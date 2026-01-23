namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from wlanapi.h.</summary>
public static partial class WlanApi
{
	/// <summary>The highest version of the Wi-Fi Direct API the client supports.</summary>
	[PInvokeData("wlanapi.h")]
	public const uint WFD_API_VERSION = 1;

	/// <summary>Current version of the Wi-Fi Direct API.</summary>
	[PInvokeData("wlanapi.h")]
	public const uint WLAN_API_VERSION = WLAN_API_VERSION_2_0;

	/// <summary>Version 1 of the Wi-Fi Direct API.</summary>
	[PInvokeData("wlanapi.h")]
	public const uint WLAN_API_VERSION_1_0 = 0x00000001;

	/// <summary>Version 2 of the Wi-Fi Direct API.</summary>
	[PInvokeData("wlanapi.h")]
	public const uint WLAN_API_VERSION_2_0 = 0x00000002;

	/// <summary>
	/// The <c>WFD_DISPLAY_SINK_NOTIFICATION_CALLBACK</c> function defines the callback function—which you implement in your app—that
	/// was specified to the <c>WFDStartDisplaySink</c> function.
	/// </summary>
	/// <param name="pvContext">An optional context pointer passed to the callback function.</param>
	/// <param name="pNotification">A pointer to a struct containing data about the display sink notification.</param>
	/// <param name="pNotificationResult">
	/// A pointer to a struct containing data that your app can optionally set to indicate the result of processing the display sink notification.
	/// </param>
	// https://docs.microsoft.com/en-us/windows/win32/nativewifi/wfd-display-sink-notification-callback DWORD CALLBACK
	// WFD_DISPLAY_SINK_NOTIFICATION_CALLBACK( _In_opt_ PVOID pvContext, _In_ const PWFD_DISPLAY_SINK_NOTIFICATION pNotification,
	// _Inout_opt_ PWFD_DISPLAY_SINK_NOTIFICATION_RESULT pNotificationResult );
	[PInvokeData("wlanapi.h", MSDNShortId = "0D4C00FD-4ED6-4F0F-BB72-0A1FCC05DB37")]
	public delegate uint WFD_DISPLAY_SINK_NOTIFICATION_CALLBACK([In, Optional] IntPtr pvContext, [In] IntPtr pNotification, [In, Out, Optional] IntPtr pNotificationResult);

	/// <summary>
	/// The <c>WFD_OPEN_SESSION_COMPLETE_CALLBACK</c> function defines the callback function that is called by the WFDStartOpenSession
	/// function when the <c>WFDStartOpenSession</c> operation completes.
	/// </summary>
	/// <param name="hSessionHandle">
	/// A session handle to a Wi-Fi Direct session. This is a session handle previously returned by the WFDStartOpenSession function.
	/// </param>
	/// <param name="pvContext">An context pointer passed to the callback function from the WFDStartOpenSession function.</param>
	/// <param name="guidSessionInterface">
	/// The interface GUID of the local network interface on which this Wi-Fi Direct device has an open session. This parameter is
	/// useful if higher-layer protocols need to determine which network interface a Wi-Fi Direct session is bound to. This value is
	/// only returned if the dwError parameter is ERROR_SUCCESS.
	/// </param>
	/// <param name="dwError">
	/// <para>
	/// A value that specifies whether there was an error encountered during the call to the WFDStartOpenSession function. If this value
	/// is ERROR_SUCCESS, then no error occurred and the operation to open the session completed successfully.
	/// </para>
	/// <para>The following other values are possible:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The parameter is incorrect. This error is returned if the hClientHandle parameter is NULL or not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_STATE</term>
	/// <term>
	/// The group or resource is not in the correct state to perform the requested operation. This error is returned if the Wi-Fi Direct
	/// service is disabled by group policy on a domain.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started. This error is returned if the WLAN AutoConfig Service is not running.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various RPC and other error codes. Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwReasonCode">A value that specifies the more detail if an error occurred during WFDStartOpenSession.</param>
	/// <returns>This callback function does not return a value.</returns>
	/// <remarks>
	/// <para>
	/// The <c>WFD_OPEN_SESSION_COMPLETE_CALLBACK</c> function is part of Wi-Fi Direct, a new feature in Windows 8 and Windows Server
	/// 2012. Wi-Fi Direct is based on the development of the Wi-Fi Peer-to-Peer Technical Specification v1.1 by the Wi-Fi Alliance (see
	/// Wi-Fi Alliance Published Specifications). The goal of the Wi-Fi Peer-to-Peer Technical Specification is to provide a solution
	/// for Wi-Fi device-to-device connectivity without the need for either a Wireless Access Point (wireless AP) to setup the
	/// connection or the use of the existing Wi-Fi adhoc (IBSS) mechanism.
	/// </para>
	/// <para>
	/// The WFDStartOpenSession function starts an asynchronous operation to start an on-demand connection to a specific Wi-Fi Direct
	/// device. The target Wi-Fi device must previously have been paired through the Windows Pairing experience. When the asynchronous
	/// operation to make the Wi-FI Direct connection completes, the callback function specified in the pfnCallback parameter is called.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nc-wlanapi-wfd_open_session_complete_callback
	// WFD_OPEN_SESSION_COMPLETE_CALLBACK WfdOpenSessionCompleteCallback; void WfdOpenSessionCompleteCallback( HANDLE hSessionHandle,
	// PVOID pvContext, GUID guidSessionInterface, DWORD dwError, DWORD dwReasonCode ) {...}
	[PInvokeData("wlanapi.h", MSDNShortId = "2CB91D70-920A-4D97-B96D-B264F59150AC")]
	public delegate void WFD_OPEN_SESSION_COMPLETE_CALLBACK(HWFDSESSION hSessionHandle, IntPtr pvContext, Guid guidSessionInterface, uint dwError, uint dwReasonCode);

	/// <summary>The <c>WLAN_NOTIFICATION_CALLBACK</c> callback function prototype defines the type of notification callback function.</summary>
	/// <param name="Arg1">Contains detailed information on the notification.</param>
	/// <param name="Arg2">
	/// Contains a pointer to the client context passed in the pCallbackContext parameter to the WlanRegisterNotification function. This
	/// client context can be a NULL pointer if that is what was passed to the WlanRegisterNotification function.
	/// </param>
	/// <returns>This callback function does not return a value.</returns>
	/// <remarks>
	/// <para>
	/// The WlanRegisterNotification function is used by an application to register and unregister notifications on all wireless
	/// interfaces. When registering for notifications, an application must provide a callback function pointed to by the funcCallback
	/// parameter passed to the <c>WlanRegisterNotification</c> function. The prototype for this callback function is the
	/// <c>WLAN_NOTIFICATION_CALLBACK</c>. This callback function will receive notifications that have been registered in the
	/// dwNotifSource parameter passed to the <c>WlanRegisterNotification</c> function.
	/// </para>
	/// <para>
	/// The callback function is called with a pointer to a WLAN_NOTIFICATION_DATA structure as the first parameter that contains
	/// detailed information on the notification. The callback function also receives a second parameter that contains a pointer to the
	/// client context passed in the pCallbackContext parameter to the WlanRegisterNotification function. This client context can be a
	/// <c>NULL</c> pointer if that is what was passed to the <c>WlanRegisterNotification</c> function.
	/// </para>
	/// <para>
	/// Once registered, the callback function will be called whenever a notification is available until the client unregisters or
	/// closes the handle.
	/// </para>
	/// <para>
	/// Any registration to receive notifications is automatically undone if the calling application closes its calling handle (by
	/// calling WlanCloseHandle with the hClientHandle parameter) used to register for notifications with the WlanRegisterNotification
	/// function or if the process ends.
	/// </para>
	/// <para>
	/// If the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure received by the callback function is
	/// <c>WLAN_NOTIFICATION_SOURCE_ACM</c>, then the received notification is an auto configuration module notification. The
	/// <c>NotificationCode</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure passed to the <c>WLAN_NOTIFICATION_CALLBACK</c>
	/// function determines the interpretation of the pData member of <c>WLAN_NOTIFICATION_DATA</c> structure. For more information on
	/// these notifications, see the WLAN_NOTIFICATION_ACM enumeration reference.
	/// </para>
	/// <para>
	/// If the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure received by the callback function is
	/// <c>WLAN_NOTIFICATION_SOURCE_HNWK</c>, then the received notification is a wireless Hosted Network notification supported on
	/// Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed. The <c>NotificationCode</c> member of the
	/// <c>WLAN_NOTIFICATION_DATA</c> structure passed to the <c>WLAN_NOTIFICATION_CALLBACK</c> function determines the interpretation
	/// of the pData member of <c>WLAN_NOTIFICATION_DATA</c> structure. For more information on these notifications, see the
	/// WLAN_HOSTED_NETWORK_NOTIFICATION_CODE enumeration reference.
	/// </para>
	/// <para>
	/// If the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure received by the callback function is
	/// <c>WLAN_NOTIFICATION_SOURCE_IHV</c>, then the received notification is an indepent hardware vendor (IHV) notification. The
	/// <c>NotificationCode</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure passed to the <c>WLAN_NOTIFICATION_CALLBACK</c>
	/// function determines the interpretation of the pData member of <c>WLAN_NOTIFICATION_DATA</c> structure, which is specific to the IHV.
	/// </para>
	/// <para>
	/// If the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure received by the callback function is
	/// <c>WLAN_NOTIFICATION_SOURCE_ONEX</c>, then the received notification is an 802.1X module notification. The
	/// <c>NotificationCode</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure passed to the <c>WLAN_NOTIFICATION_CALLBACK</c>
	/// function determines the interpretation of the pData member of <c>WLAN_NOTIFICATION_DATA</c> structure. For more information on
	/// these notifications, see the ONEX_NOTIFICATION_TYPE enumeration reference.
	/// </para>
	/// <para>
	/// If the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure received by the callback function is
	/// <c>WLAN_NOTIFICATION_SOURCE_MSM</c>, then the received notification is a media specific module (MSM) notification. The
	/// <c>NotificationCode</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure passed to the <c>WLAN_NOTIFICATION_CALLBACK</c>
	/// function determines the interpretation of the pData member of <c>WLAN_NOTIFICATION_DATA</c> structure. For more information on
	/// these notifications, see the WLAN_NOTIFICATION_MSM enumeration reference.
	/// </para>
	/// <para>
	/// If the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure received by the callback function is
	/// <c>WLAN_NOTIFICATION_SOURCE_SECURITY</c>, then the received notification is a security notification. No notifications are
	/// currently defined for <c>WLAN_NOTIFICATION_SOURCE_SECURITY</c>.
	/// </para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> Notifications are handled by the Netman service. If the
	/// Netman service is disabled or unavailable, notifications will not be received. If a notification is not received within a
	/// reasonable period of time, an application should time out and query the current interface state.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nc-wlanapi-wlan_notification_callback WLAN_NOTIFICATION_CALLBACK
	// WlanNotificationCallback; void WlanNotificationCallback( PWLAN_NOTIFICATION_DATA Arg1, PVOID Arg2 ) {...}
	[PInvokeData("wlanapi.h", MSDNShortId = "df721e77-3285-442b-aabd-2dccae85fda5")]
	public delegate void WLAN_NOTIFICATION_CALLBACK(ref WLAN_NOTIFICATION_DATA Arg1, [Optional] IntPtr Arg2);

	/// <summary>
	/// The <c>WFDCancelOpenSession</c> function indicates that the application wants to cancel a pending WFDStartOpenSession function
	/// that has not completed.
	/// </summary>
	/// <param name="hSessionHandle">
	/// A session handle to a Wi-Fi Direct session to cancel. This is a session handle previously returned by the WFDStartOpenSession function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// The handle is invalid. This error is returned if the handle specified in the hSessionHandle parameter was not found in the
	/// handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The parameter is incorrect. This error is returned if the hSessionHandle parameter is NULL or not valid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WFDCancelOpenSession</c> function is part of Wi-Fi Direct, a new feature in Windows 8 and Windows Server 2012. Wi-Fi
	/// Direct is based on the development of the Wi-Fi Peer-to-Peer Technical Specification v1.1 by the Wi-Fi Alliance (see Wi-Fi
	/// Alliance Published Specifications). The goal of the Wi-Fi Peer-to-Peer Technical Specification is to provide a solution for
	/// Wi-Fi device-to-device connectivity without the need for either a Wireless Access Point (wireless AP) to setup the connection or
	/// the use of the existing Wi-Fi adhoc (IBSS) mechanism.
	/// </para>
	/// <para>
	/// A call to the <c>WFDCancelOpenSession</c> function notifies the Wi-Fi Direct service that the client requests a cancellation of
	/// this session. The <c>WFDCancelOpenSession</c> function does not modify the expected WFDStartOpenSession behavior. The callback
	/// function specified to the <c>WFDStartOpenSession</c> function will still be called, and the <c>WFDStartOpenSession</c> function
	/// may not be completed immediately.
	/// </para>
	/// <para>
	/// It is the responsibility of the caller to pass the <c>WFDCancelOpenSession</c> function a handle in the hSessionHandle parameter
	/// that was returned from call to the WFDStartOpenSession function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wfdcancelopensession DWORD WFDCancelOpenSession( HANDLE
	// hSessionHandle );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "0BE3DAED-C9B1-492B-BDFC-CB32BE23E700")]
	public static extern Win32Error WFDCancelOpenSession(HWFDSESSION hSessionHandle);

	/// <summary>The <c>WFDCloseHandle</c> function closes a handle to the Wi-Fi Direct service.</summary>
	/// <param name="hClientHandle">
	/// A client handle to the Wi-Fi Direct service. This handle was obtained by a previous call to the WFDOpenHandle function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// The handle is invalid. This error is returned if the handle specified in the hClientHandle parameter was not found in the handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The parameter is incorrect. This error is returned if the hClientHandle parameter is NULL or not valid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WFDCloseHandle</c> function is part of Wi-Fi Direct, a new feature in Windows 8 and Windows Server 2012. Wi-Fi Direct is
	/// based on the development of the Wi-Fi Peer-to-Peer Technical Specification v1.1 by the Wi-Fi Alliance (see Wi-Fi Alliance
	/// Published Specifications). The goal of the Wi-Fi Peer-to-Peer Technical Specification is to provide a solution for Wi-Fi
	/// device-to-device connectivity without the need for either a Wireless Access Point (wireless AP) to setup the connection or the
	/// use of the existing Wi-Fi adhoc (IBSS) mechanism.
	/// </para>
	/// <para>
	/// In order to use Wi-Fi Direct, an application must first obtain a handle to the Wi-Fi Direct service by calling the WFDOpenHandle
	/// function. The Wi-Fi Direct (WFD) handle returned by the <c>WFDOpenHandle</c> function is used for subsequent calls made to the
	/// Wi-Fi Direct service. Once an application is done using the Wi-Fi Direct service, the application should call the
	/// <c>WFDCloseHandle</c> function to signal to the Wi-Fi Direct service that the application is done using the service. This allows
	/// the Wi-Fi Direct service to release resources used by the application.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wfdclosehandle DWORD WFDCloseHandle( HANDLE hClientHandle );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "A27C0AE1-1C51-4CAC-8929-63870ADB15A7")]
	public static extern Win32Error WFDCloseHandle(HWFDSERVICE hClientHandle);

	/// <summary>
	/// The <c>WFDOpenHandle</c> function opens a handle to the Wi-Fi Direct service and negotiates a version of the Wi-FI Direct API to use.
	/// </summary>
	/// <param name="dwClientVersion">
	/// <para>The highest version of the Wi-Fi Direct API the client supports.</para>
	/// <para>
	/// For Windows 8 and Windows Server 2012, this parameter should be set to <c>WFD_API_VERSION</c>, constant defined in the Wlanapi.h
	/// header file.
	/// </para>
	/// </param>
	/// <param name="pdwNegotiatedVersion">
	/// <para>A pointer to a <c>DWORD</c> to received the negotiated version.</para>
	/// <para>
	/// If the <c>WFDOpenHandle</c> function is successful, the version negotiated with the Wi-Fi Direct Service to be used by this
	/// session is returned. This value is usually the highest version supported by both the client and Wi-Fi Direct service.
	/// </para>
	/// </param>
	/// <param name="phClientHandle">
	/// <para>A pointer to a <c>HANDLE</c> to receive the handle to the Wi-Fi Direct service for this session.</para>
	/// <para>If the <c>WFDOpenHandle</c> function is successful, a handle to the Wi-Fi Direct service to use in this session is returned.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// The parameter is incorrect. This error is returned if the pdwNegotiatedVersion parameter is NULL or the phClientHandle parameter
	/// is NULL. This value is also returned if the dwClientVersion parameter is not equal to WFD_API_VERSION.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Not enough storage is available to process this command. This error is returned if the system was unable to allocate memory to
	/// create the client context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_REMOTE_SESSION_LIMIT_EXCEEDED</term>
	/// <term>
	/// An attempt was made to establish a session to a network server, but there are already too many sessions established to that
	/// server. This error is returned if too many handles have been issued by the Wi-Fi Direct service.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WFDOpenHandle</c> function is part of Wi-Fi Direct, a new feature in Windows 8 and Windows Server 2012. Wi-Fi Direct is
	/// based on the development of the Wi-Fi Peer-to-Peer Technical Specification v1.1 by the Wi-Fi Alliance (see Wi-Fi Alliance
	/// Published Specifications). The goal of the Wi-Fi Peer-to-Peer Technical Specification is to provide a solution for Wi-Fi
	/// device-to-device connectivity without the need for either a Wireless Access Point (wireless AP) to setup the connection or the
	/// use of the existing Wi-Fi adhoc (IBSS) mechanism.
	/// </para>
	/// <para>
	/// In order to use Wi-Fi Direct, an application must first obtain a handle to the Wi-Fi Direct service by calling the
	/// <c>WFDOpenHandle</c> function. The Wi-Fi Direct (WFD) handle returned by the <c>WFDOpenHandle</c> function is used for
	/// subsequent calls made to the Wi-Fi Direct service. Once an application is done using the Wi-Fi Direct service, the application
	/// should call the WFDCloseHandle function to signal to the Wi-Fi Direct service that the application is done using the service.
	/// This allows the Wi-Fi Direct service to release resources used by the application.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wfdopenhandle DWORD WFDOpenHandle( DWORD dwClientVersion,
	// PDWORD pdwNegotiatedVersion, PHANDLE phClientHandle );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "D89FAC10-BC33-44BE-ABC8-962241949281")]
	public static extern Win32Error WFDOpenHandle(uint dwClientVersion, out uint pdwNegotiatedVersion, out SafeHWFDSERVICE phClientHandle);

	/// <summary>The <c>WFDOpenLegacySession</c> function retrieves and applies a stored profile for a Wi-Fi Direct legacy device.</summary>
	/// <param name="hClientHandle">
	/// A <c>HANDLE</c> to the Wi-Fi Direct service for this session. This parameter is retrieved using the WFDOpenHandle function.
	/// </param>
	/// <param name="pLegacyMacAddress">A pointer to Wi-Fi Direct device address of the legacy client device.</param>
	/// <param name="phSessionHandle">
	/// <para>A pointer to a <c>HANDLE</c> to receive the handle to the Wi-Fi Direct service for this session.</para>
	/// <para>
	/// If the <c>WFDOpenLegacySession</c> function is successful, a handle to the Wi-Fi Direct service to use in this session is returned.
	/// </para>
	/// </param>
	/// <param name="pGuidSessionInterface">
	/// <para>A pointer to the GUID of the network interface for this session.</para>
	/// <para>
	/// If the <c>WFDOpenLegacySession</c> function is successful, a GUID of the network interface on which Wi-Fi Direct session is returned.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The parameter is incorrect. This error is returned if the phClientHandle or the pLegacyMacAddress parameter is NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Not enough storage is available to process this command. This error is returned if the system was unable to allocate memory to
	/// create the client context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WFDOpenLegacySession</c> function is part of Wi-Fi Direct, a new feature in Windows 8 and Windows Server 2012. Wi-Fi
	/// Direct is based on the development of the Wi-Fi Peer-to-Peer Technical Specification v1.1 by the Wi-Fi Alliance (see Wi-Fi
	/// Alliance Published Specifications). The goal of the Wi-Fi Peer-to-Peer Technical Specification is to provide a solution for
	/// Wi-Fi device-to-device connectivity without the need for either a Wireless Access Point (wireless AP) to setup the connection or
	/// the use of the existing Wi-Fi adhoc (IBSS) mechanism.
	/// </para>
	/// <para>
	/// In order to use Wi-Fi Direct, an application must first obtain a handle to the Wi-Fi Direct service by calling the
	/// <c>WFDOpenLegacySession</c> or WFDOpenHandle function. The Wi-Fi Direct (WFD) handle returned by the <c>WFDOpenHandle</c>
	/// function is used for subsequent calls made to the Wi-Fi Direct service. The <c>WFDOpenLegacySession</c> function is used to
	/// retrieve and apply a stored profile for a Wi-Fi Direct legacy device.
	/// </para>
	/// <para>
	/// The <c>WFDOpenLegacySession</c> function retrieves the stored legacy profile for device from the profile store for the specified
	/// legacy device address. This device address must be obtained from a Device Node created as a result of the Inbox pairing
	/// experience (Legacy WPS Pairing).
	/// </para>
	/// <para>
	/// Once an application is done using the Wi-Fi Direct service, the application should call the WFDCloseSession function to close
	/// the session and call the WFDCloseHandle function to signal to the Wi-Fi Direct service that the application is done using the
	/// service. This allows the Wi-Fi Direct service to release resources used by the application.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wfdopenlegacysession DWORD WFDOpenLegacySession( HANDLE
	// hClientHandle, PDOT11_MAC_ADDRESS pLegacyMacAddress, HANDLE *phSessionHandle, GUID *pGuidSessionInterface );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "D7BE8108-EF18-49FC-8B14-CED45B6C682B")]
	public static extern Win32Error WFDOpenLegacySession(HWFDSERVICE hClientHandle, in DOT11_MAC_ADDRESS pLegacyMacAddress,
		out SafeHWFDSESSION phSessionHandle, out Guid pGuidSessionInterface);

	/// <summary>
	/// The <c>WFDStartOpenSession</c> function starts an on-demand connection to a specific Wi-Fi Direct device, which has been
	/// previously paired through the Windows Pairing experience.
	/// </summary>
	/// <param name="hClientHandle">
	/// A client handle to the Wi-Fi Direct service. This handle was obtained by a previous call to the WFDOpenHandle function.
	/// </param>
	/// <param name="pDeviceAddress">
	/// A pointer to the target device’s Wi-Fi Direct device address. This is the MAC address of the target Wi-Fi device.
	/// </param>
	/// <param name="pvContext">An optional context pointer which is passed to the callback function specified in the pfnCallback parameter.</param>
	/// <param name="pfnCallback">A pointer to the callback function to be called once the <c>WFDStartOpenSession</c> request has completed.</param>
	/// <param name="phSessionHandle">A handle to this specific Wi-Fi Direct session.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// The handle is invalid. This error is returned if the handle specified in the hClientHandle parameter was not found in the handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// The parameter is incorrect. This error is returned if the hClientHandle parameter is NULL or not valid. This error is also
	/// returned if the pDeviceAddress parameter is NULL, the pfnCallback parameter is NULL, or the phSessionHandle parameter is NULL.
	/// This value is also returned if the dwClientVersion parameter is not equal to WFD_API_VERSION.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_STATE</term>
	/// <term>
	/// The group or resource is not in the correct state to perform the requested operation. This error is returned if the Wi-Fi Direct
	/// service is disabled by group policy on a domain.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started. This error is returned if the WLAN AutoConfig Service is not running.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WFDStartOpenSession</c> function is part of Wi-Fi Direct, a new feature in Windows 8 and Windows Server 2012. Wi-Fi
	/// Direct is based on the development of the Wi-Fi Peer-to-Peer Technical Specification v1.1 by the Wi-Fi Alliance (see Wi-Fi
	/// Alliance Published Specifications). The goal of the Wi-Fi Peer-to-Peer Technical Specification is to provide a solution for
	/// Wi-Fi device-to-device connectivity without the need for either a Wireless Access Point (wireless AP) to setup the connection or
	/// the use of the existing Wi-Fi adhoc (IBSS) mechanism.
	/// </para>
	/// <para>
	/// The <c>WFDStartOpenSession</c> function starts an asynchronous operation to start an on-demand connection to a specific Wi-Fi
	/// Direct device. The target Wi-Fi device must previously have been paired through the Windows Pairing experience. When the
	/// asynchronous operation completes, the callback function specified in the pfnCallback parameter is called.
	/// </para>
	/// <para>
	/// If the application attempts to close the handle to the Wi-Fi Direct service by calling the WFDCloseHandle function before the
	/// <c>WFDStartOpenSession</c> function completes asynchronously, the <c>WFDCloseHandle</c> function will wait until the
	/// <c>WFDStartOpenSession</c> call is completed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wfdstartopensession DWORD WFDStartOpenSession( HANDLE
	// hClientHandle, PDOT11_MAC_ADDRESS pDeviceAddress, PVOID pvContext, WFD_OPEN_SESSION_COMPLETE_CALLBACK pfnCallback, PHANDLE
	// phSessionHandle );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "CF1FF7C2-31CD-4FAB-9891-0A72BEA3E9F1")]
	public static extern Win32Error WFDStartOpenSession(HWFDSERVICE hClientHandle, in DOT11_MAC_ADDRESS pDeviceAddress, [In, Optional] IntPtr pvContext,
		[MarshalAs(UnmanagedType.FunctionPtr)] WFD_OPEN_SESSION_COMPLETE_CALLBACK pfnCallback, out SafeHWFDSESSION phSessionHandle);

	/// <summary>
	/// The <c>WFDUpdateDeviceVisibility</c> function updates device visibility for the Wi-Fi Direct device address for a given
	/// installed Wi-Fi Direct device node.
	/// </summary>
	/// <param name="pDeviceAddress">
	/// <para>A pointer to the Wi-Fi Direct device address of the client device.</para>
	/// <para>This device address must be obtained from a Device Node created as a result of the Inbox pairing experience.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The parameter is incorrect. This error is returned if the pDeviceAddress parameter is NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Not enough storage is available to process this command.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WFDUpdateDeviceVisibility</c> function is part of Wi-Fi Direct, a new feature in Windows 8 and Windows Server 2012. Wi-Fi
	/// Direct is based on the development of the Wi-Fi Peer-to-Peer Technical Specification v1.1 by the Wi-Fi Alliance (see Wi-Fi
	/// Alliance Published Specifications). The goal of the Wi-Fi Peer-to-Peer Technical Specification is to provide a solution for
	/// Wi-Fi device-to-device connectivity without the need for either a Wireless Access Point (wireless AP) to setup the connection or
	/// the use of the existing Wi-Fi adhoc (IBSS) mechanism.
	/// </para>
	/// <para>
	/// The <c>WFDUpdateDeviceVisibility</c> function will perform a targeted Wi-Fi Direct discovery, and will update the
	/// DEVPKEY_WiFiDirect_IsVisibile property key on the device node for the given device.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wfdupdatedevicevisibility DWORD WFDUpdateDeviceVisibility(
	// PDOT11_MAC_ADDRESS pDeviceAddress );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "696B7466-5ED0-4202-9AAF-CE2544C5A5B8")]
	public static extern Win32Error WFDUpdateDeviceVisibility(in DOT11_MAC_ADDRESS pDeviceAddress);

	/// <summary>Makes a WLAN version from major and minor parts..</summary>
	/// <param name="_major">The major version part.</param>
	/// <param name="_minor">The minor version part.</param>
	/// <returns>The version.</returns>
	public static uint WLAN_API_MAKE_VERSION(ushort _major, ushort _minor) => ((uint)_minor) << 16 | (_major);

	/// <summary>Gets the WLAN major API version.</summary>
	/// <param name="_v">The version.</param>
	/// <returns>The major value of the version.</returns>
	public static uint WLAN_API_VERSION_MAJOR(uint _v) => (_v) & 0xffff;

	/// <summary>Gets the WLAN minor API version.</summary>
	/// <param name="_v">The version.</param>
	/// <returns>The minor value of the version.</returns>
	public static uint WLAN_API_VERSION_MINOR(uint _v) => (_v) >> 16;

	/// <summary>
	/// The <c>WlanAllocateMemory</c> function allocates memory. Any memory passed to other Native Wifi functions must be allocated with
	/// this function.
	/// </summary>
	/// <param name="dwMemorySize">Amount of memory being requested, in bytes.</param>
	/// <returns>
	/// <para>If the call is successful, the function returns a pointer to the allocated memory.</para>
	/// <para>If the memory could not be allocated for any reason or if the dwMemorySize parameter is 0, the returned pointer is <c>NULL</c>.</para>
	/// <para>An application can call GetLastError to obtain extended error information.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanallocatememory PVOID WlanAllocateMemory( DWORD
	// dwMemorySize );
	[DllImport(Lib.Wlanapi, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "29200450-4ec8-418d-b633-1ea688755711")]
	public static extern SafeHWLANMEM WlanAllocateMemory(uint dwMemorySize);

	/// <summary>The <c>WlanCloseHandle</c> function closes a connection to the server.</summary>
	/// <param name="hClientHandle">
	/// The client's session handle, which identifies the connection to be closed. This handle was obtained by a previous call to the
	/// WlanOpenHandle function.
	/// </param>
	/// <param name="pReserved">Reserved for future use. Set this parameter to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>hClientHandle is NULL or invalid, or pReserved is not NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// After a connection has been closed, any attempted use of the closed handle can cause unexpected errors. Upon closing, all
	/// outstanding notifications are discarded.
	/// </para>
	/// <para>
	/// Do not call <c>WlanCloseHandle</c> from a callback function. If the client is in the middle of a notification callback when
	/// <c>WlanCloseHandle</c> is called, the function waits for the callback to finish before returning a value. Calling this function
	/// inside a callback function will result in the call never completing. If both the callback function and the thread that closes
	/// the handle try to acquire the same lock, a deadlock may occur. In addition, do not call <c>WlanCloseHandle</c> from the
	/// <c>DllMain</c> function in an application DLL. This could also cause a deadlock.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanclosehandle DWORD WlanCloseHandle( HANDLE
	// hClientHandle, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "8e944133-2616-4e17-ac38-c17e8d25ccec")]
	public static extern Win32Error WlanCloseHandle(HWLANSESSION hClientHandle, IntPtr pReserved = default);

	/// <summary>The <c>WlanConnect</c> function attempts to connect to a specific network.</summary>
	/// <param name="hClientHandle">The client's session handle, returned by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">The GUID of the interface to use for the connection.</param>
	/// <param name="pConnectionParameters">
	/// <para>
	/// Pointer to a WLAN_CONNECTION_PARAMETERS structure that specifies the connection type, mode, network profile, SSID that
	/// identifies the network, and other parameters.
	/// </para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> There are some constraints on the
	/// WLAN_CONNECTION_PARAMETERS members. This means that structures that are valid for Windows Server 2008 and Windows Vista may not
	/// be valid for Windows XP with SP3 or Wireless LAN API for Windows XP with SP2. For a list of constraints, see <c>WLAN_CONNECTION_PARAMETERS</c>.
	/// </para>
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the following conditions occurred:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have sufficient permissions.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanConnect</c> function returns immediately. To be notified when a connection is established or when no further
	/// connections will be attempted, a client must register for notifications by calling WlanRegisterNotification.
	/// </para>
	/// <para>
	/// The <c>strProfile</c> member of the WLAN_CONNECTION_PARAMETERS structure pointed to by pConnectionParameters specifies the
	/// profile to use for connection. If this profile is an all-user profile, the <c>WlanConnect</c> caller must have execute access on
	/// the profile. Otherwise, the <c>WlanConnect</c> call will fail with return value ERROR_ACCESS_DENIED. The permissions on an
	/// all-user profile are established when the profile is created or saved using WlanSetProfile or WlanSaveTemporaryProfile.
	/// </para>
	/// <para>
	/// To perform a connection operation at the command line, use the <c>netsh wlan connect</c> command. For more information, see
	/// Netsh Commands for Wireless Local Area Network (wlan).
	/// </para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> You can only use <c>WlanConnect</c> to connect to
	/// networks on the preferred network list. To add a network to the preferred network list, call WlanSetProfile.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanconnect DWORD WlanConnect( HANDLE hClientHandle, const
	// GUID *pInterfaceGuid, const PWLAN_CONNECTION_PARAMETERS pConnectionParameters, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "24ab2024-e786-454f-860f-cf2431f001bb")]
	public static extern Win32Error WlanConnect(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, in WLAN_CONNECTION_PARAMETERS pConnectionParameters, IntPtr pReserved = default);

	/// <summary>The <c>WlanDeleteProfile</c> function deletes a wireless profile for a wireless interface on the local computer.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">The GUID of the interface from which to delete the profile.</param>
	/// <param name="strProfileName">
	/// <para>The name of the profile to be deleted. Profile names are case-sensitive. This string must be NULL-terminated.</para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> The supplied name must match the profile name derived
	/// automatically from the SSID of the network. For an infrastructure network profile, the SSID must be supplied for the profile
	/// name. For an ad hoc network profile, the supplied name must be the SSID of the ad hoc network followed by .
	/// </para>
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// The hClientHandle parameter is NULL or not valid, the pInterfaceGuid parameter is NULL, the strProfileName parameter is NULL, or
	/// pReserved is not NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle specified in the hClientHandle parameter was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>The wireless profile specified by strProfileName was not found in the profile store.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have sufficient permissions to delete the profile.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>WlanDeleteProfile</c> function deletes a wireless profile for a wireless interface on the local computer.</para>
	/// <para>
	/// All wireless LAN functions require an interface GUID for the wireless interface when performing profile operations. When a
	/// wireless interface is removed, its state is cleared from Wireless LAN Service (WLANSVC) and no profile operations are possible.
	/// </para>
	/// <para>
	/// The <c>WlanDeleteProfile</c> function can fail with <c>ERROR_INVALID_PARAMETER</c> if the wireless interface specified in the
	/// pInterfaceGuid parameter for the wireless LAN profile has been removed from the system (a USB wireless adapter that has been
	/// removed, for example).
	/// </para>
	/// <para>
	/// To delete a profile at the command line, use the <c>netsh wlan delete profile</c> command. For more information, see Netsh
	/// Commands for Wireless Local Area Network (wlan).
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example enumerates the wireless LAN interfaces on the local computer and tries to delete a specific wireless
	/// profile on each wireless LAN interface.
	/// </para>
	/// <para>
	/// <c>Note</c> This example will fail to load on Windows Server 2008 and Windows Server 2008 R2 if the Wireless LAN Service is not
	/// installed and started.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlandeleteprofile DWORD WlanDeleteProfile( HANDLE
	// hClientHandle, const GUID *pInterfaceGuid, LPCWSTR strProfileName, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "2d1152ad-8106-4b8f-9856-9e6e36daa063")]
	public static extern Win32Error WlanDeleteProfile(HWLANSESSION hClientHandle, in Guid pInterfaceGuid,
		[MarshalAs(UnmanagedType.LPWStr)] string strProfileName, IntPtr pReserved = default);

	/// <summary>
	/// Allows an original equipment manufacturer (OEM) or independent hardware vendor (IHV) component to communicate with a device
	/// service on a particular wireless LAN interface.
	/// </summary>
	/// <param name="hClientHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>The client's session handle, obtained by a previous call to the WlanOpenHandle function.</para>
	/// </param>
	/// <param name="pInterfaceGuid">
	/// <para>Type: <c>CONST GUID*</c></para>
	/// <para>
	/// A pointer to the <c>GUID</c> of the wireless LAN interface to be queried. You can determine the <c>GUID</c> of each wireless LAN
	/// interface enabled on a local computer by using the WlanEnumInterfaces function.
	/// </para>
	/// </param>
	/// <param name="pDeviceServiceGuid">
	/// <para>Type: <c>GUID*</c></para>
	/// <para>The <c>GUID</c> identifying the device service for this command.</para>
	/// </param>
	/// <param name="dwOpCode">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The operational code identifying the operation to be performed on the device service.</para>
	/// </param>
	/// <param name="dwInBufferSize">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The size, in bytes, of the input buffer.</para>
	/// </param>
	/// <param name="pInBuffer">
	/// <para>Type: <c>PVOID</c></para>
	/// <para>A generic buffer for command input.</para>
	/// </param>
	/// <param name="dwOutBufferSize">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The size, in bytes, of the output buffer.</para>
	/// </param>
	/// <param name="pOutBuffer">
	/// <para>Type: <c>PVOID</c></para>
	/// <para>A generic buffer for command output.</para>
	/// </param>
	/// <param name="pdwBytesReturned">
	/// <para>Type: <c>PDWORD</c></para>
	/// <para>The number of bytes returned.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. If the function fails with <c>ERROR_ACCESS_DENIED</c>, then
	/// the caller doesn't have sufficient permissions to perform this operation. The caller needs to either have admin privilege, or
	/// needs to be a UMDF driver.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlandeviceservicecommand DWORD WlanDeviceServiceCommand(
	// HANDLE hClientHandle, const GUID *pInterfaceGuid, LPGUID pDeviceServiceGuid, DWORD dwOpCode, DWORD dwInBufferSize, PVOID
	// pInBuffer, DWORD dwOutBufferSize, PVOID pOutBuffer, PDWORD pdwBytesReturned );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h")]
	public static extern Win32Error WlanDeviceServiceCommand(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, in Guid pDeviceServiceGuid, uint dwOpCode,
		uint dwInBufferSize, [In, Optional] IntPtr pInBuffer, uint dwOutBufferSize, [In, Out, Optional] IntPtr pOutBuffer, out uint pdwBytesReturned);

	/// <summary>The <c>WlanDisconnect</c> function disconnects an interface from its current network.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">The GUID of the interface to be disconnected.</param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>hClientHandle is NULL or invalid, pInterfaceGuid is NULL, or pReserved is not NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Failed to allocate memory for the query results.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have sufficient permissions.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When the connection was established using WlanConnect, a profile was specified by the <c>strProfile</c> member of the
	/// WLAN_CONNECTION_PARAMETERS structure pointed to by pConnectionParameters. If that profile was an all-user profile, the
	/// <c>WlanDisconnect</c> caller must have execute access on the profile. Otherwise, the <c>WlanDisconnect</c> call will fail with
	/// return value ERROR_ACCESS_DENIED. The permissions on an all-user profile are established when the profile is created or saved
	/// using WlanSetProfile or WlanSaveTemporaryProfile.
	/// </para>
	/// <para>
	/// To perform a disconnection operation at the command line, use the <c>netsh wlan disconnect</c> command. For more information,
	/// see Netsh Commands for Wireless Local Area Network (wlan).
	/// </para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c><c>WlanDisconnect</c> has the side effect of modifying
	/// the profile associated with the disconnected network. A network profile becomes an on-demand profile after a
	/// <c>WlanDisconnect</c> call. The Wireless Zero Configuration service will not connect automatically to a network with an
	/// on-demand profile when the network is in range. Do not call <c>WlanDisconnect</c> before calling WlanConnect unless you want to
	/// change a profile to an on-demand profile. When you call <c>WlanConnect</c> to establish a network connection, any existing
	/// network connection is dropped automatically.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlandisconnect DWORD WlanDisconnect( HANDLE hClientHandle,
	// const GUID *pInterfaceGuid, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "cc48ee72-3125-45a0-ac16-0c520ee3cd44")]
	public static extern Win32Error WlanDisconnect(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, IntPtr pReserved = default);

	/// <summary>
	/// The <c>WlanEnumInterfaces</c> function enumerates all of the wireless LAN interfaces currently enabled on the local computer.
	/// </summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pReserved">Reserved for future use. This parameter must be set to <c>NULL</c>.</param>
	/// <param name="ppInterfaceList">
	/// <para>
	/// A pointer to storage for a pointer to receive the returned list of wireless LAN interfaces in a WLAN_INTERFACE_INFO_LIST structure.
	/// </para>
	/// <para>
	/// The buffer for the WLAN_INTERFACE_INFO_LIST returned is allocated by the <c>WlanEnumInterfaces</c> function if the call succeeds.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// A parameter is incorrect. This error is returned if the hClientHandle or ppInterfaceList parameter is NULL. This error is
	/// returned if the pReserved is not NULL. This error is also returned if the hClientHandle parameter is not valid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Not enough memory is available to process this request and allocate memory for the query results.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanEnumInterfaces</c> function allocates memory for the list of returned interfaces that is returned in the buffer
	/// pointed to by the ppInterfaceList parameter when the function succeeds. The memory used for the buffer pointed to by
	/// ppInterfaceList parameter should be released by calling the WlanFreeMemory function after the buffer is no longer needed.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example enumerates the wireless LAN interfaces on the local computer and prints values from the retrieved
	/// WLAN_INTERFACE_INFO_LIST structure and the enumerated WLAN_INTERFACE_INFO structures.
	/// </para>
	/// <para>
	/// <c>Note</c> This example will fail to load on Windows Server 2008 and Windows Server 2008 R2 if the Wireless LAN Service is not
	/// installed and started.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanenuminterfaces DWORD WlanEnumInterfaces( HANDLE
	// hClientHandle, PVOID pReserved, PWLAN_INTERFACE_INFO_LIST *ppInterfaceList );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "7f817edf-1b1d-495c-afd9-d97e3ae0caab")]
	public static extern Win32Error WlanEnumInterfaces(HWLANSESSION hClientHandle, [Optional] IntPtr pReserved,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(WlanMarshaler<WLAN_INTERFACE_INFO_LIST>))] out WLAN_INTERFACE_INFO_LIST ppInterfaceList);

	/// <summary>
	/// The <c>WlanExtractPsdIEDataList</c> function extracts the proximity service discovery (PSD) information element (IE) data list
	/// from raw IE data included in a beacon.
	/// </summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="dwIeDataSize">The size, in bytes, of the pRawIeData parameter.</param>
	/// <param name="pRawIeData">The raw IE data for all IEs in the list.</param>
	/// <param name="strFormat">Describes the format of a PSD IE. Only IEs with a matching format are returned.</param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <param name="ppPsdIEDataList">A pointer to a PWLAN_RAW_DATA_LIST structure that contains the formatted data list.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>hClientHandle is NULL or invalid, dwIeDataSize is 0, pRawIeData is NULL, or pReserved is not NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// This function was called from an unsupported platform. This value will be returned if this function was called from a Windows XP
	/// with SP3 or Wireless LAN API for Windows XP with SP2 client.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>For more information about PSD IEs, including a discussion of the format of an IE, see WlanSetPsdIEDataList.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanextractpsdiedatalist DWORD WlanExtractPsdIEDataList(
	// HANDLE hClientHandle, DWORD dwIeDataSize, const PBYTE pRawIeData, LPCWSTR strFormat, PVOID pReserved, PWLAN_RAW_DATA_LIST
	// *ppPsdIEDataList );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "7fb6707f-c229-4386-9058-e290693a20ce")]
	public static extern Win32Error WlanExtractPsdIEDataList(HWLANSESSION hClientHandle, uint dwIeDataSize, [In] IntPtr pRawIeData,
		[MarshalAs(UnmanagedType.LPWStr)] string strFormat, [Optional] IntPtr pReserved, out SafeHWLANMEM ppPsdIEDataList);

	/// <summary>
	/// The <c>WlanExtractPsdIEDataList</c> function extracts the proximity service discovery (PSD) information element (IE) data list
	/// from raw IE data included in a beacon.
	/// </summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="dwIeDataSize">The size, in bytes, of the pRawIeData parameter.</param>
	/// <param name="pRawIeData">The raw IE data for all IEs in the list.</param>
	/// <param name="strFormat">Describes the format of a PSD IE. Only IEs with a matching format are returned.</param>
	/// <param name="ppPsdIEDataList">An array of byte arrays, each containing a blob in the data list.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>hClientHandle is NULL or invalid, dwIeDataSize is 0, pRawIeData is NULL, or pReserved is not NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// This function was called from an unsupported platform. This value will be returned if this function was called from a Windows XP
	/// with SP3 or Wireless LAN API for Windows XP with SP2 client.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>For more information about PSD IEs, including a discussion of the format of an IE, see WlanSetPsdIEDataList.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanextractpsdiedatalist DWORD WlanExtractPsdIEDataList(
	// HANDLE hClientHandle, DWORD dwIeDataSize, const PBYTE pRawIeData, LPCWSTR strFormat, PVOID pReserved, PWLAN_RAW_DATA_LIST
	// *ppPsdIEDataList );
	[PInvokeData("wlanapi.h", MSDNShortId = "7fb6707f-c229-4386-9058-e290693a20ce")]
	public static Win32Error WlanExtractPsdIEDataList(HWLANSESSION hClientHandle, uint dwIeDataSize, [In] IntPtr pRawIeData,
		[MarshalAs(UnmanagedType.LPWStr)] string strFormat, out byte[][]? ppPsdIEDataList)
	{
		var ret = WlanExtractPsdIEDataList(hClientHandle, dwIeDataSize, pRawIeData, strFormat, default, out var mem);
		if (ret.Succeeded)
		{
			var l = mem.DangerousGetHandle().ToStructure<WLAN_RAW_DATA_LIST>();
			ppPsdIEDataList = new byte[(int)l.dwNumberOfItems][];
			for (int i = 0; i < l.dwNumberOfItems; i++)
				ppPsdIEDataList[i] = mem.DangerousGetHandle().Offset((8 * (i + 1)) + l.DataList[i].dwDataOffset).ToByteArray((int)l.DataList[i].dwDataSize)!;
			mem?.Dispose();
		}
		else
			ppPsdIEDataList = null;
		return ret;
	}

	/// <summary>The <c>WlanFreeMemory</c> function frees memory. Any memory returned from Native Wifi functions must be freed.</summary>
	/// <param name="pMemory">Pointer to the memory to be freed.</param>
	/// <returns>None.</returns>
	/// <remarks>
	/// <para>If pMemory points to memory that has already been freed, an access violation or heap corruption may occur.</para>
	/// <para>
	/// There is a hotfix available for Wireless LAN API for Windows XP with Service Pack 2 (SP2) that can help improve the performance
	/// of applications that call <c>WlanFreeMemory</c> and WlanGetAvailableNetworkList many times. For more information, see Help and
	/// Knowledge Base article 940541, entitled "FIX: The private bytes of the application continuously increase when an application
	/// calls the WlanGetAvailableNetworkList function and the WlanFreeMemory function on a Windows XP Service Pack 2-based computer",
	/// in the Help and Support Knowledge Base at https://go.microsoft.com/fwlink/p/?linkid=102216.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanfreememory void WlanFreeMemory( PVOID pMemory );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "241afb9d-8b16-4d76-b311-302b5492853e")]
	public static extern void WlanFreeMemory(IntPtr pMemory);

	/// <summary>The <c>WlanGetAvailableNetworkList</c> function retrieves the list of available networks on a wireless LAN interface.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">
	/// <para>A pointer to the GUID of the wireless LAN interface to be queried.</para>
	/// <para>The GUID of each wireless LAN interface enabled on a local computer can be determined using the WlanEnumInterfaces function.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that control the type of networks returned in the list. This parameter can be a combination of these possible values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WLAN_AVAILABLE_NETWORK_INCLUDE_ALL_ADHOC_PROFILES 0x00000001</term>
	/// <term>Include all ad hoc network profiles in the available network list, including profiles that are not visible.</term>
	/// </item>
	/// <item>
	/// <term>WLAN_AVAILABLE_NETWORK_INCLUDE_ALL_MANUAL_HIDDEN_PROFILES 0x00000002</term>
	/// <term>Include all hidden network profiles in the available network list, including profiles that are not visible.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pReserved">Reserved for future use. This parameter must be set to <c>NULL</c>.</param>
	/// <param name="ppAvailableNetworkList">
	/// <para>A pointer to storage for a pointer to receive the returned list of visible networks in a WLAN_AVAILABLE_NETWORK_LIST structure.</para>
	/// <para>
	/// The buffer for the WLAN_AVAILABLE_NETWORK_LIST returned is allocated by the <c>WlanGetAvailableNetworkList</c> function if the
	/// call succeeds.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// A parameter is incorrect. This error is returned if the hClientHandle, pInterfaceGuid, or ppAvailableNetworkList parameter is
	/// NULL. This error is returned if the pReserved is not NULL. This error is also returned if the dwFlags parameter value is set to
	/// value that is not valid or the hClientHandle parameter is not valid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NDIS_DOT11_POWER_STATE_INVALID</term>
	/// <term>The radio associated with the interface is turned off. There are no available networks when the radio is off.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Not enough memory is available to process this request and allocate memory for the query results.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanGetAvailableNetworkList</c> function allocates memory for the list of available networks returned in the buffer
	/// pointed to by the ppAvailableNetworkList parameter when the function succeeds. The memory used for the buffer pointed to by
	/// ppAvailableNetworkList parameter should be released by calling the WlanFreeMemory function after the buffer is no longer needed.
	/// </para>
	/// <para>
	/// There is a hotfix available for Wireless LAN API for Windows XP with SP2 that can help improve the performance of applications
	/// that call WlanFreeMemory and <c>WlanGetAvailableNetworkList</c> many times. For more information, see Help and Knowledge Base
	/// article 940541, entitled "FIX: The private bytes of the application continuously increase when an application calls the
	/// WlanGetAvailableNetworkList function and the WlanFreeMemory function on a Windows XP Service Pack 2-based computer", in the Help
	/// and Support Knowledge Base at https://go.microsoft.com/fwlink/p/?linkid=102216.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example enumerates the wireless LAN interfaces on the local computer, retrieves the list of available networks on
	/// each wireless LAN interface, and prints values from the retrieved WLAN_AVAILABLE_NETWORK_LIST that contains the
	/// WLAN_AVAILABLE_NETWORK entries.
	/// </para>
	/// <para>
	/// <c>Note</c> This example will fail to load on Windows Server 2008 and Windows Server 2008 R2 if the Wireless LAN Service is not
	/// installed and started.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlangetavailablenetworklist DWORD
	// WlanGetAvailableNetworkList( HANDLE hClientHandle, const GUID *pInterfaceGuid, DWORD dwFlags, PVOID pReserved,
	// PWLAN_AVAILABLE_NETWORK_LIST *ppAvailableNetworkList );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "27353a1b-2a3c-4c3b-b512-917d010ee8dd")]
	public static extern Win32Error WlanGetAvailableNetworkList(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, uint dwFlags, [Optional] IntPtr pReserved,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(WlanMarshaler<WLAN_AVAILABLE_NETWORK_LIST>))] out WLAN_AVAILABLE_NETWORK_LIST ppAvailableNetworkList);

	/// <summary>The <c>WlanGetFilterList</c> function retrieves a group policy or user permission list.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="wlanFilterListType">
	/// A WLAN_FILTER_LIST_TYPE value that specifies the type of filter list. All user defined and group policy filter lists can be queried.
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <param name="ppNetworkList">Pointer to a DOT11_NETWORK_LIST structure that contains the list of permitted or denied networks.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have sufficient permissions to get the filter list. When called with wlanFilterListType set to
	/// wlan_filter_list_type_user_permit, WlanGetFilterList retrieves the discretionary access control list (DACL) stored with the
	/// wlan_secure_permit_list object. When called with wlanFilterListType set to wlan_filter_list_type_user_deny, WlanGetFilterList
	/// retrieves the DACL stored with the wlan_secure_deny_list object. In either of these cases, if the DACL does not contain an
	/// access control entry (ACE) that grants WLAN_READ_ACCESS permission to the access token of the calling thread, then
	/// WlanGetFilterList returns ERROR_ACCESS_DENIED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>hClientHandle is NULL or invalid, ppNetworkList is NULL, or pReserved is not NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// This function was called from an unsupported platform. This value will be returned if this function was called from a Windows XP
	/// with SP3 or Wireless LAN API for Windows XP with SP2 client.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>User permission lists can be set by calling WlanSetFilterList.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlangetfilterlist DWORD WlanGetFilterList( HANDLE
	// hClientHandle, WLAN_FILTER_LIST_TYPE wlanFilterListType, PVOID pReserved, PDOT11_NETWORK_LIST *ppNetworkList );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "3ea88e52-34bb-47a6-b345-c789d1d8047d")]
	public static extern Win32Error WlanGetFilterList(HWLANSESSION hClientHandle, WLAN_FILTER_LIST_TYPE wlanFilterListType, [Optional] IntPtr pReserved,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(WlanMarshaler<DOT11_NETWORK_LIST>))] out DOT11_NETWORK_LIST ppNetworkList);

	/// <summary>The <c>WlanGetInterfaceCapability</c> function retrieves the capabilities of an interface.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">The GUID of this interface.</param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <param name="ppCapability">
	/// A WLAN_INTERFACE_CAPABILITY structure that contains information about the capabilities of the specified interface.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>hClientHandle is NULL or invalid, pInterfaceGuid is NULL, pReserved is not NULL, or ppCapability is NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// This function was called from an unsupported platform. This value will be returned if this function was called from a Windows XP
	/// with SP3 or Wireless LAN API for Windows XP with SP2 client.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>The caller is responsible for calling the WlanFreeMemory function to free the memory allocated to ppCapability.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlangetinterfacecapability DWORD
	// WlanGetInterfaceCapability( HANDLE hClientHandle, const GUID *pInterfaceGuid, PVOID pReserved, PWLAN_INTERFACE_CAPABILITY
	// *ppCapability );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "09f8273a-5259-44fa-b55e-af3282735c0b")]
	public static extern Win32Error WlanGetInterfaceCapability(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, [Optional] IntPtr pReserved,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(WlanMarshaler<WLAN_INTERFACE_CAPABILITY>))] out WLAN_INTERFACE_CAPABILITY ppCapability);

	/// <summary>
	/// The <c>WlanGetNetworkBssList</c> function retrieves a list of the basic service set (BSS) entries of the wireless network or
	/// networks on a given wireless LAN interface.
	/// </summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">
	/// <para>A pointer to the GUID of the wireless LAN interface to be queried.</para>
	/// <para>The GUID of each wireless LAN interface enabled on a local computer can be determined using the WlanEnumInterfaces function.</para>
	/// </param>
	/// <param name="pDot11Ssid">
	/// <para>
	/// A pointer to a DOT11_SSID structure that specifies the SSID of the network from which the BSS list is requested. This parameter
	/// is optional. When set to <c>NULL</c>, the returned list contains all of available BSS entries on a wireless LAN interface.
	/// </para>
	/// <para>
	/// If a pointer to a DOT11_SSID structure is specified, the SSID length specified in the <c>uSSIDLength</c> member of
	/// <c>DOT11_SSID</c> structure must be less than or equal to <c>DOT11_SSID_MAX_LENGTH</c> defined in the Wlantypes.h header file.
	/// In addition, the dot11BssType parameter must be set to either <c>dot11_BSS_type_infrastructure</c> or
	/// <c>dot11_BSS_type_independent</c> and the bSecurityEnabled parameter must be specified.
	/// </para>
	/// </param>
	/// <param name="dot11BssType">
	/// <para>
	/// The BSS type of the network. This parameter is ignored if the SSID of the network for the BSS list is unspecified (the
	/// pDot11Ssid parameter is <c>NULL</c>).
	/// </para>
	/// <para>
	/// This parameter can be one of the following values defined in the DOT11_BSS_TYPE enumeration defined in the Wlantypes.h header file.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>dot11_BSS_type_infrastructure</term>
	/// <term>An infrastructure BSS network.</term>
	/// </item>
	/// <item>
	/// <term>dot11_BSS_type_independent</term>
	/// <term>An independent BSS (IBSS) network (an ad hoc network).</term>
	/// </item>
	/// <item>
	/// <term>dot11_BSS_type_any</term>
	/// <term>Any BSS network.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bSecurityEnabled">
	/// A value that indicates whether security is enabled on the network. This parameter is only valid when the SSID of the network for
	/// the BSS list is specified (the pDot11Ssid parameter is not <c>NULL</c>).
	/// </param>
	/// <param name="pReserved">Reserved for future use. This parameter must be set to <c>NULL</c>.</param>
	/// <param name="ppWlanBssList">
	/// <para>A pointer to storage for a pointer to receive the returned list of of BSS entries in a WLAN_BSS_LIST structure.</para>
	/// <para>The buffer for the WLAN_BSS_LIST returned is allocated by the <c>WlanGetNetworkBssList</c> function if the call succeeds.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// A parameter is incorrect. This error is returned if the hClientHandle, pInterfaceGuid, or ppWlanBssList parameter is NULL. This
	/// error is returned if the pReserved is not NULL. This error is also returned if the hClientHandle, the SSID specified in the
	/// pDot11Ssid parameter, or the BSS type specified in the dot11BssType parameter is not valid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NDIS_DOT11_POWER_STATE_INVALID</term>
	/// <term>The radio associated with the interface is turned off. The BSS list is not available when the radio is off.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Not enough memory is available to process this request and allocate memory for the query results.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>
	/// The element was not found. This error is returned if the GUID of the interface to be queried that was specified in the
	/// pInterfaceGuid parameter could not be found.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// The request is not supported. This error is returned if this function was called from a Windows XP with SP3 or Wireless LAN API
	/// for Windows XP with SP2 client. This error is also returned if the WLAN AutoConfig service is disabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The WLAN AutoConfig service has not been started.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanGetNetworkBssList</c> function retrieves the basic service set list for each wireless network or networks accessible
	/// on a given interface. The list of information returned for each wireless network also contains a list of information elements
	/// returned by each access point for an infrastructure BSS network or a network peer for an independent BSS network (ad hoc
	/// network). The information is returned as a pointer to an WLAN_BSS_LIST structure in the ppWlanBssList parameter. The
	/// <c>WLAN_BSS_LIST</c> structure contains an item count followed by an array of WLAN_BSS_ENTRY structure entries.
	/// </para>
	/// <para>
	/// Since the information returned by the <c>WlanGetNetworkBssList</c> function is sent by an access point for an infrastructure BSS
	/// network or by a network peer for an independent BSS network (ad hoc network), the information returned should not be trusted.
	/// The <c>ulIeOffset</c> and <c>ulIeSize</c> members in the WLAN_BSS_ENTRY structure should be used to determine the size of the
	/// information element data blob in the <c>WLAN_BSS_ENTRY</c> structure, not the data in the information element data blob itself.
	/// The <c>WlanGetNetworkBssList</c> function does not validate that any information returned in the information element data blob
	/// pointed to by the <c>ulIeOffset</c> member is a valid information element as defined by the IEEE 802.11 standards for wireless LANs.
	/// </para>
	/// <para>
	/// If the pDot11Ssid parameter is specified (not <c>NULL</c>), then the dot11BssType parameter specified must be set to either
	/// <c>dot11_BSS_type_infrastructure</c> for an infrastructure BSS network or <c>dot11_BSS_type_independent</c> for an independent
	/// BSS network (ad hoc network). If the dot11BssType parameter is set to <c>dot11_BSS_type_any</c>, then the
	/// <c>WlanGetNetworkBssList</c> function returns ERROR_SUCCESS but no BSS entries will be returned.
	/// </para>
	/// <para>
	/// To return a list of all the infrastructure BSS networks and independent BSS networks (ad hoc networks) on a wireless LAN
	/// interface, set the pDot11Ssid parameter to <c>NULL</c>. When the wireless LAN interface is also operating as a Wireless Hosted
	/// Network , the BSS list will contain an entry for the BSS created for the Wireless Hosted Network.
	/// </para>
	/// <para>
	/// The <c>WlanGetNetworkBssList</c> function returns ERROR_SUCCESS when an empty BSS list is returned by the WLAN AutoConfig
	/// Service. An application that calls the <c>WlanGetNetworkBssList</c> function must check that the <c>dwNumberOfItems</c> member
	/// of the WLAN_BSS_LIST pointed to by the ppWlanBssList parameter is not zero before accessing the <c>wlanBssEntries[0]</c> member
	/// in <c>WLAN_BSS_LIST</c> structure.
	/// </para>
	/// <para>
	/// The <c>WlanGetNetworkBssList</c> function allocates memory for the basic service set list that is returned in a buffer pointed
	/// to by the ppWlanBssList parameter when the function succeeds. The memory used for the buffer pointed to by ppWlanBssList
	/// parameter should be released by calling the WlanFreeMemory function after the buffer is no longer needed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlangetnetworkbsslist DWORD WlanGetNetworkBssList( HANDLE
	// hClientHandle, const GUID *pInterfaceGuid, const PDOT11_SSID pDot11Ssid, DOT11_BSS_TYPE dot11BssType, BOOL bSecurityEnabled,
	// PVOID pReserved, PWLAN_BSS_LIST *ppWlanBssList );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "62f51b6e-3db1-48cd-8853-0dbe522c5e82")]
	public static extern Win32Error WlanGetNetworkBssList(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, in DOT11_SSID pDot11Ssid,
		DOT11_BSS_TYPE dot11BssType, [MarshalAs(UnmanagedType.Bool)] bool bSecurityEnabled, [Optional] IntPtr pReserved,
		out SafeHWLANMEM ppWlanBssList);

	/// <summary>
	/// The <c>WlanGetNetworkBssList</c> function retrieves a list of the basic service set (BSS) entries of the wireless network or
	/// networks on a given wireless LAN interface.
	/// </summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">
	/// <para>A pointer to the GUID of the wireless LAN interface to be queried.</para>
	/// <para>The GUID of each wireless LAN interface enabled on a local computer can be determined using the WlanEnumInterfaces function.</para>
	/// </param>
	/// <param name="pDot11Ssid">
	/// <para>
	/// A pointer to a DOT11_SSID structure that specifies the SSID of the network from which the BSS list is requested. This parameter
	/// is optional. When set to <c>NULL</c>, the returned list contains all of available BSS entries on a wireless LAN interface.
	/// </para>
	/// <para>
	/// If a pointer to a DOT11_SSID structure is specified, the SSID length specified in the <c>uSSIDLength</c> member of
	/// <c>DOT11_SSID</c> structure must be less than or equal to <c>DOT11_SSID_MAX_LENGTH</c> defined in the Wlantypes.h header file.
	/// In addition, the dot11BssType parameter must be set to either <c>dot11_BSS_type_infrastructure</c> or
	/// <c>dot11_BSS_type_independent</c> and the bSecurityEnabled parameter must be specified.
	/// </para>
	/// </param>
	/// <param name="dot11BssType">
	/// <para>
	/// The BSS type of the network. This parameter is ignored if the SSID of the network for the BSS list is unspecified (the
	/// pDot11Ssid parameter is <c>NULL</c>).
	/// </para>
	/// <para>
	/// This parameter can be one of the following values defined in the DOT11_BSS_TYPE enumeration defined in the Wlantypes.h header file.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>dot11_BSS_type_infrastructure</term>
	/// <term>An infrastructure BSS network.</term>
	/// </item>
	/// <item>
	/// <term>dot11_BSS_type_independent</term>
	/// <term>An independent BSS (IBSS) network (an ad hoc network).</term>
	/// </item>
	/// <item>
	/// <term>dot11_BSS_type_any</term>
	/// <term>Any BSS network.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bSecurityEnabled">
	/// A value that indicates whether security is enabled on the network. This parameter is only valid when the SSID of the network for
	/// the BSS list is specified (the pDot11Ssid parameter is not <c>NULL</c>).
	/// </param>
	/// <param name="pReserved">Reserved for future use. This parameter must be set to <c>NULL</c>.</param>
	/// <param name="ppWlanBssList">
	/// <para>A pointer to storage for a pointer to receive the returned list of of BSS entries in a WLAN_BSS_LIST structure.</para>
	/// <para>The buffer for the WLAN_BSS_LIST returned is allocated by the <c>WlanGetNetworkBssList</c> function if the call succeeds.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// A parameter is incorrect. This error is returned if the hClientHandle, pInterfaceGuid, or ppWlanBssList parameter is NULL. This
	/// error is returned if the pReserved is not NULL. This error is also returned if the hClientHandle, the SSID specified in the
	/// pDot11Ssid parameter, or the BSS type specified in the dot11BssType parameter is not valid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NDIS_DOT11_POWER_STATE_INVALID</term>
	/// <term>The radio associated with the interface is turned off. The BSS list is not available when the radio is off.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Not enough memory is available to process this request and allocate memory for the query results.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>
	/// The element was not found. This error is returned if the GUID of the interface to be queried that was specified in the
	/// pInterfaceGuid parameter could not be found.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// The request is not supported. This error is returned if this function was called from a Windows XP with SP3 or Wireless LAN API
	/// for Windows XP with SP2 client. This error is also returned if the WLAN AutoConfig service is disabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The WLAN AutoConfig service has not been started.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanGetNetworkBssList</c> function retrieves the basic service set list for each wireless network or networks accessible
	/// on a given interface. The list of information returned for each wireless network also contains a list of information elements
	/// returned by each access point for an infrastructure BSS network or a network peer for an independent BSS network (ad hoc
	/// network). The information is returned as a pointer to an WLAN_BSS_LIST structure in the ppWlanBssList parameter. The
	/// <c>WLAN_BSS_LIST</c> structure contains an item count followed by an array of WLAN_BSS_ENTRY structure entries.
	/// </para>
	/// <para>
	/// Since the information returned by the <c>WlanGetNetworkBssList</c> function is sent by an access point for an infrastructure BSS
	/// network or by a network peer for an independent BSS network (ad hoc network), the information returned should not be trusted.
	/// The <c>ulIeOffset</c> and <c>ulIeSize</c> members in the WLAN_BSS_ENTRY structure should be used to determine the size of the
	/// information element data blob in the <c>WLAN_BSS_ENTRY</c> structure, not the data in the information element data blob itself.
	/// The <c>WlanGetNetworkBssList</c> function does not validate that any information returned in the information element data blob
	/// pointed to by the <c>ulIeOffset</c> member is a valid information element as defined by the IEEE 802.11 standards for wireless LANs.
	/// </para>
	/// <para>
	/// If the pDot11Ssid parameter is specified (not <c>NULL</c>), then the dot11BssType parameter specified must be set to either
	/// <c>dot11_BSS_type_infrastructure</c> for an infrastructure BSS network or <c>dot11_BSS_type_independent</c> for an independent
	/// BSS network (ad hoc network). If the dot11BssType parameter is set to <c>dot11_BSS_type_any</c>, then the
	/// <c>WlanGetNetworkBssList</c> function returns ERROR_SUCCESS but no BSS entries will be returned.
	/// </para>
	/// <para>
	/// To return a list of all the infrastructure BSS networks and independent BSS networks (ad hoc networks) on a wireless LAN
	/// interface, set the pDot11Ssid parameter to <c>NULL</c>. When the wireless LAN interface is also operating as a Wireless Hosted
	/// Network , the BSS list will contain an entry for the BSS created for the Wireless Hosted Network.
	/// </para>
	/// <para>
	/// The <c>WlanGetNetworkBssList</c> function returns ERROR_SUCCESS when an empty BSS list is returned by the WLAN AutoConfig
	/// Service. An application that calls the <c>WlanGetNetworkBssList</c> function must check that the <c>dwNumberOfItems</c> member
	/// of the WLAN_BSS_LIST pointed to by the ppWlanBssList parameter is not zero before accessing the <c>wlanBssEntries[0]</c> member
	/// in <c>WLAN_BSS_LIST</c> structure.
	/// </para>
	/// <para>
	/// The <c>WlanGetNetworkBssList</c> function allocates memory for the basic service set list that is returned in a buffer pointed
	/// to by the ppWlanBssList parameter when the function succeeds. The memory used for the buffer pointed to by ppWlanBssList
	/// parameter should be released by calling the WlanFreeMemory function after the buffer is no longer needed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlangetnetworkbsslist DWORD WlanGetNetworkBssList( HANDLE
	// hClientHandle, const GUID *pInterfaceGuid, const PDOT11_SSID pDot11Ssid, DOT11_BSS_TYPE dot11BssType, BOOL bSecurityEnabled,
	// PVOID pReserved, PWLAN_BSS_LIST *ppWlanBssList );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "62f51b6e-3db1-48cd-8853-0dbe522c5e82")]
	public static extern Win32Error WlanGetNetworkBssList(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, [Optional] IntPtr pDot11Ssid,
		DOT11_BSS_TYPE dot11BssType, [MarshalAs(UnmanagedType.Bool)] bool bSecurityEnabled, [Optional] IntPtr pReserved,
		out SafeHWLANMEM ppWlanBssList);

	/// <summary>The <c>WlanGetProfile</c> function retrieves all information about a specified wireless profile.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">
	/// <para>The GUID of the wireless interface.</para>
	/// <para>A list of the GUIDs for wireless interfaces on the local computer can be retrieved using the WlanEnumInterfaces function.</para>
	/// </param>
	/// <param name="strProfileName">
	/// <para>
	/// The name of the profile. Profile names are case-sensitive. This string must be NULL-terminated. The maximum length of the
	/// profile name is 255 characters. This means that the maximum length of this string, including the NULL terminator, is 256 characters.
	/// </para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> The name of the profile is derived automatically from
	/// the SSID of the network. For infrastructure network profiles, the name of the profile is the SSID of the network. For ad hoc
	/// network profiles, the name of the profile is the SSID of the ad hoc network followed by .
	/// </para>
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <param name="pstrProfileXml">
	/// A string that is the XML representation of the queried profile. There is no predefined maximum string length.
	/// </param>
	/// <param name="pdwFlags">
	/// <para>
	/// On input, a pointer to the address location used to provide additional information about the request. If this parameter is
	/// <c>NULL</c> on input, then no information on profile flags will be returned. On output, a pointer to the address location used
	/// to receive profile flags.
	/// </para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> Per-user profiles are not supported. Set this parameter
	/// to <c>NULL</c>.
	/// </para>
	/// <para>The pdwFlags parameter can point to an address location that contains the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WLAN_PROFILE_GET_PLAINTEXT_KEY</term>
	/// <term>
	/// On input, this flag indicates that the caller wants to retrieve the plain text key from a wireless profile. If the calling
	/// thread has the required permissions, the WlanGetProfile function returns the plain text key in the keyMaterial element of the
	/// profile returned in the buffer pointed to by the pstrProfileXml parameter. For the WlanGetProfile call to return the plain text
	/// key, the wlan_secure_get_plaintext_key permissions from the WLAN_SECURABLE_OBJECT enumerated type must be set on the calling
	/// thread. The DACL must also contain an ACE that grants WLAN_READ_ACCESS permission to the access token of the calling thread. By
	/// default, the permissions for retrieving the plain text key is allowed only to the members of the Administrators group on a local
	/// machine. If the calling thread lacks the required permissions, the WlanGetProfile function returns the encrypted key in the
	/// keyMaterial element of the profile returned in the buffer pointed to by the pstrProfileXml parameter. No error is returned if
	/// the calling thread lacks the required permissions. Windows 7: This flag passed on input is an extension to native wireless APIs
	/// added on Windows 7 and later. The pdwFlags parameter is an __inout_opt parameter on Windows 7 and later.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WLAN_PROFILE_GROUP_POLICY</term>
	/// <term>
	/// On output when the WlanGetProfile call is successful, this flag indicates that this profile was created by group policy. A group
	/// policy profile is read-only. Neither the content nor the preference order of the profile can be changed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WLAN_PROFILE_USER</term>
	/// <term>
	/// On output when the WlanGetProfile call is successful, this flag indicates that the profile is a user profile for the specific
	/// user in whose context the calling thread resides. If not set, this profile is an all-user profile.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pdwGrantedAccess">
	/// <para>The access mask of the all-user profile.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WLAN_READ_ACCESS</term>
	/// <term>The user can view the contents of the profile.</term>
	/// </item>
	/// <item>
	/// <term>WLAN_EXECUTE_ACCESS</term>
	/// <term>
	/// The user has read access, and the user can also connect to and disconnect from a network using the profile. If a user has
	/// WLAN_EXECUTE_ACCESS, then the user also has WLAN_READ_ACCESS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WLAN_WRITE_ACCESS</term>
	/// <term>
	/// The user has execute access and the user can also modify the content of the profile or delete the profile. If a user has
	/// WLAN_WRITE_ACCESS, then the user also has WLAN_EXECUTE_ACCESS and WLAN_READ_ACCESS.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have sufficient permissions. This error is returned if the pstrProfileXml parameter specifies an all-user
	/// profile, but the caller does not have read access on the profile.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// A handle is invalid. This error is returned if the handle specified in the hClientHandle parameter was not found in the handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// Not enough storage is available to process this command. This error is returned if the system was unable to allocate memory for
	/// the profile.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>The profile specified by strProfileName was not found.</term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>Various RPC and other error codes. Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the <c>WlanGetProfile</c> function succeeds, the wireless profile is returned in the buffer pointed to by the pstrProfileXml
	/// parameter. The buffer contains a string that is the XML representation of the queried profile. For a description of the XML
	/// representation of the wireless profile, see WLAN_profile Schema.
	/// </para>
	/// <para>
	/// The caller is responsible for calling the WlanFreeMemory function to free the memory allocated for the buffer pointer to by the
	/// pstrProfileXml parameter when the buffer is no longer needed.
	/// </para>
	/// <para>
	/// If pstrProfileXml specifies an all-user profile, the <c>WlanGetProfile</c> caller must have read access on the profile.
	/// Otherwise, the <c>WlanGetProfile</c> call will fail with a return value of <c>ERROR_ACCESS_DENIED</c>. The permissions on an
	/// all-user profile are established when the profile is created or saved using WlanSetProfile or WlanSaveTemporaryProfile.
	/// </para>
	/// <para><c>Windows 7:</c></para>
	/// <para>
	/// The keyMaterial element returned in the profile schema pointed to by the pstrProfileXml may be requested as plaintext if the
	/// <c>WlanGetProfile</c> function is called with the <c>WLAN_PROFILE_GET_PLAINTEXT_KEY</c> flag set in the value pointed to by the
	/// pdwFlags parameter on input.
	/// </para>
	/// <para>
	/// For a WEP key, both 5 ASCII characters or 10 hexadecimal characters can be used to set the plaintext key when the profile is
	/// created or updated. However, a WEP profile will be saved with 10 hexadecimal characters in the key no matter what the original
	/// input was used to create the profile. So in the profile returned by the <c>WlanGetProfile</c> function, the plaintext WEP key is
	/// always returned as 10 hexadecimal characters.
	/// </para>
	/// <para>
	/// For the <c>WlanGetProfile</c> call to return the plain text key, the <c>wlan_secure_get_plaintext_key</c> permissions from the
	/// WLAN_SECURABLE_OBJECT enumerated type must be set on the calling thread. The DACL must also contain an ACE that grants
	/// <c>WLAN_READ_ACCESS</c> permission to the access token of the calling thread. By default, the permissions for retrieving the
	/// plain text key is allowed only to the members of the Administrators group on a local machine.
	/// </para>
	/// <para>
	/// If the calling thread lacks the required permissions, the <c>WlanGetProfile</c> function returns the encrypted key in the
	/// keyMaterial element of the profile returned in the buffer pointed to by the pstrProfileXml parameter. No error is returned if
	/// the calling thread lacks the required permissions.
	/// </para>
	/// <para>
	/// By default, the keyMaterial element returned in the profile pointed to by the pstrProfileXml is encrypted. If your process runs
	/// in the context of the LocalSystem account on the same computer, then you can unencrypt key material by calling the
	/// CryptUnprotectData function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2008 and Windows Vista:</c> The keyMaterial element returned in the profile schema pointed to by the
	/// pstrProfileXml is always encrypted. If your process runs in the context of the LocalSystem account, then you can unencrypt key
	/// material by calling the CryptUnprotectData function.
	/// </para>
	/// <para><c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> The key material is never encrypted.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example enumerates the wireless LAN interfaces on the local computer, retrieves information for a specific
	/// wireless profile on each wireless LAN interface, and prints the values retrieved. The string that is the XML representation of
	/// the queried profile is also printed.
	/// </para>
	/// <para>
	/// <c>Note</c> This example will fail to load on Windows Server 2008 and Windows Server 2008 R2 if the Wireless LAN Service is not
	/// installed and started.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlangetprofile DWORD WlanGetProfile( HANDLE hClientHandle,
	// const GUID *pInterfaceGuid, LPCWSTR strProfileName, PVOID pReserved, StrPtrUni *pstrProfileXml, DWORD *pdwFlags, DWORD
	// *pdwGrantedAccess );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "6486e961-402f-45c8-a806-ab91a4f0f156")]
	public static extern Win32Error WlanGetProfile(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, [MarshalAs(UnmanagedType.LPWStr)] string strProfileName,
		[Optional] IntPtr pReserved, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(WlanMarshaler<string>))] out string pstrProfileXml,
		ref WLAN_PROFILE_FLAGS pdwFlags, out WLAN_ACCCESS pdwGrantedAccess);

	/// <summary>The <c>WlanGetProfileCustomUserData</c> function gets the custom user data associated with a wireless profile.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">A pointer to the GUID of the wireless LAN interface.</param>
	/// <param name="strProfileName">
	/// The name of the profile with which the custom user data is associated. Profile names are case-sensitive. This string must be NULL-terminated.
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <param name="pdwDataSize">The size, in bytes, of the user data buffer pointed to by the ppDataparameter.</param>
	/// <param name="ppData">A pointer to the user data.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The system cannot find the file specified. This error is returned if no user custom data exists for the profile specified.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// The hClientHandle parameter is NULL or not valid, the pInterfaceGuid parameter is NULL, the strProfileName parameter is NULL,
	/// the pReserved parameter is not NULL, the pdwDataSize parameter is 0, or the ppData parameter is NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The system cannot find the file specified. This error is returned if no custom user data exists for the profile specified.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// This function was called from an unsupported platform. This value will be returned if this function was called from a Windows XP
	/// with SP3 or Wireless LAN API for Windows XP with SP2 client.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For every wireless WLAN profile used by the Native Wifi AutoConfig service, Windows maintains the concept of custom user data.
	/// This custom user data is initially non-existent, but can be set by calling the WlanSetProfileCustomUserData function. The custom
	/// user data gets reset to empty any time the profile is modified by calling the WlanSetProfile function.
	/// </para>
	/// <para>Once custom user data has been set, this data can be accessed using the <c>WlanGetProfileCustomUserData</c> function.</para>
	/// <para>
	/// The caller is responsible for freeing the memory allocated for the buffer pointed to by the ppData parameter using the
	/// WlanFreeMemory function.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example enumerates the wireless LAN interfaces on the local computer, and then tries to retrieve any custom user
	/// data information for a specific wireless profile on each wireless LAN interface. The size of the user custom data is printed.
	/// </para>
	/// <para>
	/// <c>Note</c> This example will fail to load on Windows Server 2008 and Windows Server 2008 R2 if the Wireless LAN Service is not
	/// installed and started.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlangetprofilecustomuserdata DWORD
	// WlanGetProfileCustomUserData( HANDLE hClientHandle, const GUID *pInterfaceGuid, LPCWSTR strProfileName, PVOID pReserved, DWORD
	// *pdwDataSize, PBYTE *ppData );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "5973be2f-8267-496b-827b-778f705accdc")]
	public static extern Win32Error WlanGetProfileCustomUserData(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, [MarshalAs(UnmanagedType.LPWStr)] string strProfileName,
		[Optional] IntPtr pReserved, out uint pdwDataSize, out SafeHWLANMEM ppData);

	/// <summary>The <c>WlanGetProfileList</c> function retrieves the list of profiles in preference order.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">
	/// <para>The GUID of the wireless interface.</para>
	/// <para>A list of the GUIDs for wireless interfaces on the local computer can be retrieved using the WlanEnumInterfaces function.</para>
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <param name="ppProfileList">A PWLAN_PROFILE_INFO_LIST structure that contains the list of profile information.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Not enough memory is available to process this request and allocate memory for the query results.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanGetProfileList</c> function returns only the basic information on the wireless profiles on a wireless interface. The
	/// list of wireless profiles on a wireless interface are retrieved in the preference order. The WlanSetProfilePosition can be used
	/// to change the preference order for the wireless profiles on a wireless interface.
	/// </para>
	/// <para>
	/// More detailed information for a wireless profile on a wireless interface can be retrieved by using the WlanGetProfile function.
	/// The WlanGetProfileCustomUserData function can be used to retrieve custom user data for a wireless profile on a wireless
	/// interface. A list of the wireless interfaces and associated GUIDs on the local computer can be retrieved using the
	/// WlanEnumInterfaces function.
	/// </para>
	/// <para>
	/// The <c>WlanGetProfileList</c> function allocates memory for the list of profiles returned in the buffer pointed to by the
	/// ppProfileList parameter. The caller is responsible for freeing this memory using the WlanFreeMemory function when this buffer is
	/// no longer needed.
	/// </para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> Guest profiles, profiles with Wireless Provisioning
	/// Service (WPS) authentication, and profiles with Wi-Fi Protected Access-None (WPA-None) authentication are not supported. These
	/// types of profiles are not returned by <c>WlanGetProfileList</c>, even if a profile of this type appears on the preferred profile list.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example enumerates the wireless LAN interfaces on the local computer, retrieves the list of profiles on each
	/// wireless LAN interface, and prints values from the retrieved WLAN_PROFILE_INFO_LIST that contains the WLAN_PROFILE_INFO entries.
	/// </para>
	/// <para>
	/// <c>Note</c> This example will fail to load on Windows Server 2008 and Windows Server 2008 R2 if the Wireless LAN Service is not
	/// installed and started.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlangetprofilelist DWORD WlanGetProfileList( HANDLE
	// hClientHandle, const GUID *pInterfaceGuid, PVOID pReserved, PWLAN_PROFILE_INFO_LIST *ppProfileList );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "f4336113-538f-4161-a71f-64a432e31f1c")]
	public static extern Win32Error WlanGetProfileList(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, [Optional] IntPtr pReserved,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(WlanMarshaler<WLAN_PROFILE_INFO_LIST>))] out WLAN_PROFILE_INFO_LIST ppProfileList);

	/// <summary>The <c>WlanGetSecuritySettings</c> function gets the security settings associated with a configurable object.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="SecurableObject">A WLAN_SECURABLE_OBJECT value that specifies the object to which the security settings apply.</param>
	/// <param name="pValueType">
	/// <para>A pointer to a WLAN_OPCODE_VALUE_TYPE value that specifies the source of the security settings.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>wlan_opcode_value_type_set_by_group_policy</term>
	/// <term>The security settings were set by group policy.</term>
	/// </item>
	/// <item>
	/// <term>wlan_opcode_value_type_set_by_user</term>
	/// <term>The security settings were set by the user. A user can set security settings by calling WlanSetSecuritySettings.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pstrCurrentSDDL">
	/// <para>On input, this parameter must be <c>NULL</c>.</para>
	/// <para>
	/// On output, this parameter receives a pointer to the security descriptor string that specifies the security settings for the
	/// object if the function call succeeds. For more information about this string, see WlanSetSecuritySettings function.
	/// </para>
	/// </param>
	/// <param name="pdwGrantedAccess">
	/// <para>The access mask of the object.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WLAN_READ_ACCESS</term>
	/// <term>The caller can view the object's permissions.</term>
	/// </item>
	/// <item>
	/// <term>WLAN_EXECUTE_ACCESS</term>
	/// <term>
	/// The caller can read from and execute the object. WLAN_EXECUTE_ACCESS has the same value as the bitwise OR combination
	/// WLAN_READ_ACCESS | WLAN_EXECUTE_ACCESS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WLAN_WRITE_ACCESS</term>
	/// <term>
	/// The caller can read from, execute, and write to the object. WLAN_WRITE_ACCESS has the same value as the bitwise OR combination
	/// WLAN_READ_ACCESS | WLAN_EXECUTE_ACCESS | WLAN_WRITE_ACCESS.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// A handle is invalid. This error is returned if the handle specified in the hClientHandle parameter was not found in the handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have sufficient permissions.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// This function was called from an unsupported platform. This value will be returned if this function was called from a Windows XP
	/// with SP3 or Wireless LAN API for Windows XP with SP2 client.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The caller is responsible for freeing the memory allocated to the security descriptor string pointed to by the pstrCurrentSDDL
	/// parameter if the function succeeds. When no longer needed, the memory for the security descriptor string should be freed by
	/// calling WlanFreeMemory function and passing in the pstrCurrentSDDL parameter.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlangetsecuritysettings DWORD WlanGetSecuritySettings(
	// HANDLE hClientHandle, WLAN_SECURABLE_OBJECT SecurableObject, PWLAN_OPCODE_VALUE_TYPE pValueType, StrPtrUni *pstrCurrentSDDL, PDWORD
	// pdwGrantedAccess );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "5e14a70c-c049-4cd1-8675-2b01ed11463f")]
	public static extern Win32Error WlanGetSecuritySettings(HWLANSESSION hClientHandle, WLAN_SECURABLE_OBJECT SecurableObject, out WLAN_OPCODE_VALUE_TYPE pValueType,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(WlanMarshaler<string>))] out string pstrCurrentSDDL, out WLAN_ACCCESS pdwGrantedAccess);

	/// <summary>Retrieves a list of the supported device services on a given wireless LAN interface.</summary>
	/// <param name="hClientHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>The client's session handle, obtained by a previous call to the WlanOpenHandle function.</para>
	/// </param>
	/// <param name="pInterfaceGuid">
	/// <para>Type: <c>CONST GUID*</c></para>
	/// <para>
	/// A pointer to the <c>GUID</c> of the wireless LAN interface to be queried. You can determine the <c>GUID</c> of each wireless LAN
	/// interface enabled on a local computer by using the WlanEnumInterfaces function.
	/// </para>
	/// </param>
	/// <param name="ppDevSvcGuidList">
	/// <para>Type: <c>PWLAN_DEVICE_SERVICE_GUID_LIST*</c></para>
	/// <para>
	/// A pointer to storage for a pointer to receive the returned list of device service <c>GUID</c> s in a
	/// WLAN_DEVICE_SERVICE_GUID_LIST structure.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. If the function fails with <c>ERROR_ACCESS_DENIED</c>, then
	/// the caller doesn't have sufficient permissions to perform this operation. The caller needs to either have admin privilege, or
	/// needs to be a UMDF driver.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlangetsupporteddeviceservices DWORD
	// WlanGetSupportedDeviceServices( HANDLE hClientHandle, const GUID *pInterfaceGuid, PWLAN_DEVICE_SERVICE_GUID_LIST
	// *ppDevSvcGuidList );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h")]
	public static extern Win32Error WlanGetSupportedDeviceServices(HWLANSESSION hClientHandle, in Guid pInterfaceGuid,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(WlanMarshaler<WLAN_DEVICE_SERVICE_GUID_LIST>))] out WLAN_DEVICE_SERVICE_GUID_LIST ppDevSvcGuidList);

	/// <summary>
	/// The <c>WlanHostedNetworkForceStart</c> function transitions the wireless Hosted Network to the <c>wlan_hosted_network_active
	/// state</c> without associating the request with the application's calling handle.
	/// </summary>
	/// <param name="hClientHandle">The client's session handle, returned by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pFailReason">
	/// An optional pointer to a value that receives the failure reason if the call to the <c>WlanHostedNetworkForceStart</c> function
	/// fails. Possible values for the failure reason are from the WLAN_HOSTED_NETWORK_REASON enumeration type defined in the Wlanapi.h
	/// header file.
	/// </param>
	/// <param name="pvReserved">Reserved for future use. This parameter must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have sufficient permissions.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// A handle is invalid. This error is returned if the handle specified in the hClientHandle parameter was not found in the handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_STATE</term>
	/// <term>
	/// The resource is not in the correct state to perform the requested operation. This error is returned if the wireless Hosted
	/// Network is disabled by group policy on a domain.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started. This error is returned if the WLAN AutoConfig Service is not running.</term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>Various RPC and other error codes. Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanHostedNetworkForceStart</c> function is an extension to native wireless APIs added to support the wireless Hosted
	/// Network on Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// <para>
	/// A client application calls the <c>WlanHostedNetworkForceStart</c> function to force the start of the wireless Hosted Network by
	/// transitioning the wireless Hosted Network to the <c>wlan_hosted_network_active state</c> without associating the request with
	/// the application's calling handle. A successful call to the <c>WlanHostedNetworkForceStart</c> function should eventually be
	/// matched by a call to WlanHostedNetworkForceStop function. Any Hosted Network state change caused by this function would not be
	/// automatically undone if the calling application closes its calling handle (by calling WlanCloseHandle with the hClientHandle
	/// parameter) or if the process ends.
	/// </para>
	/// <para>
	/// The cost of calling the <c>WlanHostedNetworkForceStart</c> function over calling WlanHostedNetworkStartUsing is the associated
	/// privilege required. An application might call the <c>WlanHostedNetworkForceStart</c> function after ensuring that an elevated
	/// system user accepts the increased power requirements involved in running the wireless Hosted Network for extended durations.
	/// </para>
	/// <para>
	/// The <c>WlanHostedNetworkForceStart</c> function could fail if Hosted Network state is <c>wlan_hosted_network_unavailable</c> or
	/// the caller does not have sufficient privileges.
	/// </para>
	/// <para>
	/// This function to force the start of the Hosted Network can only be called if the user has the appropriate associated privilege.
	/// Permissions are stored in a discretionary access control list (DACL) associated with a WLAN_SECURABLE_OBJECT. To call the
	/// <c>WlanHostedNetworkForceStart</c>, the client access token of the caller must have elevated privileges exposed by the following
	/// enumeration in <c>WLAN_SECURABLE_OBJECT</c>:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>wlan_secure_hosted_network_elevated_access</c></term>
	/// </item>
	/// </list>
	/// <para>The ability to enable the wireless Hosted Network may also be restricted by group policy in a domain.</para>
	/// <para>
	/// On Windows 7 and later, the operating system installs a virtual device if a Hosted Network capable wireless adapter is present
	/// on the machine. This virtual device normally shows up in the “Network Connections Folder” as ‘Wireless Network Connection 2’
	/// with a Device Name of ‘Microsoft Virtual WiFi Miniport adapter’ if the computer has a single wireless network adapter. This
	/// virtual device is used exclusively for performing software access point (SoftAP) connections and is not present in the list
	/// returned by the WlanEnumInterfaces function. The lifetime of this virtual device is tied to the physical wireless adapter. If
	/// the physical wireless adapter is disabled, this virtual device will be removed as well. This feature is also available on
	/// Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanhostednetworkforcestart DWORD
	// WlanHostedNetworkForceStart( HANDLE hClientHandle, PWLAN_HOSTED_NETWORK_REASON pFailReason, PVOID pvReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "d3e3b44f-ff52-4062-b54d-a0e3f2cf7785")]
	public static extern Win32Error WlanHostedNetworkForceStart(HWLANSESSION hClientHandle, out WLAN_HOSTED_NETWORK_REASON pFailReason, IntPtr pvReserved = default);

	/// <summary>
	/// The <c>WlanHostedNetworkForceStop</c> function transitions the wireless Hosted Network to the <c>wlan_hosted_network_idle</c>
	/// without associating the request with the application's calling handle.
	/// </summary>
	/// <param name="hClientHandle">The client's session handle, returned by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pFailReason">
	/// An optional pointer to a value that receives the failure reason, if the call to the <c>WlanHostedNetworkForceStop</c> function
	/// fails. Possible values for the failure reason are from the WLAN_HOSTED_NETWORK_REASON enumeration type defined in the Wlanapi.h
	/// header file.
	/// </param>
	/// <param name="pvReserved">Reserved for future use. This parameter must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// A handle is invalid. This error is returned if the handle specified in the hClientHandle parameter was not found in the handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_STATE</term>
	/// <term>The resource is not in the correct state to perform the requested operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started. This error is returned if the WLAN AutoConfig Service is not running.</term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>Various RPC and other error codes. Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanHostedNetworkForceStop</c> function is an extension to native wireless APIs added to support the wireless Hosted
	/// Network on Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// <para>
	/// A client application calls the <c>WlanHostedNetworkForceStop</c> function to force the stop the Hosted Network and transition
	/// the wireless Hosted Network to the <c>wlan_hosted_network_idle</c> without associating the request with the application's
	/// calling handle. A client typically calls the <c>WlanHostedNetworkForceStop</c> function to match an earlier successful call to
	/// the WlanHostedNetworkForceStart function.
	/// </para>
	/// <para>The <c>WlanHostedNetworkForceStop</c> function could fail if Hosted Network state is not <c>wlan_hosted_network_active</c>.</para>
	/// <para>
	/// Any Hosted Network state change caused by this function would not be automatically undone if the calling application closes its
	/// calling handle (by calling WlanCloseHandle with the hClientHandle parameter) or if the process ends.
	/// </para>
	/// <para>
	/// An application might call the <c>WlanHostedNetworkForceStop</c> function to stop the Hosted Network after a previous call to the
	/// WlanHostedNetworkForceStart by an elevated system user that accepted the increased power requirements involved in running the
	/// wireless Hosted Network for extended durations.
	/// </para>
	/// <para>
	/// Any user can call the <c>WlanHostedNetworkForceStop</c> function to force the stop of the Hosted Network. However, the ability
	/// to enable the wireless Hosted Network may be restricted by group policy in a domain.
	/// </para>
	/// <para>
	/// On Windows 7 and later, the operating system installs a virtual device if a Hosted Network capable wireless adapter is present
	/// on the machine. This virtual device normally shows up in the “Network Connections Folder” as ‘Wireless Network Connection 2’
	/// with a Device Name of ‘Microsoft Virtual WiFi Miniport adapter’ if the computer has a single wireless network adapter. This
	/// virtual device is used exclusively for performing software access point (SoftAP) connections and is not present in the list
	/// returned by the WlanEnumInterfaces function. The lifetime of this virtual device is tied to the physical wireless adapter. If
	/// the physical wireless adapter is disabled, this virtual device will be removed as well. This feature is also available on
	/// Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanhostednetworkforcestop DWORD
	// WlanHostedNetworkForceStop( HANDLE hClientHandle, PWLAN_HOSTED_NETWORK_REASON pFailReason, PVOID pvReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "abcfc33d-0310-46d2-a543-5c9529c2b851")]
	public static extern Win32Error WlanHostedNetworkForceStop(HWLANSESSION hClientHandle, out WLAN_HOSTED_NETWORK_REASON pFailReason, IntPtr pvReserved = default);

	/// <summary>
	/// The <c>WlanHostedNetworkInitSettings</c> function configures and persists to storage the network connection settings (SSID and
	/// maximum number of peers, for example) on the wireless Hosted Network if these settings are not already configured.
	/// </summary>
	/// <param name="hClientHandle">The client's session handle, returned by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pFailReason">
	/// An optional pointer to a value that receives the failure reason if the call to the <c>WlanHostedNetworkInitSettings</c> function
	/// fails. Possible values for the failure reason are from the WLAN_HOSTED_NETWORK_REASON enumeration type defined in the Wlanapi.h
	/// header file.
	/// </param>
	/// <param name="pvReserved">Reserved for future use. This parameter must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// A handle is invalid. This error is returned if the handle specified in the hClientHandle parameter was not found in the handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_STATE</term>
	/// <term>The resource is not in the correct state to perform the requested operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started. This error is returned if the WLAN AutoConfig Service is not running.</term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>Various RPC and other error codes. Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanHostedNetworkInitSettings</c> function is an extension to native wireless APIs added to support the wireless Hosted
	/// Network on Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// <para>
	/// A client application calls the <c>WlanHostedNetworkInitSettings</c> function to configure and persist to storage the network
	/// connection settings (SSID and maximum number of peers, for example) on the wireless Hosted Network, if the connections settings
	/// are not already configured. If the network settings on the wireless Hosted Network settings are already configured (the
	/// WlanHostedNetworkQueryProperty function does not return <c>ERROR_BAD_CONFIGURATION</c> for the station profile or connection
	/// settings), then this function call returns <c>ERROR_SUCCESS</c> without changing the configuration of the network connection settings.
	/// </para>
	/// <para>
	/// A client application should always call the <c>WlanHostedNetworkInitSettings</c> function before using other Hosted Network
	/// features on the local computer. This function initializes settings that are required when the wireless Hosted Network is used
	/// for the first time on a local computer. The <c>WlanHostedNetworkInitSettings</c> function does not change any configuration if
	/// the configuration has already been persisted. So it is safe to call the <c>WlanHostedNetworkInitSettings</c> function if the
	/// configuration has already been persisted. It is recommended that applications that use Hosted Network call the
	/// <c>WlanHostedNetworkInitSettings</c> function before using other Hosted Network functions.
	/// </para>
	/// <para>
	/// The <c>WlanHostedNetworkInitSettings</c> function computes a random and readable SSID from the host name and computes a random
	/// primary key. This function also uses sets a value for the maximum number of peers allowed that defaults to 100. If an
	/// application wants to use a different SSID or a different maximum number of peers, then the application should call the
	/// WlanHostedNetworkSetProperty function to specifically set these properties used by the wireless Hosted Network.
	/// </para>
	/// <para>
	/// Any Hosted Network state change caused by this function would not be automatically undone if the calling application closes its
	/// calling handle (by calling WlanCloseHandle with the hClientHandle parameter) or if the process ends.
	/// </para>
	/// <para>
	/// Any user can call the <c>WlanHostedNetworkInitSettings</c> function to configure and persist to storage network connection
	/// settings on the Hosted Network. If the wireless Hosted Network has already been configured, this function does nothing and
	/// returns <c>ERROR_SUCCESS</c>.
	/// </para>
	/// <para>
	/// On Windows 7 and later, the operating system installs a virtual device if a Hosted Network capable wireless adapter is present
	/// on the machine. This virtual device normally shows up in the “Network Connections Folder” as ‘Wireless Network Connection 2’
	/// with a Device Name of ‘Microsoft Virtual WiFi Miniport adapter’ if the computer has a single wireless network adapter. This
	/// virtual device is used exclusively for performing software access point (SoftAP) connections and is not present in the list
	/// returned by the WlanEnumInterfaces function. The lifetime of this virtual device is tied to the physical wireless adapter. If
	/// the physical wireless adapter is disabled, this virtual device will be removed as well. This feature is also available on
	/// Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanhostednetworkinitsettings DWORD
	// WlanHostedNetworkInitSettings( HANDLE hClientHandle, PWLAN_HOSTED_NETWORK_REASON pFailReason, PVOID pvReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "aed4db5d-9740-43ee-bf09-7a4a5abae953")]
	public static extern Win32Error WlanHostedNetworkInitSettings(HWLANSESSION hClientHandle, out WLAN_HOSTED_NETWORK_REASON pFailReason, IntPtr pvReserved = default);

	/// <summary>
	/// The <c>WlanHostedNetworkQueryProperty</c> function queries the current static properties of the wireless Hosted Network.
	/// </summary>
	/// <param name="hClientHandle">The client's session handle, returned by a previous call to the WlanOpenHandle function.</param>
	/// <param name="OpCode">
	/// The identifier for property to be queried. This identifier can be any of the values in the WLAN_HOSTED_NETWORK_OPCODE
	/// enumeration defined in the Wlanapi.h header file.
	/// </param>
	/// <param name="pdwDataSize">
	/// A pointer to a value that specifies the size, in bytes, of the buffer returned in the ppvData parameter, if the call to the
	/// <c>WlanHostedNetworkQueryProperty</c> function succeeds.
	/// </param>
	/// <param name="ppvData">
	/// <para>On input, this parameter must be <c>NULL</c>.</para>
	/// <para>
	/// On output, this parameter receives a pointer to a buffer returned with the static property requested, if the call to the
	/// <c>WlanHostedNetworkQueryProperty</c> function succeeds. The data type associated with this buffer depends upon the value of
	/// OpCode parameter.
	/// </para>
	/// </param>
	/// <param name="pWlanOpcodeValueType">
	/// A pointer to a value that receives the value type of the wireless Hosted Network property, if the call to the
	/// <c>WlanHostedNetworkQueryProperty</c> function succeeds. The returned value is an enumerated type in the WLAN_OPCODE_VALUE_TYPE
	/// enumeration defined in the Wlanapi.h header file.
	/// </param>
	/// <param name="pvReserved">Reserved for future use. This parameter must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>
	/// The configuration data for the wireless Hosted Network is unconfigured. This error is returned if the application calls the
	/// WlanHostedNetworkQueryProperty function with the OpCode parameter set to wlan_hosted_network_opcode_station_profile or
	/// wlan_hosted_network_opcode_connection_settings before a SSID is configured in the wireless Hosted Network.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// A handle is invalid. This error is returned if the handle specified in the hClientHandle parameter was not found in the handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_STATE</term>
	/// <term>
	/// The resource is not in the correct state to perform the requested operation. This can occur if the wireless Hosted Network was
	/// in the process of shutting down.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_OUTOFMEMORY</term>
	/// <term>Not enough storage is available to complete this operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started. This error is returned if the WLAN AutoConfig Service is not running.</term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>Various RPC and other error codes. Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanHostedNetworkQueryProperty</c> function is an extension to native wireless APIs added to support the wireless Hosted
	/// Network on Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// <para>
	/// A client application calls the <c>WlanHostedNetworkQueryProperty</c> function to query the current static properties of the
	/// wireless Hosted Network. This function does not change the state or properties of the wireless Hosted Network.
	/// </para>
	/// <para>
	/// If the function succeeds, the ppvData parameter points to a buffer that contains the requested property. The size of this buffer
	/// is returned in a pointer returned in the pwdDataSizeparameter. The WLAN_OPCODE_VALUE_TYPE is returned in a pointer returned in
	/// the pWlanOpcodeValueType parameter. The memory used for the buffer in the ppvData parameter that is returned should be released
	/// by calling the WlanFreeMemory function after the buffer is no longer needed.
	/// </para>
	/// <para>
	/// The data type associated with the buffer pointed to by the ppvData parameter depends upon the value of OpCode parameter as follows:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>OpCode</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>wlan_hosted_network_opcode_connection_settings</term>
	/// <term>A pointer to a WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS structure is returned.</term>
	/// </item>
	/// <item>
	/// <term>wlan_hosted_network_opcode_security_settings</term>
	/// <term>A pointer to a WLAN_HOSTED_NETWORK_SECURITY_SETTINGS structure is returned.</term>
	/// </item>
	/// <item>
	/// <term>wlan_hosted_network_opcode_station_profile</term>
	/// <term>A StrPtrUni to contains an XML WLAN profile for connecting to the wireless Hosted Network is returned.</term>
	/// </item>
	/// <item>
	/// <term>wlan_hosted_network_opcode_enable</term>
	/// <term>A PBOOL that indicates if wireless Hosted Network is enabled is returned.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the <c>WlanHostedNetworkQueryProperty</c> function is passed any of the following values in the OpCode parameter before a
	/// SSID is configured in the wireless Hosted Network, the function will fail with <c>ERROR_BAD_CONFIGURATION</c>:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>wlan_hosted_network_opcode_station_profile</term>
	/// </item>
	/// <item>
	/// <term>wlan_hosted_network_opcode_connection_settings</term>
	/// </item>
	/// </list>
	/// <para>Any user can call the <c>WlanHostedNetworkQueryProperty</c> function to query the Hosted Network properties.</para>
	/// <para>
	/// On Windows 7 and later, the operating system installs a virtual device if a Hosted Network capable wireless adapter is present
	/// on the machine. This virtual device normally shows up in the “Network Connections Folder” as ‘Wireless Network Connection 2’
	/// with a Device Name of ‘Microsoft Virtual WiFi Miniport adapter’ if the computer has a single wireless network adapter. This
	/// virtual device is used exclusively for performing software access point (SoftAP) connections and is not present in the list
	/// returned by the WlanEnumInterfaces function. The lifetime of this virtual device is tied to the physical wireless adapter. If
	/// the physical wireless adapter is disabled, this virtual device will be removed as well. This feature is also available on
	/// Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanhostednetworkqueryproperty DWORD
	// WlanHostedNetworkQueryProperty( HANDLE hClientHandle, WLAN_HOSTED_NETWORK_OPCODE OpCode, PDWORD pdwDataSize, PVOID *ppvData,
	// PWLAN_OPCODE_VALUE_TYPE pWlanOpcodeValueType, PVOID pvReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "bab05629-c921-4639-94db-25f77742dbd3")]
	public static extern Win32Error WlanHostedNetworkQueryProperty(HWLANSESSION hClientHandle, WLAN_HOSTED_NETWORK_OPCODE OpCode, out uint pdwDataSize,
		out SafeHWLANMEM ppvData, out WLAN_OPCODE_VALUE_TYPE pWlanOpcodeValueType, IntPtr pvReserved = default);

	/// <summary>
	/// The <c>WlanHostedNetworkQuerySecondaryKey</c> function queries the secondary security key that is configured to be used by the
	/// wireless Hosted Network.
	/// </summary>
	/// <param name="hClientHandle">The client's session handle, returned by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pdwKeyLength">
	/// <para>
	/// A pointer to a value that specifies number of valid data bytes in the key data array pointed to by the ppucKeyData parameter, if
	/// the call to the <c>WlanHostedNetworkQuerySecondaryKey</c> function succeeds.
	/// </para>
	/// <para>This key length includes the terminating ‘\0’ if the key is a passphrase.</para>
	/// </param>
	/// <param name="ppucKeyData">
	/// A pointer to a value that receives a pointer to the buffer returned with the secondary security key data, if the call to the
	/// <c>WlanHostedNetworkQuerySecondaryKey</c> function succeeds.
	/// </param>
	/// <param name="pbIsPassPhrase">
	/// <para>
	/// A pointer to a Boolean value that indicates if the key data array pointed to by the ppucKeyData parameter is in passphrase format.
	/// </para>
	/// <para>
	/// If this parameter is <c>TRUE</c>, the key data array is in passphrase format. If this parameter is <c>FALSE</c>, the key data
	/// array is not in passphrase format.
	/// </para>
	/// </param>
	/// <param name="pbPersistent">
	/// <para>
	/// A pointer to a Boolean value that indicates if the key data array pointed to by the ppucKeyData parameter is to be stored and
	/// reused later or is for one-time use only.
	/// </para>
	/// <para>
	/// If this parameter is <c>TRUE</c>, the key data array is to be stored and reused later. If this parameter is <c>FALSE</c>, the
	/// key data array is for one-time use only.
	/// </para>
	/// </param>
	/// <param name="pFailReason">
	/// An optional pointer to a value that receives the failure reason, if the call to the WlanHostedNetworkSetSecondaryKey function
	/// fails. Possible values for the failure reason are from the WLAN_HOSTED_NETWORK_REASON enumeration type defined in the Wlanapi.h
	/// header file.
	/// </param>
	/// <param name="pvReserved">Reserved for future use. This parameter must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// A handle is invalid. This error is returned if the handle specified in the hClientHandle parameter was not found in the handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_STATE</term>
	/// <term>
	/// The resource is not in the correct state to perform the requested operation. This can occur if the wireless Hosted Network was
	/// in the process of shutting down.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_OUTOFMEMORY</term>
	/// <term>Not enough storage is available to complete this operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started. This error is returned if the WLAN AutoConfig Service is not running.</term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>Various RPC and other error codes. Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanHostedNetworkQuerySecondaryKey</c> function is an extension to native wireless APIs added to support the wireless
	/// Hosted Network on Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// <para>
	/// A client application calls the <c>WlanHostedNetworkQuerySecondaryKey</c> function to query the secondary security key that will
	/// be used by the wireless Hosted Network. This function will return the key information including key data, key length, whether it
	/// is a passphrase, and whether it is persistent or for one-time use. This function does not change the state or properties of the
	/// wireless Hosted Network.
	/// </para>
	/// <para>
	/// The secondary security key is a passphrase if the value pointed to by the pbIsPassPhrase parameter is <c>TRUE</c>. The secondary
	/// security key is a binary key if the value pointed to by the pbIsPassPhrase parameter is <c>FALSE</c>.
	/// </para>
	/// <para>
	/// The secondary security key returned in the buffer pointed to by the ppucKeyData parameter is used with WPA2-Personal
	/// authentication and is in one of the following formats:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// A key passphrase that consists of an array of ASCII characters from 8 to 63 characters. The value pointed to by the pdwKeyLength
	/// parameter includes the terminating ‘\0’ in the passphrase. The value pointed to by the pdwKeyLength parameter should be in the
	/// range of 9 to 64.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// A binary key that conists of 32 bytes of binary key data. The value pointed to by the pdwKeyLength parameter should be 32 for
	/// binary key.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The secondary security key is persistent if the value pointed to by the pbPersistent parameter is <c>TRUE</c>. When persistent,
	/// the secondary security key would be used immediately if the Hosted Network is already started, and also reused whenever Hosted
	/// Network is started in the future.
	/// </para>
	/// <para>
	/// If secondary security key is not specified as persistent, it will be used immediately if the Hosted Network is already started,
	/// or only for the next time when the Hosted Network is started. After the Hosted Network is stopped, this secondary security key
	/// will never be used again and will be removed from the system.
	/// </para>
	/// <para>
	/// If there is no secondary security key currently configured, the returned value pointed to by the pdwKeyLength parameter will be
	/// zero, and the value returned in the ppucKeyData parameter will be <c>NULL</c>. In such case, the value returned in the
	/// pbIsPassPhrase and pbPersistent parameters will be meaningless.
	/// </para>
	/// <para>
	/// If the <c>WlanHostedNetworkQuerySecondaryKey</c> function succeeds, the memory used for the buffer in the ppucKeyData parameter
	/// that is returned should be freed after use by calling the WlanFreeMemory function.
	/// </para>
	/// <para>
	/// Any user can call the <c>WlanHostedNetworkQuerySecondaryKey</c> function to query the secondary security key used in the Hosted
	/// Network. However, the ability to enable the wireless Hosted Network may be restricted by group policy in a domain.
	/// </para>
	/// <para>
	/// On Windows 7 and later, the operating system installs a virtual device if a Hosted Network capable wireless adapter is present
	/// on the machine. This virtual device normally shows up in the “Network Connections Folder” as ‘Wireless Network Connection 2’
	/// with a Device Name of ‘Microsoft Virtual WiFi Miniport adapter’ if the computer has a single wireless network adapter. This
	/// virtual device is used exclusively for performing software access point (SoftAP) connections and is not present in the list
	/// returned by the WlanEnumInterfaces function. The lifetime of this virtual device is tied to the physical wireless adapter. If
	/// the physical wireless adapter is disabled, this virtual device will be removed as well. This feature is also available on
	/// Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanhostednetworkquerysecondarykey DWORD
	// WlanHostedNetworkQuerySecondaryKey( HANDLE hClientHandle, PDWORD pdwKeyLength, PUCHAR *ppucKeyData, PBOOL pbIsPassPhrase, PBOOL
	// pbPersistent, PWLAN_HOSTED_NETWORK_REASON pFailReason, PVOID pvReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "5989977a-7a2f-43b8-a958-058db01fd24f")]
	public static extern Win32Error WlanHostedNetworkQuerySecondaryKey(HWLANSESSION hClientHandle, out uint pdwKeyLength, out SafeHWLANMEM ppucKeyData,
		[MarshalAs(UnmanagedType.Bool)] out bool pbIsPassPhrase, [MarshalAs(UnmanagedType.Bool)] out bool pbPersistent, out WLAN_HOSTED_NETWORK_REASON pFailReason,
		IntPtr pvReserved = default);

	/// <summary>The <c>WlanHostedNetworkQueryStatus</c> function queries the current status of the wireless Hosted Network.</summary>
	/// <param name="hClientHandle">The client's session handle, returned by a previous call to the WlanOpenHandle function.</param>
	/// <param name="ppWlanHostedNetworkStatus">
	/// <para>On input, this parameter must be <c>NULL</c>.</para>
	/// <para>
	/// On output, this parameter receives a pointer to the current status of the wireless Hosted Network, if the call to the
	/// <c>WlanHostedNetworkQueryStatus</c> function succeeds. The current status is returned in a WLAN_HOSTED_NETWORK_STATUS structure.
	/// </para>
	/// </param>
	/// <param name="pvReserved">Reserved for future use. This parameter must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// A handle is invalid. This error is returned if the handle specified in the hClientHandle parameter was not found in the handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_STATE</term>
	/// <term>
	/// The resource is not in the correct state to perform the requested operation. This can occur if the wireless Hosted Network was
	/// in the process of shutting down.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started. This error is returned if the WLAN AutoConfig Service is not running.</term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>Various RPC and other error codes. Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanHostedNetworkQueryStatus</c> function is an extension to native wireless APIs added to support the wireless Hosted
	/// Network on Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// <para>
	/// A client application calls the <c>WlanHostedNetworkQueryStatus</c> function to query the current status of the wireless Hosted
	/// Network. This function does not change the state of the wireless Hosted Network.
	/// </para>
	/// <para>
	/// If the function succeeds, the ppWlanHostedNetworkStatus parameter points to a WLAN_HOSTED_NETWORK_STATUS structure with the
	/// current status. The memory used for the <c>WLAN_HOSTED_NETWORK_STATUS</c> structure that is returned should be freed after use
	/// by calling the WlanFreeMemory function.
	/// </para>
	/// <para>
	/// Any user can call the <c>WlanHostedNetworkQueryStatus</c> function to query the Hosted Network. However, the ability to enable
	/// the wireless Hosted Network may be restricted by group policy in a domain.
	/// </para>
	/// <para>
	/// On Windows 7 and later, the operating system installs a virtual device if a Hosted Network capable wireless adapter is present
	/// on the machine. This virtual device normally shows up in the “Network Connections Folder” as ‘Wireless Network Connection 2’
	/// with a Device Name of ‘Microsoft Virtual WiFi Miniport adapter’ if the computer has a single wireless network adapter. This
	/// virtual device is used exclusively for performing software access point (SoftAP) connections and is not present in the list
	/// returned by the WlanEnumInterfaces function. The lifetime of this virtual device is tied to the physical wireless adapter. If
	/// the physical wireless adapter is disabled, this virtual device will be removed as well. This feature is also available on
	/// Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanhostednetworkquerystatus DWORD
	// WlanHostedNetworkQueryStatus( HANDLE hClientHandle, PWLAN_HOSTED_NETWORK_STATUS *ppWlanHostedNetworkStatus, PVOID pvReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "896cff65-74ec-41d5-89e3-95fa85fd54cd")]
	public static extern Win32Error WlanHostedNetworkQueryStatus(HWLANSESSION hClientHandle,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(WlanMarshaler<WLAN_HOSTED_NETWORK_STATUS>))] out WLAN_HOSTED_NETWORK_STATUS ppWlanHostedNetworkStatus,
		IntPtr pvReserved = default);

	/// <summary>
	/// The <c>WlanHostedNetworkRefreshSecuritySettings</c> function refreshes the configurable and auto-generated parts of the wireless
	/// Hosted Network security settings.
	/// </summary>
	/// <param name="hClientHandle">The client's session handle, returned by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pFailReason">
	/// An optional pointer to a value that receives the failure reason, if the call to the
	/// <c>WlanHostedNetworkRefreshSecuritySettings</c> function fails. Possible values for the failure reason are from the
	/// WLAN_HOSTED_NETWORK_REASON enumeration type defined in the Wlanapi.h header file.
	/// </param>
	/// <param name="pvReserved">Reserved for future use. This parameter must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// A handle is invalid. This error is returned if the handle specified in the hClientHandle parameter was not found in the handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_STATE</term>
	/// <term>The resource is not in the correct state to perform the requested operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started. This error is returned if the WLAN AutoConfig Service is not running.</term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>Various RPC and other error codes. Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanHostedNetworkRefreshSecuritySettings</c> function is an extension to native wireless APIs added to support the
	/// wireless Hosted Network on Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// <para>
	/// A client application calls the <c>WlanHostedNetworkRefreshSecuritySettings</c> function to force a refresh of the configurable
	/// and auto-generated parts of the security settings (the primary key) on the wireless Hosted Network.
	/// </para>
	/// <para>
	/// An application might call the <c>WlanHostedNetworkRefreshSecuritySettings</c> function after ensuring that the user accepts the
	/// impact of updating the security settings. In order to succeed, this function must persist the new settings which would require
	/// that Hosted Network state be transitioned to wlan_hosted_network_idle if it was currently running (wlan_hosted_network_active).
	/// </para>
	/// <para>
	/// <c>Note</c> Any network clients (PCs or devices) on the wireless Hosted Network would have to be re-configured after calling the
	/// <c>WlanHostedNetworkRefreshSecuritySettings</c> function if their continued usage is a goal. An application would typically call
	/// this function in situations where the user feels that the security of the previous primary key used for security by the wireless
	/// Hosted Network has been violated. Note that the <c>WlanHostedNetworkRefreshSecuritySettings</c> function does not change or
	/// reset the secondary key.
	/// </para>
	/// <para>
	/// Any Hosted Network state change caused by this function would not be automatically undone if the calling application closes its
	/// calling handle (by calling WlanCloseHandle with the hClientHandle parameter) or if the process ends.
	/// </para>
	/// <para>
	/// Any user can call the <c>WlanHostedNetworkRefreshSecuritySettings</c> function to refresh the security settings on the Hosted
	/// Network. However, the ability to enable the wireless Hosted Network may be restricted by group policy in a domain.
	/// </para>
	/// <para>
	/// On Windows 7 and later, the operating system installs a virtual device if a Hosted Network capable wireless adapter is present
	/// on the machine. This virtual device normally shows up in the “Network Connections Folder” as ‘Wireless Network Connection 2’
	/// with a Device Name of ‘Microsoft Virtual WiFi Miniport adapter’ if the computer has a single wireless network adapter. This
	/// virtual device is used exclusively for performing software access point (SoftAP) connections and is not present in the list
	/// returned by the WlanEnumInterfaces function. The lifetime of this virtual device is tied to the physical wireless adapter. If
	/// the physical wireless adapter is disabled, this virtual device will be removed as well. This feature is also available on
	/// Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanhostednetworkrefreshsecuritysettings DWORD
	// WlanHostedNetworkRefreshSecuritySettings( HANDLE hClientHandle, PWLAN_HOSTED_NETWORK_REASON pFailReason, PVOID pvReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "9589e3a6-6e7a-4186-bfd0-a942a39ecafb")]
	public static extern Win32Error WlanHostedNetworkRefreshSecuritySettings(HWLANSESSION hClientHandle, out WLAN_HOSTED_NETWORK_REASON pFailReason, IntPtr pvReserved = default);

	/// <summary>The <c>WlanHostedNetworkSetProperty</c> function sets static properties of the wireless Hosted Network.</summary>
	/// <param name="hClientHandle">The client's session handle, returned by a previous call to the WlanOpenHandle function.</param>
	/// <param name="OpCode">
	/// <para>
	/// The identifier for the property to be set. This identifier can only be the following values in the WLAN_HOSTED_NETWORK_OPCODE
	/// enumeration defined in the Wlanapi.h header file:
	/// </para>
	/// <para>)</para>
	/// <para>)</para>
	/// </param>
	/// <param name="dwDataSize">A value that specifies the size, in bytes, of the buffer pointed to by the pvData parameter.</param>
	/// <param name="pvData">
	/// A pointer to a buffer with the static property to set. The data type associated with this buffer depends upon the value of
	/// OpCode parameter.
	/// </param>
	/// <param name="pFailReason">
	/// An optional pointer to a value that receives the failure reason, if the call to the <c>WlanHostedNetworkSetProperty</c> function
	/// fails. Possible values for the failure reason are from the WLAN_HOSTED_NETWORK_REASON enumeration type defined in the Wlanapi.h
	/// header file.
	/// </param>
	/// <param name="pvReserved">Reserved for future use. This parameter must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have sufficient permissions. This error is also returned if the OpCode parameter was
	/// wlan_hosted_network_opcode_enable and the wireless Hosted Network is disabled by group policy on a domain.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_PROFILE</term>
	/// <term>The network connection profile used by the wireless Hosted Network is corrupted.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// A handle is invalid. This error is returned if the handle specified in the hClientHandle parameter was not found in the handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_STATE</term>
	/// <term>
	/// The resource is not in the correct state to perform the requested operation. This can occur if the wireless Hosted Network was
	/// in the process of shutting down.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// The request is not supported. This error is returned if the application calls the WlanHostedNetworkSetProperty function with the
	/// OpCode parameter set to wlan_hosted_network_opcode_station_profile or wlan_hosted_network_opcode_security_settings.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started. This error is returned if the WLAN AutoConfig Service is not running.</term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>Various RPC and other error codes. Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanHostedNetworkSetProperty</c> function is an extension to native wireless APIs added to support the wireless Hosted
	/// Network on Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// <para>
	/// A client application calls the <c>WlanHostedNetworkSetProperty</c> function to set the current static properties of the wireless
	/// Hosted Network. Any Hosted Network property change caused by this function would not be automatically undone if the calling
	/// application closes its calling handle (by calling WlanCloseHandle with the hClientHandle parameter) or if the process ends.
	/// </para>
	/// <para>
	/// The data type associated with the buffer pointed to by the pvData parameter depends upon the value of OpCode parameter as follows:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>OpCode</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>wlan_hosted_network_opcode_connection_settings</term>
	/// <term>A pointer to a WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS structure is passed in the pvData parameter.</term>
	/// </item>
	/// <item>
	/// <term>wlan_hosted_network_opcode_enable</term>
	/// <term>A pointer to BOOL is passed in the pvData parameter.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the <c>WlanHostedNetworkSetProperty</c> function is called with the OpCode parameter set to
	/// <c>wlan_hosted_network_opcode_enable</c>, the user must have the appropriate associated privilege. Permissions are stored in a
	/// discretionary access control list (DACL) associated with a WLAN_SECURABLE_OBJECT. To call the
	/// <c>WlanHostedNetworkSetProperty</c> function with the OpCode parameter of <c>wlan_hosted_network_opcode_enable</c>, the client
	/// access token of the caller must have elevated privileges exposed by the following enumeration in <c>WLAN_SECURABLE_OBJECT</c>:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>wlan_secure_hosted_network_elevated_access</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// If the <c>WlanHostedNetworkSetProperty</c> function is passed any of the following values in the OpCode parameter, the function
	/// will fail with <c>ERROR_NOT_SUPPORTED</c>:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>wlan_hosted_network_opcode_station_profile</term>
	/// </item>
	/// <item>
	/// <term>wlan_hosted_network_opcode_connection_settings</term>
	/// </item>
	/// </list>
	/// <para>
	/// In order to succeed, the <c>WlanHostedNetworkSetProperty</c> function must persist the new settings which requires that the
	/// Hosted Network state be transitioned to <c>wlan_hosted_network_idle</c> if it was currently running (wlan_hosted_network_active).
	/// </para>
	/// <para>
	/// Any user can call this function to set the Hosted Network properties. However, to set the
	/// <c>wlan_hosted_network_opcode_enable</c> flag requires elevated privileges. The ability to enable the wireless Hosted Network
	/// may also be restricted by group policy in a domain.
	/// </para>
	/// <para>
	/// On Windows 7 and later, the operating system installs a virtual device if a Hosted Network capable wireless adapter is present
	/// on the machine. This virtual device normally shows up in the “Network Connections Folder” as ‘Wireless Network Connection 2’
	/// with a Device Name of ‘Microsoft Virtual WiFi Miniport adapter’ if the computer has a single wireless network adapter. This
	/// virtual device is used exclusively for performing software access point (SoftAP) connections and is not present in the list
	/// returned by the WlanEnumInterfaces function. The lifetime of this virtual device is tied to the physical wireless adapter. If
	/// the physical wireless adapter is disabled, this virtual device will be removed as well. This feature is also available on
	/// Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanhostednetworksetproperty DWORD
	// WlanHostedNetworkSetProperty( HANDLE hClientHandle, WLAN_HOSTED_NETWORK_OPCODE OpCode, DWORD dwDataSize, PVOID pvData,
	// PWLAN_HOSTED_NETWORK_REASON pFailReason, PVOID pvReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "88139383-f5d5-4e42-b41e-ea754a89356d")]
	public static extern Win32Error WlanHostedNetworkSetProperty(HWLANSESSION hClientHandle, WLAN_HOSTED_NETWORK_OPCODE OpCode, uint dwDataSize,
		[In] IntPtr pvData, out WLAN_HOSTED_NETWORK_REASON pFailReason, IntPtr pvReserved = default);

	/// <summary>
	/// The <c>WlanHostedNetworkSetSecondaryKey</c> function configures the secondary security key that will be used by the wireless
	/// Hosted Network.
	/// </summary>
	/// <param name="hClientHandle">The client's session handle, returned by a previous call to the WlanOpenHandle function.</param>
	/// <param name="dwKeyLength">
	/// The number of valid data bytes in the key data array pointed to by the pucKeyData parameter. This key length should include the
	/// terminating ‘\0’ if the key is a passphrase.
	/// </param>
	/// <param name="pucKeyData">
	/// A pointer to a buffer that contains the key data. The number of valid data bytes in the buffer must be at least the value
	/// specified in dwKeyLength parameter.
	/// </param>
	/// <param name="bIsPassPhrase">
	/// <para>A Boolean value that indicates if the key data array pointed to by the pucKeyData parameter is in passphrase format.</para>
	/// <para>
	/// If this parameter is <c>TRUE</c>, the key data array is in passphrase format. If this parameter is <c>FALSE</c>, the key data
	/// array is not in passphrase format.
	/// </para>
	/// </param>
	/// <param name="bPersistent">
	/// <para>
	/// A Boolean value that indicates if the key data array pointed to by the pucKeyData parameter is to be stored and reused later or
	/// is for one-time use only.
	/// </para>
	/// <para>
	/// If this parameter is <c>TRUE</c>, the key data array is to be stored and reused later. If this parameter is <c>FALSE</c>, the
	/// key data array is to be used for one session (either the current session or the next session if the Hosted Network is not started).
	/// </para>
	/// </param>
	/// <param name="pFailReason">
	/// An optional pointer to a value that receives the failure reason, if the call to the <c>WlanHostedNetworkSetSecondaryKey</c>
	/// function fails. Possible values for the failure reason are from the WLAN_HOSTED_NETWORK_REASON enumeration type defined in the
	/// Wlanapi.h header file.
	/// </param>
	/// <param name="pvReserved">Reserved for future use. This parameter must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// A handle is invalid. This error is returned if the handle specified in the hClientHandle parameter was not found in the handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_STATE</term>
	/// <term>
	/// The resource is not in the correct state to perform the requested operation. This can occur if the wireless Hosted Network was
	/// in the process of shutting down.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started. This error is returned if the WLAN AutoConfig Service is not running.</term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>Various RPC and other error codes. Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanHostedNetworkSetSecondaryKey</c> function is an extension to native wireless APIs added to support the wireless
	/// Hosted Network on Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// <para>
	/// A client application calls the <c>WlanHostedNetworkSetSecondaryKey</c> function to configure the secondary security key that
	/// will be used by the wireless Hosted Network. Any Hosted Network change caused by this function would not be automatically undone
	/// if the calling application closes its calling handle (by calling WlanCloseHandle with the hClientHandle parameter) or if the
	/// process ends.
	/// </para>
	/// <para>
	/// Once started, the wireless Hosted Network will allow wireless peers to associate with this secondary security key in addition to
	/// the primary security key. The secondary security key is always specified by the user as needed, while the primary security key
	/// is generated by the operating system with greater security strength.
	/// </para>
	/// <para>
	/// The secondary security key passed in the buffer pointed to by the pucKeyData parameter is used with WPA2-Personal authentication
	/// and should be in one of the following formats:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// A key passphrase that consists of an array of ASCII characters from 8 to 63 characters. The dwKeyLength parameter should include
	/// the terminating ‘\0’ in the passphrase. The value of the dwKeyLength parameter should be in the range of 9 to 64.
	/// </term>
	/// </item>
	/// <item>
	/// <term>A binary key that consists of 32 bytes of binary key data. The dwKeyLength parameter should be 32 for binary key.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To configure a valid secondary security key, the dwKeyLength parameter should be in the correct range and the pucKeyData
	/// parameter should point to a valid memory buffer containing the specified bytes of data. To remove the currently configured
	/// secondary security key from the system, the application should call the <c>WlanHostedNetworkSetSecondaryKey</c> function with
	/// zero in dwKeyLength parameter and <c>NULL</c> in the pucKeyData parameter.
	/// </para>
	/// <para>
	/// The <c>WlanHostedNetworkSetSecondaryKey</c> function will return <c>ERROR_INVALID_PARAMETER</c> if the pucKeyData parameter is
	/// <c>NULL</c>, but the dwKeyLength parameter is not zero. The <c>WlanHostedNetworkSetSecondaryKey</c> function will also return
	/// <c>ERROR_INVALID_PARAMETER</c> if the dwKeyLength parameter is zero, but pucKeyData parameter is not <c>NULL</c>.
	/// </para>
	/// <para>
	/// The secondary security key is usually set before the wireless Hosted Network is started. Then it will be used the next time when
	/// the Hosted Network is started.
	/// </para>
	/// <para>
	/// A secondary security key can also be set after the Hosted Network has been started. In this case, the secondary security key
	/// will be used immediately. Any clients using the previous secondary security key will remain connected, but they will be unable
	/// to reconnect if they get disconnected for any reason or if the wireless Hosted Network is restarted.
	/// </para>
	/// <para>
	/// The secondary security key can be specified as persistent if the bPersistent parameter is set to <c>TRUE</c>. When specified as
	/// persistent, the secondary security key would be used immediately if the Hosted Network is already started, and also reused
	/// whenever Hosted Network is started in the future.
	/// </para>
	/// <para>
	/// If secondary security key is not specified as persistent, it will be used immediately if the Hosted Network is already started,
	/// or only for the next time when Hosted Network is started. After the Hosted Network is stopped, this secondary security key will
	/// never be used again and will be removed from the system.
	/// </para>
	/// <para>
	/// Any user can call this function to configure the secondary security key to be used in the Hosted Network. However, the ability
	/// to enable the wireless Hosted Network may be restricted by group policy in a domain.
	/// </para>
	/// <para>
	/// On Windows 7 and later, the operating system installs a virtual device if a Hosted Network capable wireless adapter is present
	/// on the machine. This virtual device normally shows up in the “Network Connections Folder” as ‘Wireless Network Connection 2’
	/// with a Device Name of ‘Microsoft Virtual WiFi Miniport adapter’ if the computer has a single wireless network adapter. This
	/// virtual device is used exclusively for performing software access point (SoftAP) connections and is not present in the list
	/// returned by the WlanEnumInterfaces function. The lifetime of this virtual device is tied to the physical wireless adapter. If
	/// the physical wireless adapter is disabled, this virtual device will be removed as well. This feature is also available on
	/// Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanhostednetworksetsecondarykey DWORD
	// WlanHostedNetworkSetSecondaryKey( HANDLE hClientHandle, DWORD dwKeyLength, PUCHAR pucKeyData, BOOL bIsPassPhrase, BOOL
	// bPersistent, PWLAN_HOSTED_NETWORK_REASON pFailReason, PVOID pvReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "385148fd-b5cd-4221-be25-077f484e93e9")]
	public static extern Win32Error WlanHostedNetworkSetSecondaryKey(HWLANSESSION hClientHandle, uint dwKeyLength, [In] IntPtr pucKeyData,
		[MarshalAs(UnmanagedType.Bool)] bool bIsPassPhrase, [MarshalAs(UnmanagedType.Bool)] bool bPersistent, out WLAN_HOSTED_NETWORK_REASON pFailReason,
		IntPtr pvReserved = default);

	/// <summary>The <c>WlanHostedNetworkStartUsing</c> function starts the wireless Hosted Network.</summary>
	/// <param name="hClientHandle">The client's session handle, returned by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pFailReason">
	/// An optional pointer to a value that receives the failure reason, if the call to the <c>WlanHostedNetworkStartUsing</c> function
	/// fails. Possible values for the failure reason are from the WLAN_HOSTED_NETWORK_REASON enumeration type defined in the Wlanapi.h
	/// header file.
	/// </param>
	/// <param name="pvReserved">Reserved for future use. This parameter must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// A handle is invalid. This error is returned if the handle specified in the hClientHandle parameter was not found in the handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_STATE</term>
	/// <term>
	/// The resource is not in the correct state to perform the requested operation. This error is returned if the wireless Hosted
	/// Network is disabled by group policy on a domain.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started. This error is returned if the WLAN AutoConfig Service is not running.</term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>Various RPC and other error codes. Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanHostedNetworkStartUsing</c> function is an extension to native wireless APIs added to support the wireless Hosted
	/// Network on Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// <para>
	/// A client application calls the <c>WlanHostedNetworkStartUsing</c> function to start the wireless Hosted Network. Successful
	/// calls must be matched by calls to WlanHostedNetworkStopUsing function. This call could fail if Hosted Network state is <c>wlan_hosted_network_unavailable</c>.
	/// </para>
	/// <para>
	/// Any Hosted Network state change caused by this function would be automatically undone if the calling application closes its
	/// calling handle (by calling WlanCloseHandle with the hClientHandle parameter) or if the process ends.
	/// </para>
	/// <para>
	/// Any user can call the <c>WlanHostedNetworkStartUsing</c> function to start the Hosted Network. However, the ability to enable
	/// the wireless Hosted Network may be restricted by group policy in a domain.
	/// </para>
	/// <para>
	/// On Windows 7 and later, the operating system installs a virtual device if a Hosted Network capable wireless adapter is present
	/// on the machine. This virtual device normally shows up in the “Network Connections Folder” as ‘Wireless Network Connection 2’
	/// with a Device Name of ‘Microsoft Virtual WiFi Miniport adapter’ if the computer has a single wireless network adapter. This
	/// virtual device is used exclusively for performing software access point (SoftAP) connections and is not present in the list
	/// returned by the WlanEnumInterfaces function. The lifetime of this virtual device is tied to the physical wireless adapter. If
	/// the physical wireless adapter is disabled, this virtual device will be removed as well. This feature is also available on
	/// Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanhostednetworkstartusing DWORD
	// WlanHostedNetworkStartUsing( HANDLE hClientHandle, PWLAN_HOSTED_NETWORK_REASON pFailReason, PVOID pvReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "923ffc09-f378-442c-a891-34b0c0d04c41")]
	public static extern Win32Error WlanHostedNetworkStartUsing(HWLANSESSION hClientHandle, out WLAN_HOSTED_NETWORK_REASON pFailReason, IntPtr pvReserved = default);

	/// <summary>The <c>WlanHostedNetworkStopUsing</c> function stops the wireless Hosted Network.</summary>
	/// <param name="hClientHandle">The client's session handle, returned by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pFailReason">
	/// An optional pointer to a value that receives the failure reason if the call to the <c>WlanHostedNetworkStopUsing</c> function
	/// fails. Possible values for the failure reason are from the WLAN_HOSTED_NETWORK_REASON enumeration type defined in the Wlanapi.h
	/// header file.
	/// </param>
	/// <param name="pvReserved">Reserved for future use. This parameter must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// A handle is invalid. This error is returned if the handle specified in the hClientHandle parameter was not found in the handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_STATE</term>
	/// <term>
	/// The resource is not in the correct state to perform the requested operation. This can occur if the wireless Hosted Network was
	/// in the process of shutting down.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started. This error is returned if the WLAN AutoConfig Service is not running.</term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>Various RPC and other error codes. Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanHostedNetworkStopUsing</c> function is an extension to native wireless APIs added to support the wireless Hosted
	/// Network on Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// <para>
	/// An application calls the <c>WlanHostedNetworkStopUsing</c> function to stop the Hosted Network. A application calls the
	/// <c>WlanHostedNetworkStopUsing</c> function to match earlier successful calls to the WlanHostedNetworkStartUsing function. The
	/// wireless Hosted Network will remain active until all applications have called the <c>WlanHostedNetworkStopUsing</c> function or
	/// the WlanHostedNetworkForceStop function is called to force a stop. When the wireless Hosted Network has stopped, the state
	/// switches to <c>wlan_hosted_network_idle</c>. This call could also fail if the Hosted Network state changed because of external
	/// events (for example, if the miniport driver for the wireless interface card becomes unavailable).
	/// </para>
	/// <para>
	/// Any user can call this function to stop the Hosted Network. However, the ability to enable the wireless Hosted Network may be
	/// restricted by group policy in a domain.
	/// </para>
	/// <para>
	/// On Windows 7 and later, the operating system installs a virtual device if a Hosted Network capable wireless adapter is present
	/// on the machine. This virtual device normally shows up in the “Network Connections Folder” as ‘Wireless Network Connection 2’
	/// with a Device Name of ‘Microsoft Virtual WiFi Miniport adapter’ if the computer has a single wireless network adapter. This
	/// virtual device is used exclusively for performing software access point (SoftAP) connections and is not present in the list
	/// returned by the WlanEnumInterfaces function. The lifetime of this virtual device is tied to the physical wireless adapter. If
	/// the physical wireless adapter is disabled, this virtual device will be removed as well. This feature is also available on
	/// Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanhostednetworkstopusing DWORD
	// WlanHostedNetworkStopUsing( HANDLE hClientHandle, PWLAN_HOSTED_NETWORK_REASON pFailReason, PVOID pvReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "36b5ed93-33c4-4ade-a6d9-0d240854a5ef")]
	public static extern Win32Error WlanHostedNetworkStopUsing(HWLANSESSION hClientHandle, out WLAN_HOSTED_NETWORK_REASON pFailReason, IntPtr pvReserved = default);

	/// <summary>
	/// The <c>WlanIhvControl</c> function provides a mechanism for independent hardware vendor (IHV) control of WLAN drivers or services.
	/// </summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">The GUID of the interface.</param>
	/// <param name="Type">A WLAN_IHV_CONTROL_TYPE structure that specifies the type of software bypassed by the IHV control function.</param>
	/// <param name="dwInBufferSize">The size, in bytes, of the input buffer.</param>
	/// <param name="pInBuffer">A generic buffer for driver or service interface input.</param>
	/// <param name="dwOutBufferSize">The size, in bytes, of the output buffer.</param>
	/// <param name="pOutBuffer">A generic buffer for driver or service interface output.</param>
	/// <param name="pdwBytesReturned">The number of bytes returned.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have sufficient permissions to perform this operation. When called, WlanIhvControl retrieves the
	/// discretionary access control list (DACL) stored with the wlan_secure_ihv_control object. If the DACL does not contain an access
	/// control entry (ACE) that grants WLAN_WRITE_ACCESS permission to the access token of the calling thread, then WlanIhvControl
	/// returns ERROR_ACCESS_DENIED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>hClientHandle is NULL or invalid, pInterfaceGuid is NULL, or pdwBytesReturned is NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// This function was called from an unsupported platform. This value will be returned if this function was called from a Windows XP
	/// with SP3 or Wireless LAN API for Windows XP with SP2 client.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanihvcontrol DWORD WlanIhvControl( HANDLE hClientHandle,
	// const GUID *pInterfaceGuid, WLAN_IHV_CONTROL_TYPE Type, DWORD dwInBufferSize, PVOID pInBuffer, DWORD dwOutBufferSize, PVOID
	// pOutBuffer, PDWORD pdwBytesReturned );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "3fc32119-0f92-4939-8125-812f45584d45")]
	public static extern Win32Error WlanIhvControl(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, WLAN_IHV_CONTROL_TYPE Type, uint dwInBufferSize,
		[In] IntPtr pInBuffer, uint dwOutBufferSize, [In, Out] IntPtr pOutBuffer, out uint pdwBytesReturned);

	/// <summary>The <c>WlanOpenHandle</c> function opens a connection to the server.</summary>
	/// <param name="dwClientVersion">
	/// <para>The highest version of the WLAN API that the client supports.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>Client version for Windows XP with SP3 and Wireless LAN API for Windows XP with SP2.</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Client version for Windows Vista and Windows Server 2008</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>A handle for the client to use in this session. This handle is used by other functions throughout the session.</returns>
	/// <remarks>
	/// <para>
	/// The version number specified by dwClientVersion and pdwNegotiatedVersion is a composite version number made up of both major and
	/// minor versions. The major version is specified by the low-order word, and the minor version is specified by the high-order word.
	/// The macros and return the major and minor version numbers respectively. You can construct a version number using the macro .
	/// </para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c><c>WlanOpenHandle</c> will return an error message if
	/// the Wireless Zero Configuration (WZC) service has not been started or if the WZC service is not responsive.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanopenhandle DWORD WlanOpenHandle( DWORD dwClientVersion,
	// PVOID pReserved, PDWORD pdwNegotiatedVersion, PHANDLE phClientHandle );
	[PInvokeData("wlanapi.h", MSDNShortId = "27bfa0c1-4443-47a4-a374-326f553fa3bb")]
	public static SafeHWLANSESSION WlanOpenHandle(uint dwClientVersion = 2) =>
		WlanOpenHandle(dwClientVersion, default, out _, out var h).Succeeded ? h : new SafeHWLANSESSION(default);

	/// <summary>The <c>WlanOpenHandle</c> function opens a connection to the server.</summary>
	/// <param name="dwClientVersion">
	/// <para>The highest version of the WLAN API that the client supports.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>Client version for Windows XP with SP3 and Wireless LAN API for Windows XP with SP2.</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Client version for Windows Vista and Windows Server 2008</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <param name="pdwNegotiatedVersion">
	/// The version of the WLAN API that will be used in this session. This value is usually the highest version supported by both the
	/// client and server.
	/// </param>
	/// <param name="phClientHandle">
	/// A handle for the client to use in this session. This handle is used by other functions throughout the session.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>pdwNegotiatedVersion is NULL, phClientHandle is NULL, or pReserved is not NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Failed to allocate memory to create the client context.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_REMOTE_SESSION_LIMIT_EXCEEDED</term>
	/// <term>Too many handles have been issued by the server.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The version number specified by dwClientVersion and pdwNegotiatedVersion is a composite version number made up of both major and
	/// minor versions. The major version is specified by the low-order word, and the minor version is specified by the high-order word.
	/// The macros and return the major and minor version numbers respectively. You can construct a version number using the macro .
	/// </para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c><c>WlanOpenHandle</c> will return an error message if
	/// the Wireless Zero Configuration (WZC) service has not been started or if the WZC service is not responsive.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanopenhandle DWORD WlanOpenHandle( DWORD dwClientVersion,
	// PVOID pReserved, PDWORD pdwNegotiatedVersion, PHANDLE phClientHandle );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "27bfa0c1-4443-47a4-a374-326f553fa3bb")]
	public static extern Win32Error WlanOpenHandle(uint dwClientVersion, [Optional] IntPtr pReserved, out uint pdwNegotiatedVersion, out SafeHWLANSESSION phClientHandle);

	/// <summary>The <c>WlanQueryAutoConfigParameter</c> function queries for the parameters of the auto configuration service.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="OpCode">
	/// <para>A value that specifies the configuration parameter to be queried.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>wlan_autoconf_opcode_show_denied_networks</term>
	/// <term>
	/// When set, the ppData parameter will contain a BOOL value indicating whether user and group policy-denied networks will be
	/// included in the available networks list. If the function returns ERROR_SUCCESS and ppData points to TRUE, then user and group
	/// policy-denied networks will be included in the available networks list; if FALSE, user and group policy-denied networks will not
	/// be included in the available networks list.
	/// </term>
	/// </item>
	/// <item>
	/// <term>wlan_autoconf_opcode_power_setting</term>
	/// <term>When set, the ppData parameter will contain a WLAN_POWER_SETTING value specifying the power settings.</term>
	/// </item>
	/// <item>
	/// <term>wlan_autoconf_opcode_only_use_gp_profiles_for_allowed_networks</term>
	/// <term>
	/// When set, the ppData parameter will contain a BOOL value indicating whether profiles not created by group policy can be used to
	/// connect to an allowed network with a matching group policy profile. If the function returns ERROR_SUCCESS and ppData points to
	/// TRUE, then only profiles created by group policy can be used; if FALSE, any profile can be used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>wlan_autoconf_opcode_allow_explicit_creds</term>
	/// <term>
	/// When set, the ppData parameter will contain a BOOL value indicating whether the current wireless interface has shared user
	/// credentials allowed. If the function returns ERROR_SUCCESS and ppData points to TRUE, then the current wireless interface has
	/// shared user credentials allowed; if FALSE, the current wireless interface does not allow shared user credentials.
	/// </term>
	/// </item>
	/// <item>
	/// <term>wlan_autoconf_opcode_block_period</term>
	/// <term>
	/// When set, the ppData parameter will contain a DWORD value that indicates the blocked period setting for the current wireless
	/// interface. The blocked period is the amount of time, in seconds, for which automatic connection to a wireless network will not
	/// be attempted after a previous failure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>wlan_autoconf_opcode_allow_virtual_station_extensibility</term>
	/// <term>
	/// When set, the ppData parameter will contain a BOOL value indicating whether extensibility on a virtual station is allowed. By
	/// default, extensibility on a virtual station is allowed. The value for this opcode is persisted across restarts. If the function
	/// returns ERROR_SUCCESS and ppData points to TRUE, then extensibility on a virtual station is allowed; if FALSE, extensibility on
	/// a virtual station is not allowed.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <param name="pdwDataSize">Specifies the size of the ppData parameter, in bytes.</param>
	/// <param name="ppData">
	/// <para>Pointer to the memory that contains the queried value for the parameter specified in OpCode.</para>
	/// <para>
	/// <c>Note</c> If OpCode is set to <c>wlan_autoconf_opcode_show_denied_networks</c>, then the pointer referenced by ppData may
	/// point to an integer value. If the pointer referenced by ppData points to 0, then the integer value should be converted to the
	/// boolean value <c>FALSE</c>. If the pointer referenced by ppData points to a nonzero integer, then the integer value should be
	/// converted to the boolean value <c>TRUE</c>.
	/// </para>
	/// </param>
	/// <param name="pWlanOpcodeValueType">A WLAN_OPCODE_VALUE_TYPE value.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have sufficient permissions to get configuration parameters. When called with OpCode set to
	/// wlan_autoconf_opcode_show_denied_networks, WlanQueryAutoConfigParameter retrieves the discretionary access control list (DACL)
	/// stored with the wlan_secure_show_denied object. If the DACL does not contain an access control entry (ACE) that grants
	/// WLAN_READ_ACCESS permission to the access token of the calling thread, then WlanQueryAutoConfigParameter returns ERROR_ACCESS_DENIED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>hClientHandle is NULL or invalid, pReserved is not NULL, ppData is NULL, or pdwDataSize is NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// This function was called from an unsupported platform. This value will be returned if this function was called from a Windows XP
	/// with SP3 or Wireless LAN API for Windows XP with SP2 client.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The <c>WlanQueryAutoConfigParameter</c> function queries for the parameters used by Auto Configuration Module (ACM), the
	/// wireless configuration component supported on Windows Vista and later.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanqueryautoconfigparameter DWORD
	// WlanQueryAutoConfigParameter( HANDLE hClientHandle, WLAN_AUTOCONF_OPCODE OpCode, PVOID pReserved, PDWORD pdwDataSize, PVOID
	// *ppData, PWLAN_OPCODE_VALUE_TYPE pWlanOpcodeValueType );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "30fcfcf1-0784-4f20-b8c7-311227d0cfca")]
	public static extern Win32Error WlanQueryAutoConfigParameter(HWLANSESSION hClientHandle, WLAN_AUTOCONF_OPCODE OpCode, [Optional] IntPtr pReserved,
		out uint pdwDataSize, out SafeHWLANMEM ppData, out WLAN_OPCODE_VALUE_TYPE pWlanOpcodeValueType);

	/// <summary>The <c>WlanQueryInterface</c> function queries various parameters of a specified interface.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">The GUID of the interface to be queried.</param>
	/// <param name="OpCode">
	/// <para>
	/// A WLAN_INTF_OPCODE value that specifies the parameter to be queried. The following table lists the valid constants along with
	/// the data type of the parameter in ppData.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>WLAN_INTF_OPCODE value</term>
	/// <term>ppData data type</term>
	/// </listheader>
	/// <item>
	/// <term>wlan_intf_opcode_autoconf_enabled</term>
	/// <term>BOOL</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_background_scan_enabled</term>
	/// <term>BOOL</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_radio_state</term>
	/// <term>WLAN_RADIO_STATE</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_bss_type</term>
	/// <term>DOT11_BSS_TYPE</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_interface_state</term>
	/// <term>WLAN_INTERFACE_STATE</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_current_connection</term>
	/// <term>WLAN_CONNECTION_ATTRIBUTES</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_channel_number</term>
	/// <term>ULONG</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_supported_infrastructure_auth_cipher_pairs</term>
	/// <term>WLAN_AUTH_CIPHER_PAIR_LIST</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_supported_adhoc_auth_cipher_pairs</term>
	/// <term>WLAN_AUTH_CIPHER_PAIR_LIST</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_supported_country_or_region_string_list</term>
	/// <term>WLAN_COUNTRY_OR_REGION_STRING_LIST</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_media_streaming_mode</term>
	/// <term>BOOL</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_statistics</term>
	/// <term>WLAN_STATISTICS</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_rssi</term>
	/// <term>LONG</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_current_operation_mode</term>
	/// <term>ULONG</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_supported_safe_mode</term>
	/// <term>BOOL</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_certified_safe_mode</term>
	/// <term>BOOL</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> Only the <c>wlan_intf_opcode_autoconf_enabled</c>,
	/// <c>wlan_intf_opcode_bss_type</c>, <c>wlan_intf_opcode_interface_state</c>, and <c>wlan_intf_opcode_current_connection</c>
	/// constants are valid.
	/// </para>
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <param name="pdwDataSize">The size of the ppData parameter, in bytes.</param>
	/// <param name="ppData">
	/// <para>Pointer to the memory location that contains the queried value of the parameter specified by the OpCode parameter.</para>
	/// <para>
	/// <c>Note</c> If OpCode is set to <c>wlan_intf_opcode_autoconf_enabled</c>, <c>wlan_intf_opcode_background_scan_enabled</c>, or
	/// <c>wlan_intf_opcode_media_streaming_mode</c>, then the pointer referenced by ppData may point to an integer value. If the
	/// pointer referenced by ppData points to 0, then the integer value should be converted to the boolean value <c>FALSE</c>. If the
	/// pointer referenced by ppData points to a nonzero integer, then the integer value should be converted to the boolean value <c>TRUE</c>.
	/// </para>
	/// </param>
	/// <param name="pWlanOpcodeValueType">
	/// If passed a non- <c>NULL</c> value, points to a WLAN_OPCODE_VALUE_TYPE value that specifies the type of opcode returned. This
	/// parameter may be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>The caller is responsible for using WlanFreeMemory to free the memory allocated for ppData.</para>
	/// <para>
	/// When OpCode is set to <c>wlan_intf_opcode_current_operation_mode</c>, <c>WlanQueryInterface</c> queries the current operation
	/// mode of the wireless interface. For more information about operation modes, see Native 802.11 Operation Modes. Two operation
	/// modes are supported: <c>DOT11_OPERATION_MODE_EXTENSIBLE_STATION</c> and <c>DOT11_OPERATION_MODE_NETWORK_MONITOR</c>. The
	/// operation mode constants are defined in the header file Windot11.h. ppData will point to one of these two values.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example enumerates the wireless LAN interfaces on the local computer, queries each interface for the
	/// WLAN_CONNECTION_ATTRIBUTES on the interface, and prints values from the retrieved <c>WLAN_CONNECTION_ATTRIBUTES</c> structure.
	/// </para>
	/// <para>For another example using the <c>WlanQueryInterface</c> function, see the WLAN_RADIO_STATE structure.</para>
	/// <para>
	/// <c>Note</c> This example will fail to load on Windows Server 2008 and Windows Server 2008 R2 if the Wireless LAN Service is not
	/// installed and started.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanqueryinterface DWORD WlanQueryInterface( HANDLE
	// hClientHandle, const GUID *pInterfaceGuid, WLAN_INTF_OPCODE OpCode, PVOID pReserved, PDWORD pdwDataSize, PVOID *ppData,
	// PWLAN_OPCODE_VALUE_TYPE pWlanOpcodeValueType );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "e20eb9a3-5824-48ee-b13e-b0252bbf495e")]
	public static extern Win32Error WlanQueryInterface(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, WLAN_INTF_OPCODE OpCode, [Optional] IntPtr pReserved,
		out uint pdwDataSize, out SafeHWLANMEM ppData, out WLAN_OPCODE_VALUE_TYPE pWlanOpcodeValueType);

	/// <summary>The <c>WlanReasonCodeToString</c> function retrieves a string that describes a specified reason code.</summary>
	/// <param name="dwReasonCode">A WLAN_REASON_CODE value of which the string description is requested.</param>
	/// <param name="dwBufferSize">
	/// The size of the buffer used to store the string, in <c>WCHAR</c>. If the reason code string is longer than the buffer, it will
	/// be truncated and NULL-terminated. If dwBufferSize is larger than the actual amount of memory allocated to pStringBuffer, then an
	/// access violation will occur in the calling program.
	/// </param>
	/// <param name="pStringBuffer">
	/// Pointer to a buffer that will receive the string. The caller must allocate memory to pStringBuffer before calling <c>WlanReasonCodeToString</c>.
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a pointer to a constant string.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>Various RPC and other error codes. Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanreasoncodetostring DWORD WlanReasonCodeToString( DWORD
	// dwReasonCode, DWORD dwBufferSize, PWCHAR pStringBuffer, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "2a02e2d2-91d0-4b54-ad02-a76442edcff8")]
	public static extern Win32Error WlanReasonCodeToString(WLAN_REASON_CODE dwReasonCode, uint dwBufferSize, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pStringBuffer,
		IntPtr pReserved = default);

	/// <summary>
	/// Allows user mode clients with admin privileges, or User-Mode Driver Framework (UMDF) drivers, to register for unsolicited
	/// notifications corresponding to device services that they're interested in.
	/// </summary>
	/// <param name="hClientHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>The client's session handle, obtained by a previous call to the WlanOpenHandle function.</para>
	/// </param>
	/// <param name="pDevSvcGuidList">
	/// <para>Type: <c>CONST PWLAN_DEVICE_SERVICE_GUID_LIST</c></para>
	/// <para>
	/// An optional pointer to a constant WLAN_DEVICE_SERVICE_GUID_LIST structure representing the device service <c>GUID</c> s for
	/// which you're interested in receiving notifications. The dwIndex member of the structure must have a value less than the value of
	/// its dwNumberOfItems member; otherwise, an access violation may occur. Every time you call this API, the previous device services
	/// list is replaced by the new one.
	/// </para>
	/// <para>
	/// To unregister, set pDevSvcGuidList to , or pass a pointer to a <c>WLAN_DEVICE_SERVICE_GUID_LIST</c> structure that has the
	/// member set to 0.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. If the function fails with <c>ERROR_ACCESS_DENIED</c>, then
	/// the caller doesn't have sufficient permissions to perform this operation. The caller needs to either have admin privilege, or
	/// needs to be a UMDF driver.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanRegisterDeviceServiceNotification</c> function is an extension to existing native Wi-Fi APIs for WLAN device services.
	/// </para>
	/// <para>
	/// A client application calls this function to register and unregister notifications for device services that it is interested in.
	/// </para>
	/// <para>
	/// Any registration to receive notifications for device services caused by this function would be automatically undone if the
	/// calling application closes its calling handle (by calling WlanCloseHandle with the hClientHandle parameter), or if the process ends.
	/// </para>
	/// <para>
	/// In order to receive these notifications, a client needs to call this function with a valid pDevSvcGuidList parameter, and must
	/// also call the WlanRegisterNotification function with a dwNotifSource argument of <c>WLAN_NOTIFICATION_SOURCE_DEVICE_SERVICE</c>
	/// (which is defined in ). The registration to receive notifications for device services is in effect until the application closes
	/// the client handle (by calling WlanCloseHandle with the hClientHandle parameter), or the process ends, or
	/// <c>WlanRegisterDeviceServiceNotification</c> is called with a pDevSvcGuidList argument of , or else has dwNumberOfItems set to 0.
	/// </para>
	/// <para>
	/// When the operating system (OS) receives a device service notification from an independent hardware vendor (IHV) driver, and a
	/// client has registered for these notifications using <c>WlanRegisterDeviceServiceNotification</c>, the client will receive them
	/// via the WLAN_NOTIFICATION_CALLBACK that it had registered through its call to WlanRegisterNotification. This callback will be
	/// called for every notification that the client has received (with a separate buffer for every notification).
	/// </para>
	/// <para>
	/// The NotificationSource member of the WLAN_NOTIFICATION_DATA structure received by the callback function (that is, the data
	/// member) will be set to <c>WLAN_NOTIFICATION_SOURCE_DEVICE_SERVICE</c>. The data blob, the device service <c>GUID</c>, and the
	/// opcode associated with this notification will be present in the pData member of the <c>WLAN_NOTIFICATION_DATA</c>, which will
	/// point to a structure of type WLAN_DEVICE_SERVICE_NOTIFICATION_DATA.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanregisterdeviceservicenotification DWORD
	// WlanRegisterDeviceServiceNotification( HANDLE hClientHandle, const PWLAN_DEVICE_SERVICE_GUID_LIST pDevSvcGuidList );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h")]
	public static extern Win32Error WlanRegisterDeviceServiceNotification(HWLANSESSION hClientHandle, [In, Optional] WLAN_DEVICE_SERVICE_GUID_LIST? pDevSvcGuidList);

	/// <summary>The <c>WlanRegisterNotification</c> function is used to register and unregister notifications on all wireless interfaces.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="dwNotifSource">
	/// <para>
	/// The notification sources to be registered. These flags may be combined. When this parameter is set to
	/// <c>WLAN_NOTIFICATION_SOURCE_NONE</c>, <c>WlanRegisterNotification</c> unregisters notifications on all wireless interfaces.
	/// </para>
	/// <para>The possible values for this parameter are defined in the Wlanapi.h and L2cmn.h header files.</para>
	/// <para>The following table shows possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WLAN_NOTIFICATION_SOURCE_NONE</term>
	/// <term>Unregisters notifications.</term>
	/// </item>
	/// <item>
	/// <term>WLAN_NOTIFICATION_SOURCE_ALL</term>
	/// <term>
	/// Registers for all notifications available on the version of the operating system, including those generated by the 802.1X
	/// module. For Windows XP with SP3 and Wireless LAN API for Windows XP with SP2, setting dwNotifSource to
	/// WLAN_NOTIFICATION_SOURCE_ALL is functionally equivalent to setting dwNotifSource to WLAN_NOTIFICATION_SOURCE_ACM.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WLAN_NOTIFICATION_SOURCE_ACM</term>
	/// <term>
	/// Registers for notifications generated by the auto configuration module. Windows XP with SP3 and Wireless LAN API for Windows XP
	/// with SP2: Only the wlan_notification_acm_connection_complete and wlan_notification_acm_disconnected notifications are available.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WLAN_NOTIFICATION_SOURCE_HNWK</term>
	/// <term>
	/// Registers for notifications generated by the wireless Hosted Network. This notification source is available on Windows 7 and on
	/// Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WLAN_NOTIFICATION_SOURCE_ONEX</term>
	/// <term>Registers for notifications generated by 802.1X.</term>
	/// </item>
	/// <item>
	/// <term>WLAN_NOTIFICATION_SOURCE_MSM</term>
	/// <term>
	/// Registers for notifications generated by MSM. Windows XP with SP3 and Wireless LAN API for Windows XP with SP2: This value is
	/// not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WLAN_NOTIFICATION_SOURCE_SECURITY</term>
	/// <term>
	/// Registers for notifications generated by the security module. No notifications are currently defined for
	/// WLAN_NOTIFICATION_SOURCE_SECURITY. Windows XP with SP3 and Wireless LAN API for Windows XP with SP2: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WLAN_NOTIFICATION_SOURCE_IHV</term>
	/// <term>
	/// Registers for notifications generated by independent hardware vendors (IHV). Windows XP with SP3 and Wireless LAN API for
	/// Windows XP with SP2: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WLAN_NOTIFICATION_SOURCE_IHV</term>
	/// <term>Registers for notifications generated by device services.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> This parameter must be set to
	/// WLAN_NOTIFICATION_SOURCE_NONE, WLAN_NOTIFICATION_SOURCE_ALL, or WLAN_NOTIFICATION_SOURCE_ACM.
	/// </para>
	/// </param>
	/// <param name="bIgnoreDuplicate">
	/// <para>
	/// Specifies whether duplicate notifications will be ignored. If set to <c>TRUE</c>, a notification will not be sent to the client
	/// if it is identical to the previous one.
	/// </para>
	/// <para><c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> This parameter is ignored.</para>
	/// </param>
	/// <param name="funcCallback">
	/// <para>A WLAN_NOTIFICATION_CALLBACK type that defines the type of notification callback function.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> if the dwNotifSource parameter is set to <c>WLAN_NOTIFICATION_SOURCE_NONE</c> to unregister
	/// notifications on all wireless interfaces,
	/// </para>
	/// </param>
	/// <param name="pCallbackContext">A pointer to the client context that will be passed to the callback function with the notification.</param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <param name="pdwPrevNotifSource">A pointer to the previously registered notification sources.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if hClientHandle is NULL or not valid or if pReserved is not NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Failed to allocate memory for the query results.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanRegisterNotification</c> is used by an application to register and unregister notifications on all wireless
	/// interfaces. When registering for notifications, an application must provide a callback function pointed to by the funcCallback
	/// parameter. The prototype for this callback function is the WLAN_NOTIFICATION_CALLBACK. This callback function will receive
	/// notifications that have been registered for in the dwNotifSource parameter passed to the <c>WlanRegisterNotification</c>
	/// function. The callback function is called with a pointer to a WLAN_NOTIFICATION_DATA structure as the first parameter that
	/// contains detailed information on the notification. The callback function also receives a second parameter that contains a
	/// pointer to the client context passed in the pCallbackContext parameter to the <c>WlanRegisterNotification</c> function.
	/// </para>
	/// <para>
	/// The <c>WlanRegisterNotification</c> function will return an error if dwNotifSource is a value other than
	/// <c>WLAN_NOTIFICATION_SOURCE_NONE</c> and the client fails to provide a callback function.
	/// </para>
	/// <para>
	/// Once registered, the callback function will be called whenever a notification is available until the client unregisters or
	/// closes the handle.
	/// </para>
	/// <para>
	/// Any registration to receive notifications caused by this function would be automatically undone if the calling application
	/// closes its calling handle (by calling WlanCloseHandle with the hClientHandle parameter) or if the process ends.
	/// </para>
	/// <para>
	/// Do not call <c>WlanRegisterNotification</c> from a callback function. If the client is in the middle of a notification callback
	/// when <c>WlanRegisterNotification</c> is called with dwNotifSource set to <c>WLAN_NOTIFICATION_SOURCE_NONE</c> (that is, when the
	/// client is unregistering from notifications), <c>WlanRegisterNotification</c> will wait for the callback to finish before
	/// returning a value. Calling this function inside a callback function will result in the call never completing. If both the
	/// callback function and the thread that unregisters from notifications try to acquire the same lock, a deadlock may occur. In
	/// addition, do not call <c>WlanRegisterNotification</c> from the <c>DllMain</c> function in an application DLL. This could also
	/// cause a deadlock.
	/// </para>
	/// <para>An application can time out and query the current interface state instead of waiting for a notification.</para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> Notifications are handled by the Netman service. If the
	/// Netman service is disabled or unavailable, notifications will not be received. If a notification is not received within a
	/// reasonable period of time, an application should time out and query the current interface state.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanregisternotification DWORD WlanRegisterNotification(
	// HANDLE hClientHandle, DWORD dwNotifSource, BOOL bIgnoreDuplicate, WLAN_NOTIFICATION_CALLBACK funcCallback, PVOID
	// pCallbackContext, PVOID pReserved, PDWORD pdwPrevNotifSource );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "e24810da-ed3b-41c4-b7b1-290b01e26cd5")]
	public static extern Win32Error WlanRegisterNotification(HWLANSESSION hClientHandle, WLAN_NOTIFICATION_SOURCE dwNotifSource,
		[MarshalAs(UnmanagedType.Bool)] bool bIgnoreDuplicate, WLAN_NOTIFICATION_CALLBACK? funcCallback, [In, Optional] IntPtr pCallbackContext,
		[In, Optional] IntPtr pReserved, out uint pdwPrevNotifSource);

	/// <summary>
	/// The <c>WlanRegisterVirtualStationNotification</c> function is used to register and unregister notifications on a virtual station.
	/// </summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="bRegister">A value that specifies whether to receive notifications on a virtual station.</param>
	/// <param name="pReserved">Reserved for future use. This parameter must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// A handle is invalid. This error is returned if the handle specified in the hClientHandle parameter was not found in the handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_STATE</term>
	/// <term>
	/// The resource is not in the correct state to perform the requested operation. This error is returned if the wireless Hosted
	/// Network is disabled by group policy on a domain.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started. This error is returned if the WLAN AutoConfig Service is not running.</term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>Various RPC and other error codes. Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanRegisterVirtualStationNotification</c> function is an extension to native wireless APIs added to support the wireless
	/// Hosted Network on Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// <para>
	/// A client application calls the <c>WlanRegisterVirtualStationNotification</c> function is used to register and unregister
	/// notifications on virtual station.
	/// </para>
	/// <para>
	/// Any registration to receive notifications from a virtual station caused by this function would be automatically undone if the
	/// calling application closes its calling handle (by calling WlanCloseHandle with the hClientHandle parameter) or if the process ends.
	/// </para>
	/// <para>
	/// By default, a application client will not receive notifications on a virtual station. In order to receive these notifications, a
	/// client needs to call the <c>WlanRegisterVirtualStationNotification</c> function with the bRegister parameter set to <c>TRUE</c>
	/// and must also call the WlanRegisterNotification function with the dwNotifSource parameter set to notification sources to be
	/// registered. The registration to receive notifications from a virtual station is in effect until the application closes the
	/// client handle (by calling WlanCloseHandle with the hClientHandle parameter), the process ends, or the
	/// <c>WlanRegisterVirtualStationNotification</c> function is called with the bRegister parameter set to <c>FALSE</c>.
	/// </para>
	/// <para>
	/// On Windows 7 and later, the operating system installs a virtual device if a Hosted Network capable wireless adapter is present
	/// on the machine. This virtual device normally shows up in the “Network Connections Folder” as ‘Wireless Network Connection 2’
	/// with a Device Name of ‘Microsoft Virtual WiFi Miniport adapter’ if the computer has a single wireless network adapter. This
	/// virtual device is used exclusively for performing software access point (SoftAP) connections and is not present in the list
	/// returned by the WlanEnumInterfaces function. The lifetime of this virtual device is tied to the physical wireless adapter. If
	/// the physical wireless adapter is disabled, this virtual device will be removed as well. This feature is also available on
	/// Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanregistervirtualstationnotification DWORD
	// WlanRegisterVirtualStationNotification( HANDLE hClientHandle, BOOL bRegister, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "b86ac160-ee81-43aa-86bb-cf5d3eeb2234")]
	public static extern Win32Error WlanRegisterVirtualStationNotification(HWLANSESSION hClientHandle, [MarshalAs(UnmanagedType.Bool)] bool bRegister, IntPtr pReserved = default);

	/// <summary>The <c>WlanRenameProfile</c> function renames the specified profile.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">The GUID of the interface.</param>
	/// <param name="strOldProfileName">The profile name to be changed.</param>
	/// <param name="strNewProfileName">The new name of the profile.</param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID PARAMETER</term>
	/// <term>
	/// hClientHandle is NULL or not valid, pInterfaceGuid is NULL, strOldProfileName is NULL, strNewProfileName is NULL, or pReserved
	/// is not NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>The profile specified by strOldProfileName was not found in the profile store.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have sufficient permissions to rename the profile.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// This function was called from an unsupported platform. This value will be returned if this function was called from a Windows XP
	/// with SP3 or Wireless LAN API for Windows XP with SP2 client.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanrenameprofile DWORD WlanRenameProfile( HANDLE
	// hClientHandle, const GUID *pInterfaceGuid, LPCWSTR strOldProfileName, LPCWSTR strNewProfileName, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "488e9f87-8b98-48c6-81d5-d7237cdf5bd5")]
	public static extern Win32Error WlanRenameProfile(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, [MarshalAs(UnmanagedType.LPWStr)] string strOldProfileName,
		[MarshalAs(UnmanagedType.LPWStr)] string strNewProfileName, IntPtr pReserved = default);

	/// <summary>The <c>WlanSaveTemporaryProfile</c> function saves a temporary profile to the profile store.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">The GUID of the interface.</param>
	/// <param name="strProfileName">The name of the profile to be saved. Profile names are case-sensitive. This string must be NULL-terminated.</param>
	/// <param name="strAllUserProfileSecurity">
	/// <para>
	/// Sets the security descriptor string on the all-user profile. By default, for a new all-user profile, all users have write access
	/// on the profile. For more information about profile permissions, see the Remarks section.
	/// </para>
	/// <para>If dwFlags is set to WLAN_PROFILE_USER, this parameter is ignored.</para>
	/// <para>If this parameter is set to <c>NULL</c> for an all-user profile, the default permissions are used.</para>
	/// <para>
	/// If this parameter is not <c>NULL</c> for an all-user profile, the security descriptor string associated with the profile is
	/// created or modified after the security descriptor object is created and parsed as a string.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Specifies the flags to set on the profile. The flags can be combined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>The profile is an all-user profile.</term>
	/// </item>
	/// <item>
	/// <term>WLAN_PROFILE_USER 0x00000002</term>
	/// <term>The profile is a per-user profile.</term>
	/// </item>
	/// <item>
	/// <term>WLAN_PROFILE_CONNECTION_MODE_SET_BY_CLIENT 0x00010000</term>
	/// <term>The profile was created by the client.</term>
	/// </item>
	/// <item>
	/// <term>WLAN_PROFILE_CONNECTION_MODE_AUTO 0x00020000</term>
	/// <term>The profile was created by the automatic configuration module.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bOverWrite">
	/// Specifies whether this profile is overwriting an existing profile. If this parameter is <c>FALSE</c> and the profile already
	/// exists, the existing profile will not be overwritten and an error will be returned.
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the following conditions occurred:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// This function was called from an unsupported platform. This value will be returned if this function was called from a Windows XP
	/// with SP3 or Wireless LAN API for Windows XP with SP2 client.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_STATE</term>
	/// <term>The interface is not currently connected using a temporary profile.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A temporary profile is the one passed to WlanConnect or generated by the discovery engine. A network connection can be
	/// established using a temporary profile. Using this API saves the temporary profile and associated user data to the profile store.
	/// </para>
	/// <para>
	/// A new profile is added at the top of the list after the group policy profiles. A profile's position in the list is not changed
	/// if an existing profile is overwritten.
	/// </para>
	/// <para>
	/// All-user profiles have three associated permissions: read, write, and execute. If a user has read access, the user can view
	/// profile permissions. If a user has execute access, the user has read access and the user can also connect to and disconnect from
	/// a network using the profile. If a user has write access, the user has execute access and the user can also modify and delete
	/// permissions associated with a profile.
	/// </para>
	/// <para>The following describes the procedure for creating a security descriptor object and parsing it as a string.</para>
	/// <list type="number">
	/// <item>
	/// <term>Call InitializeSecurityDescriptor to create a security descriptor in memory.</term>
	/// </item>
	/// <item>
	/// <term>Call SetSecurityDescriptorOwner.</term>
	/// </item>
	/// <item>
	/// <term>Call InitializeAcl to create a discretionary access control list (DACL) in memory.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Call AddAccessAllowedAce or AddAccessDeniedAce to add access control entries (ACEs) to the DACL. Set the AccessMask parameter to
	/// one of the following bitwise OR combinations as appropriate:
	/// </term>
	/// </item>
	/// <item>
	/// <term>Call SetSecurityDescriptorDacl to add the DACL to the security descriptor.</term>
	/// </item>
	/// <item>
	/// <term>Call ConvertSecurityDescriptorToStringSecurityDescriptor to convert the descriptor to string.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The string returned by ConvertSecurityDescriptorToStringSecurityDescriptor can then be used as the strAllUserProfileSecurity
	/// parameter value when calling <c>WlanSaveTemporaryProfile</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlansavetemporaryprofile DWORD WlanSaveTemporaryProfile(
	// HANDLE hClientHandle, const GUID *pInterfaceGuid, LPCWSTR strProfileName, LPCWSTR strAllUserProfileSecurity, DWORD dwFlags, BOOL
	// bOverWrite, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "e409fd30-eddd-4cc7-acb7-35af6ef51a10")]
	public static extern Win32Error WlanSaveTemporaryProfile(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, [MarshalAs(UnmanagedType.LPWStr)] string strProfileName,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? strAllUserProfileSecurity, WLAN_PROFILE_FLAGS dwFlags, [MarshalAs(UnmanagedType.Bool)] bool bOverWrite, IntPtr pReserved = default);

	/// <summary>The <c>WlanScan</c> function requests a scan for available networks on the indicated interface.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">
	/// <para>The GUID of the interface to be queried.</para>
	/// <para>The GUID of each wireless LAN interface enabled on a local computer can be determined using the WlanEnumInterfaces function.</para>
	/// </param>
	/// <param name="pDot11Ssid">
	/// A pointer to a DOT11_SSID structure that specifies the SSID of the network to be scanned. This parameter is optional. When set
	/// to <c>NULL</c>, the returned list contains all available networks. <c>Windows XP with SP3 and Wireless LAN API for Windows XP
	/// with SP2:</c> This parameter must be <c>NULL</c>.
	/// </param>
	/// <param name="pIeData">
	/// A pointer to an information element to include in probe requests. This parameter points to a WLAN_RAW_DATA structure that may
	/// include client provisioning availability information and 802.1X authentication requirements. <c>Windows XP with SP3 and Wireless
	/// LAN API for Windows XP with SP2:</c> This parameter must be <c>NULL</c>.
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>hClientHandle is NULL or invalid, pInterfaceGuid is NULL, or pReserved is not NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Failed to allocate memory for the query results.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanScan</c> function requests that the native 802.11 Wireless LAN driver scan for available wireless networks. The
	/// driver may or may not send probe requests (an active scan) depending on its implementation and the values passed in the
	/// pDot11Ssid and pIeData parameters.
	/// </para>
	/// <para>
	/// If the pIeData parameter is not <c>NULL</c>, the driver will send probe requests during the scan. The probe requests include the
	/// information element (IE) pointed to by the pIeData parameter. For instance, the Wi-Fi Protected Setup (WPS) IE can be included
	/// in the probe requests to discover WPS-capable access points. The buffer pointed to by the pIeData parameter must contain the
	/// complete IE starting from the Element ID.
	/// </para>
	/// <para>
	/// The pIeData parameter passed to the <c>WlanScan</c> function can contain a pointer to an optional WLAN_RAW_DATA structure that
	/// contains a proximity service discovery (PSD) IE data entry.
	/// </para>
	/// <para>
	/// When used to store a PSD IE, the <c>DOT11_PSD_IE_MAX_DATA_SIZE</c> constant defined in the Wlanapi.h header file is the maximum
	/// value of the <c>dwDataSize</c> member.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Constant</term>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>DOT11_PSD_IE_MAX_DATA_SIZE</term>
	/// <term>240</term>
	/// <term>The maximum data size, in bytes, of a PSD IE data entry.</term>
	/// </item>
	/// </list>
	/// <para>For more information about PSD IEs, including a discussion of the format of a PSD IE, see the WlanSetPsdIEDataList function.</para>
	/// <para>
	/// When the <c>WlanScan</c> function is called, the native 802.11 Wireless LAN driver may flush the current list of available
	/// wireless networks before the scan is initiated. Applications should not assume that calling the <c>WlanScan</c> function will
	/// add to the existing list of available wireless networks returned by the WlanGetNetworkBssList or WlanGetAvailableNetworkList
	/// functions from previous scans.
	/// </para>
	/// <para>
	/// The <c>WlanScan</c> function returns immediately. To be notified when the network scan is complete, a client on Windows Vista
	/// and later must register for notifications by calling WlanRegisterNotification. The dwNotifSource parameter passed to the
	/// <c>WlanRegisterNotification</c> function must have the WLAN_NOTIFICATION_SOURCE_ACM bit set to register for notifications
	/// generated by the auto configuration module. Wireless network drivers that meet Windows logo requirements are required to
	/// complete a <c>WlanScan</c> function request in 4 seconds.
	/// </para>
	/// <para>
	/// The Wireless LAN Service does not send notifications when available wireless networks change. The Wireless LAN Service does not
	/// track changes to the list of available networks across multiple scans. The current default behavior is that the Wireless LAN
	/// Service only asks the wireless interface driver to scan for wireless networks every 60 seconds, and in some cases (when already
	/// connected to wireless network) the Wireless LAN Service does not ask for scans at all. The <c>WlanScan</c> function can be used
	/// by an application to track wireless network changes. The application should first register for WLAN_NOTIFICATION_SOURCE_ACM
	/// notifications. The <c>WlanScan</c> function can then be called to initiate a scan. The application should then wait to receive
	/// the wlan_notification_acm_scan_complete notification or timeout after 4 seconds. Then the application can call the
	/// WlanGetNetworkBssList or WlanGetAvailableNetworkList function to retrieve a list of available wireless networks. This process
	/// can be repeated periodically with the application keeping tracking of changes to available wireless networks.
	/// </para>
	/// <para>
	/// The <c>WlanScan</c> function returns immediately and does not provide a notification when the scan is complete on Windows XP
	/// with SP3 or the Wireless LAN API for Windows XP with SP2.
	/// </para>
	/// <para>
	/// Since it becomes more difficult for a wireless interface to send and receive data packets while a scan is occurring, the
	/// <c>WlanScan</c> function may increase latency until the network scan is complete.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanscan DWORD WlanScan( HANDLE hClientHandle, const GUID
	// *pInterfaceGuid, const PDOT11_SSID pDot11Ssid, const PWLAN_RAW_DATA pIeData, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "cf30b285-9694-4ab0-ad13-c1ec4d8cb6e1")]
	public static extern Win32Error WlanScan(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, in DOT11_SSID pDot11Ssid, in WLAN_RAW_DATA pIeData, IntPtr pReserved = default);

	/// <summary>The <c>WlanScan</c> function requests a scan for available networks on the indicated interface.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">
	/// <para>The GUID of the interface to be queried.</para>
	/// <para>The GUID of each wireless LAN interface enabled on a local computer can be determined using the WlanEnumInterfaces function.</para>
	/// </param>
	/// <param name="pDot11Ssid">
	/// A pointer to a DOT11_SSID structure that specifies the SSID of the network to be scanned. This parameter is optional. When set
	/// to <c>NULL</c>, the returned list contains all available networks. <c>Windows XP with SP3 and Wireless LAN API for Windows XP
	/// with SP2:</c> This parameter must be <c>NULL</c>.
	/// </param>
	/// <param name="pIeData">
	/// A pointer to an information element to include in probe requests. This parameter points to a WLAN_RAW_DATA structure that may
	/// include client provisioning availability information and 802.1X authentication requirements. <c>Windows XP with SP3 and Wireless
	/// LAN API for Windows XP with SP2:</c> This parameter must be <c>NULL</c>.
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>hClientHandle is NULL or invalid, pInterfaceGuid is NULL, or pReserved is not NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Failed to allocate memory for the query results.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanScan</c> function requests that the native 802.11 Wireless LAN driver scan for available wireless networks. The
	/// driver may or may not send probe requests (an active scan) depending on its implementation and the values passed in the
	/// pDot11Ssid and pIeData parameters.
	/// </para>
	/// <para>
	/// If the pIeData parameter is not <c>NULL</c>, the driver will send probe requests during the scan. The probe requests include the
	/// information element (IE) pointed to by the pIeData parameter. For instance, the Wi-Fi Protected Setup (WPS) IE can be included
	/// in the probe requests to discover WPS-capable access points. The buffer pointed to by the pIeData parameter must contain the
	/// complete IE starting from the Element ID.
	/// </para>
	/// <para>
	/// The pIeData parameter passed to the <c>WlanScan</c> function can contain a pointer to an optional WLAN_RAW_DATA structure that
	/// contains a proximity service discovery (PSD) IE data entry.
	/// </para>
	/// <para>
	/// When used to store a PSD IE, the <c>DOT11_PSD_IE_MAX_DATA_SIZE</c> constant defined in the Wlanapi.h header file is the maximum
	/// value of the <c>dwDataSize</c> member.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Constant</term>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>DOT11_PSD_IE_MAX_DATA_SIZE</term>
	/// <term>240</term>
	/// <term>The maximum data size, in bytes, of a PSD IE data entry.</term>
	/// </item>
	/// </list>
	/// <para>For more information about PSD IEs, including a discussion of the format of a PSD IE, see the WlanSetPsdIEDataList function.</para>
	/// <para>
	/// When the <c>WlanScan</c> function is called, the native 802.11 Wireless LAN driver may flush the current list of available
	/// wireless networks before the scan is initiated. Applications should not assume that calling the <c>WlanScan</c> function will
	/// add to the existing list of available wireless networks returned by the WlanGetNetworkBssList or WlanGetAvailableNetworkList
	/// functions from previous scans.
	/// </para>
	/// <para>
	/// The <c>WlanScan</c> function returns immediately. To be notified when the network scan is complete, a client on Windows Vista
	/// and later must register for notifications by calling WlanRegisterNotification. The dwNotifSource parameter passed to the
	/// <c>WlanRegisterNotification</c> function must have the WLAN_NOTIFICATION_SOURCE_ACM bit set to register for notifications
	/// generated by the auto configuration module. Wireless network drivers that meet Windows logo requirements are required to
	/// complete a <c>WlanScan</c> function request in 4 seconds.
	/// </para>
	/// <para>
	/// The Wireless LAN Service does not send notifications when available wireless networks change. The Wireless LAN Service does not
	/// track changes to the list of available networks across multiple scans. The current default behavior is that the Wireless LAN
	/// Service only asks the wireless interface driver to scan for wireless networks every 60 seconds, and in some cases (when already
	/// connected to wireless network) the Wireless LAN Service does not ask for scans at all. The <c>WlanScan</c> function can be used
	/// by an application to track wireless network changes. The application should first register for WLAN_NOTIFICATION_SOURCE_ACM
	/// notifications. The <c>WlanScan</c> function can then be called to initiate a scan. The application should then wait to receive
	/// the wlan_notification_acm_scan_complete notification or timeout after 4 seconds. Then the application can call the
	/// WlanGetNetworkBssList or WlanGetAvailableNetworkList function to retrieve a list of available wireless networks. This process
	/// can be repeated periodically with the application keeping tracking of changes to available wireless networks.
	/// </para>
	/// <para>
	/// The <c>WlanScan</c> function returns immediately and does not provide a notification when the scan is complete on Windows XP
	/// with SP3 or the Wireless LAN API for Windows XP with SP2.
	/// </para>
	/// <para>
	/// Since it becomes more difficult for a wireless interface to send and receive data packets while a scan is occurring, the
	/// <c>WlanScan</c> function may increase latency until the network scan is complete.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanscan DWORD WlanScan( HANDLE hClientHandle, const GUID
	// *pInterfaceGuid, const PDOT11_SSID pDot11Ssid, const PWLAN_RAW_DATA pIeData, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "cf30b285-9694-4ab0-ad13-c1ec4d8cb6e1")]
	public static extern Win32Error WlanScan(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, IntPtr pDot11Ssid = default, IntPtr pIeData = default, IntPtr pReserved = default);

	/// <summary>The <c>WlanSetAutoConfigParameter</c> function sets parameters for the automatic configuration service.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="OpCode">
	/// <para>
	/// A WLAN_AUTOCONF_OPCODE value that specifies the parameter to be set. Only some of the opcodes in the <c>WLAN_AUTOCONF_OPCODE</c>
	/// enumeration support set operations.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>wlan_autoconf_opcode_show_denied_networks</term>
	/// <term>
	/// When set, the pData parameter will contain a BOOL value indicating whether user and group policy-denied networks will be
	/// included in the available networks list.
	/// </term>
	/// </item>
	/// <item>
	/// <term>wlan_autoconf_opcode_allow_explicit_creds</term>
	/// <term>
	/// When set, the pData parameter will contain a BOOL value indicating whether the current wireless interface has shared user
	/// credentials allowed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>wlan_autoconf_opcode_block_period</term>
	/// <term>
	/// When set, the pData parameter will contain a DWORD value for the blocked period setting for the current wireless interface. The
	/// blocked period is the amount of time, in seconds, for which automatic connection to a wireless network will not be attempted
	/// after a previous failure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>wlan_autoconf_opcode_allow_virtual_station_extensibility</term>
	/// <term>
	/// When set, the pData parameter will contain a BOOL value indicating whether extensibility on a virtual station is allowed. By
	/// default, extensibility on a virtual station is allowed. The value for this opcode is persisted across restarts. This enumeration
	/// value is supported on Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwDataSize">
	/// The size of the pData parameter, in bytes. This parameter must be set to for a BOOL or for a DWORD, depending on the value of
	/// the OpCode parameter.
	/// </param>
	/// <param name="pData">
	/// <para>
	/// The value to be set for the parameter specified in OpCode parameter. The pData parameter must point to a boolean or DWORD value,
	/// depending on the value of the OpCode parameter. The pData parameter must not be <c>NULL</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> The pData parameter may point to an integer value when a boolean is required. If pData points to 0, then the value
	/// is converted to <c>FALSE</c>. If pData points to a nonzero integer, then the value is converted to <c>TRUE</c>.
	/// </para>
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// Access is denied. This error is returned if the caller does not have sufficient permissions to set the configuration parameter
	/// when the OpCode parameter is wlan_autoconf_opcode_show_denied_networks or
	/// wlan_autoconf_opcode_allow_virtual_station_extensibility. When the OpCode parameter is set to one of these values, the
	/// WlanSetAutoConfigParameter function retrieves the discretionary access control list (DACL) stored for opcode object. If the DACL
	/// does not contain an access control entry (ACE) that grants WLAN_WRITE_ACCESS permission to the access token of the calling
	/// thread, then WlanSetAutoConfigParameter returns ERROR_ACCESS_DENIED. This error is also returned if the configuration parameter
	/// is set by group policy on a domain. When group policy is set for an opcode, applications are prevented from making changes. For
	/// the following OpCode parameters may be set by group policy: wlan_autoconf_opcode_show_denied_networks,
	/// wlan_autoconf_opcode_allow_explicit_creds, and wlan_autoconf_opcode_block_period
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// A parameter was bad. This error is returned if the hClientHandle parameter is NULL, the pData parameter is NULL, or the
	/// pReserved parameter is not NULL. This error is also returned if OpCode parameter specified is not one of the
	/// WLAN_AUTOCONF_OPCODE values for a configuration parameter that can be set. This error is also returned if the dwDataSize
	/// parameter is not set to , or the dwDataSize is not set to depending on the value of the OpCode parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// This function was called from an unsupported platform. This value will be returned if this function was called from a Windows XP
	/// with SP3 or Wireless LAN API for Windows XP with SP2 client.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanSetAutoConfigParameter</c> function sets parameters used by Auto Configuration Module (ACM), the wireless
	/// configuration component supported on Windows Vista and later.
	/// </para>
	/// <para>
	/// Depending on the value of the OpCode parameter, the data pointed to by pData will be converted to a boolean value before the
	/// automatic configuration parameter is set. If pData points to 0, then the parameter is set to <c>FALSE</c>; otherwise, the
	/// parameter is set to <c>TRUE</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlansetautoconfigparameter DWORD
	// WlanSetAutoConfigParameter( HANDLE hClientHandle, WLAN_AUTOCONF_OPCODE OpCode, DWORD dwDataSize, const PVOID pData, PVOID
	// pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "4f2514be-f05e-4be6-8c74-ef7a9ffe1c53")]
	public static extern Win32Error WlanSetAutoConfigParameter(HWLANSESSION hClientHandle, WLAN_AUTOCONF_OPCODE OpCode, uint dwDataSize,
		[In] IntPtr pData, IntPtr pReserved = default);

	/// <summary>The <c>WlanSetFilterList</c> function sets the permit/deny list.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="wlanFilterListType">
	/// A WLAN_FILTER_LIST_TYPE value that specifies the type of filter list. The value must be either
	/// <c>wlan_filter_list_type_user_permit</c> or <c>wlan_filter_list_type_user_deny</c>. Group policy-defined lists cannot be set
	/// using this function.
	/// </param>
	/// <param name="pNetworkList">
	/// Pointer to a DOT11_NETWORK_LIST structure that contains the list of networks to permit or deny. The <c>dwIndex</c> member of the
	/// structure must have a value less than the value of the <c>dwNumberOfItems</c> member of the structure; otherwise, an access
	/// violation may occur.
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have sufficient permissions to set the filter list. When called with wlanFilterListType set to
	/// wlan_filter_list_type_user_permit, WlanSetFilterList retrieves the discretionary access control list (DACL) stored with the
	/// wlan_secure_permit_list object. When called with wlanFilterListType set to wlan_filter_list_type_user_deny, WlanSetFilterList
	/// retrieves the DACL stored with the wlan_secure_deny_list object. In either of these cases, if the DACL does not contain an
	/// access control entry (ACE) that grants WLAN_WRITE_ACCESS permission to the access token of the calling thread, then
	/// WlanSetFilterList returns ERROR_ACCESS_DENIED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>hClientHandle is NULL or invalid or pReserved is not NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// This function was called from an unsupported platform. This value will be returned if this function was called from a Windows XP
	/// with SP3 or Wireless LAN API for Windows XP with SP2 client.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The group policy permit and deny lists take precedence over the user's permit and deny lists. That means access to a network on
	/// the user's permit list will be denied if the network appears on the group policy deny list. Similarly, access to a network on
	/// the user's deny list will be permitted if the network appears on the group policy permit list. Networks that are not on a user
	/// list or a group policy list will be permitted.
	/// </para>
	/// <para>
	/// Denied networks cannot be connected by means of auto config and will not be included on the visible networks list. New user
	/// permit and deny lists overwrite previous versions of the user lists.
	/// </para>
	/// <para>
	/// To clear a filter list, set the pNetworkList parameter to <c>NULL</c>, or pass a pointer to a DOT11_NETWORK_LIST structure that
	/// has the <c>dwNumberOfItems</c> member set to 0.
	/// </para>
	/// <para>
	/// To add all SSIDs to a filter list, pass a pointer to a DOT11_NETWORK_LIST structure with an associated DOT11_NETWORK structure
	/// that has the <c>uSSIDLength</c> member of its DOT11_SSID structure set to 0.
	/// </para>
	/// <para>
	/// To add all BSS types to a filter list, pass a pointer to a DOT11_NETWORK_LIST with an associated DOT11_NETWORK structure that
	/// has its <c>dot11BssType</c> member set to <c>dot11_BSS_type_any</c>.
	/// </para>
	/// <para>
	/// The <c>netsh wlan add filter</c> and <c>netsh wlan delete filter</c> commands provide similar functionality at the command line.
	/// For more information, see Netsh Commands for Wireless Local Area Network (wlan).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlansetfilterlist DWORD WlanSetFilterList( HANDLE
	// hClientHandle, WLAN_FILTER_LIST_TYPE wlanFilterListType, const PDOT11_NETWORK_LIST pNetworkList, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "697682c9-cb26-42d6-86b5-d7adebcedc68")]
	public static extern Win32Error WlanSetFilterList(HWLANSESSION hClientHandle, WLAN_FILTER_LIST_TYPE wlanFilterListType,
		[In, Optional, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(VanaraCustomMarshaler<DOT11_NETWORK_LIST>))] DOT11_NETWORK_LIST? pNetworkList,
		IntPtr pReserved = default);

	/// <summary>The <c>WlanSetInterface</c> function sets user-configurable parameters for a specified interface.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">The GUID of the interface to be configured.</param>
	/// <param name="OpCode">
	/// <para>
	/// A WLAN_INTF_OPCODE value that specifies the parameter to be set. The following table lists the valid constants along with the
	/// data type of the parameter in pData.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>WLAN_INTF_OPCODE value</term>
	/// <term>pData data type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>wlan_intf_opcode_autoconf_enabled</term>
	/// <term>BOOL</term>
	/// <term>Enables or disables auto config for the indicated interface.</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_background_scan_enabled</term>
	/// <term>BOOL</term>
	/// <term>Enables or disables background scan for the indicated interface.</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_radio_state</term>
	/// <term>WLAN_PHY_RADIO_STATE</term>
	/// <term>Sets the software radio state of a specific physical layer (PHY) for the interface.</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_bss_type</term>
	/// <term>DOT11_BSS_TYPE</term>
	/// <term>Sets the BSS type.</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_media_streaming_mode</term>
	/// <term>BOOL</term>
	/// <term>Sets media streaming mode for the driver.</term>
	/// </item>
	/// <item>
	/// <term>wlan_intf_opcode_current_operation_mode</term>
	/// <term>ULONG</term>
	/// <term>Sets the current operation mode for the interface. For more information, see Remarks.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> Only the <c>wlan_intf_opcode_autoconf_enabled</c> and
	/// <c>wlan_intf_opcode_bss_type</c> constants are valid.
	/// </para>
	/// </param>
	/// <param name="dwDataSize">
	/// The size of the pData parameter, in bytes. If dwDataSize is larger than the actual amount of memory allocated to pData, then an
	/// access violation will occur in the calling program.
	/// </param>
	/// <param name="pData">
	/// <para>
	/// The value to be set as specified by the OpCode parameter. The type of data pointed to by pData must be appropriate for the
	/// specified OpCode. Use the table above to determine the type of data to use.
	/// </para>
	/// <para>
	/// <c>Note</c> If OpCode is set to <c>wlan_intf_opcode_autoconf_enabled</c>, <c>wlan_intf_opcode_background_scan_enabled</c>, or
	/// <c>wlan_intf_opcode_media_streaming_mode</c>, then pData may point to an integer value. If pData points to 0, then the value is
	/// converted to <c>FALSE</c>. If pData points to a nonzero integer, then the value is converted to <c>TRUE</c>.
	/// </para>
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When OpCode is set to <c>wlan_intf_opcode_current_operation_mode</c>, the <c>WlanSetInterface</c> function sets the current
	/// operation mode of the wireless interface. For more information about operation modes, see Native 802.11 Operation Modes. Two
	/// operation modes are supported: <c>DOT11_OPERATION_MODE_EXTENSIBLE_STATION</c> and <c>DOT11_OPERATION_MODE_NETWORK_MONITOR</c>.
	/// The operation mode constants are defined in the header file Windot11.h. If pData does not point to one of these values when
	/// OpCode is set to <c>wlan_intf_opcode_current_operation_mode</c>, the <c>WlanSetInterface</c> function will fail with an error.
	/// </para>
	/// <para>
	/// To enable or disable the automatic configuration service at the command line, which is functionally equivalent to calling
	/// <c>WlanSetInterface</c> with OpCode set to <c>wlan_intf_opcode_autoconf_enabled</c>, use the <c>netsh wlan setautoconfig</c>
	/// command. For more information, see Netsh Commands for Wireless Local Area Network (wlan).
	/// </para>
	/// <para>
	/// The software radio state can be changed by calling the <c>WlanSetInterface</c> function. The hardware radio state cannot be
	/// changed by calling the <c>WlanSetInterface</c> function. When the OpCode parameter is set to
	/// <c>wlan_intf_opcode_radio_state</c>, the <c>WlanSetInterface</c> function sets the software radio state of a specific PHY. The
	/// pData parameter must point to a WLAN_PHY_RADIO_STATE structure with the new radio state values to use. The
	/// <c>dot11HardwareRadioState</c> member of the <c>WLAN_PHY_RADIO_STATE</c> structure is ignored when the <c>WlanSetInterface</c>
	/// function is called with the OpCode parameter set to <c>wlan_intf_opcode_radio_state</c> and the pData parameter points to a
	/// <c>WLAN_PHY_RADIO_STATE</c> structure. The radio state of a PHY is off if either the software radio state (
	/// <c>dot11SoftwareRadioState</c> member of the <c>WLAN_PHY_RADIO_STATE</c> structure) or the hardware radio state (
	/// <c>dot11HardwareRadioState</c> member of the <c>WLAN_PHY_RADIO_STATE</c> structure) is off.
	/// </para>
	/// <para>
	/// Changing the software radio state of a physical network interface could cause related changes in the state of the wireless
	/// Hosted Network or virtual wireless adapter radio states. The PHYs of every virtual wireless adapter are linked. For more
	/// information, see the About the Wireless Hosted Network.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlansetinterface DWORD WlanSetInterface( HANDLE
	// hClientHandle, const GUID *pInterfaceGuid, WLAN_INTF_OPCODE OpCode, DWORD dwDataSize, const PVOID pData, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "114a2a71-babd-4cd7-860a-fea523bcc865")]
	public static extern Win32Error WlanSetInterface(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, WLAN_INTF_OPCODE OpCode, uint dwDataSize,
		[In] IntPtr pData, IntPtr pReserved = default);

	/// <summary>The <c>WlanSetProfile</c> function sets the content of a specific profile.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">The GUID of the interface.</param>
	/// <param name="dwFlags">
	/// <para>The flags to set on the profile.</para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> dwFlags must be 0. Per-user profiles are not supported.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>The profile is an all-user profile.</term>
	/// </item>
	/// <item>
	/// <term>WLAN_PROFILE_GROUP_POLICY 0x00000001</term>
	/// <term>The profile is a group policy profile.</term>
	/// </item>
	/// <item>
	/// <term>WLAN_PROFILE_USER 0x00000002</term>
	/// <term>The profile is a per-user profile.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="strProfileXml">
	/// <para>
	/// Contains the XML representation of the profile. The WLANProfile element is the root profile element. To view sample profiles,
	/// see Wireless Profile Samples. There is no predefined maximum string length.
	/// </para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> The supplied profile must meet the compatibility
	/// criteria described in Wireless Profile Compatibility.
	/// </para>
	/// </param>
	/// <param name="strAllUserProfileSecurity">
	/// <para>
	/// Sets the security descriptor string on the all-user profile. For more information about profile permissions, see the Remarks section.
	/// </para>
	/// <para>If dwFlags is set to WLAN_PROFILE_USER, this parameter is ignored.</para>
	/// <para>
	/// If this parameter is set to <c>NULL</c> for a new all-user profile, the security descriptor associated with the
	/// wlan_secure_add_new_all_user_profiles object is used. If the security descriptor has not been modified by a
	/// WlanSetSecuritySettings call, all users have default permissions on a new all-user profile. Call WlanGetSecuritySettings to get
	/// the default permissions associated with the wlan_secure_add_new_all_user_profiles object.
	/// </para>
	/// <para>If this parameter is set to <c>NULL</c> for an existing all-user profile, the permissions of the profile are not changed.</para>
	/// <para>
	/// If this parameter is not <c>NULL</c> for an all-user profile, the security descriptor string associated with the profile is
	/// created or modified after the security descriptor object is created and parsed as a string.
	/// </para>
	/// <para><c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> This parameter must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="bOverwrite">
	/// Specifies whether this profile is overwriting an existing profile. If this parameter is <c>FALSE</c> and the profile already
	/// exists, the existing profile will not be overwritten and an error will be returned.
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <param name="pdwReasonCode">A WLAN_REASON_CODE value that indicates why the profile is not valid.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have sufficient permissions to set the profile. When called with dwFlags set to 0 - that is, when setting an
	/// all-user profile - WlanSetProfile retrieves the discretionary access control list (DACL) stored with the
	/// wlan_secure_add_new_all_user_profiles object. When called with dwFlags set to WLAN_PROFILE_USER - that is, when setting a
	/// per-user profile - WlanSetProfile retrieves the discretionary access control list (DACL) stored with the
	/// wlan_secure_add_new_per_user_profiles object. In either case, if the DACL does not contain an access control entry (ACE) that
	/// grants WLAN_WRITE_ACCESS permission to the access token of the calling thread, then WlanSetProfile returns ERROR_ACCESS_DENIED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_ALREADY_EXISTS</term>
	/// <term>
	/// strProfileXml specifies a network that already exists. Typically, this return value is used when bOverwrite is FALSE; however,
	/// if bOverwrite is TRUE and dwFlags specifies a different profile type than the one used by the existing profile, then the
	/// existing profile will not be overwritten and ERROR_ALREADY_EXISTS will be returned.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_PROFILE</term>
	/// <term>
	/// The profile specified by strProfileXml is not valid. If this value is returned, pdwReasonCode specifies the reason the profile
	/// is invalid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the following conditions occurred:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MATCH</term>
	/// <term>
	/// The interface does not support one or more of the capabilities specified in the profile. For example, if a profile specifies the
	/// use of WPA2 when the NIC only supports WPA, then this error code is returned. Also, if a profile specifies the use of FIPS mode
	/// when the NIC does not support FIPS mode, then this error code is returned.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>WlanSetProfile</c> function can be used to add a new wireless LAN profile or replace an existing wireless LAN profile.</para>
	/// <para>
	/// A new profile is added at the top of the list after the group policy profiles. A profile's position in the list is not changed
	/// if an existing profile is overwritten. <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c>
	/// </para>
	/// <para>
	/// Ad hoc profiles appear after the infrastructure profiles in the profile list. If you create a new ad hoc profile, it is placed
	/// at the top of the ad hoc list, after the group policy and infrastructure profiles.
	/// </para>
	/// <para>
	/// 802.1X guest profiles, Wireless Provisioning Service (WPS) profiles, and profiles with Wi-Fi Protected Access-None (WPA-None)
	/// authentication are not supported. That means such a profile cannot be created, deleted, enumerated, or accessed using Native
	/// Wifi functions. Any such profile already in the preferred profile list will remain in the list, and its position in the list
	/// relative to other profiles is fixed unless the position of the other profiles change.
	/// </para>
	/// <para>
	/// You can call <c>WlanSetProfile</c> on a profile that contains a plaintext key (that is, a profile with the protected element
	/// present and set to <c>FALSE</c>). Before the profile is saved in the profile store, the key material is automatically encrypted.
	/// When the profile is subsequently retrieved from the profile store by calling WlanGetProfile, the encrypted key material is
	/// returned. <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> The key material is never encrypted.
	/// </para>
	/// <para>
	/// All-user profiles have three associated permissions: read, write, and execute. If a user has read access, the user can view
	/// profile permissions. If a user has execute access, the user has read access and the user can also connect to and disconnect from
	/// a network using the profile. If a user has write access, the user has execute access and the user can also modify and delete
	/// permissions associated with a profile.
	/// </para>
	/// <para>The following describes the procedure for creating a security descriptor object and parsing it as a string.</para>
	/// <list type="number">
	/// <item>
	/// <term>Call InitializeSecurityDescriptor to create a security descriptor in memory.</term>
	/// </item>
	/// <item>
	/// <term>Call SetSecurityDescriptorOwner.</term>
	/// </item>
	/// <item>
	/// <term>Call InitializeAcl to create a discretionary access control list (DACL) in memory.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Call AddAccessAllowedAce or AddAccessDeniedAce to add access control entries (ACEs) to the DACL. Set the AccessMask parameter to
	/// one of the following as appropriate:
	/// </term>
	/// </item>
	/// <item>
	/// <term>Call SetSecurityDescriptorDacl to add the DACL to the security descriptor.</term>
	/// </item>
	/// <item>
	/// <term>Call ConvertSecurityDescriptorToStringSecurityDescriptor to convert the descriptor to string.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The string returned by ConvertSecurityDescriptorToStringSecurityDescriptor can then be used as the strAllUserProfileSecurity
	/// parameter value when calling <c>WlanSetProfile</c>.
	/// </para>
	/// <para>
	/// For every wireless LAN profile used by the Native Wifi AutoConfig service, Windows maintains the concept of custom user data.
	/// This custom user data is initially non-existent, but can be set by calling the WlanSetProfileCustomUserData function. The custom
	/// user data gets reset to empty any time the profile is modified by calling the <c>WlanSetProfile</c> function. Once custom user
	/// data has been set, this data can be accessed using the WlanGetProfileCustomUserData function.
	/// </para>
	/// <para>
	/// All wireless LAN functions require an interface GUID for the wireless interface when performing profile operations. When a
	/// wireless interface is removed, its state is cleared from Wireless LAN Service (WLANSVC) and no profile operations are possible.
	/// </para>
	/// <para>
	/// The <c>WlanSetProfile</c> function can fail with <c>ERROR_INVALID_PARAMETER</c> if the wireless interface specified in the
	/// pInterfaceGuid parameter has been removed from the system (a USB wireless adapter that has been removed, for example).
	/// </para>
	/// <para>
	/// The <c>netsh wlan add profile</c> command provides similar functionality at the command line. For more information, see Netsh
	/// Commands for Wireless Local Area Network (wlan).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlansetprofile DWORD WlanSetProfile( HANDLE hClientHandle,
	// const GUID *pInterfaceGuid, DWORD dwFlags, LPCWSTR strProfileXml, LPCWSTR strAllUserProfileSecurity, BOOL bOverwrite, PVOID
	// pReserved, DWORD *pdwReasonCode );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "3f8dca2e-6fe5-4c7d-a135-a33c61ba3dd5")]
	public static extern Win32Error WlanSetProfile(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, WLAN_PROFILE_FLAGS dwFlags,
		[MarshalAs(UnmanagedType.LPWStr)] string strProfileXml, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? strAllUserProfileSecurity,
		[MarshalAs(UnmanagedType.Bool)] bool bOverwrite, [Optional] IntPtr pReserved, out WLAN_REASON_CODE pdwReasonCode);

	/// <summary>The <c>WlanSetProfileCustomUserData</c> function sets the custom user data associated with a profile.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">The GUID of the interface.</param>
	/// <param name="strProfileName">
	/// The name of the profile associated with the custom user data. Profile names are case-sensitive. This string must be NULL-terminated.
	/// </param>
	/// <param name="dwDataSize">The size of pData, in bytes.</param>
	/// <param name="pData">A pointer to the user data to be set.</param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the following conditions occurred:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// This function was called from an unsupported platform. This value will be returned if this function was called from a Windows XP
	/// with SP3 or Wireless LAN API for Windows XP with SP2 client.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For every wireless WLAN profile used by the Native Wifi AutoConfig service, Windows maintains the concept of custom user data.
	/// This custom user data is initially non-existent, but can be set by calling the <c>WlanSetProfileCustomUserData</c> function. The
	/// custom user data gets reset to empty any time the profile is modified by calling the WlanSetProfile function.
	/// </para>
	/// <para>Once custom user data has been set, this data can be accessed using the WlanGetProfileCustomUserData function.</para>
	/// <para>
	/// All wireless LAN functions require an interface GUID for the wireless interface when performing profile operations. When a
	/// wireless interface is removed, its state is cleared from Wireless LAN Service (WLANSVC) and no profile operations are possible.
	/// </para>
	/// <para>
	/// The <c>WlanSetProfileCustomUserData</c> function can fail with <c>ERROR_INVALID_PARAMETER</c> if the wireless interface
	/// specified in the pInterfaceGuid parameter has been removed from the system (a USB wireless adapter that has been removed, for example).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlansetprofilecustomuserdata DWORD
	// WlanSetProfileCustomUserData( HANDLE hClientHandle, const GUID *pInterfaceGuid, LPCWSTR strProfileName, DWORD dwDataSize, const
	// PBYTE pData, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "3b37ff29-4c9b-42c8-b00a-a9dfca1d3fed")]
	public static extern Win32Error WlanSetProfileCustomUserData(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, [MarshalAs(UnmanagedType.LPWStr)] string strProfileName,
		uint dwDataSize, [In] IntPtr pData, IntPtr pReserved = default);

	/// <summary>
	/// The <c>WlanSetProfileEapUserData</c> function sets the Extensible Authentication Protocol (EAP) user credentials as specified by
	/// raw EAP data. The user credentials apply to a profile on an interface.
	/// </summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">The GUID of the interface.</param>
	/// <param name="strProfileName">
	/// The name of the profile associated with the EAP user data. Profile names are case-sensitive. This string must be NULL-terminated.
	/// </param>
	/// <param name="eapType">An EAP_METHOD_TYPE structure that contains the method for which the caller is supplying EAP user credentials.</param>
	/// <param name="dwFlags">
	/// <para>A set of flags that modify the behavior of the function.</para>
	/// <para>On Windows Vista and Windows Server 2008, this parameter is reserved and should be set to zero.</para>
	/// <para>On Windows 7, Windows Server 2008 R2, and later, this parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WLAN_SET_EAPHOST_DATA_ALL_USERS 0x00000001</term>
	/// <term>Set EAP host data for all users of this profile.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwEapUserDataSize">The size, in bytes, of the data pointed to by pbEapUserData.</param>
	/// <param name="pbEapUserData">
	/// <para>A pointer to the raw EAP data used to set the user credentials.</para>
	/// <para>On Windows Vista and Windows Server 2008, this parameter must not be <c>NULL</c>.</para>
	/// <para>
	/// On Windows 7, Windows Server 2008 R2, and later, this parameter can be set to <c>NULL</c> to delete the stored credentials for
	/// this profile if the dwFlags parameter contains <c>WLAN_SET_EAPHOST_DATA_ALL_USERS</c> and the dwEapUserDataSize parameter is 0.
	/// </para>
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>Access is denied. This value is returned if the caller does not have write access to the profile.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// A parameter is incorrect. This value is returned if any of the following conditions occur: On Windows Vista and Windows Server
	/// 2008, this value is returned if the pbEapUserData parameter is NULL. On Windows 7, Windows Server 2008 R2 , and later, this
	/// error is returned if the pbEapUserData parameter is NULL, but the dwEapUserDataSize parameter is not 0 or the dwFlags parameter
	/// does not contain WLAN_SET_EAPHOST_DATA_ALL_USERS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>A handle is invalid. This error is returned if the handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Not enough storage is available to process this command.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// The request is not supported. This value is returned when profile settings do not permit storage of user data. This can occur
	/// when single signon (SSO) is enabled or when the request was to delete the stored credentials for this profile (the pbEapUserData
	/// parameter was NULL, the dwFlags parameter contains WLAN_SET_EAPHOST_DATA_ALL_USERS, and the dwEapUserDataSize parameter is 0).
	/// On Windows 7, Windows Server 2008 R2 , and later, this value is returned if the WlanSetProfileEapUserData function was called on
	/// a profile that uses a method other than 802.1X for authentication. This value is also returned if this function was called from
	/// a Windows XP with SP3 or Wireless LAN API for Windows XP with SP2 client.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started. This value is returned if the Wireless LAN service is not running.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanSetProfileEapUserData</c> function sets the EAP user credentials to use on a profile. On Windows Vista and Windows
	/// Server 2008, these credentials can only be used by the caller.
	/// </para>
	/// <para>
	/// The eapType parameter is an EAP_METHOD_TYPE structure that contains type, identification, and author information about an EAP
	/// method. The <c>eapType</c> member of the <c>EAP_METHOD_TYPE</c> structure is an EAP_TYPE structure that contains the type and
	/// vendor identification information for an EAP method.
	/// </para>
	/// <para>For more information on the allocation of EAP method types, see section 6.2 of RFC 3748 published by the IETF.</para>
	/// <para>
	/// On Windows 7, Windows Server 2008 R2, and later, the <c>WlanSetProfileEapUserData</c> function is enhanced. EAP user credentials
	/// can be set for all users of a profile if the dwFlags parameter contains <c>WLAN_SET_EAPHOST_DATA_ALL_USERS</c>. The EAP user
	/// credentials on a profile can also be deleted. To delete the EAP user credentials on a profile, the pbEapUserData parameter must
	/// be <c>NULL</c>, the dwFlags parameter must equal <c>WLAN_SET_EAPHOST_DATA_ALL_USERS</c>, and the dwEapUserDataSize parameter
	/// must be 0.
	/// </para>
	/// <para>
	/// All wireless LAN functions require an interface GUID for the wireless interface when performing profile operations. When a
	/// wireless interface is removed, its state is cleared from Wireless LAN Service (WLANSVC) and no profile operations are possible.
	/// </para>
	/// <para>
	/// The <c>WlanSetProfileEapUserData</c> function can fail with <c>ERROR_INVALID_PARAMETER</c> if the wireless interface specified
	/// in the pInterfaceGuid parameter has been removed from the system (a USB wireless adapter that has been removed, for example).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlansetprofileeapuserdata DWORD WlanSetProfileEapUserData(
	// HANDLE hClientHandle, const GUID *pInterfaceGuid, LPCWSTR strProfileName, EAP_METHOD_TYPE eapType, DWORD dwFlags, DWORD
	// dwEapUserDataSize, const LPBYTE pbEapUserData, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "2bef0f2f-165d-446a-afa8-735658048152")]
	public static extern Win32Error WlanSetProfileEapUserData(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, [MarshalAs(UnmanagedType.LPWStr)] string strProfileName,
		EAP_METHOD_TYPE eapType, WLAN_SET_EAPHOST dwFlags, uint dwEapUserDataSize, [In, Optional] IntPtr pbEapUserData, IntPtr pReserved = default);

	/// <summary>
	/// The <c>WlanSetProfileEapXmlUserData</c> function sets the Extensible Authentication Protocol (EAP) user credentials as specified
	/// by an XML string. The user credentials apply to a profile on an adapter. These credentials can only be used by the caller.
	/// </summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">The GUID of the interface.</param>
	/// <param name="strProfileName">
	/// <para>The name of the profile associated with the EAP user data. Profile names are case-sensitive. This string must be NULL-terminated.</para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> The supplied name must match the profile name derived
	/// automatically from the SSID of the network. For an infrastructure network profile, the SSID must be supplied for the profile
	/// name. For an ad hoc network profile, the supplied name must be the SSID of the ad hoc network followed by .
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>A set of flags that modify the behavior of the function.</para>
	/// <para>
	/// On Wireless LAN API for Windows XP with SP2, Windows XP with SP3,Windows Vista, and Windows Server 2008, this parameter is
	/// reserved and should be set to zero.
	/// </para>
	/// <para>On Windows 7, Windows Server 2008 R2, and later, this parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WLAN_SET_EAPHOST_DATA_ALL_USERS 0x00000001</term>
	/// <term>Set EAP host data for all users of this profile.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="strEapXmlUserData">
	/// <para>A pointer to XML data used to set the user credentials.</para>
	/// <para>
	/// The XML data must be based on the EAPHost User Credentials schema. To view sample user credential XML data, see EAPHost User Properties.
	/// </para>
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>Access is denied. This value is returned if the caller does not have write access to the profile.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_PROFILE</term>
	/// <term>
	/// The network connection profile is corrupted. This error is returned if the profile specified in the strProfileName parameter
	/// could not be parsed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This value is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>A handle is invalid. This error is returned if the handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Not enough storage is available to process this command.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// The request is not supported. This value is returned when profile settings do not permit storage of user data. This can occur
	/// when single signon (SSO) is enabled. On Windows 7, Windows Server 2008 R2 , and later, this value is returned if the
	/// WlanSetProfileEapXmlUserData function was called on a profile that uses a method other than 802.1X for authentication.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_SERVICE_NOT_ACTIVE</term>
	/// <term>The service has not been started. This value is returned if the Wireless LAN service is not running.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WlanSetProfileEapXmlUserData</c> function sets the EAP user credentials to use on a profile. This function can only be
	/// called on a profile that uses 802.1X for authentication. On Windows Vista and Windows Server 2008, these credentials can only be
	/// used by the caller.
	/// </para>
	/// <para>
	/// The eapType parameter is an EAP_METHOD_TYPE structure that contains type, identification, and author information about an EAP
	/// method. The <c>eapType</c> member of the <c>EAP_METHOD_TYPE</c> structure is an EAP_TYPE structure that contains the type and
	/// vendor identification information for an EAP method.
	/// </para>
	/// <para>For more information on the allocation of EAP method types, see section 6.2 of RFC 3748 published by the IETF.</para>
	/// <para>
	/// On Windows 7, Windows Server 2008 R2, and later, the <c>WlanSetProfileEapXmlUserData</c> function is enhanced. EAP user
	/// credentials can be set for all users of a profile if the dwFlags parameter contains <c>WLAN_SET_EAPHOST_DATA_ALL_USERS</c>.
	/// </para>
	/// <para>
	/// All wireless LAN functions require an interface GUID for the wireless interface when performing profile operations. When a
	/// wireless interface is removed, its state is cleared from Wireless LAN Service (WLANSVC) and no profile operations are possible.
	/// </para>
	/// <para>
	/// The <c>WlanSetProfileEapXmlUserData</c> function can fail with <c>ERROR_INVALID_PARAMETER</c> if the wireless interface
	/// specified in the pInterfaceGuid parameter has been removed from the system (a USB wireless adapter that has been removed, for example).
	/// </para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> This function can only be used for Protected EAP (PEAP)
	/// credentials. It cannot be used for other EAP types.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlansetprofileeapxmluserdata DWORD
	// WlanSetProfileEapXmlUserData( HANDLE hClientHandle, const GUID *pInterfaceGuid, LPCWSTR strProfileName, DWORD dwFlags, LPCWSTR
	// strEapXmlUserData, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "c34c39c0-8200-438a-8353-238225aea5cb")]
	public static extern Win32Error WlanSetProfileEapXmlUserData(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, [MarshalAs(UnmanagedType.LPWStr)] string strProfileName,
		WLAN_SET_EAPHOST dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string strEapXmlUserData, IntPtr pReserved = default);

	/// <summary>The <c>WlanSetProfileList</c> function sets the preference order of profiles for a given interface.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">The GUID of the interface.</param>
	/// <param name="dwItems">The number of profiles in the strProfileNames parameter.</param>
	/// <param name="strProfileNames">
	/// <para>The names of the profiles in the desired order. Profile names are case-sensitive. This string must be NULL-terminated.</para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> The supplied names must match the profile names derived
	/// automatically from the SSID of the network. For infrastructure network profiles, the SSID must be supplied for the profile name.
	/// For ad hoc network profiles, the supplied name must be the SSID of the ad hoc network followed by .
	/// </para>
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have sufficient permissions to change the profile list. Before WlanSetProfileList performs an operation that
	/// changes the relative order of all-user profiles in the profile list or moves an all-user profile to a lower position in the
	/// profile list, WlanSetProfileList retrieves the discretionary access control list (DACL) stored with the
	/// wlan_secure_all_user_profiles_order object. If the DACL does not contain an access control entry (ACE) that grants
	/// WLAN_WRITE_ACCESS permission to the access token of the calling thread, then WlanSetProfileList returns ERROR_ACCESS_DENIED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the following conditions occurred:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>strProfileNames contains the name of a profile that is not present in the profile store.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>WlanSetProfileList</c> function sets the preference order of wireless LAN profiles for a given wireless interface.</para>
	/// <para>
	/// The profiles in the list must be a one-to-one match with the current profiles returned by the WlanGetProfileList function. The
	/// position of group policy profiles cannot be changed.
	/// </para>
	/// <para>
	/// All wireless LAN functions require an interface GUID for the wireless interface when performing profile operations. When a
	/// wireless interface is removed, its state is cleared from Wireless LAN Service (WLANSVC) and no profile operations are possible.
	/// </para>
	/// <para>
	/// The <c>WlanSetProfileList</c> function can fail with <c>ERROR_INVALID_PARAMETER</c> if the wireless interface specified in the
	/// pInterfaceGuid parameter has been removed from the system (a USB wireless adapter that has been removed, for example).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlansetprofilelist DWORD WlanSetProfileList( HANDLE
	// hClientHandle, const GUID *pInterfaceGuid, DWORD dwItems, LPCWSTR *strProfileNames, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "980c7920-a25e-4e05-a742-77178a7f000a")]
	public static extern Win32Error WlanSetProfileList(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, uint dwItems,
		[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] strProfileNames, IntPtr pReserved = default);

	/// <summary>The <c>WlanSetProfilePosition</c> function sets the position of a single, specified profile in the preference list.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="pInterfaceGuid">The GUID of the interface.</param>
	/// <param name="strProfileName">
	/// <para>The name of the profile. Profile names are case-sensitive. This string must be NULL-terminated.</para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> The supplied name must match the profile name derived
	/// automatically from the SSID of the network. For an infrastructure network profile, the SSID must be supplied for the profile
	/// name. For an ad hoc network profile, the supplied name must be the SSID of the ad hoc network followed by .
	/// </para>
	/// </param>
	/// <param name="dwPosition">
	/// Indicates the position in the preference list that the profile should be shifted to. 0 (zero) corresponds to the first profile
	/// in the list that is returned by the WlanGetProfileList function.
	/// </param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have sufficient permissions to change the profile position. Before WlanSetProfilePosition performs an
	/// operation that changes the relative order of all-user profiles in the profile list or moves an all-user profile to a lower
	/// position in the profile list, WlanSetProfilePosition retrieves the discretionary access control list (DACL) stored with the
	/// wlan_secure_all_user_profiles_order object. If the DACL does not contain an access control entry (ACE) that grants
	/// WLAN_WRITE_ACCESS permission to the access token of the calling thread, then WlanSetProfilePosition returns ERROR_ACCESS_DENIED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>hClientHandle is NULL or invalid, pInterfaceGuid is NULL, strProfileName is NULL, or pReserved is not NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The position of group policy profiles cannot be changed.</para>
	/// <para>
	/// By default, only a user logged on as a member of the Administrators group can change the position of an all-user profile. Call
	/// WlanGetSecuritySettings to determine the actual user rights required to change the position of an all-user profile.
	/// </para>
	/// <para>
	/// To set the profile position at the command line, use the <c>netsh wlan set profileorder</c> command. For more information, see
	/// Netsh Commands for Wireless Local Area Network (wlan).
	/// </para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> Ad hoc profiles appear after the infrastructure
	/// profiles in the profile list. If you try to position an ad hoc profile before an infrastructure profile using
	/// <c>WlanSetProfilePosition</c>, the <c>WlanSetProfilePosition</c> call will succeed but the Wireless Zero Configuration service
	/// will reorder the profile list such that the ad hoc profile is positioned after all infrastructure network profiles.
	/// </para>
	/// <para>
	/// Guest profiles, profiles with Wireless Provisioning Service (WPS) authentication, and profiles with Wi-Fi Protected Access-None
	/// (WPA-None) authentication are not supported. Any such profile that appears in the preferred profile list has a fixed position in
	/// the profile list. That means its position cannot be changed using <c>WlanSetProfilePosition</c> and that its position is not
	/// affected by position changes of other profiles.
	/// </para>
	/// <para>
	/// All wireless LAN functions require an interface GUID for the wireless interface when performing profile operations. When a
	/// wireless interface is removed, its state is cleared from Wireless LAN Service (WLANSVC) and no profile operations are possible.
	/// </para>
	/// <para>
	/// The <c>WlanSetProfilePosition</c> function can fail with <c>ERROR_INVALID_PARAMETER</c> if the wireless interface specified in
	/// the pInterfaceGuid parameter has been removed from the system (a USB wireless adapter that has been removed, for example).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlansetprofileposition DWORD WlanSetProfilePosition( HANDLE
	// hClientHandle, const GUID *pInterfaceGuid, LPCWSTR strProfileName, DWORD dwPosition, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "06ef9f55-b425-4f61-9b9e-3c27cc3796f6")]
	public static extern Win32Error WlanSetProfilePosition(HWLANSESSION hClientHandle, in Guid pInterfaceGuid, [MarshalAs(UnmanagedType.LPWStr)] string strProfileName,
		uint dwPosition, IntPtr pReserved = default);

	/// <summary>
	/// The <c>WlanSetPsdIeDataList</c> function sets the proximity service discovery (PSD) information element (IE) data list.
	/// </summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="strFormat">
	/// The format of a PSD IE in the PSD IE data list passed in the pPsdIEDataList parameter. This is a NULL-terminated URI string that
	/// specifies the namespace of the protocol used for discovery.
	/// </param>
	/// <param name="pPsdIEDataList">A pointer to a WLAN_RAW_DATA_LIST structure that contains the PSD IE data list to be set.</param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if the hClientHandle is NULL or not valid or pReserved is not NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle hClientHandle was not found in the handle table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// This function was called from an unsupported platform. This value is returned if the function was called from a Windows XP with
	/// SP3 or Wireless LAN API for Windows XP with SP2 client.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The Proximity Service Discovery Protocol is a Microsoft proprietary protocol that allows a client to discover services in its
	/// physical proximity, which is defined by the radio range. The purpose of the Proximity Service Discovery Protocol is to convey
	/// service discovery information, such as service advertisements, as part of Beacon frames. Access points (APs) and stations (STAs)
	/// that operate in ad hoc mode periodically broadcast beacon frames. The beacon frame can contain single or multiple proprietary
	/// information elements that carry discovery information pertaining to the services that the device offers.
	/// </para>
	/// <para>
	/// A PSD IE is used to transmit compressed information provided by higher-level discovery protocols for the purpose of passive
	/// discovery. One such higher-level protocol used for discovery is the WS-Discovery protocol. Any protocol can be used for discovery.
	/// </para>
	/// <para>
	/// Windows Vista and Windows Server 2008 with the Wireless LAN Service installed support passive discovery for ad hoc clients, ad
	/// hoc services, and infrastructure clients. This means an ad hoc service can advertise an available resource or service by
	/// transmitting a PSD IE in one or more beacons. There is no guarantee that this beacon is received by an ad hoc or infrastructure client.
	/// </para>
	/// <para>
	/// Windows 7 and Windows Server 2008 R2 with the Wireless LAN Service installed support passive discovery for ad hoc clients, ad
	/// hoc services, and infrastructure clients in the same way as in Windows Vista. In addition, the PSD IE is also supported for the
	/// wireless Hosted Network, a software-based wireless access point (AP). Applications on the local computer where the wireless
	/// Hosted Network is to be run may use the <c>WlanSetPsdIeDataList</c> function to set the PSD IE before starting the wireless
	/// Hosted Network. Once set, the PSD IE will be included in the beacon and probe response after the wireless Hosted Network is started.
	/// </para>
	/// <para>
	/// Each application sending or receiving beacons maintains its own PSD IE data list. The pPsdIEDataList parameter points to a list
	/// of PSD IEs generated by the application. Each PSD IE has the following format.
	/// </para>
	/// <para>
	/// Element ID 221 specifies the Vendor-Specific information element defined in the IEEE 802.11 standards. The Organizational Unique
	/// Identifier (OUI) contains a 3-byte, IEEE-assigned OUI of the vendor that defined the content of the information element in the
	/// same order that the OUI would be transmitted in an IEEE 802.11 address field. The Element ID, Length, OUI, and OUI Type fields
	/// are controlled by the automatic configuration service, while the application controls the rest of the fields.
	/// </para>
	/// <para>
	/// The Format identifier hash field describes the format of the information carried in the PSD IE. To ensure uniqueness while
	/// circumventing the need for central administration of format identifiers, a string in the form of a Uniform Resource Identifier
	/// (URI), as specified in RFC 3986, is used to distinguish the format. However, because the transmission must be efficient and
	/// space in the information element is limited, the string is not actually transmitted, but, instead, its hash is transmitted. On
	/// the client, which is the receiving side of the beacon, the hash is matched against a known set of format identifiers.
	/// </para>
	/// <para>
	/// The Format identifier hash field is represented by bits 0…31 of a hash-based message authentication code (HMAC) over the format
	/// identifier string specified in the strFormat parameter. The HMAC is used to specify the format of the Data field of the PSD IE.
	/// The formula used to calculate the HMAC is described in RFC 2104. Sample code for the calculation of the HMAC is as specified in
	/// RFC 4634. When calculating the HMAC, use SHA-256 for the hash function. The key used is the "null" key ( <c>NULL</c> pointer to
	/// the authentication key, and zero length authentication key per the source code in RFC 4634). Use the value of strFormat
	/// parameter (including any spaces but excluding the NULL-termination character) as the input text encoded as Unicode UTF-16 in
	/// little-endian format.
	/// </para>
	/// <para>For example, if the strFormat parameter is , then the first four octets of the corresponding HMAC is .</para>
	/// <para>If the strFormat parameter is , then the four octets of the corresponding HMAC are .</para>
	/// <para>When sending the first 4 octets of an HMAC over the network, send the first (left-most) octet first.</para>
	/// <para>
	/// Note that there may be collisions in the truncated HMACs, which means that it may be impossible to uniquely determine the
	/// discovery protocol corresponding to the payload of a PSD IE from the given bits of an HMAC. An application receiving a PSD IE
	/// must take a best guess at the discovery protocol used from a given HMAC, then re-run the higher-level discovery protocol once a
	/// connection has been established.
	/// </para>
	/// <para>
	/// At most, five PSD IEs can be passed in a list. Also, the total length, in bytes, of the PSD IE list may be restricted by
	/// hardware limitations on the length of a beacon.
	/// </para>
	/// <para>
	/// An application can call <c>WlanSetPsdIeDataList</c> many times. When <c>WlanSetPsdIeDataList</c> is called twice with the same
	/// strFormat, the contents of the WLAN_RAW_DATA_LIST populated by the first function call are overwritten by the second call's
	/// <c>WLAN_RAW_DATA_LIST</c> payload. When <c>WlanSetPsdIeDataList</c> is called with the pPsdIEDataList parameter set to
	/// <c>NULL</c>, the PSD IE list associated with strFormat is cleared. When <c>WlanSetPsdIeDataList</c> is called with both the
	/// pPsdIEDataList and strFormat parameters set to <c>NULL</c>, all PSD IE lists set by the application are cleared.
	/// </para>
	/// <para>
	/// The wireless service processes PSD IE data lists set by different applications and generates raw IE data blobs. When a machine
	/// creates or joins an ad-hoc network on any wireless adapter, it sends beacons that include a PSD IE data blob associated with the
	/// network to other machines.
	/// </para>
	/// <para>Stations can call WlanExtractPsdIEDataList function to get the PSD IE data list after receiving a beacon from a machine.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlansetpsdiedatalist DWORD WlanSetPsdIEDataList( HANDLE
	// hClientHandle, LPCWSTR strFormat, const PWLAN_RAW_DATA_LIST pPsdIEDataList, PVOID pReserved );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "eea402d3-9a5f-4446-bf6c-9ab8430f9c60")]
	public static extern Win32Error WlanSetPsdIEDataList(HWLANSESSION hClientHandle, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? strFormat,
		[In, Optional] IntPtr pPsdIEDataList, IntPtr pReserved = default);

	/// <summary>The WlanGetProfileList function sets the security settings for a configurable object.</summary>
	/// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	/// <param name="SecurableObject">
	/// A WLAN_SECURABLE_OBJECT value that specifies the object to which the security settings will be applied.
	/// </param>
	/// <param name="strModifiedSDDL">
	/// A security descriptor string that specifies the new security settings for the object. This string must be NULL-terminated. For
	/// more information, see the Remarks section.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter is incorrect. This error is returned if any of the following conditions occur:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>
	/// A handle is invalid. This error is returned if the handle specified in the hClientHandle parameter was not found in the handle table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have sufficient permissions.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// This function was called from an unsupported platform. This value will be returned if this function was called from a Windows XP
	/// with SP3 or Wireless LAN API for Windows XP with SP2 client.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A successful call to the <c>WlanSetSecuritySettings</c> function overrides the default permissions associated with an object.
	/// For more information about default permissions, see Native Wifi API Permissions.
	/// </para>
	/// <para>The following describes the procedure for creating a security descriptor object and parsing it as a string.</para>
	/// <list type="number">
	/// <item>
	/// <term>Call InitializeSecurityDescriptor to create a security descriptor in memory.</term>
	/// </item>
	/// <item>
	/// <term>Call SetSecurityDescriptorOwner to set the owner information for the security descriptor.</term>
	/// </item>
	/// <item>
	/// <term>Call InitializeAcl to create a discretionary access control list (DACL) in memory.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Call AddAccessAllowedAce or AddAccessDeniedAce to add access control entries (ACEs) to the DACL. Set the AccessMask parameter to
	/// one of the following bitwise OR combinations as appropriate:
	/// </term>
	/// </item>
	/// <item>
	/// <term>Call SetSecurityDescriptorDacl to add the DACL to the security descriptor.</term>
	/// </item>
	/// <item>
	/// <term>Call ConvertSecurityDescriptorToStringSecurityDescriptor to convert the descriptor to string.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The string returned by ConvertSecurityDescriptorToStringSecurityDescriptor can then be used as the strModifiedSDDL parameter
	/// value when calling <c>WlanSetSecuritySettings</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlansetsecuritysettings DWORD WlanSetSecuritySettings(
	// HANDLE hClientHandle, WLAN_SECURABLE_OBJECT SecurableObject, LPCWSTR strModifiedSDDL );
	[DllImport(Lib.Wlanapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "6038e4bc-7f07-4148-ac34-e290c8c40e99")]
	public static extern Win32Error WlanSetSecuritySettings(HWLANSESSION hClientHandle, WLAN_SECURABLE_OBJECT SecurableObject,
		[MarshalAs(UnmanagedType.LPWStr)] string strModifiedSDDL);

	/// <summary>
	/// Displays the wireless profile user interface (UI). This UI is used to view and edit advanced settings of a wireless network profile.
	/// </summary>
	/// <param name="dwClientVersion">
	/// Specifies the highest version of the WLAN API that the client supports. Values other than WLAN_UI_API_VERSION will be ignored.
	/// </param>
	/// <param name="wstrProfileName">
	/// <para>Contains the name of the profile to be viewed or edited. Profile names are case-sensitive. This string must be NULL-terminated.</para>
	/// <para>
	/// The supplied profile must be present on the interface pInterfaceGuid. That means the profile must have been previously created
	/// and saved in the profile store and that the profile must be valid for the supplied interface.
	/// </para>
	/// </param>
	/// <param name="pInterfaceGuid">The GUID of the interface.</param>
	/// <param name="hWnd">The handle of the application window requesting the UI display.</param>
	/// <param name="wlStartPage">A WL_DISPLAY_PAGES value that specifies the active tab when the UI dialog box appears.</param>
	/// <param name="pReserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <param name="pWlanReasonCode">A pointer to a WLAN_REASON_CODE value that indicates why the UI display failed.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value may be one of the following return codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the supplied parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// This function was called from an unsupported platform. This value will be returned if this function was called from a Windows XP
	/// with SP3 or Wireless LAN API for Windows XP with SP2 client.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_STATUS</term>
	/// <term>Various error codes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// If <c>WlanUIEditProfile</c> returns ERROR_SUCCESS, any changes to the profile made in the UI will be saved in the profile store.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/nf-wlanapi-wlanuieditprofile DWORD WlanUIEditProfile( DWORD
	// dwClientVersion, LPCWSTR wstrProfileName, GUID *pInterfaceGuid, HWND hWnd, WL_DISPLAY_PAGES wlStartPage, PVOID pReserved,
	// PWLAN_REASON_CODE pWlanReasonCode );
	[DllImport(Lib.Wlanui, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wlanapi.h", MSDNShortId = "e6453a70-2a11-4f01-adc1-67346a5856b2")]
	public static extern Win32Error WlanUIEditProfile(uint dwClientVersion, [MarshalAs(UnmanagedType.LPWStr)] string wstrProfileName, in Guid pInterfaceGuid,
		HWND hWnd, WL_DISPLAY_PAGES wlStartPage, [Optional] IntPtr pReserved, out WLAN_REASON_CODE pWlanReasonCode);

	///// <summary>
	///// The <c>WlanEnumInterfaces</c> function enumerates all of the wireless LAN interfaces currently enabled on the local computer.
	///// </summary>
	///// <param name="hClientHandle">The client's session handle, obtained by a previous call to the WlanOpenHandle function.</param>
	///// <param name="ppInterfaceList">
	///// <para>
	///// The returned list of wireless LAN interfaces in an array of WLAN_INTERFACE_INFO structures.
	///// </para>
	///// </param>
	///// <returns>
	///// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	///// <para>If the function fails, the return value may be one of the following return codes.</para>
	///// <list type="table">
	///// <listheader>
	///// <term>Return code</term>
	///// <term>Description</term>
	///// </listheader>
	///// <item>
	///// <term>ERROR_INVALID_PARAMETER</term>
	///// <term>
	///// A parameter is incorrect. This error is returned if the hClientHandle or ppInterfaceList parameter is NULL. This error is
	///// returned if the pReserved is not NULL. This error is also returned if the hClientHandle parameter is not valid.
	///// </term>
	///// </item>
	///// <item>
	///// <term>ERROR_INVALID_HANDLE</term>
	///// <term>The handle hClientHandle was not found in the handle table.</term>
	///// </item>
	///// <item>
	///// <term>RPC_STATUS</term>
	///// <term>Various error codes.</term>
	///// </item>
	///// <item>
	///// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	///// <term>Not enough memory is available to process this request and allocate memory for the query results.</term>
	///// </item>
	///// </list>
	///// </returns>
	//[PInvokeData("wlanapi.h", MSDNShortId = "7f817edf-1b1d-495c-afd9-d97e3ae0caab")]
	//public static Win32Error WlanEnumInterfaces(HWLANSESSION hClientHandle, out WLAN_INTERFACE_INFO[] ppInterfaceList)
	//{
	//	var ret = WlanEnumInterfaces(hClientHandle, default, out var mem);
	//	ppInterfaceList = ret.Succeeded ? mem.DangerousGetHandle().ToStructure<WLAN_INTERFACE_INFO_LIST>().InterfaceInfo : null;
	//	mem?.Dispose();
	//	return ret;
	//}

	/// <summary>Provides a <see cref="SafeHandle"/> for WLAN API memory that is disposed using <see cref="WlanFreeMemory"/>.</summary>
	[AutoSafeHandle("{ WlanFreeMemory(handle); return true; }")]
	public partial class SafeHWLANMEM { }

	internal class WlanMarshaler<T> : ICustomMarshaler
	{
		private WlanMarshaler(string _)
		{
		}

		/// <summary>Gets the instance.</summary>
		/// <param name="cookie">The cookie.</param>
		/// <returns></returns>
		public static ICustomMarshaler GetInstance(string cookie) => new WlanMarshaler<T>(cookie);

		void ICustomMarshaler.CleanUpManagedData(object ManagedObj) => throw new NotImplementedException();

		void ICustomMarshaler.CleanUpNativeData(IntPtr pNativeData) => WlanFreeMemory(pNativeData);

		int ICustomMarshaler.GetNativeDataSize() => -1;

		IntPtr ICustomMarshaler.MarshalManagedToNative(object ManagedObj) => throw new NotImplementedException();

		object ICustomMarshaler.MarshalNativeToManaged(IntPtr pNativeData) => typeof(T) == typeof(string) ? StringHelper.GetString(pNativeData, CharSet.Unicode)! :
			(object)pNativeData.ToStructure<T>()!;
	}
}