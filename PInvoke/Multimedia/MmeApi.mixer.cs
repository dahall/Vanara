#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Items from the WinMm.dll</summary>
	public static partial class WinMm
	{
		/// <summary></summary>
		public const MIXERCONTROL_CT MIXERCONTROL_CT_CLASS_MASK = (MIXERCONTROL_CT)0xF0000000;

		/// <summary></summary>
		public const MIXERCONTROL_CT MIXERCONTROL_CT_SUBCLASS_MASK = (MIXERCONTROL_CT)0x0F000000;

		/// <summary></summary>
		public const MIXERCONTROL_CT MIXERCONTROL_CT_UNITS_MASK = (MIXERCONTROL_CT)0x00FF0000;

		private const int MIXER_LONG_NAME_CHARS = 64;
		private const int MIXER_SHORT_NAME_CHARS = 16;
		private const int MIXERLINE_COMPONENTTYPE_DST_FIRST = 0x00000000;
		private const int MIXERLINE_COMPONENTTYPE_SRC_FIRST = 0x00001000;

		/// <summary>Flags for retrieving control details.</summary>
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.mixerGetControlDetails")]
		[Flags]
		public enum MIXER_OBJECTF : uint
		{
			/// <summary>
			/// Current values for a control are retrieved. The paDetails member of the MIXERCONTROLDETAILS structure points to one or more
			/// details structures appropriate for the control class.
			/// </summary>
			MIXER_GETCONTROLDETAILSF_VALUE = 0x00000000,

			/// <summary>
			/// The paDetails member of the MIXERCONTROLDETAILS structure points to one or more MIXERCONTROLDETAILS_LISTTEXT structures to
			/// receive text labels for multiple-item controls. An application must get all list text items for a multiple-item control at
			/// once. This flag cannot be used with MIXERCONTROL_CONTROLTYPE_CUSTOM controls.
			/// </summary>
			MIXER_GETCONTROLDETAILSF_LISTTEXT = 0x00000001,

			/// <summary></summary>
			MIXER_OBJECTF_HANDLE = 0x80000000,

			/// <summary>
			/// The hmxobj parameter is the identifier of a mixer device in the range of zero to one less than the number of devices
			/// returned by the mixerGetNumDevs function. This flag is optional.
			/// </summary>
			MIXER_OBJECTF_MIXER = 0x00000000,

			/// <summary>The hmxobj parameter is a mixer device handle returned by the mixerOpen function. This flag is optional.</summary>
			MIXER_OBJECTF_HMIXER = MIXER_OBJECTF_HANDLE | MIXER_OBJECTF_MIXER,

			/// <summary>
			/// The hmxobj parameter is the identifier of a waveform-audio output device in the range of zero to one less than the number of
			/// devices returned by the waveOutGetNumDevs function.
			/// </summary>
			MIXER_OBJECTF_WAVEOUT = 0x10000000,

			/// <summary>The hmxobj parameter is a waveform-audio output handle returned by the waveOutOpen function.</summary>
			MIXER_OBJECTF_HWAVEOUT = MIXER_OBJECTF_HANDLE | MIXER_OBJECTF_WAVEOUT,

			/// <summary>
			/// The hmxobj parameter is the identifier of a waveform-audio input device in the range of zero to one less than the number of
			/// devices returned by the waveInGetNumDevs function.
			/// </summary>
			MIXER_OBJECTF_WAVEIN = 0x20000000,

			/// <summary>The hmxobj parameter is a waveform-audio input handle returned by the waveInOpen function.</summary>
			MIXER_OBJECTF_HWAVEIN = MIXER_OBJECTF_HANDLE | MIXER_OBJECTF_WAVEIN,

			/// <summary>
			/// The hmxobj parameter is the identifier of a MIDI output device. This identifier must be in the range of zero to one less
			/// than the number of devices returned by the midiOutGetNumDevs function.
			/// </summary>
			MIXER_OBJECTF_MIDIOUT = 0x30000000,

			/// <summary>
			/// The hmxobj parameter is the handle of a MIDI output device. This handle must have been returned by the midiOutOpen function.
			/// </summary>
			MIXER_OBJECTF_HMIDIOUT = MIXER_OBJECTF_HANDLE | MIXER_OBJECTF_MIDIOUT,

			/// <summary>
			/// The hmxobj parameter is the identifier of a MIDI input device. This identifier must be in the range of zero to one less than
			/// the number of devices returned by the midiInGetNumDevs function.
			/// </summary>
			MIXER_OBJECTF_MIDIIN = 0x40000000,

			/// <summary>
			/// The hmxobj parameter is the handle of a MIDI (Musical Instrument Digital Interface) input device. This handle must have been
			/// returned by the midiInOpen function.
			/// </summary>
			MIXER_OBJECTF_HMIDIIN = MIXER_OBJECTF_HANDLE | MIXER_OBJECTF_MIDIIN,

			/// <summary>
			/// The hmxobj parameter is an auxiliary device identifier in the range of zero to one less than the number of devices returned
			/// by the auxGetNumDevs function.
			/// </summary>
			MIXER_OBJECTF_AUX = 0x50000000,
		}

		/// <summary>Status and support flags for the audio line control.</summary>
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.tMIXERCONTROL")]
		[Flags]
		public enum MIXERCONTROL_CONTROLF : uint
		{
			/// <summary>
			/// The control acts on all channels of a multichannel line in a uniform fashion. For example, a control that mutes both
			/// channels of a stereo line would set this flag. Most MIXERCONTROL_CONTROLTYPE_MUX and MIXERCONTROL_CONTROLTYPE_MIXER controls
			/// also specify the MIXERCONTROL_CONTROLF_UNIFORM flag.
			/// </summary>
			MIXERCONTROL_CONTROLF_UNIFORM = 0x00000001,

			/// <summary>
			/// The control has two or more settings per channel. An equalizer, for example, requires this flag because each frequency band
			/// can be set to a different value. An equalizer that affects both channels of a stereo line in a uniform fashion will also
			/// specify the MIXERCONTROL_CONTROLF_UNIFORM flag.
			/// </summary>
			MIXERCONTROL_CONTROLF_MULTIPLE = 0x00000002,

			/// <summary>
			/// The control is disabled, perhaps due to other settings for the mixer hardware, and cannot be used. An application can read
			/// current settings from a disabled control, but it cannot apply settings.
			/// </summary>
			MIXERCONTROL_CONTROLF_DISABLED = 0x80000000,
		}

		/// <summary>
		/// Class of the control for which the identifier is specified in <c>dwControlID</c>. An application must use this information to
		/// display the appropriate control for input from the user. An application can also display tailored graphics based on the control
		/// class or search for a particular control class on a specific line. If an application does not know about a control class, this
		/// control must be ignored.
		/// </summary>
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.tMIXERCONTROL")]
		[Flags]
		public enum MIXERCONTROL_CT : uint
		{
			/// <summary></summary>
			MIXERCONTROL_CT_CLASS_CUSTOM = 0x00000000,

			/// <summary></summary>
			MIXERCONTROL_CT_CLASS_METER = 0x10000000,

			/// <summary></summary>
			MIXERCONTROL_CT_CLASS_SWITCH = 0x20000000,

			/// <summary></summary>
			MIXERCONTROL_CT_CLASS_NUMBER = 0x30000000,

			/// <summary></summary>
			MIXERCONTROL_CT_CLASS_SLIDER = 0x40000000,

			/// <summary></summary>
			MIXERCONTROL_CT_CLASS_FADER = 0x50000000,

			/// <summary></summary>
			MIXERCONTROL_CT_CLASS_TIME = 0x60000000,

			/// <summary></summary>
			MIXERCONTROL_CT_CLASS_LIST = 0x70000000,

			/// <summary></summary>
			MIXERCONTROL_CT_SC_SWITCH_BOOLEAN = 0x00000000,

			/// <summary></summary>
			MIXERCONTROL_CT_SC_SWITCH_BUTTON = 0x01000000,

			/// <summary></summary>
			MIXERCONTROL_CT_SC_METER_POLLED = 0x00000000,

			/// <summary></summary>
			MIXERCONTROL_CT_SC_TIME_MICROSECS = 0x00000000,

			/// <summary></summary>
			MIXERCONTROL_CT_SC_TIME_MILLISECS = 0x01000000,

			/// <summary></summary>
			MIXERCONTROL_CT_SC_LIST_SINGLE = 0x00000000,

			/// <summary></summary>
			MIXERCONTROL_CT_SC_LIST_MULTIPLE = 0x01000000,

			/// <summary></summary>
			MIXERCONTROL_CT_UNITS_CUSTOM = 0x00000000,

			/// <summary></summary>
			MIXERCONTROL_CT_UNITS_BOOLEAN = 0x00010000,

			/// <summary></summary>
			MIXERCONTROL_CT_UNITS_SIGNED = 0x00020000,

			/// <summary></summary>
			MIXERCONTROL_CT_UNITS_UNSIGNED = 0x00030000,

			/// <summary>in 10ths</summary>
			MIXERCONTROL_CT_UNITS_DECIBELS = 0x00040000,

			/// <summary>in 10ths</summary>
			MIXERCONTROL_CT_UNITS_PERCENT = 0x00050000,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_CUSTOM = MIXERCONTROL_CT_CLASS_CUSTOM | MIXERCONTROL_CT_UNITS_CUSTOM,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_BOOLEANMETER = MIXERCONTROL_CT_CLASS_METER | MIXERCONTROL_CT_SC_METER_POLLED | MIXERCONTROL_CT_UNITS_BOOLEAN,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_SIGNEDMETER = MIXERCONTROL_CT_CLASS_METER | MIXERCONTROL_CT_SC_METER_POLLED | MIXERCONTROL_CT_UNITS_SIGNED,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_PEAKMETER = MIXERCONTROL_CONTROLTYPE_SIGNEDMETER + 1,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_UNSIGNEDMETER = MIXERCONTROL_CT_CLASS_METER | MIXERCONTROL_CT_SC_METER_POLLED | MIXERCONTROL_CT_UNITS_UNSIGNED,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_BOOLEAN = MIXERCONTROL_CT_CLASS_SWITCH | MIXERCONTROL_CT_SC_SWITCH_BOOLEAN | MIXERCONTROL_CT_UNITS_BOOLEAN,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_ONOFF = MIXERCONTROL_CONTROLTYPE_BOOLEAN + 1,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_MUTE = MIXERCONTROL_CONTROLTYPE_BOOLEAN + 2,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_MONO = MIXERCONTROL_CONTROLTYPE_BOOLEAN + 3,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_LOUDNESS = MIXERCONTROL_CONTROLTYPE_BOOLEAN + 4,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_STEREOENH = MIXERCONTROL_CONTROLTYPE_BOOLEAN + 5,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_BASS_BOOST = MIXERCONTROL_CONTROLTYPE_BOOLEAN + 0x00002277,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_BUTTON = MIXERCONTROL_CT_CLASS_SWITCH | MIXERCONTROL_CT_SC_SWITCH_BUTTON | MIXERCONTROL_CT_UNITS_BOOLEAN,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_DECIBELS = MIXERCONTROL_CT_CLASS_NUMBER | MIXERCONTROL_CT_UNITS_DECIBELS,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_SIGNED = MIXERCONTROL_CT_CLASS_NUMBER | MIXERCONTROL_CT_UNITS_SIGNED,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_UNSIGNED = MIXERCONTROL_CT_CLASS_NUMBER | MIXERCONTROL_CT_UNITS_UNSIGNED,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_PERCENT = MIXERCONTROL_CT_CLASS_NUMBER | MIXERCONTROL_CT_UNITS_PERCENT,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_SLIDER = MIXERCONTROL_CT_CLASS_SLIDER | MIXERCONTROL_CT_UNITS_SIGNED,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_PAN = MIXERCONTROL_CONTROLTYPE_SLIDER + 1,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_QSOUNDPAN = MIXERCONTROL_CONTROLTYPE_SLIDER + 2,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_FADER = MIXERCONTROL_CT_CLASS_FADER | MIXERCONTROL_CT_UNITS_UNSIGNED,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_VOLUME = MIXERCONTROL_CONTROLTYPE_FADER + 1,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_BASS = MIXERCONTROL_CONTROLTYPE_FADER + 2,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_TREBLE = MIXERCONTROL_CONTROLTYPE_FADER + 3,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_EQUALIZER = MIXERCONTROL_CONTROLTYPE_FADER + 4,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_SINGLESELECT = MIXERCONTROL_CT_CLASS_LIST | MIXERCONTROL_CT_SC_LIST_SINGLE | MIXERCONTROL_CT_UNITS_BOOLEAN,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_MUX = MIXERCONTROL_CONTROLTYPE_SINGLESELECT + 1,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_MULTIPLESELECT = MIXERCONTROL_CT_CLASS_LIST | MIXERCONTROL_CT_SC_LIST_MULTIPLE | MIXERCONTROL_CT_UNITS_BOOLEAN,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_MIXER = MIXERCONTROL_CONTROLTYPE_MULTIPLESELECT + 1,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_MICROTIME = MIXERCONTROL_CT_CLASS_TIME | MIXERCONTROL_CT_SC_TIME_MICROSECS | MIXERCONTROL_CT_UNITS_UNSIGNED,

			/// <summary></summary>
			MIXERCONTROL_CONTROLTYPE_MILLITIME = MIXERCONTROL_CT_CLASS_TIME | MIXERCONTROL_CT_SC_TIME_MILLISECS | MIXERCONTROL_CT_UNITS_UNSIGNED,
		}

		/// <summary>
		/// Component type for this audio line. An application can use this information to display tailored graphics or to search for a
		/// particular component.
		/// </summary>
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.tMIXERLINE")]
		public enum MIXERLINE_COMPONENTTYPE
		{
			/// <summary>
			/// Audio line is a destination that cannot be defined by one of the standard component types. A mixer device is required to use
			/// this component type for line component types that have not been defined by Microsoft Corporation.
			/// </summary>
			MIXERLINE_COMPONENTTYPE_DST_UNDEFINED = MIXERLINE_COMPONENTTYPE_DST_FIRST + 0,

			/// <summary>Audio line is a digital destination (for example, digital input to a DAT or CD audio device).</summary>
			MIXERLINE_COMPONENTTYPE_DST_DIGITAL = MIXERLINE_COMPONENTTYPE_DST_FIRST + 1,

			/// <summary>
			/// Audio line is a line level destination (for example, line level input from a CD audio device) that will be the final
			/// recording source for the analog-to-digital converter (ADC). Because most audio cards for personal computers provide some
			/// sort of gain for the recording audio source line, the mixer device will use the MIXERLINE_COMPONENTTYPE_DST_WAVEIN type.
			/// </summary>
			MIXERLINE_COMPONENTTYPE_DST_LINE = MIXERLINE_COMPONENTTYPE_DST_FIRST + 2,

			/// <summary>Audio line is a destination used for a monitor.</summary>
			MIXERLINE_COMPONENTTYPE_DST_MONITOR = MIXERLINE_COMPONENTTYPE_DST_FIRST + 3,

			/// <summary>
			/// Audio line is an adjustable (gain and/or attenuation) destination intended to drive speakers. This is the typical component
			/// type for the audio output of audio cards for personal computers.
			/// </summary>
			MIXERLINE_COMPONENTTYPE_DST_SPEAKERS = MIXERLINE_COMPONENTTYPE_DST_FIRST + 4,

			/// <summary>
			/// Audio line is an adjustable (gain and/or attenuation) destination intended to drive headphones. Most audio cards use the
			/// same audio destination line for speakers and headphones, in which case the mixer device simply uses the
			/// MIXERLINE_COMPONENTTYPE_DST_SPEAKERS type.
			/// </summary>
			MIXERLINE_COMPONENTTYPE_DST_HEADPHONES = MIXERLINE_COMPONENTTYPE_DST_FIRST + 5,

			/// <summary>Audio line is a destination that will be routed to a telephone line.</summary>
			MIXERLINE_COMPONENTTYPE_DST_TELEPHONE = MIXERLINE_COMPONENTTYPE_DST_FIRST + 6,

			/// <summary>
			/// Audio line is a destination that will be the final recording source for the waveform-audio input (ADC). This line typically
			/// provides some sort of gain or attenuation. This is the typical component type for the recording line of most audio cards for
			/// personal computers.
			/// </summary>
			MIXERLINE_COMPONENTTYPE_DST_WAVEIN = MIXERLINE_COMPONENTTYPE_DST_FIRST + 7,

			/// <summary>
			/// Audio line is a destination that will be the final recording source for voice input. This component type is exactly like
			/// MIXERLINE_COMPONENTTYPE_DST_WAVEIN but is intended specifically for settings used during voice recording/recognition.
			/// Support for this line is optional for a mixer device. Many mixer devices provide only MIXERLINE_COMPONENTTYPE_DST_WAVEIN.
			/// </summary>
			MIXERLINE_COMPONENTTYPE_DST_VOICEIN = MIXERLINE_COMPONENTTYPE_DST_FIRST + 8,

			/// <summary>
			/// Audio line is a source that cannot be defined by one of the standard component types. A mixer device is required to use this
			/// component type for line component types that have not been defined by Microsoft Corporation.
			/// </summary>
			MIXERLINE_COMPONENTTYPE_SRC_UNDEFINED = MIXERLINE_COMPONENTTYPE_SRC_FIRST + 0,

			/// <summary>Audio line is a digital source (for example, digital output from a DAT or audio CD).</summary>
			MIXERLINE_COMPONENTTYPE_SRC_DIGITAL = MIXERLINE_COMPONENTTYPE_SRC_FIRST + 1,

			/// <summary>
			/// Audio line is a line-level source (for example, line-level input from an external stereo) that can be used as an optional
			/// recording source. Because most audio cards for personal computers provide some sort of gain for the recording source line,
			/// the mixer device will use the MIXERLINE_COMPONENTTYPE_SRC_AUXILIARY type.
			/// </summary>
			MIXERLINE_COMPONENTTYPE_SRC_LINE = MIXERLINE_COMPONENTTYPE_SRC_FIRST + 2,

			/// <summary>
			/// Audio line is a microphone recording source. Most audio cards for personal computers provide at least two types of recording
			/// sources: an auxiliary audio line and microphone input. A microphone audio line typically provides some sort of gain. Audio
			/// cards that use a single input for use with a microphone or auxiliary audio line should use the
			/// MIXERLINE_COMPONENTTYPE_SRC_MICROPHONE component type.
			/// </summary>
			MIXERLINE_COMPONENTTYPE_SRC_MICROPHONE = MIXERLINE_COMPONENTTYPE_SRC_FIRST + 3,

			/// <summary>
			/// Audio line is a source originating from the output of an internal synthesizer. Most audio cards for personal computers
			/// provide some sort of MIDI synthesizer.
			/// </summary>
			MIXERLINE_COMPONENTTYPE_SRC_SYNTHESIZER = MIXERLINE_COMPONENTTYPE_SRC_FIRST + 4,

			/// <summary>
			/// Audio line is a source originating from the output of an internal audio CD. This component type is provided for audio cards
			/// that provide an audio source line intended to be connected to an audio CD (or CD-ROM playing an audio CD).
			/// </summary>
			MIXERLINE_COMPONENTTYPE_SRC_COMPACTDISC = MIXERLINE_COMPONENTTYPE_SRC_FIRST + 5,

			/// <summary>Audio line is a source originating from an incoming telephone line.</summary>
			MIXERLINE_COMPONENTTYPE_SRC_TELEPHONE = MIXERLINE_COMPONENTTYPE_SRC_FIRST + 6,

			/// <summary>
			/// Audio line is a source originating from personal computer speaker. Several audio cards for personal computers provide the
			/// ability to mix what would typically be played on the internal speaker with the output of an audio card. Some audio cards
			/// support the ability to use this output as a recording source.
			/// </summary>
			MIXERLINE_COMPONENTTYPE_SRC_PCSPEAKER = MIXERLINE_COMPONENTTYPE_SRC_FIRST + 7,

			/// <summary>
			/// Audio line is a source originating from the waveform-audio output digital-to-analog converter (DAC). Most audio cards for
			/// personal computers provide this component type as a source to the MIXERLINE_COMPONENTTYPE_DST_SPEAKERS destination. Some
			/// cards also allow this source to be routed to the MIXERLINE_COMPONENTTYPE_DST_WAVEIN destination.
			/// </summary>
			MIXERLINE_COMPONENTTYPE_SRC_WAVEOUT = MIXERLINE_COMPONENTTYPE_SRC_FIRST + 8,

			/// <summary>
			/// Audio line is a source originating from the auxiliary audio line. This line type is intended as a source with gain or
			/// attenuation that can be routed to the MIXERLINE_COMPONENTTYPE_DST_SPEAKERS destination and/or recorded from the
			/// MIXERLINE_COMPONENTTYPE_DST_WAVEIN destination.
			/// </summary>
			MIXERLINE_COMPONENTTYPE_SRC_AUXILIARY = MIXERLINE_COMPONENTTYPE_SRC_FIRST + 9,

			/// <summary>Audio line is an analog source (for example, analog output from a video-cassette tape).</summary>
			MIXERLINE_COMPONENTTYPE_SRC_ANALOG = MIXERLINE_COMPONENTTYPE_SRC_FIRST + 10,
		}

		/// <summary>Status and support flags for the audio line.</summary>
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.tMIXERLINE")]
		[Flags]
		public enum MIXERLINE_LINEF : uint
		{
			/// <summary>Audio line is active. An active line indicates that a signal is probably passing through the line.</summary>
			MIXERLINE_LINEF_ACTIVE = 0x00000001,

			/// <summary>
			/// Audio line is disconnected. A disconnected line's associated controls can still be modified, but the changes have no effect
			/// until the line is connected.
			/// </summary>
			MIXERLINE_LINEF_DISCONNECTED = 0x00008000,

			/// <summary>
			/// Audio line is an audio source line associated with a single audio destination line. If this flag is not set, this line is an
			/// audio destination line associated with zero or more audio source lines.
			/// </summary>
			MIXERLINE_LINEF_SOURCE = 0x80000000,
		}

		/// <summary>The <c>mixerClose</c> function closes the specified mixer device.</summary>
		/// <param name="hmx">
		/// Handle to the mixer device. This handle must have been returned successfully by the mixerOpen function. If <c>mixerClose</c> is
		/// successful, hmx is no longer valid.
		/// </param>
		/// <returns>
		/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>Specified device handle is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixerclose MMRESULT mixerClose( HMIXER hmx );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.mixerClose")]
		public static extern MMRESULT mixerClose(HMIXER hmx);

		/// <summary>The <c>mixerGetControlDetails</c> function retrieves details about a single control associated with an audio line.</summary>
		/// <param name="hmxobj">Handle to the mixer device object being queried.</param>
		/// <param name="pmxcd">Pointer to a MIXERCONTROLDETAILS structure, which is filled with state information about the control.</param>
		/// <param name="fdwDetails">
		/// <para>Flags for retrieving control details. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MIXER_GETCONTROLDETAILSF_LISTTEXT</term>
		/// <term>
		/// The paDetails member of the MIXERCONTROLDETAILS structure points to one or more MIXERCONTROLDETAILS_LISTTEXT structures to
		/// receive text labels for multiple-item controls. An application must get all list text items for a multiple-item control at once.
		/// This flag cannot be used with MIXERCONTROL_CONTROLTYPE_CUSTOM controls.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_GETCONTROLDETAILSF_VALUE</term>
		/// <term>
		/// Current values for a control are retrieved. The paDetails member of the MIXERCONTROLDETAILS structure points to one or more
		/// details structures appropriate for the control class.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_AUX</term>
		/// <term>
		/// The hmxobj parameter is an auxiliary device identifier in the range of zero to one less than the number of devices returned by
		/// the auxGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIDIIN</term>
		/// <term>
		/// The hmxobj parameter is the handle of a MIDI (Musical Instrument Digital Interface) input device. This handle must have been
		/// returned by the midiInOpen function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIDIOUT</term>
		/// <term>The hmxobj parameter is the handle of a MIDI output device. This handle must have been returned by the midiOutOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIXER</term>
		/// <term>The hmxobj parameter is a mixer device handle returned by the mixerOpen function. This flag is optional.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HWAVEIN</term>
		/// <term>The hmxobj parameter is a waveform-audio input handle returned by the waveInOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HWAVEOUT</term>
		/// <term>The hmxobj parameter is a waveform-audio output handle returned by the waveOutOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIDIIN</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a MIDI input device. This identifier must be in the range of zero to one less than the
		/// number of devices returned by the midiInGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIDIOUT</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a MIDI output device. This identifier must be in the range of zero to one less than
		/// the number of devices returned by the midiOutGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIXER</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a mixer device in the range of zero to one less than the number of devices returned by
		/// the mixerGetNumDevs function. This flag is optional.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_WAVEIN</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a waveform-audio input device in the range of zero to one less than the number of
		/// devices returned by the waveInGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_WAVEOUT</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a waveform-audio output device in the range of zero to one less than the number of
		/// devices returned by the waveOutGetNumDevs function.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MIXERR_INVALCONTROL</term>
		/// <term>The control reference is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_BADDEVICEID</term>
		/// <term>The hmxobj parameter specifies an invalid device identifier.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>One or more flags are invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The hmxobj parameter specifies an invalid handle.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No mixer device is available for the object specified by hmxobj.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>All members of the MIXERCONTROLDETAILS structure must be initialized before calling this function.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixergetcontroldetails MMRESULT mixerGetControlDetails(
		// HMIXEROBJ hmxobj, LPMIXERCONTROLDETAILS pmxcd, DWORD fdwDetails );
		[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.mixerGetControlDetails")]
		public static extern MMRESULT mixerGetControlDetails([In, Optional] HMIXEROBJ hmxobj, ref MIXERCONTROLDETAILS pmxcd, MIXER_OBJECTF fdwDetails);

		/// <summary>The <c>mixerGetDevCaps</c> function queries a specified mixer device to determine its capabilities.</summary>
		/// <param name="uMxId">Identifier or handle of an open mixer device.</param>
		/// <param name="pmxcaps">Pointer to a MIXERCAPS structure that receives information about the capabilities of the device.</param>
		/// <param name="cbmxcaps">Size, in bytes, of the MIXERCAPS structure.</param>
		/// <returns>
		/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_BADDEVICEID</term>
		/// <term>The specified device identifier is out of range.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The mixer device handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Use the mixerGetNumDevs function to determine the number of mixer devices present in the system. The device identifier specified
		/// by uMxId varies from zero to one less than the number of mixer devices present.
		/// </para>
		/// <para>
		/// Only the number of bytes (or less) of information specified in cbmxcaps is copied to the location pointed to by pmxcaps. If
		/// cbmxcaps is zero, nothing is copied, and the function returns successfully.
		/// </para>
		/// <para>
		/// This function also accepts a mixer device handle returned by the mixerOpen function as the uMxId parameter. The application
		/// should cast the <c>HMIXER</c> handle to a <c>UINT</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixergetdevcaps MMRESULT mixerGetDevCaps( UINT uMxId,
		// LPMIXERCAPS pmxcaps, UINT cbmxcaps );
		[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.mixerGetDevCaps")]
		public static extern MMRESULT mixerGetDevCaps(uint uMxId, out MIXERCAPS pmxcaps, uint cbmxcaps);

		/// <summary>
		/// The <c>mixerGetID</c> function retrieves the device identifier for a mixer device associated with a specified device handle.
		/// </summary>
		/// <param name="hmxobj">Handle to the audio mixer object to map to a mixer device identifier.</param>
		/// <param name="puMxId">
		/// Pointer to a variable that receives the mixer device identifier. If no mixer device is available for the hmxobj object, the
		/// value -1 is placed in this location and the MMSYSERR_NODRIVER error value is returned.
		/// </param>
		/// <param name="fdwId">
		/// <para>Flags for mapping the mixer object hmxobj. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MIXER_OBJECTF_AUX</term>
		/// <term>
		/// The hmxobj parameter is an auxiliary device identifier in the range of zero to one less than the number of devices returned by
		/// the auxGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIDIIN</term>
		/// <term>The hmxobj parameter is the handle of a MIDI input device. This handle must have been returned by the midiInOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIDIOUT</term>
		/// <term>The hmxobj parameter is the handle of a MIDI output device. This handle must have been returned by the midiOutOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIXER</term>
		/// <term>The hmxobj parameter is a mixer device handle returned by the mixerOpen function. This flag is optional.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HWAVEIN</term>
		/// <term>The hmxobj parameter is a waveform-audio input handle returned by the waveInOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HWAVEOUT</term>
		/// <term>The hmxobj parameter is a waveform-audio output handle returned by the waveOutOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIDIIN</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a MIDI input device. This identifier must be in the range of zero to one less than the
		/// number of devices returned by the midiInGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIDIOUT</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a MIDI output device. This identifier must be in the range of zero to one less than
		/// the number of devices returned by the midiOutGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIXER</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a mixer device in the range of zero to one less than the number of devices returned by
		/// the mixerGetNumDevs function. This flag is optional.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_WAVEIN</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a waveform-audio input device in the range of zero to one less than the number of
		/// devices returned by the waveInGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_WAVEOUT</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a waveform-audio output device in the range of zero to one less than the number of
		/// devices returned by the waveOutGetNumDevs function.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_BADDEVICEID</term>
		/// <term>The hmxobj parameter specifies an invalid device identifier.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>One or more flags are invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The hmxobj parameter specifies an invalid handle.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>
		/// No audio mixer device is available for the object specified by hmxobj. The location referenced by puMxId also contains the value -1.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixergetid MMRESULT mixerGetID( HMIXEROBJ hmxobj, UINT
		// *puMxId, DWORD fdwId );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.mixerGetID")]
		public static extern MMRESULT mixerGetID([In, Optional] HMIXEROBJ hmxobj, out uint puMxId, MIXER_OBJECTF fdwId);

		/// <summary>The <c>mixerGetLineControls</c> function retrieves one or more controls associated with an audio line.</summary>
		/// <param name="hmxobj">Handle to the mixer device object that is being queried.</param>
		/// <param name="pmxlc">
		/// Pointer to a MIXERLINECONTROLS structure. This structure is used to reference one or more MIXERCONTROL structures to be filled
		/// with information about the controls associated with an audio line. The <c>cbStruct</c> member of the <c>MIXERLINECONTROLS</c>
		/// structure must always be initialized to be the size, in bytes, of the <c>MIXERLINECONTROLS</c> structure.
		/// </param>
		/// <param name="fdwControls">
		/// <para>Flags for retrieving information about one or more controls associated with an audio line. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MIXER_GETLINECONTROLSF_ALL</term>
		/// <term>
		/// The pmxlc parameter references a list of MIXERCONTROL structures that will receive information on all controls associated with
		/// the audio line identified by the dwLineID member of the MIXERLINECONTROLS structure. The cControls member must be initialized to
		/// the number of controls associated with the line. This number is retrieved from the cControls member of the MIXERLINE structure
		/// returned by the mixerGetLineInfo function. The cbmxctrl member must be initialized to the size, in bytes, of a single
		/// MIXERCONTROL structure. The pamxctrl member must point to the first MIXERCONTROL structure to be filled. The dwControlID and
		/// dwControlType members are ignored for this query.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_GETLINECONTROLSF_ONEBYID</term>
		/// <term>
		/// The pmxlc parameter references a single MIXERCONTROL structure that will receive information on the control identified by the
		/// dwControlID member of the MIXERLINECONTROLS structure. The cControls member must be initialized to 1. The cbmxctrl member must
		/// be initialized to the size, in bytes, of a single MIXERCONTROL structure. The pamxctrl member must point to a MIXERCONTROL
		/// structure to be filled. The dwLineID and dwControlType members are ignored for this query. This query is usually used to refresh
		/// a control after receiving a MM_MIXM_CONTROL_CHANGE control change notification message by the user-defined callback (see mixerOpen).
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_GETLINECONTROLSF_ONEBYTYPE</term>
		/// <term>
		/// The mixerGetLineControls function retrieves information about the first control of a specific class for the audio line that is
		/// being queried. The pmxlc parameter references a single MIXERCONTROL structure that will receive information about the specific
		/// control. The audio line is identified by the dwLineID member. The control class is specified in the dwControlType member of the
		/// MIXERLINECONTROLS structure.The dwControlID member is ignored for this query. This query can be used by an application to get
		/// information on a single control associated with a line. For example, you might want your application to use a peak meter only
		/// from a waveform-audio output line.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_AUX</term>
		/// <term>
		/// The hmxobj parameter is an auxiliary device identifier in the range of zero to one less than the number of devices returned by
		/// the auxGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIDIIN</term>
		/// <term>The hmxobj parameter is the handle of a MIDI input device. This handle must have been returned by the midiInOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIDIOUT</term>
		/// <term>The hmxobj parameter is the handle of a MIDI output device. This handle must have been returned by the midiOutOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIXER</term>
		/// <term>The hmxobj parameter is a mixer device handle returned by the mixerOpen function. This flag is optional.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HWAVEIN</term>
		/// <term>The hmxobj parameter is a waveform-audio input handle returned by the waveInOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HWAVEOUT</term>
		/// <term>The hmxobj parameter is a waveform-audio output handle returned by the waveOutOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIDIIN</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a MIDI input device. This identifier must be in the range of zero to one less than the
		/// number of devices returned by the midiInGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIDIOUT</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a MIDI output device. This identifier must be in the range of zero to one less than
		/// the number of devices returned by the midiOutGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIXER</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a mixer device in the range of zero to one less than the number of devices returned by
		/// the mixerGetNumDevs function. This flag is optional.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_WAVEIN</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a waveform-audio input device in the range of zero to one less than the number of
		/// devices returned by the waveInGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_WAVEOUT</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a waveform-audio output device in the range of zero to one less than the number of
		/// devices returned by the waveOutGetNumDevs function.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MIXERR_INVALCONTROL</term>
		/// <term>The control reference is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MIXERR_INVALLINE</term>
		/// <term>The audio line reference is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_BADDEVICEID</term>
		/// <term>The hmxobj parameter specifies an invalid device identifier.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>One or more flags are invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The hmxobj parameter specifies an invalid handle.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No mixer device is available for the object specified by hmxobj.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixergetlinecontrols MMRESULT mixerGetLineControls( HMIXEROBJ
		// hmxobj, LPMIXERLINECONTROLS pmxlc, DWORD fdwControls );
		[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.mixerGetLineControls")]
		public static extern MMRESULT mixerGetLineControls([In, Optional] HMIXEROBJ hmxobj, ref MIXERLINECONTROLS pmxlc, MIXER_OBJECTF fdwControls);

		/// <summary>The <c>mixerGetLineInfo</c> function retrieves information about a specific line of a mixer device.</summary>
		/// <param name="hmxobj">Handle to the mixer device object that controls the specific audio line.</param>
		/// <param name="pmxl">
		/// Pointer to a MIXERLINE structure. This structure is filled with information about the audio line for the mixer device. The
		/// <c>cbStruct</c> member must always be initialized to be the size, in bytes, of the <c>MIXERLINE</c> structure.
		/// </param>
		/// <param name="fdwInfo">
		/// <para>Flags for retrieving information about an audio line. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MIXER_GETLINEINFOF_COMPONENTTYPE</term>
		/// <term>
		/// The pmxl parameter will receive information about the first audio line of the type specified in the dwComponentType member of
		/// the MIXERLINE structure. This flag is used to retrieve information about an audio line of a specific component type. Remaining
		/// structure members except cbStruct require no further initialization.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_GETLINEINFOF_DESTINATION</term>
		/// <term>
		/// The pmxl parameter will receive information about the destination audio line specified by the dwDestination member of the
		/// MIXERLINE structure. This index ranges from zero to one less than the value in the cDestinations member of the MIXERCAPS
		/// structure. All remaining structure members except cbStruct require no further initialization.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_GETLINEINFOF_LINEID</term>
		/// <term>
		/// The pmxl parameter will receive information about the audio line specified by the dwLineID member of the MIXERLINE structure.
		/// This is usually used to retrieve updated information about the state of an audio line. All remaining structure members except
		/// cbStruct require no further initialization.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_GETLINEINFOF_SOURCE</term>
		/// <term>
		/// The pmxl parameter will receive information about the source audio line specified by the dwDestination and dwSource members of
		/// the MIXERLINE structure. The index specified by dwDestination ranges from zero to one less than the value in the cDestinations
		/// member of the MIXERCAPS structure. The index specified by dwSource ranges from zero to one less than the value in the
		/// cConnections member of the MIXERLINE structure returned for the audio line stored in the dwDestination member. All remaining
		/// structure members except cbStruct require no further initialization.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_GETLINEINFOF_TARGETTYPE</term>
		/// <term>
		/// The pmxl parameter will receive information about the audio line that is for the dwType member of the Target structure, which is
		/// a member of the MIXERLINE structure. This flag is used to retrieve information about an audio line that handles the target type
		/// (for example, MIXERLINE_TARGETTYPE_WAVEOUT). The application must initialize the dwType, wMid, wPid, vDriverVersion and szPname
		/// members of the MIXERLINE structure before calling mixerGetLineInfo. All of these values can be retrieved from the device
		/// capabilities structures for all media devices. Remaining structure members except cbStruct require no further initialization.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_AUX</term>
		/// <term>
		/// The hmxobj parameter is an auxiliary device identifier in the range of zero to one less than the number of devices returned by
		/// the auxGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIDIIN</term>
		/// <term>The hmxobj parameter is the handle of a MIDI input device. This handle must have been returned by the midiInOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIDIOUT</term>
		/// <term>The hmxobj parameter is the handle of a MIDI output device. This handle must have been returned by the midiOutOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIXER</term>
		/// <term>The hmxobj parameter is a mixer device handle returned by the mixerOpen function. This flag is optional.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HWAVEIN</term>
		/// <term>The hmxobj parameter is a waveform-audio input handle returned by the waveInOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HWAVEOUT</term>
		/// <term>The hmxobj parameter is a waveform-audio output handle returned by the waveOutOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIDIIN</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a MIDI input device. This identifier must be in the range of zero to one less than the
		/// number of devices returned by the midiInGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIDIOUT</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a MIDI output device. This identifier must be in the range of zero to one less than
		/// the number of devices returned by the midiOutGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIXER</term>
		/// <term>
		/// The hmxobj parameter is a mixer device identifier in the range of zero to one less than the number of devices returned by the
		/// mixerGetNumDevs function. This flag is optional.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_WAVEIN</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a waveform-audio input device in the range of zero to one less than the number of
		/// devices returned by the waveInGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_WAVEOUT</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a waveform-audio output device in the range of zero to one less than the number of
		/// devices returned by the waveOutGetNumDevs function.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MIXERR_INVALLINE</term>
		/// <term>The audio line reference is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_BADDEVICEID</term>
		/// <term>The hmxobj parameter specifies an invalid device identifier.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>One or more flags are invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The hmxobj parameter specifies an invalid handle.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No mixer device is available for the object specified by hmxobj.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixergetlineinfo MMRESULT mixerGetLineInfo( HMIXEROBJ hmxobj,
		// LPMIXERLINE pmxl, DWORD fdwInfo );
		[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.mixerGetLineInfo")]
		public static extern MMRESULT mixerGetLineInfo([In, Optional] HMIXEROBJ hmxobj, ref MIXERLINE pmxl, MIXER_OBJECTF fdwInfo);

		/// <summary>The <c>mixerGetNumDevs</c> function retrieves the number of mixer devices present in the system.</summary>
		/// <returns>Returns the number of mixer devices or zero if no mixer devices are available.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixergetnumdevs UINT mixerGetNumDevs();
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.mixerGetNumDevs")]
		public static extern uint mixerGetNumDevs();

		/// <summary>The <c>mixerMessage</c> function sends a custom mixer driver message directly to a mixer driver.</summary>
		/// <param name="hmx">
		/// Identifier of the mixer that receives the message. You must cast the device ID to the <c>HMIXER</c> handle type. If you supply a
		/// handle instead of a device ID, the function fails and returns the MMSYSERR_NOSUPPORT error code.
		/// </param>
		/// <param name="uMsg">
		/// Custom mixer driver message to send to the mixer driver. This message must be above or equal to the MXDM_USER constant.
		/// </param>
		/// <param name="dwParam1">Parameter associated with the message being sent.</param>
		/// <param name="dwParam2">Parameter associated with the message being sent.</param>
		/// <returns>
		/// <para>Returns a value that is specific to the custom mixer driver message. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The specified device handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>The uMsg parameter specified in the MXDM_USER message is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOSUPPORT</term>
		/// <term>The deviceID parameter must be a valid device ID.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOTSUPPORTED</term>
		/// <term>The mixer device did not process the message.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// User-defined messages must be sent only to a mixer driver that supports the messages. The application should verify that the
		/// mixer driver is the driver that supports the message by retrieving the mixer capabilities and checking the <c>wMid</c>,
		/// <c>wPid</c>, <c>vDriverVersion</c>, and <c>szPname</c> members of the MIXERCAPS structure.
		/// </para>
		/// <para>The
		/// <code>DRV_QUERYDEVICEINTERFACE</code>
		/// message queries for the device-interface name of a <c>waveIn</c>, <c>waveOut</c>, <c>midiIn</c>, <c>midiOut</c>, or <c>mixer</c> device.
		/// </para>
		/// <para>For
		/// <code>DRV_QUERYDEVICEINTERFACE</code>
		/// , dwParam1 is a pointer to a caller-allocated buffer into which the function writes a null-terminated Unicode string containing
		/// the device-interface name. If the device has no device interface, the string length is zero.
		/// </para>
		/// <para>For
		/// <code>DRV_QUERYDEVICEINTERFACE</code>
		/// , dwParam2 specifies the buffer size in bytes. This is an input parameter to the function. The caller should specify a size that
		/// is greater than or equal to the buffer size retrieved by the DRV_QUERYDEVICEINTERFACESIZE message.
		/// </para>
		/// <para>
		/// The DRV_QUERYDEVICEINTERFACE message is supported in Windows Me, and Windows 2000 and later. This message is valid only for the
		/// waveInMessage, waveOutMessage, midiInMessage, midiOutMessage, and <c>mixerMessage</c> functions. The system intercepts this
		/// message and returns the appropriate value without sending the message to the device driver. For general information about
		/// system-intercepted <c>xxxMessage</c> functions, see System-Intercepted Device Messages.
		/// </para>
		/// <para>The following two message constants are used together for the purpose of obtaining device interface names:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>DRV_QUERYDEVICEINTERFACESIZE</term>
		/// </item>
		/// <item>
		/// <term>DRV_QUERYDEVICEINTERFACE</term>
		/// </item>
		/// </list>
		/// <para>
		/// The first message obtains the size in bytes of the buffer needed to hold the string containing the device interface name. The
		/// second message retrieves the name string in a buffer of the required size.
		/// </para>
		/// <para>For more information, see Obtaining a Device Interface Name.</para>
		/// <para>The
		/// <code>DRV_QUERYDEVICEINTERFACESIZE</code>
		/// message queries for the size of the buffer required to hold the device-interface name.
		/// </para>
		/// <para>For
		/// <code>DRV_QUERYDEVICEINTERFACESIZE</code>
		/// , dwParam1 is a pointer to buffer size. This parameter points to a ULONG variable into which the function writes the required
		/// buffer size in bytes. The size includes storage space for the name string's terminating null. The size is zero if the device ID
		/// identifies a device that has no device interface.
		/// </para>
		/// <para>For
		/// <code>DRV_QUERYDEVICEINTERFACESIZE</code>
		/// , dwParam2 is unused. Set this parameter to zero.
		/// </para>
		/// <para>
		/// This message is valid only for the waveInMessage, waveOutMessage, midiInMessage, midiOutMessage, and <c>mixerMessage</c>
		/// functions. The system intercepts this message and returns the appropriate value without sending the message to the device
		/// driver. For general information about system-intercepted <c>xxxMessage</c> functions, see System-Intercepted Device Messages.
		/// </para>
		/// <para>
		/// The buffer size retrieved by this message is expressed as a byte count. It specifies the size of the buffer needed to hold the
		/// null-terminated Unicode string that contains the device-interface name. The caller allocates a buffer of the specified size and
		/// uses the DRV_QUERYDEVICEINTERFACE message to retrieve the device-interface name string.
		/// </para>
		/// <para>For more information, see Obtaining a Device Interface Name.</para>
		/// <para>The
		/// <code>DRV_QUERYDEVNODE</code>
		/// message queries for the devnode number assigned to the device by the Plug and Play manager.
		/// </para>
		/// <para>For
		/// <code>DRV_QUERYDEVNODE</code>
		/// , dwParam1 is a pointer to a caller-allocated DWORD variable into which the function writes the devnode number. If no devnode is
		/// assigned to the device, the function sets this variable to zero.
		/// </para>
		/// <para>For
		/// <code>DRV_QUERYDEVNODE</code>
		/// , dwParam2 is unused. Set this parameter to zero.
		/// </para>
		/// <para>
		/// In Windows 2000 and later, the message always returns MMSYSERR_NOTSUPPORTED. This message is valid only for the waveInMessage,
		/// waveOutMessage, midiInMessage, midiOutMessage, and <c>mixerMessage</c> functions. The system intercepts this message and returns
		/// the appropriate value without sending the message to the device driver. For general information about system-intercepted
		/// <c>xxxMessage</c> functions, see System-Intercepted Device Messages.
		/// </para>
		/// <para>The
		/// <code>DRV_QUERYMAPPABLE</code>
		/// message queries for whether the specified device can be used by a mapper.
		/// </para>
		/// <para>For
		/// <code>DRV_QUERYMAPPABLE</code>
		/// , dwParam1 is unused. Set this parameter to zero.
		/// </para>
		/// <para>For
		/// <code>DRV_QUERYMAPPABLE</code>
		/// , dwParam2 is unused. Set this parameter to zero.
		/// </para>
		/// <para>
		/// This message is valid only for the waveInMessage, waveOutMessage, midiInMessage, midiOutMessage, <c>mixerMessage</c> and
		/// auxOutMessage functions. The system intercepts this message and returns the appropriate value without sending the message to the
		/// device driver. For general information about system-intercepted <c>xxxMessage</c> functions, see System-Intercepted Device Messages.
		/// </para>
		/// <para>
		/// When an application program opens a mapper instead of a specific audio device, the system inserts a mapper between the
		/// application and the available devices. The mapper selects an appropriate device by mapping the application's requirements to one
		/// of the available devices. For more information about mappers, see the Microsoft Windows SDK documentation.
		/// </para>
		/// <para>The
		/// <code>DRVM_MAPPER_CONSOLEVOICECOM_GET</code>
		/// message retrieves the device ID of the preferred voice-communications device.
		/// </para>
		/// <para>For
		/// <code>DRVM_MAPPER_CONSOLEVOICECOM_GET</code>
		/// , dwParam1 is a pointer to device ID. This parameter points to a DWORD variable into which the function writes the device ID of
		/// the current preferred voice-communications device. The function writes the value (-1) if no device is available that qualifies
		/// as a preferred voice-communications device.
		/// </para>
		/// <para>For
		/// <code>DRVM_MAPPER_CONSOLEVOICECOM_GET</code>
		/// , dwParam2 is a pointer to status flags. This parameter points to a DWORD variable into which the function writes the
		/// device-status flags. Only one flag bit is currently defined: DRVM_MAPPER_PREFERRED_FLAGS_PREFERREDONLY.
		/// </para>
		/// <para>
		/// This message is valid only for the waveInMessage and waveOutMessage functions. When a caller calls these two functions with the
		/// DRVM_MAPPER_CONSOLEVOICECOM_GET message, the caller must specify the device ID as WAVE_MAPPER, and then cast this value to the
		/// appropriate handle type. For the <c>waveInMessage</c>, <c>waveOutMessage</c>, midiInMessage, midiOutMessage, or
		/// <c>mixerMessage</c> functions, the caller must cast the device ID to a handle of type HWAVEIN, HWAVEOUT, HMIDIIN, HMIDIOUT, or
		/// HMIXER, respectively. Note that if the caller supplies a valid handle instead of a device ID for this parameter, the function
		/// fails and returns error code MMSYSERR_NOSUPPORT.
		/// </para>
		/// <para>
		/// The system intercepts this message and returns the appropriate value without sending the message to the device driver. For
		/// general information about system-intercepted <c>xxxMessage</c> functions, see System-Intercepted Device Messages.
		/// </para>
		/// <para>
		/// This message provides a way to determine which device is preferred specifically for voice communications, in contrast to the
		/// DRVM_MAPPER_PREFERRED_GET message, which determines which device is preferred for all other audio functions.
		/// </para>
		/// <para>
		/// For example, the preferred <c>waveOut</c> device for voice communications might be the earpiece in a headset, but the preferred
		/// <c>waveOut</c> device for all other audio functions might be a set of stereo speakers.
		/// </para>
		/// <para>
		/// When the DRVM_MAPPER_PREFERRED_FLAGS_PREFERREDONLY flag bit is set in the DWORD location pointed to by dwParam2, the
		/// <c>waveIn</c> and <c>waveOut</c> APIs use only the current preferred voice-communications device and do not search for other
		/// available devices if the preferred device is unavailable. The flag that is output by either the <c>waveInMessage</c> or
		/// <c>waveOutMessage</c> call applies to the preferred voice-communications device for both the <c>waveIn</c> and <c>waveOut</c>
		/// APIs, regardless of whether the call is made to <c>waveInMessage</c> or <c>waveOutMessage</c>. For more information, see
		/// Preferred Voice-Communications Device ID.
		/// </para>
		/// <para>The
		/// <code>DRVM_MAPPER_PREFERRED_GET</code>
		/// message retrieves the device ID of the preferred audio device.
		/// </para>
		/// <para>For
		/// <code>DRVM_MAPPER_PREFERRED_GET</code>
		/// , dwParam1 is a pointer to device ID. This parameter points to a DWORD variable into which the function writes the device ID of
		/// the current preferred device. The function writes the value (-1) if no device is available that qualifies as a preferred device.
		/// </para>
		/// <para>For
		/// <code>DRVM_MAPPER_PREFERRED_GET</code>
		/// , dwParam2 is a pointer to status flags. This parameter points to a DWORD variable into which the function writes the
		/// device-status flags. Only one flag bit is currently defined (for <c>waveInMessage</c> and <c>waveOutMessage</c> calls only): DRVM_MAPPER_PREFERRED_FLAGS_PREFERREDONLY.
		/// </para>
		/// <para>
		/// This message is valid only for the waveInMessage, waveOutMessage and midiOutMessage functions. When the caller calls these
		/// functions with the DRVM_MAPPER_PREFERRED_GET message, the caller must first specify the device ID as WAVE_MAPPER (for
		/// <c>waveInMessage</c> or <c>waveOutMessage</c>) or MIDI_MAPPER (for <c>midiOutMessage</c>), and then cast this value to the
		/// appropriate handle type. For the <c>waveInMessage</c>, <c>waveOutMessage</c>, or <c>midiOutMessage</c> functions, the caller
		/// must cast the device ID to a handle type HWAVEIN, HWAVEOUT or HMIDIOUT, respectively. Note that if the caller supplies a valid
		/// handle instead of a device ID for this parameter, the function fails and returns error code MMSYSERR_NOSUPPORT.
		/// </para>
		/// <para>
		/// The system intercepts this message and returns the appropriate value without sending the message to the device driver. For
		/// general information about system-intercepted <c>xxxMessage</c> functions, see System-Intercepted Device Messages.
		/// </para>
		/// <para>
		/// This message provides a way to determine which device is preferred for audio functions in general, in contrast to the
		/// DRVM_MAPPER_CONSOLEVOICECOM_GET message, which determines which device is preferred specifically for voice communications.
		/// </para>
		/// <para>
		/// When the DRVM_MAPPER_PREFERRED_FLAGS_PREFERREDONLY flag bit is set in the DWORD location pointed to by dwParam2, the
		/// <c>waveIn</c> and <c>waveOut</c> APIs use only the current preferred device and do not search for other available devices if the
		/// preferred device is unavailable. Note that the <c>midiOutMessage</c> function does not output this flag--the <c>midiOut</c> API
		/// always uses only the preferred device. The flag that is output by either the <c>waveInMessage</c> or <c>waveOutMessage</c> call
		/// applies to the preferred device for both the <c>waveIn</c> and <c>waveOut</c> APIs, regardless of whether the call is made to
		/// <c>waveInMessage</c> or <c>waveOutMessage</c>.
		/// </para>
		/// <para>
		/// The xxxMessage functions accept this value in place of a valid device handle in order to allow an application to determine the
		/// default device ID without first having to open a device. For more information, see Accessing the Preferred Device ID.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixermessage DWORD mixerMessage( HMIXER hmx, UINT uMsg,
		// DWORD_PTR dwParam1, DWORD_PTR dwParam2 );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.mixerMessage")]
		public static extern uint mixerMessage([In, Optional] HMIXER hmx, uint uMsg, [In, Optional] IntPtr dwParam1, [In, Optional] IntPtr dwParam2);

		/// <summary>
		/// The <c>mixerOpen</c> function opens a specified mixer device and ensures that the device will not be removed until the
		/// application closes the handle.
		/// </summary>
		/// <param name="phmx">
		/// Pointer to a variable that will receive a handle identifying the opened mixer device. Use this handle to identify the device
		/// when calling other audio mixer functions. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <param name="uMxId">
		/// Identifier of the mixer device to open. Use a valid device identifier or any <c>HMIXEROBJ</c> (see the mixerGetID function for a
		/// description of mixer object handles). A "mapper" for audio mixer devices does not currently exist, so a mixer device identifier
		/// of -1 is not valid.
		/// </param>
		/// <param name="dwCallback">
		/// Handle to a window called when the state of an audio line and/or control associated with the device being opened is changed.
		/// Specify <c>NULL</c> for this parameter if no callback mechanism is to be used.
		/// </param>
		/// <param name="dwInstance">Reserved. Must be zero.</param>
		/// <param name="fdwOpen">
		/// <para>Flags for opening the device. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CALLBACK_WINDOW</term>
		/// <term>The dwCallback parameter is assumed to be a window handle (HWND).</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_AUX</term>
		/// <term>
		/// The uMxId parameter is an auxiliary device identifier in the range of zero to one less than the number of devices returned by
		/// the auxGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIDIIN</term>
		/// <term>The uMxId parameter is the handle of a MIDI input device. This handle must have been returned by the midiInOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIDIOUT</term>
		/// <term>The uMxId parameter is the handle of a MIDI output device. This handle must have been returned by the midiOutOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIXER</term>
		/// <term>The uMxId parameter is a mixer device handle returned by the mixerOpen function. This flag is optional.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HWAVEIN</term>
		/// <term>The uMxId parameter is a waveform-audio input handle returned by the waveInOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HWAVEOUT</term>
		/// <term>The uMxId parameter is a waveform-audio output handle returned by the waveOutOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIDIIN</term>
		/// <term>
		/// The uMxId parameter is the identifier of a MIDI input device. This identifier must be in the range of zero to one less than the
		/// number of devices returned by the midiInGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIDIOUT</term>
		/// <term>
		/// The uMxId parameter is the identifier of a MIDI output device. This identifier must be in the range of zero to one less than the
		/// number of devices returned by the midiOutGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIXER</term>
		/// <term>
		/// The uMxId parameter is a mixer device identifier in the range of zero to one less than the number of devices returned by the
		/// mixerGetNumDevs function. This flag is optional.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_WAVEIN</term>
		/// <term>
		/// The uMxId parameter is the identifier of a waveform-audio input device in the range of zero to one less than the number of
		/// devices returned by the waveInGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_WAVEOUT</term>
		/// <term>
		/// The uMxId parameter is the identifier of a waveform-audio output device in the range of zero to one less than the number of
		/// devices returned by the waveOutGetNumDevs function.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns <c>MMSYSERR_NOERROR</c> if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_ALLOCATED</term>
		/// <term>The specified resource is already allocated by the maximum number of clients possible.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_BADDEVICEID</term>
		/// <term>The uMxId parameter specifies an invalid device identifier.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>One or more flags are invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The uMxId parameter specifies an invalid handle.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>
		/// No mixer device is available for the object specified by uMxId. Note that the location referenced by uMxId will also contain the
		/// value –1.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate resources.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Use the mixerGetNumDevs function to determine the number of audio mixer devices present in the system. The device identifier
		/// specified by uMxId varies from zero to one less than the number of devices present.
		/// </para>
		/// <para>
		/// If a window is chosen to receive callback information, the MM_MIXM_LINE_CHANGE and MM_MIXM_CONTROL_CHANGE messages are sent to
		/// the window procedure function to indicate when an audio line or control state changes. For both messages, the wParam parameter
		/// is the handle of the mixer device. The lParam parameter is the line identifier for <c>MM_MIXM_LINE_CHANGE</c> or the control
		/// identifier for <c>MM_MIXM_CONTROL_CHANGE</c> that changed state.
		/// </para>
		/// <para>To query for audio mixer support or a media device, use the mixerGetID function.</para>
		/// <para>
		/// On 64-bit systems, this function may not work as expected in situations where you pass a 64-bit <c>LPHWAVEOUT</c> pointer in the
		/// uMxId parameter, because the uMxId parameter is truncated to 32 bits.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixeropen MMRESULT mixerOpen( LPHMIXER phmx, UINT uMxId,
		// DWORD_PTR dwCallback, DWORD_PTR dwInstance, DWORD fdwOpen );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.mixerOpen")]
		public static extern MMRESULT mixerOpen([In, Optional] HMIXER phmx, uint uMxId, [In, Optional] IntPtr dwCallback, [In, Optional] IntPtr dwInstance, MIXER_OBJECTF fdwOpen);

		/// <summary>The <c>mixerSetControlDetails</c> function sets properties of a single control associated with an audio line.</summary>
		/// <param name="hmxobj">Handle to the mixer device object for which properties are being set.</param>
		/// <param name="pmxcd">
		/// Pointer to a MIXERCONTROLDETAILS structure. This structure is used to reference control detail structures that contain the
		/// desired state for the control.
		/// </param>
		/// <param name="fdwDetails">
		/// <para>Flags for setting properties for a control. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MIXER_OBJECTF_AUX</term>
		/// <term>
		/// The hmxobj parameter is an auxiliary device identifier in the range of zero to one less than the number of devices returned by
		/// the auxGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIDIIN</term>
		/// <term>The hmxobj parameter is the handle of a MIDI input device. This handle must have been returned by the midiInOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIDIOUT</term>
		/// <term>The hmxobj parameter is the handle of a MIDI output device. This handle must have been returned by the midiOutOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HMIXER</term>
		/// <term>The hmxobj parameter is a mixer device handle returned by the mixerOpen function. This flag is optional.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HWAVEIN</term>
		/// <term>The hmxobj parameter is a waveform-audio input handle returned by the waveInOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_HWAVEOUT</term>
		/// <term>The hmxobj parameter is a waveform-audio output handle returned by the waveOutOpen function.</term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIDIIN</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a MIDI input device. This identifier must be in the range of zero to one less than the
		/// number of devices returned by the midiInGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIDIOUT</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a MIDI output device. This identifier must be in the range of zero to one less than
		/// the number of devices returned by the midiOutGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_MIXER</term>
		/// <term>
		/// The hmxobj parameter is a mixer device identifier in the range of zero to one less than the number of devices returned by the
		/// mixerGetNumDevs function. This flag is optional.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_WAVEIN</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a waveform-audio input device in the range of zero to one less than the number of
		/// devices returned by the waveInGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_OBJECTF_WAVEOUT</term>
		/// <term>
		/// The hmxobj parameter is the identifier of a waveform-audio output device in the range of zero to one less than the number of
		/// devices returned by the waveOutGetNumDevs function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_SETCONTROLDETAILSF_CUSTOM</term>
		/// <term>
		/// A custom dialog box for the specified custom mixer control is displayed. The mixer device gathers the required information from
		/// the user and returns the data in the specified buffer. The handle for the owning window is specified in the hwndOwner member of
		/// the MIXERCONTROLDETAILS structure. (This handle can be set to NULL.) The application can then save the data from the dialog box
		/// and use it later to reset the control to the same state by using the MIXER_SETCONTROLDETAILSF_VALUE flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MIXER_SETCONTROLDETAILSF_VALUE</term>
		/// <term>
		/// The current value(s) for a control are set. The paDetails member of the MIXERCONTROLDETAILS structure points to one or more
		/// mixer-control details structures of the appropriate class for the control.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MIXERR_INVALCONTROL</term>
		/// <term>The control reference is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_BADDEVICEID</term>
		/// <term>The hmxobj parameter specifies an invalid device identifier.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALFLAG</term>
		/// <term>One or more flags are invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The hmxobj parameter specifies an invalid handle.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_INVALPARAM</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No mixer device is available for the object specified by hmxobj.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>All members of the MIXERCONTROLDETAILS structure must be initialized before calling <c>mixerSetControlDetails</c>.</para>
		/// <para>
		/// If an application needs to retrieve only the current state of a custom mixer control and not display a dialog box, then
		/// mixerGetControlDetails can be used with the MIXER_GETCONTROLDETAILSF_VALUE flag.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mixersetcontroldetails MMRESULT mixerSetControlDetails(
		// HMIXEROBJ hmxobj, LPMIXERCONTROLDETAILS pmxcd, DWORD fdwDetails );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.mixerSetControlDetails")]
		public static extern MMRESULT mixerSetControlDetails([In, Optional] HMIXEROBJ hmxobj, in MIXERCONTROLDETAILS pmxcd, MIXER_OBJECTF fdwDetails);

		/// <summary>Provides a handle to a mixer device.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HMIXER : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HMIXER"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HMIXER(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HMIXER"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HMIXER NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HMIXER"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HMIXER h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HMIXER"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HMIXER(IntPtr h) => new(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HMIXER h1, HMIXER h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HMIXER h1, HMIXER h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HMIXER h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a mixer device object.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HMIXEROBJ : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HMIXEROBJ"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HMIXEROBJ(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HMIXEROBJ"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HMIXEROBJ NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HMIXEROBJ"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HMIXEROBJ h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HMIXEROBJ"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HMIXEROBJ(IntPtr h) => new(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HMIXEROBJ h1, HMIXEROBJ h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HMIXEROBJ h1, HMIXEROBJ h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HMIXEROBJ h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>The <c>MIXERCAPS</c> structure describes the capabilities of a mixer device.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixercaps typedef struct tMIXERCAPS { WORD wMid; WORD wPid;
		// VERSION vDriverVersion; char szPname[MAXPNAMELEN]; DWORD fdwSupport; DWORD cDestinations; } MIXERCAPS, *PMIXERCAPS, *LPMIXERCAPS;
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.tMIXERCAPS")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct MIXERCAPS
		{
			/// <summary>
			/// A manufacturer identifier for the mixer device driver. Manufacturer identifiers are defined in Manufacturer and Product Identifiers.
			/// </summary>
			public ushort wMid;

			/// <summary>
			/// A product identifier for the mixer device driver. Product identifiers are defined in Manufacturer and Product Identifiers.
			/// </summary>
			public ushort wPid;

			/// <summary>
			/// Version number of the mixer device driver. The high-order byte is the major version number, and the low-order byte is the
			/// minor version number.
			/// </summary>
			public uint vDriverVersion;

			/// <summary>
			/// Name of the product. If the mixer device driver supports multiple cards, this string must uniquely and easily identify
			/// (potentially to a user) the specific card.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAXPNAMELEN)]
			public string szPname;

			/// <summary>Various support information for the mixer device driver. No extended support bits are currently defined.</summary>
			public uint fdwSupport;

			/// <summary>
			/// The number of audio line destinations available through the mixer device. All mixer devices must support at least one
			/// destination line, so this member cannot be zero. Destination indexes used in the <c>dwDestination</c> member of the
			/// MIXERLINE structure range from zero to the value specified in the <c>cDestinations</c> member minus one.
			/// </summary>
			public uint cDestinations;

			/// <summary>Gets the native size of this structure.</summary>
			public static uint NativeSize = unchecked((uint)Marshal.SizeOf(typeof(MIXERCAPS)));
		}

		/// <summary>The <c>MIXERCONTROL</c> structure describes the state and metrics of a single control for an audio line.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixercontrol typedef struct tMIXERCONTROL { DWORD cbStruct;
		// DWORD dwControlID; DWORD dwControlType; DWORD fdwControl; DWORD cMultipleItems; char szShortName[MIXER_SHORT_NAME_CHARS]; char
		// szName[MIXER_LONG_NAME_CHARS]; union { struct { LONG lMinimum; LONG lMaximum; } DUMMYSTRUCTNAME; struct { DWORD dwMinimum; DWORD
		// dwMaximum; } DUMMYSTRUCTNAME2; DWORD dwReserved[6]; } Bounds; union { DWORD cSteps; DWORD cbCustomData; DWORD dwReserved[6]; }
		// Metrics; } MIXERCONTROL, *PMIXERCONTROL, *LPMIXERCONTROL;
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.tMIXERCONTROL")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct MIXERCONTROL
		{
			/// <summary>Size, in bytes, of the <c>MIXERCONTROL</c> structure.</summary>
			public uint cbStruct;

			/// <summary>
			/// Audio mixer-defined identifier that uniquely refers to the control described by the <c>MIXERCONTROL</c> structure. This
			/// identifier can be in any format supported by the mixer device. An application should use this identifier only as an abstract
			/// handle. No two controls for a single mixer device can ever have the same control identifier.
			/// </summary>
			public uint dwControlID;

			/// <summary>
			/// <para>
			/// Class of the control for which the identifier is specified in <c>dwControlID</c>. An application must use this information
			/// to display the appropriate control for input from the user. An application can also display tailored graphics based on the
			/// control class or search for a particular control class on a specific line. If an application does not know about a control
			/// class, this control must be ignored. There are eight control class classifications, each with one or more standard control types:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Descriptions</term>
			/// </listheader>
			/// <item>
			/// <term>MIXERCONTROL_CT_CLASS_CUSTOM</term>
			/// <term>MIXERCONTROL_CONTROLTYPE_CUSTOM</term>
			/// </item>
			/// <item>
			/// <term>MIXERCONTROL_CT_CLASS_FADER</term>
			/// <term>
			/// MIXERCONTROL_CONTROLTYPE_BASS MIXERCONTROL_CONTROLTYPE_EQUALIZER MIXERCONTROL_CONTROLTYPE_FADER
			/// MIXERCONTROL_CONTROLTYPE_TREBLE MIXERCONTROL_CONTROLTYPE_VOLUME
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERCONTROL_CT_CLASS_LIST</term>
			/// <term>MIXERCONTROL_CONTROLTYPE_MIXER MIXERCONTROL_CONTROLTYPE_MULTIPLESELECT MIXERCONTROL_CONTROLTYPE_MUX MIXERCONTROL_CONTROLTYPE_SINGLESELECT</term>
			/// </item>
			/// <item>
			/// <term>MIXERCONTROL_CT_CLASS_METER</term>
			/// <term>MIXERCONTROL_CONTROLTYPE_BOOLEANMETER MIXERCONTROL_CONTROLTYPE_PEAKMETER MIXERCONTROL_CONTROLTYPE_SIGNEDMETER MIXERCONTROL_CONTROLTYPE_UNSIGNEDMETER</term>
			/// </item>
			/// <item>
			/// <term>MIXERCONTROL_CT_CLASS_NUMBER</term>
			/// <term>MIXERCONTROL_CONTROLTYPE_DECIBELS MIXERCONTROL_CONTROLTYPE_PERCENT MIXERCONTROL_CONTROLTYPE_SIGNED MIXERCONTROL_CONTROLTYPE_UNSIGNED</term>
			/// </item>
			/// <item>
			/// <term>MIXERCONTROL_CT_CLASS_SLIDER</term>
			/// <term>MIXERCONTROL_CONTROLTYPE_PAN MIXERCONTROL_CONTROLTYPE_QSOUNDPAN MIXERCONTROL_CONTROLTYPE_SLIDER</term>
			/// </item>
			/// <item>
			/// <term>MIXERCONTROL_CT_CLASS_SWITCH</term>
			/// <term>
			/// MIXERCONTROL_CONTROLTYPE_BOOLEAN MIXERCONTROL_CONTROLTYPE_BUTTON MIXERCONTROL_CONTROLTYPE_LOUDNESS
			/// MIXERCONTROL_CONTROLTYPE_MONO MIXERCONTROL_CONTROLTYPE_MUTE MIXERCONTROL_CONTROLTYPE_ONOFF MIXERCONTROL_CONTROLTYPE_STEREOENH
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERCONTROL_CT_CLASS_TIME</term>
			/// <term>MIXERCONTROL_CONTROLTYPE_MICROTIME MIXERCONTROL_CONTROLTYPE_MILLITIME</term>
			/// </item>
			/// </list>
			/// </summary>
			public MIXERCONTROL_CT dwControlType;

			/// <summary>
			/// <para>Status and support flags for the audio line control. The following values are defined:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>MIXERCONTROL_CONTROLF_DISABLED</term>
			/// <term>
			/// The control is disabled, perhaps due to other settings for the mixer hardware, and cannot be used. An application can read
			/// current settings from a disabled control, but it cannot apply settings.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERCONTROL_CONTROLF_MULTIPLE</term>
			/// <term>
			/// The control has two or more settings per channel. An equalizer, for example, requires this flag because each frequency band
			/// can be set to a different value. An equalizer that affects both channels of a stereo line in a uniform fashion will also
			/// specify the MIXERCONTROL_CONTROLF_UNIFORM flag.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERCONTROL_CONTROLF_UNIFORM</term>
			/// <term>
			/// The control acts on all channels of a multichannel line in a uniform fashion. For example, a control that mutes both
			/// channels of a stereo line would set this flag. Most MIXERCONTROL_CONTROLTYPE_MUX and MIXERCONTROL_CONTROLTYPE_MIXER controls
			/// also specify the MIXERCONTROL_CONTROLF_UNIFORM flag.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public MIXERCONTROL_CONTROLF fdwControl;

			/// <summary>
			/// Number of items per channel that make up a MIXERCONTROL_CONTROLF_MULTIPLE control. This number is always two or greater for
			/// multiple-item controls. If the control is not a multiple-item control, do not use this member; it will be zero.
			/// </summary>
			public uint cMultipleItems;

			/// <summary>
			/// Short string that describes the audio line control specified by <c>dwControlID</c>. This description should be appropriate
			/// to use as a concise label for the control.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MIXER_SHORT_NAME_CHARS)]
			public string szShortName;

			/// <summary>
			/// String that describes the audio line control specified by <c>dwControlID</c>. This description should be appropriate to use
			/// as a complete description for the control.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MIXER_LONG_NAME_CHARS)]
			public string szName;

			/// <summary>Union of boundary types.</summary>
			public BOUNDS Bounds;

			/// <summary>Union of boundary types.</summary>
			[StructLayout(LayoutKind.Sequential, Size = 24)]
			public struct BOUNDS
			{
				/// <summary>
				/// Minimum signed value for a control that has a signed boundary nature. This member cannot be used in conjunction with <c>dwMinimum</c>.
				/// </summary>
				public int lMinimum;

				/// <summary>
				/// Maximum signed value for a control that has a signed boundary nature. This member cannot be used in conjunction with <c>dwMaximum</c>.
				/// </summary>
				public int lMaximum;

				/// <summary>
				/// Minimum unsigned value for a control that has an unsigned boundary nature. This member cannot be used in conjunction
				/// with <c>lMinimum</c>.
				/// </summary>
				public uint dwMinimum { get => unchecked((uint)lMinimum); set => lMinimum = unchecked((int)value); }

				/// <summary>
				/// Maximum unsigned value for a control that has an unsigned boundary nature. This member cannot be used in conjunction
				/// with <c>lMaximum</c>.
				/// </summary>
				public uint dwMaximum { get => unchecked((uint)lMaximum); set => lMaximum = unchecked((int)value); }
			}

			/// <summary>Union of boundary metrics.</summary>
			public METRICS Metrics;

			/// <summary>Union of boundary metrics.</summary>
			[StructLayout(LayoutKind.Sequential, Size = 24)]
			public struct METRICS
			{
				/// <summary>
				/// Number of discrete ranges within the union specified for a control specified by the <c>Bounds</c> member. This member
				/// overlaps with the other members of the <c>Metrics</c> structure member and cannot be used in conjunction with those members.
				/// </summary>
				public uint cSteps;

				/// <summary>
				/// Size, in bytes, required to contain the state of a custom control class. This member is appropriate only for the
				/// MIXERCONTROL_CONTROLTYPE_CUSTOM control class.
				/// </summary>
				public uint cbCustomData { get => cSteps; set => cSteps = cbCustomData; }
			}
		}

		/// <summary>
		/// The <c>MIXERCONTROLDETAILS</c> structure refers to control-detail structures, retrieving or setting state information of an
		/// audio mixer control. All members of this structure must be initialized before calling the mixerGetControlDetails and
		/// mixerSetControlDetails functions.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixercontroldetails typedef struct tMIXERCONTROLDETAILS {
		// DWORD cbStruct; DWORD dwControlID; DWORD cChannels; union { HWND hwndOwner; DWORD cMultipleItems; } DUMMYUNIONNAME; DWORD
		// cbDetails; LPVOID paDetails; } MIXERCONTROLDETAILS, *PMIXERCONTROLDETAILS, *LPMIXERCONTROLDETAILS;
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.tMIXERCONTROLDETAILS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIXERCONTROLDETAILS
		{
			/// <summary>
			/// Size, in bytes, of the <c>MIXERCONTROLDETAILS</c> structure. The size must be large enough to contain the base
			/// <c>MIXERCONTROLDETAILS</c> structure. When mixerGetControlDetails returns, this member contains the actual size of the
			/// information returned. The returned information will not exceed the requested size, nor will it be smaller than the base
			/// <c>MIXERCONTROLDETAILS</c> structure.
			/// </summary>
			public uint cbStruct;

			/// <summary>Control identifier on which to get or set properties.</summary>
			public uint dwControlID;

			/// <summary>
			/// <para>Number of channels on which to get or set control properties. The following values are defined:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>Use this value when the control is a MIXERCONTROL_CONTROLTYPE_CUSTOM control.</term>
			/// </item>
			/// <item>
			/// <term>1</term>
			/// <term>
			/// Use this value when the control is a MIXERCONTROL_CONTROLF_UNIFORM control or when an application needs to get and set all
			/// channels as if they were uniform.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE cChannels</term>
			/// <term>Use this value when the properties for the control are expected on all channels for a line.</term>
			/// </item>
			/// </list>
			/// <para>
			/// An application cannot specify a value that falls between 1 and the number of channels for the audio line. For example,
			/// specifying 2 or 3 for a four-channel line is not valid. This member cannot be 0 for noncustom control types.
			/// </para>
			/// <para>This member cannot be 0 for noncustom control types.</para>
			/// </summary>
			public uint cChannels;

			/// <summary>
			/// Handle to the window that owns a custom dialog box for a mixer control. This member is used when the
			/// MIXER_SETCONTROLDETAILSF_CUSTOM flag is specified in the mixerSetControlDetails function.
			/// </summary>
			public HWND hwndOwner;

			/// <summary>
			/// <para>Number of multiple items per channel on which to get or set properties. The following values are defined:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>Use this value for all controls except for a MIXERCONTROL_CONTROLF_MULTIPLE or a MIXERCONTROL_CONTROLTYPE_CUSTOM control.</term>
			/// </item>
			/// <item>
			/// <term>MIXERCONTROL cMultipleItems member</term>
			/// <term>Use this value when the control class is MIXERCONTROL_CONTROLF_MULTIPLE.</term>
			/// </item>
			/// <item>
			/// <term>MIXERCONTROLDETAILS hwndOwner member</term>
			/// <term>
			/// Use this value when the control is a MIXERCONTROL_CONTROLTYPE_CUSTOM control and the MIXER_SETCONTROLDETAILSF_CUSTOM flag is
			/// specified for the mixerSetControlDetails function. In this case, the hwndOwner member overlaps with cMultipleItems,
			/// providing the value of the window handle.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// When using a MIXERCONTROL_CONTROLTYPE_CUSTOM control without the MIXERCONTROL_CONTROLTYPE_CUSTOM flag, specify zero for this member.
			/// </para>
			/// <para>
			/// An application cannot specify any value other than the value specified in the cMultipleItems member of the MIXERCONTROL
			/// structure for a MIXERCONTROL_CONTROLF_MULTIPLE control.
			/// </para>
			/// </summary>
			public uint cMultipleItems { get => unchecked((uint)hwndOwner.DangerousGetHandle().ToInt32()); set => hwndOwner = new HWND(new IntPtr(unchecked((int)value))); }

			/// <summary>
			/// <para>Size, in bytes, of one of the following details structures being used:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>MIXERCONTROLDETAILS_BOOLEAN</term>
			/// <term>Boolean value for an audio line control.</term>
			/// </item>
			/// <item>
			/// <term>MIXERCONTROLDETAILS_LISTTEXT</term>
			/// <term>
			/// List text buffer for an audio line control. For information about the appropriate details structure for a specific control,
			/// see Control Types.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERCONTROLDETAILS_SIGNED</term>
			/// <term>Signed value for an audio line control.</term>
			/// </item>
			/// <item>
			/// <term>MIXERCONTROLDETAILS_UNSIGNED</term>
			/// <term>Unsigned value for an audio line control.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint cbDetails;

			/// <summary>
			/// <para>Pointer to an array of one or more structures in which properties for the specified control are retrieved or set.</para>
			/// <para>
			/// For MIXERCONTROL_CONTROLF_MULTIPLE controls, the size of this buffer should be the product of the <c>cChannels</c>,
			/// <c>cMultipleItems</c> and <c>cbDetails</c> members of the <c>MIXERCONTROLDETAILS</c> structure. For controls other than
			/// MIXERCONTROL_CONTROLF_MULTIPLE types, the size of this buffer is the product of the <c>cChannels</c> and <c>cbDetails</c>
			/// members of the <c>MIXERCONTROLDETAILS</c> structure.
			/// </para>
			/// <para>
			/// For controls other than MIXERCONTROL_CONTROLF_MULTIPLE types, the size of this buffer is the product of the <c>cChannels</c>
			/// and <c>cbDetails</c> members of the <c>MIXERCONTROLDETAILS</c> structure. For controls other than
			/// MIXERCONTROL_CONTROLF_MULTIPLE types, the size of this buffer is the product of the <c>cChannels</c> and <c>cbDetails</c>
			/// members of the <c>MIXERCONTROLDETAILS</c> structure.
			/// </para>
			/// <para>
			/// For controls that are MIXERCONTROL_CONTROLF_MULTIPLE types, the array can be treated as a two-dimensional array that is
			/// channel major. That is, all multiple items for the left channel are given, then all multiple items for the right channel,
			/// and so on.
			/// </para>
			/// <para>
			/// For controls other than MIXERCONTROL_CONTROLF_MULTIPLE types, each element index is equivalent to the zero-based channel
			/// that it affects. That is, paDetails[0] is for the left channel and paDetails[1] is for the right channel.
			/// </para>
			/// <para>
			/// If the control is a MIXERCONTROL_CONTROLTYPE_CUSTOM control, this member must point to a buffer that is at least large
			/// enough to contain the size, in bytes, specified by the cbCustomData member of the MIXERCONTROL structure.
			/// </para>
			/// </summary>
			public IntPtr paDetails;
		}

		/// <summary>
		/// The <c>MIXERCONTROLDETAILS_BOOLEAN</c> structure retrieves and sets Boolean control properties for an audio mixer control
		/// </summary>
		/// <remarks>
		/// <para>The following standard control types use this structure for retrieving and setting properties.</para>
		/// <para>Meter controls:</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_BOOLEANMETER</para>
		/// <para>Switch controls:</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_BOOLEAN</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_BUTTON</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_LOUDNESS</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_MONO</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_MUTE</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_ONOFF</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_STEREOENH</para>
		/// <para>List controls:</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_MIXER</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_MULTIPLESELECT</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_MUX</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_SINGLESELECT</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixercontroldetails_boolean typedef struct
		// tMIXERCONTROLDETAILS_BOOLEAN { LONG fValue; } MIXERCONTROLDETAILS_BOOLEAN, *PMIXERCONTROLDETAILS_BOOLEAN, *LPMIXERCONTROLDETAILS_BOOLEAN;
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.tMIXERCONTROLDETAILS_BOOLEAN")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIXERCONTROLDETAILS_BOOLEAN
		{
			/// <summary>
			/// Boolean value for a single item or channel. This value is assumed to be zero for a FALSE state (such as off or disabled),
			/// and nonzero for a TRUE state (such as on or enabled).
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fValue;
		}

		/// <summary>
		/// The MIXERCONTROLDETAILS_LISTTEXT structure retrieves list text, label text, and/or band-range information for multiple-item
		/// controls. This structure is used when the MIXER_GETCONTROLDETAILSF_LISTTEXT flag is specified in the mixerGetControlDetails function.
		/// </summary>
		/// <remarks>
		/// <para>The following standard control types use this structure for retrieving the item text descriptions on multiple-item controls:</para>
		/// <para>Fader control:</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_EQUALIZER</para>
		/// <para>List controls:</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_MIXER</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_MULTIPLESELECT</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_MUX</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_SINGLESELECT</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixercontroldetails_listtext typedef struct
		// tMIXERCONTROLDETAILS_LISTTEXT { DWORD dwParam1; DWORD dwParam2; char szName[MIXER_LONG_NAME_CHARS]; }
		// MIXERCONTROLDETAILS_LISTTEXT, *PMIXERCONTROLDETAILS_LISTTEXT, *LPMIXERCONTROLDETAILS_LISTTEXT;
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.tMIXERCONTROLDETAILS_LISTTEXT")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct MIXERCONTROLDETAILS_LISTTEXT
		{
			/// <summary>
			/// <para>Control class-specific values. The following control types are listed with their corresponding values:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>EQUALIZER</term>
			/// <term>MIXERCONTROL. Bounds dwMinimum member.</term>
			/// </item>
			/// <item>
			/// <term>MIXER and MUX</term>
			/// <term>MIXERLINEdwLineID member.</term>
			/// </item>
			/// <item>
			/// <term>MULTIPLESELECT and SINGLESELECT</term>
			/// <term>Undefined; must be zero</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint dwParam1;

			/// <summary>See dwParam1.</summary>
			public uint dwParam2;

			/// <summary>
			/// Name describing a single item in a multiple-item control. This text can be used as a label or item text, depending on the
			/// control class.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MIXER_LONG_NAME_CHARS)]
			public string szName;
		}

		/// <summary>The MIXERCONTROLDETAILS_SIGNED structure retrieves and sets signed type control properties for an audio mixer control.</summary>
		/// <remarks>
		/// <para>The following standard control types use this structure for retrieving and setting properties:</para>
		/// <para>Meter controls:</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_PEAKMETER</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_SIGNEDMETER</para>
		/// <para>Member controls:</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_SIGNED</para>
		/// <para>Number controls:</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_DECIBELS</para>
		/// <para>Slider controls:</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_PAN</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_QSOUNDPAN</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_SLIDER</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixercontroldetails_signed typedef struct
		// tMIXERCONTROLDETAILS_SIGNED { LONG lValue; } MIXERCONTROLDETAILS_SIGNED, *PMIXERCONTROLDETAILS_SIGNED, *LPMIXERCONTROLDETAILS_SIGNED;
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.tMIXERCONTROLDETAILS_SIGNED")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIXERCONTROLDETAILS_SIGNED
		{
			/// <summary>
			/// Signed integer value for a single item or channel. This value must be inclusively within the bounds given in the Bounds
			/// member of this structure for signed integer controls.
			/// </summary>
			public int lValue;
		}

		/// <summary>
		/// The MIXERCONTROLDETAILS_UNSIGNED structure retrieves and sets unsigned type control properties for an audio mixer control.
		/// </summary>
		/// <remarks>
		/// <para>The following standard control types use this structure for retrieving and setting properties:</para>
		/// <para>Meter control:</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_UNSIGNEDMETER</para>
		/// <para>Number control:</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_UNSIGNED</para>
		/// <para>Fader controls:</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_BASS</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_EQUALIZER</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_FADER</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_TREBLE</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_VOLUME</para>
		/// <para>Time controls:</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_MICROTIME</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_MILLITIME</para>
		/// <para>MIXERCONTROL_CONTROLTYPE_PERCENT</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixercontroldetails_unsigned typedef struct
		// tMIXERCONTROLDETAILS_UNSIGNED { DWORD dwValue; } MIXERCONTROLDETAILS_UNSIGNED, *PMIXERCONTROLDETAILS_UNSIGNED, *LPMIXERCONTROLDETAILS_UNSIGNED;
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.tMIXERCONTROLDETAILS_UNSIGNED")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIXERCONTROLDETAILS_UNSIGNED
		{
			/// <summary>
			/// Unsigned integer value for a single item or channel. This value must be inclusively within the bounds given in the Bounds
			/// structure member of the MIXERCONTROL structure for unsigned integer controls.
			/// </summary>
			public uint dwValue;
		}

		/// <summary>The <c>MIXERLINE</c> structure describes the state and metrics of an audio line.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixerline typedef struct tMIXERLINE { DWORD cbStruct; DWORD
		// dwDestination; DWORD dwSource; DWORD dwLineID; DWORD fdwLine; DWORD dwUser; DWORD dwComponentType; DWORD cChannels; DWORD
		// cConnections; DWORD cControls; char szShortName[MIXER_SHORT_NAME_CHARS]; char szName[MIXER_LONG_NAME_CHARS]; struct { DWORD
		// dwType; DWORD dwDeviceID; WORD wMid; WORD wPid; VERSION vDriverVersion; char szPname[MAXPNAMELEN]; } Target; } MIXERLINE,
		// *PMIXERLINE, *LPMIXERLINE;
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.tMIXERLINE")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct MIXERLINE
		{
			/// <summary>
			/// Size, in bytes, of the <c>MIXERLINE</c> structure. This member must be initialized before calling the mixerGetLineInfo
			/// function. The size specified in this member must be large enough to contain the <c>MIXERLINE</c> structure. When
			/// <c>mixerGetLineInfo</c> returns, this member contains the actual size of the information returned. The returned information
			/// will not exceed the requested size.
			/// </summary>
			public uint cbStruct;

			/// <summary>
			/// Destination line index. This member ranges from zero to one less than the value specified in the <c>cDestinations</c> member
			/// of the MIXERCAPS structure retrieved by the mixerGetDevCaps function. When the mixerGetLineInfo function is called with the
			/// MIXER_GETLINEINFOF_DESTINATION flag, properties for the destination line are returned. (The <c>dwSource</c> member must be
			/// set to zero in this case.) When called with the MIXER_GETLINEINFOF_SOURCE flag, the properties for the source given by the
			/// <c>dwSource</c> member that is associated with the <c>dwDestination</c> member are returned.
			/// </summary>
			public uint dwDestination;

			/// <summary>
			/// Index for the audio source line associated with the <c>dwDestination</c> member. That is, this member specifies the nth
			/// audio source line associated with the specified audio destination line. This member is not used for destination lines and
			/// must be set to zero when MIXER_GETLINEINFOF_DESTINATION is specified in the mixerGetLineInfo function. When the
			/// MIXER_GETLINEINFOF_SOURCE flag is specified, this member ranges from zero to one less than the value specified in the
			/// <c>cConnections</c> member for the audio destination line given in the <c>dwDestination</c> member.
			/// </summary>
			public uint dwSource;

			/// <summary>
			/// An identifier defined by the mixer device that uniquely refers to the audio line described by the <c>MIXERLINE</c>
			/// structure. This identifier is unique for each mixer device and can be in any format. An application should use this
			/// identifier only as an abstract handle.
			/// </summary>
			public uint dwLineID;

			/// <summary>
			/// <para>Status and support flags for the audio line. This member is always returned to the application and requires no initialization.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>MIXERLINE_LINEF_ACTIVE</term>
			/// <term>Audio line is active. An active line indicates that a signal is probably passing through the line.</term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_LINEF_DISCONNECTED</term>
			/// <term>
			/// Audio line is disconnected. A disconnected line's associated controls can still be modified, but the changes have no effect
			/// until the line is connected.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_LINEF_SOURCE</term>
			/// <term>
			/// Audio line is an audio source line associated with a single audio destination line. If this flag is not set, this line is an
			/// audio destination line associated with zero or more audio source lines.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// If an application is not using a waveform-audio output device, the audio line associated with that device would not be
			/// active (that is, the MIXERLINE_LINEF_ACTIVE flag would not be set).
			/// </para>
			/// <para>
			/// If the waveform-audio output device is opened, then the audio line is considered active and the MIXERLINE_LINEF_ACTIVE flag
			/// will be set.
			/// </para>
			/// <para>
			/// A paused or starved waveform-audio output device is still considered active. In other words, if the waveform-audio output
			/// device is opened by an application regardless of whether data is being played, the associated audio line is considered active.
			/// </para>
			/// <para>If a line cannot be strictly defined as active, the mixer device will always set the MIXERLINE_LINEF_ACTIVE flag.</para>
			/// </summary>
			public MIXERLINE_LINEF fdwLine;

			/// <summary>
			/// Instance data defined by the audio device for the line. This member is intended for custom mixer applications designed
			/// specifically for the mixer device returning this information. Other applications should ignore this data.
			/// </summary>
			public IntPtr dwUser;

			/// <summary>
			/// <para>
			/// Component type for this audio line. An application can use this information to display tailored graphics or to search for a
			/// particular component. If an application does not use component types, this member should be ignored. This member can be one
			/// of the following values:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_DST_DIGITAL</term>
			/// <term>Audio line is a digital destination (for example, digital input to a DAT or CD audio device).</term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_DST_HEADPHONES</term>
			/// <term>
			/// Audio line is an adjustable (gain and/or attenuation) destination intended to drive headphones. Most audio cards use the
			/// same audio destination line for speakers and headphones, in which case the mixer device simply uses the
			/// MIXERLINE_COMPONENTTYPE_DST_SPEAKERS type.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_DST_LINE</term>
			/// <term>
			/// Audio line is a line level destination (for example, line level input from a CD audio device) that will be the final
			/// recording source for the analog-to-digital converter (ADC). Because most audio cards for personal computers provide some
			/// sort of gain for the recording audio source line, the mixer device will use the MIXERLINE_COMPONENTTYPE_DST_WAVEIN type.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_DST_MONITOR</term>
			/// <term>Audio line is a destination used for a monitor.</term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_DST_SPEAKERS</term>
			/// <term>
			/// Audio line is an adjustable (gain and/or attenuation) destination intended to drive speakers. This is the typical component
			/// type for the audio output of audio cards for personal computers.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_DST_TELEPHONE</term>
			/// <term>Audio line is a destination that will be routed to a telephone line.</term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_DST_UNDEFINED</term>
			/// <term>
			/// Audio line is a destination that cannot be defined by one of the standard component types. A mixer device is required to use
			/// this component type for line component types that have not been defined by Microsoft Corporation.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_DST_VOICEIN</term>
			/// <term>
			/// Audio line is a destination that will be the final recording source for voice input. This component type is exactly like
			/// MIXERLINE_COMPONENTTYPE_DST_WAVEIN but is intended specifically for settings used during voice recording/recognition.
			/// Support for this line is optional for a mixer device. Many mixer devices provide only MIXERLINE_COMPONENTTYPE_DST_WAVEIN.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_DST_WAVEIN</term>
			/// <term>
			/// Audio line is a destination that will be the final recording source for the waveform-audio input (ADC). This line typically
			/// provides some sort of gain or attenuation. This is the typical component type for the recording line of most audio cards for
			/// personal computers.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_SRC_ANALOG</term>
			/// <term>Audio line is an analog source (for example, analog output from a video-cassette tape).</term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_SRC_AUXILIARY</term>
			/// <term>
			/// Audio line is a source originating from the auxiliary audio line. This line type is intended as a source with gain or
			/// attenuation that can be routed to the MIXERLINE_COMPONENTTYPE_DST_SPEAKERS destination and/or recorded from the
			/// MIXERLINE_COMPONENTTYPE_DST_WAVEIN destination.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_SRC_COMPACTDISC</term>
			/// <term>
			/// Audio line is a source originating from the output of an internal audio CD. This component type is provided for audio cards
			/// that provide an audio source line intended to be connected to an audio CD (or CD-ROM playing an audio CD).
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_SRC_DIGITAL</term>
			/// <term>Audio line is a digital source (for example, digital output from a DAT or audio CD).</term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_SRC_LINE</term>
			/// <term>
			/// Audio line is a line-level source (for example, line-level input from an external stereo) that can be used as an optional
			/// recording source. Because most audio cards for personal computers provide some sort of gain for the recording source line,
			/// the mixer device will use the MIXERLINE_COMPONENTTYPE_SRC_AUXILIARY type.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_SRC_MICROPHONE</term>
			/// <term>
			/// Audio line is a microphone recording source. Most audio cards for personal computers provide at least two types of recording
			/// sources: an auxiliary audio line and microphone input. A microphone audio line typically provides some sort of gain. Audio
			/// cards that use a single input for use with a microphone or auxiliary audio line should use the
			/// MIXERLINE_COMPONENTTYPE_SRC_MICROPHONE component type.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_SRC_PCSPEAKER</term>
			/// <term>
			/// Audio line is a source originating from personal computer speaker. Several audio cards for personal computers provide the
			/// ability to mix what would typically be played on the internal speaker with the output of an audio card. Some audio cards
			/// support the ability to use this output as a recording source.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_SRC_SYNTHESIZER</term>
			/// <term>
			/// Audio line is a source originating from the output of an internal synthesizer. Most audio cards for personal computers
			/// provide some sort of MIDI synthesizer.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_SRC_TELEPHONE</term>
			/// <term>Audio line is a source originating from an incoming telephone line.</term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_SRC_UNDEFINED</term>
			/// <term>
			/// Audio line is a source that cannot be defined by one of the standard component types. A mixer device is required to use this
			/// component type for line component types that have not been defined by Microsoft Corporation.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MIXERLINE_COMPONENTTYPE_SRC_WAVEOUT</term>
			/// <term>
			/// Audio line is a source originating from the waveform-audio output digital-to-analog converter (DAC). Most audio cards for
			/// personal computers provide this component type as a source to the MIXERLINE_COMPONENTTYPE_DST_SPEAKERS destination. Some
			/// cards also allow this source to be routed to the MIXERLINE_COMPONENTTYPE_DST_WAVEIN destination.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public MIXERLINE_COMPONENTTYPE dwComponentType;

			/// <summary>
			/// <para>
			/// Maximum number of separate channels that can be manipulated independently for the audio line. The minimum value for this
			/// field is 1 because a line must have at least one channel.
			/// </para>
			/// <para>Most modern audio cards for personal computers are stereo devices; for them, the value of this member is 2.</para>
			/// <para>Channel 1 is assumed to be the left channel; channel 2 is assumed to be the right channel.</para>
			/// <para>
			/// A multichannel line might have one or more uniform controls (controls that affect all channels of a line uniformly)
			/// associated with it.
			/// </para>
			/// </summary>
			public uint cChannels;

			/// <summary>
			/// Number of connections that are associated with the audio line. This member is used only for audio destination lines and
			/// specifies the number of audio source lines that are associated with it. This member is always zero for source lines and for
			/// destination lines that do not have any audio source lines associated with them.
			/// </summary>
			public uint cConnections;

			/// <summary>
			/// Number of controls associated with the audio line. This value can be zero. If no controls are associated with the line, the
			/// line is likely to be a source that might be selected in a MIXERCONTROL_CONTROLTYPE_MUX or MIXERCONTROL_CONTROLTYPE_MIXER but
			/// allows no manipulation of the signal.
			/// </summary>
			public uint cControls;

			/// <summary>
			/// Short string that describes the audio mixer line specified in the <c>dwLineID</c> member. This description should be
			/// appropriate as a concise label for the line.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MIXER_SHORT_NAME_CHARS)]
			public string szShortName;

			/// <summary>
			/// String that describes the audio mixer line specified in the <c>dwLineID</c> member. This description should be appropriate
			/// as a complete description for the line.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MIXER_LONG_NAME_CHARS)]
			public string szName;

			/// <summary>Target media information.</summary>
			public TARGET Target;

			/// <summary>Target media information.</summary>
			[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
			public struct TARGET
			{
				/// <summary>
				/// <para>
				/// Target media device type associated with the audio line described in the <c>MIXERLINE</c> structure. An application must
				/// ignore target information for media device types it does not use. The following values are defined:
				/// </para>
				/// <list type="table">
				/// <listheader>
				/// <term>Name</term>
				/// <term>Description</term>
				/// </listheader>
				/// <item>
				/// <term>MIXERLINE_TARGETTYPE_AUX</term>
				/// <term>
				/// The audio line described by the MIXERLINE structure is strictly bound to the auxiliary device detailed in the remaining
				/// members of the Target structure member of the MIXERLINE structure.
				/// </term>
				/// </item>
				/// <item>
				/// <term>MIXERLINE_TARGETTYPE_MIDIIN</term>
				/// <term>
				/// The audio line described by the MIXERLINE structure is strictly bound to the MIDI input device detailed in the remaining
				/// members of the Target structure member of the MIXERLINE structure.
				/// </term>
				/// </item>
				/// <item>
				/// <term>MIXERLINE_TARGETTYPE_MIDIOUT</term>
				/// <term>
				/// The audio line described by the MIXERLINE structure is strictly bound to the MIDI output device detailed in the
				/// remaining members of the Target structure member of the MIXERLINE structure.
				/// </term>
				/// </item>
				/// <item>
				/// <term>MIXERLINE_TARGETTYPE_UNDEFINED</term>
				/// <term>
				/// The audio line described by the MIXERLINE structure is not strictly bound to a defined media type. All remaining Target
				/// structure members of the MIXERLINE structure should be ignored. An application cannot use the
				/// MIXERLINE_TARGETTYPE_UNDEFINED target type when calling the mixerGetLineInfo function with the
				/// MIXER_GETLINEINFOF_TARGETTYPE flag.
				/// </term>
				/// </item>
				/// <item>
				/// <term>MIXERLINE_TARGETTYPE_WAVEIN</term>
				/// <term>
				/// The audio line described by the MIXERLINE structure is strictly bound to the waveform-audio input device detailed in the
				/// remaining members of the Target structure member of the MIXERLINE structure.
				/// </term>
				/// </item>
				/// <item>
				/// <term>MIXERLINE_TARGETTYPE_WAVEOUT</term>
				/// <term>
				/// The audio line described by the MIXERLINE structure is strictly bound to the waveform-audio output device detailed in
				/// the remaining members of the Target structure member of the MIXERLINE structure.
				/// </term>
				/// </item>
				/// </list>
				/// </summary>
				public uint dwType;

				/// <summary>
				/// Current device identifier of the target media device when the <c>dwType</c> member is a target type other than
				/// MIXERLINE_TARGETTYPE_UNDEFINED. This identifier is identical to the current media device index of the associated media
				/// device. When calling the mixerGetLineInfo function with the MIXER_GETLINEINFOF_TARGETTYPE flag, this member is ignored
				/// on input and will be returned to the caller by the audio mixer manager.
				/// </summary>
				public uint dwDeviceID;

				/// <summary>
				/// Manufacturer identifier of the target media device when the <c>dwType</c> member is a target type other than
				/// MIXERLINE_TARGETTYPE_UNDEFINED. This identifier is identical to the <c>wMid</c> member of the device-capabilities
				/// structure for the associated media. Manufacturer identifiers are defined in Manufacturer and Product Identifiers.
				/// </summary>
				public ushort wMid;

				/// <summary>
				/// Product identifier of the target media device when the <c>dwType</c> member is a target type other than
				/// MIXERLINE_TARGETTYPE_UNDEFINED. This identifier is identical to the <c>wPid</c> member of the device-capabilities
				/// structure for the associated media. Product identifiers are defined in Manufacturer and Product Identifiers.
				/// </summary>
				public ushort wPid;

				/// <summary>
				/// Driver version of the target media device when the <c>dwType</c> member is a target type other than
				/// MIXERLINE_TARGETTYPE_UNDEFINED. This version is identical to the <c>vDriverVersion</c> member of the device-capabilities
				/// structure for the associated media.
				/// </summary>
				public uint vDriverVersion;

				/// <summary>
				/// Product name of the target media device when the <c>dwType</c> member is a target type other than
				/// MIXERLINE_TARGETTYPE_UNDEFINED. This name is identical to the <c>szPname</c> member of the device-capabilities structure
				/// for the associated media.
				/// </summary>
				[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MIXER_LONG_NAME_CHARS)]
				public string szPname;
			}
		}

		/// <summary>The <c>MIXERLINECONTROLS</c> structure contains information about the controls of an audio line.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-mixerlinecontrols typedef struct tMIXERLINECONTROLS { DWORD
		// cbStruct; DWORD dwLineID; union { DWORD dwControlID; DWORD dwControlType; }; DWORD cControls; DWORD cbmxctrl; LPMIXERCONTROL
		// pamxctrl; } MIXERLINECONTROLS, *PMIXERLINECONTROLS, *LPMIXERLINECONTROLS;
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.tMIXERLINECONTROLS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIXERLINECONTROLS
		{
			/// <summary>
			/// Size, in bytes, of the <c>MIXERLINECONTROLS</c> structure. This member must be initialized before calling the
			/// mixerGetLineControls function. The size specified in this member must be large enough to contain the
			/// <c>MIXERLINECONTROLS</c> structure. When <c>mixerGetLineControls</c> returns, this member contains the actual size of the
			/// information returned. The returned information will not exceed the requested size, nor will it be smaller than the
			/// <c>MIXERLINECONTROLS</c> structure.
			/// </summary>
			public uint cbStruct;

			/// <summary>
			/// Line identifier for which controls are being queried. This member is not used if the MIXER_GETLINECONTROLSF_ONEBYID flag is
			/// specified for the mixerGetLineControls function, but the mixer device still returns this member in this case. The
			/// <c>dwControlID</c> and <c>dwControlType</c> members are not used when MIXER_GETLINECONTROLSF_ALL is specified.
			/// </summary>
			public uint dwLineID;

			/// <summary>
			/// Control identifier of the desired control. This member is used with the MIXER_GETLINECONTROLSF_ONEBYID flag for the
			/// mixerGetLineControls function to retrieve the control information of the specified control. Note that the <c>dwLineID</c>
			/// member of the <c>MIXERLINECONTROLS</c> structure will be returned by the mixer device and is not required as an input
			/// parameter. This member overlaps with the <c>dwControlType</c> member and cannot be used in conjunction with the
			/// MIXER_GETLINECONTROLSF_ONEBYTYPE query type.
			/// </summary>
			public uint dwControlID;

			/// <summary>
			/// Class of the desired Control Types. This member is used with the MIXER_GETLINECONTROLSF_ONEBYTYPE flag for the
			/// mixerGetLineControls function to retrieve the first control of the specified class on the line specified by the
			/// <c>dwLineID</c> member of the <c>MIXERLINECONTROLS</c> structure. This member overlaps with the <c>dwControlID</c> member
			/// and cannot be used in conjunction with the MIXER_GETLINECONTROLSF_ONEBYID query type. See dwControlType member description
			/// in MIXERCONTROL.
			/// </summary>
			public uint dwControlType;

			/// <summary>
			/// Number of MIXERCONTROL structure elements to retrieve. This member must be initialized by the application before calling the
			/// mixerGetLineControls function. This member can be 1 only if MIXER_GETLINECONTROLSF_ONEBYID or
			/// MIXER_GETLINECONTROLSF_ONEBYTYPE is specified or the value returned in the <c>cControls</c> member of the MIXERLINE
			/// structure returned for an audio line. This member cannot be zero. If an audio line specifies that it has no controls,
			/// <c>mixerGetLineControls</c> should not be called.
			/// </summary>
			public uint cControls;

			/// <summary>
			/// Size, in bytes, of a single MIXERCONTROL structure. The size specified in this member must be at least large enough to
			/// contain the base <c>MIXERCONTROL</c> structure. The total size, in bytes, required for the buffer pointed to by the
			/// <c>pamxctrl</c> member is the product of the <c>cbmxctrl</c> and <c>cControls</c> members of the <c>MIXERLINECONTROLS</c> structure.
			/// </summary>
			public uint cbmxctrl;

			/// <summary>
			/// Pointer to one or more MIXERCONTROL structures to receive the properties of the requested audio line controls. This member
			/// cannot be <c>NULL</c> and must be initialized before calling the mixerGetLineControls function. Each element of the array of
			/// controls must be at least large enough to contain a base <c>MIXERCONTROL</c> structure. The <c>cbmxctrl</c> member must
			/// specify the size, in bytes, of each element in this array. No initialization of the buffer pointed to by this member is
			/// required by the application. All members are filled in by the mixer device (including the <c>cbStruct</c> member of each
			/// <c>MIXERCONTROL</c> structure) upon returning successfully.
			/// </summary>
			public IntPtr pamxctrl;
		}
	}
}