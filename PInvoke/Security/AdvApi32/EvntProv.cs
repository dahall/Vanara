using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>
		/// <para>Providers implement this function to receive enable or disable notification requests.</para>
		/// <para>
		/// The <c>PENABLECALLBACK</c> type defines a pointer to this callback function. <c>EnableCallback</c> is a placeholder for the
		/// application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="SourceId">
		/// GUID that identifies the session that enabled the provider. The value is GUID_NULL if EnableTraceEx did not specify a source identifier.
		/// </param>
		/// <param name="IsEnabled">
		/// <para>
		/// Indicates if the session is enabling or disabling the provider. A value of zero indicates that the session is disabling the
		/// provider. A value of 1 indicates that the session is enabling the provider. Beginning with Windows 7, this value can be one of
		/// the following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>EVENT_CONTROL_CODE_DISABLE_PROVIDER 0</term>
		/// <term>The session is disabling the provider.</term>
		/// </item>
		/// <item>
		/// <term>EVENT_CONTROL_CODE_ENABLE_PROVIDER 1</term>
		/// <term>The session is enabling the provider.</term>
		/// </item>
		/// <item>
		/// <term>EVENT_CONTROL_CODE_CAPTURE_STATE 2</term>
		/// <term>
		/// The session is requesting that the provider log its state information. The provider determines the state information that it logs.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If you receive a value (for example, EVENT_CONTROL_CODE_CAPTURE_STATE) that you do not support, ignore the value (do not fail).
		/// </para>
		/// </param>
		/// <param name="Level">
		/// <para>
		/// Provider-defined value that specifies the verboseness of the events that the provider writes. The provider must write the event
		/// if this value is less than or equal to the level value that the event defines.
		/// </para>
		/// <para>This value is passed in the Level parameter of the EnableTraceEx function or the EnableLevel parameter of EnableTrace.</para>
		/// </param>
		/// <param name="MatchAnyKeyword">
		/// <para>Bitmask of keywords that the provider uses to determine the category of events that it writes.</para>
		/// <para>This value is passed in the MatchAnyKeyword parameter of the EnableTraceEx function or the EnableFlag parameter of EnableTrace.</para>
		/// </param>
		/// <param name="MatchAllKeyword"/>
		/// <param name="FilterData">
		/// <para>
		/// A list of filter data that one or more sessions passed to the provider. A session can specify only one filter but the list will
		/// contain filters from all sessions that used filter data to enable the provider.
		/// </para>
		/// <para>The filter data is valid only within the callback, so providers should make a local copy of the data.</para>
		/// </param>
		/// <param name="CallbackContext">Context of the callback defined when the provider called EventRegister to register itself.</param>
		/// <returns>This callback function does not return a value.</returns>
		/// <remarks>
		/// <para>
		/// To specify that you want to receive notification when a session enables or disables your provider, set the EnableCallback
		/// parameter when calling the EventRegister function.
		/// </para>
		/// <para>
		/// Classic providers needed to specify and implement a callback because it used the information that was passed to the callback to
		/// determine the types of events to log and the level of verboseness to use when logging the events. However, with manifest-based
		/// providers, the callback is optional and is used for informational purposes; you do not need to specify or implement the callback
		/// when registering the provider unless your provider supports filtering. Providers can now just write events and ETW will determine
		/// if the event is logged to the session. If you want to verify that the event should be written before writing the event, you can
		/// call either the EventEnabled or EventProviderEnabled function.
		/// </para>
		/// <para>
		/// Each time a new session enables the provider or a current session updates the provider, ETW calls the provider's callback
		/// function, if implemented. The level value that ETW passes to the callback is the highest level value specified amongst all the
		/// sessions. For example, if session A enabled the provider for warning (3) events and then session B enabled the provider for
		/// critical (1) events, the level value for the second callback is also 3, not 1.
		/// </para>
		/// <para>
		/// The MatchAnyKeyword value that ETW passes to the callback is a composite value of all MatchAnyKeyword values specified for all
		/// sessions that enabled the provider. The same is true for the MatchAllKeywords value. The SourceId and FilterData values are those
		/// values passed to the EnableTraceEx call.
		/// </para>
		/// <para>
		/// Your callback function must not call anything that may incur LoadLibrary (more specifically, anything that requires a loader lock).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntprov/nc-evntprov-penablecallback PENABLECALLBACK Penablecallback; void
		// Penablecallback( LPCGUID SourceId, ULONG IsEnabled, UCHAR Level, ULONGLONG MatchAnyKeyword, ULONGLONG MatchAllKeyword,
		// PEVENT_FILTER_DESCRIPTOR FilterData, PVOID CallbackContext ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("evntprov.h", MSDNShortId = "f339323e-9da9-495f-aac5-f44969a018eb")]
		public delegate void EnableCallback(in Guid SourceId, [MarshalAs(UnmanagedType.Bool)] bool IsEnabled, byte Level, ulong MatchAnyKeyword, ulong MatchAllKeyword, IntPtr FilterData, IntPtr CallbackContext);

		/// <summary>A control code that specifies if you want to create, query or set the current activity identifier.</summary>
		[PInvokeData("evntprov.h", MSDNShortId = "1c412909-bdff-4181-9750-f3444fda4c8f")]
		public enum EVENT_ACTIVITY_CTRL
		{
			/// <summary>Sets the ActivityId parameter to the current identifier value from thread local storage.</summary>
			EVENT_ACTIVITY_CTRL_GET_ID = 1,

			/// <summary>
			/// Uses the identifier in the ActivityId parameter to set the value of the current identifier in the thread local storage.
			/// </summary>
			EVENT_ACTIVITY_CTRL_SET_ID = 2,

			/// <summary>Creates a new identifier and sets the ActivityId parameter to the value of the new identifier.</summary>
			EVENT_ACTIVITY_CTRL_CREATE_ID = 3,

			/// <summary>
			/// Performs the following:
			/// <list type="bullet">
			/// <item>
			/// <term>Copies the current identifier from thread local storage.</term>
			/// </item>
			/// <item>
			/// <term>Sets the current identifier in thread local storage to the new identifier specified in the ActivityId parameter.</term>
			/// </item>
			/// <item>
			/// <term>Sets the ActivityId parameter to the copy of the previous current identifier.</term>
			/// </item>
			/// </list>
			/// </summary>
			EVENT_ACTIVITY_CTRL_GET_SET_ID = 4,

			/// <summary>
			/// Performs the following:
			/// <list type="bullet">
			/// <item>
			/// <term>Copies the current identifier from thread local storage.</term>
			/// </item>
			/// <item>
			/// <term>Creates a new identifier and sets the current identifier in thread local storage to the new identifier.</term>
			/// </item>
			/// <item>
			/// <term>Sets the ActivityId parameter to the copy of the previous current identifier.</term>
			/// </item>
			/// </list>
			/// </summary>
			EVENT_ACTIVITY_CTRL_CREATE_SET_ID = 5,
		}

		/// <summary>The <c>EVENT_INFO_CLASS</c> enumerated type defines a type of operation to perform on a registration object.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntprov/ne-evntprov-_event_info_class typedef enum _EVENT_INFO_CLASS {
		// EventProviderBinaryTrackInfo, EventProviderSetReserved1, EventProviderSetTraits, EventProviderUseDescriptorType, MaxEventInfo } EVENT_INFO_CLASS;
		[PInvokeData("evntprov.h", MSDNShortId = "76ac2b93-d5df-4504-b36d-1530bbb12ab4")]
		public enum EVENT_INFO_CLASS
		{
			/// <summary>Tracks the full path for the binary (DLL or EXE) from which the ETW registration was made.</summary>
			EventProviderBinaryTrackInfo,

			/// <summary/>
			EventProviderSetReserved1,

			/// <summary>
			/// Sets traits for the provider. Implicitly indicates that the provider correctly initializes the EVENT_DATA_DESCRIPTOR values
			/// passed to EventWrite APIs, so the EVENT_DATA_DESCRIPTOR::Type field will be respected. For more information on the format of
			/// the traits, see Provider Traits.
			/// </summary>
			EventProviderSetTraits,

			/// <summary>
			/// Indicates whether the provider correctly initializes the EVENT_DATA_DESCRIPTOR values passed to EventWrite APIs, which in
			/// turn indicates whether the EVENT_DATA_DESCRIPTOR::Type field will be respected by the EventWrite APIs.
			/// </summary>
			EventProviderUseDescriptorType,

			/// <summary>Maximum value for testing purposes.</summary>
			MaxEventInfo,
		}

		/// <summary>Creates, queries, and sets the current activity identifier used by the EventWriteTransfer function.</summary>
		/// <param name="ControlCode">
		/// A control code that specifies if you want to create, query or set the current activity identifier. You can specify one of the
		/// following codes.
		/// </param>
		/// <param name="ActivityId">
		/// A GUID that uniquely identifies the activity. To determine when this parameter is an input parameter, an output parameter or
		/// both, see the descriptions for the ControlCodes parameter.
		/// </param>
		/// <returns>Returns ERROR_SUCCESS if successful.</returns>
		/// <remarks>
		/// The EVENT_ACTIVITY_CTRL_GET_ID control code returns a GUID with all zeros (GUID_NULL) if the identifier has not been set.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntprov/nf-evntprov-eventactivityidcontrol ULONG EVNTAPI
		// EventActivityIdControl( ULONG ControlCode, LPGUID ActivityId );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntprov.h", MSDNShortId = "1c412909-bdff-4181-9750-f3444fda4c8f")]
		public static extern Win32Error EventActivityIdControl(EVENT_ACTIVITY_CTRL ControlCode, in Guid ActivityId);

		/// <summary>Determines if the event is enabled for any session.</summary>
		/// <param name="RegHandle">
		/// <para>Registration handle of the provider. The handle comes from EventRegister.</para>
		/// <para><c>Note</c> A valid registration handle must be used.</para>
		/// </param>
		/// <param name="EventDescriptor">Describes the event. For details, see EVENT_DESCRIPTOR.</param>
		/// <returns>Returns <c>TRUE</c> if the event is enabled for a session; otherwise, <c>FALSE</c>.</returns>
		/// <remarks>
		/// <para>
		/// Typically, providers do not call this function to determine if a session is expecting this event, they simply write the event and
		/// ETW determines if the event is logged to the session.
		/// </para>
		/// <para>
		/// Providers may want to call this function if they need to perform extra work to generate the event. Calling this function first to
		/// determine if a session is expecting this event or not, may save resources and time.
		/// </para>
		/// <para>
		/// The provider would call this function if the provider generated an EVENT_DESCRIPTOR structure for the event from the manifest. If
		/// the event descriptor is not available, call the EventProviderEnabled function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntprov/nf-evntprov-eventenabled BOOLEAN EVNTAPI EventEnabled( REGHANDLE
		// RegHandle, PCEVENT_DESCRIPTOR EventDescriptor );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntprov.h", MSDNShortId = "b332b6d4-6921-40bd-bebc-6646b5b9bcde")]
		[return: MarshalAs(UnmanagedType.U1)]
		public static extern bool EventEnabled(REGHANDLE RegHandle, in EVENT_DESCRIPTOR EventDescriptor);

		/// <summary>Determines if the event is enabled for any session.</summary>
		/// <param name="RegHandle">Registration handle of the provider. The handle comes from EventRegister.</param>
		/// <param name="Level">
		/// Level of detail included in the event. Specify one of the following levels that are defined in Winmeta.h. Higher numbers imply
		/// that you get lower levels as well. For example, if you specify TRACE_LEVEL_WARNING, you also receive all warning, error, and
		/// fatal events.
		/// </param>
		/// <param name="Keyword">
		/// Bitmask that specifies the event category. This mask should be the same keyword mask that you defined in the manifest for the event.
		/// </param>
		/// <returns>Returns <c>TRUE</c> if the event is enabled for a session; otherwise, returns <c>FALSE</c>.</returns>
		/// <remarks>
		/// <para>
		/// Typically, providers do not call this function to determine if a session is expecting this event; they simply write the event and
		/// ETW determines if the event is logged to the session.
		/// </para>
		/// <para>
		/// Providers may want to call this function if they need to perform extra work to generate the event. In this case, calling this
		/// function first (to determine if a session is expecting this event or not) may save resources and time.
		/// </para>
		/// <para>
		/// The provider would call this function if the provider did not generate an EVENT_DESCRIPTOR structure for the event from the
		/// manifest. If the event descriptor is available, call the EventEnabled function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntprov/nf-evntprov-eventproviderenabled BOOLEAN EVNTAPI
		// EventProviderEnabled( REGHANDLE RegHandle, UCHAR Level, ULONGLONG Keyword );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntprov.h", MSDNShortId = "84c035b1-cdc7-47b7-b887-e5b508f17266")]
		[return: MarshalAs(UnmanagedType.U1)]
		public static extern bool EventProviderEnabled(REGHANDLE RegHandle, byte Level, ulong Keyword);

		/// <summary>Registers the provider.</summary>
		/// <param name="ProviderId">GUID that uniquely identifies the provider.</param>
		/// <param name="EnableCallback">
		/// Callback that ETW calls to notify you when a session enables or disables your provider. Can be <c>NULL</c>.
		/// </param>
		/// <param name="CallbackContext">
		/// Provider-defined context data to pass to the callback when the provider is enabled or disabled. Can be <c>NULL</c>.
		/// </param>
		/// <param name="RegHandle">
		/// Registration handle. The handle is used by most provider function calls. Before your provider exits, you must pass this handle to
		/// EventUnregister to free the handle.
		/// </param>
		/// <returns>Returns ERROR_SUCCESS if successful.</returns>
		/// <remarks>
		/// <para>Use this function to register your provider if you call EventWrite to write your events.</para>
		/// <para>
		/// A process can register up to 1,024 provider GUIDs; however, you should limit the number of providers that your process registers
		/// to one or two. This limit includes those registered using this function and the RegisterTraceGuids function.
		/// </para>
		/// <para><c>Prior to Windows Vista:</c> There is no limit to the number of providers that a process can register.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntprov/nf-evntprov-eventregister ULONG EVNTAPI EventRegister( LPCGUID
		// ProviderId, PENABLECALLBACK EnableCallback, PVOID CallbackContext, PREGHANDLE RegHandle );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntprov.h", MSDNShortId = "6025c3a6-7d88-49dc-bbc3-655c172dde3c")]
		public static extern Win32Error EventRegister(in Guid ProviderId, EnableCallback EnableCallback, IntPtr CallbackContext, out SafeREGHANDLE RegHandle);

		/// <summary>Performs operations on a registration object.</summary>
		/// <param name="RegHandle">
		/// <para>Type: <c>REGHANDLE</c></para>
		/// <para>Registration handle returned by EventRegister.</para>
		/// </param>
		/// <param name="InformationClass">
		/// <para>Type: <c>EVENT_INFO_CLASS</c></para>
		/// <para>Type of operation to be performed on the registration object.</para>
		/// </param>
		/// <param name="EventInformation">
		/// <para>Type: <c>PVOID</c></para>
		/// <para>The input buffer.</para>
		/// </param>
		/// <param name="InformationLength">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Size of the input buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The parameter is incorrect. This error is returned if the RegHandle parameter is not a valid registration handle.</term>
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntprov/nf-evntprov-eventsetinformation ULONG EVNTAPI EventSetInformation(
		// REGHANDLE RegHandle, EVENT_INFO_CLASS InformationClass, PVOID EventInformation, ULONG InformationLength );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntprov.h", MSDNShortId = "e8b408ba-4bb5-4166-bf43-d18e4fe8de32")]
		public static extern Win32Error EventSetInformation(REGHANDLE RegHandle, EVENT_INFO_CLASS InformationClass, IntPtr EventInformation, uint InformationLength);

		/// <summary>Removes the provider's registration. You must call this function before your process exits.</summary>
		/// <param name="RegHandle">Registration handle returned by EventRegister.</param>
		/// <returns>Returns ERROR_SUCCESS if successful.</returns>
		/// <remarks>
		/// For private sessions, you must stop the trace (call the ControlTrace function with the ControlCode parameter set to
		/// EVENT_TRACE_CONTROL_STOP) before calling this function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntprov/nf-evntprov-eventunregister ULONG EVNTAPI EventUnregister( REGHANDLE
		// RegHandle );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntprov.h", MSDNShortId = "fdcccf6f-2f31-4356-a4ee-3b6229c01b75")]
		public static extern Win32Error EventUnregister(REGHANDLE RegHandle);

		/// <summary>Use this function to write an event.</summary>
		/// <param name="RegHandle">Registration handle of the provider. The handle comes from EventRegister.</param>
		/// <param name="EventDescriptor">Metadata that identifies the event to write. For details, see EVENT_DESCRIPTOR.</param>
		/// <param name="UserDataCount">Number of EVENT_DATA_DESCRIPTOR structures in UserData. The maximum number is 128.</param>
		/// <param name="UserData">
		/// The event data to write. Allocate a block of memory that contains one or more EVENT_DATA_DESCRIPTOR structures. Set this
		/// parameter to <c>NULL</c> if UserDataCount is zero. The data must be in the order specified in the manifest.
		/// </param>
		/// <returns>Returns ERROR_SUCCESS if successful or one of the following values on error.</returns>
		/// <remarks>
		/// <para>Event data written with this function requires a manifest to consume the data.</para>
		/// <para>ETW decides based on the event descriptor if the event is written to a session (for details, see EnableTraceEx).</para>
		/// <para>
		/// If you call the EventActivityIdControl function to specify an activity identifier for the event, <c>EventWrite</c> retrieves the
		/// identifier from thread local storage and includes it with the event.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses <c>EventWrite</c>, see Writing Manifest-based Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntprov/nf-evntprov-eventwrite ULONG EVNTAPI EventWrite( REGHANDLE
		// RegHandle, PCEVENT_DESCRIPTOR EventDescriptor, ULONG UserDataCount, PEVENT_DATA_DESCRIPTOR UserData );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntprov.h", MSDNShortId = "93070eb7-c167-4419-abff-e861877dad07")]
		public static extern Win32Error EventWrite(REGHANDLE RegHandle, in EVENT_DESCRIPTOR EventDescriptor, uint UserDataCount, IntPtr UserData);

		/// <summary>Use this function to write an event.</summary>
		/// <param name="RegHandle">Registration handle of the provider. The handle comes from EventRegister.</param>
		/// <param name="EventDescriptor">
		/// A descriptor that contains the metadata that identifies the event to write. For details, see EVENT_DESCRIPTOR.
		/// </param>
		/// <param name="Filter">
		/// The instance identifiers that identify the session to which the event will not written. Use a bitwise OR to specify multiple
		/// identifiers. Set to zero if you do not support filters or if the event is being written to all sessions (no filters failed). For
		/// information on getting the identifier for a session, see the FilterData parameter of your EnableCallback callback.
		/// </param>
		/// <param name="Flags">Reserved. Must be zero.</param>
		/// <param name="ActivityId">
		/// GUID that uniquely identifies this activity. If <c>NULL</c>, ETW gets the identifier from the thread local storage. For details
		/// on getting this identifier, see EventActivityIdControl.
		/// </param>
		/// <param name="RelatedActivityId">
		/// Activity identifier from the previous component. Use this parameter to link your component's events to the previous component's
		/// events. To get the activity identifier that was set for the previous component, see the descriptions for the ControlCode
		/// parameter of the EventActivityIdControl function.
		/// </param>
		/// <param name="UserDataCount">Number of EVENT_DATA_DESCRIPTOR structures in UserData. The maximum number is 128.</param>
		/// <param name="UserData">
		/// The event data to write. Allocate a block of memory that contains one or more EVENT_DATA_DESCRIPTOR structures. Set this
		/// parameter to <c>NULL</c> if UserDataCount is zero. The data must be in the order specified in the manifest.
		/// </param>
		/// <returns>Returns ERROR_SUCCESS if successful or one of the following values on error.</returns>
		/// <remarks>
		/// <para>
		/// Event data written with this function requires a manifest. Since the manifest is embedded in the provider, the provider must be
		/// available for a consumer to consume the data written by the provider.
		/// </para>
		/// <para>
		/// Use the ActivityId and RelatedActivityId parameters when several components want to relate their events in an end-to-end tracing
		/// scenario. For example, components A, B, and C perform work on a related activity and want to link their events so that a consumer
		/// can consume all the events related to that activity. ETW uses thread local storage to make available to the next component the
		/// previous component's activity identifier. The component retrieves from the local storage the previous component's identifier and
		/// sets the related activity identifier to it. The consumer can then use the related activity identifier to walk the chain of the
		/// events from one component to the next.
		/// </para>
		/// <para>If each component defined their own activity identifier, the components can make the following calls to link the events:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Call the EventActivityIdControl function using the EVENT_ACTIVITY_CTRL_GET_SET_ID control code. The function uses your identifier
		/// to set the activity identifier in the thread local storage and returns the activity identifier for the previous component, if set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Set the RelatedActivityId parameter of this function to the ActivityId value that the EventActivityIdControl function returned.
		/// Note that for the first component, the related identifier will be all zeros (GUID_NULL).
		/// </term>
		/// </item>
		/// <item>
		/// <term>Set the ActivityId of this function to <c>NULL</c> to use the activity identifier that you set in thread local storage.</term>
		/// </item>
		/// </list>
		/// <para>
		/// A provider can define filters that a session uses to filter events based on event data. With level and keywords, ETW determines
		/// whether the event is written to the session but with filters, the provider uses the filter data to determine whether it writes
		/// the event to the session. For example, if your provider generates process events, you could define a data filter that filters
		/// process events based on the process identifier. If the identifier of the process did not match the identifier that the session
		/// passed as filter data, you would set (perform a bitwise OR) the Filter parameter to the session's instance identifier to prevent
		/// the event from being written to that session.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses EventWrite, see Writing Manifest-based Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntprov/nf-evntprov-eventwriteex ULONG EVNTAPI EventWriteEx( REGHANDLE
		// RegHandle, PCEVENT_DESCRIPTOR EventDescriptor, ULONG64 Filter, ULONG Flags, LPCGUID ActivityId, LPCGUID RelatedActivityId, ULONG
		// UserDataCount, PEVENT_DATA_DESCRIPTOR UserData );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntprov.h", MSDNShortId = "00b907cb-45cd-48c7-bea4-4d8a39b4fa24")]
		public static extern Win32Error EventWriteEx(REGHANDLE RegHandle, in EVENT_DESCRIPTOR EventDescriptor, ulong Filter, [Optional] uint Flags, in Guid ActivityId, in Guid RelatedActivityId, uint UserDataCount, IntPtr UserData);

		/// <summary>Use this function to write an event.</summary>
		/// <param name="RegHandle">Registration handle of the provider. The handle comes from EventRegister.</param>
		/// <param name="EventDescriptor">
		/// A descriptor that contains the metadata that identifies the event to write. For details, see EVENT_DESCRIPTOR.
		/// </param>
		/// <param name="Filter">
		/// The instance identifiers that identify the session to which the event will not written. Use a bitwise OR to specify multiple
		/// identifiers. Set to zero if you do not support filters or if the event is being written to all sessions (no filters failed). For
		/// information on getting the identifier for a session, see the FilterData parameter of your EnableCallback callback.
		/// </param>
		/// <param name="Flags">Reserved. Must be zero.</param>
		/// <param name="ActivityId">
		/// GUID that uniquely identifies this activity. If <c>NULL</c>, ETW gets the identifier from the thread local storage. For details
		/// on getting this identifier, see EventActivityIdControl.
		/// </param>
		/// <param name="RelatedActivityId">
		/// Activity identifier from the previous component. Use this parameter to link your component's events to the previous component's
		/// events. To get the activity identifier that was set for the previous component, see the descriptions for the ControlCode
		/// parameter of the EventActivityIdControl function.
		/// </param>
		/// <param name="UserDataCount">Number of EVENT_DATA_DESCRIPTOR structures in UserData. The maximum number is 128.</param>
		/// <param name="UserData">
		/// The event data to write. Allocate a block of memory that contains one or more EVENT_DATA_DESCRIPTOR structures. Set this
		/// parameter to <c>NULL</c> if UserDataCount is zero. The data must be in the order specified in the manifest.
		/// </param>
		/// <returns>Returns ERROR_SUCCESS if successful or one of the following values on error.</returns>
		/// <remarks>
		/// <para>
		/// Event data written with this function requires a manifest. Since the manifest is embedded in the provider, the provider must be
		/// available for a consumer to consume the data written by the provider.
		/// </para>
		/// <para>
		/// Use the ActivityId and RelatedActivityId parameters when several components want to relate their events in an end-to-end tracing
		/// scenario. For example, components A, B, and C perform work on a related activity and want to link their events so that a consumer
		/// can consume all the events related to that activity. ETW uses thread local storage to make available to the next component the
		/// previous component's activity identifier. The component retrieves from the local storage the previous component's identifier and
		/// sets the related activity identifier to it. The consumer can then use the related activity identifier to walk the chain of the
		/// events from one component to the next.
		/// </para>
		/// <para>If each component defined their own activity identifier, the components can make the following calls to link the events:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Call the EventActivityIdControl function using the EVENT_ACTIVITY_CTRL_GET_SET_ID control code. The function uses your identifier
		/// to set the activity identifier in the thread local storage and returns the activity identifier for the previous component, if set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Set the RelatedActivityId parameter of this function to the ActivityId value that the EventActivityIdControl function returned.
		/// Note that for the first component, the related identifier will be all zeros (GUID_NULL).
		/// </term>
		/// </item>
		/// <item>
		/// <term>Set the ActivityId of this function to <c>NULL</c> to use the activity identifier that you set in thread local storage.</term>
		/// </item>
		/// </list>
		/// <para>
		/// A provider can define filters that a session uses to filter events based on event data. With level and keywords, ETW determines
		/// whether the event is written to the session but with filters, the provider uses the filter data to determine whether it writes
		/// the event to the session. For example, if your provider generates process events, you could define a data filter that filters
		/// process events based on the process identifier. If the identifier of the process did not match the identifier that the session
		/// passed as filter data, you would set (perform a bitwise OR) the Filter parameter to the session's instance identifier to prevent
		/// the event from being written to that session.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses EventWrite, see Writing Manifest-based Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntprov/nf-evntprov-eventwriteex ULONG EVNTAPI EventWriteEx( REGHANDLE
		// RegHandle, PCEVENT_DESCRIPTOR EventDescriptor, ULONG64 Filter, ULONG Flags, LPCGUID ActivityId, LPCGUID RelatedActivityId, ULONG
		// UserDataCount, PEVENT_DATA_DESCRIPTOR UserData );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntprov.h", MSDNShortId = "00b907cb-45cd-48c7-bea4-4d8a39b4fa24")]
		public static extern Win32Error EventWriteEx(REGHANDLE RegHandle, in EVENT_DESCRIPTOR EventDescriptor, ulong Filter, [Optional] uint Flags, [Optional] IntPtr ActivityId, [Optional] IntPtr RelatedActivityId, uint UserDataCount, IntPtr UserData);

		/// <summary>Writes an event that contains a string as its data.</summary>
		/// <param name="RegHandle">Registration handle of the provider. The handle comes from EventRegister.</param>
		/// <param name="Level">
		/// Level of detail included in the event. If the provider uses a manifest to define the event, set this value to the same level
		/// defined in the manifest. If the event is not defined in a manifest, set this value to 0 to ensure the event is written,
		/// otherwise, the event is written based on the level rule defined in EnableTraceEx.
		/// </param>
		/// <param name="Keyword">
		/// Bitmask that specifies the event category. If the provider uses a manifest to define the event, set this value to the same
		/// keyword mask defined in the manifest. If the event is not defined in a manifest, set this value to 0 to ensure the event is
		/// written, otherwise, the event is written based on the keyword rules defined in EnableTraceEx.
		/// </param>
		/// <param name="String">Null-terminated string to write as the event data.</param>
		/// <returns>Returns ERROR_SUCCESS if successful or one of the following values on error.</returns>
		/// <remarks>
		/// <para>
		/// The provider does not need a manifest to use this function to write the event, unlike the EventWrite function which does require
		/// a manifest. Consumers also do not need a manifest to consume events written with this function.
		/// </para>
		/// <para>This function gets the acitivity identifier from the thread local storage, if set.</para>
		/// <para>ETW decides based on the level and keyword mask whether the event is written to a session (for details, see EnableTraceEx).</para>
		/// <para>This function cannot be used to write events to the Admin or Operational channels.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntprov/nf-evntprov-eventwritestring ULONG EVNTAPI EventWriteString(
		// REGHANDLE RegHandle, UCHAR Level, ULONGLONG Keyword, PCWSTR String );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntprov.h", MSDNShortId = "ecdb0e92-fcc1-4b4f-99ea-6812b6b49381")]
		public static extern Win32Error EventWriteString(REGHANDLE RegHandle, byte Level, ulong Keyword, [MarshalAs(UnmanagedType.LPWStr)] string String);

		/// <summary>Links events together when tracing events in an end-to-end scenario.</summary>
		/// <param name="RegHandle">Registration handle of the provider. The handle comes from EventRegister.</param>
		/// <param name="EventDescriptor">Metadata that identifies the event to write. For details, see EVENT_DESCRIPTOR.</param>
		/// <param name="ActivityId">
		/// GUID that uniquely identifies this activity. If <c>NULL</c>, ETW gets the identifier from the thread local storage. For details
		/// on getting this identifier, see EventActivityIdControl.
		/// </param>
		/// <param name="RelatedActivityId">
		/// Activity identifier from the previous component. Use this parameter to link your component's events to the previous component's
		/// events. To get the activity identifier that was set for the previous component, see the descriptions for the ControlCode
		/// parameter of the EventActivityIdControl function.
		/// </param>
		/// <param name="UserDataCount">Number of EVENT_DATA_DESCRIPTOR structures in UserData. The maximum number is 128.</param>
		/// <param name="UserData">
		/// The event data to write. Allocate a block of memory that contains one or more EVENT_DATA_DESCRIPTOR structures. Set this
		/// parameter to <c>NULL</c> if UserDataCount is zero. The data must be in the order specified in the manifest.
		/// </param>
		/// <returns>Returns ERROR_SUCCESS if successful or one of the following values on error.</returns>
		/// <remarks>
		/// <para>Beginning with Windows 7 and Windows Server 2008 R2, use EventWriteEx to write transfer events in an end-to-end scenario.</para>
		/// <para>
		/// Use this function when several components want to relate their events in an end-to-end tracing scenario. For example, components
		/// A, B, and C perform work on a related activity and want to link their events so that a consumer can consume all the events
		/// related to that activity. ETW uses thread local storage to make available to the next component the previous component's activity
		/// identifier. The component retrieves from the local storage the previous component's identifier and sets the related activity
		/// identifier to it. The consumer can then use the related activity identifier to walk the chain of the events from one component to
		/// the next.
		/// </para>
		/// <para>If each component defined their own activity identifier, the components can make the following calls to link the events:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Call the EventActivityIdControl function using the EVENT_ACTIVITY_CTRL_GET_SET_ID control code. The function uses your identifier
		/// to set the activity identifier in the thread local storage and returns the activity identifier for the previous component, if set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Set the RelatedActivityId parameter of this function to the ActivityId value that the EventActivityIdControl function returned.
		/// Note that for the first component, the related identifier will be all zeros (GUID_NULL).
		/// </term>
		/// </item>
		/// <item>
		/// <term>Set the ActivityId of this function to <c>NULL</c> to use the activity identifier that you set in thread local storage.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Event data written with this function requires a manifest. Since the manifest is embedded in the provider, the provider must be
		/// available for a consumer to consume the data written by the provider.
		/// </para>
		/// <para>ETW decides based on the event descriptor if the event is written to a session (for details, see EnableTraceEx).</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntprov/nf-evntprov-eventwritetransfer ULONG EVNTAPI EventWriteTransfer(
		// REGHANDLE RegHandle, PCEVENT_DESCRIPTOR EventDescriptor, LPCGUID ActivityId, LPCGUID RelatedActivityId, ULONG UserDataCount,
		// PEVENT_DATA_DESCRIPTOR UserData );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntprov.h", MSDNShortId = "798cf3ba-e1cc-4eaf-a1d2-2313a64aab1a")]
		public static extern Win32Error EventWriteTransfer(REGHANDLE RegHandle, in EVENT_DESCRIPTOR EventDescriptor, in Guid ActivityId, in Guid RelatedActivityId, uint UserDataCount, IntPtr UserData);

		/// <summary>Links events together when tracing events in an end-to-end scenario.</summary>
		/// <param name="RegHandle">Registration handle of the provider. The handle comes from EventRegister.</param>
		/// <param name="EventDescriptor">Metadata that identifies the event to write. For details, see EVENT_DESCRIPTOR.</param>
		/// <param name="ActivityId">
		/// GUID that uniquely identifies this activity. If <c>NULL</c>, ETW gets the identifier from the thread local storage. For details
		/// on getting this identifier, see EventActivityIdControl.
		/// </param>
		/// <param name="RelatedActivityId">
		/// Activity identifier from the previous component. Use this parameter to link your component's events to the previous component's
		/// events. To get the activity identifier that was set for the previous component, see the descriptions for the ControlCode
		/// parameter of the EventActivityIdControl function.
		/// </param>
		/// <param name="UserDataCount">Number of EVENT_DATA_DESCRIPTOR structures in UserData. The maximum number is 128.</param>
		/// <param name="UserData">
		/// The event data to write. Allocate a block of memory that contains one or more EVENT_DATA_DESCRIPTOR structures. Set this
		/// parameter to <c>NULL</c> if UserDataCount is zero. The data must be in the order specified in the manifest.
		/// </param>
		/// <returns>Returns ERROR_SUCCESS if successful or one of the following values on error.</returns>
		/// <remarks>
		/// <para>Beginning with Windows 7 and Windows Server 2008 R2, use EventWriteEx to write transfer events in an end-to-end scenario.</para>
		/// <para>
		/// Use this function when several components want to relate their events in an end-to-end tracing scenario. For example, components
		/// A, B, and C perform work on a related activity and want to link their events so that a consumer can consume all the events
		/// related to that activity. ETW uses thread local storage to make available to the next component the previous component's activity
		/// identifier. The component retrieves from the local storage the previous component's identifier and sets the related activity
		/// identifier to it. The consumer can then use the related activity identifier to walk the chain of the events from one component to
		/// the next.
		/// </para>
		/// <para>If each component defined their own activity identifier, the components can make the following calls to link the events:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Call the EventActivityIdControl function using the EVENT_ACTIVITY_CTRL_GET_SET_ID control code. The function uses your identifier
		/// to set the activity identifier in the thread local storage and returns the activity identifier for the previous component, if set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Set the RelatedActivityId parameter of this function to the ActivityId value that the EventActivityIdControl function returned.
		/// Note that for the first component, the related identifier will be all zeros (GUID_NULL).
		/// </term>
		/// </item>
		/// <item>
		/// <term>Set the ActivityId of this function to <c>NULL</c> to use the activity identifier that you set in thread local storage.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Event data written with this function requires a manifest. Since the manifest is embedded in the provider, the provider must be
		/// available for a consumer to consume the data written by the provider.
		/// </para>
		/// <para>ETW decides based on the event descriptor if the event is written to a session (for details, see EnableTraceEx).</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntprov/nf-evntprov-eventwritetransfer ULONG EVNTAPI EventWriteTransfer(
		// REGHANDLE RegHandle, PCEVENT_DESCRIPTOR EventDescriptor, LPCGUID ActivityId, LPCGUID RelatedActivityId, ULONG UserDataCount,
		// PEVENT_DATA_DESCRIPTOR UserData );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("evntprov.h", MSDNShortId = "798cf3ba-e1cc-4eaf-a1d2-2313a64aab1a")]
		public static extern Win32Error EventWriteTransfer(REGHANDLE RegHandle, in EVENT_DESCRIPTOR EventDescriptor, [Optional] IntPtr ActivityId, [Optional] IntPtr RelatedActivityId, uint UserDataCount, IntPtr UserData);

		/// <summary>
		/// The EVENT_DATA_DESCRIPTOR structure is used with the user mode EventWrite and the kernel mode EtwWrite functions to send events.
		/// The EVENT_DATA_DESCRIPTOR structure describes the event payload.
		/// </summary>
		/// <remarks>
		/// The most convenient method of populating the EVENT_DATA_DESCRIPTOR structure is to use the <c>EventDataDescCreate</c> macro. This
		/// macro is declared in Evntprov.h and its use is documented in the Microsoft Windows SDK documentation. The following example uses
		/// the <c>EventDataDescCreate</c> macro to populate an array of three EVENT_DATA_DESCRIPTOR structures. This array is then passed to
		/// the <c>EtwWrite</c> function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntprov/ns-evntprov-_event_data_descriptor typedef struct
		// _EVENT_DATA_DESCRIPTOR { ULONGLONG Ptr; ULONG Size; union { ULONG Reserved; struct { UCHAR Type; UCHAR Reserved1; USHORT
		// Reserved2; } DUMMYSTRUCTNAME; } DUMMYUNIONNAME; } EVENT_DATA_DESCRIPTOR, *PEVENT_DATA_DESCRIPTOR;
		[PInvokeData("evntprov.h", MSDNShortId = "eb2b7ab6-52da-4d16-b315-6adab3131a05")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_DATA_DESCRIPTOR
		{
			/// <summary>A pointer to the event descriptor data.</summary>
			public ulong Ptr;

			/// <summary>The size of the payload field, in bytes.</summary>
			public uint Size;

			/// <summary/>
			public byte Type;

			/// <summary/>
			public byte Reserved1;

			/// <summary/>
			public ushort Reserved2;

			/// <summary>Initializes a new instance of the <see cref="EVENT_DATA_DESCRIPTOR"/> struct.</summary>
			/// <param name="DataPtr">
			/// <para>A pointer to the event data used to set the <c>Ptr</c> member of EVENT_DATA_DESCRIPTOR.</para>
			/// <para>If the event data's type is a <c>NULL</c>-terminated string, the DataPtr parameter must not be <c>NULL</c>.</para>
			/// <para>
			/// If the event data's type is a string whose size is described by some other field in the event, the DataPtr parameter may be <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="DataSize">The size of the event data. The value is used to set the <c>Size</c> member of EVENT_DATA_DESCRIPTOR.</param>
			public EVENT_DATA_DESCRIPTOR(IntPtr DataPtr, uint DataSize)
			{
				Ptr = unchecked((ulong)DataPtr.ToInt64());
				Size = DataSize;
				Reserved2 = Reserved1 = Type = 0;
			}
		}

		/// <summary>The EVENT_DESCRIPTOR structure identifies the description information that is available for each event.</summary>
		/// <remarks>
		/// <para>
		/// The <c>Id</c> member is the event identifier. The structure members <c>Id</c> and <c>Version</c> can be used together to identify
		/// all events for a specific provider. When the <c>Id</c> and <c>Version</c> are used in conjunction with the manifest, you can
		/// precisely identify the structure and metadata of the event.
		/// </para>
		/// <para>
		/// The pointer to the EVENT_DESCRIPTOR is passed to the EtwEventEnabled, EtwWrite, and EtwWriteTransfer functions. The most
		/// convenient method of populating the EVENT_DESCRIPTOR structure is to use the <c>EventDescCreate</c> macro. This macro is declared
		/// in Evntprov.h and its use is documented in the Microsoft Windows SDK.
		/// </para>
		/// <para>
		/// The following is a list of the convenience macros that you can use to create the event descriptors and to extract and set fields
		/// in the structure. For information on these macros, see Event Tracing Macros.
		/// </para>
		/// <para><c>Macros to create event descriptors:</c></para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>EventDescCreate</c></term>
		/// </item>
		/// <item>
		/// <term><c>EventDescZero</c></term>
		/// </item>
		/// </list>
		/// <para><c>Macros to extract information from an event descriptor:</c></para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>EventDescGetId</c></term>
		/// </item>
		/// <item>
		/// <term><c>EventDescGetVersion</c></term>
		/// </item>
		/// <item>
		/// <term><c>EventDescGetTask</c></term>
		/// </item>
		/// <item>
		/// <term><c>EventDescGetOpcode</c></term>
		/// </item>
		/// <item>
		/// <term><c>EventDescGetChannel</c></term>
		/// </item>
		/// <item>
		/// <term><c>EventDescGetLevel</c></term>
		/// </item>
		/// <item>
		/// <term><c>EventDescGetKeyword</c></term>
		/// </item>
		/// </list>
		/// <para><c>Macros to set fields in an event descriptor:</c></para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>EventDescSetId</c></term>
		/// </item>
		/// <item>
		/// <term><c>EventDescSetVersion</c></term>
		/// </item>
		/// <item>
		/// <term><c>EventDescSetTask</c></term>
		/// </item>
		/// <item>
		/// <term><c>EventDescSetOpcode</c></term>
		/// </item>
		/// <item>
		/// <term><c>EventDescSetLevel</c></term>
		/// </item>
		/// <item>
		/// <term><c>EventDescSetChannel</c></term>
		/// </item>
		/// <item>
		/// <term><c>EventDescSetKeyword</c></term>
		/// </item>
		/// <item>
		/// <term><c>EventDescOrKeyword</c></term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntprov/ns-evntprov-_event_descriptor typedef struct _EVENT_DESCRIPTOR {
		// USHORT Id; UCHAR Version; UCHAR Channel; UCHAR Level; UCHAR Opcode; USHORT Task; ULONGLONG Keyword; } EVENT_DESCRIPTOR, *PEVENT_DESCRIPTOR;
		[PInvokeData("evntprov.h", MSDNShortId = "cfe84b3d-fed2-4624-9899-8451e5b39de0")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_DESCRIPTOR
		{
			/// <summary>The event identifier. Each event is associated with a 16-bit numeric value.</summary>
			public ushort Id;

			/// <summary>
			/// A numeric value that represents a version of the event. Component updates can change this value for a specific event.
			/// </summary>
			public byte Version;

			/// <summary>
			/// The channel that the event is intended for. Note that the channel name is not stored here. The value of the channel is
			/// assigned by the message compiler.
			/// </summary>
			public byte Channel;

			/// <summary>
			/// The level of the event. The level indicates the severity or verbosity of the event. The level is used with earlier versions
			/// of the ETW and WPP event fields. The levels have names with values, such as Error, Warning, Information, and so on.
			/// </summary>
			public byte Level;

			/// <summary>
			/// The activity that the driver was performing at the time of the event. The <c>Opcode</c> member is defined by the provider or
			/// is one of the system-defined values defined in the Winmeta.xml file that is provided with the Windows Driver Kit (WDK) in the
			/// %Winddk%&lt;i&gt;version\inc\api directory.
			/// </summary>
			public byte Opcode;

			/// <summary>
			/// The <c>Task</c> corresponds to the logical activity that the driver was performing when it raised the event. The
			/// <c>Opcode</c> member refers to a specific action within that logical activity.
			/// </summary>
			public ushort Task;

			/// <summary>
			/// The categories or tags assigned to the event. Each keyword categorizes the event in some way. For example, a category could
			/// be <c>Network</c>, <c>Storage</c>, or <c>Not Found</c>. An event can belong to more then one category, in which case multiple
			/// keywords are specified for the event. The keyword values are bitmasks and can be combined.
			/// </summary>
			public ulong Keyword;

			/// <summary>Initializes a new instance of the <see cref="EVENT_DESCRIPTOR"/> struct.</summary>
			/// <param name="Id">Event identifier. The value is used to set the <c>Id</c> member of EVENT_DESCRIPTOR.</param>
			/// <param name="Version">Version of the event. The value is used to set the <c>Version</c> member of EVENT_DESCRIPTOR.</param>
			/// <param name="Channel">
			/// The category of events to which this event belongs. The value is used to set the <c>Channel</c> member of EVENT_DESCRIPTOR.
			/// </param>
			/// <param name="Level">Specifies the severity of the event. The value is used to set the <c>Level</c> member of EVENT_DESCRIPTOR.</param>
			/// <param name="Task">
			/// Identifies a logical component of the application whose events you want to enable. The value is used to set the <c>Task</c>
			/// member of EVENT_DESCRIPTOR.
			/// </param>
			/// <param name="Opcode">
			/// Operation being performed at the time the event was written. The value is used to set the <c>Opcode</c> member of EVENT_DESCRIPTOR.
			/// </param>
			/// <param name="Keyword">
			/// Bitmask that further defines the category of events to which the event belongs. The value is used to set the <c>Keyword</c>
			/// member of EVENT_DESCRIPTOR.
			/// </param>
			public EVENT_DESCRIPTOR(ushort Id, byte Version, byte Channel, byte Level, ushort Task, byte Opcode, ulong Keyword)
			{
				this.Channel = Channel;
				this.Id = Id;
				this.Keyword = Keyword;
				this.Level = Level;
				this.Opcode = Opcode;
				this.Task = Task;
				this.Version = Version;
			}
		}

		/// <summary>
		/// The EVENT_FILTER_DESCRIPTOR structure supplements the event provider, level, and keyword data that determines which events are
		/// reported and traced. The EVENT_FILTER_DESCRIPTOR structure gives the event provider greater control over the selection of events
		/// for reporting and tracing.
		/// </summary>
		/// <remarks>
		/// You pass a pointer to the EVENT_FILTER_DESCRIPTOR structure when you create the optional driver-supplied
		/// EtwEnableCallbackfunction. When you register the driver with ETW, the EtwRegister function takes a pointer to the
		/// <c>EtwEnableCallback</c> function as a parameter.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/evntprov/ns-evntprov-_event_filter_descriptor typedef struct
		// _EVENT_FILTER_DESCRIPTOR { ULONGLONG Ptr; ULONG Size; ULONG Type; } EVENT_FILTER_DESCRIPTOR, *PEVENT_FILTER_DESCRIPTOR;
		[PInvokeData("evntprov.h", MSDNShortId = "3870a471-a3cf-424f-bba3-bc06de1ebecc")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EVENT_FILTER_DESCRIPTOR
		{
			/// <summary>A pointer to the filter data.</summary>
			public ulong Ptr;

			/// <summary>The size of the filter data, in bytes. The maximum size is 1024 bytes.</summary>
			public uint Size;

			/// <summary>
			/// The type of filter data. The type is application-defined. An event controller that knows about the provider and knows details
			/// about the provider's events can use the <c>Type</c> field to send the provider an arbitrary set of data for use as
			/// enhancements to the filtering of events.
			/// </summary>
			public uint Type;
		}

		/// <summary>Provides a handle to a provider registration handle.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct REGHANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="REGHANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public REGHANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="REGHANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static REGHANDLE NULL => new REGHANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="REGHANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(REGHANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="REGHANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator REGHANDLE(IntPtr h) => new REGHANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(REGHANDLE h1, REGHANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(REGHANDLE h1, REGHANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is REGHANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="REGHANDLE"/> that is disposed using <see cref="EventUnregister"/>.</summary>
		public class SafeREGHANDLE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeREGHANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeREGHANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeREGHANDLE"/> class.</summary>
			private SafeREGHANDLE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeREGHANDLE"/> to <see cref="REGHANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator REGHANDLE(SafeREGHANDLE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => EventUnregister(handle).Succeeded;
		}
	}
}