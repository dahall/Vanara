using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from Windows Core Audio Api.</summary>
public static partial class CoreAudio
{
	/// <summary>Specifies the mapping of the two audio channels in a stereo jack to speaker positions.</summary>
	[PInvokeData("devicetopology.h", MSDNShortId = "4ee9fedf-4241-4678-b621-549a06e8949a")]
	[Flags]
	public enum ChannelMapping : uint
	{
		/// <summary>The front left</summary>
		SPEAKER_FRONT_LEFT = 0x1,

		/// <summary>The front right</summary>
		SPEAKER_FRONT_RIGHT = 0x2,

		/// <summary>The front center</summary>
		SPEAKER_FRONT_CENTER = 0x4,

		/// <summary>The low frequency</summary>
		SPEAKER_LOW_FREQUENCY = 0x8,

		/// <summary>The back left</summary>
		SPEAKER_BACK_LEFT = 0x10,

		/// <summary>The back right</summary>
		SPEAKER_BACK_RIGHT = 0x20,

		/// <summary>The front left of center</summary>
		SPEAKER_FRONT_LEFT_OF_CENTER = 0x40,

		/// <summary>The front right of center</summary>
		SPEAKER_FRONT_RIGHT_OF_CENTER = 0x80,

		/// <summary>The back center</summary>
		SPEAKER_BACK_CENTER = 0x100,

		/// <summary>The side left</summary>
		SPEAKER_SIDE_LEFT = 0x200,

		/// <summary>The side right</summary>
		SPEAKER_SIDE_RIGHT = 0x400,

		/// <summary>The top center</summary>
		SPEAKER_TOP_CENTER = 0x800,

		/// <summary>The top front left</summary>
		SPEAKER_TOP_FRONT_LEFT = 0x1000,

		/// <summary>The top front center</summary>
		SPEAKER_TOP_FRONT_CENTER = 0x2000,

		/// <summary>The top front right</summary>
		SPEAKER_TOP_FRONT_RIGHT = 0x4000,

		/// <summary>The top back left</summary>
		SPEAKER_TOP_BACK_LEFT = 0x8000,

		/// <summary>The top back center</summary>
		SPEAKER_TOP_BACK_CENTER = 0x10000,

		/// <summary>The top back right</summary>
		SPEAKER_TOP_BACK_RIGHT = 0x20000,
	}

	/// <summary>The <c>ConnectorType</c> enumeration indicates the type of connection that a connector is part of.</summary>
	/// <remarks>
	/// <para>The IConnector::GetType method uses the constants defined in the <c>ConnectorType</c> enumeration.</para>
	/// <para>For more information about connector types, see Device Topologies.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/ne-devicetopology-connectortype typedef enum
	// __MIDL___MIDL_itf_devicetopology_0000_0000_0013 { Unknown_Connector, Physical_Internal, Physical_External, Software_IO,
	// Software_Fixed, Network } ConnectorType;
	[PInvokeData("devicetopology.h", MSDNShortId = "7171a880-2a3e-45aa-803d-26bf5e9e0365")]
	public enum ConnectorType
	{
		/// <summary>The connector is part of a connection of unknown type.</summary>
		Unknown_Connector,

		/// <summary>
		/// The connector is part of a physical connection to an auxiliary device that is installed inside the system chassis (for
		/// example, a connection to the analog output of an internal CD player, or to a built-in microphone or built-in speakers in a
		/// laptop computer).
		/// </summary>
		Physical_Internal,

		/// <summary>
		/// The connector is part of a physical connection to an external device. That is, the connector is a user-accessible jack that
		/// connects to a microphone, speakers, headphones, S/PDIF input or output device, or line input or output device.
		/// </summary>
		Physical_External,

		/// <summary>
		/// The connector is part of a software-configured I/O connection (typically a DMA channel) between system memory and an audio
		/// hardware device on an audio adapter.
		/// </summary>
		Software_IO,

		/// <summary>
		/// The connector is part of a permanent connection that is fixed and cannot be configured under software control. This type of
		/// connection is typically used to connect two audio hardware devices that reside on the same adapter.
		/// </summary>
		Software_Fixed,

		/// <summary>The connector is part of a connection to a network.</summary>
		Network,
	}

	/// <summary>The <c>DataFlow</c> enumeration indicates the data-flow direction of an audio stream through a connector.</summary>
	/// <remarks>
	/// <para>The IConnector::GetDataFlow method uses the constants defined in the <c>DataFlow</c> enumeration.</para>
	/// <para>
	/// The topology of a rendering or capture device on an audio adapter typically has one or more connectors with a data-flow
	/// direction of "In" through which audio data enters the device, and one or more connectors with a data-flow direction of "Out"
	/// through which audio data exits the device. For example, a typical rendering device on an adapter has a connector with data-flow
	/// direction "In" through which the Windows audio engine streams PCM data into the device. The same device has a connector with
	/// data-flow direction "Out" through which the device transmits an audio signal to speakers or headphones.
	/// </para>
	/// <para>
	/// The topology of a rendering endpoint device (for example, headphones) has a single connector with data-flow direction "In"
	/// through which audio data (in the form of an analog signal) enters the device.
	/// </para>
	/// <para>
	/// The topology of a capture endpoint device (for example, a microphone) has a single connector with data-flow direction "Out"
	/// through which audio data exits the device.
	/// </para>
	/// <para>For more information, see Device Topologies.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/ne-devicetopology-dataflow typedef enum
	// __MIDL___MIDL_itf_devicetopology_0000_0000_0011 { In, Out } DataFlow;
	[PInvokeData("devicetopology.h", MSDNShortId = "bdc2336c-5609-43f2-9b65-d8806f0fc63b")]
	public enum DataFlow
	{
		/// <summary>Input stream. The audio stream flows into the device through the connector.</summary>
		In,

		/// <summary>Output stream. The audio stream flows out of the device through the connector.</summary>
		Out,
	}

	/// <summary>Specifies the physical connection type for this jack.</summary>
	[PInvokeData("Ksmedia.h", MSDNShortId = "303bc73a-fe47-499b-97b3-7c49a40e8cfa")]
	public enum EPcxConnectionType
	{
		/// <summary>Unknown</summary>
		eConnTypeUnknown,

		/// <summary>3.5 mm minijack</summary>
		eConnType3Point5mm,

		/// <summary>1/4-inch jack</summary>
		eConnTypeQuarter,

		/// <summary>ATAPI internal connector</summary>
		eConnTypeAtapiInternal,

		/// <summary>RCA jack</summary>
		eConnTypeRCA,

		/// <summary>Optical connector</summary>
		eConnTypeOptical,

		/// <summary>Generic digital connector</summary>
		eConnTypeOtherDigital,

		/// <summary>Generic analog connector</summary>
		eConnTypeOtherAnalog,

		/// <summary>Multichannel analog DIN connector</summary>
		eConnTypeMultichannelAnalogDIN,

		/// <summary>XLR connector</summary>
		eConnTypeXlrProfessional,

		/// <summary>RJ11 modem connector</summary>
		eConnTypeRJ11Modem,

		/// <summary>Connector combination</summary>
		eConnTypeCombination,
	}

	/// <summary>
	/// Specifies the general location of the jack. The value of this member is one of the EPcxGenLocation enumeration values shown in
	/// the following table.
	/// </summary>
	[PInvokeData("Ksmedia.h", MSDNShortId = "303bc73a-fe47-499b-97b3-7c49a40e8cfa")]
	public enum EPcxGenLocation
	{
		/// <summary>On primary chassis</summary>
		eGenLocPrimaryBox,

		/// <summary>Inside primary chassis</summary>
		eGenLocInternal,

		/// <summary>On separate chassis</summary>
		eGenLocSeparate,

		/// <summary>Other location</summary>
		eGenLocOther,

		/// <summary/>
		EPcxGenLocation_enum_count
	}

	/// <summary>
	/// The geometric location of the jack. The value of this member is one of the EPcxGeoLocation enumeration values shown in the
	/// following table.
	/// </summary>
	[PInvokeData("Ksmedia.h", MSDNShortId = "303bc73a-fe47-499b-97b3-7c49a40e8cfa")]
	public enum EPcxGeoLocation
	{
		/// <summary>Rear</summary>
		eGeoLocRear = 0x1,

		/// <summary>Front</summary>
		eGeoLocFront,

		/// <summary>Left</summary>
		eGeoLocLeft,

		/// <summary>Right</summary>
		eGeoLocRight,

		/// <summary>Top</summary>
		eGeoLocTop,

		/// <summary>Bottom</summary>
		eGeoLocBottom,

		/// <summary>Rear slide-open or pull-open panel</summary>
		eGeoLocRearPanel,

		/// <summary>Riser card</summary>
		eGeoLocRiser,

		/// <summary>Inside lid of mobile computer</summary>
		eGeoLocInsideMobileLid,

		/// <summary>Drive bay</summary>
		eGeoLocDrivebay,

		/// <summary>HDMI connector</summary>
		eGeoLocHDMI,

		/// <summary>Outside lid of mobile computer</summary>
		eGeoLocOutsideMobileLid,

		/// <summary>ATAPI connector</summary>
		eGeoLocATAPI,

		/// <summary>Not applicable. See Remarks section.</summary>
		eGeoLocNotApplicable,

		/// <summary/>
		eGeoLocReserved6,

		/// <summary/>
		EPcxGeoLocation_enum_count
	}

	/// <summary>
	/// Specifies the type of port represented by the jack. The value of this member is one of the EPxcPortConnection enumeration values
	/// shown in the following table.
	/// </summary>
	[PInvokeData("Ksmedia.h", MSDNShortId = "303bc73a-fe47-499b-97b3-7c49a40e8cfa")]
	public enum EPxcPortConnection
	{
		/// <summary>Jack</summary>
		ePortConnJack,

		/// <summary>Slot for an integrated device</summary>
		ePortConnIntegratedDevice,

		/// <summary>Both a jack and a slot for an integrated device</summary>
		ePortConnBothIntegratedAndJack,

		/// <summary>Unknown</summary>
		ePortConnUnknown,
	}

	/// <summary>Indicates the capabilities of the jack.</summary>
	[PInvokeData("Ksmedia.h", MSDNShortId = "0db29870-20d0-459b-a531-3dea5d073183")]
	public enum JackCapabilities : uint
	{
		/// <summary>Jack supports jack presence detection.</summary>
		JACKDESC2_PRESENCE_DETECT_CAPABILITY = 0x00000001,

		/// <summary>Jack supports dynamic format change.</summary>
		JACKDESC2_DYNAMIC_FORMAT_CHANGE_CAPABILITY = 0x00000002,
	}

	/// <summary>
	/// The <c>KSJACK_SINK_CONNECTIONTYPE</c> enumeration defines constants that specify the type of connection. These values are used
	/// in the KSJACK_SINK_INFORMATION structure that stores information about an audio jack sink.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/ne-devicetopology-ksjack_sink_connectiontype typedef enum
	// __MIDL___MIDL_itf_devicetopology_0000_0000_0010 { KSJACK_SINK_CONNECTIONTYPE_HDMI, KSJACK_SINK_CONNECTIONTYPE_DISPLAYPORT } KSJACK_SINK_CONNECTIONTYPE;
	[PInvokeData("devicetopology.h", MSDNShortId = "a1a9b0cf-b1bf-49df-a976-62f44fcf70ae")]
	public enum KSJACK_SINK_CONNECTIONTYPE
	{
		/// <summary>High-Definition Multimedia Interface (HDMI) connection.</summary>
		KSJACK_SINK_CONNECTIONTYPE_HDMI,

		/// <summary>Display port.</summary>
		KSJACK_SINK_CONNECTIONTYPE_DISPLAYPORT,
	}

	/// <summary>
	/// The <c>PartType</c> enumeration defines constants that indicate whether a part in a device topology is a connector or subunit.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The IPart::GetPartType method uses the constants defined in the <c>PartType</c> enumeration to indicate whether an IPart object
	/// represents a connector or a subunit. If an <c>IPart</c> object represents a connector, a client can query that that object for
	/// its IConnector interface. If an <c>IPart</c> object represents a subunit, a client can query that that object for its ISubunit interface.
	/// </para>
	/// <para>For more information about connectors and subunits, see Device Topologies.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/ne-devicetopology-parttype typedef enum
	// __MIDL___MIDL_itf_devicetopology_0000_0000_0012 { Connector, Subunit } PartType;
	[PInvokeData("devicetopology.h", MSDNShortId = "7374d6c6-c59e-4862-8b4c-bbe384ccc9d8")]
	public enum PartType
	{
		/// <summary>
		/// The part is a connector. A connector can represent an audio jack, an internal connection to an integrated endpoint device,
		/// or a software connection implemented through DMA transfers. For more information about connector types, see ConnectorType Enumeration.
		/// </summary>
		Connector,

		/// <summary>
		/// The part is a subunit. A subunit is an audio-processing node in a device topology. A subunit frequently has one or more
		/// hardware control parameters that can be set under program control. For example, an audio application can change the volume
		/// setting of a volume-control subunit.
		/// </summary>
		Subunit,
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioAutoGainControl</c> interface provides access to a hardware automatic gain control (AGC). The client obtains a
	/// reference to the <c>IAudioAutoGainControl</c> interface of a subunit by calling the IPart::Activate method with parameter refiid
	/// set to REFIID IID_IAudioAutoGainControl. The call to <c>IPart::Activate</c> succeeds only if the subunit supports the
	/// <c>IAudioAutoGainControl</c> interface. Only a subunit object that represents a hardware AGC function will support this interface.
	/// </para>
	/// <para>
	/// Most Windows audio adapter drivers support the Windows Driver Model (WDM) and use kernel-streaming (KS) properties to represent
	/// the hardware control parameters in subunits (referred to as KS nodes). The <c>IAudioAutoGainControl</c> interface provides
	/// convenient access to the KSPROPERTY_AUDIO_AGC property of a subunit that has a subtype GUID value of KSNODETYPE_AGC. To obtain
	/// the subtype GUID of a subunit, call the IPart::GetSubType method. For more information about KS properties and KS node types,
	/// see the Windows DDK documentation.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-iaudioautogaincontrol
	[PInvokeData("devicetopology.h", MSDNShortId = "f21e27e6-f3a0-418a-ad2e-e3e104dd6da2")]
	[ComImport, Guid("85401FD4-6DE4-4b9d-9869-2D6753A82F3C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioAutoGainControl
	{
		/// <summary>The <c>GetEnabled</c> method gets the current state (enabled or disabled) of the AGC.</summary>
		/// <returns>
		/// A <c>BOOL</c> variable into which the method writes the current AGC state. If the state is <c>TRUE</c>, AGC is enabled. If
		/// <c>FALSE</c>, AGC is disabled.
		/// </returns>
		/// <remarks>
		/// A disabled AGC operates in pass-through mode. In this mode, the audio stream passes through the AGC without modification.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iaudioautogaincontrol-getenabled HRESULT
		// GetEnabled( BOOL *pbEnabled );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetEnabled();

		/// <summary>The <c>SetEnabled</c> method enables or disables the AGC.</summary>
		/// <param name="bEnable">
		/// The new AGC state. If this parameter is <c>TRUE</c> (nonzero), the method enables AGC. If <c>FALSE</c>, it disables AGC.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetEnabled</c> call changes the state of the AGC control, all clients that have registered IControlChangeNotify
		/// interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c> method, a client can
		/// inspect the event-context GUID to discover whether it or another client is the source of the control-change event. If the
		/// caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
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
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Out of memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// A disabled AGC control operates in pass-through mode. In this mode, the audio stream passes through the control without modification.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iaudioautogaincontrol-setenabled HRESULT
		// SetEnabled( BOOL bEnable, LPCGUID pguidEventContext );
		void SetEnabled([In] [MarshalAs(UnmanagedType.Bool)] bool bEnable, [Optional] GuidPtr pguidEventContext);
	}

	/// <summary>
	/// The <c>IAudioBass</c> interface provides access to a hardware bass-level control. The client obtains a reference to the
	/// <c>IAudioBass</c> interface of a subunit by calling the IPart::Activate method with parameter refiid set to REFIID
	/// IID_IAudioBass. The call to <c>IPart::Activate</c> succeeds only if the subunit supports the <c>IAudioBass</c> interface. Only a
	/// subunit object that represents a hardware function for controlling the level of the bass frequencies in each channel will
	/// support this interface.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-iaudiobass
	[PInvokeData("devicetopology.h", MSDNShortId = "036ca996-8612-4905-9afa-a4c3b4624652")]
	[ComImport, Guid("A2B1A1D9-4DB3-425D-A2B2-BD335CB3E2E5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioBass : IPerChannelDbLevel
	{
		/// <summary>The <c>GetChannelCount</c> method gets the number of channels in the audio stream.</summary>
		/// <returns>A <c>UINT</c> variable into which the method writes the channel count (the number of channels in the audio stream).</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-getchannelcount
		// HRESULT GetChannelCount( UINT *pcChannels );
		new uint GetChannelCount();

		/// <summary>The <c>GetLevelRange</c> method gets the range, in decibels, of the volume level of the specified channel.</summary>
		/// <param name="nChannel">
		/// The number of the selected channel. If the audio stream has n channels, the channels are numbered from 0 to n– 1. To get the
		/// number of channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <param name="pfMinLevelDB">
		/// Pointer to a <c>float</c> variable into which the method writes the minimum volume level in decibels.
		/// </param>
		/// <param name="pfMaxLevelDB">
		/// Pointer to a <c>float</c> variable into which the method writes the maximum volume level in decibels.
		/// </param>
		/// <param name="pfStepping">
		/// Pointer to a <c>float</c> variable into which the method writes the stepping value between consecutive volume levels in the
		/// range *pfMinLevelDB to *pfMaxLevelDB. If the difference between the maximum and minimum volume levels is d decibels, and the
		/// range is divided into n steps (uniformly sized intervals), then the volume can have n + 1 discrete levels and the size of
		/// the step between consecutive levels is d / n decibels.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-getlevelrange HRESULT
		// GetLevelRange( UINT nChannel, float *pfMinLevelDB, float *pfMaxLevelDB, float *pfStepping );
		new void GetLevelRange([In] uint nChannel, out float pfMinLevelDB, out float pfMaxLevelDB, out float pfStepping);

		/// <summary>The <c>GetLevel</c> method gets the volume level, in decibels, of the specified channel.</summary>
		/// <param name="nChannel">
		/// The channel number. If the audio stream has N channels, the channels are numbered from 0 to N– 1. To get the number of
		/// channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <returns>A <c>float</c> variable into which the method writes the volume level, in decibels, of the specified channel.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-getlevel HRESULT
		// GetLevel( UINT nChannel, float *pfLevelDB );
		new float GetLevel([In] uint nChannel);

		/// <summary>The <c>SetLevel</c> method sets the volume level, in decibels, of the specified channel.</summary>
		/// <param name="nChannel">
		/// The number of the selected channel. If the audio stream has N channels, the channels are numbered from 0 to N– 1. To get the
		/// number of channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <param name="fLevelDB">
		/// The new volume level in decibels. A positive value represents gain, and a negative value represents attenuation.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetLevel</c> call changes the state of the level control, all clients that have registered IControlChangeNotify
		/// interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c> method, a client can
		/// inspect the event-context GUID to discover whether it or another client is the source of the control-change event. If the
		/// caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// <para>
		/// If the caller specifies a value for fLevelDB that is an exact stepping value, the <c>SetLevel</c> method completes
		/// successfully. A subsequent call to the IPerChannelDbLevel::GetLevel method will return either the value that was set, or one
		/// of the following values:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>If the set value was below the minimum, the <c>GetLevel</c> method returns the minimum value.</term>
		/// </item>
		/// <item>
		/// <term>If the set value was above the maximum, the <c>GetLevel</c> method returns the maximum value.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If the set value was between two stepping values, the <c>GetLevel</c> method returns a value that could be the next stepping
		/// value above or the stepping value below the set value; the relative distances from the set value to the neighboring stepping
		/// values is unimportant. The value that the <c>GetLevel</c> method returns is whichever value has more of an impact on the
		/// signal path.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-setlevel HRESULT
		// SetLevel( UINT nChannel, float fLevelDB, LPCGUID pguidEventContext );
		new void SetLevel([In] uint nChannel, [In] float fLevelDB, [Optional, In] GuidPtr pguidEventContext);

		/// <summary>
		/// The <c>SetLevelUniform</c> method sets all channels in the audio stream to the same uniform volume level, in decibels.
		/// </summary>
		/// <param name="fLevelDB">The new uniform level in decibels.</param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetLevelUniform</c> call changes the state of the level control, all clients that have registered IControlChangeNotify
		/// interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c> method, a client can
		/// inspect the event-context GUID to discover whether it or another client is the source of the control-change event. If the
		/// caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// If the specified uniform level is beyond the range that the IPerChannelDbLevel::GetLevelRange method reports for a
		/// particular channel, the <c>SetLevelUniform</c> call clamps the value for that channel to the supported range and completes
		/// successfully. A subsequent call to the IPerChannelDbLevel::GetLevel method retrieves the actual value used for that channel.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-setleveluniform
		// HRESULT SetLevelUniform( float fLevelDB, LPCGUID pguidEventContext );
		new void SetLevelUniform([In] float fLevelDB, [Optional, In] GuidPtr pguidEventContext);

		/// <summary>
		/// The <c>SetLevelAllChannels</c> method sets the volume levels, in decibels, of all the channels in the audio stream.
		/// </summary>
		/// <param name="aLevelsDB">
		/// Pointer to an array of volume levels. This parameter points to a caller-allocated <c>float</c> array into which the method
		/// writes the new volume levels, in decibels, for all the channels. The method writes the level for a particular channel into
		/// the array element whose index matches the channel number. If the audio stream contains n channels, the channels are numbered
		/// 0 to n– 1. To get the number of channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <param name="cChannels">
		/// The number of elements in the aLevelsDB array. If this parameter does not match the number of channels in the audio stream,
		/// the method fails without modifying the aLevelsDB array.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetLevelAllChannels</c> call changes the state of the level control, all clients that have registered
		/// IControlChangeNotify interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c>
		/// method, a client can inspect the event-context GUID to discover whether it or another client is the source of the
		/// control-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method
		/// receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// If the specified level value for any channel is beyond the range that the IPerChannelDbLevel::GetLevelRange method reports
		/// for that channel, the <c>SetLevelAllChannels</c> call clamps the value to the supported range and completes successfully. A
		/// subsequent call to the IPerChannelDbLevel::GetLevel method retrieves the actual value used for that channel.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-setlevelallchannels
		// HRESULT SetLevelAllChannels( float [] aLevelsDB, ULONG cChannels, LPCGUID pguidEventContext );
		new void SetLevelAllChannels([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] aLevelsDB, [In] uint cChannels, [Optional, In] GuidPtr pguidEventContext);
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioChannelConfig</c> interface provides access to a hardware channel-configuration control. The client obtains a
	/// reference to the <c>IAudioChannelConfig</c> interface of a subunit by calling the IPart::Activate method with parameter refiid
	/// set to REFIID IID_IAudioChannelConfig. The call to IPart::Activate succeeds only if the subunit supports the
	/// <c>IAudioChannelConfig</c> interface. Only a subunit object that represents a hardware channel-configuration control will
	/// support this interface.
	/// </para>
	/// <para>
	/// A client of the <c>IAudioChannelConfig</c> interface programs a hardware channel-configuration control by writing a
	/// channel-configuration mask to the control. The mask specifies the assignment of audio channels to speakers. For more information
	/// about channel-configuration masks, see the following:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The discussion of the KSPROPERTY_AUDIO_CHANNEL_CONFIG property in the Windows DDK documentation.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The white paper titled "Audio Driver Support for Home Theater Speaker Configurations" at the Audio Device Technologies for
	/// Windows website.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Most Windows audio adapter drivers support the Windows Driver Model (WDM) and use kernel-streaming (KS) properties to represent
	/// the hardware control parameters in subunits (referred to as KS nodes). The <c>IAudioChannelConfig</c> interface provides
	/// convenient access to the KSPROPERTY_AUDIO_CHANNEL_CONFIG property of a subunit that has a subtype GUID value of
	/// KSNODETYPE_3D_EFFECTS, KSNODETYPE_DAC, KSNODETYPE_VOLUME, or KSNODETYPE_PROLOGIC_DECODER. To obtain the subtype GUID of a
	/// subunit, call the IPart::GetSubType method. For more information about KS properties and KS node types, see the Windows DDK documentation.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-iaudiochannelconfig
	[PInvokeData("devicetopology.h", MSDNShortId = "b8e54e9e-a6eb-46e6-a71c-ff498c7e8f47")]
	[ComImport, Guid("BB11C46F-EC28-493C-B88A-5DB88062CE98"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioChannelConfig
	{
		/// <summary>The <c>SetChannelConfig</c> method sets the channel-configuration mask in a channel-configuration control.</summary>
		/// <param name="dwConfig">The channel-configuration mask.</param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetChannelConfig</c> call changes the state of the channel-configuration control, all clients that have registered
		/// IControlChangeNotify interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c>
		/// method, a client can inspect the event-context GUID to discover whether it or another client is the source of the
		/// control-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method
		/// receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// For information about channel-configuration masks, see the discussion of the KSPROPERTY_AUDIO_CHANNEL_CONFIG property in the
		/// Windows DDK documentation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iaudiochannelconfig-setchannelconfig
		// HRESULT SetChannelConfig( DWORD dwConfig, LPCGUID pguidEventContext );
		void SetChannelConfig(uint dwConfig, [Optional, In] GuidPtr pguidEventContext);

		/// <summary>
		/// The <c>GetChannelConfig</c> method gets the current channel-configuration mask from a channel-configuration control.
		/// </summary>
		/// <returns>A <c>DWORD</c> variable into which the method writes the current channel-configuration mask value.</returns>
		/// <remarks>
		/// For information about channel-configuration masks, see the discussion of the KSPROPERTY_AUDIO_CHANNEL_CONFIG property in the
		/// Windows DDK documentation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iaudiochannelconfig-getchannelconfig
		// HRESULT GetChannelConfig( DWORD *pdwConfig );
		uint GetChannelConfig();
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioInputSelector</c> interface provides access to a hardware multiplexer control (input selector). The client obtains
	/// a reference to the <c>IAudioInputSelector</c> interface of a subunit by calling the IPart::Activate method with parameter refiid
	/// set to REFIID IID_IAudioInputSelector. The call to <c>IPart::Activate</c> succeeds only if the subunit supports the
	/// <c>IAudioInputSelector</c> interface. Only a subunit object that represents a hardware input selector will support this interface.
	/// </para>
	/// <para>
	/// Each input of an input selector is identified by the local ID of the part (a connector or subunit of a device topology) that has
	/// a direct link to the input. A local ID is a number that uniquely identifies a part among all the parts in a device topology.
	/// </para>
	/// <para>
	/// Most Windows audio adapter drivers support the Windows Driver Model (WDM) and use kernel-streaming (KS) properties to represent
	/// the hardware control parameters in subunits (referred to as KS nodes). The <c>IAudioInputSelector</c> interface provides
	/// convenient access to the KSPROPERTY_AUDIO_MUX_SOURCE property of a subunit that has a subtype GUID value of KSNODETYPE_MUX. To
	/// obtain the subtype GUID of a subunit, call the IPart::GetSubType method. For more information about KS properties and KS node
	/// types, see the Windows DDK documentation.
	/// </para>
	/// <para>
	/// For a code example that uses the <c>IAudioInputSelector</c> interface, see the implementation of the SelectCaptureDevice
	/// function in Device Topologies.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-iaudioinputselector
	[PInvokeData("devicetopology.h", MSDNShortId = "6f5ce9c0-39e4-4fab-910c-9a11b90fcde7")]
	[ComImport, Guid("4F03DC02-5E6E-4653-8F72-A030C123D598"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioInputSelector
	{
		/// <summary>
		/// The GetSelection method gets the local ID of the part that is connected to the selector input that is currently selected.
		/// </summary>
		/// <returns>
		/// Pointer to a <c>UINT</c> variable into which the method writes the local ID of the part that directly links to the currently
		/// selected selector input.
		/// </returns>
		/// <remarks>
		/// A local ID is a number that uniquely identifies a part among all parts in a device topology. To obtain a pointer to the
		/// IPart interface of a part from its local ID, call the IDeviceTopology::GetPartById method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iaudioinputselector-getselection HRESULT
		// GetSelection( UINT *pnIdSelected );
		uint GetSelection();

		/// <summary>The <c>SetSelection</c> method selects one of the inputs of the input selector.</summary>
		/// <param name="nIdSelect">
		/// The new selector input. The caller should set this parameter to the local ID of a part that has a direct link to one of the
		/// selector inputs.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetSelection</c> call changes the state of the input-selector control, all clients that have registered
		/// IControlChangeNotify interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c>
		/// method, a client can inspect the event-context GUID to discover whether it or another client is the source of the
		/// control-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method
		/// receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// <para>
		/// A local ID is a number that uniquely identifies a part among all parts in a device topology. To obtain the local ID of a
		/// part, call the IPart::GetLocalId method on the part object.
		/// </para>
		/// <para>
		/// For a code example that calls the <c>SetSelection</c> method, see the implementation of the SelectCaptureDevice function in
		/// Device Topologies.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iaudioinputselector-setselection HRESULT
		// SetSelection( UINT nIdSelect, LPCGUID pguidEventContext );
		void SetSelection([In] uint nIdSelect, [Optional, In] GuidPtr pguidEventContext);
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioLoudness</c> interface provides access to a "loudness" compensation control. The client obtains a reference to the
	/// <c>IAudioLoudness</c> interface of a subunit by calling the IPart::Activate method with parameter refiid set to REFIID
	/// IID_IAudioLoudness. The call to <c>IPart::Activate</c> succeeds only if the subunit supports the <c>IAudioLoudness</c>
	/// interface. Only a subunit object that represents a hardware loudness control function will support this interface.
	/// </para>
	/// <para>
	/// Most Windows audio adapter drivers support the Windows Driver Model (WDM) and use kernel-streaming (KS) properties to represent
	/// the hardware control parameters in subunits (referred to as KS nodes). The <c>IAudioLoudness</c> interface provides convenient
	/// access to the KSPROPERTY_AUDIO_LOUDNESS property of a subunit that has a subtype GUID value of KSNODETYPE_LOUDNESS. To obtain
	/// the subtype GUID of a subunit, call the IPart::GetSubType method. For more information about KS properties and KS node types,
	/// see the Windows DDK documentation.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-iaudioloudness
	[PInvokeData("devicetopology.h", MSDNShortId = "c182d6ae-c55b-4e3b-9639-7c2f2f7d826d")]
	[ComImport, Guid("7D8B1437-DD53-4350-9C1B-1EE2890BD938"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioLoudness
	{
		/// <summary>The <c>GetEnabled</c> method gets the current state (enabled or disabled) of the loudness control.</summary>
		/// <returns>
		/// A <c>BOOL</c> variable into which the method writes the current loudness state. If the state is <c>TRUE</c>, loudness is
		/// enabled. If <c>FALSE</c>, loudness is disabled.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iaudioloudness-getenabled HRESULT
		// GetEnabled( BOOL *pbEnabled );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetEnabled();

		/// <summary>The <c>SetEnabled</c> method enables or disables the loudness control.</summary>
		/// <param name="bEnable">
		/// The new loudness state. If bEnable is <c>TRUE</c> (nonzero), the method enables loudness. If <c>FALSE</c>, it disables loudness.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetEnabled</c> call changes the state of the loudness control, all clients that have registered IControlChangeNotify
		/// interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c> method, a client can
		/// inspect the event-context GUID to discover whether it or another client is the source of the control-change event. If the
		/// caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iaudioloudness-setenabled HRESULT
		// SetEnabled( BOOL bEnable, LPCGUID pguidEventContext );
		void SetEnabled([MarshalAs(UnmanagedType.Bool)] bool bEnable, [Optional, In] GuidPtr pguidEventContext);
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioMidrange</c> interface provides access to a hardware midrange-level control. The client obtains a reference to the
	/// <c>IAudioMidrange</c> interface of a subunit by calling the IPart::Activate method with parameter refiid set to REFIID
	/// IID_IAudioMidrange. The call to <c>IPart::Activate</c> succeeds only if the subunit supports the <c>IAudioMidrange</c>
	/// interface. Only a subunit object that represents a hardware function for controlling the level of the mid-range frequencies in
	/// each channel will support this interface.
	/// </para>
	/// <para>
	/// The <c>IAudioMidrange</c> interface provides per-channel controls for setting and getting the gain or attenuation level of the
	/// midrange frequencies in the audio stream. If a midrange-level hardware control can only attenuate the channels in the audio
	/// stream, then the maximum midrange level for any channel is 0 dB. If a midrange-level control can provide gain (amplification),
	/// then the maximum midrange level is greater than 0 dB.
	/// </para>
	/// <para>
	/// Most Windows audio adapter drivers support the Windows Driver Model (WDM) and use kernel-streaming (KS) properties to represent
	/// the hardware control parameters in subunits (referred to as KS nodes). The <c>IAudioMidrange</c> interface provides convenient
	/// access to the KSPROPERTY_AUDIO_MID property of a subunit that has a subtype GUID value of KSNODETYPE_TONE. To obtain the subtype
	/// GUID of a subunit, call the IPart::GetSubType method. For more information about KS properties and KS node types, see the
	/// Windows DDK documentation.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-iaudiomidrange
	[PInvokeData("devicetopology.h", MSDNShortId = "d2d93dba-1867-4c3a-9cd1-60842bf8311d")]
	[ComImport, Guid("5E54B6D7-B44B-40D9-9A9E-E691D9CE6EDF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioMidrange : IPerChannelDbLevel
	{
		/// <summary>The <c>GetChannelCount</c> method gets the number of channels in the audio stream.</summary>
		/// <returns>A <c>UINT</c> variable into which the method writes the channel count (the number of channels in the audio stream).</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-getchannelcount
		// HRESULT GetChannelCount( UINT *pcChannels );
		new uint GetChannelCount();

		/// <summary>The <c>GetLevelRange</c> method gets the range, in decibels, of the volume level of the specified channel.</summary>
		/// <param name="nChannel">
		/// The number of the selected channel. If the audio stream has n channels, the channels are numbered from 0 to n– 1. To get the
		/// number of channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <param name="pfMinLevelDB">
		/// Pointer to a <c>float</c> variable into which the method writes the minimum volume level in decibels.
		/// </param>
		/// <param name="pfMaxLevelDB">
		/// Pointer to a <c>float</c> variable into which the method writes the maximum volume level in decibels.
		/// </param>
		/// <param name="pfStepping">
		/// Pointer to a <c>float</c> variable into which the method writes the stepping value between consecutive volume levels in the
		/// range *pfMinLevelDB to *pfMaxLevelDB. If the difference between the maximum and minimum volume levels is d decibels, and the
		/// range is divided into n steps (uniformly sized intervals), then the volume can have n + 1 discrete levels and the size of
		/// the step between consecutive levels is d / n decibels.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-getlevelrange HRESULT
		// GetLevelRange( UINT nChannel, float *pfMinLevelDB, float *pfMaxLevelDB, float *pfStepping );
		new void GetLevelRange([In] uint nChannel, out float pfMinLevelDB, out float pfMaxLevelDB, out float pfStepping);

		/// <summary>The <c>GetLevel</c> method gets the volume level, in decibels, of the specified channel.</summary>
		/// <param name="nChannel">
		/// The channel number. If the audio stream has N channels, the channels are numbered from 0 to N– 1. To get the number of
		/// channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <returns>A <c>float</c> variable into which the method writes the volume level, in decibels, of the specified channel.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-getlevel HRESULT
		// GetLevel( UINT nChannel, float *pfLevelDB );
		new float GetLevel([In] uint nChannel);

		/// <summary>The <c>SetLevel</c> method sets the volume level, in decibels, of the specified channel.</summary>
		/// <param name="nChannel">
		/// The number of the selected channel. If the audio stream has N channels, the channels are numbered from 0 to N– 1. To get the
		/// number of channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <param name="fLevelDB">
		/// The new volume level in decibels. A positive value represents gain, and a negative value represents attenuation.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetLevel</c> call changes the state of the level control, all clients that have registered IControlChangeNotify
		/// interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c> method, a client can
		/// inspect the event-context GUID to discover whether it or another client is the source of the control-change event. If the
		/// caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// <para>
		/// If the caller specifies a value for fLevelDB that is an exact stepping value, the <c>SetLevel</c> method completes
		/// successfully. A subsequent call to the IPerChannelDbLevel::GetLevel method will return either the value that was set, or one
		/// of the following values:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>If the set value was below the minimum, the <c>GetLevel</c> method returns the minimum value.</term>
		/// </item>
		/// <item>
		/// <term>If the set value was above the maximum, the <c>GetLevel</c> method returns the maximum value.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If the set value was between two stepping values, the <c>GetLevel</c> method returns a value that could be the next stepping
		/// value above or the stepping value below the set value; the relative distances from the set value to the neighboring stepping
		/// values is unimportant. The value that the <c>GetLevel</c> method returns is whichever value has more of an impact on the
		/// signal path.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-setlevel HRESULT
		// SetLevel( UINT nChannel, float fLevelDB, LPCGUID pguidEventContext );
		new void SetLevel([In] uint nChannel, [In] float fLevelDB, [Optional, In] GuidPtr pguidEventContext);

		/// <summary>
		/// The <c>SetLevelUniform</c> method sets all channels in the audio stream to the same uniform volume level, in decibels.
		/// </summary>
		/// <param name="fLevelDB">The new uniform level in decibels.</param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetLevelUniform</c> call changes the state of the level control, all clients that have registered IControlChangeNotify
		/// interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c> method, a client can
		/// inspect the event-context GUID to discover whether it or another client is the source of the control-change event. If the
		/// caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// If the specified uniform level is beyond the range that the IPerChannelDbLevel::GetLevelRange method reports for a
		/// particular channel, the <c>SetLevelUniform</c> call clamps the value for that channel to the supported range and completes
		/// successfully. A subsequent call to the IPerChannelDbLevel::GetLevel method retrieves the actual value used for that channel.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-setleveluniform
		// HRESULT SetLevelUniform( float fLevelDB, LPCGUID pguidEventContext );
		new void SetLevelUniform([In] float fLevelDB, [Optional, In] GuidPtr pguidEventContext);

		/// <summary>
		/// The <c>SetLevelAllChannels</c> method sets the volume levels, in decibels, of all the channels in the audio stream.
		/// </summary>
		/// <param name="aLevelsDB">
		/// Pointer to an array of volume levels. This parameter points to a caller-allocated <c>float</c> array into which the method
		/// writes the new volume levels, in decibels, for all the channels. The method writes the level for a particular channel into
		/// the array element whose index matches the channel number. If the audio stream contains n channels, the channels are numbered
		/// 0 to n– 1. To get the number of channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <param name="cChannels">
		/// The number of elements in the aLevelsDB array. If this parameter does not match the number of channels in the audio stream,
		/// the method fails without modifying the aLevelsDB array.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetLevelAllChannels</c> call changes the state of the level control, all clients that have registered
		/// IControlChangeNotify interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c>
		/// method, a client can inspect the event-context GUID to discover whether it or another client is the source of the
		/// control-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method
		/// receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// If the specified level value for any channel is beyond the range that the IPerChannelDbLevel::GetLevelRange method reports
		/// for that channel, the <c>SetLevelAllChannels</c> call clamps the value to the supported range and completes successfully. A
		/// subsequent call to the IPerChannelDbLevel::GetLevel method retrieves the actual value used for that channel.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-setlevelallchannels
		// HRESULT SetLevelAllChannels( float [] aLevelsDB, ULONG cChannels, LPCGUID pguidEventContext );
		new void SetLevelAllChannels([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] aLevelsDB, [In] uint cChannels, [Optional, In] GuidPtr pguidEventContext);
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioMute</c> interface provides access to a hardware mute control. The client obtains a reference to the
	/// <c>IAudioMute</c> interface of a subunit by calling the IPart::Activate method with parameter refiid set to REFIID
	/// IID_IAudioMute. The call to <c>IPart::Activate</c> succeeds only if the subunit supports the <c>IAudioMute</c> interface. Only a
	/// subunit object that represents a hardware mute control function will support this interface.
	/// </para>
	/// <para>
	/// Most Windows audio adapter drivers support the Windows Driver Model (WDM) and use kernel-streaming (KS) properties to represent
	/// the hardware control parameters in subunits (referred to as KS nodes). The <c>IAudioMute</c> interface provides convenient
	/// access to the KSPROPERTY_AUDIO_MUTE property of a subunit that has a subtype GUID value of KSNODETYPE_MUTE. To obtain the
	/// subtype GUID of a subunit, call the IPart::GetSubType method. For more information about KS properties and KS node types, see
	/// the Windows DDK documentation.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-iaudiomute
	[PInvokeData("devicetopology.h", MSDNShortId = "53d49af7-81c3-4e75-ba06-dcee34d84292")]
	[ComImport, Guid("DF45AEEA-B74A-4B6B-AFAD-2366B6AA012E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioMute
	{
		/// <summary>The <c>SetMute</c> method enables or disables the mute control.</summary>
		/// <param name="bMuted">
		/// The new muting state. If bMuted is <c>TRUE</c> (nonzero), the method enables muting. If <c>FALSE</c>, the method disables muting.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetMute</c> call changes the state of the mute control, all clients that have registered IControlChangeNotify interfaces
		/// with that control receive notifications. In its implementation of the <c>OnNotify</c> method, a client can inspect the
		/// event-context GUID to discover whether it or another client is the source of the control-change event. If the caller
		/// supplies a <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iaudiomute-setmute HRESULT SetMute( BOOL
		// bMuted, LPCGUID pguidEventContext );
		void SetMute([In] [MarshalAs(UnmanagedType.Bool)] bool bMuted, [Optional, In] GuidPtr pguidEventContext);

		/// <summary>The <c>GetMute</c> method gets the current state (enabled or disabled) of the mute control.</summary>
		/// <returns>
		/// Pointer to a <c>BOOL</c> variable into which the method writes the current state of the mute control. If the state is
		/// <c>TRUE</c>, muting is enabled. If <c>FALSE</c>, it is disabled.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iaudiomute-getmute HRESULT GetMute( BOOL
		// *pbMuted );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetMute();
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioOutputSelector</c> interface provides access to a hardware demultiplexer control (output selector). The client
	/// obtains a reference to the <c>IAudioOutputSelector</c> interface of a subunit by calling the IPart::Activate method with
	/// parameter refiid set to REFIID IID_IAudioOutputSelector. The call to <c>IPart::Activate</c> succeeds only if the subunit
	/// supports the <c>IAudioOutputSelector</c> interface. Only a subunit object that represents a hardware output selector will
	/// support this interface.
	/// </para>
	/// <para>
	/// Each output of an output selector is identified by the local ID of the part (a connector or subunit of a device topology) with a
	/// direct link to the output. A local ID is a number that uniquely identifies a part among all the parts in a device topology.
	/// </para>
	/// <para>
	/// Most Windows audio adapter drivers support the Windows Driver Model (WDM) and use kernel-streaming (KS) properties to represent
	/// the hardware control parameters in subunits (referred to as KS nodes). The <c>IAudioOutputSelector</c> interface provides
	/// convenient access to the KSPROPERTY_AUDIO_DEMUX_DEST property of a subunit that has a subtype GUID value of KSNODETYPE_DEMUX. To
	/// obtain the subtype GUID of a subunit, call the IPart::GetSubType method. For more information about KS properties and KS node
	/// types, see the Windows DDK documentation.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-iaudiooutputselector
	[PInvokeData("devicetopology.h", MSDNShortId = "571a44b6-972f-4d75-a31f-0e02cf728764")]
	[ComImport, Guid("BB515F69-94A7-429e-8B9C-271B3F11A3AB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioOutputSelector
	{
		/// <summary>
		/// The <c>GetSelection</c> method gets the local ID of the part that is connected to the selector output that is currently selected.
		/// </summary>
		/// <returns>
		/// Pointer to a <c>UINT</c> variable into which the method writes the local ID of the part that has a direct link to the
		/// currently selected selector output.
		/// </returns>
		/// <remarks>
		/// A local ID is a number that uniquely identifies a part among all parts in a device topology. To obtain a pointer to the
		/// IPart interface of a part from its local ID, call the IDeviceTopology::GetPartById method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iaudiooutputselector-getselection HRESULT
		// GetSelection( UINT *pnIdSelected );
		uint GetSelection();

		/// <summary>The <c>SetSelection</c> method selects one of the outputs of the output selector.</summary>
		/// <param name="nIdSelect">
		/// The new selector output. The caller should set this parameter to the local ID of a part that has a direct link to one of the
		/// selector outputs.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetSelection</c> call changes the state of the output-selector control, all clients that have registered
		/// IControlChangeNotify interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c>
		/// method, a client can inspect the event-context GUID to discover whether it or another client is the source of the
		/// control-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method
		/// receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// A local ID is a number that uniquely identifies a part among all parts in a device topology. To obtain the local ID of a
		/// part, call the IPart::GetLocalId method on the part object.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iaudiooutputselector-setselection HRESULT
		// SetSelection( UINT nIdSelect, LPCGUID pguidEventContext );
		void SetSelection([In] uint nIdSelect, [Optional, In] GuidPtr pguidEventContext);
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioPeakMeter</c> interface provides access to a hardware peak-meter control. The client obtains a reference to the
	/// <c>IAudioPeakMeter</c> interface of a subunit by calling the IPart::Activate method with parameter refiid set to REFIID
	/// IID_IAudioPeakMeter. The call to <c>IPart::Activate</c> succeeds only if the subunit supports the <c>IAudioPeakMeter</c>
	/// interface. Only a subunit object that represents a hardware peak meter will support this interface.
	/// </para>
	/// <para>
	/// Most Windows audio adapter drivers support the Windows Driver Model (WDM) and use kernel-streaming (KS) properties to represent
	/// the hardware control parameters in subunits (referred to as KS nodes). The <c>IAudioPeakMeter</c> interface provides convenient
	/// access to the KSPROPERTY_AUDIO_PEAKMETER property of a subunit that has a subtype GUID value of KSNODETYPE_PEAKMETER. To obtain
	/// the subtype GUID of a subunit, call the IPart::GetSubType method. For more information about KS properties and KS node types,
	/// see the Windows DDK documentation.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-iaudiopeakmeter
	[PInvokeData("devicetopology.h", MSDNShortId = "524d83ff-4303-448c-a070-58d17dec03ba")]
	[ComImport, Guid("DD79923C-0599-45e0-B8B6-C8DF7DB6E796"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioPeakMeter
	{
		/// <summary>The <c>GetChannelCount</c> method gets the number of channels in the audio stream.</summary>
		/// <returns>A <c>UINT</c> variable into which the method writes the channel count.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iaudiopeakmeter-getchannelcount HRESULT
		// GetChannelCount( UINT *pcChannels );
		uint GetChannelCount();

		/// <summary>
		/// The <c>GetLevel</c> method gets the peak level that the peak meter recorded for the specified channel since the peak level
		/// for that channel was previously read.
		/// </summary>
		/// <param name="nChannel">
		/// The channel number. If the audio stream has N channels, the channels are numbered from 0 to N– 1. To get the number of
		/// channels in the stream, call the IAudioPeakMeter::GetChannelCount method.
		/// </param>
		/// <returns>A <c>float</c> variable into which the method writes the peak meter level in decibels.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iaudiopeakmeter-getlevel HRESULT
		// GetLevel( UINT nChannel, float *pfLevel );
		float GetLevel([In] uint nChannel);
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioTreble</c> interface provides access to a hardware treble-level control. The client obtains a reference to the
	/// <c>IAudioTreble</c> interface of a subunit by calling the IPart::Activate method with parameter refiid set to REFIID
	/// IID_IAudioTreble. The call to <c>IPart::Activate</c> succeeds only if the subunit supports the <c>IAudioTreble</c> interface.
	/// Only a subunit object that represents a hardware function for controlling the level of the treble frequencies in each channel
	/// will support this interface.
	/// </para>
	/// <para>
	/// The <c>IAudioTreble</c> interface provides per-channel controls for setting and getting the gain or attenuation level of the
	/// treble frequencies in the audio stream. If a treble-level hardware control can only attenuate the channels in the audio stream,
	/// then the maximum treble level for any channel is 0 dB. If a treble-level control can provide gain (amplification), then the
	/// maximum treble level is greater than 0 dB.
	/// </para>
	/// <para>
	/// Most Windows audio adapter drivers support the Windows Driver Model (WDM) and use kernel-streaming (KS) properties to represent
	/// the hardware control parameters in subunits (referred to as KS nodes). The <c>IAudioTreble</c> interface provides convenient
	/// access to the KSPROPERTY_AUDIO_TREBLE property of a subunit that has a subtype GUID value of KSNODETYPE_TONE. To obtain the
	/// subtype GUID of a subunit, call the IPart::GetSubType method. For more information about KS properties and KS node types, see
	/// the Windows DDK documentation.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-iaudiotreble
	[PInvokeData("devicetopology.h", MSDNShortId = "3ace174e-c21c-41e7-9830-80d247d8437f")]
	[ComImport, Guid("0A717812-694E-4907-B74B-BAFA5CFDCA7B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioTreble : IPerChannelDbLevel
	{
		/// <summary>The <c>GetChannelCount</c> method gets the number of channels in the audio stream.</summary>
		/// <returns>A <c>UINT</c> variable into which the method writes the channel count (the number of channels in the audio stream).</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-getchannelcount
		// HRESULT GetChannelCount( UINT *pcChannels );
		new uint GetChannelCount();

		/// <summary>The <c>GetLevelRange</c> method gets the range, in decibels, of the volume level of the specified channel.</summary>
		/// <param name="nChannel">
		/// The number of the selected channel. If the audio stream has n channels, the channels are numbered from 0 to n– 1. To get the
		/// number of channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <param name="pfMinLevelDB">
		/// Pointer to a <c>float</c> variable into which the method writes the minimum volume level in decibels.
		/// </param>
		/// <param name="pfMaxLevelDB">
		/// Pointer to a <c>float</c> variable into which the method writes the maximum volume level in decibels.
		/// </param>
		/// <param name="pfStepping">
		/// Pointer to a <c>float</c> variable into which the method writes the stepping value between consecutive volume levels in the
		/// range *pfMinLevelDB to *pfMaxLevelDB. If the difference between the maximum and minimum volume levels is d decibels, and the
		/// range is divided into n steps (uniformly sized intervals), then the volume can have n + 1 discrete levels and the size of
		/// the step between consecutive levels is d / n decibels.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-getlevelrange HRESULT
		// GetLevelRange( UINT nChannel, float *pfMinLevelDB, float *pfMaxLevelDB, float *pfStepping );
		new void GetLevelRange([In] uint nChannel, out float pfMinLevelDB, out float pfMaxLevelDB, out float pfStepping);

		/// <summary>The <c>GetLevel</c> method gets the volume level, in decibels, of the specified channel.</summary>
		/// <param name="nChannel">
		/// The channel number. If the audio stream has N channels, the channels are numbered from 0 to N– 1. To get the number of
		/// channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <returns>A <c>float</c> variable into which the method writes the volume level, in decibels, of the specified channel.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-getlevel HRESULT
		// GetLevel( UINT nChannel, float *pfLevelDB );
		new float GetLevel([In] uint nChannel);

		/// <summary>The <c>SetLevel</c> method sets the volume level, in decibels, of the specified channel.</summary>
		/// <param name="nChannel">
		/// The number of the selected channel. If the audio stream has N channels, the channels are numbered from 0 to N– 1. To get the
		/// number of channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <param name="fLevelDB">
		/// The new volume level in decibels. A positive value represents gain, and a negative value represents attenuation.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetLevel</c> call changes the state of the level control, all clients that have registered IControlChangeNotify
		/// interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c> method, a client can
		/// inspect the event-context GUID to discover whether it or another client is the source of the control-change event. If the
		/// caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// <para>
		/// If the caller specifies a value for fLevelDB that is an exact stepping value, the <c>SetLevel</c> method completes
		/// successfully. A subsequent call to the IPerChannelDbLevel::GetLevel method will return either the value that was set, or one
		/// of the following values:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>If the set value was below the minimum, the <c>GetLevel</c> method returns the minimum value.</term>
		/// </item>
		/// <item>
		/// <term>If the set value was above the maximum, the <c>GetLevel</c> method returns the maximum value.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If the set value was between two stepping values, the <c>GetLevel</c> method returns a value that could be the next stepping
		/// value above or the stepping value below the set value; the relative distances from the set value to the neighboring stepping
		/// values is unimportant. The value that the <c>GetLevel</c> method returns is whichever value has more of an impact on the
		/// signal path.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-setlevel HRESULT
		// SetLevel( UINT nChannel, float fLevelDB, LPCGUID pguidEventContext );
		new void SetLevel([In] uint nChannel, [In] float fLevelDB, [Optional, In] GuidPtr pguidEventContext);

		/// <summary>
		/// The <c>SetLevelUniform</c> method sets all channels in the audio stream to the same uniform volume level, in decibels.
		/// </summary>
		/// <param name="fLevelDB">The new uniform level in decibels.</param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetLevelUniform</c> call changes the state of the level control, all clients that have registered IControlChangeNotify
		/// interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c> method, a client can
		/// inspect the event-context GUID to discover whether it or another client is the source of the control-change event. If the
		/// caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// If the specified uniform level is beyond the range that the IPerChannelDbLevel::GetLevelRange method reports for a
		/// particular channel, the <c>SetLevelUniform</c> call clamps the value for that channel to the supported range and completes
		/// successfully. A subsequent call to the IPerChannelDbLevel::GetLevel method retrieves the actual value used for that channel.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-setleveluniform
		// HRESULT SetLevelUniform( float fLevelDB, LPCGUID pguidEventContext );
		new void SetLevelUniform([In] float fLevelDB, [Optional, In] GuidPtr pguidEventContext);

		/// <summary>
		/// The <c>SetLevelAllChannels</c> method sets the volume levels, in decibels, of all the channels in the audio stream.
		/// </summary>
		/// <param name="aLevelsDB">
		/// Pointer to an array of volume levels. This parameter points to a caller-allocated <c>float</c> array into which the method
		/// writes the new volume levels, in decibels, for all the channels. The method writes the level for a particular channel into
		/// the array element whose index matches the channel number. If the audio stream contains n channels, the channels are numbered
		/// 0 to n– 1. To get the number of channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <param name="cChannels">
		/// The number of elements in the aLevelsDB array. If this parameter does not match the number of channels in the audio stream,
		/// the method fails without modifying the aLevelsDB array.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetLevelAllChannels</c> call changes the state of the level control, all clients that have registered
		/// IControlChangeNotify interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c>
		/// method, a client can inspect the event-context GUID to discover whether it or another client is the source of the
		/// control-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method
		/// receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// If the specified level value for any channel is beyond the range that the IPerChannelDbLevel::GetLevelRange method reports
		/// for that channel, the <c>SetLevelAllChannels</c> call clamps the value to the supported range and completes successfully. A
		/// subsequent call to the IPerChannelDbLevel::GetLevel method retrieves the actual value used for that channel.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-setlevelallchannels
		// HRESULT SetLevelAllChannels( float [] aLevelsDB, ULONG cChannels, LPCGUID pguidEventContext );
		new void SetLevelAllChannels([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] aLevelsDB, [In] uint cChannels, [Optional, In] GuidPtr pguidEventContext);
	}

	/// <summary>
	/// <para>
	/// The <c>IAudioVolumeLevel</c> interface provides access to a hardware volume control. The client obtains a reference to the
	/// <c>IAudioVolumeLevel</c> interface of a subunit by calling the IPart::Activate method with parameter refiid set to REFIID
	/// IID_IAudioVolumeLevel. The call to <c>IPart::Activate</c> succeeds only if the subunit supports the <c>IAudioVolumeLevel</c>
	/// interface. Only a subunit object that represents a hardware volume-level control will support this interface.
	/// </para>
	/// <para>
	/// The <c>IAudioVolumeLevel</c> interface provides per-channel controls for setting and getting the gain or attenuation levels in
	/// an the audio stream. If a volume-level hardware control can only attenuate the channels in the audio stream, then the maximum
	/// volume level for any channel is 0 dB. If a volume-level control can provide gain (amplification), then the maximum volume level
	/// is greater than 0 dB.
	/// </para>
	/// <para>
	/// Most Windows audio adapter drivers support the Windows Driver Model (WDM) and use kernel-streaming (KS) properties to represent
	/// the hardware control parameters in subunits (referred to as KS nodes). The <c>IAudioVolumeLevel</c> interface provides
	/// convenient access to the KSPROPERTY_AUDIO_VOLUMELEVEL property of a subunit that has a subtype GUID value of KSNODETYPE_VOLUME.
	/// To obtain the subtype GUID of a subunit, call the IPart::GetSubType method. For more information about KS properties and KS node
	/// types, see the Windows DDK documentation.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-iaudiovolumelevel
	[PInvokeData("devicetopology.h", MSDNShortId = "5e7d7111-e4b0-43b3-af35-9878d1a19e5f")]
	[ComImport, Guid("7FB7B48F-531D-44A2-BCB3-5AD5A134B3DC"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioVolumeLevel : IPerChannelDbLevel
	{
		/// <summary>The <c>GetChannelCount</c> method gets the number of channels in the audio stream.</summary>
		/// <returns>A <c>UINT</c> variable into which the method writes the channel count (the number of channels in the audio stream).</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-getchannelcount
		// HRESULT GetChannelCount( UINT *pcChannels );
		new uint GetChannelCount();

		/// <summary>The <c>GetLevelRange</c> method gets the range, in decibels, of the volume level of the specified channel.</summary>
		/// <param name="nChannel">
		/// The number of the selected channel. If the audio stream has n channels, the channels are numbered from 0 to n– 1. To get the
		/// number of channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <param name="pfMinLevelDB">
		/// Pointer to a <c>float</c> variable into which the method writes the minimum volume level in decibels.
		/// </param>
		/// <param name="pfMaxLevelDB">
		/// Pointer to a <c>float</c> variable into which the method writes the maximum volume level in decibels.
		/// </param>
		/// <param name="pfStepping">
		/// Pointer to a <c>float</c> variable into which the method writes the stepping value between consecutive volume levels in the
		/// range *pfMinLevelDB to *pfMaxLevelDB. If the difference between the maximum and minimum volume levels is d decibels, and the
		/// range is divided into n steps (uniformly sized intervals), then the volume can have n + 1 discrete levels and the size of
		/// the step between consecutive levels is d / n decibels.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-getlevelrange HRESULT
		// GetLevelRange( UINT nChannel, float *pfMinLevelDB, float *pfMaxLevelDB, float *pfStepping );
		new void GetLevelRange([In] uint nChannel, out float pfMinLevelDB, out float pfMaxLevelDB, out float pfStepping);

		/// <summary>The <c>GetLevel</c> method gets the volume level, in decibels, of the specified channel.</summary>
		/// <param name="nChannel">
		/// The channel number. If the audio stream has N channels, the channels are numbered from 0 to N– 1. To get the number of
		/// channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <returns>A <c>float</c> variable into which the method writes the volume level, in decibels, of the specified channel.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-getlevel HRESULT
		// GetLevel( UINT nChannel, float *pfLevelDB );
		new float GetLevel([In] uint nChannel);

		/// <summary>The <c>SetLevel</c> method sets the volume level, in decibels, of the specified channel.</summary>
		/// <param name="nChannel">
		/// The number of the selected channel. If the audio stream has N channels, the channels are numbered from 0 to N– 1. To get the
		/// number of channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <param name="fLevelDB">
		/// The new volume level in decibels. A positive value represents gain, and a negative value represents attenuation.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetLevel</c> call changes the state of the level control, all clients that have registered IControlChangeNotify
		/// interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c> method, a client can
		/// inspect the event-context GUID to discover whether it or another client is the source of the control-change event. If the
		/// caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// <para>
		/// If the caller specifies a value for fLevelDB that is an exact stepping value, the <c>SetLevel</c> method completes
		/// successfully. A subsequent call to the IPerChannelDbLevel::GetLevel method will return either the value that was set, or one
		/// of the following values:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>If the set value was below the minimum, the <c>GetLevel</c> method returns the minimum value.</term>
		/// </item>
		/// <item>
		/// <term>If the set value was above the maximum, the <c>GetLevel</c> method returns the maximum value.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If the set value was between two stepping values, the <c>GetLevel</c> method returns a value that could be the next stepping
		/// value above or the stepping value below the set value; the relative distances from the set value to the neighboring stepping
		/// values is unimportant. The value that the <c>GetLevel</c> method returns is whichever value has more of an impact on the
		/// signal path.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-setlevel HRESULT
		// SetLevel( UINT nChannel, float fLevelDB, LPCGUID pguidEventContext );
		new void SetLevel([In] uint nChannel, [In] float fLevelDB, [Optional, In] GuidPtr pguidEventContext);

		/// <summary>
		/// The <c>SetLevelUniform</c> method sets all channels in the audio stream to the same uniform volume level, in decibels.
		/// </summary>
		/// <param name="fLevelDB">The new uniform level in decibels.</param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetLevelUniform</c> call changes the state of the level control, all clients that have registered IControlChangeNotify
		/// interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c> method, a client can
		/// inspect the event-context GUID to discover whether it or another client is the source of the control-change event. If the
		/// caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// If the specified uniform level is beyond the range that the IPerChannelDbLevel::GetLevelRange method reports for a
		/// particular channel, the <c>SetLevelUniform</c> call clamps the value for that channel to the supported range and completes
		/// successfully. A subsequent call to the IPerChannelDbLevel::GetLevel method retrieves the actual value used for that channel.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-setleveluniform
		// HRESULT SetLevelUniform( float fLevelDB, LPCGUID pguidEventContext );
		new void SetLevelUniform([In] float fLevelDB, [Optional, In] GuidPtr pguidEventContext);

		/// <summary>
		/// The <c>SetLevelAllChannels</c> method sets the volume levels, in decibels, of all the channels in the audio stream.
		/// </summary>
		/// <param name="aLevelsDB">
		/// Pointer to an array of volume levels. This parameter points to a caller-allocated <c>float</c> array into which the method
		/// writes the new volume levels, in decibels, for all the channels. The method writes the level for a particular channel into
		/// the array element whose index matches the channel number. If the audio stream contains n channels, the channels are numbered
		/// 0 to n– 1. To get the number of channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <param name="cChannels">
		/// The number of elements in the aLevelsDB array. If this parameter does not match the number of channels in the audio stream,
		/// the method fails without modifying the aLevelsDB array.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetLevelAllChannels</c> call changes the state of the level control, all clients that have registered
		/// IControlChangeNotify interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c>
		/// method, a client can inspect the event-context GUID to discover whether it or another client is the source of the
		/// control-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method
		/// receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// If the specified level value for any channel is beyond the range that the IPerChannelDbLevel::GetLevelRange method reports
		/// for that channel, the <c>SetLevelAllChannels</c> call clamps the value to the supported range and completes successfully. A
		/// subsequent call to the IPerChannelDbLevel::GetLevel method retrieves the actual value used for that channel.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-setlevelallchannels
		// HRESULT SetLevelAllChannels( float [] aLevelsDB, ULONG cChannels, LPCGUID pguidEventContext );
		new void SetLevelAllChannels([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] aLevelsDB, [In] uint cChannels, [Optional, In] GuidPtr pguidEventContext);
	}

	/// <summary>
	/// <para>
	/// The <c>IConnector</c> interface represents a point of connection between components. The client obtains a reference to an
	/// <c>IConnector</c> interface by calling the IDeviceTopology::GetConnector or IConnector::GetConnectedTo method, or by calling the
	/// <c>IPart::QueryInterface</c> method with parameter iid set to <c>REFIID</c> IID_IConnector.
	/// </para>
	/// <para>An <c>IConnector</c> interface instance can represent:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>An audio jack on a piece of hardware</term>
	/// </item>
	/// <item>
	/// <term>An internal connection to an integrated endpoint device (for example, a built-in microphone in a laptop computer)</term>
	/// </item>
	/// <item>
	/// <term>A software connection implemented through DMA transfers</term>
	/// </item>
	/// </list>
	/// <para>
	/// The methods in the <c>IConnector</c> interface can describe various kinds of connectors. A connector has a type (a ConnectorType
	/// enumeration constant) and a subtype (a GUID obtained from the IPart::GetSubType method).
	/// </para>
	/// <para>
	/// A part in a device topology can be either a connector or a subunit. The IPart interface provides methods that are common to
	/// connectors and subunits.
	/// </para>
	/// <para>
	/// For code examples that use the <c>IConnector</c> interface, see the implementations of the GetHardwareDeviceTopology and
	/// SelectCaptureDevice functions in Device Topologies.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-iconnector
	[PInvokeData("devicetopology.h", MSDNShortId = "6eb5b439-3ac7-4c0b-84e2-b246c1b946a5")]
	[ComImport, Guid("9c2c4058-23f5-41de-877a-df3af236a09e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IConnector
	{
		/// <summary>The <c>GetType</c> method gets the type of this connector.</summary>
		/// <returns>
		/// <para>The connector type. The connector type is one of the following ConnectorType enumeration constants:</para>
		/// <para>Unknown_Connector</para>
		/// <para>Physical_Internal</para>
		/// <para>Physical_External</para>
		/// <para>Software_IO</para>
		/// <para>Software_Fixed</para>
		/// <para>Network</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A connector corresponds to a "pin" in kernel streaming (KS) terminology. The mapping of KS pins to connectors is as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If the KS pin communication type is KSPIN_COMMUNICATION_SINK, KSPIN_COMMUNICATION_SOURCE, or KSPIN_COMMUNICATION_BOTH, then
		/// the connector type is Software_IO.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Else, if the pin is part of a physical connection between two KS filters (devices) in the same audio adapter or in different
		/// audio adapters, then the connector type is Software_Fixed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Else, if the KS pin category is KSNODETYPE_SPEAKER, KSNODETYPE_MICROPHONE, KSNODETYPE_LINE_CONNECTOR, or
		/// KSNODETYPE_SPDIF_INTERFACE, the connector type is Physical_External.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Else, for a pin that does not meet any of the preceding criteria, the connector type is Physical_Internal.</term>
		/// </item>
		/// </list>
		/// <para>For more information about KS pins, see the Windows DDK documentation.</para>
		/// <para>
		/// For a code example that calls the <c>GetType</c> method, see the implementation of the SelectCaptureDevice function in
		/// Device Topologies.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iconnector-gettype HRESULT GetType(
		// ConnectorType *pType );
		ConnectorType GetType();

		/// <summary>The <c>GetDataFlow</c> method gets the direction of data flow through this connector.</summary>
		/// <returns>
		/// <para>The data-flow direction. The direction is one of the following DataFlow enumeration values:</para>
		/// <para>In</para>
		/// <para>Out</para>
		/// <para>
		/// If data flows into the device through the connector, the data-flow direction is In. Otherwise, the data-flow direction is Out.
		/// </para>
		/// </returns>
		/// <remarks>
		/// For a code example that calls this method, see the implementation of the SelectCaptureDevice function in Device Topologies.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iconnector-getdataflow HRESULT
		// GetDataFlow( DataFlow *pFlow );
		DataFlow GetDataFlow();

		/// <summary>The <c>ConnectTo</c> method connects this connector to a connector in another device-topology object.</summary>
		/// <param name="pConnectTo">
		/// The other connector. This parameter points to the IConnector interface of the connector object that represents the connector
		/// in the other device topology. The caller is responsible for releasing its counted reference to the <c>IConnector</c>
		/// interface when it is no longer needed. The <c>ConnectTo</c> method obtains its own reference to this interface.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iconnector-connectto HRESULT ConnectTo(
		// IConnector *pConnectTo );
		void ConnectTo([In] IConnector pConnectTo);

		/// <summary>The <c>Disconnect</c> method disconnects this connector from another connector.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iconnector-disconnect HRESULT Disconnect();
		void Disconnect();

		/// <summary>The <c>IsConnected</c> method indicates whether this connector is connected to another connector.</summary>
		/// <returns>
		/// A <c>BOOL</c> variable into which the method writes the connection state. If the state is <c>TRUE</c>, this connector is
		/// connected to another connector. If <c>FALSE</c>, this connector is unconnected.
		/// </returns>
		/// <remarks>
		/// For a code example that calls the <c>IsConnected</c> method, see the implementation of the SelectCaptureDevice function in
		/// Device Topologies.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iconnector-isconnected HRESULT
		// IsConnected( BOOL *pbConnected );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsConnected();

		/// <summary>The <c>GetConnectedTo</c> method gets the connector to which this connector is connected.</summary>
		/// <returns>
		/// The IConnector interface of the other connector object. Through this method, the caller obtains a counted reference to the
		/// interface. The caller is responsible for releasing the interface, when it is no longer needed, by calling the interface's
		/// <c>Release</c> method. If the <c>GetConnectedTo</c> call fails, *ppConTo is <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// <para>
		/// For code examples that call this method, see the implementations of the GetHardwareDeviceTopology and SelectCaptureDevice
		/// functions in Device Topologies.
		/// </para>
		/// <para>
		/// For information about Software_IO connections, see ConnectorType Enumeration. For information about the HRESULT_FROM_WIN32
		/// macro, see the Windows SDK documentation. For information about the DEVICE_STATE_NOTPRESENT device state, see
		/// DEVICE_STATE_XXX Constants.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iconnector-getconnectedto HRESULT
		// GetConnectedTo( IConnector **ppConTo );
		IConnector? GetConnectedTo();

		/// <summary>
		/// The <c>GetConnectorIdConnectedTo</c> method gets the global ID of the connector, if any, that this connector is connected to.
		/// </summary>
		/// <returns>
		/// A string pointer into which the method writes the address of a null-terminated, wide-character string that contains the
		/// other connector's global ID. The method allocates the storage for the string. If the <c>GetConnectorIdConnectedTo</c> call
		/// fails, *ppwstrConnectorId is <c>NULL</c>. For information about <c>CoTaskMemFree</c>, see the Windows SDK documentation.
		/// </returns>
		/// <remarks>
		/// A global ID is a string that uniquely identifies a part among all parts in all device topologies in the system. Clients
		/// should treat this string as opaque. That is, clients should not attempt to parse the contents of the string to obtain
		/// information about the part. The reason is that the string format is undefined and might change from one implementation of
		/// the DeviceTopology API to the next.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iconnector-getconnectoridconnectedto
		// HRESULT GetConnectorIdConnectedTo( PWSTR *ppwstrConnectorId );
		SafeCoTaskMemString GetConnectorIdConnectedTo();

		/// <summary>
		/// The <c>GetDeviceIdConnectedTo</c> method gets the device identifier of the audio device, if any, that this connector is
		/// connected to.
		/// </summary>
		/// <returns>
		/// A string pointer into which the method writes the address of a null-terminated, wide-character string that contains the
		/// device identifier of the connected device. The method allocates the storage for the string. If the
		/// <c>GetDeviceIdConnectedTo</c> call fails, *ppwstrDeviceId is <c>NULL</c>. For information about <c>CoTaskMemFree</c>, see
		/// the Windows SDK documentation.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The device identifier obtained from this method can be used as an input parameter to the IMMDeviceEnumerator::GetDevice method.
		/// </para>
		/// <para>This method is functionally equivalent to, but more efficient than, the following series of method calls:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Call the IConnector::GetConnectedTo method to obtain the IConnector interface of the "to" connector.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Call the <c>IConnector::QueryInterface</c> method (with parameter iid set to <c>REFIID</c> IID_IPart) to obtain the IPart
		/// interface of the "to" connector.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Call the IPart::GetTopologyObject method to obtain the IDeviceTopology interface of the "to" device (the device that
		/// contains the "to" connector).
		/// </term>
		/// </item>
		/// <item>
		/// <term>Call the IDeviceTopology::GetDeviceId method to obtain the device ID of the "to" device.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iconnector-getdeviceidconnectedto HRESULT
		// GetDeviceIdConnectedTo( PWSTR *ppwstrDeviceId );
		SafeCoTaskMemString GetDeviceIdConnectedTo();
	}

	/// <summary>
	/// <para>
	/// The <c>IControlChangeNotify</c> interface provides notifications when the status of a part (connector or subunit) changes.
	/// Unlike the other interfaces in this section, which are implemented by the DeviceTopology API, the <c>IControlChangeNotify</c>
	/// interface must be implemented by a client. To receive notifications, the client passes a pointer to its
	/// <c>IControlChangeNotify</c> interface instance as a parameter to the IPart::RegisterControlChangeCallback method.
	/// </para>
	/// <para>
	/// After registering its <c>IControlChangeNotify</c> interface, the client receives event notifications in the form of callbacks
	/// through the <c>OnNotify</c> method in the interface.
	/// </para>
	/// <para>
	/// In implementing the <c>IControlChangeNotify</c> interface, the client should observe these rules to avoid deadlocks and
	/// undefined behavior:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The methods in the interface must be nonblocking. The client should never wait on a synchronization object during an event callback.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The client should never call the IPart::UnregisterControlChangeCallback method during an event callback.</term>
	/// </item>
	/// <item>
	/// <term>The client should never release the final reference on an MMDevice API object during an event callback.</term>
	/// </item>
	/// </list>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-icontrolchangenotify
	[PInvokeData("devicetopology.h", MSDNShortId = "e50e13c2-1ef3-46f6-8c53-f99cc1631a79")]
	[ComImport, Guid("A09513ED-C709-4d21-BD7B-5F34C47F3947"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IControlChangeNotify
	{
		/// <summary>The <c>OnNotify</c> method notifies the client when the status of a connector or subunit changes.</summary>
		/// <param name="dwSenderProcessId">
		/// The process ID of the client that changed the state of the control. If a notification is generated by a hardware event, this
		/// process ID will differ from the client's process ID. For more information, see Remarks.
		/// </param>
		/// <param name="pguidEventContext">
		/// A pointer to the context GUID for the control-change event. The client that initiates the control change supplies this GUID.
		/// For more information, see Remarks.
		/// </param>
		/// <returns>If the method succeeds, it returns S_OK. If it fails, it returns an error code.</returns>
		/// <remarks>
		/// A client can use this method to keep track of control changes made by other processes and by the hardware. However, a client
		/// that changes a control setting can typically disregard the notification that the control change generates. In its
		/// implementation of the <c>OnNotify</c> method, a client can inspect the dwSenderProcessId and pguidEventContext parameters to
		/// discover whether it or another client is the source of the control-change event.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-icontrolchangenotify-onnotify HRESULT
		// OnNotify( DWORD dwSenderProcessId, LPCGUID pguidEventContext );
		[PreserveSig]
		HRESULT OnNotify([In] uint dwSenderProcessId, [Optional, In] GuidPtr pguidEventContext);
	}

	/// <summary>
	/// The <c>IControlInterface</c> interface represents a control interface on a part (connector or subunit) in a device topology. The
	/// client obtains a reference to a part's <c>IControlInterface</c> interface by calling the IPart::GetControlInterface method.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-icontrolinterface
	[PInvokeData("devicetopology.h", MSDNShortId = "fdd91f65-e45c-4f14-a55c-a44be1661950")]
	[ComImport, Guid("45d37c3f-5140-444a-ae24-400789f3cbf3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IControlInterface
	{
		/// <summary>The <c>GetName</c> method gets the friendly name for the audio function that the control interface encapsulates.</summary>
		/// <returns>
		/// A string pointer into which the method writes the address of a null-terminated, wide-character string that contains the
		/// friendly name. The method allocates the storage for the string. The caller is responsible for freeing the storage, when it
		/// is no longer needed, by calling the <c>CoTaskMemFree</c> function. If the <c>GetName</c> call fails, *ppwstrName is
		/// <c>NULL</c>. For information about <c>CoTaskMemFree</c>, see the Windows SDK documentation.
		/// </returns>
		/// <remarks>
		/// As an example of a friendly name, a subunit with an IAudioPeakMeter interface might have the friendly name "peak meter".
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-icontrolinterface-getname HRESULT
		// GetName( PWSTR *ppwstrName );
		SafeCoTaskMemString GetName();

		/// <summary>The <c>GetIID</c> method gets the interface ID of the function-specific control interface of the part.</summary>
		/// <returns>
		/// A GUID variable into which the method writes the interface ID of the function-specific control interface of the part. For
		/// more information, see Remarks.
		/// </returns>
		/// <remarks>
		/// <para>
		/// An object that represents a part (connector or subunit) has two control interfaces. The first is a generic control
		/// interface, IControlInterface, which has methods that are common to all types of controls. The second is a function-specific
		/// control interface that has methods that apply to a particular type of control. The <c>GetIID</c> method gets the interface
		/// ID of the second control interface. The client can supply this interface ID to the IPart::Activate method to create an
		/// instance of the part's function-specific interface.
		/// </para>
		/// <para>The method gets one of the function-specific interface IDs shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Interface ID</term>
		/// <term>Interface name</term>
		/// </listheader>
		/// <item>
		/// <term>IID_IAudioAutoGainControl</term>
		/// <term>IAudioAutoGainControl</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioBass</term>
		/// <term>IAudioBass</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioChannelConfig</term>
		/// <term>IAudioChannelConfig</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioInputSelector</term>
		/// <term>IAudioInputSelector</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioLoudness</term>
		/// <term>IAudioLoudness</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioMidrange</term>
		/// <term>IAudioMidrange</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioMute</term>
		/// <term>IAudioMute</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioOutputSelector</term>
		/// <term>IAudioOutputSelector</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioPeakMeter</term>
		/// <term>IAudioPeakMeter</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioTreble</term>
		/// <term>IAudioTreble</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioVolumeLevel</term>
		/// <term>IAudioVolumeLevel</term>
		/// </item>
		/// <item>
		/// <term>IID_IDeviceSpecificProperty</term>
		/// <term>IDeviceSpecificProperty</term>
		/// </item>
		/// <item>
		/// <term>IID_IKsFormatSupport</term>
		/// <term>IKsFormatSupport</term>
		/// </item>
		/// <item>
		/// <term>IID_IKsJackDescription</term>
		/// <term>IKsJackDescription</term>
		/// </item>
		/// </list>
		/// <para>
		/// To obtain the interface ID of an interface, use the <c>__uuidof</c> operator. For example, the interface ID of the
		/// <c>IAudioAutoGainControl</c> interface is defined as follows:
		/// </para>
		/// <para>For more information about the <c>__uuidof</c> operator, see the Windows SDK documentation.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-icontrolinterface-getiid HRESULT GetIID(
		// GUID *pIID );
		Guid GetIID();
	}

	/// <summary>
	/// <para>
	/// The <c>IDeviceSpecificProperty</c> interface provides access to the control value of a device-specific hardware control. A
	/// client obtains a reference to an <c>IDeviceSpecificProperty</c> interface of a part by calling the IPart::Activate method with
	/// parameter refiid set to <c>REFIID</c> IID_IDeviceSpecificProperty. The call to <c>IPart::Activate</c> succeeds only if the part
	/// supports the <c>IDeviceSpecificProperty</c> interface. A part supports this interface only if the underlying hardware control
	/// has a device-specific control value and the control cannot be adequately represented by any other interface in the
	/// DeviceTopology API.
	/// </para>
	/// <para>
	/// Typically, a device-specific property is useful only to a client that can infer the meaning of the property value from
	/// information such as the part type, part subtype, and part name. The client can obtain this information by calling the
	/// IPart::GetPartType, IPart::GetSubType, and IPart::GetName methods.
	/// </para>
	/// <para>
	/// Most Windows audio adapter drivers support the Windows Driver Model (WDM) and use kernel-streaming (KS) properties to represent
	/// the hardware control parameters in subunits (referred to as KS nodes). The <c>IDeviceSpecificProperty</c> interface provides
	/// convenient access to the KSPROPERTY_AUDIO_DEV_SPECIFIC property of a subunit that has a subtype GUID value of
	/// KSNODETYPE_DEV_SPECIFIC. To obtain the subtype GUID of a subunit, call the IPart::GetSubType method. For more information about
	/// KS properties and KS node types, see the Windows DDK documentation.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-idevicespecificproperty
	[PInvokeData("devicetopology.h", MSDNShortId = "52873fe2-7f59-4a30-b526-cbefa27a81bb")]
	[ComImport, Guid("3B22BCBF-2586-4af0-8583-205D391B807C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDeviceSpecificProperty
	{
		/// <summary>The <c>GetType</c> method gets the data type of the device-specific property value.</summary>
		/// <returns>
		/// A <c>VARTYPE</c> variable into which the method writes a <c>VARTYPE</c> enumeration value that indicates the data type of
		/// the device-specific property value. For more information about <c>VARTYPE</c> and <c>VARTYPE</c>, see the Windows SDK documentation.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-idevicespecificproperty-gettype HRESULT
		// GetType( VARTYPE *pVType );
		VARTYPE GetType();

		/// <summary>The <c>GetValue</c> method gets the current value of the device-specific property.</summary>
		/// <param name="pvValue">Pointer to a caller-allocated buffer into which the method writes the property value.</param>
		/// <param name="pcbValue">
		/// [inout] Pointer to a <c>DWORD</c> variable that specifies the size in bytes of the property value. On entry, *pcbValue
		/// contains the size of the caller-allocated buffer (or 0 if pvValue is <c>NULL</c>). Before returning, the method writes the
		/// actual size of the property value written to the buffer (or the required size if the buffer is too small or if pvValue is <c>NULL</c>).
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
		/// <term>Pointer pcbValue is NULL.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)</term>
		/// <term>
		/// The buffer pointed to by parameter pvValue is too small to contain the property value, or pvValue is NULL and the size of
		/// the property value is fixed rather than variable. For information about this macro, see the Windows SDK documentation.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the size of the property value is variable rather than fixed, the caller can obtain the required buffer size by calling
		/// <c>GetValue</c> with parameter pvValue = <c>NULL</c> and *pcbValue = 0. The method writes the required buffer size to
		/// *pcbValue. With this information, the caller can allocate a buffer of the required size and call <c>GetValue</c> a second
		/// time to obtain the property value.
		/// </para>
		/// <para>
		/// If the caller-allocated buffer is too small to hold the property value, <c>GetValue</c> writes the required buffer size to
		/// *pcbValue and returns an error status code. In this case, it writes nothing to the buffer pointed by pvValue.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-idevicespecificproperty-getvalue HRESULT
		// GetValue( void *pvValue, DWORD *pcbValue );
		[PreserveSig]
		HRESULT GetValue([Out] IntPtr pvValue, ref uint pcbValue);

		/// <summary>The <c>SetValue</c> method sets the value of the device-specific property.</summary>
		/// <param name="pvValue">Pointer to the new value for the device-specific property.</param>
		/// <param name="cbValue">The size in bytes of the device-specific property value.</param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetValue</c> call changes the state of the control, all clients that have registered IControlChangeNotify interfaces with
		/// that control receive notifications. In its implementation of the <c>OnNotify</c> method, a client can inspect the
		/// event-context GUID to discover whether it or another client is the source of the control-change event. If the caller
		/// supplies a <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-idevicespecificproperty-setvalue HRESULT
		// SetValue( void *pvValue, DWORD cbValue, LPCGUID pguidEventContext );
		void SetValue([In] IntPtr pvValue, uint cbValue, [Optional, In] GuidPtr pguidEventContext);

		/// <summary>The <c>Get4BRange</c> method gets the 4-byte range of the device-specific property value.</summary>
		/// <param name="plMin">Pointer to a <c>LONG</c> variable into which the method writes the minimum property value.</param>
		/// <param name="plMax">Pointer to a <c>LONG</c> variable into which the method writes the maximum property value.</param>
		/// <param name="plStepping">
		/// Pointer to a <c>LONG</c> variable into which the method writes the stepping value between consecutive property values in the
		/// range *plMin to *plMax. If the difference between the maximum and minimum property values is d, and the range is divided
		/// into n steps (uniformly sized intervals), then the property can take n + 1 discrete values and the size of the step between
		/// consecutive values is d / n.
		/// </param>
		/// <remarks>
		/// This method reports the range and step size for a property value that is a 32-bit signed or unsigned integer. These two data
		/// types are represented by <c>VARENUM</c> enumeration constants VT_I4 and VT_UI4, respectively. If the property value is not a
		/// 32-bit integer, then the method returns an error status code. For more information about <c>VARENUM</c>, see the Windows SDK documentation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-idevicespecificproperty-get4brange
		// HRESULT Get4BRange( LONG *plMin, LONG *plMax, LONG *plStepping );
		void Get4BRange(out int plMin, out int plMax, out int plStepping);
	}

	/// <summary>
	/// <para>
	/// The <c>IDeviceTopology</c> interface provides access to the topology of an audio device. The topology of an audio adapter device
	/// consists of the data paths that lead to and from audio endpoint devices and the control points that lie along the paths. An
	/// audio endpoint device also has a topology, but it is trivial, as explained in Device Topologies. A client obtains a reference to
	/// the <c>IDeviceTopology</c> interface for an audio endpoint device by following these steps:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// By using one of the techniques described in IMMDevice Interface, obtain a reference to the <c>IMMDevice</c> interface for an
	/// audio endpoint device.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Call the IMMDevice::Activate method with parameter refiid set to <c>REFIID</c> IID_IDeviceTopology.</term>
	/// </item>
	/// </list>
	/// <para>
	/// After obtaining the <c>IDeviceTopology</c> interface for an audio endpoint device, an application can explore the topologies of
	/// the audio adapter devices to which the endpoint device is connected.
	/// </para>
	/// <para>
	/// For code examples that use the <c>IDeviceTopology</c> interface, see the implementations of the GetHardwareDeviceTopology and
	/// SelectCaptureDevice functions in Device Topologies.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-idevicetopology
	[PInvokeData("devicetopology.h", MSDNShortId = "1b509f69-6277-40c0-a293-02afc30d464a")]
	[ComImport, Guid("2A07407E-6497-4A18-9787-32F79BD0D98F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDeviceTopology
	{
		/// <summary>The <c>GetConnectorCount</c> method gets the number of connectors in the device-topology object.</summary>
		/// <returns>
		/// A <c>UINT</c> pointer variable into which the method writes the connector count (the number of connectors in the device topology).
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-idevicetopology-getconnectorcount HRESULT
		// GetConnectorCount( UINT *pCount );
		uint GetConnectorCount();

		/// <summary>The <c>GetConnector</c> method gets the connector that is specified by a connector number.</summary>
		/// <param name="nIndex">
		/// The connector number. If a device topology contains n connectors, the connectors are numbered 0 to n – 1. To get the number
		/// of connectors in the device topology, call the IDeviceTopology::GetConnectorCount method.
		/// </param>
		/// <returns>
		/// The IConnector interface of the connector object. Through this method, the caller obtains a counted reference to the
		/// interface. The caller is responsible for releasing the interface, when it is no longer needed, by calling the interface's
		/// <c>Release</c> method. If the <c>GetConnector</c> call fails, *ppConnector is <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// For code examples that call the <c>GetConnector</c> method, see the implementations of the GetHardwareDeviceTopology and
		/// SelectCaptureDevice functions in Device Topologies.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-idevicetopology-getconnector HRESULT
		// GetConnector( UINT nIndex, IConnector **ppConnector );
		IConnector? GetConnector([In] uint nIndex);

		/// <summary>The <c>GetSubunitCount</c> method gets the number of subunits in the device topology.</summary>
		/// <returns>
		/// A <c>UINT</c> variable into which the method writes the subunit count (the number of subunits in the device topology).
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-idevicetopology-getsubunitcount HRESULT
		// GetSubunitCount( UINT *pCount );
		uint GetSubunitCount();

		/// <summary>The <c>GetSubunit</c> method gets the subunit that is specified by a subunit number.</summary>
		/// <param name="nIndex">
		/// The subunit number. If a device topology contains n subunits, the subunits are numbered from 0 to n– 1. To get the number of
		/// subunits in the device topology, call the IDeviceTopology::GetSubunitCount method.
		/// </param>
		/// <returns>
		/// The ISubunit interface of the subunit object. Through this method, the caller obtains a counted reference to the interface.
		/// The caller is responsible for releasing the interface, when it is no longer needed, by calling the interface's
		/// <c>Release</c> method. If the <c>GetSubunit</c> call fails, *ppSubunit is <c>NULL</c>.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-idevicetopology-getsubunit HRESULT
		// GetSubunit( UINT nIndex, ISubunit **ppSubunit );
		ISubunit? GetSubunit([In] uint nIndex);

		/// <summary>The <c>GetPartById</c> method gets a part that is identified by its local ID.</summary>
		/// <param name="nId">The part to get. This parameter is the local ID of the part. For more information, see Remarks.</param>
		/// <returns>
		/// The IPart interface of the part object that is identified by nId. Through this method, the caller obtains a counted
		/// reference to the interface. The caller is responsible for releasing the interface, when it is no longer needed, by calling
		/// the interface's <c>Release</c> method. If the <c>GetPartById</c> call fails, *ppPart is <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// A local ID is a number that uniquely identifies a part among all the parts in a device topology. The
		/// IAudioInputSelector::GetSelection and IAudioOutputSelector::GetSelection methods retrieve the local ID of a connected part.
		/// The IAudioInputSelector::SetSelection and IAudioOutputSelector::SetSelection methods select the input or output that is
		/// connected to a part that is identified by its local ID. When you have a pointer to a part object, you can call the
		/// IPart::GetLocalId method to get the local ID of the part.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-idevicetopology-getpartbyid HRESULT
		// GetPartById( UINT nId, IPart **ppPart );
		IPart? GetPartById([In] uint nId);

		/// <summary>
		/// The <c>GetDeviceId</c> method gets the device identifier of the device that is represented by the device-topology object.
		/// </summary>
		/// <returns>
		/// A pointer variable into which the method writes the address of a null-terminated, wide-character string that contains the
		/// device identifier. The method allocates the storage for the string. The caller is responsible for freeing the storage, when
		/// it is no longer needed, by calling the <c>CoTaskMemFree</c> function. If the <c>GetDeviceId</c> call fails, *ppwstrDeviceId
		/// is <c>NULL</c>. For information about <c>CoTaskMemFree</c>, see the Windows SDK documentation.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The device identifier obtained from this method can be used as an input parameter to the IMMDeviceEnumerator::GetDevice method.
		/// </para>
		/// <para>For a code example that uses the <c>GetDeviceId</c> method, see Using the IKsControl Interface to Access Audio Properties.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-idevicetopology-getdeviceid HRESULT
		// GetDeviceId( PWSTR *ppwstrDeviceId );
		SafeCoTaskMemString GetDeviceId();

		/// <summary>The <c>GetSignalPath</c> method gets a list of parts in the signal path that links two parts, if the path exists.</summary>
		/// <param name="pIPartFrom">
		/// Pointer to the "from" part. This parameter is a pointer to the IPart interface of the part at the beginning of the signal path.
		/// </param>
		/// <param name="pIPartTo">
		/// Pointer to the "to" part. This parameter is a pointer to the <c>IPart</c> interface of the part at the end of the signal path.
		/// </param>
		/// <param name="bRejectMixedPaths">
		/// Specifies whether to reject paths that contain mixed data. If bRejectMixedPaths is <c>TRUE</c> (nonzero), the method ignores
		/// any data path that contains a mixer (that is, a processing node that sums together two or more input signals). If
		/// <c>FALSE</c>, the method will try to find a path that connects the "from" and "to" parts regardless of whether the path
		/// contains a mixer.
		/// </param>
		/// <returns>
		/// An IPartsList interface instance. This interface encapsulates the list of parts in the signal path that connects the "from"
		/// part to the "to" part. Through this method, the caller obtains a counted reference to the interface. The caller is
		/// responsible for releasing the interface, when it is no longer needed, by calling the interface's <c>Release</c> method. If
		/// the <c>GetSignalPath</c> call fails, *ppParts is <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method creates an <c>IPartsList</c> interface instance that contains a list of the parts that lie along the specified
		/// signal path. The parts in the parts list are ordered according to their relative positions in the signal path. The "to" part
		/// is the first item in the list and the "from" part is the last item in the list.
		/// </para>
		/// <para>
		/// If the list contains n parts, the "to" and "from" parts are identified by list indexes 0 and n– 1, respectively. To get the
		/// number of parts in a parts list, call the IPartsList::GetCount method. To retrieve a part by its index, call the
		/// IPartsList::GetPart method.
		/// </para>
		/// <para>
		/// The parts in the signal path must all be part of the same device topology. The path cannot span boundaries between device topologies.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-idevicetopology-getsignalpath HRESULT
		// GetSignalPath( IPart *pIPartFrom, IPart *pIPartTo, BOOL bRejectMixedPaths, IPartsList **ppParts );
		IPartsList? GetSignalPath([In] IPart pIPartFrom, [In] IPart pIPartTo, [In] [MarshalAs(UnmanagedType.Bool)] bool bRejectMixedPaths);
	}

	/// <summary>
	/// <para>
	/// The <c>IKsFormatSupport</c> interface provides information about the audio data formats that are supported by a
	/// software-configured I/O connection (typically a DMA channel) between an audio adapter device and system memory. The client
	/// obtains a reference to the <c>IKsFormatSupport</c> interface of a part by calling the IPart::Activate method with parameter
	/// refiid set to REFIID IID_IKsFormatSupport. The call to <c>IPart::Activate</c> succeeds only if the part supports the
	/// <c>IKsFormatSupport</c> interface. Only a part object that represents a connector with a Software_IO connection type will
	/// support this interface. For more information about Software_IO, see ConnectorType Enumeration.
	/// </para>
	/// <para>
	/// Most Windows audio adapter drivers support the Windows Driver Model (WDM) and use kernel-streaming (KS) properties to represent
	/// the hardware description parameters in connectors (referred to as KS pins). The <c>IKsFormatSupport</c> interface provides
	/// convenient access to the KSPROPERTY_PIN_DATAINTERSECTION and KSPROPERTY_PIN_PROPOSEDDATAFORMAT properties of a connector to a
	/// system bus (typically, PCI or PCI Express) or an external bus (for example, USB). Not all drivers support the
	/// KSPROPERTY_PIN_PROPOSEDDATAFORMAT property. If a driver does not support this property, <c>IKsFormatSupport</c> uses the
	/// information in the KS data ranges for the connector to determine whether the connector supports the proposed format. For more
	/// information about KS properties, KS pins, and KS data ranges, see the Windows DDK documentation.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-iksformatsupport
	[ComImport, Guid("3CB4A69D-BB6F-4D2B-95B7-452D2C155DB5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IKsFormatSupport
	{
		/// <summary>
		/// The <c>IsFormatSupported</c> method indicates whether the audio endpoint device supports the specified audio stream format.
		/// </summary>
		/// <param name="pKsFormat">
		/// Pointer to an audio-stream format specifier. This parameter points to a caller-allocated buffer that contains a format
		/// specifier. The specifier begins with a KSDATAFORMAT structure that might be followed by additional format information. For
		/// more information about <c>KSDATAFORMAT</c> and format specifiers, see the Windows DDK documentation.
		/// </param>
		/// <param name="cbFormat">The size in bytes of the buffer that contains the format specifier.</param>
		/// <returns>
		/// A <c>BOOL</c> variable into which the method writes a value to indicate whether the format is supported. The method writes
		/// <c>TRUE</c> if the device supports the format and <c>FALSE</c> if the device does not support the format.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iksformatsupport-isformatsupported
		// HRESULT IsFormatSupported( PKSDATAFORMAT pKsFormat, DWORD cbFormat, BOOL *pbSupported );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsFormatSupported([In] IntPtr pKsFormat, [In] uint cbFormat);

		/// <summary>The <c>GetDevicePreferredFormat</c> method gets the preferred audio stream format for the connection.</summary>
		/// <returns>
		/// A pointer variable into which the method writes the address of a buffer that contains the format specifier for the preferred
		/// format. The specifier begins with a <c>KSDATAFORMAT</c> structure that might be followed by additional format information.
		/// The method allocates the storage for the format specifier. If the method fails, *ppKsFormat is <c>NULL</c>. For more
		/// information about <c>KSDATAFORMAT</c>, format specifiers, and <c>CoTaskMemFree</c>, see the Windows DDK documentation.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iksformatsupport-getdevicepreferredformat
		// HRESULT GetDevicePreferredFormat( PKSDATAFORMAT *ppKsFormat );
		SafeCoTaskMemHandle GetDevicePreferredFormat();
	}

	/// <summary>
	/// <para>
	/// The <c>IKsJackDescription</c> interface provides information about the jacks or internal connectors that provide a physical
	/// connection between a device on an audio adapter and an external or internal endpoint device (for example, a microphone or CD
	/// player). The client obtains a reference to the <c>IKsJackDescription</c> interface of a part by calling the IPart::Activate
	/// method with parameter refiid set to <c>REFIID</c> IID_IKsJackDescription. The call to <c>IPart::Activate</c> succeeds only if
	/// the part supports the <c>IKsJackDescription</c> interface. Only a part object that represents a connector with a
	/// Physical_External or Physical_Internal connection type will support this interface.
	/// </para>
	/// <para>
	/// Most Windows audio adapter drivers support the Windows Driver Model (WDM) and use kernel-streaming (KS) properties to represent
	/// the hardware description parameters in connectors (referred to as KS pins). The <c>IKsJackDescription</c> interface provides
	/// convenient access to the KSPROPERTY_JACK_DESCRIPTION property of a connector to an endpoint device. For more information about
	/// KS properties and KS pins, see the Windows DDK documentation.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// If an audio endpoint device supports the <c>IKsJackDescription</c> interface, the Windows multimedia control panel, Mmsys.cpl,
	/// displays the jack information. To view the jack information, follow these steps:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>To run Mmsys.cpl, open a Command Prompt window and enter the following command:</term>
	/// </item>
	/// <item>
	/// <term>
	/// After the Mmsys.cpl window opens, select a device from either the list of playback devices or the list of recording devices, and
	/// click <c>Properties</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// When the properties window opens, click <c>General</c>. If the selected property page displays the jack information for the
	/// device, the device supports the <c>IKsJackDescription</c> interface. If the property page displays the text "No jack information
	/// is available", the device does not support the interface.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The following code example shows how to obtain the <c>IKsJackDescription</c> interface for an audio endpoint device:</para>
	/// <para>
	/// In the preceding code example, the GetJackInfo function takes two parameters. Input parameter pDevice points to the IMMDevice
	/// interface of an endpoint device. Output parameter ppJackDesc points to a pointer value into which the function writes the
	/// address of the corresponding <c>IKsJackDescription</c> interface, if the interface exists. If the interface does not exist, the
	/// function writes <c>NULL</c> to *ppJackDesc and returns error code E_NOINTERFACE.
	/// </para>
	/// <para>
	/// In the preceding code example, the call to IMMDevice::Activate retrieves the IDeviceTopology interface of the endpoint device.
	/// The device topology of an endpoint device contains a single connector (connector number 0) that connects to the adapter device.
	/// At the other side of this connection, the connector on the adapter device represents the audio jack or jacks that the endpoint
	/// device plugs into. The call to the IDeviceTopology::GetConnector method retrieves the IConnector interface of the connector on
	/// the endpoint device, and the IConnector::GetConnectedTo method call retrieves the corresponding connector on the adapter device.
	/// Finally, the <c>IConnector::QueryInterface</c> method call retrieves the IPart interface of the adapter device's connector, and
	/// the IPart::Activate method call retrieves the connector's <c>IKsJackDescription</c> interface, if it exists.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-iksjackdescription
	[PInvokeData("devicetopology.h", MSDNShortId = "0ca9e719-7179-4302-99ff-df137141f58f")]
	[ComImport, Guid("4509F757-2D46-4637-8E62-CE7DB944F57B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IKsJackDescription
	{
		/// <summary>The <c>GetJackCount</c> method gets the number of jacks required to connect to an audio endpoint device.</summary>
		/// <returns>A <c>UINT</c> variable into which the method writes the number of jacks associated with the connector.</returns>
		/// <remarks>
		/// <para>
		/// An audio endpoint device that plays or records a stream that contains multiple channels might require a connection with more
		/// than one jack (physical connector).
		/// </para>
		/// <para>
		/// For example, a set of surround speakers that plays a 6-channel audio stream might require three stereo jacks. In this
		/// example, the first jack transmits the channels for the front-left and front-right speakers, the second jack transmits the
		/// channels for the front-center and low-frequency-effects (subwoofer) speakers, and the third jack transmits the channels for
		/// the side-left and side-right speakers.
		/// </para>
		/// <para>
		/// After calling this method to retrieve the jack count, call the IKsJackDescription::GetJackDescription method once for each
		/// jack to obtain a description of the jack.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iksjackdescription-getjackcount HRESULT
		// GetJackCount( UINT *pcJacks );
		uint GetJackCount();

		/// <summary>The <c>GetJackDescription</c> method gets a description of an audio jack.</summary>
		/// <param name="nJack">
		/// The jack index. If the connection consists of n jacks, the jacks are numbered from 0 to n– 1. To get the number of jacks,
		/// call the IKsJackDescription::GetJackCount method.
		/// </param>
		/// <returns>
		/// A structure of type KSJACK_DESCRIPTION that contains information about the jack. The buffer size must be at least sizeof(KSJACK_DESCRIPTION).
		/// </returns>
		/// <remarks>
		/// <para>
		/// When a user needs to plug an audio endpoint device into a jack or unplug it from a jack, an audio application can use the
		/// descriptive information that it retrieves from this method to help the user to find the jack. This information includes:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The physical location of the jack on the computer chassis or external box.</term>
		/// </item>
		/// <item>
		/// <term>The color of the jack.</term>
		/// </item>
		/// <item>
		/// <term>The type of physical connector used for the jack.</term>
		/// </item>
		/// <item>
		/// <term>The mapping of channels to the jack.</term>
		/// </item>
		/// </list>
		/// <para>For more information, see KSJACK_DESCRIPTION.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iksjackdescription-getjackdescription
		// HRESULT GetJackDescription( UINT nJack, KSJACK_DESCRIPTION *pDescription );
		KSJACK_DESCRIPTION GetJackDescription(uint nJack);
	}

	/// <summary>
	/// <para>
	/// The <c>IKsJackDescription2</c> interface provides information about the jacks or internal connectors that provide a physical
	/// connection between a device on an audio adapter and an external or internal endpoint device (for example, a microphone or CD player).
	/// </para>
	/// <para>
	/// In addition to getting jack information such as type of connection, the IKsJackDescription is primarily used to report whether
	/// the jack was connected to the device. In Windows 7, if the connected device driver supports <c>IKsJackDescription2</c>, the
	/// audio stack or an application can use this interface to get information additional jack information. This includes the jack's
	/// detection capability and if the format of the device has changed dynamically.
	/// </para>
	/// <para>
	/// Most Windows audio adapter drivers support the Windows Driver Model (WDM) and use kernel-streaming (KS) properties to represent
	/// the hardware description parameters in connectors (referred to as KS pins). The <c>IKsJackDescription2</c> interface provides
	/// convenient access to the <c>KSPROPERTY_JACK_DESCRIPTION2</c> property of a connector to an endpoint device. For more information
	/// about KS properties and KS pins, see the Windows DDK documentation.
	/// </para>
	/// <para>
	/// An application obtains a reference to the <c>IKsJackDescription2</c> interface of a part by calling the IPart::Activate method
	/// with parameter refiid set to <c>REFIID</c><c>IID_IKsJackDescription2</c>. The call to <c>IPart::Activate</c> succeeds only if
	/// the part supports the <c>IKsJackDescription2</c> interface. Only a part object that represents a bridge pin connector on a KS
	/// filter device topology object supports this interface.
	/// </para>
	/// <para>For a code example, see IKsJackDescription.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-iksjackdescription2
	[PInvokeData("devicetopology.h", MSDNShortId = "9a3d7631-6892-457a-91ab-484ae867fd9f")]
	[ComImport, Guid("478F3A9B-E0C9-4827-9228-6F5505FFE76A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IKsJackDescription2
	{
		/// <summary>
		/// The <c>GetJackCount</c> method gets the number of jacks on the connector, which are required to connect to an endpoint device.
		/// </summary>
		/// <returns>The number of audio jacks associated with the connector.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iksjackdescription2-getjackcount HRESULT
		// GetJackCount( UINT *pcJacks );
		uint GetJackCount();

		/// <summary>The <c>GetJackDescription2</c> method gets the description of a specified audio jack.</summary>
		/// <param name="nJack">
		/// The index of the jack to get a description for. If the connection consists of n jacks, the jacks are numbered from 0 to n–
		/// 1. To get the number of jacks, call the IKsJackDescription::GetJackCount method.
		/// </param>
		/// <returns>
		/// A structure of type KSJACK_DESCRIPTION2 that contains information about the jack. The buffer size must be at least .
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iksjackdescription2-getjackdescription2
		// HRESULT GetJackDescription2( UINT nJack, KSJACK_DESCRIPTION2 *pDescription2 );
		KSJACK_DESCRIPTION2 GetJackDescription2(uint nJack);
	}

	/// <summary>
	/// <para>The <c>IKsJackSinkInformation</c> interface provides access to jack sink information if the jack is supported by the hardware.</para>
	/// <para>
	/// The client obtains a reference to the <c>IKsJackSinkInformation</c> interface by activating it on the IPart interface of a
	/// bridge pin connector on a KS filter device topology object. To activate the object, call the IPart::Activate method with
	/// parameter refiid set to REFIID <c>IID_IKsJackSinkInformation</c>.
	/// </para>
	/// <para>
	/// Most Windows audio adapter drivers support the Windows Driver Model (WDM) and use kernel-streaming (KS) properties to represent
	/// the hardware description parameters in connectors (referred to as KS pins). The <c>IKsJackSinkInformation</c> interface provides
	/// convenient access to the <c>KSPROPERTY_JACK_SINK_INFO</c> property of a connector to an endpoint device. For more information
	/// about KS properties and KS pins, see the Windows DDK documentation.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-iksjacksinkinformation
	[PInvokeData("devicetopology.h", MSDNShortId = "4116a912-5ff2-4fc0-96c6-61d1e62cd973")]
	[ComImport, Guid("D9BD72ED-290F-4581-9FF3-61027A8FE532"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IKsJackSinkInformation
	{
		/// <summary>The <c>GetJackSinkInformation</c> method retrieves the sink information for the specified jack.</summary>
		/// <returns>The sink information of the jack in a KSJACK_SINK_INFORMATION structure.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iksjacksinkinformation-getjacksinkinformation
		// HRESULT GetJackSinkInformation( KSJACK_SINK_INFORMATION *pJackSinkInformation );
		KSJACK_SINK_INFORMATION GetJackSinkInformation();
	}

	/// <summary>
	/// <para>
	/// The <c>IPart</c> interface represents a part (connector or subunit) of a device topology. A client obtains a reference to an
	/// <c>IPart</c> interface by calling the IDeviceTopology::GetPartById or IPartsList::GetPart method, or by calling the
	/// <c>QueryInterface</c> method of the IConnector or ISubunit interface on a part object and setting the method's iid parameter to
	/// <c>REFIID</c> IID_IPart.
	/// </para>
	/// <para>An object with an <c>IPart</c> interface can encapsulate one of the following device topology parts:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// <c>Connector.</c> This is a part that connects to another device to form a data path for transmitting an audio stream between devices.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>Subunit.</c> This is a part that processes an audio stream (for example, volume control).</term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>IPart</c> interface of a connector or subunit object represents the generic functions that are common to all parts, and
	/// the object's <c>IConnector</c> or <c>ISubunit</c> interface represents the functions that are specific to a connector or
	/// subunit. In addition, a part might support one or more control interfaces for controlling or monitoring the function of the
	/// part. For example, the client controls a volume-control subunit through its IAudioVolumeLevel interface.
	/// </para>
	/// <para>
	/// The <c>IPart</c> interface provides methods for getting the name, local ID, global ID, and part type of a connector or subunit.
	/// In addition, <c>IPart</c> can activate a control interface on a connector or subunit.
	/// </para>
	/// <para>
	/// For code examples that use the <c>IPart</c> interface, see the implementations of the GetHardwareDeviceTopology and
	/// SelectCaptureDevice functions in Device Topologies.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-ipart
	[PInvokeData("devicetopology.h", MSDNShortId = "3bcfab9f-fad8-4605-8780-0b7c2068fcdf")]
	[ComImport, Guid("AE2DE0E4-5BCA-4F2D-AA46-5D13F8FDB3A9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPart
	{
		/// <summary>The <c>GetName</c> method gets the friendly name of this part.</summary>
		/// <returns>
		/// A pointer variable into which the method writes the address of a null-terminated, wide-character string that contains the
		/// friendly name of this part. The method allocates the storage for the string. If the <c>GetName</c> call fails, *ppwstrName
		/// is <c>NULL</c>. For information about <c>CoTaskMemFree</c>, see the Windows SDK documentation.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-ipart-getname HRESULT GetName( PWSTR
		// *ppwstrName );
		SafeCoTaskMemString GetName();

		/// <summary>The <c>GetLocalId</c> method gets the local ID of this part.</summary>
		/// <returns>A <c>UINT</c> variable into which the method writes the local ID of this part.</returns>
		/// <remarks>
		/// <para>
		/// When you have a pointer to a part object, you can call this method to get the local ID of the part. A local ID is a number
		/// that uniquely identifies a part among all parts in a device topology.
		/// </para>
		/// <para>
		/// The IAudioInputSelector::GetSelection and IAudioOutputSelector::GetSelection methods retrieve the local ID of a connected
		/// part. The IAudioInputSelector::SetSelection and IAudioOutputSelector::SetSelection methods select the input or output that
		/// is connected to a part that is identified by its local ID. The IDeviceTopology::GetPartById method gets a part that is
		/// identified by its local ID.
		/// </para>
		/// <para>For code examples that use the <c>GetLocalId</c> method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Device Topologies</term>
		/// </item>
		/// <item>
		/// <term>Using the IKsControl Interface to Access Audio Properties</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-ipart-getlocalid HRESULT GetLocalId( UINT
		// *pnId );
		uint GetLocalId();

		/// <summary>The <c>GetGlobalId</c> method gets the global ID of this part.</summary>
		/// <returns>
		/// A pointer variable into which the method writes the address of a null-terminated, wide-character string that contains the
		/// global ID. The method allocates the storage for the string. The caller is responsible for freeing the storage, when it is no
		/// longer needed, by calling the <c>CoTaskMemFree</c> function. If the <c>GetGlobalId</c> call fails, *ppwstrGlobalId is
		/// <c>NULL</c>. For information about <c>CoTaskMemFree</c>, see the Windows SDK documentation.
		/// </returns>
		/// <remarks>
		/// A global ID is a string that uniquely identifies a part among all parts in all device topologies in the system. Clients
		/// should treat this string as opaque. That is, clients should not attempt to parse the contents of the string to obtain
		/// information about the part. The reason is that the string format is undefined and might change from one implementation of
		/// the DeviceTopology API to the next.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-ipart-getglobalid HRESULT GetGlobalId(
		// PWSTR *ppwstrGlobalId );
		SafeCoTaskMemString GetGlobalId();

		/// <summary>The <c>GetPartType</c> method gets the part type of this part.</summary>
		/// <returns>
		/// <para>
		/// A PartType variable into which the method writes the part type. The part type is one of the following <c>PartType</c>
		/// enumeration values, which indicate whether the part is a connector or subunit:
		/// </para>
		/// <para>Connector</para>
		/// <para>Subunit</para>
		/// </returns>
		/// <remarks>
		/// For a code example that uses this method, see the implementation of the SelectCaptureDevice function in Device Topologies.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-ipart-getparttype HRESULT GetPartType(
		// PartType *pPartType );
		PartType GetPartType();

		/// <summary>The <c>GetSubType</c> method gets the part subtype of this part.</summary>
		/// <returns>A GUID variable into which the method writes the subtype GUID for this part.</returns>
		/// <remarks>
		/// <para>
		/// This method typically retrieves one of the KSNODETYPE_Xxx GUID values from header file Ksmedia.h, although some custom
		/// drivers might provide other GUID values. For more information about KSNODETYPE_Xxx GUIDs, see the Windows DDK documentation.
		/// </para>
		/// <para>As explained in IPart Interface, a part can be either a connector or a subunit.</para>
		/// <para>
		/// For a part that is a connector, this method retrieves the pin-category GUID that the driver has assigned to the connector.
		/// The following are examples of pin-category GUIDs:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// KSNODETYPE_ANALOG_CONNECTOR, if the connector is part of the data path to or from an analog device such as a microphone or speakers.
		/// </term>
		/// </item>
		/// <item>
		/// <term>KSNODETYPE_SPDIF_INTERFACE, if the connector is part of the data path to or from an S/PDIF port.</term>
		/// </item>
		/// </list>
		/// <para>
		/// For more information, see the discussion of the pin-category property, KSPROPERTY_PIN_CATEGORY, in the Windows DDK documentation.
		/// </para>
		/// <para>
		/// For a part that is a subunit, this method retrieves a subtype GUID that indicates the stream-processing function that the
		/// subunit performs. For example, for a volume-control subunit, the method retrieves GUID value KSNODETYPE_VOLUME.
		/// </para>
		/// <para>The following table lists some of the subtype GUIDs that can be retrieved by the <c>GetSubType</c> method for a subunit.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Subtype GUID</term>
		/// <term>Control interface</term>
		/// <term>Required or optional</term>
		/// </listheader>
		/// <item>
		/// <term>KSNODETYPE_3D_EFFECTS</term>
		/// <term>IAudioChannelConfig</term>
		/// <term>Optional</term>
		/// </item>
		/// <item>
		/// <term>KSNODETYPE_AGC</term>
		/// <term>IAudioAutoGainControl</term>
		/// <term>Required</term>
		/// </item>
		/// <item>
		/// <term>KSNODETYPE_DAC</term>
		/// <term>IAudioChannelConfig</term>
		/// <term>Optional</term>
		/// </item>
		/// <item>
		/// <term>KSNODETYPE_DEMUX</term>
		/// <term>IAudioOutputSelector</term>
		/// <term>Required</term>
		/// </item>
		/// <item>
		/// <term>KSNODETYPE_DEV_SPECIFIC</term>
		/// <term>IDeviceSpecificProperty</term>
		/// <term>Required</term>
		/// </item>
		/// <item>
		/// <term>KSNODETYPE_LOUDNESS</term>
		/// <term>IAudioLoudness</term>
		/// <term>Required</term>
		/// </item>
		/// <item>
		/// <term>KSNODETYPE_MUTE</term>
		/// <term>IAudioMute</term>
		/// <term>Required</term>
		/// </item>
		/// <item>
		/// <term>KSNODETYPE_MUX</term>
		/// <term>IAudioInputSelector</term>
		/// <term>Required</term>
		/// </item>
		/// <item>
		/// <term>KSNODETYPE_PEAKMETER</term>
		/// <term>IAudioPeakMeter</term>
		/// <term>Required</term>
		/// </item>
		/// <item>
		/// <term>KSNODETYPE_PROLOGIC_DECODER</term>
		/// <term>IAudioChannelConfig</term>
		/// <term>Optional</term>
		/// </item>
		/// <item>
		/// <term>KSNODETYPE_TONE</term>
		/// <term>IAudioBass IAudioMidrange IAudioTreble</term>
		/// <term>OptionalOptional Optional</term>
		/// </item>
		/// <item>
		/// <term>KSNODETYPE_VOLUME</term>
		/// <term>IAudioChannelConfig IAudioVolumeLevel</term>
		/// <term>OptionalRequired</term>
		/// </item>
		/// </list>
		/// <para>
		/// In the preceding table, the middle column lists the control interfaces that are supported by subunits of the subtype
		/// specified in the left column. The right column indicates whether the subunit's support for a control interface is required
		/// or optional. If support is required, an application can rely on a subunit of the specified subtype to support the control
		/// interface. If support is optional, a subunit of the specified subtype can, but does not necessarily, support the control interface.
		/// </para>
		/// <para>
		/// The control interfaces in the preceding table provide convenient access to the properties of subunits. However, some
		/// subunits have properties for which no corresponding control interfaces exist. Applications can access these properties
		/// through the IKsControl interface. For more information, see Using the IKsControl Interface to Access Audio Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-ipart-getsubtype HRESULT GetSubType( GUID
		// *pSubType );
		Guid GetSubType();

		/// <summary>The <c>GetControlInterfaceCount</c> method gets the number of control interfaces that this part supports.</summary>
		/// <returns>A <c>UINT</c> variable into which the method writes the number of control interfaces on this part.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-ipart-getcontrolinterfacecount HRESULT
		// GetControlInterfaceCount( UINT *pCount );
		uint GetControlInterfaceCount();

		/// <summary>
		/// The <c>GetControlInterface</c> method gets a reference to the specified control interface, if this part supports it.
		/// </summary>
		/// <param name="nIndex">
		/// The control interface number. If a part supports n control interfaces, the control interfaces are numbered from 0 to n– 1.
		/// </param>
		/// <returns>
		/// The IControlInterface interface of the specified audio function. Through this method, the caller obtains a counted reference
		/// to the interface. The caller is responsible for releasing the interface, when it is no longer needed, by calling the
		/// interface's <c>Release</c> method. If the <c>GetControlInterface</c> call fails, *ppFunction is <c>NULL</c>.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-ipart-getcontrolinterface HRESULT
		// GetControlInterface( UINT nIndex, IControlInterface **ppInterfaceDesc );
		IControlInterface? GetControlInterface([In] uint nIndex);

		/// <summary>
		/// The <c>EnumPartsIncoming</c> method gets a list of all the incoming parts—that is, the parts that reside on data paths that
		/// are upstream from this part.
		/// </summary>
		/// <returns>
		/// An IPartsList interface that encapsulates the list of parts that are immediately upstream from this part. Through this
		/// method, the caller obtains a counted reference to the interface. The caller is responsible for releasing the interface, when
		/// it is no longer needed, by calling the interface's <c>Release</c> method. If the <c>EnumPartsIncoming</c> call fails,
		/// *ppParts is <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// <para>
		/// A client application can traverse a device topology against the direction of audio data flow by iteratively calling this
		/// method at each step in the traversal to get the list of parts that lie immediately upstream from the current part.
		/// </para>
		/// <para>
		/// If this part has no links to upstream parts, the method returns error code E_NOTFOUND and does not create a parts list
		/// (*ppParts is <c>NULL</c>). For example, the method returns this error code if the <c>IPart</c> interface represents a
		/// connector through which data enters a device topology.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-ipart-enumpartsincoming HRESULT
		// EnumPartsIncoming( IPartsList **ppParts );
		IPartsList? EnumPartsIncoming();

		/// <summary>
		/// The <c>EnumPartsOutgoing</c> method retrieves a list of all the outgoing parts—that is, the parts that reside on data paths
		/// that are downstream from this part.
		/// </summary>
		/// <returns>
		/// An IPartsList interface that encapsulates the list of parts that are immediately downstream from this part. Through this
		/// method, the caller obtains a counted reference to the interface. The caller is responsible for releasing the interface, when
		/// it is no longer needed, by calling the interface's <c>Release</c> method. If the <c>EnumPartsOutgoing</c> call fails,
		/// *ppParts is <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// <para>
		/// A client application can traverse a device topology in the direction of audio data flow by iteratively calling this method
		/// at each step in the traversal to get the list of parts that lie immediately downstream from the current part.
		/// </para>
		/// <para>
		/// If this part has no links to downstream parts, the method returns error code E_NOTFOUND and does not create a parts list
		/// (*ppParts is <c>NULL</c>). For example, the method returns this error code if the <c>IPart</c> interface represents a
		/// connector through which data exits a device topology.
		/// </para>
		/// <para>
		/// For a code example that uses the <c>EnumPartsOutgoing</c> method, see the implementation of the SelectCaptureDevice function
		/// in Device Topologies.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-ipart-enumpartsoutgoing HRESULT
		// EnumPartsOutgoing( IPartsList **ppParts );
		IPartsList? EnumPartsOutgoing();

		/// <summary>
		/// The <c>GetTopologyObject</c> method gets a reference to the IDeviceTopology interface of the device-topology object that
		/// contains this part.
		/// </summary>
		/// <returns>
		/// The <c>IDeviceTopology</c> interface of the device-topology object. The caller obtains a counted reference to the interface
		/// from this method. Through this method, the caller obtains a counted reference to the interface. The caller is responsible
		/// for releasing the interface, when it is no longer needed, by calling the interface's <c>Release</c> method. If the
		/// <c>GetTopologyObject</c> call fails, *ppTopology is <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// <para>For code examples that use this method, see the following topics:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Device Topologies</term>
		/// </item>
		/// <item>
		/// <term>Using the IKsControl Interface to Access Audio Properties</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-ipart-gettopologyobject HRESULT
		// GetTopologyObject( IDeviceTopology **ppTopology );
		IDeviceTopology? GetTopologyObject();

		/// <summary>The <c>Activate</c> method activates a function-specific interface on a connector or subunit.</summary>
		/// <param name="dwClsContext">
		/// The execution context in which the code that manages the newly created object will run. The caller can restrict the context
		/// by setting this parameter to the bitwise <c>OR</c> of one or more <c>CLSCTX</c> enumeration values. The client can avoid
		/// imposing any context restrictions by specifying CLSCTX_ALL. For more information about <c>CLSCTX</c>, see the Windows SDK documentation.
		/// </param>
		/// <param name="refiid">
		/// <para>
		/// The interface ID for the requested control function. The client should set this parameter to one of the following
		/// <c>REFIID</c> values:
		/// </para>
		/// <para>IID_IAudioAutoGainControl</para>
		/// <para>IID_IAudioBass</para>
		/// <para>IID_IAudioChannelConfig</para>
		/// <para>IID_IAudioInputSelector</para>
		/// <para>IID_IAudioLoudness</para>
		/// <para>IID_IAudioMidrange</para>
		/// <para>IID_IAudioMute</para>
		/// <para>IID_IAudioOutputSelector</para>
		/// <para>IID_IAudioPeakMeter</para>
		/// <para>IID_IAudioTreble</para>
		/// <para>IID_IAudioVolumeLevel</para>
		/// <para>IID_IDeviceSpecificProperty</para>
		/// <para>IID_IKsFormatSupport</para>
		/// <para>IID_IKsJackDescription</para>
		/// <para>For more information, see Remarks.</para>
		/// </param>
		/// <returns>
		/// The interface that is specified by parameter refiid. Through this method, the caller obtains a counted reference to the
		/// interface. The caller is responsible for releasing the interface, when it is no longer needed, by calling the interface's
		/// <c>Release</c> method. If the <c>Activate</c> call fails, *ppObject is <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// <para>The <c>Activate</c> method supports the following function-specific control interfaces:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IAudioAutoGainControl</term>
		/// </item>
		/// <item>
		/// <term>IAudioBass</term>
		/// </item>
		/// <item>
		/// <term>IAudioChannelConfig</term>
		/// </item>
		/// <item>
		/// <term>IAudioInputSelector</term>
		/// </item>
		/// <item>
		/// <term>IAudioLoudness</term>
		/// </item>
		/// <item>
		/// <term>IAudioMidrange</term>
		/// </item>
		/// <item>
		/// <term>IAudioMute</term>
		/// </item>
		/// <item>
		/// <term>IAudioOutputSelector</term>
		/// </item>
		/// <item>
		/// <term>IAudioPeakMeter</term>
		/// </item>
		/// <item>
		/// <term>IAudioTreble</term>
		/// </item>
		/// <item>
		/// <term>IAudioVolumeLevel</term>
		/// </item>
		/// <item>
		/// <term>IDeviceSpecificProperty</term>
		/// </item>
		/// <item>
		/// <term>IKsFormatSupport</term>
		/// </item>
		/// <item>
		/// <term>IKsJackDescription</term>
		/// </item>
		/// </list>
		/// <para>
		/// To obtain the interface ID of the function-specific control interface of a part, call the part's IControlInterface::GetIID
		/// method. To obtain the interface ID of a function-specific control interface type, use the <c>__uuidof</c> operator. For
		/// example, the interface ID of <c>IAudioAutoGainControl</c> is defined as follows:
		/// </para>
		/// <para>For more information about the <c>__uuidof</c> operator, see the Windows SDK documentation.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-ipart-activate HRESULT Activate( DWORD
		// dwClsContext, REFIID refiid, void **ppvObject );
		[return: MarshalAs(UnmanagedType.IUnknown, SizeParamIndex = 1)]
		object? Activate([In] CLSCTX dwClsContext, in Guid refiid);

		/// <summary>
		/// The <c>RegisterControlChangeCallback</c> method registers the IControlChangeNotify interface, which the client implements to
		/// receive notifications of status changes in this part.
		/// </summary>
		/// <param name="riid">
		/// The function-specific control interface that is to be monitored for control changes. For more information, see Remarks.
		/// </param>
		/// <param name="pNotify">
		/// Pointer to the client's IControlChangeNotify interface. If the method succeeds, it calls the AddRef method on the client's
		/// <c>IControlChangeNotify</c> interface.
		/// </param>
		/// <remarks>
		/// <para>Set parameter riid to one of the following GUID values:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>IID_IAudioAutoGainControl</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioBass</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioChannelConfig</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioInputSelector</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioLoudness</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioMidrange</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioMute</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioOutputSelector</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioPeakMeter</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioTreble</term>
		/// </item>
		/// <item>
		/// <term>IID_IAudioVolumeLevel</term>
		/// </item>
		/// <item>
		/// <term>IID_IDeviceSpecificProperty</term>
		/// </item>
		/// <item>
		/// <term>IID_IKsFormatSupport</term>
		/// </item>
		/// <item>
		/// <term>IID_IKsJackDescription</term>
		/// </item>
		/// </list>
		/// <para>
		/// To obtain the interface ID of the function-specific control interface for a part, call the part's IControlInterface::GetIID
		/// method. To obtain the interface ID of a function-specific control interface type, use the <c>__uuidof</c> operator. For
		/// example, the interface ID of IAudioAutoGainControl is defined as follows:
		/// </para>
		/// <para>For more information about the <c>__uuidof</c> operator, see the Windows SDK documentation.</para>
		/// <para>
		/// Before the client releases its final reference to the IControlChangeNotify interface, it should call the
		/// IPart::UnregisterControlChangeCallback method to unregister the interface. Otherwise, the application leaks the resources
		/// held by the <c>IControlChangeNotify</c> and IPart objects. Note that <c>RegisterControlChangeCallback</c> calls the client's
		/// IControlChangeNotify::AddRef method, and <c>UnregisterControlChangeCallback</c> calls the IControlChangeNotify::Release
		/// method. If the client errs by releasing its reference to the <c>IControlChangeNotify</c> interface before calling
		/// <c>UnregisterControlChangeCallback</c>, the <c>IPart</c> object never releases its reference to the
		/// <c>IControlChangeNotify</c> interface. For example, a poorly designed <c>IControlChangeNotify</c> implementation might call
		/// <c>UnregisterControlChangeCallback</c> from the destructor for the <c>IControlChangeNotify</c> object. In this case, the
		/// client will not call <c>UnregisterControlChangeCallback</c> until the <c>IPart</c> object releases its reference to the
		/// <c>IControlChangeNotify</c> interface, and the <c>IPart</c> object will not release its reference to the
		/// <c>IControlChangeNotify</c> interface until the client calls <c>UnregisterControlChangeCallback</c>. For more information
		/// about the <c>AddRef</c> and <c>Release</c> methods, see the discussion of the IUnknown interface in the Windows SDK documentation.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-ipart-registercontrolchangecallback
		// HRESULT RegisterControlChangeCallback( REFGUID riid, IControlChangeNotify *pNotify );
		void RegisterControlChangeCallback(in Guid riid, [In] IControlChangeNotify pNotify);

		/// <summary>
		/// The <c>UnregisterControlChangeCallback</c> method removes the registration of an IControlChangeNotify interface that the
		/// client previously registered by a call to the IPart::RegisterControlChangeCallback method.
		/// </summary>
		/// <param name="pNotify">
		/// Pointer to the <c>IControlChangeNotify</c> interface whose registration is to be deleted. The client passed this same
		/// interface pointer to the part object in a previous call to the <c>IPart::RegisterControlChangeCallback</c> method. If the
		/// <c>UnregisterControlChangeCallback</c> method succeeds, it calls the <c>Release</c> method on the client's
		/// <c>IControlChangeNotify</c> interface.
		/// </param>
		/// <remarks>
		/// Before the client releases its final reference to the <c>IControlChangeNotify</c> interface, it should call
		/// <c>UnregisterControlChangeCallback</c> to unregister the interface. Otherwise, the application leaks the resources held by
		/// the <c>IControlChangeNotify</c> and <c>IPart</c> objects. Note that the <c>IPart::RegisterControlChangeCallback</c> method
		/// calls the client's <c>IControlChangeNotify::AddRef</c> method, and <c>UnregisterControlChangeCallback</c> calls the
		/// <c>IControlChangeNotify::Release</c> method. If the client errs by releasing its reference to the
		/// <c>IControlChangeNotify</c> interface before calling <c>UnregisterControlChangeCallback</c>, the <c>IPart</c> object never
		/// releases its reference to the <c>IControlChangeNotify</c> interface. For example, a poorly designed
		/// <c>IControlChangeNotify</c> implementation might call <c>UnregisterControlChangeCallback</c> from the destructor for the
		/// <c>IControlChangeNotify</c> object. In this case, the client will not call <c>UnregisterControlChangeCallback</c> until the
		/// <c>IPart</c> object releases its reference to the <c>IControlChangeNotify</c> interface, and the <c>IPart</c> object will
		/// not release its reference to the <c>IControlChangeNotify</c> interface until the client calls
		/// <c>UnregisterControlChangeCallback</c>. For more information about the <c>AddRef</c> and <c>Release</c> methods, see the
		/// discussion of the <c>IUnknown</c> interface in the Windows SDK documentation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-ipart-unregistercontrolchangecallback
		// HRESULT UnregisterControlChangeCallback( IControlChangeNotify *pNotify );
		void UnregisterControlChangeCallback([In] IControlChangeNotify pNotify);
	}

	/// <summary>
	/// The <c>Activate</c> method activates a function-specific interface on a connector or subunit.
	/// </summary>
	/// <typeparam name="T">The type of the interface for the requested control function.</typeparam>
	/// <param name="part">The part.</param>
	/// <param name="dwClsContext">The execution context in which the code that manages the newly created object will run. The caller can restrict the context
	/// by setting this parameter to the bitwise <c>OR</c> of one or more <c>CLSCTX</c> enumeration values. The client can avoid
	/// imposing any context restrictions by specifying CLSCTX_ALL. For more information about <c>CLSCTX</c>, see the Windows SDK documentation.</param>
	/// <returns>
	/// The interface that is specified by <typeparamref name="T"/>. Through this method, the caller obtains a counted reference to the
	/// interface. The caller is responsible for releasing the interface, when it is no longer needed, by calling the interface's
	/// <c>Release</c> method. If the <c>Activate</c> call fails, *ppObject is <c>NULL</c>.
	/// </returns>
	/// <remarks>
	/// <para>The <c>Activate</c> method supports the following function-specific control interfaces:</para>
	/// <list type="bullet">
	///   <item>
	///     <term>IAudioAutoGainControl</term>
	///   </item>
	///   <item>
	///     <term>IAudioBass</term>
	///   </item>
	///   <item>
	///     <term>IAudioChannelConfig</term>
	///   </item>
	///   <item>
	///     <term>IAudioInputSelector</term>
	///   </item>
	///   <item>
	///     <term>IAudioLoudness</term>
	///   </item>
	///   <item>
	///     <term>IAudioMidrange</term>
	///   </item>
	///   <item>
	///     <term>IAudioMute</term>
	///   </item>
	///   <item>
	///     <term>IAudioOutputSelector</term>
	///   </item>
	///   <item>
	///     <term>IAudioPeakMeter</term>
	///   </item>
	///   <item>
	///     <term>IAudioTreble</term>
	///   </item>
	///   <item>
	///     <term>IAudioVolumeLevel</term>
	///   </item>
	///   <item>
	///     <term>IDeviceSpecificProperty</term>
	///   </item>
	///   <item>
	///     <term>IKsFormatSupport</term>
	///   </item>
	///   <item>
	///     <term>IKsJackDescription</term>
	///   </item>
	/// </list>
	/// </remarks>
	public static T? Activate<T>(this IPart part, [In] CLSCTX dwClsContext = CLSCTX.CLSCTX_ALL) where T : class => part.Activate(dwClsContext, typeof(T).GUID) as T;

	/// <summary>
	/// <para>
	/// The <c>IPartsList</c> interface represents a list of parts, each of which is an object with an IPart interface that represents a
	/// connector or subunit. A client obtains a reference to an <c>IPartsList</c> interface by calling the IPart::EnumPartsIncoming,
	/// IPart::EnumPartsOutgoing, or IDeviceTopology::GetSignalPath method.
	/// </para>
	/// <para>
	/// For a code example that uses the <c>IPartsList</c> interface, see the implementation of the SelectCaptureDevice function in
	/// Device Topologies.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-ipartslist
	[PInvokeData("devicetopology.h", MSDNShortId = "3ac48781-90c2-4b23-aa68-3453091bde61")]
	[ComImport, Guid("6DAA848C-5EB0-45CC-AEA5-998A2CDA1FFB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPartsList
	{
		/// <summary>The <c>GetCount</c> method gets the number of parts in the parts list.</summary>
		/// <returns>A <c>UINT</c> variable into which the method writes the parts count (the number of parts in the parts list).</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-ipartslist-getcount HRESULT GetCount(
		// UINT *pCount );
		uint GetCount();

		/// <summary>The <c>GetPart</c> method gets a part from the parts list.</summary>
		/// <param name="nIndex">
		/// The part number of the part to retrieve. If the parts list contains n parts, the parts are numbered 0 to n– 1. Call the
		/// IPartsList::GetCount method to get the number of parts in the list.
		/// </param>
		/// <returns>
		/// The IPart interface of the part object. Through this method, the caller obtains a counted reference to the <c>IPart</c>
		/// interface. The caller is responsible for releasing the interface, when it is no longer needed, by calling the interface's
		/// <c>Release</c> method. If the <c>GetPart</c> call fails, *ppPart is <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// For a code example that calls the <c>GetPart</c> method, see the implementation of the SelectCaptureDevice function in
		/// Device Topologies.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-ipartslist-getpart HRESULT GetPart( UINT
		// nIndex, IPart **ppPart );
		IPart? GetPart([In] uint nIndex);
	}

	/// <summary>
	/// <para>
	/// The <c>IPerChannelDbLevel</c> interface represents a generic subunit control interface that provides per-channel control over
	/// the volume level, in decibels, of an audio stream or of a frequency band in an audio stream. A positive volume level represents
	/// gain, and a negative value represents attenuation.
	/// </para>
	/// <para>
	/// Clients do not call the methods in this interface directly. Instead, this interface serves as the base interface for the
	/// following interfaces, which clients do call directly:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>IAudioBass Interface</term>
	/// </item>
	/// <item>
	/// <term>IAudioMidrange Interface</term>
	/// </item>
	/// <item>
	/// <term>IAudioTreble Interface</term>
	/// </item>
	/// <item>
	/// <term>IAudioVolumeLevel Interface</term>
	/// </item>
	/// </list>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-iperchanneldblevel
	[ComImport, Guid("C2F8E001-F205-4BC9-99BC-C13B1E048CCB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPerChannelDbLevel
	{
		/// <summary>The <c>GetChannelCount</c> method gets the number of channels in the audio stream.</summary>
		/// <returns>A <c>UINT</c> variable into which the method writes the channel count (the number of channels in the audio stream).</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-getchannelcount
		// HRESULT GetChannelCount( UINT *pcChannels );
		uint GetChannelCount();

		/// <summary>The <c>GetLevelRange</c> method gets the range, in decibels, of the volume level of the specified channel.</summary>
		/// <param name="nChannel">
		/// The number of the selected channel. If the audio stream has n channels, the channels are numbered from 0 to n– 1. To get the
		/// number of channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <param name="pfMinLevelDB">
		/// Pointer to a <c>float</c> variable into which the method writes the minimum volume level in decibels.
		/// </param>
		/// <param name="pfMaxLevelDB">
		/// Pointer to a <c>float</c> variable into which the method writes the maximum volume level in decibels.
		/// </param>
		/// <param name="pfStepping">
		/// Pointer to a <c>float</c> variable into which the method writes the stepping value between consecutive volume levels in the
		/// range *pfMinLevelDB to *pfMaxLevelDB. If the difference between the maximum and minimum volume levels is d decibels, and the
		/// range is divided into n steps (uniformly sized intervals), then the volume can have n + 1 discrete levels and the size of
		/// the step between consecutive levels is d / n decibels.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-getlevelrange HRESULT
		// GetLevelRange( UINT nChannel, float *pfMinLevelDB, float *pfMaxLevelDB, float *pfStepping );
		void GetLevelRange([In] uint nChannel, out float pfMinLevelDB, out float pfMaxLevelDB, out float pfStepping);

		/// <summary>The <c>GetLevel</c> method gets the volume level, in decibels, of the specified channel.</summary>
		/// <param name="nChannel">
		/// The channel number. If the audio stream has N channels, the channels are numbered from 0 to N– 1. To get the number of
		/// channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <returns>A <c>float</c> variable into which the method writes the volume level, in decibels, of the specified channel.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-getlevel HRESULT
		// GetLevel( UINT nChannel, float *pfLevelDB );
		float GetLevel([In] uint nChannel);

		/// <summary>The <c>SetLevel</c> method sets the volume level, in decibels, of the specified channel.</summary>
		/// <param name="nChannel">
		/// The number of the selected channel. If the audio stream has N channels, the channels are numbered from 0 to N– 1. To get the
		/// number of channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <param name="fLevelDB">
		/// The new volume level in decibels. A positive value represents gain, and a negative value represents attenuation.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetLevel</c> call changes the state of the level control, all clients that have registered IControlChangeNotify
		/// interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c> method, a client can
		/// inspect the event-context GUID to discover whether it or another client is the source of the control-change event. If the
		/// caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// <para>
		/// If the caller specifies a value for fLevelDB that is an exact stepping value, the <c>SetLevel</c> method completes
		/// successfully. A subsequent call to the IPerChannelDbLevel::GetLevel method will return either the value that was set, or one
		/// of the following values:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>If the set value was below the minimum, the <c>GetLevel</c> method returns the minimum value.</term>
		/// </item>
		/// <item>
		/// <term>If the set value was above the maximum, the <c>GetLevel</c> method returns the maximum value.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If the set value was between two stepping values, the <c>GetLevel</c> method returns a value that could be the next stepping
		/// value above or the stepping value below the set value; the relative distances from the set value to the neighboring stepping
		/// values is unimportant. The value that the <c>GetLevel</c> method returns is whichever value has more of an impact on the
		/// signal path.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-setlevel HRESULT
		// SetLevel( UINT nChannel, float fLevelDB, LPCGUID pguidEventContext );
		void SetLevel([In] uint nChannel, [In] float fLevelDB, [Optional, In] GuidPtr pguidEventContext);

		/// <summary>
		/// The <c>SetLevelUniform</c> method sets all channels in the audio stream to the same uniform volume level, in decibels.
		/// </summary>
		/// <param name="fLevelDB">The new uniform level in decibels.</param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetLevelUniform</c> call changes the state of the level control, all clients that have registered IControlChangeNotify
		/// interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c> method, a client can
		/// inspect the event-context GUID to discover whether it or another client is the source of the control-change event. If the
		/// caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// If the specified uniform level is beyond the range that the IPerChannelDbLevel::GetLevelRange method reports for a
		/// particular channel, the <c>SetLevelUniform</c> call clamps the value for that channel to the supported range and completes
		/// successfully. A subsequent call to the IPerChannelDbLevel::GetLevel method retrieves the actual value used for that channel.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-setleveluniform
		// HRESULT SetLevelUniform( float fLevelDB, LPCGUID pguidEventContext );
		void SetLevelUniform([In] float fLevelDB, [Optional, In] GuidPtr pguidEventContext);

		/// <summary>
		/// The <c>SetLevelAllChannels</c> method sets the volume levels, in decibels, of all the channels in the audio stream.
		/// </summary>
		/// <param name="aLevelsDB">
		/// Pointer to an array of volume levels. This parameter points to a caller-allocated <c>float</c> array into which the method
		/// writes the new volume levels, in decibels, for all the channels. The method writes the level for a particular channel into
		/// the array element whose index matches the channel number. If the audio stream contains n channels, the channels are numbered
		/// 0 to n– 1. To get the number of channels in the stream, call the IPerChannelDbLevel::GetChannelCount method.
		/// </param>
		/// <param name="cChannels">
		/// The number of elements in the aLevelsDB array. If this parameter does not match the number of channels in the audio stream,
		/// the method fails without modifying the aLevelsDB array.
		/// </param>
		/// <param name="pguidEventContext">
		/// Context value for the IControlChangeNotify::OnNotify method. This parameter points to an event-context GUID. If the
		/// <c>SetLevelAllChannels</c> call changes the state of the level control, all clients that have registered
		/// IControlChangeNotify interfaces with that control receive notifications. In its implementation of the <c>OnNotify</c>
		/// method, a client can inspect the event-context GUID to discover whether it or another client is the source of the
		/// control-change event. If the caller supplies a <c>NULL</c> pointer for this parameter, the client's notification method
		/// receives a <c>NULL</c> context pointer.
		/// </param>
		/// <remarks>
		/// If the specified level value for any channel is beyond the range that the IPerChannelDbLevel::GetLevelRange method reports
		/// for that channel, the <c>SetLevelAllChannels</c> call clamps the value to the supported range and completes successfully. A
		/// subsequent call to the IPerChannelDbLevel::GetLevel method retrieves the actual value used for that channel.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nf-devicetopology-iperchanneldblevel-setlevelallchannels
		// HRESULT SetLevelAllChannels( float [] aLevelsDB, ULONG cChannels, LPCGUID pguidEventContext );
		void SetLevelAllChannels([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] aLevelsDB, [In] uint cChannels, [Optional, In] GuidPtr pguidEventContext);
	}

	/// <summary>
	/// The <c>ISubunit</c> interface represents a hardware subunit (for example, a volume control) that lies in the data path between a
	/// client and an audio endpoint device. The client obtains a reference to an <c>ISubunit</c> interface by calling the
	/// IDeviceTopology::GetSubunit method, or by calling the <c>IPart::QueryInterface</c> method with parameter iid set to
	/// <c>REFIID</c> IID_ISubunit.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/nn-devicetopology-isubunit
	[PInvokeData("devicetopology.h", MSDNShortId = "9ec630bc-bba1-4a44-b66d-404a5221abbf")]
	[ComImport, Guid("82149A85-DBA6-4487-86BB-EA8F7FEFCC71"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISubunit
	{
	}

	/// <summary>The <c>KSJACK_DESCRIPTION</c> structure describes an audio jack.</summary>
	/// <remarks>
	/// This structure is used by the IKsJackDescription::GetJackDescription method in the DeviceTopology API. It describes an audio
	/// jack that is part of a connection between an endpoint device and a hardware device in an audio adapter. When a user needs to
	/// plug an endpoint device into a jack or unplug it from a jack, an audio application can use the descriptive information in the
	/// structure to help the user to find the jack.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/ns-devicetopology-ksjack_description typedef struct
	// __MIDL___MIDL_itf_devicetopology_0000_0000_0009 { DWORD ChannelMapping; COLORREF Color; EPcxConnectionType ConnectionType;
	// EPcxGeoLocation GeoLocation; EPcxGenLocation GenLocation; EPxcPortConnection PortConnection; BOOL IsConnected; }
	// KSJACK_DESCRIPTION, *PKSJACK_DESCRIPTION;
	[PInvokeData("devicetopology.h", MSDNShortId = "4ee9fedf-4241-4678-b621-549a06e8949a")]
	[StructLayout(LayoutKind.Sequential)]
	public struct KSJACK_DESCRIPTION
	{
		/// <summary>
		/// <para>Specifies the mapping of the two audio channels in a stereo jack to speaker positions.</para>
		/// <para>
		/// In Windows Vista, the value of this member is one of the <c>EChannelMapping</c> enumeration values shown in the following table.
		/// </para>
		/// <para>For a physical connector with one, three, or more channels, the value of this member is ePcxChanMap_Unknown.</para>
		/// <para>
		/// In Windows 7, the <c>EChannelMapping</c> enumeration has been deprecated. The datatype of this member is a <c>DWORD</c>.
		/// This member stores either 0 or the bitwise-OR combination of one or more of the following values that are defined in Ksmedia.h.
		/// </para>
		/// </summary>
		public ChannelMapping ChannelMapping;

		/// <summary>
		/// The jack color. The color is expressed as a 32-bit RGB value that is formed by concatenating the 8-bit blue, green, and red
		/// color components. The blue component occupies the 8 least-significant bits (bits 0-7), the green component occupies bits
		/// 8-15, and the red component occupies bits 16-23. The 8 most-significant bits are zeros. If the jack color is unknown or the
		/// physical connector has no identifiable color, the value of this member is 0x00000000, which is black.
		/// </summary>
		public COLORREF Color;

		/// <summary>
		/// <para>
		/// The connection type. The value of this member is one of the <c>EPcxConnectionType</c> enumeration values shown in the
		/// following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Connector type</term>
		/// </listheader>
		/// <item>
		/// <term>eConnTypeUnknown</term>
		/// <term>Unknown</term>
		/// </item>
		/// <item>
		/// <term>eConnTypeEighth (Windows Vista) eConnType3Point5mm (Windows 7)</term>
		/// <term/>
		/// <term>1/8-inch jack</term>
		/// </item>
		/// <item>
		/// <term>eConnTypeQuarter</term>
		/// <term>1/4-inch jack</term>
		/// </item>
		/// <item>
		/// <term>eConnTypeAtapiInternal</term>
		/// <term>ATAPI internal connector</term>
		/// </item>
		/// <item>
		/// <term>eConnTypeRCA</term>
		/// <term>RCA jack</term>
		/// </item>
		/// <item>
		/// <term>eConnTypeOptical</term>
		/// <term>Optical connector</term>
		/// </item>
		/// <item>
		/// <term>eConnTypeOtherDigital</term>
		/// <term>Generic digital connector</term>
		/// </item>
		/// <item>
		/// <term>eConnTypeOtherAnalog</term>
		/// <term>Generic analog connector</term>
		/// </item>
		/// <item>
		/// <term>eConnTypeMultichannelAnalogDIN</term>
		/// <term>Multichannel analog DIN connector</term>
		/// </item>
		/// <item>
		/// <term>eConnTypeXlrProfessional</term>
		/// <term>XLR connector</term>
		/// </item>
		/// <item>
		/// <term>eConnTypeRJ11Modem</term>
		/// <term>RJ11 modem connector</term>
		/// </item>
		/// <item>
		/// <term>eConnTypeCombination</term>
		/// <term>Combination of connector types</term>
		/// </item>
		/// </list>
		/// </summary>
		public EPcxConnectionType ConnectionType;

		/// <summary>
		/// <para>
		/// The geometric location of the jack. The value of this member is one of the <c>EPcxGeoLocation</c> enumeration values shown
		/// in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Geometric location</term>
		/// </listheader>
		/// <item>
		/// <term>eGeoLocRear</term>
		/// <term>Rear-mounted panel</term>
		/// </item>
		/// <item>
		/// <term>eGeoLocFront</term>
		/// <term>Front-mounted panel</term>
		/// </item>
		/// <item>
		/// <term>eGeoLocLeft</term>
		/// <term>Left-mounted panel</term>
		/// </item>
		/// <item>
		/// <term>eGeoLocRight</term>
		/// <term>Right-mounted panel</term>
		/// </item>
		/// <item>
		/// <term>eGeoLocTop</term>
		/// <term>Top-mounted panel</term>
		/// </item>
		/// <item>
		/// <term>eGeoLocBottom</term>
		/// <term>Bottom-mounted panel</term>
		/// </item>
		/// <item>
		/// <term>eGeoLocRearOPanel(Windows Vista) eGeoLocRearPanel(Windows 7)</term>
		/// <term>Rear slide-open or pull-open panel</term>
		/// </item>
		/// <item>
		/// <term>eGeoLocRiser</term>
		/// <term>Riser card</term>
		/// </item>
		/// <item>
		/// <term>eGeoLocInsideMobileLid</term>
		/// <term>Inside lid of mobile computer</term>
		/// </item>
		/// <item>
		/// <term>eGeoLocDrivebay</term>
		/// <term>Drive bay</term>
		/// </item>
		/// <item>
		/// <term>eGeoLocHDMI</term>
		/// <term>HDMI connector</term>
		/// </item>
		/// <item>
		/// <term>eGeoLocOutsideMobileLid</term>
		/// <term>Outside lid of mobile computer</term>
		/// </item>
		/// <item>
		/// <term>eGeoLocATAPI</term>
		/// <term>ATAPI connector</term>
		/// </item>
		/// </list>
		/// </summary>
		public EPcxGeoLocation GeoLocation;

		/// <summary>
		/// <para>
		/// The general location of the jack. The value of this member is one of the <c>EPcxGenLocation</c> enumeration values shown in
		/// the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>General location</term>
		/// </listheader>
		/// <item>
		/// <term>eGenLocPrimaryBox</term>
		/// <term>On primary chassis</term>
		/// </item>
		/// <item>
		/// <term>eGenLocInternal</term>
		/// <term>Inside primary chassis</term>
		/// </item>
		/// <item>
		/// <term>eGenLocSeperate(Windows Vista) eGenLocSeparate(Windows 7)</term>
		/// <term>On separate chassis</term>
		/// </item>
		/// <item>
		/// <term>eGenLocOther</term>
		/// <term>Other location</term>
		/// </item>
		/// </list>
		/// </summary>
		public EPcxGenLocation GenLocation;

		/// <summary>
		/// <para>
		/// The type of port represented by the jack. The value of this member is one of the <c>EPxcPortConnection</c> enumeration
		/// values shown in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Port connection type</term>
		/// </listheader>
		/// <item>
		/// <term>ePortConnJack</term>
		/// <term>Jack</term>
		/// </item>
		/// <item>
		/// <term>ePortConnIntegratedDevice</term>
		/// <term>Slot for an integrated device</term>
		/// </item>
		/// <item>
		/// <term>ePortConnBothIntegratedAndJack</term>
		/// <term>Both a jack and a slot for an integrated device</term>
		/// </item>
		/// <item>
		/// <term>ePortConnUnknown</term>
		/// <term>Unknown</term>
		/// </item>
		/// </list>
		/// </summary>
		public EPxcPortConnection PortConnection;

		/// <summary>
		/// If the audio adapter supports jack-presence detection on the jack, the value of <c>IsConnected</c> indicates whether an
		/// endpoint device is plugged into the jack. If <c>IsConnected</c> is <c>TRUE</c>, a device is plugged in. If it is
		/// <c>FALSE</c>, the jack is empty. For devices that do not support jack-presence detection, this member is always <c>TRUE</c>.
		/// For more information about jack-presence detection, see Audio Endpoint Devices.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool IsConnected;
	}

	/// <summary>The structure specifies the capabilities and the current state of a jack that supports jack presence detection.</summary>
	/// <remarks>
	/// If an audio device lacks jack presence detection, the <c>IsConnected</c> member of the <c>KSJACK_DESCRIPTION</c> structure must
	/// always be set to <c>TRUE</c>. To remove the ambiguity that results from this dual meaning of the <c>TRUE</c> value for
	/// <c>IsConnected</c>, a client application can call IKsJackDescription2::GetJackDescription2 to read the <c>JackCapabilities</c>
	/// flag of the structure. If this flag has the JACKDESC2_PRESENCE_DETECT_CAPABILITY bit set, it indicates that the endpoint does in
	/// fact support jack presence detection. In that case, the return value of the <c>IsConnected</c> member can be interpreted to
	/// accurately reflect the insertion status of the jack.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/audio/ksjack-description2 typedef struct _tagKSJACK_DESCRIPTION2 {
	// DWORD DeviceStateInfo; DWORD JackCapabilities; } KSJACK_DESCRIPTION2, *PKSJACK_DESCRIPTION2;
	[PInvokeData("Ksmedia.h", MSDNShortId = "0db29870-20d0-459b-a531-3dea5d073183")]
	[StructLayout(LayoutKind.Sequential)]
	public struct KSJACK_DESCRIPTION2
	{
		/// <summary>
		/// Specifies the lower 16 bits of the DWORD parameter. This parameter indicates whether the jack is currently active,
		/// streaming, idle, or hardware not ready.
		/// </summary>
		public uint DeviceStateInfo;

		/// <summary>
		/// <para>
		/// Specifies the lower 16 bits of the DWORD parameter. This parameter is a flag and it indicates the capabilities of the jack.
		/// This flag can be set to one of the values in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>JACKDESC2_PRESENCE_DETECT_CAPABILITY (0x00000001)</term>
		/// <term>Jack supports jack presence detection.</term>
		/// </item>
		/// <item>
		/// <term>JACKDESC2_DYNAMIC_FORMAT_CHANGE_CAPABILITY (0x00000002)</term>
		/// <term>Jack supports dynamic format change.</term>
		/// </item>
		/// </list>
		/// <para>For more information about dynamic format change, see Dynamic Format Change.</para>
		/// </summary>
		public JackCapabilities JackCapabilities;
	}

	/// <summary>The <c>KSJACK_SINK_INFORMATION</c> structure stores information about an audio jack sink.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/devicetopology/ns-devicetopology-ksjack_sink_information typedef struct
	// _tagKSJACK_SINK_INFORMATION { KSJACK_SINK_CONNECTIONTYPE ConnType; WORD ManufacturerId; WORD ProductId; WORD AudioLatency; BOOL
	// HDCPCapable; BOOL AICapable; UCHAR SinkDescriptionLength; WCHAR SinkDescription[32]; LUID PortId; } KSJACK_SINK_INFORMATION;
	[PInvokeData("devicetopology.h", MSDNShortId = "ee7211d8-a34f-40c9-9925-7bb40792bae9")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct KSJACK_SINK_INFORMATION
	{
		/// <summary>Specifies the type of connection. The connection type values are defined in the KSJACK_SINK_CONNECTIONTYPE enumeration.</summary>
		public KSJACK_SINK_CONNECTIONTYPE ConnType;

		/// <summary>Specifies the sink manufacturer identifier.</summary>
		public ushort ManufacturerId;

		/// <summary>Specifies the sink product identifier.</summary>
		public ushort ProductId;

		/// <summary>Specifies the latency of the audio sink.</summary>
		public ushort AudioLatency;

		/// <summary>Specifies whether the sink supports High-bandwidth Digital Content Protection (HDCP).</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool HDCPCapable;

		/// <summary>Specifies whether the sink supports ACP Packet, ISRC1, or ISRC2.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool AICapable;

		/// <summary>Specifies the length of the string in the <c>SinkDescription</c> member.</summary>
		public byte SinkDescriptionLength;

		/// <summary>
		/// String containing the monitor sink name. The maximum length is defined by the constant
		/// <c>MAX_SINK_DESCRIPTION_NAME_LENGTH</c> (32 wide characters).
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string SinkDescription;

		/// <summary>Specifies the video port identifier in a LUID structure.</summary>
		public LUID PortId;
	}
}