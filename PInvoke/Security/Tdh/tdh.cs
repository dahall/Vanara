#nullable enable
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke;

/// <summary>Methods and structures from tdh.dll.</summary>
public static partial class Tdh
{
	private const string Lib_Tdh = "tdh.dll";

	private delegate Win32Error GetD(IntPtr p, ref uint sz);

	/// <summary>Defines the source of the event data.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/ne-tdh-decoding_source typedef enum _DECODING_SOURCE { DecodingSourceXMLFile,
	// DecodingSourceWbem, DecodingSourceWPP, DecodingSourceTlg, DecodingSourceMax } DECODING_SOURCE;
	[PInvokeData("tdh.h", MSDNShortId = "NE:tdh._DECODING_SOURCE")]
	public enum DECODING_SOURCE
	{
		/// <summary>The source of the event data is a XML manifest.</summary>
		DecodingSourceXMLFile,

		/// <summary>The source of the event data is a WMI MOF class.</summary>
		DecodingSourceWbem,

		/// <summary>The source of the event data is a TMF file.</summary>
		DecodingSourceWPP,

		/// <summary>Indicates that the event was a self-describing event and was decoded using TraceLogging metadata.</summary>
		DecodingSourceTlg,
	}

	/// <summary>Defines the provider information to retrieve.</summary>
	/// <remarks>
	/// <para>
	/// If you specify <c>EventOpcodeInformation</c> when calling TdhQueryProviderFieldInformation, you must specify the
	/// <c>EventFieldValue</c> parameter as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Bits 0 - 15 must contain the task value</term>
	/// </item>
	/// <item>
	/// <term>Bits 16 - 23 must contain the opcode value</term>
	/// </item>
	/// </list>
	/// <para>You can get the task and opcode values from EVENT_RECORD.EventHeader.EventDescriptor.</para>
	/// <para>WMI MOF class supports retrieving keyword and level information only.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/ne-tdh-event_field_type typedef enum _EVENT_FIELD_TYPE {
	// EventKeywordInformation = 0, EventLevelInformation, EventChannelInformation, EventTaskInformation, EventOpcodeInformation,
	// EventInformationMax } EVENT_FIELD_TYPE;
	[PInvokeData("tdh.h", MSDNShortId = "NE:tdh._EVENT_FIELD_TYPE")]
	public enum EVENT_FIELD_TYPE
	{
		/// <summary>
		/// <para>Value: 0</para>
		/// <para>
		/// Keyword information defined in the manifest. For providers that define themselves using MOF classes, this type returns the enable
		/// flags values if the provider class includes the Flags property. For details, see the "Specifying level and enable flags values
		/// for a provider" section of Event Tracing MOF Qualifiers.
		/// </para>
		/// </summary>
		EventKeywordInformation,

		/// <summary>Level information defined in the manifest.</summary>
		EventLevelInformation,

		/// <summary>Channel information defined in the manifest.</summary>
		EventChannelInformation,

		/// <summary>Task information defined in the manifest.</summary>
		EventTaskInformation,

		/// <summary>Operation code information defined in the manifest.</summary>
		EventOpcodeInformation,
	}

	/// <summary>Defines constant values that indicate if the map is a value map, bitmap, or pattern map.</summary>
	/// <remarks>The following MOF example shows the flags that are set based on the WMI property attributes used.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ne-tdh-map_flags typedef enum _MAP_FLAGS {
	// EVENTMAP_INFO_FLAG_MANIFEST_VALUEMAP, EVENTMAP_INFO_FLAG_MANIFEST_BITMAP, EVENTMAP_INFO_FLAG_MANIFEST_PATTERNMAP,
	// EVENTMAP_INFO_FLAG_WBEM_VALUEMAP, EVENTMAP_INFO_FLAG_WBEM_BITMAP, EVENTMAP_INFO_FLAG_WBEM_FLAG, EVENTMAP_INFO_FLAG_WBEM_NO_MAP } MAP_FLAGS;
	[PInvokeData("tdh.h", MSDNShortId = "3fc6935a-328a-4df3-8c2f-cd634d94ca16")]
	public enum MAP_FLAGS
	{
		/// <summary>The manifest value map maps integer values to strings. For details, see the MapType complex type.</summary>
		EVENTMAP_INFO_FLAG_MANIFEST_VALUEMAP,

		/// <summary>The manifest value map maps bit values to strings. For details, see the MapType complex type.</summary>
		EVENTMAP_INFO_FLAG_MANIFEST_BITMAP,

		/// <summary>
		/// The manifest value map uses regular expressions to map one name to another name. For details, see the PatternMapType complex type.
		/// </summary>
		EVENTMAP_INFO_FLAG_MANIFEST_PATTERNMAP,

		/// <summary>The WMI value map maps integer values to strings. For details, see ValueMap and Value Qualifiers.</summary>
		EVENTMAP_INFO_FLAG_WBEM_VALUEMAP,

		/// <summary>The WMI value map maps bit values to strings. For details, see BitMap and BitValue Qualifiers.</summary>
		EVENTMAP_INFO_FLAG_WBEM_BITMAP,

		/// <summary>
		/// This flag can be combined with the EVENTMAP_INFO_FLAG_WBEM_VALUEMAP flag to indicate that the ValueMap qualifier contains bit
		/// (flag) values instead of index values.
		/// </summary>
		EVENTMAP_INFO_FLAG_WBEM_FLAG,

		/// <summary>
		/// This flag can be combined with the EVENTMAP_INFO_FLAG_WBEM_VALUEMAP or EVENTMAP_INFO_FLAG_WBEM_BITMAP flag to indicate that the
		/// MOF class property contains a BitValues or Values qualifier but does not contain the BitMap or ValueMap qualifier.
		/// </summary>
		EVENTMAP_INFO_FLAG_WBEM_NO_MAP,
	}

	/// <summary>Defines if the value map value is in a ULONG data type or a string.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ne-tdh-map_valuetype typedef enum _MAP_VALUETYPE {
	// EVENTMAP_ENTRY_VALUETYPE_ULONG, EVENTMAP_ENTRY_VALUETYPE_STRING } MAP_VALUETYPE;
	[PInvokeData("tdh.h", MSDNShortId = "a17e5214-29d3-465f-9785-0cc8965a42c9")]
	public enum MAP_VALUETYPE
	{
		/// <summary>Use the Value member of EVENT_MAP_ENTRY to access the map value.</summary>
		EVENTMAP_ENTRY_VALUETYPE_ULONG,

		/// <summary>Use the InputOffset member of EVENT_MAP_ENTRY to access the map value.</summary>
		EVENTMAP_ENTRY_VALUETYPE_STRING,
	}

	/// <summary>Defines the supported payload operators for a trace data helper (TDH).</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/ne-tdh-payload_operator typedef enum _PAYLOAD_OPERATOR { PAYLOADFIELD_EQ,
	// PAYLOADFIELD_NE, PAYLOADFIELD_LE, PAYLOADFIELD_GT, PAYLOADFIELD_LT, PAYLOADFIELD_GE, PAYLOADFIELD_BETWEEN, PAYLOADFIELD_NOTBETWEEN,
	// PAYLOADFIELD_MODULO, PAYLOADFIELD_CONTAINS, PAYLOADFIELD_DOESNTCONTAIN, PAYLOADFIELD_IS, PAYLOADFIELD_ISNOT, PAYLOADFIELD_INVALID } PAYLOAD_OPERATOR;
	[PInvokeData("tdh.h", MSDNShortId = "NE:tdh._PAYLOAD_OPERATOR")]
	public enum PAYLOAD_OPERATOR
	{
		/// <summary/>
		PAYLOADFIELD_EQ = 0,

		/// <summary/>
		PAYLOADFIELD_NE,

		/// <summary/>
		PAYLOADFIELD_LE,

		/// <summary/>
		PAYLOADFIELD_GT,

		/// <summary/>
		PAYLOADFIELD_LT,

		/// <summary/>
		PAYLOADFIELD_GE,

		/// <summary/>
		PAYLOADFIELD_BETWEEN,

		/// <summary/>
		PAYLOADFIELD_NOTBETWEEN,

		/// <summary/>
		PAYLOADFIELD_MODULO,

		/// <summary/>
		PAYLOADFIELD_CONTAINS = 20,

		/// <summary/>
		PAYLOADFIELD_DOESNTCONTAIN,

		/// <summary/>
		PAYLOADFIELD_IS = 30,

		/// <summary/>
		PAYLOADFIELD_ISNOT,

		/// <summary/>
		PAYLOADFIELD_INVALID,
	}

	/// <summary>Defines if the property is contained in a structure or array.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ne-tdh-property_flags typedef enum _PROPERTY_FLAGS { PropertyStruct,
	// PropertyParamLength, PropertyParamCount, PropertyWBEMXmlFragment, PropertyParamFixedLength, PropertyParamFixedCount, PropertyHasTags,
	// PropertyHasCustomSchema } PROPERTY_FLAGS;
	[PInvokeData("tdh.h", MSDNShortId = "517c1662-4230-44dc-94f0-a1996291bbee")]
	[Flags]
	public enum PROPERTY_FLAGS : uint
	{
		/// <summary>The property information is contained in the structType member of the EVENT_PROPERTY_INFO structure.</summary>
		PropertyStruct = 0x1,

		/// <summary>
		/// Use the lengthPropertyIndex member of the EVENT_PROPERTY_INFO structure to locate the property that contains the length value of
		/// the property.
		/// </summary>
		PropertyParamLength = 0x2,

		/// <summary>
		/// Use the countPropertyIndex member of the EVENT_PROPERTY_INFO structure to locate the property that contains the size of the array.
		/// </summary>
		PropertyParamCount = 0x4,

		/// <summary>
		/// Indicates that the MOF data is in XML format (the event data contains within itself a fully-rendered XML description). This flag
		/// is set if the MOF property contains the XMLFragment qualifier.
		/// </summary>
		PropertyWBEMXmlFragment = 0x8,

		/// <summary>
		/// Indicates that the length member of the EVENT_PROPERTY_INFO structure contains a fixed length, e.g. as specified in the provider
		/// manifest with &lt;data length="12" … /&gt;. This flag will not be set for a variable-length field, e.g. &lt;data
		/// length="LengthField" … /&gt;, nor will this flag be set for fields where the length is not specified in the manifest, e.g. int32
		/// or null-terminated string. As an example, if PropertyParamLength is unset, length is 0, and InType is TDH_INTYPE_UNICODESTRING,
		/// we must check the PropertyParamFixedLength flag to determine the length of the string. If PropertyParamFixedLength is set, the
		/// string length is fixed at 0. If PropertyParamFixedLength is unset, the string is null-terminated.
		/// </summary>
		PropertyParamFixedLength = 0x10,

		/// <summary>
		/// Indicates that the count member of the EVENT_PROPERTY_INFO structure contains a fixed array count, e.g. as specified in the
		/// provider manifest with &lt;data count="12" … /&gt;. This flag will not be set for a variable-length array, e.g. &lt;data
		/// count="ArrayCount" … /&gt;, nor will this flag be set for non-array fields. As an example, if PropertyParamCount is unset and
		/// count is 1, PropertyParamFixedCount flag must be checked to determine whether the field is a scalar value or a single-element
		/// array. If PropertyParamFixedCount is set, the field is a single-element array. If PropertyParamFixedCount is unset, the field is
		/// a scalar value, not an array.
		/// </summary>
		PropertyParamFixedCount = 0x20,

		/// <summary>Indicates that the Tags field contains valid field tag data.</summary>
		PropertyHasTags = 0x40,

		/// <summary>Indicates that the Type is described with a custom schema.</summary>
		PropertyHasCustomSchema = 0x80,
	}

	/// <summary>Defines the context type.</summary>
	/// <remarks>
	/// If you are specifying context information for a legacy ETW event, you only need to specify the TDH_CONTEXT_POINTERSIZE type—the other
	/// types are used for WPP events and are ignored for legacy ETW events.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ne-tdh-tdh_context_type typedef enum _TDH_CONTEXT_TYPE {
	// TDH_CONTEXT_WPP_TMFFILE, TDH_CONTEXT_WPP_TMFSEARCHPATH, TDH_CONTEXT_WPP_GMT, TDH_CONTEXT_POINTERSIZE, TDH_CONTEXT_PDB_PATH,
	// TDH_CONTEXT_MAXIMUM } TDH_CONTEXT_TYPE;
	[PInvokeData("tdh.h", MSDNShortId = "7892f0d2-84f6-4543-b94e-8501e3911266")]
	public enum TDH_CONTEXT_TYPE
	{
		/// <summary>
		/// Null-terminated Unicode string that contains the name of the .tmf file used for parsing the WPP log. Typically, the .tmf file
		/// name is picked up from the event GUID so you do not have to specify the file name.
		/// </summary>
		TDH_CONTEXT_WPP_TMFFILE,

		/// <summary>
		/// Null-terminated Unicode string that contains the path to the .tmf file. You do not have to specify this path if the search path
		/// contains the file. Only specify this context information if you also specify the TDH_CONTEXT_WPP_TMFFILE context type. If the
		/// file is not found, TDH searches the following locations in the given order:
		/// </summary>
		TDH_CONTEXT_WPP_TMFSEARCHPATH,

		/// <summary>
		/// A 1-byte Boolean flag that indicates if the WPP event time stamp should be converted to Universal Time Coordinate (UTC). If 1,
		/// the time stamp is converted to UTC. If 0, the time stamp is in local time. By default, the time stamp is in local time.
		/// </summary>
		TDH_CONTEXT_WPP_GMT,

		/// <summary>
		/// Size, in bytes, of the pointer data types or size_t data types used in the event. Indicates if the event used 4-byte or 8-byte
		/// values. By default, the pointer size is the pointer size of the decoding computer. To determine the size of the pointer or size_t
		/// value, use the PointerSize member of TRACE_LOGFILE_HEADER (the first event you receive in your EventRecordCallback callback
		/// contains this header in the data section). However, this value may not be accurate. For example, on a 64-bit computer, a 32-bit
		/// application will log 4-byte pointers; however, the session will set PointerSize to 8.
		/// </summary>
		TDH_CONTEXT_POINTERSIZE,

		/// <summary>
		/// Null-terminated Unicode string that contains the name of the .pdb file for the binary that contains WPP messages. This parameter
		/// can be used as an alternative to TDH_CONTEXT_WPP_TMFFILE or TDH_CONTEXT_WPP_TMFSEARCHPATH.
		/// </summary>
		TDH_CONTEXT_PDB_PATH,
	}

	/// <summary>Defines the supported [in] types for a trace data helper (TDH).</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/ne-tdh-_tdh_in_type typedef enum _TDH_IN_TYPE { TDH_INTYPE_NULL,
	// TDH_INTYPE_UNICODESTRING, TDH_INTYPE_ANSISTRING, TDH_INTYPE_INT8, TDH_INTYPE_UINT8, TDH_INTYPE_INT16, TDH_INTYPE_UINT16,
	// TDH_INTYPE_INT32, TDH_INTYPE_UINT32, TDH_INTYPE_INT64, TDH_INTYPE_UINT64, TDH_INTYPE_FLOAT, TDH_INTYPE_DOUBLE, TDH_INTYPE_BOOLEAN,
	// TDH_INTYPE_BINARY, TDH_INTYPE_GUID, TDH_INTYPE_POINTER, TDH_INTYPE_FILETIME, TDH_INTYPE_SYSTEMTIME, TDH_INTYPE_SID,
	// TDH_INTYPE_HEXINT32, TDH_INTYPE_HEXINT64, TDH_INTYPE_MANIFEST_COUNTEDSTRING, TDH_INTYPE_MANIFEST_COUNTEDANSISTRING,
	// TDH_INTYPE_RESERVED24, TDH_INTYPE_MANIFEST_COUNTEDBINARY, TDH_INTYPE_COUNTEDSTRING, TDH_INTYPE_COUNTEDANSISTRING,
	// TDH_INTYPE_REVERSEDCOUNTEDSTRING, TDH_INTYPE_REVERSEDCOUNTEDANSISTRING, TDH_INTYPE_NONNULLTERMINATEDSTRING,
	// TDH_INTYPE_NONNULLTERMINATEDANSISTRING, TDH_INTYPE_UNICODECHAR, TDH_INTYPE_ANSICHAR, TDH_INTYPE_SIZET, TDH_INTYPE_HEXDUMP,
	// TDH_INTYPE_WBEMSID } ;
	[PInvokeData("tdh.h", MSDNShortId = "NE:tdh._TDH_IN_TYPE")]
	public enum TDH_IN_TYPE : ushort
	{
		/// <summary/>
		TDH_INTYPE_NULL,

		/// <summary/>
		TDH_INTYPE_UNICODESTRING,

		/// <summary/>
		TDH_INTYPE_ANSISTRING,

		/// <summary/>
		TDH_INTYPE_INT8,

		/// <summary/>
		TDH_INTYPE_UINT8,

		/// <summary/>
		TDH_INTYPE_INT16,

		/// <summary/>
		TDH_INTYPE_UINT16,

		/// <summary/>
		TDH_INTYPE_INT32,

		/// <summary/>
		TDH_INTYPE_UINT32,

		/// <summary/>
		TDH_INTYPE_INT64,

		/// <summary/>
		TDH_INTYPE_UINT64,

		/// <summary/>
		TDH_INTYPE_FLOAT,

		/// <summary/>
		TDH_INTYPE_DOUBLE,

		/// <summary/>
		TDH_INTYPE_BOOLEAN,

		/// <summary/>
		TDH_INTYPE_BINARY,

		/// <summary/>
		TDH_INTYPE_GUID,

		/// <summary/>
		TDH_INTYPE_POINTER,

		/// <summary/>
		TDH_INTYPE_FILETIME,

		/// <summary/>
		TDH_INTYPE_SYSTEMTIME,

		/// <summary/>
		TDH_INTYPE_SID,

		/// <summary/>
		TDH_INTYPE_HEXINT32,

		/// <summary/>
		TDH_INTYPE_HEXINT64,

		/// <summary/>
		TDH_INTYPE_MANIFEST_COUNTEDSTRING,

		/// <summary/>
		TDH_INTYPE_MANIFEST_COUNTEDANSISTRING,

		/// <summary/>
		TDH_INTYPE_RESERVED24,

		/// <summary/>
		TDH_INTYPE_MANIFEST_COUNTEDBINARY,

		/// <summary/>
		TDH_INTYPE_COUNTEDSTRING,

		/// <summary/>
		TDH_INTYPE_COUNTEDANSISTRING,

		/// <summary/>
		TDH_INTYPE_REVERSEDCOUNTEDSTRING,

		/// <summary/>
		TDH_INTYPE_REVERSEDCOUNTEDANSISTRING,

		/// <summary/>
		TDH_INTYPE_NONNULLTERMINATEDSTRING,

		/// <summary/>
		TDH_INTYPE_NONNULLTERMINATEDANSISTRING,

		/// <summary/>
		TDH_INTYPE_UNICODECHAR,

		/// <summary/>
		TDH_INTYPE_ANSICHAR,

		/// <summary/>
		TDH_INTYPE_SIZET,

		/// <summary/>
		TDH_INTYPE_HEXDUMP,

		/// <summary/>
		TDH_INTYPE_WBEMSID,
	}

	/// <summary>TDH_IN_TYPE</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/ne-tdh-_tdh_out_type typedef enum _TDH_OUT_TYPE { TDH_OUTTYPE_NULL,
	// TDH_OUTTYPE_STRING, TDH_OUTTYPE_DATETIME, TDH_OUTTYPE_BYTE, TDH_OUTTYPE_UNSIGNEDBYTE, TDH_OUTTYPE_SHORT, TDH_OUTTYPE_UNSIGNEDSHORT,
	// TDH_OUTTYPE_INT, TDH_OUTTYPE_UNSIGNEDINT, TDH_OUTTYPE_LONG, TDH_OUTTYPE_UNSIGNEDLONG, TDH_OUTTYPE_FLOAT, TDH_OUTTYPE_DOUBLE,
	// TDH_OUTTYPE_BOOLEAN, TDH_OUTTYPE_GUID, TDH_OUTTYPE_HEXBINARY, TDH_OUTTYPE_HEXINT8, TDH_OUTTYPE_HEXINT16, TDH_OUTTYPE_HEXINT32,
	// TDH_OUTTYPE_HEXINT64, TDH_OUTTYPE_PID, TDH_OUTTYPE_TID, TDH_OUTTYPE_PORT, TDH_OUTTYPE_IPV4, TDH_OUTTYPE_IPV6,
	// TDH_OUTTYPE_SOCKETADDRESS, TDH_OUTTYPE_CIMDATETIME, TDH_OUTTYPE_ETWTIME, TDH_OUTTYPE_XML, TDH_OUTTYPE_ERRORCODE,
	// TDH_OUTTYPE_WIN32ERROR, TDH_OUTTYPE_NTSTATUS, TDH_OUTTYPE_HRESULT, TDH_OUTTYPE_CULTURE_INSENSITIVE_DATETIME, TDH_OUTTYPE_JSON,
	// TDH_OUTTYPE_UTF8, TDH_OUTTYPE_PKCS7_WITH_TYPE_INFO, TDH_OUTTYPE_CODE_POINTER, TDH_OUTTYPE_DATETIME_UTC, TDH_OUTTYPE_REDUCEDSTRING,
	// TDH_OUTTYPE_NOPRINT } ;
	[PInvokeData("tdh.h", MSDNShortId = "NE:tdh._TDH_OUT_TYPE")]
	public enum TDH_OUT_TYPE : ushort
	{
		/// <summary/>
		TDH_OUTTYPE_NULL,

		/// <summary/>
		TDH_OUTTYPE_STRING,

		/// <summary/>
		TDH_OUTTYPE_DATETIME,

		/// <summary/>
		TDH_OUTTYPE_BYTE,

		/// <summary/>
		TDH_OUTTYPE_UNSIGNEDBYTE,

		/// <summary/>
		TDH_OUTTYPE_SHORT,

		/// <summary/>
		TDH_OUTTYPE_UNSIGNEDSHORT,

		/// <summary/>
		TDH_OUTTYPE_INT,

		/// <summary/>
		TDH_OUTTYPE_UNSIGNEDINT,

		/// <summary/>
		TDH_OUTTYPE_LONG,

		/// <summary/>
		TDH_OUTTYPE_UNSIGNEDLONG,

		/// <summary/>
		TDH_OUTTYPE_FLOAT,

		/// <summary/>
		TDH_OUTTYPE_DOUBLE,

		/// <summary/>
		TDH_OUTTYPE_BOOLEAN,

		/// <summary/>
		TDH_OUTTYPE_GUID,

		/// <summary/>
		TDH_OUTTYPE_HEXBINARY,

		/// <summary/>
		TDH_OUTTYPE_HEXINT8,

		/// <summary/>
		TDH_OUTTYPE_HEXINT16,

		/// <summary/>
		TDH_OUTTYPE_HEXINT32,

		/// <summary/>
		TDH_OUTTYPE_HEXINT64,

		/// <summary/>
		TDH_OUTTYPE_PID,

		/// <summary/>
		TDH_OUTTYPE_TID,

		/// <summary/>
		TDH_OUTTYPE_PORT,

		/// <summary/>
		TDH_OUTTYPE_IPV4,

		/// <summary/>
		TDH_OUTTYPE_IPV6,

		/// <summary/>
		TDH_OUTTYPE_SOCKETADDRESS,

		/// <summary/>
		TDH_OUTTYPE_CIMDATETIME,

		/// <summary/>
		TDH_OUTTYPE_ETWTIME,

		/// <summary/>
		TDH_OUTTYPE_XML,

		/// <summary/>
		TDH_OUTTYPE_ERRORCODE,

		/// <summary/>
		TDH_OUTTYPE_WIN32ERROR,

		/// <summary/>
		TDH_OUTTYPE_NTSTATUS,

		/// <summary/>
		TDH_OUTTYPE_HRESULT,

		/// <summary/>
		TDH_OUTTYPE_CULTURE_INSENSITIVE_DATETIME,

		/// <summary/>
		TDH_OUTTYPE_JSON,

		/// <summary/>
		TDH_OUTTYPE_UTF8,

		/// <summary/>
		TDH_OUTTYPE_PKCS7_WITH_TYPE_INFO,

		/// <summary/>
		TDH_OUTTYPE_CODE_POINTER,

		/// <summary/>
		TDH_OUTTYPE_DATETIME_UTC,

		/// <summary/>
		TDH_OUTTYPE_REDUCEDSTRING,

		/// <summary/>
		TDH_OUTTYPE_NOPRINT,
	}

	/// <summary>Defines constant values that indicates the layout of the event data.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/ne-tdh-template_flags typedef enum _TEMPLATE_FLAGS { TEMPLATE_EVENT_DATA = 1,
	// TEMPLATE_USER_DATA = 2, TEMPLATE_CONTROL_GUID = 4 } TEMPLATE_FLAGS;
	[PInvokeData("tdh.h", MSDNShortId = "NE:tdh._TEMPLATE_FLAGS")]
	[Flags]
	public enum TEMPLATE_FLAGS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The layout of the event data is determined by the order of the data items defined in the event data template definition.</para>
		/// </summary>
		TEMPLATE_EVENT_DATA = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The layout of the event data is determined by the XML fragment included in the event data template definition.</para>
		/// </summary>
		TEMPLATE_USER_DATA = 2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// </summary>
		TEMPLATE_CONTROL_GUID = 4,
	}

	/// <summary>The metadata about the event map (EVENT_MAP_INFO structure).</summary>
	/// <param name="MapInfo">The metadata about the event map (EVENT_MAP_INFO structure).</param>
	/// <returns>The event map format, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-emi_map_format TDH_INLINE PWSTR EMI_MAP_FORMAT( [in] PEVENT_MAP_INFO
	// MapInfo );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.EMI_MAP_FORMAT")]
	public static string? EMI_MAP_FORMAT(SafeCoTaskMemStruct<EVENT_MAP_INFO>? MapInfo) =>
		MapInfo is null || !MapInfo.Value.Flag.IsFlagSet(MAP_FLAGS.EVENTMAP_INFO_FLAG_MANIFEST_PATTERNMAP) ? default : MapInfo.GetOffsetString(MapInfo.Value.FormatStringOffset);

	/// <summary>Macro that retrieves the event map input.</summary>
	/// <param name="MapInfo">The metadata about the event map (EVENT_MAP_INFO structure).</param>
	/// <param name="Map">A single value map entry (EVENT_MAP_ENTRY structure).</param>
	/// <returns>The event map input, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-emi_map_input TDH_INLINE PWSTR EMI_MAP_INPUT( PEVENT_MAP_INFO MapInfo,
	// PEVENT_MAP_ENTRY Map );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.EMI_MAP_INPUT")]
	public static string? EMI_MAP_INPUT(SafeCoTaskMemStruct<EVENT_MAP_INFO>? MapInfo, in EVENT_MAP_ENTRY Map) =>
		MapInfo is null || !MapInfo.Value.Flag.IsFlagSet(MAP_FLAGS.EVENTMAP_INFO_FLAG_MANIFEST_PATTERNMAP) ? default : MapInfo.GetOffsetString(Map.InputOffset);

	/// <summary>Macro that retrieves the event map name.</summary>
	/// <param name="MapInfo">The metadata about the event map (EVENT_MAP_INFO structure).</param>
	/// <returns>The event map name, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-emi_map_name TDH_INLINE PWSTR EMI_MAP_NAME( PEVENT_MAP_INFO MapInfo );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.EMI_MAP_NAME")]
	public static string? EMI_MAP_NAME(SafeCoTaskMemStruct<EVENT_MAP_INFO>? MapInfo) =>
		MapInfo?.GetOffsetString(MapInfo.Value.NameOffset);

	/// <summary>Macro that retrieves the event map output.</summary>
	/// <param name="MapInfo">The metadata about the event map (EVENT_MAP_INFO structure).</param>
	/// <param name="Map">A single value map entry (EVENT_MAP_ENTRY structure).</param>
	/// <returns>The event map output, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-emi_map_output TDH_INLINE PWSTR EMI_MAP_OUTPUT( PEVENT_MAP_INFO
	// MapInfo, PEVENT_MAP_ENTRY Map );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.EMI_MAP_OUTPUT")]
	public static string? EMI_MAP_OUTPUT(SafeCoTaskMemStruct<EVENT_MAP_INFO>? MapInfo, in EVENT_MAP_ENTRY Map) =>
		MapInfo?.GetOffsetString(Map.OutputOffset);

	/// <summary>Macro that retrieves the Provider Event Info (PEI) name.</summary>
	/// <param name="ProviderEnum">
	/// The array of providers that have registered a MOF or manifest on the computer (PROVIDER_ENUMERATION_INFO structure)
	/// </param>
	/// <param name="ProviderInfo">Provider event info (PROVIDER_EVENT_INFO structure).</param>
	/// <returns>The provider name, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-pei_provider_name TDH_INLINE PWSTR PEI_PROVIDER_NAME(
	// PPROVIDER_ENUMERATION_INFO ProviderEnum, PTRACE_PROVIDER_INFO ProviderInfo );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.PEI_PROVIDER_NAME")]
	public static string? PEI_PROVIDER_NAME(SafeCoTaskMemStruct<PROVIDER_ENUMERATION_INFO>? ProviderEnum, in TRACE_PROVIDER_INFO ProviderInfo) =>
		ProviderEnum?.GetOffsetString(ProviderInfo.ProviderNameOffset);

	/// <summary>Macro that retrieves the Provider Field Information (PFI) field message.</summary>
	/// <param name="FieldInfoArray">The PROVIDER_FIELD_INFOARRAY structure.</param>
	/// <param name="FieldInfo">Provider field info (PROVIDER_FIELD_INFO structure).</param>
	/// <returns>The provider field message, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-pfi_field_message TDH_INLINE PWSTR PFI_FIELD_MESSAGE(
	// PPROVIDER_FIELD_INFOARRAY FieldInfoArray, PPROVIDER_FIELD_INFO FieldInfo );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.PFI_FIELD_MESSAGE")]
	public static string? PFI_FIELD_MESSAGE(SafeCoTaskMemStruct<PROVIDER_FIELD_INFOARRAY>? FieldInfoArray, in PROVIDER_FIELD_INFO FieldInfo) =>
		FieldInfoArray?.GetOffsetString(FieldInfo.DescriptionOffset);

	/// <summary>Macro that retrieves the Provider Field Information (PFI) field name.</summary>
	/// <param name="FieldInfoArray">The PROVIDER_FIELD_INFOARRAY structure.</param>
	/// <param name="FieldInfo">Provider field info (PROVIDER_FIELD_INFO structure).</param>
	/// <returns>The provider field name, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-pfi_field_name TDH_INLINE PWSTR PFI_FIELD_NAME(
	// PPROVIDER_FIELD_INFOARRAY FieldInfoArray, PPROVIDER_FIELD_INFO FieldInfo );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.PFI_FIELD_NAME")]
	public static string? PFI_FIELD_NAME(SafeCoTaskMemStruct<PROVIDER_FIELD_INFOARRAY>? FieldInfoArray, in PROVIDER_FIELD_INFO FieldInfo) =>
		FieldInfoArray?.GetOffsetString(FieldInfo.NameOffset);

	/// <summary>Macro that filters the Provider Field Information (PFI) field message.</summary>
	/// <param name="FilterInfoArray">Provider filter info array (PROVIDER_FILTER_INFO array).</param>
	/// <param name="FilterInfoIndex">Index of the filter information in the array.</param>
	/// <returns>The Provider Field Information (PFI) field message, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-pfi_filter_message TDH_INLINE PWSTR PFI_FILTER_MESSAGE( [in]
	// PPROVIDER_FILTER_INFO FilterInfo );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.PFI_FILTER_MESSAGE")]
	public static string? PFI_FILTER_MESSAGE(SafeNativeArray<PROVIDER_FILTER_INFO>? FilterInfoArray, int FilterInfoIndex) =>
		FilterInfoArray?.GetOffsetString(FilterInfoArray[FilterInfoIndex].MessageOffset);

	/// <summary>Macro that retrieves the Provider Field Information (PFI) property name.</summary>
	/// <param name="FilterInfoArray">Provider filter info array (PROVIDER_FILTER_INFO array).</param>
	/// <param name="Property">Provider property info (EVENT_PROPERTY_INFO structure).</param>
	/// <returns>The Provider Field Information (PFI) property name, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-pfi_property_name TDH_INLINE PWSTR PFI_PROPERTY_NAME( [in]
	// PPROVIDER_FILTER_INFO FilterInfo, [in] PEVENT_PROPERTY_INFO Property );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.PFI_PROPERTY_NAME")]
	public static string? PFI_PROPERTY_NAME(SafeNativeArray<PROVIDER_FILTER_INFO>? FilterInfoArray, in EVENT_PROPERTY_INFO Property) =>
		FilterInfoArray?.GetOffsetString(Property.NameOffset);

	/// <summary>
	/// The <c>TdhAggregatePayloadFilters</c> function aggregates multiple payload filters for a single provider into a single data structure
	/// for use with the EnableTraceEx2 function.
	/// </summary>
	/// <param name="PayloadFilterCount">The count of payload filters.</param>
	/// <param name="PayloadFilterPtrs">An array of event payload single filters, each created by a call to the TdhCreatePayloadFilter function.</param>
	/// <param name="EventMatchALLFlags">
	/// <para>
	/// An array of Boolean values that correspond to each payload filter passed in the <c>PayloadFilterPtrs</c> parameter and indicates how
	/// events are handled when multiple conditions are specified.. This parameter only affects situations where multiple payload filters are
	/// being specified for the same event.
	/// </para>
	/// <para>
	/// When a Boolean value is <c>TRUE</c>, an event will be written to a session if any of the specified conditions specified in the filter
	/// are <c>TRUE</c>. If this flag is set to <c>TRUE</c> on one or more filters for the same event Id or event version, then the event is
	/// only written if all the flagged filters for the event are satisfied.
	/// </para>
	/// <para>
	/// When a Boolean value is <c>FALSE</c>, an event will be written to a session only if all of the specified conditions specified in the
	/// filter are <c>TRUE</c>. If this flag is set to <c>FALSE</c> on one or more filters for the same event Id or event version, then the
	/// event is written if any of the non-flagged filters are satisfied.
	/// </para>
	/// </param>
	/// <param name="EventFilterDescriptor">
	/// <para>
	/// A pointer to an EVENT_FILTER_DESCRIPTOR structure to be used with the EnableTraceEx2 function. The <c>EVENT_FILTER_DESCRIPTOR</c>
	/// structure will contain a pointer to the aggregated payload filters, which have been allocated by this function.
	/// </para>
	/// <para>
	/// When the caller is finished using this EVENT_FILTER_DESCRIPTOR structure with the EnableTraceEx2 function, the
	/// TdhCleanupPayloadEventFilterDescriptor function should be called to free the allocated memory.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>ERROR_SUCCESS</c> if successful. Otherwise, this function returns one of the following return codes in addition to others.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Unable to allocate memory to create the aggregated payload filter.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// On Windows 8.1,Windows Server 2012 R2, and later, event payload filters can be used by the EnableTraceEx2 function to filter on the
	/// specific content of the event in a logger session.
	/// </para>
	/// <para>
	/// The <c>TdhAggregatePayloadFilters</c> function aggregates payload filters for a single provider into a single data structure for use
	/// with the EnableTraceEx2 function. The <c>TdhAggregatePayloadFilters</c> allocates and fills in an opaque data structure for an
	/// aggregated payload filter. When the aggregated payload filter is no longer needed, the TdhCleanupPayloadEventFilterDescriptor
	/// function is used to free memory allocated for the aggregated payload filter in the EVENT_FILTER_DESCRIPTOR structure returned.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// For an example that uses the <c>TdhAggregatePayloadFilters</c> function to aggregate payload filters to use in filtering on specific
	/// conditions in a logger session, see the example for the EnableTraceEx2 function.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhaggregatepayloadfilters Win32Error TdhAggregatePayloadFilters( ULONG
	// PayloadFilterCount, PVOID *PayloadFilterPtrs, [in, optional] PBOOLEAN EventMatchALLFlags, [out] PEVENT_FILTER_DESCRIPTOR
	// EventFilterDescriptor );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhAggregatePayloadFilters")]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhAggregatePayloadFilters(uint PayloadFilterCount,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] PayloadFilterPtrs,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 0)] bool[]? EventMatchALLFlags,
		out EVENT_FILTER_DESCRIPTOR EventFilterDescriptor);

	/// <summary>
	/// The <c>TdhCleanupPayloadEventFilterDescriptor</c> function frees the aggregated structure of payload filters created using the
	/// TdhAggregatePayloadFilters function.
	/// </summary>
	/// <param name="EventFilterDescriptor">
	/// <para>
	/// A pointer to an EVENT_FILTER_DESCRIPTOR structure that contains aggregated filters where the allocated memory is to be freed. The
	/// <c>EVENT_FILTER_DESCRIPTOR</c> structure passed was created by calling the TdhAggregatePayloadFilters function.
	/// </para>
	/// <para>
	/// If the call is successful, allocated memory is released for the aggregated filters and the fields in the returned
	/// EVENT_FILTER_DESCRIPTOR structure are re-initialized
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>ERROR_SUCCESS</c> if successful. Otherwise, this function returns one of the following return codes in addition to others.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// On Windows 8.1,Windows Server 2012 R2, and later, event payload filters can be used by the EnableTraceEx2 function to filter on
	/// specific content of the event in a logger session.
	/// </para>
	/// <para>
	/// The <c>TdhCleanupPayloadEventFilterDescriptor</c> function is used to free memory allocated that is returned by the
	/// TdhAggregatePayloadFilters function.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// For an example that uses the <c>TdhCleanupPayloadEventFilterDescriptor</c> function to free memory used by aggregate payload filters,
	/// see the example for the EnableTraceEx2 function.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhcleanuppayloadeventfilterdescriptor Win32Error
	// TdhCleanupPayloadEventFilterDescriptor( [in, out] PEVENT_FILTER_DESCRIPTOR EventFilterDescriptor );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhCleanupPayloadEventFilterDescriptor")]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhCleanupPayloadEventFilterDescriptor(ref EVENT_FILTER_DESCRIPTOR EventFilterDescriptor);

	/// <summary>Frees any resources associated with the input decoding handle.</summary>
	/// <param name="Handle">
	/// <para>Type: <c>TDH_HANDLE</c></para>
	/// <para>The decoding handle to be closed.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>ULONG</c></para>
	/// <para>This function returns ERROR_SUCCESS on completion.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhclosedecodinghandle Win32Error TdhCloseDecodingHandle( [in]
	// TDH_HANDLE Handle );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhCloseDecodingHandle", MinClient = PInvokeClient.Windows8)]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhCloseDecodingHandle([In] TDH_HANDLE Handle);

	/// <summary>
	/// The <c>TdhCreatePayloadFilter</c> function creates a single filter for a single payload to be used with the EnableTraceEx2 function.
	/// </summary>
	/// <param name="ProviderGuid">A GUID that identifies the manifest provider of the <c>EventDescriptor</c> parameter.</param>
	/// <param name="EventDescriptor">A pointer to the event descriptor whose payload will be filtered.</param>
	/// <param name="EventMatchANY">
	/// <para>A Boolean value that indicates how events are handled when multiple conditions are specified.</para>
	/// <para>
	/// When this parameter is <c>TRUE</c>, an event will be written to a session if any of the specified conditions specified in the filter
	/// are <c>TRUE</c>.
	/// </para>
	/// <para>
	/// When this parameter is <c>FALSE</c>, an event will be written to a session only if all of the specified conditions specified in the
	/// filter are <c>TRUE</c>.
	/// </para>
	/// </param>
	/// <param name="PayloadPredicateCount">
	/// The number of conditions specified in the filter. This value must be less than or equal to the <c>ETW_MAX_PAYLOAD_PREDICATES</c>
	/// constant defined in the <c>Tdh.h</c> header file.
	/// </param>
	/// <param name="PayloadPredicates">
	/// A pointer to an array of PAYLOAD_FILTER_PREDICATE structures that contain the list conditions that the filter specifies.
	/// </param>
	/// <param name="PayloadFilter">
	/// <para>
	/// On success, this parameter returns a pointer to a single payload filter that is properly sized and built for the specified conditions.
	/// </para>
	/// <para>
	/// When the caller is finished using the returned payload filter with the EnableTraceEx2 function, the TdhDeletePayloadFilter function
	/// should be called to free the allocated memory.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>ERROR_SUCCESS</c> if successful. Otherwise, this function returns one of the following return codes in addition to others.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>The metadata for the provider was not found.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>
	/// The resulting payload filter would not fit within the <c>MAX_EVENT_FILTER_PAYLOAD_SIZE</c> limit imposed by the EnableTraceEx2
	/// function on the EVENT_FILTER_DESCRIPTOR structures in a payload.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Unable to allocate memory to create the payload filter.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>The schema information for supplied provider GUID was not found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// On Windows 8.1,Windows Server 2012 R2, and later, event payload filters can be used by the EnableTraceEx2 function to filter on the
	/// specific content of event in a logger session.
	/// </para>
	/// <para>
	/// The <c>TdhCreatePayloadFilter</c> function is used to create a single payload filter for a single payload to be used with the
	/// EnableTraceEx2 function. The <c>TdhCreatePayloadFilter</c> allocates and fills in an opaque data structure for a single payload
	/// filter. When the payload filter is no longer needed, the TdhDeletePayloadFilter function is used to free memory allocated for a
	/// payload filter.
	/// </para>
	/// <para>
	/// For a single provider, multiple events can have distinct payload filters. There can also be multiple filters for the same event, with
	/// a payload being passed to the session if any or all of the event's filters pass it.
	/// </para>
	/// <para>
	/// The EnableTraceEx2 function takes an array of EVENT_FILTER_DESCRIPTOR structures in the ENABLE_TRACE_PARAMETERS structures passed in
	/// the <c>EnableParameters</c> parameter. There can only be one entry in the array for each event filter type. The
	/// TdhAggregatePayloadFilters function can be used to aggregate a list of payload filters for a single provider created using the
	/// <c>TdhCreatePayloadFilter</c> into a single data structure and return an <c>EVENT_FILTER_DESCRIPTOR</c> for use with the
	/// <c>EnableTraceEx2</c> function.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// For an example that uses the <c>TdhCreatePayloadFilter</c> function to create payload filters to use in filtering on specific
	/// conditions in a logger session, see the example for the EnableTraceEx2 function.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhcreatepayloadfilter Win32Error TdhCreatePayloadFilter( [in] LPCGUID
	// ProviderGuid, [in] PCEVENT_DESCRIPTOR EventDescriptor, [in] BOOLEAN EventMatchANY, [in] ULONG PayloadPredicateCount, [in]
	// PPAYLOAD_FILTER_PREDICATE PayloadPredicates, [out] PVOID *PayloadFilter );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhCreatePayloadFilter")]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhCreatePayloadFilter(in Guid ProviderGuid, in EVENT_DESCRIPTOR EventDescriptor,
		[In, MarshalAs(UnmanagedType.U1)] bool EventMatchANY, uint PayloadPredicateCount,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PAYLOAD_FILTER_PREDICATE[] PayloadPredicates, out IntPtr PayloadFilter);

	/// <summary>
	/// The <c>TdhDeletePayloadFilter</c> function frees the memory allocated for a single payload filter by the TdhCreatePayloadFilter function.
	/// </summary>
	/// <param name="PayloadFilter">A pointer to a single payload filter allocated by the TdhCreatePayloadFilter function.</param>
	/// <returns>
	/// <para>
	/// Returns <c>ERROR_SUCCESS</c> if successful. Otherwise, this function returns one of the following return codes in addition to others.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// On Windows 8.1,Windows Server 2012 R2, and later, event payload filters can be used by the EnableTraceEx2 function to filter on the
	/// specific content of the event in a logger session.
	/// </para>
	/// <para>
	/// The <c>TdhDeletePayloadFilter</c> function is used to free memory allocated for a single payload filter that is returned by the
	/// TdhCreatePayloadFilter function.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhdeletepayloadfilter Win32Error TdhDeletePayloadFilter( [in, out]
	// PVOID *PayloadFilter );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhDeletePayloadFilter")]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhDeletePayloadFilter(ref IntPtr PayloadFilter);

	/// <summary>The <c>TdhEnumerateManifestProviderEvents</c> function retrieves the list of events present in the provider manifest.</summary>
	/// <param name="ProviderGuid">A GUID that identifies the manifest provider whose list of events you want to retrieve.</param>
	/// <param name="Buffer">A user-allocated buffer to receive the list of events. For details, see the PROVIDER_EVENT_INFO structure.</param>
	/// <param name="BufferSize">
	/// The size, in bytes, of the buffer pointed to by the <c>ProviderInfo</c> parameter. If the function succeeds, this parameter receives
	/// the size of the buffer used. If the buffer is too small, the function returns <c>ERROR_INSUFFICIENT_BUFFER</c> and sets this
	/// parameter to the required buffer size. If the buffer size is zero on input, no data is returned in the buffer and this parameter
	/// receives the required buffer size.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>ERROR_SUCCESS</c> if successful. Otherwise, this function returns one of the following return codes in addition to others.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <description><c>ERROR_EMPTY</c></description>
	/// <description>There are no events defined for the provider GUID in the manifest.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_FILE_NOT_FOUND</c></description>
	/// <description>The metadata for the provider was not found.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_INSUFFICIENT_BUFFER</c></description>
	/// <description>
	/// The size of the <c>ProviderInfo</c> buffer is too small. Use the required buffer size set in the <c>BufferSize</c> parameter to
	/// allocate a new buffer.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_INVALID_PARAMETER</c></description>
	/// <description>One or more of the parameters is not valid.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_NOT_FOUND</c></description>
	/// <description>The schema information for supplied provider GUID was not found.</description>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhenumeratemanifestproviderevents Win32Error
	// TdhEnumerateManifestProviderEvents( [in] LPGUID ProviderGuid, [out] PPROVIDER_EVENT_INFO Buffer, [in, out] ULONG *BufferSize );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhEnumerateManifestProviderEvents", MinClient = PInvokeClient.Windows81)]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhEnumerateManifestProviderEvents(in Guid ProviderGuid,
		[Out, Optional] IntPtr Buffer, ref uint BufferSize);

	/// <summary>The <c>TdhEnumerateManifestProviderEvents</c> function retrieves the list of events present in the provider manifest.</summary>
	/// <param name="ProviderGuid">A GUID that identifies the manifest provider whose list of events you want to retrieve.</param>
	/// <param name="Buffer">Receives the list of events. For details, see the PROVIDER_EVENT_INFO structure.</param>
	/// <returns>
	/// <para>
	/// Returns <c>ERROR_SUCCESS</c> if successful. Otherwise, this function returns one of the following return codes in addition to others.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <description><c>ERROR_EMPTY</c></description>
	/// <description>There are no events defined for the provider GUID in the manifest.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_FILE_NOT_FOUND</c></description>
	/// <description>The metadata for the provider was not found.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_INVALID_PARAMETER</c></description>
	/// <description>One or more of the parameters is not valid.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_NOT_FOUND</c></description>
	/// <description>The schema information for supplied provider GUID was not found.</description>
	/// </item>
	/// </list>
	/// </returns>
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhEnumerateManifestProviderEvents", MinClient = PInvokeClient.Windows81)]
	public static Win32Error TdhEnumerateManifestProviderEvents([In] Guid ProviderGuid, out PROVIDER_EVENT_INFO Buffer) =>
		Get((IntPtr p, ref uint s) => TdhEnumerateManifestProviderEvents(ProviderGuid, p, ref s), out Buffer);

	/// <summary>Retrieves the specified field metadata for a given provider.</summary>
	/// <param name="pGuid">GUID that identifies the provider whose information you want to retrieve.</param>
	/// <param name="EventFieldType">
	/// Specify the type of field for which you want to retrieve information. For possible values, see the EVENT_FIELD_TYPE enumeration.
	/// </param>
	/// <param name="pBuffer">User-allocated buffer to receive the field information. For details, see the PROVIDER_FIELD_INFOARRAY structure.</param>
	/// <param name="pBufferSize">
	/// Size, in bytes, of the <c>pBuffer</c> buffer. If the function succeeds, this parameter receives the size of the buffer used. If the
	/// buffer is too small, the function returns ERROR_INSUFFICIENT_BUFFER and sets this parameter to the required buffer size. If the
	/// buffer size is zero on input, no data is returned in the buffer and this parameter receives the required buffer size.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <description><c>ERROR_INSUFFICIENT_BUFFER</c></description>
	/// <description>
	/// The size of the <c>pBuffer</c> buffer is too small. Use the required buffer size set in <c>pBufferSize</c> to allocate a new buffer.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_NOT_SUPPORTED</c></description>
	/// <description>The requested field type is not valid.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_NOT_FOUND</c></description>
	/// <description>The manifest or MOF class was not found or does not contain information for the requested field type.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_INVALID_PARAMETER</c></description>
	/// <description>One or more of the parameters is not valid.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_FILE_NOT_FOUND</c></description>
	/// <description>
	/// The <c>resourceFileName</c> attribute in the manifest contains the location of the provider binary. When you register the manifest,
	/// the location is written to the registry. TDH was unable to find the binary based on the registered location.
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function uses the XML manifest or WMI MOF class to retrieve the information.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhenumerateproviderfieldinformation Win32Error
	// TdhEnumerateProviderFieldInformation( [in] LPGUID pGuid, [in] EVENT_FIELD_TYPE EventFieldType, [out, optional]
	// PPROVIDER_FIELD_INFOARRAY pBuffer, [in, out] ULONG *pBufferSize );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhEnumerateProviderFieldInformation")]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhEnumerateProviderFieldInformation(in Guid pGuid, [In] EVENT_FIELD_TYPE EventFieldType,
		[Out, Optional] IntPtr pBuffer, ref uint pBufferSize);

	/// <summary>Retrieves the specified field metadata for a given provider.</summary>
	/// <param name="pGuid">GUID that identifies the provider whose information you want to retrieve.</param>
	/// <param name="EventFieldType">
	/// Specify the type of field for which you want to retrieve information. For possible values, see the EVENT_FIELD_TYPE enumeration.
	/// </param>
	/// <param name="pBuffer">Receives the field information. For details, see the PROVIDER_FIELD_INFOARRAY structure.</param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <description><c>ERROR_NOT_SUPPORTED</c></description>
	/// <description>The requested field type is not valid.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_NOT_FOUND</c></description>
	/// <description>The manifest or MOF class was not found or does not contain information for the requested field type.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_INVALID_PARAMETER</c></description>
	/// <description>One or more of the parameters is not valid.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_FILE_NOT_FOUND</c></description>
	/// <description>
	/// The <c>resourceFileName</c> attribute in the manifest contains the location of the provider binary. When you register the manifest,
	/// the location is written to the registry. TDH was unable to find the binary based on the registered location.
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function uses the XML manifest or WMI MOF class to retrieve the information.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhenumerateproviderfieldinformation Win32Error
	// TdhEnumerateProviderFieldInformation( [in] LPGUID pGuid, [in] EVENT_FIELD_TYPE EventFieldType, [out, optional]
	// PPROVIDER_FIELD_INFOARRAY pBuffer, [in, out] ULONG *pBufferSize );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhEnumerateProviderFieldInformation")]
	public static Win32Error TdhEnumerateProviderFieldInformation([In] Guid pGuid, [In] EVENT_FIELD_TYPE EventFieldType, out SafeCoTaskMemStruct<PROVIDER_FIELD_INFOARRAY> pBuffer) =>
		GetMem((IntPtr p, ref uint s) => TdhEnumerateProviderFieldInformation(pGuid, EventFieldType, p, ref s), out pBuffer);

	/// <summary>The <c>TdhEnumerateProviderFilters</c> function enumerates the filters that the specified provider defined in the manifest.</summary>
	/// <param name="Guid">GUID that identifies the provider whose filters you want to retrieve.</param>
	/// <param name="TdhContextCount">Not used.</param>
	/// <param name="TdhContext">Not used.</param>
	/// <param name="FilterCount">
	/// The number of filter structures that the <c>pBuffer</c> buffer contains. Is zero if the <c>pBuffer</c> buffer is insufficient.
	/// </param>
	/// <param name="Buffer">User-allocated buffer to receive the filter information. For details, see the PROVIDER_FILTER_INFO structure.</param>
	/// <param name="BufferSize">
	/// Size, in bytes, of the <c>pBuffer</c> buffer. If the function succeeds, this parameter receives the size of the buffer used. If the
	/// buffer is too small, the function returns ERROR_INSUFFICIENT_BUFFER and sets this parameter to the required buffer size. If the
	/// buffer size is zero on input, no data is returned in the buffer and this parameter receives the required buffer size.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>
	/// The size of the <c>pBuffer</c> buffer is too small. Use the required buffer size set in <c>pBufferSize</c> to allocate a new buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>The schema for the event was not found.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>
	/// The <c>resourceFileName</c> attribute in the manifest contains the location of the provider binary. When you register the manifest,
	/// the location is written to the registry. TDH was unable to find the binary based on the registered location.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>This function uses the XML manifest to retrieve the information.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhenumerateproviderfilters Win32Error TdhEnumerateProviderFilters(
	// [in] LPGUID Guid, [in] ULONG TdhContextCount, [in, optional] PTDH_CONTEXT TdhContext, [in] ULONG *FilterCount, [out, optional]
	// PPROVIDER_FILTER_INFO *Buffer, [in, out] ULONG *BufferSize );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhEnumerateProviderFilters", MinClient = PInvokeClient.Windows7)]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhEnumerateProviderFilters(in Guid Guid, [In, Optional] uint TdhContextCount,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TDH_CONTEXT[]? TdhContext,
		out uint FilterCount, [Out, Optional] IntPtr Buffer, ref uint BufferSize);

	/// <summary>The <c>TdhEnumerateProviderFilters</c> function enumerates the filters that the specified provider defined in the manifest.</summary>
	/// <param name="Guid">GUID that identifies the provider whose filters you want to retrieve.</param>
	/// <param name="TdhContext">Not used.</param>
	/// <param name="Buffer">Receives the filter information. For details, see the PROVIDER_FILTER_INFO structure.</param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <description><c>ERROR_INSUFFICIENT_BUFFER</c></description>
	/// <description>
	/// The size of the <c>pBuffer</c> buffer is too small. Use the required buffer size set in <c>pBufferSize</c> to allocate a new buffer.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_NOT_FOUND</c></description>
	/// <description>The schema for the event was not found.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_INVALID_PARAMETER</c></description>
	/// <description>One or more of the parameters is not valid.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_FILE_NOT_FOUND</c></description>
	/// <description>
	/// The <c>resourceFileName</c> attribute in the manifest contains the location of the provider binary. When you register the manifest,
	/// the location is written to the registry. TDH was unable to find the binary based on the registered location.
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>This function uses the XML manifest to retrieve the information.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhenumerateproviderfilters Win32Error TdhEnumerateProviderFilters(
	// [in] LPGUID Guid, [in] ULONG TdhContextCount, [in, optional] PTDH_CONTEXT TdhContext, [in] ULONG *FilterCount, [out, optional]
	// PPROVIDER_FILTER_INFO *Buffer, [in, out] ULONG *BufferSize );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhEnumerateProviderFilters", MinClient = PInvokeClient.Windows7)]
	public static Win32Error TdhEnumerateProviderFilters(in Guid Guid, [In, Optional] TDH_CONTEXT[]? TdhContext, out SafeNativeArray<PROVIDER_FILTER_INFO> Buffer)
	{
		Win32Error status;
		SafeHGlobalHandle buffer = new(0);
		uint bufferSize = buffer.Size, filterCount;

		while (true)
		{
			if ((status = TdhEnumerateProviderFilters(Guid, (uint)(TdhContext?.Length ?? 0), TdhContext, out filterCount, buffer, ref bufferSize)) != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				break;
			}

			buffer.Size = bufferSize;
		}
		Buffer = status.Succeeded && filterCount > 0 ? new SafeNativeArray<PROVIDER_FILTER_INFO>(buffer.TakeOwnership(), bufferSize, true, 0, (int)filterCount, true) : new SafeNativeArray<PROVIDER_FILTER_INFO>(0);
		return status;
	}

	/// <summary>Retrieves a list of all providers that have registered on the computer.</summary>
	/// <param name="pBuffer">
	/// Array of providers that publicly define their events on the computer. For details, see the PROVIDER_ENUMERATION_INFO structure.
	/// </param>
	/// <param name="pBufferSize">
	/// Size, in bytes, of the pBuffer buffer. If the function succeeds, this parameter receives the size of the buffer used. If the buffer
	/// is too small, the function returns ERROR_INSUFFICIENT_BUFFER and sets this parameter to the required buffer size. If the buffer size
	/// is zero on input, no data is returned in the buffer and this parameter receives the required buffer size.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <description><c>ERROR_INSUFFICIENT_BUFFER</c></description>
	/// <description>
	/// The size of the <c>pBuffer</c> buffer is too small. Use the required buffer size set in <c>pBufferSize</c> to allocate a new buffer.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_INVALID_PARAMETER</c></description>
	/// <description>One or more of the parameters is not valid.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Call TdhEnumerateProvidersForDecodingSource function to retrieve a list of providers that have registered a MOF class or manifest
	/// file on the computer.
	/// </para>
	/// <para>
	/// Because the number of registered event providers may fluctuate between calls to this function, you should place this function in a
	/// loop that loops until the returned value is no longer ERROR_INSUFFICIENT_BUFFER.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that shows how to enumerate providers, see Enumerating Providers.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhenumerateproviders Win32Error TdhEnumerateProviders( [out]
	// PPROVIDER_ENUMERATION_INFO pBuffer, [in, out] ULONG *pBufferSize );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhEnumerateProviders", MinClient = PInvokeClient.Windows7)]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhEnumerateProviders([Out] IntPtr pBuffer, ref uint pBufferSize);

	/// <summary>Retrieves a list of all providers that have registered on the computer.</summary>
	/// <param name="pBuffer">
	/// Array of providers that publicly define their events on the computer. For details, see the PROVIDER_ENUMERATION_INFO structure.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <description><c>ERROR_INVALID_PARAMETER</c></description>
	/// <description>One or more of the parameters is not valid.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Call TdhEnumerateProvidersForDecodingSource function to retrieve a list of providers that have registered a MOF class or manifest
	/// file on the computer.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhenumerateproviders Win32Error TdhEnumerateProviders( [out]
	// PPROVIDER_ENUMERATION_INFO pBuffer, [in, out] ULONG *pBufferSize );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhEnumerateProviders", MinClient = PInvokeClient.Windows7)]
	public static Win32Error TdhEnumerateProviders(out SafeCoTaskMemStruct<PROVIDER_ENUMERATION_INFO> pBuffer) =>
		GetMem(TdhEnumerateProviders, out pBuffer);

	/// <summary>Retrieves a list of providers that have registered a MOF class or manifest file on the computer.</summary>
	/// <param name="filter">One or more values from DECODING_SOURCE enumeration.</param>
	/// <param name="buffer">
	/// Array of providers that publicly define their events on the computer. For details, see the PROVIDER_ENUMERATION_INFO structure.
	/// </param>
	/// <param name="bufferSize">
	/// Size, in bytes, of the pBuffer buffer. If the function succeeds, this parameter receives the size of the buffer used. If the buffer
	/// is too small, the function returns ERROR_INSUFFICIENT_BUFFER and sets this parameter to the required buffer size. If the buffer size
	/// is zero on input, no data is returned in the buffer and this parameter receives the required buffer size.
	/// </param>
	/// <param name="bufferRequired">The buffer required.</param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <description><c>ERROR_INSUFFICIENT_BUFFER</c></description>
	/// <description>
	/// The size of the <c>pBuffer</c> buffer is too small. Use the required buffer size set in <c>pBufferSize</c> to allocate a new buffer.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_INVALID_PARAMETER</c></description>
	/// <description>One or more of the parameters is not valid.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>Use TdhEnumerateProviders to retrieve all providers that have registered on the computer.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhenumerateprovidersfordecodingsource Win32Error
	// TdhEnumerateProvidersForDecodingSource( DECODING_SOURCE filter, [out] PROVIDER_ENUMERATION_INFO *buffer, [in, out] ULONG bufferSize,
	// [out] ULONG *bufferRequired );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhEnumerateProvidersForDecodingSource", MinClient = PInvokeClient.Windows10)]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhEnumerateProvidersForDecodingSource(DECODING_SOURCE filter,
		[Out] IntPtr buffer, uint bufferSize, out uint bufferRequired);

	/// <summary>Retrieves a list of providers that have registered a MOF class or manifest file on the computer.</summary>
	/// <param name="filter">One or more values from DECODING_SOURCE enumeration.</param>
	/// <param name="buffer">
	/// Array of providers that publicly define their events on the computer. For details, see the PROVIDER_ENUMERATION_INFO structure.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <description><c>ERROR_INVALID_PARAMETER</c></description>
	/// <description>One or more of the parameters is not valid.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>Use TdhEnumerateProviders to retrieve all providers that have registered on the computer.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhenumerateprovidersfordecodingsource Win32Error
	// TdhEnumerateProvidersForDecodingSource( DECODING_SOURCE filter, [out] PROVIDER_ENUMERATION_INFO *buffer, [in, out] ULONG bufferSize,
	// [out] ULONG *bufferRequired );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhEnumerateProvidersForDecodingSource", MinClient = PInvokeClient.Windows10)]
	public static Win32Error TdhEnumerateProvidersForDecodingSource(DECODING_SOURCE filter, out SafeCoTaskMemStruct<PROVIDER_ENUMERATION_INFO> buffer) =>
		GetMem((IntPtr p, ref uint s) => TdhEnumerateProvidersForDecodingSource(filter, p, s, out s), out buffer);

	/// <summary>Formats a property value for display.</summary>
	/// <param name="EventInfo">
	/// A TRACE_EVENT_INFO structure that contains the event information. To get this structure, call the TdhGetEventInformation function.
	/// </param>
	/// <param name="MapInfo">
	/// An EVENT_MAP_INFO structure that maps integer and bit values to strings. To get this structure, call the TdhGetEventMapInformation
	/// function. To get the name of the map, use the <c>MapNameOffset</c> member of the EVENT_PROPERTY_INFO structure. If you do not provide
	/// the map information for a mapped property, the function formats the integer or bit value.
	/// </param>
	/// <param name="PointerSize">
	/// The size of a pointer value in the event data. To get the size, access the EVENT_RECORD.EventHeader.Flags member. The pointer size is
	/// 4 bytes if the EVENT_HEADER_FLAG_32_BIT_HEADER flag is set; otherwise, it is 8 bytes if the EVENT_HEADER_FLAG_64_BIT_HEADER flag is
	/// set. The EVENT_RECORD structure (evntcons.h) is passed to your [PEVENT_RECORD_CALLBACK callback function].
	/// </param>
	/// <param name="PropertyInType">
	/// The input type of the property. Use the <c>InType</c> member of the EVENT_PROPERTY_INFO structure to set this parameter.
	/// </param>
	/// <param name="PropertyOutType">
	/// The output type of the property. Use the <c>OutType</c> member of the EVENT_PROPERTY_INFO structure to set this parameter.
	/// </param>
	/// <param name="PropertyLength">
	/// The length, in bytes, of the property. Use the <c>Length</c> member of the EVENT_PROPERTY_INFO structure to set this parameter.
	/// </param>
	/// <param name="UserDataLength">The size, in bytes, of the UserData buffer. See Remarks.</param>
	/// <param name="UserData">The buffer that contains the event data. See Remarks.</param>
	/// <param name="BufferSize">
	/// The size, in bytes, of the Buffer buffer. If the function succeeds, this parameter receives the size of the buffer used. If the
	/// buffer is too small, the function returns ERROR_INSUFFICIENT_BUFFER and sets this parameter to the required buffer size. If the
	/// buffer size is zero on input, no data is returned in the buffer and this parameter receives the required buffer size.
	/// </param>
	/// <param name="Buffer">
	/// A caller-allocated buffer that contains the formatted property value. To determine the required buffer size, set this parameterto
	/// <c>NULL</c> and BufferSize to zero.
	/// </param>
	/// <param name="UserDataConsumed">
	/// The length, in bytes, of the consumed event data. Use this value to adjust the values of the UserData and UserDataLength parameters.
	/// See Remarks.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>
	/// The size of the <c>pBuffer</c> buffer is too small. Use the required buffer size set in <c>pBufferSize</c> to allocate a new buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_EVT_INVALID_EVENT_DATA</c></term>
	/// <term>The event data does not match the event definition in the manifest.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Typically, you call this function in a loop. Use the TRACE_EVENT_INFO.TopLevelPropertyCount member to control the loop (the
	/// TdhGetEventInformation function returns the TRACE_EVENT_INFO structure). Before entering the loop, you set the UserData and
	/// UserDataLength parameters to the value of the <c>UserData</c> and <c>UserDataLength</c> members of the EVENT_RECORD structure,
	/// respectively. The EVENT_RECORD structure is passed to your [PEVENT_RECORD_CALLBACK callback function].
	/// </para>
	/// <para>
	/// Determine whether the property is an array. The property is an array if the EVENT_PROPERTY_INFO.Flags member is set to
	/// PropertyParamCount or the EVENT_PROPERTY_INFO.count member is greater than 1. Call the <c>TdhFormatProperty</c> function in a loop
	/// based on the number of elements in the array.
	/// </para>
	/// <para>
	/// After calling the <c>TdhFormatProperty</c> function, use the UserDataConsumed parameter value to set the new values of the UserData
	/// and UserDataLength parameters (Subtract UserDataConsumed from UserDataLength and use UserDataLength to increment the UserData pointer).
	/// </para>
	/// <para>
	/// If the property is an IP V6 address, you must set the PropertyLength parameter to the size of the <c>IN6_ADDR</c> structure. The
	/// property is considered an IP V6 address if the following conditions are met:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The <c>InType</c> member of the EVENT_PROPERTY_INFO structure is TDH_INTYPE_BINARY</term>
	/// </item>
	/// <item>
	/// <term>The <c>OutType</c> member of the EVENT_PROPERTY_INFO structure is TDH_OUTTYPE_IPV6</term>
	/// </item>
	/// <item>
	/// <term>The <c>Length</c> member of the EVENT_PROPERTY_INFO structure is 0</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example that shows how to call this function , see Using TdhFormatProperty to Consume Event Data.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhformatproperty Win32Error TdhFormatProperty( [in] PTRACE_EVENT_INFO
	// EventInfo, [in, optional] PEVENT_MAP_INFO MapInfo, [in] ULONG PointerSize, [in] USHORT PropertyInType, [in] USHORT PropertyOutType,
	// [in] USHORT PropertyLength, [in] USHORT UserDataLength, [in] PBYTE UserData, [in, out] PULONG BufferSize, [out, optional] PWCHAR
	// Buffer, [out] PUSHORT UserDataConsumed );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhFormatProperty", MinClient = PInvokeClient.Windows7)]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhFormatProperty(SafeCoTaskMemStruct<TRACE_EVENT_INFO> EventInfo, in EVENT_MAP_INFO MapInfo, uint PointerSize,
		ushort PropertyInType, ushort PropertyOutType, ushort PropertyLength, ushort UserDataLength, [In] IntPtr UserData,
		ref uint BufferSize, [Out, Optional, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? Buffer, out ushort UserDataConsumed);

	/// <summary>Formats a property value for display.</summary>
	/// <param name="EventInfo">
	/// A TRACE_EVENT_INFO structure that contains the event information. To get this structure, call the TdhGetEventInformation function.
	/// </param>
	/// <param name="MapInfo">
	/// An EVENT_MAP_INFO structure that maps integer and bit values to strings. To get this structure, call the TdhGetEventMapInformation
	/// function. To get the name of the map, use the <c>MapNameOffset</c> member of the EVENT_PROPERTY_INFO structure. If you do not provide
	/// the map information for a mapped property, the function formats the integer or bit value.
	/// </param>
	/// <param name="PointerSize">
	/// The size of a pointer value in the event data. To get the size, access the EVENT_RECORD.EventHeader.Flags member. The pointer size is
	/// 4 bytes if the EVENT_HEADER_FLAG_32_BIT_HEADER flag is set; otherwise, it is 8 bytes if the EVENT_HEADER_FLAG_64_BIT_HEADER flag is
	/// set. The EVENT_RECORD structure (evntcons.h) is passed to your [PEVENT_RECORD_CALLBACK callback function].
	/// </param>
	/// <param name="PropertyInType">
	/// The input type of the property. Use the <c>InType</c> member of the EVENT_PROPERTY_INFO structure to set this parameter.
	/// </param>
	/// <param name="PropertyOutType">
	/// The output type of the property. Use the <c>OutType</c> member of the EVENT_PROPERTY_INFO structure to set this parameter.
	/// </param>
	/// <param name="PropertyLength">
	/// The length, in bytes, of the property. Use the <c>Length</c> member of the EVENT_PROPERTY_INFO structure to set this parameter.
	/// </param>
	/// <param name="UserDataLength">The size, in bytes, of the UserData buffer. See Remarks.</param>
	/// <param name="UserData">The buffer that contains the event data. See Remarks.</param>
	/// <param name="BufferSize">
	/// The size, in bytes, of the Buffer buffer. If the function succeeds, this parameter receives the size of the buffer used. If the
	/// buffer is too small, the function returns ERROR_INSUFFICIENT_BUFFER and sets this parameter to the required buffer size. If the
	/// buffer size is zero on input, no data is returned in the buffer and this parameter receives the required buffer size.
	/// </param>
	/// <param name="Buffer">
	/// A caller-allocated buffer that contains the formatted property value. To determine the required buffer size, set this parameterto
	/// <c>NULL</c> and BufferSize to zero.
	/// </param>
	/// <param name="UserDataConsumed">
	/// The length, in bytes, of the consumed event data. Use this value to adjust the values of the UserData and UserDataLength parameters.
	/// See Remarks.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>
	/// The size of the <c>pBuffer</c> buffer is too small. Use the required buffer size set in <c>pBufferSize</c> to allocate a new buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_EVT_INVALID_EVENT_DATA</c></term>
	/// <term>The event data does not match the event definition in the manifest.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Typically, you call this function in a loop. Use the TRACE_EVENT_INFO.TopLevelPropertyCount member to control the loop (the
	/// TdhGetEventInformation function returns the TRACE_EVENT_INFO structure). Before entering the loop, you set the UserData and
	/// UserDataLength parameters to the value of the <c>UserData</c> and <c>UserDataLength</c> members of the EVENT_RECORD structure,
	/// respectively. The EVENT_RECORD structure is passed to your [PEVENT_RECORD_CALLBACK callback function].
	/// </para>
	/// <para>
	/// Determine whether the property is an array. The property is an array if the EVENT_PROPERTY_INFO.Flags member is set to
	/// PropertyParamCount or the EVENT_PROPERTY_INFO.count member is greater than 1. Call the <c>TdhFormatProperty</c> function in a loop
	/// based on the number of elements in the array.
	/// </para>
	/// <para>
	/// After calling the <c>TdhFormatProperty</c> function, use the UserDataConsumed parameter value to set the new values of the UserData
	/// and UserDataLength parameters (Subtract UserDataConsumed from UserDataLength and use UserDataLength to increment the UserData pointer).
	/// </para>
	/// <para>
	/// If the property is an IP V6 address, you must set the PropertyLength parameter to the size of the <c>IN6_ADDR</c> structure. The
	/// property is considered an IP V6 address if the following conditions are met:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The <c>InType</c> member of the EVENT_PROPERTY_INFO structure is TDH_INTYPE_BINARY</term>
	/// </item>
	/// <item>
	/// <term>The <c>OutType</c> member of the EVENT_PROPERTY_INFO structure is TDH_OUTTYPE_IPV6</term>
	/// </item>
	/// <item>
	/// <term>The <c>Length</c> member of the EVENT_PROPERTY_INFO structure is 0</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example that shows how to call this function , see Using TdhFormatProperty to Consume Event Data.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhformatproperty Win32Error TdhFormatProperty( [in] PTRACE_EVENT_INFO
	// EventInfo, [in, optional] PEVENT_MAP_INFO MapInfo, [in] ULONG PointerSize, [in] USHORT PropertyInType, [in] USHORT PropertyOutType,
	// [in] USHORT PropertyLength, [in] USHORT UserDataLength, [in] PBYTE UserData, [in, out] PULONG BufferSize, [out, optional] PWCHAR
	// Buffer, [out] PUSHORT UserDataConsumed );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhFormatProperty", MinClient = PInvokeClient.Windows7)]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhFormatProperty(SafeCoTaskMemStruct<TRACE_EVENT_INFO> EventInfo, [In, Optional] IntPtr MapInfo, uint PointerSize,
		ushort PropertyInType, ushort PropertyOutType, ushort PropertyLength, ushort UserDataLength, [In] IntPtr UserData,
		ref uint BufferSize, [Out, Optional, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? Buffer, out ushort UserDataConsumed);

	/// <summary>Retrieves the value of a decoding parameter.</summary>
	/// <param name="Handle">
	/// <para>Type: <c>TDH_HANDLE</c></para>
	/// <para>A valid decoding handle.</para>
	/// </param>
	/// <param name="TdhContext">
	/// <para>Type: <c>PTDH_CONTEXT</c></para>
	/// <para>Array of context values. The array must not contain duplicate context types.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// One or more of the parameters is incorrect. This error is returned if the <c>Handle</c> or <c>TdhContext</c> parameter is
	/// <c>NULL</c>. This error is also returned if the <c>ParameterValue</c> member of the TDH_CONTEXT struct pointed to by the
	/// <c>TdhContext</c> parameter does not exist.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Memory allocations failed.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhgetdecodingparameter Win32Error TdhGetDecodingParameter( [in]
	// TDH_HANDLE Handle, [in, out] PTDH_CONTEXT TdhContext );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhGetDecodingParameter", MinClient = PInvokeClient.Windows8)]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhGetDecodingParameter([In] TDH_HANDLE Handle, [In, Out, MarshalAs(UnmanagedType.LPArray)] TDH_CONTEXT[] TdhContext);

	/// <summary>Retrieves metadata about an event.</summary>
	/// <param name="Event">The event record passed to your EventRecordCallback callback. For details, see the EVENT_RECORD structure.</param>
	/// <param name="TdhContextCount">Number of elements in <c>pTdhContext</c>.</param>
	/// <param name="TdhContext">
	/// Array of context values for WPP or classic ETW events only; otherwise, <c>NULL</c>. For details, see the TDH_CONTEXT structure. The
	/// array must not contain duplicate context types.
	/// </param>
	/// <param name="Buffer">User-allocated buffer to receive the event information. For details, see the TRACE_EVENT_INFO structure.</param>
	/// <param name="BufferSize">
	/// Size, in bytes, of the <c>pBuffer</c> buffer. If the function succeeds, this parameter receives the size of the buffer used. If the
	/// buffer is too small, the function returns ERROR_INSUFFICIENT_BUFFER and sets this parameter to the required buffer size. If the
	/// buffer size is zero on input, no data is returned in the buffer and this parameter receives the required buffer size.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>
	/// The size of the <c>pBuffer</c> buffer is too small. Use the required buffer size set in <c>pBufferSize</c> to allocate a new buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>The schema for the event was not found.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>
	/// The <c>resourceFileName</c> attribute in the manifest contains the location of the provider binary. When you register the manifest,
	/// the location is written to the registry. TDH was unable to find the binary based on the registered location.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WMI_SERVER_UNAVAILABLE</c></term>
	/// <term>The WMI service is not available.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the event is a WPP or legacy ETW event, you can specify context information that is used to help parse the event information. The
	/// event is a WPP event if the EVENT_HEADER_FLAG_TRACE_MESSAGE flag is set in the <c>Flags</c> member of EVENT_HEADER (see the
	/// <c>EventHeader</c> member of EVENT_RECORD). The event is a legacy ETW event if the EVENT_HEADER_FLAG_CLASSIC_HEADER flag is set.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that shows how to retrieve metadata about an event, see Using TdhFormatProperty to Consume Event Data.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhgeteventinformation Win32Error TdhGetEventInformation( [in]
	// PEVENT_RECORD Event, [in] ULONG TdhContextCount, [in] PTDH_CONTEXT TdhContext, [out] PTRACE_EVENT_INFO Buffer, [in, out] PULONG
	// BufferSize );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhGetEventInformation")]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhGetEventInformation(in EVENT_RECORD Event, uint TdhContextCount,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TDH_CONTEXT[]? TdhContext, [Out] IntPtr Buffer, ref uint BufferSize);

	/// <summary>Retrieves metadata about an event.</summary>
	/// <param name="Event">The event record passed to your EventRecordCallback callback. For details, see the EVENT_RECORD structure.</param>
	/// <param name="TdhContext">
	/// Array of context values for WPP or classic ETW events only; otherwise, <c>NULL</c>. For details, see the TDH_CONTEXT structure. The
	/// array must not contain duplicate context types.
	/// </param>
	/// <param name="Buffer">Receives the event information. For details, see the TRACE_EVENT_INFO structure.</param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>The schema for the event was not found.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>
	/// The <c>resourceFileName</c> attribute in the manifest contains the location of the provider binary. When you register the manifest,
	/// the location is written to the registry. TDH was unable to find the binary based on the registered location.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WMI_SERVER_UNAVAILABLE</c></term>
	/// <term>The WMI service is not available.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the event is a WPP or legacy ETW event, you can specify context information that is used to help parse the event information. The
	/// event is a WPP event if the EVENT_HEADER_FLAG_TRACE_MESSAGE flag is set in the <c>Flags</c> member of EVENT_HEADER (see the
	/// <c>EventHeader</c> member of EVENT_RECORD). The event is a legacy ETW event if the EVENT_HEADER_FLAG_CLASSIC_HEADER flag is set.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhgeteventinformation Win32Error TdhGetEventInformation( [in]
	// PEVENT_RECORD Event, [in] ULONG TdhContextCount, [in] PTDH_CONTEXT TdhContext, [out] PTRACE_EVENT_INFO Buffer, [in, out] PULONG
	// BufferSize );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhGetEventInformation")]
	public static Win32Error TdhGetEventInformation([In] EVENT_RECORD Event, [In, Optional] TDH_CONTEXT[]? TdhContext, out SafeCoTaskMemStruct<TRACE_EVENT_INFO> Buffer) =>
		GetMem((IntPtr p, ref uint s) => TdhGetEventInformation(Event, (uint)(TdhContext?.Length ?? 0), TdhContext, p, ref s), out Buffer);

	/// <summary>Retrieves information about the event map contained in the event.</summary>
	/// <param name="pEvent">The event record passed to your EventRecordCallback callback. For details, see the EVENT_RECORD structure.</param>
	/// <param name="pMapName">
	/// Null-terminated Unicode string that contains the name of the map attribute value. The name comes from the <c>MapNameOffset</c> member
	/// of the EVENT_PROPERTY_INFO structure.
	/// </param>
	/// <param name="pBuffer">
	/// User-allocated buffer to receive the event map. The map could be a value map, bitmap, or pattern map. For details, see the
	/// EVENT_MAP_INFO structure.
	/// </param>
	/// <param name="pBufferSize">
	/// Size, in bytes, of the <c>pBuffer</c> buffer. If the function succeeds, this parameter receives the size of the buffer used. If the
	/// buffer is too small, the function returns ERROR_INSUFFICIENT_BUFFER and sets this parameter to the required buffer size. If the
	/// buffer size is zero on input, no data is returned in the buffer and this parameter receives the required buffer size.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>
	/// The size of the <c>pBuffer</c> buffer is too small. Use the required buffer size set in <c>pBufferSize</c> to allocate a new buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>The schema for the event was not found or the specified map was not found.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>
	/// The <c>resourceFileName</c> attribute in the manifest contains the location of the provider binary. When you register the manifest,
	/// the location is written to the registry. TDH was unable to find the binary based on the registered location.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WMI_SERVER_UNAVAILABLE</c></term>
	/// <term>The WMI service is not available.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>You cannot use this function to retrieve event map information for WPP events.</para>
	/// <para>
	/// For maps defined in a manifest, the string will contain a space at the end of the string. For example, if the value is mapped to
	/// "Monday" in the manifest, the string is returned as "Monday ".
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that shows how to call this function, see Using TdhGetProperty to Consume Event Data.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhgeteventmapinformation Win32Error TdhGetEventMapInformation( [in]
	// PEVENT_RECORD pEvent, [in] PWSTR pMapName, [out] PEVENT_MAP_INFO pBuffer, [in, out] ULONG *pBufferSize );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhGetEventMapInformation")]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhGetEventMapInformation(in EVENT_RECORD pEvent, [MarshalAs(UnmanagedType.LPWStr)] string pMapName,
		[Out, Optional] IntPtr pBuffer, ref uint pBufferSize);

	/// <summary>Retrieves information about the event map contained in the event.</summary>
	/// <param name="pEvent">The event record passed to your EventRecordCallback callback. For details, see the EVENT_RECORD structure.</param>
	/// <param name="pMapName">
	/// String that contains the name of the map attribute value. The name comes from the <c>MapNameOffset</c> member
	/// of the EVENT_PROPERTY_INFO structure.
	/// </param>
	/// <param name="pBuffer">
	/// Receives the event map. The map could be a value map, bitmap, or pattern map. For details, see the EVENT_MAP_INFO structure.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>The schema for the event was not found or the specified map was not found.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>
	/// The <c>resourceFileName</c> attribute in the manifest contains the location of the provider binary. When you register the manifest,
	/// the location is written to the registry. TDH was unable to find the binary based on the registered location.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WMI_SERVER_UNAVAILABLE</c></term>
	/// <term>The WMI service is not available.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>You cannot use this function to retrieve event map information for WPP events.</para>
	/// <para>
	/// For maps defined in a manifest, the string will contain a space at the end of the string. For example, if the value is mapped to
	/// "Monday" in the manifest, the string is returned as "Monday ".
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that shows how to call this function, see Using TdhGetProperty to Consume Event Data.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhgeteventmapinformation Win32Error TdhGetEventMapInformation( [in]
	// PEVENT_RECORD pEvent, [in] PWSTR pMapName, [out] PEVENT_MAP_INFO pBuffer, [in, out] ULONG *pBufferSize );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhGetEventMapInformation")]
	public static Win32Error TdhGetEventMapInformation([In] EVENT_RECORD pEvent, [MarshalAs(UnmanagedType.LPWStr)] string pMapName,
		out SafeCoTaskMemStruct<EVENT_MAP_INFO> pBuffer) => GetMem((IntPtr p, ref uint sz) => TdhGetEventMapInformation(pEvent, pMapName, p, ref sz), out pBuffer);

	/// <summary>The <c>TdhGetManifestEventInformation</c> function retrieves metadata about an event in a manifest.</summary>
	/// <param name="ProviderGuid">A GUID that identifies the manifest provider whose event metadata you want to retrieve.</param>
	/// <param name="EventDescriptor">
	/// A pointer to the event descriptor that contains information such as event id, version, op-code, and keyword. For details, see the
	/// EVENT_DESCRIPTOR structure
	/// </param>
	/// <param name="Buffer">
	/// A user-allocated buffer to receive the metadata about an event in a provider manifest. For details, see the TRACE_EVENT_INFO structure.
	/// </param>
	/// <param name="BufferSize">
	/// The size, in bytes, of the buffer pointed to by the <c>Buffer</c> parameter. If the function succeeds, this parameter receives the
	/// size of the buffer used. If the buffer is too small, the function returns <c>ERROR_INSUFFICIENT_BUFFER</c> and sets this parameter to
	/// the required buffer size. If the buffer size is zero on input, no data is returned in the buffer and this parameter receives the
	/// required buffer size.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>ERROR_SUCCESS</c> if successful. Otherwise, this function returns one of the following return codes in addition to others.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_EMPTY</c></term>
	/// <term>There are no events defined for the provider GUID in the manifest.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>The metadata for the provider was not found.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>
	/// The size of the buffer pointed to by the <c>Buffer</c> parameter is too small. Use the required buffer size set in the
	/// <c>BufferSize</c> parameter to allocate a new buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>The schema information for supplied provider GUID was not found.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhgetmanifesteventinformation Win32Error
	// TdhGetManifestEventInformation( [in] LPGUID ProviderGuid, [in] PEVENT_DESCRIPTOR EventDescriptor, [out] PTRACE_EVENT_INFO Buffer, [in,
	// out] ULONG *BufferSize );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhGetManifestEventInformation", MinClient = PInvokeClient.Windows81)]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhGetManifestEventInformation(in Guid ProviderGuid, in EVENT_DESCRIPTOR EventDescriptor,
		[Out, Optional] IntPtr Buffer, ref uint BufferSize);

	/// <summary>The <c>TdhGetManifestEventInformation</c> function retrieves metadata about an event in a manifest.</summary>
	/// <param name="ProviderGuid">A GUID that identifies the manifest provider whose event metadata you want to retrieve.</param>
	/// <param name="EventDescriptor">
	/// A pointer to the event descriptor that contains information such as event id, version, op-code, and keyword. For details, see the
	/// EVENT_DESCRIPTOR structure
	/// </param>
	/// <param name="Buffer">Receives the metadata about an event in a provider manifest. For details, see the TRACE_EVENT_INFO structure.</param>
	/// <returns>
	/// <para>
	/// Returns <c>ERROR_SUCCESS</c> if successful. Otherwise, this function returns one of the following return codes in addition to others.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_EMPTY</c></term>
	/// <term>There are no events defined for the provider GUID in the manifest.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>The metadata for the provider was not found.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>The schema information for supplied provider GUID was not found.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhgetmanifesteventinformation Win32Error
	// TdhGetManifestEventInformation( [in] LPGUID ProviderGuid, [in] PEVENT_DESCRIPTOR EventDescriptor, [out] PTRACE_EVENT_INFO Buffer, [in,
	// out] ULONG *BufferSize );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhGetManifestEventInformation", MinClient = PInvokeClient.Windows81)]
	public static Win32Error TdhGetManifestEventInformation([In] Guid ProviderGuid, [In] EVENT_DESCRIPTOR EventDescriptor,
		out SafeCoTaskMemStruct<TRACE_EVENT_INFO> Buffer) => GetMem((IntPtr p, ref uint sz) => TdhGetManifestEventInformation(ProviderGuid, EventDescriptor, p, ref sz), out Buffer);

	/// <summary>Retrieves a property value from the event data.</summary>
	/// <param name="pEvent">The event record passed to your EventRecordCallback callback. For details, see the EVENT_RECORD structure.</param>
	/// <param name="TdhContextCount">Number of elements in <c>pTdhContext</c>.</param>
	/// <param name="pTdhContext">
	/// Array of context values for WPP or classic ETW events only; otherwise, <c>NULL</c>. For details, see the TDH_CONTEXT structure. The
	/// array must not contain duplicate context types.
	/// </param>
	/// <param name="PropertyDataCount">Number of data descriptor structures in <c>pPropertyData</c>.</param>
	/// <param name="pPropertyData">
	/// <para>Array of PROPERTY_DATA_DESCRIPTOR structures that defines the property to retrieve.</para>
	/// <para>
	/// If you called the TdhGetPropertySize function to retrieve the required buffer size for the property, you can use the same data descriptors.
	/// </para>
	/// <para>
	/// If you are retrieving a property that is not a member of a structure, you can specify a single data descriptor. If you are retrieving
	/// a property that is a member of a structure, specify an array of two data descriptors (structures cannot contain or reference other structures).
	/// </para>
	/// </param>
	/// <param name="BufferSize">
	/// Size of the <c>pBuffer</c> buffer, in bytes. You can get this value from the <c>pPropertySize</c> parameter when calling
	/// TdhGetPropertySize function.
	/// </param>
	/// <param name="pBuffer">User-allocated buffer that receives the property data.</param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>The schema for the event was not found or the specified property was not found.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>The pBuffer buffer is too small. To get the required buffer size, call TdhGetPropertySize.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>
	/// The <c>resourceFileName</c> attribute in the manifest contains the location of the provider binary. When you register the manifest,
	/// the location is written to the registry. TDH was unable to find the binary based on the registered location.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WMI_SERVER_UNAVAILABLE</c></term>
	/// <term>The WMI service is not available.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the event is a WPP or classic ETW event, you can specify context information that is used to help parse the event information. The
	/// event is a WPP event if the EVENT_HEADER_FLAG_TRACE_MESSAGE flag is set in the <c>Flags</c> member of EVENT_HEADER (see the
	/// <c>EventHeader</c> member of EVENT_RECORD). The event is a legacy ETW event if the EVENT_HEADER_FLAG_CLASSIC_HEADER flag is set.
	/// </para>
	/// <para>For a list of properties for WPP events and their data types, see PROPERTY_DATA_DESCRIPTOR.</para>
	/// <para>Examples</para>
	/// <para>
	/// For an example that shows how to call this function to retrieve the value of a top-level property or the member of a structure, see
	/// Using TdhGetProperty to Consume Event Data.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhgetproperty Win32Error TdhGetProperty( [in] PEVENT_RECORD pEvent,
	// [in] ULONG TdhContextCount, [in] PTDH_CONTEXT pTdhContext, [in] ULONG PropertyDataCount, [in] PPROPERTY_DATA_DESCRIPTOR pPropertyData,
	// [in] ULONG BufferSize, [out] PBYTE pBuffer );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhGetProperty")]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhGetProperty(in EVENT_RECORD pEvent, uint TdhContextCount,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TDH_CONTEXT[]? pTdhContext, uint PropertyDataCount,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] PROPERTY_DATA_DESCRIPTOR[] pPropertyData,
		uint BufferSize, [Out] IntPtr pBuffer);

	/// <summary>Retrieves the size of one or more property values in the event data.</summary>
	/// <param name="pEvent">The event record passed to your EventRecordCallback callback. For details, see the EVENT_RECORD structure.</param>
	/// <param name="TdhContextCount">Number of elements in <c>pTdhContext</c>.</param>
	/// <param name="pTdhContext">
	/// Array of context values for WPP or classic ETW events only, otherwise, <c>NULL</c>. For details, see the TDH_CONTEXT structure. The
	/// array must not contain duplicate context types.
	/// </param>
	/// <param name="PropertyDataCount">Number of data descriptor structures in <c>pPropertyData</c>.</param>
	/// <param name="pPropertyData">
	/// <para>Array of PROPERTY_DATA_DESCRIPTOR structures that define the property whose size you want to retrieve.</para>
	/// <para>You can pass this same array to the TdhGetProperty function to retrieve the property data.</para>
	/// <para>
	/// If you are retrieving the size of a property that is not a member of a structure, you can specify a single data descriptor. If you
	/// are retrieving the size of a property that is a member of a structure, specify an array of two data descriptors (structures cannot
	/// contain or reference other structures). For more information on specifying this parameter, see the example code below.
	/// </para>
	/// </param>
	/// <param name="pPropertySize">
	/// Size of the property, in bytes. Use this value to allocate the buffer passed in the <c>pBuffer</c> parameter of the TdhGetProperty function.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>
	/// The schema for the event was not found or the specified map was not found. If you used a MOF class to define your event, TDH looks
	/// for the schema in the WMI repository. If you used a manifest to define your event, TDH looks in the provider's resources. If you use
	/// a manifest, the <c>resourceFileName</c> attribute of the <c>provider</c> element defines the location where TDH expects to find the resources.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>
	/// The <c>resourceFileName</c> attribute in the manifest contains the location of the provider binary. When you register the manifest,
	/// the location is written to the registry. TDH was unable to find the binary based on the registered location.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WMI_SERVER_UNAVAILABLE</c></term>
	/// <term>The WMI service is not available.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the event is a WPP or classic ETW event, you can specify context information that is used to help parse the event information. The
	/// event is a WPP event if the EVENT_HEADER_FLAG_TRACE_MESSAGE flag is set in the <c>Flags</c> member of EVENT_HEADER (see the
	/// <c>EventHeader</c> member of EVENT_RECORD). The event is a legacy ETW event if the EVENT_HEADER_FLAG_CLASSIC_HEADER flag is set.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that shows how to call this function, see Using TdhGetProperty to Consume Event Data.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhgetpropertysize Win32Error TdhGetPropertySize( [in] PEVENT_RECORD
	// pEvent, [in] ULONG TdhContextCount, [in] PTDH_CONTEXT pTdhContext, [in] ULONG PropertyDataCount, [in] PPROPERTY_DATA_DESCRIPTOR
	// pPropertyData, [out] ULONG *pPropertySize );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhGetPropertySize")]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhGetPropertySize(in EVENT_RECORD pEvent, uint TdhContextCount,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TDH_CONTEXT[]? pTdhContext, uint PropertyDataCount,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] PROPERTY_DATA_DESCRIPTOR[] pPropertyData,
		out uint pPropertySize);

	/// <summary>Retrieves the formatted WPP message embedded into an EVENT_RECORD structure.</summary>
	/// <param name="Handle">
	/// <para>Type: <c>TDH_HANDLE</c></para>
	/// <para>A valid decoding handle.</para>
	/// </param>
	/// <param name="EventRecord">
	/// <para>Type: <c>PEVENT_RECORD</c></para>
	/// <para>The event record passed to your EventRecordCallback callback.</para>
	/// </param>
	/// <param name="BufferSize">
	/// <para>Type: <c>PULONG</c></para>
	/// <para>Size of the <c>Buffer</c> parameter, in bytes.</para>
	/// </param>
	/// <param name="Buffer">
	/// <para>Type: <c>PBYTE</c></para>
	/// <para>User-allocated buffer that receives the property data.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>The specified property was not found.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term><c>BufferSize</c> is too small. To get the required buffer size, call TdhGetPropertySize.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>To retrieve a specific property instead of the decoded event message without specifying a property name, call TdhGetWppProperty.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhgetwppmessage TDHSTATUS TdhGetWppMessage( [in] TDH_HANDLE Handle,
	// [in] PEVENT_RECORD EventRecord, [in, out] PULONG BufferSize, [out] PBYTE Buffer );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhGetWppMessage", MinClient = PInvokeClient.Windows8)]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhGetWppMessage([In] TDH_HANDLE Handle, in EVENT_RECORD EventRecord, ref uint BufferSize, [Out] IntPtr Buffer);

	/// <summary>Retrieves a specific property associated with a WPP message.</summary>
	/// <param name="Handle">
	/// <para>Type: <c>TDH_HANDLE</c></para>
	/// <para>A valid decoding handle.</para>
	/// </param>
	/// <param name="EventRecord">
	/// <para>Type: <c>PEVENT_RECORD</c></para>
	/// <para>The event record passed to your EventRecordCallback callback.</para>
	/// </param>
	/// <param name="PropertyName">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>The name of the property to retrieve.</para>
	/// <para>For a list of possible values, see PROPERTY_DATA_DESCRIPTOR.</para>
	/// </param>
	/// <param name="BufferSize">
	/// <para>Type: <c>PULONG</c></para>
	/// <para>Size of the <c>Buffer</c> parameter, in bytes.</para>
	/// </param>
	/// <param name="Buffer">
	/// <para>Type: <c>PBYTE</c></para>
	/// <para>User-allocated buffer that receives the property data.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>The specified property was not found.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>
	/// <c>BufferSize</c> is too small. To get the required buffer size, call TdhGetWppProperty twice, once with a null buffer and a pointer
	/// to retrieve the buffer size and then again with the correctly sized buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// One or more of the parameters is incorrect. This error is returned if the <c>Handle</c>, <c>EventRecord</c>, <c>PropertyName</c>, or
	/// <c>Buffer</c> parameter is <c>NULL</c>.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>To retrieve only the decoded event message without specifying a property name, call TdhGetWppMessage.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhgetwppproperty Win32Error TdhGetWppProperty( [in] TDH_HANDLE Handle,
	// [in] PEVENT_RECORD EventRecord, [in] PWSTR PropertyName, [in, out] PULONG BufferSize, [out] PBYTE Buffer );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhGetWppProperty", MinClient = PInvokeClient.Windows8)]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhGetWppProperty([In] TDH_HANDLE Handle, in EVENT_RECORD EventRecord,
		[MarshalAs(UnmanagedType.LPWStr)] string PropertyName, ref uint BufferSize, [Out] IntPtr Buffer);

	/// <summary>Loads the manifest used to decode a log file.</summary>
	/// <param name="Manifest">The full path to the manifest.</param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>The manifest file was not found at the specified path.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>Manifest</c> parameter cannot be <c>NULL</c> and the path cannot exceed MAX_PATH.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_XML_PARSE_ERROR</c></term>
	/// <term>The manifest did not pass validation. To determine the validation errors, run the manifest through the message compiler (mc.exe).</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To consume events, TDH requires the provider's manifest. Typically, you decode the log file on a computer that contains the provider.
	/// Since the provider includes the manifest as a resource, TDH uses the provider to get the manifest. To decode the log file on a
	/// computer that does not contain the provider, you must first use the TraceRpt.exe executable to export the manifest (see the –export
	/// switch) from the provider on a computer that does contain the provider. After you have the manifest file, you can decode the log file
	/// on a computer that does not contain the provider.
	/// </para>
	/// <para>
	/// You need to call this function before decoding the first event. For example, you can call this function before calling the OpenTrace
	/// function. After processing all the events, call the TdhUnloadManifest function.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhloadmanifest Win32Error TdhLoadManifest( [in] PWSTR Manifest );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhLoadManifest", MinClient = PInvokeClient.Windows7)]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhLoadManifest([In, MarshalAs(UnmanagedType.LPWStr)] string Manifest);

	/// <summary>Takes a NULL-terminated path to a binary file that contains metadata resources needed to decode a specific event provider.</summary>
	/// <param name="BinaryPath">
	/// <para>Type: <c>PWSTR</c></para>
	/// <para>Path to the ETW provider binary that contains the metadata resources.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>The file pointed to by <c>BinaryPath</c> was not found.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Memory allocations failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_RESOURCE_NOT_FOUND</c></term>
	/// <term>The file does not contain any eventing metadata resources.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The GUIDs and BinaryPath string are cached.</para>
	/// <para>
	/// When metadata is requested for a given event or provider, but the provider is not installed in the system, the cache of binaries will
	/// be searched.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhloadmanifestfrombinary Win32Error TdhLoadManifestFromBinary( [in]
	// PWSTR BinaryPath );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhLoadManifestFromBinary", MinClient = PInvokeClient.Windows8)]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhLoadManifestFromBinary([In, MarshalAs(UnmanagedType.LPWStr)] string BinaryPath);

	/// <summary>Loads the manifest from memory.</summary>
	/// <param name="pData">
	/// <para>Type: <c>const void</c>*</para>
	/// <para>Pointer to the data to be stored.</para>
	/// </param>
	/// <param name="cbData">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Size of the data in the buffer pointed to by pData, in bytes.</para>
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>The file pointed to by <c>pData</c> was not found.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Memory allocations failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_RESOURCE_NOT_FOUND</c></term>
	/// <term>The file does not contain any eventing metadata resources.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhloadmanifestfrommemory Win32Error TdhLoadManifestFromMemory( [in]
	// LPCVOID pData, [in] ULONG cbData );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhLoadManifestFromMemory", MinClient = PInvokeClient.Windows10)]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhLoadManifestFromMemory([In] IntPtr pData, uint cbData);

	/// <summary>Opens a decoding handle.</summary>
	/// <param name="Handle">
	/// <para>Type: <c>PTDH_HANDLE</c></para>
	/// <para>A valid decoding handle.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The parameter is incorrect. This error is returned if the <c>Handle</c> parameter is <c>NULL</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Memory allocations failed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>Call TdhCloseDecodingHandle to free the returned handle.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhopendecodinghandle Win32Error TdhOpenDecodingHandle( [out]
	// PTDH_HANDLE Handle );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhOpenDecodingHandle", MinClient = PInvokeClient.Windows8)]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhOpenDecodingHandle(out TDH_HANDLE Handle);

	/// <summary>
	/// Retrieves information for the specified field from the event descriptions for those field values that match the given value.
	/// </summary>
	/// <param name="pGuid">GUID that identifies the provider whose information you want to retrieve.</param>
	/// <param name="EventFieldValue">
	/// Retrieve information about the field if the field's value matches this value. If the field type is a keyword, the information is
	/// retrieved for each event keyword bit contained in the mask.
	/// </param>
	/// <param name="EventFieldType">
	/// Specify the type of field for which you want to retrieve information. For possible values, see the EVENT_FIELD_TYPE enumeration.
	/// </param>
	/// <param name="pBuffer">User-allocated buffer to receive the field information. For details, see the PROVIDER_FIELD_INFOARRAY structure.</param>
	/// <param name="pBufferSize">
	/// Size, in bytes, of the <c>pBuffer</c> buffer. If the function succeeds, this parameter receives the size of the buffer used. If the
	/// buffer is too small, the function returns ERROR_INSUFFICIENT_BUFFER and sets this parameter to the required buffer size. If the
	/// buffer size is zero on input, no data is returned in the buffer and this parameter receives the required buffer size.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>
	/// The size of the <c>pBuffer</c> buffer is too small. Use the required buffer size set in <c>pBufferSize</c> to allocate a new buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>The requested field type is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>
	/// The manifest or MOF class was not found or does not contain information for the requested field type, or a field whose value matches
	/// the given value was not found.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>
	/// The <c>resourceFileName</c> attribute in the manifest contains the location of the provider binary. When you register the manifest,
	/// the location is written to the registry. TDH was unable to find the binary based on the registered location.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function uses the XML manifest or WMI MOF class to retrieve the information.</para>
	/// <para>Examples</para>
	/// <para>The following example shows how to query information contained in the manifest or MOF class for the requested field.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhqueryproviderfieldinformation Win32Error
	// TdhQueryProviderFieldInformation( [in] LPGUID pGuid, [in] ULONGLONG EventFieldValue, [in] EVENT_FIELD_TYPE EventFieldType, [out]
	// PPROVIDER_FIELD_INFOARRAY pBuffer, [in, out] ULONG *pBufferSize );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhQueryProviderFieldInformation")]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhQueryProviderFieldInformation(in Guid pGuid, ulong EventFieldValue,
		[In] EVENT_FIELD_TYPE EventFieldType, [Out, Optional] IntPtr pBuffer, ref uint pBufferSize);

	/// <summary>
	/// Retrieves information for the specified field from the event descriptions for those field values that match the given value.
	/// </summary>
	/// <param name="pGuid">GUID that identifies the provider whose information you want to retrieve.</param>
	/// <param name="EventFieldValue">
	/// Retrieve information about the field if the field's value matches this value. If the field type is a keyword, the information is
	/// retrieved for each event keyword bit contained in the mask.
	/// </param>
	/// <param name="EventFieldType">
	/// Specify the type of field for which you want to retrieve information. For possible values, see the EVENT_FIELD_TYPE enumeration.
	/// </param>
	/// <param name="pBuffer">Receives the field information. For details, see the PROVIDER_FIELD_INFOARRAY structure.</param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>The requested field type is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>
	/// The manifest or MOF class was not found or does not contain information for the requested field type, or a field whose value matches
	/// the given value was not found.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>
	/// The <c>resourceFileName</c> attribute in the manifest contains the location of the provider binary. When you register the manifest,
	/// the location is written to the registry. TDH was unable to find the binary based on the registered location.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function uses the XML manifest or WMI MOF class to retrieve the information.</para>
	/// <para>Examples</para>
	/// <para>The following example shows how to query information contained in the manifest or MOF class for the requested field.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhqueryproviderfieldinformation Win32Error
	// TdhQueryProviderFieldInformation( [in] LPGUID pGuid, [in] ULONGLONG EventFieldValue, [in] EVENT_FIELD_TYPE EventFieldType, [out]
	// PPROVIDER_FIELD_INFOARRAY pBuffer, [in, out] ULONG *pBufferSize );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhQueryProviderFieldInformation")]
	public static Win32Error TdhQueryProviderFieldInformation([In] Guid pGuid, ulong EventFieldValue,
		[In] EVENT_FIELD_TYPE EventFieldType, out SafeCoTaskMemStruct<PROVIDER_FIELD_INFOARRAY> pBuffer) =>
		GetMem((IntPtr p, ref uint s) => TdhQueryProviderFieldInformation(pGuid, EventFieldValue, EventFieldType, p, ref s), out pBuffer);

	/// <summary>Sets the value of a decoding parameter.</summary>
	/// <param name="Handle">
	/// <para>Type: <c>TDH_HANDLE</c></para>
	/// <para>A valid decoding handle.</para>
	/// </param>
	/// <param name="TdhContext">
	/// <para>Type: <c>PTDH_CONTEXT</c></para>
	/// <para>Array of context values. The array must not contain duplicate context types.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// One or more of the parameters is incorrect. This error is returned if the <c>Handle</c> or <c>TdhContext</c> parameter is
	/// <c>NULL</c>. This error is also returned if the <c>ParameterValue</c> member of the TDH_CONTEXT struct pointed to by the
	/// <c>TdhContext</c> parameter does not exist.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Memory allocations failed.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhsetdecodingparameter Win32Error TdhSetDecodingParameter( [in]
	// TDH_HANDLE Handle, [in] PTDH_CONTEXT TdhContext );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhSetDecodingParameter")]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhSetDecodingParameter([In] TDH_HANDLE Handle, [In, MarshalAs(UnmanagedType.LPArray)] TDH_CONTEXT[] TdhContext);

	/// <summary>Unloads the manifest that was loaded by the TdhLoadManifest function.</summary>
	/// <param name="Manifest">The full path to the loaded manifest.</param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>The manifest file was not found at the specified path.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>Manifest</c> parameter cannot be <c>NULL</c> and the path cannot exceed MAX_PATH.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_XML_PARSE_ERROR</c></term>
	/// <term>The manifest did not pass validation. To determine the validation errors, run the manifest through the message compiler (mc.exe).</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>You must call this function after processing all the events. For example, you can call this function after calling CloseTrace.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhunloadmanifest Win32Error TdhUnloadManifest( [in] PWSTR Manifest );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhUnloadManifest")]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhUnloadManifest([In, MarshalAs(UnmanagedType.LPWStr)] string Manifest);

	/// <summary>Unloads the manifest from memory.</summary>
	/// <param name="pData">
	/// <para>Type: <c>const void</c>*</para>
	/// <para>Pointer to the data to be stored.</para>
	/// </param>
	/// <param name="cbData">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Size of the data in the buffer pointed to by pData, in bytes.</para>
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful. Otherwise, this function returns one of the following return codes in addition to others.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>The file pointed to by <c>pData</c> was not found.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Memory allocations failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_RESOURCE_NOT_FOUND</c></term>
	/// <term>The file does not contain any eventing metadata resources.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tdhunloadmanifestfrommemory Win32Error TdhUnloadManifestFromMemory(
	// [in] LPCVOID pData, [in] ULONG cbData );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TdhUnloadManifestFromMemory")]
	[DllImport(Lib_Tdh, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TdhUnloadManifestFromMemory([In] IntPtr pData, uint cbData);

	/// <summary>Macro that retrieves the Trace Event Information (TEI) activity ID name.</summary>
	/// <param name="EventInfo">
	/// A TRACE_EVENT_INFO structure that contains the event information. To get this structure, call the TdhGetEventInformation function.
	/// </param>
	/// <returns>The TEI activity ID name, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tei_activityid_name TDH_INLINE PWSTR TEI_ACTIVITYID_NAME( [in]
	// PTRACE_EVENT_INFO EventInfo );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TEI_ACTIVITYID_NAME")]
	public static string? TEI_ACTIVITYID_NAME(SafeCoTaskMemStruct<TRACE_EVENT_INFO>? EventInfo) =>
		EventInfo?.GetOffsetString(EventInfo.Value.ActivityIDNameOffset);

	/// <summary>Macro that retrieves the Trace Event Information (TEI) channel name.</summary>
	/// <param name="EventInfo">
	/// A TRACE_EVENT_INFO structure that contains the event information. To get this structure, call the TdhGetEventInformation function.
	/// </param>
	/// <returns>The TEI activity channel name, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tei_channel_name TDH_INLINE PWSTR TEI_CHANNEL_NAME( [in]
	// PTRACE_EVENT_INFO EventInfo );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TEI_CHANNEL_NAME")]
	public static string? TEI_CHANNEL_NAME(SafeCoTaskMemStruct<TRACE_EVENT_INFO>? EventInfo) =>
		EventInfo?.GetOffsetString(EventInfo.Value.ChannelNameOffset);

	/// <summary>Macro that retrieves the Trace Event Information (TEI) message.</summary>
	/// <param name="EventInfo">
	/// A TRACE_EVENT_INFO structure that contains the event information. To get this structure, call the TdhGetEventInformation function.
	/// </param>
	/// <returns>The TEI message, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tei_event_message TDH_INLINE PWSTR TEI_EVENT_MESSAGE( [in]
	// PTRACE_EVENT_INFO EventInfo );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TEI_EVENT_MESSAGE")]
	public static string? TEI_EVENT_MESSAGE(SafeCoTaskMemStruct<TRACE_EVENT_INFO>? EventInfo) =>
		EventInfo?.GetOffsetString(EventInfo.Value.EventMessageOffset);

	/// <summary>Macro that retrieves the Trace Event Information (TEI) name.</summary>
	/// <param name="EventInfo">
	/// A TRACE_EVENT_INFO structure that contains the event information. To get this structure, call the TdhGetEventInformation function.
	/// </param>
	/// <returns>The TEI name, or NULL.</returns>
	[PInvokeData("tdh.h")]
	public static string? TEI_EVENT_NAME(SafeCoTaskMemStruct<TRACE_EVENT_INFO>? EventInfo) =>
		EventInfo?.GetOffsetString(EventInfo.Value.EventNameOffset);

	/// <summary>Macro that retrieves the Trace Event Information (TEI) keywords name.</summary>
	/// <param name="EventInfo">
	/// A TRACE_EVENT_INFO structure that contains the event information. To get this structure, call the TdhGetEventInformation function.
	/// </param>
	/// <returns>The TEI keywords name, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tei_keywords_name TDH_INLINE PWSTR TEI_KEYWORDS_NAME( [in]
	// PTRACE_EVENT_INFO EventInfo );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TEI_KEYWORDS_NAME")]
	public static string? TEI_KEYWORDS_NAME(SafeCoTaskMemStruct<TRACE_EVENT_INFO>? EventInfo) =>
		EventInfo?.GetOffsetString(EventInfo.Value.KeywordsNameOffset);

	/// <summary>Macro that retrieves the Trace Event Information (TEI) level name.</summary>
	/// <param name="EventInfo">
	/// A TRACE_EVENT_INFO structure that contains the event information. To get this structure, call the TdhGetEventInformation function.
	/// </param>
	/// <returns>The TEI level name, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tei_level_name TDH_INLINE PWSTR TEI_LEVEL_NAME( [in] PTRACE_EVENT_INFO
	// EventInfo );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TEI_LEVEL_NAME")]
	public static string? TEI_LEVEL_NAME(SafeCoTaskMemStruct<TRACE_EVENT_INFO>? EventInfo) =>
		EventInfo?.GetOffsetString(EventInfo.Value.LevelNameOffset);

	/// <summary>Macro that retrieves the Trace Event Information (TEI) map name.</summary>
	/// <param name="EventInfo">
	/// A TRACE_EVENT_INFO structure that contains the event information. To get this structure, call the TdhGetEventInformation function.
	/// </param>
	/// <param name="Property">An EVENT_PROPERTY_INFO structure that contains the event property information.</param>
	/// <returns>The TEI map name, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tei_map_name TDH_INLINE PWSTR TEI_MAP_NAME( [in] PTRACE_EVENT_INFO
	// EventInfo, [in] PEVENT_PROPERTY_INFO Property );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TEI_MAP_NAME")]
	public static string? TEI_MAP_NAME(SafeCoTaskMemStruct<TRACE_EVENT_INFO>? EventInfo, in EVENT_PROPERTY_INFO Property) =>
		EventInfo?.GetOffsetString(Property.nonStructType.MapNameOffset);

	/// <summary>Macro that retrieves the Trace Event Information (TEI) opcode name.</summary>
	/// <param name="EventInfo">
	/// A TRACE_EVENT_INFO structure that contains the event information. To get this structure, call the TdhGetEventInformation function.
	/// </param>
	/// <returns>The TEI opcode name, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tei_opcode_name TDH_INLINE PWSTR TEI_OPCODE_NAME( [in]
	// PTRACE_EVENT_INFO EventInfo );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TEI_OPCODE_NAME")]
	public static string? TEI_OPCODE_NAME(SafeCoTaskMemStruct<TRACE_EVENT_INFO>? EventInfo) =>
		EventInfo?.GetOffsetString(EventInfo.Value.OpcodeNameOffset);

	/// <summary>Macro that retrieves the Trace Event Information (TEI) property name.</summary>
	/// <param name="EventInfo">
	/// A TRACE_EVENT_INFO structure that contains the event information. To get this structure, call the TdhGetEventInformation function.
	/// </param>
	/// <param name="Property">An EVENT_PROPERTY_INFO structure that contains the event property information.</param>
	/// <returns>The TEI property name, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tei_property_name TDH_INLINE PWSTR TEI_PROPERTY_NAME( [in]
	// PTRACE_EVENT_INFO EventInfo, PEVENT_PROPERTY_INFO Property );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TEI_PROPERTY_NAME")]
	public static string? TEI_PROPERTY_NAME(SafeCoTaskMemStruct<TRACE_EVENT_INFO>? EventInfo, in EVENT_PROPERTY_INFO Property) =>
		EventInfo?.GetOffsetString(Property.NameOffset);

	/// <summary>Macro that retrieves the Trace Event Information (TEI) provider message.</summary>
	/// <param name="EventInfo">
	/// A TRACE_EVENT_INFO structure that contains the event information. To get this structure, call the TdhGetEventInformation function.
	/// </param>
	/// <returns>The TEI provider message, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tei_provider_message TDH_INLINE PWSTR TEI_PROVIDER_MESSAGE( [in]
	// PTRACE_EVENT_INFO EventInfo );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TEI_PROVIDER_MESSAGE")]
	public static string? TEI_PROVIDER_MESSAGE(SafeCoTaskMemStruct<TRACE_EVENT_INFO>? EventInfo) =>
		EventInfo?.GetOffsetString(EventInfo.Value.ProviderMessageOffset);

	/// <summary>Macro that retrieves the Trace Event Information (TEI) provider name.</summary>
	/// <param name="EventInfo">
	/// A TRACE_EVENT_INFO structure that contains the event information. To get this structure, call the TdhGetEventInformation function.
	/// </param>
	/// <returns>The TEI provider name, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tei_provider_name TDH_INLINE PWSTR TEI_PROVIDER_NAME( [in]
	// PTRACE_EVENT_INFO EventInfo );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TEI_PROVIDER_NAME")]
	public static string? TEI_PROVIDER_NAME(SafeCoTaskMemStruct<TRACE_EVENT_INFO>? EventInfo) =>
		EventInfo?.GetOffsetString(EventInfo.Value.ProviderNameOffset);

	/// <summary>Macro that retrieves the Trace Event Information (TEI) related activity ID name.</summary>
	/// <param name="EventInfo">
	/// A TRACE_EVENT_INFO structure that contains the event information. To get this structure, call the TdhGetEventInformation function.
	/// </param>
	/// <returns>The TEI related activity ID name, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tei_relatedactivityid_name TDH_INLINE PWSTR TEI_RELATEDACTIVITYID_NAME(
	// [in] PTRACE_EVENT_INFO EventInfo );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TEI_RELATEDACTIVITYID_NAME")]
	public static string? TEI_RELATEDACTIVITYID_NAME(SafeCoTaskMemStruct<TRACE_EVENT_INFO>? EventInfo) =>
		EventInfo?.GetOffsetString(EventInfo.Value.RelatedActivityIDNameOffset);

	/// <summary>Macro that retrieves the Trace Event Information (TEI) task name.</summary>
	/// <param name="EventInfo">
	/// A TRACE_EVENT_INFO structure that contains the event information. To get this structure, call the TdhGetEventInformation function.
	/// </param>
	/// <returns>The TEI task name, or NULL.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/tdh/nf-tdh-tei_task_name TDH_INLINE PWSTR TEI_TASK_NAME( [in] PTRACE_EVENT_INFO
	// EventInfo );
	[PInvokeData("tdh.h", MSDNShortId = "NF:tdh.TEI_TASK_NAME")]
	public static string? TEI_TASK_NAME(SafeCoTaskMemStruct<TRACE_EVENT_INFO>? EventInfo) =>
		EventInfo?.GetOffsetString(EventInfo.Value.TaskNameOffset);

	private static Win32Error Get<T>(GetD getter, out T value) where T : struct
	{
		var status = GetMem<T>(getter, out var mem);
		value = status.Succeeded && !mem.IsInvalid ? mem.Value : default;
		return status;
	}

	private static Win32Error GetMem<T>(GetD getter, out SafeCoTaskMemStruct<T> value) where T : struct
	{
		Win32Error status;
		SafeCoTaskMemStruct<T> buffer = new();
		uint bufferSize = buffer.Size;

		while (true)
		{
			if ((status = getter(buffer, ref bufferSize)) != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				break;
			}

			buffer.Size = bufferSize;
		}
		value = status.Succeeded ? buffer : SafeCoTaskMemStruct<T>.Null;
		return status;
	}

	private static string? GetOffsetString(this SafeAllocatedMemoryHandle mem, uint offset, CharSet charSet = CharSet.Unicode) =>
		offset == 0 ? null : StringHelper.GetString(mem.DangerousGetHandle().Offset(offset), charSet, mem.Size - offset);

	/// <summary>Defines a single value map entry.</summary>
	/// <remarks>
	/// For maps defined in a manifest, the string will contain a space at the end of the string. For example, if the value is mapped to
	/// "Monday" in the manifest, the string is returned as "Monday ".
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-event_map_entry typedef struct _EVENT_MAP_ENTRY { ULONG OutputOffset;
	// union { ULONG Value; ULONG InputOffset; }; } EVENT_MAP_ENTRY;
	[PInvokeData("tdh.h", MSDNShortId = "e5b12f7a-4a00-41a0-90df-7d1317d63a4a")]
	[StructLayout(LayoutKind.Sequential)]
	public struct EVENT_MAP_ENTRY
	{
		/// <summary>
		/// Offset from the beginning of the EVENT_MAP_INFO structure to a null-terminated Unicode string that contains the string associated
		/// with the map value in <c>Value</c> or <c>InputOffset</c>.
		/// </summary>
		public uint OutputOffset;

		/// <summary>
		/// If the <c>MapEntryValueType</c> member of EVENT_MAP_INFO is EVENTMAP_ENTRY_VALUETYPE_ULONG, use this member to access the map value.
		/// </summary>
		public uint Value;

		/// <summary>
		/// <para>Offset from the beginning of the EVENT_MAP_INFO structure to the null-terminated Unicode string that contains the map value.</para>
		/// <para>The offset is used for pattern maps and WMI value maps that map strings to strings.</para>
		/// </summary>
		public uint InputOffset { get => Value; set => Value = value; }
	}

	/// <summary>Defines the metadata about the event map.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-event_map_info typedef struct _EVENT_MAP_INFO { ULONG NameOffset;
	// MAP_FLAGS Flag; ULONG EntryCount; union { MAP_VALUETYPE MapEntryValueType; ULONG FormatStringOffset; }; EVENT_MAP_ENTRY
	// MapEntryArray[ANYSIZE_ARRAY]; } EVENT_MAP_INFO;
	[PInvokeData("tdh.h", MSDNShortId = "dc7f14e7-16d7-4dfc-8c1a-5db6fa999d98")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<EVENT_MAP_INFO>), nameof(EntryCount))]
	[StructLayout(LayoutKind.Sequential)]
	public struct EVENT_MAP_INFO
	{
		/// <summary>
		/// Offset from the beginning of this structure to a null-terminated Unicode string that contains the name of the event map.
		/// </summary>
		public uint NameOffset;

		/// <summary>
		/// Indicates if the map is a value map, bitmap, or pattern map. This member can contain one or more flag values. For possible
		/// values, see the MAP_FLAGS enumeration.
		/// </summary>
		public MAP_FLAGS Flag;

		/// <summary>Number of map entries in <c>MapEntryArray</c>.</summary>
		public uint EntryCount;

		/// <summary>
		/// Determines if you use the <c>Value</c> member or <c>InputOffset</c> member of EVENT_MAP_ENTRY to access the map value. For
		/// possible values, see the MAP_VALUETYPE enumeration.
		/// </summary>
		public MAP_VALUETYPE MapEntryValueType { get => (MAP_VALUETYPE)FormatStringOffset; set => FormatStringOffset = (uint)value; }

		/// <summary>
		/// <para>
		/// If the value of <c>Flag</c> is EVENTMAP_INFO_FLAG_MANIFEST_PATTERNMAP, use this offset to access the null-terminated Unicode
		/// string that contains the value of the <c>format</c> attribute of the patternMap element. The offset is from the beginning of this structure.
		/// </para>
		/// <para>
		/// The EVENTMAP_INFO_FLAG_MANIFEST_PATTERNMAP also indicates that you use the <c>InputOffset</c> member of EVENT_MAP_ENTRY to access
		/// the map value.
		/// </para>
		/// </summary>
		public uint FormatStringOffset;

		/// <summary>Array of map entries. For details, see the EVENT_MAP_ENTRY structure.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public EVENT_MAP_ENTRY[] MapEntryArray;
	}

	/// <summary>Provides information about a single property of the event or filter.</summary>
	/// <remarks>Filters do not support maps, structures, or arrays.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-event_property_info typedef struct _EVENT_PROPERTY_INFO { PROPERTY_FLAGS
	// Flags; ULONG NameOffset; union { struct { USHORT InType; USHORT OutType; ULONG MapNameOffset; } nonStructType; struct { USHORT
	// StructStartIndex; USHORT NumOfStructMembers; ULONG padding; } structType; struct { USHORT InType; USHORT OutType; ULONG
	// CustomSchemaOffset; } customSchemaType; }; union { USHORT count; USHORT countPropertyIndex; }; union { USHORT length; USHORT
	// lengthPropertyIndex; }; union { ULONG Reserved; struct { ULONG Tags : 28; }; }; } EVENT_PROPERTY_INFO;
	[PInvokeData("tdh.h", MSDNShortId = "06b82b31-1f0e-45d5-88ec-9b9835af10df")]
	[StructLayout(LayoutKind.Explicit)]
	public struct EVENT_PROPERTY_INFO
	{
		/// <summary>
		/// Flags that indicate if the property is contained in a structure or array. For possible values, see the PROPERTY_FLAGS enumeration.
		/// </summary>
		[FieldOffset(0)]
		public PROPERTY_FLAGS Flags;

		/// <summary>
		/// Offset to a null-terminated Unicode string that contains the name of the property. If this an event property, the offset is from
		/// the beginning of the TRACE_EVENT_INFO structure. If this is a filter property, the offset is from the beginning of the
		/// PROVIDER_FILTER_INFO structure.
		/// </summary>
		[FieldOffset(4)]
		public uint NameOffset;

		/// <summary/>
		[FieldOffset(8)]
		public NONSTRUCTTYPE nonStructType;

		/// <summary/>
		[FieldOffset(8)]
		public STRUCTTYPE structType;

		/// <summary/>
		[FieldOffset(8)]
		public CUSTOMSCHEMATYPE customSchemaType;

		/// <summary>Number of elements in the array. Note that this value is 1 for properties that are not defined as an array.</summary>
		[FieldOffset(16)]
		public ushort count;

		/// <summary>
		/// Zero-based index to the element of the property array that contains the number of elements in the array. Use this member if the
		/// PropertyParamCount flag in <c>Flags</c> is set; otherwise, use the <c>count</c> member.
		/// </summary>
		[FieldOffset(16)]
		public ushort countPropertyIndex;

		/// <summary>
		/// Size of the property, in bytes. Note that variable-sized types such as strings and binary data have a length of zero unless the
		/// property has length attribute to explicitly indicate its real length. Structures have a length of zero.
		/// </summary>
		[FieldOffset(18)]
		public ushort length;

		/// <summary>
		/// Zero-based index to the element of the property array that contains the size value of this property. Use this member if the
		/// PropertyParamLength flag in <c>Flags</c> is set; otherwise, use the <c>length</c> member.
		/// </summary>
		[FieldOffset(18)]
		public ushort lengthPropertyIndex;

		/// <summary>
		/// A 28-bit value associated with the field metadata. This value is valid only if the PropertyHasTags flag is set. This value can be
		/// used by the event provider to associate additional semantic data with a field for use by an event processing tool. For example, a
		/// tag value of 1 might indicate that the field contains a username. The semantics of any values in this field are defined by the
		/// event provider.
		/// </summary>
		[FieldOffset(20)]
		public uint Tags;

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct NONSTRUCTTYPE
		{
			/// <summary>
			/// <para>Data type of this property on input. For a description of these types, see Remarks in InputType.</para>
			/// <para>For descriptions of these types, see Event Tracing MOF Qualifiers.</para>
			/// <para>TdhGetPropertySize TdhGetPropertySize</para>
			/// </summary>
			public TDH_IN_TYPE InType;

			/// <summary>
			/// <para>
			/// Output format for this property. If the value is TDH_OUTTYPE_NULL, use the in type as the output format. For a description of
			/// these types, see Remarks in InputType.
			/// </para>
			/// <para>For descriptions of these types, see Event Tracing MOF Qualifiers.</para>
			/// </summary>
			public TDH_OUT_TYPE OutType;

			/// <summary>
			/// Offset from the beginning of the TRACE_EVENT_INFO structure to a null-terminated Unicode string that contains the name of the
			/// map attribute value. You can pass this string to TdhGetEventMapInformation to retrieve information about the value map.
			/// </summary>
			public uint MapNameOffset;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct STRUCTTYPE
		{
			/// <summary>Zero-based index to the element of the property array that contains the first member of the structure.</summary>
			public ushort StructStartIndex;

			/// <summary>Number of members in the structure.</summary>
			public ushort NumOfStructMembers;

			/// <summary>Not used.</summary>
			public uint padding;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct CUSTOMSCHEMATYPE
		{
			/// <summary>
			/// <para>Data type of this property on input. For a description of these types, see Remarks in InputType.</para>
			/// <para>For descriptions of these types, see Event Tracing MOF Qualifiers.</para>
			/// <para>TdhGetPropertySize TdhGetPropertySize</para>
			/// </summary>
			public TDH_IN_TYPE InType;

			/// <summary>
			/// <para>
			/// Output format for this property. If the value is TDH_OUTTYPE_NULL, use the in type as the output format. For a description of
			/// these types, see Remarks in InputType.
			/// </para>
			/// <para>For descriptions of these types, see Event Tracing MOF Qualifiers.</para>
			/// </summary>
			public TDH_OUT_TYPE OutType;

			/// <summary>
			/// Offset (in bytes) from the beginning of the TRACE_EVENT_INFO structure to the custom schema information. The custom schema
			/// information will contain a 2-byte protocol identifier, followed by a 2-byte schema length, followed by the schema.
			/// </summary>
			public uint CustomSchemaOffset;
		}
	}

	/// <summary>
	/// The <c>PAYLOAD_FILTER_PREDICATE</c> structure defines an event payload filter predicate that describes how to filter on a single
	/// field in a trace session.
	/// </summary>
	/// <remarks>
	/// <para>
	/// On Windows 8.1,Windows Server 2012 R2, and later, event payload filters can be used by the EnableTraceEx2 function and the
	/// ENABLE_TRACE_PARAMETERS and EVENT_FILTER_DESCRIPTOR structures to filter on the specific content of the event in a logger session.
	/// </para>
	/// <para>
	/// The <c>PAYLOAD_FILTER_PREDICATE</c> structure is used with the TdhCreatePayloadFilter function to create a single payload filter for
	/// a single payload to be used with the EnableTraceEx2 function. A single payload filter can also be aggregated with other single
	/// payload filters using the TdhAggregatePayloadFilters function.
	/// </para>
	/// <para>
	/// Each field has a type specified in the provider manifest that can be used in the <c>Fieldname</c> member of the
	/// <c>PAYLOAD_FILTER_PREDICATE</c> structure to filter on that field.
	/// </para>
	/// <para>
	/// The <c>CompareOp</c> member specifies that operator to use for payload filtering. Payload filtering supports filtering on a string
	/// (including a <c>GUID</c>) and integers (including <c>TDH_INTYPE_FILETIME</c>). Filtering on floating-point numbers, a binary blob
	/// (including <c>TDH_INTYPE_POINTER</c>), and structured data ( <c>SID</c> and <c>SYSTEMTIME</c>) are not supported.
	/// </para>
	/// <para>
	/// The <c>Value</c> member contains a string of the value or values to compare with the value of the <c>Fieldname</c> member. The
	/// <c>Value</c> member is converted from a string to the type of the <c>Fieldname</c> member as specified in the manifest.
	/// </para>
	/// <para>
	/// All string comparisons are case-insensitive. The string in the <c>Value</c> member is UNICODE, but it will be converted to ANSI if
	/// the type specified in the manifest is ANSI.
	/// </para>
	/// <para>
	/// A <c>Fieldname</c> member that contains a <c>GUID</c> can only be compared when the <c>CompareOp</c> member contains either the
	/// <c>PAYLOADFIELD_IS</c> or <c>PAYLOADFIELD_ISNOT</c> for the payload operator. The string that represents a <c>GUID</c> in the
	/// <c>Value</c> member must contain the curly brackets ({00000000-0000-0000-0000-000000000000}, for example).
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// For an example that uses the <c>PAYLOAD_FILTER_PREDICATE</c> structure and the TdhCreatePayloadFilter function to create payload
	/// filters to use in filtering on specific conditions in a logger session, see the example for the EnableTraceEx2 function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-payload_filter_predicate typedef struct _PAYLOAD_FILTER_PREDICATE {
	// LPWSTR FieldName; USHORT CompareOp; LPWSTR Value; } PAYLOAD_FILTER_PREDICATE, *PPAYLOAD_FILTER_PREDICATE;
	[PInvokeData("tdh.h", MSDNShortId = "6B8C03C9-2936-4FEE-AEF4-ABC368B1CB75")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PAYLOAD_FILTER_PREDICATE
	{
		/// <summary>The name of the field to filter in package manifest.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string FieldName;

		/// <summary>
		/// <para>The payload operator to use for the comparison.</para>
		/// <para>This member can be one of the values for the <c>PAYLOAD_OPERATOR</c> enumeration defined in the Tdh.h header file.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PAYLOADFIELD_EQ 0</term>
		/// <term>
		/// The value of the FieldName parameter is equal to the numeric value of the string in the Value member. This operator is for
		/// comparing integers and requires one value in the Value member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAYLOADFIELD_NE 1</term>
		/// <term>
		/// The value of the FieldName parameter is not equal to the numeric value of the string in the Value member. This operator is for
		/// comparing integers and requires one value in the Value member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAYLOADFIELD_LE 2</term>
		/// <term>
		/// The value of the FieldName parameter is less than or equal to the numeric value of the string in the Value member. This operator
		/// is for comparing integers and requires one value in the Value member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAYLOADFIELD_GT 3</term>
		/// <term>
		/// The value of the FieldName parameter is greater than the numeric value of the string in the Value member. This operator is for
		/// comparing integers and requires one value in the Value member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAYLOADFIELD_LT 4</term>
		/// <term>
		/// The value of the FieldName parameter is less than the numeric value of the string in the Value member. This operator is for
		/// comparing integers and requires one value in the Value member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAYLOADFIELD_GE 5</term>
		/// <term>
		/// The value of the FieldName parameter is greater than or equal to the numeric value of the string in the Value member. This
		/// operator is for comparing integers and requires one value in the Value member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAYLOADFIELD_BETWEEN 6</term>
		/// <term>
		/// The value of the FieldName parameter is between the two numeric values in the string in the Value member. The
		/// PAYLOADFIELD_BETWEEN operator uses a closed interval (LowerBound &lt;= FieldValue &lt;= UpperBound). This operator is for
		/// comparing integers and requires two values in the Value member. The two values should be separated by a comma character (',').
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAYLOADFIELD_NOTBETWEEN 7</term>
		/// <term>
		/// The value of the FieldName parameter is not between the two numeric values in the string in the Value member. This operator is
		/// for comparing integers and requires two values in the Value member. The two values should be separated by a comma character (',').
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAYLOADFIELD_MODULO 8</term>
		/// <term>
		/// The value of the FieldName parameter is the modulo of the numeric value in the string in the Value member. The operator can be
		/// used for periodic sampling. This operator is for comparing integers and requires one value in the Value member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAYLOADFIELD_CONTAINS 20</term>
		/// <term>
		/// The value of the FieldName parameter contains the substring value in the Value member. String comparisons are case insensitive.
		/// This operator is for comparing strings and requires one value in the Value member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAYLOADFIELD_DOESNTCONTAIN 21</term>
		/// <term>
		/// The value of the FieldName parameter does not contain the substring in the Value member. String comparisons are case insensitive.
		/// This operator is for comparing strings and requires one value in the Value member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAYLOADFIELD_IS 30</term>
		/// <term>
		/// The value of the FieldName parameter is identical to the value of the string in the Value member. String comparisons are case
		/// insensitive. This operator is for comparing strings or other non-integer values and requires one value in the Value member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAYLOADFIELD_ISNOT 31</term>
		/// <term>
		/// The value of the FieldName parameter is not identical to the value of the string in the Value member. String comparisons are case
		/// insensitive. This operator is for comparing strings or other non-integer values and requires one value in the Value member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PAYLOADFIELD_INVALID 32</term>
		/// <term>A value of the payload operator that is not valid.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ushort CompareOp;

		/// <summary>The string that contains one or values to compare depending on the <c>CompareOp</c> member.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Value;
	}

	/// <summary>Defines the property to retrieve.</summary>
	/// <remarks>
	/// <para>To describe a structure, set PropertyName to the name of the structure and ArrayIndex to ULONG_MAX.</para>
	/// <para>
	/// To describe a member of a structure, define an array of two <c>PROPERTY_DATA_DESCRIPTOR</c> structures. In the first descriptor, set
	/// PropertyName to the name of the structure and ArrayIndex to 0. In the second descriptor, set PropertyName to the name of the member
	/// and ArrayIndex to ULONG_MAX.
	/// </para>
	/// <para>
	/// If the structure is an element of an array of structures, set ArrayIndex in the first descriptor to the zero-based index of the
	/// structure in the array.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-property_data_descriptor typedef struct _PROPERTY_DATA_DESCRIPTOR {
	// ULONGLONG PropertyName; ULONG ArrayIndex; ULONG Reserved; } PROPERTY_DATA_DESCRIPTOR;
	[PInvokeData("tdh.h", MSDNShortId = "38e6f5b1-fce5-45e4-ac7a-09ba40d29837")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PROPERTY_DATA_DESCRIPTOR
	{
		/// <summary>
		/// <para>
		/// Pointer to a null-terminated Unicode string that contains the case-sensitive property name. You can use the <c>NameOffset</c>
		/// member of the EVENT_PROPERTY_INFO structure to get the property name.
		/// </para>
		/// <para>
		/// The following table lists the possible values of PropertyName for WPP events. Use the suggested TDH data type when formatting the
		/// returned buffer from TdhGetProperty.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>TDH Data Type</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>FormattedString</term>
		/// <term>TDH_INTYPE_UNICODESTRING</term>
		/// <term>The formatted WPP trace message.</term>
		/// </item>
		/// <item>
		/// <term>SequenceNum</term>
		/// <term>TDH_INTYPE_UINT32</term>
		/// <term>
		/// The local or global sequence number of the trace message. Local sequence numbers, which are unique only to this trace session,
		/// are the default.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FunctionName</term>
		/// <term>TDH_INTYPE_UNICODESTRING</term>
		/// <term>The name of the function that generated the trace message.</term>
		/// </item>
		/// <item>
		/// <term>ComponentName</term>
		/// <term>TDH_INTYPE_UNICODESTRING</term>
		/// <term>
		/// The name of the component of the provider that generated the trace message. The component name appears only if it is specified in
		/// the tracing code.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SubComponentName</term>
		/// <term>TDH_INTYPE_UNICODESTRING</term>
		/// <term>
		/// The name of the subcomponent of the provider that generated the trace message. The subcomponent name appears only if it is
		/// specified in the tracing code.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TraceGuid</term>
		/// <term>TDH_INTYPE_GUID</term>
		/// <term>The GUID associated with the WPP trace message.</term>
		/// </item>
		/// <item>
		/// <term>GuidTypeName</term>
		/// <term>TDH_INTYPE_UNICODESTRING</term>
		/// <term>The file name concatenated with the line number from the source code from which the WPP trace message was traced.</term>
		/// </item>
		/// <item>
		/// <term>SystemTime</term>
		/// <term>TDH_INTYPE_SYSTEMTIME</term>
		/// <term>The time when the WPP trace message was generated.</term>
		/// </item>
		/// <item>
		/// <term>FlagsName</term>
		/// <term>TDH_INTYPE_UNICODESTRING</term>
		/// <term>The names of the trace flags enabling the trace message.</term>
		/// </item>
		/// <item>
		/// <term>LevelName</term>
		/// <term>TDH_INTYPE_UNICODESTRING</term>
		/// <term>The value of the trace level enabling the trace message.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ulong PropertyName;

		/// <summary>
		/// Zero-based index for accessing elements of a property array. If the property data is not an array or if you want to address the
		/// entire array, specify ULONG_MAX (0xFFFFFFFF).
		/// </summary>
		public uint ArrayIndex;

		/// <summary>Reserved.</summary>
		public uint Reserved;
	}

	/// <summary>Defines the array of providers that have registered a MOF or manifest on the computer.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-provider_enumeration_info typedef struct _PROVIDER_ENUMERATION_INFO {
	// ULONG NumberOfProviders; ULONG Reserved; TRACE_PROVIDER_INFO TraceProviderInfoArray[ANYSIZE_ARRAY]; } PROVIDER_ENUMERATION_INFO;
	[PInvokeData("tdh.h", MSDNShortId = "bb4548fb-70e5-4726-bc92-adb7ba7be0e4")]
	[StructLayout(LayoutKind.Sequential)]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<PROVIDER_ENUMERATION_INFO>), nameof(NumberOfProviders))]
	public struct PROVIDER_ENUMERATION_INFO
	{
		/// <summary>Number of elements in the <c>TraceProviderInfoArray</c> array.</summary>
		public uint NumberOfProviders;

		/// <summary/>
		public uint Reserved;

		/// <summary>
		/// Array of TRACE_PROVIDER_INFO structures that contain information about each provider such as its name and unique identifier.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public TRACE_PROVIDER_INFO[] TraceProviderInfoArray;
	}

	/// <summary>The <c>PROVIDER_EVENT_INFO</c> structure defines an array of events in a provider manifest.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-provider_event_info typedef struct _PROVIDER_EVENT_INFO { ULONG
	// NumberOfEvents; ULONG Reserved; EVENT_DESCRIPTOR EventDescriptorsArray[ANYSIZE_ARRAY]; } PROVIDER_EVENT_INFO;
	[PInvokeData("tdh.h", MSDNShortId = "CC392841-7436-4543-A846-FB5A27D9A014")]
	[StructLayout(LayoutKind.Sequential)]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<PROVIDER_EVENT_INFO>), nameof(NumberOfEvents))]
	public struct PROVIDER_EVENT_INFO
	{
		/// <summary>The number of elements in the <c>EventDescriptorsArray</c> array.</summary>
		public uint NumberOfEvents;

		/// <summary>Reserved.</summary>
		public uint Reserved;

		/// <summary>An array of EVENT_DESCRIPTOR structures that contain information about each event.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public EVENT_DESCRIPTOR[] EventDescriptorsArray;
	}

	/// <summary>Defines the field information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-provider_field_info typedef struct _PROVIDER_FIELD_INFO { ULONG
	// NameOffset; ULONG DescriptionOffset; ULONGLONG Value; } PROVIDER_FIELD_INFO;
	[PInvokeData("tdh.h", MSDNShortId = "a7c88c25-3acc-42aa-bf2b-bc7651e84f8c")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PROVIDER_FIELD_INFO
	{
		/// <summary>Offset to the null-terminated Unicode string that contains the name of the field, in English only.</summary>
		public uint NameOffset;

		/// <summary>
		/// Offset to the null-terminated Unicode string that contains the localized description of the field. The value is zero if the
		/// description does not exist.
		/// </summary>
		public uint DescriptionOffset;

		/// <summary>Field value.</summary>
		public ulong Value;
	}

	/// <summary>Defines metadata information about the requested field.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-provider_field_infoarray typedef struct _PROVIDER_FIELD_INFOARRAY {
	// ULONG NumberOfElements; EVENT_FIELD_TYPE FieldType; PROVIDER_FIELD_INFO FieldInfoArray[ANYSIZE_ARRAY]; } PROVIDER_FIELD_INFOARRAY;
	[PInvokeData("tdh.h", MSDNShortId = "c3755ca2-7b17-4f86-9ae8-34621f8b8c1b")]
	[StructLayout(LayoutKind.Sequential)]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<PROVIDER_FIELD_INFOARRAY>), nameof(NumberOfElements))]
	public struct PROVIDER_FIELD_INFOARRAY
	{
		/// <summary>Number of elements in the <c>FieldInfoArray</c> array.</summary>
		public uint NumberOfElements;

		/// <summary>Type of field information in the <c>FieldInfoArray</c> array. For possible values, see the EVENT_FIELD_TYPE enumeration.</summary>
		public EVENT_FIELD_TYPE FieldType;

		/// <summary>Array of PROVIDER_FIELD_INFO structures that define the field's name, description and value.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public PROVIDER_FIELD_INFO[] FieldInfoArray;
	}

	/// <summary>Defines a filter and its data.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-provider_filter_info typedef struct _PROVIDER_FILTER_INFO { UCHAR Id;
	// UCHAR Version; ULONG MessageOffset; ULONG Reserved; ULONG PropertyCount; EVENT_PROPERTY_INFO EventPropertyInfoArray[ANYSIZE_ARRAY]; }
	// PROVIDER_FILTER_INFO, *PPROVIDER_FILTER_INFO;
	[PInvokeData("tdh.h", MSDNShortId = "0541b24a-8531-4828-8c3b-d889e58b0b38")]
	[StructLayout(LayoutKind.Sequential)]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<PROVIDER_FILTER_INFO>), nameof(PropertyCount))]
	public struct PROVIDER_FILTER_INFO
	{
		/// <summary>
		/// The filter identifier that identifies the filter in the manifest. This is the same value as the <c>value</c> attribute of the
		/// FilterType complex type.
		/// </summary>
		public byte Id;

		/// <summary>
		/// The version number that identifies the version of the filter definition in the manifest. This is the same value as the
		/// <c>version</c> attribute of the FilterType complex type.
		/// </summary>
		public byte Version;

		/// <summary>
		/// Offset from the beginning of this structure to the message string that describes the filter. This is the same value as the
		/// <c>message</c> attribute of the FilterType complex type.
		/// </summary>
		public uint MessageOffset;

		/// <summary>Reserved.</summary>
		public uint Reserved;

		/// <summary>The number of elements in the EventPropertyInfoArray array.</summary>
		public uint PropertyCount;

		/// <summary>An array of EVENT_PROPERTY_INFO structures that define the filter data.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public EVENT_PROPERTY_INFO[] EventPropertyInfoArray;
	}

	/// <summary>Defines the additional information required to parse an event.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-tdh_context typedef struct _TDH_CONTEXT { ULONGLONG ParameterValue;
	// TDH_CONTEXT_TYPE ParameterType; ULONG ParameterSize; } TDH_CONTEXT;
	[PInvokeData("tdh.h", MSDNShortId = "184df0af-3ac5-406f-a298-4f23826ad85e")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TDH_CONTEXT
	{
		/// <summary>
		/// Context value cast to a ULONGLONG. The context value is determined by the context type specified in <c>ParameterType</c>. For
		/// example, if the context type is TDH_CONTEXT_WPP_TMFFILE, the context value is a Unicode string that contains the name of the .tmf file.
		/// </summary>
		public ulong ParameterValue;

		/// <summary>Context type. For a list of types, see the TDH_CONTEXT_TYPE enumeration.</summary>
		public TDH_CONTEXT_TYPE ParameterType;

		/// <summary>Reserved for future use.</summary>
		public uint ParameterSize;
	}

	/// <summary>Defines the information about the event.</summary>
	/// <remarks>The value of an offset is zero if the member is not defined.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-trace_event_info typedef struct _TRACE_EVENT_INFO { GUID ProviderGuid;
	// GUID EventGuid; EVENT_DESCRIPTOR EventDescriptor; DECODING_SOURCE DecodingSource; ULONG ProviderNameOffset; ULONG LevelNameOffset;
	// ULONG ChannelNameOffset; ULONG KeywordsNameOffset; ULONG TaskNameOffset; ULONG OpcodeNameOffset; ULONG EventMessageOffset; ULONG
	// ProviderMessageOffset; ULONG BinaryXMLOffset; ULONG BinaryXMLSize; union { ULONG EventNameOffset; ULONG ActivityIDNameOffset; }; union
	// { ULONG EventAttributesOffset; ULONG RelatedActivityIDNameOffset; }; ULONG PropertyCount; ULONG TopLevelPropertyCount; union {
	// TEMPLATE_FLAGS Flags; struct { ULONG Reserved : 4; ULONG Tags : 28; }; }; EVENT_PROPERTY_INFO EventPropertyInfoArray[ANYSIZE_ARRAY]; } TRACE_EVENT_INFO;
	[PInvokeData("tdh.h", MSDNShortId = "ecf57a23-0dd2-4954-82ac-e92f651c226f")]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<TRACE_EVENT_INFO>), nameof(PropertyCount))]
	public struct TRACE_EVENT_INFO
	{
		/// <summary>A GUID that identifies the provider.</summary>
		public Guid ProviderGuid;

		/// <summary>
		/// A GUID that identifies the MOF class that contains the event. If the provider uses a manifest to define its events, this member
		/// is GUID_NULL.
		/// </summary>
		public Guid EventGuid;

		/// <summary>A EVENT_DESCRIPTOR structure that describes the event.</summary>
		public EVENT_DESCRIPTOR EventDescriptor;

		/// <summary>
		/// A DECODING_SOURCE enumeration value that identifies the source used to parse the event's data (for example, an instrumenation
		/// manifest of WMI MOF class).
		/// </summary>
		public DECODING_SOURCE DecodingSource;

		/// <summary>
		/// The offset from the beginning of this structure to a null-terminated Unicode string that contains the name of the provider.
		/// </summary>
		public uint ProviderNameOffset;

		/// <summary>
		/// The offset from the beginning of this structure to a null-terminated Unicode string that contains the name of the level. For
		/// possible names, see Remarks in LevelType.
		/// </summary>
		public uint LevelNameOffset;

		/// <summary>
		/// The offset from the beginning of this structure to a null-terminated Unicode string that contains the name of the channel. For
		/// possible names, see Remarks in ChannelType.
		/// </summary>
		public uint ChannelNameOffset;

		/// <summary>
		/// The offset from the beginning of this structure to a list of null-terminated Unicode strings that contains the names of the
		/// keywords. The list is terminated with two NULL characters. For possible names, see Remarks in KeywordType.
		/// </summary>
		public uint KeywordsNameOffset;

		/// <summary>
		/// The offset from the beginning of this structure to a null-terminated Unicode string that contains the name of the task. For
		/// possible names, see Remarks in TaskType.
		/// </summary>
		public uint TaskNameOffset;

		/// <summary>
		/// The offset from the beginning of this structure to a null-terminated Unicode string that contains the name of the operation. For
		/// possible names, see Remarks in OpcodeType.
		/// </summary>
		public uint OpcodeNameOffset;

		/// <summary>
		/// <para>
		/// The offset from the beginning of this structure to a null-terminated Unicode string that contains the event message string. The
		/// offset is zero if there is no message string. For information on message strings, see the <c>message</c> attribute for EventDefinitionType.
		/// </para>
		/// <para>
		/// The message string can contain insert sequences, for example, Unable to connect to the %1 printer. The number of the insert
		/// sequence identifies the property in the event data to use for the substitution.
		/// </para>
		/// </summary>
		public uint EventMessageOffset;

		/// <summary>
		/// The offset from the beginning of this structure to a null-terminated Unicode string that contains the localized provider name.
		/// </summary>
		public uint ProviderMessageOffset;

		/// <summary>Reserved.</summary>
		public uint BinaryXMLOffset;

		/// <summary>Reserved.</summary>
		public uint BinaryXMLSize;

		/// <summary>
		/// The offset from the beginning of this structure to a null-terminated Unicode string that contains the property name of the
		/// activity identifier in the MOF class. Supported for classic ETW events only.
		/// </summary>
		public uint ActivityIDNameOffset;

		/// <summary>
		/// The offset from the beginning of this structure to a null-terminated Unicode string that contains the event's name. Supported for
		/// classic ETW events only.
		/// </summary>
		public uint EventNameOffset { get => ActivityIDNameOffset; set => ActivityIDNameOffset = value; }

		/// <summary>
		/// The offset from the beginning of this structure to a null-terminated Unicode string that contains the property name of the
		/// related activity identifier in the MOF class. Supported for legacy ETW events only.
		/// </summary>
		public uint RelatedActivityIDNameOffset;

		/// <summary>
		/// The offset from the beginning of this structure to a null-terminated Unicode string that contains a semicolon-separated list of
		/// name=value attributes associated with the event. Supported for legacy ETW events only.
		/// </summary>
		public uint EventAttributesOffset { get => RelatedActivityIDNameOffset; set => RelatedActivityIDNameOffset = value; }

		/// <summary>The number of elements in the <c>EventPropertyInfoArray</c> array.</summary>
		public uint PropertyCount;

		/// <summary>
		/// The number of properties in the <c>EventPropertyInfoArray</c> array that are top-level properties. This number does not include
		/// members of structures. Top-level properties come before all member properties in the array.
		/// </summary>
		public uint TopLevelPropertyCount;

		/// <summary>
		/// A 28-bit value associated with the event metadata. This value can be used by the event provider to associate additional semantic
		/// data with an event for use by an event processing tool. For example, a tag value of 5 might indicate that the event contains
		/// debugging information. The semantics of any values in this field are defined by the event provider.
		/// </summary>
		public TEMPLATE_FLAGS Tags;

		/// <summary>An array of EVENT_PROPERTY_INFO structures that provides information about each property of the event's user data.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public EVENT_PROPERTY_INFO[] EventPropertyInfoArray;
	}

	/// <summary>Defines the GUID and name for a provider.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-trace_provider_info typedef struct _TRACE_PROVIDER_INFO { GUID
	// ProviderGuid; ULONG SchemaSource; ULONG ProviderNameOffset; } TRACE_PROVIDER_INFO;
	[PInvokeData("tdh.h", MSDNShortId = "0dbfde78-b1d4-4cc6-99aa-81de3f647cdb")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TRACE_PROVIDER_INFO
	{
		/// <summary>GUID that uniquely identifies the provider.</summary>
		public Guid ProviderGuid;

		/// <summary>
		/// Is zero if the provider uses a XML manifest to provide a description of its events. Otherwise, the value is 1 if the provider
		/// uses a WMI MOF class to provide a description of its events.
		/// </summary>
		public uint SchemaSource;

		/// <summary>
		/// Offset to a null-terminated Unicode string that contains the name of the provider. The offset is from the beginning of the
		/// PROVIDER_ENUMERATION_INFO buffer that TdhEnumerateProviders returns.
		/// </summary>
		public uint ProviderNameOffset;
	}
}