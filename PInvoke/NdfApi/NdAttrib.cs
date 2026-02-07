namespace Vanara.PInvoke;

public static partial class NdfApi
{
	/// <summary>The <c>ATTRIBUTE_TYPE</c> enumeration defines possible values for a helper attribute.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndattrib/ne-ndattrib-attribute_type typedef enum tagATTRIBUTE_TYPE { AT_INVALID = 0,
	// AT_BOOLEAN, AT_INT8, AT_UINT8, AT_INT16, AT_UINT16, AT_INT32, AT_UINT32, AT_INT64, AT_UINT64, AT_STRING, AT_GUID, AT_LIFE_TIME,
	// AT_SOCKADDR, AT_OCTET_STRING } ATTRIBUTE_TYPE;
	[PInvokeData("ndattrib.h", MSDNShortId = "NE:ndattrib.tagATTRIBUTE_TYPE")]
	public enum ATTRIBUTE_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>An invalid attribute.</para>
		/// </summary>
		AT_INVALID,

		/// <summary>A true or false value.</summary>
		AT_BOOLEAN,

		/// <summary>An 8-bit signed integer.</summary>
		AT_INT8,

		/// <summary>An 8-bit unsigned integer.</summary>
		AT_UINT8,

		/// <summary>A 16-bit signed integer.</summary>
		AT_INT16,

		/// <summary>A 16-bit unsigned integer.</summary>
		AT_UINT16,

		/// <summary>A 32-bit signed integer.</summary>
		AT_INT32,

		/// <summary>A 32-bit unsigned integer.</summary>
		AT_UINT32,

		/// <summary>A 64-bit signed integer.</summary>
		AT_INT64,

		/// <summary>A 64-bit unsigned integer.</summary>
		AT_UINT64,

		/// <summary>A string.</summary>
		AT_STRING,

		/// <summary>A GUID structure.</summary>
		AT_GUID,

		/// <summary>A LifeTime structure.</summary>
		AT_LIFE_TIME,

		/// <summary>An IPv4 or IPv6 address.</summary>
		AT_SOCKADDR,

		/// <summary>A byte array.</summary>
		AT_OCTET_STRING,
	}

	/// <summary>A numeric value that provides more information about the problem.</summary>
	[PInvokeData("ndattrib.h", MSDNShortId = "NS:ndattrib.tagRootCauseInfo")]
	[Flags]
	public enum RCF : uint
	{
		/// <summary>
		/// The root cause corresponds to a leaf in the diagnostics tree. Root causes that are leafs are more likely to be closer to the
		/// problem that the user is trying to diagnose.
		/// </summary>
		RCF_ISLEAF = 0x1,

		/// <summary>
		/// The root cause corresponds to a node with a DIAGNOSIS_STATUS value of <c>DS_CONFIRMED</c>. Problems with confirmed low health are
		/// more likely to correspond to the problem the user is trying to diagnose.
		/// </summary>
		RCF_ISCONFIRMED = 0x2,

		/// <summary>The root cause comes from a third-party helper class extension rather than a native Windows helper class.</summary>
		RCF_ISTHIRDPARTY = 0x4,
	}

	/// <summary>Additional information about the repair.</summary>
	[PInvokeData("ndattrib.h", MSDNShortId = "NS:ndattrib.tagRepairInfo")]
	[Flags]
	public enum REPAIR_FLAG : uint
	{
		/// <summary>
		/// Indicates that the repair is a workaround for the issue. For example, sometimes resetting a network interface solves intermittent
		/// problems, but does not directly address a specific issue, so it is considered a workaround. NDF will show non-workarounds to the
		/// user before workarounds.
		/// </summary>
		RF_WORKAROUND = 0x20000000,

		/// <summary>Indicates that the repair prompts the user to perform a manual task outside of NDF.</summary>
		RF_USER_ACTION = 0x10000000,

		/// <summary>Indicates that the repair should not be automatically performed. The user is instead prompted to select the repair.</summary>
		RF_USER_CONFIRMATION = 0x8000000,

		/// <summary>
		/// Indicates that the repair consists of actionable information for the user. Repair and validation sessions do not occur for
		/// information-only repairs.
		/// </summary>
		RF_INFORMATION_ONLY = 0x2000000,

		/// <summary/>
		RF_UI_ONLY = 0x1000000,

		/// <summary/>
		RF_SHOW_EVENTS = 0x800000,

		/// <summary>
		/// Indicates that the repair provides information to the user as well as a help topic. Unlike <c>RF_INFORMATION_ONLY</c> repairs,
		/// which cannot be validated, this repair can be executed and validated within a diagnostic session.
		/// </summary>
		RF_VALIDATE_HELPTOPIC = 0x400000,

		/// <summary>
		/// Indicates that the repair prompts the user to reproduce their problem. At the same time, the helper class may have enabled more
		/// detailed logging or other background mechanisms to help detect the failure.
		/// </summary>
		RF_REPRO = 0x200000,

		/// <summary>Indicates that the repair prompts the user to contact their network administrator in order to resolve the problem.</summary>
		RF_CONTACT_ADMIN = 0x20000,

		/// <summary>Reserved for system use.</summary>
		DF_TRACELESS = 0x40000000,

		/// <summary>Reserved for system use.</summary>
		DF_IMPERSONATION = 0x80000000,

		/// <summary>Reserved for system use.</summary>
		RF_RESERVED_LNI = 0x10000,
	}

	/// <summary>The <c>REPAIR_RISK</c> enumeration specifies whether repair changes are persistent and whether they can be undone.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndattrib/ne-ndattrib-repair_risk typedef enum
	// __MIDL___MIDL_itf_ndattrib_0000_0000_0002 { RR_NOROLLBACK = 0, RR_ROLLBACK, RR_NORISK } REPAIR_RISK;
	[PInvokeData("ndattrib.h", MSDNShortId = "NE:ndattrib.__MIDL___MIDL_itf_ndattrib_0000_0000_0002")]
	public enum REPAIR_RISK
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The repair performs persistent changes that cannot be undone.</para>
		/// </summary>
		RR_NOROLLBACK,

		/// <summary>The repair performs persistent changes that can be undone.</summary>
		RR_ROLLBACK,

		/// <summary>The repair does not perform persistent changes.</summary>
		RR_NORISK,
	}

	/// <summary>The <c>REPAIR_SCOPE</c> enumeration describes the scope of modification for a given repair.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndattrib/ne-ndattrib-repair_scope typedef enum tagREPAIR_SCOPE { RS_SYSTEM = 0,
	// RS_USER, RS_APPLICATION, RS_PROCESS } REPAIR_SCOPE, *PREPAIR_SCOPE;
	[PInvokeData("ndattrib.h", MSDNShortId = "NE:ndattrib.tagREPAIR_SCOPE")]
	public enum REPAIR_SCOPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The repair effect is system-wide.</para>
		/// </summary>
		RS_SYSTEM,

		/// <summary>The repair effect is user-specific.</summary>
		RS_USER,

		/// <summary>The repair effect is application-specific.</summary>
		RS_APPLICATION,

		/// <summary>The repair effect is process-specific.</summary>
		RS_PROCESS,
	}

	/// <summary>The <c>UI_INFO_TYPE</c> enumeration identifies repairs that perform user interface tasks.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndattrib/ne-ndattrib-ui_info_type typedef enum
	// __MIDL___MIDL_itf_ndattrib_0000_0000_0003 { UIT_INVALID = 0, UIT_NONE = 1, UIT_SHELL_COMMAND, UIT_HELP_PANE, UIT_DUI } UI_INFO_TYPE;
	[PInvokeData("ndattrib.h", MSDNShortId = "NE:ndattrib.__MIDL___MIDL_itf_ndattrib_0000_0000_0003")]
	public enum UI_INFO_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// </summary>
		UIT_INVALID,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No additional repair interfaces are present.</para>
		/// </summary>
		UIT_NONE,

		/// <summary>Execute shell command.</summary>
		UIT_SHELL_COMMAND,

		/// <summary>Launch help pane.</summary>
		UIT_HELP_PANE,

		/// <summary>Direct UI.</summary>
		UIT_DUI,
	}

	/// <summary>
	/// The <c>WCN_ATTRIBUTE_TYPE</c> enumeration defines the attribute buffer types defined for Wi-Fi Protected Setup. The overall size
	/// occupied by each attribute buffer includes an additional 4 bytes (2 bytes of ID, 2 bytes of Length).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcntypes/ne-wcntypes-wcn_attribute_type typedef enum tagWCN_ATTRIBUTE_TYPE {
	// WCN_TYPE_AP_CHANNEL = 0, WCN_TYPE_ASSOCIATION_STATE, WCN_TYPE_AUTHENTICATION_TYPE, WCN_TYPE_AUTHENTICATION_TYPE_FLAGS,
	// WCN_TYPE_AUTHENTICATOR, WCN_TYPE_CONFIG_METHODS, WCN_TYPE_CONFIGURATION_ERROR, WCN_TYPE_CONFIRMATION_URL4, WCN_TYPE_CONFIRMATION_URL6,
	// WCN_TYPE_CONNECTION_TYPE, WCN_TYPE_CONNECTION_TYPE_FLAGS, WCN_TYPE_CREDENTIAL, WCN_TYPE_DEVICE_NAME, WCN_TYPE_DEVICE_PASSWORD_ID,
	// WCN_TYPE_E_HASH1, WCN_TYPE_E_HASH2, WCN_TYPE_E_SNONCE1, WCN_TYPE_E_SNONCE2, WCN_TYPE_ENCRYPTED_SETTINGS, WCN_TYPE_ENCRYPTION_TYPE,
	// WCN_TYPE_ENCRYPTION_TYPE_FLAGS, WCN_TYPE_ENROLLEE_NONCE, WCN_TYPE_FEATURE_ID, WCN_TYPE_IDENTITY, WCN_TYPE_IDENTITY_PROOF,
	// WCN_TYPE_KEY_WRAP_AUTHENTICATOR, WCN_TYPE_KEY_IDENTIFIER, WCN_TYPE_MAC_ADDRESS, WCN_TYPE_MANUFACTURER, WCN_TYPE_MESSAGE_TYPE,
	// WCN_TYPE_MODEL_NAME, WCN_TYPE_MODEL_NUMBER, WCN_TYPE_NETWORK_INDEX, WCN_TYPE_NETWORK_KEY, WCN_TYPE_NETWORK_KEY_INDEX,
	// WCN_TYPE_NEW_DEVICE_NAME, WCN_TYPE_NEW_PASSWORD, WCN_TYPE_OOB_DEVICE_PASSWORD, WCN_TYPE_OS_VERSION, WCN_TYPE_POWER_LEVEL,
	// WCN_TYPE_PSK_CURRENT, WCN_TYPE_PSK_MAX, WCN_TYPE_PUBLIC_KEY, WCN_TYPE_RADIO_ENABLED, WCN_TYPE_REBOOT, WCN_TYPE_REGISTRAR_CURRENT,
	// WCN_TYPE_REGISTRAR_ESTABLISHED, WCN_TYPE_REGISTRAR_LIST, WCN_TYPE_REGISTRAR_MAX, WCN_TYPE_REGISTRAR_NONCE, WCN_TYPE_REQUEST_TYPE,
	// WCN_TYPE_RESPONSE_TYPE, WCN_TYPE_RF_BANDS, WCN_TYPE_R_HASH1, WCN_TYPE_R_HASH2, WCN_TYPE_R_SNONCE1, WCN_TYPE_R_SNONCE2,
	// WCN_TYPE_SELECTED_REGISTRAR, WCN_TYPE_SERIAL_NUMBER, WCN_TYPE_WI_FI_PROTECTED_SETUP_STATE, WCN_TYPE_SSID, WCN_TYPE_TOTAL_NETWORKS,
	// WCN_TYPE_UUID_E, WCN_TYPE_UUID_R, WCN_TYPE_VENDOR_EXTENSION, WCN_TYPE_VERSION, WCN_TYPE_X_509_CERTIFICATE_REQUEST,
	// WCN_TYPE_X_509_CERTIFICATE, WCN_TYPE_EAP_IDENTITY, WCN_TYPE_MESSAGE_COUNTER, WCN_TYPE_PUBLIC_KEY_HASH, WCN_TYPE_REKEY_KEY,
	// WCN_TYPE_KEY_LIFETIME, WCN_TYPE_PERMITTED_CONFIG_METHODS, WCN_TYPE_SELECTED_REGISTRAR_CONFIG_METHODS, WCN_TYPE_PRIMARY_DEVICE_TYPE,
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
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a value containing
		/// data that specifies the 802.11 channel the access point is hosting.
		/// </para>
		/// </summary>
		WCN_TYPE_AP_CHANNEL,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a value containing
		/// the association state or configuration information defined by WCN_VALUE_TYPE_ASSOCIATION_STATE.
		/// </para>
		/// </summary>
		WCN_TYPE_ASSOCIATION_STATE,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a value containing
		/// an authentication type defined by WCN_VALUE_TYPE_AUTHENTICATION_TYPE.
		/// </para>
		/// </summary>
		WCN_TYPE_AUTHENTICATION_TYPE,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a value containing
		/// data that specifies the network authentication capabilities of the Enrollee (access point or station) by providing a value
		/// defined byWCN_VALUE_TYPE_AUTHENTICATION_TYPE
		/// </para>
		/// <para>.</para>
		/// </summary>
		WCN_TYPE_AUTHENTICATION_TYPE_FLAGS,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a buffer containing a
		/// keyed hash of data.
		/// </para>
		/// <para><c>Note</c> Security is handled transparently by Windows. As a result, applications do not need to query or set this attribute.</para>
		/// </summary>
		WCN_TYPE_AUTHENTICATOR,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains values,
		/// defined by WCN_VALUE_TYPE_CONFIG_METHODS, that specify the configuration methods supported by the Enrollee or Registrar.
		/// Additionally, access points and stations that support the UPnP Management Interface must also support this attribute, which is
		/// used to control the configuration methods that are enabled on the access point.
		/// </para>
		/// </summary>
		WCN_TYPE_CONFIG_METHODS,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a value, defined by
		/// WCN_VALUE_TYPE_CONFIGURATION_ERROR, that specifies the result of the device attempting to configure itself and associate with the WLAN.
		/// </para>
		/// <para>
		/// If a configuration session fails with the error code WCN_E_CONNECTION_REJECTED, any error code returned by the remote device can
		/// be obtained by querying this attribute. It is important to note that some devices will return WCN_VALUE_CE_NO_ERROR even if an
		/// error has occurred.
		/// </para>
		/// </summary>
		WCN_TYPE_CONFIGURATION_ERROR,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a buffer that
		/// contains data representing the URL (IPv4 address based) provided by the Registrar to the Enrollee for use in posting confirmation
		/// once settings have been successfully applied and the network has been joined. This configurationparameter is optional for a
		/// Registrar, and it is optional for the Enrollee to post to the URL if the Registrar includes it.
		/// </para>
		/// <para><c>Note</c> An Enrollee must not connect to a confirmation URL that is on a different subnet.</para>
		/// </summary>
		WCN_TYPE_CONFIRMATION_URL4,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a buffer that
		/// contains data representing the URL (IPv6 address based) provided by the Registrar to the Enrollee for use in posting a
		/// confirmation once settings have been successfully applied and the network has been joined. This configurationparameter is
		/// optional for a Registrar and it is optional for the Enrollee to post to the URL if the Registrar includes it.
		/// </para>
		/// <para><c>Note</c> The Enrollee must not connect to a confirmation URL that is on a different subnet.</para>
		/// </summary>
		WCN_TYPE_CONFIRMATION_URL6,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains a value,
		/// defined by WCN_VALUE_TYPE_CONNECTION_TYPE, that specifies the connection capability of the Enrollee.
		/// </para>
		/// </summary>
		WCN_TYPE_CONNECTION_TYPE,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains a value,
		/// defined by WCN_VALUE_TYPE_CONNECTION_TYPE, that specifies the connection capability of the Enrollee.
		/// </para>
		/// </summary>
		WCN_TYPE_CONNECTION_TYPE_FLAGS,

		/// <summary>
		/// <para>
		/// This compound attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method contains a single WLAN
		/// Credential. There can be either multiple Credential attributes for each Network Key, or multiple Network Keys in a single
		/// Credential attribute, which is accomplished by repeating the Network Key Index and attributes thatfollow it. Generally, multiple
		/// keys in a single Credential for a single SSID should be used, and multiple Credential attributes for separate SSIDs should be
		/// used. The following attributes are contained in each instance of Credential:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>WCN_TYPE_AUTHENTICATION_TYPE</term>
		/// <description></description>
		/// </item>
		/// <item>
		/// <term>WCN_TYPE_ENCRYPTION_TYPE</term>
		/// <description></description>
		/// </item>
		/// <item>
		/// <term>WCN_TYPE_SSID</term>
		/// <description></description>
		/// </item>
		/// <item>
		/// <term>WCN_TYPE_NETWORK_INDEX</term>
		/// <description></description>
		/// </item>
		/// </list>
		/// <para>
		/// If an application intends to use the network credential with the WLAN API, it should use IWCNDevice::GetNetworkProfile to get a
		/// compatible XML network profile directly.
		/// </para>
		/// </summary>
		WCN_TYPE_CREDENTIAL,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a buffer that
		/// contains a user-friendly description of the device encoded in UTF-8. Typically, the component would be a unique identifier that
		/// describes the product in a way that is recognizable to the user.
		/// </para>
		/// </summary>
		WCN_TYPE_DEVICE_NAME,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains a value,
		/// defined by WCN VALUE TYPE DEVICE_PASSWORD_ID, that is used to identify a device password.
		/// </para>
		/// </summary>
		WCN_TYPE_DEVICE_PASSWORD_ID,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method contains the HMAC-SHA-256 hash
		/// of the first half of the device password and the Enrollee’s first secret nonce. <c>Note</c> Security is handled transparently by
		/// Windows. As a result, applications do not need to query or set this attribute.
		/// </para>
		/// </summary>
		WCN_TYPE_E_HASH1,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method contains the HMAC-SHA-256 hash
		/// of the second half of the device password, and the Enrollee’s second secret nonce. <c>Note</c> Security is handled transparently
		/// by Windows. As a result, applications do not need to query or set this attribute.
		/// </para>
		/// </summary>
		WCN_TYPE_E_HASH2,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains the first
		/// nonce used by the Enrollee with the first half of the device password.
		/// </para>
		/// <para><c>Note</c> Security is handled transparently by Windows. As a result, applications do not need to query or set this attribute.</para>
		/// </summary>
		WCN_TYPE_E_SNONCE1,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains the second
		/// nonce used by the Enrollee with the second half of the device password.
		/// </para>
		/// <para><c>Note</c> Security is handled transparently by Windows. As a result, applications do not need to query or set this attribute.</para>
		/// </summary>
		WCN_TYPE_E_SNONCE2,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method contains an initialization
		/// vector (IV) followed by a set of encrypted Wi-Fi Protected Setup TLV attributes. The last attribute in the encrypted set is a Key
		/// WrapAuthenticator computed according to the procedure described in section 6.5.
		/// </para>
		/// <para><c>Note</c> Security is handled transparently by Windows. As a result, applications do not need to query or set this attribute.</para>
		/// </summary>
		WCN_TYPE_ENCRYPTED_SETTINGS,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains a value,
		/// defined by WCN_VALUE_TYPE_ENCRYPTION_TYPE, for the Enrollee (AP or station) to use.
		/// </para>
		/// </summary>
		WCN_TYPE_ENCRYPTION_TYPE,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains a value,
		/// defined by WCN_VALUE_TYPE_ENCRYPTION_TYPE, for the Enrollee (AP or station) to use.
		/// </para>
		/// </summary>
		WCN_TYPE_ENCRYPTION_TYPE_FLAGS,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains a randomly
		/// generated binary value that is created by the Enrollee for setup operations. <c>Note</c> Security is handled transparently by
		/// Windows. As a result, applications do not need to query or set this attribute.
		/// </para>
		/// </summary>
		WCN_TYPE_ENROLLEE_NONCE,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method contains data that
		/// indicates a particular feature build for an operating system running on the device. The most significant bit of the 4 byte
		/// integer is reserved, and always set to one.
		/// </para>
		/// </summary>
		WCN_TYPE_FEATURE_ID,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_IDENTITY,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_IDENTITY_PROOF,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a 8 byte buffer
		/// containing the first 64 bits of the HMAC-SHA-256 computed over the data to be encrypted with the key wrap algorithm. It is
		/// appended to the end of the ConfigData prior to encryption. <c>Note</c> Security is handled transparently by Windows. As a result,
		/// applications do not need to query or set this attribute.
		/// </para>
		/// </summary>
		WCN_TYPE_KEY_WRAP_AUTHENTICATOR,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetAttribute method is a 16 byte buffer containing
		/// a 128-bit key identifier. If this attribute immediately precedes an Encrypted Data or Authenticator attribute, then the key
		/// corresponding to the 128-bit identifier should be used to decryptor verify the Data field.
		/// </para>
		/// </summary>
		WCN_TYPE_KEY_IDENTIFIER,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method is a 6 byte buffer containing
		/// the 48 bit value of the MAC Address. For example: 0x00 0x07 0xE9 0x4C 0xA8 0x1C.This address is supplied by the remote device.
		/// Some Access Points give the MAC address of their Ethernet interface, in which case, the address cannot be used to locate the AP’s
		/// wireless radio. If an application needs to locate an AP’s radio, the application should query the WCN_TYPE_BSSID attribute, which
		/// is populated by Windows and is generally more reliable.
		/// </para>
		/// </summary>
		WCN_TYPE_MAC_ADDRESS,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method is a buffer containing a string
		/// that identifies the manufacturer of the device. Generally, this field should allow a user to make an association with a device
		/// with the labeling on thedevice.
		/// </para>
		/// </summary>
		WCN_TYPE_MANUFACTURER,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_MESSAGE_TYPE,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a buffer that
		/// identifies the model of the device. Generally, this field should allow a user to create an association of a device with the
		/// labeling on the device.
		/// </para>
		/// </summary>
		WCN_TYPE_MODEL_NAME,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a string containing
		/// additional descriptive data associated with the device.
		/// </para>
		/// </summary>
		WCN_TYPE_MODEL_NUMBER,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 1 byte buffer used
		/// to get and set network settings for devices that host more than one network. The default value is '1' which refers to the primary
		/// WLAN network on the device.
		/// </para>
		/// </summary>
		WCN_TYPE_NETWORK_INDEX,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a buffer containing
		/// the wireless encryption key to be used by the Enrollee. Note that it is recommended that applications implement
		/// IWCNDevice::GetNetworkProfileto get network settings in a convenient format that is ready to be used with the WLAN connection and
		/// profile management APIs.
		/// </para>
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
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 4 byte buffer that
		/// contains the operating system version running on the device. The most significant bit of this 4 byte field is reserved, and
		/// always set to one.
		/// </para>
		/// </summary>
		WCN_TYPE_OS_VERSION,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_POWER_LEVEL,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_PSK_CURRENT,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_PSK_MAX,

		/// <summary>
		/// Reserved. Do not use. We recommend that a shared secret be sent by way of a vendor extension or that you find another way to do cryptography.
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
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 16 byte buffer
		/// containing a randomly generated binary value created by the Registrar for setup. <c>Note</c> Security is handled transparently by
		/// Windows. As a result, applications do not need to query or set this attribute.
		/// </para>
		/// </summary>
		WCN_TYPE_REGISTRAR_NONCE,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_REQUEST_TYPE,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_RESPONSE_TYPE,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is an integer value,
		/// defined by WCN_VALUE_TYPE_RF_BANDS, that indicates which REPAIR_FLAG band is utilized during message exchange, permitting end
		/// points and proxies to communicate over a consistent radio interface. It may also be used as an optional attribute in a
		/// WCN_TYPE_CREDENTIAL or WCN_TYPE_ENCRYPTED_SETTINGS to indicate a specific (or group) of REPAIR_FLAG bands to which a setting applies.
		/// </para>
		/// </summary>
		WCN_TYPE_RF_BANDS,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a 32 byte buffer that
		/// containing the HMAC-SHA-256 hash of the first half of the device password and the Registrar’s first secret nonce. <c>Note</c>
		/// Security is handled transparently by Windows. As a result, applications do not need to query or set this attribute.
		/// </para>
		/// </summary>
		WCN_TYPE_R_HASH1,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a 32 byte buffer
		/// containing the HMAC-SHA-256 hash of the second half of the device password and the Registrar’s second secret nonce. <c>Note</c>
		/// Security is handled transparently by Windows. As a result, applications do not need to query or set this attribute.
		/// </para>
		/// </summary>
		WCN_TYPE_R_HASH2,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 16 byte buffer
		/// containing the first nonce used by the Registrar with the first half of the device password.
		/// </para>
		/// <para><c>Note</c> Security is handled transparently by Windows. As a result, applications do not need to query or set this attribute.</para>
		/// </summary>
		WCN_TYPE_R_SNONCE1,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 16 byte buffer
		/// containing the second nonce used by the Registrar with the second half of the device password.
		/// </para>
		/// <para><c>Note</c> Security is handled transparently by Windows. As a result, applications do not need to query or set this attribute.</para>
		/// </summary>
		WCN_TYPE_R_SNONCE2,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is an integer value,
		/// defined by WCN_VALUE_TYPE_BOOLEAN, that indicates if a Registrar has been selected by a user and that an Enrollee can proceed
		/// with setting up an 802.1X uncontrolled data port with the Registrar.
		/// </para>
		/// </summary>
		WCN_TYPE_SELECTED_REGISTRAR,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a string containing
		/// the serial number of the Enrollee.
		/// </para>
		/// <para>
		/// <c>Note</c> Not all devices supply a serial number. Some devices return a string of non-numeric characters, and as a result it is
		/// not always possible to convert this value to a number.
		/// </para>
		/// </summary>
		WCN_TYPE_SERIAL_NUMBER,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method an integer value,
		/// defined by WCN_VALUE_TYPE_WI_FI_PROTECTED_SETUP, that indicates if a device is configured.
		/// </para>
		/// </summary>
		WCN_TYPE_WI_FI_PROTECTED_SETUP_STATE,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the pbData parameter of the IWCNDevice::GetAttribute method is a buffer, up to 32 bytes in
		/// size, containing the Service Set Identifier (SSID) or network name. Instead of querying this attribute, it is recommended that
		/// applications implementIWCNDevice::GetNetworkProfile to retrieve network settings in a convenient format that is ready to be used
		/// with the WLAN connection and profile management APIs.
		/// </para>
		/// </summary>
		WCN_TYPE_SSID,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_TOTAL_NETWORKS,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 16 byte buffer
		/// containing the Universally Unique Identifier (UUID) generated by the Enrollee. It uniquely identifies an operational device and
		/// should survive reboots and resets. The UUID is provided inbinary format. If the device also supports UPnP, then the UUID
		/// corresponds to the UPnP UUID.
		/// </para>
		/// <para>
		/// Instead of querying this attribute, applications should instead query the WCN_TYPE_UUID attribute, as it is available for both
		/// enrollees and registrars. WCN_TYPE_UUID_E_ is only available for devices that act as an enrollee.
		/// </para>
		/// </summary>
		WCN_TYPE_UUID_E,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method is a 16 byte buffer containing
		/// the Universally Unique Identifier (UUID) element generated by the Registrar. It uniquely identifies an operational device and
		/// should survive reboots and resets. The UUID is provided inbinary format. If the device also supports UPnP, then the UUID
		/// corresponds to the UPnP UUID.
		/// </para>
		/// <para>
		/// Instead of querying this attribute, applications should instead query the WCN_TYPE_UUID attribute, as it is available for both
		/// enrollees and registrars.
		/// </para>
		/// </summary>
		WCN_TYPE_UUID_R,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetAttribute method is a buffer, up to 1024 bytes
		/// in size, that permits the use of vendor extensions in the Wi-Fi Protected Setup TLV framework. The Vendor Extension figure
		/// illustrates the implementation of vendor extensions. Vendor ID is the SMI network management private enterprise code.Instead of
		/// querying this value, implementation of the IWCNDevice::GetVendorExtension API is recommended for convenience and flexibility
		/// while accessing the raw vendor extension attribute directly.
		/// </para>
		/// </summary>
		WCN_TYPE_VENDOR_EXTENSION,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is an integer value
		/// that indicates the Wi-Fi Protected Setup version. The one-byte field is broken into a four-bit major part using the top MSBs and
		/// four-bit minor part using the LSBs. As an example, version 3.2 would be 0x32. <c>Note</c> Windows will automatically use the
		/// correct WPS version for each device, so applications are not required to query or set this value.
		/// </para>
		/// <para>
		/// <c>Note</c> When using WPS 2.0, <c>WCN_TYPE_VERSION</c> will always be set to 0x10 and <c>WCN_TYPE_VERSION2</c> is used instead
		/// </para>
		/// </summary>
		WCN_TYPE_VERSION,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method is a buffer containing an X.509
		/// certificate request payload as specified in RFC 2511.
		/// </para>
		/// </summary>
		WCN_TYPE_X_509_CERTIFICATE_REQUEST,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the pbBuffer parameter of the IWCNDevice::GetAttribute method is a buffer containing an X.509 certificate.
		/// </para>
		/// </summary>
		WCN_TYPE_X_509_CERTIFICATE,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_EAP_IDENTITY,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_MESSAGE_COUNTER,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is a 20 byte buffer
		/// containing the first 160 bits of the SHA-256 hash of a public key.
		/// </para>
		/// <para><c>Note</c> Security is handled transparently by Windows. As a result, applications do not need to query or set this attribute.</para>
		/// </summary>
		WCN_TYPE_PUBLIC_KEY_HASH,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_REKEY_KEY,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_KEY_LIFETIME,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is an integer defined
		/// by WCN_VALUE_TYPE_CONFIG_METHODS, that indicates which of the configuration methods supported by the device are enabled.
		/// </para>
		/// </summary>
		WCN_TYPE_PERMITTED_CONFIG_METHODS,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is an integer defined
		/// by WCN_VALUE_TYPE_CONFIG_METHODS, that is used in Probe Response messages to convey the current supported Config Methods of a
		/// specific Registrar.
		/// </para>
		/// </summary>
		WCN_TYPE_SELECTED_REGISTRAR_CONFIG_METHODS,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is an 8 byte buffer
		/// containing values, contained in WCN_VALUE_TYPE_PRIMARY_DEVICE_TYPE, that indicates the primary type of the device. It is
		/// recommended that applications instead query the WCN_TYPE_PRIMARY_DEVICE_TYPE_CATEGORY,
		/// WCN_TYPE_PRIMARY_DEVICE_TYPE_SUBCATEGORY_OUI, and WCN_TYPE_PRIMARY_DEVICE_TYPE_SUBCATEGORY attributes as they are more convenient.
		/// </para>
		/// </summary>
		WCN_TYPE_PRIMARY_DEVICE_TYPE,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_SECONDARY_DEVICE_TYPE_LIST,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_PORTABLE_DEVICE,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a buffer containing
		/// a value, defined by WCN_VALUE_TYPE_BOOLEAN, that indicates if the access point has entered a state in which it will refuse to
		/// allow an external Registrar to attempt to run the Registration Protocol using the AP’s PIN (with the AP acting as Enrollee). The
		/// AP should enter this state if it believes a brute force attack is underway against the AP’s PIN.
		/// </para>
		/// <para>
		/// When the AP is in this state, it MUST continue to allow other Enrollees to connect and run the Registration Protocol with any
		/// external Registrars or the AP’s built-in Registrar (if any). It is only the use of the AP’s PIN for adding external Registrars
		/// that is disabled in this state.
		/// </para>
		/// <para>
		/// The AP Setup Locked state can be reset to FALSE through an authenticated call to SetAPSettings. APs may provide other
		/// implementation-specific methods of resetting the AP Setup Locked state as well.
		/// </para>
		/// </summary>
		WCN_TYPE_AP_SETUP_LOCKED,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the pvBuffer parameter of the IWCNDevice::GetAttribute method is a buffer, up to 512 bytes in
		/// size, used to pass parameters for enabling applications during the WSC exchange. It is similar to the Vendor Extension attribute
		/// except that instead of a 3-byte Vendor ID prefixto the Vendor Data field, a 16-byte UUID (as defined in RFC 4122) is used. This
		/// provides a virtually unlimited application ID space with a regular structure that can be easily mapped onto a generic application
		/// extension API. Furthermore, the 16-byte UUID value can be used to derive application-specific AMSKs as described in Section 6.3
		/// or pass any necessary keying directly.
		/// </para>
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
		/// <para>
		/// This attribute value represents the buffer, up to 128 bytes in size, containing data that indicates an exchange of application
		/// specific session keys and, alternatively, may be used
		/// </para>
		/// <para>to calculate AMSKs.</para>
		/// </summary>
		WCN_TYPE_APPSESSIONKEY,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 1 byte buffer
		/// containing data that identifies the Key Index value used as the Access Point transmit key for WEP configurations.
		/// </para>
		/// </summary>
		WCN_TYPE_WEPTRANSMITKEY,

		/// <summary>
		/// <para>
		/// This compound attribute indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 16 byte buffer
		/// that contains data that is always equal to the UUID of the device, regardless if the device is enrollee or registrar.
		/// (Effectively, merges WCN_TYPE_UUID_E and WCN_TYPE_UUID_R).
		/// </para>
		/// </summary>
		WCN_TYPE_UUID,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute is an integer that represents
		/// the major device category of a WCN device. The major device category is one of the WCN_VALUE_TYPE_DEVICE_TYPE_CATEGORY values.
		/// </para>
		/// </summary>
		WCN_TYPE_PRIMARY_DEVICE_TYPE_CATEGORY,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute is an integer that represents
		/// the OUI that defines the device subcategory of a WCN device. The most common OUI is WCN_VALUE_DT_SUBTYPE_WIFI_OUI which indicates
		/// that the subcategory is defined by the Wi-Fi Alliance.
		/// </para>
		/// </summary>
		WCN_TYPE_PRIMARY_DEVICE_TYPE_SUBCATEGORY_OUI,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute is an integer that represents
		/// the device subcategory of a WCN device. The subcategory must be interpreted along with the OUI from
		/// WCN_TYPE_PRIMARY_DEVICE_TYPE_SUBCATEGORY_OUI. For devices using the Wi-Fi Alliance OUI. The subcategory is one of the
		/// WCN_VALUE_TYPE_DEVICE_TYPE_SUBCATEGORY values.
		/// </para>
		/// </summary>
		WCN_TYPE_PRIMARY_DEVICE_TYPE_SUBCATEGORY,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the wszString parameter of the IWCNDevice::GetStringAttribute method is buffer, up to 32
		/// bytes in size, containing the current SSID of a wireless access point.
		/// </para>
		/// </summary>
		WCN_TYPE_CURRENT_SSID,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_BSSID,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_DOT11_MAC_ADDRESS,

		/// <summary>
		/// <para>
		/// . This attribute value indicates that a registrar is providing a list of MAC addresses that are authorized to start WSC. the
		/// pbBuffer parameter of the IWCNDevice::GetAttribute method is a 6-30 byte buffer containing the 48 bit value of each MAC Address
		/// in the list of authorized MACs. For example: 0x00 0x07 0xE9 0x4C 0xA8 0x1C.
		/// </para>
		/// <para><c>Note</c> Only available in Windows 8.</para>
		/// </summary>
		WCN_TYPE_AUTHORIZED_MACS,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 1 byte buffer used
		/// to get and set network settings for devices that host more than one network. A value of '1' indicates that the Network Key may be
		/// shared with other devices.
		/// </para>
		/// <para><c>Note</c> Only available in Windows 8.</para>
		/// </summary>
		WCN_TYPE_NETWORK_KEY_SHAREABLE,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_REQUEST_TO_ENROLL,

		/// <summary>Reserved. Do not use.</summary>
		WCN_TYPE_REQUESTED_DEVICE_TYPE,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is a 1 byte buffer
		/// indicating the estimated length of time (in seconds) that an access point will require to reconfigure itself and become
		/// available, or that a device will require to apply settings and connect to a network.
		/// </para>
		/// <para><c>Note</c> Only available in Windows 8.</para>
		/// </summary>
		WCN_TYPE_SETTINGS_DELAY_TIME,

		/// <summary>
		/// <para>
		/// This attribute value indicates that the puInteger parameter of the IWCNDevice::GetIntegerAttribute method is an integer value
		/// that indicates the Wi-Fi Protected Setup version. The one-byte field is broken into a four-bit major part using the top MSBs and
		/// four-bit minor part using the LSBs. As an example, version 3.2 would be 0x32. <c>Note</c> Windows will automatically use the
		/// correct WPS version for each device, so applications are not required to query or set this value.
		/// </para>
		/// <para><c>Note</c> Only available in Windows 8.</para>
		/// </summary>
		WCN_TYPE_VERSION2,

		/// <summary>
		/// <para>Reserved. Do not use.</para>
		/// <para><c>Note</c> The attributes within the WFA vendor extension may be queried directly.</para>
		/// </summary>
		WCN_TYPE_VENDOR_EXTENSION_WFA,

		/// <summary>The number of assigned attributes.</summary>
		WCN_NUM_ATTRIBUTE_TYPES,
	}

	/// <summary>
	/// The <c>DIAG_SOCKADDR</c> structure stores an Internet Protocol (IP) address for a computer that is participating in a Windows Sockets communication.
	/// </summary>
	/// <remarks>This data structure is designed to be used as a <c>SOCKADDR</c> structure.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndattrib/ns-ndattrib-diag_sockaddr typedef struct tagSOCK_ADDR { USHORT family;
	// CHAR data[126]; } DIAG_SOCKADDR, *PDIAG_SOCK_ADDR;
	[PInvokeData("ndattrib.h", MSDNShortId = "NS:ndattrib.tagSOCK_ADDR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DIAG_SOCKADDR
	{
		/// <summary>
		/// <para>Type: <c>USHORT</c></para>
		/// <para>Socket address group.</para>
		/// </summary>
		public ADDRESS_FAMILY family;

		/// <summary>
		/// <para>Type: <c>CHAR[126]</c></para>
		/// <para>The maximum size of all the different socket address structures.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 126)]
		public byte[] data;
	}

	/// <summary>The <c>HELPER_ATTRIBUTE</c> structure contains all NDF supported data types.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndattrib/ns-ndattrib-helper_attribute typedef struct tagHELPER_ATTRIBUTE { StrPtrUni
	// pwszName; ATTRIBUTE_TYPE type; union { BOOL Boolean; char Char; byte Byte; short Short; WORD Word; int Int; DWORD DWord; LONGLONG
	// Int64; ULONGLONG UInt64; StrPtrUni PWStr; GUID Guid; LIFE_TIME LifeTime; DIAG_SOCKADDR Address; OCTET_STRING OctetString; }; }
	// HELPER_ATTRIBUTE, *PHELPER_ATTRIBUTE;
	[PInvokeData("ndattrib.h", MSDNShortId = "NS:ndattrib.tagHELPER_ATTRIBUTE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HELPER_ATTRIBUTE
	{
		/// <summary>
		/// <para>Type: <c>[string] StrPtrUni</c></para>
		/// <para>A pointer to a null-terminated string that contains the name of the attribute.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszName;

		/// <summary>
		/// <para>Type: <c>ATTRIBUTE_TYPE</c></para>
		/// <para>The type of helper attribute.</para>
		/// </summary>
		public ATTRIBUTE_TYPE type;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A True or False value. Used when <c>type</c> is <c>AT_BOOLEAN</c>.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool Boolean;

		/// <summary>
		/// <para>Type: <c>char</c></para>
		/// <para>A character value. Used when <c>type</c> is <c>AT_INT8</c>.</para>
		/// </summary>
		public byte Char;

		/// <summary>
		/// <para>Type: <c>byte</c></para>
		/// <para>A byte value. Used when <c>type</c> is <c>AT_UINT8</c>.</para>
		/// </summary>
		public byte Byte;

		/// <summary>
		/// <para>Type: <c>short</c></para>
		/// <para>A 16-bit signed value. Used when <c>type</c> is <c>AT_INT16</c></para>
		/// </summary>
		public short Short;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>A 2-byte unsigned value. Used when <c>type</c> is <c>AT_UINT16</c>.</para>
		/// </summary>
		public ushort Word;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>A 4-byte signed value. Used when <c>type</c> is <c>AT_INT32</c>.</para>
		/// </summary>
		public int Int;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A 4-byte unsigned value. Used when <c>type</c> is <c>AT_UINT32</c>.</para>
		/// </summary>
		public uint DWord;

		/// <summary>
		/// <para>Type: <c>LONGLONG</c></para>
		/// <para>A 64-bit signed integer value. Used when <c>type</c> is <c>AT_INT64</c>.</para>
		/// </summary>
		public long Int64;

		/// <summary>
		/// <para>Type: <c>ULONGLONG</c></para>
		/// <para>A 64-bit unsigned integer value. Used when <c>type</c> is <c>AT_UINT64</c>.</para>
		/// </summary>
		public ulong UInt64;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>A null-terminated string value. Used when <c>type</c> is <c>AT_STRING</c>.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string PWStr;

		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>A GUID structure. Used when <c>type</c> is <c>AT_GUID</c>.</para>
		/// </summary>
		public Guid Guid;

		/// <summary>
		/// <para>Type: <c>LIFE_TIME</c></para>
		/// <para>A LIFE_TIME structure. Used when <c>type</c> is <c>AT_LIFE_TIME</c>.</para>
		/// </summary>
		public LIFE_TIME LifeTime;

		/// <summary>
		/// <para>Type: <c>DIAG_SOCKADDR</c></para>
		/// <para>An IPv4 or IPv6 address. Used when <c>type</c> is <c>AT_SOCKADDR</c>.</para>
		/// </summary>
		public DIAG_SOCKADDR Address;

		/// <summary>
		/// <para>Type: <c>OCTET_STRING</c></para>
		/// <para>A byte array for undefined types. Used when <c>type</c> is <c>AT_OCTET_STRING</c>.</para>
		/// </summary>
		public OCTET_STRING OctetString;
	}

	/// <summary>The <c>LIFE_TIME</c> structure contains a start time and an end time.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndattrib/ns-ndattrib-life_time typedef struct tagLIFE_TIME { FILETIME startTime;
	// FILETIME endTime; } LIFE_TIME, *PLIFE_TIME;
	[PInvokeData("ndattrib.h", MSDNShortId = "NS:ndattrib.tagLIFE_TIME")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct LIFE_TIME
	{
		/// <summary>
		/// <para>Type: <c>FILETIME</c></para>
		/// <para>The time the problem instance began.</para>
		/// </summary>
		public FILETIME startTime;

		/// <summary>
		/// <para>Type: <c>FILETIME</c></para>
		/// <para>The time the problem instance ended.</para>
		/// </summary>
		public FILETIME endTime;
	}

	/// <summary>The <c>OCTET_STRING</c> structure contains a pointer to a string of byte data.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndattrib/ns-ndattrib-octet_string typedef struct tagOCTET_STRING { DWORD dwLength;
	// BYTE *lpValue; } OCTET_STRING, *POCTET_STRING;
	[PInvokeData("ndattrib.h", MSDNShortId = "NS:ndattrib.tagOCTET_STRING")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct OCTET_STRING
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The length of the data.</para>
		/// </summary>
		public uint dwLength;

		/// <summary>
		/// <para>Type: <c>[size_is(dwLength)]BYTE*</c></para>
		/// <para>A pointer to the byte array containing the data.</para>
		/// </summary>
		public IntPtr lpValue;
	}

	/// <summary>The <c>RepairInfo</c> structure contains data required for a particular repair option.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndattrib/ns-ndattrib-repairinfo typedef struct tagRepairInfo { GUID guid; StrPtrUni
	// pwszClassName; StrPtrUni pwszDescription; DWORD sidType; long cost; ULONG flags; REPAIR_SCOPE scope; REPAIR_RISK risk; UiInfo UiInfo; int
	// rootCauseIndex; } RepairInfo, *PRepairInfo;
	[PInvokeData("ndattrib.h", MSDNShortId = "NS:ndattrib.tagRepairInfo")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RepairInfo
	{
		/// <summary>A unique GUID for this repair.</summary>
		public Guid guid;

		/// <summary>A pointer to a null-terminated string that contains the helper class name in a user-friendly way.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszClassName;

		/// <summary>A pointer to a null-terminated string that describes the repair in a user friendly way.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszDescription;

		/// <summary>One of the WELL_KNOWN_SID_TYPE if the repair requires certain user contexts or privileges.</summary>
		public AdvApi32.WELL_KNOWN_SID_TYPE sidType;

		/// <summary>The number of seconds required to perform the repair.</summary>
		public long cost;

		/// <summary>
		/// <para>Additional information about the repair.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>RF_WORKAROUND</c></term>
		/// <term>
		/// Indicates that the repair is a workaround for the issue. For example, sometimes resetting a network interface solves intermittent
		/// problems, but does not directly address a specific issue, so it is considered a workaround. NDF will show non-workarounds to the
		/// user before workarounds.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>RF_USER_ACTION</c></term>
		/// <term>Indicates that the repair prompts the user to perform a manual task outside of NDF.</term>
		/// </item>
		/// <item>
		/// <term><c>RF_USER_CONFIRMATION</c></term>
		/// <term>Indicates that the repair should not be automatically performed. The user is instead prompted to select the repair.</term>
		/// </item>
		/// <item>
		/// <term><c>RF_INFORMATION_ONLY</c></term>
		/// <term>
		/// Indicates that the repair consists of actionable information for the user. Repair and validation sessions do not occur for
		/// information-only repairs.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>RF_VALIDATE_HELPTOPIC</c></term>
		/// <term>
		/// Indicates that the repair provides information to the user as well as a help topic. Unlike <c>RF_INFORMATION_ONLY</c> repairs,
		/// which cannot be validated, this repair can be executed and validated within a diagnostic session.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>RF_REPRO</c></term>
		/// <term>
		/// Indicates that the repair prompts the user to reproduce their problem. At the same time, the helper class may have enabled more
		/// detailed logging or other background mechanisms to help detect the failure.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>RF_CONTACT_ADMIN</c></term>
		/// <term>Indicates that the repair prompts the user to contact their network administrator in order to resolve the problem.</term>
		/// </item>
		/// <item>
		/// <term><c>RF_RESERVED</c></term>
		/// <term>Reserved for system use.</term>
		/// </item>
		/// <item>
		/// <term><c>RF_RESERVED_CA</c></term>
		/// <term>Reserved for system use.</term>
		/// </item>
		/// <item>
		/// <term><c>RF_RESERVED_LNI</c></term>
		/// <term>Reserved for system use.</term>
		/// </item>
		/// </list>
		/// </summary>
		public REPAIR_FLAG flags;

		/// <summary>Reserved for future use.</summary>
		public REPAIR_SCOPE scope;

		/// <summary>Reserved for future use.</summary>
		public REPAIR_RISK risk;

		/// <summary>A UiInfo structure.</summary>
		public UiInfo UiInfo;

		/// <summary/>
		public int rootCauseIndex;
	}

	/// <summary>Contains detailed repair information that can be used to help resolve the root cause of an incident.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndattrib/ns-ndattrib-repairinfoex typedef struct tagRepairInfoEx { RepairInfo
	// repair; USHORT repairRank; } RepairInfoEx, *PRepairInfoEx;
	[PInvokeData("ndattrib.h", MSDNShortId = "NS:ndattrib.tagRepairInfoEx")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RepairInfoEx
	{
		/// <summary>
		/// <para>Type: <c>RepairInfo</c></para>
		/// <para>The detailed repair information.</para>
		/// </summary>
		public RepairInfo repair;

		/// <summary>
		/// <para>Type: <c>USHORT</c></para>
		/// <para>
		/// The rank of the repair, relative to other repairs in the RootCauseInfo structure associated with the incident. A repair with rank
		/// 1 is expected to be more relevant to the problem and thus will be the first repair to be attempted. The success of any individual
		/// repair is not guaranteed, regardless of its rank.
		/// </para>
		/// </summary>
		public ushort repairRank;
	}

	/// <summary>Contains detailed information about the root cause of an incident.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndattrib/ns-ndattrib-rootcauseinfo typedef struct tagRootCauseInfo { StrPtrUni
	// pwszDescription; GUID rootCauseID; DWORD rootCauseFlags; GUID networkInterfaceID; RepairInfoEx *pRepairs; USHORT repairCount; }
	// RootCauseInfo, *PRootCauseInfo;
	[PInvokeData("ndattrib.h", MSDNShortId = "NS:ndattrib.tagRootCauseInfo")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RootCauseInfo
	{
		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>A string that describes the problem that caused the incident.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszDescription;

		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>The GUID that corresponds to the problem identified.</para>
		/// </summary>
		public Guid rootCauseID;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A numeric value that provides more information about the problem.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>RCF_ISLEAF</c> 0x1</term>
		/// <term>
		/// The root cause corresponds to a leaf in the diagnostics tree. Root causes that are leafs are more likely to be closer to the
		/// problem that the user is trying to diagnose.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>RCF_ISCONFIRMED</c> 0x2</term>
		/// <term>
		/// The root cause corresponds to a node with a DIAGNOSIS_STATUS value of <c>DS_CONFIRMED</c>. Problems with confirmed low health are
		/// more likely to correspond to the problem the user is trying to diagnose.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>RCF_ISTHIRDPARTY</c> 0x4</term>
		/// <term>The root cause comes from a third-party helper class extension rather than a native Windows helper class.</term>
		/// </item>
		/// </list>
		/// </summary>
		public RCF rootCauseFlags;

		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>
		/// GUID of the network interface on which the problem occurred. If the problem is not interface-specific, this value is zero (0).
		/// </para>
		/// </summary>
		public Guid networkInterfaceID;

		/// <summary>
		/// <para>Type: <c>RepairInfoEx*</c></para>
		/// <para>The repairs that are available to try and fix the problem.</para>
		/// </summary>
		public IntPtr pRepairs;

		/// <summary>
		/// <para>Type: <c>USHORT</c></para>
		/// <para>The number of repairs available.</para>
		/// </summary>
		public ushort repairCount;
	}

	/// <summary>The <c>ShellCommandInfo</c> structure contains data required to launch an additional application for manual repair options.</summary>
	/// <remarks>
	/// <para>
	/// In the case of a manual repair option, the caller can use this structure to call the ShellExecute function to launch an additional
	/// application that can help the user to repair the problem.
	/// </para>
	/// <para>The following verbs are used in connection with <c>pwszOperation</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Term</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>edit</term>
	/// <term>Launches an editor and opens the document for editing. If <c>pwszFile</c> is not a document file, the function fails.</term>
	/// </item>
	/// <item>
	/// <term>explore</term>
	/// <term>Explores the folder specified by the <c>pwszFile</c> parameter.</term>
	/// </item>
	/// <item>
	/// <term>find</term>
	/// <term>Initiates a search starting from the specified directory.</term>
	/// </item>
	/// <item>
	/// <term>open</term>
	/// <term>Opens the file specified by the <c>pwszFile</c> parameter. The file can be an executable file, a document file, or a folder.</term>
	/// </item>
	/// <item>
	/// <term>print</term>
	/// <term>
	/// Prints the document file specified by the <c>pwszFile</c> parameter. If <c>pwszFile</c> is not a document file, the function fails.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>Used when other verbs do not apply.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndattrib/ns-ndattrib-shellcommandinfo typedef struct tagShellCommandInfo { StrPtrUni
	// pwszOperation; StrPtrUni pwszFile; StrPtrUni pwszParameters; StrPtrUni pwszDirectory; ULONG nShowCmd; } ShellCommandInfo, *PShellCommandInfo;
	[PInvokeData("ndattrib.h", MSDNShortId = "NS:ndattrib.tagShellCommandInfo")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ShellCommandInfo
	{
		/// <summary>
		/// <para>Type: <c>[string] StrPtrUni</c></para>
		/// <para>
		/// A pointer to a null-terminated string that contains the action to be performed. The set of available verbs that specifies the
		/// action depends on the particular file or folder. Generally, the actions available from an object's shortcut menu are available
		/// verbs. For more information, see the Remarks section.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszOperation;

		/// <summary>
		/// <para>Type: <c>[string] StrPtrUni</c></para>
		/// <para>
		/// A pointer to a null-terminated string that specifies the file or object on which to execute the specified verb. To specify a
		/// Shell namespace object, pass the fully qualified parse name. Note that not all verbs are supported on all objects. For example,
		/// not all document types support the "print" verb.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszFile;

		/// <summary>
		/// <para>Type: <c>[string] StrPtrUni</c></para>
		/// <para>
		/// A pointer to a null-terminated strings that specifies the parameters to be passed to the application, only if the <c>pwszFile</c>
		/// parameter specifies an executable file. The format of this string is determined by the verb that is to be invoked. If
		/// <c>pwszFile</c> specifies a document file, <c>pwszParameters</c> should be <c>NULL</c>.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszParameters;

		/// <summary>
		/// <para>Type: <c>[string] StrPtrUni</c></para>
		/// <para>A pointer to a null-terminated string that specifies the default directory.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszDirectory;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>
		/// Flags that specify how an application is to be displayed when it is opened. If <c>pwszFile</c> specifies a document file, the
		/// flag is simply passed to the associated application. It is up to the application to decide how to handle it.
		/// </para>
		/// </summary>
		public ShowWindowCommand nShowCmd;
	}

	/// <summary>The <c>UiInfo</c> structure is used to display repair messages to the user.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndattrib/ns-ndattrib-uiinfo typedef struct tagUiInfo { UI_INFO_TYPE type; union {
	// StrPtrUni pwzNull; ShellCommandInfo ShellInfo; StrPtrUni pwzHelpUrl; StrPtrUni pwzDui; }; } UiInfo, *PUiInfo;
	[PInvokeData("ndattrib.h", MSDNShortId = "NS:ndattrib.tagUiInfo")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct UiInfo
	{
		/// <summary>
		/// <para>Type: <c>UI_INFO_TYPE</c></para>
		/// <para>The type of user interface (UI) to use. This can be one of the values shown in the following members.</para>
		/// </summary>
		public UI_INFO_TYPE type;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>No additional UI is required. Used when <c>type</c> is set to UIT_NONE.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzNull;

		/// <summary>
		/// <para>Type: <c>ShellCommandInfo</c></para>
		/// <para>Execute a shell command. Used when <c>type</c> is set to UIT_SHELL_COMMAND.</para>
		/// </summary>
		public ShellCommandInfo ShellInfo;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Launches a help pane. Used when <c>type</c> is set to UIT_HELP_PANE.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzHelpUrl;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>Use a direct user interface. Used when <c>type</c> is set to UIT_DUI.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzDui;
	}
}