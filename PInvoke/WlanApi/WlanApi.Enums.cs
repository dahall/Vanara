namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from wlanapi.h.</summary>
public static partial class WlanApi
{
	// L2 reason codes from l2cmn.h
	private const uint L2_REASON_CODE_DOT11_AC_BASE = (L2_REASON_CODE_GEN_BASE + L2_REASON_CODE_GROUP_SIZE);

	private const uint L2_REASON_CODE_DOT11_MSM_BASE = (L2_REASON_CODE_DOT11_AC_BASE + L2_REASON_CODE_GROUP_SIZE);

	private const uint L2_REASON_CODE_DOT11_SECURITY_BASE = (L2_REASON_CODE_DOT11_MSM_BASE + L2_REASON_CODE_GROUP_SIZE);

	private const uint L2_REASON_CODE_DOT3_AC_BASE = (L2_REASON_CODE_ONEX_BASE + L2_REASON_CODE_GROUP_SIZE);

	private const uint L2_REASON_CODE_DOT3_MSM_BASE = (L2_REASON_CODE_DOT3_AC_BASE + L2_REASON_CODE_GROUP_SIZE);

	private const uint L2_REASON_CODE_GEN_BASE = 0x10000;

	private const uint L2_REASON_CODE_GROUP_SIZE = 0x10000;

	private const uint L2_REASON_CODE_IHV_BASE = (L2_REASON_CODE_PROFILE_BASE + L2_REASON_CODE_GROUP_SIZE);

	private const uint L2_REASON_CODE_ONEX_BASE = (L2_REASON_CODE_DOT11_SECURITY_BASE + L2_REASON_CODE_GROUP_SIZE);

	private const uint L2_REASON_CODE_PROFILE_BASE = (L2_REASON_CODE_DOT3_MSM_BASE + L2_REASON_CODE_GROUP_SIZE);

	private const uint L2_REASON_CODE_RESERVED_BASE = (L2_REASON_CODE_WIMAX_BASE + L2_REASON_CODE_GROUP_SIZE);

	private const uint L2_REASON_CODE_SUCCESS = 0;

	private const uint L2_REASON_CODE_UNKNOWN = (L2_REASON_CODE_GEN_BASE + 1);

	private const uint L2_REASON_CODE_WIMAX_BASE = (L2_REASON_CODE_IHV_BASE + L2_REASON_CODE_GROUP_SIZE);

	/// <summary>The <c>DOT11_AUTH_ALGORITHM</c> enumerated type defines a wireless LAN authentication algorithm.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/nativewifi/dot11-auth-algorithm typedef enum _DOT11_AUTH_ALGORITHM {
	// DOT11_AUTH_ALGO_80211_OPEN = 1, DOT11_AUTH_ALGO_80211_SHARED_KEY = 2, DOT11_AUTH_ALGO_WPA = 3, DOT11_AUTH_ALGO_WPA_PSK = 4,
	// DOT11_AUTH_ALGO_WPA_NONE = 5, DOT11_AUTH_ALGO_RSNA = 6, DOT11_AUTH_ALGO_RSNA_PSK = 7, DOT11_AUTH_ALGO_IHV_START = 0x80000000,
	// DOT11_AUTH_ALGO_IHV_END = 0xffffffff } DOT11_AUTH_ALGORITHM, *PDOT11_AUTH_ALGORITHM;
	[PInvokeData("windot11.h", MSDNShortId = "ac4097df-46dc-4c64-b72a-7cb9dce8b418")]
	// public enum DOT11_AUTH_ALGORITHM{DOT11_AUTH_ALGO_80211_OPEN = 1, DOT11_AUTH_ALGO_80211_SHARED_KEY = 2, DOT11_AUTH_ALGO_WPA = 3,
	// DOT11_AUTH_ALGO_WPA_PSK = 4, DOT11_AUTH_ALGO_WPA_NONE = 5, DOT11_AUTH_ALGO_RSNA = 6, DOT11_AUTH_ALGO_RSNA_PSK = 7,
	// DOT11_AUTH_ALGO_IHV_START = 0x80000000, DOT11_AUTH_ALGO_IHV_END = 0xffffffff, DOT11_AUTH_ALGORITHM, *PDOT11_AUTH_ALGORITHM}
	public enum DOT11_AUTH_ALGORITHM : uint
	{
		/// <summary>Specifies an IEEE 802.11 Open System authentication algorithm.</summary>
		DOT11_AUTH_ALGO_80211_OPEN = 1,

		/// <summary>
		/// Specifies an 802.11 Shared Key authentication algorithm that requires the use of a pre-shared Wired Equivalent Privacy (WEP)
		/// key for the 802.11 authentication.
		/// </summary>
		DOT11_AUTH_ALGO_80211_SHARED_KEY,

		/// <summary>
		/// <para>
		/// Specifies a Wi-Fi Protected Access (WPA) algorithm. IEEE 802.1X port authentication is performed by the supplicant,
		/// authenticator, and authentication server. Cipher keys are dynamically derived through the authentication process.
		/// </para>
		/// <para>This algorithm is valid only for BSS types of dot11_BSS_type_infrastructure.</para>
		/// <para>
		/// When the WPA algorithm is enabled, the 802.11 station will associate only with an access point whose beacon or probe
		/// responses contain the authentication suite of type 1 (802.1X) within the WPA information element (IE).
		/// </para>
		/// </summary>
		DOT11_AUTH_ALGO_WPA,

		/// <summary>
		/// <para>
		/// Specifies a WPA algorithm that uses preshared keys (PSK). IEEE 802.1X port authentication is performed by the supplicant and
		/// authenticator. Cipher keys are dynamically derived through a preshared key that is used on both the supplicant and authenticator.
		/// </para>
		/// <para>This algorithm is valid only for BSS types of <c>dot11_BSS_type_infrastructure</c>.</para>
		/// <para>
		/// When the WPA PSK algorithm is enabled, the 802.11 station will associate only with an access point whose beacon or probe
		/// responses contain the authentication suite of type 2 (preshared key) within the WPA IE.
		/// </para>
		/// </summary>
		DOT11_AUTH_ALGO_WPA_PSK,

		/// <summary>This value is not supported.</summary>
		DOT11_AUTH_ALGO_WPA_NONE,

		/// <summary>
		/// <para>
		/// Specifies an 802.11i Robust Security Network Association (RSNA) algorithm. WPA2 is one such algorithm. IEEE 802.1X port
		/// authentication is performed by the supplicant, authenticator, and authentication server. Cipher keys are dynamically derived
		/// through the authentication process.
		/// </para>
		/// <para>This algorithm is valid only for BSS types of <c>dot11_BSS_type_infrastructure</c>.</para>
		/// <para>
		/// When the RSNA algorithm is enabled, the 802.11 station will associate only with an access point whose beacon or probe
		/// responses contain the authentication suite of type 1 (802.1X) within the RSN IE.
		/// </para>
		/// </summary>
		DOT11_AUTH_ALGO_RSNA,

		/// <summary>
		/// <para>
		/// Specifies an 802.11i RSNA algorithm that uses PSK. IEEE 802.1X port authentication is performed by the supplicant and
		/// authenticator. Cipher keys are dynamically derived through a preshared key that is used on both the supplicant and authenticator.
		/// </para>
		/// <para>This algorithm is valid only for BSS types of <c>dot11_BSS_type_infrastructure</c>.</para>
		/// <para>
		/// When the RSNA PSK algorithm is enabled, the 802.11 station will associate only with an access point whose beacon or probe
		/// responses contain the authentication suite of type 2(preshared key) within the RSN IE.
		/// </para>
		/// </summary>
		DOT11_AUTH_ALGO_RSNA_PSK,

		/// <summary>
		/// <para>Indicates the start of the range that specifies proprietary authentication algorithms that are developed by an IHV.</para>
		/// <para>
		/// The <c>DOT11_AUTH_ALGO_IHV_START</c> enumerator is valid only when the miniport driver is operating in Extensible Station
		/// (ExtSTA) mode.
		/// </para>
		/// </summary>
		DOT11_AUTH_ALGO_IHV_START = 0x80000000,

		/// <summary>
		/// <para>Indicates the end of the range that specifies proprietary authentication algorithms that are developed by an IHV.</para>
		/// <para>The <c>DOT11_AUTH_ALGO_IHV_END</c> enumerator is valid only when the miniport driver is operating in ExtSTA mode.</para>
		/// </summary>
		DOT11_AUTH_ALGO_IHV_END = 0xffffffff,
	}

	/// <summary>The <c>DOT11_BSS_TYPE</c> enumerated type defines a basic service set (BSS) network type.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/nativewifi/dot11-bss-type typedef enum _DOT11_BSS_TYPE {
	// dot11_BSS_type_infrastructure = 1, dot11_BSS_type_independent = 2, dot11_BSS_type_any = 3 } DOT11_BSS_TYPE, *PDOT11_BSS_TYPE;
	[PInvokeData("windot11.h", MSDNShortId = "13d57339-655e-4978-974e-e7b12a83d18a")]
	public enum DOT11_BSS_TYPE
	{
		/// <summary>Specifies an infrastructure BSS network.</summary>
		dot11_BSS_type_infrastructure = 1,

		/// <summary>Specifies an independent BSS (IBSS) network.</summary>
		dot11_BSS_type_independent,

		/// <summary>Specifies either infrastructure or IBSS network.</summary>
		dot11_BSS_type_any,
	}

	/// <summary>The <c>DOT11_CIPHER_ALGORITHM</c> enumerated type defines a cipher algorithm for data encryption and decryption.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/nativewifi/dot11-cipher-algorithm typedef enum _DOT11_CIPHER_ALGORITHM {
	// DOT11_CIPHER_ALGO_NONE = 0x00, DOT11_CIPHER_ALGO_WEP40 = 0x01, DOT11_CIPHER_ALGO_TKIP = 0x02, DOT11_CIPHER_ALGO_CCMP = 0x04,
	// DOT11_CIPHER_ALGO_WEP104 = 0x05, DOT11_CIPHER_ALGO_WPA_USE_GROUP = 0x100, DOT11_CIPHER_ALGO_RSN_USE_GROUP = 0x100,
	// DOT11_CIPHER_ALGO_WEP = 0x101, DOT11_CIPHER_ALGO_IHV_START = 0x80000000, DOT11_CIPHER_ALGO_IHV_END = 0xffffffff }
	// DOT11_CIPHER_ALGORITHM, *PDOT11_CIPHER_ALGORITHM;
	[PInvokeData("windot11.h", MSDNShortId = "6b634d76-a159-438e-8fc6-5f05b326ed68")]
	public enum DOT11_CIPHER_ALGORITHM : uint
	{
		/// <summary>Specifies that no cipher algorithm is enabled or supported.</summary>
		DOT11_CIPHER_ALGO_NONE = 0x00,

		/// <summary>
		/// Specifies a Wired Equivalent Privacy (WEP) algorithm, which is the RC4-based algorithm that is specified in the 802.11-1999
		/// standard. This enumerator specifies the WEP cipher algorithm with a 40-bit cipher key.
		/// </summary>
		DOT11_CIPHER_ALGO_WEP40 = 0x01,

		/// <summary>
		/// Specifies a Temporal Key Integrity Protocol (TKIP) algorithm, which is the RC4-based cipher suite that is based on the
		/// algorithms that are defined in the WPA specification and IEEE 802.11i-2004 standard. This cipher also uses the Michael
		/// Message Integrity Code (MIC) algorithm for forgery protection.
		/// </summary>
		DOT11_CIPHER_ALGO_TKIP = 0x02,

		/// <summary>
		/// Specifies an AES-CCMP algorithm, as specified in the IEEE 802.11i-2004 standard and RFC 3610. Advanced Encryption Standard
		/// (AES) is the encryption algorithm defined in FIPS PUB 197.
		/// </summary>
		DOT11_CIPHER_ALGO_CCMP = 0x04,

		/// <summary>Specifies a WEP cipher algorithm with a 104-bit cipher key.</summary>
		DOT11_CIPHER_ALGO_WEP104 = 0x05,

		/// <summary>
		/// Specifies a Wi-Fi Protected Access (WPA) Use Group Key cipher suite. For more information about the Use Group Key cipher
		/// suite, refer to Clause 7.3.2.25.1 of the IEEE 802.11i-2004 standard.
		/// </summary>
		DOT11_CIPHER_ALGO_WPA_USE_GROUP = 0x100,

		/// <summary>
		/// Specifies a Robust Security Network (RSN) Use Group Key cipher suite. For more information about the Use Group Key cipher
		/// suite, refer to Clause 7.3.2.25.1 of the IEEE 802.11i-2004 standard.
		/// </summary>
		DOT11_CIPHER_ALGO_RSN_USE_GROUP = 0x100,

		/// <summary>Specifies a WEP cipher algorithm with a cipher key of any length.</summary>
		DOT11_CIPHER_ALGO_WEP = 0x101,

		/// <summary>
		/// Specifies the start of the range that is used to define proprietary cipher algorithms that are developed by an independent
		/// hardware vendor (IHV).
		/// </summary>
		DOT11_CIPHER_ALGO_IHV_START = 0x80000000,

		/// <summary>
		/// Specifies the end of the range that is used to define proprietary cipher algorithms that are developed by an IHV.
		/// </summary>
		DOT11_CIPHER_ALGO_IHV_END = 0xffffffff,
	}

	/// <summary>A bitmask of the miniport driver's supported operation modes.</summary>
	[PInvokeData("windot11.h", MSDNShortId = "e20eb9a3-5824-48ee-b13e-b0252bbf495e")]
	[Flags]
	public enum DOT11_OPERATION_MODE : uint
	{
		/// <summary/>
		DOT11_OPERATION_MODE_UNKNOWN = 0x00000000,

		/// <summary/>
		DOT11_OPERATION_MODE_STATION = 0x00000001,

		/// <summary/>
		DOT11_OPERATION_MODE_AP = 0x00000002,

		/// <summary>Specifies that the miniport driver supports the Extensible Station (ExtSTA) operation mode.</summary>
		DOT11_OPERATION_MODE_EXTENSIBLE_STATION = 0x00000004,

		/// <summary>Specifies that the miniport driver supports the Extensible Access Point (ExtAP) operation mode.</summary>
		DOT11_OPERATION_MODE_EXTENSIBLE_AP = 0x00000008,

		/// <summary/>
		DOT11_OPERATION_MODE_WFD_DEVICE = 0x00000010,

		/// <summary/>
		DOT11_OPERATION_MODE_WFD_GROUP_OWNER = 0x00000020,

		/// <summary/>
		DOT11_OPERATION_MODE_WFD_CLIENT = 0x00000040,

		/// <summary/>
		DOT11_OPERATION_MODE_MANUFACTURING = 0x40000000,

		/// <summary>Specifies that the miniport driver supports the Network Monitor (NetMon) operation mode.</summary>
		DOT11_OPERATION_MODE_NETWORK_MONITOR = 0x80000000,
	}

	/// <summary>The <c>DOT11_PHY_TYPE</c> enumeration defines an 802.11 PHY and media type.</summary>
	/// <remarks>
	/// An IHV can assign a value for its proprietary PHY types from <c>dot11_phy_type_IHV_start</c> through
	/// <c>dot11_phy_type_IHV_end</c>. The IHV must assign a unique number from this range for each of its proprietary PHY types.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/nativewifi/dot11-phy-type typedef enum _DOT11_PHY_TYPE { dot11_phy_type_unknown =
	// 0, dot11_phy_type_any = 0, dot11_phy_type_fhss = 1, dot11_phy_type_dsss = 2, dot11_phy_type_irbaseband = 3, dot11_phy_type_ofdm =
	// 4, dot11_phy_type_hrdsss = 5, dot11_phy_type_erp = 6, dot11_phy_type_ht = 7, dot11_phy_type_vht = 8, dot11_phy_type_IHV_start =
	// 0x80000000, dot11_phy_type_IHV_end = 0xffffffff } DOT11_PHY_TYPE, *PDOT11_PHY_TYPE;
	[PInvokeData("windot11.h", MSDNShortId = "f3804e57-c633-4288-9749-2b267b1353ae")]
	public enum DOT11_PHY_TYPE : uint
	{
		/// <summary>Specifies an unknown or uninitialized PHY type.</summary>
		dot11_phy_type_unknown = 0,

		/// <summary>Specifies any PHY type.</summary>
		dot11_phy_type_any = 0,

		/// <summary>
		/// Specifies a frequency-hopping spread-spectrum (FHSS) PHY. Bluetooth devices can use FHSS or an adaptation of FHSS.
		/// </summary>
		dot11_phy_type_fhss = 1,

		/// <summary>Specifies a direct sequence spread spectrum (DSSS) PHY type.</summary>
		dot11_phy_type_dsss,

		/// <summary>Specifies an infrared (IR) baseband PHY type.</summary>
		dot11_phy_type_irbaseband,

		/// <summary>Specifies an orthogonal frequency division multiplexing (OFDM) PHY type. 802.11a devices can use OFDM.</summary>
		dot11_phy_type_ofdm,

		/// <summary>Specifies a high-rate DSSS (HRDSSS) PHY type.</summary>
		dot11_phy_type_hrdsss,

		/// <summary>Specifies an extended rate PHY type (ERP). 802.11g devices can use ERP.</summary>
		dot11_phy_type_erp,

		/// <summary>Specifies the 802.11n PHY type.</summary>
		dot11_phy_type_ht,

		/// <summary>
		/// <para>Specifies the 802.11ac PHY type. This is the very high throughput PHY type specified in IEEE 802.11ac.</para>
		/// <para>This value is supported on Windows 8.1, Windows Server 2012 R2, and later.</para>
		/// </summary>
		dot11_phy_type_vht,

		/// <summary>
		/// Specifies the start of the range that is used to define PHY types that are developed by an independent hardware vendor (IHV).
		/// </summary>
		dot11_phy_type_IHV_start = 0x80000000,

		/// <summary>
		/// Specifies the start of the range that is used to define PHY types that are developed by an independent hardware vendor (IHV).
		/// </summary>
		dot11_phy_type_IHV_end = 0xffffffff,
	}

	/// <summary>The <c>DOT11_RADIO_STATE</c> enumeration specifies an 802.11 radio state.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-dot11_radio_state~r1 typedef enum _DOT11_RADIO_STATE {
	// dot11_radio_state_unknown, dot11_radio_state_on, dot11_radio_state_off } DOT11_RADIO_STATE, *PDOT11_RADIO_STATE;
	[PInvokeData("wlanapi.h")]
	public enum DOT11_RADIO_STATE
	{
		/// <summary/>
		dot11_radio_state_unknown,

		/// <summary/>
		dot11_radio_state_on,

		/// <summary/>
		dot11_radio_state_off
	}

	/// <summary>Specifies the active tab when the wireless profile user interface dialog box appears.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wl_display_pages typedef enum _WL_DISPLAY_PAGES {
	// WLConnectionPage, WLSecurityPage, WLAdvPage } WL_DISPLAY_PAGES, *PWL_DISPLAY_PAGES;
	[PInvokeData("wlanapi.h", MSDNShortId = "040433b7-9204-4462-a8fd-7b65bcd1880b")]
	public enum WL_DISPLAY_PAGES
	{
		/// <summary>Displays the Connection tab.</summary>
		WLConnectionPage,

		/// <summary>Displays the Security tab.</summary>
		WLSecurityPage,

		/// <summary/>
		WLAdvPage,
	}

	/// <summary>The access mask of the object.</summary>
	[PInvokeData("wlanapi.h", MSDNShortId = "5e14a70c-c049-4cd1-8675-2b01ed11463f")]
	public enum WLAN_ACCCESS : uint
	{
		/// <summary>The caller can view the object's permissions.</summary>
		WLAN_READ_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_READ | 1U /*FILE_READ_DATA*/,

		/// <summary>
		/// The caller can read from and execute the object. WLAN_EXECUTE_ACCESS has the same value as the bitwise OR combination
		/// WLAN_READ_ACCESS | WLAN_EXECUTE_ACCESS.
		/// </summary>
		WLAN_EXECUTE_ACCESS = WLAN_READ_ACCESS | ACCESS_MASK.STANDARD_RIGHTS_EXECUTE | 32 /*FILE_EXECUTE*/,

		/// <summary>
		/// The caller can read from, execute, and write to the object. WLAN_WRITE_ACCESS has the same value as the bitwise OR
		/// combination WLAN_READ_ACCESS | WLAN_EXECUTE_ACCESS | WLAN_WRITE_ACCESS.
		/// </summary>
		WLAN_WRITE_ACCESS = WLAN_READ_ACCESS | WLAN_EXECUTE_ACCESS | ACCESS_MASK.STANDARD_RIGHTS_WRITE | 2 /*FILE_WRITE_DATA*/ | ACCESS_MASK.DELETE | ACCESS_MASK.WRITE_DAC,
	}

	/// <summary>The <c>WLAN_ADHOC_NETWORK_STATE</c> enumerated type specifies the connection state of an ad hoc network.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_adhoc_network_state~r1 typedef enum
	// _WLAN_ADHOC_NETWORK_STATE { wlan_adhoc_network_state_formed, wlan_adhoc_network_state_connected } WLAN_ADHOC_NETWORK_STATE, *PWLAN_ADHOC_NETWORK_STATE;
	[PInvokeData("wlanapi.h")]
	public enum WLAN_ADHOC_NETWORK_STATE
	{
		/// <summary/>
		wlan_adhoc_network_state_formed = 0,

		/// <summary/>
		wlan_adhoc_network_state_connected
	}

	/// <summary>The <c>WLAN_AUTOCONF_OPCODE</c> enumerated type specifies an automatic configuration parameter.</summary>
	/// <remarks>
	/// <para>
	/// The <c>WLAN_AUTOCONF_OPCODE</c> enumerated type is used by the Auto Configuration Module (ACM), the wireless configuration
	/// component supported on Windows Vista and later.
	/// </para>
	/// <para>
	/// The <c>WLAN_AUTOCONF_OPCODE</c> specifies the possible values for the OpCode parameter passed to the
	/// WlanQueryAutoConfigParameter and WlanSetAutoConfigParameter functions.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_autoconf_opcode~r1 typedef enum _WLAN_AUTOCONF_OPCODE
	// { wlan_autoconf_opcode_start, wlan_autoconf_opcode_show_denied_networks, wlan_autoconf_opcode_power_setting,
	// wlan_autoconf_opcode_only_use_gp_profiles_for_allowed_networks, wlan_autoconf_opcode_allow_explicit_creds,
	// wlan_autoconf_opcode_block_period, wlan_autoconf_opcode_allow_virtual_station_extensibility, wlan_autoconf_opcode_end }
	// WLAN_AUTOCONF_OPCODE, *PWLAN_AUTOCONF_OPCODE;
	[PInvokeData("wlanapi.h")]
	public enum WLAN_AUTOCONF_OPCODE
	{
		/// <summary/>
		wlan_autoconf_opcode_start,

		/// <summary/>
		[CorrespondingType(typeof(BOOL))]
		wlan_autoconf_opcode_show_denied_networks,

		/// <summary/>
		[CorrespondingType(typeof(WLAN_POWER_SETTING), CorrespondingAction.Get)]
		wlan_autoconf_opcode_power_setting,

		/// <summary/>
		[CorrespondingType(typeof(BOOL), CorrespondingAction.Get)]
		wlan_autoconf_opcode_only_use_gp_profiles_for_allowed_networks,

		/// <summary/>
		[CorrespondingType(typeof(BOOL))]
		wlan_autoconf_opcode_allow_explicit_creds,

		/// <summary/>
		[CorrespondingType(typeof(uint))]
		wlan_autoconf_opcode_block_period,

		/// <summary/>
		[CorrespondingType(typeof(BOOL))]
		wlan_autoconf_opcode_allow_virtual_station_extensibility,

		/// <summary/>
		wlan_autoconf_opcode_end
	}

	/// <summary>Available network flags.</summary>
	[PInvokeData("wlanapi.h", MSDNShortId = "82883cea-515b-426d-9961-c144ce99b3db")]
	[Flags]
	public enum WLAN_AVAILABLE_NETWORK_FLAGS
	{
		/// <summary>This network is currently connected.</summary>
		WLAN_AVAILABLE_NETWORK_CONNECTED = 0x00000001,

		/// <summary>There is a profile for this network.</summary>
		WLAN_AVAILABLE_NETWORK_HAS_PROFILE = 0x00000002,

		/// <summary/>
		WLAN_AVAILABLE_NETWORK_CONSOLE_USER_PROFILE = 0x00000004,

		/// <summary/>
		WLAN_AVAILABLE_NETWORK_INTERWORKING_SUPPORTED = 0x00000008,

		/// <summary/>
		WLAN_AVAILABLE_NETWORK_HOTSPOT2_ENABLED = 0x00000010,

		/// <summary/>
		WLAN_AVAILABLE_NETWORK_ANQP_SUPPORTED = 0x00000020,

		/// <summary/>
		WLAN_AVAILABLE_NETWORK_HOTSPOT2_DOMAIN = 0x00000040,

		/// <summary/>
		WLAN_AVAILABLE_NETWORK_HOTSPOT2_ROAMING = 0x00000080,

		/// <summary/>
		WLAN_AVAILABLE_NETWORK_AUTO_CONNECT_FAILED = 0x00000100,
	}

	/// <summary>Flags used to specify the connection parameters.</summary>
	[PInvokeData("wlanapi.h", MSDNShortId = "e0321447-b89a-4f4e-929e-eb6db76f7283")]
	[Flags]
	public enum WLAN_CONNECTION_FLAGS
	{
		/// <summary>
		/// Connect to the destination network even if the destination is a hidden network. A hidden network does not broadcast its
		/// SSID. Do not use this flag if the destination network is an ad-hoc network.If the profile specified by strProfile is not
		/// NULL, then this flag is ignored and the nonBroadcast profile element determines whether to connect to a hidden network.
		/// </summary>
		WLAN_CONNECTION_HIDDEN_NETWORK = 0x00000001,

		/// <summary>
		/// Do not form an ad-hoc network. Only join an ad-hoc network if the network already exists. Do not use this flag if the
		/// destination network is an infrastructure network.
		/// </summary>
		WLAN_CONNECTION_ADHOC_JOIN_ONLY = 0x00000002,

		/// <summary>
		/// Ignore the privacy bit when connecting to the network. Ignoring the privacy bit has the effect of ignoring whether packets
		/// are encrypted and ignoring the method of encryption used. Only use this flag when connecting to an infrastructure network
		/// using a temporary profile.
		/// </summary>
		WLAN_CONNECTION_IGNORE_PRIVACY_BIT = 0x00000004,

		/// <summary>
		/// Exempt EAPOL traffic from encryption and decryption. This flag is used when an application must send EAPOL traffic over an
		/// infrastructure network that uses Open authentication and WEP encryption. This flag must not be used to connect to networks
		/// that require 802.1X authentication. This flag is only valid when wlanConnectionMode is set to
		/// wlan_connection_mode_temporary_profile. Avoid using this flag whenever possible.
		/// </summary>
		WLAN_CONNECTION_EAPOL_PASSTHROUGH = 0x00000008,

		/// <summary>
		/// Automatically persist discovery profile on successful connection completion. This flag is only valid for
		/// wlan_connection_mode_discovery_secure or wlan_connection_mode_discovery_unsecure. The profile will be saved as an all user
		/// profile, with the name generated from the SSID using WlanUtf8SsidToDisplayName. If there is already a profile with the same
		/// name, a number will be appended to the end of the profile name. The profile will be saved with manual connection mode,
		/// unless WLAN_CONNECTION_PERSIST_DISCOVERY_PROFILE_CONNECTION_MODE_AUTO is also specified.
		/// </summary>
		WLAN_CONNECTION_PERSIST_DISCOVERY_PROFILE = 0x00000010,

		/// <summary>
		/// To be used in conjunction with WLAN_CONNECTION_PERSIST_DISCOVERY_PROFILE. The discovery profile will be persisted with
		/// automatic connection mode.
		/// </summary>
		WLAN_CONNECTION_PERSIST_DISCOVERY_PROFILE_CONNECTION_MODE_AUTO = 0x00000020,

		/// <summary>
		/// To be used in conjunction with WLAN_CONNECTION_PERSIST_DISCOVERY_PROFILE. The discovery profile will be persisted and
		/// attempt to overwrite an existing profile with the same name.
		/// </summary>
		WLAN_CONNECTION_PERSIST_DISCOVERY_PROFILE_OVERWRITE_EXISTING = 0x00000040,
	}

	/// <summary>
	/// The <c>WLAN_CONNECTION_MODE</c> enumerated type defines the mode of connection. <c>Windows XP with SP3 and Wireless LAN API for
	/// Windows XP with SP2:</c> Only the <c>wlan_connection_mode_profile</c> value is supported.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_connection_mode typedef enum _WLAN_CONNECTION_MODE {
	// wlan_connection_mode_profile, wlan_connection_mode_temporary_profile, wlan_connection_mode_discovery_secure,
	// wlan_connection_mode_discovery_unsecure, wlan_connection_mode_auto, wlan_connection_mode_invalid } WLAN_CONNECTION_MODE, *PWLAN_CONNECTION_MODE;
	[PInvokeData("wlanapi.h", MSDNShortId = "d62e863f-2aa8-49b1-9e27-8d9d053026f0")]
	public enum WLAN_CONNECTION_MODE
	{
		/// <summary>A profile will be used to make the connection.</summary>
		wlan_connection_mode_profile,

		/// <summary>A temporary profile will be used to make the connection.</summary>
		wlan_connection_mode_temporary_profile,

		/// <summary>Secure discovery will be used to make the connection.</summary>
		wlan_connection_mode_discovery_secure,

		/// <summary>Unsecure discovery will be used to make the connection.</summary>
		wlan_connection_mode_discovery_unsecure,

		/// <summary>The connection is initiated by the wireless service automatically using a persistent profile.</summary>
		wlan_connection_mode_auto,

		/// <summary>Not used.</summary>
		wlan_connection_mode_invalid,
	}

	/// <summary>
	/// <para>A set of flags that provide additional information for the network connection.</para>
	/// </summary>
	[PInvokeData("wlanapi.h", MSDNShortId = "005af5ef-994d-425a-be4b-54567a733fb3")]
	[Flags]
	public enum WLAN_CONNECTION_NOTIFICATION
	{
		/// <term>Indicates that an adhoc network is formed.</term>
		WLAN_CONNECTION_NOTIFICATION_ADHOC_NETWORK_FORMED = 1,

		/// <term>
		/// Indicates that the connection uses a per-user profile owned by the console user. Non-console users will not be able to see
		/// the profile in their profile list.
		/// </term>
		WLAN_CONNECTION_NOTIFICATION_CONSOLE_USER_PROFILE = 4
	}

	/// <summary>The <c>WLAN_FILTER_LIST_TYPE</c> enumerated type indicates types of filter lists.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_filter_list_type typedef enum _WLAN_FILTER_LIST_TYPE {
	// wlan_filter_list_type_gp_permit, wlan_filter_list_type_gp_deny, wlan_filter_list_type_user_permit,
	// wlan_filter_list_type_user_deny } WLAN_FILTER_LIST_TYPE, *PWLAN_FILTER_LIST_TYPE;
	[PInvokeData("wlanapi.h", MSDNShortId = "b53b9a6c-6453-4828-9662-589a1b99614c")]
	public enum WLAN_FILTER_LIST_TYPE
	{
		/// <summary>Group policy permit list.</summary>
		wlan_filter_list_type_gp_permit,

		/// <summary>Group policy deny list.</summary>
		wlan_filter_list_type_gp_deny,

		/// <summary>User permit list.</summary>
		wlan_filter_list_type_user_permit,

		/// <summary>User deny list.</summary>
		wlan_filter_list_type_user_deny,
	}

	/// <summary>
	/// The <c>WLAN_HOSTED_NETWORK_NOTIFICATION_CODE</c> enumerated type specifies the possible values of the NotificationCode parameter
	/// for received notifications on the wireless Hosted Network.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>WLAN_HOSTED_NETWORK_NOTIFICATION_CODE</c> enumerated type is an extension to native wireless APIs added to support the
	/// wireless Hosted Network on Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.
	/// </para>
	/// <para>
	/// The <c>WLAN_HOSTED_NETWORK_NOTIFICATION_CODE</c> specifies the possible values for the NotificationCode parameter for received
	/// notifications when the NotificationSource parameter is WLAN_NOTIFICATION_SOURCE_HNWK on the wireless Hosted Network.
	/// </para>
	/// <para>
	/// The starting value for the <c>WLAN_HOSTED_NETWORK_NOTIFICATION_CODE</c> enumeration is defined as L2_NOTIFICATION_CODE_V2_BEGIN,
	/// which is defined in the l2cmn.h header file. Note that the l2cmn.h header is automatically included by the wlanapi.h header file.
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
	/// <para>
	/// If the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure received by the callback function is
	/// <c>WLAN_NOTIFICATION_SOURCE_HNWK</c>, then the received notification is a wireless Hosted Network notification. The
	/// <c>NotificationCode</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure passed to the WLAN_NOTIFICATION_CALLBACK function
	/// determines the interpretation of the pData member of <c>WLAN_NOTIFICATION_DATA</c> structure.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>NotificationCode</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>wlan_hosted_network_state_change</term>
	/// <term>
	/// The pData member of WLAN_NOTIFICATION_DATA structure should be cast to a pointer to a WLAN_HOSTED_NETWORK_STATE_CHANGE structure
	/// and dwDataSize member would be at least as large as sizeof(WLAN_HOSTED_NETWORK_STATE_CHANGE).
	/// </term>
	/// </item>
	/// <item>
	/// <term>wlan_hosted_network_peer_state_change</term>
	/// <term>
	/// the pData member of WLAN_NOTIFICATION_DATA structure should be cast to a pointer to a WLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE
	/// structure and dwDataSize member would be at least as large as sizeof(WLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE).
	/// </term>
	/// </item>
	/// <item>
	/// <term>wlan_hosted_network_radio_state_change</term>
	/// <term>
	/// the pData member of WLAN_NOTIFICATION_DATA structure should be cast to a pointer to a WLAN_HOSTED_NETWORK_RADIO_STATE structure
	/// and dwDataSize member would be at least as large as sizeof(WLAN_HOSTED_NETWORK_RADIO_STATE ).
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_hosted_network_notification_code typedef enum
	// _WLAN_HOSTED_NETWORK_NOTIFICATION_CODE { wlan_hosted_network_state_change, wlan_hosted_network_peer_state_change,
	// wlan_hosted_network_radio_state_change } WLAN_HOSTED_NETWORK_NOTIFICATION_CODE, *PWLAN_HOSTED_NETWORK_NOTIFICATION_CODE;
	[PInvokeData("wlanapi.h", MSDNShortId = "f01e4a42-3378-4ceb-b23b-5deb78fb18ca")]
	public enum WLAN_HOSTED_NETWORK_NOTIFICATION_CODE : uint
	{
		/// <summary>
		/// The wireless Hosted Network state has changed.
		/// <para>The pData member points to a WLAN_HOSTED_NETWORK_STATE_CHANGE structure that identifies the state change.</para>
		/// </summary>
		[CorrespondingType(typeof(WLAN_HOSTED_NETWORK_STATE_CHANGE))]
		wlan_hosted_network_state_change = 0x00001000,

		/// <summary>
		/// The wireless Hosted Network peer state has changed.
		/// <para>The pData member points to a WLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE structure that identifies the peer state change.</para>
		/// </summary>
		[CorrespondingType(typeof(WLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE))]
		wlan_hosted_network_peer_state_change = 0x00001001,

		/// <summary>
		/// The wireless Hosted Network radio state has changed.
		/// <para>The pData member points to a WLAN_HOSTED_NETWORK_RADIO_STATE structure that identifies the radio state change.</para>
		/// </summary>
		[CorrespondingType(typeof(WLAN_HOSTED_NETWORK_RADIO_STATE))]
		wlan_hosted_network_radio_state_change = 0x00001002,
	}

	/// <summary>
	/// The <c>WLAN_HOSTED_NETWORK_OPCODE</c> enumerated type specifies the possible values of the operation code for the properties to
	/// query or set on the wireless Hosted Network.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>WLAN_HOSTED_NETWORK_OPCODE</c> enumerated type is an extension to native wireless APIs added to support the wireless
	/// Hosted Network on Windows 7 and later.
	/// </para>
	/// <para>
	/// The <c>WLAN_HOSTED_NETWORK_OPCODE</c> specifies the possible values of the operation code for the properties to query or set on
	/// the wireless Hosted Network.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_hosted_network_opcode typedef enum
	// _WLAN_HOSTED_NETWORK_OPCODE { wlan_hosted_network_opcode_connection_settings, wlan_hosted_network_opcode_security_settings,
	// wlan_hosted_network_opcode_station_profile, wlan_hosted_network_opcode_enable } WLAN_HOSTED_NETWORK_OPCODE, *PWLAN_HOSTED_NETWORK_OPCODE;
	[PInvokeData("wlanapi.h", MSDNShortId = "e4acd7ad-c8f2-4ece-8d27-ced879baa9e7")]
	public enum WLAN_HOSTED_NETWORK_OPCODE
	{
		/// <summary>The opcode used to query or set the wireless Hosted Network connection settings.</summary>
		[CorrespondingType(typeof(WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS))]
		wlan_hosted_network_opcode_connection_settings,

		/// <summary>The opcode used to query the wireless Hosted Network security settings.</summary>
		[CorrespondingType(typeof(WLAN_HOSTED_NETWORK_SECURITY_SETTINGS), CorrespondingAction.Get)]
		wlan_hosted_network_opcode_security_settings,

		/// <summary>The opcode used to query the wireless Hosted Network station profile.</summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		wlan_hosted_network_opcode_station_profile,

		/// <summary>The opcode used to query or set the wireless Hosted Network enabled flag.</summary>
		[CorrespondingType(typeof(BOOL))]
		wlan_hosted_network_opcode_enable,
	}

	/// <summary>
	/// The <c>WLAN_HOSTED_NETWORK_PEER_AUTH_STATE</c> enumerated type specifies the possible values for the authentication state of a
	/// peer on the wireless Hosted Network.
	/// </summary>
	/// <remarks>
	/// The <c>WLAN_HOSTED_NETWORK_PEER_AUTH_STATE</c> enumerated type is an extension to native wireless APIs added to support the
	/// wireless Hosted Network on Windows 7 and later.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_hosted_network_peer_auth_state typedef enum
	// _WLAN_HOSTED_NETWORK_PEER_AUTH_STATE { wlan_hosted_network_peer_state_invalid, wlan_hosted_network_peer_state_authenticated }
	// WLAN_HOSTED_NETWORK_PEER_AUTH_STATE, *PWLAN_HOSTED_NETWORK_PEER_AUTH_STATE;
	[PInvokeData("wlanapi.h", MSDNShortId = "9953ad0c-eafc-49ad-b9a3-09fbfba805e5")]
	public enum WLAN_HOSTED_NETWORK_PEER_AUTH_STATE
	{
		/// <summary>An invalid peer state.</summary>
		wlan_hosted_network_peer_state_invalid,

		/// <summary>The peer is authenticated.</summary>
		wlan_hosted_network_peer_state_authenticated,
	}

	/// <summary>
	/// The <c>WLAN_HOSTED_NETWORK_REASON</c> enumerated type specifies the possible values for the result of a wireless Hosted Network
	/// function call.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>WLAN_HOSTED_NETWORK_REASON</c> enumerated type is an extension to native wireless APIs added to support the wireless
	/// Hosted Network on Windows 7 and later.
	/// </para>
	/// <para>
	/// The <c>WLAN_HOSTED_NETWORK_REASON</c> enumerates the possible reasons that a wireless Hosted Network function call failed or the
	/// reasons why a particular wireless Hosted Network notification was generated.
	/// </para>
	/// <para>
	/// On Windows 7 and later, the operating system installs a virtual device if a Hosted Network capable wireless adapter is present
	/// on the machine. This virtual device normally shows up in the “Network Connections Folder” as ‘Wireless Network Connection 2’
	/// with a Device Name of ‘Microsoft Virtual WiFi Miniport adapter’ if the computer has a single wireless network adapter. This
	/// virtual device is used exclusively for performing software access point (SoftAP) connections and is not present in the list
	/// returned by the WlanEnumInterfaces function. The lifetime of this virtual device is tied to the physical wireless adapter. If
	/// the physical wireless adapter is disabled, this virtual device will be removed as well.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_hosted_network_reason typedef enum
	// _WLAN_HOSTED_NETWORK_REASON { wlan_hosted_network_reason_success, wlan_hosted_network_reason_unspecified,
	// wlan_hosted_network_reason_bad_parameters, wlan_hosted_network_reason_service_shutting_down,
	// wlan_hosted_network_reason_insufficient_resources, wlan_hosted_network_reason_elevation_required,
	// wlan_hosted_network_reason_read_only, wlan_hosted_network_reason_persistence_failed, wlan_hosted_network_reason_crypt_error,
	// wlan_hosted_network_reason_impersonation, wlan_hosted_network_reason_stop_before_start,
	// wlan_hosted_network_reason_interface_available, wlan_hosted_network_reason_interface_unavailable,
	// wlan_hosted_network_reason_miniport_stopped, wlan_hosted_network_reason_miniport_started,
	// wlan_hosted_network_reason_incompatible_connection_started, wlan_hosted_network_reason_incompatible_connection_stopped,
	// wlan_hosted_network_reason_user_action, wlan_hosted_network_reason_client_abort, wlan_hosted_network_reason_ap_start_failed,
	// wlan_hosted_network_reason_peer_arrived, wlan_hosted_network_reason_peer_departed, wlan_hosted_network_reason_peer_timeout,
	// wlan_hosted_network_reason_gp_denied, wlan_hosted_network_reason_service_unavailable, wlan_hosted_network_reason_device_change,
	// wlan_hosted_network_reason_properties_change, wlan_hosted_network_reason_virtual_station_blocking_use,
	// wlan_hosted_network_reason_service_available_on_virtual_station } WLAN_HOSTED_NETWORK_REASON, *PWLAN_HOSTED_NETWORK_REASON;
	[PInvokeData("wlanapi.h", MSDNShortId = "affca9ab-fcd4-474d-993c-f6bb6b1f967c")]
	public enum WLAN_HOSTED_NETWORK_REASON
	{
		/// <summary>The operation was successful.</summary>
		wlan_hosted_network_reason_success,

		/// <summary>Unknown error.</summary>
		wlan_hosted_network_reason_unspecified,

		/// <summary>
		/// Bad parameters.For example, this reason code is returned if an application failed to reference the client context from the
		/// correct handle (the handle returned by the WlanOpenHandle function).
		/// </summary>
		wlan_hosted_network_reason_bad_parameters,

		/// <summary>Service is shutting down.</summary>
		wlan_hosted_network_reason_service_shutting_down,

		/// <summary>Service is out of resources.</summary>
		wlan_hosted_network_reason_insufficient_resources,

		/// <summary>This operation requires elevation.</summary>
		wlan_hosted_network_reason_elevation_required,

		/// <summary>An attempt was made to write read-only data.</summary>
		wlan_hosted_network_reason_read_only,

		/// <summary>Data persistence failed.</summary>
		wlan_hosted_network_reason_persistence_failed,

		/// <summary>A cryptographic error occurred.</summary>
		wlan_hosted_network_reason_crypt_error,

		/// <summary>User impersonation failed.</summary>
		wlan_hosted_network_reason_impersonation,

		/// <summary>An incorrect function call sequence was made.</summary>
		wlan_hosted_network_reason_stop_before_start,

		/// <summary>A wireless interface has become available.</summary>
		wlan_hosted_network_reason_interface_available,

		/// <summary>
		/// A wireless interface has become unavailable.This reason code is returned by the wireless Hosted Network functions any time
		/// the network state of the wireless Hosted Network is wlan_hosted_network_unavailable. For example if the wireless Hosted
		/// Network is disabled by group policy on a domain, then the network state of the wireless Hosted Network is
		/// wlan_hosted_network_unavailable. In this case, any calls to the WlanHostedNetworkStartUsing or WlanHostedNetworkForceStart
		/// function would return this reason code.
		/// </summary>
		wlan_hosted_network_reason_interface_unavailable,

		/// <summary>The wireless miniport driver stopped the Hosted Network.</summary>
		wlan_hosted_network_reason_miniport_stopped,

		/// <summary>The wireless miniport driver status changed.</summary>
		wlan_hosted_network_reason_miniport_started,

		/// <summary>
		/// An incompatible connection started.An incompatible connection refers to one of the following cases:Windows will stop the
		/// wireless Hosted Network on the software-based wireless access point (AP) adapter when an incompatible connection starts on
		/// the primary station adapter. The network state of the wireless Hosted Network state would become wlan_hosted_network_unavailable.
		/// </summary>
		wlan_hosted_network_reason_incompatible_connection_started,

		/// <summary>
		/// An incompatible connection stopped.An incompatible connection previously started on the primary station adapter
		/// (wlan_hosted_network_reason_incompatible_connection_started), but the incompatible connection has stopped. If the wireless
		/// Hosted Network was previously stopped as a result of an incompatible connection being started, Windows will not
		/// automatically restart the wireless Hosted Network. Applications can restart the wireless Hosted Network on the AP adapter by
		/// calling the WlanHostedNetworkStartUsing or WlanHostedNetworkForceStart function.
		/// </summary>
		wlan_hosted_network_reason_incompatible_connection_stopped,

		/// <summary>A state change occurred that was caused by explicit user action.</summary>
		wlan_hosted_network_reason_user_action,

		/// <summary>A state change occurred that was caused by client abort.</summary>
		wlan_hosted_network_reason_client_abort,

		/// <summary>The driver for the wireless Hosted Network failed to start.</summary>
		wlan_hosted_network_reason_ap_start_failed,

		/// <summary>A peer connected to the wireless Hosted Network.</summary>
		wlan_hosted_network_reason_peer_arrived,

		/// <summary>A peer disconnected from the wireless Hosted Network.</summary>
		wlan_hosted_network_reason_peer_departed,

		/// <summary>A peer timed out.</summary>
		wlan_hosted_network_reason_peer_timeout,

		/// <summary>The operation was denied by group policy.</summary>
		wlan_hosted_network_reason_gp_denied,

		/// <summary>The Wireless LAN service is not running.</summary>
		wlan_hosted_network_reason_service_unavailable,

		/// <summary>The wireless adapter used by the wireless Hosted Network changed.</summary>
		wlan_hosted_network_reason_device_change,

		/// <summary>The properties of the wireless Hosted Network changed.</summary>
		wlan_hosted_network_reason_properties_change,

		/// <summary>A virtual station is active and blocking operation.</summary>
		wlan_hosted_network_reason_virtual_station_blocking_use,

		/// <summary>An identical service is available on a virtual station.</summary>
		wlan_hosted_network_reason_service_available_on_virtual_station,
	}

	/// <summary>
	/// The <c>WLAN_HOSTED_NETWORK_STATE</c> enumerated type specifies the possible values for the network state of the wireless Hosted Network.
	/// </summary>
	/// <remarks>
	/// The <c>WLAN_HOSTED_NETWORK_STATE</c> enumerated type is an extension to native wireless APIs added to support the wireless
	/// Hosted Network on Windows 7 and later.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_hosted_network_state typedef enum
	// _WLAN_HOSTED_NETWORK_STATE { wlan_hosted_network_unavailable, wlan_hosted_network_idle, wlan_hosted_network_active }
	// WLAN_HOSTED_NETWORK_STATE, *PWLAN_HOSTED_NETWORK_STATE;
	[PInvokeData("wlanapi.h", MSDNShortId = "4c845df3-6bc8-4e09-ac01-6c9180d43b16")]
	public enum WLAN_HOSTED_NETWORK_STATE
	{
		/// <summary>The wireless Hosted Network is unavailable.</summary>
		wlan_hosted_network_unavailable,

		/// <summary>The wireless Hosted Network is idle.</summary>
		wlan_hosted_network_idle,

		/// <summary>The wireless Hosted Network is active.</summary>
		wlan_hosted_network_active,
	}

	/// <summary>The <c>WLAN_IHV_CONTROL_TYPE</c> enumeration specifies the type of software bypassed by a vendor-specific method.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_ihv_control_type~r1 typedef enum
	// _WLAN_IHV_CONTROL_TYPE { wlan_ihv_control_type_service, wlan_ihv_control_type_driver } WLAN_IHV_CONTROL_TYPE, *PWLAN_IHV_CONTROL_TYPE;
	[PInvokeData("wlanapi.h")]
	public enum WLAN_IHV_CONTROL_TYPE
	{
		/// <summary/>
		wlan_ihv_control_type_service,

		/// <summary/>
		wlan_ihv_control_type_driver
	}

	/// <summary>
	/// <para>The <c>WLAN_INTERFACE_STATE</c> enumerated type indicates the state of an interface.</para>
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> Only the <c>wlan_interface_state_connected</c>,
	/// <c>wlan_interface_state_disconnected</c>, and <c>wlan_interface_state_authenticating</c> values are supported.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_interface_state~r1 typedef enum _WLAN_INTERFACE_STATE
	// { wlan_interface_state_not_ready, wlan_interface_state_connected, wlan_interface_state_ad_hoc_network_formed,
	// wlan_interface_state_disconnecting, wlan_interface_state_disconnected, wlan_interface_state_associating,
	// wlan_interface_state_discovering, wlan_interface_state_authenticating } WLAN_INTERFACE_STATE, *PWLAN_INTERFACE_STATE;
	[PInvokeData("wlanapi.h")]
	public enum WLAN_INTERFACE_STATE
	{
		/// <summary/>
		wlan_interface_state_not_ready,

		/// <summary/>
		wlan_interface_state_connected,

		/// <summary/>
		wlan_interface_state_ad_hoc_network_formed,

		/// <summary/>
		wlan_interface_state_disconnecting,

		/// <summary/>
		wlan_interface_state_disconnected,

		/// <summary/>
		wlan_interface_state_associating,

		/// <summary/>
		wlan_interface_state_discovering,

		/// <summary/>
		wlan_interface_state_authenticating
	}

	/// <summary>The <c>WLAN_INTERFACE_TYPE</c> enumeration specifies the wireless interface type.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_interface_type typedef enum _WLAN_INTERFACE_TYPE {
	// wlan_interface_type_emulated_802_11, wlan_interface_type_native_802_11, wlan_interface_type_invalid } WLAN_INTERFACE_TYPE, *PWLAN_INTERFACE_TYPE;
	[PInvokeData("wlanapi.h", MSDNShortId = "c7a3aa6c-2f66-4d45-a975-f6da433e368f")]
	public enum WLAN_INTERFACE_TYPE
	{
		/// <summary>Specifies an emulated 802.11 interface.</summary>
		wlan_interface_type_emulated_802_11,

		/// <summary>Specifies a native 802.11 interface.</summary>
		wlan_interface_type_native_802_11,

		/// <summary>The interface specified is invalid.</summary>
		wlan_interface_type_invalid,
	}

	/// <summary>
	/// The <c>WLAN_INTF_OPCODE</c> enumerated type defines various opcodes used to set and query parameters on a wireless interface.
	/// </summary>
	/// <remarks>
	/// The <c>WLAN_INTF_OPCODE</c> enumerated type defines the possible opcodes that can be passed in the OpCode parameter to the
	/// WlanQueryInterface and WlanSetInterface functions to query or set parameters on a wireless interface.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_intf_opcode~r1 typedef enum _WLAN_INTF_OPCODE {
	// wlan_intf_opcode_autoconf_start, wlan_intf_opcode_autoconf_enabled, wlan_intf_opcode_background_scan_enabled,
	// wlan_intf_opcode_media_streaming_mode, wlan_intf_opcode_radio_state, wlan_intf_opcode_bss_type, wlan_intf_opcode_interface_state,
	// wlan_intf_opcode_current_connection, wlan_intf_opcode_channel_number,
	// wlan_intf_opcode_supported_infrastructure_auth_cipher_pairs, wlan_intf_opcode_supported_adhoc_auth_cipher_pairs,
	// wlan_intf_opcode_supported_country_or_region_string_list, wlan_intf_opcode_current_operation_mode,
	// wlan_intf_opcode_supported_safe_mode, wlan_intf_opcode_certified_safe_mode, wlan_intf_opcode_hosted_network_capable,
	// wlan_intf_opcode_management_frame_protection_capable, wlan_intf_opcode_autoconf_end, wlan_intf_opcode_msm_start,
	// wlan_intf_opcode_statistics, wlan_intf_opcode_rssi, wlan_intf_opcode_msm_end, wlan_intf_opcode_security_start,
	// wlan_intf_opcode_security_end, wlan_intf_opcode_ihv_start, wlan_intf_opcode_ihv_end } WLAN_INTF_OPCODE, *PWLAN_INTF_OPCODE;
	[PInvokeData("wlanapi.h")]
	public enum WLAN_INTF_OPCODE : uint
	{
		/// <summary/>
		wlan_intf_opcode_autoconf_start = 0,

		/// <summary>Enables or disables auto config for the indicated interface.</summary>
		[CorrespondingType(typeof(BOOL))]
		wlan_intf_opcode_autoconf_enabled,

		/// <summary>Enables or disables background scan for the indicated interface.</summary>
		[CorrespondingType(typeof(BOOL))]
		wlan_intf_opcode_background_scan_enabled,

		/// <summary>Sets media streaming mode for the driver.</summary>
		[CorrespondingType(typeof(BOOL))]
		wlan_intf_opcode_media_streaming_mode,

		/// <summary>Sets the software radio state of a specific physical layer (PHY) for the interface.</summary>
		[CorrespondingType(typeof(WLAN_RADIO_STATE))]
		wlan_intf_opcode_radio_state,

		/// <summary>Sets the BSS type.</summary>
		[CorrespondingType(typeof(DOT11_BSS_TYPE))]
		wlan_intf_opcode_bss_type,

		/// <summary/>
		[CorrespondingType(typeof(WLAN_INTERFACE_STATE), CorrespondingAction.Get)]
		wlan_intf_opcode_interface_state,

		/// <summary/>
		[CorrespondingType(typeof(WLAN_CONNECTION_ATTRIBUTES), CorrespondingAction.Get)]
		wlan_intf_opcode_current_connection,

		/// <summary/>
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		wlan_intf_opcode_channel_number,

		/// <summary/>
		[CorrespondingType(typeof(WLAN_AUTH_CIPHER_PAIR_LIST), CorrespondingAction.Get)]
		wlan_intf_opcode_supported_infrastructure_auth_cipher_pairs,

		/// <summary/>
		[CorrespondingType(typeof(WLAN_AUTH_CIPHER_PAIR_LIST), CorrespondingAction.Get)]
		wlan_intf_opcode_supported_adhoc_auth_cipher_pairs,

		/// <summary/>
		[CorrespondingType(typeof(WLAN_COUNTRY_OR_REGION_STRING_LIST), CorrespondingAction.Get)]
		wlan_intf_opcode_supported_country_or_region_string_list,

		/// <summary>Sets the current operation mode for the interface. For more information, see Remarks.</summary>
		[CorrespondingType(typeof(DOT11_OPERATION_MODE))]
		wlan_intf_opcode_current_operation_mode,

		/// <summary/>
		[CorrespondingType(typeof(BOOL), CorrespondingAction.Get)]
		wlan_intf_opcode_supported_safe_mode,

		/// <summary/>
		[CorrespondingType(typeof(BOOL), CorrespondingAction.Get)]
		wlan_intf_opcode_certified_safe_mode,

		/// <summary/>
		[CorrespondingType(typeof(BOOL), CorrespondingAction.Get)]
		wlan_intf_opcode_hosted_network_capable,

		/// <summary/>
		[CorrespondingType(typeof(BOOL), CorrespondingAction.Get)]
		wlan_intf_opcode_management_frame_protection_capable,

		/// <summary/>
		wlan_intf_opcode_autoconf_end = 0x0fffffff,

		/// <summary/>
		wlan_intf_opcode_msm_start = 0x10000100,

		/// <summary/>
		[CorrespondingType(typeof(WLAN_STATISTICS), CorrespondingAction.Get)]
		wlan_intf_opcode_statistics,

		/// <summary/>
		[CorrespondingType(typeof(int), CorrespondingAction.Get)]
		wlan_intf_opcode_rssi,

		/// <summary/>
		wlan_intf_opcode_msm_end = 0x1fffffff,

		/// <summary/>
		wlan_intf_opcode_security_start = 0x20010000,

		/// <summary/>
		wlan_intf_opcode_security_end = 0x2fffffff,

		/// <summary/>
		wlan_intf_opcode_ihv_start = 0x30000000,

		/// <summary/>
		wlan_intf_opcode_ihv_end = 0x3fffffff
	}

	/// <summary>
	/// The <c>WLAN_NOTIFICATION_ACM</c> enumerated type specifies the possible values of the <c>NotificationCode</c> member of the
	/// WLAN_NOTIFICATION_DATA structure for Auto Configuration Module (ACM) notifications.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>WLAN_NOTIFICATION_ACM</c> enumerated type is used by the Auto Configuration Module, the new wireless configuration
	/// component supported on Windows Vista and later.
	/// </para>
	/// <para>
	/// The <c>WLAN_NOTIFICATION_ACM</c> specifies the possible values for the <c>NotificationCode</c> member of the
	/// WLAN_NOTIFICATION_DATA structure for received notifications when the <c>NotificationSource</c> member of the
	/// <c>WLAN_NOTIFICATION_DATA</c> structure is <c>WLAN_NOTIFICATION_SOURCE_ACM</c>.
	/// </para>
	/// <para>
	/// The starting value for the <c>WLAN_NOTIFICATION_ACM</c> enumeration is defined as L2_NOTIFICATION_CODE_V2_BEGIN in the l2cmn.h
	/// header file. Note that the l2cmn.h header is automatically included by the wlanapi.h header file.
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
	/// <para>
	/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> Only the
	/// <c>wlan_notification_acm_connection_complete</c> and <c>wlan_notification_acm_disconnected</c> notifications are available.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_notification_acm~r1 typedef enum
	// _WLAN_NOTIFICATION_ACM { wlan_notification_acm_start, wlan_notification_acm_autoconf_enabled,
	// wlan_notification_acm_autoconf_disabled, wlan_notification_acm_background_scan_enabled,
	// wlan_notification_acm_background_scan_disabled, wlan_notification_acm_bss_type_change,
	// wlan_notification_acm_power_setting_change, wlan_notification_acm_scan_complete, wlan_notification_acm_scan_fail,
	// wlan_notification_acm_connection_start, wlan_notification_acm_connection_complete, wlan_notification_acm_connection_attempt_fail,
	// wlan_notification_acm_filter_list_change, wlan_notification_acm_interface_arrival, wlan_notification_acm_interface_removal,
	// wlan_notification_acm_profile_change, wlan_notification_acm_profile_name_change, wlan_notification_acm_profiles_exhausted,
	// wlan_notification_acm_network_not_available, wlan_notification_acm_network_available, wlan_notification_acm_disconnecting,
	// wlan_notification_acm_disconnected, wlan_notification_acm_adhoc_network_state_change, wlan_notification_acm_profile_unblocked,
	// wlan_notification_acm_screen_power_change, wlan_notification_acm_profile_blocked, wlan_notification_acm_scan_list_refresh,
	// wlan_notification_acm_operational_state_change, wlan_notification_acm_end } WLAN_NOTIFICATION_ACM, *PWLAN_NOTIFICATION_ACM;
	[PInvokeData("wlanapi.h")]
	public enum WLAN_NOTIFICATION_ACM : uint
	{
		/// <summary/>
		wlan_notification_acm_start = 0,

		/// <summary>Autoconfiguration is enabled.</summary>
		wlan_notification_acm_autoconf_enabled = 0x00000001,

		/// <summary>Autoconfiguration is disabled.</summary>
		wlan_notification_acm_autoconf_disabled = 0x00000002,

		/// <summary>Background scans are enabled.</summary>
		wlan_notification_acm_background_scan_enabled = 0x00000003,

		/// <summary>Background scans are disabled.</summary>
		wlan_notification_acm_background_scan_disabled = 0x00000004,

		/// <summary>
		/// The BSS type for an interface has changed.
		/// <para>The pData member points to a DOT11_BSS_TYPE enumeration value that identifies the new basic service set (BSS) type.</para>
		/// </summary>
		wlan_notification_acm_bss_type_change = 0x00000005,

		/// <summary>
		/// The power setting for an interface has changed.
		/// <para>The pData member points to a WLAN_POWER_SETTING enumeration value that identifies the new power setting of an interface.</para>
		/// </summary>
		wlan_notification_acm_power_setting_change = 0x00000006,

		/// <summary>A scan for networks has completed.</summary>
		wlan_notification_acm_scan_complete = 0x00000007,

		/// <summary>
		/// A scan for connectable networks failed.
		/// <para>The pData member points to a WLAN_REASON_CODE data type value that identifies the reason the WLAN operation failed.</para>
		/// </summary>
		wlan_notification_acm_scan_fail = 0x00000008,

		/// <summary>
		/// A connection has started to a network in range.
		/// <para>
		/// The pData member points to a WLAN_CONNECTION_NOTIFICATION_DATA structure that identifies the network information for the
		/// connection attempt.
		/// </para>
		/// </summary>
		wlan_notification_acm_connection_start = 0x00000009,

		/// <summary>
		/// A connection has completed.
		/// <para>
		/// The pData member points to a WLAN_CONNECTION_NOTIFICATION_DATA structure that identifies the network information for the
		/// connection attempt that completed. The connection succeeded if the wlanReasonCode in WLAN_CONNECTION_NOTIFICATION_DATA is
		/// WLAN_REASON_CODE_SUCCESS. Otherwise, the connection has failed.
		/// </para>
		/// </summary>
		wlan_notification_acm_connection_complete = 0x0000000a,

		/// <summary>
		/// A connection attempt has failed.
		/// <para>
		/// A connection consists of one or more connection attempts. An application may receive zero or more
		/// wlan_notification_acm_connection_attempt_fail notifications between receiving the wlan_notification_acm_connection_start
		/// notification and the wlan_notification_acm_connection_complete notification.
		/// </para>
		/// <para>
		/// The pData member points to a WLAN_CONNECTION_NOTIFICATION_DATA structure that identifies the network information for the
		/// connection attempt that failed.
		/// </para>
		/// </summary>
		wlan_notification_acm_connection_attempt_fail = 0x0000000b,

		/// <summary>
		/// A change in the filter list has occurred, either through group policy or a call to the WlanSetFilterList function.
		/// <para>An application can call the WlanGetFilterList function to retrieve the new filter list.</para>
		/// </summary>
		wlan_notification_acm_filter_list_change = 0x0000000c,

		/// <summary>A wireless LAN interface is been added to or enabled on the local computer.</summary>
		wlan_notification_acm_interface_arrival = 0x0000000d,

		/// <summary>A wireless LAN interface has been removed or disabled on the local computer.</summary>
		wlan_notification_acm_interface_removal = 0x0000000e,

		/// <summary>
		/// A change in a profile or the profile list has occurred, either through group policy or by calls to Native Wifi functions.
		/// <para>
		/// An application can call the WlanGetProfileList and WlanGetProfile functions to retrieve the updated profiles. The interface
		/// on which the profile list changes is identified by the InterfaceGuid member.
		/// </para>
		/// </summary>
		wlan_notification_acm_profile_change = 0x0000000f,

		/// <summary>
		/// A profile name has changed, either through group policy or by calls to Native Wifi functions.
		/// <para>
		/// The pData member points to a buffer that contains two NULL-terminated WCHAR strings, the old profile name followed by the
		/// new profile name.
		/// </para>
		/// </summary>
		wlan_notification_acm_profile_name_change = 0x00000010,

		/// <summary>All profiles were exhausted in an attempt to autoconnect.</summary>
		wlan_notification_acm_profiles_exhausted = 0x00000011,

		/// <summary>
		/// The wireless service cannot find any connectable network after a scan.
		/// <para>The interface on which no connectable network is found is identified by identified by the InterfaceGuid member.</para>
		/// </summary>
		wlan_notification_acm_network_not_available = 0x00000012,

		/// <summary>
		/// The wireless service found a connectable network after a scan, the interface was in the disconnected state, and there is no
		/// compatible auto-connect profile that the wireless service can use to connect .
		/// <para>The interface on which connectable networks are found is identified by the InterfaceGuid member.</para>
		/// </summary>
		wlan_notification_acm_network_available = 0x00000013,

		/// <summary>
		/// The wireless service is disconnecting from a connectable network.
		/// <para>
		/// The pData member points to a WLAN_CONNECTION_NOTIFICATION_DATA structure that identifies the network information for the
		/// connection that is disconnecting.
		/// </para>
		/// </summary>
		wlan_notification_acm_disconnecting = 0x00000014,

		/// <summary>
		/// The wireless service has disconnected from a connectable network.
		/// <para>
		/// The pData member points to a WLAN_CONNECTION_NOTIFICATION_DATA structure that identifies the network information for the
		/// connection that disconnected.
		/// </para>
		/// </summary>
		wlan_notification_acm_disconnected = 0x00000015,

		/// <summary>
		/// A state change has occurred for an adhoc network.
		/// <para>The pData member points to a WLAN_ADHOC_NETWORK_STATE enumeration value that identifies the new adhoc network state.</para>
		/// </summary>
		wlan_notification_acm_adhoc_network_state_change = 0x00000016,

		/// <summary>This value is supported on Windows 8 and later.</summary>
		wlan_notification_acm_profile_unblocked = 0x00000017,

		/// <summary>
		/// The screen power has changed.
		/// <para>
		/// The pData member points to a BOOL value that indicates the value of the screen power change. When this value is TRUE, the
		/// screen changed to on. When this value is FALSE, the screen changed to off.
		/// </para>
		/// <para>This value is supported on Windows 8 and later.</para>
		/// </summary>
		wlan_notification_acm_screen_power_change = 0x00000018,

		/// <summary>This value is supported on Windows 8 and later.</summary>
		wlan_notification_acm_profile_blocked = 0x00000019,

		/// <summary>This value is supported on Windows 8 and later.</summary>
		wlan_notification_acm_scan_list_refresh = 0x0000001a,

		/// <summary/>
		wlan_notification_acm_operational_state_change,

		/// <summary/>
		wlan_notification_acm_end,
	}

	/// <summary>
	/// The <c>WLAN_NOTIFICATION_MSM</c> enumerated type specifies the possible values of the <c>NotificationCode</c> member of the
	/// WLAN_NOTIFICATION_DATA structure for Media Specific Module (MSM) notifications.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The WLAN_NOTIFICATION_ACM enumerated type is used by the Media Specific Module, the new wireless configuration component
	/// supported on Windows Vista and later.
	/// </para>
	/// <para>
	/// The <c>WLAN_NOTIFICATION_MSM</c> specifies the possible values for the <c>NotificationCode</c> member of the
	/// WLAN_NOTIFICATION_DATA structure for received notifications when the <c>NotificationSource</c> member of the
	/// <c>WLAN_NOTIFICATION_DATA</c> structure is <c>WLAN_NOTIFICATION_SOURCE_MSM</c>.
	/// </para>
	/// <para>
	/// The starting value for the <c>WLAN_NOTIFICATION_MSM</c> enumeration is defined as L2_NOTIFICATION_CODE_PUBLIC_BEGIN in the
	/// l2cmn.h header file. Note that the l2cmn.h header is automatically included by the wlanapi.h header file.
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
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_notification_msm~r1 typedef enum
	// _WLAN_NOTIFICATION_MSM { wlan_notification_msm_start, wlan_notification_msm_associating, wlan_notification_msm_associated,
	// wlan_notification_msm_authenticating, wlan_notification_msm_connected, wlan_notification_msm_roaming_start,
	// wlan_notification_msm_roaming_end, wlan_notification_msm_radio_state_change, wlan_notification_msm_signal_quality_change,
	// wlan_notification_msm_disassociating, wlan_notification_msm_disconnected, wlan_notification_msm_peer_join,
	// wlan_notification_msm_peer_leave, wlan_notification_msm_adapter_removal, wlan_notification_msm_adapter_operation_mode_change,
	// wlan_notification_msm_link_degraded, wlan_notification_msm_link_improved, wlan_notification_msm_end } WLAN_NOTIFICATION_MSM, *PWLAN_NOTIFICATION_MSM;
	[PInvokeData("wlanapi.h")]
	public enum WLAN_NOTIFICATION_MSM : uint
	{
		/// <summary/>
		wlan_notification_msm_start,

		/// <summary>
		/// A wireless device is in the process of associating with an access point or a peer station.
		/// <para>The pData member points to a WLAN_MSM_NOTIFICATION_DATA structure that contains connection-related information.</para>
		/// </summary>
		wlan_notification_msm_associating = 0x00000001,

		/// <summary>
		/// The wireless device has associated with an access point or a peer station.
		/// <para>The pData member points to a WLAN_MSM_NOTIFICATION_DATA structure that contains connection-related information.</para>
		/// </summary>
		wlan_notification_msm_associated = 0x00000002,

		/// <summary>
		/// The wireless device is in the process of authenticating.
		/// <para>
		/// The pData member of the WLAN_NOTIFICATION_DATA structure points to a WLAN_MSM_NOTIFICATION_DATA structure that contains
		/// connection-related information.
		/// </para>
		/// </summary>
		wlan_notification_msm_authenticating = 0x00000003,

		/// <summary>
		/// The wireless device is associated with an access point or a peer station, keys have been exchanged, and the wireless device
		/// is available to send data.
		/// <para>The pData member points to a WLAN_MSM_NOTIFICATION_DATA structure that contains connection-related information.</para>
		/// </summary>
		wlan_notification_msm_connected = 0x00000004,

		/// <summary>
		/// The wireless device is connected to an access point and has initiated roaming to another access point.
		/// <para>The pData member points to a WLAN_MSM_NOTIFICATION_DATA structure that contains connection-related information.</para>
		/// </summary>
		wlan_notification_msm_roaming_start = 0x00000005,

		/// <summary>
		/// The wireless device was connected to an access point and has completed roaming to another access point.
		/// <para>The pData member points to a WLAN_MSM_NOTIFICATION_DATA structure that contains connection-related information.</para>
		/// </summary>
		wlan_notification_msm_roaming_end = 0x00000006,

		/// <summary>
		/// The radio state for an adapter has changed. Each physical layer (PHY) has its own radio state. The radio for an adapter is
		/// switched off when the radio state of every PHY is off.
		/// <para>The pData member points to a WLAN_PHY_RADIO_STATE structure that identifies the new radio state.</para>
		/// </summary>
		wlan_notification_msm_radio_state_change = 0x00000007,

		/// <summary>
		/// A signal quality change for the currently associated access point or peer station.
		/// <para>The pData member points to a ULONG value for the WLAN_SIGNAL_QUALITY that identifies the new signal quality.</para>
		/// </summary>
		wlan_notification_msm_signal_quality_change = 0x00000008,

		/// <summary>
		/// A wireless device is in the process of disassociating from an access point or a peer station.
		/// <para>The pData member points to a WLAN_MSM_NOTIFICATION_DATA structure that contains connection-related information.</para>
		/// </summary>
		wlan_notification_msm_disassociating = 0x00000009,

		/// <summary>
		/// The wireless device is not associated with an access point or a peer station.
		/// <para>
		/// The pData member points to a WLAN_MSM_NOTIFICATION_DATA structure that contains connection-related information. The
		/// wlanReasonCode member of the WLAN_MSM_NOTIFICATION_DATA structure indicates the reason for the disconnect.
		/// </para>
		/// </summary>
		wlan_notification_msm_disconnected = 0x0000000a,

		/// <summary>
		/// A peer has joined an adhoc network.
		/// <para>The pData member points to a WLAN_MSM_NOTIFICATION_DATA structure that contains connection-related information.</para>
		/// </summary>
		wlan_notification_msm_peer_join = 0x0000000b,

		/// <summary>
		/// A peer has left an adhoc network.
		/// <para>
		/// The pData member of the WLAN_NOTIFICATION_DATA structure points to a WLAN_MSM_NOTIFICATION_DATA structure that contains
		/// connection-related information.
		/// </para>
		/// </summary>
		wlan_notification_msm_peer_leave = 0x0000000c,

		/// <summary>
		/// A wireless adapter has been removed from the local computer.
		/// <para>The pData member points to a WLAN_MSM_NOTIFICATION_DATA structure that contains connection-related information.</para>
		/// </summary>
		wlan_notification_msm_adapter_removal = 0x0000000d,

		/// <summary>
		/// The operation mode of the wireless device has changed.
		/// <para>The pData member points to a ULONG that identifies the new operation mode.</para>
		/// </summary>
		wlan_notification_msm_adapter_operation_mode_change = 0x0000000e,

		/// <summary/>
		wlan_notification_msm_link_degraded,

		/// <summary/>
		wlan_notification_msm_link_improved,

		/// <summary/>
		wlan_notification_msm_end
	}

	/// <summary>A value that indicates the source of the notification.</summary>
	[PInvokeData("wlanapi.h")]
	[Flags]
	public enum WLAN_NOTIFICATION_SOURCE
	{
		/// <summary>A notification generated by an unknown source.</summary>
		WLAN_NOTIFICATION_SOURCE_NONE = 0,

		/// <summary>
		/// A notification generated by the 802.1X module. For more information on these notifications, see the ONEX_NOTIFICATION_TYPE
		/// enumeration reference.
		/// </summary>
		WLAN_NOTIFICATION_SOURCE_ONEX = 0x00000004,

		/// <summary>
		/// A notification generated by the auto configuration module. For more information on these notifications, see the
		/// WLAN_NOTIFICATION_ACM enumeration reference.
		/// </summary>
		WLAN_NOTIFICATION_SOURCE_ACM = 0x00000008,

		/// <summary>
		/// A notification generated by the media specific module (MSM). For more information on these notifications, see the
		/// WLAN_NOTIFICATION_MSM enumeration reference.
		/// </summary>
		WLAN_NOTIFICATION_SOURCE_MSM = 0x00000010,

		/// <summary>
		/// A notification generated by the security module.
		/// <para>No notifications are currently defined for WLAN_NOTIFICATION_SOURCE_SECURITY.</para>
		/// </summary>
		WLAN_NOTIFICATION_SOURCE_SECURITY = 0x00000020,

		/// <summary>A notification generated by independent hardware vendors (IHV).</summary>
		WLAN_NOTIFICATION_SOURCE_IHV = 0x00000040,

		/// <summary>
		/// A notification generated by the wireless Hosted Network. For more information on these notifications, see the
		/// WLAN_HOSTED_NETWORK_NOTIFICATION_CODE enumeration reference.
		/// <para>This notification source is available on Windows 7 and on Windows Server 2008 R2 with the Wireless LAN Service installed.</para>
		/// </summary>
		WLAN_NOTIFICATION_SOURCE_HNWK = 0x00000080,

		/// <summary>A notification generated by the 802.1X module.</summary>
		WLAN_NOTIFICATION_SOURCE_ALL = 0x0000FFFF,
	}

	/// <summary>The <c>WLAN_OPCODE_VALUE_TYPE</c> enumeration specifies the origin of automatic configuration (auto config) settings.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_opcode_value_type~r1 typedef enum
	// _WLAN_OPCODE_VALUE_TYPE { wlan_opcode_value_type_query_only, wlan_opcode_value_type_set_by_group_policy,
	// wlan_opcode_value_type_set_by_user, wlan_opcode_value_type_invalid } WLAN_OPCODE_VALUE_TYPE, *PWLAN_OPCODE_VALUE_TYPE;
	[PInvokeData("wlanapi.h")]
	public enum WLAN_OPCODE_VALUE_TYPE
	{
		/// <summary/>
		wlan_opcode_value_type_query_only,

		/// <summary/>
		wlan_opcode_value_type_set_by_group_policy,

		/// <summary/>
		wlan_opcode_value_type_set_by_user,

		/// <summary/>
		wlan_opcode_value_type_invalid
	}

	/// <summary>The <c>WLAN_POWER_SETTING</c> enumerated type specifies the power setting of an interface.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_power_setting~r1 typedef enum _WLAN_POWER_SETTING {
	// wlan_power_setting_no_saving, wlan_power_setting_low_saving, wlan_power_setting_medium_saving, wlan_power_setting_maximum_saving,
	// wlan_power_setting_invalid } WLAN_POWER_SETTING, *PWLAN_POWER_SETTING;
	[PInvokeData("wlanapi.h")]
	public enum WLAN_POWER_SETTING
	{
		/// <summary/>
		wlan_power_setting_no_saving,

		/// <summary/>
		wlan_power_setting_low_saving,

		/// <summary/>
		wlan_power_setting_medium_saving,

		/// <summary/>
		wlan_power_setting_maximum_saving,

		/// <summary/>
		wlan_power_setting_invalid
	}

	/// <summary>Specifies the flags to set on the profile.</summary>
	[PInvokeData("wlanapi.h", MSDNShortId = "ca45278c-2e1e-4080-825a-d6a05e463858")]
	[Flags]
	public enum WLAN_PROFILE_FLAGS
	{
		/// <summary>
		/// This flag indicates that this profile was created by group policy. A group policy profile is read-only. Neither the content
		/// nor the preference order of the profile can be changed.
		/// </summary>
		WLAN_PROFILE_GROUP_POLICY = 0x00000001,

		/// <summary>This flag indicates that the profile is a per-user profile. If not set, this profile is an all-user profile.</summary>
		WLAN_PROFILE_USER = 0x00000002,

		/// <summary>
		/// <para>
		/// On input, this flag indicates that the caller wants to retrieve the plain text key from a wireless profile. If the calling
		/// thread has the required permissions, the WlanGetProfile function returns the plain text key in the keyMaterial element of
		/// the profile returned in the buffer pointed to by the pstrProfileXml parameter.
		/// </para>
		/// <para>
		/// For the WlanGetProfile call to return the plain text key, the wlan_secure_get_plaintext_key permissions from the
		/// WLAN_SECURABLE_OBJECT enumerated type must be set on the calling thread. The DACL must also contain an ACE that grants
		/// WLAN_READ_ACCESS permission to the access token of the calling thread. By default, the permissions for retrieving the plain
		/// text key is allowed only to the members of the Administrators group on a local machine.
		/// </para>
		/// <para>
		/// If the calling thread lacks the required permissions, the WlanGetProfile function returns the encrypted key in the
		/// keyMaterial element of the profile returned in the buffer pointed to by the pstrProfileXml parameter. No error is returned
		/// if the calling thread lacks the required permissions.
		/// </para>
		/// <para>
		/// Windows 7: This flag passed on input is an extension to native wireless APIs added on Windows 7 and later. The pdwFlags
		/// parameter is an __inout_opt parameter on Windows 7 and later.
		/// </para>
		/// </summary>
		WLAN_PROFILE_GET_PLAINTEXT_KEY = 0x00000004,

		/// <summary>The profile was created by the client.</summary>
		WLAN_PROFILE_CONNECTION_MODE_SET_BY_CLIENT = 0x00010000,

		/// <summary>The profile was created by the automatic configuration module.</summary>
		WLAN_PROFILE_CONNECTION_MODE_AUTO = 0x00020000,
	}

	/// <summary>
	/// <para>The <c>WLAN_REASON_CODE</c> type indicates the reason a WLAN operation has failed.</para>
	/// <para>
	/// You can use the <c>WlanReasonCodeToString</c> function to map a numeric reason code (for example, 0x00050007) to its text
	/// meaning. You can also use the lookup table to help interpret the numeric value of the reason code. To view the lookup table, see
	/// Appendix E: Mapping of reason codes to event messages in the document Troubleshooting Windows Vista 802.11 Wireless Connections.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// A limited set of reason codes are supported on Windows XP with Service Pack 3 (SP3) and on the Wireless LAN API for Windows XP
	/// with Service Pack 2 (SP2). The profile validation error codes supported on Windows XP with SP3 and on the Wireless LAN API for
	/// Windows XP with SP2 are as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WLAN_REASON_CODE_INVALID_PROFILE_SCHEMA</term>
	/// </item>
	/// <item>
	/// <term>WLAN_REASON_CODE_PROFILE_MISSING</term>
	/// </item>
	/// <item>
	/// <term>WLAN_REASON_CODE_PROFILE_SSID_INVALID</term>
	/// </item>
	/// </list>
	/// <para>
	/// The MSM security error codes supported on Windows XP with SP3 and on the Wireless LAN API for Windows XP with SP2 are as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WLAN_REASON_CODE_MSMSEC_PROFILE_INVALID_KEY_INDEX</term>
	/// </item>
	/// <item>
	/// <term>WLAN_REASON_CODE_MSMSEC_PROFILE_KEY_LENGTH</term>
	/// </item>
	/// <item>
	/// <term>WLAN_REASON_CODE_MSMSEC_PROFILE_PSK_LENGTH</term>
	/// </item>
	/// <item>
	/// <term>WLAN_REASON_CODE_MSMSEC_PROFILE_INVALID_AUTH_CIPHER</term>
	/// </item>
	/// <item>
	/// <term>WLAN_REASON_CODE_MSMSEC_PROFILE_ONEX_DISABLED</term>
	/// </item>
	/// <item>
	/// <term>WLAN_REASON_CODE_MSMSEC_PROFILE_ONEX_ENABLED</term>
	/// </item>
	/// <item>
	/// <term>WLAN_REASON_CODE_MSMSEC_CAPABILITY_NETWORK</term>
	/// </item>
	/// <item>
	/// <term>WLAN_REASON_CODE_MSMSEC_CAPABILITY_NIC</term>
	/// </item>
	/// <item>
	/// <term>WLAN_REASON_CODE_MSMSEC_PROFILE_KEYMATERIAL_CHAR</term>
	/// </item>
	/// <item>
	/// <term>WLAN_REASON_CODE_MSMSEC_PROFILE_WRONG_KEYTYPE</term>
	/// </item>
	/// </list>
	/// <para>The 802.1x error codes supported on Windows XP with SP3 and on the Wireless LAN API for Windows XP with SP2 are as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>ONEX_PROFILE_INVALID_LENGTH</term>
	/// </item>
	/// <item>
	/// <term>ONEX_PROFILE_INVALID_EAP_TYPE_OR_FLAG</term>
	/// </item>
	/// <item>
	/// <term>ONEX_PROFILE_INVALID_AUTH_MODE</term>
	/// </item>
	/// <item>
	/// <term>ONEX_PROFILE_INVALID_EAP_CONNECTION_PROPERTIES</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/nativewifi/wlan-reason-code
	[PInvokeData("", MSDNShortId = "7b267f0b-b3f7-4729-bab4-de3bdd0a35a2")]
	public enum WLAN_REASON_CODE : uint
	{
		/// <summary>The operation succeeds.</summary>
		WLAN_REASON_CODE_SUCCESS = L2_REASON_CODE_SUCCESS,

		/// <summary>The reason for failure is unknown.</summary>
		WLAN_REASON_CODE_UNKNOWN = L2_REASON_CODE_UNKNOWN,

		/// <summary/>
		WLAN_REASON_CODE_AC_BASE = L2_REASON_CODE_DOT11_AC_BASE,

		/// <summary/>
		WLAN_REASON_CODE_AC_CONNECT_BASE = (WLAN_REASON_CODE_AC_BASE + WLAN_REASON_CODE_RANGE_SIZE / 2),

		/// <summary/>
		WLAN_REASON_CODE_AC_END = (WLAN_REASON_CODE_AC_BASE + WLAN_REASON_CODE_RANGE_SIZE - 1),

		/// <summary>Failed to start security for ad hoc peer.</summary>
		WLAN_REASON_CODE_ADHOC_SECURITY_FAILURE = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 10),

		/// <summary>
		/// An application tried to apply a wireless Hosted Network profile to a physical wireless network adapter using the
		/// WlanSetProfile function, rather than to a virtual device.
		/// </summary>
		WLAN_REASON_CODE_AP_PROFILE_NOT_ALLOWED = (WLAN_REASON_CODE_AC_CONNECT_BASE + 16),

		/// <summary>
		/// An application tried to apply a wireless Hosted Network profile to a physical wireless network adapter using the
		/// WlanSetProfile function, rather than to a virtual device.
		/// </summary>
		WLAN_REASON_CODE_AP_PROFILE_NOT_ALLOWED_FOR_CLIENT = (WLAN_REASON_CODE_AC_CONNECT_BASE + 15),

		/// <summary>An internal operating system error occurred that resulted in a failure to start the wireless Hosted Network.</summary>
		WLAN_REASON_CODE_AP_STARTING_FAILURE = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 19),

		/// <summary>Driver disconnected while associating.</summary>
		WLAN_REASON_CODE_ASSOCIATION_FAILURE = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 2),

		/// <summary>Association timed out.</summary>
		WLAN_REASON_CODE_ASSOCIATION_TIMEOUT = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 3),

		/// <summary>An internal operating system error occurred with the wireless Hosted Network.</summary>
		WLAN_REASON_CODE_AUTO_AP_PROFILE_NOT_ALLOWED = (WLAN_REASON_CODE_PROFILE_BASE + 25),

		/// <summary/>
		WLAN_REASON_CODE_AUTO_CONNECTION_NOT_ALLOWED = (WLAN_REASON_CODE_PROFILE_BASE + 26),

		/// <summary>Auto-switch cannot be set for an ad hoc network.</summary>
		WLAN_REASON_CODE_AUTO_SWITCH_SET_FOR_ADHOC = (WLAN_REASON_CODE_PROFILE_BASE + 16),

		/// <summary>Auto-switch cannot be set for a manual connection profile.</summary>
		WLAN_REASON_CODE_AUTO_SWITCH_SET_FOR_MANUAL_CONNECTION = (WLAN_REASON_CODE_PROFILE_BASE + 17),

		/// <summary>
		/// An application tried to apply a wireless Hosted Network profile to a physical network adapter NIC using the WlanSetProfile
		/// function, and specified an unacceptable value for the maximum number of clients allowed.
		/// </summary>
		WLAN_REASON_CODE_BAD_MAX_NUMBER_OF_CLIENTS_FOR_AP = (WLAN_REASON_CODE_PROFILE_BASE + 22),

		/// <summary/>
		WLAN_REASON_CODE_BASE = L2_REASON_CODE_DOT11_AC_BASE,

		/// <summary>The basic service set (BSS) type is not allowed on this wireless adapter.</summary>
		WLAN_REASON_CODE_BSS_TYPE_NOT_ALLOWED = (WLAN_REASON_CODE_AC_CONNECT_BASE + 5),

		/// <summary>The BSS type does not match.</summary>
		WLAN_REASON_CODE_BSS_TYPE_UNMATCH = (WLAN_REASON_CODE_MSM_BASE + 3),

		/// <summary>The security settings conflict.</summary>
		WLAN_REASON_CODE_CONFLICT_SECURITY = (WLAN_REASON_CODE_PROFILE_BASE + 11),

		/// <summary>The Media Specific Module (MSM) connect call fails.</summary>
		WLAN_REASON_CODE_CONNECT_CALL_FAIL = (WLAN_REASON_CODE_AC_CONNECT_BASE + 9),

		/// <summary>The data rate does not match.</summary>
		WLAN_REASON_CODE_DATARATE_UNMATCH = (WLAN_REASON_CODE_MSM_BASE + 5),

		/// <summary>Timed out waiting for the driver to disconnect.</summary>
		WLAN_REASON_CODE_DISCONNECT_TIMEOUT = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 15),

		/// <summary>Driver disconnected.</summary>
		WLAN_REASON_CODE_DRIVER_DISCONNECTED = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 11),

		/// <summary>Driver failed to perform some operations.</summary>
		WLAN_REASON_CODE_DRIVER_OPERATION_FAILURE = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 12),

		/// <summary>The wireless network is blocked by group policy.</summary>
		WLAN_REASON_CODE_GP_DENIED = (WLAN_REASON_CODE_AC_CONNECT_BASE + 3),

		/// <summary/>
		WLAN_REASON_CODE_HOTSPOT2_PROFILE_DENIED = (WLAN_REASON_CODE_AC_CONNECT_BASE + 17),

		/// <summary/>
		WLAN_REASON_CODE_HOTSPOT2_PROFILE_NOT_ALLOWED = (WLAN_REASON_CODE_PROFILE_BASE + 27),

		/// <summary/>
		WLAN_REASON_CODE_IHV_CONNECTIVITY_NOT_SUPPORTED = (WLAN_REASON_CODE_PROFILE_BASE + 21),

		/// <summary>The IHV service is not available.</summary>
		WLAN_REASON_CODE_IHV_NOT_AVAILABLE = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 13),

		/// <summary>The response from the IHV service timed out.</summary>
		WLAN_REASON_CODE_IHV_NOT_RESPONDING = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 14),

		/// <summary>The IHV profile OUI did not match with the adapter OUI.</summary>
		WLAN_REASON_CODE_IHV_OUI_MISMATCH = (WLAN_REASON_CODE_PROFILE_BASE + 8),

		/// <summary>The IHV OUI settings are missing.</summary>
		WLAN_REASON_CODE_IHV_OUI_MISSING = (WLAN_REASON_CODE_PROFILE_BASE + 9),

		/// <summary>The independent hardware vendor (IHV) security settings are missing.</summary>
		WLAN_REASON_CODE_IHV_SECURITY_NOT_SUPPORTED = (WLAN_REASON_CODE_PROFILE_BASE + 7),

		/// <summary>The IHV 802.1X security settings are missing.</summary>
		WLAN_REASON_CODE_IHV_SECURITY_ONEX_MISSING = (WLAN_REASON_CODE_PROFILE_BASE + 18),

		/// <summary>The IHV security settings are missing.</summary>
		WLAN_REASON_CODE_IHV_SETTINGS_MISSING = (WLAN_REASON_CODE_PROFILE_BASE + 10),

		/// <summary>The wireless network is in the blocked list.</summary>
		WLAN_REASON_CODE_IN_BLOCKED_LIST = (WLAN_REASON_CODE_AC_CONNECT_BASE + 7),

		/// <summary>The wireless network is in the failed list.</summary>
		WLAN_REASON_CODE_IN_FAILED_LIST = (WLAN_REASON_CODE_AC_CONNECT_BASE + 6),

		/// <summary>An internal error prevented the operation from being completed.</summary>
		WLAN_REASON_CODE_INTERNAL_FAILURE = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 16),

		/// <summary>Automatic connection cannot be set for an ad hoc network.</summary>
		WLAN_REASON_CODE_INVALID_ADHOC_CONNECTION_MODE = (WLAN_REASON_CODE_PROFILE_BASE + 14),

		/// <summary>The BSS type is not valid.</summary>
		WLAN_REASON_CODE_INVALID_BSS_TYPE = (WLAN_REASON_CODE_PROFILE_BASE + 13),

		/// <summary>The channel specified is invalid.</summary>
		WLAN_REASON_CODE_INVALID_CHANNEL = (WLAN_REASON_CODE_PROFILE_BASE + 23),

		/// <summary>The PHY type is invalid.</summary>
		WLAN_REASON_CODE_INVALID_PHY_TYPE = (WLAN_REASON_CODE_PROFILE_BASE + 5),

		/// <summary>The name of the profile is invalid.</summary>
		WLAN_REASON_CODE_INVALID_PROFILE_NAME = (WLAN_REASON_CODE_PROFILE_BASE + 3),

		/// <summary>The profile invalid according to the schema.</summary>
		WLAN_REASON_CODE_INVALID_PROFILE_SCHEMA = (WLAN_REASON_CODE_PROFILE_BASE + 1),

		/// <summary>The type of the profile is invalid.</summary>
		WLAN_REASON_CODE_INVALID_PROFILE_TYPE = (WLAN_REASON_CODE_PROFILE_BASE + 4),

		/// <summary>The profile key does not match the network key.</summary>
		WLAN_REASON_CODE_KEY_MISMATCH = (WLAN_REASON_CODE_AC_CONNECT_BASE + 13),

		/// <summary/>
		WLAN_REASON_CODE_MSM_BASE = L2_REASON_CODE_DOT11_MSM_BASE,

		/// <summary/>
		WLAN_REASON_CODE_MSM_CONNECT_BASE = (WLAN_REASON_CODE_MSM_BASE + WLAN_REASON_CODE_RANGE_SIZE / 2),

		/// <summary/>
		WLAN_REASON_CODE_MSM_END = (WLAN_REASON_CODE_MSM_BASE + WLAN_REASON_CODE_RANGE_SIZE - 1),

		/// <summary>The MSM security settings are missing.</summary>
		WLAN_REASON_CODE_MSM_SECURITY_MISSING = (WLAN_REASON_CODE_PROFILE_BASE + 6),

		/// <summary>802.1X authentication did not start within configured time.</summary>
		WLAN_REASON_CODE_MSMSEC_AUTH_START_TIMEOUT = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 2),

		/// <summary>802.1X authentication did not complete within configured time.</summary>
		WLAN_REASON_CODE_MSMSEC_AUTH_SUCCESS_TIMEOUT = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 3),

		/// <summary/>
		WLAN_REASON_CODE_MSMSEC_AUTH_WCN_COMPLETED = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 25),

		/// <summary/>
		WLAN_REASON_CODE_MSMSEC_BASE = L2_REASON_CODE_DOT11_SECURITY_BASE,

		/// <summary>Operation was canceled by a caller.</summary>
		WLAN_REASON_CODE_MSMSEC_CANCELLED = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 17),

		/// <summary>Network does not support specified capability type.</summary>
		WLAN_REASON_CODE_MSMSEC_CAPABILITY_DISCOVERY = (WLAN_REASON_CODE_MSMSEC_BASE + 21),

		/// <summary>
		/// The wireless LAN requires Management Frame Protection (MFP) and the network interface does not suppport MFP. For more
		/// informarion, see the IEEE 802.11w amendment to the 802.11 standard.
		/// </summary>
		WLAN_REASON_CODE_MSMSEC_CAPABILITY_MFP_NW_NIC = (WLAN_REASON_CODE_MSMSEC_BASE + 37),

		/// <summary>Capability matching failed at network.</summary>
		WLAN_REASON_CODE_MSMSEC_CAPABILITY_NETWORK = (WLAN_REASON_CODE_MSMSEC_BASE + 18),

		/// <summary>Capability matching failed at NIC.</summary>
		WLAN_REASON_CODE_MSMSEC_CAPABILITY_NIC = (WLAN_REASON_CODE_MSMSEC_BASE + 19),

		/// <summary>Capability matching failed at profile.</summary>
		WLAN_REASON_CODE_MSMSEC_CAPABILITY_PROFILE = (WLAN_REASON_CODE_MSMSEC_BASE + 20),

		/// <summary>Capability matching failed because the network does not support the authentication method in the profile.</summary>
		WLAN_REASON_CODE_MSMSEC_CAPABILITY_PROFILE_AUTH = (WLAN_REASON_CODE_MSMSEC_BASE + 30),

		/// <summary>Capability matching failed because the network does not support the cipher algorithm in the profile.</summary>
		WLAN_REASON_CODE_MSMSEC_CAPABILITY_PROFILE_CIPHER = (WLAN_REASON_CODE_MSMSEC_BASE + 31),

		/// <summary>Profile requires FIPS 140-2 mode, which is not supported by network interface card (NIC).</summary>
		WLAN_REASON_CODE_MSMSEC_CAPABILITY_PROFILE_SAFE_MODE_NIC = (WLAN_REASON_CODE_MSMSEC_BASE + 33),

		/// <summary>Profile requires FIPS 140-2 mode, which is not supported by network.</summary>
		WLAN_REASON_CODE_MSMSEC_CAPABILITY_PROFILE_SAFE_MODE_NW = (WLAN_REASON_CODE_MSMSEC_BASE + 34),

		/// <summary/>
		WLAN_REASON_CODE_MSMSEC_CONNECT_BASE = (WLAN_REASON_CODE_MSMSEC_BASE + WLAN_REASON_CODE_RANGE_SIZE / 2),

		/// <summary>A security downgrade was detected.</summary>
		WLAN_REASON_CODE_MSMSEC_DOWNGRADE_DETECTED = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 19),

		/// <summary/>
		WLAN_REASON_CODE_MSMSEC_END = (WLAN_REASON_CODE_MSMSEC_BASE + WLAN_REASON_CODE_RANGE_SIZE - 1),

		/// <summary>There was a forced failure because the connection method was not secure.</summary>
		WLAN_REASON_CODE_MSMSEC_FORCED_FAILURE = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 21),

		/// <summary>Message 1 of group key handshake has no group key.</summary>
		WLAN_REASON_CODE_MSMSEC_G1_MISSING_GRP_KEY = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 13),

		/// <summary>Message 1 of group key handshake has no key data.</summary>
		WLAN_REASON_CODE_MSMSEC_G1_MISSING_KEY_DATA = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 12),

		/// <summary>Message 1 of group key handshake has no group management key.</summary>
		WLAN_REASON_CODE_MSMSEC_G1_MISSING_MGMT_GRP_KEY = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 27),

		/// <summary>Entered key format is not in a valid format.</summary>
		WLAN_REASON_CODE_MSMSEC_KEY_FORMAT = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 18),

		/// <summary>Dynamic key exchange did not start within configured time.</summary>
		WLAN_REASON_CODE_MSMSEC_KEY_START_TIMEOUT = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 4),

		/// <summary>Dynamic key exchange did not complete within configured time.</summary>
		WLAN_REASON_CODE_MSMSEC_KEY_SUCCESS_TIMEOUT = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 5),

		/// <summary>Message 2 of 4 way handshake has no IE (RSN Adhoc).</summary>
		WLAN_REASON_CODE_MSMSEC_M2_MISSING_IE = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 24),

		/// <summary>Message 2 of 4 way handshake has no key data (RSN Adhoc).</summary>
		WLAN_REASON_CODE_MSMSEC_M2_MISSING_KEY_DATA = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 23),

		/// <summary>Message 3 of 4-way handshake has no GRP key.</summary>
		WLAN_REASON_CODE_MSMSEC_M3_MISSING_GRP_KEY = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 8),

		/// <summary>Message 3 of 4-way handshake has no IE.</summary>
		WLAN_REASON_CODE_MSMSEC_M3_MISSING_IE = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 7),

		/// <summary>Message 3 of 4-way handshake has no key data.</summary>
		WLAN_REASON_CODE_MSMSEC_M3_MISSING_KEY_DATA = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 6),

		/// <summary>Message 3 of 4 way handshake has no Mgmt Group Key (RSN).</summary>
		WLAN_REASON_CODE_MSMSEC_M3_MISSING_MGMT_GRP_KEY = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 26),

		/// <summary>Message 3 of 4 way handshake contains too many RSN IE (RSN).</summary>
		WLAN_REASON_CODE_MSMSEC_M3_TOO_MANY_RSNIE = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 22),

		/// <summary/>
		WLAN_REASON_CODE_MSMSEC_MAX = WLAN_REASON_CODE_MSMSEC_END,

		/// <summary/>
		WLAN_REASON_CODE_MSMSEC_MIN = WLAN_REASON_CODE_MSMSEC_BASE,

		/// <summary>A mixed cell is suspected. The AP is not signaling that it is compatible with a privacy-enabled profile.</summary>
		WLAN_REASON_CODE_MSMSEC_MIXED_CELL = (WLAN_REASON_CODE_MSMSEC_BASE + 25),

		/// <summary>Plumbing settings to NIC failed.</summary>
		WLAN_REASON_CODE_MSMSEC_NIC_FAILURE = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 16),

		/// <summary>802.1X indicated that there is no authenticator, but the profile requires one.</summary>
		WLAN_REASON_CODE_MSMSEC_NO_AUTHENTICATOR = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 15),

		/// <summary>Required a pairwise key but access point (AP) configured only group keys.</summary>
		WLAN_REASON_CODE_MSMSEC_NO_PAIRWISE_KEY = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 11),

		/// <summary>AP reset secure bit after connection was secured.</summary>
		WLAN_REASON_CODE_MSMSEC_PEER_INDICATED_INSECURE = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 14),

		/// <summary>Matching security capabilities of IE in M3 failed.</summary>
		WLAN_REASON_CODE_MSMSEC_PR_IE_MATCHING = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 9),

		/// <summary>The number of authentication timers or the number of timeouts specified in the profile is invalid.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_AUTH_TIMERS_INVALID = (WLAN_REASON_CODE_MSMSEC_BASE + 26),

		/// <summary>Profile contains duplicate auth/cipher pair.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_DUPLICATE_AUTH_CIPHER = (WLAN_REASON_CODE_MSMSEC_BASE + 7),

		/// <summary>Invalid auth/cipher combination.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_INVALID_AUTH_CIPHER = (WLAN_REASON_CODE_MSMSEC_BASE + 9),

		/// <summary>The group key update interval specified in the profile is invalid.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_INVALID_GKEY_INTV = (WLAN_REASON_CODE_MSMSEC_BASE + 27),

		/// <summary>Key index specified is not valid.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_INVALID_KEY_INDEX = (WLAN_REASON_CODE_MSMSEC_BASE + 1),

		/// <summary>Invalid PMK cache mode.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_INVALID_PMKCACHE_MODE = (WLAN_REASON_CODE_MSMSEC_BASE + 12),

		/// <summary>Invalid PMK cache size.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_INVALID_PMKCACHE_SIZE = (WLAN_REASON_CODE_MSMSEC_BASE + 13),

		/// <summary>Invalid PMK cache TTL.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_INVALID_PMKCACHE_TTL = (WLAN_REASON_CODE_MSMSEC_BASE + 14),

		/// <summary>Invalid preauth mode.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_INVALID_PREAUTH_MODE = (WLAN_REASON_CODE_MSMSEC_BASE + 15),

		/// <summary>Invalid preauth throttle.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_INVALID_PREAUTH_THROTTLE = (WLAN_REASON_CODE_MSMSEC_BASE + 16),

		/// <summary>Invalid key length.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_KEY_LENGTH = (WLAN_REASON_CODE_MSMSEC_BASE + 3),

		/// <summary>The key contains characters that are not in the ASCII character set.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_KEY_UNMAPPED_CHAR = (WLAN_REASON_CODE_MSMSEC_BASE + 29),

		/// <summary>Key material contains invalid character.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_KEYMATERIAL_CHAR = (WLAN_REASON_CODE_MSMSEC_BASE + 23),

		/// <summary>No auth/cipher pairs specified.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_NO_AUTH_CIPHER_SPECIFIED = (WLAN_REASON_CODE_MSMSEC_BASE + 5),

		/// <summary>802.1X disabled when it is required to be enabled.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_ONEX_DISABLED = (WLAN_REASON_CODE_MSMSEC_BASE + 10),

		/// <summary>802.1X enabled when it is required to be disabled.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_ONEX_ENABLED = (WLAN_REASON_CODE_MSMSEC_BASE + 11),

		/// <summary>Passphrase contains invalid character.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_PASSPHRASE_CHAR = (WLAN_REASON_CODE_MSMSEC_BASE + 22),

		/// <summary>Preauth enabled when PMK cache is disabled.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_PREAUTH_ONLY_ENABLED = (WLAN_REASON_CODE_MSMSEC_BASE + 17),

		/// <summary>Invalid PSK length.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_PSK_LENGTH = (WLAN_REASON_CODE_MSMSEC_BASE + 4),

		/// <summary>Key required, PSK present.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_PSK_PRESENT = (WLAN_REASON_CODE_MSMSEC_BASE + 2),

		/// <summary>Profile raw data is invalid.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_RAWDATA_INVALID = (WLAN_REASON_CODE_MSMSEC_BASE + 8),

		/// <summary>FIPS 140-2 mode value in the profile is invalid.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_SAFE_MODE = (WLAN_REASON_CODE_MSMSEC_BASE + 32),

		/// <summary>Too many auth/cipher pairs specified.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_TOO_MANY_AUTH_CIPHER_SPECIFIED = (WLAN_REASON_CODE_MSMSEC_BASE + 6),

		/// <summary>Profile specifies an unsupported authentication mechanism.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_UNSUPPORTED_AUTH = (WLAN_REASON_CODE_MSMSEC_BASE + 35),

		/// <summary>Profile specifies an unsupported cipher.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_UNSUPPORTED_CIPHER = (WLAN_REASON_CODE_MSMSEC_BASE + 36),

		/// <summary>The key type specified does not match the key material.</summary>
		WLAN_REASON_CODE_MSMSEC_PROFILE_WRONG_KEYTYPE = (WLAN_REASON_CODE_MSMSEC_BASE + 24),

		/// <summary>A PSK mismatch is suspected.</summary>
		WLAN_REASON_CODE_MSMSEC_PSK_MISMATCH_SUSPECTED = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 20),

		/// <summary>Matching security capabilities of secondary IE in M3 failed.</summary>
		WLAN_REASON_CODE_MSMSEC_SEC_IE_MATCHING = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 10),

		/// <summary>A "transition network" is suspected. Legacy 802.11 security is used for the next authentication attempt.</summary>
		WLAN_REASON_CODE_MSMSEC_TRANSITION_NETWORK = (WLAN_REASON_CODE_MSMSEC_BASE + 28),

		/// <summary>Failed to queue the user interface request.</summary>
		WLAN_REASON_CODE_MSMSEC_UI_REQUEST_FAILURE = (WLAN_REASON_CODE_MSMSEC_CONNECT_BASE + 1),

		/// <summary>
		/// The specified network is not available.This reason code is also used when there is a mismatch between capabilities specified
		/// in an XML profile and interface and/or network capabilities. For example, if a profile specifies the use of WPA2 when the
		/// NIC only supports WPA, then this error code is returned. Also, if a profile specifies the use of FIPS mode when the NIC does
		/// not support FIPS mode, then this error code is returned.
		/// </summary>
		WLAN_REASON_CODE_NETWORK_NOT_AVAILABLE = (WLAN_REASON_CODE_AC_CONNECT_BASE + 11),

		/// <summary>The wireless network is not compatible.</summary>
		WLAN_REASON_CODE_NETWORK_NOT_COMPATIBLE = (WLAN_REASON_CODE_AC_BASE + 1),

		/// <summary>The profile specifies no auto connection.</summary>
		WLAN_REASON_CODE_NO_AUTO_CONNECTION = (WLAN_REASON_CODE_AC_CONNECT_BASE + 1),

		/// <summary>Non-broadcast cannot be set for an ad hoc network.</summary>
		WLAN_REASON_CODE_NON_BROADCAST_SET_FOR_ADHOC = (WLAN_REASON_CODE_PROFILE_BASE + 15),

		/// <summary>The wireless network is not visible.</summary>
		WLAN_REASON_CODE_NOT_VISIBLE = (WLAN_REASON_CODE_AC_CONNECT_BASE + 2),

		/// <summary/>
		WLAN_REASON_CODE_OPERATION_MODE_NOT_SUPPORTED = (WLAN_REASON_CODE_PROFILE_BASE + 24),

		/// <summary>The PHY type does not match.</summary>
		WLAN_REASON_CODE_PHY_TYPE_UNMATCH = (WLAN_REASON_CODE_MSM_BASE + 4),

		/// <summary>Pre-association security failure.</summary>
		WLAN_REASON_CODE_PRE_SECURITY_FAILURE = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 4),

		/// <summary/>
		WLAN_REASON_CODE_PROFILE_BASE = L2_REASON_CODE_PROFILE_BASE,

		/// <summary>The profile was changed or deleted before the connection was established.</summary>
		WLAN_REASON_CODE_PROFILE_CHANGED_OR_DELETED = (WLAN_REASON_CODE_AC_CONNECT_BASE + 12),

		/// <summary/>
		WLAN_REASON_CODE_PROFILE_CONNECT_BASE = (WLAN_REASON_CODE_PROFILE_BASE + WLAN_REASON_CODE_RANGE_SIZE / 2),

		/// <summary/>
		WLAN_REASON_CODE_PROFILE_END = (WLAN_REASON_CODE_PROFILE_BASE + WLAN_REASON_CODE_RANGE_SIZE - 1),

		/// <summary>The WLANProfile element is missing.</summary>
		WLAN_REASON_CODE_PROFILE_MISSING = (WLAN_REASON_CODE_PROFILE_BASE + 2),

		/// <summary>The wireless network profile is not compatible.</summary>
		WLAN_REASON_CODE_PROFILE_NOT_COMPATIBLE = (WLAN_REASON_CODE_AC_BASE + 2),

		/// <summary>The SSID in the profile is invalid or missing.</summary>
		WLAN_REASON_CODE_PROFILE_SSID_INVALID = (WLAN_REASON_CODE_PROFILE_BASE + 19),

		/// <summary/>
		WLAN_REASON_CODE_RANGE_SIZE = L2_REASON_CODE_GROUP_SIZE,

		/// <summary/>
		WLAN_REASON_CODE_RESERVED_BASE = L2_REASON_CODE_RESERVED_BASE,

		/// <summary/>
		WLAN_REASON_CODE_RESERVED_END = (WLAN_REASON_CODE_RESERVED_BASE + WLAN_REASON_CODE_RANGE_SIZE - 1),

		/// <summary>Driver disconnected while roaming.</summary>
		WLAN_REASON_CODE_ROAMING_FAILURE = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 8),

		/// <summary>Failed to start security for roaming.</summary>
		WLAN_REASON_CODE_ROAMING_SECURITY_FAILURE = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 9),

		/// <summary>The MSM scan call fails.</summary>
		WLAN_REASON_CODE_SCAN_CALL_FAIL = (WLAN_REASON_CODE_AC_CONNECT_BASE + 10),

		/// <summary>Security ends up with failure.</summary>
		WLAN_REASON_CODE_SECURITY_FAILURE = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 6),

		/// <summary>The security settings are missing.</summary>
		WLAN_REASON_CODE_SECURITY_MISSING = (WLAN_REASON_CODE_PROFILE_BASE + 12),

		/// <summary>Security operation times out.</summary>
		WLAN_REASON_CODE_SECURITY_TIMEOUT = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 7),

		/// <summary>The size of the service set identifiers (SSID) list exceeds the maximum size supported by the adapter.</summary>
		WLAN_REASON_CODE_SSID_LIST_TOO_LONG = (WLAN_REASON_CODE_AC_CONNECT_BASE + 8),

		/// <summary>Failed to start security after association.</summary>
		WLAN_REASON_CODE_START_SECURITY_FAILURE = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 5),

		/// <summary>Roaming too often. Post security was not completed after 5 attempts.</summary>
		WLAN_REASON_CODE_TOO_MANY_SECURITY_ATTEMPTS = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 18),

		/// <summary>Too many SSIDs were specified in the profile.</summary>
		WLAN_REASON_CODE_TOO_MANY_SSID = (WLAN_REASON_CODE_PROFILE_BASE + 20),

		/// <summary>A user interaction request timed out.</summary>
		WLAN_REASON_CODE_UI_REQUEST_TIMEOUT = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 17),

		/// <summary>The security settings are not supported.</summary>
		WLAN_REASON_CODE_UNSUPPORTED_SECURITY_SET = (WLAN_REASON_CODE_MSM_BASE + 2),

		/// <summary>The security settings are not supported by the operating system.</summary>
		WLAN_REASON_CODE_UNSUPPORTED_SECURITY_SET_BY_OS = (WLAN_REASON_CODE_MSM_BASE + 1),

		/// <summary>User has canceled the operation.</summary>
		WLAN_REASON_CODE_USER_CANCELLED = (WLAN_REASON_CODE_MSM_CONNECT_BASE + 1),

		/// <summary>The wireless network is blocked by the user.</summary>
		WLAN_REASON_CODE_USER_DENIED = (WLAN_REASON_CODE_AC_CONNECT_BASE + 4),

		/// <summary>The user is not responding.</summary>
		WLAN_REASON_CODE_USER_NOT_RESPOND = (WLAN_REASON_CODE_AC_CONNECT_BASE + 14),
	}

	/// <summary>
	/// <para>The <c>WLAN_SECURABLE_OBJECT</c> enumerated type defines the securable objects used by Native Wifi Functions.</para>
	/// <para>
	/// These objects can be secured using WlanSetSecuritySettings. The current permissions associated with these objects can be
	/// retrieved using WlanGetSecuritySettings. For more information about the use of securable objects, see How DACLs Control Access
	/// to an Object.
	/// </para>
	/// </summary>
	/// <remarks>
	/// These objects can be secured using WlanSetSecuritySettings. The current permissions associated with these objects can be
	/// retrieved using WlanGetSecuritySettings. For more information about the use of securable objects, see How DACLs Control Access
	/// to an Object and Native Wifi API Permissions.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ne-wlanapi-wlan_securable_object typedef enum _WLAN_SECURABLE_OBJECT {
	// wlan_secure_permit_list, wlan_secure_deny_list, wlan_secure_ac_enabled, wlan_secure_bc_scan_enabled, wlan_secure_bss_type,
	// wlan_secure_show_denied, wlan_secure_interface_properties, wlan_secure_ihv_control, wlan_secure_all_user_profiles_order,
	// wlan_secure_add_new_all_user_profiles, wlan_secure_add_new_per_user_profiles, wlan_secure_media_streaming_mode_enabled,
	// wlan_secure_current_operation_mode, wlan_secure_get_plaintext_key, wlan_secure_hosted_network_elevated_access,
	// wlan_secure_virtual_station_extensibility, wlan_secure_wfd_elevated_access, WLAN_SECURABLE_OBJECT_COUNT } WLAN_SECURABLE_OBJECT, *PWLAN_SECURABLE_OBJECT;
	[PInvokeData("wlanapi.h", MSDNShortId = "1f6e1460-d27f-4800-8a32-6f9f509753cf")]
	public enum WLAN_SECURABLE_OBJECT
	{
		/// <summary>
		/// The permissions for modifying the permit list for user profiles.The discretionary access control lists (DACL) associated
		/// with this securable object is retrieved when either WlanGetFilterList or WlanSetFilterList is called with wlanFilterListType
		/// set to wlan_filter_list_type_user_permit. For the WlanGetFilterList call to succeed, the DACL must contain an access control
		/// entry (ACE) that grants WLAN_READ_ACCESS permission to the access token of the calling thread. For the WlanSetFilterList
		/// call to succeed, the DACL must contain an ACE that grants WLAN_WRITE_ACCESS permission to the access token of the calling thread.
		/// </summary>
		wlan_secure_permit_list,

		/// <summary>
		/// The permissions for modifying the deny list for user profiles. The auto config service will not establish a connection to a
		/// network on the deny list.The DACL associated with this securable object is retrieved when either WlanGetFilterList or
		/// WlanSetFilterList is called with wlanFilterListType set to wlan_filter_list_type_user_deny. For the WlanGetFilterList call
		/// to succeed, the DACL must contain an ACE that grants WLAN_READ_ACCESS permission to the access token of the calling thread.
		/// For the WlanSetFilterList call to succeed, the DACL must contain an ACE that grants WLAN_WRITE_ACCESS permission to the
		/// access token of the calling thread.
		/// </summary>
		wlan_secure_deny_list,

		/// <summary>
		/// The permissions for enabling the auto config service.The DACL associated with this securable object is retrieved when either
		/// WlanQueryInterface or WlanSetInterface is called with OpCode set to wlan_intf_opcode_autoconf_enabled. For the
		/// WlanQueryInterface call to succeed, the DACL must contain an ACE that grants WLAN_READ_ACCESS permission to the access token
		/// of the calling thread. For the WlanSetInterface call to succeed, the DACL must contain an ACE that grants WLAN_WRITE_ACCESS
		/// permission to the access token of the calling thread.
		/// </summary>
		wlan_secure_ac_enabled,

		/// <summary>
		/// The permissions for enabling background scans.The DACL associated with this securable object is retrieved when either
		/// WlanQueryInterface or WlanSetInterface is called with OpCode set to wlan_intf_opcode_background_scan_enabled. For the
		/// WlanQueryInterface call to succeed, the DACL must contain an ACE that grants WLAN_READ_ACCESS permission to the access token
		/// of the calling thread. For the WlanSetInterface call to succeed, the DACL must contain an ACE that grants WLAN_WRITE_ACCESS
		/// permission to the access token of the calling thread.
		/// </summary>
		wlan_secure_bc_scan_enabled,

		/// <summary>
		/// The permissions for altering the basic service set type.The DACL associated with this securable object is retrieved when
		/// either WlanQueryInterface or WlanSetInterface is called with OpCode set to wlan_intf_opcode_bss_type. For the
		/// WlanQueryInterface call to succeed, the DACL must contain an ACE that grants WLAN_READ_ACCESS permission to the access token
		/// of the calling thread. For the WlanSetInterface call to succeed, the DACL must contain an ACE that grants WLAN_WRITE_ACCESS
		/// permission to the access token of the calling thread.
		/// </summary>
		wlan_secure_bss_type,

		/// <summary>
		/// The permissions for modifying whether networks on the deny list appear in the available networks list.The DACL associated
		/// with this securable object is retrieved when either WlanQueryAutoConfigParameter or WlanSetAutoConfigParameter is called
		/// with OpCode set to wlan_autoconf_opcode_show_denied_networks. For the WlanQueryAutoConfigParameter call to succeed, the DACL
		/// must contain an ACE that grants WLAN_READ_ACCESS permission to the access token of the calling thread. For the
		/// WlanSetAutoConfigParameter call to succeed, the DACL must contain an ACE that grants WLAN_WRITE_ACCESS permission to the
		/// access token of the calling thread.
		/// </summary>
		wlan_secure_show_denied,

		/// <summary>
		/// The permissions for changing interface properties.This is the generic securable object used by WlanQueryInterface or
		/// WlanSetInterface when another more specific securable object is not used. Its DACL is retrieved whenever WlanQueryInterface
		/// or WlanSetInterface is access token of the calling thread and the OpCode is set to a value other than
		/// wlan_intf_opcode_autoconf_enabled, wlan_intf_opcode_background_scan_enabled, wlan_intf_opcode_media_streaming_mode,
		/// wlan_intf_opcode_bss_type, or wlan_intf_opcode_current_operation_mode. The DACL is also not retrieved when OpCode is set to
		/// wlan_intf_opcode_radio_state and the caller is the console user.For the WlanQueryInterface call to succeed, the DACL must
		/// contain an ACE that grants WLAN_READ_ACCESS permission to the access token of the calling thread. For the WlanSetInterface
		/// call to succeed, the DACL must contain an ACE that grants WLAN_WRITE_ACCESS permission to the access token of the calling thread.
		/// </summary>
		wlan_secure_interface_properties,

		/// <summary>
		/// The permissions for using the WlanIhvControl function for independent hardware vendor (IHV) control of WLAN drivers or
		/// services.The DACL associated with this securable object is retrieved when WlanIhvControl is called. For the call to succeed,
		/// the DACL must contain an ACE that grants WLAN_WRITE_ACCESS permission to the access token of the calling thread.
		/// </summary>
		wlan_secure_ihv_control,

		/// <summary>
		/// The permissions for modifying the order of all-user profiles.The DACL associated with this securable object is retrieved
		/// before WlanSetProfileList or WlanSetProfilePosition performs an operation that changes the relative order of all-user
		/// profiles in the profile list or moves an all-user profile to a lower position in the profile list. For either call to
		/// succeed, the DACL must contain an ACE that grants WLAN_WRITE_ACCESS permission to the access token of the calling thread.
		/// </summary>
		wlan_secure_all_user_profiles_order,

		/// <summary>
		/// The permissions for adding new all-user profiles.The DACL associated with this securable object is retrieved when
		/// WlanSetProfile is called with dwFlags set to 0. For the call to succeed, the DACL must contain an ACE that grants
		/// WLAN_WRITE_ACCESS permission to the access token of the calling thread.
		/// </summary>
		wlan_secure_add_new_all_user_profiles,

		/// <summary>
		/// The permissions for adding new per-user profiles.The DACL associated with this securable object is retrieved when
		/// WlanSetProfile is called with dwFlags set to WLAN_PROFILE_USER. For the call to succeed, the DACL must contain an ACE that
		/// grants WLAN_WRITE_ACCESS permission to the access token of the calling thread.
		/// </summary>
		wlan_secure_add_new_per_user_profiles,

		/// <summary>
		/// The permissions for setting or querying the media streaming mode.The DACL associated with this securable object is retrieved
		/// when either WlanQueryInterface or WlanSetInterface is called with OpCode set to wlan_intf_opcode_media_streaming_mode. For
		/// the WlanQueryInterface call to succeed, the DACL must contain an ACE that grants WLAN_READ_ACCESS permission to the access
		/// token of the calling thread. For the WlanSetInterface call to succeed, the DACL must contain an ACE that grants
		/// WLAN_WRITE_ACCESS permission to the access token of the calling thread.
		/// </summary>
		wlan_secure_media_streaming_mode_enabled,

		/// <summary>
		/// The permissions for setting or querying the operation mode of the wireless interface.The DACL associated with this securable
		/// object is retrieved when either WlanQueryInterface or WlanSetInterface is called with OpCode set to
		/// wlan_intf_opcode_current_operation_mode. For the WlanQueryInterface call to succeed, the DACL must contain an ACE that
		/// grants WLAN_READ_ACCESS permission to the access token of the calling thread. For the WlanSetInterface call to succeed, the
		/// DACL must contain an ACE that grants WLAN_WRITE_ACCESS permission to the access token of the calling thread.
		/// </summary>
		wlan_secure_current_operation_mode,

		/// <summary>
		/// The permissions for retrieving the plain text key from a wireless profile. The DACL associated with this securable object is
		/// retrieved when the WlanGetProfile function is called with the WLAN_PROFILE_GET_PLAINTEXT_KEY flag set in the value pointed
		/// to by the pdwFlags parameter on input. For the WlanGetProfile call to succeed, the DACL must contain an ACE that grants
		/// WLAN_READ_ACCESS permission to the access token of the calling thread. By default, the permissions for retrieving the plain
		/// text key is allowed only to the members of the Administrators group on a local computer.Windows 7: This value is an
		/// extension to native wireless APIs added on Windows 7 and later.
		/// </summary>
		wlan_secure_get_plaintext_key,

		/// <summary>
		/// The permissions that have elevated access to call the privileged Hosted Network functions. The DACL associated with this
		/// securable object is retrieved when the WlanHostedNetworkSetProperty function is called with the OpCode parameter set to
		/// wlan_hosted_network_opcode_enable. For the WlanHostedNetworkSetProperty call to succeed, the DACL must contain an ACE that
		/// grants WLAN_WRITE_ACCESS permission to the access token of the calling thread. By default, the permission to set the
		/// wireless Hosted Network property to wlan_hosted_network_opcode_enable is allowed only to the members of the Administrators
		/// group on a local computer. The DACL associated with this securable object is retrieved when the WlanHostedNetworkForceStart
		/// function is called. For the WlanHostedNetworkForceStart call to succeed, the DACL must contain an ACE that grants
		/// WLAN_WRITE_ACCESS permission to the access token of the calling thread. By default, the permission to force start the
		/// wireless Hosted Network is allowed only to the members of the Administrators group on a local computer.Windows 7: This value
		/// is an extension to native wireless APIs added on Windows 7 and later.
		/// </summary>
		wlan_secure_hosted_network_elevated_access,

		/// <summary>Windows 7: This value is an extension to native wireless APIs added on Windows 7 and later.</summary>
		wlan_secure_virtual_station_extensibility,

		/// <summary>
		/// This value is reserved for internal use by the Wi-Fi Direct service. Windows 8: This value is an extension to native
		/// wireless APIs added on Windows 8 and later.
		/// </summary>
		wlan_secure_wfd_elevated_access,

		/// <summary/>
		WLAN_SECURABLE_OBJECT_COUNT,
	}

	/// <summary>EAPHost data storage flags</summary>
	[PInvokeData("wlanapi.h")]
	public enum WLAN_SET_EAPHOST
	{
		/// <summary>Set EAP host data for all users of this profile.</summary>
		WLAN_SET_EAPHOST_DATA_ALL_USERS = 0x00000001
	}
}