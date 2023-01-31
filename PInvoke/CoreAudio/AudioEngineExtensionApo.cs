#nullable enable

using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.PInvoke;

public static partial class CoreAudio
{
	/// <summary>Specifies the level of an APO event logged with IAudioProcessingObjectLoggingService::ApoLog.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/ne-audioengineextensionapo-apo_log_level typedef enum
	// APO_LOG_LEVEL { APO_LOG_LEVEL_ALWAYS, APO_LOG_LEVEL_CRITICAL, APO_LOG_LEVEL_ERROR, APO_LOG_LEVEL_WARNING, APO_LOG_LEVEL_INFO,
	// APO_LOG_LEVEL_VERBOSE } ;
	[PInvokeData("audioengineextensionapo.h", MSDNShortId = "NE:audioengineextensionapo.APO_LOG_LEVEL")]
	public enum APO_LOG_LEVEL
	{
		/// <summary>All events.</summary>
		APO_LOG_LEVEL_ALWAYS = 0,

		/// <summary>Abnormal exit or termination events.</summary>
		APO_LOG_LEVEL_CRITICAL,

		/// <summary>Severe error events.</summary>
		APO_LOG_LEVEL_ERROR,

		/// <summary>Warning events such as allocation failures.</summary>
		APO_LOG_LEVEL_WARNING,

		/// <summary>Non-error events such as entry or exit events.</summary>
		APO_LOG_LEVEL_INFO,

		/// <summary>Detailed trace events.</summary>
		APO_LOG_LEVEL_VERBOSE,
	}

	/// <summary>Specifies the type of an APO_NOTIFICATION.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/ne-audioengineextensionapo-apo_notification_type typedef
	// enum APO_NOTIFICATION_TYPE { APO_NOTIFICATION_TYPE_NONE, APO_NOTIFICATION_TYPE_ENDPOINT_VOLUME,
	// APO_NOTIFICATION_TYPE_ENDPOINT_PROPERTY_CHANGE, APO_NOTIFICATION_TYPE_SYSTEM_EFFECTS_PROPERTY_CHANGE,
	// APO_NOTIFICATION_TYPE_ENDPOINT_VOLUME2, APO_NOTIFICATION_TYPE_DEVICE_ORIENTATION, APO_NOTIFICATION_TYPE_MICROPHONE_BOOST } ;
	[PInvokeData("audioengineextensionapo.h", MSDNShortId = "NE:audioengineextensionapo.APO_NOTIFICATION_TYPE")]
	public enum APO_NOTIFICATION_TYPE
	{
		/// <summary>None.</summary>
		APO_NOTIFICATION_TYPE_NONE = 0,

		/// <summary>Endpoint volume notification.</summary>
		APO_NOTIFICATION_TYPE_ENDPOINT_VOLUME = 1,

		/// <summary>Endpoint property change notification.</summary>
		APO_NOTIFICATION_TYPE_ENDPOINT_PROPERTY_CHANGE = 2,

		/// <summary>System effects property change notification.</summary>
		APO_NOTIFICATION_TYPE_SYSTEM_EFFECTS_PROPERTY_CHANGE = 3,

		/// <summary>Endpoint volume notifications for an endpoint that includes master and channel volume in dB.</summary>
		APO_NOTIFICATION_TYPE_ENDPOINT_VOLUME2 = 4,

		/// <summary>Orientation notifications for the device.</summary>
		APO_NOTIFICATION_TYPE_DEVICE_ORIENTATION = 5,

		/// <summary>Microphone boost notifications</summary>
		APO_NOTIFICATION_TYPE_MICROPHONE_BOOST = 6
	}

	/// <summary>Specifies the state of a System Effects Audio Processing Object (sAPO) audio effect.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/ne-audioengineextensionapo-audio_systemeffect_state
	// typedef enum AUDIO_SYSTEMEFFECT_STATE { AUDIO_SYSTEMEFFECT_STATE_OFF, AUDIO_SYSTEMEFFECT_STATE_ON } ;
	[PInvokeData("audioengineextensionapo.h", MSDNShortId = "NE:audioengineextensionapo.AUDIO_SYSTEMEFFECT_STATE")]
	public enum AUDIO_SYSTEMEFFECT_STATE
	{
		/// <summary>The audio effect is off.</summary>
		AUDIO_SYSTEMEFFECT_STATE_OFF,

		/// <summary>The audio effect is on.</summary>
		AUDIO_SYSTEMEFFECT_STATE_ON,
	}

	/// <summary>Undocumented</summary>
	[PInvokeData("audioengineextensionapo.h")]
	public enum DEVICE_ORIENTATION_TYPE
	{
		/// <summary>Undocumented</summary>
		DEVICE_NOT_ROTATED,

		/// <summary>Undocumented</summary>
		DEVICE_ROTATED_90_DEGREES_CLOCKWISE,

		/// <summary>Undocumented</summary>
		DEVICE_ROTATED_180_DEGREES_CLOCKWISE,

		/// <summary>Undocumented</summary>
		DEVICE_ROTATED_270_DEGREES_CLOCKWISE
	}

	/// <summary>Represents a logging service for APOs.</summary>
	/// <remarks>
	/// <para>
	/// Get an instance of this interface by QueryService on the object in the pServiceProvider field of the APOInitSystemEffects3 structure
	/// passed in the pbyData parameter to IAudioProcessingObject::Initialize. Specify <c>SID_AudioProcessingObjectLoggingService</c> as the
	/// identifier in the guidService parameter.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// IAudioProcessingObjectLoggingService::ApoLog should never be called from a real-time priority thread. For more information on thread
	/// priorities, see Scheduling Priorities.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/nn-audioengineextensionapo-iaudioprocessingobjectloggingservice
	[PInvokeData("audioengineextensionapo.h", MSDNShortId = "NN:audioengineextensionapo.IAudioProcessingObjectLoggingService")]
	[ComImport, Guid("698f0107-1745-4708-95a5-d84478a62a65"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioProcessingObjectLoggingService
	{
		/// <summary>Logs an APO event.</summary>
		/// <param name="level">A value from the APO_LOG_LEVEL enumeration specifying the level of the event being logged.</param>
		/// <param name="format">The format-control string for the log message.</param>
		/// <param name="args">Format argument list.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// This method should never be called from a real-time priority thread. For more information on thread priorities, see Scheduling Priorities.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/nf-audioengineextensionapo-iaudioprocessingobjectloggingservice-apolog
		// void ApoLog( APO_LOG_LEVEL level, LPCWSTR format, ... );
		[PreserveSig]
		void ApoLog(APO_LOG_LEVEL level, string format, IntPtr args);
	}

	/// <summary>
	/// Implemented by clients to register for and receive common audio-related notifications for APO endpoint and system effect notifications.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/nn-audioengineextensionapo-iaudioprocessingobjectnotifications
	[PInvokeData("audioengineextensionapo.h", MSDNShortId = "NN:audioengineextensionapo.IAudioProcessingObjectNotifications")]
	[ComImport, Guid("56B0C76F-02FD-4B21-A52E-9F8219FC86E4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioProcessingObjectNotifications
	{
		/// <summary>
		/// Called by the system to allow clients to register to receive notification callbacks for APO endpoint and system effect notifications.
		/// </summary>
		/// <param name="apoNotifications">
		/// Output parameter that returns a pointer to an array of APO_NOTIFICATION_DESCRIPTOR specifying the set of APO changes for which
		/// notifications are requested.
		/// </param>
		/// <param name="count">Output parameter specifying the number of items returned in apoNotifications.</param>
		/// <returns>An HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/nf-audioengineextensionapo-iaudioprocessingobjectnotifications-getaponotificationregistrationinfo
		// HRESULT GetApoNotificationRegistrationInfo( APO_NOTIFICATION_DESCRIPTOR **apoNotifications, DWORD *count );
		[PreserveSig]
		HRESULT GetApoNotificationRegistrationInfo(
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] out APO_NOTIFICATION_DESCRIPTOR[] apoNotifications, out uint count);

		/// <summary>Called by the system to notify clients of changes to APO endpoints or system effects.</summary>
		/// <param name="apoNotification">An APO_NOTIFICATION representing the APO change associated with the notification.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Specify the set of APO changes for which this method is called by implementing IAudioProcessingObjectNotifications::GetApoNotificationRegistrationInfo.</para>
		/// <para>
		/// This method will be called after LockForProcess is called and will stop being called before UnlockForProcess. If there are any
		/// notifications in flight, they might get executed during or after <c>UnlockForProcess</c>. The APO must handle synchronization in
		/// this case.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// APOs must query each property once to get its initial value because <c>HandleNotification</c> method is only invoked when any of
		/// the properties have changed. The exceptions to this are the initial audio endpoint volume when the APO registers for
		/// APO_NOTIFICATION_TYPE_ENDPOINT_VOLUME and the value of PKEY_AudioEndpoint_Disable_SysFx if the APO registers for APO_NOTIFICATION_TYPE_ENDPOINT_PROPERTY_CHANGE
		/// </para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/nf-audioengineextensionapo-iaudioprocessingobjectnotifications-handlenotification
		// void HandleNotification( APO_NOTIFICATION *apoNotification );
		[PreserveSig]
		void HandleNotification(in APO_NOTIFICATION apoNotification);
	}

	/// <summary>Undocumented</summary>
	/// <seealso cref="Vanara.PInvoke.CoreAudio.IAudioProcessingObjectNotifications"/>
	[ComImport, Guid("ca2cfbde-a9d6-4eb0-bc95-c4d026b380f0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioProcessingObjectNotifications2 : IAudioProcessingObjectNotifications
	{
		/// <summary>
		/// Called by the system to allow clients to register to receive notification callbacks for APO endpoint and system effect notifications.
		/// </summary>
		/// <param name="apoNotifications">
		/// Output parameter that returns a pointer to an array of APO_NOTIFICATION_DESCRIPTOR specifying the set of APO changes for which
		/// notifications are requested.
		/// </param>
		/// <param name="count">Output parameter specifying the number of items returned in apoNotifications.</param>
		/// <returns>An HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/nf-audioengineextensionapo-iaudioprocessingobjectnotifications-getaponotificationregistrationinfo
		// HRESULT GetApoNotificationRegistrationInfo( APO_NOTIFICATION_DESCRIPTOR **apoNotifications, DWORD *count );
		[PreserveSig]
		new HRESULT GetApoNotificationRegistrationInfo(
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] out APO_NOTIFICATION_DESCRIPTOR[] apoNotifications, out uint count);

		/// <summary>Called by the system to notify clients of changes to APO endpoints or system effects.</summary>
		/// <param name="apoNotification">An APO_NOTIFICATION representing the APO change associated with the notification.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Specify the set of APO changes for which this method is called by implementing IAudioProcessingObjectNotifications::GetApoNotificationRegistrationInfo.</para>
		/// <para>
		/// This method will be called after LockForProcess is called and will stop being called before UnlockForProcess. If there are any
		/// notifications in flight, they might get executed during or after <c>UnlockForProcess</c>. The APO must handle synchronization in
		/// this case.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// APOs must query each property once to get its initial value because <c>HandleNotification</c> method is only invoked when any of
		/// the properties have changed. The exceptions to this are the initial audio endpoint volume when the APO registers for
		/// APO_NOTIFICATION_TYPE_ENDPOINT_VOLUME and the value of PKEY_AudioEndpoint_Disable_SysFx if the APO registers for APO_NOTIFICATION_TYPE_ENDPOINT_PROPERTY_CHANGE
		/// </para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/nf-audioengineextensionapo-iaudioprocessingobjectnotifications-handlenotification
		// void HandleNotification( APO_NOTIFICATION *apoNotification );
		[PreserveSig]
		new void HandleNotification(in APO_NOTIFICATION apoNotification);

		/// <summary>Undocumented</summary>
		[PreserveSig]
		HRESULT GetApoNotificationRegistrationInfo2(APO_NOTIFICATION_TYPE maxApoNotificationTypeSupported,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out APO_NOTIFICATION_DESCRIPTOR[] apoNotifications, out uint count);
	}

	/// <summary>Provides access to the real time work queue for APOs.</summary>
	/// <remarks>
	/// <para>
	/// Get an instance of this interface by calling QueryService on the object in the pServiceProvider field of the APOInitSystemEffects3
	/// structure passed in the pbyData parameter to IAudioProcessingObject::Initialize. Specify <c>SID_AudioProcessingObjectRTQueue</c> as
	/// the identifier in the guidService parameter.
	/// </para>
	/// <para>For information on using the real-time work queue APIs, see rtworkq.h header.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/nn-audioengineextensionapo-iaudioprocessingobjectrtqueueservice
	[PInvokeData("audioengineextensionapo.h", MSDNShortId = "NN:audioengineextensionapo.IAudioProcessingObjectRTQueueService")]
	[ComImport, Guid("ACD65E2F-955B-4B57-B9BF-AC297BB752C9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioProcessingObjectRTQueueService
	{
		/// <summary>Gets the ID of a work queue that the APO can use to schedule tasks that need to run at a real-time priority.</summary>
		/// <returns>A DWORD containing the work queue ID.</returns>
		/// <remarks>The returned work queue ID is used with the real-time work queue APIs. For more information see rtworkq.h header.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/nf-audioengineextensionapo-iaudioprocessingobjectrtqueueservice-getrealtimeworkqueue
		// HRESULT GetRealTimeWorkQueue( DWORD *workQueueId );
		uint GetRealTimeWorkQueue();
	}

	/// <summary>
	/// <para>
	/// Implementing this interface also implies that the APO supports the APO Settings framework and allows the APO to subscribe for common
	/// audio related notifications from the Audio Engine
	/// </para>
	/// <para>
	/// This interface is also implemented by clients that require an APOInitSystemEffects3 structure to be passed into the
	/// IAudioProcessingObject::Initialize method. <c>APOInitSystemEffects3</c> adds the ability to obtain a service provider such as
	/// IAudioProcessingObjectLoggingService or IAudioProcessingObjectRTQueueService.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// On OS versions earlier than Windows Build 22000, the system will not pass an <c>APOInitSystemEffects3</c> into
	/// <c>IAudioProcessingObject::Initialize</c> even if the client implements <c>IAudioSystemEffects3</c>, but will instead pass an older
	/// version of the structure, APOInitSystemEffects2 or APOInitSystemEffects, into <c>Initialize</c>.
	/// </para>
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/nn-audioengineextensionapo-iaudiosystemeffects3
	[PInvokeData("audioengineextensionapo.h", MSDNShortId = "NN:audioengineextensionapo.IAudioSystemEffects3")]
	[ComImport, Guid("C58B31CD-FC6A-4255-BC1F-AD29BB0A4A17"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioSystemEffects3 : IAudioSystemEffects2
	{
		/// <summary>
		/// The GetEffectsList method is used for retrieving the list of audio processing effects that are currently active, and stores an
		/// event to be signaled if the list changes.
		/// </summary>
		/// <param name="ppEffectsIds">
		/// Pointer to the list of GUIDs that represent audio processing effects. The caller is responsible for freeing this memory by
		/// calling CoTaskMemFree.
		/// </param>
		/// <param name="pcEffects">A count of the audio processing effects in the list.</param>
		/// <param name="Event">The HANDLE of the event that will be signaled if the list changes.</param>
		/// <returns>
		/// The <c>GetEffectsList</c> method returns S_OK, If the method call is successful. If there are no effects in the list, the
		/// function still succeeds, <c>ppEffectsIds</c> returns a NULL pointer, and <c>pcEffects</c> returns a count of 0.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The APO signals the specified event when the list of audio processing effects changes from the list that was returned by
		/// <c>GetEffectsList</c>. The APO uses this event until either <c>GetEffectsList</c> is called again, or the APO is destroyed. The
		/// passed handle can be NULL, in which case the APO stops using any previous handle and does not signal an event.
		/// </para>
		/// <para>
		/// An APO implements this method to allow Windows to discover the current effects applied by the APO. The list of effects may depend
		/// on the processing mode that the APO initialized, and on any end user configuration. The processing mode is indicated by the
		/// <c>AudioProcessingMode</c> member of APOInitSystemEffects2.
		/// </para>
		/// <para>
		/// APOs should identify effects using GUIDs defined by Windows, such as AUDIO_EFFECT_TYPE_ACOUSTIC_ECHO_CANCELLATION. An APO should
		/// only define and return a custom GUID in rare cases where the type of effect is clearly different from the ones defined by Windows.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nf-audioenginebaseapo-iaudiosystemeffects2-geteffectslist
		// HRESULT GetEffectsList( [out] LPGUID *ppEffectsIds, [out] UINT *pcEffects, [in] HANDLE Event );
		[PreserveSig]
		new HRESULT GetEffectsList(out SafeCoTaskMemHandle ppEffectsIds, out uint pcEffects, [In] IntPtr Event);

		/// <summary>
		/// Implemented by System Effects Audio Processing Object (sAPO) audio effects to allow the caller to get the current list of effects.
		/// </summary>
		/// <param name="effects">
		/// Receives a pointer to an array of AUDIO_SYSTEMEFFECT_STATE structures representing the current list of audio effects.
		/// </param>
		/// <param name="numEffects">Receives the number of <c>AUDIO_EFFECT</c> structures returned in effects.</param>
		/// <param name="event">The HANDLE of the event that will be signaled if the list changes.</param>
		/// <returns>An HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/nf-audioengineextensionapo-iaudiosystemeffects3-getcontrollablesystemeffectslist
		// HRESULT GetControllableSystemEffectsList( AUDIO_SYSTEMEFFECT **effects, UINT *numEffects, HANDLE event );
		[PreserveSig]
		HRESULT GetControllableSystemEffectsList([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] out AUDIO_SYSTEMEFFECT[]? effects,
			out uint numEffects, [In, Optional] HEVENT @event);

		/// <summary>
		/// Implemented by System Effects Audio Processing Object (sAPO) audio effects to allow the caller to set the state of effects.
		/// </summary>
		/// <param name="effectId">The GUID identifier for an audio effect. Audio effect GUIDs are defined in ksmedia.h.</param>
		/// <param name="state">A value from the AUDIO_SYSTEMEFFECT_STATE enumerating specifying the state to set.</param>
		/// <returns>An HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/nf-audioengineextensionapo-iaudiosystemeffects3-setaudiosystemeffectstate
		// HRESULT SetAudioSystemEffectState( GUID effectId, AUDIO_SYSTEMEFFECT_STATE state );
		[PreserveSig]
		HRESULT SetAudioSystemEffectState(Guid effectId, AUDIO_SYSTEMEFFECT_STATE state);
	}

	/// <summary>Represents a notification for a change to an APO endpoint or system effects.</summary>
	/// <remarks>
	/// Register for the types of notifications you want to receive by implementing
	/// IAudioProcessingObjectNotifications::GetApoNotificationRegistrationInfo. Receive the registered notifications by implementing IAudioProcessingObjectNotifications::HandleNotification.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/ns-audioengineextensionapo-apo_notification typedef struct
	// APO_NOTIFICATION { APO_NOTIFICATION_TYPE type; union { AUDIO_ENDPOINT_VOLUME_CHANGE_NOTIFICATION audioEndpointVolumeChange;
	// AUDIO_ENDPOINT_PROPERTY_CHANGE_NOTIFICATION audioEndpointPropertyChange; AUDIO_SYSTEMEFFECTS_PROPERTY_CHANGE_NOTIFICATION
	// audioSystemEffectsPropertyChange; AUDIO_ENDPOINT_VOLUME_CHANGE_NOTIFICATION2 audioEndpointVolumeChange2; DEVICE_ORIENTATION_TYPE
	// deviceOrientation; AUDIO_MICROPHONE_BOOST_NOTIFICATION audioMicrophoneBoostChange; } DUMMYUNIONNAME; } APO_NOTIFICATION;
	[PInvokeData("audioengineextensionapo.h", MSDNShortId = "NS:audioengineextensionapo.APO_NOTIFICATION")]
	[StructLayout(LayoutKind.Explicit)]
	public struct APO_NOTIFICATION
	{
		/// <summary>A value from the APO_NOTIFICATION_TYPE enumeration specifying the type of change the notification represents.</summary>
		[FieldOffset(0)]
		public APO_NOTIFICATION_TYPE type;

		/// <summary>An AUDIO_ENDPOINT_VOLUME_CHANGE_NOTIFICATION representing a notification of a change to APO endpoint volume.</summary>
		[FieldOffset(8)]
		public AUDIO_ENDPOINT_VOLUME_CHANGE_NOTIFICATION audioEndpointVolumeChange;

		/// <summary>An AUDIO_ENDPOINT_PROPERTY_CHANGE_NOTIFICATION representing a notification of a change to an APO endpoint property.</summary>
		[FieldOffset(8)]
		public AUDIO_ENDPOINT_PROPERTY_CHANGE_NOTIFICATION audioEndpointPropertyChange;

		/// <summary>
		/// An AUDIO_SYSTEMEFFECTS_PROPERTY_CHANGE_NOTIFICATION representing a notification of a change to an APO system effect property.
		/// </summary>
		[FieldOffset(8)]
		public AUDIO_SYSTEMEFFECTS_PROPERTY_CHANGE_NOTIFICATION audioSystemEffectsPropertyChange;

		/// <summary>Used when type is APO_NOTIFICATION_TYPE_ENDPOINT_VOLUME2.</summary>
		[FieldOffset(8)]
		public AUDIO_ENDPOINT_VOLUME_CHANGE_NOTIFICATION2 audioEndpointVolumeChange2;

		/// <summary>Used when type is APO_NOTIFICATION_TYPE_DEVICE_ORIENTATION.</summary>
		[FieldOffset(8)]
		public DEVICE_ORIENTATION_TYPE deviceOrientation;

		/// <summary>Used when type is APO_NOTIFICATION_TYPE_MICROPHONE_BOOST.</summary>
		[FieldOffset(8)]
		public AUDIO_MICROPHONE_BOOST_NOTIFICATION audioMicrophoneBoostChange;
	}

	/// <summary>Specifies a requested APO notification.</summary>
	/// <remarks>
	/// Return this structure from an implementation ofIAudioProcessingObjectNotifications::GetApoNotificationRegistrationInfo to specify a
	/// requested APO notifications.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/ns-audioengineextensionapo-apo_notification_descriptor
	// typedef struct APO_NOTIFICATION_DESCRIPTOR { APO_NOTIFICATION_TYPE type; union { AUDIO_ENDPOINT_VOLUME_APO_NOTIFICATION_DESCRIPTOR
	// audioEndpointVolume; AUDIO_ENDPOINT_PROPERTY_CHANGE_APO_NOTIFICATION_DESCRIPTOR audioEndpointPropertyChange;
	// AUDIO_SYSTEMEFFECTS_PROPERTY_CHANGE_APO_NOTIFICATION_DESCRIPTOR audioSystemEffectsPropertyChange;
	// AUDIO_MICROPHONE_BOOST_APO_NOTIFICATION_DESCRIPTOR audioMicrophoneBoost; } DUMMYUNIONNAME; } APO_NOTIFICATION_DESCRIPTOR;
	[PInvokeData("audioengineextensionapo.h", MSDNShortId = "NS:audioengineextensionapo.APO_NOTIFICATION_DESCRIPTOR")]
	[StructLayout(LayoutKind.Explicit)]
	public struct APO_NOTIFICATION_DESCRIPTOR
	{
		/// <summary>A value from the APO_NOTIFICATION_TYPE enumeration</summary>
		[FieldOffset(0)]
		public APO_NOTIFICATION_TYPE type;

		/// <summary>An AUDIO_ENDPOINT_VOLUME_APO_NOTIFICATION_DESCRIPTOR specifying an endpoint volume change APO notification.</summary>
		[FieldOffset(8)]
		public AUDIO_ENDPOINT_VOLUME_APO_NOTIFICATION_DESCRIPTOR audioEndpointVolume;

		/// <summary>An AUDIO_ENDPOINT_PROPERTY_CHANGE_APO_NOTIFICATION_DESCRIPTOR specifying an endpoint property change APO notification.</summary>
		[FieldOffset(8)]
		public AUDIO_ENDPOINT_PROPERTY_CHANGE_APO_NOTIFICATION_DESCRIPTOR audioEndpointPropertyChange;

		/// <summary>
		/// An AUDIO_SYSTEMEFFECTS_PROPERTY_CHANGE_APO_NOTIFICATION_DESCRIPTOR specifying a system effects property change APO notification.
		/// </summary>
		[FieldOffset(8)]
		public AUDIO_SYSTEMEFFECTS_PROPERTY_CHANGE_APO_NOTIFICATION_DESCRIPTOR audioSystemEffectsPropertyChange;

		/// <summary>Used for microphone boost notifications.</summary>
		[FieldOffset(8)]
		public AUDIO_MICROPHONE_BOOST_APO_NOTIFICATION_DESCRIPTOR audioMicrophoneBoost;
	}

	/// <summary>
	/// Provides audio processing object (APO) initialization parameters, extending APOInitSystemEffects2 to add the ability to specify a
	/// service provider for logging.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/ns-audioengineextensionapo-apoinitsystemeffects3 typedef
	// struct APOInitSystemEffects3 { APOInitBaseStruct APOInit; IPropertyStore *pAPOEndpointProperties; IServiceProvider *pServiceProvider;
	// IMMDeviceCollection *pDeviceCollection; UINT nSoftwareIoDeviceInCollection; UINT nSoftwareIoConnectorIndex; GUID AudioProcessingMode;
	// BOOL InitializeForDiscoveryOnly; } APOInitSystemEffects3;
	[PInvokeData("audioengineextensionapo.h", MSDNShortId = "NS:audioengineextensionapo.APOInitSystemEffects3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct APOInitSystemEffects3
	{
		/// <summary>An APOInitBaseStruct structure.</summary>
		public APOInitBaseStruct APOInit;

		/// <summary>A pointer to an ../propsys/nn-propsys-ipropertystore object.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IPropertyStore pAPOEndpointProperties;

		/// <summary>An IServiceProvider interface.</summary>
		public IServiceProvider pServiceProvider;

		/// <summary>
		/// A pointer to an IMMDeviceCollection object. The last item in the pDeviceCollection is always the IMMDevice representing the audio endpoint.
		/// </summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IMMDeviceCollection pDeviceCollection;

		/// <summary>
		/// Specifies the <c>MMDevice</c> that implements the DeviceTopology that includes the software connector for which the APO is
		/// initializing. The <c>MMDevice</c> is contained in pDeviceCollection.
		/// </summary>
		public uint nSoftwareIoDeviceInCollection;

		/// <summary>Specifies the index of a <c>Software_IO</c> connector in the DeviceTopology.</summary>
		public uint nSoftwareIoConnectorIndex;

		/// <summary>Specifies the processing mode for the audio graph.</summary>
		public Guid AudioProcessingMode;

		/// <summary>Indicates whether the audio system is initializing the APO for effects discovery only.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool InitializeForDiscoveryOnly;
	}

	/// <summary>Specifies an endpoint property change APO notification.</summary>
	/// <remarks>
	/// Return an APO_NOTIFICATION_DESCRIPTOR containing this structure from an implementation
	/// ofIAudioProcessingObjectNotifications::GetApoNotificationRegistrationInfo to request endpoint property change APO notifications.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/ns-audioengineextensionapo-audio_endpoint_property_change_apo_notification_descriptor
	// typedef struct AUDIO_ENDPOINT_PROPERTY_CHANGE_APO_NOTIFICATION_DESCRIPTOR { IMMDevice *device; } AUDIO_ENDPOINT_PROPERTY_CHANGE_APO_NOTIFICATION_DESCRIPTOR;
	[PInvokeData("audioengineextensionapo.h", MSDNShortId = "NS:audioengineextensionapo.AUDIO_ENDPOINT_PROPERTY_CHANGE_APO_NOTIFICATION_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AUDIO_ENDPOINT_PROPERTY_CHANGE_APO_NOTIFICATION_DESCRIPTOR
	{
		/// <summary>An IMMDevice representing the audio endpoint associated with the notification.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IMMDevice device;
	}

	/// <summary>Represents a property change APO notification.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/ns-audioengineextensionapo-audio_endpoint_property_change_notification
	// typedef struct AUDIO_ENDPOINT_PROPERTY_CHANGE_NOTIFICATION { IMMDevice *endpoint; IPropertyStore *propertyStore; PROPERTYKEY
	// propertyKey; } AUDIO_ENDPOINT_PROPERTY_CHANGE_NOTIFICATION;
	[PInvokeData("audioengineextensionapo.h", MSDNShortId = "NS:audioengineextensionapo.AUDIO_ENDPOINT_PROPERTY_CHANGE_NOTIFICATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AUDIO_ENDPOINT_PROPERTY_CHANGE_NOTIFICATION
	{
		/// <summary>An IMMDevice representing the audio endpoint associated with the notification.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IMMDevice endpoint;

		/// <summary>An IPropertyStore representing the property store associated with the notification.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IPropertyStore propertyStore;

		/// <summary>A PROPERTYKEY structure identifying the property associated with the notification.</summary>
		public PROPERTYKEY propertyKey;
	}

	/// <summary>Specifies an endpoint volume APO notification.</summary>
	/// <remarks>
	/// Return an APO_NOTIFICATION_DESCRIPTOR containing this structure from an implementation
	/// ofIAudioProcessingObjectNotifications::GetApoNotificationRegistrationInfo to request endpoint volume change APO notifications.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/ns-audioengineextensionapo-audio_endpoint_volume_apo_notification_descriptor
	// typedef struct AUDIO_ENDPOINT_VOLUME_APO_NOTIFICATION_DESCRIPTOR { IMMDevice *device; } AUDIO_ENDPOINT_VOLUME_APO_NOTIFICATION_DESCRIPTOR;
	[PInvokeData("audioengineextensionapo.h", MSDNShortId = "NS:audioengineextensionapo.AUDIO_ENDPOINT_VOLUME_APO_NOTIFICATION_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AUDIO_ENDPOINT_VOLUME_APO_NOTIFICATION_DESCRIPTOR
	{
		/// <summary>The IMMDevice representing the audio endpoint associated with the notification request.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IMMDevice device;
	}

	/// <summary>Represents an audio endpoint volume change APO notification.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/ns-audioengineextensionapo-audio_endpoint_volume_change_notification
	// typedef struct AUDIO_ENDPOINT_VOLUME_CHANGE_NOTIFICATION { IMMDevice *endpoint; PAUDIO_VOLUME_NOTIFICATION_DATA volume; } AUDIO_ENDPOINT_VOLUME_CHANGE_NOTIFICATION;
	[PInvokeData("audioengineextensionapo.h", MSDNShortId = "NS:audioengineextensionapo.AUDIO_ENDPOINT_VOLUME_CHANGE_NOTIFICATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AUDIO_ENDPOINT_VOLUME_CHANGE_NOTIFICATION
	{
		/// <summary>An IMMDevice representing the audio endpoint associated with the notification.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IMMDevice endpoint;

		/// <summary>A pointer to a AUDIO_VOLUME_NOTIFICATION_DATA representing the new endpoint volume.</summary>
		public IntPtr /*AUDIO_VOLUME_NOTIFICATION_DATA*/ volume;
	}

	/// <summary>Undocumented</summary>
	[PInvokeData("audioengineextensionapo.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AUDIO_ENDPOINT_VOLUME_CHANGE_NOTIFICATION2
	{
		/// <summary>Undocumented</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IMMDevice endpoint;

		/// <summary>Undocumented</summary>
		public IntPtr /*PAUDIO_VOLUME_NOTIFICATION_DATA2*/ volume;
	}

	/// <summary>Used to request microphone boost notifications.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct AUDIO_MICROPHONE_BOOST_APO_NOTIFICATION_DESCRIPTOR
	{
		/// <summary>Undocumented</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IMMDevice device;
	}

	/// <summary>Undocumented</summary>
	[PInvokeData("audioengineextensionapo.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AUDIO_MICROPHONE_BOOST_NOTIFICATION
	{
		/// <summary>Device associated with mic boost notification.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IMMDevice endpoint;

		/// <summary>
		/// Context associated with the originator of the event. A client can use this method to keep track of control changes made by other
		/// processes and by the hardware. The functions IAudioVolumeLevel::SetLevel and IAudioMute::SetMute use the context. When this
		/// notification is recieved, a client can inspect the context Guid to discover whether it or another client is the source of the notification.
		/// </summary>
		public Guid eventContext;

		/// <summary>Indicates the presence of a "Microphone Boost" part (connector or subunit) of an audio capture device topology.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool microphoneBoostEnabled;

		/// <summary>The volume level in decibels.</summary>
		public float levelInDb;

		/// <summary>The minimum volume level in decibels.</summary>
		public float levelMinInDb;

		/// <summary>The maximum volume level in decibels.</summary>
		public float levelMaxInDb;

		/// <summary>The stepping value between consecutive volume levels in the range levelMinInDb to levelMaxInDb</summary>
		public float levelStepInDb;

		/// <summary>Indicates if the IAudioMute interface is supported by the "Microphone Boost" part of the audio capture device topology.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool muteSupported;

		/// <summary>The current state (enabled or disabled) of the mute control</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool mute;
	}

	/// <summary>Represents a System Effects Audio Processing Object (sAPO) audio effect.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/ns-audioengineextensionapo-audio_systemeffect typedef
	// struct AUDIO_SYSTEMEFFECT { GUID id; BOOL canSetState; AUDIO_SYSTEMEFFECT_STATE state; } AUDIO_SYSTEMEFFECT;
	[PInvokeData("audioengineextensionapo.h", MSDNShortId = "NS:audioengineextensionapo.AUDIO_SYSTEMEFFECT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AUDIO_SYSTEMEFFECT
	{
		/// <summary>The GUID identifier for an audio effect. Audio effect GUIDs are defined in ksmedia.h.</summary>
		public Guid id;

		/// <summary>A boolean value specifying whether the effect state can be modified.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool canSetState;

		/// <summary>A member of the AUDIO_SYSTEMEFFECT_STATE enumeration specifying the state of the audio effect.</summary>
		public AUDIO_SYSTEMEFFECT_STATE state;
	}

	/// <summary>Used to request audio system effects property change notifications on a specific endpoint and property context.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct AUDIO_SYSTEMEFFECTS_PROPERTY_CHANGE_APO_NOTIFICATION_DESCRIPTOR
	{
		/// <summary>Undocumented</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IMMDevice device;

		/// <summary>Undocumented</summary>
		public Guid propertyStoreContext;
	}

	/// <summary>Represents a system audio effect APO notification.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioengineextensionapo/ns-audioengineextensionapo-audio_systemeffects_property_change_notification
	// typedef struct AUDIO_SYSTEMEFFECTS_PROPERTY_CHANGE_NOTIFICATION { IMMDevice *endpoint; GUID propertyStoreContext;
	// AUDIO_SYSTEMEFFECTS_PROPERTYSTORE_TYPE propertyStoreType; IPropertyStore *propertyStore; PROPERTYKEY propertyKey; } AUDIO_SYSTEMEFFECTS_PROPERTY_CHANGE_NOTIFICATION;
	[PInvokeData("audioengineextensionapo.h", MSDNShortId = "NS:audioengineextensionapo.AUDIO_SYSTEMEFFECTS_PROPERTY_CHANGE_NOTIFICATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AUDIO_SYSTEMEFFECTS_PROPERTY_CHANGE_NOTIFICATION
	{
		/// <summary>An IMMDevice representing the audio endpoint associated with the notification.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IMMDevice endpoint;

		/// <summary>A GUID identifying the APO property store associated with the notification.</summary>
		public Guid propertyStoreContext;

		/// <summary>
		/// A value from the AUDIO_SYSTEMEFFECTS_PROPERTYSTORE_TYPE enumeration specifying the type of the property store associated with the notification.
		/// </summary>
		public AUDIO_SYSTEMEFFECTS_PROPERTYSTORE_TYPE propertyStoreType;

		/// <summary>An IPropertyStore representing the property store associated with the notification.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IPropertyStore propertyStore;

		/// <summary>A PROPERTYKEY structure identifying the property associated with the notification.</summary>
		public PROPERTYKEY propertyKey;
	}

	/// <summary>Undocumented</summary>
	[PInvokeData("audioengineextensionapo.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AUDIO_VOLUME_NOTIFICATION_DATA2
	{
		/// <summary>Undocumented</summary>
		public IntPtr /*PAUDIO_VOLUME_NOTIFICATION_DATA*/ notificationData;

		/// <summary>Specifies the current master volume level of the audio stream in dB.</summary>
		public float masterVolumeInDb;

		/// <summary>
		/// The minimum volume level of the endpoint in decibels. This value remains constant for the lifetime of audio device specified in AUDIO_ENDPOINT_VOLUME_APO_NOTIFICATION_DESCRIPTOR.
		/// </summary>
		public float volumeMinInDb;

		/// <summary>
		/// The maximum volume level of the endpoint in decibels. This value remains constant for the lifetime of the audio device specified
		/// in AUDIO_ENDPOINT_VOLUME_APO_NOTIFICATION_DESCRIPTOR.
		/// </summary>
		public float volumeMaxInDb;

		/// <summary>
		/// The volume increment in decibels. This increment remains constant for the lifetime the audio device specified in AUDIO_ENDPOINT_VOLUME_APO_NOTIFICATION_DESCRIPTOR.
		/// </summary>
		public float volumeIncrementInDb;

		/// <summary>
		/// Current step in the volume range. Is a value in the range from 0 to stepCount-1, where 0 represents the minimum volume level and
		/// stepCount–1 represents the maximum level. Audio applications can call the IAudioEndpointVolume::VolumeStepUp and
		/// IAudioEndpointVolume::VolumeStepDown methods to increase or decrease the volume level by one interval.
		/// </summary>
		public uint step;

		/// <summary>
		/// The number of steps in the volume range. This number remains constant for the lifetime of the audio device specified in AUDIO_ENDPOINT_VOLUME_APO_NOTIFICATION_DESCRIPTOR.
		/// </summary>
		public uint stepCount;

		/// <summary>
		/// The first element in an array of channel volumes in dB. This element contains the current volume level of channel 0 in the audio
		/// stream. If the audio stream contains more than one channel, the volume levels for the additional channels immediately follow the
		/// AUDIO_VOLUME_NOTIFICATION_DATA2 structure.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public float[] channelVolumesInDb;
	}
}