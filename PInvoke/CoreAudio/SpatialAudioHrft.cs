namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from Windows Core Audio Api.</summary>
public static partial class CoreAudio
{
	/// <summary>Specifies the shape in which sound is emitted by an ISpatialAudioObjectForHrtf.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/ne-spatialaudiohrtf-spatialaudiohrtfdirectivitytype typedef enum
	// SpatialAudioHrtfDirectivityType { SpatialAudioHrtfDirectivity_OmniDirectional, SpatialAudioHrtfDirectivity_Cardioid,
	// SpatialAudioHrtfDirectivity_Cone } ;
	[PInvokeData("spatialaudiohrtf.h", MSDNShortId = "3A1426B5-F4FF-4CF0-9E0A-3096371B3D2E")]
	public enum SpatialAudioHrtfDirectivityType
	{
		/// <summary>The sound is emitted in all directions.</summary>
		SpatialAudioHrtfDirectivity_OmniDirectional,

		/// <summary>The sound is emitted in a cardioid shape.</summary>
		SpatialAudioHrtfDirectivity_Cardioid,

		/// <summary>The sound is emitted in a cone shape.</summary>
		SpatialAudioHrtfDirectivity_Cone,
	}

	/// <summary>
	/// Specifies the type of decay applied over distance from the position of an ISpatialAudioObjectForHrtf to the position of the listener.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/ne-spatialaudiohrtf-spatialaudiohrtfdistancedecaytype typedef enum
	// SpatialAudioHrtfDistanceDecayType { SpatialAudioHrtfDistanceDecay_NaturalDecay, SpatialAudioHrtfDistanceDecay_CustomDecay } ;
	[PInvokeData("spatialaudiohrtf.h", MSDNShortId = "EF4ACEB1-E802-4337-AA76-467BCB90D7C6")]
	public enum SpatialAudioHrtfDistanceDecayType
	{
		/// <summary>
		/// A natural decay over distance, as constrained by minimum and maximum gain distance limits. The output drops to silent at the
		/// distance specified by SpatialAudioHrtfDistanceDecay.CutoffDistance.
		/// </summary>
		SpatialAudioHrtfDistanceDecay_NaturalDecay,

		/// <summary>A custom gain curve, within the maximum and minimum gain limit.</summary>
		SpatialAudioHrtfDistanceDecay_CustomDecay,
	}

	/// <summary>Specifies the type of acoustic environment that is simulated when audio is processed for an ISpatialAudioObjectForHrtf.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/ne-spatialaudiohrtf-spatialaudiohrtfenvironmenttype typedef enum
	// SpatialAudioHrtfEnvironmentType { SpatialAudioHrtfEnvironment_Small, SpatialAudioHrtfEnvironment_Medium,
	// SpatialAudioHrtfEnvironment_Large, SpatialAudioHrtfEnvironment_Outdoors, SpatialAudioHrtfEnvironment_Average } ;
	[PInvokeData("spatialaudiohrtf.h", MSDNShortId = "017FC8D4-2B74-4B13-AF5B-D7FFF97A7E45")]
	public enum SpatialAudioHrtfEnvironmentType
	{
		/// <summary>A small room.</summary>
		SpatialAudioHrtfEnvironment_Small,

		/// <summary>A medium-sized room.</summary>
		SpatialAudioHrtfEnvironment_Medium,

		/// <summary>A large room.</summary>
		SpatialAudioHrtfEnvironment_Large,

		/// <summary>An outdoor space.</summary>
		SpatialAudioHrtfEnvironment_Outdoors,

		/// <summary>Reserved for Microsoft use. Apps should not use this value.</summary>
		SpatialAudioHrtfEnvironment_Average,
	}

	/// <summary>
	/// <para>
	/// Represents an object that provides audio data to be rendered from a position in 3D space, relative to the user, a head-relative
	/// transfer function (HRTF). Spatial audio objects can be static or dynamic, which you specify with the type parameter to the
	/// ISpatialAudioObjectRenderStreamForHrtf::ActivateSpatialAudioObjectForHrtf method. Dynamic audio objects can be placed in an arbitrary
	/// position in space and can be moved over time. Static audio objects are assigned to one or more channels, defined in the
	/// AudioObjectType enumeration, that each correlate to a fixed speaker location that may be a physical or a virtualized speaker
	/// </para>
	/// <para>
	/// This interface is a part of Windows Sonic, Microsoft’s audio platform for more immersive audio which includes integrated spatial
	/// sound on Xbox and Windows.
	/// </para>
	/// </summary>
	/// <remarks><c>Note</c> Many of the methods provided by this interface are implemented in the inherited ISpatialAudioObjectBase interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/nn-spatialaudiohrtf-ispatialaudioobjectforhrtf
	[PInvokeData("spatialaudiohrtf.h", MSDNShortId = "E69F1D09-B937-4BCC-A040-18EF8A838289")]
	[ComImport, Guid("D7436ADE-1978-4E14-ABA0-555BD8EB83B4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpatialAudioObjectForHrtf : ISpatialAudioObjectBase
	{
		/// <summary>Gets a buffer that is used to supply the audio data for the ISpatialAudioObject.</summary>
		/// <param name="buffer">The buffer into which audio data is written.</param>
		/// <param name="bufferLength">
		/// The length of the buffer in bytes. This length will be the value returned in the frameCountPerBuffer parameter to
		/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects multiplied by the value of the <c>nBlockAlign</c> field of the
		/// WAVEFORMATEX structure passed in the SpatialAudioObjectRenderStreamActivationParams parameter to ISpatialAudioClient::ActivateSpatialAudioStream.
		/// </param>
		/// <remarks>
		/// <para>
		/// The first time <c>GetBuffer</c> is called after the ISpatialAudioObject is activated with a call
		/// ISpatialAudioObjectRenderStream::ActivateSpatialAudioObject, lifetime of the spatial audio object starts. To keep the spatial
		/// audio object alive after that, this <c>GetBuffer</c> must be called on every processing pass (between calls to
		/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects and ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects). If
		/// <c>GetBuffer</c> is not called within an audio processing pass, SetEndOfStream is called implicitly on the audio object to
		/// deactivate, and the audio object can only be reused after calling Release on the object and then reactivating the object by
		/// calling <c>ActivateSpatialAudioObject</c> again.
		/// </para>
		/// <para>
		/// The pointers retrieved by <c>GetBuffer</c> should not be used after ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects has
		/// been called.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-getbuffer
		// HRESULT GetBuffer( BYTE **buffer, UINT32 *bufferLength );
		new void GetBuffer(out IntPtr buffer, out uint bufferLength);

		/// <summary>
		/// Instructs the system that the final block of audio data has been submitted for the ISpatialAudioObject so that the object can be
		/// deactivated and it's resources reused.
		/// </summary>
		/// <param name="frameCount">
		/// The number of audio frames in the audio buffer that should be included in the final processing pass. This number may be smaller
		/// than or equal to the value returned in the frameCountPerBuffer parameter to ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects.
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
		/// <term>SPTLAUDCLNT_E_OUT_OF_ORDER</term>
		/// <term>ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects was not called before the call to SetEndOfStream.</term>
		/// </item>
		/// <item>
		/// <term>SPTLAUDCLNT_E_RESOURCES_INVALIDATED</term>
		/// <term>
		/// SetEndOfStream was called either explicitly or implicitly in a previous audio processing pass. SetEndOfStream is called
		/// implicitly by the system if GetBuffer is not called within an audio processing pass (between calls to
		/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects and ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects).
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>Call Release after calling <c>SetEndOfStream</c> to make free the audio object resources for future use.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-setendofstream
		// HRESULT SetEndOfStream( UINT32 frameCount );
		new void SetEndOfStream([In] uint frameCount);

		/// <summary>Gets a boolean value indicating whether the ISpatialAudioObject is valid.</summary>
		/// <returns><c>TRUE</c> if the audio object is currently valid; otherwise, <c>FALSE</c>.</returns>
		/// <remarks>
		/// <para>If this value is false, you should call Release to make the audio object resource available in the future.</para>
		/// <para>
		/// <c>IsActive</c> will be set to false after SetEndOfStream is called implicitly or explicitly. <c>SetEndOfStream</c> is called
		/// implicitly by the system if GetBuffer is not called within an audio processing pass (between calls to
		/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects and ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects).
		/// </para>
		/// <para>
		/// The rendering engine will also deactivate the audio object, setting <c>IsActive</c> to false, when audio object resources become
		/// unavailable. In this case, a notification is sent via ISpatialAudioObjectRenderStreamNotify before the object is deactivated. The
		/// value returned in the availableDynamicObjectCount parameter to ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects
		/// indicates how many objects will be processed for each pass.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-isactive
		// HRESULT IsActive( BOOL *isActive );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsActive();

		/// <summary>
		/// Gets a value specifying the type of audio object that is represented by the ISpatialAudioObject. This value indicates if the
		/// object is dynamic or static. If the object is static, one and only one of the static audio channel values to which the object is
		/// assigned is returned.
		/// </summary>
		/// <returns>A value specifying the type of audio object that is represented</returns>
		/// <remarks>
		/// Set the type of the audio object with the type parameter to the ISpatialAudioObjectRenderStream::ActivateSpatialAudioObject method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-getaudioobjecttype
		// HRESULT GetAudioObjectType( AudioObjectType *audioObjectType );
		new AudioObjectType GetAudioObjectType();

		/// <summary>
		/// Sets the position in 3D space, relative to the listener, from which the ISpatialAudioObjectForHrtf audio data will be rendered.
		/// </summary>
		/// <param name="x">
		/// The x position of the audio object, in meters, relative to the listener. Positive values are to the right of the listener and
		/// negative values are to the left.
		/// </param>
		/// <param name="y">
		/// The y position of the audio object, in meters, relative to the listener. Positive values are above the listener and negative
		/// values are below.
		/// </param>
		/// <param name="z">
		/// The z position of the audio object, in meters, relative to the listener. Positive values are behind the listener and negative
		/// values are in front.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method can only be called on a ISpatialAudioObjectForHrtf that is of type <c>AudioObjectType_Dynamic</c>. Set the type of
		/// the audio object with the type parameter to the ISpatialAudioObjectRenderStreamForHrtf::ActivateSpatialAudioObjectForHrtf method.
		/// </para>
		/// <para>
		/// Position values use a right-handed Cartesian coordinate system, where each unit represents 1 meter. The coordinate system is
		/// relative to the listener where the origin (x=0.0, y=0.0, z=0.0) represents the center point between the listener's ears.
		/// </para>
		/// <para>
		/// If <c>SetPosition</c> is never called, the origin (x=0.0, y=0.0, z=0.0) is used as the default position. After <c>SetPosition</c>
		/// is called, the position that is set will be used for the audio object until the position is changed with another call to <c>SetPosition</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/nf-spatialaudiohrtf-ispatialaudioobjectforhrtf-setposition
		// HRESULT SetPosition( float x, float y, float z );
		void SetPosition([In] float x, [In] float y, [In] float z);

		/// <summary>Sets the gain for the ISpatialAudioObjectForHrtf.</summary>
		/// <param name="gain">The gain for the ISpatialAudioObjectForHrtf.</param>
		/// <remarks>
		/// <para>
		/// This is valid only for spatial audio objects configured to use the SpatialAudioHrtfDistanceDecay_CustomDecay decay type. Set the
		/// decay type of an ISpatialAudioObjectForHrtf object by calling SetDistanceDecay. Set the default decay type for an all objects in
		/// an HRTF render stream by setting the <c>DistanceDecay</c> field of the SpatialAudioHrtfActivationParams passed into ISpatialAudioClient::ActivateSpatialAudioStream.
		/// </para>
		/// <para>
		/// If <c>SetGain</c> is never called, the default value of 0.0 is used. After <c>SetGain</c> is called, the gain that is set will be
		/// used for the audio object until the gain is changed with another call to <c>SetGain</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/nf-spatialaudiohrtf-ispatialaudioobjectforhrtf-setgain HRESULT
		// SetGain( float gain );
		void SetGain([In] float gain);

		/// <summary>
		/// Sets the orientation in 3D space, relative to the listener's frame of reference, from which the ISpatialAudioObjectForHrtf audio
		/// data will be rendered.
		/// </summary>
		/// <param name="orientation">An array of floats defining row-major 3x3 rotation matrix.</param>
		/// <remarks>
		/// If <c>SetOrientation</c> is never called, the default value of an identity matrix is used. After <c>SetOrientation</c> is called,
		/// the orientation that is set will be used for the audio object until the orientation is changed with another call to <c>SetOrientation</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/nf-spatialaudiohrtf-ispatialaudioobjectforhrtf-setorientation
		// HRESULT SetOrientation( const SpatialAudioHrtfOrientation *orientation );
		void SetOrientation(in SpatialAudioHrtfOrientation orientation);

		/// <summary>Sets the type of acoustic environment that is simulated when audio is processed for the ISpatialAudioObjectForHrtf.</summary>
		/// <param name="environment">
		/// A value specifying the type of acoustic environment that is simulated when audio is processed for the ISpatialAudioObjectForHrtf.
		/// </param>
		/// <remarks>If <c>SetEnvironment</c> is not called, the default value of SpatialAudioHrtfEnvironment_Small is used.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/nf-spatialaudiohrtf-ispatialaudioobjectforhrtf-setenvironment
		// HRESULT SetEnvironment( SpatialAudioHrtfEnvironmentType environment );
		void SetEnvironment([In] SpatialAudioHrtfEnvironmentType environment);

		/// <summary>
		/// Sets the decay model that is applied over distance from the position of an ISpatialAudioObjectForHrtf to the position of the listener.
		/// </summary>
		/// <param name="distanceDecay">The decay model.</param>
		/// <remarks>If <c>SetEnvironment</c> is not called, the default values are used.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/nf-spatialaudiohrtf-ispatialaudioobjectforhrtf-setdistancedecay
		// HRESULT SetDistanceDecay( SpatialAudioHrtfDistanceDecay *distanceDecay );
		void SetDistanceDecay(in SpatialAudioHrtfDistanceDecay distanceDecay);

		/// <summary>Sets the spatial audio directivity model for the ISpatialAudioObjectForHrtf.</summary>
		/// <param name="directivity">
		/// <para>The spatial audio directivity model. This value can be one of the following structures:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>SpatialAudioHrtfDirectivity</term>
		/// </item>
		/// <item>
		/// <term>SpatialAudioHrtfDirectivityCardioid</term>
		/// </item>
		/// <item>
		/// <term>SpatialAudioHrtfDirectivityCone</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// The SpatialAudioHrtfDirectivity structure represents an omnidirectional model that can be linearly interpolated with a cardioid
		/// or cone model.
		/// </para>
		/// <para>
		/// If <c>SetDirectivity</c> is not called, the default type of SpatialAudioHrtfDirectivity_OmniDirectional is used with no interpolation.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/nf-spatialaudiohrtf-ispatialaudioobjectforhrtf-setdirectivity
		// HRESULT SetDirectivity( SpatialAudioHrtfDirectivityUnion *directivity );
		void SetDirectivity(in SpatialAudioHrtfDirectivityUnion directivity);
	}

	/// <summary>
	/// <para>
	/// Provides methods for controlling an Hrtf spatial audio object render stream, including starting, stopping, and resetting the stream.
	/// Also provides methods for activating new ISpatialAudioObjectForHrtf instances and notifying the system when you are beginning and
	/// ending the process of updating activated spatial audio objects and data.
	/// </para>
	/// <para>
	/// This interface is a part of Windows Sonic, Microsoft’s audio platform for more immersive audio which includes integrated spatial
	/// sound on Xbox and Windows.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <c>Note</c> Many of the methods provided by this interface are implemented in the inherited ISpatialAudioObjectRenderStreamBase interface.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/nn-spatialaudiohrtf-ispatialaudioobjectrenderstreamforhrtf
	[ComImport, Guid("E08DEEF9-5363-406E-9FDC-080EE247BBE0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpatialAudioObjectRenderStreamForHrtf : ISpatialAudioObjectRenderStreamBase
	{
		/// <summary>Gets the number of dynamic spatial audio objects that are currently available.</summary>
		/// <returns>The number of dynamic spatial audio objects that are currently available.</returns>
		/// <remarks>
		/// <para>
		/// A dynamic ISpatialAudioObject is one that was activated by setting the type parameter to the ActivateSpatialAudioObject method to
		/// <c>AudioObjectType_Dynamic</c>. The system has a limit of the maximum number of dynamic spatial audio objects that can be
		/// activated at one time. Call Release on an <c>ISpatialAudioObject</c> when it is no longer being used to free up the resource to
		/// create new dynamic spatial audio objects.
		/// </para>
		/// <para>
		/// You should not call this method after streaming has started, as the value is already provided by
		/// ISpatialAudioObjectRenderStreamBase::BeginUpdatingAudioObjects. This method should only be called before streaming has started,
		/// which occurs after ISpatialAudioObjectRenderStreamBase::Start is called.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-getavailabledynamicobjectcount
		// HRESULT GetAvailableDynamicObjectCount( UINT32 *value );
		new uint GetAvailableDynamicObjectCount();

		/// <summary>Gets additional services from the <c>ISpatialAudioObjectRenderStream</c>.</summary>
		/// <param name="riid">
		/// <para>The interface ID for the requested service. The client should set this parameter to one of the following REFIID values:</para>
		/// <para>IID_IAudioClock</para>
		/// <para>IID_IAudioClock2</para>
		/// <para>IID_IAudioStreamVolume</para>
		/// </param>
		/// <param name="service">
		/// Pointer to a pointer variable into which the method writes the address of an instance of the requested interface. Through this
		/// method, the caller obtains a counted reference to the interface. The caller is responsible for releasing the interface, when it
		/// is no longer needed, by calling the interface's Release method. If the <c>GetService</c> call fails, *ppv is NULL.
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
		/// <term>E_POINTER</term>
		/// <term>Parameter ppv is NULL.</term>
		/// </item>
		/// <item>
		/// <term>SPTLAUDCLNT_E_DESTROYED</term>
		/// <term>The ISpatialAudioClient associated with the spatial audio stream has been destroyed.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_DEVICE_INVALIDATED</term>
		/// <term>
		/// The audio endpoint device has been unplugged, or the audio hardware or associated hardware resources have been reconfigured,
		/// disabled, removed, or otherwise made unavailable for use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SPTLAUDCLNT_E_INTERNAL</term>
		/// <term>An internal error has occurred.</term>
		/// </item>
		/// <item>
		/// <term>AUDCLNT_E_UNSUPPORTED_FORMAT</term>
		/// <term>The media associated with the spatial audio stream uses an unsupported format.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetService</c> method supports the following service interfaces:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IAudioClock</term>
		/// </item>
		/// <item>
		/// <term>IAudioClock2</term>
		/// </item>
		/// <item>
		/// <term>IAudioStreamVolume</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-getservice
		// HRESULT GetService( REFIID riid, void **service );
		[PreserveSig]
		new HRESULT GetService(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object service);

		/// <summary>Starts the spatial audio stream.</summary>
		/// <remarks>
		/// <para>
		/// Starting the stream causes data flow between the endpoint buffer and the audio engine. The first time this method is called, the
		/// stream's audio clock position will be at 0. Otherwise, the clock resumes from its position at the time that the stream was last
		/// paused with a call to Stop. Call Reset to reset the clock position to 0 and cause all active ISpatialAudioObject instances to be revoked.
		/// </para>
		/// <para>The stream must have been previously stopped with a call to Stop or the method will fail and return SPTLAUDCLNT_E_STREAM_NOT_STOPPED.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-start
		// HRESULT Start();
		new void Start();

		/// <summary>Stops a running audio stream.</summary>
		/// <remarks>
		/// Stopping stream causes data to stop flowing between the endpoint buffer and the audio engine. You can consider this operation to
		/// pause the stream because it leaves the stream's audio clock at its current stream position and does not reset it to 0. A
		/// subsequent call to Start causes the stream to resume running from the current position. Call Reset to reset the clock position to
		/// 0 and cause all active ISpatialAudioObject instances to be revoked.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-stop
		// HRESULT Stop();
		new void Stop();

		/// <summary>Reset a stopped audio stream.</summary>
		/// <remarks>
		/// <para>
		/// Resetting the audio stream flushes all pending data and resets the audio clock stream position to 0. Resetting the stream also
		/// causes all active ISpatialAudioObject instances to be revoked. A subsequent call to Start causes the stream to start from 0 position.
		/// </para>
		/// <para>The stream must have been previously stopped with a call to Stop or the method will fail and return SPTLAUDCLNT_E_STREAM_NOT_STOPPED.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-reset
		// HRESULT Reset();
		new void Reset();

		/// <summary>
		/// Puts the system into the state where audio object data can be submitted for processing and the ISpatialAudioObject state can be modified.
		/// </summary>
		/// <param name="availableDynamicObjectCount">
		/// The number of dynamic audio objects that are available to be rendered for the current processing pass. All allocated static audio
		/// objects can be rendered in every pass. For information on audio object types, see AudioObjectType.
		/// </param>
		/// <param name="frameCountPerBuffer">The size, in audio frames, of the buffer returned by GetBuffer.</param>
		/// <remarks>
		/// <para>
		/// This method must be called each time the event passed in the SpatialAudioObjectRenderStreamActivationParams to
		/// ISpatialAudioClient::ActivateSpatialAudioStream is signaled, even if there no audio object data to submit.
		/// </para>
		/// <para>
		/// For each <c>BeginUpdatingAudioObjects</c> call, there should be a corresponding call to EndUpdatingAudioObjects call. If
		/// <c>BeginUpdatingAudioObjects</c> is called twice without a call <c>EndUpdatingAudioObjects</c> between them, the second call to
		/// <c>BeginUpdatingAudioObjects</c> will return SPTLAUDCLNT_E_OUT_OF_ORDER.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-beginupdatingaudioobjects
		// HRESULT BeginUpdatingAudioObjects( UINT32 *availableDynamicObjectCount, UINT32 *frameCountPerBuffer );
		new void BeginUpdatingAudioObjects(out uint availableDynamicObjectCount, out uint frameCountPerBuffer);

		/// <summary>Notifies the system that the app has finished supplying audio data for the spatial audio objects activated with ActivateSpatialAudioObject.</summary>
		/// <remarks>The pointers retrieved with ISpatialAudioObjectBase::GetBuffer can no longer be used after this method is called.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-endupdatingaudioobjects
		// HRESULT EndUpdatingAudioObjects();
		new void EndUpdatingAudioObjects();

		/// <summary>Activates an ISpatialAudioObjectForHrtf for audio rendering.</summary>
		/// <param name="type">
		/// The type of audio object to activate. For dynamic audio objects, this value must be <c>AudioObjectType_Dynamic</c>. For static
		/// audio objects, specify one of the static audio channel values from the enumeration. Specifying <c>AudioObjectType_None</c> will
		/// produce an audio object that is not spatialized.
		/// </param>
		/// <returns>Receives a pointer to the activated interface.</returns>
		/// <remarks>
		/// A dynamic ISpatialAudioObjectForHrtf is one that was activated by setting the type parameter to the
		/// <c>ActivateSpatialAudioObjectForHrtf</c> method to <c>AudioObjectType_Dynamic</c>. The client has a limit of the maximum number
		/// of dynamic spatial audio objects that can be activated at one time. After the limit has been reached, attempting to activate
		/// additional audio objects will result in this method returning an SPTLAUDCLNT_E_NO_MORE_OBJECTS error. To avoid this, call Release
		/// on each dynamic <c>ISpatialAudioObjectForHrtf</c> after it is no longer being used to free up the resource so that it can be
		/// reallocated. See ISpatialAudioObjectgBase::IsActive and ISpatialAudioObjectgBase::SetEndOfStream for more information on the
		/// managing the lifetime of spatial audio objects.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/nf-spatialaudiohrtf-ispatialaudioobjectrenderstreamforhrtf-activatespatialaudioobjectforhrtf
		// HRESULT ActivateSpatialAudioObjectForHrtf( AudioObjectType type, ISpatialAudioObjectForHrtf **audioObject );
		ISpatialAudioObjectForHrtf ActivateSpatialAudioObjectForHrtf([In] AudioObjectType type);
	}

	/// <summary>Specifies the activation parameters for an ISpatialAudioRenderStreamForHrtf.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/ns-spatialaudiohrtf-spatialaudiohrtfactivationparams typedef
	// struct SpatialAudioHrtfActivationParams { const WAVEFORMATEX *ObjectFormat; AudioObjectType StaticObjectTypeMask; UINT32
	// MinDynamicObjectCount; UINT32 MaxDynamicObjectCount; AUDIO_STREAM_CATEGORY Category; HANDLE EventHandle;
	// ISpatialAudioObjectRenderStreamNotify *NotifyObject; SpatialAudioHrtfDistanceDecay *DistanceDecay; SpatialAudioHrtfDirectivityUnion
	// *Directivity; SpatialAudioHrtfEnvironmentType *Environment; SpatialAudioHrtfOrientation
	// *Orientation; } SpatialAudioHrtfActivationParams;
	[PInvokeData("spatialaudiohrtf.h", MSDNShortId = "6A549BFB-993A-4A20-AFAB-B38D03EAE35C")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SpatialAudioHrtfActivationParams
	{
		/// <summary>
		/// Format descriptor for spatial audio objects associated with the stream. All objects must have the same format and must be of type
		/// WAVEFORMATEX or WAVEFORMATEXTENSIBLE.
		/// </summary>
		public IntPtr /*WAVEFORMATEX*/ ObjectFormat;

		/// <summary>
		/// A bitwise combination of <c>AudioObjectType</c> values indicating the set of static spatial audio channels that will be allowed
		/// by the activated stream.
		/// </summary>
		public AudioObjectType StaticObjectTypeMask;

		/// <summary>
		/// The minimum number of concurrent dynamic objects. If this number of dynamic audio objects can't be activated simultaneously, no
		/// dynamic audio objects will be activated.
		/// </summary>
		public uint MinDynamicObjectCount;

		/// <summary>The maximum number of concurrent dynamic objects that can be activated with ISpatialAudioRenderStreamForHrtf.</summary>
		public uint MaxDynamicObjectCount;

		/// <summary>The category of the audio stream and its spatial audio objects.</summary>
		public AUDIO_STREAM_CATEGORY Category;

		/// <summary>
		/// The event that will signal the client to provide more audio data. This handle will be duplicated internally before it is used.
		/// </summary>
		public HEVENT EventHandle;

		/// <summary>
		/// The object that provides notifications for spatial audio clients to respond to changes in the state of an
		/// ISpatialAudioRenderStreamForHrtf. This object is used to notify clients that the number of dynamic spatial audio objects that can
		/// be activated concurrently is about to change.
		/// </summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ISpatialAudioObjectRenderStreamNotify NotifyObject;

		/// <summary>
		/// Optional default value for the decay model used for ISpatialAudioObjectForHrtf objects associated with the stream. <c>nullptr</c>
		/// if unused.
		/// </summary>
		public IntPtr /*SpatialAudioHrtfDistanceDecay*/ DistanceDecay;

		/// <summary>
		/// Optional default value for the spatial audio directivity model used for ISpatialAudioObjectForHrtf objects associated with the
		/// stream. <c>nullptr</c> if unused.
		/// </summary>
		public IntPtr /*SpatialAudioHrtfDirectivityUnion*/ Directivity;

		/// <summary>
		/// Optional default value for the type of environment that is simulated when audio is processed for ISpatialAudioObjectForHrtf
		/// objects associated with the stream. <c>nullptr</c> if unused.
		/// </summary>
		public IntPtr /*SpatialAudioHrtfEnvironmentType*/ Environment;

		/// <summary>
		/// Optional default value for the orientation of ISpatialAudioObjectForHrtf objects associated with the stream. <c>nullptr</c> if unused.
		/// </summary>
		public IntPtr /*SpatialAudioHrtfOrientation*/ Orientation;
	}

	/// <summary>
	/// Represents activation parameters for a spatial audio render stream, extending SpatialAudioHrtfActivationParams (spatialaudiohrtf.h)
	/// with the ability to specify stream options.
	/// </summary>
	/// <remarks>The following example demostrates activating a spatial audio render stream for HRTF with stream options.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/ns-spatialaudiohrtf-spatialaudiohrtfactivationparams2 typedef
	// struct SpatialAudioHrtfActivationParams2 { const WAVEFORMATEX *ObjectFormat; AudioObjectType StaticObjectTypeMask; UINT32
	// MinDynamicObjectCount; UINT32 MaxDynamicObjectCount; AUDIO_STREAM_CATEGORY Category; HANDLE EventHandle;
	// ISpatialAudioObjectRenderStreamNotify *NotifyObject; SpatialAudioHrtfDistanceDecay *DistanceDecay; SpatialAudioHrtfDirectivityUnion
	// *Directivity; SpatialAudioHrtfEnvironmentType *Environment; SpatialAudioHrtfOrientation *Orientation; SPATIAL_AUDIO_STREAM_OPTIONS
	// Options; } SpatialAudioHrtfActivationParams2;
	[PInvokeData("spatialaudiohrtf.h", MSDNShortId = "NS:spatialaudiohrtf.SpatialAudioHrtfActivationParams2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SpatialAudioHrtfActivationParams2
	{
		/// <summary>
		/// Format descriptor for spatial audio objects associated with the stream. All objects must have the same format and must be of type
		/// WAVEFORMATEX or WAVEFORMATEXTENSIBLE.
		/// </summary>
		public IntPtr /*WAVEFORMATEX*/ ObjectFormat;

		/// <summary>
		/// A bitwise combination of <c>AudioObjectType</c> values indicating the set of static spatial audio channels that will be allowed
		/// by the activated stream.
		/// </summary>
		public AudioObjectType StaticObjectTypeMask;

		/// <summary>
		/// The minimum number of concurrent dynamic objects. If this number of dynamic audio objects can't be activated simultaneously, no
		/// dynamic audio objects will be activated.
		/// </summary>
		public uint MinDynamicObjectCount;

		/// <summary>The maximum number of concurrent dynamic objects that can be activated with ISpatialAudioRenderStreamForHrtf.</summary>
		public uint MaxDynamicObjectCount;

		/// <summary>The category of the audio stream and its spatial audio objects.</summary>
		public AUDIO_STREAM_CATEGORY Category;

		/// <summary>
		/// The event that will signal the client to provide more audio data. This handle will be duplicated internally before it is used.
		/// </summary>
		public HEVENT EventHandle;

		/// <summary>
		/// The object that provides notifications for spatial audio clients to respond to changes in the state of an
		/// ISpatialAudioRenderStreamForHrtf. This object is used to notify clients that the number of dynamic spatial audio objects that can
		/// be activated concurrently is about to change.
		/// </summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ISpatialAudioObjectRenderStreamNotify NotifyObject;

		/// <summary>
		/// Optional default value for the decay model used for ISpatialAudioObjectForHrtf objects associated with the stream. <c>nullptr</c>
		/// if unused.
		/// </summary>
		public IntPtr /*SpatialAudioHrtfDistanceDecay*/ DistanceDecay;

		/// <summary>
		/// Optional default value for the spatial audio directivity model used for ISpatialAudioObjectForHrtf objects associated with the
		/// stream. <c>nullptr</c> if unused.
		/// </summary>
		public IntPtr /*SpatialAudioHrtfDirectivityUnion*/ Directivity;

		/// <summary>
		/// Optional default value for the type of environment that is simulated when audio is processed for ISpatialAudioObjectForHrtf
		/// objects associated with the stream. <c>nullptr</c> if unused.
		/// </summary>
		public IntPtr /*SpatialAudioHrtfEnvironmentType*/ Environment;

		/// <summary>
		/// Optional default value for the orientation of ISpatialAudioObjectForHrtf objects associated with the stream. <c>nullptr</c> if unused.
		/// </summary>
		public IntPtr /*SpatialAudioHrtfOrientation*/ Orientation;

		/// <summary>A member of the SPATIAL_AUDIO_STREAM_OPTIONS emumeration, specifying options for the activated audio stream.</summary>
		public SPATIAL_AUDIO_STREAM_OPTIONS Options;
	}

	/// <summary>
	/// Represents an omnidirectional model for an ISpatialAudioObjectForHrtf. The omnidirectional emission is interpolated linearly with the
	/// directivity model specified in the <c>Type</c> field based on the value of the <c>Scaling</c> field.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/ns-spatialaudiohrtf-spatialaudiohrtfdirectivity typedef struct
	// SpatialAudioHrtfDirectivity { SpatialAudioHrtfDirectivityType Type; float Scaling; } SpatialAudioHrtfDirectivity;
	[PInvokeData("spatialaudiohrtf.h", MSDNShortId = "A3D149E0-F2C1-47C7-8858-35C5F51C7F75")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SpatialAudioHrtfDirectivity
	{
		/// <summary>The type of shape in which sound is emitted by an ISpatialAudioObjectForHrtf.</summary>
		public SpatialAudioHrtfDirectivityType Type;

		/// <summary>
		/// The amount of linear interpolation applied between omnidirectional sound and the directivity specified in the <c>Type</c> field.
		/// This is a normalized value between 0 and 1.0 where 0 is omnidirectional and 1.0 is full directivity using the specified type.
		/// </summary>
		public float Scaling;
	}

	/// <summary>Represents a cardioid-shaped directivity model for an ISpatialAudioObjectForHrtf.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/ns-spatialaudiohrtf-spatialaudiohrtfdirectivitycardioid typedef
	// struct SpatialAudioHrtfDirectivityCardioid { SpatialAudioHrtfDirectivity directivity; float Order; } SpatialAudioHrtfDirectivityCardioid;
	[PInvokeData("spatialaudiohrtf.h", MSDNShortId = "71E2E152-14DC-472B-B582-82D4412EAA85")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SpatialAudioHrtfDirectivityCardioid
	{
		/// <summary>A structure that expresses the direction in which sound is emitted by an ISpatialAudioObjectForHrtf.</summary>
		public SpatialAudioHrtfDirectivity directivity;

		/// <summary>The order of the cardioid.</summary>
		public float Order;
	}

	/// <summary>Represents a cone-shaped directivity model for an ISpatialAudioObjectForHrtf.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/ns-spatialaudiohrtf-spatialaudiohrtfdirectivitycone typedef struct
	// SpatialAudioHrtfDirectivityCone { SpatialAudioHrtfDirectivity directivity; float InnerAngle; float OuterAngle; } SpatialAudioHrtfDirectivityCone;
	[PInvokeData("spatialaudiohrtf.h", MSDNShortId = "C34F26C2-4979-4C06-8EAC-64547745238F")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SpatialAudioHrtfDirectivityCone
	{
		/// <summary>A structure that expresses the direction in which sound is emitted by an ISpatialAudioObjectForHrtf.</summary>
		public SpatialAudioHrtfDirectivity directivity;

		/// <summary>The inner angle of the cone.</summary>
		public float InnerAngle;

		/// <summary>The outer angle of the cone.</summary>
		public float OuterAngle;
	}

	/// <summary>Defines a spatial audio directivity model for an ISpatialAudioObjectForHrtf.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/ns-spatialaudiohrtf-spatialaudiohrtfdirectivityunion typedef union
	// SpatialAudioHrtfDirectivityUnion { SpatialAudioHrtfDirectivityCone Cone; SpatialAudioHrtfDirectivityCardioid Cardiod;
	// SpatialAudioHrtfDirectivity Omni; } SpatialAudioHrtfDirectivityUnion;
	[PInvokeData("spatialaudiohrtf.h", MSDNShortId = "BBBE4B0B-59C2-44E0-9BB4-B10CE5CE12E3")]
	[StructLayout(LayoutKind.Explicit)]
	public struct SpatialAudioHrtfDirectivityUnion
	{
		/// <summary>A cone-shaped directivity model</summary>
		[FieldOffset(0)]
		public SpatialAudioHrtfDirectivityCone Cone;

		/// <summary/>
		[FieldOffset(0)]
		public SpatialAudioHrtfDirectivityCardioid Cardiod;

		/// <summary>An omni-direction directivity model that can be interpolated linearly with one of the other directivity models.</summary>
		[FieldOffset(0)]
		public SpatialAudioHrtfDirectivity Omni;
	}

	/// <summary>
	/// Represents the decay model that is applied over distance from the position of an ISpatialAudioObjectForHrtf to the position of the listener.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudiohrtf/ns-spatialaudiohrtf-spatialaudiohrtfdistancedecay typedef struct
	// SpatialAudioHrtfDistanceDecay { SpatialAudioHrtfDistanceDecayType Type; float MaxGain; float MinGain; float UnityGainDistance; float
	// CutoffDistance; } SpatialAudioHrtfDistanceDecay;
	[PInvokeData("spatialaudiohrtf.h", MSDNShortId = "2EBAE322-2A5F-4610-B64F-F1B8CE2DFD2D")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SpatialAudioHrtfDistanceDecay
	{
		/// <summary>The type of decay, natural or custom. The default value for this field is <c>SpatialAudioHrtfDistanceDecay_NaturalDecay</c>.</summary>
		public SpatialAudioHrtfDistanceDecayType Type;

		/// <summary/>
		public float MaxGain;

		/// <summary/>
		public float MinGain;

		/// <summary/>
		public float UnityGainDistance;

		/// <summary/>
		public float CutoffDistance;
	}

	/// <summary>Represents the orientation of an <c>ISpatialAudioObjectForHrtf</c>.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/coreaudio/spatialaudiohrtforientation
	[PInvokeData("spatialaudiohrtf.h", MSDNShortId = "BDC1C409-F461-4903-A411-3F0647C59DBA")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SpatialAudioHrtfOrientation
	{
		/// <summary>A row-major 3x3 rotation matrix.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
		public float[] Orientation;
	}
}