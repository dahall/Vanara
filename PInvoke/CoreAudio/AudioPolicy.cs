namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from Windows Core Audio Api.</summary>
public static partial class CoreAudio
{
	/// <summary>The reason that the audio session was disconnected.</summary>
	[PInvokeData("audiopolicy.h")]
	public enum AudioSessionDisconnectReason
	{
		/// <summary>The user removed the audio endpoint device.</summary>
		DisconnectReasonDeviceRemoval = 0,

		/// <summary>The Windows audio service has stopped.</summary>
		DisconnectReasonServerShutdown = (DisconnectReasonDeviceRemoval + 1),

		/// <summary>The stream format changed for the device that the audio session is connected to.</summary>
		DisconnectReasonFormatChanged = (DisconnectReasonServerShutdown + 1),

		/// <summary>The user logged off the Windows Terminal Services (WTS) session that the audio session was running in.</summary>
		DisconnectReasonSessionLogoff = (DisconnectReasonFormatChanged + 1),

		/// <summary>The WTS session that the audio session was running in was disconnected.</summary>
		DisconnectReasonSessionDisconnected = (DisconnectReasonSessionLogoff + 1),

		/// <summary>
		/// The (shared-mode) audio session was disconnected to make the audio endpoint device available for an exclusive-mode connection.
		/// </summary>
		DisconnectReasonExclusiveModeOverride = (DisconnectReasonSessionDisconnected + 1)
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioSessionControl</c> interface enables a client to configure the control parameters for an audio session and to
	/// monitor events in the session. The IAudioClient::Initialize method initializes a stream object and assigns the stream to an
	/// audio session. The client obtains a reference to the <c>IAudioSessionControl</c> interface on a stream object by calling the
	/// IAudioClient::GetService method with parameter riid set to <c>REFIID</c> IID_IAudioSessionControl.
	/// </para>
	/// <para>
	/// Alternatively, a client can obtain the <c>IAudioSessionControl</c> interface of an existing session without having to first
	/// create a stream object and add the stream to the session. Instead, the client calls the
	/// IAudioSessionManager::GetAudioSessionControl method with parameter AudioSessionGuid set to the session GUID.
	/// </para>
	/// <para>
	/// The client can register to receive notification from the session manager when clients change session parameters through the
	/// methods in the <c>IAudioSessionControl</c> interface.
	/// </para>
	/// <para>
	/// When releasing an <c>IAudioSessionControl</c> interface instance, the client must call the interface's <c>Release</c> method
	/// from the same thread as the call to <c>IAudioClient::GetService</c> that created the object.
	/// </para>
	/// <para>
	/// The <c>IAudioSessionControl</c> interface controls an audio session. An audio session is a collection of shared-mode streams.
	/// This interface does not work with exclusive-mode streams.
	/// </para>
	/// <para>For a code example that uses the <c>IAudioSessionControl</c> interface, see Audio Events for Legacy Audio Applications.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nn-audiopolicy-iaudiosessioncontrol
	[PInvokeData("audiopolicy.h", MSDNShortId = "4446140e-2e61-40ed-b0f9-4c1b90e7c2de")]
	[ComImport, Guid("F4B1A599-7266-4319-A8CA-E70ACB11E8CD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioSessionControl
	{
		/// <summary>The <c>GetState</c> method retrieves the current state of the audio session.</summary>
		/// <returns>
		/// <para>A variable into which the method writes the current session state.</para>
		/// <para>
		/// These values indicate that the session state is active, inactive, or expired, respectively. For more information, see Remarks.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method indicates whether the state of the session is active, inactive, or expired. The state is active if the session
		/// has one or more streams that are running. The state changes from active to inactive when the last running stream in the
		/// session stops. The session state changes to expired when the client destroys the last stream in the session by releasing all
		/// references to the stream object.
		/// </para>
		/// <para>
		/// The Sndvol program displays volume and mute controls for sessions that are in the active and inactive states. When a session
		/// expires, Sndvol stops displaying the controls for that session. If a session has previously expired, but the session state
		/// changes to active (because a stream in the session begins running) or inactive (because a client assigns a new stream to the
		/// session), Sndvol resumes displaying the controls for the session.
		/// </para>
		/// <para>
		/// The client creates a stream by calling the IAudioClient::Initialize method. At the time that it creates a stream, the client
		/// assigns the stream to a session. A session begins when a client assigns the first stream to the session. Initially, the
		/// session is in the inactive state. The session state changes to active when the first stream in the session begins running.
		/// The session terminates when a client releases the final reference to the last remaining stream object in the session.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-getstate HRESULT GetState(
		// AudioSessionState *pRetVal );
		AudioSessionState GetState();

		/// <summary>The <c>GetDisplayName</c> method retrieves the display name for the audio session.</summary>
		/// <returns>A string that contains the display name.</returns>
		/// <remarks>
		/// If the client has not called IAudioSessionControl::SetDisplayName to set the display name, the string will be empty. Rather
		/// than display an empty name string, the Sndvol program uses a default, automatically generated name to label the volume
		/// control for the audio session.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-getdisplayname HRESULT
		// GetDisplayName( LPWSTR *pRetVal );
		SafeCoTaskMemString GetDisplayName();

		/// <summary>The <c>SetDisplayName</c> method assigns a display name to the current session.</summary>
		/// <param name="Value">Pointer to a null-terminated, wide-character string that contains the display name for the session.</param>
		/// <param name="EventContext">
		/// Pointer to the event-context GUID. If a call to this method generates a name-change event, the session manager sends
		/// notifications to all clients that have registered IAudioSessionEvents interfaces with the session manager. The session
		/// manager includes the EventContext pointer value with each notification. Upon receiving a notification, a client can
		/// determine whether it or another client is the source of the event by inspecting the EventContext value. This scheme depends
		/// on the client selecting a value for this parameter that is unique among all clients in the session. If the caller supplies a
		/// <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// <para>
		/// In Windows Vista, the system-supplied program, Sndvol.exe, uses the display name to label the volume control for the
		/// session. If the client does not call <c>SetDisplayName</c> to assign a display name to the session, the Sndvol program uses
		/// a default, automatically generated name to label the session. The default name incorporates information such as the window
		/// title or version resource of the audio application.
		/// </para>
		/// <para>
		/// If a client has more than one active session, client-specified display names are especially helpful for distinguishing among
		/// the volume controls for the various sessions.
		/// </para>
		/// <para>
		/// In the case of a cross-process session, the session has no identifying information, such as an application name or process
		/// ID, from which to generate a default display name. Thus, the client must call <c>SetDisplayName</c> to avoid displaying a
		/// meaningless default display name.
		/// </para>
		/// <para>
		/// The display name does not persist beyond the lifetime of the IAudioSessionControl object. Thus, after all references to the
		/// object are released, a subsequently created version of the object (with the same application, same session GUID, and same
		/// endpoint device) will once again have a default, automatically generated display name until the client calls <c>SetDisplayName</c>.
		/// </para>
		/// <para>The client can retrieve the display name for the session by calling the IAudioSessionControl::GetDisplayName method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-setdisplayname HRESULT
		// SetDisplayName( LPCWSTR Value, LPCGUID EventContext );
		void SetDisplayName([MarshalAs(UnmanagedType.LPWStr)] string Value, in Guid EventContext);

		/// <summary>The <c>GetIconPath</c> method retrieves the path for the display icon for the audio session.</summary>
		/// <returns>
		/// Pointer to a pointer variable into which the method writes the address of a null-terminated, wide-character string that
		/// specifies the fully qualified path of an .ico, .dll, or .exe file that contains the icon. The method allocates the storage
		/// for the string. The caller is responsible for freeing the storage, when it is no longer needed, by calling the CoTaskMemFree
		/// function. For information about icon paths and <c>CoTaskMemFree</c>, see the Windows SDK documentation.
		/// </returns>
		/// <remarks>
		/// If a client has not called IAudioSessionControl::SetIconPath to set the display icon, the string will be empty. If no
		/// client-specified icon is available, the Sndvol program uses the icon from the client's application window to label the
		/// volume control for the audio session.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-geticonpath HRESULT
		// GetIconPath( LPWSTR *pRetVal );
		SafeCoTaskMemString GetIconPath();

		/// <summary>The <c>SetIconPath</c> method assigns a display icon to the current session.</summary>
		/// <param name="Value">
		/// Pointer to a null-terminated, wide-character string that specifies the path and file name of an .ico, .dll, or .exe file
		/// that contains the icon. For information about icon paths, see the Windows SDK documentation.
		/// </param>
		/// <param name="EventContext">
		/// Pointer to the event-context GUID. If a call to this method generates an icon-change event, the session manager sends
		/// notifications to all clients that have registered IAudioSessionEvents interfaces with the session manager. The session
		/// manager includes the EventContext pointer value with each notification. Upon receiving a notification, a client can
		/// determine whether it or another client is the source of the event by inspecting the EventContext value. This scheme depends
		/// on the client selecting a value for this parameter that is unique among all clients in the session. If the caller supplies a
		/// <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// <para>
		/// In Windows Vista, the system-supplied program, Sndvol.exe, uses the display icon (along with the display name) to label the
		/// volume control for the session. If the client does not call <c>SetIconPath</c> to assign an icon to the session, the Sndvol
		/// program uses the icon from the application window as the default icon for the session.
		/// </para>
		/// <para>
		/// In the case of a cross-process session, the session is not associated with a single application process. Thus, Sndvol has no
		/// application-specific icon to use by default, and the client must call <c>SetIconPath</c> to avoid displaying a meaningless icon.
		/// </para>
		/// <para>
		/// The display icon does not persist beyond the lifetime of the IAudioSessionControl object. Thus, after all references to the
		/// object are released, a subsequently created version of the object (with the same application, same session GUID, and same
		/// endpoint device) will once again have a default icon until the client calls <c>SetIconPath</c>.
		/// </para>
		/// <para>The client can retrieve the display icon for the session by calling the IAudioSessionControl::GetIconPath method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-seticonpath HRESULT
		// SetIconPath( LPCWSTR Value, LPCGUID EventContext );
		void SetIconPath([MarshalAs(UnmanagedType.LPWStr)] string Value, in Guid EventContext);

		/// <summary>The <c>GetGroupingParam</c> method retrieves the grouping parameter of the audio session.</summary>
		/// <returns>
		/// Output pointer for the grouping-parameter GUID. This parameter must be a valid, non- <c>NULL</c> pointer to a
		/// caller-allocated GUID variable. The method writes the grouping parameter into this variable.
		/// </returns>
		/// <remarks>
		/// <para>
		/// All of the audio sessions that have the same grouping parameter value are under the control of the same volume-level slider
		/// in the system volume-control program, Sndvol. For more information, see Grouping Parameters.
		/// </para>
		/// <para>A client can call the IAudioSessionControl::SetGroupingParam method to change the grouping parameter of a session.</para>
		/// <para>
		/// If a client has never called SetGroupingParam to assign a grouping parameter to an audio session, the session's grouping
		/// parameter value is GUID_NULL by default and a call to <c>GetGroupingParam</c> retrieves this value. A grouping parameter
		/// value of GUID_NULL indicates that the session does not belong to any grouping. In that case, the session has its own
		/// volume-level slider in the Sndvol program.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-getgroupingparam HRESULT
		// GetGroupingParam( GUID *pRetVal );
		Guid GetGroupingParam();

		/// <summary>The <c>SetGroupingParam</c> method assigns a session to a grouping of sessions.</summary>
		/// <param name="Override">
		/// The new grouping parameter. This parameter must be a valid, non- <c>NULL</c> pointer to a grouping-parameter GUID. For more
		/// information, see Remarks.
		/// </param>
		/// <param name="EventContext">
		/// Pointer to the event-context GUID. If a call to this method generates a grouping-change event, the session manager sends
		/// notifications to all clients that have registered IAudioSessionEvents interfaces with the session manager. The session
		/// manager includes the EventContext pointer value with each notification. Upon receiving a notification, a client can
		/// determine whether it or another client is the source of the event by inspecting the EventContext value. This scheme depends
		/// on the client selecting a value for this parameter that is unique among all clients in the session. If the caller supplies a
		/// <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// <para>
		/// A client calls this method to change the grouping parameter of a session. All of the audio sessions that have the same
		/// grouping parameter value are under the control of the same volume-level slider in the system volume-control program, Sndvol.
		/// For more information, see Grouping Parameters.
		/// </para>
		/// <para>
		/// The client can get the current grouping parameter for the session by calling the IAudioSessionControl::GetGroupingParam method.
		/// </para>
		/// <para>
		/// If a client has never called <c>SetGroupingParam</c> to assign a grouping parameter to a session, the session does not
		/// belong to any grouping. A session that does not belong to any grouping has its own, dedicated volume-level slider in the
		/// Sndvol program.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-setgroupingparam HRESULT
		// SetGroupingParam( LPCGUID Override, LPCGUID EventContext );
		void SetGroupingParam(in Guid Override, in Guid EventContext);

		/// <summary>
		/// The <c>RegisterAudioSessionNotification</c> method registers the client to receive notifications of session events,
		/// including changes in the stream state.
		/// </summary>
		/// <param name="NewNotifications">
		/// Pointer to a client-implemented IAudioSessionEvents interface. If the method succeeds, it calls the AddRef method on the
		/// client's <c>IAudioSessionEvents</c> interface.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method passes a client-implemented IAudioSessionEvents interface to the session manager. Following a successful call to
		/// this method, the session manager calls the methods in the <c>IAudioSessionEvents</c> interface to notify the client of
		/// various session events. Through these methods, the client receives notifications of the following session-related events:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Display name changes</term>
		/// </item>
		/// <item>
		/// <term>Volume level changes</term>
		/// </item>
		/// <item>
		/// <term>Session state changes (inactive to active, or active to inactive)</term>
		/// </item>
		/// <item>
		/// <term>Grouping parameter changes</term>
		/// </item>
		/// <item>
		/// <term>
		/// Disconnection of the client from the session (caused by the user removing the audio endpoint device, shutting down the
		/// session manager, or changing the stream format)
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// When notifications are no longer needed, the client can call the IAudioSessionControl::UnregisterAudioSessionNotification
		/// method to terminate the notifications.
		/// </para>
		/// <para>
		/// Before the client releases its final reference to the IAudioSessionEvents interface, it should call
		/// UnregisterAudioSessionNotification to unregister the interface. Otherwise, the application leaks the resources held by the
		/// <c>IAudioSessionEvents</c> and IAudioSessionControl objects. Note that <c>RegisterAudioSessionNotification</c> calls the
		/// client's IAudioSessionEvents::AddRef method, and <c>UnregisterAudioSessionNotification</c> calls the
		/// IAudioSessionEvents::Release method. If the client errs by releasing its reference to the <c>IAudioSessionEvents</c>
		/// interface before calling <c>UnregisterAudioSessionNotification</c>, the session manager never releases its reference to the
		/// <c>IAudioSessionEvents</c> interface. For example, a poorly designed <c>IAudioSessionEvents</c> implementation might call
		/// <c>UnregisterAudioSessionNotification</c> from the destructor for the <c>IAudioSessionEvents</c> object. In this case, the
		/// client will not call <c>UnregisterAudioSessionNotification</c> until the session manager releases its reference to the
		/// <c>IAudioSessionEvents</c> interface, and the session manager will not release its reference to the
		/// <c>IAudioSessionEvents</c> interface until the client calls <c>UnregisterAudioSessionNotification</c>. For more information
		/// about the <c>AddRef</c> and <c>Release</c> methods, see the discussion of the IUnknown interface in the Windows SDK documentation.
		/// </para>
		/// <para>
		/// In addition, the client should call UnregisterAudioSessionNotification before releasing all of its references to the
		/// IAudioSessionControl and IAudioSessionManager objects. Unless the client retains a reference to at least one of these two
		/// objects, the session manager leaks the storage that it allocated to hold the registration information. After registering a
		/// notification interface, the client continues to receive notifications for only as long as at least one of these two objects exists.
		/// </para>
		/// <para>
		/// For a code example that calls the <c>RegisterAudioSessionNotification</c> method, see Audio Events for Legacy Audio Applications.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-registeraudiosessionnotification
		// HRESULT RegisterAudioSessionNotification( IAudioSessionEvents *NewNotifications );
		void RegisterAudioSessionNotification([In] IAudioSessionEvents NewNotifications);

		/// <summary>
		/// The <c>UnregisterAudioSessionNotification</c> method deletes a previous registration by the client to receive notifications.
		/// </summary>
		/// <param name="NewNotifications">
		/// Pointer to a client-implemented IAudioSessionEvents interface. The client passed this same interface pointer to the session
		/// manager in a previous call to the IAudioSessionControl::RegisterAudioSessionNotification method. If the
		/// <c>UnregisterAudioSessionNotification</c> method succeeds, it calls the Release method on the client's
		/// <c>IAudioSessionEvents</c> interface.
		/// </param>
		/// <remarks>
		/// <para>
		/// The client calls this method when it no longer needs to receive notifications. The <c>UnregisterAudioSessionNotification</c>
		/// method removes the registration of an IAudioSessionEvents interface that the client previously registered with the session
		/// manager by calling the IAudioSessionControl::RegisterAudioSessionNotification method.
		/// </para>
		/// <para>
		/// Before the client releases its final reference to the IAudioSessionEvents interface, it should call
		/// <c>UnregisterAudioSessionNotification</c> to unregister the interface. Otherwise, the application leaks the resources held
		/// by the <c>IAudioSessionEvents</c> and IAudioSessionControl objects. Note that RegisterAudioSessionNotification calls the
		/// client's IAudioSessionEvents::AddRef method, and <c>UnregisterAudioSessionNotification</c> calls the
		/// IAudioSessionEvents::Release method. If the client errs by releasing its reference to the <c>IAudioSessionEvents</c>
		/// interface before calling <c>UnregisterAudioSessionNotification</c>, the session manager never releases its reference to the
		/// <c>IAudioSessionEvents</c> interface. For example, a poorly designed <c>IAudioSessionEvents</c> implementation might call
		/// <c>UnregisterAudioSessionNotification</c> from the destructor for the <c>IAudioSessionEvents</c> object. In this case, the
		/// client will not call <c>UnregisterAudioSessionNotification</c> until the session manager releases its reference to the
		/// <c>IAudioSessionEvents</c> interface, and the session manager will not release its reference to the
		/// <c>IAudioSessionEvents</c> interface until the client calls <c>UnregisterAudioSessionNotification</c>. For more information
		/// about the <c>AddRef</c> and <c>Release</c> methods, see the discussion of the IUnknown interface in the Windows SDK documentation.
		/// </para>
		/// <para>
		/// For a code example that calls the <c>UnregisterAudioSessionNotification</c> method, see Audio Events for Legacy Audio Applications.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-unregisteraudiosessionnotification
		// HRESULT UnregisterAudioSessionNotification( IAudioSessionEvents *NewNotifications );
		void UnregisterAudioSessionNotification([In] IAudioSessionEvents NewNotifications);
	}

	/// <summary>
	/// <para>The <c>IAudioSessionControl2</c> interface can be used by a client to get information about the audio session.</para>
	/// <para>
	/// To get a reference to the <c>IAudioSessionControl2</c> interface, the application must call
	/// <c>IAudioSessionControl::QueryInterface</c> to request the interface pointer from the stream object's IAudioSessionControl
	/// interface. There are two ways an application can get a pointer to the <c>IAudioSessionControl</c> interface:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// By calling IAudioClient::GetService on the audio client after opening a stream on the device. The audio client opens a stream
	/// for rendering or capturing, and associates it with an audio session by calling IAudioClient::Initialize.
	/// </term>
	/// </item>
	/// <item>
	/// <term>By calling IAudioSessionManager::GetAudioSessionControl for an existing audio session without opening the stream.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When the application wants to release the <c>IAudioSessionControl2</c> interface instance, the application must call the
	/// interface's <c>Release</c> method from the same thread as the call to IAudioClient::GetService that created the object.
	/// </para>
	/// <para>
	/// The application thread that uses this interface must be initialized for COM. For more information about COM initialization, see
	/// the description of the <c>CoInitializeEx</c> function in the Windows SDK documentation.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// This interface supports custom implementations for stream attenuation or ducking, a new feature in Windows 7. An application
	/// playing a media stream can make it behave differently when a new communication stream is opened on the default communication
	/// device. For example, the original media stream can be paused while the new communication stream is open. For more information
	/// about this feature, see Default Ducking Experience.
	/// </para>
	/// <para>An application can use this interface to perform the following tasks:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Specify that it wants to opt out of the default stream attenuation experience provided by the system.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Get the audio session identifier that is associated with the stream. The identifier is required during the notification
	/// registration. The application can register itself to receive ducking notifications from the system.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Check whether the stream associated with the audio session is a system sound.</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following example code shows how to get a reference to the <c>IAudioSessionControl2</c> interface and call its methods to
	/// determine whether the stream associated with the audio session is a system sound.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nn-audiopolicy-iaudiosessioncontrol2
	[PInvokeData("audiopolicy.h", MSDNShortId = "3bb65edf-103c-4eeb-82b4-7c571cddfcf3")]
	[ComImport, Guid("bfb7ff88-7239-4fc9-8fa2-07c950be9c6d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioSessionControl2 : IAudioSessionControl
	{
		/// <summary>The <c>GetState</c> method retrieves the current state of the audio session.</summary>
		/// <returns>
		/// <para>A variable into which the method writes the current session state.</para>
		/// <para>
		/// These values indicate that the session state is active, inactive, or expired, respectively. For more information, see Remarks.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method indicates whether the state of the session is active, inactive, or expired. The state is active if the session
		/// has one or more streams that are running. The state changes from active to inactive when the last running stream in the
		/// session stops. The session state changes to expired when the client destroys the last stream in the session by releasing all
		/// references to the stream object.
		/// </para>
		/// <para>
		/// The Sndvol program displays volume and mute controls for sessions that are in the active and inactive states. When a session
		/// expires, Sndvol stops displaying the controls for that session. If a session has previously expired, but the session state
		/// changes to active (because a stream in the session begins running) or inactive (because a client assigns a new stream to the
		/// session), Sndvol resumes displaying the controls for the session.
		/// </para>
		/// <para>
		/// The client creates a stream by calling the IAudioClient::Initialize method. At the time that it creates a stream, the client
		/// assigns the stream to a session. A session begins when a client assigns the first stream to the session. Initially, the
		/// session is in the inactive state. The session state changes to active when the first stream in the session begins running.
		/// The session terminates when a client releases the final reference to the last remaining stream object in the session.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-getstate HRESULT GetState(
		// AudioSessionState *pRetVal );
		new AudioSessionState GetState();

		/// <summary>The <c>GetDisplayName</c> method retrieves the display name for the audio session.</summary>
		/// <returns>A string that contains the display name.</returns>
		/// <remarks>
		/// If the client has not called IAudioSessionControl::SetDisplayName to set the display name, the string will be empty. Rather
		/// than display an empty name string, the Sndvol program uses a default, automatically generated name to label the volume
		/// control for the audio session.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-getdisplayname HRESULT
		// GetDisplayName( LPWSTR *pRetVal );
		new SafeCoTaskMemString GetDisplayName();

		/// <summary>The <c>SetDisplayName</c> method assigns a display name to the current session.</summary>
		/// <param name="Value">Pointer to a null-terminated, wide-character string that contains the display name for the session.</param>
		/// <param name="EventContext">
		/// Pointer to the event-context GUID. If a call to this method generates a name-change event, the session manager sends
		/// notifications to all clients that have registered IAudioSessionEvents interfaces with the session manager. The session
		/// manager includes the EventContext pointer value with each notification. Upon receiving a notification, a client can
		/// determine whether it or another client is the source of the event by inspecting the EventContext value. This scheme depends
		/// on the client selecting a value for this parameter that is unique among all clients in the session. If the caller supplies a
		/// <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// <para>
		/// In Windows Vista, the system-supplied program, Sndvol.exe, uses the display name to label the volume control for the
		/// session. If the client does not call <c>SetDisplayName</c> to assign a display name to the session, the Sndvol program uses
		/// a default, automatically generated name to label the session. The default name incorporates information such as the window
		/// title or version resource of the audio application.
		/// </para>
		/// <para>
		/// If a client has more than one active session, client-specified display names are especially helpful for distinguishing among
		/// the volume controls for the various sessions.
		/// </para>
		/// <para>
		/// In the case of a cross-process session, the session has no identifying information, such as an application name or process
		/// ID, from which to generate a default display name. Thus, the client must call <c>SetDisplayName</c> to avoid displaying a
		/// meaningless default display name.
		/// </para>
		/// <para>
		/// The display name does not persist beyond the lifetime of the IAudioSessionControl object. Thus, after all references to the
		/// object are released, a subsequently created version of the object (with the same application, same session GUID, and same
		/// endpoint device) will once again have a default, automatically generated display name until the client calls <c>SetDisplayName</c>.
		/// </para>
		/// <para>The client can retrieve the display name for the session by calling the IAudioSessionControl::GetDisplayName method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-setdisplayname HRESULT
		// SetDisplayName( LPCWSTR Value, LPCGUID EventContext );
		new void SetDisplayName([MarshalAs(UnmanagedType.LPWStr)] string Value, in Guid EventContext);

		/// <summary>The <c>GetIconPath</c> method retrieves the path for the display icon for the audio session.</summary>
		/// <returns>
		/// Pointer to a pointer variable into which the method writes the address of a null-terminated, wide-character string that
		/// specifies the fully qualified path of an .ico, .dll, or .exe file that contains the icon. The method allocates the storage
		/// for the string. The caller is responsible for freeing the storage, when it is no longer needed, by calling the CoTaskMemFree
		/// function. For information about icon paths and <c>CoTaskMemFree</c>, see the Windows SDK documentation.
		/// </returns>
		/// <remarks>
		/// If a client has not called IAudioSessionControl::SetIconPath to set the display icon, the string will be empty. If no
		/// client-specified icon is available, the Sndvol program uses the icon from the client's application window to label the
		/// volume control for the audio session.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-geticonpath HRESULT
		// GetIconPath( LPWSTR *pRetVal );
		new SafeCoTaskMemString GetIconPath();

		/// <summary>The <c>SetIconPath</c> method assigns a display icon to the current session.</summary>
		/// <param name="Value">
		/// Pointer to a null-terminated, wide-character string that specifies the path and file name of an .ico, .dll, or .exe file
		/// that contains the icon. For information about icon paths, see the Windows SDK documentation.
		/// </param>
		/// <param name="EventContext">
		/// Pointer to the event-context GUID. If a call to this method generates an icon-change event, the session manager sends
		/// notifications to all clients that have registered IAudioSessionEvents interfaces with the session manager. The session
		/// manager includes the EventContext pointer value with each notification. Upon receiving a notification, a client can
		/// determine whether it or another client is the source of the event by inspecting the EventContext value. This scheme depends
		/// on the client selecting a value for this parameter that is unique among all clients in the session. If the caller supplies a
		/// <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// <para>
		/// In Windows Vista, the system-supplied program, Sndvol.exe, uses the display icon (along with the display name) to label the
		/// volume control for the session. If the client does not call <c>SetIconPath</c> to assign an icon to the session, the Sndvol
		/// program uses the icon from the application window as the default icon for the session.
		/// </para>
		/// <para>
		/// In the case of a cross-process session, the session is not associated with a single application process. Thus, Sndvol has no
		/// application-specific icon to use by default, and the client must call <c>SetIconPath</c> to avoid displaying a meaningless icon.
		/// </para>
		/// <para>
		/// The display icon does not persist beyond the lifetime of the IAudioSessionControl object. Thus, after all references to the
		/// object are released, a subsequently created version of the object (with the same application, same session GUID, and same
		/// endpoint device) will once again have a default icon until the client calls <c>SetIconPath</c>.
		/// </para>
		/// <para>The client can retrieve the display icon for the session by calling the IAudioSessionControl::GetIconPath method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-seticonpath HRESULT
		// SetIconPath( LPCWSTR Value, LPCGUID EventContext );
		new void SetIconPath([MarshalAs(UnmanagedType.LPWStr)] string Value, in Guid EventContext);

		/// <summary>The <c>GetGroupingParam</c> method retrieves the grouping parameter of the audio session.</summary>
		/// <returns>
		/// Output pointer for the grouping-parameter GUID. This parameter must be a valid, non- <c>NULL</c> pointer to a
		/// caller-allocated GUID variable. The method writes the grouping parameter into this variable.
		/// </returns>
		/// <remarks>
		/// <para>
		/// All of the audio sessions that have the same grouping parameter value are under the control of the same volume-level slider
		/// in the system volume-control program, Sndvol. For more information, see Grouping Parameters.
		/// </para>
		/// <para>A client can call the IAudioSessionControl::SetGroupingParam method to change the grouping parameter of a session.</para>
		/// <para>
		/// If a client has never called SetGroupingParam to assign a grouping parameter to an audio session, the session's grouping
		/// parameter value is GUID_NULL by default and a call to <c>GetGroupingParam</c> retrieves this value. A grouping parameter
		/// value of GUID_NULL indicates that the session does not belong to any grouping. In that case, the session has its own
		/// volume-level slider in the Sndvol program.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-getgroupingparam HRESULT
		// GetGroupingParam( GUID *pRetVal );
		new Guid GetGroupingParam();

		/// <summary>The <c>SetGroupingParam</c> method assigns a session to a grouping of sessions.</summary>
		/// <param name="Override">
		/// The new grouping parameter. This parameter must be a valid, non- <c>NULL</c> pointer to a grouping-parameter GUID. For more
		/// information, see Remarks.
		/// </param>
		/// <param name="EventContext">
		/// Pointer to the event-context GUID. If a call to this method generates a grouping-change event, the session manager sends
		/// notifications to all clients that have registered IAudioSessionEvents interfaces with the session manager. The session
		/// manager includes the EventContext pointer value with each notification. Upon receiving a notification, a client can
		/// determine whether it or another client is the source of the event by inspecting the EventContext value. This scheme depends
		/// on the client selecting a value for this parameter that is unique among all clients in the session. If the caller supplies a
		/// <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// <para>
		/// A client calls this method to change the grouping parameter of a session. All of the audio sessions that have the same
		/// grouping parameter value are under the control of the same volume-level slider in the system volume-control program, Sndvol.
		/// For more information, see Grouping Parameters.
		/// </para>
		/// <para>
		/// The client can get the current grouping parameter for the session by calling the IAudioSessionControl::GetGroupingParam method.
		/// </para>
		/// <para>
		/// If a client has never called <c>SetGroupingParam</c> to assign a grouping parameter to a session, the session does not
		/// belong to any grouping. A session that does not belong to any grouping has its own, dedicated volume-level slider in the
		/// Sndvol program.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-setgroupingparam HRESULT
		// SetGroupingParam( LPCGUID Override, LPCGUID EventContext );
		new void SetGroupingParam(in Guid Override, in Guid EventContext);

		/// <summary>
		/// The <c>RegisterAudioSessionNotification</c> method registers the client to receive notifications of session events,
		/// including changes in the stream state.
		/// </summary>
		/// <param name="NewNotifications">
		/// Pointer to a client-implemented IAudioSessionEvents interface. If the method succeeds, it calls the AddRef method on the
		/// client's <c>IAudioSessionEvents</c> interface.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method passes a client-implemented IAudioSessionEvents interface to the session manager. Following a successful call to
		/// this method, the session manager calls the methods in the <c>IAudioSessionEvents</c> interface to notify the client of
		/// various session events. Through these methods, the client receives notifications of the following session-related events:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Display name changes</term>
		/// </item>
		/// <item>
		/// <term>Volume level changes</term>
		/// </item>
		/// <item>
		/// <term>Session state changes (inactive to active, or active to inactive)</term>
		/// </item>
		/// <item>
		/// <term>Grouping parameter changes</term>
		/// </item>
		/// <item>
		/// <term>
		/// Disconnection of the client from the session (caused by the user removing the audio endpoint device, shutting down the
		/// session manager, or changing the stream format)
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// When notifications are no longer needed, the client can call the IAudioSessionControl::UnregisterAudioSessionNotification
		/// method to terminate the notifications.
		/// </para>
		/// <para>
		/// Before the client releases its final reference to the IAudioSessionEvents interface, it should call
		/// UnregisterAudioSessionNotification to unregister the interface. Otherwise, the application leaks the resources held by the
		/// <c>IAudioSessionEvents</c> and IAudioSessionControl objects. Note that <c>RegisterAudioSessionNotification</c> calls the
		/// client's IAudioSessionEvents::AddRef method, and <c>UnregisterAudioSessionNotification</c> calls the
		/// IAudioSessionEvents::Release method. If the client errs by releasing its reference to the <c>IAudioSessionEvents</c>
		/// interface before calling <c>UnregisterAudioSessionNotification</c>, the session manager never releases its reference to the
		/// <c>IAudioSessionEvents</c> interface. For example, a poorly designed <c>IAudioSessionEvents</c> implementation might call
		/// <c>UnregisterAudioSessionNotification</c> from the destructor for the <c>IAudioSessionEvents</c> object. In this case, the
		/// client will not call <c>UnregisterAudioSessionNotification</c> until the session manager releases its reference to the
		/// <c>IAudioSessionEvents</c> interface, and the session manager will not release its reference to the
		/// <c>IAudioSessionEvents</c> interface until the client calls <c>UnregisterAudioSessionNotification</c>. For more information
		/// about the <c>AddRef</c> and <c>Release</c> methods, see the discussion of the IUnknown interface in the Windows SDK documentation.
		/// </para>
		/// <para>
		/// In addition, the client should call UnregisterAudioSessionNotification before releasing all of its references to the
		/// IAudioSessionControl and IAudioSessionManager objects. Unless the client retains a reference to at least one of these two
		/// objects, the session manager leaks the storage that it allocated to hold the registration information. After registering a
		/// notification interface, the client continues to receive notifications for only as long as at least one of these two objects exists.
		/// </para>
		/// <para>
		/// For a code example that calls the <c>RegisterAudioSessionNotification</c> method, see Audio Events for Legacy Audio Applications.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-registeraudiosessionnotification
		// HRESULT RegisterAudioSessionNotification( IAudioSessionEvents *NewNotifications );
		new void RegisterAudioSessionNotification([In] IAudioSessionEvents NewNotifications);

		/// <summary>
		/// The <c>UnregisterAudioSessionNotification</c> method deletes a previous registration by the client to receive notifications.
		/// </summary>
		/// <param name="NewNotifications">
		/// Pointer to a client-implemented IAudioSessionEvents interface. The client passed this same interface pointer to the session
		/// manager in a previous call to the IAudioSessionControl::RegisterAudioSessionNotification method. If the
		/// <c>UnregisterAudioSessionNotification</c> method succeeds, it calls the Release method on the client's
		/// <c>IAudioSessionEvents</c> interface.
		/// </param>
		/// <remarks>
		/// <para>
		/// The client calls this method when it no longer needs to receive notifications. The <c>UnregisterAudioSessionNotification</c>
		/// method removes the registration of an IAudioSessionEvents interface that the client previously registered with the session
		/// manager by calling the IAudioSessionControl::RegisterAudioSessionNotification method.
		/// </para>
		/// <para>
		/// Before the client releases its final reference to the IAudioSessionEvents interface, it should call
		/// <c>UnregisterAudioSessionNotification</c> to unregister the interface. Otherwise, the application leaks the resources held
		/// by the <c>IAudioSessionEvents</c> and IAudioSessionControl objects. Note that RegisterAudioSessionNotification calls the
		/// client's IAudioSessionEvents::AddRef method, and <c>UnregisterAudioSessionNotification</c> calls the
		/// IAudioSessionEvents::Release method. If the client errs by releasing its reference to the <c>IAudioSessionEvents</c>
		/// interface before calling <c>UnregisterAudioSessionNotification</c>, the session manager never releases its reference to the
		/// <c>IAudioSessionEvents</c> interface. For example, a poorly designed <c>IAudioSessionEvents</c> implementation might call
		/// <c>UnregisterAudioSessionNotification</c> from the destructor for the <c>IAudioSessionEvents</c> object. In this case, the
		/// client will not call <c>UnregisterAudioSessionNotification</c> until the session manager releases its reference to the
		/// <c>IAudioSessionEvents</c> interface, and the session manager will not release its reference to the
		/// <c>IAudioSessionEvents</c> interface until the client calls <c>UnregisterAudioSessionNotification</c>. For more information
		/// about the <c>AddRef</c> and <c>Release</c> methods, see the discussion of the IUnknown interface in the Windows SDK documentation.
		/// </para>
		/// <para>
		/// For a code example that calls the <c>UnregisterAudioSessionNotification</c> method, see Audio Events for Legacy Audio Applications.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol-unregisteraudiosessionnotification
		// HRESULT UnregisterAudioSessionNotification( IAudioSessionEvents *NewNotifications );
		new void UnregisterAudioSessionNotification([In] IAudioSessionEvents NewNotifications);

		/// <summary>The <c>GetSessionIdentifier</c> method retrieves the audio session identifier.</summary>
		/// <returns>A string that receives the audio session identifier.</returns>
		/// <remarks>
		/// <para>
		/// Each audio session is identified by an identifier string. This session identifier string is not unique across all instances.
		/// If there are two instances of the application playing, both instances will have the same session identifier. The identifier
		/// retrieved by <c>GetSessionIdentifier</c> is different from the session instance identifier, which is unique across all
		/// sessions. To get the session instance identifier, call IAudioSessionControl2::GetSessionInstanceIdentifier.
		/// </para>
		/// <para>
		/// <c>GetSessionIdentifier</c> checks whether the session has been disconnected on the default device. It retrieves the
		/// identifier string that is cached by the audio client for the device. If the session identifier is not found, this method
		/// retrieves it from the audio engine.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol2-getsessionidentifier
		// HRESULT GetSessionIdentifier( LPWSTR *pRetVal );
		SafeCoTaskMemString GetSessionIdentifier();

		/// <summary>The <c>GetSessionInstanceIdentifier</c> method retrieves the identifier of the audio session instance.</summary>
		/// <returns>A string that receives the identifier of a particular instance of the audio session.</returns>
		/// <remarks>
		/// <para>
		/// Each audio session instance is identified by a unique string. This string represents a particular instance of the audio
		/// session and, unlike the session identifier, is unique across all instances. If there are two instances of the application
		/// playing, they will have different session instance identifiers. The identifier retrieved by
		/// <c>GetSessionInstanceIdentifier</c> is different from the session identifier, which is shared by all session instances. To
		/// get the session identifier, call IAudioSessionControl2::GetSessionIdentifier.
		/// </para>
		/// <para>
		/// <c>GetSessionInstanceIdentifier</c> checks whether the session has been disconnected on the default device. It retrieves the
		/// identifier string that is cached by the audio client for the device. If the session instance identifier is not found, this
		/// method retrieves it from the audio engine. For example code about getting a session instance identifier, see Getting Ducking
		/// Events from a Communication Device.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol2-getsessioninstanceidentifier
		// HRESULT GetSessionInstanceIdentifier( LPWSTR *pRetVal );
		SafeCoTaskMemString GetSessionInstanceIdentifier();

		/// <summary>The <c>GetProcessId</c> method retrieves the process identifier of the audio session.</summary>
		/// <returns>A <c>DWORD</c> variable that receives the process identifier of the audio session.</returns>
		/// <remarks>
		/// <para>This method overwrites the value that was passed by the application in pRetVal.</para>
		/// <para>
		/// <c>GetProcessId</c> checks whether the audio session has been disconnected on the default device or if the session has
		/// switched to another stream. In the case of stream switching, this method transfers state information for the new stream to
		/// the session. State information includes volume controls, metadata information (display name, icon path), and the session's
		/// property store.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol2-getprocessid HRESULT
		// GetProcessId( DWORD *pRetVal );
		uint GetProcessId();

		/// <summary>The <c>IsSystemSoundsSession</c> method indicates whether the session is a system sounds session.</summary>
		/// <returns>
		/// <para>The possible return codes include, but are not limited to, the values shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The session is a system sounds session.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The session is not a system sounds session.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol2-issystemsoundssession
		// HRESULT IsSystemSoundsSession();
		[PreserveSig]
		HRESULT IsSystemSoundsSession();

		/// <summary>
		/// The <c>SetDuckingPreference</c> method enables or disables the default stream attenuation experience (auto-ducking) provided
		/// by the system.
		/// </summary>
		/// <param name="optOut">A <c>BOOL</c> variable that enables or disables system auto-ducking.</param>
		/// <remarks>
		/// <para>
		/// By default, the system adjusts the volume for all currently playing sounds when the system starts a communication session
		/// and receives a new communication stream on the default communication device. For more information about this feature, see
		/// Using a Communication Device.
		/// </para>
		/// <para>
		/// If the application passes <c>TRUE</c> in optOut, the system disables the Default Ducking Experience. For more information,
		/// see Disabling the Default Ducking Experience.
		/// </para>
		/// <para>
		/// To provide a custom implementation, the application needs to get notifications from the system when it opens or closes the
		/// communication stream. To receive the notifications, the application must call this method before registering itself by
		/// calling <c>IAudioSessionManager2::RegisterForDuckNotification</c>. For more information and example code, see Getting
		/// Ducking Events.
		/// </para>
		/// <para>
		/// If the application passes <c>FALSE</c> in optOut, the application provides the default stream attenuation experience
		/// provided by the system.
		/// </para>
		/// <para>
		/// We recommend that the application call <c>SetDuckingPreference</c> during stream creation. However, this method can be
		/// called dynamically during the session to change the initial preference.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessioncontrol2-setduckingpreference
		// HRESULT SetDuckingPreference( BOOL optOut );
		void SetDuckingPreference([MarshalAs(UnmanagedType.Bool)] bool optOut);
	}

	/// <summary>
	/// The <c>IAudioSessionEnumerator</c> interface enumerates audio sessions on an audio device. To get a reference to the
	/// <c>IAudioSessionEnumerator</c> interface of the session enumerator object, the application must call IAudioSessionManager2::GetSessionEnumerator.
	/// </summary>
	/// <remarks>
	/// <para>
	/// If an application wants to be notified when new sessions are created, it must register its implementation of
	/// IAudioSessionNotification with the session manager. Upon successful registration, the session manager sends create-session
	/// notifications to the application in the form of callbacks. These notifications contain a reference to the IAudioSessionControl
	/// pointer of the newly created session.
	/// </para>
	/// <para>
	/// The session enumerator maintains a list of current sessions by holding references to each session's IAudioSessionControl
	/// pointer. However, the session enumerator might not be aware of the new sessions that are reported through
	/// IAudioSessionNotification. In that case, the application would have access to only a partial list of sessions. This might occur
	/// if the <c>IAudioSessionControl</c> pointer (in the callback) is released before the session enumerator is initialized.
	/// Therefore, if an application wants a complete set of sessions for the audio endpoint, the application should maintain its own list.
	/// </para>
	/// <para>The application must perform the following steps to receive session notifications and manage a list of current sessions.</para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Initialize COM with the Multithreaded Apartment (MTA) model by calling in a non-UI thread. If MTA is not initialized, the
	/// application does not receive session notifications from the session manager.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Activate an IAudioSessionManager2 interface from the audio endpoint device. Call IMMDevice::Activate with parameter iid set to
	/// <c>IID_IAudioSessionManager2</c>. This call receives a reference to the session manager's <c>IAudioSessionManager2</c> interface
	/// in the ppInterface parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Implement the IAudioSessionNotification interface to provide the callback behavior.</term>
	/// </item>
	/// <item>
	/// <term>Call IAudioSessionManager2::RegisterSessionNotification to register the application's implementation of IAudioSessionNotification.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Create and initialize the session enumerator object by calling IAudioSessionManager2::GetSessionEnumerator. This method
	/// generates a list of current sessions available for the endpoint and adds the IAudioSessionControl pointers for each session in
	/// the list, if they are not already present.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Use the <c>IAudioSessionEnumerator</c> interface returned in the previous step to retrieve and enumerate the list of sessions.
	/// The session control for each session can be retrieved by calling IAudioSessionEnumerator::GetSession. Make sure you call
	/// <c>AddRef</c> for each session control to maintain the reference count.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// When the application gets a create-session notification, add the IAudioSessionControl pointer of the new session (received in
	/// IAudioSessionNotification::OnSessionCreated) to the list of existing sessions.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Because the application maintains this list of sessions and manages the lifetime of the session based on the application's
	/// requirements, there is no expiration mechanism enforced by the audio system on the session control objects.
	/// </para>
	/// <para>A session control is valid as long as the application has a reference to the session control in the list.</para>
	/// <para>Examples</para>
	/// <para>The following example code shows how to create the session enumerator object and then enumerate sessions.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nn-audiopolicy-iaudiosessionenumerator
	[PInvokeData("audiopolicy.h", MSDNShortId = "a7976d13-3391-4747-b83a-cfb9407b34f2")]
	[ComImport, Guid("E2F5BB11-0570-40CA-ACDD-3AA01277DEE8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioSessionEnumerator
	{
		/// <summary>The <c>GetCount</c> method gets the total number of audio sessions that are open on the audio device.</summary>
		/// <returns>Receives the total number of audio sessions.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionenumerator-getcount HRESULT
		// GetCount( int *SessionCount );
		int GetCount();

		/// <summary>The <c>GetSession</c> method gets the audio session specified by an audio session number.</summary>
		/// <param name="SessionCount">
		/// The session number. If there are n sessions, the sessions are numbered from 0 to n – 1. To get the number of sessions, call
		/// the IAudioSessionEnumerator::GetCount method.
		/// </param>
		/// <returns>
		/// Receives a pointer to the IAudioSessionControl interface of the session object in the collection that is maintained by the
		/// session enumerator. The caller must release the interface pointer.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionenumerator-getsession HRESULT
		// GetSession( int SessionCount, IAudioSessionControl **Session );
		IAudioSessionControl GetSession(int SessionCount);
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioSessionEvents</c> interface provides notifications of session-related events such as changes in the volume level,
	/// display name, and session state. Unlike the other interfaces in this section, which are implemented by the WASAPI system
	/// component, a WASAPI client implements the <c>IAudioSessionEvents</c> interface. To receive event notifications, the client
	/// passes a pointer to its <c>IAudioSessionEvents</c> interface to the IAudioSessionControl::RegisterAudioSessionNotification method.
	/// </para>
	/// <para>
	/// After registering its <c>IAudioClientSessionEvents</c> interface, the client receives event notifications in the form of
	/// callbacks through the methods in the interface.
	/// </para>
	/// <para>
	/// In implementing the <c>IAudioSessionEvents</c> interface, the client should observe these rules to avoid deadlocks and undefined behavior:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The methods in the interface must be nonblocking. The client should never wait on a synchronization object during an event callback.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The client should never call the IAudioSessionControl::UnregisterAudioSessionNotification method during an event callback.</term>
	/// </item>
	/// <item>
	/// <term>The client should never release the final reference on a WASAPI object during an event callback.</term>
	/// </item>
	/// </list>
	/// <para>
	/// For a code example that implements an <c>IAudioSessionEvents</c> interface, see Audio Session Events. For a code example that
	/// registers a client's <c>IAudioSessionEvents</c> interface to receive notifications, see Audio Events for Legacy Audio Applications.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nn-audiopolicy-iaudiosessionevents
	[PInvokeData("audiopolicy.h", MSDNShortId = "fd287ef7-8a37-4342-b4c2-79b84a56c30e")]
	[ComImport, Guid("24918ACC-64B3-37C1-8CA9-74A66E9957A8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioSessionEvents
	{
		/// <summary>The <c>OnDisplayNameChanged</c> method notifies the client that the display name for the session has changed.</summary>
		/// <param name="NewDisplayName">
		/// The new display name for the session. This parameter points to a null-terminated, wide-character string containing the new
		/// display name. The string remains valid for the duration of the call.
		/// </param>
		/// <param name="EventContext">
		/// The event context value. This is the same value that the caller passed to IAudioSessionControl::SetDisplayName in the call
		/// that changed the display name for the session. For more information, see Remarks.
		/// </param>
		/// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
		/// <remarks>
		/// <para>
		/// The session manager calls this method each time a call to the IAudioSessionControl::SetDisplayName method changes the
		/// display name of the session. The Sndvol program uses a session's display name to label the volume slider for the session.
		/// </para>
		/// <para>
		/// The EventContext parameter provides a means for a client to distinguish between a display-name change that it initiated and
		/// one that some other client initiated. When calling the IAudioSessionControl::SetDisplayName method, a client passes in an
		/// EventContext parameter value that its implementation of the <c>OnDisplayNameChanged</c> method can recognize.
		/// </para>
		/// <para>For a code example that implements the methods in the IAudioSessionEvents interface, see Audio Session Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionevents-ondisplaynamechanged
		// HRESULT OnDisplayNameChanged( LPCWSTR NewDisplayName, LPCGUID EventContext );
		[PreserveSig]
		HRESULT OnDisplayNameChanged([MarshalAs(UnmanagedType.LPWStr)] string NewDisplayName, in Guid EventContext);

		/// <summary>The <c>OnIconPathChanged</c> method notifies the client that the display icon for the session has changed.</summary>
		/// <param name="NewIconPath">
		/// The path for the new display icon for the session. This parameter points to a string that contains the path for the new
		/// icon. The string pointer remains valid only for the duration of the call.
		/// </param>
		/// <param name="EventContext">
		/// The event context value. This is the same value that the caller passed to IAudioSessionControl::SetIconPath in the call that
		/// changed the display icon for the session. For more information, see Remarks.
		/// </param>
		/// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
		/// <remarks>
		/// <para>
		/// The session manager calls this method each time a call to the IAudioSessionControl::SetIconPath method changes the display
		/// icon for the session. The Sndvol program uses a session's display icon to label the volume slider for the session.
		/// </para>
		/// <para>
		/// The EventContext parameter provides a means for a client to distinguish between a display-icon change that it initiated and
		/// one that some other client initiated. When calling the IAudioSessionControl::SetIconPath method, a client passes in an
		/// EventContext parameter value that its implementation of the <c>OnIconPathChanged</c> method can recognize.
		/// </para>
		/// <para>For a code example that implements the methods in the IAudioSessionEvents interface, see Audio Session Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionevents-oniconpathchanged HRESULT
		// OnIconPathChanged( LPCWSTR NewIconPath, LPCGUID EventContext );
		[PreserveSig]
		HRESULT OnIconPathChanged([MarshalAs(UnmanagedType.LPWStr)] string NewIconPath, in Guid EventContext);

		/// <summary>
		/// The <c>OnSimpleVolumeChanged</c> method notifies the client that the volume level or muting state of the audio session has changed.
		/// </summary>
		/// <param name="NewVolume">
		/// The new volume level for the audio session. This parameter is a value in the range 0.0 to 1.0, where 0.0 is silence and 1.0
		/// is full volume (no attenuation).
		/// </param>
		/// <param name="NewMute">The new muting state. If <c>TRUE</c>, muting is enabled. If <c>FALSE</c>, muting is disabled.</param>
		/// <param name="EventContext">
		/// The event context value. This is the same value that the caller passed to ISimpleAudioVolume::SetMasterVolume or
		/// ISimpleAudioVolume::SetMute in the call that changed the volume level or muting state of the session. For more information,
		/// see Remarks.
		/// </param>
		/// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
		/// <remarks>
		/// <para>
		/// The session manager calls this method each time a call to the ISimpleAudioVolume::SetMasterVolume or
		/// ISimpleAudioVolume::SetMute method changes the volume level or muting state of the session.
		/// </para>
		/// <para>
		/// The EventContext parameter provides a means for a client to distinguish between a volume or mute change that it initiated
		/// and one that some other client initiated. When calling the ISimpleAudioVolume::SetMasterVolume or
		/// ISimpleAudioVolume::SetMute method, a client passes in an EventContext parameter value that its implementation of the
		/// <c>OnSimpleVolumeChanged</c> method can recognize.
		/// </para>
		/// <para>For a code example that implements the methods in the IAudioSessionEvents interface, see Audio Session Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionevents-onsimplevolumechanged
		// HRESULT OnSimpleVolumeChanged( float NewVolume, BOOL NewMute, LPCGUID EventContext );
		[PreserveSig]
		HRESULT OnSimpleVolumeChanged([In] float NewVolume, [MarshalAs(UnmanagedType.Bool)] bool NewMute, in Guid EventContext);

		/// <summary>
		/// The <c>OnChannelVolumeChanged</c> method notifies the client that the volume level of an audio channel in the session submix
		/// has changed.
		/// </summary>
		/// <param name="ChannelCount">The channel count. This parameter specifies the number of audio channels in the session submix.</param>
		/// <param name="NewChannelVolumeArray">
		/// Pointer to an array of volume levels. Each element is a value of type <c>float</c> that specifies the volume level for a
		/// particular channel. Each volume level is a value in the range 0.0 to 1.0, where 0.0 is silence and 1.0 is full volume (no
		/// attenuation). The number of elements in the array is specified by the ChannelCount parameter. If an audio stream contains n
		/// channels, the channels are numbered from 0 to n– 1. The array element whose index matches the channel number, contains the
		/// volume level for that channel. Assume that the array remains valid only for the duration of the call.
		/// </param>
		/// <param name="ChangedChannel">
		/// The number of the channel whose volume level changed. Use this value as an index into the NewChannelVolumeArray array. If
		/// the session submix contains n channels, the channels are numbered from 0 to n– 1. If more than one channel might have
		/// changed (for example, as a result of a call to the IChannelAudioVolume::SetAllVolumes method), the value of ChangedChannel
		/// is ( <c>DWORD</c>)(–1).
		/// </param>
		/// <param name="EventContext">
		/// The event context value. This is the same value that the caller passed to the IChannelAudioVolume::SetChannelVolume or
		/// <c>IChannelAudioVolume::SetAllVolumes</c> method in the call that initiated the change in volume level of the channel. For
		/// more information, see Remarks.
		/// </param>
		/// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
		/// <remarks>
		/// <para>
		/// The session manager calls this method each time a call to the <c>IChannelAudioVolume::SetChannelVolume</c> or
		/// <c>IChannelAudioVolume::SetAllVolumes</c> method successfully updates the volume level of one or more channels in the
		/// session submix. Note that the <c>OnChannelVolumeChanged</c> call occurs regardless of whether the new channel volume level
		/// or levels differ in value from the previous channel volume level or levels.
		/// </para>
		/// <para>
		/// The EventContext parameter provides a means for a client to distinguish between a channel-volume change that it initiated
		/// and one that some other client initiated. When calling the <c>IChannelAudioVolume::SetChannelVolume</c> or
		/// <c>IChannelAudioVolume::SetAllVolumes</c> method, a client passes in an EventContext parameter value that its implementation
		/// of the <c>OnChannelVolumeChanged</c> method can recognize.
		/// </para>
		/// <para>For a code example that implements the methods in the <c>IAudioSessionEvents</c> interface, see Audio Session Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionevents-onchannelvolumechanged
		// HRESULT OnChannelVolumeChanged( DWORD ChannelCount, float [] NewChannelVolumeArray, DWORD ChangedChannel, LPCGUID
		// EventContext );
		[PreserveSig]
		HRESULT OnChannelVolumeChanged(uint ChannelCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] NewChannelVolumeArray, uint ChangedChannel, in Guid EventContext);

		/// <summary>
		/// The <c>OnGroupingParamChanged</c> method notifies the client that the grouping parameter for the session has changed.
		/// </summary>
		/// <param name="NewGroupingParam">
		/// The new grouping parameter for the session. This parameter points to a grouping-parameter GUID.
		/// </param>
		/// <param name="EventContext">
		/// The event context value. This is the same value that the caller passed to IAudioSessionControl::SetGroupingParam in the call
		/// that changed the grouping parameter for the session. For more information, see Remarks.
		/// </param>
		/// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
		/// <remarks>
		/// <para>
		/// The session manager calls this method each time a call to the IAudioSessionControl::SetGroupingParam method changes the
		/// grouping parameter for the session.
		/// </para>
		/// <para>
		/// The EventContext parameter provides a means for a client to distinguish between a grouping-parameter change that it
		/// initiated and one that some other client initiated. When calling the IAudioSessionControl::SetGroupingParam method, a client
		/// passes in an EventContext parameter value that its implementation of the <c>OnGroupingParamChanged</c> method can recognize.
		/// </para>
		/// <para>For a code example that implements the methods in the IAudioSessionEvents interface, see Audio Session Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionevents-ongroupingparamchanged
		// HRESULT OnGroupingParamChanged( LPCGUID NewGroupingParam, LPCGUID EventContext );
		[PreserveSig]
		HRESULT OnGroupingParamChanged(in Guid NewGroupingParam, in Guid EventContext);

		/// <summary>The <c>OnStateChanged</c> method notifies the client that the stream-activity state of the session has changed.</summary>
		/// <param name="NewState">
		/// <para>The new session state. The value of this parameter is one of the following AudioSessionState enumeration values:</para>
		/// <para>AudioSessionStateActive</para>
		/// <para>AudioSessionStateInactive</para>
		/// <para>AudioSessionStateExpired</para>
		/// </param>
		/// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
		/// <remarks>
		/// <para>
		/// A client cannot generate a session-state-change event. The system is always the source of this type of event. Thus, unlike
		/// some other IAudioSessionEvents methods, this method does not supply a context parameter.
		/// </para>
		/// <para>
		/// The system changes the state of a session from inactive to active at the time that a client opens the first stream in the
		/// session. A client opens a stream by calling the IAudioClient::Initialize method. The system changes the session state from
		/// active to inactive at the time that a client closes the last stream in the session. The client that releases the last
		/// reference to an IAudioClient object closes the stream that is associated with the object.
		/// </para>
		/// <para>For a code example that implements the methods in the IAudioSessionEvents interface, see Audio Session Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionevents-onstatechanged HRESULT
		// OnStateChanged( AudioSessionState NewState );
		[PreserveSig]
		HRESULT OnStateChanged(AudioSessionState NewState);

		/// <summary>The <c>OnSessionDisconnected</c> method notifies the client that the audio session has been disconnected.</summary>
		/// <param name="DisconnectReason">
		/// <para>
		/// The reason that the audio session was disconnected. The caller sets this parameter to one of the
		/// <c>AudioSessionDisconnectReason</c> enumeration values shown in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>DisconnectReasonDeviceRemoval</term>
		/// <term>The user removed the audio endpoint device.</term>
		/// </item>
		/// <item>
		/// <term>DisconnectReasonServerShutdown</term>
		/// <term>The Windows audio service has stopped.</term>
		/// </item>
		/// <item>
		/// <term>DisconnectReasonFormatChanged</term>
		/// <term>The stream format changed for the device that the audio session is connected to.</term>
		/// </item>
		/// <item>
		/// <term>DisconnectReasonSessionLogoff</term>
		/// <term>The user logged off the Windows Terminal Services (WTS) session that the audio session was running in.</term>
		/// </item>
		/// <item>
		/// <term>DisconnectReasonSessionDisconnected</term>
		/// <term>The WTS session that the audio session was running in was disconnected.</term>
		/// </item>
		/// <item>
		/// <term>DisconnectReasonExclusiveModeOverride</term>
		/// <term>
		/// The (shared-mode) audio session was disconnected to make the audio endpoint device available for an exclusive-mode connection.
		/// </term>
		/// </item>
		/// </list>
		/// <para>For more information about WTS sessions, see the Windows SDK documentation.</para>
		/// </param>
		/// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
		/// <remarks>
		/// <para>
		/// When disconnecting a session, the session manager closes the streams that belong to that session and invalidates all
		/// outstanding requests for services on those streams. The client should respond to a disconnection by releasing all of its
		/// references to the IAudioClient interface for a closed stream and releasing all references to the service interfaces that it
		/// obtained previously through calls to the IAudioClient::GetService method.
		/// </para>
		/// <para>
		/// Following disconnection, many of the methods in the WASAPI interfaces that are tied to closed streams in the disconnected
		/// session return error code AUDCLNT_E_DEVICE_INVALIDATED (for example, see IAudioClient::GetCurrentPadding). For information
		/// about recovering from this error, see Recovering from an Invalid-Device Error.
		/// </para>
		/// <para>
		/// If the Windows audio service terminates unexpectedly, it does not have an opportunity to notify clients that it is shutting
		/// down. In that case, clients learn that the service has stopped when they call a method such as
		/// IAudioClient::GetCurrentPadding that discovers that the service is no longer running and fails with error code AUDCLNT_E_SERVICE_NOT_RUNNING.
		/// </para>
		/// <para>
		/// A client cannot generate a session-disconnected event. The system is always the source of this type of event. Thus, unlike
		/// some other IAudioSessionEvents methods, this method does not have a context parameter.
		/// </para>
		/// <para>For a code example that implements the methods in the IAudioSessionEvents interface, see Audio Session Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionevents-onsessiondisconnected
		// HRESULT OnSessionDisconnected( AudioSessionDisconnectReason DisconnectReason );
		[PreserveSig]
		HRESULT OnSessionDisconnected([In] AudioSessionDisconnectReason DisconnectReason);
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioSessionManager</c> interface enables a client to access the session controls and volume controls for both
	/// cross-process and process-specific audio sessions. The client obtains a reference to an <c>IAudioSessionManager</c> interface by
	/// calling the IMMDevice::Activate method with parameter iid set to <c>REFIID</c> IID_IAudioSessionManager.
	/// </para>
	/// <para>
	/// This interface enables clients to access the controls for an existing session without first opening a stream. This capability is
	/// useful for clients of higher-level APIs that are built on top of WASAPI and use session controls internally but do not give
	/// their clients access to session controls.
	/// </para>
	/// <para>
	/// In Windows Vista, the higher-level APIs that use WASAPI include Media Foundation, DirectSound, the Windows multimedia
	/// <c>waveInXxx</c>, <c>waveOutXxx</c>, and <c>mciXxx</c> functions, and third-party APIs.
	/// </para>
	/// <para>
	/// When a client creates an audio stream through a higher-level API, that API typically adds the stream to the default audio
	/// session for the client's process (the session that is identified by the session GUID value, GUID_NULL), but the same API might
	/// not provide a means for the client to access the controls for that session. In that case, the client can access the controls
	/// through the <c>IAudioSessionManager</c> interface.
	/// </para>
	/// <para>For a code example that uses the <c>IAudioSessionManager</c> interface, see Audio Events for Legacy Audio Applications.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nn-audiopolicy-iaudiosessionmanager
	[PInvokeData("audiopolicy.h", MSDNShortId = "606b0a42-d1d1-4196-911f-5b095bf56c4e")]
	[ComImport, Guid("BFA971F1-4D5E-40BB-935E-967039BFBEE4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioSessionManager
	{
		/// <summary>The <c>GetAudioSessionControl</c> method retrieves an audio session control.</summary>
		/// <param name="AudioSessionGuid">
		/// Pointer to a session GUID. If the GUID does not identify a session that has been previously opened, the call opens a new but
		/// empty session. The Sndvol program does not display a volume-level control for a session unless it contains one or more
		/// active streams. If this parameter is <c>NULL</c> or points to the value GUID_NULL, the method assigns the stream to the
		/// default session.
		/// </param>
		/// <param name="StreamFlags">Specifies the status of the flags for the audio stream.</param>
		/// <returns>
		/// A pointer to the IAudioSessionControl interface of the audio session control object. The caller is responsible for releasing
		/// the interface, when it is no longer needed, by calling the interface's <c>Release</c> method. If the call fails,
		/// *SessionControl is <c>NULL</c>.
		/// </returns>
		/// <remarks>For a code example that calls this method, see Audio Events for Legacy Audio Applications.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionmanager-getaudiosessioncontrol
		// HRESULT GetAudioSessionControl( LPCGUID AudioSessionGuid, DWORD StreamFlags, IAudioSessionControl **SessionControl );
		IAudioSessionControl GetAudioSessionControl([In, Optional] in Guid AudioSessionGuid, [In] AUDCLNT_STREAMFLAGS StreamFlags);

		/// <summary>The <c>GetSimpleAudioVolume</c> method retrieves a simple audio volume control.</summary>
		/// <param name="AudioSessionGuid">
		/// Pointer to a session GUID. If the GUID does not identify a session that has been previously opened, the call opens a new but
		/// empty session. The Sndvol program does not display a volume-level control for a session unless it contains one or more
		/// active streams. If this parameter is <c>NULL</c> or points to the value GUID_NULL, the method assigns the stream to the
		/// default session.
		/// </param>
		/// <param name="StreamFlags">
		/// Specifies whether the request is for a cross-process session. Set to <c>TRUE</c> if the session is cross-process. Set to
		/// <c>FALSE</c> if the session is not cross-process.
		/// </param>
		/// <returns>
		/// Pointer to a pointer variable into which the method writes a pointer to the ISimpleAudioVolume interface of the audio volume
		/// control object. This interface represents the simple audio volume control for the current process. The caller is responsible
		/// for releasing the interface, when it is no longer needed, by calling the interface's <c>Release</c> method. If the
		/// <c>Activate</c> call fails, *AudioVolume is <c>NULL</c>.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionmanager-getsimpleaudiovolume
		// HRESULT GetSimpleAudioVolume( LPCGUID AudioSessionGuid, DWORD StreamFlags, ISimpleAudioVolume **AudioVolume );
		ISimpleAudioVolume GetSimpleAudioVolume([In, Optional] in Guid AudioSessionGuid, [In] AUDCLNT_STREAMFLAGS StreamFlags);
	}

	/// <summary>
	/// <para>The <c>IAudioSessionManager2</c> interface enables an application to manage submixes for the audio device.</para>
	/// <para>
	/// To a get a reference to an <c>IAudioSessionManager2</c> interface, the application must activate it on the audio device by
	/// following these steps:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Use one of the techniques described on the IMMDevice interface page to obtain a reference to the <c>IMMDevice</c> interface for
	/// an audio endpoint device.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Call the IMMDevice::Activate method with parameter iid set to IID_IAudioSessionManager2.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When the application wants to release the <c>IAudioSessionManager2</c> interface instance, the application must call the
	/// interface's <c>Release</c> method.
	/// </para>
	/// <para>
	/// The application thread that uses this interface must be initialized for COM. For more information about COM initialization, see
	/// the description of the <c>CoInitializeEx</c> function in the Windows SDK documentation.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>An application can use this interface to perform the following tasks:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Register to receive ducking notifications.</term>
	/// </item>
	/// <item>
	/// <term>Register to receive a notification when a session is created.</term>
	/// </item>
	/// <item>
	/// <term>Enumerate sessions on the audio device that was used to get the interface pointer.</term>
	/// </item>
	/// </list>
	/// <para>
	/// This interface supports custom implementations for stream attenuation or ducking, a new feature in Windows 7. An application
	/// playing a media stream can make the it behave differently when a new communication stream is opened on the default communication
	/// device. For example, the original media stream can be paused while the new communication stream is open. For more information
	/// about this feature, see Using a Communication Device.
	/// </para>
	/// <para>
	/// An application that manages the media streams and wants to provide a custom ducking implementation, must register to receive
	/// notifications when session events occur. For stream attenuation, a session event is raised by the system when a communication
	/// stream is opened or closed on the default communication device. For more information, see Providing a Custom Ducking Behavior.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example code shows how to get a reference to the <c>IAudioSessionManager2</c> interface of the audio device.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nn-audiopolicy-iaudiosessionmanager2
	[PInvokeData("audiopolicy.h", MSDNShortId = "476dac90-d0c4-499c-973e-33ea55546659")]
	[ComImport, Guid("77AA99A0-1BD6-484F-8BC7-2C654C9A9B6F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioSessionManager2 : IAudioSessionManager
	{
		/// <summary>The <c>GetAudioSessionControl</c> method retrieves an audio session control.</summary>
		/// <param name="AudioSessionGuid">
		/// Pointer to a session GUID. If the GUID does not identify a session that has been previously opened, the call opens a new but
		/// empty session. The Sndvol program does not display a volume-level control for a session unless it contains one or more
		/// active streams. If this parameter is <c>NULL</c> or points to the value GUID_NULL, the method assigns the stream to the
		/// default session.
		/// </param>
		/// <param name="StreamFlags">Specifies the status of the flags for the audio stream.</param>
		/// <returns>
		/// A pointer to the IAudioSessionControl interface of the audio session control object. The caller is responsible for releasing
		/// the interface, when it is no longer needed, by calling the interface's <c>Release</c> method. If the call fails,
		/// *SessionControl is <c>NULL</c>.
		/// </returns>
		/// <remarks>For a code example that calls this method, see Audio Events for Legacy Audio Applications.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionmanager-getaudiosessioncontrol
		// HRESULT GetAudioSessionControl( LPCGUID AudioSessionGuid, DWORD StreamFlags, IAudioSessionControl **SessionControl );
		new IAudioSessionControl GetAudioSessionControl([In, Optional] in Guid AudioSessionGuid, [In] AUDCLNT_STREAMFLAGS StreamFlags);

		/// <summary>The <c>GetSimpleAudioVolume</c> method retrieves a simple audio volume control.</summary>
		/// <param name="AudioSessionGuid">
		/// Pointer to a session GUID. If the GUID does not identify a session that has been previously opened, the call opens a new but
		/// empty session. The Sndvol program does not display a volume-level control for a session unless it contains one or more
		/// active streams. If this parameter is <c>NULL</c> or points to the value GUID_NULL, the method assigns the stream to the
		/// default session.
		/// </param>
		/// <param name="StreamFlags">
		/// Specifies whether the request is for a cross-process session. Set to <c>TRUE</c> if the session is cross-process. Set to
		/// <c>FALSE</c> if the session is not cross-process.
		/// </param>
		/// <returns>
		/// Pointer to a pointer variable into which the method writes a pointer to the ISimpleAudioVolume interface of the audio volume
		/// control object. This interface represents the simple audio volume control for the current process. The caller is responsible
		/// for releasing the interface, when it is no longer needed, by calling the interface's <c>Release</c> method. If the
		/// <c>Activate</c> call fails, *AudioVolume is <c>NULL</c>.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionmanager-getsimpleaudiovolume
		// HRESULT GetSimpleAudioVolume( LPCGUID AudioSessionGuid, DWORD StreamFlags, ISimpleAudioVolume **AudioVolume );
		new ISimpleAudioVolume GetSimpleAudioVolume([In, Optional] in Guid AudioSessionGuid, [In] AUDCLNT_STREAMFLAGS StreamFlags);

		/// <summary>The <c>GetSessionEnumerator</c> method gets a pointer to the audio session enumerator object.</summary>
		/// <returns>
		/// Receives a pointer to the IAudioSessionEnumerator interface of the session enumerator object that the client can use to
		/// enumerate audio sessions on the audio device. Through this method, the caller obtains a counted reference to the interface.
		/// The caller is responsible for releasing the interface, when it is no longer needed, by calling the interface's
		/// <c>Release</c> method.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The session manager maintains a collection of audio sessions that are active on the audio device by querying the audio
		/// engine. <c>GetSessionEnumerator</c> creates a session control for each session in the collection. To get a reference to the
		/// IAudioSessionControl interface of the session in the enumerated collection, the application must call
		/// IAudioSessionEnumerator::GetSession. For a code example, see IAudioSessionEnumerator Interface.
		/// </para>
		/// <para>
		/// The session enumerator might not be aware of the new sessions that are reported through IAudioSessionNotification. So if an
		/// application exclusively relies on the session enumerator for getting all the sessions for an audio endpoint, the results
		/// might not be accurate. To work around this, the application should manually maintain a list. For more information, see IAudioSessionEnumerator.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionmanager2-getsessionenumerator
		// HRESULT GetSessionEnumerator( IAudioSessionEnumerator **SessionEnum );
		IAudioSessionEnumerator GetSessionEnumerator();

		/// <summary>
		/// The <c>RegisterSessionNotification</c> method registers the application to receive a notification when a session is created.
		/// </summary>
		/// <param name="SessionNotification">
		/// A pointer to the application's implementation of the IAudioSessionNotification interface. If the method call succeeds, it
		/// calls the <c>AddRef</c> method on the application's <c>IAudioSessionNotification</c> interface.
		/// </param>
		/// <remarks>
		/// <para>
		/// The application can register to receive a notification when a session is created, through the methods of the
		/// IAudioSessionNotification interface. The application implements the <c>IAudioSessionNotification</c> interface. The methods
		/// defined in this interface receive callbacks from the system when a session is created. For example code that shows how to
		/// implement this interface, see
		/// </para>
		/// <para>IAudioSessionNotification Interface.</para>
		/// <para>
		/// To begin receiving notifications, the application calls the <c>IAudioSessionManager2::RegisterSessionNotification</c> method
		/// to register its IAudioSessionNotification interface. When the application no longer requires notifications, it calls the
		/// IAudioSessionManager2::UnregisterSessionNotification method to delete the registration.
		/// </para>
		/// <para>
		/// <c>Note</c> Make sure that the application initializes COM with Multithreaded Apartment (MTA) model by calling in a non-UI
		/// thread. If MTA is not initialized, the application does not receive session notifications from the session manager. Threads
		/// that run the user interface of an application should be initialized apartment threading model.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionmanager2-registersessionnotification
		// HRESULT RegisterSessionNotification( IAudioSessionNotification *SessionNotification );
		void RegisterSessionNotification(IAudioSessionNotification SessionNotification);

		/// <summary>
		/// The <c>UnregisterSessionNotification</c> method deletes the registration to receive a notification when a session is created.
		/// </summary>
		/// <param name="SessionNotification">
		/// <para>
		/// A pointer to the application's implementation of the IAudioSessionNotification interface. Pass the same interface pointer
		/// that was specified to the session manager in a previous call to IAudioSessionManager2::RegisterSessionNotification to
		/// register for notification.
		/// </para>
		/// <para>
		/// If the <c>UnregisterSessionNotification</c> method succeeds, it calls the <c>Release</c> method on the application's
		/// IAudioSessionNotification interface.
		/// </para>
		/// </param>
		/// <remarks>
		/// The application calls this method when it no longer needs to receive notifications. The <c>UnregisterSessionNotification</c>
		/// method removes the registration of an IAudioSessionNotification interface that the application previously registered with
		/// the session manager by calling the IAudioSessionControl::RegisterAudioSessionNotification method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionmanager2-unregistersessionnotification
		// HRESULT UnregisterSessionNotification( IAudioSessionNotification *SessionNotification );
		void UnregisterSessionNotification(IAudioSessionNotification SessionNotification);

		/// <summary>
		/// The <c>RegisterDuckNotification</c> method registers the application with the session manager to receive ducking notifications.
		/// </summary>
		/// <param name="sessionID">
		/// <para>
		/// Pointer to a null-terminated string that contains a session instance identifier. Applications that are playing a media
		/// stream and want to provide custom stream attenuation or ducking behavior, pass their own session instance identifier. For
		/// more information, see Remarks.
		/// </para>
		/// <para>
		/// Other applications that do not want to alter their streams but want to get all the ducking notifications must pass <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="duckNotification">
		/// Pointer to the application's implementation of the IAudioVolumeDuckNotification interface. The implementation is called when
		/// ducking events are raised by the audio system and notifications are sent to the registered applications.
		/// </param>
		/// <remarks>
		/// <para>
		/// Stream Attenuation or ducking is a new feature in Windows 7. An application playing a media stream can make the stream
		/// behave differently when a new communication stream is opened on the default communication device. For example, the original
		/// media stream can be paused while the new communication stream is open. To provide this custom implementation for stream
		/// attenuation, the application can opt out of the default stream attenuation experience by calling
		/// IAudioSessionControl::SetDuckingPreference and then register itself to receive notifications when session events occur. For
		/// stream attenuation, a session event is raised by the system when a communication stream is opened or closed on the default
		/// communication device. For more information about this feature, see Getting Ducking Events.
		/// </para>
		/// <para>
		/// To begin receiving notifications, the application calls the <c>RegisterDuckNotification</c> method to register its
		/// IAudioVolumeDuckNotification interface with the session manager. When the application no longer requires notifications, it
		/// calls the IAudioSessionManager2::UnregisterDuckNotification method to delete the registration.
		/// </para>
		/// <para>
		/// The application receives notifications about the ducking events through the methods of the IAudioVolumeDuckNotification
		/// interface. The application implements <c>IAudioVolumeDuckNotification</c>. After the registration call has succeeded, the
		/// system calls the methods of this interface when session events occur.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionmanager2-registerducknotification
		// HRESULT RegisterDuckNotification( LPCWSTR sessionID, IAudioVolumeDuckNotification *duckNotification );
		void RegisterDuckNotification([MarshalAs(UnmanagedType.LPWStr)] string sessionID, [In] IAudioVolumeDuckNotification duckNotification);

		/// <summary>The <c>UnregisterDuckNotification</c> method deletes a previous registration by the application to receive notifications.</summary>
		/// <param name="duckNotification">
		/// Pointer to the IAudioVolumeDuckNotification interface that is implemented by the application. Pass the same interface
		/// pointer that was specified to the session manager in a previous call to the IAudioSessionManager2::RegisterDuckNotification
		/// method. If the <c>UnregisterDuckNotification</c> method succeeds, it calls the <c>Release</c> method on the application's
		/// <c>IAudioVolumeDuckNotification</c> interface.
		/// </param>
		/// <remarks>
		/// <para>
		/// The application calls this method when it no longer needs to receive notifications. The <c>UnregisterDuckNotification</c>
		/// method removes the registration of an IAudioVolumeDuckNotification interface that the application previously registered with
		/// the session manager by calling the IAudioSessionManager2::RegisterDuckNotification method.
		/// </para>
		/// <para>After the application calls <c>UnregisterDuckNotification</c>, any pending events are not reported to the application.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionmanager2-unregisterducknotification
		// HRESULT UnregisterDuckNotification( IAudioVolumeDuckNotification *duckNotification );
		void UnregisterDuckNotification([In] IAudioVolumeDuckNotification duckNotification);
	}

	/// <summary>The <c>IAudioSessionNotification</c> interface provides notification when an audio session is created.</summary>
	/// <remarks>
	/// <para>
	/// Unlike the other WASAPI interfaces, which are implemented by the WASAPI system component, the <c>IAudioSessionNotification</c>
	/// interface is implemented by the application. To receive event notifications, the application passes to the
	/// IAudioSessionManager2::RegisterSessionNotification method a pointer to its <c>IAudioSessionNotification</c> implementation .
	/// </para>
	/// <para>
	/// After registering its <c>IAudioSessionNotification</c> interface, the application receives event notifications in the form of
	/// callbacks through the methods in the interface.
	/// </para>
	/// <para>
	/// When the application no longer needs to receive notifications, it calls the IAudioSessionManager2::UnregisterSessionNotification
	/// method. This method removes the registration of an <c>IAudioSessionNotification</c> interface that the application previously registered.
	/// </para>
	/// <para>The application must not register or unregister notification callbacks during an event callback.</para>
	/// <para>
	/// The session enumerator might not be aware of the new sessions that are reported through <c>IAudioSessionNotification</c>. So if
	/// an application exclusively relies on the session enumerator for getting all the sessions for an audio endpoint, the results
	/// might not be accurate. To work around this, the application should manually maintain a list. For more information, see IAudioSessionEnumerator.
	/// </para>
	/// <para>
	/// <c>Note</c> Make sure that the application initializes COM with Multithreaded Apartment (MTA) model by calling in a non-UI
	/// thread. If MTA is not initialized, the application does not receive session notifications from the session manager. Threads that
	/// run the user interface of an application should be initialized apartment threading model.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following code example shows a sample implementation of the <c>IAudioSessionNotification</c> interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nn-audiopolicy-iaudiosessionnotification
	[PInvokeData("audiopolicy.h", MSDNShortId = "69222168-87d7-4f5a-93b1-6d91263a54bd")]
	[ComImport, Guid("641DD20B-4D41-49CC-ABA3-174B9477BB08"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioSessionNotification
	{
		/// <summary>The <c>OnSessionCreated</c> method notifies the registered processes that the audio session has been created.</summary>
		/// <param name="NewSession">Pointer to the IAudioSessionControl interface of the audio session that was created.</param>
		/// <returns>If the method succeeds, it returns S_OK.</returns>
		/// <remarks>
		/// <para>
		/// After registering its IAudioSessionNotification interface, the application receives event notifications in the form of
		/// callbacks through the methods of the interface.
		/// </para>
		/// <para>
		/// The audio engine calls <c>OnSessionCreated</c> when a new session is activated on the device endpoint. This method is called
		/// from the session manager thread. This method must take a reference to the session in the NewSession parameter if it wants to
		/// keep the reference after this call completes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiosessionnotification-onsessioncreated
		// HRESULT OnSessionCreated( IAudioSessionControl *NewSession );
		HRESULT OnSessionCreated(IAudioSessionControl NewSession);
	}

	/// <summary>
	/// The <c>IAudioVolumeDuckNotification</c> interface is used to by the system to send notifications about stream attenuation
	/// changes.Stream Attenuation, or ducking, is a feature introduced in Windows 7, where the system adjusts the volume of a
	/// non-communication stream when a new communication stream is opened. For more information about this feature, see Default Ducking Experience.
	/// </summary>
	/// <remarks>
	/// <para>
	/// If an application needs to opt out of the system attenuation experience provided by the system, it must call
	/// IAudioSessionControl2::SetDuckingPreference and specify that preference.
	/// </para>
	/// <para>
	/// Unlike the other WASAPI interfaces, which are implemented by the WASAPI system component, the
	/// <c>IAudioVolumeDuckNotification</c> interface is implemented by the application to provide custom stream attenuation behavior.
	/// To receive event notifications, the application passes to the IAudioSessionManager2::RegisterDuckNotification method a pointer
	/// to the application's implementation of <c>IAudioVolumeDuckNotification</c>.
	/// </para>
	/// <para>
	/// After the application has registered its <c>IAudioVolumeDuckNotification</c> interface, the session manager calls the
	/// <c>IAudioVolumeDuckNotification</c> implementation when it needs to send ducking notifications. The application receives event
	/// notifications in the form of callbacks through the methods of the interface.
	/// </para>
	/// <para>
	/// When the application no longer needs to receive notifications, it calls the IAudioSessionManager2::UnregisterDuckNotification
	/// method. The <c>UnregisterDuckNotification</c> method removes the registration of an <c>IAudioVolumeDuckNotification</c>
	/// interface that the application previously registered.
	/// </para>
	/// <para>The application must not register or unregister notification callbacks during an event callback.</para>
	/// <para>For more information, see Implementation Considerations for Ducking Notifications.</para>
	/// <para>Examples</para>
	/// <para>The following example code shows a sample implementation of the <c>IAudioVolumeDuckNotification</c> interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nn-audiopolicy-iaudiovolumeducknotification
	[PInvokeData("audiopolicy.h", MSDNShortId = "08e90a50-a6ac-4405-ba90-a862b78efaf8")]
	[ComImport, Guid("C3B284D4-6D39-4359-B3CF-B56DDB3BB39C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioVolumeDuckNotification
	{
		/// <summary>
		/// The <c>OnVolumeDuckNotification</c> method sends a notification about a pending system ducking event. For more information,
		/// see Implementation Considerations for Ducking Notifications.
		/// </summary>
		/// <param name="sessionID">
		/// A string containing the session instance identifier of the communications session that raises the the auto-ducking event. To
		/// get the session instance identifier, call IAudioSessionControl2::GetSessionInstanceIdentifier.
		/// </param>
		/// <param name="countCommunicationSessions">
		/// The number of active communications sessions. If there are n sessions, the sessions are numbered from 0 to –1.
		/// </param>
		/// <returns>If the method succeeds, it returns S_OK.</returns>
		/// <remarks>
		/// After the application registers its implementation of the IAudioVolumeDuckNotification interface by calling
		/// IAudioSessionManager2::RegisterDuckNotification, the session manager calls <c>OnVolumeDuckNotification</c> when it wants to
		/// send a notification about when ducking begins. The application receives the event notifications in the form of callbacks.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiovolumeducknotification-onvolumeducknotification
		// HRESULT OnVolumeDuckNotification( LPCWSTR sessionID, UINT32 countCommunicationSessions );
		HRESULT OnVolumeDuckNotification([MarshalAs(UnmanagedType.LPWStr)] string sessionID, uint countCommunicationSessions);

		/// <summary>
		/// The <c>OnVolumeUnduckNotification</c> method sends a notification about a pending system unducking event. For more
		/// information, see Implementation Considerations for Ducking Notifications.
		/// </summary>
		/// <param name="sessionID">
		/// A string containing the session instance identifier of the terminating communications session that intiated the ducking. To
		/// get the session instance identifier, call IAudioSessionControl2::GetSessionInstanceIdentifier.
		/// </param>
		/// <returns>If the method succeeds, it returns S_OK.</returns>
		/// <remarks>
		/// After the application registers its implementation of the IAudioVolumeDuckNotification interface by calling
		/// IAudioSessionManager2::RegisterDuckNotification, the session manager calls <c>OnVolumeUnduckNotification</c> when it wants
		/// to send a notification about when ducking ends. The application receives the event notifications in the form of callbacks.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audiopolicy/nf-audiopolicy-iaudiovolumeducknotification-onvolumeunducknotification
		// HRESULT OnVolumeUnduckNotification( LPCWSTR sessionID );
		HRESULT OnVolumeUnduckNotification([MarshalAs(UnmanagedType.LPWStr)] string sessionID);
	}
}