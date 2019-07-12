using System;
using System.Runtime.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
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
		public delegate Win32Error ControlCallback(WMIDPREQUESTCODE RequestCode, IntPtr Context, in uint Reserved, IntPtr Buffer);

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
			/// <summary>Marks the last value in the enumeration for testing purposes. Should not be used.</summary>
			EtwQueryProcessHandleInfoMax,
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
			/// <summary>Reserved.</summary>
			EventSecurityMax,
		}

		/// <summary>Provider-defined value that specifies the level of information the event generates.</summary>
		[PInvokeData("evntrace.h", MSDNShortId = "d75f18e1-e5fa-4039-bb74-76dea334b0fd")]
		public enum TRACE_LEVEL
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
			TraceGuidQueryList,

			/// <summary>Query information that each session used to enable the provider.</summary>
			TraceGuidQueryInfo,

			/// <summary>Query an array of GUIDs of the providers that registered themselves in the same process as the calling process.</summary>
			TraceGuidQueryProcess,

			/// <summary>
			/// Query the setting for call stack tracing for kernel events. The value is supported on Windows 7, Windows Server 2008 R2, and later.
			/// </summary>
			TraceStackTracingInfo,

			/// <summary>
			/// Query the setting for the EnableFlags for the system trace provider. For more information, see the EVENT_TRACE_PROPERTIES
			/// structure. The value is supported on Windows 8, Windows Server 2012, and later.
			/// </summary>
			TraceSystemTraceEnableFlagsInfo,

			/// <summary>
			/// Queries the setting for the sampling profile interval for the supplied source. The value is supported on Windows 8, Windows
			/// Server 2012, and later.
			/// </summary>
			TraceSampledProfileIntervalInfo,

			/// <summary>
			/// Query the setting for sampled profile list information. The value is supported on Windows 8, Windows Server 2012, and later.
			/// </summary>
			TraceProfileSourceListInfo,

			/// <summary>
			/// Query the list of performance monitoring counters to collect The value is supported on Windows 8, Windows Server 2012, and later.
			/// </summary>
			TracePmcCounterListInfo,

			/// <summary>Query the trace file version information. The value is supported on Windows 10.</summary>
			TraceVersionInfo,

			/// <summary>
			/// Queries the currently-configured maximum number of system loggers allowed by the operating system. Returns a ULONG. Used with
			/// EnumerateTraceGuidsEx. The value is supported on Windows 10, version 1709 and later.
			/// </summary>
			TraceMaxLoggersQuery,

			/// <summary>Marks the last value in the enumeration. Do not use.</summary>
			MaxTraceSetInfoClass,
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
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/enabletrace ULONG EnableTrace( _In_ ULONG Enable, _In_ ULONG EnableFlag, _In_
		// ULONG EnableLevel, _In_ LPCGUID ControlGuid, _In_ TRACEHANDLE SessionHandle );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntrace.h", MSDNShortId = "d75f18e1-e5fa-4039-bb74-76dea334b0fd")]
		public static extern Win32Error EnableTrace([MarshalAs(UnmanagedType.Bool)] bool Enable, uint EnableFlag, TRACE_LEVEL EnableLevel, in Guid ControlGuid, TRACEHANDLE SessionHandle);

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
		public static extern Win32Error EnableTraceEx(in Guid ProviderId, in Guid SourceId, TRACEHANDLE TraceHandle, [MarshalAs(UnmanagedType.Bool)] bool IsEnabled, byte Level, ulong MatchAnyKeyword, ulong MatchAllKeyword, uint EnableProperty, in EVENT_FILTER_DESCRIPTOR EnableFilterDesc);

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
		public static extern Win32Error EnableTraceEx2(TRACEHANDLE TraceHandle, in Guid ProviderId, EVENT_TRACE_CONTROL ControlCode, byte Level, ulong MatchAnyKeyword, ulong MatchAllKeyword, uint Timeout, in ENABLE_TRACE_PARAMETERS EnableParameters);

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
		public static extern Win32Error EnumerateTraceGuids([In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TRACE_GUID_PROPERTIES[] GuidPropertiesArray, uint PropertyArrayCount, out uint GuidCount);

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
		public static extern byte GetTraceEnableLevel(TRACEHANDLE SessionHandle);

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
		public static extern TRACEHANDLE OpenTrace(in EVENT_TRACE_LOGFILE Logfile);

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
		public static extern Win32Error QueryAllTraces([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] EVENT_TRACE_PROPERTIES[] PropertyArray, uint PropertyArrayCount, out uint LoggerCount);

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
		public static extern Win32Error RegisterTraceGuids([MarshalAs(UnmanagedType.FunctionPtr)] ControlCallback RequestAddress, IntPtr RequestContext, in Guid ControlGuid, uint GuidCount, ref TRACE_GUID_REGISTRATION TraceGuidReg, string MofImagePath, string MofResourceName, out TRACEHANDLE RegistrationHandle);

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
		public static extern Win32Error TraceEvent(TRACEHANDLE SessionHandle, in EVENT_TRACE_HEADER EventTrace);

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
		public static extern Win32Error TraceEventInstance(TRACEHANDLE SessionHandle, in EVENT_INSTANCE_HEADER EventTrace, in EVENT_INSTANCE_INFO pInstInfo, in EVENT_INSTANCE_INFO pParentInstInfo);

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
		/// <param name="Arguments">
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
		public static extern Win32Error TraceMessage(TRACEHANDLE SessionHandle, TRACE_MESSAGE MessageFlags, in Guid MessageGuid, ushort MessageNumber, IntPtr Arguments);

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
		/// <param name="__arglist">
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
		public static extern Win32Error TraceMessageVa(TRACEHANDLE SessionHandle, TRACE_MESSAGE MessageFlags, in Guid MessageGuid, ushort MessageNumber, __arglist);

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
		public static extern Win32Error UpdateTrace(TRACEHANDLE TraceHandle, string InstanceName, ref EVENT_TRACE_PROPERTIES Properties);

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
			/// <summary>Type of event.</summary>
			public byte Type;
			/// <summary>
			/// Provider-defined value that defines the severity level used to generate the event. The value ranges from 0 to 255. The
			/// controller specifies the severity level when it calls the EnableTrace function. The provider retrieves the severity level by
			/// calling the GetTraceEnableLevel function from its ControlCallback implementation. The provider uses the value to set this member.
			/// </summary>
			public byte Level;
			/// <summary>
			/// Indicates the version of the event trace class that you are using to log the event. Specify zero if there is only one version
			/// of your event trace class. The version tells the consumer which MOF class to use to decipher the event data.
			/// </summary>
			public ushort Version;
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
		// https://docs.microsoft.com/en-us/windows/desktop/ETW/event-trace-logfile typedef struct _EVENT_TRACE_LOGFILE { LPTSTR LogFileName;
		// LPTSTR LoggerName; LONGLONG CurrentTime; ULONG BuffersRead; union { ULONG LogFileMode; ULONG ProcessTraceMode; }; EVENT_TRACE
		// CurrentEvent; TRACE_LOGFILE_HEADER LogfileHeader; PEVENT_TRACE_BUFFER_CALLBACK BufferCallback; ULONG BufferSize; ULONG Filled;
		// ULONG EventsLost; union { PEVENT_CALLBACK EventCallback; PEVENT_RECORD_CALLBACK EventRecordCallback; }; ULONG IsKernelTrace; PVOID
		// Context; } EVENT_TRACE_LOGFILE, *PEVENT_TRACE_LOGFILE;
		[PInvokeData("Evntrace.h", MSDNShortId = "179451e9-7e3c-4d3a-bcc6-3ad9d382229a")]
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
			/// <summary>Reserved. Do not use.</summary>
			public uint LogFileMode;
			/// <summary>
			/// Modes for processing events. The modes are defined in the Evntcons.h header file. You can specify one or more of the
			/// following modes:
			/// </summary>
			public uint ProcessTraceMode;
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
			/// <summary>
			/// <para>Pointer to the <c>EventCallback</c> function that ETW calls for each event in the buffer.</para>
			/// <para>
			/// Specify this callback if you are consuming events from a provider that used one of the <c>TraceEvent</c> functions to log events.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public EventClassCallback EventCallback;
			/// <summary>
			/// <para>Pointer to the <c>EventRecordCallback</c> function that ETW calls for each event in the buffer.</para>
			/// <para>
			/// Specify this callback if you are consuming events from a provider that used one of the <c>EventWrite</c> functions to log events.
			/// </para>
			/// <para><c>Prior to Windows Vista:</c> Not supported.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public EventRecordCallback EventRecordCallback;
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
		// DUMMYUNIONNAME2; #if ... PWCHAR LoggerName; #if ... PWCHAR LogFileName; #if ... RTL_TIME_ZONE_INFORMATION TimeZone; #else LPWSTR
		// LoggerName; #endif #else LPWSTR LogFileName; #endif #else TIME_ZONE_INFORMATION TimeZone; #endif LARGE_INTEGER BootTime;
		// LARGE_INTEGER PerfFreq; LARGE_INTEGER StartTime; ULONG ReservedFlags; ULONG BuffersLost; } TRACE_LOGFILE_HEADER, *PTRACE_LOGFILE_HEADER;
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
			public uint LogFileMode;
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
			public IntPtr LoggerName;
			/// <summary>
			/// Do Not use.
			/// <para>
			/// The name of the event tracing log file is the second null-terminated string following this structure in memory.The first
			/// string is the name of the session.
			/// </para>
			/// </summary>
			public IntPtr LogFileName;
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

		/// <summary>The EVENT_TRACE_HEADER structure contains standard event tracing information common to all events.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_TRACE_HEADER
		{
			/// <summary>
			/// Total number of bytes of the event. Size includes the size of the header structure, plus the size of any event-specific data
			/// appended to the header.
			/// <para>On input, the size must be less than the size of the event tracing session's buffer minus 72 (0x48).</para>
			/// <para>On output, do not use this number in calculations.</para>
			/// </summary>
			public ushort Size;

			/// <summary>Reserved.</summary>
			public ushort FieldTypeFlags;

			/// <summary>Type of event.</summary>
			public byte Type;
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
			public byte Level;

			/// <summary>
			/// Indicates the version of the event trace class that you are using to log the event. Specify zero if there is only one version
			/// of your event trace class. The version tells the consumer which MOF class to use to decipher the event data.
			/// </summary>
			public ushort Version;

			/// <summary>
			/// On output, identifies the thread that generated the event.
			/// <para>Note that on Windows 2000, ThreadId was a ULONGLONG value.</para>
			/// </summary>
			public uint ThreadId;

			/// <summary>
			/// On output, identifies the process that generated the event.
			/// <para>Note that on Windows 2000, ProcessId was a ULONGLONG value.</para>
			/// </summary>
			public uint ProcessId;

			/// <summary>
			/// On output, contains the time that the event occurred. The resolution is system time unless the ProcessTraceMode member of
			/// EVENT_TRACE_LOGFILE contains the PROCESS_TRACE_MODE_RAW_TIMESTAMP flag, in which case the resolution depends on the value of
			/// the Wnode.ClientContext member of EVENT_TRACE_PROPERTIES at the time the controller created the session.
			/// </summary>
			public long TimeStamp;

			/// <summary>
			/// Event trace class GUID. You can use the class GUID to identify a category of events and the Class.Type member to identify an
			/// event within the category of events.
			/// <para>Alternatively, you can use the GuidPtr member to specify the class GUID.</para>
			/// <para>Windows XP and Windows 2000: The class GUID must have been registered previously using the RegisterTraceGuids function.</para>
			/// </summary>
			public Guid Guid;

			/// <summary>
			/// Elapsed execution time for kernel-mode instructions, in CPU time units. If you are using a private session, use the value in
			/// the ProcessorTime member instead. For more information, see Remarks.
			/// </summary>
			public uint KernelTime;

			/// <summary>
			/// Elapsed execution time for user-mode instructions, in CPU time units. If you are using a private session, use the value in
			/// the ProcessorTime member instead. For more information, see Remarks.
			/// </summary>
			public uint UserTime;

			/// <summary>For private sessions, the elapsed execution time for user-mode instructions, in CPU ticks.</summary>
			public ulong ProcessorTime;
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

		/// <summary>The <c>EVENT_INSTANCE_INFO</c> structure maps a unique transaction identifier to a registered event trace class.</summary>
		/// <remarks>Be sure to initialize the memory for this structure to zero before setting any members.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntrace/ns-evntrace-event_instance_info typedef struct EVENT_INSTANCE_INFO {
		// HANDLE RegHandle; ULONG InstanceId; } EVENT_INSTANCE_INFO, *PEVENT_INSTANCE_INFO;
		[PInvokeData("evntrace.h", MSDNShortId = "83a3802c-b992-43a2-a98a-bdee2ecfef24")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_INSTANCE_INFO
		{
			/// <summary>Handle to a registered event trace class.</summary>
			public TRACEHANDLE RegHandle;

			/// <summary>Unique transaction identifier that maps an event to a specific transaction.</summary>
			public uint InstanceId;
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
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_TRACE_PROPERTIES
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
			/// A system logger must set <c>EnableFlags</c> to indicate which SystemTraceProvider events should be included in the trace.
			/// This is also used for NT Kernel Logger sessions. This member can contain one or more of the following values. In addition to
			/// the events you specify, the kernel logger also logs hardware configuration events on Windows XP or system configuration
			/// events on Windows Server 2003.
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
			public IntPtr Guid;
			/// <summary>
			/// <para>Handle to the registered event trace class. The <c>RegisterTraceGuids</c> function generates this value.</para>
			/// <para>
			/// Use this handle when you call the <c>CreateTraceInstanceId</c> function and to set the <c>RegHandle</c> member of
			/// <c>EVENT_INSTANCE_HEADER</c> when calling the <c>TraceEventInstance</c> function.
			/// </para>
			/// </summary>
			public TRACEHANDLE RegHandle;
		}

		/// <summary>Provides a handle to an event trace.</summary>
		[PInvokeData("evntrace.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRACEHANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="TRACEHANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public TRACEHANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="TRACEHANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static TRACEHANDLE NULL => new TRACEHANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="TRACEHANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(TRACEHANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="TRACEHANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator TRACEHANDLE(IntPtr h) => new TRACEHANDLE(h);

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

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
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
			public ulong HistoricalContext;

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
			public uint Flags;
		}
	}
}