using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.WinMm;

namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from Windows Core Audio Api.</summary>
public static partial class CoreAudio
{
	/// <summary>Undocumented</summary>
	public const uint AMBISONICS_PARAM_VERSION_1 = 1;

	public const uint WM_APP_GRAPHNOTIFY = 0x8002;
	public const uint WM_APP_SESSION_DUCKED = 0x8000;
	public const uint WM_APP_SESSION_UNDUCKED = 0x8001;
	public const uint WM_APP_SESSION_VOLUME_CHANGED = 0x8003;

	/// <summary>Undocumented</summary>
	[PInvokeData("audioclient.h")]
	public enum AMBISONICS_CHANNEL_ORDERING
	{
		/// <summary>Undocumented</summary>
		AMBISONICS_CHANNEL_ORDERING_ACN
	}

	/// <summary>Undocumented</summary>
	[PInvokeData("audioclient.h")]
	public enum AMBISONICS_NORMALIZATION
	{
		/// <summary>Undocumented</summary>
		AMBISONICS_NORMALIZATION_SN3D,

		/// <summary>Undocumented</summary>
		AMBISONICS_NORMALIZATION_N3D = AMBISONICS_NORMALIZATION_SN3D + 1
	}

	/// <summary>Undocumented</summary>
	[PInvokeData("audioclient.h")]
	public enum AMBISONICS_TYPE
	{
		/// <summary>Undocumented</summary>
		AMBISONICS_TYPE_FULL3D
	}

	/// <summary>The <c>_AUDCLNT_BUFFERFLAGS</c> enumeration defines flags that indicate the status of an audio endpoint buffer.</summary>
	/// <remarks>
	/// The IAudioCaptureClient::GetBuffer and IAudioRenderClient::ReleaseBuffer methods use the constants defined in the
	/// <c>_AUDCLNT_BUFFERFLAGS</c> enumeration.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/ne-audioclient-_audclnt_bufferflags typedef enum _AUDCLNT_BUFFERFLAGS {
	// AUDCLNT_BUFFERFLAGS_DATA_DISCONTINUITY, AUDCLNT_BUFFERFLAGS_SILENT, AUDCLNT_BUFFERFLAGS_TIMESTAMP_ERROR } ;
	[PInvokeData("audioclient.h", MSDNShortId = "ac4ec901-b1e2-4c4e-b9fc-1808d5338d15")]
	[Flags]
	public enum AUDCLNT_BUFFERFLAGS
	{
		/// <summary>
		/// The data in the packet is not correlated with the previous packet's device position; this is possibly due to a stream state
		/// transition or timing glitch.
		/// </summary>
		AUDCLNT_BUFFERFLAGS_DATA_DISCONTINUITY = 0x01,

		/// <summary>
		/// Treat all of the data in the packet as silence and ignore the actual data values. For more information about the use of this
		/// flag, see Rendering a Stream and Capturing a Stream.
		/// </summary>
		AUDCLNT_BUFFERFLAGS_SILENT = 0x02,

		/// <summary>
		/// The time at which the device's stream position was recorded is uncertain. Thus, the client might be unable to accurately set the
		/// time stamp for the current data packet.
		/// </summary>
		AUDCLNT_BUFFERFLAGS_TIMESTAMP_ERROR = 0x04,
	}

	/// <summary>Defines values that describe the characteristics of an audio stream.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/ne-audioclient-audclnt_streamoptions typedef enum AUDCLNT_STREAMOPTIONS
	// { AUDCLNT_STREAMOPTIONS_NONE, AUDCLNT_STREAMOPTIONS_RAW, AUDCLNT_STREAMOPTIONS_MATCH_FORMAT, AUDCLNT_STREAMOPTIONS_AMBISONICS } ;
	[PInvokeData("audioclient.h", MSDNShortId = "C9A51FB2-46F5-4F20-B9F2-63EC53CAB3D7")]
	[Flags]
	public enum AUDCLNT_STREAMOPTIONS
	{
		/// <summary>No stream options.</summary>
		AUDCLNT_STREAMOPTIONS_NONE = 0x00,

		/// <summary>
		/// The audio stream is a 'raw' stream that bypasses all signal processing except for endpoint specific, always-on processing in the
		/// Audio Processing Object (APO), driver, and hardware.
		/// </summary>
		AUDCLNT_STREAMOPTIONS_RAW = 0x01,

		/// <summary>
		/// The audio client is requesting that the audio engine match the format proposed by the client. The audio enginewill match this
		/// format only if the format is supported by the audio driver and associated APOs. Supported in Windows 10 and later.
		/// </summary>
		AUDCLNT_STREAMOPTIONS_MATCH_FORMAT = 0x02,

		/// <summary/>
		AUDCLNT_STREAMOPTIONS_AMBISONIC = 0x04,
	}

	//[ComImport, Guid("28724C91-DF35-4856-9F76-D6A26413F3DF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	//public interface IAudioAmbisonicsControl
	//{
	//	HRESULT SetData([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] AMBISONICS_PARAMS[] pAmbisonicsParams, uint cbAmbisonicsParams);
	//	HRESULT SetHeadTracking([MarshalAs(UnmanagedType.Bool)] bool bEnableHeadTracking);
	//	HRESULT GetHeadTracking([MarshalAs(UnmanagedType.Bool)] out bool pbEnableHeadTracking);
	//	HRESULT SetRotation(float X, float Y, float Z, float W);
	//}

	/// <summary>Specifies audio ducking options. Use values from this enumeration when calling IAudioClientDuckingControl::SetDuckingOptionsForCurrentStream</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioclient/ne-audioclient-audio_ducking_options typedef enum
	// AUDIO_DUCKING_OPTIONS { AUDIO_DUCKING_OPTIONS_DEFAULT, AUDIO_DUCKING_OPTIONS_DO_NOT_DUCK_OTHER_STREAMS } ;
	[PInvokeData("audioclient.h", MSDNShortId = "NE:audioclient.AUDIO_DUCKING_OPTIONS")]
	public enum AUDIO_DUCKING_OPTIONS
	{
		/// <summary>The associated audio stream should use the default audio ducking behavior.</summary>
		AUDIO_DUCKING_OPTIONS_DEFAULT,

		/// <summary>The associated audio stream should not cause other streams to be ducked.</summary>
		AUDIO_DUCKING_OPTIONS_DO_NOT_DUCK_OTHER_STREAMS,
	}

	/// <summary>Specifies the state of an audio effect.</summary>
	/// <remarks>
	/// <para>
	/// Get the state of an audio effect by calling IAudioEffectsManager::GetAudioEffects and checking the state field of the returned
	/// AUDIO_EFFECT structures.
	/// </para>
	/// <para>Set the state of an audio effect by calling IAudioEffectsManager::SetAudioEffectState.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioclient/ne-audioclient-audio_effect_state typedef enum AUDIO_EFFECT_STATE {
	// AUDIO_EFFECT_STATE_OFF, AUDIO_EFFECT_STATE_ON } ;
	[PInvokeData("audioclient.h", MSDNShortId = "NE:audioclient.AUDIO_EFFECT_STATE")]
	public enum AUDIO_EFFECT_STATE
	{
		/// <summary>The audio effect is off.</summary>
		AUDIO_EFFECT_STATE_OFF,

		/// <summary>The audio effect is on.</summary>
		AUDIO_EFFECT_STATE_ON,
	}

	/// <summary>Undocumented</summary>
	[PInvokeData("audioclient.h")]
	[ComImport, Guid("f4ae25b5-aaa3-437d-b6b3-dbbe2d0e9549"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAcousticEchoCancellationControl
	{
		/// <summary>Undocumented</summary>
		[PreserveSig]
		HRESULT SetEchoCancellationRenderEndpoint([MarshalAs(UnmanagedType.LPWStr)] string endpointId);
	}

	[PInvokeData("audioclient.h")]
	[ComImport, Guid("28724C91-DF35-4856-9F76-D6A26413F3DF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioAmbisonicsControl
	{
		[PreserveSig]
		HRESULT SetData([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] AMBISONICS_PARAMS[] pAmbisonicsParams,
			uint cbAmbisonicsParams);

		[PreserveSig]
		HRESULT SetHeadTracking([MarshalAs(UnmanagedType.Bool)] bool bEnableHeadTracking);

		[PreserveSig]
		HRESULT GetHeadTracking([MarshalAs(UnmanagedType.Bool)] out bool pbEnableHeadTracking);

		[PreserveSig]
		HRESULT SetRotation(float X, float Y, float Z, float W);
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioCaptureClient</c> interface enables a client to read input data from a capture endpoint buffer. The client obtains a
	/// reference to the <c>IAudioCaptureClient</c> interface on a stream object by calling the IAudioClient::GetService method with
	/// parameter riid set to REFIID IID_IAudioCaptureClient.
	/// </para>
	/// <para>
	/// The methods in this interface manage the movement of data packets that contain capture data. The length of a data packet is expressed
	/// as the number of audio frames in the packet. The size of an audio frame is specified by the <c>nBlockAlign</c> member of the W
	/// <c>AVEFORMATEX (or WAVEFORMATEXTENSIBLE)</c> structure that the client obtains by calling the IAudioClient::GetMixFormat method. The
	/// size in bytes of an audio frame equals the number of channels in the stream multiplied by the sample size per channel. For example,
	/// the frame size is four bytes for a stereo (2-channel) stream with 16-bit samples. A packet always contains an integral number of
	/// audio frames.
	/// </para>
	/// <para>
	/// When releasing an <c>IAudioCaptureClient</c> interface instance, the client must call the <c>Release</c> method of the instance from
	/// the same thread as the call to <c>IAudioClient::GetService</c> that created the object.
	/// </para>
	/// <para>For a code example that uses the <c>IAudioCaptureClient</c> interface, see Capturing a Stream.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nn-audioclient-iaudiocaptureclient
	[PInvokeData("audioclient.h", MSDNShortId = "c0fa6841-56bf-421e-9949-c6a037cf9fd4")]
	[ComImport, Guid("C8ADBD64-E71E-48a0-A4DE-185C395CD317"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioCaptureClient
	{
		/// <summary>Retrieves a pointer to the next available packet of data in the capture endpoint buffer.</summary>
		/// <param name="ppData">
		/// Pointer to a pointer variable into which the method writes the starting address of the next data packet that is available for the
		/// client to read.
		/// </param>
		/// <param name="pNumFramesToRead">
		/// Pointer to a <c>UINT32</c> variable into which the method writes the frame count (the number of audio frames available in the
		/// data packet). The client should either read the entire data packet or none of it.
		/// </param>
		/// <param name="pdwFlags">
		/// <para>
		/// Pointer to a <c>DWORD</c> variable into which the method writes the buffer-status flags. The method writes either 0 or the
		/// bitwise-OR combination of one or more of the following _AUDCLNT_BUFFERFLAGS enumeration values:
		/// </para>
		/// <para>AUDCLNT_BUFFERFLAGS_SILENT</para>
		/// <para>AUDCLNT_BUFFERFLAGS_DATA_DISCONTINUITY</para>
		/// <para>AUDCLNT_BUFFERFLAGS_TIMESTAMP_ERROR</para>
		/// <para>
		/// <c>Note</c> The AUDCLNT_BUFFERFLAGS_DATA_DISCONTINUITY flag is not supported in Windows Vista.In Windows 7 and later OS releases,
		/// this flag can be used for glitch detection. To start the capture stream, the client application must call IAudioClient::Start
		/// followed by calls to <c>GetBuffer</c> in a loop to read data packets until all of the available packets in the endpoint buffer
		/// have been read. <c>GetBuffer</c> sets the AUDCLNT_BUFFERFLAGS_DATA_DISCONTINUITY flag to indicate a glitch in the buffer pointed
		/// by ppData.
		/// </para>
		/// </param>
		/// <param name="pu64DevicePosition">
		/// Pointer to a <c>UINT64</c> variable into which the method writes the device position of the first audio frame in the data packet.
		/// The device position is expressed as the number of audio frames from the start of the stream. This parameter can be <c>NULL</c> if
		/// the client does not require the device position. For more information, see Remarks.
		/// </param>
		/// <param name="pu64QPCPosition">
		/// Pointer to a <c>UINT64</c> variable into which the method writes the value of the performance counter at the time that the audio
		/// endpoint device recorded the device position of the first audio frame in the data packet. The method converts the counter value
		/// to 100-nanosecond units before writing it to *pu64QPCPosition. This parameter can be <c>NULL</c> if the client does not require
		/// the performance counter value. For more information, see Remarks.
		/// </param>
		/// <returns>
		/// <para>Possible return codes include, but are not limited to, the values shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The call succeeded and *pNumFramesToRead is nonzero, indicating that a packet is ready to be read.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_S_BUFFER_EMPTY</term>
		/// <term>The call succeeded and *pNumFramesToRead is 0, indicating that no capture data is available to be read.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_BUFFER_ERROR</term>
		/// <term>Windows 7 and later: GetBuffer failed to retrieve a data buffer and *ppData points to NULL. For more information, see Remarks.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_OUT_OF_ORDER</term>
		/// <term>A previous IAudioCaptureClient::GetBuffer call is still in effect.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
		/// <term>
		/// The audio endpoint device has been unplugged, or the audio hardware or associated hardware resources have been reconfigured,
		/// disabled, removed, or otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_BUFFER_OPERATION_PENDING</term>
		/// <term>Buffer cannot be accessed because a stream reset is in progress.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_SERVICE_NOT_RUNNING</term>
		/// <term>The Windows audio service is not running.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>Parameter ppData, pNumFramesToRead, or pdwFlags is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method retrieves the next data packet from the capture endpoint buffer. At a particular time, the buffer might contain zero,
		/// one, or more packets that are ready to read. Typically, a buffer-processing thread that reads data from a capture endpoint buffer
		/// reads all of the available packets each time the thread executes.
		/// </para>
		/// <para>
		/// During processing of an audio capture stream, the client application alternately calls <c>GetBuffer</c> and the
		/// IAudioCaptureClient::ReleaseBuffer method. The client can read no more than a single data packet with each <c>GetBuffer</c> call.
		/// Following each <c>GetBuffer</c> call, the client must call <c>ReleaseBuffer</c> to release the packet before the client can call
		/// <c>GetBuffer</c> again to get the next packet.
		/// </para>
		/// <para>
		/// Two or more consecutive calls either to <c>GetBuffer</c> or to <c>ReleaseBuffer</c> are not permitted and will fail with error
		/// code AUDCLNT_E_OUT_OF_ORDER. To ensure the correct ordering of calls, a <c>GetBuffer</c> call and its corresponding
		/// <c>ReleaseBuffer</c> call must occur in the same thread.
		/// </para>
		/// <para>
		/// During each <c>GetBuffer</c> call, the caller must either obtain the entire packet or none of it. Before reading the packet, the
		/// caller can check the packet size (available through the pNumFramesToRead parameter) to make sure that it has enough room to store
		/// the entire packet.
		/// </para>
		/// <para>
		/// During each <c>ReleaseBuffer</c> call, the caller reports the number of audio frames that it read from the buffer. This number
		/// must be either the (nonzero) packet size or 0. If the number is 0, then the next <c>GetBuffer</c> call will present the caller
		/// with the same packet as in the previous <c>GetBuffer</c> call.
		/// </para>
		/// <para>
		/// Following each <c>GetBuffer</c> call, the data in the packet remains valid until the next <c>ReleaseBuffer</c> call releases the buffer.
		/// </para>
		/// <para>
		/// The client must call <c>ReleaseBuffer</c> after a <c>GetBuffer</c> call that successfully obtains a packet of any size other than
		/// 0. The client has the option of calling or not calling <c>ReleaseBuffer</c> to release a packet of size 0.
		/// </para>
		/// <para>
		/// The method outputs the device position and performance counter through the pu64DevicePosition and pu64QPCPosition output
		/// parameters. These values provide a time stamp for the first audio frame in the data packet. Through the pdwFlags output
		/// parameter, the method indicates whether the reported device position is valid.
		/// </para>
		/// <para>
		/// The device position that the method writes to *pu64DevicePosition is the stream-relative position of the audio frame that is
		/// currently playing through the speakers (for a rendering stream) or being recorded through the microphone (for a capture stream).
		/// The position is expressed as the number of frames from the start of the stream. The size of a frame in an audio stream is
		/// specified by the <c>nBlockAlign</c> member of the <c>WAVEFORMATEX</c> (or <c>WAVEFORMATEXTENSIBLE</c>) structure that specifies
		/// the stream format. The size, in bytes, of an audio frame equals the number of channels in the stream multiplied by the sample
		/// size per channel. For example, for a stereo (2-channel) stream with 16-bit samples, the frame size is four bytes.
		/// </para>
		/// <para>
		/// The performance counter value that <c>GetBuffer</c> writes to *pu64QPCPosition is not the raw counter value obtained from the
		/// <c>QueryPerformanceCounter</c> function. If t is the raw counter value, and if f is the frequency obtained from the
		/// <c>QueryPerformanceFrequency</c> function, <c>GetBuffer</c> calculates the performance counter value as follows:
		/// </para>
		/// <para>*pu64QPCPosition = 10,000,000t/f</para>
		/// <para>
		/// The result is expressed in 100-nanosecond units. For more information about <c>QueryPerformanceCounter</c> and
		/// <c>QueryPerformanceFrequency</c>, see the Windows SDK documentation.
		/// </para>
		/// <para>
		/// If no new packet is currently available, the method sets *pNumFramesToRead = 0 and returns status code AUDCLNT_S_BUFFER_EMPTY. In
		/// this case, the method does not write to the variables that are pointed to by the ppData, pu64DevicePosition, and pu64QPCPosition parameters.
		/// </para>
		/// <para>
		/// Clients should avoid excessive delays between the <c>GetBuffer</c> call that acquires a packet and the <c>ReleaseBuffer</c> call
		/// that releases the packet. The implementation of the audio engine assumes that the <c>GetBuffer</c> call and the corresponding
		/// <c>ReleaseBuffer</c> call occur within the same buffer-processing period. Clients that delay releasing a packet for more than one
		/// period risk losing sample data.
		/// </para>
		/// <para>
		/// In Windows 7 and later, <c>GetBuffer</c> can return the <c>AUDCLNT_E_BUFFER_ERROR</c> error code for an audio client that uses
		/// the endpoint buffer in the exclusive mode. This error indicates that the data buffer was not retrieved because a data packet
		/// wasn't available (*ppData received <c>NULL</c>).
		/// </para>
		/// <para>
		/// If <c>GetBuffer</c> returns <c>AUDCLNT_E_BUFFER_ERROR</c>, the thread consuming the audio samples must wait for the next
		/// processing pass. The client might benefit from keeping a count of the failed <c>GetBuffer</c> calls. If <c>GetBuffer</c> returns
		/// this error repeatedly, the client can start a new processing loop after shutting down the current client by calling
		/// IAudioClient::Stop, IAudioClient::Reset, and releasing the audio client.
		/// </para>
		/// <para>Examples</para>
		/// <para>For a code example that calls the <c>GetBuffer</c> method, see Capturing a Stream.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudiocaptureclient-getbuffer HRESULT GetBuffer(
		// BYTE **ppData, UINT32 *pNumFramesToRead, DWORD *pdwFlags, UINT64 *pu64DevicePosition, UINT64 *pu64QPCPosition );
		[PreserveSig]
		HRESULT GetBuffer(out IntPtr ppData, out uint pNumFramesToRead, out AUDCLNT_BUFFERFLAGS pdwFlags, out ulong pu64DevicePosition, out ulong pu64QPCPosition);

		/// <summary>The <c>ReleaseBuffer</c> method releases the buffer.</summary>
		/// <param name="NumFramesRead">
		/// The number of audio frames that the client read from the capture buffer. This parameter must be either equal to the number of
		/// frames in the previously acquired data packet or 0.
		/// </param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. If it fails, possible return codes include, but are not limited to, the values shown in
		/// the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>AUDCLNT_E_INVALID_SIZE</term>
		/// <term>The NumFramesRead parameter is set to a value other than the data packet size or 0.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_OUT_OF_ORDER</term>
		/// <term>This call was not preceded by a corresponding IAudioCaptureClient::GetBuffer call.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
		/// <term>
		/// The audio endpoint device has been unplugged, or the audio hardware or associated hardware resources have been reconfigured,
		/// disabled, removed, or otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_SERVICE_NOT_RUNNING</term>
		/// <term>The Windows audio service is not running.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The client should call this method when it finishes reading a data packet that it obtained previously by calling the
		/// IAudioCaptureClient::GetBuffer method.
		/// </para>
		/// <para>
		/// The data in the packet that the client obtained from a GetBuffer call is guaranteed to remain valid until the client calls
		/// <c>ReleaseBuffer</c> to release the packet.
		/// </para>
		/// <para>
		/// Between each GetBuffer call and its corresponding <c>ReleaseBuffer</c> call, the client must either read the entire data packet
		/// or none of it. If the client reads the entire packet following the <c>GetBuffer</c> call, then it should call
		/// <c>ReleaseBuffer</c> with NumFramesRead set to the total number of frames in the data packet. In this case, the next call to
		/// <c>GetBuffer</c> will produce a new data packet. If the client reads none of the data from the packet following the call to
		/// <c>GetBuffer</c>, then it should call <c>ReleaseBuffer</c> with NumFramesRead set to 0. In this case, the next <c>GetBuffer</c>
		/// call will produce the same data packet as in the previous <c>GetBuffer</c> call.
		/// </para>
		/// <para>
		/// If the client calls <c>ReleaseBuffer</c> with NumFramesRead set to any value other than the packet size or 0, then the call fails
		/// and returns error code AUDCLNT_E_INVALID_SIZE.
		/// </para>
		/// <para>
		/// Clients should avoid excessive delays between the GetBuffer call that acquires a buffer and the <c>ReleaseBuffer</c> call that
		/// releases the buffer. The implementation of the audio engine assumes that the <c>GetBuffer</c> call and the corresponding
		/// <c>ReleaseBuffer</c> call occur within the same buffer-processing period. Clients that delay releasing a buffer for more than one
		/// period risk losing sample data.
		/// </para>
		/// <para>For a code example that calls the <c>ReleaseBuffer</c> method, see Capturing a Stream.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudiocaptureclient-releasebuffer HRESULT
		// ReleaseBuffer( UINT32 NumFramesRead );
		[PreserveSig]
		HRESULT ReleaseBuffer([In] uint NumFramesRead);

		/// <summary>
		/// The <c>GetNextPacketSize</c> method retrieves the number of frames in the next data packet in the capture endpoint buffer.
		/// </summary>
		/// <param name="pNumFramesInNextPacket">
		/// Pointer to a <c>UINT32</c> variable into which the method writes the frame count (the number of audio frames in the next capture packet).
		/// </param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. If it fails, possible return codes include, but are not limited to, the values shown in
		/// the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
		/// <term>
		/// The audio endpoint device has been unplugged, or the audio hardware or associated hardware resources have been reconfigured,
		/// disabled, removed, or otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_SERVICE_NOT_RUNNING</term>
		/// <term>The Windows audio service is not running.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>Parameter pNumFramesInNextPacket is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Use this method only with shared-mode streams. It does not work with exclusive-mode streams.</para>
		/// <para>
		/// Before calling the IAudioCaptureClient::GetBuffer method to retrieve the next data packet, the client can call
		/// <c>GetNextPacketSize</c> to retrieve the number of audio frames in the next packet. The count reported by
		/// <c>GetNextPacketSize</c> matches the count retrieved in the <c>GetBuffer</c> call (through the pNumFramesToRead output
		/// parameter) that follows the <c>GetNextPacketSize</c> call.
		/// </para>
		/// <para>A packet always consists of an integral number of audio frames.</para>
		/// <para>
		/// <c>GetNextPacketSize</c> must be called in the same thread as the GetBuffer and IAudioCaptureClient::ReleaseBuffer method calls
		/// that get and release the packets in the capture endpoint buffer.
		/// </para>
		/// <para>For a code example that uses the <c>GetNextPacketSize</c> method, see Capturing a Stream.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudiocaptureclient-getnextpacketsize HRESULT
		// GetNextPacketSize( UINT32 *pNumFramesInNextPacket );
		[PreserveSig]
		HRESULT GetNextPacketSize(out uint pNumFramesInNextPacket);
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioClient</c> interface enables a client to create and initialize an audio stream between an audio application and the
	/// audio engine (for a shared-mode stream) or the hardware buffer of an audio endpoint device (for an exclusive-mode stream). A client
	/// obtains a reference to an <c>IAudioClient</c> interface for an audio endpoint device by following these steps:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// By using one of the techniques described in IMMDevice Interface, obtain a reference to the <c>IMMDevice</c> interface for an audio
	/// endpoint device.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Call the IMMDevice::Activate method with parameter iid set to REFIID IID_IAudioClient.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The application thread that uses this interface must be initialized for COM. For more information about COM initialization, see the
	/// description of the <c>CoInitializeEx</c> function in the Windows SDK documentation.
	/// </para>
	/// <para>For code examples that use the <c>IAudioClient</c> interface, see the following topics:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Rendering a Stream</term>
	/// </item>
	/// <item>
	/// <term>Capturing a Stream</term>
	/// </item>
	/// <item>
	/// <term>Exclusive-Mode Streams</term>
	/// </item>
	/// </list>
	/// </summary>
	/// <remarks>
	/// <c>Note</c> In Windows 8, the first use of <c>IAudioClient</c> to access the audio device should be on the STA thread. Calls from an
	/// MTA thread may result in undefined behavior.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nn-audioclient-iaudioclient
	[PInvokeData("audioclient.h", MSDNShortId = "5088a3f1-5001-4ed9-a495-9e91df613ab0")]
	[ComImport, Guid("1CB9AD4C-DBFA-4c32-B178-C2F568A703B2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioClient
	{
		/// <summary>The <c>Initialize</c> method initializes the audio stream.</summary>
		/// <param name="ShareMode">
		/// <para>
		/// The sharing mode for the connection. Through this parameter, the client tells the audio engine whether it wants to share the
		/// audio endpoint device with other clients. The client should set this parameter to one of the following AUDCLNT_SHAREMODE
		/// enumeration values:
		/// </para>
		/// <para>AUDCLNT_SHAREMODE_EXCLUSIVE</para>
		/// <para>AUDCLNT_SHAREMODE_SHARED</para>
		/// </param>
		/// <param name="StreamFlags">
		/// Flags to control creation of the stream. The client should set this parameter to 0 or to the bitwise OR of one or more of the
		/// AUDCLNT_STREAMFLAGS_XXX Constants or the AUDCLNT_SESSIONFLAGS_XXX Constants.
		/// </param>
		/// <param name="hnsBufferDuration">
		/// The buffer capacity as a time value. This parameter is of type <c>REFERENCE_TIME</c> and is expressed in 100-nanosecond units.
		/// This parameter contains the buffer size that the caller requests for the buffer that the audio application will share with the
		/// audio engine (in shared mode) or with the endpoint device (in exclusive mode). If the call succeeds, the method allocates a
		/// buffer that is a least this large. For more information about <c>REFERENCE_TIME</c>, see the Windows SDK documentation. For more
		/// information about buffering requirements, see Remarks.
		/// </param>
		/// <param name="hnsPeriodicity">
		/// The device period. This parameter can be nonzero only in exclusive mode. In shared mode, always set this parameter to 0. In
		/// exclusive mode, this parameter specifies the requested scheduling period for successive buffer accesses by the audio endpoint
		/// device. If the requested device period lies outside the range that is set by the device's minimum period and the system's maximum
		/// period, then the method clamps the period to that range. If this parameter is 0, the method sets the device period to its default
		/// value. To obtain the default device period, call the IAudioClient::GetDevicePeriod method. If the
		/// AUDCLNT_STREAMFLAGS_EVENTCALLBACK stream flag is set and AUDCLNT_SHAREMODE_EXCLUSIVE is set as the ShareMode, then hnsPeriodicity
		/// must be nonzero and equal to hnsBufferDuration.
		/// </param>
		/// <param name="pFormat">
		/// Pointer to a format descriptor. This parameter must point to a valid format descriptor of type <c>WAVEFORMATEX</c> (or
		/// <c>WAVEFORMATEXTENSIBLE</c>). For more information, see Remarks.
		/// </param>
		/// <param name="AudioSessionGuid">
		/// Pointer to a session GUID. This parameter points to a GUID value that identifies the audio session that the stream belongs to. If
		/// the GUID identifies a session that has been previously opened, the method adds the stream to that session. If the GUID does not
		/// identify an existing session, the method opens a new session and adds the stream to that session. The stream remains a member of
		/// the same session for its lifetime. Setting this parameter to <c>NULL</c> is equivalent to passing a pointer to a GUID_NULL value.
		/// </param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. If it fails, possible return codes include, but are not limited to, the values shown in
		/// the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>AUDCLNT_E_ALREADY_INITIALIZED</term>
		/// <term>The IAudioClient object is already initialized.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_WRONG_ENDPOINT_TYPE</term>
		/// <term>The AUDCLNT_STREAMFLAGS_LOOPBACK flag is set but the endpoint device is a capture device, not a rendering device.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED</term>
		/// <term>
		/// The requested buffer size is not aligned. This code can be returned for a render or a capture device if the caller specified
		/// AUDCLNT_SHAREMODE_EXCLUSIVE and the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flags. The caller must call Initialize again with the
		/// aligned buffer size. For more information, see Remarks.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_BUFFER_SIZE_ERROR</term>
		/// <term>
		/// Indicates that the buffer duration value requested by an exclusive-mode client is out of range. The requested duration value for
		/// pull mode must not be greater than 500 milliseconds; for push mode the duration value must not be greater than 2 seconds.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_CPUUSAGE_EXCEEDED</term>
		/// <term>
		/// Indicates that the process-pass duration exceeded the maximum CPU usage. The audio engine keeps track of CPU usage by maintaining
		/// the number of times the process-pass duration exceeds the maximum CPU usage. The maximum CPU usage is calculated as a percent of
		/// the engine's periodicity. The percentage value is the system's CPU throttle value (within the range of 10% and 90%). If this
		/// value is not found, then the default value of 40% is used to calculate the maximum CPU usage.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
		/// <term>
		/// The audio endpoint device has been unplugged, or the audio hardware or associated hardware resources have been reconfigured,
		/// disabled, removed, or otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_IN_USE</term>
		/// <term>
		/// The endpoint device is already in use. Either the device is being used in exclusive mode, or the device is being used in shared
		/// mode and the caller asked to use the device in exclusive mode.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_ENDPOINT_CREATE_FAILED</term>
		/// <term>
		/// The method failed to create the audio endpoint for the render or the capture device. This can occur if the audio endpoint device
		/// has been unplugged, or the audio hardware or associated hardware resources have been reconfigured, disabled, removed, or
		/// otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_INVALID_DEVICE_PERIOD</term>
		/// <term>Indicates that the device period requested by an exclusive-mode client is greater than 500 milliseconds.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_UNSUPPORTED_FORMAT</term>
		/// <term>The audio engine (shared mode) or audio endpoint device (exclusive mode) does not support the specified format.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_EXCLUSIVE_MODE_NOT_ALLOWED</term>
		/// <term>
		/// The caller is requesting exclusive-mode use of the endpoint device, but the user has disabled exclusive-mode use of the device.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_BUFDURATION_PERIOD_NOT_EQUAL</term>
		/// <term>The AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag is set but parameters hnsBufferDuration and hnsPeriodicity are not equal.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_SERVICE_NOT_RUNNING</term>
		/// <term>The Windows audio service is not running.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>Parameter pFormat is NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>
		/// Parameter pFormat points to an invalid format description; or the AUDCLNT_STREAMFLAGS_LOOPBACK flag is set but ShareMode is not
		/// equal to AUDCLNT_SHAREMODE_SHARED; or the AUDCLNT_STREAMFLAGS_CROSSPROCESS flag is set but ShareMode is equal to
		/// AUDCLNT_SHAREMODE_EXCLUSIVE. A prior call to SetClientProperties was made with an invalid category for audio/render streams.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Out of memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// After activating an IAudioClient interface on an audio endpoint device, the client must successfully call <c>Initialize</c> once
		/// and only once to initialize the audio stream between the client and the device. The client can either connect directly to the
		/// audio hardware (exclusive mode) or indirectly through the audio engine (shared mode). In the <c>Initialize</c> call, the client
		/// specifies the audio data format, the buffer size, and audio session for the stream.
		/// </para>
		/// <para>
		/// <c>Note</c> In Windows 8, the first use of IAudioClient to access the audio device should be on the STA thread. Calls from an MTA
		/// thread may result in undefined behavior.
		/// </para>
		/// <para>
		/// An attempt to create a shared-mode stream can succeed only if the audio device is already operating in shared mode or the device
		/// is currently unused. An attempt to create a shared-mode stream fails if the device is already operating in exclusive mode.
		/// </para>
		/// <para>
		/// If a stream is initialized to be event driven and in shared mode, ShareMode is set to AUDCLNT_SHAREMODE_SHARED and one of the
		/// stream flags that are set includes AUDCLNT_STREAMFLAGS_EVENTCALLBACK. For such a stream, the associated application must also
		/// obtain a handle by making a call to IAudioClient::SetEventHandle. When it is time to retire the stream, the audio engine can then
		/// use the handle to release the stream objects. Failure to call <c>IAudioClient::SetEventHandle</c> before releasing the stream
		/// objects can cause a delay of several seconds (a time-out period) while the audio engine waits for an available handle. After the
		/// time-out period expires, the audio engine then releases the stream objects.
		/// </para>
		/// <para>
		/// Whether an attempt to create an exclusive-mode stream succeeds depends on several factors, including the availability of the
		/// device and the user-controlled settings that govern exclusive-mode operation of the device. For more information, see
		/// Exclusive-Mode Streams.
		/// </para>
		/// <para>
		/// An <c>IAudioClient</c> object supports exactly one connection to the audio engine or audio hardware. This connection lasts for
		/// the lifetime of the <c>IAudioClient</c> object.
		/// </para>
		/// <para>The client should call the following methods only after calling <c>Initialize</c>:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IAudioClient::GetBufferSize</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::GetCurrentPadding</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::GetService</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::GetStreamLatency</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::Reset</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::SetEventHandle</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::Start</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::Stop</term>
		/// </item>
		/// </list>
		/// <para>The following methods do not require that <c>Initialize</c> be called first:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IAudioClient::GetDevicePeriod</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::GetMixFormat</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::IsFormatSupported</term>
		/// </item>
		/// </list>
		/// <para>These methods can be called any time after activating the <c>IAudioClient</c> interface.</para>
		/// <para>
		/// Before calling <c>Initialize</c> to set up a shared-mode or exclusive-mode connection, the client can call the
		/// IAudioClient::IsFormatSupported method to discover whether the audio engine or audio endpoint device supports a particular format
		/// in that mode. Before opening a shared-mode connection, the client can obtain the audio engine's mix format by calling the
		/// IAudioClient::GetMixFormat method.
		/// </para>
		/// <para>
		/// The endpoint buffer that is shared between the client and audio engine must be large enough to prevent glitches from occurring in
		/// the audio stream between processing passes by the client and audio engine. For a rendering endpoint, the client thread
		/// periodically writes data to the buffer, and the audio engine thread periodically reads data from the buffer. For a capture
		/// endpoint, the engine thread periodically writes to the buffer, and the client thread periodically reads from the buffer. In
		/// either case, if the periods of the client thread and engine thread are not equal, the buffer must be large enough to accommodate
		/// the longer of the two periods without allowing glitches to occur.
		/// </para>
		/// <para>
		/// The client specifies a buffer size through the hnsBufferDuration parameter. The client is responsible for requesting a buffer
		/// that is large enough to ensure that glitches cannot occur between the periodic processing passes that it performs on the buffer.
		/// Similarly, the <c>Initialize</c> method ensures that the buffer is never smaller than the minimum buffer size needed to ensure
		/// that glitches do not occur between the periodic processing passes that the engine thread performs on the buffer. If the client
		/// requests a buffer size that is smaller than the audio engine's minimum required buffer size, the method sets the buffer size to
		/// this minimum buffer size rather than to the buffer size requested by the client.
		/// </para>
		/// <para>
		/// If the client requests a buffer size (through the hnsBufferDuration parameter) that is not an integral number of audio frames,
		/// the method rounds up the requested buffer size to the next integral number of frames.
		/// </para>
		/// <para>
		/// Following the <c>Initialize</c> call, the client should call the IAudioClient::GetBufferSize method to get the precise size of
		/// the endpoint buffer. During each processing pass, the client will need the actual buffer size to calculate how much data to
		/// transfer to or from the buffer. The client calls the IAudioClient::GetCurrentPadding method to determine how much of the data in
		/// the buffer is currently available for processing.
		/// </para>
		/// <para>
		/// To achieve the minimum stream latency between the client application and audio endpoint device, the client thread should run at
		/// the same period as the audio engine thread. The period of the engine thread is fixed and cannot be controlled by the client.
		/// Making the client's period smaller than the engine's period unnecessarily increases the client thread's load on the processor
		/// without improving latency or decreasing the buffer size. To determine the period of the engine thread, the client can call the
		/// IAudioClient::GetDevicePeriod method. To set the buffer to the minimum size required by the engine thread, the client should call
		/// <c>Initialize</c> with the hnsBufferDuration parameter set to 0. Following the <c>Initialize</c> call, the client can get the
		/// size of the resulting buffer by calling <c>IAudioClient::GetBufferSize</c>.
		/// </para>
		/// <para>
		/// A client has the option of requesting a buffer size that is larger than what is strictly necessary to make timing glitches rare
		/// or nonexistent. Increasing the buffer size does not necessarily increase the stream latency. For a rendering stream, the latency
		/// through the buffer is determined solely by the separation between the client's write pointer and the engine's read pointer. For a
		/// capture stream, the latency through the buffer is determined solely by the separation between the engine's write pointer and the
		/// client's read pointer.
		/// </para>
		/// <para>
		/// The loopback flag (AUDCLNT_STREAMFLAGS_LOOPBACK) enables audio loopback. A client can enable audio loopback only on a rendering
		/// endpoint with a shared-mode stream. Audio loopback is provided primarily to support acoustic echo cancellation (AEC).
		/// </para>
		/// <para>
		/// An AEC client requires both a rendering endpoint and the ability to capture the output stream from the audio engine. The engine's
		/// output stream is the global mix that the audio device plays through the speakers. If audio loopback is enabled, a client can open
		/// a capture buffer for the global audio mix by calling the IAudioClient::GetService method to obtain an IAudioCaptureClient
		/// interface on the rendering stream object. If audio loopback is not enabled, then an attempt to open a capture buffer on a
		/// rendering stream will fail. The loopback data in the capture buffer is in the device format, which the client can obtain by
		/// querying the device's PKEY_AudioEngine_DeviceFormat property.
		/// </para>
		/// <para>
		/// On Windows versions prior to Windows 10, a pull-mode capture client will not receive any events when a stream is initialized with
		/// event-driven buffering (AUDCLNT_STREAMFLAGS_EVENTCALLBACK) and is loopback-enabled (AUDCLNT_STREAMFLAGS_LOOPBACK). If the stream
		/// is opened with this configuration, the <c>Initialize</c> call succeeds, but relevant events are not raised to notify the capture
		/// client each time a buffer becomes ready for processing. To work around this, initialize a render stream in event-driven mode.
		/// Each time the client receives an event for the render stream, it must signal the capture client to run the capture thread that
		/// reads the next set of samples from the capture endpoint buffer. As of Windows 10 the relevant event handles are now set for
		/// loopback-enabled streams that are active.
		/// </para>
		/// <para>
		/// Note that all streams must be opened in share mode because exclusive-mode streams cannot operate in loopback mode. For more
		/// information about audio loopback, see Loopback Recording.
		/// </para>
		/// <para>
		/// The AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag indicates that processing of the audio buffer by the client will be event driven.
		/// WASAPI supports event-driven buffering to enable low-latency processing of both shared-mode and exclusive-mode streams.
		/// </para>
		/// <para>
		/// The initial release of Windows Vista supports event-driven buffering (that is, the use of the AUDCLNT_STREAMFLAGS_EVENTCALLBACK
		/// flag) for rendering streams only.
		/// </para>
		/// <para>
		/// In the initial release of Windows Vista, for capture streams, the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag is supported only in
		/// shared mode. Setting this flag has no effect for exclusive-mode capture streams. That is, although the application specifies this
		/// flag in exclusive mode through the <c>Initialize</c> call, the application will not receive any events that are usually required
		/// to capture the audio stream. In the Windows Vista Service Pack 1 release, this flag is functional in shared-mode and exclusive
		/// mode; an application can set this flag to enable event-buffering for capture streams. For more information about capturing an
		/// audio stream, see Capturing a Stream.
		/// </para>
		/// <para>
		/// To enable event-driven buffering, the client must provide an event handle to the system. Following the <c>Initialize</c> call and
		/// before calling the IAudioClient::Start method to start the stream, the client must call the IAudioClient::SetEventHandle method
		/// to set the event handle. While the stream is running, the system periodically signals the event to indicate to the client that
		/// audio data is available for processing. Between processing passes, the client thread waits on the event handle by calling a
		/// synchronization function such as <c>WaitForSingleObject</c>. For more information about synchronization functions, see the
		/// Windows SDK documentation.
		/// </para>
		/// <para>
		/// For a shared-mode stream that uses event-driven buffering, the caller must set both hnsPeriodicity and hnsBufferDuration to
		/// 0. The <c>Initialize</c> method determines how large a buffer to allocate based on the scheduling period of the audio engine.
		/// Although the client's buffer processing thread is event driven, the basic buffer management process, as described previously, is
		/// unaltered. Each time the thread awakens, it should call IAudioClient::GetCurrentPadding to determine how much data to write to a
		/// rendering buffer or read from a capture buffer. In contrast to the two buffers that the <c>Initialize</c> method allocates for an
		/// exclusive-mode stream that uses event-driven buffering, a shared-mode stream requires a single buffer.
		/// </para>
		/// <para>
		/// For an exclusive-mode stream that uses event-driven buffering, the caller must specify nonzero values for hnsPeriodicity and
		/// hnsBufferDuration, and the values of these two parameters must be equal. The <c>Initialize</c> method allocates two buffers for
		/// the stream. Each buffer is equal in duration to the value of the hnsBufferDuration parameter. Following the <c>Initialize</c>
		/// call for a rendering stream, the caller should fill the first of the two buffers before starting the stream. For a capture
		/// stream, the buffers are initially empty, and the caller should assume that each buffer remains empty until the event for that
		/// buffer is signaled. While the stream is running, the system alternately sends one buffer or the other to the client—this form of
		/// double buffering is referred to as "ping-ponging". Each time the client receives a buffer from the system (which the system
		/// indicates by signaling the event), the client must process the entire buffer. For example, if the client requests a packet size
		/// from the IAudioRenderClient::GetBuffer method that does not match the buffer size, the method fails. Calls to the
		/// <c>IAudioClient::GetCurrentPadding</c> method are unnecessary because the packet size must always equal the buffer size. In
		/// contrast to the buffering modes discussed previously, the latency for an event-driven, exclusive-mode stream depends directly on
		/// the buffer size.
		/// </para>
		/// <para>
		/// As explained in Audio Sessions, the default behavior for a session that contains rendering streams is that its volume and mute
		/// settings persist across system restarts. The AUDCLNT_STREAMFLAGS_NOPERSIST flag overrides the default behavior and makes the
		/// settings nonpersistent. This flag has no effect on sessions that contain capture streams—the settings for those sessions are
		/// never persistent. In addition, the settings for a session that contains a loopback stream (a stream that is initialized with the
		/// AUDCLNT_STREAMFLAGS_LOOPBACK flag) are not persistent.
		/// </para>
		/// <para>
		/// Only a session that connects to a rendering endpoint device can have persistent volume and mute settings. The first stream to be
		/// added to the session determines whether the session's settings are persistent. Thus, if the AUDCLNT_STREAMFLAGS_NOPERSIST or
		/// AUDCLNT_STREAMFLAGS_LOOPBACK flag is set during initialization of the first stream, the session's settings are not persistent.
		/// Otherwise, they are persistent. Their persistence is unaffected by additional streams that might be subsequently added or removed
		/// during the lifetime of the session object.
		/// </para>
		/// <para>
		/// After a call to <c>Initialize</c> has successfully initialized an <c>IAudioClient</c> interface instance, a subsequent
		/// <c>Initialize</c> call to initialize the same interface instance will fail and return error code E_ALREADY_INITIALIZED.
		/// </para>
		/// <para>
		/// If the initial call to <c>Initialize</c> fails, subsequent <c>Initialize</c> calls might fail and return error code
		/// E_ALREADY_INITIALIZED, even though the interface has not been initialized. If this occurs, release the <c>IAudioClient</c>
		/// interface and obtain a new <c>IAudioClient</c> interface from the MMDevice API before calling <c>Initialize</c> again.
		/// </para>
		/// <para>For code examples that call the <c>Initialize</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// <item>
		/// <term>Exclusive-Mode Streams</term>
		/// </item>
		/// </list>
		/// <para>
		/// Starting with Windows 7, <c>Initialize</c> can return AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED for a render or a capture device. This
		/// indicates that the buffer size, specified by the caller in the hnsBufferDuration parameter, is not aligned. This error code is
		/// returned only if the caller requested an exclusive-mode stream (AUDCLNT_SHAREMODE_EXCLUSIVE) and event-driven buffering (AUDCLNT_STREAMFLAGS_EVENTCALLBACK).
		/// </para>
		/// <para>
		/// If <c>Initialize</c> returns AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED, the caller must call <c>Initialize</c> again and specify the
		/// aligned buffer size. Use the following steps:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Call IAudioClient::GetBufferSize and receive the next-highest-aligned buffer size (in frames).</term>
		/// </item>
		/// <item>
		/// <term>Call <c>IAudioClient::Release</c> to release the audio client used in the previous call that returned AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Calculate the aligned buffer size in 100-nansecond units (hns). The buffer size is . In this formula, is the buffer size
		/// retrieved by GetBufferSize.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Call the IMMDevice::Activate method with parameter iid set to REFIID IID_IAudioClient to create a new audio client.</term>
		/// </item>
		/// <item>
		/// <term>Call <c>Initialize</c> again on the created audio client and specify the new buffer size and periodicity.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Starting with Windows 10, hardware-offloaded audio streams must be event driven. This means that if you call
		/// IAudioClient2::SetClientProperties and set the bIsOffload parameter of the AudioClientProperties to TRUE, you must specify the
		/// <c>AUDCLNT_STREAMFLAGS_EVENTCALLBACK</c> flag in the StreamFlags parameter to <c>IAudioClient::Initialize</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example code shows how to respond to the <c>AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED</c> return code.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-initialize HRESULT Initialize(
		// AUDCLNT_SHAREMODE ShareMode, DWORD StreamFlags, REFERENCE_TIME hnsBufferDuration, REFERENCE_TIME hnsPeriodicity, const
		// WAVEFORMATEX *pFormat, LPCGUID AudioSessionGuid );
		[PreserveSig]
		HRESULT Initialize([In] AUDCLNT_SHAREMODE ShareMode, AUDCLNT_STREAMFLAGS StreamFlags, long hnsBufferDuration, long hnsPeriodicity, [In] IntPtr pFormat, [In, Optional] in Guid AudioSessionGuid);

		/// <summary>The <c>GetBufferSize</c> method retrieves the size (maximum capacity) of the endpoint buffer.</summary>
		/// <returns>Pointer to a <c>UINT32</c> variable into which the method writes the number of audio frames that the buffer can hold.</returns>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// This method retrieves the length of the endpoint buffer shared between the client application and the audio engine. The length is
		/// expressed as the number of audio frames the buffer can hold. The size in bytes of an audio frame is calculated as the number of
		/// channels in the stream multiplied by the sample size per channel. For example, the frame size is four bytes for a stereo
		/// (2-channel) stream with 16-bit samples.
		/// </para>
		/// <para>
		/// The IAudioClient::Initialize method allocates the buffer. The client specifies the buffer length in the hnsBufferDuration
		/// parameter value that it passes to the <c>Initialize</c> method. For rendering clients, the buffer length determines the maximum
		/// amount of rendering data that the application can write to the endpoint buffer during a single processing pass. For capture
		/// clients, the buffer length determines the maximum amount of capture data that the audio engine can read from the endpoint buffer
		/// during a single processing pass. The client should always call <c>GetBufferSize</c> after calling <c>Initialize</c> to determine
		/// the actual size of the allocated buffer, which might differ from the requested size.
		/// </para>
		/// <para>
		/// Rendering clients can use this value to calculate the largest rendering buffer size that can be requested from
		/// IAudioRenderClient::GetBuffer during each processing pass.
		/// </para>
		/// <para>For code examples that call the <c>GetBufferSize</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getbuffersize HRESULT GetBufferSize(
		// UINT32 *pNumBufferFrames );
		uint GetBufferSize();

		/// <summary>
		/// The <c>GetStreamLatency</c> method retrieves the maximum latency for the current stream and can be called any time after the
		/// stream has been initialized.
		/// </summary>
		/// <returns>
		/// Pointer to a REFERENCE_TIME variable into which the method writes a time value representing the latency. The time is expressed in
		/// 100-nanosecond units. For more information about <c>REFERENCE_TIME</c>, see the Windows SDK documentation.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// This method retrieves the maximum latency for the current stream. The value will not change for the lifetime of the IAudioClient object.
		/// </para>
		/// <para>
		/// Rendering clients can use this latency value to compute the minimum amount of data that they can write during any single
		/// processing pass. To write less than this minimum is to risk introducing glitches into the audio stream. For more information, see IAudioRenderClient::GetBuffer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getstreamlatency HRESULT
		// GetStreamLatency( REFERENCE_TIME *phnsLatency );
		long GetStreamLatency();

		/// <summary>The <c>GetCurrentPadding</c> method retrieves the number of frames of padding in the endpoint buffer.</summary>
		/// <returns>
		/// Pointer to a <c>UINT32</c> variable into which the method writes the frame count (the number of audio frames of padding in the buffer).
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// This method retrieves a padding value that indicates the amount of valid, unread data that the endpoint buffer currently
		/// contains. A rendering application can use the padding value to determine how much new data it can safely write to the endpoint
		/// buffer without overwriting previously written data that the audio engine has not yet read from the buffer. A capture application
		/// can use the padding value to determine how much new data it can safely read from the endpoint buffer without reading invalid data
		/// from a region of the buffer to which the audio engine has not yet written valid data.
		/// </para>
		/// <para>
		/// The padding value is expressed as a number of audio frames. The size of an audio frame is specified by the <c>nBlockAlign</c>
		/// member of the WAVEFORMATEX (or WAVEFORMATEXTENSIBLE) structure that the client passed to the IAudioClient::Initialize method. The
		/// size in bytes of an audio frame equals the number of channels in the stream multiplied by the sample size per channel. For
		/// example, the frame size is four bytes for a stereo (2-channel) stream with 16-bit samples.
		/// </para>
		/// <para>
		/// For a shared-mode rendering stream, the padding value reported by <c>GetCurrentPadding</c> specifies the number of audio frames
		/// that are queued up to play in the endpoint buffer. Before writing to the endpoint buffer, the client can calculate the amount of
		/// available space in the buffer by subtracting the padding value from the buffer length. To ensure that a subsequent call to the
		/// IAudioRenderClient::GetBuffer method succeeds, the client should request a packet length that does not exceed the available space
		/// in the buffer. To obtain the buffer length, call the IAudioClient::GetBufferSize method.
		/// </para>
		/// <para>
		/// For a shared-mode capture stream, the padding value reported by <c>GetCurrentPadding</c> specifies the number of frames of
		/// capture data that are available in the next packet in the endpoint buffer. At a particular moment, zero, one, or more packets of
		/// capture data might be ready for the client to read from the buffer. If no packets are currently available, the method reports a
		/// padding value of 0. Following the <c>GetCurrentPadding</c> call, an IAudioCaptureClient::GetBuffer method call will retrieve a
		/// packet whose length exactly equals the padding value reported by <c>GetCurrentPadding</c>. Each call to GetBuffer retrieves a
		/// whole packet. A packet always contains an integral number of audio frames.
		/// </para>
		/// <para>
		/// For a shared-mode capture stream, calling <c>GetCurrentPadding</c> is equivalent to calling the
		/// IAudioCaptureClient::GetNextPacketSize method. That is, the padding value reported by <c>GetCurrentPadding</c> is equal to the
		/// packet length reported by <c>GetNextPacketSize</c>.
		/// </para>
		/// <para>
		/// For an exclusive-mode rendering or capture stream that was initialized with the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag, the
		/// client typically has no use for the padding value reported by <c>GetCurrentPadding</c>. Instead, the client accesses an entire
		/// buffer during each processing pass. Each time a buffer becomes available for processing, the audio engine notifies the client by
		/// signaling the client's event handle. For more information about this flag, see IAudioClient::Initialize.
		/// </para>
		/// <para>
		/// For an exclusive-mode rendering or capture stream that was not initialized with the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag, the
		/// client can use the padding value obtained from <c>GetCurrentPadding</c> in a way that is similar to that described previously for
		/// a shared-mode stream. The details are as follows.
		/// </para>
		/// <para>
		/// First, for an exclusive-mode rendering stream, the padding value specifies the number of audio frames that are queued up to play
		/// in the endpoint buffer. As before, the client can calculate the amount of available space in the buffer by subtracting the
		/// padding value from the buffer length.
		/// </para>
		/// <para>
		/// Second, for an exclusive-mode capture stream, the padding value reported by <c>GetCurrentPadding</c> specifies the current length
		/// of the next packet. However, this padding value is a snapshot of the packet length, which might increase before the client calls
		/// the IAudioCaptureClient::GetBuffer method. Thus, the length of the packet retrieved by <c>GetBuffer</c> is at least as large as,
		/// but might be larger than, the padding value reported by the <c>GetCurrentPadding</c> call that preceded the <c>GetBuffer</c>
		/// call. In contrast, for a shared-mode capture stream, the length of the packet obtained from <c>GetBuffer</c> always equals the
		/// padding value reported by the preceding <c>GetCurrentPadding</c> call.
		/// </para>
		/// <para>For a code example that calls the <c>GetCurrentPadding</c> method, see Rendering a Stream.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getcurrentpadding HRESULT
		// GetCurrentPadding( UINT32 *pNumPaddingFrames );
		uint GetCurrentPadding();

		/// <summary>The <c>IsFormatSupported</c> method indicates whether the audio endpoint device supports a particular stream format.</summary>
		/// <param name="ShareMode">
		/// <para>
		/// The sharing mode for the stream format. Through this parameter, the client indicates whether it wants to use the specified format
		/// in exclusive mode or shared mode. The client should set this parameter to one of the following AUDCLNT_SHAREMODE enumeration values:
		/// </para>
		/// <para>AUDCLNT_SHAREMODE_EXCLUSIVE</para>
		/// <para>AUDCLNT_SHAREMODE_SHARED</para>
		/// </param>
		/// <param name="pFormat">
		/// Pointer to the specified stream format. This parameter points to a caller-allocated format descriptor of type <c>WAVEFORMATEX</c>
		/// or <c>WAVEFORMATEXTENSIBLE</c>. The client writes a format description to this structure before calling this method. For
		/// information about <c>WAVEFORMATEX</c> and <c>WAVEFORMATEXTENSIBLE</c>, see the Windows DDK documentation.
		/// </param>
		/// <param name="ppClosestMatch">
		/// Pointer to a pointer variable into which the method writes the address of a <c>WAVEFORMATEX</c> or <c>WAVEFORMATEXTENSIBLE</c>
		/// structure. This structure specifies the supported format that is closest to the format that the client specified through the
		/// pFormat parameter. For shared mode (that is, if the ShareMode parameter is AUDCLNT_SHAREMODE_SHARED), set ppClosestMatch to point
		/// to a valid, non- <c>NULL</c> pointer variable. For exclusive mode, set ppClosestMatch to <c>NULL</c>. The method allocates the
		/// storage for the structure. The caller is responsible for freeing the storage, when it is no longer needed, by calling the
		/// <c>CoTaskMemFree</c> function. If the <c>IsFormatSupported</c> call fails and ppClosestMatch is non- <c>NULL</c>, the method sets
		/// *ppClosestMatch to <c>NULL</c>. For information about <c>CoTaskMemFree</c>, see the Windows SDK documentation.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Succeeded and the audio endpoint device supports the specified stream format.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>Succeeded with a closest match to the specified format.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_UNSUPPORTED_FORMAT</term>
		/// <term>Succeeded but the specified format is not supported in exclusive mode.</term>
		/// </item>
		/// </list>
		/// <para>If the operation fails, possible return codes include, but are not limited to, the values shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>Parameter pFormat is NULL, or ppClosestMatch is NULL and ShareMode is AUDCLNT_SHAREMODE_SHARED.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>Parameter ShareMode is a value other than AUDCLNT_SHAREMODE_SHARED or AUDCLNT_SHAREMODE_EXCLUSIVE.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
		/// <term>
		/// The audio endpoint device has been unplugged, or the audio hardware or associated hardware resources have been reconfigured,
		/// disabled, removed, or otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_SERVICE_NOT_RUNNING</term>
		/// <term>The Windows audio service is not running.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method provides a way for a client to determine, before calling IAudioClient::Initialize, whether the audio engine supports
		/// a particular stream format.
		/// </para>
		/// <para>
		/// For exclusive mode, <c>IsFormatSupported</c> returns S_OK if the audio endpoint device supports the caller-specified format, or
		/// it returns AUDCLNT_E_UNSUPPORTED_FORMAT if the device does not support the format. The ppClosestMatch parameter can be
		/// <c>NULL</c>. If it is not <c>NULL</c>, the method writes <c>NULL</c> to *ppClosestMatch.
		/// </para>
		/// <para>
		/// For shared mode, if the audio engine supports the caller-specified format, <c>IsFormatSupported</c> sets <c>*ppClosestMatch</c>
		/// to <c>NULL</c> and returns S_OK. If the audio engine does not support the caller-specified format but does support a similar
		/// format, the method retrieves the similar format through the ppClosestMatch parameter and returns S_FALSE. If the audio engine
		/// does not support the caller-specified format or any similar format, the method sets
		/// *ppClosestMatch to <c>NULL</c> and returns AUDCLNT_E_UNSUPPORTED_FORMAT.
		/// </para>
		/// <para>
		/// In shared mode, the audio engine always supports the mix format, which the client can obtain by calling the
		/// IAudioClient::GetMixFormat method. In addition, the audio engine might support similar formats that have the same sample rate and
		/// number of channels as the mix format but differ in the representation of audio sample values. The audio engine represents sample
		/// values internally as floating-point numbers, but if the caller-specified format represents sample values as integers, the audio
		/// engine typically can convert between the integer sample values and its internal floating-point representation.
		/// </para>
		/// <para>
		/// The audio engine might be able to support an even wider range of shared-mode formats if the installation package for the audio
		/// device includes a local effects (LFX) audio processing object (APO) that can handle format conversions. An LFX APO is a software
		/// module that performs device-specific processing of an audio stream. The audio graph builder in the Windows audio service inserts
		/// the LFX APO into the stream between each client and the audio engine. When a client calls the <c>IsFormatSupported</c> method and
		/// the method determines that an LFX APO is installed for use with the device, the method directs the query to the LFX APO, which
		/// indicates whether it supports the caller-specified format.
		/// </para>
		/// <para>
		/// For example, a particular LFX APO might accept a 6-channel surround sound stream from a client and convert the stream to a stereo
		/// format that can be played through headphones. Typically, an LFX APO supports only client formats with sample rates that match the
		/// sample rate of the mix format.
		/// </para>
		/// <para>
		/// For more information about APOs, see the white papers titled "Custom Audio Effects in Windows Vista" and "Reusing the Windows
		/// Vista Audio System Effects" at the Audio Device Technologies for Windows website. For more information about the
		/// <c>IsFormatSupported</c> method, see Device Formats.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-isformatsupported HRESULT
		// IsFormatSupported( AUDCLNT_SHAREMODE ShareMode, const WAVEFORMATEX *pFormat, WAVEFORMATEX **ppClosestMatch );
		[PreserveSig]
		HRESULT IsFormatSupported([In] AUDCLNT_SHAREMODE ShareMode, [In] IntPtr pFormat, out SafeCoTaskMemHandle ppClosestMatch);

		/// <summary>
		/// The <c>GetMixFormat</c> method retrieves the stream format that the audio engine uses for its internal processing of shared-mode streams.
		/// </summary>
		/// <param name="ppDeviceFormat">
		/// Pointer to a pointer variable into which the method writes the address of the mix format. This parameter must be a valid, non-
		/// <c>NULL</c> pointer to a pointer variable. The method writes the address of a <c>WAVEFORMATEX</c> (or
		/// <c>WAVEFORMATEXTENSIBLE</c>) structure to this variable. The method allocates the storage for the structure. The caller is
		/// responsible for freeing the storage, when it is no longer needed, by calling the <c>CoTaskMemFree</c> function. If the
		/// <c>GetMixFormat</c> call fails, *ppDeviceFormat is <c>NULL</c>. For information about <c>WAVEFORMATEX</c>,
		/// <c>WAVEFORMATEXTENSIBLE</c>, and <c>CoTaskMemFree</c>, see the Windows SDK documentation.
		/// </param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. If it fails, possible return codes include, but are not limited to, the values shown in
		/// the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
		/// <term>
		/// The audio endpoint device has been unplugged, or the audio hardware or associated hardware resources have been reconfigured,
		/// disabled, removed, or otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_SERVICE_NOT_RUNNING</term>
		/// <term>The Windows audio service is not running.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>Parameter ppDeviceFormat is NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Out of memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The client can call this method before calling the IAudioClient::Initialize method. When creating a shared-mode stream for an
		/// audio endpoint device, the <c>Initialize</c> method always accepts the stream format obtained from a <c>GetMixFormat</c> call on
		/// the same device.
		/// </para>
		/// <para>
		/// The mix format is the format that the audio engine uses internally for digital processing of shared-mode streams. This format is
		/// not necessarily a format that the audio endpoint device supports. Thus, the caller might not succeed in creating an
		/// exclusive-mode stream with a format obtained by calling <c>GetMixFormat</c>.
		/// </para>
		/// <para>
		/// For example, to facilitate digital audio processing, the audio engine might use a mix format that represents samples as
		/// floating-point values. If the device supports only integer PCM samples, then the engine converts the samples to or from integer
		/// PCM values at the connection between the device and the engine. However, to avoid resampling, the engine might use a mix format
		/// with a sample rate that the device supports.
		/// </para>
		/// <para>
		/// To determine whether the <c>Initialize</c> method can create a shared-mode or exclusive-mode stream with a particular format,
		/// call the IAudioClient::IsFormatSupported method.
		/// </para>
		/// <para>
		/// By itself, a <c>WAVEFORMATEX</c> structure cannot specify the mapping of channels to speaker positions. In addition, although
		/// <c>WAVEFORMATEX</c> specifies the size of the container for each audio sample, it cannot specify the number of bits of precision
		/// in a sample (for example, 20 bits of precision in a 24-bit container). However, the <c>WAVEFORMATEXTENSIBLE</c> structure can
		/// specify both the mapping of channels to speakers and the number of bits of precision in each sample. For this reason, the
		/// <c>GetMixFormat</c> method retrieves a format descriptor that is in the form of a <c>WAVEFORMATEXTENSIBLE</c> structure instead
		/// of a standalone <c>WAVEFORMATEX</c> structure. Through the ppDeviceFormat parameter, the method outputs a pointer to the
		/// <c>WAVEFORMATEX</c> structure that is embedded at the start of this <c>WAVEFORMATEXTENSIBLE</c> structure. For more information
		/// about <c>WAVEFORMATEX</c> and <c>WAVEFORMATEXTENSIBLE</c>, see the Windows DDK documentation.
		/// </para>
		/// <para>
		/// For more information about the <c>GetMixFormat</c> method, see Device Formats. For code examples that call <c>GetMixFormat</c>,
		/// see the following topics:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getmixformat HRESULT GetMixFormat(
		// WAVEFORMATEX **ppDeviceFormat );
		[PreserveSig]
		HRESULT GetMixFormat(out SafeCoTaskMemHandle ppDeviceFormat);

		/// <summary>
		/// The <c>GetDevicePeriod</c> method retrieves the length of the periodic interval separating successive processing passes by the
		/// audio engine on the data in the endpoint buffer.
		/// </summary>
		/// <param name="phnsDefaultDevicePeriod">
		/// Pointer to a REFERENCE_TIME variable into which the method writes a time value specifying the default interval between periodic
		/// processing passes by the audio engine. The time is expressed in 100-nanosecond units. For information about
		/// <c>REFERENCE_TIME</c>, see the Windows SDK documentation.
		/// </param>
		/// <param name="phnsMinimumDevicePeriod">
		/// Pointer to a REFERENCE_TIME variable into which the method writes a time value specifying the minimum interval between periodic
		/// processing passes by the audio endpoint device. The time is expressed in 100-nanosecond units.
		/// </param>
		/// <remarks>
		/// <para>The client can call this method before calling the IAudioClient::Initialize method.</para>
		/// <para>
		/// The phnsDefaultDevicePeriod parameter specifies the default scheduling period for a shared-mode stream. The
		/// phnsMinimumDevicePeriod parameter specifies the minimum scheduling period for an exclusive-mode stream.
		/// </para>
		/// <para>
		/// At least one of the two parameters, phnsDefaultDevicePeriod and phnsMinimumDevicePeriod, must be non- <c>NULL</c> or the method
		/// returns immediately with error code E_POINTER. If both parameters are non- <c>NULL</c>, then the method outputs both the default
		/// and minimum periods.
		/// </para>
		/// <para>
		/// For a shared-mode stream, the audio engine periodically processes the data in the endpoint buffer, which the engine shares with
		/// the client application. The engine schedules itself to perform these processing passes at regular intervals.
		/// </para>
		/// <para>
		/// The period between processing passes by the audio engine is fixed for a particular audio endpoint device and represents the
		/// smallest processing quantum for the audio engine. This period plus the stream latency between the buffer and endpoint device
		/// represents the minimum possible latency that an audio application can achieve.
		/// </para>
		/// <para>
		/// The client has the option of scheduling its periodic processing thread to run at the same time interval as the audio engine. In
		/// this way, the client can achieve the smallest possible latency for a shared-mode stream. However, in an application for which
		/// latency is less important, the client can reduce the process-switching overhead on the CPU by scheduling its processing passes to
		/// occur less frequently. In this case, the endpoint buffer must be proportionally larger to compensate for the longer period
		/// between processing passes.
		/// </para>
		/// <para>
		/// The client determines the buffer size during its call to the IAudioClient::Initialize method. For a shared-mode stream, if the
		/// client passes this method an hnsBufferDuration parameter value of 0, the method assumes that the periods for the client and audio
		/// engine are guaranteed to be equal, and the method will allocate a buffer small enough to achieve the minimum possible latency.
		/// (In fact, any hnsBufferDuration value between 0 and the sum of the audio engine's period and device latency will have the same
		/// result.) Similarly, for an exclusive-mode stream, if the client sets hnsBufferDuration to 0, the method assumes that the period
		/// of the client is set to the minimum period of the audio endpoint device, and the method will allocate a buffer small enough to
		/// achieve the minimum possible latency.
		/// </para>
		/// <para>
		/// If the client chooses to run its periodic processing thread less often, at the cost of increased latency, it can do so as long as
		/// it creates an endpoint buffer during the IAudioClient::Initialize call that is sufficiently large.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getdeviceperiod HRESULT
		// GetDevicePeriod( REFERENCE_TIME *phnsDefaultDevicePeriod, REFERENCE_TIME *phnsMinimumDevicePeriod );
		void GetDevicePeriod([Out, Optional] out long phnsDefaultDevicePeriod, out long phnsMinimumDevicePeriod);

		/// <summary>The <c>Start</c> method starts the audio stream.</summary>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// <c>Start</c> is a control method that the client calls to start the audio stream. Starting the stream causes the IAudioClient
		/// object to begin streaming data between the endpoint buffer and the audio engine. It also causes the stream's audio clock to
		/// resume counting from its current position.
		/// </para>
		/// <para>
		/// The first time this method is called following initialization of the stream, the IAudioClient object's stream position counter
		/// begins at 0. Otherwise, the clock resumes from its position at the time that the stream was last stopped. Resetting the stream
		/// forces the stream position back to 0.
		/// </para>
		/// <para>
		/// To avoid start-up glitches with rendering streams, clients should not call <c>Start</c> until the audio engine has been initially
		/// loaded with data by calling the IAudioRenderClient::GetBuffer and IAudioRenderClient::ReleaseBuffer methods on the rendering interface.
		/// </para>
		/// <para>For code examples that call the <c>Start</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-start HRESULT Start();
		void Start();

		/// <summary>The <c>Stop</c> method stops the audio stream.</summary>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// <c>Stop</c> is a control method that stops a running audio stream. This method stops data from streaming through the client's
		/// connection with the audio engine. Stopping the stream freezes the stream's audio clock at its current stream position. A
		/// subsequent call to IAudioClient::Start causes the stream to resume running from that position. If necessary, the client can call
		/// the IAudioClient::Reset method to reset the position while the stream is stopped.
		/// </para>
		/// <para>For code examples that call the <c>Stop</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-stop HRESULT Stop();
		void Stop();

		/// <summary>The <c>Reset</c> method resets the audio stream.</summary>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// <c>Reset</c> is a control method that the client calls to reset a stopped audio stream. Resetting the stream flushes all pending
		/// data and resets the audio clock stream position to 0. This method fails if it is called on a stream that is not stopped.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-reset HRESULT Reset();
		void Reset();

		/// <summary>
		/// The <c>SetEventHandle</c> method sets the event handle that the system signals when an audio buffer is ready to be processed by
		/// the client.
		/// </summary>
		/// <param name="eventHandle">The event handle.</param>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// During stream initialization, the client can, as an option, enable event-driven buffering. To do so, the client calls the
		/// IAudioClient::Initialize method with the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag set. After enabling event-driven buffering, and
		/// before calling the IAudioClient::Start method to start the stream, the client must call <c>SetEventHandle</c> to register the
		/// event handle that the system will signal each time a buffer becomes ready to be processed by the client.
		/// </para>
		/// <para>The event handle should be in the nonsignaled state at the time that the client calls the Start method.</para>
		/// <para>
		/// If the client has enabled event-driven buffering of a stream, but the client calls the Start method for that stream without first
		/// calling <c>SetEventHandle</c>, the <c>Start</c> call will fail and return an error code.
		/// </para>
		/// <para>
		/// If the client does not enable event-driven buffering of a stream but attempts to set an event handle for the stream by calling
		/// <c>SetEventHandle</c>, the call will fail and return an error code.
		/// </para>
		/// <para>For a code example that calls the <c>SetEventHandle</c> method, see Exclusive-Mode Streams.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-seteventhandle HRESULT SetEventHandle(
		// HANDLE eventHandle );
		void SetEventHandle(HEVENT eventHandle);

		/// <summary>The <c>GetService</c> method accesses additional services from the audio client object.</summary>
		/// <param name="riid">
		/// <para>The interface ID for the requested service. The client should set this parameter to one of the following REFIID values:</para>
		/// <para>IID_IAudioCaptureClient</para>
		/// <para>IID_IAudioClock</para>
		/// <para>IID_IAudioRenderClient</para>
		/// <para>IID_IAudioSessionControl</para>
		/// <para>IID_IAudioStreamVolume</para>
		/// <para>IID_IChannelAudioVolume</para>
		/// <para>IID_IMFTrustedOutput</para>
		/// <para>IID_ISimpleAudioVolume</para>
		/// <para>For more information, see Remarks.</para>
		/// </param>
		/// <returns>
		/// Pointer to a pointer variable into which the method writes the address of an instance of the requested interface. Through this
		/// method, the caller obtains a counted reference to the interface. The caller is responsible for releasing the interface, when it
		/// is no longer needed, by calling the interface's <c>Release</c> method. If the <c>GetService</c> call fails, *ppv is <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>The <c>GetService</c> method supports the following service interfaces:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IAudioCaptureClient</term>
		/// </item>
		/// <item>
		/// <term>IAudioClock</term>
		/// </item>
		/// <item>
		/// <term>IAudioRenderClient</term>
		/// </item>
		/// <item>
		/// <term>IAudioSessionControl</term>
		/// </item>
		/// <item>
		/// <term>IAudioStreamVolume</term>
		/// </item>
		/// <item>
		/// <term>IChannelAudioVolume</term>
		/// </item>
		/// <item>
		/// <term>IMFTrustedOutput</term>
		/// </item>
		/// <item>
		/// <term>ISimpleAudioVolume</term>
		/// </item>
		/// </list>
		/// <para>
		/// In Windows 7, a new service identifier, <c>IID_IMFTrustedOutput</c>, has been added that facilitates the use of output trust
		/// authority (OTA) objects. These objects can operate inside or outside the Media Foundation's protected media path (PMP) and send
		/// content outside the Media Foundation pipeline. If the caller is outside PMP, then the OTA may not operate in the PMP, and the
		/// protection settings are less robust. OTAs must implement the IMFTrustedOutput interface. By passing <c>IID_IMFTrustedOutput</c>
		/// in <c>GetService</c>, an application can retrieve a pointer to the object's <c>IMFTrustedOutput</c> interface. For more
		/// information about protected objects and <c>IMFTrustedOutput</c>, see "Protected Media Path" in the Media Foundation SDK documentation.
		/// </para>
		/// <para>For information about using trusted audio drivers in OTAs, see Protected User Mode Audio (PUMA).</para>
		/// <para>
		/// Note that activating IMFTrustedOutput through this mechanism works regardless of whether the caller is running in PMP. However,
		/// if the caller is not running in a protected process (that is, the caller is not within Media Foundation's PMP) then the audio OTA
		/// might not operate in the PMP and the protection settings are less robust.
		/// </para>
		/// <para>
		/// To obtain the interface ID for a service interface, use the <c>__uuidof</c> operator. For example, the interface ID of
		/// <c>IAudioCaptureClient</c> is defined as follows:
		/// </para>
		/// <para>For information about the <c>__uuidof</c> operator, see the Windows SDK documentation.</para>
		/// <para>
		/// To release the <c>IAudioClient</c> object and free all its associated resources, the client must release all references to any
		/// service objects that were created by calling <c>GetService</c>, in addition to calling <c>Release</c> on the <c>IAudioClient</c>
		/// interface itself. The client must release a service from the same thread that releases the <c>IAudioClient</c> object.
		/// </para>
		/// <para>
		/// The <c>IAudioSessionControl</c>, <c>IAudioStreamVolume</c>, <c>IChannelAudioVolume</c>, and <c>ISimpleAudioVolume</c> interfaces
		/// control and monitor aspects of audio sessions and shared-mode streams. These interfaces do not work with exclusive-mode streams.
		/// </para>
		/// <para>For code examples that call the <c>GetService</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getservice HRESULT GetService( REFIID
		// riid, void **ppv );
		[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)]
		object GetService(in Guid riid);
	}

	/// <summary>
	/// The <c>IAudioClient2</c> interface is derived from the IAudioClient interface, with a set of additional methods that enable a Windows
	/// Audio Session API (WASAPI) audio client to do the following: opt in for offloading, query stream properties, and get information from
	/// the hardware that handles offloading.The audio client can be successful in creating an offloaded stream if the underlying endpoint
	/// supports the hardware audio engine, the endpoint has been enumerated and discovered by the audio system, and there are still offload
	/// pin instances available on the endpoint.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nn-audioclient-iaudioclient2
	[PInvokeData("audioclient.h", MSDNShortId = "9CE79CEB-115E-4802-A687-B2CB23E6A0E0")]
	[ComImport, Guid("726778CD-F60A-4eda-82DE-E47610CD78AA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioClient2 : IAudioClient
	{
		/// <summary>The <c>Initialize</c> method initializes the audio stream.</summary>
		/// <param name="ShareMode">
		/// <para>
		/// The sharing mode for the connection. Through this parameter, the client tells the audio engine whether it wants to share the
		/// audio endpoint device with other clients. The client should set this parameter to one of the following AUDCLNT_SHAREMODE
		/// enumeration values:
		/// </para>
		/// <para>AUDCLNT_SHAREMODE_EXCLUSIVE</para>
		/// <para>AUDCLNT_SHAREMODE_SHARED</para>
		/// </param>
		/// <param name="StreamFlags">
		/// Flags to control creation of the stream. The client should set this parameter to 0 or to the bitwise OR of one or more of the
		/// AUDCLNT_STREAMFLAGS_XXX Constants or the AUDCLNT_SESSIONFLAGS_XXX Constants.
		/// </param>
		/// <param name="hnsBufferDuration">
		/// The buffer capacity as a time value. This parameter is of type <c>REFERENCE_TIME</c> and is expressed in 100-nanosecond units.
		/// This parameter contains the buffer size that the caller requests for the buffer that the audio application will share with the
		/// audio engine (in shared mode) or with the endpoint device (in exclusive mode). If the call succeeds, the method allocates a
		/// buffer that is a least this large. For more information about <c>REFERENCE_TIME</c>, see the Windows SDK documentation. For more
		/// information about buffering requirements, see Remarks.
		/// </param>
		/// <param name="hnsPeriodicity">
		/// The device period. This parameter can be nonzero only in exclusive mode. In shared mode, always set this parameter to 0. In
		/// exclusive mode, this parameter specifies the requested scheduling period for successive buffer accesses by the audio endpoint
		/// device. If the requested device period lies outside the range that is set by the device's minimum period and the system's maximum
		/// period, then the method clamps the period to that range. If this parameter is 0, the method sets the device period to its default
		/// value. To obtain the default device period, call the IAudioClient::GetDevicePeriod method. If the
		/// AUDCLNT_STREAMFLAGS_EVENTCALLBACK stream flag is set and AUDCLNT_SHAREMODE_EXCLUSIVE is set as the ShareMode, then hnsPeriodicity
		/// must be nonzero and equal to hnsBufferDuration.
		/// </param>
		/// <param name="pFormat">
		/// Pointer to a format descriptor. This parameter must point to a valid format descriptor of type <c>WAVEFORMATEX</c> (or
		/// <c>WAVEFORMATEXTENSIBLE</c>). For more information, see Remarks.
		/// </param>
		/// <param name="AudioSessionGuid">
		/// Pointer to a session GUID. This parameter points to a GUID value that identifies the audio session that the stream belongs to. If
		/// the GUID identifies a session that has been previously opened, the method adds the stream to that session. If the GUID does not
		/// identify an existing session, the method opens a new session and adds the stream to that session. The stream remains a member of
		/// the same session for its lifetime. Setting this parameter to <c>NULL</c> is equivalent to passing a pointer to a GUID_NULL value.
		/// </param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. If it fails, possible return codes include, but are not limited to, the values shown in
		/// the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>AUDCLNT_E_ALREADY_INITIALIZED</term>
		/// <term>The IAudioClient object is already initialized.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_WRONG_ENDPOINT_TYPE</term>
		/// <term>The AUDCLNT_STREAMFLAGS_LOOPBACK flag is set but the endpoint device is a capture device, not a rendering device.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED</term>
		/// <term>
		/// The requested buffer size is not aligned. This code can be returned for a render or a capture device if the caller specified
		/// AUDCLNT_SHAREMODE_EXCLUSIVE and the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flags. The caller must call Initialize again with the
		/// aligned buffer size. For more information, see Remarks.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_BUFFER_SIZE_ERROR</term>
		/// <term>
		/// Indicates that the buffer duration value requested by an exclusive-mode client is out of range. The requested duration value for
		/// pull mode must not be greater than 500 milliseconds; for push mode the duration value must not be greater than 2 seconds.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_CPUUSAGE_EXCEEDED</term>
		/// <term>
		/// Indicates that the process-pass duration exceeded the maximum CPU usage. The audio engine keeps track of CPU usage by maintaining
		/// the number of times the process-pass duration exceeds the maximum CPU usage. The maximum CPU usage is calculated as a percent of
		/// the engine's periodicity. The percentage value is the system's CPU throttle value (within the range of 10% and 90%). If this
		/// value is not found, then the default value of 40% is used to calculate the maximum CPU usage.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
		/// <term>
		/// The audio endpoint device has been unplugged, or the audio hardware or associated hardware resources have been reconfigured,
		/// disabled, removed, or otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_IN_USE</term>
		/// <term>
		/// The endpoint device is already in use. Either the device is being used in exclusive mode, or the device is being used in shared
		/// mode and the caller asked to use the device in exclusive mode.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_ENDPOINT_CREATE_FAILED</term>
		/// <term>
		/// The method failed to create the audio endpoint for the render or the capture device. This can occur if the audio endpoint device
		/// has been unplugged, or the audio hardware or associated hardware resources have been reconfigured, disabled, removed, or
		/// otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_INVALID_DEVICE_PERIOD</term>
		/// <term>Indicates that the device period requested by an exclusive-mode client is greater than 500 milliseconds.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_UNSUPPORTED_FORMAT</term>
		/// <term>The audio engine (shared mode) or audio endpoint device (exclusive mode) does not support the specified format.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_EXCLUSIVE_MODE_NOT_ALLOWED</term>
		/// <term>
		/// The caller is requesting exclusive-mode use of the endpoint device, but the user has disabled exclusive-mode use of the device.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_BUFDURATION_PERIOD_NOT_EQUAL</term>
		/// <term>The AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag is set but parameters hnsBufferDuration and hnsPeriodicity are not equal.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_SERVICE_NOT_RUNNING</term>
		/// <term>The Windows audio service is not running.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>Parameter pFormat is NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>
		/// Parameter pFormat points to an invalid format description; or the AUDCLNT_STREAMFLAGS_LOOPBACK flag is set but ShareMode is not
		/// equal to AUDCLNT_SHAREMODE_SHARED; or the AUDCLNT_STREAMFLAGS_CROSSPROCESS flag is set but ShareMode is equal to
		/// AUDCLNT_SHAREMODE_EXCLUSIVE. A prior call to SetClientProperties was made with an invalid category for audio/render streams.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Out of memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// After activating an IAudioClient interface on an audio endpoint device, the client must successfully call <c>Initialize</c> once
		/// and only once to initialize the audio stream between the client and the device. The client can either connect directly to the
		/// audio hardware (exclusive mode) or indirectly through the audio engine (shared mode). In the <c>Initialize</c> call, the client
		/// specifies the audio data format, the buffer size, and audio session for the stream.
		/// </para>
		/// <para>
		/// <c>Note</c> In Windows 8, the first use of IAudioClient to access the audio device should be on the STA thread. Calls from an MTA
		/// thread may result in undefined behavior.
		/// </para>
		/// <para>
		/// An attempt to create a shared-mode stream can succeed only if the audio device is already operating in shared mode or the device
		/// is currently unused. An attempt to create a shared-mode stream fails if the device is already operating in exclusive mode.
		/// </para>
		/// <para>
		/// If a stream is initialized to be event driven and in shared mode, ShareMode is set to AUDCLNT_SHAREMODE_SHARED and one of the
		/// stream flags that are set includes AUDCLNT_STREAMFLAGS_EVENTCALLBACK. For such a stream, the associated application must also
		/// obtain a handle by making a call to IAudioClient::SetEventHandle. When it is time to retire the stream, the audio engine can then
		/// use the handle to release the stream objects. Failure to call <c>IAudioClient::SetEventHandle</c> before releasing the stream
		/// objects can cause a delay of several seconds (a time-out period) while the audio engine waits for an available handle. After the
		/// time-out period expires, the audio engine then releases the stream objects.
		/// </para>
		/// <para>
		/// Whether an attempt to create an exclusive-mode stream succeeds depends on several factors, including the availability of the
		/// device and the user-controlled settings that govern exclusive-mode operation of the device. For more information, see
		/// Exclusive-Mode Streams.
		/// </para>
		/// <para>
		/// An <c>IAudioClient</c> object supports exactly one connection to the audio engine or audio hardware. This connection lasts for
		/// the lifetime of the <c>IAudioClient</c> object.
		/// </para>
		/// <para>The client should call the following methods only after calling <c>Initialize</c>:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IAudioClient::GetBufferSize</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::GetCurrentPadding</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::GetService</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::GetStreamLatency</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::Reset</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::SetEventHandle</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::Start</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::Stop</term>
		/// </item>
		/// </list>
		/// <para>The following methods do not require that <c>Initialize</c> be called first:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IAudioClient::GetDevicePeriod</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::GetMixFormat</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::IsFormatSupported</term>
		/// </item>
		/// </list>
		/// <para>These methods can be called any time after activating the <c>IAudioClient</c> interface.</para>
		/// <para>
		/// Before calling <c>Initialize</c> to set up a shared-mode or exclusive-mode connection, the client can call the
		/// IAudioClient::IsFormatSupported method to discover whether the audio engine or audio endpoint device supports a particular format
		/// in that mode. Before opening a shared-mode connection, the client can obtain the audio engine's mix format by calling the
		/// IAudioClient::GetMixFormat method.
		/// </para>
		/// <para>
		/// The endpoint buffer that is shared between the client and audio engine must be large enough to prevent glitches from occurring in
		/// the audio stream between processing passes by the client and audio engine. For a rendering endpoint, the client thread
		/// periodically writes data to the buffer, and the audio engine thread periodically reads data from the buffer. For a capture
		/// endpoint, the engine thread periodically writes to the buffer, and the client thread periodically reads from the buffer. In
		/// either case, if the periods of the client thread and engine thread are not equal, the buffer must be large enough to accommodate
		/// the longer of the two periods without allowing glitches to occur.
		/// </para>
		/// <para>
		/// The client specifies a buffer size through the hnsBufferDuration parameter. The client is responsible for requesting a buffer
		/// that is large enough to ensure that glitches cannot occur between the periodic processing passes that it performs on the buffer.
		/// Similarly, the <c>Initialize</c> method ensures that the buffer is never smaller than the minimum buffer size needed to ensure
		/// that glitches do not occur between the periodic processing passes that the engine thread performs on the buffer. If the client
		/// requests a buffer size that is smaller than the audio engine's minimum required buffer size, the method sets the buffer size to
		/// this minimum buffer size rather than to the buffer size requested by the client.
		/// </para>
		/// <para>
		/// If the client requests a buffer size (through the hnsBufferDuration parameter) that is not an integral number of audio frames,
		/// the method rounds up the requested buffer size to the next integral number of frames.
		/// </para>
		/// <para>
		/// Following the <c>Initialize</c> call, the client should call the IAudioClient::GetBufferSize method to get the precise size of
		/// the endpoint buffer. During each processing pass, the client will need the actual buffer size to calculate how much data to
		/// transfer to or from the buffer. The client calls the IAudioClient::GetCurrentPadding method to determine how much of the data in
		/// the buffer is currently available for processing.
		/// </para>
		/// <para>
		/// To achieve the minimum stream latency between the client application and audio endpoint device, the client thread should run at
		/// the same period as the audio engine thread. The period of the engine thread is fixed and cannot be controlled by the client.
		/// Making the client's period smaller than the engine's period unnecessarily increases the client thread's load on the processor
		/// without improving latency or decreasing the buffer size. To determine the period of the engine thread, the client can call the
		/// IAudioClient::GetDevicePeriod method. To set the buffer to the minimum size required by the engine thread, the client should call
		/// <c>Initialize</c> with the hnsBufferDuration parameter set to 0. Following the <c>Initialize</c> call, the client can get the
		/// size of the resulting buffer by calling <c>IAudioClient::GetBufferSize</c>.
		/// </para>
		/// <para>
		/// A client has the option of requesting a buffer size that is larger than what is strictly necessary to make timing glitches rare
		/// or nonexistent. Increasing the buffer size does not necessarily increase the stream latency. For a rendering stream, the latency
		/// through the buffer is determined solely by the separation between the client's write pointer and the engine's read pointer. For a
		/// capture stream, the latency through the buffer is determined solely by the separation between the engine's write pointer and the
		/// client's read pointer.
		/// </para>
		/// <para>
		/// The loopback flag (AUDCLNT_STREAMFLAGS_LOOPBACK) enables audio loopback. A client can enable audio loopback only on a rendering
		/// endpoint with a shared-mode stream. Audio loopback is provided primarily to support acoustic echo cancellation (AEC).
		/// </para>
		/// <para>
		/// An AEC client requires both a rendering endpoint and the ability to capture the output stream from the audio engine. The engine's
		/// output stream is the global mix that the audio device plays through the speakers. If audio loopback is enabled, a client can open
		/// a capture buffer for the global audio mix by calling the IAudioClient::GetService method to obtain an IAudioCaptureClient
		/// interface on the rendering stream object. If audio loopback is not enabled, then an attempt to open a capture buffer on a
		/// rendering stream will fail. The loopback data in the capture buffer is in the device format, which the client can obtain by
		/// querying the device's PKEY_AudioEngine_DeviceFormat property.
		/// </para>
		/// <para>
		/// On Windows versions prior to Windows 10, a pull-mode capture client will not receive any events when a stream is initialized with
		/// event-driven buffering (AUDCLNT_STREAMFLAGS_EVENTCALLBACK) and is loopback-enabled (AUDCLNT_STREAMFLAGS_LOOPBACK). If the stream
		/// is opened with this configuration, the <c>Initialize</c> call succeeds, but relevant events are not raised to notify the capture
		/// client each time a buffer becomes ready for processing. To work around this, initialize a render stream in event-driven mode.
		/// Each time the client receives an event for the render stream, it must signal the capture client to run the capture thread that
		/// reads the next set of samples from the capture endpoint buffer. As of Windows 10 the relevant event handles are now set for
		/// loopback-enabled streams that are active.
		/// </para>
		/// <para>
		/// Note that all streams must be opened in share mode because exclusive-mode streams cannot operate in loopback mode. For more
		/// information about audio loopback, see Loopback Recording.
		/// </para>
		/// <para>
		/// The AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag indicates that processing of the audio buffer by the client will be event driven.
		/// WASAPI supports event-driven buffering to enable low-latency processing of both shared-mode and exclusive-mode streams.
		/// </para>
		/// <para>
		/// The initial release of Windows Vista supports event-driven buffering (that is, the use of the AUDCLNT_STREAMFLAGS_EVENTCALLBACK
		/// flag) for rendering streams only.
		/// </para>
		/// <para>
		/// In the initial release of Windows Vista, for capture streams, the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag is supported only in
		/// shared mode. Setting this flag has no effect for exclusive-mode capture streams. That is, although the application specifies this
		/// flag in exclusive mode through the <c>Initialize</c> call, the application will not receive any events that are usually required
		/// to capture the audio stream. In the Windows Vista Service Pack 1 release, this flag is functional in shared-mode and exclusive
		/// mode; an application can set this flag to enable event-buffering for capture streams. For more information about capturing an
		/// audio stream, see Capturing a Stream.
		/// </para>
		/// <para>
		/// To enable event-driven buffering, the client must provide an event handle to the system. Following the <c>Initialize</c> call and
		/// before calling the IAudioClient::Start method to start the stream, the client must call the IAudioClient::SetEventHandle method
		/// to set the event handle. While the stream is running, the system periodically signals the event to indicate to the client that
		/// audio data is available for processing. Between processing passes, the client thread waits on the event handle by calling a
		/// synchronization function such as <c>WaitForSingleObject</c>. For more information about synchronization functions, see the
		/// Windows SDK documentation.
		/// </para>
		/// <para>
		/// For a shared-mode stream that uses event-driven buffering, the caller must set both hnsPeriodicity and hnsBufferDuration to
		/// 0. The <c>Initialize</c> method determines how large a buffer to allocate based on the scheduling period of the audio engine.
		/// Although the client's buffer processing thread is event driven, the basic buffer management process, as described previously, is
		/// unaltered. Each time the thread awakens, it should call IAudioClient::GetCurrentPadding to determine how much data to write to a
		/// rendering buffer or read from a capture buffer. In contrast to the two buffers that the <c>Initialize</c> method allocates for an
		/// exclusive-mode stream that uses event-driven buffering, a shared-mode stream requires a single buffer.
		/// </para>
		/// <para>
		/// For an exclusive-mode stream that uses event-driven buffering, the caller must specify nonzero values for hnsPeriodicity and
		/// hnsBufferDuration, and the values of these two parameters must be equal. The <c>Initialize</c> method allocates two buffers for
		/// the stream. Each buffer is equal in duration to the value of the hnsBufferDuration parameter. Following the <c>Initialize</c>
		/// call for a rendering stream, the caller should fill the first of the two buffers before starting the stream. For a capture
		/// stream, the buffers are initially empty, and the caller should assume that each buffer remains empty until the event for that
		/// buffer is signaled. While the stream is running, the system alternately sends one buffer or the other to the client—this form of
		/// double buffering is referred to as "ping-ponging". Each time the client receives a buffer from the system (which the system
		/// indicates by signaling the event), the client must process the entire buffer. For example, if the client requests a packet size
		/// from the IAudioRenderClient::GetBuffer method that does not match the buffer size, the method fails. Calls to the
		/// <c>IAudioClient::GetCurrentPadding</c> method are unnecessary because the packet size must always equal the buffer size. In
		/// contrast to the buffering modes discussed previously, the latency for an event-driven, exclusive-mode stream depends directly on
		/// the buffer size.
		/// </para>
		/// <para>
		/// As explained in Audio Sessions, the default behavior for a session that contains rendering streams is that its volume and mute
		/// settings persist across system restarts. The AUDCLNT_STREAMFLAGS_NOPERSIST flag overrides the default behavior and makes the
		/// settings nonpersistent. This flag has no effect on sessions that contain capture streams—the settings for those sessions are
		/// never persistent. In addition, the settings for a session that contains a loopback stream (a stream that is initialized with the
		/// AUDCLNT_STREAMFLAGS_LOOPBACK flag) are not persistent.
		/// </para>
		/// <para>
		/// Only a session that connects to a rendering endpoint device can have persistent volume and mute settings. The first stream to be
		/// added to the session determines whether the session's settings are persistent. Thus, if the AUDCLNT_STREAMFLAGS_NOPERSIST or
		/// AUDCLNT_STREAMFLAGS_LOOPBACK flag is set during initialization of the first stream, the session's settings are not persistent.
		/// Otherwise, they are persistent. Their persistence is unaffected by additional streams that might be subsequently added or removed
		/// during the lifetime of the session object.
		/// </para>
		/// <para>
		/// After a call to <c>Initialize</c> has successfully initialized an <c>IAudioClient</c> interface instance, a subsequent
		/// <c>Initialize</c> call to initialize the same interface instance will fail and return error code E_ALREADY_INITIALIZED.
		/// </para>
		/// <para>
		/// If the initial call to <c>Initialize</c> fails, subsequent <c>Initialize</c> calls might fail and return error code
		/// E_ALREADY_INITIALIZED, even though the interface has not been initialized. If this occurs, release the <c>IAudioClient</c>
		/// interface and obtain a new <c>IAudioClient</c> interface from the MMDevice API before calling <c>Initialize</c> again.
		/// </para>
		/// <para>For code examples that call the <c>Initialize</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// <item>
		/// <term>Exclusive-Mode Streams</term>
		/// </item>
		/// </list>
		/// <para>
		/// Starting with Windows 7, <c>Initialize</c> can return AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED for a render or a capture device. This
		/// indicates that the buffer size, specified by the caller in the hnsBufferDuration parameter, is not aligned. This error code is
		/// returned only if the caller requested an exclusive-mode stream (AUDCLNT_SHAREMODE_EXCLUSIVE) and event-driven buffering (AUDCLNT_STREAMFLAGS_EVENTCALLBACK).
		/// </para>
		/// <para>
		/// If <c>Initialize</c> returns AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED, the caller must call <c>Initialize</c> again and specify the
		/// aligned buffer size. Use the following steps:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Call IAudioClient::GetBufferSize and receive the next-highest-aligned buffer size (in frames).</term>
		/// </item>
		/// <item>
		/// <term>Call <c>IAudioClient::Release</c> to release the audio client used in the previous call that returned AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Calculate the aligned buffer size in 100-nansecond units (hns). The buffer size is . In this formula, is the buffer size
		/// retrieved by GetBufferSize.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Call the IMMDevice::Activate method with parameter iid set to REFIID IID_IAudioClient to create a new audio client.</term>
		/// </item>
		/// <item>
		/// <term>Call <c>Initialize</c> again on the created audio client and specify the new buffer size and periodicity.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Starting with Windows 10, hardware-offloaded audio streams must be event driven. This means that if you call
		/// IAudioClient2::SetClientProperties and set the bIsOffload parameter of the AudioClientProperties to TRUE, you must specify the
		/// <c>AUDCLNT_STREAMFLAGS_EVENTCALLBACK</c> flag in the StreamFlags parameter to <c>IAudioClient::Initialize</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example code shows how to respond to the <c>AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED</c> return code.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-initialize HRESULT Initialize(
		// AUDCLNT_SHAREMODE ShareMode, DWORD StreamFlags, REFERENCE_TIME hnsBufferDuration, REFERENCE_TIME hnsPeriodicity, const
		// WAVEFORMATEX *pFormat, LPCGUID AudioSessionGuid );
		[PreserveSig]
		new HRESULT Initialize([In] AUDCLNT_SHAREMODE ShareMode, AUDCLNT_STREAMFLAGS StreamFlags, long hnsBufferDuration, long hnsPeriodicity, [In] IntPtr pFormat, [In, Optional] in Guid AudioSessionGuid);

		/// <summary>The <c>GetBufferSize</c> method retrieves the size (maximum capacity) of the endpoint buffer.</summary>
		/// <returns>Pointer to a <c>UINT32</c> variable into which the method writes the number of audio frames that the buffer can hold.</returns>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// This method retrieves the length of the endpoint buffer shared between the client application and the audio engine. The length is
		/// expressed as the number of audio frames the buffer can hold. The size in bytes of an audio frame is calculated as the number of
		/// channels in the stream multiplied by the sample size per channel. For example, the frame size is four bytes for a stereo
		/// (2-channel) stream with 16-bit samples.
		/// </para>
		/// <para>
		/// The IAudioClient::Initialize method allocates the buffer. The client specifies the buffer length in the hnsBufferDuration
		/// parameter value that it passes to the <c>Initialize</c> method. For rendering clients, the buffer length determines the maximum
		/// amount of rendering data that the application can write to the endpoint buffer during a single processing pass. For capture
		/// clients, the buffer length determines the maximum amount of capture data that the audio engine can read from the endpoint buffer
		/// during a single processing pass. The client should always call <c>GetBufferSize</c> after calling <c>Initialize</c> to determine
		/// the actual size of the allocated buffer, which might differ from the requested size.
		/// </para>
		/// <para>
		/// Rendering clients can use this value to calculate the largest rendering buffer size that can be requested from
		/// IAudioRenderClient::GetBuffer during each processing pass.
		/// </para>
		/// <para>For code examples that call the <c>GetBufferSize</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getbuffersize HRESULT GetBufferSize(
		// UINT32 *pNumBufferFrames );
		new uint GetBufferSize();

		/// <summary>
		/// The <c>GetStreamLatency</c> method retrieves the maximum latency for the current stream and can be called any time after the
		/// stream has been initialized.
		/// </summary>
		/// <returns>
		/// Pointer to a REFERENCE_TIME variable into which the method writes a time value representing the latency. The time is expressed in
		/// 100-nanosecond units. For more information about <c>REFERENCE_TIME</c>, see the Windows SDK documentation.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// This method retrieves the maximum latency for the current stream. The value will not change for the lifetime of the IAudioClient object.
		/// </para>
		/// <para>
		/// Rendering clients can use this latency value to compute the minimum amount of data that they can write during any single
		/// processing pass. To write less than this minimum is to risk introducing glitches into the audio stream. For more information, see IAudioRenderClient::GetBuffer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getstreamlatency HRESULT
		// GetStreamLatency( REFERENCE_TIME *phnsLatency );
		new long GetStreamLatency();

		/// <summary>The <c>GetCurrentPadding</c> method retrieves the number of frames of padding in the endpoint buffer.</summary>
		/// <returns>
		/// Pointer to a <c>UINT32</c> variable into which the method writes the frame count (the number of audio frames of padding in the buffer).
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// This method retrieves a padding value that indicates the amount of valid, unread data that the endpoint buffer currently
		/// contains. A rendering application can use the padding value to determine how much new data it can safely write to the endpoint
		/// buffer without overwriting previously written data that the audio engine has not yet read from the buffer. A capture application
		/// can use the padding value to determine how much new data it can safely read from the endpoint buffer without reading invalid data
		/// from a region of the buffer to which the audio engine has not yet written valid data.
		/// </para>
		/// <para>
		/// The padding value is expressed as a number of audio frames. The size of an audio frame is specified by the <c>nBlockAlign</c>
		/// member of the WAVEFORMATEX (or WAVEFORMATEXTENSIBLE) structure that the client passed to the IAudioClient::Initialize method. The
		/// size in bytes of an audio frame equals the number of channels in the stream multiplied by the sample size per channel. For
		/// example, the frame size is four bytes for a stereo (2-channel) stream with 16-bit samples.
		/// </para>
		/// <para>
		/// For a shared-mode rendering stream, the padding value reported by <c>GetCurrentPadding</c> specifies the number of audio frames
		/// that are queued up to play in the endpoint buffer. Before writing to the endpoint buffer, the client can calculate the amount of
		/// available space in the buffer by subtracting the padding value from the buffer length. To ensure that a subsequent call to the
		/// IAudioRenderClient::GetBuffer method succeeds, the client should request a packet length that does not exceed the available space
		/// in the buffer. To obtain the buffer length, call the IAudioClient::GetBufferSize method.
		/// </para>
		/// <para>
		/// For a shared-mode capture stream, the padding value reported by <c>GetCurrentPadding</c> specifies the number of frames of
		/// capture data that are available in the next packet in the endpoint buffer. At a particular moment, zero, one, or more packets of
		/// capture data might be ready for the client to read from the buffer. If no packets are currently available, the method reports a
		/// padding value of 0. Following the <c>GetCurrentPadding</c> call, an IAudioCaptureClient::GetBuffer method call will retrieve a
		/// packet whose length exactly equals the padding value reported by <c>GetCurrentPadding</c>. Each call to GetBuffer retrieves a
		/// whole packet. A packet always contains an integral number of audio frames.
		/// </para>
		/// <para>
		/// For a shared-mode capture stream, calling <c>GetCurrentPadding</c> is equivalent to calling the
		/// IAudioCaptureClient::GetNextPacketSize method. That is, the padding value reported by <c>GetCurrentPadding</c> is equal to the
		/// packet length reported by <c>GetNextPacketSize</c>.
		/// </para>
		/// <para>
		/// For an exclusive-mode rendering or capture stream that was initialized with the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag, the
		/// client typically has no use for the padding value reported by <c>GetCurrentPadding</c>. Instead, the client accesses an entire
		/// buffer during each processing pass. Each time a buffer becomes available for processing, the audio engine notifies the client by
		/// signaling the client's event handle. For more information about this flag, see IAudioClient::Initialize.
		/// </para>
		/// <para>
		/// For an exclusive-mode rendering or capture stream that was not initialized with the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag, the
		/// client can use the padding value obtained from <c>GetCurrentPadding</c> in a way that is similar to that described previously for
		/// a shared-mode stream. The details are as follows.
		/// </para>
		/// <para>
		/// First, for an exclusive-mode rendering stream, the padding value specifies the number of audio frames that are queued up to play
		/// in the endpoint buffer. As before, the client can calculate the amount of available space in the buffer by subtracting the
		/// padding value from the buffer length.
		/// </para>
		/// <para>
		/// Second, for an exclusive-mode capture stream, the padding value reported by <c>GetCurrentPadding</c> specifies the current length
		/// of the next packet. However, this padding value is a snapshot of the packet length, which might increase before the client calls
		/// the IAudioCaptureClient::GetBuffer method. Thus, the length of the packet retrieved by <c>GetBuffer</c> is at least as large as,
		/// but might be larger than, the padding value reported by the <c>GetCurrentPadding</c> call that preceded the <c>GetBuffer</c>
		/// call. In contrast, for a shared-mode capture stream, the length of the packet obtained from <c>GetBuffer</c> always equals the
		/// padding value reported by the preceding <c>GetCurrentPadding</c> call.
		/// </para>
		/// <para>For a code example that calls the <c>GetCurrentPadding</c> method, see Rendering a Stream.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getcurrentpadding HRESULT
		// GetCurrentPadding( UINT32 *pNumPaddingFrames );
		new uint GetCurrentPadding();

		/// <summary>The <c>IsFormatSupported</c> method indicates whether the audio endpoint device supports a particular stream format.</summary>
		/// <param name="ShareMode">
		/// <para>
		/// The sharing mode for the stream format. Through this parameter, the client indicates whether it wants to use the specified format
		/// in exclusive mode or shared mode. The client should set this parameter to one of the following AUDCLNT_SHAREMODE enumeration values:
		/// </para>
		/// <para>AUDCLNT_SHAREMODE_EXCLUSIVE</para>
		/// <para>AUDCLNT_SHAREMODE_SHARED</para>
		/// </param>
		/// <param name="pFormat">
		/// Pointer to the specified stream format. This parameter points to a caller-allocated format descriptor of type <c>WAVEFORMATEX</c>
		/// or <c>WAVEFORMATEXTENSIBLE</c>. The client writes a format description to this structure before calling this method. For
		/// information about <c>WAVEFORMATEX</c> and <c>WAVEFORMATEXTENSIBLE</c>, see the Windows DDK documentation.
		/// </param>
		/// <param name="ppClosestMatch">
		/// Pointer to a pointer variable into which the method writes the address of a <c>WAVEFORMATEX</c> or <c>WAVEFORMATEXTENSIBLE</c>
		/// structure. This structure specifies the supported format that is closest to the format that the client specified through the
		/// pFormat parameter. For shared mode (that is, if the ShareMode parameter is AUDCLNT_SHAREMODE_SHARED), set ppClosestMatch to point
		/// to a valid, non- <c>NULL</c> pointer variable. For exclusive mode, set ppClosestMatch to <c>NULL</c>. The method allocates the
		/// storage for the structure. The caller is responsible for freeing the storage, when it is no longer needed, by calling the
		/// <c>CoTaskMemFree</c> function. If the <c>IsFormatSupported</c> call fails and ppClosestMatch is non- <c>NULL</c>, the method sets
		/// *ppClosestMatch to <c>NULL</c>. For information about <c>CoTaskMemFree</c>, see the Windows SDK documentation.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Succeeded and the audio endpoint device supports the specified stream format.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>Succeeded with a closest match to the specified format.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_UNSUPPORTED_FORMAT</term>
		/// <term>Succeeded but the specified format is not supported in exclusive mode.</term>
		/// </item>
		/// </list>
		/// <para>If the operation fails, possible return codes include, but are not limited to, the values shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>Parameter pFormat is NULL, or ppClosestMatch is NULL and ShareMode is AUDCLNT_SHAREMODE_SHARED.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>Parameter ShareMode is a value other than AUDCLNT_SHAREMODE_SHARED or AUDCLNT_SHAREMODE_EXCLUSIVE.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
		/// <term>
		/// The audio endpoint device has been unplugged, or the audio hardware or associated hardware resources have been reconfigured,
		/// disabled, removed, or otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_SERVICE_NOT_RUNNING</term>
		/// <term>The Windows audio service is not running.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method provides a way for a client to determine, before calling IAudioClient::Initialize, whether the audio engine supports
		/// a particular stream format.
		/// </para>
		/// <para>
		/// For exclusive mode, <c>IsFormatSupported</c> returns S_OK if the audio endpoint device supports the caller-specified format, or
		/// it returns AUDCLNT_E_UNSUPPORTED_FORMAT if the device does not support the format. The ppClosestMatch parameter can be
		/// <c>NULL</c>. If it is not <c>NULL</c>, the method writes <c>NULL</c> to *ppClosestMatch.
		/// </para>
		/// <para>
		/// For shared mode, if the audio engine supports the caller-specified format, <c>IsFormatSupported</c> sets <c>*ppClosestMatch</c>
		/// to <c>NULL</c> and returns S_OK. If the audio engine does not support the caller-specified format but does support a similar
		/// format, the method retrieves the similar format through the ppClosestMatch parameter and returns S_FALSE. If the audio engine
		/// does not support the caller-specified format or any similar format, the method sets
		/// *ppClosestMatch to <c>NULL</c> and returns AUDCLNT_E_UNSUPPORTED_FORMAT.
		/// </para>
		/// <para>
		/// In shared mode, the audio engine always supports the mix format, which the client can obtain by calling the
		/// IAudioClient::GetMixFormat method. In addition, the audio engine might support similar formats that have the same sample rate and
		/// number of channels as the mix format but differ in the representation of audio sample values. The audio engine represents sample
		/// values internally as floating-point numbers, but if the caller-specified format represents sample values as integers, the audio
		/// engine typically can convert between the integer sample values and its internal floating-point representation.
		/// </para>
		/// <para>
		/// The audio engine might be able to support an even wider range of shared-mode formats if the installation package for the audio
		/// device includes a local effects (LFX) audio processing object (APO) that can handle format conversions. An LFX APO is a software
		/// module that performs device-specific processing of an audio stream. The audio graph builder in the Windows audio service inserts
		/// the LFX APO into the stream between each client and the audio engine. When a client calls the <c>IsFormatSupported</c> method and
		/// the method determines that an LFX APO is installed for use with the device, the method directs the query to the LFX APO, which
		/// indicates whether it supports the caller-specified format.
		/// </para>
		/// <para>
		/// For example, a particular LFX APO might accept a 6-channel surround sound stream from a client and convert the stream to a stereo
		/// format that can be played through headphones. Typically, an LFX APO supports only client formats with sample rates that match the
		/// sample rate of the mix format.
		/// </para>
		/// <para>
		/// For more information about APOs, see the white papers titled "Custom Audio Effects in Windows Vista" and "Reusing the Windows
		/// Vista Audio System Effects" at the Audio Device Technologies for Windows website. For more information about the
		/// <c>IsFormatSupported</c> method, see Device Formats.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-isformatsupported HRESULT
		// IsFormatSupported( AUDCLNT_SHAREMODE ShareMode, const WAVEFORMATEX *pFormat, WAVEFORMATEX **ppClosestMatch );
		[PreserveSig]
		new HRESULT IsFormatSupported([In] AUDCLNT_SHAREMODE ShareMode, [In] IntPtr pFormat, out SafeCoTaskMemHandle ppClosestMatch);

		/// <summary>
		/// The <c>GetMixFormat</c> method retrieves the stream format that the audio engine uses for its internal processing of shared-mode streams.
		/// </summary>
		/// <param name="ppDeviceFormat">
		/// Pointer to a pointer variable into which the method writes the address of the mix format. This parameter must be a valid, non-
		/// <c>NULL</c> pointer to a pointer variable. The method writes the address of a <c>WAVEFORMATEX</c> (or
		/// <c>WAVEFORMATEXTENSIBLE</c>) structure to this variable. The method allocates the storage for the structure. The caller is
		/// responsible for freeing the storage, when it is no longer needed, by calling the <c>CoTaskMemFree</c> function. If the
		/// <c>GetMixFormat</c> call fails, *ppDeviceFormat is <c>NULL</c>. For information about <c>WAVEFORMATEX</c>,
		/// <c>WAVEFORMATEXTENSIBLE</c>, and <c>CoTaskMemFree</c>, see the Windows SDK documentation.
		/// </param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. If it fails, possible return codes include, but are not limited to, the values shown in
		/// the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
		/// <term>
		/// The audio endpoint device has been unplugged, or the audio hardware or associated hardware resources have been reconfigured,
		/// disabled, removed, or otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_SERVICE_NOT_RUNNING</term>
		/// <term>The Windows audio service is not running.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>Parameter ppDeviceFormat is NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Out of memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The client can call this method before calling the IAudioClient::Initialize method. When creating a shared-mode stream for an
		/// audio endpoint device, the <c>Initialize</c> method always accepts the stream format obtained from a <c>GetMixFormat</c> call on
		/// the same device.
		/// </para>
		/// <para>
		/// The mix format is the format that the audio engine uses internally for digital processing of shared-mode streams. This format is
		/// not necessarily a format that the audio endpoint device supports. Thus, the caller might not succeed in creating an
		/// exclusive-mode stream with a format obtained by calling <c>GetMixFormat</c>.
		/// </para>
		/// <para>
		/// For example, to facilitate digital audio processing, the audio engine might use a mix format that represents samples as
		/// floating-point values. If the device supports only integer PCM samples, then the engine converts the samples to or from integer
		/// PCM values at the connection between the device and the engine. However, to avoid resampling, the engine might use a mix format
		/// with a sample rate that the device supports.
		/// </para>
		/// <para>
		/// To determine whether the <c>Initialize</c> method can create a shared-mode or exclusive-mode stream with a particular format,
		/// call the IAudioClient::IsFormatSupported method.
		/// </para>
		/// <para>
		/// By itself, a <c>WAVEFORMATEX</c> structure cannot specify the mapping of channels to speaker positions. In addition, although
		/// <c>WAVEFORMATEX</c> specifies the size of the container for each audio sample, it cannot specify the number of bits of precision
		/// in a sample (for example, 20 bits of precision in a 24-bit container). However, the <c>WAVEFORMATEXTENSIBLE</c> structure can
		/// specify both the mapping of channels to speakers and the number of bits of precision in each sample. For this reason, the
		/// <c>GetMixFormat</c> method retrieves a format descriptor that is in the form of a <c>WAVEFORMATEXTENSIBLE</c> structure instead
		/// of a standalone <c>WAVEFORMATEX</c> structure. Through the ppDeviceFormat parameter, the method outputs a pointer to the
		/// <c>WAVEFORMATEX</c> structure that is embedded at the start of this <c>WAVEFORMATEXTENSIBLE</c> structure. For more information
		/// about <c>WAVEFORMATEX</c> and <c>WAVEFORMATEXTENSIBLE</c>, see the Windows DDK documentation.
		/// </para>
		/// <para>
		/// For more information about the <c>GetMixFormat</c> method, see Device Formats. For code examples that call <c>GetMixFormat</c>,
		/// see the following topics:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getmixformat HRESULT GetMixFormat(
		// WAVEFORMATEX **ppDeviceFormat );
		[PreserveSig]
		new HRESULT GetMixFormat(out SafeCoTaskMemHandle ppDeviceFormat);

		/// <summary>
		/// The <c>GetDevicePeriod</c> method retrieves the length of the periodic interval separating successive processing passes by the
		/// audio engine on the data in the endpoint buffer.
		/// </summary>
		/// <param name="phnsDefaultDevicePeriod">
		/// Pointer to a REFERENCE_TIME variable into which the method writes a time value specifying the default interval between periodic
		/// processing passes by the audio engine. The time is expressed in 100-nanosecond units. For information about
		/// <c>REFERENCE_TIME</c>, see the Windows SDK documentation.
		/// </param>
		/// <param name="phnsMinimumDevicePeriod">
		/// Pointer to a REFERENCE_TIME variable into which the method writes a time value specifying the minimum interval between periodic
		/// processing passes by the audio endpoint device. The time is expressed in 100-nanosecond units.
		/// </param>
		/// <remarks>
		/// <para>The client can call this method before calling the IAudioClient::Initialize method.</para>
		/// <para>
		/// The phnsDefaultDevicePeriod parameter specifies the default scheduling period for a shared-mode stream. The
		/// phnsMinimumDevicePeriod parameter specifies the minimum scheduling period for an exclusive-mode stream.
		/// </para>
		/// <para>
		/// At least one of the two parameters, phnsDefaultDevicePeriod and phnsMinimumDevicePeriod, must be non- <c>NULL</c> or the method
		/// returns immediately with error code E_POINTER. If both parameters are non- <c>NULL</c>, then the method outputs both the default
		/// and minimum periods.
		/// </para>
		/// <para>
		/// For a shared-mode stream, the audio engine periodically processes the data in the endpoint buffer, which the engine shares with
		/// the client application. The engine schedules itself to perform these processing passes at regular intervals.
		/// </para>
		/// <para>
		/// The period between processing passes by the audio engine is fixed for a particular audio endpoint device and represents the
		/// smallest processing quantum for the audio engine. This period plus the stream latency between the buffer and endpoint device
		/// represents the minimum possible latency that an audio application can achieve.
		/// </para>
		/// <para>
		/// The client has the option of scheduling its periodic processing thread to run at the same time interval as the audio engine. In
		/// this way, the client can achieve the smallest possible latency for a shared-mode stream. However, in an application for which
		/// latency is less important, the client can reduce the process-switching overhead on the CPU by scheduling its processing passes to
		/// occur less frequently. In this case, the endpoint buffer must be proportionally larger to compensate for the longer period
		/// between processing passes.
		/// </para>
		/// <para>
		/// The client determines the buffer size during its call to the IAudioClient::Initialize method. For a shared-mode stream, if the
		/// client passes this method an hnsBufferDuration parameter value of 0, the method assumes that the periods for the client and audio
		/// engine are guaranteed to be equal, and the method will allocate a buffer small enough to achieve the minimum possible latency.
		/// (In fact, any hnsBufferDuration value between 0 and the sum of the audio engine's period and device latency will have the same
		/// result.) Similarly, for an exclusive-mode stream, if the client sets hnsBufferDuration to 0, the method assumes that the period
		/// of the client is set to the minimum period of the audio endpoint device, and the method will allocate a buffer small enough to
		/// achieve the minimum possible latency.
		/// </para>
		/// <para>
		/// If the client chooses to run its periodic processing thread less often, at the cost of increased latency, it can do so as long as
		/// it creates an endpoint buffer during the IAudioClient::Initialize call that is sufficiently large.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getdeviceperiod HRESULT
		// GetDevicePeriod( REFERENCE_TIME *phnsDefaultDevicePeriod, REFERENCE_TIME *phnsMinimumDevicePeriod );
		new void GetDevicePeriod([Out, Optional] out long phnsDefaultDevicePeriod, out long phnsMinimumDevicePeriod);

		/// <summary>The <c>Start</c> method starts the audio stream.</summary>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// <c>Start</c> is a control method that the client calls to start the audio stream. Starting the stream causes the IAudioClient
		/// object to begin streaming data between the endpoint buffer and the audio engine. It also causes the stream's audio clock to
		/// resume counting from its current position.
		/// </para>
		/// <para>
		/// The first time this method is called following initialization of the stream, the IAudioClient object's stream position counter
		/// begins at 0. Otherwise, the clock resumes from its position at the time that the stream was last stopped. Resetting the stream
		/// forces the stream position back to 0.
		/// </para>
		/// <para>
		/// To avoid start-up glitches with rendering streams, clients should not call <c>Start</c> until the audio engine has been initially
		/// loaded with data by calling the IAudioRenderClient::GetBuffer and IAudioRenderClient::ReleaseBuffer methods on the rendering interface.
		/// </para>
		/// <para>For code examples that call the <c>Start</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-start HRESULT Start();
		new void Start();

		/// <summary>The <c>Stop</c> method stops the audio stream.</summary>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// <c>Stop</c> is a control method that stops a running audio stream. This method stops data from streaming through the client's
		/// connection with the audio engine. Stopping the stream freezes the stream's audio clock at its current stream position. A
		/// subsequent call to IAudioClient::Start causes the stream to resume running from that position. If necessary, the client can call
		/// the IAudioClient::Reset method to reset the position while the stream is stopped.
		/// </para>
		/// <para>For code examples that call the <c>Stop</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-stop HRESULT Stop();
		new void Stop();

		/// <summary>The <c>Reset</c> method resets the audio stream.</summary>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// <c>Reset</c> is a control method that the client calls to reset a stopped audio stream. Resetting the stream flushes all pending
		/// data and resets the audio clock stream position to 0. This method fails if it is called on a stream that is not stopped.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-reset HRESULT Reset();
		new void Reset();

		/// <summary>
		/// The <c>SetEventHandle</c> method sets the event handle that the system signals when an audio buffer is ready to be processed by
		/// the client.
		/// </summary>
		/// <param name="eventHandle">The event handle.</param>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// During stream initialization, the client can, as an option, enable event-driven buffering. To do so, the client calls the
		/// IAudioClient::Initialize method with the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag set. After enabling event-driven buffering, and
		/// before calling the IAudioClient::Start method to start the stream, the client must call <c>SetEventHandle</c> to register the
		/// event handle that the system will signal each time a buffer becomes ready to be processed by the client.
		/// </para>
		/// <para>The event handle should be in the nonsignaled state at the time that the client calls the Start method.</para>
		/// <para>
		/// If the client has enabled event-driven buffering of a stream, but the client calls the Start method for that stream without first
		/// calling <c>SetEventHandle</c>, the <c>Start</c> call will fail and return an error code.
		/// </para>
		/// <para>
		/// If the client does not enable event-driven buffering of a stream but attempts to set an event handle for the stream by calling
		/// <c>SetEventHandle</c>, the call will fail and return an error code.
		/// </para>
		/// <para>For a code example that calls the <c>SetEventHandle</c> method, see Exclusive-Mode Streams.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-seteventhandle HRESULT SetEventHandle(
		// HANDLE eventHandle );
		new void SetEventHandle(HEVENT eventHandle);

		/// <summary>The <c>GetService</c> method accesses additional services from the audio client object.</summary>
		/// <param name="riid">
		/// <para>The interface ID for the requested service. The client should set this parameter to one of the following REFIID values:</para>
		/// <para>IID_IAudioCaptureClient</para>
		/// <para>IID_IAudioClock</para>
		/// <para>IID_IAudioRenderClient</para>
		/// <para>IID_IAudioSessionControl</para>
		/// <para>IID_IAudioStreamVolume</para>
		/// <para>IID_IChannelAudioVolume</para>
		/// <para>IID_IMFTrustedOutput</para>
		/// <para>IID_ISimpleAudioVolume</para>
		/// <para>For more information, see Remarks.</para>
		/// </param>
		/// <returns>
		/// Pointer to a pointer variable into which the method writes the address of an instance of the requested interface. Through this
		/// method, the caller obtains a counted reference to the interface. The caller is responsible for releasing the interface, when it
		/// is no longer needed, by calling the interface's <c>Release</c> method. If the <c>GetService</c> call fails, *ppv is <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>The <c>GetService</c> method supports the following service interfaces:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IAudioCaptureClient</term>
		/// </item>
		/// <item>
		/// <term>IAudioClock</term>
		/// </item>
		/// <item>
		/// <term>IAudioRenderClient</term>
		/// </item>
		/// <item>
		/// <term>IAudioSessionControl</term>
		/// </item>
		/// <item>
		/// <term>IAudioStreamVolume</term>
		/// </item>
		/// <item>
		/// <term>IChannelAudioVolume</term>
		/// </item>
		/// <item>
		/// <term>IMFTrustedOutput</term>
		/// </item>
		/// <item>
		/// <term>ISimpleAudioVolume</term>
		/// </item>
		/// </list>
		/// <para>
		/// In Windows 7, a new service identifier, <c>IID_IMFTrustedOutput</c>, has been added that facilitates the use of output trust
		/// authority (OTA) objects. These objects can operate inside or outside the Media Foundation's protected media path (PMP) and send
		/// content outside the Media Foundation pipeline. If the caller is outside PMP, then the OTA may not operate in the PMP, and the
		/// protection settings are less robust. OTAs must implement the IMFTrustedOutput interface. By passing <c>IID_IMFTrustedOutput</c>
		/// in <c>GetService</c>, an application can retrieve a pointer to the object's <c>IMFTrustedOutput</c> interface. For more
		/// information about protected objects and <c>IMFTrustedOutput</c>, see "Protected Media Path" in the Media Foundation SDK documentation.
		/// </para>
		/// <para>For information about using trusted audio drivers in OTAs, see Protected User Mode Audio (PUMA).</para>
		/// <para>
		/// Note that activating IMFTrustedOutput through this mechanism works regardless of whether the caller is running in PMP. However,
		/// if the caller is not running in a protected process (that is, the caller is not within Media Foundation's PMP) then the audio OTA
		/// might not operate in the PMP and the protection settings are less robust.
		/// </para>
		/// <para>
		/// To obtain the interface ID for a service interface, use the <c>__uuidof</c> operator. For example, the interface ID of
		/// <c>IAudioCaptureClient</c> is defined as follows:
		/// </para>
		/// <para>For information about the <c>__uuidof</c> operator, see the Windows SDK documentation.</para>
		/// <para>
		/// To release the <c>IAudioClient</c> object and free all its associated resources, the client must release all references to any
		/// service objects that were created by calling <c>GetService</c>, in addition to calling <c>Release</c> on the <c>IAudioClient</c>
		/// interface itself. The client must release a service from the same thread that releases the <c>IAudioClient</c> object.
		/// </para>
		/// <para>
		/// The <c>IAudioSessionControl</c>, <c>IAudioStreamVolume</c>, <c>IChannelAudioVolume</c>, and <c>ISimpleAudioVolume</c> interfaces
		/// control and monitor aspects of audio sessions and shared-mode streams. These interfaces do not work with exclusive-mode streams.
		/// </para>
		/// <para>For code examples that call the <c>GetService</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getservice HRESULT GetService( REFIID
		// riid, void **ppv );
		[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)]
		new object GetService(in Guid riid);

		/// <summary>
		/// The <c>IsOffloadCapable</c> method retrieves information about whether or not the endpoint on which a stream is created is
		/// capable of supporting an offloaded audio stream.
		/// </summary>
		/// <param name="Category">An enumeration that specifies the category of an audio stream.</param>
		/// <returns>
		/// A pointer to a Boolean value. <c>TRUE</c> indicates that the endpoint is offload-capable. <c>FALSE</c> indicates that the
		/// endpoint is not offload-capable.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient2-isoffloadcapable HRESULT
		// IsOffloadCapable( AUDIO_STREAM_CATEGORY Category, BOOL *pbOffloadCapable );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsOffloadCapable(AUDIO_STREAM_CATEGORY Category);

		/// <summary>Sets the properties of the audio stream by populating an AudioClientProperties structure.</summary>
		/// <param name="pProperties">Pointer to an AudioClientProperties structure.</param>
		/// <remarks>
		/// Starting with Windows 10, hardware-offloaded audio streams must be event driven. This means that if you call
		/// <c>IAudioClient2::SetClientProperties</c> and set the bIsOffload parameter of the AudioClientProperties to TRUE, you must specify
		/// the <c>AUDCLNT_STREAMFLAGS_EVENTCALLBACK</c> flag in the StreamFlags parameter to IAudioClient::Initialize.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient2-setclientproperties HRESULT
		// SetClientProperties( const AudioClientProperties *pProperties );
		void SetClientProperties(in AudioClientProperties pProperties);

		/// <summary>
		/// The <c>GetBufferSizeLimits</c> method returns the buffer size limits of the hardware audio engine in 100-nanosecond units.
		/// </summary>
		/// <param name="pFormat">A pointer to the target format that is being queried for the buffer size limit.</param>
		/// <param name="bEventDriven">Boolean value to indicate whether or not the stream can be event-driven.</param>
		/// <param name="phnsMinBufferDuration">
		/// Returns a pointer to the minimum buffer size (in 100-nanosecond units) that is required for the underlying hardware audio engine
		/// to operate at the format specified in the pFormat parameter, without frequent audio glitching.
		/// </param>
		/// <param name="phnsMaxBufferDuration">
		/// Returns a pointer to the maximum buffer size (in 100-nanosecond units) that the underlying hardware audio engine can support for
		/// the format specified in the pFormat parameter.
		/// </param>
		/// <remarks>The <c>GetBufferSizeLimits</c> method is a device-facing method and does not require prior audio stream initialization.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient2-getbuffersizelimits HRESULT
		// GetBufferSizeLimits( const WAVEFORMATEX *pFormat, BOOL bEventDriven, REFERENCE_TIME *phnsMinBufferDuration, REFERENCE_TIME
		// *phnsMaxBufferDuration );
		void GetBufferSizeLimits([In] IntPtr pFormat, [MarshalAs(UnmanagedType.Bool)] bool bEventDriven, out long phnsMinBufferDuration, out long phnsMaxBufferDuration);
	}

	/// <summary>
	/// The <c>IAudioClient3</c> interface is derived from the IAudioClient2 interface, with a set of additional methods that enable a
	/// Windows Audio Session API (WASAPI) audio client to query for the audio engine's supported periodicities and current periodicity as
	/// well as request initialization a shared audio stream with a specified periodicity.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nn-audioclient-iaudioclient3
	[PInvokeData("audioclient.h", MSDNShortId = "E8EFE682-E1BC-4D0D-A60E-DD257D6E5894")]
	[ComImport, Guid("7ED4EE07-8E67-4CD4-8C1A-2B7A5987AD42"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioClient3 : IAudioClient2
	{
		/// <summary>The <c>Initialize</c> method initializes the audio stream.</summary>
		/// <param name="ShareMode">
		/// <para>
		/// The sharing mode for the connection. Through this parameter, the client tells the audio engine whether it wants to share the
		/// audio endpoint device with other clients. The client should set this parameter to one of the following AUDCLNT_SHAREMODE
		/// enumeration values:
		/// </para>
		/// <para>AUDCLNT_SHAREMODE_EXCLUSIVE</para>
		/// <para>AUDCLNT_SHAREMODE_SHARED</para>
		/// </param>
		/// <param name="StreamFlags">
		/// Flags to control creation of the stream. The client should set this parameter to 0 or to the bitwise OR of one or more of the
		/// AUDCLNT_STREAMFLAGS_XXX Constants or the AUDCLNT_SESSIONFLAGS_XXX Constants.
		/// </param>
		/// <param name="hnsBufferDuration">
		/// The buffer capacity as a time value. This parameter is of type <c>REFERENCE_TIME</c> and is expressed in 100-nanosecond units.
		/// This parameter contains the buffer size that the caller requests for the buffer that the audio application will share with the
		/// audio engine (in shared mode) or with the endpoint device (in exclusive mode). If the call succeeds, the method allocates a
		/// buffer that is a least this large. For more information about <c>REFERENCE_TIME</c>, see the Windows SDK documentation. For more
		/// information about buffering requirements, see Remarks.
		/// </param>
		/// <param name="hnsPeriodicity">
		/// The device period. This parameter can be nonzero only in exclusive mode. In shared mode, always set this parameter to 0. In
		/// exclusive mode, this parameter specifies the requested scheduling period for successive buffer accesses by the audio endpoint
		/// device. If the requested device period lies outside the range that is set by the device's minimum period and the system's maximum
		/// period, then the method clamps the period to that range. If this parameter is 0, the method sets the device period to its default
		/// value. To obtain the default device period, call the IAudioClient::GetDevicePeriod method. If the
		/// AUDCLNT_STREAMFLAGS_EVENTCALLBACK stream flag is set and AUDCLNT_SHAREMODE_EXCLUSIVE is set as the ShareMode, then hnsPeriodicity
		/// must be nonzero and equal to hnsBufferDuration.
		/// </param>
		/// <param name="pFormat">
		/// Pointer to a format descriptor. This parameter must point to a valid format descriptor of type <c>WAVEFORMATEX</c> (or
		/// <c>WAVEFORMATEXTENSIBLE</c>). For more information, see Remarks.
		/// </param>
		/// <param name="AudioSessionGuid">
		/// Pointer to a session GUID. This parameter points to a GUID value that identifies the audio session that the stream belongs to. If
		/// the GUID identifies a session that has been previously opened, the method adds the stream to that session. If the GUID does not
		/// identify an existing session, the method opens a new session and adds the stream to that session. The stream remains a member of
		/// the same session for its lifetime. Setting this parameter to <c>NULL</c> is equivalent to passing a pointer to a GUID_NULL value.
		/// </param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. If it fails, possible return codes include, but are not limited to, the values shown in
		/// the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>AUDCLNT_E_ALREADY_INITIALIZED</term>
		/// <term>The IAudioClient object is already initialized.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_WRONG_ENDPOINT_TYPE</term>
		/// <term>The AUDCLNT_STREAMFLAGS_LOOPBACK flag is set but the endpoint device is a capture device, not a rendering device.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED</term>
		/// <term>
		/// The requested buffer size is not aligned. This code can be returned for a render or a capture device if the caller specified
		/// AUDCLNT_SHAREMODE_EXCLUSIVE and the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flags. The caller must call Initialize again with the
		/// aligned buffer size. For more information, see Remarks.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_BUFFER_SIZE_ERROR</term>
		/// <term>
		/// Indicates that the buffer duration value requested by an exclusive-mode client is out of range. The requested duration value for
		/// pull mode must not be greater than 500 milliseconds; for push mode the duration value must not be greater than 2 seconds.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_CPUUSAGE_EXCEEDED</term>
		/// <term>
		/// Indicates that the process-pass duration exceeded the maximum CPU usage. The audio engine keeps track of CPU usage by maintaining
		/// the number of times the process-pass duration exceeds the maximum CPU usage. The maximum CPU usage is calculated as a percent of
		/// the engine's periodicity. The percentage value is the system's CPU throttle value (within the range of 10% and 90%). If this
		/// value is not found, then the default value of 40% is used to calculate the maximum CPU usage.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
		/// <term>
		/// The audio endpoint device has been unplugged, or the audio hardware or associated hardware resources have been reconfigured,
		/// disabled, removed, or otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_IN_USE</term>
		/// <term>
		/// The endpoint device is already in use. Either the device is being used in exclusive mode, or the device is being used in shared
		/// mode and the caller asked to use the device in exclusive mode.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_ENDPOINT_CREATE_FAILED</term>
		/// <term>
		/// The method failed to create the audio endpoint for the render or the capture device. This can occur if the audio endpoint device
		/// has been unplugged, or the audio hardware or associated hardware resources have been reconfigured, disabled, removed, or
		/// otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_INVALID_DEVICE_PERIOD</term>
		/// <term>Indicates that the device period requested by an exclusive-mode client is greater than 500 milliseconds.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_UNSUPPORTED_FORMAT</term>
		/// <term>The audio engine (shared mode) or audio endpoint device (exclusive mode) does not support the specified format.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_EXCLUSIVE_MODE_NOT_ALLOWED</term>
		/// <term>
		/// The caller is requesting exclusive-mode use of the endpoint device, but the user has disabled exclusive-mode use of the device.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_BUFDURATION_PERIOD_NOT_EQUAL</term>
		/// <term>The AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag is set but parameters hnsBufferDuration and hnsPeriodicity are not equal.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_SERVICE_NOT_RUNNING</term>
		/// <term>The Windows audio service is not running.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>Parameter pFormat is NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>
		/// Parameter pFormat points to an invalid format description; or the AUDCLNT_STREAMFLAGS_LOOPBACK flag is set but ShareMode is not
		/// equal to AUDCLNT_SHAREMODE_SHARED; or the AUDCLNT_STREAMFLAGS_CROSSPROCESS flag is set but ShareMode is equal to
		/// AUDCLNT_SHAREMODE_EXCLUSIVE. A prior call to SetClientProperties was made with an invalid category for audio/render streams.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Out of memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// After activating an IAudioClient interface on an audio endpoint device, the client must successfully call <c>Initialize</c> once
		/// and only once to initialize the audio stream between the client and the device. The client can either connect directly to the
		/// audio hardware (exclusive mode) or indirectly through the audio engine (shared mode). In the <c>Initialize</c> call, the client
		/// specifies the audio data format, the buffer size, and audio session for the stream.
		/// </para>
		/// <para>
		/// <c>Note</c> In Windows 8, the first use of IAudioClient to access the audio device should be on the STA thread. Calls from an MTA
		/// thread may result in undefined behavior.
		/// </para>
		/// <para>
		/// An attempt to create a shared-mode stream can succeed only if the audio device is already operating in shared mode or the device
		/// is currently unused. An attempt to create a shared-mode stream fails if the device is already operating in exclusive mode.
		/// </para>
		/// <para>
		/// If a stream is initialized to be event driven and in shared mode, ShareMode is set to AUDCLNT_SHAREMODE_SHARED and one of the
		/// stream flags that are set includes AUDCLNT_STREAMFLAGS_EVENTCALLBACK. For such a stream, the associated application must also
		/// obtain a handle by making a call to IAudioClient::SetEventHandle. When it is time to retire the stream, the audio engine can then
		/// use the handle to release the stream objects. Failure to call <c>IAudioClient::SetEventHandle</c> before releasing the stream
		/// objects can cause a delay of several seconds (a time-out period) while the audio engine waits for an available handle. After the
		/// time-out period expires, the audio engine then releases the stream objects.
		/// </para>
		/// <para>
		/// Whether an attempt to create an exclusive-mode stream succeeds depends on several factors, including the availability of the
		/// device and the user-controlled settings that govern exclusive-mode operation of the device. For more information, see
		/// Exclusive-Mode Streams.
		/// </para>
		/// <para>
		/// An <c>IAudioClient</c> object supports exactly one connection to the audio engine or audio hardware. This connection lasts for
		/// the lifetime of the <c>IAudioClient</c> object.
		/// </para>
		/// <para>The client should call the following methods only after calling <c>Initialize</c>:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IAudioClient::GetBufferSize</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::GetCurrentPadding</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::GetService</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::GetStreamLatency</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::Reset</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::SetEventHandle</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::Start</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::Stop</term>
		/// </item>
		/// </list>
		/// <para>The following methods do not require that <c>Initialize</c> be called first:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IAudioClient::GetDevicePeriod</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::GetMixFormat</term>
		/// </item>
		/// <item>
		/// <term>IAudioClient::IsFormatSupported</term>
		/// </item>
		/// </list>
		/// <para>These methods can be called any time after activating the <c>IAudioClient</c> interface.</para>
		/// <para>
		/// Before calling <c>Initialize</c> to set up a shared-mode or exclusive-mode connection, the client can call the
		/// IAudioClient::IsFormatSupported method to discover whether the audio engine or audio endpoint device supports a particular format
		/// in that mode. Before opening a shared-mode connection, the client can obtain the audio engine's mix format by calling the
		/// IAudioClient::GetMixFormat method.
		/// </para>
		/// <para>
		/// The endpoint buffer that is shared between the client and audio engine must be large enough to prevent glitches from occurring in
		/// the audio stream between processing passes by the client and audio engine. For a rendering endpoint, the client thread
		/// periodically writes data to the buffer, and the audio engine thread periodically reads data from the buffer. For a capture
		/// endpoint, the engine thread periodically writes to the buffer, and the client thread periodically reads from the buffer. In
		/// either case, if the periods of the client thread and engine thread are not equal, the buffer must be large enough to accommodate
		/// the longer of the two periods without allowing glitches to occur.
		/// </para>
		/// <para>
		/// The client specifies a buffer size through the hnsBufferDuration parameter. The client is responsible for requesting a buffer
		/// that is large enough to ensure that glitches cannot occur between the periodic processing passes that it performs on the buffer.
		/// Similarly, the <c>Initialize</c> method ensures that the buffer is never smaller than the minimum buffer size needed to ensure
		/// that glitches do not occur between the periodic processing passes that the engine thread performs on the buffer. If the client
		/// requests a buffer size that is smaller than the audio engine's minimum required buffer size, the method sets the buffer size to
		/// this minimum buffer size rather than to the buffer size requested by the client.
		/// </para>
		/// <para>
		/// If the client requests a buffer size (through the hnsBufferDuration parameter) that is not an integral number of audio frames,
		/// the method rounds up the requested buffer size to the next integral number of frames.
		/// </para>
		/// <para>
		/// Following the <c>Initialize</c> call, the client should call the IAudioClient::GetBufferSize method to get the precise size of
		/// the endpoint buffer. During each processing pass, the client will need the actual buffer size to calculate how much data to
		/// transfer to or from the buffer. The client calls the IAudioClient::GetCurrentPadding method to determine how much of the data in
		/// the buffer is currently available for processing.
		/// </para>
		/// <para>
		/// To achieve the minimum stream latency between the client application and audio endpoint device, the client thread should run at
		/// the same period as the audio engine thread. The period of the engine thread is fixed and cannot be controlled by the client.
		/// Making the client's period smaller than the engine's period unnecessarily increases the client thread's load on the processor
		/// without improving latency or decreasing the buffer size. To determine the period of the engine thread, the client can call the
		/// IAudioClient::GetDevicePeriod method. To set the buffer to the minimum size required by the engine thread, the client should call
		/// <c>Initialize</c> with the hnsBufferDuration parameter set to 0. Following the <c>Initialize</c> call, the client can get the
		/// size of the resulting buffer by calling <c>IAudioClient::GetBufferSize</c>.
		/// </para>
		/// <para>
		/// A client has the option of requesting a buffer size that is larger than what is strictly necessary to make timing glitches rare
		/// or nonexistent. Increasing the buffer size does not necessarily increase the stream latency. For a rendering stream, the latency
		/// through the buffer is determined solely by the separation between the client's write pointer and the engine's read pointer. For a
		/// capture stream, the latency through the buffer is determined solely by the separation between the engine's write pointer and the
		/// client's read pointer.
		/// </para>
		/// <para>
		/// The loopback flag (AUDCLNT_STREAMFLAGS_LOOPBACK) enables audio loopback. A client can enable audio loopback only on a rendering
		/// endpoint with a shared-mode stream. Audio loopback is provided primarily to support acoustic echo cancellation (AEC).
		/// </para>
		/// <para>
		/// An AEC client requires both a rendering endpoint and the ability to capture the output stream from the audio engine. The engine's
		/// output stream is the global mix that the audio device plays through the speakers. If audio loopback is enabled, a client can open
		/// a capture buffer for the global audio mix by calling the IAudioClient::GetService method to obtain an IAudioCaptureClient
		/// interface on the rendering stream object. If audio loopback is not enabled, then an attempt to open a capture buffer on a
		/// rendering stream will fail. The loopback data in the capture buffer is in the device format, which the client can obtain by
		/// querying the device's PKEY_AudioEngine_DeviceFormat property.
		/// </para>
		/// <para>
		/// On Windows versions prior to Windows 10, a pull-mode capture client will not receive any events when a stream is initialized with
		/// event-driven buffering (AUDCLNT_STREAMFLAGS_EVENTCALLBACK) and is loopback-enabled (AUDCLNT_STREAMFLAGS_LOOPBACK). If the stream
		/// is opened with this configuration, the <c>Initialize</c> call succeeds, but relevant events are not raised to notify the capture
		/// client each time a buffer becomes ready for processing. To work around this, initialize a render stream in event-driven mode.
		/// Each time the client receives an event for the render stream, it must signal the capture client to run the capture thread that
		/// reads the next set of samples from the capture endpoint buffer. As of Windows 10 the relevant event handles are now set for
		/// loopback-enabled streams that are active.
		/// </para>
		/// <para>
		/// Note that all streams must be opened in share mode because exclusive-mode streams cannot operate in loopback mode. For more
		/// information about audio loopback, see Loopback Recording.
		/// </para>
		/// <para>
		/// The AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag indicates that processing of the audio buffer by the client will be event driven.
		/// WASAPI supports event-driven buffering to enable low-latency processing of both shared-mode and exclusive-mode streams.
		/// </para>
		/// <para>
		/// The initial release of Windows Vista supports event-driven buffering (that is, the use of the AUDCLNT_STREAMFLAGS_EVENTCALLBACK
		/// flag) for rendering streams only.
		/// </para>
		/// <para>
		/// In the initial release of Windows Vista, for capture streams, the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag is supported only in
		/// shared mode. Setting this flag has no effect for exclusive-mode capture streams. That is, although the application specifies this
		/// flag in exclusive mode through the <c>Initialize</c> call, the application will not receive any events that are usually required
		/// to capture the audio stream. In the Windows Vista Service Pack 1 release, this flag is functional in shared-mode and exclusive
		/// mode; an application can set this flag to enable event-buffering for capture streams. For more information about capturing an
		/// audio stream, see Capturing a Stream.
		/// </para>
		/// <para>
		/// To enable event-driven buffering, the client must provide an event handle to the system. Following the <c>Initialize</c> call and
		/// before calling the IAudioClient::Start method to start the stream, the client must call the IAudioClient::SetEventHandle method
		/// to set the event handle. While the stream is running, the system periodically signals the event to indicate to the client that
		/// audio data is available for processing. Between processing passes, the client thread waits on the event handle by calling a
		/// synchronization function such as <c>WaitForSingleObject</c>. For more information about synchronization functions, see the
		/// Windows SDK documentation.
		/// </para>
		/// <para>
		/// For a shared-mode stream that uses event-driven buffering, the caller must set both hnsPeriodicity and hnsBufferDuration to
		/// 0. The <c>Initialize</c> method determines how large a buffer to allocate based on the scheduling period of the audio engine.
		/// Although the client's buffer processing thread is event driven, the basic buffer management process, as described previously, is
		/// unaltered. Each time the thread awakens, it should call IAudioClient::GetCurrentPadding to determine how much data to write to a
		/// rendering buffer or read from a capture buffer. In contrast to the two buffers that the <c>Initialize</c> method allocates for an
		/// exclusive-mode stream that uses event-driven buffering, a shared-mode stream requires a single buffer.
		/// </para>
		/// <para>
		/// For an exclusive-mode stream that uses event-driven buffering, the caller must specify nonzero values for hnsPeriodicity and
		/// hnsBufferDuration, and the values of these two parameters must be equal. The <c>Initialize</c> method allocates two buffers for
		/// the stream. Each buffer is equal in duration to the value of the hnsBufferDuration parameter. Following the <c>Initialize</c>
		/// call for a rendering stream, the caller should fill the first of the two buffers before starting the stream. For a capture
		/// stream, the buffers are initially empty, and the caller should assume that each buffer remains empty until the event for that
		/// buffer is signaled. While the stream is running, the system alternately sends one buffer or the other to the client—this form of
		/// double buffering is referred to as "ping-ponging". Each time the client receives a buffer from the system (which the system
		/// indicates by signaling the event), the client must process the entire buffer. For example, if the client requests a packet size
		/// from the IAudioRenderClient::GetBuffer method that does not match the buffer size, the method fails. Calls to the
		/// <c>IAudioClient::GetCurrentPadding</c> method are unnecessary because the packet size must always equal the buffer size. In
		/// contrast to the buffering modes discussed previously, the latency for an event-driven, exclusive-mode stream depends directly on
		/// the buffer size.
		/// </para>
		/// <para>
		/// As explained in Audio Sessions, the default behavior for a session that contains rendering streams is that its volume and mute
		/// settings persist across system restarts. The AUDCLNT_STREAMFLAGS_NOPERSIST flag overrides the default behavior and makes the
		/// settings nonpersistent. This flag has no effect on sessions that contain capture streams—the settings for those sessions are
		/// never persistent. In addition, the settings for a session that contains a loopback stream (a stream that is initialized with the
		/// AUDCLNT_STREAMFLAGS_LOOPBACK flag) are not persistent.
		/// </para>
		/// <para>
		/// Only a session that connects to a rendering endpoint device can have persistent volume and mute settings. The first stream to be
		/// added to the session determines whether the session's settings are persistent. Thus, if the AUDCLNT_STREAMFLAGS_NOPERSIST or
		/// AUDCLNT_STREAMFLAGS_LOOPBACK flag is set during initialization of the first stream, the session's settings are not persistent.
		/// Otherwise, they are persistent. Their persistence is unaffected by additional streams that might be subsequently added or removed
		/// during the lifetime of the session object.
		/// </para>
		/// <para>
		/// After a call to <c>Initialize</c> has successfully initialized an <c>IAudioClient</c> interface instance, a subsequent
		/// <c>Initialize</c> call to initialize the same interface instance will fail and return error code E_ALREADY_INITIALIZED.
		/// </para>
		/// <para>
		/// If the initial call to <c>Initialize</c> fails, subsequent <c>Initialize</c> calls might fail and return error code
		/// E_ALREADY_INITIALIZED, even though the interface has not been initialized. If this occurs, release the <c>IAudioClient</c>
		/// interface and obtain a new <c>IAudioClient</c> interface from the MMDevice API before calling <c>Initialize</c> again.
		/// </para>
		/// <para>For code examples that call the <c>Initialize</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// <item>
		/// <term>Exclusive-Mode Streams</term>
		/// </item>
		/// </list>
		/// <para>
		/// Starting with Windows 7, <c>Initialize</c> can return AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED for a render or a capture device. This
		/// indicates that the buffer size, specified by the caller in the hnsBufferDuration parameter, is not aligned. This error code is
		/// returned only if the caller requested an exclusive-mode stream (AUDCLNT_SHAREMODE_EXCLUSIVE) and event-driven buffering (AUDCLNT_STREAMFLAGS_EVENTCALLBACK).
		/// </para>
		/// <para>
		/// If <c>Initialize</c> returns AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED, the caller must call <c>Initialize</c> again and specify the
		/// aligned buffer size. Use the following steps:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Call IAudioClient::GetBufferSize and receive the next-highest-aligned buffer size (in frames).</term>
		/// </item>
		/// <item>
		/// <term>Call <c>IAudioClient::Release</c> to release the audio client used in the previous call that returned AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Calculate the aligned buffer size in 100-nansecond units (hns). The buffer size is . In this formula, is the buffer size
		/// retrieved by GetBufferSize.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Call the IMMDevice::Activate method with parameter iid set to REFIID IID_IAudioClient to create a new audio client.</term>
		/// </item>
		/// <item>
		/// <term>Call <c>Initialize</c> again on the created audio client and specify the new buffer size and periodicity.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Starting with Windows 10, hardware-offloaded audio streams must be event driven. This means that if you call
		/// IAudioClient2::SetClientProperties and set the bIsOffload parameter of the AudioClientProperties to TRUE, you must specify the
		/// <c>AUDCLNT_STREAMFLAGS_EVENTCALLBACK</c> flag in the StreamFlags parameter to <c>IAudioClient::Initialize</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example code shows how to respond to the <c>AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED</c> return code.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-initialize HRESULT Initialize(
		// AUDCLNT_SHAREMODE ShareMode, DWORD StreamFlags, REFERENCE_TIME hnsBufferDuration, REFERENCE_TIME hnsPeriodicity, const
		// WAVEFORMATEX *pFormat, LPCGUID AudioSessionGuid );
		[PreserveSig]
		new HRESULT Initialize([In] AUDCLNT_SHAREMODE ShareMode, AUDCLNT_STREAMFLAGS StreamFlags, long hnsBufferDuration, long hnsPeriodicity, [In] IntPtr pFormat, [In, Optional] in Guid AudioSessionGuid);

		/// <summary>The <c>GetBufferSize</c> method retrieves the size (maximum capacity) of the endpoint buffer.</summary>
		/// <returns>Pointer to a <c>UINT32</c> variable into which the method writes the number of audio frames that the buffer can hold.</returns>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// This method retrieves the length of the endpoint buffer shared between the client application and the audio engine. The length is
		/// expressed as the number of audio frames the buffer can hold. The size in bytes of an audio frame is calculated as the number of
		/// channels in the stream multiplied by the sample size per channel. For example, the frame size is four bytes for a stereo
		/// (2-channel) stream with 16-bit samples.
		/// </para>
		/// <para>
		/// The IAudioClient::Initialize method allocates the buffer. The client specifies the buffer length in the hnsBufferDuration
		/// parameter value that it passes to the <c>Initialize</c> method. For rendering clients, the buffer length determines the maximum
		/// amount of rendering data that the application can write to the endpoint buffer during a single processing pass. For capture
		/// clients, the buffer length determines the maximum amount of capture data that the audio engine can read from the endpoint buffer
		/// during a single processing pass. The client should always call <c>GetBufferSize</c> after calling <c>Initialize</c> to determine
		/// the actual size of the allocated buffer, which might differ from the requested size.
		/// </para>
		/// <para>
		/// Rendering clients can use this value to calculate the largest rendering buffer size that can be requested from
		/// IAudioRenderClient::GetBuffer during each processing pass.
		/// </para>
		/// <para>For code examples that call the <c>GetBufferSize</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getbuffersize HRESULT GetBufferSize(
		// UINT32 *pNumBufferFrames );
		new uint GetBufferSize();

		/// <summary>
		/// The <c>GetStreamLatency</c> method retrieves the maximum latency for the current stream and can be called any time after the
		/// stream has been initialized.
		/// </summary>
		/// <returns>
		/// Pointer to a REFERENCE_TIME variable into which the method writes a time value representing the latency. The time is expressed in
		/// 100-nanosecond units. For more information about <c>REFERENCE_TIME</c>, see the Windows SDK documentation.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// This method retrieves the maximum latency for the current stream. The value will not change for the lifetime of the IAudioClient object.
		/// </para>
		/// <para>
		/// Rendering clients can use this latency value to compute the minimum amount of data that they can write during any single
		/// processing pass. To write less than this minimum is to risk introducing glitches into the audio stream. For more information, see IAudioRenderClient::GetBuffer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getstreamlatency HRESULT
		// GetStreamLatency( REFERENCE_TIME *phnsLatency );
		new long GetStreamLatency();

		/// <summary>The <c>GetCurrentPadding</c> method retrieves the number of frames of padding in the endpoint buffer.</summary>
		/// <returns>
		/// Pointer to a <c>UINT32</c> variable into which the method writes the frame count (the number of audio frames of padding in the buffer).
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// This method retrieves a padding value that indicates the amount of valid, unread data that the endpoint buffer currently
		/// contains. A rendering application can use the padding value to determine how much new data it can safely write to the endpoint
		/// buffer without overwriting previously written data that the audio engine has not yet read from the buffer. A capture application
		/// can use the padding value to determine how much new data it can safely read from the endpoint buffer without reading invalid data
		/// from a region of the buffer to which the audio engine has not yet written valid data.
		/// </para>
		/// <para>
		/// The padding value is expressed as a number of audio frames. The size of an audio frame is specified by the <c>nBlockAlign</c>
		/// member of the WAVEFORMATEX (or WAVEFORMATEXTENSIBLE) structure that the client passed to the IAudioClient::Initialize method. The
		/// size in bytes of an audio frame equals the number of channels in the stream multiplied by the sample size per channel. For
		/// example, the frame size is four bytes for a stereo (2-channel) stream with 16-bit samples.
		/// </para>
		/// <para>
		/// For a shared-mode rendering stream, the padding value reported by <c>GetCurrentPadding</c> specifies the number of audio frames
		/// that are queued up to play in the endpoint buffer. Before writing to the endpoint buffer, the client can calculate the amount of
		/// available space in the buffer by subtracting the padding value from the buffer length. To ensure that a subsequent call to the
		/// IAudioRenderClient::GetBuffer method succeeds, the client should request a packet length that does not exceed the available space
		/// in the buffer. To obtain the buffer length, call the IAudioClient::GetBufferSize method.
		/// </para>
		/// <para>
		/// For a shared-mode capture stream, the padding value reported by <c>GetCurrentPadding</c> specifies the number of frames of
		/// capture data that are available in the next packet in the endpoint buffer. At a particular moment, zero, one, or more packets of
		/// capture data might be ready for the client to read from the buffer. If no packets are currently available, the method reports a
		/// padding value of 0. Following the <c>GetCurrentPadding</c> call, an IAudioCaptureClient::GetBuffer method call will retrieve a
		/// packet whose length exactly equals the padding value reported by <c>GetCurrentPadding</c>. Each call to GetBuffer retrieves a
		/// whole packet. A packet always contains an integral number of audio frames.
		/// </para>
		/// <para>
		/// For a shared-mode capture stream, calling <c>GetCurrentPadding</c> is equivalent to calling the
		/// IAudioCaptureClient::GetNextPacketSize method. That is, the padding value reported by <c>GetCurrentPadding</c> is equal to the
		/// packet length reported by <c>GetNextPacketSize</c>.
		/// </para>
		/// <para>
		/// For an exclusive-mode rendering or capture stream that was initialized with the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag, the
		/// client typically has no use for the padding value reported by <c>GetCurrentPadding</c>. Instead, the client accesses an entire
		/// buffer during each processing pass. Each time a buffer becomes available for processing, the audio engine notifies the client by
		/// signaling the client's event handle. For more information about this flag, see IAudioClient::Initialize.
		/// </para>
		/// <para>
		/// For an exclusive-mode rendering or capture stream that was not initialized with the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag, the
		/// client can use the padding value obtained from <c>GetCurrentPadding</c> in a way that is similar to that described previously for
		/// a shared-mode stream. The details are as follows.
		/// </para>
		/// <para>
		/// First, for an exclusive-mode rendering stream, the padding value specifies the number of audio frames that are queued up to play
		/// in the endpoint buffer. As before, the client can calculate the amount of available space in the buffer by subtracting the
		/// padding value from the buffer length.
		/// </para>
		/// <para>
		/// Second, for an exclusive-mode capture stream, the padding value reported by <c>GetCurrentPadding</c> specifies the current length
		/// of the next packet. However, this padding value is a snapshot of the packet length, which might increase before the client calls
		/// the IAudioCaptureClient::GetBuffer method. Thus, the length of the packet retrieved by <c>GetBuffer</c> is at least as large as,
		/// but might be larger than, the padding value reported by the <c>GetCurrentPadding</c> call that preceded the <c>GetBuffer</c>
		/// call. In contrast, for a shared-mode capture stream, the length of the packet obtained from <c>GetBuffer</c> always equals the
		/// padding value reported by the preceding <c>GetCurrentPadding</c> call.
		/// </para>
		/// <para>For a code example that calls the <c>GetCurrentPadding</c> method, see Rendering a Stream.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getcurrentpadding HRESULT
		// GetCurrentPadding( UINT32 *pNumPaddingFrames );
		new uint GetCurrentPadding();

		/// <summary>The <c>IsFormatSupported</c> method indicates whether the audio endpoint device supports a particular stream format.</summary>
		/// <param name="ShareMode">
		/// <para>
		/// The sharing mode for the stream format. Through this parameter, the client indicates whether it wants to use the specified format
		/// in exclusive mode or shared mode. The client should set this parameter to one of the following AUDCLNT_SHAREMODE enumeration values:
		/// </para>
		/// <para>AUDCLNT_SHAREMODE_EXCLUSIVE</para>
		/// <para>AUDCLNT_SHAREMODE_SHARED</para>
		/// </param>
		/// <param name="pFormat">
		/// Pointer to the specified stream format. This parameter points to a caller-allocated format descriptor of type <c>WAVEFORMATEX</c>
		/// or <c>WAVEFORMATEXTENSIBLE</c>. The client writes a format description to this structure before calling this method. For
		/// information about <c>WAVEFORMATEX</c> and <c>WAVEFORMATEXTENSIBLE</c>, see the Windows DDK documentation.
		/// </param>
		/// <param name="ppClosestMatch">
		/// Pointer to a pointer variable into which the method writes the address of a <c>WAVEFORMATEX</c> or <c>WAVEFORMATEXTENSIBLE</c>
		/// structure. This structure specifies the supported format that is closest to the format that the client specified through the
		/// pFormat parameter. For shared mode (that is, if the ShareMode parameter is AUDCLNT_SHAREMODE_SHARED), set ppClosestMatch to point
		/// to a valid, non- <c>NULL</c> pointer variable. For exclusive mode, set ppClosestMatch to <c>NULL</c>. The method allocates the
		/// storage for the structure. The caller is responsible for freeing the storage, when it is no longer needed, by calling the
		/// <c>CoTaskMemFree</c> function. If the <c>IsFormatSupported</c> call fails and ppClosestMatch is non- <c>NULL</c>, the method sets
		/// *ppClosestMatch to <c>NULL</c>. For information about <c>CoTaskMemFree</c>, see the Windows SDK documentation.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Succeeded and the audio endpoint device supports the specified stream format.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>Succeeded with a closest match to the specified format.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_UNSUPPORTED_FORMAT</term>
		/// <term>Succeeded but the specified format is not supported in exclusive mode.</term>
		/// </item>
		/// </list>
		/// <para>If the operation fails, possible return codes include, but are not limited to, the values shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>Parameter pFormat is NULL, or ppClosestMatch is NULL and ShareMode is AUDCLNT_SHAREMODE_SHARED.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>Parameter ShareMode is a value other than AUDCLNT_SHAREMODE_SHARED or AUDCLNT_SHAREMODE_EXCLUSIVE.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
		/// <term>
		/// The audio endpoint device has been unplugged, or the audio hardware or associated hardware resources have been reconfigured,
		/// disabled, removed, or otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_SERVICE_NOT_RUNNING</term>
		/// <term>The Windows audio service is not running.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method provides a way for a client to determine, before calling IAudioClient::Initialize, whether the audio engine supports
		/// a particular stream format.
		/// </para>
		/// <para>
		/// For exclusive mode, <c>IsFormatSupported</c> returns S_OK if the audio endpoint device supports the caller-specified format, or
		/// it returns AUDCLNT_E_UNSUPPORTED_FORMAT if the device does not support the format. The ppClosestMatch parameter can be
		/// <c>NULL</c>. If it is not <c>NULL</c>, the method writes <c>NULL</c> to *ppClosestMatch.
		/// </para>
		/// <para>
		/// For shared mode, if the audio engine supports the caller-specified format, <c>IsFormatSupported</c> sets <c>*ppClosestMatch</c>
		/// to <c>NULL</c> and returns S_OK. If the audio engine does not support the caller-specified format but does support a similar
		/// format, the method retrieves the similar format through the ppClosestMatch parameter and returns S_FALSE. If the audio engine
		/// does not support the caller-specified format or any similar format, the method sets
		/// *ppClosestMatch to <c>NULL</c> and returns AUDCLNT_E_UNSUPPORTED_FORMAT.
		/// </para>
		/// <para>
		/// In shared mode, the audio engine always supports the mix format, which the client can obtain by calling the
		/// IAudioClient::GetMixFormat method. In addition, the audio engine might support similar formats that have the same sample rate and
		/// number of channels as the mix format but differ in the representation of audio sample values. The audio engine represents sample
		/// values internally as floating-point numbers, but if the caller-specified format represents sample values as integers, the audio
		/// engine typically can convert between the integer sample values and its internal floating-point representation.
		/// </para>
		/// <para>
		/// The audio engine might be able to support an even wider range of shared-mode formats if the installation package for the audio
		/// device includes a local effects (LFX) audio processing object (APO) that can handle format conversions. An LFX APO is a software
		/// module that performs device-specific processing of an audio stream. The audio graph builder in the Windows audio service inserts
		/// the LFX APO into the stream between each client and the audio engine. When a client calls the <c>IsFormatSupported</c> method and
		/// the method determines that an LFX APO is installed for use with the device, the method directs the query to the LFX APO, which
		/// indicates whether it supports the caller-specified format.
		/// </para>
		/// <para>
		/// For example, a particular LFX APO might accept a 6-channel surround sound stream from a client and convert the stream to a stereo
		/// format that can be played through headphones. Typically, an LFX APO supports only client formats with sample rates that match the
		/// sample rate of the mix format.
		/// </para>
		/// <para>
		/// For more information about APOs, see the white papers titled "Custom Audio Effects in Windows Vista" and "Reusing the Windows
		/// Vista Audio System Effects" at the Audio Device Technologies for Windows website. For more information about the
		/// <c>IsFormatSupported</c> method, see Device Formats.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-isformatsupported HRESULT
		// IsFormatSupported( AUDCLNT_SHAREMODE ShareMode, const WAVEFORMATEX *pFormat, WAVEFORMATEX **ppClosestMatch );
		[PreserveSig]
		new HRESULT IsFormatSupported([In] AUDCLNT_SHAREMODE ShareMode, [In] IntPtr pFormat, out SafeCoTaskMemHandle ppClosestMatch);

		/// <summary>
		/// The <c>GetMixFormat</c> method retrieves the stream format that the audio engine uses for its internal processing of shared-mode streams.
		/// </summary>
		/// <param name="ppDeviceFormat">
		/// Pointer to a pointer variable into which the method writes the address of the mix format. This parameter must be a valid, non-
		/// <c>NULL</c> pointer to a pointer variable. The method writes the address of a <c>WAVEFORMATEX</c> (or
		/// <c>WAVEFORMATEXTENSIBLE</c>) structure to this variable. The method allocates the storage for the structure. The caller is
		/// responsible for freeing the storage, when it is no longer needed, by calling the <c>CoTaskMemFree</c> function. If the
		/// <c>GetMixFormat</c> call fails, *ppDeviceFormat is <c>NULL</c>. For information about <c>WAVEFORMATEX</c>,
		/// <c>WAVEFORMATEXTENSIBLE</c>, and <c>CoTaskMemFree</c>, see the Windows SDK documentation.
		/// </param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. If it fails, possible return codes include, but are not limited to, the values shown in
		/// the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
		/// <term>
		/// The audio endpoint device has been unplugged, or the audio hardware or associated hardware resources have been reconfigured,
		/// disabled, removed, or otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_SERVICE_NOT_RUNNING</term>
		/// <term>The Windows audio service is not running.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>Parameter ppDeviceFormat is NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Out of memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The client can call this method before calling the IAudioClient::Initialize method. When creating a shared-mode stream for an
		/// audio endpoint device, the <c>Initialize</c> method always accepts the stream format obtained from a <c>GetMixFormat</c> call on
		/// the same device.
		/// </para>
		/// <para>
		/// The mix format is the format that the audio engine uses internally for digital processing of shared-mode streams. This format is
		/// not necessarily a format that the audio endpoint device supports. Thus, the caller might not succeed in creating an
		/// exclusive-mode stream with a format obtained by calling <c>GetMixFormat</c>.
		/// </para>
		/// <para>
		/// For example, to facilitate digital audio processing, the audio engine might use a mix format that represents samples as
		/// floating-point values. If the device supports only integer PCM samples, then the engine converts the samples to or from integer
		/// PCM values at the connection between the device and the engine. However, to avoid resampling, the engine might use a mix format
		/// with a sample rate that the device supports.
		/// </para>
		/// <para>
		/// To determine whether the <c>Initialize</c> method can create a shared-mode or exclusive-mode stream with a particular format,
		/// call the IAudioClient::IsFormatSupported method.
		/// </para>
		/// <para>
		/// By itself, a <c>WAVEFORMATEX</c> structure cannot specify the mapping of channels to speaker positions. In addition, although
		/// <c>WAVEFORMATEX</c> specifies the size of the container for each audio sample, it cannot specify the number of bits of precision
		/// in a sample (for example, 20 bits of precision in a 24-bit container). However, the <c>WAVEFORMATEXTENSIBLE</c> structure can
		/// specify both the mapping of channels to speakers and the number of bits of precision in each sample. For this reason, the
		/// <c>GetMixFormat</c> method retrieves a format descriptor that is in the form of a <c>WAVEFORMATEXTENSIBLE</c> structure instead
		/// of a standalone <c>WAVEFORMATEX</c> structure. Through the ppDeviceFormat parameter, the method outputs a pointer to the
		/// <c>WAVEFORMATEX</c> structure that is embedded at the start of this <c>WAVEFORMATEXTENSIBLE</c> structure. For more information
		/// about <c>WAVEFORMATEX</c> and <c>WAVEFORMATEXTENSIBLE</c>, see the Windows DDK documentation.
		/// </para>
		/// <para>
		/// For more information about the <c>GetMixFormat</c> method, see Device Formats. For code examples that call <c>GetMixFormat</c>,
		/// see the following topics:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getmixformat HRESULT GetMixFormat(
		// WAVEFORMATEX **ppDeviceFormat );
		[PreserveSig]
		new HRESULT GetMixFormat(out SafeCoTaskMemHandle ppDeviceFormat);

		/// <summary>
		/// The <c>GetDevicePeriod</c> method retrieves the length of the periodic interval separating successive processing passes by the
		/// audio engine on the data in the endpoint buffer.
		/// </summary>
		/// <param name="phnsDefaultDevicePeriod">
		/// Pointer to a REFERENCE_TIME variable into which the method writes a time value specifying the default interval between periodic
		/// processing passes by the audio engine. The time is expressed in 100-nanosecond units. For information about
		/// <c>REFERENCE_TIME</c>, see the Windows SDK documentation.
		/// </param>
		/// <param name="phnsMinimumDevicePeriod">
		/// Pointer to a REFERENCE_TIME variable into which the method writes a time value specifying the minimum interval between periodic
		/// processing passes by the audio endpoint device. The time is expressed in 100-nanosecond units.
		/// </param>
		/// <remarks>
		/// <para>The client can call this method before calling the IAudioClient::Initialize method.</para>
		/// <para>
		/// The phnsDefaultDevicePeriod parameter specifies the default scheduling period for a shared-mode stream. The
		/// phnsMinimumDevicePeriod parameter specifies the minimum scheduling period for an exclusive-mode stream.
		/// </para>
		/// <para>
		/// At least one of the two parameters, phnsDefaultDevicePeriod and phnsMinimumDevicePeriod, must be non- <c>NULL</c> or the method
		/// returns immediately with error code E_POINTER. If both parameters are non- <c>NULL</c>, then the method outputs both the default
		/// and minimum periods.
		/// </para>
		/// <para>
		/// For a shared-mode stream, the audio engine periodically processes the data in the endpoint buffer, which the engine shares with
		/// the client application. The engine schedules itself to perform these processing passes at regular intervals.
		/// </para>
		/// <para>
		/// The period between processing passes by the audio engine is fixed for a particular audio endpoint device and represents the
		/// smallest processing quantum for the audio engine. This period plus the stream latency between the buffer and endpoint device
		/// represents the minimum possible latency that an audio application can achieve.
		/// </para>
		/// <para>
		/// The client has the option of scheduling its periodic processing thread to run at the same time interval as the audio engine. In
		/// this way, the client can achieve the smallest possible latency for a shared-mode stream. However, in an application for which
		/// latency is less important, the client can reduce the process-switching overhead on the CPU by scheduling its processing passes to
		/// occur less frequently. In this case, the endpoint buffer must be proportionally larger to compensate for the longer period
		/// between processing passes.
		/// </para>
		/// <para>
		/// The client determines the buffer size during its call to the IAudioClient::Initialize method. For a shared-mode stream, if the
		/// client passes this method an hnsBufferDuration parameter value of 0, the method assumes that the periods for the client and audio
		/// engine are guaranteed to be equal, and the method will allocate a buffer small enough to achieve the minimum possible latency.
		/// (In fact, any hnsBufferDuration value between 0 and the sum of the audio engine's period and device latency will have the same
		/// result.) Similarly, for an exclusive-mode stream, if the client sets hnsBufferDuration to 0, the method assumes that the period
		/// of the client is set to the minimum period of the audio endpoint device, and the method will allocate a buffer small enough to
		/// achieve the minimum possible latency.
		/// </para>
		/// <para>
		/// If the client chooses to run its periodic processing thread less often, at the cost of increased latency, it can do so as long as
		/// it creates an endpoint buffer during the IAudioClient::Initialize call that is sufficiently large.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getdeviceperiod HRESULT
		// GetDevicePeriod( REFERENCE_TIME *phnsDefaultDevicePeriod, REFERENCE_TIME *phnsMinimumDevicePeriod );
		new void GetDevicePeriod([Out, Optional] out long phnsDefaultDevicePeriod, out long phnsMinimumDevicePeriod);

		/// <summary>The <c>Start</c> method starts the audio stream.</summary>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// <c>Start</c> is a control method that the client calls to start the audio stream. Starting the stream causes the IAudioClient
		/// object to begin streaming data between the endpoint buffer and the audio engine. It also causes the stream's audio clock to
		/// resume counting from its current position.
		/// </para>
		/// <para>
		/// The first time this method is called following initialization of the stream, the IAudioClient object's stream position counter
		/// begins at 0. Otherwise, the clock resumes from its position at the time that the stream was last stopped. Resetting the stream
		/// forces the stream position back to 0.
		/// </para>
		/// <para>
		/// To avoid start-up glitches with rendering streams, clients should not call <c>Start</c> until the audio engine has been initially
		/// loaded with data by calling the IAudioRenderClient::GetBuffer and IAudioRenderClient::ReleaseBuffer methods on the rendering interface.
		/// </para>
		/// <para>For code examples that call the <c>Start</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-start HRESULT Start();
		new void Start();

		/// <summary>The <c>Stop</c> method stops the audio stream.</summary>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// <c>Stop</c> is a control method that stops a running audio stream. This method stops data from streaming through the client's
		/// connection with the audio engine. Stopping the stream freezes the stream's audio clock at its current stream position. A
		/// subsequent call to IAudioClient::Start causes the stream to resume running from that position. If necessary, the client can call
		/// the IAudioClient::Reset method to reset the position while the stream is stopped.
		/// </para>
		/// <para>For code examples that call the <c>Stop</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-stop HRESULT Stop();
		new void Stop();

		/// <summary>The <c>Reset</c> method resets the audio stream.</summary>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// <c>Reset</c> is a control method that the client calls to reset a stopped audio stream. Resetting the stream flushes all pending
		/// data and resets the audio clock stream position to 0. This method fails if it is called on a stream that is not stopped.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-reset HRESULT Reset();
		new void Reset();

		/// <summary>
		/// The <c>SetEventHandle</c> method sets the event handle that the system signals when an audio buffer is ready to be processed by
		/// the client.
		/// </summary>
		/// <param name="eventHandle">The event handle.</param>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>
		/// During stream initialization, the client can, as an option, enable event-driven buffering. To do so, the client calls the
		/// IAudioClient::Initialize method with the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag set. After enabling event-driven buffering, and
		/// before calling the IAudioClient::Start method to start the stream, the client must call <c>SetEventHandle</c> to register the
		/// event handle that the system will signal each time a buffer becomes ready to be processed by the client.
		/// </para>
		/// <para>The event handle should be in the nonsignaled state at the time that the client calls the Start method.</para>
		/// <para>
		/// If the client has enabled event-driven buffering of a stream, but the client calls the Start method for that stream without first
		/// calling <c>SetEventHandle</c>, the <c>Start</c> call will fail and return an error code.
		/// </para>
		/// <para>
		/// If the client does not enable event-driven buffering of a stream but attempts to set an event handle for the stream by calling
		/// <c>SetEventHandle</c>, the call will fail and return an error code.
		/// </para>
		/// <para>For a code example that calls the <c>SetEventHandle</c> method, see Exclusive-Mode Streams.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-seteventhandle HRESULT SetEventHandle(
		// HANDLE eventHandle );
		new void SetEventHandle(HEVENT eventHandle);

		/// <summary>The <c>GetService</c> method accesses additional services from the audio client object.</summary>
		/// <param name="riid">
		/// <para>The interface ID for the requested service. The client should set this parameter to one of the following REFIID values:</para>
		/// <para>IID_IAudioCaptureClient</para>
		/// <para>IID_IAudioClock</para>
		/// <para>IID_IAudioRenderClient</para>
		/// <para>IID_IAudioSessionControl</para>
		/// <para>IID_IAudioStreamVolume</para>
		/// <para>IID_IChannelAudioVolume</para>
		/// <para>IID_IMFTrustedOutput</para>
		/// <para>IID_ISimpleAudioVolume</para>
		/// <para>For more information, see Remarks.</para>
		/// </param>
		/// <returns>
		/// Pointer to a pointer variable into which the method writes the address of an instance of the requested interface. Through this
		/// method, the caller obtains a counted reference to the interface. The caller is responsible for releasing the interface, when it
		/// is no longer needed, by calling the interface's <c>Release</c> method. If the <c>GetService</c> call fails, *ppv is <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
		/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
		/// </para>
		/// <para>The <c>GetService</c> method supports the following service interfaces:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IAudioCaptureClient</term>
		/// </item>
		/// <item>
		/// <term>IAudioClock</term>
		/// </item>
		/// <item>
		/// <term>IAudioRenderClient</term>
		/// </item>
		/// <item>
		/// <term>IAudioSessionControl</term>
		/// </item>
		/// <item>
		/// <term>IAudioStreamVolume</term>
		/// </item>
		/// <item>
		/// <term>IChannelAudioVolume</term>
		/// </item>
		/// <item>
		/// <term>IMFTrustedOutput</term>
		/// </item>
		/// <item>
		/// <term>ISimpleAudioVolume</term>
		/// </item>
		/// </list>
		/// <para>
		/// In Windows 7, a new service identifier, <c>IID_IMFTrustedOutput</c>, has been added that facilitates the use of output trust
		/// authority (OTA) objects. These objects can operate inside or outside the Media Foundation's protected media path (PMP) and send
		/// content outside the Media Foundation pipeline. If the caller is outside PMP, then the OTA may not operate in the PMP, and the
		/// protection settings are less robust. OTAs must implement the IMFTrustedOutput interface. By passing <c>IID_IMFTrustedOutput</c>
		/// in <c>GetService</c>, an application can retrieve a pointer to the object's <c>IMFTrustedOutput</c> interface. For more
		/// information about protected objects and <c>IMFTrustedOutput</c>, see "Protected Media Path" in the Media Foundation SDK documentation.
		/// </para>
		/// <para>For information about using trusted audio drivers in OTAs, see Protected User Mode Audio (PUMA).</para>
		/// <para>
		/// Note that activating IMFTrustedOutput through this mechanism works regardless of whether the caller is running in PMP. However,
		/// if the caller is not running in a protected process (that is, the caller is not within Media Foundation's PMP) then the audio OTA
		/// might not operate in the PMP and the protection settings are less robust.
		/// </para>
		/// <para>
		/// To obtain the interface ID for a service interface, use the <c>__uuidof</c> operator. For example, the interface ID of
		/// <c>IAudioCaptureClient</c> is defined as follows:
		/// </para>
		/// <para>For information about the <c>__uuidof</c> operator, see the Windows SDK documentation.</para>
		/// <para>
		/// To release the <c>IAudioClient</c> object and free all its associated resources, the client must release all references to any
		/// service objects that were created by calling <c>GetService</c>, in addition to calling <c>Release</c> on the <c>IAudioClient</c>
		/// interface itself. The client must release a service from the same thread that releases the <c>IAudioClient</c> object.
		/// </para>
		/// <para>
		/// The <c>IAudioSessionControl</c>, <c>IAudioStreamVolume</c>, <c>IChannelAudioVolume</c>, and <c>ISimpleAudioVolume</c> interfaces
		/// control and monitor aspects of audio sessions and shared-mode streams. These interfaces do not work with exclusive-mode streams.
		/// </para>
		/// <para>For code examples that call the <c>GetService</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Capturing a Stream</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient-getservice HRESULT GetService( REFIID
		// riid, void **ppv );
		[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)]
		new object GetService(in Guid riid);

		/// <summary>
		/// The <c>IsOffloadCapable</c> method retrieves information about whether or not the endpoint on which a stream is created is
		/// capable of supporting an offloaded audio stream.
		/// </summary>
		/// <param name="Category">An enumeration that specifies the category of an audio stream.</param>
		/// <returns>
		/// A pointer to a Boolean value. <c>TRUE</c> indicates that the endpoint is offload-capable. <c>FALSE</c> indicates that the
		/// endpoint is not offload-capable.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient2-isoffloadcapable HRESULT
		// IsOffloadCapable( AUDIO_STREAM_CATEGORY Category, BOOL *pbOffloadCapable );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsOffloadCapable(AUDIO_STREAM_CATEGORY Category);

		/// <summary>Sets the properties of the audio stream by populating an AudioClientProperties structure.</summary>
		/// <param name="pProperties">Pointer to an AudioClientProperties structure.</param>
		/// <remarks>
		/// Starting with Windows 10, hardware-offloaded audio streams must be event driven. This means that if you call
		/// <c>IAudioClient2::SetClientProperties</c> and set the bIsOffload parameter of the AudioClientProperties to TRUE, you must specify
		/// the <c>AUDCLNT_STREAMFLAGS_EVENTCALLBACK</c> flag in the StreamFlags parameter to IAudioClient::Initialize.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient2-setclientproperties HRESULT
		// SetClientProperties( const AudioClientProperties *pProperties );
		new void SetClientProperties(in AudioClientProperties pProperties);

		/// <summary>
		/// The <c>GetBufferSizeLimits</c> method returns the buffer size limits of the hardware audio engine in 100-nanosecond units.
		/// </summary>
		/// <param name="pFormat">A pointer to the target format that is being queried for the buffer size limit.</param>
		/// <param name="bEventDriven">Boolean value to indicate whether or not the stream can be event-driven.</param>
		/// <param name="phnsMinBufferDuration">
		/// Returns a pointer to the minimum buffer size (in 100-nanosecond units) that is required for the underlying hardware audio engine
		/// to operate at the format specified in the pFormat parameter, without frequent audio glitching.
		/// </param>
		/// <param name="phnsMaxBufferDuration">
		/// Returns a pointer to the maximum buffer size (in 100-nanosecond units) that the underlying hardware audio engine can support for
		/// the format specified in the pFormat parameter.
		/// </param>
		/// <remarks>The <c>GetBufferSizeLimits</c> method is a device-facing method and does not require prior audio stream initialization.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient2-getbuffersizelimits HRESULT
		// GetBufferSizeLimits( const WAVEFORMATEX *pFormat, BOOL bEventDriven, REFERENCE_TIME *phnsMinBufferDuration, REFERENCE_TIME
		// *phnsMaxBufferDuration );
		new void GetBufferSizeLimits([In] IntPtr pFormat, [MarshalAs(UnmanagedType.Bool)] bool bEventDriven, out long phnsMinBufferDuration, out long phnsMaxBufferDuration);

		/// <summary>
		/// Returns the range of periodicities supported by the engine for the specified stream format. The periodicity of the engine is the
		/// rate at which the engine wakes an event-driven audio client to transfer audio data to or from the engine. The values returned
		/// depend on the characteristics of the audio client as specified through a previous call to IAudioClient2::SetClientProperties.
		/// </summary>
		/// <param name="pFormat">
		/// <para>Type: <c>const WAVEFORMATEX*</c></para>
		/// <para>The stream format for which the supported periodicities are queried.</para>
		/// </param>
		/// <param name="pDefaultPeriodInFrames">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>The default period with which the engine will wake the client for transferring audio samples</para>
		/// </param>
		/// <param name="pFundamentalPeriodInFrames">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// The fundamental period with which the engine will wake the client for transferring audio samples. When setting the audio engine
		/// periodicity, you must use an integral multiple of this value.
		/// </para>
		/// </param>
		/// <param name="pMinPeriodInFrames">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>The shortest period, in audio frames, with which the audio engine will wake the client for transferring audio samples.</para>
		/// </param>
		/// <param name="pMaxPeriodInFrames">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>The longest period, in audio frames, with which the audio engine will wake the client for transferring audio samples.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Audio clients request a specific periodicity from the audio engine with the PeriodInFrames parameter to
		/// IAudioClient3::InitializeSharedAudioStream. The value of PeriodInFrames must be an integral multiple of the value returned in the
		/// pFundamentalPeriodInFrames parameter. PeriodInFrames must also be greater than or equal to the value returned in
		/// pMinPeriodInFrames and less than or equal to the value of pMaxPeriodInFrames.
		/// </para>
		/// <para>For example, for a 44100 kHz format, <c>GetSharedModeEnginePeriod</c> might return:</para>
		/// <list type="bullet">
		/// <item>
		/// <term/>
		/// </item>
		/// <item>
		/// <term/>
		/// </item>
		/// <item>
		/// <term/>
		/// </item>
		/// <item>
		/// <term/>
		/// </item>
		/// </list>
		/// <para>
		/// Allowed values for the PeriodInFrames parameter to <c>InitializeSharedAudioStream</c> would include 48 and 448. They would also
		/// include things like 96 and 128.
		/// </para>
		/// <para>
		/// They would NOT include 4 (which is smaller than the minimum allowed value) or 98 (which is not a multiple of the
		/// fundamental) or 1000 (which is larger than the maximum allowed value).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient3-getsharedmodeengineperiod HRESULT
		// GetSharedModeEnginePeriod( const WAVEFORMATEX *pFormat, UINT32 *pDefaultPeriodInFrames, UINT32 *pFundamentalPeriodInFrames, UINT32
		// *pMinPeriodInFrames, UINT32 *pMaxPeriodInFrames );
		void GetSharedModeEnginePeriod([In] IntPtr pFormat, out uint pDefaultPeriodInFrames, out uint pFundamentalPeriodInFrames, out uint pMinPeriodInFrames, out uint pMaxPeriodInFrames);

		/// <summary>
		/// Returns the current format and periodicity of the audio engine. This method enables audio clients to match the current period of
		/// the audio engine.
		/// </summary>
		/// <param name="ppFormat">
		/// <para>Type: <c>WAVEFORMATEX**</c></para>
		/// <para>The current device format that is being used by the audio engine.</para>
		/// </param>
		/// <param name="pCurrentPeriodInFrames">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>The current period of the audio engine, in audio frames.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>Note</c> The values returned by this method are instantaneous values and may be invalid immediately after the call returns if,
		/// for example, another audio client sets the periodicity or format to a different value.
		/// </para>
		/// <para>
		/// <c>Note</c> The caller is responsible for calling CoTaskMemFree to deallocate the memory of the <c>WAVEFORMATEX</c> structure
		/// populated by this method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient3-getcurrentsharedmodeengineperiod
		// HRESULT GetCurrentSharedModeEnginePeriod( WAVEFORMATEX **ppFormat, UINT32 *pCurrentPeriodInFrames );
		void GetCurrentSharedModeEnginePeriod(out SafeCoTaskMemHandle ppFormat, out uint pCurrentPeriodInFrames);

		/// <summary>Initializes a shared stream with the specified periodicity.</summary>
		/// <param name="StreamFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Flags to control creation of the stream. The client should set this parameter to 0 or to the bitwise OR of one or more of the
		/// supported AUDCLNT_STREAMFLAGS_XXX Constants or AUDCLNT_SESSIONFLAGS_XXX Constants. The supported AUDCLNT_STREAMFLAGS_XXX
		/// Constants for this parameter when using this method are:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>AUDCLNT_STREAMFLAGS_EVENTCALLBACK</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_STREAMFLAGS_AUTOCONVERTPCM</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_STREAMFLAGS_SRC_DEFAULT_QUALITY</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="PeriodInFrames">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// Periodicity requested by the client. This value must be an integral multiple of the value returned in the
		/// pFundamentalPeriodInFrames parameter to IAudioClient3::GetSharedModeEnginePeriod. PeriodInFrames must also be greater than or
		/// equal to the value returned in pMinPeriodInFrames and less than or equal to the value returned in pMaxPeriodInFrames.
		/// </para>
		/// </param>
		/// <param name="pFormat">
		/// <para>Type: <c>const WAVEFORMATEX*</c></para>
		/// <para>
		/// Pointer to a format descriptor. This parameter must point to a valid format descriptor of type WAVEFORMATEX or <c></c>
		/// WAVEFORMATEXTENSIBLE. For more information, see the Remarks section for IAudioClient::Initialize.
		/// </para>
		/// </param>
		/// <param name="AudioSessionGuid">
		/// <para>Type: <c>LPCGUID</c></para>
		/// <para>
		/// Pointer to a session GUID. This parameter points to a GUID value that identifies the audio session that the stream belongs to. If
		/// the GUID identifies a session that has been previously opened, the method adds the stream to that session. If the GUID does not
		/// identify an existing session, the method opens a new session and adds the stream to that session. The stream remains a member of
		/// the same session for its lifetime. Setting this parameter to <c>NULL</c> is equivalent to passing a pointer to a GUID_NULL value.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Unlike IAudioClient::Initialize, this method does not allow you to specify a buffer size. The buffer size is computed based on
		/// the periodicity requested with the PeriodInFrames parameter. It is the client app's responsibility to ensure that audio samples
		/// are transferred in and out of the buffer in a timely manner.
		/// </para>
		/// <para>
		/// Audio clients should check for allowed values for the PeriodInFrames parameter by calling
		/// IAudioClient3::GetSharedModeEnginePeriod. The value of PeriodInFrames must be an integral multiple of the value returned in the
		/// pFundamentalPeriodInFrames parameter. PeriodInFrames must also be greater than or equal to the value returned in
		/// pMinPeriodInFrames and less than or equal to the value of pMaxPeriodInFrames.
		/// </para>
		/// <para>For example, for a 44100 kHz format, <c>GetSharedModeEnginePeriod</c> might return:</para>
		/// <list type="bullet">
		/// <item>
		/// <term/>
		/// </item>
		/// <item>
		/// <term/>
		/// </item>
		/// <item>
		/// <term/>
		/// </item>
		/// <item>
		/// <term/>
		/// </item>
		/// </list>
		/// <para>
		/// Allowed values for the PeriodInFrames parameter to <c>InitializeSharedAudioStream</c> would include 48 and 448. They would also
		/// include things like 96 and 128.
		/// </para>
		/// <para>
		/// They would NOT include 4 (which is smaller than the minimum allowed value) or 98 (which is not a multiple of the
		/// fundamental) or 1000 (which is larger than the maximum allowed value).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient3-initializesharedaudiostream HRESULT
		// InitializeSharedAudioStream( DWORD StreamFlags, UINT32 PeriodInFrames, const WAVEFORMATEX *pFormat, LPCGUID AudioSessionGuid );
		void InitializeSharedAudioStream(AUDCLNT_STREAMFLAGS StreamFlags, [In] uint PeriodInFrames, [In] IntPtr pFormat, [In, Optional] in Guid AudioSessionGuid);
	}

	/// <summary>
	/// Provides a method, SetDuckingOptionsForCurrentStream, that allows an app to specify that the system shouldn't duck the audio of other
	/// streams when the app's audio render stream is active.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Get an instance of the IAudioClientDuckingControl interface by calling IAudioClient::GetService, passing in the interface ID constant <c>IID_IAudioClientDuckingControl</c>.
	/// </para>
	/// <para>
	/// <c>IAudioClientDuckingControl</c> only controls the ducking caused by the audio stream ( <c>IAudioClient</c>) that the interface is
	/// obtained from.
	/// </para>
	/// <para>Audio from applications could continue to be ducked if there are other concurrent applications with streams that cause ducking.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioclient/nn-audioclient-iaudioclientduckingcontrol
	[PInvokeData("audioclient.h", MSDNShortId = "NN:audioclient.IAudioClientDuckingControl")]
	[ComImport, Guid("C789D381-A28C-4168-B28F-D3A837924DC3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioClientDuckingControl
	{
		/// <summary>
		/// Sets the audio ducking options for an audio render stream. Allows an app to specify that the system shouldn't duck the audio of
		/// other streams when the app's audio render stream is active.
		/// </summary>
		/// <param name="options">A value from the AUDIO_DUCKING_OPTIONS enumeration specifying the requested ducking behavior.</param>
		/// <remarks>
		/// <para>
		/// Get an instance of the IAudioClientDuckingControl interface by calling IAudioClient::GetService, passing in the interface ID
		/// constant <c>IID_IAudioClientDuckingControl</c>.
		/// </para>
		/// <para>
		/// <c>IAudioClientDuckingControl</c> only controls the ducking caused by the audio stream ( <c>IAudioClient</c>) that the interface
		/// is obtained from.
		/// </para>
		/// <para>
		/// Audio from applications could continue to be ducked if there are other concurrent applications with streams that cause ducking.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclientduckingcontrol-setduckingoptionsforcurrentstream
		// HRESULT SetDuckingOptionsForCurrentStream( AUDIO_DUCKING_OPTIONS options );
		void SetDuckingOptionsForCurrentStream(AUDIO_DUCKING_OPTIONS options);
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioClock</c> interface enables a client to monitor a stream's data rate and the current position in the stream. The client
	/// obtains a reference to the <c>IAudioClock</c> interface of a stream object by calling the IAudioClient::GetService method with
	/// parameter riid set to REFIID IID_IAudioClock.
	/// </para>
	/// <para>
	/// When releasing an <c>IAudioClock</c> interface instance, the client must call the interface's Release method from the same thread as
	/// the call to <c>IAudioClient::GetService</c> that created the object.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nn-audioclient-iaudioclock
	[PInvokeData("audioclient.h", MSDNShortId = "dbec9468-b555-42a0-a988-dec3a66c9f96")]
	[ComImport, Guid("CD63314F-3FBA-4a1b-812C-EF96358728E7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioClock
	{
		/// <summary>The <c>GetFrequency</c> method gets the device frequency.</summary>
		/// <returns>A <c>UINT64</c> variable into which the method writes the device frequency. For more information, see Remarks.</returns>
		/// <remarks>
		/// <para>
		/// The device frequency is the frequency generated by the hardware clock in the audio device. This method reports the device
		/// frequency in units that are compatible with those of the device position that the IAudioClock::GetPosition method reports. For
		/// example, if, for a particular stream, the <c>GetPosition</c> method expresses the position p as a byte offset, the
		/// <c>GetFrequency</c> method expresses the frequency f in bytes per second. For any stream, the offset in seconds from the start of
		/// the stream can always be reliably calculated as p/f regardless of the units in which p and f are expressed.
		/// </para>
		/// <para>
		/// In Windows Vista, the device frequency reported by successive calls to <c>GetFrequency</c> never changes during the lifetime of a stream.
		/// </para>
		/// <para>
		/// If the clock generated by an audio device runs at a nominally constant frequency, the frequency might still vary slightly over
		/// time due to drift or jitter with respect to a reference clock. The reference clock might be a wall clock or the system clock used
		/// by the <c>QueryPerformanceCounter</c> function. The <c>GetFrequency</c> method ignores such variations and simply reports a
		/// constant frequency. However, the position reported by the <c>IAudioClient::GetPosition</c> method takes all such variations into
		/// account to report an accurate position value each time it is called. For more information about <c>QueryPerformanceCounter</c>,
		/// see the Windows SDK documentation.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclock-getfrequency HRESULT GetFrequency(
		// UINT64 *pu64Frequency );
		ulong GetFrequency();

		/// <summary>The <c>GetPosition</c> method gets the current device position.</summary>
		/// <param name="pu64Position">
		/// Pointer to a <c>UINT64</c> variable into which the method writes the device position. The device position is the offset from the
		/// start of the stream to the current position in the stream. However, the units in which this offset is expressed are undefined—the
		/// device position value has meaning only in relation to the frequency reported by the IAudioClock::GetFrequency method. For more
		/// information, see Remarks.
		/// </param>
		/// <param name="pu64QPCPosition">
		/// Pointer to a <c>UINT64</c> variable into which the method writes the value of the performance counter at the time that the audio
		/// endpoint device read the device position (*pu64Position) in response to the <c>GetPosition</c> call. The method converts the
		/// counter value to 100-nanosecond time units before writing it to *pu64QPCPosition. This parameter can be <c>NULL</c> if the client
		/// does not require the performance counter value.
		/// </param>
		/// <remarks>
		/// <para>
		/// Rendering or capture clients that need to expose a clock based on the stream's current playback or record position can use this
		/// method to derive that clock.
		/// </para>
		/// <para>This method retrieves two correlated stream-position values:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Device position. The client obtains the device position through output parameter pu64Position. This is the stream position of the
		/// sample that is currently playing through the speakers (for a rendering stream) or being recorded through the microphone (for a
		/// capture stream).
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Performance counter. The client obtains the performance counter through output parameter pu64QPCPosition. This is the counter
		/// value that the method obtained by calling the <c>QueryPerformanceCounter</c> function at the time that the audio endpoint device
		/// recorded the stream position (*pu64Position). Note that <c>GetPosition</c> converts the counter value to 100-nanosecond time units.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The device position is meaningless unless it is combined with the device frequency reported by the
		/// <c>IAudioClock::GetFrequency</c> method. The reason is that the units in which the device positions for different streams are
		/// expressed might vary according to factors such as whether the stream was opened in shared mode or exclusive mode. However, the
		/// frequency f obtained from <c>GetFrequency</c> is always expressed in units that are compatible with those of the device position
		/// p. Thus, the stream-relative offset in seconds can always be calculated as p/f.
		/// </para>
		/// <para>
		/// The device position is a stream-relative offset. That is, it is specified as an offset from the start of the stream. The device
		/// position can be thought of as an offset into an idealized buffer that contains the entire stream and is contiguous from beginning
		/// to end.
		/// </para>
		/// <para>
		/// Given the device position and the performance counter at the time of the <c>GetPosition</c> call, the client can provide a more
		/// timely estimate of the device position at a slightly later time by calling <c>QueryPerformanceCounter</c> to obtain the current
		/// performance counter, and extrapolating the device position based on how far the counter has advanced since the original device
		/// position was recorded. The client can call the <c>QueryPerformanceFrequency</c> function to determine the frequency of the clock
		/// that increments the counter. Before comparing the raw counter value obtained from <c>QueryPerformanceCounter</c> to the value
		/// written to *pu64QPCPosition by <c>GetPosition</c>, convert the raw counter value to 100-nanosecond time units as follows:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Multiply the raw counter value by 10,000,000.</term>
		/// </item>
		/// <item>
		/// <term>Divide the result by the counter frequency obtained from <c>QueryPerformanceFrequency</c>.</term>
		/// </item>
		/// </list>
		/// <para>For more information about <c>QueryPerformanceCounter</c> and <c>QueryPerformanceFrequency</c>, see the Windows SDK documentation.</para>
		/// <para>
		/// Immediately following creation of a new stream, the device position is 0. Following a call to the IAudioClient::Start method, the
		/// device position increments at a uniform rate. The IAudioClient::Stop method freezes the device position, and a subsequent
		/// <c>Start</c> call causes the device position to resume incrementing from its value at the time of the <c>Stop</c> call. A call to
		/// IAudioClient::Reset, which should only occur while the stream is stopped, resets the device position to 0.
		/// </para>
		/// <para>
		/// When a new or reset rendering stream initially begins running, its device position might remain 0 for a few milliseconds until
		/// the audio data has had time to propagate from the endpoint buffer to the rendering endpoint device. The device position changes
		/// from 0 to a nonzero value when the data begins playing through the device.
		/// </para>
		/// <para>
		/// Successive device readings are monotonically increasing. Although the device position might not change between two successive
		/// readings, the device position never decreases from one reading to the next.
		/// </para>
		/// <para>The pu64Position parameter must be a valid, non- <c>NULL</c> pointer or the method will fail and return error code E_POINTER.</para>
		/// <para>
		/// Position measurements might occasionally be delayed by intermittent, high-priority events. These events might be unrelated to
		/// audio. In the case of an exclusive-mode stream, the method can return S_FALSE instead of S_OK if the method succeeds but the
		/// duration of the call is long enough to detract from the accuracy of the reported position. When this occurs, the caller has the
		/// option of calling the method again to attempt to retrieve a more accurate position (as indicated by return value S_OK). However,
		/// the caller should avoid performing this test in an infinite loop in the event that the method consistently returns S_FALSE.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclock-getposition HRESULT GetPosition( UINT64
		// *pu64Position, UINT64 *pu64QPCPosition );
		void GetPosition(out ulong pu64Position, out ulong pu64QPCPosition);

		/// <summary>The <c>GetCharacteristics</c> method is reserved for future use.</summary>
		/// <returns>
		/// Pointer to a <c>DWORD</c> variable into which the method writes a value that indicates the characteristics of the audio clock.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclock-getcharacteristics HRESULT
		// GetCharacteristics( DWORD *pdwCharacteristics );
		uint GetCharacteristics();
	}

	/// <summary>
	/// <para>The <c>IAudioClock2</c> interface is used to get the current device position.</para>
	/// <para>
	/// To get a reference to the <c>IAudioClock2</c> interface, the application must call <c>IAudioClock::QueryInterface</c> to request the
	/// interface pointer from the stream object's IAudioClock interface.
	/// </para>
	/// <para>
	/// The client obtains a reference to the <c>IAudioClock</c> interface of a stream object by calling the IAudioClient::GetService method
	/// with parameter riid set to REFIID IID_IAudioClock.
	/// </para>
	/// <para>
	/// When releasing an <c>IAudioClock2</c> interface instance, the client must call the interface's <c>Release</c> method from the same
	/// thread as the call to IAudioClient::GetService that created the object.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nn-audioclient-iaudioclock2
	[PInvokeData("audioclient.h", MSDNShortId = "4820c93a-a5d8-4ab9-aefc-9377fc76e745")]
	[ComImport, Guid("6f49ff73-6727-49ac-a008-d98cf5e70048"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioClock2
	{
		/// <summary>The <c>GetDevicePosition</c> method gets the current device position, in frames, directly from the hardware.</summary>
		/// <param name="DevicePosition">
		/// Receives the device position, in frames. The received position is an unprocessed value that the method obtains directly from the
		/// hardware. For more information, see Remarks.
		/// </param>
		/// <param name="QPCPosition">
		/// Receives the value of the performance counter at the time that the audio endpoint device read the device position retrieved in
		/// the DevicePosition parameter in response to the <c>GetDevicePosition</c> call. <c>GetDevicePosition</c> converts the counter
		/// value to 100-nanosecond time units before writing it to QPCPosition. QPCPosition can be <c>NULL</c> if the client does not
		/// require the performance counter value. For more information, see Remarks.
		/// </param>
		/// <remarks>
		/// <para>This method only applies to shared-mode streams.</para>
		/// <para>This method retrieves two correlated stream-position values:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Device position. The client retrieves the unprocessed device position in DevicePosition. This is the stream position of the
		/// sample that is currently playing through the speakers (for a rendering stream) or being recorded through the microphone (for a
		/// capture stream). The sampling rate of the device endpoint may be different from the sampling rate of the mix format used by the
		/// client. To retrieve the device position from the client, call IAudioClock::GetPosition.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Performance counter. The client retrieves the performance counter in QPCPosition. <c>GetDevicePosition</c> obtains the counter
		/// value by calling the <c>QueryPerformanceCounter</c> function at the time that the audio endpoint device stores the stream
		/// position in the DevicePosition parameter of the <c>GetDevicePosition</c> method. <c>GetDevicePosition</c> converts the counter
		/// value to 100-nanosecond time units. For more information about <c>QueryPerformanceCounter</c> and
		/// <c>QueryPerformanceFrequency</c>, see the Windows SDK documentation.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Given the device position and the performance counter at the time of the <c>GetDevicePosition</c> call, the client can get a more
		/// timely estimate of the device position at a later time by calling <c>QueryPerformanceCounter</c> to obtain the current
		/// performance counter, and extrapolating the device position based on how far the counter has advanced since the original device
		/// position was recorded. The client can call the <c>QueryPerformanceCounter</c> function to get the frequency of the clock that
		/// increments the counter. Before comparing the raw counter value obtained from <c>QueryPerformanceCounter</c> to the value
		/// retrieved by <c>GetDevicePosition</c>, convert the raw counter value to 100-nanosecond time units as follows:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Multiply the raw counter value by 10,000,000.</term>
		/// </item>
		/// <item>
		/// <term>Divide the result by the counter frequency obtained from <c>QueryPerformanceCounter</c>.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclock2-getdeviceposition HRESULT
		// GetDevicePosition( UINT64 *DevicePosition, UINT64 *QPCPosition );
		void GetDevicePosition(out ulong DevicePosition, out ulong QPCPosition);
	}

	/// <summary>
	/// <para>The <c>IAudioClockAdjustment</c> interface is used to adjust the sample rate of a stream.</para>
	/// <para>
	/// The client obtains a reference to the <c>IAudioClockAdjustment</c> interface of a stream object by calling the
	/// IAudioClient::GetService method with parameter riid set to REFIID IID_IAudioClockAdjustment. Adjusting the sample rate is not
	/// supported for exclusive mode streams.
	/// </para>
	/// <para>
	/// The <c>IAudioClockAdjustment</c> interface must be obtained from an audio client that is initialized with both the
	/// AUDCLNT_STREAMFLAGS_RATEADJUST flag and the share mode set to AUDCLNT_SHAREMODE_SHARED. If Initialize is called in an exclusive mode
	/// with the AUDCLNT_STREAMFLAGS_RATEADJUST flag, <c>Initialize</c> fails with the AUDCLNT_E_UNSUPPORTED_FORMAT error code.
	/// </para>
	/// <para>
	/// When releasing an <c>IAudioClockAdjustment</c> interface instance, the client must call the interface's <c>Release</c> method from
	/// the same thread as the call to IAudioClient::GetService that created the object.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nn-audioclient-iaudioclockadjustment
	[PInvokeData("audioclient.h", MSDNShortId = "61d90fd9-6c73-4987-b424-1523f15ab023")]
	[ComImport, Guid("f6e4c0a0-46d9-4fb8-be21-57a3ef2b626c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioClockAdjustment
	{
		/// <summary>The <c>SetSampleRate</c> method sets the sample rate of a stream.</summary>
		/// <param name="flSampleRate">The new sample rate in frames per second.</param>
		/// <remarks>
		/// <para>This method must not be called from a real-time processing thread.</para>
		/// <para>
		/// The new sample rate will take effect after the current frame is done processing and will remain in effect until
		/// <c>SetSampleRate</c> is called again. The audio client must be initialized in shared-mode (AUDCLNT_SHAREMODE_SHARED), otherwise
		/// <c>SetSampleRate</c> fails.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclockadjustment-setsamplerate HRESULT
		// SetSampleRate( float flSampleRate );
		void SetSampleRate([In] float flSampleRate);
	}

	/// <summary>
	/// A callback interface allows applications to receive notifications when the list of audio effects for the associated audio stream
	/// changes or when the resources needed to enable an effect changes, i.e. when the value of the canSetState field of the associated
	/// AUDIO_EFFECT changes.
	/// </summary>
	/// <remarks>Register the callback interface by calling IAudioEffectsManager::RegisterAudioEffectsChangedNotificationCallback.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioclient/nn-audioclient-iaudioeffectschangednotificationclient
	[PInvokeData("audioclient.h", MSDNShortId = "NN:audioclient.IAudioEffectsChangedNotificationClient")]
	[ComImport, Guid("A5DED44F-3C5D-4B2B-BD1E-5DC1EE20BBF6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioEffectsChangedNotificationClient
	{
		/// <summary>
		/// Called by the system when the list of audio effects changes or the resources needed to enable an effect changes, i.e. when the
		/// value of the canSetState field of the associated AUDIO_EFFECT changes.
		/// </summary>
		/// <returns>An HRESULT.</returns>
		/// <remarks>Register the callback interface by calling IAudioEffectsManager::RegisterAudioEffectsChangedNotificationCallback.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioeffectschangednotificationclient-onaudioeffectschanged
		// HRESULT OnAudioEffectsChanged();
		[PreserveSig]
		HRESULT OnAudioEffectsChanged();
	}

	/// <summary>
	/// Provides management functionality for the audio effects pipeline for the associated audio stream, allowing applications to get the
	/// current list of effects, set the state of effects, and to register for notifications when the list of effects or effect states change.
	/// </summary>
	/// <remarks>
	/// Get an instance of this interface by calling IAudioClient::GetService passing in the interface pointer of the
	/// <c>IAudioEffectsManager</c> interface.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioclient/nn-audioclient-iaudioeffectsmanager
	[PInvokeData("audioclient.h", MSDNShortId = "NN:audioclient.IAudioEffectsManager")]
	[ComImport, Guid("4460B3AE-4B44-4527-8676-7548A8ACD260"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioEffectsManager
	{
		/// <summary>
		/// Registers an IAudioEffectsChangedNotificationClient interface. This callback interface allows applications to receive
		/// notifications when the list of audio effects changes or the resources needed to enable an effect changes, i.e. when the value of
		/// the canSetState field of the associated AUDIO_EFFECT changes.
		/// </summary>
		/// <param name="client">The <c>IAudioEffectsChangedNotificationClient</c> interface to register.</param>
		/// <remarks>Unregister the callback interface by calling UnregisterAudioEffectsChangedNotificationCallback.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioeffectsmanager-registeraudioeffectschangednotificationcallback
		// HRESULT RegisterAudioEffectsChangedNotificationCallback( IAudioEffectsChangedNotificationClient *client );
		void RegisterAudioEffectsChangedNotificationCallback(IAudioEffectsChangedNotificationClient client);

		/// <summary>Unregisters an IAudioEffectsChangedNotificationClient interface.</summary>
		/// <param name="client">The <c>IAudioEffectsChangedNotificationClient</c> interface to unregister.</param>
		/// <remarks>Register the callback interface by calling RegisterAudioEffectsChangedNotificationCallback.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioeffectsmanager-unregisteraudioeffectschangednotificationcallback
		// HRESULT UnregisterAudioEffectsChangedNotificationCallback( IAudioEffectsChangedNotificationClient *client );
		void UnregisterAudioEffectsChangedNotificationCallback(IAudioEffectsChangedNotificationClient client);

		/// <summary>Gets the current list of audio effects for the associated audio stream.</summary>
		/// <param name="effects">Receives a pointer to an array of AUDIO_EFFECT structures representing the current list of audio effects.</param>
		/// <param name="numEffects">Receives the number of <c>AUDIO_EFFECT</c> structures returned in effects.</param>
		/// <remarks>
		/// <para>The caller is responsible for freeing the array using CoTaskMemFree.</para>
		/// <para>Register an IAudioEffectsChangedNotificationClient to receive notifications when the list of audio effects changes.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioeffectsmanager-getaudioeffects HRESULT
		// GetAudioEffects( AUDIO_EFFECT **effects, UINT32 *numEffects );
		void GetAudioEffects(out SafeCoTaskMemHandle effects, out uint numEffects);

		/// <summary>Sets the state of the specified audio effect.</summary>
		/// <param name="effectId">
		/// The GUID identifier of the effect for which the state is being changed. Audio effect GUIDs are defined in ksmedia.h.
		/// </param>
		/// <param name="state">A value from the AUDIO_EFFECT_STATE enumerating specifying the state to set.</param>
		/// <remarks>Get the current list of audio effects for the associated audio stream by calling GetAudioEffects.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioeffectsmanager-setaudioeffectstate HRESULT
		// SetAudioEffectState( GUID effectId, AUDIO_EFFECT_STATE state );
		void SetAudioEffectState(Guid effectId, AUDIO_EFFECT_STATE state);
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioRenderClient</c> interface enables a client to write output data to a rendering endpoint buffer. The client obtains a
	/// reference to the <c>IAudioRenderClient</c> interface of a stream object by calling the IAudioClient::GetService method with parameter
	/// riid set to <c>REFIID</c> IID_IAudioRenderClient.
	/// </para>
	/// <para>
	/// The methods in this interface manage the movement of data packets that contain audio-rendering data. The length of a data packet is
	/// expressed as the number of audio frames in the packet. The size of an audio frame is specified by the <c>nBlockAlign</c> member of
	/// the <c>WAVEFORMATEX</c> structure that the client obtains by calling the IAudioClient::GetMixFormat method. The size in bytes of an
	/// audio frame equals the number of channels in the stream multiplied by the sample size per channel. For example, the frame size is
	/// four bytes for a stereo (2-channel) stream with 16-bit samples. A packet always contains an integral number of audio frames.
	/// </para>
	/// <para>
	/// When releasing an <c>IAudioRenderClient</c> interface instance, the client must call the interface's <c>Release</c> method from the
	/// same thread as the call to <c>IAudioClient::GetService</c> that created the object.
	/// </para>
	/// <para>For code examples that use the <c>IAudioRenderClient</c> interface, see the following topics:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Rendering a Stream</term>
	/// </item>
	/// <item>
	/// <term>Exclusive-Mode Streams</term>
	/// </item>
	/// </list>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nn-audioclient-iaudiorenderclient
	[PInvokeData("audioclient.h", MSDNShortId = "e3e18e1e-1a09-4072-add6-36d2a6428a74")]
	[ComImport, Guid("F294ACFC-3146-4483-A7BF-ADDCA7C260E2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioRenderClient
	{
		/// <summary>
		/// Retrieves a pointer to the next available space in the rendering endpoint buffer into which the caller can write a data packet.
		/// </summary>
		/// <param name="NumFramesRequested">
		/// The number of audio frames in the data packet that the caller plans to write to the requested space in the buffer. If the call
		/// succeeds, the size of the buffer area pointed to by *ppData matches the size specified in NumFramesRequested.
		/// </param>
		/// <returns>
		/// Pointer to a variable into which the method writes the starting address of the buffer area into which the caller will write the
		/// data packet.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The caller can request a packet size that is less than or equal to the amount of available space in the buffer (except in the
		/// case of an exclusive-mode stream that uses event-driven buffering; for more information, see IAudioClient::Initialize). The
		/// available space is simply the buffer size minus the amount of data in the buffer that is already queued up to be played. If the
		/// caller specifies a NumFramesRequested value that exceeds the available space in the buffer, the call fails and returns error code AUDCLNT_E_BUFFER_TOO_LARGE.
		/// </para>
		/// <para>
		/// The client is responsible for writing a sufficient amount of data to the buffer to prevent glitches from occurring in the audio
		/// stream. For more information about buffering requirements, see IAudioClient::Initialize.
		/// </para>
		/// <para>
		/// After obtaining a data packet by calling <c>GetBuffer</c>, the client fills the packet with rendering data and issues the packet
		/// to the audio engine by calling the IAudioRenderClient::ReleaseBuffer method.
		/// </para>
		/// <para>
		/// The client must call <c>ReleaseBuffer</c> after a <c>GetBuffer</c> call that successfully obtains a packet of any size other than
		/// 0. The client has the option of calling or not calling <c>ReleaseBuffer</c> to release a packet of size 0.
		/// </para>
		/// <para>
		/// For nonzero packet sizes, the client must alternate calls to <c>GetBuffer</c> and <c>ReleaseBuffer</c>. Each <c>GetBuffer</c>
		/// call must be followed by a corresponding <c>ReleaseBuffer</c> call. After the client has called <c>GetBuffer</c> to acquire a
		/// data packet, the client cannot acquire the next data packet until it has called <c>ReleaseBuffer</c> to release the previous
		/// packet. Two or more consecutive calls either to <c>GetBuffer</c> or to <c>ReleaseBuffer</c> are not permitted and will fail with
		/// error code AUDCLNT_E_OUT_OF_ORDER.
		/// </para>
		/// <para>
		/// To ensure the correct ordering of calls, a <c>GetBuffer</c> call and its corresponding <c>ReleaseBuffer</c> call must occur in
		/// the same thread.
		/// </para>
		/// <para>
		/// The size of an audio frame is specified by the <c>nBlockAlign</c> member of the <c>WAVEFORMATEX</c> structure that the client
		/// obtains by calling the IAudioClient::GetMixFormat method.
		/// </para>
		/// <para>
		/// If the caller sets NumFramesRequested = 0, the method returns status code S_OK but does not write to the variable that the ppData
		/// parameter points to.
		/// </para>
		/// <para>
		/// Clients should avoid excessive delays between the <c>GetBuffer</c> call that acquires a buffer and the <c>ReleaseBuffer</c> call
		/// that releases the buffer. The implementation of the audio engine assumes that the <c>GetBuffer</c> call and the corresponding
		/// <c>ReleaseBuffer</c> call occur within the same buffer-processing period. Clients that delay releasing a buffer for more than one
		/// period risk losing sample data.
		/// </para>
		/// <para>
		/// In Windows 7, <c>GetBuffer</c> can return the <c>AUDCLNT_E_BUFFER_ERROR</c> error code for an audio client that uses the endpoint
		/// buffer in the exclusive mode. This error indicates that the data buffer was not retrieved because a data packet was not available
		/// (*ppData received <c>NULL</c>).
		/// </para>
		/// <para>
		/// If <c>GetBuffer</c> returns <c>AUDCLNT_E_BUFFER_ERROR</c>, the thread consuming the audio samples must wait for the next
		/// processing pass. The client might benefit from keeping a count of the failed <c>GetBuffer</c> calls. If <c>GetBuffer</c> returns
		/// this error repeatedly, the client can start a new processing loop after shutting down the current client by calling
		/// IAudioClient::Stop, IAudioClient::Reset, and releasing the audio client.
		/// </para>
		/// <para>Examples</para>
		/// <para>For code examples that call the <c>GetBuffer</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Exclusive-Mode Streams</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudiorenderclient-getbuffer HRESULT GetBuffer(
		// UINT32 NumFramesRequested, BYTE **ppData );
		IntPtr GetBuffer([In] uint NumFramesRequested);

		/// <summary>
		/// The <c>ReleaseBuffer</c> method releases the buffer space acquired in the previous call to the IAudioRenderClient::GetBuffer method.
		/// </summary>
		/// <param name="NumFramesWritten">
		/// The number of audio frames written by the client to the data packet. The value of this parameter must be less than or equal to
		/// the size of the data packet, as specified in the NumFramesRequested parameter passed to the IAudioRenderClient::GetBuffer method.
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// The buffer-configuration flags. The caller can set this parameter either to 0 or to the following _AUDCLNT_BUFFERFLAGS
		/// enumeration value (a flag bit):
		/// </para>
		/// <para>AUDCLNT_BUFFERFLAGS_SILENT</para>
		/// <para>
		/// If this flag bit is set, the audio engine treats the data packet as though it contains silence regardless of the data values
		/// contained in the packet. This flag eliminates the need for the client to explicitly write silence data to the rendering buffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the method succeeds, it returns S_OK. If it fails, possible return codes include, but are not limited to, the values shown in
		/// the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>AUDCLNT_E_INVALID_SIZE</term>
		/// <term>
		/// The NumFramesWritten value exceeds the NumFramesRequested value specified in the previous IAudioRenderClient::GetBuffer call.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_BUFFER_SIZE_ERROR</term>
		/// <term>
		/// The stream is exclusive mode and uses event-driven buffering, but the client attempted to release a packet that was not the size
		/// of the buffer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_OUT_OF_ORDER</term>
		/// <term>This call was not preceded by a corresponding call to IAudioRenderClient::GetBuffer.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
		/// <term>
		/// The audio endpoint device has been unplugged, or the audio hardware or associated hardware resources have been reconfigured,
		/// disabled, removed, or otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_SERVICE_NOT_RUNNING</term>
		/// <term>The Windows audio service is not running.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>Parameter dwFlags is not a valid value.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The client must release the same number of frames that it requested in the preceding call to the IAudioRenderClient::GetBuffer
		/// method. The single exception to this rule is that the client can always call <c>ReleaseBuffer</c> to release 0 frames (unless the
		/// stream is exclusive mode and uses event-driven buffering).
		/// </para>
		/// <para>
		/// This behavior provides a convenient means for the client to "release" a previously requested packet of length 0. In this case,
		/// the call to <c>ReleaseBuffer</c> is optional. After calling GetBuffer to obtain a packet of length 0, the client has the option
		/// of not calling <c>ReleaseBuffer</c> before calling <c>GetBuffer</c> again.
		/// </para>
		/// <para>
		/// In addition, if the preceding GetBuffer call obtained a packet of nonzero size, calling <c>ReleaseBuffer</c> with
		/// NumFramesRequested set to 0 will succeed (unless the stream is exclusive mode and uses event-driven buffering). The meaning of
		/// the call is that the client wrote no data to the packet before releasing it. Thus, the method treats the portion of the buffer
		/// represented by the packet as unused and will make this portion of the buffer available again to the client in the next
		/// <c>GetBuffer</c> call.
		/// </para>
		/// <para>
		/// Clients should avoid excessive delays between the GetBuffer call that acquires a buffer and the <c>ReleaseBuffer</c> call that
		/// releases the buffer. The implementation of the audio engine assumes that the <c>GetBuffer</c> call and the corresponding
		/// <c>ReleaseBuffer</c> call occur within the same buffer-processing period. Clients that delay releasing a buffer for more than one
		/// period risk losing sample data.
		/// </para>
		/// <para>For code examples that call the <c>ReleaseBuffer</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Rendering a Stream</term>
		/// </item>
		/// <item>
		/// <term>Exclusive-Mode Streams</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudiorenderclient-releasebuffer HRESULT
		// ReleaseBuffer( UINT32 NumFramesWritten, DWORD dwFlags );
		void ReleaseBuffer([In] uint NumFramesWritten, [In] AUDCLNT_BUFFERFLAGS dwFlags);
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioStreamVolume</c> interface enables a client to control and monitor the volume levels for all of the channels in an audio
	/// stream. The client obtains a reference to the <c>IAudioStreamVolume</c> interface on a stream object by calling the
	/// IAudioClient::GetService method with parameter riid set to REFIID IID_IAudioStreamVolume.
	/// </para>
	/// <para>
	/// The effective volume level of any channel in the session submix, as heard at the speakers, is the product of the following four
	/// volume-level factors:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The per-channel volume levels of the streams in the session, which clients can control through the methods in the
	/// <c>IAudioStreamVolume</c> interface.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The per-channel volume level of the session, which clients can control through the methods in the IChannelAudioVolume interface.</term>
	/// </item>
	/// <item>
	/// <term>The master volume level of the session, which clients can control through the methods in the ISimpleAudioVolume interface.</term>
	/// </item>
	/// <item>
	/// <term>The policy-based volume level of the session, which the system dynamically assigns to the session as the global mix changes.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Each of the four volume-level factors in the preceding list is a value in the range 0.0 to 1.0, where 0.0 indicates silence and 1.0
	/// indicates full volume (no attenuation). The effective volume level is also a value in the range 0.0 to 1.0.
	/// </para>
	/// <para>
	/// When releasing an <c>IAudioStreamVolume</c> interface instance, the client must call the interface's <c>Release</c> method from the
	/// same thread as the call to <c>IAudioClient::GetService</c> that created the object.
	/// </para>
	/// <para>
	/// The <c>IAudioStreamVolume</c> interface controls the channel volumes in a shared-mode audio stream. This interface does not work with
	/// exclusive-mode streams. For information about volume controls for exclusive-mode streams, see EndpointVolume API.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nn-audioclient-iaudiostreamvolume
	[PInvokeData("audioclient.h", MSDNShortId = "92cc127b-77ac-4fc7-ac3c-319e5d6368d3")]
	[ComImport, Guid("93014887-242D-4068-8A15-CF5E93B90FE3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioStreamVolume
	{
		/// <summary>The <c>GetChannelCount</c> method retrieves the number of channels in the audio stream.</summary>
		/// <returns>A <c>UINT32</c> variable into which the method writes the channel count.</returns>
		/// <remarks>
		/// Call this method to get the number of channels in the audio stream before calling any of the other methods in the
		/// IAudioStreamVolume interface.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudiostreamvolume-getchannelcount HRESULT
		// GetChannelCount( UINT32 *pdwCount );
		uint GetChannelCount();

		/// <summary>The <c>SetChannelVolume</c> method sets the volume level for the specified channel in the audio stream.</summary>
		/// <param name="dwIndex">
		/// The channel number. If the stream format has N channels, the channels are numbered from 0 to N– 1. To get the number of channels,
		/// call the IAudioStreamVolume::GetChannelCount method.
		/// </param>
		/// <param name="fLevel">The volume level for the channel. Valid volume levels are in the range 0.0 to 1.0.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudiostreamvolume-setchannelvolume HRESULT
		// SetChannelVolume( UINT32 dwIndex, const float fLevel );
		void SetChannelVolume([In] uint dwIndex, [In] float fLevel);

		/// <summary>The <c>GetChannelVolume</c> method retrieves the volume level for the specified channel in the audio stream.</summary>
		/// <param name="dwIndex">
		/// The channel number. If the stream format has N channels, then the channels are numbered from 0 to N– 1. To get the number of
		/// channels, call the IAudioStreamVolume::GetChannelCount method.
		/// </param>
		/// <returns>
		/// A <c>float</c> variable into which the method writes the volume level of the specified channel. The volume level is in the range
		/// 0.0 to 1.0.
		/// </returns>
		/// <remarks>
		/// Clients can call the IAudioStreamVolume::SetAllVolumes or IAudioStreamVolume::SetChannelVolume method to set the per-channel
		/// volume levels in an audio stream.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudiostreamvolume-getchannelvolume HRESULT
		// GetChannelVolume( UINT32 dwIndex, float *pfLevel );
		float GetChannelVolume([In] uint dwIndex);

		/// <summary>The <c>SetAllVolumes</c> method sets the individual volume levels for all the channels in the audio stream.</summary>
		/// <param name="dwCount">
		/// The number of elements in the pfVolumes array. This parameter must equal the number of channels in the stream format. To get the
		/// number of channels, call the IAudioStreamVolume::GetChannelCount method.
		/// </param>
		/// <param name="pfVolumes">
		/// Pointer to an array of volume levels for the channels in the audio stream. The number of elements in the pfVolumes array is
		/// specified by the dwCount parameter. The caller writes the volume level for each channel to the array element whose index matches
		/// the channel number. If the stream format has N channels, the channels are numbered from 0 to N– 1. Valid volume levels are in the
		/// range 0.0 to 1.0.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudiostreamvolume-setallvolumes HRESULT
		// SetAllVolumes( UINT32 dwCount, const float *pfVolumes );
		void SetAllVolumes([In] uint dwCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] pfVolumes);

		/// <summary>The <c>GetAllVolumes</c> method retrieves the volume levels for all the channels in the audio stream.</summary>
		/// <param name="dwCount">
		/// The number of elements in the pfVolumes array. The dwCount parameter must equal the number of channels in the stream format. To
		/// get the number of channels, call the IAudioStreamVolume::GetChannelCount method.
		/// </param>
		/// <param name="pfVolumes">
		/// Pointer to an array of volume levels for the channels in the audio stream. This parameter points to a caller-allocated
		/// <c>float</c> array into which the method writes the volume levels for the individual channels. Volume levels are in the range 0.0
		/// to 1.0.
		/// </param>
		/// <remarks>
		/// Clients can call the IAudioStreamVolume::SetAllVolumes or IAudioStreamVolume::SetChannelVolume method to set the per-channel
		/// volume levels in an audio stream.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudiostreamvolume-getallvolumes HRESULT
		// GetAllVolumes( UINT32 dwCount, float *pfVolumes );
		void GetAllVolumes([In] uint dwCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] pfVolumes);
	}

	/// <summary>Provides APIs for associating an HWND with an audio stream.</summary>
	/// <remarks>Get an instance of the IAudioViewManagerService by calling GetService on an instance of IAudioClient.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioclient/nn-audioclient-iaudioviewmanagerservice
	[PInvokeData("audioclient.h", MSDNShortId = "NN:audioclient.IAudioViewManagerService")]
	[ComImport, Guid("A7A7EF10-1F49-45E0-AD35-612057CC8F74"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioViewManagerService
	{
		/// <summary>Associates the specified HWND window handle with an audio stream.</summary>
		/// <param name="hwnd">The HWND with which the audio stream wll be associated.</param>
		/// <remarks>
		/// <para>
		/// An app can choose to associate audio streams with a particular window of their app for proper audio location representation in a
		/// Mixed Reality scenario
		/// </para>
		/// <para>
		/// Get an instance of the IAudioViewManagerService by calling GetService on the IAudioClient instance representing the stream you
		/// want to associate a window with. The following code example illustrates creating an audio stream on the default audio render
		/// endpoint and associating it with an <c>HWND</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioviewmanagerservice-setaudiostreamwindow
		// HRESULT SetAudioStreamWindow( HWND hwnd );
		void SetAudioStreamWindow(HWND hwnd);
	}

	/// <summary>
	/// <para>
	/// The <c>IChannelAudioVolume</c> interface enables a client to control and monitor the volume levels for all of the channels in the
	/// audio session that the stream belongs to. This is the session that the client assigned the stream to during the call to the
	/// IAudioClient::Initialize method. The client obtains a reference to the <c>IChannelAudioVolume</c> interface on a stream object by
	/// calling the IAudioClient::GetService method with parameter riid set to REFIID IID_IChannelAudioVolume.
	/// </para>
	/// <para>
	/// The effective volume level of any channel in the session submix, as heard at the speakers, is the product of the following four
	/// volume-level factors:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The per-channel volume levels of the streams in the session, which clients can control through the methods in the IAudioStreamVolume interface.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The per-channel volume level of the session, which clients can control through the methods in the <c>IChannelAudioVolume</c> interface.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The master volume level of the session, which clients can control through the methods in the ISimpleAudioVolume interface.</term>
	/// </item>
	/// <item>
	/// <term>The policy-based volume level of the session, which the system dynamically assigns to the session as the global mix changes.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Each of the four volume-level factors in the preceding list is a value in the range 0.0 to 1.0, where 0.0 indicates silence and 1.0
	/// indicates full volume (no attenuation). The effective volume level is also a value in the range 0.0 to 1.0.
	/// </para>
	/// <para>
	/// Typical audio applications do not modify the volume levels of sessions. Instead, they rely on users to set these volume levels
	/// through the Sndvol program. Sndvol modifies only the master volume levels of sessions. By default, the session manager sets the
	/// per-channel volume levels to 1.0 at the initial activation of a session. Subsequent per-channel volume changes by clients are
	/// persistent across computer restarts.
	/// </para>
	/// <para>
	/// When releasing an <c>IChannelAudioVolume</c> interface instance, the client must call the interface's <c>Release</c> method from the
	/// same thread as the call to <c>IAudioClient::GetService</c> that created the object.
	/// </para>
	/// <para>
	/// The <c>IChannelAudioVolume</c> interface controls the channel volumes in an audio session. An audio session is a collection of
	/// shared-mode streams. This interface does not work with exclusive-mode streams. For information about volume controls for
	/// exclusive-mode streams, see EndpointVolume API.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nn-audioclient-ichannelaudiovolume
	[PInvokeData("audioclient.h", MSDNShortId = "0d0a20dc-5e5a-49a7-adc9-20aacb88368a")]
	[ComImport, Guid("1C158861-B533-4B30-B1CF-E853E51C59B8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IChannelAudioVolume
	{
		/// <summary>The <c>GetChannelCount</c> method retrieves the number of channels in the stream format for the audio session.</summary>
		/// <returns>A <c>UINT32</c> variable into which the method writes the channel count.</returns>
		/// <remarks>
		/// Call this method to get the number of channels in the audio session before calling any of the other methods in the
		/// IChannelAudioVolume interface.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-ichannelaudiovolume-getchannelcount HRESULT
		// GetChannelCount( UINT32 *pdwCount );
		uint GetChannelCount();

		/// <summary>The <c>SetChannelVolume</c> method sets the volume level for the specified channel in the audio session.</summary>
		/// <param name="dwIndex">
		/// The channel number. If the stream format for the audio session has N channels, the channels are numbered from 0 to N– 1. To get
		/// the number of channels, call the IChannelAudioVolume::GetChannelCount method.
		/// </param>
		/// <param name="fLevel">The volume level for the channel. Valid volume levels are in the range 0.0 to 1.0.</param>
		/// <param name="EventContext">
		/// Pointer to the event-context GUID. If a call to this method generates a channel-volume-change event, the session manager sends
		/// notifications to all clients that have registered IAudioSessionEvents interfaces with the session manager. The session manager
		/// includes the EventContext pointer value with each notification. Upon receiving a notification, a client can determine whether it
		/// or another client is the source of the event by inspecting the EventContext value. This scheme depends on the client selecting a
		/// value for this parameter that is unique among all clients in the session. If the caller supplies a <c>NULL</c> pointer for this
		/// parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// This method, if it succeeds, generates a channel-volume-change event regardless of whether the new channel volume level differs
		/// in value from the previous channel volume level.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-ichannelaudiovolume-setchannelvolume HRESULT
		// SetChannelVolume( UINT32 dwIndex, const float fLevel, LPCGUID EventContext );
		void SetChannelVolume([In] uint dwIndex, [In] float fLevel, in Guid EventContext);

		/// <summary>The <c>GetChannelVolume</c> method retrieves the volume level for the specified channel in the audio session.</summary>
		/// <param name="dwIndex">
		/// The channel number. If the stream format for the audio session has N channels, then the channels are numbered from 0 to N–
		/// 1. To get the number of channels, call the IChannelAudioVolume::GetChannelCount method.
		/// </param>
		/// <returns>
		/// A <c>float</c> variable into which the method writes the volume level of the specified channel. The volume level is in the range
		/// 0.0 to 1.0.
		/// </returns>
		/// <remarks>
		/// Clients can call the IChannelAudioVolume::SetAllVolumes or IChannelAudioVolume::SetChannelVolume method to set the per-channel
		/// volume levels in an audio session.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-ichannelaudiovolume-getchannelvolume HRESULT
		// GetChannelVolume( UINT32 dwIndex, float *pfLevel );
		float GetChannelVolume([In] uint dwIndex);

		/// <summary>The <c>SetAllVolumes</c> method sets the individual volume levels for all the channels in the audio session.</summary>
		/// <param name="dwCount">
		/// The number of elements in the pfVolumes array. This parameter must equal the number of channels in the stream format for the
		/// audio session. To get the number of channels, call the IChannelAudioVolume::GetChannelCount method.
		/// </param>
		/// <param name="pfVolumes">
		/// Pointer to an array of volume levels for the channels in the audio session. The number of elements in the pfVolumes array is
		/// specified by the dwCount parameter. The caller writes the volume level for each channel to the array element whose index matches
		/// the channel number. If the stream format for the audio session has N channels, the channels are numbered from 0 to N– 1. Valid
		/// volume levels are in the range 0.0 to 1.0.
		/// </param>
		/// <param name="EventContext">
		/// Pointer to the event-context GUID. If a call to this method generates a channel-volume-change event, the session manager sends
		/// notifications to all clients that have registered IAudioSessionEvents interfaces with the session manager. The session manager
		/// includes the EventContext pointer value with each notification. Upon receiving a notification, a client can determine whether it
		/// or another client is the source of the event by inspecting the EventContext value. This scheme depends on the client selecting a
		/// value for this parameter that is unique among all clients in the session. If the caller supplies a <c>NULL</c> pointer for this
		/// parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// This method, if it succeeds, generates a channel-volume-change event regardless of whether any of the new channel volume levels
		/// differ in value from the previous channel volume levels.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-ichannelaudiovolume-setallvolumes HRESULT
		// SetAllVolumes( UINT32 dwCount, const float *pfVolumes, LPCGUID EventContext );
		void SetAllVolumes([In] uint dwCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] pfVolumes, in Guid EventContext);

		/// <summary>The <c>GetAllVolumes</c> method retrieves the volume levels for all the channels in the audio session.</summary>
		/// <param name="dwCount">
		/// The number of elements in the pfVolumes array. The dwCount parameter must equal the number of channels in the stream format for
		/// the audio session. To get the number of channels, call the IChannelAudioVolume::GetChannelCount method.
		/// </param>
		/// <param name="pfVolumes">
		/// Pointer to an array of volume levels for the channels in the audio session. This parameter points to a caller-allocated
		/// <c>float</c> array into which the method writes the volume levels for the individual channels. Volume levels are in the range 0.0
		/// to 1.0.
		/// </param>
		/// <remarks>
		/// Clients can call the IChannelAudioVolume::SetAllVolumes or IChannelAudioVolume::SetChannelVolume method to set the per-channel
		/// volume levels in an audio session.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-ichannelaudiovolume-getallvolumes HRESULT
		// GetAllVolumes( UINT32 dwCount, float *pfVolumes );
		void GetAllVolumes([In] uint dwCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] pfVolumes);
	}

	/// <summary>
	/// <para>
	/// The <c>ISimpleAudioVolume</c> interface enables a client to control the master volume level of an audio session. The
	/// IAudioClient::Initialize method initializes a stream object and assigns the stream to an audio session. The client obtains a
	/// reference to the <c>ISimpleAudioVolume</c> interface on a stream object by calling the IAudioClient::GetService method with parameter
	/// riid set to <c>REFIID</c> IID_ISimpleAudioVolume.
	/// </para>
	/// <para>
	/// Alternatively, a client can obtain the <c>ISimpleAudioVolume</c> interface of an existing session without having to first create a
	/// stream object and add the stream to the session. Instead, the client calls the IAudioSessionManager::GetSimpleAudioVolume method with
	/// the session GUID.
	/// </para>
	/// <para>
	/// The effective volume level of any channel in the session submix, as heard at the speakers, is the product of the following four
	/// volume-level factors:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The per-channel volume levels of the streams in the session, which clients can control through the methods in the IAudioStreamVolume interface.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The master volume level of the session, which clients can control through the methods in the <c>ISimpleAudioVolume</c> interface.</term>
	/// </item>
	/// <item>
	/// <term>The per-channel volume level of the session, which clients can control through the methods in the IChannelAudioVolume interface.</term>
	/// </item>
	/// <item>
	/// <term>The policy-based volume level of the session, which the system dynamically assigns to the session as the global mix changes.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Each of the four volume-level factors in the preceding list is a value in the range 0.0 to 1.0, where 0.0 indicates silence and 1.0
	/// indicates full volume (no attenuation). The effective volume level is also a value in the range 0.0 to 1.0.
	/// </para>
	/// <para>
	/// Typical audio applications do not modify the volume levels of sessions. Instead, they rely on users to set these volume levels
	/// through the Sndvol program. Sndvol modifies only the master volume levels of sessions. By default, the session manager sets the
	/// master volume level to 1.0 at the initial activation of a session. Subsequent volume changes by Sndvol or other clients are
	/// persistent across computer restarts.
	/// </para>
	/// <para>
	/// When releasing an <c>ISimpleAudioVolume</c> interface instance, the client must call the interface's <c>Release</c> method from the
	/// same thread as the call to <c>IAudioClient::GetService</c> that created the object.
	/// </para>
	/// <para>
	/// The <c>ISimpleAudioVolume</c> interface controls the volume of an audio session. An audio session is a collection of shared-mode
	/// streams. This interface does not work with exclusive-mode streams. For information about volume controls for exclusive-mode streams,
	/// see EndpointVolume API.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nn-audioclient-isimpleaudiovolume
	[PInvokeData("audioclient.h", MSDNShortId = "360211f2-de82-4ff5-896c-dee1d60cb7b7")]
	[ComImport, Guid("87CE5498-68D6-44E5-9215-6DA47EF883D8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISimpleAudioVolume
	{
		/// <summary>The <c>SetMasterVolume</c> method sets the master volume level for the audio session.</summary>
		/// <param name="fLevel">The new master volume level. Valid volume levels are in the range 0.0 to 1.0.</param>
		/// <param name="EventContext">
		/// Pointer to the event-context GUID. If a call to this method generates a volume-change event, the session manager sends
		/// notifications to all clients that have registered IAudioSessionEvents interfaces with the session manager. The session manager
		/// includes the EventContext pointer value with each notification. Upon receiving a notification, a client can determine whether it
		/// or another client is the source of the event by inspecting the EventContext value. This scheme depends on the client selecting a
		/// value for this parameter that is unique among all clients in the session. If the caller supplies a <c>NULL</c> pointer for this
		/// parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// This method generates a volume-change event only if the method call changes the volume level of the session. For example, if the
		/// volume level is 0.4 when the call occurs, and the call sets the volume level to 0.4, no event is generated.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-isimpleaudiovolume-setmastervolume HRESULT
		// SetMasterVolume( float fLevel, LPCGUID EventContext );
		void SetMasterVolume([In] float fLevel, in Guid EventContext);

		/// <summary>The <c>GetMasterVolume</c> method retrieves the client volume level for the audio session.</summary>
		/// <returns>
		/// A <c>float</c> variable into which the method writes the client volume level. The volume level is a value in the range 0.0 to 1.0.
		/// </returns>
		/// <remarks>
		/// This method retrieves the client volume level for the session. This is the volume level that the client set in a previous call to
		/// the ISimpleAudioVolume::SetMasterVolume method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-isimpleaudiovolume-getmastervolume HRESULT
		// GetMasterVolume( float *pfLevel );
		float GetMasterVolume();

		/// <summary>The <c>SetMute</c> method sets the muting state for the audio session.</summary>
		/// <param name="bMute">The new muting state. <c>TRUE</c> enables muting. <c>FALSE</c> disables muting.</param>
		/// <param name="EventContext">
		/// Pointer to the event-context GUID. If a call to this method generates a volume-change event, the session manager sends
		/// notifications to all clients that have registered IAudioSessionEvents interfaces with the session manager. The session manager
		/// includes the EventContext pointer value with each notification. Upon receiving a notification, a client can determine whether it
		/// or another client is the source of the event by inspecting the EventContext value. This scheme depends on the client selecting a
		/// value for this parameter that is unique among all clients in the session. If the caller supplies a <c>NULL</c> pointer for this
		/// parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method generates a volume-change event only if the method call changes the muting state of the session from disabled to
		/// enabled, or from enabled to disabled. For example, if muting is enabled when the call occurs, and the call enables muting, no
		/// event is generated.
		/// </para>
		/// <para>
		/// This method applies the same muting state to all channels in the audio session. The endpoint device always applies muting
		/// uniformly across all the channels in the session. There are no IChannelAudioVolume methods for setting the muting states of
		/// individual channels.
		/// </para>
		/// <para>The client can get the muting state of the audio session by calling the SimpleAudioVolume::GetMute method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-isimpleaudiovolume-setmute HRESULT SetMute( const
		// BOOL bMute, LPCGUID EventContext );
		void SetMute([In][MarshalAs(UnmanagedType.Bool)] bool bMute, in Guid EventContext);

		/// <summary>The <c>GetMute</c> method retrieves the current muting state for the audio session.</summary>
		/// <returns>
		/// A <c>BOOL</c> variable into which the method writes the muting state. <c>TRUE</c> indicates that muting is enabled. <c>FALSE</c>
		/// indicates that it is disabled.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-isimpleaudiovolume-getmute HRESULT GetMute( BOOL
		// *pbMute );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetMute();
	}

	/// <summary>Gets the current list of audio effects for the associated audio stream.</summary>
	/// <param name="mgr">The <see cref="IAudioEffectsManager"/> instance.</param>
	/// <returns>An array of AUDIO_EFFECT structures representing the current list of audio effects.</returns>
	/// <remarks>Register an IAudioEffectsChangedNotificationClient to receive notifications when the list of audio effects changes.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioeffectsmanager-getaudioeffects HRESULT
	// GetAudioEffects( AUDIO_EFFECT **effects, UINT32 *numEffects );
	public static AUDIO_EFFECT[] GetAudioEffects(this IAudioEffectsManager mgr)
	{
		mgr.GetAudioEffects(out SafeCoTaskMemHandle eff, out uint c);
		return eff.ToArray<AUDIO_EFFECT>((int)c) ?? new AUDIO_EFFECT[0];
	}

	/// <summary>
	/// Returns the current format and periodicity of the audio engine. This method enables audio clients to match the current period of the
	/// audio engine.
	/// </summary>
	/// <param name="client">The client.</param>
	/// <returns>
	/// <para>A tuple:</para>
	/// <para><c>ppFormat</c> - Type: <c>WAVEFORMATEX</c></para>
	/// <para>The current device format that is being used by the audio engine.</para>
	/// <para><c>pCurrentPeriodInFrames</c> - Type: <c>UINT32</c></para>
	/// <para>The current period of the audio engine, in audio frames.</para>
	/// </returns>
	/// <remarks>
	/// <c>Note</c> The values returned by this method are instantaneous values and may be invalid immediately after the call returns if, for
	/// example, another audio client sets the periodicity or format to a different value.
	/// </remarks>
	public static (WAVEFORMATEX ppFormat, uint pCurrentPeriodInFrames) GetCurrentSharedModeEnginePeriod(this IAudioClient3 client)
	{
		client.GetCurrentSharedModeEnginePeriod(out SafeCoTaskMemHandle fmt, out uint fr);
		return (fmt.ToStructure<WAVEFORMATEX>(), fr);
	}

	/// <summary>The <c>GetService</c> method accesses additional services from the audio client object.</summary>
	/// <param name="client">The client.</param>
	/// <returns>
	/// Pointer to a variable into which the method writes the address of an instance of the requested interface. Through this method, the
	/// caller obtains a counted reference to the interface. The caller is responsible for releasing the interface, when it is no longer
	/// needed, by calling the interface's <c>Release</c> method. If the <c>GetService</c> call fails, *ppv is <c>NULL</c>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This method requires prior initialization of the IAudioClient interface. All calls to this method will fail with the error
	/// AUDCLNT_E_NOT_INITIALIZED until the client initializes the audio stream by successfully calling the IAudioClient::Initialize method.
	/// </para>
	/// <para>The <c>GetService</c> method supports the following service interfaces:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>IAudioCaptureClient</term>
	/// </item>
	/// <item>
	/// <term>IAudioClock</term>
	/// </item>
	/// <item>
	/// <term>IAudioRenderClient</term>
	/// </item>
	/// <item>
	/// <term>IAudioSessionControl</term>
	/// </item>
	/// <item>
	/// <term>IAudioStreamVolume</term>
	/// </item>
	/// <item>
	/// <term>IChannelAudioVolume</term>
	/// </item>
	/// <item>
	/// <term>IMFTrustedOutput</term>
	/// </item>
	/// <item>
	/// <term>ISimpleAudioVolume</term>
	/// </item>
	/// </list>
	/// <para>
	/// In Windows 7, a new service identifier, <c>IID_IMFTrustedOutput</c>, has been added that facilitates the use of output trust
	/// authority (OTA) objects. These objects can operate inside or outside the Media Foundation's protected media path (PMP) and send
	/// content outside the Media Foundation pipeline. If the caller is outside PMP, then the OTA may not operate in the PMP, and the
	/// protection settings are less robust. OTAs must implement the IMFTrustedOutput interface. By passing <c>IID_IMFTrustedOutput</c> in
	/// <c>GetService</c>, an application can retrieve a pointer to the object's <c>IMFTrustedOutput</c> interface. For more information
	/// about protected objects and <c>IMFTrustedOutput</c>, see "Protected Media Path" in the Media Foundation SDK documentation.
	/// </para>
	/// <para>For information about using trusted audio drivers in OTAs, see Protected User Mode Audio (PUMA).</para>
	/// <para>
	/// Note that activating IMFTrustedOutput through this mechanism works regardless of whether the caller is running in PMP. However, if
	/// the caller is not running in a protected process (that is, the caller is not within Media Foundation's PMP) then the audio OTA might
	/// not operate in the PMP and the protection settings are less robust.
	/// </para>
	/// <para>
	/// To obtain the interface ID for a service interface, use the <c>__uuidof</c> operator. For example, the interface ID of
	/// <c>IAudioCaptureClient</c> is defined as follows:
	/// </para>
	/// <para>For information about the <c>__uuidof</c> operator, see the Windows SDK documentation.</para>
	/// <para>
	/// To release the <c>IAudioClient</c> object and free all its associated resources, the client must release all references to any
	/// service objects that were created by calling <c>GetService</c>, in addition to calling <c>Release</c> on the <c>IAudioClient</c>
	/// interface itself. The client must release a service from the same thread that releases the <c>IAudioClient</c> object.
	/// </para>
	/// <para>
	/// The <c>IAudioSessionControl</c>, <c>IAudioStreamVolume</c>, <c>IChannelAudioVolume</c>, and <c>ISimpleAudioVolume</c> interfaces
	/// control and monitor aspects of audio sessions and shared-mode streams. These interfaces do not work with exclusive-mode streams.
	/// </para>
	/// <para>For code examples that call the <c>GetService</c> method, see the following topics:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Rendering a Stream</term>
	/// </item>
	/// <item>
	/// <term>Capturing a Stream</term>
	/// </item>
	/// </list>
	/// </remarks>
	public static T GetService<T>(this IAudioClient client) => (T)client.GetService(typeof(T).GUID);

	/// <summary>The <c>Initialize</c> method initializes the audio stream.</summary>
	/// <param name="client">The client.</param>
	/// <param name="ShareMode">
	/// <para>
	/// The sharing mode for the connection. Through this parameter, the client tells the audio engine whether it wants to share the audio
	/// endpoint device with other clients. The client should set this parameter to one of the following AUDCLNT_SHAREMODE enumeration values:
	/// </para>
	/// <para>AUDCLNT_SHAREMODE_EXCLUSIVE</para>
	/// <para>AUDCLNT_SHAREMODE_SHARED</para>
	/// </param>
	/// <param name="StreamFlags">
	/// Flags to control creation of the stream. The client should set this parameter to 0 or to the bitwise OR of one or more of the
	/// AUDCLNT_STREAMFLAGS_XXX Constants or the AUDCLNT_SESSIONFLAGS_XXX Constants.
	/// </param>
	/// <param name="hnsBufferDuration">
	/// The buffer capacity as a time value. This parameter is of type <c>REFERENCE_TIME</c> and is expressed in 100-nanosecond units. This
	/// parameter contains the buffer size that the caller requests for the buffer that the audio application will share with the audio
	/// engine (in shared mode) or with the endpoint device (in exclusive mode). If the call succeeds, the method allocates a buffer that is
	/// a least this large. For more information about <c>REFERENCE_TIME</c>, see the Windows SDK documentation. For more information about
	/// buffering requirements, see Remarks.
	/// </param>
	/// <param name="hnsPeriodicity">
	/// The device period. This parameter can be nonzero only in exclusive mode. In shared mode, always set this parameter to 0. In exclusive
	/// mode, this parameter specifies the requested scheduling period for successive buffer accesses by the audio endpoint device. If the
	/// requested device period lies outside the range that is set by the device's minimum period and the system's maximum period, then the
	/// method clamps the period to that range. If this parameter is 0, the method sets the device period to its default value. To obtain the
	/// default device period, call the IAudioClient::GetDevicePeriod method. If the AUDCLNT_STREAMFLAGS_EVENTCALLBACK stream flag is set and
	/// AUDCLNT_SHAREMODE_EXCLUSIVE is set as the ShareMode, then hnsPeriodicity must be nonzero and equal to hnsBufferDuration.
	/// </param>
	/// <param name="pFormat">
	/// Pointer to a format descriptor. This parameter must point to a valid format descriptor of type <c>WAVEFORMATEX</c> (or
	/// <c>WAVEFORMATEXTENSIBLE</c>). For more information, see Remarks.
	/// </param>
	/// <param name="AudioSessionGuid">
	/// Pointer to a session GUID. This parameter points to a GUID value that identifies the audio session that the stream belongs to. If the
	/// GUID identifies a session that has been previously opened, the method adds the stream to that session. If the GUID does not identify
	/// an existing session, the method opens a new session and adds the stream to that session. The stream remains a member of the same
	/// session for its lifetime. Setting this parameter to <c>NULL</c> is equivalent to passing a pointer to a GUID_NULL value.
	/// </param>
	/// <returns>
	/// <para>
	/// If the method succeeds, it returns S_OK. If it fails, possible return codes include, but are not limited to, the values shown in the
	/// following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>AUDCLNT_E_ALREADY_INITIALIZED</term>
	/// <term>The IAudioClient object is already initialized.</term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_WRONG_ENDPOINT_TYPE</term>
	/// <term>The AUDCLNT_STREAMFLAGS_LOOPBACK flag is set but the endpoint device is a capture device, not a rendering device.</term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED</term>
	/// <term>
	/// The requested buffer size is not aligned. This code can be returned for a render or a capture device if the caller specified
	/// AUDCLNT_SHAREMODE_EXCLUSIVE and the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flags. The caller must call Initialize again with the aligned
	/// buffer size. For more information, see Remarks.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_BUFFER_SIZE_ERROR</term>
	/// <term>
	/// Indicates that the buffer duration value requested by an exclusive-mode client is out of range. The requested duration value for pull
	/// mode must not be greater than 500 milliseconds; for push mode the duration value must not be greater than 2 seconds.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_CPUUSAGE_EXCEEDED</term>
	/// <term>
	/// Indicates that the process-pass duration exceeded the maximum CPU usage. The audio engine keeps track of CPU usage by maintaining the
	/// number of times the process-pass duration exceeds the maximum CPU usage. The maximum CPU usage is calculated as a percent of the
	/// engine's periodicity. The percentage value is the system's CPU throttle value (within the range of 10% and 90%). If this value is not
	/// found, then the default value of 40% is used to calculate the maximum CPU usage.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
	/// <term>
	/// The audio endpoint device has been unplugged, or the audio hardware or associated hardware resources have been reconfigured,
	/// disabled, removed, or otherwise made unavailable for use.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_DEVICE_IN_USE</term>
	/// <term>
	/// The endpoint device is already in use. Either the device is being used in exclusive mode, or the device is being used in shared mode
	/// and the caller asked to use the device in exclusive mode.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_ENDPOINT_CREATE_FAILED</term>
	/// <term>
	/// The method failed to create the audio endpoint for the render or the capture device. This can occur if the audio endpoint device has
	/// been unplugged, or the audio hardware or associated hardware resources have been reconfigured, disabled, removed, or otherwise made
	/// unavailable for use.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_INVALID_DEVICE_PERIOD</term>
	/// <term>Indicates that the device period requested by an exclusive-mode client is greater than 500 milliseconds.</term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_UNSUPPORTED_FORMAT</term>
	/// <term>The audio engine (shared mode) or audio endpoint device (exclusive mode) does not support the specified format.</term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_EXCLUSIVE_MODE_NOT_ALLOWED</term>
	/// <term>The caller is requesting exclusive-mode use of the endpoint device, but the user has disabled exclusive-mode use of the device.</term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_BUFDURATION_PERIOD_NOT_EQUAL</term>
	/// <term>The AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag is set but parameters hnsBufferDuration and hnsPeriodicity are not equal.</term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_SERVICE_NOT_RUNNING</term>
	/// <term>The Windows audio service is not running.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>Parameter pFormat is NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// Parameter pFormat points to an invalid format description; or the AUDCLNT_STREAMFLAGS_LOOPBACK flag is set but ShareMode is not equal
	/// to AUDCLNT_SHAREMODE_SHARED; or the AUDCLNT_STREAMFLAGS_CROSSPROCESS flag is set but ShareMode is equal to
	/// AUDCLNT_SHAREMODE_EXCLUSIVE. A prior call to SetClientProperties was made with an invalid category for audio/render streams.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Out of memory.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// After activating an IAudioClient interface on an audio endpoint device, the client must successfully call <c>Initialize</c> once and
	/// only once to initialize the audio stream between the client and the device. The client can either connect directly to the audio
	/// hardware (exclusive mode) or indirectly through the audio engine (shared mode). In the <c>Initialize</c> call, the client specifies
	/// the audio data format, the buffer size, and audio session for the stream.
	/// </para>
	/// <para>
	/// <c>Note</c> In Windows 8, the first use of IAudioClient to access the audio device should be on the STA thread. Calls from an MTA
	/// thread may result in undefined behavior.
	/// </para>
	/// <para>
	/// An attempt to create a shared-mode stream can succeed only if the audio device is already operating in shared mode or the device is
	/// currently unused. An attempt to create a shared-mode stream fails if the device is already operating in exclusive mode.
	/// </para>
	/// <para>
	/// If a stream is initialized to be event driven and in shared mode, ShareMode is set to AUDCLNT_SHAREMODE_SHARED and one of the stream
	/// flags that are set includes AUDCLNT_STREAMFLAGS_EVENTCALLBACK. For such a stream, the associated application must also obtain a
	/// handle by making a call to IAudioClient::SetEventHandle. When it is time to retire the stream, the audio engine can then use the
	/// handle to release the stream objects. Failure to call <c>IAudioClient::SetEventHandle</c> before releasing the stream objects can
	/// cause a delay of several seconds (a time-out period) while the audio engine waits for an available handle. After the time-out period
	/// expires, the audio engine then releases the stream objects.
	/// </para>
	/// <para>
	/// Whether an attempt to create an exclusive-mode stream succeeds depends on several factors, including the availability of the device
	/// and the user-controlled settings that govern exclusive-mode operation of the device. For more information, see Exclusive-Mode Streams.
	/// </para>
	/// <para>
	/// An <c>IAudioClient</c> object supports exactly one connection to the audio engine or audio hardware. This connection lasts for the
	/// lifetime of the <c>IAudioClient</c> object.
	/// </para>
	/// <para>The client should call the following methods only after calling <c>Initialize</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>IAudioClient::GetBufferSize</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::GetCurrentPadding</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::GetService</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::GetStreamLatency</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::Reset</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::SetEventHandle</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::Start</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::Stop</term>
	/// </item>
	/// </list>
	/// <para>The following methods do not require that <c>Initialize</c> be called first:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>IAudioClient::GetDevicePeriod</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::GetMixFormat</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::IsFormatSupported</term>
	/// </item>
	/// </list>
	/// <para>These methods can be called any time after activating the <c>IAudioClient</c> interface.</para>
	/// <para>
	/// Before calling <c>Initialize</c> to set up a shared-mode or exclusive-mode connection, the client can call the
	/// IAudioClient::IsFormatSupported method to discover whether the audio engine or audio endpoint device supports a particular format in
	/// that mode. Before opening a shared-mode connection, the client can obtain the audio engine's mix format by calling the
	/// IAudioClient::GetMixFormat method.
	/// </para>
	/// <para>
	/// The endpoint buffer that is shared between the client and audio engine must be large enough to prevent glitches from occurring in the
	/// audio stream between processing passes by the client and audio engine. For a rendering endpoint, the client thread periodically
	/// writes data to the buffer, and the audio engine thread periodically reads data from the buffer. For a capture endpoint, the engine
	/// thread periodically writes to the buffer, and the client thread periodically reads from the buffer. In either case, if the periods of
	/// the client thread and engine thread are not equal, the buffer must be large enough to accommodate the longer of the two periods
	/// without allowing glitches to occur.
	/// </para>
	/// <para>
	/// The client specifies a buffer size through the hnsBufferDuration parameter. The client is responsible for requesting a buffer that is
	/// large enough to ensure that glitches cannot occur between the periodic processing passes that it performs on the buffer. Similarly,
	/// the <c>Initialize</c> method ensures that the buffer is never smaller than the minimum buffer size needed to ensure that glitches do
	/// not occur between the periodic processing passes that the engine thread performs on the buffer. If the client requests a buffer size
	/// that is smaller than the audio engine's minimum required buffer size, the method sets the buffer size to this minimum buffer size
	/// rather than to the buffer size requested by the client.
	/// </para>
	/// <para>
	/// If the client requests a buffer size (through the hnsBufferDuration parameter) that is not an integral number of audio frames, the
	/// method rounds up the requested buffer size to the next integral number of frames.
	/// </para>
	/// <para>
	/// Following the <c>Initialize</c> call, the client should call the IAudioClient::GetBufferSize method to get the precise size of the
	/// endpoint buffer. During each processing pass, the client will need the actual buffer size to calculate how much data to transfer to
	/// or from the buffer. The client calls the IAudioClient::GetCurrentPadding method to determine how much of the data in the buffer is
	/// currently available for processing.
	/// </para>
	/// <para>
	/// To achieve the minimum stream latency between the client application and audio endpoint device, the client thread should run at the
	/// same period as the audio engine thread. The period of the engine thread is fixed and cannot be controlled by the client. Making the
	/// client's period smaller than the engine's period unnecessarily increases the client thread's load on the processor without improving
	/// latency or decreasing the buffer size. To determine the period of the engine thread, the client can call the
	/// IAudioClient::GetDevicePeriod method. To set the buffer to the minimum size required by the engine thread, the client should call
	/// <c>Initialize</c> with the hnsBufferDuration parameter set to 0. Following the <c>Initialize</c> call, the client can get the size of
	/// the resulting buffer by calling <c>IAudioClient::GetBufferSize</c>.
	/// </para>
	/// <para>
	/// A client has the option of requesting a buffer size that is larger than what is strictly necessary to make timing glitches rare or
	/// nonexistent. Increasing the buffer size does not necessarily increase the stream latency. For a rendering stream, the latency through
	/// the buffer is determined solely by the separation between the client's write pointer and the engine's read pointer. For a capture
	/// stream, the latency through the buffer is determined solely by the separation between the engine's write pointer and the client's
	/// read pointer.
	/// </para>
	/// <para>
	/// The loopback flag (AUDCLNT_STREAMFLAGS_LOOPBACK) enables audio loopback. A client can enable audio loopback only on a rendering
	/// endpoint with a shared-mode stream. Audio loopback is provided primarily to support acoustic echo cancellation (AEC).
	/// </para>
	/// <para>
	/// An AEC client requires both a rendering endpoint and the ability to capture the output stream from the audio engine. The engine's
	/// output stream is the global mix that the audio device plays through the speakers. If audio loopback is enabled, a client can open a
	/// capture buffer for the global audio mix by calling the IAudioClient::GetService method to obtain an IAudioCaptureClient interface on
	/// the rendering stream object. If audio loopback is not enabled, then an attempt to open a capture buffer on a rendering stream will
	/// fail. The loopback data in the capture buffer is in the device format, which the client can obtain by querying the device's
	/// PKEY_AudioEngine_DeviceFormat property.
	/// </para>
	/// <para>
	/// On Windows versions prior to Windows 10, a pull-mode capture client will not receive any events when a stream is initialized with
	/// event-driven buffering (AUDCLNT_STREAMFLAGS_EVENTCALLBACK) and is loopback-enabled (AUDCLNT_STREAMFLAGS_LOOPBACK). If the stream is
	/// opened with this configuration, the <c>Initialize</c> call succeeds, but relevant events are not raised to notify the capture client
	/// each time a buffer becomes ready for processing. To work around this, initialize a render stream in event-driven mode. Each time the
	/// client receives an event for the render stream, it must signal the capture client to run the capture thread that reads the next set
	/// of samples from the capture endpoint buffer. As of Windows 10 the relevant event handles are now set for loopback-enabled streams
	/// that are active.
	/// </para>
	/// <para>
	/// Note that all streams must be opened in share mode because exclusive-mode streams cannot operate in loopback mode. For more
	/// information about audio loopback, see Loopback Recording.
	/// </para>
	/// <para>
	/// The AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag indicates that processing of the audio buffer by the client will be event driven. WASAPI
	/// supports event-driven buffering to enable low-latency processing of both shared-mode and exclusive-mode streams.
	/// </para>
	/// <para>
	/// The initial release of Windows Vista supports event-driven buffering (that is, the use of the AUDCLNT_STREAMFLAGS_EVENTCALLBACK
	/// flag) for rendering streams only.
	/// </para>
	/// <para>
	/// In the initial release of Windows Vista, for capture streams, the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag is supported only in shared
	/// mode. Setting this flag has no effect for exclusive-mode capture streams. That is, although the application specifies this flag in
	/// exclusive mode through the <c>Initialize</c> call, the application will not receive any events that are usually required to capture
	/// the audio stream. In the Windows Vista Service Pack 1 release, this flag is functional in shared-mode and exclusive mode; an
	/// application can set this flag to enable event-buffering for capture streams. For more information about capturing an audio stream,
	/// see Capturing a Stream.
	/// </para>
	/// <para>
	/// To enable event-driven buffering, the client must provide an event handle to the system. Following the <c>Initialize</c> call and
	/// before calling the IAudioClient::Start method to start the stream, the client must call the IAudioClient::SetEventHandle method to
	/// set the event handle. While the stream is running, the system periodically signals the event to indicate to the client that audio
	/// data is available for processing. Between processing passes, the client thread waits on the event handle by calling a synchronization
	/// function such as <c>WaitForSingleObject</c>. For more information about synchronization functions, see the Windows SDK documentation.
	/// </para>
	/// <para>
	/// For a shared-mode stream that uses event-driven buffering, the caller must set both hnsPeriodicity and hnsBufferDuration to 0. The
	/// <c>Initialize</c> method determines how large a buffer to allocate based on the scheduling period of the audio engine. Although the
	/// client's buffer processing thread is event driven, the basic buffer management process, as described previously, is unaltered. Each
	/// time the thread awakens, it should call IAudioClient::GetCurrentPadding to determine how much data to write to a rendering buffer or
	/// read from a capture buffer. In contrast to the two buffers that the <c>Initialize</c> method allocates for an exclusive-mode stream
	/// that uses event-driven buffering, a shared-mode stream requires a single buffer.
	/// </para>
	/// <para>
	/// For an exclusive-mode stream that uses event-driven buffering, the caller must specify nonzero values for hnsPeriodicity and
	/// hnsBufferDuration, and the values of these two parameters must be equal. The <c>Initialize</c> method allocates two buffers for the
	/// stream. Each buffer is equal in duration to the value of the hnsBufferDuration parameter. Following the <c>Initialize</c> call for a
	/// rendering stream, the caller should fill the first of the two buffers before starting the stream. For a capture stream, the buffers
	/// are initially empty, and the caller should assume that each buffer remains empty until the event for that buffer is signaled. While
	/// the stream is running, the system alternately sends one buffer or the other to the client—this form of double buffering is referred
	/// to as "ping-ponging". Each time the client receives a buffer from the system (which the system indicates by signaling the event), the
	/// client must process the entire buffer. For example, if the client requests a packet size from the IAudioRenderClient::GetBuffer
	/// method that does not match the buffer size, the method fails. Calls to the <c>IAudioClient::GetCurrentPadding</c> method are
	/// unnecessary because the packet size must always equal the buffer size. In contrast to the buffering modes discussed previously, the
	/// latency for an event-driven, exclusive-mode stream depends directly on the buffer size.
	/// </para>
	/// <para>
	/// As explained in Audio Sessions, the default behavior for a session that contains rendering streams is that its volume and mute
	/// settings persist across system restarts. The AUDCLNT_STREAMFLAGS_NOPERSIST flag overrides the default behavior and makes the settings
	/// nonpersistent. This flag has no effect on sessions that contain capture streams—the settings for those sessions are never persistent.
	/// In addition, the settings for a session that contains a loopback stream (a stream that is initialized with the
	/// AUDCLNT_STREAMFLAGS_LOOPBACK flag) are not persistent.
	/// </para>
	/// <para>
	/// Only a session that connects to a rendering endpoint device can have persistent volume and mute settings. The first stream to be
	/// added to the session determines whether the session's settings are persistent. Thus, if the AUDCLNT_STREAMFLAGS_NOPERSIST or
	/// AUDCLNT_STREAMFLAGS_LOOPBACK flag is set during initialization of the first stream, the session's settings are not persistent.
	/// Otherwise, they are persistent. Their persistence is unaffected by additional streams that might be subsequently added or removed
	/// during the lifetime of the session object.
	/// </para>
	/// <para>
	/// After a call to <c>Initialize</c> has successfully initialized an <c>IAudioClient</c> interface instance, a subsequent
	/// <c>Initialize</c> call to initialize the same interface instance will fail and return error code E_ALREADY_INITIALIZED.
	/// </para>
	/// <para>
	/// If the initial call to <c>Initialize</c> fails, subsequent <c>Initialize</c> calls might fail and return error code
	/// E_ALREADY_INITIALIZED, even though the interface has not been initialized. If this occurs, release the <c>IAudioClient</c> interface
	/// and obtain a new <c>IAudioClient</c> interface from the MMDevice API before calling <c>Initialize</c> again.
	/// </para>
	/// <para>For code examples that call the <c>Initialize</c> method, see the following topics:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Rendering a Stream</term>
	/// </item>
	/// <item>
	/// <term>Capturing a Stream</term>
	/// </item>
	/// <item>
	/// <term>Exclusive-Mode Streams</term>
	/// </item>
	/// </list>
	/// <para>
	/// Starting with Windows 7, <c>Initialize</c> can return AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED for a render or a capture device. This
	/// indicates that the buffer size, specified by the caller in the hnsBufferDuration parameter, is not aligned. This error code is
	/// returned only if the caller requested an exclusive-mode stream (AUDCLNT_SHAREMODE_EXCLUSIVE) and event-driven buffering (AUDCLNT_STREAMFLAGS_EVENTCALLBACK).
	/// </para>
	/// <para>
	/// If <c>Initialize</c> returns AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED, the caller must call <c>Initialize</c> again and specify the aligned
	/// buffer size. Use the following steps:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>Call IAudioClient::GetBufferSize and receive the next-highest-aligned buffer size (in frames).</term>
	/// </item>
	/// <item>
	/// <term>Call <c>IAudioClient::Release</c> to release the audio client used in the previous call that returned AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Calculate the aligned buffer size in 100-nansecond units (hns). The buffer size is . In this formula, is the buffer size retrieved by GetBufferSize.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Call the IMMDevice::Activate method with parameter iid set to REFIID IID_IAudioClient to create a new audio client.</term>
	/// </item>
	/// <item>
	/// <term>Call <c>Initialize</c> again on the created audio client and specify the new buffer size and periodicity.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Starting with Windows 10, hardware-offloaded audio streams must be event driven. This means that if you call
	/// IAudioClient2::SetClientProperties and set the bIsOffload parameter of the AudioClientProperties to TRUE, you must specify the
	/// <c>AUDCLNT_STREAMFLAGS_EVENTCALLBACK</c> flag in the StreamFlags parameter to <c>IAudioClient::Initialize</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example code shows how to respond to the <c>AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED</c> return code.</para>
	/// </remarks>
	public static HRESULT Initialize(this IAudioClient client, [In] AUDCLNT_SHAREMODE ShareMode, AUDCLNT_STREAMFLAGS StreamFlags, long hnsBufferDuration, long hnsPeriodicity, in WAVEFORMATEX pFormat, [In, Optional] in Guid AudioSessionGuid)
	{
		using SafeCoTaskMemHandle mem = SafeCoTaskMemHandle.CreateFromStructure(pFormat);
		return client.Initialize(ShareMode, StreamFlags, hnsBufferDuration, hnsPeriodicity, mem, AudioSessionGuid);
	}

	/// <summary>The <c>Initialize</c> method initializes the audio stream.</summary>
	/// <param name="client">The client.</param>
	/// <param name="ShareMode">
	/// <para>
	/// The sharing mode for the connection. Through this parameter, the client tells the audio engine whether it wants to share the audio
	/// endpoint device with other clients. The client should set this parameter to one of the following AUDCLNT_SHAREMODE enumeration values:
	/// </para>
	/// <para>AUDCLNT_SHAREMODE_EXCLUSIVE</para>
	/// <para>AUDCLNT_SHAREMODE_SHARED</para>
	/// </param>
	/// <param name="StreamFlags">
	/// Flags to control creation of the stream. The client should set this parameter to 0 or to the bitwise OR of one or more of the
	/// AUDCLNT_STREAMFLAGS_XXX Constants or the AUDCLNT_SESSIONFLAGS_XXX Constants.
	/// </param>
	/// <param name="hnsBufferDuration">
	/// The buffer capacity as a time value. This parameter is of type <c>REFERENCE_TIME</c> and is expressed in 100-nanosecond units. This
	/// parameter contains the buffer size that the caller requests for the buffer that the audio application will share with the audio
	/// engine (in shared mode) or with the endpoint device (in exclusive mode). If the call succeeds, the method allocates a buffer that is
	/// a least this large. For more information about <c>REFERENCE_TIME</c>, see the Windows SDK documentation. For more information about
	/// buffering requirements, see Remarks.
	/// </param>
	/// <param name="hnsPeriodicity">
	/// The device period. This parameter can be nonzero only in exclusive mode. In shared mode, always set this parameter to 0. In exclusive
	/// mode, this parameter specifies the requested scheduling period for successive buffer accesses by the audio endpoint device. If the
	/// requested device period lies outside the range that is set by the device's minimum period and the system's maximum period, then the
	/// method clamps the period to that range. If this parameter is 0, the method sets the device period to its default value. To obtain the
	/// default device period, call the IAudioClient::GetDevicePeriod method. If the AUDCLNT_STREAMFLAGS_EVENTCALLBACK stream flag is set and
	/// AUDCLNT_SHAREMODE_EXCLUSIVE is set as the ShareMode, then hnsPeriodicity must be nonzero and equal to hnsBufferDuration.
	/// </param>
	/// <param name="pFormat">
	/// Pointer to a format descriptor. This parameter must point to a valid format descriptor of type <c>WAVEFORMATEX</c> (or
	/// <c>WAVEFORMATEXTENSIBLE</c>). For more information, see Remarks.
	/// </param>
	/// <param name="AudioSessionGuid">
	/// Pointer to a session GUID. This parameter points to a GUID value that identifies the audio session that the stream belongs to. If the
	/// GUID identifies a session that has been previously opened, the method adds the stream to that session. If the GUID does not identify
	/// an existing session, the method opens a new session and adds the stream to that session. The stream remains a member of the same
	/// session for its lifetime. Setting this parameter to <c>NULL</c> is equivalent to passing a pointer to a GUID_NULL value.
	/// </param>
	/// <returns>
	/// <para>
	/// If the method succeeds, it returns S_OK. If it fails, possible return codes include, but are not limited to, the values shown in the
	/// following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>AUDCLNT_E_ALREADY_INITIALIZED</term>
	/// <term>The IAudioClient object is already initialized.</term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_WRONG_ENDPOINT_TYPE</term>
	/// <term>The AUDCLNT_STREAMFLAGS_LOOPBACK flag is set but the endpoint device is a capture device, not a rendering device.</term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED</term>
	/// <term>
	/// The requested buffer size is not aligned. This code can be returned for a render or a capture device if the caller specified
	/// AUDCLNT_SHAREMODE_EXCLUSIVE and the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flags. The caller must call Initialize again with the aligned
	/// buffer size. For more information, see Remarks.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_BUFFER_SIZE_ERROR</term>
	/// <term>
	/// Indicates that the buffer duration value requested by an exclusive-mode client is out of range. The requested duration value for pull
	/// mode must not be greater than 500 milliseconds; for push mode the duration value must not be greater than 2 seconds.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_CPUUSAGE_EXCEEDED</term>
	/// <term>
	/// Indicates that the process-pass duration exceeded the maximum CPU usage. The audio engine keeps track of CPU usage by maintaining the
	/// number of times the process-pass duration exceeds the maximum CPU usage. The maximum CPU usage is calculated as a percent of the
	/// engine's periodicity. The percentage value is the system's CPU throttle value (within the range of 10% and 90%). If this value is not
	/// found, then the default value of 40% is used to calculate the maximum CPU usage.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
	/// <term>
	/// The audio endpoint device has been unplugged, or the audio hardware or associated hardware resources have been reconfigured,
	/// disabled, removed, or otherwise made unavailable for use.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_DEVICE_IN_USE</term>
	/// <term>
	/// The endpoint device is already in use. Either the device is being used in exclusive mode, or the device is being used in shared mode
	/// and the caller asked to use the device in exclusive mode.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_ENDPOINT_CREATE_FAILED</term>
	/// <term>
	/// The method failed to create the audio endpoint for the render or the capture device. This can occur if the audio endpoint device has
	/// been unplugged, or the audio hardware or associated hardware resources have been reconfigured, disabled, removed, or otherwise made
	/// unavailable for use.
	/// </term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_INVALID_DEVICE_PERIOD</term>
	/// <term>Indicates that the device period requested by an exclusive-mode client is greater than 500 milliseconds.</term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_UNSUPPORTED_FORMAT</term>
	/// <term>The audio engine (shared mode) or audio endpoint device (exclusive mode) does not support the specified format.</term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_EXCLUSIVE_MODE_NOT_ALLOWED</term>
	/// <term>The caller is requesting exclusive-mode use of the endpoint device, but the user has disabled exclusive-mode use of the device.</term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_BUFDURATION_PERIOD_NOT_EQUAL</term>
	/// <term>The AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag is set but parameters hnsBufferDuration and hnsPeriodicity are not equal.</term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_E_SERVICE_NOT_RUNNING</term>
	/// <term>The Windows audio service is not running.</term>
	/// </item>
	/// <item>
	/// <term>E_POINTER</term>
	/// <term>Parameter pFormat is NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// Parameter pFormat points to an invalid format description; or the AUDCLNT_STREAMFLAGS_LOOPBACK flag is set but ShareMode is not equal
	/// to AUDCLNT_SHAREMODE_SHARED; or the AUDCLNT_STREAMFLAGS_CROSSPROCESS flag is set but ShareMode is equal to
	/// AUDCLNT_SHAREMODE_EXCLUSIVE. A prior call to SetClientProperties was made with an invalid category for audio/render streams.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Out of memory.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// After activating an IAudioClient interface on an audio endpoint device, the client must successfully call <c>Initialize</c> once and
	/// only once to initialize the audio stream between the client and the device. The client can either connect directly to the audio
	/// hardware (exclusive mode) or indirectly through the audio engine (shared mode). In the <c>Initialize</c> call, the client specifies
	/// the audio data format, the buffer size, and audio session for the stream.
	/// </para>
	/// <para>
	/// <c>Note</c> In Windows 8, the first use of IAudioClient to access the audio device should be on the STA thread. Calls from an MTA
	/// thread may result in undefined behavior.
	/// </para>
	/// <para>
	/// An attempt to create a shared-mode stream can succeed only if the audio device is already operating in shared mode or the device is
	/// currently unused. An attempt to create a shared-mode stream fails if the device is already operating in exclusive mode.
	/// </para>
	/// <para>
	/// If a stream is initialized to be event driven and in shared mode, ShareMode is set to AUDCLNT_SHAREMODE_SHARED and one of the stream
	/// flags that are set includes AUDCLNT_STREAMFLAGS_EVENTCALLBACK. For such a stream, the associated application must also obtain a
	/// handle by making a call to IAudioClient::SetEventHandle. When it is time to retire the stream, the audio engine can then use the
	/// handle to release the stream objects. Failure to call <c>IAudioClient::SetEventHandle</c> before releasing the stream objects can
	/// cause a delay of several seconds (a time-out period) while the audio engine waits for an available handle. After the time-out period
	/// expires, the audio engine then releases the stream objects.
	/// </para>
	/// <para>
	/// Whether an attempt to create an exclusive-mode stream succeeds depends on several factors, including the availability of the device
	/// and the user-controlled settings that govern exclusive-mode operation of the device. For more information, see Exclusive-Mode Streams.
	/// </para>
	/// <para>
	/// An <c>IAudioClient</c> object supports exactly one connection to the audio engine or audio hardware. This connection lasts for the
	/// lifetime of the <c>IAudioClient</c> object.
	/// </para>
	/// <para>The client should call the following methods only after calling <c>Initialize</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>IAudioClient::GetBufferSize</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::GetCurrentPadding</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::GetService</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::GetStreamLatency</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::Reset</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::SetEventHandle</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::Start</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::Stop</term>
	/// </item>
	/// </list>
	/// <para>The following methods do not require that <c>Initialize</c> be called first:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>IAudioClient::GetDevicePeriod</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::GetMixFormat</term>
	/// </item>
	/// <item>
	/// <term>IAudioClient::IsFormatSupported</term>
	/// </item>
	/// </list>
	/// <para>These methods can be called any time after activating the <c>IAudioClient</c> interface.</para>
	/// <para>
	/// Before calling <c>Initialize</c> to set up a shared-mode or exclusive-mode connection, the client can call the
	/// IAudioClient::IsFormatSupported method to discover whether the audio engine or audio endpoint device supports a particular format in
	/// that mode. Before opening a shared-mode connection, the client can obtain the audio engine's mix format by calling the
	/// IAudioClient::GetMixFormat method.
	/// </para>
	/// <para>
	/// The endpoint buffer that is shared between the client and audio engine must be large enough to prevent glitches from occurring in the
	/// audio stream between processing passes by the client and audio engine. For a rendering endpoint, the client thread periodically
	/// writes data to the buffer, and the audio engine thread periodically reads data from the buffer. For a capture endpoint, the engine
	/// thread periodically writes to the buffer, and the client thread periodically reads from the buffer. In either case, if the periods of
	/// the client thread and engine thread are not equal, the buffer must be large enough to accommodate the longer of the two periods
	/// without allowing glitches to occur.
	/// </para>
	/// <para>
	/// The client specifies a buffer size through the hnsBufferDuration parameter. The client is responsible for requesting a buffer that is
	/// large enough to ensure that glitches cannot occur between the periodic processing passes that it performs on the buffer. Similarly,
	/// the <c>Initialize</c> method ensures that the buffer is never smaller than the minimum buffer size needed to ensure that glitches do
	/// not occur between the periodic processing passes that the engine thread performs on the buffer. If the client requests a buffer size
	/// that is smaller than the audio engine's minimum required buffer size, the method sets the buffer size to this minimum buffer size
	/// rather than to the buffer size requested by the client.
	/// </para>
	/// <para>
	/// If the client requests a buffer size (through the hnsBufferDuration parameter) that is not an integral number of audio frames, the
	/// method rounds up the requested buffer size to the next integral number of frames.
	/// </para>
	/// <para>
	/// Following the <c>Initialize</c> call, the client should call the IAudioClient::GetBufferSize method to get the precise size of the
	/// endpoint buffer. During each processing pass, the client will need the actual buffer size to calculate how much data to transfer to
	/// or from the buffer. The client calls the IAudioClient::GetCurrentPadding method to determine how much of the data in the buffer is
	/// currently available for processing.
	/// </para>
	/// <para>
	/// To achieve the minimum stream latency between the client application and audio endpoint device, the client thread should run at the
	/// same period as the audio engine thread. The period of the engine thread is fixed and cannot be controlled by the client. Making the
	/// client's period smaller than the engine's period unnecessarily increases the client thread's load on the processor without improving
	/// latency or decreasing the buffer size. To determine the period of the engine thread, the client can call the
	/// IAudioClient::GetDevicePeriod method. To set the buffer to the minimum size required by the engine thread, the client should call
	/// <c>Initialize</c> with the hnsBufferDuration parameter set to 0. Following the <c>Initialize</c> call, the client can get the size of
	/// the resulting buffer by calling <c>IAudioClient::GetBufferSize</c>.
	/// </para>
	/// <para>
	/// A client has the option of requesting a buffer size that is larger than what is strictly necessary to make timing glitches rare or
	/// nonexistent. Increasing the buffer size does not necessarily increase the stream latency. For a rendering stream, the latency through
	/// the buffer is determined solely by the separation between the client's write pointer and the engine's read pointer. For a capture
	/// stream, the latency through the buffer is determined solely by the separation between the engine's write pointer and the client's
	/// read pointer.
	/// </para>
	/// <para>
	/// The loopback flag (AUDCLNT_STREAMFLAGS_LOOPBACK) enables audio loopback. A client can enable audio loopback only on a rendering
	/// endpoint with a shared-mode stream. Audio loopback is provided primarily to support acoustic echo cancellation (AEC).
	/// </para>
	/// <para>
	/// An AEC client requires both a rendering endpoint and the ability to capture the output stream from the audio engine. The engine's
	/// output stream is the global mix that the audio device plays through the speakers. If audio loopback is enabled, a client can open a
	/// capture buffer for the global audio mix by calling the IAudioClient::GetService method to obtain an IAudioCaptureClient interface on
	/// the rendering stream object. If audio loopback is not enabled, then an attempt to open a capture buffer on a rendering stream will
	/// fail. The loopback data in the capture buffer is in the device format, which the client can obtain by querying the device's
	/// PKEY_AudioEngine_DeviceFormat property.
	/// </para>
	/// <para>
	/// On Windows versions prior to Windows 10, a pull-mode capture client will not receive any events when a stream is initialized with
	/// event-driven buffering (AUDCLNT_STREAMFLAGS_EVENTCALLBACK) and is loopback-enabled (AUDCLNT_STREAMFLAGS_LOOPBACK). If the stream is
	/// opened with this configuration, the <c>Initialize</c> call succeeds, but relevant events are not raised to notify the capture client
	/// each time a buffer becomes ready for processing. To work around this, initialize a render stream in event-driven mode. Each time the
	/// client receives an event for the render stream, it must signal the capture client to run the capture thread that reads the next set
	/// of samples from the capture endpoint buffer. As of Windows 10 the relevant event handles are now set for loopback-enabled streams
	/// that are active.
	/// </para>
	/// <para>
	/// Note that all streams must be opened in share mode because exclusive-mode streams cannot operate in loopback mode. For more
	/// information about audio loopback, see Loopback Recording.
	/// </para>
	/// <para>
	/// The AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag indicates that processing of the audio buffer by the client will be event driven. WASAPI
	/// supports event-driven buffering to enable low-latency processing of both shared-mode and exclusive-mode streams.
	/// </para>
	/// <para>
	/// The initial release of Windows Vista supports event-driven buffering (that is, the use of the AUDCLNT_STREAMFLAGS_EVENTCALLBACK
	/// flag) for rendering streams only.
	/// </para>
	/// <para>
	/// In the initial release of Windows Vista, for capture streams, the AUDCLNT_STREAMFLAGS_EVENTCALLBACK flag is supported only in shared
	/// mode. Setting this flag has no effect for exclusive-mode capture streams. That is, although the application specifies this flag in
	/// exclusive mode through the <c>Initialize</c> call, the application will not receive any events that are usually required to capture
	/// the audio stream. In the Windows Vista Service Pack 1 release, this flag is functional in shared-mode and exclusive mode; an
	/// application can set this flag to enable event-buffering for capture streams. For more information about capturing an audio stream,
	/// see Capturing a Stream.
	/// </para>
	/// <para>
	/// To enable event-driven buffering, the client must provide an event handle to the system. Following the <c>Initialize</c> call and
	/// before calling the IAudioClient::Start method to start the stream, the client must call the IAudioClient::SetEventHandle method to
	/// set the event handle. While the stream is running, the system periodically signals the event to indicate to the client that audio
	/// data is available for processing. Between processing passes, the client thread waits on the event handle by calling a synchronization
	/// function such as <c>WaitForSingleObject</c>. For more information about synchronization functions, see the Windows SDK documentation.
	/// </para>
	/// <para>
	/// For a shared-mode stream that uses event-driven buffering, the caller must set both hnsPeriodicity and hnsBufferDuration to 0. The
	/// <c>Initialize</c> method determines how large a buffer to allocate based on the scheduling period of the audio engine. Although the
	/// client's buffer processing thread is event driven, the basic buffer management process, as described previously, is unaltered. Each
	/// time the thread awakens, it should call IAudioClient::GetCurrentPadding to determine how much data to write to a rendering buffer or
	/// read from a capture buffer. In contrast to the two buffers that the <c>Initialize</c> method allocates for an exclusive-mode stream
	/// that uses event-driven buffering, a shared-mode stream requires a single buffer.
	/// </para>
	/// <para>
	/// For an exclusive-mode stream that uses event-driven buffering, the caller must specify nonzero values for hnsPeriodicity and
	/// hnsBufferDuration, and the values of these two parameters must be equal. The <c>Initialize</c> method allocates two buffers for the
	/// stream. Each buffer is equal in duration to the value of the hnsBufferDuration parameter. Following the <c>Initialize</c> call for a
	/// rendering stream, the caller should fill the first of the two buffers before starting the stream. For a capture stream, the buffers
	/// are initially empty, and the caller should assume that each buffer remains empty until the event for that buffer is signaled. While
	/// the stream is running, the system alternately sends one buffer or the other to the client—this form of double buffering is referred
	/// to as "ping-ponging". Each time the client receives a buffer from the system (which the system indicates by signaling the event), the
	/// client must process the entire buffer. For example, if the client requests a packet size from the IAudioRenderClient::GetBuffer
	/// method that does not match the buffer size, the method fails. Calls to the <c>IAudioClient::GetCurrentPadding</c> method are
	/// unnecessary because the packet size must always equal the buffer size. In contrast to the buffering modes discussed previously, the
	/// latency for an event-driven, exclusive-mode stream depends directly on the buffer size.
	/// </para>
	/// <para>
	/// As explained in Audio Sessions, the default behavior for a session that contains rendering streams is that its volume and mute
	/// settings persist across system restarts. The AUDCLNT_STREAMFLAGS_NOPERSIST flag overrides the default behavior and makes the settings
	/// nonpersistent. This flag has no effect on sessions that contain capture streams—the settings for those sessions are never persistent.
	/// In addition, the settings for a session that contains a loopback stream (a stream that is initialized with the
	/// AUDCLNT_STREAMFLAGS_LOOPBACK flag) are not persistent.
	/// </para>
	/// <para>
	/// Only a session that connects to a rendering endpoint device can have persistent volume and mute settings. The first stream to be
	/// added to the session determines whether the session's settings are persistent. Thus, if the AUDCLNT_STREAMFLAGS_NOPERSIST or
	/// AUDCLNT_STREAMFLAGS_LOOPBACK flag is set during initialization of the first stream, the session's settings are not persistent.
	/// Otherwise, they are persistent. Their persistence is unaffected by additional streams that might be subsequently added or removed
	/// during the lifetime of the session object.
	/// </para>
	/// <para>
	/// After a call to <c>Initialize</c> has successfully initialized an <c>IAudioClient</c> interface instance, a subsequent
	/// <c>Initialize</c> call to initialize the same interface instance will fail and return error code E_ALREADY_INITIALIZED.
	/// </para>
	/// <para>
	/// If the initial call to <c>Initialize</c> fails, subsequent <c>Initialize</c> calls might fail and return error code
	/// E_ALREADY_INITIALIZED, even though the interface has not been initialized. If this occurs, release the <c>IAudioClient</c> interface
	/// and obtain a new <c>IAudioClient</c> interface from the MMDevice API before calling <c>Initialize</c> again.
	/// </para>
	/// <para>For code examples that call the <c>Initialize</c> method, see the following topics:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Rendering a Stream</term>
	/// </item>
	/// <item>
	/// <term>Capturing a Stream</term>
	/// </item>
	/// <item>
	/// <term>Exclusive-Mode Streams</term>
	/// </item>
	/// </list>
	/// <para>
	/// Starting with Windows 7, <c>Initialize</c> can return AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED for a render or a capture device. This
	/// indicates that the buffer size, specified by the caller in the hnsBufferDuration parameter, is not aligned. This error code is
	/// returned only if the caller requested an exclusive-mode stream (AUDCLNT_SHAREMODE_EXCLUSIVE) and event-driven buffering (AUDCLNT_STREAMFLAGS_EVENTCALLBACK).
	/// </para>
	/// <para>
	/// If <c>Initialize</c> returns AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED, the caller must call <c>Initialize</c> again and specify the aligned
	/// buffer size. Use the following steps:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>Call IAudioClient::GetBufferSize and receive the next-highest-aligned buffer size (in frames).</term>
	/// </item>
	/// <item>
	/// <term>Call <c>IAudioClient::Release</c> to release the audio client used in the previous call that returned AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Calculate the aligned buffer size in 100-nansecond units (hns). The buffer size is . In this formula, is the buffer size retrieved by GetBufferSize.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Call the IMMDevice::Activate method with parameter iid set to REFIID IID_IAudioClient to create a new audio client.</term>
	/// </item>
	/// <item>
	/// <term>Call <c>Initialize</c> again on the created audio client and specify the new buffer size and periodicity.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Starting with Windows 10, hardware-offloaded audio streams must be event driven. This means that if you call
	/// IAudioClient2::SetClientProperties and set the bIsOffload parameter of the AudioClientProperties to TRUE, you must specify the
	/// <c>AUDCLNT_STREAMFLAGS_EVENTCALLBACK</c> flag in the StreamFlags parameter to <c>IAudioClient::Initialize</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example code shows how to respond to the <c>AUDCLNT_E_BUFFER_SIZE_NOT_ALIGNED</c> return code.</para>
	/// </remarks>
	public static HRESULT Initialize(this IAudioClient client, [In] AUDCLNT_SHAREMODE ShareMode, AUDCLNT_STREAMFLAGS StreamFlags, long hnsBufferDuration, long hnsPeriodicity, in WAVEFORMATEXTENSIBLE pFormat, [In, Optional] in Guid AudioSessionGuid)
	{
		using SafeCoTaskMemHandle mem = SafeCoTaskMemHandle.CreateFromStructure(pFormat);
		return client.Initialize(ShareMode, StreamFlags, hnsBufferDuration, hnsPeriodicity, mem, AudioSessionGuid);
	}

	/// <summary>Initializes a shared stream with the specified periodicity.</summary>
	/// <param name="client">The client.</param>
	/// <param name="StreamFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// Flags to control creation of the stream. The client should set this parameter to 0 or to the bitwise OR of one or more of the
	/// supported AUDCLNT_STREAMFLAGS_XXX Constants or AUDCLNT_SESSIONFLAGS_XXX Constants. The supported AUDCLNT_STREAMFLAGS_XXX Constants
	/// for this parameter when using this method are:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>AUDCLNT_STREAMFLAGS_EVENTCALLBACK</term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_STREAMFLAGS_AUTOCONVERTPCM</term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_STREAMFLAGS_SRC_DEFAULT_QUALITY</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PeriodInFrames">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>
	/// Periodicity requested by the client. This value must be an integral multiple of the value returned in the pFundamentalPeriodInFrames
	/// parameter to IAudioClient3::GetSharedModeEnginePeriod. PeriodInFrames must also be greater than or equal to the value returned in
	/// pMinPeriodInFrames and less than or equal to the value returned in pMaxPeriodInFrames.
	/// </para>
	/// </param>
	/// <param name="pFormat">
	/// <para>Type: <c>const WAVEFORMATEX*</c></para>
	/// <para>
	/// Pointer to a format descriptor. This parameter must point to a valid format descriptor of type WAVEFORMATEX or <c></c>
	/// WAVEFORMATEXTENSIBLE. For more information, see the Remarks section for IAudioClient::Initialize.
	/// </para>
	/// </param>
	/// <param name="AudioSessionGuid">
	/// <para>Type: <c>LPCGUID</c></para>
	/// <para>
	/// Pointer to a session GUID. This parameter points to a GUID value that identifies the audio session that the stream belongs to. If the
	/// GUID identifies a session that has been previously opened, the method adds the stream to that session. If the GUID does not identify
	/// an existing session, the method opens a new session and adds the stream to that session. The stream remains a member of the same
	/// session for its lifetime. Setting this parameter to <c>NULL</c> is equivalent to passing a pointer to a GUID_NULL value.
	/// </para>
	/// </param>
	/// <remarks>
	/// <para>
	/// Unlike IAudioClient::Initialize, this method does not allow you to specify a buffer size. The buffer size is computed based on the
	/// periodicity requested with the PeriodInFrames parameter. It is the client app's responsibility to ensure that audio samples are
	/// transferred in and out of the buffer in a timely manner.
	/// </para>
	/// <para>
	/// Audio clients should check for allowed values for the PeriodInFrames parameter by calling IAudioClient3::GetSharedModeEnginePeriod.
	/// The value of PeriodInFrames must be an integral multiple of the value returned in the pFundamentalPeriodInFrames parameter.
	/// PeriodInFrames must also be greater than or equal to the value returned in pMinPeriodInFrames and less than or equal to the value of pMaxPeriodInFrames.
	/// </para>
	/// <para>For example, for a 44100 kHz format, <c>GetSharedModeEnginePeriod</c> might return:</para>
	/// <list type="bullet">
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// </list>
	/// <para>
	/// Allowed values for the PeriodInFrames parameter to <c>InitializeSharedAudioStream</c> would include 48 and 448. They would also
	/// include things like 96 and 128.
	/// </para>
	/// <para>
	/// They would NOT include 4 (which is smaller than the minimum allowed value) or 98 (which is not a multiple of the fundamental) or 1000
	/// (which is larger than the maximum allowed value).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient3-initializesharedaudiostream HRESULT
	// InitializeSharedAudioStream( DWORD StreamFlags, UINT32 PeriodInFrames, const WAVEFORMATEX *pFormat, LPCGUID AudioSessionGuid );
	public static void InitializeSharedAudioStream(this IAudioClient3 client, AUDCLNT_STREAMFLAGS StreamFlags, [In] uint PeriodInFrames, in WAVEFORMATEX pFormat, [In, Optional] in Guid AudioSessionGuid)
	{
		using SafeCoTaskMemHandle mem = SafeCoTaskMemHandle.CreateFromStructure(pFormat);
		client.InitializeSharedAudioStream(StreamFlags, PeriodInFrames, mem, AudioSessionGuid);
	}

	/// <summary>Initializes a shared stream with the specified periodicity.</summary>
	/// <param name="client">The client.</param>
	/// <param name="StreamFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// Flags to control creation of the stream. The client should set this parameter to 0 or to the bitwise OR of one or more of the
	/// supported AUDCLNT_STREAMFLAGS_XXX Constants or AUDCLNT_SESSIONFLAGS_XXX Constants. The supported AUDCLNT_STREAMFLAGS_XXX Constants
	/// for this parameter when using this method are:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>AUDCLNT_STREAMFLAGS_EVENTCALLBACK</term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_STREAMFLAGS_AUTOCONVERTPCM</term>
	/// </item>
	/// <item>
	/// <term>AUDCLNT_STREAMFLAGS_SRC_DEFAULT_QUALITY</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PeriodInFrames">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>
	/// Periodicity requested by the client. This value must be an integral multiple of the value returned in the pFundamentalPeriodInFrames
	/// parameter to IAudioClient3::GetSharedModeEnginePeriod. PeriodInFrames must also be greater than or equal to the value returned in
	/// pMinPeriodInFrames and less than or equal to the value returned in pMaxPeriodInFrames.
	/// </para>
	/// </param>
	/// <param name="pFormat">
	/// <para>Type: <c>const WAVEFORMATEX*</c></para>
	/// <para>
	/// Pointer to a format descriptor. This parameter must point to a valid format descriptor of type WAVEFORMATEX or <c></c>
	/// WAVEFORMATEXTENSIBLE. For more information, see the Remarks section for IAudioClient::Initialize.
	/// </para>
	/// </param>
	/// <param name="AudioSessionGuid">
	/// <para>Type: <c>LPCGUID</c></para>
	/// <para>
	/// Pointer to a session GUID. This parameter points to a GUID value that identifies the audio session that the stream belongs to. If the
	/// GUID identifies a session that has been previously opened, the method adds the stream to that session. If the GUID does not identify
	/// an existing session, the method opens a new session and adds the stream to that session. The stream remains a member of the same
	/// session for its lifetime. Setting this parameter to <c>NULL</c> is equivalent to passing a pointer to a GUID_NULL value.
	/// </para>
	/// </param>
	/// <remarks>
	/// <para>
	/// Unlike IAudioClient::Initialize, this method does not allow you to specify a buffer size. The buffer size is computed based on the
	/// periodicity requested with the PeriodInFrames parameter. It is the client app's responsibility to ensure that audio samples are
	/// transferred in and out of the buffer in a timely manner.
	/// </para>
	/// <para>
	/// Audio clients should check for allowed values for the PeriodInFrames parameter by calling IAudioClient3::GetSharedModeEnginePeriod.
	/// The value of PeriodInFrames must be an integral multiple of the value returned in the pFundamentalPeriodInFrames parameter.
	/// PeriodInFrames must also be greater than or equal to the value returned in pMinPeriodInFrames and less than or equal to the value of pMaxPeriodInFrames.
	/// </para>
	/// <para>For example, for a 44100 kHz format, <c>GetSharedModeEnginePeriod</c> might return:</para>
	/// <list type="bullet">
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// </list>
	/// <para>
	/// Allowed values for the PeriodInFrames parameter to <c>InitializeSharedAudioStream</c> would include 48 and 448. They would also
	/// include things like 96 and 128.
	/// </para>
	/// <para>
	/// They would NOT include 4 (which is smaller than the minimum allowed value) or 98 (which is not a multiple of the fundamental) or 1000
	/// (which is larger than the maximum allowed value).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/nf-audioclient-iaudioclient3-initializesharedaudiostream HRESULT
	// InitializeSharedAudioStream( DWORD StreamFlags, UINT32 PeriodInFrames, const WAVEFORMATEX *pFormat, LPCGUID AudioSessionGuid );
	public static void InitializeSharedAudioStream(this IAudioClient3 client, AUDCLNT_STREAMFLAGS StreamFlags, [In] uint PeriodInFrames, in WAVEFORMATEXTENSIBLE pFormat, [In, Optional] in Guid AudioSessionGuid)
	{
		using SafeCoTaskMemHandle mem = SafeCoTaskMemHandle.CreateFromStructure(pFormat);
		client.InitializeSharedAudioStream(StreamFlags, PeriodInFrames, mem, AudioSessionGuid);
	}

	/// <summary>The <c>IsFormatSupported</c> method indicates whether the audio endpoint device supports a particular stream format.</summary>
	/// <param name="client">The client.</param>
	/// <param name="ShareMode">
	/// <para>
	/// The sharing mode for the stream format. Through this parameter, the client indicates whether it wants to use the specified format in
	/// exclusive mode or shared mode. The client should set this parameter to one of the following AUDCLNT_SHAREMODE enumeration values:
	/// </para>
	/// <para>AUDCLNT_SHAREMODE_EXCLUSIVE</para>
	/// <para>AUDCLNT_SHAREMODE_SHARED</para>
	/// </param>
	/// <param name="pFormat">The specified stream format.</param>
	/// <param name="ppClosestMatch">
	/// A variable into which the method writes the address of a stream format structure. This structure specifies the supported format that
	/// is closest to the format that the client specified through the pFormat parameter.
	/// </param>
	/// <returns>
	/// <see langword="true"/> if the audio endpoint device supports the specified stream format; <see langword="false"/> if succeeded with a
	/// closest match to the specified format.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This method provides a way for a client to determine, before calling IAudioClient::Initialize, whether the audio engine supports a
	/// particular stream format.
	/// </para>
	/// <para>
	/// For exclusive mode, <c>IsFormatSupported</c> returns S_OK if the audio endpoint device supports the caller-specified format, or it
	/// returns AUDCLNT_E_UNSUPPORTED_FORMAT if the device does not support the format. The ppClosestMatch parameter can be <c>NULL</c>. If
	/// it is not <c>NULL</c>, the method writes <c>NULL</c> to *ppClosestMatch.
	/// </para>
	/// <para>
	/// For shared mode, if the audio engine supports the caller-specified format, <c>IsFormatSupported</c> sets <c>*ppClosestMatch</c> to
	/// <c>NULL</c> and returns S_OK. If the audio engine does not support the caller-specified format but does support a similar format, the
	/// method retrieves the similar format through the ppClosestMatch parameter and returns S_FALSE. If the audio engine does not support
	/// the caller-specified format or any similar format, the method sets *ppClosestMatch to <c>NULL</c> and returns AUDCLNT_E_UNSUPPORTED_FORMAT.
	/// </para>
	/// <para>
	/// In shared mode, the audio engine always supports the mix format, which the client can obtain by calling the
	/// IAudioClient::GetMixFormat method. In addition, the audio engine might support similar formats that have the same sample rate and
	/// number of channels as the mix format but differ in the representation of audio sample values. The audio engine represents sample
	/// values internally as floating-point numbers, but if the caller-specified format represents sample values as integers, the audio
	/// engine typically can convert between the integer sample values and its internal floating-point representation.
	/// </para>
	/// <para>
	/// The audio engine might be able to support an even wider range of shared-mode formats if the installation package for the audio device
	/// includes a local effects (LFX) audio processing object (APO) that can handle format conversions. An LFX APO is a software module that
	/// performs device-specific processing of an audio stream. The audio graph builder in the Windows audio service inserts the LFX APO into
	/// the stream between each client and the audio engine. When a client calls the <c>IsFormatSupported</c> method and the method
	/// determines that an LFX APO is installed for use with the device, the method directs the query to the LFX APO, which indicates whether
	/// it supports the caller-specified format.
	/// </para>
	/// <para>
	/// For example, a particular LFX APO might accept a 6-channel surround sound stream from a client and convert the stream to a stereo
	/// format that can be played through headphones. Typically, an LFX APO supports only client formats with sample rates that match the
	/// sample rate of the mix format.
	/// </para>
	/// <para>
	/// For more information about APOs, see the white papers titled "Custom Audio Effects in Windows Vista" and "Reusing the Windows Vista
	/// Audio System Effects" at the Audio Device Technologies for Windows website. For more information about the <c>IsFormatSupported</c>
	/// method, see Device Formats.
	/// </para>
	/// </remarks>
	public static bool IsFormatSupported(this IAudioClient client, [In] AUDCLNT_SHAREMODE ShareMode, in WAVEFORMATEX pFormat, out WAVEFORMATEX ppClosestMatch) =>
		IsFormatSupportedGeneric(client, ShareMode, pFormat, out ppClosestMatch);

	/// <summary>The <c>IsFormatSupported</c> method indicates whether the audio endpoint device supports a particular stream format.</summary>
	/// <param name="client">The client.</param>
	/// <param name="ShareMode">
	/// <para>
	/// The sharing mode for the stream format. Through this parameter, the client indicates whether it wants to use the specified format in
	/// exclusive mode or shared mode. The client should set this parameter to one of the following AUDCLNT_SHAREMODE enumeration values:
	/// </para>
	/// <para>AUDCLNT_SHAREMODE_EXCLUSIVE</para>
	/// <para>AUDCLNT_SHAREMODE_SHARED</para>
	/// </param>
	/// <param name="pFormat">The specified stream format.</param>
	/// <param name="ppClosestMatch">
	/// A variable into which the method writes the address of a stream format structure. This structure specifies the supported format that
	/// is closest to the format that the client specified through the pFormat parameter.
	/// </param>
	/// <returns>
	/// <see langword="true"/> if the audio endpoint device supports the specified stream format; <see langword="false"/> if succeeded with a
	/// closest match to the specified format.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This method provides a way for a client to determine, before calling IAudioClient::Initialize, whether the audio engine supports a
	/// particular stream format.
	/// </para>
	/// <para>
	/// For exclusive mode, <c>IsFormatSupported</c> returns S_OK if the audio endpoint device supports the caller-specified format, or it
	/// returns AUDCLNT_E_UNSUPPORTED_FORMAT if the device does not support the format. The ppClosestMatch parameter can be <c>NULL</c>. If
	/// it is not <c>NULL</c>, the method writes <c>NULL</c> to *ppClosestMatch.
	/// </para>
	/// <para>
	/// For shared mode, if the audio engine supports the caller-specified format, <c>IsFormatSupported</c> sets <c>*ppClosestMatch</c> to
	/// <c>NULL</c> and returns S_OK. If the audio engine does not support the caller-specified format but does support a similar format, the
	/// method retrieves the similar format through the ppClosestMatch parameter and returns S_FALSE. If the audio engine does not support
	/// the caller-specified format or any similar format, the method sets *ppClosestMatch to <c>NULL</c> and returns AUDCLNT_E_UNSUPPORTED_FORMAT.
	/// </para>
	/// <para>
	/// In shared mode, the audio engine always supports the mix format, which the client can obtain by calling the
	/// IAudioClient::GetMixFormat method. In addition, the audio engine might support similar formats that have the same sample rate and
	/// number of channels as the mix format but differ in the representation of audio sample values. The audio engine represents sample
	/// values internally as floating-point numbers, but if the caller-specified format represents sample values as integers, the audio
	/// engine typically can convert between the integer sample values and its internal floating-point representation.
	/// </para>
	/// <para>
	/// The audio engine might be able to support an even wider range of shared-mode formats if the installation package for the audio device
	/// includes a local effects (LFX) audio processing object (APO) that can handle format conversions. An LFX APO is a software module that
	/// performs device-specific processing of an audio stream. The audio graph builder in the Windows audio service inserts the LFX APO into
	/// the stream between each client and the audio engine. When a client calls the <c>IsFormatSupported</c> method and the method
	/// determines that an LFX APO is installed for use with the device, the method directs the query to the LFX APO, which indicates whether
	/// it supports the caller-specified format.
	/// </para>
	/// <para>
	/// For example, a particular LFX APO might accept a 6-channel surround sound stream from a client and convert the stream to a stereo
	/// format that can be played through headphones. Typically, an LFX APO supports only client formats with sample rates that match the
	/// sample rate of the mix format.
	/// </para>
	/// <para>
	/// For more information about APOs, see the white papers titled "Custom Audio Effects in Windows Vista" and "Reusing the Windows Vista
	/// Audio System Effects" at the Audio Device Technologies for Windows website. For more information about the <c>IsFormatSupported</c>
	/// method, see Device Formats.
	/// </para>
	/// </remarks>
	public static bool IsFormatSupported(this IAudioClient client, [In] AUDCLNT_SHAREMODE ShareMode, in WAVEFORMATEXTENSIBLE pFormat, out WAVEFORMATEXTENSIBLE ppClosestMatch) =>
		IsFormatSupportedGeneric(client, ShareMode, pFormat, out ppClosestMatch);

	private static bool IsFormatSupportedGeneric<T>(IAudioClient client, [In] AUDCLNT_SHAREMODE ShareMode, in T pFormat, out T ppClosestMatch) where T : struct
	{
		using SafeCoTaskMemHandle mem = SafeCoTaskMemHandle.CreateFromStructure<T>(pFormat);
		HRESULT hr = client.IsFormatSupported(ShareMode, mem, out SafeCoTaskMemHandle ret);
		if (hr != HRESULT.S_OK && hr != HRESULT.S_FALSE && hr != HRESULT.AUDCLNT_E_UNSUPPORTED_FORMAT)
		{
			throw hr.GetException();
		}

		ppClosestMatch = ret.ToStructure<T>();
		ret.Dispose();
		return hr == HRESULT.S_OK;
	}

	/// <summary>Undocumented</summary>
	[PInvokeData("audioclient.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AMBISONICS_PARAMS
	{
		/// <summary>Undocumented</summary>
		public uint u32Size = (uint)Marshal.SizeOf(typeof(AMBISONICS_PARAMS));

		/// <summary>Undocumented</summary>
		public uint u32Version = AMBISONICS_PARAM_VERSION_1;

		/// <summary>Undocumented</summary>
		public AMBISONICS_TYPE u32Type;

		/// <summary>Undocumented</summary>
		public AMBISONICS_CHANNEL_ORDERING u32ChannelOrdering;

		/// <summary>Undocumented</summary>
		public AMBISONICS_NORMALIZATION u32Normalization;

		/// <summary>Undocumented</summary>
		public uint u32Order;

		/// <summary>Undocumented</summary>
		public uint u32NumChannels;

		/// <summary>
		/// A sequence of 32-bit unsigned integers that maps audio channels in a given audio track to ambisonic components, given the defined
		/// ambisonics_channel_ordering. The sequence of channel_map values should match the channel sequence within the given audio track.
		/// </summary>
		public IntPtr pu32ChannelMap;

		/// <summary>Initializes a new instance of the <see cref="AMBISONICS_PARAMS"/> struct.</summary>
		public AMBISONICS_PARAMS()
		{ }
	}

	/// <summary>Represents an audio effect.</summary>
	/// <remarks>Get a list of <c>AUDIO_EFFECT</c> structures by calling IAudioEffectsManager::GetAudioEffects.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioclient/ns-audioclient-audio_effect typedef struct AUDIO_EFFECT { GUID id;
	// BOOL canSetState; AUDIO_EFFECT_STATE state; } AUDIO_EFFECT;
	[PInvokeData("audioclient.h", MSDNShortId = "NS:audioclient.AUDIO_EFFECT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AUDIO_EFFECT
	{
		/// <summary>The GUID identifier for an audio effect. Audio effect GUIDs are defined in ksmedia.h.</summary>
		public Guid id;

		/// <summary>A boolean value specifying whether the effect state can be modified.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool canSetState;

		/// <summary>A member of the AUDIO_EFFECT_STATE enumeration specifying the state of the audio effect.</summary>
		public AUDIO_EFFECT_STATE state;
	}

	/// <summary>
	/// The <c>AudioClientProperties</c> structure is used to set the parameters that describe the properties of the client's audio stream.
	/// </summary>
	/// <remarks>
	/// Starting with Windows 10, hardware-offloaded audio streams must be event driven. This means that if you call
	/// IAudioClient2::SetClientProperties and set the bIsOffload parameter of the <c>AudioClientProperties</c> to TRUE, you must specify the
	/// <c>AUDCLNT_STREAMFLAGS_EVENTCALLBACK</c> flag in the StreamFlags parameter to IAudioClient::Initialize.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioclient/ns-audioclient-audioclientproperties~r1 typedef struct
	// AudioClientProperties { UINT32 cbSize; BOOL bIsOffload; AUDIO_STREAM_CATEGORY eCategory; AUDCLNT_STREAMOPTIONS Options; } AudioClientProperties;
	[PInvokeData("audioclient.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AudioClientProperties
	{
		/// <summary>The size of the <c>AudioClientProperties</c> structure, in bytes.</summary>
		public uint cbSize;

		/// <summary>Boolean value to indicate whether or not the audio stream is hardware-offloaded.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bIsOffload;

		/// <summary>An enumeration that is used to specify the category of the audio stream.</summary>
		public AUDIO_STREAM_CATEGORY eCategory;

		/// <summary>
		/// <para>A member of the AUDCLNT_STREAMOPTIONS enumeration describing the characteristics of the stream.</para>
		/// <para>Supported in Windows 8.1 and later.</para>
		/// </summary>
		public AUDCLNT_STREAMOPTIONS Options;
	}
}