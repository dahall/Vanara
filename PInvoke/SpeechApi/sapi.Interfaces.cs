using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using Vanara.Collections;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.UrlMon;
using static Vanara.PInvoke.WinMm;
using STATSTG = System.Runtime.InteropServices.ComTypes.STATSTG;

namespace Vanara.PInvoke;

public static partial class SpeechApi
{
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIDispatch), Guid("7B8FCB42-0E9D-4F00-A048-7B04D6179D3D")]
	public interface _ISpeechRecoContextEvents
	{
		[DispId(1)]
		void StartStream([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition);

		[DispId(2)]
		void EndStream([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In] bool StreamReleased);

		[DispId(3)]
		void Bookmark([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In, MarshalAs(UnmanagedType.Struct)] object BookmarkId, [In] SpeechBookmarkOptions Options);

		[DispId(4)]
		void SoundStart([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition);

		[DispId(5)]
		void SoundEnd([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition);

		[DispId(6)]
		void PhraseStart([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition);

		[DispId(7)]
		void Recognition([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In] SpeechRecognitionType RecognitionType, [In, MarshalAs(UnmanagedType.Interface)] ISpeechRecoResult Result);

		[DispId(8)]
		void Hypothesis([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In, MarshalAs(UnmanagedType.Interface)] ISpeechRecoResult Result);

		[DispId(9)]
		void PropertyNumberChange([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In, MarshalAs(UnmanagedType.BStr)] string PropertyName, [In] int NewNumberValue);

		[DispId(10)]
		void PropertyStringChange([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In, MarshalAs(UnmanagedType.BStr)] string PropertyName, [In, MarshalAs(UnmanagedType.BStr)] string NewStringValue);

		[DispId(11)]
		void FalseRecognition([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In, MarshalAs(UnmanagedType.Interface)] ISpeechRecoResult Result);

		[DispId(12)]
		void Interference([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In] SpeechInterference Interference);

		[DispId(13)]
		void RequestUI([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In, MarshalAs(UnmanagedType.BStr)] string UIType);

		[DispId(14)]
		void RecognizerStateChange([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In] SpeechRecognizerState NewState);

		[DispId(15)]
		void Adaptation([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition);

		[DispId(16)]
		void RecognitionForOtherContext([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition);

		[DispId(17)]
		void AudioLevel([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In] int AudioLevel);

		[DispId(18)]
		void EnginePrivate([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In, MarshalAs(UnmanagedType.Struct)] object EngineData);
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIDispatch), Guid("A372ACD1-3BEF-4BBD-8FFB-CB3E2B416AF8"), CoClass(typeof(SpVoice))]
	public interface _ISpeechVoiceEvents
	{
		[DispId(1)]
		void StartStream([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition);

		[DispId(2)]
		void EndStream([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition);

		[DispId(3)]
		void VoiceChange([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In, MarshalAs(UnmanagedType.Interface)] SpObjectToken VoiceObjectToken);

		[DispId(4)]
		void Bookmark([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In, MarshalAs(UnmanagedType.BStr)] string Bookmark, [In] int BookmarkId);

		[DispId(5)]
		void Word([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In] int CharacterPosition, [In] int Length);

		[DispId(7)]
		void Sentence([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In] int CharacterPosition, [In] int Length);

		[DispId(6)]
		void Phoneme([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In] int Duration, [In] short NextPhoneId, [In] SpeechVisemeFeature Feature, [In] short CurrentPhoneId);

		[DispId(8)]
		void Viseme([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In] int Duration, [In] SpeechVisemeType NextVisemeId, [In] SpeechVisemeFeature Feature, [In] SpeechVisemeType CurrentVisemeId);

		[DispId(9)]
		void AudioLevel([In] int StreamNumber, [In, MarshalAs(UnmanagedType.Struct)] object StreamPosition, [In] int AudioLevel);

		[DispId(10)]
		void EnginePrivate([In] int StreamNumber, [In] int StreamPosition, [In, MarshalAs(UnmanagedType.Struct)] object EngineData);
	}

	/// <summary>Enumerates speech object tokens, providing methods to retrieve, skip, reset, and clone the enumeration.</summary>
	/// <remarks>
	/// This interface is used to iterate over a collection of speech object tokens, such as audio input devices or speech recognition
	/// engines. It provides functionality to retrieve tokens individually or in batches, skip tokens, reset the enumeration, and create a
	/// duplicate enumerator.
	/// </remarks>
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("06B64F9E-7FDA-11D2-B4F2-00C04F797396"), CoClass(typeof(SpMMAudioEnum))]
	public interface IEnumSpObjectTokens : ICOMEnum<ISpObjectToken>
	{
		/// <summary>Retrieves the next set of elements in the enumeration sequence.</summary>
		/// <remarks>
		/// This method is typically used to iterate through a collection of <see cref="ISpObjectToken"/> instances. If the end of the
		/// enumeration is reached, fewer elements than requested may be returned, and subsequent calls may return no elements.
		/// </remarks>
		/// <param name="celt">The number of elements to retrieve. Must be greater than zero.</param>
		/// <param name="pelt">
		/// An array to receive the retrieved elements. The array must be preallocated with a size equal to or greater than <paramref
		/// name="celt"/>. Each element in the array will be populated with an <see cref="ISpObjectToken"/> instance.
		/// </param>
		/// <param name="pceltFetched">
		/// When the method returns, contains the actual number of elements retrieved. If fewer elements are available than requested, this
		/// value will be less than <paramref name="celt"/>.
		/// </param>
		/// <returns>
		/// A <see cref="HRESULT"/> value indicating the success or failure of the operation. Returns <see cref="HRESULT.S_OK"/> if the
		/// operation succeeds, or an appropriate error code if it fails.
		/// </returns>
		[PreserveSig]
		HRESULT Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ISpObjectToken[] pelt, out uint pceltFetched);

		/// <summary>Skips the specified number of elements in the enumeration sequence.</summary>
		/// <remarks>
		/// This method advances the current position in the enumeration by the specified number of elements. If the end of the sequence is
		/// reached before skipping the requested number of elements, the method stops at the end of the sequence.
		/// </remarks>
		/// <param name="celt">The number of elements to skip. Must be a positive integer.</param>
		/// <returns>
		/// An HRESULT value indicating the success or failure of the operation. A return value of <see cref="HRESULT.S_OK"/> indicates
		/// success, while other values indicate an error.
		/// </returns>
		[PreserveSig]
		HRESULT Skip([In] uint celt);

		/// <summary>Resets the state of the object to its initial configuration.</summary>
		/// <remarks>
		/// This method restores the object to its default state, clearing any modifications or changes made. Use this method to reinitialize
		/// the object without creating a new instance.
		/// </remarks>
		void Reset();

		/// <summary>Creates a new enumerator that is a copy of the current enumerator.</summary>
		/// <remarks>
		/// The cloned enumerator maintains the same state as the original enumerator at the time of cloning. Subsequent changes to the
		/// original enumerator do not affect the cloned instance.
		/// </remarks>
		/// <returns>A new <see cref="IEnumSpObjectTokens"/> instance that represents a duplicate of the current enumerator.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumSpObjectTokens Clone();

		/// <summary>Retrieves the object token at the specified index in the collection.</summary>
		/// <param name="Index">The zero-based index of the object token to retrieve.</param>
		/// <returns>
		/// An <see cref="ISpObjectToken"/> representing the object token at the specified index. If the index is out of range, the behavior
		/// is undefined.
		/// </returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpObjectToken Item([In] uint Index);

		/// <summary>Retrieves the current count of items.</summary>
		/// <returns>The total number of items as an unsigned integer. Returns 0 if there are no items.</returns>
		uint GetCount();
	}

	/// <summary>
	/// Represents an audio interface that provides methods for managing audio streams, controlling audio state, and configuring audio settings.
	/// </summary>
	/// <remarks>
	/// The <see cref="ISpAudio"/> interface extends <see cref="ISpStreamFormat"/> and provides additional functionality for handling
	/// audio-specific operations, such as setting the audio state, configuring buffer information, and managing volume levels. This
	/// interface is typically used in speech-related applications to interact with audio input/output devices.
	/// </remarks>
	[ComImport, Guid("C05C768F-FAE8-4EC2-8E07-338321C12452"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpAudio : ISpStreamFormat
	{
		/// <inheritdoc/>
		new void Read(byte[] pv, int cb, nint pcbRead);

		/// <inheritdoc/>
		new void Write(byte[] pv, int cb, nint pcbWritten);

		/// <inheritdoc/>
		new void Seek(long dlibMove, int dwOrigin, nint plibNewPosition);

		/// <inheritdoc/>
		new void SetSize(long libNewSize);

		/// <inheritdoc/>
		new void CopyTo(IStream pstm, long cb, nint pcbRead, nint pcbWritten);

		/// <inheritdoc/>
		new void Commit(int grfCommitFlags);

		/// <inheritdoc/>
		new void Revert();

		/// <inheritdoc/>
		new void LockRegion(long libOffset, long cb, int dwLockType);

		/// <inheritdoc/>
		new void UnlockRegion(long libOffset, long cb, int dwLockType);

		/// <inheritdoc/>
		new void Stat(out STATSTG pstatstg, int grfStatFlag);

		/// <inheritdoc/>
		new void Clone(out IStream ppstm);

		/// <inheritdoc/>
		new void GetFormat(in Guid pguidFormatId, out SafeCoTaskMemStruct<WAVEFORMATEX> ppCoMemWaveFormatEx);

		/// <summary>Sets the audio state of the speech audio interface.</summary>
		/// <param name="NewState">The new audio state to set. This must be a valid <see cref="SPAUDIOSTATE"/> value.</param>
		/// <param name="ullReserved">Reserved for future use. The default value is 0.</param>
		void SetState([In] SPAUDIOSTATE NewState, [In] ulong ullReserved = 0);

		/// <summary>Sets the format of the audio device.</summary>
		/// <param name="rguidFmtId">
		/// The REFGUID for the format to set. Typically this will be SPDFID_WaveFormatEx. This is required for the SAPI multimedia objects.
		/// </param>
		/// <param name="pWaveFormatEx">Address of the WAVEFORMATEX structure containing the wave file format information.</param>
		void SetFormat(in Guid rguidFmtId, in WAVEFORMATEX pWaveFormatEx);

		/// <summary>Retrieves the current status of the audio device.</summary>
		/// <returns>An SPAUDIOSTATUS filled with the status details.</returns>
		/// <remarks>
		/// This method determines whether the device is running, stopped, closed, or paused. It also includes various parameters about the
		/// audio object, including how much data is buffered.
		/// </remarks>
		SPAUDIOSTATUS GetStatus();

		/// <summary>Sets the audio stream buffer information.</summary>
		/// <param name="pBuffInfo">The buffer settings.</param>
		void SetBufferInfo(in SPAUDIOBUFFERINFO pBuffInfo);

		/// <summary>Passes back the audio stream buffer information.</summary>
		/// <returns>The buffer settings.</returns>
		SPAUDIOBUFFERINFO GetBufferInfo();

		/// <summary>Gets the default audio format.</summary>
		/// <param name="pFormatId">Pointer to the GUID of the default format.</param>
		/// <param name="ppCoMemWaveFormatEx">
		/// Address of a pointer to the WAVEFORMATEX structure that receives the wave file format information. SAPI allocates the memory for
		/// the WAVEFORMATEX data structure using CoTaskMemAlloc, but it is the caller's responsibility to call CoTaskMemFree on the returned
		/// WAVEFORMATEX pointer.
		/// </param>
		void GetDefaultFormat(out Guid pFormatId, out StructPointer<WAVEFORMATEX> ppCoMemWaveFormatEx);

		/// <summary>Returns a Win32 event handle that applications can use to wait for status changes in the I/O stream.</summary>
		/// <returns>Win32 event handle that applications can use to wait for status changes in the I/O stream.</returns>
		/// <remarks>
		/// <para>The handle may use one of the various Win32 wait functions, such as WaitForSingleObject or WaitForMultipleObjects.</para>
		/// <para>
		/// For read streams, set the event when there is data available to read and reset it whenever there is no available data. For write
		/// streams, set the event when all of the data has been written to the device, and reset it at any time when there is still data
		/// available to be played.
		/// </para>
		/// <para>
		/// The caller should not close the returned handle, nor should the caller ever use the event handle after calling Release() on the
		/// audio object. The audio device will close the handle on the final release of the object.
		/// </para>
		/// </remarks>
		[PreserveSig]
		HEVENT EventHandle();

		/// <summary>
		/// Gets the current volume level of the audio device.
		/// <para>The volume level is on a linear scale from zero to 10000.</para>
		/// </summary>
		/// <returns>The current volume level of the audio device.</returns>
		uint GetVolumeLevel();

		/// <summary>Sets the current volume level. It is on a linear scale from zero to 10000.</summary>
		/// <param name="Level">The new volume level.</param>
		void SetVolumeLevel([In] uint Level);

		/// <summary>
		/// Gets the audio stream buffer size information. This information is used to determine when the event returned by
		/// ISpAudio::EventHandle is set or reset.
		/// </summary>
		/// <returns>The size information, specified in bytes, that is associated with the audio stream buffer.</returns>
		uint GetBufferNotifySize();

		/// <summary>Sets the size of the buffer notify.</summary>
		/// <param name="cbSize">Size of the cb.</param>
		void SetBufferNotifySize([In] uint cbSize);
	}

	/// <summary>
	/// The ISpDataKey interface provides a mechanism for storing and retrieving string and other data. ISpDataKey is used in conjunction
	/// with object tokens, which implement ISpObjectToken, which inherits from ISpDataKey. For example, data can be stored in an object
	/// token representing a recognizer or TTS engine using this interface.
	/// </summary>
	[ComImport, Guid("14056581-E16C-11D2-BB90-00C04F8EE6C0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpDataKey
	{
		/// <summary>Sets the binary data for a token.</summary>
		/// <param name="pszValueName">The registry key value name.</param>
		/// <param name="cbData">Size of the <paramref name="pData"/> parameter.</param>
		/// <param name="pData">Pointer to the buffer containing the information.</param>
		/// <returns>S_OK, E_INVALIDARG, FAILED(hr)</returns>
		[PreserveSig]
		HRESULT SetData([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName, [In] uint cbData, [In] IntPtr pData);

		/// <summary>Gets the binary data for a token.</summary>
		/// <param name="pszValueName">The registry key value name.</param>
		/// <param name="pcbData">Size of the <paramref name="pData"/> parameter.</param>
		/// <param name="pData">Pointer to the buffer receiving the information.</param>
		/// <returns>S_OK, E_INVALIDARG, E_POINTER, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		HRESULT GetData([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName, in uint pcbData, [Out] IntPtr pData);

		/// <summary>Sets the string value information for a specified token.</summary>
		/// <param name="pszValueName">The registry key value name. If NULL, the default value of the token is used.</param>
		/// <param name="pszValue">The string value to be set for the specified key..</param>
		/// <returns>S_OK, E_INVALIDARG, FAILED(hr)</returns>
		[PreserveSig]
		HRESULT SetStringValue([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszValueName,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszValue);

		/// <summary>Gets the string value information for a specified token.</summary>
		/// <param name="pszValueName">The registry key value name. If NULL, the default value of the token is used.</param>
		/// <param name="ppszValue">The string value for the specified key</param>
		/// <returns>S_OK, E_INVALIDARG, E_POINTER, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		HRESULT GetStringValue([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszValueName,
			[MarshalAs(UnmanagedType.LPWStr)] out string ppszValue);

		/// <summary>Sets the value information for a specified token.</summary>
		/// <param name="pszValueName">The attribute name.</param>
		/// <param name="dwValue">The attribute key value.</param>
		/// <returns>S_OK, E_INVALIDARG, FAILED(hr)</returns>
		[PreserveSig]
		HRESULT SetDWORD([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName, [In] uint dwValue);

		/// <summary>Gets the value information for a specified token.</summary>
		/// <param name="pszValueName">The attribute name.</param>
		/// <param name="pdwValue">The attribute key value.</param>
		/// <returns>S_OK, E_INVALIDARG, E_POINTER, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		HRESULT GetDWORD([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName, out uint pdwValue);

		/// <summary>Opens a specified token subkey. Passes back a new object that supports ISpDataKey for the specified subkey.</summary>
		/// <param name="pszSubKeyName">Name of the key to open.</param>
		/// <param name="ppSubKey">Address of a pointer to an ISpDataKey interface.</param>
		/// <returns>S_OK, E_INVALIDARG, E_POINTER, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		HRESULT OpenKey([In, MarshalAs(UnmanagedType.LPWStr)] string pszSubKeyName, [MarshalAs(UnmanagedType.Interface)] out ISpDataKey ppSubKey);

		/// <summary>
		/// Creates a new token subkey. Returns a new object which supports ISpDataKey for the specified subkey. If the key already exists,
		/// the function will open the existing key instead of overwriting it.
		/// </summary>
		/// <param name="pszSubKey">Name of the key to create.</param>
		/// <param name="ppSubKey">Address of a pointer to an ISpDataKey interface.</param>
		/// <returns>S_OK, E_INVALIDARG, FAILED(hr)</returns>
		[PreserveSig]
		HRESULT CreateKey([In, MarshalAs(UnmanagedType.LPWStr)] string pszSubKey, [MarshalAs(UnmanagedType.Interface)] out ISpDataKey ppSubKey);

		/// <summary>Deletes a specified token key and all its descendants.</summary>
		/// <param name="pszSubKey">The name of the key or subkey to delete.</param>
		/// <returns>S_OK, E_INVALIDARG, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		HRESULT DeleteKey([In, MarshalAs(UnmanagedType.LPWStr)] string pszSubKey);

		/// <summary>Deletes a named value from the specified token.</summary>
		/// <param name="pszValueName">The value name to be deleted.</param>
		/// <returns></returns>
		[PreserveSig]
		HRESULT DeleteValue([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName);

		/// <summary>Enumerates the subkeys of the specified token.</summary>
		/// <param name="Index">Value indicating which token in the enumeration sequence to locate.</param>
		/// <param name="ppszSubKeyName">The enumerated key name.</param>
		/// <returns>S_OK, E_INVALIDARG, SPERR_NOT_FOUND, E_OUTOFMEMORY, SPERR_NO_MORE_ITEMS, FAILED(hr)</returns>
		[PreserveSig]
		HRESULT EnumKeys([In] uint Index, [MarshalAs(UnmanagedType.LPWStr)] out string ppszSubKeyName);

		/// <summary>Enumerates the values of the specified token.</summary>
		/// <param name="Index">Value indicating which token in the enumeration sequence to locate.</param>
		/// <param name="ppszValueName">The enumerated values name.</param>
		/// <returns>S_OK, E_INVALIDARG, SPERR_NOT_FOUND, E_OUTOFMEMORY, SPERR_NO_MORE_ITEMS, FAILED(hr)</returns>
		[PreserveSig]
		HRESULT EnumValues([In] uint Index, [MarshalAs(UnmanagedType.LPWStr)] out string ppszValueName);
	}

	/// <summary>
	/// <para>
	/// The ISpeechAudio automation interface supports the control of real-time audio streams, such as those connected to a live microphone
	/// or telephone line.
	/// </para>
	/// <para>The Format property and the Read, Write and Seek methods are inherited from the ISpeechBaseStream interface.</para>
	/// </summary>
	[ComImport, Guid("CFF8E175-019E-11D3-A08E-00C04F8EF9B5")]
	public interface ISpeechAudio : ISpeechBaseStream
	{
		/// <inheritdoc/>
		[DispId(1)]
		new ISpeechAudioFormat? Format
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(1)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		/// <inheritdoc/>
		[DispId(2)]
		new int Read([MarshalAs(UnmanagedType.Struct)] out object Buffer, [In] int NumberOfBytes);

		/// <inheritdoc/>
		[DispId(3)]
		new int Write([In, MarshalAs(UnmanagedType.Struct)] object Buffer);

		/// <inheritdoc/>
		[DispId(4)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object Seek([In, MarshalAs(UnmanagedType.Struct)] object Position, [In] SpeechStreamSeekPositionType Origin = SpeechStreamSeekPositionType.SSSPTRelativeToStart);

		/// <summary>The Status property returns the audio status as an ISpeechAudioStatus object.</summary>
		/// <value>An ISpeechAudioStatus variable that gets the audio status.</value>
		[DispId(200)]
		ISpeechAudioStatus? Status
		{
			[DispId(200)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The BufferInfo property returns the audio buffer information as an ISpeechAudioBufferInfo object.</summary>
		/// <value>An ISpeechAudioBufferInfo object which gets the buffer data.</value>
		[DispId(201)]
		ISpeechAudioBufferInfo? BufferInfo
		{
			[DispId(201)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The DefaultFormat property returns the default audio format as an SpAudioFormat object.</summary>
		/// <value>A SpAudioFormat that gets the audio format.</value>
		[DispId(202)]
		ISpeechAudioFormat? DefaultFormat
		{
			[DispId(202)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>
		/// The Volume property gets and sets the volume (loudness) level. The volume level is on a linear scale from zero to 10,000.
		/// </summary>
		/// <value>The volume level is on a linear scale from zero to 10,000.</value>
		[DispId(203)]
		int Volume
		{
			[DispId(203)]
			get;
			[DispId(203)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>The BufferNotifySize property gets and sets the audio stream buffer size information.</para>
		/// <para>This information is used to determine when the event returned by the EventHandle method is set or reset.</para>
		/// </summary>
		/// <value>The size at which notifications are sent.</value>
		/// <remarks>
		/// <para>
		/// For read streams, the event is set if the audio buffered is greater than or equal to the value set in pcbSize, otherwise the
		/// event information is reset.
		/// </para>
		/// <para>
		/// For write streams, the event is set if the audio buffered is less than the value set in pcbSize, otherwise the event information
		/// is reset.
		/// </para>
		/// </remarks>
		[DispId(204)]
		int BufferNotifySize
		{
			[DispId(204)]
			get;
			[DispId(204)]
			[param: In]
			set;
		}

		/// <summary>
		/// The EventHandle property returns a Win32 event handle that applications can use to wait for status changes in the I/O stream.
		/// </summary>
		/// <value>The event handle.</value>
		[DispId(205)]
		int EventHandle
		{
			[DispId(205)]
			get;
		}

		/// <summary>The SetState method sets the audio state with a SpeechAudioState constant.</summary>
		/// <param name="State">Specifies a member of the SpeechAudioState enumeration.</param>
		[DispId(206)]
		void SetState([In] SpeechAudioState State);
	}

	/// <summary>The ISpeechAudioBufferInfo automation interface defines the audio stream buffer information.</summary>
	[ComImport, Guid("11B103D8-1142-4EDF-A093-82FB3915F8CC")]
	public interface ISpeechAudioBufferInfo
	{
		/// <summary>
		/// <para>
		/// The MinNotification property gets and sets the minimum preferred time, in milliseconds, between the actual time an event
		/// notification occurs and the ideal time.
		/// </para>
		/// <para>
		/// More CPU resources are needed when the amount of time is shorter; however, the event notifications are more timely. This value
		/// must be greater than zero and no more than one quarter the size of the Buffersize property.
		/// </para>
		/// </summary>
		/// <value>The minimum preferred time, in milliseconds.</value>
		[DispId(1)]
		int MinNotification
		{
			[DispId(1)]
			get;
			[DispId(1)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>The BufferSize property gets and sets the size of the audio object's buffer, in milliseconds.</para>
		/// <para>
		/// For readable audio objects, this is simply a preferred size because readable objects will automatically expand their buffers to
		/// accommodate data. For writable audio objects, this is the amount of audio data that will be buffered before a call to Write will block.
		/// </para>
		/// <para>This value must be greater than or equal to 200 milliseconds. A reasonable default is 500ms.</para>
		/// </summary>
		/// <value>The size of the buffer.</value>
		[DispId(2)]
		int BufferSize
		{
			[DispId(2)]
			get;
			[DispId(2)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>
		/// The EventBias property gets and sets the amount of time, in milliseconds, by which event notifications precede the actual
		/// occurrence of the events.
		/// </para>
		/// <para>
		/// For example, setting a value of 100 for the event bias would cause all events to be notified 100 milliseconds prior to the audio
		/// data being played. This can be useful for applications needing time to animate mouths for TTS voices.
		/// </para>
		/// </summary>
		/// <value>The amount of time, in milliseconds.</value>
		[DispId(3)]
		int EventBias
		{
			[DispId(3)]
			get;
			[DispId(3)]
			[param: In]
			set;
		}
	}

	/// <summary>
	/// <para>The SpAudioFormat automation object represents an audio format.</para>
	/// <para>
	/// Most applications using standard audio formats will use the Type property to set and retrieve formats. Non-standard formats using wav
	/// files will use SetWavFormatEx and GetWaveFormatEx to set and retrieve formats, respectively. Non-standard formats using sources other
	/// than wav files use Guid.
	/// </para>
	/// </summary>
	[ComImport, Guid("E6E9C590-3E18-40E3-8299-061F98BDE7C7"), CoClass(typeof(SpAudioFormat))]
	public interface ISpeechAudioFormat
	{
		/// <summary>
		/// <para>The Type property gets and sets the speech audio format as a SpeechAudioFormatType.</para>
		/// <para>Most applications using standard audio formats should use Type to set and retrieve formats.</para>
		/// </summary>
		/// <value>A SpeechAudioFormatType object.</value>
		[DispId(1)]
		SpeechAudioFormatType Type
		{
			[DispId(1)]
			get;
			[DispId(1)]
			[param: In]
			set;
		}

		/// <summary>
		/// <para>The Guid property returns the GUID of the default audio format.</para>
		/// <para>Non-standard formats using sources other than wav files should use Guid to set and retrieve formats.</para>
		/// </summary>
		/// <value>The unique identifier.</value>
		[DispId(2)]
		string? Guid
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(2)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		/// <summary>
		/// <para>The GetWaveFormatEx method gets the audio format as an SpWaveFormatEx object.</para>
		/// <para>Non-standard formats using wav files should use GetWaveFormatEx to retrieve formats.</para>
		/// </summary>
		/// <returns>The GetWaveFormatEx method returns an SpWaveFormatEx variable.</returns>
		/// <example>
		/// <para>
		/// The following Visual Basic form code demonstrates the use of the GetWaveFormatEx and SetWaveFormatEx properties. To run this
		/// code, create a form with the following controls:
		/// </para>
		/// <para>Two command buttons called Command1 and Command2 <br/> Paste this code into the Declarations section of the form.</para>
		/// <para>
		/// The Command1 procedure creates an SpAudioFormat object and sets it to the audio format SAFT22kHz16BitStereo. It then gets the
		/// format object's SpWaveFormatEx object and displays the properties. The code then changes the format of the SpAudioFormat object
		/// to SAFT11kHz16BitMono, gets a new SpWaveFormatEx object and displays its properties again. Note that the SpWaveFormatEx
		/// properties have changed to reflect the new audio format.
		/// </para>
		/// <para>
		/// The Command2 procedure creates an SpAudioFormat object and sets it to the audio format SAFT22kHz16BitStereo. It then gets the
		/// format object's SpWaveFormatEx object and displays the properties. The code then changes the properties of the SpWaveFormatEx
		/// object to match the SAFT11kHz16BitMono format and sets the format of the SpAudioFormat object with the SetWaveFormatEx method.
		/// Note that the SpAudioFormat object's Type property has changed to SAFT11kHz16BitMono to reflect the new SpWaveFormatEx properties.
		/// </para>
		/// <code language="vbnet">
		///Option Explicit
		///
		///Dim F As SpeechLib.SpAudioFormat
		///Dim W As SpeechLib.SpWaveFormatEx
		///
		///Private Sub Command1_Click()
		///On Error GoTo EH
		///
		///'Create an empty SpAudioFormat object
		///'Set it to the default format
		///'Get its format in an SpWaveFormatEx object
		///Set F = New SpAudioFormat
		///F.Type = SAFT22kHz16BitStereo
		///Set W = F.GetWaveFormatEx
		///
		///Debug.Print
		///Debug.Print "Default SpAudioFormat and SpWaveFormatEx"
		///Debug.Print "Format:        SAFT22kHz16BitStereo"
		///Debug.Print "Format code:   " &amp; F.Type
		///Debug.Print "AvgBytesPerSec " &amp; W.AvgBytesPerSec
		///Debug.Print "BitsPerSample  " &amp; W.BitsPerSample
		///Debug.Print "BlockAlign     " &amp; W.BlockAlign
		///Debug.Print "Channels       " &amp; W.Channels
		///Debug.Print "ExtraData      " &amp; W.ExtraData
		///Debug.Print "FormatTag      " &amp; W.FormatTag
		///Debug.Print "SamplesPerSec  " &amp; W.SamplesPerSec
		///
		///'Give the SpAudioFormat object an audio type
		///'Get its format in an SpWaveFormatEx object
		///F.Type = SAFT11kHz16BitMono
		///Set W = F.GetWaveFormatEx
		///
		///Debug.Print
		///Debug.Print "Changing SpAudioFormat changes SpWaveFormatEx"
		///Debug.Print "Format:        SAFT11kHz16BitMono"
		///Debug.Print "Format code:   " &amp; F.Type
		///Debug.Print "AvgBytesPerSec " &amp; W.AvgBytesPerSec
		///Debug.Print "BitsPerSample  " &amp; W.BitsPerSample
		///Debug.Print "BlockAlign     " &amp; W.BlockAlign
		///Debug.Print "Channels       " &amp; W.Channels
		///Debug.Print "ExtraData      " &amp; W.ExtraData
		///Debug.Print "FormatTag      " &amp; W.FormatTag
		///Debug.Print "SamplesPerSec  " &amp; W.SamplesPerSec
		///
		///EH:
		///If Err.Number Then ShowErrMsg
		///End Sub
		///
		///Private Sub Command2_Click()
		///On Error GoTo EH
		///
		///'Create an empty SpAudioFormat object
		///'Set it to the default format
		///'Get its format in an SpWaveFormatEx object
		///
		///Set F = New SpAudioFormat
		///F.Type = SAFT22kHz16BitStereo
		///Set W = F.GetWaveFormatEx
		///
		///Debug.Print
		///Debug.Print "Default SpAudioFormat and SpWaveFormatEx:"
		///Debug.Print "Format:        SAFT22kHz16BitStereo"
		///Debug.Print "Format code:   " &amp; F.Type
		///Debug.Print "AvgBytesPerSec " &amp; W.AvgBytesPerSec
		///Debug.Print "BitsPerSample  " &amp; W.BitsPerSample
		///Debug.Print "BlockAlign     " &amp; W.BlockAlign
		///Debug.Print "Channels       " &amp; W.Channels
		///Debug.Print "ExtraData      " &amp; W.ExtraData
		///Debug.Print "FormatTag      " &amp; W.FormatTag
		///Debug.Print "SamplesPerSec  " &amp; W.SamplesPerSec
		///
		///'Set SpWaveFormatEx properties as in SAFT11kHz16BitMono format;
		///'this will reset the SpAudioFormat Type.
		///
		///Debug.Print
		///Debug.Print "Changing SpWaveFormatEx properties changes SpAudioFormat:"
		///W.AvgBytesPerSec = 22050
		///W.BitsPerSample = 16
		///W.BlockAlign = 2
		///W.Channels = 1
		///W.SamplesPerSec = 11025
		///
		///Call F.SetWaveFormatEx(W)
		///Debug.Print "Format code:   " &amp; F.Type
		///
		///EH:
		///If Err.Number Then ShowErrMsg
		///End Sub
		///
		///Private Sub ShowErrMsg()
		///
		///' Declare identifiers:
		///Dim T As String
		///
		///T = "Desc: " &amp; Err.Description &amp; vbNewLine
		///T = T &amp; "Err #: " &amp; Err.Number
		///MsgBox T, vbExclamation, "Run-Time Error"
		///End
		///
		///End Sub
		/// </code>
		/// </example>
		[DispId(3)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechWaveFormatEx? GetWaveFormatEx();

		/// <summary>
		/// <para>The SetWaveFormatEx method sets the audio format with an SpWaveFormatEx object.</para>
		/// <para>Non-standard formats using wav files should use SetWavFormatEx to set formats.</para>
		/// </summary>
		/// <param name="SpeechWaveFormatEx">Specifies the WaveFormatEx.</param>
		[DispId(4)]
		void SetWaveFormatEx([In, MarshalAs(UnmanagedType.Interface)] ISpeechWaveFormatEx? SpeechWaveFormatEx);
	}

	/// <summary>
	/// <para>The ISpeechAudioStatus automation interface provides control over the operation of real-time audio streams.</para>
	/// <para>
	/// It is intended for use when the audio input or output source is not a standard Windows multimedia device. An audio stream connected
	/// to a microphone or a telephone line would be a typical use.
	/// </para>
	/// </summary>
	[ComImport, Guid("C62D9C91-7458-47F6-862D-1EF86FB0B278")]
	public interface ISpeechAudioStatus
	{
		/// <summary>The FreeBufferSpace property returns the size of the free space in the stream or device in bytes.</summary>
		/// <value>The free buffer space.</value>
		[DispId(1)]
		int FreeBufferSpace
		{
			[DispId(1)]
			get;
		}

		/// <summary>
		/// The NonBlockingIO property returns the amount of data which can be read from or written to the stream or device without blocking.
		/// </summary>
		/// <value>The count in bytes.</value>
		[DispId(2)]
		int NonBlockingIO
		{
			[DispId(2)]
			get;
		}

		/// <summary>The State property returns the state of the audio stream or device.</summary>
		/// <value>The state of the stream or device.</value>
		[DispId(3)]
		SpeechAudioState State
		{
			[DispId(3)]
			get;
		}

		/// <summary>
		/// <para>The CurrentSeekPosition property returns the current seek position in the audio stream or device in bytes.</para>
		/// <para>This is the position in the stream where the next read or write will be performed.</para>
		/// </summary>
		/// <value>The position.</value>
		[DispId(4)]
		object CurrentSeekPosition
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		/// <summary>
		/// <para>The CurrentDevicePosition property returns the current read or write position of the stream or device in bytes.</para>
		/// <para>
		/// This is the position in the stream where the device is currently reading or writing. For readable streams, this value will always
		/// be greater than or equal to the CurrentSeekPosition property. For writable streams, this value will always be less than or equal
		/// to the CurrentSeekPosition property.
		/// </para>
		/// </summary>
		/// <value>The position.</value>
		[DispId(5)]
		object CurrentDevicePosition
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}
	}

	/// <summary>
	/// <para>The ISpeechBaseStream automation interface defines properties and methods for manipulating data streams.</para>
	/// <para>ISpeechBaseStream objects normally contain audio data, but may also be used for text data.</para>
	/// <para>
	/// The Read, Write and Seek methods maintain a pointer referred to as the Seek pointer. The Read and Write methods begin reading or
	/// writing at the Seek pointer, and reset the Seek pointer one byte past the last byte read or written. The Seek method returns the
	/// current pointer, and can also move the Seek pointer forward or backward in the stream, starting from the Seek pointer, or relative to
	/// the beginning or the end of the stream.
	/// </para>
	/// <para>Use of the Read, Write and Seek methods are demonstrated in a code example at the end of the ISpeechBaseStream section.</para>
	/// <para>
	/// The ISpeechBaseStream is not an object in its own right, but is implemented by other objects, such as SpFileStream and
	/// SpMemoryStream. SAPI does not call ISpeechBaseStream methods, but uses the underlying COM interfaces. For this reason, a custom
	/// object cannot be created using the ISpeechBaseStream interface.
	/// </para>
	/// </summary>
	[ComImport, Guid("6450336F-7D49-4CED-8097-49D6DEE37294")]
	public interface ISpeechBaseStream
	{
		/// <summary>The Format property gets and sets the cached wave format of the stream as an SpAudioFormat object.</summary>
		/// <value>An SpAudioFormat object that identifies the wave format.</value>
		[DispId(1)]
		ISpeechAudioFormat? Format
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(1)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		/// <summary>
		/// <para>The Read method reads data from a stream object.</para>
		/// <para>
		/// The Read method reads text or audio data from the stream into a Variant variable. Data is read from the Seek pointer of the
		/// stream until the specified number of bytes has been copied, or the end of the stream has been reached. When the method has
		/// completed, it returns the actual number of bytes read and resets the Seek pointer one byte past the last byte read.
		/// </para>
		/// </summary>
		/// <param name="Buffer">Specifies a Variant variable to receive the data.</param>
		/// <param name="NumberOfBytes">Specifies the number of bytes of data to attempt to read from the audio stream.</param>
		/// <returns>A Long variable containing the actual number of bytes read from the stream object.</returns>
		[DispId(2)]
		int Read([MarshalAs(UnmanagedType.Struct)] out object Buffer, [In] int NumberOfBytes);

		/// <summary>
		/// <para>The Write method writes data to a stream object.</para>
		/// <para>
		/// The Write method writes text or audio data from a Variant variable into the stream, starting at the Seek pointer and writing
		/// until all data has been copied. When the method has completed, it returns the number of bytes written, and resets the Seek
		/// pointer one byte past the last byte written.
		/// </para>
		/// </summary>
		/// <param name="Buffer">A Variant variable containing the data to be written.</param>
		/// <returns>A Long variable indicating the number of bytes written.</returns>
		[DispId(3)]
		int Write([In, MarshalAs(UnmanagedType.Struct)] object Buffer);

		/// <summary>
		/// <para>The Seek method returns the current read position of the stream in bytes.</para>
		/// <para>
		/// The Seek method may also move the Seek pointer forward or backward in the stream. The parameter Position, specifies a number of
		/// bytes to move the Seek pointer forward in the stream; negative values specify moving the Seek pointer backward. The parameter
		/// Origin, specifies the point from which the forward or backward movement will begin. When the method has completed, it returns a
		/// Variant variable containing the new Seek pointer.
		/// </para>
		/// </summary>
		/// <param name="Position">
		/// Specifies the number of bytes to move the Seek pointer forward in the stream. Negative values move the pointer backward.
		/// </param>
		/// <param name="Origin">[Optional] Specifies the Origin. Default value is SSSPTRelativeToStart.</param>
		/// <returns>A Variant variable containing the new Seek pointer.</returns>
		/// <remarks>
		/// <para>
		/// The following are examples. This statement sets the Seek pointer 23,456 bytes past the start of the stream and returns a Variant
		/// containing the new Seek pointer:
		/// </para>
		/// <code>var curPos = stream.Seek(23456, SpeechStreamSeekPositionType.SSSPTRelativeToStart)</code>
		/// <para>This statement moves the Seek pointer forward 23,456 bytes and returns a Variant containing the new Seek pointer:</para>
		/// <code>var curPos = stream.Seek(23456, SpeechStreamSeekPositionType.SSSPTRelativeToCurrentPosition)</code>
		/// <para>
		/// This statement sets the Seek pointer to the end of the stream and returns a Variant containing the new Seek pointer, which in
		/// this case is equal to the size of the stream:
		/// </para>
		/// <code>var curPos = stream.Seek(0, SpeechStreamSeekPositionType.SSSPTRelativeToEnd)</code>
		/// </remarks>
		[DispId(4)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object Seek([In, MarshalAs(UnmanagedType.Struct)] object Position, [In] SpeechStreamSeekPositionType Origin = SpeechStreamSeekPositionType.SSSPTRelativeToStart);
	}

	/// <summary>Represents a custom speech stream that provides access to the underlying base stream.</summary>
	/// <remarks>
	/// This interface extends <see cref="ISpeechBaseStream"/> to include functionality for accessing and modifying the base stream used for
	/// speech processing. It allows integration with custom stream implementations.
	/// </remarks>
	[ComImport, Guid("1A9E9F4F-104F-4DB8-A115-EFD7FD0C97AE"), CoClass(typeof(SpCustomStream))]
	public interface ISpeechCustomStream : ISpeechBaseStream
	{
		/// <inheritdoc/>
		[DispId(1)]
		new ISpeechAudioFormat? Format
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(1)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		/// <inheritdoc/>
		[DispId(2)]
		new int Read([MarshalAs(UnmanagedType.Struct)] out object Buffer, [In] int NumberOfBytes);

		/// <inheritdoc/>
		[DispId(3)]
		new int Write([In, MarshalAs(UnmanagedType.Struct)] object Buffer);

		/// <inheritdoc/>
		[DispId(4)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object Seek([In, MarshalAs(UnmanagedType.Struct)] object Position, [In] SpeechStreamSeekPositionType Origin = SpeechStreamSeekPositionType.SSSPTRelativeToStart);

		/// <summary>Gets or sets the base stream.</summary>
		/// <value>The base stream.</value>
		[DispId(100)]
		object? BaseStream
		{
			[DispId(100)]
			[return: MarshalAs(UnmanagedType.IUnknown)]
			get;
			[DispId(100)]
			[param: In]
			[param: MarshalAs(UnmanagedType.IUnknown)]
			set;
		}
	}

	/// <summary>
	/// <para>The ISpeechDataKey automation interface provides read and write access to the speech configuration database.</para>
	/// <para>
	/// The Speech configuration database contains folders which represent the resources on a computer which are used by SAPI 5.1 SR and TTS.
	/// These folders are organized into resource categories, such as voices, lexicons, and audio input devices. The SpObjectTokenCategory
	/// object provides access to a category of resources, and the SpObjectToken object provides access to a single resource.
	/// </para>
	/// <para>
	/// An ISpeechDataKey object is typically created by the DataKey property of an SpObjectToken or the GetDataKey method of an
	/// SpObjectTokenCategory object. Such an ISpeechDataKey object provides read and write access to the database folder represented by its
	/// parent token or token category object. Further ISpeechDataKey objects can be created by CreateKey and OpenKey calls on existing
	/// ISpeechDataKey objects. ISpeechDataKey methods can create, delete and enumerate subfolders and values in the database folder
	/// represented by an ISpeechDataKey object.
	/// </para>
	/// </summary>
	[ComImport, Guid("CE17C09B-4EFA-44D5-A4C9-59D9585AB0CD")]
	public interface ISpeechDataKey
	{
		/// <summary>Sets the specified binary value in the data key.</summary>
		/// <param name="ValueName">Name of the value.</param>
		/// <param name="Value">The binary data value.</param>
		[DispId(1)]
		void SetBinaryValue([In, MarshalAs(UnmanagedType.BStr)] string ValueName, [In, MarshalAs(UnmanagedType.Struct)] object Value);

		/// <summary>Gets the specified binary value from the data key.</summary>
		/// <param name="ValueName">Name of the value.</param>
		/// <returns>A Variant variable.</returns>
		[DispId(2)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetBinaryValue([In, MarshalAs(UnmanagedType.BStr)] string ValueName);

		/// <summary>Sets the specified string value in the data key.</summary>
		/// <param name="ValueName">Name of the value.</param>
		/// <param name="Value">The string data value.</param>
		[DispId(3)]
		void SetStringValue([In, MarshalAs(UnmanagedType.BStr)] string ValueName, [In, MarshalAs(UnmanagedType.BStr)] string Value);

		/// <summary>Gets the specified string value from the data key.</summary>
		/// <param name="ValueName">Name of the value.</param>
		/// <returns>A string variable.</returns>
		[DispId(4)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string? GetStringValue([In, MarshalAs(UnmanagedType.BStr)] string ValueName);

		/// <summary>Sets the specified long value in the data key.</summary>
		/// <param name="ValueName">Name of the value.</param>
		/// <param name="Value">The long data value.</param>
		[DispId(5)]
		void SetLongValue([In, MarshalAs(UnmanagedType.BStr)] string ValueName, [In] int Value);

		/// <summary>Gets the specified long value from the data key.</summary>
		/// <param name="ValueName">Name of the value.</param>
		/// <returns>A long variable.</returns>
		[DispId(6)]
		int GetLongValue([In, MarshalAs(UnmanagedType.BStr)] string ValueName);

		/// <summary>The OpenKey method opens the specified subkey of the data key as another data key object.</summary>
		/// <param name="SubKeyName">Name of the subkey.</param>
		/// <returns>An ISpeechDataKey variable representing the subkey.</returns>
		[DispId(7)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechDataKey? OpenKey([In, MarshalAs(UnmanagedType.BStr)] string SubKeyName);

		/// <summary>The CreateKey method creates the specified subkey within the data key.</summary>
		/// <param name="SubKeyName">Name of the subkey.</param>
		/// <returns>An ISpeechDataKey variable representing the subkey.</returns>
		[DispId(8)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechDataKey? CreateKey([In, MarshalAs(UnmanagedType.BStr)] string SubKeyName);

		/// <summary>The DeleteKey method deletes the specified subkey from the data key.</summary>
		/// <param name="SubKeyName">Name of the subkey.</param>
		[DispId(9)]
		void DeleteKey([In, MarshalAs(UnmanagedType.BStr)] string SubKeyName);

		/// <summary>The DeleteValue method deletes the specified value from the data key.</summary>
		/// <param name="ValueName">Name of the value.</param>
		[DispId(10)]
		void DeleteValue([In, MarshalAs(UnmanagedType.BStr)] string ValueName);

		/// <summary>
		/// <para>The EnumKeys method returns the name of one subkey of the data key, specified by its index.</para>
		/// <para>
		/// The starting index is zero. A count of subkeys or an enumeration of subkey names can be performed by calling this method
		/// repetitively, starting with an index of zero, and increasing the index until all items are enumerated. This is indicated by an
		/// SPERR_NO_MORE_ITEMS error.
		/// </para>
		/// </summary>
		/// <param name="Index">The index of the subkey to be returned.</param>
		/// <returns>A String variable containing the name of the subkey.</returns>
		[DispId(11)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string? EnumKeys([In] int Index);

		/// <summary>
		/// <para>The EnumValues method returns the name of one value of the data key, specified by its index.</para>
		/// <para>
		/// The starting index is zero. A count of values or an enumeration of value names can be performed by calling this method
		/// repetitively, starting with an index of zero, and increasing the index until all items are enumerated.
		/// </para>
		/// </summary>
		/// <param name="Index">The index of the value to be returned.</param>
		/// <returns>A String variable containing the name of the value.</returns>
		[DispId(12)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string? EnumValues([In] int Index);
	}

	/// <summary>
	/// Represents a speech file stream that provides methods for opening, reading, writing, and seeking within a file used in speech-related operations.
	/// </summary>
	/// <remarks>
	/// This interface is used to interact with speech files, allowing for file-based input and output operations in speech applications. It
	/// extends <see cref="ISpeechBaseStream"/> to provide additional functionality specific to file streams, such as opening and closing files.
	/// </remarks>
	[ComImport, Guid("AF67F125-AB39-4E93-B4A2-CC2E66E182A7"), CoClass(typeof(SpFileStream))]
	public interface ISpeechFileStream : ISpeechBaseStream
	{
		/// <inheritdoc/>
		[DispId(1)]
		new ISpeechAudioFormat? Format
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(1)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		/// <inheritdoc/>
		[DispId(2)]
		new int Read([MarshalAs(UnmanagedType.Struct)] out object Buffer, [In] int NumberOfBytes);

		/// <inheritdoc/>
		[DispId(3)]
		new int Write([In, MarshalAs(UnmanagedType.Struct)] object Buffer);

		/// <inheritdoc/>
		[DispId(4)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object Seek([In, MarshalAs(UnmanagedType.Struct)] object Position, [In] SpeechStreamSeekPositionType Origin = SpeechStreamSeekPositionType.SSSPTRelativeToStart);

		/// <summary>Opens a speech stream file for reading or writing.</summary>
		/// <remarks>
		/// Use this method to open a speech stream file for reading or writing. Ensure the file path is valid and accessible. When <paramref
		/// name="DoEvents"/> is set to <see langword="true"/>, the method processes events during the operation, which may impact performance.
		/// </remarks>
		/// <param name="FileName">The path to the file to open. The file name must be a valid path and cannot be null or empty.</param>
		/// <param name="FileMode">Specifies the mode in which the file should be opened. The default is <see cref="SpeechStreamFileMode.SSFMOpenForRead"/>.</param>
		/// <param name="DoEvents">
		/// Indicates whether the method should process events while opening the file. Pass <see langword="true"/> to enable event
		/// processing; otherwise, <see langword="false"/>.
		/// </param>
		[DispId(100)]
		void Open([In, MarshalAs(UnmanagedType.BStr)] string FileName, [In] SpeechStreamFileMode FileMode = SpeechStreamFileMode.SSFMOpenForRead, [In] bool DoEvents = false);

		/// <summary>Closes the current object and releases any associated resources.</summary>
		/// <remarks>
		/// Once this method is called, the object is no longer usable, and any subsequent calls to its members may result in undefined
		/// behavior. Ensure that all necessary operations are completed before invoking this method.
		/// </remarks>
		[DispId(101)]
		void Close();
	}

	/// <summary>The ISpeechGrammarRule automation interface defines the properties and methods of a speech grammar rule.</summary>
	[ComImport, Guid("AFE719CF-5DD1-44F2-999C-7A399F1CFCCC")]
	public interface ISpeechGrammarRule
	{
		/// <summary>
		/// <para>The Attributes property returns information about the attributes of each grammar rule.</para>
		/// <para>This property consists of one or more members of the SpeechRuleAttributes enumeration.</para>
		/// </summary>
		/// <value>One or more SpeechRuleAttributes flags representing the attributes of the rule.</value>
		[DispId(1)]
		SpeechRuleAttributes Attributes
		{
			[DispId(1)]
			get;
		}

		/// <summary>The InitialState property specifies the initial state of the speech grammar rule.</summary>
		/// <value>An ISpeechGrammarRuleState variable that gets the initial rule state.</value>
		[DispId(2)]
		ISpeechGrammarRuleState? InitialState
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		/// <summary>The Name property specifies the name of the speech grammar rule.</summary>
		/// <value>The name of the rule.</value>
		[DispId(3)]
		string? Name
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>The Id property specifies the ID of the speech grammar rule.</summary>
		/// <value>The ID of the rule.</value>
		[DispId(4)]
		int Id
		{
			[DispId(4)]
			get;
		}

		/// <summary>The Clear method clears a rule, leaving only its initial state.</summary>
		[DispId(5)]
		void Clear();

		/// <summary>
		/// <para>The AddResource method adds one or more string name/value pair associated with a rule.</para>
		/// <para>
		/// This method is used with an interpreter rule, in which case the interpreter can call the C/C++ function
		/// ISpCFGInterpreterSite::GetResourceValue to get the value of a specified resource name.
		/// </para>
		/// </summary>
		/// <param name="ResourceName">Name of the resource.</param>
		/// <param name="ResourceValue">The resource value.</param>
		[DispId(6)]
		void AddResource([In, MarshalAs(UnmanagedType.BStr)] string ResourceName, [In, MarshalAs(UnmanagedType.BStr)] string ResourceValue);

		/// <summary>
		/// <para>The AddState method adds a state to a speech rule.</para>
		/// <para>
		/// This method can be used with the ISpeechGrammarRuleState methods AddRuleTransition, AddSpecialTransition, or AddWordTransition to
		/// modify speech rules programmatically.
		/// </para>
		/// </summary>
		/// <returns>An ISpeechGrammarRuleState object.</returns>
		[DispId(7)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechGrammarRuleState? AddState();
	}

	[ComImport, DefaultMember("Item"), Guid("6FFA3B44-FC2D-40D1-8AFC-32911C7F1AD1")]
	public interface ISpeechGrammarRules : System.Collections.IEnumerable, ICOMEnum<ISpeechGrammarRule>
	{
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		[DispId(6)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechGrammarRule? FindRule([In, MarshalAs(UnmanagedType.Struct)] object RuleNameOrId);

		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechGrammarRule? Item([In] int Index);

		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = EnumVariantMarshaler)]
		new System.Collections.IEnumerator GetEnumerator();

		[DispId(2)]
		bool Dynamic
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechGrammarRule? Add([In, MarshalAs(UnmanagedType.BStr)] string RuleName, [In] SpeechRuleAttributes Attributes, [In] int RuleId = 0);

		[DispId(4)]
		void Commit();

		[DispId(5)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object CommitAndSave([MarshalAs(UnmanagedType.BStr)] out string? ErrorText);
	}

	[ComImport, Guid("D4286F2C-EE67-45AE-B928-28D695362EDA")]
	public interface ISpeechGrammarRuleState
	{
		[DispId(1)]
		ISpeechGrammarRule? Rule
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		ISpeechGrammarRuleStateTransitions? Transitions
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(3)]
		void AddWordTransition([In, MarshalAs(UnmanagedType.Interface)] ISpeechGrammarRuleState? DestState, [In, MarshalAs(UnmanagedType.BStr)] string Words,
			[In, MarshalAs(UnmanagedType.BStr)] string Separators = " ", [In] SpeechGrammarWordType Type = SpeechGrammarWordType.SGLexical,
			[In, MarshalAs(UnmanagedType.BStr)] string PropertyName = "", [In] int PropertyId = 0,
			[In, MarshalAs(UnmanagedType.Struct)] object? PropertyValue = null, [In] float Weight = 1f);

		[DispId(4)]
		void AddRuleTransition([In, MarshalAs(UnmanagedType.Interface)] ISpeechGrammarRuleState? DestinationState, [In, MarshalAs(UnmanagedType.Interface)] ISpeechGrammarRule? Rule,
			[In, MarshalAs(UnmanagedType.BStr)] string PropertyName = "", [In] int PropertyId = 0, [In, MarshalAs(UnmanagedType.Struct)] object? PropertyValue = null, [In] float Weight = 1f);

		[DispId(5)]
		void AddSpecialTransition([In, MarshalAs(UnmanagedType.Interface)] ISpeechGrammarRuleState? DestinationState, [In] SpeechSpecialTransitionType Type,
			[In, MarshalAs(UnmanagedType.BStr)] string PropertyName = "", [In] int PropertyId = 0, [In, MarshalAs(UnmanagedType.Struct)] object? PropertyValue = null, [In] float Weight = 1f);
	}

	[ComImport, Guid("CAFD1DB1-41D1-4A06-9863-E2E81DA17A9A")]
	public interface ISpeechGrammarRuleStateTransition
	{
		[DispId(1)]
		SpeechGrammarRuleStateTransitionType Type
		{
			[DispId(1)]
			get;
		}

		[DispId(2)]
		string? Text
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(3)]
		ISpeechGrammarRule Rule
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(4)]
		object Weight
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(5)]
		string? PropertyName
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(6)]
		int PropertyId
		{
			[DispId(6)]
			get;
		}

		[DispId(7)]
		object PropertyValue
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(8)]
		ISpeechGrammarRuleState? NextState
		{
			[DispId(8)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	[ComImport, Guid("EABCE657-75BC-44A2-AA7F-C56476742963"), DefaultMember("Item")]
	public interface ISpeechGrammarRuleStateTransitions : System.Collections.IEnumerable
	{
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechGrammarRuleStateTransition? Item([In] int Index);

		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = EnumVariantMarshaler)]
		new System.Collections.IEnumerator GetEnumerator();
	}

	[ComImport, Guid("3DA7627A-C7AE-4B23-8708-638C50362C25"), CoClass(typeof(SpLexicon))]
	public interface ISpeechLexicon
	{
		[DispId(1)]
		int GenerationId
		{
			[DispId(1)]
			get;
		}

		[DispId(2)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechLexiconWords? GetWords([In, Optional, DefaultParameterValue((SpeechLexiconType)3)] SpeechLexiconType Flags, [Optional, DefaultParameterValue(0)] out int GenerationId);

		[DispId(3)]
		void AddPronunciation([In, MarshalAs(UnmanagedType.BStr)] string bstrWord, [In] int LangId, [In] SpeechPartOfSpeech PartOfSpeech = SpeechPartOfSpeech.SPSUnknown,
			[In, MarshalAs(UnmanagedType.BStr)] string bstrPronunciation = "");

		[DispId(4)]
		void AddPronunciationByPhoneIds([In, MarshalAs(UnmanagedType.BStr)] string bstrWord, [In] int LangId, [In] SpeechPartOfSpeech PartOfSpeech = SpeechPartOfSpeech.SPSUnknown,
			[In, MarshalAs(UnmanagedType.Struct)] object? PhoneIds = null);

		[DispId(5)]
		void RemovePronunciation([In, MarshalAs(UnmanagedType.BStr)] string bstrWord, [In] int LangId, [In] SpeechPartOfSpeech PartOfSpeech = SpeechPartOfSpeech.SPSUnknown,
			[In, MarshalAs(UnmanagedType.BStr)] string bstrPronunciation = "");

		[DispId(6)]
		void RemovePronunciationByPhoneIds([In, MarshalAs(UnmanagedType.BStr)] string bstrWord, [In] int LangId, [In] SpeechPartOfSpeech PartOfSpeech = SpeechPartOfSpeech.SPSUnknown,
			[In, MarshalAs(UnmanagedType.Struct)] object? PhoneIds = null);

		[DispId(7)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechLexiconPronunciations? GetPronunciations([In, MarshalAs(UnmanagedType.BStr)] string bstrWord, [In] int LangId = 0, [In] SpeechLexiconType TypeFlags = (SpeechLexiconType)3);

		[DispId(8)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechLexiconWords? GetGenerationChange(out int GenerationId);
	}

	[ComImport, Guid("95252C5D-9E43-4F4A-9899-48EE73352F9F")]
	public interface ISpeechLexiconPronunciation
	{
		[DispId(1)]
		SpeechLexiconType Type
		{
			[DispId(1)]
			get;
		}

		[DispId(2)]
		int LangId
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		SpeechPartOfSpeech PartOfSpeech
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		object PhoneIds
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(5)]
		string? Symbolic
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
	}

	[ComImport, DefaultMember("Item"), Guid("72829128-5682-4704-A0D4-3E2BB6F2EAD3")]
	public interface ISpeechLexiconPronunciations : System.Collections.IEnumerable
	{
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechLexiconPronunciation? Item([In] int Index);

		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = EnumVariantMarshaler)]
		new System.Collections.IEnumerator GetEnumerator();
	}

	[ComImport, Guid("4E5B933C-C9BE-48ED-8842-1EE51BB1D4FF")]
	public interface ISpeechLexiconWord
	{
		[DispId(1)]
		int LangId
		{
			[DispId(1)]
			get;
		}

		[DispId(2)]
		SpeechWordType Type
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		string? Word
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(4)]
		ISpeechLexiconPronunciations? Pronunciations
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	[ComImport, DefaultMember("Item"), Guid("8D199862-415E-47D5-AC4F-FAA608B424E6")]
	public interface ISpeechLexiconWords : System.Collections.IEnumerable
	{
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechLexiconWord? Item([In] int Index);

		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = EnumVariantMarshaler)]
		new System.Collections.IEnumerator GetEnumerator();
	}

	[ComImport, Guid("EEB14B68-808B-4ABE-A5EA-B51DA7588008"), CoClass(typeof(SpMemoryStream))]
	public interface ISpeechMemoryStream : ISpeechBaseStream
	{
		[DispId(1)]
		new ISpeechAudioFormat? Format
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(1)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		[DispId(2)]
		new int Read([MarshalAs(UnmanagedType.Struct)] out object Buffer, [In] int NumberOfBytes);

		[DispId(3)]
		new int Write([In, MarshalAs(UnmanagedType.Struct)] object Buffer);

		[DispId(4)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object Seek([In, MarshalAs(UnmanagedType.Struct)] object Position, [In] SpeechStreamSeekPositionType Origin = SpeechStreamSeekPositionType.SSSPTRelativeToStart);

		[DispId(100)]
		void SetData([In, MarshalAs(UnmanagedType.Struct)] object Data);

		[DispId(101)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object GetData();
	}

	[ComImport, Guid("3C76AF6D-1FD7-4831-81D1-3B71D5A13C44")]
	public interface ISpeechMMSysAudio : ISpeechAudio
	{
		[DispId(1)]
		new ISpeechAudioFormat? Format
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(1)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		[DispId(2)]
		new int Read([MarshalAs(UnmanagedType.Struct)] out object Buffer, [In] int NumberOfBytes);

		[DispId(3)]
		new int Write([In, MarshalAs(UnmanagedType.Struct)] object Buffer);

		[DispId(4)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object Seek([In, MarshalAs(UnmanagedType.Struct)] object Position, [In] SpeechStreamSeekPositionType Origin = SpeechStreamSeekPositionType.SSSPTRelativeToStart);

		[DispId(200)]
		new ISpeechAudioStatus? Status
		{
			[DispId(200)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(201)]
		new ISpeechAudioBufferInfo? BufferInfo
		{
			[DispId(201)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(202)]
		new ISpeechAudioFormat? DefaultFormat
		{
			[DispId(202)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(203)]
		new int Volume
		{
			[DispId(203)]
			get;
			[DispId(203)]
			[param: In]
			set;
		}

		[DispId(204)]
		new int BufferNotifySize
		{
			[DispId(204)]
			get;
			[DispId(204)]
			[param: In]
			set;
		}

		[DispId(205)]
		new int EventHandle
		{
			[DispId(205)]
			get;
		}

		[DispId(206)]
		new void SetState([In] SpeechAudioState State);

		[DispId(300)]
		int DeviceId
		{
			[DispId(300)]
			get;
			[DispId(300)]
			[param: In]
			set;
		}

		[DispId(301)]
		int LineId
		{
			[DispId(301)]
			get;
			[DispId(301)]
			[param: In]
			set;
		}

		[DispId(302)]
		int MMHandle
		{
			[DispId(302)]
			get;
		}
	}

	[ComImport, Guid("C74A3ADC-B727-4500-A84A-B526721C8B8C"), CoClass(typeof(SpObjectToken))]
	public interface ISpeechObjectToken
	{
		[DispId(1)]
		string Id
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(2)]
		ISpeechDataKey DataKey
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(3)]
		SpObjectTokenCategory Category
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(4)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetDescription([In] int Locale = 0);

		[DispId(5)]
		void SetId([In, MarshalAs(UnmanagedType.BStr)] string Id, [In, MarshalAs(UnmanagedType.BStr)] string CategoryID = "", [In] bool CreateIfNotExist = false);

		[DispId(6)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetAttribute([In, MarshalAs(UnmanagedType.BStr)] string AttributeName);

		[DispId(7)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object CreateInstance([In, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter = null, [In] SpeechTokenContext ClsContext = SpeechTokenContext.STCAll);

		[DispId(8)]
		void Remove([In, MarshalAs(UnmanagedType.BStr)] string ObjectStorageCLSID);

		[DispId(9)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetStorageFileName([In, MarshalAs(UnmanagedType.BStr)] string ObjectStorageCLSID, [In, MarshalAs(UnmanagedType.BStr)] string KeyName, [In, MarshalAs(UnmanagedType.BStr)] string FileName, [In] SpeechTokenShellFolder Folder);

		[DispId(10)]
		void RemoveStorageFileName([In, MarshalAs(UnmanagedType.BStr)] string ObjectStorageCLSID, [In, MarshalAs(UnmanagedType.BStr)] string KeyName, [In] bool DeleteFile);

		[DispId(11)]
		bool IsUISupported([In, MarshalAs(UnmanagedType.BStr)] string TypeOfUI, [In, MarshalAs(UnmanagedType.Struct)] object? ExtraData = null, [In, MarshalAs(UnmanagedType.IUnknown)] object? Object = null);

		[DispId(12)]
		void DisplayUI([In] int hWnd, [In, MarshalAs(UnmanagedType.BStr)] string Title, [In, MarshalAs(UnmanagedType.BStr)] string TypeOfUI, [In, MarshalAs(UnmanagedType.Struct)] object? ExtraData = null, [In, MarshalAs(UnmanagedType.IUnknown)] object? Object = null);

		[DispId(13)]
		bool MatchesAttributes([In, MarshalAs(UnmanagedType.BStr)] string Attributes);
	}

	[ComImport, Guid("CA7EAC50-2D01-4145-86D4-5AE7D70F4469"), CoClass(typeof(SpObjectTokenCategory))]
	public interface ISpeechObjectTokenCategory
	{
		[DispId(1)]
		string? Id
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(2)]
		string? Default
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
			[DispId(2)]
			[param: In]
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
		}

		[DispId(3)]
		void SetId([In, MarshalAs(UnmanagedType.BStr)] string Id, [In] bool CreateIfNotExist = false);

		[DispId(4)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechDataKey? GetDataKey([In] SpeechDataKeyLocation Location = SpeechDataKeyLocation.SDKLDefaultLocation);

		[DispId(5)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechObjectTokens? EnumerateTokens([In, MarshalAs(UnmanagedType.BStr)] string RequiredAttributes = "", [In, MarshalAs(UnmanagedType.BStr)] string OptionalAttributes = "");
	}

	[ComImport, DefaultMember("Item"), Guid("9285B776-2E7B-4BC0-B53E-580EB6FA967F")]
	public interface ISpeechObjectTokens : System.Collections.IEnumerable
	{
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		SpObjectToken Item([In] int Index);

		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = EnumVariantMarshaler)]
		new System.Collections.IEnumerator GetEnumerator();
	}

	[ComImport, Guid("C3E4F353-433F-43D6-89A1-6A62A7054C3D"), CoClass(typeof(SpPhoneConverter))]
	public interface ISpeechPhoneConverter
	{
		[DispId(1)]
		int LanguageId
		{
			[DispId(1)]
			get;
			[DispId(1)]
			[param: In]
			set;
		}

		[DispId(2)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object PhoneToId([In, MarshalAs(UnmanagedType.BStr)] string Phonemes);

		[DispId(3)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string? IdToPhone([In, MarshalAs(UnmanagedType.Struct)] object IdArray);
	}

	[ComImport, Guid("27864A2A-2B9F-4CB8-92D3-0D2722FD1E73")]
	public interface ISpeechPhraseAlternate
	{
		[DispId(1)]
		ISpeechRecoResult? RecoResult
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		int StartElementInResult
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		int NumberOfElementsInResult
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		ISpeechPhraseInfo? PhraseInfo
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(5)]
		void Commit();
	}

	[ComImport, Guid("B238B6D5-F276-4C3D-A6C1-2974801C3CC2"), DefaultMember("Item")]
	public interface ISpeechPhraseAlternates : System.Collections.IEnumerable
	{
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechPhraseAlternate? Item([In] int Index);

		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = EnumVariantMarshaler)]
		new System.Collections.IEnumerator GetEnumerator();
	}

	[ComImport, Guid("E6176F96-E373-4801-B223-3B62C068C0B4")]
	public interface ISpeechPhraseElement
	{
		[DispId(1)]
		int AudioTimeOffset
		{
			[DispId(1)]
			get;
		}

		[DispId(2)]
		int AudioSizeTime
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		int AudioStreamOffset
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		int AudioSizeBytes
		{
			[DispId(4)]
			get;
		}

		[DispId(5)]
		int RetainedStreamOffset
		{
			[DispId(5)]
			get;
		}

		[DispId(6)]
		int RetainedSizeBytes
		{
			[DispId(6)]
			get;
		}

		[DispId(7)]
		string? DisplayText
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(8)]
		string? LexicalForm
		{
			[DispId(8)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(9)]
		object Pronunciation
		{
			[DispId(9)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(10)]
		SpeechDisplayAttributes DisplayAttributes
		{
			[DispId(10)]
			get;
		}

		[DispId(11)]
		SpeechEngineConfidence RequiredConfidence
		{
			[DispId(11)]
			get;
		}

		[DispId(12)]
		SpeechEngineConfidence ActualConfidence
		{
			[DispId(12)]
			get;
		}

		[DispId(13)]
		float EngineConfidence
		{
			[DispId(13)]
			get;
		}
	}

	[ComImport, DefaultMember("Item"), Guid("0626B328-3478-467D-A0B3-D0853B93DDA3")]
	public interface ISpeechPhraseElements : System.Collections.IEnumerable
	{
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechPhraseElement? Item([In] int Index);

		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = EnumVariantMarshaler)]
		new System.Collections.IEnumerator GetEnumerator();
	}

	[ComImport, Guid("961559CF-4E67-4662-8BF0-D93F1FCD61B3")]
	public interface ISpeechPhraseInfo
	{
		[DispId(1)]
		int LanguageId
		{
			[DispId(1)]
			get;
		}

		[DispId(2)]
		object GrammarId
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(3)]
		object StartTime
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(4)]
		object AudioStreamPosition
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(5)]
		int AudioSizeBytes
		{
			[DispId(5)]
			get;
		}

		[DispId(6)]
		int RetainedSizeBytes
		{
			[DispId(6)]
			get;
		}

		[DispId(7)]
		int AudioSizeTime
		{
			[DispId(7)]
			get;
		}

		[DispId(8)]
		ISpeechPhraseRule? Rule
		{
			[DispId(8)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(9)]
		ISpeechPhraseProperties? Properties
		{
			[DispId(9)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(10)]
		ISpeechPhraseElements? Elements
		{
			[DispId(10)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(11)]
		ISpeechPhraseReplacements? Replacements
		{
			[DispId(11)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(12)]
		string? EngineId
		{
			[DispId(12)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(13)]
		object EnginePrivateData
		{
			[DispId(13)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(14)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object SaveToMemory();

		[DispId(15)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string? GetText([In] int StartElement = 0, [In] int Elements = -1, [In] bool UseReplacements = true);

		[DispId(16)]
		SpeechDisplayAttributes GetDisplayAttributes([In] int StartElement = 0, [In] int Elements = -1, [In] bool UseReplacements = true);
	}

	[ComImport, Guid("3B151836-DF3A-4E0A-846C-D2ADC9334333"), CoClass(typeof(SpPhraseInfoBuilder))]
	public interface ISpeechPhraseInfoBuilder
	{
		[DispId(1)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechPhraseInfo? RestorePhraseFromMemory([In, MarshalAs(UnmanagedType.Struct)] in object PhraseInMemory);
	}

	[ComImport, DefaultMember("Item"), Guid("08166B47-102E-4B23-A599-BDB98DBFD1F4")]
	public interface ISpeechPhraseProperties : System.Collections.IEnumerable
	{
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechPhraseProperty? Item([In] int Index);

		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = EnumVariantMarshaler)]
		new System.Collections.IEnumerator GetEnumerator();
	}

	[ComImport, Guid("CE563D48-961E-4732-A2E1-378A42B430BE")]
	public interface ISpeechPhraseProperty
	{
		[DispId(1)]
		string? Name
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(2)]
		int Id
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		object Value
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(4)]
		int FirstElement
		{
			[DispId(4)]
			get;
		}

		[DispId(5)]
		int NumberOfElements
		{
			[DispId(5)]
			get;
		}

		[DispId(6)]
		float EngineConfidence
		{
			[DispId(6)]
			get;
		}

		[DispId(7)]
		SpeechEngineConfidence Confidence
		{
			[DispId(7)]
			get;
		}

		[DispId(8)]
		ISpeechPhraseProperty? Parent
		{
			[DispId(8)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(9)]
		ISpeechPhraseProperties? Children
		{
			[DispId(9)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}

	[ComImport, Guid("2890A410-53A7-4FB5-94EC-06D4998E3D02")]
	public interface ISpeechPhraseReplacement
	{
		[DispId(1)]
		SpeechDisplayAttributes DisplayAttributes
		{
			[DispId(1)]
			get;
		}

		[DispId(2)]
		string? Text
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(3)]
		int FirstElement
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		int NumberOfElements
		{
			[DispId(4)]
			get;
		}
	}

	[ComImport, DefaultMember("Item"), Guid("38BC662F-2257-4525-959E-2069D2596C05")]
	public interface ISpeechPhraseReplacements : System.Collections.IEnumerable
	{
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechPhraseReplacement? Item([In] int Index);

		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = EnumVariantMarshaler)]
		new System.Collections.IEnumerator GetEnumerator();
	}

	[ComImport, Guid("A7BFE112-A4A0-48D9-B602-C313843F6964")]
	public interface ISpeechPhraseRule
	{
		[DispId(1)]
		string? Name
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(2)]
		int Id
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		int FirstElement
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		int NumberOfElements
		{
			[DispId(4)]
			get;
		}

		[DispId(5)]
		ISpeechPhraseRule? Parent
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(6)]
		ISpeechPhraseRules? Children
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(7)]
		SpeechEngineConfidence Confidence
		{
			[DispId(7)]
			get;
		}

		[DispId(8)]
		float EngineConfidence
		{
			[DispId(8)]
			get;
		}
	}

	[ComImport, DefaultMember("Item"), Guid("9047D593-01DD-4B72-81A3-E4A0CA69F407")]
	public interface ISpeechPhraseRules : System.Collections.IEnumerable
	{
		[DispId(1)]
		int Count
		{
			[DispId(1)]
			get;
		}

		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechPhraseRule? Item([In] int Index);

		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = EnumVariantMarshaler)]
		new System.Collections.IEnumerator GetEnumerator();
	}

	[ComImport, Guid("580AA49D-7E1E-4809-B8E2-57DA806104B8")]
	public interface ISpeechRecoContext
	{
		[DispId(1)]
		ISpeechRecognizer? Recognizer
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		SpeechInterference AudioInputInterferenceStatus
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		string? RequestedUIType
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(4)]
		ISpeechVoice? Voice
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(4)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		[DispId(5)]
		bool AllowVoiceFormatMatchingOnNextSet
		{
			[DispId(5)]
			get;
			[DispId(5)]
			[param: In]
			set;
		}

		[DispId(6)]
		SpeechRecoEvents VoicePurgeEvent
		{
			[DispId(6)]
			get;
			[DispId(6)]
			[param: In]
			set;
		}

		[DispId(7)]
		SpeechRecoEvents EventInterests
		{
			[DispId(7)]
			get;
			[DispId(7)]
			[param: In]
			set;
		}

		[DispId(8)]
		int CmdMaxAlternates
		{
			[DispId(8)]
			get;
			[DispId(8)]
			[param: In]
			set;
		}

		[DispId(9)]
		SpeechRecoContextState State
		{
			[DispId(9)]
			get;
			[DispId(9)]
			[param: In]
			set;
		}

		[DispId(10)]
		SpeechRetainedAudioOptions RetainedAudio
		{
			[DispId(10)]
			get;
			[DispId(10)]
			[param: In]
			set;
		}

		[DispId(11)]
		ISpeechAudioFormat? RetainedAudioFormat
		{
			[DispId(11)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(11)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		[DispId(12)]
		void Pause();

		[DispId(13)]
		void Resume();

		[DispId(14)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechRecoGrammar? CreateGrammar([In, DefaultParameterValue(0), MarshalAs(UnmanagedType.Struct)] object GrammarId);

		[DispId(15)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechRecoResult? CreateResultFromMemory([In, MarshalAs(UnmanagedType.Struct)] in object ResultBlock);

		[DispId(16)]
		void Bookmark([In] SpeechBookmarkOptions Options, [In, MarshalAs(UnmanagedType.Struct)] object StreamPos, [In, MarshalAs(UnmanagedType.Struct)] object BookmarkId);

		[DispId(17)]
		void SetAdaptationData([In, MarshalAs(UnmanagedType.BStr)] string AdaptationString);
	}

	[ComImport, Guid("2D5F1C0C-BD75-4B08-9478-3B11FEA2586C")]
	public interface ISpeechRecognizer
	{
		[DispId(1)]
		ISpeechObjectToken? Recognizer
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(1)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		[DispId(2)]
		bool AllowAudioInputFormatChangesOnNextSet
		{
			[DispId(2)]
			get;
			[DispId(2)]
			[param: In]
			set;
		}

		[DispId(3)]
		ISpeechObjectToken? AudioInput
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(3)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		[DispId(4)]
		ISpeechBaseStream? AudioInputStream
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(4)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		[DispId(5)]
		bool IsShared
		{
			[DispId(5)]
			get;
		}

		[DispId(6)]
		SpeechRecognizerState State
		{
			[DispId(6)]
			get;
			[DispId(6)]
			[param: In]
			set;
		}

		[DispId(7)]
		ISpeechRecognizerStatus Status
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(8)]
		ISpeechObjectToken? Profile
		{
			[DispId(8)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(8)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		[DispId(9)]
		void EmulateRecognition([In, MarshalAs(UnmanagedType.Struct)] object TextElements, [In, MarshalAs(UnmanagedType.Struct)] object? ElementDisplayAttributes = null, [In] int LanguageId = 0);

		[DispId(10)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechRecoContext? CreateRecoContext();

		[DispId(11)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechAudioFormat? GetFormat([In] SpeechFormatType Type);

		[DispId(12)]
		bool SetPropertyNumber([In, MarshalAs(UnmanagedType.BStr)] string Name, [In] int Value);

		[DispId(13)]
		bool GetPropertyNumber([In, MarshalAs(UnmanagedType.BStr)] string Name, out int Value);

		[DispId(14)]
		bool SetPropertyString([In, MarshalAs(UnmanagedType.BStr)] string Name, [In, MarshalAs(UnmanagedType.BStr)] string Value);

		[DispId(15)]
		bool GetPropertyString([In, MarshalAs(UnmanagedType.BStr)] string Name, [MarshalAs(UnmanagedType.BStr)] out string? Value);

		[DispId(16)]
		bool IsUISupported([In, MarshalAs(UnmanagedType.BStr)] string TypeOfUI, [In, MarshalAs(UnmanagedType.Struct)] object? ExtraData = null);

		[DispId(17)]
		void DisplayUI([In] int hWndParent, [In, MarshalAs(UnmanagedType.BStr)] string Title, [In, MarshalAs(UnmanagedType.BStr)] string TypeOfUI, [In, MarshalAs(UnmanagedType.Struct)] object? ExtraData = null);

		[DispId(18)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechObjectTokens? GetRecognizers([In, MarshalAs(UnmanagedType.BStr)] string RequiredAttributes = "", [In, MarshalAs(UnmanagedType.BStr)] string OptionalAttributes = "");

		[DispId(19)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechObjectTokens? GetAudioInputs([In, MarshalAs(UnmanagedType.BStr)] string RequiredAttributes = "", [In, MarshalAs(UnmanagedType.BStr)] string OptionalAttributes = "");

		[DispId(20)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechObjectTokens? GetProfiles([In, MarshalAs(UnmanagedType.BStr)] string RequiredAttributes = "", [In, MarshalAs(UnmanagedType.BStr)] string OptionalAttributes = "");
	}

	[ComImport, Guid("BFF9E781-53EC-484E-BB8A-0E1B5551E35C")]
	public interface ISpeechRecognizerStatus
	{
		[DispId(1)]
		ISpeechAudioStatus? AudioStatus
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		object CurrentStreamPosition
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(3)]
		int CurrentStreamNumber
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		int NumberOfActiveRules
		{
			[DispId(4)]
			get;
		}

		[DispId(5)]
		string? ClsidEngine
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(6)]
		object SupportedLanguages
		{
			[DispId(6)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}
	}

	[ComImport, Guid("B6D6F79F-2158-4E50-B5BC-9A9CCD852A09")]
	public interface ISpeechRecoGrammar
	{
		[DispId(1)]
		object Id
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(2)]
		ISpeechRecoContext? RecoContext
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(3)]
		SpeechGrammarState State
		{
			[DispId(3)]
			get;
			[DispId(3)]
			[param: In]
			set;
		}

		[DispId(4)]
		ISpeechGrammarRules? Rules
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(5)]
		void Reset([In] int NewLanguage = 0);

		[DispId(7)]
		void CmdLoadFromFile([In, MarshalAs(UnmanagedType.BStr)] string FileName, [In] SpeechLoadOption LoadOption = SpeechLoadOption.SLOStatic);

		[DispId(8)]
		void CmdLoadFromObject([In, MarshalAs(UnmanagedType.BStr)] string ClassId, [In, MarshalAs(UnmanagedType.BStr)] string GrammarName, [In] SpeechLoadOption LoadOption = SpeechLoadOption.SLOStatic);

		[DispId(9)]
		void CmdLoadFromResource([In] int hModule, [In, MarshalAs(UnmanagedType.Struct)] object ResourceName, [In, MarshalAs(UnmanagedType.Struct)] object ResourceType, [In] int LanguageId, [In] SpeechLoadOption LoadOption = SpeechLoadOption.SLOStatic);

		[DispId(10)]
		void CmdLoadFromMemory([In, MarshalAs(UnmanagedType.Struct)] object GrammarData, [In] SpeechLoadOption LoadOption = SpeechLoadOption.SLOStatic);

		[DispId(11)]
		void CmdLoadFromProprietaryGrammar([In, MarshalAs(UnmanagedType.BStr)] string ProprietaryGuid, [In, MarshalAs(UnmanagedType.BStr)] string ProprietaryString, [In, MarshalAs(UnmanagedType.Struct)] object ProprietaryData, [In] SpeechLoadOption LoadOption = SpeechLoadOption.SLOStatic);

		[DispId(12)]
		void CmdSetRuleState([In, MarshalAs(UnmanagedType.BStr)] string Name, [In] SpeechRuleState State);

		[DispId(13)]
		void CmdSetRuleIdState([In] int RuleId, [In] SpeechRuleState State);

		[DispId(14)]
		void DictationLoad([In, MarshalAs(UnmanagedType.BStr)] string TopicName = "", [In] SpeechLoadOption LoadOption = SpeechLoadOption.SLOStatic);

		[DispId(15)]
		void DictationUnload();

		[DispId(16)]
		void DictationSetState([In] SpeechRuleState State);

		[DispId(17)]
		void SetWordSequenceData([In, MarshalAs(UnmanagedType.BStr)] string Text, [In] int TextLength, [In, MarshalAs(UnmanagedType.Interface)] ISpeechTextSelectionInformation? Info);

		[DispId(18)]
		void SetTextSelection([In, MarshalAs(UnmanagedType.Interface)] ISpeechTextSelectionInformation? Info);

		[DispId(19)]
		SpeechWordPronounceable IsPronounceable([In, MarshalAs(UnmanagedType.BStr)] string Word);
	}

	[ComImport, Guid("ED2879CF-CED9-4EE6-A534-DE0191D5468D")]
	public interface ISpeechRecoResult
	{
		[DispId(1)]
		ISpeechRecoContext? RecoContext
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		ISpeechRecoResultTimes? Times
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(3)]
		ISpeechAudioFormat? AudioFormat
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(3)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		[DispId(4)]
		ISpeechPhraseInfo? PhraseInfo
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(5)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechPhraseAlternates? Alternates([In] int RequestCount, [In] int StartElement = 0, [In] int Elements = -1);

		[DispId(6)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechMemoryStream? Audio([In] int StartElement = 0, [In] int Elements = -1);

		[DispId(7)]
		int SpeakAudio([In] int StartElement = 0, [In] int Elements = -1, [In] SpeechVoiceSpeakFlags Flags = SpeechVoiceSpeakFlags.SVSFDefault);

		[DispId(8)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object SaveToMemory();

		[DispId(9)]
		void DiscardResultInfo([In] SpeechDiscardType ValueTypes);
	}

	[ComImport, Guid("8E0A246D-D3C8-45DE-8657-04290C458C3C")]
	public interface ISpeechRecoResult2 : ISpeechRecoResult
	{
		[DispId(1)]
		new ISpeechRecoContext? RecoContext
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		new ISpeechRecoResultTimes? Times
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(3)]
		new ISpeechAudioFormat? AudioFormat
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(3)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		[DispId(4)]
		new ISpeechPhraseInfo? PhraseInfo
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(5)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new ISpeechPhraseAlternates? Alternates([In] int RequestCount, [In] int StartElement = 0, [In] int Elements = -1);

		[DispId(6)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new ISpeechMemoryStream? Audio([In] int StartElement = 0, [In] int Elements = -1);

		[DispId(7)]
		new int SpeakAudio([In] int StartElement = 0, [In] int Elements = -1, [In] SpeechVoiceSpeakFlags Flags = SpeechVoiceSpeakFlags.SVSFDefault);

		[DispId(8)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object SaveToMemory();

		[DispId(9)]
		new void DiscardResultInfo([In] SpeechDiscardType ValueTypes);

		[DispId(12)]
		void SetTextFeedback([In, MarshalAs(UnmanagedType.BStr)] string Feedback, [In] bool WasSuccessful);
	}

	[ComImport, Guid("6D60EB64-ACED-40A6-BBF3-4E557F71DEE2")]
	public interface ISpeechRecoResultDispatch
	{
		[DispId(1)]
		ISpeechRecoContext? RecoContext
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		ISpeechRecoResultTimes? Times
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(3)]
		ISpeechAudioFormat? AudioFormat
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(3)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		[DispId(4)]
		ISpeechPhraseInfo? PhraseInfo
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(5)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechPhraseAlternates? Alternates([In] int RequestCount, [In] int StartElement = 0, [In] int Elements = -1);

		[DispId(6)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechMemoryStream? Audio([In] int StartElement = 0, [In] int Elements = -1);

		[DispId(7)]
		int SpeakAudio([In] int StartElement = 0, [In] int Elements = -1, [In] SpeechVoiceSpeakFlags Flags = SpeechVoiceSpeakFlags.SVSFDefault);

		[DispId(8)]
		[return: MarshalAs(UnmanagedType.Struct)]
		object SaveToMemory();

		[DispId(9)]
		void DiscardResultInfo([In] SpeechDiscardType ValueTypes);

		[DispId(10)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string? GetXMLResult([In] SPXMLRESULTOPTIONS Options);

		[DispId(11)]
		bool GetXMLErrorInfo(out int LineNumber, [MarshalAs(UnmanagedType.BStr)] out string? ScriptLine,
			[MarshalAs(UnmanagedType.BStr)] out string? Source, [MarshalAs(UnmanagedType.BStr)] out string? Description,
			out HRESULT ResultCode);

		[DispId(12)]
		void SetTextFeedback([In, MarshalAs(UnmanagedType.BStr)] string Feedback, [In] bool WasSuccessful);
	}

	[ComImport, Guid("62B3B8FB-F6E7-41BE-BDCB-056B1C29EFC0")]
	public interface ISpeechRecoResultTimes
	{
		[DispId(1)]
		object StreamTime
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(2)]
		object Length
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}

		[DispId(3)]
		int TickCount
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		object OffsetFromStart
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
		}
	}

	[ComImport, Guid("B9AC5783-FCD0-4B21-B119-B4F8DA8FD2C3")]
	public interface ISpeechResourceLoader
	{
		[DispId(1)]
		void LoadResource([In, MarshalAs(UnmanagedType.BStr)] string bstrResourceUri, [In] bool fAlwaysReload, [MarshalAs(UnmanagedType.IUnknown)] out object pStream, [MarshalAs(UnmanagedType.BStr)] out string pbstrMIMEType, out bool pfModified, [MarshalAs(UnmanagedType.BStr)] out string pbstrRedirectUrl);

		[DispId(2)]
		void GetLocalCopy([In, MarshalAs(UnmanagedType.BStr)] string bstrResourceUri, [MarshalAs(UnmanagedType.BStr)] out string pbstrLocalPath, [MarshalAs(UnmanagedType.BStr)] out string pbstrMIMEType, [MarshalAs(UnmanagedType.BStr)] out string pbstrRedirectUrl);

		[DispId(3)]
		void ReleaseLocalCopy([In, MarshalAs(UnmanagedType.BStr)] string pbstrLocalPath);
	}

	[ComImport, Guid("3B9C7E7A-6EEE-4DED-9092-11657279ADBE"), CoClass(typeof(SpTextSelectionInformation))]
	public interface ISpeechTextSelectionInformation
	{
		[DispId(1)]
		int ActiveOffset
		{
			[DispId(1)]
			get;
			[DispId(1)]
			[param: In]
			set;
		}

		[DispId(2)]
		int ActiveLength
		{
			[DispId(2)]
			get;
			[DispId(2)]
			[param: In]
			set;
		}

		[DispId(3)]
		int SelectionOffset
		{
			[DispId(3)]
			get;
			[DispId(3)]
			[param: In]
			set;
		}

		[DispId(4)]
		int SelectionLength
		{
			[DispId(4)]
			get;
			[DispId(4)]
			[param: In]
			set;
		}
	}

	[ComImport, Guid("269316D8-57BD-11D2-9EEE-00C04F797396"), CoClass(typeof(SpVoice))]
	public interface ISpeechVoice
	{
		[DispId(1)]
		ISpeechVoiceStatus? Status
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		ISpeechObjectToken? Voice
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(2)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		[DispId(3)]
		ISpeechObjectToken? AudioOutput
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(3)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		[DispId(4)]
		ISpeechBaseStream? AudioOutputStream
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(4)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		[DispId(5)]
		int Rate
		{
			[DispId(5)]
			get;
			[DispId(5)]
			[param: In]
			set;
		}

		[DispId(6)]
		int Volume
		{
			[DispId(6)]
			get;
			[DispId(6)]
			[param: In]
			set;
		}

		[DispId(7)]
		bool AllowAudioOutputFormatChangesOnNextSet
		{
			[DispId(7)]
			get;
			[DispId(7)]
			[param: In]
			set;
		}

		[DispId(8)]
		SpeechVoiceEvents EventInterests
		{
			[DispId(8)]
			get;
			[DispId(8)]
			[param: In]
			set;
		}

		[DispId(9)]
		SpeechVoicePriority Priority
		{
			[DispId(9)]
			get;
			[DispId(9)]
			[param: In]
			set;
		}

		[DispId(10)]
		SpeechVoiceEvents AlertBoundary
		{
			[DispId(10)]
			get;
			[DispId(10)]
			[param: In]
			set;
		}

		[DispId(11)]
		int SynchronousSpeakTimeout
		{
			[DispId(11)]
			get;
			[DispId(11)]
			[param: In]
			set;
		}

		[DispId(12)]
		int Speak([In, MarshalAs(UnmanagedType.BStr)] string Text, [In] SpeechVoiceSpeakFlags Flags = SpeechVoiceSpeakFlags.SVSFDefault);

		[DispId(13)]
		int SpeakStream([In, MarshalAs(UnmanagedType.Interface)] ISpeechBaseStream? Stream, [In] SpeechVoiceSpeakFlags Flags = SpeechVoiceSpeakFlags.SVSFDefault);

		[DispId(14)]
		void Pause();

		[DispId(15)]
		void Resume();

		[DispId(16)]
		int Skip([In, MarshalAs(UnmanagedType.BStr)] string Type, [In] int NumItems);

		[DispId(17)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechObjectTokens? GetVoices([In, MarshalAs(UnmanagedType.BStr)] string RequiredAttributes = "", [In, MarshalAs(UnmanagedType.BStr)] string OptionalAttributes = "");

		[DispId(18)]
		[return: MarshalAs(UnmanagedType.Interface)]
		ISpeechObjectTokens? GetAudioOutputs([In, MarshalAs(UnmanagedType.BStr)] string RequiredAttributes = "", [In, MarshalAs(UnmanagedType.BStr)] string OptionalAttributes = "");

		[DispId(19)]
		bool WaitUntilDone([In] int msTimeout);

		[DispId(20)]
		int SpeakCompleteEvent();

		[DispId(21)]
		bool IsUISupported([In, MarshalAs(UnmanagedType.BStr)] string TypeOfUI, [In, MarshalAs(UnmanagedType.Struct)] object? ExtraData = null);

		[DispId(22)]
		void DisplayUI([In] int hWndParent, [In, MarshalAs(UnmanagedType.BStr)] string Title, [In, MarshalAs(UnmanagedType.BStr)] string TypeOfUI, [In, MarshalAs(UnmanagedType.Struct)] object? ExtraData = null);
	}

	[ComImport, Guid("8BE47B07-57F6-11D2-9EEE-00C04F797396")]
	public interface ISpeechVoiceStatus
	{
		[DispId(1)]
		int CurrentStreamNumber
		{
			[DispId(1)]
			get;
		}

		[DispId(2)]
		int LastStreamNumberQueued
		{
			[DispId(2)]
			get;
		}

		[DispId(3)]
		HRESULT LastHResult
		{
			[DispId(3)]
			get;
		}

		[DispId(4)]
		SpeechRunState RunningState
		{
			[DispId(4)]
			get;
		}

		[DispId(5)]
		int InputWordPosition
		{
			[DispId(5)]
			get;
		}

		[DispId(6)]
		int InputWordLength
		{
			[DispId(6)]
			get;
		}

		[DispId(7)]
		int InputSentencePosition
		{
			[DispId(7)]
			get;
		}

		[DispId(8)]
		int InputSentenceLength
		{
			[DispId(8)]
			get;
		}

		[DispId(9)]
		string? LastBookmark
		{
			[DispId(9)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[DispId(10)]
		int LastBookmarkId
		{
			[DispId(10)]
			get;
		}

		[DispId(11)]
		short PhonemeId
		{
			[DispId(11)]
			get;
		}

		[DispId(12)]
		short VisemeId
		{
			[DispId(12)]
			get;
		}
	}

	[ComImport, Guid("7A1EF0D5-1581-4741-88E4-209A49F11A10"), CoClass(typeof(SpWaveFormatEx))]
	public interface ISpeechWaveFormatEx
	{
		[DispId(1)]
		short FormatTag
		{
			[DispId(1)]
			get;
			[DispId(1)]
			[param: In]
			set;
		}

		[DispId(2)]
		short Channels
		{
			[DispId(2)]
			get;
			[DispId(2)]
			[param: In]
			set;
		}

		[DispId(3)]
		int SamplesPerSec
		{
			[DispId(3)]
			get;
			[DispId(3)]
			[param: In]
			set;
		}

		[DispId(4)]
		int AvgBytesPerSec
		{
			[DispId(4)]
			get;
			[DispId(4)]
			[param: In]
			set;
		}

		[DispId(5)]
		short BlockAlign
		{
			[DispId(5)]
			get;
			[DispId(5)]
			[param: In]
			set;
		}

		[DispId(6)]
		short BitsPerSample
		{
			[DispId(6)]
			get;
			[DispId(6)]
			[param: In]
			set;
		}

		[DispId(7)]
		object ExtraData
		{
			[DispId(7)]
			[return: MarshalAs(UnmanagedType.Struct)]
			get;
			[DispId(7)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Struct)]
			set;
		}
	}

	[ComImport, Guid("AAEC54AF-8F85-4924-944D-B79D39D72E19")]
	public interface ISpeechXMLRecoResult : ISpeechRecoResult
	{
		[DispId(1)]
		new ISpeechRecoContext? RecoContext
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(2)]
		new ISpeechRecoResultTimes? Times
		{
			[DispId(2)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(3)]
		new ISpeechAudioFormat? AudioFormat
		{
			[DispId(3)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
			[DispId(3)]
			[param: In]
			[param: MarshalAs(UnmanagedType.Interface)]
			set;
		}

		[DispId(4)]
		new ISpeechPhraseInfo? PhraseInfo
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[DispId(5)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new ISpeechPhraseAlternates? Alternates([In] int RequestCount, [In] int StartElement = 0, [In] int Elements = -1);

		[DispId(6)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new ISpeechMemoryStream? Audio([In] int StartElement = 0, [In] int Elements = -1);

		[DispId(7)]
		new int SpeakAudio([In] int StartElement = 0, [In] int Elements = -1, [In] SpeechVoiceSpeakFlags Flags = SpeechVoiceSpeakFlags.SVSFDefault);

		[DispId(8)]
		[return: MarshalAs(UnmanagedType.Struct)]
		new object SaveToMemory();

		[DispId(9)]
		new void DiscardResultInfo([In] SpeechDiscardType ValueTypes);

		[DispId(10)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string? GetXMLResult([In] SPXMLRESULTOPTIONS Options);

		[DispId(11)]
		bool GetXMLErrorInfo(out int LineNumber, [MarshalAs(UnmanagedType.BStr)] out string? ScriptLine,
			[MarshalAs(UnmanagedType.BStr)] out string? Source, [MarshalAs(UnmanagedType.BStr)] out string? Description, out int ResultCode);
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("BE7A9CC9-5F9E-11D2-960F-00C04F8EE628")]
	public interface ISpEventSink
	{
		[PreserveSig]
		HRESULT AddEvents([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SPEVENT[]? pEventArray, [In] uint ulCount);

		[PreserveSig]
		HRESULT GetEventInterest(out ulong pullEventInterest);
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("BE7A9CCE-5F9E-11D2-960F-00C04F8EE628")]
	public interface ISpEventSource : ISpNotifySource
	{
		new void SetNotifySink([In, MarshalAs(UnmanagedType.Interface)] ISpNotifySink pNotifySink);

		new void SetNotifyWindowMessage([In] HWND hWnd, [In] uint Msg, [In] IntPtr wParam, [In] IntPtr lParam);

		new void SetNotifyCallbackFunction(SPNOTIFYCALLBACK pfnCallback, [In] IntPtr wParam, [In] IntPtr lParam);

		new void SetNotifyCallbackInterface([In, MarshalAs(UnmanagedType.Interface)] ISpNotifyCallback pSpCallback, [In] IntPtr wParam, [In] IntPtr lParam);

		new void SetNotifyWin32Event();

		[PreserveSig]
		new HRESULT WaitForNotifyEvent([In] uint dwMilliseconds);

		new HEVENT GetNotifyEventHandle();

		void SetInterest([In] SPEVENTENUM ullEventInterest, [In] SPEVENTENUM ullQueuedInterest);

		[PreserveSig]
		HRESULT GetEvents([In] uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SPEVENT[]? pEventArray, out uint pulFetched);

		void GetInfo(out SPEVENTSOURCEINFO pInfo);
	}

	/// <summary>
	/// This interface details the SAPI context-free grammar (CFG) backend compiler. These methods can be used to programmatically construct
	/// and modify grammars.
	/// </summary>
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("8137828F-591A-4A42-BE58-49EA7EBAAC68")]
	public interface ISpGrammarBuilder
	{
		/// <summary>
		/// ISpGrammarBuilder::ResetGrammar clears all grammar rules (un-defines them) and resets the grammar's language to NewLanguage. The
		/// state handles for this grammar are no longer valid after this point.
		/// </summary>
		/// <param name="NewLanguage">Language identifier associated with the grammar rule.</param>
		void ResetGrammar([In] LANGID NewLanguage);

		/// <summary>ISpGrammarBuilder::GetRule retrieves grammar rule's initial state.</summary>
		/// <param name="pszRuleName">The grammar rule name. If NULL, no search is made for the name.</param>
		/// <param name="dwRuleId">Grammar rule identifier. If zero, no search is made for the rule ID.</param>
		/// <param name="dwAttributes">
		/// Grammar rule attributes for the new rule created. Ignored if the rule already exists. Must be of type SPCFGRULEATTRIBUTES. Values
		/// may be combined to allow for multiple attributes.
		/// </param>
		/// <param name="fCreateIfNotExist">
		/// Boolean indicating that the grammar rule is to be created if one does not currently exist. TRUE allows the creation; FALSE does not.
		/// </param>
		/// <param name="phInitialState">The initial state of the rule. May be NULL.</param>
		/// <remarks>
		/// Either the rule name or ID must be provided (the other unused parameter can either be NULL or zero). If both a grammar rule name
		/// and identifier are provided, they both must match in order for this call to succeed. If the grammar rule does not already exist
		/// and fCreateIfNotExists is true, the grammar rule is defined. Otherwise this call will return an error.
		/// </remarks>
		void GetRule([In, MarshalAs(UnmanagedType.LPWStr)] string? pszRuleName, [In] uint dwRuleId, [In] SPCFGRULEATTRIBUTES dwAttributes,
			[In, MarshalAs(UnmanagedType.Bool)] bool fCreateIfNotExist, out SPSTATEHANDLE phInitialState);

		/// <summary>ISpGrammarBuilder::ClearRule removes all of the grammar rule information except for the rule's initial state handle.</summary>
		/// <param name="hState">
		/// Handle to the any of the states in the grammar rule to be cleared. Only the rule's initial state handle is still valid.
		/// </param>
		void ClearRule([In] SPSTATEHANDLE hState);

		/// <summary>ISpGrammarBuilder::CreateNewState creates a new state in the same grammar rule as hState.</summary>
		/// <param name="hState">Handle to any existing state in the grammar rule.</param>
		/// <param name="phState">Address of the state handle for a new state in the same grammar rule.</param>
		void CreateNewState([In] SPSTATEHANDLE hState, out SPSTATEHANDLE phState);

		/// <summary>ISpGrammarBuilder::AddWordTransition adds a word or a sequence of words to the grammar.</summary>
		/// <param name="hFromState">Handle of the state from which the arc (or sequence of arcs in the case of multiple words) should originate.</param>
		/// <param name="hToState">
		/// Handle of the state where the arc (or sequence of arcs) should terminate. If NULL, the final arc will be to the (implicit)
		/// terminal node of this grammar rule.
		/// </param>
		/// <param name="psz">A string containing the word or words to be added. If psz is NULL, an epsilon arc will be added.</param>
		/// <param name="pszSeparators">
		/// A string containing the transition word separation characters.
		/// <para>
		/// psz points to a single word if pszSeperators is NULL, or else pszSeperators specifies the valid separator characters.This
		/// parameter may not contain a forward slash ("/") as that is used for the complex word format.
		/// </para>
		/// </param>
		/// <param name="eWordType">
		/// The SPGRAMMARWORDTYPE enumeration that specifies the word type. SAPI 5.1 supports only SPWT_LEXICAL. SAPI 5.3 supports
		/// SPWT_LEXICAL and SPWT_LEXICAL_NO_SPECIAL_CHARS. If neither of these are specified, the method returns E_INVALIDARG.
		/// </param>
		/// <param name="Weight">Value specifying the arc's relative weight in case there are multiple arcs originating from hFromState.</param>
		/// <param name="pPropInfo">
		/// The SPPROPERTYINFO structure containing property name and value information that is associated with this arc or sequence of arcs.
		/// </param>
		void AddWordTransition([In] SPSTATEHANDLE hFromState, [In] SPSTATEHANDLE hToState, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? psz, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszSeparators,
			[In] SPGRAMMARWORDTYPE eWordType, [In] float Weight, in SPPROPERTYINFO pPropInfo);

		/// <summary>ISpGrammarBuilder::AddRuleTransition adds a rule (reference) transition from one grammar rule to another.</summary>
		/// <param name="hFromState">Handle of the state from which the arc should originate.</param>
		/// <param name="hToState">
		/// Handle of the state where the arc should terminate. If NULL, the final arc will be to the (implicit) terminal node of this
		/// grammar rule.
		/// </param>
		/// <param name="hRule">
		/// <para>
		/// [in] Handle of any state of the rule to be called with this transition. Get the hRule using the ISpGrammarBuilder::GetRule()
		/// call. To refer to a rule in another grammar, and "import" that rule by calling ISpGrammarBuilder::GetRule( ... , SPRAF_Import,
		/// TRUE /*fCreatIfNotExist*/, ...).
		/// </para>
		/// <para>hRule can also be one of the following special transition handles:</para>
		/// <list type="table">
		/// <item>
		/// <description>Transition handle</description>
		/// <description>Description</description>
		/// </item>
		/// <item>
		/// <description>SPRULETRANS_WILDCARD</description>
		/// <description>&lt;WILDCARD&gt; transition</description>
		/// </item>
		/// <item>
		/// <description>SPRULETRANS_DICTATION</description>
		/// <description>&lt;DICTATION&gt; single word from dictation</description>
		/// </item>
		/// <item>
		/// <description>SPRULETRANS_TEXTBUFFER</description>
		/// <description>&lt;TEXTBUFFER&gt; transition</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Weight">[in] Value specifying the arc's relative weight in case there are multiple arcs originating from hFromState.</param>
		/// <param name="pPropInfo">
		/// [in] The SPPROPERTYINFO structure containing property name and value information that is associated with this arc.
		/// </param>
		void AddRuleTransition([In] SPSTATEHANDLE hFromState, [In] SPSTATEHANDLE hToState, [In] SPSTATEHANDLE hRule, [In] float Weight,
			in SPPROPERTYINFO pPropInfo);

		/// <summary>
		/// ISpGrammarBuilder::AddResource adds a resource (name and string value) to the grammar rule specified in hRuleState. The resource
		/// can be queried by a rule interpreter using ISpCFGInterpreterSite::GetResourceValue().
		/// </summary>
		/// <param name="hRuleState">[in] Handle of a state in the rule to which the resource is to be added.</param>
		/// <param name="pszResourceName">[in] Address of a null-terminated string specifying the resource name.</param>
		/// <param name="pszResourceValue">[in] Address of a null-terminated string specifying the resource value.</param>
		void AddResource([In] SPSTATEHANDLE hRuleState, [In, MarshalAs(UnmanagedType.LPWStr)] string pszResourceName,
			[In, MarshalAs(UnmanagedType.LPWStr)] string? pszResourceValue = null);

		/// <summary>
		/// <para>
		/// ISpGrammarBuilder::Commit performs consistency checks of the grammar structure, creates the serialized format, saves the grammar
		/// structure, or reloads the grammar structure.
		/// </para>
		/// <para>
		/// The grammar structure may be saved it to the stream provided by SetSaveObjects, or reloaded into the SR engine. Commit must be
		/// called before any changes to the grammar can take effect.
		/// </para>
		/// </summary>
		/// <param name="dwReserved">Reserved. Must be zero.</param>
		void Commit([In] uint dwReserved = 0);
	}

	/// <summary>
	/// The ISpLexicon interface provides a uniform way for applications and engines to access the user lexicon, application lexicon, and
	/// engine private lexicons.
	/// </summary>
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("DA41A7C2-5383-4DB2-916B-6C1719E3DB58"), CoClass(typeof(SpCompressedLexicon))]
	public interface ISpLexicon
	{
		/// <summary><b>ISpLexicon::GetPronunciations</b> gets pronunciations and parts of speech for a word.</summary>
		/// <param name="pszWord">[in] Pointer to a null-terminated text string as a search keyword. Length must be equal to less than <c>SP_MAX_WORD_LENGTH</c>.</param>
		/// <param name="LangId">[in] The language ID of the word. May be zero to indicate that the word can be of any LANGID.</param>
		/// <param name="dwFlags">[in] Bitwise flags of type SPLEXICONTYPE indicating that the lexicons searched for this word.</param>
		/// <param name="pWordPronunciationList">[in, out] Pointer to SPWORDPRONUNCIATIONLIST structure in which the pronunciations and parts of speech are returned.</param>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms717909(v=vs.85)
		void GetPronunciations([In, MarshalAs(UnmanagedType.LPWStr)] string pszWord, [In] LANGID LangId, [In] SPLEXICONTYPE dwFlags,
			out SPWORDPRONUNCIATIONLIST pWordPronunciationList);

		/// <summary>ISpLexicon::AddPronunciation adds word pronunciations and parts of speech (POS) to the user lexicon.</summary>
		/// <param name="pszWord">[in] The word to add.</param>
		/// <param name="LangId">
		/// [in] The language ID of the word. The speech user default will be used if LANGID is omitted. Length must be equal to or less than SP_MAX_WORD_LENGTH.
		/// </param>
		/// <param name="ePartOfSpeech">[in] The part of speech of type SPPARTOFSPEECH.</param>
		/// <param name="pszPronunciation">
		/// [in] Null-terminated pronunciation of the word in the NUM phone set. Multiple pronunciations may be added for a single word. The
		/// length must be equal to or less than <see cref="SP_MAX_PRON_LENGTH"/>. pszPronunciation may be NULL.
		/// </param>
		void AddPronunciation([In, MarshalAs(UnmanagedType.LPWStr)] string pszWord, [In] LANGID LangId, [In] SPPARTOFSPEECH ePartOfSpeech,
			[In, MarshalAs(UnmanagedType.LPWStr)] string? pszPronunciation = null);

		/// <summary>ISpLexicon::RemovePronunciation removes a word and all its pronunciations from a user lexicon.</summary>
		/// <param name="pszWord">[in] The word to remove.</param>
		/// <param name="LangId">
		/// [in] The language ID of the word. The speech user default will be used if LANGID is omitted.
		/// </param>
		/// <param name="ePartOfSpeech">[in] The part of speech of type SPPARTOFSPEECH.</param>
		/// <param name="pszPronunciation">
		/// [in] Null-terminated pronunciation of the word in the NUM phone set. Multiple pronunciations may be added for a single word. The
		/// length must be equal to or less than <see cref="SP_MAX_PRON_LENGTH"/>. pszPronunciation may be NULL.
		/// </param>
		void RemovePronunciation([In, MarshalAs(UnmanagedType.LPWStr)] string pszWord, [In] LANGID LangId, [In] SPPARTOFSPEECH ePartOfSpeech,
			[In, MarshalAs(UnmanagedType.LPWStr)] string? pszPronunciation = null);

		/// <summary>
		///   <para>
		///     <strong>ISpLexicon::GetGeneration</strong> passes back the generation ID for a word.</para>
		///   <para>Passes back the current generation ID of the user lexicon. It is used to detect the changes in the user lexicon because each change in the user lexicon (add/remove a word or install/uninstall an application lexicon) will increment the generation ID.</para>
		/// </summary>
		/// <returns>The generation ID. This is a relative count of how many times the custom lexicons have changed.</returns>
		uint GetGeneration();

		/// <summary>
		/// <strong>ISpLexicon::GetGenerationChange</strong> passes back a list of words which have changed between the current and a
		/// specified generation.
		/// </summary>
		/// <param name="dwFlags">
		/// [in] The lexicon category of type SPLEXICONTYPE. Currently it must be zero for the SpLexicon (container lexicon) object, and must
		/// be the correct flag for the type of SpUnCompressedLexicon object (either eLEXTYPE_USER or eLEXTYPE_APP).
		/// </param>
		/// <param name="pdwGeneration">
		/// [in, out] The generation ID of client when passed in. The current generation ID is passed back on successful completion of the call.
		/// </param>
		/// <param name="pWordList">
		/// [in, out] The buffer containing the word list and its related information. This must be initialized (memset to zero) before first
		/// use. If pWordList is successfully returned, CoTaskMemFree must be used to free the list (pWordList-&gt;pvBuffer) when no longer needed.
		/// </param>
		/// <remarks>
		/// An application can determine what has been done to a lexicon over a given period of time using ISpLexicon::GetGenerationChange
		/// and ISpLexicon::GetGeneration. That is, it can back out of changes it has made due to a user cancel. To do this, before it starts
		/// modifying the lexicon, the application would call ISpLexicon::GetGeneration and store the generation ID. Later, when the
		/// application wants to see what words in the lexicon it has modified, it would call ISpLexicon::GetGenerationChanges with the
		/// stored ID. This can only be done for small changes because, past a certain point, SPERR_LEX_VERY_OUT_OF_SYNC will be returned and
		/// the change history will not be available from the original generation.
		/// </remarks>
		[PreserveSig]
		HRESULT GetGenerationChange([In] SPLEXICONTYPE dwFlags, out uint pdwGeneration, out SPWORDLIST pWordList);

		/// <summary><b>ISpLexicon::GetWords</b> gets a list of all words in the lexicon.</summary>
		/// <param name="dwFlags">[in] Bitwise flags of type <c>SPLEXICONTYPE</c> from which words are to be retrieved.</param>
		/// <param name="pdwGeneration">[out] The current generation ID of the custom lexicon.</param>
		/// <param name="pdwCookie">
		/// [in, out] Cookie passed back by this call. It should subsequently be passed back in to get more data. If the call returns
		/// S_FALSE, data is remaining and GetWords should be called again. The initial value of the cookie passed in must be zero or
		/// pdwCookie will be a NULL pointer. NULL pdwCookie indicates the method should return all words contained in the lexicon at once.
		/// If it cannot, SP_LEX_REQUIRES_COOKIE is returned instead.
		/// </param>
		/// <param name="pWordList">
		/// [in, out] The buffer containing the word list and its related information. If pWordList is successfully returned, CoTaskMemFree
		/// must be used to free the list (pWordList-&gt;pvBuffer) when no longer needed.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// </item>
		/// <item>
		/// <description>S_FALSE</description>
		/// </item>
		/// <item>
		/// <description>SPERR_LEX_REQUIRES_COOKIE</description>
		/// </item>
		/// <item>
		/// <description>E_POINTER</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// </item>
		/// <item>
		/// <description>SPERR_UNINITIALIZED</description>
		/// </item>
		/// <item>
		/// <description>FAILED(hr)</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To retrieve all of the words in a lexicon, this method typically must be called repeatedly with the cookie (initially set to zero
		/// before the first call) until S_OK is returned. S_FALSE is returned to indicate that additional words remain in the lexicon.
		/// Optionally, the cookie pointer passed in may be NULL, which indicates that the application is asking to receive all of the words
		/// at one time. The lexicon is not required to support this and may return the error SP_LEX_REQUIRES_COOKIE. The <c>SpLexicon</c>
		/// object (container lexicon) requires a cookie currently.
		/// </para>
		/// <para>
		/// Between calls to GetWords it is possible for the GenerationId out parameter to change as the lexicon is updated. The caller of
		/// this method should retain the value of GenerationId that is passed out from the first call to GetWords (when the cookie is
		/// initially 0). When pdwCookie is nonnull and the cookie value is nonzero, the application should completely ignore the value of
		/// GenerationId passed out when GetWords returns.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ee450828(v=vs.85)
		[PreserveSig]
		HRESULT GetWords([In] SPLEXICONTYPE dwFlags, out uint pdwGeneration, out uint pdwCookie, out SPWORDLIST pWordList);
	}

	[ComImport, Guid("15806F6E-1D70-4B48-98E6-3B1A007509AB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpMMSysAudio : ISpAudio
	{
		/// <inheritdoc/>
		new void Read(byte[] pv, int cb, nint pcbRead);

		/// <inheritdoc/>
		new void Write(byte[] pv, int cb, nint pcbWritten);

		/// <inheritdoc/>
		new void Seek(long dlibMove, int dwOrigin, nint plibNewPosition);

		/// <inheritdoc/>
		new void SetSize(long libNewSize);

		/// <inheritdoc/>
		new void CopyTo(IStream pstm, long cb, nint pcbRead, nint pcbWritten);

		/// <inheritdoc/>
		new void Commit(int grfCommitFlags);

		/// <inheritdoc/>
		new void Revert();

		/// <inheritdoc/>
		new void LockRegion(long libOffset, long cb, int dwLockType);

		/// <inheritdoc/>
		new void UnlockRegion(long libOffset, long cb, int dwLockType);

		/// <inheritdoc/>
		new void Stat(out STATSTG pstatstg, int grfStatFlag);

		/// <inheritdoc/>
		new void Clone(out IStream ppstm);

		/// <inheritdoc/>
		new void GetFormat(in Guid pguidFormatId, out SafeCoTaskMemStruct<WAVEFORMATEX> ppCoMemWaveFormatEx);

		/// <summary>Sets the audio state of the speech audio interface.</summary>
		/// <param name="NewState">The new audio state to set. This must be a valid <see cref="SPAUDIOSTATE"/> value.</param>
		/// <param name="ullReserved">Reserved for future use. The default value is 0.</param>
		new void SetState([In] SPAUDIOSTATE NewState, [In] ulong ullReserved = 0);

		/// <summary>Sets the format of the audio device.</summary>
		/// <param name="rguidFmtId">
		/// The REFGUID for the format to set. Typically this will be SPDFID_WaveFormatEx. This is required for the SAPI multimedia objects.
		/// </param>
		/// <param name="pWaveFormatEx">Address of the WAVEFORMATEX structure containing the wave file format information.</param>
		new void SetFormat(in Guid rguidFmtId, in WAVEFORMATEX pWaveFormatEx);

		/// <summary>Retrieves the current status of the audio device.</summary>
		/// <returns>An SPAUDIOSTATUS filled with the status details.</returns>
		/// <remarks>
		/// This method determines whether the device is running, stopped, closed, or paused. It also includes various parameters about the
		/// audio object, including how much data is buffered.
		/// </remarks>
		new SPAUDIOSTATUS GetStatus();

		/// <summary>Sets the audio stream buffer information.</summary>
		/// <param name="pBuffInfo">The buffer settings.</param>
		new void SetBufferInfo(in SPAUDIOBUFFERINFO pBuffInfo);

		/// <summary>Passes back the audio stream buffer information.</summary>
		/// <returns>The buffer settings.</returns>
		new SPAUDIOBUFFERINFO GetBufferInfo();

		/// <summary>Gets the default audio format.</summary>
		/// <param name="pFormatId">Pointer to the GUID of the default format.</param>
		/// <param name="ppCoMemWaveFormatEx">
		/// Address of a pointer to the WAVEFORMATEX structure that receives the wave file format information. SAPI allocates the memory for
		/// the WAVEFORMATEX data structure using CoTaskMemAlloc, but it is the caller's responsibility to call CoTaskMemFree on the returned
		/// WAVEFORMATEX pointer.
		/// </param>
		new void GetDefaultFormat(out Guid pFormatId, out StructPointer<WAVEFORMATEX> ppCoMemWaveFormatEx);

		/// <summary>Returns a Win32 event handle that applications can use to wait for status changes in the I/O stream.</summary>
		/// <returns>Win32 event handle that applications can use to wait for status changes in the I/O stream.</returns>
		/// <remarks>
		/// <para>The handle may use one of the various Win32 wait functions, such as WaitForSingleObject or WaitForMultipleObjects.</para>
		/// <para>
		/// For read streams, set the event when there is data available to read and reset it whenever there is no available data. For write
		/// streams, set the event when all of the data has been written to the device, and reset it at any time when there is still data
		/// available to be played.
		/// </para>
		/// <para>
		/// The caller should not close the returned handle, nor should the caller ever use the event handle after calling Release() on the
		/// audio object. The audio device will close the handle on the final release of the object.
		/// </para>
		/// </remarks>
		[PreserveSig]
		new HEVENT EventHandle();

		/// <summary>
		/// Gets the current volume level of the audio device.
		/// <para>The volume level is on a linear scale from zero to 10000.</para>
		/// </summary>
		/// <returns>The current volume level of the audio device.</returns>
		new uint GetVolumeLevel();

		/// <summary>Sets the current volume level. It is on a linear scale from zero to 10000.</summary>
		/// <param name="Level">The new volume level.</param>
		new void SetVolumeLevel([In] uint Level);

		/// <summary>
		/// Gets the audio stream buffer size information. This information is used to determine when the event returned by
		/// ISpAudio::EventHandle is set or reset.
		/// </summary>
		/// <returns>The size information, specified in bytes, that is associated with the audio stream buffer.</returns>
		new uint GetBufferNotifySize();

		/// <summary>Sets the size of the buffer notify.</summary>
		/// <param name="cbSize">Size of the cb.</param>
		new void SetBufferNotifySize([In] uint cbSize);

		void GetDeviceId(out uint puDeviceId);

		void SetDeviceId([In] uint uDeviceId);

		void GetMMHandle(out IntPtr pHandle);

		void GetLineId(out uint puLineId);

		void SetLineId([In] uint uLineId);
	}

	public interface ISpNotifyCallback
	{
		[PreserveSig]
		HRESULT NotifyCallback(IntPtr wParam, IntPtr lParam);
	}

	[ComImport, Guid("259684DC-37C3-11D2-9603-00C04F8EE628"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpNotifySink
	{
		[PreserveSig]
		HRESULT Notify();
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5EFF4AEF-8487-11D2-961C-00C04F8EE628")]
	public interface ISpNotifySource
	{
		void SetNotifySink([In, MarshalAs(UnmanagedType.Interface)] ISpNotifySink? pNotifySink);

		void SetNotifyWindowMessage([In] HWND hWnd, [In] uint Msg, [In] IntPtr wParam, [In] IntPtr lParam);

		void SetNotifyCallbackFunction(SPNOTIFYCALLBACK pfnCallback, [In] IntPtr wParam, [In] IntPtr lParam);

		void SetNotifyCallbackInterface([In, MarshalAs(UnmanagedType.Interface)] ISpNotifyCallback pSpCallback, [In] IntPtr wParam, [In] IntPtr lParam);

		void SetNotifyWin32Event();

		[PreserveSig]
		HRESULT WaitForNotifyEvent([In] uint dwMilliseconds);

		HEVENT GetNotifyEventHandle();
	}

	[ComImport, Guid("ACA16614-5D3D-11D2-960E-00C04F8EE628"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SpNotifyTranslator))]
	public interface ISpNotifyTranslator : ISpNotifySink
	{
		new void Notify();

		void InitWindowMessage([In] HWND hWnd, [In] uint Msg, [In] IntPtr wParam, [In] IntPtr lParam);

		void InitCallback(SPNOTIFYCALLBACK pfnCallback, [In] IntPtr wParam, [In] IntPtr lParam);

		void InitSpNotifyCallback([In, MarshalAs(UnmanagedType.Interface)] ISpNotifyCallback pSpCallback, [In] IntPtr wParam, [In] IntPtr lParam);

		void InitWin32Event([In] HEVENT hEvent, [In, MarshalAs(UnmanagedType.Bool)] bool fCloseHandleOnRelease);

		void Wait([In] uint dwMilliseconds);

		HEVENT GetEventHandle();
	}

	/// <summary>
	/// <para>The ISpObjectToken interface handles object token entries.</para>
	/// <para>
	/// An object token is an object representing a resource that is available on a computer, such as a voice, recognizer, or an audio input
	/// device. A token provides an application a simple way to inspect the various attributes of a resource without having to instantiate
	/// it. The Vendor of a Recognizer, and Gender of a Voice are examples of attributes of resources. An application can enumerate the
	/// various tokens that exist on the computer by using the SpEnumTokens helper function, or by using the
	/// ISpObjectTokenCategory::EnumTokens method to enumerate the tokens of a particular category. Applications can find the best token that
	/// matches certain attributes by using the SpFindBestToken function.
	/// </para>
	/// <para>Conceptually, a token contains the following information:</para>
	/// <list type="bullet">
	/// <item>An identifier that uniquely identifies the object token.</item>
	/// <item>
	/// The language-independent name is the name that should be displayed wherever the name of the token is displayed. The implementer of
	/// the token may also choose to provide a set of language-dependent names in several languages.
	/// </item>
	/// <item>The CLSID used to instantiate the object from the token.</item>
	/// <item>
	/// A set of Attributes, which are the set of queriable values in a token. SAPI provides a mechanism to query for tokens whose attributes
	/// match certain values.
	/// </item>
	/// </list>
	/// <para>A token may also contain the following:</para>
	/// <list type="bullet">
	/// <item>
	/// If a token has user interfaces (UIs), such as the properties of a Recognizer or a wizard to customize a Voice to display, the token
	/// will also contain the CLSID for the COM object used to instantiate each type of UI.
	/// </item>
	/// <item>The set of Files from which SAPI returns the paths to all the associated files for the token.</item>
	/// </list>
	/// <para>
	/// Attributes are null-terminated strings forming a series of key-pair entries. This is usually in the form of definition relationships.
	/// For example, a token may be defined as:
	/// </para>
	/// <para>"vendor=microsoft;language=409;someflag"</para>
	/// <para>In this instance:</para>
	/// <list type="bullet">
	/// <item>"vendor=microsoft" means a string exists under TokenID\attributes with name vendor and value "microsoft";</item>
	/// <item>"language=409" means a string exists under TokenID\attributes with name language and value "409" (representing US English);</item>
	/// <item>
	/// "someflag" means a string exists under TokenID\attributes with name someflag but has no additional information. Sometimes the
	/// presence or absence of the attribute name itself is indicative.
	/// </item>
	/// </list>
	/// </summary>
	[ComImport, Guid("14056589-E16C-11D2-BB90-00C04F8EE6C0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SpObjectToken))]
	public interface ISpObjectToken : ISpDataKey
	{
		/// <summary>Sets the binary data for a token.</summary>
		/// <param name="pszValueName">The registry key value name.</param>
		/// <param name="cbData">Size of the <paramref name="pData"/> parameter.</param>
		/// <param name="pData">Pointer to the buffer containing the information.</param>
		/// <returns>S_OK, E_INVALIDARG, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT SetData([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName, [In] uint cbData, [In] IntPtr pData);

		/// <summary>Gets the binary data for a token.</summary>
		/// <param name="pszValueName">The registry key value name.</param>
		/// <param name="pcbData">Size of the <paramref name="pData"/> parameter.</param>
		/// <param name="pData">Pointer to the buffer receiving the information.</param>
		/// <returns>S_OK, E_INVALIDARG, E_POINTER, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT GetData([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName, in uint pcbData, [Out] IntPtr pData);

		/// <summary>Sets the string value information for a specified token.</summary>
		/// <param name="pszValueName">The registry key value name. If NULL, the default value of the token is used.</param>
		/// <param name="pszValue">The string value to be set for the specified key..</param>
		/// <returns>S_OK, E_INVALIDARG, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT SetStringValue([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszValueName,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszValue);

		/// <summary>Gets the string value information for a specified token.</summary>
		/// <param name="pszValueName">The registry key value name. If NULL, the default value of the token is used.</param>
		/// <param name="ppszValue">The string value for the specified key</param>
		/// <returns>S_OK, E_INVALIDARG, E_POINTER, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT GetStringValue([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszValueName,
			[MarshalAs(UnmanagedType.LPWStr)] out string ppszValue);

		/// <summary>Sets the value information for a specified token.</summary>
		/// <param name="pszValueName">The attribute name.</param>
		/// <param name="dwValue">The attribute key value.</param>
		/// <returns>S_OK, E_INVALIDARG, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT SetDWORD([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName, [In] uint dwValue);

		/// <summary>Gets the value information for a specified token.</summary>
		/// <param name="pszValueName">The attribute name.</param>
		/// <param name="pdwValue">The attribute key value.</param>
		/// <returns>S_OK, E_INVALIDARG, E_POINTER, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT GetDWORD([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName, out uint pdwValue);

		/// <summary>Opens a specified token subkey. Passes back a new object that supports ISpDataKey for the specified subkey.</summary>
		/// <param name="pszSubKeyName">Name of the key to open.</param>
		/// <param name="ppSubKey">Address of a pointer to an ISpDataKey interface.</param>
		/// <returns>S_OK, E_INVALIDARG, E_POINTER, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT OpenKey([In, MarshalAs(UnmanagedType.LPWStr)] string pszSubKeyName, [MarshalAs(UnmanagedType.Interface)] out ISpDataKey ppSubKey);

		/// <summary>
		/// Creates a new token subkey. Returns a new object which supports ISpDataKey for the specified subkey. If the key already exists,
		/// the function will open the existing key instead of overwriting it.
		/// </summary>
		/// <param name="pszSubKey">Name of the key to create.</param>
		/// <param name="ppSubKey">Address of a pointer to an ISpDataKey interface.</param>
		/// <returns>S_OK, E_INVALIDARG, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT CreateKey([In, MarshalAs(UnmanagedType.LPWStr)] string pszSubKey, [MarshalAs(UnmanagedType.Interface)] out ISpDataKey ppSubKey);

		/// <summary>Deletes a specified token key and all its descendants.</summary>
		/// <param name="pszSubKey">The name of the key or subkey to delete.</param>
		/// <returns>S_OK, E_INVALIDARG, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT DeleteKey([In, MarshalAs(UnmanagedType.LPWStr)] string pszSubKey);

		/// <summary>Deletes a named value from the specified token.</summary>
		/// <param name="pszValueName">The value name to be deleted.</param>
		/// <returns></returns>
		[PreserveSig]
		new HRESULT DeleteValue([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName);

		/// <summary>Enumerates the subkeys of the specified token.</summary>
		/// <param name="Index">Value indicating which token in the enumeration sequence to locate.</param>
		/// <param name="ppszSubKeyName">The enumerated key name.</param>
		/// <returns>S_OK, E_INVALIDARG, SPERR_NOT_FOUND, E_OUTOFMEMORY, SPERR_NO_MORE_ITEMS, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT EnumKeys([In] uint Index, [MarshalAs(UnmanagedType.LPWStr)] out string ppszSubKeyName);

		/// <summary>Enumerates the values of the specified token.</summary>
		/// <param name="Index">Value indicating which token in the enumeration sequence to locate.</param>
		/// <param name="ppszValueName">The enumerated values name.</param>
		/// <returns>S_OK, E_INVALIDARG, SPERR_NOT_FOUND, E_OUTOFMEMORY, SPERR_NO_MORE_ITEMS, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT EnumValues([In] uint Index, [MarshalAs(UnmanagedType.LPWStr)] out string ppszValueName);

		[PreserveSig]
		HRESULT SetId([Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszCategoryId, [In, MarshalAs(UnmanagedType.LPWStr)] string pszTokenId,
			[In, MarshalAs(UnmanagedType.Bool)] bool fCreateIfNotExist);

		[PreserveSig]
		HRESULT GetId([MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemTokenId);

		[PreserveSig]
		HRESULT GetCategory([MarshalAs(UnmanagedType.Interface)] out ISpObjectTokenCategory ppTokenCategory);

		[PreserveSig]
		HRESULT CreateInstance([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, [In] CLSCTX dwClsContext,
			in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out object? ppvObject);

		[PreserveSig]
		HRESULT GetStorageFileName(in Guid clsidCaller, [In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName,
			[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszFileNameSpecifier, [In] uint nFolder,
			[MarshalAs(UnmanagedType.LPWStr)] out string ppszFilePath);

		[PreserveSig]
		HRESULT RemoveStorageFileName(in Guid clsidCaller, [In, MarshalAs(UnmanagedType.LPWStr)] string pszKeyName,
			[In, MarshalAs(UnmanagedType.Bool)] bool fDeleteFile);

		/// <summary><b>ISpObjectToken::Remove</b> removes an object token.</summary>
		/// <param name="pclsidCaller">
		/// [in] Address of the identifier associated with the object token to remove. If pclsidCaller is NULL, the entire token is removed;
		/// otherwise, only the specified section is removed.
		/// </param>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ee450879(v=vs.85)
		[PreserveSig]
		HRESULT Remove([Optional] StructPointer<Guid> pclsidCaller);

		[PreserveSig]
		HRESULT IsUISupported([In, MarshalAs(UnmanagedType.LPWStr)] string pszTypeOfUI, [In] IntPtr pvExtraData, [In] uint cbExtraData,
			[In, MarshalAs(UnmanagedType.IUnknown)] object punkObject, [MarshalAs(UnmanagedType.Bool)] out bool pfSupported);

		[PreserveSig]
		HRESULT DisplayUI([In] HWND hWndParent, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszTitle,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszTypeOfUI, [In] IntPtr pvExtraData, [In] uint cbExtraData,
			[In, MarshalAs(UnmanagedType.IUnknown)] object punkObject);

		[PreserveSig]
		HRESULT MatchesAttributes([In, MarshalAs(UnmanagedType.LPWStr)] string pszAttributes, [MarshalAs(UnmanagedType.Bool)] out bool pfMatches);
	}

	[ComImport, Guid("2D3D3845-39AF-4850-BBF9-40B49780011D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SpObjectTokenCategory))]
	public interface ISpObjectTokenCategory : ISpDataKey
	{
		/// <summary>Sets the binary data for a token.</summary>
		/// <param name="pszValueName">The registry key value name.</param>
		/// <param name="cbData">Size of the <paramref name="pData"/> parameter.</param>
		/// <param name="pData">Pointer to the buffer containing the information.</param>
		/// <returns>S_OK, E_INVALIDARG, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT SetData([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName, [In] uint cbData, [In] IntPtr pData);

		/// <summary>Gets the binary data for a token.</summary>
		/// <param name="pszValueName">The registry key value name.</param>
		/// <param name="pcbData">Size of the <paramref name="pData"/> parameter.</param>
		/// <param name="pData">Pointer to the buffer receiving the information.</param>
		/// <returns>S_OK, E_INVALIDARG, E_POINTER, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT GetData([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName, in uint pcbData, [Out] IntPtr pData);

		/// <summary>Sets the string value information for a specified token.</summary>
		/// <param name="pszValueName">The registry key value name. If NULL, the default value of the token is used.</param>
		/// <param name="pszValue">The string value to be set for the specified key..</param>
		/// <returns>S_OK, E_INVALIDARG, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT SetStringValue([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszValueName,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszValue);

		/// <summary>Gets the string value information for a specified token.</summary>
		/// <param name="pszValueName">The registry key value name. If NULL, the default value of the token is used.</param>
		/// <param name="ppszValue">The string value for the specified key</param>
		/// <returns>S_OK, E_INVALIDARG, E_POINTER, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT GetStringValue([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszValueName,
			[MarshalAs(UnmanagedType.LPWStr)] out string ppszValue);

		/// <summary>Sets the value information for a specified token.</summary>
		/// <param name="pszValueName">The attribute name.</param>
		/// <param name="dwValue">The attribute key value.</param>
		/// <returns>S_OK, E_INVALIDARG, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT SetDWORD([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName, [In] uint dwValue);

		/// <summary>Gets the value information for a specified token.</summary>
		/// <param name="pszValueName">The attribute name.</param>
		/// <param name="pdwValue">The attribute key value.</param>
		/// <returns>S_OK, E_INVALIDARG, E_POINTER, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT GetDWORD([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName, out uint pdwValue);

		/// <summary>Opens a specified token subkey. Passes back a new object that supports ISpDataKey for the specified subkey.</summary>
		/// <param name="pszSubKeyName">Name of the key to open.</param>
		/// <param name="ppSubKey">Address of a pointer to an ISpDataKey interface.</param>
		/// <returns>S_OK, E_INVALIDARG, E_POINTER, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT OpenKey([In, MarshalAs(UnmanagedType.LPWStr)] string pszSubKeyName, [MarshalAs(UnmanagedType.Interface)] out ISpDataKey ppSubKey);

		/// <summary>
		/// Creates a new token subkey. Returns a new object which supports ISpDataKey for the specified subkey. If the key already exists,
		/// the function will open the existing key instead of overwriting it.
		/// </summary>
		/// <param name="pszSubKey">Name of the key to create.</param>
		/// <param name="ppSubKey">Address of a pointer to an ISpDataKey interface.</param>
		/// <returns>S_OK, E_INVALIDARG, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT CreateKey([In, MarshalAs(UnmanagedType.LPWStr)] string pszSubKey, [MarshalAs(UnmanagedType.Interface)] out ISpDataKey ppSubKey);

		/// <summary>Deletes a specified token key and all its descendants.</summary>
		/// <param name="pszSubKey">The name of the key or subkey to delete.</param>
		/// <returns>S_OK, E_INVALIDARG, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT DeleteKey([In, MarshalAs(UnmanagedType.LPWStr)] string pszSubKey);

		/// <summary>Deletes a named value from the specified token.</summary>
		/// <param name="pszValueName">The value name to be deleted.</param>
		/// <returns></returns>
		[PreserveSig]
		new HRESULT DeleteValue([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName);

		/// <summary>Enumerates the subkeys of the specified token.</summary>
		/// <param name="Index">Value indicating which token in the enumeration sequence to locate.</param>
		/// <param name="ppszSubKeyName">The enumerated key name.</param>
		/// <returns>S_OK, E_INVALIDARG, SPERR_NOT_FOUND, E_OUTOFMEMORY, SPERR_NO_MORE_ITEMS, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT EnumKeys([In] uint Index, [MarshalAs(UnmanagedType.LPWStr)] out string ppszSubKeyName);

		/// <summary>Enumerates the values of the specified token.</summary>
		/// <param name="Index">Value indicating which token in the enumeration sequence to locate.</param>
		/// <param name="ppszValueName">The enumerated values name.</param>
		/// <returns>S_OK, E_INVALIDARG, SPERR_NOT_FOUND, E_OUTOFMEMORY, SPERR_NO_MORE_ITEMS, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT EnumValues([In] uint Index, [MarshalAs(UnmanagedType.LPWStr)] out string ppszValueName);

		[PreserveSig]
		HRESULT SetId([In, MarshalAs(UnmanagedType.LPWStr)] string pszCategoryId, [In, MarshalAs(UnmanagedType.Bool)] bool fCreateIfNotExist);

		[PreserveSig]
		HRESULT GetId([MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemCategoryId);

		[PreserveSig]
		HRESULT GetDataKey([In] SPDATAKEYLOCATION spdkl, [MarshalAs(UnmanagedType.Interface)] out ISpDataKey ppDataKey);

		[PreserveSig]
		HRESULT EnumTokens([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pzsReqAttribs,
			[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszOptAttribs,
			[MarshalAs(UnmanagedType.Interface)] out IEnumSpObjectTokens ppEnum);

		[PreserveSig]
		HRESULT SetDefaultTokenId([In, MarshalAs(UnmanagedType.LPWStr)] string pszTokenId);

		[PreserveSig]
		HRESULT GetDefaultTokenId([MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemTokenId);
	}

	[ComImport, Guid("B8AAB0CF-346F-49D8-9499-C8B03F161D51"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpObjectTokenInit : ISpObjectToken
	{
		/// <summary>Sets the binary data for a token.</summary>
		/// <param name="pszValueName">The registry key value name.</param>
		/// <param name="cbData">Size of the <paramref name="pData"/> parameter.</param>
		/// <param name="pData">Pointer to the buffer containing the information.</param>
		/// <returns>S_OK, E_INVALIDARG, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT SetData([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName, [In] uint cbData, [In] IntPtr pData);

		/// <summary>Gets the binary data for a token.</summary>
		/// <param name="pszValueName">The registry key value name.</param>
		/// <param name="pcbData">Size of the <paramref name="pData"/> parameter.</param>
		/// <param name="pData">Pointer to the buffer receiving the information.</param>
		/// <returns>S_OK, E_INVALIDARG, E_POINTER, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT GetData([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName, in uint pcbData, [Out] IntPtr pData);

		/// <summary>Sets the string value information for a specified token.</summary>
		/// <param name="pszValueName">The registry key value name. If NULL, the default value of the token is used.</param>
		/// <param name="pszValue">The string value to be set for the specified key..</param>
		/// <returns>S_OK, E_INVALIDARG, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT SetStringValue([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszValueName,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszValue);

		/// <summary>Gets the string value information for a specified token.</summary>
		/// <param name="pszValueName">The registry key value name. If NULL, the default value of the token is used.</param>
		/// <param name="ppszValue">The string value for the specified key</param>
		/// <returns>S_OK, E_INVALIDARG, E_POINTER, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT GetStringValue([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszValueName,
			[MarshalAs(UnmanagedType.LPWStr)] out string ppszValue);

		/// <summary>Sets the value information for a specified token.</summary>
		/// <param name="pszValueName">The attribute name.</param>
		/// <param name="dwValue">The attribute key value.</param>
		/// <returns>S_OK, E_INVALIDARG, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT SetDWORD([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName, [In] uint dwValue);

		/// <summary>Gets the value information for a specified token.</summary>
		/// <param name="pszValueName">The attribute name.</param>
		/// <param name="pdwValue">The attribute key value.</param>
		/// <returns>S_OK, E_INVALIDARG, E_POINTER, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT GetDWORD([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName, out uint pdwValue);

		/// <summary>Opens a specified token subkey. Passes back a new object that supports ISpDataKey for the specified subkey.</summary>
		/// <param name="pszSubKeyName">Name of the key to open.</param>
		/// <param name="ppSubKey">Address of a pointer to an ISpDataKey interface.</param>
		/// <returns>S_OK, E_INVALIDARG, E_POINTER, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT OpenKey([In, MarshalAs(UnmanagedType.LPWStr)] string pszSubKeyName, [MarshalAs(UnmanagedType.Interface)] out ISpDataKey ppSubKey);

		/// <summary>
		/// Creates a new token subkey. Returns a new object which supports ISpDataKey for the specified subkey. If the key already exists,
		/// the function will open the existing key instead of overwriting it.
		/// </summary>
		/// <param name="pszSubKey">Name of the key to create.</param>
		/// <param name="ppSubKey">Address of a pointer to an ISpDataKey interface.</param>
		/// <returns>S_OK, E_INVALIDARG, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT CreateKey([In, MarshalAs(UnmanagedType.LPWStr)] string pszSubKey, [MarshalAs(UnmanagedType.Interface)] out ISpDataKey ppSubKey);

		/// <summary>Deletes a specified token key and all its descendants.</summary>
		/// <param name="pszSubKey">The name of the key or subkey to delete.</param>
		/// <returns>S_OK, E_INVALIDARG, SPERR_NOT_FOUND, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT DeleteKey([In, MarshalAs(UnmanagedType.LPWStr)] string pszSubKey);

		/// <summary>Deletes a named value from the specified token.</summary>
		/// <param name="pszValueName">The value name to be deleted.</param>
		/// <returns></returns>
		[PreserveSig]
		new HRESULT DeleteValue([In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName);

		/// <summary>Enumerates the subkeys of the specified token.</summary>
		/// <param name="Index">Value indicating which token in the enumeration sequence to locate.</param>
		/// <param name="ppszSubKeyName">The enumerated key name.</param>
		/// <returns>S_OK, E_INVALIDARG, SPERR_NOT_FOUND, E_OUTOFMEMORY, SPERR_NO_MORE_ITEMS, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT EnumKeys([In] uint Index, [MarshalAs(UnmanagedType.LPWStr)] out string ppszSubKeyName);

		/// <summary>Enumerates the values of the specified token.</summary>
		/// <param name="Index">Value indicating which token in the enumeration sequence to locate.</param>
		/// <param name="ppszValueName">The enumerated values name.</param>
		/// <returns>S_OK, E_INVALIDARG, SPERR_NOT_FOUND, E_OUTOFMEMORY, SPERR_NO_MORE_ITEMS, FAILED(hr)</returns>
		[PreserveSig]
		new HRESULT EnumValues([In] uint Index, [MarshalAs(UnmanagedType.LPWStr)] out string ppszValueName);

		[PreserveSig]
		new HRESULT SetId([Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszCategoryId, [In, MarshalAs(UnmanagedType.LPWStr)] string pszTokenId,
			[In, MarshalAs(UnmanagedType.Bool)] bool fCreateIfNotExist);

		[PreserveSig]
		new HRESULT GetId([MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemTokenId);

		[PreserveSig]
		new HRESULT GetCategory([MarshalAs(UnmanagedType.Interface)] out ISpObjectTokenCategory ppTokenCategory);

		[PreserveSig]
		new HRESULT CreateInstance([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, [In] CLSCTX dwClsContext,
			in Guid riid, [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out object? ppvObject);

		[PreserveSig]
		new HRESULT GetStorageFileName(in Guid clsidCaller, [In, MarshalAs(UnmanagedType.LPWStr)] string pszValueName,
			[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszFileNameSpecifier, [In] uint nFolder,
			[MarshalAs(UnmanagedType.LPWStr)] out string ppszFilePath);

		[PreserveSig]
		new HRESULT RemoveStorageFileName(in Guid clsidCaller, [In, MarshalAs(UnmanagedType.LPWStr)] string pszKeyName,
			[In, MarshalAs(UnmanagedType.Bool)] bool fDeleteFile);

		/// <summary><b>ISpObjectToken::Remove</b> removes an object token.</summary>
		/// <param name="pclsidCaller">
		/// [in] Address of the identifier associated with the object token to remove. If pclsidCaller is NULL, the entire token is removed;
		/// otherwise, only the specified section is removed.
		/// </param>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ee450879(v=vs.85)
		[PreserveSig]
		new HRESULT Remove([Optional] StructPointer<Guid> pclsidCaller);

		[PreserveSig]
		new HRESULT IsUISupported([In, MarshalAs(UnmanagedType.LPWStr)] string pszTypeOfUI, [In] IntPtr pvExtraData, [In] uint cbExtraData,
			[In, MarshalAs(UnmanagedType.IUnknown)] object punkObject, [MarshalAs(UnmanagedType.Bool)] out bool pfSupported);

		[PreserveSig]
		new HRESULT DisplayUI([In] HWND hWndParent, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszTitle,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszTypeOfUI, [In] IntPtr pvExtraData, [In] uint cbExtraData,
			[In, MarshalAs(UnmanagedType.IUnknown)] object punkObject);

		[PreserveSig]
		new HRESULT MatchesAttributes([In, MarshalAs(UnmanagedType.LPWStr)] string pszAttributes, [MarshalAs(UnmanagedType.Bool)] out bool pfMatches);

		[PreserveSig]
		HRESULT InitFromDataKey([MarshalAs(UnmanagedType.LPWStr)] string pszCategoryId, [MarshalAs(UnmanagedType.LPWStr)] string pszTokenId,
			[In, Optional] ISpDataKey? pDataKey);
	}

	[ComImport, Guid("5B559F40-E952-11D2-BB91-00C04F8EE6C0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpObjectWithToken
	{
		void SetObjectToken([In, MarshalAs(UnmanagedType.Interface)] ISpObjectToken? pToken);

		void GetObjectToken([MarshalAs(UnmanagedType.Interface)] out ISpObjectToken? ppToken);
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("8445C581-0CAC-4A38-ABFE-9B2CE2826455"), CoClass(typeof(SpNullPhoneConverter))]
	public interface ISpPhoneConverter : ISpObjectWithToken
	{
		new void SetObjectToken([In, MarshalAs(UnmanagedType.Interface)] ISpObjectToken pToken);

		new void GetObjectToken([MarshalAs(UnmanagedType.Interface)] out ISpObjectToken ppToken);

		void PhoneToId([In, MarshalAs(UnmanagedType.LPWStr)] string pszPhone, [Out, MarshalAs(UnmanagedType.LPArray)] SPPHONEID[] pId);

		void IdToPhone([In, MarshalAs(UnmanagedType.LPArray)] SPPHONEID[] pId, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszPhone);
	}

	[ComImport, Guid("133ADCD4-19B4-4020-9FDC-842E78253B17"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SpPhoneticAlphabetConverter))]
	public interface ISpPhoneticAlphabetConverter
	{
		LANGID GetLangId();

		void SetLangId([In] LANGID LangId);

		void SAPI2UPS([In, MarshalAs(UnmanagedType.LPArray)] SPPHONEID[] pszSAPIId, [Out, MarshalAs(UnmanagedType.LPArray)] SPPHONEID[] pszUPSId, [In] uint cMaxLength);

		void UPS2SAPI([In, MarshalAs(UnmanagedType.LPArray)] SPPHONEID[] pszUPSId, [Out, MarshalAs(UnmanagedType.LPArray)] SPPHONEID[] pszSAPIId, [In] uint cMaxLength);

		uint GetMaxConvertLength([In] uint cSrcLength, [In, MarshalAs(UnmanagedType.Bool)] bool bSAPI2UPS);
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("B2745EFD-42CE-48CA-81F1-A96E02538A90")]
	public interface ISpPhoneticAlphabetSelection
	{
		void IsAlphabetUPS([MarshalAs(UnmanagedType.Bool)] out bool pfIsUPS);

		void SetAlphabetToUPS([In, MarshalAs(UnmanagedType.Bool)] bool fForceUPS);
	}

	/// <summary>
	/// This is the main interface used to access information contained in a phrase. Using this interface, applications can retrieve recognition information such as the recognized (or hypothesized) text, the recognized rule, and semantic tag or property information. An application can also serialize the phrase data to a stream to enable persisting of recognitions to the disk, the network, or memory.
	/// </summary>
	[ComImport, Guid("1A5C0354-B621-4B5A-8791-D306ED379E53")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpPhrase
	{
		/// <summary>
		/// <para><b>ISpPhrase::GetPhrase</b> retrieves data elements associated with a phrase.</para>
		/// </summary>
		/// <param name="ppCoMemPhrase">
		/// [out] Address of a pointer to an <c>SPPHRASE</c> data structure receiving the phrase information. May be NULL if no phrase is
		/// recognized. If NULL, no memory is allocated for the structure. It is the caller's responsibility to call CoTaskMemFree to free
		/// the object; however, the caller does not need to call CoTaskMemFree on each of the elements in SPPHRASE.
		/// </param>
		/// <example>
		/// <para>The following code snippet illustrates the use of ISpRecoResult::GetPhrase as inherited from ISpPhrase to retrieve the recognized text, and display the rule recognized and the phrase.</para>
		/// <code language="cpp">// Declare local identifiers:
		/// HRESULT                   hr = S_OK;
		/// CComPtr&lt;ISpRecoResult&gt;    cpRecoResult;
		/// SPPHRASE                  *pPhrase;
		/// WCHAR                     *pwszText;
		/// HWND                      hwndParent;
		/// 
		/// // ... Obtain a recognition result object from the recognizer ...
		/// 
		/// // Get the recognized phrase object.
		/// hr = cpRecoResult->GetPhrase(&amp;pPhrase;);
		/// 
		/// if (SUCCEEDED (hr))
		/// {
		///    // Get the phrase's text.
		///    hr = cpRecoResult->GetText(SP_GETWHOLEPHRASE, SP_GETWHOLEPHRASE, TRUE, &amp;pwszText;, NULL);
		/// }
		/// 
		/// if (SUCCEEDED(hr))
		/// {
		///    // Display the recognized text and the rule name in a message box.
		///    MessageBoxW(hwndParent, pwszText, pPhrase->Rule.pszName, MB_OK);
		/// }</code>
		/// </example>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718433(v=vs.85)
		void GetPhrase(out SafeCoTaskMemStruct<SPPHRASE> ppCoMemPhrase);

		/// <summary>ISpPhrase::GetSerializedPhrase returns the phrase information in serialized form.</summary>
		/// <param name="ppCoMemPhrase">[out] Address of a pointer which will be initialized to point to the serialized phrase data. The block of memory is created by CoTaskMemAlloc and must be manually freed with CoTaskMemFree when no longer needed.</param>
		void GetSerializedPhrase(out SafeCoTaskMemStruct<SPSERIALIZEDPHRASE> ppCoMemPhrase);

		/// <summary>
		/// <para>
		///   <b>ISpPhrase::GetText</b> retrieves elements from a text phrase.</para>
		/// </summary>
		/// <param name="ulStart">[in] Specifies the first element in the text phrase to retrieve.</param>
		/// <param name="ulCount">[in] Specifies the number of elements to retrieve from the text phrase.</param>
		/// <param name="fUseTextReplacements">[in] Boolean value that indicates if replacement text should be used. An example of a text replacement is saying "write new check for twenty dollars" and retrieving the replaced text as "write new check for $20". For more information on replacements, see the <c>SR Engine White Paper</c>.</param>
		/// <param name="ppszCoMemText">[out] Address of a pointer to the data structure that contains the display text information. It is the caller's responsibility to call ::CoTaskMemFree to free the memory.</param>
		/// <param name="pbDisplayAttributes">[out] Address of the <c>SPDISPLAYATTRIBUTES</c> enumeration that contains the text display attribute information. Text display attribute information can be used by the application to display the text to the user in a reasonable manner. For example, speaking "hello comma world period" includes a trailing period, so the recognition might include SPAF_TWO_TRAILING_SPACES to inform the application without requiring extra text processing logic for the application.</param>
		/// <remarks>
		/// <para>The text is the display text of the elements for the phrase and constructs a text string created by CoTaskMemAlloc by applying the pbDisplayAttributes of each <c>SPPHRASEELEMENT</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ee450916(v=vs.85)
		void GetText([In] uint ulStart, [In] uint ulCount, [In, MarshalAs(UnmanagedType.Bool)] bool fUseTextReplacements, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemText,
			[Optional] out SPDISPLAYATTRIBUTES pbDisplayAttributes);

		/// <summary>ISpPhrase::Discard discards the requested data from a phrase object.</summary>
		/// <param name="dwValueTypes">[in] Flags of type SPVALUETYPE indicating elements to discard. Multiple values may be combined.</param>
		void Discard([In] SPVALUETYPE dwValueTypes);
	}

	/// <summary>
	/// <para><b>ISpPhrase::GetPhrase</b> retrieves data elements associated with a phrase.</para>
	/// </summary>
	/// <param name="phr">A <see cref="ISpPhrase"/> instance.</param>
	/// <returns>A <c>SPPHRASE_M</c> data structure receiving the phrase information. May be NULL if no phrase is recognized.</returns>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718433(v=vs.85)
	public static SPPHRASE_M? GetPhrase(this ISpPhrase phr)
	{
		phr.GetPhrase(out var ppCoMemPhrase);
		return (SPPHRASE_M)ppCoMemPhrase;
	}

	[ComImport, Guid("8FCEBC98-4E49-4067-9C6C-D86A0E092E3D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpPhraseAlt : ISpPhrase
	{
		/// <summary>
		/// <para><b>ISpPhrase::GetPhrase</b> retrieves data elements associated with a phrase.</para>
		/// </summary>
		/// <param name="ppCoMemPhrase">
		/// [out] Address of a pointer to an <c>SPPHRASE</c> data structure receiving the phrase information. May be NULL if no phrase is
		/// recognized. If NULL, no memory is allocated for the structure. It is the caller's responsibility to call CoTaskMemFree to free
		/// the object; however, the caller does not need to call CoTaskMemFree on each of the elements in SPPHRASE.
		/// </param>
		/// <example>
		/// <para>The following code snippet illustrates the use of ISpRecoResult::GetPhrase as inherited from ISpPhrase to retrieve the recognized text, and display the rule recognized and the phrase.</para>
		/// <code language="cpp">// Declare local identifiers:
		/// HRESULT                   hr = S_OK;
		/// CComPtr&lt;ISpRecoResult&gt;    cpRecoResult;
		/// SPPHRASE                  *pPhrase;
		/// WCHAR                     *pwszText;
		/// HWND                      hwndParent;
		/// 
		/// // ... Obtain a recognition result object from the recognizer ...
		/// 
		/// // Get the recognized phrase object.
		/// hr = cpRecoResult->GetPhrase(&amp;pPhrase;);
		/// 
		/// if (SUCCEEDED (hr))
		/// {
		///    // Get the phrase's text.
		///    hr = cpRecoResult->GetText(SP_GETWHOLEPHRASE, SP_GETWHOLEPHRASE, TRUE, &amp;pwszText;, NULL);
		/// }
		/// 
		/// if (SUCCEEDED(hr))
		/// {
		///    // Display the recognized text and the rule name in a message box.
		///    MessageBoxW(hwndParent, pwszText, pPhrase->Rule.pszName, MB_OK);
		/// }</code>
		/// </example>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718433(v=vs.85)
		new void GetPhrase(out SafeCoTaskMemStruct<SPPHRASE> ppCoMemPhrase);

		/// <summary>ISpPhrase::GetSerializedPhrase returns the phrase information in serialized form.</summary>
		/// <param name="ppCoMemPhrase">[out] Address of a pointer which will be initialized to point to the serialized phrase data. The block of memory is created by CoTaskMemAlloc and must be manually freed with CoTaskMemFree when no longer needed.</param>
		new void GetSerializedPhrase(out SafeCoTaskMemStruct<SPSERIALIZEDPHRASE> ppCoMemPhrase);

		/// <summary>
		/// <para>
		///   <b>ISpPhrase::GetText</b> retrieves elements from a text phrase.</para>
		/// </summary>
		/// <param name="ulStart">[in] Specifies the first element in the text phrase to retrieve.</param>
		/// <param name="ulCount">[in] Specifies the number of elements to retrieve from the text phrase.</param>
		/// <param name="fUseTextReplacements">[in] Boolean value that indicates if replacement text should be used. An example of a text replacement is saying "write new check for twenty dollars" and retrieving the replaced text as "write new check for $20". For more information on replacements, see the <c>SR Engine White Paper</c>.</param>
		/// <param name="ppszCoMemText">[out] Address of a pointer to the data structure that contains the display text information. It is the caller's responsibility to call ::CoTaskMemFree to free the memory.</param>
		/// <param name="pbDisplayAttributes">[out] Address of the <c>SPDISPLAYATTRIBUTES</c> enumeration that contains the text display attribute information. Text display attribute information can be used by the application to display the text to the user in a reasonable manner. For example, speaking "hello comma world period" includes a trailing period, so the recognition might include SPAF_TWO_TRAILING_SPACES to inform the application without requiring extra text processing logic for the application.</param>
		/// <remarks>
		/// <para>The text is the display text of the elements for the phrase and constructs a text string created by CoTaskMemAlloc by applying the pbDisplayAttributes of each <c>SPPHRASEELEMENT</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ee450916(v=vs.85)
		new void GetText([In] uint ulStart, [In] uint ulCount, [In, MarshalAs(UnmanagedType.Bool)] bool fUseTextReplacements, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemText,
			[Optional] out SPDISPLAYATTRIBUTES pbDisplayAttributes);

		/// <summary>ISpPhrase::Discard discards the requested data from a phrase object.</summary>
		/// <param name="dwValueTypes">[in] Flags of type SPVALUETYPE indicating elements to discard. Multiple values may be combined.</param>
		new void Discard([In] SPVALUETYPE dwValueTypes);

		void GetAltInfo([MarshalAs(UnmanagedType.Interface)] out ISpPhrase ppParent, out uint pulStartElementInParent, out uint pcElementsInParent, out uint pcElementsInAlt);

		void Commit();
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5B4FB971-B115-4DE1-AD97-E482E3BF6EE4")]
	public interface ISpProperties
	{
		void SetPropertyNum([In, MarshalAs(UnmanagedType.LPWStr)] string pName, [In] int lValue);

		void GetPropertyNum([In, MarshalAs(UnmanagedType.LPWStr)] string pName, out int plValue);

		void SetPropertyString([In, MarshalAs(UnmanagedType.LPWStr)] string pName, [In, MarshalAs(UnmanagedType.LPWStr)] string pValue);

		void GetPropertyString([In, MarshalAs(UnmanagedType.LPWStr)] string pName, [MarshalAs(UnmanagedType.LPWStr)] out string ppCoMemValue);
	}

	[ComImport, Guid("DA0CD0F9-14A2-4F09-8C2A-85CC48979345"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpRecoCategory
	{
		void GetType(out SPCATEGORYTYPE peCategoryType);
	}

	[ComImport, Guid("F740A62F-7C15-489E-8234-940A33D9272D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpRecoContext : ISpEventSource
	{
		new void SetNotifySink([In, MarshalAs(UnmanagedType.Interface)] ISpNotifySink pNotifySink);

		new void SetNotifyWindowMessage([In] HWND hWnd, [In] uint Msg, [In] IntPtr wParam, [In] IntPtr lParam);

		new void SetNotifyCallbackFunction(SPNOTIFYCALLBACK pfnCallback, [In] IntPtr wParam, [In] IntPtr lParam);

		new void SetNotifyCallbackInterface([In, MarshalAs(UnmanagedType.Interface)] ISpNotifyCallback pSpCallback, [In] IntPtr wParam, [In] IntPtr lParam);

		new void SetNotifyWin32Event();

		[PreserveSig]
		new HRESULT WaitForNotifyEvent([In] uint dwMilliseconds);

		new HEVENT GetNotifyEventHandle();

		new void SetInterest([In] SPEVENTENUM ullEventInterest, [In] SPEVENTENUM ullQueuedInterest);

		[PreserveSig]
		new HRESULT GetEvents([In] uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SPEVENT[]? pEventArray, out uint pulFetched);

		new void GetInfo(out SPEVENTSOURCEINFO pInfo);

		void GetRecognizer([MarshalAs(UnmanagedType.Interface)] out ISpRecognizer ppRecognizer);

		void CreateGrammar([In] ulong ullGrammarID, [MarshalAs(UnmanagedType.Interface)] out ISpRecoGrammar ppGrammar);

		void GetStatus(out SPRECOCONTEXTSTATUS pStatus);

		void GetMaxAlternates(in uint pcAlternates);

		void SetMaxAlternates([In] uint cAlternates);

		void SetAudioOptions([In] SPAUDIOOPTIONS Options, [In, Optional] StructPointer<Guid> pAudioFormatId, [In, Optional] StructPointer<WAVEFORMATEX> pWaveFormatEx);

		void GetAudioOptions(in SPAUDIOOPTIONS pOptions, out Guid pAudioFormatId, out SafeCoTaskMemStruct<WAVEFORMATEX> ppCoMemWFEX);

		void DeserializeResult(in SPSERIALIZEDRESULT pSerializedResult, [MarshalAs(UnmanagedType.Interface)] out ISpRecoResult ppResult);

		void Bookmark([In] SPBOOKMARKOPTIONS Options, [In] ulong ullStreamPosition, [In] IntPtr lparamEvent);

		void SetAdaptationData([In, MarshalAs(UnmanagedType.LPWStr)] string pAdaptationData, [In] uint cch);

		void Pause([In] uint dwReserved);

		void Resume([In] uint dwReserved);

		void SetVoice([In, MarshalAs(UnmanagedType.Interface)] ISpVoice pVoice, [In, MarshalAs(UnmanagedType.Bool)] bool fAllowFormatChanges);

		void GetVoice([MarshalAs(UnmanagedType.Interface)] out ISpVoice ppVoice);

		void SetVoicePurgeEvent([In] ulong ullEventInterest);

		void GetVoicePurgeEvent(out ulong pullEventInterest);

		void SetContextState([In] SPCONTEXTSTATE eContextState);

		void GetContextState(out SPCONTEXTSTATE peContextState);
	}

	[ComImport, Guid("BEAD311C-52FF-437F-9464-6B21054CA73D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpRecoContext2
	{
		void SetGrammarOptions([In] uint eGrammarOptions);

		void GetGrammarOptions(out uint peGrammarOptions);

		void SetAdaptationData2([In, MarshalAs(UnmanagedType.LPWStr)] string pAdaptationData, [In] uint cch, [In, MarshalAs(UnmanagedType.LPWStr)] string pTopicName, [In] uint eAdaptationSettings, [In] SPADAPTATIONRELEVANCE eRelevance);
	}

	[ComImport, Guid("C2B5F241-DAA0-4507-9E16-5A1EAA2B7A5C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpRecognizer : ISpProperties
	{
		new void SetPropertyNum([In, MarshalAs(UnmanagedType.LPWStr)] string pName, [In] int lValue);

		new void GetPropertyNum([In, MarshalAs(UnmanagedType.LPWStr)] string pName, out int plValue);

		new void SetPropertyString([In, MarshalAs(UnmanagedType.LPWStr)] string pName, [In, MarshalAs(UnmanagedType.LPWStr)] string pValue);

		new void GetPropertyString([In, MarshalAs(UnmanagedType.LPWStr)] string pName, [MarshalAs(UnmanagedType.LPWStr)] out string ppCoMemValue);

		void SetRecognizer([In, MarshalAs(UnmanagedType.Interface)] ISpObjectToken pRecognizer);

		ISpObjectToken GetRecognizer();

		void SetInput([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkInput, [In, MarshalAs(UnmanagedType.Bool)] bool fAllowFormatChanges);

		ISpObjectToken GetInputObjectToken();

		ISpStreamFormat GetInputStream();

		ISpRecoContext CreateRecoContext();

		ISpObjectToken GetRecoProfile();

		void SetRecoProfile([In, MarshalAs(UnmanagedType.Interface)] ISpObjectToken pToken);

		void IsSharedInstance();

		SPRECOSTATE GetRecoState();

		void SetRecoState([In] SPRECOSTATE NewState);

		SPRECOGNIZERSTATUS GetStatus();

		void GetFormat([In] SPSTREAMFORMATTYPE WaveFormatType, out Guid pFormatId, out StructPointer<WAVEFORMATEX> ppCoMemWFEX);

		void IsUISupported([In, MarshalAs(UnmanagedType.LPWStr)] string pszTypeOfUI, [In] IntPtr pvExtraData, [In] uint cbExtraData, [MarshalAs(UnmanagedType.Bool)] out bool pfSupported);

		void DisplayUI([In] HWND hWndParent, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszTitle, [In, MarshalAs(UnmanagedType.LPWStr)] string pszTypeOfUI, [In] IntPtr pvExtraData, [In] uint cbExtraData);

		void EmulateRecognition([In, MarshalAs(UnmanagedType.Interface)] ISpPhrase pPhrase);
	}

	[ComImport, Guid("8FC6D974-C81E-4098-93C5-0147F61ED4D3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpRecognizer2
	{
		void EmulateRecognitionEx([In, MarshalAs(UnmanagedType.Interface)] ISpPhrase pPhrase, [In] uint dwCompareFlags);

		void SetTrainingState([In, MarshalAs(UnmanagedType.Bool)] bool fDoingTraining, [In, MarshalAs(UnmanagedType.Bool)] bool fAdaptFromTrainingData);

		void ResetAcousticModelAdaptation();
	}

	[ComImport, Guid("DF1B943C-5838-4AA2-8706-D7CD5B333499"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpRecognizer3
	{
		void GetCategory([In] SPCATEGORYTYPE categoryType, [MarshalAs(UnmanagedType.Interface)] out ISpRecoCategory ppCategory);

		void SetActiveCategory([In, MarshalAs(UnmanagedType.Interface)] ISpRecoCategory pCategory);

		void GetActiveCategory([MarshalAs(UnmanagedType.Interface)] out ISpRecoCategory ppCategory);
	}

	/// <summary>
	/// <para>
	/// The ISpRecoGrammar interface enables applications to manage the words and phrases that the speech recognition (SR) engine will recognize.
	/// </para>
	/// <para>
	/// A single SpRecognizer object can have multiple SpRecoContext objects associated with it. And similarly, a single SpRecoContext object
	/// can have multiple SpRecoGrammar objects associated with it. Using a one-to-many relationship with SpRecoContext objects and
	/// SpRecoGrammar objects allows applications to separate types of recognizable phrases and content into separate objects for clearer
	/// application logic.
	/// </para>
	/// <para>See Designing Grammar Rules for examples of how to create context-free grammars.</para>
	/// </summary>
	/// <seealso cref="Vanara.PInvoke.SpeechApi.ISpGrammarBuilder"/>
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("2177DB29-7F45-47D0-8554-067E91C80502")]
	public interface ISpRecoGrammar : ISpGrammarBuilder
	{
		/// <summary>
		/// ISpGrammarBuilder::ResetGrammar clears all grammar rules (un-defines them) and resets the grammar's language to NewLanguage. The
		/// state handles for this grammar are no longer valid after this point.
		/// </summary>
		/// <param name="NewLanguage">Language identifier associated with the grammar rule.</param>
		new void ResetGrammar([In] LANGID NewLanguage);

		/// <summary>ISpGrammarBuilder::GetRule retrieves grammar rule's initial state.</summary>
		/// <param name="pszRuleName">The grammar rule name. If NULL, no search is made for the name.</param>
		/// <param name="dwRuleId">Grammar rule identifier. If zero, no search is made for the rule ID.</param>
		/// <param name="dwAttributes">
		/// Grammar rule attributes for the new rule created. Ignored if the rule already exists. Must be of type SPCFGRULEATTRIBUTES. Values
		/// may be combined to allow for multiple attributes.
		/// </param>
		/// <param name="fCreateIfNotExist">
		/// Boolean indicating that the grammar rule is to be created if one does not currently exist. TRUE allows the creation; FALSE does not.
		/// </param>
		/// <param name="phInitialState">The initial state of the rule. May be NULL.</param>
		/// <remarks>
		/// Either the rule name or ID must be provided (the other unused parameter can either be NULL or zero). If both a grammar rule name
		/// and identifier are provided, they both must match in order for this call to succeed. If the grammar rule does not already exist
		/// and fCreateIfNotExists is true, the grammar rule is defined. Otherwise this call will return an error.
		/// </remarks>
		new void GetRule([In, MarshalAs(UnmanagedType.LPWStr)] string? pszRuleName, [In] uint dwRuleId, [In] SPCFGRULEATTRIBUTES dwAttributes,
			[In, MarshalAs(UnmanagedType.Bool)] bool fCreateIfNotExist, out SPSTATEHANDLE phInitialState);

		/// <summary>ISpGrammarBuilder::ClearRule removes all of the grammar rule information except for the rule's initial state handle.</summary>
		/// <param name="hState">
		/// Handle to the any of the states in the grammar rule to be cleared. Only the rule's initial state handle is still valid.
		/// </param>
		new void ClearRule([In] SPSTATEHANDLE hState);

		/// <summary>ISpGrammarBuilder::CreateNewState creates a new state in the same grammar rule as hState.</summary>
		/// <param name="hState">Handle to any existing state in the grammar rule.</param>
		/// <param name="phState">Address of the state handle for a new state in the same grammar rule.</param>
		new void CreateNewState([In] SPSTATEHANDLE hState, out SPSTATEHANDLE phState);

		/// <summary>ISpGrammarBuilder::AddWordTransition adds a word or a sequence of words to the grammar.</summary>
		/// <param name="hFromState">Handle of the state from which the arc (or sequence of arcs in the case of multiple words) should originate.</param>
		/// <param name="hToState">
		/// Handle of the state where the arc (or sequence of arcs) should terminate. If NULL, the final arc will be to the (implicit)
		/// terminal node of this grammar rule.
		/// </param>
		/// <param name="psz">A string containing the word or words to be added. If psz is NULL, an epsilon arc will be added.</param>
		/// <param name="pszSeparators">
		/// A string containing the transition word separation characters.
		/// <para>
		/// psz points to a single word if pszSeperators is NULL, or else pszSeperators specifies the valid separator characters.This
		/// parameter may not contain a forward slash ("/") as that is used for the complex word format.
		/// </para>
		/// </param>
		/// <param name="eWordType">
		/// The SPGRAMMARWORDTYPE enumeration that specifies the word type. SAPI 5.1 supports only SPWT_LEXICAL. SAPI 5.3 supports
		/// SPWT_LEXICAL and SPWT_LEXICAL_NO_SPECIAL_CHARS. If neither of these are specified, the method returns E_INVALIDARG.
		/// </param>
		/// <param name="Weight">Value specifying the arc's relative weight in case there are multiple arcs originating from hFromState.</param>
		/// <param name="pPropInfo">
		/// The SPPROPERTYINFO structure containing property name and value information that is associated with this arc or sequence of arcs.
		/// </param>
		new void AddWordTransition([In] SPSTATEHANDLE hFromState, [In] SPSTATEHANDLE hToState, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? psz, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszSeparators,
			[In] SPGRAMMARWORDTYPE eWordType, [In] float Weight, in SPPROPERTYINFO pPropInfo);

		/// <summary>ISpGrammarBuilder::AddRuleTransition adds a rule (reference) transition from one grammar rule to another.</summary>
		/// <param name="hFromState">Handle of the state from which the arc should originate.</param>
		/// <param name="hToState">
		/// Handle of the state where the arc should terminate. If NULL, the final arc will be to the (implicit) terminal node of this
		/// grammar rule.
		/// </param>
		/// <param name="hRule">
		/// <para>
		/// [in] Handle of any state of the rule to be called with this transition. Get the hRule using the ISpGrammarBuilder::GetRule()
		/// call. To refer to a rule in another grammar, and "import" that rule by calling ISpGrammarBuilder::GetRule( ... , SPRAF_Import,
		/// TRUE /*fCreatIfNotExist*/, ...).
		/// </para>
		/// <para>hRule can also be one of the following special transition handles:</para>
		/// <list type="table">
		/// <item>
		/// <description>Transition handle</description>
		/// <description>Description</description>
		/// </item>
		/// <item>
		/// <description>SPRULETRANS_WILDCARD</description>
		/// <description>&lt;WILDCARD&gt; transition</description>
		/// </item>
		/// <item>
		/// <description>SPRULETRANS_DICTATION</description>
		/// <description>&lt;DICTATION&gt; single word from dictation</description>
		/// </item>
		/// <item>
		/// <description>SPRULETRANS_TEXTBUFFER</description>
		/// <description>&lt;TEXTBUFFER&gt; transition</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Weight">[in] Value specifying the arc's relative weight in case there are multiple arcs originating from hFromState.</param>
		/// <param name="pPropInfo">
		/// [in] The SPPROPERTYINFO structure containing property name and value information that is associated with this arc.
		/// </param>
		new void AddRuleTransition([In] SPSTATEHANDLE hFromState, [In] SPSTATEHANDLE hToState, [In] SPSTATEHANDLE hRule, [In] float Weight,
			in SPPROPERTYINFO pPropInfo);

		/// <summary>
		/// ISpGrammarBuilder::AddResource adds a resource (name and string value) to the grammar rule specified in hRuleState. The resource
		/// can be queried by a rule interpreter using ISpCFGInterpreterSite::GetResourceValue().
		/// </summary>
		/// <param name="hRuleState">[in] Handle of a state in the rule to which the resource is to be added.</param>
		/// <param name="pszResourceName">[in] Address of a null-terminated string specifying the resource name.</param>
		/// <param name="pszResourceValue">[in] Address of a null-terminated string specifying the resource value.</param>
		new void AddResource([In] SPSTATEHANDLE hRuleState, [In, MarshalAs(UnmanagedType.LPWStr)] string pszResourceName,
			[In, MarshalAs(UnmanagedType.LPWStr)] string? pszResourceValue = null);

		/// <summary>
		/// <para>
		/// ISpGrammarBuilder::Commit performs consistency checks of the grammar structure, creates the serialized format, saves the grammar
		/// structure, or reloads the grammar structure.
		/// </para>
		/// <para>
		/// The grammar structure may be saved it to the stream provided by SetSaveObjects, or reloaded into the SR engine. Commit must be
		/// called before any changes to the grammar can take effect.
		/// </para>
		/// </summary>
		/// <param name="dwReserved">Reserved. Must be zero.</param>
		new void Commit([In] uint dwReserved = 0);

		/// <summary>
		/// <para>ISpRecoGrammar::GetGrammarId retrieves the identifier associated with the grammar when the grammar was created.</para>
		/// <para>The grammar ID is set by the application by calling ISpRecoContext::CreateGrammar.</para>
		/// </summary>
		/// <param name="pullGrammarId">Address of a ULONGLONG variable to receive the grammar ID.</param>
		void GetGrammarId(out ulong pullGrammarId);

		/// <summary>
		/// ISpRecoGrammar::GetRecoContext retrieves the ISpRecoContext object that created this grammar. If this method succeeds, the
		/// application using this method must call Release() on the SpRecoContext object returned..
		/// </summary>
		/// <param name="ppRecoCtxt">Address of a pointer to an ISpRecoContext interface that receives the recognition context object pointer.</param>
		void GetRecoContext([MarshalAs(UnmanagedType.Interface)] out ISpRecoContext ppRecoCtxt);

		/// <summary>
		/// ISpRecoGrammar::LoadCmdFromFile loads a grammar from a file. The file can either be a compiled or uncompiled grammar file. To
		/// modify the rules of the grammar after it has been loaded, specify SPLO_DYNAMIC for the Options parameter, otherwise specify the
		/// SPLO_STATIC flag.
		/// </summary>
		/// <param name="pszFileName">
		/// [in, string] The name of the file containing the command and control grammar. The Speech Platform supports loading of compiled
		/// and static grammars using URL.
		/// </param>
		/// <param name="Options">[in] Flag of type SPLOADOPTIONS indicating whether the grammar will be modified dynamically.</param>
		void LoadCmdFromFile([In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName, [In] SPLOADOPTIONS Options);

		/// <summary>ISpRecoGrammar::LoadCmdFromObject loads a context-free grammar (CFG) from a COM object.</summary>
		/// <param name="rcid">[in] The reference class ID of the object containing the command.</param>
		/// <param name="pszGrammarName">[in, string] The grammar name of the object containing the command.</param>
		/// <param name="Options">[in] Flag of type SPLOADOPTIONS indicating whether the file should be loaded statically or dynamically.</param>
		void LoadCmdFromObject(in Guid rcid, [In, MarshalAs(UnmanagedType.LPWStr)] string pszGrammarName, [In] SPLOADOPTIONS Options);

		/// <summary>ISpRecoGrammar::LoadCmdFromResource loads a context-free grammar (CFG) from a Win32 resource.</summary>
		/// <param name="hModule">
		/// [in] Handle to the module whose file name is being requested. If this parameter is NULL, it passes back the path for the file
		/// containing the current process.
		/// </param>
		/// <param name="pszResourceName">[in, string] The name of the resource.</param>
		/// <param name="pszResourceType">[in, string] The type of the resource.</param>
		/// <param name="wLanguage">[in] The language ID.</param>
		/// <param name="Options">[in] Flag of type SPLOADOPTIONS indicating whether the file should be loaded statically or dynamically.</param>
		void LoadCmdFromResource([In] HINSTANCE hModule, [In, MarshalAs(UnmanagedType.LPWStr)] string pszResourceName,
			[In, MarshalAs(UnmanagedType.LPWStr)] string pszResourceType, [In] ushort wLanguage, [In] SPLOADOPTIONS Options);

		/// <summary>ISpRecoGrammar::LoadCmdFromMemory loads a compiled binary version of a context-free grammar (CFG) from memory.</summary>
		/// <param name="pGrammar">[in] The serialized header buffer of type SPBINARYGRAMMAR.</param>
		/// <param name="Options">[in] Flag of type SPLOADOPTIONS indicating whether the file should be loaded statically or dynamically.</param>
		/// <remarks>When an application calls ::LoadCmdFromMemory, the currently loaded CFG will be unloaded.</remarks>
		void LoadCmdFromMemory(StructPointer<SPBINARYGRAMMAR> pGrammar, [In] SPLOADOPTIONS Options);

		/// <summary>ISpRecoGrammar::LoadCmdFromProprietaryGrammar loads a proprietary grammar.</summary>
		/// <param name="rguidParam">
		/// [in] Unique identifier of the grammar. The GUID will be used by the application and the speech recognition (SR) engine to
		/// uniquely identify the SR engine for verifying support.
		/// </param>
		/// <param name="pszStringParam">
		/// [in, string] The null-terminated string command. The string can be used by the application and the SR engine to specify which
		/// part of a grammar to utilize.
		/// </param>
		/// <param name="pvDataPrarm">
		/// [in] Additional information for the process. The Speech Platform will handle the marshaling of the data to the SR engine.
		/// </param>
		/// <param name="cbDataSize">
		/// [in] The size, in bytes, of pvDataParam. The Speech Platform will handle the marshaling of the data to the SR engine.
		/// </param>
		/// <param name="Options">
		/// [in] Flag of type SPLOADOPTIONS indicating whether the file should be loaded statically or dynamically. This value must be SPLO_STATIC.
		/// </param>
		void LoadCmdFromProprietaryGrammar(in Guid rguidParam, [In, MarshalAs(UnmanagedType.LPWStr)] string pszStringParam,
			[In] IntPtr pvDataPrarm, [In] uint cbDataSize, [In] SPLOADOPTIONS Options);

		/// <summary>ISpRecoGrammar::SetRuleState activates or deactivates a top-level rule by its rule name.</summary>
		/// <param name="pszName">
		/// [in, string] Address of a null-terminated string containing the rule name. If NULL and the grammar was created using
		/// ISpGrammarBuilder, all rules with attribute SPRAF_TopLevel and SPRAF_Active and set (at rule creation time) are affected. If the
		/// grammar is SRGS XML, use the value of the root rule's id attribute, or NULL, to activate the grammar.
		/// </param>
		/// <param name="pReserved">Reserved. Do not use; must be NULL.</param>
		/// <param name="NewState">[in] Flag of type SPRULESTATE indicating the new rule state. See Remarks section.</param>
		void SetRuleState([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszName, [In, Optional] IntPtr pReserved, [In] SPRULESTATE NewState);

		/// <summary>ISpRecoGrammar::SetRuleIdState activates or deactivates a rule by its rule ID.</summary>
		/// <param name="ulRuleId">
		/// [in] Value specifying the grammar rule identifier. If zero, all rules with attribute SPRAF_TopLevel and SPRAF_Active and set (at
		/// rule creation time) are affected.
		/// </param>
		/// <param name="NewState">[in] Flag of type SPRULESTATE indicating the new rule state.</param>
		/// <remarks>
		/// <para>
		/// The ulRuleId parameter takes an integer value that the Speech Platform assigns as an identifier to each rule when it is loaded to
		/// the SpRecoGrammar object.
		/// </para>
		/// <para>
		/// By default, the recognizer state (SPRECOSTATE) is SPRST_ACTIVE, which means that if a rule is active, audio will be read and
		/// passed to the speech recognition (SR) engine and recognition will happen. Consequently, an application should not activate a rule
		/// until it is prepared to receive recognitions. An application can also disable the SpRecoContext object (see
		/// ISpRecoContext::SetContextState) or SpRecoGrammar objects (see ISpRecoGrammar::SetGrammarState) to prevent recognitions from
		/// being fired for active rules.
		/// </para>
		/// <para>
		/// If the recognizer state is SPRST_ACTIVE, the Speech Platform will first attempt to open the audio input stream when a rule is
		/// activated. Consequently, if the audio device is already in use by another context, or the stream fails to open, the failure code
		/// will be returned using ::SetRuleIdState. The application should handle this failure gracefully.
		/// </para>
		/// <para>
		/// An application must call ISpRecognizer::SetInput with a non-NULL setting before the recognizer will return recognitions,
		/// regardless of the rule state.
		/// </para>
		/// </remarks>
		void SetRuleIdState([In] uint ulRuleId, [In] SPRULESTATE NewState);

		/// <summary>ISpRecoGrammar::LoadDictation loads a dictation topic into the SpRecoGrammar object and the SR engine.</summary>
		/// <param name="pszTopicName">
		/// [in, optional, string] The null-terminated string containing the topic name. If NULL, the general dictation is loaded. See
		/// Remarks section.
		/// </param>
		/// <param name="Options">
		/// [in] Flag of type SPLOADOPTIONS indicating whether the file should be loaded statically or dynamically. This value must be SPLO_STATIC.
		/// </param>
		/// <remarks>
		/// <para>
		/// SAPI currently defines one specialized dictation topic: SPTOPIC_SPELLING. SR engines are not required to support specialized
		/// dictation topic (including spelling).
		/// </para>
		/// <para>See the SR engine vendor for information on what specialized dictation topics if any are supported.</para>
		/// </remarks>
		void LoadDictation([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszTopicName, [In] SPLOADOPTIONS Options);

		/// <summary>ISpRecoGrammar::UnloadDictation unloads the active dictation topic from the grammar.</summary>
		void UnloadDictation();

		/// <summary>
		/// <para>ISpRecoGrammar::SetDictationState sets the dictation topic state.</para>
		/// <para>The dictation topic is specified by calling ISpRecoGrammar::LoadDictation.</para>
		/// <para>See also ISpSREngine::SetSLMState for information on how SAPI notifies the SR engine.</para>
		/// </summary>
		/// <param name="NewState">[in] Flag of type SPRULESTATE indicating the new state of dictation. See Remarks section</param>
		/// <remarks>
		/// <para>
		/// An application can use the SPRS_ACTIVE_WITH_AUTO_PAUSE state to pause the engine after each dictation recognition is sent. The
		/// application must reactivate the SR engine (see ISpRecoContext::Resume) to prevent the loss of input audio data (see
		/// ISpSREngineSite::Read and SPERR_AUDIO_BUFFER_OVERFLOW).
		/// </para>
		/// <para>
		/// By default, the recognizer state (SPRECOSTATE) is SPRST_ACTIVE, which means that recognition will begin as soon as dictation is
		/// activated. Consequently, an application should not activate the dictation state until it is prepared to receive recognitions. An
		/// application can also disable the SpRecoContext object (see ISpRecoContext::SetContextState) or SpRecoGrammar objects (see
		/// ISpRecoGrammar::SetGrammarState) to prevent recognitions from being fired for active dictation topics.
		/// </para>
		/// <para>
		/// If the recognizer state is SPRST_ACTIVE, SAPI will first attempt to open the audio input stream when dictation (or a rule) is
		/// activated. Consequently, if the audio device is already in use by another application, or the stream fails to open, the failure
		/// code will be returned using ::SetDictationState. The application should handle this failure gracefully.
		/// </para>
		/// <para>
		/// If an application uses an InProc recognizer, it must call ISpRecognizer::SetInput with a non-NULL setting before the recognizer
		/// will return recognitions, regardless of the dictation topic state.
		/// </para>
		/// </remarks>
		void SetDictationState([In] SPRULESTATE NewState);

		/// <summary>
		/// ISpRecoGrammar::SetWordSequenceData sets a word sequence buffer in the SR engine. <br/> The command and control grammar can refer
		/// to any subsequence of words in this buffer using the &lt;TEXTBUFFER&gt; tag, or the SPRULETRANS_TEXTBUFFER special transition
		/// type in ISpGrammarBuilder::AddRuleTransition().
		/// </summary>
		/// <param name="pText">
		/// [in] Buffer containing the text to search for possible word sequences. The buffer is double-NULL terminated. The whole buffer
		/// could be separated into different groups by '\0'. Any sub-sequence of words in the same group is recognizable, any sub-sequence
		/// of words across different groups is not recognizable. The word could be in simple format or complex format: /disp/lex/pron. The
		/// SR engines determine where to break words and when to normalize text for better performance. For example, if the buffer displays:
		/// "please play\0this new game\0\0", "please play" is recognizable, while "this new game" is not recognizable.
		/// </param>
		/// <param name="cchText">
		/// [in] The number of characters (WCHAR) in pText, including null terminators. Because pText should be a double-null-terminated
		/// string, the value of cchText should include any internal null terminators and the ending double-null terminators.
		/// </param>
		/// <param name="pInfo">
		/// [optional, in] Address of the SPTEXTSELECTIONINFO structure that contains the selection information. If NULL, the SR engine will
		/// use the entire contents of pText.
		/// </param>
		/// <remarks>
		/// <para>
		/// An application that has a text box could enable the user to speak commands into the text box to edit the text. One way to design
		/// this functionality would be to create a CFG which supports such commands as "cut the text *", "bold the text *", or "italicize
		/// the words *". The grammar would then use a TEXTBUFFER tag in place of the * which would enable the SR engine to recognize the
		/// text buffer information. At run time, the application would update the SR engine's view of the text buffer using
		/// ::SetWordSequenceData. So if a user had the text "hello world" in the text box, the SR engine could recognize "bold the text world".
		/// </para>
		/// <para>
		/// See also ISpRecoGrammar::SetTextSelection for information on how to update the text selection information independent of the word
		/// sequence data.
		/// </para>
		/// <para>See also ISpSREngine::SetWordSequenceData for information on how SAPI passes the word sequence data to the SR engine.</para>
		/// <para>
		/// The SR engine must support text buffer features. Check for the presence of the TextBuffer attribute for the SR engine. Microsoft
		/// SR ASR engines support these features although there is no requirement that other manufacturers engines need to. See Recognizers
		/// in Object Tokens and Registry Settings for more information.
		/// </para>
		/// </remarks>
		void SetWordSequenceData([In, MarshalAs(UnmanagedType.LPWStr)] string pText, [In] uint cchText, [In, Optional] StructPointer<SPTEXTSELECTIONINFO> pInfo);

		/// <summary>ISpRecoGrammar::SetTextSelection sets the current text selection and insertion point information.</summary>
		/// <param name="pInfo">[in] Address of the SPTEXTSELECTIONINFO structure that contains the text selection and insertion point information.</param>
		/// <remarks>
		/// <para>
		/// An application that has a text box could enable the user to speak commands into the text box to edit the text. One way to design
		/// this functionality would be to create a CFG which supports such commands as "cut the text *", "bold the text *", or "italicize
		/// the words *". The grammar would then use a TEXTBUFFER tag in place of the * which would enable the SR engine to recognize the
		/// text buffer information. At run time, the application would update the SR engine's view of the text buffer using
		/// ISpRecoGrammar::SetWordSequenceData. When the user highlights a selection of text and the text selection using ::SetTextSelection.
		/// </para>
		/// <para>
		/// If a user had the text "hello world" in the text box and no text highlighted, the SR engine could recognize "bold the text
		/// world". If the user highlighted "hello", and the application changed the active text selection only contain "hello", "bold the
		/// text world" would fail to recognize.
		/// </para>
		/// <para>
		/// The application should change the active text selection when the text highlight changes, rather than the entire word sequence
		/// data, to ensure the SR engine has a textual context to help the recognition language model.
		/// </para>
		/// <para>See also ISpRecoGrammar::SetWordSequenceData for information on how to set the text data.</para>
		/// <para>See also ISpSREngine::SetTextSelection for information on how SAPI passes the text selection information to the SR engine.</para>
		/// <para>
		/// The SR engine must support text buffer features. Check for the presence of the TextBuffer attribute in the SR engine. Microsoft
		/// SR ASR engines support these features although there is no requirement that other manufacturers engines need to. See Recognizers
		/// in Object Tokens and Registry Settings for more information.
		/// </para>
		/// </remarks>
		void SetTextSelection(in SPTEXTSELECTIONINFO pInfo);

		/// <summary>
		/// <para>ISpRecoGrammar::IsPronounceable calls the SR engine object to determine if the word has a pronunciation.</para>
		/// </summary>
		/// <param name="pszWord">[in, string] The word to test. Length must be equal to or less than SP_MAX_WORD_LENGTH.</param>
		/// <param name="pWordPronounceable">
		/// [out] Flag, from among the following list, indicating the if the word is pronounceable by the SR engine. See Remarks section.
		/// </param>
		/// <remarks>
		/// <para>
		/// The exact implementation and usage for the SR engine's dictionary and pronounceable words may vary between engines. For example,
		/// an SR engine may attempt to pronounce all words passed using ::IsPronounceable, even if it is not located in the lexicon or the
		/// dictionary, it would rarely or never, return SPWP_UNKNOWN_WORD_UNPRONOUNCEABLE.
		/// </para>
		/// <para>Typically, there are two scenarios when an application might use the method ::IsPronounceable.</para>
		/// <para>
		/// If an application is using a number of specialized or uncommon words (e.g., legal, medical, or scientific terms), the application
		/// may want to verify that the words are contained in either the lexicon (see also ISpLexicon) or the SR engine's dictionary. If the
		/// words are not contained in the lexicon or the dictionary (even if they are pronounceable), the application can add them to the
		/// lexicon to improve the chances of a successful recognition.
		/// </para>
		/// <para>
		/// An application may also want to verify that the SR engine will actually recognize the words in a CFG (even though loading the CFG
		/// succeeded). If the SR engine returns SPWP_UNKNOWN_WORD_UNPRONOUNCEABLE, the application can update the lexicon pronunciation
		/// entry (see ISpLexicon).
		/// </para>
		/// <para>See also ISpSREngine::IsPronounceable for more information on the SR engine's role.</para>
		/// </remarks>
		void IsPronounceable([In, MarshalAs(UnmanagedType.LPWStr)] string pszWord, out SPWORDPRONOUNCEABLE pWordPronounceable);

		/// <summary>ISpRecoGrammar::SetGrammarState sets the grammar state.</summary>
		/// <param name="eGrammarState">[in] Flag of type SPGRAMMARSTATE indicating the new state of the grammar.</param>
		/// <remarks>
		/// <para>
		/// If eGrammarState is SPGM_DISABLED, SAPI will retain the current rule activation state, so that when the grammar state is set to
		/// SPGM_ENABLED, it restores the grammar rules back to each of the original activation states. While the grammar is set to
		/// SPGM_DISABLED, the application can still activate and deactivate rule. The effect is not communicated to the SR engine (but
		/// retained by SAPI) until the grammar is enabled again.
		/// </para>
		/// <para>
		/// If eGrammarState is SPGM_EXCLUSIVE, SAPI will disable all other grammars in the system, unless another grammar is already
		/// exclusive. Activation and deactivation commands are buffered for all other grammars until the exclusive grammar is set to
		/// SPGM_ENABLED again.
		/// </para>
		/// <para>The default grammar state is SPGS_ENABLED, meaning the grammar can receive recognitions.</para>
		/// <para>
		/// Applications can use the grammar state to control whether it will receive recognitions for rules in that SpRecoGrammar object.
		/// For example, an application create a new SpRecoGrammar object, set the grammar state to SPGS_DISABLED, dynamically generate the
		/// rules, and finally set the grammar state to SPFS_ENABLED when grammar construction is completed.
		/// </para>
		/// </remarks>
		void SetGrammarState([In] SPGRAMMARSTATE eGrammarState);

		/// <summary>ISpRecoGrammar::SaveCmd allows applications using dynamic grammars to save the current grammar state to a stream.</summary>
		/// <param name="pStream">[in] The stream to save the compiler binary grammar into.</param>
		/// <param name="ppszCoMemErrorText">
		/// [out] Optional parameter of a null-terminated string containing error messages that occurred during the save operation.
		/// </param>
		/// <remarks>
		/// Applications can use ::SaveCmd to serialize grammar changes that were made at run time for use at a later time. See also ISpRecoGrammar::LoadCmdFromMemory.
		/// </remarks>
		void SaveCmd([In, MarshalAs(UnmanagedType.Interface)] IStream pStream,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] out string? ppszCoMemErrorText);

		/// <summary>
		/// <para>ISpRecoGrammar::GetGrammarState retrieves the current state of the recognition grammar.</para>
		/// <para>The default grammar state is SPGS_ENABLED.</para>
		/// <para>See also ISpRecoGrammar::SetGrammarState</para>
		/// </summary>
		/// <param name="peGrammarState">[out] Address of the SPGRAMMARSTATE enumeration that receives the grammar state information.</param>
		void GetGrammarState(out SPGRAMMARSTATE peGrammarState);
	}

	/// <summary>Extends the ISpRecoGrammar interface.</summary>
	[ComImport, Guid("4B37BC9E-9ED6-44A3-93D3-18F022B79EC3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpRecoGrammar2
	{
		/// <summary>ISpRecoGrammar2::GetRules is used to discover the list of public rules in the grammar.</summary>
		/// <param name="ppCoMemRules">Returns an array of SPRULE structures.</param>
		/// <param name="puNumRules">Returns the number of SPRULE structures in the ppCoMemRules array.</param>
		void GetRules(out ManagedArrayPointer<SPRULE> ppCoMemRules, out uint puNumRules);

		/// <summary>
		/// ISpRecoGrammar2::LoadCmdFromFile2 loads a SAPI 5 grammar from a file and extends the ISpRecoGrammar::LoadCmdFromFile function.
		/// </summary>
		/// <param name="pszFileName">The file name of the grammar.</param>
		/// <param name="Options">Flag of type SPLOADOPTIONS indicating whether the grammar will be modified dynamically.</param>
		/// <param name="pszSharingUri">
		/// Indicates that it is a dynamic shared grammar. Other grammars in the same recognizer can reference this grammar at runtime using
		/// this URI.
		/// </param>
		/// <param name="pszBaseUri">The base path that any relative rule references within the grammar are resolved against.</param>
		void LoadCmdFromFile2([In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName, [In] SPLOADOPTIONS Options,
			[In, MarshalAs(UnmanagedType.LPWStr)] string? pszSharingUri = null, [In, MarshalAs(UnmanagedType.LPWStr)] string? pszBaseUri = null);

		/// <summary>
		/// ISpRecoGrammar2::LoadCmdFromMemory2 loads a compiled CFG binary from memory and extends the ISpRecoGrammar::LoadCmdFromMemory function.
		/// </summary>
		/// <param name="pGrammar">A pointer to the grammar in memory.</param>
		/// <param name="Options">Flag of type SPLOADOPTIONS indicating whether the grammar will be modified dynamically.</param>
		/// <param name="pszSharingUri">
		/// Indicates that it is a dynamic shared grammar. Other grammars in the same recognizer can reference this grammar at runtime using
		/// this URI.
		/// </param>
		/// <param name="pszBaseUri">The base path that any relative rule references within the grammar are resolved against.</param>
		void LoadCmdFromMemory2(in SPBINARYGRAMMAR pGrammar, [In] SPLOADOPTIONS Options, [In, MarshalAs(UnmanagedType.LPWStr)] string? pszSharingUri = null,
			[In, MarshalAs(UnmanagedType.LPWStr)] string? pszBaseUri = null);

		/// <summary>ISpRecoGrammar2::SetRulePriority sets the priority on the specified rule.</summary>
		/// <param name="pszRuleName">The name of the rule.</param>
		/// <param name="ulRuleId">The ID number of the rule.</param>
		/// <param name="nRulePriority">
		/// The priority to be assigned to the rule (between -128 and + 127). When a given utterance satisfies more than one rule, the
		/// recognizer applies the rule with the highest priority. When an utterance satisfies several rules with the same priority, or
		/// several rules with no priority, the recognizer applies the most recently activated rule.
		/// </param>
		void SetRulePriority([In, MarshalAs(UnmanagedType.LPWStr)] string pszRuleName, [In] uint ulRuleId, [In] int nRulePriority);

		/// <summary>ISpRecoContext2::SetRuleWeight sets the weight on the specified rule.</summary>
		/// <param name="pszRuleName">The name of the rule.</param>
		/// <param name="ulRuleId">The ID number of the rule.</param>
		/// <param name="flWeight">
		/// A floating point number between 0 and 1. A higher number biases the recognizer to favour this rule over another rule when the
		/// developer knows that one rule is more likely to be uttered than the other. This is used to tune the accuracy of an application.
		/// </param>
		void SetRuleWeight([In, MarshalAs(UnmanagedType.LPWStr)] string pszRuleName, [In] uint ulRuleId, [In] float flWeight);

		/// <summary>ISpRecoGrammar2::SetDictationWeight sets the weight on the dictation rule.</summary>
		/// <param name="flWeight">
		/// A floating point number between 0 and 1. A higher number biases the recognizer to favour dictation over CFG rules when the
		/// developer knows that dictation is more likely to be uttered than the rule (or vice versa).
		/// </param>
		void SetDictationWeight([In] float flWeight);

		/// <summary>
		/// ISpRecoGrammar2::SetGrammarLoader is used to pass a pointer to an ISpeechResourceLoader interface into SAPI to override SAPI's
		/// default grammar loading function. Applications that wish to perform grammar loading, rather than leave this to SAPI, can do so by
		/// implementing ISpeechResourceLoader.
		/// </summary>
		/// <param name="pLoader">The pointer to the ISpeechResourceLoader interface implemented by an application.</param>
		void SetGrammarLoader([In, MarshalAs(UnmanagedType.Interface)] ISpeechResourceLoader pLoader);

		/// <summary>
		/// <para>ISpRecoGrammar2::SetSMLSecurityManager lets a SAPI application manage its own security policy.</para>
		/// <para>
		/// By default, SAPI uses Windows' URLMON to determine the security rights of semantic interpretation scripts in SRGS grammars.
		/// However, an application may desire to override this with its own security policy, by implementing their own
		/// IInternetSecurityManager interface. IInternetSecurityManager is defined by URLMON.
		/// </para>
		/// </summary>
		/// <param name="pSMLSecurityManager">The pointer to the application's implementation of the IInternetSecurityManager interface.</param>
		void SetSMLSecurityManager([In, MarshalAs(UnmanagedType.Interface)] IInternetSecurityManager pSMLSecurityManager);
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("20B053BE-E235-43CD-9A2A-8D17A48B7842")]
	public interface ISpRecoResult : ISpPhrase
	{
		/// <summary>
		/// <para><b>ISpPhrase::GetPhrase</b> retrieves data elements associated with a phrase.</para>
		/// </summary>
		/// <param name="ppCoMemPhrase">
		/// [out] Address of a pointer to an <c>SPPHRASE</c> data structure receiving the phrase information. May be NULL if no phrase is
		/// recognized. If NULL, no memory is allocated for the structure. It is the caller's responsibility to call CoTaskMemFree to free
		/// the object; however, the caller does not need to call CoTaskMemFree on each of the elements in SPPHRASE.
		/// </param>
		/// <example>
		/// <para>The following code snippet illustrates the use of ISpRecoResult::GetPhrase as inherited from ISpPhrase to retrieve the recognized text, and display the rule recognized and the phrase.</para>
		/// <code language="cpp">// Declare local identifiers:
		/// HRESULT                   hr = S_OK;
		/// CComPtr&lt;ISpRecoResult&gt;    cpRecoResult;
		/// SPPHRASE                  *pPhrase;
		/// WCHAR                     *pwszText;
		/// HWND                      hwndParent;
		/// 
		/// // ... Obtain a recognition result object from the recognizer ...
		/// 
		/// // Get the recognized phrase object.
		/// hr = cpRecoResult->GetPhrase(&amp;pPhrase;);
		/// 
		/// if (SUCCEEDED (hr))
		/// {
		///    // Get the phrase's text.
		///    hr = cpRecoResult->GetText(SP_GETWHOLEPHRASE, SP_GETWHOLEPHRASE, TRUE, &amp;pwszText;, NULL);
		/// }
		/// 
		/// if (SUCCEEDED(hr))
		/// {
		///    // Display the recognized text and the rule name in a message box.
		///    MessageBoxW(hwndParent, pwszText, pPhrase->Rule.pszName, MB_OK);
		/// }</code>
		/// </example>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718433(v=vs.85)
		new void GetPhrase(out SafeCoTaskMemStruct<SPPHRASE> ppCoMemPhrase);

		/// <summary>ISpPhrase::GetSerializedPhrase returns the phrase information in serialized form.</summary>
		/// <param name="ppCoMemPhrase">[out] Address of a pointer which will be initialized to point to the serialized phrase data. The block of memory is created by CoTaskMemAlloc and must be manually freed with CoTaskMemFree when no longer needed.</param>
		new void GetSerializedPhrase(out SafeCoTaskMemStruct<SPSERIALIZEDPHRASE> ppCoMemPhrase);

		/// <summary>
		/// <para>
		///   <b>ISpPhrase::GetText</b> retrieves elements from a text phrase.</para>
		/// </summary>
		/// <param name="ulStart">[in] Specifies the first element in the text phrase to retrieve.</param>
		/// <param name="ulCount">[in] Specifies the number of elements to retrieve from the text phrase.</param>
		/// <param name="fUseTextReplacements">[in] Boolean value that indicates if replacement text should be used. An example of a text replacement is saying "write new check for twenty dollars" and retrieving the replaced text as "write new check for $20". For more information on replacements, see the <c>SR Engine White Paper</c>.</param>
		/// <param name="ppszCoMemText">[out] Address of a pointer to the data structure that contains the display text information. It is the caller's responsibility to call ::CoTaskMemFree to free the memory.</param>
		/// <param name="pbDisplayAttributes">[out] Address of the <c>SPDISPLAYATTRIBUTES</c> enumeration that contains the text display attribute information. Text display attribute information can be used by the application to display the text to the user in a reasonable manner. For example, speaking "hello comma world period" includes a trailing period, so the recognition might include SPAF_TWO_TRAILING_SPACES to inform the application without requiring extra text processing logic for the application.</param>
		/// <remarks>
		/// <para>The text is the display text of the elements for the phrase and constructs a text string created by CoTaskMemAlloc by applying the pbDisplayAttributes of each <c>SPPHRASEELEMENT</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ee450916(v=vs.85)
		new void GetText([In] uint ulStart, [In] uint ulCount, [In, MarshalAs(UnmanagedType.Bool)] bool fUseTextReplacements, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemText,
			[Optional] out SPDISPLAYATTRIBUTES pbDisplayAttributes);

		void GetResultTimes(out SPRECORESULTTIMES pTimes);

		void GetAlternates([In] uint ulStartElement, [In] uint cElements, [In] uint ulRequestCount, [MarshalAs(UnmanagedType.Interface)] out ISpPhraseAlt ppPhrases, out uint pcPhrasesReturned);

		[return: MarshalAs(UnmanagedType.Interface)]
		ISpStreamFormat GetAudio([In] uint ulStartElement, [In] uint cElements);

		void SpeakAudio([In] uint ulStartElement, [In] uint cElements, [In] uint dwFlags, out uint pulStreamNumber);

		void Serialize(out StructPointer<SPSERIALIZEDRESULT> ppCoMemSerializedResult);

		void ScaleAudio(in Guid pAudioFormatId, in WAVEFORMATEX pWaveFormatEx);

		[return: MarshalAs(UnmanagedType.Interface)]
		ISpRecoContext GetRecoContext();
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("27CAC6C4-88F2-41f2-8817-0C95E59F1E6E")]
	public interface ISpRecoResult2 : ISpRecoResult
	{
		/// <summary>
		/// <para><b>ISpPhrase::GetPhrase</b> retrieves data elements associated with a phrase.</para>
		/// </summary>
		/// <param name="ppCoMemPhrase">
		/// [out] Address of a pointer to an <c>SPPHRASE</c> data structure receiving the phrase information. May be NULL if no phrase is
		/// recognized. If NULL, no memory is allocated for the structure. It is the caller's responsibility to call CoTaskMemFree to free
		/// the object; however, the caller does not need to call CoTaskMemFree on each of the elements in SPPHRASE.
		/// </param>
		/// <example>
		/// <para>The following code snippet illustrates the use of ISpRecoResult::GetPhrase as inherited from ISpPhrase to retrieve the recognized text, and display the rule recognized and the phrase.</para>
		/// <code language="cpp">// Declare local identifiers:
		/// HRESULT                   hr = S_OK;
		/// CComPtr&lt;ISpRecoResult&gt;    cpRecoResult;
		/// SPPHRASE                  *pPhrase;
		/// WCHAR                     *pwszText;
		/// HWND                      hwndParent;
		/// 
		/// // ... Obtain a recognition result object from the recognizer ...
		/// 
		/// // Get the recognized phrase object.
		/// hr = cpRecoResult->GetPhrase(&amp;pPhrase;);
		/// 
		/// if (SUCCEEDED (hr))
		/// {
		///    // Get the phrase's text.
		///    hr = cpRecoResult->GetText(SP_GETWHOLEPHRASE, SP_GETWHOLEPHRASE, TRUE, &amp;pwszText;, NULL);
		/// }
		/// 
		/// if (SUCCEEDED(hr))
		/// {
		///    // Display the recognized text and the rule name in a message box.
		///    MessageBoxW(hwndParent, pwszText, pPhrase->Rule.pszName, MB_OK);
		/// }</code>
		/// </example>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718433(v=vs.85)
		new void GetPhrase(out SafeCoTaskMemStruct<SPPHRASE> ppCoMemPhrase);

		/// <summary>ISpPhrase::GetSerializedPhrase returns the phrase information in serialized form.</summary>
		/// <param name="ppCoMemPhrase">[out] Address of a pointer which will be initialized to point to the serialized phrase data. The block of memory is created by CoTaskMemAlloc and must be manually freed with CoTaskMemFree when no longer needed.</param>
		new void GetSerializedPhrase(out SafeCoTaskMemStruct<SPSERIALIZEDPHRASE> ppCoMemPhrase);

		/// <summary>
		/// <para>
		///   <b>ISpPhrase::GetText</b> retrieves elements from a text phrase.</para>
		/// </summary>
		/// <param name="ulStart">[in] Specifies the first element in the text phrase to retrieve.</param>
		/// <param name="ulCount">[in] Specifies the number of elements to retrieve from the text phrase.</param>
		/// <param name="fUseTextReplacements">[in] Boolean value that indicates if replacement text should be used. An example of a text replacement is saying "write new check for twenty dollars" and retrieving the replaced text as "write new check for $20". For more information on replacements, see the <c>SR Engine White Paper</c>.</param>
		/// <param name="ppszCoMemText">[out] Address of a pointer to the data structure that contains the display text information. It is the caller's responsibility to call ::CoTaskMemFree to free the memory.</param>
		/// <param name="pbDisplayAttributes">[out] Address of the <c>SPDISPLAYATTRIBUTES</c> enumeration that contains the text display attribute information. Text display attribute information can be used by the application to display the text to the user in a reasonable manner. For example, speaking "hello comma world period" includes a trailing period, so the recognition might include SPAF_TWO_TRAILING_SPACES to inform the application without requiring extra text processing logic for the application.</param>
		/// <remarks>
		/// <para>The text is the display text of the elements for the phrase and constructs a text string created by CoTaskMemAlloc by applying the pbDisplayAttributes of each <c>SPPHRASEELEMENT</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ee450916(v=vs.85)
		new void GetText([In] uint ulStart, [In] uint ulCount, [In, MarshalAs(UnmanagedType.Bool)] bool fUseTextReplacements, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemText,
			[Optional] out SPDISPLAYATTRIBUTES pbDisplayAttributes);

		new void GetResultTimes(out SPRECORESULTTIMES pTimes);

		new void GetAlternates([In] uint ulStartElement, [In] uint cElements, [In] uint ulRequestCount, [MarshalAs(UnmanagedType.Interface)] out ISpPhraseAlt ppPhrases, out uint pcPhrasesReturned);

		[return: MarshalAs(UnmanagedType.Interface)]
		new ISpStreamFormat GetAudio([In] uint ulStartElement, [In] uint cElements);

		new void SpeakAudio([In] uint ulStartElement, [In] uint cElements, [In] uint dwFlags, out uint pulStreamNumber);

		new void Serialize(out StructPointer<SPSERIALIZEDRESULT> ppCoMemSerializedResult);

		new void ScaleAudio(in Guid pAudioFormatId, in WAVEFORMATEX pWaveFormatEx);

		[return: MarshalAs(UnmanagedType.Interface)]
		new ISpRecoContext GetRecoContext();

		void CommitAlternate(ISpPhraseAlt pPhraseAlt, out ISpRecoResult ppNewResult);

		void CommitText(uint ulStartElement, uint cElements, [In, Optional] string? pszCorrectedData, SPCOMMITFLAGS eCommitFlags);

		void SetTextFeedback(string pszFeedback, bool fSuccessful);
	}

	[ComImport, Guid("93384E18-5014-43D5-ADBB-A78E055926BD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SpResourceManager))]
	public interface ISpResourceManager : Shell32.IServiceProvider
	{
		[PreserveSig]
		new HRESULT QueryService(in Guid guidService, in Guid riid, out nint ppvObject);

		void SetObject(in Guid guidServiceId, [In, MarshalAs(UnmanagedType.IUnknown)] object? punkObject);

		[return: MarshalAs(UnmanagedType.IUnknown)]
		object? GetObject(in Guid guidServiceId, in Guid ObjectCLSID, in Guid ObjectIID, [In, MarshalAs(UnmanagedType.Bool)] bool fReleaseWhenLastExternalRefReleased);
	}

	[ComImport]
	[Guid("21B501A0-0EC7-46C9-92C3-A2BC784C54B9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpSerializeState
	{
		void GetSerializedState([Out, Optional] IntPtr ppbData, out uint pulSize, [In] uint dwReserved = 0);

		void SetSerializedState([In] IntPtr pbData, [In] uint ulSize, [In] uint dwReserved = 0);
	}

	[ComImport, Guid("3DF681E2-EA56-11D9-8BDE-F66BAD1E3F3A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SpShortcut))]
	public interface ISpShortcut
	{
		void AddShortcut([In, MarshalAs(UnmanagedType.LPWStr)] string pszDisplay, [In] LANGID LangId, [In, MarshalAs(UnmanagedType.LPWStr)] string pszSpoken, [In] SPSHORTCUTTYPE shType);

		void RemoveShortcut([In, MarshalAs(UnmanagedType.LPWStr)] string pszDisplay, [In] LANGID LangId, [In, MarshalAs(UnmanagedType.LPWStr)] string pszSpoken, [In] SPSHORTCUTTYPE shType);

		void GetShortcuts([In] LANGID LangId, out SPSHORTCUTPAIRLIST pShortcutpairList);

		void GetGeneration(out uint pdwGeneration);

		void GetWordsFromGenerationChange(out uint pdwGeneration, out SPWORDLIST pWordList);

		void GetWords(out uint pdwGeneration, out uint pdwCookie, out SPWORDLIST pWordList);

		void GetShortcutsForGeneration(out uint pdwGeneration, out uint pdwCookie, out SPSHORTCUTPAIRLIST pShortcutpairList);

		void GetGenerationChange(out uint pdwGeneration, out SPSHORTCUTPAIRLIST pShortcutpairList);
	}

	[ComImport, Guid("12E3CCA9-7518-44C5-A5E7-BA5A79CB929E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SpStream))]
	public interface ISpStream : ISpStreamFormat
	{
		new void Clone(out IStream ppstm);

		new void Commit(int grfCommitFlags);

		new void CopyTo(IStream pstm, long cb, nint pcbRead, nint pcbWritten);

		new void LockRegion(long libOffset, long cb, int dwLockType);

		new void Read(byte[] pv, int cb, nint pcbRead);

		new void Revert();

		new void Seek(long dlibMove, int dwOrigin, nint plibNewPosition);

		new void SetSize(long libNewSize);

		new void Stat(out STATSTG pstatstg, int grfStatFlag);

		new void UnlockRegion(long libOffset, long cb, int dwLockType);

		new void Write(byte[] pv, int cb, nint pcbWritten);

		new void GetFormat(in Guid pguidFormatId, out SafeCoTaskMemStruct<WAVEFORMATEX> ppCoMemWaveFormatEx);

		void SetBaseStream([In, MarshalAs(UnmanagedType.Interface)] IStream pStream, in Guid rguidFormat, in WAVEFORMATEX pWaveFormatEx);

		void GetBaseStream([MarshalAs(UnmanagedType.Interface)] out IStream ppStream);

		/// <summary><b>ISpStream::BindToFile</b> binds the input stream to the file that it identifies.</summary>
		/// <param name="pszFileName">Address of a null-terminated string containing the file name of the file to bind the stream to.</param>
		/// <param name="eMode">
		/// Flag of the type <c>SPFILEMODE</c> to define the file opening mode. When opening an audio wave file, eMode must be
		/// SPFM_OPEN_READONLY or SPFM_CREATE_ALWAYS, otherwise the call will fail.
		/// </param>
		/// <param name="pFormatId">
		/// The data format identifier associated with the stream. This can be NULL and the format will be determined from the supplied wave
		/// file, if the file has the wav extension. If it does not, the file is assumed to be a text file.
		/// </param>
		/// <param name="pWaveFormatEx">
		/// Address of the <c>WAVEFORMATEX</c> structure that contains the wave file format information. If guidFormatId is
		/// SPDFID_WaveFormatEx, this must point to a valid <c>WAVEFORMATEX</c> structure. For other formats, it should be NULL.
		/// </param>
		/// <param name="ullEventInterest">
		/// Flags of type <c>SPEVENTENUM</c> (that is, the possible events raised by SAPI) for the format converter to watch. Typical events
		/// are those to be serialized into the audio stream (for audio output) or those to be deserialized out of the audio stream and fed
		/// to SAPI (for audio input).
		/// </param>
		/// <remarks>
		/// <para>
		/// In speech recognition, ::BindToFile supports only wave audio files. It passes SAPI an audio file to pass to the engine. In
		/// text-to-speech, ::BindToFile supports both audio and text files. See <c>ISpVoice::SpeakStream</c> for more information.
		/// </para>
		/// <para>
		/// The helper class <c>CSpStreamFormat</c> and the <c>SPSTREAMFORMAT</c> enumeration can be used to avoid the possibility of typos
		/// or mistakes when filling in the <c>WAVEFORMATEX</c> structure.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719484(v=vs.85)
		void BindToFile([In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName, [In] SPFILEMODE eMode, [In, Optional] StructPointer<Guid> pFormatId,
			[In, Optional] StructPointer<WAVEFORMATEX> pWaveFormatEx, [In] SPEVENTENUM ullEventInterest);

		void Close();
	}

	/// <summary>Represents a stream format interface that extends <see cref="IStream"/> to provide access to audio format information.</summary>
	/// <remarks>
	/// This interface is primarily used in speech-related applications to retrieve the format of audio streams. It provides a method to
	/// obtain the format identifier and associated wave format structure.
	/// </remarks>
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("BED530BE-2606-4F4D-A1C0-54C5CDA5566F")]
	public interface ISpStreamFormat : IStream
	{
		/// <inheritdoc/>
		new void Read(byte[] pv, int cb, nint pcbRead);

		/// <inheritdoc/>
		new void Write(byte[] pv, int cb, nint pcbWritten);

		/// <inheritdoc/>
		new void Seek(long dlibMove, int dwOrigin, nint plibNewPosition);

		/// <inheritdoc/>
		new void SetSize(long libNewSize);

		/// <inheritdoc/>
		new void CopyTo(IStream pstm, long cb, nint pcbRead, nint pcbWritten);

		/// <inheritdoc/>
		new void Commit(int grfCommitFlags);

		/// <inheritdoc/>
		new void Revert();

		/// <inheritdoc/>
		new void LockRegion(long libOffset, long cb, int dwLockType);

		/// <inheritdoc/>
		new void UnlockRegion(long libOffset, long cb, int dwLockType);

		/// <inheritdoc/>
		new void Stat(out STATSTG pstatstg, int grfStatFlag);

		/// <inheritdoc/>
		new void Clone(out IStream ppstm);

		/// <summary>Retrieves the format information for the specified format identifier.</summary>
		/// <remarks>
		/// This method provides format details for audio processing scenarios. Ensure that the <paramref name="pguidFormatId"/> corresponds
		/// to a valid format identifier. The memory for <paramref name="ppCoMemWaveFormatEx"/> is allocated by the method and must be freed
		/// by the caller.
		/// </remarks>
		/// <param name="pguidFormatId">The GUID that identifies the format for which information is being requested.</param>
		/// <param name="ppCoMemWaveFormatEx">
		/// When the method returns, contains a pointer to a <see cref="WAVEFORMATEX"/> structure that describes the format. The caller is
		/// responsible for releasing the memory associated with this pointer.
		/// </param>
		void GetFormat(in Guid pguidFormatId, out SafeCoTaskMemStruct<WAVEFORMATEX> ppCoMemWaveFormatEx);
	}

	[ComImport, Guid("678A932C-EA71-4446-9B41-78FDA6280A29"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SpStreamFormatConverter))]
	public interface ISpStreamFormatConverter : ISpStreamFormat
	{
		new void Clone(out IStream ppstm);

		new void Commit(int grfCommitFlags);

		new void CopyTo(IStream pstm, long cb, nint pcbRead, nint pcbWritten);

		new void LockRegion(long libOffset, long cb, int dwLockType);

		new void Read(byte[] pv, int cb, nint pcbRead);

		new void Revert();

		new void Seek(long dlibMove, int dwOrigin, nint plibNewPosition);

		new void SetSize(long libNewSize);

		new void Stat(out STATSTG pstatstg, int grfStatFlag);

		new void UnlockRegion(long libOffset, long cb, int dwLockType);

		new void Write(byte[] pv, int cb, nint pcbWritten);

		new void GetFormat(in Guid pguidFormatId, out SafeCoTaskMemStruct<WAVEFORMATEX> ppCoMemWaveFormatEx);

		void SetBaseStream([In, MarshalAs(UnmanagedType.Interface)] ISpStreamFormat? pStream, [In, MarshalAs(UnmanagedType.Bool)] bool fSetFormatToBaseStreamFormat, [In, MarshalAs(UnmanagedType.Bool)] bool fWriteToBaseStream);

		[return: MarshalAs(UnmanagedType.Interface)]
		ISpStreamFormat? GetBaseStream();

		void SetFormat(in Guid rguidFormatIdOfConvertedStream, in WAVEFORMATEX pWaveFormatExOfConvertedStream);

		void ResetSeekPosition();

		void ScaleConvertedToBaseOffset([In] ulong ullOffsetConvertedStream, out ulong pullOffsetBaseStream);

		void ScaleBaseToConvertedOffset([In] ulong ullOffsetBaseStream, out ulong pullOffsetConvertedStream);
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("6C44DF74-72B9-4992-A1EC-EF996E0422D4")]
	public interface ISpVoice : ISpEventSource
	{
		new void SetNotifySink([In, MarshalAs(UnmanagedType.Interface)] ISpNotifySink pNotifySink);

		new void SetNotifyWindowMessage([In] HWND hWnd, [In] uint Msg, [In] IntPtr wParam, [In] IntPtr lParam);

		new void SetNotifyCallbackFunction(SPNOTIFYCALLBACK pfnCallback, [In] IntPtr wParam, [In] IntPtr lParam);

		new void SetNotifyCallbackInterface([In, MarshalAs(UnmanagedType.Interface)] ISpNotifyCallback pSpCallback, [In] IntPtr wParam, [In] IntPtr lParam);

		new void SetNotifyWin32Event();

		[PreserveSig]
		new HRESULT WaitForNotifyEvent([In] uint dwMilliseconds);

		new HEVENT GetNotifyEventHandle();

		new void SetInterest([In] SPEVENTENUM ullEventInterest, [In] SPEVENTENUM ullQueuedInterest);

		[PreserveSig]
		new HRESULT GetEvents([In] uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SPEVENT[]? pEventArray, out uint pulFetched);

		new void GetInfo(out SPEVENTSOURCEINFO pInfo);

		void SetOutput([In, MarshalAs(UnmanagedType.IUnknown)] object pUnkOutput, [In, MarshalAs(UnmanagedType.Bool)] bool fAllowFormatChanges);

		void GetOutputObjectToken([MarshalAs(UnmanagedType.Interface)] out ISpObjectToken ppObjectToken);

		void GetOutputStream([MarshalAs(UnmanagedType.Interface)] out ISpStreamFormat ppStream);

		void Pause();

		void Resume();

		void SetVoice([In, MarshalAs(UnmanagedType.Interface)] ISpObjectToken pToken);

		void GetVoice([MarshalAs(UnmanagedType.Interface)] out ISpObjectToken ppToken);

		void Speak([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwcs, [In] SPEAKFLAGS dwFlags, out uint pulStreamNumber);

		void SpeakStream([In, MarshalAs(UnmanagedType.Interface)] IStream pStream, [In] SPEAKFLAGS dwFlags, out uint pulStreamNumber);

		void GetStatus(out SPVOICESTATUS pStatus, [MarshalAs(UnmanagedType.LPWStr)] out string ppszLastBookmark);

		void Skip([In, MarshalAs(UnmanagedType.LPWStr)] string pItemType, [In] int lNumItems, out uint pulNumSkipped);

		void SetPriority([In] SPVPRIORITY ePriority);

		void GetPriority(out SPVPRIORITY pePriority);

		void SetAlertBoundary([In] SPEVENTENUM eBoundary);

		void GetAlertBoundary(out SPEVENTENUM peBoundary);

		void SetRate([In] int RateAdjust);

		void GetRate(out int pRateAdjust);

		void SetVolume([In] ushort usVolume);

		void GetVolume(out ushort pusVolume);

		void WaitUntilDone([In] uint msTimeout);

		void SetSyncSpeakTimeout([In] uint msTimeout);

		void GetSyncSpeakTimeout(out uint pmsTimeout);

		[PreserveSig]
		HEVENT SpeakCompleteEvent();

		void IsUISupported([In, MarshalAs(UnmanagedType.LPWStr)] string pszTypeOfUI, [In] IntPtr pvExtraData, [In] uint cbExtraData, [MarshalAs(UnmanagedType.Bool)] out bool pfSupported);

		void DisplayUI([In] HWND hWndParent, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszTitle, [In, MarshalAs(UnmanagedType.LPWStr)] string pszTypeOfUI, [In] IntPtr pvExtraData, [In] uint cbExtraData);
	}

	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("AE39362B-45A8-4074-9B9E-CCF49AA2D0B6")]
	public interface ISpXMLRecoResult : ISpRecoResult
	{
		/// <summary>
		/// <para><b>ISpPhrase::GetPhrase</b> retrieves data elements associated with a phrase.</para>
		/// </summary>
		/// <param name="ppCoMemPhrase">
		/// [out] Address of a pointer to an <c>SPPHRASE</c> data structure receiving the phrase information. May be NULL if no phrase is
		/// recognized. If NULL, no memory is allocated for the structure. It is the caller's responsibility to call CoTaskMemFree to free
		/// the object; however, the caller does not need to call CoTaskMemFree on each of the elements in SPPHRASE.
		/// </param>
		/// <example>
		/// <para>The following code snippet illustrates the use of ISpRecoResult::GetPhrase as inherited from ISpPhrase to retrieve the recognized text, and display the rule recognized and the phrase.</para>
		/// <code language="cpp">// Declare local identifiers:
		/// HRESULT                   hr = S_OK;
		/// CComPtr&lt;ISpRecoResult&gt;    cpRecoResult;
		/// SPPHRASE                  *pPhrase;
		/// WCHAR                     *pwszText;
		/// HWND                      hwndParent;
		/// 
		/// // ... Obtain a recognition result object from the recognizer ...
		/// 
		/// // Get the recognized phrase object.
		/// hr = cpRecoResult->GetPhrase(&amp;pPhrase;);
		/// 
		/// if (SUCCEEDED (hr))
		/// {
		///    // Get the phrase's text.
		///    hr = cpRecoResult->GetText(SP_GETWHOLEPHRASE, SP_GETWHOLEPHRASE, TRUE, &amp;pwszText;, NULL);
		/// }
		/// 
		/// if (SUCCEEDED(hr))
		/// {
		///    // Display the recognized text and the rule name in a message box.
		///    MessageBoxW(hwndParent, pwszText, pPhrase->Rule.pszName, MB_OK);
		/// }</code>
		/// </example>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms718433(v=vs.85)
		new void GetPhrase(out SafeCoTaskMemStruct<SPPHRASE> ppCoMemPhrase);

		/// <summary>ISpPhrase::GetSerializedPhrase returns the phrase information in serialized form.</summary>
		/// <param name="ppCoMemPhrase">[out] Address of a pointer which will be initialized to point to the serialized phrase data. The block of memory is created by CoTaskMemAlloc and must be manually freed with CoTaskMemFree when no longer needed.</param>
		new void GetSerializedPhrase(out SafeCoTaskMemStruct<SPSERIALIZEDPHRASE> ppCoMemPhrase);

		/// <summary>
		/// <para>
		///   <b>ISpPhrase::GetText</b> retrieves elements from a text phrase.</para>
		/// </summary>
		/// <param name="ulStart">[in] Specifies the first element in the text phrase to retrieve.</param>
		/// <param name="ulCount">[in] Specifies the number of elements to retrieve from the text phrase.</param>
		/// <param name="fUseTextReplacements">[in] Boolean value that indicates if replacement text should be used. An example of a text replacement is saying "write new check for twenty dollars" and retrieving the replaced text as "write new check for $20". For more information on replacements, see the <c>SR Engine White Paper</c>.</param>
		/// <param name="ppszCoMemText">[out] Address of a pointer to the data structure that contains the display text information. It is the caller's responsibility to call ::CoTaskMemFree to free the memory.</param>
		/// <param name="pbDisplayAttributes">[out] Address of the <c>SPDISPLAYATTRIBUTES</c> enumeration that contains the text display attribute information. Text display attribute information can be used by the application to display the text to the user in a reasonable manner. For example, speaking "hello comma world period" includes a trailing period, so the recognition might include SPAF_TWO_TRAILING_SPACES to inform the application without requiring extra text processing logic for the application.</param>
		/// <remarks>
		/// <para>The text is the display text of the elements for the phrase and constructs a text string created by CoTaskMemAlloc by applying the pbDisplayAttributes of each <c>SPPHRASEELEMENT</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ee450916(v=vs.85)
		new void GetText([In] uint ulStart, [In] uint ulCount, [In, MarshalAs(UnmanagedType.Bool)] bool fUseTextReplacements, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemText,
			[Optional] out SPDISPLAYATTRIBUTES pbDisplayAttributes);

		new void GetResultTimes(out SPRECORESULTTIMES pTimes);

		new void GetAlternates([In] uint ulStartElement, [In] uint cElements, [In] uint ulRequestCount, [MarshalAs(UnmanagedType.Interface)] out ISpPhraseAlt ppPhrases, out uint pcPhrasesReturned);

		[return: MarshalAs(UnmanagedType.Interface)]
		new ISpStreamFormat GetAudio([In] uint ulStartElement, [In] uint cElements);

		new void SpeakAudio([In] uint ulStartElement, [In] uint cElements, [In] uint dwFlags, out uint pulStreamNumber);

		new void Serialize(out StructPointer<SPSERIALIZEDRESULT> ppCoMemSerializedResult);

		new void ScaleAudio(in Guid pAudioFormatId, in WAVEFORMATEX pWaveFormatEx);

		[return: MarshalAs(UnmanagedType.Interface)]
		new ISpRecoContext GetRecoContext();

		void GetXMLResult([MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemXMLResult, [In] SPXMLRESULTOPTIONS Options);

		void GetXMLErrorInfo(out SPSEMANTICERRORINFO pSemanticErrorInfo);
	}

	/// <summary><b>ISpStream::BindToFile</b> binds the input stream to the file that it identifies.</summary>
	/// <param name="str">The <see cref="ISpStreamFormat"/> instance.</param>
	/// <param name="pszFileName">Address of a null-terminated string containing the file name of the file to bind the stream to.</param>
	/// <param name="eMode">
	/// Flag of the type <c>SPFILEMODE</c> to define the file opening mode. When opening an audio wave file, eMode must be SPFM_OPEN_READONLY
	/// or SPFM_CREATE_ALWAYS, otherwise the call will fail.
	/// </param>
	/// <param name="pFormatId">
	/// The data format identifier associated with the stream. This can be NULL and the format will be determined from the supplied wave
	/// file, if the file has the wav extension. If it does not, the file is assumed to be a text file.
	/// </param>
	/// <param name="pWaveFormatEx">
	/// Address of the <c>WAVEFORMATEX</c> structure that contains the wave file format information. If guidFormatId is SPDFID_WaveFormatEx,
	/// this must point to a valid <c>WAVEFORMATEX</c> structure. For other formats, it should be NULL.
	/// </param>
	/// <param name="ullEventInterest">
	/// Flags of type <c>SPEVENTENUM</c> (that is, the possible events raised by SAPI) for the format converter to watch. Typical events are
	/// those to be serialized into the audio stream (for audio output) or those to be deserialized out of the audio stream and fed to SAPI
	/// (for audio input).
	/// </param>
	/// <remarks>
	/// <para>
	/// In speech recognition, ::BindToFile supports only wave audio files. It passes SAPI an audio file to pass to the engine. In
	/// text-to-speech, ::BindToFile supports both audio and text files. See <c>ISpVoice::SpeakStream</c> for more information.
	/// </para>
	/// <para>
	/// The helper class <c>CSpStreamFormat</c> and the <c>SPSTREAMFORMAT</c> enumeration can be used to avoid the possibility of typos or
	/// mistakes when filling in the <c>WAVEFORMATEX</c> structure.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms719484(v=vs.85)
	public static void BindToFile(this ISpStream str, string pszFileName, SPFILEMODE eMode, [In, Optional] Guid? pFormatId, [In, Optional] WAVEFORMATEX? pWaveFormatEx, SPEVENTENUM ullEventInterest) =>
		str.BindToFile(pszFileName, eMode, new(pFormatId, out _), new(pWaveFormatEx, out _), ullEventInterest);

	/// <summary><b>ISpObjectToken::Remove</b> removes an object token.</summary>
	/// <param name="token">The token instance.</param>
	/// <param name="pclsidCaller">
	/// [in] Address of the identifier associated with the object token to remove. If pclsidCaller is NULL, the entire token is removed;
	/// otherwise, only the specified section is removed.
	/// </param>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ee450879(v=vs.85)
	public static void Remove(this ISpObjectToken token, in Guid pclsidCaller)
	{ unsafe { fixed (Guid* p = &pclsidCaller) { token.Remove(p); } } }

	[ComImport, Guid("9EF96870-E160-4792-820D-48CF0649E4EC"), ClassInterface(ClassInterfaceType.None)]
	public class SpAudioFormat
	{ }

	[ComImport, Guid("90903716-2F42-11D3-9C26-00C04F8EF87C"), ClassInterface(ClassInterfaceType.None)]
	public class SpCompressedLexicon
	{ }

	[ComImport, Guid("8DBEF13F-1948-4AA8-8CF0-048EEBED95D8"), ClassInterface(ClassInterfaceType.None)]
	public class SpCustomStream
	{ }

	[ComImport, Guid("947812B3-2AE1-4644-BA86-9E90DED7EC91"), ClassInterface(ClassInterfaceType.None)]
	public class SpFileStream
	{ }

	[ComImport, Guid("73AD6842-ACE0-45E8-A4DD-8795881A2C2A"), ClassInterface(ClassInterfaceType.None)]
	public class SpInProcRecoContext
	{ } // : ISpeechRecoContext, _ISpeechRecoContextEvents, ISpRecoContext, ISpRecoContext2, ISpPhoneticAlphabetConverter

	[ComImport, Guid("41B89B6B-9399-11D2-9623-00C04F8EE628"), ClassInterface(ClassInterfaceType.None)]
	public class SpInprocRecognizer
	{ } // : ISpeechRecognizer, ISpRecognizer, ISpRecognizer2, ISpRecognizer3, ISpSerializeState

	[ComImport, Guid("0655E396-25D0-11D3-9C26-00C04F8EF87C"), ClassInterface(ClassInterfaceType.None)]
	public class SpLexicon
	{ }

	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("5FB7EF7D-DFF4-468A-B6B7-2FCBD188F994")]
	public class SpMemoryStream
	{ }

	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("AB1890A0-E91F-11D2-BB91-00C04F8EE6C0")]
	public class SpMMAudioEnum
	{ }

	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("CF3D2E50-53F2-11D2-960C-00C04F8EE628")]
	public class SpMMAudioIn
	{ } //: ISpeechMMSysAudio

	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("A8C680EB-3D32-11D2-9EE7-00C04F797396")]
	public class SpMMAudioOut
	{ } //: ISpeechMMSysAudio

	[ComImport, Guid("E2AE5372-5D40-11D2-960E-00C04F8EE628"), ClassInterface(ClassInterfaceType.None)]
	public class SpNotifyTranslator
	{ }

	[ComImport, Guid("455F24E9-7396-4A16-9715-7C0FDBE3EFE3"), ClassInterface(ClassInterfaceType.None)]
	public class SpNullPhoneConverter
	{ }

	[ComImport, Guid("EF411752-3736-4CB4-9C8C-8EF4CCB58EFE"), ClassInterface(ClassInterfaceType.None)]
	public class SpObjectToken
	{ }

	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("A910187F-0C7A-45AC-92CC-59EDAFB77B53")]
	public class SpObjectTokenCategory
	{ }

	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("9185F743-1143-4C28-86B5-BFF14F20E5C8")]
	public class SpPhoneConverter
	{ }

	[ComImport, Guid("4F414126-DFE3-4629-99EE-797978317EAD"), ClassInterface(ClassInterfaceType.None)]
	public class SpPhoneticAlphabetConverter
	{ }

	[ComImport, Guid("C23FC28D-C55F-4720-8B32-91F73C2BD5D1"), ClassInterface(ClassInterfaceType.None)]
	public class SpPhraseInfoBuilder
	{ }

	[ComImport, Guid("96749373-3391-11D2-9EE3-00C04F797396"), ClassInterface(ClassInterfaceType.None)]
	public class SpResourceManager
	{ }

	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("47206204-5ECA-11D2-960F-00C04F8EE628")]
	public class SpSharedRecoContext
	{ } //: ISpeechRecoContext, _ISpeechRecoContextEvents, ISpRecoContext, ISpRecoContext2, ISpPhoneticAlphabetConverter

	[ComImport, Guid("3BEE4890-4FE9-4A37-8C1E-5E7E12791C1F"), ClassInterface(ClassInterfaceType.None)]
	public class SpSharedRecognizer
	{ } //: ISpeechRecognizer, ISpRecognizer, ISpRecognizer2, ISpRecognizer3, ISpSerializeState

	[ComImport, Guid("0D722F1A-9FCF-4E62-96D8-6DF8F01A26AA"), ClassInterface(ClassInterfaceType.None)]
	public class SpShortcut
	{ }

	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("715D9C59-4442-11D2-9605-00C04F8EE628")]
	public class SpStream
	{ }

	[ComImport, Guid("7013943A-E2EC-11D2-A086-00C04F8EF9B5"), ClassInterface(ClassInterfaceType.None)]
	public class SpStreamFormatConverter
	{ }

	[ComImport, Guid("0F92030A-CBFD-4AB8-A164-FF5985547FF6"), ClassInterface(ClassInterfaceType.None)]
	public class SpTextSelectionInformation
	{ }

	[ComImport, Guid("C9E37C15-DF92-4727-85D6-72E5EEB6995A"), ClassInterface(ClassInterfaceType.None)]
	public class SpUnCompressedLexicon
	{ }

	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("96749377-3391-11D2-9EE3-00C04F797396")]
	public class SpVoice
	{ }

	[ComImport, ClassInterface(ClassInterfaceType.None), Guid("C79A574C-63BE-44B9-801F-283F87F898BE")]
	public class SpWaveFormatEx
	{ }
}