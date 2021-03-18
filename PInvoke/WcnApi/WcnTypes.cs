using System;
using System.Runtime.InteropServices;
using System.Text;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke
{
	public static partial class WcnApi
	{
		/// <summary/>
		public const string WCN_QUERY_CONSTRAINT_USE_SOFTAP = "WCN.Discovery.SoftAP";

		/// <summary/>
		public const uint WCN_MICROSOFT_VENDOR_ID = 311;

		/// <summary/>
		public const int WCN_API_MAX_BUFFER_SIZE = 2096;

		/// <summary/>
		public const uint WCN_NO_SUBTYPE = 0xfffffffe;

		/// <summary>
		/// The <c>WCN_ATTRIBUTE_TYPE</c> enumeration defines the attribute buffer types defined for Wi-Fi Protected Setup. The overall size
		/// occupied by each attribute buffer includes an additional 4 bytes (2 bytes of ID, 2 bytes of Length).
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcntypes/ne-wcntypes-wcn_attribute_type typedef enum tagWCN_ATTRIBUTE_TYPE {
		// WCN_TYPE_AP_CHANNEL, WCN_TYPE_ASSOCIATION_STATE, WCN_TYPE_AUTHENTICATION_TYPE, WCN_TYPE_AUTHENTICATION_TYPE_FLAGS,
		// WCN_TYPE_AUTHENTICATOR, WCN_TYPE_CONFIG_METHODS, WCN_TYPE_CONFIGURATION_ERROR, WCN_TYPE_CONFIRMATION_URL4,
		// WCN_TYPE_CONFIRMATION_URL6, WCN_TYPE_CONNECTION_TYPE, WCN_TYPE_CONNECTION_TYPE_FLAGS, WCN_TYPE_CREDENTIAL, WCN_TYPE_DEVICE_NAME,
		// WCN_TYPE_DEVICE_PASSWORD_ID, WCN_TYPE_E_HASH1, WCN_TYPE_E_HASH2, WCN_TYPE_E_SNONCE1, WCN_TYPE_E_SNONCE2,
		// WCN_TYPE_ENCRYPTED_SETTINGS, WCN_TYPE_ENCRYPTION_TYPE, WCN_TYPE_ENCRYPTION_TYPE_FLAGS, WCN_TYPE_ENROLLEE_NONCE,
		// WCN_TYPE_FEATURE_ID, WCN_TYPE_IDENTITY, WCN_TYPE_IDENTITY_PROOF, WCN_TYPE_KEY_WRAP_AUTHENTICATOR, WCN_TYPE_KEY_IDENTIFIER,
		// WCN_TYPE_MAC_ADDRESS, WCN_TYPE_MANUFACTURER, WCN_TYPE_MESSAGE_TYPE, WCN_TYPE_MODEL_NAME, WCN_TYPE_MODEL_NUMBER,
		// WCN_TYPE_NETWORK_INDEX, WCN_TYPE_NETWORK_KEY, WCN_TYPE_NETWORK_KEY_INDEX, WCN_TYPE_NEW_DEVICE_NAME, WCN_TYPE_NEW_PASSWORD,
		// WCN_TYPE_OOB_DEVICE_PASSWORD, WCN_TYPE_OS_VERSION, WCN_TYPE_POWER_LEVEL, WCN_TYPE_PSK_CURRENT, WCN_TYPE_PSK_MAX,
		// WCN_TYPE_PUBLIC_KEY, WCN_TYPE_RADIO_ENABLED, WCN_TYPE_REBOOT, WCN_TYPE_REGISTRAR_CURRENT, WCN_TYPE_REGISTRAR_ESTABLISHED,
		// WCN_TYPE_REGISTRAR_LIST, WCN_TYPE_REGISTRAR_MAX, WCN_TYPE_REGISTRAR_NONCE, WCN_TYPE_REQUEST_TYPE, WCN_TYPE_RESPONSE_TYPE,
		// WCN_TYPE_RF_BANDS, WCN_TYPE_R_HASH1, WCN_TYPE_R_HASH2, WCN_TYPE_R_SNONCE1, WCN_TYPE_R_SNONCE2, WCN_TYPE_SELECTED_REGISTRAR,
		// WCN_TYPE_SERIAL_NUMBER, WCN_TYPE_WI_FI_PROTECTED_SETUP_STATE, WCN_TYPE_SSID, WCN_TYPE_TOTAL_NETWORKS, WCN_TYPE_UUID_E,
		// WCN_TYPE_UUID_R, WCN_TYPE_VENDOR_EXTENSION, WCN_TYPE_VERSION, WCN_TYPE_X_509_CERTIFICATE_REQUEST, WCN_TYPE_X_509_CERTIFICATE,
		// WCN_TYPE_EAP_IDENTITY, WCN_TYPE_MESSAGE_COUNTER, WCN_TYPE_PUBLIC_KEY_HASH, WCN_TYPE_REKEY_KEY, WCN_TYPE_KEY_LIFETIME,
		// WCN_TYPE_PERMITTED_CONFIG_METHODS, WCN_TYPE_SELECTED_REGISTRAR_CONFIG_METHODS, WCN_TYPE_PRIMARY_DEVICE_TYPE,
		// WCN_TYPE_SECONDARY_DEVICE_TYPE_LIST, WCN_TYPE_PORTABLE_DEVICE, WCN_TYPE_AP_SETUP_LOCKED, WCN_TYPE_APPLICATION_EXTENSION,
		// WCN_TYPE_EAP_TYPE, WCN_TYPE_INITIALIZATION_VECTOR, WCN_TYPE_KEY_PROVIDED_AUTOMATICALLY, WCN_TYPE_802_1X_ENABLED,
		// WCN_TYPE_APPSESSIONKEY, WCN_TYPE_WEPTRANSMITKEY, WCN_TYPE_UUID, WCN_TYPE_PRIMARY_DEVICE_TYPE_CATEGORY,
		// WCN_TYPE_PRIMARY_DEVICE_TYPE_SUBCATEGORY_OUI, WCN_TYPE_PRIMARY_DEVICE_TYPE_SUBCATEGORY, WCN_TYPE_CURRENT_SSID, WCN_TYPE_BSSID,
		// WCN_TYPE_DOT11_MAC_ADDRESS, WCN_TYPE_AUTHORIZED_MACS, WCN_TYPE_NETWORK_KEY_SHAREABLE, WCN_TYPE_REQUEST_TO_ENROLL,
		// WCN_TYPE_REQUESTED_DEVICE_TYPE, WCN_TYPE_SETTINGS_DELAY_TIME, WCN_TYPE_VERSION2, WCN_TYPE_VENDOR_EXTENSION_WFA,
		// WCN_NUM_ATTRIBUTE_TYPES } WCN_ATTRIBUTE_TYPE;
		[PInvokeData("wcntypes.h", MSDNShortId = "NE:wcntypes.tagWCN_ATTRIBUTE_TYPE")]
		public enum WCN_ATTRIBUTE_TYPE
		{
			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a value
			/// containing data that specifies the 802.11 channel the access point is hosting.
			/// </summary>
			WCN_TYPE_AP_CHANNEL,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a value
			/// containing the association state or configuration information defined by WCN_VALUE_TYPE_ASSOCIATION_STATE.
			/// </summary>
			WCN_TYPE_ASSOCIATION_STATE,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a value
			/// containing an authentication type defined by WCN_VALUE_TYPE_AUTHENTICATION_TYPE.
			/// </summary>
			WCN_TYPE_AUTHENTICATION_TYPE,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a value
			/// containing data that specifies the network authentication capabilities of the Enrollee (access point or station) by
			/// providing a value defined by WCN_VALUE_TYPE_AUTHENTICATION_TYPE.
			/// </summary>
			WCN_TYPE_AUTHENTICATION_TYPE_FLAGS,

			/// <summary>
			/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a buffer
			/// containing a keyed hash of data.
			/// </summary>
			WCN_TYPE_AUTHENTICATOR,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains values,
			/// defined by WCN_VALUE_TYPE_CONFIG_METHODS, that specify the configuration methods supported by the Enrollee or Registrar.
			/// Additionally, access points and stationsthat support the UPnP Management Interface must also support this attribute, whichis
			/// used to control the configuration methods that are enabled on the access point.
			/// </summary>
			WCN_TYPE_CONFIG_METHODS,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a value,
			/// defined by WCN_VALUE_TYPE_CONFIGURATION_ERROR, that specifies the result of the device attempting to configure itself and
			/// associate with the WLAN.If a configuration session fails with the error code WCN_E_CONNECTION_REJECTED, any error code
			/// returned by the remote device can be obtained by querying this attribute. It is important to note that some devices will
			/// return WCN_VALUE_CE_NO_ERROR even if an error has occurred.
			/// </summary>
			WCN_TYPE_CONFIGURATION_ERROR,

			/// <summary>
			/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a buffer that
			/// contains data representing the URL (IPv4 address based) provided by the Registrar to the Enrollee for use in posting
			/// confirmationonce settings have been successfully applied and the network has been joined. This configurationparameter is
			/// optional for a Registrar, and it is optional for the Enrollee to post to the URL if the Registrarincludes it.
			/// </summary>
			WCN_TYPE_CONFIRMATION_URL4,

			/// <summary>
			/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a buffer that
			/// contains data representing the URL (IPv6 address based) provided by the Registrar to the Enrollee for use in posting a
			/// confirmationonce settings have been successfully applied and the network has been joined. This configurationparameter is
			/// optional for a Registrar and it is optional for the Enrollee to post to the URL if the Registrarincludes it.
			/// </summary>
			WCN_TYPE_CONFIRMATION_URL6,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains a value,
			/// defined by WCN_VALUE_TYPE_CONNECTION_TYPE, that specifies the connection capability of the Enrollee.
			/// </summary>
			WCN_TYPE_CONNECTION_TYPE,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains a value,
			/// defined by WCN_VALUE_TYPE_CONNECTION_TYPE, that specifies the connection capability of the Enrollee.
			/// </summary>
			WCN_TYPE_CONNECTION_TYPE_FLAGS,

			/// <summary>
			/// This compound attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method contains a single
			/// WLAN Credential. There can be either multiple Credential attributes for each Network Key, or multipleNetwork Keys in a
			/// single Credential attribute, which is accomplished by repeating the Network Key Index and attributes thatfollow it.
			/// Generally, multiplekeys in a single Credential for a single SSID should be used, and multiple Credential attributes
			/// forseparate SSIDs should be used. The following attributes are contained in each instance of Credential:If an application
			/// intends to use the network credential with the WLAN API, it should use IWCNDevice::GetNetworkProfile to get a compatible XML
			/// network profile directly.
			/// </summary>
			WCN_TYPE_CREDENTIAL,

			/// <summary>
			/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a buffer that
			/// contains a user-friendly description of the device encoded in UTF-8. Typically, the componentwould be a unique identifier
			/// that describes the product in a way that is recognizable to the user.
			/// </summary>
			WCN_TYPE_DEVICE_NAME,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains a value,
			/// defined by WCN VALUE TYPE DEVICE_PASSWORD_ID, that is used to identify a device password.
			/// </summary>
			WCN_TYPE_DEVICE_PASSWORD_ID,

			/// <summary>
			/// This attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method contains the HMAC-SHA-256
			/// hash of the first half of the device password and the Enrollee’s first secretnonce.
			/// </summary>
			WCN_TYPE_E_HASH1,

			/// <summary>
			/// This attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method contains the HMAC-SHA-256
			/// hash of the second half of the device password, and the Enrollee’s secondsecret nonce.
			/// </summary>
			WCN_TYPE_E_HASH2,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains the first
			/// nonce used by the Enrollee with the first half of the device password.
			/// </summary>
			WCN_TYPE_E_SNONCE1,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains the
			/// second nonce used by the Enrollee with the second half of the device password.
			/// </summary>
			WCN_TYPE_E_SNONCE2,

			/// <summary>
			/// This attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method contains an initialization
			/// vector (IV) followed by a setof encrypted Wi-Fi Protected Setup TLV attributes. The last attribute in the encrypted set is a
			/// Key WrapAuthenticator computed according to the procedure described in section 6.5.
			/// </summary>
			WCN_TYPE_ENCRYPTED_SETTINGS,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains a value,
			/// defined by WCN_VALUE_TYPE_ENCRYPTION_TYPE, for the Enrollee (AP orstation) to use.
			/// </summary>
			WCN_TYPE_ENCRYPTION_TYPE,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains a value,
			/// defined by WCN_VALUE_TYPE_ENCRYPTION_TYPE, for the Enrollee (AP orstation) to use.
			/// </summary>
			WCN_TYPE_ENCRYPTION_TYPE_FLAGS,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains a
			/// randomly generated binary value that is created by the Enrollee forsetup operations.
			/// </summary>
			WCN_TYPE_ENROLLEE_NONCE,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains data that
			/// indicates a particular feature build for an operating system running on the device. The most significant bit of the 4 byte
			/// integer is reserved, and always set to one.
			/// </summary>
			WCN_TYPE_FEATURE_ID,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_IDENTITY,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_IDENTITY_PROOF,

			/// <summary>
			/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a 8 byte buffer
			/// containing the first 64 bits of the HMAC-SHA-256 computed over the data to be encryptedwith the key wrap algorithm. It is
			/// appended to the end of the ConfigData prior to encryption.
			/// </summary>
			WCN_TYPE_KEY_WRAP_AUTHENTICATOR,

			/// <summary>
			/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetAttribute method is a 16 byte buffer
			/// containing a 128-bit key identifier. If this attribute immediately precedes an Encrypted Dataor Authenticator attribute,
			/// then the key corresponding to the 128-bit identifier should be used to decryptor verify the Data field.
			/// </summary>
			WCN_TYPE_KEY_IDENTIFIER,

			/// <summary>
			/// This attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method is a 6 byte buffer
			/// containing the 48 bit value of the MAC Address. For example: 0x00 0x07 0xE9 0x4C 0xA8 0x1C.This address is supplied by the
			/// remote device. Some Access Points give the MAC address of their Ethernet interface, in which case, the address cannot be
			/// used to locate the AP’s wireless radio. If an application needs to locate an AP’s radio, the application should query the
			/// WCN_TYPE_BSSID attribute, which is populated by Windows and is generally more reliable.
			/// </summary>
			WCN_TYPE_MAC_ADDRESS,

			/// <summary>
			/// This attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method is a buffer containing a
			/// string that identifies the manufacturer of the device.Generally, this field should allow a user to make an association with
			/// a device with the labeling on thedevice.
			/// </summary>
			WCN_TYPE_MANUFACTURER,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_MESSAGE_TYPE,

			/// <summary>
			/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a buffer that
			/// identifies the model of the device. Generally, this fieldshould allow a user to create an association of a device with the
			/// labeling on the device.
			/// </summary>
			WCN_TYPE_MODEL_NAME,

			/// <summary>
			/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a string
			/// containing additional descriptive data associated with the device.
			/// </summary>
			WCN_TYPE_MODEL_NUMBER,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 1 byte buffer
			/// used to get and set network settings for devices that host more than one network. Thedefault value is '1' which refers to
			/// the primary WLAN network on the device.
			/// </summary>
			WCN_TYPE_NETWORK_INDEX,

			/// <summary>
			/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a buffer
			/// containing the wireless encryption key to be used by the Enrollee. Note that it is recommended that applications implement
			/// IWCNDevice::GetNetworkProfile to get network settings in a convenient format that is ready to be used with the WLAN
			/// connection and profile management APIs.
			/// </summary>
			WCN_TYPE_NETWORK_KEY,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_NETWORK_KEY_INDEX,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_NEW_DEVICE_NAME,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_NEW_PASSWORD,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_OOB_DEVICE_PASSWORD,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 4 byte buffer
			/// that contains the operating system version running on the device. The most significant bit of this 4 byte field is reserved,
			/// and always set to one.
			/// </summary>
			WCN_TYPE_OS_VERSION,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_POWER_LEVEL,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_PSK_CURRENT,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_PSK_MAX,

			/// <summary>
			/// Reserved. Do not use. We recommend that a shared secret be sent by way of a vendor extension or that you find another way to
			/// do cryptography.
			/// </summary>
			WCN_TYPE_PUBLIC_KEY,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_RADIO_ENABLED,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_REBOOT,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_REGISTRAR_CURRENT,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_REGISTRAR_ESTABLISHED,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_REGISTRAR_LIST,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_REGISTRAR_MAX,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 16 byte
			/// buffer containing a randomly generated binary value created by the Registrar forsetup.
			/// </summary>
			WCN_TYPE_REGISTRAR_NONCE,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_REQUEST_TYPE,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_RESPONSE_TYPE,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is an integer
			/// value, defined by WCN_VALUE_TYPE_RF_BANDS, that indicates which RF band is utilized during message exchange, permitting
			/// endpoints and proxies to communicate over a consistent radio interface. It may also be used as an optionalattribute in a
			/// WCN_TYPE_CREDENTIAL or WCN_TYPE_ENCRYPTED_SETTINGS to indicate a specific (or group) of RF bands to which asetting applies.
			/// </summary>
			WCN_TYPE_RF_BANDS,

			/// <summary>
			/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a 32 byte buffer
			/// that containing the HMAC-SHA-256 hash of the first half of the device password and the Registrar’s first secretnonce.
			/// </summary>
			WCN_TYPE_R_HASH1,

			/// <summary>
			/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a 32 byte buffer
			/// containing the HMAC-SHA-256 hash of the second half of the device password and the Registrar’s secondsecret nonce.
			/// </summary>
			WCN_TYPE_R_HASH2,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 16 byte
			/// buffer containing the first nonce used by the Registrar with the first half of the device password.
			/// </summary>
			WCN_TYPE_R_SNONCE1,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 16 byte
			/// buffer containing the second nonce used by the Registrar with the second half of the device password.
			/// </summary>
			WCN_TYPE_R_SNONCE2,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is an integer
			/// value, defined by WCN_VALUE_TYPE_BOOLEAN, that indicates if a Registrar has been selected by a user and that an Enrollee can
			/// proceed withsetting up an 802.1X uncontrolled data port with the Registrar.
			/// </summary>
			WCN_TYPE_SELECTED_REGISTRAR,

			/// <summary>
			/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a string
			/// containing the serial number of the Enrollee.
			/// </summary>
			WCN_TYPE_SERIAL_NUMBER,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method an integer value,
			/// defined by WCN_VALUE_TYPE_WI_FI_PROTECTED_SETUP, that indicates if a device is configured.
			/// </summary>
			WCN_TYPE_WI_FI_PROTECTED_SETUP_STATE,

			/// <summary>
			/// This attribute value indicates that the pbData parameter of the IWCNDevice::GetAttribute method is a buffer, up to 32 bytes
			/// in size, containing the Service Set Identifier (SSID) or network name.Instead of querying this attribute, it is recommended
			/// that applications implement IWCNDevice::GetNetworkProfile to retrieve network settings in a convenient format that is ready
			/// to be used with the WLAN connection and profile management APIs.
			/// </summary>
			WCN_TYPE_SSID,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_TOTAL_NETWORKS,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 16 byte
			/// buffer containing the Universally Unique Identifier (UUID) generated by the Enrollee. Ituniquely identifies an operational
			/// device and should survive reboots and resets. The UUID is provided inbinary format. If the device also supports UPnP, then
			/// the UUID corresponds to the UPnP UUID.Instead of querying this attribute, applications should instead query the
			/// WCN_TYPE_UUID attribute, as it is available for both enrollees and registrars. WCN_TYPE_UUID_E_ is only available for
			/// devices that act as an enrollee.
			/// </summary>
			WCN_TYPE_UUID_E,

			/// <summary>
			/// This attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method is a 16 byte buffer
			/// containing the Universally Unique Identifier (UUID) element generated by the Registrar. Ituniquely identifies an operational
			/// device and should survive reboots and resets. The UUID is provided inbinary format. If the device also supports UPnP, then
			/// the UUID corresponds to the UPnP UUID.Instead of querying this attribute, applications should instead query the
			/// WCN_TYPE_UUID attribute, as it is available for both enrollees and registrars.
			/// </summary>
			WCN_TYPE_UUID_R,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetAttribute method is a buffer, up to 1024
			/// bytes in size, that permits the use of vendor extensions in the Wi-Fi Protected Setup TLV framework. The VendorExtension
			/// figure illustrates the implementation of vendor extensions. Vendor ID is the SMI network management private enterprise code.
			/// Instead of querying this value, implementation of the IWCNDevice::GetVendorExtension API is recommended for convenience and
			/// flexibilty while accessing the raw vendor extension attribute directly.
			/// </summary>
			WCN_TYPE_VENDOR_EXTENSION,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is an integer
			/// value that indicates the Wi-Fi Protected Setup version. The one-byte field is broken into a four-bit major part using thetop
			/// MSBs and four-bit minor part using the LSBs. As an example, version 3.2 would be 0x32.
			/// </summary>
			WCN_TYPE_VERSION,

			/// <summary>
			/// This attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method is a buffer containing an
			/// X.509 certificate request payload as specified in RFC 2511.
			/// </summary>
			WCN_TYPE_X_509_CERTIFICATE_REQUEST,

			/// <summary>
			/// This attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method is a buffer containing an
			/// X.509 certificate.
			/// </summary>
			WCN_TYPE_X_509_CERTIFICATE,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_EAP_IDENTITY,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_MESSAGE_COUNTER,

			/// <summary>
			/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a 20 byte buffer
			/// containing the first 160 bits of the SHA-256 hash of a public key.
			/// </summary>
			WCN_TYPE_PUBLIC_KEY_HASH,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_REKEY_KEY,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_KEY_LIFETIME,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is an integer
			/// defined by WCN_VALUE_TYPE_CONFIG_METHODS, that indicates which of the configuration methods supported by the device are enabled.
			/// </summary>
			WCN_TYPE_PERMITTED_CONFIG_METHODS,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is an integer
			/// defined by WCN_VALUE_TYPE_CONFIG_METHODS, that is used in Probe Response messages toconvey the current supported Config
			/// Methods of a specific Registrar.
			/// </summary>
			WCN_TYPE_SELECTED_REGISTRAR_CONFIG_METHODS,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is an 8 byte
			/// buffer containing values, contained in WCN_VALUE_TYPE_PRIMARY_DEVICE_TYPE, that indicates the primary type of the device. It
			/// is recommended that applications instead query the WCN_TYPE_PRIMARY_DEVICE_TYPE_CATEGORY,
			/// WCN_TYPE_PRIMARY_DEVICE_TYPE_SUBCATEGORY_OUI, and WCN_TYPE_PRIMARY_DEVICE_TYPE_SUBCATEGORY attributes as they are more convenient.
			/// </summary>
			WCN_TYPE_PRIMARY_DEVICE_TYPE,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_SECONDARY_DEVICE_TYPE_LIST,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_PORTABLE_DEVICE,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a buffer
			/// containing a value, defined by WCN_VALUE_TYPE_BOOLEAN, that indicates if the access point has entered a state in which it
			/// will refuse to allow an external Registrarto attempt to run the Registration Protocol using the AP’s PIN (with the AP acting
			/// as Enrollee). The APshould enter this state if it believes a brute force attack is underway against the AP’s PIN.When the AP
			/// is in this state, it MUST continue to allow other Enrollees to connect and run theRegistration Protocol with any external
			/// Registrars or the AP’s built-in Registrar (if any). It is only the useof the AP’s PIN for adding external Registrars that is
			/// disabled in this state.The AP Setup Locked state can be reset to FALSE through an authenticated call to SetAPSettings.
			/// APsmay provide other implementation-specific methods of resetting the AP Setup Locked state as well.
			/// </summary>
			WCN_TYPE_AP_SETUP_LOCKED,

			/// <summary>
			/// This attribute value indicates that the pvBuffer parameter of the IWCNDevice::GetAttribute method is a buffer, up to 512
			/// bytes in size, used to pass parameters for enabling applications during the WSCexchange. It is similar to the Vendor
			/// Extension attribute except that instead of a 3-byte Vendor ID prefixto the Vendor Data field, a 16-byte UUID (as defined in
			/// RFC 4122) is used. This provides a virtuallyunlimited application ID space with a regular structure that can be easily
			/// mapped onto a genericapplication extension API. Furthermore, the 16-byte UUID value can be used to derive
			/// applicationspecificAMSKs as described in Section 6.3 or pass any necessary keying directly.
			/// </summary>
			WCN_TYPE_APPLICATION_EXTENSION,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_EAP_TYPE,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_INITIALIZATION_VECTOR,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_KEY_PROVIDED_AUTOMATICALLY,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_802_1X_ENABLED,

			/// <summary>
			/// This attribute value represents the buffer, up to 128 bytes in size, containing data that indicates an exchange of
			/// application specific session keys and, alternatively, may be usedto calculate AMSKs.
			/// </summary>
			WCN_TYPE_APPSESSIONKEY,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 1 byte buffer
			/// containing data that identifies the Key Index value used as the Access Point transmit key for WEP configurations.
			/// </summary>
			WCN_TYPE_WEPTRANSMITKEY,

			/// <summary>
			/// This compound attribute indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 16 byte
			/// buffer that contains data that is always equal to the UUID of the device, regardless if the device is enrollee or registrar.
			/// (Effectively, merges WCN_TYPE_UUID_E and WCN_TYPE_UUID_R).
			/// </summary>
			WCN_TYPE_UUID,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute is an integer that
			/// represents the major device category of a WCN device. The major device category is one of the
			/// WCN_VALUE_TYPE_DEVICE_TYPE_CATEGORY values.
			/// </summary>
			WCN_TYPE_PRIMARY_DEVICE_TYPE_CATEGORY,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute is an integer that
			/// represents the OUI that defines the device subcategory of a WCN device. The most common OUI is WCN_VALUE_DT_SUBTYPE_WIFI_OUI
			/// which indicates that the subcategory is defined by the Wi-Fi Alliance.
			/// </summary>
			WCN_TYPE_PRIMARY_DEVICE_TYPE_SUBCATEGORY_OUI,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute is an integer that
			/// represents the device subcategory of a WCN device. The subcategory must be interpreted along with the OUI from
			/// WCN_TYPE_PRIMARY_DEVICE_TYPE_SUBCATEGORY_OUI. For devices using the Wi-Fi Alliance OUI. The subcategory is one of the
			/// WCN_VALUE_TYPE_DEVICE_TYPE_SUBCATEGORY values.
			/// </summary>
			WCN_TYPE_PRIMARY_DEVICE_TYPE_SUBCATEGORY,

			/// <summary>
			/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is buffer, up to 32
			/// bytes in size, containing the current SSID of a wireless access point.
			/// </summary>
			WCN_TYPE_CURRENT_SSID,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_BSSID,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_DOT11_MAC_ADDRESS,

			/// <summary>
			/// . This attribute value indicates that a registrar is providing a list of MAC addresses that are authorized to start WSC. The
			/// pbBuffer parameter of the IWCNDevice::GetAttribute method is a 6-30 byte buffer containing the 48 bit value of each MAC
			/// Address in the list of authorized MACs. For example: 0x00 0x07 0xE9 0x4C 0xA8 0x1C.
			/// </summary>
			WCN_TYPE_AUTHORIZED_MACS,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 1 byte buffer
			/// used to get and set network settings for devices that host more than one network. A value of '1' indicates that the Network
			/// Key may be shared with other devices.
			/// </summary>
			WCN_TYPE_NETWORK_KEY_SHAREABLE,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_REQUEST_TO_ENROLL,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_REQUESTED_DEVICE_TYPE,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 1 byte buffer
			/// indicating the estimated length of time (in seconds) that an access point will require to reconfigure itself and become
			/// available, or that a device will require to apply settings and connect to a network.
			/// </summary>
			WCN_TYPE_SETTINGS_DELAY_TIME,

			/// <summary>
			/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is an integer
			/// value that indicates the Wi-Fi Protected Setup version. The one-byte field is broken into a four-bit major part using thetop
			/// MSBs and four-bit minor part using the LSBs. As an example, version 3.2 would be 0x32.
			/// </summary>
			WCN_TYPE_VERSION2,

			/// <summary>Reserved. Do not use.</summary>
			WCN_TYPE_VENDOR_EXTENSION_WFA,

			/// <summary>The number of assigned attributes.</summary>
			WCN_NUM_ATTRIBUTE_TYPES,
		}

		/// <summary>
		/// The <c>WCN_VALUE_TYPE_ASSOCIATION_STATE</c> enumeration defines the possible association states of a wireless station during a
		/// Discovery request.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcntypes/ne-wcntypes-wcn_value_type_association_state typedef enum
		// tagWCN_VALUE_TYPE_ASSOCIATION_STATE { WCN_VALUE_AS_NOT_ASSOCIATED, WCN_VALUE_AS_CONNECTION_SUCCESS,
		// WCN_VALUE_AS_CONFIGURATION_FAILURE, WCN_VALUE_AS_ASSOCIATION_FAILURE, WCN_VALUE_AS_IP_FAILURE } WCN_VALUE_TYPE_ASSOCIATION_STATE;
		[PInvokeData("wcntypes.h", MSDNShortId = "NE:wcntypes.tagWCN_VALUE_TYPE_ASSOCIATION_STATE")]
		public enum WCN_VALUE_TYPE_ASSOCIATION_STATE
		{
			/// <summary>The wireless station is not associated.</summary>
			WCN_VALUE_AS_NOT_ASSOCIATED,

			/// <summary>The connection was successfully established.</summary>
			WCN_VALUE_AS_CONNECTION_SUCCESS,

			/// <summary>The wireless station is not properly configured.</summary>
			WCN_VALUE_AS_CONFIGURATION_FAILURE,

			/// <summary>Association has failed.</summary>
			WCN_VALUE_AS_ASSOCIATION_FAILURE,

			/// <summary>The specified IP address could not be connected to, and may be invalid.</summary>
			WCN_VALUE_AS_IP_FAILURE,
		}

		/// <summary>
		/// The <c>WCN_VALUE_TYPE_AUTHENTICATION_TYPE</c> enumeration defines the authentication types supported by the Enrollee (access
		/// point or station).
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcntypes/ne-wcntypes-wcn_value_type_authentication_type typedef enum
		// tagWCN_VALUE_TYPE_AUTHENTICATION_TYPE { WCN_VALUE_AT_OPEN, WCN_VALUE_AT_WPAPSK, WCN_VALUE_AT_SHARED, WCN_VALUE_AT_WPA,
		// WCN_VALUE_AT_WPA2, WCN_VALUE_AT_WPA2PSK, WCN_VALUE_AT_WPAWPA2PSK_MIXED } WCN_VALUE_TYPE_AUTHENTICATION_TYPE;
		[PInvokeData("wcntypes.h", MSDNShortId = "NE:wcntypes.tagWCN_VALUE_TYPE_AUTHENTICATION_TYPE")]
		[Flags]
		public enum WCN_VALUE_TYPE_AUTHENTICATION_TYPE
		{
			/// <summary>Specifies IEEE 802.11 Open System authentication.</summary>
			WCN_VALUE_AT_OPEN = 0x1,

			/// <summary>
			/// Specifies WPA security. Authentication is performed between the supplicant and authenticator over IEEE 802.1X. Encryption
			/// keys are dynamic and are derived through the preshared key used by the supplicant and authenticator.
			/// </summary>
			WCN_VALUE_AT_WPAPSK = 0x2,

			/// <summary>Specifies IEEE 802.11 Shared Key authentication that uses a preshared WEP key.</summary>
			WCN_VALUE_AT_SHARED = 0x4,

			/// <summary>
			/// Specifies WPA security. Authentication is performed between the supplicant, authenticator, and authentication server over
			/// IEEE 802.1X. Encryption keys are dynamic and are derived through the authentication process.
			/// </summary>
			WCN_VALUE_AT_WPA = 0x8,

			/// <summary>
			/// Specifies WPA2 security. Authentication is performed between the supplicant, authenticator, and authentication server over
			/// IEEE 802.1X. Encryption keys are dynamic and are derived through the authentication process.
			/// </summary>
			WCN_VALUE_AT_WPA2 = 0x10,

			/// <summary>
			/// Specifies WPA2 security. Authentication is performed between the supplicant and authenticator over IEEE 802 1X. Encryption
			/// keys are dynamic and are derived through the preshared key used by the supplicant and authenticator.
			/// </summary>
			WCN_VALUE_AT_WPA2PSK = 0x20,

			/// <summary>Specifies WPAPSK/WPA2PSK mixed-mode encryption.</summary>
			WCN_VALUE_AT_WPAWPA2PSK_MIXED = 0x22,
		}

		/// <summary>
		/// The <c>WCN_VALUE_TYPE_BOOLEAN</c> enumeration defines values used to represent true/false conditions encountered during device
		/// setup and association.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcntypes/ne-wcntypes-wcn_value_type_boolean typedef enum
		// tagWCN_VALUE_TYPE_BOOLEAN { WCN_VALUE_FALSE, WCN_VALUE_TRUE } WCN_VALUE_TYPE_BOOLEAN;
		[PInvokeData("wcntypes.h", MSDNShortId = "NE:wcntypes.tagWCN_VALUE_TYPE_BOOLEAN")]
		public enum WCN_VALUE_TYPE_BOOLEAN
		{
			/// <summary>The argument is false.</summary>
			WCN_VALUE_FALSE,

			/// <summary>The argument is true.</summary>
			WCN_VALUE_TRUE,
		}

		/// <summary>
		/// The <c>WCN_VALUE_TYPE_CONFIG_METHODS</c> enumeration defines the configuration methods supported by the Enrollee or Registrar.
		/// One or more of the following configuration methods must be supported.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcntypes/ne-wcntypes-wcn_value_type_config_methods typedef enum
		// tagWCN_VALUE_TYPE_CONFIG_METHODS { WCN_VALUE_CM_USBA, WCN_VALUE_CM_ETHERNET, WCN_VALUE_CM_LABEL, WCN_VALUE_CM_DISPLAY,
		// WCN_VALUE_CM_EXTERNAL_NFC, WCN_VALUE_CM_INTEGRATED_NFC, WCN_VALUE_CM_NFC_INTERFACE, WCN_VALUE_CM_PUSHBUTTON, WCN_VALUE_CM_KEYPAD,
		// WCN_VALUE_CM_VIRT_PUSHBUTTON, WCN_VALUE_CM_PHYS_PUSHBUTTON, WCN_VALUE_CM_VIRT_DISPLAY, WCN_VALUE_CM_PHYS_DISPLAY } WCN_VALUE_TYPE_CONFIG_METHODS;
		[PInvokeData("wcntypes.h", MSDNShortId = "NE:wcntypes.tagWCN_VALUE_TYPE_CONFIG_METHODS")]
		[Flags]
		public enum WCN_VALUE_TYPE_CONFIG_METHODS
		{
			/// <summary>USB-A (flash drive) configuration is supported.</summary>
			WCN_VALUE_CM_USBA = 0x1,

			/// <summary>Ethernet configuration is supported.</summary>
			WCN_VALUE_CM_ETHERNET = 0x2,

			/// <summary>
			/// Label configuration is supported. To authenticate with the default password ID, call IWCNDevice::SetPassword with the PIN
			/// password type defined by WCN_PASSWORD_TYPE.
			/// </summary>
			WCN_VALUE_CM_LABEL = 0x4,

			/// <summary>
			/// Display configuration is supported. To authenticate with the default password ID, call IWCNDevice::SetPassword with the PIN
			/// password type defined by WCN_PASSWORD_TYPE.
			/// </summary>
			WCN_VALUE_CM_DISPLAY = 0x8,

			/// <summary>External near-field communication (NFC) token configuration is supported.</summary>
			WCN_VALUE_CM_EXTERNAL_NFC = 0x10,

			/// <summary>Integrated NFC token configuration is supported.</summary>
			WCN_VALUE_CM_INTEGRATED_NFC = 0x20,

			/// <summary>NFC interface configuration is supported.</summary>
			WCN_VALUE_CM_NFC_INTERFACE = 0x40,

			/// <summary>
			/// Push button configuration is supported. To authenticate with the default password ID, call IWCNDevice::SetPassword with the
			/// push button password type defined by WCN_PASSWORD_TYPE.
			/// </summary>
			WCN_VALUE_CM_PUSHBUTTON = 0x80,

			/// <summary>Keypad configuration is supported.</summary>
			WCN_VALUE_CM_KEYPAD = 0x100,

			/// <summary>
			/// Virtual push button configuration is supported. To authenticate with the default password ID, call IWCNDevice::SetPassword
			/// with the push button password type defined by WCN_PASSWORD_TYPE.
			/// </summary>
			WCN_VALUE_CM_VIRT_PUSHBUTTON = 0x280,

			/// <summary>
			/// Physical push button configuration is supported. To authenticate with the default password ID, call IWCNDevice::SetPassword
			/// with the push button password type defined by WCN_PASSWORD_TYPE.
			/// </summary>
			WCN_VALUE_CM_PHYS_PUSHBUTTON = 0x480,

			/// <summary>
			/// Virtual display configuration is supported. To authenticate with the default password ID, call IWCNDevice::SetPassword with
			/// the PIN password type defined by WCN_PASSWORD_TYPE.
			/// </summary>
			WCN_VALUE_CM_VIRT_DISPLAY = 0x2008,

			/// <summary>
			/// Physical display configuration is supported. To authenticate with the default password ID, call IWCNDevice::SetPassword with
			/// the PIN password type defined by WCN_PASSWORD_TYPE.
			/// </summary>
			WCN_VALUE_CM_PHYS_DISPLAY = 0x4008,
		}

		/// <summary>
		/// The <c>WCN_VALUE_TYPE_CONFIGURATION_ERROR</c> enumeration defines possible error values returned to a device while attempting to
		/// configure to, and associate with, the WLAN.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcntypes/ne-wcntypes-wcn_value_type_configuration_error typedef enum
		// tagWCN_VALUE_TYPE_CONFIGURATION_ERROR { WCN_VALUE_CE_NO_ERROR, WCN_VALUE_CE_OOB_INTERFACE_READ_ERROR,
		// WCN_VALUE_CE_DECRYPTION_CRC_FAILURE, WCN_VALUE_CE_2_4_CHANNEL_NOT_SUPPORTED, WCN_VALUE_CE_5_0_CHANNEL_NOT_SUPPORTED,
		// WCN_VALUE_CE_SIGNAL_TOO_WEAK, WCN_VALUE_CE_NETWORK_AUTHENTICATION_FAILURE, WCN_VALUE_CE_NETWORK_ASSOCIATION_FAILURE,
		// WCN_VALUE_CE_NO_DHCP_RESPONSE, WCN_VALUE_CE_FAILED_DHCP_CONFIG, WCN_VALUE_CE_IP_ADDRESS_CONFLICT,
		// WCN_VALUE_CE_COULD_NOT_CONNECT_TO_REGISTRAR, WCN_VALUE_CE_MULTIPLE_PBC_SESSIONS_DETECTED, WCN_VALUE_CE_ROGUE_ACTIVITY_SUSPECTED,
		// WCN_VALUE_CE_DEVICE_BUSY, WCN_VALUE_CE_SETUP_LOCKED, WCN_VALUE_CE_MESSAGE_TIMEOUT, WCN_VALUE_CE_REGISTRATION_SESSION_TIMEOUT,
		// WCN_VALUE_CE_DEVICE_PASSWORD_AUTH_FAILURE } WCN_VALUE_TYPE_CONFIGURATION_ERROR;
		[PInvokeData("wcntypes.h", MSDNShortId = "NE:wcntypes.tagWCN_VALUE_TYPE_CONFIGURATION_ERROR")]
		public enum WCN_VALUE_TYPE_CONFIGURATION_ERROR
		{
			/// <summary>
			/// No error. An application must be prepared to handle devices that signal 'No Error' even if the device detected an error.
			/// </summary>
			WCN_VALUE_CE_NO_ERROR,

			/// <summary>Could not read the out-of-band (OOB) interface.</summary>
			WCN_VALUE_CE_OOB_INTERFACE_READ_ERROR,

			/// <summary>Could not decrypt the Cyclic Redundancy Check (CRC) value.</summary>
			WCN_VALUE_CE_DECRYPTION_CRC_FAILURE,

			/// <summary>The 2.4 GHz channel is not supported.</summary>
			WCN_VALUE_CE_2_4_CHANNEL_NOT_SUPPORTED,

			/// <summary>The 5.0 GHz channel is not supported.</summary>
			WCN_VALUE_CE_5_0_CHANNEL_NOT_SUPPORTED,

			/// <summary>The wireless signal is not strong enough to initiate a connection.</summary>
			WCN_VALUE_CE_SIGNAL_TOO_WEAK,

			/// <summary>Network authentication failed.</summary>
			WCN_VALUE_CE_NETWORK_AUTHENTICATION_FAILURE,

			/// <summary>Network association failed.</summary>
			WCN_VALUE_CE_NETWORK_ASSOCIATION_FAILURE,

			/// <summary>The DHCP server did not respond.</summary>
			WCN_VALUE_CE_NO_DHCP_RESPONSE,

			/// <summary>DHCP configuration failed.</summary>
			WCN_VALUE_CE_FAILED_DHCP_CONFIG,

			/// <summary>There was an IP address conflict.</summary>
			WCN_VALUE_CE_IP_ADDRESS_CONFLICT,

			/// <summary>Could not connect to the registrar.</summary>
			WCN_VALUE_CE_COULD_NOT_CONNECT_TO_REGISTRAR,

			/// <summary>Multiple push button configuration (PBC) sessions were detected.</summary>
			WCN_VALUE_CE_MULTIPLE_PBC_SESSIONS_DETECTED,

			/// <summary>Rogue activity is suspected.</summary>
			WCN_VALUE_CE_ROGUE_ACTIVITY_SUSPECTED,

			/// <summary>The device is busy.</summary>
			WCN_VALUE_CE_DEVICE_BUSY,

			/// <summary>Setup is locked.</summary>
			WCN_VALUE_CE_SETUP_LOCKED,

			/// <summary>The message timed out.</summary>
			WCN_VALUE_CE_MESSAGE_TIMEOUT,

			/// <summary>The registration session timed out.</summary>
			WCN_VALUE_CE_REGISTRATION_SESSION_TIMEOUT,

			/// <summary>Device password authentication failed.</summary>
			WCN_VALUE_CE_DEVICE_PASSWORD_AUTH_FAILURE,
		}

		/// <summary>The <c>WCN_VALUE_TYPE_CONNECTION_TYPE</c> enumeration defines the connection capabilities of the Enrollee.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcntypes/ne-wcntypes-wcn_value_type_connection_type typedef enum
		// tagWCN_VALUE_TYPE_CONNECTION_TYPE { WCN_VALUE_CT_ESS, WCN_VALUE_CT_IBSS } WCN_VALUE_TYPE_CONNECTION_TYPE;
		[PInvokeData("wcntypes.h", MSDNShortId = "NE:wcntypes.tagWCN_VALUE_TYPE_CONNECTION_TYPE")]
		public enum WCN_VALUE_TYPE_CONNECTION_TYPE
		{
			/// <summary>Specifies an ESS (infrastructure network) connection.</summary>
			WCN_VALUE_CT_ESS = 1,

			/// <summary>Specifies an IBSS (ad-hoc network) connection.</summary>
			WCN_VALUE_CT_IBSS,
		}

		/// <summary>The <c>WCN_VALUE_TYPE_DEVICE_PASSWORD_ID</c> enumeration defines values that specify the origin or 'type' of a password.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcntypes/ne-wcntypes-wcn_value_type_device_password_id typedef enum
		// tagWCN_VALUE_TYPE_DEVICE_PASSWORD_ID { WCN_VALUE_DP_DEFAULT, WCN_VALUE_DP_USER_SPECIFIED, WCN_VALUE_DP_MACHINE_SPECIFIED,
		// WCN_VALUE_DP_REKEY, WCN_VALUE_DP_PUSHBUTTON, WCN_VALUE_DP_REGISTRAR_SPECIFIED, WCN_VALUE_DP_NFC_CONNECTION_HANDOVER,
		// WCN_VALUE_DP_WFD_SERVICES, WCN_VALUE_DP_OUTOFBAND_MIN, WCN_VALUE_DP_OUTOFBAND_MAX } WCN_VALUE_TYPE_DEVICE_PASSWORD_ID;
		[PInvokeData("wcntypes.h", MSDNShortId = "NE:wcntypes.tagWCN_VALUE_TYPE_DEVICE_PASSWORD_ID")]
		public enum WCN_VALUE_TYPE_DEVICE_PASSWORD_ID
		{
			/// <summary>
			/// The PIN password, obtained from the label, ordisplay will be used. This password may correspond to the label, display, or a
			/// user-defined password that has beenconfigured to replace the original device password.To authenticate with the default
			/// password ID, call IWCNDevice::SetPassword with the PIN password type defined by WCN_PASSWORD_TYPE.
			/// </summary>
			WCN_VALUE_DP_DEFAULT = 0,

			/// <summary>The user has overridden the default password with a manually selected value.</summary>
			WCN_VALUE_DP_USER_SPECIFIED,

			/// <summary>The default PIN password has been overridden by a strong, machine-generateddevice password value.</summary>
			WCN_VALUE_DP_MACHINE_SPECIFIED,

			/// <summary>The 256-bit rekeying passwordassociated with the device will be used.</summary>
			WCN_VALUE_DP_REKEY,

			/// <summary>
			/// A password entered via a push button interface will be used. To authenticate with the default password ID, call
			/// IWCNDevice::SetPassword with the push button password type defined by WCN_PASSWORD_TYPE.
			/// </summary>
			WCN_VALUE_DP_PUSHBUTTON,

			/// <summary>A PIN has been obtained from the Registrar via a display orother out-of-band method.</summary>
			WCN_VALUE_DP_REGISTRAR_SPECIFIED,

			/// <summary/>
			WCN_VALUE_DP_NFC_CONNECTION_HANDOVER = 7,

			/// <summary/>
			WCN_VALUE_DP_WFD_SERVICES,

			/// <summary/>
			WCN_VALUE_DP_OUTOFBAND_MIN = 0x10,

			/// <summary/>
			WCN_VALUE_DP_OUTOFBAND_MAX = 0xffff,
		}

		/// <summary>
		/// <para>Specifies the primary device type category. This data is supplied in network byte order.</para>
		/// </summary>
		[PInvokeData("wcntypes.h", MSDNShortId = "NS:wcntypes.tagWCN_VALUE_TYPE_PRIMARY_DEVICE_TYPE")]
		public enum WCN_VALUE_TYPE_DEVICE_TYPE_CATEGORY : ushort
		{
			/// <summary>Indicates a computer.</summary>
			WCN_VALUE_DT_CATEGORY_COMPUTER = 0x1,

			/// <summary>Indicates an input device.</summary>
			WCN_VALUE_DT_CATEGORY_INPUT_DEVICE = 0x2,

			/// <summary>Indicates a printer.</summary>
			WCN_VALUE_DT_CATEGORY_PRINTER = 0x3,

			/// <summary>Indicates a camera.</summary>
			WCN_VALUE_DT_CATEGORY_CAMERA = 0x4,

			/// <summary>Indicates a storage device.</summary>
			WCN_VALUE_DT_CATEGORY_STORAGE = 0x5,

			/// <summary>Indicates a network.</summary>
			WCN_VALUE_DT_CATEGORY_NETWORK_INFRASTRUCTURE = 0x6,

			/// <summary>Indicates a display.</summary>
			WCN_VALUE_DT_CATEGORY_DISPLAY = 0x7,

			/// <summary>Indicates a multimedia device.</summary>
			WCN_VALUE_DT_CATEGORY_MULTIMEDIA_DEVICE = 0x8,

			/// <summary>Indicates a gaming device.</summary>
			WCN_VALUE_DT_CATEGORY_GAMING_DEVICE = 0x9,

			/// <summary>Indicates a telephone.</summary>
			WCN_VALUE_DT_CATEGORY_TELEPHONE = 0xa,

			/// <summary>
			/// Indicates an audio device.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_CATEGORY_AUDIO_DEVICE = 0xb,

			/// <summary>
			/// Indicates an unspecified device.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_CATEGORY_OTHER = 0xff,
		}

		/// <summary>
		/// <para>
		/// Specifies the primary device type sub-category. This data is supplied in network byte order. If <c>SubCategoryOUI</c> is equal
		/// to <c>WCN_VALUE_DT_SUBTYPE_WIFI_OUI</c>, then any of the values below are valid. Otherwise, the SubCategory has been defined by
		/// the vendor.
		/// </para>
		/// </summary>
		[PInvokeData("wcntypes.h", MSDNShortId = "NS:wcntypes.tagWCN_VALUE_TYPE_PRIMARY_DEVICE_TYPE")]
		public enum WCN_VALUE_TYPE_DEVICE_TYPE_SUBCATEGORY : ushort
		{
			/// <summary>Indicates a personal computer.</summary>
			WCN_VALUE_DT_SUBTYPE_COMPUTER_PC = 0x1,

			/// <summary>Indicates a server.</summary>
			WCN_VALUE_DT_SUBTYPE_COMPUTER_SERVER = 0x2,

			/// <summary>
			/// Indicates a media center.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_COMPUTER_MEDIACENTER = 0x3,

			/// <summary>
			/// Indicates an Ultra-Mobile PC.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_COMPUTER_ULTRAMOBILEPC = 0x4,

			/// <summary>
			/// Indicates a notebook computer.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_COMPUTER_NOTEBOOK = 0x5,

			/// <summary>
			/// Indicates a desktop computer.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_COMPUTER_DESKTOP = 0x6,

			/// <summary>
			/// Indicates a mobile Internet device.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_COMPUTER_MID = 0x7,

			/// <summary>
			/// Indicates a netbook.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_COMPUTER_NETBOOK = 0x8,

			/// <summary>
			/// Indicates a keyboard.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_KEYBOARD = 0x1,

			/// <summary>
			/// Indicates a mouse.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_MOUSE = 0x2,

			/// <summary>
			/// Indicates a joystick.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_JOYSTICK = 0x3,

			/// <summary>
			/// Indicates a trackball.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_TRACKBALL = 0x4,

			/// <summary>
			/// Indicates a game controller.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_GAMECONTROLLER = 0x5,

			/// <summary>
			/// Indicates a remote control.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_REMOTE = 0x6,

			/// <summary>
			/// Indicates a touch screen.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_TOUCHSCREEN = 0x7,

			/// <summary>
			/// Indicates a biometric reader.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_BIOMETRICREADER = 0x8,

			/// <summary>
			/// Indicates a barcode reader.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_BARCODEREADER = 0x9,

			/// <summary>Indicates a printer.</summary>
			WCN_VALUE_DT_SUBTYPE_PRINTER_PRINTER = 0x1,

			/// <summary>Indicates a scanner.</summary>
			WCN_VALUE_DT_SUBTYPE_PRINTER_SCANNER = 0x2,

			/// <summary>
			/// Indicates a fax machine.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_PRINTER_FAX = 0x3,

			/// <summary>
			/// Indicates a copier.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_PRINTER_COPIER = 0x4,

			/// <summary>
			/// Indicates an all-in-one printer.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_PRINTER_ALLINONE = 0x4,

			/// <summary>Indicates a still-shot camera.</summary>
			WCN_VALUE_DT_SUBTYPE_CAMERA_STILL_CAMERA = 0x1,

			/// <summary>
			/// Indicates a video camera.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_CAMERA_VIDEO_CAMERA = 0x2,

			/// <summary>
			/// Indicates a web camera.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_CAMERA_WEB_CAMERA = 0x3,

			/// <summary>
			/// Indicates a security camera.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_CAMERA_SECURITY_CAMERA = 0x4,

			/// <summary>Indicates a network storage device.</summary>
			WCN_VALUE_DT_SUBTYPE_STORAGE_NAS = 0x1,

			/// <summary>Indicates an access point.</summary>
			WCN_VALUE_DT_SUBTYPE_NETWORK_INFRASTRUCUTURE_AP = 0x1,

			/// <summary>Indicates a router.</summary>
			WCN_VALUE_DT_SUBTYPE_NETWORK_INFRASTRUCUTURE_ROUTER = 0x2,

			/// <summary>Indicates a switch.</summary>
			WCN_VALUE_DT_SUBTYPE_NETWORK_INFRASTRUCUTURE_SWITCH = 0x3,

			/// <summary>
			/// Indicates a gateway.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_NETWORK_INFRASTRUCUTURE_GATEWAY = 0x4,

			/// <summary>
			/// Indicates a bridge.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_NETWORK_INFRASTRUCUTURE_BRIDGE = 0x5,

			/// <summary>Indicates a television.</summary>
			WCN_VALUE_DT_SUBTYPE_DISPLAY_TELEVISION = 0x1,

			/// <summary>Indicates an electronic picture frame.</summary>
			WCN_VALUE_DT_SUBTYPE_DISPLAY_PICTURE_FRAME = 0x2,

			/// <summary>Indicates a digital projector.</summary>
			WCN_VALUE_DT_SUBTYPE_DISPLAY_PROJECTOR = 0x3,

			/// <summary>
			/// Indicates a monitor.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_DISPLAY_MONITOR = 0x4,

			/// <summary>Indicates a digital audio recorder.</summary>
			WCN_VALUE_DT_SUBTYPE_MULTIMEDIA_DEVICE_DAR = 0x1,

			/// <summary>Indicates a personal video recorder.</summary>
			WCN_VALUE_DT_SUBTYPE_MULTIMEDIA_DEVICE_PVR = 0x2,

			/// <summary>Indicates a Yamaha Digital Multimedia Receiver.</summary>
			WCN_VALUE_DT_SUBTYPE_MULTIMEDIA_DEVICE_MCX = 0x3,

			/// <summary>
			/// Indicates a set-top box.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_MULTIMEDIA_DEVICE_SETTOPBOX = 0x4,

			/// <summary>
			/// Indicates a media server, media adapter, or media extender.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_MULTIMEDIA_DEVICE_MEDIA_SERVER_ADAPT_EXT = 0x5,

			/// <summary>
			/// Indicates a portable video player.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_MULTIMEDIA_DEVICE_PVP = 0x6,

			/// <summary>Indicates a Microsoft XBOX console.</summary>
			WCN_VALUE_DT_SUBTYPE_GAMING_DEVICE_XBOX = 0x1,

			/// <summary>Indicates a Microsoft XBOX 360 console.</summary>
			WCN_VALUE_DT_SUBTYPE_GAMING_DEVICE_XBOX360 = 0x2,

			/// <summary>Indicates a Sony Playstation 3.</summary>
			WCN_VALUE_DT_SUBTYPE_GAMING_DEVICE_PLAYSTATION = 0x3,

			/// <summary>
			/// Indicates a game console adapter.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_GAMING_DEVICE_CONSOLE_ADAPT = 0x4,

			/// <summary>
			/// Indicates a portable gaming device.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_GAMING_DEVICE_PORTABLE = 0x5,

			/// <summary>Indicates a Windows Mobile device.</summary>
			WCN_VALUE_DT_SUBTYPE_TELEPHONE_WINDOWS_MOBILE = 0x1,

			/// <summary>
			/// Indicates a single-mode phone.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_TELEPHONE_PHONE_SINGLEMODE = 0x2,

			/// <summary>
			/// Indicates a dual-mode phone.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_TELEPHONE_PHONE_DUALMODE = 0x3,

			/// <summary>
			/// Indicates a single-mode smartphone.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_TELEPHONE_PHONE_SMARTPHONE_SINGLEMODE = 0x4,

			/// <summary>
			/// Indicates a dual-mode smartphone.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_TELEPHONE_PHONE_SMARTPHONE_DUALMODE = 0x2,

			/// <summary>
			/// Indicates an audio tuner/receiver.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_AUDIO_DEVICE_TUNER_RECEIVER = 0x1,

			/// <summary>
			/// Indicates speakers.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_AUDIO_DEVICE_SPEAKERS = 0x2,

			/// <summary>
			/// Indicates a personal media player.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_AUDIO_DEVICE_PMP = 0x2,

			/// <summary>
			/// Indicates a headset.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_AUDIO_DEVICE_HEADSET = 0x2,

			/// <summary>
			/// Indicates headphones.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_AUDIO_DEVICE_HEADPHONES = 0x2,

			/// <summary>
			/// Indicates a microphone.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_AUDIO_DEVICE_MICROPHONE = 0x2,

			/// <summary>
			/// Indicates a home theater system.
			/// <para>Note Only available in Windows 8.</para>
			/// </summary>
			WCN_VALUE_DT_SUBTYPE_AUDIO_DEVICE_HOMETHEATER = 0x2,
		}

		/// <summary>Specifies the unique manufacturer OUI associated with the device.</summary>
		[PInvokeData("wcntypes.h", MSDNShortId = "NS:wcntypes.tagWCN_VALUE_TYPE_PRIMARY_DEVICE_TYPE")]
		public enum WCN_VALUE_TYPE_DEVICE_TYPE_SUBCATEGORY_OUI : uint
		{
			/// <summary>Indicates the specific manufacturer Organization ID (OUI) for a wireless device.</summary>
			WCN_VALUE_DT_SUBTYPE_WIFI_OUI = 0x50f204
		}

		/// <summary>The <c>WCN_VALUE_TYPE_ENCRYPTION_TYPE</c> enumeration defines the supported WLAN encryption types.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcntypes/ne-wcntypes-wcn_value_type_encryption_type typedef enum
		// tagWCN_VALUE_TYPE_ENCRYPTION_TYPE { WCN_VALUE_ET_NONE, WCN_VALUE_ET_WEP, WCN_VALUE_ET_TKIP, WCN_VALUE_ET_AES,
		// WCN_VALUE_ET_TKIP_AES_MIXED } WCN_VALUE_TYPE_ENCRYPTION_TYPE;
		[PInvokeData("wcntypes.h", MSDNShortId = "NE:wcntypes.tagWCN_VALUE_TYPE_ENCRYPTION_TYPE")]
		[Flags]
		public enum WCN_VALUE_TYPE_ENCRYPTION_TYPE
		{
			/// <summary>Specifies support for unsecured wireless activity.</summary>
			WCN_VALUE_ET_NONE = 0x1,

			/// <summary>Specifies support for the Wired Equivalent Privacy (WEP) encryption method.</summary>
			WCN_VALUE_ET_WEP = 0x2,

			/// <summary>Specifies support for the Temporal Key Integrity Protocol (TKIP) encryption method.</summary>
			WCN_VALUE_ET_TKIP = 0x4,

			/// <summary>Specifies support for the Advanced Encryption Standard (AES) encryption method.</summary>
			WCN_VALUE_ET_AES = 0x8,

			/// <summary>Specifies support for WPAPSK/WPA2PSK mixed-mode encryption.</summary>
			WCN_VALUE_ET_TKIP_AES_MIXED = 0xc,
		}

		/// <summary>Values for WCN_TYPE_MESSAGE_TYPE</summary>
		[PInvokeData("wcntypes.h")]
		public enum WCN_VALUE_TYPE_MESSAGE_TYPE
		{
			/// <summary/>
			WCN_VALUE_MT_BEACON = 0x1,

			/// <summary/>
			WCN_VALUE_MT_PROBE_REQUEST = 0x2,

			/// <summary/>
			WCN_VALUE_MT_PROBE_RESPONSE = 0x3,

			/// <summary/>
			WCN_VALUE_MT_M1 = 0x4,

			/// <summary/>
			WCN_VALUE_MT_M2 = 0x5,

			/// <summary/>
			WCN_VALUE_MT_M2D = 0x6,

			/// <summary/>
			WCN_VALUE_MT_M3 = 0x7,

			/// <summary/>
			WCN_VALUE_MT_M4 = 0x8,

			/// <summary/>
			WCN_VALUE_MT_M5 = 0x9,

			/// <summary/>
			WCN_VALUE_MT_M6 = 0xa,

			/// <summary/>
			WCN_VALUE_MT_M7 = 0xb,

			/// <summary/>
			WCN_VALUE_MT_M8 = 0xc,

			/// <summary/>
			WCN_VALUE_MT_ACK = 0xd,

			/// <summary/>
			WCN_VALUE_MT_NACK = 0xe,

			/// <summary/>
			WCN_VALUE_MT_DONE = 0xf
		}

		/// <summary>Values for WCN_TYPE_REQUEST_TYPE</summary>
		[PInvokeData("wcntypes.h")]
		public enum WCN_VALUE_TYPE_REQUEST_TYPE
		{
			/// <summary/>
			WCN_VALUE_ReqT_ENROLLEE_INFO = 0,

			/// <summary/>
			WCN_VALUE_ReqT_ENROLLEE_OPEN_1X = 0x1,

			/// <summary/>
			WCN_VALUE_ReqT_REGISTRAR = 0x2,

			/// <summary/>
			WCN_VALUE_ReqT_MANAGER_REGISTRAR = 0x3
		}

		/// <summary>Values for WCN_TYPE_RESPONSE_TYPE</summary>
		[PInvokeData("wcntypes.h")]
		public enum WCN_VALUE_TYPE_RESPONSE_TYPE
		{
			/// <summary/>
			WCN_VALUE_RspT_ENROLLEE_INFO,

			/// <summary/>
			WCN_VALUE_RspT_ENROLLEE_OPEN_1X = 0x1,

			/// <summary/>
			WCN_VALUE_RspT_REGISTRAR = 0x2,

			/// <summary/>
			WCN_VALUE_RspT_AP = 0x3
		}

		/// <summary>
		/// The <c>WCN_VALUE_TYPE_RF_BANDS</c> enumeration defines the possible radio frequency bands on which an enrollee can send
		/// Discovery requests.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcntypes/ne-wcntypes-wcn_value_type_rf_bands typedef enum
		// tagWCN_VALUE_TYPE_RF_BANDS { WCN_VALUE_RB_24GHZ, WCN_VALUE_RB_50GHZ } WCN_VALUE_TYPE_RF_BANDS;
		[PInvokeData("wcntypes.h", MSDNShortId = "NE:wcntypes.tagWCN_VALUE_TYPE_RF_BANDS")]
		public enum WCN_VALUE_TYPE_RF_BANDS
		{
			/// <summary>The request is being sent on the 2.4 GHz frequency band.</summary>
			WCN_VALUE_RB_24GHZ = 0x1,

			/// <summary>The request is being sent on the 5.0 Ghz frequency band.</summary>
			WCN_VALUE_RB_50GHZ = 0x2
		}

		/// <summary>The <c>WCN_VALUE_TYPE_VERSION</c> enumeration defines the supported version of Wi-Fi Protected Setup (WPS).</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcntypes/ne-wcntypes-wcn_value_type_version typedef enum
		// tagWCN_VALUE_TYPE_VERSION { WCN_VALUE_VERSION_1_0, WCN_VALUE_VERSION_2_0 } WCN_VALUE_TYPE_VERSION;
		[PInvokeData("wcntypes.h", MSDNShortId = "NE:wcntypes.tagWCN_VALUE_TYPE_VERSION")]
		public enum WCN_VALUE_TYPE_VERSION
		{
			/// <summary>
			/// Specifies WPS 1.0. Indicates compliance with Wi-Fi Alliance protocol specification for Wi-Fi Protected Setup (WPS) 1.0h.
			/// </summary>
			WCN_VALUE_VERSION_1_0 = 0x10,

			/// <summary>
			/// Specifies WPS 2.0. Indicates compliance with Wi-Fi Alliance protocol specification for Wi-Fi Simple Configuration (WSC) 2.0.
			/// </summary>
			WCN_VALUE_VERSION_2_0 = 0x20,
		}

		/// <summary>The <c>WCN_VALUE_TYPE_WI_FI_PROTECTED_SETUP_STATE</c> enumeration defines values that indicate if a device is configured.</summary>
		/// <remarks>
		/// A device is considered 'not configured' if it is using factory default wireless settings. If the wireless settings have been
		/// customized by the user, the device is considered to be 'configured'. A factory reset will restore the device to a 'not
		/// configured' state.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcntypes/ne-wcntypes-wcn_value_type_wi_fi_protected_setup_state typedef enum
		// tagWCN_VALUE_TYPE_WI_FI_PROTECTED_SETUP_STATE { WCN_VALUE_SS_RESERVED00, WCN_VALUE_SS_NOT_CONFIGURED, WCN_VALUE_SS_CONFIGURED } WCN_VALUE_TYPE_WI_FI_PROTECTED_SETUP_STATE;
		[PInvokeData("wcntypes.h", MSDNShortId = "NE:wcntypes.tagWCN_VALUE_TYPE_WI_FI_PROTECTED_SETUP_STATE")]
		public enum WCN_VALUE_TYPE_WI_FI_PROTECTED_SETUP_STATE
		{
			/// <summary>This value is reserved.</summary>
			WCN_VALUE_SS_RESERVED00,

			/// <summary>The device is not configured.</summary>
			WCN_VALUE_SS_NOT_CONFIGURED,

			/// <summary>The device is configured.</summary>
			WCN_VALUE_SS_CONFIGURED,
		}

		/// <summary>
		/// The <c>WCN_VALUE_TYPE_PRIMARY_DEVICE_TYPE</c> structure contains information that identifies the device type by category,
		/// sub-category, and a manufacturer specific OUI (Organization ID).
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcntypes/ns-wcntypes-wcn_value_type_primary_device_type typedef struct
		// tagWCN_VALUE_TYPE_PRIMARY_DEVICE_TYPE { WCN_VALUE_TYPE_DEVICE_TYPE_CATEGORY Category; WCN_VALUE_TYPE_DEVICE_TYPE_SUBCATEGORY_OUI
		// SubCategoryOUI; WCN_VALUE_TYPE_DEVICE_TYPE_SUBCATEGORY SubCategory; } WCN_VALUE_TYPE_PRIMARY_DEVICE_TYPE;
		[PInvokeData("wcntypes.h", MSDNShortId = "NS:wcntypes.tagWCN_VALUE_TYPE_PRIMARY_DEVICE_TYPE")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WCN_VALUE_TYPE_PRIMARY_DEVICE_TYPE
		{
			/// <summary>
			/// <para>Specifies the primary device type category. This data is supplied in network byte order.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>WCN_VALUE_DT_CATEGORY_COMPUTER 0x1</term>
			/// <term>Indicates a computer.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_CATEGORY_INPUT_DEVICE 0x2</term>
			/// <term>Indicates an input device.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_CATEGORY_PRINTER 0x3</term>
			/// <term>Indicates a printer.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_CATEGORY_CAMERA 0x4</term>
			/// <term>Indicates a camera.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_CATEGORY_STORAGE 0x5</term>
			/// <term>Indicates a storage device.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_CATEGORY_NETWORK_INFRASTRUCTURE 0x6</term>
			/// <term>Indicates a network.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_CATEGORY_DISPLAY 0x7</term>
			/// <term>Indicates a display.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_CATEGORY_MULTIMEDIA_DEVICE 0x8</term>
			/// <term>Indicates a multimedia device.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_CATEGORY_GAMING_DEVICE 0x9</term>
			/// <term>Indicates a gaming device.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_CATEGORY_TELEPHONE 0xa</term>
			/// <term>Indicates a telephone.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_CATEGORY_AUDIO_DEVICE 0xb</term>
			/// <term>Indicates an audio device.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_CATEGORY_OTHER 0xff</term>
			/// <term>Indicates an unspecified device.</term>
			/// </item>
			/// </list>
			/// </summary>
			public WCN_VALUE_TYPE_DEVICE_TYPE_CATEGORY Category;

			/// <summary>
			/// <para>Specifies the unique manufacturer OUI associated with the device.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_WIFI_OUI 0x50f204</term>
			/// <term>Indicates the specific manufacturer Organization ID (OUI) for a wireless device.</term>
			/// </item>
			/// </list>
			/// </summary>
			public WCN_VALUE_TYPE_DEVICE_TYPE_SUBCATEGORY_OUI SubCategoryOUI;

			/// <summary>
			/// <para>
			/// Specifies the primary device type sub-category. This data is supplied in network byte order. If <c>SubCategoryOUI</c> is
			/// equal to <c>WCN_VALUE_DT_SUBTYPE_WIFI_OUI</c>, then any of the values below are valid. Otherwise, the SubCategory has been
			/// defined by the vendor.
			/// </para>
			/// <para>The following values are possible when the <c>Category</c> member is set to <c>WCN_VALUE_DT_CATEGORY_COMPUTER</c>.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_COMPUTER_PC 0x1</term>
			/// <term>Indicates a personal computer.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_COMPUTER_SERVER 0x2</term>
			/// <term>Indicates a server.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_COMPUTER_MEDIACENTER 0x3</term>
			/// <term>Indicates a media center.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_COMPUTER_ULTRAMOBILEPC 0x4</term>
			/// <term>Indicates an Ultra-Mobile PC.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_COMPUTER_NOTEBOOK 0x5</term>
			/// <term>Indicates a notebook computer.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_COMPUTER_DESKTOP 0x6</term>
			/// <term>Indicates a desktop computer.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_COMPUTER_MID 0x7</term>
			/// <term>Indicates a mobile Internet device.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_COMPUTER_NETBOOK 0x8</term>
			/// <term>Indicates a netbook.</term>
			/// </item>
			/// </list>
			/// <para>The following values are possible when the <c>Category</c> member is set to <c>WCN_VALUE_DT_CATEGORY_INPUT_DEVICE</c>.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_KEYBOARD 0x1</term>
			/// <term>Indicates a keyboard.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_MOUSE 0x2</term>
			/// <term>Indicates a mouse.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_JOYSTICK 0x3</term>
			/// <term>Indicates a joystick.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_TRACKBALL 0x4</term>
			/// <term>Indicates a trackball.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_GAMECONTROLLER 0x5</term>
			/// <term>Indicates a game controller.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_REMOTE 0x6</term>
			/// <term>Indicates a remote control.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_TOUCHSCREEN 0x7</term>
			/// <term>Indicates a touch screen.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_BIOMETRICREADER 0x8</term>
			/// <term>Indicates a biometric reader.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_INPUT_DEVICE_BARCODEREADER 0x9</term>
			/// <term>Indicates a barcode reader.</term>
			/// </item>
			/// </list>
			/// <para>The following values are possible when the <c>Category</c> member is set to <c>WCN_VALUE_DT_CATEGORY_PRINTER</c>.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_PRINTER_PRINTER 0x1</term>
			/// <term>Indicates a printer.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_PRINTER_SCANNER 0x2</term>
			/// <term>Indicates a scanner.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_PRINTER_FAX 0x3</term>
			/// <term>Indicates a fax machine.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_PRINTER_COPIER 0x4</term>
			/// <term>Indicates a copier.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_PRINTER_ALLINONE 0x4</term>
			/// <term>Indicates an all-in-one printer.</term>
			/// </item>
			/// </list>
			/// <para>The following values are possible when the <c>Category</c> member is set to <c>WCN_VALUE_DT_CATEGORY_CAMERA</c>.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_CAMERA_STILL_CAMERA 0x1</term>
			/// <term>Indicates a still-shot camera.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_CAMERA_VIDEO_CAMERA 0x2</term>
			/// <term>Indicates a video camera.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_CAMERA_WEB_CAMERA 0x3</term>
			/// <term>Indicates a web camera.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_CAMERA_SECURITY_CAMERA 0x4</term>
			/// <term>Indicates a security camera.</term>
			/// </item>
			/// </list>
			/// <para>The following values are possible when the <c>Category</c> member is set to <c>WCN_VALUE_DT_CATEGORY_NETWORK_STORAGE</c>.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_STORAGE_NAS 0x1</term>
			/// <term>Indicates a network storage device.</term>
			/// </item>
			/// </list>
			/// <para>The following values are possible when the <c>Category</c> member is set to <c>WCN_VALUE_DT_CATEGORY_NETWORK_INFRASTRUCTURE</c>.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_NETWORK_INFRASTRUCUTURE_AP 0x1</term>
			/// <term>Indicates an access point.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_NETWORK_INFRASTRUCUTURE_ROUTER 0x2</term>
			/// <term>Indicates a router.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_NETWORK_INFRASTRUCUTURE_SWITCH 0x3</term>
			/// <term>Indicates a switch.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_NETWORK_INFRASTRUCUTURE_GATEWAY 0x4</term>
			/// <term>Indicates a gateway.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_NETWORK_INFRASTRUCUTURE_BRIDGE 0x5</term>
			/// <term>Indicates a bridge.</term>
			/// </item>
			/// </list>
			/// <para>The following values are possible when the <c>Category</c> member is set to <c>WCN_VALUE_DT_CATEGORY_DISPLAY</c>.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_DISPLAY_TELEVISION 0x1</term>
			/// <term>Indicates a television.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_DISPLAY_PICTURE_FRAME 0x2</term>
			/// <term>Indicates an electronic picture frame.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_DISPLAY_PROJECTOR 0x3</term>
			/// <term>Indicates a digital projector.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_DISPLAY_MONITOR 0x4</term>
			/// <term>Indicates a monitor.</term>
			/// </item>
			/// </list>
			/// <para>The following values are possible when the <c>Category</c> member is set to <c>WCN_VALUE_DT_CATEGORY_MULTIMEDIA_DEVICE</c>.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_MULTIMEDIA_DEVICE_DAR 0x1</term>
			/// <term>Indicates a digital audio recorder.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_MULTIMEDIA_DEVICE_PVR 0x2</term>
			/// <term>Indicates a personal video recorder.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_MULTIMEDIA_DEVICE_MCX 0x3</term>
			/// <term>Indicates a Yamaha Digital Multimedia Receiver.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_MULTIMEDIA_DEVICE_SETTOPBOX 0x4</term>
			/// <term>Indicates a set-top box.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_MULTIMEDIA_DEVICE_MEDIA_SERVER_ADAPT_EXT 0x5</term>
			/// <term>Indicates a media server, media adapter, or media extender.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_MULTIMEDIA_DEVICE_PVP 0x6</term>
			/// <term>Indicates a portable video player.</term>
			/// </item>
			/// </list>
			/// <para>The following values are possible when the <c>Category</c> member is set to <c>WCN_VALUE_DT_CATEGORY_GAMING_DEVICE</c>.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_GAMING_DEVICE_XBOX 0x1</term>
			/// <term>Indicates a Microsoft XBOX console.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_GAMING_DEVICE_XBOX360 0x2</term>
			/// <term>Indicates a Microsoft XBOX 360 console.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_GAMING_DEVICE_PLAYSTATION 0x3</term>
			/// <term>Indicates a Sony Playstation 3.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_GAMING_DEVICE_CONSOLE_ADAPT 0x4</term>
			/// <term>Indicates a game console adapter.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_GAMING_DEVICE_PORTABLE 0x5</term>
			/// <term>Indicates a portable gaming device.</term>
			/// </item>
			/// </list>
			/// <para>The following values are possible when the <c>Category</c> member is set to <c>WCN_VALUE_DT_CATEGORY_TELEPHONE</c>.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_TELEPHONE_WINDOWS_MOBILE 0x1</term>
			/// <term>Indicates a Windows Mobile device.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_TELEPHONE_PHONE_SINGLEMODE 0x2</term>
			/// <term>Indicates a single-mode phone.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_TELEPHONE_PHONE_DUALMODE 0x3</term>
			/// <term>Indicates a dual-mode phone.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_TELEPHONE_PHONE_SMARTPHONE_SINGLEMODE 0x4</term>
			/// <term>Indicates a single-mode smartphone.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_TELEPHONE_PHONE_SMARTPHONE_DUALMODE 0x2</term>
			/// <term>Indicates a dual-mode smartphone.</term>
			/// </item>
			/// </list>
			/// <para>The following values are possible when the <c>Category</c> member is set to <c>WCN_VALUE_DT_CATEGORY_AUDIO_DEVICE</c>.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_AUDIO_DEVICE_TUNER_RECEIVER 0x1</term>
			/// <term>Indicates an audio tuner/receiver.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_AUDIO_DEVICE_SPEAKERS 0x2</term>
			/// <term>Indicates speakers.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_AUDIO_DEVICE_PMP 0x2</term>
			/// <term>Indicates a personal media player.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_AUDIO_DEVICE_HEADSET 0x2</term>
			/// <term>Indicates a headset.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_AUDIO_DEVICE_HEADPHONES 0x2</term>
			/// <term>Indicates headphones.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_AUDIO_DEVICE_MICROPHONE 0x2</term>
			/// <term>Indicates a microphone.</term>
			/// </item>
			/// <item>
			/// <term>WCN_VALUE_DT_SUBTYPE_AUDIO_DEVICE_HOMETHEATER 0x2</term>
			/// <term>Indicates a home theater system.</term>
			/// </item>
			/// </list>
			/// </summary>
			public WCN_VALUE_TYPE_DEVICE_TYPE_SUBCATEGORY SubCategory;
		}
	}
}