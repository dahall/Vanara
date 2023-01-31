using System;

namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from Windows Core Audio Api.</summary>
public static partial class CoreAudio
{
	/// <summary>
	/// <para>
	/// The AUDCLNT_SESSIONFLAGS_XXX constants indicate characteristics of an audio session associated with the stream. A client can specify
	/// these options during the initialization of the stream by through the StreamFlags parameter of the <c>IAudioClient::Initialize</c> method.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/coreaudio/audclnt-sessionflags-xxx-constants
	[PInvokeData("Audiosessiontypes.h", MSDNShortId = "5745d5bc-71e8-4b33-8227-c1c84226b6ee")]
	public enum AUDCLNT_SESSIONFLAGS : uint
	{
		/// <summary>The session expires when there are no associated streams and owning session control objects holding references.</summary>
		AUDCLNT_SESSIONFLAGS_EXPIREWHENUNOWNED = 0x10000000,

		/// <summary>
		/// The volume control is hidden in the volume mixer user interface when the audio session is created. If the session associated with
		/// the stream already exists before IAudioClient::Initialize opens the stream, the volume control is displayed in the volume mixer.
		/// </summary>
		AUDCLNT_SESSIONFLAGS_DISPLAY_HIDE = 0x20000000,

		/// <summary>The volume control is hidden in the volume mixer user interface after the session expires.</summary>
		AUDCLNT_SESSIONFLAGS_DISPLAY_HIDEWHENEXPIRED = 0x40000000,
	}

	/// <summary>
	/// The <c>AUDCLNT_SHAREMODE</c> enumeration defines constants that indicate whether an audio stream will run in shared mode or in
	/// exclusive mode.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The IAudioClient::Initialize and IAudioClient::IsFormatSupported methods use the constants defined in the <c>AUDCLNT_SHAREMODE</c> enumeration.
	/// </para>
	/// <para>
	/// In shared mode, the client can share the audio endpoint device with clients that run in other user-mode processes. The audio engine
	/// always supports formats for client streams that match the engine's mix format. In addition, the audio engine might support another
	/// format if the Windows audio service can insert system effects into the client stream to convert the client format to the mix format.
	/// </para>
	/// <para>
	/// In exclusive mode, the Windows audio service attempts to establish a connection in which the client has exclusive access to the audio
	/// endpoint device. In this mode, the audio engine inserts no system effects into the local stream to aid in the creation of the
	/// connection point. Either the audio device can handle the specified format directly or the method fails.
	/// </para>
	/// <para>For more information about shared-mode and exclusive-mode streams, see User-Mode Audio Components.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audiosessiontypes/ne-audiosessiontypes-audclnt_sharemode typedef enum
	// _AUDCLNT_SHAREMODE { AUDCLNT_SHAREMODE_SHARED, AUDCLNT_SHAREMODE_EXCLUSIVE } AUDCLNT_SHAREMODE;
	[PInvokeData("audiosessiontypes.h", MSDNShortId = "f4870d0f-85d1-48ad-afe0-2f5a960c08fb")]
	public enum AUDCLNT_SHAREMODE
	{
		/// <summary>The audio stream will run in shared mode. For more information, see Remarks.</summary>
		AUDCLNT_SHAREMODE_SHARED,

		/// <summary>The audio stream will run in exclusive mode. For more information, see Remarks.</summary>
		AUDCLNT_SHAREMODE_EXCLUSIVE,
	}

	/// <summary>Specifies characteristics that a client can assign to an audio stream during the initialization of the stream.</summary>
	/// <remarks>
	/// The <c>IAudioClient::Initialize</c> method and the <c>DIRECTX_AUDIO_ACTIVATION_PARAMS</c> structure use the AUDCLNT_STREAMFLAGS_XXX constants.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/coreaudio/audclnt-streamflags-xxx-constants
	[PInvokeData("Audiosessiontypes.h", MSDNShortId = "7b2267c3-79f5-4ada-a7ce-78dd514f8487")]
	[Flags]
	public enum AUDCLNT_STREAMFLAGS : uint
	{
		/// <summary>
		/// The audio stream will be a member of a cross-process audio session.
		/// <para>
		/// The AUDCLNT_STREAMFLAGS_CROSSPROCESS flag indicates that the audio session for the stream is a cross-process session. A
		/// cross-process session can accept streams from more than one process. If two applications in two separate processes call
		/// <c>IAudioClient::Initialize</c> with identical session GUIDs, and both applications set the AUDCLNT_SHAREMODE_CROSSPROCESS flag,
		/// then the audio engine assigns their streams to the same cross-process session. This flag overrides the default behavior, which is
		/// to assign the stream to a process-specific session rather than a cross-process session. The AUDCLNT_STREAMFLAGS_CROSSPROCESS flag
		/// bit is incompatible with exclusive mode. For more information about cross-process sessions, see Audio Sessions.
		/// </para>
		/// </summary>
		AUDCLNT_STREAMFLAGS_CROSSPROCESS = 0x00010000,

		/// <summary>
		/// The audio stream will operate in loopback mode.
		/// <para>
		/// The AUDCLNT_STREAMFLAGS_LOOPBACK flag enables loopback recording. In loopback recording, the audio engine copies the audio stream
		/// that is being played by a rendering endpoint device into an audio endpoint buffer so that a WASAPI client can capture the stream.
		/// If this flag is set, the <c>IAudioClient::Initialize</c> method attempts to open a capture buffer on the rendering device. This
		/// flag is valid only for a rendering device and only if the <c>Initialize</c> call sets the ShareMode parameter to
		/// AUDCLNT_SHAREMODE_SHARED. Otherwise the <c>Initialize</c> call will fail. If the call succeeds, the client can call the
		/// <c>IAudioClient::GetService</c> method to obtain an <c>IAudioCaptureClient</c> interface on the rendering device. For more
		/// information, see Loopback Recording.
		/// </para>
		/// </summary>
		AUDCLNT_STREAMFLAGS_LOOPBACK = 0x00020000,

		/// <summary>
		/// Processing of the audio buffer by the client will be event driven.
		/// <para>
		/// The AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag enables event-driven buffering. If a client sets this flag in the call to
		/// <c>IAudioClient::Initialize</c> that initializes a stream, the client must subsequently call the
		/// <c>IAudioClient::SetEventHandle</c> method to supply an event handle for the stream. After the stream starts, the audio engine
		/// will signal the event handle to notify the client each time a buffer becomes ready for the client to process. WASAPI supports
		/// event-driven buffering for both rendering and capture buffers. Both shared-mode and exclusive-mode streams can use event-driven
		/// buffering. For a code example that uses the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag, see Exclusive-Mode Streams.
		/// </para>
		/// </summary>
		AUDCLNT_STREAMFLAGS_EVENTCALLBACK = 0x00040000,

		/// <summary>
		/// The volume and mute settings for an audio session will not persist across system restarts.
		/// <para>
		/// The AUDCLNT_STREAMFLAGS_NOPERSIST flag disables persistence of the volume and mute settings for a session that contains rendering
		/// streams. By default, the volume level and muting state for a rendering session are persistent across system restarts. The volume
		/// level and muting state for a capture session are never persistent. For more information about the persistence of session volume
		/// and mute settings, see Audio Sessions.
		/// </para>
		/// </summary>
		AUDCLNT_STREAMFLAGS_NOPERSIST = 0x00080000,

		/// <summary>
		/// This constant is new in Windows 7. The sample rate of the stream is adjusted to a rate specified by an application. For more
		/// information, see Remarks.
		/// </summary>
		AUDCLNT_STREAMFLAGS_RATEADJUST = 0x00100000,

		/// <summary>
		/// Prevents the render stream from being included in any application loopback streams. Note that this stream will continue to be
		/// included in the endpoint loopback stream. This has no effect on Exclusive-Mode Streams. This constant is available starting with
		/// Windows 10, version 1803.
		/// <para>
		/// The AUDCLNT_STREAMFLAGS_RATEADJUST flag enables an application to get a reference to the <c>IAudioClockAdjustment</c> interface
		/// that is used to set the sample rate for the stream. To get a pointer to this interace, an application must initialize the audio
		/// client with this flag and then call <c>IAudioClient::GetService</c> by specifying the <c>IID_IAudioClockAdjustment</c>
		/// identifier. To set the new sample rate, call <c>IAudioClockAdjustment::SetSampleRate</c>. This flag is valid only for a rendering
		/// device. Otherwise the <c>GetService</c> call fails with the error code AUDCLNT_E_WRONG_ENDPOINT_TYPE. The application must also
		/// set the ShareMode parameter to AUDCLNT_SHAREMODE_SHARED during the <c>Initialize</c> call. <c>SetSampleRate</c> fails if the
		/// audio client is not in shared mode.
		/// </para>
		/// </summary>
		AUDCLNT_STREAMFLAGS_PREVENT_LOOPBACK_CAPTURE = 0x01000000,

		/// <summary>
		/// A channel matrixer and a sample rate converter are inserted as necessary to convert between the uncompressed format supplied to
		/// IAudioClient::Initialize and the audio engine mix format.
		/// </summary>
		AUDCLNT_STREAMFLAGS_AUTOCONVERTPCM = 0x80000000,

		/// <summary>
		/// When used with AUDCLNT_STREAMFLAGS_AUTOCONVERTPCM, a sample rate converter with better quality than the default conversion but
		/// with a higher performance cost is used. This should be used if the audio is ultimately intended to be heard by humans as opposed
		/// to other scenarios such as pumping silence or populating a meter.
		/// </summary>
		AUDCLNT_STREAMFLAGS_SRC_DEFAULT_QUALITY = 0x08000000,
	}

	/// <summary>Specifies the category of an audio stream.</summary>
	/// <remarks>
	/// <para>Note that only a subset of the audio stream categories are valid for certain stream types.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Stream type</term>
	/// <term>Valid categories</term>
	/// </listheader>
	/// <item>
	/// <term>Render stream</term>
	/// <term>All categories are valid.</term>
	/// </item>
	/// <item>
	/// <term>Capture stream</term>
	/// <term>AudioCategory_Communications, AudioCategory_Speech, AudioCategory_Other</term>
	/// </item>
	/// <item>
	/// <term>Loopback stream</term>
	/// <term>AudioCategory_Other</term>
	/// </item>
	/// </list>
	/// <para>
	/// Games should categorize their music streams as <c>AudioCategory_GameMedia</c> so that game music mutes automatically if another
	/// application plays music in the background. Music or video applications should categorize their streams as <c>AudioCategory_Media</c>
	/// or <c>AudioCategory_Movie</c> so they will take priority over <c>AudioCategory_GameMedia</c> streams. Game audio for in-game
	/// cinematics or cutscenes, when the audio is premixed or for creative reasons should take priority over background audio, should also
	/// be categorized as <c>Media</c> or <c>Movie</c>.
	/// </para>
	/// <para>
	/// The values <c>AudioCategory_ForegroundOnlyMedia</c> and <c>AudioCategory_BackgroundCapableMedia</c> are deprecated. For Windows Store
	/// apps, these values will continue to function the same when running on Windows 10 as they did on Windows 8.1. Attempting to use these
	/// values in a Universal Windows Platform (UWP) app, will result in compilation errors and an exception at runtime. Using these values
	/// in a Windows desktop application built with the Windows 10 SDK the will result in a compilation error.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audiosessiontypes/ne-audiosessiontypes-audio_stream_category typedef enum
	// _AUDIO_STREAM_CATEGORY { AudioCategory_Other, AudioCategory_ForegroundOnlyMedia, AudioCategory_BackgroundCapableMedia,
	// AudioCategory_Communications, AudioCategory_Alerts, AudioCategory_SoundEffects, AudioCategory_GameEffects, AudioCategory_GameMedia,
	// AudioCategory_GameChat, AudioCategory_Speech, AudioCategory_Movie, AudioCategory_Media } AUDIO_STREAM_CATEGORY;
	[PInvokeData("audiosessiontypes.h", MSDNShortId = "B6B9195A-2704-4633-AFCF-B01CED6B6DB4")]
	public enum AUDIO_STREAM_CATEGORY
	{
		/// <summary>Other audio stream.</summary>
		AudioCategory_Other,

		/// <summary>
		/// Media that will only stream when the app is in the foreground. This enumeration value has been deprecated. For more information,
		/// see the Remarks section.
		/// </summary>
		AudioCategory_ForegroundOnlyMedia,

		/// <summary>
		/// Media that can be streamed when the app is in the background. This enumeration value has been deprecated. For more information,
		/// see the Remarks section.
		/// </summary>
		AudioCategory_BackgroundCapableMedia,

		/// <summary>Real-time communications, such as VOIP or chat.</summary>
		AudioCategory_Communications,

		/// <summary>Alert sounds.</summary>
		AudioCategory_Alerts,

		/// <summary>Sound effects.</summary>
		AudioCategory_SoundEffects,

		/// <summary>Game sound effects.</summary>
		AudioCategory_GameEffects,

		/// <summary>Background audio for games.</summary>
		AudioCategory_GameMedia,

		/// <summary>
		/// Game chat audio. Similar to AudioCategory_Communications except that AudioCategory_GameChat will not attenuate other streams.
		/// </summary>
		AudioCategory_GameChat,

		/// <summary>Speech.</summary>
		AudioCategory_Speech,

		/// <summary>Stream that includes audio with dialog.</summary>
		AudioCategory_Movie,

		/// <summary>Stream that includes audio without dialog.</summary>
		AudioCategory_Media,
	}

	/// <summary>The <c>AudioSessionState</c> enumeration defines constants that indicate the current state of an audio session.</summary>
	/// <remarks>
	/// <para>
	/// When a client opens a session by assigning the first stream to the session (by calling the IAudioClient::Initialize method), the
	/// initial session state is inactive. The session state changes from inactive to active when a stream in the session begins running
	/// (because the client has called the IAudioClient::Start method). The session changes from active to inactive when the client stops the
	/// last running stream in the session (by calling the IAudioClient::Stop method). The session state changes to expired when the client
	/// destroys the last stream in the session by releasing all references to the stream object.
	/// </para>
	/// <para>
	/// The system volume-control program, Sndvol, displays volume controls for both active and inactive sessions. Sndvol stops displaying
	/// the volume control for a session when the session state changes to expired. For more information about Sndvol, see Audio Sessions.
	/// </para>
	/// <para>
	/// The IAudioSessionControl::GetState and IAudioSessionEvents::OnStateChanged methods use the constants defined in the
	/// <c>AudioSessionState</c> enumeration.
	/// </para>
	/// <para>For more information about session states, see Audio Sessions.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audiosessiontypes/ne-audiosessiontypes-audiosessionstate typedef enum
	// _AudioSessionState { AudioSessionStateInactive, AudioSessionStateActive, AudioSessionStateExpired } AudioSessionState;
	[PInvokeData("audiosessiontypes.h", MSDNShortId = "a972fed6-425f-46c8-b0cc-6538460bb104")]
	public enum AudioSessionState
	{
		/// <summary>
		/// The audio session is inactive. (It contains at least one stream, but none of the streams in the session is currently running.)
		/// </summary>
		AudioSessionStateInactive,

		/// <summary>The audio session is active. (At least one of the streams in the session is running.)</summary>
		AudioSessionStateActive,

		/// <summary>The audio session has expired. (It contains no streams.)</summary>
		AudioSessionStateExpired,
	}
}