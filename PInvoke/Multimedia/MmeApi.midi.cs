namespace Vanara.PInvoke;

/// <summary>Items from the WinMm.dll</summary>
public static partial class WinMm
{
	/// <summary/>
	public const int MIDIPATCHSIZE = 128;

	/// <summary>Flags giving information about the buffer.</summary>
	[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.midihdr_tag")]
	[Flags]
	public enum MHDR : uint
	{
		/// <summary>Set by the device driver to indicate that it is finished with the buffer and is returning it to the application.</summary>
		MHDR_DONE = 0x00000001,

		/// <summary>
		/// Set by Windows to indicate that the buffer has been prepared by using the midiInPrepareHeader or midiOutPrepareHeader function.
		/// </summary>
		MHDR_PREPARED = 0x00000002,

		/// <summary>Set by Windows to indicate that the buffer is queued for playback.</summary>
		MHDR_INQUEUE = 0x00000004,

		/// <summary>Set to indicate that the buffer is a stream buffer.</summary>
		MHDR_ISSTRM = 0x00000008,
	}

	/// <summary>Options for the cache operation.</summary>
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiOutCacheDrumPatches")]
	public enum MIDI_CACHE
	{
		/// <summary>
		/// Caches all of the specified patches. If they cannot all be cached, it caches none, clears the KEYARRAY array, and returns MMSYSERR_NOMEM.
		/// </summary>
		MIDI_CACHE_ALL = 1,

		/// <summary>
		/// Caches all of the specified patches. If they cannot all be cached, it caches as many patches as possible, changes the
		/// KEYARRAY array to reflect which patches were cached, and returns MMSYSERR_NOMEM.
		/// </summary>
		MIDI_CACHE_BESTFIT = 2,

		/// <summary>Changes the KEYARRAY array to indicate which patches are currently cached.</summary>
		MIDI_CACHE_QUERY = 3,

		/// <summary>Uncaches the specified patches and clears the KEYARRAY array.</summary>
		MIDI_UNCACHE = 4,
	}

	/// <summary>Optional functionality supported by the device.</summary>
	[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.tagMIDIOUTCAPSW")]
	[Flags]
	public enum MIDI_CAPS : uint
	{
		/// <summary>Supports volume control.</summary>
		MIDICAPS_VOLUME = 0x0001,

		/// <summary>Supports separate left and right volume control.</summary>
		MIDICAPS_LRVOLUME = 0x0002,

		/// <summary>Supports patch caching.</summary>
		MIDICAPS_CACHE = 0x0004,

		/// <summary>Provides direct support for the midiStreamOut function.</summary>
		MIDICAPS_STREAM = 0x0008,
	}

	/// <summary>
	/// Flags that specify the action to perform and identify the appropriate property of the MIDI data stream. The
	/// <c>midiStreamProperty</c> function requires setting two flags in each use. One flag (either MIDIPROP_GET or MIDIPROP_SET)
	/// specifies an action, and the other identifies a specific property to examine or edit.
	/// </summary>
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiStreamProperty")]
	[Flags]
	public enum MIDIPROP : uint
	{
		/// <summary>Sets the given property.</summary>
		MIDIPROP_SET = 0x80000000,

		/// <summary>Retrieves the current setting of the given property.</summary>
		MIDIPROP_GET = 0x40000000,

		/// <summary>
		/// Specifies the time division property. You can get or set this property. The lppropdata parameter points to a MIDIPROPTIMEDIV
		/// structure. This property can be set only when the device is stopped.
		/// </summary>
		MIDIPROP_TIMEDIV = 0x00000001,

		/// <summary>
		/// Retrieves the tempo property. The lppropdata parameter points to a MIDIPROPTEMPO structure. The current tempo value can be
		/// retrieved at any time. Output devices set the tempo by inserting MEVT_TEMPO events into the MIDI data.
		/// </summary>
		MIDIPROP_TEMPO = 0x00000002,
	}

	/// <summary>Type of the MIDI output device.</summary>
	[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.tagMIDIOUTCAPSW")]
	public enum MOD : ushort
	{
		/// <summary>MIDI hardware port.</summary>
		MOD_MIDIPORT = 1,

		/// <summary>Synthesizer.</summary>
		MOD_SYNTH = 2,

		/// <summary>Square wave synthesizer.</summary>
		MOD_SQSYNTH = 3,

		/// <summary>FM synthesizer.</summary>
		MOD_FMSYNTH = 4,

		/// <summary>Microsoft MIDI mapper.</summary>
		MOD_MAPPER = 5,

		/// <summary>Hardware wavetable synthesizer.</summary>
		MOD_WAVETABLE = 6,

		/// <summary>Software synthesizer.</summary>
		MOD_SWSYNTH = 7,
	}

	/// <summary>
	/// The <c>midiConnect</c> function connects a MIDI input device to a MIDI thru or output device, or connects a MIDI thru device to
	/// a MIDI output device.
	/// </summary>
	/// <param name="hmi">
	/// Handle to a MIDI input device or a MIDI thru device. (For thru devices, this handle must have been returned by a call to the
	/// midiOutOpen function.)
	/// </param>
	/// <param name="hmo">Handle to the MIDI output or thru device.</param>
	/// <param name="pReserved">Reserved; must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MIDIERR_NOTREADY</term>
	/// <term>Specified input device is already connected to an output device.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALHANDLE</term>
	/// <term>Specified device handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// After calling this function, the MIDI input device receives event data in an MIM_DATA message whenever a message with the same
	/// event data is sent to the output device driver.
	/// </para>
	/// <para>
	/// A thru driver is a special form of MIDI output driver. The system will allow only one MIDI output device to be connected to a
	/// MIDI input device, but multiple MIDI output devices can be connected to a MIDI thru device. Whenever the given MIDI input device
	/// receives event data in an MIM_DATA message, a message with the same event data is sent to the given output device driver (or
	/// through the thru driver to the output drivers).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midiconnect MMRESULT midiConnect( HMIDI hmi, HMIDIOUT hmo,
	// LPVOID pReserved );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiConnect")]
	public static extern MMRESULT midiConnect([In] HMIDI hmi, [In] HMIDIOUT hmo, IntPtr pReserved = default);

	/// <summary>
	/// The <c>midiDisconnect</c> function disconnects a MIDI input device from a MIDI thru or output device, or disconnects a MIDI thru
	/// device from a MIDI output device.
	/// </summary>
	/// <param name="hmi">Handle to a MIDI input device or a MIDI thru device.</param>
	/// <param name="hmo">Handle to the MIDI output device to be disconnected.</param>
	/// <param name="pReserved">Reserved; must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following:.</para>
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
	/// <remarks>
	/// MIDI input, output, and thru devices can be connected by using the <c>midiConnect</c> function. Thereafter, whenever the MIDI
	/// input device receives event data in an MIM_DATA message, a message with the same event data is sent to the output device driver
	/// (or through the thru driver to the output drivers).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-mididisconnect MMRESULT midiDisconnect( HMIDI hmi, HMIDIOUT
	// hmo, LPVOID pReserved );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiDisconnect")]
	public static extern MMRESULT midiDisconnect([In] HMIDI hmi, [In] HMIDIOUT hmo, IntPtr pReserved = default);

	/// <summary>
	/// The <c>midiInAddBuffer</c> function sends an input buffer to a specified opened MIDI input device. This function is used for
	/// system-exclusive messages.
	/// </summary>
	/// <param name="hmi">Handle to the MIDI input device.</param>
	/// <param name="pmh">Pointer to a MIDIHDR structure that identifies the buffer.</param>
	/// <param name="cbmh">Size, in bytes, of the MIDIHDR structure.</param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MIDIERR_STILLPLAYING</term>
	/// <term>The buffer pointed to by lpMidiInHdr is still in the queue.</term>
	/// </item>
	/// <item>
	/// <term>MIDIERR_UNPREPARED</term>
	/// <term>The buffer pointed to by lpMidiInHdr has not been prepared.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALHANDLE</term>
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALPARAM</term>
	/// <term>The specified pointer or structure is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOMEM</term>
	/// <term>The system is unable to allocate or lock memory.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>When the buffer is filled, it is sent back to the application.</para>
	/// <para>
	/// The buffer must be prepared by using the midiInPrepareHeader function before it is passed to the <c>midiInAddBuffer</c> function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midiinaddbuffer MMRESULT midiInAddBuffer( HMIDIIN hmi,
	// LPMIDIHDR pmh, UINT cbmh );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiInAddBuffer")]
	public static extern MMRESULT midiInAddBuffer([In] HMIDIIN hmi, ref MIDIHDR pmh, uint cbmh);

	/// <summary>The <c>midiInClose</c> function closes the specified MIDI input device.</summary>
	/// <param name="hmi">
	/// Handle to the MIDI input device. If the function is successful, the handle is no longer valid after the call to this function.
	/// </param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MIDIERR_STILLPLAYING</term>
	/// <term>Buffers are still in the queue.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALHANDLE</term>
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOMEM</term>
	/// <term>The system is unable to allocate or lock memory.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// If there are input buffers that have been sent by using the midiInAddBuffer function and have not been returned to the
	/// application, the close operation will fail. To return all pending buffers through the callback function, use the midiInReset function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midiinclose MMRESULT midiInClose( HMIDIIN hmi );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiInClose")]
	public static extern MMRESULT midiInClose([In] HMIDIIN hmi);

	/// <summary>The <c>midiInGetDevCaps</c> function determines the capabilities of a specified MIDI input device.</summary>
	/// <param name="uDeviceID">
	/// Identifier of the MIDI input device. The device identifier varies from zero to one less than the number of devices present. This
	/// parameter can also be a properly cast device handle.
	/// </param>
	/// <param name="pmic">Pointer to a MIDIINCAPS structure that is filled with information about the capabilities of the device.</param>
	/// <param name="cbmic">
	/// Size, in bytes, of the MIDIINCAPS structure. Only cbMidiInCaps bytes (or less) of information is copied to the location pointed
	/// to by lpMidiInCaps. If cbMidiInCaps is zero, nothing is copied, and the function returns MMSYSERR_NOERROR.
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
	/// <term>The specified device identifier is out of range.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALPARAM</term>
	/// <term>The specified pointer or structure is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NODRIVER</term>
	/// <term>The driver is not installed.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOMEM</term>
	/// <term>The system is unable to allocate or lock memory.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>To determine the number of MIDI input devices present on the system, use the midiInGetNumDevs function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midiingetdevcaps MMRESULT midiInGetDevCaps( UINT uDeviceID,
	// LPMIDIINCAPS pmic, UINT cbmic );
	[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiInGetDevCaps")]
	public static extern MMRESULT midiInGetDevCaps(uint uDeviceID, out MIDIINCAPS pmic, uint cbmic);

	/// <summary>
	/// The <c>midiInGetErrorText</c> function retrieves a textual description for an error identified by the specified error code.
	/// </summary>
	/// <param name="mmrError">Error code.</param>
	/// <param name="pszText">Pointer to the buffer to be filled with the textual error description.</param>
	/// <param name="cchText">Length, in characters, of the buffer pointed to by lpText.</param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMSYSERR_BADERRNUM</term>
	/// <term>The specified error number is out of range.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALPARAM</term>
	/// <term>The specified pointer or structure is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOMEM</term>
	/// <term>The system is unable to allocate or lock memory.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// If the textual error description is longer than the specified buffer, the description is truncated. The returned error string is
	/// always null-terminated. If cchText is zero, nothing is copied, and the function returns zero. All error descriptions are less
	/// than MAXERRORLENGTH characters long.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midiingeterrortext MMRESULT midiInGetErrorText( MMRESULT
	// mmrError, StrPtrAnsi pszText, UINT cchText );
	[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiInGetErrorText")]
	public static extern MMRESULT midiInGetErrorText(MMRESULT mmrError, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder pszText, uint cchText);

	/// <summary>
	/// <para>The <c>midiInGetID</c> function gets the device identifier for the given MIDI input device.</para>
	/// <para>
	/// This function is supported for backward compatibility. New applications can cast a handle of the device rather than retrieving
	/// the device identifier.
	/// </para>
	/// </summary>
	/// <param name="hmi">Handle to the MIDI input device.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midiingetid MMRESULT midiInGetID( HMIDIIN hmi, LPUINT
	// puDeviceID );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiInGetID")]
	public static extern MMRESULT midiInGetID([In] HMIDIIN hmi, out uint puDeviceID);

	/// <summary>The <c>midiInGetNumDevs</c> function retrieves the number of MIDI input devices in the system.</summary>
	/// <returns>
	/// Returns the number of MIDI input devices present in the system. A return value of zero means that there are no devices (not that
	/// there is no error).
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midiingetnumdevs UINT midiInGetNumDevs();
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiInGetNumDevs")]
	public static extern uint midiInGetNumDevs();

	/// <summary>The <c>midiInMessage</c> function sends a message to the MIDI device driver.</summary>
	/// <param name="hmi">
	/// Identifier of the MIDI device that receives the message. You must cast the device ID to the <c>HMIDIIN</c> handle type. If you
	/// supply a handle instead of a device ID, the function fails and returns the MMSYSERR_NOSUPPORT error code.
	/// </param>
	/// <param name="uMsg">Message to send.</param>
	/// <param name="dw1">Message parameter.</param>
	/// <param name="dw2">Message parameter.</param>
	/// <returns>Returns the value returned by the audio device driver.</returns>
	/// <remarks>
	/// <para>This function is used only for driver-specific messages that are not supported by the MIDI API.</para>
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
	/// waveInMessage, waveOutMessage, <c>midiInMessage</c>, midiOutMessage, and mixerMessage functions. The system intercepts this
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
	/// This message is valid only for the waveInMessage, waveOutMessage, <c>midiInMessage</c>, midiOutMessage, and mixerMessage
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
	/// waveOutMessage, <c>midiInMessage</c>, midiOutMessage, and mixerMessage functions. The system intercepts this message and returns
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
	/// This message is valid only for the waveInMessage, waveOutMessage, <c>midiInMessage</c>, midiOutMessage, mixerMessage and
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
	/// appropriate handle type. For the <c>waveInMessage</c>, <c>waveOutMessage</c>, <c>midiInMessage</c>, midiOutMessage, or
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
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midiinmessage MMRESULT midiInMessage( HMIDIIN hmi, UINT uMsg,
	// DWORD_PTR dw1, DWORD_PTR dw2 );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiInMessage")]
	public static extern MMRESULT midiInMessage([In, Optional] HMIDIIN hmi, uint uMsg, [In, Optional] IntPtr dw1, [In, Optional] IntPtr dw2);

	/// <summary>The <c>midiInOpen</c> function opens a specified MIDI input device.</summary>
	/// <param name="phmi">
	/// Pointer to an <c>HMIDIIN</c> handle. This location is filled with a handle identifying the opened MIDI input device. The handle
	/// is used to identify the device in calls to other MIDI input functions.
	/// </param>
	/// <param name="uDeviceID">Identifier of the MIDI input device to be opened.</param>
	/// <param name="dwCallback">
	/// Pointer to a callback function, a thread identifier, or a handle of a window called with information about incoming MIDI
	/// messages. For more information on the callback function, see MidiInProc.
	/// </param>
	/// <param name="dwInstance">
	/// User instance data passed to the callback function. This parameter is not used with window callback functions or threads.
	/// </param>
	/// <param name="fdwOpen">
	/// <para>
	/// Callback flag for opening the device and, optionally, a status flag that helps regulate rapid data transfers. It can be the
	/// following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CALLBACK_FUNCTION</term>
	/// <term>The dwCallback parameter is a callback procedure address.</term>
	/// </item>
	/// <item>
	/// <term>CALLBACK_NULL</term>
	/// <term>There is no callback mechanism. This value is the default setting.</term>
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
	/// <term>MIDI_IO_STATUS</term>
	/// <term>
	/// When this parameter also specifies CALLBACK_FUNCTION, MIM_MOREDATA messages are sent to the callback function as well as
	/// MIM_DATA messages. Or, if this parameter also specifies CALLBACK_WINDOW, MM_MIM_MOREDATA messages are sent to the window as well
	/// as MM_MIM_DATA messages. This flag does not affect event or thread callbacks.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Most applications that use a callback mechanism will specify CALLBACK_FUNCTION for this parameter.</para>
	/// </param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following/</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMSYSERR_ALLOCATED</term>
	/// <term>The specified resource is already allocated.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_BADDEVICEID</term>
	/// <term>The specified device identifier is out of range.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALFLAG</term>
	/// <term>The flags specified by dwFlags are invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALPARAM</term>
	/// <term>The specified pointer or structure is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOMEM</term>
	/// <term>The system is unable to allocate or lock memory.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To determine the number of MIDI input devices present in the system, use the midiInGetNumDevs function. The device identifier
	/// specified by wDeviceID varies from zero to one less than the number of devices present.
	/// </para>
	/// <para>
	/// If a window or thread is chosen to receive callback information, the following messages are sent to the window procedure or
	/// thread to indicate the progress of MIDI input: MM_MIM_OPEN, MM_MIM_CLOSE, MM_MIM_DATA, MM_MIM_LONGDATA, MM_MIM_ERROR,
	/// MM_MIM_LONGERROR, and MM_MIM_MOREDATA.
	/// </para>
	/// <para>
	/// If a function is chosen to receive callback information, the following messages are sent to the function to indicate the
	/// progress of MIDI input: MIM_OPEN, MIM_CLOSE, MIM_DATA, MIM_LONGDATA, MIM_ERROR, MIM_LONGERROR, and MIM_MOREDATA.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midiinopen MMRESULT midiInOpen( LPHMIDIIN phmi, UINT
	// uDeviceID, DWORD_PTR dwCallback, DWORD_PTR dwInstance, DWORD fdwOpen );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiInOpen")]
	public static extern MMRESULT midiInOpen(out HMIDIIN phmi, uint uDeviceID, [In, Optional] IntPtr dwCallback, [In, Optional] IntPtr dwInstance, CALLBACK_FLAGS fdwOpen);

	/// <summary>The <c>midiInPrepareHeader</c> function prepares a buffer for MIDI input.</summary>
	/// <param name="hmi">Handle to the MIDI input device. To get the device handle, call midiInOpen.</param>
	/// <param name="pmh">
	/// <para>Pointer to a MIDIHDR structure that identifies the buffer to be prepared.</para>
	/// <para>
	/// Before calling the function, set the <c>lpData</c>, <c>dwBufferLength</c>, and <c>dwFlags</c> members of the MIDIHDR structure.
	/// The <c>dwFlags</c> member must be set to zero.
	/// </para>
	/// </param>
	/// <param name="cbmh">Size, in bytes, of the MIDIHDR structure.</param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
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
	/// <term>The specified address is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOMEM</term>
	/// <term>The system is unable to allocate or lock memory.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Before you pass a MIDI data block to a device driver, you must prepare the buffer by passing it to the
	/// <c>midiInPrepareHeader</c> function. After the header has been prepared, do not modify the buffer. After the driver is done
	/// using the buffer, call the midiInUnprepareHeader function.
	/// </para>
	/// <para>
	/// The application can re-use the same buffer, or allocate multiple buffers and call <c>midiInPrepareHeader</c> for each buffer. If
	/// you re-use the same buffer, it is not necessary to prepare the buffer each time. You can call <c>midiInPrepareHeader</c> once at
	/// the beginning and then call midiInUnprepareHeader once at the end.
	/// </para>
	/// <para>Preparing a header that has already been prepared has no effect, and the function returns zero.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midiinprepareheader MMRESULT midiInPrepareHeader( HMIDIIN
	// hmi, LPMIDIHDR pmh, UINT cbmh );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiInPrepareHeader")]
	public static extern MMRESULT midiInPrepareHeader([In] HMIDIIN hmi, ref MIDIHDR pmh, uint cbmh);

	/// <summary>The <c>midiInReset</c> function stops input on a given MIDI input device.</summary>
	/// <param name="hmi">Handle to the MIDI input device.</param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMSYSERR_INVALHANDLE</term>
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// This function returns all pending input buffers to the callback function and sets the MHDR_DONE flag in the <c>dwFlags</c>
	/// member of the MIDIHDR structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midiinreset MMRESULT midiInReset( HMIDIIN hmi );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiInReset")]
	public static extern MMRESULT midiInReset([In] HMIDIIN hmi);

	/// <summary>The <c>midiInStart</c> function starts MIDI input on the specified MIDI input device.</summary>
	/// <param name="hmi">Handle to the MIDI input device.</param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMSYSERR_INVALHANDLE</term>
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function resets the time stamp to zero; time stamp values for subsequently received messages are relative to the time that
	/// this function was called.
	/// </para>
	/// <para>
	/// All messages except system-exclusive messages are sent directly to the client when they are received. System-exclusive messages
	/// are placed in the buffers supplied by the midiInAddBuffer function. If there are no buffers in the queue, the system-exclusive
	/// data is thrown away without notification to the client and input continues. Buffers are returned to the client when they are
	/// full, when a complete system-exclusive message has been received, or when the midiInReset function is used. The
	/// <c>dwBytesRecorded</c> member of the MIDIHDR structure will contain the actual length of data received.
	/// </para>
	/// <para>Calling this function when input is already started has no effect, and the function returns zero.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midiinstart MMRESULT midiInStart( HMIDIIN hmi );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiInStart")]
	public static extern MMRESULT midiInStart([In] HMIDIIN hmi);

	/// <summary>The <c>midiInStop</c> function stops MIDI input on the specified MIDI input device.</summary>
	/// <param name="hmi">Handle to the MIDI input device.</param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMSYSERR_INVALHANDLE</term>
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If there are any system-exclusive messages or stream buffers in the queue, the current buffer is marked as done (the
	/// <c>dwBytesRecorded</c> member of the MIDIHDR structure will contain the actual length of data), but any empty buffers in the
	/// queue remain there and are not marked as done.
	/// </para>
	/// <para>Calling this function when input is not started has no effect, and the function returns zero.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midiinstop MMRESULT midiInStop( HMIDIIN hmi );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiInStop")]
	public static extern MMRESULT midiInStop([In] HMIDIIN hmi);

	/// <summary>The <c>midiInUnprepareHeader</c> function cleans up the preparation performed by the midiInPrepareHeader function.</summary>
	/// <param name="hmi">Handle to the MIDI input device.</param>
	/// <param name="pmh">Pointer to a MIDIHDR structure identifying the buffer to be cleaned up.</param>
	/// <param name="cbmh">Size of the MIDIHDR structure.</param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MIDIERR_STILLPLAYING</term>
	/// <term>The buffer pointed to by lpMidiInHdr is still in the queue.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALPARAM</term>
	/// <term>The specified pointer or structure is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALHANDLE</term>
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// This function is complementary to midiInPrepareHeader. You must use this function before freeing the buffer. After passing a
	/// buffer to the device driver by using the midiInAddBuffer function, you must wait until the driver is finished with the buffer
	/// before using <c>midiInUnprepareHeader</c>. Unpreparing a buffer that has not been prepared has no effect, and the function
	/// returns MMSYSERR_NOERROR.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midiinunprepareheader MMRESULT midiInUnprepareHeader( HMIDIIN
	// hmi, LPMIDIHDR pmh, UINT cbmh );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiInUnprepareHeader")]
	public static extern MMRESULT midiInUnprepareHeader([In] HMIDIIN hmi, ref MIDIHDR pmh, uint cbmh);

	/// <summary>
	/// The <c>midiOutCacheDrumPatches</c> function requests that an internal MIDI synthesizer device preload and cache a specified set
	/// of key-based percussion patches.
	/// </summary>
	/// <param name="hmo">
	/// Handle to the opened MIDI output device. This device should be an internal MIDI synthesizer. This parameter can also be the
	/// handle of a MIDI stream, cast to <c>HMIDIOUT</c>.
	/// </param>
	/// <param name="uPatch">
	/// Drum patch number that should be used. This parameter should be set to zero to cache the default drum patch.
	/// </param>
	/// <param name="pwkya">
	/// Pointer to a KEYARRAY array indicating the key numbers of the specified percussion patches to be cached or uncached.
	/// </param>
	/// <param name="fuCache">
	/// <para>Options for the cache operation. It can be one of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MIDI_CACHE_ALL</term>
	/// <term>
	/// Caches all of the specified patches. If they cannot all be cached, it caches none, clears the KEYARRAY array, and returns MMSYSERR_NOMEM.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MIDI_CACHE_BESTFIT</term>
	/// <term>
	/// Caches all of the specified patches. If they cannot all be cached, it caches as many patches as possible, changes the KEYARRAY
	/// array to reflect which patches were cached, and returns MMSYSERR_NOMEM.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MIDI_CACHE_QUERY</term>
	/// <term>Changes the KEYARRAY array to indicate which patches are currently cached.</term>
	/// </item>
	/// <item>
	/// <term>MIDI_UNCACHE</term>
	/// <term>Uncaches the specified patches and clears the KEYARRAY array.</term>
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
	/// <term>MMSYSERR_INVALFLAG</term>
	/// <term>The flag specified by wFlags is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALHANDLE</term>
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALPARAM</term>
	/// <term>The array pointed to by the lpKeyArray array is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOMEM</term>
	/// <term>The device does not have enough memory to cache all of the requested patches.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOTSUPPORTED</term>
	/// <term>The specified device does not support patch caching.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Some synthesizers are not capable of keeping all percussion patches loaded simultaneously. Caching patches ensures that the
	/// specified patches are available.
	/// </para>
	/// <para>
	/// Each element of the KEYARRAY array represents one of the 128 key-based percussion patches and has bits set for each of the 16
	/// MIDI channels that use the particular patch. The least-significant bit represents physical channel 0, and the most-significant
	/// bit represents physical channel 15. For example, if the patch on key number 60 is used by physical channels 9 and 15, element 60
	/// would be set to 0x8200.
	/// </para>
	/// <para>
	/// This function applies only to internal MIDI synthesizer devices. Not all internal synthesizers support patch caching. To see if
	/// a device supports patch caching, use the MIDICAPS_CACHE flag to test the <c>dwSupport</c> member of the MIDIOUTCAPS structure
	/// filled by the midiOutGetDevCaps function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midioutcachedrumpatches MMRESULT midiOutCacheDrumPatches(
	// HMIDIOUT hmo, UINT uPatch, LPWORD pwkya, UINT fuCache );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiOutCacheDrumPatches")]
	public static extern MMRESULT midiOutCacheDrumPatches([In] HMIDIOUT hmo, uint uPatch, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = MIDIPATCHSIZE)] ushort[] pwkya, MIDI_CACHE fuCache);

	/// <summary>
	/// The <c>midiOutCachePatches</c> function requests that an internal MIDI synthesizer device preload and cache a specified set of patches.
	/// </summary>
	/// <param name="hmo">
	/// Handle to the opened MIDI output device. This device must be an internal MIDI synthesizer. This parameter can also be the handle
	/// of a MIDI stream, cast to <c>HMIDIOUT</c>.
	/// </param>
	/// <param name="uBank">Bank of patches that should be used. This parameter should be set to zero to cache the default patch bank.</param>
	/// <param name="pwpa">Pointer to a PATCHARRAY array indicating the patches to be cached or uncached.</param>
	/// <param name="fuCache">
	/// <para>Options for the cache operation. It can be one of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MIDI_CACHE_ALL</term>
	/// <term>
	/// Caches all of the specified patches. If they cannot all be cached, it caches none, clears the PATCHARRAY array, and returns MMSYSERR_NOMEM.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MIDI_CACHE_BESTFIT</term>
	/// <term>
	/// Caches all of the specified patches. If they cannot all be cached, it caches as many patches as possible, changes the PATCHARRAY
	/// array to reflect which patches were cached, and returns MMSYSERR_NOMEM.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MIDI_CACHE_QUERY</term>
	/// <term>Changes the PATCHARRAY array to indicate which patches are currently cached.</term>
	/// </item>
	/// <item>
	/// <term>MIDI_UNCACHE</term>
	/// <term>Uncaches the specified patches and clears the PATCHARRAY array.</term>
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
	/// <term>MMSYSERR_INVALFLAG</term>
	/// <term>The flag specified by wFlags is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALHANDLE</term>
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALPARAM</term>
	/// <term>The array pointed to by lpPatchArray is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOMEM</term>
	/// <term>The device does not have enough memory to cache all of the requested patches.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOTSUPPORTED</term>
	/// <term>The specified device does not support patch caching.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Some synthesizers are not capable of keeping all patches loaded simultaneously and must load data from disk when they receive
	/// MIDI program change messages. Caching patches ensures that the specified patches are immediately available.
	/// </para>
	/// <para>
	/// Each element of the PATCHARRAY array represents one of the 128 patches and has bits set for each of the 16 MIDI channels that
	/// use the particular patch. The least-significant bit represents physical channel 0, and the most-significant bit represents
	/// physical channel 15 (0x0F). For example, if patch 0 is used by physical channels 0 and 8, element 0 would be set to 0x0101.
	/// </para>
	/// <para>
	/// This function applies only to internal MIDI synthesizer devices. Not all internal synthesizers support patch caching. To see if
	/// a device supports patch caching, use the MIDICAPS_CACHE flag to test the <c>dwSupport</c> member of the MIDIOUTCAPS structure
	/// filled by the midiOutGetDevCaps function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midioutcachepatches MMRESULT midiOutCachePatches( HMIDIOUT
	// hmo, UINT uBank, LPWORD pwpa, UINT fuCache );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiOutCachePatches")]
	public static extern MMRESULT midiOutCachePatches([In] HMIDIOUT hmo, uint uBank, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = MIDIPATCHSIZE)] ushort[] pwpa, MIDI_CACHE fuCache);

	/// <summary>The <c>midiOutClose</c> function closes the specified MIDI output device.</summary>
	/// <param name="hmo">
	/// Handle to the MIDI output device. If the function is successful, the handle is no longer valid after the call to this function.
	/// </param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MIDIERR_STILLPLAYING</term>
	/// <term>Buffers are still in the queue.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALHANDLE</term>
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOMEM</term>
	/// <term>The system is unable to load mapper string description.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// If there are output buffers that have been sent by using the midiOutLongMsg function and have not been returned to the
	/// application, the close operation will fail. To mark all pending buffers as being done, use the midiOutReset function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midioutclose MMRESULT midiOutClose( HMIDIOUT hmo );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiOutClose")]
	public static extern MMRESULT midiOutClose([In] HMIDIOUT hmo);

	/// <summary>The <c>midiOutGetDevCaps</c> function queries a specified MIDI output device to determine its capabilities.</summary>
	/// <param name="uDeviceID">
	/// <para>
	/// Identifier of the MIDI output device. The device identifier specified by this parameter varies from zero to one less than the
	/// number of devices present. The MIDI_MAPPER constant is also a valid device identifier.
	/// </para>
	/// <para>This parameter can also be a properly cast device handle.</para>
	/// </param>
	/// <param name="pmoc">
	/// Pointer to a MIDIOUTCAPS structure. This structure is filled with information about the capabilities of the device.
	/// </param>
	/// <param name="cbmoc">
	/// Size, in bytes, of the MIDIOUTCAPS structure. Only cbMidiOutCaps bytes (or less) of information is copied to the location
	/// pointed to by lpMidiOutCaps. If cbMidiOutCaps is zero, nothing is copied, and the function returns MMSYSERR_NOERROR.
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
	/// <term>The specified device identifier is out of range.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALPARAM</term>
	/// <term>The specified pointer or structure is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NODRIVER</term>
	/// <term>The driver is not installed.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOMEM</term>
	/// <term>The system is unable to load mapper string description.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>To determine the number of MIDI output devices present in the system, use the midiOutGetNumDevs function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midioutgetdevcaps MMRESULT midiOutGetDevCaps( UINT uDeviceID,
	// LPMIDIOUTCAPS pmoc, UINT cbmoc );
	[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiOutGetDevCaps")]
	public static extern MMRESULT midiOutGetDevCaps(uint uDeviceID, out MIDIOUTCAPS pmoc, uint cbmoc);

	/// <summary>
	/// The <c>midiOutGetErrorText</c> function retrieves a textual description for an error identified by the specified error code.
	/// </summary>
	/// <param name="mmrError">Error code.</param>
	/// <param name="pszText">Pointer to a buffer to be filled with the textual error description.</param>
	/// <param name="cchText">Length, in characters, of the buffer pointed to by lpText.</param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMSYSERR_BADERRNUM</term>
	/// <term>The specified error number is out of range.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALPARAM</term>
	/// <term>The specified pointer or structure is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// If the textual error description is longer than the specified buffer, the description is truncated. The returned error string is
	/// always null-terminated. If cchText is zero, nothing is copied, and the function returns MMSYSERR_NOERROR. All error descriptions
	/// are less than MAXERRORLENGTH characters long.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midioutgeterrortext MMRESULT midiOutGetErrorText( MMRESULT
	// mmrError, StrPtrAnsi pszText, UINT cchText );
	[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiOutGetErrorText")]
	public static extern MMRESULT midiOutGetErrorText(MMRESULT mmrError, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder pszText, uint cchText);

	/// <summary>
	/// <para>The <c>midiOutGetID</c> function retrieves the device identifier for the given MIDI output device.</para>
	/// <para>
	/// This function is supported for backward compatibility. New applications can cast a handle of the device rather than retrieving
	/// the device identifier.
	/// </para>
	/// </summary>
	/// <param name="hmo">Handle to the MIDI output device.</param>
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
	/// <term>The hmo parameter specifies an invalid handle.</term>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midioutgetid MMRESULT midiOutGetID( HMIDIOUT hmo, LPUINT
	// puDeviceID );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiOutGetID")]
	public static extern MMRESULT midiOutGetID(HMIDIOUT hmo, out uint puDeviceID);

	/// <summary>The <c>midiOutGetNumDevs</c> function retrieves the number of MIDI output devices present in the system.</summary>
	/// <returns>
	/// Returns the number of MIDI output devices. A return value of zero means that there are no devices (not that there is no error).
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midioutgetnumdevs UINT midiOutGetNumDevs();
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiOutGetNumDevs")]
	public static extern uint midiOutGetNumDevs();

	/// <summary>The <c>midiOutGetVolume</c> function retrieves the current volume setting of a MIDI output device.</summary>
	/// <param name="hmo">
	/// Handle to an open MIDI output device. This parameter can also contain the handle of a MIDI stream, as long as it is cast to
	/// <c>HMIDIOUT</c>. This parameter can also be a device identifier.
	/// </param>
	/// <param name="pdwVolume">
	/// <para>
	/// Pointer to the location to contain the current volume setting. The low-order word of this location contains the left-channel
	/// volume setting, and the high-order word contains the right-channel setting. A value of 0xFFFF represents full volume, and a
	/// value of 0x0000 is silence.
	/// </para>
	/// <para>
	/// If a device does not support both left and right volume control, the low-order word of the specified location contains the mono
	/// volume level.
	/// </para>
	/// <para>Any value set by using the midiOutSetVolume function is returned, regardless of whether the device supports that value.</para>
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
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALPARAM</term>
	/// <term>The specified pointer or structure is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOMEM</term>
	/// <term>The system is unable to allocate or lock memory.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOTSUPPORTED</term>
	/// <term>The function is not supported.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a device identifier is used, then the result of the <c>midiOutGetVolume</c> call and the information returned in lpdwVolume
	/// applies to all instances of the device. If a device handle is used, then the result and information returned applies only to the
	/// instance of the device referenced by the device handle.
	/// </para>
	/// <para>
	/// Not all devices support volume control. You can determine whether a device supports volume control by querying the device by
	/// using the midiOutGetDevCaps function and specifying the MIDICAPS_VOLUME flag.
	/// </para>
	/// <para>
	/// You can also determine whether the device supports volume control on both the left and right channels by querying the device by
	/// using the midiOutGetDevCaps function and specifying the MIDICAPS_LRVOLUME flag.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midioutgetvolume MMRESULT midiOutGetVolume( HMIDIOUT hmo,
	// LPDWORD pdwVolume );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiOutGetVolume")]
	public static extern MMRESULT midiOutGetVolume([In] HMIDIOUT hmo, out uint pdwVolume);

	/// <summary>The <c>midiOutLongMsg</c> function sends a system-exclusive MIDI message to the specified MIDI output device.</summary>
	/// <param name="hmo">Handle to the MIDI output device. This parameter can also be the handle of a MIDI stream cast to <c>HMIDIOUT</c>.</param>
	/// <param name="pmh">Pointer to a MIDIHDR structure that identifies the MIDI buffer.</param>
	/// <param name="cbmh">Size, in bytes, of the MIDIHDR structure.</param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MIDIERR_NOTREADY</term>
	/// <term>The hardware is busy with other data.</term>
	/// </item>
	/// <item>
	/// <term>MIDIERR_UNPREPARED</term>
	/// <term>The buffer pointed to by lpMidiOutHdr has not been prepared.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALHANDLE</term>
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALPARAM</term>
	/// <term>The specified pointer or structure is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Before the buffer is passed to <c>midiOutLongMsg</c>, it must be prepared by using the midiOutPrepareHeader function. The MIDI
	/// output device driver determines whether the data is sent synchronously or asynchronously.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midioutlongmsg MMRESULT midiOutLongMsg( HMIDIOUT hmo,
	// LPMIDIHDR pmh, UINT cbmh );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiOutLongMsg")]
	public static extern MMRESULT midiOutLongMsg([In] HMIDIOUT hmo, in MIDIHDR pmh, uint cbmh);

	/// <summary>
	/// The <c>midiOutMessage</c> function sends a message to the MIDI device drivers. This function is used only for driver-specific
	/// messages that are not supported by the MIDI API.
	/// </summary>
	/// <param name="hmo">
	/// Identifier of the MIDI device that receives the message. You must cast the device ID to the <c>HMIDIOUT</c> handle type. If you
	/// supply a handle instead of a device ID, the function fails and returns the MMSYSERR_NOSUPPORT error code.
	/// </param>
	/// <param name="uMsg">Message to send.</param>
	/// <param name="dw1">Message parameter.</param>
	/// <param name="dw2">Message parameter.</param>
	/// <returns>Returns the value returned by the audio device driver.</returns>
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
	/// waveInMessage, waveOutMessage, midiInMessage, <c>midiOutMessage</c>, and mixerMessage functions. The system intercepts this
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
	/// This message is valid only for the waveInMessage, waveOutMessage, midiInMessage, <c>midiOutMessage</c>, and mixerMessage
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
	/// waveOutMessage, midiInMessage, <c>midiOutMessage</c>, and mixerMessage functions. The system intercepts this message and returns
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
	/// This message is valid only for the waveInMessage, waveOutMessage, midiInMessage, <c>midiOutMessage</c>, mixerMessage and
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
	/// appropriate handle type. For the <c>waveInMessage</c>, <c>waveOutMessage</c>, midiInMessage, <c>midiOutMessage</c>, or
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
	/// This message is valid only for the waveInMessage, waveOutMessage and <c>midiOutMessage</c> functions. When the caller calls
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
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midioutmessage MMRESULT midiOutMessage( HMIDIOUT hmo, UINT
	// uMsg, DWORD_PTR dw1, DWORD_PTR dw2 );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiOutMessage")]
	public static extern MMRESULT midiOutMessage([In, Optional] HMIDIOUT hmo, uint uMsg, [In, Optional] IntPtr dw1, [In, Optional] IntPtr dw2);

	/// <summary>The <c>midiOutOpen</c> function opens a MIDI output device for playback.</summary>
	/// <param name="phmo">
	/// Pointer to an <c>HMIDIOUT</c> handle. This location is filled with a handle identifying the opened MIDI output device. The
	/// handle is used to identify the device in calls to other MIDI output functions.
	/// </param>
	/// <param name="uDeviceID">Identifier of the MIDI output device that is to be opened.</param>
	/// <param name="dwCallback">
	/// Pointer to a callback function, an event handle, a thread identifier, or a handle of a window or thread called during MIDI
	/// playback to process messages related to the progress of the playback. If no callback is desired, specify <c>NULL</c> for this
	/// parameter. For more information on the callback function, see MidiOutProc.
	/// </param>
	/// <param name="dwInstance">User instance data passed to the callback. This parameter is not used with window callbacks or threads.</param>
	/// <param name="fdwOpen">
	/// <para>Callback flag for opening the device. It can be the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CALLBACK_EVENT</term>
	/// <term>The dwCallback parameter is an event handle. This callback mechanism is for output only.</term>
	/// </item>
	/// <item>
	/// <term>CALLBACK_FUNCTION</term>
	/// <term>The dwCallback parameter is a callback function address.</term>
	/// </item>
	/// <item>
	/// <term>CALLBACK_NULL</term>
	/// <term>There is no callback mechanism. This value is the default setting.</term>
	/// </item>
	/// <item>
	/// <term>CALLBACK_THREAD</term>
	/// <term>The dwCallback parameter is a thread identifier.</term>
	/// </item>
	/// <item>
	/// <term>CALLBACK_WINDOW</term>
	/// <term>The dwCallback parameter is a window handle.</term>
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
	/// <term>MIDIERR_NODEVICE</term>
	/// <term>No MIDI port was found. This error occurs only when the mapper is opened.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_ALLOCATED</term>
	/// <term>The specified resource is already allocated.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_BADDEVICEID</term>
	/// <term>The specified device identifier is out of range.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALPARAM</term>
	/// <term>The specified pointer or structure is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOMEM</term>
	/// <term>The system is unable to allocate or lock memory.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To determine the number of MIDI output devices present in the system, use the midiOutGetNumDevs function. The device identifier
	/// specified by wDeviceID varies from zero to one less than the number of devices present. MIDI_MAPPER can also be used as the
	/// device identifier.
	/// </para>
	/// <para>
	/// If a window or thread is chosen to receive callback information, the following messages are sent to the window procedure or
	/// thread to indicate the progress of MIDI output: MM_MOM_OPEN, MM_MOM_CLOSE, and MM_MOM_DONE.
	/// </para>
	/// <para>
	/// If a function is chosen to receive callback information, the following messages are sent to the function to indicate the
	/// progress of MIDI output: MOM_OPEN, MOM_CLOSE, and MOM_DONE.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midioutopen MMRESULT midiOutOpen( LPHMIDIOUT phmo, UINT
	// uDeviceID, DWORD_PTR dwCallback, DWORD_PTR dwInstance, DWORD fdwOpen );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiOutOpen")]
	public static extern MMRESULT midiOutOpen(out HMIDIOUT phmo, uint uDeviceID, [In, Optional] IntPtr dwCallback, [In, Optional] IntPtr dwInstance, CALLBACK_FLAGS fdwOpen = CALLBACK_FLAGS.CALLBACK_NULL);

	/// <summary>The <c>midiOutPrepareHeader</c> function prepares a MIDI system-exclusive or stream buffer for output.</summary>
	/// <param name="hmo">
	/// Handle to the MIDI output device. To get the device handle, call midiOutOpen. This parameter can also be the handle of a MIDI
	/// stream cast to a <c>HMIDIOUT</c> type.
	/// </param>
	/// <param name="pmh">
	/// <para>Pointer to a MIDIHDR structure that identifies the buffer to be prepared.</para>
	/// <para>
	/// Before calling the function, set the <c>lpData</c>, <c>dwBufferLength</c>, and <c>dwFlags</c> members of the MIDIHDR structure.
	/// The <c>dwFlags</c> member must be set to zero.
	/// </para>
	/// </param>
	/// <param name="cbmh">Size, in bytes, of the MIDIHDR structure.</param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
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
	/// <term>The specified address is invalid or the given stream buffer is greater than 64K.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOMEM</term>
	/// <term>The system is unable to allocate or lock memory.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Before you pass a MIDI data block to a device driver, you must prepare the buffer by passing it to the
	/// <c>midiOutPrepareHeader</c> function. After the header has been prepared, do not modify the buffer. After the driver is done
	/// using the buffer, call the midiOutUnprepareHeader function.
	/// </para>
	/// <para>
	/// The application can re-use the same buffer, or allocate multiple buffers and call <c>midiOutPrepareHeader</c> for each buffer.
	/// If you re-use the same buffer, it is not necessary to prepare the buffer each time. You can call <c>midiOutPrepareHeader</c>
	/// once at the beginning and then call midiOutUnprepareHeader once at the end.
	/// </para>
	/// <para>A stream buffer cannot be larger than 64K.</para>
	/// <para>Preparing a header that has already been prepared has no effect, and the function returns MMSYSERR_NOERROR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midioutprepareheader MMRESULT midiOutPrepareHeader( HMIDIOUT
	// hmo, LPMIDIHDR pmh, UINT cbmh );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiOutPrepareHeader")]
	public static extern MMRESULT midiOutPrepareHeader(HMIDIOUT hmo, ref MIDIHDR pmh, uint cbmh);

	/// <summary>The <c>midiOutReset</c> function turns off all notes on all MIDI channels for the specified MIDI output device.</summary>
	/// <param name="hmo">Handle to the MIDI output device. This parameter can also be the handle of a MIDI stream cast to <c>HMIDIOUT</c>.</param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMSYSERR_INVALHANDLE</term>
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Any pending system-exclusive or stream output buffers are returned to the callback function and the MHDR_DONE flag is set in the
	/// <c>dwFlags</c> member of the MIDIHDR structure.
	/// </para>
	/// <para>
	/// Terminating a system-exclusive message without sending an EOX (end-of-exclusive) byte might cause problems for the receiving
	/// device. The <c>midiOutReset</c> function does not send an EOX byte when it terminates a system-exclusive message - applications
	/// are responsible for doing this.
	/// </para>
	/// <para>
	/// To turn off all notes, a note-off message for each note in each channel is sent. In addition, the sustain controller is turned
	/// off for each channel.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midioutreset MMRESULT midiOutReset( HMIDIOUT hmo );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiOutReset")]
	public static extern MMRESULT midiOutReset([In] HMIDIOUT hmo);

	/// <summary>The <c>midiOutSetVolume</c> function sets the volume of a MIDI output device.</summary>
	/// <param name="hmo">
	/// Handle to an open MIDI output device. This parameter can also contain the handle of a MIDI stream, as long as it is cast to
	/// <c>HMIDIOUT</c>. This parameter can also be a device identifier.
	/// </param>
	/// <param name="dwVolume">
	/// <para>
	/// New volume setting. The low-order word contains the left-channel volume setting, and the high-order word contains the
	/// right-channel setting. A value of 0xFFFF represents full volume, and a value of 0x0000 is silence.
	/// </para>
	/// <para>
	/// If a device does not support both left and right volume control, the low-order word of dwVolume specifies the mono volume level,
	/// and the high-order word is ignored.
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
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOMEM</term>
	/// <term>The system is unable to allocate or lock memory.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOTSUPPORTED</term>
	/// <term>The function is not supported.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a device identifier is used, then the result of the <c>midiOutSetVolume</c> call applies to all instances of the device. If a
	/// device handle is used, then the result applies only to the instance of the device referenced by the device handle.
	/// </para>
	/// <para>
	/// Not all devices support volume changes. You can determine whether a device supports it by querying the device using the
	/// midiOutGetDevCaps function and the MIDICAPS_VOLUME flag.
	/// </para>
	/// <para>
	/// You can also determine whether the device supports volume control on both the left and right channels by querying the device
	/// using the midiOutGetDevCaps function and the MIDICAPS_LRVOLUME flag.
	/// </para>
	/// <para>
	/// Devices that do not support a full 16 bits of volume-level control use the high-order bits of the requested volume setting. For
	/// example, a device that supports 4 bits of volume control produces the same volume setting for the following volume-level values:
	/// 0x4000, 0x43be, and 0x4fff. The midiOutGetVolume function returns the full 16-bit value, as set by <c>midiOutSetVolume</c>,
	/// irrespective of the device's capabilities.
	/// </para>
	/// <para>
	/// Volume settings are interpreted logarithmically. This means that the perceived increase in volume is the same when increasing
	/// the volume level from 0x5000 to 0x6000 as it is from 0x4000 to 0x5000.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midioutsetvolume MMRESULT midiOutSetVolume( HMIDIOUT hmo,
	// DWORD dwVolume );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiOutSetVolume")]
	public static extern MMRESULT midiOutSetVolume([In] HMIDIOUT hmo, uint dwVolume);

	/// <summary>The <c>midiOutShortMsg</c> function sends a short MIDI message to the specified MIDI output device.</summary>
	/// <param name="hmo">Handle to the MIDI output device. This parameter can also be the handle of a MIDI stream cast to <c>HMIDIOUT</c>.</param>
	/// <param name="dwMsg">
	/// <para>
	/// MIDI message. The message is packed into a <c>DWORD</c> value with the first byte of the message in the low-order byte. The
	/// message is packed into this parameter as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Word</term>
	/// <term>Byte</term>
	/// <term>Usage</term>
	/// </listheader>
	/// <item>
	/// <term>High</term>
	/// <term>High-order</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Low-order</term>
	/// <term>The second byte of MIDI data (when needed).</term>
	/// </item>
	/// <item>
	/// <term>Low</term>
	/// <term>High-order</term>
	/// <term>The first byte of MIDI data (when needed).</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Low-order</term>
	/// <term>The MIDI status.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The two MIDI data bytes are optional, depending on the MIDI status byte. When a series of messages have the same status byte,
	/// the status byte can be omitted from messages after the first one in the series, creating a running status. Pack a message for
	/// running status as follows:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Word</term>
	/// <term>Byte</term>
	/// <term>Usage</term>
	/// </listheader>
	/// <item>
	/// <term>High</term>
	/// <term>High-order</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Low-order</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>Low</term>
	/// <term>High-order</term>
	/// <term>The second byte of MIDI data (when needed).</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Low-order</term>
	/// <term>The first byte of MIDI data.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MIDIERR_BADOPENMODE</term>
	/// <term>The application sent a message without a status byte to a stream handle.</term>
	/// </item>
	/// <item>
	/// <term>MIDIERR_NOTREADY</term>
	/// <term>The hardware is busy with other data.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALHANDLE</term>
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function is used to send any MIDI message except for system-exclusive or stream messages.</para>
	/// <para>
	/// This function might not return until the message has been sent to the output device. You can send short messages while streams
	/// are playing on the same device (although you cannot use a running status in this case).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midioutshortmsg MMRESULT midiOutShortMsg( HMIDIOUT hmo, DWORD
	// dwMsg );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiOutShortMsg")]
	public static extern MMRESULT midiOutShortMsg([In] HMIDIOUT hmo, uint dwMsg);

	/// <summary>The <c>midiOutUnprepareHeader</c> function cleans up the preparation performed by the midiOutPrepareHeader function.</summary>
	/// <param name="hmo">Handle to the MIDI output device. This parameter can also be the handle of a MIDI stream cast to <c>HMIDIOUT</c>.</param>
	/// <param name="pmh">Pointer to a MIDIHDR structure identifying the buffer to be cleaned up.</param>
	/// <param name="cbmh">Size, in bytes, of the MIDIHDR structure.</param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MIDIERR_STILLPLAYING</term>
	/// <term>The buffer pointed to by lpMidiOutHdr is still in the queue.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALHANDLE</term>
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALPARAM</term>
	/// <term>The specified pointer or structure is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is complementary to the midiOutPrepareHeader function. You must call <c>midiOutUnprepareHeader</c> before freeing
	/// the buffer. After passing a buffer to the device driver with the midiOutLongMsg function, you must wait until the device driver
	/// is finished with the buffer before calling <c>midiOutUnprepareHeader</c>.
	/// </para>
	/// <para>Unpreparing a buffer that has not been prepared has no effect, and the function returns MMSYSERR_NOERROR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midioutunprepareheader MMRESULT midiOutUnprepareHeader(
	// HMIDIOUT hmo, LPMIDIHDR pmh, UINT cbmh );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiOutUnprepareHeader")]
	public static extern MMRESULT midiOutUnprepareHeader([In] HMIDIOUT hmo, ref MIDIHDR pmh, uint cbmh);

	/// <summary>The <c>midiStreamClose</c> function closes an open MIDI stream.</summary>
	/// <param name="hms">Handle to a MIDI stream, as retrieved by using the midiStreamOpen function.</param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMSYSERR_INVALHANDLE</term>
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midistreamclose MMRESULT midiStreamClose( HMIDISTRM hms );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiStreamClose")]
	public static extern MMRESULT midiStreamClose([In] HMIDISTRM hms);

	/// <summary>
	/// The <c>midiStreamOpen</c> function opens a MIDI stream for output. By default, the device is opened in paused mode. The stream
	/// handle retrieved by this function must be used in all subsequent references to the stream.
	/// </summary>
	/// <param name="phms">Pointer to a variable to contain the stream handle when the function returns.</param>
	/// <param name="puDeviceID">
	/// Pointer to a device identifier. The device is opened on behalf of the stream and closed again when the stream is closed.
	/// </param>
	/// <param name="cMidi">Reserved; must be 1.</param>
	/// <param name="dwCallback">
	/// Pointer to a callback function, an event handle, a thread identifier, or a handle of a window or thread called during MIDI
	/// playback to process messages related to the progress of the playback. If no callback mechanism is desired, specify <c>NULL</c>
	/// for this parameter.
	/// </param>
	/// <param name="dwInstance">Application-specific instance data that is returned to the application with every callback function.</param>
	/// <param name="fdwOpen">
	/// <para>Callback flag for opening the device. One of the following callback flags must be specified.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CALLBACK_EVENT</term>
	/// <term>The dwCallback parameter is an event handle. This callback mechanism is for output only.</term>
	/// </item>
	/// <item>
	/// <term>CALLBACK_FUNCTION</term>
	/// <term>The dwCallback parameter is a callback procedure address. For the callback signature, see MidiOutProc.</term>
	/// </item>
	/// <item>
	/// <term>CALLBACK_NULL</term>
	/// <term>There is no callback mechanism. This is the default setting.</term>
	/// </item>
	/// <item>
	/// <term>CALLBACK_THREAD</term>
	/// <term>The dwCallback parameter is a thread identifier.</term>
	/// </item>
	/// <item>
	/// <term>CALLBACK_WINDOW</term>
	/// <term>The dwCallback parameter is a window handle.</term>
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
	/// <term>The specified device identifier is out of range.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALPARAM</term>
	/// <term>The given handle or flags parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_NOMEM</term>
	/// <term>The system is unable to allocate or lock memory.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midistreamopen MMRESULT midiStreamOpen( LPHMIDISTRM phms,
	// LPUINT puDeviceID, DWORD cMidi, DWORD_PTR dwCallback, DWORD_PTR dwInstance, DWORD fdwOpen );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiStreamOpen")]
	public static extern MMRESULT midiStreamOpen(out HMIDISTRM phms, ref uint puDeviceID, uint cMidi, [In, Optional] IntPtr dwCallback, [In, Optional] IntPtr dwInstance, CALLBACK_FLAGS fdwOpen);

	/// <summary>The <c>midiStreamOut</c> function plays or queues a stream (buffer) of MIDI data to a MIDI output device.</summary>
	/// <param name="hms">
	/// Handle to a MIDI stream. This handle must have been returned by a call to the midiStreamOpen function. This handle identifies
	/// the output device.
	/// </param>
	/// <param name="pmh">Pointer to a MIDIHDR structure that identifies the MIDI buffer.</param>
	/// <param name="cbmh">Size, in bytes, of the MIDIHDR structure.</param>
	/// <returns>
	/// <para>Returns MMSYSERR_NOERROR if successful or an error otherwise. Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>MMSYSERR_NOMEM</term>
	/// <term>The system is unable to allocate or lock memory.</term>
	/// </item>
	/// <item>
	/// <term>MIDIERR_STILLPLAYING</term>
	/// <term>The output buffer pointed to by lpMidiHdr is still playing or is queued from a previous call to midiStreamOut.</term>
	/// </item>
	/// <item>
	/// <term>MIDIERR_UNPREPARED</term>
	/// <term>The header pointed to by lpMidiHdr has not been prepared.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALHANDLE</term>
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALPARAM</term>
	/// <term>The pointer specified by lpMidiHdr is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Before the buffer is passed to midiStreamOpen, it must be prepared by using the midiOutPrepareHeader function.</para>
	/// <para>
	/// Because the midiStreamOpen function opens the output device in paused mode, you must call the midiStreamRestart function before
	/// you can use <c>midiStreamOut</c> to start the playback.
	/// </para>
	/// <para>For the current implementation of this function, the buffer must be smaller than 64K.</para>
	/// <para>
	/// The buffer pointed to by the MIDIHDR structure contains one or more MIDI events, each of which is defined by a MIDIEVENT structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midistreamout MMRESULT midiStreamOut( HMIDISTRM hms,
	// LPMIDIHDR pmh, UINT cbmh );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiStreamOut")]
	public static extern MMRESULT midiStreamOut([In] HMIDISTRM hms, ref MIDIHDR pmh, uint cbmh);

	/// <summary>The <c>midiStreamPause</c> function pauses playback of a specified MIDI stream.</summary>
	/// <param name="hms">
	/// Handle to a MIDI stream. This handle must have been returned by a call to the MIDIEVENT function. This handle identifies the
	/// output device.
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
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The current playback position is saved when playback is paused. To resume playback from the current position, use the
	/// midiStreamRestart function.
	/// </para>
	/// <para>Calling this function when the output is already paused has no effect, and the function returns MMSYSERR_NOERROR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midistreampause MMRESULT midiStreamPause( HMIDISTRM hms );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiStreamPause")]
	public static extern MMRESULT midiStreamPause([In] HMIDISTRM hms);

	/// <summary>The <c>midiStreamPosition</c> function retrieves the current position in a MIDI stream.</summary>
	/// <param name="hms">
	/// Handle to a MIDI stream. This handle must have been returned by a call to the midiStreamOpen function. This handle identifies
	/// the output device.
	/// </param>
	/// <param name="lpmmt">Pointer to an MMTIME structure.</param>
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
	/// <term>MMSYSERR_INVALPARAM</term>
	/// <term>Specified pointer or structure is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Before calling <c>midiStreamPosition</c>, set the <c>wType</c> member of the MMTIME structure to indicate the time format you
	/// desire. After calling <c>midiStreamPosition</c>, check the <c>wType</c> member to determine if the desired time format is
	/// supported. If the desired format is not supported, <c>wType</c> will specify an alternative format.
	/// </para>
	/// <para>The position is set to zero when the device is opened or reset.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midistreamposition MMRESULT midiStreamPosition( HMIDISTRM
	// hms, LPMMTIME lpmmt, UINT cbmmt );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiStreamPosition")]
	public static extern MMRESULT midiStreamPosition([In] HMIDISTRM hms, ref MMTIME lpmmt, uint cbmmt);

	/// <summary>
	/// The <c>midiStreamProperty</c> function sets or retrieves properties of a MIDI data stream associated with a MIDI output device.
	/// </summary>
	/// <param name="hms">Handle to the MIDI device that the property is associated with.</param>
	/// <param name="lppropdata">Pointer to the property data.</param>
	/// <param name="dwProperty">
	/// <para>
	/// Flags that specify the action to perform and identify the appropriate property of the MIDI data stream. The
	/// <c>midiStreamProperty</c> function requires setting two flags in each use. One flag (either MIDIPROP_GET or MIDIPROP_SET)
	/// specifies an action, and the other identifies a specific property to examine or edit.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MIDIPROP_GET</term>
	/// <term>Retrieves the current setting of the given property.</term>
	/// </item>
	/// <item>
	/// <term>MIDIPROP_SET</term>
	/// <term>Sets the given property.</term>
	/// </item>
	/// <item>
	/// <term>MIDIPROP_TEMPO</term>
	/// <term>
	/// Retrieves the tempo property. The lppropdata parameter points to a MIDIPROPTEMPO structure. The current tempo value can be
	/// retrieved at any time. Output devices set the tempo by inserting MEVT_TEMPO events into the MIDI data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MIDIPROP_TIMEDIV</term>
	/// <term>
	/// Specifies the time division property. You can get or set this property. The lppropdata parameter points to a MIDIPROPTIMEDIV
	/// structure. This property can be set only when the device is stopped.
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
	/// <term>MMSYSERR_INVALHANDLE</term>
	/// <term>The specified handle is not a stream handle.</term>
	/// </item>
	/// <item>
	/// <term>MMSYSERR_INVALPARAM</term>
	/// <term>The given handle or flags parameter is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// These properties are the default properties defined by the system. Driver writers can implement and document their own properties.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midistreamproperty MMRESULT midiStreamProperty( HMIDISTRM
	// hms, LPBYTE lppropdata, DWORD dwProperty );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiStreamProperty")]
	public static extern MMRESULT midiStreamProperty([In] HMIDISTRM hms, IntPtr lppropdata, MIDIPROP dwProperty);

	/// <summary>The <c>midiStreamRestart</c> function restarts a paused MIDI stream.</summary>
	/// <param name="hms">
	/// Handle to a MIDI stream. This handle must have been returned by a call to the midiStreamOpen function. This handle identifies
	/// the output device.
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
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>Calling this function when the output is not paused has no effect, and the function returns MMSYSERR_NOERROR.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midistreamrestart MMRESULT midiStreamRestart( HMIDISTRM hms );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiStreamRestart")]
	public static extern MMRESULT midiStreamRestart([In] HMIDISTRM hms);

	/// <summary>The <c>midiStreamStop</c> function turns off all notes on all MIDI channels for the specified MIDI output device.</summary>
	/// <param name="hms">
	/// Handle to a MIDI stream. This handle must have been returned by a call to the midiStreamOpen function. This handle identifies
	/// the output device.
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
	/// <term>The specified device handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When you call this function, any pending system-exclusive or stream output buffers are returned to the callback mechanism and
	/// the MHDR_DONE bit is set in the <c>dwFlags</c> member of the MIDIHDR structure.
	/// </para>
	/// <para>
	/// While the midiOutReset function turns off all notes, <c>midiStreamStop</c> turns off only those notes that have been turned on
	/// by a MIDI note-on message.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/nf-mmeapi-midistreamstop MMRESULT midiStreamStop( HMIDISTRM hms );
	[DllImport(Lib_Winmm, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mmeapi.h", MSDNShortId = "NF:mmeapi.midiStreamStop")]
	public static extern MMRESULT midiStreamStop([In] HMIDISTRM hms);

	/// <summary>The MIDIEVENT structure describes a MIDI event in a stream buffer.</summary>
	/// <remarks>
	/// <para>
	/// The high byte of <c>dwEvent</c> contains flags and an event code. Either the MEVT_F_LONG or MEVT_F_SHORT flag must be specified.
	/// The MEVT_F_CALLBACK flag is optional. The following table describes these flags.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MEVT_F_CALLBACK</term>
	/// <term>The system generates a callback when the event is about to be executed.</term>
	/// </item>
	/// <item>
	/// <term>MEVT_F_LONG</term>
	/// <term>The event is a long event. The low 24 bits of dwEvent contain the length of the event parameters included in dwParms.</term>
	/// </item>
	/// <item>
	/// <term>MEVT_F_SHORT</term>
	/// <term>The event is a short event. The event parameters are contained in the low 24 bits of dwEvent.</term>
	/// </item>
	/// </list>
	/// <para>The remainder of the high byte contains one of the following event codes:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Event Code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MEVT_COMMENT</term>
	/// <term>
	/// Long event. The event data will be ignored. This event is intended to store commentary information about the stream that might
	/// be useful to authoring programs or sequencers if the stream data were to be stored in a file in stream format. In a buffer of
	/// this data, the zero byte identifies the comment class and subsequent bytes contain the comment data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MEVT_LONGMSG</term>
	/// <term>
	/// Long event. The event data is transmitted verbatim. The event data is assumed to be system-exclusive data; that is, running
	/// status will be cleared when the event is executed and running status from any previous events will not be applied to any channel
	/// events in the event data. Using this event to send a group of channel messages at the same time is not recommended; a set of
	/// MEVT_SHORTMSG events with zero delta times should be used instead.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MEVT_NOP</term>
	/// <term>
	/// Short event. This event is a placeholder; it does nothing. The low 24 bits are ignored. This event will still generate a
	/// callback if MEVT_F_CALLBACK is set in dwEvent.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MEVT_SHORTMSG</term>
	/// <term>
	/// Short event. The data in the low 24 bits of dwEvent is a MIDI short message. (For a description of how a short message is packed
	/// into a DWORD value, see the midiOutShortMsg function.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>MEVT_TEMPO</term>
	/// <term>
	/// Short event. The data in the low 24 bits of dwEvent contain the new tempo for following events. The tempo is specified in the
	/// same format as it is for the tempo change meta-event in a MIDI file — that is, in microseconds per quarter note. (This event
	/// will have no affect if the time format specified for the stream is SMPTE time.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>MEVT_VERSION</term>
	/// <term>Long event. The event data must contain a MIDISTRMBUFFVER structure.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-midievent typedef struct midievent_tag { DWORD dwDeltaTime;
	// DWORD dwStreamID; DWORD dwEvent; DWORD dwParms[1]; } MIDIEVENT;
	[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.midievent_tag")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct MIDIEVENT
	{
		/// <summary>
		/// Time, in MIDI ticks, between the previous event and the current event. The length of a tick is defined by the time format
		/// and possibly the tempo associated with the stream. (The definition is identical to the specification for a tick in a
		/// standard MIDI file.)
		/// </summary>
		public uint dwDeltaTime;

		/// <summary>Reserved; must be zero.</summary>
		public uint dwStreamID;

		/// <summary>
		/// Event code and event parameters or length. To parse this information, use the MEVT_EVENTTYPE and MEVT_EVENTPARM macros. See Remarks.
		/// </summary>
		public uint dwEvent;

		/// <summary>
		/// <para>
		/// If <c>dwEvent</c> specifies MEVT_F_LONG and the length of the buffer, this member contains parameters for the event. This
		/// parameter data must be padded with zeros so that an integral number of <c>DWORD</c> values are stored. For example, if the
		/// event data is five bytes long, three pad bytes must follow the data for a total of eight bytes. In this case, the low 24
		/// bits of <c>dwEvent</c> would contain the value 5.
		/// </para>
		/// <para>If <c>dwEvent</c> specifies MEVT_F_SHORT, do not use this member in the stream buffer.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public uint[] dwParms;

		/// <summary>Retrieves the event type from the value specified in the dwEvent member of a MIDIEVENT structure.</summary>
		public byte EventType => (byte)(((dwEvent) >> 24) & 0xFF);

		/// <summary>Retrieves the event parameters or length from the value specified in the dwEvent member of a MIDIEVENT structure.</summary>
		public uint EventParm => (dwEvent) & 0x00FFFFFF;
	}

	/// <summary>The <c>MIDIHDR</c> structure defines the header used to identify a MIDI system-exclusive or stream buffer.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-midihdr typedef struct midihdr_tag { StrPtrAnsi lpData; DWORD
	// dwBufferLength; DWORD dwBytesRecorded; DWORD_PTR dwUser; DWORD dwFlags; struct midihdr_tag *lpNext; DWORD_PTR reserved; DWORD
	// dwOffset; DWORD_PTR dwReserved[8]; } MIDIHDR, *PMIDIHDR, *NPMIDIHDR, *LPMIDIHDR;
	[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.midihdr_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MIDIHDR
	{
		/// <summary>Pointer to MIDI data.</summary>
		public IntPtr lpData;

		/// <summary>Size of the buffer.</summary>
		public uint dwBufferLength;

		/// <summary>
		/// Actual amount of data in the buffer. This value should be less than or equal to the value given in the <c>dwBufferLength</c> member.
		/// </summary>
		public uint dwBytesRecorded;

		/// <summary>Custom user data.</summary>
		public IntPtr dwUser;

		/// <summary>
		/// <para>Flags giving information about the buffer.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MHDR_DONE</term>
		/// <term>Set by the device driver to indicate that it is finished with the buffer and is returning it to the application.</term>
		/// </item>
		/// <item>
		/// <term>MHDR_INQUEUE</term>
		/// <term>Set by Windows to indicate that the buffer is queued for playback.</term>
		/// </item>
		/// <item>
		/// <term>MHDR_ISSTRM</term>
		/// <term>Set to indicate that the buffer is a stream buffer.</term>
		/// </item>
		/// <item>
		/// <term>MHDR_PREPARED</term>
		/// <term>
		/// Set by Windows to indicate that the buffer has been prepared by using the midiInPrepareHeader or midiOutPrepareHeader function.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public MHDR dwFlags;

		/// <summary>Reserved; do not use.</summary>
		public IntPtr lpNext;

		/// <summary>Reserved; do not use.</summary>
		public IntPtr reserved;

		/// <summary>
		/// Offset into the buffer when a callback is performed. (This callback is generated because the MEVT_F_CALLBACK flag is set in
		/// the <c>dwEvent</c> member of the MIDIEVENT structure.) This offset enables an application to determine which event caused
		/// the callback.
		/// </summary>
		public uint dwOffset;

		/// <summary>Reserved; do not use.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public IntPtr[] dwReserved;

		/// <summary>Gets the native size of this structure.</summary>
		public static uint NativeSize = unchecked((uint)Marshal.SizeOf(typeof(MIDIHDR)));
	}

	/// <summary>The <c>MIDIINCAPS</c> structure describes the capabilities of a MIDI input device.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-midiincaps typedef struct midiincaps_tag { WORD wMid; WORD
	// wPid; VERSION vDriverVersion; char szPname[MAXPNAMELEN]; DWORD dwSupport; } MIDIINCAPS, *PMIDIINCAPS, *NPMIDIINCAPS, *LPMIDIINCAPS;
	[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.midiincaps_tag")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct MIDIINCAPS
	{
		/// <summary>
		/// Manufacturer identifier of the device driver for the MIDI input device. Manufacturer identifiers are defined in Manufacturer
		/// and Product Identifiers.
		/// </summary>
		public ushort wMid;

		/// <summary>Product identifier of the MIDI input device. Product identifiers are defined in Manufacturer and Product Identifiers.</summary>
		public ushort wPid;

		/// <summary>
		/// Version number of the device driver for the MIDI input device. The high-order byte is the major version number, and the
		/// low-order byte is the minor version number.
		/// </summary>
		public uint vDriverVersion;

		/// <summary>Product name in a null-terminated string.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAXPNAMELEN)]
		public string szPname;

		/// <summary>Reserved; must be zero.</summary>
		public uint dwSupport;

		/// <summary>Gets the native size of this structure.</summary>
		public static uint NativeSize = unchecked((uint)Marshal.SizeOf(typeof(MIDIINCAPS)));
	}

	/// <summary>The <c>MIDIOUTCAPS</c> structure describes the capabilities of a MIDI output device.</summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The mmeapi.h header defines MIDIOUTCAPS as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-midioutcapsw typedef struct tagMIDIOUTCAPSW { WORD wMid; WORD
	// wPid; MMVERSION vDriverVersion; WCHAR szPname[MAXPNAMELEN]; WORD wTechnology; WORD wVoices; WORD wNotes; WORD wChannelMask; DWORD
	// dwSupport; } MIDIOUTCAPSW, *PMIDIOUTCAPSW, *NPMIDIOUTCAPSW, *LPMIDIOUTCAPSW;
	[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.tagMIDIOUTCAPSW")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct MIDIOUTCAPS
	{
		/// <summary>
		/// Manufacturer identifier of the device driver for the MIDI output device. Manufacturer identifiers are defined in
		/// Manufacturer and Product Identifiers.
		/// </summary>
		public ushort wMid;

		/// <summary>Product identifier of the MIDI output device. Product identifiers are defined in Manufacturer and Product Identifiers.</summary>
		public ushort wPid;

		/// <summary>
		/// Version number of the device driver for the MIDI output device. The high-order byte is the major version number, and the
		/// low-order byte is the minor version number.
		/// </summary>
		public uint vDriverVersion;

		/// <summary>Product name in a null-terminated string.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAXPNAMELEN)]
		public string szPname;

		/// <summary>
		/// <para>Type of the MIDI output device. This value can be one of the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MOD_MIDIPORT</term>
		/// <term>MIDI hardware port.</term>
		/// </item>
		/// <item>
		/// <term>MOD_SYNTH</term>
		/// <term>Synthesizer.</term>
		/// </item>
		/// <item>
		/// <term>MOD_SQSYNTH</term>
		/// <term>Square wave synthesizer.</term>
		/// </item>
		/// <item>
		/// <term>MOD_FMSYNTH</term>
		/// <term>FM synthesizer.</term>
		/// </item>
		/// <item>
		/// <term>MOD_MAPPER</term>
		/// <term>Microsoft MIDI mapper.</term>
		/// </item>
		/// <item>
		/// <term>MOD_WAVETABLE</term>
		/// <term>Hardware wavetable synthesizer.</term>
		/// </item>
		/// <item>
		/// <term>MOD_SWSYNTH</term>
		/// <term>Software synthesizer.</term>
		/// </item>
		/// </list>
		/// </summary>
		public MOD wTechnology;

		/// <summary>
		/// Number of voices supported by an internal synthesizer device. If the device is a port, this member is not meaningful and is
		/// set to 0.
		/// </summary>
		public ushort wVoices;

		/// <summary>
		/// Maximum number of simultaneous notes that can be played by an internal synthesizer device. If the device is a port, this
		/// member is not meaningful and is set to 0.
		/// </summary>
		public ushort wNotes;

		/// <summary>
		/// Channels that an internal synthesizer device responds to, where the least significant bit refers to channel 0 and the most
		/// significant bit to channel 15. Port devices that transmit on all channels set this member to 0xFFFF.
		/// </summary>
		public ushort wChannelMask;

		/// <summary>
		/// <para>Optional functionality supported by the device. It can be one or more of the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>MIDICAPS_CACHE</term>
		/// <term>Supports patch caching.</term>
		/// </item>
		/// <item>
		/// <term>MIDICAPS_LRVOLUME</term>
		/// <term>Supports separate left and right volume control.</term>
		/// </item>
		/// <item>
		/// <term>MIDICAPS_STREAM</term>
		/// <term>Provides direct support for the midiStreamOut function.</term>
		/// </item>
		/// <item>
		/// <term>MIDICAPS_VOLUME</term>
		/// <term>Supports volume control.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If a device supports volume changes, the MIDICAPS_VOLUME flag will be set for the dwSupport member. If a device supports
		/// separate volume changes on the left and right channels, both the MIDICAPS_VOLUME and the MIDICAPS_LRVOLUME flags will be set
		/// for this member.
		/// </para>
		/// </summary>
		public MIDI_CAPS dwSupport;

		/// <summary>Gets the native size of this structure.</summary>
		public static uint NativeSize = unchecked((uint)Marshal.SizeOf(typeof(MIDIOUTCAPS)));
	}

	/// <summary>The <c>MIDIPROPTEMPO</c> structure contains the tempo property for a stream.</summary>
	/// <remarks>The tempo property is read or written by the midiStreamProperty function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-midiproptempo typedef struct midiproptempo_tag { DWORD
	// cbStruct; DWORD dwTempo; } MIDIPROPTEMPO, *LPMIDIPROPTEMPO;
	[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.midiproptempo_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MIDIPROPTEMPO
	{
		/// <summary>
		/// Length, in bytes, of this structure. This member must be filled in for both the MIDIPROP_SET and MIDIPROP_GET operations of
		/// the midiStreamProperty function.
		/// </summary>
		public uint cbStruct;

		/// <summary>
		/// Tempo of the stream, in microseconds per quarter note. The tempo is honored only if the time division for the stream is
		/// specified in quarter note format. This member is set in a MIDIPROP_SET operation and is filled on return from a MIDIPROP_GET operation.
		/// </summary>
		public uint dwTempo;
	}

	/// <summary>The <c>MIDIPROPTIMEDIV</c> structure contains the time division property for a stream.</summary>
	/// <remarks>The time division property is read or written by the midiStreamProperty function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-midiproptimediv typedef struct midiproptimediv_tag { DWORD
	// cbStruct; DWORD dwTimeDiv; } MIDIPROPTIMEDIV, *LPMIDIPROPTIMEDIV;
	[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.midiproptimediv_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MIDIPROPTIMEDIV
	{
		/// <summary>
		/// Length, in bytes, of this structure. This member must be filled in for both the MIDIPROP_SET and MIDIPROP_GET operations of
		/// the midiStreamProperty function.
		/// </summary>
		public uint cbStruct;

		/// <summary>
		/// Time division for this stream, in the format specified in the Standard MIDI Files 1.0 specification. The low 16 bits of this
		/// <c>DWORD</c> value contain the time division. This member is set in a MIDIPROP_SET operation and is filled on return from a
		/// MIDIPROP_GET operation.
		/// </summary>
		public uint dwTimeDiv;
	}

	/// <summary>The <c>MIDISTRMBUFFVER</c> structure contains version information for a long MIDI event of the MEVT_VERSION type.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mmeapi/ns-mmeapi-midistrmbuffver typedef struct midistrmbuffver_tag { DWORD
	// dwVersion; DWORD dwMid; DWORD dwOEMVersion; } MIDISTRMBUFFVER;
	[PInvokeData("mmeapi.h", MSDNShortId = "NS:mmeapi.midistrmbuffver_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MIDISTRMBUFFVER
	{
		/// <summary>
		/// Version of the stream. The high 16 bits contain the major version, and the low 16 bits contain the minor version. The
		/// version number for the first implementation of MIDI streams should be 1.0.
		/// </summary>
		public uint dwVersion;

		/// <summary>Manufacturer identifier. Manufacturer identifiers are defined in Manufacturer and Product Identifiers.</summary>
		public uint dwMid;

		/// <summary>
		/// OEM version of the stream. Original equipment manufacturers can use this field to version-stamp any custom events they have
		/// specified. If a custom event is specified, it must be the first event sent after the stream is opened.
		/// </summary>
		public uint dwOEMVersion;
	}
}