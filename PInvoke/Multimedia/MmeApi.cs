#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	/// <summary>Items from the WinMm.dll</summary>
	public static partial class WinMm
	{
		private const string Lib_Winmm = "WinMm.dll";
		private const int MMSYSERR_BASE = 0;
		private const int WAVERR_BASE = 32;

		/// <summary>Describes optional functionality supported by the auxiliary audio device.</summary>
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.auxcaps_tag")]
		[Flags]
		public enum AUX_CAPS : uint
		{
			/// <summary>Supports volume control.</summary>
			AUXCAPS_VOLUME = 0x0001,

			/// <summary>Supports separate left and right volume control.</summary>
			AUXCAPS_LRVOLUME = 0x0002,
		}

		/// <summary>Flags for opening the device.</summary>
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveInOpen")]
		[Flags]
		public enum WAVE_OPEN : uint
		{
			/// <term>The function queries the device to determine whether it supports the given format, but it does not open the device.</term>
			WAVE_FORMAT_QUERY = 0x0001,

			/// <summary></summary>
			WAVE_ALLOWSYNC = 0x0002,

			/// <term>The uDeviceID parameter specifies a waveform-audio device to be mapped to by the wave mapper.</term>
			WAVE_MAPPED = 0x0004,

			/// <term>If this flag is specified, the ACM driver does not perform conversions on the audio data.</term>
			WAVE_FORMAT_DIRECT = 0x0008,

			/// <summary></summary>
			WAVE_FORMAT_DIRECT_QUERY = WAVE_FORMAT_QUERY | WAVE_FORMAT_DIRECT,

			/// <term>
			/// If this flag is specified and the uDeviceID parameter is WAVE_MAPPER, the function opens the default communication device.
			/// This flag applies only when uDeviceID equals WAVE_MAPPER.
			/// </term>
			WAVE_MAPPED_DEFAULT_COMMUNICATION_DEVICE = 0x0010,

			/// <summary>No callback mechanism. This is the default setting.</summary>
			CALLBACK_NULL = 0x00000000,

			/// <summary>The dwCallback parameter is a window handle.</summary>
			CALLBACK_WINDOW = 0x00010000,

			/// <summary>The dwCallback parameter is a task handle.</summary>
			CALLBACK_TASK = 0x00020000,

			/// <summary>The dwCallback parameter is a callback procedure address. See <see cref="DRVCALLBACK"/>.</summary>
			CALLBACK_FUNCTION = 0x00030000,

			/// <summary>The dwCallback parameter is a thread identifier.</summary>
			CALLBACK_THREAD = CALLBACK_TASK,

			/// <summary>The dwCallback parameter is an event handle.</summary>
			CALLBACK_EVENT = 0x00050000,
		}

		/// <summary>Optional functionality supported by the device.</summary>
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.waveoutcaps_tag")]
		[Flags]
		public enum WAVECAPS : uint
		{
			/// <summary>Supports pitch control.</summary>
			WAVECAPS_PITCH = 0x0001,

			/// <summary>Supports playback rate control.</summary>
			WAVECAPS_PLAYBACKRATE = 0x0002,

			/// <summary>Supports volume control.</summary>
			WAVECAPS_VOLUME = 0x0004,

			/// <summary>Supports separate left and right volume control.</summary>
			WAVECAPS_LRVOLUME = 0x0008,

			/// <summary>The driver is synchronous and will block while playing a buffer.</summary>
			WAVECAPS_SYNC = 0x0010,

			/// <summary>Returns sample-accurate position information.</summary>
			WAVECAPS_SAMPLEACCURATE = 0x0020,
		}

		/// <summary>Flags for WAVEHDR.</summary>
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.wavehdr_tag")]
		[Flags]
		public enum WHDR
		{
			/// <summary>Set by the device driver to indicate that it is finished with the buffer and is returning it to the application.</summary>
			WHDR_DONE = 0x00000001,

			/// <summary>
			/// Set by Windows to indicate that the buffer has been prepared with the waveInPrepareHeader or waveOutPrepareHeader function.
			/// </summary>
			WHDR_PREPARED = 0x00000002,

			/// <summary>This buffer is the first buffer in a loop. This flag is used only with output buffers.</summary>
			WHDR_BEGINLOOP = 0x00000004,

			/// <summary>This buffer is the last buffer in a loop. This flag is used only with output buffers.</summary>
			WHDR_ENDLOOP = 0x00000008,

			/// <summary>Set by Windows to indicate that the buffer is queued for playback.</summary>
			WHDR_INQUEUE = 0x00000010,
		}

		/// <summary>The <c>auxGetDevCaps</c> function retrieves the capabilities of a given auxiliary output device.</summary>
		/// <param name="uDeviceID">
		/// <para>
		/// Identifier of the auxiliary output device to be queried. Specify a valid device identifier (see the following comments section),
		/// or use the following constant:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AUX_MAPPER</term>
		/// <term>Auxiliary audio mapper. The function returns an error if no auxiliary audio mapper is installed.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pac">Pointer to an AUXCAPS structure to be filled with information about the capabilities of the device.</param>
		/// <param name="cbac">Size, in bytes, of the AUXCAPS structure.</param>
		/// <returns>
		/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_BADDEVICEID</term>
		/// <term>Specified device identifier is out of range.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The device identifier in uDeviceID varies from zero to one less than the number of devices present. AUX_MAPPER may also be used.
		/// Use the auxGetNumDevs function to determine the number of auxiliary output devices present in the system.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-auxgetdevcaps MMRESULT auxGetDevCaps( UINT uDeviceID,
		// LPAUXCAPS pac, UINT cbac );
		[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.auxGetDevCaps")]
		public static extern MMRESULT auxGetDevCaps(uint uDeviceID, out AUXCAPS pac, uint cbac);

		/// <summary>The <c>auxGetNumDevs</c> function retrieves the number of auxiliary output devices present in the system.</summary>
		/// <returns>Returns the number of device. A return value of zero means that no devices are present or that an error occurred.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-auxgetnumdevs UINT auxGetNumDevs();
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.auxGetNumDevs")]
		public static extern uint auxGetNumDevs();

		/// <summary>The <c>auxGetVolume</c> function retrieves the current volume setting of the specified auxiliary output device.</summary>
		/// <param name="uDeviceID">Identifier of the auxiliary output device to be queried.</param>
		/// <param name="pdwVolume">
		/// <para>
		/// Pointer to a variable to be filled with the current volume setting. The low-order word of this location contains the left
		/// channel volume setting, and the high-order word contains the right channel setting. A value of 0xFFFF represents full volume,
		/// and a value of 0x0000 is silence.
		/// </para>
		/// <para>
		/// If a device does not support both left and right volume control, the low-order word of the specified location contains the
		/// volume level.
		/// </para>
		/// <para>
		/// The full 16-bit setting(s) set with the auxSetVolume function are returned, regardless of whether the device supports the full
		/// 16 bits of volume-level control.
		/// </para>
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
		/// <term>Specified device identifier is out of range.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Not all devices support volume control. To determine whether a device supports volume control, use the AUXCAPS_VOLUME flag to
		/// test the <c>dwSupport</c> member of the AUXCAPS structure (filled by the auxGetDevCaps function).
		/// </para>
		/// <para>
		/// To determine whether a device supports volume control on both the left and right channels, use the AUXCAPS_LRVOLUME flag to test
		/// the <c>dwSupport</c> member of the AUXCAPS structure (filled by auxGetDevCaps).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-auxgetvolume MMRESULT auxGetVolume( UINT uDeviceID, LPDWORD
		// pdwVolume );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.auxGetVolume")]
		public static extern MMRESULT auxGetVolume(uint uDeviceID, out uint pdwVolume);

		/// <summary>
		/// The <c>auxOutMessage</c> function sends a message to the given auxiliary output device. This function also performs error
		/// checking on the device identifier passed as part of the message.
		/// </summary>
		/// <param name="uDeviceID">Identifier of the auxiliary output device to receive the message.</param>
		/// <param name="uMsg">Message to send.</param>
		/// <param name="dw1">Message parameter.</param>
		/// <param name="dw2">Message parameter.</param>
		/// <returns>Returns the message return value.</returns>
		/// <remarks>
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
		/// waveInMessage, waveOutMessage, midiInMessage, midiOutMessage, and mixerMessage functions. The system intercepts this message and
		/// returns the appropriate value without sending the message to the device driver. For general information about system-intercepted
		/// <c>xxxMessage</c> functions, see System-Intercepted Device Messages.
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
		/// This message is valid only for the waveInMessage, waveOutMessage, midiInMessage, midiOutMessage, and mixerMessage functions. The
		/// system intercepts this message and returns the appropriate value without sending the message to the device driver. For general
		/// information about system-intercepted <c>xxxMessage</c> functions, see System-Intercepted Device Messages.
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
		/// waveOutMessage, midiInMessage, midiOutMessage, and mixerMessage functions. The system intercepts this message and returns the
		/// appropriate value without sending the message to the device driver. For general information about system-intercepted
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
		/// This message is valid only for the waveInMessage, waveOutMessage, midiInMessage, midiOutMessage, mixerMessage and
		/// <c>auxOutMessage</c> functions. The system intercepts this message and returns the appropriate value without sending the message
		/// to the device driver. For general information about system-intercepted <c>xxxMessage</c> functions, see System-Intercepted
		/// Device Messages.
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
		/// appropriate handle type. For the <c>waveInMessage</c>, <c>waveOutMessage</c>, midiInMessage, midiOutMessage, or mixerMessage
		/// functions, the caller must cast the device ID to a handle of type HWAVEIN, HWAVEOUT, HMIDIIN, HMIDIOUT, or HMIXER, respectively.
		/// Note that if the caller supplies a valid handle instead of a device ID for this parameter, the function fails and returns error
		/// code MMSYSERR_NOSUPPORT.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-auxoutmessage MMRESULT auxOutMessage( UINT uDeviceID, UINT
		// uMsg, DWORD_PTR dw1, DWORD_PTR dw2 );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.auxOutMessage")]
		public static extern MMRESULT auxOutMessage(uint uDeviceID, uint uMsg, IntPtr dw1, IntPtr dw2);

		/// <summary>The <c>auxSetVolume</c> function sets the volume of the specified auxiliary output device.</summary>
		/// <param name="uDeviceID">
		/// Identifier of the auxiliary output device to be queried. Device identifiers are determined implicitly from the number of devices
		/// present in the system. Device identifier values range from zero to one less than the number of devices present. Use the
		/// auxGetNumDevs function to determine the number of auxiliary devices in the system.
		/// </param>
		/// <param name="dwVolume">
		/// <para>
		/// Specifies the new volume setting. The low-order word specifies the left-channel volume setting, and the high-order word
		/// specifies the right-channel setting. A value of 0xFFFF represents full volume, and a value of 0x0000 is silence.
		/// </para>
		/// <para>
		/// If a device does not support both left and right volume control, the low-order word of dwVolume specifies the volume level, and
		/// the high-order word is ignored.
		/// </para>
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
		/// <term>Specified device identifier is out of range.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Not all devices support volume control. To determine whether the device supports volume control, use the AUXCAPS_VOLUME flag to
		/// test the <c>dwSupport</c> member of the AUXCAPS structure (filled by the auxGetDevCaps function).
		/// </para>
		/// <para>
		/// To determine whether the device supports volume control on both the left and right channels, use the AUXCAPS_LRVOLUME flag to
		/// test the <c>dwSupport</c> member of the AUXCAPS structure (filled by auxGetDevCaps).
		/// </para>
		/// <para>
		/// Most devices do not support the full 16 bits of volume-level control and will use only the high-order bits of the requested
		/// volume setting. For example, for a device that supports 4 bits of volume control, requested volume level values of 0x4000,
		/// 0x4FFF, and 0x43BE will produce the same physical volume setting, 0x4000. The auxGetVolume function will return the full 16-bit
		/// setting set with <c>auxSetVolume</c>.
		/// </para>
		/// <para>
		/// Volume settings are interpreted logarithmically. This means the perceived volume increase is the same when increasing the volume
		/// level from 0x5000 to 0x6000 as it is from 0x4000 to 0x5000.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-auxsetvolume MMRESULT auxSetVolume( UINT uDeviceID, DWORD
		// dwVolume );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.auxSetVolume")]
		public static extern MMRESULT auxSetVolume(uint uDeviceID, uint dwVolume);

		/// <summary>
		/// The <c>waveInAddBuffer</c> function sends an input buffer to the given waveform-audio input device. When the buffer is filled,
		/// the application is notified.
		/// </summary>
		/// <param name="hwi">Handle to the waveform-audio input device.</param>
		/// <param name="pwh">Pointer to a WAVEHDR structure that identifies the buffer.</param>
		/// <param name="cbwh">Size, in bytes, of the <c>WAVEHDR</c> structure.</param>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// <item>
		/// <term>WAVERR_UNPREPARED</term>
		/// <term>The buffer pointed to by the pwh parameter hasn't been prepared.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>When the buffer is filled, the WHDR_DONE bit is set in the <c>dwFlags</c> member of the <c>WAVEHDR</c> structure.</para>
		/// <para>The buffer must be prepared with the <c>waveInPrepareHeader</c> function before it is passed to this function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveinaddbuffer MMRESULT waveInAddBuffer( HWAVEIN hwi,
		// LPWAVEHDR pwh, UINT cbwh );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveInAddBuffer")]
		public static extern MMRESULT waveInAddBuffer([In] HWAVEIN hwi, ref WAVEHDR pwh, uint cbwh);

		/// <summary>The <c>waveInClose</c> function closes the given waveform-audio input device.</summary>
		/// <param name="hwi">
		/// Handle to the waveform-audio input device. If the function succeeds, the handle is no longer valid after this call.
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// <item>
		/// <term>WAVERR_STILLPLAYING</term>
		/// <term>There are still buffers in the queue.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If there are input buffers that have been sent with the <c>waveInAddBuffer</c> function and that haven't been returned to the
		/// application, the close operation will fail. Call the <c>waveInReset</c> function to mark all pending buffers as done.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveinclose MMRESULT waveInClose( HWAVEIN hwi );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveInClose")]
		public static extern MMRESULT waveInClose(HWAVEIN hwi);

		/// <summary>The <c>waveInGetDevCaps</c> function retrieves the capabilities of a given waveform-audio input device.</summary>
		/// <param name="uDeviceID">
		/// Identifier of the waveform-audio output device. It can be either a device identifier or a handle of an open waveform-audio input device.
		/// </param>
		/// <param name="pwic">Pointer to a WAVEINCAPS structure to be filled with information about the capabilities of the device.</param>
		/// <param name="cbwic">Size, in bytes, of the <c>WAVEINCAPS</c> structure.</param>
		/// <returns>
		/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_BADDEVICEID</term>
		/// <term>Specified device identifier is out of range.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Use this function to determine the number of waveform-audio input devices present in the system. If the value specified by the
		/// uDeviceID parameter is a device identifier, it can vary from zero to one less than the number of devices present. The
		/// WAVE_MAPPER constant can also be used as a device identifier. Only cbwic bytes (or less) of information is copied to the
		/// location pointed to by pwic. If cbwic is zero, nothing is copied and the function returns zero.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveingetdevcaps MMRESULT waveInGetDevCaps( UINT uDeviceID,
		// LPWAVEINCAPS pwic, UINT cbwic );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveInGetDevCaps")]
		public static extern MMRESULT waveInGetDevCaps(uint uDeviceID, out WAVEINCAPS pwic, uint cbwic);

		/// <summary>
		/// The <c>waveInGetErrorText</c> function retrieves a textual description of the error identified by the given error number.
		/// </summary>
		/// <param name="mmrError">Error number.</param>
		/// <param name="pszText">Pointer to the buffer to be filled with the textual error description.</param>
		/// <param name="cchText">Size, in characters, of the buffer pointed to by pszText.</param>
		/// <returns>
		/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_BADERRNUM</term>
		/// <term>Specified error number is out of range.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the textual error description is longer than the specified buffer, the description is truncated. The returned error string is
		/// always null-terminated. If cchText is zero, nothing is copied and the function returns zero. All error descriptions are less
		/// than MAXERRORLENGTH characters long.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveingeterrortext MMRESULT waveInGetErrorText( MMRESULT
		// mmrError, LPSTR pszText, UINT cchText );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveInGetErrorText")]
		public static extern MMRESULT waveInGetErrorText(MMRESULT mmrError, [MarshalAs(UnmanagedType.LPStr)] StringBuilder pszText, uint cchText);

		/// <summary>
		/// <para>The <c>waveInGetID</c> function gets the device identifier for the given waveform-audio input device.</para>
		/// <para>
		/// This function is supported for backward compatibility. New applications can cast a handle of the device rather than retrieving
		/// the device identifier.
		/// </para>
		/// </summary>
		/// <param name="hwi">Handle to the waveform-audio input device.</param>
		/// <param name="puDeviceID">Pointer to a variable to be filled with the device identifier.</param>
		/// <returns>
		/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The hwi parameter specifies an invalid handle.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveingetid MMRESULT waveInGetID( HWAVEIN hwi, LPUINT
		// puDeviceID );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveInGetID")]
		public static extern MMRESULT waveInGetID(HWAVEIN hwi, out uint puDeviceID);

		/// <summary>The <c>waveInGetNumDevs</c> function returns the number of waveform-audio input devices present in the system.</summary>
		/// <returns>Returns the number of devices. A return value of zero means that no devices are present or that an error occurred.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveingetnumdevs UINT waveInGetNumDevs();
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveInGetNumDevs")]
		public static extern uint waveInGetNumDevs();

		/// <summary>
		/// <para>[ <c>waveInGetPosition</c> is no longer supported for use as of Windows Vista. Instead, use IAudioClock::GetPosition.]</para>
		/// <para>The <c>waveInGetPosition</c> function retrieves the current input position of the given waveform-audio input device.</para>
		/// </summary>
		/// <param name="hwi">Handle to the waveform-audio input device.</param>
		/// <param name="pmmt">Pointer to an MMTIME structure.</param>
		/// <param name="cbmmt">Size, in bytes, of the MMTIME structure.</param>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Before calling this function, set the <c>wType</c> member of the MMTIME structure to indicate the time format you want. After
		/// calling this function, check <c>wType</c> to determine whether the desired time format is supported. If the format is not
		/// supported, the member will specify an alternative format.
		/// </para>
		/// <para>The position is set to zero when the device is opened or reset.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveingetposition MMRESULT waveInGetPosition( HWAVEIN hwi,
		// LPMMTIME pmmt, UINT cbmmt );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveInGetPosition")]
		public static extern MMRESULT waveInGetPosition(HWAVEIN hwi, ref MMTIME pmmt, uint cbmmt);

		/// <summary>The <c>waveInMessage</c> function sends messages to the waveform-audio input device drivers.</summary>
		/// <param name="hwi">
		/// Identifier of the waveform device that receives the message. You must cast the device ID to the <c>HWAVEIN</c> handle type. If
		/// you supply a handle instead of a device ID, the function fails and returns the MMSYSERR_NOSUPPORT error code.
		/// </param>
		/// <param name="uMsg">Message to send.</param>
		/// <param name="dw1">Message parameter.</param>
		/// <param name="dw2">Message parameter.</param>
		/// <returns>Returns the value returned from the driver.</returns>
		/// <remarks>
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
		/// <c>waveInMessage</c>, waveOutMessage, midiInMessage, midiOutMessage, and mixerMessage functions. The system intercepts this
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
		/// This message is valid only for the <c>waveInMessage</c>, waveOutMessage, midiInMessage, midiOutMessage, and mixerMessage
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
		/// In Windows 2000 and later, the message always returns MMSYSERR_NOTSUPPORTED. This message is valid only for the
		/// <c>waveInMessage</c>, waveOutMessage, midiInMessage, midiOutMessage, and mixerMessage functions. The system intercepts this
		/// message and returns the appropriate value without sending the message to the device driver. For general information about
		/// system-intercepted <c>xxxMessage</c> functions, see System-Intercepted Device Messages.
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
		/// This message is valid only for the <c>waveInMessage</c>, waveOutMessage, midiInMessage, midiOutMessage, mixerMessage and
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
		/// This message is valid only for the <c>waveInMessage</c> and waveOutMessage functions. When a caller calls these two functions
		/// with the DRVM_MAPPER_CONSOLEVOICECOM_GET message, the caller must specify the device ID as WAVE_MAPPER, and then cast this value
		/// to the appropriate handle type. For the <c>waveInMessage</c>, <c>waveOutMessage</c>, midiInMessage, midiOutMessage, or
		/// mixerMessage functions, the caller must cast the device ID to a handle of type HWAVEIN, HWAVEOUT, HMIDIIN, HMIDIOUT, or HMIXER,
		/// respectively. Note that if the caller supplies a valid handle instead of a device ID for this parameter, the function fails and
		/// returns error code MMSYSERR_NOSUPPORT.
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
		/// This message is valid only for the <c>waveInMessage</c>, waveOutMessage and midiOutMessage functions. When the caller calls
		/// these functions with the DRVM_MAPPER_PREFERRED_GET message, the caller must first specify the device ID as WAVE_MAPPER (for
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
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveinmessage MMRESULT waveInMessage( HWAVEIN hwi, UINT uMsg,
		// DWORD_PTR dw1, DWORD_PTR dw2 );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveInMessage")]
		public static extern MMRESULT waveInMessage(HWAVEIN hwi, uint uMsg, IntPtr dw1, IntPtr dw2);

		/// <summary>The <c>waveInOpen</c> function opens the given waveform-audio input device for recording.</summary>
		/// <param name="phwi">
		/// Pointer to a buffer that receives a handle identifying the open waveform-audio input device. Use this handle to identify the
		/// device when calling other waveform-audio input functions. This parameter can be <c>NULL</c> if <c>WAVE_FORMAT_QUERY</c> is
		/// specified for fdwOpen.
		/// </param>
		/// <param name="uDeviceID">
		/// <para>
		/// Identifier of the waveform-audio input device to open. It can be either a device identifier or a handle of an open
		/// waveform-audio input device. You can use the following flag instead of a device identifier.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WAVE_MAPPER</term>
		/// <term>The function selects a waveform-audio input device capable of recording in the specified format.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pwfx">
		/// Pointer to a WAVEFORMATEX structure that identifies the desired format for recording waveform-audio data. You can free this
		/// structure immediately after <c>waveInOpen</c> returns.
		/// </param>
		/// <param name="dwCallback">
		/// Pointer to a fixed callback function, an event handle, a handle to a window, or the identifier of a thread to be called during
		/// waveform-audio recording to process messages related to the progress of recording. If no callback function is required, this
		/// value can be zero. For more information on the callback function, see waveInProc.
		/// </param>
		/// <param name="dwInstance">
		/// User-instance data passed to the callback mechanism. This parameter is not used with the window callback mechanism.
		/// </param>
		/// <param name="fdwOpen">
		/// <para>Flags for opening the device. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CALLBACK_EVENT</term>
		/// <term>The dwCallback parameter is an event handle.</term>
		/// </item>
		/// <item>
		/// <term>CALLBACK_FUNCTION</term>
		/// <term>The dwCallback parameter is a callback procedure address.</term>
		/// </item>
		/// <item>
		/// <term>CALLBACK_NULL</term>
		/// <term>No callback mechanism. This is the default setting.</term>
		/// </item>
		/// <item>
		/// <term>CALLBACK_THREAD</term>
		/// <term>The dwCallback parameter is a thread identifier.</term>
		/// </item>
		/// <item>
		/// <term>CALLBACK_WINDOW</term>
		/// <term>The dwCallback parameter is a window handle.</term>
		/// </item>
		/// <item>
		/// <term>WAVE_MAPPED_DEFAULT_COMMUNICATION_DEVICE</term>
		/// <term>
		/// If this flag is specified and the uDeviceID parameter is WAVE_MAPPER, the function opens the default communication device. This
		/// flag applies only when uDeviceID equals WAVE_MAPPER.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WAVE_FORMAT_DIRECT</term>
		/// <term>If this flag is specified, the ACM driver does not perform conversions on the audio data.</term>
		/// </item>
		/// <item>
		/// <term>WAVE_FORMAT_QUERY</term>
		/// <term>The function queries the device to determine whether it supports the given format, but it does not open the device.</term>
		/// </item>
		/// <item>
		/// <term>WAVE_MAPPED</term>
		/// <term>The uDeviceID parameter specifies a waveform-audio device to be mapped to by the wave mapper.</term>
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
		/// <term>Specified resource is already allocated.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_BADDEVICEID</term>
		/// <term>Specified device identifier is out of range.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// <item>
		/// <term>WAVERR_BADFORMAT</term>
		/// <term>Attempted to open with an unsupported waveform-audio format.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Use the waveInGetNumDevs function to determine the number of waveform-audio input devices present on the system. The device
		/// identifier specified by uDeviceID varies from zero to one less than the number of devices present. The WAVE_MAPPER constant can
		/// also be used as a device identifier.
		/// </para>
		/// <para>
		/// If you choose to have a window or thread receive callback information, the following messages are sent to the window procedure
		/// or thread to indicate the progress of waveform-audio input: MM_WIM_OPEN, MM_WIM_CLOSE, and MM_WIM_DATA.
		/// </para>
		/// <para>
		/// If you choose to have a function receive callback information, the following messages are sent to the function to indicate the
		/// progress of waveform-audio input: WIM_OPEN, WIM_CLOSE, and WIM_DATA.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveinopen MMRESULT waveInOpen( LPHWAVEIN phwi, UINT
		// uDeviceID, LPCWAVEFORMATEX pwfx, DWORD_PTR dwCallback, DWORD_PTR dwInstance, DWORD fdwOpen );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveInOpen")]
		public static extern MMRESULT waveInOpen(out SafeHWAVEIN phwi, uint uDeviceID, in WAVEFORMATEX pwfx, [In, Optional] IntPtr dwCallback, [In, Optional] IntPtr dwInstance, WAVE_OPEN fdwOpen);

		/// <summary>The <c>waveInPrepareHeader</c> function prepares a buffer for waveform-audio input.</summary>
		/// <param name="hwi">Handle to the waveform-audio input device.</param>
		/// <param name="pwh">Pointer to a WAVEHDR structure that identifies the buffer to be prepared.</param>
		/// <param name="cbwh">Size, in bytes, of the <c>WAVEHDR</c> structure.</param>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The <c>lpData</c>, <c>dwBufferLength</c>, and <c>dwFlags</c> members of the <c>WAVEHDR</c> structure must be set before calling
		/// this function ( <c>dwFlags</c> must be zero).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveinprepareheader MMRESULT waveInPrepareHeader( HWAVEIN
		// hwi, LPWAVEHDR pwh, UINT cbwh );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveInPrepareHeader")]
		public static extern MMRESULT waveInPrepareHeader(HWAVEIN hwi, ref WAVEHDR pwh, uint cbwh);

		/// <summary>
		/// The <c>waveInReset</c> function stops input on the given waveform-audio input device and resets the current position to zero.
		/// All pending buffers are marked as done and returned to the application.
		/// </summary>
		/// <param name="hwi">Handle to the waveform-audio input device.</param>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveinreset MMRESULT waveInReset( HWAVEIN hwi );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveInReset")]
		public static extern MMRESULT waveInReset(HWAVEIN hwi);

		/// <summary>The <c>waveInStart</c> function starts input on the given waveform-audio input device.</summary>
		/// <param name="hwi">Handle to the waveform-audio input device.</param>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Buffers are returned to the application when full or when the <c>waveInReset</c> function is called (the <c>dwBytesRecorded</c>
		/// member in the header will contain the length of data). If there are no buffers in the queue, the data is thrown away without
		/// notifying the application, and input continues.
		/// </para>
		/// <para>Calling this function when input is already started has no effect, and the function returns zero.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveinstart MMRESULT waveInStart( HWAVEIN hwi );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveInStart")]
		public static extern MMRESULT waveInStart(HWAVEIN hwi);

		/// <summary>The <c>waveInStop</c> function stops waveform-audio input.</summary>
		/// <param name="hwi">Handle to the waveform-audio input device.</param>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If there are any buffers in the queue, the current buffer will be marked as done (the <c>dwBytesRecorded</c> member in the
		/// header will contain the length of data), but any empty buffers in the queue will remain there.
		/// </para>
		/// <para>Calling this function when input is not started has no effect, and the function returns zero.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveinstop MMRESULT waveInStop( HWAVEIN hwi );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveInStop")]
		public static extern MMRESULT waveInStop(HWAVEIN hwi);

		/// <summary>
		/// The <c>waveInUnprepareHeader</c> function cleans up the preparation performed by the waveInPrepareHeader function. This function
		/// must be called after the device driver fills a buffer and returns it to the application. You must call this function before
		/// freeing the buffer.
		/// </summary>
		/// <param name="hwi">Handle to the waveform-audio input device.</param>
		/// <param name="pwh">Pointer to a WAVEHDR structure identifying the buffer to be cleaned up.</param>
		/// <param name="cbwh">Size, in bytes, of the <c>WAVEHDR</c> structure.</param>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// <item>
		/// <term>WAVERR_STILLPLAYING</term>
		/// <term>The buffer pointed to by the pwh parameter is still in the queue.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>This function complements the <c>waveInPrepareHeader</c> function.</para>
		/// <para>
		/// You must call this function before freeing the buffer. After passing a buffer to the device driver with the
		/// <c>waveInAddBuffer</c> function, you must wait until the driver is finished with the buffer before calling
		/// <c>waveInUnprepareHeader</c>. Unpreparing a buffer that has not been prepared has no effect, and the function returns zero.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveinunprepareheader MMRESULT waveInUnprepareHeader( HWAVEIN
		// hwi, LPWAVEHDR pwh, UINT cbwh );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveInUnprepareHeader")]
		public static extern MMRESULT waveInUnprepareHeader(HWAVEIN hwi, ref WAVEHDR pwh, uint cbwh);

		/// <summary>
		/// The <c>waveOutBreakLoop</c> function breaks a loop on the given waveform-audio output device and allows playback to continue
		/// with the next block in the driver list.
		/// </summary>
		/// <param name="hwo">Handle to the waveform-audio output device.</param>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The blocks making up the loop are played to the end before the loop is terminated.</para>
		/// <para>Calling this function when nothing is playing or looping has no effect, and the function returns zero.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutbreakloop MMRESULT waveOutBreakLoop( HWAVEOUT hwo );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutBreakLoop")]
		public static extern MMRESULT waveOutBreakLoop(HWAVEOUT hwo);

		/// <summary>The <c>waveOutClose</c> function closes the given waveform-audio output device.</summary>
		/// <param name="hwo">
		/// Handle to the waveform-audio output device. If the function succeeds, the handle is no longer valid after this call.
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// <item>
		/// <term>WAVERR_STILLPLAYING</term>
		/// <term>There are still buffers in the queue.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The close operation fails if the device is still playing a waveform-audio buffer that was previously sent by calling
		/// <c>waveOutWrite</c>. Before calling <c>waveOutClose</c>, the application must wait for all buffers to finish playing or call the
		/// <c>waveOutReset</c> function to terminate playback.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutclose MMRESULT waveOutClose( HWAVEOUT hwo );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutClose")]
		public static extern MMRESULT waveOutClose(HWAVEOUT hwo);

		/// <summary>The <c>waveOutGetDevCaps</c> function retrieves the capabilities of a given waveform-audio output device.</summary>
		/// <param name="uDeviceID">
		/// Identifier of the waveform-audio output device. It can be either a device identifier or a handle of an open waveform-audio
		/// output device.
		/// </param>
		/// <param name="pwoc">Pointer to a WAVEOUTCAPS structure to be filled with information about the capabilities of the device.</param>
		/// <param name="cbwoc">Size, in bytes, of the <c>WAVEOUTCAPS</c> structure.</param>
		/// <returns>
		/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_BADDEVICEID</term>
		/// <term>Specified device identifier is out of range.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Use the <c>waveOutGetNumDevs</c> function to determine the number of waveform-audio output devices present in the system. If the
		/// value specified by the uDeviceID parameter is a device identifier, it can vary from zero to one less than the number of devices
		/// present. The WAVE_MAPPER constant can also be used as a device identifier. Only cbwoc bytes (or less) of information is copied
		/// to the location pointed to by pwoc. If cbwoc is zero, nothing is copied and the function returns zero.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutgetdevcaps MMRESULT waveOutGetDevCaps( UINT uDeviceID,
		// LPWAVEOUTCAPS pwoc, UINT cbwoc );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutGetDevCaps")]
		public static extern MMRESULT waveOutGetDevCaps(uint uDeviceID, out WAVEOUTCAPS pwoc, uint cbwoc);

		/// <summary>
		/// The <c>waveOutGetErrorText</c> function retrieves a textual description of the error identified by the given error number.
		/// </summary>
		/// <param name="mmrError">Error number.</param>
		/// <param name="pszText">Pointer to a buffer to be filled with the textual error description.</param>
		/// <param name="cchText">Size, in characters, of the buffer pointed to by pszText.</param>
		/// <returns>
		/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_BADERRNUM</term>
		/// <term>Specified error number is out of range.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the textual error description is longer than the specified buffer, the description is truncated. The returned error string is
		/// always null-terminated. If cchText is zero, nothing is copied and the function returns zero. All error descriptions are less
		/// than MAXERRORLENGTH characters long.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutgeterrortext MMRESULT waveOutGetErrorText( MMRESULT
		// mmrError, LPSTR pszText, UINT cchText );
		[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutGetErrorText")]
		public static extern MMRESULT waveOutGetErrorText(MMRESULT mmrError, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder pszText, uint cchText);

		/// <summary>
		/// <para>The <c>waveOutGetID</c> function retrieves the device identifier for the given waveform-audio output device.</para>
		/// <para>
		/// This function is supported for backward compatibility. New applications can cast a handle of the device rather than retrieving
		/// the device identifier.
		/// </para>
		/// </summary>
		/// <param name="hwo">Handle to the waveform-audio output device.</param>
		/// <param name="puDeviceID">Pointer to a variable to be filled with the device identifier.</param>
		/// <returns>
		/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>The hwo parameter specifies an invalid handle.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutgetid MMRESULT waveOutGetID( HWAVEOUT hwo, LPUINT
		// puDeviceID );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutGetID")]
		public static extern MMRESULT waveOutGetID(HWAVEOUT hwo, out uint puDeviceID);

		/// <summary>The <c>waveOutGetNumDevs</c> function retrieves the number of waveform-audio output devices present in the system.</summary>
		/// <returns>Returns the number of devices. A return value of zero means that no devices are present or that an error occurred.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutgetnumdevs UINT waveOutGetNumDevs();
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutGetNumDevs")]
		public static extern uint waveOutGetNumDevs();

		/// <summary>
		/// The <c>waveOutGetPitch</c> function retrieves the current pitch setting for the specified waveform-audio output device.
		/// </summary>
		/// <param name="hwo">Handle to the waveform-audio output device.</param>
		/// <param name="pdwPitch">
		/// <para>
		/// Pointer to a variable to be filled with the current pitch multiplier setting. The pitch multiplier indicates the current change
		/// in pitch from the original authored setting. The pitch multiplier must be a positive value.
		/// </para>
		/// <para>
		/// The pitch multiplier is specified as a fixed-point value. The high-order word of the variable contains the signed integer part
		/// of the number, and the low-order word contains the fractional part. A value of 0x8000 in the low-order word represents one-half,
		/// and 0x4000 represents one-quarter. For example, the value 0x00010000 specifies a multiplier of 1.0 (no pitch change), and a
		/// value of 0x000F8000 specifies a multiplier of 15.5.
		/// </para>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOTSUPPORTED</term>
		/// <term>Function isn't supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Changing the pitch does not change the playback rate, sample rate, or playback time. Not all devices support pitch changes. To
		/// determine whether the device supports pitch control, use the WAVECAPS_PITCH flag to test the <c>dwSupport</c> member of the
		/// <c>WAVEOUTCAPS</c> structure (filled by the <c>waveOutGetDevCaps</c> function).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutgetpitch MMRESULT waveOutGetPitch( HWAVEOUT hwo,
		// LPDWORD pdwPitch );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutGetPitch")]
		public static extern MMRESULT waveOutGetPitch(HWAVEOUT hwo, out uint pdwPitch);

		/// <summary>
		/// The <c>waveOutGetPlaybackRate</c> function retrieves the current playback rate for the specified waveform-audio output device.
		/// </summary>
		/// <param name="hwo">Handle to the waveform-audio output device.</param>
		/// <param name="pdwRate">
		/// <para>
		/// Pointer to a variable to be filled with the current playback rate. The playback rate setting is a multiplier indicating the
		/// current change in playback rate from the original authored setting. The playback rate multiplier must be a positive value.
		/// </para>
		/// <para>
		/// The rate is specified as a fixed-point value. The high-order word of the variable contains the signed integer part of the
		/// number, and the low-order word contains the fractional part. A value of 0x8000 in the low-order word represents one-half, and
		/// 0x4000 represents one-quarter. For example, the value 0x00010000 specifies a multiplier of 1.0 (no playback rate change), and a
		/// value of 0x000F8000 specifies a multiplier of 15.5.
		/// </para>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOTSUPPORTED</term>
		/// <term>Function isn't supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Changing the playback rate does not change the sample rate but does change the playback time. Not all devices support playback
		/// rate changes. To determine whether a device supports playback rate changes, use the WAVECAPS_PLAYBACKRATE flag to test the
		/// <c>dwSupport</c> member of the <c>WAVEOUTCAPS</c> structure (filled by the <c>waveOutGetDevCaps</c> function).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutgetplaybackrate MMRESULT waveOutGetPlaybackRate(
		// HWAVEOUT hwo, LPDWORD pdwRate );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutGetPlaybackRate")]
		public static extern MMRESULT waveOutGetPlaybackRate(HWAVEOUT hwo, out uint pdwRate);

		/// <summary>
		/// The <c>waveOutGetPosition</c> function retrieves the current playback position of the given waveform-audio output device.
		/// </summary>
		/// <param name="hwo">Handle to the waveform-audio output device.</param>
		/// <param name="pmmt">Pointer to an MMTIME structure.</param>
		/// <param name="cbmmt">Size, in bytes, of the <c>MMTIME</c> structure.</param>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Before calling this function, set the <c>wType</c> member of the <c>MMTIME</c> structure to indicate the time format you want.
		/// After calling this function, check <c>wType</c> to determine whether the time format is supported. If the format is not
		/// supported, <c>wType</c> will specify an alternative format.
		/// </para>
		/// <para>The position is set to zero when the device is opened or reset.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutgetposition MMRESULT waveOutGetPosition( HWAVEOUT hwo,
		// LPMMTIME pmmt, UINT cbmmt );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutGetPosition")]
		public static extern MMRESULT waveOutGetPosition(HWAVEOUT hwo, ref MMTIME pmmt, uint cbmmt);

		/// <summary>The <c>waveOutGetVolume</c> function retrieves the current volume level of the specified waveform-audio output device.</summary>
		/// <param name="hwo">Handle to an open waveform-audio output device. This parameter can also be a device identifier.</param>
		/// <param name="pdwVolume">
		/// <para>
		/// Pointer to a variable to be filled with the current volume setting. The low-order word of this location contains the
		/// left-channel volume setting, and the high-order word contains the right-channel setting. A value of 0xFFFF represents full
		/// volume, and a value of 0x0000 is silence.
		/// </para>
		/// <para>
		/// If a device does not support both left and right volume control, the low-order word of the specified location contains the mono
		/// volume level.
		/// </para>
		/// <para>
		/// The full 16-bit setting(s) set with the waveOutSetVolume function is returned, regardless of whether the device supports the
		/// full 16 bits of volume-level control.
		/// </para>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOTSUPPORTED</term>
		/// <term>Function isn't supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If a device identifier is used, then the result of the <c>waveOutGetVolume</c> call and the information returned in pdwVolume
		/// applies to all instances of the device. If a device handle is used, then the result and information returned applies only to the
		/// instance of the device referenced by the device handle.
		/// </para>
		/// <para>
		/// Not all devices support volume changes. To determine whether the device supports volume control, use the WAVECAPS_VOLUME flag to
		/// test the <c>dwSupport</c> member of the <c>WAVEOUTCAPS</c> structure (filled by the <c>waveOutGetDevCaps</c> function).
		/// </para>
		/// <para>
		/// To determine whether the device supports left- and right-channel volume control, use the WAVECAPS_LRVOLUME flag to test the
		/// <c>dwSupport</c> member of the <c>WAVEOUTCAPS</c> structure (filled by <c>waveOutGetDevCaps</c>).
		/// </para>
		/// <para>
		/// Volume settings are interpreted logarithmically. This means the perceived increase in volume is the same when increasing the
		/// volume level from 0x5000 to 0x6000 as it is from 0x4000 to 0x5000.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutgetvolume MMRESULT waveOutGetVolume( HWAVEOUT hwo,
		// LPDWORD pdwVolume );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutGetVolume")]
		public static extern MMRESULT waveOutGetVolume(HWAVEOUT hwo, out uint pdwVolume);

		/// <summary>The <c>waveOutMessage</c> function sends messages to the waveform-audio output device drivers.</summary>
		/// <param name="hwo">
		/// Identifier of the waveform device that receives the message. You must cast the device ID to the <c>HWAVEOUT</c> handle type. If
		/// you supply a handle instead of a device ID, the function fails and returns the MMSYSERR_NOSUPPORT error code.
		/// </param>
		/// <param name="uMsg">Message to send.</param>
		/// <param name="dw1">Message parameter.</param>
		/// <param name="dw2">Message parameter.</param>
		/// <returns>Returns the value returned from the driver.</returns>
		/// <remarks>
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
		/// waveInMessage, <c>waveOutMessage</c>, midiInMessage, midiOutMessage, and mixerMessage functions. The system intercepts this
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
		/// This message is valid only for the waveInMessage, <c>waveOutMessage</c>, midiInMessage, midiOutMessage, and mixerMessage
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
		/// <c>waveOutMessage</c>, midiInMessage, midiOutMessage, and mixerMessage functions. The system intercepts this message and returns
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
		/// This message is valid only for the waveInMessage, <c>waveOutMessage</c>, midiInMessage, midiOutMessage, mixerMessage and
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
		/// This message is valid only for the waveInMessage and <c>waveOutMessage</c> functions. When a caller calls these two functions
		/// with the DRVM_MAPPER_CONSOLEVOICECOM_GET message, the caller must specify the device ID as WAVE_MAPPER, and then cast this value
		/// to the appropriate handle type. For the <c>waveInMessage</c>, <c>waveOutMessage</c>, midiInMessage, midiOutMessage, or
		/// mixerMessage functions, the caller must cast the device ID to a handle of type HWAVEIN, HWAVEOUT, HMIDIIN, HMIDIOUT, or HMIXER,
		/// respectively. Note that if the caller supplies a valid handle instead of a device ID for this parameter, the function fails and
		/// returns error code MMSYSERR_NOSUPPORT.
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
		/// This message is valid only for the waveInMessage, <c>waveOutMessage</c> and midiOutMessage functions. When the caller calls
		/// these functions with the DRVM_MAPPER_PREFERRED_GET message, the caller must first specify the device ID as WAVE_MAPPER (for
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
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutmessage MMRESULT waveOutMessage( HWAVEOUT hwo, UINT
		// uMsg, DWORD_PTR dw1, DWORD_PTR dw2 );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutMessage")]
		public static extern MMRESULT waveOutMessage(HWAVEOUT hwo, uint uMsg, IntPtr dw1, IntPtr dw2);

		/// <summary>The <c>waveOutOpen</c> function opens the given waveform-audio output device for playback.</summary>
		/// <param name="phwo">
		/// Pointer to a buffer that receives a handle identifying the open waveform-audio output device. Use the handle to identify the
		/// device when calling other waveform-audio output functions. This parameter might be <c>NULL</c> if the <c>WAVE_FORMAT_QUERY</c>
		/// flag is specified for fdwOpen.
		/// </param>
		/// <param name="uDeviceID">
		/// <para>
		/// Identifier of the waveform-audio output device to open. It can be either a device identifier or a handle of an open
		/// waveform-audio input device. You can also use the following flag instead of a device identifier:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WAVE_MAPPER</term>
		/// <term>The function selects a waveform-audio output device capable of playing the given format.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pwfx">
		/// Pointer to a WAVEFORMATEX structure that identifies the format of the waveform-audio data to be sent to the device. You can free
		/// this structure immediately after passing it to <c>waveOutOpen</c>.
		/// </param>
		/// <param name="dwCallback">
		/// <para>Specifies the callback mechanism. The value must be one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>A pointer to a callback function. For the function signature, see waveOutProc.</term>
		/// </item>
		/// <item>
		/// <term>A handle to a window.</term>
		/// </item>
		/// <item>
		/// <term>A thread identifier.</term>
		/// </item>
		/// <item>
		/// <term>A handle to an event.</term>
		/// </item>
		/// <item>
		/// <term>The value <c>NULL</c>.</term>
		/// </item>
		/// </list>
		/// <para>The</para>
		/// <para>fdwOpen</para>
		/// <para>parameter specifies how the</para>
		/// <para>dwCallback</para>
		/// <para>parameter is interpreted. For more information, see Remarks.</para>
		/// </param>
		/// <param name="dwInstance">
		/// User-instance data passed to the callback mechanism. This parameter is not used with the window callback mechanism.
		/// </param>
		/// <param name="fdwOpen">
		/// <para>Flags for opening the device. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CALLBACK_EVENT</term>
		/// <term>The dwCallback parameter is an event handle.</term>
		/// </item>
		/// <item>
		/// <term>CALLBACK_FUNCTION</term>
		/// <term>The dwCallback parameter is a callback procedure address.</term>
		/// </item>
		/// <item>
		/// <term>CALLBACK_NULL</term>
		/// <term>No callback mechanism. This is the default setting.</term>
		/// </item>
		/// <item>
		/// <term>CALLBACK_THREAD</term>
		/// <term>The dwCallback parameter is a thread identifier.</term>
		/// </item>
		/// <item>
		/// <term>CALLBACK_WINDOW</term>
		/// <term>The dwCallback parameter is a window handle.</term>
		/// </item>
		/// <item>
		/// <term>WAVE_ALLOWSYNC</term>
		/// <term>
		/// If this flag is specified, a synchronous waveform-audio device can be opened. If this flag is not specified while opening a
		/// synchronous driver, the device will fail to open.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WAVE_MAPPED_DEFAULT_COMMUNICATION_DEVICE</term>
		/// <term>
		/// If this flag is specified and the uDeviceID parameter is WAVE_MAPPER, the function opens the default communication device. This
		/// flag applies only when uDeviceID equals WAVE_MAPPER.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WAVE_FORMAT_DIRECT</term>
		/// <term>If this flag is specified, the ACM driver does not perform conversions on the audio data.</term>
		/// </item>
		/// <item>
		/// <term>WAVE_FORMAT_QUERY</term>
		/// <term>
		/// If this flag is specified, waveOutOpen queries the device to determine if it supports the given format, but the device is not
		/// actually opened.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WAVE_MAPPED</term>
		/// <term>If this flag is specified, the uDeviceID parameter specifies a waveform-audio device to be mapped to by the wave mapper.</term>
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
		/// <term>Specified resource is already allocated.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_BADDEVICEID</term>
		/// <term>Specified device identifier is out of range.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// <item>
		/// <term>WAVERR_BADFORMAT</term>
		/// <term>Attempted to open with an unsupported waveform-audio format.</term>
		/// </item>
		/// <item>
		/// <term>WAVERR_SYNC</term>
		/// <term>The device is synchronous but waveOutOpen was called without using the WAVE_ALLOWSYNC flag.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Use the waveOutGetNumDevs function to determine the number of waveform-audio output devices present in the system. If the value
		/// specified by the uDeviceID parameter is a device identifier, it can vary from zero to one less than the number of devices
		/// present. The <c>WAVE_MAPPER</c> constant can also be used as a device identifier.
		/// </para>
		/// <para>
		/// The structure pointed to by pwfx can be extended to include type-specific information for certain data formats. For example, for
		/// PCM data, an extra <c>UINT</c> is added to specify the number of bits per sample. Use the PCMWAVEFORMAT structure in this case.
		/// For all other waveform-audio formats, use the WAVEFORMATEX structure to specify the length of the additional data.
		/// </para>
		/// <para>
		/// If you choose to have a window or thread receive callback information, the following messages are sent to the window procedure
		/// function to indicate the progress of waveform-audio output: MM_WOM_OPEN, MM_WOM_CLOSE, and MM_WOM_DONE.
		/// </para>
		/// <para>Callback Mechanism</para>
		/// <para>The dwCallback and fdwOpen parameters specify how the application is notified about the progress of waveform-audio output.</para>
		/// <para>
		/// If fdwOpen contains the <c>CALLBACK_FUNCTION</c> flag, dwCallback is a pointer to a callback function. For the function
		/// signature, see waveOutProc. The uMsg parameter of the callback indicates the progress of the audio output:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>WOM_OPEN</term>
		/// </item>
		/// <item>
		/// <term>WOM_CLOSE</term>
		/// </item>
		/// <item>
		/// <term>WOM_DONE</term>
		/// </item>
		/// </list>
		/// <para>
		/// If fdwOpen contains the <c>CALLBACK_WINDOW</c> flag, dwCallback is a handle to a window.The window receives the following
		/// messages, indicating the progress:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>MM_WOM_OPEN</term>
		/// </item>
		/// <item>
		/// <term>MM_WOM_CLOSE</term>
		/// </item>
		/// <item>
		/// <term>MM_WOM_DONE</term>
		/// </item>
		/// </list>
		/// <para>
		/// If fdwOpen contains the <c>CALLBACK_THREAD</c> flag, dwCallback is a thread identifier. The thread receives the messages listed
		/// previously for <c>CALLBACK_WINDOW</c>.
		/// </para>
		/// <para>
		/// If fdwOpen contains the <c>CALLBACK_EVENT</c> flag, dwCallback is a handle to an event. The event is signaled whenever the state
		/// of the waveform buffer changes. The application can use WaitForSingleObject or WaitForMultipleObjects to wait for the event.
		/// When the event is signaled, you can get the current state of the waveform buffer by checking the <c>dwFlags</c> member of the
		/// WAVEHDR structure. (See waveOutPrepareHeader.)
		/// </para>
		/// <para>
		/// If fdwOpen contains the <c>CALLBACK_NULL</c> flag, dwCallback must be <c>NULL</c>. In that case, no callback mechanism is used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutopen MMRESULT waveOutOpen( LPHWAVEOUT phwo, UINT
		// uDeviceID, LPCWAVEFORMATEX pwfx, DWORD_PTR dwCallback, DWORD_PTR dwInstance, DWORD fdwOpen );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutOpen")]
		public static extern MMRESULT waveOutOpen(out SafeHWAVEOUT phwo, uint uDeviceID, in WAVEFORMATEX pwfx, [In, Optional] IntPtr dwCallback, [In, Optional] IntPtr dwInstance, [In, Optional] WAVE_OPEN fdwOpen);

		/// <summary>
		/// The <c>waveOutPause</c> function pauses playback on the given waveform-audio output device. The current position is saved. Use
		/// the waveOutRestart function to resume playback from the current position.
		/// </summary>
		/// <param name="hwo">Handle to the waveform-audio output device.</param>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOTSUPPORTED</term>
		/// <term>Specified device is synchronous and does not support pausing.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>Calling this function when the output is already paused has no effect, and the function returns zero.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutpause MMRESULT waveOutPause( HWAVEOUT hwo );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutPause")]
		public static extern MMRESULT waveOutPause(HWAVEOUT hwo);

		/// <summary>The <c>waveOutPrepareHeader</c> function prepares a waveform-audio data block for playback.</summary>
		/// <param name="hwo">Handle to the waveform-audio output device.</param>
		/// <param name="pwh">Pointer to a WAVEHDR structure that identifies the data block to be prepared.</param>
		/// <param name="cbwh">Size, in bytes, of the WAVEHDR structure.</param>
		/// <returns>
		/// <para>Returns <c>MMSYSERR_NOERROR</c> if successful or an error otherwise. Possible error values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MMSYSERR_INVALHANDLE</term>
		/// <term>Specified device handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Set the <c>lpData</c>, <c>dwBufferLength</c>, and <c>dwFlags</c> members of the WAVEHDR structure before calling this function.
		/// Set the <c>dwFlags</c> member to zero.
		/// </para>
		/// <para>
		/// The <c>dwFlags</c>, <c>dwBufferLength</c>, and <c>dwLoops</c> members of the WAVEHDR structure can change between calls to this
		/// function and the waveOutWrite function. If you change the size specified by <c>dwBufferLength</c> before the call to
		/// <c>waveOutWrite</c>, the new value must be less than the prepared value.
		/// </para>
		/// <para>If the method succeeds, the <c>WHDR_PREPARED</c> flag is set in the <c>dwFlags</c> member of the WAVEHDR structure.</para>
		/// <para>Preparing a header that has already been prepared has no effect, and the function returns zero.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutprepareheader MMRESULT waveOutPrepareHeader( HWAVEOUT
		// hwo, LPWAVEHDR pwh, UINT cbwh );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutPrepareHeader")]
		public static extern MMRESULT waveOutPrepareHeader(HWAVEOUT hwo, ref WAVEHDR pwh, uint cbwh);

		/// <summary>
		/// The <c>waveOutReset</c> function stops playback on the given waveform-audio output device and resets the current position to
		/// zero. All pending playback buffers are marked as done (WHDR_DONE) and returned to the application.
		/// </summary>
		/// <param name="hwo">Handle to the waveform-audio output device.</param>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOTSUPPORTED</term>
		/// <term>Specified device is synchronous and does not support pausing.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// After this function returns, the application can send new playback buffers to the device by calling waveOutWrite, or close the
		/// device by calling waveOutClose.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutreset MMRESULT waveOutReset( HWAVEOUT hwo );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutReset")]
		public static extern MMRESULT waveOutReset(HWAVEOUT hwo);

		/// <summary>The <c>waveOutRestart</c> function resumes playback on a paused waveform-audio output device.</summary>
		/// <param name="hwo">Handle to the waveform-audio output device.</param>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOTSUPPORTED</term>
		/// <term>Specified device is synchronous and does not support pausing.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>Calling this function when the output is not paused has no effect, and the function returns zero.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutrestart MMRESULT waveOutRestart( HWAVEOUT hwo );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutRestart")]
		public static extern MMRESULT waveOutRestart(HWAVEOUT hwo);

		/// <summary>The <c>waveOutSetPitch</c> function sets the pitch for the specified waveform-audio output device.</summary>
		/// <param name="hwo">Handle to the waveform-audio output device.</param>
		/// <param name="dwPitch">
		/// <para>
		/// New pitch multiplier setting. This setting indicates the current change in pitch from the original authored setting. The pitch
		/// multiplier must be a positive value.
		/// </para>
		/// <para>
		/// The pitch multiplier is specified as a fixed-point value. The high-order word contains the signed integer part of the number,
		/// and the low-order word contains the fractional part. A value of 0x8000 in the low-order word represents one-half, and 0x4000
		/// represents one-quarter. For example, the value 0x00010000 specifies a multiplier of 1.0 (no pitch change), and a value of
		/// 0x000F8000 specifies a multiplier of 15.5.
		/// </para>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOTSUPPORTED</term>
		/// <term>Function isn't supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Changing the pitch does not change the playback rate or the sample rate, nor does it change the playback time. Not all devices
		/// support pitch changes. To determine whether the device supports pitch control, use the WAVECAPS_PITCH flag to test the
		/// <c>dwSupport</c> member of the <c>WAVEOUTCAPS</c> structure (filled by the <c>waveOutGetDevCaps</c> function).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutsetpitch MMRESULT waveOutSetPitch( HWAVEOUT hwo, DWORD
		// dwPitch );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutSetPitch")]
		public static extern MMRESULT waveOutSetPitch(HWAVEOUT hwo, uint dwPitch);

		/// <summary>The <c>waveOutSetPlaybackRate</c> function sets the playback rate for the specified waveform-audio output device.</summary>
		/// <param name="hwo">Handle to the waveform-audio output device.</param>
		/// <param name="dwRate">
		/// <para>
		/// New playback rate setting. This setting is a multiplier indicating the current change in playback rate from the original
		/// authored setting. The playback rate multiplier must be a positive value.
		/// </para>
		/// <para>
		/// The rate is specified as a fixed-point value. The high-order word contains the signed integer part of the number, and the
		/// low-order word contains the fractional part. A value of 0x8000 in the low-order word represents one-half, and 0x4000 represents
		/// one-quarter. For example, the value 0x00010000 specifies a multiplier of 1.0 (no playback rate change), and a value of
		/// 0x000F8000 specifies a multiplier of 15.5.
		/// </para>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOTSUPPORTED</term>
		/// <term>Function isn't supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Changing the playback rate does not change the sample rate but does change the playback time. Not all devices support playback
		/// rate changes. To determine whether a device supports playback rate changes, use the WAVECAPS_PLAYBACKRATE flag to test the
		/// <c>dwSupport</c> member of the <c>WAVEOUTCAPS</c> structure (filled by the <c>waveOutGetDevCaps</c> function).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutsetplaybackrate MMRESULT waveOutSetPlaybackRate(
		// HWAVEOUT hwo, DWORD dwRate );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutSetPlaybackRate")]
		public static extern MMRESULT waveOutSetPlaybackRate(HWAVEOUT hwo, uint dwRate);

		/// <summary>The <c>waveOutSetVolume</c> function sets the volume level of the specified waveform-audio output device.</summary>
		/// <param name="hwo">Handle to an open waveform-audio output device. This parameter can also be a device identifier.</param>
		/// <param name="dwVolume">
		/// <para>
		/// New volume setting. The low-order word contains the left-channel volume setting, and the high-order word contains the
		/// right-channel setting. A value of 0xFFFF represents full volume, and a value of 0x0000 is silence.
		/// </para>
		/// <para>
		/// If a device does not support both left and right volume control, the low-order word of dwVolume specifies the volume level, and
		/// the high-order word is ignored.
		/// </para>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOTSUPPORTED</term>
		/// <term>Function is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If a device identifier is used, then the result of the <c>waveOutSetVolume</c> call applies to all instances of the device. If a
		/// device handle is used, then the result applies only to the instance of the device referenced by the device handle.
		/// </para>
		/// <para>
		/// Not all devices support volume changes. To determine whether the device supports volume control, use the WAVECAPS_VOLUME flag to
		/// test the <c>dwSupport</c> member of the WAVEOUTCAPS structure (filled by the waveOutGetDevCaps function). To determine whether
		/// the device supports volume control on both the left and right channels, use the WAVECAPS_LRVOLUME flag.
		/// </para>
		/// <para>
		/// Most devices do not support the full 16 bits of volume-level control and will not use the least-significant bits of the
		/// requested volume setting. For example, if a device supports 4 bits of volume control, the values 0x4000, 0x4FFF, and 0x43BE will
		/// all be truncated to 0x4000. The <c>waveOutGetVolume</c> function returns the full 16-bit setting set with <c>waveOutSetVolume</c>.
		/// </para>
		/// <para>
		/// Volume settings are interpreted logarithmically. This means the perceived increase in volume is the same when increasing the
		/// volume level from 0x5000 to 0x6000 as it is from 0x4000 to 0x5000.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutsetvolume MMRESULT waveOutSetVolume( HWAVEOUT hwo,
		// DWORD dwVolume );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutSetVolume")]
		public static extern MMRESULT waveOutSetVolume(HWAVEOUT hwo, uint dwVolume);

		/// <summary>
		/// The <c>waveOutUnprepareHeader</c> function cleans up the preparation performed by the waveOutPrepareHeader function. This
		/// function must be called after the device driver is finished with a data block. You must call this function before freeing the buffer.
		/// </summary>
		/// <param name="hwo">Handle to the waveform-audio output device.</param>
		/// <param name="pwh">Pointer to a WAVEHDR structure identifying the data block to be cleaned up.</param>
		/// <param name="cbwh">Size, in bytes, of the <c>WAVEHDR</c> structure.</param>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// <item>
		/// <term>WAVERR_STILLPLAYING</term>
		/// <term>The data block pointed to by the pwh parameter is still in the queue.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function complements <c>waveOutPrepareHeader</c>. You must call this function before freeing the buffer. After passing a
		/// buffer to the device driver with the <c>waveOutWrite</c> function, you must wait until the driver is finished with the buffer
		/// before calling <c>waveOutUnprepareHeader</c>.
		/// </para>
		/// <para>Unpreparing a buffer that has not been prepared has no effect, and the function returns zero.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutunprepareheader MMRESULT waveOutUnprepareHeader(
		// HWAVEOUT hwo, LPWAVEHDR pwh, UINT cbwh );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutUnprepareHeader")]
		public static extern MMRESULT waveOutUnprepareHeader(HWAVEOUT hwo, ref WAVEHDR pwh, uint cbwh);

		/// <summary>The <c>waveOutWrite</c> function sends a data block to the given waveform-audio output device.</summary>
		/// <param name="hwo">Handle to the waveform-audio output device.</param>
		/// <param name="pwh">Pointer to a WAVEHDR structure containing information about the data block.</param>
		/// <param name="cbwh">Size, in bytes, of the <c>WAVEHDR</c> structure.</param>
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
		/// <item>
		/// <term>MMSYSERR_NODRIVER</term>
		/// <term>No device driver is present.</term>
		/// </item>
		/// <item>
		/// <term>MMSYSERR_NOMEM</term>
		/// <term>Unable to allocate or lock memory.</term>
		/// </item>
		/// <item>
		/// <term>WAVERR_UNPREPARED</term>
		/// <term>The data block pointed to by the pwh parameter hasn't been prepared.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>When the buffer is finished, the WHDR_DONE bit is set in the <c>dwFlags</c> member of the <c>WAVEHDR</c> structure.</para>
		/// <para>
		/// The buffer must be prepared with the <c>waveOutPrepareHeader</c> function before it is passed to <c>waveOutWrite</c>. Unless the
		/// device is paused by calling the <c>waveOutPause</c> function, playback begins when the first data block is sent to the device.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-waveoutwrite MMRESULT waveOutWrite( HWAVEOUT hwo, LPWAVEHDR
		// pwh, UINT cbwh );
		[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.waveOutWrite")]
		public static extern MMRESULT waveOutWrite(HWAVEOUT hwo, ref WAVEHDR pwh, uint cbwh);

		/// <summary>The <c>AUXCAPS</c> structure describes the capabilities of an auxiliary output device.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-auxcaps typedef struct auxcaps_tag { WORD wMid; WORD wPid;
		// VERSION vDriverVersion; char szPname[MAXPNAMELEN]; WORD wTechnology; DWORD dwSupport; } AUXCAPS, *PAUXCAPS, *NPAUXCAPS, *LPAUXCAPS;
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.auxcaps_tag")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct AUXCAPS
		{
			/// <summary>
			/// Manufacturer identifier for the device driver for the auxiliary audio device. Manufacturer identifiers are defined in
			/// Manufacturer and Product Identifiers.
			/// </summary>
			public ushort wMid;

			/// <summary>
			/// Product identifier for the auxiliary audio device. Currently, no product identifiers are defined for auxiliary audio devices.
			/// </summary>
			public ushort wPid;

			/// <summary>
			/// Version number of the device driver for the auxiliary audio device. The high-order byte is the major version number, and the
			/// low-order byte is the minor version number.
			/// </summary>
			public uint vDriverVersion;

			/// <summary>Product name in a null-terminated string.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string szPname;

			/// <summary>
			/// <para>Type of the auxiliary audio output:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>AUXCAPS_AUXIN</term>
			/// <term>Audio output from auxiliary input jacks.</term>
			/// </item>
			/// <item>
			/// <term>AUXCAPS_CDAUDIO</term>
			/// <term>Audio output from an internal CD-ROM drive.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ushort wTechnology;

			/// <summary>
			/// <para>Describes optional functionality supported by the auxiliary audio device.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>AUXCAPS_LRVOLUME</term>
			/// <term>Supports separate left and right volume control.</term>
			/// </item>
			/// <item>
			/// <term>AUXCAPS_VOLUME</term>
			/// <term>Supports volume control.</term>
			/// </item>
			/// </list>
			/// <para>
			/// If a device supports volume changes, the AUXCAPS_VOLUME flag will be set. If a device supports separate volume changes on
			/// the left and right channels, both AUXCAPS_VOLUME and the AUXCAPS_LRVOLUME will be set.
			/// </para>
			/// </summary>
			public AUX_CAPS dwSupport;
		}

		/// <summary>Provides a handle to a waveform-audio input device.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HWAVEIN : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HWAVEIN"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HWAVEIN(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HWAVEIN"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HWAVEIN NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HWAVEIN"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HWAVEIN h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HWAVEIN"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HWAVEIN(IntPtr h) => new(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HWAVEIN h1, HWAVEIN h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HWAVEIN h1, HWAVEIN h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HWAVEIN h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a waveform-audio output device.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HWAVEOUT : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HWAVEOUT"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HWAVEOUT(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HWAVEOUT"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HWAVEOUT NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HWAVEOUT"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HWAVEOUT h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HWAVEOUT"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HWAVEOUT(IntPtr h) => new(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HWAVEOUT h1, HWAVEOUT h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HWAVEOUT h1, HWAVEOUT h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HWAVEOUT h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>
		/// <para>
		/// The <c>WAVEFORMATEX</c> structure defines the format of waveform-audio data. Only format information common to all
		/// waveform-audio data formats is included in this structure. For formats that require additional information, this structure is
		/// included as the first member in another structure, along with the additional information.
		/// </para>
		/// <para>
		/// Formats that support more than two channels or sample sizes of more than 16 bits can be described in a WAVEFORMATEXTENSIBLE
		/// structure, which includes the WAVEFORMAT structure.
		/// </para>
		/// </summary>
		/// <remarks>
		/// An example of a format that uses extra information is the Microsoft Adaptive Delta Pulse Code Modulation (MS-ADPCM) format. The
		/// <c>wFormatTag</c> for MS-ADPCM is WAVE_FORMAT_ADPCM. The <c>cbSize</c> member will typically be set to 32. The extra information
		/// stored for WAVE_FORMAT_ADPCM is coefficient pairs required for encoding and decoding the waveform-audio data.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-waveformatex typedef struct tWAVEFORMATEX { WORD wFormatTag;
		// WORD nChannels; DWORD nSamplesPerSec; DWORD nAvgBytesPerSec; WORD nBlockAlign; WORD wBitsPerSample; WORD cbSize; } WAVEFORMATEX,
		// *PWAVEFORMATEX, *NPWAVEFORMATEX, *LPWAVEFORMATEX;
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.tWAVEFORMATEX")]
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		public struct WAVEFORMATEX
		{
			/// <summary>
			/// Waveform-audio format type. Format tags are registered with Microsoft Corporation for many compression algorithms. A
			/// complete list of format tags can be found in the Mmreg.h header file. For one- or two-channel PCM data, this value should be
			/// WAVE_FORMAT_PCM. When this structure is included in a WAVEFORMATEXTENSIBLE structure, this value must be WAVE_FORMAT_EXTENSIBLE.
			/// </summary>
			public WAVE_FORMAT wFormatTag;

			/// <summary>Number of channels in the waveform-audio data. Monaural data uses one channel and stereo data uses two channels.</summary>
			public ushort nChannels;

			/// <summary>
			/// Sample rate, in samples per second (hertz). If <c>wFormatTag</c> is WAVE_FORMAT_PCM, then common values for
			/// <c>nSamplesPerSec</c> are 8.0 kHz, 11.025 kHz, 22.05 kHz, and 44.1 kHz. For non-PCM formats, this member must be computed
			/// according to the manufacturer's specification of the format tag.
			/// </summary>
			public uint nSamplesPerSec;

			/// <summary>
			/// Required average data-transfer rate, in bytes per second, for the format tag. If <c>wFormatTag</c> is WAVE_FORMAT_PCM,
			/// <c>nAvgBytesPerSec</c> should be equal to the product of <c>nSamplesPerSec</c> and <c>nBlockAlign</c>. For non-PCM formats,
			/// this member must be computed according to the manufacturer's specification of the format tag.
			/// </summary>
			public uint nAvgBytesPerSec;

			/// <summary>
			/// <para>
			/// Block alignment, in bytes. The block alignment is the minimum atomic unit of data for the <c>wFormatTag</c> format type. If
			/// <c>wFormatTag</c> is WAVE_FORMAT_PCM or WAVE_FORMAT_EXTENSIBLE, <c>nBlockAlign</c> must be equal to the product of
			/// <c>nChannels</c> and <c>wBitsPerSample</c> divided by 8 (bits per byte). For non-PCM formats, this member must be computed
			/// according to the manufacturer's specification of the format tag.
			/// </para>
			/// <para>
			/// Software must process a multiple of <c>nBlockAlign</c> bytes of data at a time. Data written to and read from a device must
			/// always start at the beginning of a block. For example, it is illegal to start playback of PCM data in the middle of a sample
			/// (that is, on a non-block-aligned boundary).
			/// </para>
			/// </summary>
			public ushort nBlockAlign;

			/// <summary>
			/// Bits per sample for the <c>wFormatTag</c> format type. If <c>wFormatTag</c> is WAVE_FORMAT_PCM, then <c>wBitsPerSample</c>
			/// should be equal to 8 or 16. For non-PCM formats, this member must be set according to the manufacturer's specification of
			/// the format tag. If <c>wFormatTag</c> is WAVE_FORMAT_EXTENSIBLE, this value can be any integer multiple of 8 and represents
			/// the container size, not necessarily the sample size; for example, a 20-bit sample size is in a 24-bit container. Some
			/// compression schemes cannot define a value for <c>wBitsPerSample</c>, so this member can be 0.
			/// </summary>
			public ushort wBitsPerSample;

			/// <summary>
			/// Size, in bytes, of extra format information appended to the end of the <c>WAVEFORMATEX</c> structure. This information can
			/// be used by non-PCM formats to store extra attributes for the <c>wFormatTag</c>. If no extra information is required by the
			/// <c>wFormatTag</c>, this member must be set to 0. For WAVE_FORMAT_PCM formats (and only WAVE_FORMAT_PCM formats), this member
			/// is ignored. When this structure is included in a WAVEFORMATEXTENSIBLE structure, this value must be at least 22.
			/// </summary>
			public ushort cbSize;
		}

		/// <summary>
		/// The <c>WAVEFORMATEXTENSIBLE</c> structure defines the format of waveform-audio data for formats having more than two channels or
		/// higher sample resolutions than allowed by WAVEFORMATEX. It can also be used to define any format that can be defined by <c>WAVEFORMATEX</c>.
		/// </summary>
		/// <remarks>
		/// <para>
		/// <c>WAVEFORMATEXTENSIBLE</c> can describe any format that can be described by WAVEFORMATEX, but provides additional support for
		/// more than two channels, for greater precision in the number of bits per sample, and for new compression schemes.
		/// </para>
		/// <para>
		/// <c>WAVEFORMATEXTENSIBLE</c> can safely be cast to <c>WAVEFORMATEX</c>, because it simply configures the extra bytes specified by <c>WAVEFORMATEX.cbSize</c>.
		/// </para>
		/// <para>
		/// The <c>dwChannelMask</c> member specifies which channels are present in the multichannel stream. The least significant bit
		/// corresponds with the front left speaker, the next least significant bit corresponds to the front right speaker, and so on. The
		/// bits, in order of significance, are defined as follows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Speaker position</term>
		/// <term>Flag bit</term>
		/// </listheader>
		/// <item>
		/// <term>SPEAKER_FRONT_LEFT</term>
		/// <term>0x1</term>
		/// </item>
		/// <item>
		/// <term>SPEAKER_FRONT_RIGHT</term>
		/// <term>0x2</term>
		/// </item>
		/// <item>
		/// <term>SPEAKER_FRONT_CENTER</term>
		/// <term>0x4</term>
		/// </item>
		/// <item>
		/// <term>SPEAKER_LOW_FREQUENCY</term>
		/// <term>0x8</term>
		/// </item>
		/// <item>
		/// <term>SPEAKER_BACK_LEFT</term>
		/// <term>0x10</term>
		/// </item>
		/// <item>
		/// <term>SPEAKER_BACK_RIGHT</term>
		/// <term>0x20</term>
		/// </item>
		/// <item>
		/// <term>SPEAKER_FRONT_LEFT_OF_CENTER</term>
		/// <term>0x40</term>
		/// </item>
		/// <item>
		/// <term>SPEAKER_FRONT_RIGHT_OF_CENTER</term>
		/// <term>0x80</term>
		/// </item>
		/// <item>
		/// <term>SPEAKER_BACK_CENTER</term>
		/// <term>0x100</term>
		/// </item>
		/// <item>
		/// <term>SPEAKER_SIDE_LEFT</term>
		/// <term>0x200</term>
		/// </item>
		/// <item>
		/// <term>SPEAKER_SIDE_RIGHT</term>
		/// <term>0x400</term>
		/// </item>
		/// <item>
		/// <term>SPEAKER_TOP_CENTER</term>
		/// <term>0x800</term>
		/// </item>
		/// <item>
		/// <term>SPEAKER_TOP_FRONT_LEFT</term>
		/// <term>0x1000</term>
		/// </item>
		/// <item>
		/// <term>SPEAKER_TOP_FRONT_CENTER</term>
		/// <term>0x2000</term>
		/// </item>
		/// <item>
		/// <term>SPEAKER_TOP_FRONT_RIGHT</term>
		/// <term>0x4000</term>
		/// </item>
		/// <item>
		/// <term>SPEAKER_TOP_BACK_LEFT</term>
		/// <term>0x8000</term>
		/// </item>
		/// <item>
		/// <term>SPEAKER_TOP_BACK_CENTER</term>
		/// <term>0x10000</term>
		/// </item>
		/// <item>
		/// <term>SPEAKER_TOP_BACK_RIGHT</term>
		/// <term>0x20000</term>
		/// </item>
		/// </list>
		/// <para>
		/// The channels specified in <c>dwChannelMask</c> must be present in the prescribed order (from least significant bit up). For
		/// example, if only SPEAKER_FRONT_LEFT and SPEAKER_FRONT_RIGHT are specified, then the samples for the front left speaker must come
		/// first in the interleaved stream. The number of bits set in <c>dwChannelMask</c> should be the same as the number of channels
		/// specified in <c>WAVEFORMATEX.nChannels</c>.
		/// </para>
		/// <para>
		/// For backward compatibility, any wave format that can be specified by a stand-alone WAVEFORMATEX structure can also be defined by
		/// a <c>WAVEFORMATEXTENSIBLE</c> structure. Thus, every wave-format tag in mmreg.h has a corresponding <c>SubFormat</c> GUID. The
		/// following table shows some typical wave-format tags and their corresponding <c>SubFormat</c> GUIDs. These GUIDs are defined in Ksmedia.h.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Wave-Format Tag</term>
		/// <term>SubFormat GUID</term>
		/// </listheader>
		/// <item>
		/// <term>WAVE_FORMAT_PCM</term>
		/// <term>KSDATAFORMAT_SUBTYPE_PCM</term>
		/// </item>
		/// <item>
		/// <term>WAVE_FORMAT_IEEE_FLOAT</term>
		/// <term>KSDATAFORMAT_SUBTYPE_IEEE_FLOAT</term>
		/// </item>
		/// <item>
		/// <term>WAVE_FORMAT_DRM</term>
		/// <term>KSDATAFORMAT_SUBTYPE_DRM</term>
		/// </item>
		/// <item>
		/// <term>WAVE_FORMAT_ALAW</term>
		/// <term>KSDATAFORMAT_SUBTYPE_ALAW</term>
		/// </item>
		/// <item>
		/// <term>WAVE_FORMAT_MULAW</term>
		/// <term>KSDATAFORMAT_SUBTYPE_MULAW</term>
		/// </item>
		/// <item>
		/// <term>WAVE_FORMAT_ADPCM</term>
		/// <term>KSDATAFORMAT_SUBTYPE_ADPCM</term>
		/// </item>
		/// </list>
		/// <para>
		/// Because <c>WAVEFORMATEXTENSIBLE</c> is an extended version of WAVEFORMATEX, it can describe additional formats that cannot be
		/// described by <c>WAVEFORMATEX</c> alone. Vendors are free to define their own <c>SubFormat</c> GUIDs to identify proprietary
		/// formats for which no wave-format tags exist.
		/// </para>
		/// <para>The following structures, for particular extended formats, are defined as <c>WAVEFORMATEXTENSIBLE</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Definition</term>
		/// <term>Value of SubFormat</term>
		/// </listheader>
		/// <item>
		/// <term>WAVEFORMATIEEEFLOATEX</term>
		/// <term>KSDATAFORMAT_SUBTYPE_IEEE_FLOAT</term>
		/// </item>
		/// <item>
		/// <term>WAVEFORMATPCMEX</term>
		/// <term>KSDATAFORMAT_SUBTYPE_PCM</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmreg/ns-mmreg-waveformatextensible typedef struct { WAVEFORMATEX Format;
		// union { WORD wValidBitsPerSample; WORD wSamplesPerBlock; WORD wReserved; } Samples; DWORD dwChannelMask; GUID SubFormat; }
		// WAVEFORMATEXTENSIBLE, *PWAVEFORMATEXTENSIBLE;
		[PInvokeData("mmreg.h", MSDNShortId = "NS:mmreg.__unnamed_struct_0")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct WAVEFORMATEXTENSIBLE
		{
			/// <summary>
			/// WAVEFORMATEX structure that specifies the basic format. The <c>wFormatTag</c> member must be WAVE_FORMAT_EXTENSIBLE. The
			/// <c>cbSize</c> member must be at least 22.
			/// </summary>
			public WAVEFORMATEX Format;

			/// <summary>A union describing the sample format.</summary>
			public SAMPLES Samples;

			/// <summary>Bitmask specifying the assignment of channels in the stream to speaker positions.</summary>
			public uint dwChannelMask;

			/// <summary>
			/// Subformat of the data, such as KSDATAFORMAT_SUBTYPE_PCM. The subformat information is similar to that provided by the tag in
			/// the WAVEFORMATEX structure's <c>wFormatTag</c> member.
			/// </summary>
			public Guid SubFormat;

			/// <summary>A union describing the sample format.</summary>
			[StructLayout(LayoutKind.Explicit)]
			public struct SAMPLES
			{
				/// <summary>
				/// Number of bits of precision in the signal. Usually equal to <c>WAVEFORMATEX.wBitsPerSample</c>. However,
				/// <c>wBitsPerSample</c> is the container size and must be a multiple of 8, whereas <c>wValidBitsPerSample</c> can be any
				/// value not exceeding the container size. For example, if the format uses 20-bit samples, <c>wBitsPerSample</c> must be at
				/// least 24, but <c>wValidBitsPerSample</c> is 20.
				/// </summary>
				[FieldOffset(0)]
				public ushort wValidBitsPerSample;

				/// <summary>
				/// Number of samples contained in one compressed block of audio data. This value is used in buffer estimation. This value
				/// is used with compressed formats that have a fixed number of samples within each block. This value can be set to 0 if a
				/// variable number of samples is contained in each block of compressed audio data. In this case, buffer estimation and
				/// position information needs to be obtained in other ways.
				/// </summary>
				[FieldOffset(0)]
				public ushort wSamplesPerBlock;

				/// <summary>Reserved for internal use by operating system. Set to 0.</summary>
				[FieldOffset(0)]
				public ushort wReserved;
			}
		}

		/// <summary>The <c>WAVEHDR</c> structure defines the header used to identify a waveform-audio buffer.</summary>
		/// <remarks>
		/// <para>
		/// Use the WHDR_BEGINLOOP and WHDR_ENDLOOP flags in the <c>dwFlags</c> member to specify the beginning and ending data blocks for
		/// looping. To loop on a single block, specify both flags for the same block. Use the <c>dwLoops</c> member in the <c>WAVEHDR</c>
		/// structure for the first block in the loop to specify the number of times to play the loop.
		/// </para>
		/// <para>
		/// The <c>lpData</c>, <c>dwBufferLength</c>, and <c>dwFlags</c> members must be set before calling the waveInPrepareHeader or
		/// waveOutPrepareHeader function. (For either function, the <c>dwFlags</c> member must be set to zero.)
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-wavehdr typedef struct wavehdr_tag { LPSTR lpData; DWORD
		// dwBufferLength; DWORD dwBytesRecorded; DWORD_PTR dwUser; DWORD dwFlags; DWORD dwLoops; struct wavehdr_tag *lpNext; DWORD_PTR
		// reserved; } WAVEHDR, *PWAVEHDR, *NPWAVEHDR, *LPWAVEHDR;
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.wavehdr_tag")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WAVEHDR
		{
			/// <summary>Pointer to the waveform buffer.</summary>
			public IntPtr lpData;

			/// <summary>Length, in bytes, of the buffer.</summary>
			public uint dwBufferLength;

			/// <summary>When the header is used in input, specifies how much data is in the buffer.</summary>
			public uint dwBytesRecorded;

			/// <summary>User data.</summary>
			public IntPtr dwUser;

			/// <summary>
			/// <para>A bitwise <c>OR</c> of zero of more flags. The following flags are defined:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>WHDR_BEGINLOOP</term>
			/// <term>This buffer is the first buffer in a loop. This flag is used only with output buffers.</term>
			/// </item>
			/// <item>
			/// <term>WHDR_DONE</term>
			/// <term>Set by the device driver to indicate that it is finished with the buffer and is returning it to the application.</term>
			/// </item>
			/// <item>
			/// <term>WHDR_ENDLOOP</term>
			/// <term>This buffer is the last buffer in a loop. This flag is used only with output buffers.</term>
			/// </item>
			/// <item>
			/// <term>WHDR_INQUEUE</term>
			/// <term>Set by Windows to indicate that the buffer is queued for playback.</term>
			/// </item>
			/// <item>
			/// <term>WHDR_PREPARED</term>
			/// <term>
			/// Set by Windows to indicate that the buffer has been prepared with the waveInPrepareHeader or waveOutPrepareHeader function.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public WHDR dwFlags;

			/// <summary>Number of times to play the loop. This member is used only with output buffers.</summary>
			public uint dwLoops;

			/// <summary>Reserved.</summary>
			public IntPtr lpNext;

			/// <summary>Reserved.</summary>
			public IntPtr reserved;
		}

		/// <summary>The <c>WAVEINCAPS</c> structure describes the capabilities of a waveform-audio input device.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-waveincaps typedef struct waveincaps_tag { WORD wMid; WORD
		// wPid; VERSION vDriverVersion; char szPname[MAXPNAMELEN]; DWORD dwFormats; WORD wChannels; } WAVEINCAPS, *PWAVEINCAPS,
		// *NPWAVEINCAPS, *LPWAVEINCAPS;
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.waveincaps_tag")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WAVEINCAPS
		{
			/// <summary>
			/// Manufacturer identifier for the device driver for the waveform-audio input device. Manufacturer identifiers are defined in
			/// Manufacturer and Product Identifiers.
			/// </summary>
			public ushort wMid;

			/// <summary>
			/// Product identifier for the waveform-audio input device. Product identifiers are defined in Manufacturer and Product Identifiers.
			/// </summary>
			public ushort wPid;

			/// <summary>
			/// Version number of the device driver for the waveform-audio input device. The high-order byte is the major version number,
			/// and the low-order byte is the minor version number.
			/// </summary>
			public uint vDriverVersion;

			/// <summary>Product name in a null-terminated string.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string szPname;

			/// <summary>
			/// <para>Standard formats that are supported. Can be a combination of the following:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Format</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>WAVE_FORMAT_1M08</term>
			/// <term>11.025 kHz, mono, 8-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_1M16</term>
			/// <term>11.025 kHz, mono, 16-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_1S08</term>
			/// <term>11.025 kHz, stereo, 8-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_1S16</term>
			/// <term>11.025 kHz, stereo, 16-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_2M08</term>
			/// <term>22.05 kHz, mono, 8-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_2M16</term>
			/// <term>22.05 kHz, mono, 16-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_2S08</term>
			/// <term>22.05 kHz, stereo, 8-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_2S16</term>
			/// <term>22.05 kHz, stereo, 16-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_4M08</term>
			/// <term>44.1 kHz, mono, 8-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_4M16</term>
			/// <term>44.1 kHz, mono, 16-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_4S08</term>
			/// <term>44.1 kHz, stereo, 8-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_4S16</term>
			/// <term>44.1 kHz, stereo, 16-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_96M08</term>
			/// <term>96 kHz, mono, 8-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_96M16</term>
			/// <term>96 kHz, mono, 16-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_96S08</term>
			/// <term>96 kHz, stereo, 8-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_96S16</term>
			/// <term>96 kHz, stereo, 16-bit</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint dwFormats;

			/// <summary>Number specifying whether the device supports mono (1) or stereo (2) input.</summary>
			public ushort wChannels;
		}

		/// <summary>The <c>WAVEOUTCAPS</c> structure describes the capabilities of a waveform-audio output device.</summary>
		/// <remarks>
		/// If a device supports volume changes, the WAVECAPS_VOLUME flag will be set for the <c>dwSupport</c> member. If a device supports
		/// separate volume changes on the left and right channels, both the WAVECAPS_VOLUME and the WAVECAPS_LRVOLUME flags will be set for
		/// this member.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-waveoutcaps typedef struct waveoutcaps_tag { WORD wMid; WORD
		// wPid; VERSION vDriverVersion; char szPname[MAXPNAMELEN]; DWORD dwFormats; WORD wChannels; DWORD dwSupport; } WAVEOUTCAPS,
		// *PWAVEOUTCAPS, *NPWAVEOUTCAPS, *LPWAVEOUTCAPS;
		[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.waveoutcaps_tag")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WAVEOUTCAPS
		{
			/// <summary>
			/// Manufacturer identifier for the device driver for the device. Manufacturer identifiers are defined in Manufacturer and
			/// Product Identifiers.
			/// </summary>
			public ushort wMid;

			/// <summary>Product identifier for the device. Product identifiers are defined in Manufacturer and Product Identifiers.</summary>
			public ushort wPid;

			/// <summary>
			/// Version number of the device driver for the device. The high-order byte is the major version number, and the low-order byte
			/// is the minor version number.
			/// </summary>
			public uint vDriverVersion;

			/// <summary>Product name in a null-terminated string.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string szPname;

			/// <summary>
			/// <para>Standard formats that are supported. Can be a combination of the following:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Format</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>WAVE_FORMAT_1M08</term>
			/// <term>11.025 kHz, mono, 8-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_1M16</term>
			/// <term>11.025 kHz, mono, 16-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_1S08</term>
			/// <term>11.025 kHz, stereo, 8-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_1S16</term>
			/// <term>11.025 kHz, stereo, 16-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_2M08</term>
			/// <term>22.05 kHz, mono, 8-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_2M16</term>
			/// <term>22.05 kHz, mono, 16-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_2S08</term>
			/// <term>22.05 kHz, stereo, 8-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_2S16</term>
			/// <term>22.05 kHz, stereo, 16-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_4M08</term>
			/// <term>44.1 kHz, mono, 8-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_4M16</term>
			/// <term>44.1 kHz, mono, 16-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_4S08</term>
			/// <term>44.1 kHz, stereo, 8-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_4S16</term>
			/// <term>44.1 kHz, stereo, 16-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_96M08</term>
			/// <term>96 kHz, mono, 8-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_96M16</term>
			/// <term>96 kHz, mono, 16-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_96S08</term>
			/// <term>96 kHz, stereo, 8-bit</term>
			/// </item>
			/// <item>
			/// <term>WAVE_FORMAT_96S16</term>
			/// <term>96 kHz, stereo, 16-bit</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint dwFormats;

			/// <summary>Number specifying whether the device supports mono (1) or stereo (2) output.</summary>
			public ushort wChannels;

			/// <summary>
			/// <para>Optional functionality supported by the device. The following values are defined:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Flag</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>WAVECAPS_LRVOLUME</term>
			/// <term>Supports separate left and right volume control.</term>
			/// </item>
			/// <item>
			/// <term>WAVECAPS_PITCH</term>
			/// <term>Supports pitch control.</term>
			/// </item>
			/// <item>
			/// <term>WAVECAPS_PLAYBACKRATE</term>
			/// <term>Supports playback rate control.</term>
			/// </item>
			/// <item>
			/// <term>WAVECAPS_SYNC</term>
			/// <term>The driver is synchronous and will block while playing a buffer.</term>
			/// </item>
			/// <item>
			/// <term>WAVECAPS_VOLUME</term>
			/// <term>Supports volume control.</term>
			/// </item>
			/// <item>
			/// <term>WAVECAPS_SAMPLEACCURATE</term>
			/// <term>Returns sample-accurate position information.</term>
			/// </item>
			/// </list>
			/// </summary>
			public WAVECAPS dwSupport;
		}

		/// <summary>The <c>MMTIME</c> structure contains timing information for different types of multimedia data.</summary>
		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HWAVEIN"/> that is disposed using <see cref="waveInClose"/>.</summary>
		public class SafeHWAVEIN : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHWAVEIN"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHWAVEIN(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHWAVEIN"/> class.</summary>
			private SafeHWAVEIN() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHWAVEIN"/> to <see cref="HWAVEIN"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HWAVEIN(SafeHWAVEIN h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => waveInClose(handle) == MMRESULT.MMSYSERR_NOERROR;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HWAVEOUT"/> that is disposed using <see cref="waveOutClose"/>.</summary>
		public class SafeHWAVEOUT : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHWAVEOUT"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHWAVEOUT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHWAVEOUT"/> class.</summary>
			private SafeHWAVEOUT() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHWAVEOUT"/> to <see cref="HWAVEOUT"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HWAVEOUT(SafeHWAVEOUT h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => waveOutClose(handle) == MMRESULT.MMSYSERR_NOERROR;
		}

		/*
		MM_WIM_CLOSE
		MM_WIM_DATA
		MM_WIM_OPEN
		MM_WOM_CLOSE
		MM_WOM_DONE
		MM_WOM_OPEN
		WIM_CLOSE
		WIM_DATA
		WIM_OPEN
		WOM_CLOSE
		WOM_DONE
		WOM_OPEN

		 MEVT_EVENTPARM
MEVT_EVENTTYPE
midiConnect
midiDisconnect
midiInAddBuffer
midiInClose
midiInGetDevCaps
midiInGetDevCapsA
midiInGetDevCapsW
midiInGetErrorText
midiInGetErrorTextA
midiInGetErrorTextW
midiInGetID
midiInGetNumDevs
midiInMessage
midiInOpen
midiInPrepareHeader
midiInReset
midiInStart
midiInStop
midiInUnprepareHeader
midiOutCacheDrumPatches
midiOutCachePatches
midiOutClose
midiOutGetDevCaps
midiOutGetDevCapsA
midiOutGetDevCapsW
midiOutGetErrorText
midiOutGetErrorTextA
midiOutGetErrorTextW
midiOutGetID
midiOutGetNumDevs
midiOutGetVolume
midiOutLongMsg
midiOutMessage
midiOutOpen
midiOutPrepareHeader
midiOutReset
midiOutSetVolume
midiOutShortMsg
midiOutUnprepareHeader
midiStreamClose
midiStreamOpen
midiStreamOut
midiStreamPause
midiStreamPosition
midiStreamProperty
midiStreamRestart
midiStreamStop
mixerClose
mixerGetControlDetails
mixerGetControlDetailsA
mixerGetControlDetailsW
mixerGetDevCaps
mixerGetDevCapsA
mixerGetDevCapsW
mixerGetID
mixerGetLineControls
mixerGetLineControlsA
mixerGetLineControlsW
mixerGetLineInfo
mixerGetLineInfoA
mixerGetLineInfoW
mixerGetNumDevs
mixerMessage
mixerOpen
mixerSetControlDetails
*/
	}
}