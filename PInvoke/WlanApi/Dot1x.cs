namespace Vanara.PInvoke;

public static partial class WlanApi
{
	/// <summary>
	/// The <c>ONEX_AUTH_IDENTITY</c> enumerated type specifies the possible values of the identity used for 802.1X authentication status.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>ONEX_AUTH_IDENTITY</c> enumerated type is used by the 802.1X module, a new wireless configuration component supported on
	/// Windows Vista and later.
	/// </para>
	/// <para>
	/// The <c>ONEX_AUTH_IDENTITY</c> specifies the possible values of the identity used for 802.1X authentication. The
	/// <c>ONEX_AUTH_IDENTITY</c> is a function of the 802.1X authentication mode selected and various system triggers (user logon and
	/// logoff operations, for example).
	/// </para>
	/// <para>
	/// The ONEX_RESULT_UPDATE_DATA contains information on a status change to 802.1X authentication. The <c>ONEX_RESULT_UPDATE_DATA</c>
	/// structure is returned when the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure is
	/// <c>WLAN_NOTIFICATION_SOURCE_ONEX</c> and the <c>NotificationCode</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure for
	/// received notification is <c>OneXNotificationTypeResultUpdate</c>. For this notification, the <c>pData</c> member of the
	/// <c>WLAN_NOTIFICATION_DATA</c> structure points to an <c>ONEX_RESULT_UPDATE_DATA</c> structure that contains information on the
	/// 802.1X authentication status change.
	/// </para>
	/// <para>
	/// If the <c>fOneXAuthParams</c> member in the ONEX_RESULT_UPDATE_DATA structure is set, then the <c>authParams</c> member of the
	/// <c>ONEX_RESULT_UPDATE_DATA</c> structure contains an ONEX_VARIABLE_BLOB structure with an ONEX_AUTH_PARAMS structure embedded
	/// starting at the <c>dwOffset</c> member of the <c>ONEX_VARIABLE_BLOB</c>. This <c>ONEX_AUTH_PARAMS</c> structure that contains a
	/// value from the <c>ONEX_AUTH_IDENTITY</c> enumeration in the <c>authIdentity</c> member.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dot1x/ne-dot1x-onex_auth_identity typedef enum _ONEX_AUTH_IDENTITY {
	// OneXAuthIdentityNone, OneXAuthIdentityMachine, OneXAuthIdentityUser, OneXAuthIdentityExplicitUser, OneXAuthIdentityGuest,
	// OneXAuthIdentityInvalid } ONEX_AUTH_IDENTITY, PONEX_AUTH_IDENTITY;
	[PInvokeData("dot1x.h", MSDNShortId = "c51ab620-7e44-4798-8206-8ae9bbcd6614")]
	public enum ONEX_AUTH_IDENTITY
	{
		/// <summary>No identity is specified in the profile used for 802.1X authentication.</summary>
		OneXAuthIdentityNone,

		/// <summary>The identity of the local machine account is used for 802.1X authentication.</summary>
		OneXAuthIdentityMachine,

		/// <summary>The identity of the logged-on user is used for 802.1X authentication.</summary>
		OneXAuthIdentityUser,

		/// <summary>
		/// The identity of an explicit user as specified in the profile is used for 802.1X authentication. This value is used when
		/// performing single signon or when credentials are saved with the profile.
		/// </summary>
		OneXAuthIdentityExplicitUser,

		/// <summary>The identity of the Guest account as specified in the profile is used for 802.1X authentication.</summary>
		OneXAuthIdentityGuest,

		/// <summary>The identity is not valid as specified in the profile used for 802.1X authentication.</summary>
		OneXAuthIdentityInvalid,
	}

	/// <summary>
	/// The authMode element in the 802.1X schema that specifies the type of credentials used for 802.1X authentication. For more
	/// information, see the authMode (OneX) Element in the 802.1X scheme.
	/// </summary>
	[PInvokeData("", MSDNShortId = "ec494c74-bc79-445a-8889-a6f441e95ac5")]
	public enum ONEX_AUTH_MODE
	{
		/// <summary>
		/// Use machine or user credentials. When a user is logged on, the user's credentials are used for authentication. When no user
		/// is logged on, machine credentials are used.
		/// </summary>
		OneXAuthModeMachineOrUser = 0,

		/// <summary>Use machine credentials only.</summary>
		OneXAuthModeMachineOnly = 1,

		/// <summary>Use user credentials only.</summary>
		OneXAuthModeUserOnly = 2,

		/// <summary>Use guest (empty) credentials only.</summary>
		OneXAuthModeGuest = 3,

		/// <summary>Credentials to use are not specified.</summary>
		OneXAuthModeUnspecified = 4,
	}

	/// <summary>
	/// The <c>ONEX_AUTH_RESTART_REASON</c> enumerated type specifies the possible reasons that 802.1X authentication was restarted.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>ONEX_AUTH_RESTART_REASON</c> enumerated type is used by the 802.1X module, a new wireless configuration component
	/// supported on Windows Vista and later.
	/// </para>
	/// <para>
	/// The <c>ONEX_AUTH_RESTART_REASON</c> specifies the possible values for the reason that 802.1X authentication was restarted. A
	/// value from this enumeration is returned when the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure is
	/// <c>WLAN_NOTIFICATION_SOURCE_ONEX</c> and the <c>NotificationCode</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure for
	/// received notifications is <c>OneXNotificationTypeAuthRestarted</c>. For this notification, the <c>pData</c> member of the
	/// <c>WLAN_NOTIFICATION_DATA</c> structure points to an <c>ONEX_AUTH_RESTART_REASON</c> enumeration value that identifies the
	/// reason the authentication was restarted.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dot1x/ne-dot1x-onex_auth_restart_reason typedef enum _ONEX_AUTH_RESTART_REASON
	// { OneXRestartReasonPeerInitiated, OneXRestartReasonMsmInitiated, OneXRestartReasonOneXHeldStateTimeout,
	// OneXRestartReasonOneXAuthTimeout, OneXRestartReasonOneXConfigurationChanged, OneXRestartReasonOneXUserChanged,
	// OneXRestartReasonQuarantineStateChanged, OneXRestartReasonAltCredsTrial, OneXRestartReasonInvalid } ONEX_AUTH_RESTART_REASON, PONEX_AUTH_RESTART_REASON;
	[PInvokeData("dot1x.h", MSDNShortId = "794231da-ef4e-4419-9ff8-9b23483853d1")]
	public enum ONEX_AUTH_RESTART_REASON
	{
		/// <summary>
		/// The EAPHost component (the peer) requested the 802.1x module to restart 802.1X authentication. This results from a
		/// EapHostPeerProcessReceivedPacket function call that returns an EapHostPeerResponseAction enumeration value of
		/// EapHostPeerResponseStartAuthentication in the pEapOutput parameter.
		/// </summary>
		OneXRestartReasonPeerInitiated,

		/// <summary>The Media Specific Module (MSM) initiated the 802.1X authentication restart.</summary>
		OneXRestartReasonMsmInitiated,

		/// <summary>
		/// The 802.1X authentication restart was the result of a state timeout. The timer expiring is the heldWhile timer of the 802.1X
		/// supplicant state machine defined in IEEE 802.1X - 2004 standard for Port-Based Network Access Control. The heldWhile timer
		/// is used by the supplicant state machine to define periods of time during which itwill not attempt to acquire an authenticator.
		/// </summary>
		OneXRestartReasonOneXHeldStateTimeout,

		/// <summary>
		/// The 802.1X authentication restart was the result of an state timeout. The timer expiring is the authWhile timer of the
		/// 802.1X supplicant port access entity defined in IEEE 802.1X - 2004 standard for Port-Based Network Access Control. The
		/// authWhile timer is used by the supplicant port access entity to determine how long to wait for a request fromthe
		/// authenticator before timing it out.
		/// </summary>
		OneXRestartReasonOneXAuthTimeout,

		/// <summary>The 802.1X authentication restart was the result of a configuration change to the current profile.</summary>
		OneXRestartReasonOneXConfigurationChanged,

		/// <summary>
		/// The 802.1X authentication restart was the result of a change of user. This could occur if the current user logs off and new
		/// user logs on to the local computer.
		/// </summary>
		OneXRestartReasonOneXUserChanged,

		/// <summary>
		/// The 802.1X authentication restart was the result of receiving a notification from the EAP quarantine enforcement client
		/// (QEC) due to a network health change. If an EAPHost supplicant is participating in network access protection (NAP), the
		/// supplicant will respond to changes in the state of its network health. If that state changes, the supplicant must then
		/// initiate a re-authentication session. For more information, see the EapHostPeerBeginSession function.
		/// </summary>
		OneXRestartReasonQuarantineStateChanged,

		/// <summary>
		/// The 802.1X authentication restart was caused by a new authentication attempt with alternate user credentials. EAP methods
		/// like MSCHAPv2 prefer to use logged-on user credentials for 802.1X authentication. If these user credentials do not work,
		/// then a dialog will be displayed to the user that asks permission to use alternate credentials for 802.1X authentication. For
		/// more information, see the EapHostPeerBeginSession function and EAP_FLAG_PREFER_ALT_CREDENTIALS flag in the dwflags parameter.
		/// </summary>
		OneXRestartReasonAltCredsTrial,

		/// <summary>Indicates the end of the range that specifies the possible reasons that 802.1X authentication was restarted.</summary>
		OneXRestartReasonInvalid,
	}

	/// <summary>The <c>ONEX_AUTH_STATUS</c> enumerated type specifies the possible values for the 802.1X authentication status.</summary>
	/// <remarks>
	/// <para>
	/// The <c>ONEX_AUTH_STATUS</c> enumerated type is used by the 802.1X module, a new wireless configuration component supported on
	/// Windows Vista and later.
	/// </para>
	/// <para>
	/// The <c>ONEX_AUTH_STATUS</c> specifies the possible values for the 802.1X authentication status. A value from this enumeration is
	/// returned when the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure is
	/// <c>WLAN_NOTIFICATION_SOURCE_ONEX</c> and the <c>NotificationCode</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure for
	/// received notifications is <c>OneXNotificationTypeResultUpdate</c>. For this notification, the <c>pData</c> member of the
	/// <c>WLAN_NOTIFICATION_DATA</c> structure points to an ONEX_RESULT_UPDATE_DATA structure that contains a ONEX_STATUS structure
	/// member in the <c>oneXStatus</c> structure member. The <c>ONEX_STATUS</c> structure contains a <c>ONEX_AUTH_STATUS</c>
	/// enumeration value in the <c>authStatus</c> member.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dot1x/ne-dot1x-onex_auth_status typedef enum _ONEX_AUTH_STATUS {
	// OneXAuthNotStarted, OneXAuthInProgress, OneXAuthNoAuthenticatorFound, OneXAuthSuccess, OneXAuthFailure, OneXAuthInvalid }
	// ONEX_AUTH_STATUS, PONEX_AUTH_STATUS;
	[PInvokeData("dot1x.h", MSDNShortId = "9a5c7876-2c6b-450e-95e4-2766d63b6e19")]
	public enum ONEX_AUTH_STATUS
	{
		/// <summary>802.1X authentication was not started.</summary>
		OneXAuthNotStarted,

		/// <summary>802.1X authentication is in progress.</summary>
		OneXAuthInProgress,

		/// <summary>
		/// No 802.1X authenticator was found. The 802.1X authentication was attempted, but no 802.1X peer was found. In this case,
		/// either the network does not support or is not configured to support the 802.1X standard.
		/// </summary>
		OneXAuthNoAuthenticatorFound,

		/// <summary>802.1X authentication was successful.</summary>
		OneXAuthSuccess,

		/// <summary>802.1X authentication was a failure.</summary>
		OneXAuthFailure,

		/// <summary>Indicates the end of the range that specifies the possible values for 802.1X authentication status.</summary>
		OneXAuthInvalid,
	}

	/// <summary>
	/// The <c>ONEX_EAP_METHOD_BACKEND_SUPPORT</c> enumerated type specifies the possible values for whether the EAP method configured
	/// on the supplicant for 802.1X authentication is supported on the authentication server.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>ONEX_EAP_METHOD_BACKEND_SUPPORT</c> enumeration is used by the 802.1X module, a new wireless configuration component
	/// supported on Windows Vista and later.
	/// </para>
	/// <para>
	/// The ONEX_RESULT_UPDATE_DATA contains information on a status change to 802.1X authentication. The <c>ONEX_RESULT_UPDATE_DATA</c>
	/// structure is returned when the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure is
	/// <c>WLAN_NOTIFICATION_SOURCE_ONEX</c> and the <c>NotificationCode</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure for
	/// received notification is <c>OneXNotificationTypeResultUpdate</c>. For this notification, the <c>pData</c> member of the
	/// <c>WLAN_NOTIFICATION_DATA</c> structure points to an <c>ONEX_RESULT_UPDATE_DATA</c> structure that contains information on the
	/// 802.1X authentication status change.
	/// </para>
	/// <para>
	/// The <c>BackendSupport</c> member of the ONEX_RESULT_UPDATE_DATA struct contains a value from the
	/// <c>ONEX_EAP_METHOD_BACKEND_SUPPORT</c> enumeration.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dot1x/ne-dot1x-onex_eap_method_backend_support typedef enum
	// _ONEX_EAP_METHOD_BACKEND_SUPPORT { OneXEapMethodBackendSupportUnknown, OneXEapMethodBackendSupported,
	// OneXEapMethodBackendUnsupported } ONEX_EAP_METHOD_BACKEND_SUPPORT;
	[PInvokeData("dot1x.h", MSDNShortId = "ae0c30c3-331e-4b57-aa5f-f6b1f73dc69d")]
	public enum ONEX_EAP_METHOD_BACKEND_SUPPORT
	{
		/// <summary>
		/// It is not known whether the EAP method configured on the supplicant for 802.1X authentication is supported on the
		/// authentication server. This value can be returned if the 802.1X authentication process is in the initial state.
		/// </summary>
		OneXEapMethodBackendSupportUnknown,

		/// <summary>
		/// The EAP method configured on the supplicant for 802.1X authentication is supported on the authentication server. The 802.1X
		/// handshake is used to decide what is an acceptable EAP method to use.
		/// </summary>
		OneXEapMethodBackendSupported,

		/// <summary>
		/// The EAP method configured on the supplicant for 802.1X authentication is not supported on the authentication server.
		/// </summary>
		OneXEapMethodBackendUnsupported,
	}

	/// <summary>
	/// The <c>ONEX_NOTIFICATION_TYPE</c> enumerated type specifies the possible values of the <c>NotificationCode</c> member of the
	/// WLAN_NOTIFICATION_DATA structure for 802.1X module notifications.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>ONEX_NOTIFICATION_TYPE</c> enumerated type is used by the 802.1X module, a new wireless configuration component supported
	/// on Windows Vista and later.
	/// </para>
	/// <para>
	/// The <c>ONEX_NOTIFICATION_TYPE</c> specifies the possible values for the <c>NotificationCode</c> member of the
	/// WLAN_NOTIFICATION_DATA structure for received notifications when the <c>NotificationSource</c> member of the
	/// <c>WLAN_NOTIFICATION_DATA</c> structure is <c>WLAN_NOTIFICATION_SOURCE_ONEX</c>.
	/// </para>
	/// <para>
	/// The WlanRegisterNotification function is used by an application to register and unregister notifications on all wireless
	/// interfaces. When registering for notifications, an application must provide a callback function pointed to by the funcCallback
	/// parameter passed to the <c>WlanRegisterNotification</c> function. The prototype for this callback function is the
	/// WLAN_NOTIFICATION_CALLBACK. This callback function will receive notifications that have been registered in the dwNotifSource
	/// parameter passed to the <c>WlanRegisterNotification</c> function.
	/// </para>
	/// <para>
	/// The callback function is called with a pointer to a WLAN_NOTIFICATION_DATA structure as the first parameter that contains
	/// detailed information on the notification. The callback function also receives a second parameter that contains a pointer to the
	/// client context passed in the pCallbackContext parameter to the WlanRegisterNotification function. This client context can be a
	/// <c>NULL</c> pointer if that is what was passed to the <c>WlanRegisterNotification</c> function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dot1x/ne-dot1x-onex_notification_type typedef enum _ONEX_NOTIFICATION_TYPE {
	// OneXPublicNotificationBase, OneXNotificationTypeResultUpdate, OneXNotificationTypeAuthRestarted,
	// OneXNotificationTypeEventInvalid, OneXNumNotifications } ONEX_NOTIFICATION_TYPE, PONEX_NOTIFICATION_TYPE;
	[PInvokeData("dot1x.h", MSDNShortId = "c5892938-9798-4c09-a766-4924cda4d090")]
	public enum ONEX_NOTIFICATION_TYPE : uint
	{
		/// <summary>Indicates the beginning of the range that specifies the possible values for 802.1X notifications.</summary>
		OneXPublicNotificationBase,

		/// <summary>
		/// Indicates that 802.1X authentication has a status change.The pData member of the WLAN_NOTIFICATION_DATA structure points to
		/// a ONEX_RESULT_UPDATE_DATA structure that contains 802.1X update data.
		/// </summary>
		OneXNotificationTypeResultUpdate,

		/// <summary>
		/// Indicates that 802.1X authentication restarted.The pData member of the WLAN_NOTIFICATION_DATA structure points to an
		/// ONEX_AUTH_RESTART_REASON enumeration value that identifies the reason the authentication was restarted.
		/// </summary>
		OneXNotificationTypeAuthRestarted,

		/// <summary>Indicates the end of the range that specifies the possible values for 802.1X notifications.</summary>
		OneXNotificationTypeEventInvalid,

		/// <summary>Indicates the end of the range that specifies the possible values for 802.1X notifications.</summary>
		OneXNumNotifications,
	}

	/// <summary>
	/// The <c>ONEX_REASON_CODE</c> enumerated type specifies the possible values that indicate the reason that 802.1X authentication failed.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>ONEX_REASON_CODE</c> enumerated type is used by the 802.1X module, a new wireless configuration component supported on
	/// Windows Vista and later.
	/// </para>
	/// <para>
	/// The ONEX_RESULT_UPDATE_DATA contains information on a status change to 802.1X authentication. The <c>ONEX_RESULT_UPDATE_DATA</c>
	/// structure is returned when the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure is
	/// <c>WLAN_NOTIFICATION_SOURCE_ONEX</c> and the <c>NotificationCode</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure for
	/// received notification is <c>OneXNotificationTypeResultUpdate</c>. For this notification, the <c>pData</c> member of the
	/// <c>WLAN_NOTIFICATION_DATA</c> structure points to an <c>ONEX_RESULT_UPDATE_DATA</c> structure that contains information on the
	/// 802.1X authentication status change.
	/// </para>
	/// <para>
	/// The <c>oneXStatus</c> member of the ONEX_RESULT_UPDATE_DATA structure contains an ONEX_STATUS structure. If an error occurred
	/// during 802.1X authentication, the dwReason menber of this <c>ONEX_STATUS</c> structure contains the reason for the error
	/// specified as a value from the <c>ONEX_REASON_CODE</c> enumeration.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dot1x/ne-dot1x-onex_reason_code typedef enum _ONEX_REASON_CODE {
	// ONEX_REASON_CODE_SUCCESS, ONEX_REASON_START, ONEX_UNABLE_TO_IDENTIFY_USER, ONEX_IDENTITY_NOT_FOUND, ONEX_UI_DISABLED,
	// ONEX_UI_FAILURE, ONEX_EAP_FAILURE_RECEIVED, ONEX_AUTHENTICATOR_NO_LONGER_PRESENT, ONEX_NO_RESPONSE_TO_IDENTITY,
	// ONEX_PROFILE_VERSION_NOT_SUPPORTED, ONEX_PROFILE_INVALID_LENGTH, ONEX_PROFILE_DISALLOWED_EAP_TYPE,
	// ONEX_PROFILE_INVALID_EAP_TYPE_OR_FLAG, ONEX_PROFILE_INVALID_ONEX_FLAGS, ONEX_PROFILE_INVALID_TIMER_VALUE,
	// ONEX_PROFILE_INVALID_SUPPLICANT_MODE, ONEX_PROFILE_INVALID_AUTH_MODE, ONEX_PROFILE_INVALID_EAP_CONNECTION_PROPERTIES,
	// ONEX_UI_CANCELLED, ONEX_PROFILE_INVALID_EXPLICIT_CREDENTIALS, ONEX_PROFILE_EXPIRED_EXPLICIT_CREDENTIALS, ONEX_UI_NOT_PERMITTED }
	// ONEX_REASON_CODE, PONEX_REASON_CODE;
	[PInvokeData("dot1x.h", MSDNShortId = "9ce6ff56-946c-4058-b9a6-33dab4124c24")]
	public enum ONEX_REASON_CODE
	{
		/// <summary>Indicates the 802.1X authentication was a success.</summary>
		ONEX_REASON_CODE_SUCCESS,

		/// <summary>Indicates the start of the range that specifies the possible values for 802.1X reason code.</summary>
		ONEX_REASON_START,

		/// <summary>
		/// The 802.1X module was unable to identify a set of credentials to be used. An example is when the authentication mode is set
		/// to user, but no user is logged on.
		/// </summary>
		ONEX_UNABLE_TO_IDENTIFY_USER,

		/// <summary>
		/// The EAP module was unable to acquire an identity for the user. Thus value is not currently used. All EAP-specific errors are
		/// returned as ONEX_EAP_FAILURE_RECEIVED.
		/// </summary>
		ONEX_IDENTITY_NOT_FOUND,

		/// <summary>
		/// To proceed with 802.1X authentication, the system needs to request user input, but the user interface is disabled. On
		/// Windows Vista and on Windows Server 2008, this value can be returned if an EAP method requested user input for a profile for
		/// Guest or local machine authentication. On Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed,
		/// this value should not be returned.
		/// </summary>
		ONEX_UI_DISABLED,

		/// <summary>
		/// The 802.1X authentication module was unable to return the requested user input. On Windows 7 and on Windows Server 2008 R2
		/// with the Wireless LAN Service installed, this value can be returned if an EAP method requested user input, but the UI could
		/// not be displayed (the network icon was configured to not show in the taskbar, for example).
		/// </summary>
		ONEX_UI_FAILURE,

		/// <summary>
		/// The EAP module returned an error code. The ONEX_EAP_ERROR structure may contain additional information about the specific
		/// EAP error (a certificate not found, for example).
		/// </summary>
		ONEX_EAP_FAILURE_RECEIVED,

		/// <summary>
		/// The peer with which the 802.1X module was negotiating is no longer present or is not responding (a laptop client moved out
		/// of range of the wireless access point, for example).
		/// </summary>
		ONEX_AUTHENTICATOR_NO_LONGER_PRESENT,

		/// <summary>
		/// No response was received to an EAP identity response packet. This value indicates a problem with the infrastructure (a link
		/// between the wireless access point and the authentication server is not functioning, for example).
		/// </summary>
		ONEX_NO_RESPONSE_TO_IDENTITY,

		/// <summary>The 802.1X module does not support this version of the profile.</summary>
		ONEX_PROFILE_VERSION_NOT_SUPPORTED,

		/// <summary>The length member specified in the 802.1X profile is invalid.</summary>
		ONEX_PROFILE_INVALID_LENGTH,

		/// <summary>
		/// The EAP type specified in the 802.1X profile is not allowed for this media. An example is when the keyed MD5 algorithm is
		/// used for wireless transmission.
		/// </summary>
		ONEX_PROFILE_DISALLOWED_EAP_TYPE,

		/// <summary>
		/// The EAP type or EAP flags specified in the 802.1X profile are not valid. An example is when EAP type is not installed on the system.
		/// </summary>
		ONEX_PROFILE_INVALID_EAP_TYPE_OR_FLAG,

		/// <summary>The 802.1X flags specified in the 802.1X profile are not valid.</summary>
		ONEX_PROFILE_INVALID_ONEX_FLAGS,

		/// <summary>One or more timer values specified in the 802.1X profile is out of its valid range.</summary>
		ONEX_PROFILE_INVALID_TIMER_VALUE,

		/// <summary>The supplicant mode specified in the 802.1X profile is not valid.</summary>
		ONEX_PROFILE_INVALID_SUPPLICANT_MODE,

		/// <summary>The authentication mode specified in the 802.1X profile is not valid.</summary>
		ONEX_PROFILE_INVALID_AUTH_MODE,

		/// <summary>The EAP connection properties specified in the 802.1X profile are not valid.</summary>
		ONEX_PROFILE_INVALID_EAP_CONNECTION_PROPERTIES,

		/// <summary>
		/// User input was canceled. This value can be returned if an EAP method requested user input, but the user hit the Cancel
		/// button or dismissed the user input dialog.This value is supported on Windows 7 and on Windows Server 2008 R2 with the
		/// Wireless LAN Service installed.
		/// </summary>
		ONEX_UI_CANCELLED,

		/// <summary>
		/// The saved user credentials are not valid. This value can be returned if a profile was saved with bad credentials (an
		/// incorrect password, for example), since the credentials are not tested until the profile is actually used to establish a
		/// connection. This value is supported on Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.
		/// </summary>
		ONEX_PROFILE_INVALID_EXPLICIT_CREDENTIALS,

		/// <summary>
		/// The saved user credentials have expired. This value can be returned if a profile was saved with credentials and the
		/// credentials subsequently expired (password expirarion after some period of time, for example).This value is supported on
		/// Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.
		/// </summary>
		ONEX_PROFILE_EXPIRED_EXPLICIT_CREDENTIALS,

		/// <summary>
		/// User interface is not permitted. On Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed, this
		/// value can be returned if an EAP method requested user input and the profile is configured with user credentials saved by
		/// another user and not the currently logged in user.This value is supported on Windows 7 and on Windows Server 2008 R2 with
		/// the Wireless LAN Service installed.
		/// </summary>
		ONEX_UI_NOT_PERMITTED,
	}

	/// <summary>
	/// The supplicantMode element in the 802.1X schema that specifies the method of transmission used for EAPOL-Start messages. For
	/// more information, see the supplicantMode (OneX) Element in the 802.1X scheme.
	/// </summary>
	[PInvokeData("", MSDNShortId = "ec494c74-bc79-445a-8889-a6f441e95ac5")]
	public enum ONEX_SUPPLICANT_MODE
	{
		/// <summary>EAPOL-Start messages are not transmitted. Valid for wired LAN profiles only.</summary>
		OneXSupplicantModeInhibitTransmission = 0,

		/// <summary>
		/// The client determines when to send EAPOL-Start packets based on network capability. EAPOL-Start messages are only sent when
		/// required. Valid for wired LAN profiles only.
		/// </summary>
		OneXSupplicantModeLearn = 1,

		/// <summary>EAPOL-Start messages are transmitted as specified by 802.1X. Valid for both wired and wireless LAN profiles.</summary>
		OneXSupplicantModeCompliant = 2,
	}

	/// <summary>The <c>ONEX_AUTH_PARAMS</c> structure contains 802.1X authentication parameters used for 802.1X authentication.</summary>
	/// <remarks>
	/// <para>
	/// The <c>ONEX_AUTH_PARAMS</c> structure is used by the 802.1X module, a new wireless configuration component supported on Windows
	/// Vista and later.
	/// </para>
	/// <para>
	/// The ONEX_RESULT_UPDATE_DATA contains information on a status change to 802.1X authentication. The <c>ONEX_RESULT_UPDATE_DATA</c>
	/// structure is returned when the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure is
	/// <c>WLAN_NOTIFICATION_SOURCE_ONEX</c> and the <c>NotificationCode</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure for
	/// received notification is <c>OneXNotificationTypeResultUpdate</c>. For this notification, the <c>pData</c> member of the
	/// <c>WLAN_NOTIFICATION_DATA</c> structure points to an <c>ONEX_RESULT_UPDATE_DATA</c> structure that contains information on the
	/// 802.1X authentication status change.
	/// </para>
	/// <para>
	/// If the <c>fOneXAuthParams</c> member in the ONEX_RESULT_UPDATE_DATA structure is set, then the <c>authParams</c> member of the
	/// <c>ONEX_RESULT_UPDATE_DATA</c> structure contains an ONEX_VARIABLE_BLOB structure with an <c>ONEX_AUTH_PARAMS</c> structure
	/// embedded starting at the <c>dwOffset</c> member of the <c>ONEX_VARIABLE_BLOB</c>.
	/// </para>
	/// <para>
	/// For security reasons, the <c>hUserToken</c> and <c>OneXUserProfile</c> members of the <c>ONEX_AUTH_PARAMS</c> structure returned
	/// in the <c>authParams</c> member are always set to <c>NULL</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dot1x/ns-dot1x-onex_auth_params typedef struct _ONEX_AUTH_PARAMS { BOOL
	// fUpdatePending; ONEX_VARIABLE_BLOB oneXConnProfile; ONEX_AUTH_IDENTITY authIdentity; DWORD dwQuarantineState; DWORD fSessionId :
	// 1; DWORD fhUserToken : 1; DWORD fOnexUserProfile : 1; DWORD fIdentity : 1; DWORD fUserName : 1; DWORD fDomain : 1; DWORD
	// dwSessionId; HANDLE hUserToken; ONEX_VARIABLE_BLOB OneXUserProfile; ONEX_VARIABLE_BLOB Identity; ONEX_VARIABLE_BLOB UserName;
	// ONEX_VARIABLE_BLOB Domain; } ONEX_AUTH_PARAMS, *PONEX_AUTH_PARAMS;
	[PInvokeData("dot1x.h", MSDNShortId = "a5dcd546-abe5-4553-baa8-656d37b263a3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ONEX_AUTH_PARAMS
	{
		/// <summary>Indicates if a status update is pending for 802.X authentication.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fUpdatePending;

		/// <summary>
		/// The 802.1X authentication connection profile. This member contains an embedded ONEX_CONNECTION_PROFILE structure starting at
		/// the <c>dwOffset</c> member of the ONEX_VARIABLE_BLOB.
		/// </summary>
		public ONEX_VARIABLE_BLOB oneXConnProfile;

		/// <summary>The identity used for 802.1X authentication status. This member is a value from the ONEX_AUTH_IDENTITY enumeration.</summary>
		public ONEX_AUTH_IDENTITY authIdentity;

		/// <summary>
		/// The quarantine isolation state value of the local computer. The isolation state determines its network connectivity. This
		/// member corresponds to a value from the EAPHost ISOLATION_STATE enumeration.
		/// </summary>
		public uint dwQuarantineState;

		private uint flags;

		/// <summary>Indicates if the <c>ONEX_AUTH_PARAMS</c> structure contains a session ID in the <c>dwSessionId</c> member.</summary>
		public bool fSessionId { get => BitHelper.GetBit(flags, 0); set => BitHelper.SetBit(ref flags, 0, value); }

		/// <summary>
		/// <para>Indicates if the <c>ONEX_AUTH_PARAMS</c> structure contains a user token handle in the <c>hUserToken</c> member.</para>
		/// <para>
		/// For security reasons, the <c>hUserToken</c> member of the <c>ONEX_AUTH_PARAMS</c> structure returned in the
		/// <c>authParams</c> member of the ONEX_RESULT_UPDATE_DATA structure is always set to <c>NULL</c>.
		/// </para>
		/// </summary>
		public bool fhUserToken { get => BitHelper.GetBit(flags, 1); set => BitHelper.SetBit(ref flags, 1, value); }

		/// <summary>
		/// <para>Indicates if the <c>ONEX_AUTH_PARAMS</c> structure contains an 802.1X user profile in the <c>OneXUserProfile</c> member.</para>
		/// <para>
		/// For security reasons, the <c>OneXUserProfile</c> member of the <c>ONEX_AUTH_PARAMS</c> structure returned in the
		/// <c>authParams</c> member of the ONEX_RESULT_UPDATE_DATA structure is always set to <c>NULL</c>.
		/// </para>
		/// </summary>
		public bool fOnexUserProfile { get => BitHelper.GetBit(flags, 2); set => BitHelper.SetBit(ref flags, 2, value); }

		/// <summary>Indicates if the <c>ONEX_AUTH_PARAMS</c> structure contains an 802.1X identity in the <c>Identity</c> member.</summary>
		public bool fIdentity { get => BitHelper.GetBit(flags, 3); set => BitHelper.SetBit(ref flags, 3, value); }

		/// <summary>
		/// Indicates if the <c>ONEX_AUTH_PARAMS</c> structure contains a user name used for 802.1X authentication in the
		/// <c>UserName</c> member.
		/// </summary>
		public bool fUserName { get => BitHelper.GetBit(flags, 4); set => BitHelper.SetBit(ref flags, 4, value); }

		/// <summary>
		/// Indicates if the <c>ONEX_AUTH_PARAMS</c> structure contains a domain used for 802.1X authentication in the <c>Domain</c> member.
		/// </summary>
		public bool fDomain { get => BitHelper.GetBit(flags, 5); set => BitHelper.SetBit(ref flags, 5, value); }

		/// <summary>
		/// The session ID of the user currently logged on to the console. This member corresponds to the value returned by the
		/// WTSGetActiveConsoleSessionId function. This member contains a session ID if the <c>fSessionId</c> bitfield member is set.
		/// </summary>
		public uint dwSessionId;

		/// <summary>
		/// <para>
		/// The user token handle used for 802.1X authentication. This member contains a user token handle if the <c>fhUserToken</c>
		/// bitfield member is set.
		/// </para>
		/// <para>
		/// For security reasons, the <c>hUserToken</c> member of the <c>ONEX_AUTH_PARAMS</c> structure returned in the
		/// <c>authParams</c> member of the ONEX_RESULT_UPDATE_DATA structure is always set to <c>NULL</c>.
		/// </para>
		/// </summary>
		public IntPtr hUserToken;

		/// <summary>
		/// <para>
		/// The 802.1X user profile used for 802.1X authentication. This member contains an embedded user profile starting at the
		/// <c>dwOffset</c> member of the ONEX_VARIABLE_BLOB if the <c>fOneXUserProfile</c> bitfield member is set.
		/// </para>
		/// <para>
		/// For security reasons, the <c>OneXUserProfile</c> member of the <c>ONEX_AUTH_PARAMS</c> structure returned in the
		/// <c>authParams</c> member of the ONEX_RESULT_UPDATE_DATA structure is always set to <c>NULL</c>.
		/// </para>
		/// </summary>
		public ONEX_VARIABLE_BLOB OneXUserProfile;

		/// <summary>
		/// The 802.1X identity used for 802.1X authentication. This member contains a NULL-terminated Unicode string with the identity
		/// starting at the <c>dwOffset</c> member of the ONEX_VARIABLE_BLOB if the <c>fIdentity</c> bitfield member is set.
		/// </summary>
		public ONEX_VARIABLE_BLOB Identity;

		/// <summary>
		/// The user name used for 802.1X authentication. This member contains a NULL-terminated Unicode string with the user name
		/// starting at the <c>dwOffset</c> member of the ONEX_VARIABLE_BLOB if the <c>fUserName</c> bitfield member is set.
		/// </summary>
		public ONEX_VARIABLE_BLOB UserName;

		/// <summary>
		/// The domain used for 802.1X authentication. This member contains a NULL-terminated Unicode string with the domain starting at
		/// the <c>dwOffset</c> member of the ONEX_VARIABLE_BLOB if the <c>fDomain</c> bitfield member is set.
		/// </summary>
		public ONEX_VARIABLE_BLOB Domain;
	}

	/// <summary>
	/// The <c>ONEX_CONNECTION_PROFILE</c> structure contains information on the 802.1X connection profile currently used for 802.1X authentication.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>ONEX_CONNECTION_PROFILE</c> structure is used by the 802.1X module, a new wireless configuration component supported on
	/// Windows Vista and later.
	/// </para>
	/// <para>
	/// The <c>ONEX_RESULT_UPDATE_DATA</c> contains information on a status change to 802.1X authentication. The
	/// <c>ONEX_RESULT_UPDATE_DATA</c> structure is returned when the <c>NotificationSource</c> member of the
	/// <c>WLAN_NOTIFICATION_DATA</c> structure is <c>WLAN_NOTIFICATION_SOURCE_ONEX</c> and the <c>NotificationCode</c> member of the
	/// <c>WLAN_NOTIFICATION_DATA</c> structure for received notification is <c>OneXNotificationTypeResultUpdate</c>. For this
	/// notification, the <c>pData</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure points to an <c>ONEX_RESULT_UPDATE_DATA</c>
	/// structure that contains information on the 802.1X authentication status change.
	/// </para>
	/// <para>
	/// If the <c>fOneXAuthParams</c> member in the <c>ONEX_RESULT_UPDATE_DATA</c> structure is set, then the <c>authParams</c> member
	/// of the <c>ONEX_RESULT_UPDATE_DATA</c> structure contains an <c>ONEX_VARIABLE_BLOB</c> structure with an <c>ONEX_AUTH_PARAMS</c>
	/// structure embedded starting at the <c>dwOffset</c> member of the <c>ONEX_VARIABLE_BLOB</c>. The <c>oneXConnProfile</c> member of
	/// the <c>ONEX_AUTH_PARAMS</c> structure contains an <c>ONEX_VARIABLE_BLOB</c> structure with an <c>ONEX_CONNECTION_PROFILE</c>
	/// structure embedded starting at the <c>dwOffset</c> member of the <c>ONEX_VARIABLE_BLOB</c>.
	/// </para>
	/// <para>The <c>ONEX_CONNECTION_PROFILE</c> structure is not defined in a public header file.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/nativewifi/onex-connection-profile typedef struct _ONEX_CONNECTION_PROFILE { DWORD
	// dwVersion; DWORD dwTotalLen; DWORD fOneXSupplicantFlags :1; DWORD fsupplicantMode :1; DWORD fauthMode :1; DWORD fHeldPeriod :1;
	// DWORD fAuthPeriod :1; DWORD fStartPeriod :1; DWORD fMaxStart :1; DWORD fMaxAuthFailures :1; DWORD fNetworkAuthTimeout :1; DWORD
	// fAllowLogonDialogs :1; DWORD fNetworkAuthWithUITimeout :1; DWORD fUserBasedVLan :1; DWORD dwOneXSupplicantFlags;
	// ONEX_SUPPLICANT_MODE supplicantMode; ONEX_AUTH_MODE authMode; DWORD dwHeldPeriod; DWORD dwAuthPeriod; DWORD dwStartPeriod; DWORD
	// dwMaxStart; DWORD dwMaxAuthFailures; DWORD dwNetworkAuthTimeout; DWORD dwNetworkAuthWithUITimeout; BOOL bAllowLogonDialogs; BOOL
	// bUserBasedVLan; } ONEX_CONNECTION_PROFILE, *PONEX_CONNECTION_PROFILE;
	[PInvokeData("dot1x.h", MSDNShortId = "ec494c74-bc79-445a-8889-a6f441e95ac5")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ONEX_CONNECTION_PROFILE
	{
		/// <summary>The version of this <c>ONEX_CONNECTION_PROFILE</c> structure.</summary>
		public uint dwVersion;

		/// <summary>The length, in bytes, of this <c>ONEX_CONNECTION_PROFILE</c> structure.</summary>
		public uint dwTotalLen;

		private uint flags;

		/// <summary>
		/// Indicates if the <c>ONEX_CONNECTION_PROFILE</c> structure contains valid data in the <c>dwOneXSupplicantFlags</c> member.
		/// </summary>
		public bool fOneXSupplicantFlags { get => BitHelper.GetBit(flags, 0); set => BitHelper.SetBit(ref flags, 0, value); }

		/// <summary>Indicates if the <c>ONEX_CONNECTION_PROFILE</c> structure contains valid data in the <c>supplicantMode</c> member.</summary>
		public bool fsupplicantMode { get => BitHelper.GetBit(flags, 1); set => BitHelper.SetBit(ref flags, 1, value); }

		/// <summary>Indicates if the <c>ONEX_CONNECTION_PROFILE</c> structure contains valid data in the <c>authMode</c> member.</summary>
		public bool fauthMode { get => BitHelper.GetBit(flags, 2); set => BitHelper.SetBit(ref flags, 2, value); }

		/// <summary>Indicates if the <c>ONEX_CONNECTION_PROFILE</c> structure contains valid data in the <c>dwHeldPeriod</c> member.</summary>
		public bool fHeldPeriod { get => BitHelper.GetBit(flags, 3); set => BitHelper.SetBit(ref flags, 3, value); }

		/// <summary>Indicates if the <c>ONEX_CONNECTION_PROFILE</c> structure contains valid data in the <c>dwAuthPeriod</c> member.</summary>
		public bool fAuthPeriod { get => BitHelper.GetBit(flags, 4); set => BitHelper.SetBit(ref flags, 4, value); }

		/// <summary>Indicates if the <c>ONEX_CONNECTION_PROFILE</c> structure contains valid data in the <c>dwStartPeriod</c> member.</summary>
		public bool fStartPeriod { get => BitHelper.GetBit(flags, 5); set => BitHelper.SetBit(ref flags, 5, value); }

		/// <summary>Indicates if the <c>ONEX_CONNECTION_PROFILE</c> structure contains valid data in the <c>dwMaxStart</c> member.</summary>
		public bool fMaxStart { get => BitHelper.GetBit(flags, 6); set => BitHelper.SetBit(ref flags, 6, value); }

		/// <summary>
		/// Indicates if the <c>ONEX_CONNECTION_PROFILE</c> structure contains valid data in the <c>dwMaxAuthFailures</c> member.
		/// </summary>
		public bool fMaxAuthFailures { get => BitHelper.GetBit(flags, 7); set => BitHelper.SetBit(ref flags, 7, value); }

		/// <summary>
		/// Indicates if the <c>ONEX_CONNECTION_PROFILE</c> structure contains valid data in the <c>dwNetworkAuthTimeout</c> member.
		/// </summary>
		public bool fNetworkAuthTimeout { get => BitHelper.GetBit(flags, 8); set => BitHelper.SetBit(ref flags, 8, value); }

		/// <summary>
		/// Indicates if the <c>ONEX_CONNECTION_PROFILE</c> structure contains valid data in the <c>bAllowLogonDialogs</c> member.
		/// </summary>
		public bool fAllowLogonDialogs { get => BitHelper.GetBit(flags, 9); set => BitHelper.SetBit(ref flags, 9, value); }

		/// <summary>
		/// Indicates if the <c>ONEX_CONNECTION_PROFILE</c> structure contains valid data in the <c>dwNetworkAuthWithUITimeout</c> member.
		/// </summary>
		public bool fNetworkAuthWithUITimeout { get => BitHelper.GetBit(flags, 10); set => BitHelper.SetBit(ref flags, 10, value); }

		/// <summary>Indicates if the <c>ONEX_CONNECTION_PROFILE</c> structure contains valid data in the <c>bUserBasedVLan</c> member.</summary>
		public bool fUserBasedVLan { get => BitHelper.GetBit(flags, 11); set => BitHelper.SetBit(ref flags, 11, value); }

		/// <summary>
		/// A set of 802.1X flags that can be present in the profile. These flags are reserved for internal use by the 802.1X
		/// authentication module.
		/// </summary>
		public uint dwOneXSupplicantFlags;

		/// <summary>
		/// <para>
		/// The supplicantMode element in the 802.1X schema that specifies the method of transmission used for EAPOL-Start messages. For
		/// more information, see the <c>supplicantMode (OneX) Element</c> in the 802.1X scheme.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OneXSupplicantModeInhibitTransmission 0</term>
		/// <term>EAPOL-Start messages are not transmitted. Valid for wired LAN profiles only.</term>
		/// </item>
		/// <item>
		/// <term>OneXSupplicantModeLearn 1</term>
		/// <term>
		/// The client determines when to send EAPOL-Start packets based on network capability. EAPOL-Start messages are only sent when
		/// required. Valid for wired LAN profiles only.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OneXSupplicantModeCompliant 2</term>
		/// <term>EAPOL-Start messages are transmitted as specified by 802.1X. Valid for both wired and wireless LAN profiles.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ONEX_SUPPLICANT_MODE supplicantMode;

		/// <summary>
		/// <para>
		/// The authMode element in the 802.1X schema that specifies the type of credentials used for 802.1X authentication. For more
		/// information, see the <c>authMode (OneX) Element</c> in the 802.1X scheme.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OneXAuthModeMachineOrUser 0</term>
		/// <term>
		/// Use machine or user credentials. When a user is logged on, the user's credentials are used for authentication. When no user
		/// is logged on, machine credentials are used.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OneXAuthModeMachineOnly 1</term>
		/// <term>Use machine credentials only.</term>
		/// </item>
		/// <item>
		/// <term>OneXAuthModeUserOnly 2</term>
		/// <term>Use user credentials only.</term>
		/// </item>
		/// <item>
		/// <term>OneXAuthModeGuest 3</term>
		/// <term>Use guest (empty) credentials only.</term>
		/// </item>
		/// <item>
		/// <term>OneXAuthModeUnspecified 4</term>
		/// <term>Credentials to use are not specified.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ONEX_AUTH_MODE authMode;

		/// <summary>
		/// The heldPeriod element in the 802.1X schema that specifies the length of time, in seconds, in which a client will not
		/// re-attempt authentication after a failed authentication attempt. For more information, see the <c>heldPeriod (OneX)
		/// Element</c> in the 802.1X scheme.
		/// </summary>
		public uint dwHeldPeriod;

		/// <summary>
		/// The authPeriod element in the 802.1X schema that specifies the maximum length of time, in seconds, in which a client waits
		/// for a response from the authenticator. If a response is not received within the specified period, the client assumes that
		/// there is no authenticator present on the network. For more information, see the <c>authPeriod (OneX) Element</c> in the
		/// 802.1X scheme.
		/// </summary>
		public uint dwAuthPeriod;

		/// <summary>
		/// The startPeriod element in the 802.1X schema that specifies the length of time, in seconds, to wait before an EAPOL-Start is
		/// sent. An EAPOL-Start message is sent to start the 802.1X authentication process. For more information, see the
		/// <c>startPeriod (OneX) Element</c> in the 802.1X scheme.
		/// </summary>
		public uint dwStartPeriod;

		/// <summary>
		/// The maxStart element in the 802.1X schema that specifies the maximum number of EAPOL-Start messages sent. After the maximum
		/// number of EAPOL-Start messages has been sent, the client assumes that there is no authenticator present on the network. For
		/// more information, see the <c>maxStart (OneX) Element</c> in the 802.1X scheme.
		/// </summary>
		public uint dwMaxStart;

		/// <summary>
		/// The maxAuthFailures element in the 802.1X schema that specifies the maximum number of authentication failures allowed for a
		/// set of credentials. For more information, see the <c>maxAuthFailures (OneX)</c> element in the 802.1X schema.
		/// </summary>
		public uint dwMaxAuthFailures;

		/// <summary>
		/// The time, in seconds, to wait for 802.1X authentication completion before normal logon proceeds. This value is used in
		/// single signon (SSO) scenarios. This value defaults to 10 seconds in an 802.1X profile. For more information, see the
		/// <c>maxDelay (singleSignOn) Element</c> in the 802.1X schema.
		/// </summary>
		public uint dwNetworkAuthTimeout;

		/// <summary>
		/// <para>
		/// The maximum duration time, in seconds, to wait for a connection in case a user interface dialog box that requires user input
		/// is displayed during the per-logon SSO.
		/// </para>
		/// <para>
		/// On Windows Vista with SP1 and later, this value is hardcoded to 10 minutes and is not configurable. On Windows Vista Release
		/// to Manufacturing, this value defaults to 60 seconds in an 802.1X profile and was controlled by the
		/// <c>maxDelayWithAdditionalDialogs</c> element in the schema.
		/// </para>
		/// <para>
		/// On Windows Vista with SP1 and later, the <c>maxDelayWithAdditionalDialogs</c> element in the 802.1X schema is ignored and deprecated.
		/// </para>
		/// </summary>
		public uint dwNetworkAuthWithUITimeout;

		/// <summary>
		/// A value that specifies whether to allow EAP dialogs to be displayed when using pre-logon SSO. For more information, see the
		/// <c>allowAdditionalDialogs</c> element in the 802.1X schema.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool bAllowLogonDialogs;

		/// <summary>
		/// The userBasedVirtualLan element in the 802.1X schema that specifies if the virtual LAN (VLAN) used by the device changes
		/// based on the user's credentials. Some network access server (NAS) devices change the VLAN after a user authenticates. When
		/// userBasedVirtualLan is TRUE, the NAS may change a device's VLAN after a user authenticates. For more information, see the
		/// <c>userBasedVirtualLan (singleSignOn) Element</c> in the 802.1X scheme.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool bUserBasedVLan;
	}

	/// <summary>The <c>ONEX_EAP_ERROR</c> structure contains 802.1X EAP error when an error occurs with 802.1X authentication.</summary>
	/// <remarks>
	/// <para>
	/// The <c>ONEX_EAP_ERROR</c> structure is used by the 802.1X module, a new wireless configuration component supported on Windows
	/// Vista and later.
	/// </para>
	/// <para>Many members of the <c>ONEX_EAP_ERROR</c> structure correspond with similar members in the EAP_ERROR structure</para>
	/// <para>
	/// The ONEX_RESULT_UPDATE_DATA contains information on a status change to 802.1X authentication. The <c>ONEX_RESULT_UPDATE_DATA</c>
	/// structure is returned when the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure is
	/// <c>WLAN_NOTIFICATION_SOURCE_ONEX</c> and the <c>NotificationCode</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure for
	/// received notification is <c>OneXNotificationTypeResultUpdate</c>. For this notification, the <c>pData</c> member of the
	/// <c>WLAN_NOTIFICATION_DATA</c> structure points to an <c>ONEX_RESULT_UPDATE_DATA</c> structure that contains information on the
	/// 802.1X authentication status change.
	/// </para>
	/// <para>
	/// If the <c>fEapError</c> member in the ONEX_RESULT_UPDATE_DATA structure is set, then the <c>eapError</c> member of the
	/// <c>ONEX_RESULT_UPDATE_DATA</c> structure contains an ONEX_VARIABLE_BLOB structure with an <c>ONEX_EAP_ERROR</c> structure
	/// embedded starting at the <c>dwOffset</c> member of the <c>ONEX_VARIABLE_BLOB</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dot1x/ns-dot1x-onex_eap_error typedef struct _ONEX_EAP_ERROR { DWORD
	// dwWinError; EAP_METHOD_TYPE type; DWORD dwReasonCode; GUID rootCauseGuid; GUID repairGuid; GUID helpLinkGuid; DWORD
	// fRootCauseString : 1; DWORD fRepairString : 1; ONEX_VARIABLE_BLOB RootCauseString; ONEX_VARIABLE_BLOB RepairString; }
	// ONEX_EAP_ERROR, *PONEX_EAP_ERROR;
	[PInvokeData("dot1x.h", MSDNShortId = "20126b9a-732e-460d-bb10-4d7485b25eb9")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ONEX_EAP_ERROR
	{
		/// <summary>
		/// <para>
		/// The error value defined in the Winerror.h header file. This member also sometimes contains the reason the EAP method failed.
		/// The existing values for this member for the reason the EAP method failed are defined in the Eaphosterror.h header file.
		/// </para>
		/// <para>Some possible values are listed below.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_PATH_NOT_FOUND 3L</term>
		/// <term>The system cannot find the path specified.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_DATA 13L</term>
		/// <term>The data is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER 87L</term>
		/// <term>A parameter is incorrect.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_ARGUMENTS 160L</term>
		/// <term>One or more arguments are not correct.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_CANTOPEN 1011L</term>
		/// <term>The configuration registry key could not be opened.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_DATATYPE_MISMATCH 1629L</term>
		/// <term>The data supplied is of the wrong type.</term>
		/// </item>
		/// <item>
		/// <term>EAP_I_USER_ACCOUNT_OTHER_ERROR 0x40420110</term>
		/// <term>
		/// The EAPHost received EAP failure after the identity exchange. There is likely a problem with the authenticating user's account.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED 0x8000FFFFL</term>
		/// <term>A catastrophic failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_CERT_STORE_INACCESSIBLE 0x80420010</term>
		/// <term>The certificate store can't be accessed on either the authenticator or the peer.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_EAPHOST_METHOD_NOT_INSTALLED 0x80420011</term>
		/// <term>The requested EAP method is not installed.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_EAPHOST_EAPQEC_INACCESSIBLE 0x80420013</term>
		/// <term>
		/// The EAPHost is not able to communicate with the EAP quarantine enforcement client (QEC) on a client with Network Access
		/// Protection (NAP) enabled.
		/// </term>
		/// </item>
		/// <item>
		/// <term>EAP_E_EAPHOST_IDENTITY_UNKNOWN 0x80420014</term>
		/// <term>The EAPHost returns this error if the authenticator fails the authentication after the peer sent its identity.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_AUTHENTICATION_FAILED 0x80420015</term>
		/// <term>The EAPHost returns this error on authentication failure.</term>
		/// </item>
		/// <item>
		/// <term>EAP_I_EAPHOST_EAP_NEGOTIATION_FAILED 0x80420016</term>
		/// <term>The EAPHost returns this error when the client and the server aren't configured with compatible EAP types.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_EAPHOST_METHOD_INVALID_PACKET 0x80420017</term>
		/// <term>The EAPMethod received an EAP packet that cannot be processed.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_EAPHOST_REMOTE_INVALID_PACKET 0x80420018</term>
		/// <term>The EAPHost received a packet that cannot be processed.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_EAPHOST_XML_MALFORMED 0x80420019</term>
		/// <term>The EAPHost configuration schema validation failed.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_METHOD_CONFIG_DOES_NOT_SUPPORT_SSO 0x8042001A</term>
		/// <term>The EAP method does not support single signon for the provided configuration.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_EAPHOST_METHOD_OPERATION_NOT_SUPPORTED 0x80420020</term>
		/// <term>The EAPHost returns this error when a configured EAP method does not support a requested operation (procedure call).</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_USER_CERT_NOT_FOUND 0x80420100</term>
		/// <term>The EAPHost could not find the user certificate for authentication.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_USER_CERT_INVALID 0x80420101</term>
		/// <term>The user certificate being used for authentication does not have a proper extended key usage (EKU) set.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_USER_CERT_EXPIRED 0x80420102</term>
		/// <term>The EAPhost found a user certificate which has expired.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_USER_CERT_REVOKED 0x80420103</term>
		/// <term>The user certificate being used for authentication has been revoked.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_USER_CERT_OTHER_ERROR 0x80420104</term>
		/// <term>An unknown error occurred with the user certificate being used for authentication.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_USER_CERT_REJECTED 0x80420105</term>
		/// <term>The authenticator rejected the user certificate being used for authentication.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_USER_CREDENTIALS_REJECTED 0x80420111</term>
		/// <term>The authenticator rejected the user credentials for authentication.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_USER_NAME_PASSWORD_REJECTED 0x80420112</term>
		/// <term>The authenticator rejected the user credentials for authentication.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_NO_SMART_CARD_READER 0x80420113</term>
		/// <term>No smart card reader was present.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_SERVER_CERT_INVALID 0x80420201</term>
		/// <term>The server certificate being user for authentication does not have a proper EKU set .</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_SERVER_CERT_EXPIRED 0x80420202</term>
		/// <term>The EAPhost found a server certificate which has expired.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_SERVER_CERT_REVOKED 0x80420203</term>
		/// <term>The server certificate being used for authentication has been revoked.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_SERVER_CERT_OTHER_ERROR 0x80420204</term>
		/// <term>An unknown error occurred with the server certificate being used for authentication.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_USER_ROOT_CERT_NOT_FOUND 0x80420300</term>
		/// <term>The EAPHost could not find a certificate in trusted root certificate store for user certificate validation.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_USER_ROOT_CERT_INVALID 0x80420301</term>
		/// <term>The authentication failed because the root certificate used for this network is not valid.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_USER_ROOT_CERT_EXPIRED 0x80420302</term>
		/// <term>The trusted root certificate needed for user certificate validation has expired.</term>
		/// </item>
		/// <item>
		/// <term>EAP_E_SERVER_ROOT_CERT_NOT_FOUND 0x80420400</term>
		/// <term>The EAPHost could not find a root certificate in the trusted root certificate store for server certificate velidation.</term>
		/// </item>
		/// </list>
		/// </summary>
		public Win32Error dwWinError;

		/// <summary>
		/// The EAP method type that raised the error during 802.1X authentication. The EAP_METHOD_TYPE structure is defined in the
		/// Eaptypes.h header file.
		/// </summary>
		public EAP_METHOD_TYPE type;

		/// <summary>
		/// <para>
		/// The reason the EAP method failed. Some of the values for this member are defined in the Eaphosterror.h header file and some
		/// are defined in in the Winerror.h header file, although other values are possible.
		/// </para>
		/// <para>Possible values are listed below.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_ARGUMENTS</term>
		/// <term>One or more arguments are not correct.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_DATA</term>
		/// <term>The data is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>A parameter is incorrect.</term>
		/// </item>
		/// <item>
		/// <term>EAP_I_USER_ACCOUNT_OTHER_ERROR</term>
		/// <term>
		/// The EAPHost received EAP failure after the identity exchange. There is likely a problem with the authenticating user's account.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwReasonCode;

		/// <summary>
		/// <para>
		/// A unique ID that identifies cause of error in EAPHost. An EAP method can define a new GUID and associate the GUID with a
		/// specific root cause. The existing values for this member are defined in the Eaphosterror.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GUID_EapHost_Default {0x00000000, 0x0000, 0x0000, 0, 0, 0, 0, 0, 0, 0, 0}</term>
		/// <term>
		/// The default error cause. This is not a fixed GUID when it reaches supplicant, but the first portion will be filled by a
		/// generic Win32/RAS error. This helps create a unique GUID for every unique error.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_MethodDLLNotFound {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 1}}</term>
		/// <term>EAPHost cannot locate the DLL for the EAP method.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_CertStoreInaccessible {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 4}}</term>
		/// <term>Both the authenticator and the peer are unable to access the certificate store.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_Server_CertExpired {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 5}}</term>
		/// <term>EAPHost found an expired server certificate.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_Server_CertInvalid {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 6}}</term>
		/// <term>The server certificate being user for authentication does not have a proper extended key usage (EKU) set.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_Server_CertNotFound {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 7}}</term>
		/// <term>EAPHost could not find the server certificate for authentication.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_Server_CertRevoked {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 8}}</term>
		/// <term>The server certificate being used for authentication has been revoked.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_User_CertExpired {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 9}}</term>
		/// <term>EAPHost found an expired user certificate.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_User_CertInvalid {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0xA}}</term>
		/// <term>The user certificate being user for authentication does not have proper extended key usage (EKU) set.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_User_CertNotFound {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0xB}}</term>
		/// <term>EAPHost could not find a user certificate for authentication.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_User_CertOtherError {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0xC}}</term>
		/// <term>An unknown error occurred with the user certification being used for authentication.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_User_CertRejected {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0xD}}</term>
		/// <term>The authenticator rejected the user certification.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_User_CertRevoked {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0xE}}</term>
		/// <term>The user certificate being used for authentication has been revoked.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_User_Root_CertExpired {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0xF}}</term>
		/// <term>The trusted root certificate needed for user certificate validation has expired.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_User_Root_CertInvalid {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x10}}</term>
		/// <term>The authentication failed because the root certificate used for this network is not valid.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_User_Root_CertNotFound {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x11}}</term>
		/// <term>EAPHost could not find a certificate in a trusted root certificate store for user certification validation.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_Server_Root_CertNameRequired {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x12}}</term>
		/// <term>The authentication failed because the certificate on the server computer does not have a server name specified.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_EapNegotiationFailed {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x1C}}</term>
		/// <term>The authentication failed because Windows does not have the authentication method required for this network.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_XmlMalformed {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x1D}}</term>
		/// <term>The EAPHost configuration schema validation failed.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_MethodDoesNotSupportOperation {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x1E}}</term>
		/// <term>EAPHost returns this error when a configured EAP method does not support a requested operation (procedure call).</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_No_SmartCardReader_Found {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x2B}}</term>
		/// <term>
		/// A valid smart card needs to be present for authentication to be proceed. This GUID is supported on Windows Server 2008 R2
		/// with the Wireless LAN Service installed and on Windows 7 .
		/// </term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_Generic_AuthFailure {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 1, 4}}</term>
		/// <term>EAPHost returns this error on a generic, unspecified authentication failure.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_Server_CertOtherError {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 1, 8}}</term>
		/// <term>An unknown error occurred with the server certificate.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_User_Account_OtherProblem {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 1, 0xE}}</term>
		/// <term>
		/// An EAP failure was received after an identity exchange, indicating the likelihood of a problem with the authenticating
		/// user's account.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_Server_Root_CertNotFound {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 1, 0x12}}</term>
		/// <term>EAPHost could not find a root certificate in a trusted root certificate store for the server certification validation.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_IdentityUnknown {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 2, 4}}</term>
		/// <term>EAPHost returns this error if the authenticator fails the authentication after the peer identity was submitted.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_User_CredsRejected {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 2, 0xE}}</term>
		/// <term>The authenticator rejected user credentials for authentication.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_ThirdPartyMethod_Host_Reset {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 2, 0x12}}</term>
		/// <term>The host of the third party method is not responding and was automatically restarted.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Cause_EapQecInaccessible {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 3, 0x12}}</term>
		/// <term>
		/// EAPHost was not able to communicate with the EAP quarantine enforcement client (QEC) on a client with Network Access
		/// Protection (NAP) enabled. This error may occur when the NAP service is not responding.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// GUID_EapHost_Cause_Method_Config_Does_Not_Support_Sso {0xda18bd32, 0x004f, 0x41fa, {0xae, 0x08, 0x0b, 0xc8, 0x5e, 0x58,
		/// 0x45, 0xac}}
		/// </term>
		/// <term>
		/// The EAP method does not support single signon for the provided configuration data. This GUID is supported on Windows Server
		/// 2008 R2 with the Wireless LAN Service installed and on Windows 7.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public Guid rootCauseGuid;

		/// <summary>
		/// <para>
		/// A unique ID that maps to a localizable string that identifies the repair action that can be taken to fix the reported error.
		/// The existing values for this member are defined in the Eaphosterror.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GUID_EapHost_Repair_ContactSysadmin {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 2}}</term>
		/// <term>The user should contact the network administrator.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Repair_Server_ClientSelectServerCert {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x18}}</term>
		/// <term>The user should choose a different and valid certificate for authentication with this network.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Repair_User_AuthFailure {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x19}}</term>
		/// <term>
		/// The user should contact your network administrator. Your administrator can verify your user name and password for network authentication.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Repair_User_GetNewCert {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x1A}}</term>
		/// <term>
		/// The user should obtain an updated certificate from the network administrator. The certificate required to connect to this
		/// network can't be found on your computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Repair_User_SelectValidCert {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x1B}}</term>
		/// <term>The user should use a different and valid user certificate for authentication with the network.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Repair_ContactAdmin_AuthFailure {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x1F}}</term>
		/// <term>
		/// The user should contact your network administrator. Windows can't verify your identity for connection to this network. This
		/// GUID is supported on Windows Server 2008 R2 with the Wireless LAN Service installed and on Windows 7.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Repair_ContactAdmin_IdentityUnknown {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x20}}</term>
		/// <term>
		/// The user should contact your network administrator. Windows can't verify your identity for connection to this network. This
		/// GUID is supported on Windows Windows Server 2008 R2 with the Wireless LAN Service installed and on Windows 7.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// GUID_EapHost_Repair_ContactAdmin_NegotiationFailed {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x21}}
		/// </term>
		/// <term>
		/// The user should contact your network administrator. Windows needs to be configured to use the authentication method required
		/// for this network. This GUID is supported on Windows Server 2008 R2 with the Wireless LAN Service installed and on Windows 7.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Repair_ContactAdmin_MethodNotFound {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x22}}</term>
		/// <term>
		/// The user should contact your network administrator. Windows needs to be configured to use the authentication method required
		/// for this network. This GUID is supported on Windows Windows Server 2008 R2 with the Wireless LAN Service installed and on
		/// Windows 7.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Repair_RestartNap {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x23}}</term>
		/// <term>
		/// The user should start the Network Access Protection service. The Network Access Protection service is not responding. Start
		/// or restart the Network Access Protection service, and then try connecting again. This GUID is supported on Windows Server
		/// 2008 R2 with the Wireless LAN Service installed and on Windows 7 .
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// GUID_EapHost_Repair_ContactAdmin_CertStoreInaccessible {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x24}}
		/// </term>
		/// <term>
		/// The user should contact your network administrator. The certificate store on this computer needs to be repaired. This GUID
		/// is supported on Windows Windows Server 2008 R2 with the Wireless LAN Service installed and on Windows 7.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// GUID_EapHost_Repair_ContactAdmin_InvalidUserAccount {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x25}}
		/// </term>
		/// <term>
		/// The user should contact your network administrator. A problem with your user account needs to be resolved. This GUID is
		/// supported on Windows Server 2008 R2 with the Wireless LAN Service installed and on Windows 7.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Repair_ContactAdmin_RootCertInvalid {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x26}}</term>
		/// <term>
		/// The user should contact your network administrator. The root certificate used for this network needs to be repaired. This
		/// GUID is supported on Windows Server 2008 R2 with the Wireless LAN Service installed and on Windows 7.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Repair_ContactAdmin_RootCertNotFound {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x27}}</term>
		/// <term>
		/// The user should contact your network administrator. The certificate used by the server for this network needs to be properly
		/// installed on your computer. This GUID is supported on Windows Server 2008 R2 with the Wireless LAN Service installed and on
		/// Windows 7.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Repair_ContactAdmin_RootExpired {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x28}}</term>
		/// <term>
		/// The user should contact your network administrator. The root certificate used for this network needs to be renewed. This
		/// GUID is supported on Windows Server 2008 R2 with the Wireless LAN Service installed and on Windows 7.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Repair_ContactAdmin_CertNameAbsent {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x29}}</term>
		/// <term>
		/// The user should contact your network administrator. A problem with the server certificate used for this network needs to be
		/// resolved. This GUID is supported on Windows Server 2008 R2 with the Wireless LAN Service installed and on Windows 7.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// GUID_EapHost_Repair_ContactAdmin_NoSmartCardReader {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x2A}}
		/// </term>
		/// <term>
		/// The user should connect a smart card reader to your computer, insert a smart card, and attempt to connect again. This GUID
		/// is supported on Windows Server 2008 R2 with the Wireless LAN Service installed and on Windows 7.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Repair_ContactAdmin_InvalidUserCert {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x2C}}</term>
		/// <term>
		/// The user should contact your network administrator. The user certificate on this computer needs to be repaired. This GUID is
		/// supported on Windows Server 2008 R2 with the Wireless LAN Service installed and on Windows 7.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Repair_Method_Not_Support_Sso {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x2D}}</term>
		/// <term>
		/// The user should contact your network administrator. Windows needs to be configured to use the authentication method required
		/// for this network. This GUID is supported on Windows Server 2008 R2 with the Wireless LAN Service installed and on Windows 7.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Repair_Retry_Authentication {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 1, 0x1B}}</term>
		/// <term>The user should try to connect to the network again.</term>
		/// </item>
		/// </list>
		/// </summary>
		public Guid repairGuid;

		/// <summary>
		/// <para>
		/// A unique ID that maps to a localizable string that specifies an URL for a page that contains additional information about an
		/// error or repair message. An EAP method can potentially define a new GUID and associate with one specific help link. Some of
		/// the existing values for this member are defined in the Eaphosterror.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GUID_EapHost_Help_Troubleshooting {0x33307acf, 0x0698, 0x41ba, {0xb0, 0x14, 0xea, 0x0a, 0x2e, 0xb8, 0xd0, 0xa8}}</term>
		/// <term>
		/// The URL for the page with more information about troubleshooting. This currently is a generic networking troubleshooting
		/// help page, not EAP specific.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Help_EapConfigureTypes {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x03}}</term>
		/// <term>The URL for the page with more information about configuring EAP types.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Help_FailedAuth {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x13}}</term>
		/// <term>The URL for the page with more information about authentication failures. This GUID is supported on Windows Vista</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Help_SelectingCerts {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x15}}</term>
		/// <term>The URL for the page with more information about selecting the appropriate certificate to use for authentication.</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Help_SetupEapServer {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x16}}</term>
		/// <term>The URL for the page with more information about setting up an EAP server. This GUID is supported on Windows Vista</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Help_Troubleshooting {0x9612fc67, 0x6150, 0x4209, {0xa8, 0x5e, 0xa8, 0xd8, 0, 0, 0, 0x17}}</term>
		/// <term>The URL for the page with more information about troubleshooting. This GUID is supported on Windows Vista</term>
		/// </item>
		/// <item>
		/// <term>GUID_EapHost_Help_ObtainingCerts {0xf535eea3, 0x1bdd, 0x46ca, {0xa2, 0xfc, 0xa6, 0x65, 0x59, 0x39, 0xb7, 0xe8}}</term>
		/// <term>The URL for the page with more information about getting EAP certificates.</term>
		/// </item>
		/// </list>
		/// </summary>
		public Guid helpLinkGuid;

		private uint flags;

		/// <summary>
		/// Indicates if the <c>ONEX_EAP_ERROR</c> structure contains a root cause string in the <c>RootCauseString</c> member.
		/// </summary>
		public bool fRootCauseString { get => BitHelper.GetBit(flags, 0); set => BitHelper.SetBit(ref flags, 0, value); }

		/// <summary>Indicates if the <c>ONEX_EAP_ERROR</c> structure contains a repair string in the <c>RepairString</c> member.</summary>
		public bool fRepairString { get => BitHelper.GetBit(flags, 1); set => BitHelper.SetBit(ref flags, 1, value); }

		/// <summary>
		/// A localized and readable string that describes the root cause of the error. This member contains a NULL-terminated Unicode
		/// string starting at the <c>dwOffset</c> member of the ONEX_VARIABLE_BLOB if the <c>fRootCauseString</c> bitfield member is set.
		/// </summary>
		public ONEX_VARIABLE_BLOB RootCauseString;

		/// <summary>
		/// A localized and readable string that describes the possible repair action. This member contains a NULL-terminated Unicode
		/// string starting at the <c>dwOffset</c> member of the ONEX_VARIABLE_BLOB if the <c>fRepairString</c> bitfield member is set.
		/// </summary>
		public ONEX_VARIABLE_BLOB RepairString;
	}

	/// <summary>The <c>ONEX_RESULT_UPDATE_DATA</c> structure contains information on a status change to 802.1X authentication.</summary>
	/// <remarks>
	/// <para>
	/// The <c>ONEX_RESULT_UPDATE_DATA</c> structure is used by the 802.1X module, a new wireless configuration component supported on
	/// Windows Vista and later.
	/// </para>
	/// <para>
	/// The <c>ONEX_RESULT_UPDATE_DATA</c> contains information on a status change to 802.1X authentication.This structure is returned
	/// when the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure is <c>WLAN_NOTIFICATION_SOURCE_ONEX</c> and
	/// the <c>NotificationCode</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure for received notification is
	/// <c>OneXNotificationTypeResultUpdate</c>. For this notification, the <c>pData</c> member of the <c>WLAN_NOTIFICATION_DATA</c>
	/// structure points to an <c>ONEX_RESULT_UPDATE_DATA</c> structure that contains information on the 802.1X authentication status change.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dot1x/ns-dot1x-onex_result_update_data typedef struct _ONEX_RESULT_UPDATE_DATA
	// { ONEX_STATUS oneXStatus; ONEX_EAP_METHOD_BACKEND_SUPPORT BackendSupport; BOOL fBackendEngaged; DWORD fOneXAuthParams : 1; DWORD
	// fEapError : 1; ONEX_VARIABLE_BLOB authParams; ONEX_VARIABLE_BLOB eapError; } ONEX_RESULT_UPDATE_DATA, *PONEX_RESULT_UPDATE_DATA;
	[PInvokeData("dot1x.h", MSDNShortId = "140386c8-2e35-4e83-812f-119bf8828d0b")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ONEX_RESULT_UPDATE_DATA
	{
		/// <summary>Specifies the current 802.1X authentication status. For more information, see the ONEX_STATUS structure.</summary>
		public ONEX_STATUS oneXStatus;

		/// <summary>
		/// <para>Indicates if the configured EAP method on the supplicant is supported on the 802.1X authentication server.</para>
		/// <para>
		/// EAP permits the use of a backend authentication server, which may implement some or all authentication methods, with the
		/// authenticator acting as a pass-through for some or all methods and peers. For more information, see RFC 3748 published by
		/// the IETF and the ONEX_EAP_METHOD_BACKEND_SUPPORT enumeration.
		/// </para>
		/// </summary>
		public ONEX_EAP_METHOD_BACKEND_SUPPORT BackendSupport;

		/// <summary>Indicates if a response was received from the 802.1X authentication server.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fBackendEngaged;

		private uint flags;

		/// <summary>
		/// Indicates if the <c>ONEX_RESULT_UPDATE_DATA</c> structure contains 802.1X authentication parameters in the <c>authParams</c> member.
		/// </summary>
		public bool fOneXAuthParams { get => BitHelper.GetBit(flags, 0); set => BitHelper.SetBit(ref flags, 0, value); }

		/// <summary>Indicates if the <c>ONEX_RESULT_UPDATE_DATA</c> structure contains an EAP error in the <c>eapError</c> member.</summary>
		public bool fEapError { get => BitHelper.GetBit(flags, 1); set => BitHelper.SetBit(ref flags, 1, value); }

		/// <summary>
		/// The 802.1X authentication parameters. This member contains an embedded ONEX_AUTH_PARAMS structure starting at the
		/// <c>dwOffset</c> member of the ONEX_VARIABLE_BLOB if the <c>fOneXAuthParams</c> bitfield member is set.
		/// </summary>
		public ONEX_VARIABLE_BLOB authParams;

		/// <summary>
		/// An EAP error value. This member contains an embedded ONEX_EAP_ERROR structure starting at the <c>dwOffset</c> member of the
		/// ONEX_VARIABLE_BLOB if the <c>fEapError</c> bitfield member is set.
		/// </summary>
		public ONEX_VARIABLE_BLOB eapError;
	}

	/// <summary>The <c>ONEX_STATUS</c> structure contains the current 802.1X authentication status.</summary>
	/// <remarks>
	/// <para>
	/// The <c>ONEX_STATUS</c> structure is used by the 802.1X module, a new wireless configuration component supported on Windows Vista
	/// and later.
	/// </para>
	/// <para>
	/// The ONEX_RESULT_UPDATE_DATA contains information on a status change to 802.1X authentication. The <c>ONEX_RESULT_UPDATE_DATA</c>
	/// structure is returned when the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure is
	/// <c>WLAN_NOTIFICATION_SOURCE_ONEX</c> and the <c>NotificationCode</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure for
	/// received notification is <c>OneXNotificationTypeResultUpdate</c>. For this notification, the <c>pData</c> member of the
	/// <c>WLAN_NOTIFICATION_DATA</c> structure points to an <c>ONEX_RESULT_UPDATE_DATA</c> structure that contains information on the
	/// 802.1X authentication status change.
	/// </para>
	/// <para>The <c>oneXStatus</c> member of the ONEX_RESULT_UPDATE_DATA structure contains an <c>ONEX_STATUS</c> structure.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dot1x/ns-dot1x-onex_status typedef struct _ONEX_STATUS { ONEX_AUTH_STATUS
	// authStatus; DWORD dwReason; DWORD dwError; } ONEX_STATUS, *PONEX_STATUS;
	[PInvokeData("dot1x.h", MSDNShortId = "2c19c65b-0943-4561-a28f-0104e1cbd229")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ONEX_STATUS
	{
		/// <summary>
		/// The current status of the 802.1X authentication process. Any error that may have occurred during authentication is indicated
		/// below by the value of the <c>dwReason</c> and <c>dwError</c> members of the <c>ONEX_STATUS</c> structure. For more
		/// information, see the ONEX_AUTH_STATUS enumeration.
		/// </summary>
		public ONEX_AUTH_STATUS authStatus;

		/// <summary>
		/// If an error occurred during 802.1X authentication, this member contains the reason for the error specified as a value from
		/// the ONEX_REASON_CODE enumeration. This member is normally <c>ONEX_REASON_CODE_SUCCESS</c> when 802.1X authentication is
		/// successful and no error occurs.
		/// </summary>
		public uint dwReason;

		/// <summary>
		/// If an error occurred during 802.1X authentication, this member contains the error. This member is normally NO_ERROR, except
		/// when an EAPHost error occurs.
		/// </summary>
		public uint dwError;
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("dot1x.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ONEX_USER_INFO
	{
		/// <summary/>
		public ONEX_AUTH_IDENTITY authIdentity;

		private uint bits;

		/// <summary/>
		public bool fUserName { get => BitHelper.GetBit(bits, 0); set => BitHelper.SetBit(ref bits, 0, value); }

		/// <summary/>
		public bool fDomainName { get => BitHelper.GetBit(bits, 1); set => BitHelper.SetBit(ref bits, 1, value); }

		/// <summary/>
		public ONEX_VARIABLE_BLOB UserName;

		/// <summary/>
		public ONEX_VARIABLE_BLOB DomainName;
	}

	/// <summary>
	/// The <c>ONEX_VARIABLE_BLOB</c> structure is used as a member of other 802.1X authentication stuctures to contain variable-sized members..
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>ONEX_VARIABLE_BLOB</c> structure is used by the 802.1X module, a new wireless configuration component supported on
	/// Windows Vista and later.
	/// </para>
	/// <para>
	/// The ONEX_RESULT_UPDATE_DATA contains information on a status change to 802.1X authentication. The <c>ONEX_RESULT_UPDATE_DATA</c>
	/// structure is returned when the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure is
	/// <c>WLAN_NOTIFICATION_SOURCE_ONEX</c> and the <c>NotificationCode</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure for
	/// received notification is <c>OneXNotificationTypeResultUpdate</c>. For this notification, the <c>pData</c> member of the
	/// <c>WLAN_NOTIFICATION_DATA</c> structure points to an <c>ONEX_RESULT_UPDATE_DATA</c> structure that contains information on the
	/// 802.1X authentication status change.
	/// </para>
	/// <para>
	/// A number of the nested structure members in the ONEX_RESULT_UPDATE_DATA structure contains members of the
	/// <c>ONEX_VARIABLE_BLOB</c> type.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dot1x/ns-dot1x-onex_variable_blob typedef struct _ONEX_VARIABLE_BLOB { DWORD
	// dwSize; DWORD dwOffset; } ONEX_VARIABLE_BLOB, *PONEX_VARIABLE_BLOB;
	[PInvokeData("dot1x.h", MSDNShortId = "3a410bde-bcff-4a86-aadc-650862dbf38b")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ONEX_VARIABLE_BLOB
	{
		/// <summary>The size, in bytes, of this <c>ONEX_VARIABLE_BLOB</c> structure.</summary>
		public uint dwSize;

		/// <summary>
		/// The offset, in bytes, from the beginning of the containing outer structure (where the <c>ONEX_VARIABLE_BLOB</c> structure is
		/// a member) to the data contained in the <c>ONEX_VARIABLE_BLOB</c> structure.
		/// </summary>
		public uint dwOffset;
	}
}
