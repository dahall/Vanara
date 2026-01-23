using static Vanara.PInvoke.WinMm;

namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from Windows Core Audio Api.</summary>
public static partial class CoreAudio
{
	/// <summary>
	/// Defines constants for the AE_CURRENT_POSITION structure. These constants describe the degree of validity of the current position.
	/// </summary>
	/// <remarks>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/ne-audioengineendpoint-ae_position_flags typedef enum
	// AE_POSITION_FLAGS { POSITION_INVALID, POSITION_DISCONTINUOUS, POSITION_CONTINUOUS, POSITION_QPC_ERROR } ;
	[PInvokeData("audioengineendpoint.h", MSDNShortId = "09edc9ae-923c-4f57-9479-c0331588dd92")]
	[Flags]
	public enum AE_POSITION_FLAGS
	{
		/// <summary>The position is not valid and must not be used.</summary>
		POSITION_INVALID = 0,

		/// <summary>
		/// The position is valid; however, there has been a disruption such as a glitch or state transition. This current position is not
		/// correlated with the previous position. The start of a stream should not reflect a discontinuity.
		/// </summary>
		POSITION_DISCONTINUOUS = 1,

		/// <summary>The position is valid. The previous packet and the current packet are both synchronized with the timeline.</summary>
		POSITION_CONTINUOUS = 2,

		/// <summary>
		/// The quality performance counter (QPC) timer value associated with this position is not accurate. This flag is set when a position
		/// error is encountered and the implementation is unable to compute an accurate QPC value that correlates with the position.
		/// </summary>
		POSITION_QPC_ERROR = 4,
	}

	/// <summary>Used by <see cref="AUDIO_ENDPOINT_SHARED_CREATE_PARAMS"/>.</summary>
	[PInvokeData("audioengineendpoint.h")]
	public enum EndpointConnectorType
	{
		/// <summary/>
		eHostProcessConnector = 0,

		/// <summary/>
		eOffloadConnector,

		/// <summary/>
		eLoopbackConnector,

		/// <summary/>
		eKeywordDetectorConnector,

		/// <summary/>
		eConnectorCount
	}

	/// <summary>
	/// <para>Initializes a device endpoint object and gets the capabilities of the device that it represents.</para>
	/// <para>
	/// A <c>device endpoint</c> abstracts an audio device. The device can be a rendering device such as a speaker or a capture device such
	/// as a microphone. A device endpoint must implement the <c>IAudioDeviceEndpoint</c> interface.
	/// </para>
	/// <para>
	/// To a get a reference to the <c>IAudioDeviceEndpoint</c> interface of the device, the audio engine calls <c>QueryInterface</c> on the
	/// audio endpoint (IAudioInputEndpointRT or IAudioOutputEndpointRT) for the device.
	/// </para>
	/// </summary>
	/// <remarks>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nn-audioengineendpoint-iaudiodeviceendpoint
	[PInvokeData("audioengineendpoint.h", MSDNShortId = "NN:audioengineendpoint.IAudioDeviceEndpoint")]
	[ComImport, Guid("D4952F5A-A0B2-4cc4-8B82-9358488DD8AC"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioDeviceEndpoint
	{
		/// <summary>
		/// The <c>SetBuffer</c> method initializes the endpoint and creates a buffer based on the format of the endpoint into which the
		/// audio data is streamed.
		/// </summary>
		/// <param name="MaxPeriod">The processing time, in 100-nanosecond units, of the audio endpoint.</param>
		/// <param name="u32LatencyCoefficient">
		/// <para>
		/// The latency coefficient for the audio device. This value is used to calculate the latency. Latency = <c>u32LatencyCoefficient</c>
		/// * <c>MaxPeriod</c>.
		/// </para>
		/// <para>
		/// <c>Note</c> The device that the endpoint represents has a minimum latency value. If the value of this parameter is less than the
		/// minimum latency of the device or is zero, the endpoint object applies the minimum latency. The audio engine can obtain the actual
		/// latency of the endpoint by calling the IAudioEndpoint::GetLatency method.
		/// </para>
		/// </param>
		/// <remarks>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudiodeviceendpoint-setbuffer
		// HRESULT SetBuffer( [in] HNSTIME MaxPeriod, [in] UINT32 u32LatencyCoefficient );
		void SetBuffer(long MaxPeriod, uint u32LatencyCoefficient);

		/// <summary>
		/// The <c>GetRTCaps</c> method queries whether the audio device is real-time (RT)-capable. This method is not used in Remote Desktop
		/// Services implementations of IAudioDeviceEndpoint.
		/// </summary>
		/// <returns>
		/// Receives <c>TRUE</c> if the audio device is RT-capable, or <c>FALSE</c> otherwise. Remote Desktop Services implementations should
		/// always return <c>FALSE</c>.
		/// </returns>
		/// <remarks>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudiodeviceendpoint-getrtcaps
		// HRESULT GetRTCaps( [out] BOOL *pbIsRTCapable );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetRTCaps();

		/// <summary>
		/// The <c>GetEventDrivenCapable</c> method indicates whether the device endpoint is event driven. The device endpoint controls the
		/// period of the audio engine by setting events that signal buffer availability.
		/// </summary>
		/// <returns>
		/// A value of <c>TRUE</c> indicates that the device endpoint is event driven. A value of <c>FALSE</c> indicates that it is not event
		/// driven. If the endpoint device is event driven, the audio engine can receive events from an audio device endpoint.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Call the <c>GetEventDrivenCapable</c> method before calling the IAudioDeviceEndpoint::SetBuffer method, which initializes the
		/// device endpoint and creates a buffer. This allows the device endpoint to set up the structures needed for driving events.
		/// </para>
		/// <para>If the audio engine requires an event driven device endpoint, it will:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Create an event and set the event handle on the device endpoint by calling the IAudioEndpoint::SetEventHandle method.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Specify event driven mode by setting the <c>AUDCLNT_STREAMFLAGS_EVENTCALLBACK</c> flag on the device endpoint by calling the
		/// IAudioEndpoint::SetStreamFlags method.
		/// </term>
		/// </item>
		/// </list>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudiodeviceendpoint-geteventdrivencapable
		// HRESULT GetEventDrivenCapable( [out] BOOL *pbisEventCapable );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetEventDrivenCapable();

		/// <summary>
		/// The <c>WriteExclusiveModeParametersToSharedMemory</c> method creates and writes the exclusive-mode parameters to shared memory.
		/// </summary>
		/// <param name="hTargetProcess">The handle of the process for which the handles will be duplicated.</param>
		/// <param name="hnsPeriod">
		/// The periodicity, in 100-nanosecond units, of the device. This value must fall within the range of the minimum and maximum
		/// periodicity of the device represented by the endpoint.
		/// </param>
		/// <param name="hnsBufferDuration">The buffer duration, in 100-nanosecond units, requested by the client.</param>
		/// <param name="u32LatencyCoefficient">
		/// The latency coefficient of the audio endpoint. A client can obtain the actual latency of the endpoint by calling the
		/// IAudioEndpoint::GetLatency method.
		/// </param>
		/// <param name="pu32SharedMemorySize">Receives the size of the memory area shared by the service and the process.</param>
		/// <param name="phSharedMemory">Receives a handle to the memory area shared by the service and the process.</param>
		/// <remarks>
		/// <para>
		/// This method is used to provide handles and parameters of the audio service of the endpoint to the client process for use in
		/// exclusive mode. This method fails if the endpoint object is fully initialized through the IAudioDeviceEndpoint::SetBuffer method call.
		/// </para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudiodeviceendpoint-writeexclusivemodeparameterstosharedmemory
		// HRESULT WriteExclusiveModeParametersToSharedMemory( [in] UINT_PTR hTargetProcess, [in] HNSTIME hnsPeriod, [in] HNSTIME
		// hnsBufferDuration, [in] UINT32 u32LatencyCoefficient, [out] UINT32 *pu32SharedMemorySize, [out] UINT_PTR *phSharedMemory );
		void WriteExclusiveModeParametersToSharedMemory([In] IntPtr hTargetProcess, long hnsPeriod, long hnsBufferDuration, uint u32LatencyCoefficient, out uint pu32SharedMemorySize, out IntPtr phSharedMemory);
	}

	/// <summary>Provides information to the audio engine about an audio endpoint. This interface is implemented by an audio endpoint.</summary>
	/// <remarks>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nn-audioengineendpoint-iaudioendpoint
	[PInvokeData("audioengineendpoint.h", MSDNShortId = "a1bb3fe4-6051-4b9c-8270-70375e700f01")]
	[ComImport, Guid("30A99515-1527-4451-AF9F-00C5F0234DAF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioEndpoint
	{
		/// <summary>The <c>GetFrameFormat</c> method retrieves the format of the audio endpoint.</summary>
		/// <param name="ppFormat">
		/// Receives a pointer to a <c>WAVEFORMATEX</c> structure that contains the format information for the device that the audio endpoint
		/// represents. The implementation must allocate memory for the structure by using <c>CoTaskMemAlloc</c>. The caller must free the
		/// buffer by using <c>CoTaskMemFree</c>. For information about CoTaskMemAlloc and CoTaskMemFree, see the Windows SDK documentation.
		/// </param>
		/// <remarks>
		/// <para>This method must not be called from a real-time processing thread.</para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpoint-getframeformat
		// HRESULT GetFrameFormat( WAVEFORMATEX **ppFormat );
		void GetFrameFormat(out SafeCoTaskMemHandle ppFormat);

		/// <summary>
		/// The <c>GetFramesPerPacket</c> method gets the maximum number of frames per packet that the audio endpoint can support, based on
		/// the endpoint's period and the sample rate.
		/// </summary>
		/// <returns>Receives the maximum number of frames per packet that the endpoint can support.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpoint-getframesperpacket
		// HRESULT GetFramesPerPacket( UINT32 *pFramesPerPacket );
		uint GetFramesPerPacket();

		/// <summary>The <c>GetLatency</c> method gets the latency of the audio endpoint.</summary>
		/// <returns>A pointer to an <c>HNSTIME</c> variable that receives the latency that is added to the stream by the audio endpoint.</returns>
		/// <remarks>
		/// <para>
		/// There is some latency for an endpoint so that the buffer can stay ahead of the data already committed for input/output (I/O)
		/// transfer (playback or capture). For example, if an audio endpoint is using 5-millisecond buffers to stay ahead of the I/O
		/// transfer, the latency returned by this method is 5 milliseconds.
		/// </para>
		/// <para>This method must not be called from a real-time processing thread.</para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpoint-getlatency HRESULT
		// GetLatency( HNSTIME *pLatency );
		long GetLatency();

		/// <summary>The <c>SetStreamFlags</c> method sets the stream configuration flags on the audio endpoint.</summary>
		/// <param name="streamFlags">A bitwise <c>OR</c> of one or more of the AUDCLNT_STREAMFLAGS_XXX constants.</param>
		/// <remarks>
		/// <para>This method must not be called from a real-time processing thread.</para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpoint-setstreamflags
		// HRESULT SetStreamFlags( DWORD streamFlags );
		void SetStreamFlags(AUDCLNT_STREAMFLAGS streamFlags);

		/// <summary>
		/// The <c>SetEventHandle</c> method sets the handle for the event that the endpoint uses to signal that it has completed processing
		/// of a buffer.
		/// </summary>
		/// <param name="eventHandle">The event handle used to invoke a buffer completion callback.</param>
		/// <remarks>
		/// <para>
		/// The <c>SetEventHandle</c> method sets the audio engine event handle on the endpoint. In this implementation, the caller should
		/// receive an error response of <c>AEERR_NOT_INITIALIZED</c> if the audio endpoint is not initialized or the buffer is not set by
		/// the SetBuffer method.
		/// </para>
		/// <para>
		/// To get event notifications, the audio engine will have set the <c>AUDCLNT_STREAMFLAGS_EVENTCALLBACK</c> flag on the endpoint. To
		/// set this flag, the audio engine calls the IAudioEndpoint::SetStreamFlags method.
		/// </para>
		/// <para>This method must not be called from a real-time processing thread.</para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpoint-seteventhandle
		// HRESULT SetEventHandle( HANDLE eventHandle );
		void SetEventHandle([In] IntPtr eventHandle);
	}

	/// <summary>Controls the stream state of an endpoint.</summary>
	/// <remarks>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nn-audioengineendpoint-iaudioendpointcontrol
	[PInvokeData("audioengineendpoint.h", MSDNShortId = "4514521a-e9a9-4f39-ab7d-4ef7e514bd10")]
	[ComImport, Guid("C684B72A-6DF4-4774-BDF9-76B77509B653"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioEndpointControl
	{
		/// <summary>The <c>Start</c> method starts the endpoint stream.</summary>
		/// <remarks>
		/// <para>The implementation of this method can differ depending on the type of device that the endpoint represents.</para>
		/// <para>This method must not be called from a real-time processing thread.</para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpointcontrol-start HRESULT Start();
		void Start();

		/// <summary>The <c>Reset</c> method resets the endpoint stream.</summary>
		/// <remarks>
		/// <para>
		/// <c>Reset</c> discards all data that has not been processed yet. The implementation of this method may differ depending on the
		/// type of device that the endpoint represents.
		/// </para>
		/// <para>This method must not be called from a real-time processing thread.</para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpointcontrol-reset HRESULT Reset();
		void Reset();

		/// <summary>The <c>Stop</c> method stops the endpoint stream.</summary>
		/// <remarks>
		/// <para>The implementation of this method can differ depending on the type of device that the endpoint represents.</para>
		/// <para>This method must not be called from a real-time processing thread.</para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpointcontrol-stop HRESULT Stop();
		void Stop();
	}

	/// <summary>
	/// Provides functionality to allow an offload stream client to notify the endpoint that the last buffer has been sent only partially filled.
	/// </summary>
	/// <remarks>This is an optional interface on an endpoint.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nn-audioengineendpoint-iaudioendpointlastbuffercontrol
	[PInvokeData("audioengineendpoint.h", MSDNShortId = "79f4b370-fd04-41a9-ad74-54f7edd084c2")]
	[ComImport, Guid("F8520DD3-8F9D-4437-9861-62F584C33DD6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioEndpointLastBufferControl
	{
		/// <summary>Indicates if last buffer control is supported.</summary>
		/// <returns><c>true</c> if last buffer control is supported; otherwise, <c>false</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpointlastbuffercontrol-islastbuffercontrolsupported
		// BOOL IsLastBufferControlSupported();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsLastBufferControlSupported();

		/// <summary>Releases the output data pointer for the last buffer.</summary>
		/// <param name="pConnectionProperty">The APO connection property.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpointlastbuffercontrol-releaseoutputdatapointerforlastbuffer
		// void ReleaseOutputDataPointerForLastBuffer( const APO_CONNECTION_PROPERTY *pConnectionProperty );
		[PreserveSig]
		void ReleaseOutputDataPointerForLastBuffer(in APO_CONNECTION_PROPERTY pConnectionProperty);
	}

	/// <summary>
	/// The <c>IAudioEndpointOffloadStreamMeter</c> interface retrieves general information about the audio channels in the offloaded audio stream.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nn-audioengineendpoint-iaudioendpointoffloadstreammeter
	[PInvokeData("audioengineendpoint.h", MSDNShortId = "B19413F9-1DE9-4940-B0A1-11E5278F084B")]
	[ComImport, Guid("E1546DCE-9DD1-418B-9AB2-348CED161C86"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioEndpointOffloadStreamMeter
	{
		/// <summary>Gets the number of available audio channels in the offloaded stream that can be metered.</summary>
		/// <returns>
		/// A Pointer to a variable that indicates the number of available audio channels in the offloaded stream that can be metered.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpointoffloadstreammeter-getmeterchannelcount
		// HRESULT GetMeterChannelCount( UINT32 *pu32ChannelCount );
		uint GetMeterChannelCount();

		/// <summary>
		/// The <c>GetMeteringData</c> method retrieves general information about the available audio channels in the offloaded stream.
		/// </summary>
		/// <param name="u32ChannelCount">Indicates the number of available audio channels in the offloaded audio stream.</param>
		/// <returns>A pointer to the peak values for the audio channels in the offloaded audio stream.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpointoffloadstreammeter-getmeteringdata
		// HRESULT GetMeteringData( UINT32 u32ChannelCount, FLOAT32 *pf32PeakValues );
		float GetMeteringData(uint u32ChannelCount);
	}

	/// <summary>
	/// The <c>IAudioEndpointOffloadStreamMute</c> interface allows a client to manipulate the mute status of the offloaded audio stream.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nn-audioengineendpoint-iaudioendpointoffloadstreammute
	[ComImport, Guid("DFE21355-5EC2-40E0-8D6B-710AC3C00249"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioEndpointOffloadStreamMute
	{
		/// <summary>The <c>SetMute</c> method sets the mute status of the offloaded audio stream.</summary>
		/// <param name="bMuted">
		/// Indicates whether or not the offloaded audio stream is to be muted. A value of <c>TRUE</c> mutes the stream, and a value of
		/// <c>FALSE</c> sets the stream to a non-muted state.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpointoffloadstreammute-setmute
		// HRESULT SetMute( boolean bMuted );
		void SetMute([MarshalAs(UnmanagedType.U1)] bool bMuted);

		/// <summary>The <c>GetMute</c> method retrieves the mute status of the offloaded audio stream.</summary>
		/// <returns>
		/// The <c>GetMute</c> method returns <c>S_OK</c> to indicate that it has completed successfully. Otherwise it returns an appropriate
		/// error code.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpointoffloadstreammute-getmute
		// HRESULT GetMute( boolean *pbMuted );
		[return: MarshalAs(UnmanagedType.U1)]
		bool GetMute();
	}

	/// <summary>
	/// The <c>IAudioEndpointOffloadStreamVolume</c> interface allows the client application to manipulate the volume level of the offloaded
	/// audio stream.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nn-audioengineendpoint-iaudioendpointoffloadstreamvolume
	[ComImport, Guid("64F1DD49-71CA-4281-8672-3A9EDDD1D0B6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioEndpointOffloadStreamVolume
	{
		/// <summary>The <c>GetVolumeChannelCount</c> method retrieves the number of available audio channels in the offloaded stream.</summary>
		/// <returns>A pointer to the number of available audio channels in the offloaded stream.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpointoffloadstreamvolume-getvolumechannelcount
		// HRESULT GetVolumeChannelCount( UINT32 *pu32ChannelCount );
		uint GetVolumeChannelCount();

		/// <summary>The <c>SetChannelVolumes</c> method sets the volume levels for the various audio channels in the offloaded stream.</summary>
		/// <param name="u32ChannelCount">Indicates the number of available audio channels in the offloaded stream.</param>
		/// <param name="pf32Volumes">A pointer to the volume levels for the various audio channels in the offloaded stream.</param>
		/// <param name="u32CurveType">
		/// A value from the AUDIO_CURVE_TYPE enumeration specifying the curve to use when changing the channel volumes.
		/// </param>
		/// <param name="pCurveDuration">A <c>LONGLONG</c> value specifying the curve duration in hundred nanosecond units.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpointoffloadstreamvolume-setchannelvolumes
		// HRESULT SetChannelVolumes( UINT32 u32ChannelCount, FLOAT32 *pf32Volumes, AUDIO_CURVE_TYPE u32CurveType, HNSTIME *pCurveDuration );
		void SetChannelVolumes(uint u32ChannelCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] pf32Volumes, AUDIO_CURVE_TYPE u32CurveType, in long pCurveDuration);

		/// <summary>The <c>GetChannelVolumes</c> method retrieves the volume levels for the various audio channels in the offloaded stream.</summary>
		/// <param name="u32ChannelCount">Indicates the numer of available audio channels in the offloaded stream.</param>
		/// <param name="pf32Volumes">A pointer to the volume levels for the various audio channels in the offloaded stream.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpointoffloadstreamvolume-getchannelvolumes
		// HRESULT GetChannelVolumes( UINT32 u32ChannelCount, FLOAT32 *pf32Volumes );
		void GetChannelVolumes(uint u32ChannelCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] pf32Volumes);
	}

	/// <summary>
	/// <para>
	/// Gets the difference between the current read and write positions in the endpoint buffer. The <c>IAudioEndpointRT</c> interface is
	/// used by the audio engine.
	/// </para>
	/// <para>
	/// <c>IAudioEndpointRT</c> methods can be called from a real-time processing thread. The implementation of the methods of this interface
	/// must not block, access paged memory, or call any blocking system routines.
	/// </para>
	/// </summary>
	/// <remarks>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nn-audioengineendpoint-iaudioendpointrt
	[PInvokeData("audioengineendpoint.h", MSDNShortId = "3fb05ce4-a3be-4c84-8e03-71213f453f74")]
	[ComImport, Guid("DFD2005F-A6E5-4d39-A265-939ADA9FBB4D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioEndpointRT
	{
		/// <summary>The <c>GetCurrentPadding</c> method gets the amount, in 100-nanosecond units, of data that is queued up in the endpoint.</summary>
		/// <param name="pPadding">Receives the number of frames available in the endpoint buffer.</param>
		/// <param name="pAeCurrentPosition">
		/// Receives information about the position of the current frame in the endpoint buffer in an AE_CURRENT_POSITION structure specified
		/// by the caller.
		/// </param>
		/// <remarks>
		/// <para>
		/// The audio engine uses this information to calculate the amount of data that requires processing. This calculation depends on the
		/// implementation. The value of the pPadding parameter specifies the number of audio frames that are queued up to play in the
		/// endpoint buffer. Before writing to the endpoint buffer, the audio engine can calculate the amount of available space in the
		/// buffer by subtracting the padding value from the buffer length. For a CaptureStream endpoint, the padding value reported by the
		/// <c>GetCurrentPadding</c> method specifies the number of frames of capture data that are available in the next packet in the
		/// endpoint buffer and that might be ready for the audio engine to read from the buffer.
		/// </para>
		/// <para>
		/// This method can be called from a real-time processing thread. The implementation of this method must not block, access paged
		/// memory, or call any blocking system routines.
		/// </para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpointrt-getcurrentpadding
		// void GetCurrentPadding( HNSTIME *pPadding, AE_CURRENT_POSITION *pAeCurrentPosition );
		[PreserveSig]
		void GetCurrentPadding(out long pPadding, out AE_CURRENT_POSITION pAeCurrentPosition);

		/// <summary>The <c>ProcessingComplete</c> method notifies the endpoint that a processing pass has been completed.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method enables the audio engine to call into the endpoint to set an event that indicates that a processing pass had been
		/// completed and that there is audio data ready to be retrieved or passed to the endpoint device.
		/// </para>
		/// <para>
		/// This method can be called from a real-time processing thread. The implementation of this method must not block, access paged
		/// memory, or call any blocking system routines.
		/// </para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpointrt-processingcomplete
		// void ProcessingComplete();
		[PreserveSig]
		void ProcessingComplete();

		/// <summary>
		/// The <c>SetPinInactive</c> method notifies the endpoint that it must change the state of the underlying stream resources to an
		/// inactive state.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This method enables the audio engine to call into the endpoint to indicate that the endpoint can pause the underlying stream
		/// resources. In most cases, this method can simply return <c>S_OK</c>.
		/// </para>
		/// <para>
		/// This method can be called from a real-time processing thread. The implementation of this method must not block, access paged
		/// memory, or call any blocking system routines.
		/// </para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpointrt-setpininactive
		// HRESULT SetPinInactive();
		void SetPinInactive();

		/// <summary>
		/// The <c>SetPinActive</c> method notifies the endpoint that it must change the state of the underlying streaming resources to an
		/// active state.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This method enables the audio engine to call into the endpoint to indicate that the endpoint must prepare any audio stream
		/// resources. In most cases, this method can simply return <c>S_OK</c>.
		/// </para>
		/// <para>
		/// This method can be called from a real-time processing thread. The implementation of this method must not block, access paged
		/// memory, or call any blocking system routines.
		/// </para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioendpointrt-setpinactive
		// HRESULT SetPinActive();
		void SetPinActive();
	}

	/// <summary>Gets the input buffer for each processing pass.The <c>IAudioInputEndpointRT</c> interface is used by the audio engine.</summary>
	/// <remarks>
	/// <para>
	/// <c>IAudioInputEndpointRT</c> methods can be called from a real-time processing thread. The implementation of the methods of this
	/// interface must not block, access paged memory, or call any blocking system routines.
	/// </para>
	/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nn-audioengineendpoint-iaudioinputendpointrt
	[PInvokeData("audioengineendpoint.h", MSDNShortId = "f9638dea-f61d-45f6-b91d-72e4fc1b4a92")]
	[ComImport, Guid("8026AB61-92B2-43c1-A1DF-5C37EBD08D82"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioInputEndpointRT
	{
		/// <summary>The <c>GetInputDataPointer</c> method gets a pointer to the buffer from which data will be read by the audio engine.</summary>
		/// <param name="pConnectionProperty">
		/// <para>A pointer to an APO_CONNECTION_PROPERTYstructure.</para>
		/// <para>The caller sets the member values as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>pBuffer</c> is set to <c>NULL</c>.</term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>u32ValidFrameCount</c> contains the number of frames that need to be in the retrieved data pointer. The endpoint object must
		/// not cache this information. The audio engine can change this number depending on its processing needs.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>u32BufferFlags</c> is set to <c>BUFFER_INVALID</c>.</term>
		/// </item>
		/// </list>
		/// <para>If this call completes successfully, the endpoint must set the member values as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <c>pBuffer</c> points to valid memory where the data has been read. This could include silence depending on the flags that were
		/// set in the <c>u32BufferFlags</c> member.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>u32ValidFrameCount</c> is unchanged.</term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>u32BufferFlags</c> is set to <c>BUFFER_VALID</c> if the data pointer contains valid data or to <c>BUFFER_SILENT</c> if the
		/// data pointer contains only silent data. The data in the buffer does not actually need to be silence, but the buffer specified in
		/// <c>pBuffer</c> must be capable of holding all the frames of silence contained in <c>u32ValidFrameCount</c> to match the required
		/// frame count.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pAeTimeStamp">
		/// A pointer to an AE_CURRENT_POSITION structure that contains the time stamp of the data that is captured in the buffer. This
		/// parameter is optional.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method returns a pointer from the endpoint to the buffer pConnectionProperty-&gt; <c>pBuffer</c>, which contains data that
		/// needs to be passed into the engine as input. The data and the buffer pointer must remain valid until the
		/// IAudioInputEndpointRT::ReleaseInputDataPointer method is called. The endpoint object must set the requested amount of information
		/// and insert silence if no valid data exists. The buffer pointer, pConnectionProperty-&gt; <c>pBuffer</c>, returned by the endpoint
		/// object must be frame aligned. Endpoints do not support the extra space, which may be available in the APO_CONNECTION_PROPERTY
		/// associated with the connection properties passed in the pConnectionProperty parameter.
		/// </para>
		/// <para>
		/// Passing zero in the <c>u32ValidFrameCount</c> member is a valid request. In this case, the input pointer must be valid but the
		/// endpoint does not read from it. The pConnectionProperty-&gt; <c>u32ValidFrameCount</c> value must be less than or equal to the
		/// maximum frame count supported by the endpoint. To get the supported number of frames, call the IAudioEndpoint::GetFramesPerPacket method.
		/// </para>
		/// <para>
		/// This method can be called from a real-time processing thread. The implementation of this method must not block, access paged
		/// memory, or call any blocking system routines.
		/// </para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioinputendpointrt-getinputdatapointer
		// void GetInputDataPointer( APO_CONNECTION_PROPERTY *pConnectionProperty, AE_CURRENT_POSITION *pAeTimeStamp );
		[PreserveSig]
		void GetInputDataPointer(ref APO_CONNECTION_PROPERTY pConnectionProperty, ref AE_CURRENT_POSITION pAeTimeStamp);

		/// <summary>The <c>ReleaseInputDataPointer</c> method releases the acquired data pointer.</summary>
		/// <param name="u32FrameCount">
		/// The number of frames that have been consumed by the audio engine. This count might not be the same as the value returned by the
		/// IAudioInputEndpointRT::GetInputDataPointer method in the pConnectionProperty-&gt; <c>u32ValidFrameCount</c> member.
		/// </param>
		/// <param name="pDataPointer">
		/// The pointer to the buffer retrieved by the GetInputDataPointer method received in the pConnectionProperty-&gt; <c>pBuffer</c> member.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <c>ReleaseInputDataPointer</c> notifies the endpoint that the audio engine no longer requires the input data pointer and also
		/// indicates the number of frames used during the session. For example, an endpoint, which represents a looped buffer, is connected
		/// to the input of the audio engine and can advance its read pointer by using the actual frame count. If <c>u32FrameCount</c> is
		/// zero, this indicates that the client did not use any data from the specified input buffer. The <c>u32FrameCount</c> must be less
		/// than or equal to the maximum frame count supported by the endpoint. To get the supported number of frames, the audio engine calls
		/// the IAudioEndpoint::GetFramesPerPacket method.
		/// </para>
		/// <para>
		/// This method can be called from a real-time processing thread. The implementation of this method must not block, access paged
		/// memory, or call any blocking system routines.
		/// </para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioinputendpointrt-releaseinputdatapointer
		// void ReleaseInputDataPointer( UINT32 u32FrameCount, UINT_PTR pDataPointer );
		[PreserveSig]
		void ReleaseInputDataPointer(uint u32FrameCount, [In] IntPtr pDataPointer);

		/// <summary>The <c>PulseEndpoint</c> method is reserved.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method can be called from a real-time processing thread. The implementation of this method must not block, access paged
		/// memory, or call any blocking system routines.
		/// </para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudioinputendpointrt-pulseendpoint
		// void PulseEndpoint();
		[PreserveSig]
		void PulseEndpoint();
	}

	/// <summary>The <c>IAudioLfxControl</c> interface allows the client to apply or remove local effects from the offloaded audio stream.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nn-audioengineendpoint-iaudiolfxcontrol
	[PInvokeData("audioengineendpoint.h", MSDNShortId = "E4290AE9-7F2E-4D0B-BEAF-F01D95B3E03D")]
	[ComImport, Guid("076A6922-D802-4F83-BAF6-409D9CA11BFE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioLfxControl
	{
		/// <summary>
		/// The <c>SetLocalEffectsState</c> method sets the local effects state that is to be applied to the offloaded audio stream.
		/// </summary>
		/// <param name="bEnabled">
		/// Indicates the local effects state that is to be applied to the offloaded audio stream. A value of <c>TRUE</c> enables local
		/// effects, and the local effects in the audio graph are applied to the stream. A value of <c>FALSE</c> disables local effects, so
		/// that the local effects in the audio graph are not applied to the audio stream.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudiolfxcontrol-setlocaleffectsstate
		// HRESULT SetLocalEffectsState( BOOL bEnabled );
		void SetLocalEffectsState([MarshalAs(UnmanagedType.Bool)] bool bEnabled);

		/// <summary>
		/// The <c>GetLocalEffectsState</c> method retrieves the local effects state that is currently applied to the offloaded audio stream.
		/// </summary>
		/// <returns>
		/// A pointer to the Boolean variable that indicates the state of the local effects that have been applied to the offloaded audio
		/// stream. A value of <c>TRUE</c> indicates that local effects have been enabled and applied to the stream. A value of <c>FALSE</c>
		/// indicates that local effects have been disabled.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudiolfxcontrol-getlocaleffectsstate
		// HRESULT GetLocalEffectsState( BOOL *pbEnabled );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetLocalEffectsState();
	}

	/// <summary>Gets the output buffer for each processing pass. The <c>IAudioOutputEndpointRT</c> interface is used by the audio engine.</summary>
	/// <remarks>
	/// <para>
	/// <c>IAudioOutputEndpointRT</c> methods can be called from a real-time processing thread. The implementation of the methods of this
	/// interface must not block, access paged memory, or call any blocking system routines.
	/// </para>
	/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nn-audioengineendpoint-iaudiooutputendpointrt
	[PInvokeData("audioengineendpoint.h", MSDNShortId = "b881b2f9-ffe9-46ff-94aa-eef0af172a3e")]
	[ComImport, Guid("8FA906E4-C31C-4e31-932E-19A66385E9AA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioOutputEndpointRT
	{
		/// <summary>
		/// The <c>GetOutputDataPointer</c> method returns a pointer to the output buffer in which data will be written by the audio engine.
		/// </summary>
		/// <param name="u32FrameCount">
		/// The number of frames in the output buffer pointed to by the data pointer that is returned by this method. The endpoint must not
		/// cache this information because this can be changed by the audio engine depending on its processing requirements. For more
		/// information, see Remarks.
		/// </param>
		/// <param name="pAeTimeStamp">
		/// A pointer to an AE_CURRENT_POSITION structure that specifies the time stamp of the data that is rendered. This parameter is optional.
		/// </param>
		/// <returns>A pointer to the buffer to which data will be written.</returns>
		/// <remarks>
		/// <para>
		/// This method returns a pointer to a buffer in which the audio engine writes data. The data is not valid until the
		/// IAudioOutputEndpointRT::ReleaseOutputDataPointer method is called. The returned pointer must be frame-aligned.
		/// </para>
		/// <para>
		/// The frame count passed in <c>u32FrameCount</c> must be less than or equal to the maximum number of frames supported by the
		/// endpoint. To get the maximum frame count that the endpoint can support, the audio engine calls the
		/// IAudioEndpoint::GetFramesPerPacket method.
		/// </para>
		/// <para>
		/// This method can be called from a real-time processing thread. The implementation of this method must not block, access paged
		/// memory, or call any blocking system routines.
		/// </para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudiooutputendpointrt-getoutputdatapointer
		// UINT_PTR GetOutputDataPointer( UINT32 u32FrameCount, AE_CURRENT_POSITION *pAeTimeStamp );
		[PreserveSig]
		IntPtr GetOutputDataPointer(uint u32FrameCount, [In] IntPtr pAeTimeStamp);

		/// <summary>The <c>ReleaseOutputDataPointer</c> method releases the pointer to the output buffer.</summary>
		/// <param name="pConnectionProperty">
		/// <para>
		/// A pointer to an APO_CONNECTION_PROPERTYstructure. The values in the structure must not be changed. The caller sets the members as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <c>pBuffer</c> is set to the pointer to the output data buffer returned by the IAudioOutputEndpointRT::GetOutputDataPointer method.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>u32ValidFrameCount</c> is set to the actual number of frames that have been generated by the audio engine. The value might not
		/// be the same as the frame count passed in the u32FrameCount parameter of the GetOutputDataPointer method.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>u32BufferFlags</c> is set to <c>BUFFER_VALID</c> if the output buffer pointed to by the <c>pBuffer</c> member contains valid
		/// data. <c>u32BufferFlags</c> is set to <c>BUFFER_SILENT</c> if the output buffer contains only silent data. The data in the buffer
		/// does not actually need to be silence, but the buffer specified in the <c>pBuffer</c> member must be capable of holding all the
		/// frames of silence contained in the <c>u32ValidFrameCount</c> member. Therefore, if <c>BUFFER_SILENT</c> is specified, the
		/// endpoint should write silence in the output buffer.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <c>ReleaseOutputDataPointer</c> notifies the endpoint that the audio engine has completed the task of writing data in the output
		/// buffer and no longer requires the data pointer. This method also relays information such as the time that corresponds to the
		/// audio samples in the output buffer, the number of frames generated by the audio engine, and whether the buffer is full of valid
		/// data or silence data. Based on this information, an endpoint that represents a looped buffer and is attached to the output of the
		/// audio engine can advance its write position in the buffer. A value of zero in the u32FrameCount parameter of the
		/// GetOutputDataPointer method indicates that the audio engine did not write any valid data in the output buffer. The u32FrameCount
		/// parameter value must be less than or equal to the frame count specified in <c>GetOutputDataPointer</c>. The endpoint must not
		/// assume that all data requested by <c>GetOutputDataPointer</c> was actually generated.
		/// </para>
		/// <para>
		/// This method can be called from a real-time processing thread. The implementation of this method must not block, access paged
		/// memory, or call any blocking system routines.
		/// </para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudiooutputendpointrt-releaseoutputdatapointer
		// void ReleaseOutputDataPointer( const APO_CONNECTION_PROPERTY *pConnectionProperty );
		[PreserveSig]
		void ReleaseOutputDataPointer(in APO_CONNECTION_PROPERTY pConnectionProperty);

		/// <summary>
		/// <para>The <c>PulseEndpoint</c> method is reserved.</para>
		/// <para>
		/// This method is called by the audio engine at the end of a processing pass. The event handle is set by calling the
		/// IAudioEndpoint::SetEventHandle method.
		/// </para>
		/// </summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method can be called from a real-time processing thread. The implementation of this method must not block, access paged
		/// memory, or call any blocking system routines.
		/// </para>
		/// <para>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-iaudiooutputendpointrt-pulseendpoint
		// void PulseEndpoint();
		[PreserveSig]
		void PulseEndpoint();
	}

	/// <summary>
	/// The <c>IHardwareAudioEngineBase</c> interface is implemented by audio endpoints for the audio stack to use to configure and retrieve
	/// information about the hardware audio engine.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nn-audioengineendpoint-ihardwareaudioenginebase
	[PInvokeData("audioengineendpoint.h", MSDNShortId = "6FB9BEDB-111B-4F0A-B8BB-B0BA2024EB24")]
	[ComImport, Guid("EDDCE3E4-F3C1-453a-B461-223563CBD886"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IHardwareAudioEngineBase
	{
		/// <summary>
		/// The <c>GetAvailableOffloadConnectorCount</c> method retrieves the number of avaialable endpoints that can handle offloaded
		/// streams on the hardware audio engine.
		/// </summary>
		/// <param name="_pwstrDeviceId">A pointer to the device ID of the hardware audio engine device.</param>
		/// <param name="_uConnectorId">The identifier for the endpoint connector.</param>
		/// <returns>The number of available endpoint connectors that can handle offloaded audio streams.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-ihardwareaudioenginebase-getavailableoffloadconnectorcount
		// HRESULT GetAvailableOffloadConnectorCount( StrPtrUni _pwstrDeviceId, UINT32 _uConnectorId, UINT32 *_pAvailableConnectorInstanceCount );
		uint GetAvailableOffloadConnectorCount([MarshalAs(UnmanagedType.LPWStr)] string _pwstrDeviceId, uint _uConnectorId);

		/// <summary>The <c>GetEngineFormat</c> method retrieves the current data format of the offloaded audio stream.</summary>
		/// <param name="pDevice">A pointer to an IMMDevice interface.</param>
		/// <param name="_bRequestDeviceFormat">
		/// A Boolean variable that indicates whether or not the <c>IMMDevice</c> interface is being accessed to retrieve the device format.
		/// </param>
		/// <param name="_ppwfxFormat">
		/// A pointer to a pointer to a WAVEFORMATEX structure that provides information about the hardware audio engine. This includes the
		/// waveform audio format type, the number of audio channels, and the sample rate of the audio engine.
		/// </param>
		/// <returns>
		/// The <c>GetEngineFormat</c> method returns <c>S_OK</c> to indicate that it has completed successfully. Otherwise it returns an
		/// appropriate error code.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-ihardwareaudioenginebase-getengineformat
		// HRESULT GetEngineFormat( IMMDevice *pDevice, BOOL _bRequestDeviceFormat, WAVEFORMATEX **_ppwfxFormat );
		void GetEngineFormat(IMMDevice pDevice, [MarshalAs(UnmanagedType.Bool)] bool _bRequestDeviceFormat, out SafeCoTaskMemHandle _ppwfxFormat);

		/// <summary>The <c>SetEngineDeviceFormat</c> method sets the waveform audio format for the hardware audio engine.</summary>
		/// <param name="pDevice">A pointer to an IMMDevice interface.</param>
		/// <param name="_pwfxFormat">A pointer to a WAVEFORMATEX structure that provides information about the hardware audio engine.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-ihardwareaudioenginebase-setenginedeviceformat
		// HRESULT SetEngineDeviceFormat( IMMDevice *pDevice, WAVEFORMATEX *_pwfxFormat );
		void SetEngineDeviceFormat(IMMDevice pDevice, in WAVEFORMATEX _pwfxFormat);

		/// <summary>The <c>SetGfxState</c> method sets the GFX state of the offloaded audio stream.</summary>
		/// <param name="pDevice">Pointer to an IMMDevice interface.</param>
		/// <param name="_bEnable">Pointer to a boolean variable.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-ihardwareaudioenginebase-setgfxstate
		// HRESULT SetGfxState( IMMDevice *pDevice, BOOL _bEnable );
		void SetGfxState(IMMDevice pDevice, [MarshalAs(UnmanagedType.Bool)] bool _bEnable);

		/// <summary>The <c>GetGfxState</c> method retrieves the GFX state of the offloaded audio stream.</summary>
		/// <param name="pDevice">Pointer to an IMMDevice interface.</param>
		/// <returns>Pointer to a boolean variable.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/nf-audioengineendpoint-ihardwareaudioenginebase-getgfxstate
		// HRESULT GetGfxState( IMMDevice *pDevice, BOOL *_pbEnable );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetGfxState(IMMDevice pDevice);
	}

	/// <summary>Reports the current frame position from the device to the clients.</summary>
	/// <remarks>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioengineendpoint/ns-audioengineendpoint-ae_current_position typedef struct
	// AE_CURRENT_POSITION { UINT64 u64DevicePosition; UINT64 u64StreamPosition; UINT64 u64PaddingFrames; long hnsQPCPosition; float
	// f32FramesPerSecond; AE_POSITION_FLAGS Flag; } AE_CURRENT_POSITION, *PAE_CURRENT_POSITION;
	[PInvokeData("audioengineendpoint.h", MSDNShortId = "2e239114-1af7-455a-a60f-2054b05e1414")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AE_CURRENT_POSITION
	{
		/// <summary>The device position, in frames.</summary>
		public ulong u64DevicePosition;

		/// <summary>
		/// The stream position, in frames, used to determine the starting point for audio capture and the render device position relative to
		/// the stream.
		/// </summary>
		public ulong u64StreamPosition;

		/// <summary>The amount of padding, in frames, between the current position and the stream fill point.</summary>
		public ulong u64PaddingFrames;

		/// <summary>
		/// A translated quality performance counter (QPC) timer value taken at the time that the <c>u64DevicePosition</c> member was checked.
		/// </summary>
		public long hnsQPCPosition;

		/// <summary>The calculated data rate at the point at the time the position was set.</summary>
		public float f32FramesPerSecond;

		/// <summary>A value of the AE_POSITION_FLAGS enumeration that indicates the validity of the position information.</summary>
		public AE_POSITION_FLAGS Flag;
	}

	/// <summary>Contains creation parameters for the endpoint used in shared mode.</summary>
	/// <remarks>The Remote Desktop Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</remarks>
	// https://docs.microsoft.com/en-us/previous-versions/dd408134(v=vs.85) typedef struct _AUDIO_ENDPOINT_SHARED_CREATE_PARAMS { uint
	// u32Size; uint u32TSSessionId; EndpointConnectorType targetEndpointConnectorType; WAVEFORMATEX wfxDeviceFormat; }
	// AUDIO_ENDPOINT_SHARED_CREATE_PARAMS, *PAUDIO_ENDPOINT_SHARED_CREATE_PARAMS;
	[PInvokeData("Audioengineendpoint.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AUDIO_ENDPOINT_SHARED_CREATE_PARAMS
	{
		/// <summary>The size of this structure.</summary>
		public uint u32Size;

		/// <summary>The session identifier.</summary>
		public uint u32TSSessionId;

		/// <summary>The type of the endpoint.</summary>
		public EndpointConnectorType targetEndpointConnectorType;

		/// <summary>The format of the device that is represented by the endpoint.</summary>
		public WAVEFORMATEX wfxDeviceFormat;
	}
}