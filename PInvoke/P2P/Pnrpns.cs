namespace Vanara.PInvoke;

/// <summary>Items from the P2P.dll</summary>
public static partial class P2P
{
	/// <summary/>
	public static readonly Guid NS_PROVIDER_PNRPCLOUD = new(0x03fe89ce, 0x766d, 0x4976, 0xb9, 0xc1, 0xbb, 0x9b, 0xc4, 0x2c, 0x7b, 0x4d);

	/// <summary/>
	public static readonly Guid NS_PROVIDER_PNRPNAME = new(0x03fe89cd, 0x766d, 0x4976, 0xb9, 0xc1, 0xbb, 0x9b, 0xc4, 0x2c, 0x7b, 0x4d);

	/// <summary/>
	public static readonly Guid SVCID_PNRPCLOUD = new(0xc2239ce6, 0x00c0, 0x4fbf, 0xba, 0xd6, 0x18, 0x13, 0x93, 0x85, 0xa4, 0x9a);

	/// <summary/>
	public static readonly Guid SVCID_PNRPNAME_V1 = new(0xc2239ce5, 0x00c0, 0x4fbf, 0xba, 0xd6, 0x18, 0x13, 0x93, 0x85, 0xa4, 0x9a);

	/// <summary/>
	public static readonly Guid SVCID_PNRPNAME_V2 = new(0xc2239ce7, 0x00c0, 0x4fbf, 0xba, 0xd6, 0x18, 0x13, 0x93, 0x85, 0xa4, 0x9a);

	/// <summary>Specifies the flags to use for the resolve operation.</summary>
	[PInvokeData("pnrpns.h", MSDNShortId = "NS:pnrpns._PNRPINFO_V1")]
	[Flags]
	public enum PNRPINFO_FLAGS
	{
		/// <summary>
		/// Indicates that the saHint member is used. The hint influences how the service location portion of the PNRP ID is generated;
		/// it also influences how names are resolved, and specifies how to select between multiple peer names.
		/// </summary>
		PNRPINFO_HINT = 1
	}

	/// <summary>The <c>PNRPCLOUDINFO</c> structure is pointed to by the <c>lpBlob</c> member of the WSAQUERYSET structure.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/pnrpns/ns-pnrpns-pnrpcloudinfo typedef struct _PNRPCLOUDINFO { DWORD dwSize;
	// PNRP_CLOUD_ID Cloud; PNRP_CLOUD_STATE enCloudState; PNRP_CLOUD_FLAGS enCloudFlags; } PNRPCLOUDINFO, *PPNRPCLOUDINFO;
	[PInvokeData("pnrpns.h", MSDNShortId = "NS:pnrpns._PNRPCLOUDINFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PNRPCLOUDINFO
	{
		/// <summary>Specifies the size of this structure.</summary>
		public uint dwSize;

		/// <summary>Specifies the network cloud information stored in a PNRP_CLOUD_ID structure.</summary>
		public PNRP_CLOUD_ID Cloud;

		/// <summary>Specifies the state of the network cloud. Valid values are specified by PNRP_CLOUD_STATE.</summary>
		public PNRP_CLOUD_STATE enCloudState;

		/// <summary>
		/// Indicates if the cloud name is valid on the network or only valid on the current computer. Valid values are specified by PNRP_CLOUD_FLAGS.
		/// </summary>
		public PNRP_CLOUD_FLAGS enCloudFlags;
	}

	/// <summary>The <c>PNRPINFO_V1</c> structure is pointed to by the <c>lpBlob</c> member of the WSAQUERYSET structure.</summary>
	/// <remarks>Starting with Windows Vista, please use the PNRPINFO_V2 structure.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pnrpns/ns-pnrpns-pnrpinfo_v1 typedef struct _PNRPINFO_V1 { DWORD dwSize;
	// StrPtrUni lpwszIdentity; DWORD nMaxResolve; DWORD dwTimeout; DWORD dwLifetime; PNRP_RESOLVE_CRITERIA enResolveCriteria; DWORD
	// dwFlags; SOCKET_ADDRESS saHint; PNRP_REGISTERED_ID_STATE enNameState; } PNRPINFO_V1, *PPNRPINFO_V1;
	[PInvokeData("pnrpns.h", MSDNShortId = "NS:pnrpns._PNRPINFO_V1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PNRPINFO_V1
	{
		/// <summary>Specifies the size of this structure.</summary>
		public uint dwSize;

		/// <summary>Points to the Unicode string that contains the identity.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpwszIdentity;

		/// <summary>Specifies the requested number of resolutions.</summary>
		public uint nMaxResolve;

		/// <summary>Specifies the time, in seconds, to wait for a response.</summary>
		public uint dwTimeout;

		/// <summary>Specifies the number of seconds between refresh operations. Must be 86400 (24 * 60 * 60 seconds).</summary>
		public uint dwLifetime;

		/// <summary>
		/// Specifies the criteria used to resolve matches. PNRP can look for the first matching name, or attempt to find a name that is
		/// numerically close to the service location. Valid values are specified by PNRP_RESOLVE_CRITERIA.
		/// </summary>
		public PNRP_RESOLVE_CRITERIA enResolveCriteria;

		/// <summary>
		/// <para>Specifies the flags to use for the resolve operation. The valid value is:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PNRPINFO_HINT</term>
		/// <term>
		/// Indicates that the saHint member is used. The hint influences how the service location portion of the PNRP ID is generated;
		/// it also influences how names are resolved, and specifies how to select between multiple peer names.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public PNRPINFO_FLAGS dwFlags;

		/// <summary>Specifies the IPv6 address to use for the location. The <c>dwFlags</c> member must be PNRPINFO_HINT.</summary>
		public Ws2_32.SOCKET_ADDRESS saHint;

		/// <summary>Specifies the state of the registered ID. This value is reserved and must be set to zero (0).</summary>
		public PNRP_REGISTERED_ID_STATE enNameState;
	}

	/// <summary>The <c>PNRPINFO_V1</c> structure is pointed to by the <c>lpBlob</c> member of the WSAQUERYSET structure.</summary>
	/// <remarks>Starting with Windows Vista, please use the PNRPINFO_V2 structure.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/pnrpns/ns-pnrpns-pnrpinfo_v2 typedef struct _PNRPINFO_V2 { DWORD dwSize;
	// StrPtrUni lpwszIdentity; DWORD nMaxResolve; DWORD dwTimeout; DWORD dwLifetime; PNRP_RESOLVE_CRITERIA enResolveCriteria; DWORD
	// dwFlags; SOCKET_ADDRESS saHint; PNRP_REGISTERED_ID_STATE enNameState; PNRP_EXTENDED_PAYLOAD_TYPE enExtendedPayloadType; union {
	// BLOB blobPayload; StrPtrUni pwszPayload; }; } PNRPINFO_V2, *PPNRPINFO_V2;
	[PInvokeData("pnrpns.h", MSDNShortId = "NS:pnrpns._PNRPINFO_V2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PNRPINFO_V2
	{
		/// <summary>Specifies the size of this structure.</summary>
		public uint dwSize;

		/// <summary>Points to the Unicode string that contains the identity.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpwszIdentity;

		/// <summary>Specifies the requested number of resolutions.</summary>
		public uint nMaxResolve;

		/// <summary>Specifies the time, in seconds, to wait for a response.</summary>
		public uint dwTimeout;

		/// <summary>Specifies the number of seconds between refresh operations. Must be 86400 (24 * 60 * 60 seconds).</summary>
		public uint dwLifetime;

		/// <summary>
		/// Specifies the criteria used to resolve matches. PNRP can look for the first matching name, or attempt to find a name that is
		/// numerically close to the service location. Valid values are specified by PNRP_RESOLVE_CRITERIA.
		/// </summary>
		public PNRP_RESOLVE_CRITERIA enResolveCriteria;

		/// <summary>
		/// <para>Specifies the flags to use for the resolve operation. The valid value is:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PNRPINFO_HINT</term>
		/// <term>
		/// Indicates that the saHint member is used. The hint influences how the service location portion of the PNRP ID is generated;
		/// it also influences how names are resolved, and specifies how to select between multiple peer names.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public PNRPINFO_FLAGS dwFlags;

		/// <summary>Specifies the IPv6 address to use for the location. The <c>dwFlags</c> member must be PNRPINFO_HINT.</summary>
		public Ws2_32.SOCKET_ADDRESS saHint;

		/// <summary>Specifies the state of the registered ID. This value is reserved and must be set to zero (0).</summary>
		public PNRP_REGISTERED_ID_STATE enNameState;

		/// <summary/>
		public PNRP_EXTENDED_PAYLOAD_TYPE enExtendedPayloadType;

		private UNION union;

		/// <summary/>
		public Ws2_32.BLOB blobPayload { get => union.blob; set => union.blob = value; }

		/// <summary/>
		public StrPtrUni pwszPayload { get => union.str; set => union.str = value; }

		[StructLayout(LayoutKind.Explicit)]
		private struct UNION
		{
			[FieldOffset(0)] public Ws2_32.BLOB blob;
			[FieldOffset(0)] public StrPtrUni str;
		}
	}
}