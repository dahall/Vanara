using System.Collections.Generic;
using System.Linq;

namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary/>
	public const uint PERF_WILDCARD_COUNTER = uint.MaxValue;

	/// <summary/>
	public const string PERF_WILDCARD_INSTANCE = "*";

	private const uint PERF_COUNTERSET_FLAG_AGGREGATE = 4;
	private const uint PERF_COUNTERSET_FLAG_HISTORY = 8;
	private const uint PERF_COUNTERSET_FLAG_INSTANCE = 16;
	private const uint PERF_COUNTERSET_FLAG_MULTIPLE = 2;
	private const uint PERF_PROVIDER_DRIVER = 2;
	private const uint PERF_PROVIDER_KERNEL_MODE = 1;
	private const uint PERF_PROVIDER_USER_MODE = 0;

	/// <summary>
	/// <para>
	/// Providers implement this function to provide custom memory management for PERFLIB. PERFLIB calls this callback when it needs to
	/// allocate memory. By default, PERFLIB uses the process heap to allocate memory.
	/// </para>
	/// <para>
	/// The <c>PERF_MEM_ALLOC</c> type defines a pointer to this callback function. The <c>AllocateMemory</c> function is a placeholder
	/// for the application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="AllocSize">Number of bytes to allocate.</param>
	/// <param name="pContext">Context information set in the <c>pMemContext</c> member of PERF_PROVIDER_CONTEXT.</param>
	/// <returns>Pointer to the allocated memory or <c>NULL</c> if an error occurred.</returns>
	/// <remarks>
	/// <para>
	/// If you used the <c>-MemoryRoutines</c> when calling CTRPP, you must implement this callback function. You pass the name of your
	/// callback function to CounterInitialize.
	/// </para>
	/// <para><c>Windows Vista:</c> The CounterInitialize function is named <c>PerfAutoInitialize</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nc-perflib-perf_mem_alloc PERF_MEM_ALLOC PerfMemAlloc; LPVOID
	// PerfMemAlloc( IN SizeT AllocSize, IN LPVOID pContext ) {...}
	[PInvokeData("perflib.h", MSDNShortId = "09af7e56-2174-4a82-b45b-59f4180e4aab")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate IntPtr AllocateMemory([In] SizeT AllocSize, [In, Optional] IntPtr pContext);

	/// <summary>
	/// <para>
	/// Providers can implement this function to receive notification when consumers perform certain actions, such as adding or removing
	/// counters from a query. PERFLIB calls the callback before the consumer's request completes.
	/// </para>
	/// <para>
	/// The <c>PERFLIBREQUEST</c> type defines a pointer to this callback function. The <c>ControlCallback</c> function is a placeholder
	/// for the application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="RequestCode">
	/// <para>The request code can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PERF_ADD_COUNTER</term>
	/// <term>
	/// The consumer is adding a counter to the query. PERFLIB calls the callback with this request code for each counter being added to
	/// the query. The Buffer parameter contains a PERF_COUNTER_IDENTITY structure that identifies the counter being added. Providers can
	/// use this notification to start counting.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PERF_REMOVE_COUNTER</term>
	/// <term>
	/// The consumer is removing a counter from the query. PERFLIB calls the callback with this request code for each counter being
	/// removed from the query. The Buffer parameter contains a PERF_COUNTER_IDENTITY structure that identifies the counter being
	/// removed. Providers can use this notification to stop counting.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PERF_ENUM_INSTANCES</term>
	/// <term>
	/// The consumer is enumerating instances of the counter set. The Buffer parameter contains a null-terminated Unicode string that
	/// identifies the name of the computer (or its IP address) from which the consumer is enumerating the instances.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PERF_COLLECT_START</term>
	/// <term>
	/// The consumer is beginning to collect counter data. The Buffer parameter contains a null-terminated Unicode string that identifies
	/// the name of the computer (or its IP address) from which the consumer is collecting data. Providers can use this notification if
	/// the raw data state is critical (for example, transaction-related counters where partial updates are not allowed). This
	/// notification gives the provider a chance to flush all pending updates and lock future updates before collection begins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PERF_COLLECT_END</term>
	/// <term>
	/// The counter data collection is complete. The Buffer parameter contains a null-terminated Unicode string that identifies the name
	/// of the computer (or its IP address) from which the consumer collected data. Providers can use this notification to release the
	/// update lock imposed by the collection start notification so that updates to the counter data can resume.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Buffer">The contents of the buffer depends on the request. For possible content, see the RequestCode parameter.</param>
	/// <param name="BufferSize">Size, in bytes, of the Buffer parameter.</param>
	/// <returns>
	/// <para>Return ERROR_SUCCESS if the callback succeeds.</para>
	/// <para>
	/// If the callback fails, PERFLIB will return the error code to the consumer if the request is <c>PERF_ADD_COUNTER</c>,
	/// <c>PERF_ENUM_INSTANCES</c>, or <c>PERF_COLLECT_START</c>; otherwise, the error code is ignored.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the <c>callback</c> attribute of the provider element is "custom" or you used the <c>-NotificationCallback</c> argument when
	/// calling CTRPP, you must implement this function. You pass the name of your callback function to CounterInitialize.
	/// </para>
	/// <para>
	/// <c>Windows Vista:</c> The CounterInitialize function is named <c>PerfAutoInitialize</c>. The CTRPP tool also generates a skeleton
	/// of this callback for you that includes all the request codes. You then add code to the request codes that you want to support and
	/// remove the others.
	/// </para>
	/// <para>
	/// The callback must complete within one second. If the callback does not complete in time, PERFLIB continues with the consumer's
	/// request and ignores the callback's return value when it completes.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows a simple implementation of a ControlCallback function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nc-perflib-perflibrequest PERFLIBREQUEST Perflibrequest; ULONG
	// Perflibrequest( IN ULONG RequestCode, IN PVOID Buffer, IN ULONG BufferSize ) {...}
	[PInvokeData("perflib.h", MSDNShortId = "0f771ab7-af42-481b-b2da-20dcdf49b82b")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate NTStatus ControlCallback([In] uint RequestCode, [In] IntPtr Buffer, [In] uint BufferSize);

	/// <summary>
	/// <para>
	/// Providers implement this function to provide custom memory management for PERFLIB. PERFLIB calls this callback when it needs to
	/// free memory that it allocated using AllocateMemory.
	/// </para>
	/// <para>
	/// The <c>PERF_MEM_FREE</c> type defines a pointer to this callback function. The <c>FreeMemory</c> function is a placeholder for
	/// the application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="pBuffer">Memory to free.</param>
	/// <param name="pContext">Context information set in the <c>pMemContext</c> member of PERF_PROVIDER_CONTEXT.</param>
	/// <remarks>
	/// <para>
	/// If you used the <c>-MemoryRoutines</c> when calling CTRPP, you must implement this callback function. You pass the name of your
	/// callback function to CounterInitialize.
	/// </para>
	/// <para><c>Windows Vista:</c> The CounterInitialize function is named <c>PerfAutoInitialize</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nc-perflib-perf_mem_free PERF_MEM_FREE PerfMemFree; void PerfMemFree(
	// IN LPVOID pBuffer, IN LPVOID pContext ) {...}
	[PInvokeData("perflib.h", MSDNShortId = "3b2f9f68-131a-4e17-8b43-6c3a20871dad")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void FreeMemory([In] IntPtr pBuffer, [In] IntPtr pContext);

	/// <summary>Specifies the type of aggregation to perform on counter instances in a counter set.</summary>
	public enum PERF_AGGREGATE
	{
		/// <summary>Undefined.</summary>
		PERF_AGGREGATE_UNDEFINED = 0,

		/// <summary>The sum of the values of the returned counter instances.</summary>
		PERF_AGGREGATE_TOTAL,

		/// <summary>The average of the values of the returned counter instances.</summary>
		PERF_AGGREGATE_AVG,

		/// <summary>The minimum value of the returned counter instance values.</summary>
		PERF_AGGREGATE_MIN,

		/// <summary>The maximum value of the returned counter instance values.</summary>
		PERF_AGGREGATE_MAX,
	}

	/// <summary>Specifies attributes of a performance counter in a PERF_COUNTER_INFO structure.</summary>
	[Flags]
	public enum PERF_ATTRIB : ulong
	{
		/// <summary>The query on the server MUST dereference the counter to obtain the value.</summary>
		PERF_ATTRIB_BY_REFERENCE = 0x00000001,

		/// <summary>Instructs the client consumer querying for performance counter data not to display the counter value.</summary>
		PERF_ATTRIB_NO_DISPLAYABLE = 0x00000002,

		/// <summary>
		/// Instructs the client consumer querying performance counter data to display the counter values as a single number without commas
		/// between digits.
		/// </summary>
		PERF_ATTRIB_NO_GROUP_SEPARATOR = 0x00000004,

		/// <summary>Instructs the client consumer querying performance counter to display the counter value as a real number.</summary>
		PERF_ATTRIB_DISPLAY_AS_REAL = 0x00000008,

		/// <summary>Instructs the client consumer querying performance counter to display the counter value as a hexadecimal number.</summary>
		PERF_ATTRIB_DISPLAY_AS_HEX = 0x00000010,
	}

	/// <summary>
	/// Specifies whether the counter set allows multiple instances such as processes and physical disks, or a single instance such as memory
	/// in <see cref="PERF_COUNTERSET_INFO"/>.
	/// </summary>
	[Flags]
	public enum PERF_COUNTERSET_TYPE : uint
	{
		/// <summary>The counter set contains single instance counters, for example, a counter that measures physical memory.</summary>
		PERF_COUNTERSET_SINGLE_INSTANCE = 0,

		/// <summary>
		/// The counter set contains multiple instance counters, for example, a counter that measures the average disk I/O for a process.
		/// </summary>
		PERF_COUNTERSET_MULTI_INSTANCES = (PERF_COUNTERSET_FLAG_MULTIPLE),

		/// <summary>
		/// The counter set contains single instance counters whose aggregate value is obtained from one or more sources. For example, a
		/// counter in this type of counter set might obtain the number of reads from each of the three hard disks on the computer and sum
		/// their values.
		/// </summary>
		PERF_COUNTERSET_SINGLE_AGGREGATE = (PERF_COUNTERSET_FLAG_AGGREGATE),

		/// <summary>
		/// The counter set contains multiple instance counters whose aggregate value is obtained from all instances of the counter. For
		/// example, a counter in this type of counter set might obtain the total thread execution time for all threads in a multi-threaded
		/// application and sum their values.
		/// </summary>
		PERF_COUNTERSET_MULTI_AGGREGATE = (PERF_COUNTERSET_FLAG_AGGREGATE | PERF_COUNTERSET_FLAG_MULTIPLE),

		/// <summary>
		/// The difference between this type and PERF_COUNTERSET_SINGLE_AGGREGATE is that this counter set type stores all counter values for
		/// the lifetime of the consumer application (the counter value is cached beyond the lifetime of the counter). For example, if one of
		/// the hard disks in the single aggregate example above were to become unavailable, the total bytes read by that disk would still be
		/// available and used to calculate the aggregate value.
		/// </summary>
		PERF_COUNTERSET_SINGLE_AGGREGATE_HISTORY = (PERF_COUNTERSET_FLAG_HISTORY | PERF_COUNTERSET_SINGLE_AGGREGATE),

		/// <summary>
		/// This type is similar to PERF_COUNTERSET_MULTI_AGGREGATE, except that instead of aggregating all instance data to one aggregated
		/// (_Total) instance, it will aggregate counter data from instances of the same name.
		/// <para>
		/// For example, if multiple provider processes contained instances named IExplore, PERF_COUNTERSET_MULTIPLE and
		/// PERF_COUNTERSET_MULTI_AGGREGATE CounterSet will show multiple IExplore instances (IExplore, IExplore#1, IExplore#2, and so on);
		/// however, a PERF_COUNTERSET_INSTANCE_AGGREGATE instance type will only publish one IExplore instance with aggregated counter data
		/// from all instances named IExplore.
		/// </para>
		/// </summary>
		PERF_COUNTERSET_INSTANCE_AGGREGATE = (PERF_COUNTERSET_MULTI_AGGREGATE | PERF_COUNTERSET_FLAG_INSTANCE),
	}

	/// <summary>
	/// Indicates the content type of a PERF_COUNTER_HEADER block that the PerfQueryCounterData function includes as part of the
	/// PERF_DATA_HEADER block that the function produces as output.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/ne-perflib-_perfcounterdatatype typedef enum _PerfCounterDataType {
	// PERF_ERROR_RETURN, PERF_SINGLE_COUNTER, PERF_MULTIPLE_COUNTERS, PERF_MULTIPLE_INSTANCES, PERF_COUNTERSET } PerfCounterDataType;
	[PInvokeData("perflib.h", MSDNShortId = "E64C73F0-034E-408B-8537-CE6855C01347")]
	public enum PerfCounterDataType
	{
		/// <summary>An error occurred when the performance counter value was queried.</summary>
		PERF_ERROR_RETURN = 0,

		/// <summary>The query returned a single counter from a single instance.</summary>
		[CorrespondingType(typeof(PERF_COUNTER_HEADER))]
		PERF_SINGLE_COUNTER = 1,

		/// <summary>The query returned multiple counters from a single instance.</summary>
		[CorrespondingType(typeof(PERF_MULTI_COUNTERS))]
		PERF_MULTIPLE_COUNTERS = 2,

		/// <summary>The query returned a single counter from each of multiple instances.</summary>
		[CorrespondingType(typeof(PERF_MULTI_INSTANCES))]
		PERF_MULTIPLE_INSTANCES = 4,

		/// <summary>The query returned multiple counters from each of multiple instances.</summary>
		[CorrespondingType(typeof(PERF_COUNTER_HEADER))]
		PERF_COUNTERSET = 6,
	}

	/// <summary>
	/// Indicates the types of information that you can request about a performance counter set by calling the
	/// PerfQueryCounterSetRegistrationInfo function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/ne-perflib-_perfreginfotype typedef enum _PerfRegInfoType {
	// PERF_REG_COUNTERSET_STRUCT, PERF_REG_COUNTER_STRUCT, PERF_REG_COUNTERSET_NAME_STRING, PERF_REG_COUNTERSET_HELP_STRING,
	// PERF_REG_COUNTER_NAME_STRINGS, PERF_REG_COUNTER_HELP_STRINGS, PERF_REG_PROVIDER_NAME, PERF_REG_PROVIDER_GUID,
	// PERF_REG_COUNTERSET_ENGLISH_NAME, PERF_REG_COUNTER_ENGLISH_NAMES } PerfRegInfoType;
	[PInvokeData("perflib.h", MSDNShortId = "8D54F31F-9ABA-405F-84A5-9C7225B7BE67")]
	public enum PerfRegInfoType
	{
		/// <summary>
		/// Gets the registration information for a counter set and all of the counters it contains as a PERF_COUNTERSET_REG_INFO block.
		/// The block includes a PERF_COUNTERSET_REG_INFO structure followed by one or
		/// </summary>
		PERF_REG_COUNTERSET_STRUCT = 1,

		/// <summary></summary>
		PERF_REG_COUNTER_STRUCT,

		/// <summary></summary>
		PERF_REG_COUNTERSET_NAME_STRING,

		/// <summary></summary>
		PERF_REG_COUNTERSET_HELP_STRING,

		/// <summary></summary>
		PERF_REG_COUNTER_NAME_STRINGS,

		/// <summary></summary>
		PERF_REG_COUNTER_HELP_STRINGS,

		/// <summary></summary>
		PERF_REG_PROVIDER_NAME,

		/// <summary>Gets the GUID of the provider for the counter set.</summary>
		PERF_REG_PROVIDER_GUID,

		/// <summary>
		/// Gets a null-terminated UTF-16LE string that contains the name of the counter set in English. This value is equivalent to
		/// setting the requestCode parameter to PERF_REG_COUNTERSET_NAME_STRING and the requestLangId parameter to 0 when you call the
		/// PerfQueryCounterSetRegistrationInfo function.
		/// </summary>
		PERF_REG_COUNTERSET_ENGLISH_NAME,

		/// <summary>Gets the English names of the performance counters in the counter set as a PERF_STRING_BUFFER_HEADER block.</summary>
		PERF_REG_COUNTER_ENGLISH_NAMES
	}

	/// <summary>Adds performance counter specifications to the specified query.</summary>
	/// <param name="hQuery">A handle to the query to which you want to add performance counter specifications.</param>
	/// <param name="pCounters">A pointer to the performance counter specifications that you want to add.</param>
	/// <param name="cbCounters">The size of the buffer that the pCounters parameter specifies, in bytes.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The pCounters parameter should point to a sequence of PERF_COUNTER_IDENTIFIERblocks. Each <c>PERF_COUNTER_IDENTIFIER</c> block
	/// consists of a <c>PERF_COUNTER_IDENTIFIER</c> structure, optionally followed by a null-terminated UTF-16LE instance name string,
	/// followed by padding that makes the size of the block a multiple of 8 bytes.
	/// </para>
	/// <para>For each PERF_COUNTER_IDENTIFIER block:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Set the <c>CounterSetGuid</c> member of the PERF_COUNTER_IDENTIFIER structure to the identifier of the counter set to be queried.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Set the <c>Status</c> member of the PERF_COUNTER_IDENTIFIER structure to 0.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Set <c>Size</c> member of the PERF_COUNTER_IDENTIFIER structure to the size of the <c>PERF_COUNTER_IDENTIFIER</c> block in bytes,
	/// including the <c>PERF_COUNTER_IDENTIFIER</c> structure, the instance name, and the padding. The value of <c>Size</c> must be a
	/// multiple of 8.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Set the <c>CounterId</c> member of the PERF_COUNTER_IDENTIFIER structure to the identifier of the counter that should be returned
	/// by the query. To return all counters, set <c>CounterId</c> to <c>PERF_WILDCARD_COUNTER</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Set the <c>InstanceId</c> member of the PERF_COUNTER_IDENTIFIER structure to the identifier of the instance that should be
	/// returned by the query. If no filtering should be done based on instance identifier, set <c>InstanceId</c> to <c>PERF_WILDCARD_COUNTER</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Set the <c>Index</c> member of the PERF_COUNTER_IDENTIFIER structure to 0.</term>
	/// </item>
	/// <item>
	/// <term>Set the <c>Reserved</c> member of the PERF_COUNTER_IDENTIFIER structure to 0.</term>
	/// </item>
	/// <item>
	/// <term>Include the instance name immediately after the PERF_COUNTER_IDENTIFIERstructure.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>PerfAddCounters</c> attempts to add one counter specification to the query for each PERF_COUNTER_IDENTIFIER block, and updates
	/// the <c>Status</c> member of the <c>PERF_COUNTER_IDENTIFIER</c> structure in each block with the result of the attempt.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfaddcounters ULONG PerfAddCounters( HANDLE hQuery,
	// PPERF_COUNTER_IDENTIFIER pCounters, DWORD cbCounters );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "FC66E794-EF13-47BB-A704-735924363310")]
	public static extern NTStatus PerfAddCounters([In] HPERFQUERY hQuery, [In, Out] IntPtr pCounters, uint cbCounters);

	/// <summary>Adds performance counter specifications to the specified query.</summary>
	/// <param name="hQuery">A handle to the query to which you want to add performance counter specifications.</param>
	/// <param name="pCounters">A pointer to the performance counter specifications that you want to add.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>For each PPERF_COUNTER_IDENTIFIER block:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Set the <c>CounterSetGuid</c> member of the PERF_COUNTER_IDENTIFIER structure to the identifier of the counter set to be queried.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Set the <c>CounterId</c> member of the PERF_COUNTER_IDENTIFIER structure to the identifier of the counter that should be returned
	/// by the query. To return all counters, set <c>CounterId</c> to <c>PERF_WILDCARD_COUNTER</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Set the <c>InstanceId</c> member of the PERF_COUNTER_IDENTIFIER structure to the identifier of the instance that should be
	/// returned by the query. If no filtering should be done based on instance identifier, set <c>InstanceId</c> to <c>PERF_WILDCARD_COUNTER</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Set the optional instance name.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>PerfAddCounters</c> attempts to add one counter specification to the query for each PERF_COUNTER_IDENTIFIER block, and updates
	/// the <c>Status</c> member of the <c>PERF_COUNTER_IDENTIFIER</c> structure in each block with the result of the attempt.
	/// </para>
	/// </remarks>
	[PInvokeData("perflib.h", MSDNShortId = "FC66E794-EF13-47BB-A704-735924363310")]
	public static NTStatus PerfAddCounters([In, AddAsMember] HPERFQUERY hQuery, [In, Out] PPERF_COUNTER_IDENTIFIER[] pCounters) =>
		ProcessCounters(hQuery, pCounters, PerfAddCounters);

	/// <summary>Closes a query handle that you opened by calling PerfOpenQueryHandle.</summary>
	/// <param name="hQuery">A handle to the query that you want to close</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfclosequeryhandle ULONG PerfCloseQueryHandle( HANDLE
	// hQuery );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "94D08CF1-D47C-4A1B-A0CE-8C318CDF9FE0")]
	public static extern NTStatus PerfCloseQueryHandle(HPERFQUERY hQuery);

	/// <summary>Creates an instance of the specified counter set. Providers use this function.</summary>
	/// <param name="ProviderHandle">
	/// <para>
	/// The handle of the provider. Use the handle variable that the CTRPP tool generated for you. For the name of the variable, see the
	/// <c>symbol</c> attribute of the provider element.
	/// </para>
	/// <para><c>Windows Vista:</c> The PerfStartProvider function returns the handle.</para>
	/// </param>
	/// <param name="CounterSetGuid">
	/// <para>
	/// GUID that uniquely identifies the counter set that you want to create an instance of. This is the same GUID specified in the
	/// <c>guid</c> attribute of the counterSet element. Use the GUID variable that the CTRPP tool generated for you. For the name of the
	/// variable, see the <c>symbol</c> attribute of the <c>counterSet</c> element.
	/// </para>
	/// <para><c>Windows Vista:</c> The GUID variable is not available.</para>
	/// </param>
	/// <param name="Name"><c>Null</c>-terminated Unicode string that contains a unique name for this instance.</param>
	/// <param name="Id">
	/// Unique identifier for this instance of the counter set. The identifier can be a serial number that you increment for each new instance.
	/// </param>
	/// <returns>
	/// <para>
	/// A PERF_COUNTERSET_INSTANCE structure that contains the instance of the counter set or <c>NULL</c> if PERFLIB could not create the
	/// instance. Cache this pointer to use in later calls instead of calling PerfQueryInstance to retrieve the pointer to the instance.
	/// </para>
	/// <para>This function returns <c>NULL</c> if an error occurred. To determine the error that occurred, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The provider determines when it creates an instance. If the counter data is more static, the provider can create an instance at
	/// initialization time. For example, the number of processors on a computer would be considered static, so a provider that provides
	/// counter data for processors could create an instance for each processor on the computer at initialization time. For counters that
	/// are more dynamic, such as disk or process counters, the providers would create the new instances in response to a new USB device
	/// being added or a new process being created.
	/// </para>
	/// <para>
	/// When the provider calls this function, PERFLIB allocates local memory for the new instance and builds the instance block. PERFLIB
	/// deletes the memory when the provider calls the PerfDeleteInstance function.
	/// </para>
	/// <para>The instance contains the raw counter data. Providers use the following three functions to update the raw counter data:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>PerfSetUlongCounterValue</term>
	/// </item>
	/// <item>
	/// <term>PerfSetUlongLongCounterValue</term>
	/// </item>
	/// <item>
	/// <term>PerfSetCounterRefValue</term>
	/// </item>
	/// </list>
	/// <para>
	/// Typically, the provider keeps the counter data up-to-date at all times. As an alternative, the provider can implement the
	/// ControlCallback function and use the <c>PERF_COLLECT_START</c> request code to trigger the updates.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfcreateinstance PPERF_COUNTERSET_INSTANCE
	// PerfCreateInstance( HANDLE ProviderHandle, LPCGUID CounterSetGuid, PCWSTR Name, ULONG Id );
	[PInvokeData("perflib.h", MSDNShortId = "73be8588-2c87-4c27-933d-62b8605ed9a3")]
	[return: AddAsCtor]
	public static SafePPERF_COUNTERSET_INSTANCE PerfCreateInstance([In, AddAsMember] HPERFPROV ProviderHandle, in Guid CounterSetGuid, string Name, uint Id)
	{
		return new(ProviderHandle, PerfCreateInstance(ProviderHandle, CounterSetGuid, Name, Id));

		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		static extern IntPtr PerfCreateInstance(HPERFPROV ProviderHandle, in Guid CounterSetGuid, [MarshalAs(UnmanagedType.LPWStr)] string Name, uint Id);
	}

	/// <summary>Decrements the value of a counter whose value is a 4-byte unsigned integer. Providers use this function.</summary>
	/// <param name="Provider">
	/// <para>
	/// The handle of the provider. Use the handle variable that the CTRPP tool generated for you. For the name of the variable, see the
	/// <c>symbol</c> attribute of the provider element.
	/// </para>
	/// <para><c>Windows Vista:</c> The PerfStartProvider function returns the handle.</para>
	/// </param>
	/// <param name="Instance">
	/// A PERF_COUNTERSET_INSTANCE structure that contains the counter set instance. The PerfCreateInstance function returns this pointer.
	/// </param>
	/// <param name="CounterId">
	/// <para>
	/// Identifier that uniquely identifies the counter to update in the instance block. The identifier is defined in the <c>id</c>
	/// attribute of the counter element and must match the <c>CounterId</c> member of one of the PERF_COUNTER_INFO structures in the
	/// instance block. Use the counter ID constant that the CTRPP tool generated for you. For the name of the constant, see the
	/// <c>symbol</c> attribute of the <c>counter</c> element.
	/// </para>
	/// <para><c>Windows Vista:</c> The counter ID constant is not available.</para>
	/// </param>
	/// <param name="Value">Value by which to decrement the counter.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This is a convenience function for decrementing raw counter data. To decrement the raw counter data yourself, use the
	/// <c>Offset</c> member of the PERF_COUNTER_INFO structure to access the raw counter data for a specific counter. The
	/// PERF_COUNTERSET_INSTANCE structure block contains one or more counter information structures.
	/// </para>
	/// <para>Use the PerfSetULongCounterValue function to initially set the counter value.</para>
	/// <para>Note that the counter value will underflow when the counter value decrements past zero.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfdecrementulongcountervalue ULONG
	// PerfDecrementULongCounterValue( HANDLE Provider, PPERF_COUNTERSET_INSTANCE Instance, ULONG CounterId, ULONG Value );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "5e8b40d6-b794-4bac-8832-3eb14c49ecec")]
	public static extern NTStatus PerfDecrementULongCounterValue([In, AddAsMember] HPERFPROV Provider, [In] PPERF_COUNTERSET_INSTANCE Instance, uint CounterId, uint Value);

	/// <summary>Decrements the value of a counter whose value is an 8-byte unsigned integer. Providers use this function.</summary>
	/// <param name="Provider">
	/// <para>
	/// The handle of the provider. Use the handle variable that the CTRPP tool generated for you. For the name of the variable, see the
	/// <c>symbol</c> attribute of the provider element.
	/// </para>
	/// <para><c>Windows Vista:</c> The PerfStartProvider function returns the handle.</para>
	/// </param>
	/// <param name="Instance">
	/// A PERF_COUNTERSET_INSTANCE structure that contains the counter set instance. The PerfCreateInstance function returns this pointer.
	/// </param>
	/// <param name="CounterId">
	/// <para>
	/// Identifier that uniquely identifies the counter to update in the instance block. The identifier is defined in the <c>id</c>
	/// attribute of the counter element and must match the <c>CounterId</c> member of one of the PERF_COUNTER_INFO structures in the
	/// instance block. Use the counter ID constant that the CTRPP tool generated for you. For the name of the constant, see the
	/// <c>symbol</c> attribute of the <c>counter</c> element.
	/// </para>
	/// <para><c>Windows Vista:</c> The counter ID constant is not available.</para>
	/// </param>
	/// <param name="Value">Value by which to decrement the counter.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This is a convenience function for decrementing raw counter data. To decrement the raw counter data yourself, use the
	/// <c>Offset</c> member of the PERF_COUNTER_INFO structure to access the raw counter data for a specific counter. The
	/// PERF_COUNTERSET_INSTANCE structure block contains one or more counter information structures.
	/// </para>
	/// <para>Use the PerfSetULongLongCounterValue function to initially set the counter value.</para>
	/// <para>Note that the counter value will underflow when the counter value decrements past zero.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfdecrementulonglongcountervalue ULONG
	// PerfDecrementULongLongCounterValue( HANDLE Provider, PPERF_COUNTERSET_INSTANCE Instance, ULONG CounterId, ULONGLONG Value );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "38fd52a7-c2af-4c69-a104-aba6a602fbf4")]
	public static extern NTStatus PerfDecrementULongLongCounterValue([In, AddAsMember] HPERFPROV Provider, [In] PPERF_COUNTERSET_INSTANCE Instance, uint CounterId, ulong Value);

	/// <summary>Removes the specified performance counter specifications from the specified query.</summary>
	/// <param name="hQuery">A handle to the query from which you want to remove performance counter specifications.</param>
	/// <param name="pCounters">A pointer to the performance counter specifications that you want to remove.</param>
	/// <param name="cbCounters">The size of the buffer that the pCounters parameter specifies, in bytes.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The pCounters parameter should point to a sequence of PERF_COUNTER_IDENTIFIERblocks. Each <c>PERF_COUNTER_IDENTIFIER</c> block
	/// consists of a <c>PERF_COUNTER_IDENTIFIER</c> structure, optionally followed by a null-terminated UTF-16LE instance name string,
	/// followed by padding that makes the size of the block a multiple of 8 bytes.
	/// </para>
	/// <para>Configure each PERF_COUNTER_IDENTIFIER block in the same way as described in the Remarks for PerfAddCounters.</para>
	/// <para>
	/// <c>PerfDeleteCounters</c> attempts to remove one counter specification from the query for each PERF_COUNTER_IDENTIFIER block, and
	/// updates the <c>Status</c> member of the <c>PERF_COUNTER_IDENTIFIER</c> structure in each block with the result of the attempt.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfdeletecounters ULONG PerfDeleteCounters( HANDLE
	// hQuery, PPERF_COUNTER_IDENTIFIER pCounters, DWORD cbCounters );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "330CA041-41CA-4C48-B88B-C48A0143505E")]
	public static extern NTStatus PerfDeleteCounters([In] HPERFQUERY hQuery, [In, Out] IntPtr pCounters, uint cbCounters);

	/// <summary>Removes the specified performance counter specifications from the specified query.</summary>
	/// <param name="hQuery">A handle to the query from which you want to remove performance counter specifications.</param>
	/// <param name="pCounters">The performance counter specifications that you want to remove.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <c>PerfDeleteCounters</c> attempts to remove one counter specification from the query for each PERF_COUNTER_IDENTIFIER block, and
	/// updates the <c>Status</c> member of the <c>PERF_COUNTER_IDENTIFIER</c> structure in each block with the result of the attempt.
	/// </remarks>
	[PInvokeData("perflib.h", MSDNShortId = "330CA041-41CA-4C48-B88B-C48A0143505E")]
	public static NTStatus PerfDeleteCounters([In, AddAsMember] HPERFQUERY hQuery, [In, Out] PPERF_COUNTER_IDENTIFIER[] pCounters) =>
		ProcessCounters(hQuery, pCounters, PerfDeleteCounters);

	/// <summary>Deletes an instance of the counter set created by the PerfCreateInstance function. Providers use this function.</summary>
	/// <param name="Provider">
	/// <para>
	/// The handle of the provider. Use the handle variable that the CTRPP tool generated for you. For the name of the variable, see the
	/// <c>symbol</c> attribute of the provider element.
	/// </para>
	/// <para><c>Windows Vista:</c> The PerfStartProvider function returns the handle.</para>
	/// </param>
	/// <param name="InstanceBlock">A PERF_COUNTERSET_INSTANCE structure that contains the instance of the counter set to delete.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>If the provider process terminates abnormally, all allocated instances will be released.</para>
	/// <para>
	/// The provider determines when it deletes an instance. If the counter data is more static, the provider can delete an instance at
	/// cleanup time. For example, the number of processors on a computer would be considered static, so a provider that provides counter
	/// data for processors could delete an instance for each processor on the computer at cleanup time. For counters that are more
	/// dynamic, such as disk or process counters, the providers would delete the instances in response to a USB device being removed or
	/// a process being terminated.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfdeleteinstance ULONG PerfDeleteInstance( HANDLE
	// Provider, PPERF_COUNTERSET_INSTANCE InstanceBlock );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "8266e58c-c0a3-42dd-9f06-0d04dccfcf7c")]
	public static extern NTStatus PerfDeleteInstance([In, AddAsMember] HPERFPROV Provider, [In] PPERF_COUNTERSET_INSTANCE InstanceBlock);

	/// <summary>
	/// <para>Gets the counter set identifiers of the counter sets that are registered on the specified system.</para>
	/// <para>Counter set identifiers are globally unique identifiers (GUIDs).</para>
	/// </summary>
	/// <param name="szMachine">
	/// The name of the machine for which to get the counter set identifiers. If NULL, the function retrieves the counter set identifiers for
	/// the local machine.
	/// </param>
	/// <param name="pCounterSetIds">
	/// <para>
	/// A pointer to a buffer that has enough space to receive the number of GUIDs that the <c>cCounterSetIds</c> parameter specifies. May be
	/// NULL if <c>cCounterSetIds</c> is 0.
	/// </para>
	/// </param>
	/// <param name="cCounterSetIds">The size of the buffer that the <c>pCounterSetIds</c> parameter specifies, measured in GUIDs.</param>
	/// <param name="pcCounterSetIdsActual">
	/// <para>
	/// The size of the buffer actually required to get the counter set identifiers. The meaning depends on the value that the function returns.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Function Return Value</term>
	/// <term>Meaning of <c>pcCounterSetIdsActual</c></term>
	/// </listheader>
	/// <item>
	/// <definition><c>ERROR_SUCCESS</c></definition><definition>The number of GUIDs that the function stored in the buffer that
	/// <c>pCounterSetIds</c> specified.</definition>
	/// <term/>
	/// </item>
	/// <item>
	/// <definition><c>ERROR_NOT_ENOUGH_MEMORY</c></definition><definition>The size (in GUIDs) of the buffer required. Enlarge the buffer to
	/// the required size and call the function again.</definition>
	/// </item>
	/// <item><definition>Other</definition><definition>The value is undefined and should not be used.</definition></item>
	/// </list>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <definition><c>ERROR_SUCCESS</c></definition><definition>The function successfully stored all of the content set identifiers in the
	/// buffer that <c>pCounterSetIds</c> specified. The value that <c>pcCounterSetIdsActual</c> points to indicates the number of counter
	/// set identifiers actually stored in the buffer.</definition>
	/// </item>
	/// <item>
	/// <definition><c>ERROR_NOT_ENOUGH_MEMORY</c></definition><definition>The buffer that <c>pCounterSetIds</c> specified was not large
	/// enough to store all of the counter set identifiers for the counter sets on the specified system. The value that
	/// <c>pcCounterSetIdsActual</c> points to indicates the size of the buffer required to store all of the counter set identifiers. Enlarge
	/// the buffer to the required size and call the function again.</definition>
	/// </item>
	/// </list>
	/// <para>For other types of failures, the return value is a system error code.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/perflib/nf-perflib-perfenumeratecounterset
	// ULONG PerfEnumerateCounterSet( [in, optional] LPCWSTR szMachine, [out, optional] LPGUID pCounterSetIds, DWORD cCounterSetIds, [out] LPDWORD pcCounterSetIdsActual );
	[PInvokeData("perflib.h", MSDNShortId = "NF:perflib.PerfEnumerateCounterSet")]
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	public static extern NTStatus PerfEnumerateCounterSet([MarshalAs(UnmanagedType.LPWStr), Optional] string? szMachine,
		[Out, MarshalAs(UnmanagedType.LPArray), SizeDef(nameof(cCounterSetIds), SizingMethod.Query, OutVarName = nameof(pcCounterSetIdsActual))] Guid[]? pCounterSetIds,
		uint cCounterSetIds, out uint pcCounterSetIdsActual);

	/// <summary>
	/// <para>Gets the names and identifiers of the active instances of a counter set on the</para>
	/// <para>specified system.</para>
	/// </summary>
	/// <param name="szMachine">
	/// The name of the machine for which to get the information about the active instances of the counter set that the pCounterSet
	/// parameter specifies. If NULL, the function retrieves information about the active instances of the specified counter set for the
	/// local machine.
	/// </param>
	/// <param name="pCounterSetId">
	/// The counter set identifier of the counter set for which you want to get the information about of the active instances.
	/// </param>
	/// <param name="pInstances">
	/// <para>Pointer to a buffer that is large enough to receive the amount of data that the cbInstances parameter specifies. May be</para>
	/// <para>NULL if cbInstances is 0.</para>
	/// </param>
	/// <param name="cbInstances">The size of the buffer that the pInstances parameter specifies, in bytes.</param>
	/// <param name="pcbInstancesActual">
	/// <para>
	/// The size of the buffer actually required to get the information about of the active instances. The meaning depends on the value
	/// that the function
	/// </para>
	/// <para>returns.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Function Return Value</term>
	/// <term>Meaning of pcbInstancesActual</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>
	/// The number of bytes of information about the active instances of the specified counter set that the function stored in the buffer
	/// that pInstances specified.
	/// </term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// The size of the buffer required to store the information about the active instances of the counter set on the specified machine,
	/// in bytes. Enlarge the buffer to the required size and call the function again.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>The value is undefined and should not be used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>
	/// The function successfully stored all of the information about the active instances of the counter set in the buffer that
	/// pInstances specified. The value that pcbInstancesActual points to indicates amount of information actually stored in the buffer,
	/// in bytes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// The buffer that pInstances specified was not large enough to store all of the information about the active instances of the
	/// counter set. The value that pcbInstancesActual points to indicates the size of the buffer required to store all of the
	/// information. Enlarge the buffer to the required size and call the function again.
	/// </term>
	/// </item>
	/// </list>
	/// <para>For other types of failures, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The information about the active instances of the specified counter set is written to the buffer that pInstances specifies as a
	/// sequence of PERF_INSTANCE_HEADER blocks. The size in bytes of
	/// </para>
	/// <para>the sequence of blocks is written to pcbInstancesActual. Each <c>PERF_INSTANCE_HEADER</c> block consists</para>
	/// <para>of a <c>PERF_INSTANCE_HEADER</c> structure, immediately followed by a null-terminated UTF-16LE</para>
	/// <para>instance name, followed by padding so that the size of the</para>
	/// <para><c>PERF_INSTANCE_HEADER</c> block is a multiple of 8 bytes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfenumeratecountersetinstances ULONG
	// PerfEnumerateCounterSetInstances( LPCWSTR szMachine, LPCGUID pCounterSetId, PPERF_INSTANCE_HEADER pInstances, DWORD cbInstances,
	// LPDWORD pcbInstancesActual );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "83DCEAB7-5F79-4A55-8BAC-D20F545FF76D")]
	public static extern Win32Error PerfEnumerateCounterSetInstances([MarshalAs(UnmanagedType.LPWStr), Optional] string? szMachine, in Guid pCounterSetId,
		[Out/*, MarshalAs(UnmanagedType.LPArray), SizeDef(nameof(cbInstances), SizingMethod.Query | SizingMethod.Bytes, OutVarName = nameof(pcbInstancesActual))*/] IntPtr pInstances, uint cbInstances, out uint pcbInstancesActual);

	/// <summary>Gets the names and identifiers of the active instances of a counter set on the specified system.</summary>
	/// <param name="szMachine">
	/// The name of the machine for which to get the information about the active instances of the counter set that the pCounterSet parameter
	/// specifies. If NULL, the function retrieves information about the active instances of the specified counter set for the local machine.
	/// </param>
	/// <param name="pCounterSetId">
	/// The counter set identifier of the counter set for which you want to get the information about of the active instances.
	/// </param>
	/// <param name="pInstances">
	/// A sequence of tuples containing the instance ID and name of each active instance of the specified counter set extracted from <c>PERF_INSTANCE_HEADER</c>.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>
	/// The function successfully stored all of the information about the active instances of the counter set in the buffer that pInstances
	/// specified. The value that pcbInstancesActual points to indicates amount of information actually stored in the buffer, in bytes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// The buffer that pInstances specified was not large enough to store all of the information about the active instances of the counter
	/// set. The value that pcbInstancesActual points to indicates the size of the buffer required to store all of the information. Enlarge
	/// the buffer to the required size and call the function again.
	/// </term>
	/// </item>
	/// </list>
	/// <para>For other types of failures, the return value is a system error code.</para>
	/// </returns>
	[PInvokeData("perflib.h", MSDNShortId = "83DCEAB7-5F79-4A55-8BAC-D20F545FF76D")]
	public static Win32Error PerfEnumerateCounterSetInstances(string? szMachine, in Guid pCounterSetId, out IEnumerable<(uint id, string name)> pInstances)
	{
		pInstances = [];
		var err = PerfEnumerateCounterSetInstances(szMachine, pCounterSetId, IntPtr.Zero, 0, out var pcbInstancesActual);
		if (err != Win32Error.ERROR_NOT_ENOUGH_MEMORY)
			return err;
		using var mem = new SafeHGlobalHandle(pcbInstancesActual);
		err = PerfEnumerateCounterSetInstances(szMachine, in pCounterSetId, mem, pcbInstancesActual, out pcbInstancesActual);
		if (err.Succeeded && pcbInstancesActual > 0)
		{
			List<(uint id, string name)> list = [];
			IntPtr p = mem;
			for (uint offset = 0, hsz = (uint)Marshal.SizeOf<PERF_INSTANCE_HEADER>(); offset < pcbInstancesActual;)
			{
				ref var header = ref p.Offset(offset).AsRef<PERF_INSTANCE_HEADER>();
				var name = Marshal.PtrToStringUni(p.Offset(offset + hsz)) ?? string.Empty;
				list.Add((header.InstanceId, name));
				offset += header.Size;
			}
			pInstances = list;
		}
		return err;
	}

	/// <summary>Increments the value of a counter whose value is a 4-byte unsigned integer. Providers use this function.</summary>
	/// <param name="Provider">
	/// <para>
	/// The handle of the provider. Use the handle variable that the CTRPP tool generated for you. For the name of the variable, see the
	/// <c>symbol</c> attribute of the provider element.
	/// </para>
	/// <para><c>Windows Vista:</c> The PerfStartProvider function returns the handle.</para>
	/// </param>
	/// <param name="Instance">
	/// A PERF_COUNTERSET_INSTANCE structure that contains the counter set instance. The PerfCreateInstance function returns this pointer.
	/// </param>
	/// <param name="CounterId">
	/// <para>
	/// Identifier that uniquely identifies the counter to update in the instance block. The identifier is defined in the <c>id</c>
	/// attribute of the counter element and must match the <c>CounterId</c> member of one of the PERF_COUNTER_INFO structures in the
	/// instance block. Use the counter ID constant that the CTRPP tool generated for you. For the name of the constant, see the
	/// <c>symbol</c> attribute of the <c>counter</c> element.
	/// </para>
	/// <para><c>Windows Vista:</c> The counter ID constant is not available.</para>
	/// </param>
	/// <param name="Value">Value by which to increment the counter.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This is a convenience function for incrementing raw counter data. To increment the raw counter data yourself, use the
	/// <c>Offset</c> member of the PERF_COUNTER_INFO structure to access the raw counter data for a specific counter. The
	/// PERF_COUNTERSET_INSTANCE structure block contains one or more counter information structures.
	/// </para>
	/// <para>Use the PerfSetULongCounterValue function to initially set the counter value.</para>
	/// <para>
	/// Note that the counter value will overflow when the counter value increments past the maximum size of an 4-byte unsigned integer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfincrementulongcountervalue ULONG
	// PerfIncrementULongCounterValue( HANDLE Provider, PPERF_COUNTERSET_INSTANCE Instance, ULONG CounterId, ULONG Value );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "002162a0-d782-4648-949e-178985fd1d44")]
	public static extern NTStatus PerfIncrementULongCounterValue(HPERFPROV Provider, [In] PPERF_COUNTERSET_INSTANCE Instance, uint CounterId, uint Value);

	/// <summary>Increments the value of a counter whose value is an 8-byte unsigned integer. Providers use this function.</summary>
	/// <param name="Provider">
	/// <para>
	/// The handle of the provider. Use the handle variable that the CTRPP tool generated for you. For the name of the variable, see the
	/// <c>symbol</c> attribute of the provider element.
	/// </para>
	/// <para><c>Windows Vista:</c> The PerfStartProvider function returns the handle.</para>
	/// </param>
	/// <param name="Instance">
	/// A PERF_COUNTERSET_INSTANCE structure that contains the counter set instance. The PerfCreateInstance function returns this pointer.
	/// </param>
	/// <param name="CounterId">
	/// <para>
	/// Identifier that uniquely identifies the counter to update in the instance block. The identifier is defined in the <c>id</c>
	/// attribute of the counter element and must match the <c>CounterId</c> member of one of the PERF_COUNTER_INFO structures in the
	/// instance block. Use the counter ID constant that the CTRPP tool generated for you. For the name of the constant, see the
	/// <c>symbol</c> attribute of the <c>counter</c> element.
	/// </para>
	/// <para><c>Windows Vista:</c> The counter ID constant is not available.</para>
	/// </param>
	/// <param name="Value">Value by which to increment the counter.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This is a convenience function for incrementing raw counter data. To increment the raw counter data yourself, use the
	/// <c>Offset</c> member of the PERF_COUNTER_INFO structure to access the raw counter data for a specific counter. The
	/// PERF_COUNTERSET_INSTANCE structure block contains one or more counter information structures.
	/// </para>
	/// <para>Use the PerfSetULongLongCounterValue function to initially set the counter value.</para>
	/// <para>
	/// Note that the counter value will overflow when the counter value increments past the maximum size of an 8-byte unsigned integer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfincrementulonglongcountervalue ULONG
	// PerfIncrementULongLongCounterValue( HANDLE Provider, PPERF_COUNTERSET_INSTANCE Instance, ULONG CounterId, ULONGLONG Value );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "6e701561-4036-4ae4-8d4e-667fa6a20d99")]
	public static extern NTStatus PerfIncrementULongLongCounterValue([In, AddAsMember] HPERFPROV Provider, [In] PPERF_COUNTERSET_INSTANCE Instance, uint CounterId, ulong Value);

	/// <summary>Creates a handle that references a query on the specified system. A query is a list of counter specifications.</summary>
	/// <param name="szMachine">The name of the machine for which you want to get the query handle.</param>
	/// <param name="phQuery">The handle to the query. Call PerfCloseQueryHandle to close ths handle when you no longer need it.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// Use PerfAddCounters and PerfDeleteCounters to add or remove counter specifications to the list. Use PerfQueryCounterInfo to get
	/// the counter specifications currently in the list and to determine the indexes at which the data for each counter will be returned
	/// by PerfQueryCounterData. Use <c>PerfQueryCounterData</c> to retrieve the values of the counters that match the counter specifications.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfopenqueryhandle ULONG PerfOpenQueryHandle( LPCWSTR
	// szMachine, HANDLE *phQuery );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "5105F617-9443-451D-B802-C6A241769E65")]
	public static extern NTStatus PerfOpenQueryHandle([MarshalAs(UnmanagedType.LPWStr)] string? szMachine, [AddAsCtor] out SafeHPERFQUERY phQuery);

	/// <summary>Gets the values of the performance counters that match the counter specifications in the specified query.</summary>
	/// <param name="hQuery">
	/// A handle to a query for the counter specifications of the performance counters for which you want to get the values.
	/// </param>
	/// <param name="pCounterBlock">
	/// <para>
	/// A pointer to a buffer that has enough space to receive the amount of data that the cbCounterBlock parameter specifies, in bytes.
	/// May be NULL if cbCounterBlock is 0.</para>
	/// </param>
	/// <param name="cbCounterBlock">The size of the buffer that the pCounterBlock parameter specifies, in bytes.</param>
	/// <param name="pcbCounterBlockActual">
	/// <para>
	/// The size of the buffer actually required to get the performance counter values. The meaning depends on the value that the function
	/// </para>
	/// <para>returns.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Function Return Value</term>
	/// <term>Meaning of pcbCounterBlockActual</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The number of bytes of performance counter values that the function stored in the buffer that pCounterBlock specified.</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// The size of the buffer required to store the performance counter values, in bytes. Enlarge the buffer to the required size and
	/// call the function again.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>The value is undefined and should not be used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>
	/// The function successfully stored all of the requested performance counter values in the buffer that pCounterBlock specified. The
	/// value that pcbCounterBlockActual points to indicates amount of information actually stored in the buffer, in bytes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// The buffer that pCounterBlock specified was not large enough to store all of the requested performance counter values. The value
	/// that pcbCounterBlockActual points to indicates the size of the buffer required to store all of the information. Enlarge the
	/// buffer to the required size and call the function again.
	/// </term>
	/// </item>
	/// </list>
	/// <para>For other types of failures, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// The information about the performance counter values is written to the buffer that pCounterBlock specifies as a PERF_DATA_HEADER
	/// block, which consists <c>PERF_DATA_HEADER</c> structure followed by a sequence of PERF_COUNTER_HEADER blocks.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfquerycounterdata ULONG PerfQueryCounterData( HANDLE
	// hQuery, PPERF_DATA_HEADER pCounterBlock, DWORD cbCounterBlock, LPDWORD pcbCounterBlockActual );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "EBCF00E0-6C40-40E5-9F3D-9AE5F9AB74AC")]
	[SuppressAutoGen]
	public static extern Win32Error PerfQueryCounterData(HPERFQUERY hQuery, [Out, SizeDef(nameof(cbCounterBlock), SizingMethod.Query | SizingMethod.Bytes, OutVarName = nameof(pcbCounterBlockActual))] IntPtr pCounterBlock,
		uint cbCounterBlock, out uint pcbCounterBlockActual);

	/// <summary>Gets the values of the performance counters that match the counter specifications in the specified query.</summary>
	/// <param name="hQuery">
	/// A handle to a query for the counter specifications of the performance counters for which you want to get the values.
	/// </param>
	/// <param name="pCounterBlock">A pointer to a buffer that receives the performance counter values as a PERF_DATA_HEADER block.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>
	/// The function successfully stored all of the requested performance counter values in the buffer that pCounterBlock specified. The
	/// value that pcbCounterBlockActual points to indicates amount of information actually stored in the buffer, in bytes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// The buffer that pCounterBlock specified was not large enough to store all of the requested performance counter values. The value
	/// that pcbCounterBlockActual points to indicates the size of the buffer required to store all of the information. Enlarge the
	/// buffer to the required size and call the function again.
	/// </term>
	/// </item>
	/// </list>
	/// <para>For other types of failures, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// The information about the performance counter values is written to the buffer that pCounterBlock specifies as a PERF_DATA_HEADER
	/// block, which consists <c>PERF_DATA_HEADER</c> structure followed by a sequence of PERF_COUNTER_HEADER blocks.
	/// </remarks>
	[PInvokeData("perflib.h", MSDNShortId = "EBCF00E0-6C40-40E5-9F3D-9AE5F9AB74AC")]
	public static NTStatus PerfQueryCounterData([In, AddAsMember] HPERFQUERY hQuery, out SafeCoTaskMemStruct<PERF_DATA_HEADER> pCounterBlock)
	{
		var err = PerfQueryCounterData(hQuery, IntPtr.Zero, 0, out var pcbCounterBlockActual);
		if (err != Win32Error.ERROR_NOT_ENOUGH_MEMORY)
		{
			pCounterBlock = SafeCoTaskMemStruct<PERF_DATA_HEADER>.Null;
			return err;
		}
		pCounterBlock = new(pcbCounterBlockActual);
		return PerfQueryCounterData(hQuery, pCounterBlock, pcbCounterBlockActual, out _);
	}

	/// <summary>Gets the counter specifications in the specified query.</summary>
	/// <param name="hQuery">A handle to the query for which you want to get the counter specifications</param>
	/// <param name="pCounters">
	/// Pointer to a buffer that is large enough to hold the amount of data that the cbCounters parameter specifies, in bytes. May be
	/// NULL if cbCounters is 0.
	/// </param>
	/// <param name="cbCounters">The size of the pCounters buffer, in bytes.</param>
	/// <param name="pcbCountersActual">
	/// <para>
	/// The size of the buffer actually required to get the counter specifications. The meaning depends on the value that the function
	/// </para>
	/// <para>returns.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Function Return Value</term>
	/// <term>Meaning of pcbCountersActual</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>
	/// The number of bytes of information about the counter specifications that the function stored in the buffer that pCounters specified.
	/// </term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// The size of the buffer required to store the information about the counter specifications, in bytes. Enlarge the buffer to the
	/// required size and call the function again.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>The value is undefined and should not be used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>
	/// The function successfully stored all of the information about the counter specifications in the buffer that pCounters specified.
	/// The value that pcbCountersActual points to indicates amount of information actually stored in the buffer, in bytes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// The buffer that pCounters specified was not large enough to store all of the information about the counter specifications. The
	/// value that pcbCountersActual points to indicates the size of the buffer required to store all of the information. Enlarge the
	/// buffer to the required size and call the function again.
	/// </term>
	/// </item>
	/// </list>
	/// <para>For other types of failures, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The information about the counter specifications is written to the buffer that pCounters specifies as a sequence of
	/// PERF_COUNTER_IDENTIFIER blocks. The size in bytes of
	/// </para>
	/// <para>the sequence of blocks is written to pcbCountersActual. Each <c>PERF_COUNTER_IDENTIFIER</c> block consists</para>
	/// <para>of a <c>PERF_COUNTER_IDENTIFIER</c> structure, optionally followed by a null-terminated UTF-16LE</para>
	/// <para>instance name, followed by padding so that the size of the</para>
	/// <para>
	/// <c>PERF_COUNTER_IDENTIFIER</c> block is a multiple of 8 bytes. The size of each block, including the
	/// <c>PERF_COUNTER_IDENTIFIER</c> structure, instance name, and padding, is determined by the <c>Size</c> member of the
	/// <c>PERF_COUNTER_IDENTIFIER</c> structure, which will be a multiple of 8 bytes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfquerycounterinfo ULONG PerfQueryCounterInfo( HANDLE
	// hQuery, PPERF_COUNTER_IDENTIFIER pCounters, DWORD cbCounters, LPDWORD pcbCountersActual );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "42CAB98C-4525-499D-BA11-731A666E112D")]
	public static extern NTStatus PerfQueryCounterInfo([In] HPERFQUERY hQuery, [Out] IntPtr pCounters, uint cbCounters, out uint pcbCountersActual);

	/// <summary>Gets the counter specifications in the specified query.</summary>
	/// <param name="hQuery">A handle to the query for which you want to get the counter specifications</param>
	/// <param name="pCounters">
	/// The counter specifications as a collection of tuples containing the PERF_COUNTER_IDENTIFIER and optional name.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>
	/// The function successfully stored all of the information about the counter specifications in the buffer that pCounters specified. The
	/// value that pcbCountersActual points to indicates amount of information actually stored in the buffer, in bytes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// The buffer that pCounters specified was not large enough to store all of the information about the counter specifications. The value
	/// that pcbCountersActual points to indicates the size of the buffer required to store all of the information. Enlarge the buffer to the
	/// required size and call the function again.
	/// </term>
	/// </item>
	/// </list>
	/// <para>For other types of failures, the return value is a system error code.</para>
	/// </returns>
	[PInvokeData("perflib.h", MSDNShortId = "42CAB98C-4525-499D-BA11-731A666E112D")]
	public static NTStatus PerfQueryCounterInfo([In, AddAsMember] HPERFQUERY hQuery, out IReadOnlyList<PPERF_COUNTER_IDENTIFIER> pCounters)
	{
		pCounters = [];
		var err = PerfQueryCounterInfo(hQuery, IntPtr.Zero, 0, out var pcbCountersActual);
		if (err != NTStatus.STATUS_BUFFER_TOO_SMALL)
			return err;
		using var mem = new SafeHGlobalHandle(pcbCountersActual);
		err = PerfQueryCounterInfo(hQuery, mem, pcbCountersActual, out pcbCountersActual);
		if (err.Succeeded && pcbCountersActual > 0)
		{
			List<PPERF_COUNTER_IDENTIFIER> pc = [];
			for (int offset = 0; offset < pcbCountersActual;)
			{
				PPERF_COUNTER_IDENTIFIER pci = new(mem.DangerousGetHandle().Offset(offset));
				pc.Add(pci);
				offset += (int)pci.Size;
			}
			pCounters = pc;
		}
		return err;
	}

	/// <summary>Gets information about a counter set on the specified system.</summary>
	/// <param name="szMachine">
	/// The name of the machine for which to get the information about the counter set that the pCounterSet parameter specifies. If NULL, the
	/// function retrieves information about the specified counter set for the local machine.
	/// </param>
	/// <param name="pCounterSetId">The counter set identifier of the counter set for which you want to get information.</param>
	/// <param name="requestCode">
	/// The type of information that you want to get about the counter set. See PerfRegInfoType for a list of possible values.
	/// </param>
	/// <param name="requestLangId">
	/// <para>
	/// The preferred locale identifier for the strings that contain the requested information if requestCode is
	/// <c>PERF_REG_COUNTERSET_NAME_STRING</c>, <c>PERF_REG_COUNTERSET_HELP_STRING</c>, <c>PERF_REG_COUNTER_NAME_STRINGS</c>, or <c>PERF_REG_COUNTER_HELP_STRINGS</c>.
	/// </para>
	/// <para>The counter identifier of the counter for which you want data, if requestCode is <c>PERF_REG_COUNTER_STRUCT</c>.</para>
	/// <para>Set to 0 for all other values of requestCode.</para>
	/// </param>
	/// <param name="pbRegInfo">
	/// <para>
	/// Pointer to a buffer that is large enough to receive the amount of data that the cbRegInfo parameter specifies, in bytes. May be
	/// </para>
	/// <para>NULL if cbRegInfo is 0.</para>
	/// </param>
	/// <param name="cbRegInfo">The size of the buffer that the pbRegInfo parameter specifies, in bytes.</param>
	/// <param name="pcbRegInfoActual">
	/// <para>
	/// The size of the buffer actually required to get the information about the counter set. The meaning depends on the value that the function
	/// </para>
	/// <para>returns.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Function Return Value</term>
	/// <term>Meaning of pcbRegInfoActual</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The number of bytes of information about the specified counter set that the function stored in the buffer that pbRegInfo specified.</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// The size of the buffer required to store the information about the counter set on the specified machine, in bytes. Enlarge the buffer
	/// to the required size and call the function again.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>The value is undefined and should not be used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>
	/// The function successfully stored all of the information about the counter set in the buffer that pbRegInfo specified. The value that
	/// pcbRegInfoActual points to indicates amount of information actually stored in the buffer, in bytes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>
	/// The buffer that pbRegInfo specified was not large enough to store all of the information about the counter set. The value that
	/// pcbRegInfoActual points to indicates the size of the buffer required to store all of the information. Enlarge the buffer to the
	/// required size and call the function again.
	/// </term>
	/// </item>
	/// </list>
	/// <para>For other types of failures, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>See PerfRegInfoType for the types of data that you can request and</para>
	/// <para>the formats of the data provided for each type of request.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfquerycountersetregistrationinfo ULONG
	// PerfQueryCounterSetRegistrationInfo( LPCWSTR szMachine, LPCGUID pCounterSetId, PerfRegInfoType requestCode, DWORD requestLangId,
	// LPBYTE pbRegInfo, DWORD cbRegInfo, LPDWORD pcbRegInfoActual );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "E8E83E47-2445-42AE-855F-6710FC8F789E")]
	public static extern Win32Error PerfQueryCounterSetRegistrationInfo([MarshalAs(UnmanagedType.LPWStr), Optional] string? szMachine, in Guid pCounterSetId,
		PerfRegInfoType requestCode, uint requestLangId, [Out, SizeDef(nameof(cbRegInfo), SizingMethod.Query, OutVarName = nameof(pcbRegInfoActual))] IntPtr pbRegInfo, uint cbRegInfo, out uint pcbRegInfoActual);

	/// <summary>Retrieves a pointer to the specified counter set instance. Providers use this function.</summary>
	/// <param name="ProviderHandle">
	/// <para>
	/// The handle of the provider. Use the handle variable that the CTRPP tool generated for you. For the name of the variable, see the
	/// <c>symbol</c> attribute of the provider element.
	/// </para>
	/// <para><c>Windows Vista:</c> The PerfStartProvider function returns the handle.</para>
	/// </param>
	/// <param name="CounterSetGuid">
	/// <para>
	/// GUID that uniquely identifies the counter set that you want to query. This is the same GUID specified in the <c>guid</c>
	/// attribute of the counterSet element. Use the GUID variable that the CTRPP tool generated for you. For the name of the variable,
	/// see the <c>symbol</c> attribute of the <c>counterSet</c> element.
	/// </para>
	/// <para><c>Windows Vista:</c> The GUID variable is not available.</para>
	/// </param>
	/// <param name="Name"><c>Null</c>-terminated Unicode string that contains the name of counter set instance that you want to retrieve.</param>
	/// <param name="Id">Unique identifier of the counter set instance that you want to retrieve.</param>
	/// <returns>
	/// <para>A PERF_COUNTERSET_INSTANCE structure that contains the counter set instance or <c>NULL</c> if the instance does not exist.</para>
	/// <para>This function returns <c>NULL</c> if an error occurred. To determine the error that occurred, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use the same instance name and identifier that you used when calling PerfCreateInstance to retrieve a specific instance of the
	/// counter set.
	/// </para>
	/// <para>
	/// Providers should cache the pointer to the instance when they create the instance instead of calling this function to retrieve the pointer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfqueryinstance PPERF_COUNTERSET_INSTANCE
	// PerfQueryInstance( HANDLE ProviderHandle, LPCGUID CounterSetGuid, PCWSTR Name, ULONG Id );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "844f3f9e-8de2-4995-b13c-befe0da8a1ab")]
	public static extern PPERF_COUNTERSET_INSTANCE PerfQueryInstance([In, AddAsMember] HPERFPROV ProviderHandle, in Guid CounterSetGuid, [MarshalAs(UnmanagedType.LPWStr)] string Name, uint Id);

	/// <summary>Updates the value of a counter whose value is a pointer to the actual data. Providers use this function.</summary>
	/// <param name="Provider">
	/// <para>
	/// The handle of the provider. Use the handle variable that the CTRPP tool generated for you. For the name of the variable, see the
	/// <c>symbol</c> attribute of the provider element.
	/// </para>
	/// <para><c>Windows Vista:</c> The PerfStartProvider function returns the handle.</para>
	/// </param>
	/// <param name="Instance">
	/// A PERF_COUNTERSET_INSTANCE structure that contains the counter set instance. The PerfCreateInstance function returns this pointer.
	/// </param>
	/// <param name="CounterId">
	/// <para>
	/// Identifier that uniquely identifies the counter to update in the instance block. The identifier is defined in the <c>id</c>
	/// attribute of the counter element and must match the <c>CounterId</c> member of one of the PERF_COUNTER_INFO structures in the
	/// instance block. Use the counter ID constant that the CTRPP tool generated for you. For the name of the constant, see the
	/// <c>symbol</c> attribute of the <c>counter</c> element.
	/// </para>
	/// <para><c>Windows Vista:</c> The counter ID constant is not available.</para>
	/// </param>
	/// <param name="Address">
	/// <para>Pointer to the actual counter data.</para>
	/// <para>If <c>NULL</c>, the consumer receives ERROR_NO_DATA.</para>
	/// <para>
	/// To indicate that the counter data is accessed by reference, the counter declaration in the manifest must include a
	/// counterAttribute element whose <c>name</c> attribute is set to "reference".
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This is a convenience function for specifying a reference to the raw counter data. To update the reference to the raw counter
	/// data yourself, use the <c>Offset</c> member of the PERF_COUNTER_INFO structure to access the counter value for a specific
	/// counter. The <c>Attrib</c> member must include the PERF_ATTRIB_BY_REFERENCE flag. The PERF_COUNTERSET_INSTANCE structure block
	/// contains one or more counter information structures.
	/// </para>
	/// <para>
	/// Depending on the counter type, the pointer must reference a 4-byte or 8-byte unsigned integer. When collecting the counter data,
	/// PERFLIB dereferences the pointer and returns the actual data.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfsetcounterrefvalue ULONG PerfSetCounterRefValue(
	// HANDLE Provider, PPERF_COUNTERSET_INSTANCE Instance, ULONG CounterId, PVOID Address );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "0694ff8c-4c36-4bf7-a2b3-c032bf7a2f65")]
	public static extern NTStatus PerfSetCounterRefValue([In, AddAsMember] HPERFPROV Provider, [In] PPERF_COUNTERSET_INSTANCE Instance, uint CounterId, IntPtr Address);

	/// <summary>Specifies the layout of a particular counter set.</summary>
	/// <param name="ProviderHandle">
	/// <para>
	/// The handle of the provider. Use the handle variable that the CTRPP tool generated for you. For the name of the variable, see the
	/// <c>symbol</c> attribute of the provider element.
	/// </para>
	/// <para><c>Windows Vista:</c> The PerfStartProvider function returns the handle.</para>
	/// </param>
	/// <param name="Template">Buffer that contains the counter set information. For details, see PERF_COUNTERSET_INFO.</param>
	/// <param name="TemplateSize">Size, in bytes, of the pTemplate buffer.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>The CounterInitialize function calls this function; do not call this function directly.</para>
	/// <para><c>Windows Vista:</c> The <c>PerfAutoInitialize</c> function calls this function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfsetcountersetinfo ULONG PerfSetCounterSetInfo( HANDLE
	// ProviderHandle, PPERF_COUNTERSET_INFO Template, ULONG TemplateSize );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "b4295503-5588-4898-816c-939a5920fc77")]
	public static extern NTStatus PerfSetCounterSetInfo([In, AddAsMember] HPERFPROV ProviderHandle, [In] IntPtr Template, uint TemplateSize);

	/// <summary>Updates the value of a counter whose value is a 4-byte unsigned integer. Providers use this function.</summary>
	/// <param name="Provider">
	/// <para>
	/// The handle of the provider. Use the handle variable that the CTRPP tool generated for you. For the name of the variable, see the
	/// <c>symbol</c> attribute of the provider element.
	/// </para>
	/// <para><c>Windows Vista:</c> The PerfStartProvider function returns the handle.</para>
	/// </param>
	/// <param name="Instance">
	/// A PERF_COUNTERSET_INSTANCE structure that contains the counter set instance. The PerfCreateInstance function returns this pointer.
	/// </param>
	/// <param name="CounterId">
	/// <para>
	/// Identifier that uniquely identifies the counter to update in the instance block. The identifier is defined in the <c>id</c>
	/// attribute of the counter element and must match the <c>CounterId</c> member of one of the PERF_COUNTER_INFO structures in the
	/// instance block. Use the counter ID constant that the CTRPP tool generated for you. For the name of the constant, see the
	/// <c>symbol</c> attribute of the <c>counter</c> element.
	/// </para>
	/// <para><c>Windows Vista:</c> The counter ID constant is not available.</para>
	/// </param>
	/// <param name="Value">New 4-byte counter value.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This is a convenience function for setting raw counter data. To update the raw counter data yourself, use the <c>Offset</c>
	/// member of the PERF_COUNTER_INFO structure to access the raw counter data for a specific counter. The PERF_COUNTERSET_INSTANCE
	/// structure block contains one or more counter information structures.
	/// </para>
	/// <para>
	/// You can use the PerfIncrementULongCounterValue and PerfDecrementULongCounterValue functions to increment or decrement the counter
	/// value, respectively.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfsetulongcountervalue ULONG PerfSetULongCounterValue(
	// HANDLE Provider, PPERF_COUNTERSET_INSTANCE Instance, ULONG CounterId, ULONG Value );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "b790bea0-90d8-4894-bacb-a27f777cf240")]
	public static extern NTStatus PerfSetULongCounterValue([In, AddAsMember] HPERFPROV Provider, [In] PPERF_COUNTERSET_INSTANCE Instance, uint CounterId, uint Value);

	/// <summary>Updates the value of a counter whose value is an 8-byte unsigned integer. Providers use this function.</summary>
	/// <param name="Provider">
	/// <para>
	/// The handle of the provider. Use the handle variable that the CTRPP tool generated for you. For the name of the variable, see the
	/// <c>symbol</c> attribute of the provider element.
	/// </para>
	/// <para><c>Windows Vista:</c> The PerfStartProvider function returns the handle.</para>
	/// </param>
	/// <param name="Instance">
	/// A PERF_COUNTERSET_INSTANCE structure that contains the counter set instance. The PerfCreateInstance function returns this pointer.
	/// </param>
	/// <param name="CounterId">
	/// <para>
	/// Identifier that uniquely identifies the counter to update in the instance block. The identifier is defined in the <c>id</c>
	/// attribute of the counter element and must match the <c>CounterId</c> member of one of the PERF_COUNTER_INFO structures in the
	/// instance block. Use the counter ID constant that the CTRPP tool generated for you. For the name of the constant, see the
	/// <c>symbol</c> attribute of the <c>counter</c> element.
	/// </para>
	/// <para><c>Windows Vista:</c> The counter ID constant is not available.</para>
	/// </param>
	/// <param name="Value">New 8-byte counter value.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This is a convenience function for setting raw counter data. To update the raw counter data yourself, use the <c>Offset</c>
	/// member of the PERF_COUNTER_INFO structure to access the raw counter data for a specific counter. The PERF_COUNTERSET_INSTANCE
	/// structure block contains one or more counter information structures.
	/// </para>
	/// <para>
	/// You can use the PerfIncrementULongLongCounterValue and PerfDecrementULongLongCounterValue functions to increment or decrement the
	/// counter value, respectively.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfsetulonglongcountervalue ULONG
	// PerfSetULongLongCounterValue( HANDLE Provider, PPERF_COUNTERSET_INSTANCE Instance, ULONG CounterId, ULONGLONG Value );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "c38f9efc-7ea8-4841-9a31-a88d4f87369c")]
	public static extern NTStatus PerfSetULongLongCounterValue([In, AddAsMember] HPERFPROV Provider, [In] PPERF_COUNTERSET_INSTANCE Instance, uint CounterId, ulong Value);

	/// <summary>Registers the provider.</summary>
	/// <param name="ProviderGuid">
	/// GUID that uniquely identifies the provider. The <c>providerGuid</c> attribute of the provider element specifies the GUID.
	/// </param>
	/// <param name="ControlCallback">
	/// ControlCallback function that PERFLIB calls to notify you of consumer requests, such as a request to add or remove counters from
	/// the query. This parameter is set if the <c>callback</c> attribute of the <c>counters</c> element is "custom"; otherwise, <c>NULL</c>.
	/// </param>
	/// <param name="phProvider">Handle to the provider. You must call PerfStopProvider to release resources associated with the handle.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>The CounterInitialize function calls this function; do not call this function directly.</para>
	/// <para><c>Windows Vista:</c> The <c>PerfAutoInitialize</c> function calls this function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfstartprovider ULONG PerfStartProvider( LPGUID
	// ProviderGuid, PERFLIBREQUEST ControlCallback, HANDLE *phProvider );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "b417b19b-adbc-40e3-aca1-c2cd94a79232")]
	public static extern NTStatus PerfStartProvider(in Guid ProviderGuid, [Optional] ControlCallback? ControlCallback, [AddAsCtor] out SafeHPERFPROV phProvider);

	/// <summary>Registers the provider.</summary>
	/// <param name="ProviderGuid">
	/// GUID that uniquely identifies the provider. The <c>providerGuid</c> attribute of the provider element specifies the GUID.
	/// </param>
	/// <param name="ProviderContext">
	/// A PERF_PROVIDER_CONTEXT structure that contains pointers to the control callback, memory management routines, and context information.
	/// </param>
	/// <param name="Provider">Handle to the provider. You must call PerfStopProvider to release resources associated with the handle.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>The CounterInitialize function calls this function; do not call this function directly.</para>
	/// <para><c>Windows Vista:</c> The <c>PerfAutoInitialize</c> function calls this function.</para>
	/// <para>
	/// The CTRPP tool includes this function instead of PerfStartProvider if you use the <c>-MemoryRoutines</c> argument or
	/// <c>-NotificationCallback</c> argument when calling CTRPP, or if the <c>callback</c> attribute of the provider element is set to "custom".
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfstartproviderex ULONG PerfStartProviderEx( LPGUID
	// ProviderGuid, PPERF_PROVIDER_CONTEXT ProviderContext, PHANDLE Provider );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "9f3aefbf-0836-46fc-8a53-858c3c94cef9")]
	public static extern NTStatus PerfStartProviderEx(in Guid ProviderGuid, in PERF_PROVIDER_CONTEXT ProviderContext, [AddAsCtor] out SafeHPERFPROV Provider);

	/// <summary>
	/// Removes the provider's registration from the list of registered providers and frees all resources associated with the provider.
	/// </summary>
	/// <param name="ProviderHandle">Handle to the provider.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a system error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>The CounterCleanup function calls this function; do not call this function directly.</para>
	/// <para><c>Windows Vista:</c> The <c>PerfAutoCleanup</c> function calls this function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/nf-perflib-perfstopprovider ULONG PerfStopProvider( HANDLE
	// ProviderHandle );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("perflib.h", MSDNShortId = "4b31f88b-cadc-4bee-bdea-9079cc14c140")]
	public static extern NTStatus PerfStopProvider(HPERFPROV ProviderHandle);

	internal static int Mult8(int x) => (x + 7) & ~7;

	internal static NTStatus ProcessCounters([In] HPERFQUERY hQuery, [In, Out] PPERF_COUNTER_IDENTIFIER[] pCounters, Func<HPERFQUERY, IntPtr, uint, NTStatus> f)
	{
		if (pCounters is null || pCounters.Length == 0)
			return NTStatus.STATUS_INVALID_PARAMETER;
		var size = pCounters.Sum(pc => pc.Size);
		using SafeCoTaskMemStruct<PERF_COUNTER_IDENTIFIER> mem = new(size);
		var ptr = mem.DangerousGetHandle();
		foreach (var pci in pCounters)
		{
			pci.Write(ptr);
			ptr += (int)pci.Size;
		}
		var err = f(hQuery, mem, (uint)size);
		if (err.Succeeded)
		{
			unsafe
			{
				var e = (PERF_COUNTER_IDENTIFIER*)mem;
				for (int i = 0; i < pCounters.Length; i++)
				{
					pCounters[i] = new(e);
					e = (PERF_COUNTER_IDENTIFIER*)((byte*)e + e->Size);
				}
			}
		}
		return err;
	}

	/// <summary>
	/// <para>
	/// Contains information about the <c>PERF_COUNTER_DATA</c> block that contains the structure. A <c>PERF_COUNTER_DATA</c> block
	/// provides raw performance counter data, and consists of the following items in order:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>A <c>PERF_COUNTER_DATA</c> structure.</term>
	/// </item>
	/// <item>
	/// <term>Raw performance counter data.</term>
	/// </item>
	/// <item>
	/// <term>Padding to make the total size of the block a multiple of eight bytes.</term>
	/// </item>
	/// </list>
	/// </summary>
	/// <remarks>
	/// The PerfQueryCounterData function returns a PERF_DATA_HEADER block that may contain <c>PERF_COUNTER_DATA</c> blocks directly, or
	/// indirectly as part of a PERF_MULTI_INSTANCES block.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/ns-perflib-perf_counter_data typedef struct _PERF_COUNTER_DATA {
	// ULONG dwDataSize; ULONG dwSize; } PERF_COUNTER_DATA, *PPERF_COUNTER_DATA;
	[PInvokeData("perflib.h", MSDNShortId = "19D65E98-182E-45CC-946F-F1924CB78029")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PERF_COUNTER_DATA
	{
		/// <summary>
		/// The size of the raw performance counter data that follows the <c>PERF_COUNTER_DATA</c> structure in the
		/// <c>PERF_COUNTER_DATA</c> block, in bytes.
		/// </summary>
		public uint dwDataSize;

		/// <summary>
		/// <para>The total size of the <c>PERF_COUNTER_DATA</c> block, which is the sum of the sizes of the following items:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The <c>PERF_COUNTER_DATA</c> structure</term>
		/// </item>
		/// <item>
		/// <term>The raw performance counter data</term>
		/// </item>
		/// <item>
		/// <term>The padding that ensures that the size of the <c>PERF_COUNTER_DATA</c> block is a multiple of 8 bytes</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwSize;

		/// <summary>Gets the raw performance counter data.</summary>
		public static ulong GetData(StructPointer<PERF_COUNTER_DATA> pcd)
		{
			unsafe
			{
				var pData = (byte*)((PERF_COUNTER_DATA*)pcd + 1);
				return ((PERF_COUNTER_DATA*)pcd)->dwDataSize == 4 ? *(uint*)pData : *(ulong*)pData;
			}
		}
	}

	/// <summary>
	/// Contains information about the <c>PERF_COUNTER_HEADER</c> block that contains the structure. A <c>PERF_COUNTER_HEADER</c> block
	/// provides error information and data for performance counter queries, and consists of a <c>PERF_COUNTER_HEADER</c> structure
	/// followed by additional performance counter data.
	/// </summary>
	/// <remarks>
	/// The PerfQueryCounterData function returns a PERF_DATA_HEADER block that contains a sequence of <c>PERF_COUNTER_HEADER</c> blocks.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/ns-perflib-_perf_counter_header typedef struct _PERF_COUNTER_HEADER {
	// ULONG dwStatus; PerfCounterDataType dwType; ULONG dwSize; ULONG Reserved; } PERF_COUNTER_HEADER, *PPERF_COUNTER_HEADER;
	[PInvokeData("perflib.h", MSDNShortId = "8C07E4BB-61CD-4A0F-8C23-86BE7DAA415F")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PERF_COUNTER_HEADER
	{
		/// <summary>An error code that indicates whether the operation to query the performance succeeded or failed.</summary>
		public Win32Error dwStatus;

		/// <summary>
		/// <para>The type of performance counter information that the <c>PERF_COUNTER_HEADER</c> block provides.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PERF_ERROR_RETURN</term>
		/// <term>
		/// An error that was the result of a performance counter query. The performance library cannot get valid counter data back from
		/// provider. No additional data follows the PERF_COUNTER_HEADER structure. The dwStatus member of the structure contains the
		/// error code.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PERF_SINGLE_COUNTER</term>
		/// <term>
		/// The result of a single-counter, single-instance query; for example, "\Processor(_Total)\% Processor Time". The additional
		/// data consists of a PERF_COUNTER_DATA block.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PERF_MULTIPLE_COUNTERS</term>
		/// <term>
		/// The result of a multi-counter, single-instance query; for example, "\Processor(_Total)\*". The additional data consists of a
		/// PERF_MULTI_COUNTERS block followed by PERF_COUNTER_DATA blocks.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PERF_MULTIPLE_INSTANCES</term>
		/// <term>
		/// The result of a single-counter, multi-instance query; for example, "\Processor(*)\% Processor Time". The additional data
		/// consists of a PERF_MULTI_INSTANCES block.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PERF_COUNTERSET</term>
		/// <term>
		/// The result of a multi-counter, multi-instance query; for example, "\Processor(*)\*". The additional data consists of a
		/// PERF_MULTI_COUNTERS block followed by a PERF_MULTI_INSTANCES block.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public PerfCounterDataType dwType;

		/// <summary>
		/// The total size of the <c>PERF_COUNTER_HEADER</c> block, which equals the sum of the size of the <c>PERF_COUNTER_HEADER</c>
		/// structure and the size of the additional data.
		/// </summary>
		public uint dwSize;

		/// <summary>Reserved.</summary>
		public uint Reserved;

		internal static readonly int cntHdrSz = Marshal.SizeOf<PERF_COUNTER_HEADER>();

		internal readonly bool ValidFor(PerfCounterDataType type) => dwType == type && dwSize > cntHdrSz;

		/// <summary>Gets the data for a single-counter, single-instance query.</summary>
		public static StructPointer<PERF_COUNTER_DATA> GetSingleCounter(StructPointer<PERF_COUNTER_HEADER> ptr) =>
			GetTrailingStruct<PERF_COUNTER_DATA>(ptr, PerfCounterDataType.PERF_SINGLE_COUNTER);

		/// <summary>Gets the single-counter, single-instance query.</summary>
		public static ulong GetSingleCounterData(StructPointer<PERF_COUNTER_HEADER> ptr) =>
			PERF_COUNTER_DATA.GetData(GetSingleCounter(ptr));

		/// <summary>Enumerates the multiple counters in the data header.</summary>
		public static StructPointer<PERF_MULTI_COUNTERS> GetCounterset(StructPointer<PERF_COUNTER_HEADER> ptr) =>
			GetTrailingStruct<PERF_MULTI_COUNTERS>(ptr, PerfCounterDataType.PERF_COUNTERSET);

		/// <summary>Gets the multiple counters in the data header.</summary>
		public static StructPointer<PERF_MULTI_COUNTERS> GetMultiCounters(StructPointer<PERF_COUNTER_HEADER> ptr) =>
			GetTrailingStruct<PERF_MULTI_COUNTERS>(ptr, PerfCounterDataType.PERF_MULTIPLE_COUNTERS);

		/// <summary>Enumerates the multiple counters in the data header.</summary>
		public static IEnumerable<(uint id, ulong data)> GetMultiCountersData(StructPointer<PERF_COUNTER_HEADER> ptr) =>
			PERF_MULTI_COUNTERS.GetDataBlocks(GetMultiCounters(ptr));

		/// <summary>Enumerates the instances in the data header.</summary>
		public static StructPointer<PERF_MULTI_INSTANCES> GetMultiInstances(StructPointer<PERF_COUNTER_HEADER> ptr) =>
			GetTrailingStruct<PERF_MULTI_INSTANCES>(ptr, PerfCounterDataType.PERF_MULTIPLE_INSTANCES);

		private static StructPointer<T> GetTrailingStruct<T>(StructPointer<PERF_COUNTER_HEADER> ptr, PerfCounterDataType type) where T : unmanaged
		{
			if (!ptr.AsRef().ValidFor(type))
				throw new ArgumentException($"The PERF_COUNTER_HEADER does not contain a {typeof(T).Name} structure.", nameof(ptr));
			return ((IntPtr)ptr).Offset(cntHdrSz);
		}
	}

	/// <summary>
	/// <para>
	/// Contains information about the <c>PERF_COUNTER_IDENTIFIER</c> block that contains the structure. A <c>PERF_COUNTER_IDENTIFIER</c>
	/// block provides information about a performance counter specification, and consists of the following items in order:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>A <c>PERF_COUNTER_IDENTIFIER</c> structure</term>
	/// </item>
	/// <item>
	/// <term>An optional null-terminated UTF-16LE string that specifies the instance name</term>
	/// </item>
	/// <item>
	/// <term>Padding as needed to make the size of the block a multiple of 8 bytes.</term>
	/// </item>
	/// </list>
	/// </summary>
	/// <remarks>
	/// <para>
	/// When you specify a counter set identifier for a single-instance counter set, you must not specify the instance name in the
	/// additional data of the <c>PERF_COUNTER_IDENTIFIER</c> block. The size of the <c>PERF_COUNTER_IDENTIFIER</c> block must be the
	/// size of the <c>PERF_COUNTER_IDENTIFIER</c> structure.
	/// </para>
	/// <para>
	/// On the other hand, when you specify a counter set identifier for a multiple-instance counter set, you must specify the instance
	/// name in the additional data of the <c>PERF_COUNTER_IDENTIFIER</c> block. The identifier is notconsidered valid unless the size of
	/// the <c>PERF_COUNTER_IDENTIFIER</c> block is greater than the size of the <c>PERF_COUNTER_IDENTIFIER</c> structure. If you do not
	/// want to filter the counter sets based on the instance name, use <c>PERF_WILDCARD_INSTANCE</c> as the instance name.
	/// </para>
	/// <para>
	/// The PerfAddCounters and PerfDeleteCounters functions accept a sequence of <c>PERF_COUNTER_IDENTIFIER</c> blocks to define the
	/// counter specifications that you want to be add or remove from a query.
	/// </para>
	/// <para>
	/// The PerfQueryCounterInfo function gets a sequence of <c>PERF_COUNTER_IDENTIFIER</c> blocks to indicate the counter specifications
	/// in a query and to indicate in the <c>Index</c> member the order in which the query gets the results.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/ns-perflib-_perf_counter_identifier typedef struct
	// _PERF_COUNTER_IDENTIFIER { GUID CounterSetGuid; ULONG Status; ULONG Size; ULONG CounterId; ULONG InstanceId; ULONG Index; ULONG
	// Reserved; } PERF_COUNTER_IDENTIFIER, *PPERF_COUNTER_IDENTIFIER;
	[PInvokeData("perflib.h", MSDNShortId = "4BBAB831-9A7F-407E-A7D6-9123192C12B4")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PERF_COUNTER_IDENTIFIER(Guid counterSetGuid, uint counterId = PERF_WILDCARD_COUNTER, uint instanceId = PERF_WILDCARD_COUNTER)
	{
		/// <summary>The <c>GUID</c> of the performance counter set.</summary>
		public Guid CounterSetGuid = counterSetGuid;

		/// <summary>An error code that indicates whether the operation to add or delete a performance counter succeeded or failed.</summary>
		public Win32Error Status;

		/// <summary>
		/// The total size of the <c>PERF_COUNTER_IDENTIFIER</c> block, in bytes. The total size of the block is the sum of the sizes of
		/// the <c>PERF_COUNTER_IDENTIFIER</c> structure, the string that specifies the instance name, and the padding.
		/// </summary>
		public uint Size;

		/// <summary>The identifier of the performance counter. <c>PERF_WILDCARD_COUNTER</c> specifies all counters.</summary>
		public uint CounterId = counterId;

		/// <summary>The instance identifier. Specify 0xFFFFFFFF if you do not want to filter the results based on the instance identifier.</summary>
		public uint InstanceId = instanceId;

		/// <summary>
		/// The position in the sequence of <c>PERF_COUNTER_IDENTIFIER</c> blocks at which the counter data that corresponds to this
		/// <c>PERF_COUNTER_IDENTIFIER</c> block is returned. Set by PerfQueryCounterInfo.
		/// </summary>
		public uint Index;

		/// <summary>Reserved.</summary>
		public uint Reserved;
	}

	/// <summary>Defines the counter that is sent to a provider's callback when the consumer adds or removes a counter from the query.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/ns-perflib-_perf_counter_identity typedef struct
	// _PERF_COUNTER_IDENTITY { GUID CounterSetGuid; ULONG BufferSize; ULONG CounterId; ULONG InstanceId; ULONG MachineOffset; ULONG
	// NameOffset; ULONG Reserved; } PERF_COUNTER_IDENTITY, *PPERF_COUNTER_IDENTITY;
	[PInvokeData("perflib.h", MSDNShortId = "a18d2546-642b-4e83-be05-4b4aae1f2d2c")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PERF_COUNTER_IDENTITY
	{
		/// <summary>GUID that uniquely identifies the counter set that this counter belongs to.</summary>
		public Guid CounterSetGuid;

		/// <summary>
		/// Size, in bytes, of this structure and the computer name and instance name that are appended to this structure in memory.
		/// </summary>
		public uint BufferSize;

		/// <summary>
		/// <para>Unique identifier of the counter in the counter set.</para>
		/// <para>
		/// This member is set to <c>PERF_WILDCARD_COUNTER</c> if the consumer wants to add or remove all counters in the counter set.
		/// </para>
		/// </summary>
		public uint CounterId;

		/// <summary>
		/// <para>Identifier of the counter set instance to which the counter belongs.</para>
		/// <para>Ignore this value if the instance name at <c>NameOffset</c> is PERF_WILDCARD_INSTANCE.</para>
		/// </summary>
		public uint InstanceId;

		/// <summary>Offset to the null-terminated Unicode computer name that follows this structure in memory.</summary>
		public uint MachineOffset;

		/// <summary>Offset to the null-terminated Unicode instance name that follows this structure in memory.</summary>
		public uint NameOffset;

		/// <summary>Reserved.</summary>
		public uint Reserved;
	}

	/// <summary>
	/// Defines information about a counter that a provider uses. The CTRPP tool automatically generates this structure based on the
	/// schema you specify.
	/// </summary>
	/// <remarks>This structure is contained within a PERF_COUNTERSET_INFO or PERF_COUNTERSET_INSTANCE block.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/ns-perflib-_perf_counter_info typedef struct _PERF_COUNTER_INFO {
	// ULONG CounterId; ULONG Type; ULONGLONG Attrib; ULONG Size; ULONG DetailLevel; LONG Scale; ULONG Offset; } PERF_COUNTER_INFO, *PPERF_COUNTER_INFO;
	[PInvokeData("perflib.h", MSDNShortId = "f1fb6ad5-ad38-46d0-b76d-803887ba3d97")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PERF_COUNTER_INFO(uint id, uint type, uint size, uint detailLevel)
	{
		/// <summary>Identifier that uniquely identifies the counter within the counter set.</summary>
		public uint CounterId = id;

		/// <summary>
		/// Specifies the type of counter. For possible counter types, see Counter Types in the Windows 2003 Deployment Guide.
		/// </summary>
		public uint Type = type;

		/// <summary>
		/// <para>One or more attributes that indicate how to display this counter.</para>
		/// <para>The possible values are:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PERF_ATTRIB_BY_REFERENCE</term>
		/// <term>Retrieve the value of the counter by reference as opposed to by value.</term>
		/// </item>
		/// <item>
		/// <term>PERF_ATTRIB_NO_DISPLAYABLE</term>
		/// <term>Do not display the counter value.</term>
		/// </item>
		/// <item>
		/// <term>PERF_ATTRIB_NO_GROUP_SEPARATOR</term>
		/// <term>Do not use digit separators when displaying counter value.</term>
		/// </item>
		/// <item>
		/// <term>PERF_ATTRIB_DISPLAY_AS_REAL</term>
		/// <term>Display the counter value as a real value.</term>
		/// </item>
		/// <item>
		/// <term>PERF_ATTRIB_DISPLAY_AS_HEX</term>
		/// <term>Display the counter value as a hexadecimal number.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The attributes PERF_ATTRIB_NO_GROUP_SEPARATOR, PERF_ATTRIB_DISPLAY_AS_REAL, and PERF_ATTRIB_DISPLAY_AS_HEX are not mutually
		/// exclusive. If you specify all three attributes, precedence is given to the attributes in the order given.
		/// </para>
		/// </summary>
		public PERF_ATTRIB Attrib;

		/// <summary>Size, in bytes, of this structure.</summary>
		public uint Size = size;

		/// <summary>
		/// <para>Specify the target audience for the counter.</para>
		/// <para>Possible values are:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PERF_DETAIL_NOVICE</term>
		/// <term>You can display the counter to any level of user.</term>
		/// </item>
		/// <item>
		/// <term>PERF_DETAIL_ADVANCED</term>
		/// <term>The counter is complicated and should be displayed only to advanced users.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint DetailLevel = detailLevel;

		/// <summary>
		/// Scale factor to apply to the counter value. Valid values range from –10 through 10. Zero if no scale is applied. If this
		/// value is zero, the scale value is 1; if this value is 1, the scale value is 10; if this value is –1, the scale value is .10;
		/// and so on.
		/// </summary>
		public int Scale;

		/// <summary>Byte offset from the beginning of the PERF_COUNTERSET_INSTANCE block to the counter value.</summary>
		public uint Offset;
	}

	/// <summary>Provides registration information about a performance counter.</summary>
	/// <remarks>
	/// <para>
	/// The PerfQueryCounterSetRegistrationInfo function called with the requestCodeparameter set to <c>PERF_REG_COUNTERSET_STRUCT</c>
	/// gets a PERF_COUNTERSET_REG_INFO block that contains one or more <c>PERF_COUNTER_REG_INFO</c> structures.
	/// </para>
	/// <para>
	/// The PerfQueryCounterSetRegistrationInfo function called with the requestCodeparameter set to <c>PERF_REG_COUNTER_STRUCT</c> gets
	/// a <c>PERF_COUNTER_REG_INFO</c> structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/ns-perflib-_perf_counter_reg_info typedef struct
	// _PERF_COUNTER_REG_INFO { ULONG CounterId; ULONG Type; ULONGLONG Attrib; ULONG DetailLevel; LONG DefaultScale; ULONG BaseCounterId;
	// ULONG PerfTimeId; ULONG PerfFreqId; ULONG MultiId; ULONG AggregateFunc; ULONG Reserved; } PERF_COUNTER_REG_INFO, *PPERF_COUNTER_REG_INFO;
	[PInvokeData("perflib.h", MSDNShortId = "34CA6EA3-DF74-4DB5-8DD0-2B0BB0162F9D")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PERF_COUNTER_REG_INFO
	{
		/// <summary>
		/// A unique identifier for the performance counter within the counter set. A counter set can contain a maximum of 64,000
		/// performance counters.
		/// </summary>
		public uint CounterId;

		/// <summary>
		/// <para>
		/// The type of the performance counter. For information about the predefined counter types, see the Counter Types section of the
		/// Windows Server 2003 Deployment Kit. Consumers use the counter type to determine how to calculate and display the counter
		/// value. Providers should limit their choice of counter types to the predefined list.
		/// </para>
		/// <para>The possible values are:</para>
		/// <para>PERF_100NSEC_MULTI_TIMER</para>
		/// <para>PERF_100NSEC_MULTI_TIMER_II</para>
		/// <para>PERF_100NSEC_TIMER</para>
		/// <para>PERF_100NSEC_TIMER_INV</para>
		/// <para>PERF_AVERAGE_BASE</para>
		/// <para>PERF_AVERAGE_BULK</para>
		/// <para>PERF_AVERAGE_TIMER</para>
		/// <para>PERF_COUNTER_100NS_QUEUELEN_TYPE</para>
		/// <para>PERF_COUNTER_BULK_COUNT</para>
		/// <para>PERF_COUNTER_COUNTER</para>
		/// <para>PERF_COUNTER_DELTA</para>
		/// <para>PERF_COUNTER_LARGE_DELTA</para>
		/// <para>PERF_COUNTER_LARGE_QUEUELEN_TYPE</para>
		/// <para>PERF_COUNTER_LARGE_RAWCOUNT</para>
		/// <para>PERF_COUNTER_LARGE_RAWCOUNT_HEX</para>
		/// <para>PERF_COUNTER_MULTI_TIMER</para>
		/// <para>PERF_COUNTER_MULTI_TIMER_INV</para>
		/// <para>PERF_COUNTER_OBJ_QUEUELEN_TYPE</para>
		/// <para>PERF_COUNTER_RAWCOUNT</para>
		/// <para>PERF_COUNTER_RAWCOUNT_HEX</para>
		/// <para>PERF_COUNTER_TEXT</para>
		/// <para>PERF_COUNTER_TIMER</para>
		/// <para>PERF_COUNTER_TIMER_INV</para>
		/// <para>PERF_ELAPSED_TIME</para>
		/// <para>PERF_LARGE_RAW_BASE</para>
		/// <para>PERF_OBJ_TIME_TIMER</para>
		/// <para>PERF_PRECISION_100NS_TIMER</para>
		/// <para>PERF_PRECISION_TIMER</para>
		/// <para>PERF_PRECISION_OBJECT_TIMER</para>
		/// <para>PERF_RAW_BASE</para>
		/// <para>PERF_RAW_FRACTION</para>
		/// <para>PERF_SAMPLE_COUNTER</para>
		/// <para>PERF_SAMPLE_FRACTION</para>
		/// </summary>
		public uint Type;

		/// <summary>
		/// <para>One or more attributes that indicate how to display this counter.</para>
		/// <para>The possible values are:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PERF_ATTRIB_BY_REFERENCE</term>
		/// <term>Retrieve the value of the counter by reference as opposed to by value.</term>
		/// </item>
		/// <item>
		/// <term>PERF_ATTRIB_NO_DISPLAYABLE</term>
		/// <term>Do not display the counter value.</term>
		/// </item>
		/// <item>
		/// <term>PERF_ATTRIB_NO_GROUP_SEPARATOR</term>
		/// <term>Do not use digit separators when displaying counter value.</term>
		/// </item>
		/// <item>
		/// <term>PERF_ATTRIB_DISPLAY_AS_REAL</term>
		/// <term>Display the counter value as a real value.</term>
		/// </item>
		/// <item>
		/// <term>PERF_ATTRIB_DISPLAY_AS_HEX</term>
		/// <term>Display the counter value as a hexadecimal number.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The attributes <c>PERF_ATTRIB_NO_GROUP_SEPARATOR</c>, <c>PERF_ATTRIB_DISPLAY_AS_REAL</c>, and
		/// <c>PERF_ATTRIB_DISPLAY_AS_HEX</c> are not mutually exclusive. If you specify all three attributes, precedence is given to the
		/// attributes in the order given.
		/// </para>
		/// </summary>
		public PERF_ATTRIB Attrib;

		/// <summary>
		/// <para>The target audience for the counter.</para>
		/// <para>The possible values are:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PERF_DETAIL_NOVICE</term>
		/// <term>You can display the counter to any level of user.</term>
		/// </item>
		/// <item>
		/// <term>PERF_DETAIL_ADVANCED</term>
		/// <term>The counter is complicated and should be displayed only to advanced users.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint DetailLevel;

		/// <summary>
		/// The scaling factor to apply to the raw performance counter value. Valid values range from –10 through 10. Zero if no scale is
		/// applied. If this value is zero, the scale value is 1; if this value is 1, the scale value is 10; if this value is –1, the
		/// scale value is .10; and so on. The scaled value of the performance counter is equal to the raw value of the performance
		/// counter multiplied by 10 raised to the power that the <c>DefaultScale</c> member specifies.
		/// </summary>
		public int DefaultScale;

		/// <summary>The counter identifier of the base counter. 0xFFFFFFFF indicates that there is no base counter.</summary>
		public uint BaseCounterId;

		/// <summary>The counter identifier of the performance counter. 0xFFFFFFFF indicates that there is no performance counter.</summary>
		public uint PerfTimeId;

		/// <summary>The counter identifier of the frequency counter. 0xFFFFFFFF indicates that there is no frequency counter.</summary>
		public uint PerfFreqId;

		/// <summary>The counter identifier of the multi-counter. 0xFFFFFFFF indicates that there is no multi-counter.</summary>
		public uint MultiId;

		/// <summary>
		/// <para>The aggregation function the client should apply to the counter if the</para>
		/// <para>counter set to which the counter belongs is of type Global Aggregate, Multiple</para>
		/// <para>
		/// Instance Aggregate, or Global Aggregate History. The client specifies the counter instances across which the aggregation is
		/// performed if the counter set type
		/// </para>
		/// <para>is Multiple Instance Aggregate; otherwise, the client must aggregate values</para>
		/// <para>across all instances of the counter set. One of the following values must be</para>
		/// <para>specified.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PERF_AGGREGATE_UNDEFINED</term>
		/// <term>Undefined.</term>
		/// </item>
		/// <item>
		/// <term>PERF_AGGREGATE_TOTAL</term>
		/// <term>The sum of the values of the returned counter instances.</term>
		/// </item>
		/// <item>
		/// <term>PERF_AGGREGATE_AVG</term>
		/// <term>The average of the values of the returned counter instances.</term>
		/// </item>
		/// <item>
		/// <term>PERF_AGGREGATE_MIN</term>
		/// <term>The minimum value of the returned counter instance values.</term>
		/// </item>
		/// <item>
		/// <term>PERF_AGGREGATE_MAX</term>
		/// <term>The maximum value of the returned counter instance values.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PERF_AGGREGATE AggregateFunc;

		/// <summary>Reserved.</summary>
		public uint Reserved;
	}

	/// <summary>
	/// Defines information about a counter set that a provider uses. The CTRPP tool automatically generates this structure based on the
	/// schema you specify.
	/// </summary>
	/// <remarks>
	/// The memory block for this structure also contains one or more PERF_COUNTER_INFO structures. The <c>NumCounter</c> member
	/// determines the number of <c>PERF_COUNTER_INFO</c> structures that follow this structure in memory.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/ns-perflib-_perf_counterset_info typedef struct _PERF_COUNTERSET_INFO
	// { GUID CounterSetGuid; GUID ProviderGuid; ULONG NumCounters; ULONG InstanceType; } PERF_COUNTERSET_INFO, *PPERF_COUNTERSET_INFO;
	[PInvokeData("perflib.h", MSDNShortId = "bf48dcdb-6fdd-4093-9006-a53690c3ed86")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PERF_COUNTERSET_INFO(in Guid counterSetGuid, in Guid providerGuid, uint numCounters, PERF_COUNTERSET_TYPE instType = PERF_COUNTERSET_TYPE.PERF_COUNTERSET_MULTI_INSTANCES)
	{
		/// <summary>
		/// GUID that uniquely identifies the counter set. The <c>guid</c> attribute of the counterSet element contains the GUID.
		/// </summary>
		public Guid CounterSetGuid = counterSetGuid;

		/// <summary>
		/// GUID that uniquely identifies the provider that supports the counter set. The <c>providerGuid</c> attribute of the provider
		/// element contains the GUID.
		/// </summary>
		public Guid ProviderGuid = providerGuid;

		/// <summary>Number of counters in the counter set. See Remarks.</summary>
		public uint NumCounters = numCounters;

		/// <summary>
		/// <para>
		/// Specifies whether the counter set allows multiple instances such as processes and physical disks, or a single instance such
		/// as memory.
		/// </para>
		/// <para>The following are the possible instance types.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PERF_COUNTERSET_SINGLE_INSTANCE</term>
		/// <term>The counter set contains single instance counters, for example, a counter that measures physical memory.</term>
		/// </item>
		/// <item>
		/// <term>PERF_COUNTERSET_MULTI_INSTANCES</term>
		/// <term>
		/// The counter set contains multiple instance counters, for example, a counter that measures the average disk I/O for a process.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PERF_COUNTERSET_SINGLE_AGGREGATE</term>
		/// <term>
		/// The counter set contains single instance counters whose aggregate value is obtained from one or more sources. For example, a
		/// counter in this type of counter set might obtain the number of reads from each of the three hard disks on the computer and
		/// sum their values.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PERF_COUNTERSET_MULTI_AGGREGATE</term>
		/// <term>
		/// The counter set contains multiple instance counters whose aggregate value is obtained from all instances of the counter. For
		/// example, a counter in this type of counter set might obtain the total thread execution time for all threads in a
		/// multi-threaded application and sum their values.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PERF_COUNTERSET_SINGLE_AGGREGATE_HISTORY</term>
		/// <term>
		/// The difference between this type and PERF_COUNTERSET_SINGLE_AGGREGATE is that this counter set type stores all counter values
		/// for the lifetime of the consumer application (the counter value is cached beyond the lifetime of the counter). For example,
		/// if one of the hard disks in the single aggregate example above were to become unavailable, the total bytes read by that disk
		/// would still be available and used to calculate the aggregate value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PERF_COUNTERSET_INSTANCE_AGGREGATE</term>
		/// <term>
		/// This type is similar to PERF_COUNTERSET_MULTI_AGGREGATE, except that instead of aggregating all instance data to one
		/// aggregated (_Total) instance, it will aggregate counter data from instances of the same name. For example, if multiple
		/// provider processes contained instances named IExplore, PERF_COUNTERSET_MULTIPLE and PERF_COUNTERSET_MULTI_AGGREGATE
		/// CounterSet will show multiple IExplore instances (IExplore, IExplore#1, IExplore#2, and so on); however, a
		/// PERF_COUNTERSET_INSTANCE_AGGREGATE instance type will only publish one IExplore instance with aggregated counter data from
		/// all instances named IExplore. Windows Vista: This type is not available.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public PERF_COUNTERSET_TYPE InstanceType = instType;
	}

	/// <summary>Defines an instance of a counter set.</summary>
	/// <remarks>
	/// The <c>Offset</c> member of PERF_COUNTER_INFO contains the byte offset from the beginning of the <c>PERF_COUNTERSET_INSTANCE</c>
	/// block to the counter's raw counter value.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/ns-perflib-_perf_counterset_instance typedef struct
	// _PERF_COUNTERSET_INSTANCE { GUID CounterSetGuid; ULONG dwSize; ULONG InstanceId; ULONG InstanceNameOffset; ULONG InstanceNameSize;
	// } PERF_COUNTERSET_INSTANCE, *PPERF_COUNTERSET_INSTANCE;
	[PInvokeData("perflib.h", MSDNShortId = "709d5339-cedd-4b03-9d8e-c125eb3bcac0")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PERF_COUNTERSET_INSTANCE
	{
		/// <summary>GUID that identifies the counter set to which this instance belongs.</summary>
		public Guid CounterSetGuid;

		/// <summary>
		/// Size, in bytes, of the instance block. The instance block contains this structure, followed by one or more PERF_COUNTER_INFO
		/// blocks, and ends with the instance name.
		/// </summary>
		public uint dwSize;

		/// <summary>
		/// <para>Identifier that uniquely identifies this instance.</para>
		/// <para>The provider specified the identifier when calling PerfCreateInstance.</para>
		/// </summary>
		public uint InstanceId;

		/// <summary>
		/// <para>Byte offset from the beginning of this structure to the null-terminated Unicode instance name.</para>
		/// <para>The provider specified the instance name when calling PerfCreateInstance.</para>
		/// </summary>
		public uint InstanceNameOffset;

		/// <summary>Size, in bytes, of the instance name. The size includes the null-terminator.</summary>
		public uint InstanceNameSize;
	}

	/// <summary>
	/// Contains information about the <c>PERF_COUNTERSET_REG_INFO</c> block that contains the structure. A
	/// <c>PERF_COUNTERSET_REG_INFO</c> block provides registration information for a counter set and the performance counters it
	/// contains, and consists of a <c>PERF_COUNTERSET_REG_INFO</c> structure immediately followed by a set PERF_COUNTER_REG_INFO
	/// structures that correspond to the performance counters in the counter set.
	/// </summary>
	/// <remarks>
	/// The PerfQueryCounterSetRegistrationInfo function called with the requestCode parameter set to <c>PERF_REG_COUNTERSET_STRUCT</c>
	/// gets a <c>PERF_COUNTERSET_REG_INFO</c> block.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/ns-perflib-_perf_counterset_reg_info typedef struct
	// _PERF_COUNTERSET_REG_INFO { GUID CounterSetGuid; ULONG CounterSetType; ULONG DetailLevel; ULONG NumCounters; ULONG InstanceType; }
	// PERF_COUNTERSET_REG_INFO, *PPERF_COUNTERSET_REG_INFO;
	[PInvokeData("perflib.h", MSDNShortId = "D220426F-7849-47DF-A411-5381FC39CA80")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PERF_COUNTERSET_REG_INFO
	{
		/// <summary>The unique identifier for the counter set.</summary>
		public Guid CounterSetGuid;

		/// <summary>Reserved.</summary>
		public uint CounterSetType;

		/// <summary>
		/// <para>The target audience for the counters in the counter set.</para>
		/// <para>The possible values are:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PERF_DETAIL_NOVICE</term>
		/// <term>You can display the counter to any level of user.</term>
		/// </item>
		/// <item>
		/// <term>PERF_DETAIL_ADVANCED</term>
		/// <term>The counter is complicated and should be displayed only to advanced users.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint DetailLevel;

		/// <summary>The number of PERF_COUNTER_REG_INFO structures in this <c>PERF_COUNTERSET_REG_INFO</c> block.</summary>
		public uint NumCounters;

		/// <summary>
		/// <para>
		/// Specifies whether the counter set allows multiple instances such as processes and physical disks, or a single instance such
		/// as memory.
		/// </para>
		/// <para>The following are the possible instance types.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PERF_COUNTERSET_SINGLE_INSTANCE</term>
		/// <term>The counter set contains single instance counters, for example, a counter that measures physical memory.</term>
		/// </item>
		/// <item>
		/// <term>PERF_COUNTERSET_MULTI_INSTANCES</term>
		/// <term>
		/// The counter set contains multiple instance counters, for example, a counter that measures the average disk I/O for a process.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PERF_COUNTERSET_SINGLE_AGGREGATE</term>
		/// <term>
		/// The counter set contains single instance counters whose aggregate value is obtained from one or more sources. For example, a
		/// counter in this type of counter set might obtain the number of reads from each of the three hard disks on the computer and
		/// sum their values.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PERF_COUNTERSET_MULTI_AGGREGATE</term>
		/// <term>
		/// The counter set contains multiple instance counters whose aggregate value is obtained from all instances of the counter. For
		/// example, a counter in this type of counter set might obtain the total thread execution time for all threads in a
		/// multi-threaded application and sum their values.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PERF_COUNTERSET_SINGLE_AGGREGATE_HISTORY</term>
		/// <term>
		/// The difference between this type and PERF_COUNTERSET_SINGLE_AGGREGATE is that this counter set type stores all counter values
		/// for the lifetime of the consumer application (the counter value is cached beyond the lifetime of the counter). For example,
		/// if one of the hard disks in the single aggregate example above were to become unavailable, the total bytes read by that disk
		/// would still be available and used to calculate the aggregate value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PERF_COUNTERSET_INSTANCE_AGGREGATE</term>
		/// <term>Not implemented.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PERF_COUNTERSET_TYPE InstanceType;
	}

	/// <summary>
	/// Provides information about the <c>PERF_DATA_HEADER</c> block that contains the structure. A <c>PERF_DATA_HEADER</c> block
	/// corresponds to one query specification in a query, and consists of a <c>PERF_DATA_HEADER</c> structure followed by a sequence of
	/// PERF_COUNTER_HEADER blocks.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The ordering of the PERF_COUNTER_HEADER blocks is based on the <c>Index</c> member of the PERF_COUNTER_IDENTIFIER blocks that the
	/// PerfQueryCounterInfo function gets. Each <c>PERF_COUNTER_HEADER</c> block is 8-byte aligned, so the value of the
	/// <c>dwTotalSize</c> is a multiple of 8 bytes.
	/// </para>
	/// <para>
	/// The timestamp information in the <c>PERF_DATA_HEADER</c> structure is required when you compute the display values of certain
	/// performance counters.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/ns-perflib-_perf_data_header typedef struct _PERF_DATA_HEADER { ULONG
	// dwTotalSize; ULONG dwNumCounters; LONGLONG PerfTimeStamp; LONGLONG PerfTime100NSec; LONGLONG PerfFreq; SYSTEMTIME SystemTime; }
	// PERF_DATA_HEADER, *PPERF_DATA_HEADER;
	[PInvokeData("perflib.h", MSDNShortId = "0B30B30A-2B2D-43D8-B6DD-58C70D54EB58")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PERF_DATA_HEADER
	{
		/// <summary>
		/// The sum of the size of the <c>PERF_DATA_HEADER</c> structure and the sizes of all of the PERF_COUNTER_HEADER blocks in the
		/// <c>PERF_DATA_HEADER</c> block.
		/// </summary>
		public uint dwTotalSize;

		/// <summary>The number of PERF_COUNTER_HEADER blocks that the <c>PERF_DATA_HEADER</c> block contains.</summary>
		public uint dwNumCounters;

		/// <summary>The timestamp from a high-resolution clock.</summary>
		public long PerfTimeStamp;

		/// <summary>The number of 100 nanosecond intervals since January 1, 1601, in Coordinated Universal Time (UTC).</summary>
		public long PerfTime100NSec;

		/// <summary>The frequency of a high-resolution clock.</summary>
		public long PerfFreq;

		/// <summary>The time at which data is collected by the provider.</summary>
		public SYSTEMTIME SystemTime;

		/// <summary>Enumerates the counters in the data header.</summary>
		public static IEnumerable<(PERF_COUNTER_HEADER value, StructPointer<PERF_COUNTER_HEADER> ptr)> GetCounters(StructPointer<PERF_DATA_HEADER> ptr)
		{
			var cn = ptr.AsRef().dwNumCounters;
			var offset = Marshal.SizeOf<PERF_DATA_HEADER>();
			for (var i = 0; i < cn; i++)
			{
				StructPointer<PERF_COUNTER_HEADER> p = ((IntPtr)ptr).Offset(offset);
				var val = p.Value.GetValueOrDefault();
				yield return (val, p);
				offset += (int)val.dwSize;
			}
		}

		/// <summary>Enumerates the errors in the data header.</summary>
		public static IEnumerable<Win32Error> GetErrors(StructPointer<PERF_DATA_HEADER> ptr) =>
			GetCounters(ptr).Where(t => t.value.dwType == PerfCounterDataType.PERF_ERROR_RETURN).Select(t => t.value.dwStatus);
	}

	/// <summary>
	/// <para>
	/// Provides information about the <c>PERF_INSTANCE_HEADER</c> block that contains the structure. A <c>PERF_INSTANCE_HEADER</c> block
	/// provides information about the instances in a counter set, or the instances for which performance counter results are provided in
	/// a multiple-instance query. The <c>PERF_INSTANCE_HEADER</c> block consists of the following items in order:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// A <c>PERF_INSTANCE_HEADER</c> structure that contains the size of the <c>PERF_INSTANCE_HEADER</c> block and the instance identifier
	/// </term>
	/// </item>
	/// <item>
	/// <term>A null-terminated UTF-16LE string that contains the instance name.</term>
	/// </item>
	/// <item>
	/// <term>Padding such that the total size of the <c>PERF_INSTANCE_HEADER</c> block is a multiple of 8 bytes.</term>
	/// </item>
	/// </list>
	/// </summary>
	/// <remarks>
	/// <para>Each active instance of a counter set is identified by the combination of</para>
	/// <para>its instance name and instance identifier. Two active instances of a</para>
	/// <para>counter set should not have the same combination of instance name and instance</para>
	/// <para>identifier. Clients, however, should tolerate instances with duplicate combinations of instance name and instance</para>
	/// <para>identifier.</para>
	/// <para>The PerfEnumerateCounterSetInstances function gets a sequence of</para>
	/// <para><c>PERF_INSTANCE_HEADER</c> blocks.</para>
	/// <para>The PerfQueryCounterData function gets a PERF_DATA_HEADER block that may</para>
	/// <para>contain <c>PERF_INSTANCE_HEADER</c> blocks within the PERF_MULTI_INSTANCES block.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/ns-perflib-perf_instance_header typedef struct _PERF_INSTANCE_HEADER
	// { ULONG Size; ULONG InstanceId; } PERF_INSTANCE_HEADER, *PPERF_INSTANCE_HEADER;
	[PInvokeData("perflib.h", MSDNShortId = "58E4062A-0CE4-4FF7-A9B2-CA0947563C7B")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PERF_INSTANCE_HEADER
	{
		/// <summary>
		/// The total size of the <c>PERF_INSTANCE_HEADER</c> block, in bytes. This total size is the sum of the sizes of the
		/// <c>PERF_INSTANCE_HEADER</c> structures, the string that contains the instance name, and the padding.
		/// </summary>
		public uint Size;

		/// <summary>The instance identifier.</summary>
		public uint InstanceId;

		/// <summary>Retrieves the Unicode instance name from the specified performance instance header pointer.</summary>
		/// <remarks>
		/// The returned string is interpreted as Unicode and is extracted from the memory immediately following the PERF_INSTANCE_HEADER
		/// structure. The caller is responsible for ensuring that the pointer is valid and points to a properly initialized structure.
		/// </remarks>
		/// <param name="ptr">A pointer to a PERF_INSTANCE_HEADER structure from which to extract the instance name.</param>
		/// <returns>A string containing the instance name, or null if the name cannot be read.</returns>
		public static string? GetInstanceName(StructPointer<PERF_INSTANCE_HEADER> ptr)
		{
			ref var ih = ref ptr.AsRef();
			return StringHelper.GetString(((IntPtr)ptr).Offset(Marshal.SizeOf<PERF_INSTANCE_HEADER>()), CharSet.Unicode, (int)(ih.Size - Marshal.SizeOf<PERF_INSTANCE_HEADER>()));
		}

		/// <summary>
		/// Retrieves the raw counter data associated with a performance instance header that is part of a multiple-instance query.
		/// </summary>
		/// <param name="ptr">
		/// A pointer to a PERF_INSTANCE_HEADER structure representing the performance instance for which to retrieve counter data.
		/// </param>
		/// <returns>
		/// A span of bytes containing the counter data for the specified performance instance. The span will be empty if no data is available.
		/// </returns>
		public static ulong GetMultiInstData(StructPointer<PERF_INSTANCE_HEADER> ptr) =>
			PERF_COUNTER_DATA.GetData(((IntPtr)ptr).Offset(ptr.AsRef().Size));

		/// <summary>Enumerates the collection of performance counter data structures for a given set of performance instances.</summary>
		/// <remarks>
		/// The returned enumerable yields pointers in the order they appear in memory, starting immediately after the specified instance
		/// header. The caller is responsible for ensuring that the memory region referenced by ptr and count remains valid for the duration
		/// of the enumeration.
		/// </remarks>
		/// <param name="ptr">A pointer to the first performance instance header from which to begin enumeration.</param>
		/// <param name="count">The number of performance counter data structures to enumerate. Must be non-negative.</param>
		/// <returns>An enumerable collection of pointers to PERF_COUNTER_DATA structures, one for each performance instance.</returns>
		public static IEnumerable<StructPointer<PERF_COUNTER_DATA>> GetCountersetData(StructPointer<PERF_INSTANCE_HEADER> ptr, SizeT count)
		{
			StructPointer<PERF_COUNTER_DATA> pCounterData = ((IntPtr)ptr).Offset(ptr.AsRef().Size);
			for (int i = 0; i < count; i++)
			{
				yield return pCounterData;
				pCounterData = ((IntPtr)pCounterData).Offset(pCounterData.AsRef().dwSize);
			}
		}
	}

	/// <summary>
	/// Provides information about the <c>PERF_MULTI_COUNTERS</c> block that contains the structure. A <c>PERF_MULTI_COUNTERS</c> block
	/// indicates the performance counters for which results are provided as part of the PERF_COUNTER_HEADER block in multiple-counter
	/// query. The <c>PERF_MULTI_COUNTERS</c> block consists of a <c>PERF_MULTI_COUNTERS</c> structure followed by a sequence of
	/// <c>DWORD</c> values that specify performance counter identifiers.
	/// </summary>
	/// <remarks>
	/// The PerfQueryCounterData function gets a PERF_DATA_HEADER block that may contain a <c>PERF_MULTI_COUNTERS</c> block within the
	/// PERF_COUNTER_HEADER block.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/ns-perflib-_perf_multi_counters typedef struct _PERF_MULTI_COUNTERS {
	// ULONG dwSize; ULONG dwCounters; } PERF_MULTI_COUNTERS, *PPERF_MULTI_COUNTERS;
	[PInvokeData("perflib.h", MSDNShortId = "4F490C3C-F587-4E7B-B316-162EDA76EC30")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PERF_MULTI_COUNTERS
	{
		/// <summary>
		/// The total size of the <c>PERF_MULTI_COUNTERS</c> block, in bytes. This total size is the sum of the sizes of the
		/// <c>PERF_MULTI_COUNTERS</c> structure and all of the performance counter identifiers.
		/// </summary>
		public uint dwSize;

		/// <summary>The number of performance counter identifiers that the <c>PERF_MULTI_COUNTERS</c> block contains.</summary>
		public uint dwCounters;

		/// <summary>Retrieves the collection of counter values from the specified PERF_MULTI_COUNTERS structure pointer.</summary>
		/// <remarks>
		/// The returned collection reflects the counter values stored immediately after the PERF_MULTI_COUNTERS structure in memory. The
		/// caller is responsible for ensuring that the pointer references a valid and properly initialized structure.
		/// </remarks>
		/// <param name="ptr">A pointer to a PERF_MULTI_COUNTERS structure from which to read the counter values.</param>
		/// <returns>An enumerable collection of unsigned integer counter values. Returns an empty collection if no counters are present.</returns>
		public static IEnumerable<(uint id, ulong data)> GetDataBlocks(StructPointer<PERF_MULTI_COUNTERS> ptr)
		{
			var ids = GetDataIds(ptr).ToArray();
			var cnt = ids.Length;
			int offset = (int)ptr.AsRef().dwSize;
			for (var i = 0; i < cnt; i++)
			{
				StructPointer<PERF_COUNTER_DATA> d = ((IntPtr)ptr).Offset(offset);
				var dval = d.Value.GetValueOrDefault();
				yield return (ids[i], dval.dwDataSize switch
				{
					4 => ((IntPtr)d).Offset(Marshal.SizeOf<PERF_COUNTER_DATA>()).ToStructure<uint>(),
					8 => ((IntPtr)d).Offset(Marshal.SizeOf<PERF_COUNTER_DATA>()).ToStructure<ulong>(),
					_ => 0
				});
				offset += (int)dval.dwSize;
			}
		}

		/// <summary>Retrieves the collection of counter IDs from the specified PERF_MULTI_COUNTERS structure pointer.</summary>
		public static Span<uint> GetDataIds(StructPointer<PERF_MULTI_COUNTERS> ptr)
		{
			var cnt = ptr.AsRef().dwCounters;
			int offset = Marshal.SizeOf<PERF_MULTI_COUNTERS>();
			return ((IntPtr)ptr).Offset(offset).AsSpan<uint>(cnt);
		}

		/// <summary>Retrieves a pointer to the PERF_MULTI_INSTANCES structure that follows the specified PERF_MULTI_COUNTERS structure pointer.</summary>
		public static StructPointer<PERF_MULTI_INSTANCES> GetMultiInstances(StructPointer<PERF_MULTI_COUNTERS> pcs) =>
			((IntPtr)pcs).Offset(pcs.AsRef().dwSize);
	}

	/// <summary>
	/// <para>
	/// Provides information about the <c>PERF_MULTI_INSTANCES</c> block that contains the structure. A <c>PERF_MULTI_INSTANCES</c> block
	/// indicates the number of instances for which results are provided as part of the <c>PERF_COUNTER_HEADER</c> block in multiple-instance
	/// query. The <c>PERF_MULTI_INSTANCES</c> block consists of the following items in order:
	/// </para>
	/// <list type="number">
	/// <item>A <c>PERF_MULTI_INSTANCES</c> structure</item>
	/// <item>
	/// A number of instance data blocks. The number of instance data blocks that the <c>PERF_MULTI_INSTANCES</c> block contains is indicated
	/// by the <c>dwInstances</c> member of the <c>PERF_MULTI_INSTANCES</c> structure. Each instance data block consists of the following
	/// items in order:
	/// </item>
	/// <list type="number">
	/// <item>A PERF_INSTANCE_HEADER block</item>
	/// <item>A number of PERF_COUNTER_DATA blocks. The number of PERF_COUNTER_DATA blocks depends on the context:</item>
	/// <list type="number">
	/// <item>
	/// If the PERF_MULTI_INSTANCES block is part of a PERF_COUNTER_HEADER block with type PERF_MULTIPLE_INSTANCES, the instance data block
	/// contains one PERF_COUNTER_DATA block.
	/// </item>
	/// <item>
	/// If the PERF_MULTI_INSTANCES block is part of a PERF_COUNTER_HEADER block with type PERF_COUNTERSET, the number of PERF_COUNTER_DATA
	/// blocks is indicated by the PERF_MULTI_COUNTERS block.
	/// </item>
	/// </list>
	/// </list>
	/// </list>
	/// </summary>
	/// <remarks>
	/// The <c>PerfQueryCounterData</c> function gets a <c>PERF_DATA_HEADER</c> block that may contain <c>PERF_MULTI_INSTANCES</c> blocks
	/// within the <c>PERF_COUNTER_HEADER</c> block.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/perflib/ns-perflib-perf_multi_instances
	// typedef struct _PERF_MULTI_INSTANCES { ULONG dwTotalSize; ULONG dwInstances; } PERF_MULTI_INSTANCES, *PPERF_MULTI_INSTANCES;
	[PInvokeData("perflib.h", MSDNShortId = "5EC34ECD-D240-4B44-A52B-C5518918400C")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PERF_MULTI_INSTANCES
	{
		/// <summary>
		/// The total size of the <c>PERF_MULTI_INSTANCES</c> block, in bytes. This total size is the sum of the sizes of the
		/// <c>PERF_MULTI_INSTANCES</c> structure and the instance data blocks.
		/// </summary>
		public uint dwTotalSize;

		/// <summary>The number of instance data blocks in the <c>PERF_MULTI_INSTANCES</c> block.</summary>
		public uint dwInstances;


		/// <summary>Enumerates the instances in the data header.</summary>
		public static IEnumerable<StructPointer<PERF_INSTANCE_HEADER>> GetInstances(StructPointer<PERF_MULTI_INSTANCES> pmi) =>
			GetCountersetInstances(pmi, 1);

		/// <summary>Enumerates the instances in the data header.</summary>
		public static IEnumerable<StructPointer<PERF_INSTANCE_HEADER>> GetCountersetInstances(StructPointer<PERF_MULTI_INSTANCES> pmi, SizeT dwCounters)
		{
			StructPointer<PERF_INSTANCE_HEADER> ih = ((IntPtr)pmi).Offset(Marshal.SizeOf<PERF_MULTI_INSTANCES>());
			for (var i = 0; i < pmi.AsRef().dwInstances; i++)
			{
				yield return ih;
				unsafe
				{
					var pih = (PERF_INSTANCE_HEADER*)ih;
					var pcd = (PERF_COUNTER_DATA*)((byte*)pih + pih->Size);
					for (int ic = 0; ic < dwCounters; ic++)
						pcd = (PERF_COUNTER_DATA*)((byte*)pcd + pcd->dwSize);
					ih = (IntPtr)pcd;
				}
			}
		}
	}

	/// <summary>Defines provider context information.</summary>
	/// <remarks>By default, PERFLIB uses process heap. The memory allocation and free routines lets you provide custom memory management.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/ns-perflib-perf_provider_context typedef struct _PROVIDER_CONTEXT {
	// DWORD ContextSize; DWORD Reserved; PERFLIBREQUEST ControlCallback; PERF_MEM_ALLOC MemAllocRoutine; PERF_MEM_FREE MemFreeRoutine;
	// LPVOID pMemContext; } PERF_PROVIDER_CONTEXT, *PPERF_PROVIDER_CONTEXT;
	[PInvokeData("perflib.h", MSDNShortId = "9bfab8aa-f44b-4515-8a2a-764583080f57")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PERF_PROVIDER_CONTEXT(ControlCallback? controlCallback)
	{
		/// <summary>The size of this structure.</summary>
		public uint ContextSize = (uint)Marshal.SizeOf<PERF_PROVIDER_CONTEXT>();

		/// <summary>Reserved.</summary>
		public uint Reserved;

		/// <summary>
		/// The name of the ControlCallback function that PERFLIB calls to notify you of consumer requests, such as a request to add or
		/// remove counters from the query. Set this member if the <c>callback</c> attribute of the provider element is "custom" or you
		/// used the <c>-NotificationCallback</c> argument when calling CTRPP. Otherwise, <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public ControlCallback? ControlCallback = controlCallback;

		/// <summary>
		/// The name of the AllocateMemory function that PERFLIB calls to allocate memory. Set this member if you used the
		/// <c>-MemoryRoutines</c> argument when calling CTRPP. Otherwise, <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public AllocateMemory MemAllocRoutine = (s, _) => Marshal.AllocCoTaskMem(s);

		/// <summary>
		/// The name of the FreeMemory function that PERFLIB calls to free memory allocated by the AllocateMemory function. Must be
		/// <c>NULL</c> if <c>MemAllocRoutine</c> is <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public FreeMemory MemFreeRoutine = (p, _) => Marshal.FreeCoTaskMem(p);

		/// <summary>Context information passed to the memory allocation and free routines. Can be <c>NULL</c>.</summary>
		public IntPtr pMemContext;

		/// <summary>Provides a default instance of this structure with the size preset.</summary>
		public static readonly PERF_PROVIDER_CONTEXT Default = new(null);
	}

	/// <summary>
	/// <para>
	/// Provides information about the <c>PERF_STRING_BUFFER_HEADER</c> block that contains the structure. The
	/// <c>PERF_STRING_BUFFER_HEADER</c> block provides the names or help strings for the performance counters in a counter set, amd
	/// consists of the following items in order:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>A <c>PERF_STRING_BUFFER_HEADER</c> structure</term>
	/// </item>
	/// <item>
	/// <term>
	/// A number of PERF_STRING_COUNTER_HEADERstructures. The <c>dwCounters</c> member of the <c>PERF_STRING_BUFFER_HEADER</c> structure
	/// specifies how many <c>PERF_STRING_COUNTER_HEADER</c> structures the <c>PERF_STRING_BUFFER_HEADER</c> block contains.
	/// </term>
	/// </item>
	/// <item>
	/// <term>A block of string data.</term>
	/// </item>
	/// </list>
	/// </summary>
	/// <remarks>
	/// The PerfQueryCounterSetRegistrationInfo function called with the requestCode parameter set to
	/// <c>PERF_REG_COUNTER_NAME_STRINGS</c> or <c>PERF_REG_COUNTER_HELP_STRINGS</c> gets a <c>PERF_STRING_BUFFER_HEADER</c> block.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/ns-perflib-_string_buffer_header typedef struct _STRING_BUFFER_HEADER
	// { DWORD dwSize; DWORD dwCounters; } PERF_STRING_BUFFER_HEADER, *PPERF_STRING_BUFFER_HEADER;
	[PInvokeData("perflib.h", MSDNShortId = "874A97BA-708E-4001-A7CA-1C3114577D7D")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PERF_STRING_BUFFER_HEADER
	{
		/// <summary>
		/// The total size of the <c>PERF_STRING_BUFFER_HEADER</c> block, in bytes. This total size is the sum of the sizes of the
		/// <c>PERF_STRING_BUFFER_HEADER</c> structure, all of the PERF_STRING_COUNTER_HEADER structures, and the block of string data.
		/// </summary>
		public uint dwSize;

		/// <summary>The number of PERF_STRING_COUNTER_HEADER structures in the <c>PERF_STRING_BUFFER_HEADER</c> block.</summary>
		public uint dwCounters;

		/// <summary>Enumerates counter ID and value pairs from a performance string buffer.</summary>
		/// <remarks>
		/// The returned sequence reflects the counters present in the buffer at the time of enumeration. The caller is responsible for
		/// ensuring that the memory referenced by the pointer remains valid for the duration of the enumeration.
		/// </remarks>
		/// <param name="ptr">
		/// A pointer to a PERF_STRING_BUFFER_HEADER structure representing the start of the performance string buffer to read.
		/// </param>
		/// <returns>
		/// An enumerable collection of tuples, each containing a counter ID and its associated string value. The value is null if the
		/// counter does not have an associated string.
		/// </returns>
		public static IEnumerable<(uint counterId, string? value)> GetData(StructPointer<PERF_STRING_BUFFER_HEADER> ptr)
		{
			var cn = ptr.AsRef().dwCounters;
			var offset = Marshal.SizeOf<PERF_STRING_BUFFER_HEADER>();
			var chsz = Marshal.SizeOf<PERF_STRING_COUNTER_HEADER>();
			for (var i = 0; i < cn; i++)
			{
				var pch = ((IntPtr)ptr).Offset(offset);
				ref PERF_STRING_COUNTER_HEADER h = ref pch.AsRef<PERF_STRING_COUNTER_HEADER>();
				yield return (h.dwCounterId, h.dwOffset == uint.MaxValue ? null : Marshal.PtrToStringUni(pch.Offset(h.dwOffset)));
				offset += chsz;
			}
		}
	}

	/// <summary>
	/// Indicates where in the PERF_STRING_BUFFER_HEADER block that the string that contains the name or help string for the indicated
	/// performance counter starts. The <c>PERF_STRING_COUNTER_HEADER</c> structure is part of the PERF_STRING_BUFFER_HEADER block
	/// </summary>
	/// <remarks>
	/// The PerfQueryCounterSetRegistrationInfo function called with the requestCode parameter set to
	/// <c>PERF_REG_COUNTER_NAME_STRINGS</c> or <c>PERF_REG_COUNTER_HELP_STRINGS</c> gets a PERF_STRING_BUFFER_HEADER block that contains
	/// one or more <c>PERF_STRING_COUNTER_HEADER</c> structures.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/perflib/ns-perflib-_string_counter_header typedef struct
	// _STRING_COUNTER_HEADER { DWORD dwCounterId; DWORD dwOffset; } PERF_STRING_COUNTER_HEADER, *PPERF_STRING_COUNTER_HEADER;
	[PInvokeData("perflib.h", MSDNShortId = "73DFA1C0-B0E8-4788-8CBA-1CFA7580F633")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PERF_STRING_COUNTER_HEADER
	{
		/// <summary>The identifier of the performance counter.</summary>
		public uint dwCounterId;

		/// <summary>
		/// The number of bytes from the start of the PERF_STRING_BUFFER_HEADER block to the null-terminated UTF-16LE data. A value of
		/// 0xFFFFFFFF indicates that the string is not present; in other words, that the value of the string is NULL.
		/// </summary>
		public uint dwOffset;
	}

	/// <summary>Managed version of PERF_COUNTER_INFO with marshalling support.</summary>
	public class PERF_COUNTER_INFO_MGD
	{
		/// <summary>
		/// <para>One or more attributes that indicate how to display this counter.</para>
		/// <para>The possible values are:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PERF_ATTRIB_BY_REFERENCE</term>
		/// <term>Retrieve the value of the counter by reference as opposed to by value.</term>
		/// </item>
		/// <item>
		/// <term>PERF_ATTRIB_NO_DISPLAYABLE</term>
		/// <term>Do not display the counter value.</term>
		/// </item>
		/// <item>
		/// <term>PERF_ATTRIB_NO_GROUP_SEPARATOR</term>
		/// <term>Do not use digit separators when displaying counter value.</term>
		/// </item>
		/// <item>
		/// <term>PERF_ATTRIB_DISPLAY_AS_REAL</term>
		/// <term>Display the counter value as a real value.</term>
		/// </item>
		/// <item>
		/// <term>PERF_ATTRIB_DISPLAY_AS_HEX</term>
		/// <term>Display the counter value as a hexadecimal number.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The attributes PERF_ATTRIB_NO_GROUP_SEPARATOR, PERF_ATTRIB_DISPLAY_AS_REAL, and PERF_ATTRIB_DISPLAY_AS_HEX are not mutually
		/// exclusive. If you specify all three attributes, precedence is given to the attributes in the order given.
		/// </para>
		/// </summary>
		public PERF_ATTRIB Attrib { get; set; }

		/// <summary>Identifier that uniquely identifies the counter within the counter set.</summary>
		public uint CounterId { get; set; }

		/// <summary>The counter's raw counter value.</summary>
		public byte[]? CounterValue { get; set; }

		/// <summary>
		/// <para>Specify the target audience for the counter.</para>
		/// <para>Possible values are:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PERF_DETAIL_NOVICE</term>
		/// <term>You can display the counter to any level of user.</term>
		/// </item>
		/// <item>
		/// <term>PERF_DETAIL_ADVANCED</term>
		/// <term>The counter is complicated and should be displayed only to advanced users.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint DetailLevel { get; set; }

		/// <summary>
		/// Scale factor to apply to the counter value. Valid values range from –10 through 10. Zero if no scale is applied. If this
		/// value is zero, the scale value is 1; if this value is 1, the scale value is 10; if this value is –1, the scale value is .10;
		/// and so on.
		/// </summary>
		public int Scale { get; set; }

		/// <summary>
		/// Specifies the type of counter. For possible counter types, see Counter Types in the Windows 2003 Deployment Guide.
		/// </summary>
		public uint Type { get; set; }
	}


	/// <summary>Managed version of PERF_COUNTERSET_INSTANCE with marshalling support.</summary>
#if NET7_0_OR_GREATER
	[System.Runtime.InteropServices.Marshalling.CustomMarshaller(typeof(PERF_COUNTERSET_INSTANCE_MGD), System.Runtime.InteropServices.Marshalling.MarshalMode.Default, typeof(PERF_COUNTERSET_INSTANCE_MGD.CustomMarshaller))]
#endif
	public class PERF_COUNTERSET_INSTANCE_MGD
	{
		/// <summary>List of counters in this instance block.</summary>
		public List<PERF_COUNTER_INFO_MGD> Counters = [];

		/// <summary>GUID that identifies the counter set to which this instance belongs.</summary>
		public Guid CounterSetGuid { get; set; }

		/// <summary>The provider specified the identifier when calling PerfCreateInstance.</summary>
		public uint InstanceId { get; set; }

		/// <summary>The provider specified the instance name when calling PerfCreateInstance.</summary>
		public string InstanceName { get; set; } = "";
		internal static unsafe class CustomMarshaller
		{
			static readonly uint instanceSize = (uint)Marshal.SizeOf<PERF_COUNTERSET_INSTANCE>();
			public static PERF_COUNTERSET_INSTANCE_MGD? ConvertToManaged(PERF_COUNTERSET_INSTANCE* unmanaged)
			{
				if (unmanaged is null) return null;
				var result = new PERF_COUNTERSET_INSTANCE_MGD
				{
					CounterSetGuid = unmanaged->CounterSetGuid,
					InstanceId = unmanaged->InstanceId,
					InstanceName = Marshal.PtrToStringUni(((IntPtr)unmanaged).Offset(unmanaged->InstanceNameOffset), (int)(unmanaged->InstanceNameSize / 2 - 1)) ?? ""
				};
				var counterInfoPtr = (PERF_COUNTER_INFO*)(unmanaged + 1);
				var counterCount = (unmanaged->InstanceNameOffset - (uint)instanceSize) / (uint)Marshal.SizeOf<PERF_COUNTER_INFO>();
				for (int i = 0; i < counterCount; i++)
				{
					var counterInfo = counterInfoPtr[i];
					var counter = new PERF_COUNTER_INFO_MGD
					{
						CounterId = counterInfo.CounterId,
						Type = counterInfo.Type,
						Attrib = counterInfo.Attrib,
						DetailLevel = counterInfo.DetailLevel,
						Scale = counterInfo.Scale
					};
					if (counterInfo.Offset + 4 <= unmanaged->InstanceNameOffset)
					{
						var nextOffset = (i + 1 < counterCount) ? counterInfoPtr[i + 1].Offset : unmanaged->InstanceNameOffset;
						var counterValueLength = nextOffset - counterInfo.Offset;
						counter.CounterValue = new byte[counterValueLength];
						Marshal.Copy((IntPtr)((byte*)unmanaged + counterInfo.Offset), counter.CounterValue, 0, (int)counterValueLength);
					}
					result.Counters.Add(counter);
				}
				return result;
			}

			public static PERF_COUNTERSET_INSTANCE* ConvertToUnmanaged(PERF_COUNTERSET_INSTANCE_MGD? value)
			{
				if (value is null) return null;
				var instanceNameBytes = ((uint)value.InstanceName.Length + 1) * 2;
				var counterInfoSize = (uint)(value.Counters.Count * Marshal.SizeOf<PERF_COUNTER_INFO>());
				var valueSize = (uint)value.Counters.Sum(c => (c.CounterValue?.Length ?? 0));
				var totalSize = instanceSize + counterInfoSize + instanceNameBytes + valueSize;
				var ptr = (PERF_COUNTERSET_INSTANCE*)Marshal.AllocCoTaskMem((int)totalSize);
				ptr->CounterSetGuid = value.CounterSetGuid;
				ptr->dwSize = totalSize;
				ptr->InstanceId = value.InstanceId;
				ptr->InstanceNameOffset = instanceSize + counterInfoSize + valueSize;
				ptr->InstanceNameSize = instanceNameBytes;
				var counterInfoPtr = (PERF_COUNTER_INFO*)(ptr + 1);
				var offset = instanceSize + counterInfoSize;
				for (int i = 0; i < value.Counters.Count; i++)
				{
					var counter = value.Counters[i];
					counterInfoPtr[i].CounterId = counter.CounterId;
					counterInfoPtr[i].Type = counter.Type;
					counterInfoPtr[i].Attrib = counter.Attrib;
					counterInfoPtr[i].DetailLevel = counter.DetailLevel;
					counterInfoPtr[i].Scale = counter.Scale;
					counterInfoPtr[i].Offset = offset;
					var counterValueLength = counter.CounterValue?.Length ?? 0;
					if (counterValueLength > 0)
					{
						var dest = (byte*)ptr + offset;
						Marshal.Copy(counter.CounterValue!, 0, (IntPtr)dest, counterValueLength);
						offset += (uint)counterValueLength;
					}
				}
				return ptr;
			}
			public static void Free(PERF_COUNTERSET_INSTANCE* unmanaged)
			{
				if (unmanaged != null)
					Marshal.FreeCoTaskMem((IntPtr)unmanaged);
			}
		}
	}

	/// <summary>
	/// Represents an identifier for a performance counter, including its counter set GUID, counter and instance identifiers, status, and
	/// optional instance name.
	/// </summary>
	/// <remarks>
	/// Use this class to specify or retrieve information about a particular performance counter instance when querying or managing
	/// performance counters. The instance name is optional; if not specified, the instance is identified solely by its numeric identifier.
	/// The special value 0xFFFFFFFF for the instance identifier indicates that results should not be filtered by instance. The status field
	/// provides the result of operations such as adding or deleting a counter.
	/// </remarks>
	public class PPERF_COUNTER_IDENTIFIER
	{
		private static readonly int structSize = Marshal.SizeOf<PERF_COUNTER_IDENTIFIER>();
		private PERF_COUNTER_IDENTIFIER id;

		/// <summary>
		/// Initializes a new instance of the PPERF_COUNTER_IDENTIFIER class with the specified counter set GUID, counter ID, instance ID,
		/// and optional instance name.
		/// </summary>
		/// <remarks>
		/// If counterId or instanceId is set to PERF_WILDCARD_COUNTER, the identifier will match all counters or instances, respectively.
		/// This constructor is typically used to specify a particular counter or to select multiple counters or instances using wildcards.
		/// </remarks>
		/// <param name="counterSetGuid">The unique identifier of the performance counter set to which this counter belongs.</param>
		/// <param name="instanceName">The name of the counter instance, or null to indicate all instances.</param>
		/// <param name="counterId">
		/// The identifier of the specific counter within the counter set. Use PERF_WILDCARD_COUNTER to select all counters.
		/// </param>
		/// <param name="instanceId">The identifier of the counter instance. Use PERF_WILDCARD_COUNTER to select all instances.</param>
		public PPERF_COUNTER_IDENTIFIER(Guid counterSetGuid, string? instanceName = null, uint counterId = PERF_WILDCARD_COUNTER, uint instanceId = PERF_WILDCARD_COUNTER)
		{
			CounterSetGuid = counterSetGuid;
			CounterId = counterId;
			InstanceId = instanceId;
			InstanceName = instanceName;
		}

		internal unsafe PPERF_COUNTER_IDENTIFIER(PERF_COUNTER_IDENTIFIER* ptr) : this((IntPtr)ptr) { }

		internal PPERF_COUNTER_IDENTIFIER(IntPtr ptr)
		{
			unsafe { id = *(PERF_COUNTER_IDENTIFIER*)ptr; }
			InstanceName = id.Size > structSize ? StringHelper.GetString(ptr.Offset(structSize), CharSet.Unicode, id.Size - structSize) : null;
		}

		/// <summary>The identifier of the performance counter. <c>PERF_WILDCARD_COUNTER</c> specifies all counters.</summary>
		public uint CounterId { get => id.CounterId; set => id.CounterId = value; }

		/// <summary>The <c>GUID</c> of the performance counter set.</summary>
		public Guid CounterSetGuid { get => id.CounterSetGuid; set => id.CounterSetGuid = value; }

		/// <summary>
		/// The position in the sequence of <c>PERF_COUNTER_IDENTIFIER</c> blocks at which the counter data that corresponds to this
		/// <c>PERF_COUNTER_IDENTIFIER</c> block is returned. Set by PerfQueryCounterInfo.
		/// </summary>
		public uint Index => id.Index;

		/// <summary>The instance identifier. Specify 0xFFFFFFFF if you do not want to filter the results based on the instance identifier.</summary>
		public uint InstanceId { get => id.InstanceId; set => id.InstanceId = value; }

		/// <summary>The optional instance name associated with the counter.</summary>
		public string? InstanceName { get; set; }

		/// <summary>An error code that indicates whether the operation to add or delete a performance counter succeeded or failed.</summary>
		public Win32Error Status => id.Status;
		internal uint Size => (uint)(InstanceName is null ? structSize : structSize + Mult8((InstanceName.Length + 1) * 2));
		internal void Write(IntPtr ptr)
		{
			id.Size = Size;
			Marshal.StructureToPtr(id, ptr, false);
			if (InstanceName is not null)
				StringHelper.Write(InstanceName, ptr.Offset(structSize), out _, true, CharSet.Unicode, id.Size - structSize);
		}
	}

	/// <summary>Represents a pointer to an instance of a performance counter set, providing access to performance metrics.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct PPERF_COUNTERSET_INSTANCE(IntPtr ptr)
	{
		private readonly IntPtr handle = ptr;

		/// <summary>Gets a reference to the underlying structure.</summary>
		public readonly ref PERF_COUNTERSET_INSTANCE Ref => ref handle.AsRef<PERF_COUNTERSET_INSTANCE>();

		/// <summary>Gets the managed details of the instance.</summary>
		public readonly PERF_COUNTERSET_INSTANCE_MGD GetDetails() { unsafe { return PERF_COUNTERSET_INSTANCE_MGD.CustomMarshaller.ConvertToManaged((PERF_COUNTERSET_INSTANCE*)handle)!; } }

		/// <summary>Implictly converts a PPERF_COUNTERSET_INSTANCE to an IntPtr, providing access to the underlying handle.</summary>
		public static implicit operator IntPtr(PPERF_COUNTERSET_INSTANCE inst) => inst.handle;

		/// <summary>Implicitly converts an IntPtr to a PPERF_COUNTERSET_INSTANCE, allowing for easy creation of instances from raw pointers.</summary>
		public static implicit operator PPERF_COUNTERSET_INSTANCE(IntPtr ptr) => new(ptr);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="PERF_COUNTERSET_INSTANCE"/> that is disposed using <see cref="PerfDeleteInstance"/>.</summary>
	[AdjustAutoMethodNamePattern("Perf|Instance", "")]
	public partial class SafePPERF_COUNTERSET_INSTANCE : SafeHANDLE
	{
		private readonly HPERFPROV hProv;

		/// <summary>
		/// Initializes a new instance of the <see cref="SafePPERF_COUNTERSET_INSTANCE"/> class and assigns an existing handle.
		/// </summary>
		/// <param name="ProviderHandle">Handle for the open provider.</param>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafePPERF_COUNTERSET_INSTANCE(HPERFPROV ProviderHandle, IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) => hProv = ProviderHandle;

		/// <summary>Initializes a new instance of the <see cref="SafePPERF_COUNTERSET_INSTANCE"/> class.</summary>
		public SafePPERF_COUNTERSET_INSTANCE() : base() { }

		/// <summary>Gets a reference to the underlying structure.</summary>
		public ref PERF_COUNTERSET_INSTANCE Ref => ref handle.AsRef<PERF_COUNTERSET_INSTANCE>();

		/// <summary>Gets the underlying structure values.</summary>
		public PERF_COUNTERSET_INSTANCE Value => handle.ToStructure<PERF_COUNTERSET_INSTANCE>();

		/// <summary>Performs an implicit conversion from <see cref="SafePPERF_COUNTERSET_INSTANCE"/> to <see cref="IntPtr"/>.</summary>
		public static implicit operator IntPtr(SafePPERF_COUNTERSET_INSTANCE inst) => inst.DangerousGetHandle();

		/// <summary>Performs an implicit conversion from <see cref="SafePPERF_COUNTERSET_INSTANCE"/> to <see cref="PPERF_COUNTERSET_INSTANCE"/>.</summary>
		public static implicit operator PPERF_COUNTERSET_INSTANCE(SafePPERF_COUNTERSET_INSTANCE inst) => inst.DangerousGetHandle();

		/// <summary>Gets the managed details of the instance.</summary>
		public PERF_COUNTERSET_INSTANCE_MGD GetDetails() { unsafe { return PERF_COUNTERSET_INSTANCE_MGD.CustomMarshaller.ConvertToManaged((PERF_COUNTERSET_INSTANCE*)handle)!; } }

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => PerfDeleteInstance(hProv, handle).Succeeded;
	}
}