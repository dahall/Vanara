namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from Windows Core Audio Api.</summary>
public static partial class CoreAudio
{
	/// <summary>The ENDPOINT_HARDWARE_SUPPORT_XXX constants are hardware support flags for an audio endpoint device.</summary>
	/// <remarks>
	/// <para>
	/// The <c>IAudioEndpointVolume::QueryHardwareSupport</c> and <c>IAudioMeterInformation::QueryHardwareSupport</c> methods use the
	/// ENDPOINT_HARDWARE_SUPPORT_XXX constants.
	/// </para>
	/// <para>
	/// A hardware support mask indicates which functions an audio endpoint device implements in hardware. The mask can be either 0 or
	/// the bitwise-OR combination of one or more ENDPOINT_HARDWARE_SUPPORT_XXX constants. If a bit that corresponds to a particular
	/// ENDPOINT_HARDWARE_SUPPORT_XXX constant is set in the mask, then the meaning is that the function represented by that constant is
	/// implemented in hardware by the device.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/coreaudio/endpoint-hardware-support-xxx-constants
	[PInvokeData("endpointvolume.h", MSDNShortId = "54032f75-2287-4589-bda5-e005ee077c41")]
	[Flags]
	public enum ENDPOINT_HARDWARE_SUPPORT
	{
		/// <summary>The audio endpoint device supports a hardware volume control.</summary>
		ENDPOINT_HARDWARE_SUPPORT_VOLUME = 0x00000001,

		/// <summary>The audio endpoint device supports a hardware mute control.</summary>
		ENDPOINT_HARDWARE_SUPPORT_MUTE = 0x00000002,

		/// <summary>The audio endpoint device supports a hardware peak meter.</summary>
		ENDPOINT_HARDWARE_SUPPORT_METER = 0x00000004,
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioEndpointVolume</c> interface represents the volume controls on the audio stream to or from an audio endpoint
	/// device. A client obtains a reference to the <c>IAudioEndpointVolume</c> interface of an endpoint device by calling the
	/// IMMDevice::Activate method with parameter iid set to REFIID IID_IAudioEndpointVolume.
	/// </para>
	/// <para>
	/// Audio applications that use the MMDevice API and WASAPI typically use the ISimpleAudioVolume interface to manage stream volume
	/// levels on a per-session basis. In rare cases, a specialized audio application might require the use of the
	/// <c>IAudioEndpointVolume</c> interface to control the master volume level of an audio endpoint device. A client of
	/// <c>IAudioEndpointVolume</c> must take care to avoid the potentially disruptive effects on other audio applications of altering
	/// the master volume levels of audio endpoint devices. Typically, the user has exclusive control over the master volume levels
	/// through the Windows volume-control program, Sndvol.exe.
	/// </para>
	/// <para>
	/// If the adapter device that streams audio data to or from the endpoint device has hardware volume and mute controls, the
	/// <c>IAudioEndpointVolume</c> interface uses those controls to manage the volume and mute settings of the audio stream. If the
	/// audio device lacks a hardware volume control for the stream, the audio engine automatically implements volume and mute controls
	/// in software.
	/// </para>
	/// <para>
	/// For applications that manage shared-mode streams to and from endpoint devices, the behavior of the <c>IAudioEndpointVolume</c>
	/// is different for rendering streams and capture streams.
	/// </para>
	/// <para>
	/// For a shared-mode rendering stream, the endpoint volume control that the client accesses through the <c>IAudioEndpointVolume</c>
	/// interface operates independently of the per-session volume controls that the <c>ISimpleAudioVolume</c> and IChannelAudioVolume
	/// interfaces implement. Thus, the volume level of the rendering stream results from the combined effects of the endpoint volume
	/// control and per-session controls.
	/// </para>
	/// <para>
	/// For a shared-mode capture stream, the per-session volume controls that the <c>ISimpleAudioVolume</c> and
	/// <c>IChannelAudioVolume</c> interfaces implement are tied directly to the endpoint volume control implemented by the
	/// <c>IAudioEndpointVolume</c> interface. Changing the per-session volume control through the methods in the
	/// <c>ISimpleAudioVolume</c> and <c>IChannelAudioVolume</c> interfaces changes the setting of the <c>IAudioEndpointVolume</c>
	/// interface's volume control, and the reverse is also true. The volume levels represented by each of the interfaces correspond to
	/// each other as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// For each channel in a stream, <c>IAudioEndpointVolume</c> provides audio-tapered volume levels expressed in decibels (dB), that
	/// are mapped to normalized values in the range from 0.0 (minimum volume) to 1.0 (maximum volume). The possible range is dependent
	/// on the audio driver. See IAudioEndpointVolume::GetVolumeRange for details.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The session volume represented by ISimpleAudioVolume::GetMasterVolume is the scalar value ranging from 0.0 to 1.0 that
	/// corresponds to the highest volume setting across the various channels. So, for example, if the left channel is set to 0.8, and
	/// the right channel is set to 0.4, then <c>ISimpleAudioVolume::GetMasterVolume</c> will return 0.8.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// When the per-channel volume level is controlled through the methods in the IChannelAudioVolume interface, the scalar indicating
	/// volume is always relative to the session volume. This means that the channel or channels with the highest volume has a volume of
	/// 1.0. Given the example of two channels, set to volumes of 0.8 and 0.4 by IAudioEndpointVolume::SetChannelVolumeLevelScalar,
	/// IChannelAudioVolume::GetChannelVolume will indicate volumes of 1.0 and 0.5.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> Clients of the <c>EndpointVolume</c> API should not rely on the preceding behavior because it might change in future releases.
	/// </para>
	/// <para>
	/// If a device has hardware volume and mute controls, changes made to the device's volume and mute settings through the
	/// <c>IAudioEndpointVolume</c> interface affect the volume level in both shared mode and exclusive mode. If a device lacks hardware
	/// volume and mute controls, changes made to the software volume and mute controls through the <c>IAudioEndpointVolume</c>
	/// interface affect the volume level in shared mode, but not in exclusive mode. In exclusive mode, the client and the device
	/// exchange audio data directly, bypassing the software controls. However, the software controls are persistent, and volume changes
	/// made while the device operates in exclusive mode take effect when the device switches to shared-mode operation.
	/// </para>
	/// <para>
	/// To determine whether a device has hardware volume and mute controls, call the IAudioEndpointVolume::QueryHardwareSupport method.
	/// </para>
	/// <para>
	/// The methods of the <c>IAudioEndpointVolume</c> interface enable the client to express volume levels either in decibels or as
	/// normalized, audio-tapered values. In the latter case, a volume level is expressed as a floating-point value in the normalized
	/// range from 0.0 (minimum volume) to 1.0 (maximum volume). Within this range, the relationship of the normalized volume level to
	/// the attenuation of signal amplitude is described by a nonlinear, audio-tapered curve. For more information about audio-tapered
	/// curves, see Audio-Tapered Volume Controls.
	/// </para>
	/// <para>
	/// In addition, to conveniently support volume sliders in user interfaces, the <c>IAudioEndpointVolume</c> interface enables
	/// clients to set and get volume levels that are expressed as discrete values or "steps". The steps are uniformly distributed over
	/// a nonlinear, audio-tapered curve. If the range contains n steps, the steps are numbered from 0 to n– 1, where step 0 represents
	/// the minimum volume level and step n– 1 represents the maximum.
	/// </para>
	/// <para>For a code example that uses the <c>IAudioEndpointVolume</c> interface, see Endpoint Volume Controls.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nn-endpointvolume-iaudioendpointvolume
	[PInvokeData("endpointvolume.h", MSDNShortId = "5e3e7ffc-8822-4b1b-b9af-206ec1e767e2")]
	[ComImport, Guid("5CDF2C82-841E-4546-9722-0CF74078229A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioEndpointVolume
	{
		/// <summary>The <c>RegisterControlChangeNotify</c> method registers a client's notification callback interface.</summary>
		/// <param name="pNotify">
		/// Pointer to the IAudioEndpointVolumeCallback interface that the client is registering for notification callbacks. If the
		/// <c>RegisterControlChangeNotify</c> method succeeds, it calls the AddRef method on the client's
		/// <c>IAudioEndpointVolumeCallback</c> interface.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method registers an IAudioEndpointVolumeCallback interface to be called by the system when the volume level or muting
		/// state of an endpoint changes. The caller implements the <c>IAudioEndpointVolumeCallback</c> interface.
		/// </para>
		/// <para>
		/// When notifications are no longer needed, the client can call the IAudioEndpointVolume::UnregisterControlChangeNotify method
		/// to terminate the notifications.
		/// </para>
		/// <para>
		/// Before the client releases its final reference to the IAudioEndpointVolumeCallback interface, it should call
		/// UnregisterControlChangeNotify to unregister the interface. Otherwise, the application leaks the resources held by the
		/// <c>IAudioEndpointVolumeCallback</c> and IAudioEndpointVolume objects. Note that <c>RegisterControlChangeNotify</c> calls the
		/// client's IAudioEndpointVolumeCallback::AddRef method, and <c>UnregisterControlChangeNotify</c> calls the
		/// IAudioEndpointVolumeCallback::Release method. If the client errs by releasing its reference to the
		/// <c>IAudioEndpointVolumeCallback</c> interface before calling <c>UnregisterControlChangeNotify</c>, the
		/// <c>IAudioEndpointVolume</c> object never releases its reference to the <c>IAudioEndpointVolumeCallback</c> interface. For
		/// example, a poorly designed <c>IAudioEndpointVolumeCallback</c> implementation might call
		/// <c>UnregisterControlChangeNotify</c> from the destructor for the <c>IAudioEndpointVolumeCallback</c> object. In this case,
		/// the client will not call <c>UnregisterControlChangeNotify</c> until the <c>IAudioEndpointVolume</c> object releases its
		/// reference to the <c>IAudioEndpointVolumeCallback</c> interface, and the <c>IAudioEndpointVolume</c> object will not release
		/// its reference to the <c>IAudioEndpointVolumeCallback</c> interface until the client calls
		/// <c>UnregisterControlChangeNotify</c>. For more information about the <c>AddRef</c> and <c>Release</c> methods, see the
		/// discussion of the IUnknown interface in the Windows SDK documentation.
		/// </para>
		/// <para>
		/// In addition, the client should call UnregisterControlChangeNotify before releasing the final reference to the
		/// IAudioEndpointVolume object. Otherwise, the object leaks the storage that it allocated to hold the registration information.
		/// After registering a notification interface, the client continues to receive notifications for only as long as the
		/// <c>IAudioEndpointVolume</c> object exists.
		/// </para>
		/// <para>For a code example that calls <c>RegisterControlChangeNotify</c>, see Endpoint Volume Controls.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-registercontrolchangenotify
		// HRESULT RegisterControlChangeNotify( IAudioEndpointVolumeCallback *pNotify );
		void RegisterControlChangeNotify([In] IAudioEndpointVolumeCallback pNotify);

		/// <summary>
		/// The <c>UnregisterControlChangeNotify</c> method deletes the registration of a client's notification callback interface that
		/// the client registered in a previous call to the IAudioEndpointVolume::RegisterControlChangeNotify method.
		/// </summary>
		/// <param name="pNotify">
		/// Pointer to the client's IAudioEndpointVolumeCallback interface. The client passed this same interface pointer to the
		/// endpoint volume object in a previous call to the IAudioEndpointVolume::RegisterControlChangeNotify method. If the
		/// <c>UnregisterControlChangeNotify</c> method succeeds, it calls the Release method on the client's
		/// <c>IAudioEndpointVolumeCallback</c> interface.
		/// </param>
		/// <remarks>
		/// <para>
		/// Before the client releases its final reference to the IAudioEndpointVolumeCallback interface, it should call
		/// <c>UnregisterControlChangeNotify</c> to unregister the interface. Otherwise, the application leaks the resources held by the
		/// <c>IAudioEndpointVolumeCallback</c> and IAudioEndpointVolume objects. Note that the
		/// IAudioEndpointVolume::RegisterControlChangeNotify method calls the client's IAudioEndpointVolumeCallback::AddRef method, and
		/// <c>UnregisterControlChangeNotify</c> calls the IAudioEndpointVolumeCallback::Release method. If the client errs by releasing
		/// its reference to the <c>IAudioEndpointVolumeCallback</c> interface before calling <c>UnregisterControlChangeNotify</c>, the
		/// <c>IAudioEndpointVolume</c> object never releases its reference to the <c>IAudioEndpointVolumeCallback</c> interface. For
		/// example, a poorly designed <c>IAudioEndpointVolumeCallback</c> implementation might call
		/// <c>UnregisterControlChangeNotify</c> from the destructor for the <c>IAudioEndpointVolumeCallback</c> object. In this case,
		/// the client will not call <c>UnregisterControlChangeNotify</c> until the <c>IAudioEndpointVolume</c> object releases its
		/// reference to the <c>IAudioEndpointVolumeCallback</c> interface, and the <c>IAudioEndpointVolume</c> object will not release
		/// its reference to the <c>IAudioEndpointVolumeCallback</c> interface until the client calls
		/// <c>UnregisterControlChangeNotify</c>. For more information about the <c>AddRef</c> and <c>Release</c> methods, see the
		/// discussion of the IUnknown interface in the Windows SDK documentation.
		/// </para>
		/// <para>For a code example that calls <c>UnregisterControlChangeNotify</c>, see Endpoint Volume Controls.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-unregistercontrolchangenotify
		// HRESULT UnregisterControlChangeNotify( IAudioEndpointVolumeCallback *pNotify );
		void UnregisterControlChangeNotify([In] IAudioEndpointVolumeCallback pNotify);

		/// <summary>
		/// The <c>GetChannelCount</c> method gets a count of the channels in the audio stream that enters or leaves the audio endpoint device.
		/// </summary>
		/// <returns>A <c>UINT</c> variable into which the method writes the channel count.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-getchannelcount
		// HRESULT GetChannelCount( UINT *pnChannelCount );
		uint GetChannelCount();

		/// <summary>
		/// The <c>SetMasterVolumeLevel</c> method sets the master volume level, in decibels, of the audio stream that enters or leaves
		/// the audio endpoint device.
		/// </summary>
		/// <param name="fLevelDB">
		/// The new master volume level in decibels. To obtain the range and granularity of the volume levels that can be set by this
		/// method, call the IAudioEndpointVolume::GetVolumeRange method.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IAudioEndpointVolumeCallback::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetMasterVolumeLevel</c> call changes the volume level of the endpoint, all clients that have registered
		/// IAudioEndpointVolumeCallback interfaces with that endpoint will receive notifications. In its implementation of the
		/// <c>OnNotify</c> method, a client can inspect the event-context GUID to discover whether it or another client is the source
		/// of the volume-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the notification routine
		/// receives the context GUID value GUID_NULL.
		/// </param>
		/// <remarks>
		/// If volume level fLevelDB falls outside of the volume range reported by the <c>IAudioEndpointVolume::GetVolumeRange</c>
		/// method, the <c>SetMasterVolumeLevel</c> call fails and returns error code E_INVALIDARG.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-setmastervolumelevel
		// HRESULT SetMasterVolumeLevel( float fLevelDB, LPCGUID pguidEventContext );
		void SetMasterVolumeLevel([In] float fLevelDB, in Guid pguidEventContext);

		/// <summary>
		/// The <c>SetMasterVolumeLevelScalar</c> method sets the master volume level of the audio stream that enters or leaves the
		/// audio endpoint device. The volume level is expressed as a normalized, audio-tapered value in the range from 0.0 to 1.0.
		/// </summary>
		/// <param name="fLevel">
		/// The new master volume level. The level is expressed as a normalized value in the range from 0.0 to 1.0.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IAudioEndpointVolumeCallback::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetMasterVolumeLevelScalar</c> call changes the volume level of the endpoint, all clients that have registered
		/// IAudioEndpointVolumeCallback interfaces with that endpoint will receive notifications. In its implementation of the
		/// <c>OnNotify</c> method, a client can inspect the event-context GUID to discover whether it or another client is the source
		/// of the volume-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the notification routine
		/// receives the context GUID value GUID_NULL.
		/// </param>
		/// <remarks>
		/// <para>
		/// The volume level is normalized to the range from 0.0 to 1.0, where 0.0 is the minimum volume level and 1.0 is the maximum
		/// level. Within this range, the relationship of the normalized volume level to the attenuation of signal amplitude is
		/// described by a nonlinear, audio-tapered curve. Note that the shape of the curve might change in future versions of Windows.
		/// For more information about audio-tapered curves, see Audio-Tapered Volume Controls.
		/// </para>
		/// <para>
		/// The normalized volume levels that are passed to this method are suitable to represent the positions of volume controls in
		/// application windows and on-screen displays.
		/// </para>
		/// <para>For a code example that calls <c>SetMasterVolumeLevelScalar</c>, see Endpoint Volume Controls.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-setmastervolumelevelscalar
		// HRESULT SetMasterVolumeLevelScalar( float fLevel, LPCGUID pguidEventContext );
		void SetMasterVolumeLevelScalar([In] float fLevel, in Guid pguidEventContext);

		/// <summary>
		/// The <c>GetMasterVolumeLevel</c> method gets the master volume level, in decibels, of the audio stream that enters or leaves
		/// the audio endpoint device.
		/// </summary>
		/// <returns>
		/// The master volume level. This parameter points to a <c>float</c> variable into which the method writes the volume level in
		/// decibels. To get the range of volume levels obtained from this method, call the IAudioEndpointVolume::GetVolumeRange method.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-getmastervolumelevel
		// HRESULT GetMasterVolumeLevel( float *pfLevelDB );
		float GetMasterVolumeLevel();

		/// <summary>
		/// The <c>GetMasterVolumeLevelScalar</c> method gets the master volume level of the audio stream that enters or leaves the
		/// audio endpoint device. The volume level is expressed as a normalized, audio-tapered value in the range from 0.0 to 1.0.
		/// </summary>
		/// <returns>
		/// The master volume level. This parameter points to a <c>float</c> variable into which the method writes the volume level. The
		/// level is expressed as a normalized value in the range from 0.0 to 1.0.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The volume level is normalized to the range from 0.0 to 1.0, where 0.0 is the minimum volume level and 1.0 is the maximum
		/// level. Within this range, the relationship of the normalized volume level to the attenuation of signal amplitude is
		/// described by a nonlinear, audio-tapered curve. Note that the shape of the curve might change in future versions of Windows.
		/// For more information about audio-tapered curves, see Audio-Tapered Volume Controls.
		/// </para>
		/// <para>
		/// The normalized volume levels that are retrieved by this method are suitable to represent the positions of volume controls in
		/// application windows and on-screen displays.
		/// </para>
		/// <para>For a code example that calls <c>GetMasterVolumeLevelScalar</c>, see Endpoint Volume Controls.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-getmastervolumelevelscalar
		// HRESULT GetMasterVolumeLevelScalar( float *pfLevel );
		float GetMasterVolumeLevelScalar();

		/// <summary>
		/// The <c>SetChannelVolumeLevel</c> method sets the volume level, in decibels, of the specified channel of the audio stream
		/// that enters or leaves the audio endpoint device.
		/// </summary>
		/// <param name="nChannel">
		/// The channel number. If the audio stream contains n channels, the channels are numbered from 0 to n– 1. To obtain the number
		/// of channels, call the IAudioEndpointVolume::GetChannelCount method.
		/// </param>
		/// <param name="fLevelDB">
		/// The new volume level in decibels. To obtain the range and granularity of the volume levels that can be set by this method,
		/// call the IAudioEndpointVolume::GetVolumeRange method.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IAudioEndpointVolumeCallback::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetChannelVolumeLevel</c> call changes the volume level of the endpoint, all clients that have registered
		/// IAudioEndpointVolumeCallback interfaces with that endpoint will receive notifications. In its implementation of the
		/// <c>OnNotify</c> method, a client can inspect the event-context GUID to discover whether it or another client is the source
		/// of the volume-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the notification routine
		/// receives the context GUID value GUID_NULL.
		/// </param>
		/// <remarks>
		/// If volume level fLevelDB falls outside of the volume range reported by the <c>IAudioEndpointVolume::GetVolumeRange</c>
		/// method, the <c>SetChannelVolumeLevel</c> call fails and returns error code E_INVALIDARG.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-setchannelvolumelevel
		// HRESULT SetChannelVolumeLevel( UINT nChannel, float fLevelDB, LPCGUID pguidEventContext );
		void SetChannelVolumeLevel([In] uint nChannel, float fLevelDB, in Guid pguidEventContext);

		/// <summary>
		/// The <c>SetChannelVolumeLevelScalar</c> method sets the normalized, audio-tapered volume level of the specified channel in
		/// the audio stream that enters or leaves the audio endpoint device.
		/// </summary>
		/// <param name="nChannel">
		/// The channel number. If the audio stream contains n channels, the channels are numbered from 0 to n– 1. To obtain the number
		/// of channels, call the IAudioEndpointVolume::GetChannelCount method.
		/// </param>
		/// <param name="fLevel">The volume level. The volume level is expressed as a normalized value in the range from 0.0 to 1.0.</param>
		/// <param name="pguidEventContext">
		/// Context value for the IAudioEndpointVolumeCallback::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetChannelVolumeLevelScalar</c> call changes the volume level of the endpoint, all clients that have registered
		/// IAudioEndpointVolumeCallback interfaces with that endpoint will receive notifications. In its implementation of the
		/// <c>OnNotify</c> method, a client can inspect the event-context GUID to discover whether it or another client is the source
		/// of the volume-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the notification routine
		/// receives the context GUID value GUID_NULL.
		/// </param>
		/// <remarks>
		/// <para>
		/// The volume level is normalized to the range from 0.0 to 1.0, where 0.0 is the minimum volume level and 1.0 is the maximum
		/// level. Within this range, the relationship of the normalized volume level to the attenuation of signal amplitude is
		/// described by a nonlinear, audio-tapered curve. Note that the shape of the curve might change in future versions of Windows.
		/// For more information about audio-tapered curves, see Audio-Tapered Volume Controls.
		/// </para>
		/// <para>
		/// The normalized volume levels that are passed to this method are suitable to represent the positions of volume controls in
		/// application windows and on-screen displays.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-setchannelvolumelevelscalar
		// HRESULT SetChannelVolumeLevelScalar( UINT nChannel, float fLevel, LPCGUID pguidEventContext );
		void SetChannelVolumeLevelScalar([In] uint nChannel, float fLevel, in Guid pguidEventContext);

		/// <summary>
		/// The <c>GetChannelVolumeLevel</c> method gets the volume level, in decibels, of the specified channel in the audio stream
		/// that enters or leaves the audio endpoint device.
		/// </summary>
		/// <param name="nChannel">
		/// The channel number. If the audio stream has n channels, the channels are numbered from 0 to n– 1. To obtain the number of
		/// channels in the stream, call the IAudioEndpointVolume::GetChannelCount method.
		/// </param>
		/// <returns>
		/// A <c>float</c> variable into which the method writes the volume level in decibels. To get the range of volume levels
		/// obtained from this method, call the IAudioEndpointVolume::GetVolumeRange method.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-getchannelvolumelevel
		// HRESULT GetChannelVolumeLevel( UINT nChannel, float *pfLevelDB );
		float GetChannelVolumeLevel([In] uint nChannel);

		/// <summary>
		/// The <c>GetChannelVolumeLevelScalar</c> method gets the normalized, audio-tapered volume level of the specified channel of
		/// the audio stream that enters or leaves the audio endpoint device.
		/// </summary>
		/// <param name="nChannel">
		/// The channel number. If the audio stream contains n channels, the channels are numbered from 0 to n– 1. To obtain the number
		/// of channels, call the IAudioEndpointVolume::GetChannelCount method.
		/// </param>
		/// <returns>
		/// A <c>float</c> variable into which the method writes the volume level. The level is expressed as a normalized value in the
		/// range from 0.0 to 1.0.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The volume level is normalized to the range from 0.0 to 1.0, where 0.0 is the minimum volume level and 1.0 is the maximum
		/// level. Within this range, the relationship of the normalized volume level to the attenuation of signal amplitude is
		/// described by a nonlinear, audio-tapered curve. Note that the shape of the curve might change in future versions of Windows.
		/// For more information about audio-tapered curves, see Audio-Tapered Volume Controls.
		/// </para>
		/// <para>
		/// The normalized volume levels that are retrieved by this method are suitable to represent the positions of volume controls in
		/// application windows and on-screen displays.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-getchannelvolumelevelscalar
		// HRESULT GetChannelVolumeLevelScalar( UINT nChannel, float *pfLevel );
		float GetChannelVolumeLevelScalar([In] uint nChannel);

		/// <summary>
		/// The <c>SetMute</c> method sets the muting state of the audio stream that enters or leaves the audio endpoint device.
		/// </summary>
		/// <param name="bMute">
		/// The new muting state. If bMute is <c>TRUE</c>, the method mutes the stream. If <c>FALSE</c>, the method turns off muting.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IAudioEndpointVolumeCallback::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetMute</c> call changes the muting state of the endpoint, all clients that have registered IAudioEndpointVolumeCallback
		/// interfaces with that endpoint will receive notifications. In its implementation of the <c>OnNotify</c> method, a client can
		/// inspect the event-context GUID to discover whether it or another client is the source of the control-change event. If the
		/// caller supplies a <c>NULL</c> pointer for this parameter, the notification routine receives the context GUID value GUID_NULL.
		/// </param>
		/// <remarks>For a code example that calls <c>SetMute</c>, see Endpoint Volume Controls.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-setmute HRESULT
		// SetMute( BOOL bMute, LPCGUID pguidEventContext );
		void SetMute([In] [MarshalAs(UnmanagedType.Bool)] bool bMute, in Guid pguidEventContext);

		/// <summary>
		/// The <c>GetMute</c> method gets the muting state of the audio stream that enters or leaves the audio endpoint device.
		/// </summary>
		/// <returns>
		/// A <c>BOOL</c> variable into which the method writes the muting state. If *pbMute is <c>TRUE</c>, the stream is muted. If
		/// <c>FALSE</c>, the stream is not muted.
		/// </returns>
		/// <remarks>For a code example that calls <c>GetMute</c>, see Endpoint Volume Controls.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-getmute HRESULT
		// GetMute( BOOL *pbMute );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetMute();

		/// <summary>The <c>GetVolumeStepInfo</c> method gets information about the current step in the volume range.</summary>
		/// <param name="pnStep">
		/// Pointer to a <c>UINT</c> variable into which the method writes the current step index. This index is a value in the range
		/// from 0 to *pStepCount– 1, where 0 represents the minimum volume level and *pStepCount– 1 represents the maximum level.
		/// </param>
		/// <param name="pnStepCount">
		/// Pointer to a <c>UINT</c> variable into which the method writes the number of steps in the volume range. This number remains
		/// constant for the lifetime of the IAudioEndpointVolume interface instance.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method represents the volume level of the audio stream that enters or leaves the audio endpoint device as an index or
		/// "step" in a range of discrete volume levels. Output value *pnStepCount is the number of steps in the range. Output value
		/// *pnStep is the step index of the current volume level. If the number of steps is n = *pnStepCount, then step index *pnStep
		/// can assume values from 0 (minimum volume) to n – 1 (maximum volume).
		/// </para>
		/// <para>
		/// Over the range from 0 to n – 1, successive intervals between adjacent steps do not necessarily represent uniform volume
		/// increments in either linear signal amplitude or decibels. In Windows Vista, <c>GetVolumeStepInfo</c> defines the
		/// relationship of index to volume level (signal amplitude) to be an audio-tapered curve. Note that the shape of the curve
		/// might change in future versions of Windows. For more information about audio-tapered curves, see Audio-Tapered Volume Controls.
		/// </para>
		/// <para>
		/// Audio applications can call the IAudioEndpointVolume::VolumeStepUp and IAudioEndpointVolume::VolumeStepDown methods to
		/// increase or decrease the volume level by one interval. Either method first calculates the idealized volume level that
		/// corresponds to the next point on the audio-tapered curve. Next, the method selects the endpoint volume setting that is the
		/// best approximation to the idealized level. To obtain the range and granularity of the endpoint volume settings, call the
		/// IEndpointVolume::GetVolumeRange method. If the audio endpoint device implements a hardware volume control,
		/// <c>GetVolumeRange</c> describes the hardware volume settings. Otherwise, the EndpointVolume API implements the endpoint
		/// volume control in software, and <c>GetVolumeRange</c> describes the volume settings of the software-implemented control.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-getvolumestepinfo
		// HRESULT GetVolumeStepInfo( UINT *pnStep, UINT *pnStepCount );
		void GetVolumeStepInfo(out uint pnStep, out uint pnStepCount);

		/// <summary>
		/// The <c>VolumeStepUp</c> method increments, by one step, the volume level of the audio stream that enters or leaves the audio
		/// endpoint device.
		/// </summary>
		/// <param name="pguidEventContext">
		/// Context value for the IAudioEndpointVolumeCallback::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>VolumeStepUp</c> call changes the volume level of the endpoint, all clients that have registered
		/// IAudioEndpointVolumeCallback interfaces with that endpoint will receive notifications. In its implementation of the
		/// <c>OnNotify</c> method, a client can inspect the event-context GUID to discover whether it or another client is the source
		/// of the volume-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the client's notification
		/// method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// <para>
		/// To obtain the current volume step and the total number of steps in the volume range, call the
		/// IAudioEndpointVolume::GetVolumeStepInfo method.
		/// </para>
		/// <para>
		/// If the volume level is already at the highest step in the volume range, the call to <c>VolumeStepUp</c> has no effect and
		/// returns status code S_OK.
		/// </para>
		/// <para>
		/// Successive intervals between adjacent steps do not necessarily represent uniform volume increments in either linear signal
		/// amplitude or decibels. In Windows Vista, <c>VolumeStepUp</c> defines the relationship of step index to volume level (signal
		/// amplitude) to be an audio-tapered curve. Note that the shape of the curve might change in future versions of Windows. For
		/// more information about audio-tapered curves, see Audio-Tapered Volume Controls.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-volumestepup HRESULT
		// VolumeStepUp( LPCGUID pguidEventContext );
		void VolumeStepUp(in Guid pguidEventContext);

		/// <summary>
		/// The <c>VolumeStepDown</c> method decrements, by one step, the volume level of the audio stream that enters or leaves the
		/// audio endpoint device.
		/// </summary>
		/// <param name="pguidEventContext">
		/// Context value for the IAudioEndpointVolumeCallback::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>VolumeStepDown</c> call changes the volume level of the endpoint, all clients that have registered
		/// IAudioEndpointVolumeCallback interfaces with that endpoint will receive notifications. In its implementation of the
		/// <c>OnNotify</c> method, a client can inspect the event-context GUID to discover whether it or another client is the source
		/// of the volume-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the client's notification
		/// method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// <para>
		/// To obtain the current volume step and the total number of steps in the volume range, call the
		/// IAudioEndpointVolume::GetVolumeStepInfo method.
		/// </para>
		/// <para>
		/// If the volume level is already at the lowest step in the volume range, the call to <c>VolumeStepDown</c> has no effect and
		/// returns status code S_OK.
		/// </para>
		/// <para>
		/// Successive intervals between adjacent steps do not necessarily represent uniform volume increments in either linear signal
		/// amplitude or decibels. In Windows Vista, <c>VolumeStepDown</c> defines the relationship of step index to volume level
		/// (signal amplitude) to be an audio-tapered curve. Note that the shape of the curve might change in future versions of
		/// Windows. For more information about audio-tapered curves, see Audio-Tapered Volume Controls.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-volumestepdown
		// HRESULT VolumeStepDown( LPCGUID pguidEventContext );
		void VolumeStepDown(in Guid pguidEventContext);

		/// <summary>The QueryHardwareSupport method queries the audio endpoint device for its hardware-supported functions.</summary>
		/// <returns>
		/// A <c>DWORD</c> variable into which the method writes a hardware support mask that indicates the hardware capabilities of the
		/// audio endpoint device. The method can set the mask to 0 or to the bitwise-OR combination of one or more
		/// ENDPOINT_HARDWARE_SUPPORT_XXX constants.
		/// </returns>
		/// <remarks>
		/// <para>This method indicates whether the audio endpoint device implements the following functions in hardware:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Volume control</term>
		/// </item>
		/// <item>
		/// <term>Mute control</term>
		/// </item>
		/// <item>
		/// <term>Peak meter</term>
		/// </item>
		/// </list>
		/// <para>
		/// The system automatically substitutes a software implementation for any function in the preceding list that the endpoint
		/// device does not implement in hardware.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-queryhardwaresupport
		// HRESULT QueryHardwareSupport( DWORD *pdwHardwareSupportMask );
		ENDPOINT_HARDWARE_SUPPORT QueryHardwareSupport();

		/// <summary>
		/// The <c>GetVolumeRange</c> method gets the volume range, in decibels, of the audio stream that enters or leaves the audio
		/// endpoint device.
		/// </summary>
		/// <param name="pflVolumeMindB">
		/// Pointer to the minimum volume level. This parameter points to a <c>float</c> variable into which the method writes the
		/// minimum volume level in decibels. This value remains constant for the lifetime of the IAudioEndpointVolume interface instance.
		/// </param>
		/// <param name="pflVolumeMaxdB">
		/// Pointer to the maximum volume level. This parameter points to a <c>float</c> variable into which the method writes the
		/// maximum volume level in decibels. This value remains constant for the lifetime of the <c>IAudioEndpointVolume</c> interface instance.
		/// </param>
		/// <param name="pflVolumeIncrementdB">
		/// Pointer to the volume increment. This parameter points to a <c>float</c> variable into which the method writes the volume
		/// increment in decibels. This increment remains constant for the lifetime of the <c>IAudioEndpointVolume</c> interface instance.
		/// </param>
		/// <remarks>
		/// <para>
		/// The volume range from vmin = *pfLevelMinDB to vmax = *pfLevelMaxDB is divided into n uniform intervals of size vinc =
		/// *pfVolumeIncrementDB, where
		/// </para>
		/// <para>n = (vmax – vmin) / vinc.</para>
		/// <para>
		/// The values vmin, vmax, and vinc are measured in decibels. The client can set the volume level to one of n + 1 discrete
		/// values in the range from vmin to vmax.
		/// </para>
		/// <para>
		/// The IAudioEndpointVolume::SetChannelVolumeLevel and IAudioEndpointVolume::SetMasterVolumeLevel methods accept only volume
		/// levels in the range from vmin to vmax. If the caller specifies a volume level outside of this range, the method fails and
		/// returns E_INVALIDARG. If the caller specifies a volume level that falls between two steps in the volume range, the method
		/// sets the endpoint volume level to the step that lies closest to the requested volume level and returns S_OK. However, a
		/// subsequent call to IAudioEndpointVolume::GetChannelVolumeLevel or IAudioEndpointVolume::GetMasterVolumeLevel retrieves the
		/// volume level requested by the previous call to <c>SetChannelVolumeLevel</c> or <c>SetMasterVolumeLevel</c>, not the step value.
		/// </para>
		/// <para>
		/// If the volume control is implemented in hardware, <c>GetVolumeRange</c> describes the range and granularity of the hardware
		/// volume settings. In contrast, the steps that are reported by the IEndpointVolume::GetVolumeStepInfo method correspond to
		/// points on an audio-tapered curve that are calculated in software by the IEndpointVolume::VolumeStepDown and
		/// IEndpointVolume::VolumeStepUp methods. Either method first calculates the idealized volume level that corresponds to the
		/// next point on the curve. Next, the method selects the hardware volume setting that is the best approximation to the
		/// idealized level. For more information about audio-tapered curves, see Audio-Tapered Volume Controls.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-getvolumerange
		// HRESULT GetVolumeRange( float *pflVolumeMindB, float *pflVolumeMaxdB, float *pflVolumeIncrementdB );
		void GetVolumeRange(out float pflVolumeMindB, out float pflVolumeMaxdB, out float pflVolumeIncrementdB);
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioEndpointVolumeCallback</c> interface provides notifications of changes in the volume level and muting state of an
	/// audio endpoint device. Unlike the other interfaces in this section, which are implemented by the WASAPI system component, an
	/// EndpointVolume API client implements the <c>IAudioEndpointVolumeCallback</c> interface. To receive event notifications, the
	/// client passes a pointer to its <c>IAudioEndpointVolumeCallback</c> interface to the
	/// IAudioEndpointVolume::RegisterControlChangeNotify method.
	/// </para>
	/// <para>
	/// After registering its <c>IAudioEndpointVolumeCallback</c> interface, the client receives event notifications in the form of
	/// callbacks through the <c>OnNotify</c> method in the interface. These event notifications occur when one of the following methods
	/// causes a change in the volume level or muting state of an endpoint device:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>IAudioEndpointVolume::SetChannelVolumeLevel</term>
	/// </item>
	/// <item>
	/// <term>IAudioEndpointVolume::SetChannelVolumeLevelScalar</term>
	/// </item>
	/// <item>
	/// <term>IAudioEndpointVolume::SetMasterVolumeLevel</term>
	/// </item>
	/// <item>
	/// <term>IAudioEndpointVolume::SetMasterVolumeLevelScalar</term>
	/// </item>
	/// <item>
	/// <term>IAudioEndpointVolume::SetMute</term>
	/// </item>
	/// <item>
	/// <term>IAudioEndpointVolume::VolumeStepDown</term>
	/// </item>
	/// <item>
	/// <term>IAudioEndpointVolume::VolumeStepUp</term>
	/// </item>
	/// </list>
	/// <para>
	/// If an audio endpoint device implements hardware volume and mute controls, the <c>IAudioEndpointVolume</c> interface uses the
	/// hardware controls to manage the device's volume. Otherwise, the <c>IAudioEndpointVolume</c> interface implements volume and mute
	/// controls in software, transparently to the client.
	/// </para>
	/// <para>
	/// If a device has hardware volume and mute controls, changes made to the volume and mute settings through the methods in the
	/// preceding list affect the device's volume in both shared mode and exclusive mode. If a device lacks hardware volume and mute
	/// controls, changes made to the software volume and mute controls through these methods affect the device's volume in shared mode,
	/// but not in exclusive mode. In exclusive mode, the client and the device exchange audio data directly, bypassing the software
	/// controls. However, changes made to the software controls through these methods generate event notifications regardless of
	/// whether the device is operating in shared mode or in exclusive mode. Changes made to the software volume and mute controls while
	/// the device operates in exclusive mode take effect when the device switches to shared mode.
	/// </para>
	/// <para>
	/// To determine whether a device has hardware volume and mute controls, call the IAudioEndpointVolume::QueryHardwareSupport method.
	/// </para>
	/// <para>In implementing the <c>IAudioEndpointVolumeCallback</c> interface, the client should observe these rules to avoid deadlocks:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The methods in the interface must be nonblocking. The client should never wait on a synchronization object during an event callback.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The client should never call the IAudioEndpointVolume::UnregisterControlChangeNotify method during an event callback.</term>
	/// </item>
	/// <item>
	/// <term>The client should never release the final reference on an EndpointVolume API object during an event callback.</term>
	/// </item>
	/// </list>
	/// <para>For a code example that implements the <c>IAudioEndpointVolumeCallback</c> interface, see Endpoint Volume Controls.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nn-endpointvolume-iaudioendpointvolumecallback
	[PInvokeData("endpointvolume.h", MSDNShortId = "0b631d1b-f89c-4789-a09c-875b24a48a89")]
	[ComImport, Guid("657804FA-D6AD-4496-8A60-352752AF4F89"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioEndpointVolumeCallback
	{
		/// <summary>
		/// The <c>OnNotify</c> method notifies the client that the volume level or muting state of the audio endpoint device has changed.
		/// </summary>
		/// <param name="pNotify">Pointer to the volume-notification data. This parameter points to a structure of type AUDIO_VOLUME_NOTIFICATION_DATA.</param>
		/// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
		/// <remarks>
		/// <para>
		/// The pNotify parameter points to a structure that describes the volume change event that initiated the call to
		/// <c>OnNotify</c>. This structure contains an event-context GUID. This GUID enables a client to distinguish between a volume
		/// (or muting) change that it initiated and one that some other client initiated. When calling an IAudioEndpointVolume method
		/// that changes the volume level of the stream, a client passes in a pointer to an event-context GUID that its implementation
		/// of the <c>OnNotify</c> method can recognize. The structure pointed to by pNotify contains this context GUID. If the client
		/// that changes the volume level supplies a <c>NULL</c> pointer value for the pointer to the event-context GUID, the value of
		/// the event-context GUID in the structure pointed to by pNotify is GUID_NULL.
		/// </para>
		/// <para>
		/// The Windows 7, the system's volume user interface does not specify GUID_NULL when it changes the volume in the system. A
		/// third-party OSD application can differentiate between master volume control changes that result from the system's volume
		/// user interface, and other volume changes such as changes from the built-in volume control handler.
		/// </para>
		/// <para>For a code example that implements the <c>OnNotify</c> method, see Endpoint Volume Controls.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolumecallback-onnotify
		// HRESULT OnNotify( PAUDIO_VOLUME_NOTIFICATION_DATA pNotify );
		[PreserveSig]
		HRESULT OnNotify([In] IntPtr pNotify);
	}

	/// <summary>
	/// <para>The <c>IAudioEndpointVolumeEx</c> interface provides volume controls on the audio stream to or from a device endpoint.</para>
	/// <para>
	/// A client obtains a reference to the <c>IAudioEndpointVolumeEx</c> interface of an endpoint device by calling the
	/// IMMDevice::Activate method with parameter iid set to REFIID IID_IAudioEndpointVolumeEx.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nn-endpointvolume-iaudioendpointvolumeex
	[ComImport, Guid("66E11784-F695-4F28-A505-A7080081A78F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioEndpointVolumeEx : IAudioEndpointVolume
	{
		/// <summary>The <c>RegisterControlChangeNotify</c> method registers a client's notification callback interface.</summary>
		/// <param name="pNotify">
		/// Pointer to the IAudioEndpointVolumeCallback interface that the client is registering for notification callbacks. If the
		/// <c>RegisterControlChangeNotify</c> method succeeds, it calls the AddRef method on the client's
		/// <c>IAudioEndpointVolumeCallback</c> interface.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method registers an IAudioEndpointVolumeCallback interface to be called by the system when the volume level or muting
		/// state of an endpoint changes. The caller implements the <c>IAudioEndpointVolumeCallback</c> interface.
		/// </para>
		/// <para>
		/// When notifications are no longer needed, the client can call the IAudioEndpointVolume::UnregisterControlChangeNotify method
		/// to terminate the notifications.
		/// </para>
		/// <para>
		/// Before the client releases its final reference to the IAudioEndpointVolumeCallback interface, it should call
		/// UnregisterControlChangeNotify to unregister the interface. Otherwise, the application leaks the resources held by the
		/// <c>IAudioEndpointVolumeCallback</c> and IAudioEndpointVolume objects. Note that <c>RegisterControlChangeNotify</c> calls the
		/// client's IAudioEndpointVolumeCallback::AddRef method, and <c>UnregisterControlChangeNotify</c> calls the
		/// IAudioEndpointVolumeCallback::Release method. If the client errs by releasing its reference to the
		/// <c>IAudioEndpointVolumeCallback</c> interface before calling <c>UnregisterControlChangeNotify</c>, the
		/// <c>IAudioEndpointVolume</c> object never releases its reference to the <c>IAudioEndpointVolumeCallback</c> interface. For
		/// example, a poorly designed <c>IAudioEndpointVolumeCallback</c> implementation might call
		/// <c>UnregisterControlChangeNotify</c> from the destructor for the <c>IAudioEndpointVolumeCallback</c> object. In this case,
		/// the client will not call <c>UnregisterControlChangeNotify</c> until the <c>IAudioEndpointVolume</c> object releases its
		/// reference to the <c>IAudioEndpointVolumeCallback</c> interface, and the <c>IAudioEndpointVolume</c> object will not release
		/// its reference to the <c>IAudioEndpointVolumeCallback</c> interface until the client calls
		/// <c>UnregisterControlChangeNotify</c>. For more information about the <c>AddRef</c> and <c>Release</c> methods, see the
		/// discussion of the IUnknown interface in the Windows SDK documentation.
		/// </para>
		/// <para>
		/// In addition, the client should call UnregisterControlChangeNotify before releasing the final reference to the
		/// IAudioEndpointVolume object. Otherwise, the object leaks the storage that it allocated to hold the registration information.
		/// After registering a notification interface, the client continues to receive notifications for only as long as the
		/// <c>IAudioEndpointVolume</c> object exists.
		/// </para>
		/// <para>For a code example that calls <c>RegisterControlChangeNotify</c>, see Endpoint Volume Controls.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-registercontrolchangenotify
		// HRESULT RegisterControlChangeNotify( IAudioEndpointVolumeCallback *pNotify );
		new void RegisterControlChangeNotify([In] IAudioEndpointVolumeCallback pNotify);

		/// <summary>
		/// The <c>UnregisterControlChangeNotify</c> method deletes the registration of a client's notification callback interface that
		/// the client registered in a previous call to the IAudioEndpointVolume::RegisterControlChangeNotify method.
		/// </summary>
		/// <param name="pNotify">
		/// Pointer to the client's IAudioEndpointVolumeCallback interface. The client passed this same interface pointer to the
		/// endpoint volume object in a previous call to the IAudioEndpointVolume::RegisterControlChangeNotify method. If the
		/// <c>UnregisterControlChangeNotify</c> method succeeds, it calls the Release method on the client's
		/// <c>IAudioEndpointVolumeCallback</c> interface.
		/// </param>
		/// <remarks>
		/// <para>
		/// Before the client releases its final reference to the IAudioEndpointVolumeCallback interface, it should call
		/// <c>UnregisterControlChangeNotify</c> to unregister the interface. Otherwise, the application leaks the resources held by the
		/// <c>IAudioEndpointVolumeCallback</c> and IAudioEndpointVolume objects. Note that the
		/// IAudioEndpointVolume::RegisterControlChangeNotify method calls the client's IAudioEndpointVolumeCallback::AddRef method, and
		/// <c>UnregisterControlChangeNotify</c> calls the IAudioEndpointVolumeCallback::Release method. If the client errs by releasing
		/// its reference to the <c>IAudioEndpointVolumeCallback</c> interface before calling <c>UnregisterControlChangeNotify</c>, the
		/// <c>IAudioEndpointVolume</c> object never releases its reference to the <c>IAudioEndpointVolumeCallback</c> interface. For
		/// example, a poorly designed <c>IAudioEndpointVolumeCallback</c> implementation might call
		/// <c>UnregisterControlChangeNotify</c> from the destructor for the <c>IAudioEndpointVolumeCallback</c> object. In this case,
		/// the client will not call <c>UnregisterControlChangeNotify</c> until the <c>IAudioEndpointVolume</c> object releases its
		/// reference to the <c>IAudioEndpointVolumeCallback</c> interface, and the <c>IAudioEndpointVolume</c> object will not release
		/// its reference to the <c>IAudioEndpointVolumeCallback</c> interface until the client calls
		/// <c>UnregisterControlChangeNotify</c>. For more information about the <c>AddRef</c> and <c>Release</c> methods, see the
		/// discussion of the IUnknown interface in the Windows SDK documentation.
		/// </para>
		/// <para>For a code example that calls <c>UnregisterControlChangeNotify</c>, see Endpoint Volume Controls.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-unregistercontrolchangenotify
		// HRESULT UnregisterControlChangeNotify( IAudioEndpointVolumeCallback *pNotify );
		new void UnregisterControlChangeNotify([In] IAudioEndpointVolumeCallback pNotify);

		/// <summary>
		/// The <c>GetChannelCount</c> method gets a count of the channels in the audio stream that enters or leaves the audio endpoint device.
		/// </summary>
		/// <returns>A <c>UINT</c> variable into which the method writes the channel count.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-getchannelcount
		// HRESULT GetChannelCount( UINT *pnChannelCount );
		new uint GetChannelCount();

		/// <summary>
		/// The <c>SetMasterVolumeLevel</c> method sets the master volume level, in decibels, of the audio stream that enters or leaves
		/// the audio endpoint device.
		/// </summary>
		/// <param name="fLevelDB">
		/// The new master volume level in decibels. To obtain the range and granularity of the volume levels that can be set by this
		/// method, call the IAudioEndpointVolume::GetVolumeRange method.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IAudioEndpointVolumeCallback::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetMasterVolumeLevel</c> call changes the volume level of the endpoint, all clients that have registered
		/// IAudioEndpointVolumeCallback interfaces with that endpoint will receive notifications. In its implementation of the
		/// <c>OnNotify</c> method, a client can inspect the event-context GUID to discover whether it or another client is the source
		/// of the volume-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the notification routine
		/// receives the context GUID value GUID_NULL.
		/// </param>
		/// <remarks>
		/// If volume level fLevelDB falls outside of the volume range reported by the <c>IAudioEndpointVolume::GetVolumeRange</c>
		/// method, the <c>SetMasterVolumeLevel</c> call fails and returns error code E_INVALIDARG.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-setmastervolumelevel
		// HRESULT SetMasterVolumeLevel( float fLevelDB, LPCGUID pguidEventContext );
		new void SetMasterVolumeLevel([In] float fLevelDB, in Guid pguidEventContext);

		/// <summary>
		/// The <c>SetMasterVolumeLevelScalar</c> method sets the master volume level of the audio stream that enters or leaves the
		/// audio endpoint device. The volume level is expressed as a normalized, audio-tapered value in the range from 0.0 to 1.0.
		/// </summary>
		/// <param name="fLevel">
		/// The new master volume level. The level is expressed as a normalized value in the range from 0.0 to 1.0.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IAudioEndpointVolumeCallback::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetMasterVolumeLevelScalar</c> call changes the volume level of the endpoint, all clients that have registered
		/// IAudioEndpointVolumeCallback interfaces with that endpoint will receive notifications. In its implementation of the
		/// <c>OnNotify</c> method, a client can inspect the event-context GUID to discover whether it or another client is the source
		/// of the volume-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the notification routine
		/// receives the context GUID value GUID_NULL.
		/// </param>
		/// <remarks>
		/// <para>
		/// The volume level is normalized to the range from 0.0 to 1.0, where 0.0 is the minimum volume level and 1.0 is the maximum
		/// level. Within this range, the relationship of the normalized volume level to the attenuation of signal amplitude is
		/// described by a nonlinear, audio-tapered curve. Note that the shape of the curve might change in future versions of Windows.
		/// For more information about audio-tapered curves, see Audio-Tapered Volume Controls.
		/// </para>
		/// <para>
		/// The normalized volume levels that are passed to this method are suitable to represent the positions of volume controls in
		/// application windows and on-screen displays.
		/// </para>
		/// <para>For a code example that calls <c>SetMasterVolumeLevelScalar</c>, see Endpoint Volume Controls.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-setmastervolumelevelscalar
		// HRESULT SetMasterVolumeLevelScalar( float fLevel, LPCGUID pguidEventContext );
		new void SetMasterVolumeLevelScalar([In] float fLevel, in Guid pguidEventContext);

		/// <summary>
		/// The <c>GetMasterVolumeLevel</c> method gets the master volume level, in decibels, of the audio stream that enters or leaves
		/// the audio endpoint device.
		/// </summary>
		/// <returns>
		/// The master volume level. This parameter points to a <c>float</c> variable into which the method writes the volume level in
		/// decibels. To get the range of volume levels obtained from this method, call the IAudioEndpointVolume::GetVolumeRange method.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-getmastervolumelevel
		// HRESULT GetMasterVolumeLevel( float *pfLevelDB );
		new float GetMasterVolumeLevel();

		/// <summary>
		/// The <c>GetMasterVolumeLevelScalar</c> method gets the master volume level of the audio stream that enters or leaves the
		/// audio endpoint device. The volume level is expressed as a normalized, audio-tapered value in the range from 0.0 to 1.0.
		/// </summary>
		/// <returns>
		/// The master volume level. This parameter points to a <c>float</c> variable into which the method writes the volume level. The
		/// level is expressed as a normalized value in the range from 0.0 to 1.0.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The volume level is normalized to the range from 0.0 to 1.0, where 0.0 is the minimum volume level and 1.0 is the maximum
		/// level. Within this range, the relationship of the normalized volume level to the attenuation of signal amplitude is
		/// described by a nonlinear, audio-tapered curve. Note that the shape of the curve might change in future versions of Windows.
		/// For more information about audio-tapered curves, see Audio-Tapered Volume Controls.
		/// </para>
		/// <para>
		/// The normalized volume levels that are retrieved by this method are suitable to represent the positions of volume controls in
		/// application windows and on-screen displays.
		/// </para>
		/// <para>For a code example that calls <c>GetMasterVolumeLevelScalar</c>, see Endpoint Volume Controls.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-getmastervolumelevelscalar
		// HRESULT GetMasterVolumeLevelScalar( float *pfLevel );
		new float GetMasterVolumeLevelScalar();

		/// <summary>
		/// The <c>SetChannelVolumeLevel</c> method sets the volume level, in decibels, of the specified channel of the audio stream
		/// that enters or leaves the audio endpoint device.
		/// </summary>
		/// <param name="nChannel">
		/// The channel number. If the audio stream contains n channels, the channels are numbered from 0 to n– 1. To obtain the number
		/// of channels, call the IAudioEndpointVolume::GetChannelCount method.
		/// </param>
		/// <param name="fLevelDB">
		/// The new volume level in decibels. To obtain the range and granularity of the volume levels that can be set by this method,
		/// call the IAudioEndpointVolume::GetVolumeRange method.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IAudioEndpointVolumeCallback::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetChannelVolumeLevel</c> call changes the volume level of the endpoint, all clients that have registered
		/// IAudioEndpointVolumeCallback interfaces with that endpoint will receive notifications. In its implementation of the
		/// <c>OnNotify</c> method, a client can inspect the event-context GUID to discover whether it or another client is the source
		/// of the volume-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the notification routine
		/// receives the context GUID value GUID_NULL.
		/// </param>
		/// <remarks>
		/// If volume level fLevelDB falls outside of the volume range reported by the <c>IAudioEndpointVolume::GetVolumeRange</c>
		/// method, the <c>SetChannelVolumeLevel</c> call fails and returns error code E_INVALIDARG.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-setchannelvolumelevel
		// HRESULT SetChannelVolumeLevel( UINT nChannel, float fLevelDB, LPCGUID pguidEventContext );
		new void SetChannelVolumeLevel([In] uint nChannel, float fLevelDB, in Guid pguidEventContext);

		/// <summary>
		/// The <c>SetChannelVolumeLevelScalar</c> method sets the normalized, audio-tapered volume level of the specified channel in
		/// the audio stream that enters or leaves the audio endpoint device.
		/// </summary>
		/// <param name="nChannel">
		/// The channel number. If the audio stream contains n channels, the channels are numbered from 0 to n– 1. To obtain the number
		/// of channels, call the IAudioEndpointVolume::GetChannelCount method.
		/// </param>
		/// <param name="fLevel">The volume level. The volume level is expressed as a normalized value in the range from 0.0 to 1.0.</param>
		/// <param name="pguidEventContext">
		/// Context value for the IAudioEndpointVolumeCallback::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetChannelVolumeLevelScalar</c> call changes the volume level of the endpoint, all clients that have registered
		/// IAudioEndpointVolumeCallback interfaces with that endpoint will receive notifications. In its implementation of the
		/// <c>OnNotify</c> method, a client can inspect the event-context GUID to discover whether it or another client is the source
		/// of the volume-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the notification routine
		/// receives the context GUID value GUID_NULL.
		/// </param>
		/// <remarks>
		/// <para>
		/// The volume level is normalized to the range from 0.0 to 1.0, where 0.0 is the minimum volume level and 1.0 is the maximum
		/// level. Within this range, the relationship of the normalized volume level to the attenuation of signal amplitude is
		/// described by a nonlinear, audio-tapered curve. Note that the shape of the curve might change in future versions of Windows.
		/// For more information about audio-tapered curves, see Audio-Tapered Volume Controls.
		/// </para>
		/// <para>
		/// The normalized volume levels that are passed to this method are suitable to represent the positions of volume controls in
		/// application windows and on-screen displays.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-setchannelvolumelevelscalar
		// HRESULT SetChannelVolumeLevelScalar( UINT nChannel, float fLevel, LPCGUID pguidEventContext );
		new void SetChannelVolumeLevelScalar([In] uint nChannel, float fLevel, in Guid pguidEventContext);

		/// <summary>
		/// The <c>GetChannelVolumeLevel</c> method gets the volume level, in decibels, of the specified channel in the audio stream
		/// that enters or leaves the audio endpoint device.
		/// </summary>
		/// <param name="nChannel">
		/// The channel number. If the audio stream has n channels, the channels are numbered from 0 to n– 1. To obtain the number of
		/// channels in the stream, call the IAudioEndpointVolume::GetChannelCount method.
		/// </param>
		/// <returns>
		/// A <c>float</c> variable into which the method writes the volume level in decibels. To get the range of volume levels
		/// obtained from this method, call the IAudioEndpointVolume::GetVolumeRange method.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-getchannelvolumelevel
		// HRESULT GetChannelVolumeLevel( UINT nChannel, float *pfLevelDB );
		new float GetChannelVolumeLevel([In] uint nChannel);

		/// <summary>
		/// The <c>GetChannelVolumeLevelScalar</c> method gets the normalized, audio-tapered volume level of the specified channel of
		/// the audio stream that enters or leaves the audio endpoint device.
		/// </summary>
		/// <param name="nChannel">
		/// The channel number. If the audio stream contains n channels, the channels are numbered from 0 to n– 1. To obtain the number
		/// of channels, call the IAudioEndpointVolume::GetChannelCount method.
		/// </param>
		/// <returns>
		/// A <c>float</c> variable into which the method writes the volume level. The level is expressed as a normalized value in the
		/// range from 0.0 to 1.0.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The volume level is normalized to the range from 0.0 to 1.0, where 0.0 is the minimum volume level and 1.0 is the maximum
		/// level. Within this range, the relationship of the normalized volume level to the attenuation of signal amplitude is
		/// described by a nonlinear, audio-tapered curve. Note that the shape of the curve might change in future versions of Windows.
		/// For more information about audio-tapered curves, see Audio-Tapered Volume Controls.
		/// </para>
		/// <para>
		/// The normalized volume levels that are retrieved by this method are suitable to represent the positions of volume controls in
		/// application windows and on-screen displays.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-getchannelvolumelevelscalar
		// HRESULT GetChannelVolumeLevelScalar( UINT nChannel, float *pfLevel );
		new float GetChannelVolumeLevelScalar([In] uint nChannel);

		/// <summary>
		/// The <c>SetMute</c> method sets the muting state of the audio stream that enters or leaves the audio endpoint device.
		/// </summary>
		/// <param name="bMute">
		/// The new muting state. If bMute is <c>TRUE</c>, the method mutes the stream. If <c>FALSE</c>, the method turns off muting.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IAudioEndpointVolumeCallback::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetMute</c> call changes the muting state of the endpoint, all clients that have registered IAudioEndpointVolumeCallback
		/// interfaces with that endpoint will receive notifications. In its implementation of the <c>OnNotify</c> method, a client can
		/// inspect the event-context GUID to discover whether it or another client is the source of the control-change event. If the
		/// caller supplies a <c>NULL</c> pointer for this parameter, the notification routine receives the context GUID value GUID_NULL.
		/// </param>
		/// <remarks>For a code example that calls <c>SetMute</c>, see Endpoint Volume Controls.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-setmute HRESULT
		// SetMute( BOOL bMute, LPCGUID pguidEventContext );
		new void SetMute([In] [MarshalAs(UnmanagedType.Bool)] bool bMute, in Guid pguidEventContext);

		/// <summary>
		/// The <c>GetMute</c> method gets the muting state of the audio stream that enters or leaves the audio endpoint device.
		/// </summary>
		/// <returns>
		/// A <c>BOOL</c> variable into which the method writes the muting state. If *pbMute is <c>TRUE</c>, the stream is muted. If
		/// <c>FALSE</c>, the stream is not muted.
		/// </returns>
		/// <remarks>For a code example that calls <c>GetMute</c>, see Endpoint Volume Controls.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-getmute HRESULT
		// GetMute( BOOL *pbMute );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool GetMute();

		/// <summary>The <c>GetVolumeStepInfo</c> method gets information about the current step in the volume range.</summary>
		/// <param name="pnStep">
		/// Pointer to a <c>UINT</c> variable into which the method writes the current step index. This index is a value in the range
		/// from 0 to *pStepCount– 1, where 0 represents the minimum volume level and *pStepCount– 1 represents the maximum level.
		/// </param>
		/// <param name="pnStepCount">
		/// Pointer to a <c>UINT</c> variable into which the method writes the number of steps in the volume range. This number remains
		/// constant for the lifetime of the IAudioEndpointVolume interface instance.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method represents the volume level of the audio stream that enters or leaves the audio endpoint device as an index or
		/// "step" in a range of discrete volume levels. Output value *pnStepCount is the number of steps in the range. Output value
		/// *pnStep is the step index of the current volume level. If the number of steps is n = *pnStepCount, then step index *pnStep
		/// can assume values from 0 (minimum volume) to n – 1 (maximum volume).
		/// </para>
		/// <para>
		/// Over the range from 0 to n – 1, successive intervals between adjacent steps do not necessarily represent uniform volume
		/// increments in either linear signal amplitude or decibels. In Windows Vista, <c>GetVolumeStepInfo</c> defines the
		/// relationship of index to volume level (signal amplitude) to be an audio-tapered curve. Note that the shape of the curve
		/// might change in future versions of Windows. For more information about audio-tapered curves, see Audio-Tapered Volume Controls.
		/// </para>
		/// <para>
		/// Audio applications can call the IAudioEndpointVolume::VolumeStepUp and IAudioEndpointVolume::VolumeStepDown methods to
		/// increase or decrease the volume level by one interval. Either method first calculates the idealized volume level that
		/// corresponds to the next point on the audio-tapered curve. Next, the method selects the endpoint volume setting that is the
		/// best approximation to the idealized level. To obtain the range and granularity of the endpoint volume settings, call the
		/// IEndpointVolume::GetVolumeRange method. If the audio endpoint device implements a hardware volume control,
		/// <c>GetVolumeRange</c> describes the hardware volume settings. Otherwise, the EndpointVolume API implements the endpoint
		/// volume control in software, and <c>GetVolumeRange</c> describes the volume settings of the software-implemented control.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-getvolumestepinfo
		// HRESULT GetVolumeStepInfo( UINT *pnStep, UINT *pnStepCount );
		new void GetVolumeStepInfo(out uint pnStep, out uint pnStepCount);

		/// <summary>
		/// The <c>VolumeStepUp</c> method increments, by one step, the volume level of the audio stream that enters or leaves the audio
		/// endpoint device.
		/// </summary>
		/// <param name="pguidEventContext">
		/// Context value for the IAudioEndpointVolumeCallback::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>VolumeStepUp</c> call changes the volume level of the endpoint, all clients that have registered
		/// IAudioEndpointVolumeCallback interfaces with that endpoint will receive notifications. In its implementation of the
		/// <c>OnNotify</c> method, a client can inspect the event-context GUID to discover whether it or another client is the source
		/// of the volume-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the client's notification
		/// method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// <para>
		/// To obtain the current volume step and the total number of steps in the volume range, call the
		/// IAudioEndpointVolume::GetVolumeStepInfo method.
		/// </para>
		/// <para>
		/// If the volume level is already at the highest step in the volume range, the call to <c>VolumeStepUp</c> has no effect and
		/// returns status code S_OK.
		/// </para>
		/// <para>
		/// Successive intervals between adjacent steps do not necessarily represent uniform volume increments in either linear signal
		/// amplitude or decibels. In Windows Vista, <c>VolumeStepUp</c> defines the relationship of step index to volume level (signal
		/// amplitude) to be an audio-tapered curve. Note that the shape of the curve might change in future versions of Windows. For
		/// more information about audio-tapered curves, see Audio-Tapered Volume Controls.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-volumestepup HRESULT
		// VolumeStepUp( LPCGUID pguidEventContext );
		new void VolumeStepUp(in Guid pguidEventContext);

		/// <summary>
		/// The <c>VolumeStepDown</c> method decrements, by one step, the volume level of the audio stream that enters or leaves the
		/// audio endpoint device.
		/// </summary>
		/// <param name="pguidEventContext">
		/// Context value for the IAudioEndpointVolumeCallback::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>VolumeStepDown</c> call changes the volume level of the endpoint, all clients that have registered
		/// IAudioEndpointVolumeCallback interfaces with that endpoint will receive notifications. In its implementation of the
		/// <c>OnNotify</c> method, a client can inspect the event-context GUID to discover whether it or another client is the source
		/// of the volume-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the client's notification
		/// method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// <para>
		/// To obtain the current volume step and the total number of steps in the volume range, call the
		/// IAudioEndpointVolume::GetVolumeStepInfo method.
		/// </para>
		/// <para>
		/// If the volume level is already at the lowest step in the volume range, the call to <c>VolumeStepDown</c> has no effect and
		/// returns status code S_OK.
		/// </para>
		/// <para>
		/// Successive intervals between adjacent steps do not necessarily represent uniform volume increments in either linear signal
		/// amplitude or decibels. In Windows Vista, <c>VolumeStepDown</c> defines the relationship of step index to volume level
		/// (signal amplitude) to be an audio-tapered curve. Note that the shape of the curve might change in future versions of
		/// Windows. For more information about audio-tapered curves, see Audio-Tapered Volume Controls.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-volumestepdown
		// HRESULT VolumeStepDown( LPCGUID pguidEventContext );
		new void VolumeStepDown(in Guid pguidEventContext);

		/// <summary>The QueryHardwareSupport method queries the audio endpoint device for its hardware-supported functions.</summary>
		/// <returns>
		/// A <c>DWORD</c> variable into which the method writes a hardware support mask that indicates the hardware capabilities of the
		/// audio endpoint device. The method can set the mask to 0 or to the bitwise-OR combination of one or more
		/// ENDPOINT_HARDWARE_SUPPORT_XXX constants.
		/// </returns>
		/// <remarks>
		/// <para>This method indicates whether the audio endpoint device implements the following functions in hardware:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Volume control</term>
		/// </item>
		/// <item>
		/// <term>Mute control</term>
		/// </item>
		/// <item>
		/// <term>Peak meter</term>
		/// </item>
		/// </list>
		/// <para>
		/// The system automatically substitutes a software implementation for any function in the preceding list that the endpoint
		/// device does not implement in hardware.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-queryhardwaresupport
		// HRESULT QueryHardwareSupport( DWORD *pdwHardwareSupportMask );
		new ENDPOINT_HARDWARE_SUPPORT QueryHardwareSupport();

		/// <summary>
		/// The <c>GetVolumeRange</c> method gets the volume range, in decibels, of the audio stream that enters or leaves the audio
		/// endpoint device.
		/// </summary>
		/// <param name="pflVolumeMindB">
		/// Pointer to the minimum volume level. This parameter points to a <c>float</c> variable into which the method writes the
		/// minimum volume level in decibels. This value remains constant for the lifetime of the IAudioEndpointVolume interface instance.
		/// </param>
		/// <param name="pflVolumeMaxdB">
		/// Pointer to the maximum volume level. This parameter points to a <c>float</c> variable into which the method writes the
		/// maximum volume level in decibels. This value remains constant for the lifetime of the <c>IAudioEndpointVolume</c> interface instance.
		/// </param>
		/// <param name="pflVolumeIncrementdB">
		/// Pointer to the volume increment. This parameter points to a <c>float</c> variable into which the method writes the volume
		/// increment in decibels. This increment remains constant for the lifetime of the <c>IAudioEndpointVolume</c> interface instance.
		/// </param>
		/// <remarks>
		/// <para>
		/// The volume range from vmin = *pfLevelMinDB to vmax = *pfLevelMaxDB is divided into n uniform intervals of size vinc =
		/// *pfVolumeIncrementDB, where
		/// </para>
		/// <para>n = (vmax – vmin) / vinc.</para>
		/// <para>
		/// The values vmin, vmax, and vinc are measured in decibels. The client can set the volume level to one of n + 1 discrete
		/// values in the range from vmin to vmax.
		/// </para>
		/// <para>
		/// The IAudioEndpointVolume::SetChannelVolumeLevel and IAudioEndpointVolume::SetMasterVolumeLevel methods accept only volume
		/// levels in the range from vmin to vmax. If the caller specifies a volume level outside of this range, the method fails and
		/// returns E_INVALIDARG. If the caller specifies a volume level that falls between two steps in the volume range, the method
		/// sets the endpoint volume level to the step that lies closest to the requested volume level and returns S_OK. However, a
		/// subsequent call to IAudioEndpointVolume::GetChannelVolumeLevel or IAudioEndpointVolume::GetMasterVolumeLevel retrieves the
		/// volume level requested by the previous call to <c>SetChannelVolumeLevel</c> or <c>SetMasterVolumeLevel</c>, not the step value.
		/// </para>
		/// <para>
		/// If the volume control is implemented in hardware, <c>GetVolumeRange</c> describes the range and granularity of the hardware
		/// volume settings. In contrast, the steps that are reported by the IEndpointVolume::GetVolumeStepInfo method correspond to
		/// points on an audio-tapered curve that are calculated in software by the IEndpointVolume::VolumeStepDown and
		/// IEndpointVolume::VolumeStepUp methods. Either method first calculates the idealized volume level that corresponds to the
		/// next point on the curve. Next, the method selects the hardware volume setting that is the best approximation to the
		/// idealized level. For more information about audio-tapered curves, see Audio-Tapered Volume Controls.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolume-getvolumerange
		// HRESULT GetVolumeRange( float *pflVolumeMindB, float *pflVolumeMaxdB, float *pflVolumeIncrementdB );
		new void GetVolumeRange(out float pflVolumeMindB, out float pflVolumeMaxdB, out float pflVolumeIncrementdB);

		/// <summary>The <c>GetVolumeRangeChannel</c> method gets the volume range for a specified channel.</summary>
		/// <param name="iChannel">
		/// The channel number for which to get the volume range. If the audio stream has n channels, the channels are numbered from 0
		/// to n– 1. To obtain the number of channels in the stream, call the IAudioEndpointVolume::GetChannelCount method.
		/// </param>
		/// <param name="pflVolumeMindB">Receives the minimum volume level for the channel, in decibels.</param>
		/// <param name="pflVolumeMaxdB">Receives the maximum volume level for the channel, in decibels.</param>
		/// <param name="pflVolumeIncrementdB">Receives the volume increment for the channel, in decibels.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudioendpointvolumeex-getvolumerangechannel
		// HRESULT GetVolumeRangeChannel( UINT iChannel, float *pflVolumeMindB, float *pflVolumeMaxdB, float *pflVolumeIncrementdB );
		void GetVolumeRangeChannel(uint iChannel, out float pflVolumeMindB, out float pflVolumeMaxdB, out float pflVolumeIncrementdB);
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioMeterInformation</c> interface represents a peak meter on an audio stream to or from an audio endpoint device. The
	/// client obtains a reference to the <c>IAudioMeterInformation</c> interface on an endpoint object by calling the
	/// IMMDevice::Activate method with parameter iid set to REFIID IID_IAudioMeterInformation.
	/// </para>
	/// <para>
	/// If the adapter device that streams audio data to or from the endpoint device implements a hardware peak meter, the
	/// <c>IAudioMeterInformation</c> interface uses that meter to monitor the peak levels in the audio stream. If the audio device
	/// lacks a hardware peak meter, the audio engine automatically implements the peak meter in software, transparently to the client.
	/// </para>
	/// <para>
	/// If a device has a hardware peak meter, a client can use the methods in the <c>IAudioMeterInformation</c> interface to monitor
	/// the device's peak levels in both shared mode and exclusive mode. If a device lacks a hardware peak meter, a client can use those
	/// methods to monitor the device's peak levels in shared mode, but not in exclusive mode. In exclusive mode, the client and the
	/// device exchange audio data directly, bypassing the software peak meter. In exclusive mode, a software peak meter always reports
	/// a peak value of 0.0.
	/// </para>
	/// <para>To determine whether a device has a hardware peak meter, call the IAudioMeterInformation::QueryHardwareSupport method.</para>
	/// <para>
	/// For a rendering endpoint device, the <c>IAudioMeterInformation</c> interface monitors the peak levels in the output stream
	/// before the stream is attenuated by the endpoint volume controls. Similarly, for a capture endpoint device, the interface
	/// monitors the peak levels in the input stream before the stream is attenuated by the endpoint volume controls.
	/// </para>
	/// <para>
	/// The peak values reported by the methods in the <c>IAudioMeterInformation</c> interface are normalized to the range from 0.0 to
	/// 1.0. For example, if a PCM stream contains 16-bit samples, and the peak sample value during a particular metering period is
	/// –8914, then the absolute value recorded by the peak meter is 8914, and the normalized peak value reported by the
	/// <c>IAudioMeterInformation</c> interface is 8914/32768 = 0.272.
	/// </para>
	/// <para>For a code example that uses the <c>IAudioMeterInformation</c> interface, see Peak Meters.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nn-endpointvolume-iaudiometerinformation
	[PInvokeData("endpointvolume.h", MSDNShortId = "eff1c1cd-792b-489a-8381-4b783c57f005")]
	[ComImport, Guid("C02216F6-8C67-4B5B-9D00-D008E73E0064"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioMeterInformation
	{
		/// <summary>The <c>GetPeakValue</c> method gets the peak sample value for the channels in the audio stream.</summary>
		/// <returns>
		/// Pointer to a <c>float</c> variable into which the method writes the peak sample value for the audio stream. The peak value
		/// is a number in the normalized range from 0.0 to 1.0.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method retrieves the peak sample value recorded across all of the channels in the stream. The peak value for each
		/// channel is recorded over one device period and made available during the subsequent device period. Thus, this method always
		/// retrieves the peak value recorded during the previous device period. To obtain the device period, call the
		/// IAudioClient::GetDevicePeriod method.
		/// </para>
		/// <para>For a code example that uses the <c>GetPeakValue</c> method, see Peak Meters.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudiometerinformation-getpeakvalue
		// HRESULT GetPeakValue( float *pfPeak );
		float GetPeakValue();

		/// <summary>
		/// The <c>GetMeteringChannelCount</c> method gets the number of channels in the audio stream that are monitored by peak meters.
		/// </summary>
		/// <returns>Pointer to a <c>UINT</c> variable into which the method writes the number of channels.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudiometerinformation-getmeteringchannelcount
		// HRESULT GetMeteringChannelCount( UINT *pnChannelCount );
		uint GetMeteringChannelCount();

		/// <summary>The <c>GetChannelsPeakValues</c> method gets the peak sample values for all the channels in the audio stream.</summary>
		/// <param name="u32ChannelCount">
		/// The channel count. This parameter also specifies the number of elements in the afPeakValues array. If the specified count
		/// does not match the number of channels in the stream, the method returns error code E_INVALIDARG.
		/// </param>
		/// <param name="afPeakValues">
		/// Pointer to an array of peak sample values. The method writes the peak values for the channels into the array. The array
		/// contains one element for each channel in the stream. The peak values are numbers in the normalized range from 0.0 to 1.0.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method retrieves the peak sample values for the channels in the stream. The peak value for each channel is recorded
		/// over one device period and made available during the subsequent device period. Thus, this method always retrieves the peak
		/// values recorded during the previous device period. To obtain the device period, call the IAudioClient::GetDevicePeriod method.
		/// </para>
		/// <para>
		/// Parameter afPeakValues points to a caller-allocated <c>float</c> array. If the stream contains n channels, the channels are
		/// numbered 0 to n– 1. The method stores the peak value for each channel in the array element whose array index matches the
		/// channel number. To get the number of channels in the audio stream that are monitored by peak meters, call the
		/// IAudioMeterInformation::GetMeteringChannelCount method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudiometerinformation-getchannelspeakvalues
		// HRESULT GetChannelsPeakValues( UINT32 u32ChannelCount, float *afPeakValues );
		void GetChannelsPeakValues(uint u32ChannelCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] afPeakValues);

		/// <summary>The <c>QueryHardwareSupport</c> method queries the audio endpoint device for its hardware-supported functions.</summary>
		/// <returns>
		/// A <c>DWORD</c> variable into which the method writes a hardware support mask that indicates the hardware capabilities of the
		/// audio endpoint device. The method can set the mask to 0 or to the bitwise-OR combination of one or more
		/// ENDPOINT_HARDWARE_SUPPORT_XXX constants.
		/// </returns>
		/// <remarks>
		/// <para>This method indicates whether the audio endpoint device implements the following functions in hardware:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Volume control</term>
		/// </item>
		/// <item>
		/// <term>Mute control</term>
		/// </item>
		/// <item>
		/// <term>Peak meter</term>
		/// </item>
		/// </list>
		/// <para>
		/// The system automatically substitutes a software implementation for any function in the preceding list that the endpoint
		/// devices does not implement in hardware.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/nf-endpointvolume-iaudiometerinformation-queryhardwaresupport
		// HRESULT QueryHardwareSupport( DWORD *pdwHardwareSupportMask );
		uint QueryHardwareSupport();
	}

	/// <summary>
	/// The <c>AUDIO_VOLUME_NOTIFICATION_DATA</c> structure describes a change in the volume level or muting state of an audio endpoint device.
	/// </summary>
	/// <remarks>
	/// <para>This structure is used by the <c>IAudioEndpointVolumeCallback::OnNotify</c> method.</para>
	/// <para>
	/// A client can register to be notified when the volume level or muting state of an endpoint device changes. The following methods
	/// can cause such a change:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>IAudioEndpointVolume::SetChannelVolumeLevel</term>
	/// </item>
	/// <item>
	/// <term>IAudioEndpointVolume::SetChannelVolumeLevelScalar</term>
	/// </item>
	/// <item>
	/// <term>IAudioEndpointVolume::SetMasterVolumeLevel</term>
	/// </item>
	/// <item>
	/// <term>IAudioEndpointVolume::SetMasterVolumeLevelScalar</term>
	/// </item>
	/// <item>
	/// <term>IAudioEndpointVolume::SetMute</term>
	/// </item>
	/// <item>
	/// <term>IAudioEndpointVolume::VolumeStepDown</term>
	/// </item>
	/// <item>
	/// <term>IAudioEndpointVolume::VolumeStepUp</term>
	/// </item>
	/// </list>
	/// <para>
	/// When a call to one of these methods causes a volume-change event (that is, a change in the volume level or muting state), the
	/// method sends notifications to all clients that have registered to receive them. The method notifies a client by calling the
	/// client's <c>IAudioEndpointVolumeCallback::OnNotify</c> method. Through the <c>OnNotify</c> call, the client receives a pointer
	/// to an <c>AUDIO_VOLUME_NOTIFICATION_DATA</c> structure that describes the change.
	/// </para>
	/// <para>
	/// Each of the methods in the preceding list accepts an input parameter named pguidEventContext, which is a pointer to an
	/// event-context GUID. Before sending notifications to clients, the method copies the event-context GUID pointed to by
	/// pguidEventContext into the <c>guidEventContext</c> member of the <c>AUDIO_VOLUME_NOTIFICATION_DATA</c> structure that it
	/// supplies to clients through their <c>OnNotify</c> methods. If pguidEventContext is <c>NULL</c>, the value of the
	/// <c>guidEventContext</c> member is set to GUID_NULL.
	/// </para>
	/// <para>
	/// In its implementation of the <c>OnNotify</c> method, a client can inspect the event-context GUID from that call to discover
	/// whether it or another client is the source of the volume-change event.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/endpointvolume/ns-endpointvolume-audio_volume_notification_data typedef struct
	// AUDIO_VOLUME_NOTIFICATION_DATA { GUID guidEventContext; BOOL bMuted; float fMasterVolume; UINT nChannels; float
	// afChannelVolumes[1]; } AUDIO_VOLUME_NOTIFICATION_DATA, *PAUDIO_VOLUME_NOTIFICATION_DATA;
	[PInvokeData("endpointvolume.h", MSDNShortId = "8778eb32-bc37-4d21-a096-f932db3d7b3f")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<AUDIO_VOLUME_NOTIFICATION_DATA>), nameof(nChannels))]
	[StructLayout(LayoutKind.Sequential)]
	public struct AUDIO_VOLUME_NOTIFICATION_DATA
	{
		/// <summary>
		/// Context value for the IAudioEndpointVolumeCallback::OnNotify method. This member is the value of the event-context GUID that
		/// was provided as an input parameter to the IAudioEndpointVolume method call that changed the endpoint volume level or muting
		/// state. For more information, see Remarks.
		/// </summary>
		public Guid guidEventContext;

		/// <summary>
		/// Specifies whether the audio stream is currently muted. If <c>bMuted</c> is <c>TRUE</c>, the stream is muted. If
		/// <c>FALSE</c>, the stream is not muted.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bMuted;

		/// <summary>
		/// Specifies the current master volume level of the audio stream. The volume level is normalized to the range from 0.0 to 1.0,
		/// where 0.0 is the minimum volume level and 1.0 is the maximum level. Within this range, the relationship of the normalized
		/// volume level to the attenuation of signal amplitude is described by a nonlinear, audio-tapered curve. For more information
		/// about audio tapers, see Audio-Tapered Volume Controls.
		/// </summary>
		public float fMasterVolume;

		/// <summary>
		/// Specifies the number of channels in the audio stream, which is also the number of elements in the <c>afChannelVolumes</c>
		/// array. If the audio stream contains n channels, the channels are numbered from 0 to n-1. The volume level for a particular
		/// channel is contained in the array element whose index matches the channel number.
		/// </summary>
		public uint nChannels;

		/// <summary>
		/// The first element in an array of channel volumes. This element contains the current volume level of channel 0 in the audio
		/// stream. If the audio stream contains more than one channel, the volume levels for the additional channels immediately follow
		/// the <c>AUDIO_VOLUME_NOTIFICATION_DATA</c> structure. The volume level for each channel is normalized to the range from 0.0
		/// to 1.0, where 0.0 is the minimum volume level and 1.0 is the maximum level. Within this range, the relationship of the
		/// normalized volume level to the attenuation of signal amplitude is described by a nonlinear, audio-tapered curve.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public float[] afChannelVolumes;
	}
}