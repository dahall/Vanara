namespace Vanara.PInvoke;

public static partial class Pdh
{
	/// <summary>Revision for the performance data block.</summary>
	public const uint PERF_DATA_REVISION = 1;

	/// <summary>Signature for the performance data block.</summary>
	public const uint PERF_DATA_VERSION = 1;

	/// <summary>Indicates that the performance object can have multiple instances.</summary>
	public const int PERF_METADATA_MULTIPLE_INSTANCES = -2;

	/// <summary>Indicates that the performance object is a metadata-only object with one unnamed instance.</summary>
	public const int PERF_METADATA_NO_INSTANCES = -3;

	/// <summary>Indicates that the performance object cannot have multiple instances.</summary>
	public const int PERF_NO_INSTANCES = -1;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public const int MAX_PERF_OBJECTS_IN_QUERY_FUNCTION = 64;
	public const uint WINPERF_LOG_DEBUG = 2; // Report debug errors as well
	public const uint WINPERF_LOG_NONE = 0; // No event reported
	public const uint WINPERF_LOG_USER = 1; // Report only errors
	public const uint WINPERF_LOG_VERBOSE = 3; // Report everything
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

	/// <summary>
	/// <para>
	/// Performs the cleanup required by your performance DLL. Implement and export this function if you are writing a performance DLL to
	/// provide performance data. The system calls this function whenever a consumer closes the registry key used to collect performance data.
	/// </para>
	/// <para>The <b>ClosePerformanceData</b> function is a placeholder for the application-defined function name.</para>
	/// </summary>
	/// <returns>This function should return ERROR_SUCCESS.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/winperf/nc-winperf-pm_close_proc PM_CLOSE_PROC PmCloseProc; DWORD PmCloseProc() {...}
	[PInvokeData("winperf.h", MSDNShortId = "NC:winperf.PM_CLOSE_PROC")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate uint PM_CLOSE_PROC();

	/// <summary>
	/// <para>
	/// Collects the performance data and returns it to the consumer. Implement and export this function if you are writing a performance DLL
	/// to provide performance data. The system calls this function whenever a consumer queries the registry for performance data.
	/// </para>
	/// <para>The <b>CollectPerformanceData</b> function is a placeholder for the application-defined function name.</para>
	/// </summary>
	/// <param name="pValueName"/>
	/// <param name="ppData"/>
	/// <param name="pcbTotalBytes"/>
	/// <param name="pNumObjectTypes"/>
	/// <returns>
	/// <para>One of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>ERROR_MORE_DATA</b></description>
	/// <description>
	/// The size of the <c>pData</c> buffer (where <c>pData</c> refers to the pointer pointed to by <c>lppData</c>) as specified by
	/// <c>lpcbTotalBytes</c> is not large enough to store the data. Leave <c>pData</c> unchanged, and set <c>lpcbTotalBytes</c> and
	/// <c>lpNumObjectTypes</c> to zero. No attempt is made to indicate the required buffer size, because this can change before the next call.
	/// </description>
	/// </item>
	/// <item>
	/// <description><b>ERROR_SUCCESS</b></description>
	/// <description>
	/// Return this value in all cases other than the <b>ERROR_MORE_DATA</b> case, even if no data is returned or an error occurs. To report
	/// errors other than insufficient buffer size, use the Application Event Log.
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the requested objects specified in the lpValueName parameter do not correspond to any of the object indexes that your performance
	/// DLL supports, leave the pData parameter unchanged (where pData refers to the pointer pointed to by lppData), and set the
	/// lpcbTotalBytes and lpNumObjectTypes parameters to zero. This indicates that no data was returned.
	/// </para>
	/// <para>
	/// If you support one or more of the queried objects, determine whether the size of the pData buffer as specified by lpcbTotalBytes is
	/// large enough to store the data. If not, leave pData unchanged, and set lpcbTotalBytes and lpNumObjectTypes to zero. No attempt is
	/// made to indicate the required buffer size, because this may change before the next call. Return <b>ERROR_MORE_DATA</b>.
	/// </para>
	/// <para>
	/// If your data collection is time-consuming, you should respond only to queries for specific objects, or costly queries. You should
	/// also lower the priority of the thread collecting the data, so that it does not adversely affect system performance. For the query
	/// string format, see <c>Using the Registry Functions to Consume Counter Data</c>.
	/// </para>
	/// <para>
	/// If the consumer is running on another computer (remotely), then the <c>OpenPerformanceData</c>, <c>ClosePerformanceData</c>, and
	/// <b>CollectPerformanceData</b> functions are called in the context of the Winlogon process, which handles the server side of the
	/// remote connection. This distinction is important when troubleshooting problems that occur only remotely.
	/// </para>
	/// <para>
	/// After your function returns successfully, the system can perform some basic tests to ensure the integrity of the data. By default, no
	/// tests are performed. If a test fails, the system generates an event log message and the data is discarded to prevent any further
	/// problems due to pointers that are not valid. The following registry value controls the test level:
	/// <c>HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\Perflib\ExtCounterTestLevel</c>.
	/// </para>
	/// <para>The following are the possible test levels for <b>ExtCounterTestLevel</b>.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Level</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description>1</description>
	/// <description>Test the pointers and buffers of trusted counter DLLs. Sends a copy of the user's buffer.</description>
	/// </item>
	/// <item>
	/// <description>2</description>
	/// <description>
	/// Test pointers and buffer lengths but does not test pointer references or buffer contents. Sends a copy of the user's buffer.
	/// </description>
	/// </item>
	/// <item>
	/// <description>3</description>
	/// <description>Do not test pointers or buffers. Sends a copy of the user's buffer.</description>
	/// </item>
	/// <item>
	/// <description>4</description>
	/// <description>Do not test pointers or buffers. Sends the user's buffer, not a copy. This is the default value.</description>
	/// </item>
	/// </list>
	/// <para>The following tests are performed at levels 1 and 2:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// Verifies that the value of lpcbTotalBytes is consistent with the returned buffer pointer, pData. If you add the lpcbTotalBytes value
	/// to the original buffer pointer passed to this function, you should end up with the same buffer pointer returned by this function. If
	/// they are not the same, an error message is logged and the data is ignored.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// Verify that a buffer overrun did not occur. The system adds a 1-KB guard page before and after the consumer-allocated buffer. If the
	/// returned buffer pointer, pData, points past the first byte of the appended guard page, then it is assumed that the buffer is not
	/// valid and the data is ignored. If the buffer pointer exceeds the end of the buffer, but not the end of the guard page, then a buffer
	/// overrun error is logged. If the buffer pointer is past the end of the guard page, then a heap error is logged because the heap that
	/// the buffer was allocated from could have been corrupted, causing other memory errors.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// Verify that the guard pages have not been corrupted. The 1-KB guard pages that were added before and after the buffer are initialized
	/// with a data pattern before this function is called. This data pattern is checked after the collect procedure returns. If any
	/// discrepancy is detected, a buffer overrun or other memory error is assumed and the data is ignored.
	/// </description>
	/// </item>
	/// </list>
	/// <para>The following tests are performed only if test level 1 is used:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// Verify that the sum of each object's <b>TotalByteLength</b> member is the same as the value of lpcbTotalBytes. If not, the data is ignored.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// Verify that the <b>ByteLength</b> member of each instance is consistent. The lengths are consistent if the next object or end of
	/// buffer follows the last instance. If not, the data is ignored.
	/// </description>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>See <c>Implementing CollectPerformanceData</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winperf/nc-winperf-pm_collect_proc PM_COLLECT_PROC PmCollectProc; DWORD
	// PmCollectProc( LPWSTR pValueName, void **ppData, DWORD *pcbTotalBytes, DWORD *pNumObjectTypes ) {...}
	[PInvokeData("winperf.h", MSDNShortId = "NC:winperf.PM_COLLECT_PROC")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate uint PM_COLLECT_PROC([MarshalAs(UnmanagedType.LPWStr)] string? pValueName, out IntPtr ppData,
		ref uint pcbTotalBytes, out uint pNumObjectTypes);

	/// <summary>Represents a callback function that initializes a performance data provider for use by the system.</summary>
	/// <remarks>
	/// This delegate is typically used with Windows performance data providers to perform any necessary setup before performance data
	/// collection begins. The system calls this function when the provider is first loaded.
	/// </remarks>
	/// <param name="pContext">
	/// An optional context string that provides provider-specific information required for initialization. Can be null if no context is needed.
	/// </param>
	/// <returns>
	/// A Win32Error value indicating the result of the initialization. Returns Win32Error.ERROR_SUCCESS if initialization succeeds;
	/// otherwise, returns an appropriate error code.
	/// </returns>
	[PInvokeData("winperf.h")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate Win32Error PM_OPEN_PROC([Optional] string? pContext);

	/// <summary>
	/// Default detail level to show in the Detail level list if bHideDetailBox is FALSE. If bHideDetailBox is TRUE, the dialog uses this
	/// value to filter the displayed performance counters and objects.
	/// </summary>
	[PInvokeData("winperf.h")]
	public enum PERF_DETAIL : uint
	{
		/// <summary>A novice user can understand the counter data.</summary>
		PERF_DETAIL_NOVICE = 100,

		/// <summary>The counter data is provided for advanced users.</summary>
		PERF_DETAIL_ADVANCED = 200,

		/// <summary>The counter data is provided for expert users.</summary>
		PERF_DETAIL_EXPERT = 300,

		/// <summary>The counter data is provided for system designers.</summary>
		PERF_DETAIL_WIZARD = 400
	}

	/// <summary>Describes the block of memory that contains the raw performance counter data for an object's counters.</summary>
	/// <remarks>
	/// <para>
	/// The <b>CounterOffset</b> member of <c>PERF_COUNTER_DEFINITION</c> provides the offset from the beginning of this structure to the
	/// counter value.
	/// </para>
	/// <para>
	/// The location of the <b>PERF_COUNTER_BLOCK</b> structure within the <c>PERF_OBJECT_TYPE</c> block depends on if the object contains
	/// instances. For details, see <c>Performance Data Format</c>.
	/// </para>
	/// <para>
	/// You must ensure that the size of the counter block is aligned to an 8-byte boundary. For example, if the performance object includes
	/// two DWORD counters, you must add an additional four bytes to the counter block to make it aligned to an 8-byte boundary.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winperf/ns-winperf-perf_counter_block typedef struct _PERF_COUNTER_BLOCK { DWORD
	// ByteLength; } PERF_COUNTER_BLOCK, *PPERF_COUNTER_BLOCK;
	[PInvokeData("winperf.h", MSDNShortId = "NS:winperf._PERF_COUNTER_BLOCK")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PERF_COUNTER_BLOCK
	{
		/// <summary>Size of this structure and the raw counter data that follows, in bytes.</summary>
		public uint ByteLength;
	}

	/// <summary>Describes a performance counter.</summary>
	/// <remarks>
	/// <para>
	/// A <c>PERF_OBJECT_TYPE</c> structure contains one or more counters. This structure defines each counter and gives the offset to its
	/// value. These structures follow the <b>PERF_OBJECT_TYPE</b> structure in memory. For details, see <c>Performance Data Format</c>.
	/// </para>
	/// <para>
	/// Providers should provide their counters in the same order each time their counters are queried. If the counter uses a base counter in
	/// its calculation (the counter type includes the <b>PERF_COUNTER_FRACTION</b> flag), the base counter must follow this counter in the
	/// list of counters. If the counter type includes the <b>PERF_MULTI_COUNTER</b> flag, the second counter value must follow this
	/// counter's value in the <c>PERF_COUNTER_BLOCK</c> block.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winperf/ns-winperf-perf_counter_definition typedef struct _PERF_COUNTER_DEFINITION
	// { DWORD ByteLength; DWORD CounterNameTitleIndex; #if ... DWORD CounterNameTitle; #else LPWSTR CounterNameTitle; #endif DWORD
	// CounterHelpTitleIndex; #if ... DWORD CounterHelpTitle; #else LPWSTR CounterHelpTitle; #endif LONG DefaultScale; DWORD DetailLevel;
	// DWORD CounterType; DWORD CounterSize; DWORD CounterOffset; } PERF_COUNTER_DEFINITION, *PPERF_COUNTER_DEFINITION;
	[PInvokeData("winperf.h", MSDNShortId = "NS:winperf._PERF_COUNTER_DEFINITION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PERF_COUNTER_DEFINITION
	{
		/// <summary>Size of this structure, in bytes.</summary>
		public uint ByteLength;

		/// <summary>
		/// <para>
		/// Index of the counter's name in the title database. For details on using the index to retrieve the counter's name, see
		/// <c>Retrieving Counter Names and Help Text</c>.
		/// </para>
		/// <para>
		/// To set this value, providers add the counter's offset value defined in their symbol file to the <b>First Counter</b> registry
		/// value. For details, see <c>Adding Counter Names and Descriptions to the Registry</c> and <c>Implementing the OpenPerformanceData function</c>.
		/// </para>
		/// <para>This value should be zero if the counter is a base counter ( <b>CounterType</b> includes the PERF_COUNTER_BASE flag).</para>
		/// </summary>
		public uint CounterNameTitleIndex;

		/// <summary>Reserved.</summary>
		public uint CounterNameTitle;

		/// <summary>
		/// <para>
		/// Index to the counter's help text in the title database. For details on using the index to retrieve the counter's help text, see
		/// <c>Retrieving Counter Names and Help Text</c>.
		/// </para>
		/// <para>
		/// To set this value, providers add the counter's offset value defined in their symbol file to the <b>First Help</b> registry value.
		/// For details, see <c>Adding Counter Names and Descriptions to the Registry</c> and <c>Implementing the OpenPerformanceData function</c>.
		/// </para>
		/// <para>This value should be zero if the counter is a base counter ( <b>CounterType</b> includes the PERF_COUNTER_BASE flag).</para>
		/// </summary>
		public uint CounterHelpTitleIndex;

		/// <summary>Reserved.</summary>
		public uint CounterHelpTitle;

		/// <summary>
		/// Scale factor to use when graphing the counter value. Valid values range from -7 to 7 (the values correspond to 0.0000001 -
		/// 10000000). If this value is zero, the scale value is 1; if this value is 1, the scale value is 10; if this value is –1, the scale
		/// value is .10; and so on.
		/// </summary>
		public int DefaultScale;

		/// <summary>
		/// <para>
		/// Level of detail for the counter. Consumers use this value to control display complexity. This member can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Detail level</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>PERF_DETAIL_NOVICE</b></description>
		/// <description>The counter data is provided for all users.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>PERF_DETAIL_ADVANCED</b></description>
		/// <description>The counter data is provided for advanced users.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>PERF_DETAIL_EXPERT</b></description>
		/// <description>The counter data is provided for expert users.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>PERF_DETAIL_WIZARD</b></description>
		/// <description>The counter data is provided for system designers.</description>
		/// </item>
		/// </list>
		/// </summary>
		public uint DetailLevel;

		/// <summary>
		/// Type of counter. For a list of predefined counter types, see the Counter Types section of the <c>Windows Server 2003 Deployment
		/// Kit</c>. Consumers use the counter type to determine how to calculate and display the counter value. Providers should limit their
		/// choice of counter types to the predefined list.
		/// </summary>
		public uint CounterType;

		/// <summary>
		/// <para>Counter size, in bytes.</para>
		/// <para>Currently, only DWORDs (4 bytes) and ULONGLONGs (8 bytes) are used to provide counter values.</para>
		/// </summary>
		public uint CounterSize;

		/// <summary>
		/// <para>
		/// Offset from the start of the <c>PERF_COUNTER_BLOCK</c> structure to the first byte of this counter. The location of the
		/// <b>PERF_COUNTER_BLOCK</b> structure within the <c>PERF_OBJECT_TYPE</c> block depends on if the object contains instances. For
		/// details, see <c>Performance Data Format</c>.
		/// </para>
		/// <para>Note that multiple counters can use the same raw data and point to the same offset in the <c>PERF_COUNTER_BLOCK</c> block.</para>
		/// </summary>
		public uint CounterOffset;
	}

	/// <summary>
	/// Describes the performance data block that you queried, for example, the number of performance objects returned by the provider and
	/// the time-based values that you use when calculating performance values.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The performance data block is returned when a consumer calls <c>RegQueryValueEx</c> to retrieve one or more performance objects. This
	/// structure is the first structure in the returned block. The next structure in the block is the <c>PERF_OBJECT_TYPE</c> structure,
	/// which defines a performance object. For details on the layout of the performance data block, see <c>Performance Data Format</c>.
	/// </para>
	/// <para>
	/// Consumers use <b>PerfTime</b>, <b>PerfFreq</b>, and <b>PerfTime100nSec</b> when calculating counter values unless the counter type
	/// contains the <b>PERF_OBJECT_TIMER</b> flag in which case the consumer uses the <b>PerfTime</b> and <b>PerfFreq</b> members of <c>PERF_OBJECT_TYPE</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winperf/ns-winperf-perf_data_block typedef struct _PERF_DATA_BLOCK { WCHAR
	// Signature[4]; DWORD LittleEndian; DWORD Version; DWORD Revision; DWORD TotalByteLength; DWORD HeaderLength; DWORD NumObjectTypes; LONG
	// DefaultObject; SYSTEMTIME SystemTime; LARGE_INTEGER PerfTime; LARGE_INTEGER PerfFreq; LARGE_INTEGER PerfTime100nSec; DWORD
	// SystemNameLength; DWORD SystemNameOffset; } PERF_DATA_BLOCK, *PPERF_DATA_BLOCK;
	[PInvokeData("winperf.h", MSDNShortId = "NS:winperf._PERF_DATA_BLOCK")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct PERF_DATA_BLOCK()
	{
		/// <summary>Array of four wide-characters that contains "PERF".</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
		public string Signature = "PERF";

		/// <summary>
		/// Indicates if the counter values are in big endian format or little endian format. If one, the counter values are in little endian
		/// format. If zero, the counter values are in big endian format. This value may be zero (big endian format) if you retrieve
		/// performance data from a foreign computer, such as a UNIX computer.
		/// </summary>
		public uint LittleEndian;

		/// <summary>Version of the performance structures.</summary>
		public uint Version = PERF_DATA_VERSION;

		/// <summary>Revision of the performance structures.</summary>
		public uint Revision = PERF_DATA_REVISION;

		/// <summary>Total size of the performance data block, in bytes.</summary>
		public uint TotalByteLength;

		/// <summary>
		/// Size of this structure, in bytes. You use the header length to find the first <c>PERF_OBJECT_TYPE</c> structure in the
		/// performance data block.
		/// </summary>
		public uint HeaderLength;

		/// <summary>Number of performance objects in the performance data block.</summary>
		public uint NumObjectTypes;

		/// <summary>Reserved.</summary>
		public int DefaultObject;

		/// <summary>Time when the system was monitored. This member is in Coordinated Universal Time (UTC) format.</summary>
		public SYSTEMTIME SystemTime;

		/// <summary>Performance-counter value, in counts, for the system being monitored. For more information, see <c>QueryPerformanceCounter</c>.</summary>
		public long PerfTime;

		/// <summary>Performance-counter frequency, in counts per second, for the system being monitored. For more information, see <c>QueryPerformanceFrequency</c>.</summary>
		public long PerfFreq;

		/// <summary>Performance-counter value, in 100 nanosecond units, for the system being monitored. For more information, see <c>GetSystemTimeAsFileTime</c>.</summary>
		public long PerfTime100nSec;

		/// <summary>Size of the computer name located at <b>SystemNameOffset</b>, in bytes.</summary>
		public uint SystemNameLength;

		/// <summary>Offset from the beginning of this structure to the Unicode name of the computer being monitored.</summary>
		public uint SystemNameOffset;
	}

	/// <summary>Describes an instance of a performance object.</summary>
	/// <remarks>
	/// <para>
	/// The object contains instances if the <b>NumInstances</b> member of <c>PERF_OBJECT_TYPE</c> is greater than zero. Use the
	/// <b>DefinitionLength</b> member of <b>PERF_OBJECT_TYPE</b> to find the first instance of the object. For details, see <c>Performance
	/// Data Format</c>.
	/// </para>
	/// <para>
	/// Consumers should use the parent instance name, if specified, to create a full instance name that is used for display. The convention
	/// is to form the name as parent/child.
	/// </para>
	/// <para>
	/// Providers should use unique instance names. If you do not, it makes it difficult for consumers to calculate and display performance
	/// values because they cannot tell if the current instance refers to the same instance that was queried previously (instances can come
	/// and go).
	/// </para>
	/// <para>Providers must allocate enough space for the instance name to ensure that <b>ByteLength</b> is aligned to an 8-byte boundary.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winperf/ns-winperf-perf_instance_definition typedef struct
	// _PERF_INSTANCE_DEFINITION { DWORD ByteLength; DWORD ParentObjectTitleIndex; DWORD ParentObjectInstance; LONG UniqueID; DWORD
	// NameOffset; DWORD NameLength; } PERF_INSTANCE_DEFINITION, *PPERF_INSTANCE_DEFINITION;
	[PInvokeData("winperf.h", MSDNShortId = "NS:winperf._PERF_INSTANCE_DEFINITION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PERF_INSTANCE_DEFINITION
	{
		/// <summary>Size of this structure, including the instance name that follows, in bytes. This value must be an 8-byte multiple.</summary>
		public uint ByteLength;

		/// <summary>
		/// Index of the name of the parent object in the title database. For example, if the object is a thread, the parent object is a
		/// process, or if the object is a logical drive, the parent is a physical drive.
		/// </summary>
		public uint ParentObjectTitleIndex;

		/// <summary>Position of the instance within the parent object that is associated with this instance. The position is zero-based.</summary>
		public uint ParentObjectInstance;

		/// <summary>
		/// A unique identifier that you can use to identify the instance instead of using the name to identify the instance. If you do not
		/// use unique identifiers to distinguish the counter instances, set this member to PERF_NO_UNIQUE_ID.
		/// </summary>
		public int UniqueID;

		/// <summary>Offset from the beginning of this structure to the Unicode name of this instance.</summary>
		public uint NameOffset;

		/// <summary>
		/// <para>
		/// Length of the instance name, including the null-terminator, in bytes. This member is zero if the instance does not have a name.
		/// </para>
		/// <para>
		/// Do not include in the length any padding that you added to the instance name to ensure that <b>ByteLength</b> is aligned to an
		/// 8-byte boundary.
		/// </para>
		/// </summary>
		public uint NameLength;
	}

	/// <summary>
	/// Describes object-specific performance information, for example, the number of instances of the object and the number of counters that
	/// the object defines.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Providers use this structure to provide performance data for objects that they support. Consumers use this structure to consume
	/// performance data for objects that they queried.
	/// </para>
	/// <para>
	/// This structure is followed by a list of <c>PERF_COUNTER_DEFINITION</c> structures, one for each counter defined for the performance
	/// object. For details on the layout of the performance data block, see <c>Performance Data Format</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winperf/ns-winperf-perf_object_type typedef struct _PERF_OBJECT_TYPE { DWORD
	// TotalByteLength; DWORD DefinitionLength; DWORD HeaderLength; DWORD ObjectNameTitleIndex; #if ... DWORD ObjectNameTitle; #else LPWSTR
	// ObjectNameTitle; #endif DWORD ObjectHelpTitleIndex; #if ... DWORD ObjectHelpTitle; #else LPWSTR ObjectHelpTitle; #endif DWORD
	// DetailLevel; DWORD NumCounters; LONG DefaultCounter; LONG NumInstances; DWORD CodePage; LARGE_INTEGER PerfTime; LARGE_INTEGER
	// PerfFreq; } PERF_OBJECT_TYPE, *PPERF_OBJECT_TYPE;
	[PInvokeData("winperf.h", MSDNShortId = "NS:winperf._PERF_OBJECT_TYPE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PERF_OBJECT_TYPE
	{
		/// <summary>
		/// Size of the object-specific data, in bytes. This member is the offset from the beginning of this structure to the next
		/// <b>PERF_OBJECT_TYPE</b> structure, if one exists.
		/// </summary>
		public uint TotalByteLength;

		/// <summary>
		/// <para>Size of this structure plus the size of all the <c>PERF_COUNTER_DEFINITION</c> structures.</para>
		/// <para>
		/// If the object is a multiple instance object (the <b>NumInstances</b> member is not zero), this member is the offset from the
		/// beginning of this structure to the first <c>PERF_INSTANCE_DEFINITION</c> structure. Otherwise, this value is the offset to the <c>PERF_COUNTER_BLOCK</c>.
		/// </para>
		/// </summary>
		public uint DefinitionLength;

		/// <summary>
		/// Size of this structure, in bytes. This member is the offset from the beginning of this structure to the first
		/// <c>PERF_COUNTER_DEFINITION</c> structure.
		/// </summary>
		public uint HeaderLength;

		/// <summary>
		/// <para>
		/// Index to the object's name in the title database. For details on using the index to retrieve the object's name, see <c>Retrieving
		/// Counter Names and Help Text</c>.
		/// </para>
		/// <para>
		/// Providers specify the index value in their initialization file. For details, see <c>Adding Counter Names and Descriptions to the Registry</c>.
		/// </para>
		/// </summary>
		public uint ObjectNameTitleIndex;

		/// <summary>Reserved.</summary>
		public uint ObjectNameTitle;

		/// <summary>
		/// <para>
		/// Index to the object's help text in the title database. For details on using the index to retrieve the object's help text, see
		/// <c>Retrieving Counter Names and Help Text</c>.
		/// </para>
		/// <para>
		/// Providers specify the index value in their initialization file. For details, see <c>Adding Counter Names and Descriptions to the Registry</c>.
		/// </para>
		/// </summary>
		public uint ObjectHelpTitleIndex;

		/// <summary>Reserved.</summary>
		public uint ObjectHelpTitle;

		/// <summary>
		/// <para>
		/// Level of detail. Consumers use this value to control display complexity. This value is the minimum detail level of all the
		/// counters for a given object. This member can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Detail level</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c></c><c></c><b>PERF_DETAIL_NOVICE</b></description>
		/// <description>The counter data is provided for all users.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>PERF_DETAIL_ADVANCED</b></description>
		/// <description>The counter data is provided for advanced users.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>PERF_DETAIL_EXPERT</b></description>
		/// <description>The counter data is provided for expert users.</description>
		/// </item>
		/// <item>
		/// <description><c></c><c></c><b>PERF_DETAIL_WIZARD</b></description>
		/// <description>The counter data is provided for system designers.</description>
		/// </item>
		/// </list>
		/// </summary>
		public PERF_DETAIL DetailLevel;

		/// <summary>Number of <c>PERF_COUNTER_DEFINITION</c> blocks returned by the object.</summary>
		public uint NumCounters;

		/// <summary>
		/// Index to the counter's name in the title database of the default counter whose information is to be displayed when this object is
		/// selected in the Performance tool. This member may be –1 to indicate that there is no default.
		/// </summary>
		public int DefaultCounter;

		/// <summary>
		/// Number of object instances for which counters are being provided. If the object can have zero or more instances, but has none at
		/// present, this value should be zero. If the object cannot have multiple instances, this value should be PERF_NO_INSTANCES.
		/// </summary>
		public int NumInstances;

		/// <summary>
		/// This member is zero if the instance strings are Unicode strings. Otherwise, this member is the code-page identifier of the
		/// instance names. You can use the code-page value when calling <c>MultiByteToWideChar</c> to convert the string to Unicode.
		/// </summary>
		public uint CodePage;

		/// <summary>
		/// <para>
		/// Provider generated timestamp that consumers use when calculating counter values. For example, this could be the current value, in
		/// counts, of the high-resolution performance counter.
		/// </para>
		/// <para>
		/// Providers need to provide this value if the counter types of their counters include the <b>PERF_OBJECT_TIMER</b> flag. Otherwise,
		/// consumers use the <b>PerfTime</b> value from <c>PERF_DATA_BLOCK</c>.
		/// </para>
		/// </summary>
		public long PerfTime;

		/// <summary>
		/// <para>
		/// Provider generated frequency value that consumers use when calculating counter values. For example, this could be the current
		/// frequency, in counts per second, of the high-resolution performance counter.
		/// </para>
		/// <para>
		/// Providers need to provide this value if the counter types of their counters include the <b>PERF_OBJECT_TIMER</b> flag. Otherwise,
		/// consumers use the <b>PerfFreq</b> value from <c>PERF_DATA_BLOCK</c>.
		/// </para>
		/// </summary>
		public long PerfFreq;
	}
}