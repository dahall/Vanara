using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Winmm;

namespace Vanara.PInvoke
{
	/// <summary>Functions, structures and constants from Windows Core Audio Api.</summary>
	public static partial class CoreAudio
	{
		/// <summary>
		/// Specifies the type of an ISpatialAudioObject. A spatial audio object can be dynamic, meaning that it's spatial properties can
		/// change over time, or static, which means that its spatial properties are fixed. There are 17 audio channels to which a static
		/// spatial audio object can be assigned, each representing a real or virtualized speaker. The static channel values of the
		/// enumeration can be combined as a mask to assign a spatial audio object to multiple channels. All of the enumeration values
		/// except for <c>AudioObjectType_None</c> and <c>AudioObjectType_Dynamic</c> represent static channels.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/ne-spatialaudioclient-audioobjecttype typedef enum
		// AudioObjectType { AudioObjectType_None, AudioObjectType_Dynamic, AudioObjectType_FrontLeft, AudioObjectType_FrontRight,
		// AudioObjectType_FrontCenter, AudioObjectType_LowFrequency, AudioObjectType_SideLeft, AudioObjectType_SideRight,
		// AudioObjectType_BackLeft, AudioObjectType_BackRight, AudioObjectType_TopFrontLeft, AudioObjectType_TopFrontRight,
		// AudioObjectType_TopBackLeft, AudioObjectType_TopBackRight, AudioObjectType_BottomFrontLeft, AudioObjectType_BottomFrontRight,
		// AudioObjectType_BottomBackLeft, AudioObjectType_BottomBackRight, AudioObjectType_BackCenter } ;
		[PInvokeData("spatialaudioclient.h", MSDNShortId = "DFFE770F-41C0-4048-A38F-FB96353E9216")]
		public enum AudioObjectType
		{
			/// <summary>The spatial audio object is not spatialized.</summary>
			AudioObjectType_None = 0,

			/// <summary>The spatial audio object is dynamic. It's spatial properties can be changed over time.</summary>
			AudioObjectType_Dynamic = (1 << 0),

			/// <summary>
			/// The spatial audio object is assigned the front left channel. The equivalent channel mask of DirectShow's
			/// WAVEFORMATEXTENSIBLE enumeration is SPEAKER_FRONT_LEFT.
			/// </summary>
			AudioObjectType_FrontLeft = (1 << 1),

			/// <summary>
			/// The spatial audio object is assigned the front right channel. The equivalent channel mask of DirectShow's
			/// WAVEFORMATEXTENSIBLE enumeration is SPEAKER_FRONT_RIGHT.
			/// </summary>
			AudioObjectType_FrontRight = (1 << 2),

			/// <summary>
			/// The spatial audio object is assigned the front center channel. The equivalent channel mask of DirectShow's
			/// WAVEFORMATEXTENSIBLE enumeration is SPEAKER_FRONT_CENTER.
			/// </summary>
			AudioObjectType_FrontCenter = (1 << 3),

			/// <summary>
			/// The spatial audio object is assigned the low frequency channel. Because this channel is not spatialized, it does not count
			/// toward the system resource limits for spatialized audio objects. The equivalent channel mask of DirectShow's
			/// WAVEFORMATEXTENSIBLE enumeration is SPEAKER_LOW_FREQUENCY.
			/// </summary>
			AudioObjectType_LowFrequency = (1 << 4),

			/// <summary>
			/// The spatial audio object is assigned the side left channel. The equivalent channel mask of DirectShow's WAVEFORMATEXTENSIBLE
			/// enumeration is SPEAKER_SIDE_LEFT.
			/// </summary>
			AudioObjectType_SideLeft = (1 << 5),

			/// <summary>
			/// The spatial audio object is assigned the side right channel. The equivalent channel mask of DirectShow's
			/// WAVEFORMATEXTENSIBLE enumeration is SPEAKER_SIDE_RIGHT.
			/// </summary>
			AudioObjectType_SideRight = (1 << 6),

			/// <summary>
			/// The spatial audio object is assigned the back left channel. The equivalent channel mask of DirectShow's WAVEFORMATEXTENSIBLE
			/// enumeration is SPEAKER_BACK_LEFT.
			/// </summary>
			AudioObjectType_BackLeft = (1 << 7),

			/// <summary>
			/// The spatial audio object is assigned the back right channel. The equivalent channel mask of DirectShow's
			/// WAVEFORMATEXTENSIBLE enumeration is SPEAKER_BACK_RIGHT.
			/// </summary>
			AudioObjectType_BackRight = (1 << 8),

			/// <summary>
			/// The spatial audio object is assigned the top front left channel. The equivalent channel mask of DirectShow's
			/// WAVEFORMATEXTENSIBLE enumeration is SPEAKER_TOP_FRONT_LEFT.
			/// </summary>
			AudioObjectType_TopFrontLeft = (1 << 9),

			/// <summary>
			/// The spatial audio object is assigned the top front right channel. The equivalent channel mask of DirectShow's
			/// WAVEFORMATEXTENSIBLE enumeration is SPEAKER_TOP_FRONT_RIGHT.
			/// </summary>
			AudioObjectType_TopFrontRight = (1 << 10),

			/// <summary>
			/// The spatial audio object is assigned the top back left channel. The equivalent channel mask of DirectShow's
			/// WAVEFORMATEXTENSIBLE enumeration is SPEAKER_TOP_BACK_LEFT.
			/// </summary>
			AudioObjectType_TopBackLeft = (1 << 11),

			/// <summary>
			/// The spatial audio object is assigned the top back right channel. The equivalent channel mask of DirectShow's
			/// WAVEFORMATEXTENSIBLE enumeration is SPEAKER_TOP_BACK_RIGHT.
			/// </summary>
			AudioObjectType_TopBackRight = (1 << 12),

			/// <summary>The spatial audio object is assigned the bottom front left channel.</summary>
			AudioObjectType_BottomFrontLeft = (1 << 13),

			/// <summary>The spatial audio object is assigned the bottom front right channel.</summary>
			AudioObjectType_BottomFrontRight = (1 << 14),

			/// <summary>The spatial audio object is assigned the bottom back left channel.</summary>
			AudioObjectType_BottomBackLeft = (1 << 15),

			/// <summary>The spatial audio object is assigned the bottom back right channel.</summary>
			AudioObjectType_BottomBackRight = (1 << 16),

			/// <summary>The spatial audio object is assigned the back center channel.</summary>
			AudioObjectType_BackCenter = (1 << 17)
		}

		/// <summary>
		/// Provides a list of supported audio formats. The most preferred format is first in the list. Get a reference to this interface by
		/// calling ISpatialAudioClient::GetSupportedAudioObjectFormatEnumerator.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nn-spatialaudioclient-iaudioformatenumerator
		[ComImport, Guid("DCDAA858-895A-4A22-A5EB-67BDA506096D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IAudioFormatEnumerator
		{
			/// <summary>Gets the number of supported audio formats in the list</summary>
			/// <returns>The number of supported audio formats in the list.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-iaudioformatenumerator-getcount
			// HRESULT GetCount( UINT32 *count );
			uint GetCount();

			/// <summary>
			/// Gets the format with the specified index in the list. The formats are listed in order of importance. The most preferable
			/// format is first in the list.
			/// </summary>
			/// <param name="index">The index of the item in the list to retrieve.</param>
			/// <param name="format">Pointer to a pointer to a <c>WAVEFORMATEX</c> structure describing a supported audio format.</param>
			/// <returns>If the method succeeds, it returns S_OK.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-iaudioformatenumerator-getformat
			// HRESULT GetFormat( UINT32 index, WAVEFORMATEX **format );
			void GetFormat([In] uint index, out IntPtr format);
		}

		/// <summary>
		/// The <c>ISpatialAudioClient</c> interface enables a client to create audio streams that emit audio from a position in 3D space.
		/// This interface is a part of Windows Sonic, Microsoft’s audio platform for more immersive audio which includes integrated spatial
		/// sound on Xbox and Windows.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Get an instance of this interface by calling ActivateAudioInterfaceAsync, using the __uuidof operator to get the class ID of the
		/// <c>ISpatialAudioClient</c> interface. The following example code shows how to initialize this interface.
		/// </para>
		/// <para>
		/// <c>Note</c> When using the <c>ISpatialAudioClient</c> interfaces on an Xbox One Development Kit (XDK) title, you must first call
		/// <c>EnableSpatialAudio</c> before calling IMMDeviceEnumerator::EnumAudioEndpoints or
		/// IMMDeviceEnumerator::GetDefaultAudioEndpoint. Failure to do so will result in an E_NOINTERFACE error being returned from the
		/// call to Activate. <c>EnableSpatialAudio</c> is only available for XDK titles, and does not need to be called for Universal
		/// Windows Platform apps running on Xbox One, nor for any non-Xbox One devices.
		/// </para>
		/// <para>To access the <c>ActivateAudioIntefaceAsync</c>, you will need to link to mmdevapi.lib.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nn-spatialaudioclient-ispatialaudioclient
		[PInvokeData("spatialaudioclient.h", MSDNShortId = "950778D4-79FE-4222-951F-5A456A633124")]
		[ComImport, Guid("BBF8E066-AAAA-49BE-9A4D-FD2A858EA27F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISpatialAudioClient
		{
			/// <summary>Gets the position in 3D space of the specified static spatial audio channel.</summary>
			/// <param name="type">
			/// A value indicating the static spatial audio channel for which the position is being queried. This method will return
			/// E_INVALIDARG if the value does not represent a static channel, including <c>AudioObjectType_Dynamic</c> and <c>AudioObjectType_None</c>.
			/// </param>
			/// <param name="x">
			/// The x coordinate of the static audio channel, in meters, relative to the listener. Positive values are to the right of the
			/// listener and negative values are to the left.
			/// </param>
			/// <param name="y">
			/// The y coordinate of the static audio channel, in meters, relative to the listener. Positive values are above the listener
			/// and negative values are below.
			/// </param>
			/// <param name="z">
			/// The z coordinate of the static audio channel, in meters, relative to the listener. Positive values are behind the listener
			/// and negative values are in front.
			/// </param>
			/// <remarks>
			/// Position values use a right-handed Cartesian coordinate system, where each unit represents 1 meter. The coordinate system is
			/// relative to the listener where the origin (x=0.0, y=0.0, z=0.0) represents the center point between the listener's ears.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioclient-getstaticobjectposition
			// HRESULT GetStaticObjectPosition( AudioObjectType type, float *x, float *y, float *z );
			void GetStaticObjectPosition([In] AudioObjectType type, out float x, out float y, out float z);

			/// <summary>Gets a channel mask which represents the subset of static speaker bed channels native to current rendering engine.</summary>
			/// <returns>
			/// A bitwise combination of values from the AudioObjectType enumeration indicating a subset of static speaker channels. The
			/// values returned will only include the static channel values and will not include <c>AudioObjectType_Dynamic</c>.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioclient-getnativestaticobjecttypemask
			// HRESULT GetNativeStaticObjectTypeMask( AudioObjectType *mask );
			AudioObjectType GetNativeStaticObjectTypeMask();

			/// <summary>Gets the maximum number of dynamic audio objects for the spatial audio client.</summary>
			/// <returns>Gets the maximum dynamic object count for this client.</returns>
			/// <remarks>
			/// <para>
			/// A dynamic ISpatialAudioObject is one that was activated by setting the type parameter to the
			/// ISpatialAudioObjectRenderStream::ActivateSpatialAudioObject method to <c>AudioObjectType_Dynamic</c>. The client has a limit
			/// of the maximum number of dynamic spatial audio objects that can be activated at one time. When the capacity of the audio
			/// rendering pipeline changes, the system will dynamically adjust the maximum number of concurrent dynamic spatial audio
			/// objects. Before doing so, the system will call OnAvailableDynamicObjectCountChange to notify clients of the resource limit change.
			/// </para>
			/// <para>
			/// Call Release on an <c>ISpatialAudioObject</c> when it is no longer being used to free up the resource to create new dynamic
			/// spatial audio objects.
			/// </para>
			/// <para>
			/// When Windows Sonic is not available (for instance, when playing to embedded laptop stereo speakers, or if the user has not
			/// explicitly enabled Windows Sonic on the device), the number of available dynamic objects returned by
			/// <c>GetMaxDynamicObjectCount</c> to an application will be 0.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioclient-getmaxdynamicobjectcount
			// HRESULT GetMaxDynamicObjectCount( UINT32 *value );
			uint GetMaxDynamicObjectCount();

			/// <summary>
			/// Gets an IAudioFormatEnumerator that contains all supported audio formats for spatial audio objects, the first item in the
			/// list represents the most preferable format.
			/// </summary>
			/// <returns>Pointer to the pointer that receives the IAudioFormatEnumerator interface.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioclient-getsupportedaudioobjectformatenumerator
			// HRESULT GetSupportedAudioObjectFormatEnumerator( IAudioFormatEnumerator **enumerator );
			IAudioFormatEnumerator GetSupportedAudioObjectFormatEnumerator();

			/// <summary>
			/// Gets the maximum possible frame count per processing pass. This method can be used to determine the size of the source
			/// buffer that should be allocated to convey audio data for each processing pass.
			/// </summary>
			/// <param name="objectFormat">
			/// The audio format used to calculate the maximum frame count. This should be the same format specified in the
			/// <c>ObjectFormat</c> field of the SpatialAudioObjectRenderStreamActivationParams passed to ActivateSpatialAudioStream.
			/// </param>
			/// <returns>The maximum number of audio frames that will be processed in one pass.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioclient-getmaxframecount
			// HRESULT GetMaxFrameCount( const WAVEFORMATEX *objectFormat, UINT32 *frameCountPerBuffer );
			uint GetMaxFrameCount(in WAVEFORMATEX objectFormat);

			/// <summary>Gets a value indicating whether ISpatialAudioObjectRenderStream supports a the specified format.</summary>
			/// <param name="objectFormat">The format for which support is queried.</param>
			/// <returns>
			/// If the specified format is supported, it returns S_OK. If specified format is unsupported, this method returns AUDCLNT_E_UNSUPPORTED_FORMAT.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioclient-isaudioobjectformatsupported
			// HRESULT IsAudioObjectFormatSupported( const WAVEFORMATEX *objectFormat );
			[PreserveSig]
			HRESULT IsAudioObjectFormatSupported(in WAVEFORMATEX objectFormat);

			/// <summary>
			/// When successful, gets a value indicating whether the currently active spatial rendering engine supports the specified
			/// spatial audio render stream.
			/// </summary>
			/// <param name="streamUuid">The interface ID of the interface for which availability is queried.</param>
			/// <param name="auxiliaryInfo">
			/// A structure containing additional information to be used when support is queried. For more information, see Remarks.
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
			/// <term>SPTLAUDCLNT_E_STREAM_IS_NOT_AVAILABLE</term>
			/// <term>The specified stream interface can't be activated by the currently active rendering engine.</term>
			/// </item>
			/// <item>
			/// <term>SPTLAUDCLNT_E_METADATA_FORMAT_IS_NOT_SUPPORTED</term>
			/// <term>
			/// The metadata format supplied in the auxiliaryInfo parameter is not supported by the current rendering engine. For more
			/// information, see Remarks..
			/// </term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When querying to see if the ISpatialAudioObjectRenderStreamForMetadata you can use the auxilaryInfo parameter to query if a
			/// particular metadata format is supported. The following code example demonstrates how to initialize the PROPVARIANT structure
			/// to check for support for an example metadata format.
			/// </para>
			/// <para>If the specified metadata format is unsupported, <c>IsSpatialAudioStreamAvailable</c> returns SPTLAUDCLNT_E_METADATA_FORMAT_IS_NOT_SUPPORTED.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioclient-isspatialaudiostreamavailable
			// HRESULT IsSpatialAudioStreamAvailable( REFIID streamUuid, const PROPVARIANT *auxiliaryInfo );
			[PreserveSig]
			HRESULT IsSpatialAudioStreamAvailable(in Guid streamUuid, [In, Optional] PROPVARIANT auxiliaryInfo);

			/// <summary>Activates and initializes spatial audio stream using one of the spatial audio stream activation structures.</summary>
			/// <param name="activationParams">
			/// The structure defining the activation parameters for the spatial audio stream. The <c>vt</c> field should be set to VT_BLOB
			/// and the <c>blob</c> field should be populated with a SpatialAudioObjectRenderStreamActivationParams or a SpatialAudioObjectRenderStreamForMetadataActivationParams.
			/// </param>
			/// <param name="riid">The UUID of the spatial audio stream interface to activate.</param>
			/// <returns>A pointer which receives the activated spatial audio interface.</returns>
			/// <remarks>
			/// <para>This method supports activation of the following spatial audio stream interfaces:</para>
			/// <para>ISpatialAudioObjectRenderStream</para>
			/// <para>ISpatialAudioObjectRenderStreamForMetadata</para>
			/// <para>Examples</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioclient-activatespatialaudiostream
			// HRESULT ActivateSpatialAudioStream( const PROPVARIANT *activationParams, REFIID riid, void **stream );
			[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)]
			object ActivateSpatialAudioStream([In] PROPVARIANT activationParams, in Guid riid);
		}

		/// <summary>
		/// <para>
		/// Represents an object that provides audio data to be rendered from a position in 3D space, relative to the user. Spatial audio
		/// objects can be static or dynamic, which you specify with the type parameter to the
		/// ISpatialAudioObjectRenderStream::ActivateSpatialAudioObject method. Dynamic audio objects can be placed in an arbitrary position
		/// in space and can be moved over time. Static audio objects are assigned to one or more channels, defined in the AudioObjectType
		/// enumeration, that each correlate to a fixed speaker location that may be a physical or a virtualized speaker.
		/// </para>
		/// <para>
		/// This interface is a part of Windows Sonic, Microsoft’s audio platform for more immersive audio which includes integrated spatial
		/// sound on Xbox and Windows.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <c>Note</c> Many of the methods provided by this interface are implemented in the inherited ISpatialAudioObjectBase interface.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nn-spatialaudioclient-ispatialaudioobject
		[PInvokeData("spatialaudioclient.h", MSDNShortId = "EE83AF5F-4342-4CF2-81A7-1123F8DAFA6F")]
		[ComImport, Guid("DDE28967-521B-46E5-8F00-BD6F2BC8AB1D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISpatialAudioObject : ISpatialAudioObjectBase
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
			/// ISpatialAudioObjectRenderStream::ActivateSpatialAudioObject, lifetime of the spatial audio object starts. To keep the
			/// spatial audio object alive after that, this <c>GetBuffer</c> must be called on every processing pass (between calls to
			/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects and ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects). If
			/// <c>GetBuffer</c> is not called within an audio processing pass, SetEndOfStream is called implicitly on the audio object to
			/// deactivate, and the audio object can only be reused after calling Release on the object and then reactivating the object by
			/// calling <c>ActivateSpatialAudioObject</c> again.
			/// </para>
			/// <para>
			/// The pointers retrieved by <c>GetBuffer</c> should not be used after ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects
			/// has been called.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-getbuffer
			// HRESULT GetBuffer( BYTE **buffer, UINT32 *bufferLength );
			new void GetBuffer(out IntPtr buffer, out uint bufferLength);

			/// <summary>
			/// Instructs the system that the final block of audio data has been submitted for the ISpatialAudioObject so that the object
			/// can be deactivated and it's resources reused.
			/// </summary>
			/// <param name="frameCount">
			/// The number of audio frames in the audio buffer that should be included in the final processing pass. This number may be
			/// smaller than or equal to the value returned in the frameCountPerBuffer parameter to ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects.
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
			/// <c>IsActive</c> will be set to false after SetEndOfStream is called implicitly or explicitly. <c>SetEndOfStream</c> is
			/// called implicitly by the system if GetBuffer is not called within an audio processing pass (between calls to
			/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects and ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects).
			/// </para>
			/// <para>
			/// The rendering engine will also deactivate the audio object, setting <c>IsActive</c> to false, when audio object resources
			/// become unavailable. In this case, a notification is sent via ISpatialAudioObjectRenderStreamNotify before the object is
			/// deactivated. The value returned in the availableDynamicObjectCount parameter to
			/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects indicates how many objects will be processed for each pass.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-isactive
			// HRESULT IsActive( BOOL *isActive );
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool IsActive();

			/// <summary>
			/// Gets a value specifying the type of audio object that is represented by the ISpatialAudioObject. This value indicates if the
			/// object is dynamic or static. If the object is static, one and only one of the static audio channel values to which the
			/// object is assigned is returned.
			/// </summary>
			/// <returns>A value specifying the type of audio object that is represented</returns>
			/// <remarks>
			/// Set the type of the audio object with the type parameter to the ISpatialAudioObjectRenderStream::ActivateSpatialAudioObject method.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-getaudioobjecttype
			// HRESULT GetAudioObjectType( AudioObjectType *audioObjectType );
			new AudioObjectType GetAudioObjectType();

			/// <summary>
			/// Sets the position in 3D space, relative to the listener, from which the ISpatialAudioObject audio data will be rendered.
			/// </summary>
			/// <param name="x">
			/// The x position of the audio object, in meters, relative to the listener. Positive values are to the right of the listener
			/// and negative values are to the left.
			/// </param>
			/// <param name="y">
			/// The y position of the audio object, in meters, relative to the listener. Positive values are above the listener and negative
			/// values are below.
			/// </param>
			/// <param name="z">
			/// The z position of the audio object, in meters, relative to the listener. Positive values are behind the listener and
			/// negative values are in front.
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
			/// <term>SPTLAUDCLNT_E_OUT_OF_ORDER</term>
			/// <term>ISpatialAudioObjectRenderStreamBase::BeginUpdatingAudioObjects was not called before the call to SetPosition.</term>
			/// </item>
			/// <item>
			/// <term>SPTLAUDCLNT_E_RESOURCES_INVALIDATED</term>
			/// <term>
			/// SetEndOfStream was called either explicitly or implicitly in a previous audio processing pass. SetEndOfStream is called
			/// implicitly by the system if GetBuffer is not called within an audio processing pass (between calls to
			/// ISpatialAudioObjectRenderStreamBase::BeginUpdatingAudioObjects and ISpatialAudioObjectRenderStreamBase::EndUpdatingAudioObjects).
			/// </term>
			/// </item>
			/// <item>
			/// <term>SPTLAUDCLNT_E_PROPERTY_NOT_SUPPORTED</term>
			/// <term>
			/// The ISpatialAudioObject is not of type AudioObjectType_Dynamic. Set the type of the audio object with the type parameter to
			/// the ISpatialAudioObjectRenderStreamBase::ActivateSpatialAudioObject method.
			/// </term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method can only be called on a ISpatialAudioObject that is of type <c>AudioObjectType_Dynamic</c>. Set the type of the
			/// audio object with the type parameter to the ISpatialAudioObjectRenderStreamBase::ActivateSpatialAudioObject method.
			/// </para>
			/// <para>
			/// Position values use a right-handed Cartesian coordinate system, where each unit represents 1 meter. The coordinate system is
			/// relative to the listener where the origin (x=0.0, y=0.0, z=0.0) represents the center point between the listener's ears.
			/// </para>
			/// <para>
			/// If <c>SetPosition</c> is never called, the origin (x=0.0, y=0.0, z=0.0) is used as the default position. After
			/// <c>SetPosition</c> is called, the position that is set will be used for the audio object until the position is changed with
			/// another call to <c>SetPosition</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobject-setposition
			// HRESULT SetPosition( float x, float y, float z );
			void SetPosition([In] float x, [In] float y, [In] float z);

			/// <summary>
			/// Sets an audio amplitude multiplier that will be applied to the audio data provided by the ISpatialAudioObject before it is
			/// submitted to the audio rendering engine.
			/// </summary>
			/// <param name="volume">The amplitude multiplier for audio data. This must be a value between 0.0 and 1.0.</param>
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
			/// <term>SPTLAUDCLNT_E_OUT_OF_ORDER</term>
			/// <term>ISpatialAudioObjectRenderStreamBase::BeginUpdatingAudioObjects was not called before the call to SetVolume.</term>
			/// </item>
			/// <item>
			/// <term>SPTLAUDCLNT_E_RESOURCES_INVALIDATED</term>
			/// <term>
			/// SetEndOfStream was called either explicitly or implicitly in a previous audio processing pass. SetEndOfStream is called
			/// implicitly by the system if GetBuffer is not called within an audio processing pass (between calls to
			/// ISpatialAudioObjectRenderStreamBase::BeginUpdatingAudioObjects and ISpatialAudioObjectRenderStreamBase::EndUpdatingAudioObjects).
			/// </term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// If <c>SetVolume</c> is never called, the default value of 1.0 is used. After <c>SetVolume</c> is called, the volume that is
			/// set will be used for the audio object until the volume is changed with another call to <c>SetVolume</c>.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobject-setvolume
			// HRESULT SetVolume( float volume );
			void SetVolume([In] float volume);
		}

		/// <summary>
		/// <para>
		/// Base interface that represents an object that provides audio data to be rendered from a position in 3D space, relative to the
		/// user. Spatial audio objects can be static or dynamic, which you specify with the type parameter to the
		/// ISpatialAudioObjectRenderStream::ActivateSpatialAudioObject method. Dynamic audio objects can be placed in an arbitrary position
		/// in space and can be moved over time. Static audio objects are assigned to one or more channels, defined in the AudioObjectType
		/// enumeration, that each correlate to a fixed speaker location that may be a physical or a virtualized speaker.
		/// </para>
		/// <para>
		/// This interface is a part of Windows Sonic, Microsoft’s audio platform for more immersive audio which includes integrated spatial
		/// sound on Xbox and Windows.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nn-spatialaudioclient-ispatialaudioobjectbase
		[PInvokeData("spatialaudioclient.h", MSDNShortId = "54721875-D93A-4C7E-A07E-C286E1A409D3")]
		[ComImport, Guid("CCE0B8F2-8D4D-4EFB-A8CF-3D6ECF1C30E0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISpatialAudioObjectBase
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
			/// ISpatialAudioObjectRenderStream::ActivateSpatialAudioObject, lifetime of the spatial audio object starts. To keep the
			/// spatial audio object alive after that, this <c>GetBuffer</c> must be called on every processing pass (between calls to
			/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects and ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects). If
			/// <c>GetBuffer</c> is not called within an audio processing pass, SetEndOfStream is called implicitly on the audio object to
			/// deactivate, and the audio object can only be reused after calling Release on the object and then reactivating the object by
			/// calling <c>ActivateSpatialAudioObject</c> again.
			/// </para>
			/// <para>
			/// The pointers retrieved by <c>GetBuffer</c> should not be used after ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects
			/// has been called.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-getbuffer
			// HRESULT GetBuffer( BYTE **buffer, UINT32 *bufferLength );
			void GetBuffer(out IntPtr buffer, out uint bufferLength);

			/// <summary>
			/// Instructs the system that the final block of audio data has been submitted for the ISpatialAudioObject so that the object
			/// can be deactivated and it's resources reused.
			/// </summary>
			/// <param name="frameCount">
			/// The number of audio frames in the audio buffer that should be included in the final processing pass. This number may be
			/// smaller than or equal to the value returned in the frameCountPerBuffer parameter to ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects.
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
			void SetEndOfStream([In] uint frameCount);

			/// <summary>Gets a boolean value indicating whether the ISpatialAudioObject is valid.</summary>
			/// <returns><c>TRUE</c> if the audio object is currently valid; otherwise, <c>FALSE</c>.</returns>
			/// <remarks>
			/// <para>If this value is false, you should call Release to make the audio object resource available in the future.</para>
			/// <para>
			/// <c>IsActive</c> will be set to false after SetEndOfStream is called implicitly or explicitly. <c>SetEndOfStream</c> is
			/// called implicitly by the system if GetBuffer is not called within an audio processing pass (between calls to
			/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects and ISpatialAudioObjectRenderStream::EndUpdatingAudioObjects).
			/// </para>
			/// <para>
			/// The rendering engine will also deactivate the audio object, setting <c>IsActive</c> to false, when audio object resources
			/// become unavailable. In this case, a notification is sent via ISpatialAudioObjectRenderStreamNotify before the object is
			/// deactivated. The value returned in the availableDynamicObjectCount parameter to
			/// ISpatialAudioObjectRenderStream::BeginUpdatingAudioObjects indicates how many objects will be processed for each pass.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-isactive
			// HRESULT IsActive( BOOL *isActive );
			[return: MarshalAs(UnmanagedType.Bool)]
			bool IsActive();

			/// <summary>
			/// Gets a value specifying the type of audio object that is represented by the ISpatialAudioObject. This value indicates if the
			/// object is dynamic or static. If the object is static, one and only one of the static audio channel values to which the
			/// object is assigned is returned.
			/// </summary>
			/// <returns>A value specifying the type of audio object that is represented</returns>
			/// <remarks>
			/// Set the type of the audio object with the type parameter to the ISpatialAudioObjectRenderStream::ActivateSpatialAudioObject method.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectbase-getaudioobjecttype
			// HRESULT GetAudioObjectType( AudioObjectType *audioObjectType );
			AudioObjectType GetAudioObjectType();
		}

		/// <summary>
		/// <para>
		/// Provides methods for controlling a spatial audio object render stream, including starting, stopping, and resetting the stream.
		/// Also provides methods for activating new ISpatialAudioObject instances and notifying the system when you are beginning and
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
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nn-spatialaudioclient-ispatialaudioobjectrenderstream
		[ComImport, Guid("BAB5F473-B423-477B-85F5-B5A332A04153"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISpatialAudioObjectRenderStream : ISpatialAudioObjectRenderStreamBase
		{
			/// <summary>Gets the number of dynamic spatial audio objects that are currently available.</summary>
			/// <returns>The number of dynamic spatial audio objects that are currently available.</returns>
			/// <remarks>
			/// <para>
			/// A dynamic ISpatialAudioObject is one that was activated by setting the type parameter to the ActivateSpatialAudioObject
			/// method to <c>AudioObjectType_Dynamic</c>. The system has a limit of the maximum number of dynamic spatial audio objects that
			/// can be activated at one time. Call Release on an <c>ISpatialAudioObject</c> when it is no longer being used to free up the
			/// resource to create new dynamic spatial audio objects.
			/// </para>
			/// <para>
			/// You should not call this method after streaming has started, as the value is already provided by
			/// ISpatialAudioObjectRenderStreamBase::BeginUpdatingAudioObjects. This method should only be called before streaming has
			/// started, which occurs after ISpatialAudioObjectRenderStreamBase::Start is called.
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
			/// Pointer to a pointer variable into which the method writes the address of an instance of the requested interface. Through
			/// this method, the caller obtains a counted reference to the interface. The caller is responsible for releasing the interface,
			/// when it is no longer needed, by calling the interface's Release method. If the <c>GetService</c> call fails, *ppv is NULL.
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
			/// Starting the stream causes data flow between the endpoint buffer and the audio engine. The first time this method is called,
			/// the stream's audio clock position will be at 0. Otherwise, the clock resumes from its position at the time that the stream
			/// was last paused with a call to Stop. Call Reset to reset the clock position to 0 and cause all active ISpatialAudioObject
			/// instances to be revoked.
			/// </para>
			/// <para>The stream must have been previously stopped with a call to Stop or the method will fail and return SPTLAUDCLNT_E_STREAM_NOT_STOPPED.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-start
			// HRESULT Start();
			new void Start();

			/// <summary>Stops a running audio stream.</summary>
			/// <remarks>
			/// Stopping stream causes data to stop flowing between the endpoint buffer and the audio engine. You can consider this
			/// operation to pause the stream because it leaves the stream's audio clock at its current stream position and does not reset
			/// it to 0. A subsequent call to Start causes the stream to resume running from the current position. Call Reset to reset the
			/// clock position to 0 and cause all active ISpatialAudioObject instances to be revoked.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-stop
			// HRESULT Stop();
			new void Stop();

			/// <summary>Reset a stopped audio stream.</summary>
			/// <remarks>
			/// <para>
			/// Resetting the audio stream flushes all pending data and resets the audio clock stream position to 0. Resetting the stream
			/// also causes all active ISpatialAudioObject instances to be revoked. A subsequent call to Start causes the stream to start
			/// from 0 position.
			/// </para>
			/// <para>The stream must have been previously stopped with a call to Stop or the method will fail and return SPTLAUDCLNT_E_STREAM_NOT_STOPPED.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-reset
			// HRESULT Reset();
			new void Reset();

			/// <summary>
			/// Puts the system into the state where audio object data can be submitted for processing and the ISpatialAudioObject state can
			/// be modified.
			/// </summary>
			/// <param name="availableDynamicObjectCount">
			/// The number of dynamic audio objects that are available to be rendered for the current processing pass. All allocated static
			/// audio objects can be rendered in every pass. For information on audio object types, see AudioObjectType.
			/// </param>
			/// <param name="frameCountPerBuffer">The size, in audio frames, of the buffer returned by GetBuffer.</param>
			/// <remarks>
			/// <para>
			/// This method must be called each time the event passed in the SpatialAudioObjectRenderStreamActivationParams to
			/// ISpatialAudioClient::ActivateSpatialAudioStream is signaled, even if there no audio object data to submit.
			/// </para>
			/// <para>
			/// For each <c>BeginUpdatingAudioObjects</c> call, there should be a corresponding call to EndUpdatingAudioObjects call. If
			/// <c>BeginUpdatingAudioObjects</c> is called twice without a call <c>EndUpdatingAudioObjects</c> between them, the second call
			/// to <c>BeginUpdatingAudioObjects</c> will return SPTLAUDCLNT_E_OUT_OF_ORDER.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-beginupdatingaudioobjects
			// HRESULT BeginUpdatingAudioObjects( UINT32 *availableDynamicObjectCount, UINT32 *frameCountPerBuffer );
			new void BeginUpdatingAudioObjects(out uint availableDynamicObjectCount, out uint frameCountPerBuffer);

			/// <summary>
			/// Notifies the system that the app has finished supplying audio data for the spatial audio objects activated with ActivateSpatialAudioObject.
			/// </summary>
			/// <remarks>The pointers retrieved with ISpatialAudioObjectBase::GetBuffer can no longer be used after this method is called.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-endupdatingaudioobjects
			// HRESULT EndUpdatingAudioObjects();
			new void EndUpdatingAudioObjects();

			/// <summary>Activates an ISpatialAudioObject for audio rendering.</summary>
			/// <param name="type">
			/// The type of audio object to activate. For dynamic audio objects, this value must be <c>AudioObjectType_Dynamic</c>. For
			/// static audio objects, specify one of the static audio channel values from the enumeration. Specifying
			/// <c>AudioObjectType_None</c> will produce an audio object that is not spatialized.
			/// </param>
			/// <returns>Receives a pointer to the activated interface.</returns>
			/// <remarks>
			/// A dynamic ISpatialAudioObject is one that was activated by setting the type parameter to the
			/// <c>ActivateSpatialAudioObject</c> method to <c>AudioObjectType_Dynamic</c>. The client has a limit of the maximum number of
			/// dynamic spatial audio objects that can be activated at one time. After the limit has been reached, attempting to activate
			/// additional audio objects will result in this method returning an SPTLAUDCLNT_E_NO_MORE_OBJECTS error. To avoid this, call
			/// Release on each dynamic <c>ISpatialAudioObject</c> after it is no longer being used to free up the resource so that it can
			/// be reallocated. See ISpatialAudioObject::IsActive and ISpatialAudioObject::SetEndOfStream for more information on the
			/// managing the lifetime of spatial audio objects.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstream-activatespatialaudioobject
			// HRESULT ActivateSpatialAudioObject( AudioObjectType type, ISpatialAudioObject **audioObject );
			ISpatialAudioObject ActivateSpatialAudioObject([In] AudioObjectType type);
		}

		/// <summary>
		/// <para>
		/// Base interface that provides methods for controlling a spatial audio object render stream, including starting, stopping, and
		/// resetting the stream. Also provides methods for activating new ISpatialAudioObject instances and notifying the system when you
		/// are beginning and ending the process of updating activated spatial audio objects and data.
		/// </para>
		/// <para>
		/// This interface is a part of Windows Sonic, Microsoft’s audio platform for more immersive audio which includes integrated spatial
		/// sound on Xbox and Windows.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nn-spatialaudioclient-ispatialaudioobjectrenderstreambase
		[ComImport, Guid("FEAAF403-C1D8-450D-AA05-E0CCEE7502A8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISpatialAudioObjectRenderStreamBase
		{
			/// <summary>Gets the number of dynamic spatial audio objects that are currently available.</summary>
			/// <returns>The number of dynamic spatial audio objects that are currently available.</returns>
			/// <remarks>
			/// <para>
			/// A dynamic ISpatialAudioObject is one that was activated by setting the type parameter to the ActivateSpatialAudioObject
			/// method to <c>AudioObjectType_Dynamic</c>. The system has a limit of the maximum number of dynamic spatial audio objects that
			/// can be activated at one time. Call Release on an <c>ISpatialAudioObject</c> when it is no longer being used to free up the
			/// resource to create new dynamic spatial audio objects.
			/// </para>
			/// <para>
			/// You should not call this method after streaming has started, as the value is already provided by
			/// ISpatialAudioObjectRenderStreamBase::BeginUpdatingAudioObjects. This method should only be called before streaming has
			/// started, which occurs after ISpatialAudioObjectRenderStreamBase::Start is called.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-getavailabledynamicobjectcount
			// HRESULT GetAvailableDynamicObjectCount( UINT32 *value );
			uint GetAvailableDynamicObjectCount();

			/// <summary>Gets additional services from the <c>ISpatialAudioObjectRenderStream</c>.</summary>
			/// <param name="riid">
			/// <para>The interface ID for the requested service. The client should set this parameter to one of the following REFIID values:</para>
			/// <para>IID_IAudioClock</para>
			/// <para>IID_IAudioClock2</para>
			/// <para>IID_IAudioStreamVolume</para>
			/// </param>
			/// <param name="service">
			/// Pointer to a pointer variable into which the method writes the address of an instance of the requested interface. Through
			/// this method, the caller obtains a counted reference to the interface. The caller is responsible for releasing the interface,
			/// when it is no longer needed, by calling the interface's Release method. If the <c>GetService</c> call fails, *ppv is NULL.
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
			HRESULT GetService(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object service);

			/// <summary>Starts the spatial audio stream.</summary>
			/// <remarks>
			/// <para>
			/// Starting the stream causes data flow between the endpoint buffer and the audio engine. The first time this method is called,
			/// the stream's audio clock position will be at 0. Otherwise, the clock resumes from its position at the time that the stream
			/// was last paused with a call to Stop. Call Reset to reset the clock position to 0 and cause all active ISpatialAudioObject
			/// instances to be revoked.
			/// </para>
			/// <para>The stream must have been previously stopped with a call to Stop or the method will fail and return SPTLAUDCLNT_E_STREAM_NOT_STOPPED.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-start
			// HRESULT Start();
			void Start();

			/// <summary>Stops a running audio stream.</summary>
			/// <remarks>
			/// Stopping stream causes data to stop flowing between the endpoint buffer and the audio engine. You can consider this
			/// operation to pause the stream because it leaves the stream's audio clock at its current stream position and does not reset
			/// it to 0. A subsequent call to Start causes the stream to resume running from the current position. Call Reset to reset the
			/// clock position to 0 and cause all active ISpatialAudioObject instances to be revoked.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-stop
			// HRESULT Stop();
			void Stop();

			/// <summary>Reset a stopped audio stream.</summary>
			/// <remarks>
			/// <para>
			/// Resetting the audio stream flushes all pending data and resets the audio clock stream position to 0. Resetting the stream
			/// also causes all active ISpatialAudioObject instances to be revoked. A subsequent call to Start causes the stream to start
			/// from 0 position.
			/// </para>
			/// <para>The stream must have been previously stopped with a call to Stop or the method will fail and return SPTLAUDCLNT_E_STREAM_NOT_STOPPED.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-reset
			// HRESULT Reset();
			void Reset();

			/// <summary>
			/// Puts the system into the state where audio object data can be submitted for processing and the ISpatialAudioObject state can
			/// be modified.
			/// </summary>
			/// <param name="availableDynamicObjectCount">
			/// The number of dynamic audio objects that are available to be rendered for the current processing pass. All allocated static
			/// audio objects can be rendered in every pass. For information on audio object types, see AudioObjectType.
			/// </param>
			/// <param name="frameCountPerBuffer">The size, in audio frames, of the buffer returned by GetBuffer.</param>
			/// <remarks>
			/// <para>
			/// This method must be called each time the event passed in the SpatialAudioObjectRenderStreamActivationParams to
			/// ISpatialAudioClient::ActivateSpatialAudioStream is signaled, even if there no audio object data to submit.
			/// </para>
			/// <para>
			/// For each <c>BeginUpdatingAudioObjects</c> call, there should be a corresponding call to EndUpdatingAudioObjects call. If
			/// <c>BeginUpdatingAudioObjects</c> is called twice without a call <c>EndUpdatingAudioObjects</c> between them, the second call
			/// to <c>BeginUpdatingAudioObjects</c> will return SPTLAUDCLNT_E_OUT_OF_ORDER.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-beginupdatingaudioobjects
			// HRESULT BeginUpdatingAudioObjects( UINT32 *availableDynamicObjectCount, UINT32 *frameCountPerBuffer );
			void BeginUpdatingAudioObjects(out uint availableDynamicObjectCount, out uint frameCountPerBuffer);

			/// <summary>
			/// Notifies the system that the app has finished supplying audio data for the spatial audio objects activated with ActivateSpatialAudioObject.
			/// </summary>
			/// <remarks>The pointers retrieved with ISpatialAudioObjectBase::GetBuffer can no longer be used after this method is called.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreambase-endupdatingaudioobjects
			// HRESULT EndUpdatingAudioObjects();
			void EndUpdatingAudioObjects();
		}

		/// <summary>
		/// <para>Provides notifications for spatial audio clients to respond to changes in the state of an ISpatialAudioObjectRenderStream.</para>
		/// <para>
		/// You register the object that implements this interface by assigning it to the NotifyObject parameter of the
		/// SpatialAudioClientActivationParams structure passed into the ISpatialAudioClient::ActivateSpatialAudioStream method. After
		/// registering its <c>ISpatialAudioObjectRenderStreamNotify</c> interface, the client receives event notifications in the form of
		/// callbacks through the OnAvailableDynamicObjectCountChange method in the interface.
		/// </para>
		/// <para>
		/// This interface is a part of Windows Sonic, Microsoft’s audio platform for more immersive audio which includes integrated spatial
		/// sound on Xbox and Windows.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nn-spatialaudioclient-ispatialaudioobjectrenderstreamnotify
		[PInvokeData("spatialaudioclient.h", MSDNShortId = "3729D985-9040-43AD-A8B0-045509FE2F20")]
		[ComImport, Guid("DDDF83E6-68D7-4C70-883F-A1836AFB4A50"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISpatialAudioObjectRenderStreamNotify
		{
			/// <summary>
			/// Notifies the spatial audio client when the rendering capacity for an ISpatialAudioObjectRenderStream is about to change,
			/// specifies the time after which the change will occur, and specifies the number of dynamic audio objects that will be
			/// available after the change.
			/// </summary>
			/// <param name="sender">The spatial audio render stream for which the available dynamic object count is changing.</param>
			/// <param name="hnsComplianceDeadlineTime">
			/// The time after which the spatial resource limit will change, in 100-nanosecond units. A value of 0 means that the change
			/// will occur immediately.
			/// </param>
			/// <param name="availableDynamicObjectCountChange">
			/// The number of dynamic spatial audio objects that will be available to the stream after hnsComplianceDeadlineTime.
			/// </param>
			/// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
			/// <remarks>
			/// <para>
			/// A dynamic ISpatialAudioObject is one that was activated by setting the type parameter to the
			/// ISpatialAudioObjectRenderStream::ActivateSpatialAudioObject method to <c>AudioObjectType_Dynamic</c>. The client has a limit
			/// of the maximum number of dynamic spatial audio objects that can be activated at one time. When the capacity of the audio
			/// rendering pipeline changes, the system will dynamically adjust the maximum number of concurrent dynamic spatial audio
			/// objects. Before doing so, the system will call <c>OnAvailableDynamicObjectCountChange</c> to notify clients of the resource
			/// limit change.
			/// </para>
			/// <para>
			/// Call Release on an <c>ISpatialAudioObject</c> when it is no longer being used to free up the resource to create new dynamic
			/// spatial audio objects.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/nf-spatialaudioclient-ispatialaudioobjectrenderstreamnotify-onavailabledynamicobjectcountchange
			// HRESULT OnAvailableDynamicObjectCountChange( ISpatialAudioObjectRenderStreamBase *sender, LONGLONG hnsComplianceDeadlineTime,
			// UINT32 availableDynamicObjectCountChange );
			[PreserveSig]
			HRESULT OnAvailableDynamicObjectCountChange([In] ISpatialAudioObjectRenderStreamBase sender, int hnsComplianceDeadlineTime, [In] uint availableDynamicObjectCountChange);
		}

		/// <summary>
		/// Represents optional activation parameters for a spatial audio render stream. Pass this structure to ActivateAudioInterfaceAsync
		/// when activating an ISpatialAudioClient interface.
		/// </summary>
		/// <remarks>
		/// <para>The following example code shows how to initialize this structure.</para>
		/// <para>To access the <c>ActivateAudioIntefaceAsync</c>, you will need to link to mmdevapi.lib.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/ns-spatialaudioclient-spatialaudioclientactivationparams
		// typedef struct SpatialAudioClientActivationParams { GUID tracingContextId; GUID appId; int majorVersion; int minorVersion1; int
		// minorVersion2; int minorVersion3; } SpatialAudioClientActivationParams;
		[PInvokeData("spatialaudioclient.h", MSDNShortId = "6FEC7A70-D12E-4DB9-91DC-A54D5CCF8B57")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SpatialAudioClientActivationParams
		{
			/// <summary>An app-defined context identifier, used for event logging.</summary>
			public Guid tracingContextId;

			/// <summary>
			/// <para>An identifier for the client app, used for event logging.</para>
			/// <para>majorVersion</para>
			/// <para>The major version number of the client app, used for event logging.</para>
			/// <para>minorVersion1</para>
			/// <para>The first minor version number of the client app, used for event logging.</para>
			/// <para>minorVersion2</para>
			/// <para>The second minor version number of the client app, used for event logging.</para>
			/// <para>####### minorVersion3</para>
			/// <para>The third minor version number of the client app, used for event logging.</para>
			/// </summary>
			public Guid appId;

			/// <summary/>
			public int majorVersion;

			/// <summary/>
			public int minorVersion1;

			/// <summary/>
			public int minorVersion2;

			/// <summary/>
			public int minorVersion3;
		}

		/// <summary>
		/// Represents activation parameters for a spatial audio render stream. Pass this structure to
		/// ISpatialAudioClient::ActivateSpatialAudioStream when activating a stream.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/spatialaudioclient/ns-spatialaudioclient-spatialaudioobjectrenderstreamactivationparams
		// typedef struct SpatialAudioObjectRenderStreamActivationParams { const WAVEFORMATEX *ObjectFormat; AudioObjectType
		// StaticObjectTypeMask; UINT32 MinDynamicObjectCount; UINT32 MaxDynamicObjectCount; AUDIO_STREAM_CATEGORY Category; HANDLE
		// EventHandle; ISpatialAudioObjectRenderStreamNotify *NotifyObject; } SpatialAudioObjectRenderStreamActivationParams;
		[PInvokeData("spatialaudioclient.h", MSDNShortId = "DD27FDE1-3B4B-4C11-A980-15AF60A3A75B")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SpatialAudioObjectRenderStreamActivationParams
		{
			/// <summary>
			/// Format descriptor for a single spatial audio object. All objects used by the stream must have the same format and the format
			/// must be of type WAVEFORMATEX or WAVEFORMATEXTENSIBLE.
			/// </summary>
			public IntPtr ObjectFormat;

			/// <summary>
			/// A bitwise combination of <c>AudioObjectType</c> values indicating the set of static spatial audio channels that will be
			/// allowed by the activated stream.
			/// </summary>
			public AudioObjectType StaticObjectTypeMask;

			/// <summary>
			/// The minimum number of concurrent dynamic objects. If this number of dynamic audio objects can't be activated simultaneously,
			/// ISpatialAudioClient::ActivateSpatialAudioStream will fail with this error <c>SPTLAUDCLNT_E_NO_MORE_OBJECTS</c>.
			/// </summary>
			public uint MinDynamicObjectCount;

			/// <summary>The maximum number of concurrent dynamic objects that can be activated with ISpatialAudioObjectRenderStream.</summary>
			public uint MaxDynamicObjectCount;

			/// <summary>The category of the audio stream and its spatial audio objects.</summary>
			public AUDIO_STREAM_CATEGORY Category;

			/// <summary>
			/// The event that will signal the client to provide more audio data. This handle will be duplicated internally before it is used.
			/// </summary>
			public HANDLE EventHandle;

			/// <summary>
			/// The object that provides notifications for spatial audio clients to respond to changes in the state of an
			/// ISpatialAudioObjectRenderStream. This object is used to notify clients that the number of dynamic spatial audio objects that
			/// can be activated concurrently is about to change.
			/// </summary>
			public ISpatialAudioObjectRenderStreamNotify NotifyObject;
		}
	}
}