namespace Vanara.PInvoke;

public static partial class Hid
{
	/// <summary>Indicates the parsing error, if it’s not HIDP_GETCOLDESC_SUCCESS.</summary>
	[PInvokeData("hidpddi.h")]
	public enum HIDP_GETCOLDESC_RESULT : uint
	{
		/// <summary>No error.</summary>
		HIDP_GETCOLDESC_SUCCESS = 0x00,

		/// <summary>Insufficient resources to allocate needed memory.</summary>
		HIDP_GETCOLDESC_RESOURCES = 0x01,

		/// <summary>End of report descriptor found when more data was expected.</summary>
		HIDP_GETCOLDESC_BUFFER = 0x02,

		/// <summary>Link collection found with no corresponding end collection.</summary>
		HIDP_GETCOLDESC_LINK_RESOURCES = 0x03,

		/// <summary>An extra end collection token was found.</summary>
		HIDP_GETCOLDESC_UNEXP_END_COL = 0x04,

		/// <summary>Insufficient resources to allocate memory for preparsing.</summary>
		HIDP_GETCOLDESC_PREPARSE_RESOURCES = 0x05,

		/// <summary>One more byte was expected but not found.</summary>
		HIDP_GETCOLDESC_ONE_BYTE = 0x06,

		/// <summary>Two more bytes were expected but not found.</summary>
		HIDP_GETCOLDESC_TWO_BYTE = 0x07,

		/// <summary>One two and four more byte were expected but not found.</summary>
		HIDP_GETCOLDESC_FOUR_BYTE = 0x08,

		/// <summary>
		/// A given report was not byte aligned Args[0] -- Collection number of the offending collection Args[1] -- Report ID of offending
		/// report Args[2] -- Length (in bits) of the Input report for this ID Args[3] -- Length (in bits) of the Output report for this ID
		/// Args[4] -- Length (in bits) of the Feature report for this ID
		/// </summary>
		HIDP_GETCOLDESC_BYTE_ALLIGN = 0x0,

		/// <summary>
		/// A non constant main item was declaired without a corresponding usage. Only constant main items (used as padding) are allowed with
		/// no usage
		/// </summary>
		HIDP_GETCOLDESC_MAIN_ITEM_NO_USAGE = 0x0A,

		/// <summary>
		/// A top level collection (Arg[0]) was declared without a usage or with more than one usage Args[0] -- Collection number of the
		/// offending collection
		/// </summary>
		HIDP_GETCOLDESC_TOP_COLLECTION_USAGE = 0x0B,

		/// <summary>Insufficient resources required to push more items to either the global items stack or the usage stack</summary>
		HIDP_GETCOLDESC_PUSH_RESOURCES = 0x10,

		/// <summary>An unknown item was found in the report descriptor Args[0] -- The item value of the unknown item</summary>
		HIDP_GETCOLDESC_ITEM_UNKNOWN = 0x12,

		/// <summary>
		/// Report ID declaration found outside of top level collection. Report ID's must be defined within the context of a top level
		/// collection Args[0] -- Report ID of the offending report
		/// </summary>
		HIDP_GETCOLDESC_REPORT_ID = 0x13,

		/// <summary>A bad report ID value was found...Report IDs must be within the range of 1-255</summary>
		HIDP_GETCOLDESC_BAD_REPORT_ID = 0x14,

		/// <summary>
		/// The parser discovered a top level collection in a complex device (more than one top level collection) that had no declared report
		/// ID or a report ID spanned multiple collections Args[0] -- Collection number of the offending collection
		/// </summary>
		HIDP_GETCOLDESC_NO_REPORT_ID = 0x15,

		/// <summary>
		/// The parser detected a condition where a main item was declared without a global report ID so the default report ID was used.
		/// After this main item declaration, the parser detected either another main item that had an explicitly defined report ID or it
		/// detected a second top-level collection The default report ID is only allowed for devices with one top-level collection and don't
		/// have any report IDs explicitly declared.
		/// </summary>
		HIDP_GETCOLDESC_DEFAULT_ID_ERROR = 0x16,

		/// <summary>No top level collections were found in this device.</summary>
		HIDP_GETCOLDESC_NO_DATA = 0x1A,

		/// <summary>A main item was detected outside of a top level collection.</summary>
		HIDP_GETCOLDESC_INVALID_MAIN_ITEM = 0x1B,

		/// <summary>A start delimiter token was found with no corresponding end delimiter</summary>
		HIDP_GETCOLDESC_NO_CLOSE_DELIMITER = 0x20,

		/// <summary>The parser detected a non-usage item with a delimiter declaration Args[0] -- item code for the offending item</summary>
		HIDP_GETCOLDESC_NOT_VALID_DELIMITER = 0x21,

		/// <summary>The parser detected either a close delimiter without a corresponding open delimiter or detected a nested open delimiter</summary>
		HIDP_GETCOLDESC_MISMATCH_OC_DELIMITER = 0x22,

		/// <summary>
		/// The prepared data length returned is truncated from ULONG to USHORT. This error doesn't cause the device to fail to start.
		/// HIDPARSE uses this code to pass the information to HIDCLASS for telemetry purpose.
		/// </summary>
		HIDP_GETCOLDESC_PREPARED_DATA_LENGTH_TRUNCATED = 0x23,

		/// <summary>
		/// The given report descriptor was found to have a valid report descriptor containing a scenario that this parser does not support.
		/// For instance, declaring an ARRAY style main item with delimiters.
		/// </summary>
		HIDP_GETCOLDESC_UNSUPPORTED = 0x40,
	}

	/// <summary>
	/// This function frees the resources in DeviceDescription that were allocated by HidP_GetCollectionDescription.It does not, however,
	/// free the the DeviceDescription block itself.
	/// </summary>
	/// <param name="DeviceDescription">HIDP_DEVICE_DESC block that was previously filled in by a call to HidP_GetCollectionDescription.</param>
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("hidpddi.h")]
	public static extern void HidP_FreeCollectionDescription([In, Out] StructPointer<HIDP_DEVICE_DESC> DeviceDescription);

	/// <summary>
	/// Fills a device description block with collection description and the corresponding report ID information for the specified report
	/// descriptor. A HID minidriver generally does not need to call this function. Instead, it returns the report descriptor to Hidclass
	/// driver in response to <c>IOCTL_HID_GET_REPORT_DESCRIPTOR</c>.
	/// </summary>
	/// <param name="ReportDesc">A pointer to a UCHAR array that contains the raw report descriptor.</param>
	/// <param name="DescLength">The length of the report descriptor array.</param>
	/// <param name="PoolType">
	/// A <c>POOL_TYPE</c>-value that indicates the pool type from which memory for the linked list is allocated. This includes each
	/// <c>HIDP_COLLECTION_DESC</c> array element of <c>HIDP_DEVICE_DESC</c>, each <c>HIDP_PREPARSED_DATA</c> in each
	/// <b>HIDP_COLLECTION_DESC</b>, each <c>HIDP_REPORT_IDS</c> array element of <b>HIDP_DEVICE_DESC</b>.
	/// </param>
	/// <param name="DeviceDescription">
	/// A pointer to a <c>HIDP_DEVICE_DESC</c> structure that is populated with device description block filled in collection descriptors as
	/// linked lists. This is a caller-allocated structure. However, its <c>HIDP_COLLECTION_DESC</c> array elements and
	/// <c>HIDP_REPORT_IDS</c> array elements are allocated by this function.
	/// </param>
	/// <returns>
	/// <para>
	/// <b>HidP_GetCollectionDescription</b> can return one of these values: <b>TRUE</b> if it successfully fills the device description
	/// block. Otherwise, it returns <b>FALSE</b>.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return value</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description>STATUS_SUCCESS</description>
	/// <description>Successfully parsed the report descriptor and allocated the memory blocks necessary to describe the device.</description>
	/// </item>
	/// <item>
	/// <description>STATUS_NO_DATA_DETECTED</description>
	/// <description>Failed to find top-level collections in the report descriptor.</description>
	/// </item>
	/// <item>
	/// <description>STATUS_COULD_NOT_INTERPRET</description>
	/// <description>
	/// An error was detected in the report descriptor. See the error code in <b>Dbg</b> field of the <c>HIDP_DEVICE_DESC</c> structure.
	/// </description>
	/// </item>
	/// <item>
	/// <description>STATUS_BUFFER_TOO_SMALL</description>
	/// <description>Found the end of the report descriptor when it expected more data.</description>
	/// </item>
	/// <item>
	/// <description>STATUS_INSUFFICIENT_RESOURCES</description>
	/// <description>Failed to allocate memory.</description>
	/// </item>
	/// <item>
	/// <description>STATUS_ILLEGAL_INSTRUCTION</description>
	/// <description>Failed to parse an item in the report descriptor.</description>
	/// </item>
	/// <item>
	/// <description>HIDP_STATUS_INVALID_REPORT_TYPE</description>
	/// <description>Report ID of 0 was found in the descriptor.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// For a raw report descriptor that is specified by the <i>ReportDesc</i> parameter, <i>HidP_GetCollectionDescription</i> fills in the
	/// <i>DeviceDescription</i> block with a caller-allocated linked list of collection descriptors and the corresponding Report ID
	/// information that is described by the given report descriptor. The memory for the collection information and the ReportID information
	/// is allocated based on the <i>PoolType</i> value.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpddi/nf-hidpddi-hidp_getcollectiondescription NTSTATUS
	// HidP_GetCollectionDescription( [in] PHIDP_REPORT_DESCRIPTOR ReportDesc, [in] ULONG DescLength, [in] POOL_TYPE PoolType, [out]
	// PHIDP_DEVICE_DESC DeviceDescription );
	[PInvokeData("hidpddi.h", MSDNShortId = "NF:hidpddi.HidP_GetCollectionDescription")]
	[DllImport(Lib_Hid, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus HidP_GetCollectionDescription([In] PHIDP_REPORT_DESCRIPTOR ReportDesc, uint DescLength, [In] POOL_TYPE PoolType, [Out] StructPointer<HIDP_DEVICE_DESC> DeviceDescription);

	/// <summary>
	/// Contains the information of a top-level-collection. This structure is used in the <c>HidP_GetCollectionDescription</c> call.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpddi/ns-hidpddi-_hidp_collection_desc typedef struct
	// _HIDP_COLLECTION_DESC { USAGE UsagePage; USAGE Usage; UCHAR CollectionNumber; UCHAR Reserved[15]; USHORT InputLength; USHORT
	// OutputLength; USHORT FeatureLength; USHORT PreparsedDataLength; PHIDP_PREPARSED_DATA PreparsedData; } HIDP_COLLECTION_DESC, *PHIDP_COLLECTION_DESC;
	[PInvokeData("hidpddi.h", MSDNShortId = "NS:hidpddi._HIDP_COLLECTION_DESC")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HIDP_COLLECTION_DESC
	{
		/// <summary>Specifies the usage page of the usage ID specified by <b>Usage</b>.</summary>
		public USAGE UsagePage;

		/// <summary>Indicates a usage ID.</summary>
		public USAGE Usage;

		/// <summary>The index of the collection in the array of <b>HIDP_COLLECTION_DESC</b> structure. This is a 1-based value.</summary>
		public byte CollectionNumber;

		/// <summary>Reserved for internal system use. Must be 0.</summary>
		public unsafe fixed byte Reserved[15];

		/// <summary>The maximum length of an input report of this collection.</summary>
		public ushort InputLength;

		/// <summary>The maximum length of an output report of this collection.</summary>
		public ushort OutputLength;

		/// <summary>The maximum length of a feature report of this collection.</summary>
		public ushort FeatureLength;

		/// <summary>The length of the preparsed data pointed to by <i>PreparsedData</i>.</summary>
		public ushort PreparsedDataLength;

		/// <summary>A pointer to a <c>_HIDP_PREPARSED_DATA</c> structure that contains a top-level collection's preparsed data.</summary>
		public PHIDP_PREPARSED_DATA PreparsedData;
	}

	/// <summary>Contains the device description block filled in collection descriptions as linked lists. This structure is used by <c>HidP_GetCollectionDescription</c>.</summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpddi/ns-hidpddi-_hidp_device_desc typedef struct _HIDP_DEVICE_DESC {
	// PHIDP_COLLECTION_DESC CollectionDesc; ULONG CollectionDescLength; PHIDP_REPORT_IDS ReportIDs; ULONG ReportIDsLength;
	// HIDP_GETCOLDESC_DBG Dbg; } HIDP_DEVICE_DESC, *PHIDP_DEVICE_DESC;
	[PInvokeData("hidpddi.h", MSDNShortId = "NS:hidpddi._HIDP_DEVICE_DESC")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HIDP_DEVICE_DESC
	{
		/// <summary>An array of <c>HIDP_COLLECTION_DESC</c> structure that contains the collection descriptors.</summary>
		public ArrayPointer<HIDP_COLLECTION_DESC> CollectionDesc;

		/// <summary>The number of elements in the array of the collection descriptors.</summary>
		public uint CollectionDescLength;

		/// <summary>An array of <c>HIDP_REPORT_IDS</c> structures report ID information for a report descriptor.</summary>
		public ArrayPointer<HIDP_REPORT_IDS> ReportIDs;

		/// <summary>The number of elements in the length of the array of report IDs.</summary>
		public uint ReportIDsLength;

		/// <summary>
		/// A <c>HIDP_GETCOLDESC_DBG</c> structure that contains the error code indicating the failure in parsing the report descriptor.
		/// </summary>
		public HIDP_GETCOLDESC_DBG Dbg;
	}

	/// <summary>
	/// Contains the error code indicating the failure in parsing the report descriptor. This structure is used in the
	/// <c>HidP_GetCollectionDescription</c> call.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpddi/ns-hidpddi-_hidp_getcoldesc_dbg typedef struct
	// _HIDP_GETCOLDESC_DBG { ULONG BreakOffset; ULONG ErrorCode; ULONG args[6]; } HIDP_GETCOLDESC_DBG, *PHIDP_GETCOLDESC_DBG;
	[PInvokeData("hidpddi.h", MSDNShortId = "NS:hidpddi._HIDP_GETCOLDESC_DBG")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HIDP_GETCOLDESC_DBG
	{
		/// <summary>The byte offset in the report descriptor where the parsing error occurred.</summary>
		public uint BreakOffset;

		/// <summary>
		/// <para>Indicates the parsing error, if it’s not HIDP_GETCOLDESC_SUCCESS.</para>
		/// <para>All possible values are defined in hidpddi.h, from HIDP_GETCOLDESC_SUCCESS to the end of the file.</para>
		/// </summary>
		public HIDP_GETCOLDESC_RESULT ErrorCode;

		private unsafe fixed uint _args[6];

		/// <summary>Error-specific arguments. These are described as comments in the possible values for <b>ErrorCode</b> in hidpddi.h.</summary>
		private uint[] args
		{
			get { unsafe { fixed (uint* p = _args) return new ReadOnlySpan<uint>(p, 6).ToArray(); } }
			set { if (value.Length != 6) throw new ArgumentException("Array length must be 6.", nameof(args)); unsafe { fixed (uint* p = _args) for (int i = 0; i < 6 && i < value.Length; i++) p[i] = value[i]; } }
		}
	}

	/// <summary>Contains report ID information for a top-level collection.</summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/hidpddi/ns-hidpddi-_hidp_report_ids typedef struct _HIDP_REPORT_IDS {
	// UCHAR ReportID; UCHAR CollectionNumber; USHORT InputLength; USHORT OutputLength; USHORT FeatureLength; } HIDP_REPORT_IDS, *PHIDP_REPORT_IDS;
	[PInvokeData("hidpddi.h", MSDNShortId = "NS:hidpddi._HIDP_REPORT_IDS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HIDP_REPORT_IDS
	{
		/// <summary>The report ID of the top-level collection.</summary>
		public byte ReportID;

		/// <summary>The index of the collection in the array of <c>HIDP_COLLECTION_DESC</c> structure.</summary>
		public byte CollectionNumber;

		/// <summary>The length of an input report of this report ID.</summary>
		public ushort InputLength;

		/// <summary>
		/// The length of an output report of this report ID. An input report, an output report, and a feature report can use the same report.
		/// </summary>
		public ushort OutputLength;

		/// <summary>The length of a feature report of this report ID.</summary>
		public ushort FeatureLength;
	}
}