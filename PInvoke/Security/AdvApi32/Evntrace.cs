using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
#if (NETCOREAPP2_0 || NETCOREAPP2_1 || NETCOREAPP2_2 || NETSTANDARD2_0)
using ArgIterator = System.IntPtr;
#endif

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>The diagnostic logger session name.</summary>
		public const string DIAG_LOGGER_NAME = "DiagLog";

		/// <summary>The event logger session name.</summary>
		public const string EVENT_LOGGER_NAME = "EventLog";

		/// <summary>The global logger session name.</summary>
		public const string GLOBAL_LOGGER_NAME = "GlobalLogger";

		/// <summary>The kernel logger session name.</summary>
		public const string KERNEL_LOGGER_NAME = "NT Kernel Logger";

		/// <summary>Specifies the default event tracing security</summary>
		public static readonly Guid DefaultTraceSecurityGuid = new Guid("0811c1af-7a07-4a06-82ed-869455cdf713");

		public static readonly Guid Dummy = new Guid("3595ab5c-042a-4c8e-b942-2d059bfeb1b1");

		/// <summary>Used to report system configuration records</summary>
		public static readonly Guid EventTraceConfigGuid = new Guid("01853a65-418f-4f36-aefc-dc0f1d2fd235");

		/// <summary>EventTraceGuid is used to identify a event tracing session</summary>
		public static readonly Guid EventTraceGuid = new Guid("68fdd900-4a3e-11d1-84f4-0000f80464e3");

		/// <summary>Used for private cross-process logger notifications.</summary>
		public static readonly Guid PrivateLoggerNotificationGuid = new Guid("3595ab5c-042a-4c8e-b942-2d059bfeb1b1");

		/// <summary>Used to specify event tracing for kernel</summary>
		public static readonly Guid SystemTraceControlGuid = new Guid("9e814aad-3204-11d2-9a82-006008a86939");

		/// <summary>
		/// <para>
		/// Consumers implement this function to receive statistics about each buffer of events that ETW delivers to an event trace consumer.
		/// ETW calls this function after the events for each buffer are delivered.
		/// </para>
		/// <para>
		/// The <c>PEVENT_TRACE_BUFFER_CALLBACK</c> type defines a pointer to this callback function. <c>BufferCallback</c> is a placeholder
		/// for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="Logfile"/>
		/// <returns>
		/// To continue processing events, return <c>TRUE</c>. Otherwise, return <c>FALSE</c>. Returning <c>FALSE</c> will terminate the
		/// ProcessTrace function.
		/// </returns>
		/// <remarks>
		/// <para>
		/// To specify the function that ETW calls to deliver the buffer statistics, set the <c>BufferCallback</c> member of the
		/// EVENT_TRACE_LOGFILE structure that you pass to the OpenTrace function.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example implementation of a <c>BufferCallback</c> function, see Retrieving Event Data Using MOF.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntrace/nc-evntrace-pevent_trace_buffer_callbacka
		// PEVENT_TRACE_BUFFER_CALLBACKA PeventTraceBufferCallbacka; ULONG PeventTraceBufferCallbacka( PEVENT_TRACE_LOGFILEA Logfile ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("evntrace.h", MSDNShortId = "0cfe2f62-63dc-45a6-96ce-fb4bf458358f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool BufferCallback(in EVENT_TRACE_LOGFILE Logfile);

		/// <summary>
		/// <para>[Do not implement this function; it may be unavailable in subsequent versions.]</para>
		/// <para>
		/// Consumers implement this function to receive events for a specific event trace class from a session. ETW calls this function
		/// every time the <c>ProcessTrace</c> function process an event belonging to the event trace class.
		/// </para>
		/// <para>
		/// The <c>PEVENT_CALLBACK</c> type defines a pointer to this callback function. <c>EventClassCallback</c> is a placeholder for the
		/// application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="pEvent">Pointer to an <c>EVENT_TRACE</c> structure that contains the event information.</param>
		/// <returns>The function does not return a value.</returns>
		/// <remarks>
		/// <para>
		/// To associate each <c>EventClassCallback</c> function with the class GUID of the event trace class it processes, use the
		/// <c>SetTraceCallback</c> function.
		/// </para>
		/// <para>To stop the <c>EventClassCallback</c> from receiving events, call the <c>RemoveTraceCallback</c> function.</para>
		/// <para>To processes all events that the session generates, see the <c>EventCallback</c> function.</para>
		/// <para>
		/// If you use both <c>EventCallback</c> and <c>EventClassCallback</c> to receive events, the event is always sent to
		/// <c>EventCallback</c> and is only sent to <c>EventClassCallback</c> if the event matches the class GUID associated with the callback.
		/// </para>
		/// <para>
		/// You use the <c>Header.Class.Type</c> member of <c>EVENT_TRACE</c> to determine the type of event you received. If you are
		/// consuming events from your own provider and know the layout of the data, this is not an issue. Otherwise, to interpret the event,
		/// the provider must have published their event schema in the \\root\wmi namespace. For information on using an event's MOF schema
		/// to interpret the event, see Consuming Events.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/eventclasscallback VOID WINAPI EventClassCallback( _In_ PEVENT_TRACE pEvent );
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("Evntrace.h", MSDNShortId = "32e94f58-b8b6-4e0a-b53b-716a534ac374")]
		public delegate void EventClassCallback(in EVENT_TRACE pEvent);

		/// <summary>
		/// <para>Consumers implement this callback to receive events from a session.</para>
		/// <para>
		/// The <c>PEVENT_RECORD_CALLBACK</c> type defines a pointer to this callback function. <c>EventRecordCallback</c> is a placeholder
		/// for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="EventRecord">Pointer to an <c>EVENT_RECORD</c> structure that contains the event information.</param>
		/// <returns>The function does not return a value.</returns>
		/// <remarks>
		/// <para>
		/// To specify the function that ETW calls to deliver events, set the <c>EventRecordCallback</c> member of the
		/// <c>EVENT_TRACE_LOGFILE</c> structure (you pass this structure to the <c>OpenTrace</c> function). You must also set the
		/// <c>ProcessTraceMode</c> member to PROCESS_TRACE_MODE_EVENT_RECORD.
		/// </para>
		/// <para>
		/// This callback receives all events that the session generates from the time you call the <c>OpenTrace</c> function. Call the
		/// <c>ProcessTrace</c> function to begin receiving the events.
		/// </para>
		/// <para>For information on parsing the event data, see Retrieving Event Data Using TDH.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/eventrecordcallback VOID WINAPI EventRecordCallback( _In_ PEVENT_RECORD
		// EventRecord );
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("", MSDNShortId = "80a30faf-af1f-4440-8a17-9df44bdb2291")]
		public delegate void EventRecordCallback(in EVENT_RECORD EventRecord);

		/// <summary>
		/// <para>Providers implement this function to receive enable or disable notification requests from controllers.</para>
		/// <para>
		/// The <c>WMIDPREQUEST</c> type defines a pointer to this callback function. <c>ControlCallback</c> is a placeholder for the
		/// application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="RequestCode">Request code. Specify one of the following values.</param>
		/// <param name="Context">
		/// Provider-defined context. The provider uses the RequestContext parameter of <c>RegisterTraceGuids</c> to specify the context.
		/// </param>
		/// <param name="Reserved">Reserved for internal use.</param>
		/// <param name="Buffer">
		/// Pointer to a <c>WNODE_HEADER</c> structure that contains information about the event tracing session for which the provider is
		/// being enabled or disabled.
		/// </param>
		/// <returns>
		/// You should return ERROR_SUCCESS if the callback succeeds. Note that ETW ignores the return value for this function except when a
		/// controller calls <c>EnableTrace</c> to enable a provider and the provider has not yet called <c>RegisterTraceGuids</c>. When this
		/// occurs, <c>RegisterTraceGuids</c> will return the return value of this callback if the registration was successful.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is specified using the <c>RegisterTraceGuids</c> function. When the controller calls the <c>EnableTrace</c>
		/// function to enable, disable, or change the enable flags or level, ETW calls this callback. The provider enables or disables
		/// itself based the RequestCode value. Typically, the provider uses this value to set a global flag to indicate its enabled state.
		/// </para>
		/// <para>
		/// The provider defines its interpretation of being enabled or disabled. Generally, if a provider is enabled, it generates events,
		/// but while it is disabled, it does not.
		/// </para>
		/// <para>
		/// ETW does not pass the enable flags and enable level that the controller passes to the <c>EnableTrace</c> function to this
		/// callback. To retrieve this information, call the <c>GetTraceEnableFlags</c> and <c>GetTraceEnableLevel</c> functions, respectively.
		/// </para>
		/// <para>
		/// You also need to retrieve the session handle in this callback for future calls. To retrieve the session handle, call the
		/// <c>GetTraceLoggerHandle</c> function.
		/// </para>
		/// <para>
		/// Your callback function must not call anything that may incur LoadLibrary (more specifically, anything that requires a loader lock).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/etw/controlcallback ULONG WINAPI ControlCallback( _In_ WMIDPREQUESTCODE
		// RequestCode, _In_ PVOID Context, _In_ ULONG *Reserved, _In_ PVOID Buffer );
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("evntrace.h", MSDNShortId = "e9f70ae6-906f-4e55-bca7-4355f1ca6091")]
		public delegate Win32Error TraceControlCallback([In] WMIDPREQUESTCODE RequestCode, [In] IntPtr Context, ref uint Reserved, [In] IntPtr Buffer);

		/// <summary>Defines the source of the event data.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ne-tdh-decoding_source typedef enum _DECODING_SOURCE {
		// DecodingSourceXMLFile, DecodingSourceWbem, DecodingSourceWPP, DecodingSourceTlg, DecodingSourceMax } DECODING_SOURCE;
		[PInvokeData("tdh.h", MSDNShortId = "d6cd09da-9a67-4df2-9d82-370c559d3bfc")]
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

		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>Specifies what kind of operation will be done on a handle. currently used with the QueryTraceProcessingHandle function.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntrace/ne-evntrace-etw_process_handle_info_type typedef enum
		// _ETW_PROCESS_HANDLE_INFO_TYPE { EtwQueryPartitionInformation, EtwQueryProcessHandleInfoMax, EtwQueryPartitionInformationV2,
		// EtwQueryLastDroppedTimes } ETW_PROCESS_HANDLE_INFO_TYPE;
		[PInvokeData("evntrace.h", MSDNShortId = "92932E4C-0A06-4CDE-B14B-BF53226E133B")]
		public enum ETW_PROCESS_HANDLE_INFO_TYPE
		{
			/// <summary>
			/// Used to query partition identifying information. InBuffer should be Null. OutBuffer should be large enough to hold the
			/// returned ETW_TRACE_PARTITION_INFORMATION structure. Note that this will only return a non-zero structure when the queried
			/// handle is for a trace file generated from a non-host partition on Windows 10, version 1709.
			/// </summary>
			EtwQueryPartitionInformation,
		}

		/// <summary>Control code for EnableTraceEx2.</summary>
		[PInvokeData("evntrace.h")]
		public enum EVENT_CONTROL_CODE
		{
			/// <summary>Disables the provider.</summary>
			EVENT_CONTROL_CODE_DISABLE_PROVIDER = 0,

			/// <summary>Enables the provider. The session receives events when the provider is registered.</summary>
			EVENT_CONTROL_CODE_ENABLE_PROVIDER = 1,

			/// <summary>
			/// Requests that the provider log its state information. First you would enable the provider and then call EnableTraceEx2 with
			/// this control code to capture state information.
			/// </summary>
			EVENT_CONTROL_CODE_CAPTURE_STATE = 2
		}

		/// <summary>Defines the provider information to retrieve.</summary>
		/// <remarks>
		/// <para>
		/// If you specify <c>EventOpcodeInformation</c> when calling TdhQueryProviderFieldInformation, you must specify the EventFieldValue
		/// parameter as follows:
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
		// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ne-tdh-event_field_type typedef enum _EVENT_FIELD_TYPE {
		// EventKeywordInformation, EventLevelInformation, EventChannelInformation, EventTaskInformation, EventOpcodeInformation,
		// EventInformationMax } EVENT_FIELD_TYPE;
		[PInvokeData("tdh.h", MSDNShortId = "da525556-e42b-41cb-b954-300f378477e5")]
		public enum EVENT_FIELD_TYPE
		{
			/// <summary>
			/// Keyword information defined in the manifest. For providers that define themselves using MOF classes, this type returns the
			/// enable flags values if the provider class includes the Flags property. For details, see the "Specifying level and enable
			/// flags values for a provider" section of Event Tracing MOF Qualifiers.
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

		/// <summary>Requested control function.</summary>
		[PInvokeData("evntrace.h", MSDNShortId = "c39f669c-ff40-40ed-ba47-798474ec2de4")]
		public enum EVENT_TRACE_CONTROL
		{
			/// <summary>Retrieves session properties and statistics.</summary>
			EVENT_TRACE_CONTROL_QUERY = 0,

			/// <summary>Stops the session. The session handle is no longer valid.</summary>
			EVENT_TRACE_CONTROL_STOP = 1,

			/// <summary>Updates the session properties.</summary>
			EVENT_TRACE_CONTROL_UPDATE = 2,

			/// <summary>
			/// Flushes the session's active buffers. Typically, you do not need to flush buffers yourself. However, you may want to flush
			/// buffers if the event rate is low and you are delivering events in real time.
			/// <para>Windows 2000: This value is not supported.</para>
			/// </summary>
			EVENT_TRACE_CONTROL_FLUSH = 3,

			/// <summary>Undocumented.</summary>
			EVENT_TRACE_CONTROL_INCREMENT_FILE = 4,
		}

		/// <summary>
		/// A system logger must set EnableFlags to indicate which SystemTraceProvider events should be included in the trace. This is also
		/// used for NT Kernel Logger sessions.
		/// </summary>
		[PInvokeData("evntrace.h")]
		[Flags]
		public enum EVENT_TRACE_FLAG : uint
		{
			/// <summary>
			/// Enables the ALPC event types.
			/// <para>This value is supported on Windows Vista and later.</para>
			/// </summary>
			EVENT_TRACE_FLAG_ALPC = 0x00100000,

			/// <summary>
			/// Enables the following Thread event type:
			/// <list type="bullet">
			/// <item>CSwitch</item>
			/// </list>
			/// <para>This value is supported on Windows Vista and later.</para>
			/// </summary>
			EVENT_TRACE_FLAG_CSWITCH = 0x00000010,

			/// <summary>Enables the DbgPrint and DbgPrintEx calls to be converted to ETW events.</summary>
			EVENT_TRACE_FLAG_DBGPRINT = 0x00040000,

			/// <summary>
			/// Enables the following FileIo event type (you must also enable EVENT_TRACE_FLAG_DISK_IO):
			/// <list type="bullet">
			/// <item>FileIo_Name</item>
			/// </list>
			/// </summary>
			EVENT_TRACE_FLAG_DISK_FILE_IO = 0x00000200,

			/// <summary>
			/// Enables the following DiskIo event types:
			/// <list type="bullet">
			/// <item>DiskIo_TypeGroup1</item>
			/// <item>DiskIo_TypeGroup3</item>
			/// </list>
			/// </summary>
			EVENT_TRACE_FLAG_DISK_IO = 0x00000100,

			/// <summary>
			/// Enables the following DiskIo event type:
			/// <list type="bullet">
			/// <item>DiskIo_TypeGroup2</item>
			/// </list>
			/// <para>This value is supported on Windows Vista and later.</para>
			/// </summary>
			EVENT_TRACE_FLAG_DISK_IO_INIT = 0x00000400,

			/// <summary>
			/// Enables the following Thread event type:
			/// <list type="bullet">
			/// <item>ReadyThread</item>
			/// </list>
			/// <para>This value is supported on Windows 7, Windows Server 2008 R2, and later.</para>
			/// </summary>
			EVENT_TRACE_FLAG_DISPATCHER = 0x00000800,

			/// <summary>
			/// Enables the following PerfInfo event type:
			/// <list type="bullet">
			/// <item>DPC</item>
			/// </list>
			/// <para>This value is supported on Windows Vista and later.</para>
			/// </summary>
			EVENT_TRACE_FLAG_DPC = 0x00000020,

			/// <summary>
			/// Enables the following DiskIo event types:
			/// <list type="bullet">
			/// <item>DriverCompleteRequest</item>
			/// <item>DriverCompleteRequestReturn</item>
			/// <item>DriverCompletionRoutine</item>
			/// <item>DriverMajorFunctionCall</item>
			/// <item>DriverMajorFunctionReturn</item>
			/// </list>
			/// <para>This value is supported on Windows Vista and later.</para>
			/// </summary>
			EVENT_TRACE_FLAG_DRIVER = 0x00800000,

			/// <summary>
			/// Enables the following FileIo event types:
			/// <list type="bullet">
			/// <item>FileIo_OpEnd</item>
			/// </list>
			/// <para>This value is supported on Windows Vista and later.</para>
			/// </summary>
			EVENT_TRACE_FLAG_FILE_IO = 0x02000000,

			/// <summary>
			/// Enables the following FileIo event type:
			/// <list type="bullet">
			/// <item>FileIo_Create</item>
			/// <item>FileIo_DirEnum</item>
			/// <item>FileIo_Info</item>
			/// <item>FileIo_ReadWrite</item>
			/// <item>FileIo_SimpleOp</item>
			/// </list>
			/// <para>This value is supported on Windows Vista and later.</para>
			/// </summary>
			EVENT_TRACE_FLAG_FILE_IO_INIT = 0x04000000,

			/// <summary>
			/// Enables the following Image event type:
			/// <list type="bullet">
			/// <item>Image_Load</item>
			/// </list>
			/// </summary>
			EVENT_TRACE_FLAG_IMAGE_LOAD = 0x00000004,

			/// <summary>
			/// Enables the following PerfInfo event type:
			/// <list type="bullet">
			/// <item>ISR</item>
			/// </list>
			/// <para>This value is supported on Windows Vista and later.</para>
			/// </summary>
			EVENT_TRACE_FLAG_INTERRUPT = 0x00000040,

			/// <summary>This value is supported on Windows 10</summary>
			EVENT_TRACE_FLAG_JOB = 0x00080000,

			/// <summary>
			/// Enables the following PageFault_V2 event type:
			/// <list type="bullet">
			/// <item>PageFault_HardFault</item>
			/// </list>
			/// </summary>
			EVENT_TRACE_FLAG_MEMORY_HARD_FAULTS = 0x00002000,

			/// <summary>
			/// Enables the following PageFault_V2 event type:
			/// <list type="bullet">
			/// <item>PageFault_TypeGroup1</item>
			/// </list>
			/// </summary>
			EVENT_TRACE_FLAG_MEMORY_PAGE_FAULTS = 0x00001000,

			/// <summary>Enables the TcpIp and UdpIp event types.</summary>
			EVENT_TRACE_FLAG_NETWORK_TCPIP = 0x00010000,

			/// <summary>
			/// Do not do a system configuration rundown.
			/// <para>This value is supported on Windows 8, Windows Server 2012, and later.</para>
			/// </summary>
			EVENT_TRACE_FLAG_NO_SYSCONFIG = 0x10000000,

			/// <summary>
			/// Enables the following Process event type:
			/// <list type="bullet">
			/// <item>Process_TypeGroup1</item>
			/// </list>
			/// </summary>
			EVENT_TRACE_FLAG_PROCESS = 0x00000001,

			/// <summary>
			/// Enables the following Process_V2 event type:
			/// <list type="bullet">
			/// <item>Process_V2_TypeGroup2</item>
			/// </list>
			/// <para>This value is supported on Windows Vista and later.</para>
			/// </summary>
			EVENT_TRACE_FLAG_PROCESS_COUNTERS = 0x00000008,

			/// <summary>
			/// Enables the following PerfInfo event type:
			/// <list type="bullet">
			/// <item>SampledProfile</item>
			/// </list>
			/// <para>This value is supported on Windows Vista and later.</para>
			/// </summary>
			EVENT_TRACE_FLAG_PROFILE = 0x01000000,

			/// <summary>Enables the Registry event types.</summary>
			EVENT_TRACE_FLAG_REGISTRY = 0x00020000,

			/// <summary>
			/// Enables the SplitIo event types.
			/// <para>This value is supported on Windows Vista and later.</para>
			/// </summary>
			EVENT_TRACE_FLAG_SPLIT_IO = 0x00200000,

			/// <summary>
			/// Enables the following PerfInfo event type:
			/// <list type="bullet">
			/// <item>SysCallEnter</item>
			/// <item>SysCallExit</item>
			/// </list>
			/// <para>This value is supported on Windows Vista and later.</para>
			/// </summary>
			EVENT_TRACE_FLAG_SYSTEMCALL = 0x00000080,

			/// <summary>
			/// Enables the following Thread event type:
			/// <para>Thread_TypeGroup1</para>
			/// </summary>
			EVENT_TRACE_FLAG_THREAD = 0x00000002,

			/// <summary>
			/// Enables the map and unmap (excluding image files) event type.
			/// <para>This value is supported on Windows 8, Windows Server 2012, and later.</para>
			/// </summary>
			EVENT_TRACE_FLAG_VAMAP = 0x00008000,

			/// <summary>
			/// Enables the following PageFault_V2 event type:
			/// <list type="bullet">
			/// <item>PageFault_VirtualAlloc</item>
			/// </list>
			/// <para>This value is supported on Windows 7, Windows Server 2008 R2, and later.</para>
			/// </summary>
			EVENT_TRACE_FLAG_VIRTUAL_ALLOC = 0x00004000,
		}

		/// <summary>Type flags used by <see cref="EVENT_TRACE_HEADER"/>.</summary>
		[PInvokeData("evntrace.h")]
		public enum EVENT_TRACE_TYPE : byte
		{
			/// <summary>Checkpoint event. Use for an event that is not at the start or end of an activity.</summary>
			EVENT_TRACE_TYPE_CHECKPOINT = 0x08,

			/// <summary>Data collection end event.</summary>
			EVENT_TRACE_TYPE_DC_END = 0x04,

			/// <summary>Data collection start event.</summary>
			EVENT_TRACE_TYPE_DC_START = 0x03,

			/// <summary>
			/// Dequeue event. Use when an activity is queued before it begins. Use EVENT_TRACE_TYPE_START to mark the time when a work item
			/// is queued. Use the dequeue event type to mark the time when work on the item actually begins. Use EVENT_TRACE_TYPE_END to
			/// mark the time when work on the item completes.
			/// </summary>
			EVENT_TRACE_TYPE_DEQUEUE = 0x07,

			/// <summary>End event. Use to trace the final state of a multi-step event.</summary>
			EVENT_TRACE_TYPE_END = 0x02,

			/// <summary>
			/// Extension event. Use for an event that is a continuation of a previous event. For example, use the extension event type when
			/// an event trace records more data than can fit in a session buffer.
			/// </summary>
			EVENT_TRACE_TYPE_EXTENSION = 0x05,

			/// <summary>Informational event. This is the default event type.</summary>
			EVENT_TRACE_TYPE_INFO = 0x00,

			/// <summary>
			/// Reply event. Use when an application that requests resources can receive multiple responses. For example, if a client
			/// application requests a URL, and the web server replies by sending several files, each file received can be marked as a reply event.
			/// </summary>
			EVENT_TRACE_TYPE_REPLY = 0x06,

			/// <summary>Start event. Use to trace the initial state of a multi-step event.</summary>
			EVENT_TRACE_TYPE_START = 0x01,

			/// <summary>Send Event (WinEvent compatible)</summary>
			EVENT_TRACE_TYPE_WINEVT_SEND = 0x09,

			/// <summary>Receive Event (WinEvent compatible)</summary>
			EVENT_TRACE_TYPE_WINEVT_RECEIVE = 0XF0,
		}

		/// <summary>Defines what component of the security descriptor that the EventAccessControl function modifies.</summary>
		/// <remarks>For information on DACLs and SACLs, see Access Control Lists.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntcons/ne-evntcons-eventsecurityoperation typedef enum {
		// EventSecuritySetDACL, EventSecuritySetSACL, EventSecurityAddDACL, EventSecurityAddSACL, EventSecurityMax } ;
		[PInvokeData("evntcons.h", MSDNShortId = "81f6cf07-2705-4075-b085-d5aebba17121")]
		public enum EVENTSECURITYOPERATION
		{
			/// <summary>
			/// Clears the current discretionary access control list (DACL) and adds an ACE to the DACL. The Sid, Rights, and AllowOrDeny
			/// parameters of the EventAccessControl function determine the contents of the ACE (who has access to the provider or session
			/// and the type of access). To add a new ACE to the DACL without clearing the existing DACL, specify EventSecurityAddDACL.
			/// </summary>
			EventSecuritySetDACL,

			/// <summary>
			/// Clears the current system access control list (SACL) and adds an audit ACE to the SACL. The Sid and Rights parameters of the
			/// EventAccessControl function determine the contents of the ACE (who generates an audit record when attempting the specified
			/// access). To add a new ACE to the SACL without clearing the existing SACL, specify EventSecurityAddSACL.
			/// </summary>
			EventSecuritySetSACL,

			/// <summary>
			/// Adds an ACE to the current DACL. The Sid, Rights, and AllowOrDeny parameters of the EventAccessControl function determine the
			/// contents of the ACE (who has access to the provider or session and the type of access).
			/// </summary>
			EventSecurityAddDACL,

			/// <summary>
			/// Adds an ACE to the current SACL. The Sid and Rights parameters of the EventAccessControl function determine the contents of
			/// the ACE (who generates an audit record when attempting the specified access).
			/// </summary>
			EventSecurityAddSACL,
		}

		/// <summary>
		/// <para>The following constants represent the possible logging modes for an event tracing session.</para>
		/// <para>
		/// The constants are used in the <c>LogFileMode</c> members of <c>EVENT_TRACE_LOGFILE</c>, <c>EVENT_TRACE_PROPERTIES</c> and
		/// <c>TRACE_LOGFILE_HEADER</c> structures. These constants are defined in the Evntrace.h header file.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/etw/logging-mode-constants
		[PInvokeData("Evntrace.h", MSDNShortId = "d12aaecb-776a-4476-9ba4-16af30fde9c2")]
		[Flags]
		public enum LogFileMode : uint
		{
			/// <summary>Same as EVENT_TRACE_FILE_MODE_SEQUENTIAL with no maximum file size specified.</summary>
			EVENT_TRACE_FILE_MODE_NONE = 0x00000000,

			/// <summary>
			/// Writes events to a log file sequentially; stops when the file reaches its maximum size.Do not use with
			/// EVENT_TRACE_FILE_MODE_CIRCULAR or EVENT_TRACE_FILE_MODE_NEWFILE.
			/// </summary>
			EVENT_TRACE_FILE_MODE_SEQUENTIAL = 0x00000001,

			/// <summary>
			/// Writes events to a log file. After the file reaches the maximum size, the oldest events are replaced with incoming
			/// events.Note that the contents of the circular log file may appear out of order on multiprocessor computers.
			/// <para>Do not use with EVENT_TRACE_FILE_MODE_APPEND, EVENT_TRACE_FILE_MODE_NEWFILE, or EVENT_TRACE_FILE_MODE_SEQUENTIAL.</para>
			/// </summary>
			EVENT_TRACE_FILE_MODE_CIRCULAR = 0x00000002,

			/// <summary>
			/// Appends events to an existing sequential log file. If the file does not exist, it is created. Use only if you specify system
			/// time for the clock resolution, otherwise, ProcessTrace will return events with incorrect time stamps. When using
			/// EVENT_TRACE_FILE_MODE_APPEND, the values for BufferSize, NumberOfProcessors, and ClockType must be explicitly provided and
			/// must be the same in both the logger and the file being appended.
			/// <para>Do not use with EVENT_TRACE_REAL_TIME_MODE, EVENT_TRACE_FILE_MODE_CIRCULAR, EVENT_TRACE_FILE_MODE_NEWFILE, or EVENT_TRACE_PRIVATE_LOGGER_MODE.</para>
			/// <para>Windows 2000: This value is not supported.</para>
			/// </summary>
			EVENT_TRACE_FILE_MODE_APPEND = 0x00000004,

			/// <summary>
			/// Automatically switches to a new log file when the file reaches the maximum size. The MaximumFileSize member of
			/// EVENT_TRACE_PROPERTIES must be set.The specified file name must be a formatted string (for example, the string contains a %d,
			/// such as c:\test%d.etl). Each time a new file is created, a counter is incremented and its value is used, the formatted string
			/// is updated, and the resulting string is used as the file name.
			/// <para>This option is not allowed for private event tracing sessions and should not be used for NT kernel logger sessions.</para>
			/// <para>Do not use with EVENT_TRACE_FILE_MODE_CIRCULAR, EVENT_TRACE_FILE_MODE_APPEND or EVENT_TRACE_FILE_MODE_SEQUENTIAL.</para>
			/// <para>Windows 2000: This value is not supported.</para>
			/// </summary>
			EVENT_TRACE_FILE_MODE_NEWFILE = 0x00000008,

			/// <summary>
			/// Reserves EVENT_TRACE_PROPERTIES.MaximumFileSize bytes of disk space for the log file in advance. The file occupies the entire
			/// space during logging, for both circular and sequential log files. When you stop the session, the log file is reduced to the
			/// size needed. You must set EVENT_TRACE_PROPERTIES.MaximumFileSize.
			/// <para>You cannot use the mode for private event tracing sessions.</para>
			/// <para>Windows 2000: This value is not supported.</para>
			/// </summary>
			EVENT_TRACE_FILE_MODE_PREALLOCATE = 0x00000020,

			/// <summary>
			/// The logging session cannot be stopped. This mode is only supported by Autologger.This option is supported on Windows Vista
			/// and later.
			/// </summary>
			EVENT_TRACE_NONSTOPPABLE_MODE = 0x00000040,

			/// <summary>
			/// Restricts who can log events to the session to those with TRACELOG_LOG_EVENT permission. This option is supported on Windows
			/// Vista and later.
			/// </summary>
			EVENT_TRACE_SECURE_MODE = 0X00000080,

			/// <summary>
			/// Delivers the events to consumers in real-time. Events are delivered when the buffers are flushed, not at the time the
			/// provider writes the event. You should not enable real-time mode if there are no consumers to consume the events because calls
			/// to log events will eventually fail when the buffers become full. Prior to Windows Vista, if the events were not being
			/// consumed, the events were discarded.Do not specify more than one real-time consumer in one process on Windows XP orWindows
			/// Server 2003. Instead, have one thread consume events and distribute the events to others.
			/// <para>
			/// Prior to Windows Vista: You should not use real-time mode because the supported event rate is much lower than reading from
			/// the log file (events may be dropped). Also, the event order is not guaranteed on computers with multiple processors. The
			/// real-time mode is more suitable for low-traffic, notification type events.
			/// </para>
			/// <para>
			/// You can combine this mode with other log file modes; however, do not use this mode with EVENT_TRACE_PRIVATE_LOGGER_MODE. Note
			/// that if you combine this mode with other log file modes, buffers will be flushed once every second, resulting in partially
			/// filled buffers being written to your log file. For example if you use 64k buffers and your logging rate is 1 event every
			/// second, the service will write 64k/second to your log file.
			/// </para>
			/// </summary>
			EVENT_TRACE_REAL_TIME_MODE = 0x00000100,

			/// <summary>
			/// This mode is used to delay opening the log file until an event occurs.
			/// <para>[!Note]</para>
			/// <para>On Windows Vista or later, this mode is not applicable should not be used.</para>
			/// </summary>
			EVENT_TRACE_DELAY_OPEN_FILE_MODE = 0x00000200,

			/// <summary>
			/// This mode writes events to a circular memory buffer. Events written beyond the total size of the buffer evict the oldest
			/// events still remaining in the buffer. The size of this memory buffer is the product of MinimumBuffers and BufferSize (see
			/// EVENT_TRACE_PROPERTIES).As a consequence of this formula, any buffer that uses EVENT_TRACE_BUFFERING_MODE will ignore the
			/// MaximumBuffers value.
			/// <para>
			/// Events are not written to a log file or delivered in real-time, and ETW does not flush the buffers. To get a snapshot of the
			/// buffer, call the FlushTrace function.
			/// </para>
			/// <para>
			/// This mode is particularly useful for debugging device drivers in conjunction with the ability to view the contents of
			/// in-memory buffers with the WMITrace kernel debugger extension.
			/// </para>
			/// <para>
			/// Do not use with EVENT_TRACE_FILE_MODE_SEQUENTIAL, EVENT_TRACE_FILE_MODE_CIRCULAR, EVENT_TRACE_FILE_MODE_APPEND,
			/// EVENT_TRACE_FILE_MODE_NEWFILE, or EVENT_TRACE_REAL_TIME_MODE.
			/// </para>
			/// </summary>
			EVENT_TRACE_BUFFERING_MODE = 0x00000400,

			/// <summary>
			/// Creates a user-mode event tracing session that runs in the same process as its event trace provider. The memory for buffers
			/// comes from the process's memory. Processes that do not require data from the kernel can eliminate the overhead associated
			/// with kernel-mode transitions by using a private event tracing session.
			/// <para>
			/// If the provider is registered by multiple processes, ETW appends the process identifier to the log file name to create a
			/// unique log file name. For example, if the controller specifies the log file names as c:\mylogs\myprivatelog.etl, ETW creates
			/// the log file as c:\mylogs\myprivatelog.etl_nnnn, where nnnn is the process identifier. The process identifier is not appended
			/// to the first process that registers the provider, it is appended to only the subsequent processes that register the provider.
			/// </para>
			/// <para>Private event tracing sessions have the following limitations:</para>
			/// <list type="bullet">
			/// <item>A private session can record events only for the threads of the process in which it is executing.</item>
			/// <item>There can be up to eight private session per process.</item>
			/// <item>Private sessions cannot be used with real-time delivery.</item>
			/// <item>
			/// Events that are generated by a private session do not include execution time for kernel-mode versus user-mode instructions,
			/// or thread-level detail of the CPU time used.
			/// </item>
			/// </list>
			/// <para>
			/// Process ID filters and executable name filters can now be passed in to session control APIs when system wide private loggers
			/// are started. For the best results in cross process scenarios, the same filters should be passed to every control operation
			/// during the session, including provider enable/diasble calls. Note that the filters have the same format as those consumed by EnableTraceEx2.
			/// </para>
			/// <para>You can use this mode in conjunction with the EVENT_TRACE_PRIVATE_IN_PROC mode.</para>
			/// <para>
			/// <strong>Prior to Windows 10, version 1703</strong>: Only LocalSystem, the administrator, and users in the administrator group
			/// that run in an elevated process can create a private session. If you include the EVENT_TRACE_PRIVATE_IN_PROC flag, any user
			/// can create an in-process private session. Also, in prior versions of Windows, there can only be one private session per
			/// process (unless the EVENT_TRACE_PRIVATE_IN_PROC mode is also specified, in which case you can create up to three in-process
			/// private sessions).
			/// </para>
			/// <para><strong>Prior to Windows Vista:</strong> Users in the Performance Log Users group could also create a private session.</para>
			/// <para>Do not use with EVENT_TRACE_REAL_TIME_MODE.</para>
			/// <para><strong>Prior to Windows 7 and Windows Server 2008 R2</strong>: Do not use with EVENT_TRACE_FILE_MODE_NEWFILE.</para>
			/// </summary>
			EVENT_TRACE_PRIVATE_LOGGER_MODE = 0x00000800,

			/// <summary>
			/// This option adds a header to the log file.
			/// <para>[!Note]</para>
			/// <para>On Windows Vista or later, this mode is not applicable should not be used.</para>
			/// </summary>
			EVENT_TRACE_ADD_HEADER_MODE = 0x00001000,

			/// <summary>
			/// Use kilobytes as the unit of measure for specifying the size of a file. The default unit of measure is megabytes. This mode
			/// applies to the MaxFileSize registry value for an AutoLogger session and the MaximumFileSize member of EVENT_TRACE_PROPERTIES.
			/// This option is supported on Windows Vista and later.
			/// </summary>
			EVENT_TRACE_USE_KBYTES_FOR_SIZE = 0x00002000,

			/// <summary>
			/// Uses sequence numbers that are unique across event tracing sessions. This mode only applies to events logged using the
			/// TraceMessage function. For more information, see TraceMessage for usage details.
			/// <para>EVENT_TRACE_USE_GLOBAL_SEQUENCE and EVENT_TRACE_USE_LOCAL_SEQUENCE are mutually exclusive.</para>
			/// <para>Windows 2000: This value is not supported.</para>
			/// </summary>
			EVENT_TRACE_USE_GLOBAL_SEQUENCE = 0x00004000,

			/// <summary>
			/// Uses sequence numbers that are unique only for an individual event tracing session. This mode only applies to events logged
			/// using the TraceMessage function. For more information, see TraceMessage for usage details.
			/// <para>EVENT_TRACE_USE_GLOBAL_SEQUENCE and EVENT_TRACE_USE_LOCAL_SEQUENCE are mutually exclusive.</para>
			/// <para>Windows 2000: This value is not supported.</para>
			/// </summary>
			EVENT_TRACE_USE_LOCAL_SEQUENCE = 0x00008000,

			/// <summary>
			/// Logs the event without including EVENT_TRACE_HEADER.
			/// <para>[!Note]</para>
			/// <para>This mode should not be used. It is reserved for internal use.</para>
			/// <para>Windows 2000: This value is not supported.</para>
			/// </summary>
			EVENT_TRACE_RELOG_MODE = 0x00010000,

			/// <summary>
			/// Use in conjunction with the EVENT_TRACE_PRIVATE_LOGGER_MODE mode to start a private session. This mode enforces that only the
			/// process that registered the provider GUID can start the logger session with that GUID.
			/// <para>You can create up to three in-process private sessions per process.</para>
			/// <para>This option is supported on Windows Vista and later.</para>
			/// </summary>
			EVENT_TRACE_PRIVATE_IN_PROC = 0x00020000,

			/// <summary>
			/// This option is used to signal heap and critical section tracing. This option is supported on Windows Vista and later.
			/// </summary>
			EVENT_TRACE_MODE_RESERVED = 0x00100000,

			/// <summary>
			/// This option stops logging on hybrid shutdown. If neither EVENT_TRACE_STOP_ON_HYBRID_SHUTDOWN or
			/// EVENT_TRACE_PERSIST_ON_HYBRID_SHUTDOWN is specified, ETW will chose a default based on whether the caller is coming from
			/// Session 0 or not.This option is supported on Windows 8 and Windows Server 2012.
			/// </summary>
			EVENT_TRACE_STOP_ON_HYBRID_SHUTDOWN = 0x00400000,

			/// <summary>
			/// This option continues logging on hybrid shutdown. If neither EVENT_TRACE_STOP_ON_HYBRID_SHUTDOWN or
			/// EVENT_TRACE_PERSIST_ON_HYBRID_SHUTDOWN is specified, ETW will chose a default based on whether the caller is coming from
			/// Session 0 or not.This option is supported on Windows 8 and Windows Server 2012.
			/// </summary>
			EVENT_TRACE_PERSIST_ON_HYBRID_SHUTDOWN = 0x00800000,

			/// <summary>
			/// Uses paged memory. This setting is recommended so that events do not use up the nonpaged memory.Nonpaged buffers use nonpaged
			/// memory for buffer space. Because nonpaged buffers are never paged out, a logging session performs well. Using pageable
			/// buffers is less resource-intensive.
			/// <para>Kernel-mode providers and system loggers cannot log events to sessions that specify this logging mode.</para>
			/// <para>This mode is ignored if EVENT_TRACE_PRIVATE_LOGGER_MODE is set.</para>
			/// <para>You cannot use this mode with the NT Kernel Logger.</para>
			/// <para>Windows 2000: This value is not supported.</para>
			/// </summary>
			EVENT_TRACE_USE_PAGED_MEMORY = 0x01000000,

			/// <summary>
			/// This option will receive events from SystemTraceProvider. If the StartTraceProperties parameter LogFileMode includes this
			/// flag, the logger will be a system logger.This option is supported on Windows 8 and Windows Server 2012.
			/// </summary>
			EVENT_TRACE_SYSTEM_LOGGER_MODE = 0x02000000,

			/// <summary>
			/// Indicates that a logging session should not be affected by EventWrite failures in other sessions. Without this flag, if an
			/// event cannot be published to one of the sessions that a provider is enabled to, the event will not get published to any of
			/// the sessions. When this flag is set, a failure to write an event to one session will not cause the EventWrite function to
			/// return an error code in other sessions.
			/// <para>Do not use with EVENT_TRACE_PRIVATE_LOGGER_MODE.</para>
			/// <para>This option is supported on Windows 8.1, Windows Server 2012 R2, and later.</para>
			/// </summary>
			EVENT_TRACE_INDEPENDENT_SESSION_MODE = 0x08000000,

			/// <summary>
			/// Writes events that were logged on different processors to a common buffer. Using this mode can eliminate the issue of events
			/// appearing out of order when events are being published on different processors using system time. This mode can also
			/// eliminate the issue with circular logs appearing to drop events on multiple processor computers.
			/// <para>
			/// If you do not use this mode and you use system time, the events may appear out of order on multiple processor computers. This
			/// is because ETW buffers are associated with a processor instead of a thread. As a result, if a thread is switched from one CPU
			/// to another, the buffer associated with the latter CPU can be flushed to disk before the one associated with the former CPU.
			/// </para>
			/// <para>If you expect a high volume of events (for example, more than 1,000 events per second), you should not use this mode.</para>
			/// <para>Note that the processor number is not included with the event.</para>
			/// <para>This option is supported on Windows 7, Windows Server 2008 R2, and later.</para>
			/// </summary>
			EVENT_TRACE_NO_PER_PROCESSOR_BUFFERING = 0x10000000,

			/// <summary>This option adds ETW buffers to triage dumps. This option is supported on Windows 8 and Windows Server 2012.</summary>
			EVENT_TRACE_ADDTO_TRIAGE_DUMP = 0x80000000,
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
			/// This flag can be combined with the EVENTMAP_INFO_FLAG_WBEM_VALUEMAP or EVENTMAP_INFO_FLAG_WBEM_BITMAP flag to indicate that
			/// the MOF class property contains a BitValues or Values qualifier but does not contain the BitMap or ValueMap qualifier.
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

		/// <summary>Modes for processing events.</summary>
		[PInvokeData("Evntcons.h", MSDNShortId = "179451e9-7e3c-4d3a-bcc6-3ad9d382229a")]
		[Flags]
		public enum PROCESS_TRACE_MODE : uint
		{
			/// <summary>Specify this mode to receive events in real time (you must specify this mode if LoggerName is not NULL).</summary>
			PROCESS_TRACE_MODE_REAL_TIME = 0x00000100,

			/// <summary>
			/// Specify this mode if you do not want the time stamp value in the TimeStamp member of EVENT_HEADER and EVENT_TRACE_HEADER
			/// converted to system time (leaves the time stamp value in the resolution that the controller specified in the
			/// Wnode.ClientContext member of EVENT_TRACE_PROPERTIES). Prior to Windows Vista: Not supported.
			/// </summary>
			PROCESS_TRACE_MODE_RAW_TIMESTAMP = 0x00001000,

			/// <summary>
			/// Specify this mode if you want to receive events in the new EVENT_RECORD format. To receive events in the new format you must
			/// specify a callback in the EventRecordCallback member. If you do not specify this mode, you receive events in the old format
			/// through the callback specified in the EventCallback member. Prior to Windows Vista: Not supported.
			/// </summary>
			PROCESS_TRACE_MODE_EVENT_RECORD = 0x10000000,
		}

		/// <summary>Defines if the property is contained in a structure or array.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ne-tdh-property_flags typedef enum _PROPERTY_FLAGS { PropertyStruct,
		// PropertyParamLength, PropertyParamCount, PropertyWBEMXmlFragment, PropertyParamFixedLength, PropertyParamFixedCount,
		// PropertyHasTags, PropertyHasCustomSchema } PROPERTY_FLAGS;
		[PInvokeData("tdh.h", MSDNShortId = "517c1662-4230-44dc-94f0-a1996291bbee")]
		public enum PROPERTY_FLAGS
		{
			/// <summary>The property information is contained in the structType member of the EVENT_PROPERTY_INFO structure.</summary>
			PropertyStruct,

			/// <summary>
			/// Use the lengthPropertyIndex member of the EVENT_PROPERTY_INFO structure to locate the property that contains the length value
			/// of the property.
			/// </summary>
			PropertyParamLength,

			/// <summary>
			/// Use the countPropertyIndex member of the EVENT_PROPERTY_INFO structure to locate the property that contains the size of the array.
			/// </summary>
			PropertyParamCount,

			/// <summary>
			/// Indicates that the MOF data is in XML format (the event data contains within itself a fully-rendered XML description). This
			/// flag is set if the MOF property contains the XMLFragment qualifier.
			/// </summary>
			PropertyWBEMXmlFragment,

			/// <summary>
			/// Indicates that the length member of the EVENT_PROPERTY_INFO structure contains a fixed length, e.g. as specified in the
			/// provider manifest with &lt;data length="12" … /&gt;. This flag will not be set for a variable-length field, e.g. &lt;data
			/// length="LengthField" … /&gt;, nor will this flag be set for fields where the length is not specified in the manifest, e.g.
			/// int32 or null-terminated string. As an example, if PropertyParamLength is unset, length is 0, and InType is
			/// TDH_INTYPE_UNICODESTRING, we must check the PropertyParamFixedLength flag to determine the length of the string. If
			/// PropertyParamFixedLength is set, the string length is fixed at 0. If PropertyParamFixedLength is unset, the string is null-terminated.
			/// </summary>
			PropertyParamFixedLength,

			/// <summary>
			/// Indicates that the count member of the EVENT_PROPERTY_INFO structure contains a fixed array count, e.g. as specified in the
			/// provider manifest with &lt;data count="12" … /&gt;. This flag will not be set for a variable-length array, e.g. &lt;data
			/// count="ArrayCount" … /&gt;, nor will this flag be set for non-array fields. As an example, if PropertyParamCount is unset and
			/// count is 1, PropertyParamFixedCount flag must be checked to determine whether the field is a scalar value or a single-element
			/// array. If PropertyParamFixedCount is set, the field is a single-element array. If PropertyParamFixedCount is unset, the field
			/// is a scalar value, not an array.
			/// </summary>
			PropertyParamFixedCount,

			/// <summary>Indicates that the Tags field contains valid field tag data.</summary>
			PropertyHasTags,

			/// <summary>Indicates that the Type is described with a custom schema.</summary>
			PropertyHasCustomSchema,
		}

		/// <summary>Defines the context type.</summary>
		/// <remarks>
		/// If you are specifying context information for a legacy ETW event, you only need to specify the TDH_CONTEXT_POINTERSIZE type—the
		/// other types are used for WPP events and are ignored for legacy ETW events.
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
			/// Null-terminated Unicode string that contains the path to the .tmf file. You do not have to specify this path if the search
			/// path contains the file. Only specify this context information if you also specify the TDH_CONTEXT_WPP_TMFFILE context type.
			/// If the file is not found, TDH searches the following locations in the given order:
			/// </summary>
			TDH_CONTEXT_WPP_TMFSEARCHPATH,

			/// <summary>
			/// A 1-byte Boolean flag that indicates if the WPP event time stamp should be converted to Universal Time Coordinate (UTC). If
			/// 1, the time stamp is converted to UTC. If 0, the time stamp is in local time. By default, the time stamp is in local time.
			/// </summary>
			TDH_CONTEXT_WPP_GMT,

			/// <summary>
			/// Size, in bytes, of the pointer data types or size_t data types used in the event. Indicates if the event used 4-byte or
			/// 8-byte values. By default, the pointer size is the pointer size of the decoding computer. To determine the size of the
			/// pointer or size_t value, use the PointerSize member of TRACE_LOGFILE_HEADER (the first event you receive in your
			/// EventRecordCallback callback contains this header in the data section). However, this value may not be accurate. For example,
			/// on a 64-bit computer, a 32-bit application will log 4-byte pointers; however, the session will set PointerSize to 8.
			/// </summary>
			TDH_CONTEXT_POINTERSIZE,

			/// <summary>
			/// Null-terminated Unicode string that contains the name of the .pdb file for the binary that contains WPP messages. This
			/// parameter can be used as an alternative to TDH_CONTEXT_WPP_TMFFILE or TDH_CONTEXT_WPP_TMFSEARCHPATH.
			/// </summary>
			TDH_CONTEXT_PDB_PATH,
		}

		/// <summary>Provider-defined value that specifies the level of information the event generates.</summary>
		[PInvokeData("evntrace.h", MSDNShortId = "d75f18e1-e5fa-4039-bb74-76dea334b0fd")]
		public enum TRACE_LEVEL : byte
		{
			/// <summary>Abnormal exit or termination events</summary>
			TRACE_LEVEL_CRITICAL = 1,

			/// <summary>Severe error events</summary>
			TRACE_LEVEL_ERROR = 2,

			/// <summary>Warning events such as allocation failures</summary>
			TRACE_LEVEL_WARNING = 3,

			/// <summary>Non-error events such as entry or exit events</summary>
			TRACE_LEVEL_INFORMATION = 4,

			/// <summary>Detailed trace events</summary>
			TRACE_LEVEL_VERBOSE = 5,
		}

		/// <summary>Adds additional information to the beginning of the provider-specific data section of the event.</summary>
		[PInvokeData("Evntrace.h", MSDNShortId = "5d81c851-d47e-43f8-97b0-87156f36119a")]
		[Flags]
		public enum TRACE_MESSAGE : uint
		{
			/// <summary>
			/// Include a sequence number in the message. The sequence number starts at one. To use this flag, the controller must have set
			/// the EVENT_TRACE_USE_GLOBAL_SEQUENCE or EVENT_TRACE_USE_LOCAL_SEQUENCE log file mode when creating the session.
			/// </summary>
			TRACE_MESSAGE_SEQUENCE = 1,

			/// <summary>
			/// Include the event trace class GUID in the message. The MessageGuid parameter contains the event trace class GUID.
			/// </summary>
			TRACE_MESSAGE_GUID = 2,

			/// <summary>Include the component identifier in the message. The MessageGuid parameter contains the component identifier.</summary>
			TRACE_MESSAGE_COMPONENTID = 4,

			/// <summary>Include a time stamp in the message.</summary>
			TRACE_MESSAGE_TIMESTAMP = 8,

			TRACE_MESSAGE_PERFORMANCE_TIMESTAMP = 16,

			/// <summary>Include the thread identifier and process identifier in the message.</summary>
			TRACE_MESSAGE_SYSTEMINFO = 32,

			TRACE_MESSAGE_POINTER32 = 0x0040,
			TRACE_MESSAGE_POINTER64 = 0x0080,
			TRACE_MESSAGE_FLAG_MASK = 0xFFFF,
		}

		/// <summary>Flags used by <c>TRACE_PROVIDER_INSTANCE_INFO</c>.</summary>
		[PInvokeData("evntrace.h", MSDNShortId = "49c11cd5-2cb1-474a-8b51-2d86b4501da1")]
		public enum TRACE_PROVIDER_FLAG
		{
			/// <summary>The provider used RegisterTraceGuids instead of EventRegister to register itself.</summary>
			TRACE_PROVIDER_FLAG_LEGACY = 1,

			/// <summary>The provider is not registered; however, one or more sessions have enabled the provider.</summary>
			TRACE_PROVIDER_FLAG_PRE_ENABLE
		}

		/// <summary>Determines the type of information to include with the trace.</summary>
		/// <remarks>
		/// The <c>TRACE_INFO_CLASS</c> and <c>TRACE_QUERY_INFO_CLASS</c> enumerations both define the same values. Use both enumerations
		/// with the EnumerateTraceGuidsEx function or the TraceSetInformation function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntrace/ne-evntrace-trace_query_info_class typedef enum
		// _TRACE_QUERY_INFO_CLASS { TraceGuidQueryList, TraceGuidQueryInfo, TraceGuidQueryProcess, TraceStackTracingInfo,
		// TraceSystemTraceEnableFlagsInfo, TraceSampledProfileIntervalInfo, TraceProfileSourceConfigInfo, TraceProfileSourceListInfo,
		// TracePmcEventListInfo, TracePmcCounterListInfo, TraceSetDisallowList, TraceVersionInfo, TraceGroupQueryList, TraceGroupQueryInfo,
		// TraceDisallowListQuery, TraceInfoReserved15, TracePeriodicCaptureStateListInfo, TracePeriodicCaptureStateInfo,
		// TraceProviderBinaryTracking, TraceMaxLoggersQuery, MaxTraceSetInfoClass, TraceLbrConfigurationInfo, TraceLbrEventListInfo,
		// TraceMaxPmcCounterQuery } TRACE_QUERY_INFO_CLASS, TRACE_INFO_CLASS;
		[PInvokeData("evntrace.h", MSDNShortId = "b163e120-454a-48ba-93a9-71351fc3f2c2")]
		public enum TRACE_QUERY_INFO_CLASS
		{
			/// <summary>Query an array of GUIDs of the providers that are registered on the computer.</summary>
			[CorrespondingType(typeof(Guid[]), CorrespondingAction.Get)]
			TraceGuidQueryList,

			/// <summary>Query information that each session used to enable the provider.</summary>
			[CorrespondingType(typeof(TRACE_GUID_INFO), CorrespondingAction.Get)]
			TraceGuidQueryInfo,

			/// <summary>Query an array of GUIDs of the providers that registered themselves in the same process as the calling process.</summary>
			[CorrespondingType(typeof(Guid[]), CorrespondingAction.Get)]
			TraceGuidQueryProcess,

			/// <summary>
			/// Query the setting for call stack tracing for kernel events. The value is supported on Windows 7, Windows Server 2008 R2, and later.
			/// </summary>
			[CorrespondingType(typeof(CLASSIC_EVENT_ID[]), CorrespondingAction.Set)]
			TraceStackTracingInfo,

			/// <summary>
			/// Query the setting for the EnableFlags for the system trace provider. For more information, see the EVENT_TRACE_PROPERTIES
			/// structure. The value is supported on Windows 8, Windows Server 2012, and later.
			/// </summary>
			[CorrespondingType(typeof(EVENT_TRACE_FLAG[]), CorrespondingAction.Set)]
			TraceSystemTraceEnableFlagsInfo,

			/// <summary>
			/// Queries the setting for the sampling profile interval for the supplied source. The value is supported on Windows 8, Windows
			/// Server 2012, and later.
			/// </summary>
			[CorrespondingType(typeof(TRACE_PROFILE_INTERVAL), CorrespondingAction.GetSet)]
			TraceSampledProfileIntervalInfo,

			/// <summary>Sets a list of sources to be used for PMC Profiling system-wide.</summary>
			[CorrespondingType(typeof(uint[]), CorrespondingAction.Set)]
			TraceProfileSourceConfigInfo,

			/// <summary>
			/// Query the setting for sampled profile list information. The value is supported on Windows 8, Windows Server 2012, and later.
			/// </summary>
			[CorrespondingType(typeof(PROFILE_SOURCE_INFO[]), CorrespondingAction.Get)]
			TraceProfileSourceListInfo,

			/// <summary>
			/// Query the setting for sampled profile list information. The value is supported on Windows 8, Windows Server 2012, and later.
			/// </summary>
			[CorrespondingType(typeof(CLASSIC_EVENT_ID[]), CorrespondingAction.Set)]
			TracePmcEventListInfo,

			/// <summary>
			/// Query the list of performance monitoring counters to collect The value is supported on Windows 8, Windows Server 2012, and later.
			/// </summary>
			[CorrespondingType(typeof(uint[]), CorrespondingAction.Set)]
			TracePmcCounterListInfo,

			// TraceSetDisallowList:
			// - TraceSetInformation Sets a list of provider GUIDs that should not be enabled via Provider Groups on the specified logging session.
			//
			// Input Format: An array of GUIDs.
			[CorrespondingType(typeof(Guid[]), CorrespondingAction.Set)]
			TraceSetDisallowList = 10,

			// TraceVersionInfo:
			// - TraceQueryInformation Queries the version number of the trace processing code.
			//
			// Output Format: TRACE_VERSION_INFO
			/// <summary>Query the trace file version information. The value is supported on Windows 10.</summary>
			[CorrespondingType(typeof(TRACE_VERSION_INFO), CorrespondingAction.Get)]
			TraceVersionInfo,

			// TraceGroupQueryList:
			// - EnumerateTraceGuidsEx. Returns a list of Group GUIDs that are currently known to the kernel.
			//
			// Input Format: None. Output Format: An array of GUIDs.
			[CorrespondingType(typeof(Guid[]), CorrespondingAction.Get)]
			TraceGroupQueryList,

			// TraceGroupQueryInfo:
			// - EnumerateTraceGuidsEx. Returns the current enablement information and list of member providers for the input Group GUID.
			//
			// Input Format: GUID Output Format: a) ULONG - Length of the following TRACE_ENABLE_INFO array.
			// b) Array of TRACE_ENABLE_INFO. Size of the array is inferred from (a)
			// c) ULONG - Count of the Number of Unique Providers that belong to this Group
			// d) Array of GUID - Size of the array is specified by (c)
			//
			// PseudoStructure - struct TRACE_GROUP_INFO { ULONG TraceEnableInfoSize; TRACE_ENABLE_INFO
			// TraceEnableInfos[TraceEnableInfoSize]; ULONG GuidArraySize; GUID UniqueProviders[GuidArraySize]; }
			[CorrespondingType(typeof(IntPtr), CorrespondingAction.Get)]
			TraceGroupQueryInfo,

			// TraceDisallowListQuery:
			// - TraceQueryInformation Queries the list of provider GUIDs that should not be enabled via Provider Groups on the specified
			// logging session.
			//
			// Output Format: An array of GUIDs.
			[CorrespondingType(typeof(Guid[]), CorrespondingAction.Get)]
			TraceDisallowListQuery,

			TraceInfoReserved15,

			// TracePeriodicCaptureStateListInfo:
			// - TraceSetInformation Sets the list of providers for which capture stat should be collected at periodic time intervals for the
			// specified logging session. If a NULL input buffer is specified, then the current periodic capture state settings are cleared.
			//
			// Input Format: TRACE_PERIODIC_CAPTURE_STATE_INFO followed by an array of ProviderCount Provider GUIDs. Or a NULL Buffer.
			[CorrespondingType(typeof(TRACE_PERIODIC_CAPTURE_STATE_INFO), CorrespondingAction.Set)]
			TracePeriodicCaptureStateListInfo,

			// TracePeriodicCaptureStatInfo:
			// - TraceQueryInformation Queries the limits of periodic capture settings on this system, including the minimum time frequency
			// and the maximum number of providers that can be enabled for periodic capture state.
			//
			// Output Format: TRACE_PERIODIC_CAPTURE_STATE_INFO
			[CorrespondingType(typeof(TRACE_PERIODIC_CAPTURE_STATE_INFO), CorrespondingAction.Get)]
			TracePeriodicCaptureStateInfo,

			// TraceProviderBinaryTracking:
			// - TraceSetInformation Instructs ETW to begin tracking binaries for all providers that are enabled to the session. The tracking
			// applies retroactively for providers that were enabled to the session prior to the call, as well as for all future providers
			// that are enabled to the session.
			//
			// ETW fabricates tracking events for these tracked providers that contain a mapping between provider GUID(s). ETW also
			// fabricates the file path that describes where the registered provider is located on disk. If the session is in realtime, the
			// events are provided live in the realtime buffers. If the session is file-based (i.e. trace is saved to an .etl file), the
			// events are aggregated and written to the file header; they will be among some of the first events the ETW runtime provides
			// when the .etl file is played back.
			//
			// The binary tracking events will come from the EventTraceGuid provider, with an opcode of WMI_LOG_TYPE_BINARY_PATH.
			//
			// Input Format: BOOLEAN (The 1-byte type, rather than the 4-byte BOOL.) True to turn tracking on. False to turn tracking off.
			[CorrespondingType(typeof(byte), CorrespondingAction.Set)]
			TraceProviderBinaryTracking,

			// TraceMaxLoggersQuery:
			// - TraceQueryInformation Queries the maximum number of system-wide loggers that can be running at a time on this system.
			//
			// Output Format: ULONG
			/// <summary>
			/// Queries the currently-configured maximum number of system loggers allowed by the operating system. Returns a ULONG. Used with
			/// EnumerateTraceGuidsEx. The value is supported on Windows 10, version 1709 and later.
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
			TraceMaxLoggersQuery,

			// TraceLbrConfigurationInfo:
			// - TraceSetInformation Sets a bitfield of configuration options for Last Branch Record tracing.
			//
			// Input Format: ULONG
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			TraceLbrConfigurationInfo,

			// TraceLbrEventListInfo:
			// - TraceSetInformation Provides a list of kernel events to collect Last Branch Records on. The events are specified by their HookIds.
			//
			// Input Format: An array of ULONGs
			[CorrespondingType(typeof(uint[]), CorrespondingAction.Set)]
			TraceLbrEventListInfo,

			// TraceMaxPmcCounterQuery:
			// - TraceQueryInformation Queries the maximum number of PMC counters supported on this platform
			//
			// Output Format: ULONG
			[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
			TraceMaxPmcCounterQuery,
		}

		/// <summary>Specific rights for WMI guid objects.</summary>
		[PInvokeData("evntcons.h", MSDNShortId = "699bb165-680f-4d3b-8859-959f319ca4be")]
		[Flags]
		public enum TRACELOG_RIGHTS : uint
		{
			/// <summary>Allows the user to query information about the trace session. Set this permission on the session's GUID.</summary>
			WMIGUID_QUERY = 0x0001,

			/// <summary></summary>
			WMIGUID_SET = 0x0002,

			/// <summary></summary>
			WMIGUID_NOTIFICATION = 0x0004,

			/// <summary></summary>
			WMIGUID_READ_DESCRIPTION = 0x0008,

			/// <summary></summary>
			WMIGUID_EXECUTE = 0x0010,

			/// <summary>Allows the user to start or update a real-time session. Set this permission on the session's GUID.</summary>
			TRACELOG_CREATE_REALTIME = 0x0020,

			/// <summary>
			/// Allows the user to start or update a session that writes events to a log file. Set this permission on the session's GUID.
			/// </summary>
			TRACELOG_CREATE_ONDISK = 0x0040,

			/// <summary>Allows the user to enable the provider. Set this permission on the provider's GUID.</summary>
			TRACELOG_GUID_ENABLE = 0x0080,

			/// <summary>Not used.</summary>
			TRACELOG_ACCESS_KERNEL_LOGGER = 0x0100,

			/// <summary>
			/// Allows the user to log events to a trace session if session is running in SECURE mode (the session set the
			/// EVENT_TRACE_SECURE_MODE flag in the LogFileMode member of EVENT_TRACE_PROPERTIES).
			/// </summary>
			TRACELOG_LOG_EVENT = 0x0200,

			/// <summary></summary>
			TRACELOG_CREATE_INPROC = 0x0200,

			/// <summary>Allows a user to consume events in real-time. Set this permission on the session's GUID.</summary>
			TRACELOG_ACCESS_REALTIME = 0x0400,

			/// <summary>Allows the user to register the provider. Set this permission on the provider's GUID.</summary>
			TRACELOG_REGISTER_GUIDS = 0x0800,

			/// <summary></summary>
			TRACELOG_JOIN_GROUP = 0x1000,
		}

		/// <summary>Request code.</summary>
		[PInvokeData("wmistr.h")]
		public enum WMIDPREQUESTCODE
		{
			WMI_GET_ALL_DATA = 0,
			WMI_GET_SINGLE_INSTANCE = 1,
			WMI_SET_SINGLE_INSTANCE = 2,
			WMI_SET_SINGLE_ITEM = 3,

			/// <summary>Enables the provider.</summary>
			WMI_ENABLE_EVENTS = 4,

			/// <summary>Disables the provider.</summary>
			WMI_DISABLE_EVENTS = 5,

			WMI_ENABLE_COLLECTION = 6,
			WMI_DISABLE_COLLECTION = 7,
			WMI_REGINFO = 8,
			WMI_EXECUTE_METHOD = 9,
			WMI_CAPTURE_STATE = 10
		}

		[Flags]
		public enum WNODE_FLAG : uint
		{
			WNODE_FLAG_ALL_DATA = 0x00000001,
			WNODE_FLAG_SINGLE_INSTANCE = 0x00000002,
			WNODE_FLAG_SINGLE_ITEM = 0x00000004,
			WNODE_FLAG_EVENT_ITEM = 0x00000008,
			WNODE_FLAG_FIXED_INSTANCE_SIZE = 0x00000010,
			WNODE_FLAG_TOO_SMALL = 0x00000020,
			WNODE_FLAG_INSTANCES_SAME = 0x00000040,
			WNODE_FLAG_STATIC_INSTANCE_NAMES = 0x00000080,
			WNODE_FLAG_INTERNAL = 0x00000100,
			WNODE_FLAG_USE_TIMESTAMP = 0x00000200,
			WNODE_FLAG_PERSIST_EVENT = 0x00000400,
			WNODE_FLAG_EVENT_REFERENCE = 0x00002000,
			WNODE_FLAG_ANSI_INSTANCENAMES = 0x00004000,
			WNODE_FLAG_METHOD_ITEM = 0x00008000,
			WNODE_FLAG_PDO_INSTANCE_NAMES = 0x00010000,
			WNODE_FLAG_TRACED_GUID = 0x00020000,
			WNODE_FLAG_LOG_WNODE = 0x00040000,
			WNODE_FLAG_USE_GUID_PTR = 0x00080000,
			WNODE_FLAG_USE_MOF_PTR = 0x00100000,
			WNODE_FLAG_NO_HEADER = 0x00200000,
			WNODE_FLAG_SEND_DATA_BLOCK = 0x00400000,
			WNODE_FLAG_VERSIONED_PROPERTIES = 0x00800000,
			WNODE_FLAG_SEVERITY_MASK = 0xff000000,
		}

		/// <summary>The <c>CloseTrace</c> function closes a trace.</summary>
		/// <param name="TraceHandle">Handle to the trace to close. The <c>OpenTrace</c> function returns this handle.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BUSY</term>
		/// <term>Prior to Windows Vista, you cannot close the trace until the ProcessTrace function completes.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_CTX_CLOSE_PENDING</term>
		/// <term>
		/// The call was successful. The ProcessTrace function will stop after it has processed all real-time events in its buffers (it will
		/// not receive any new events).
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Consumers call this function.</para>
		/// <para>
		/// If you are processing events from a log file, you call this function only after the <c>ProcessTrace</c> function returns.
		/// However, if you are processing real-time events, you can call this function before <c>ProcessTrace</c> returns. If you call this
		/// function before <c>ProcessTrace</c> returns, the <c>CloseTrace</c> function returns ERROR_CTX_CLOSE_PENDING. The
		/// ERROR_CTX_CLOSE_PENDING code indicates that the <c>CloseTrace</c> function call was successful; the <c>ProcessTrace</c> function
		/// will stop processing events after it processes all events in its buffers ( <c>ProcessTrace</c> will not receive any new events
		/// after you call the <c>CloseTrace</c> function). You can call the <c>CloseTrace</c> function from your BufferCallback,
		/// EventCallback, or EventClassCallback callback.
		/// </para>
		/// <para><c>Prior to Windows Vista:</c> You can call <c>CloseTrace</c> only after <c>ProcessTrace</c> returns.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/etw/closetrace ULONG CloseTrace( _In_ TRACEHANDLE TraceHandle );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntrace.h", MSDNShortId = "25f4c4d3-0b70-40fe-bf03-8f9ffd82fbec")]
		public static extern Win32Error CloseTrace(TRACEHANDLE TraceHandle);

		/// <summary>The <c>ControlTrace</c> function flushes, queries, updates, or stops the specified event tracing session.</summary>
		/// <param name="SessionHandle">
		/// Handle to an event tracing session, or <c>NULL</c>. You must specify SessionHandle if SessionName is <c>NULL</c>. However, ETW
		/// ignores the handle if SessionName is not <c>NULL</c>. The handle is returned by the <c>StartTrace</c> function.
		/// </param>
		/// <param name="SessionName">
		/// <para>Name of an event tracing session, or <c>NULL</c>. You must specify SessionName if SessionHandle is <c>NULL</c>.</para>
		/// <para>To specify the NT Kernel Logger session, set SessionName to <c>KERNEL_LOGGER_NAME</c>.</para>
		/// </param>
		/// <param name="Properties">
		/// <para>Pointer to an initialized <c>EVENT_TRACE_PROPERTIES</c> structure. This structure should be zeroed out before it is used.</para>
		/// <para>
		/// If ControlCode specifies <c>EVENT_TRACE_CONTROL_STOP</c>, <c>EVENT_TRACE_CONTROL_QUERY</c> or <c>EVENT_TRACE_CONTROL_FLUSH</c>,
		/// you only need to set the <c>Wnode.BufferSize</c>, <c>Wnode.Guid</c>, <c>LoggerNameOffset</c>, and <c>LogFileNameOffset</c>
		/// members of the <c>EVENT_TRACE_PROPERTIES</c> structure. If the session is a private session, you also need to set
		/// <c>LogFileMode</c>. You can use the maximum session name (1024 characters) and maximum log file name (1024 characters) lengths to
		/// calculate the buffer size and offsets if not known.
		/// </para>
		/// <para>
		/// If ControlCode specifies <c>EVENT_TRACE_CONTROL_UPDATE</c>, on input, the members must specify the new values for the properties
		/// to update. On output, Properties contains the properties and statistics for the event tracing session. You can update the
		/// following properties.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Member</term>
		/// <term>Use</term>
		/// </listheader>
		/// <item>
		/// <term>EnableFlags</term>
		/// <term>
		/// Set this member to 0 to disable all kernel providers. Otherwise, you must specify the kernel providers that you want to enable or
		/// keep enabled. Applies only to NT Kernel Logger sessions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FlushTimer</term>
		/// <term>
		/// Set this member if you want to change the time to wait before flushing buffers. If this member is 0, the member is not updated.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LogFileNameOffset</term>
		/// <term>
		/// Set this member if you want to switch to another log file. If this member is 0, the file name is not updated. If the offset is
		/// not zero and you do not change the log file name, the function returns an error.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LogFileMode</term>
		/// <term>
		/// Set this member if you want to turn EVENT_TRACE_REAL_TIME_MODE on and off. To turn real time consuming off, set this member to 0.
		/// To turn real time consuming on, set this member to EVENT_TRACE_REAL_TIME_MODE and it will be OR'd with the current modes.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MaximumBuffers</term>
		/// <term>
		/// Set this member if you want to change the maximum number of buffers that ETW uses. If this member is 0, the member is not updated.
		/// </term>
		/// </item>
		/// </list>
		/// <para>For private logger sessions, you can update only the <c>LogFileNameOffset</c> and <c>FlushTimer</c> members.</para>
		/// <para>
		/// If you are using a newly initialized <c>EVENT_TRACE_PROPERTIES</c> structure, the only members you need to specify, other than
		/// the members you are updating, are <c>Wnode.BufferSize</c>, <c>Wnode.Guid</c>, and <c>Wnode.Flags</c>.
		/// </para>
		/// <para>
		/// If you use the property structure you passed to <c>StartTrace</c>, make sure the <c>LogFileNameOffset</c> member is 0 unless you
		/// are changing the log file name.
		/// </para>
		/// <para>
		/// If you call the <c>ControlTrace</c> function to query the current session properties and then update those properties to update
		/// the session, make sure you set <c>LogFileNameOffset</c> to 0 (unless you are changing the log file name) and set
		/// <c>EVENT_TRACE_PROPERTIES.Wnode.Flags</c> to <c>WNODE_FLAG_TRACED_GUID</c>.
		/// </para>
		/// <para>
		/// <c>Starting with Windows 10, version 1703:</c> For better performance in cross process scenarios, you can now pass filtering in
		/// to <c>ControlTrace</c> for system wide private loggers. You will need to pass in the new <c>EVENT_TRACE_PROPERTIES_V2</c>
		/// structure to include filtering information. See Configuring and Starting a Private Logger Session for more details.
		/// </para>
		/// </param>
		/// <param name="ControlCode">
		/// <para>Requested control function. You can specify one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>EVENT_TRACE_CONTROL_FLUSH</term>
		/// <term>
		/// Flushes the session's active buffers. Typically, you do not need to flush buffers yourself. However, you may want to flush
		/// buffers if the event rate is low and you are delivering events in real time. Windows 2000: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>EVENT_TRACE_CONTROL_QUERY</term>
		/// <term>Retrieves session properties and statistics.</term>
		/// </item>
		/// <item>
		/// <term>EVENT_TRACE_CONTROL_STOP</term>
		/// <term>Stops the session. The session handle is no longer valid.</term>
		/// </item>
		/// <item>
		/// <term>EVENT_TRACE_CONTROL_UPDATE</term>
		/// <term>Updates the session properties.</term>
		/// </item>
		/// </list>
		/// <para>Note that it is not safe to flush buffers or stop a trace session from DllMain.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_LENGTH</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_PATHNAME</term>
		/// <term>Another session is already using the file name specified by the LogFileNameOffset member of the Properties structure.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>
		/// The buffer for EVENT_TRACE_PROPERTIES is too small to hold all the information for the session. If you do not need the session's
		/// property information, you can ignore this error. If you receive this error when stopping the session, ETW will have already
		/// stopped the session before generating this error.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Only users running with elevated administrative privileges, users in the Performance Log Users group, and services running as
		/// LocalSystem, LocalService, NetworkService can control event tracing sessions. To grant a restricted user the ability to control
		/// trace sessions, add them to the Performance Log Users group. Only users with administrative privileges and services running as
		/// LocalSystem can control an NT Kernel Logger session. Windows XP and Windows 2000: Anyone can control a trace session.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_WMI_INSTANCE_NOT_FOUND</term>
		/// <term>The given session is not running.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Event trace controllers call this function.</para>
		/// <para>This function supersedes the <c>FlushTrace</c>, <c>QueryTrace</c>, <c>StopTrace</c>, and <c>UpdateTrace</c> functions.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/controltrace ULONG ControlTrace( _In_ TRACEHANDLE SessionHandle, _In_ LPCTSTR
		// SessionName, _Inout_ PEVENT_TRACE_PROPERTIES Properties, _In_ ULONG ControlCode );
		[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("evntrace.h", MSDNShortId = "c39f669c-ff40-40ed-ba47-798474ec2de4")]
		public static extern Win32Error ControlTrace([Optional] TRACEHANDLE SessionHandle, [Optional] string SessionName, ref EVENT_TRACE_PROPERTIES Properties, EVENT_TRACE_CONTROL ControlCode);

		/// <summary>
		/// The <c>CreateTraceInstanceId</c> function creates a unique transaction identifier and maps it to a class GUID registration
		/// handle. You then use the transaction identifier when calling the TraceEventInstance function.
		/// </summary>
		/// <param name="RegHandle">
		/// Handle to a registered event trace class. The RegisterTraceGuids function returns this handle in the <c>RegHandle</c> member of
		/// the TRACE_GUID_REGISTRATION structure.
		/// </param>
		/// <param name="InstInfo">
		/// Pointer to an EVENT_INSTANCE_INFO structure. The <c>InstanceId</c> member of this structure contains the transaction identifier.
		/// </param>
		/// <returns>
		/// <para>If the function is successful, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Providers call this function.</para>
		/// <para>
		/// ETW creates the identifier in the user-mode process, thus it can return the same number for different processes. The value starts
		/// over at one when <c>InstanceId</c> reaches the maximum value for a <c>ULONG</c>. Only user-mode providers can call the
		/// <c>CreateTraceInstanceId</c> function; drivers cannot call this function.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses <c>CreateTraceInstanceId</c>, see Tracing Event Instances.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntrace/nf-evntrace-createtraceinstanceid ULONG WMIAPI
		// CreateTraceInstanceId( HANDLE RegHandle, PEVENT_INSTANCE_INFO InstInfo );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntrace.h", MSDNShortId = "ab890392-f1e4-4b4e-a46c-8c7c2bfd3897")]
		public static extern Win32Error CreateTraceInstanceId(HANDLE RegHandle, ref EVENT_INSTANCE_INFO InstInfo);

		/// <summary>
		/// <para>Enables or disables the specified classic event trace provider.</para>
		/// <para>On Windows Vista and later, call the <c>EnableTraceEx</c> function to enable or disable a provider.</para>
		/// </summary>
		/// <param name="Enable">If <c>TRUE</c>, the provider is enabled; otherwise, the provider is disabled.</param>
		/// <param name="EnableFlag">
		/// <para>
		/// Provider-defined value that specifies the class of events for which the provider generates events. A provider that generates only
		/// one class of events will typically ignore this flag. If the provider is more complex, the provider could use the TraceGuidReg
		/// parameter of <c>RegisterTraceGuids</c> to register more than one class of events. For example, if the provider has a database
		/// component, a UI component, and a general processing component, the provider could register separate event classes for these
		/// components. This would then allow the controller the ability to turn on tracing in only the database component.
		/// </para>
		/// <para>The provider calls <c>GetTraceEnableFlags</c> from its ControlCallback function to obtain the enable flags.</para>
		/// </param>
		/// <param name="EnableLevel">
		/// <para>
		/// Provider-defined value that specifies the level of information the event generates. For example, you can use this value to
		/// indicate the severity level of the events (informational, warning, error) you want the provider to generate.
		/// </para>
		/// <para>
		/// Specify a value from zero to 255. ETW defines the following severity levels that you can use. Higher numbers imply that you get
		/// lower levels as well. For example, if you specify TRACE_LEVEL_WARNING, you also receive all warning, error, and fatal events.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRACE_LEVEL_CRITICAL 1</term>
		/// <term>Abnormal exit or termination events</term>
		/// </item>
		/// <item>
		/// <term>TRACE_LEVEL_ERROR 2</term>
		/// <term>Severe error events</term>
		/// </item>
		/// <item>
		/// <term>TRACE_LEVEL_WARNING 3</term>
		/// <term>Warning events such as allocation failures</term>
		/// </item>
		/// <item>
		/// <term>TRACE_LEVEL_INFORMATION 4</term>
		/// <term>Non-error events such as entry or exit events</term>
		/// </item>
		/// <item>
		/// <term>TRACE_LEVEL_VERBOSE 5</term>
		/// <term>Detailed trace events</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ControlGuid">GUID of the event trace provider that you want to enable or disable.</param>
		/// <param name="SessionHandle">
		/// Handle of the event tracing session to which you want to enable, disable, or change the logging level of the provider. The
		/// <c>StartTrace</c> function returns this handle.
		/// </param>
		/// <returns>
		/// <para>If the function is successful, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_FUNCTION</term>
		/// <term>You cannot change the enable flags and level when the provider is not registered.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_WMI_GUID_NOT_FOUND</term>
		/// <term>
		/// The provider is not registered. Occurs when KB307331 or Windows 2000 Service Pack 4 is installed and the provider is not
		/// registered. To avoid this error, the provider must first be registered.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SYSTEM_RESOURCES</term>
		/// <term>Exceeded the number of trace sessions that can enable the provider.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Only users with administrative privileges, users in the Performance Log Users group, and services running as LocalSystem,
		/// LocalService, NetworkService can enable trace providers. To grant a restricted user the ability to enable a trace provider, add
		/// them to the Performance Log Users group or see EventAccessControl. Windows XP and Windows 2000: Anyone can enable a trace provider.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Event trace controllers call this function.</para>
		/// <para>
		/// Up to eight trace sessions can enable and receive events from the same manifest-based provider; however, only one trace session
		/// can enable a classic provider. If more than one session tried to enable a classic provider, the first session would stop
		/// receiving events when the second session enabled the same provider. For example, if Session A enabled Provider 1 and then Session
		/// B enabled Provider 1, only Session B would receive events from Provider 1.
		/// </para>
		/// <para>
		/// The provider remains enabled for the session until the session disables the provider. If the application that started the session
		/// ends without disabling the provider, the provider remains enabled.
		/// </para>
		/// <para>
		/// The <c>EnableTrace</c> function calls the <c>ControlCallback</c> function implemented by the event trace provider, if defined.
		/// The provider defines its interpretation of being enabled or disabled. Typically, if a provider has been enabled, it generates
		/// events, but while it is disabled, it does not. The <c>ControlCallback</c> function can call the <c>GetTraceEnableFlags</c>,
		/// <c>GetTraceEnableLevel</c>, and <c>GetTraceLoggerHandle</c> functions to obtain the values specified for the EnableFlag,
		/// EnableLevel, and SessionHandle parameters, respectively.
		/// </para>
		/// <para>
		/// You can call this function one time to enable a provider before the provider registers itself. After the provider registers
		/// itself, ETW calls the provider's <c>ControlCallback</c> function. If you try to enable the provider for multiple sessions before
		/// the provider registers itself, ETW will only enable the provider for the last session. For example, if you enable the provider to
		/// Session A and then enable the provider to Session B, when the provider registers itself, the provider is only enabled for Session B.
		/// </para>
		/// <para>
		/// You do not call <c>EnableTrace</c> to enable kernel providers. To enable kernel providers, set the <c>EnableFlags</c> member of
		/// <c>EVENT_TRACE_PROPERTIES</c> which you then pass to <c>StartTrace</c>. The <c>StartTrace</c> function enables the selected
		/// kernel providers.
		/// </para>
		/// <para>To determine the level and keywords used to enable a manifest-based provider, use one of the following commands:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Logman query providers</term>
		/// </item>
		/// <item>
		/// <term>Wevtutil gp</term>
		/// </item>
		/// </list>
		/// <para>
		/// For classic providers, it is up to the provider to document and make available to potential controllers the severity levels or
		/// enable flags that it supports. If the provider wants to be enabled by any controller, the provider should accept 0 for the
		/// severity level and enable flags and interpret 0 as a request to perform default logging (whatever that may be).
		/// </para>
		/// <para>If you use <c>EnableTrace</c> to enable a manifest-based provider, the following translation occurs:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The EnableLevel parameter is the same as setting the Level parameter in <c>EnableTraceEx</c>.</term>
		/// </item>
		/// <item>
		/// <term>The EnableFlag is the same as setting the MatchAnyKeyword parameter in <c>EnableTraceEx</c>.</term>
		/// </item>
		/// <item>
		/// <term>
		/// In the <c>EnableCallback</c> callback, the SourceId parameter will be <c>NULL</c>, Level will be set to the value in
		/// <c>EnableTrace</c>, MatchAnyKeyword will be set to the value of EnableFlag in <c>EventTrace</c>, MatchAllKeyword will be 0, and
		/// FilterData will be <c>NULL</c>.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// On Windows 8.1,Windows Server 2012 R2, and later, payload filters can be used by the <c>EnableTraceEx2</c> function to filter on
		/// specific conditions in a logger session.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/enabletrace
		[PInvokeData("evntrace.h", MSDNShortId = "d75f18e1-e5fa-4039-bb74-76dea334b0fd")]
		public static Win32Error EnableTrace(bool Enable, uint EnableFlag, TRACE_LEVEL EnableLevel, in Guid ControlGuid, TRACEHANDLE SessionHandle) =>
			InternalEnableTrace(Enable, EnableFlag, (uint)EnableLevel, ControlGuid, SessionHandle);

		/// <summary>
		/// <para>Enables or disables the specified event trace provider.</para>
		/// <para>The <c>EnableTraceEx2</c> function supersedes this function.</para>
		/// </summary>
		/// <param name="ProviderId">GUID of the event trace provider that you want to enable or disable.</param>
		/// <param name="SourceId">
		/// GUID that uniquely identifies the session that is enabling or disabling the provider. Can be <c>NULL</c>. If the provider does
		/// not implement <c>EnableCallback</c>, the GUID is not used.
		/// </param>
		/// <param name="TraceHandle">
		/// Handle of the event tracing session to which you want to enable or disable the provider. The <c>StartTrace</c> function returns
		/// this handle.
		/// </param>
		/// <param name="IsEnabled">
		/// Set to 1 to receive events when the provider is registered; otherwise, set to 0 to no longer receive events from the provider.
		/// </param>
		/// <param name="Level">
		/// Provider-defined value that specifies the level of detail included in the event. Specify one of the following levels that are
		/// defined in Winmeta.h. Higher numbers imply that you get lower levels as well. For example, if you specify TRACE_LEVEL_WARNING,
		/// you also receive all warning, error, and critical events.
		/// </param>
		/// <param name="MatchAnyKeyword">
		/// Bitmask of keywords that determine the category of events that you want the provider to write. The provider writes the event if
		/// any of the event's keyword bits match any of the bits set in this mask. See Remarks.
		/// </param>
		/// <param name="MatchAllKeyword">
		/// This bitmask is optional. This mask further restricts the category of events that you want the provider to write. If the event's
		/// keyword meets the MatchAnyKeyword condition, the provider will write the event only if all of the bits in this mask exist in the
		/// event's keyword. This mask is not used if MatchAnyKeyword is zero. See Remarks.
		/// </param>
		/// <param name="EnableProperty">
		/// Optional information that ETW can include when writing the event. The data is written to the <c>extended data item</c> section of
		/// the event. To include the optional information, specify one or more of the following flags; otherwise, set to zero.
		/// </param>
		/// <param name="EnableFilterDesc">
		/// <para>
		/// An <c>EVENT_FILTER_DESCRIPTOR</c> structure that points to the filter data. The provider uses to filter data to prevent events
		/// that match the filter criteria from being written to the session; the provider determines the layout of the data and how it
		/// applies the filter to the event's data. A session can pass only one filter to the provider.
		/// </para>
		/// <para>A session can call the <c>TdhEnumerateProviderFilters</c> function to determine the filters that it can pass to the provider.</para>
		/// </param>
		/// <returns>
		/// <para>If the function is successful, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_FUNCTION</term>
		/// <term>You cannot update the level when the provider is not registered.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SYSTEM_RESOURCES</term>
		/// <term>Exceeded the number of trace sessions that can enable the provider.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Only users with administrative privileges, users in the Performance Log Users group, and services running as LocalSystem,
		/// LocalService, NetworkService can enable trace providers. To grant a restricted user the ability to enable a trace provider, add
		/// them to the Performance Log Users group or see EventAccessControl. Windows XP and Windows 2000: Anyone can enable a trace provider.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Event trace controllers call this function.</para>
		/// <para>
		/// The provider defines its interpretation of being enabled or disabled. Typically, if a provider has been enabled, it generates
		/// events, but while it is disabled, it does not.
		/// </para>
		/// <para>
		/// To include all events that a provider provides, set MatchAnyKeyword to zero (for a manifest-based provider and 0xFFFFFFFF for a
		/// classic provider). To include specific events, set the MatchAnyKeyword mask to those specific events. For example, if the
		/// provider defines an event for its initialization and cleanup routines (set keyword bit 0), an event for its file operations (set
		/// keyword bit 1), and an event for its calculation operations (set keyword bit 2), you can set MatchAnyKeyword to 5 to receive
		/// initialization and cleanup events and calculation events.
		/// </para>
		/// <para>
		/// If the provider defines more complex event keywords, for example, the provider defines an event that sets bit 0 for read and bit
		/// 1 for local access and a second event that sets bit 0 for read and bit 2 for remote access, you could set MatchAnyKeyword to 1 to
		/// receive all read events, or you could set MatchAnykeyword to 1 and MatchAllKeywords to 3 to receive local reads only.
		/// </para>
		/// <para>
		/// If an event's keyword is zero, the provider will write the event to the session, regardless of the MatchAnyKeyword and
		/// MatchAllKeyword masks.
		/// </para>
		/// <para>
		/// When you call <c>EnableTraceEx</c> the provider may or may not be registered. If the provider is registered, ETW calls the
		/// provider's callback function, if it implements one, and the session begins receiving events. If the provider is not registered,
		/// ETW will call the provider's callback function when it registers itself, if it implements one, and the session will begin
		/// receiving events. If the provider is not registered, the provider's callback function will not receive the source ID or filter
		/// data. You can call <c>EnableTraceEx</c> one time to enable a provider before the provider registers itself.
		/// </para>
		/// <para>
		/// If the provider is registered and already enabled to your session, you can also use this function to update the Level,
		/// MatchAnyKeyword, MatchAllKeyword, EnableProperty and EnableFilterDesc parameters that determine which events the provider writes.
		/// </para>
		/// <para>
		/// You do not call <c>EnableTraceEx</c> to enable kernel providers. To enable kernel providers, set the <c>EnableFlags</c> member of
		/// <c>EVENT_TRACE_PROPERTIES</c> which you then pass to <c>StartTrace</c>. The <c>StartTrace</c> function enables the selected
		/// kernel providers.
		/// </para>
		/// <para>
		/// Up to eight trace sessions can enable and receive events from the same manifest-based provider; however, only one trace session
		/// can enable a classic provider. If more than one session tried to enable a classic provider, the first session would stop
		/// receiving events when the second session enabled the same provider. For example, if Session A enabled Provider 1 and then Session
		/// B enabled Provider 1, only Session B would receive events from Provider 1.
		/// </para>
		/// <para>
		/// The provider remains enabled for the session until the session disables the provider. If the application that started the session
		/// ends without disabling the provider, the provider remains enabled.
		/// </para>
		/// <para>To determine the level and keywords used to enable a manifest-based provider, use one of the following commands:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Logman query providers</term>
		/// </item>
		/// <item>
		/// <term>Wevtutil gp</term>
		/// </item>
		/// </list>
		/// <para>
		/// For classic providers, it is up to the provider to document and make available to potential controllers the severity levels or
		/// enable flags that it supports. If the provider wants to be enabled by any controller, the provider should accept 0 for the
		/// severity level and enable flags and interpret 0 as a request to perform default logging (whatever that may be).
		/// </para>
		/// <para>If you use <c>EnableTraceEx</c> to enable a classic provider, the following translation occurs:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The Level parameter is the same as setting the EnableLevel parameter in <c>EnableTrace</c>.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The MatchAnyKeyword is the same as setting the EnableFlag parameter in <c>EnableTrace</c> except that the keyword value is
		/// truncated from a ULONGLONG to a ULONG value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// In the ControlCallback callback, the provider can call <c>GetTraceEnableLevel</c> to get the level and <c>GetTraceEnableFlags</c>
		/// to get the enable flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The other parameter are not used.</term>
		/// </item>
		/// </list>
		/// <para>
		/// A provider can define filters that a session uses to filter events based on event data. With the level and keywords that you
		/// provide, ETW determines whether the event is written to the session but with filters, the provider uses the filter data to
		/// determine whether it writes the event to the session. For example, if the provider generates process events, it could define a
		/// data filter that filters process events based on the process identifier. If the identifier of the process did not match the
		/// identifier that you passed as filter data, the provider would prevent event from being written to your session.
		/// </para>
		/// <para>
		/// On Windows 8.1,Windows Server 2012 R2, and later, payload filters can be used by the <c>EnableTraceEx2</c> function to filter on
		/// specific conditions in a logger session.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/enabletraceex-func ULONG EnableTraceEx( _In_ LPCGUID ProviderId, _In_opt_
		// LPCGUID SourceId, _In_ TRACEHANDLE TraceHandle, _In_ ULONG IsEnabled, _In_ UCHAR Level, _In_ ULONGLONG MatchAnyKeyword, _In_
		// ULONGLONG MatchAllKeyword, _In_ ULONG EnableProperty, _In_opt_ PEVENT_FILTER_DESCRIPTOR EnableFilterDesc );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntrace.h", MSDNShortId = "1c675bf7-f292-49b1-8b60-720499a497fd")]
		public static extern Win32Error EnableTraceEx(in Guid ProviderId, [Optional] IntPtr SourceId, TRACEHANDLE TraceHandle, [MarshalAs(UnmanagedType.Bool)] bool IsEnabled, TRACE_LEVEL Level, [Optional] ulong MatchAnyKeyword, [Optional] ulong MatchAllKeyword, [Optional] uint EnableProperty, [Optional] IntPtr EnableFilterDesc);

		/// <summary>
		/// <para>Enables or disables the specified event trace provider.</para>
		/// <para>The <c>EnableTraceEx2</c> function supersedes this function.</para>
		/// </summary>
		/// <param name="ProviderId">GUID of the event trace provider that you want to enable or disable.</param>
		/// <param name="SourceId">
		/// GUID that uniquely identifies the session that is enabling or disabling the provider. Can be <c>NULL</c>. If the provider does
		/// not implement <c>EnableCallback</c>, the GUID is not used.
		/// </param>
		/// <param name="TraceHandle">
		/// Handle of the event tracing session to which you want to enable or disable the provider. The <c>StartTrace</c> function returns
		/// this handle.
		/// </param>
		/// <param name="IsEnabled">
		/// Set to 1 to receive events when the provider is registered; otherwise, set to 0 to no longer receive events from the provider.
		/// </param>
		/// <param name="Level">
		/// Provider-defined value that specifies the level of detail included in the event. Specify one of the following levels that are
		/// defined in Winmeta.h. Higher numbers imply that you get lower levels as well. For example, if you specify TRACE_LEVEL_WARNING,
		/// you also receive all warning, error, and critical events.
		/// </param>
		/// <param name="MatchAnyKeyword">
		/// Bitmask of keywords that determine the category of events that you want the provider to write. The provider writes the event if
		/// any of the event's keyword bits match any of the bits set in this mask. See Remarks.
		/// </param>
		/// <param name="MatchAllKeyword">
		/// This bitmask is optional. This mask further restricts the category of events that you want the provider to write. If the event's
		/// keyword meets the MatchAnyKeyword condition, the provider will write the event only if all of the bits in this mask exist in the
		/// event's keyword. This mask is not used if MatchAnyKeyword is zero. See Remarks.
		/// </param>
		/// <param name="EnableProperty">
		/// Optional information that ETW can include when writing the event. The data is written to the <c>extended data item</c> section of
		/// the event. To include the optional information, specify one or more of the following flags; otherwise, set to zero.
		/// </param>
		/// <param name="EnableFilterDesc">
		/// <para>
		/// An <c>EVENT_FILTER_DESCRIPTOR</c> structure that points to the filter data. The provider uses to filter data to prevent events
		/// that match the filter criteria from being written to the session; the provider determines the layout of the data and how it
		/// applies the filter to the event's data. A session can pass only one filter to the provider.
		/// </para>
		/// <para>A session can call the <c>TdhEnumerateProviderFilters</c> function to determine the filters that it can pass to the provider.</para>
		/// </param>
		/// <returns>
		/// <para>If the function is successful, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_FUNCTION</term>
		/// <term>You cannot update the level when the provider is not registered.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SYSTEM_RESOURCES</term>
		/// <term>Exceeded the number of trace sessions that can enable the provider.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Only users with administrative privileges, users in the Performance Log Users group, and services running as LocalSystem,
		/// LocalService, NetworkService can enable trace providers. To grant a restricted user the ability to enable a trace provider, add
		/// them to the Performance Log Users group or see EventAccessControl. Windows XP and Windows 2000: Anyone can enable a trace provider.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Event trace controllers call this function.</para>
		/// <para>
		/// The provider defines its interpretation of being enabled or disabled. Typically, if a provider has been enabled, it generates
		/// events, but while it is disabled, it does not.
		/// </para>
		/// <para>
		/// To include all events that a provider provides, set MatchAnyKeyword to zero (for a manifest-based provider and 0xFFFFFFFF for a
		/// classic provider). To include specific events, set the MatchAnyKeyword mask to those specific events. For example, if the
		/// provider defines an event for its initialization and cleanup routines (set keyword bit 0), an event for its file operations (set
		/// keyword bit 1), and an event for its calculation operations (set keyword bit 2), you can set MatchAnyKeyword to 5 to receive
		/// initialization and cleanup events and calculation events.
		/// </para>
		/// <para>
		/// If the provider defines more complex event keywords, for example, the provider defines an event that sets bit 0 for read and bit
		/// 1 for local access and a second event that sets bit 0 for read and bit 2 for remote access, you could set MatchAnyKeyword to 1 to
		/// receive all read events, or you could set MatchAnykeyword to 1 and MatchAllKeywords to 3 to receive local reads only.
		/// </para>
		/// <para>
		/// If an event's keyword is zero, the provider will write the event to the session, regardless of the MatchAnyKeyword and
		/// MatchAllKeyword masks.
		/// </para>
		/// <para>
		/// When you call <c>EnableTraceEx</c> the provider may or may not be registered. If the provider is registered, ETW calls the
		/// provider's callback function, if it implements one, and the session begins receiving events. If the provider is not registered,
		/// ETW will call the provider's callback function when it registers itself, if it implements one, and the session will begin
		/// receiving events. If the provider is not registered, the provider's callback function will not receive the source ID or filter
		/// data. You can call <c>EnableTraceEx</c> one time to enable a provider before the provider registers itself.
		/// </para>
		/// <para>
		/// If the provider is registered and already enabled to your session, you can also use this function to update the Level,
		/// MatchAnyKeyword, MatchAllKeyword, EnableProperty and EnableFilterDesc parameters that determine which events the provider writes.
		/// </para>
		/// <para>
		/// You do not call <c>EnableTraceEx</c> to enable kernel providers. To enable kernel providers, set the <c>EnableFlags</c> member of
		/// <c>EVENT_TRACE_PROPERTIES</c> which you then pass to <c>StartTrace</c>. The <c>StartTrace</c> function enables the selected
		/// kernel providers.
		/// </para>
		/// <para>
		/// Up to eight trace sessions can enable and receive events from the same manifest-based provider; however, only one trace session
		/// can enable a classic provider. If more than one session tried to enable a classic provider, the first session would stop
		/// receiving events when the second session enabled the same provider. For example, if Session A enabled Provider 1 and then Session
		/// B enabled Provider 1, only Session B would receive events from Provider 1.
		/// </para>
		/// <para>
		/// The provider remains enabled for the session until the session disables the provider. If the application that started the session
		/// ends without disabling the provider, the provider remains enabled.
		/// </para>
		/// <para>To determine the level and keywords used to enable a manifest-based provider, use one of the following commands:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Logman query providers</term>
		/// </item>
		/// <item>
		/// <term>Wevtutil gp</term>
		/// </item>
		/// </list>
		/// <para>
		/// For classic providers, it is up to the provider to document and make available to potential controllers the severity levels or
		/// enable flags that it supports. If the provider wants to be enabled by any controller, the provider should accept 0 for the
		/// severity level and enable flags and interpret 0 as a request to perform default logging (whatever that may be).
		/// </para>
		/// <para>If you use <c>EnableTraceEx</c> to enable a classic provider, the following translation occurs:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The Level parameter is the same as setting the EnableLevel parameter in <c>EnableTrace</c>.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The MatchAnyKeyword is the same as setting the EnableFlag parameter in <c>EnableTrace</c> except that the keyword value is
		/// truncated from a ULONGLONG to a ULONG value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// In the ControlCallback callback, the provider can call <c>GetTraceEnableLevel</c> to get the level and <c>GetTraceEnableFlags</c>
		/// to get the enable flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The other parameter are not used.</term>
		/// </item>
		/// </list>
		/// <para>
		/// A provider can define filters that a session uses to filter events based on event data. With the level and keywords that you
		/// provide, ETW determines whether the event is written to the session but with filters, the provider uses the filter data to
		/// determine whether it writes the event to the session. For example, if the provider generates process events, it could define a
		/// data filter that filters process events based on the process identifier. If the identifier of the process did not match the
		/// identifier that you passed as filter data, the provider would prevent event from being written to your session.
		/// </para>
		/// <para>
		/// On Windows 8.1,Windows Server 2012 R2, and later, payload filters can be used by the <c>EnableTraceEx2</c> function to filter on
		/// specific conditions in a logger session.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/enabletraceex-func ULONG EnableTraceEx( _In_ LPCGUID ProviderId, _In_opt_
		// LPCGUID SourceId, _In_ TRACEHANDLE TraceHandle, _In_ ULONG IsEnabled, _In_ UCHAR Level, _In_ ULONGLONG MatchAnyKeyword, _In_
		// ULONGLONG MatchAllKeyword, _In_ ULONG EnableProperty, _In_opt_ PEVENT_FILTER_DESCRIPTOR EnableFilterDesc );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntrace.h", MSDNShortId = "1c675bf7-f292-49b1-8b60-720499a497fd")]
		public static extern Win32Error EnableTraceEx(in Guid ProviderId, in Guid SourceId, TRACEHANDLE TraceHandle, [MarshalAs(UnmanagedType.Bool)] bool IsEnabled, TRACE_LEVEL Level, ulong MatchAnyKeyword, ulong MatchAllKeyword, uint EnableProperty, in EVENT_FILTER_DESCRIPTOR EnableFilterDesc);

		/// <summary>
		/// <para>The <c>EnableTraceEx2</c> function enables or disables the specified event trace provider.</para>
		/// <para>This function supersedes the <c>EnableTraceEx</c> function.</para>
		/// </summary>
		/// <param name="TraceHandle">
		/// A handle of the event tracing session to which you want to enable or disable the provider. The <c>StartTrace</c> function returns
		/// this handle.
		/// </param>
		/// <param name="ProviderId">A GUID of the event trace provider that you want to enable or disable.</param>
		/// <param name="ControlCode">You can specify one of the following control codes:</param>
		/// <param name="Level">
		/// A provider-defined value that specifies the level of detail included in the event. Specify one of the following levels that are
		/// defined in the Winmeta.h header file. Higher numbers imply that you get lower levels as well. For example, if you specify
		/// TRACE_LEVEL_WARNING, you also receive all warning, error, and critical events.
		/// </param>
		/// <param name="MatchAnyKeyword">
		/// A bitmask of keywords that determine the category of events that you want the provider to write. The provider writes the event if
		/// any of the event's keyword bits match any of the bits set in this mask. See Remarks.
		/// </param>
		/// <param name="MatchAllKeyword">
		/// This bitmask is optional. This mask further restricts the category of events that you want the provider to write. If the event's
		/// keyword meets the MatchAnyKeyword condition, the provider will write the event only if all of the bits in this mask exist in the
		/// event's keyword. This mask is not used if MatchAnyKeyword is zero. See Remarks.
		/// </param>
		/// <param name="Timeout">
		/// Set to zero to enable the trace asynchronously; this is the default. If the timeout value is zero, this function calls the
		/// provider's enable callback and returns immediately. To enable the trace synchronously, specify a timeout value, in milliseconds.
		/// If you specify a timeout value, this function calls the provider's enable callback and waits until the callback exits or the
		/// timeout expires. To wait forever, set to INFINITE.
		/// </param>
		/// <param name="EnableParameters">
		/// The trace parameters used to enable the provider. For details, see <c>ENABLE_TRACE_PARAMETERS</c> and <c>ENABLE_TRACE_PARAMETERS_V1</c>.
		/// </param>
		/// <returns>
		/// <para>If the function is successful, the return value is <c>ERROR_SUCCESS</c>.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>A parameter is incorrect. This can occur if any of the following are true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_TIMEOUT</term>
		/// <term>The timeout value expired before the enable callback completed. For details, see the Timeout parameter.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_FUNCTION</term>
		/// <term>You cannot update the level when the provider is not registered.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SYSTEM_RESOURCES</term>
		/// <term>Exceeded the number of trace sessions that can enable the provider.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Only users with administrative privileges, users in the Performance Log Users group, and services running as LocalSystem,
		/// LocalService, or NetworkService can enable trace providers. To grant a restricted user the ability to enable a trace provider,
		/// add them to the Performance Log Users group or see EventAccessControl. Windows XP and Windows 2000: Anyone can enable a trace provider.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Event trace controllers call this function.</para>
		/// <para>
		/// The provider defines its interpretation of being enabled or disabled. Typically, if a provider has been enabled, it generates
		/// events, but while it is disabled, it does not.
		/// </para>
		/// <para>Event Tracing for Windows (ETW) supports several categories of filtering.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Schematized filtering - This is the traditional filtering setup also called provider-side filtering. The controller defines a
		/// custom set of filters as a binary object that is passed to the provider in the <c>EnableTrace</c> call. It is incumbent on the
		/// controller and provider to define and interpret these filters and the controller should only log applicable events. This requires
		/// a close coupling of the controller and provider since the type and format of the binary object of what can be filtered is not
		/// defined. The <c>TdhEnumerateProviderFilters</c> function can be used to retrieve the filters defined in a manifest.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Scope filtering - Certain providers are enabled or not enabled to a session based on whether or not they meet the criteria
		/// specified by the scope filters. There are several types of scope filters that allow filtering based on the event ID, the process
		/// ID (PID), executable filename, the app ID, and the app package name. This feature is supported on Windows 8.1,Windows Server 2012
		/// R2, and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Stackwalk filtering - This notifies ETW to only perform a stack walk for a given set of event IDs. This feature is supported on
		/// Windows 8.1,Windows Server 2012 R2, and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Event payload filtering - For manifest providers, events can be filtered on-the-fly based on whether or not they satisfy a
		/// logical expression based on one or more predicates.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Every time <c>EnableTraceEx2</c> is called, the filters for the provider in that session are replaced by the new parameters
		/// defined by the parameters passed to the <c>EnableTraceEx2</c> function. Multiple filters passed in a single <c>EnableTraceEx2</c>
		/// call can be combined with an additive effect. To disable filtering and thereby enable all providers/events in the logging
		/// session, call <c>EnableTraceEx2</c> with the EnableParameters parameter pointed to an <c>ENABLE_TRACE_PARAMETERS</c> structure
		/// with the <c>FilterDescCount</c> member set to 0.
		/// </para>
		/// <para>
		/// Each filter passed to the <c>EnableTraceEx2</c> function is specified by a <c>Type</c> member in the
		/// <c>EVENT_FILTER_DESCRIPTOR</c>. An array of <c>EVENT_FILTER_DESCRIPTOR</c> structures is passed in the
		/// <c>ENABLE_TRACE_PARAMETERS</c> structure passed in the <c>EnableParameters</c> parameter to the <c>EnableTraceEx2</c> function.
		/// </para>
		/// <para>
		/// Each type of filter (a specific <c>Type</c> member) may only appear once in a call to the <c>EnableTraceEx2</c> function,
		/// however, some filter types allow multiple conditions to be included in a single filter. The maximum number of filters that can be
		/// included in a call to <c>EnableTraceEx2</c> is set by <c>MAX_EVENT_FILTERS_COUNT</c> defined to be 8 in the Evntprov.h header file.
		/// </para>
		/// <para>
		/// Each filter type has its own size or entity limits based on the specific <c>Type</c> member in the <c>EVENT_FILTER_DESCRIPTOR</c>
		/// structure. The list below indicates these limits.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Term</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>EVENT_FILTER_TYPE_SCHEMATIZED</term>
		/// <term>Filter size limit: MAX_EVENT_FILTER_DATA_SIZE (1024) Number of elements allowed: Defined by provider and controller</term>
		/// </item>
		/// <item>
		/// <term>EVENT_FILTER_TYPE_PID</term>
		/// <term>Filter size limit: MAX_EVENT_FILTER_DATA_SIZE (1024) Number of elements allowed: MAX_EVENT_FILTER_PID_COUNT (8)</term>
		/// </item>
		/// <item>
		/// <term>EVENT_FILTER_TYPE_EXECUTABLE_NAME</term>
		/// <term>
		/// Filter size limit: MAX_EVENT_FILTER_DATA_SIZE (1024) Number of elements allowed: A single string that can contain multiple
		/// executable file names separated by semicolons.
		/// </term>
		/// </item>
		/// <item>
		/// <term>EVENT_FILTER_TYPE_PACKAGE_ID</term>
		/// <term>
		/// Filter size limit: MAX_EVENT_FILTER_DATA_SIZE (1024) Number of elements allowed: A single string that can contain multiple
		/// package IDs separated by semicolons.
		/// </term>
		/// </item>
		/// <item>
		/// <term>EVENT_FILTER_TYPE_PACKAGE_APP_ID</term>
		/// <term>
		/// Filter size limit: MAX_EVENT_FILTER_DATA_SIZE (1024) Number of elements allowed: A single string that can contain multiple
		/// package relative app IDs (PRAIDs) separated by semicolons.
		/// </term>
		/// </item>
		/// <item>
		/// <term>EVENT_FILTER_TYPE_PAYLOAD</term>
		/// <term>Filter size limit: 1MAX_EVENT_FILTER_PAYLOAD_SIZE (4096) Number of elements allowed: 1</term>
		/// </item>
		/// <item>
		/// <term>EVENT_FILTER_TYPE_EVENT_ID</term>
		/// <term>Filter size limit: Not defined Number of elements allowed: MAX_EVENT_FILTER_EVENT_ID_COUNT (64)</term>
		/// </item>
		/// <item>
		/// <term>EVENT_FILTER_TYPE_STACKWALK</term>
		/// <term>Filter size limit: Not defined Number of elements allowed: MAX_EVENT_FILTER_EVENT_ID_COUNT (64)</term>
		/// </item>
		/// </list>
		/// <para>
		/// To include all events that a provider provides, set MatchAnyKeyword to zero (for a manifest-based provider or TraceLogging
		/// provider and 0xFFFFFFFF for a classic provider). To include specific events, set the MatchAnyKeyword mask to those specific
		/// events. To indicate that you wish to enable a Provider Group, use the EVENT_ENABLE_PROPERTY_PROVIDER_GROUP flag on the
		/// <c>EnableProperty</c> member of EnableParameters. For example, if the provider defines an event for its initialization and
		/// cleanup routines (set keyword bit 0), an event for its file operations (set keyword bit 1), and an event for its calculation
		/// operations (set keyword bit 2), you can set MatchAnyKeyword to 5 to receive initialization and cleanup events and calculation events.
		/// </para>
		/// <para>
		/// If the provider defines more complex event keywords, for example, the provider defines an event that sets bit 0 for read and bit
		/// 1 for local access and a second event that sets bit 0 for read and bit 2 for remote access, you could set MatchAnyKeyword to 1 to
		/// receive all read events, or you could set MatchAnykeyword to 1 and MatchAllKeywords to 3 to receive local reads only.
		/// </para>
		/// <para>
		/// If an event's keyword is zero, the provider will write the event to the session, regardless of the MatchAnyKeyword and
		/// MatchAllKeyword masks.
		/// </para>
		/// <para>
		/// When you call <c>EnableTraceEx2</c> the provider may or may not be registered. If the provider is registered, ETW calls the
		/// provider's callback function, if it implements one, and the session begins receiving events. If the provider is not registered,
		/// ETW will call the provider's callback function when it registers itself, if it implements one, and the session will begin
		/// receiving events. If the provider is not registered, the provider's callback function will not receive the source ID or filter
		/// data. You can call <c>EnableTraceEx2</c> one time to enable a provider before the provider registers itself.
		/// </para>
		/// <para>
		/// If the provider is registered and already enabled to your session, you can also use this function to update the Level,
		/// MatchAnyKeyword, MatchAllKeyword parameters, and the <c>EnableProperty</c> and <c>EnableFilterDesc</c> members of EnableParameters.
		/// </para>
		/// <para>
		/// On Windows 8.1,Windows Server 2012 R2, and later, event payload , scope, and stack walk filters can be used by the
		/// <c>EnableTraceEx2</c> function and the <c>ENABLE_TRACE_PARAMETERS</c> and <c>EVENT_FILTER_DESCRIPTOR</c> structures to filter on
		/// specific conditions in a logger session. For more information on event payload filters, see the <c>TdhCreatePayloadFilter</c>,
		/// and <c>TdhAggregatePayloadFilters</c> functions and the <c>ENABLE_TRACE_PARAMETERS</c>, <c>EVENT_FILTER_DESCRIPTOR</c>, and
		/// <c>PAYLOAD_FILTER_PREDICATE</c> structures.
		/// </para>
		/// <para>
		/// You do not call <c>EnableTraceEx2</c> to enable kernel providers. To enable kernel providers, set the <c>EnableFlags</c> member
		/// of <c>EVENT_TRACE_PROPERTIES</c> which you then pass to <c>StartTrace</c>. The <c>StartTrace</c> function enables the selected
		/// kernel providers.
		/// </para>
		/// <para>
		/// Up to eight trace sessions can enable and receive events from the same manifest-based provider or TraceLogging provider; however,
		/// only one trace session can enable a classic provider. If more than one session tried to enable a classic provider, the first
		/// session would stop receiving events when the second session enabled the same provider. For example, if Session A enabled Provider
		/// 1 and then Session B enabled Provider 1, only Session B would receive events from Provider 1.
		/// </para>
		/// <para>
		/// The provider remains enabled for the session until the session disables the provider. If the application that started the session
		/// ends without disabling the provider, the provider remains enabled.
		/// </para>
		/// <para>To determine the level and keywords used to enable a manifest-based provider, use one of the following commands:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Logman query providers</term>
		/// </item>
		/// <item>
		/// <term>Wevtutil gp</term>
		/// </item>
		/// </list>
		/// <para>
		/// For classic providers, it is up to the provider to document and make available to potential controllers the severity levels or
		/// enable flags that it supports. If the provider wants to be enabled by any controller, the provider should accept 0 for the
		/// severity level and enable flags and interpret 0 as a request to perform default logging (whatever that may be).
		/// </para>
		/// <para>If you use <c>EnableTraceEx2</c> to enable a classic provider, the following translation occurs:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The Level parameter is the same as setting the EnableLevel parameter in <c>EnableTrace</c>.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The MatchAnyKeyword is the same as setting the EnableFlag parameter in <c>EnableTrace</c> except that the keyword value is
		/// truncated from a ULONGLONG to a ULONG value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// In the ControlCallback callback, the provider can call <c>GetTraceEnableLevel</c> to get the level and <c>GetTraceEnableFlags</c>
		/// to get the enable flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The other parameter are not used.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If <c>EnableTraceEx2</c> returns <c>ERROR_INVALID_PARAMETER</c> when enabling filtering, you can turn on tracing to view
		/// debugging messages about the failure. This requires a checked build.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/enabletraceex2 ULONG EnableTraceEx2( _In_ TRACEHANDLE TraceHandle, _In_
		// LPCGUID ProviderId, _In_ ULONG ControlCode, _In_ UCHAR Level, _In_ ULONGLONG MatchAnyKeyword, _In_ ULONGLONG MatchAllKeyword, _In_
		// ULONG Timeout, _In_opt_ PENABLE_TRACE_PARAMETERS EnableParameters );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntrace.h", MSDNShortId = "3aceffb6-614f-4cad-bbec-f181f0cbdbff")]
		public static extern Win32Error EnableTraceEx2(TRACEHANDLE TraceHandle, in Guid ProviderId, EVENT_CONTROL_CODE ControlCode, TRACE_LEVEL Level, ulong MatchAnyKeyword, ulong MatchAllKeyword, uint Timeout, in ENABLE_TRACE_PARAMETERS EnableParameters);

		/// <summary>
		/// <para>The <c>EnableTraceEx2</c> function enables or disables the specified event trace provider.</para>
		/// <para>This function supersedes the <c>EnableTraceEx</c> function.</para>
		/// </summary>
		/// <param name="TraceHandle">
		/// A handle of the event tracing session to which you want to enable or disable the provider. The <c>StartTrace</c> function returns
		/// this handle.
		/// </param>
		/// <param name="ProviderId">A GUID of the event trace provider that you want to enable or disable.</param>
		/// <param name="ControlCode">You can specify one of the following control codes:</param>
		/// <param name="Level">
		/// A provider-defined value that specifies the level of detail included in the event. Specify one of the following levels that are
		/// defined in the Winmeta.h header file. Higher numbers imply that you get lower levels as well. For example, if you specify
		/// TRACE_LEVEL_WARNING, you also receive all warning, error, and critical events.
		/// </param>
		/// <param name="MatchAnyKeyword">
		/// A bitmask of keywords that determine the category of events that you want the provider to write. The provider writes the event if
		/// any of the event's keyword bits match any of the bits set in this mask. See Remarks.
		/// </param>
		/// <param name="MatchAllKeyword">
		/// This bitmask is optional. This mask further restricts the category of events that you want the provider to write. If the event's
		/// keyword meets the MatchAnyKeyword condition, the provider will write the event only if all of the bits in this mask exist in the
		/// event's keyword. This mask is not used if MatchAnyKeyword is zero. See Remarks.
		/// </param>
		/// <param name="Timeout">
		/// Set to zero to enable the trace asynchronously; this is the default. If the timeout value is zero, this function calls the
		/// provider's enable callback and returns immediately. To enable the trace synchronously, specify a timeout value, in milliseconds.
		/// If you specify a timeout value, this function calls the provider's enable callback and waits until the callback exits or the
		/// timeout expires. To wait forever, set to INFINITE.
		/// </param>
		/// <param name="EnableParameters">
		/// The trace parameters used to enable the provider. For details, see <c>ENABLE_TRACE_PARAMETERS</c> and <c>ENABLE_TRACE_PARAMETERS_V1</c>.
		/// </param>
		/// <returns>
		/// <para>If the function is successful, the return value is <c>ERROR_SUCCESS</c>.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>A parameter is incorrect. This can occur if any of the following are true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_TIMEOUT</term>
		/// <term>The timeout value expired before the enable callback completed. For details, see the Timeout parameter.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_FUNCTION</term>
		/// <term>You cannot update the level when the provider is not registered.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SYSTEM_RESOURCES</term>
		/// <term>Exceeded the number of trace sessions that can enable the provider.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Only users with administrative privileges, users in the Performance Log Users group, and services running as LocalSystem,
		/// LocalService, or NetworkService can enable trace providers. To grant a restricted user the ability to enable a trace provider,
		/// add them to the Performance Log Users group or see EventAccessControl. Windows XP and Windows 2000: Anyone can enable a trace provider.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Event trace controllers call this function.</para>
		/// <para>
		/// The provider defines its interpretation of being enabled or disabled. Typically, if a provider has been enabled, it generates
		/// events, but while it is disabled, it does not.
		/// </para>
		/// <para>Event Tracing for Windows (ETW) supports several categories of filtering.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Schematized filtering - This is the traditional filtering setup also called provider-side filtering. The controller defines a
		/// custom set of filters as a binary object that is passed to the provider in the <c>EnableTrace</c> call. It is incumbent on the
		/// controller and provider to define and interpret these filters and the controller should only log applicable events. This requires
		/// a close coupling of the controller and provider since the type and format of the binary object of what can be filtered is not
		/// defined. The <c>TdhEnumerateProviderFilters</c> function can be used to retrieve the filters defined in a manifest.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Scope filtering - Certain providers are enabled or not enabled to a session based on whether or not they meet the criteria
		/// specified by the scope filters. There are several types of scope filters that allow filtering based on the event ID, the process
		/// ID (PID), executable filename, the app ID, and the app package name. This feature is supported on Windows 8.1,Windows Server 2012
		/// R2, and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Stackwalk filtering - This notifies ETW to only perform a stack walk for a given set of event IDs. This feature is supported on
		/// Windows 8.1,Windows Server 2012 R2, and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Event payload filtering - For manifest providers, events can be filtered on-the-fly based on whether or not they satisfy a
		/// logical expression based on one or more predicates.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Every time <c>EnableTraceEx2</c> is called, the filters for the provider in that session are replaced by the new parameters
		/// defined by the parameters passed to the <c>EnableTraceEx2</c> function. Multiple filters passed in a single <c>EnableTraceEx2</c>
		/// call can be combined with an additive effect. To disable filtering and thereby enable all providers/events in the logging
		/// session, call <c>EnableTraceEx2</c> with the EnableParameters parameter pointed to an <c>ENABLE_TRACE_PARAMETERS</c> structure
		/// with the <c>FilterDescCount</c> member set to 0.
		/// </para>
		/// <para>
		/// Each filter passed to the <c>EnableTraceEx2</c> function is specified by a <c>Type</c> member in the
		/// <c>EVENT_FILTER_DESCRIPTOR</c>. An array of <c>EVENT_FILTER_DESCRIPTOR</c> structures is passed in the
		/// <c>ENABLE_TRACE_PARAMETERS</c> structure passed in the <c>EnableParameters</c> parameter to the <c>EnableTraceEx2</c> function.
		/// </para>
		/// <para>
		/// Each type of filter (a specific <c>Type</c> member) may only appear once in a call to the <c>EnableTraceEx2</c> function,
		/// however, some filter types allow multiple conditions to be included in a single filter. The maximum number of filters that can be
		/// included in a call to <c>EnableTraceEx2</c> is set by <c>MAX_EVENT_FILTERS_COUNT</c> defined to be 8 in the Evntprov.h header file.
		/// </para>
		/// <para>
		/// Each filter type has its own size or entity limits based on the specific <c>Type</c> member in the <c>EVENT_FILTER_DESCRIPTOR</c>
		/// structure. The list below indicates these limits.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Term</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>EVENT_FILTER_TYPE_SCHEMATIZED</term>
		/// <term>Filter size limit: MAX_EVENT_FILTER_DATA_SIZE (1024) Number of elements allowed: Defined by provider and controller</term>
		/// </item>
		/// <item>
		/// <term>EVENT_FILTER_TYPE_PID</term>
		/// <term>Filter size limit: MAX_EVENT_FILTER_DATA_SIZE (1024) Number of elements allowed: MAX_EVENT_FILTER_PID_COUNT (8)</term>
		/// </item>
		/// <item>
		/// <term>EVENT_FILTER_TYPE_EXECUTABLE_NAME</term>
		/// <term>
		/// Filter size limit: MAX_EVENT_FILTER_DATA_SIZE (1024) Number of elements allowed: A single string that can contain multiple
		/// executable file names separated by semicolons.
		/// </term>
		/// </item>
		/// <item>
		/// <term>EVENT_FILTER_TYPE_PACKAGE_ID</term>
		/// <term>
		/// Filter size limit: MAX_EVENT_FILTER_DATA_SIZE (1024) Number of elements allowed: A single string that can contain multiple
		/// package IDs separated by semicolons.
		/// </term>
		/// </item>
		/// <item>
		/// <term>EVENT_FILTER_TYPE_PACKAGE_APP_ID</term>
		/// <term>
		/// Filter size limit: MAX_EVENT_FILTER_DATA_SIZE (1024) Number of elements allowed: A single string that can contain multiple
		/// package relative app IDs (PRAIDs) separated by semicolons.
		/// </term>
		/// </item>
		/// <item>
		/// <term>EVENT_FILTER_TYPE_PAYLOAD</term>
		/// <term>Filter size limit: 1MAX_EVENT_FILTER_PAYLOAD_SIZE (4096) Number of elements allowed: 1</term>
		/// </item>
		/// <item>
		/// <term>EVENT_FILTER_TYPE_EVENT_ID</term>
		/// <term>Filter size limit: Not defined Number of elements allowed: MAX_EVENT_FILTER_EVENT_ID_COUNT (64)</term>
		/// </item>
		/// <item>
		/// <term>EVENT_FILTER_TYPE_STACKWALK</term>
		/// <term>Filter size limit: Not defined Number of elements allowed: MAX_EVENT_FILTER_EVENT_ID_COUNT (64)</term>
		/// </item>
		/// </list>
		/// <para>
		/// To include all events that a provider provides, set MatchAnyKeyword to zero (for a manifest-based provider or TraceLogging
		/// provider and 0xFFFFFFFF for a classic provider). To include specific events, set the MatchAnyKeyword mask to those specific
		/// events. To indicate that you wish to enable a Provider Group, use the EVENT_ENABLE_PROPERTY_PROVIDER_GROUP flag on the
		/// <c>EnableProperty</c> member of EnableParameters. For example, if the provider defines an event for its initialization and
		/// cleanup routines (set keyword bit 0), an event for its file operations (set keyword bit 1), and an event for its calculation
		/// operations (set keyword bit 2), you can set MatchAnyKeyword to 5 to receive initialization and cleanup events and calculation events.
		/// </para>
		/// <para>
		/// If the provider defines more complex event keywords, for example, the provider defines an event that sets bit 0 for read and bit
		/// 1 for local access and a second event that sets bit 0 for read and bit 2 for remote access, you could set MatchAnyKeyword to 1 to
		/// receive all read events, or you could set MatchAnykeyword to 1 and MatchAllKeywords to 3 to receive local reads only.
		/// </para>
		/// <para>
		/// If an event's keyword is zero, the provider will write the event to the session, regardless of the MatchAnyKeyword and
		/// MatchAllKeyword masks.
		/// </para>
		/// <para>
		/// When you call <c>EnableTraceEx2</c> the provider may or may not be registered. If the provider is registered, ETW calls the
		/// provider's callback function, if it implements one, and the session begins receiving events. If the provider is not registered,
		/// ETW will call the provider's callback function when it registers itself, if it implements one, and the session will begin
		/// receiving events. If the provider is not registered, the provider's callback function will not receive the source ID or filter
		/// data. You can call <c>EnableTraceEx2</c> one time to enable a provider before the provider registers itself.
		/// </para>
		/// <para>
		/// If the provider is registered and already enabled to your session, you can also use this function to update the Level,
		/// MatchAnyKeyword, MatchAllKeyword parameters, and the <c>EnableProperty</c> and <c>EnableFilterDesc</c> members of EnableParameters.
		/// </para>
		/// <para>
		/// On Windows 8.1,Windows Server 2012 R2, and later, event payload , scope, and stack walk filters can be used by the
		/// <c>EnableTraceEx2</c> function and the <c>ENABLE_TRACE_PARAMETERS</c> and <c>EVENT_FILTER_DESCRIPTOR</c> structures to filter on
		/// specific conditions in a logger session. For more information on event payload filters, see the <c>TdhCreatePayloadFilter</c>,
		/// and <c>TdhAggregatePayloadFilters</c> functions and the <c>ENABLE_TRACE_PARAMETERS</c>, <c>EVENT_FILTER_DESCRIPTOR</c>, and
		/// <c>PAYLOAD_FILTER_PREDICATE</c> structures.
		/// </para>
		/// <para>
		/// You do not call <c>EnableTraceEx2</c> to enable kernel providers. To enable kernel providers, set the <c>EnableFlags</c> member
		/// of <c>EVENT_TRACE_PROPERTIES</c> which you then pass to <c>StartTrace</c>. The <c>StartTrace</c> function enables the selected
		/// kernel providers.
		/// </para>
		/// <para>
		/// Up to eight trace sessions can enable and receive events from the same manifest-based provider or TraceLogging provider; however,
		/// only one trace session can enable a classic provider. If more than one session tried to enable a classic provider, the first
		/// session would stop receiving events when the second session enabled the same provider. For example, if Session A enabled Provider
		/// 1 and then Session B enabled Provider 1, only Session B would receive events from Provider 1.
		/// </para>
		/// <para>
		/// The provider remains enabled for the session until the session disables the provider. If the application that started the session
		/// ends without disabling the provider, the provider remains enabled.
		/// </para>
		/// <para>To determine the level and keywords used to enable a manifest-based provider, use one of the following commands:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Logman query providers</term>
		/// </item>
		/// <item>
		/// <term>Wevtutil gp</term>
		/// </item>
		/// </list>
		/// <para>
		/// For classic providers, it is up to the provider to document and make available to potential controllers the severity levels or
		/// enable flags that it supports. If the provider wants to be enabled by any controller, the provider should accept 0 for the
		/// severity level and enable flags and interpret 0 as a request to perform default logging (whatever that may be).
		/// </para>
		/// <para>If you use <c>EnableTraceEx2</c> to enable a classic provider, the following translation occurs:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The Level parameter is the same as setting the EnableLevel parameter in <c>EnableTrace</c>.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The MatchAnyKeyword is the same as setting the EnableFlag parameter in <c>EnableTrace</c> except that the keyword value is
		/// truncated from a ULONGLONG to a ULONG value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// In the ControlCallback callback, the provider can call <c>GetTraceEnableLevel</c> to get the level and <c>GetTraceEnableFlags</c>
		/// to get the enable flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The other parameter are not used.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If <c>EnableTraceEx2</c> returns <c>ERROR_INVALID_PARAMETER</c> when enabling filtering, you can turn on tracing to view
		/// debugging messages about the failure. This requires a checked build.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/enabletraceex2 ULONG EnableTraceEx2( _In_ TRACEHANDLE TraceHandle, _In_
		// LPCGUID ProviderId, _In_ ULONG ControlCode, _In_ UCHAR Level, _In_ ULONGLONG MatchAnyKeyword, _In_ ULONGLONG MatchAllKeyword, _In_
		// ULONG Timeout, _In_opt_ PENABLE_TRACE_PARAMETERS EnableParameters );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntrace.h", MSDNShortId = "3aceffb6-614f-4cad-bbec-f181f0cbdbff")]
		public static extern Win32Error EnableTraceEx2(TRACEHANDLE TraceHandle, in Guid ProviderId, EVENT_CONTROL_CODE ControlCode, TRACE_LEVEL Level, [Optional] ulong MatchAnyKeyword, [Optional] ulong MatchAllKeyword, [Optional] uint Timeout, [Optional] IntPtr EnableParameters);

		/// <summary>
		/// The <c>EnumerateTraceGuids</c> function retrieves information about registered event trace providers that are running on the computer.
		/// </summary>
		/// <param name="GuidPropertiesArray">An array of pointers to <c>TRACE_GUID_PROPERTIES</c> structures.</param>
		/// <param name="PropertyArrayCount">Number of elements in the GuidPropertiesArray array.</param>
		/// <param name="GuidCount">Actual number of event tracing providers registered on the computer.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>
		/// The property array is too small to receive information for all registered providers (GuidCount is greater than
		/// PropertyArrayCount). The function fills the GUID property array with the number of structures specified in PropertyArrayCount.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Event trace controllers call this function.</para>
		/// <para>For information on registering event trace providers, see <c>RegisterTraceGuids</c>.</para>
		/// <para>
		/// You can use the <c>TRACE_GUID_PROPERTIES.LoggerId</c> member to determine which session enabled the provider if
		/// <c>TRACE_GUID_PROPERTIES.IsEnable</c> is <c>TRUE</c>.
		/// </para>
		/// <para>The list will not include kernel providers.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/enumeratetraceguids ULONG EnumerateTraceGuids( _Inout_ PTRACE_GUID_PROPERTIES
		// *GuidPropertiesArray, _In_ ULONG PropertyArrayCount, _Out_ PULONG GuidCount );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntrace.h", MSDNShortId = "9a9e2f53-9916-4a9c-a08e-c8affd5fc4c9")]
		public static extern Win32Error EnumerateTraceGuids([In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] GuidPropertiesArray, uint PropertyArrayCount, out uint GuidCount);

		/// <summary>Use this function to retrieve information about trace providers that are registered on the computer.</summary>
		/// <param name="TraceQueryInfoClass">
		/// Determines the type of information to include with the list of registered providers. For possible values, see the
		/// <c>TRACE_QUERY_INFO_CLASS</c> enumeration.
		/// </param>
		/// <param name="InBuffer">
		/// GUID of the provider or provider group whose information you want to retrieve. Specify the GUID only if TraceQueryInfoClass is
		/// <c>TraceGuidQueryInfo</c> or <c>TraceGroupQueryInfo</c>.
		/// </param>
		/// <param name="InBufferSize">Size, in bytes, of the data InBuffer.</param>
		/// <param name="OutBuffer">
		/// Application-allocated buffer that contains the enumerated information. The format of the information depends on the value of
		/// TraceQueryInfoClass. For details, see Remarks.
		/// </param>
		/// <param name="OutBufferSize">
		/// Size, in bytes, of the OutBuffer buffer. If the function succeeds, the ReturnLength parameter receives the size of the buffer
		/// used. If the buffer is too small, the function returns ERROR_INSUFFICIENT_BUFFER and the ReturnLength parameter receives the
		/// required buffer size. If the buffer size is zero on input, no data is returned in the buffer and the ReturnLength parameter
		/// receives the required buffer size.
		/// </param>
		/// <param name="ReturnLength">Actual size of the data in OutBuffer, in bytes.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The OutBuffer buffer is too small to receive information for all registered providers. Reallocate the buffer using the size
		/// returned in ReturnLength.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Event trace controllers call this function.</para>
		/// <para>
		/// If TraceQueryInfoClass is <c>TraceGuidQueryInfo</c>, ETW returns the data in a <c>TRACE_GUID_INFO</c> block that is a header to
		/// the information. The info block contains a <c>TRACE_PROVIDER_INSTANCE_INFO</c> block for each provider that uses the same GUID.
		/// Each instance info block contains a <c>TRACE_ENABLE_INFO</c> structure for each session that enabled the provider.
		/// </para>
		/// <para>For information on registering event trace providers, see <c>EventRegister</c> and <c>RegisterTraceGuids</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/enumeratetraceguidsex ULONG WINAPI EnumerateTraceGuidsEx( _In_
		// TRACE_QUERY_INFO_CLASS TraceQueryInfoClass, _In_ PVOID InBuffer, _In_ ULONG InBufferSize, _Out_ PVOID OutBuffer, _In_ ULONG
		// OutBufferSize, _Out_ PULONG ReturnLength );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntrace.h", MSDNShortId = "9d70fe21-1750-4d60-a825-2004f7d666c7")]
		public static extern Win32Error EnumerateTraceGuidsEx(TRACE_QUERY_INFO_CLASS TraceQueryInfoClass, IntPtr InBuffer, uint InBufferSize, IntPtr OutBuffer, uint OutBufferSize, out uint ReturnLength);

		/// <summary>Use this function to retrieve information about trace providers that are registered on the computer.</summary>
		/// <typeparam name="TOut">The type of the expected enumeration value that is output.</typeparam>
		/// <typeparam name="TIn">The type of the input value.</typeparam>
		/// <param name="TraceQueryInfoClass">
		/// Determines the type of information to include with the list of registered providers. For possible values, see the
		/// <c>TRACE_QUERY_INFO_CLASS</c> enumeration.
		/// </param>
		/// <param name="InBuffer">
		/// GUID of the provider or provider group whose information you want to retrieve. Specify the GUID only if TraceQueryInfoClass is
		/// <c>TraceGuidQueryInfo</c> or <c>TraceGroupQueryInfo</c>.
		/// </param>
		/// <returns>
		/// The enumerated information. The format of the information depends on the value of TraceQueryInfoClass. For details, see Remarks.
		/// </returns>
		/// <remarks>
		/// <para>Event trace controllers call this function.</para>
		/// <para>
		/// If TraceQueryInfoClass is <c>TraceGuidQueryInfo</c>, ETW returns the data in a <c>TRACE_GUID_INFO</c> block that is a header to
		/// the information. The info block contains a <c>TRACE_PROVIDER_INSTANCE_INFO</c> block for each provider that uses the same GUID.
		/// Each instance info block contains a <c>TRACE_ENABLE_INFO</c> structure for each session that enabled the provider.
		/// </para>
		/// <para>For information on registering event trace providers, see <c>EventRegister</c> and <c>RegisterTraceGuids</c>.</para>
		/// </remarks>
		[PInvokeData("evntrace.h", MSDNShortId = "9d70fe21-1750-4d60-a825-2004f7d666c7")]
		public static IEnumerable<TOut> EnumerateTraceGuidsEx<TOut, TIn>(TRACE_QUERY_INFO_CLASS TraceQueryInfoClass, in TIn InBuffer) where TOut : struct where TIn : struct
		{
			using (var buffer = EnumerateTraceGuidsEx<TIn>(TraceQueryInfoClass, InBuffer))
				return buffer.ToArray<TOut>(buffer.Size / Marshal.SizeOf(typeof(TOut)));
		}

		/// <summary>Use this function to retrieve information about trace providers that are registered on the computer.</summary>
		/// <typeparam name="TOut">The type of the expected enumeration value that is output.</typeparam>
		/// <param name="TraceQueryInfoClass">
		/// Determines the type of information to include with the list of registered providers. For possible values, see the
		/// <c>TRACE_QUERY_INFO_CLASS</c> enumeration.
		/// </param>
		/// <returns>
		/// The enumerated information. The format of the information depends on the value of TraceQueryInfoClass. For details, see Remarks.
		/// </returns>
		/// <remarks>
		/// <para>Event trace controllers call this function.</para>
		/// <para>
		/// If TraceQueryInfoClass is <c>TraceGuidQueryInfo</c>, ETW returns the data in a <c>TRACE_GUID_INFO</c> block that is a header to
		/// the information. The info block contains a <c>TRACE_PROVIDER_INSTANCE_INFO</c> block for each provider that uses the same GUID.
		/// Each instance info block contains a <c>TRACE_ENABLE_INFO</c> structure for each session that enabled the provider.
		/// </para>
		/// <para>For information on registering event trace providers, see <c>EventRegister</c> and <c>RegisterTraceGuids</c>.</para>
		/// </remarks>
		[PInvokeData("evntrace.h", MSDNShortId = "9d70fe21-1750-4d60-a825-2004f7d666c7")]
		public static IEnumerable<TOut> EnumerateTraceGuidsEx<TOut>(TRACE_QUERY_INFO_CLASS TraceQueryInfoClass) where TOut : struct
		{
			using (var buffer = EnumerateTraceGuidsEx<int>(TraceQueryInfoClass, null))
				return buffer.ToArray<TOut>(buffer.Size / Marshal.SizeOf(typeof(TOut)));
		}

		/// <summary>Use this function to retrieve information about trace providers that are registered on the computer.</summary>
		/// <typeparam name="TIn">The type of the input value.</typeparam>
		/// <param name="TraceQueryInfoClass">
		/// Determines the type of information to include with the list of registered providers. For possible values, see the
		/// <c>TRACE_QUERY_INFO_CLASS</c> enumeration.
		/// </param>
		/// <param name="InBuffer">
		/// GUID of the provider or provider group whose information you want to retrieve. Specify the GUID only if TraceQueryInfoClass is
		/// <c>TraceGuidQueryInfo</c> or <c>TraceGroupQueryInfo</c>.
		/// </param>
		/// <returns>
		/// The enumerated information as a memory allocation. The format of the information depends on the value of TraceQueryInfoClass. For
		/// details, see Remarks.
		/// </returns>
		/// <remarks>
		/// <para>Event trace controllers call this function.</para>
		/// <para>
		/// If TraceQueryInfoClass is <c>TraceGuidQueryInfo</c>, ETW returns the data in a <c>TRACE_GUID_INFO</c> block that is a header to
		/// the information. The info block contains a <c>TRACE_PROVIDER_INSTANCE_INFO</c> block for each provider that uses the same GUID.
		/// Each instance info block contains a <c>TRACE_ENABLE_INFO</c> structure for each session that enabled the provider.
		/// </para>
		/// <para>For information on registering event trace providers, see <c>EventRegister</c> and <c>RegisterTraceGuids</c>.</para>
		/// </remarks>
		[PInvokeData("evntrace.h", MSDNShortId = "9d70fe21-1750-4d60-a825-2004f7d666c7")]
		public static SafeHGlobalHandle EnumerateTraceGuidsEx<TIn>(TRACE_QUERY_INFO_CLASS TraceQueryInfoClass, TIn? InBuffer = null) where TIn : struct
		{
			using (var input = InBuffer.HasValue ? SafeHGlobalHandle.CreateFromStructure(InBuffer.Value) : SafeHGlobalHandle.Null)
			{
				var err = EnumerateTraceGuidsEx(TraceQueryInfoClass, input, input.Size, IntPtr.Zero, 0, out var sz);
				if (err != Win32Error.ERROR_INSUFFICIENT_BUFFER)
					throw err.GetException();
				var output = new SafeHGlobalHandle(sz);
				while ((err = EnumerateTraceGuidsEx(TraceQueryInfoClass, input, input.Size, output, output.Size, out sz)) == Win32Error.ERROR_INSUFFICIENT_BUFFER)
					output.Size = sz;
				if (err.Failed)
					throw err.GetException();
				return output;
			}
		}

		/// <summary>Adds or modifies the permissions of the specified provider or session.</summary>
		/// <param name="Guid">GUID that uniquely identifies the provider or session whose permissions you want to add or modify.</param>
		/// <param name="Operation">
		/// Type of operation to perform, for example, add a DACL to the session's GUID or provider's GUID. For possible values, see the
		/// EVENTSECURITYOPERATION enumeration.
		/// </param>
		/// <param name="Sid">The security identifier (SID) of the user or group to whom you want to grant or deny permissions.</param>
		/// <param name="Rights">You can specify one or more of the following permissions:</param>
		/// <param name="AllowOrDeny">
		/// If <c>TRUE</c>, grant the user permissions to the session or provider; otherwise, deny permissions. This value is ignored if the
		/// value of Operation is EventSecuritySetSACL or EventSecurityAddSACL.
		/// </param>
		/// <returns>Returns ERROR_SUCCESS if successful.</returns>
		/// <remarks>
		/// <para>
		/// By default, only the administrator of the computer, users in the Performance Log Users group, and services running as
		/// LocalSystem, LocalService, NetworkService can control trace sessions and provide and consume event data. Only users with
		/// administrative privileges and services running as LocalSystem can start and control an NT Kernel Logger session.
		/// </para>
		/// <para>
		/// <c>Windows Server 2003:</c> Only users with administrator privileges can control trace sessions and consume event data; any user
		/// can provide event data.
		/// </para>
		/// <para><c>Windows XP and Windows 2000:</c> Any user can control trace sessions and provide and consume event data.</para>
		/// <para>
		/// Users with administrator privileges can control trace sessions if the tool that they use to control the session is started from a
		/// Command Prompt window that is opened with <c>Run as administrator...</c>.
		/// </para>
		/// <para>
		/// To grant a restricted user the ability to control trace sessions, you can add them to the Performance Log Users group or call
		/// this function to grant them permission. For example, you can grant user A permission to start and stop a trace session and grant
		/// user B permission to only query the session.
		/// </para>
		/// <para>To restrict who can log events to the session, see the TRACELOG_LOG_EVENT permission.</para>
		/// <para>
		/// The ACL on the log file determines who can consume event data from the log file. To consume events from a session in real-time,
		/// you must grant the user TRACELOG_ACCESS_REALTIME permission or the user must be a member of the Performance Log Users group.
		/// </para>
		/// <para>You can also specify the provider's GUID to restrict who can register the provider and who can enable the provider.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntcons/nf-evntcons-eventaccesscontrol ULONG EVNTAPI EventAccessControl(
		// LPGUID Guid, ULONG Operation, PSID Sid, ULONG Rights, BOOLEAN AllowOrDeny );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntcons.h", MSDNShortId = "699bb165-680f-4d3b-8859-959f319ca4be")]
		public static extern Win32Error EventAccessControl(in Guid Guid, EVENTSECURITYOPERATION Operation, PSID Sid, TRACELOG_RIGHTS Rights, [MarshalAs(UnmanagedType.U1)] bool AllowOrDeny);

		/// <summary>Retrieves the permissions for the specified controller or provider.</summary>
		/// <param name="Guid">GUID that uniquely identifies the provider or session.</param>
		/// <param name="Buffer">Application-allocated buffer that will contain the security descriptor of the controller or provider.</param>
		/// <param name="BufferSize">
		/// Size of the security descriptor buffer, in bytes. If the function succeeds, this parameter receives the size of the buffer used.
		/// If the buffer is too small, the function returns ERROR_MORE_DATA and this parameter receives the required buffer size. If the
		/// buffer size is zero on input, no data is returned in the buffer and this parameter receives the required buffer size.
		/// </param>
		/// <returns>
		/// <para>Returns ERROR_SUCCESS if successful.</para>
		/// <para>The function returns the following return code if an error occurs:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>The buffer is too small to receive the security descriptor. Reallocate the buffer using the size returned in BufferSize.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the GUID does not exist in the registry, ETW returns the default permissions for a provider or controller. For details on
		/// specifying the GUID in the registry, see EventAccessControl.
		/// </para>
		/// <para>
		/// For information on accessing the components of the security descriptor, see Getting Information from an ACL, the
		/// GetSecurityDescriptorDacl, GetSecurityDescriptorSacl, and GetAce functions, and the ACE structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntcons/nf-evntcons-eventaccessquery ULONG EVNTAPI EventAccessQuery( LPGUID
		// Guid, PSECURITY_DESCRIPTOR Buffer, PULONG BufferSize );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntcons.h", MSDNShortId = "21c87137-0e8f-43d1-9dad-9f2b4fc591a3")]
		public static extern Win32Error EventAccessQuery(in Guid Guid, SafePSECURITY_DESCRIPTOR Buffer, ref uint BufferSize);

		/// <summary>Removes the permissions defined in the registry for the specified provider or session.</summary>
		/// <param name="Guid">GUID that uniquely identifies the provider or session whose permissions you want to remove from the registry.</param>
		/// <returns>Returns ERROR_SUCCESS if successful.</returns>
		/// <remarks>
		/// After removing the permission from the registry, the default permissions apply to the provider or session. For details on the
		/// default permissions, see EventAccessControl.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntcons/nf-evntcons-eventaccessremove ULONG EVNTAPI EventAccessRemove(
		// LPGUID Guid );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntcons.h", MSDNShortId = "9f25f163-046c-41b0-82f9-0b214b74b87e")]
		public static extern Win32Error EventAccessRemove(in Guid Guid);

		/// <summary>
		/// <para>
		/// The <c>FlushTrace</c> function causes an event tracing session to immediately deliver buffered events for the specified session.
		/// (An event tracing session does not deliver events until an active buffer is full.)
		/// </para>
		/// <para>The ControlTrace function supersedes this function.</para>
		/// </summary>
		/// <param name="TraceHandle">
		/// Handle to the event tracing session for whose buffers you want to flush, or <c>NULL</c>. You must specify SessionHandle if
		/// SessionName is <c>NULL</c>. However, ETW ignores the handle if SessionName is not <c>NULL</c>. The handle is returned by the
		/// StartTrace function.
		/// </param>
		/// <param name="InstanceName">
		/// <para>
		/// Pointer to a null-terminated string that specifies the name of the event tracing session whose buffers you want to flush, or
		/// <c>NULL</c>. You must specify SessionName if SessionHandle is <c>NULL</c>.
		/// </para>
		/// <para>To specify the NT Kernel Logger session, set SessionName to <c>KERNEL_LOGGER_NAME</c>.</para>
		/// </param>
		/// <param name="Properties">
		/// <para>Pointer to an initialized EVENT_TRACE_PROPERTIES structure.</para>
		/// <para>
		/// If you are using a newly initialized structure, you only need to set the <c>Wnode.BufferSize</c>, <c>Wnode.Guid</c>,
		/// <c>LoggerNameOffset</c>, and <c>LogFileNameOffset</c> members of the structure. You can use the maximum session name (1024
		/// characters) and maximum log file name (1024 characters) lengths to calculate the buffer size and offsets if not known.
		/// </para>
		/// <para>
		/// On output, the structure receives the property settings and session statistics of the event tracing session, which reflect the
		/// state of the session after the flush.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_LENGTH</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Only users with administrative privileges, users in the Performance Log Users group, and services running as LocalSystem,
		/// LocalService, NetworkService can control event tracing sessions. To grant a restricted user the ability to control trace
		/// sessions, add them to the Performance Log Users group. Windows XP and Windows 2000: Anyone can control a trace session.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Controllers call this function.</para>
		/// <para>
		/// Typically, you do not need to flush buffers yourself. However, you may want to flush buffers if the event rate is low and you are
		/// delivering events in real time.
		/// </para>
		/// <para>Note that it is not safe to flush buffers from DllMain.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntrace/nf-evntrace-flushtracea ULONG WMIAPI FlushTraceA( TRACEHANDLE
		// TraceHandle, LPCSTR InstanceName, PEVENT_TRACE_PROPERTIES Properties );
		[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("evntrace.h", MSDNShortId = "bc7d0dac-93d9-4614-9cb6-fee99765eb39")]
		public static extern Win32Error FlushTrace(TRACEHANDLE TraceHandle, string InstanceName, ref EVENT_TRACE_PROPERTIES Properties);

		/// <summary>
		/// <para>
		/// The <c>GetTraceEnableFlags</c> function retrieves the enable flags passed by the controller to indicate which category of events
		/// to trace.
		/// </para>
		/// <para>Providers can only call this function from their <c>ControlCallback</c> function.</para>
		/// </summary>
		/// <param name="SessionHandle">Handle to an event tracing session, obtained by calling the <c>GetTraceLoggerHandle</c> function.</param>
		/// <returns>
		/// <para>Returns the value the controller specified in the EnableFlag parameter when calling the <c>EnableTrace</c> function.</para>
		/// <para>To determine if the function failed or the controller set the enable flags to 0, follow these steps:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Call the <c>SetLastError</c> function to set the last error to <c>ERROR_SUCCESS</c>.</term>
		/// </item>
		/// <item>
		/// <term>Call the <c>GetTraceEnableFlags</c> function to retrieve the enable flags.</term>
		/// </item>
		/// <item>
		/// <term>If the enable flags value is 0, call the <c>GetLastError</c> function to retrieve the last known error.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If the last known error is <c>ERROR_SUCCESS</c>, the controller set the enable flags to 0; otherwise, the
		/// <c>GetTraceEnableFlags</c> function failed with the last known error.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Providers can use this value to control which events that it generates. For example, a provider can group events into logical
		/// categories of events and use this value to enable or disable their generation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/gettraceenableflags ULONG GetTraceEnableFlags( _In_ TRACEHANDLE SessionHandle );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Evntrace.h", MSDNShortId = "e5c0f2bf-34da-4555-9556-4c79ee9a73ab")]
		public static extern uint GetTraceEnableFlags(TRACEHANDLE SessionHandle);

		/// <summary>
		/// <para>
		/// The <c>GetTraceEnableLevel</c> function retrieves the severity level passed by the controller to indicate the level of logging
		/// the provider should perform.
		/// </para>
		/// <para>Providers can only call this function from their <c>ControlCallback</c> function.</para>
		/// </summary>
		/// <param name="SessionHandle">Handle to an event tracing session, obtained by calling the <c>GetTraceLoggerHandle</c> function.</param>
		/// <returns>
		/// <para>Returns the value the controller specified in the EnableLevel parameter when calling the <c>EnableTrace</c> function.</para>
		/// <para>To determine if the function failed or the controller set the enable flags to 0, follow these steps:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Call the <c>SetLastError</c> function to set the last error to <c>ERROR_SUCCESS</c>.</term>
		/// </item>
		/// <item>
		/// <term>Call the <c>GetTraceEnableLevel</c> function to retrieve the enable level.</term>
		/// </item>
		/// <item>
		/// <term>If the enable level value is 0, call the <c>GetLastError</c> function to retrieve the last known error.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If the last known error is <c>ERROR_SUCCESS</c>, the controller set the enable level to 0; otherwise, the
		/// <c>GetTraceEnableLevel</c> function failed with the last known error.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Providers use this value to control the severity of events that it generates. For example, providers can use this value to
		/// determine if it should generate informational, warning, or error events.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/gettraceenablelevel UCHAR GetTraceEnableLevel( _In_ TRACEHANDLE SessionHandle );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Evntrace.h", MSDNShortId = "22326fd9-c428-4430-8a92-978d005f6705")]
		public static extern TRACE_LEVEL GetTraceEnableLevel(TRACEHANDLE SessionHandle);

		/// <summary>
		/// <para>The <c>GetTraceLoggerHandle</c> function retrieves the handle of the event tracing session.</para>
		/// <para>Providers can only call this function from their <c>ControlCallback</c> function.</para>
		/// </summary>
		/// <param name="Buffer">
		/// <para>
		/// Pointer to a <c>WNODE_HEADER</c> structure. ETW passes this structure to the provider's <c>ControlCallback</c> function in the
		/// Buffer parameter.
		/// </para>
		/// <para>The <c>HistoricalContext</c> member of <c>WNODE_HEADER</c> contains the session's handle.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns the event tracing session handle.</para>
		/// <para>
		/// If the function fails, it returns <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call the <c>GetLastError</c> function.
		/// </para>
		/// </returns>
		/// <remarks>
		/// You use the handle when calling the <c>GetTraceEnableFlags</c> and <c>GetTraceEnableLevel</c> functions to retrieve the enable
		/// flags and level values passed to the <c>EnableTrace</c> function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/gettraceloggerhandle TRACEHANDLE GetTraceLoggerHandle( _In_ PVOID Buffer );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Evntrace.h", MSDNShortId = "050d3a01-0087-40f1-af35-b9ceeaf47813")]
		public static extern TRACEHANDLE GetTraceLoggerHandle(IntPtr Buffer);

		/// <summary>The <c>OpenTrace</c> function opens a real-time trace session or log file for consuming.</summary>
		/// <param name="Logfile">
		/// Pointer to an EVENT_TRACE_LOGFILE structure. The structure specifies the source from which to consume events (from a log file or
		/// the session in real time) and specifies the callbacks the consumer wants to use to receive the events.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a handle to the trace.</para>
		/// <para>If the function fails, it returns INVALID_PROCESSTRACE_HANDLE.</para>
		/// <para>
		/// <c>Note</c> If your code base supports Windows 7 and Windows Vista, and also supports earlier operating systems such as Windows
		/// XP and Windows Server 2003, do not use the constants described above. Instead, determine the operating system on which you are
		/// running and compare the return value to the following values.
		/// </para>
		/// <para>
		/// If the function returns INVALID_PROCESSTRACE_HANDLE, you can use the GetLastError function to obtain extended error information.
		/// The following table lists some common errors and their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The Logfile parameter is NULL.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_PATHNAME</term>
		/// <term>If you did not specify the LoggerName member of EVENT_TRACE_LOGFILE, you must specify a valid log file name.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Only users with administrative privileges, users in the Performance Log Users group, and services running as LocalSystem,
		/// LocalService, NetworkService can consume events in real time. To grant a restricted user the ability to consume events in real
		/// time, add them to the Performance Log Users group. Windows XP and Windows 2000: Anyone can consume real time events.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Consumers call this function.</para>
		/// <para>
		/// After calling <c>OpenTrace</c>, call the ProcessTrace function to process the events. When you have finished processing events,
		/// call the CloseTrace function.
		/// </para>
		/// <para>Note that you can process events from only one real-time session.</para>
		/// <para>
		/// Windows Vista and earlier: If the function fails it will returns INVALID_HANDLE_VALUE. To avoid compile-time errors, cast
		/// INVALID_HANDLE_VALUE to TRACEHANDLE as follows: .
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// For an example that uses <c>OpenTrace</c>, see Using TdhFormatProperty to Consume Event Data or Retrieving Event Data Using MOF.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntrace/nf-evntrace-opentracea TRACEHANDLE WMIAPI OpenTraceA(
		// PEVENT_TRACE_LOGFILEA Logfile );
		[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("evntrace.h", MSDNShortId = "505e643b-6b4f-4f93-96c8-7fe8abdd6234")]
		public static extern TRACEHANDLE OpenTrace(ref EVENT_TRACE_LOGFILE Logfile);

		/// <summary>The <c>ProcessTrace</c> function delivers events from one or more event tracing sessions to the consumer.</summary>
		/// <param name="HandleArray">
		/// <para>
		/// Pointer to an array of trace handles obtained from earlier calls to the <c>OpenTrace</c> function. The number of handles that you
		/// can specify is limited to 64.
		/// </para>
		/// <para>The array can contain the handles to multiple log files, but only one real-time trace session.</para>
		/// </param>
		/// <param name="HandleCount">Number of elements in HandleArray.</param>
		/// <param name="StartTime">
		/// Pointer to an optional <c>FILETIME</c> structure that specifies the beginning time period for which you want to receive events.
		/// The function does not deliver events recorded prior to StartTime.
		/// </param>
		/// <param name="EndTime">
		/// <para>
		/// Pointer to an optional <c>FILETIME</c> structure that specifies the ending time period for which you want to receive events. The
		/// function does not deliver events recorded after EndTime.
		/// </para>
		/// <para><c>Windows Server 2003:</c> This value is ignored for real-time event delivery.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_LENGTH</term>
		/// <term>HandleCount is not valid or the number of handles is greater than 64.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>An element of HandleArray is not a valid event tracing session handle.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_TIME</term>
		/// <term>EndTime is less than StartTime.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>HandleArray is NULL.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOACCESS</term>
		/// <term>An exception occurred in one of the callback functions that receives the events.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_CANCELLED</term>
		/// <term>Indicates the consumer canceled processing by returning FALSE in their BufferCallback function.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_WMI_INSTANCE_NOT_FOUND</term>
		/// <term>
		/// The session from which you are trying to consume events in real time is not running or does not have the real-time trace mode enabled.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_WMI_ALREADY_ENABLED</term>
		/// <term>The HandleArray parameter contains the handle to more than one real-time session.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Consumers call this function.</para>
		/// <para>You must call the <c>OpenTrace</c> function prior to calling <c>ProcessTrace</c>.</para>
		/// <para>
		/// The <c>ProcessTrace</c> function delivers the events to the consumer's <c>BufferCallback</c>, <c>EventCallback</c>, and
		/// <c>EventClassCallback</c> callback functions.
		/// </para>
		/// <para>
		/// The <c>ProcessTrace</c> function sorts the events chronologically and delivers all events generated between StartTime and
		/// EndTime. Note that events can appear out of order if the session specifies system time as the clock (low resolution) and the
		/// volume of events is high. In this case, it is possible for multiple events to contain the same time stamp. If multiple events
		/// contain the same time stamp, ETW cannot guarantee the order of those events.
		/// </para>
		/// <para>
		/// The <c>ProcessTrace</c> function blocks the thread until it delivers all events, the <c>BufferCallback</c> function returns
		/// <c>FALSE</c>, or you call <c>CloseTrace</c>. If the consumer is consuming events in real time, the <c>ProcessTrace</c> function
		/// returns after the controller stops the trace session. (Note that there may be a several-second delay before the function returns.)
		/// </para>
		/// <para><c>Windows Server 2003:</c> You can call <c>CloseTrace</c> only after <c>ProcessTrace</c> returns.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/processtrace ULONG ProcessTrace( _In_ PTRACEHANDLE HandleArray, _In_ ULONG
		// HandleCount, _In_ LPFILETIME StartTime, _In_ LPFILETIME EndTime );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Evntrace.h", MSDNShortId = "aea25a95-f435-4068-9b15-7473f31ebf16")]
		public static extern Win32Error ProcessTrace([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TRACEHANDLE[] HandleArray, uint HandleCount, in FILETIME StartTime, in FILETIME EndTime);

		/// <summary>The <c>ProcessTrace</c> function delivers events from one or more event tracing sessions to the consumer.</summary>
		/// <param name="HandleArray">
		/// <para>
		/// Pointer to an array of trace handles obtained from earlier calls to the <c>OpenTrace</c> function. The number of handles that you
		/// can specify is limited to 64.
		/// </para>
		/// <para>The array can contain the handles to multiple log files, but only one real-time trace session.</para>
		/// </param>
		/// <param name="HandleCount">Number of elements in HandleArray.</param>
		/// <param name="StartTime">
		/// Pointer to an optional <c>FILETIME</c> structure that specifies the beginning time period for which you want to receive events.
		/// The function does not deliver events recorded prior to StartTime.
		/// </param>
		/// <param name="EndTime">
		/// <para>
		/// Pointer to an optional <c>FILETIME</c> structure that specifies the ending time period for which you want to receive events. The
		/// function does not deliver events recorded after EndTime.
		/// </para>
		/// <para><c>Windows Server 2003:</c> This value is ignored for real-time event delivery.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_LENGTH</term>
		/// <term>HandleCount is not valid or the number of handles is greater than 64.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>An element of HandleArray is not a valid event tracing session handle.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_TIME</term>
		/// <term>EndTime is less than StartTime.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>HandleArray is NULL.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOACCESS</term>
		/// <term>An exception occurred in one of the callback functions that receives the events.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_CANCELLED</term>
		/// <term>Indicates the consumer canceled processing by returning FALSE in their BufferCallback function.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_WMI_INSTANCE_NOT_FOUND</term>
		/// <term>
		/// The session from which you are trying to consume events in real time is not running or does not have the real-time trace mode enabled.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_WMI_ALREADY_ENABLED</term>
		/// <term>The HandleArray parameter contains the handle to more than one real-time session.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Consumers call this function.</para>
		/// <para>You must call the <c>OpenTrace</c> function prior to calling <c>ProcessTrace</c>.</para>
		/// <para>
		/// The <c>ProcessTrace</c> function delivers the events to the consumer's <c>BufferCallback</c>, <c>EventCallback</c>, and
		/// <c>EventClassCallback</c> callback functions.
		/// </para>
		/// <para>
		/// The <c>ProcessTrace</c> function sorts the events chronologically and delivers all events generated between StartTime and
		/// EndTime. Note that events can appear out of order if the session specifies system time as the clock (low resolution) and the
		/// volume of events is high. In this case, it is possible for multiple events to contain the same time stamp. If multiple events
		/// contain the same time stamp, ETW cannot guarantee the order of those events.
		/// </para>
		/// <para>
		/// The <c>ProcessTrace</c> function blocks the thread until it delivers all events, the <c>BufferCallback</c> function returns
		/// <c>FALSE</c>, or you call <c>CloseTrace</c>. If the consumer is consuming events in real time, the <c>ProcessTrace</c> function
		/// returns after the controller stops the trace session. (Note that there may be a several-second delay before the function returns.)
		/// </para>
		/// <para><c>Windows Server 2003:</c> You can call <c>CloseTrace</c> only after <c>ProcessTrace</c> returns.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/processtrace ULONG ProcessTrace( _In_ PTRACEHANDLE HandleArray, _In_ ULONG
		// HandleCount, _In_ LPFILETIME StartTime, _In_ LPFILETIME EndTime );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Evntrace.h", MSDNShortId = "aea25a95-f435-4068-9b15-7473f31ebf16")]
		public static extern Win32Error ProcessTrace([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TRACEHANDLE[] HandleArray, uint HandleCount, IntPtr StartTime = default, IntPtr EndTime = default);

		/// <summary>
		/// The <c>QueryAllTraces</c> function retrieves the properties and statistics for all event tracing sessions started on the computer
		/// for which the caller has permissions to query.
		/// </summary>
		/// <param name="PropertyArray">
		/// <para>
		/// An array of pointers to EVENT_TRACE_PROPERTIES structures that receive session properties and statistics for the event tracing sessions.
		/// </para>
		/// <para>
		/// You only need to set the <c>Wnode.BufferSize</c>, <c>LoggerNameOffset</c> , and <c>LogFileNameOffset</c> members of the
		/// EVENT_TRACE_PROPERTIES structure. The other members should all be set to zero.
		/// </para>
		/// </param>
		/// <param name="PropertyArrayCount">
		/// Number of structures in the PropertyArray array. This value must be less than or equal to 64, the maximum number of event tracing
		/// sessions that ETW supports.
		/// </param>
		/// <param name="LoggerCount">Actual number of event tracing sessions started on the computer.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>
		/// The property array is too small to receive information for all sessions (SessionCount is greater than PropertyArrayCount). The
		/// function fills the property array with the number of property structures specified in PropertyArrayCount.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Event trace controllers call this function.</para>
		/// <para>
		/// This function retrieves the trace sessions that the caller has permissions to query. Users running with elevated administrative
		/// privileges, users in the Performance Log Users group, and services running as LocalSystem, LocalService, NetworkService can view
		/// all tracing sessions.
		/// </para>
		/// <para>This function does not return private logging sessions.</para>
		/// <para>To retrieve information for a single session, use the ControlTrace function and set the ControlCode parameter to <c>EVENT_TRACE_CONTROL_QUERY</c>.</para>
		/// <para>Examples</para>
		/// <para>The following example shows how to call this function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntrace/nf-evntrace-queryalltracesa ULONG WMIAPI QueryAllTracesA(
		// PEVENT_TRACE_PROPERTIES *PropertyArray, ULONG PropertyArrayCount, PULONG LoggerCount );
		[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("evntrace.h", MSDNShortId = "6b6144b0-9152-4b5e-863d-06e823fbe084")]
		public static extern Win32Error QueryAllTraces([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] PropertyArray, uint PropertyArrayCount, out uint LoggerCount);

		/// <summary>
		/// <para>
		/// The <c>QueryTrace</c> function retrieves the property settings and session statistics for the specified event tracing session.
		/// </para>
		/// <para>The ControlTrace function supersedes this function.</para>
		/// </summary>
		/// <param name="TraceHandle">TBD</param>
		/// <param name="InstanceName">TBD</param>
		/// <param name="Properties">TBD</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_LENGTH</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Only users running with elevated administrative privileges, users in the Performance Log Users group, and services running as
		/// LocalSystem, LocalService, NetworkService can query event tracing sessions. To grant a restricted user the ability to query trace
		/// sessions, add them to the Performance Log Users group or see EventAccessControl. Windows XP and Windows 2000: Anyone can control
		/// a trace session.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_WMI_INSTANCE_NOT_FOUND</term>
		/// <term>The given session is not running.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Controllers call this function.</para>
		/// <para>To update the property settings and session statistics for an event tracing session, call the UpdateTrace function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntrace/nf-evntrace-querytracea ULONG WMIAPI QueryTraceA( TRACEHANDLE
		// TraceHandle, LPCSTR InstanceName, PEVENT_TRACE_PROPERTIES Properties );
		[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("evntrace.h", MSDNShortId = "8ad0f4f6-902c-490e-b26e-7499dd99fc95")]
		public static extern Win32Error QueryTrace(TRACEHANDLE TraceHandle, string InstanceName, ref EVENT_TRACE_PROPERTIES Properties);

		/// <summary>Queries the system for the trace processing handle.</summary>
		/// <param name="ProcessingHandle">A valid handle created with <c>OpenTrace</c> that the data should be queried from.</param>
		/// <param name="InformationClass">
		/// An <c>ETW_PROCESS_HANDLE_INFO_TYPE</c> value that specifies what kind of operation will be done on the handle.
		/// </param>
		/// <param name="InBuffer">Reserved for future use. May be null.</param>
		/// <param name="InBufferSize">Size in bytes of the InBuffer.</param>
		/// <param name="OutBuffer">Buffer provided by the caller to contain output data.</param>
		/// <param name="OutBufferSize">Size in bytes of OutBuffer.</param>
		/// <param name="ReturnLength">The size in bytes of the data that the API wrote into OutBuffer. Important for variable length returns.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>If the function fails, the return value is one of the system error codes.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/querytraceprocessinghandle ULONG WINAPI QueryTraceProcessingHandle( _In_
		// TRACEHANDLE ProcessingHandle, _In_ ETW_PROCESS_HANDLE_INFO_TYPE InformationClass, _In_opt_ PVOID InBuffer, _In_ ULONG
		// InBufferSize, _Out_opt_ PVOID OutBuffer, _In_ ULONG OutBufferSize, _Out_ PULONG ReturnLength );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntrace.h", MSDNShortId = "87666275-8752-4EC8-9C01-16D36AE4C5E8")]
		public static extern Win32Error QueryTraceProcessingHandle(TRACEHANDLE ProcessingHandle, ETW_PROCESS_HANDLE_INFO_TYPE InformationClass, [In, Optional] IntPtr InBuffer, uint InBufferSize, [Out, Optional] IntPtr OutBuffer, uint OutBufferSize, out uint ReturnLength);

		/// <summary>
		/// The <c>RegisterTraceGuids</c> function registers an event trace provider and the event trace classes that it uses to generate
		/// events. This function also specifies the function the provider uses to enable and disable tracing.
		/// </summary>
		/// <param name="RequestAddress">
		/// Pointer to a <c>ControlCallback</c> function that receives notification when the provider is enabled or disabled by an event
		/// tracing session. The <c>EnableTrace</c> function calls the callback.
		/// </param>
		/// <param name="RequestContext">Pointer to an optional provider-defined context that ETW passes to the function specified by RequestAddress.</param>
		/// <param name="ControlGuid">GUID of the registering provider.</param>
		/// <param name="GuidCount">
		/// Number of elements in the TraceGuidReg array. If TraceGuidReg is <c>NULL</c>, set this parameter to 0.
		/// </param>
		/// <param name="TraceGuidReg">
		/// <para>
		/// Pointer to an array of <c>TRACE_GUID_REGISTRATION</c> structures. Each element identifies a category of events that the provider provides.
		/// </para>
		/// <para>
		/// On input, the <c>Guid</c> member of each structure contains an event trace class GUID assigned by the registering provider. The
		/// class GUID identifies a category of events that the provider provides. Providers use the same class GUID to set the Guid member
		/// of <c>EVENT_TRACE_HEADER</c> when calling the <c>TraceEvent</c> function to log the event.
		/// </para>
		/// <para>
		/// On output, the <c>RegHandle</c> member receives a handle to the event's class GUID registration. If the provider calls the
		/// <c>TraceEventInstance</c> function, use the <c>RegHandle</c> member of <c>TRACE_GUID_REGISTRATION</c> to set the <c>RegHandle</c>
		/// member of <c>EVENT_INSTANCE_HEADER</c>.
		/// </para>
		/// <para>
		/// This parameter can be <c>NULL</c> if the provider calls only the <c>TraceEvent</c> function to log events. If the provider calls
		/// the <c>TraceEventInstance</c> function to log events, this parameter cannot be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="MofImagePath">
		/// <para>
		/// This parameter is not supported, set to <c>NULL</c>. You should use Mofcomp.exe to register the MOF resource during the setup of
		/// your application. For more information see, Publishing Your Event Schema.
		/// </para>
		/// <para>
		/// <c>Windows XP with SP1, Windows XP and Windows 2000:</c> Pointer to an optional string that specifies the path of the DLL or
		/// executable program that contains the resource specified by MofResourceName. This parameter can be <c>NULL</c> if the event
		/// provider and consumer use another mechanism to share information about the event trace classes used by the provider.
		/// </para>
		/// </param>
		/// <param name="MofResourceName">
		/// <para>
		/// This parameter is not supported, set to <c>NULL</c>. You should use Mofcomp.exe to register the MOF resource during the setup of
		/// your application. For more information see, Publishing Your Event Schema.
		/// </para>
		/// <para>
		/// <c>Windows XP with SP1, Windows XP and Windows 2000:</c> Pointer to an optional string that specifies the string resource of
		/// MofImagePath. The string resource contains the name of the binary MOF file that describes the event trace classes supported by
		/// the provider.
		/// </para>
		/// </param>
		/// <param name="RegistrationHandle">
		/// Pointer to the provider's registration handle. Use this handle when you call the <c>UnregisterTraceGuids</c> function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// One of the following is true: Windows XP and Windows 2000: TraceGuidReg is NULL or GuidCount is less than or equal to zero.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Providers call this function.</para>
		/// <para>
		/// If the provider's ControlGuid has been previously registered and enabled, subsequent registrations that reference the same
		/// ControlGuid are automatically enabled.
		/// </para>
		/// <para>
		/// A process can register up to 1,024 provider GUIDs; however, you should limit the number of providers that your process registers
		/// to one or two. This limit includes those registered using this function and the <c>EventRegister</c> function.
		/// </para>
		/// <para><c>Prior to Windows Vista:</c> There is no limit to the number of providers that a process can register.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/registertraceguids ULONG RegisterTraceGuids( _In_ WMIDPREQUEST
		// RequestAddress, _In_ PVOID RequestContext, _In_ LPCGUID ControlGuid, _In_ ULONG GuidCount, _Inout_ PTRACE_GUID_REGISTRATION
		// TraceGuidReg, _In_ LPCTSTR MofImagePath, _In_ LPCTSTR MofResourceName, _Out_ PTRACEHANDLE RegistrationHandle );
		[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("evntrace.h", MSDNShortId = "c9158292-281b-4a02-b280-956e340d225c")]
		public static extern Win32Error RegisterTraceGuids([MarshalAs(UnmanagedType.FunctionPtr)] TraceControlCallback RequestAddress, [In, Optional] IntPtr RequestContext, in Guid ControlGuid, uint GuidCount,
			[In, Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] TRACE_GUID_REGISTRATION[] TraceGuidReg, [In, Optional] string MofImagePath, [In, Optional] string MofResourceName, out TRACEHANDLE RegistrationHandle);

		//public unsafe delegate Win32Error UnsafeTraceControlCallback([In] WMIDPREQUESTCODE RequestCode, [In] void* Context, uint* Reserved, void* Buffer);
		//[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Unicode, EntryPoint = "RegisterTraceGuidsW")]
		//public static extern unsafe Win32Error UnsafeRegisterTraceGuids(UnsafeTraceControlCallback TraceRequestAddress, [In, Optional] void* RequestContext, [In] Guid* ControlGuid, uint GuidCount,
		//	TRACE_GUID_REGISTRATION* TraceGuidReg, [In, Optional] string MofImagePath, [In, Optional] string MofResourceName, out TRACEHANDLE RegistrationHandle);

		/// <summary>
		/// <para>[Do not use this function; it may be unavailable in subsequent versions.]</para>
		/// <para>
		/// The <c>RemoveTraceCallback</c> function stops an <c>EventClassCallback</c> function from receiving events for an event trace class.
		/// </para>
		/// </summary>
		/// <param name="pGuid">
		/// Pointer to the class GUID of the event trace class for which the callback receives events. Use the same class GUID that you
		/// passed to the <c>SetTraceCallback</c> to begin receiving the events.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The pGuid parameter is NULL.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_WMI_GUID_NOT_FOUND</term>
		/// <term>There is no EventClassCallback function associated with the event trace class.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>Consumers call this function.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/removetracecallback ULONG RemoveTraceCallback( _In_ LPCGUID pGuid );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Evntrace.h", MSDNShortId = "da779e8d-4984-44e3-8731-647a422b55b2")]
		public static extern Win32Error RemoveTraceCallback(in Guid pGuid);

		/// <summary>
		/// <para>
		/// [Do not use this function; it may be unavailable in subsequent versions. Instead, filter for the event trace class in your
		/// EventRecordCallback function.]
		/// </para>
		/// <para>
		/// The <c>SetTraceCallback</c> function specifies an <c>EventClassCallback</c> function to process events for the specified event
		/// trace class.
		/// </para>
		/// </summary>
		/// <param name="pGuid">
		/// Pointer to the class GUID of an event trace class for which you want to receive events. For a list of kernel provider class
		/// GUIDs, see NT Kernel Logger Constants.
		/// </param>
		/// <param name="EventCallback">
		/// Pointer to an <c>EventClassCallback</c> function used to process events belonging to the event trace class.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Consumers call this function.</para>
		/// <para>
		/// You can only specify one callback function for an event trace class. If you specify more than one callback function for the even
		/// trace class, the last callback function receives the events for that event trace class.
		/// </para>
		/// <para>
		/// To stop the callback function from receiving events for the event trace class, call the <c>RemoveTraceCallback</c> function. The
		/// callback automatically stops receiving callbacks when you close the trace.
		/// </para>
		/// <para>
		/// You can use this function to receive events written using one of the <c>TraceEvent</c> functions. You cannot use this function to
		/// consume events from a provider that used one of the <c>EventWrite</c> functions to log events.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/settracecallback ULONG SetTraceCallback( _In_ LPCGUID pGuid, _In_
		// PEVENT_CALLBACK EventCallback );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Evntrace.h", MSDNShortId = "8663f64f-a203-43e5-94e8-337f2d81c3a0")]
		public static extern Win32Error SetTraceCallback(in Guid pGuid, EventClassCallback EventCallback);

		/// <summary>The <c>StartTrace</c> function registers and starts an event tracing session.</summary>
		/// <param name="TraceHandle">
		/// <para>Handle to the event tracing session.</para>
		/// <para>
		/// Do not use this handle if the function fails. Do not compare the session handle to INVALID_HANDLE_VALUE; the session handle is 0
		/// if the handle is not valid.
		/// </para>
		/// </param>
		/// <param name="InstanceName">
		/// <para>
		/// Null-terminated string that contains the name of the event tracing session. The session name is limited to 1,024 characters, is
		/// case-insensitive, and must be unique.
		/// </para>
		/// <para>
		/// <c>Windows 2000:</c> Session names are case-sensitive. As a result, duplicate session names are allowed. However, to reduce
		/// confusion, you should make sure your session names are unique.
		/// </para>
		/// <para>
		/// This function copies the session name that you provide to the offset that the <c>LoggerNameOffset</c> member of Properties points to.
		/// </para>
		/// </param>
		/// <param name="Properties">
		/// <para>
		/// Pointer to an EVENT_TRACE_PROPERTIES structure that specifies the behavior of the session. The following are key members of the
		/// structure to set:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>Wnode.BufferSize</c></term>
		/// </item>
		/// <item>
		/// <term><c>Wnode.Guid</c></term>
		/// </item>
		/// <item>
		/// <term><c>Wnode.ClientContext</c></term>
		/// </item>
		/// <item>
		/// <term><c>Wnode.Flags</c></term>
		/// </item>
		/// <item>
		/// <term><c>LogFileMode</c></term>
		/// </item>
		/// <item>
		/// <term><c>LogFileNameOffset</c></term>
		/// </item>
		/// <item>
		/// <term><c>LoggerNameOffset</c></term>
		/// </item>
		/// </list>
		/// <para>Depending on the type of log file you choose to create, you may also need to specify a value for</para>
		/// <para>MaximumFileSize</para>
		/// <para>. See the Remarks section for more information on setting the</para>
		/// <para>Properties</para>
		/// <para>parameter and the behavior of the session.</para>
		/// <para>
		/// <c>Starting with Windows 10, version 1703:</c> For better performance in cross process scenarios, you can now pass filtering in
		/// to <c>StartTrace</c> when starting system wide private loggers. You will need to pass in the new EVENT_TRACE_PROPERTIES_V2
		/// structure to include filtering information. See Configuring and Starting a Private Logger Session for more details.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_LENGTH</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ALREADY_EXISTS</term>
		/// <term>A session with the same name or GUID is already running.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_PATHNAME</term>
		/// <term>You can receive this error for one of the following reasons:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_DISK_FULL</term>
		/// <term>
		/// There is not enough free space on the drive for the log file. This occurs if: Choose a drive with more space, or decrease the
		/// size specified in MaximumFileSize (if used). Windows 2000: Does not require an additional 200 MB available disk space.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Only users with administrative privileges, users in the Performance Log Users group, and services running as LocalSystem,
		/// LocalService, NetworkService can control event tracing sessions. To grant a restricted user the ability to control trace
		/// sessions, add them to the Performance Log Users group. Only users with administrative privileges and services running as
		/// LocalSystem can control an NT Kernel Logger session. Windows XP and Windows 2000: Anyone can control a trace session. If the user
		/// is a member of the Performance Log Users group, they may not have permission to create the log file in the specified folder.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SYSTEM_RESOURCES</term>
		/// <term>
		/// The maximum number of logging sessions on the system has been reached. No new loggers can be created until a logging session has
		/// been stopped. This value defaults to 64 on most systems. You can change this value by editing the REG_DWORD key at
		/// HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\WMI\EtwMaxLoggers. Permissible values are 32 through 256, inclusive. A reboot
		/// is required for any change to take effect. Note that Loggers use system resources. Increasing the number of loggers on the system
		/// will come at a performance cost if those slots are filled. Prior to Windows 10, version 1709, this is a fixed cap of 64 loggers
		/// for non-private loggers.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Event trace controllers call this function.</para>
		/// <para>
		/// The session remains active until you stop the session, the computer is restarted or the maximum file size is reached for
		/// non-circular logs. To stop an event tracing session, call the ControlTrace function and set the ControlCode parameter to <c>EVENT_TRACE_CONTROL_STOP</c>.
		/// </para>
		/// <para>You cannot start more than one session with the same session GUID.</para>
		/// <para><c>Windows Server 2003:</c> You can start more than one session with the same session GUID.</para>
		/// <para>For the logger to be a system logger and receive events from SystemTraceProvider, any of the following must be true:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The Properties member <c>Wnode.Guid</c> is set to <c>SystemTraceControlGuid</c> or <c>GlobalLoggerGuid</c>.</term>
		/// </item>
		/// <item>
		/// <term>The Properties member <c>LogFileMode</c> includes the <c>EVENT_TRACE_SYSTEM_LOGGER_MODE</c> flag.</term>
		/// </item>
		/// <item>
		/// <term>SessionName is set to <c>KERNEL_LOGGER_NAME</c>.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> A system logger must set the <c>EnableFlags</c> member of the EVENT_TRACE_PROPERTIES structure to indicate which
		/// SystemTraceProvider events should be included in the trace.
		/// </para>
		/// <para>Because system loggers receive special kernel events, they are subject to additional restrictions:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>There can be no more than 8 system loggers active on the same system.</term>
		/// </item>
		/// <item>
		/// <term>System loggers cannot be created within a Windows Server container.</term>
		/// </item>
		/// <item>
		/// <term>System loggers cannot use the <c>EVENT_TRACE_USE_PAGED_MEMORY</c> flag.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Prior to Windows 10, version 1703, no more than 2 distinct clock types can be used simultaneously by any system loggers. For
		/// example, if one active system logger is using the "CPU cycle counter" clock type, and another active system logger is using the
		/// "Query performance counter" clock type, then any attempt to start a system logger using the "System time" clock type will fail
		/// because it would require the activation of a third clock type. Because of this limitation, Microsoft strongly recommends that
		/// system loggers do not use the "System time" clock type.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Starting with Windows 10, version 1703, the clock type restriction has been removed. All three clock types can now be used
		/// simultaneously by system loggers.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// To specify an NT Kernel Logger session, set SessionName to <c>KERNEL_LOGGER_NAME</c> and the <c>Wnode.Guid</c> member of
		/// Properties to <c>SystemTraceControlGuid</c>. If you do not specify the GUID as <c>SystemTraceControlGuid</c>, ETW will override
		/// the GUID value and set it to <c>SystemTraceControlGuid</c>.
		/// </para>
		/// <para>
		/// <c>Windows 2000:</c> To start the kernel session, the session name must be <c>KERNEL_LOGGER_NAME</c> and the GUID must be <c>SystemTraceControlGuid</c>.
		/// </para>
		/// <para>
		/// To specify a private logger session, set <c>Wnode.Guid</c> member of Properties to the provider's control GUID, not the private
		/// logger session's control GUID. The provider must have registered the GUID before you call <c>StartTrace</c>.
		/// </para>
		/// <para>
		/// You do not use this function to start a global logger session. For details on starting a global logger session, see Configuring
		/// and Starting the Global Logger Session.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses <c>StartTrace</c>, see Configuring and Starting an Event Tracing Session.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntrace/nf-evntrace-starttracea ULONG WMIAPI StartTraceA( PTRACEHANDLE
		// TraceHandle, LPCSTR InstanceName, PEVENT_TRACE_PROPERTIES Properties );
		[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("evntrace.h", MSDNShortId = "c040514a-733d-44b9-8300-a8341d2630b3")]
		public static extern Win32Error StartTrace(out TRACEHANDLE TraceHandle, string InstanceName, ref EVENT_TRACE_PROPERTIES Properties);

		/// <summary>
		/// <para>The <c>StopTrace</c> function stops the specified event tracing session.</para>
		/// <para>The <c>ControlTrace</c> function supersedes this function.</para>
		/// </summary>
		/// <param name="SessionHandle">
		/// Handle to the event tracing session that you want to stop, or <c>NULL</c>. You must specify SessionHandle if SessionName is
		/// <c>NULL</c>. However, ETW ignores the handle if SessionName is not <c>NULL</c>. The handle is returned by the <c>StartTrace</c> function.
		/// </param>
		/// <param name="SessionName">
		/// <para>
		/// Pointer to a null-terminated string that specifies the name of the event tracing session that you want to stop, or <c>NULL</c>.
		/// You must specify SessionName if SessionHandle is <c>NULL</c>.
		/// </para>
		/// <para>To specify the NT Kernel Logger session, set SessionName to <c>KERNEL_LOGGER_NAME</c>.</para>
		/// </param>
		/// <param name="Properties">
		/// <para>Pointer to an <c>EVENT_TRACE_PROPERTIES</c> structure that receives the final properties and statistics for the session.</para>
		/// <para>
		/// If you are using a newly initialized structure, you only need to set the <c>Wnode.BufferSize</c>, <c>Wnode.Guid</c>,
		/// <c>LoggerNameOffset</c>, and <c>LogFileNameOffset</c> members of the structure. You can use the maximum session name (1024
		/// characters) and maximum log file name (1024 characters) lengths to calculate the buffer size and offsets if not known.
		/// </para>
		/// <para>
		/// <c>Starting with Windows 10, version 1703:</c> For better performance in cross process scenarios, you can now pass filtering in
		/// to <c>StopTrace</c> for system wide private loggers. You will need to pass in the new <c>EVENT_TRACE_PROPERTIES_V2</c> structure
		/// to include filtering information. See Configuring and Starting a Private Logger Session for more details.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_LENGTH</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Only users with administrative privileges, users in the Performance Log Users group, and services running as LocalSystem,
		/// LocalService, NetworkService can control event tracing sessions. To grant a restricted user the ability to control trace
		/// sessions, add them to the Performance Log Users group. Windows XP and Windows 2000: Anyone can control a trace session.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Controllers call this function.</para>
		/// <para>
		/// If <c>LogFileMode</c> contains <c>EVENT_TRACE_FILE_MODE_PREALLOCATE</c>, <c>StartTrace</c> extends the log file to
		/// <c>MaximumFileSize</c> bytes. The file occupies the entire space during logging, for both circular and sequential logs. When you
		/// stop the logger, the log file is reduced to the size needed.
		/// </para>
		/// <para>Note that it is not safe to stop a trace session from DllMain.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/stoptrace ULONG StopTrace( _In_ TRACEHANDLE SessionHandle, _In_ LPCTSTR
		// SessionName, _Out_ PEVENT_TRACE_PROPERTIES Properties );
		[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Evntrace.h", MSDNShortId = "604274a1-c4ed-4746-b69a-e18969f969db")]
		public static extern Win32Error StopTrace(TRACEHANDLE SessionHandle, [Optional] string SessionName, ref EVENT_TRACE_PROPERTIES Properties);

		/// <summary>The <c>TraceEvent</c> function sends an event to an event tracing session.</summary>
		/// <param name="SessionHandle">
		/// Handle to the event tracing session that records the event. The provider obtains the handle when it calls the
		/// <c>GetTraceLoggerHandle</c> function in its ControlCallback implementation.
		/// </param>
		/// <param name="EventTrace">
		/// <para>
		/// Pointer to an <c>EVENT_TRACE_HEADER</c> structure. Event-specific data is optionally appended to the structure. The largest event
		/// you can log is 64K. You must specify values for the following members of the <c>EVENT_TRACE_HEADER</c> structure.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>Size</c></term>
		/// </item>
		/// <item>
		/// <term><c>Guid</c> or <c>GuidPtr</c></term>
		/// </item>
		/// <item>
		/// <term><c>Flags</c></term>
		/// </item>
		/// </list>
		/// <para>
		/// Depending on the complexity of the information your provider provides, you should also consider specifying values for the
		/// following members.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>Class.Type</c></term>
		/// </item>
		/// <item>
		/// <term><c>Class.Level</c></term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_FLAG_NUMBER</term>
		/// <term>The Flags member of the EVENT_TRACE_HEADER structure is incorrect.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>SessionHandle is not valid or specifies the NT Kernel Logger session handle.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>
		/// The session ran out of free buffers to write to. This can occur during high event rates because the disk subsystem is overloaded
		/// or the number of buffers is too small. Rather than blocking until more buffers become available, TraceEvent discards the event.
		/// Consider increasing the number and size of the buffers for the session, or reducing the number of events written or the size of
		/// the events. Windows 2000: Not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_OUTOFMEMORY</term>
		/// <term>
		/// The event is discarded because, although the buffer pool has not reached its maximum size, there is insufficient available memory
		/// to allocate an additional buffer and there is no buffer available to receive the event.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>
		/// Data from a single event cannot span multiple buffers. A trace event is limited to the size of the event tracing session's buffer
		/// minus the size of the EVENT_TRACE_HEADER structure.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Providers call this function.</para>
		/// <para>Before the provider can call this function, the provider</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Must call the <c>RegisterTraceGuids</c> function to register itself and the event trace class.</term>
		/// </item>
		/// <item>
		/// <term>Must be enabled. A controller calls the <c>EnableTrace</c> function to enable a provider.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The event is either written to a log file, sent to event trace consumers in real time, or both. The <c>LogFileMode</c> member of
		/// the <c>EVENT_TRACE_PROPERTIES</c> structure passed to the <c>StartTrace</c> defines where the event is sent.
		/// </para>
		/// <para>The trace events are written in the order in which they occur.</para>
		/// <para>To trace a set of related events, use the <c>TraceEventInstance</c> function.</para>
		/// <para>On Windows Vista, you should use the <c>EventWrite</c> function to log events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/etw/traceevent ULONG TraceEvent( _In_ TRACEHANDLE SessionHandle, _In_
		// PEVENT_TRACE_HEADER EventTrace );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Evntrace.h", MSDNShortId = "9b21f6f0-dd9b-4f9c-a879-846901a3bab7")]
		public static extern Win32Error TraceEvent(TRACEHANDLE SessionHandle, PEVENT_TRACE_HEADER EventTrace);

		/// <summary>The <c>TraceEvent</c> function sends an event to an event tracing session.</summary>
		/// <param name="SessionHandle">
		/// Handle to the event tracing session that records the event. The provider obtains the handle when it calls the
		/// <c>GetTraceLoggerHandle</c> function in its ControlCallback implementation.
		/// </param>
		/// <param name="EventTrace">
		/// <para>
		/// Pointer to an <c>EVENT_TRACE_HEADER</c> structure. Event-specific data is optionally appended to the structure. The largest event
		/// you can log is 64K. You must specify values for the following members of the <c>EVENT_TRACE_HEADER</c> structure.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>Size</c></term>
		/// </item>
		/// <item>
		/// <term><c>Guid</c> or <c>GuidPtr</c></term>
		/// </item>
		/// <item>
		/// <term><c>Flags</c></term>
		/// </item>
		/// </list>
		/// <para>
		/// Depending on the complexity of the information your provider provides, you should also consider specifying values for the
		/// following members.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>Class.Type</c></term>
		/// </item>
		/// <item>
		/// <term><c>Class.Level</c></term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_FLAG_NUMBER</term>
		/// <term>The Flags member of the EVENT_TRACE_HEADER structure is incorrect.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>SessionHandle is not valid or specifies the NT Kernel Logger session handle.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>
		/// The session ran out of free buffers to write to. This can occur during high event rates because the disk subsystem is overloaded
		/// or the number of buffers is too small. Rather than blocking until more buffers become available, TraceEvent discards the event.
		/// Consider increasing the number and size of the buffers for the session, or reducing the number of events written or the size of
		/// the events. Windows 2000: Not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_OUTOFMEMORY</term>
		/// <term>
		/// The event is discarded because, although the buffer pool has not reached its maximum size, there is insufficient available memory
		/// to allocate an additional buffer and there is no buffer available to receive the event.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>
		/// Data from a single event cannot span multiple buffers. A trace event is limited to the size of the event tracing session's buffer
		/// minus the size of the EVENT_TRACE_HEADER structure.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Providers call this function.</para>
		/// <para>Before the provider can call this function, the provider</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Must call the <c>RegisterTraceGuids</c> function to register itself and the event trace class.</term>
		/// </item>
		/// <item>
		/// <term>Must be enabled. A controller calls the <c>EnableTrace</c> function to enable a provider.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The event is either written to a log file, sent to event trace consumers in real time, or both. The <c>LogFileMode</c> member of
		/// the <c>EVENT_TRACE_PROPERTIES</c> structure passed to the <c>StartTrace</c> defines where the event is sent.
		/// </para>
		/// <para>The trace events are written in the order in which they occur.</para>
		/// <para>To trace a set of related events, use the <c>TraceEventInstance</c> function.</para>
		/// <para>On Windows Vista, you should use the <c>EventWrite</c> function to log events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/etw/traceevent ULONG TraceEvent( _In_ TRACEHANDLE SessionHandle, _In_
		// PEVENT_TRACE_HEADER EventTrace );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Evntrace.h", MSDNShortId = "9b21f6f0-dd9b-4f9c-a879-846901a3bab7")]
		public static extern Win32Error TraceEvent(TRACEHANDLE SessionHandle, IntPtr EventTrace);

		/// <summary>
		/// The <c>TraceEventInstance</c> function sends an event to an event tracing session. The event uses an instance identifier to
		/// associate the event with a transaction. This function may also be used to trace hierarchical relationships between related events.
		/// </summary>
		/// <param name="SessionHandle">
		/// Handle to the event tracing session that records the event instance. The provider obtains the handle when it calls the
		/// <c>GetTraceLoggerHandle</c> function in its ControlCallback implementation.
		/// </param>
		/// <param name="EventTrace">
		/// <para>
		/// Pointer to an <c>EVENT_INSTANCE_HEADER</c> structure. Event-specific data is optionally appended to the structure. The largest
		/// event you can log is 64K. You must specify values for the following members of the <c>EVENT_INSTANCE_HEADER</c> structure.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>Size</c></term>
		/// </item>
		/// <item>
		/// <term><c>Flags</c></term>
		/// </item>
		/// <item>
		/// <term><c>RegHandle</c></term>
		/// </item>
		/// </list>
		/// <para>
		/// Depending on the complexity of the information your provider provides, you should also consider specifying values for the
		/// following members.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>Class.Type</c></term>
		/// </item>
		/// <item>
		/// <term><c>Class.Level</c></term>
		/// </item>
		/// </list>
		/// <para>To trace hierarchical relationships between related events, also set the <c>ParentRegHandle</c> member.</para>
		/// </param>
		/// <param name="pInstInfo">
		/// Pointer to an <c>EVENT_INSTANCE_INFO</c> structure, which contains the registration handle for this event trace class and the
		/// instance identifier. Use the <c>CreateTraceInstanceId</c> function to initialize the structure.
		/// </param>
		/// <param name="pParentInstInfo">
		/// Pointer to an <c>EVENT_INSTANCE_INFO</c> structure, which contains the registration handle for the parent event trace class and
		/// its instance identifier. Use the <c>CreateTraceInstanceId</c> function to initialize the structure. Set to <c>NULL</c> if you are
		/// not tracing a hierarchical relationship.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The Flags member of the EVENT_INSTANCE_HEADER does not contain WNODE_FLAG_TRACED_GUID.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_OUTOFMEMORY</term>
		/// <term>
		/// There was insufficient memory to complete the function call. The causes for this error code are described in the following
		/// Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>SessionHandle is not valid or specifies the NT Kernel Logger session handle.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>
		/// The session ran out of free buffers to write to. This can occur during high event rates because the disk subsystem is overloaded
		/// or the number of buffers is too small. Rather than blocking until more buffers become available, TraceEvent discards the event.
		/// Windows 2000 and Windows XP: Not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_OUTOFMEMORY</term>
		/// <term>
		/// The event is discarded because, although the buffer pool has not reached its maximum size, there is insufficient available memory
		/// to allocate an additional buffer and there is no buffer available to receive the event.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>
		/// Data from a single event cannot span multiple buffers. A trace event is limited to the size of the event tracing session's buffer
		/// minus the size of the EVENT_INSTANCE_HEADER structure.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Providers call this function.</para>
		/// <para>Before the provider can call this function, the provider</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Must call the <c>RegisterTraceGuids</c> function to register itself and the event trace class.</term>
		/// </item>
		/// <item>
		/// <term>Must call the <c>CreateTraceInstanceId</c> function to create an instance identifier for the registered event trace class.</term>
		/// </item>
		/// <item>
		/// <term>Must be enabled. A controller calls the <c>EnableTrace</c> function to enable a provider.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The event is either written to a log file, sent to event trace consumers in real time, or both. The <c>LogFileMode</c> member of
		/// the <c>EVENT_TRACE_PROPERTIES</c> structure passed to the <c>StartTrace</c> defines where the event is sent.
		/// </para>
		/// <para>The trace events are written in the order in which they occur.</para>
		/// <para>To trace unrelated events, use the <c>TraceEvent</c> function.</para>
		/// <para><c>Windows XP:</c> Does not work correctly.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/etw/traceeventinstance ULONG TraceEventInstance( _In_ TRACEHANDLE SessionHandle,
		// _In_ PEVENT_INSTANCE_HEADER EventTrace, _In_ PEVENT_INSTANCE_INFO pInstInfo, _In_ PEVENT_INSTANCE_INFO pParentInstInfo );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Evntrace.h", MSDNShortId = "e8361bdc-21dd-47a0-bdbf-56f4d6195689")]
		public static extern Win32Error TraceEventInstance(TRACEHANDLE SessionHandle, PEVENT_INSTANCE_HEADER EventTrace, in EVENT_INSTANCE_INFO pInstInfo, in EVENT_INSTANCE_INFO pParentInstInfo);

		/// <summary>
		/// The <c>TraceEventInstance</c> function sends an event to an event tracing session. The event uses an instance identifier to
		/// associate the event with a transaction. This function may also be used to trace hierarchical relationships between related events.
		/// </summary>
		/// <param name="SessionHandle">
		/// Handle to the event tracing session that records the event instance. The provider obtains the handle when it calls the
		/// <c>GetTraceLoggerHandle</c> function in its ControlCallback implementation.
		/// </param>
		/// <param name="EventTrace">
		/// <para>
		/// Pointer to an <c>EVENT_INSTANCE_HEADER</c> structure. Event-specific data is optionally appended to the structure. The largest
		/// event you can log is 64K. You must specify values for the following members of the <c>EVENT_INSTANCE_HEADER</c> structure.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>Size</c></term>
		/// </item>
		/// <item>
		/// <term><c>Flags</c></term>
		/// </item>
		/// <item>
		/// <term><c>RegHandle</c></term>
		/// </item>
		/// </list>
		/// <para>
		/// Depending on the complexity of the information your provider provides, you should also consider specifying values for the
		/// following members.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>Class.Type</c></term>
		/// </item>
		/// <item>
		/// <term><c>Class.Level</c></term>
		/// </item>
		/// </list>
		/// <para>To trace hierarchical relationships between related events, also set the <c>ParentRegHandle</c> member.</para>
		/// </param>
		/// <param name="pInstInfo">
		/// Pointer to an <c>EVENT_INSTANCE_INFO</c> structure, which contains the registration handle for this event trace class and the
		/// instance identifier. Use the <c>CreateTraceInstanceId</c> function to initialize the structure.
		/// </param>
		/// <param name="pParentInstInfo">
		/// Pointer to an <c>EVENT_INSTANCE_INFO</c> structure, which contains the registration handle for the parent event trace class and
		/// its instance identifier. Use the <c>CreateTraceInstanceId</c> function to initialize the structure. Set to <c>NULL</c> if you are
		/// not tracing a hierarchical relationship.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The Flags member of the EVENT_INSTANCE_HEADER does not contain WNODE_FLAG_TRACED_GUID.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_OUTOFMEMORY</term>
		/// <term>
		/// There was insufficient memory to complete the function call. The causes for this error code are described in the following
		/// Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the following is true:</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>SessionHandle is not valid or specifies the NT Kernel Logger session handle.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>
		/// The session ran out of free buffers to write to. This can occur during high event rates because the disk subsystem is overloaded
		/// or the number of buffers is too small. Rather than blocking until more buffers become available, TraceEvent discards the event.
		/// Windows 2000 and Windows XP: Not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_OUTOFMEMORY</term>
		/// <term>
		/// The event is discarded because, although the buffer pool has not reached its maximum size, there is insufficient available memory
		/// to allocate an additional buffer and there is no buffer available to receive the event.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>
		/// Data from a single event cannot span multiple buffers. A trace event is limited to the size of the event tracing session's buffer
		/// minus the size of the EVENT_INSTANCE_HEADER structure.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Providers call this function.</para>
		/// <para>Before the provider can call this function, the provider</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Must call the <c>RegisterTraceGuids</c> function to register itself and the event trace class.</term>
		/// </item>
		/// <item>
		/// <term>Must call the <c>CreateTraceInstanceId</c> function to create an instance identifier for the registered event trace class.</term>
		/// </item>
		/// <item>
		/// <term>Must be enabled. A controller calls the <c>EnableTrace</c> function to enable a provider.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The event is either written to a log file, sent to event trace consumers in real time, or both. The <c>LogFileMode</c> member of
		/// the <c>EVENT_TRACE_PROPERTIES</c> structure passed to the <c>StartTrace</c> defines where the event is sent.
		/// </para>
		/// <para>The trace events are written in the order in which they occur.</para>
		/// <para>To trace unrelated events, use the <c>TraceEvent</c> function.</para>
		/// <para><c>Windows XP:</c> Does not work correctly.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/etw/traceeventinstance ULONG TraceEventInstance( _In_ TRACEHANDLE SessionHandle,
		// _In_ PEVENT_INSTANCE_HEADER EventTrace, _In_ PEVENT_INSTANCE_INFO pInstInfo, _In_ PEVENT_INSTANCE_INFO pParentInstInfo );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Evntrace.h", MSDNShortId = "e8361bdc-21dd-47a0-bdbf-56f4d6195689")]
		public static extern Win32Error TraceEventInstance(TRACEHANDLE SessionHandle, PEVENT_INSTANCE_HEADER EventTrace, in EVENT_INSTANCE_INFO pInstInfo, [Optional] IntPtr pParentInstInfo);

		/// <summary>The <c>TraceMessage</c> function sends an informational message to an event tracing session.</summary>
		/// <param name="SessionHandle">
		/// Handle to the event tracing session that records the event. The provider obtains the handle when it calls the
		/// <c>GetTraceLoggerHandle</c> function in its ControlCallback implementation.
		/// </param>
		/// <param name="MessageFlags">
		/// <para>
		/// Adds additional information to the beginning of the provider-specific data section of the event. The provider-specific data
		/// section of the event will contain data only for those flags that are set. The variable list of argument data will follow this
		/// information. This parameter can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRACE_MESSAGE_COMPONENTID</term>
		/// <term>Include the component identifier in the message. The MessageGuid parameter contains the component identifier.</term>
		/// </item>
		/// <item>
		/// <term>TRACE_MESSAGE_GUID</term>
		/// <term>Include the event trace class GUID in the message. The MessageGuid parameter contains the event trace class GUID.</term>
		/// </item>
		/// <item>
		/// <term>TRACE_MESSAGE_SEQUENCE</term>
		/// <term>
		/// Include a sequence number in the message. The sequence number starts at one. To use this flag, the controller must have set the
		/// EVENT_TRACE_USE_GLOBAL_SEQUENCE or EVENT_TRACE_USE_LOCAL_SEQUENCE log file mode when creating the session.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TRACE_MESSAGE_SYSTEMINFO</term>
		/// <term>Include the thread identifier and process identifier in the message.</term>
		/// </item>
		/// <item>
		/// <term>TRACE_MESSAGE_TIMESTAMP</term>
		/// <term>Include a time stamp in the message.</term>
		/// </item>
		/// </list>
		/// <para><c>TRACE_MESSAGE_COMPONENTID</c> and <c>TRACE_MESSAGE_GUID</c> are mutually exclusive.</para>
		/// <para>The information is included in the event data in the following order:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Sequence number</term>
		/// </item>
		/// <item>
		/// <term>Event trace class GUID (or component identifier)</term>
		/// </item>
		/// <item>
		/// <term>Time stamp</term>
		/// </item>
		/// <item>
		/// <term>Thread identifier</term>
		/// </item>
		/// <item>
		/// <term>Process identifier</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="MessageGuid">
		/// Class GUID or component ID that identifies the message. Depends if MessageFlags contains the <c>TRACE_MESSAGE_COMPONENTID</c> or
		/// <c>TRACE_MESSAGE_GUID</c> flag.
		/// </param>
		/// <param name="MessageNumber">
		/// Number that uniquely identifies each occurrence of the message. You must define the value specified for this parameter; the value
		/// should be meaningful to the application.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>Either the SessionHandle is NULL or specifies the NT Kernel Logger session handle.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>
		/// The session ran out of free buffers to write to. This can occur during high event rates because the disk subsystem is overloaded
		/// or the number of buffers is too small. Rather than blocking until more buffers become available, TraceMessage discards the event.
		/// Windows 2000 and Windows XP: Not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_OUTOFMEMORY</term>
		/// <term>
		/// The event is discarded because, although the buffer pool has not reached its maximum size, there is insufficient available memory
		/// to allocate an additional buffer and there is no buffer available to receive the event.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>MessageFlags contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>
		/// Data from a single event cannot span multiple buffers. A trace event is limited to the size of the event tracing session's buffer
		/// minus the size of the EVENT_TRACE_HEADER structure.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Providers call this function.</para>
		/// <para>The final __arglist parameter has the following requirements.</para>
		/// <para>
		/// A list of variable arguments to be appended to the message. Use this list to specify your provider-specific event data. The list
		/// must be composed of pairs of arguments, as described in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Data Type</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PVOID</term>
		/// <term>Pointer to the argument data.</term>
		/// </item>
		/// <item>
		/// <term>size_t</term>
		/// <term>The size of the argument data, in bytes.</term>
		/// </item>
		/// </list>
		/// <para>Terminate the list using an argument pair consisting of a pointer to <c>NULL</c> and zero.</para>
		/// <para>
		/// The caller must ensure that the sum of the sizes of the arguments + 72 does not exceed the size of the event tracing session's buffer.
		/// </para>
		/// <para>
		/// Using the <c>TraceEvent</c> function is the preferred way to log an event. On Windows Vista, you should use the <c>EventWrite</c>
		/// function to log events.
		/// </para>
		/// <para>The trace events are written in the order in which they occur.</para>
		/// <para>
		/// If you need to access message tracing functionality from a wrapper function, call the <c>TraceMessageVa</c> version of this function.
		/// </para>
		/// <para>
		/// Consumers will have to use the EventCallback callback to receive and process the events if the MessageFlags parameter does not
		/// contain the TRACE_MESSAGE_GUID flag. If you do not specify the TRACE_MESSAGE_GUID flag, the consumer will not be able to use the
		/// EventClassCallback because the <c>Header.Guid</c> member of the <c>EVENT_TRACE</c> structure will not contain the event trace
		/// class GUID.
		/// </para>
		/// <para>
		/// Note that the members of the <c>EVENT_TRACE</c> and <c>EVENT_TRACE_HEADER</c> structures that correspond to the MessageFlags
		/// flags are set only if the corresponding flag is specified. For example, the <c>ThreadId</c> and <c>ProcessId</c> members of
		/// <c>EVENT_TRACE_HEADER</c> are populated only if you specify the TRACE_MESSAGE_SYSTEMINFO flag.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/etw/tracemessage ULONG TraceMessage( _In_ TRACEHANDLE SessionHandle, _In_ ULONG
		// MessageFlags, _In_ LPGUID MessageGuid, _In_ USHORT MessageNumber, ... );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Evntrace.h", MSDNShortId = "5d81c851-d47e-43f8-97b0-87156f36119a")]
		public static extern Win32Error TraceMessage(TRACEHANDLE SessionHandle, TRACE_MESSAGE MessageFlags, in Guid MessageGuid, ushort MessageNumber, __arglist);

		/// <summary>The <c>TraceMessageVa</c> function sends an informational message with variable arguments to an event tracing session.</summary>
		/// <param name="SessionHandle">
		/// Handle to the event tracing session that records the event. The provider obtains the handle when it calls the
		/// <c>GetTraceLoggerHandle</c> function in its ControlCallback implementation.
		/// </param>
		/// <param name="MessageFlags">
		/// <para>
		/// Adds additional information to the beginning of the provider-specific data section of the event. The provider-specific data
		/// section of the event will contain data only for those flags that are set. The variable list of argument data will follow this
		/// information. This parameter can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRACE_MESSAGE_GUID</term>
		/// <term>Include the event trace class GUID in the message. The MessageGuid parameter contains the event trace class GUID.</term>
		/// </item>
		/// <item>
		/// <term>TRACE_MESSAGE_SEQUENCE</term>
		/// <term>
		/// Include a sequence number in the message. The sequence number starts at one. To use this flag, the controller must have set the
		/// EVENT_TRACE_USE_GLOBAL_SEQUENCE or EVENT_TRACE_USE_LOCAL_SEQUENCE log file mode when creating the session.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TRACE_MESSAGE_SYSTEMINFO</term>
		/// <term>Include the thread identifier and process identifier in the message.</term>
		/// </item>
		/// <item>
		/// <term>TRACE_MESSAGE_TIMESTAMP</term>
		/// <term>Include a time stamp in the message.</term>
		/// </item>
		/// </list>
		/// <para>The information is included in the event data in the following order:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Sequence number</term>
		/// </item>
		/// <item>
		/// <term>Event trace class GUID</term>
		/// </item>
		/// <item>
		/// <term>Time stamp</term>
		/// </item>
		/// <item>
		/// <term>Thread identifier</term>
		/// </item>
		/// <item>
		/// <term>Process identifier</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="MessageGuid">Class GUID that identifies the event trace message.</param>
		/// <param name="MessageNumber">
		/// Number that uniquely identifies each occurrence of the message. You must define the value specified for this parameter; the value
		/// should be meaningful to the application.
		/// </param>
		/// <param name="MessageArgList">
		/// <para>
		/// List of variable arguments to be appended to the message. The list must be composed of pairs of arguments, as described in the
		/// following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Data Type</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PVOID</term>
		/// <term>Pointer to the argument data.</term>
		/// </item>
		/// <item>
		/// <term>size_t</term>
		/// <term>The size of the argument data, in bytes.</term>
		/// </item>
		/// </list>
		/// <para>Terminate the list using an argument pair consisting of a pointer to <c>NULL</c> and zero.</para>
		/// <para>
		/// The caller must ensure that the sum of the sizes of the arguments + 72 does not exceed the size of the event tracing session's buffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>Either the SessionHandle is NULL or specifies the NT Kernel Logger session handle.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>
		/// The session ran out of free buffers to write to. This can occur during high event rates because the disk subsystem is overloaded
		/// or the number of buffers is too small. Rather than blocking until more buffers become available, TraceMessage discards the event.
		/// Windows 2000 and Windows XP: Not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_OUTOFMEMORY</term>
		/// <term>
		/// The event is discarded because, although the buffer pool has not reached its maximum size, there is insufficient available memory
		/// to allocate an additional buffer and there is no buffer available to receive the event.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>MessageFlags contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>
		/// Data from a single event cannot span multiple buffers. A trace event is limited to the size of the event tracing session's buffer
		/// minus the size of the EVENT_TRACE_HEADER structure.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Providers call this function.</para>
		/// <para>
		/// Using the <c>TraceEvent</c> function is the preferred way to log an event. On Windows Vista, you should use the <c>EventWrite</c>
		/// function to log events.
		/// </para>
		/// <para>The trace events are written in the order in which they occur.</para>
		/// <para>
		/// If you do not need to access the message tracing functionality from a wrapper function, you can call the <c>TraceMessage</c>
		/// version of this function.
		/// </para>
		/// <para>
		/// Consumers will have to use the EventCallback callback to receive and process the events if the MessageFlags parameter does not
		/// contain the TRACE_MESSAGE_GUID flag. If you do not specify the TRACE_MESSAGE_GUID flag, the consumer will not be able to use the
		/// EventClassCallback because the <c>Header.Guid</c> member of the <c>EVENT_TRACE</c> structure will not contain the event trace
		/// class GUID.
		/// </para>
		/// <para>
		/// Note that the members of the <c>EVENT_TRACE</c> and <c>EVENT_TRACE_HEADER</c> structures that correspond to the MessageFlags
		/// flags are set only if the corresponding flag is specified. For example, the <c>ThreadId</c> and <c>ProcessId</c> members of
		/// <c>EVENT_TRACE_HEADER</c> are populated only if you specify the TRACE_MESSAGE_SYSTEMINFO flag.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/tracemessageva ULONG TraceMessageVa( _In_ TRACEHANDLE SessionHandle, _In_
		// ULONG MessageFlags, _In_ LPGUID MessageGuid, _In_ USHORT MessageNumber, _In_ va_list MessageArgList );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Evntrace.h", MSDNShortId = "2cfb7226-fd29-432e-abfd-bd10c6344a67")]
		public static extern Win32Error TraceMessageVa(TRACEHANDLE SessionHandle, TRACE_MESSAGE MessageFlags, in Guid MessageGuid, ushort MessageNumber, IntPtr MessageArgList);

		/// <summary>The <c>TraceQueryInformation</c> function queries event tracing session settings for the specified information class.</summary>
		/// <param name="SessionHandle">
		/// A handle of the event tracing session that wants to capture the specified information. The <c>StartTrace</c> function returns
		/// this handle.
		/// </param>
		/// <param name="InformationClass">
		/// The information class to query. The information that the class captures is included in the extended data section of the event.
		/// For a list of information classes that you can query, see the <c>TRACE_QUERY_INFO_CLASS</c> enumeration.
		/// </param>
		/// <param name="TraceInformation">
		/// A pointer to a buffer to receive the returned information class specific data. The information class determines the contents of
		/// this parameter. For example, for the <c>TraceStackTracingInfo</c> information class, this parameter is an array of
		/// <c>CLASSIC_EVENT_ID</c> structures. The structures specify the event GUIDs for which stack tracing is enabled. The array is
		/// limited to 256 elements.
		/// </param>
		/// <param name="InformationLength">
		/// The size, in bytes, of the data returned in the TraceInformation buffer. If the function fails, this value indicates the required
		/// size of the TraceInformation buffer that is needed.
		/// </param>
		/// <param name="ReturnLength">
		/// A pointer a value that receives the size, in bytes, of the specific data returned in the TraceInformation buffer.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_LENGTH</term>
		/// <term>
		/// The program issued a command but the command length is incorrect. This error is returned if the InformationLength parameter is
		/// less than a minimum size.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The parameter is incorrect.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The <c>TraceQueryInformation</c> function queries event tracing session settings for the specified information class. Call this
		/// function after calling <c>StartTrace</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/etw/tracequeryinformation ULONG WINAPI TraceQueryInformation( _In_ TRACEHANDLE
		// SessionHandle, _In_ TRACE_QUERY_INFO_CLASS InformationClass, _Out_ PVOID TraceInformation, _In_ ULONG InformationLength, _Out_opt_
		// PULONG ReturnLength );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Evntrace.h", MSDNShortId = "3CC91F7C-7F82-4B3B-AA50-FE03CFEC0278")]
		public static extern Win32Error TraceQueryInformation(TRACEHANDLE SessionHandle, TRACE_QUERY_INFO_CLASS InformationClass, IntPtr TraceInformation, uint InformationLength, out uint ReturnLength);

		/// <summary>
		/// The <c>TraceSetInformation</c> function enables or disables event tracing session settings for the specified information class.
		/// </summary>
		/// <param name="SessionHandle">
		/// A handle of the event tracing session that wants to capture the specified information. The <c>StartTrace</c> function returns
		/// this handle.
		/// </param>
		/// <param name="InformationClass">
		/// The information class to enable or disable. The information that the class captures is included in the extended data section of
		/// the event. For a list of information classes that you can enable, see the <c>TRACE_INFO_CLASS</c> enumeration.
		/// </param>
		/// <param name="TraceInformation">
		/// A pointer to information class specific data; the information class determines the contents of this parameter. For example, for
		/// the <c>TraceStackTracingInfo</c> information class, this parameter is an array of <c>CLASSIC_EVENT_ID</c> structures. The
		/// structures specify the event GUIDs for which stack tracing is enabled. The array is limited to 256 elements.
		/// </param>
		/// <param name="InformationLength">The size, in bytes, of the data in the TraceInformation buffer.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_LENGTH</term>
		/// <term>
		/// The program issued a command but the command length is incorrect. This error is returned if the InformationLength parameter is
		/// less than a minimum size.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The parameter is incorrect.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Call this function after calling <c>StartTrace</c>.</para>
		/// <para>
		/// If the InformationClass parameter is set to <c>TraceStackTracingInfo</c>, calling this function enables stack tracing of the
		/// specified kernel events. Subsequent calls to this function overwrites the previous list of kernel events for which stack tracing
		/// is enabled. To disable stack tracing, call this function with InformationClass set to <c>TraceStackTracingInfo</c> and
		/// InformationLength set to 0.
		/// </para>
		/// <para>
		/// The extended data section of the event will include the call stack. The <c>StackWalk_Event</c> MOF class defines the layout of
		/// the extended data.
		/// </para>
		/// <para>
		/// Typically, on 64-bit computers, you cannot capture the kernel stack in certain contexts when page faults are not allowed. To
		/// enable walking the kernel stack on x64, set the <c>DisablePagingExecutive</c> Memory Management registry value to 1. The
		/// <c>DisablePagingExecutive</c> registry value is located under the following registry key:
		/// </para>
		/// <para><c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Session Manager\Memory Management</c></para>
		/// <para>You should consider the cost of setting this registry value before doing so.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/tracesetinformation ULONG WINAPI TraceSetInformation( _In_ TRACEHANDLE
		// SessionHandle, _In_ TRACE_INFO_CLASS InformationClass, _In_ PVOID TraceInformation, _In_ ULONG InformationLength );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Evntrace.h", MSDNShortId = "f4cdbe32-6885-4844-add5-560961c3dd1d")]
		public static extern Win32Error TraceSetInformation(TRACEHANDLE SessionHandle, TRACE_QUERY_INFO_CLASS InformationClass, IntPtr TraceInformation, uint InformationLength);

		/// <summary>The <c>UnregisterTraceGuids</c> function unregisters an event trace provider and its event trace classes.</summary>
		/// <param name="RegistrationHandle">
		/// Handle to the event trace provider, obtained from an earlier call to the <c>RegisterTraceGuids</c> function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The RegistrationHandle parameter does not specify the handle to a registered provider or is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Providers call this function.</para>
		/// <para>The event trace provider must have been registered previously by calling the <c>RegisterTraceGuids</c> function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/unregistertraceguids ULONG UnregisterTraceGuids( _In_ TRACEHANDLE
		// RegistrationHandle );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Evntrace.h", MSDNShortId = "1fa10f66-a78b-4f40-9518-72d48365246e")]
		public static extern Win32Error UnregisterTraceGuids(TRACEHANDLE RegistrationHandle);

		/// <summary>
		/// <para>The <c>UpdateTrace</c> function updates the property setting of the specified event tracing session.</para>
		/// <para>The <c>ControlTrace</c> function supersedes this function.</para>
		/// </summary>
		/// <param name="SessionHandle">
		/// Handle to the event tracing session to update, or <c>NULL</c>. You must specify SessionHandle if SessionName is <c>NULL</c>.
		/// However, ETW ignores the handle if SessionName is not <c>NULL</c>. The handle is returned by the <c>StartTrace</c> function.
		/// </param>
		/// <param name="SessionName">
		/// <para>
		/// Pointer to a null-terminated string that specifies the name of the event tracing session to update, or <c>NULL</c>. You must
		/// specify SessionName if SessionHandle is <c>NULL</c>.
		/// </para>
		/// <para>To specify the NT Kernel Logger session, set SessionName to <c>KERNEL_LOGGER_NAME</c>.</para>
		/// </param>
		/// <param name="Properties">
		/// <para>Pointer to an initialized <c>EVENT_TRACE_PROPERTIES</c> structure.</para>
		/// <para>
		/// On input, the members must specify the new values for the properties to update. For information on which properties you can
		/// update, see Remarks.
		/// </para>
		/// <para>On output, the structure members contains the updated settings and statistics for the event tracing session.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>
		/// If the function fails, the return value is one of the system error codes. The following table includes some common errors and
		/// their causes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_LENGTH</term>
		/// <term>The BufferSize member of the Wnode member of Properties specifies an incorrect size.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// One of the following is true: Windows Server 2003 and Windows XP: The Guid member of the Wnode structure is
		/// SystemTraceControlGuid, but the SessionName parameter is not KERNEL_LOGGER_NAME.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Only users with administrative privileges, users in the Performance Log Users group, and services running as LocalSystem,
		/// LocalService, NetworkService can control event tracing sessions. To grant a restricted user the ability to control trace
		/// sessions, add them to the Performance Log Users group. Windows XP and Windows 2000: Anyone can control a trace session.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Controllers call this function.</para>
		/// <para>On input, the members must specify the new values for the properties to update. You can update the following properties.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Member</term>
		/// <term>Use</term>
		/// </listheader>
		/// <item>
		/// <term>EnableFlags</term>
		/// <term>
		/// Set this member to 0 to disable all kernel providers. Otherwise, you must specify the kernel providers that you want to enable or
		/// keep enabled. Applies only to NT Kernel Logger sessions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FlushTimer</term>
		/// <term>
		/// Set this member if you want to change the time to wait before flushing buffers. If this member is 0, the member is not updated.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LogFileNameOffset</term>
		/// <term>
		/// Set this member if you want to switch to another log file. If this member is 0, the file name is not updated. If the offset is
		/// not zero and you do not change the log file name, the function returns an error.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LogFileMode</term>
		/// <term>
		/// Set this member if you want to turn EVENT_TRACE_REAL_TIME_MODE on and off. To turn real time consuming off, set this member to 0.
		/// To turn real time consuming on, set this member to EVENT_TRACE_REAL_TIME_MODE and it will be OR'd with the current modes.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MaximumBuffers</term>
		/// <term>
		/// Set set this member if you want to change the maximum number of buffers that ETW uses. If this member is 0, the member is not updated.
		/// </term>
		/// </item>
		/// </list>
		/// <para>For private logger sessions, you can only update <c>LogFileNameOffset</c> and <c>FlushTimer</c>.</para>
		/// <para>
		/// If you are using a newly initialized <c>EVENT_TRACE_PROPERTIES</c> structure, the only members you need to specify, other than
		/// the members you are updating, are <c>Wnode.BufferSize</c>, <c>Wnode.Guid</c>, and <c>Wnode.Flags</c>.
		/// </para>
		/// <para>
		/// If you use the property structure you passed to <c>StartTrace</c>, make sure the <c>LogFileNameOffset</c> member is 0 unless you
		/// are changing the log file name.
		/// </para>
		/// <para>
		/// If you call the <c>ControlTrace</c> function to query the current session properties and then update those properties to update
		/// the session, make sure you set <c>LogFileNameOffset</c> to 0 (unless you are changing the log file name) and set
		/// <c>EVENT_TRACE_PROPERTIES.Wnode.Flags</c> to <c>WNODE_FLAG_TRACED_GUID</c>.
		/// </para>
		/// <para>To obtain the property settings and session statistics for an event tracing session, call the <c>ControlTrace</c> function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/updatetrace ULONG UpdateTrace( _In_ TRACEHANDLE SessionHandle, _In_ LPCTSTR
		// SessionName, _Inout_ PEVENT_TRACE_PROPERTIES Properties );
		[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Evntrace.h", MSDNShortId = "40e6deaf-7363-45eb-80d0-bc3f33760875")]
		public static extern Win32Error UpdateTrace(TRACEHANDLE SessionHandle, string SessionName, ref EVENT_TRACE_PROPERTIES Properties);

		// ULONG EnableTrace( _In_ ULONG Enable, _In_ ULONG EnableFlag, _In_ ULONG EnableLevel, _In_ LPCGUID ControlGuid, _In_ TRACEHANDLE
		// SessionHandle );
		[DllImport(Lib.AdvApi32, SetLastError = false, EntryPoint = "EnableTrace")]
		private static extern Win32Error InternalEnableTrace([MarshalAs(UnmanagedType.Bool)] bool Enable, uint EnableFlag, uint EnableLevel, in Guid ControlGuid, TRACEHANDLE SessionHandle);

		/// <summary>Identifies the kernel event for which you want to enable call stack tracing.</summary>
		/// <remarks>
		/// To enable the <c>read</c> event type for <c>disk IO</c> events, set <c>GUID</c> to 3d6fa8d4-fe05-11d0-9dda-00c04fd7ba7c and
		/// <c>Type</c> to 10.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/etw/classic-event-id typedef struct _CLASSIC_EVENT_ID { GUID EventGuid; UCHAR Type;
		// UCHAR Reserved[7]; } CLASSIC_EVENT_ID, *PCLASSIC_EVENT_ID;
		[PInvokeData("Evntrace.h", MSDNShortId = "cbd77002-466b-40e6-85a5-cd872aef7d51")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CLASSIC_EVENT_ID
		{
			/// <summary>The GUID that identifies the kernel event class.</summary>
			public Guid EventGuid;

			/// <summary>The event type that identifies the event within the kernel event class to enable.</summary>
			public byte Type;

			/// <summary>Reserved.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
			public byte[] Reserved;
		}

		/// <summary>The <c>ENABLE_TRACE_PARAMETERS</c> structure defines the information used to enable a provider.</summary>
		/// <remarks>
		/// <para>
		/// The <c>ENABLE_TRACE_PARAMETERS</c> structure is a version 2 structure and replaces the <c>ENABLE_TRACE_PARAMETERS_V1</c>
		/// structure for use with the <c>EnableTraceEx2</c> function.
		/// </para>
		/// <para>
		/// On Windows 8.1,Windows Server 2012 R2, and later, event payload , scope, and stack walk filters can be used by the
		/// <c>EnableTraceEx2</c> function and the <c>ENABLE_TRACE_PARAMETERS</c> and <c>EVENT_FILTER_DESCRIPTOR</c> structures to filter on
		/// specific conditions in a logger session. For more information on event payload filters, see the <c>EnableTraceEx2</c>,
		/// <c>TdhCreatePayloadFilter</c>, and <c>TdhAggregatePayloadFilters</c> functions and the <c>EVENT_FILTER_DESCRIPTOR</c> and
		/// <c>PAYLOAD_FILTER_PREDICATE</c> structures.
		/// </para>
		/// <para>
		/// Typically, on 64-bit computers, you cannot capture the kernel stack in certain contexts when page faults are not allowed. To
		/// enable walking the kernel stack on x64, set the <c>DisablePagingExecutive</c> Memory Management registry value to 1. The
		/// <c>DisablePagingExecutive</c> registry value is located under the following registry key:
		/// </para>
		/// <para><c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Session Manager\Memory Management</c></para>
		/// <para>You should consider the cost of setting this registry value before doing so.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/enable-trace-parameters typedef struct _ENABLE_TRACE_PARAMETERS { ULONG
		// Version; ULONG EnableProperty; ULONG ControlFlags; GUID SourceId; PEVENT_FILTER_DESCRIPTOR EnableFilterDesc; ULONG
		// FilterDescCount; } ENABLE_TRACE_PARAMETERS, *PENABLE_TRACE_PARAMETERS;
		[PInvokeData("evntrace.h", MSDNShortId = "bc7cf886-f763-428a-9e75-031e8df26554")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ENABLE_TRACE_PARAMETERS
		{
			/// <summary>Set to <c>ENABLE_TRACE_PARAMETERS_VERSION_2</c>.</summary>
			public uint Version;

			/// <summary>
			/// Optional settings that ETW can include when writing the event. Some settings write extra data to the <c>extended data
			/// item</c> section of each event. Other settings refine which events will be included. To use these optional settings, specify
			/// one or more of the following flags; otherwise, set to zero.
			/// </summary>
			public uint EnableProperty;

			/// <summary>Reserved. Set to 0.</summary>
			public uint ControlFlags;

			/// <summary>
			/// A GUID that uniquely identifies the session that is enabling or disabling the provider. If the provider does not implement
			/// <c>EnableCallback</c>, the GUID is not used.
			/// </summary>
			public Guid SourceId;

			/// <summary>
			/// <para>
			/// A pointer to an array of <c>EVENT_FILTER_DESCRIPTOR</c> structures that points to the filter data. The number of elements in
			/// the array is specified in the <c>FilterDescCount</c> member. There can only be one filter for a specific filter type as
			/// specified by the <c>Type</c> member of the <c>EVENT_FILTER_DESCRIPTOR</c> structure.
			/// </para>
			/// <para>
			/// For a schematized filter (a <c>Type</c> member equal to <c>EVENT_FILTER_TYPE_SCHEMATIZED</c>), the provider uses filter data
			/// to prevent events that match the filter criteria from being written to the session. The provider determines the layout of the
			/// data and how it applies the filter to the event's data. A session can pass only one schematized filter to the provider.
			/// </para>
			/// <para>
			/// A session can call the <c>TdhEnumerateProviderFilters</c> function to determine the schematized filters that it can pass to
			/// the provider.
			/// </para>
			/// </summary>
			public IntPtr EnableFilterDesc;

			/// <summary>
			/// <para>
			/// The number of elements (filters) in the <c>EVENT_FILTER_DESCRIPTOR</c> array pointed to by <c>EnableFilterDesc</c> member.
			/// </para>
			/// <para>
			/// The <c>FilterDescCount</c> member should match the number of <c>EVENT_FILTER_DESCRIPTOR</c> structures in the array pointed
			/// to by the <c>EnableFilterDesc</c> member.
			/// </para>
			/// <para>.</para>
			/// </summary>
			public uint FilterDescCount;
		}

		/// <summary>The <c>ENABLE_TRACE_PARAMETERS_V1</c> structure defines the information used to enable a provider.</summary>
		/// <remarks>
		/// <para>
		/// The <c>ENABLE_TRACE_PARAMETERS_V1</c> structure is used with the <c>EnableTrace</c> and <c>EnableTraceEx</c> functions. The
		/// <c>ENABLE_TRACE_PARAMETERS</c> structure is a version 2 structure and replaces the <c>ENABLE_TRACE_PARAMETERS_V1</c> structure
		/// for use with the <c>EnableTraceEx2</c> function.
		/// </para>
		/// <para>
		/// Typically, on 64-bit computers, you cannot capture the kernel stack in certain contexts when page faults are not allowed. To
		/// enable walking the kernel stack on x64, set the <c>DisablePagingExecutive</c> Memory Management registry value to 1. The
		/// <c>DisablePagingExecutive</c> registry value is located under the following registry key:
		/// </para>
		/// <para><c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Session Manager\Memory Management</c></para>
		/// <para>You should consider the cost of setting this registry value before doing so.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/etw/enable-trace-parameters-v1 typedef struct _ENABLE_TRACE_PARAMETERS_V1 { ULONG
		// Version; ULONG EnableProperty; ULONG ControlFlags; GUID SourceId; PEVENT_FILTER_DESCRIPTOR EnableFilterDesc; }
		// ENABLE_TRACE_PARAMETERS_V1, *PENABLE_TRACE_PARAMETERS_V1;
		[PInvokeData("evntrace.h", MSDNShortId = "6FC5EF54-2D05-4246-A8E8-7FDA0ABA0D4B")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ENABLE_TRACE_PARAMETERS_V1
		{
			/// <summary>Set to <c>ENABLE_TRACE_PARAMETERS_VERSION</c>.</summary>
			public uint Version;

			/// <summary>
			/// <para>
			/// Optional information that ETW can include when writing the event. The data is written to the <c>extended data item</c>
			/// section of the event. To include the optional information, specify one or more of the following flags; otherwise, set to zero.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>EVENT_ENABLE_PROPERTY_SID</term>
			/// <term>Include in the extended data the security identifier (SID) of the user.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_ENABLE_PROPERTY_TS_ID</term>
			/// <term>Include in the extended data the terminal session identifier.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_ENABLE_PROPERTY_STACK_TRACE</term>
			/// <term>
			/// Include in the extended data a call stack trace for events written using EventWrite. If you set
			/// EVENT_ENABLE_PROPERTY_STACK_TRACE, ETW will drop the event if the total event size exceeds 64K. If the provider is logging
			/// events close in size to 64K maximum, it is possible that enabling stack capture will cause the event to be lost. If the stack
			/// is longer than the maximum number of frames (192), the frames will be cut from the bottom of the stack. For consumers, the
			/// events will include the EVENT_EXTENDED_ITEM_STACK_TRACE32 or EVENT_EXTENDED_ITEM_STACK_TRACE64 extended item. Note that on
			/// 64-bit computers, 32-bit processes will receive 64-bit stack traces.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public uint EnableProperty;

			/// <summary>Reserved. Set to 0.</summary>
			public uint ControlFlags;

			/// <summary>
			/// A GUID that uniquely identifies the session that is enabling or disabling the provider. If the provider does not implement
			/// <c>EnableCallback</c>, the GUID is not used.
			/// </summary>
			public Guid SourceId;

			/// <summary>
			/// <para>
			/// An <c>EVENT_FILTER_DESCRIPTOR</c> structure that points to the filter data. The provider uses filter data to prevent events
			/// that match the filter criteria from being written to the session. The provider determines the layout of the data and how it
			/// applies the filter to the event's data. A session can pass only one filter to the provider.
			/// </para>
			/// <para>
			/// A session can call the <c>TdhEnumerateProviderFilters</c> function to determine the schematized filters that it can pass to
			/// the provider.
			/// </para>
			/// </summary>
			public IntPtr EnableFilterDesc;
		}

		/// <summary>The <c>ETW_BUFFER_CONTEXT</c> structure provides context information about the event.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/relogger/ns-relogger-_etw_buffer_context typedef struct _ETW_BUFFER_CONTEXT {
		// union { struct { UCHAR ProcessorNumber; UCHAR Alignment; } DUMMYSTRUCTNAME; USHORT ProcessorIndex; } DUMMYUNIONNAME; USHORT
		// LoggerId; } ETW_BUFFER_CONTEXT, *PETW_BUFFER_CONTEXT;
		[PInvokeData("relogger.h", MSDNShortId = "75577305-fb3f-40a2-8fe6-9cd82c3f4e69")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ETW_BUFFER_CONTEXT
		{
			/// <summary>The number of the CPU on which the provider process was running. The number is zero on a single processor computer.</summary>
			public byte ProcessorNumber;

			/// <summary>Alignment between events (always eight).</summary>
			public byte Alignment;

			/// <summary>Identifier of the session that logged the event.</summary>
			public ushort LoggerId;
		}

		/// <summary>Contains partition information pulled from an ETW trace. Most commonly used as a return structure for <c>QueryTraceProcessingHandle</c>.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/etw/etw-trace-partition-information typedef struct _ETW_TRACE_PARTITION_INFORMATION
		// { GUID PartitionId; GUID ParentId; ULONG64 Reserved; ULONG PartitionType; } ETW_TRACE_PARTITION_INFORMATION, *PETW_TRACE_PARTITION_INFORMATION;
		[PInvokeData("", MSDNShortId = "8D8F8E79-B273-417A-B8C2-6CE4FC454C07")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ETW_TRACE_PARTITION_INFORMATION
		{
			/// <summary>GUID to identify the machine.</summary>
			public Guid PartitionId;

			/// <summary>
			/// GUID that identifies the partition instance that contains the traced partition. If the traced partition is a host, then
			/// <c>ParentId</c> will be 0.
			/// </summary>
			public Guid ParentId;

			/// <summary>Reserved for future use.</summary>
			public ulong Reserved;

			/// <summary>
			/// <para>Enumeration value of the container type. the value may be one of the following:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>Process 1</term>
			/// <term>For events originating from inside a “Windows Server Container”.</term>
			/// </item>
			/// <item>
			/// <term>VmHost 2</term>
			/// <term>For events originating from inside a “Hyper-V Container”.</term>
			/// </item>
			/// <item>
			/// <term>VmHostedUvm 3</term>
			/// <term>For events originating from a “Hyper-V Container” template virtual machine.</term>
			/// </item>
			/// <item>
			/// <term>VmDirectUvm 4</term>
			/// <term>For events originating from applications running with Windows Defender Application Guard.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint PartitionType;
		}

		/// <summary>
		/// The <c>EVENT_EXTENDED_ITEM_INSTANCE</c> structure defines the relationship between events if TraceEventInstance was used to log
		/// related events.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_instance typedef struct
		// _EVENT_EXTENDED_ITEM_INSTANCE { ULONG InstanceId; ULONG ParentInstanceId; GUID ParentGuid; } EVENT_EXTENDED_ITEM_INSTANCE, *PEVENT_EXTENDED_ITEM_INSTANCE;
		[PInvokeData("evntcons.h", MSDNShortId = "3def638b-cab2-4b5d-b409-7285caa77ae1")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_EXTENDED_ITEM_INSTANCE
		{
			/// <summary>A unique transaction identifier that maps an event to a specific transaction.</summary>
			public uint InstanceId;

			/// <summary>A unique transaction identifier of a parent event if you are mapping a hierarchical relationship.</summary>
			public uint ParentInstanceId;

			/// <summary>
			/// A GUID that uniquely identifies the provider that logged the event referenced by the <c>ParentInstanceId</c> member.
			/// </summary>
			public Guid ParentGuid;
		}

		/// <summary>The <c>EVENT_EXTENDED_ITEM_RELATED_ACTIVITYID</c> structure defines the parent event of this event.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_related_activityid typedef struct
		// _EVENT_EXTENDED_ITEM_RELATED_ACTIVITYID { GUID RelatedActivityId; } EVENT_EXTENDED_ITEM_RELATED_ACTIVITYID, *PEVENT_EXTENDED_ITEM_RELATED_ACTIVITYID;
		[PInvokeData("evntcons.h", MSDNShortId = "cabc11ca-e65e-4ffd-9832-7fb4f77417e4")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_EXTENDED_ITEM_RELATED_ACTIVITYID
		{
			/// <summary>
			/// A GUID that uniquely identifies the parent activity to which this activity is related. The identifier is specified in the
			/// RelatedActivityId parameter passed to the EventWriteTransfer function.
			/// </summary>
			public Guid RelatedActivityId;
		}

		/// <summary>The <c>EVENT_EXTENDED_ITEM_STACK_TRACE32</c> structure defines a call stack on a 32-bit computer.</summary>
		/// <remarks>
		/// The <c>DataSize</c> member of EVENT_HEADER_EXTENDED_DATA_ITEM contains the size of this structure. To determine the number of
		/// addresses in the array, subtract from <c>DataSize</c> and then divide by .
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_stack_trace32 typedef struct
		// _EVENT_EXTENDED_ITEM_STACK_TRACE32 { ULONG64 MatchId; ULONG Address[ANYSIZE_ARRAY]; } EVENT_EXTENDED_ITEM_STACK_TRACE32, *PEVENT_EXTENDED_ITEM_STACK_TRACE32;
		[PInvokeData("evntcons.h", MSDNShortId = "6898951a-5719-47aa-a219-97f82095686f")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_EXTENDED_ITEM_STACK_TRACE32
		{
			/// <summary>
			/// <para>
			/// A unique identifier that you use to match the kernel-mode calls to the user-mode calls; the kernel-mode calls and user-mode
			/// calls are captured in separate events if the environment prevents both from being captured in the same event. If the
			/// kernel-mode and user-mode calls were captured in the same event, the value is zero.
			/// </para>
			/// <para>
			/// Typically, on 32-bit computers, you can always capture both the kernel-mode and user-mode calls in the same event. However,
			/// if you use the frame pointer optimization compiler option, the stack may not be captured, captured incorrectly, or truncated.
			/// </para>
			/// </summary>
			public ulong MatchId;

			///// <summary>An array of call addresses on the stack.</summary>
			//public uint Address[ANYSIZE_ARRAY];
		}

		/// <summary>The <c>EVENT_EXTENDED_ITEM_STACK_TRACE64</c> structure defines a call stack on a 64-bit computer.</summary>
		/// <remarks>
		/// The <c>DataSize</c> member of EVENT_HEADER_EXTENDED_DATA_ITEM contains the size of this structure. To determine the number of
		/// addresses in the array, subtract from <c>DataSize</c> and then divide by .
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_stack_trace64 typedef struct
		// _EVENT_EXTENDED_ITEM_STACK_TRACE64 { ULONG64 MatchId; ULONG64 Address[ANYSIZE_ARRAY]; } EVENT_EXTENDED_ITEM_STACK_TRACE64, *PEVENT_EXTENDED_ITEM_STACK_TRACE64;
		[PInvokeData("evntcons.h", MSDNShortId = "3c9e0dcb-1eb9-4c9f-a4c8-5a93566be303")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_EXTENDED_ITEM_STACK_TRACE64
		{
			/// <summary>
			/// A unique identifier that you use to match the kernel-mode calls to the user-mode calls; the kernel-mode calls and user-mode
			/// calls are captured in separate events if the environment prevents both from being captured in the same event. If the
			/// kernel-mode and user-mode calls were captured in the same event, the value is zero.
			/// </summary>
			public ulong MatchId;

			///// <summary>An array of call addresses on the stack.</summary>
			//public ulong Address[ANYSIZE_ARRAY];
		}

		/// <summary>The <c>EVENT_EXTENDED_ITEM_TS_ID</c> defines the terminal session that logged the event.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_ts_id typedef struct
		// _EVENT_EXTENDED_ITEM_TS_ID { ULONG SessionId; } EVENT_EXTENDED_ITEM_TS_ID, *PEVENT_EXTENDED_ITEM_TS_ID;
		[PInvokeData("evntcons.h", MSDNShortId = "fcf1252d-9730-45a2-b601-60f76decd0dd")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_EXTENDED_ITEM_TS_ID
		{
			/// <summary>Identifies the terminal session that logged the event.</summary>
			public uint SessionId;
		}

		/// <summary>
		/// The <c>EVENT_FILTER_EVENT_ID</c> structure defines event IDs used in an EVENT_FILTER_DESCRIPTOR structure for an event ID or
		/// stack walk filter.
		/// </summary>
		/// <remarks>
		/// The <c>EVENT_FILTER_EVENT_ID</c> structure is used in the EVENT_FILTER_DESCRIPTOR structure when the <c>Type</c> member of the
		/// <c>EVENT_FILTER_DESCRIPTOR</c> is set to <c>EVENT_FILTER_TYPE_EVENT_ID</c> or <c>EVENT_FILTER_TYPE_STACKWALK</c>. This
		/// corresponds to an event ID filter (one of the possible scope filters) or a stack walk filter. The <c>EVENT_FILTER_EVENT_ID</c>
		/// structure contains an array of event IDs and a Boolean value that indicates if filtering is enabled or disabled for the specified
		/// event IDs.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/evntprov/ns-evntprov-event_filter_event_id typedef struct
		// _EVENT_FILTER_EVENT_ID { BOOLEAN FilterIn; UCHAR Reserved; USHORT Count; USHORT Events[ANYSIZE_ARRAY]; } EVENT_FILTER_EVENT_ID, *PEVENT_FILTER_EVENT_ID;
		[PInvokeData("evntprov.h", MSDNShortId = "D660D140-BE86-44F6-B1D2-E1B97300BD11")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_FILTER_EVENT_ID
		{
			/// <summary>
			/// <para>
			/// A value that indicates whether filtering should be enabled or disabled for the event IDs passed in the <c>Events</c> member.
			/// </para>
			/// <para>
			/// When this member is <c>TRUE</c>, filtering is enabled for the specified event IDs. When this member is <c>FALSE</c>,
			/// filtering is disabled for the event IDs.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool FilterIn;

			/// <summary>A reserved value.</summary>
			public byte Reserved;

			/// <summary>The number of event IDs in the <c>Events</c> member.</summary>
			public ushort Count;

			///// <summary>An array of event IDs.</summary>
			//public ushort Events[ANYSIZE_ARRAY];
		}

		/// <summary>
		/// <para>
		/// The <c>EVENT_FILTER_EVENT_NAME</c> structure defines event IDs used in an EVENT_FILTER_DESCRIPTOR structure for an event name or
		/// stalk walk name filter.
		/// </para>
		/// <para>
		/// This filter will only be applied to events that are otherwise enabled on the logging session, via level/keyword in the enable call.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/evntprov/ns-evntprov-event_filter_event_name typedef struct
		// _EVENT_FILTER_EVENT_NAME { ULONGLONG MatchAnyKeyword; ULONGLONG MatchAllKeyword; UCHAR Level; BOOLEAN FilterIn; USHORT NameCount;
		// UCHAR Names[ANYSIZE_ARRAY]; } EVENT_FILTER_EVENT_NAME, *PEVENT_FILTER_EVENT_NAME;
		[PInvokeData("evntprov.h", MSDNShortId = "85E8C8F8-31D4-42F1-9267-15F74E473D57")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_FILTER_EVENT_NAME
		{
			/// <summary>Bitmask of keywords that determine the category of events to filter on.</summary>
			public ulong MatchAnyKeyword;

			/// <summary>
			/// This bitmask is optional. This mask further restricts the category of events that you want to filter on. If the event's
			/// keyword meets the <c>MatchAnyKeyword</c> condition, the provider will filter the event only if all of the bits in this mask
			/// exist in the event's keyword. This mask is not used if <c>MatchAnyKeyword</c> is zero.
			/// </summary>
			public ulong MatchAllKeyword;

			/// <summary>Defines the severity level of the event to filter on.</summary>
			public TRACE_LEVEL Level;

			/// <summary>
			/// <para><c>True</c> to filter the events matching the provided names in; <c>false</c> to filter them out.</para>
			/// <para>
			/// When used for the <c>EVENT_FILTER_TYPE_STACKWALK_NAME</c> filter type, the filtered in events will have stacks collected for them.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)]
			public bool FilterIn;

			/// <summary>The number of names in the <c>Names</c> member.</summary>
			public ushort NameCount;

			///// <summary>An <c>NameCount</c> long array of null-terminated, UTF-8 event names.</summary>
			//public byte Names[ANYSIZE_ARRAY];
		}

		/// <summary>Defines the header data that must precede the filter data that is defined in the instrumentation manifest.</summary>
		/// <remarks>
		/// The filter data that you pass to the provider also includes a header. The following shows an example of how you would define a
		/// filter that contained three integers:
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/evntprov/ns-evntprov-event_filter_header typedef struct _EVENT_FILTER_HEADER {
		// USHORT Id; UCHAR Version; UCHAR Reserved[5]; ULONGLONG InstanceId; ULONG Size; ULONG NextOffset; } EVENT_FILTER_HEADER, *PEVENT_FILTER_HEADER;
		[PInvokeData("evntprov.h", MSDNShortId = "364a253d-f4c4-494a-af43-487c70912542")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_FILTER_HEADER
		{
			/// <summary>
			/// The identifier that identifies the filter in the manifest for a schematized filter. The <c>value</c> attribute of the
			/// <c>filter</c> element contains the identifier.
			/// </summary>
			public ushort Id;

			/// <summary>
			/// The version number of the filter for a schematized filter. The <c>version</c> attribute of the <c>filter</c> element contains
			/// the version number.
			/// </summary>
			public byte Version;

			/// <summary>Reserved</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
			public byte[] Reserved;

			/// <summary>
			/// <para>
			/// An identifier that identifies the session that passed the filter. ETW sets this value; the session must set this member to zero.
			/// </para>
			/// <para>
			/// Providers use this value to set the Filter parameter of EventWriteEx to prevent the event from being written to the session
			/// if the event data does not match the filter criteria (the provider determines the semantics of how the filter data is used in
			/// determining whether the event is written to the session).
			/// </para>
			/// </summary>
			public ulong InstanceId;

			/// <summary>The size, in bytes, of this header and the filter data that is appended to the end of this header.</summary>
			public uint Size;

			/// <summary>
			/// The offset from the beginning of this filter object to the next filter object. The value is zero if there are no more filter
			/// blocks. ETW sets this value; the session must set this member to zero.
			/// </summary>
			public uint NextOffset;
		}

		/// <summary>
		/// <para>
		/// The <c>EVENT_FILTER_LEVEL_KW</c> structure defines event IDs used in an EVENT_FILTER_DESCRIPTOR structure for a stack walk
		/// level-keyword filter.
		/// </para>
		/// <para>
		/// This filter is only applied to events that are otherwise enabled on the logging session, via a level/keyword in the enable call.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/evntprov/ns-evntprov-event_filter_level_kw typedef struct
		// _EVENT_FILTER_LEVEL_KW { ULONGLONG MatchAnyKeyword; ULONGLONG MatchAllKeyword; UCHAR Level; BOOLEAN FilterIn; }
		// EVENT_FILTER_LEVEL_KW, *PEVENT_FILTER_LEVEL_KW;
		[PInvokeData("evntprov.h", MSDNShortId = "2FE25C55-8028-4894-9DD8-FC997B7D9ADB")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_FILTER_LEVEL_KW
		{
			/// <summary>Bitmask of keywords that determine the category of events to filter on.</summary>
			public ulong MatchAnyKeyword;

			/// <summary>
			/// This bitmask is optional. This mask further restricts the category of events that you want to filter on. If the event's
			/// keyword meets the <c>MatchAnyKeyword</c> condition, the provider will filter the event only if all of the bits in this mask
			/// exist in the event's keyword. This mask is not used if <c>MatchAnyKeyword</c> is zero.
			/// </summary>
			public ulong MatchAllKeyword;

			/// <summary>Defines the severity level of the event to filter on.</summary>
			public TRACE_LEVEL Level;

			/// <summary>
			/// <para><c>true</c> to filter the events matching the provided names in; <c>false</c> to filter them out.</para>
			/// <para>If set to <c>true</c>, the filtered events will have stacks collected.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool FilterIn;
		}

		/// <summary>Defines information about the event.</summary>
		/// <remarks>
		/// <para>
		/// You can use the <c>KernelTime</c> and <c>UserTime</c> members to determine the CPU cost in units for a set of instructions (the
		/// values indicate the CPU usage charged to that thread at the time of logging). For example, if Event A and Event B are
		/// consecutively logged by the same thread and they have CPU usage numbers 150 and 175, then the activity that was performed by that
		/// thread between events A and B cost 25 CPU time units (175 – 150).
		/// </para>
		/// <para>
		/// The <c>TimerResolution</c> of the TRACE_LOGFILE_HEADER structure contains the resolution of the CPU usage timer in 100-nanosecond
		/// units. You can use the timer resolution with the kernel time and user time values to determine the amount of CPU time that the
		/// set of instructions used. For example, if the timer resolution is 156,250, then 25 CPU time units is 0.39 seconds (156,250 * 25 *
		/// 100 / 1,000,000,000). This is the amount of CPU time (not elapsed wall clock time) used by the set of instructions between events
		/// A and B.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntcons/ns-evntcons-_event_header typedef struct _EVENT_HEADER { USHORT
		// Size; USHORT HeaderType; USHORT Flags; USHORT EventProperty; ULONG ThreadId; ULONG ProcessId; LARGE_INTEGER TimeStamp; GUID
		// ProviderId; EVENT_DESCRIPTOR EventDescriptor; union { struct { ULONG KernelTime; ULONG UserTime; } DUMMYSTRUCTNAME; ULONG64
		// ProcessorTime; } DUMMYUNIONNAME; GUID ActivityId; } EVENT_HEADER, *PEVENT_HEADER;
		[PInvokeData("evntcons.h", MSDNShortId = "479091ae-7229-433b-b93b-8da6cc18df89")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_HEADER
		{
			/// <summary>Size of the event record, in bytes.</summary>
			public ushort Size;

			/// <summary>Reserved.</summary>
			public ushort HeaderType;

			/// <summary>
			/// Flags that provide information about the event such as the type of session it was logged to and if the event contains
			/// extended data. This member can contain one or more of the following flags.
			/// </summary>
			public ushort Flags;

			/// <summary>Indicates the source to use for parsing the event data.</summary>
			public ushort EventProperty;

			/// <summary>Identifies the thread that generated the event.</summary>
			public uint ThreadId;

			/// <summary>Identifies the process that generated the event.</summary>
			public uint ProcessId;

			/// <summary>
			/// Contains the time that the event occurred. The resolution is system time unless the <c>ProcessTraceMode</c> member of
			/// EVENT_TRACE_LOGFILE contains the PROCESS_TRACE_MODE_RAW_TIMESTAMP flag, in which case the resolution depends on the value of
			/// the <c>Wnode.ClientContext</c> member of EVENT_TRACE_PROPERTIES at the time the controller created the session.
			/// </summary>
			public FILETIME TimeStamp;

			/// <summary>GUID that uniquely identifies the provider that logged the event.</summary>
			public Guid ProviderId;

			/// <summary>Defines the information about the event such as the event identifier and severity level. For details, see EVENT_DESCRIPTOR.</summary>
			public EVENT_DESCRIPTOR EventDescriptor;

			/// <summary/>
			public DUMMYUNION Union;

			/// <summary>Identifier that relates two events. For details, see EventWriteTransfer.</summary>
			public Guid ActivityId;

			/// <summary></summary>
			[StructLayout(LayoutKind.Explicit)]
			public struct DUMMYUNION
			{
				/// <summary>
				/// Elapsed execution time for kernel-mode instructions, in CPU ticks. If you are using a private session, use the value in
				/// the ProcessorTime member instead.
				/// </summary>
				[FieldOffset(0)]
				public uint KernelTime;

				/// <summary>
				/// Elapsed execution time for user-mode instructions, in CPU ticks. If you are using a private session, use the value in the
				/// ProcessorTime member instead.
				/// </summary>
				[FieldOffset(4)]
				public uint UserTime;

				/// <summary>For private sessions, the elapsed execution time for user-mode instructions, in CPU ticks.</summary>
				[FieldOffset(0)]
				public ulong ProcessorTime;
			}
		}

		/// <summary>
		/// The <c>EVENT_HEADER_EXTENDED_DATA_ITEM</c> structure defines the extended data that ETW collects as part of the event data.
		/// </summary>
		[PInvokeData("evntcons.h", MSDNShortId = "aa363760")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_HEADER_EXTENDED_DATA_ITEM
		{
			/// <summary>Reserved.</summary>
			public ushort Reserved1;

			/// <summary>
			/// <para>Type of extended data. The following are possible values.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>EVENT_HEADER_EXT_TYPE_RELATED_ACTIVITYID</term>
			/// <term>
			/// The DataPtr member points to an EVENT_EXTENDED_ITEM_RELATED_ACTIVITYID structure that contains the related activity
			/// identifier if you called EventWriteTransfer to write the event.
			/// </term>
			/// </item>
			/// <item>
			/// <term>EVENT_HEADER_EXT_TYPE_SID</term>
			/// <term>
			/// The DataPtr member points to a SID structure that contains the security identifier (SID) of the user that logged the event.
			/// ETW includes the SID if you set the EnableProperty parameter of EnableTraceEx to EVENT_ENABLE_PROPERTY_SID.
			/// </term>
			/// </item>
			/// <item>
			/// <term>EVENT_HEADER_EXT_TYPE_TS_ID</term>
			/// <term>
			/// The DataPtr member points to an EVENT_EXTENDED_ITEM_TS_ID structure that contains the terminal session identifier. ETW
			/// includes the terminal session identifier if you set the EnableProperty parameter of EnableTraceEx to EVENT_ENABLE_PROPERTY_TS_ID.
			/// </term>
			/// </item>
			/// <item>
			/// <term>EVENT_HEADER_EXT_TYPE_INSTANCE_INFO</term>
			/// <term>
			/// The DataPtr member points to an EVENT_EXTENDED_ITEM_INSTANCE structure that contains the activity identifier if you called
			/// TraceEventInstance to write the event.
			/// </term>
			/// </item>
			/// <item>
			/// <term>EVENT_HEADER_EXT_TYPE_STACK_TRACE32</term>
			/// <term>
			/// The DataPtr member points to an EVENT_EXTENDED_ITEM_STACK_TRACE32 structure that contains the call stack if the event is
			/// captured on a 32-bit computer.
			/// </term>
			/// </item>
			/// <item>
			/// <term>EVENT_HEADER_EXT_TYPE_STACK_TRACE64</term>
			/// <term>
			/// The DataPtr member points to an EVENT_EXTENDED_ITEM_STACK_TRACE64 structure that contains the call stack if the event is
			/// captured on a 64-bit computer.
			/// </term>
			/// </item>
			/// <item>
			/// <term>EVENT_HEADER_EXT_TYPE_EVENT_SCHEMA_TL</term>
			/// <term>The DataPtr member points to an extended header item that contains TraceLogging event metadata information.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_HEADER_EXT_TYPE_PROV_TRAITS</term>
			/// <term>
			/// The DataPtr member points to an extended header item that contains provider traits data, for example traits set through
			/// EventSetInformation(EventProviderSetTraits) or specified through EVENT_DATA_DESCRIPTOR_TYPE_PROVIDER_METADATA.
			/// </term>
			/// </item>
			/// <item>
			/// <term>EVENT_HEADER_EXT_TYPE_EVENT_KEY</term>
			/// <term>
			/// The DataPtr member points to an EVENT_EXTENDED_ITEM_EVENT_KEY structure that contains a unique event identifier which is a
			/// 64-bit scalar. The EnablePropertyEVENT_ENABLE_PROPERTY_EVENT_KEY needs to be passed in for the EnableTrace call for a given
			/// provider to enable this feature.
			/// </term>
			/// </item>
			/// <item>
			/// <term>EVENT_HEADER_EXT_TYPE_PROCESS_START_KEY</term>
			/// <term>
			/// The DataPtr member points to an EVENT_EXTENDED_ITEM_PROCESS_START_KEY structure that contains a unique process identifier
			/// (unique across the boot session). This identifier is a 64-bit scalar. The
			/// EnablePropertyEVENT_ENABLE_PROPERTY_PROCESS_START_KEY needs to be passed in for the EnableTrace call for a given provider to
			/// enable this feature.
			/// </term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public ushort ExtType;

			/// <summary>Reserved.</summary>
			public ushort Linkage;

			/// <summary>Size, in bytes, of the extended data that <c>DataPtr</c> points to.</summary>
			public ushort DataSize;

			/// <summary>
			/// Pointer to the extended data. The <c>ExtType</c> member determines the type of extended data to which this member points.
			/// </summary>
			public ulong DataPtr;
		}

		/// <summary>
		/// The EVENT_INSTANCE_HEADER structure contains standard event tracing information common to all events. The structure also contains
		/// registration handles for the event trace class and related parent event, which you use to trace instances of a transaction or
		/// hierarchical relationships between related events.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_INSTANCE_HEADER
		{
			/// <summary>
			/// Total number of bytes of the event. Size must include the size of the EVENT_INSTANCE_HEADER structure, plus the size of any
			/// event-specific data appended to this structure. The size must be less than the size of the event tracing session's buffer
			/// minus 72 (0x48).
			/// </summary>
			public ushort Size;

			/// <summary>Reserved.</summary>
			public ushort FieldTypeFlags;

			/// <summary/>
			public CLASS Class;

			/// <summary>
			/// On output, identifies the thread that generated the event.
			/// <para>Note that on Windows 2000, ThreadId was a ULONGLONG value.</para>
			/// </summary>
			public uint ThreadId;

			/// <summary>
			/// On output, identifies the process that generated the event.
			/// <para>Windows 2000: This member is not supported.</para>
			/// </summary>
			public uint ProcessId;

			/// <summary>On output, contains the time the event occurred, in 100-nanosecond intervals since midnight, January 1, 1601.</summary>
			public FILETIME TimeStamp;

			/// <summary>Handle to a registered event trace class. Set this property before calling the TraceEventInstance function.</summary>
			public ulong RegHandle;

			/// <summary>On output, contains the event trace instance identifier associated with RegHandle.</summary>
			public uint InstanceId;

			/// <summary>On output, contains the event trace instance identifier associated with ParentRegHandle.</summary>
			public uint ParentInstanceId;

			/// <summary>The union</summary>
			public DUMMYUNION Union;

			/// <summary>
			/// Handle to a registered event trace class of a parent event. Set this property before calling the TraceEventInstance function
			/// if you want to trace a hierarchical relationship (parent element/child element) between related events.
			/// <para>The RegisterTraceGuids function creates this handle(see the TraceGuidReg parameter).</para>
			/// </summary>
			public ulong ParentRegHandle;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct CLASS
			{
				/// <summary>Type of event.</summary>
				public EVENT_TRACE_TYPE Type;

				/// <summary>
				/// Provider-defined value that defines the severity level used to generate the event. The value ranges from 0 to 255. The
				/// controller specifies the severity level when it calls the EnableTrace function. The provider retrieves the severity level by
				/// calling the GetTraceEnableLevel function from its ControlCallback implementation. The provider uses the value to set this member.
				/// </summary>
				public TRACE_LEVEL Level;

				/// <summary>
				/// Indicates the version of the event trace class that you are using to log the event. Specify zero if there is only one version
				/// of your event trace class. The version tells the consumer which MOF class to use to decipher the event data.
				/// </summary>
				public ushort Version;
			}

			/// <summary></summary>
			[StructLayout(LayoutKind.Explicit)]
			public struct DUMMYUNION
			{
				/// <summary>
				/// Elapsed execution time for kernel-mode instructions, in CPU ticks. If you are using a private session, use the value in
				/// the ProcessorTime member instead.
				/// </summary>
				[FieldOffset(0)]
				public uint KernelTime;

				/// <summary>
				/// Elapsed execution time for user-mode instructions, in CPU ticks. If you are using a private session, use the value in the
				/// ProcessorTime member instead.
				/// </summary>
				[FieldOffset(4)]
				public uint UserTime;

				/// <summary>For private sessions, the elapsed execution time for user-mode instructions, in CPU ticks.</summary>
				[FieldOffset(0)]
				public ulong ProcessorTime;

				/// <summary>The event identifier</summary>
				[FieldOffset(0)]
				public uint EventId;

				/// <summary>Must contain WNODE_FLAG_TRACED_GUID, and may also contain any combination of the following.</summary>
				[FieldOffset(4)]
				public WNODE_FLAG Flags;
			}
		}

		/// <summary>The <c>EVENT_INSTANCE_INFO</c> structure maps a unique transaction identifier to a registered event trace class.</summary>
		/// <remarks>Be sure to initialize the memory for this structure to zero before setting any members.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntrace/ns-evntrace-event_instance_info typedef struct EVENT_INSTANCE_INFO {
		// HANDLE RegHandle; ULONG InstanceId; } EVENT_INSTANCE_INFO, *PEVENT_INSTANCE_INFO;
		[PInvokeData("evntrace.h", MSDNShortId = "83a3802c-b992-43a2-a98a-bdee2ecfef24")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_INSTANCE_INFO
		{
			/// <summary>Handle to a registered event trace class.</summary>
			public HANDLE RegHandle;

			/// <summary>Unique transaction identifier that maps an event to a specific transaction.</summary>
			public uint InstanceId;
		}

		/// <summary>Defines a single value map entry.</summary>
		/// <remarks>
		/// For maps defined in a manifest, the string will contain a space at the end of the string. For example, if the value is mapped to
		/// "Monday" in the manifest, the string is returned as "Monday ".
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-event_map_entry typedef struct _EVENT_MAP_ENTRY { ULONG
		// OutputOffset; union { ULONG Value; ULONG InputOffset; }; } EVENT_MAP_ENTRY;
		[PInvokeData("tdh.h", MSDNShortId = "e5b12f7a-4a00-41a0-90df-7d1317d63a4a")]
		[StructLayout(LayoutKind.Explicit)]
		public struct EVENT_MAP_ENTRY
		{
			/// <summary>
			/// Offset from the beginning of the EVENT_MAP_INFO structure to a null-terminated Unicode string that contains the string
			/// associated with the map value in <c>Value</c> or <c>InputOffset</c>.
			/// </summary>
			[FieldOffset(0)]
			public uint OutputOffset;

			/// <summary>
			/// If the <c>MapEntryValueType</c> member of EVENT_MAP_INFO is EVENTMAP_ENTRY_VALUETYPE_ULONG, use this member to access the map value.
			/// </summary>
			[FieldOffset(4)]
			public uint Value;

			/// <summary>
			/// <para>
			/// Offset from the beginning of the EVENT_MAP_INFO structure to the null-terminated Unicode string that contains the map value.
			/// </para>
			/// <para>The offset is used for pattern maps and WMI value maps that map strings to strings.</para>
			/// </summary>
			[FieldOffset(4)]
			public uint InputOffset;
		}

		/// <summary>Defines the metadata about the event map.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-event_map_info typedef struct _EVENT_MAP_INFO { ULONG NameOffset;
		// MAP_FLAGS Flag; ULONG EntryCount; union { MAP_VALUETYPE MapEntryValueType; ULONG FormatStringOffset; }; EVENT_MAP_ENTRY
		// MapEntryArray[ANYSIZE_ARRAY]; } EVENT_MAP_INFO;
		[PInvokeData("tdh.h", MSDNShortId = "dc7f14e7-16d7-4dfc-8c1a-5db6fa999d98")]
		[StructLayout(LayoutKind.Explicit)]
		public struct EVENT_MAP_INFO
		{
			/// <summary>
			/// Offset from the beginning of this structure to a null-terminated Unicode string that contains the name of the event map.
			/// </summary>
			[FieldOffset(0)]
			public uint NameOffset;

			/// <summary>
			/// Indicates if the map is a value map, bitmap, or pattern map. This member can contain one or more flag values. For possible
			/// values, see the MAP_FLAGS enumeration.
			/// </summary>
			[FieldOffset(4)]
			public MAP_FLAGS Flag;

			/// <summary>Number of map entries in <c>MapEntryArray</c>.</summary>
			[FieldOffset(8)]
			public uint EntryCount;

			/// <summary>
			/// Determines if you use the <c>Value</c> member or <c>InputOffset</c> member of EVENT_MAP_ENTRY to access the map value. For
			/// possible values, see the MAP_VALUETYPE enumeration.
			/// </summary>
			[FieldOffset(12)]
			public MAP_VALUETYPE MapEntryValueType;

			/// <summary>
			/// <para>
			/// If the value of <c>Flag</c> is EVENTMAP_INFO_FLAG_MANIFEST_PATTERNMAP, use this offset to access the null-terminated Unicode
			/// string that contains the value of the <c>format</c> attribute of the patternMap element. The offset is from the beginning of
			/// this structure.
			/// </para>
			/// <para>
			/// The EVENTMAP_INFO_FLAG_MANIFEST_PATTERNMAP also indicates that you use the <c>InputOffset</c> member of EVENT_MAP_ENTRY to
			/// access the map value.
			/// </para>
			/// </summary>
			[FieldOffset(12)]
			public uint FormatStringOffset;

			///// <summary>Array of map entries. For details, see the EVENT_MAP_ENTRY structure.</summary>
			//public EVENT_MAP_ENTRY MapEntryArray[ANYSIZE_ARRAY];
		}

		/// <summary>Provides information about a single property of the event or filter.</summary>
		/// <remarks>Filters do not support maps, structures, or arrays.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-event_property_info typedef struct _EVENT_PROPERTY_INFO {
		// PROPERTY_FLAGS Flags; ULONG NameOffset; union { struct { USHORT InType; USHORT OutType; ULONG MapNameOffset; } nonStructType;
		// struct { USHORT StructStartIndex; USHORT NumOfStructMembers; ULONG padding; } structType; struct { USHORT InType; USHORT OutType;
		// ULONG CustomSchemaOffset; } customSchemaType; }; union { USHORT count; USHORT countPropertyIndex; }; union { USHORT length; USHORT
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
			/// Offset to a null-terminated Unicode string that contains the name of the property. If this an event property, the offset is
			/// from the beginning of the TRACE_EVENT_INFO structure. If this is a filter property, the offset is from the beginning of the
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
			/// Zero-based index to the element of the property array that contains the number of elements in the array. Use this member if
			/// the PropertyParamCount flag in <c>Flags</c> is set; otherwise, use the <c>count</c> member.
			/// </summary>
			[FieldOffset(16)]
			public ushort countPropertyIndex;

			/// <summary>
			/// Size of the property, in bytes. Note that variable-sized types such as strings and binary data have a length of zero unless
			/// the property has length attribute to explicitly indicate its real length. Structures have a length of zero.
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
			/// A 28-bit value associated with the field metadata. This value is valid only if the PropertyHasTags flag is set. This value
			/// can be used by the event provider to associate additional semantic data with a field for use by an event processing tool. For
			/// example, a tag value of 1 might indicate that the field contains a username. The semantics of any values in this field are
			/// defined by the event provider.
			/// </summary>
			[FieldOffset(20)]
			public uint Tags;

			[StructLayout(LayoutKind.Sequential)]
			public struct NONSTRUCTTYPE
			{
				/// <summary>
				/// <para>Data type of this property on input. For a description of these types, see Remarks in InputType.</para>
				/// <para>For descriptions of these types, see Event Tracing MOF Qualifiers.</para>
				/// <para>TdhGetPropertySize TdhGetPropertySize</para>
				/// </summary>
				public ushort InType;

				/// <summary>
				/// <para>
				/// Output format for this property. If the value is TDH_OUTTYPE_NULL, use the in type as the output format. For a
				/// description of these types, see Remarks in InputType.
				/// </para>
				/// <para>For descriptions of these types, see Event Tracing MOF Qualifiers.</para>
				/// </summary>
				public ushort OutType;

				/// <summary>
				/// Offset from the beginning of the TRACE_EVENT_INFO structure to a null-terminated Unicode string that contains the name of
				/// the map attribute value. You can pass this string to TdhGetEventMapInformation to retrieve information about the value map.
				/// </summary>
				public uint MapNameOffset;
			}

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

			[StructLayout(LayoutKind.Sequential)]
			public struct CUSTOMSCHEMATYPE
			{
				/// <summary>
				/// <para>Data type of this property on input. For a description of these types, see Remarks in InputType.</para>
				/// <para>For descriptions of these types, see Event Tracing MOF Qualifiers.</para>
				/// <para>TdhGetPropertySize TdhGetPropertySize</para>
				/// </summary>
				public ushort InType;

				/// <summary>
				/// <para>
				/// Output format for this property. If the value is TDH_OUTTYPE_NULL, use the in type as the output format. For a
				/// description of these types, see Remarks in InputType.
				/// </para>
				/// <para>For descriptions of these types, see Event Tracing MOF Qualifiers.</para>
				/// </summary>
				public ushort OutType;

				/// <summary>
				/// Offset (in bytes) from the beginning of the TRACE_EVENT_INFO structure to the custom schema information. The custom
				/// schema information will contain a 2-byte protocol identifier, followed by a 2-byte schema length, followed by the schema.
				/// </summary>
				public uint CustomSchemaOffset;
			}
		}

		/// <summary>The <c>EVENT_RECORD</c> structure defines the layout of an event that ETW delivers.</summary>
		/// <remarks>
		/// The <c>EVENT_RECORD</c> structure is passed to the consumer's implementation of the EventRecordCallback callback .
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntcons/ns-evntcons-_event_record typedef struct _EVENT_RECORD {
		// EVENT_HEADER EventHeader; ETW_BUFFER_CONTEXT BufferContext; USHORT ExtendedDataCount; USHORT UserDataLength;
		// PEVENT_HEADER_EXTENDED_DATA_ITEM ExtendedData; PVOID UserData; PVOID UserContext; } EVENT_RECORD, *PEVENT_RECORD;
		[PInvokeData("evntcons.h", MSDNShortId = "e352c1a7-39a2-43e3-a723-5fc6a3921ee8")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_RECORD
		{
			/// <summary>
			/// Information about the event such as the time stamp for when it was written. For details, see the EVENT_HEADER structure.
			/// </summary>
			public EVENT_HEADER EventHeader;

			/// <summary>Defines information such as the session that logged the event. For details, see the ETW_BUFFER_CONTEXT structure.</summary>
			public ETW_BUFFER_CONTEXT BufferContext;

			/// <summary>The number of extended data structures in the <c>ExtendedData</c> member.</summary>
			public ushort ExtendedDataCount;

			/// <summary>The size, in bytes, of the data in the <c>UserData</c> member.</summary>
			public ushort UserDataLength;

			/// <summary>
			/// One or more extended data items that ETW collects. The extended data includes some items, such as the security identifier
			/// (SID) of the user that logged the event, only if the controller sets the EnableProperty parameter passed to the EnableTraceEx
			/// or EnableTraceEx2 function. The extended data includes other items, such as the related activity identifier and decoding
			/// information for trace logging, regardless whether the controller sets the EnableProperty parameter passed to
			/// <c>EnableTraceEx</c> or <c>EnableTraceEx2</c>. For details, see the EVENT_HEADER_EXTENDED_DATA_ITEM structure .
			/// </summary>
			public IntPtr ExtendedData;

			/// <summary>
			/// Event specific data. To parse this data, see Retrieving Event Data Using TDH. If the <c>Flags</c> member of EVENT_HEADER
			/// contains <c>EVENT_HEADER_FLAG_STRING_ONLY</c>, the data is a null-terminated Unicode string that you do not need TDH to parse.
			/// </summary>
			public IntPtr UserData;

			/// <summary>
			/// Th context specified in the <c>Context</c> member of the EVENT_TRACE_LOGFILE structure that is passed to the OpenTrace function.
			/// </summary>
			public IntPtr UserContext;
		}

		/// <summary>The <c>EVENT_TRACE</c> structure is used to deliver event information to an event trace consumer.</summary>
		/// <remarks>ETW passes this structure to the consumer's EventCallback callback function.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntrace/ns-evntrace-event_trace typedef struct _EVENT_TRACE {
		// EVENT_TRACE_HEADER Header; ULONG InstanceId; ULONG ParentInstanceId; GUID ParentGuid; PVOID MofData; ULONG MofLength; union {
		// ULONG ClientContext; ETW_BUFFER_CONTEXT BufferContext; } DUMMYUNIONNAME; } EVENT_TRACE, *PEVENT_TRACE;
		[PInvokeData("evntrace.h", MSDNShortId = "d8a6b63e-0cd4-4d19-b0b3-16bb0d33e4c0")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_TRACE
		{
			/// <summary>An EVENT_TRACE_HEADER structure that contains standard event tracing information.</summary>
			public EVENT_TRACE_HEADER Header;

			/// <summary>
			/// Instance identifier. Contains valid data when the provider calls the TraceEventInstance function to generate the event.
			/// Otherwise, the value is zero.
			/// </summary>
			public uint InstanceId;

			/// <summary>
			/// Instance identifier for a parent event. Contains valid data when the provider calls the TraceEventInstance function to
			/// generate the event. Otherwise, the value is zero.
			/// </summary>
			public uint ParentInstanceId;

			/// <summary>
			/// Class GUID of the parent event. Contains valid data when the provider calls the TraceEventInstance function to generate the
			/// event. Otherwise, the value is zero.
			/// </summary>
			public Guid ParentGuid;

			/// <summary>Pointer to the beginning of the event-specific data for this event.</summary>
			public IntPtr MofData;

			/// <summary>Number of bytes to which <c>MofData</c> points.</summary>
			public uint MofLength;

			/// <summary>
			/// <para>
			/// Provides information about the event such as the session identifier and processor number of the CPU on which the provider
			/// process ran. For details, see the ETW_BUFFER_CONTEXT structure.
			/// </para>
			/// <para><c>Prior to Windows Vista:</c> Not supported.</para>
			/// </summary>
			public ETW_BUFFER_CONTEXT BufferContext;
		}

		/// <summary>The EVENT_TRACE_HEADER structure contains standard event tracing information common to all events.</summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct EVENT_TRACE_HEADER
		{
			/// <summary>
			/// Total number of bytes of the event. Size includes the size of the header structure, plus the size of any event-specific data
			/// appended to the header.
			/// <para>On input, the size must be less than the size of the event tracing session's buffer minus 72 (0x48).</para>
			/// <para>On output, do not use this number in calculations.</para>
			/// </summary>
			[FieldOffset(0)]
			public ushort Size;

			/// <summary>Reserved.</summary>
			[FieldOffset(2)]
			public ushort FieldTypeFlags;

			/// <summary>
			/// This is a roll-up of the members of Class. The low-order byte contains the Type, the next byte contains the Level, and the
			/// last two bytes contain the version.
			/// </summary>
			[FieldOffset(4)]
			public uint Version;

			/// <summary/>
			[FieldOffset(4)]
			public CLASS Class;

			/// <summary>
			/// On output, identifies the thread that generated the event.
			/// <para>Note that on Windows 2000, ThreadId was a ULONGLONG value.</para>
			/// </summary>
			[FieldOffset(8)]
			public uint ThreadId;

			/// <summary>
			/// On output, identifies the process that generated the event.
			/// <para>Note that on Windows 2000, ProcessId was a ULONGLONG value.</para>
			/// </summary>
			[FieldOffset(12)]
			public uint ProcessId;

			/// <summary>
			/// On output, contains the time that the event occurred. The resolution is system time unless the ProcessTraceMode member of
			/// EVENT_TRACE_LOGFILE contains the PROCESS_TRACE_MODE_RAW_TIMESTAMP flag, in which case the resolution depends on the value of
			/// the Wnode.ClientContext member of EVENT_TRACE_PROPERTIES at the time the controller created the session.
			/// </summary>
			[FieldOffset(16)]
			public FILETIME TimeStamp;

			/// <summary>
			/// Event trace class GUID. You can use the class GUID to identify a category of events and the Class.Type member to identify an
			/// event within the category of events.
			/// <para>Alternatively, you can use the GuidPtr member to specify the class GUID.</para>
			/// <para>Windows XP and Windows 2000: The class GUID must have been registered previously using the RegisterTraceGuids function.</para>
			/// </summary>
			[FieldOffset(24)]
			public Guid Guid;

			/// <summary>
			/// Pointer to an event trace class GUID. Alternatively, you can use the Guid member to specify the class GUID. When the event is
			/// written, ETW uses the pointer to copy the GUID to the event (the GUID is included in the event, not the pointer).
			/// <para>If you use this member, the Flags member must also contain WNODE_FLAG_USE_GUID_PTR.</para>
			/// </summary>
			[FieldOffset(24)]
			public GuidPtr GuidPtr;

			/// <summary>
			/// Elapsed execution time for kernel-mode instructions, in CPU time units. If you are using a private session, use the value in
			/// the ProcessorTime member instead. For more information, see Remarks.
			/// </summary>
			[FieldOffset(40)]
			public uint KernelTime;

			/// <summary>
			/// Elapsed execution time for user-mode instructions, in CPU time units. If you are using a private session, use the value in
			/// the ProcessorTime member instead. For more information, see Remarks.
			/// </summary>
			[FieldOffset(44)]
			public uint UserTime;

			/// <summary>Reserved.</summary>
			[FieldOffset(40)]
			public uint ClientContext;

			/// <summary>
			/// You must set this member to WNODE_FLAG_TRACED_GUID, and may optionally specify any combination of the following.
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <description>WNODE_FLAG_USE_GUID_PTR</description>
			/// <description>Specify if the GuidPtr member contains the class GUID.</description>
			/// </item>
			/// <item>
			/// <description>WNODE_FLAG_USE_MOF_PTR</description>
			/// <description>
			/// Specify if an array of MOF_FIELD structures contains the event data appended to this structure. The number of elements in the
			/// array is limited to MAX_MOF_FIELDS.
			/// </description>
			/// </item>
			/// </list>
			/// </summary>
			[FieldOffset(44)]
			public WNODE_FLAG Flags;

			/// <summary>For private sessions, the elapsed execution time for user-mode instructions, in CPU ticks.</summary>
			[FieldOffset(40)]
			public ulong ProcessorTime;

			[StructLayout(LayoutKind.Sequential)]
			public struct CLASS
			{
				/// <summary>Type of event.</summary>
				public EVENT_TRACE_TYPE Type;

				/// <summary>
				/// Provider-defined value that defines the severity level used to generate the event. The value ranges from 0 to 255. The
				/// controller specifies the severity level when it calls the EnableTrace function. The provider retrieves the severity level by
				/// calling the GetTraceEnableLevel function from its ControlCallback implementation. The provider uses the value to set this member.
				/// <para>
				/// ETW defines the following severity levels.Selecting a level higher than 1 will also include events for lower levels. For
				/// example, if the controller specifies TRACE_LEVEL_WARNING (3), the provider also generates TRACE_LEVEL_FATAL(1) and
				/// TRACE_LEVEL_ERROR(2) events.
				/// </para>
				/// </summary>
				public TRACE_LEVEL Level;

				/// <summary>
				/// Indicates the version of the event trace class that you are using to log the event. Specify zero if there is only one version
				/// of your event trace class. The version tells the consumer which MOF class to use to decipher the event data.
				/// </summary>
				public ushort Version;
			}
		}

		/// <summary>
		/// <para>
		/// The <c>EVENT_TRACE_LOGFILE</c> structure specifies how the consumer wants to read events (from a log file or in real-time) and
		/// the callbacks that will receive the events.
		/// </para>
		/// <para>
		/// When ETW flushes a buffer, this structure contains information about the event tracing session and the buffer that ETW flushed.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>Be sure to initialize the memory for this structure to zero before setting any members.</para>
		/// <para>Consumers pass this structure to the <c>OpenTrace</c> function.</para>
		/// <para>When ETW flushes a buffer, it passes the structure to the consumer's <c>BufferCallback</c> function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/etw/event-trace-logfile typedef struct _EVENT_TRACE_LOGFILE { LPTSTR LogFileName;
		// LPTSTR LoggerName; LONGLONG CurrentTime; ULONG BuffersRead; union { ULONG LogFileMode; ULONG ProcessTraceMode; }; EVENT_TRACE
		// CurrentEvent; TRACE_LOGFILE_HEADER LogfileHeader; PEVENT_TRACE_BUFFER_CALLBACK BufferCallback; ULONG BufferSize; ULONG Filled;
		// ULONG EventsLost; union { PEVENT_CALLBACK EventCallback; PEVENT_RECORD_CALLBACK EventRecordCallback; }; ULONG IsKernelTrace; PVOID
		// Context; } EVENT_TRACE_LOGFILE, *PEVENT_TRACE_LOGFILE;
		[PInvokeData("Evntcons.h", MSDNShortId = "179451e9-7e3c-4d3a-bcc6-3ad9d382229a")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct EVENT_TRACE_LOGFILE
		{
			/// <summary>
			/// <para>
			/// Name of the log file used by the event tracing session. Specify a value for this member if you are consuming from a log file.
			/// This member must be <c>NULL</c> if <c>LoggerName</c> is specified.
			/// </para>
			/// <para>
			/// You must know the log file name the controller specified. If the controller logged events to a private session (the
			/// controller set the <c>LogFileMode</c> member of <c>EVENT_TRACE_PROPERTIES</c> to <c>EVENT_TRACE_PRIVATE_LOGGER_MODE</c>), the
			/// file name must include the process identifier that ETW appended to the log file name. For example, if the controller named
			/// the log file xyz.etl and the process identifier is 123, ETW uses xyz.etl_123 as the file name.
			/// </para>
			/// <para>
			/// If the controller set the <c>LogFileMode</c> member of <c>EVENT_TRACE_PROPERTIES</c> to <c>EVENT_TRACE_FILE_MODE_NEWFILE</c>,
			/// the log file name must include the sequential serial number used to create each new log file.
			/// </para>
			/// <para>The user consuming the events must have permissions to read the file.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string LogFileName;

			/// <summary>
			/// <para>
			/// Name of the event tracing session. Specify a value for this member if you want to consume events in real time. This member
			/// must be <c>NULL</c> if <c>LogFileName</c> is specified.
			/// </para>
			/// <para>
			/// You can only consume events in real time if the controller set the <c>LogFileMode</c> member of <c>EVENT_TRACE_PROPERTIES</c>
			/// to <c>EVENT_TRACE_REAL_TIME_MODE</c>.
			/// </para>
			/// <para>
			/// Only users with administrative privileges, users in the Performance Log Users group, and applications running as LocalSystem,
			/// LocalService, NetworkService can consume events in real time. To grant a restricted user the ability to consume events in
			/// real time, add them to the Performance Log Users group or call <c>EventAccessControl</c>.
			/// </para>
			/// <para><c>Windows XP and Windows 2000:</c> Anyone can consume real time events.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string LoggerName;

			/// <summary>On output, the current time, in 100-nanosecond intervals since midnight, January 1, 1601.</summary>
			public FILETIME CurrentTime;

			/// <summary>On output, the number of buffers processed.</summary>
			public uint BuffersRead;

			/// <summary>
			/// <para>
			/// Modes for processing events. The modes are defined in the Evntcons.h header file. You can specify one or more of the
			/// following modes:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PROCESS_TRACE_MODE_EVENT_RECORD</term>
			/// <term>
			/// Specify this mode if you want to receive events in the new EVENT_RECORD format. To receive events in the new format you must
			/// specify a callback in the EventRecordCallback member. If you do not specify this mode, you receive events in the old format
			/// through the callback specified in the EventCallback member. Prior to Windows Vista: Not supported.
			/// </term>
			/// </item>
			/// <item>
			/// <term>PROCESS_TRACE_MODE_RAW_TIMESTAMP</term>
			/// <term>
			/// Specify this mode if you do not want the time stamp value in the TimeStamp member of EVENT_HEADER and EVENT_TRACE_HEADER
			/// converted to system time (leaves the time stamp value in the resolution that the controller specified in the
			/// Wnode.ClientContext member of EVENT_TRACE_PROPERTIES). Prior to Windows Vista: Not supported.
			/// </term>
			/// </item>
			/// <item>
			/// <term>PROCESS_TRACE_MODE_REAL_TIME</term>
			/// <term>Specify this mode to receive events in real time (you must specify this mode if LoggerName is not NULL).</term>
			/// </item>
			/// </list>
			/// </summary>
			public PROCESS_TRACE_MODE ProcessTraceMode;

			/// <summary>On output, an <c>EVENT_TRACE</c> structure that contains the last event processed.</summary>
			public EVENT_TRACE CurrentEvent;

			/// <summary>
			/// On output, a <c>TRACE_LOGFILE_HEADER</c> structure that contains general information about the session and the computer on
			/// which the session ran.
			/// </summary>
			public TRACE_LOGFILE_HEADER LogfileHeader;

			/// <summary>
			/// Pointer to the <c>BufferCallback</c> function that receives buffer-related statistics for each buffer ETW flushes. ETW calls
			/// this callback after it delivers all the events in the buffer. This callback is optional.
			/// </summary>
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public BufferCallback BufferCallback;

			/// <summary>On output, contains the size of each buffer, in bytes.</summary>
			public uint BufferSize;

			/// <summary>On output, contains the number of bytes in the buffer that contain valid information.</summary>
			public uint Filled;

			/// <summary>Not used.</summary>
			public uint EventsLost;

			/// <summary>A callback function associated with the type of events being written.</summary>
			public CALLBACK_UNION Callback;

			/// <summary>
			/// On output, if this member is <c>TRUE</c>, the event tracing session is the NT Kernel Logger. Otherwise, it is another event
			/// tracing session.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool IsKernelTrace;

			/// <summary>
			/// <para>
			/// Context data that a consumer can specify when calling <c>OpenTrace</c>. If the consumer uses <c>EventRecordCallback</c> to
			/// consume events, ETW sets the <c>UserContext</c> member of the <c>EVENT_RECORD</c> structure to this value.
			/// </para>
			/// <para><c>Prior to Windows Vista:</c> Not supported.</para>
			/// </summary>
			public IntPtr Context;

			[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
			public struct CALLBACK_UNION
			{
				/// <summary>
				/// <para>Pointer to the <c>EventCallback</c> function that ETW calls for each event in the buffer.</para>
				/// <para>
				/// Specify this callback if you are consuming events from a provider that used one of the <c>TraceEvent</c> functions to log events.
				/// </para>
				/// </summary>
				[FieldOffset(0)]
				[MarshalAs(UnmanagedType.FunctionPtr)]
				public EventClassCallback EventCallback;

				/// <summary>
				/// <para>Pointer to the <c>EventRecordCallback</c> function that ETW calls for each event in the buffer.</para>
				/// <para>
				/// Specify this callback if you are consuming events from a provider that used one of the <c>EventWrite</c> functions to log events.
				/// </para>
				/// <para><c>Prior to Windows Vista:</c> Not supported.</para>
				/// </summary>
				[FieldOffset(0)]
				[MarshalAs(UnmanagedType.FunctionPtr)]
				public EventRecordCallback EventRecordCallback;
			}
		}

		/// <summary>
		/// The <c>EVENT_TRACE_PROPERTIES</c> structure contains information about an event tracing session. You use this structure when you
		/// define a session, change the properties of a session, or query for the properties of a session.
		/// </summary>
		/// <remarks>
		/// <para>Be sure to initialize the memory for this structure to zero before setting any members.</para>
		/// <para>
		/// Events from providers are written to a session's buffers. When a buffer is full, the session flushes the buffer either by writing
		/// the events to a log file, delivering them to a real-time consumer, or both. If the session's buffers are filled faster than they
		/// can be flushed, new buffers are allocated and added to the session's buffer pool, up to the maximum number specified. Beyond this
		/// limit, the session discards incoming events until a buffer becomes available. Each session keeps a record of the number of events
		/// discarded (see the <c>EventsLost</c> member).
		/// </para>
		/// <para>ETW does not free unused buffers.</para>
		/// <para><c>Windows 2000:</c> ETW frees unused buffers based on the <c>AgeLimit</c> member value.</para>
		/// <para>
		/// You use the <c>BufferSize</c>, <c>MinimumBuffers</c>, and <c>MaximumBuffers</c> members to configure the buffers for an event
		/// tracing session when you define the session or anytime during the tracing session. ETW uses the physical memory and number of
		/// processors available on the computer to determine if the values are reasonable. If ETW determines the values are not reasonable,
		/// ETW will determine the correct size and overwrite the values.
		/// </para>
		/// <para>Typically, you should not set these values and instead let ETW determine the size and number of buffers.</para>
		/// <para>
		/// To view session statistics, such as <c>EventsLost</c> while the session is running, call the <c>ControlTrace</c> function and set
		/// the ControlCode parameter to EVENT_TRACE_CONTROL_QUERY.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/event-trace-properties typedef struct _EVENT_TRACE_PROPERTIES { WNODE_HEADER
		// Wnode; ULONG BufferSize; ULONG MinimumBuffers; ULONG MaximumBuffers; ULONG MaximumFileSize; ULONG LogFileMode; ULONG FlushTimer;
		// ULONG EnableFlags; LONG AgeLimit; ULONG NumberOfBuffers; ULONG FreeBuffers; ULONG EventsLost; ULONG BuffersWritten; ULONG
		// LogBuffersLost; ULONG RealTimeBuffersLost; HANDLE LoggerThreadId; ULONG LogFileNameOffset; ULONG LoggerNameOffset; }
		// EVENT_TRACE_PROPERTIES, *PEVENT_TRACE_PROPERTIES;
		[PInvokeData("evntrace.h", MSDNShortId = "0c967971-8df1-4679-a8a9-a783f5b35860")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct EVENT_TRACE_PROPERTIES
		{
			public const int MaxLoggerNameLength = 1024;
			public const int MaxLogFileNameLength = 1024;

			private static readonly uint SizeOf = (uint)Marshal.SizeOf(typeof(EVENT_TRACE_PROPERTIES));
			private static readonly uint StrLen = SizeOf > 4096 ? 2048U : 1024U;

			/// <summary>
			/// A <c>WNODE_HEADER</c> structure. You must specify the <c>BufferSize</c>, <c>Flags</c>, and <c>Guid</c> members, and
			/// optionally the <c>ClientContext</c> member.
			/// </summary>
			public WNODE_HEADER Wnode;

			/// <summary>
			/// <para>
			/// Amount of memory allocated for each event tracing session buffer, in kilobytes. The maximum buffer size is 1 MB. ETW uses the
			/// size of physical memory to calculate this value. For more information, see Remarks.
			/// </para>
			/// <para>
			/// If an application expects a relatively low event rate, the buffer size should be set to the memory page size. If the event
			/// rate is expected to be relatively high, the application should specify a larger buffer size, and should increase the maximum
			/// number of buffers.
			/// </para>
			/// <para>
			/// The buffer size affects the rate at which buffers fill and must be flushed. Although a small buffer size requires less
			/// memory, it increases the rate at which buffers must be flushed.
			/// </para>
			/// </summary>
			public uint BufferSize;

			/// <summary>
			/// Minimum number of buffers allocated for the event tracing session's buffer pool. The minimum number of buffers that you can
			/// specify is two buffers per processor. For example, on a single processor computer, the minimum number of buffers is two. Note
			/// that if you use the EVENT_TRACE_NO_PER_PROCESSOR_BUFFERING logging mode, the number of processors is assumed to be 1.
			/// </summary>
			public uint MinimumBuffers;

			/// <summary>
			/// Maximum number of buffers allocated for the event tracing session's buffer pool. Typically, this value is the minimum number
			/// of buffers plus twenty. ETW uses the buffer size and the size of physical memory to calculate this value. This value must be
			/// greater than or equal to the value for <c>MinimumBuffers</c>. Note that you do not need to set this value if
			/// <c>LogFileMode</c> contains <c>EVENT_TRACE_BUFFERING_MODE</c>; instead, the total memory buffer size is instead the product
			/// of <c>MinimumBuffers</c> and <c>BufferSize</c>.
			/// </summary>
			public uint MaximumBuffers;

			/// <summary>
			/// <para>
			/// Maximum size of the file used to log events, in megabytes. Typically, you use this member to limit the size of a circular log
			/// file when you set <c>LogFileMode</c> to <c>EVENT_TRACE_FILE_MODE_CIRCULAR</c>. This member must be specified if
			/// <c>LogFileMode</c> contains <c>EVENT_TRACE_FILE_MODE_PREALLOCATE</c>, <c>EVENT_TRACE_FILE_MODE_CIRCULAR</c> or <c>EVENT_TRACE_FILE_MODE_NEWFILE</c>
			/// </para>
			/// <para>
			/// If you are using the system drive (the drive that contains the operating system) for logging, ETW checks for an additional
			/// 200MB of disk space, regardless of whether you are using the maximum file size parameter. Therefore, if you specify 100MB as
			/// the maximum file size for the trace file in the system drive, you need to have 300MB of free space on the drive.
			/// </para>
			/// </summary>
			public uint MaximumFileSize;

			/// <summary>
			/// <para>
			/// Logging modes for the event tracing session. You use this member to specify that you want events written to a log file, a
			/// real-time consumer, or both. You can also use this member to specify that the session is a private logger session. You can
			/// specify one or more modes. For a list of possible modes, see Logging Mode Constants.
			/// </para>
			/// <para>
			/// Do not specify real-time logging unless there are real-time consumers ready to consume the events. If there are no real-time
			/// consumers, ETW writes the events to a playback file. However, the size of the playback file is limited. If the limit is
			/// reached, no new events are logged (to the log file or playback file) and the logging functions fail with STATUS_LOG_FILE_FULL.
			/// </para>
			/// <para><c>Prior to Windows Vista:</c> If there was no real-time consumer, the events were discarded and logging continues.</para>
			/// <para>
			/// If a consumer begins processing real-time events, the events in the playback file are consumed first. After all events in the
			/// playback file are consumed, the session will begin logging new events.
			/// </para>
			/// </summary>
			public LogFileMode LogFileMode;

			/// <summary>
			/// <para>
			/// How often, in seconds, the trace buffers are forcibly flushed. The minimum flush time is 1 second. This forced flush is in
			/// addition to the automatic flush that occurs whenever a buffer is full and when the trace session stops.
			/// </para>
			/// <para>
			/// If zero, ETW flushes buffers as soon as they become full. If nonzero, ETW flushes all buffers that contain events based on
			/// the timer value. Typically, you want to flush buffers only when they become full. Forcing the buffers to flush (either by
			/// setting this member to a nonzero value or by calling <c>FlushTrace</c>) can increase the file size of the log file with
			/// unfilled buffer space.
			/// </para>
			/// <para>
			/// If the consumer is consuming events in real time, you may want to set this member to a nonzero value if the event rate is low
			/// to force events to be delivered before the buffer is full.
			/// </para>
			/// <para>
			/// For the case of a realtime logger, a value of zero (the default value) means that the flush time will be set to 1 second. A
			/// realtime logger is when <c>LogFileMode</c> is set to <c>EVENT_TRACE_REAL_TIME_MODE</c>.
			/// </para>
			/// </summary>
			public uint FlushTimer;

			/// <summary>
			/// A system logger must set <c>EnableFlags</c> to indicate which SystemTraceProvider events should be included in the trace.
			/// This is also used for NT Kernel Logger sessions. This member can contain one or more of the following values. In addition to
			/// the events you specify, the kernel logger also logs hardware configuration events on Windows XP or system configuration
			/// events on Windows Server 2003.
			/// </summary>
			public EVENT_TRACE_FLAG EnableFlags;

			/// <summary>
			/// <para>Not used.</para>
			/// <para><c>Windows 2000:</c> Time delay before unused buffers are freed, in minutes. The default is 15 minutes.</para>
			/// </summary>
			public int AgeLimit;

			/// <summary>On output, the number of buffers allocated for the event tracing session's buffer pool.</summary>
			public uint NumberOfBuffers;

			/// <summary>On output, the number of buffers that are allocated but unused in the event tracing session's buffer pool.</summary>
			public uint FreeBuffers;

			/// <summary>On output, the number of events that were not recorded.</summary>
			public uint EventsLost;

			/// <summary>On output, the number of buffers written.</summary>
			public uint BuffersWritten;

			/// <summary>On output, the number of buffers that could not be written to the log file.</summary>
			public uint LogBuffersLost;

			/// <summary>On output, the number of buffers that could not be delivered in real-time to the consumer.</summary>
			public uint RealTimeBuffersLost;

			/// <summary>On output, the thread identifier for the event tracing session.</summary>
			public HANDLE LoggerThreadId;

			/// <summary>
			/// <para>
			/// Offset from the start of the structure's allocated memory to beginning of the null-terminated string that contains the log
			/// file name.
			/// </para>
			/// <para>
			/// The file name should use the .etl extension. All folders in the path must exist. The path can be relative, absolute, local,
			/// or remote. The path cannot contain environment variables (they are not expanded). The user must have permission to write to
			/// the folder.
			/// </para>
			/// <para>
			/// The log file name is limited to 1,024 characters. If you set <c>LogFileMode</c> to <c>EVENT_TRACE_PRIVATE_LOGGER_MODE</c> or
			/// <c>EVENT_TRACE_FILE_MODE_NEWFILE</c>, be sure to allocate enough memory to include the process identifier that is appended to
			/// the file name for private loggers sessions, and the sequential number that is added to log files created using the new file
			/// log mode.
			/// </para>
			/// <para>
			/// If you do not want to log events to a log file (for example, you specify <c>EVENT_TRACE_REAL_TIME_MODE</c> only), set
			/// LogFileNameOffset to 0. If you specify only real-time logging and also provide an offset with a valid log file name, ETW will
			/// use the log file name to create a sequential log file and log events to the log file. ETW also creates the sequential log
			/// file if <c>LogFileMode</c> is 0 and you provide an offset with a valid log file name.
			/// </para>
			/// <para>
			/// If you want to log events to a log file, you must allocate enough memory for this structure to include the log file name and
			/// session name following the structure. The log file name must follow the session name in memory.
			/// </para>
			/// <para>
			/// Trace files are created using the default security descriptor, meaning that the log file will have the same ACL as the parent
			/// directory. If you want access to the files restricted, create a parent directory with the appropriate ACLs.
			/// </para>
			/// </summary>
			public uint LogFileNameOffset;

			/// <summary>
			/// <para>
			/// Offset from the start of the structure's allocated memory to beginning of the null-terminated string that contains the
			/// session name.
			/// </para>
			/// <para>The session name is limited to 1,024 characters. The session name is case-insensitive and must be unique.</para>
			/// <para>
			/// <c>Windows 2000:</c> Session names are case-sensitive. As a result, duplicate session names are allowed. However, to reduce
			/// confusion, you should make sure your session names are unique.
			/// </para>
			/// <para>
			/// When you allocate the memory for this structure, you must allocate enough memory to include the session name and log file
			/// name following the structure. The session name must come before the log file name in memory. You must copy the log file name
			/// to the offset but you do not copy the session name to the offset—the <c>StartTrace</c> function copies the name for you.
			/// </para>
			/// </summary>
			public uint LoggerNameOffset;

			/// <summary>
			/// <para>A string that contains the log file name.</para>
			/// <para>
			/// The file name should use the .etl extension. All folders in the path must exist. The path can be relative, absolute, local,
			/// or remote. The path cannot contain environment variables (they are not expanded). The user must have permission to write to
			/// the folder.
			/// </para>
			/// <para>
			/// The log file name is limited to 1,024 characters. If you set <c>LogFileMode</c> to <c>EVENT_TRACE_PRIVATE_LOGGER_MODE</c> or
			/// <c>EVENT_TRACE_FILE_MODE_NEWFILE</c>, be sure to allocate enough memory to include the process identifier that is appended to
			/// the file name for private loggers sessions, and the sequential number that is added to log files created using the new file
			/// log mode.
			/// </para>
			/// <para>
			/// If you do not want to log events to a log file (for example, you specify <c>EVENT_TRACE_REAL_TIME_MODE</c> only), set
			/// LogFileNameOffset to 0. If you specify only real-time logging and also provide an offset with a valid log file name, ETW will
			/// use the log file name to create a sequential log file and log events to the log file. ETW also creates the sequential log
			/// file if <c>LogFileMode</c> is 0 and you provide an offset with a valid log file name.
			/// </para>
			/// <para>
			/// If you want to log events to a log file, you must allocate enough memory for this structure to include the log file name and
			/// session name following the structure. The log file name must follow the session name in memory.
			/// </para>
			/// <para>
			/// Trace files are created using the default security descriptor, meaning that the log file will have the same ACL as the parent
			/// directory. If you want access to the files restricted, create a parent directory with the appropriate ACLs.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MaxLogFileNameLength)]
			public string LogFileName;

			// Reserve buffer space so the ETW system can fill this with the logger name
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MaxLoggerNameLength)]
			public string LoggerName;

			/// <summary>Creates a <see cref="EVENT_TRACE_PROPERTIES"/> with default properties set.</summary>
			/// <param name="sessionId">The session identifier.</param>
			/// <param name="createForQuery">if set to <c>true</c> creating for a query.</param>
			/// <returns>An initialized instance of <see cref="EVENT_TRACE_PROPERTIES"/>.</returns>
			public static EVENT_TRACE_PROPERTIES Create(Guid sessionId, bool createForQuery = false)
			{
				var output = Create();
				output.Wnode.Guid = sessionId;
				output.Wnode.ClientContext = 1;
				output.LogFileMode = createForQuery ? 0 : LogFileMode.EVENT_TRACE_REAL_TIME_MODE;
				return output;
			}

			/// <summary>Creates a <see cref="EVENT_TRACE_PROPERTIES"/> with default properties set.</summary>
			/// <param name="logFileName">Name of the log file.</param>
			/// <param name="providerName">Name of the provider.</param>
			/// <returns>An initialized instance of <see cref="EVENT_TRACE_PROPERTIES"/>.</returns>
			public static EVENT_TRACE_PROPERTIES Create(string logFileName = null, string providerName = null)
			{
				var output = new EVENT_TRACE_PROPERTIES
				{
					Wnode = new WNODE_HEADER
					{
						BufferSize = SizeOf,
						Flags = WNODE_FLAG.WNODE_FLAG_TRACED_GUID,
					},
					LoggerNameOffset = SizeOf - StrLen,
					LogFileNameOffset = SizeOf - StrLen * 2
				};
				if (!string.IsNullOrEmpty(logFileName))
					output.LogFileName = logFileName;
				if (!string.IsNullOrEmpty(providerName))
					output.LoggerName = providerName;
				return output;
			}
		}

		/// <summary>
		/// The <c>EVENT_TRACE_PROPERTIES_V2</c> structure contains information about an event tracing session. You use this structure when
		/// you define a session, change the properties of a session, or query for the properties of a session. This is extended from the
		/// <c>EVENT_TRACE_PROPERTIES</c> structure.
		/// </summary>
		/// <remarks>
		/// <para>This structure behaves similarly to <c>EVENT_TRACE_PROPERTIES</c> with a few exceptions.</para>
		/// <para>
		/// The beginning of the structure is defined exactly as <c>EVENT_TRACE_PROPERTIES</c> to allow this new structure to be compatible
		/// with systems running versions of Windows before Windows 10, version 1703 and will be treated as <c>EVENT_TRACE_PROPERTIES</c>.
		/// </para>
		/// <para>
		/// When using this structure, be sure to include WNODE_FLAG_VERSIONED_PROPERTIES in Wnode.Flags to indicate that this is the version
		/// two structure.
		/// </para>
		/// <para>
		/// Note that the filters passed into <c>ControlTrace</c>, <c>QueryTrace</c>, <c>StartTrace</c>, and <c>StopTrace</c> by this
		/// structure are the same format as filters consumed by the <c>EnableTraceEx2</c> function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/etw/event-trace-properties-v2 typedef struct EVENT_TRACE_PROPERTIES_V2 {
		// WNODE_HEADER Wnode; ULONG BufferSize; ULONG MinimumBuffers; ULONG MaximumBuffers; ULONG MaximumFileSize; ULONG LogFileMode; ULONG
		// FlushTimer; ULONG EnableFlags; LONG AgeLimit; ULONG NumberOfBuffers; ULONG FreeBuffers; ULONG EventsLost; ULONG BuffersWritten;
		// ULONG LogBuffersLost; ULONG RealTimeBuffersLost; HANDLE LoggerThreadId; ULONG LogFileNameOffset; ULONG LoggerNameOffset; ULONG
		// VersionNumber; PEVENT_FILTER_DESCRIPTOR FilterDesc; ULONG FilterDescCount; union { struct { ULONG Wow : 1; ULONG QpcDeltaTracking
		// : 1; } ULONG V2Options; }; } EVENT_TRACE_PROPERTIES_V2, *PEVENT_TRACE_PROPERTIES_V2;
		[PInvokeData("Evntrace.h", MSDNShortId = "2EEDB53B-75BC-48AC-A70D-9AEAED526C40")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_TRACE_PROPERTIES_V2
		{
			/// <summary>
			/// A <c>WNODE_HEADER</c> structure. You must specify the <c>BufferSize</c>, <c>Flags</c>, and <c>Guid</c> members, and
			/// optionally the <c>ClientContext</c> member.
			/// </summary>
			public WNODE_HEADER Wnode;

			/// <summary>
			/// <para>
			/// Amount of memory allocated for each event tracing session buffer, in kilobytes. The maximum buffer size is 1 MB. ETW uses the
			/// size of physical memory to calculate this value. For more information, see Remarks.
			/// </para>
			/// <para>
			/// If an application expects a relatively low event rate, the buffer size should be set to the memory page size. If the event
			/// rate is expected to be relatively high, the application should specify a larger buffer size, and should increase the maximum
			/// number of buffers.
			/// </para>
			/// <para>
			/// The buffer size affects the rate at which buffers fill and must be flushed. Although a small buffer size requires less
			/// memory, it increases the rate at which buffers must be flushed.
			/// </para>
			/// </summary>
			public uint BufferSize;

			/// <summary>
			/// Minimum number of buffers allocated for the event tracing session's buffer pool. The minimum number of buffers that you can
			/// specify is two buffers per processor. For example, on a single processor computer, the minimum number of buffers is two. Note
			/// that if you use the EVENT_TRACE_NO_PER_PROCESSOR_BUFFERING logging mode, the number of processors is assumed to be 1.
			/// </summary>
			public uint MinimumBuffers;

			/// <summary>
			/// Maximum number of buffers allocated for the event tracing session's buffer pool. Typically, this value is the minimum number
			/// of buffers plus twenty. ETW uses the buffer size and the size of physical memory to calculate this value. This value must be
			/// greater than or equal to the value for <c>MinimumBuffers</c>. Note that you do not need to set this value if
			/// <c>LogFileMode</c> contains <c>EVENT_TRACE_BUFFERING_MODE</c>; instead, the total memory buffer size is instead the product
			/// of <c>MinimumBuffers</c> and <c>BufferSize</c>.
			/// </summary>
			public uint MaximumBuffers;

			/// <summary>
			/// <para>
			/// Maximum size of the file used to log events, in megabytes. Typically, you use this member to limit the size of a circular log
			/// file when you set <c>LogFileMode</c> to <c>EVENT_TRACE_FILE_MODE_CIRCULAR</c>. This member must be specified if
			/// <c>LogFileMode</c> contains <c>EVENT_TRACE_FILE_MODE_PREALLOCATE</c>, <c>EVENT_TRACE_FILE_MODE_CIRCULAR</c> or <c>EVENT_TRACE_FILE_MODE_NEWFILE</c>
			/// </para>
			/// <para>
			/// If you are using the system drive (the drive that contains the operating system) for logging, ETW checks for an additional
			/// 200MB of disk space, regardless of whether you are using the maximum file size parameter. Therefore, if you specify 100MB as
			/// the maximum file size for the trace file in the system drive, you need to have 300MB of free space on the drive.
			/// </para>
			/// </summary>
			public uint MaximumFileSize;

			/// <summary>
			/// <para>
			/// Logging modes for the event tracing session. You use this member to specify that you want events written to a log file, a
			/// real-time consumer, or both. You can also use this member to specify that the session is a private logger session. You can
			/// specify one or more modes. For a list of possible modes, see Logging Mode Constants.
			/// </para>
			/// <para>
			/// Do not specify real-time logging unless there are real-time consumers ready to consume the events. If there are no real-time
			/// consumers, ETW writes the events to a playback file. However, the size of the playback file is limited. If the limit is
			/// reached, no new events are logged (to the log file or playback file) and the logging functions fail with STATUS_LOG_FILE_FULL.
			/// </para>
			/// <para><c>Prior to Windows Vista:</c> If there was no real-time consumer, the events were discarded and logging continues.</para>
			/// <para>
			/// If a consumer begins processing real-time events, the events in the playback file are consumed first. After all events in the
			/// playback file are consumed, the session will begin logging new events.
			/// </para>
			/// </summary>
			public uint LogFileMode;

			/// <summary>
			/// <para>
			/// How often, in seconds, the trace buffers are forcibly flushed. The minimum flush time is 1 second. This forced flush is in
			/// addition to the automatic flush that occurs whenever a buffer is full and when the trace session stops.
			/// </para>
			/// <para>
			/// If zero, ETW flushes buffers as soon as they become full. If nonzero, ETW flushes all buffers that contain events based on
			/// the timer value. Typically, you want to flush buffers only when they become full. Forcing the buffers to flush (either by
			/// setting this member to a nonzero value or by calling <c>FlushTrace</c>) can increase the file size of the log file with
			/// unfilled buffer space.
			/// </para>
			/// <para>
			/// If the consumer is consuming events in real time, you may want to set this member to a nonzero value if the event rate is low
			/// to force events to be delivered before the buffer is full.
			/// </para>
			/// <para>
			/// For the case of a realtime logger, a value of zero (the default value) means that the flush time will be set to 1 second. A
			/// realtime logger is when <c>LogFileMode</c> is set to <c>EVENT_TRACE_REAL_TIME_MODE</c>.
			/// </para>
			/// </summary>
			public uint FlushTimer;

			/// <summary>
			/// <para>
			/// A system logger must set <c>EnableFlags</c> to indicate which SystemTraceProvider events should be included in the trace.
			/// This is also used for NT Kernel Logger sessions. This member can contain one or more of the following values. In addition to
			/// the events you specify, the kernel logger also logs hardware configuration events on Windows XP or system configuration
			/// events on Windows Server 2003.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Flag</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_ALPC 0x00100000</term>
			/// <term>Enables the ALPC event types. This value is supported on Windows Vista and later.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_CSWITCH 0x00000010</term>
			/// <term>Enables the following Thread event type: This value is supported on Windows Vista and later.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_DBGPRINT 0x00040000</term>
			/// <term>Enables the DbgPrint and DbgPrintEx calls to be converted to ETW events.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_DISK_FILE_IO 0x00000200</term>
			/// <term>Enables the following FileIo event type (you must also enable EVENT_TRACE_FLAG_DISK_IO):</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_DISK_IO 0x00000100</term>
			/// <term>Enables the following DiskIo event types:</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_DISK_IO_INIT 0x00000400</term>
			/// <term>Enables the following DiskIo event type: This value is supported on Windows Vista and later.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_DISPATCHER 0x00000800</term>
			/// <term>Enables the following Thread event type: This value is supported on Windows 7, Windows Server 2008 R2, and later.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_DPC 0x00000020</term>
			/// <term>Enables the following PerfInfo event type: This value is supported on Windows Vista and later.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_DRIVER 0x00800000</term>
			/// <term>Enables the following DiskIo event types: This value is supported on Windows Vista and later.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_FILE_IO 0x02000000</term>
			/// <term>Enables the following FileIo event types: This value is supported on Windows Vista and later.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_FILE_IO_INIT 0x04000000</term>
			/// <term>Enables the following FileIo event type: This value is supported on Windows Vista and later.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_IMAGE_LOAD 0x00000004</term>
			/// <term>Enables the following Image event type:</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_INTERRUPT 0x00000040</term>
			/// <term>Enables the following PerfInfo event type: This value is supported on Windows Vista and later.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_JOB 0x00080000</term>
			/// <term>This value is supported on Windows 10</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_MEMORY_HARD_FAULTS 0x00002000</term>
			/// <term>Enables the following PageFault_V2 event type:</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_MEMORY_PAGE_FAULTS 0x00001000</term>
			/// <term>Enables the following PageFault_V2 event type:</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_NETWORK_TCPIP 0x00010000</term>
			/// <term>Enables the TcpIp and UdpIp event types.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_NO_SYSCONFIG 0x10000000</term>
			/// <term>Do not do a system configuration rundown. This value is supported on Windows 8, Windows Server 2012, and later.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_PROCESS 0x00000001</term>
			/// <term>Enables the following Process event type:</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_PROCESS_COUNTERS 0x00000008</term>
			/// <term>Enables the following Process_V2 event type: This value is supported on Windows Vista and later.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_PROFILE 0x01000000</term>
			/// <term>Enables the following PerfInfo event type: This value is supported on Windows Vista and later.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_REGISTRY 0x00020000</term>
			/// <term>Enables the Registry event types.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_SPLIT_IO 0x00200000</term>
			/// <term>Enables the SplitIo event types. This value is supported on Windows Vista and later.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_SYSTEMCALL 0x00000080</term>
			/// <term>Enables the following PerfInfo event type: This value is supported on Windows Vista and later.</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_THREAD 0x00000002</term>
			/// <term>Enables the following Thread event type:</term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_VAMAP 0x00008000</term>
			/// <term>
			/// Enables the map and unmap (excluding image files) event type. This value is supported on Windows 8, Windows Server 2012, and later.
			/// </term>
			/// </item>
			/// <item>
			/// <term>EVENT_TRACE_FLAG_VIRTUAL_ALLOC 0x00004000</term>
			/// <term>Enables the following PageFault_V2 event type: This value is supported on Windows 7, Windows Server 2008 R2, and later.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint EnableFlags;

			/// <summary>
			/// <para>Not used.</para>
			/// <para><c>Windows 2000:</c> Time delay before unused buffers are freed, in minutes. The default is 15 minutes.</para>
			/// </summary>
			public int AgeLimit;

			/// <summary>On output, the number of buffers allocated for the event tracing session's buffer pool.</summary>
			public uint NumberOfBuffers;

			/// <summary>On output, the number of buffers that are allocated but unused in the event tracing session's buffer pool.</summary>
			public uint FreeBuffers;

			/// <summary>On output, the number of events that were not recorded.</summary>
			public uint EventsLost;

			/// <summary>On output, the number of buffers written.</summary>
			public uint BuffersWritten;

			/// <summary>On output, the number of buffers that could not be written to the log file.</summary>
			public uint LogBuffersLost;

			/// <summary>On output, the number of buffers that could not be delivered in real-time to the consumer.</summary>
			public uint RealTimeBuffersLost;

			/// <summary>On output, the thread identifier for the event tracing session.</summary>
			public HANDLE LoggerThreadId;

			/// <summary>
			/// <para>
			/// Offset from the start of the structure's allocated memory to beginning of the null-terminated string that contains the log
			/// file name.
			/// </para>
			/// <para>
			/// The file name should use the .etl extension. All folders in the path must exist. The path can be relative, absolute, local,
			/// or remote. The path cannot contain environment variables (they are not expanded). The user must have permission to write to
			/// the folder.
			/// </para>
			/// <para>
			/// The log file name is limited to 1,024 characters. If you set <c>LogFileMode</c> to <c>EVENT_TRACE_PRIVATE_LOGGER_MODE</c> or
			/// <c>EVENT_TRACE_FILE_MODE_NEWFILE</c>, be sure to allocate enough memory to include the process identifier that is appended to
			/// the file name for private loggers sessions, and the sequential number that is added to log files created using the new file
			/// log mode.
			/// </para>
			/// <para>
			/// If you do not want to log events to a log file (for example, you specify <c>EVENT_TRACE_REAL_TIME_MODE</c> only), set
			/// LogFileNameOffset to 0. If you specify only real-time logging and also provide an offset with a valid log file name, ETW will
			/// use the log file name to create a sequential log file and log events to the log file. ETW also creates the sequential log
			/// file if <c>LogFileMode</c> is 0 and you provide an offset with a valid log file name.
			/// </para>
			/// <para>
			/// If you want to log events to a log file, you must allocate enough memory for this structure to include the log file name and
			/// session name following the structure. The log file name must follow the session name in memory.
			/// </para>
			/// <para>
			/// Trace files are created using the default security descriptor, meaning that the log file will have the same ACL as the parent
			/// directory. If you want access to the files restricted, create a parent directory with the appropriate ACLs.
			/// </para>
			/// </summary>
			public uint LogFileNameOffset;

			/// <summary>
			/// <para>
			/// Offset from the start of the structure's allocated memory to beginning of the null-terminated string that contains the
			/// session name.
			/// </para>
			/// <para>The session name is limited to 1,024 characters. The session name is case-insensitive and must be unique.</para>
			/// <para>
			/// <c>Windows 2000:</c> Session names are case-sensitive. As a result, duplicate session names are allowed. However, to reduce
			/// confusion, you should make sure your session names are unique.
			/// </para>
			/// <para>
			/// When you allocate the memory for this structure, you must allocate enough memory to include the session name and log file
			/// name following the structure. The session name must come before the log file name in memory. You must copy the log file name
			/// to the offset but you do not copy the session name to the offset—the <c>StartTrace</c> function copies the name for you.
			/// </para>
			/// </summary>
			public uint LoggerNameOffset;

			/// <summary>The version of the structure. This should be set to "2" for this version.</summary>
			public uint VersionNumber;

			/// <summary>
			/// <para>
			/// Supported <c>EVENT_FILTER_DESCRIPTOR</c> filter types for system wide private loggers:
			/// <c>EVENT_FILTER_TYPE_EXECUTABLE_NAME</c> and <c>EVENT_FILTER_TYPE_PID</c>
			/// </para>
			/// <para>
			/// A pointer to an array of <c>EVENT_FILTER_DESCRIPTOR</c> structures that points to the filter data. The number of elements in
			/// the array is specified in the <c>FilterDescCount</c> member. There can only be one filter for a specific filter type as
			/// specified by the <c>Type</c> member of the <c>EVENT_FILTER_DESCRIPTOR</c> structure.
			/// </para>
			/// <para>
			/// This is only applicable to Private Loggers. The only time this should not be null is when it is used for system wide Private Loggers.
			/// </para>
			/// </summary>
			public IntPtr FilterDesc;

			/// <summary>
			/// The number of filters that the <c>FilterDesc</c> points to. The only time this should not be zero is for system wide Private Loggers.
			/// </summary>
			public uint FilterDescCount;

			/// <summary>
			/// <para>An extended set of configuration options:</para>
			/// <para>
			/// <c>Wow</c>: Marks whether or not this logger was created by a Wow64 process. This should never be set on input as it is
			/// reserved for internal use.
			/// </para>
			/// <para>
			/// <c>QpcDeltaTracking</c>: When set, this turns on QPC Delta Tracking events for use in Container scenarios. When a Container's
			/// QPC clock is not synchronized with the QPC clock of its host, this feature will insert QPC Delta events into the trace to
			/// allow the parsing engine to correlate a Container's trace with traces from the host. This is supported beginning in the next
			/// major release of Windows 10.
			/// </para>
			/// </summary>
			public uint V2Options;
		}

		/// <summary>
		/// You may use the <c>MOF_FIELD</c> structures to append event data to the EVENT_TRACE_HEADER or EVENT_INSTANCE_HEADER structures.
		/// </summary>
		/// <remarks>
		/// <para>Be sure to initialize the memory for this structure to zero before setting any members.</para>
		/// <para>
		/// If you use <c>MOF_FIELD</c> structures, you must set the <c>WNODE_FLAG_USE_MOF_PTR</c> flag in the <c>Flags</c> member of the
		/// EVENT_TRACE_HEADER or EVENT_INSTANCE_HEADER structure.
		/// </para>
		/// <para>
		/// The event tracing session automatically dereferences <c>MOF_FIELD</c> data pointers before passing the data to event trace
		/// consumers using EVENT_TRACE structures.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-mof_field typedef struct _MOF_FIELD { ULONG64 DataPtr;
		// ULONG Length; ULONG DataType; } MOF_FIELD, *PMOF_FIELD;
		[PInvokeData("evntrace.h", MSDNShortId = "64ff1191-2177-4d51-afcd-b58d510e9ae8")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MOF_FIELD
		{
			/// <summary>Pointer to a event data item.</summary>
			public ulong DataPtr;

			/// <summary>Length of the item pointed to by <c>DataPtr</c>, in bytes.</summary>
			public uint Length;

			/// <summary>Reserved.</summary>
			public uint DataType;
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
		/// The <c>PAYLOAD_FILTER_PREDICATE</c> structure is used with the TdhCreatePayloadFilter function to create a single payload filter
		/// for a single payload to be used with the EnableTraceEx2 function. A single payload filter can also be aggregated with other
		/// single payload filters using the TdhAggregatePayloadFilters function.
		/// </para>
		/// <para>
		/// Each field has a type specified in the provider manifest that can be used in the <c>Fieldname</c> member of the
		/// <c>PAYLOAD_FILTER_PREDICATE</c> structure to filter on that field.
		/// </para>
		/// <para>
		/// The <c>CompareOp</c> member specifies that operator to use for payload filtering. Payload filtering supports filtering on a
		/// string (including a <c>GUID</c>) and integers (including <c>TDH_INTYPE_FILETIME</c>). Filtering on floating-point numbers, a
		/// binary blob (including <c>TDH_INTYPE_POINTER</c>), and structured data ( <c>SID</c> and <c>SYSTEMTIME</c>) are not supported.
		/// </para>
		/// <para>
		/// The <c>Value</c> member contains a string of the value or values to compare with the value of the <c>Fieldname</c> member. The
		/// <c>Value</c> member is converted from a string to the type of the <c>Fieldname</c> member as specified in the manifest.
		/// </para>
		/// <para>
		/// All string comparisons are case-insensitive. The string in the <c>Value</c> member is UNICODE, but it will be converted to ANSI
		/// if the type specified in the manifest is ANSI.
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
			[MarshalAs(UnmanagedType.LPWStr)] public string FieldName;

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
			/// The value of the FieldName parameter is not equal to the numeric value of the string in the Value member. This operator is
			/// for comparing integers and requires one value in the Value member.
			/// </term>
			/// </item>
			/// <item>
			/// <term>PAYLOADFIELD_LE 2</term>
			/// <term>
			/// The value of the FieldName parameter is less than or equal to the numeric value of the string in the Value member. This
			/// operator is for comparing integers and requires one value in the Value member.
			/// </term>
			/// </item>
			/// <item>
			/// <term>PAYLOADFIELD_GT 3</term>
			/// <term>
			/// The value of the FieldName parameter is greater than the numeric value of the string in the Value member. This operator is
			/// for comparing integers and requires one value in the Value member.
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
			/// The value of the FieldName parameter is not between the two numeric values in the string in the Value member. This operator
			/// is for comparing integers and requires two values in the Value member. The two values should be separated by a comma
			/// character (',').
			/// </term>
			/// </item>
			/// <item>
			/// <term>PAYLOADFIELD_MODULO 8</term>
			/// <term>
			/// The value of the FieldName parameter is the modulo of the numeric value in the string in the Value member. The operator can
			/// be used for periodic sampling. This operator is for comparing integers and requires one value in the Value member.
			/// </term>
			/// </item>
			/// <item>
			/// <term>PAYLOADFIELD_CONTAINS 20</term>
			/// <term>
			/// The value of the FieldName parameter contains the substring value in the Value member. String comparisons are case
			/// insensitive. This operator is for comparing strings and requires one value in the Value member.
			/// </term>
			/// </item>
			/// <item>
			/// <term>PAYLOADFIELD_DOESNTCONTAIN 21</term>
			/// <term>
			/// The value of the FieldName parameter does not contain the substring in the Value member. String comparisons are case
			/// insensitive. This operator is for comparing strings and requires one value in the Value member.
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
			/// The value of the FieldName parameter is not identical to the value of the string in the Value member. String comparisons are
			/// case insensitive. This operator is for comparing strings or other non-integer values and requires one value in the Value member.
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
			[MarshalAs(UnmanagedType.LPWStr)] public string Value;
		}

		/// <summary/>
		[PInvokeData("evntrace.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct PROFILE_SOURCE_INFO
		{
			public uint NextEntryOffset;
			public uint Source;
			public uint MinInterval;
			public uint MaxInterval;
			public ulong Reserved;
			public ushort _Description;

			public string Description
			{
				get
				{
					unsafe
					{
						fixed (void* desc = &_Description)
						{
							return Marshal.PtrToStringUni((IntPtr)desc);
						}
					}
				}
			}
		}

		/// <summary>Defines the property to retrieve.</summary>
		/// <remarks>
		/// <para>To describe a structure, set PropertyName to the name of the structure and ArrayIndex to ULONG_MAX.</para>
		/// <para>
		/// To describe a member of a structure, define an array of two <c>PROPERTY_DATA_DESCRIPTOR</c> structures. In the first descriptor,
		/// set PropertyName to the name of the structure and ArrayIndex to 0. In the second descriptor, set PropertyName to the name of the
		/// member and ArrayIndex to ULONG_MAX.
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
			/// The following table lists the possible values of PropertyName for WPP events. Use the suggested TDH data type when formatting
			/// the returned buffer from TdhGetProperty.
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
			/// The local or global sequence number of the trace message. Local sequence numbers, which are unique only to this trace
			/// session, are the default.
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
			/// The name of the component of the provider that generated the trace message. The component name appears only if it is
			/// specified in the tracing code.
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
			/// Zero-based index for accessing elements of a property array. If the property data is not an array or if you want to address
			/// the entire array, specify ULONG_MAX (0xFFFFFFFF).
			/// </summary>
			public uint ArrayIndex;

			/// <summary>Reserved.</summary>
			public uint Reserved;
		}

		/// <summary>Defines the array of providers that have registered a MOF or manifest on the computer.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-provider_enumeration_info typedef struct _PROVIDER_ENUMERATION_INFO
		// { ULONG NumberOfProviders; ULONG Reserved; TRACE_PROVIDER_INFO TraceProviderInfoArray[ANYSIZE_ARRAY]; } PROVIDER_ENUMERATION_INFO;
		[PInvokeData("tdh.h", MSDNShortId = "bb4548fb-70e5-4726-bc92-adb7ba7be0e4")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROVIDER_ENUMERATION_INFO
		{
			/// <summary>Number of elements in the <c>TraceProviderInfoArray</c> array.</summary>
			public uint NumberOfProviders;

			/// <summary/>
			public uint Reserved;

			///// <summary>
			///// Array of TRACE_PROVIDER_INFO structures that contain information about each provider such as its name and unique identifier.
			///// </summary>
			//public TRACE_PROVIDER_INFO TraceProviderInfoArray[ANYSIZE_ARRAY];
		}

		/// <summary>The <c>PROVIDER_EVENT_INFO</c> structure defines an array of events in a provider manifest.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-provider_event_info typedef struct _PROVIDER_EVENT_INFO { ULONG
		// NumberOfEvents; ULONG Reserved; EVENT_DESCRIPTOR EventDescriptorsArray[ANYSIZE_ARRAY]; } PROVIDER_EVENT_INFO;
		[PInvokeData("tdh.h", MSDNShortId = "CC392841-7436-4543-A846-FB5A27D9A014")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROVIDER_EVENT_INFO
		{
			/// <summary>The number of elements in the <c>EventDescriptorsArray</c> array.</summary>
			public uint NumberOfEvents;

			/// <summary>Reserved.</summary>
			public uint Reserved;

			///// <summary>An array of EVENT_DESCRIPTOR structures that contain information about each event.</summary>
			//public EVENT_DESCRIPTOR EventDescriptorsArray[ANYSIZE_ARRAY];
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
		public struct PROVIDER_FIELD_INFOARRAY
		{
			/// <summary>Number of elements in the <c>FieldInfoArray</c> array.</summary>
			public uint NumberOfElements;

			/// <summary>
			/// Type of field information in the <c>FieldInfoArray</c> array. For possible values, see the EVENT_FIELD_TYPE enumeration.
			/// </summary>
			public EVENT_FIELD_TYPE FieldType;

			///// <summary>Array of PROVIDER_FIELD_INFO structures that define the field's name, description and value.</summary>
			//public PROVIDER_FIELD_INFO FieldInfoArray[ANYSIZE_ARRAY];
		}

		/// <summary>Defines a filter and its data.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-provider_filter_info typedef struct _PROVIDER_FILTER_INFO { UCHAR
		// Id; UCHAR Version; ULONG MessageOffset; ULONG Reserved; ULONG PropertyCount; EVENT_PROPERTY_INFO
		// EventPropertyInfoArray[ANYSIZE_ARRAY]; } PROVIDER_FILTER_INFO, *PPROVIDER_FILTER_INFO;
		[PInvokeData("tdh.h", MSDNShortId = "0541b24a-8531-4828-8c3b-d889e58b0b38")]
		[StructLayout(LayoutKind.Sequential)]
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

			///// <summary>An array of EVENT_PROPERTY_INFO structures that define the filter data.</summary>
			//public EVENT_PROPERTY_INFO EventPropertyInfoArray[ANYSIZE_ARRAY];
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
			/// example, if the context type is TDH_CONTEXT_WPP_TMFFILE, the context value is a Unicode string that contains the name of the
			/// .tmf file.
			/// </summary>
			public ulong ParameterValue;

			/// <summary>Context type. For a list of types, see the TDH_CONTEXT_TYPE enumeration.</summary>
			public TDH_CONTEXT_TYPE ParameterType;

			/// <summary>Reserved for future use.</summary>
			public uint ParameterSize;
		}

		/// <summary>Defines the session and the information that the session used to enable the provider.</summary>
		/// <remarks>The <c>TRACE_PROVIDER_INSTANCE_INFO</c> block contains one or more of these structures.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/etw/trace-enable-info typedef struct _TRACE_ENABLE_INFO { ULONG IsEnabled; UCHAR
		// Level; UCHAR Reserved1; USHORT LoggerId; ULONG EnableProperty; ULONG Reserved2; ULONGLONG MatchAnyKeyword; ULONGLONG
		// MatchAllKeyword; } TRACE_ENABLE_INFO, *PTRACE_ENABLE_INFO;
		[PInvokeData("evntrace.h", MSDNShortId = "999dd102-5937-4b1e-b841-623dddaa0df9")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRACE_ENABLE_INFO
		{
			/// <summary>
			/// Indicates if the provider is enabled to the session. The value is <c>TRUE</c> if the provider is enabled to the session,
			/// otherwise, the value is <c>FALSE</c>. This value should always be <c>TRUE</c>.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool IsEnabled;

			/// <summary>
			/// Level of detail that the session asked the provider to include in the events. For details, see the Level parameter of the
			/// <c>EnableTraceEx</c> function.
			/// </summary>
			public TRACE_LEVEL Level;

			/// <summary>Reserved.</summary>
			public byte Reserved1;

			/// <summary>Identifies the session that enabled the provider.</summary>
			public ushort LoggerId;

			/// <summary>
			/// Additional information that the session wants ETW to include in the log file. For details, see the EnableProperty parameter
			/// of the <c>EnableTraceEx</c> function.
			/// </summary>
			public uint EnableProperty;

			/// <summary>Reserved.</summary>
			public uint Reserved2;

			/// <summary>
			/// Keywords specify which events the session wants the provider to write. For details, see the MatchAnyKeyword parameter of the
			/// <c>EnableTraceEx</c> function.
			/// </summary>
			public ulong MatchAnyKeyword;

			/// <summary>
			/// Keywords specify which events the session wants the provider to write. For details, see the MatchAllKeyword parameter of the
			/// <c>EnableTraceEx</c> function.
			/// </summary>
			public ulong MatchAllKeyword;
		}

		/// <summary>Defines the information about the event.</summary>
		/// <remarks>The value of an offset is zero if the member is not defined.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/tdh/ns-tdh-trace_event_info typedef struct _TRACE_EVENT_INFO { GUID
		// ProviderGuid; GUID EventGuid; EVENT_DESCRIPTOR EventDescriptor; DECODING_SOURCE DecodingSource; ULONG ProviderNameOffset; ULONG
		// LevelNameOffset; ULONG ChannelNameOffset; ULONG KeywordsNameOffset; ULONG TaskNameOffset; ULONG OpcodeNameOffset; ULONG
		// EventMessageOffset; ULONG ProviderMessageOffset; ULONG BinaryXMLOffset; ULONG BinaryXMLSize; union { ULONG EventNameOffset; ULONG
		// ActivityIDNameOffset; }; union { ULONG EventAttributesOffset; ULONG RelatedActivityIDNameOffset; }; ULONG PropertyCount; ULONG
		// TopLevelPropertyCount; union { TEMPLATE_FLAGS Flags; struct { ULONG Reserved : 4; ULONG Tags : 28; }; }; EVENT_PROPERTY_INFO
		// EventPropertyInfoArray[ANYSIZE_ARRAY]; } TRACE_EVENT_INFO;
		[PInvokeData("tdh.h", MSDNShortId = "ecf57a23-0dd2-4954-82ac-e92f651c226f")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRACE_EVENT_INFO
		{
			/// <summary>A GUID that identifies the provider.</summary>
			public Guid ProviderGuid;

			/// <summary>
			/// A GUID that identifies the MOF class that contains the event. If the provider uses a manifest to define its events, this
			/// member is GUID_NULL.
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
			/// The offset from the beginning of this structure to a null-terminated Unicode string that contains the name of the channel.
			/// For possible names, see Remarks in ChannelType.
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
			/// The offset from the beginning of this structure to a null-terminated Unicode string that contains the name of the operation.
			/// For possible names, see Remarks in OpcodeType.
			/// </summary>
			public uint OpcodeNameOffset;

			/// <summary>
			/// <para>
			/// The offset from the beginning of this structure to a null-terminated Unicode string that contains the event message string.
			/// The offset is zero if there is no message string. For information on message strings, see the <c>message</c> attribute for EventDefinitionType.
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
			/// The offset from the beginning of this structure to a null-terminated Unicode string that contains the property name of the
			/// related activity identifier in the MOF class. Supported for legacy ETW events only.
			/// </summary>
			public uint RelatedActivityIDNameOffset;

			/// <summary>The number of elements in the <c>EventPropertyInfoArray</c> array.</summary>
			public uint PropertyCount;

			/// <summary>
			/// The number of properties in the <c>EventPropertyInfoArray</c> array that are top-level properties. This number does not
			/// include members of structures. Top-level properties come before all member properties in the array.
			/// </summary>
			public uint TopLevelPropertyCount;

			/// <summary>
			/// A 28-bit value associated with the event metadata. This value can be used by the event provider to associate additional
			/// semantic data with an event for use by an event processing tool. For example, a tag value of 5 might indicate that the event
			/// contains debugging information. The semantics of any values in this field are defined by the event provider.
			/// </summary>
			public uint Tags;

			///// <summary>An array of EVENT_PROPERTY_INFO structures that provides information about each property of the event's user data.</summary>
			//public EVENT_PROPERTY_INFO EventPropertyInfoArray[ANYSIZE_ARRAY];
		}

		/// <summary>Defines the header to the list of sessions that enabled the provider specified in the InBuffer parameter of <c>EnumerateTraceGuidsEx</c>.</summary>
		/// <remarks>Use the size of this structure to access the first <c>TRACE_PROVIDER_INSTANCE_INFO</c> block in the list.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/etw/trace-guid-info typedef struct _TRACE_GUID_INFO { ULONG InstanceCount; ULONG
		// Reserved; } TRACE_GUID_INFO, *PTRACE_GUID_INFO;
		[PInvokeData("evntrace.h", MSDNShortId = "2c484adf-605d-420b-8059-942b35305acd")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRACE_GUID_INFO
		{
			/// <summary>
			/// The number of <c>TRACE_PROVIDER_INSTANCE_INFO</c> blocks contained in the list. You can have multiple instances of the same
			/// provider if the provider lives in a DLL that is loaded by multiple processes.
			/// </summary>
			public uint InstanceCount;

			/// <summary>Reserved.</summary>
			public uint Reserved;
		}

		/// <summary>The <c>TRACE_GUID_PROPERTIES</c> structure contains information about an event trace provider.</summary>
		/// <remarks>Be sure to initialize the memory for this structure to zero before setting any members or passing to any functions.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/etw/trace-guid-properties typedef struct _TRACE_GUID_PROPERTIES { GUID Guid;
		// ULONG GuidType; ULONG LoggerId; ULONG EnableLevel; ULONG EnableFlags; BOOLEAN IsEnable; } TRACE_GUID_PROPERTIES, *PTRACE_GUID_PROPERTIES;
		[PInvokeData("evntrace.h", MSDNShortId = "849f2d34-14e0-43e8-a735-d46e94671725")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRACE_GUID_PROPERTIES
		{
			/// <summary>Control GUID of the event trace provider.</summary>
			public Guid Guid;

			/// <summary>Not used.</summary>
			public uint GuidType;

			/// <summary>Session handle that identifies the event tracing session.</summary>
			public uint LoggerId;

			/// <summary>Value passed as the EnableLevel parameter to the EnableTrace function.</summary>
			public uint EnableLevel;

			/// <summary>Value passed as the EnableFlag parameter to the EnableTrace function.</summary>
			public uint EnableFlags;

			/// <summary>
			/// If this member is TRUE, the element identified by the Guid member is currently enabled for the session identified by the
			/// LoggerId member. If this member is FALSE, all other members have no meaning and should be zero.
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool IsEnable;
		}

		/// <summary>The <c>TRACE_GUID_REGISTRATION</c> structure is used to register event trace classes.</summary>
		/// <remarks>Be sure to initialize the memory for this structure to zero before setting any members.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/trace-guid-registration typedef struct _TRACE_GUID_REGISTRATION { LPCGUID
		// Guid; HANDLE RegHandle; } TRACE_GUID_REGISTRATION;
		[PInvokeData("Evntrace.h", MSDNShortId = "fc7b61fb-ef1c-48ec-8523-5f3114b5407a")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRACE_GUID_REGISTRATION
		{
			/// <summary>Class GUID of an event trace class that you are registering.</summary>
			public GuidPtr Guid;

			/// <summary>
			/// <para>Handle to the registered event trace class. The <c>RegisterTraceGuids</c> function generates this value.</para>
			/// <para>
			/// Use this handle when you call the <c>CreateTraceInstanceId</c> function and to set the <c>RegHandle</c> member of
			/// <c>EVENT_INSTANCE_HEADER</c> when calling the <c>TraceEventInstance</c> function.
			/// </para>
			/// </summary>
			public HANDLE RegHandle;
		}

		/// <summary>The TRACE_LOGFILE_HEADER structure contains information about an event tracing session and its events.</summary>
		/// <remarks>
		/// <para>Be sure to initialize the memory for this structure to zero before setting any members.</para>
		/// <para>
		/// The first event from any log file contains the data defined in this structure. You can use this structure to access the event
		/// data or you can use the EventTrace_Header MOF class to decode the event data. Using this structure to read the event data may
		/// return unexpected results if the consumer is on a different computer from the one that generated the log file or the log file was
		/// written in a WOW (32-bit) session on a 64-bit computer. This is because the <c>LoggerName</c> and <c>LogFileName</c> members are
		/// pointers and can vary in size depending on the <c>PointerSize</c> member.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntrace/ns-evntrace-trace_logfile_header typedef struct
		// _TRACE_LOGFILE_HEADER { ULONG BufferSize; union { ULONG Version; struct { UCHAR MajorVersion; UCHAR MinorVersion; UCHAR
		// SubVersion; UCHAR SubMinorVersion; } VersionDetail; } DUMMYUNIONNAME; ULONG ProviderVersion; ULONG NumberOfProcessors;
		// LARGE_INTEGER EndTime; ULONG TimerResolution; ULONG MaximumFileSize; ULONG LogFileMode; ULONG BuffersWritten; union { GUID
		// LogInstanceGuid; struct { ULONG StartBuffers; ULONG PointerSize; ULONG EventsLost; ULONG CpuSpeedInMHz; } DUMMYSTRUCTNAME; }
		// DUMMYUNIONNAME2; LARGE_INTEGER BootTime; LARGE_INTEGER PerfFreq; LARGE_INTEGER StartTime; ULONG ReservedFlags; ULONG BuffersLost;
		// } TRACE_LOGFILE_HEADER, *PTRACE_LOGFILE_HEADER;
		[PInvokeData("evntrace.h", MSDNShortId = "13fdabe6-c904-4546-b876-c145f6a6c345")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRACE_LOGFILE_HEADER
		{
			/// <summary>Size of the event tracing session's buffers, in bytes.</summary>
			public uint BufferSize;

			/// <summary>
			/// Version number of the operating system. This is a roll-up of the members of <c>VersionDetail</c>. Starting with the low-order
			/// bytes, the first two bytes contain <c>MajorVersion</c>, the next two bytes contain <c>MinorVersion</c>, the next two bytes
			/// contain <c>SubVersion</c>, and the last two bytes contain <c>SubMinorVersion</c>.
			/// </summary>
			public VERSIONDETAIL VersionDetail;

			/// <summary>Build number of the operating system.</summary>
			public uint ProviderVersion;

			/// <summary>Number of processors on the system.</summary>
			public uint NumberOfProcessors;

			/// <summary>
			/// Time at which the event tracing session stopped, in 100-nanosecond intervals since midnight, January 1, 1601. This value may
			/// be 0 if you are consuming events in real time or from a log file to which the provide is still logging events.
			/// </summary>
			public FILETIME EndTime;

			/// <summary>Resolution of the hardware timer, in units of 100 nanoseconds. For usage, see the Remarks for EVENT_TRACE_HEADER.</summary>
			public uint TimerResolution;

			/// <summary>Maximum size of the log file, in megabytes.</summary>
			public uint MaximumFileSize;

			/// <summary>Current logging mode for the event tracing session. For a list of values, see Logging Mode Constants.</summary>
			public LogFileMode LogFileMode;

			/// <summary>Total number of buffers written by the event tracing session.</summary>
			public uint BuffersWritten;

			/// <summary>Reserved.</summary>
			public uint StartBuffers;

			/// <summary>Size of a pointer data type, in bytes.</summary>
			public uint PointerSize;

			/// <summary>
			/// Number of events lost during the event tracing session. Events may be lost due to insufficient memory or a very high rate of
			/// incoming events.
			/// </summary>
			public uint EventsLost;

			/// <summary>
			/// <para>CPU speed, in megahertz.</para>
			/// <para><c>Windows 2000:</c> This member is not supported.</para>
			/// </summary>
			public uint CpuSpeedInMHz;

			/// <summary>
			/// Do not use.
			/// <para>The name of the event tracing session is the first null-terminated string following this structure in memory.</para>
			/// </summary>
			public StrPtrUni LoggerName;

			/// <summary>
			/// Do Not use.
			/// <para>
			/// The name of the event tracing log file is the second null-terminated string following this structure in memory.The first
			/// string is the name of the session.
			/// </para>
			/// </summary>
			public StrPtrUni LogFileName;

			/// <summary>A TIME_ZONE_INFORMATION structure that contains the time zone for the BootTime, EndTime and StartTime members.</summary>
			public TIME_ZONE_INFORMATION TimeZone;

			/// <summary>
			/// Time at which the system was started, in 100-nanosecond intervals since midnight, January 1, 1601. <c>BootTime</c> is
			/// supported only for traces written to the Global Logger session.
			/// </summary>
			public FILETIME BootTime;

			/// <summary>Frequency of the high-resolution performance counter, if one exists.</summary>
			public long PerfFreq;

			/// <summary>Time at which the event tracing session started, in 100-nanosecond intervals since midnight, January 1, 1601.</summary>
			public FILETIME StartTime;

			/// <summary>Specifies the clock type. For details, see the <c>ClientContext</c> member of WNODE_HEADER.</summary>
			public uint ReservedFlags;

			/// <summary>Total number of buffers lost during the event tracing session.</summary>
			public uint BuffersLost;

			/// <summary>
			/// Version number of the operating system. This is a roll-up of the members of <c>VersionDetail</c>. Starting with the low-order
			/// bytes, the first two bytes contain <c>MajorVersion</c>, the next two bytes contain <c>MinorVersion</c>, the next two bytes
			/// contain <c>SubVersion</c>, and the last two bytes contain <c>SubMinorVersion</c>.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct VERSIONDETAIL
			{
				/// <summary>Major version number of the operating system.</summary>
				public byte MajorVersion;

				/// <summary>Minor version number of the operating system.</summary>
				public byte MinorVersion;

				/// <summary>Reserved.</summary>
				public byte SubVersion;

				/// <summary>Reserved.</summary>
				public byte SubMinorVersion;
			}
		}

		/// <summary>Information relating to a periodic capture state.</summary>
		/// <remarks>
		/// <para>
		/// Periodic capture state is a way to allow capture state notifications to be routinely sent to providers. When this is enabled,
		/// notifications will only be sent to provider registrations that have been previously enabled to the current session. Each provider
		/// can define its own response (if any) to a notification. Note that events logged by the provider in response to a notification
		/// will be sent to every ETW session that the provider is enabled to, similar to a manually requested capture state.
		/// </para>
		/// <para>To use periodic capture state:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Allocate a buffer of type <c>TRACE_PERIODIC_CAPTURE_STATE_INFO</c>. The size of the buffer should be: sizeof(
		/// <c>TRACE_PERIODIC_CAPTURE_STATE_INFO</c>) + (x * sizeof(GUID)), where x is the number of providers you would like to enable.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Call <c>TraceQueryInformation</c> using <c>TracePeriodicCaptureStateInfo</c> for the <c>TRACE_INFO_CLASS</c> enumeration. Pass
		/// the buffer and its size as the TraceInformation and InformationLength parameters of <c>TraceQueryInformation</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Set <c>CaptureStateFrequencyInSeconds</c> from <c>TRACE_PERIODIC_CAPTURE_STATE_INFO</c> to the minimum frequency supported by the
		/// version of Windows. This value may change in the future, so hard coding it is not recommended. If the frequency is below the
		/// minimum, the call to <c>TraceSetInformation</c> will fail.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Set the <c>ProviderCount</c> from <c>TRACE_PERIODIC_CAPTURE_STATE_INFO</c> to the number of provider GUIDs being passed.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Add the GUIDs of each provider after the end of the <c>TRACE_PERIODIC_CAPTURE_STATE_INFO</c> structure. This uses the extra space
		/// allocated from (x * sizeof(GUID) from the first step.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Call <c>TraceSetInformation</c> using <c>TracePeriodicCaptureStateListInfo</c> from the <c>TRACE_INFO_CLASS</c> enumeration.</term>
		/// </item>
		/// <item>
		/// <term>
		/// To turn periodic capture state off, call <c>TraceSetInformation</c> again with <c>TracePeriodicCaptureStateListInfo</c> from the
		/// <c>TRACE_INFO_CLASS</c>, NULL for the <c>TraceInformation</c>, and 0 as the <c>InformationLength</c>.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/etw/trace-periodic-capture-state-info typedef struct
		// _TRACE_PERIODIC_CAPTURE_STATE_INFO { ULONG CaptureStateFrequencyInSeconds; USHORT ProviderCount; USHORT Reserved; }
		// TRACE_PERIODIC_CAPTURE_STATE_INFO, *PTRACE_PERIODIC_CAPTURE_STATE_INFO;
		[PInvokeData("evntrace.h", MSDNShortId = "6C032D97-4B37-48D2-BD1A-35B8BA48B8AB")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRACE_PERIODIC_CAPTURE_STATE_INFO
		{
			/// <summary>The frequency of state captures in seconds.</summary>
			public uint CaptureStateFrequencyInSeconds;

			/// <summary>The number of providers.</summary>
			public ushort ProviderCount;

			/// <summary>Reserved for future use.</summary>
			public ushort Reserved;
		}

		/// <summary/>
		[PInvokeData("evntrace.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRACE_PROFILE_INTERVAL
		{
			public uint Source;
			public uint Interval;
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

		/// <summary>Defines an instance of the provider GUID.</summary>
		/// <remarks>
		/// If more than one provider uses the same GUID, the <c>TRACE_GUID_INFO</c> block contains more than one
		/// <c>TRACE_PROVIDER_INSTANCE_INFO</c> structure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/etw/trace-provider-instance-info typedef struct _TRACE_PROVIDER_INSTANCE_INFO {
		// ULONG NextOffset; ULONG EnableCount; ULONG Pid; ULONG Flags; } TRACE_PROVIDER_INSTANCE_INFO, *PTRACE_PROVIDER_INSTANCE_INFO;
		[PInvokeData("evntrace.h", MSDNShortId = "49c11cd5-2cb1-474a-8b51-2d86b4501da1")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRACE_PROVIDER_INSTANCE_INFO
		{
			/// <summary>
			/// Offset, in bytes, from the beginning of this structure to the next <c>TRACE_PROVIDER_INSTANCE_INFO</c> structure. The value
			/// is zero if there is not another instance info block.
			/// </summary>
			public uint NextOffset;

			/// <summary>
			/// Number of <c>TRACE_ENABLE_INFO</c> structures in this block. Each structure represents a session that enabled the provider.
			/// </summary>
			public uint EnableCount;

			/// <summary>Process identifier of the process that registered the provider.</summary>
			public uint Pid;

			/// <summary>
			/// <para>Can be one of the following flags.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRACE_PROVIDER_FLAG_LEGACY</term>
			/// <term>The provider used RegisterTraceGuids instead of EventRegister to register itself.</term>
			/// </item>
			/// <item>
			/// <term>TRACE_PROVIDER_FLAG_PRE_ENABLE</term>
			/// <term>The provider is not registered; however, one or more sessions have enabled the provider.</term>
			/// </item>
			/// </list>
			/// </summary>
			public TRACE_PROVIDER_FLAG Flags;
		}

		/// <summary>Determines the version information of the TraceLogging session.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-trace_version_info typedef struct _TRACE_VERSION_INFO {
		// UINT EtwTraceProcessingVersion; UINT Reserved; } TRACE_VERSION_INFO, *PTRACE_VERSION_INFO;
		[PInvokeData("evntrace.h", MSDNShortId = "E2B291DB-928F-4170-8684-4B26A7E067BD")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRACE_VERSION_INFO
		{
			/// <summary>TraceLogging version information.</summary>
			public uint EtwTraceProcessingVersion;

			/// <summary>Not used.</summary>
			public uint Reserved;
		}

		/// <summary>Provides a handle to an event trace.</summary>
		[PInvokeData("evntrace.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRACEHANDLE
		{
			private readonly ulong handle;

			/// <summary>Initializes a new instance of the <see cref="TRACEHANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public TRACEHANDLE(ulong preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="TRACEHANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static TRACEHANDLE NULL => new TRACEHANDLE(0);

			/// <summary>Gets a value indicating whether this instance is invalid.</summary>
			public bool IsInvalid => handle == 0 || handle == 0x00000000FFFFFFFF;

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == 0;

			/// <summary>Performs an explicit conversion from <see cref="TRACEHANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator ulong(TRACEHANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="TRACEHANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator TRACEHANDLE(ulong h) => new TRACEHANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(TRACEHANDLE h1, TRACEHANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(TRACEHANDLE h1, TRACEHANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is TRACEHANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();
		}

		/// <summary>The <c>WNODE_HEADER</c> structure is a member of the <c>EVENT_TRACE_PROPERTIES</c> structure.</summary>
		/// <remarks>
		/// <para>Be sure to initialize the memory for this structure to zero before setting any members.</para>
		/// <para>To convert an ETW timestamp into a FILETIME, use the following procedure:</para>
		/// <para>
		/// 1. For each session or log file being processed (i.e. for each EVENT\_TRACE\_LOGFILE), check the logFile.ProcessTraceMode field
		/// to determine whether the PROCESS\_TRACE\_MODE\_RAW\_TIMESTAMP flag is set. By default, this flag is not set. If this flag is not
		/// set, the ETW runtime will automatically convert the timestamp of each EVENT\_RECORD into a FILETIME before sending the
		/// EVENT\_RECORD to your EventRecordCallback function, so no additional processing is needed. The following steps should only be
		/// used if the trace is being processed with the PROCESS\_TRACE\_MODE\_RAW\_TIMESTAMP flag set. 2. For each session or log file
		/// being processed (i.e. for each EVENT\_TRACE\_LOGFILE), check the logFile.LogfileHeader.ReservedFlags field to determine the time
		/// stamp scale for the log file. Based on the value of ReservedFlags, follow one of these steps to determine the value to use for
		/// timeStampScale in the remaining steps: 3. On the FIRST call to your EventRecordCallback function for a particular log file, use
		/// data from the logFile (EVENT\_TRACE\_LOGFILE) and from the eventRecord (EVENT\_RECORD) to compute the timeStampBase that will be
		/// used for the remaining events in the log file: INT64 timeStampBase = logFile.LogfileHeader.StartTime.QuadPart -
		/// (INT64)(timeStampScale \* eventRecord.EventHeader.TimeStamp.QuadPart); 4. For each eventRecord (EVENT\_RECORD), convert the
		/// event’s timestamp into FILETIME as follows, using the timeStampScale and timeStampBase values calculated in steps 2 and 3: INT64
		/// timeStampInFileTime = timeStampBase + (INT64)(timeStampScale \* eventRecord.EventHeader.TimeStamp.QuadPart);
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/wnode-header typedef struct _WNODE_HEADER { ULONG BufferSize; ULONG
		// ProviderId; union { ULONG64 HistoricalContext; struct { ULONG Version; ULONG Linkage; }; }; union { HANDLE KernelHandle;
		// LARGE_INTEGER TimeStamp; }; GUID Guid; ULONG ClientContext; ULONG Flags; } WNODE_HEADER, *PWNODE_HEADER;
		[PInvokeData("evntrace.h", MSDNShortId = "862a8f46-a326-48c6-92b7-8bb667837bb7")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WNODE_HEADER
		{
			/// <summary>
			/// Total size of memory allocated, in bytes, for the event tracing session properties. The size of memory must include the room
			/// for the <c>EVENT_TRACE_PROPERTIES</c> structure plus the session name string and log file name string that follow the
			/// structure in memory.
			/// </summary>
			public uint BufferSize;

			/// <summary>Reserved for internal use.</summary>
			public uint ProviderId;

			/// <summary>On output, the handle to the event tracing session.</summary>
			public TRACEHANDLE HistoricalContext;

			/// <summary>
			/// Time at which the information in this structure was updated, in 100-nanosecond intervals since midnight, January 1, 1601.
			/// </summary>
			public FILETIME TimeStamp;

			/// <summary>
			/// <para>The GUID that you define for the session.</para>
			/// <para>For an NT Kernel Logger session, set this member to <c>SystemTraceControlGuid</c>.</para>
			/// <para>If this member is set to <c>SystemTraceControlGuid</c> or <c>GlobalLoggerGuid</c>, the logger will be a system logger.</para>
			/// <para>For a private logger session, set this member to the provider's GUID that you are going to enable for the session.</para>
			/// <para>
			/// If you start a session that is not a kernel logger or private logger session, you do not have to specify a session GUID. If
			/// you do not specify a GUID, ETW creates one for you. You need to specify a session GUID only if you want to change the default
			/// permissions associated with a specific session. For details, see the EventAccessControl function.
			/// </para>
			/// <para>You cannot start more than one session with the same session GUID.</para>
			/// <para><c>Prior to Windows Vista:</c> You can start more than one session with the same session GUID.</para>
			/// </summary>
			public Guid Guid;

			/// <summary>
			/// <para>Clock resolution to use when logging the time stamp for each event. The default is Query performance counter (QPC).</para>
			/// <para><c>Prior to Windows Vista:</c> The default is system time.</para>
			/// <para>
			/// <c>Prior to Windows 10, version 1703:</c> No more than 2 distinct clock types can be used simultaneously by any system loggers.
			/// </para>
			/// <para>
			/// <c>Starting with Windows 10, version 1703:</c> The clock type restriction has been removed. All three clock types can now be
			/// used simultaneously by system loggers.
			/// </para>
			/// <para>You can specify one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>1</term>
			/// <term>
			/// Query performance counter (QPC). The QPC counter provides a high-resolution time stamp that is not affected by adjustments to
			/// the system clock. The time stamp stored in the event is equivalent to the value returned from the QueryPerformanceCounter
			/// API. For more information on the characteristics of this time stamp, see Acquiring high-resolution time stamps. You should
			/// use this resolution if you have high event rates or if the consumer merges events from different buffers. In these cases, the
			/// precision and stability of the QPC time stamp allows for better accuracy in ordering the events from different buffers.
			/// However, the QPC time stamp will not reflect updates to the system clock, e.g. if the system clock is adjusted forward due to
			/// synchronization with an NTP server while the trace is in progress, the QPC time stamps in the trace will continue to reflect
			/// time as if no update had occurred. To determine the resolution, use the PerfFreq member of TRACE_LOGFILE_HEADER when
			/// consuming the event. To convert an event’s time stamp into 100-ns units, use the following conversion formula:
			/// scaledTimestamp = eventRecord.EventHeader.TimeStamp.QuadPart * 10000000.0 / logfileHeader.PerfFreq.QuadPart Note that on
			/// older computers, the time stamp may not be accurate because the counter sometimes skips forward due to hardware errors.
			/// </term>
			/// </item>
			/// <item>
			/// <term>2</term>
			/// <term>
			/// System time. The system time provides a time stamp that tracks changes to the system’s clock, e.g. if the system clock is
			/// adjusted forward due to synchronization with an NTP server while the trace is in progress, the System Time time stamps in the
			/// trace will also jump forward to match the new setting of the system clock. Prior to Windows 10, the resolution of this time
			/// stamp was the resolution of a system clock tick, as indicated by the TimerResolution member of TRACE_LOGFILE_HEADER. Starting
			/// with Windows 10, the resolution of this time stamp is the performance counter resolution, as indicated by the PerfFreq member
			/// of TRACE_LOGFILE_HEADER. To convert an event’s time stamp into 100-ns units, use the following conversion formula:
			/// scaledTimestamp = eventRecord.EventHeader.TimeStamp.QuadPart Note that when events are captured on a system running an OS
			/// prior to Windows 10, if the volume of events is high, the resolution for system time may not be fine enough to determine the
			/// sequence of events. In this case, a set of events will have the same time stamp, but the order in which ETW delivers the
			/// events may not be correct. Starting with Windows 10, the time stamp is captured with additional precision, though some
			/// instability may still occur in cases where the system clock was adjusted while the trace was being captured.
			/// </term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>
			/// CPU cycle counter. The CPU counter provides the highest resolution time stamp and is the least resource-intensive to
			/// retrieve. However, the CPU counter is unreliable and should not be used in production. For example, on some computers, the
			/// timers will change frequency due to thermal and power changes, in addition to stopping in some states. To determine the
			/// resolution, use the CpuSpeedInMHz member of TRACE_LOGFILE_HEADER when consuming the event. If your hardware does not support
			/// this clock type, ETW uses system time. Windows Server 2003, Windows XP with SP1 and Windows XP: This value is not supported,
			/// it was introduced in Windows Server 2003 with SP1 and Windows XP with SP2.
			/// </term>
			/// </item>
			/// </list>
			/// <para><c>Windows 2000:</c> The <c>ClientContext</c> member is not supported.</para>
			/// </summary>
			public uint ClientContext;

			/// <summary>Must contain <c>WNODE_FLAG_TRACED_GUID</c> to indicate that the structure contains event tracing information.</summary>
			public WNODE_FLAG Flags;
		}

		[StructLayout(LayoutKind.Sequential)]
		public abstract class PEVENT_INSTANCE_HEADER
		{
			public EVENT_INSTANCE_HEADER Header;
		}

		[StructLayout(LayoutKind.Sequential)]
		public abstract class PEVENT_TRACE_HEADER
		{
			public EVENT_TRACE_HEADER Header;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="TRACEHANDLE"/> that is disposed using <see cref="CloseTrace"/>.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public class SafeTRACEHANDLE : MarshalByRefObject, IDisposable
		{
			private readonly ulong handle;

			/// <summary>Initializes a new instance of the <see cref="SafeTRACEHANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeTRACEHANDLE(ulong preexistingHandle, bool ownsHandle = true) { }

			/// <summary>Initializes a new instance of the <see cref="SafeTRACEHANDLE"/> class.</summary>
			private SafeTRACEHANDLE() : base() { }

			/// <summary>Gets a value indicating whether this instance is invalid.</summary>
			/// <value><c>true</c> if this instance is invalid; otherwise, <c>false</c>.</value>
			public bool IsInvalid => handle == 0 || handle == 0x00000000FFFFFFFF;

			/// <summary>Performs an implicit conversion from <see cref="SafeTRACEHANDLE"/> to <see cref="TRACEHANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator TRACEHANDLE(SafeTRACEHANDLE h) => h.handle;

			/// <inheritdoc/>
			public void Dispose() => CloseTrace(handle);
		}
	}
}