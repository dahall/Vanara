using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from Windows Core Audio Api.</summary>
public static partial class CoreAudio
{
	/// <summary>System Effects are disabled.</summary>
	public const uint ENDPOINT_SYSFX_DISABLED = 0x00000001;

	/// <summary>System Effects are enabled.</summary>
	public const uint ENDPOINT_SYSFX_ENABLED = 0x00000000;

	/// <summary>Specifies the type of an audio system effects property store.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/mmdeviceapi/ne-mmdeviceapi-audio_systemeffects_propertystore_type
	// typedef enum __MIDL___MIDL_itf_mmdeviceapi_0000_0008_0002 { AUDIO_SYSTEMEFFECTS_PROPERTYSTORE_TYPE_DEFAULT, AUDIO_SYSTEMEFFECTS_PROPERTYSTORE_TYPE_USER, AUDIO_SYSTEMEFFECTS_PROPERTYSTORE_TYPE_VOLATILE, AUDIO_SYSTEMEFFECTS_PROPERTYSTORE_TYPE_ENUM_COUNT } AUDIO_SYSTEMEFFECTS_PROPERTYSTORE_TYPE;
	[PInvokeData("mmdeviceapi.h", MSDNShortId = "NE:mmdeviceapi.__MIDL___MIDL_itf_mmdeviceapi_0000_0008_0002")]
	public enum AUDIO_SYSTEMEFFECTS_PROPERTYSTORE_TYPE
	{
		/// <summary>Default property store. Contains custom effects properties and is populated from the INF file. Properties will not be persisted across OS upgrades.</summary>
		AUDIO_SYSTEMEFFECTS_PROPERTYSTORE_TYPE_DEFAULT,

		/// <summary>User property store. Contains user settings pertaining to effects properties and will be persisted by the OS across upgrades and migrations.</summary>
		AUDIO_SYSTEMEFFECTS_PROPERTYSTORE_TYPE_USER,

		/// <summary>The volatile property store. Contains audio effects properties that are lost on device reboot. The store is cleared each time the endpoint transitions to active</summary>
		AUDIO_SYSTEMEFFECTS_PROPERTYSTORE_TYPE_VOLATILE,

		/// <summary />
		AUDIO_SYSTEMEFFECTS_PROPERTYSTORE_TYPE_ENUM_COUNT,
	}

	/// <summary>The DEVICE_STATE_XXX constants indicate the current state of an audio endpoint device.</summary>
	/// <remarks>
	/// <para>
	/// The <c>IMMDeviceEnumerator::EnumAudioEndpoints</c>, <c>IMMDevice::GetState</c>, and
	/// <c>IMMNotificationClient::OnDeviceStateChanged</c> methods use the DEVICE_STATE_XXX constants. These methods enable clients to
	/// obtain information about endpoint devices that are in any of the states represented by the DEVICE_STATE_XXX constants.
	/// </para>
	/// <para>
	/// However, a client can open a stream (for example, by obtaining an <c>IAudioClient</c> interface for the device) only on a device
	/// that is in the DEVICE_STATE_ACTIVE state.
	/// </para>
	/// <para>
	/// The Windows multimedia control panel, Mmsys.cpl, displays the audio endpoint devices in the system. Disabling a device in
	/// Mmsys.cpl hides the device from the device-discovery mechanisms in higher-level audio APIs, but it does not invalidate any
	/// stream objects that a client might have instantiated before the device was disabled. For example, if a stream is playing on the
	/// device when the user disables it in Mmsys.cpl, the stream continues to play uninterrupted.
	/// </para>
	/// <para>In contrast, disabling a device in Device Manager effectively removes the device from the system.</para>
	/// <para>To use Mmsys.cpl to view the rendering devices, open a Command Prompt window and enter the following command:</para>
	/// <para><c>control mmsys.cpl,,0</c></para>
	/// <para>To view the capture devices, enter the following command:</para>
	/// <para><c>control mmsys.cpl,,1</c></para>
	/// <para>
	/// Alternatively, you can view the rendering devices or the capture devices in Mmsys.cpl by right-clicking the speaker icon in the
	/// notification area, which is located on the right side of the taskbar, and selecting <c>Playback Devices</c> or <c>Recording Devices</c>.
	/// </para>
	/// <para>
	/// Mmsys.cpl always displays endpoint devices that are in the DEVICE_STATE_ACTIVE state. In addition, it can be configured to
	/// display disabled and disconnected devices.
	/// </para>
	/// <para>
	/// To view endpoint devices that are in the DEVICE_STATE_DISABLED and DEVICE_STATE_NOTPRESENT states, right-click in the Mmsys.cpl
	/// window and select the <c>Show Disabled Devices</c> option.
	/// </para>
	/// <para>
	/// To view endpoint devices that are in the DEVICE_STATE_UNPLUGGED state, right-click in the Mmsys.cpl window and select the
	/// <c>Show Disconnected Devices</c> option.
	/// </para>
	/// <para>
	/// To view only endpoint devices that are in the DEVICE_STATE_ACTIVE state, deselect both the <c>Show Disabled Devices</c> and
	/// <c>Show Disconnected Devices</c> options.
	/// </para>
	/// <para>
	/// To enable or disable an endpoint device in Mmsys.cpl, click <c>Playback</c> or <c>Recording</c>, depending on whether the device
	/// is a playback or recording device. Next, select the device and click <c>Properties</c>. In the <c>Properties</c> window, next to
	/// <c>Device usage</c>, select either <c>Use this device (enable)</c> or <c>Don't use this device (disable)</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/coreaudio/device-state-xxx-constants
	[PInvokeData("mmdeviceapi.h", MSDNShortId = "d03f2fbc-313a-42cf-902a-fd9f6dce2a35")]
	[Flags]
	public enum DEVICE_STATE
	{
		/// <summary>
		/// The audio endpoint device is active. That is, the audio adapter that connects to the endpoint device is present and enabled.
		/// In addition, if the endpoint device plugs into a jack on the adapter, then the endpoint device is plugged in.
		/// </summary>
		DEVICE_STATE_ACTIVE = 0x00000001,

		/// <summary>
		/// The audio endpoint device is disabled. The user has disabled the device in the Windows multimedia control panel, Mmsys.cpl.
		/// For more information, see Remarks.
		/// </summary>
		DEVICE_STATE_DISABLED = 0x00000002,

		/// <summary>
		/// The audio endpoint device is not present because the audio adapter that connects to the endpoint device has been removed
		/// from the system, or the user has disabled the adapter device in Device Manager.
		/// </summary>
		DEVICE_STATE_NOTPRESENT = 0x00000004,

		/// <summary>
		/// The audio endpoint device is unplugged. The audio adapter that contains the jack for the endpoint device is present and
		/// enabled, but the endpoint device is not plugged into the jack. Only a device with jack-presence detection can be in this
		/// state. For more information about jack-presence detection, see Audio Endpoint Devices.
		/// </summary>
		DEVICE_STATE_UNPLUGGED = 0x00000008,

		/// <summary>Includes audio endpoint devices in all states active, disabled, not present, and unplugged.</summary>
		DEVICE_STATEMASK_ALL = 0x0000000f,
	}

	/// <summary>
	/// The <c>EDataFlow</c> enumeration defines constants that indicate the direction in which audio data flows between an audio
	/// endpoint device and an application.
	/// </summary>
	/// <remarks>
	/// The IMMDeviceEnumerator::GetDefaultAudioEndpoint, IMMDeviceEnumerator::EnumAudioEndpoints, IMMEndpoint::GetDataFlow, and
	/// IMMNotificationClient::OnDefaultDeviceChanged methods use the constants defined in the <c>EDataFlow</c> enumeration.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/ne-mmdeviceapi-edataflow typedef enum
	// __MIDL___MIDL_itf_mmdeviceapi_0000_0000_0001 { eRender, eCapture, eAll, EDataFlow_enum_count } EDataFlow;
	[PInvokeData("mmdeviceapi.h", MSDNShortId = "d79315aa-d753-4674-84c2-9ba601f36f57")]
	public enum EDataFlow
	{
		/// <summary>
		/// Audio rendering stream. Audio data flows from the application to the audio endpoint device, which renders the stream.
		/// </summary>
		eRender,

		/// <summary>Audio capture stream. Audio data flows from the audio endpoint device that captures the stream, to the application.</summary>
		eCapture,

		/// <summary>
		/// Audio rendering or capture stream. Audio data can flow either from the application to the audio endpoint device, or from the
		/// audio endpoint device to the application.
		/// </summary>
		eAll,

		/// <summary>The number of members in the EDataFlow enumeration (not counting the EDataFlow_enum_count member).</summary>
		EDataFlow_enum_count,
	}

	/// <summary>
	/// The <c>EndpointFormFactor</c> enumeration defines constants that indicate the general physical attributes of an audio endpoint device.
	/// </summary>
	/// <remarks>
	/// <para>The constants in this enumeration are the values that can be assigned to the PKEY_AudioEndpoint_FormFactor property.</para>
	/// <para>
	/// In digital pass-through mode, a digital interface transports blocks of non-PCM data through a connection without modifying them
	/// and without attempting to interpret their contents. For more information about digital pass-through mode, see the following documentation:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The descriptions of the WAVE_FORMAT_WMA_SPDIF and WAVE_FORMAT_DOLBY_AC3_SPDIF wave-format tags in the Windows DDK documentation.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The white paper titled "Audio Driver Support for the WMA Pro-over-S/PDIF Format" at the Audio Device Technologies for Windows website.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// For information about obtaining a description of the audio jack or connector through which an audio endpoint device connects to
	/// an audio adapter, see IKsJackDescription::GetJackDescription and IKsJackDescription2::GetJackDescription2.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/ne-mmdeviceapi-endpointformfactor typedef enum
	// __MIDL___MIDL_itf_mmdeviceapi_0000_0000_0003 { RemoteNetworkDevice, Speakers, LineLevel, Headphones, Microphone, Headset,
	// Handset, UnknownDigitalPassthrough, SPDIF, DigitalAudioDisplayDevice, UnknownFormFactor, EndpointFormFactor_enum_count } EndpointFormFactor;
	[PInvokeData("mmdeviceapi.h", MSDNShortId = "3fd3782b-c0fc-4d75-8627-d898e7fae436")]
	public enum EndpointFormFactor
	{
		/// <summary>An audio endpoint device that the user accesses remotely through a network.</summary>
		RemoteNetworkDevice,

		/// <summary>A set of speakers.</summary>
		Speakers,

		/// <summary>
		/// An audio endpoint device that sends a line-level analog signal to a line-input jack on an audio adapter or that receives a
		/// line-level analog signal from a line-output jack on the adapter.
		/// </summary>
		LineLevel,

		/// <summary>A set of headphones.</summary>
		Headphones,

		/// <summary>A microphone.</summary>
		Microphone,

		/// <summary>An earphone or a pair of earphones with an attached mouthpiece for two-way communication.</summary>
		Headset,

		/// <summary>The part of a telephone that is held in the hand and that contains a speaker and a microphone for two-way communication.</summary>
		Handset,

		/// <summary>
		/// An audio endpoint device that connects to an audio adapter through a connector for a digital interface of unknown type that
		/// transmits non-PCM data in digital pass-through mode. For more information, see Remarks.
		/// </summary>
		UnknownDigitalPassthrough,

		/// <summary>
		/// An audio endpoint device that connects to an audio adapter through a Sony/Philips Digital Interface (S/PDIF) connector.
		/// </summary>
		SPDIF,

		/// <summary>
		/// An audio endpoint device that connects to an audio adapter through a High-Definition Multimedia Interface (HDMI) connector
		/// or a display port.In Windows Vista, this value was named HDMI.
		/// </summary>
		DigitalAudioDisplayDevice,

		/// <summary>An audio endpoint device with unknown physical attributes.</summary>
		UnknownFormFactor,

		/// <summary>Windows 7: Maximum number of endpoint form factors.</summary>
		EndpointFormFactor_enum_count,
	}

	/// <summary>
	/// The <c>ERole</c> enumeration defines constants that indicate the role that the system has assigned to an audio endpoint device.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The IMMDeviceEnumerator::GetDefaultAudioEndpoint and IMMNotificationClient::OnDefaultDeviceChanged methods use the constants
	/// defined in the <c>ERole</c> enumeration.
	/// </para>
	/// <para>For more information, see Device Roles.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/ne-mmdeviceapi-erole typedef enum
	// __MIDL___MIDL_itf_mmdeviceapi_0000_0000_0002 { eConsole, eMultimedia, eCommunications, ERole_enum_count } ERole;
	[PInvokeData("mmdeviceapi.h", MSDNShortId = "0d0d3174-8489-4951-858c-024d58477ae0")]
	public enum ERole
	{
		/// <summary>Games, system notification sounds, and voice commands.</summary>
		eConsole,

		/// <summary>Music, movies, narration, and live music recording.</summary>
		eMultimedia,

		/// <summary>Voice communications (talking to another person).</summary>
		eCommunications,

		/// <summary>The number of members in the ERole enumeration (not counting the ERole_enum_count member).</summary>
		ERole_enum_count,
	}

	/// <summary>
	/// Represents an asynchronous operation activating a WASAPI interface and provides a method to retrieve the results of the activation.
	/// </summary>
	/// <remarks><c>When to implement:</c> Implemented by Windows and returned from the function ActivateAudioInterfaceAsync.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nn-mmdeviceapi-iactivateaudiointerfaceasyncoperation
	[PInvokeData("mmdeviceapi.h", MSDNShortId = "43b25a67-d9a8-4749-a654-c7310039c553")]
	[ComImport, Guid("72A22D78-CDE4-431D-B8CC-843A71199B6D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IActivateAudioInterfaceAsyncOperation
	{
		/// <summary>
		/// Gets the results of an asynchronous activation of a WASAPI interface initiated by an application calling the
		/// ActivateAudioInterfaceAsync function.
		/// </summary>
		/// <param name="activateResult"/>
		/// <param name="activatedInterface"/>
		/// <returns>
		/// <para>The function returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ILLEGAL_METHOD_CALL</term>
		/// <term>The method was called before the asynchronous operation was complete.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application calls this method after Windows calls the ActivateCompleted method of the application’s
		/// IActivateAudioInterfaceCompletionHandler interface.
		/// </para>
		/// <para>
		/// The result code returned through activateResult may depend on the requested interface. For additional information, see
		/// IMMDevice::Activate. A result code of <c>E_ACCESSDENIED</c> might indicate that the user has not given consent to access the
		/// device in a manner required by the requested WASAPI interface.
		/// </para>
		/// <para>The returned activatedInterface may be <c>NULL</c> if activateResult is not a success code.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-iactivateaudiointerfaceasyncoperation-getactivateresult
		// HRESULT GetActivateResult( HRESULT *activateResult, IUnknown **activatedInterface );
		[PreserveSig]
		HRESULT GetActivateResult(out HRESULT activateResult, [MarshalAs(UnmanagedType.IUnknown)] out object? activatedInterface);
	}

	/// <summary>Provides a callback to indicate that activation of a WASAPI interface is complete.</summary>
	/// <remarks>
	/// <para><c>When to implement:</c> An application implements this interface if it calls the ActivateAudioInterfaceAsync function.</para>
	/// <para>The implementation must be agile (aggregating a free-threaded marshaler).</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nn-mmdeviceapi-iactivateaudiointerfacecompletionhandler
	[PInvokeData("mmdeviceapi.h", MSDNShortId = "04ff7cbb-fd33-40d9-9c11-4f716c6423b0")]
	[ComImport, Guid("41D949AB-9862-444A-80F6-C261334DA5EB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IActivateAudioInterfaceCompletionHandler
	{
		/// <summary>Indicates that activation of a WASAPI interface is complete and results are available.</summary>
		/// <param name="activateOperation">
		/// An interface representing the asynchronous operation of activating the requested <c>WASAPI</c> interface
		/// </param>
		/// <remarks>
		/// An application implements this method if it calls the ActivateAudioInterfaceAsync function. When Windows calls this method,
		/// the results of the activation are available. The application can then retrieve the results by calling the GetActivateResult
		/// method of the IActivateAudioInterfaceAsyncOperation interface, passed through the activateOperation parameter.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-iactivateaudiointerfacecompletionhandler-activatecompleted
		// HRESULT ActivateCompleted( IActivateAudioInterfaceAsyncOperation *activateOperation );
		void ActivateCompleted(IActivateAudioInterfaceAsyncOperation activateOperation);
	}

	/// <summary>
	/// <para>
	/// The <c>IMMDevice</c> interface encapsulates the generic features of a multimedia device resource. In the current implementation
	/// of the MMDevice API, the only type of device resource that an <c>IMMDevice</c> interface can represent is an audio endpoint device.
	/// </para>
	/// <para>A client can obtain an <c>IMMDevice</c> interface from one of the following methods:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>IMMDeviceCollection::Item</term>
	/// </item>
	/// <item>
	/// <term>IMMDeviceEnumerator::GetDefaultAudioEndpoint</term>
	/// </item>
	/// <item>
	/// <term>IMMDeviceEnumerator::GetDevice</term>
	/// </item>
	/// </list>
	/// <para>For more information, see IMMDeviceCollection Interface.</para>
	/// <para>
	/// After obtaining the <c>IMMDevice</c> interface of an audio endpoint device, a client can obtain an interface that encapsulates
	/// the endpoint-specific features of the device by calling the <c>IMMDevice::QueryInterface</c> method with parameter iid set to
	/// <c>REFIID</c> IID_IMMEndpoint. For more information, see IMMEndpoint Interface.
	/// </para>
	/// <para>For code examples that use the <c>IMMDevice</c> interface, see the following topics:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Device Properties</term>
	/// </item>
	/// <item>
	/// <term>Rendering a Stream</term>
	/// </item>
	/// <item>
	/// <term>Device Roles for Legacy Windows Multimedia Applications</term>
	/// </item>
	/// </list>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nn-mmdeviceapi-immdevice
	[PInvokeData("mmdeviceapi.h", MSDNShortId = "12b05e7e-81b2-49fd-bb9f-d5ad3315c580")]
	[ComImport, Guid("D666063F-1587-4E43-81F1-B948E807363F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IMMDevice
	{
		/// <summary>The <c>Activate</c> method creates a COM object with the specified interface.</summary>
		/// <param name="iid">
		/// <para>
		/// The interface identifier. This parameter is a reference to a GUID that identifies the interface that the caller requests be
		/// activated. The caller will use this interface to communicate with the COM object. Set this parameter to one of the following
		/// interface identifiers:
		/// </para>
		/// <para>IID_IAudioClient</para>
		/// <para>IID_IAudioEndpointVolume</para>
		/// <para>IID_IAudioMeterInformation</para>
		/// <para>IID_IAudioSessionManager</para>
		/// <para>IID_IAudioSessionManager2</para>
		/// <para>IID_IBaseFilter</para>
		/// <para>IID_IDeviceTopology</para>
		/// <para>IID_IDirectSound</para>
		/// <para>IID_IDirectSound8</para>
		/// <para>IID_IDirectSoundCapture</para>
		/// <para>IID_IDirectSoundCapture8</para>
		/// <para>IID_IMFTrustedOutput</para>
		/// <para>IID_ISpatialAudioClient</para>
		/// <para>IID_ISpatialAudioMetadataClient</para>
		/// <para>For more information, see Remarks.</para>
		/// </param>
		/// <param name="dwClsCtx">
		/// The execution context in which the code that manages the newly created object will run. The caller can restrict the context
		/// by setting this parameter to the bitwise <c>OR</c> of one or more <c>CLSCTX</c> enumeration values. Alternatively, the
		/// client can avoid imposing any context restrictions by specifying CLSCTX_ALL. For more information about <c>CLSCTX</c>, see
		/// the Windows SDK documentation.
		/// </param>
		/// <param name="pActivationParams">
		/// Set to <c>NULL</c> to activate an IAudioClient, IAudioEndpointVolume, IAudioMeterInformation, IAudioSessionManager, or
		/// IDeviceTopology interface on an audio endpoint device. When activating an <c>IBaseFilter</c>, <c>IDirectSound</c>,
		/// <c>IDirectSound8</c>, <c>IDirectSoundCapture</c>, or <c>IDirectSoundCapture8</c> interface on the device, the caller can
		/// specify a pointer to a <c>PROPVARIANT</c> structure that contains stream-initialization information. For more information,
		/// see Remarks.
		/// </param>
		/// <param name="ppInterface">
		/// Pointer to a pointer variable into which the method writes the address of the interface specified by parameter iid. Through
		/// this method, the caller obtains a counted reference to the interface. The caller is responsible for releasing the interface,
		/// when it is no longer needed, by calling the interface's <c>Release</c> method. If the <c>Activate</c> call fails,
		/// *ppInterface is <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. If it fails, possible return codes include, but are not limited to, the values
		/// shown in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>The object does not support the requested interface type.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>Parameter ppInterface is NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pActivationParams parameter must be NULL for the specified interface; or pActivationParams points to invalid data.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Out of memory.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
		/// <term>The user has removed either the audio endpoint device or the adapter device that the endpoint device connects to.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method creates a COM object with an interface that is specified by the iid parameter. The method is similar to the
		/// Windows <c>CoCreateInstance</c> function, except that the caller does not supply a CLSID as a parameter. For more
		/// information about <c>CoCreateInstance</c>, see the Windows SDK documentation.
		/// </para>
		/// <para>
		/// A client can call the <c>Activate</c> method of the <c>IMMDevice</c> interface for a particular audio endpoint device to
		/// obtain a counted reference to an interface on that device. The method can activate the following interfaces:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>IAudioClient</term>
		/// </item>
		/// <item>
		/// <term>IAudioEndpointVolume</term>
		/// </item>
		/// <item>
		/// <term>IAudioMeterInformation</term>
		/// </item>
		/// <item>
		/// <term>IAudioSessionManager</term>
		/// </item>
		/// <item>
		/// <term>IAudioSessionManager2</term>
		/// </item>
		/// <item>
		/// <term>IBaseFilter</term>
		/// </item>
		/// <item>
		/// <term>IDeviceTopology</term>
		/// </item>
		/// <item>
		/// <term>IDirectSound</term>
		/// </item>
		/// <item>
		/// <term>IDirectSound8</term>
		/// </item>
		/// <item>
		/// <term>IDirectSoundCapture</term>
		/// </item>
		/// <item>
		/// <term>IDirectSoundCapture8</term>
		/// </item>
		/// <item>
		/// <term>IMFTrustedOutput</term>
		/// </item>
		/// </list>
		/// <para>
		/// To obtain the interface ID for an interface, use the <c>__uuidof</c> operator. For example, the interface ID of
		/// <c>IAudioCaptureClient</c> is defined as follows:
		/// </para>
		/// <para>
		/// For information about the <c>__uuidof</c> operator, see the Windows SDK documentation. For information about
		/// <c>IBaseFilter</c>, <c>IDirectSound</c>, <c>IDirectSound8</c>, <c>IDirectSoundCapture</c>, <c>IDirectSoundCapture8</c>, and
		/// <c>IMFTrustedOutput</c> see the Windows SDK documentation.
		/// </para>
		/// <para>
		/// The pActivationParams parameter should be <c>NULL</c> for an <c>Activate</c> call to create an <c>IAudioClient</c>,
		/// <c>IAudioEndpointVolume</c>, <c>IAudioMeterInformation</c>, <c>IAudioSessionManager</c>, or <c>IDeviceTopology</c> interface
		/// for an audio endpoint device.
		/// </para>
		/// <para>
		/// For an <c>Activate</c> call to create an <c>IBaseFilter</c>, <c>IDirectSound</c>, <c>IDirectSound8</c>,
		/// <c>IDirectSoundCapture</c>, or <c>IDirectSoundCapture8</c> interface, the caller can, as an option, specify a non-
		/// <c>NULL</c> value for pActivationParams. In this case, pActivationParams points to a <c>PROPVARIANT</c> structure that
		/// contains stream-initialization information. Set the <c>vt</c> member of the structure to VT_BLOB. Set the
		/// <c>blob.pBlobData</c> member to point to a DIRECTX_AUDIO_ACTIVATION_PARAMS structure that contains an audio session GUID and
		/// stream-initialization flags. Set the <c>blob.cbSize</c> member to <c>sizeof</c>( <c>DIRECTX_AUDIO_ACTIVATION_PARAMS</c>).
		/// For a code example, see Device Roles for DirectShow Applications. For more information about <c>PROPVARIANT</c>, see the
		/// Windows SDK documentation.
		/// </para>
		/// <para>
		/// An <c>IBaseFilter</c>, <c>IDirectSound</c>, <c>IDirectSound8</c>, <c>IDirectSoundCapture</c>, or <c>IDirectSoundCapture8</c>
		/// interface instance that is created by the <c>Activate</c> method encapsulates a stream on the audio endpoint device. During
		/// the <c>Activate</c> call, the DirectSound system module creates the stream by calling the IAudioClient::Initialize method.
		/// If pActivationParams is non- <c>NULL</c>, DirectSound supplies the audio session GUID and stream-initialization flags from
		/// the <c>DIRECTX_AUDIO_ACTIVATION_PARAMS</c> structure as input parameters to the <c>Initialize</c> call. If pActivationParams
		/// is <c>NULL</c>, DirectSound sets the <c>Initialize</c> method's AudioSessionGuid and StreamFlags parameters to their
		/// respective default values, <c>NULL</c> and 0. These values instruct the method to assign the stream to the process-specific
		/// session that is identified by the session GUID value GUID_NULL.
		/// </para>
		/// <para>
		/// <c>Activate</c> can activate an <c>IDirectSound</c> or <c>IDirectSound8</c> interface only on a rendering endpoint device.
		/// It can activate an <c>IDirectSoundCapture</c> or <c>IDirectSoundCapture8</c> interface only on a capture endpoint device. An
		/// <c>Activate</c> call to activate an <c>IDirectSound</c> or <c>IDirectSoundCapture8</c> interface on a capture device or an
		/// <c>IDirectSoundCapture</c> or <c>IDirectSoundCapture8</c> interface on a rendering device fails and returns error code E_NOINTERFACE.
		/// </para>
		/// <para>
		/// In Windows 7, a client can call <c>IMMDevice::Activate</c> and specify, <c>IID_IMFTrustedOutput</c>, to create an output
		/// trust authorities (OTA) object and retrieve a pointer to the object's IMFTrustedOutput interface. OTAs can operate inside or
		/// outside the Media Foundation's protected media path (PMP) and send content outside the Media Foundation pipeline. If the
		/// caller is outside PMP, then the OTA may not operate in the PMP, and the protection settings are less robust. For information
		/// about using protected objects for audio and example code, see Protected User Mode Audio (PUMA).
		/// </para>
		/// <para>
		/// For general information about protected objects and IMFTrustedOutput, see "Protected Media Path" in Media Foundation documentation.
		/// </para>
		/// <para>
		/// <c>Note</c> When using the ISpatialAudioClient interfaces on an Xbox One Development Kit (XDK) title, you must first call
		/// <c>EnableSpatialAudio</c> before calling IMMDeviceEnumerator::EnumAudioEndpoints or
		/// IMMDeviceEnumerator::GetDefaultAudioEndpoint. Failure to do so will result in an E_NOINTERFACE error being returned from the
		/// call to Activate. <c>EnableSpatialAudio</c> is only available for XDK titles, and does not need to be called for Universal
		/// Windows Platform apps running on Xbox One, nor for any non-Xbox One devices.
		/// </para>
		/// <para>For code examples that call the <c>Activate</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Device Topologies</term>
		/// </item>
		/// <item>
		/// <term>Using the IKsControl Interface to Access Audio Properties</term>
		/// </item>
		/// <item>
		/// <term>Audio Events for Legacy Audio Applications</term>
		/// </item>
		/// <item>
		/// <term>Render Spatial Sound Using Spatial Audio Objects</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-immdevice-activate HRESULT Activate( REFIID
		// iid, DWORD dwClsCtx, PROPVARIANT *pActivationParams, void **ppInterface );
		[PreserveSig]
		HRESULT Activate([In] in Guid iid, [In] CLSCTX dwClsCtx, [In, Optional] PROPVARIANT? pActivationParams, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppInterface);

		/// <summary>The <c>OpenPropertyStore</c> method retrieves an interface to the device's property store.</summary>
		/// <param name="stgmAccess">
		/// <para>
		/// The storage-access mode. This parameter specifies whether to open the property store in read mode, write mode, or read/write
		/// mode. Set this parameter to one of the following STGM constants:
		/// </para>
		/// <para>STGM_READ</para>
		/// <para>STGM_WRITE</para>
		/// <para>STGM_READWRITE</para>
		/// <para>
		/// The method permits a client running as an administrator to open a store for read-only, write-only, or read/write access. A
		/// client that is not running as an administrator is restricted to read-only access. For more information about STGM constants,
		/// see the Windows SDK documentation.
		/// </para>
		/// </param>
		/// <returns>
		/// Pointer to a pointer variable into which the method writes the address of the <c>IPropertyStore</c> interface of the
		/// device's property store. Through this method, the caller obtains a counted reference to the interface. The caller is
		/// responsible for releasing the interface, when it is no longer needed, by calling the interface's <c>Release</c> method. If
		/// the <c>OpenPropertyStore</c> call fails, *ppProperties is <c>NULL</c>. For more information about <c>IPropertyStore</c>, see
		/// the Windows SDK documentation.
		/// </returns>
		/// <remarks>
		/// <para>
		/// In general, the properties in the device's property store are read-only for clients that do not perform administrative,
		/// system, or service functions.
		/// </para>
		/// <para>For code examples that call the <c>OpenPropertyStore</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Device Properties</term>
		/// </item>
		/// <item>
		/// <term>Device Roles for DirectSound Applications</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-immdevice-openpropertystore HRESULT
		// OpenPropertyStore( DWORD stgmAccess, IPropertyStore **ppProperties );
		IPropertyStore? OpenPropertyStore(STGM stgmAccess);

		/// <summary>The <c>GetId</c> method retrieves an endpoint ID string that identifies the audio endpoint device.</summary>
		/// <returns>
		/// Pointer to a pointer variable into which the method writes the address of a null-terminated, wide-character string
		/// containing the endpoint device ID. The method allocates the storage for the string. The caller is responsible for freeing
		/// the storage, when it is no longer needed, by calling the <c>CoTaskMemFree</c> function. If the <c>GetId</c> call fails,
		/// *ppstrId is NULL. For information about <c>CoTaskMemFree</c>, see the Windows SDK documentation.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The endpoint ID string obtained from this method identifies the audio endpoint device that is represented by the
		/// <c>IMMDevice</c> interface instance. A client can use the endpoint ID string to create an instance of the audio endpoint
		/// device at a later time or in a different process by calling the IMMDeviceEnumerator::GetDevice method. Clients should treat
		/// the contents of the endpoint ID string as opaque. That is, clients should not attempt to parse the contents of the string to
		/// obtain information about the device. The reason is that the string format is undefined and might change from one
		/// implementation of the MMDevice API system module to the next.
		/// </para>
		/// <para>For code examples that call the <c>GetId</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Device Properties</term>
		/// </item>
		/// <item>
		/// <term>Device Roles for Legacy Windows Multimedia Applications</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-immdevice-getid HRESULT GetId( PWSTR *ppstrId );
		SafeCoTaskMemString GetId();

		/// <summary>The <c>GetState</c> method retrieves the current device state.</summary>
		/// <returns>
		/// <para>
		/// Pointer to a <c>DWORD</c> variable into which the method writes the current state of the device. The device-state value is
		/// one of the following DEVICE_STATE_XXX constants:
		/// </para>
		/// <para>DEVICE_STATE_ACTIVE</para>
		/// <para>DEVICE_STATE_DISABLED</para>
		/// <para>DEVICE_STATE_NOTPRESENT</para>
		/// <para>DEVICE_STATE_UNPLUGGED</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-immdevice-getstate HRESULT GetState( DWORD
		// *pdwState );
		DEVICE_STATE GetState();
	}

	/// <summary>The <c>Activate</c> method creates a COM object with the specified interface.</summary>
	/// <typeparam name="TOut">
	/// Can be one of the following interfaces:
	/// <list type="bullet">
	/// <item>
	/// <term>IAudioClient</term>
	/// </item>
	/// <item>
	/// <term>IAudioEndpointVolume</term>
	/// </item>
	/// <item>
	/// <term>IAudioMeterInformation</term>
	/// </item>
	/// <item>
	/// <term>IAudioSessionManager</term>
	/// </item>
	/// <item>
	/// <term>IAudioSessionManager2</term>
	/// </item>
	/// <item>
	/// <term>IBaseFilter</term>
	/// </item>
	/// <item>
	/// <term>IDeviceTopology</term>
	/// </item>
	/// <item>
	/// <term>IDirectSound</term>
	/// </item>
	/// <item>
	/// <term>IDirectSound8</term>
	/// </item>
	/// <item>
	/// <term>IDirectSoundCapture</term>
	/// </item>
	/// <item>
	/// <term>IDirectSoundCapture8</term>
	/// </item>
	/// <item>
	/// <term>IMFTrustedOutput</term>
	/// </item>
	/// </list>
	/// </typeparam>
	/// <param name="device">The <see cref="IMMDevice"/> instance.</param>
	/// <param name="dwClsCtx">
	/// The execution context in which the code that manages the newly created object will run. The caller can restrict the context by
	/// setting this parameter to the bitwise <c>OR</c> of one or more <c>CLSCTX</c> enumeration values. Alternatively, the client can
	/// avoid imposing any context restrictions by specifying CLSCTX_ALL. For more information about <c>CLSCTX</c>, see the Windows SDK documentation.
	/// </param>
	/// <param name="pActivationParams">
	/// Set to <c>NULL</c> to activate an IAudioClient, IAudioEndpointVolume, IAudioMeterInformation, IAudioSessionManager, or
	/// IDeviceTopology interface on an audio endpoint device. When activating an <c>IBaseFilter</c>, <c>IDirectSound</c>,
	/// <c>IDirectSound8</c>, <c>IDirectSoundCapture</c>, or <c>IDirectSoundCapture8</c> interface on the device, the caller can specify
	/// a pointer to a <c>PROPVARIANT</c> structure that contains stream-initialization information. For more information, see Remarks.
	/// </param>
	/// <returns>
	/// The interface specified by <typeparamref name="TOut"/>. Through this method, the caller obtains a counted reference to the
	/// interface. The caller is responsible for releasing the interface, when it is no longer needed, by calling the interface's
	/// <c>Release</c> method. If the <c>Activate</c> call fails, this value is <c>NULL</c>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This method creates a COM object with an interface that is specified by the iid parameter. The method is similar to the Windows
	/// <c>CoCreateInstance</c> function, except that the caller does not supply a CLSID as a parameter. For more information about
	/// <c>CoCreateInstance</c>, see the Windows SDK documentation.
	/// </para>
	/// <para>
	/// A client can call the <c>Activate</c> method of the <c>IMMDevice</c> interface for a particular audio endpoint device to obtain
	/// a counted reference to an interface on that device. The method can activate the following interfaces:
	/// </para>
	/// <para>
	/// To obtain the interface ID for an interface, use the <c>__uuidof</c> operator. For example, the interface ID of
	/// <c>IAudioCaptureClient</c> is defined as follows:
	/// </para>
	/// <para>
	/// For information about the <c>__uuidof</c> operator, see the Windows SDK documentation. For information about <c>IBaseFilter</c>,
	/// <c>IDirectSound</c>, <c>IDirectSound8</c>, <c>IDirectSoundCapture</c>, <c>IDirectSoundCapture8</c>, and <c>IMFTrustedOutput</c>
	/// see the Windows SDK documentation.
	/// </para>
	/// <para>
	/// The pActivationParams parameter should be <c>NULL</c> for an <c>Activate</c> call to create an <c>IAudioClient</c>,
	/// <c>IAudioEndpointVolume</c>, <c>IAudioMeterInformation</c>, <c>IAudioSessionManager</c>, or <c>IDeviceTopology</c> interface for
	/// an audio endpoint device.
	/// </para>
	/// <para>
	/// For an <c>Activate</c> call to create an <c>IBaseFilter</c>, <c>IDirectSound</c>, <c>IDirectSound8</c>,
	/// <c>IDirectSoundCapture</c>, or <c>IDirectSoundCapture8</c> interface, the caller can, as an option, specify a non- <c>NULL</c>
	/// value for pActivationParams. In this case, pActivationParams points to a <c>PROPVARIANT</c> structure that contains
	/// stream-initialization information. Set the <c>vt</c> member of the structure to VT_BLOB. Set the <c>blob.pBlobData</c> member to
	/// point to a DIRECTX_AUDIO_ACTIVATION_PARAMS structure that contains an audio session GUID and stream-initialization flags. Set
	/// the <c>blob.cbSize</c> member to <c>sizeof</c>( <c>DIRECTX_AUDIO_ACTIVATION_PARAMS</c>). For a code example, see Device Roles
	/// for DirectShow Applications. For more information about <c>PROPVARIANT</c>, see the Windows SDK documentation.
	/// </para>
	/// <para>
	/// An <c>IBaseFilter</c>, <c>IDirectSound</c>, <c>IDirectSound8</c>, <c>IDirectSoundCapture</c>, or <c>IDirectSoundCapture8</c>
	/// interface instance that is created by the <c>Activate</c> method encapsulates a stream on the audio endpoint device. During the
	/// <c>Activate</c> call, the DirectSound system module creates the stream by calling the IAudioClient::Initialize method. If
	/// pActivationParams is non- <c>NULL</c>, DirectSound supplies the audio session GUID and stream-initialization flags from the
	/// <c>DIRECTX_AUDIO_ACTIVATION_PARAMS</c> structure as input parameters to the <c>Initialize</c> call. If pActivationParams is
	/// <c>NULL</c>, DirectSound sets the <c>Initialize</c> method's AudioSessionGuid and StreamFlags parameters to their respective
	/// default values, <c>NULL</c> and 0. These values instruct the method to assign the stream to the process-specific session that is
	/// identified by the session GUID value GUID_NULL.
	/// </para>
	/// <para>
	/// <c>Activate</c> can activate an <c>IDirectSound</c> or <c>IDirectSound8</c> interface only on a rendering endpoint device. It
	/// can activate an <c>IDirectSoundCapture</c> or <c>IDirectSoundCapture8</c> interface only on a capture endpoint device. An
	/// <c>Activate</c> call to activate an <c>IDirectSound</c> or <c>IDirectSoundCapture8</c> interface on a capture device or an
	/// <c>IDirectSoundCapture</c> or <c>IDirectSoundCapture8</c> interface on a rendering device fails and returns error code E_NOINTERFACE.
	/// </para>
	/// <para>
	/// In Windows 7, a client can call <c>IMMDevice::Activate</c> and specify, <c>IID_IMFTrustedOutput</c>, to create an output trust
	/// authorities (OTA) object and retrieve a pointer to the object's IMFTrustedOutput interface. OTAs can operate inside or outside
	/// the Media Foundation's protected media path (PMP) and send content outside the Media Foundation pipeline. If the caller is
	/// outside PMP, then the OTA may not operate in the PMP, and the protection settings are less robust. For information about using
	/// protected objects for audio and example code, see Protected User Mode Audio (PUMA).
	/// </para>
	/// <para>For general information about protected objects and IMFTrustedOutput, see "Protected Media Path" in Media Foundation documentation.</para>
	/// <para>
	/// <c>Note</c> When using the ISpatialAudioClient interfaces on an Xbox One Development Kit (XDK) title, you must first call
	/// <c>EnableSpatialAudio</c> before calling IMMDeviceEnumerator::EnumAudioEndpoints or
	/// IMMDeviceEnumerator::GetDefaultAudioEndpoint. Failure to do so will result in an E_NOINTERFACE error being returned from the
	/// call to Activate. <c>EnableSpatialAudio</c> is only available for XDK titles, and does not need to be called for Universal
	/// Windows Platform apps running on Xbox One, nor for any non-Xbox One devices.
	/// </para>
	/// <para>For code examples that call the <c>Activate</c> method, see the following topics:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Rendering a Stream</term>
	/// </item>
	/// <item>
	/// <term>Device Topologies</term>
	/// </item>
	/// <item>
	/// <term>Using the IKsControl Interface to Access Audio Properties</term>
	/// </item>
	/// <item>
	/// <term>Audio Events for Legacy Audio Applications</term>
	/// </item>
	/// <item>
	/// <term>Render Spatial Sound Using Spatial Audio Objects</term>
	/// </item>
	/// </list>
	/// </remarks>
	public static TOut Activate<TOut>(this IMMDevice device, [In] CLSCTX dwClsCtx = CLSCTX.CLSCTX_ALL, [In] PROPVARIANT? pActivationParams = null) where TOut : class
	{
		device.Activate(typeof(TOut).GUID, dwClsCtx, pActivationParams, out var intf).ThrowIfFailed();
		return (TOut)intf!;
	}

	/// <summary>The <c>Activate</c> method creates a COM object with the specified interface.</summary>
	/// <typeparam name="TOut">
	/// Can be one of the following interfaces:
	/// <list type="bullet">
	/// <item>
	/// <term>IAudioClient</term>
	/// </item>
	/// <item>
	/// <term>IAudioEndpointVolume</term>
	/// </item>
	/// <item>
	/// <term>IAudioMeterInformation</term>
	/// </item>
	/// <item>
	/// <term>IAudioSessionManager</term>
	/// </item>
	/// <item>
	/// <term>IAudioSessionManager2</term>
	/// </item>
	/// <item>
	/// <term>IBaseFilter</term>
	/// </item>
	/// <item>
	/// <term>IDeviceTopology</term>
	/// </item>
	/// <item>
	/// <term>IDirectSound</term>
	/// </item>
	/// <item>
	/// <term>IDirectSound8</term>
	/// </item>
	/// <item>
	/// <term>IDirectSoundCapture</term>
	/// </item>
	/// <item>
	/// <term>IDirectSoundCapture8</term>
	/// </item>
	/// <item>
	/// <term>IMFTrustedOutput</term>
	/// </item>
	/// </list>
	/// </typeparam>
	/// <typeparam name="TIn">The type of the structure that is to be wrapped in a <see cref="BLOB"/>.</typeparam>
	/// <param name="device">The <see cref="IMMDevice"/> instance.</param>
	/// <param name="dwClsCtx">
	/// The execution context in which the code that manages the newly created object will run. The caller can restrict the context by
	/// setting this parameter to the bitwise <c>OR</c> of one or more <c>CLSCTX</c> enumeration values. Alternatively, the client can avoid
	/// imposing any context restrictions by specifying CLSCTX_ALL. For more information about <c>CLSCTX</c>, see the Windows SDK documentation.
	/// </param>
	/// <param name="pActivationParams">
	/// Set to <c>NULL</c> to activate an IAudioClient, IAudioEndpointVolume, IAudioMeterInformation, IAudioSessionManager, or
	/// IDeviceTopology interface on an audio endpoint device. When activating an <c>IBaseFilter</c>, <c>IDirectSound</c>,
	/// <c>IDirectSound8</c>, <c>IDirectSoundCapture</c>, or <c>IDirectSoundCapture8</c> interface on the device, the caller can specify a
	/// pointer to a <c>PROPVARIANT</c> structure that contains stream-initialization information. For more information, see Remarks.
	/// </param>
	/// <returns>
	/// The interface specified by <typeparamref name="TOut"/>. Through this method, the caller obtains a counted reference to the interface.
	/// The caller is responsible for releasing the interface, when it is no longer needed, by calling the interface's <c>Release</c> method.
	/// If the <c>Activate</c> call fails, this value is <c>NULL</c>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This method creates a COM object with an interface that is specified by the iid parameter. The method is similar to the Windows
	/// <c>CoCreateInstance</c> function, except that the caller does not supply a CLSID as a parameter. For more information about
	/// <c>CoCreateInstance</c>, see the Windows SDK documentation.
	/// </para>
	/// <para>
	/// A client can call the <c>Activate</c> method of the <c>IMMDevice</c> interface for a particular audio endpoint device to obtain a
	/// counted reference to an interface on that device. The method can activate the following interfaces:
	/// </para>
	/// <para>
	/// To obtain the interface ID for an interface, use the <c>__uuidof</c> operator. For example, the interface ID of
	/// <c>IAudioCaptureClient</c> is defined as follows:
	/// </para>
	/// <para>
	/// For information about the <c>__uuidof</c> operator, see the Windows SDK documentation. For information about <c>IBaseFilter</c>,
	/// <c>IDirectSound</c>, <c>IDirectSound8</c>, <c>IDirectSoundCapture</c>, <c>IDirectSoundCapture8</c>, and <c>IMFTrustedOutput</c> see
	/// the Windows SDK documentation.
	/// </para>
	/// <para>
	/// The pActivationParams parameter should be <c>NULL</c> for an <c>Activate</c> call to create an <c>IAudioClient</c>,
	/// <c>IAudioEndpointVolume</c>, <c>IAudioMeterInformation</c>, <c>IAudioSessionManager</c>, or <c>IDeviceTopology</c> interface for an
	/// audio endpoint device.
	/// </para>
	/// <para>
	/// For an <c>Activate</c> call to create an <c>IBaseFilter</c>, <c>IDirectSound</c>, <c>IDirectSound8</c>, <c>IDirectSoundCapture</c>,
	/// or <c>IDirectSoundCapture8</c> interface, the caller can, as an option, specify a non- <c>NULL</c> value for pActivationParams. In
	/// this case, pActivationParams points to a <c>PROPVARIANT</c> structure that contains stream-initialization information. Set the
	/// <c>vt</c> member of the structure to VT_BLOB. Set the <c>blob.pBlobData</c> member to point to a DIRECTX_AUDIO_ACTIVATION_PARAMS
	/// structure that contains an audio session GUID and stream-initialization flags. Set the <c>blob.cbSize</c> member to <c>sizeof</c>(
	/// <c>DIRECTX_AUDIO_ACTIVATION_PARAMS</c>). For a code example, see Device Roles for DirectShow Applications. For more information about
	/// <c>PROPVARIANT</c>, see the Windows SDK documentation.
	/// </para>
	/// <para>
	/// An <c>IBaseFilter</c>, <c>IDirectSound</c>, <c>IDirectSound8</c>, <c>IDirectSoundCapture</c>, or <c>IDirectSoundCapture8</c>
	/// interface instance that is created by the <c>Activate</c> method encapsulates a stream on the audio endpoint device. During the
	/// <c>Activate</c> call, the DirectSound system module creates the stream by calling the IAudioClient::Initialize method. If
	/// pActivationParams is non- <c>NULL</c>, DirectSound supplies the audio session GUID and stream-initialization flags from the
	/// <c>DIRECTX_AUDIO_ACTIVATION_PARAMS</c> structure as input parameters to the <c>Initialize</c> call. If pActivationParams is
	/// <c>NULL</c>, DirectSound sets the <c>Initialize</c> method's AudioSessionGuid and StreamFlags parameters to their respective default
	/// values, <c>NULL</c> and 0. These values instruct the method to assign the stream to the process-specific session that is identified
	/// by the session GUID value GUID_NULL.
	/// </para>
	/// <para>
	/// <c>Activate</c> can activate an <c>IDirectSound</c> or <c>IDirectSound8</c> interface only on a rendering endpoint device. It can
	/// activate an <c>IDirectSoundCapture</c> or <c>IDirectSoundCapture8</c> interface only on a capture endpoint device. An <c>Activate</c>
	/// call to activate an <c>IDirectSound</c> or <c>IDirectSoundCapture8</c> interface on a capture device or an <c>IDirectSoundCapture</c>
	/// or <c>IDirectSoundCapture8</c> interface on a rendering device fails and returns error code E_NOINTERFACE.
	/// </para>
	/// <para>
	/// In Windows 7, a client can call <c>IMMDevice::Activate</c> and specify, <c>IID_IMFTrustedOutput</c>, to create an output trust
	/// authorities (OTA) object and retrieve a pointer to the object's IMFTrustedOutput interface. OTAs can operate inside or outside the
	/// Media Foundation's protected media path (PMP) and send content outside the Media Foundation pipeline. If the caller is outside PMP,
	/// then the OTA may not operate in the PMP, and the protection settings are less robust. For information about using protected objects
	/// for audio and example code, see Protected User Mode Audio (PUMA).
	/// </para>
	/// <para>For general information about protected objects and IMFTrustedOutput, see "Protected Media Path" in Media Foundation documentation.</para>
	/// <para>
	/// <c>Note</c> When using the ISpatialAudioClient interfaces on an Xbox One Development Kit (XDK) title, you must first call
	/// <c>EnableSpatialAudio</c> before calling IMMDeviceEnumerator::EnumAudioEndpoints or IMMDeviceEnumerator::GetDefaultAudioEndpoint.
	/// Failure to do so will result in an E_NOINTERFACE error being returned from the call to Activate. <c>EnableSpatialAudio</c> is only
	/// available for XDK titles, and does not need to be called for Universal Windows Platform apps running on Xbox One, nor for any
	/// non-Xbox One devices.
	/// </para>
	/// <para>For code examples that call the <c>Activate</c> method, see the following topics:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Rendering a Stream</term>
	/// </item>
	/// <item>
	/// <term>Device Topologies</term>
	/// </item>
	/// <item>
	/// <term>Using the IKsControl Interface to Access Audio Properties</term>
	/// </item>
	/// <item>
	/// <term>Audio Events for Legacy Audio Applications</term>
	/// </item>
	/// <item>
	/// <term>Render Spatial Sound Using Spatial Audio Objects</term>
	/// </item>
	/// </list>
	/// </remarks>
	public static TOut Activate<TOut, TIn>(this IMMDevice device, [In] CLSCTX dwClsCtx, in TIn pActivationParams) where TOut : class where TIn : struct
	{
		using SafeCoTaskMemStruct<TIn> mem = pActivationParams;
		PROPVARIANT pv = new(new BLOB() { cbSize = mem.Size, pBlobData = mem }, VarEnum.VT_BLOB);
		device.Activate(typeof(TOut).GUID, dwClsCtx, pv, out var intf).ThrowIfFailed();
		return (TOut)intf!;
	}

	/// <summary>
	/// <para>
	/// The <c>IMMDeviceCollection</c> interface represents a collection of multimedia device resources. In the current implementation,
	/// the only device resources that the MMDevice API can create collections of are audio endpoint devices.
	/// </para>
	/// <para>
	/// A client can obtain a reference to an <c>IMMDeviceCollection</c> interface instance by calling the
	/// IMMDeviceEnumerator::EnumAudioEndpoints method. This method creates a collection of endpoint objects, each of which represents
	/// an audio endpoint device in the system. Each endpoint object in the collection supports the IMMDevice and IMMEndpoint
	/// interfaces. For more information, see IMMDeviceEnumerator Interface.
	/// </para>
	/// <para>For a code example that uses the <c>IMMDeviceCollection</c> interface, see Device Properties.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nn-mmdeviceapi-immdevicecollection
	[PInvokeData("mmdeviceapi.h", MSDNShortId = "4769b0a6-a319-4605-8742-5e7c285679cf")]
	[ComImport, Guid("0BD7A1BE-7A1A-44DB-8397-CC5392387B5E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IMMDeviceCollection
	{
		/// <summary>The <c>GetCount</c> method retrieves a count of the devices in the device collection.</summary>
		/// <returns>Pointer to a <c>UINT</c> variable into which the method writes the number of devices in the device collection.</returns>
		/// <remarks>For a code example that calls the <c>GetCount</c> method, see Device Properties.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-immdevicecollection-getcount HRESULT GetCount(
		// UINT *pcDevices );
		uint GetCount();

		/// <summary>The <c>Item</c> method retrieves a pointer to the specified item in the device collection.</summary>
		/// <param name="nDevice">The device number. If the collection contains n devices, the devices are numbered 0 to n– 1.</param>
		/// <param name="ppDevice">
		/// Pointer to a pointer variable into which the method writes the address of the IMMDevice interface of the specified item in
		/// the device collection. Through this method, the caller obtains a counted reference to the interface. The caller is
		/// responsible for releasing the interface, when it is no longer needed, by calling the interface's <c>Release</c> method. If
		/// the <c>Item</c> call fails, *ppDevice is <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. If it fails, possible return codes include, but are not limited to, the values
		/// shown in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>Parameter ppDevice is NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>Parameter nDevice is not a valid device number.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method retrieves a pointer to the <c>IMMDevice</c> interface of the specified item in the device collection. Each item
		/// in the collection is an endpoint object that represents an audio endpoint device. The caller selects a device from the
		/// device collection by specifying the device number. For a collection of n devices, valid device numbers range from 0 to n– 1.
		/// To obtain a count of the devices in a collection, call the IMMDeviceCollection::GetCount method.
		/// </para>
		/// <para>For a code example that calls the <c>Item</c> method, see Device Properties.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-immdevicecollection-item HRESULT Item( UINT
		// nDevice, IMMDevice **ppDevice );
		[PreserveSig]
		HRESULT Item([In] uint nDevice, out IMMDevice? ppDevice);
	}

	/// <summary>
	/// <para>
	/// The <c>IMMDeviceEnumerator</c> interface provides methods for enumerating multimedia device resources. In the current
	/// implementation of the MMDevice API, the only device resources that this interface can enumerate are audio endpoint devices. A
	/// client obtains a reference to an <c>IMMDeviceEnumerator</c> interface by calling the <c>CoCreateInstance</c> function, as
	/// described previously (see MMDevice API).
	/// </para>
	/// <para>
	/// The device resources enumerated by the methods in the <c>IMMDeviceEnumerator</c> interface are represented as collections of
	/// objects with IMMDevice interfaces. A collection has an IMMDeviceCollection interface. The
	/// IMMDeviceEnumerator::EnumAudioEndpoints method creates a device collection.
	/// </para>
	/// <para>
	/// To obtain a pointer to the <c>IMMDevice</c> interface of an item in a device collection, the client calls the
	/// IMMDeviceCollection::Item method.
	/// </para>
	/// <para>For code examples that use the <c>IMMDeviceEnumerator</c> interface, see the following topics:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Device Properties</term>
	/// </item>
	/// <item>
	/// <term>Rendering a Stream</term>
	/// </item>
	/// </list>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nn-mmdeviceapi-immdeviceenumerator
	[PInvokeData("mmdeviceapi.h", MSDNShortId = "1abdeac1-c156-40b8-8b8c-5ddb51e410aa")]
	[ComImport, Guid("A95664D2-9614-4F35-A746-DE8DB63617E6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(MMDeviceEnumerator))]
	public interface IMMDeviceEnumerator
	{
		/// <summary>
		/// The <c>EnumAudioEndpoints</c> method generates a collection of audio endpoint devices that meet the specified criteria.
		/// </summary>
		/// <param name="dataFlow">
		/// <para>
		/// The data-flow direction for the endpoint devices in the collection. The caller should set this parameter to one of the
		/// following EDataFlow enumeration values:
		/// </para>
		/// <para>eRender</para>
		/// <para>eCapture</para>
		/// <para>eAll</para>
		/// <para>If the caller specifies eAll, the method includes both rendering and capture endpoints in the collection.</para>
		/// </param>
		/// <param name="dwStateMask">
		/// <para>
		/// The state or states of the endpoints that are to be included in the collection. The caller should set this parameter to the
		/// bitwise OR of one or more of the following DEVICE_STATE_XXX constants:
		/// </para>
		/// <para>DEVICE_STATE_ACTIVE</para>
		/// <para>DEVICE_STATE_DISABLED</para>
		/// <para>DEVICE_STATE_NOTPRESENT</para>
		/// <para>DEVICE_STATE_UNPLUGGED</para>
		/// <para>
		/// For example, if the caller sets the dwStateMask parameter to DEVICE_STATE_ACTIVE | DEVICE_STATE_UNPLUGGED, the method
		/// includes endpoints that are either active or unplugged from their jacks, but excludes endpoints that are on audio adapters
		/// that have been disabled or are not present. To include all endpoints, regardless of state, set dwStateMask = DEVICE_STATEMASK_ALL.
		/// </para>
		/// </param>
		/// <returns>
		/// Pointer to a pointer variable into which the method writes the address of the IMMDeviceCollection interface of the
		/// device-collection object. Through this method, the caller obtains a counted reference to the interface. The caller is
		/// responsible for releasing the interface, when it is no longer needed, by calling the interface's <c>Release</c> method. If
		/// the <c>EnumAudioEndpoints</c> call fails, *ppDevices is <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// <para>
		/// For example, the following call enumerates all audio-rendering endpoint devices that are currently active (present and not disabled):
		/// </para>
		/// <para>
		/// In the preceding code fragment, variable hr is of type <c>HRESULT</c>, pDevEnum is a pointer to an
		/// <c>IMMDeviceEnumerator</c> interface, and pEndpoints is a pointer to an <c>IMMDeviceCollection</c> interface.
		/// </para>
		/// <para>Examples</para>
		/// <para>For a code example that calls the <c>EnumAudioEndpoints</c> method, see Device Properties.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-immdeviceenumerator-enumaudioendpoints HRESULT
		// EnumAudioEndpoints( EDataFlow dataFlow, DWORD dwStateMask, IMMDeviceCollection **ppDevices );
		IMMDeviceCollection? EnumAudioEndpoints([In] EDataFlow dataFlow, [In] DEVICE_STATE dwStateMask);

		/// <summary>
		/// The <c>GetDefaultAudioEndpoint</c> method retrieves the default audio endpoint for the specified data-flow direction and role.
		/// </summary>
		/// <param name="dataFlow">
		/// <para>
		/// The data-flow direction for the endpoint device. The caller should set this parameter to one of the following two EDataFlow
		/// enumeration values:
		/// </para>
		/// <para>eRender</para>
		/// <para>eCapture</para>
		/// <para>The data-flow direction for a rendering device is eRender. The data-flow direction for a capture device is eCapture.</para>
		/// </param>
		/// <param name="role">
		/// <para>The role of the endpoint device. The caller should set this parameter to one of the following ERole enumeration values:</para>
		/// <para>eConsole</para>
		/// <para>eMultimedia</para>
		/// <para>eCommunications</para>
		/// <para>For more information, see Remarks.</para>
		/// </param>
		/// <returns>
		/// Pointer to a pointer variable into which the method writes the address of the IMMDevice interface of the endpoint object for
		/// the default audio endpoint device. Through this method, the caller obtains a counted reference to the interface. The caller
		/// is responsible for releasing the interface, when it is no longer needed, by calling the interface's <c>Release</c> method.
		/// If the <c>GetDefaultAudioEndpoint</c> call fails, *ppDevice is <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// <para><c>Note</c></para>
		/// <para>
		/// In Windows Vista, the MMDevice API supports device roles but the system-supplied user interface programs do not. The user
		/// interface in Windows Vista enables the user to select a default audio device for rendering and a default audio device for
		/// capture. When the user changes the default rendering or capture device, the system assigns all three device roles (eConsole,
		/// eMultimedia, and eCommunications) to that device. Thus, <c>GetDefaultAudioEndpoint</c> always selects the default rendering
		/// or capture device, regardless of which role is indicated by the role parameter. In a future version of Windows, the user
		/// interface might enable the user to assign individual roles to different devices. In that case, the selection of a rendering
		/// or capture device by <c>GetDefaultAudioEndpoint</c> might depend on the role parameter. Thus, the behavior of an audio
		/// application developed to run in Windows Vista might change when run in a future version of Windows. For more information,
		/// see Device Roles in Windows Vista.
		/// </para>
		/// <para>
		/// This method retrieves the default endpoint device for the specified data-flow direction (rendering or capture) and role. For
		/// example, a client can get the default console playback device by making the following call:
		/// </para>
		/// <para>
		/// In the preceding code fragment, variable hr is of type <c>HRESULT</c>, pDevEnum is a pointer to an
		/// <c>IMMDeviceEnumerator</c> interface, and pDeviceOut is a pointer to an <c>IMMDevice</c> interface.
		/// </para>
		/// <para>
		/// A Windows system might contain some combination of audio endpoint devices such as desktop speakers, high-fidelity
		/// headphones, desktop microphones, headsets with speaker and microphones, and high-fidelity multichannel speakers. The user
		/// can assign appropriate roles to the devices. For example, an application that manages voice communications streams can call
		/// <c>GetDefaultAudioEndpoint</c> to identify the designated rendering and capture devices for that role.
		/// </para>
		/// <para>
		/// If only a single rendering or capture device is available, the system always assigns all three rendering or capture roles to
		/// that device. If the method fails to find a rendering or capture device for the specified role, this means that no rendering
		/// or capture device is available at all. If no device is available, the method sets *ppEndpoint = <c>NULL</c> and returns ERROR_NOT_FOUND.
		/// </para>
		/// <para>For code examples that call the <c>GetDefaultAudioEndpoint</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Audio Events for Legacy Audio Applications</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-immdeviceenumerator-getdefaultaudioendpoint
		// HRESULT GetDefaultAudioEndpoint( EDataFlow dataFlow, ERole role, IMMDevice **ppEndpoint );
		IMMDevice? GetDefaultAudioEndpoint([In] EDataFlow dataFlow, [In] ERole role);

		/// <summary>The <c>GetDevice</c> method retrieves an audio endpoint device that is identified by an endpoint ID string.</summary>
		/// <param name="pwstrId">
		/// Pointer to a string containing the endpoint ID. The caller typically obtains this string from the IMMDevice::GetId method or
		/// from one of the methods in the IMMNotificationClient interface.
		/// </param>
		/// <returns>
		/// Pointer to a pointer variable into which the method writes the address of the IMMDevice interface for the specified device.
		/// Through this method, the caller obtains a counted reference to the interface. The caller is responsible for releasing the
		/// interface, when it is no longer needed, by calling the interface's <c>Release</c> method. If the <c>GetDevice</c> call
		/// fails, *ppDevice is <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If two programs are running in two different processes and both need to access the same audio endpoint device, one program
		/// cannot simply pass the device's <c>IMMDevice</c> interface to the other program. However, the programs can access the same
		/// device by following these steps:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// The first program calls the <c>IMMDevice::GetId</c> method in the first process to obtain the endpoint ID string that
		/// identifies the device.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The first program passes the endpoint ID string across the process boundary to the second program.</term>
		/// </item>
		/// <item>
		/// <term>
		/// To obtain a reference to the device's <c>IMMDevice</c> interface in the second process, the second program calls
		/// <c>GetDevice</c> with the endpoint ID string.
		/// </term>
		/// </item>
		/// </list>
		/// <para>For more information about the <c>GetDevice</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Endpoint ID Strings</term>
		/// </item>
		/// <item>
		/// <term>Audio Events for Legacy Audio Applications</term>
		/// </item>
		/// </list>
		/// <para>For code examples that use the <c>GetDevice</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Device Properties</term>
		/// </item>
		/// <item>
		/// <term>Device Events</term>
		/// </item>
		/// <item>
		/// <term>Using the IKsControl Interface to Access Audio Properties</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-immdeviceenumerator-getdevice HRESULT
		// GetDevice( LPCWSTR pwstrId, IMMDevice **ppDevice );
		IMMDevice? GetDevice([In, MarshalAs(UnmanagedType.LPWStr)] string pwstrId);

		/// <summary>The <c>RegisterEndpointNotificationCallback</c> method registers a client's notification callback interface.</summary>
		/// <param name="pClient">Pointer to the IMMNotificationClient interface that the client is registering for notification callbacks.</param>
		/// <remarks>
		/// <para>
		/// This method registers an IMMNotificationClient interface to be called by the system when the roles, state, existence, or
		/// properties of an endpoint device change. The caller implements the IMMNotificationClient interface.
		/// </para>
		/// <para>
		/// When notifications are no longer needed, the client can call the IMMDeviceEnumerator::UnregisterEndpointNotificationCallback
		/// method to terminate the notifications.
		/// </para>
		/// <para>
		/// The client must ensure that the IMMNotificationClient object is not released after the
		/// <c>RegisterEndpointNotificationCallback</c> call and before calling UnregisterEndpointNotificationCallback. These methods do
		/// not call the client's <c>IMMNotificationClient::AddRef</c> and <c>IMMNotificationClient::Release</c> implementations. The
		/// client is responsible for maintaining the reference count of the <c>IMMNotificationClient</c> object. The client must
		/// increment the count if the <c>RegisterEndpointNotificationCallback</c> call succeeds and release the final reference only
		/// after calling <c>UnregisterEndpointNotificationCallback</c> or implement some other mechanism to ensure that the object is
		/// not deleted before <c>UnregisterEndpointNotificationCallback</c> is called. Otherwise, the application leaks the resources
		/// held by the <c>IMMNotificationClient</c> and any other object that is implemented in the same container.
		/// </para>
		/// <para>
		/// For more information about the <c>AddRef</c> and <c>Release</c> methods, see the discussion of the <c>IUnknown</c> interface
		/// in the Windows SDK documentation.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-immdeviceenumerator-registerendpointnotificationcallback
		// HRESULT RegisterEndpointNotificationCallback( IMMNotificationClient *pClient );
		void RegisterEndpointNotificationCallback([In] IMMNotificationClient pClient);

		/// <summary>
		/// The <c>UnregisterEndpointNotificationCallback</c> method deletes the registration of a notification interface that the
		/// client registered in a previous call to the IMMDeviceEnumerator::RegisterEndpointNotificationCallback method.
		/// </summary>
		/// <param name="pClient">
		/// Pointer to the client's IMMNotificationClient interface. The client passed this same interface pointer to the device
		/// enumerator in a previous call to the IMMDeviceEnumerator::RegisterEndpointNotificationCallback method. For more information,
		/// see Remarks.
		/// </param>
		/// <remarks>
		/// <para>
		/// The client must ensure that the IMMNotificationClient object is not released after the RegisterEndpointNotificationCallback
		/// call and before calling <c>UnregisterEndpointNotificationCallback</c>. These methods do not call the client's
		/// <c>IMMNotificationClient::AddRef</c> and <c>IMMNotificationClient::Release</c> implementations. The client is responsible
		/// for maintaining the reference count of the <c>IMMNotificationClient</c> object. The client must increment the count if the
		/// <c>RegisterEndpointNotificationCallback</c> call succeeds and release the final reference only after calling
		/// <c>UnregisterEndpointNotificationCallback</c> or implement some other mechanism to ensure that the object is not deleted
		/// before <c>UnregisterEndpointNotificationCallback</c> is called. Otherwise, the application leaks the resources held by the
		/// <c>IMMNotificationClient</c> and any other object that is implemented in the same container.
		/// </para>
		/// <para>
		/// For more information about the <c>AddRef</c> and <c>Release</c> methods, see the discussion of the <c>IUnknown</c> interface
		/// in the Windows SDK documentation.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-immdeviceenumerator-unregisterendpointnotificationcallback
		// HRESULT UnregisterEndpointNotificationCallback( IMMNotificationClient *pClient );
		void UnregisterEndpointNotificationCallback([In] IMMNotificationClient pClient);
	}

	/// <summary>
	/// <para>
	/// The <c>IMMEndpoint</c> interface represents an audio endpoint device. A client obtains a reference to an <c>IMMEndpoint</c>
	/// interface instance by following these steps:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// By using one of the techniques described in IMMDevice Interface, obtain a reference to the <c>IMMDevice</c> interface of an
	/// audio endpoint device.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Call the <c>IMMDevice::QueryInterface</c> method with parameter iid set to <c>REFIID</c> IID_IMMEndpoint.</term>
	/// </item>
	/// </list>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nn-mmdeviceapi-immendpoint
	[PInvokeData("mmdeviceapi.h", MSDNShortId = "293de8eb-204a-4c18-807c-b1405db85b12")]
	[ComImport, Guid("1BE09788-6894-4089-8586-9A2A6C265AC5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IMMEndpoint
	{
		/// <summary>
		/// The <c>GetDataFlow</c> method indicates whether the audio endpoint device is a rendering device or a capture device.
		/// </summary>
		/// <returns>
		/// <para>
		/// Pointer to a variable into which the method writes the data-flow direction of the endpoint device. The direction is
		/// indicated by one of the following EDataFlow enumeration constants:
		/// </para>
		/// <para>eRender</para>
		/// <para>eCapture</para>
		/// <para>The data-flow direction for a rendering device is eRender. The data-flow direction for a capture device is eCapture.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-immendpoint-getdataflow HRESULT GetDataFlow(
		// EDataFlow *pDataFlow );
		EDataFlow GetDataFlow();
	}

	/// <summary>
	/// <para>
	/// The <c>IMMNotificationClient</c> interface provides notifications when an audio endpoint device is added or removed, when the
	/// state or properties of an endpoint device change, or when there is a change in the default role assigned to an endpoint device.
	/// Unlike the other interfaces in this section, which are implemented by the MMDevice API system component, an MMDevice API client
	/// implements the <c>IMMNotificationClient</c> interface. To receive notifications, the client passes a pointer to its
	/// <c>IMMNotificationClient</c> interface instance as a parameter to the IMMDeviceEnumerator::RegisterEndpointNotificationCallback method.
	/// </para>
	/// <para>
	/// After registering its <c>IMMNotificationClient</c> interface, the client receives event notifications in the form of callbacks
	/// through the methods of the interface.
	/// </para>
	/// <para>
	/// Each method in the <c>IMMNotificationClient</c> interface receives, as one of its input parameters, an endpoint ID string that
	/// identifies the audio endpoint device that is the subject of the notification. The string uniquely identifies the device with
	/// respect to all of the other audio endpoint devices in the system. The methods in the <c>IMMNotificationClient</c> interface
	/// implementation should treat this string as opaque. That is, none of the methods should attempt to parse the contents of the
	/// string to obtain information about the device. The reason is that the string format is undefined and might change from one
	/// implementation of the MMDevice API system module to the next.
	/// </para>
	/// <para>
	/// A client can use the endpoint ID string that it receives as an input parameter in a call to an <c>IMMNotificationClient</c>
	/// method in two ways:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The client can create an instance of the device that the endpoint ID string identifies. The client does this by calling the
	/// IMMDeviceEnumerator::GetDevice method and supplying the endpoint ID string as an input parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The client can compare the endpoint ID string with the endpoint ID string of an existing device instance. To obtain the second
	/// endpoint ID string, the client calls the IMMDevice::GetId method of the device instance. If the two strings match, they identify
	/// the same device.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// In implementing the <c>IMMNotificationClient</c> interface, the client should observe these rules to avoid deadlocks and
	/// undefined behavior:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The methods of the interface must be nonblocking. The client should never wait on a synchronization object during an event callback.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To avoid dead locks, the client should never call IMMDeviceEnumerator::RegisterEndpointNotificationCallback or
	/// IMMDeviceEnumerator::UnregisterEndpointNotificationCallback in its implementation of <c>IMMNotificationClient</c> methods.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The client should never release the final reference on an MMDevice API object during an event callback.</term>
	/// </item>
	/// </list>
	/// <para>For a code example that implements the <c>IMMNotificationClient</c> interface, see Device Events.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nn-mmdeviceapi-immnotificationclient
	[ComImport, Guid("7991EEC9-7E89-4D85-8390-6C703CEC60C0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[PInvokeData("mmdeviceapi.h")]
	public interface IMMNotificationClient
	{
		/// <summary>The <c>OnDeviceStateChanged</c> method indicates that the state of an audio endpoint device has changed.</summary>
		/// <param name="pwstrDeviceId">
		/// Pointer to the endpoint ID string that identifies the audio endpoint device. This parameter points to a null-terminated,
		/// wide-character string containing the endpoint ID. The string remains valid for the duration of the call.
		/// </param>
		/// <param name="dwNewState">
		/// <para>
		/// Specifies the new state of the endpoint device. The value of this parameter is one of the following DEVICE_STATE_XXX constants:
		/// </para>
		/// <para>DEVICE_STATE_ACTIVE</para>
		/// <para>DEVICE_STATE_DISABLED</para>
		/// <para>DEVICE_STATE_NOTPRESENT</para>
		/// <para>DEVICE_STATE_UNPLUGGED</para>
		/// </param>
		/// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
		/// <remarks>For a code example that implements the <c>OnDeviceStateChanged</c> method, see Device Events.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-immnotificationclient-ondevicestatechanged
		// HRESULT OnDeviceStateChanged( LPCWSTR pwstrDeviceId, DWORD dwNewState );
		[PreserveSig]
		HRESULT OnDeviceStateChanged([In, MarshalAs(UnmanagedType.LPWStr)] string pwstrDeviceId, [In] DEVICE_STATE dwNewState);

		/// <summary>The <c>OnDeviceAdded</c> method indicates that a new audio endpoint device has been added.</summary>
		/// <param name="pwstrDeviceId">
		/// Pointer to the endpoint ID string that identifies the audio endpoint device. This parameter points to a null-terminated,
		/// wide-character string containing the endpoint ID. The string remains valid for the duration of the call.
		/// </param>
		/// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
		/// <remarks>For a code example that implements the <c>OnDeviceAdded</c> method, see Device Events.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-immnotificationclient-ondeviceadded HRESULT
		// OnDeviceAdded( LPCWSTR pwstrDeviceId );
		[PreserveSig]
		HRESULT OnDeviceAdded([In, MarshalAs(UnmanagedType.LPWStr)] string pwstrDeviceId);

		/// <summary>The <c>OnDeviceRemoved</c> method indicates that an audio endpoint device has been removed.</summary>
		/// <param name="pwstrDeviceId">
		/// Pointer to the endpoint ID string that identifies the audio endpoint device. This parameter points to a null-terminated,
		/// wide-character string containing the endpoint ID. The string remains valid for the duration of the call.
		/// </param>
		/// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
		/// <remarks>For a code example that implements the <c>OnDeviceRemoved</c> method, see Device Events.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-immnotificationclient-ondeviceremoved HRESULT
		// OnDeviceRemoved( LPCWSTR pwstrDeviceId );
		[PreserveSig]
		HRESULT OnDeviceRemoved([In, MarshalAs(UnmanagedType.LPWStr)] string pwstrDeviceId);

		/// <summary>
		/// The <c>OnDefaultDeviceChanged</c> method notifies the client that the default audio endpoint device for a particular device
		/// role has changed.
		/// </summary>
		/// <param name="flow">
		/// <para>
		/// The data-flow direction of the endpoint device. This parameter is set to one of the following EDataFlow enumeration values:
		/// </para>
		/// <para>eRender</para>
		/// <para>eCapture</para>
		/// <para>The data-flow direction for a rendering device is eRender. The data-flow direction for a capture device is eCapture.</para>
		/// </param>
		/// <param name="role">
		/// <para>The device role of the audio endpoint device. This parameter is set to one of the following ERole enumeration values:</para>
		/// <para>eConsole</para>
		/// <para>eMultimedia</para>
		/// <para>eCommunications</para>
		/// </param>
		/// <param name="pwstrDefaultDeviceId">
		/// Pointer to the endpoint ID string that identifies the audio endpoint device. This parameter points to a null-terminated,
		/// wide-character string containing the endpoint ID. The string remains valid for the duration of the call. If the user has
		/// removed or disabled the default device for a particular role, and no other device is available to assume that role, then
		/// pwstrDefaultDevice is <c>NULL</c>.
		/// </param>
		/// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
		/// <remarks>
		/// <para>
		/// The three input parameters specify the data-flow direction, device role, and endpoint ID string of the new default audio
		/// endpoint device.
		/// </para>
		/// <para>
		/// In Windows Vista, the MMDevice API supports device roles but the system-supplied user interface programs do not. The user
		/// interface in Windows Vista enables the user to select a default audio device for rendering and a default audio device for
		/// capture. When the user changes the default rendering or capture device, the system assigns all three device roles (eConsole,
		/// eMultimedia, and eCommunications) to the new device. Thus, when the user changes the default rendering or capture device,
		/// the system calls the client's <c>OnDefaultDeviceChanged</c> method three times—once for each of the three device roles.
		/// </para>
		/// <para>
		/// In a future version of Windows, the user interface might enable the user to assign individual roles to different devices. In
		/// that case, if the user changes the assignment of only one or two device roles to a new rendering or capture device, the
		/// system will call the client's <c>OnDefaultDeviceChanged</c> method only once or twice (that is, one call per changed role).
		/// Depending on how the <c>OnDefaultDeviceChanged</c> method responds to role changes, the behavior of an audio application
		/// developed to run in Windows Vista might change when run in a future version of Windows. For more information, see Device
		/// Roles in Windows Vista.
		/// </para>
		/// <para>For a code example that implements the <c>OnDefaultDeviceChanged</c> method, see Device Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-immnotificationclient-ondefaultdevicechanged
		// HRESULT OnDefaultDeviceChanged( EDataFlow flow, ERole role, LPCWSTR pwstrDefaultDeviceId );
		[PreserveSig]
		HRESULT OnDefaultDeviceChanged([In] EDataFlow flow, [In] ERole role, [In, MarshalAs(UnmanagedType.LPWStr)] string? pwstrDefaultDeviceId);

		/// <summary>
		/// The <c>OnPropertyValueChanged</c> method indicates that the value of a property belonging to an audio endpoint device has changed.
		/// </summary>
		/// <param name="pwstrDeviceId">
		/// Pointer to the endpoint ID string that identifies the audio endpoint device. This parameter points to a null-terminated,
		/// wide-character string that contains the endpoint ID. The string remains valid for the duration of the call.
		/// </param>
		/// <param name="key">
		/// A PROPERTYKEY structure that specifies the property. The structure contains the property-set GUID and an index identifying a
		/// property within the set. The structure is passed by value. It remains valid for the duration of the call. For more
		/// information about <c>PROPERTYKEY</c>, see the Windows SDK documentation.
		/// </param>
		/// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
		/// <remarks>
		/// <para>
		/// A call to the IPropertyStore::SetValue method that successfully changes the value of a property of an audio endpoint device
		/// generates a call to <c>OnPropertyValueChanged</c>. For more information about <c>IPropertyStore::SetValue</c>, see the
		/// Windows SDK documentation.
		/// </para>
		/// <para>
		/// A client can use the key parameter to retrieve the new property value. For a code example that uses a property key to
		/// retrieve a property value from the property store of an endpoint device, see Device Properties.
		/// </para>
		/// <para>For a code example that implements the <c>OnPropertyValueChanged</c> method, see Device Events.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-immnotificationclient-onpropertyvaluechanged
		// HRESULT OnPropertyValueChanged( LPCWSTR pwstrDeviceId, const PROPERTYKEY key );
		[PreserveSig]
		HRESULT OnPropertyValueChanged([In, MarshalAs(UnmanagedType.LPWStr)] string pwstrDeviceId, [In] PROPERTYKEY key);
	}

	/// <summary>Enables Windows Store apps to access preexisting Component Object Model (COM) interfaces in the WASAPI family.</summary>
	/// <param name="deviceInterfacePath">
	/// <para>
	/// A device interface ID for an audio device. This is normally retrieved from a DeviceInformation object or one of the methods of
	/// the MediaDevice class.
	/// </para>
	/// <para>
	/// The GUIDs DEVINTERFACE_AUDIO_CAPTURE and <c>DEVINTERFACE_AUDIO_RENDER</c> represent the default audio capture and render device
	/// respectively. Call StringFromIID to convert either of these GUIDs to an <c>LPCWSTR</c> to use for this argument.
	/// </para>
	/// </param>
	/// <param name="riid">The IID of a COM interface in the WASAPI family, such as IAudioClient.</param>
	/// <param name="activationParams">
	/// Interface-specific activation parameters. For more information, see the pActivationParams parameter in IMMDevice::Activate.
	/// </param>
	/// <param name="completionHandler">
	/// An interface implemented by the caller that is called by Windows when the result of the activation procedure is available.
	/// </param>
	/// <param name="activationOperation">
	/// Returns an IActivateAudioInterfaceAsyncOperation interface that represents the asynchronous operation of activating the
	/// requested <c>WASAPI</c> interface.
	/// </param>
	/// <returns>
	/// <para>The function returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The underlying object and asynchronous operation were created successfully.</term>
	/// </item>
	/// <item>
	/// <term>E_ILLEGAL_METHOD_CALL</term>
	/// <term>
	/// This error may result if the function is called from an incorrect COM apartment, or if the passed
	/// IActivateAudioInterfaceCompletionHandler is not implemented on an agile object (aggregating a free-threaded marshaler).
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function enables Windows Store apps to activate certain WASAPI COM interfaces after using Windows Runtime APIs in the
	/// <c>Windows.Devices</c> and Windows.Media.Devices namespaces to select an audio device.
	/// </para>
	/// <para>
	/// For many implementations, an application must call this function from the main UI thread to activate a COM interface in the
	/// WASAPI family so that the system can show a dialog to the user. The application passes an
	/// IActivateAudioInterfaceCompletionHandler callback COM interface through completionHandler. Windows calls a method in the
	/// application’s <c>IActivateAudioInterfaceCompletionHandler</c> interface from a worker thread in the COM Multi-threaded Apartment
	/// (MTA) when the activation results are available. The application can then call a method in the
	/// IActivateAudioInterfaceAsyncOperation interface to retrieve the result code and the requested <c>WASAPI</c> interface. There are
	/// some activations that are explicitly safe and therefore don't require that this function be called from the main UI thread.
	/// These explicitly safe activations include:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Calling <c>ActivateAudioInterfaceAsync</c> with a deviceInterfacePath that specifies an audio render device and an riid that
	/// specifies the IAudioClient interface.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Calling <c>ActivateAudioInterfaceAsync</c> with a deviceInterfacePath that specifies an audio render device and an riid that
	/// specifies the IAudioEndpointVolume interface.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Calling <c>ActivateAudioInterfaceAsync</c> from a session 0 service. For more information, see Services.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Windows holds a reference to the application's IActivateAudioInterfaceCompletionHandler interface until the operation is
	/// complete and the application releases the IActivateAudioInterfaceAsyncOperation interface.
	/// </para>
	/// <para>
	/// <c>Important</c> Applications must not free the object implementing the <c>IActivateAudioInterfaceCompletionHandler</c> until
	/// the completion handler callback has executed.
	/// </para>
	/// <para>
	/// Depending on which WASAPI interface is activated, this function may display a consent prompt the first time it is called. For
	/// example, when the application calls this function to activate IAudioClient to access a microphone, the purpose of the consent
	/// prompt is to get the user's permission for the app to access the microphone. For more information about the consent prompt, see
	/// Guidelines for devices that access personal data.
	/// </para>
	/// <para>
	/// <c>ActivateAudioInterfaceAsync</c> must be called on the main UI thread so that the consent prompt can be shown. If the consent
	/// prompt can’t be shown, the user can’t grant device access to the app.
	/// </para>
	/// <para>
	/// <c>ActivateAudioInterfaceAsync</c> must be called on a thread in a COM Single-Threaded Apartment (STA). The completionHandler
	/// that is passed into <c>ActivateAudioInterfaceAsync</c> needs to implement IAgileObject to ensure that there is no deadlock when
	/// the completionHandler is called from the MTA. Otherwise, an <c>E_ILLEGAL_METHOD_CALL</c> will occur.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/nf-mmdeviceapi-activateaudiointerfaceasync HRESULT
	// ActivateAudioInterfaceAsync( LPCWSTR deviceInterfacePath, REFIID riid, PROPVARIANT *activationParams,
	// IActivateAudioInterfaceCompletionHandler *completionHandler, IActivateAudioInterfaceAsyncOperation **activationOperation );
	[DllImport("mmdevapi.dll", SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmdeviceapi.h", MSDNShortId = "7BAFD9DB-DCD7-4093-A24B-9A8556C6C45B")]
	public static extern HRESULT ActivateAudioInterfaceAsync([MarshalAs(UnmanagedType.LPWStr)] string deviceInterfacePath, in Guid riid, [In, Optional] PROPVARIANT? activationParams,
		[MarshalAs(UnmanagedType.IUnknown)] IActivateAudioInterfaceCompletionHandler completionHandler, [MarshalAs(UnmanagedType.IUnknown)] out IActivateAudioInterfaceAsyncOperation activationOperation);

	/// <summary>The <c>DIRECTX_AUDIO_ACTIVATION_PARAMS</c> structure specifies the initialization parameters for a DirectSound stream.</summary>
	/// <remarks>
	/// <para>
	/// This structure is used by the IMMDevice::Activate method. When activating an <c>IDirectSound</c>, <c>IDirectSoundCapture</c>, or
	/// <c>IBaseFilter</c> interface on an audio endpoint device, the <c>DIRECTX_AUDIO_ACTIVATION_PARAMS</c> structure specifies the
	/// session GUID and stream-initialization flags for the audio stream that the DirectSound module creates and encapsulates in the
	/// interface instance. During the <c>Activate</c> call, DirectSound calls the IAudioClient::Initialize method and specifies the
	/// session GUID and stream-initialization flags from the <c>DIRECTX_AUDIO_ACTIVATION_PARAMS</c> structure as input parameters.
	/// </para>
	/// <para>
	/// For more information about <c>IDirectSound</c>, <c>IDirectSoundCapture</c>, and <c>IBaseFilter</c>, see the Windows SDK documentation.
	/// </para>
	/// <para>For a code example that uses the <c>DIRECTX_AUDIO_ACTIVATION_PARAMS</c> structure, see Device Roles for DirectShow Applications.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmdeviceapi/ns-mmdeviceapi-directx_audio_activation_params typedef struct
	// tagDIRECTX_AUDIO_ACTIVATION_PARAMS { DWORD cbDirectXAudioActivationParams; GUID guidAudioSession; DWORD dwAudioStreamFlags; }
	// DIRECTX_AUDIO_ACTIVATION_PARAMS, *PDIRECTX_AUDIO_ACTIVATION_PARAMS;
	[PInvokeData("mmdeviceapi.h", MSDNShortId = "d8d16c1c-5306-42a7-885b-4e1c5ee7634d")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DIRECTX_AUDIO_ACTIVATION_PARAMS
	{
		/// <summary>The size, in bytes, of the <c>DIRECTX_AUDIO_ACTIVATION_PARAMS</c> structure. Set this member to sizeof(DIRECTX_AUDIO_ACTIVATION_PARAMS).</summary>
		public uint cbDirectXAudioActivationParams;

		/// <summary>
		/// Session GUID. This member is a GUID value that identifies the audio session that the stream belongs to. If the GUID
		/// identifies a session that has been previously opened, the method adds the stream to that session. If the GUID does not
		/// identify an existing session, the method opens a new session and adds the stream to that session. The stream remains a
		/// member of the same session for its lifetime.
		/// </summary>
		public Guid guidAudioSession;

		/// <summary>
		/// <para>
		/// Stream-initialization flags. This member specifies whether the stream belongs to a cross-process session or to a session
		/// that is specific to the current process. Set this member to 0 or to the following AUDCLNT_STREAMFLAGS_XXX constant:
		/// </para>
		/// <para>AUDCLNT_STREAMFLAGS_CROSSPROCESS</para>
		/// </summary>
		public uint dwAudioStreamFlags;
	}

	/// <summary>CoClass for <see cref="IMMDeviceEnumerator"/>.</summary>
	[ComImport, Guid("BCDE0395-E52F-467C-8E3D-C4579291692E"), ClassInterface(ClassInterfaceType.None)]
	[PInvokeData("mmdeviceapi.h")]
	public class MMDeviceEnumerator { }

	/// <summary>The DEVINTERFACE_XXX GUIDs are used to represent the GUIDs for device interfaces.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/coreaudio/devinterface-xxx-guids
	[PInvokeData("mmdeviceapi.h", MSDNShortId = "2503463B-D7C6-4C82-8421-424D79FD1C2A")]
	public static class AudioGuids
	{
		/// <summary>
		/// Specifies the query string used to enumerate all audio capture devices on the system. This value is returned by MediaDevice::GetAudioCaptureSelector.
		/// <para>Passing this value to ActivateAudioInterfaceAsync activates the requested interface on the default audio capture device.</para>
		/// </summary>
		public static readonly Guid DEVINTERFACE_AUDIO_CAPTURE = new(0x2eef81be, 0x33fa, 0x4800, 0x96, 0x70, 0x1c, 0xd4, 0x74, 0x97, 0x2c, 0x3f);

		/// <summary>
		/// Specifies the query string used to enumerate all audio render devices on the system. This value is returned by MediaDevice::GetAudioRenderSelector.
		/// <para>Passing this value to ActivateAudioInterfaceAsync activates the requested interface on the default audio render device.</para>
		/// </summary>
		public static readonly Guid DEVINTERFACE_AUDIO_RENDER = new(0xe6327cad, 0xdcec, 0x4949, 0xae, 0x8a, 0x99, 0x1e, 0x97, 0x6a, 0x79, 0xd2);

		/// <summary>
		/// Specifies the query string used to enumerate all MidiInPort objects on the system. This value is returned by MidiInPort::GetDeviceSelector.
		/// </summary>
		public static readonly Guid DEVINTERFACE_MIDI_INPUT = new(0x504be32c, 0xccf6, 0x4d2c, 0xb7, 0x3f, 0x6f, 0x8b, 0x37, 0x47, 0xe2, 0x2b);

		/// <summary>
		/// Specifies the query string used to enumerate all MidiOutPort objects on the system. This value is returned by MidiOutPort::GetDeviceSelector.
		/// </summary>
		public static readonly Guid DEVINTERFACE_MIDI_OUTPUT = new(0x6dc23320, 0xab33, 0x4ce4, 0x80, 0xd4, 0xbb, 0xb3, 0xeb, 0xbf, 0x28, 0x14);
	}

	/// <summary>Core Audio SDK includes several properties of audio endpoint devices. For more information, see Audio Endpoint Properties.</summary>
	[PInvokeData("mmdeviceapi.h")]
	public static class AudioPropertyKeys
	{
		/// <summary>
		/// <para>
		/// The <c>PKEY_AudioEndpoint_Association</c> property associates a kernel-streaming (KS) pin category with an audio endpoint
		/// device. The .inf file that installs an audio adapter assigns a pin category to each KS pin in the adapter. A KS pin on an
		/// adapter device represents the point at which an audio stream enters or leaves the device. A pin category is a GUID that
		/// specifies the type of function performed by a KS pin. For example, header file Ksmedia.h defines pin-category GUID
		/// KSNODETYPE_MICROPHONE to indicate a KS pin that connects to a microphone, and KSNODETYPE_HEADPHONES to indicate a KS pin
		/// that connects to headphones. For more information, see the description of pin category properties in the Windows DDK documentation.
		/// </para>
		/// <para>The <c>vt</c> member of the <c>PROPVARIANT</c> structure is set to VT_LPWSTR.</para>
		/// <para>
		/// The <c>pwszVal</c> member of the <c>PROPVARIANT</c> structure points to a null-terminated, wide-character string that
		/// contains a KS pin category GUID.
		/// </para>
		/// </summary>
		public static readonly PROPERTYKEY PKEY_AudioEndpoint_Association = new(new Guid(0x1da5d803, 0xd492, 0x4edd, 0x8c, 0x23, 0xe0, 0xc0, 0xff, 0xee, 0x7f, 0x0e), 2);

		/// <summary>
		/// <para>
		/// The <c>PKEY_AudioEndpoint_ControlPanelPageProvider</c> property specifies the CLSID of the registered provider of the
		/// device-properties extension for the audio endpoint device. The extension supplies the audio endpoint properties that are
		/// displayed in the device-properties page of the Windows multimedia control panel, Mmsys.cpl. For more information about
		/// Mmsys.cpl, see the Windows DDK documentation.
		/// </para>
		/// <para>The <c>vt</c> member of the <c>PROPVARIANT</c> structure is set to VT_LPWSTR.</para>
		/// <para>
		/// The <c>pwszVal</c> member of the <c>PROPVARIANT</c> structure points to a null-terminated, wide-character string that
		/// contains a GUID that identifies the provider of the control-panel extension.
		/// </para>
		/// </summary>
		public static readonly PROPERTYKEY PKEY_AudioEndpoint_ControlPanelPageProvider = new(new Guid(0x1da5d803, 0xd492, 0x4edd, 0x8c, 0x23, 0xe0, 0xc0, 0xff, 0xee, 0x7f, 0x0e), 1);

		/// <summary>
		/// <para>
		/// In Windows 10 Version 1605 and later, the <c>PKEY_AudioEndpoint_Default_VolumeInDb</c> property key configures the default
		/// volume (in dB) for the software volume node. The driver developer should provide the default dB value that they would like
		/// to set.
		/// </para>
		/// <para>
		/// If an audio driver is not implementing hardware volume node for an endpoint, the OS inserts a software volume node to
		/// control volume on that endpoint. There are situations, where the default volume value is too low. This INF key provides the
		/// user a better experience when appropriate gain or attenuation is applied to audio signal.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// IHVs and OEMs can override the default software volume value for an endpoint by setting
		/// PKEY_AudioEndpoint_Default_VolumeInDb on a topology filter using the driver INF file. The value specified by the key is in
		/// dB units.
		/// </para>
		/// <para>This key will be used for both render and capture endpoints.</para>
		/// <para>This key is ignored if the endpoint has implemented a hardware volume node.</para>
		/// <para>
		/// Any value can be set, but the OS will make sure that the value it is within the min and max value settings. For example, if
		/// the specified value is greater than max volume value, OS will set the default value to the max volume value.
		/// </para>
		/// <para>
		/// The data is stored as a 16.16 fixed point value. The upper 16 bits are used for the whole number of the value and the lower
		/// 16 bits are used for the fractional portion of the value.
		/// </para>
		/// </remarks>
		public static readonly PROPERTYKEY PKEY_AudioEndpoint_Default_VolumeInDb = new(new Guid(0x1da5d803, 0xd492, 0x4edd, 0x8c, 0x23, 0xe0, 0xc0, 0xff, 0xee, 0x7f, 0x0e), 9);

		/// <summary>
		/// <para>
		/// The <c>PKEY_AudioEndpoint_Disable_SysFx</c> property specifies whether system effects are enabled in the shared-mode stream
		/// that flows to or from the audio endpoint device.
		/// </para>
		/// <para>
		/// System effects are implemented as audio processing objects (APOs) that can be inserted into an audio stream. APOs are
		/// software modules that perform audio processing functions such as volume control and format conversion. Disabling the system
		/// effects for an endpoint device enables the associated stream to pass through the APOs unmodified.
		/// </para>
		/// <para>
		/// For more information about system effects in Windows Vista, see the white papers titled "Custom Audio Effects in Windows
		/// Vista" and "Reusing Windows Vista Audio System Effects" at the Audio Device Technologies for Windows website.
		/// </para>
		/// <para>
		/// This property applies only to the local-effects and global-effects APOs that were installed by the .inf file that installed
		/// the audio adapter to which the endpoint device is connected. In addition, this property affects only the target endpoint
		/// device—it has no effect on the system effects for any other endpoint devices, even if they connect to the same adapter.
		/// </para>
		/// <para>The <c>vt</c> member of the <c>PROPVARIANT</c> structure is set to <c>VT_UI4</c>.</para>
		/// <para>
		/// The <c>ulVal</c> member of the <c>PROPVARIANT</c> structure is set to <c>ENDPOINT_SYSFX_ENABLED</c> if system effects are
		/// enabled or to <c>ENDPOINT_SYSFX_DISABLED</c> if they are disabled.
		/// </para>
		/// </summary>
		public static readonly PROPERTYKEY PKEY_AudioEndpoint_Disable_SysFx = new(new Guid(0x1da5d803, 0xd492, 0x4edd, 0x8c, 0x23, 0xe0, 0xc0, 0xff, 0xee, 0x7f, 0x0e), 5);

		/// <summary>
		/// <para>
		/// The <c>PKEY_AudioEndpoint_FormFactor</c> property specifies the form factor of the audio endpoint device. The form factor
		/// indicates the physical attributes of the audio endpoint device that the user manipulates.
		/// </para>
		/// <para>The <c>vt</c> member of the <c>PROPVARIANT</c> structure is set to VT_UI4.</para>
		/// <para>
		/// The <c>uintVal</c> member of the <c>PROPVARIANT</c> structure contains an enumeration value that is cast to type UINT. It is
		/// set to one of the following <c>EndpointFormFactor</c> enumeration values:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>RemoteNetworkDevice</term>
		/// </item>
		/// <item>
		/// <term>Speakers</term>
		/// </item>
		/// <item>
		/// <term>LineLevel</term>
		/// </item>
		/// <item>
		/// <term>Headphones</term>
		/// </item>
		/// <item>
		/// <term>Microphone</term>
		/// </item>
		/// <item>
		/// <term>Headset</term>
		/// </item>
		/// <item>
		/// <term>Handset</term>
		/// </item>
		/// <item>
		/// <term>UnknownDigitalPassthrough</term>
		/// </item>
		/// <item>
		/// <term>SPDIF</term>
		/// </item>
		/// <item>
		/// <term>HDMI</term>
		/// </item>
		/// <item>
		/// <term>UnknownFormFactor</term>
		/// </item>
		/// </list>
		/// </summary>
		public static readonly PROPERTYKEY PKEY_AudioEndpoint_FormFactor = new(new Guid(0x1da5d803, 0xd492, 0x4edd, 0x8c, 0x23, 0xe0, 0xc0, 0xff, 0xee, 0x7f, 0x0e), 0);

		/// <summary>
		/// <para>
		/// The <c>PKEY_AudioEndpoint_FullRangeSpeakers</c> property specifies the channel-configuration mask for the full-range
		/// speakers that are connected to the audio endpoint device. The mask indicates the physical configuration of the full-range
		/// speakers and specifies the assignment of channels to those speakers.
		/// </para>
		/// <para>The <c>vt</c> member of the <c>PROPVARIANT</c> structure is set to VT_UI4.</para>
		/// <para>
		/// The <c>uintVal</c> member of the <c>PROPVARIANT</c> structure contains a channel-configuration mask that is cast to type <c>UINT</c>.
		/// </para>
		/// <para>
		/// A full-range speaker is capable of playing sounds over the full range from bass to treble. Typically, larger speakers are
		/// full range but smaller speakers are significantly less capable of playing bass sounds. In Windows Vista, the audio engine
		/// uses this property to manage bass levels in the audio output stream that is played by the audio endpoint device.
		/// </para>
		/// <para>
		/// The channel-configuration mask for this property is in the same format as the channel-configuration mask for the
		/// <c>PKEY_AudioEndpoint_PhysicalSpeakers</c> property. For more information about channel-configuration masks, see the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The description of the KSPROPERTY_AUDIO_CHANNEL_CONFIG property in the Windows DDK documentation.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The white paper titled "Audio Driver Support for Home Theater Speaker Configurations" at the Audio Device Technologies for
		/// Windows website.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The system obtains the channel-configuration mask for the PKEY_AudioEndpoint_FullRangeSpeakers property from the user. The
		/// user enters this information through the Windows multimedia control panel, Mmsys.cpl. For more information about Mmsys.cpl,
		/// see the Windows DDK documentation.
		/// </para>
		/// <para>
		/// The channel-configuration mask for the PKEY_AudioEndpoint_FullRangeSpeakers property of an audio endpoint device is a subset
		/// of the channel-configuration mask for the PKEY_AudioEndpoint_PhysicalSpeakers property of the same device.
		/// </para>
		/// <para>
		/// For example, if an audio endpoint device drives a set of 5.1 surround-sound speakers, then the channel-configuration mask
		/// for the PKEY_AudioEndpoint_PhysicalSpeakers property is KSAUDIO_SPEAKER_5POINT1. This mask indicates the presence of
		/// front-left, front-right, front-center, side-left, and side-right speakers—plus a subwoofer. If the front-left and
		/// front-right speakers are large enough to produce bass sounds but the smaller front-center and side speakers are not, then
		/// the channel-configuration mask for the PKEY_AudioEndpoint_FullRangeSpeakers property is KSAUDIO_SPEAKER_STEREO, which
		/// indicates only the front-left and front-right speakers. Channel-configuration masks KSAUDIO_SPEAKER_5POINT1 and
		/// KSAUDIO_SPEAKER_STEREO are defined in header file Ksmedia.h.
		/// </para>
		/// </summary>
		public static readonly PROPERTYKEY PKEY_AudioEndpoint_FullRangeSpeakers = new(new Guid(0x1da5d803, 0xd492, 0x4edd, 0x8c, 0x23, 0xe0, 0xc0, 0xff, 0xee, 0x7f, 0x0e), 6);

		/// <summary>
		/// <para>
		/// The <c>PKEY_AudioEndpoint_GUID</c> property supplies the DirectSound device identifier that corresponds to the audio
		/// endpoint device. The property value is a GUID that the client can supply as the device identifier to the
		/// <c>DirectSoundCreate</c> or <c>DirectSoundCaptureCreate</c> function in the DirectSound API. This value uniquely identifies
		/// the audio endpoint device across all audio endpoint devices in the system. For more information about DirectSound, see the
		/// DirectX SDK documentation.
		/// </para>
		/// <para>The <c>vt</c> member of the <c>PROPVARIANT</c> structure is set to VT_LPWSTR.</para>
		/// <para>
		/// The <c>pwszVal</c> member of the <c>PROPVARIANT</c> structure points to a null-terminated, wide-character string that
		/// contains a GUID that identifies the audio endpoint device in DirectSound.
		/// </para>
		/// <para>
		/// As explained previously, the MMDevice API supports device roles. Although DirectSound does not directly support device
		/// roles, a DirectSound client can use the PKEY_AudioEndpoint_GUID property to select a DirectSound rendering or capture device
		/// based on its device role.
		/// </para>
		/// <para>
		/// For example, a DirectSound application performs the following steps to create a DirectSound device that corresponds to the
		/// rendering endpoint device that the user has assigned the eMultimedia role to:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// Call the <c>IMMDeviceEnumerator::GetDefaultAudioEndpoint</c> method to get the <c>IMMDevice</c> interface of the rendering
		/// endpoint device that has the eMultimedia role.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Call the <c>IMMDevice::OpenPropertyStore</c> method to obtain the <c>IPropertyStore</c> interface of the eMultimedia device.
		/// For more information about <c>IPropertyStore</c>, see the Windows SDK documentation.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Call the <c>IPropertyStore::GetValue</c> method to obtain the PKEY_AudioEndpoint_GUID property value.</term>
		/// </item>
		/// <item>
		/// <term>Convert the property value from a GUID in string format to a 16-byte GUID structure.</term>
		/// </item>
		/// <item>
		/// <term>Call the <c>DirectSoundCreate</c> function with the GUID to create the device with the eMultimedia role.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Note that the 16-byte GUID generated in step 4 matches the device GUID that identifies the device during DirectSound device
		/// enumeration. The <c>DirectSoundEnumerate</c> function enumerates rendering endpoint devices, and the
		/// <c>DirectSoundCaptureEnumerate</c> function enumerates capture endpoint devices. In either case, the device GUID is the
		/// first parameter passed to the enumeration callback function. For more information about DirectSound enumeration, see the
		/// DirectX SDK documentation.
		/// </para>
		/// <para>For a code example that uses the PKEY_AudioEndpoint_GUID property, see Device Roles for DirectSound Applications.</para>
		/// </summary>
		public static readonly PROPERTYKEY PKEY_AudioEndpoint_GUID = new(new Guid(0x1da5d803, 0xd492, 0x4edd, 0x8c, 0x23, 0xe0, 0xc0, 0xff, 0xee, 0x7f, 0x0e), 4);

		/// <summary>
		/// <para>
		/// The <c>PKEY_AudioEndpoint_JackSubType</c> property contains an output category GUID for an audio endpoint device. The header
		/// file Ksmedia.h defines the GUIDs; each GUID specifies the type of connection. These GUIDs also have associated pin
		/// categories. For example, header file Ksmedia.h defines the GUID <c>KSNODETYPE_DISPLAYPORT_INTERFACE</c> for a display port
		/// that connects with the KS pin defined by the GUID <c>PINNAME_DISPLAYPORT_OUT</c>.
		/// </para>
		/// <para>For more information, see the description of pin category properties in the Windows DDK documentation.</para>
		/// <para>The <c>vt</c> member of the <c>PROPVARIANT</c> structure is set to <c>VT_LPWSTR</c>.</para>
		/// <para>
		/// The <c>pwszVal</c> member of the <c>PROPVARIANT</c> structure points to a null-terminated, wide-character string that
		/// contains a category GUID.
		/// </para>
		/// </summary>
		public static readonly PROPERTYKEY PKEY_AudioEndpoint_JackSubType = new(new Guid(0x1da5d803, 0xd492, 0x4edd, 0x8c, 0x23, 0xe0, 0xc0, 0xff, 0xee, 0x7f, 0x0e), 8);

		/// <summary>
		/// <para>
		/// The <c>PKEY_AudioEndpoint_PhysicalSpeakers</c> property specifies the channel-configuration mask for the audio endpoint
		/// device. The mask indicates the physical configuration of a set of speakers and specifies the assignment of channels to
		/// speakers. For more information about channel-configuration masks, see the following:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>The description of the KSPROPERTY_AUDIO_CHANNEL_CONFIG property in the Windows DDK documentation.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The white paper titled "Audio Driver Support for Home Theater Speaker Configurations" at the Audio Device Technologies for
		/// Windows website.
		/// </term>
		/// </item>
		/// </list>
		/// <para>The <c>vt</c> member of the <c>PROPVARIANT</c> structure is set to VT_UI4.</para>
		/// <para>
		/// The <c>uintVal</c> member of the <c>PROPVARIANT</c> structure contains a channel-configuration mask that is cast to type <c>UINT</c>.
		/// </para>
		/// </summary>
		public static readonly PROPERTYKEY PKEY_AudioEndpoint_PhysicalSpeakers = new(new Guid(0x1da5d803, 0xd492, 0x4edd, 0x8c, 0x23, 0xe0, 0xc0, 0xff, 0xee, 0x7f, 0x0e), 3);

		/// <summary>
		/// <para>
		/// The <c>PKEY_AudioEndpoint_Supports_EventDriven_Mode</c> property indicates whether the endpoint supports the event-driven mode.
		/// </para>
		/// <para>The <c>vt</c> member of the <c>PROPVARIANT</c> structure is set to VT_UI4.</para>
		/// <para>
		/// The <c>uintVal</c> member of the <c>PROPVARIANT</c> structure is a <c>DWORD</c> that indicates if the endpoint supports the
		/// event-driven mode.
		/// </para>
		/// </summary>
		/// <remarks>
		/// This property value is populated by an audio OEM in an .inf file to indicate that the HDAudio hardware supports event driven
		/// mode as per the WHQL requirement.
		/// </remarks>
		public static readonly PROPERTYKEY PKEY_AudioEndpoint_Supports_EventDriven_Mode = new(new Guid(0x1da5d803, 0xd492, 0x4edd, 0x8c, 0x23, 0xe0, 0xc0, 0xff, 0xee, 0x7f, 0x0e), 7);

		/// <summary/>
		public static readonly PROPERTYKEY PKEY_AudioEndpointLogo_IconEffects = new(new Guid(0xf1ab780d, 0x2010, 0x4ed3, 0xa3, 0xa6, 0x8b, 0x87, 0xf0, 0xf0, 0xc4, 0x76), 0);

		/// <summary/>
		public static readonly PROPERTYKEY PKEY_AudioEndpointLogo_IconPath = new(new Guid(0xf1ab780d, 0x2010, 0x4ed3, 0xa3, 0xa6, 0x8b, 0x87, 0xf0, 0xf0, 0xc4, 0x76), 1);

		/// <summary/>
		public static readonly PROPERTYKEY PKEY_AudioEndpointSettings_LaunchContract = new(new Guid(0x14242002, 0x0320, 0x4de4, 0x95, 0x55, 0xa7, 0xd8, 0x2b, 0x73, 0xc2, 0x86), 1);

		/// <summary/>
		public static readonly PROPERTYKEY PKEY_AudioEndpointSettings_MenuText = new(new Guid(0x14242002, 0x0320, 0x4de4, 0x95, 0x55, 0xa7, 0xd8, 0x2b, 0x73, 0xc2, 0x86), 0);

		/// <summary>
		/// <para>
		/// The <c>PKEY_AudioEngine_DeviceFormat</c> property specifies the device format, which is the format that the user has
		/// selected for the stream that flows between the audio engine and the audio endpoint device when the device operates in shared
		/// mode. This format might not be the best default format for an exclusive-mode application to use. Typically, an
		/// exclusive-mode application finds a suitable device format by making some number of calls to the
		/// <c>IAudioClient::IsFormatSupported</c> method. For more information, see Device Formats.
		/// </para>
		/// <para>The <c>vt</c> member of the <c>PROPVARIANT</c> structure is set to VT_BLOB.</para>
		/// <para>
		/// The <c>blob</c> member of the <c>PROPVARIANT</c> structure is a structure of type <c>BLOB</c> that contains two members.
		/// Member <c>blob.cbSize</c> is a <c>DWORD</c> that specifies the number of bytes in the format description. Member
		/// <c>blob.pBlobData</c> points to a <c>WAVEFORMATEX</c> structure that contains the format description. For more information
		/// about <c>BLOB</c>, see the Windows SDK documentation. For more information about <c>WAVEFORMATEX</c>, see the Windows DDK documentation.
		/// </para>
		/// </summary>
		public static readonly PROPERTYKEY PKEY_AudioEngine_DeviceFormat = new(new Guid(0xf19f064d, 0x82c, 0x4e27, 0xbc, 0x73, 0x68, 0x82, 0xa1, 0xbb, 0x8e, 0x4c), 0);

		/// <summary>
		/// <para>
		/// The PKEY_AudioEngine_OEMFormat property specifies the default format of the device that is used for rendering or capturing a
		/// stream. The values are populated by the OEM in an .inf file.
		/// </para>
		/// <para>The <c>vt</c> member of the <c>PROPVARIANT</c> structure is set to VT_BLOB.</para>
		/// <para>
		/// The <c>blob</c> member of the <c>PROPVARIANT</c> structure is a structure of type <c>BLOB</c> that contains two members.
		/// Member <c>blob.cbSize</c> is a <c>DWORD</c> that specifies the number of bytes in the format description. Member
		/// <c>blob.pBlobData</c> points to a <c>WAVEFORMATEX</c> structure that contains the format description. For more information
		/// about BLOB, see the Windows SDK documentation. For more information about <c>WAVEFORMATEX</c>, see the Windows DDK documentation.
		/// </para>
		/// </summary>
		public static readonly PROPERTYKEY PKEY_AudioEngine_OEMFormat = new(new Guid(0xe4870e26, 0x3cc5, 0x4cd2, 0xba, 0x46, 0xca, 0xa, 0x9a, 0x70, 0xed, 0x4), 3);
	}
}