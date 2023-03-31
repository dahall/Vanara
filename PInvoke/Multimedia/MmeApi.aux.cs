#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke;

/// <summary>Items from the WinMm.dll</summary>
public static partial class WinMm
{
	private const string Lib_Winmm = "winmm.dll";

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

	*/
}