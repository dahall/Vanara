namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary>Specifies the types of Provider Traits supported by Event Tracing for Windows (ETW).</summary>
	/// <remarks>Providers are applications that can generate event logs.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ne-evntcons-etw_provider_trait_type
	// typedef enum { EtwProviderTraitTypeGroup, EtwProviderTraitDecodeGuid, EtwProviderTraitTypeMax } ETW_PROVIDER_TRAIT_TYPE;
	[PInvokeData("evntcons.h", MSDNShortId = "NE:evntcons.ETW_PROVIDER_TRAIT_TYPE")]
	public enum ETW_PROVIDER_TRAIT_TYPE
	{
		/// <summary>ETW Provider trait group.</summary>
		EtwProviderTraitTypeGroup = 1,

		/// <summary>ETW Provider trait decode GUID.</summary>
		EtwProviderTraitDecodeGuid,

		/// <summary>ETW Provider trait type maximum.</summary>
		EtwProviderTraitTypeMax,
	}

	/// <summary>
	/// Optional settings that ETW can include when writing the event. Some settings write extra data to the extended data item section of
	/// each event. Other settings control which events will be included in the trace. To use these optional settings, specify one or more of
	/// the following flags. Otherwise, set to zero.
	/// </summary>
	[Flags]
	public enum EVENT_ENABLE_PROPERTY : uint
	{
		/// <summary>
		/// <para>Include the security identifier (SID) of the user in the event's extended data.</para>
		/// <para>Supported on Windows Vista and later.</para>
		/// </summary>
		EVENT_ENABLE_PROPERTY_SID = 0x00000001,

		/// <summary>
		/// <para>Include the terminal session identifier in the event's extended data.</para>
		/// <para>Supported on Windows Vista and later.</para>
		/// </summary>
		EVENT_ENABLE_PROPERTY_TS_ID = 0x00000002,

		/// <summary>
		/// <para>Add a call stack trace to the extended data of events written using EventWrite.</para>
		/// <para>If the stack is longer than the maximum number of frames (192), the frames will be cut from the bottom of the stack.</para>
		/// <para>
		/// For consumers, the events will include the EVENT_EXTENDED_ITEM_STACK_TRACE32 or EVENT_EXTENDED_ITEM_STACK_TRACE64 extended item.
		/// Note that on 64-bit computers, the trace will contain both 64-bit stacks even if the trace was started by a 32-bit trace controller.
		/// </para>
		/// <para>Supported on Windows 7 and later.</para>
		/// </summary>
		EVENT_ENABLE_PROPERTY_STACK_TRACE = 0x00000004,

		/// <summary></summary>
		EVENT_ENABLE_PROPERTY_PSM_KEY = 0x00000008,

		/// <summary>
		/// <para>Filters out events where the event's keyword is .</para>
		/// <para>Supported on Windows 10, version 1507 and later. This is also supported on Windows 8.1 and Windows 7 with SP1 via a patch.</para>
		/// </summary>
		EVENT_ENABLE_PROPERTY_IGNORE_KEYWORD_0 = 0x00000010,

		/// <summary>
		/// <para>Indicates that this call to EnableTraceEx2 should enable a Provider Group rather than an individual Event Provider.</para>
		/// <para>Supported on Windows 10, version 1507 and later. This is also supported on Windows 8.1 and Windows 7 with SP1 via a patch.</para>
		/// </summary>
		EVENT_ENABLE_PROPERTY_PROVIDER_GROUP = 0x00000020,

		/// <summary></summary>
		EVENT_ENABLE_PROPERTY_ENABLE_KEYWORD_0 = 0x00000040,

		/// <summary>
		/// <para>Include the Process Start Key in the extended data.</para>
		/// <para>
		/// The Process Start Key is a sequence number that identifies the process. While the Process ID may be reused within a session, the
		/// Process Start Key is guaranteed to be unique in the current boot session.
		/// </para>
		/// <para>Supported on Windows 10, version 1507 and later. This is also supported on Windows 8.1 and Windows 7 with SP1 via a patch.</para>
		/// </summary>
		EVENT_ENABLE_PROPERTY_PROCESS_START_KEY = 0x00000080,

		/// <summary>
		/// <para>Include the Event Key in the extended data.</para>
		/// <para>
		/// The Event Key is a unique identifier for the event instance that will be constant across multiple trace sessions listening to
		/// this event. It can be used to correlate simultaneous trace sessions.
		/// </para>
		/// <para>Supported on Windows 10, version 1507 and later.</para>
		/// </summary>
		EVENT_ENABLE_PROPERTY_EVENT_KEY = 0x00000100,

		/// <summary>
		/// <para>Filters out all events that are either marked as an InPrivate event or come from a process that is marked as InPrivate.</para>
		/// <para>
		/// InPrivate implies that the event or process contains some data that would be considered private or personal. It is up to the
		/// process or event to designate itself as InPrivate for this to work.
		/// </para>
		/// <para>Supported on Windows 10, version 1507 and later.</para>
		/// </summary>
		EVENT_ENABLE_PROPERTY_EXCLUDE_INPRIVATE = 0x00000200,

		/// <summary/>
		EVENT_ENABLE_PROPERTY_ENABLE_SILOS = 0x00000400,

		/// <summary/>
		EVENT_ENABLE_PROPERTY_SOURCE_CONTAINER_TRACKING = 0x00000800,
	}

	/// <summary>Type of extended data.</summary>
	[PInvokeData("evntcons.h", MSDNShortId = "aa363760")]
	public enum EVENT_HEADER_EXT_TYPE : ushort
	{
		/// <summary>
		/// The DataPtr member points to an EVENT_EXTENDED_ITEM_RELATED_ACTIVITYID structure that contains the related activity identifier if
		/// you called EventWriteTransfer to write the event.
		/// </summary>
		[CorrespondingType(typeof(EVENT_EXTENDED_ITEM_RELATED_ACTIVITYID))]
		EVENT_HEADER_EXT_TYPE_RELATED_ACTIVITYID = 0x0001,

		/// <summary>
		/// The DataPtr member points to a SID structure that contains the security identifier (SID) of the user that logged the event. ETW
		/// includes the SID if you set the EnableProperty parameter of EnableTraceEx to EVENT_ENABLE_PROPERTY_SID.
		/// </summary>
		[CorrespondingType(typeof(SID))]
		EVENT_HEADER_EXT_TYPE_SID = 0x0002,

		/// <summary>
		/// The DataPtr member points to an EVENT_EXTENDED_ITEM_TS_ID structure that contains the terminal session identifier. ETW includes
		/// the terminal session identifier if you set the EnableProperty parameter of EnableTraceEx to EVENT_ENABLE_PROPERTY_TS_ID.
		/// </summary>
		[CorrespondingType(typeof(EVENT_EXTENDED_ITEM_TS_ID))]
		EVENT_HEADER_EXT_TYPE_TS_ID = 0x0003,

		/// <summary>
		/// The DataPtr member points to an EVENT_EXTENDED_ITEM_INSTANCE structure that contains the activity identifier if you called
		/// TraceEventInstance to write the event.
		/// </summary>
		[CorrespondingType(typeof(EVENT_EXTENDED_ITEM_INSTANCE))]
		EVENT_HEADER_EXT_TYPE_INSTANCE_INFO = 0x0004,

		/// <summary>
		/// The DataPtr member points to an EVENT_EXTENDED_ITEM_STACK_TRACE32 structure that contains the call stack if the event is captured
		/// on a 32-bit computer.
		/// </summary>
		[CorrespondingType(typeof(EVENT_EXTENDED_ITEM_STACK_TRACE32))]
		EVENT_HEADER_EXT_TYPE_STACK_TRACE32 = 0x0005,

		/// <summary>
		/// The DataPtr member points to an EVENT_EXTENDED_ITEM_STACK_TRACE64 structure that contains the call stack if the event is captured
		/// on a 64-bit computer.
		/// </summary>
		[CorrespondingType(typeof(EVENT_EXTENDED_ITEM_STACK_TRACE64))]
		EVENT_HEADER_EXT_TYPE_STACK_TRACE64 = 0x0006,

		/// <summary>
		/// </summary>
		EVENT_HEADER_EXT_TYPE_PEBS_INDEX = 0x0007,

		/// <summary>
		/// </summary>
		EVENT_HEADER_EXT_TYPE_PMC_COUNTERS = 0x0008,

		/// <summary>
		/// </summary>
		EVENT_HEADER_EXT_TYPE_PSM_KEY = 0x0009,

		/// <summary>
		/// The DataPtr member points to an EVENT_EXTENDED_ITEM_EVENT_KEY structure that contains a unique event identifier which is a 64-bit
		/// scalar. The EnablePropertyEVENT_ENABLE_PROPERTY_EVENT_KEY needs to be passed in for the EnableTrace call for a given provider to
		/// enable this feature.
		/// </summary>
		[CorrespondingType(typeof(EVENT_EXTENDED_ITEM_EVENT_KEY))]
		EVENT_HEADER_EXT_TYPE_EVENT_KEY = 0x000A,

		/// <summary>The DataPtr member points to an extended header item that contains TraceLogging event metadata information.</summary>
		EVENT_HEADER_EXT_TYPE_EVENT_SCHEMA_TL = 0x000B,

		/// <summary>
		/// The DataPtr member points to an extended header item that contains provider traits data, for example traits set through
		/// EventSetInformation(EventProviderSetTraits) or specified through EVENT_DATA_DESCRIPTOR_TYPE_PROVIDER_METADATA.
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		EVENT_HEADER_EXT_TYPE_PROV_TRAITS = 0x000C,

		/// <summary>
		/// The DataPtr member points to an EVENT_EXTENDED_ITEM_PROCESS_START_KEY structure that contains a unique process identifier (unique
		/// across the boot session). This identifier is a 64-bit scalar. The EnablePropertyEVENT_ENABLE_PROPERTY_PROCESS_START_KEY needs to
		/// be passed in for the EnableTrace call for a given provider to enable this feature.
		/// </summary>
		[CorrespondingType(typeof(EVENT_EXTENDED_ITEM_PROCESS_START_KEY))]
		EVENT_HEADER_EXT_TYPE_PROCESS_START_KEY = 0x000D,

		/// <summary>
		/// </summary>
		EVENT_HEADER_EXT_TYPE_CONTROL_GUID = 0x000E,

		/// <summary>
		/// </summary>
		EVENT_HEADER_EXT_TYPE_QPC_DELTA = 0x000F,

		/// <summary>
		/// </summary>
		EVENT_HEADER_EXT_TYPE_CONTAINER_ID = 0x0010,

		/// <summary>
		/// </summary>
		EVENT_HEADER_EXT_TYPE_STACK_KEY32 = 0x0011,

		/// <summary>
		/// </summary>
		EVENT_HEADER_EXT_TYPE_STACK_KEY64 = 0x0012,
	}

	/// <summary>
	/// Flags that provide information about the event such as the type of session it was logged to and if the event contains extended data.
	/// </summary>
	[PInvokeData("evntcons.h", MSDNShortId = "NS:evntcons._EVENT_HEADER")]
	[Flags]
	public enum EVENT_HEADER_FLAG : ushort
	{
		/// <summary>The <c>ExtendedData</c> member of EVENT_RECORD contains data.</summary>
		EVENT_HEADER_FLAG_EXTENDED_INFO = 0x0001,

		/// <summary>The event was logged to a private session. Use <c>ProcessorTime</c> for elapsed execution time.</summary>
		EVENT_HEADER_FLAG_PRIVATE_SESSION = 0x0002,

		/// <summary>
		/// The event data is a null-terminated Unicode string. You do not need a manifest to parse the <c>UserData</c> member of EVENT_RECORD.
		/// </summary>
		EVENT_HEADER_FLAG_STRING_ONLY = 0x0004,

		/// <summary>
		/// The provider used TraceMessage or TraceMessageVa to log the event. Most providers do not use these functions to write events, so
		/// this flag typically indicates that the event was written by Windows Software Trace Preprocessor (WPP).
		/// </summary>
		EVENT_HEADER_FLAG_TRACE_MESSAGE = 0x0008,

		/// <summary>Use <c>ProcessorTime</c> for elapsed execution time.</summary>
		EVENT_HEADER_FLAG_NO_CPUTIME = 0x0010,

		/// <summary>Indicates that the provider was running on a 32-bit computer or in a WOW64 session.</summary>
		EVENT_HEADER_FLAG_32_BIT_HEADER = 0x0020,

		/// <summary>Indicates that the provider was running on a 64-bit computer.</summary>
		EVENT_HEADER_FLAG_64_BIT_HEADER = 0x0040,

		/// <summary/>
		EVENT_HEADER_FLAG_DECODE_GUID = 0x0080,

		/// <summary>Indicates that provider used TraceEvent to log the event.</summary>
		EVENT_HEADER_FLAG_CLASSIC_HEADER = 0x0100,

		/// <summary/>
		EVENT_HEADER_FLAG_PROCESSOR_INDEX = 0x0200,
	}

	/// <summary>Indicates the source to use for parsing the event data.</summary>
	[PInvokeData("evntcons.h", MSDNShortId = "NS:evntcons._EVENT_HEADER")]
	[Flags]
	public enum EVENT_HEADER_PROPERTY : ushort
	{
		/// <summary>Indicates that you need a manifest to parse the event data.</summary>
		EVENT_HEADER_PROPERTY_XML = 0x0001,

		/// <summary>
		/// Indicates that the event data contains within itself a fully-rendered XML description of the data, so you do not need a manifest
		/// to parse the event data.
		/// </summary>
		EVENT_HEADER_PROPERTY_FORWARDED_XML = 0x0002,

		/// <summary>Indicates that you need a WMI MOF class to parse the event data.</summary>
		EVENT_HEADER_PROPERTY_LEGACY_EVENTLOG = 0x0004,

		/// <summary/>
		EVENT_HEADER_PROPERTY_RELOGGABLE = 0x0008,
	}

	/// <summary>Defines what component of the security descriptor that the EventAccessControl function modifies.</summary>
	/// <remarks>For information on DACLs and SACLs, see Access Control Lists.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/evntcons/ne-evntcons-eventsecurityoperation typedef enum { EventSecuritySetDACL,
	// EventSecuritySetSACL, EventSecurityAddDACL, EventSecurityAddSACL, EventSecurityMax } ;
	[PInvokeData("evntcons.h", MSDNShortId = "81f6cf07-2705-4075-b085-d5aebba17121")]
	public enum EVENTSECURITYOPERATION
	{
		/// <summary>
		/// Clears the current discretionary access control list (DACL) and adds an ACE to the DACL. The Sid, Rights, and AllowOrDeny
		/// parameters of the EventAccessControl function determine the contents of the ACE (who has access to the provider or session and
		/// the type of access). To add a new ACE to the DACL without clearing the existing DACL, specify EventSecurityAddDACL.
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
		/// Adds an ACE to the current SACL. The Sid and Rights parameters of the EventAccessControl function determine the contents of the
		/// ACE (who generates an audit record when attempting the specified access).
		/// </summary>
		EventSecurityAddSACL,
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
		/// converted to system time (leaves the time stamp value in the resolution that the controller specified in the Wnode.ClientContext
		/// member of EVENT_TRACE_PROPERTIES). Prior to Windows Vista: Not supported.
		/// </summary>
		PROCESS_TRACE_MODE_RAW_TIMESTAMP = 0x00001000,

		/// <summary>
		/// Specify this mode if you want to receive events in the new EVENT_RECORD format. To receive events in the new format you must
		/// specify a callback in the EventRecordCallback member. If you do not specify this mode, you receive events in the old format
		/// through the callback specified in the EventCallback member. Prior to Windows Vista: Not supported.
		/// </summary>
		PROCESS_TRACE_MODE_EVENT_RECORD = 0x10000000,
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

	/// <summary>Retrieves an individual trait from the ETW provider.</summary>
	/// <param name="ProviderTraits">The Provider traits.</param>
	/// <param name="TraitType">The ETW_PROVIDER_TRAIT_TYPE.</param>
	/// <param name="Trait">The Provider trait.</param>
	/// <param name="Size">The trait size.</param>
	/// <returns>Returns ERROR_SUCCESS if successful.</returns>
	/// <remarks>Providers are applications that can generate event logs.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/nf-evntcons-etwgettraitfromprovidertraits
	// EVNTCONS_INLINE VOID EtwGetTraitFromProviderTraits( [in] PVOID ProviderTraits, [in] UCHAR TraitType, [out] PVOID *Trait, [out] PUSHORT Size );
	[PInvokeData("evntcons.h", MSDNShortId = "NF:evntcons.EtwGetTraitFromProviderTraits")]
	public static void EtwGetTraitFromProviderTraits([In] IntPtr ProviderTraits, byte TraitType, out IntPtr Trait, out ushort Size)
	{
		unsafe
		{
			ushort ByteCount = *(ushort*)ProviderTraits;
			byte* Ptr = (byte*)ProviderTraits;
			byte* PtrEnd = Ptr + ByteCount;

			Trait = default;
			Size = 0;

			// Abort on invalid size.
			if (ByteCount < 3)
				return;

			// Skip byte counts
			Ptr += 2;

			// Skip the Provider Name, including the Null termination
			for (ByteCount -= 3; *Ptr != 0 && ByteCount > 0; Ptr++, ByteCount--) ;
			Ptr += 1;

			// Loop through the rest of the traits until one of the
			// desired type is located.
			while (Ptr < PtrEnd)
			{
				ushort TraitByteCount = *(ushort*)Ptr;

				// Abort on invalid trait size.
				if (TraitByteCount < 3)
					return;

				if ((Ptr[2] == TraitType) && (Ptr + TraitByteCount <= PtrEnd))
				{
					Trait = (IntPtr)(Ptr + 3);
					Size = (ushort)(TraitByteCount - 3);
					return;
				}

				Ptr += TraitByteCount;
			}
		}
		return;
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
	/// By default, only the administrator of the computer, users in the Performance Log Users group, and services running as LocalSystem,
	/// LocalService, NetworkService can control trace sessions and provide and consume event data. Only users with administrative privileges
	/// and services running as LocalSystem can start and control an NT Kernel Logger session.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003:</c> Only users with administrator privileges can control trace sessions and consume event data; any user can
	/// provide event data.
	/// </para>
	/// <para><c>Windows XP and Windows 2000:</c> Any user can control trace sessions and provide and consume event data.</para>
	/// <para>
	/// Users with administrator privileges can control trace sessions if the tool that they use to control the session is started from a
	/// Command Prompt window that is opened with <c>Run as administrator...</c>.
	/// </para>
	/// <para>
	/// To grant a restricted user the ability to control trace sessions, you can add them to the Performance Log Users group or call this
	/// function to grant them permission. For example, you can grant user A permission to start and stop a trace session and grant user B
	/// permission to only query the session.
	/// </para>
	/// <para>To restrict who can log events to the session, see the TRACELOG_LOG_EVENT permission.</para>
	/// <para>
	/// The ACL on the log file determines who can consume event data from the log file. To consume events from a session in real-time, you
	/// must grant the user TRACELOG_ACCESS_REALTIME permission or the user must be a member of the Performance Log Users group.
	/// </para>
	/// <para>You can also specify the provider's GUID to restrict who can register the provider and who can enable the provider.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/evntcons/nf-evntcons-eventaccesscontrol ULONG EVNTAPI EventAccessControl( LPGUID
	// Guid, ULONG Operation, PSID Sid, ULONG Rights, BOOLEAN AllowOrDeny );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("evntcons.h", MSDNShortId = "699bb165-680f-4d3b-8859-959f319ca4be")]
	public static extern Win32Error EventAccessControl(in Guid Guid, EVENTSECURITYOPERATION Operation, PSID Sid, TRACELOG_RIGHTS Rights, [MarshalAs(UnmanagedType.U1)] bool AllowOrDeny);

	/// <summary>Retrieves the permissions for the specified controller or provider.</summary>
	/// <param name="Guid">GUID that uniquely identifies the provider or session.</param>
	/// <param name="Buffer">Application-allocated buffer that will contain the security descriptor of the controller or provider.</param>
	/// <param name="BufferSize">
	/// Size of the security descriptor buffer, in bytes. If the function succeeds, this parameter receives the size of the buffer used. If
	/// the buffer is too small, the function returns ERROR_MORE_DATA and this parameter receives the required buffer size. If the buffer
	/// size is zero on input, no data is returned in the buffer and this parameter receives the required buffer size.
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
	/// After removing the permission from the registry, the default permissions apply to the provider or session. For details on the default
	/// permissions, see EventAccessControl.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/evntcons/nf-evntcons-eventaccessremove ULONG EVNTAPI EventAccessRemove( LPGUID
	// Guid );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("evntcons.h", MSDNShortId = "9f25f163-046c-41b0-82f9-0b214b74b87e")]
	public static extern Win32Error EventAccessRemove(in Guid Guid);

	/// <summary>Retrieves the Event Processor index.</summary>
	/// <param name="EventRecord">The event record.</param>
	/// <returns>Returns ERROR_SUCCESS if successful.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/nf-evntcons-geteventprocessorindex EVNTCONS_INLINE ULONG
	// GetEventProcessorIndex( PCEVENT_RECORD EventRecord );
	[PInvokeData("evntcons.h", MSDNShortId = "NF:evntcons.GetEventProcessorIndex")]
	public static uint GetEventProcessorIndex(in EVENT_RECORD EventRecord) => (EventRecord.EventHeader.Flags & EVENT_HEADER_FLAG.EVENT_HEADER_FLAG_PROCESSOR_INDEX) != 0
			? EventRecord.BufferContext.ProcessorIndex
			: EventRecord.BufferContext.ProcessorNumber;

	/// <summary>Defines a unique event identifier.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_event_key typedef struct
	// _EVENT_EXTENDED_ITEM_EVENT_KEY { ULONG64 Key; } EVENT_EXTENDED_ITEM_EVENT_KEY, *PEVENT_EXTENDED_ITEM_EVENT_KEY;
	[PInvokeData("evntcons.h", MSDNShortId = "NS:evntcons._EVENT_EXTENDED_ITEM_EVENT_KEY")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct EVENT_EXTENDED_ITEM_EVENT_KEY
	{
		/// <summary>The event key.</summary>
		public ulong Key;
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

		/// <summary>A GUID that uniquely identifies the provider that logged the event referenced by the <c>ParentInstanceId</c> member.</summary>
		public Guid ParentGuid;
	}

	/// <summary>Defines a Processor Event Based Sampling (PEBS) index.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_pebs_index typedef struct
	// _EVENT_EXTENDED_ITEM_PEBS_INDEX { ULONG64 PebsIndex; } EVENT_EXTENDED_ITEM_PEBS_INDEX, *PEVENT_EXTENDED_ITEM_PEBS_INDEX;
	[PInvokeData("evntcons.h", MSDNShortId = "NS:evntcons._EVENT_EXTENDED_ITEM_PEBS_INDEX")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct EVENT_EXTENDED_ITEM_PEBS_INDEX
	{
		/// <summary>The PEBS index.</summary>
		public ulong PebsIndex;
	}

	/// <summary>Defines an extended item Performance Monitoring Unit (PMC) counter.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_pmc_counters typedef struct
	// _EVENT_EXTENDED_ITEM_PMC_COUNTERS { ULONG64 Counter[ANYSIZE_ARRAY]; } EVENT_EXTENDED_ITEM_PMC_COUNTERS, *PEVENT_EXTENDED_ITEM_PMC_COUNTERS;
	[PInvokeData("evntcons.h", MSDNShortId = "NS:evntcons._EVENT_EXTENDED_ITEM_PMC_COUNTERS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct EVENT_EXTENDED_ITEM_PMC_COUNTERS
	{
		/// <summary>The counter.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public ulong[] Counter;
	}

	/// <summary>Defines a trace flag to get a process start key of a process logging the event.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_process_start_key typedef struct
	// _EVENT_EXTENDED_ITEM_PROCESS_START_KEY { ULONG64 ProcessStartKey; } EVENT_EXTENDED_ITEM_PROCESS_START_KEY, *PEVENT_EXTENDED_ITEM_PROCESS_START_KEY;
	[PInvokeData("evntcons.h", MSDNShortId = "NS:evntcons._EVENT_EXTENDED_ITEM_PROCESS_START_KEY")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct EVENT_EXTENDED_ITEM_PROCESS_START_KEY
	{
		/// <summary>The trace flag.</summary>
		public ulong ProcessStartKey;
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

	/// <summary>Defines an extended item stack key on a 32-bit computer.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_stack_key32 typedef struct
	// _EVENT_EXTENDED_ITEM_STACK_KEY32 { ULONG64 MatchId; ULONG StackKey; ULONG Padding; } EVENT_EXTENDED_ITEM_STACK_KEY32, *PEVENT_EXTENDED_ITEM_STACK_KEY32;
	[PInvokeData("evntcons.h", MSDNShortId = "NS:evntcons._EVENT_EXTENDED_ITEM_STACK_KEY32")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct EVENT_EXTENDED_ITEM_STACK_KEY32
	{
		/// <summary>
		/// <para>
		/// A unique identifier that you use to match the kernel-mode calls to the user-mode calls; the kernel-mode calls and user-mode calls
		/// are captured in separate events if the environment prevents both from being captured in the same event. If the kernel-mode and
		/// user-mode calls were captured in the same event, the value is zero.
		/// </para>
		/// <para>
		/// Typically, on 32-bit computers, you can always capture both the kernel-mode and user-mode calls in the same event. However, if
		/// you use the frame pointer optimization compiler option, the stack may not be captured, captured incorrectly, or truncated.
		/// </para>
		/// </summary>
		public ulong MatchId;

		/// <summary>The key.</summary>
		public uint StackKey;

		/// <summary>The key padding.</summary>
		public uint Padding;
	}

	/// <summary>Defines an extended item stack key on a 64-bit computer.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_extended_item_stack_key64 typedef struct
	// _EVENT_EXTENDED_ITEM_STACK_KEY64 { ULONG64 MatchId; ULONG64 StackKey; } EVENT_EXTENDED_ITEM_STACK_KEY64, *PEVENT_EXTENDED_ITEM_STACK_KEY64;
	[PInvokeData("evntcons.h", MSDNShortId = "NS:evntcons._EVENT_EXTENDED_ITEM_STACK_KEY64")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct EVENT_EXTENDED_ITEM_STACK_KEY64
	{
		/// <summary>
		/// A unique identifier that you use to match the kernel-mode calls to the user-mode calls; the kernel-mode calls and user-mode calls
		/// are captured in separate events if the environment prevents both from being captured in the same event. If the kernel-mode and
		/// user-mode calls were captured in the same event, the value is zero.
		/// </summary>
		public ulong MatchId;

		/// <summary>The key.</summary>
		public ulong StackKey;
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
		/// A unique identifier that you use to match the kernel-mode calls to the user-mode calls; the kernel-mode calls and user-mode calls
		/// are captured in separate events if the environment prevents both from being captured in the same event. If the kernel-mode and
		/// user-mode calls were captured in the same event, the value is zero.
		/// </para>
		/// <para>
		/// Typically, on 32-bit computers, you can always capture both the kernel-mode and user-mode calls in the same event. However, if
		/// you use the frame pointer optimization compiler option, the stack may not be captured, captured incorrectly, or truncated.
		/// </para>
		/// </summary>
		public ulong MatchId;

		internal readonly uint _Address;

		/// <summary>An array of call addresses on the stack.</summary>
		public static unsafe uint[] GetAddresses(EVENT_HEADER_EXTENDED_DATA_ITEM* parent)
		{
			var sz = (parent->DataSize - sizeof(ulong)) / sizeof(uint);
			uint[] ret = new uint[sz];
			uint* src = (uint*)new IntPtr((long)parent->DataPtr + Marshal.OffsetOf(typeof(EVENT_EXTENDED_ITEM_STACK_TRACE32), nameof(_Address)).ToInt64()).ToPointer();
			for (int i = 0; i < sz; i++)
				ret[i] = src[i];
			return ret;
		}
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
		/// A unique identifier that you use to match the kernel-mode calls to the user-mode calls; the kernel-mode calls and user-mode calls
		/// are captured in separate events if the environment prevents both from being captured in the same event. If the kernel-mode and
		/// user-mode calls were captured in the same event, the value is zero.
		/// </summary>
		public ulong MatchId;

		internal readonly ulong _Address;

		/// <summary>An array of call addresses on the stack.</summary>
		public static unsafe ulong[] GetAddresses(EVENT_HEADER_EXTENDED_DATA_ITEM* parent)
		{
			var sz = (parent->DataSize - sizeof(ulong)) / sizeof(uint);
			ulong[] ret = new ulong[sz];
			ulong* src = (ulong*)new IntPtr((long)parent->DataPtr + Marshal.OffsetOf(typeof(EVENT_EXTENDED_ITEM_STACK_TRACE32), nameof(_Address)).ToInt64()).ToPointer();
			for (int i = 0; i < sz; i++)
				ret[i] = src[i];
			return ret;
		}
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

	/// <summary>Defines information about the event.</summary>
	/// <remarks>
	/// <para>
	/// You can use the <c>KernelTime</c> and <c>UserTime</c> members to determine the CPU cost in units for a set of instructions (the
	/// values indicate the CPU usage charged to that thread at the time of logging). For example, if Event A and Event B are consecutively
	/// logged by the same thread and they have CPU usage numbers 150 and 175, then the activity that was performed by that thread between
	/// events A and B cost 25 CPU time units (175 – 150).
	/// </para>
	/// <para>
	/// The <c>TimerResolution</c> of the TRACE_LOGFILE_HEADER structure contains the resolution of the CPU usage timer in 100-nanosecond
	/// units. You can use the timer resolution with the kernel time and user time values to determine the amount of CPU time that the set of
	/// instructions used. For example, if the timer resolution is 156,250, then 25 CPU time units is 0.39 seconds (156,250 * 25 * 100 /
	/// 1,000,000,000). This is the amount of CPU time (not elapsed wall clock time) used by the set of instructions between events A and B.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_header typedef struct _EVENT_HEADER { USHORT Size;
	// USHORT HeaderType; USHORT Flags; USHORT EventProperty; ULONG ThreadId; ULONG ProcessId; LARGE_INTEGER TimeStamp; GUID ProviderId;
	// EVENT_DESCRIPTOR EventDescriptor; union { struct { ULONG KernelTime; ULONG UserTime; } DUMMYSTRUCTNAME; ULONG64 ProcessorTime; }
	// DUMMYUNIONNAME; GUID ActivityId; } EVENT_HEADER, *PEVENT_HEADER;
	[PInvokeData("evntcons.h", MSDNShortId = "NS:evntcons._EVENT_HEADER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct EVENT_HEADER
	{
		/// <summary>Size of the event record, in bytes.</summary>
		public ushort Size;

		/// <summary>Reserved.</summary>
		public ushort HeaderType;

		/// <summary>
		/// <para>
		/// Flags that provide information about the event such as the type of session it was logged to and if the event contains extended
		/// data. This member can contain one or more of the following flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>EVENT_HEADER_FLAG_EXTENDED_INFO</c></term>
		/// <term>The <c>ExtendedData</c> member of EVENT_RECORD contains data.</term>
		/// </item>
		/// <item>
		/// <term><c>EVENT_HEADER_FLAG_PRIVATE_SESSION</c></term>
		/// <term>The event was logged to a private session. Use <c>ProcessorTime</c> for elapsed execution time.</term>
		/// </item>
		/// <item>
		/// <term><c>EVENT_HEADER_FLAG_STRING_ONLY</c></term>
		/// <term>The event data is a null-terminated Unicode string. You do not need a manifest to parse the <c>UserData</c> member of EVENT_RECORD.</term>
		/// </item>
		/// <item>
		/// <term><c>EVENT_HEADER_FLAG_TRACE_MESSAGE</c></term>
		/// <term>
		/// The provider used TraceMessage or TraceMessageVa to log the event. Most providers do not use these functions to write events, so
		/// this flag typically indicates that the event was written by Windows Software Trace Preprocessor (WPP).
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>EVENT_HEADER_FLAG_NO_CPUTIME</c></term>
		/// <term>Use <c>ProcessorTime</c> for elapsed execution time.</term>
		/// </item>
		/// <item>
		/// <term><c>EVENT_HEADER_FLAG_32_BIT_HEADER</c></term>
		/// <term>Indicates that the provider was running on a 32-bit computer or in a WOW64 session.</term>
		/// </item>
		/// <item>
		/// <term><c>EVENT_HEADER_FLAG_64_BIT_HEADER</c></term>
		/// <term>Indicates that the provider was running on a 64-bit computer.</term>
		/// </item>
		/// <item>
		/// <term><c>EVENT_HEADER_FLAG_CLASSIC_HEADER</c></term>
		/// <term>Indicates that provider used TraceEvent to log the event.</term>
		/// </item>
		/// </list>
		/// </summary>
		public EVENT_HEADER_FLAG Flags;

		/// <summary>
		/// <para>Indicates the source to use for parsing the event data.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>EVENT_HEADER_PROPERTY_XML</c></term>
		/// <term>Indicates that you need a manifest to parse the event data.</term>
		/// </item>
		/// <item>
		/// <term><c>EVENT_HEADER_PROPERTY_FORWARDED_XML</c></term>
		/// <term>
		/// Indicates that the event data contains within itself a fully-rendered XML description of the data, so you do not need a manifest
		/// to parse the event data.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>EVENT_HEADER_PROPERTY_LEGACY_EVENTLOG</c></term>
		/// <term>Indicates that you need a WMI MOF class to parse the event data.</term>
		/// </item>
		/// </list>
		/// </summary>
		public EVENT_HEADER_PROPERTY EventProperty;

		/// <summary>Identifies the thread that generated the event.</summary>
		public uint ThreadId;

		/// <summary>Identifies the process that generated the event.</summary>
		public uint ProcessId;

		/// <summary>
		/// Contains the time that the event occurred. The resolution is system time unless the <c>ProcessTraceMode</c> member of
		/// EVENT_TRACE_LOGFILE contains the PROCESS_TRACE_MODE_RAW_TIMESTAMP flag, in which case the resolution depends on the value of the
		/// <c>Wnode.ClientContext</c> member of EVENT_TRACE_PROPERTIES at the time the controller created the session.
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
			/// Elapsed execution time for kernel-mode instructions, in CPU ticks. If you are using a private session, use the value in the
			/// ProcessorTime member instead.
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
		/// The DataPtr member points to an EVENT_EXTENDED_ITEM_RELATED_ACTIVITYID structure that contains the related activity identifier if
		/// you called EventWriteTransfer to write the event.
		/// </term>
		/// </item>
		/// <item>
		/// <term>EVENT_HEADER_EXT_TYPE_SID</term>
		/// <term>
		/// The DataPtr member points to a SID structure that contains the security identifier (SID) of the user that logged the event. ETW
		/// includes the SID if you set the EnableProperty parameter of EnableTraceEx to EVENT_ENABLE_PROPERTY_SID.
		/// </term>
		/// </item>
		/// <item>
		/// <term>EVENT_HEADER_EXT_TYPE_TS_ID</term>
		/// <term>
		/// The DataPtr member points to an EVENT_EXTENDED_ITEM_TS_ID structure that contains the terminal session identifier. ETW includes
		/// the terminal session identifier if you set the EnableProperty parameter of EnableTraceEx to EVENT_ENABLE_PROPERTY_TS_ID.
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
		/// The DataPtr member points to an EVENT_EXTENDED_ITEM_STACK_TRACE32 structure that contains the call stack if the event is captured
		/// on a 32-bit computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>EVENT_HEADER_EXT_TYPE_STACK_TRACE64</term>
		/// <term>
		/// The DataPtr member points to an EVENT_EXTENDED_ITEM_STACK_TRACE64 structure that contains the call stack if the event is captured
		/// on a 64-bit computer.
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
		/// The DataPtr member points to an EVENT_EXTENDED_ITEM_EVENT_KEY structure that contains a unique event identifier which is a 64-bit
		/// scalar. The EnablePropertyEVENT_ENABLE_PROPERTY_EVENT_KEY needs to be passed in for the EnableTrace call for a given provider to
		/// enable this feature.
		/// </term>
		/// </item>
		/// <item>
		/// <term>EVENT_HEADER_EXT_TYPE_PROCESS_START_KEY</term>
		/// <term>
		/// The DataPtr member points to an EVENT_EXTENDED_ITEM_PROCESS_START_KEY structure that contains a unique process identifier (unique
		/// across the boot session). This identifier is a 64-bit scalar. The EnablePropertyEVENT_ENABLE_PROPERTY_PROCESS_START_KEY needs to
		/// be passed in for the EnableTrace call for a given provider to enable this feature.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public EVENT_HEADER_EXT_TYPE ExtType;

		/// <summary>Reserved.</summary>
		public ushort Linkage;

		/// <summary>Size, in bytes, of the extended data that <c>DataPtr</c> points to.</summary>
		public ushort DataSize;

		/// <summary>
		/// Pointer to the extended data. The <c>ExtType</c> member determines the type of extended data to which this member points.
		/// </summary>
		public ulong DataPtr;
	}

	/// <summary>The <c>EVENT_RECORD</c> structure defines the layout of an event that ETW delivers.</summary>
	/// <remarks>The <c>EVENT_RECORD</c> structure is passed to the consumer's implementation of the EventRecordCallback callback .</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/evntcons/ns-evntcons-_event_record typedef struct _EVENT_RECORD { EVENT_HEADER
	// EventHeader; ETW_BUFFER_CONTEXT BufferContext; USHORT ExtendedDataCount; USHORT UserDataLength; PEVENT_HEADER_EXTENDED_DATA_ITEM
	// ExtendedData; PVOID UserData; PVOID UserContext; } EVENT_RECORD, *PEVENT_RECORD;
	[PInvokeData("evntcons.h", MSDNShortId = "e352c1a7-39a2-43e3-a723-5fc6a3921ee8")]
	[StructLayout(LayoutKind.Sequential)]
	public struct EVENT_RECORD
	{
		/// <summary>Information about the event such as the time stamp for when it was written. For details, see the EVENT_HEADER structure.</summary>
		public EVENT_HEADER EventHeader;

		/// <summary>Defines information such as the session that logged the event. For details, see the ETW_BUFFER_CONTEXT structure.</summary>
		public ETW_BUFFER_CONTEXT BufferContext;

		/// <summary>The number of extended data structures in the <c>ExtendedData</c> member.</summary>
		public ushort ExtendedDataCount;

		/// <summary>The size, in bytes, of the data in the <c>UserData</c> member.</summary>
		public ushort UserDataLength;

		/// <summary>
		/// One or more extended data items that ETW collects. The extended data includes some items, such as the security identifier (SID)
		/// of the user that logged the event, only if the controller sets the EnableProperty parameter passed to the EnableTraceEx or
		/// EnableTraceEx2 function. The extended data includes other items, such as the related activity identifier and decoding information
		/// for trace logging, regardless whether the controller sets the EnableProperty parameter passed to <c>EnableTraceEx</c> or
		/// <c>EnableTraceEx2</c>. For details, see the EVENT_HEADER_EXTENDED_DATA_ITEM structure .
		/// </summary>
		public IntPtr /*PEVENT_HEADER_EXTENDED_DATA_ITEM*/ ExtendedData;

		/// <summary>
		/// Event specific data. To parse this data, see Retrieving Event Data Using TDH. If the <c>Flags</c> member of EVENT_HEADER contains
		/// <c>EVENT_HEADER_FLAG_STRING_ONLY</c>, the data is a null-terminated Unicode string that you do not need TDH to parse.
		/// </summary>
		public IntPtr UserData;

		/// <summary>
		/// Th context specified in the <c>Context</c> member of the EVENT_TRACE_LOGFILE structure that is passed to the OpenTrace function.
		/// </summary>
		public IntPtr UserContext;
	}

	/// <summary>
	/// <para>
	/// The <c>EVENT_TRACE_LOGFILE</c> structure specifies how the consumer wants to read events (from a log file or in real-time) and the
	/// callbacks that will receive the events.
	/// </para>
	/// <para>When ETW flushes a buffer, this structure contains information about the event tracing session and the buffer that ETW flushed.</para>
	/// </summary>
	/// <remarks>
	/// <para>Be sure to initialize the memory for this structure to zero before setting any members.</para>
	/// <para>Consumers pass this structure to the <c>OpenTrace</c> function.</para>
	/// <para>When ETW flushes a buffer, it passes the structure to the consumer's <c>BufferCallback</c> function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/etw/event-trace-logfile typedef struct _EVENT_TRACE_LOGFILE { StrPtrAuto LogFileName;
	// StrPtrAuto LoggerName; LONGLONG CurrentTime; ULONG BuffersRead; union { ULONG LogFileMode; ULONG ProcessTraceMode; }; EVENT_TRACE
	// CurrentEvent; TRACE_LOGFILE_HEADER LogfileHeader; PEVENT_TRACE_BUFFER_CALLBACK BufferCallback; ULONG BufferSize; ULONG Filled; ULONG
	// EventsLost; union { PEVENT_CALLBACK EventCallback; PEVENT_RECORD_CALLBACK EventRecordCallback; }; ULONG IsKernelTrace; PVOID Context;
	// } EVENT_TRACE_LOGFILE, *PEVENT_TRACE_LOGFILE;
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
		/// You must know the log file name the controller specified. If the controller logged events to a private session (the controller
		/// set the <c>LogFileMode</c> member of <c>EVENT_TRACE_PROPERTIES</c> to <c>EVENT_TRACE_PRIVATE_LOGGER_MODE</c>), the file name must
		/// include the process identifier that ETW appended to the log file name. For example, if the controller named the log file xyz.etl
		/// and the process identifier is 123, ETW uses xyz.etl_123 as the file name.
		/// </para>
		/// <para>
		/// If the controller set the <c>LogFileMode</c> member of <c>EVENT_TRACE_PROPERTIES</c> to <c>EVENT_TRACE_FILE_MODE_NEWFILE</c>, the
		/// log file name must include the sequential serial number used to create each new log file.
		/// </para>
		/// <para>The user consuming the events must have permissions to read the file.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? LogFileName;

		/// <summary>
		/// <para>
		/// Name of the event tracing session. Specify a value for this member if you want to consume events in real time. This member must
		/// be <c>NULL</c> if <c>LogFileName</c> is specified.
		/// </para>
		/// <para>
		/// You can only consume events in real time if the controller set the <c>LogFileMode</c> member of <c>EVENT_TRACE_PROPERTIES</c> to <c>EVENT_TRACE_REAL_TIME_MODE</c>.
		/// </para>
		/// <para>
		/// Only users with administrative privileges, users in the Performance Log Users group, and applications running as LocalSystem,
		/// LocalService, NetworkService can consume events in real time. To grant a restricted user the ability to consume events in real
		/// time, add them to the Performance Log Users group or call <c>EventAccessControl</c>.
		/// </para>
		/// <para><c>Windows XP and Windows 2000:</c> Anyone can consume real time events.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? LoggerName;

		/// <summary>On output, the current time, in 100-nanosecond intervals since midnight, January 1, 1601.</summary>
		public FILETIME CurrentTime;

		/// <summary>On output, the number of buffers processed.</summary>
		public uint BuffersRead;

		/// <summary>
		/// <para>
		/// Modes for processing events. The modes are defined in the Evntcons.h header file. You can specify one or more of the following modes:
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
		/// converted to system time (leaves the time stamp value in the resolution that the controller specified in the Wnode.ClientContext
		/// member of EVENT_TRACE_PROPERTIES). Prior to Windows Vista: Not supported.
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
		/// On output, a <c>TRACE_LOGFILE_HEADER</c> structure that contains general information about the session and the computer on which
		/// the session ran.
		/// </summary>
		public TRACE_LOGFILE_HEADER LogfileHeader;

		/// <summary>
		/// Pointer to the <c>BufferCallback</c> function that receives buffer-related statistics for each buffer ETW flushes. ETW calls this
		/// callback after it delivers all the events in the buffer. This callback is optional.
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

		/// <summary/>
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
			public EventClassCallback? EventCallback;

			/// <summary>
			/// <para>Pointer to the <c>EventRecordCallback</c> function that ETW calls for each event in the buffer.</para>
			/// <para>
			/// Specify this callback if you are consuming events from a provider that used one of the <c>EventWrite</c> functions to log events.
			/// </para>
			/// <para><c>Prior to Windows Vista:</c> Not supported.</para>
			/// </summary>
			[FieldOffset(0)]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public EventRecordCallback? EventRecordCallback;
		}
	}
}