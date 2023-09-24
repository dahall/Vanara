using static Vanara.PInvoke.PropSys;

namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from Windows Core Audio Api.</summary>
public static partial class CoreAudio
{
	/// <summary>
	/// <para>
	/// The <c>APO_CONNECTION_BUFFER_TYPE</c> enumeration defines constants that indicate whether the audio engine allocates the connection
	/// buffer or uses the buffer that is provided by the APO. These flags are used by the <c>Type</c> member of the
	/// <c>APO_CONNECTION_DESCRIPTOR</c> structure that stores the configuration settings of an APO connection. These settings are required
	/// by the audio engine when an APO connection is created.
	/// </para>
	/// </summary>
	/// <remarks>The Terminal Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</remarks>
	// https://docs.microsoft.com/en-us/previous-versions/dd408130(v=vs.85) typedef enum { APO_CONNECTION_BUFFER_TYPE_ALLOCATED = 0,
	// APO_CONNECTION_BUFFER_TYPE_EXTERNAL = 1, APO_CONNECTION_BUFFER_TYPE_DEPENDANT = 2 } APO_CONNECTION_BUFFER_TYPE;
	[PInvokeData("Audioenginebaseapo.h")]
	public enum APO_CONNECTION_BUFFER_TYPE
	{
		/// <summary>The connection buffer is internally allocated by the audio engine.</summary>
		APO_CONNECTION_BUFFER_TYPE_ALLOCATED = 0,

		/// <summary>
		/// The connection buffer is allocated by the APO, and the audio engine must use the connection buffer that is specified in the
		/// pBuffer member of the APO_CONNECTION_DESCRIPTOR structure.
		/// </summary>
		APO_CONNECTION_BUFFER_TYPE_EXTERNAL = 1,

		/// <summary>The connection buffer is extracted by the audio engine from another connection.</summary>
		APO_CONNECTION_BUFFER_TYPE_DEPENDANT = 2,
	}

	/// <summary>
	/// <para>The APO_FLAG enumeration defines constants that are used as flags by an audio processing object (APO).</para>
	/// <para>This enumeration is used by the APO_REG_PROPERTIES structure to help describe the registration properties of an APO.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/ne-audioenginebaseapo-apo_flag typedef enum APO_FLAG {
	// APO_FLAG_NONE, APO_FLAG_INPLACE, APO_FLAG_SAMPLESPERFRAME_MUST_MATCH, APO_FLAG_FRAMESPERSECOND_MUST_MATCH,
	// APO_FLAG_BITSPERSAMPLE_MUST_MATCH, APO_FLAG_MIXER, APO_FLAG_DEFAULT } ;
	[PInvokeData("audioenginebaseapo.h", MSDNShortId = "42134625-A351-4CB6-B83C-3F2E662D1938")]
	[Flags]
	public enum APO_FLAG
	{
		/// <summary>Indicates that there are no flags enabled for this APO.</summary>
		APO_FLAG_NONE = 0x00,

		/// <summary>
		/// Indicates that this APO can perform in-place processing. This allows the processor to use a common buffer for input and output.
		/// </summary>
		APO_FLAG_INPLACE = 0x01,

		/// <summary>Indicates that the samples per frame for the input and output connections must match.</summary>
		APO_FLAG_SAMPLESPERFRAME_MUST_MATCH = 0x02,

		/// <summary>Indicates that the frames per second for the input and output connections must match.</summary>
		APO_FLAG_FRAMESPERSECOND_MUST_MATCH = 0x04,

		/// <summary>Indicates that bits per sample AND bytes per sample container for the input and output connections must match.</summary>
		APO_FLAG_BITSPERSAMPLE_MUST_MATCH = 0x08,

		/// <summary/>
		APO_FLAG_MIXER = 0x10,

		/// <summary>
		/// The value of this member is determined by the logical OR result of the three preceding members. In other words:APO_FLAG_DEFAULT =
		/// ( APO_FLAG_SAMPLESPERFRAME_MUST_MATCH
		/// </summary>
		APO_FLAG_DEFAULT = APO_FLAG_SAMPLESPERFRAME_MUST_MATCH | APO_FLAG_FRAMESPERSECOND_MUST_MATCH | APO_FLAG_BITSPERSAMPLE_MUST_MATCH,
	}

	/// <summary>Undocumented</summary>
	[PInvokeData("Audioenginebaseapo.h")]
	public enum AUDIO_FLOW_TYPE
	{
		AUDIO_FLOW_PULL = 0,
		AUDIO_FLOW_PUSH = AUDIO_FLOW_PULL + 1
	}

	/// <summary>Undocumented</summary>
	[PInvokeData("Audioenginebaseapo.h")]
	public enum EAudioConstriction
	{
		eAudioConstrictionOff = 0,
		eAudioConstriction48_16 = eAudioConstrictionOff + 1,
		eAudioConstriction44_16 = eAudioConstriction48_16 + 1,
		eAudioConstriction14_14 = eAudioConstriction44_16 + 1,
		eAudioConstrictionMute = eAudioConstriction14_14 + 1
	}

	/// <summary>Undocumented</summary>
	[ComImport, Guid("25385759-3236-4101-A943-25693DFB5D2D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IApoAcousticEchoCancellation
	{
	}

	/// <summary>Undocumented</summary>
	[ComImport, Guid("4CEB0AAB-FA19-48ED-A857-87771AE1B768"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IApoAuxiliaryInputConfiguration
	{
		[PreserveSig]
		HRESULT AddAuxiliaryInput(uint dwInputId, uint cbDataSize, ref byte pbyData, in APO_CONNECTION_DESCRIPTOR pInputConnection);

		[PreserveSig]
		HRESULT RemoveAuxiliaryInput(uint dwInputId);

		[PreserveSig]
		HRESULT IsInputFormatSupported(IAudioMediaType pRequestedInputFormat, out IAudioMediaType ppSupportedInputFormat);
	}

	/// <summary>Undocumented</summary>
	[ComImport, Guid("F851809C-C177-49A0-B1B2-B66F017943AB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IApoAuxiliaryInputRT
	{
		[PreserveSig]
		void AcceptInput(uint dwInputId, in APO_CONNECTION_PROPERTY pInputConnection);
	}

	/// <summary>
	/// <para>
	/// System Effects Audio Processing Objects (sAPOs) are typically used in or called from real-time process threads. However, it is
	/// sometimes necessary to use an sAPO in a non real-time mode. For example, when an sAPO is initialized, it is called from a non
	/// real-time thread. But when audio processing begins, the sAPO is called from a real-time thread. The interface exposes methods that
	/// enable a client to access the non real-time compliant parts of an sAPO.
	/// </para>
	/// <para>The interface supports the following methods:</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nn-audioenginebaseapo-iaudioprocessingobject
	[PInvokeData("audioenginebaseapo.h", MSDNShortId = "71be0151-20dd-40e3-a478-d67e4d8d9c36")]
	[ComImport, Guid("FD7F2B29-24D0-4b5c-B177-592C39F9CA10"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioProcessingObject
	{
		/// <summary>
		/// The Reset method resets the APO to its original state. This method does not cause any changes in the connection objects that are
		/// attached to the input or the output of the APO.
		/// </summary>
		/// <remarks>
		/// This method is not real-time compliant and must not be called from a real-time processing thread. The implementation of this
		/// method does not and must not touch paged memory. Additionally, it must not call any blocking system routines.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nf-audioenginebaseapo-iaudioprocessingobject-reset HRESULT Reset();
		void Reset();

		/// <summary>
		/// The GetLatency method returns the latency for this APO. Latency is the amount of time it takes a frame to traverse the processing
		/// pass of an APO.
		/// </summary>
		/// <returns>
		/// A MFTIME structure that will receive the number of units of delay that this APO introduces. Each unit of delay represents 100 nanoseconds.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the client that is calling this APO knows the sampling rate, the client can calculate the latency in terms of the number of
		/// frames. To get the total latency of the entire audio signal processing stream, the client must query every APO in the processing
		/// chain and add up the results.
		/// </para>
		/// <para><c>Important</c> This method is not real-time compliant and must not be called from a real-time processing thread.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nf-audioenginebaseapo-iaudioprocessingobject-getlatency
		// HRESULT GetLatency( HNSTIME *pTime );
		long GetLatency();

		/// <summary>GetRegistrationProperties returns the registration properties of the audio processing object (APO).</summary>
		/// <returns>The registration properties of the APO. This parameter is of type APO_REG_PROPERTIES.</returns>
		/// <remarks>
		/// <para>The caller must free the memory returned by .</para>
		/// <para><c>Note</c> This method must not be called from a real-time processing thread.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nf-audioenginebaseapo-iaudioprocessingobject-getregistrationproperties
		// HRESULT GetRegistrationProperties( APO_REG_PROPERTIES **ppRegProps );
		SafeCoTaskMemHandle GetRegistrationProperties();

		/// <summary>The Initialize method initializes the APO and supports data of variable length.</summary>
		/// <param name="cbDataSize">This is the size, in bytes, of the initialization data.</param>
		/// <param name="pbyData">This is initialization data that is specific to this APO.</param>
		/// <remarks>
		/// If this method is used to initialize an APO without the need to initialize any data, it is acceptable to supply a <c>NULL</c> as
		/// the value of the pbyData parameter and a 0 (zero) as the value of the cbDataSize parameter. The data that is supplied is of
		/// variable length and must have the following format:
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nf-audioenginebaseapo-iaudioprocessingobject-initialize
		// HRESULT Initialize( UINT32 cbDataSize, BYTE *pbyData );
		void Initialize(uint cbDataSize, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] pbyData);

		/// <summary>This method negotiates with the Windows Vista audio engine to establish a data format for the stream of audio data.</summary>
		/// <param name="pOppositeFormat">
		/// A pointer to an IAudioMediaType interface. This parameter is used to indicate the output format of the data. The value of
		/// pOppositeFormat must be set to <c>NULL</c> to indicate that the output format can be any type.
		/// </param>
		/// <param name="pRequestedInputFormat">
		/// A pointer to an IAudioMediaType interface. This parameter is used to indicate the input format that is to be verified.
		/// </param>
		/// <param name="ppSupportedInputFormat">This parameter indicates the supported format that is closest to the format to be verified.</param>
		/// <returns>
		/// <para>
		/// If the call completed successfully, the ppSupportedInputFormat parameter returns a pRequestedInputFormat pointer and the
		/// IsInputFormatSupported method returns a value of S_OK. Otherwise, this method returns one of the following error codes:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The format of the input/output format pair is not supported. ppSupportedInputFormat returns a suggested new format.</term>
		/// </item>
		/// <item>
		/// <term>APOERR_FORMAT_NOT_SUPPORTED</term>
		/// <term>The format to be verified is not supported. The value of ppSupportedInputFormat does not change.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>Invalid pointer that is passed to the method. The value of ppSupportedInputFormat does not change.</term>
		/// </item>
		/// <item>
		/// <term>Other HRESULT values</term>
		/// <term>These additional error conditions are tracked by the audio engine.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// There are differences in the implementation of the method by the different APOs. For example, with certain implementations, the
		/// output can only be of type float when the input format is of type integer.
		/// </para>
		/// <para>
		/// To initiate format negotiation, the audio service first sets the output of the LFX sAPO to the default float32-based format. The
		/// audio service then calls the method of the LFX sAPO, suggests the default format, and monitors the HRESULT response of this
		/// method. If the input of the LFX sAPO can support the suggested format, it returns S_OK, together with a reference to the
		/// supported format. If the input of the LFX sAPO cannot support the suggested format, it returns S_FALSE together with a reference
		/// to a format that is the closest match to the suggested one. If the LFX sAPO cannot support the suggested format and does not have
		/// a close match, it returns APOERR_FORMAT_NOT_SUPPORTED. The GFX sAPO works with the output format of the LFX sAPO. So the GFX sAPO
		/// is not involved in the format negotiation process.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nf-audioenginebaseapo-iaudioprocessingobject-isinputformatsupported
		// HRESULT IsInputFormatSupported( IAudioMediaType *pOppositeFormat, IAudioMediaType *pRequestedInputFormat, IAudioMediaType
		// **ppSupportedInputFormat );
		[PreserveSig]
		HRESULT IsInputFormatSupported(IAudioMediaType pOppositeFormat, IAudioMediaType pRequestedInputFormat, out IAudioMediaType ppSupportedInputFormat);

		/// <summary>The method is used to verify that a specific output format is supported.</summary>
		/// <param name="pOppositeFormat">
		/// A pointer to an IAudioMediaType interface. This parameter indicates the output format. This parameter must be set to <c>NULL</c>
		/// to indicate that the output format can be any type.
		/// </param>
		/// <param name="pRequestedOutputFormat">
		/// A pointer to an <c>IAudioMediaType</c> interface. This parameter indicates the output format that is to be verified.
		/// </param>
		/// <param name="ppSupportedOutputFormat">
		/// This parameter indicates the supported output format that is closest to the format to be verified.
		/// </param>
		/// <returns>
		/// <para>
		/// If the call completes successfully, the ppSupportedOutputFormat parameter returns a pRequestedOutputFormat pointer and the
		/// IsOutputFormatSupported method returns a value of S_OK. Otherwise, this method returns one of the following error codes:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>
		/// The format of Input/output format pair is not supported. The ppSupportedOutPutFormat parameter returns a suggested new format.
		/// </term>
		/// </item>
		/// <item>
		/// <term>APOERR_FORMAT_NOT_SUPPORTED</term>
		/// <term>The format is not supported. The value of ppSupportedOutputFormat does not change.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>An invalid pointer was passed to the function. The value of ppSupportedOutputFormat does not change.</term>
		/// </item>
		/// <item>
		/// <term>Other HRESULT values</term>
		/// <term>These additional error conditions are tracked by the audio engine.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// There are differences in the implementation of the method by the different APOs. For example, with certain implementations, the
		/// output can only be of type float when the input format is of type integer.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nf-audioenginebaseapo-iaudioprocessingobject-isoutputformatsupported
		// HRESULT IsOutputFormatSupported( IAudioMediaType *pOppositeFormat, IAudioMediaType *pRequestedOutputFormat, IAudioMediaType
		// **ppSupportedOutputFormat );
		[PreserveSig]
		HRESULT IsOutputFormatSupported(IAudioMediaType pOppositeFormat, IAudioMediaType pRequestedOutputFormat, out IAudioMediaType ppSupportedOutputFormat);

		/// <summary>GetInputChannelCount returns the input channel count (samples-per-frame) for this APO.</summary>
		/// <returns>The input channel count.</returns>
		/// <remarks>The input channel count that is returned refers to the input side of the APO.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nf-audioenginebaseapo-iaudioprocessingobject-getinputchannelcount
		// HRESULT GetInputChannelCount( UINT32 *pu32ChannelCount );
		uint GetInputChannelCount();
	}

	/// <summary>
	/// <para>The interface is used to configure the APO. This interface uses its methods to lock and unlock the APO for processing.</para>
	/// <para>The interface supports the following methods:</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nn-audioenginebaseapo-iaudioprocessingobjectconfiguration
	[PInvokeData("audioenginebaseapo.h", MSDNShortId = "6311a5d1-b9d3-4c62-99aa-8feda32b4a2f")]
	[ComImport, Guid("0E5ED805-ABA6-49c3-8F9A-2B8C889C4FA8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioProcessingObjectConfiguration
	{
		/// <summary>The method is used to verify that the APO is locked and ready to process data.</summary>
		/// <param name="u32NumInputConnections">Number of input connections that are attached to this APO.</param>
		/// <param name="ppInputConnections">Connection descriptor for each input connection that is attached to this APO.</param>
		/// <param name="u32NumOutputConnections">Number of output connections that are attached to this APO.</param>
		/// <param name="ppOutputConnections">Connection descriptor for each output connection that is attached to this APO.</param>
		/// <remarks>
		/// When the method is called, it first performs an internal check to see if the APO has been initialized and is ready to process
		/// data. Each APO has different initialization requirements so each APO must define its own Initialize method if needed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nf-audioenginebaseapo-iaudioprocessingobjectconfiguration-lockforprocess
		// HRESULT LockForProcess( UINT32 u32NumInputConnections, APO_CONNECTION_DESCRIPTOR **ppInputConnections, UINT32
		// u32NumOutputConnections, APO_CONNECTION_DESCRIPTOR **ppOutputConnections );
		void LockForProcess([In] uint u32NumInputConnections, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct, SizeParamIndex = 0)] APO_CONNECTION_DESCRIPTOR[] ppInputConnections,
			[In] uint u32NumOutputConnections, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct, SizeParamIndex = 2)] APO_CONNECTION_DESCRIPTOR[] ppOutputConnections);

		/// <summary>The method releases the lock that was imposed on the APO by the LockForProcess method.</summary>
		/// <remarks>
		/// The method places the APO in a mode that makes configuration changes possible. These changes include Add, Remove, and Swap of the
		/// input and output connections that are attached to the APO.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nf-audioenginebaseapo-iaudioprocessingobjectconfiguration-unlockforprocess
		// HRESULT UnlockForProcess();
		void UnlockForProcess();
	}

	/// <summary>
	/// <para>
	/// This interface can operate in real-time mode and its methods can be called form real-time processing threads. The implementation of
	/// the methods for this interface must not block or touch paged memory. Additionally, you must not call any blocking system routines in
	/// the implementation of the methods.
	/// </para>
	/// <para>The interface includes the following methods:</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nn-audioenginebaseapo-iaudioprocessingobjectrt
	[PInvokeData("audioenginebaseapo.h", MSDNShortId = "640ac817-16f2-47c8-87e9-1ae0136e6e55")]
	[ComImport, Guid("9E1D6A6D-DDBC-4E95-A4C7-AD64BA37846C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioProcessingObjectRT
	{
		/// <summary>The APOProcess method causes the APO to make a processing pass.</summary>
		/// <param name="u32NumInputConnections">The number of input connections that are attached to this APO.</param>
		/// <param name="ppInputConnections">An array of input connection property structures. There is one structure per input connection.</param>
		/// <param name="u32NumOutputConnections">The number of output connections that are attached to this APO.</param>
		/// <param name="ppOutputConnections">An array of output connection property structures. There is one structure per output connection.</param>
		/// <returns>
		/// <para>None</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The method must not change the data in the ppOutputConnections array. But it must set the properties of the output connections
		/// after processing.
		/// </para>
		/// <para>
		/// The method is called from a real-time processing thread. The implementation of this method must not touch paged memory and it
		/// should not call any system blocking routines.
		/// </para>
		/// <para>For a detailed look at an implementation of this method, see the Swap sample code and refer to the Swapapolfx.cpp file.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nf-audioenginebaseapo-iaudioprocessingobjectrt-apoprocess
		// void APOProcess( UINT32 u32NumInputConnections, APO_CONNECTION_PROPERTY **ppInputConnections, UINT32 u32NumOutputConnections,
		// APO_CONNECTION_PROPERTY **ppOutputConnections );
		[PreserveSig]
		void APOProcess([In] uint u32NumInputConnections, [In, Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct, SizeParamIndex = 0)] APO_CONNECTION_PROPERTY[] ppInputConnections,
			[In] uint u32NumOutputConnections, [In, Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct, SizeParamIndex = 2)] APO_CONNECTION_PROPERTY[] ppOutputConnections);

		/// <summary>The method returns the number of input frames that an APO requires to generate a given number of output frames.</summary>
		/// <param name="u32OutputFrameCount">This is a count of the number of output frames.</param>
		/// <returns>
		/// <para>The method returns the number of input frames that are required to generate the given number of output frames.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The method is called from a real-time processing thread. The implementation of this method must not touch paged memory and it
		/// should not call any system blocking routines.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nf-audioenginebaseapo-iaudioprocessingobjectrt-calcinputframes
		// UINT32 CalcInputFrames( UINT32 u32OutputFrameCount );
		[PreserveSig]
		uint CalcInputFrames(uint u32OutputFrameCount);

		/// <summary>The method returns the number of output frames that an APO requires for a given number of input frames.</summary>
		/// <param name="u32InputFrameCount">This is a count of the number of input frames.</param>
		/// <returns>
		/// <para>The method returns the number of output frames that an APO will generate for a given number of input frames.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The method can be called form a real-time processing thread. The implementation of this method must not block or touch paged
		/// memory and it should not call any system blocking routines.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nf-audioenginebaseapo-iaudioprocessingobjectrt-calcoutputframes
		// UINT32 CalcOutputFrames( UINT32 u32InputFrameCount );
		[PreserveSig]
		uint CalcOutputFrames([In] uint u32InputFrameCount);
	}

	/// <summary>Undocumented</summary>
	[ComImport, Guid("7ba1db8f-78ad-49cd-9591-f79d80a17c81"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioProcessingObjectVBR
	{
		[PreserveSig]
		HRESULT CalcMaxInputFrames(uint u32MaxOutputFrameCount, uint pu32InputFrameCount);

		[PreserveSig]
		HRESULT CalcMaxOutputFrames(uint u32MaxInputFrameCount, uint pu32OutputFrameCount);
	}

	/// <summary>
	/// <para>
	/// The IAudioSystemEffects interface uses the basic methods that are inherited from <c>IUnknown</c>, and must implement an
	/// <c>Initialize</c> method. The parameters that are passed to this <c>Initialize</c> method must be passed directly to the
	/// <c>IAudioProcessingObject::Initialize</c> method.
	/// </para>
	/// <para>
	/// Refer to the IAudioProcessingObject::Initialize method for information about the structure and the parameters that are required to
	/// implement the <c>IAudioSystemEffects::Initialize</c> method.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nn-audioenginebaseapo-iaudiosystemeffects
	[PInvokeData("audioenginebaseapo.h", MSDNShortId = "86429c51-6831-4266-9774-1547dc04bcb0")]
	[ComImport, Guid("5FA00F27-ADD6-499a-8A9D-6B98521FA75B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioSystemEffects
	{
	}

	/// <summary>
	/// The <c>IAudioSystemEffects2</c> interface was introduced with Windows 8.1 for retrieving information about the processing objects in
	/// a given mode.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nn-audioenginebaseapo-iaudiosystemeffects2
	[PInvokeData("audioenginebaseapo.h", MSDNShortId = "5989BAFB-6B2D-4186-9A8D-96C8974E0D18")]
	[ComImport, Guid("BAFE99D2-7436-44CE-9E0E-4D89AFBFFF56"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioSystemEffects2 : IAudioSystemEffects
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
		HRESULT GetEffectsList(out SafeCoTaskMemHandle ppEffectsIds, out uint pcEffects, [In] IntPtr Event);
	}

	/// <summary>
	/// <para>
	/// The interface is supported in Windows Vista and later versions of Windows. When you develop an audio processing object (APO) to drive
	/// an audio adapter with an atypical format, the APO must support the interface.
	/// </para>
	/// <para>
	/// The Windows operating system can instantiate your APO outside the audio engine and use the interface to retrieve information about
	/// the atypical format. The associated user interface displays the data that is retrieved.
	/// </para>
	/// <para>
	/// <c>Important</c> Although the interface continues to be supported in Windows, note that the type of APO to which you can apply this
	/// interface depends on the version of Windows you are targeting. The following table provides more information:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Target OS</term>
	/// <term>Target APO type</term>
	/// </listheader>
	/// <item>
	/// <term>Windows Vista</term>
	/// <term>Global effects (GFX)</term>
	/// </item>
	/// <item>
	/// <term>Windows 7</term>
	/// <term>Global effects (GFX)</term>
	/// </item>
	/// <item>
	/// <term>Windows 8</term>
	/// <term>Global effects (GFX)</term>
	/// </item>
	/// <item>
	/// <term>Windows 8.1</term>
	/// <term>Endpoint effects (EFX)</term>
	/// </item>
	/// </list>
	/// <para>The interface inherits from <c>IUnknown</c> and also supports the following methods:</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nn-audioenginebaseapo-iaudiosystemeffectscustomformats
	[PInvokeData("audioenginebaseapo.h", MSDNShortId = "29b758c0-5bbe-489c-9950-bc92a185fbaf")]
	[ComImport, Guid("B1176E34-BB7F-4f05-BEBD-1B18A534E097"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioSystemEffectsCustomFormats
	{
		/// <summary>The method retrieves the number of custom formats supported by the system effects audio processing object (sAPO).</summary>
		/// <returns>
		/// Specifies a pointer to an unsigned integer. The unsigned integer represents the number of formats supported by the sAPO.
		/// </returns>
		/// <remarks>For more information about sAPOs, see System Effects Audio Processing Objects.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nf-audioenginebaseapo-iaudiosystemeffectscustomformats-getformatcount
		// HRESULT GetFormatCount( UINT *pcFormats );
		uint GetFormatCount();

		/// <summary>The method retrieves an IAudioMediaType representation of a custom format.</summary>
		/// <param name="nFormat">
		/// Specifies the index of a supported format. This parameter can be any value in the range from zero to one less than the return
		/// value of GetFormatCount. In other words, any value in the range from zero to GetFormatCount( ) - 1.
		/// </param>
		/// <returns>
		/// Specifies a pointer to a pointer to an <c>IAudioMediaType</c> interface. It is the responsibility of the caller to release the
		/// <c>IAudioMediaType</c> interface to which the ppFormat parameter points.
		/// </returns>
		/// <remarks>
		/// When the audio system calls the method, the sAPO creates an audio media type object and returns an <c>IAudioMediaType</c>
		/// interface. The sAPO implementation can use the CreateAudioMediaType utility function to create the audio media type object.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nf-audioenginebaseapo-iaudiosystemeffectscustomformats-getformat
		// HRESULT GetFormat( UINT nFormat, IAudioMediaType **ppFormat );
		IAudioMediaType GetFormat(uint nFormat);

		/// <summary>The method retrieves a string representation of the custom format so that it can be displayed on a user-interface.</summary>
		/// <param name="nFormat">
		/// Specifies the index of a supported format. This parameter can be any value in the range from zero to one less than the return
		/// value of GetFormatCount. In other words, any value in the range from zero to GetFormatCount( ) - 1.
		/// </param>
		/// <param name="ppwstrFormatRep">
		/// Specifies the address of the buffer that receives a NULL-terminated Unicode string that describes the custom format.
		/// </param>
		/// <returns>
		/// <para>
		/// The method returns S_OK when the call is successful. Otherwise, it returns one of the error codes shown in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>Invalid pointer passed to function</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Return buffer cannot be allocated</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>nFormat is out of range</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The sAPO uses CoTaskMemAlloc to allocate the returned string. The caller must use CoTaskMemFree to delete the buffer that is
		/// pointed to by the ppwstrFormatRep parameter.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/nf-audioenginebaseapo-iaudiosystemeffectscustomformats-getformatrepresentation
		// HRESULT GetFormatRepresentation( UINT nFormat, LPWSTR *ppwstrFormatRep );
		void GetFormatRepresentation(uint nFormat, out SafeCoTaskMemString ppwstrFormatRep);
	}

	/// <summary>
	/// The GetEffectsList method is used for retrieving the list of audio processing effects that are currently active, and stores an event
	/// to be signaled if the list changes.
	/// </summary>
	/// <param name="ase2">The <c>IAudioSystemEffects2</c> instance.</param>
	/// <param name="Event">The HANDLE of the event that will be signaled if the list changes.</param>
	/// <returns>The list of GUIDs that represent audio processing effects.</returns>
	/// <remarks>
	/// <para>
	/// The APO signals the specified event when the list of audio processing effects changes from the list that was returned by
	/// <c>GetEffectsList</c>. The APO uses this event until either <c>GetEffectsList</c> is called again, or the APO is destroyed. The
	/// passed handle can be NULL, in which case the APO stops using any previous handle and does not signal an event.
	/// </para>
	/// <para>
	/// An APO implements this method to allow Windows to discover the current effects applied by the APO. The list of effects may depend on
	/// the processing mode that the APO initialized, and on any end user configuration. The processing mode is indicated by the
	/// AudioProcessingMode member of APOInitSystemEffects2.
	/// </para>
	/// <para>
	/// APOs should identify effects using GUIDs defined by Windows, such as AUDIO_EFFECT_TYPE_ACOUSTIC_ECHO_CANCELLATION. An APO should only
	/// define and return a custom GUID in rare cases where the type of effect is clearly different from the ones defined by Windows.
	/// </para>
	/// </remarks>
	public static Guid[] GetEffectsList(this IAudioSystemEffects2 ase2, [In] IntPtr Event)
	{
		ase2.GetEffectsList(out SafeCoTaskMemHandle ids, out uint i, Event);
		using (ids)
		{
			return ids.ToArray<Guid>((int)i);
		}
	}

	/// <summary>The method retrieves a string representation of the custom format so that it can be displayed on a user-interface.</summary>
	/// <param name="fmts">The <c>IAudioSystemEffectsCustomFormats</c> instance.</param>
	/// <param name="nFormat">
	/// Specifies the index of a supported format. This parameter can be any value in the range from zero to one less than the return value
	/// of GetFormatCount. In other words, any value in the range from zero to GetFormatCount( ) - 1.
	/// </param>
	/// <returns>A string that describes the custom format.</returns>
	public static string GetFormatRepresentation(this IAudioSystemEffectsCustomFormats fmts, uint nFormat)
	{
		fmts.GetFormatRepresentation(nFormat, out SafeCoTaskMemString rep);
		using (rep)
		{
			return (string)rep;
		}
	}

	/// <summary>The APO_CONNECTION_DESCRIPTOR structure stores the description of an APO connection buffer.</summary>
	/// <remarks>The Terminal Services AudioEndpoint API is for use in Remote Desktop scenarios; it is not for client applications.</remarks>
	[PInvokeData("Audioenginebaseapo.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct APO_CONNECTION_DESCRIPTOR
	{
		/// <summary>
		/// A value of the APO_CONNECTION_BUFFER_TYPE enumeration that indicates how the connection buffer inside the APO connection is
		/// allocated. This member is set only by the APO connection during initialization. It is a private member that should be cleared
		/// before creating the connection.
		/// </summary>
		public APO_CONNECTION_BUFFER_TYPE Type;

		/// <summary>
		/// A pointer to the buffer to be used for the APO connection. If this member is NULL, the audio engine allocates memory for the
		/// buffer and the Type member is set to APO_CONNECTION_BUFFER_TYPE_ALLOCATED. Otherwise, the audio engine uses the specified memory
		/// region as the connection buffer. The buffer to be used for the APO connection must be frame aligned or 128-bit aligned, both at
		/// the beginning of the buffer and at the start of the audio buffer section. The buffer to be used for the APO connection must be
		/// large enough to hold the number of frames indicated in u32MaxFrameCount. This member must point to the beginning of the audio
		/// buffer area. If the audio engine must use the memory pointed by this member, the Type member is set to APO_CONNECTION_BUFFER_TYPE_EXTERNAL.
		/// </summary>
		public IntPtr pBuffer;

		/// <summary>
		/// The maximum number of frames that the connection buffer can hold. The actual space allocated depends on the exact format of the
		/// audio data specified by the pFormat member.
		/// </summary>
		public uint u32MaxFrameCount;

		/// <summary>
		/// A pointer to the audio media object that specifies the format of the connection. This also represents the format of the data in
		/// the connection buffer.
		/// </summary>
		public IntPtr pFormat;

		/// <summary>A tag that identifies a valid APO_CONNECTION_DESCRIPTOR structure. A valid structure is marked as APO_CONNECTION_DESCRIPTOR_SIGNATURE.</summary>
		public uint u32Signature;
	}

	/// <summary>
	/// The APO_REG_PROPERTIES structure is used by IAudioProcessingObject::GetRegistrationProperties for returning the registration
	/// properties of an audio processing object (APO).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/ns-audioenginebaseapo-apo_reg_properties typedef struct
	// APO_REG_PROPERTIES { CLSID clsid; APO_FLAG Flags; WCHAR szFriendlyName[256]; WCHAR szCopyrightInfo[256]; UINT32 u32MajorVersion;
	// UINT32 u32MinorVersion; UINT32 u32MinInputConnections; UINT32 u32MaxInputConnections; UINT32 u32MinOutputConnections; UINT32
	// u32MaxOutputConnections; UINT32 u32MaxInstances; UINT32 u32NumAPOInterfaces; IID iidAPOInterfaceList[1]; } APO_REG_PROPERTIES, *PAPO_REG_PROPERTIES;
	[PInvokeData("audioenginebaseapo.h", MSDNShortId = "466215E5-5345-4570-A29B-086562882F5D")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct APO_REG_PROPERTIES
	{
		/// <summary>The class ID for this APO.</summary>
		public Guid clsid;

		/// <summary>The flags for this APO. This parameter is an enumerated constant of type APO_FLAG.</summary>
		public APO_FLAG Flags;

		/// <summary>The friendly name of this APO. This is a string of characters with a max length of 256.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string szFriendlyName;

		/// <summary>The copyright info for this APO. This is a string of characters with a max length of 256.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string szCopyrightInfo;

		/// <summary>The major version number for this APO.</summary>
		public uint u32MajorVersion;

		/// <summary>The minor version number for this APO.</summary>
		public uint u32MinorVersion;

		/// <summary>The minimum number of input connections for this APO.</summary>
		public uint u32MinInputConnections;

		/// <summary>The maximum number of input connections for this APO.</summary>
		public uint u32MaxInputConnections;

		/// <summary>The minimum number of output connections for this APO.</summary>
		public uint u32MinOutputConnections;

		/// <summary>The maximum number of output connections for this APO.</summary>
		public uint u32MaxOutputConnections;

		/// <summary>The maximum number of instances of this APO.</summary>
		public uint u32MaxInstances;

		/// <summary>The number of interfaces for this APO.</summary>
		public uint u32NumAPOInterfaces;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public Guid[] iidAPOInterfaceList;
	}

	/// <summary>The APOInitBaseStruct structure is the base initialization header that must precede other initialization data in IAudioProcessingObject::Initialize.</summary>
	/// <remarks>
	/// If the specified CLSID does not match, then the APOInitBaseStruct structure was not designed for this APO, and this is an error
	/// condition. And if the CLSID of the APO changes between versions, then the CLSID may also be used for version management. In the case
	/// where the CLSID is used for version management, a previous version may still be supported by the APO.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/ns-audioenginebaseapo-apoinitbasestruct typedef struct
	// APOInitBaseStruct { UINT32 cbSize; CLSID clsid; } APOInitBaseStruct;
	[PInvokeData("audioenginebaseapo.h", MSDNShortId = "15C973AE-B0E8-42FD-9F34-671A6A915B47")]
	[StructLayout(LayoutKind.Sequential)]
	public struct APOInitBaseStruct
	{
		/// <summary>The total size of the structure in bytes.</summary>
		public uint cbSize;

		/// <summary>The Class ID (CLSID) of the APO.</summary>
		public Guid clsid;
	}

	/// <summary>The APOInitSystemEffects structure gets passed to the system effects APO for initialization.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/ns-audioenginebaseapo-apoinitsystemeffects typedef struct
	// APOInitSystemEffects { APOInitBaseStruct APOInit; IPropertyStore *pAPOEndpointProperties; IPropertyStore
	// *pAPOSystemEffectsProperties; void *pReserved; IMMDeviceCollection *pDeviceCollection; } APOInitSystemEffects;
	[PInvokeData("audioenginebaseapo.h", MSDNShortId = "E33B1F94-4E3A-4EC1-AFB5-FD803FA391BC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct APOInitSystemEffects
	{
		/// <summary>An APOInitBaseStruct structure.</summary>
		public APOInitBaseStruct APOInit;

		/// <summary>A pointer to an IPropertyStore object.</summary>
		public IPropertyStore pAPOEndpointProperties;

		/// <summary>A pointer to an IPropertyStore object.</summary>
		public IPropertyStore pAPOSystemEffectsProperties;

		/// <summary>Reserved for future use.</summary>
		public IntPtr pReserved;

		/// <summary>A pointer to an IMMDeviceCollection object.</summary>
		public IMMDeviceCollection pDeviceCollection;
	}

	/// <summary>
	/// The APOInitSystemEffects2 structure was introduced with Windows 8.1, to make it possible to provide additional initialization context
	/// to the audio processing object (APO) for initialization.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/ns-audioenginebaseapo-apoinitsystemeffects2 typedef struct
	// APOInitSystemEffects2 { APOInitBaseStruct APOInit; IPropertyStore *pAPOEndpointProperties; IPropertyStore
	// *pAPOSystemEffectsProperties; void *pReserved; IMMDeviceCollection *pDeviceCollection; UINT nSoftwareIoDeviceInCollection; UINT
	// nSoftwareIoConnectorIndex; GUID AudioProcessingMode; BOOL InitializeForDiscoveryOnly; } APOInitSystemEffects2;
	[PInvokeData("audioenginebaseapo.h", MSDNShortId = "87E59FCE-1965-4B23-B1F5-F54FEDD5A83E")]
	[StructLayout(LayoutKind.Sequential)]
	public struct APOInitSystemEffects2
	{
		/// <summary>An APOInitBaseStruct structure.</summary>
		public APOInitBaseStruct APOInit;

		/// <summary>A pointer to an IPropertyStore object.</summary>
		public IPropertyStore pAPOEndpointProperties;

		/// <summary>A pointer to an IPropertyStore object.</summary>
		public IPropertyStore pAPOSystemEffectsProperties;

		/// <summary>Reserved for future use.</summary>
		public IntPtr pReserved;

		/// <summary>A pointer to an IMMDeviceCollection object.</summary>
		public IMMDeviceCollection pDeviceCollection;

		/// <summary>
		/// Specifies the MMDevice that implements the DeviceTopology that includes the software connector for which the APO is initializing.
		/// The MMDevice is contained in pDeviceCollection.
		/// </summary>
		public uint nSoftwareIoDeviceInCollection;

		/// <summary>Specifies the index of a Software_IO connector in the DeviceTopology.</summary>
		public uint nSoftwareIoConnectorIndex;

		/// <summary>Specifies the processing mode for the audio graph.</summary>
		public Guid AudioProcessingMode;

		/// <summary>Indicates whether the audio system is initializing the APO for effects discovery only.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool InitializeForDiscoveryOnly;
	}

	/// <summary>The AudioFXExtensionParams structure is passed to the system effects ControlPanel Extension PropertyPage via IShellPropSheetExt::AddPages.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/audioenginebaseapo/ns-audioenginebaseapo-audiofxextensionparams typedef struct
	// __MIDL___MIDL_itf_audioenginebaseapo_0000_0008_0001 { LPARAM AddPageParam; LPWSTR pwstrEndpointID; IPropertyStore *pFxProperties; } AudioFXExtensionParams;
	[PInvokeData("audioenginebaseapo.h", MSDNShortId = "832F1190-ED3E-4059-AB45-18C23D98663B")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AudioFXExtensionParams
	{
		/// <summary>Parameters for the Property Page extension.</summary>
		public IntPtr AddPageParam;

		/// <summary>The ID for the audio endpoint.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwstrEndpointID;

		/// <summary>An IPropertyStore object.</summary>
		public IPropertyStore pFxProperties;
	}
}