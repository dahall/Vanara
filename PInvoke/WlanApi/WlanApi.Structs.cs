#pragma warning disable IDE1006 // Naming Styles

namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from wlanapi.h.</summary>
public static partial class WlanApi
{
	private const int DOT11_RATE_SET_MAX_LENGTH = 126;

	private const int DOT11_SSID_MAX_LENGTH = 32;

	private const int WLAN_MAX_NAME_LENGTH = 256;

	private const int WLAN_MAX_PHY_INDEX = 64;

	private const int WLAN_MAX_PHY_TYPE_NUMBER = 8;

	/// <summary>
	/// The <c>DOT11_AUTH_CIPHER_PAIR</c> structure defines a pair of 802.11 authentication and cipher algorithms that can be enabled at
	/// the same time on the 802.11 station.
	/// </summary>
	/// <remarks>
	/// The DOT11_AUTH_CIPHER_PAIR structure defines an authentication and cipher algorithm that can be enabled together for basic
	/// service set (BSS) network connections.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/nativewifi/dot11-auth-cipher-pair typedef struct _DOT11_AUTH_CIPHER_PAIR {
	// DOT11_AUTH_ALGORITHM AuthAlgoId; DOT11_CIPHER_ALGORITHM CipherAlgoId; } DOT11_AUTH_CIPHER_PAIR, *PDOT11_AUTH_CIPHER_PAIR;
	[PInvokeData("windot11.h", MSDNShortId = "5fbe23f6-7902-46d4-a1f0-57f045d78662")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DOT11_AUTH_CIPHER_PAIR
	{
		/// <summary>An authentication algorithm that uses a <c>DOT11_AUTH_ALGORITHM</c> enumerated type.</summary>
		public DOT11_AUTH_ALGORITHM AuthAlgoId;

		/// <summary>A cipher algorithm that uses a <c>DOT11_CIPHER_ALGORITHM</c> enumerated type.</summary>
		public DOT11_CIPHER_ALGORITHM CipherAlgoId;
	}

	/// <summary>The <c>DOT11_BSSID_LIST</c> structure contains a list of basic service set (BSS) identifiers.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/nativewifi/dot11-bssid-list typedef struct _DOT11_BSSID_LIST { NDIS_OBJECT_HEADER
	// Header; ULONG uNumOfEntries; ULONG uTotalNumOfEntries; DOT11_MAC_ADDRESS BSSIDs[1]; } DOT11_BSSID_LIST, *PDOT11_BSSID_LIST;
	[PInvokeData("windot11.h", MSDNShortId = "22907f94-1ae8-4938-a816-b406656256c0")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DOT11_BSSID_LIST>), nameof(uTotalNumOfEntries))]
	[StructLayout(LayoutKind.Sequential)]
	public struct DOT11_BSSID_LIST
	{
		/// <summary>
		/// An <c>NDIS_OBJECT_HEADER</c> structure that contains the type, version, and, size information of an NDIS structure. For most
		/// <c>DOT11_BSSID_LIST</c> structures, set the <c>Type</c> member to <c>NDIS_OBJECT_TYPE_DEFAULT</c>, set the <c>Revision</c>
		/// member to <c>DOT11_BSSID_LIST_REVISION_1</c>, and set the <c>Size</c> member to <c>sizeof(DOT11_BSSID_LIST)</c>.
		/// </summary>
		public NDIS_OBJECT_HEADER Header;

		/// <summary>The number of entries in this structure.</summary>
		public uint uNumOfEntries;

		/// <summary>The total number of entries supported.</summary>
		public uint uTotalNumOfEntries;

		/// <summary>A list of BSS identifiers. A BSS identifier is stored as a <c>DOT11_MAC_ADDRESS</c> type.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public DOT11_MAC_ADDRESS[] BSSIDs;
	}

	/// <summary>Supported country or region strings.</summary>
	[PInvokeData("wlanapi.h", MSDNShortId = "64343c1f-3543-406f-a64c-94196b8aa17e")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct DOT11_COUNTRY_OR_REGION_STRING
	{
		/// <summary/>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
		public string Value;
	}

	/// <summary>The <c>DOT11_MAC_ADDRESS</c> types are used to define an IEEE media access control (MAC) address.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/nativewifi/dot11-mac-address-type
	[PInvokeData("Windot11.h", MSDNShortId = "c1335127-a2d2-4f44-a895-1abbc5eaf98d")]
	public struct DOT11_MAC_ADDRESS
	{
		/// <summary>A MAC address in unicast, multicast, or broadcast format.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		public byte[] ucDot11MacAddress;

		/// <inheritdoc/>
		public override string ToString() => string.Join(":", Array.ConvertAll(ucDot11MacAddress, b => b.ToString("X2")));
	}

	/// <summary>The <c>DOT11_NETWORK</c> structure contains information about an available wireless network.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-dot11_network typedef struct _DOT11_NETWORK { DOT11_SSID
	// dot11Ssid; DOT11_BSS_TYPE dot11BssType; } DOT11_NETWORK, *PDOT11_NETWORK;
	[PInvokeData("wlanapi.h", MSDNShortId = "95f58433-deef-4c47-8f6c-a9e7b0d52dad")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DOT11_NETWORK
	{
		/// <summary>A DOT11_SSID structure that contains the SSID of a visible wireless network.</summary>
		public DOT11_SSID dot11Ssid;

		/// <summary>A DOT11_BSS_TYPE value that indicates the BSS type of the network.</summary>
		public DOT11_BSS_TYPE dot11BssType;

		/// <summary>Initializes a new instance of the <see cref="DOT11_NETWORK"/> struct.</summary>
		/// <param name="ssid">The SSID of a visible wireless network.</param>
		/// <param name="bssType">A DOT11_BSS_TYPE value that indicates the BSS type of the network.</param>
		public DOT11_NETWORK(string ssid, DOT11_BSS_TYPE bssType = DOT11_BSS_TYPE.dot11_BSS_type_infrastructure)
		{
			dot11BssType = bssType;
			dot11Ssid = new DOT11_SSID { ucSSID = ssid, uSSIDLength = (uint)(ssid?.Length ?? 0) };
		}
	}

	/// <summary>A <c>DOT11_SSID</c> structure contains the SSID of an interface.</summary>
	/// <remarks>
	/// <para>
	/// The SSID that is specified by the <c>ucSSID</c> member is not a null-terminated ASCII string. The length of the SSID is
	/// determined by the <c>uSSIDLength</c> member.
	/// </para>
	/// <para>
	/// A wildcard SSID is an SSID whose <c>uSSIDLength</c> member is set to zero. When the desired SSID is set to the wildcard SSID,
	/// the 802.11 station can connect to any basic service set (BSS) network.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/nativewifi/dot11-ssid typedef struct _DOT11_SSID { ULONG uSSIDLength; UCHAR
	// ucSSID[DOT11_SSID_MAX_LENGTH]; } DOT11_SSID, *PDOT11_SSID;
	[PInvokeData("wlantypes.h", MSDNShortId = "f2b15ef9-99ee-4505-8575-224112024d7a")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct DOT11_SSID
	{
		/// <summary>The length, in bytes, of the <c>ucSSID</c> array.</summary>
		public uint uSSIDLength;

		/// <summary>The SSID. DOT11_SSID_MAX_LENGTH is set to 32.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = DOT11_SSID_MAX_LENGTH)]
		public string ucSSID;

		/// <inheritdoc/>
		public override string ToString() => ucSSID?.Substring(0, (int)uSSIDLength);
	}

	/// <summary>The <c>EAP_METHOD_TYPE</c> structure contains type, identification, and author information about an EAP method.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/eaptypes/ns-eaptypes-eap_method_type typedef struct _EAP_METHOD_TYPE {
	// EAP_TYPE eapType; DWORD dwAuthorId; } EAP_METHOD_TYPE;
	[PInvokeData("eaptypes.h", MSDNShortId = "47702dd9-d9c2-4dd5-a12d-23a55b031d27")]
	[StructLayout(LayoutKind.Sequential)]
	public struct EAP_METHOD_TYPE
	{
		/// <summary>EAP_TYPE structure that contains the ID for the EAP method as well as specific vendor information.</summary>
		public EAP_TYPE eapType;

		/// <summary>The numeric ID for the author of the EAP method.</summary>
		public uint dwAuthorId;
	}

	/// <summary>The <c>EAP_TYPE</c> structure contains type and vendor identification information for an EAP method.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/eaptypes/ns-eaptypes-eap_type typedef struct _EAP_TYPE { BYTE type; DWORD
	// dwVendorId; DWORD dwVendorType; } EAP_TYPE;
	[PInvokeData("eaptypes.h", MSDNShortId = "383f1e11-2e40-45e6-8c55-a23d1b8eb71f")]
	[StructLayout(LayoutKind.Sequential)]
	public struct EAP_TYPE
	{
		/// <summary>
		/// <para>The numeric type code for this EAP method.</para>
		/// <para><c>Note</c> For more information on the allocation of EAP method types, see section 6.2 of RFC 3748.</para>
		/// </summary>
		public byte type;

		/// <summary>The vendor ID for the EAP method.</summary>
		public uint dwVendorId;

		/// <summary>The numeric type code for the vendor of this EAP method.</summary>
		public uint dwVendorType;
	}

	/// <summary>
	/// The <c>NDIS_OBJECT_HEADER</c> structure packages the object type, version, and size information that is required in many NDIS
	/// 6.0 structures.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/nativewifi/ndis-object-header typedef struct _NDIS_OBJECT_HEADER { UCHAR Type;
	// UCHAR Revision; USHORT Size; } NDIS_OBJECT_HEADER, *PNDIS_OBJECT_HEADER;
	[PInvokeData("Ntddndis.h", MSDNShortId = "0dfb6022-1d8d-4bd9-bde3-2ee6d683f223")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NDIS_OBJECT_HEADER
	{
		/// <summary>Specifies the type of NDIS object that a structure describes.</summary>
		public byte Type;

		/// <summary>Specifies the revision number of this structure.</summary>
		public byte Revision;

		/// <summary>
		/// Specifies the total size, in bytes, of the NDIS structure that contains the <c>NDIS_OBJECT_HEADER</c>. This size includes
		/// the size of the <c>NDIS_OBJECT_HEADER</c> member and all other members of the structure.
		/// </summary>
		public ushort Size;
	}

	/// <summary>The <c>WLAN_ASSOCIATION_ATTRIBUTES</c> structure contains association attributes for a connection.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_association_attributes typedef struct
	// _WLAN_ASSOCIATION_ATTRIBUTES { DOT11_SSID dot11Ssid; DOT11_BSS_TYPE dot11BssType; DOT11_MAC_ADDRESS dot11Bssid; DOT11_PHY_TYPE
	// dot11PhyType; ULONG uDot11PhyIndex; WLAN_SIGNAL_QUALITY wlanSignalQuality; ULONG ulRxRate; ULONG ulTxRate; }
	// WLAN_ASSOCIATION_ATTRIBUTES, *PWLAN_ASSOCIATION_ATTRIBUTES;
	[PInvokeData("wlanapi.h", MSDNShortId = "f7d3d106-54a9-4bdf-bccf-216cac938995")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_ASSOCIATION_ATTRIBUTES
	{
		/// <summary>A DOT11_SSID structure that contains the SSID of the association.</summary>
		public DOT11_SSID dot11Ssid;

		/// <summary>A DOT11_BSS_TYPE value that specifies whether the network is infrastructure or ad hoc.</summary>
		public DOT11_BSS_TYPE dot11BssType;

		/// <summary>A DOT11_MAC_ADDRESS that contains the BSSID of the association.</summary>
		public DOT11_MAC_ADDRESS dot11Bssid;

		/// <summary>A DOT11_PHY_TYPE value that indicates the physical type of the association.</summary>
		public DOT11_PHY_TYPE dot11PhyType;

		/// <summary>The position of the DOT11_PHY_TYPE value in the structure containing the list of PHY types.</summary>
		public uint uDot11PhyIndex;

		/// <summary>
		/// A percentage value that represents the signal quality of the network. <c>WLAN_SIGNAL_QUALITY</c> is of type <c>ULONG</c>.
		/// This member contains a value between 0 and 100. A value of 0 implies an actual RSSI signal strength of -100 dbm. A value of
		/// 100 implies an actual RSSI signal strength of -50 dbm. You can calculate the RSSI signal strength value for
		/// <c>wlanSignalQuality</c> values between 1 and 99 using linear interpolation.
		/// </summary>
		public uint wlanSignalQuality;

		/// <summary>Contains the receiving rate of the association.</summary>
		public uint ulRxRate;

		/// <summary>Contains the transmission rate of the association.</summary>
		public uint ulTxRate;
	}

	/// <summary>The <c>WLAN_AUTH_CIPHER_PAIR_LIST</c> structure contains a list of authentication and cipher algorithm pairs.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_auth_cipher_pair_list typedef struct
	// _WLAN_AUTH_CIPHER_PAIR_LIST { DWORD dwNumberOfItems; #if ... DOT11_AUTH_CIPHER_PAIR *pAuthCipherPairList[]; #else
	// DOT11_AUTH_CIPHER_PAIR pAuthCipherPairList[1]; #endif } WLAN_AUTH_CIPHER_PAIR_LIST, *PWLAN_AUTH_CIPHER_PAIR_LIST;
	[PInvokeData("wlanapi.h", MSDNShortId = "747ee8e6-aafa-42ec-9183-a5a4a2603fc0")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<WLAN_AUTH_CIPHER_PAIR_LIST>), nameof(dwNumberOfItems))]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_AUTH_CIPHER_PAIR_LIST
	{
		/// <summary>Contains the number of supported auth-cipher pairs.</summary>
		public uint dwNumberOfItems;

		/// <summary>A DOT11_AUTH_CIPHER_PAIR structure containing a list of auth-cipher pairs.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public DOT11_AUTH_CIPHER_PAIR[] pAuthCipherPairList;
	}

	/// <summary>The <c>WLAN_AVAILABLE_NETWORK</c> structure contains information about an available wireless network.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_available_network typedef struct
	// _WLAN_AVAILABLE_NETWORK { WCHAR strProfileName[WLAN_MAX_NAME_LENGTH]; DOT11_SSID dot11Ssid; DOT11_BSS_TYPE dot11BssType; ULONG
	// uNumberOfBssids; BOOL bNetworkConnectable; WLAN_REASON_CODE wlanNotConnectableReason; ULONG uNumberOfPhyTypes; DOT11_PHY_TYPE
	// dot11PhyTypes[WLAN_MAX_PHY_TYPE_NUMBER]; BOOL bMorePhyTypes; WLAN_SIGNAL_QUALITY wlanSignalQuality; BOOL bSecurityEnabled;
	// DOT11_AUTH_ALGORITHM dot11DefaultAuthAlgorithm; DOT11_CIPHER_ALGORITHM dot11DefaultCipherAlgorithm; DWORD dwFlags; DWORD
	// dwReserved; } WLAN_AVAILABLE_NETWORK, *PWLAN_AVAILABLE_NETWORK;
	[PInvokeData("wlanapi.h", MSDNShortId = "82883cea-515b-426d-9961-c144ce99b3db")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WLAN_AVAILABLE_NETWORK
	{
		/// <summary>
		/// Contains the profile name associated with the network. If the network does not have a profile, this member will be empty. If
		/// multiple profiles are associated with the network, there will be multiple entries with the same SSID in the visible network
		/// list. Profile names are case-sensitive. This string must be NULL-terminated.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = WLAN_MAX_NAME_LENGTH)]
		public string strProfileName;

		/// <summary>A DOT11_SSID structure that contains the SSID of the visible wireless network.</summary>
		public DOT11_SSID dot11Ssid;

		/// <summary>A DOT11_BSS_TYPE value that specifies whether the network is infrastructure or ad hoc.</summary>
		public DOT11_BSS_TYPE dot11BssType;

		/// <summary>
		/// <para>Indicates the number of BSSIDs in the network.</para>
		/// <para>
		/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c><c>uNumberofBssids</c> is at most 1, regardless of
		/// the number of access points broadcasting the SSID.
		/// </para>
		/// </summary>
		public uint uNumberOfBssids;

		/// <summary>
		/// Indicates whether the network is connectable or not. If set to <c>TRUE</c>, the network is connectable, otherwise the
		/// network cannot be connected to.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool bNetworkConnectable;

		/// <summary>
		/// A WLAN_REASON_CODE value that indicates why a network cannot be connected to. This member is only valid when
		/// <c>bNetworkConnectable</c> is <c>FALSE</c>.
		/// </summary>
		public WLAN_REASON_CODE wlanNotConnectableReason;

		/// <summary>
		/// The number of PHY types supported on available networks. The maximum value of uNumberOfPhyTypes is
		/// <c>WLAN_MAX_PHY_TYPE_NUMBER</c>, which has a value of 8. If more than <c>WLAN_MAX_PHY_TYPE_NUMBER</c> PHY types are
		/// supported, bMorePhyTypes must be set to <c>TRUE</c>.
		/// </summary>
		public uint uNumberOfPhyTypes;

		/// <summary>
		/// <para>
		/// Contains an array of DOT11_PHY_TYPE values that represent the PHY types supported by the available networks. When
		/// uNumberOfPhyTypes is greater than <c>WLAN_MAX_PHY_TYPE_NUMBER</c>, this array contains only the first
		/// <c>WLAN_MAX_PHY_TYPE_NUMBER</c> PHY types.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>dot11_phy_type_unknown</term>
		/// <term>Specifies an unknown or uninitialized PHY type.</term>
		/// </item>
		/// <item>
		/// <term>dot11_phy_type_any</term>
		/// <term>Specifies any PHY type.</term>
		/// </item>
		/// <item>
		/// <term>dot11_phy_type_fhss</term>
		/// <term>Specifies a frequency-hopping spread-spectrum (FHSS) PHY. Bluetooth devices can use FHSS or an adaptation of FHSS.</term>
		/// </item>
		/// <item>
		/// <term>dot11_phy_type_dsss</term>
		/// <term>Specifies a direct sequence spread spectrum (DSSS) PHY.</term>
		/// </item>
		/// <item>
		/// <term>dot11_phy_type_irbaseband</term>
		/// <term>Specifies an infrared (IR) baseband PHY.</term>
		/// </item>
		/// <item>
		/// <term>dot11_phy_type_ofdm</term>
		/// <term>Specifies an orthogonal frequency division multiplexing (OFDM) PHY. 802.11a devices can use OFDM.</term>
		/// </item>
		/// <item>
		/// <term>dot11_phy_type_hrdsss</term>
		/// <term>Specifies a high-rate DSSS (HRDSSS) PHY.</term>
		/// </item>
		/// <item>
		/// <term>dot11_phy_type_erp</term>
		/// <term>Specifies an extended rate PHY (ERP). 802.11g devices can use ERP.</term>
		/// </item>
		/// <item>
		/// <term>dot11_phy_type_ht</term>
		/// <term>Specifies an 802.11n PHY type.</term>
		/// </item>
		/// <item>
		/// <term>dot11_phy_type_vht</term>
		/// <term>
		/// Specifies the 802.11ac PHY type. This is the very high throughput PHY type specified in IEEE 802.11ac. This value is
		/// supported on Windows 8.1, Windows Server 2012 R2, and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>dot11_phy_type_IHV_start</term>
		/// <term>
		/// Specifies the start of the range that is used to define PHY types that are developed by an independent hardware vendor (IHV).
		/// </term>
		/// </item>
		/// <item>
		/// <term>dot11_phy_type_IHV_end</term>
		/// <term>
		/// Specifies the end of the range that is used to define PHY types that are developed by an independent hardware vendor (IHV).
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = WLAN_MAX_PHY_TYPE_NUMBER)]
		public DOT11_PHY_TYPE[] dot11PhyTypes;

		/// <summary>
		/// <para>Specifies if there are more than <c>WLAN_MAX_PHY_TYPE_NUMBER</c> PHY types supported.</para>
		/// <para>
		/// When this member is set to <c>TRUE</c>, an application must call WlanGetNetworkBssList to get the complete list of PHY
		/// types. The returned WLAN_BSS_LIST structure has an array of WLAN_BSS_ENTRY structures. The uPhyId member of the
		/// <c>WLAN_BSS_ENTRY</c> structure contains the PHY type for an entry.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool bMorePhyTypes;

		/// <summary>
		/// A percentage value that represents the signal quality of the network. <c>WLAN_SIGNAL_QUALITY</c> is of type <c>ULONG</c>.
		/// This member contains a value between 0 and 100. A value of 0 implies an actual RSSI signal strength of -100 dbm. A value of
		/// 100 implies an actual RSSI signal strength of -50 dbm. You can calculate the RSSI signal strength value for
		/// <c>wlanSignalQuality</c> values between 1 and 99 using linear interpolation.
		/// </summary>
		public uint wlanSignalQuality;

		/// <summary>
		/// Indicates whether security is enabled on the network. A value of <c>TRUE</c> indicates that security is enabled, otherwise
		/// it is not.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool bSecurityEnabled;

		/// <summary>
		/// A DOT11_AUTH_ALGORITHM value that indicates the default authentication algorithm used to join this network for the first time.
		/// </summary>
		public DOT11_AUTH_ALGORITHM dot11DefaultAuthAlgorithm;

		/// <summary>A DOT11_CIPHER_ALGORITHM value that indicates the default cipher algorithm to be used when joining this network.</summary>
		public DOT11_CIPHER_ALGORITHM dot11DefaultCipherAlgorithm;

		/// <summary>
		/// <para>Contains various flags for the network.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WLAN_AVAILABLE_NETWORK_CONNECTED</term>
		/// <term>This network is currently connected.</term>
		/// </item>
		/// <item>
		/// <term>WLAN_AVAILABLE_NETWORK_HAS_PROFILE</term>
		/// <term>There is a profile for this network.</term>
		/// </item>
		/// </list>
		/// </summary>
		public WLAN_AVAILABLE_NETWORK_FLAGS dwFlags;

		/// <summary>Reserved for future use. Must be set to <c>NULL</c>.</summary>
		public uint dwReserved;
	}

	/// <summary>The <c>WLAN_BSS_ENTRY</c> structure contains information about a basic service set (BSS).</summary>
	/// <remarks>
	/// <para>
	/// The WlanGetNetworkBssList function retrieves the BSS list of the wireless network or networks on a given interface and returns
	/// this information in a WLAN_BSS_LIST structure that contains an array of . <c>WLAN_BSS_ENTRY</c> structures.
	/// </para>
	/// <para>
	/// When the wireless LAN interface is also operating as a Wireless Hosted Network , the BSS list will contain an entry for the BSS
	/// created for the Wireless Hosted Network.
	/// </para>
	/// <para>
	/// Since the information is returned by the access point for an infrastructure BSS network or by the network peer for an
	/// independent BSS network (ad hoc network), the information returned should not be trusted. The <c>ulIeOffset</c> and
	/// <c>ulIeSize</c> members in the <c>WLAN_BSS_ENTRY</c> structure should be used to determine the maximum size of the information
	/// element data blob in the <c>WLAN_BSS_ENTRY</c> structure, not the data in the information element data blob.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_bss_entry typedef struct _WLAN_BSS_ENTRY { DOT11_SSID
	// dot11Ssid; ULONG uPhyId; DOT11_MAC_ADDRESS dot11Bssid; DOT11_BSS_TYPE dot11BssType; DOT11_PHY_TYPE dot11BssPhyType; LONG lRssi;
	// ULONG uLinkQuality; BOOLEAN bInRegDomain; USHORT usBeaconPeriod; ULONGLONG ullTimestamp; ULONGLONG ullHostTimestamp; USHORT
	// usCapabilityInformation; ULONG ulChCenterFrequency; WLAN_RATE_SET wlanRateSet; ULONG ulIeOffset; ULONG ulIeSize; }
	// WLAN_BSS_ENTRY, *PWLAN_BSS_ENTRY;
	[PInvokeData("wlanapi.h", MSDNShortId = "25a76128-13d9-47dd-9c73-1fbf06a908be")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_BSS_ENTRY
	{
		/// <summary>
		/// The SSID of the access point (AP) or peer station associated with the BSS. The data type for this member is a DOT11_SSID structure.
		/// </summary>
		public DOT11_SSID dot11Ssid;

		/// <summary>The identifier (ID) of the PHY that the wireless LAN interface used to detect the BSS network.</summary>
		public uint uPhyId;

		/// <summary>
		/// The media access control (MAC) address of the access point for infrastructure BSS networks or the peer station for
		/// independent BSS networks (ad hoc networks) that sent the 802.11 Beacon or Probe Response frame received by the wireless LAN
		/// interface while scanning. The data type for this member is a DOT11_MAC_ADDRESS structure.
		/// </summary>
		public DOT11_MAC_ADDRESS dot11Bssid;

		/// <summary>
		/// <para>The BSS network type. The data type for this member is a DOT11_BSS_TYPE enumeration value.</para>
		/// <para>This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>dot11_BSS_type_infrastructure 1</term>
		/// <term>Specifies an infrastructure BSS network.</term>
		/// </item>
		/// <item>
		/// <term>dot11_BSS_type_independent 2</term>
		/// <term>Specifies an independent BSS (IBSS) network (an ad hoc network).</term>
		/// </item>
		/// </list>
		/// </summary>
		public DOT11_BSS_TYPE dot11BssType;

		/// <summary>The PHY type for this network. The data type for this member is a DOT11_PHY_TYPE enumeration value.</summary>
		public DOT11_PHY_TYPE dot11BssPhyType;

		/// <summary>
		/// The received signal strength indicator (RSSI) value, in units of decibels referenced to 1.0 milliwatts (dBm), as detected by
		/// the wireless LAN interface driver for the AP or peer station.
		/// </summary>
		public int lRssi;

		/// <summary>
		/// The link quality reported by the wireless LAN interface driver. The link quality value ranges from 0 through 100. A value of
		/// 100 specifies the highest link quality.
		/// </summary>
		public uint uLinkQuality;

		/// <summary>
		/// <para>
		/// A value that specifies whether the AP or peer station is operating within the regulatory domain as identified by the country/region.
		/// </para>
		/// <para>If the wireless LAN interface driver does not support multiple regulatory domains, this member is set to <c>TRUE</c>.</para>
		/// <para>
		/// If the 802.11 Beacon or Probe Response frame received from the AP or peer station does not include a Country information
		/// element (IE), this member is set to <c>TRUE</c>.
		/// </para>
		/// <para>
		/// If the 802.11 Beacon or Probe Response frame received from the AP or peer station does include a Country IE, this member is
		/// set to <c>FALSE</c> if the value of the Country String subfield does not equal the input country string.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.U1)] public bool bInRegDomain;

		/// <summary>
		/// <para>
		/// The value of the Beacon Interval field from the 802.11 Beacon or Probe Response frame received by the wireless LAN interface.
		/// </para>
		/// <para>
		/// The interval is in 1,024 microsecond time units between target beacon transmission times. This information is retrieved from
		/// the beacon packet sent by an access point in an infrastructure BSS network or a probe response from an access point or peer
		/// station in response to a wireless LAN client sending a Probe Request.
		/// </para>
		/// <para>
		/// The IEEE 802.11 standard defines a unit of time as equal to 1,024 microseconds. This unit was defined so that it could be
		/// easily implemented in hardware.
		/// </para>
		/// </summary>
		public ushort usBeaconPeriod;

		/// <summary>
		/// The value of the Timestamp field from the 802.11 Beacon or Probe Response frame received by the wireless LAN interface.
		/// </summary>
		public ulong ullTimestamp;

		/// <summary>
		/// <para>
		/// The host timestamp value that records when wireless LAN interface received the Beacon or Probe Response frame. This member
		/// is a count of 100-nanosecond intervals since January 1, 1601.
		/// </para>
		/// <para>For more information, see the <c>NdisGetCurrentSystemTime</c> function documented in the WDK.</para>
		/// </summary>
		public ulong ullHostTimestamp;

		/// <summary>
		/// <para>
		/// The value of the Capability Information field from the 802.11 Beacon or Probe Response frame received by the wireless LAN
		/// interface. This value is a set of bit flags defining the capability.
		/// </para>
		/// <para>This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ESS bit 0</term>
		/// <term>
		/// An extended service set. A set of one or more interconnected basic service sets (BSSs) and integrated local area networks
		/// (LANs) that appears as a single BSS to the logical link control layer at any station associated with one of those BSSs. An
		/// AP set the ESS subfield to 1 and the IBSS subfield to 0 within transmitted Beacon or Probe Response frames. A peer station
		/// within an IBSS (ad hoc network) sets the ESS subfield to 0 and the IBSS subfield to 1 in transmitted Beacon or Probe
		/// Response frames.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IBSS bit 1</term>
		/// <term>
		/// An independent basic service set. A BSS that forms a self-contained network, and in which no access to a distribution system
		/// (DS) is available (an ad hoc network). An AP sets the ESS subfield to 1 and the IBSS subfield to 0 within transmitted Beacon
		/// or Probe Response frames. A peer station within an IBSS (ad hoc network) sets the ESS subfield to 0 and the IBSS subfield to
		/// 1 in transmitted Beacon or Probe Response frames.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF-Pollable bit 2</term>
		/// <term>A value that indicates if the AP or peer station is pollable.</term>
		/// </item>
		/// <item>
		/// <term>CF Poll Request bit 3</term>
		/// <term>A value that indicates how the AP or peer station handles poll requests.</term>
		/// </item>
		/// <item>
		/// <term>Privacy bit 4</term>
		/// <term>
		/// A value that indicates if encryption is required for all data frames. An AP sets the Privacy subfield to 1 within
		/// transmitted Beacon and Probe Response frames if WEP, WPA, or WPA2 encryption is required for all data type frames exchanged
		/// within the BSS. If WEP, WPA, or WPA2 encryption is not required, the Privacy subfield is set to 0. A peer station within and
		/// IBSS sets the Privacy subfield to 1 within transmitted Beacon and Probe Response frames if WEP, WPA, or WPA2 encryption is
		/// required for all data type frames exchanged within the IBSS. If WEP, WPA, or WPA2 encryption is not required, the Privacy
		/// subfield is set to 0.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ushort usCapabilityInformation;

		/// <summary>
		/// <para>
		/// The channel center frequency of the band on which the 802.11 Beacon or Probe Response frame was received. The value of
		/// <c>ulChCenterFrequency</c> is in units of kilohertz (kHz).
		/// </para>
		/// <para><c>Note</c> This member is only valid for PHY types that are not frequency-hopping spread spectrum (FHSS).</para>
		/// </summary>
		public uint ulChCenterFrequency;

		/// <summary>A set of data transfer rates supported by the BSS. The data type for this member is a WLAN_RATE_SET structure.</summary>
		public WLAN_RATE_SET wlanRateSet;

		/// <summary>
		/// <para>The offset, in bytes, of the information element (IE) data blob from the beginning of the <c>WLAN_BSS_ENTRY</c> structure.</para>
		/// <para>
		/// This member points to a buffer that contains variable-length information elements (IEs) from the 802.11 Beacon or Probe
		/// Response frames. For each BSS, the IEs are from the last Beacon or Probe Response frame received from that BSS network. If
		/// an IE is available in only one frame, the wireless LAN interface driver merges the IE with the other IEs from the last
		/// received Beacon or Probe Response frame.
		/// </para>
		/// <para>
		/// Information elements are defined in the IEEE 802.11 specifications to have a common general format consisting of a 1-byte
		/// Element ID field, a 1-byte Length field, and a variable-length element-specific information field. Each information element
		/// is assigned a unique Element ID value as defined in this IEEE 802.11 standards. The Length field specifies the number of
		/// bytes in the information field.
		/// </para>
		/// </summary>
		public uint ulIeOffset;

		/// <summary>
		/// <para>The size, in bytes, of the IE data blob in the <c>WLAN_BSS_ENTRY</c> structure.</para>
		/// <para>
		/// This is the exact length of the data in the buffer pointed to by <c>ulIeOffset</c> member and does not contain any padding
		/// for alignment. The maximum value for the size of the IE data blob is 2,324 bytes.
		/// </para>
		/// </summary>
		public uint ulIeSize;
	}

	/// <summary>The <c>WLAN_CONNECTION_ATTRIBUTES</c> structure defines the attributes of a wireless connection.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_connection_attributes typedef struct
	// _WLAN_CONNECTION_ATTRIBUTES { WLAN_INTERFACE_STATE isState; WLAN_CONNECTION_MODE wlanConnectionMode; WCHAR
	// strProfileName[WLAN_MAX_NAME_LENGTH]; WLAN_ASSOCIATION_ATTRIBUTES wlanAssociationAttributes; WLAN_SECURITY_ATTRIBUTES
	// wlanSecurityAttributes; } WLAN_CONNECTION_ATTRIBUTES, *PWLAN_CONNECTION_ATTRIBUTES;
	[PInvokeData("wlanapi.h", MSDNShortId = "91b8058d-faf6-46ee-a03b-f762e9cdae4d")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WLAN_CONNECTION_ATTRIBUTES
	{
		/// <summary>
		/// <para>A WLAN_INTERFACE_STATE value that indicates the state of the interface.</para>
		/// <para>
		/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> Only the <c>wlan_interface_state_connected</c>,
		/// <c>wlan_interface_state_disconnected</c>, and <c>wlan_interface_state_authenticating</c> values are supported.
		/// </para>
		/// </summary>
		public WLAN_INTERFACE_STATE isState;

		/// <summary>
		/// <para>A WLAN_CONNECTION_MODE value that indicates the mode of the connection.</para>
		/// <para>
		/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> Only the <c>wlan_connection_mode_profile</c> value
		/// is supported.
		/// </para>
		/// </summary>
		public WLAN_CONNECTION_MODE wlanConnectionMode;

		/// <summary>The name of the profile used for the connection. Profile names are case-sensitive. This string must be NULL-terminated.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = WLAN_MAX_NAME_LENGTH)]
		public string strProfileName;

		/// <summary>A WLAN_ASSOCIATION_ATTRIBUTES structure that contains the attributes of the association.</summary>
		public WLAN_ASSOCIATION_ATTRIBUTES wlanAssociationAttributes;

		/// <summary>A WLAN_SECURITY_ATTRIBUTES structure that contains the security attributes of the connection.</summary>
		public WLAN_SECURITY_ATTRIBUTES wlanSecurityAttributes;
	}

	/// <summary>The <c>WLAN_CONNECTION_NOTIFICATION_DATA</c> structure contains information about connection related notifications.</summary>
	/// <remarks>
	/// <para>
	/// The WlanRegisterNotification function is used by an application to register and unregister notifications on all wireless
	/// interfaces. When registering for notifications, an application must provide a callback function pointed to by the funcCallback
	/// parameter passed to the <c>WlanRegisterNotification</c> function. The prototype for this callback function is the
	/// WLAN_NOTIFICATION_CALLBACK. This callback function will receive notifications that have been registered in the dwNotifSource
	/// parameter passed to the <c>WlanRegisterNotification</c> function.
	/// </para>
	/// <para>
	/// The callback function is called with a pointer to a WLAN_NOTIFICATION_DATA structure as the first parameter that contains
	/// detailed information on the notification.
	/// </para>
	/// <para>
	/// If the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure received by the callback function is
	/// <c>WLAN_NOTIFICATION_SOURCE_ACM</c>, then the received notification is an auto configuration module notification. The
	/// <c>NotificationCode</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure passed to the WLAN_NOTIFICATION_CALLBACK function
	/// determines the interpretation of the pData member of <c>WLAN_NOTIFICATION_DATA</c> structure. For some of these notifications, a
	/// <c>WLAN_CONNECTION_NOTIFICATION_DATA</c> structure is returned in the pData member of <c>WLAN_NOTIFICATION_DATA</c> structure.
	/// </para>
	/// <para>For more information on these notifications, see the WLAN_NOTIFICATION_ACM enumeration reference.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_connection_notification_data typedef struct
	// _WLAN_CONNECTION_NOTIFICATION_DATA { WLAN_CONNECTION_MODE wlanConnectionMode; WCHAR strProfileName[WLAN_MAX_NAME_LENGTH];
	// DOT11_SSID dot11Ssid; DOT11_BSS_TYPE dot11BssType; BOOL bSecurityEnabled; WLAN_REASON_CODE wlanReasonCode; DWORD dwFlags; WCHAR
	// strProfileXml[1]; } WLAN_CONNECTION_NOTIFICATION_DATA, *PWLAN_CONNECTION_NOTIFICATION_DATA;
	[PInvokeData("wlanapi.h", MSDNShortId = "005af5ef-994d-425a-be4b-54567a733fb3")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WLAN_CONNECTION_NOTIFICATION_DATA
	{
		/// <summary>
		/// <para>A WLAN_CONNECTION_MODE value that specifies the mode of the connection.</para>
		/// <para>
		/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> Only the <c>wlan_connection_mode_profile</c> value
		/// is supported.
		/// </para>
		/// </summary>
		public WLAN_CONNECTION_MODE wlanConnectionMode;

		/// <summary>
		/// The name of the profile used for the connection. WLAN_MAX_NAME_LENGTH is 256. Profile names are case-sensitive. This string
		/// must be NULL-terminated.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = WLAN_MAX_NAME_LENGTH)]
		public string strProfileName;

		/// <summary>A DOT11_SSID structure that contains the SSID of the association.</summary>
		public DOT11_SSID dot11Ssid;

		/// <summary>A DOT11_BSS_TYPE value that indicates the BSS network type.</summary>
		public DOT11_BSS_TYPE dot11BssType;

		/// <summary>Indicates whether security is enabled for this connection. If <c>TRUE</c>, security is enabled.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool bSecurityEnabled;

		/// <summary>
		/// A WLAN_REASON_CODE that indicates the reason for an operation failure. This field has a value of
		/// <c>WLAN_REASON_CODE_SUCCESS</c> for all connection-related notifications except
		/// <c>wlan_notification_acm_connection_complete</c>. If the connection fails, this field indicates the reason for the failure.
		/// </summary>
		public WLAN_REASON_CODE wlanReasonCode;

		/// <summary>
		/// <para>A set of flags that provide additional information for the network connection.</para>
		/// <para>This member can be one of the following values defined in the Wlanapi.h header file.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WLAN_CONNECTION_NOTIFICATION_ADHOC_NETWORK_FORMED</term>
		/// <term>Indicates that an adhoc network is formed.</term>
		/// </item>
		/// <item>
		/// <term>WLAN_CONNECTION_NOTIFICATION_CONSOLE_USER_PROFILE</term>
		/// <term>
		/// Indicates that the connection uses a per-user profile owned by the console user. Non-console users will not be able to see
		/// the profile in their profile list.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public WLAN_CONNECTION_NOTIFICATION dwFlags;

		/// <summary>This field contains the XML presentation of the profile used for discovery, if the connection succeeds.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public string strProfileXml;
	}

	/// <summary>The <c>WLAN_CONNECTION_PARAMETERS</c> structure specifies the parameters used when using the WlanConnect function.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_connection_parameters typedef struct
	// _WLAN_CONNECTION_PARAMETERS { WLAN_CONNECTION_MODE wlanConnectionMode; #if ... LPCWSTR strProfile; #else LPCWSTR strProfile;
	// #endif PDOT11_SSID pDot11Ssid; PDOT11_BSSID_LIST pDesiredBssidList; DOT11_BSS_TYPE dot11BssType; DWORD dwFlags; }
	// WLAN_CONNECTION_PARAMETERS, *PWLAN_CONNECTION_PARAMETERS;
	[PInvokeData("wlanapi.h", MSDNShortId = "e0321447-b89a-4f4e-929e-eb6db76f7283")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_CONNECTION_PARAMETERS
	{
		/// <summary>
		/// <para>A WLAN_CONNECTION_MODE value that specifies the mode of connection.</para>
		/// <para>
		/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> Only the <c>wlan_connection_mode_profile</c> value
		/// is supported.
		/// </para>
		/// </summary>
		public WLAN_CONNECTION_MODE wlanConnectionMode;

		/// <summary>
		/// <para>Specifies the profile being used for the connection.</para>
		/// <para>
		/// If <c>wlanConnectionMode</c> is set to <c>wlan_connection_mode_profile</c>, then <c>strProfile</c> specifies the name of the
		/// profile used for the connection. If <c>wlanConnectionMode</c> is set to <c>wlan_connection_mode_temporary_profile</c>, then
		/// <c>strProfile</c> specifies the XML representation of the profile used for the connection. If <c>wlanConnectionMode</c> is
		/// set to <c>wlan_connection_mode_discovery_secure</c> or <c>wlan_connection_mode_discovery_unsecure</c>, then
		/// <c>strProfile</c> should be set to <c>NULL</c>.
		/// </para>
		/// <para>
		/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> The profile must meet the compatibility criteria
		/// described in Wireless Profile Compatibility.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string strProfile;

		/// <summary>
		/// Pointer to a DOT11_SSID structure that specifies the SSID of the network to connect to. This parameter is optional. When set
		/// to <c>NULL</c>, all SSIDs in the profile will be tried. This parameter must not be <c>NULL</c> if WLAN_CONNECTION_MODE is
		/// set to <c>wlan_connection_mode_discovery_secure</c> or <c>wlan_connection_mode_discovery_unsecure</c>.
		/// </summary>
		public IntPtr pDot11Ssid;

		/// <summary>
		/// <para>
		/// Pointer to a DOT11_BSSID_LIST structure that contains the list of basic service set (BSS) identifiers desired for the connection.
		/// </para>
		/// <para><c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> This member must be <c>NULL</c>.</para>
		/// </summary>
		public IntPtr pDesiredBssidList;

		/// <summary>
		/// A DOT11_BSS_TYPE value that indicates the BSS type of the network. If a profile is provided, this BSS type must be the same
		/// as the one in the profile.
		/// </summary>
		public DOT11_BSS_TYPE dot11BssType;

		/// <summary>
		/// <para>The following table shows flags used to specify the connection parameters.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Constant</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WLAN_CONNECTION_HIDDEN_NETWORK</term>
		/// <term>0x00000001</term>
		/// <term>
		/// Connect to the destination network even if the destination is a hidden network. A hidden network does not broadcast its
		/// SSID. Do not use this flag if the destination network is an ad-hoc network.If the profile specified by strProfile is not
		/// NULL, then this flag is ignored and the nonBroadcast profile element determines whether to connect to a hidden network.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WLAN_CONNECTION_ADHOC_JOIN_ONLY</term>
		/// <term>0x00000002</term>
		/// <term>
		/// Do not form an ad-hoc network. Only join an ad-hoc network if the network already exists. Do not use this flag if the
		/// destination network is an infrastructure network.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WLAN_CONNECTION_IGNORE_PRIVACY_BIT</term>
		/// <term>0x00000004</term>
		/// <term>
		/// Ignore the privacy bit when connecting to the network. Ignoring the privacy bit has the effect of ignoring whether packets
		/// are encrypted and ignoring the method of encryption used. Only use this flag when connecting to an infrastructure network
		/// using a temporary profile.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WLAN_CONNECTION_EAPOL_PASSTHROUGH</term>
		/// <term>0x00000008</term>
		/// <term>
		/// Exempt EAPOL traffic from encryption and decryption. This flag is used when an application must send EAPOL traffic over an
		/// infrastructure network that uses Open authentication and WEP encryption. This flag must not be used to connect to networks
		/// that require 802.1X authentication. This flag is only valid when wlanConnectionMode is set to
		/// wlan_connection_mode_temporary_profile. Avoid using this flag whenever possible.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WLAN_CONNECTION_PERSIST_DISCOVERY_PROFILE</term>
		/// <term>0x00000010</term>
		/// <term>
		/// Automatically persist discovery profile on successful connection completion. This flag is only valid for
		/// wlan_connection_mode_discovery_secure or wlan_connection_mode_discovery_unsecure. The profile will be saved as an all user
		/// profile, with the name generated from the SSID using WlanUtf8SsidToDisplayName. If there is already a profile with the same
		/// name, a number will be appended to the end of the profile name. The profile will be saved with manual connection mode,
		/// unless WLAN_CONNECTION_PERSIST_DISCOVERY_PROFILE_CONNECTION_MODE_AUTO is also specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WLAN_CONNECTION_PERSIST_DISCOVERY_PROFILE_CONNECTION_MODE_AUTO</term>
		/// <term>0x00000020</term>
		/// <term>
		/// To be used in conjunction with WLAN_CONNECTION_PERSIST_DISCOVERY_PROFILE. The discovery profile will be persisted with
		/// automatic connection mode.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WLAN_CONNECTION_PERSIST_DISCOVERY_PROFILE_OVERWRITE_EXISTING</term>
		/// <term>0x00000040</term>
		/// <term>
		/// To be used in conjunction with WLAN_CONNECTION_PERSIST_DISCOVERY_PROFILE. The discovery profile will be persisted and
		/// attempt to overwrite an existing profile with the same name.
		/// </term>
		/// </item>
		/// </list>
		/// <para><c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> This member must be set to 0.</para>
		/// </summary>
		public WLAN_CONNECTION_FLAGS dwFlags;
	}

	/// <summary>A <c>WLAN_COUNTRY_OR_REGION_STRING_LIST</c> structure contains a list of supported country or region strings.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_country_or_region_string_list typedef struct
	// _WLAN_COUNTRY_OR_REGION_STRING_LIST { DWORD dwNumberOfItems; #if ... DOT11_COUNTRY_OR_REGION_STRING
	// *pCountryOrRegionStringList[]; #else DOT11_COUNTRY_OR_REGION_STRING pCountryOrRegionStringList[1]; #endif }
	// WLAN_COUNTRY_OR_REGION_STRING_LIST, *PWLAN_COUNTRY_OR_REGION_STRING_LIST;
	[PInvokeData("wlanapi.h", MSDNShortId = "64343c1f-3543-406f-a64c-94196b8aa17e")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<WLAN_COUNTRY_OR_REGION_STRING_LIST>), nameof(dwNumberOfItems))]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_COUNTRY_OR_REGION_STRING_LIST
	{
		/// <summary>Indicates the number of supported country or region strings.</summary>
		public uint dwNumberOfItems;

		/// <summary>
		/// A list of supported country or region strings. In Windows, a <c>DOT11_COUNTRY_OR_REGION_STRING</c> is of type <c>char[3]</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public DOT11_COUNTRY_OR_REGION_STRING[] pCountryOrRegionStringList;
	}

	/// <summary>A structure that represents a device service notification.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_device_service_notification_data typedef struct
	// _WLAN_DEVICE_SERVICE_NOTIFICATION_DATA { GUID DeviceService; DWORD dwOpCode; DWORD dwDataSize; #if ... BYTE *DataBlob[]; #else
	// BYTE DataBlob[1]; #endif } WLAN_DEVICE_SERVICE_NOTIFICATION_DATA, *PWLAN_DEVICE_SERVICE_NOTIFICATION_DATA;
	[PInvokeData("wlanapi.h")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<WLAN_DEVICE_SERVICE_NOTIFICATION_DATA>), nameof(dwDataSize))]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_DEVICE_SERVICE_NOTIFICATION_DATA
	{
		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>The <c>GUID</c> identifying the device service for this notification.</para>
		/// </summary>
		public Guid DeviceService;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The opcode that identifies the operation under the device service for this notification.</para>
		/// </summary>
		public uint dwOpCode;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The size, in bytes, of the DataBlob member. The maximum value of dwDataSize may be restricted by the type of data that is
		/// stored in the <c>WLAN_DEVICE_SERVICE_NOTIFICATION_DATA</c> structure.
		/// </para>
		/// </summary>
		public uint dwDataSize;

		/// <summary>
		/// <para>Type: <c>BYTE[1]</c></para>
		/// <para>
		/// A pointer to an array containing <c>BYTES</c> s, representing the data blob. This is the data that is received from the
		/// independent hardware vendor (IHV) driver, and is passed on to the client as an unformatted byte array blob.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] DataBlob;
	}

	/// <summary>
	/// The <c>WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS</c> structure contains information about the connection settings on the wireless
	/// Hosted Network.
	/// </summary>
	/// <remarks>
	/// The <c>WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS</c> structure is an extension to native wireless APIs added to support the
	/// wireless Hosted Network on Windows 7 and later.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_hosted_network_connection_settings typedef struct
	// _WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS { DOT11_SSID hostedNetworkSSID; DWORD dwMaxNumberOfPeers; }
	// WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS, *PWLAN_HOSTED_NETWORK_CONNECTION_SETTINGS;
	[PInvokeData("wlanapi.h", MSDNShortId = "845eaef2-7ce0-4d7a-8273-8b843b5c95fd")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS
	{
		/// <summary>The SSID associated with the wireless Hosted Network.</summary>
		public DOT11_SSID hostedNetworkSSID;

		/// <summary>The maximum number of concurrent peers allowed by the wireless Hosted Network.</summary>
		public uint dwMaxNumberOfPeers;
	}

	/// <summary>
	/// The <c>WLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE</c> structure contains information about a network state change for a data
	/// peer on the wireless Hosted Network.
	/// </summary>
	/// <remarks>
	/// The <c>WLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE</c> structure is an extension to native wireless APIs added to support the
	/// wireless Hosted Network on Windows 7 and later.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_hosted_network_data_peer_state_change typedef struct
	// _WLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE { WLAN_HOSTED_NETWORK_PEER_STATE OldState; WLAN_HOSTED_NETWORK_PEER_STATE NewState;
	// WLAN_HOSTED_NETWORK_REASON PeerStateChangeReason; } WLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE, *PWLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE;
	[PInvokeData("wlanapi.h", MSDNShortId = "476b903d-7c87-4734-8a42-c8b75d292fb5")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE
	{
		/// <summary>The previous network state for a data peer on the wireless Hosted Network.</summary>
		public WLAN_HOSTED_NETWORK_PEER_STATE OldState;

		/// <summary>
		/// <para>The current network state for a data peer on the wireless Hosted Network.</para>
		/// <para>The reason for the network state change for the data peer.</para>
		/// </summary>
		public WLAN_HOSTED_NETWORK_PEER_STATE NewState;

		/// <summary/>
		public WLAN_HOSTED_NETWORK_REASON PeerStateChangeReason;
	}

	/// <summary>
	/// The <c>WLAN_HOSTED_NETWORK_PEER_STATE</c> structure contains information about the peer state for a peer on the wireless Hosted Network.
	/// </summary>
	/// <remarks>
	/// The <c>WLAN_HOSTED_NETWORK_PEER_STATE</c> structure is an extension to native wireless APIs added to support the wireless Hosted
	/// Network on Windows 7 and later.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_hosted_network_peer_state typedef struct
	// _WLAN_HOSTED_NETWORK_PEER_STATE { DOT11_MAC_ADDRESS PeerMacAddress; WLAN_HOSTED_NETWORK_PEER_AUTH_STATE PeerAuthState; }
	// WLAN_HOSTED_NETWORK_PEER_STATE, *PWLAN_HOSTED_NETWORK_PEER_STATE;
	[PInvokeData("wlanapi.h", MSDNShortId = "f42f7100-45c8-4dd3-ae01-07740cace871")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_HOSTED_NETWORK_PEER_STATE
	{
		/// <summary>The MAC address of the peer being described.</summary>
		public DOT11_MAC_ADDRESS PeerMacAddress;

		/// <summary>The current authentication state of this peer.</summary>
		public WLAN_HOSTED_NETWORK_PEER_AUTH_STATE PeerAuthState;
	}

	/// <summary>
	/// The <c>WLAN_HOSTED_NETWORK_RADIO_STATE</c> structure contains information about the radio state on the wireless Hosted Network.
	/// </summary>
	/// <remarks>
	/// The <c>WLAN_HOSTED_NETWORK_RADIO_STATE</c> structure is an extension to native wireless APIs added to support the wireless
	/// Hosted Network on Windows 7 and later.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_hosted_network_radio_state typedef struct
	// _WLAN_HOSTED_NETWORK_RADIO_STATE { DOT11_RADIO_STATE dot11SoftwareRadioState; DOT11_RADIO_STATE dot11HardwareRadioState; }
	// WLAN_HOSTED_NETWORK_RADIO_STATE, *PWLAN_HOSTED_NETWORK_RADIO_STATE;
	[PInvokeData("wlanapi.h", MSDNShortId = "a84db78d-f6fd-48c4-80e8-a0d16f4dc3ed")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_HOSTED_NETWORK_RADIO_STATE
	{
		/// <summary>The software radio state of the wireless Hosted Network.</summary>
		public DOT11_RADIO_STATE dot11SoftwareRadioState;

		/// <summary>The hardware radio state of the wireless Hosted Network.</summary>
		public DOT11_RADIO_STATE dot11HardwareRadioState;
	}

	/// <summary>
	/// The <c>WLAN_HOSTED_NETWORK_SECURITY_SETTINGS</c> structure contains information about the security settings on the wireless
	/// Hosted Network.
	/// </summary>
	/// <remarks>
	/// The <c>WLAN_HOSTED_NETWORK_SECURITY_SETTINGS</c> structure is an extension to native wireless APIs added to support the wireless
	/// Hosted Network on Windows 7 and later.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_hosted_network_security_settings typedef struct
	// _WLAN_HOSTED_NETWORK_SECURITY_SETTINGS { DOT11_AUTH_ALGORITHM dot11AuthAlgo; DOT11_CIPHER_ALGORITHM dot11CipherAlgo; }
	// WLAN_HOSTED_NETWORK_SECURITY_SETTINGS, *PWLAN_HOSTED_NETWORK_SECURITY_SETTINGS;
	[PInvokeData("wlanapi.h", MSDNShortId = "b86beb10-52e5-4bc0-95fe-08307f8d1ccd")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_HOSTED_NETWORK_SECURITY_SETTINGS
	{
		/// <summary>The authentication algorithm used by the wireless Hosted Network.</summary>
		public DOT11_AUTH_ALGORITHM dot11AuthAlgo;

		/// <summary>The cipher algorithm used by the wireless Hosted Network.</summary>
		public DOT11_CIPHER_ALGORITHM dot11CipherAlgo;
	}

	/// <summary>
	/// The <c>WLAN_HOSTED_NETWORK_STATE_CHANGE</c> structure contains information about a network state change on the wireless Hosted Network.
	/// </summary>
	/// <remarks>
	/// The <c>WLAN_HOSTED_NETWORK_STATE_CHANGE</c> structure is an extension to native wireless APIs added to support the wireless
	/// Hosted Network on Windows 7 and later.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_hosted_network_state_change typedef struct
	// _WLAN_HOSTED_NETWORK_STATE_CHANGE { WLAN_HOSTED_NETWORK_STATE OldState; WLAN_HOSTED_NETWORK_STATE NewState;
	// WLAN_HOSTED_NETWORK_REASON StateChangeReason; } WLAN_HOSTED_NETWORK_STATE_CHANGE, *PWLAN_HOSTED_NETWORK_STATE_CHANGE;
	[PInvokeData("wlanapi.h", MSDNShortId = "e05607fd-da1e-49ae-b2eb-3ac4758df84c")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_HOSTED_NETWORK_STATE_CHANGE
	{
		/// <summary>The previous network state on the wireless Hosted Network.</summary>
		public WLAN_HOSTED_NETWORK_STATE OldState;

		/// <summary>The current network state on the wireless Hosted Network.</summary>
		public WLAN_HOSTED_NETWORK_STATE NewState;

		/// <summary>The reason for the network state change.</summary>
		public WLAN_HOSTED_NETWORK_REASON StateChangeReason;
	}

	/// <summary>The <c>WLAN_INTERFACE_INFO</c> structure contains information about a wireless LAN interface.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_interface_info typedef struct _WLAN_INTERFACE_INFO {
	// GUID InterfaceGuid; WCHAR strInterfaceDescription[WLAN_MAX_NAME_LENGTH]; WLAN_INTERFACE_STATE isState; } WLAN_INTERFACE_INFO, *PWLAN_INTERFACE_INFO;
	[PInvokeData("wlanapi.h", MSDNShortId = "906e7d59-ebd0-47e7-985e-f5d313f19ecb")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WLAN_INTERFACE_INFO
	{
		/// <summary>Contains the GUID of the interface.</summary>
		public Guid InterfaceGuid;

		/// <summary>Contains the description of the interface.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = WLAN_MAX_NAME_LENGTH)]
		public string strInterfaceDescription;

		/// <summary>
		/// <para>Contains a WLAN_INTERFACE_STATE value that indicates the current state of the interface.</para>
		/// <para>
		/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> Only the <c>wlan_interface_state_connected</c>,
		/// <c>wlan_interface_state_disconnected</c>, and <c>wlan_interface_state_authenticating</c> values are supported.
		/// </para>
		/// </summary>
		public WLAN_INTERFACE_STATE isState;
	}

	/// <summary>The <c>WLAN_MAC_FRAME_STATISTICS</c> structure contains information about sent and received MAC frames.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_mac_frame_statistics typedef struct
	// WLAN_MAC_FRAME_STATISTICS { ULONGLONG ullTransmittedFrameCount; ULONGLONG ullReceivedFrameCount; ULONGLONG ullWEPExcludedCount;
	// ULONGLONG ullTKIPLocalMICFailures; ULONGLONG ullTKIPReplays; ULONGLONG ullTKIPICVErrorCount; ULONGLONG ullCCMPReplays; ULONGLONG
	// ullCCMPDecryptErrors; ULONGLONG ullWEPUndecryptableCount; ULONGLONG ullWEPICVErrorCount; ULONGLONG ullDecryptSuccessCount;
	// ULONGLONG ullDecryptFailureCount; } WLAN_MAC_FRAME_STATISTICS, *PWLAN_MAC_FRAME_STATISTICS;
	[PInvokeData("wlanapi.h", MSDNShortId = "b5bb4ec9-aeec-4a64-977d-e875c3835196")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_MAC_FRAME_STATISTICS
	{
		/// <summary>Contains the number of successfully transmitted MSDU/MMPDUs.</summary>
		public ulong ullTransmittedFrameCount;

		/// <summary>Contains the number of successfully received MSDU/MMPDUs.</summary>
		public ulong ullReceivedFrameCount;

		/// <summary>Contains the number of frames discarded due to having a "Protected" status indicated in the frame control field.</summary>
		public ulong ullWEPExcludedCount;

		/// <summary>
		/// Contains the number of MIC failures encountered while checking the integrity of packets received from the AP or peer station.
		/// </summary>
		public ulong ullTKIPLocalMICFailures;

		/// <summary>Contains the number of TKIP replay errors detected.</summary>
		public ulong ullTKIPReplays;

		/// <summary>Contains the number of TKIP protected packets that the NIC failed to decrypt.</summary>
		public ulong ullTKIPICVErrorCount;

		/// <summary>Contains the number of received unicast fragments discarded by the replay mechanism.</summary>
		public ulong ullCCMPReplays;

		/// <summary>Contains the number of received fragments discarded by the CCMP decryption algorithm.</summary>
		public ulong ullCCMPDecryptErrors;

		/// <summary>Contains the number of WEP protected packets received for which a decryption key was not available on the NIC.</summary>
		public ulong ullWEPUndecryptableCount;

		/// <summary>Contains the number of WEP protected packets the NIC failed to decrypt.</summary>
		public ulong ullWEPICVErrorCount;

		/// <summary>Contains the number of encrypted packets that the NIC has successfully decrypted.</summary>
		public ulong ullDecryptSuccessCount;

		/// <summary>Contains the number of encrypted packets that the NIC has failed to decrypt.</summary>
		public ulong ullDecryptFailureCount;
	}

	/// <summary>
	/// The <c>WLAN_MSM_NOTIFICATION_DATA</c> structure contains information about media specific module (MSM) connection related notifications.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The WlanRegisterNotification function is used by an application to register and unregister notifications on all wireless
	/// interfaces. When registering for notifications, an application must provide a callback function pointed to by the funcCallback
	/// parameter passed to the <c>WlanRegisterNotification</c> function. The prototype for this callback function is the
	/// WLAN_NOTIFICATION_CALLBACK. This callback function will receive notifications that have been registered in the dwNotifSource
	/// parameter passed to the <c>WlanRegisterNotification</c> function.
	/// </para>
	/// <para>
	/// The callback function is called with a pointer to a WLAN_NOTIFICATION_DATA structure as the first parameter that contains
	/// detailed information on the notification.
	/// </para>
	/// <para>
	/// If the <c>NotificationSource</c> member of the WLAN_NOTIFICATION_DATA structure received by the callback function is
	/// <c>WLAN_NOTIFICATION_SOURCE_MSM</c>, then the received notification is a media specific module (MSM) notification. The
	/// <c>NotificationCode</c> member of the <c>WLAN_NOTIFICATION_DATA</c> structure passed to the WLAN_NOTIFICATION_CALLBACK function
	/// determines the interpretation of the pData member of <c>WLAN_NOTIFICATION_DATA</c> structure. For some of these notifications, a
	/// <c>WLAN_MSM_NOTIFICATION_DATA</c> structure is returned in the pData member of <c>WLAN_NOTIFICATION_DATA</c> structure.
	/// </para>
	/// <para>For more information on these notifications, see the WLAN_NOTIFICATION_MSM enumeration reference.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_msm_notification_data typedef struct
	// _WLAN_MSM_NOTIFICATION_DATA { WLAN_CONNECTION_MODE wlanConnectionMode; WCHAR strProfileName[WLAN_MAX_NAME_LENGTH]; DOT11_SSID
	// dot11Ssid; DOT11_BSS_TYPE dot11BssType; DOT11_MAC_ADDRESS dot11MacAddr; BOOL bSecurityEnabled; BOOL bFirstPeer; BOOL bLastPeer;
	// WLAN_REASON_CODE wlanReasonCode; } WLAN_MSM_NOTIFICATION_DATA, *PWLAN_MSM_NOTIFICATION_DATA;
	[PInvokeData("wlanapi.h", MSDNShortId = "76693a8e-7df8-45f0-a3c1-7960de27250c")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WLAN_MSM_NOTIFICATION_DATA
	{
		/// <summary>A WLAN_CONNECTION_MODE value that specifies the mode of the connection.</summary>
		public WLAN_CONNECTION_MODE wlanConnectionMode;

		/// <summary>
		/// The name of the profile used for the connection. WLAN_MAX_NAME_LENGTH is 256. Profile names are case-sensitive. This string
		/// must be NULL-terminated.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = WLAN_MAX_NAME_LENGTH)]
		public string strProfileName;

		/// <summary>A DOT11_SSID structure that contains the SSID of the association.</summary>
		public DOT11_SSID dot11Ssid;

		/// <summary>A DOT11_BSS_TYPE value that indicates the BSS network type.</summary>
		public DOT11_BSS_TYPE dot11BssType;

		/// <summary>A DOT11_MAC_ADDRESS that specifies the MAC address of the peer or access point.</summary>
		public DOT11_MAC_ADDRESS dot11MacAddr;

		/// <summary>Indicates whether security is enabled for this connection. If <c>TRUE</c>, security is enabled.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool bSecurityEnabled;

		/// <summary>
		/// <para>
		/// Indicates whether the peer is the first to join the ad hoc network created by the machine. If <c>TRUE</c>, the peer is the
		/// first to join.
		/// </para>
		/// <para>
		/// After the first peer joins the network, the interface state of the machine that created the ad hoc network changes from
		/// wlan_interface_state_ad_hoc_network_formed to wlan_interface_state_connected.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool bFirstPeer;

		/// <summary>
		/// Indicates whether the peer is the last to leave the ad hoc network created by the machine. If <c>TRUE</c>, the peer is the
		/// last to leave. After the last peer leaves the network, the interface state of the machine that created the ad hoc network
		/// changes from wlan_interface_state_connected to wlan_interface_state_ad_hoc_network_formed.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool bLastPeer;

		/// <summary>
		/// A WLAN_REASON_CODE that indicates the reason for an operation failure. If the operation succeeds, this field has a value of
		/// <c>WLAN_REASON_CODE_SUCCESS</c>. Otherwise, this field indicates the reason for the failure.
		/// </summary>
		public WLAN_REASON_CODE wlanReasonCode;
	}

	/// <summary>The WLAN_NOTIFICATION_DATA structure contains information provided when receiving notifications.</summary>
	/// <remarks>
	/// <para>
	/// The WlanRegisterNotification function is used by an application to register and unregister notifications on all wireless
	/// interfaces. When registering for notifications, an application must provide a callback function pointed to by the funcCallback
	/// parameter passed to the WlanRegisterNotification function. The prototype for this callback function is the
	/// WLAN_NOTIFICATION_CALLBACK. This callback function will receive notifications that have been registered in the dwNotifSource
	/// parameter passed to the WlanRegisterNotification function.
	/// </para>
	/// <para>
	/// The callback function is called with a pointer to a WLAN_NOTIFICATION_DATA structure as the first parameter that contains
	/// detailed information on the notification. The callback function also receives a second parameter that contains a pointer to the
	/// client context passed in the pCallbackContext parameter to the WlanRegisterNotification function. This client context can be a
	/// NULL pointer if that is what was passed to the WlanRegisterNotification function.
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
	/// <para>An application can time out and query the current interface state instead of waiting for a notification.</para>
	/// <para>
	/// If the NotificationSource member of the WLAN_NOTIFICATION_DATA structure received by the callback function is
	/// WLAN_NOTIFICATION_SOURCE_ACM, then the received notification is an auto configuration module notification. The NotificationCode
	/// member of the WLAN_NOTIFICATION_DATA structure passed to the WLAN_NOTIFICATION_CALLBACK function determines the interpretation
	/// of the pData member of WLAN_NOTIFICATION_DATA structure. For more information on these notifications, see the
	/// WLAN_NOTIFICATION_ACM enumeration reference.
	/// </para>
	/// <para>
	/// The wlan_notification_acm_connection_attempt_fail notification is used only when an application tries and fails to initiate a
	/// connection using WlanConnect. This notification is sent for each failed SSID. The wlanReasonCode member of the
	/// WLAN_CONNECTION_NOTIFICATION_DATA structure included with the notification data specifies the reason the SSID failed.
	/// </para>
	/// <para>
	/// If all SSIDs fail when a connection is initiated using WlanConnect, the notification wlan_notification_acm_connection_complete
	/// is sent with wlanReasonCode set to WLAN_REASON_CODE_NETWORK_NOT_AVAILABLE. If at least one SSID succeeds, then the notification
	/// is sent with wlanReasonCode set to WLAN_REASON_CODE_SUCCESS.
	/// </para>
	/// <para>
	/// Unlike wlan_notification_acm_connection_attempt_fail, the wlan_notification_acm_connection_complete notification is sent for
	/// automatic connections and for connections initiated using WlanConnect. If the connection succeeds, wlanReasonCode set to
	/// WLAN_REASON_CODE_SUCCESS. Otherwise, wlanReasonCode specifies the reason for failure.
	/// </para>
	/// <para>
	/// The wlan_notification_acm_filter_list_change notification is sent when there is a change in the filter list, either through
	/// group policy or a call to the WlanSetFilterList function. An application can call the WlanGetFilterList function to retrieve the
	/// new filter list.
	/// </para>
	/// <para>
	/// The wlan_notification_acm_network_not_available notification is sent if the wireless service cannot find any connectable network
	/// after a scan. The interface on which no connectable network is found is identified by the InterfaceGuid member of the
	/// WLAN_NOTIFICATION_DATA structure.
	/// </para>
	/// <para>The wlan_notification_acm_network_available notification is sent when all of the following conditions occur:</para>
	/// <para>
	/// The wireless service finds connectable networks after a scan <br/> The interface is in the disconnected state; <br/> There is no
	/// compatible auto-connect profile that the wireless service can use to connect. <br/> The interface on which connectable networks
	/// are found is identified by the InterfaceGuid member of the WLAN_NOTIFICATION_DATA structure.
	/// </para>
	/// <para>
	/// The wlan_notification_acm_profile_change notification is sent when there is a change in a profile or the profile list, either
	/// through group policy or by calls to Native Wifi functions. An application can call WlanGetProfileList and WlanGetProfile
	/// functions to retrieve the updated profiles. The interface on which the profile list changes is identified by the InterfaceGuid
	/// member of the WLAN_NOTIFICATION_DATA structure.
	/// </para>
	/// <para>
	/// The wlan_notification_acm_profiles_exhausted notification is sent if the wireless service cannot connect to any network
	/// automatically after trying all auto-connect profiles. The notification won't be sent if there is no auto-connect profile or no
	/// connectable network. The interface is identified by identified by the InterfaceGuid member of the WLAN_NOTIFICATION_DATA structure.
	/// </para>
	/// <para>
	/// If the NotificationSource member of the WLAN_NOTIFICATION_DATA structure received by the callback function is
	/// WLAN_NOTIFICATION_SOURCE_HNWK, then the received notification is a wireless Hosted Network notification supported on Windows 7
	/// and on Windows Server 2008 R2 with the Wireless LAN Service installed. The NotificationCode member of the WLAN_NOTIFICATION_DATA
	/// structure passed to the WLAN_NOTIFICATION_CALLBACK function determines the interpretation of the pData member of
	/// WLAN_NOTIFICATION_DATA structure. For more information on these notifications, see the WLAN_HOSTED_NETWORK_NOTIFICATION_CODE
	/// enumeration reference.
	/// </para>
	/// <para>
	/// If the NotificationSource member of the WLAN_NOTIFICATION_DATA structure received by the callback function is
	/// WLAN_NOTIFICATION_SOURCE_IHV, then the received notification is an indepent hardware vendor (IHV) notification. The
	/// NotificationCode member of the WLAN_NOTIFICATION_DATA structure passed to the WLAN_NOTIFICATION_CALLBACK function determines the
	/// interpretation of the pData member of WLAN_NOTIFICATION_DATA structure, which is specific to the IHV.
	/// </para>
	/// <para>
	/// If the NotificationSource member of the WLAN_NOTIFICATION_DATA structure received by the callback function is
	/// WLAN_NOTIFICATION_SOURCE_MSM, then the received notification is a media specific module (MSM) notification. The NotificationCode
	/// member of the WLAN_NOTIFICATION_DATA structure passed to the WLAN_NOTIFICATION_CALLBACK function determines the interpretation
	/// of the pData member of WLAN_NOTIFICATION_DATA structure. For more information on these notifications, see the
	/// WLAN_NOTIFICATION_MSM enumeration reference.
	/// </para>
	/// <para>
	/// The wlan_notification_msm_adapter_operation_mode_change notification is used when the operation mode changes. For more
	/// information about operation modes, see Native 802.11 Operation Modes. Two operation modes are supported:
	/// DOT11_OPERATION_MODE_EXTENSIBLE_STATION and DOT11_OPERATION_MODE_NETWORK_MONITOR. The operation mode constants are defined in
	/// the header file Windot11.h. When this notification is sent, pData points to the current operation mode.
	/// </para>
	/// <para>
	/// The wlan_notification_msm_peer_join and wlan_notification_msm_peer_leave notifications are used only when a machine creates an
	/// ad hoc network. These notifications are not used when a machine joins an existing ad hoc network.
	/// </para>
	/// <para>
	/// If the NotificationSource member of the WLAN_NOTIFICATION_DATA structure received by the callback function is
	/// WLAN_NOTIFICATION_SOURCE_ONEX, then the received notification is an 802.1X module notification. The NotificationCode member of
	/// the WLAN_NOTIFICATION_DATA structure passed to the WLAN_NOTIFICATION_CALLBACK function determines the interpretation of the
	/// pData member of WLAN_NOTIFICATION_DATA structure. For more information on these notifications, see the ONEX_NOTIFICATION_TYPE
	/// enumeration reference.
	/// </para>
	/// <para>
	/// If the NotificationSource member of the WLAN_NOTIFICATION_DATA structure received by the callback function is
	/// WLAN_NOTIFICATION_SOURCE_SECURITY, then the received notification is a security notification. No notifications are currently
	/// defined for WLAN_NOTIFICATION_SOURCE_SECURITY.
	/// </para>
	/// <para>
	/// The WLAN_NOTIFICATION_DATA structure is a typedef to the L2_WLAN_NOTIFICATION_DATA structure which is defined in the L2cmn.h
	/// header file which is automatically included by the Wlanapi.h header file. The L2cmn.h header file should never be used directly.
	/// </para>
	/// </remarks>
	[PInvokeData("wlanapi.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WLAN_NOTIFICATION_DATA
	{
		/// <summary>
		/// A value that indicates the source of the notification.
		/// <para>
		/// The possible values for this member are defined in the Wlanapai.h header file to values defined in the L2cmn.h header file.
		/// </para>
		/// <para>
		/// Windows XP with SP3 and Wireless LAN API for Windows XP with SP2: This parameter is set to WLAN_NOTIFICATION_SOURCE_NONE,
		/// WLAN_NOTIFICATION_SOURCE_ALL, or WLAN_NOTIFICATION_SOURCE_ACM.
		/// </para>
		/// </summary>
		public WLAN_NOTIFICATION_SOURCE NotificationSource;

		/// <summary>
		/// The type of notification. The value of this member indicates what type of associated data will be present in the value
		/// pointed to by the pData member.
		/// <para>
		/// This member can be a <see cref="ONEX_NOTIFICATION_TYPE"/>, <see cref="WLAN_NOTIFICATION_ACM"/>, <see
		/// cref="WLAN_NOTIFICATION_MSM"/> or <see cref="WLAN_HOSTED_NETWORK_NOTIFICATION_CODE"/> enumeration value.
		/// </para>
		/// <para>
		/// Windows XP with SP3 and Wireless LAN API for Windows XP with SP2: Only the wlan_notification_acm_connection_complete and
		/// wlan_notification_acm_disconnected notifications are available.
		/// </para>
		/// </summary>
		public uint NotificationCode;

		/// <summary>The interface on which the notification is for.</summary>
		public Guid InterfaceGuid;

		/// <summary>The size, in bytes, of value pointed to by pData member.</summary>
		public uint dwDataSize;

		/// <summary>
		/// A pointer to additional data provided for the notification. The type of data pointed to by the pData member is determined by
		/// the value of the NotificationCode member.
		/// </summary>
		public IntPtr pData;
	}

	/// <summary>The <c>WLAN_PHY_FRAME_STATISTICS</c> structure contains information about sent and received PHY frames</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_phy_frame_statistics typedef struct
	// WLAN_PHY_FRAME_STATISTICS { ULONGLONG ullTransmittedFrameCount; ULONGLONG ullMulticastTransmittedFrameCount; ULONGLONG
	// ullFailedCount; ULONGLONG ullRetryCount; ULONGLONG ullMultipleRetryCount; ULONGLONG ullMaxTXLifetimeExceededCount; ULONGLONG
	// ullTransmittedFragmentCount; ULONGLONG ullRTSSuccessCount; ULONGLONG ullRTSFailureCount; ULONGLONG ullACKFailureCount; ULONGLONG
	// ullReceivedFrameCount; ULONGLONG ullMulticastReceivedFrameCount; ULONGLONG ullPromiscuousReceivedFrameCount; ULONGLONG
	// ullMaxRXLifetimeExceededCount; ULONGLONG ullFrameDuplicateCount; ULONGLONG ullReceivedFragmentCount; ULONGLONG
	// ullPromiscuousReceivedFragmentCount; ULONGLONG ullFCSErrorCount; } WLAN_PHY_FRAME_STATISTICS, *PWLAN_PHY_FRAME_STATISTICS;
	[PInvokeData("wlanapi.h", MSDNShortId = "c675a3cd-bbe5-473e-b734-12e74fd19a50")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_PHY_FRAME_STATISTICS
	{
		/// <summary>Contains the number of successfully transmitted MSDU/MMPDUs.</summary>
		public ulong ullTransmittedFrameCount;

		/// <summary>
		/// Contains the number of successfully transmitted MSDU/MMPDUs in which the multicast bit is set as the destination MAC address.
		/// </summary>
		public ulong ullMulticastTransmittedFrameCount;

		/// <summary>
		/// Contains the number of MSDU/MMPDUs transmission failures due to the number of transmit attempts exceeding the retry limit.
		/// </summary>
		public ulong ullFailedCount;

		/// <summary>Contains the number of MSDU/MMPDUs successfully transmitted after one or more retransmissions.</summary>
		public ulong ullRetryCount;

		/// <summary>Contains the number of MSDU/MMPDUs successfully transmitted after more than one retransmission.</summary>
		public ulong ullMultipleRetryCount;

		/// <summary>Contains the number of fragmented MSDU/MMPDUs that failed to send due to timeout.</summary>
		public ulong ullMaxTXLifetimeExceededCount;

		/// <summary>
		/// Contains the number of MPDUs with an individual address in the address 1 field and MPDUs that have a multicast address with
		/// types Data or Management.
		/// </summary>
		public ulong ullTransmittedFragmentCount;

		/// <summary>Contains the number of times a CTS has been received in response to an RTS.</summary>
		public ulong ullRTSSuccessCount;

		/// <summary>Contains the number of times a CTS has not been received in response to an RTS.</summary>
		public ulong ullRTSFailureCount;

		/// <summary>Contains the number of times an expected ACK has not been received.</summary>
		public ulong ullACKFailureCount;

		/// <summary>Contains the number of MSDU/MMPDUs successfully received.</summary>
		public ulong ullReceivedFrameCount;

		/// <summary>Contains the number of successfully received MSDU/MMPDUs with the multicast bit set in the MAC address.</summary>
		public ulong ullMulticastReceivedFrameCount;

		/// <summary>Contains the number of MSDU/MMPDUs successfully received only because promicscuous mode is enabled.</summary>
		public ulong ullPromiscuousReceivedFrameCount;

		/// <summary>Contains the number of fragmented MSDU/MMPDUs dropped due to timeout.</summary>
		public ulong ullMaxRXLifetimeExceededCount;

		/// <summary>Contains the number of frames received that the Sequence Control field indicates as a duplicate.</summary>
		public ulong ullFrameDuplicateCount;

		/// <summary>Contains the number of successfully received Data or Management MPDUs.</summary>
		public ulong ullReceivedFragmentCount;

		/// <summary>Contains the number of MPDUs successfully received only because promiscuous mode is enabled.</summary>
		public ulong ullPromiscuousReceivedFragmentCount;

		/// <summary>Contains the number of times an FCS error has been detected in a received MPDU.</summary>
		public ulong ullFCSErrorCount;
	}

	/// <summary>The <c>WLAN_PHY_RADIO_STATE</c> structure specifies the radio state on a specific physical layer (PHY) type.</summary>
	/// <remarks>
	/// <para>
	/// The <c>WLAN_PHY_RADIO_STATE</c> structure is used with the WlanSetInterface function when the OpCode parameter is set to <c>wlan_intf_opcode_radio_state</c>.
	/// </para>
	/// <para>
	/// The <c>WLAN_PHY_RADIO_STATE</c> structure is also used for notification by the media specific module (MSM) when the radio state
	/// changes. An application registers to receive MSM notifications by calling the WlanRegisterNotification function with the
	/// dwNotifSource parameter set to a value that includes <c>WLAN_NOTIFICATION_SOURCE_MSM</c>. For more information on these
	/// notifications, see the WLAN_NOTIFICATION_DATA structure and the WLAN_NOTIFICATION_MSM enumeration reference.
	/// </para>
	/// <para>
	/// The radio state of a PHY is off if either <c>dot11SoftwareRadioState</c> or <c>dot11HardwareRadioState</c> member of the
	/// <c>WLAN_PHY_RADIO_STATE</c> structure is <c>dot11_radio_state_off</c>.
	/// </para>
	/// <para>
	/// The hardware radio state cannot be changed by calling the WlanSetInterface function. The <c>dot11HardwareRadioState</c> member
	/// of the <c>WLAN_PHY_RADIO_STATE</c> structure is ignored when the <c>WlanSetInterface</c> function is called with the OpCode
	/// parameter set to <c>wlan_intf_opcode_radio_state</c> and the pData parameter points to a <c>WLAN_PHY_RADIO_STATE</c> structure.
	/// </para>
	/// <para>The software radio state can be changed by calling the WlanSetInterface function.</para>
	/// <para>
	/// Changing the software radio state of a physical network interface could cause related changes in the state of the wireless
	/// Hosted Network or virtual wireless adapter radio states. The PHYs of every virtual wireless adapter are linked. For more
	/// information, see the About the Wireless Hosted Network.
	/// </para>
	/// <para>
	/// The radio state of a PHY is off if either the software radio state ( <c>dot11SoftwareRadioState</c> member) or the hardware
	/// radio state ( <c>dot11HardwareRadioState</c> member) is off.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_phy_radio_state typedef struct _WLAN_PHY_RADIO_STATE {
	// DWORD dwPhyIndex; DOT11_RADIO_STATE dot11SoftwareRadioState; DOT11_RADIO_STATE dot11HardwareRadioState; } WLAN_PHY_RADIO_STATE, *PWLAN_PHY_RADIO_STATE;
	[PInvokeData("wlanapi.h", MSDNShortId = "20da1494-4264-4d0d-b789-25e2be6a8dd4")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_PHY_RADIO_STATE
	{
		/// <summary>
		/// The index of the PHY type on which the radio state is being set or queried. The WlanGetInterfaceCapability function returns
		/// a list of valid PHY types.
		/// </summary>
		public uint dwPhyIndex;

		/// <summary>A DOT11_RADIO_STATE value that indicates the software radio state.</summary>
		public DOT11_RADIO_STATE dot11SoftwareRadioState;

		/// <summary>A DOT11_RADIO_STATE value that indicates the hardware radio state.</summary>
		public DOT11_RADIO_STATE dot11HardwareRadioState;
	}

	/// <summary>The <c>WLAN_PROFILE_INFO</c> structure contains basic information about a profile.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_profile_info typedef struct _WLAN_PROFILE_INFO { WCHAR
	// strProfileName[WLAN_MAX_NAME_LENGTH]; DWORD dwFlags; } WLAN_PROFILE_INFO, *PWLAN_PROFILE_INFO;
	[PInvokeData("wlanapi.h", MSDNShortId = "ca45278c-2e1e-4080-825a-d6a05e463858")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WLAN_PROFILE_INFO
	{
		/// <summary>
		/// <para>
		/// The name of the profile. This value may be the name of a domain if the profile is for provisioning. Profile names are
		/// case-sensitive. This string must be NULL-terminated.
		/// </para>
		/// <para>
		/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> The name of the profile is derived automatically
		/// from the SSID of the wireless network. For infrastructure network profiles, the name of the profile is the SSID of the
		/// network. For ad hoc network profiles, the name of the profile is the SSID of the ad hoc network followed by .
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = WLAN_MAX_NAME_LENGTH)]
		public string strProfileName;

		/// <summary>
		/// <para>A set of flags specifying settings for wireless profile. These values are defined in the Wlanapi.h header file.</para>
		/// <para>
		/// <c>Windows XP with SP3 and Wireless LAN API for Windows XP with SP2:</c> dwFlags must be 0. Per-user profiles are not supported.
		/// </para>
		/// <para>Combinations of these flag bits are possible</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WLAN_PROFILE_GROUP_POLICY</term>
		/// <term>
		/// This flag indicates that this profile was created by group policy. A group policy profile is read-only. Neither the content
		/// nor the preference order of the profile can be changed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WLAN_PROFILE_USER</term>
		/// <term>This flag indicates that the profile is a per-user profile. If not set, this profile is an all-user profile.</term>
		/// </item>
		/// </list>
		/// </summary>
		public WLAN_PROFILE_FLAGS dwFlags;
	}

	/// <summary>The <c>WLAN_RADIO_STATE</c> structurespecifies the radio state on a list of physical layer (PHY) types.</summary>
	/// <remarks>
	/// <para>
	/// The <c>WLAN_RADIO_STATE</c> structure is used with the WlanQueryInterface function when the OpCode parameter is set to
	/// <c>wlan_intf_opcode_radio_state</c>. If the call is successful, the ppData parameter points to a <c>WLAN_RADIO_STATE</c> structure.
	/// </para>
	/// <para>
	/// The WLAN_PHY_RADIO_STATE structure members in the <c>WLAN_RADIO_STATE</c> structure can be used with the WlanSetInterface
	/// function when the OpCode parameter is set to <c>wlan_intf_opcode_radio_state</c> to change the radio state.
	/// </para>
	/// <para>
	/// The WLAN_PHY_RADIO_STATE structure is also used for notification by the media specific module (MSM) when the radio state
	/// changes. An application registers to receive MSM notifications by calling the WlanRegisterNotification function with the
	/// dwNotifSource parameter set to a value that includes <c>WLAN_NOTIFICATION_SOURCE_MSM</c>. For more information on these
	/// notifications, see the WLAN_NOTIFICATION_DATA structure and the WLAN_NOTIFICATION_MSM enumeration reference.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example enumerates the wireless LAN interfaces on the local computer, queries each interface for the
	/// <c>WLAN_RADIO_STATE</c> on the interface, and prints values from the retrieved <c>WLAN_RADIO_STATE</c> structure.
	/// </para>
	/// <para>
	/// <c>Note</c> This example will fail to load on Windows Server 2008 and Windows Server 2008 R2 if the Wireless LAN Service is not
	/// installed and started.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_radio_state typedef struct _WLAN_RADIO_STATE { DWORD
	// dwNumberOfPhys; WLAN_PHY_RADIO_STATE PhyRadioState[WLAN_MAX_PHY_INDEX]; } WLAN_RADIO_STATE, *PWLAN_RADIO_STATE;
	[PInvokeData("wlanapi.h", MSDNShortId = "61551b46-785e-4353-910c-8ce23172b176")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_RADIO_STATE
	{
		/// <summary>The number of valid PHY indices in the <c>PhyRadioState</c> member.</summary>
		public uint dwNumberOfPhys;

		/// <summary>
		/// An array of WLAN_PHY_RADIO_STATE structures that specify the radio states of a number of PHY indices. Only the first
		/// <c>dwNumberOfPhys</c> entries in this array are valid.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = WLAN_MAX_PHY_INDEX)]
		public WLAN_PHY_RADIO_STATE[] PhyRadioState;
	}

	/// <summary>The set of supported data rates.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_rate_set typedef struct _WLAN_RATE_SET { ULONG
	// uRateSetLength; USHORT usRateSet[DOT11_RATE_SET_MAX_LENGTH]; } WLAN_RATE_SET, *PWLAN_RATE_SET;
	[PInvokeData("wlanapi.h", MSDNShortId = "e07a9249-9571-4747-b913-05d319202f8f")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_RATE_SET
	{
		/// <summary>The length, in bytes, of <c>usRateSet</c>.</summary>
		public uint uRateSetLength;

		/// <summary>
		/// <para>An array of supported data transfer rates. DOT11_RATE_SET_MAX_LENGTH is defined in windot11.h to have a value of 126.</para>
		/// <para>
		/// Each supported data transfer rate is stored as a USHORT. The first bit of the USHORT specifies whether the rate is a basic
		/// rate. A basic rate is the data transfer rate that all stations in a basic service set (BSS) can use to receive frames from
		/// the wireless medium. If the rate is a basic rate, the first bit of the USHORT is set to 1.
		/// </para>
		/// <para>To calculate the data transfer rate in Mbps for an arbitrary array entry rateSet[i], use the following equation:</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = DOT11_RATE_SET_MAX_LENGTH)]
		public ushort[] usRateSet;
	}

	/// <summary>The <c>WLAN_RAW_DATA</c> structure contains raw data in the form of a blob that is used by some Native Wifi functions.</summary>
	/// <remarks>
	/// <para>
	/// The <c>WLAN_RAW_DATA</c> structure is a raw data structure used to hold a data entry used by some Native Wifi functions. The
	/// data structure is in the form of a generalized blob that can contain any type of data.
	/// </para>
	/// <para>
	/// The WlanScan function uses the <c>WLAN_RAW_DATA</c> structure. The pIeData parameter passed to the <c>WlanScan</c> function
	/// points to a <c>WLAN_RAW_DATA</c> structure currently used to contain an information element to include in probe requests. This
	/// <c>WLAN_RAW_DATA</c> structure passed to the <c>WlanScan</c> function can contain a proximity service discovery (PSD)
	/// information element (IE) data entry.
	/// </para>
	/// <para>
	/// When the <c>WLAN_RAW_DATA</c> structure is used to store a PSD IE, the <c>DOT11_PSD_IE_MAX_DATA_SIZE</c> constant defined in the
	/// Wlanapi.h header file is the maximum value of the <c>dwDataSize</c> member.
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
	/// <para>For more information about PSD IEs, including a discussion of the format of an IE, see the WlanSetPsdIEDataList function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_raw_data typedef struct _WLAN_RAW_DATA { DWORD
	// dwDataSize; #if ... BYTE *DataBlob[]; #else BYTE DataBlob[1]; #endif } WLAN_RAW_DATA, *PWLAN_RAW_DATA;
	[PInvokeData("wlanapi.h", MSDNShortId = "5f5ddecb-f841-436c-bf31-c70c95a5d39c")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_RAW_DATA
	{
		/// <summary>
		/// The size, in bytes, of the <c>DataBlob</c> member. The maximum value of the <c>dwDataSize</c> may be restricted by type of
		/// data that is stored in the <c>WLAN_RAW_DATA</c> structure.
		/// </summary>
		public uint dwDataSize;

		/// <summary>The data blob.</summary>
		public IntPtr DataBlob;
	}

	/// <summary>
	/// The <c>WLAN_RAW_DATA_LIST</c> structure contains raw data in the form of an array of data blobs that are used by some Native
	/// Wifi functions.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>WLAN_RAW_DATA_LIST</c> structure is used to encapsulate a list of data blobs into a flat memory block. It should be
	/// interpreted as a list of headers followed by data blobs.
	/// </para>
	/// <para>
	/// To create a <c>WLAN_RAW_DATA_LIST</c>, an application needs to allocate a memory block that is large enough to hold the headers
	/// and the data blobs, and then cast the memory block to a pointer to a <c>WLAN_RAW_DATA_LIST</c> structure.
	/// </para>
	/// <para>The following is the memory layout of an example <c>WLAN_RAW_DATA_LIST</c> structure that contains two data blobs.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Memory Offset</term>
	/// <term>Field</term>
	/// <term>Value</term>
	/// <term>Comments</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>dwTotalSize</term>
	/// <term>84</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>dwNumberOfItems</term>
	/// <term>2</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>dwDataOffset</term>
	/// <term>16</term>
	/// <term>Offset of the first blob: 16 = 24 - 8</term>
	/// </item>
	/// <item>
	/// <term>12</term>
	/// <term>dwDataSize</term>
	/// <term>20</term>
	/// <term>Size of the first blob.</term>
	/// </item>
	/// <item>
	/// <term>16</term>
	/// <term>dwDataOffset</term>
	/// <term>28</term>
	/// <term>Offset of the second blob: 44 - 16.</term>
	/// </item>
	/// <item>
	/// <term>20</term>
	/// <term>dwDataSize</term>
	/// <term>24</term>
	/// <term>Size of the second blob.</term>
	/// </item>
	/// <item>
	/// <term>24</term>
	/// <term/>
	/// <term>20</term>
	/// <term>Start of the first blob.</term>
	/// </item>
	/// <item>
	/// <term>44</term>
	/// <term/>
	/// <term>40</term>
	/// <term>Start of the second blob.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>WLAN_RAW_DATA_LIST</c> structure is currently used by the WlanSetPsdIEDataList function to set the proximity service
	/// discovery (PSD) information element (IE) data list for an application.
	/// </para>
	/// <para>
	/// When used to store a PSD IE data list, the <c>DOT11_PSD_IE_MAX_ENTRY_NUMBER</c> constant defined in the Wlanapi.h header file is
	/// the maximum value of the <c>dwNumberOfItems</c> member for the number of blobs in the <c>WLAN_RAW_DATA_LIST</c> structure. The
	/// <c>DOT11_PSD_IE_MAX_DATA_SIZE</c> constant defined in the Wlanapi.h header file is the maximum value of the <c>dwDataSize</c>
	/// member for any blob.
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
	/// <item>
	/// <term>DOT11_PSD_IE_MAX_ENTRY_NUMBER</term>
	/// <term>5</term>
	/// <term>The maximum number of PSD IE data entries.</term>
	/// </item>
	/// </list>
	/// <para>For more information about PSD IEs, including a discussion of the format of an IE, see WlanSetPsdIEDataList.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_raw_data_list typedef struct _WLAN_RAW_DATA_LIST {
	// DWORD dwTotalSize; DWORD dwNumberOfItems; struct { DWORD dwDataOffset; DWORD dwDataSize; }; __unnamed_struct_088f_1 DataList[1];
	// } WLAN_RAW_DATA_LIST, *PWLAN_RAW_DATA_LIST;
	[PInvokeData("wlanapi.h", MSDNShortId = "e0e59abf-1a78-4c7f-b044-2d4c75328329")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<WLAN_RAW_DATA_LIST>), nameof(dwNumberOfItems))]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_RAW_DATA_LIST
	{
		/// <summary>The total size, in bytes, of the <c>WLAN_RAW_DATA_LIST</c> structure.</summary>
		public uint dwTotalSize;

		/// <summary>
		/// The number of raw data entries or blobs in the <c>WLAN_RAW_DATA_LIST</c> structure. The maximum value of the
		/// <c>dwNumberOfItems</c> may be restricted by the type of data that is stored in the <c>WLAN_RAW_DATA_LIST</c> structure.
		/// </summary>
		public uint dwNumberOfItems;

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct WLAN_RAW_DATA_INFO
		{
			/// <summary/>
			public uint dwDataOffset;

			/// <summary/>
			public uint dwDataSize;
		}

		/// <summary>
		/// <para>An array of raw data entries or blobs that make up the data list.</para>
		/// <para>dwDataOffset</para>
		/// <para>
		/// The offset, in bytes, of the data blob from the beginning of current blob descriptor. For details, see the example in the
		/// Remarks section below.
		/// </para>
		/// <para>dwDataSize</para>
		/// <para>The size, in bytes, of the data blob.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public WLAN_RAW_DATA_INFO[] DataList;
	}

	/// <summary>The <c>WLAN_SECURITY_ATTRIBUTES</c> structure defines the security attributes for a wireless connection.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_security_attributes typedef struct
	// _WLAN_SECURITY_ATTRIBUTES { BOOL bSecurityEnabled; BOOL bOneXEnabled; DOT11_AUTH_ALGORITHM dot11AuthAlgorithm;
	// DOT11_CIPHER_ALGORITHM dot11CipherAlgorithm; } WLAN_SECURITY_ATTRIBUTES, *PWLAN_SECURITY_ATTRIBUTES;
	[PInvokeData("wlanapi.h", MSDNShortId = "37aa07a2-fe7f-46e3-9f17-545f48442f35")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_SECURITY_ATTRIBUTES
	{
		/// <summary>Indicates whether security is enabled for this connection.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool bSecurityEnabled;

		/// <summary>Indicates whether 802.1X is enabled for this connection.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool bOneXEnabled;

		/// <summary>A DOT11_AUTH_ALGORITHM value that identifies the authentication algorithm.</summary>
		public DOT11_AUTH_ALGORITHM dot11AuthAlgorithm;

		/// <summary>A DOT11_CIPHER_ALGORITHM value that identifies the cipher algorithm.</summary>
		public DOT11_CIPHER_ALGORITHM dot11CipherAlgorithm;
	}

	/// <summary>The <c>WLAN_STATISTICS</c> structure contains assorted statistics about an interface.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_statistics typedef struct WLAN_STATISTICS { ULONGLONG
	// ullFourWayHandshakeFailures; ULONGLONG ullTKIPCounterMeasuresInvoked; ULONGLONG ullReserved; WLAN_MAC_FRAME_STATISTICS
	// MacUcastCounters; WLAN_MAC_FRAME_STATISTICS MacMcastCounters; DWORD dwNumberOfPhys; #if ... WLAN_PHY_FRAME_STATISTICS
	// *PhyCounters[]; #else WLAN_PHY_FRAME_STATISTICS PhyCounters[1]; #endif } WLAN_STATISTICS, *PWLAN_STATISTICS;
	[PInvokeData("wlanapi.h", MSDNShortId = "d66d89f1-bb12-4c2e-8c7a-a4eba008955d")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<WLAN_STATISTICS>), nameof(dwNumberOfPhys))]
	[StructLayout(LayoutKind.Sequential)]
	public struct WLAN_STATISTICS
	{
		/// <summary>
		/// Indicates the number of 4-way handshake failures. This member is only valid if IHV Service is being used as the
		/// authentication service for the current network.
		/// </summary>
		public ulong ullFourWayHandshakeFailures;

		/// <summary>
		/// Indicates the number of TKIP countermeasures performed by an IHV Miniport driver. This count does not include TKIP
		/// countermeasures invoked by the operating system.
		/// </summary>
		public ulong ullTKIPCounterMeasuresInvoked;

		/// <summary>Reserved for use by Microsoft.</summary>
		public ulong ullReserved;

		/// <summary>
		/// A WLAN_MAC_FRAME_STATISTICS structure that contains MAC layer counters for unicast packets directed to the receiver of the NIC.
		/// </summary>
		public WLAN_MAC_FRAME_STATISTICS MacUcastCounters;

		/// <summary>
		/// A WLAN_MAC_FRAME_STATISTICS structure that contains MAC layer counters for multicast packets directed to the current
		/// multicast address.
		/// </summary>
		public WLAN_MAC_FRAME_STATISTICS MacMcastCounters;

		/// <summary>Contains the number of <c>WLAN_PHY_FRAME_STATISTICS</c> structures in the <c>PhyCounters</c> member.</summary>
		public uint dwNumberOfPhys;

		/// <summary>An array of WLAN_PHY_FRAME_STATISTICS structures that contain PHY layer counters.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public WLAN_PHY_FRAME_STATISTICS[] PhyCounters;
	}

	/// <summary>The <c>DOT11_NETWORK_LIST</c> structure contains a list of 802.11 wireless networks.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-dot11_network_list typedef struct _DOT11_NETWORK_LIST {
	// DWORD dwNumberOfItems; DWORD dwIndex; #if ... DOT11_NETWORK *Network[]; #else DOT11_NETWORK Network[1]; #endif }
	// DOT11_NETWORK_LIST, *PDOT11_NETWORK_LIST;
	[PInvokeData("wlanapi.h", MSDNShortId = "607c5795-8168-4c6b-a2f3-65f31aea5cf5")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DOT11_NETWORK_LIST>), nameof(dwNumberOfItems))]
	[StructLayout(LayoutKind.Sequential)]
	public class DOT11_NETWORK_LIST
	{
		/// <summary>Initializes a new instance of the <see cref="DOT11_NETWORK_LIST"/> class.</summary>
		public DOT11_NETWORK_LIST() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="DOT11_NETWORK_LIST"/> class setting the <see cref="Network"/> and <see
		/// cref="dwNumberOfItems"/> fields based on <paramref name="network"/>.
		/// </summary>
		/// <param name="network">An array of DOT11_NETWORK structures that contain 802.11 wireless network information.</param>
		public DOT11_NETWORK_LIST(DOT11_NETWORK[] network)
		{
			Network = network;
			dwNumberOfItems = (uint)(network?.Length ?? 0);
		}

		/// <summary>Contains the number of items in the <c>Network</c> member.</summary>
		public uint dwNumberOfItems;

		/// <summary>
		/// <para>The index of the current item. The index of the first item is 0. <c>dwIndex</c> must be less than <c>dwNumberOfItems</c>.</para>
		/// <para>
		/// This member is not used by the wireless service. Applications can use this member when processing individual networks in the
		/// <c>DOT11_NETWORK_LIST</c> structure. When an application passes this structure from one function to another, it can set the
		/// value of <c>dwIndex</c> to the index of the item currently being processed. This can help an application maintain state.
		/// </para>
		/// <para><c>dwIndex</c> should always be initialized before use.</para>
		/// </summary>
		public uint dwIndex;

		/// <summary>An array of DOT11_NETWORK structures that contain 802.11 wireless network information.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public DOT11_NETWORK[] Network;
	}

	/// <summary>The <c>WLAN_AVAILABLE_NETWORK_LIST</c> structure contains an array of information about available networks.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_available_network_list typedef struct
	// _WLAN_AVAILABLE_NETWORK_LIST { DWORD dwNumberOfItems; DWORD dwIndex; #if ... WLAN_AVAILABLE_NETWORK *Network[]; #else
	// WLAN_AVAILABLE_NETWORK Network[1]; #endif } WLAN_AVAILABLE_NETWORK_LIST, *PWLAN_AVAILABLE_NETWORK_LIST;
	[PInvokeData("wlanapi.h", MSDNShortId = "0ac508b2-9117-423d-89d3-982f070c70e2")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<WLAN_AVAILABLE_NETWORK_LIST>), nameof(dwNumberOfItems))]
	[StructLayout(LayoutKind.Sequential)]
	public class WLAN_AVAILABLE_NETWORK_LIST
	{
		/// <summary>Contains the number of items in the <c>Network</c> member.</summary>
		public uint dwNumberOfItems;

		/// <summary>
		/// <para>The index of the current item. The index of the first item is 0. <c>dwIndex</c> must be less than <c>dwNumberOfItems</c>.</para>
		/// <para>
		/// This member is not used by the wireless service. Applications can use this member when processing individual networks in the
		/// <c>WLAN_AVAILABLE_NETWORK_LIST</c> structure. When an application passes this structure from one function to another, it can
		/// set the value of <c>dwIndex</c> to the index of the item currently being processed. This can help an application maintain state.
		/// </para>
		/// <para><c>dwIndex</c> should always be initialized before use.</para>
		/// </summary>
		public uint dwIndex;

		/// <summary>An array of WLAN_AVAILABLE_NETWORK structures containing interface information.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public WLAN_AVAILABLE_NETWORK[] Network;
	}

	/// <summary>The <c>WLAN_BSS_LIST</c> structure contains a list of basic service set (BSS) entries.</summary>
	/// <remarks>
	/// <para>
	/// The WlanGetNetworkBssList function retrieves the BSS list of the wireless network or networks on a given interface and returns
	/// this information in a <c>WLAN_BSS_LIST</c> structure.
	/// </para>
	/// <para>
	/// The <c>WLAN_BSS_LIST</c> structure may contain padding for alignment between the <c>dwTotalSize</c> member, the
	/// <c>dwNumberOfItems</c> member, and the first WLAN_BSS_ENTRY array entry in the <c>wlanBssEntries</c> member. Padding for
	/// alignment may also be present between the <c>WLAN_BSS_ENTRY</c> array entries in the <c>wlanBssEntries</c> member. Any access to
	/// a <c>WLAN_BSS_ENTRY</c> array entry should assume padding may exist.
	/// </para>
	/// <para>
	/// When the wireless LAN interface is also operating as a Wireless Hosted Network , the BSS list will contain an entry for the BSS
	/// created for the Wireless Hosted Network.
	/// </para>
	/// <para>
	/// Since the information is returned by the access point for an infrastructure BSS network or by the network peer for an
	/// independent BSS network (ad hoc network), the information returned should not be trusted. The <c>ulIeOffset</c> and
	/// <c>ulIeSize</c> members in the WLAN_BSS_ENTRY structure should be used to determine the maximum size of the information element
	/// data blob in the <c>WLAN_BSS_ENTRY</c> structure, not the data in the information element data blob.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_bss_list typedef struct _WLAN_BSS_LIST { DWORD
	// dwTotalSize; DWORD dwNumberOfItems; WLAN_BSS_ENTRY wlanBssEntries[1]; } WLAN_BSS_LIST, *PWLAN_BSS_LIST;
	[PInvokeData("wlanapi.h", MSDNShortId = "aeb68835-31ce-4fa7-980a-91a328fbcbc3")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<WLAN_BSS_LIST>), nameof(dwNumberOfItems))]
	[StructLayout(LayoutKind.Sequential)]
	public class WLAN_BSS_LIST
	{
		/// <summary>The total size of this structure, in bytes.</summary>
		public uint dwTotalSize;

		/// <summary>The number of items in the <c>wlanBssEntries</c> member.</summary>
		public uint dwNumberOfItems;

		/// <summary>An array of WLAN_BSS_ENTRY structures that contains information about a BSS.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public WLAN_BSS_ENTRY[] wlanBssEntries;
	}

	/// <summary>Contains an array of device service GUIDs.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_device_service_guid_list typedef struct
	// _WLAN_DEVICE_SERVICE_GUID_LIST { DWORD dwNumberOfItems; DWORD dwIndex; #if ... GUID *DeviceService[]; #else GUID
	// DeviceService[1]; #endif } WLAN_DEVICE_SERVICE_GUID_LIST, *PWLAN_DEVICE_SERVICE_GUID_LIST;
	[PInvokeData("wlanapi.h")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<WLAN_DEVICE_SERVICE_GUID_LIST>), nameof(dwNumberOfItems))]
	[StructLayout(LayoutKind.Sequential)]
	public class WLAN_DEVICE_SERVICE_GUID_LIST
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of items in the DeviceService argument.</para>
		/// </summary>
		public uint dwNumberOfItems;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The index of the current item. The index of the first item is 0. dwIndex must be less than dwNumberOfItems. This member is
		/// not used by the wireless service. You can use this member when processing individual <c>GUID</c> s in the
		/// <c>WLAN_DEVICE_SERVICE_GUID_LIST</c> structure. When your application passes this structure from one function to another, it
		/// can set the value of dwIndex to the index of the item currently being processed. This can help your application maintain
		/// state. You should always initialize dwIndex before use.
		/// </para>
		/// </summary>
		public uint dwIndex;

		/// <summary>
		/// <para>Type: <c>GUID[1]</c></para>
		/// <para>A pointer to an array containing <c>GUID</c> s; each corresponds to a WLAN device service that the driver supports.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public Guid[] DeviceService;
	}

	/// <summary>The <c>WLAN_HOSTED_NETWORK_STATUS</c> structure contains information about the status of the wireless Hosted Network.</summary>
	/// <remarks>
	/// <para>
	/// The <c>WLAN_HOSTED_NETWORK_STATUS</c> structure is an extension to native wireless APIs added to support the wireless Hosted
	/// Network on Windows 7 and later.
	/// </para>
	/// <para>
	/// The <c>WLAN_HOSTED_NETWORK_STATUS</c> structure is returned in a pointer in the ppWlanHostedNetworkStatus parameter by the
	/// WlanHostedNetworkQueryStatus function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_hosted_network_status typedef struct
	// _WLAN_HOSTED_NETWORK_STATUS { WLAN_HOSTED_NETWORK_STATE HostedNetworkState; GUID IPDeviceID; DOT11_MAC_ADDRESS
	// wlanHostedNetworkBSSID; DOT11_PHY_TYPE dot11PhyType; ULONG ulChannelFrequency; DWORD dwNumberOfPeers; #if ...
	// WLAN_HOSTED_NETWORK_PEER_STATE *PeerList[]; #else WLAN_HOSTED_NETWORK_PEER_STATE PeerList[1]; #endif }
	// WLAN_HOSTED_NETWORK_STATUS, *PWLAN_HOSTED_NETWORK_STATUS;
	[PInvokeData("wlanapi.h", MSDNShortId = "5fa00041-235f-4f48-a367-e1eaec8474ce")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<WLAN_HOSTED_NETWORK_STATUS>), nameof(dwNumberOfPeers))]
	[StructLayout(LayoutKind.Sequential)]
	public class WLAN_HOSTED_NETWORK_STATUS
	{
		/// <summary>
		/// <para>The current state of the wireless Hosted Network.</para>
		/// <para>
		/// If the value of this member is <c>wlan_hosted_network_unavailable</c>, then the values of the other fields in this structure
		/// should not be used.
		/// </para>
		/// </summary>
		public WLAN_HOSTED_NETWORK_STATE HostedNetworkState;

		/// <summary>
		/// <para>The actual network Device ID used for the wireless Hosted Network.</para>
		/// <para>
		/// This is member is the GUID of a virtual wireless device which would not be available through calls to the WlanEnumInterfaces
		/// function. This GUID can be used for calling other higher layer networking functions that use the device GUID (IP Helper
		/// functions, for example).
		/// </para>
		/// </summary>
		public Guid IPDeviceID;

		/// <summary>The BSSID used by the wireless Hosted Network in packets, beacons, and probe responses.</summary>
		public DOT11_MAC_ADDRESS wlanHostedNetworkBSSID;

		/// <summary>
		/// <para>The physical type of the network interface used by wireless Hosted Network.</para>
		/// <para>
		/// This is one of the types reported by the related physical interface. This value is correct only if the
		/// <c>HostedNetworkState</c> member is <c>wlan_hosted_network_active</c>.
		/// </para>
		/// </summary>
		public DOT11_PHY_TYPE dot11PhyType;

		/// <summary>
		/// <para>The channel frequency of the network interface used by wireless Hosted Network.</para>
		/// <para>This value is correct only if <c>HostedNetworkState</c> is <c>wlan_hosted_network_active</c>.</para>
		/// </summary>
		public uint ulChannelFrequency;

		/// <summary>
		/// <para>The current number of authenticated peers on the wireless Hosted Network.</para>
		/// <para>This value is correct only if <c>HostedNetworkState</c> is <c>wlan_hosted_network_active</c>.</para>
		/// </summary>
		public uint dwNumberOfPeers;

		/// <summary>
		/// <para>
		/// An array of WLAN_HOSTED_NETWORK_PEER_STATE structures describing each of the current peers on the wireless Hosted Network.
		/// The number of elements in the array is given by <c>dwNumberOfPeers</c> member.
		/// </para>
		/// <para>This value is correct only if <c>HostedNetworkState</c> is <c>wlan_hosted_network_active</c>.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public WLAN_HOSTED_NETWORK_PEER_STATE[] PeerList;
	}

	/// <summary>The <c>WLAN_INTERFACE_CAPABILITY</c> structure contains information about the capabilities of an interface.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_interface_capability typedef struct
	// _WLAN_INTERFACE_CAPABILITY { WLAN_INTERFACE_TYPE interfaceType; BOOL bDot11DSupported; DWORD dwMaxDesiredSsidListSize; DWORD
	// dwMaxDesiredBssidListSize; DWORD dwNumberOfSupportedPhys; DOT11_PHY_TYPE dot11PhyTypes[WLAN_MAX_PHY_INDEX]; }
	// WLAN_INTERFACE_CAPABILITY, *PWLAN_INTERFACE_CAPABILITY;
	[PInvokeData("wlanapi.h", MSDNShortId = "db7a9066-d699-4860-90cd-dc3f4bf42549")]
	[StructLayout(LayoutKind.Sequential)]
	public class WLAN_INTERFACE_CAPABILITY
	{
		/// <summary>A WLAN_INTERFACE_TYPE value that indicates the type of the interface.</summary>
		public WLAN_INTERFACE_TYPE interfaceType;

		/// <summary>Indicates whether 802.11d is supported by the interface. If <c>TRUE</c>, 802.11d is supported.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool bDot11DSupported;

		/// <summary>The maximum size of the SSID list supported by this interface.</summary>
		public uint dwMaxDesiredSsidListSize;

		/// <summary>The maximum size of the basic service set (BSS) identifier list supported by this interface.</summary>
		public uint dwMaxDesiredBssidListSize;

		/// <summary>Contains the number of supported PHY types.</summary>
		public uint dwNumberOfSupportedPhys;

		/// <summary>An array of DOT11_PHY_TYPE values that specify the supported PHY types. WLAN_MAX_PHY_INDEX is set to 64.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = WLAN_MAX_PHY_INDEX)]
		public DOT11_PHY_TYPE[] dot11PhyTypes;
	}

	/// <summary>The <c>WLAN_INTERFACE_INFO_LIST</c> structure contains an array of NIC interface information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_interface_info_list typedef struct
	// _WLAN_INTERFACE_INFO_LIST { DWORD dwNumberOfItems; DWORD dwIndex; #if ... WLAN_INTERFACE_INFO *InterfaceInfo[]; #else
	// WLAN_INTERFACE_INFO InterfaceInfo[1]; #endif } WLAN_INTERFACE_INFO_LIST, *PWLAN_INTERFACE_INFO_LIST;
	[PInvokeData("wlanapi.h", MSDNShortId = "c57f4658-9f1e-4b05-a298-38a064121bb3")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<WLAN_INTERFACE_INFO_LIST>), nameof(dwNumberOfItems))]
	[StructLayout(LayoutKind.Sequential)]
	public class WLAN_INTERFACE_INFO_LIST
	{
		/// <summary>Contains the number of items in the <c>InterfaceInfo</c> member.</summary>
		public uint dwNumberOfItems;

		/// <summary>
		/// <para>The index of the current item. The index of the first item is 0. <c>dwIndex</c> must be less than <c>dwNumberOfItems</c>.</para>
		/// <para>
		/// This member is not used by the wireless service. Applications can use this member when processing individual interfaces in
		/// the <c>WLAN_INTERFACE_INFO_LIST</c> structure. When an application passes this structure from one function to another, it
		/// can set the value of <c>dwIndex</c> to the index of the item currently being processed. This can help an application
		/// maintain state.
		/// </para>
		/// <para><c>dwIndex</c> should always be initialized before use.</para>
		/// </summary>
		public uint dwIndex;

		/// <summary>An array of WLAN_INTERFACE_INFO structures containing interface information.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public WLAN_INTERFACE_INFO[] InterfaceInfo;
	}

	/// <summary>The <c>WLAN_PROFILE_INFO_LIST</c> structure contains a list of wireless profile information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wlanapi/ns-wlanapi-wlan_profile_info_list typedef struct
	// _WLAN_PROFILE_INFO_LIST { DWORD dwNumberOfItems; DWORD dwIndex; #if ... WLAN_PROFILE_INFO *ProfileInfo[]; #else WLAN_PROFILE_INFO
	// ProfileInfo[1]; #endif } WLAN_PROFILE_INFO_LIST, *PWLAN_PROFILE_INFO_LIST;
	[PInvokeData("wlanapi.h", MSDNShortId = "d5a3d475-0ae0-4860-a433-dd916c586f50")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<WLAN_PROFILE_INFO_LIST>), nameof(dwNumberOfItems))]
	[StructLayout(LayoutKind.Sequential)]
	public class WLAN_PROFILE_INFO_LIST
	{
		/// <summary>The number of wireless profile entries in the <c>ProfileInfo</c> member.</summary>
		public uint dwNumberOfItems;

		/// <summary>
		/// <para>
		/// The index of the current item. The index of the first item is 0. The <c>dwIndex</c> member must be less than the
		/// <c>dwNumberOfItems</c> member.
		/// </para>
		/// <para>
		/// This member is not used by the wireless service. Applications can use this member when processing individual profiles in the
		/// <c>WLAN_PROFILE_INFO_LIST</c> structure. When an application passes this structure from one function to another, it can set
		/// the value of <c>dwIndex</c> to the index of the item currently being processed. This can help an application maintain state.
		/// </para>
		/// <para><c>dwIndex</c> should always be initialized before use.</para>
		/// </summary>
		public uint dwIndex;

		/// <summary>
		/// An array of WLAN_PROFILE_INFO structures containing interface information. The number of items in the array is specified in
		/// the <c>dwNumberOfItems</c> member.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public WLAN_PROFILE_INFO[] ProfileInfo;
	}
}