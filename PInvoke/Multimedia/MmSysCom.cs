namespace Vanara.PInvoke;

public static partial class WinMm
{
	/// <summary>max oem vxd name length (including NULL)</summary>
	public const int MAX_JOYSTICKOEMVXDNAME = 260;

	/// <summary>max error text length (including NULL)</summary>
	public const int MAXERRORLENGTH = 256;

	/// <summary>max product name length (including NULL)</summary>
	public const int MAXPNAMELEN = 32;

	/// <summary>Microsoft Corporation</summary>
	public const ushort MM_MICROSOFT = 1;

	internal const int JOYERR_BASE = 160;
	internal const int MCIERR_BASE = 256;
	internal const int MIDIERR_BASE = 64;
	internal const int MIXERR_BASE = 1024;
	internal const int MMSYSERR_BASE = 0;
	internal const int TIMERR_BASE = 96;
	internal const int WAVERR_BASE = 32;

	/// <summary>
	/// The <c>DRVCALLBACK</c> function is the callback function used with the waveform-audio input device. This function is a
	/// placeholder for the application-defined function name. The address of this function can be specified in the callback-address
	/// parameter of the <c>waveInOpen</c> function.
	/// </summary>
	/// <param name="hdrvr">Handle to the waveform-audio device associated with the callback function.</param>
	/// <param name="uMsg">
	/// <para>Waveform-audio input message. It can be one of the following messages.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WIM_CLOSE</term>
	/// <term>Sent when the device is closed using the waveInClose function.</term>
	/// </item>
	/// <item>
	/// <term>WIM_DATA</term>
	/// <term>Sent when the device driver is finished with a data block sent using the waveInAddBuffer function.</term>
	/// </item>
	/// <item>
	/// <term>WIM_OPEN</term>
	/// <term>Sent when the device is opened using the waveInOpen function.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwUser">User instance data specified with <c>waveInOpen</c>.</param>
	/// <param name="dwParam1">Message parameter.</param>
	/// <param name="dwParam2">Message parameter.</param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// Applications should not call any system-defined functions from inside a callback function, except for
	/// <c>EnterCriticalSection</c>, <c>LeaveCriticalSection</c>, <c>midiOutLongMsg</c>, <c>midiOutShortMsg</c>,
	/// <c>OutputDebugString</c>, <c>PostMessage</c>, <c>PostThreadMessage</c>, <c>SetEvent</c>, <c>timeGetSystemTime</c>,
	/// <c>timeGetTime</c>, <c>timeKillEvent</c>, and <c>timeSetEvent.</c> Calling other wave functions will cause deadlock.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/dd743849(v=vs.85) void CALLBACK waveInProc( HWAVEIN hwi, UINT uMsg, DWORD_PTR
	// dwInstance, DWORD_PTR dwParam1, DWORD_PTR dwParam2 );
	[PInvokeData("mmsyscon.h")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DRVCALLBACK(IntPtr hdrvr, uint uMsg, IntPtr dwUser, IntPtr dwParam1, IntPtr dwParam2);

	/// <summary>
	/// Flags used with waveOutOpen(), waveInOpen(), midiInOpen(), and midiOutOpen() to specify the type of the dwCallback parameter.
	/// </summary>
	[PInvokeData("mmsyscom.h", MSDNShortId = "NF:mmeapi.waveInOpen")]
	[Flags]
	public enum CALLBACK_FLAGS : uint
	{
		/// <summary>No callback mechanism. This is the default setting.</summary>
		CALLBACK_NULL = 0x00000000,

		/// <summary>The dwCallback parameter is a window handle.</summary>
		CALLBACK_WINDOW = 0x00010000,

		/// <summary>The dwCallback parameter is a task handle.</summary>
		CALLBACK_TASK = 0x00020000,

		/// <summary>The dwCallback parameter is a callback procedure address.</summary>
		CALLBACK_FUNCTION = 0x00030000,

		/// <summary>The dwCallback parameter is a thread identifier.</summary>
		CALLBACK_THREAD = CALLBACK_TASK,

		/// <summary>The dwCallback parameter is an event handle.</summary>
		CALLBACK_EVENT = 0x00050000,
	}

	/// <summary>Microsoft Corporation Product Identifiers</summary>
	[PInvokeData("mmsyscon.h")]
	public enum MMPRODID : ushort
	{
		/// <summary>MIDI Mapper</summary>
		MM_MIDI_MAPPER = 1,

		/// <summary>Wave Mapper</summary>
		MM_WAVE_MAPPER = 2,

		/// <summary>Sound Blaster MIDI output port</summary>
		MM_SNDBLST_MIDIOUT = 3,

		/// <summary>Sound Blaster MIDI input port</summary>
		MM_SNDBLST_MIDIIN = 4,

		/// <summary>Sound Blaster internal synthesizer</summary>
		MM_SNDBLST_SYNTH = 5,

		/// <summary>Sound Blaster waveform output</summary>
		MM_SNDBLST_WAVEOUT = 6,

		/// <summary>Sound Blaster waveform input</summary>
		MM_SNDBLST_WAVEIN = 7,

		/// <summary>Ad Lib-compatible synthesizer</summary>
		MM_ADLIB = 9,

		/// <summary>MPU401-compatible MIDI output port</summary>
		MM_MPU401_MIDIOUT = 10,

		/// <summary>MPU401-compatible MIDI input port</summary>
		MM_MPU401_MIDIIN = 11,

		/// <summary>Joystick adapter</summary>
		MM_PC_JOYSTICK = 12,
	}

	/// <summary>Multimedia function result codes.</summary>
	[PInvokeData("mmsyscon.h")]
	public enum MMRESULT
	{
		/// <summary>no error</summary>
		MMSYSERR_NOERROR = 0,

		/// <summary>unspecified error</summary>
		MMSYSERR_ERROR = MMSYSERR_BASE + 1,

		/// <summary>Specified device identifier is out of range.</summary>
		MMSYSERR_BADDEVICEID = MMSYSERR_BASE + 2,

		/// <summary>driver failed enable</summary>
		MMSYSERR_NOTENABLED = MMSYSERR_BASE + 3,

		/// <summary>Specified resource is already allocated.</summary>
		MMSYSERR_ALLOCATED = MMSYSERR_BASE + 4,

		/// <summary>Specified device handle is invalid.</summary>
		MMSYSERR_INVALHANDLE = MMSYSERR_BASE + 5,

		/// <summary>No device driver is present.</summary>
		MMSYSERR_NODRIVER = MMSYSERR_BASE + 6,

		/// <summary>Unable to allocate or lock memory.</summary>
		MMSYSERR_NOMEM = MMSYSERR_BASE + 7,

		/// <summary>function isn't supported</summary>
		MMSYSERR_NOTSUPPORTED = MMSYSERR_BASE + 8,

		/// <summary>Specified error number is out of range.</summary>
		MMSYSERR_BADERRNUM = MMSYSERR_BASE + 9,

		/// <summary>invalid flag passed</summary>
		MMSYSERR_INVALFLAG = MMSYSERR_BASE + 10,

		/// <summary>invalid parameter passed</summary>
		MMSYSERR_INVALPARAM = MMSYSERR_BASE + 11,

		/// <summary>handle being used simultaneously on another thread (eg callback)</summary>
		MMSYSERR_HANDLEBUSY = MMSYSERR_BASE + 12,

		/// <summary>specified alias not found</summary>
		MMSYSERR_INVALIDALIAS = MMSYSERR_BASE + 13,

		/// <summary>bad registry database</summary>
		MMSYSERR_BADDB = MMSYSERR_BASE + 14,

		/// <summary>registry key not found</summary>
		MMSYSERR_KEYNOTFOUND = MMSYSERR_BASE + 15,

		/// <summary>registry read error</summary>
		MMSYSERR_READERROR = MMSYSERR_BASE + 16,

		/// <summary>registry write error</summary>
		MMSYSERR_WRITEERROR = MMSYSERR_BASE + 17,

		/// <summary>registry delete error</summary>
		MMSYSERR_DELETEERROR = MMSYSERR_BASE + 18,

		/// <summary>registry value not found</summary>
		MMSYSERR_VALNOTFOUND = MMSYSERR_BASE + 19,

		/// <summary>driver does not call DriverCallback</summary>
		MMSYSERR_NODRIVERCB = MMSYSERR_BASE + 20,

		/// <summary>more data to be returned</summary>
		MMSYSERR_MOREDATA = MMSYSERR_BASE + 21,

		/// <summary>Attempted to open with an unsupported waveform-audio format.</summary>
		WAVERR_BADFORMAT = WAVERR_BASE + 0,

		/// <summary>There are still buffers in the queue.</summary>
		WAVERR_STILLPLAYING = WAVERR_BASE + 1,

		/// <summary>The buffer pointed to by the pwh parameter hasn't been prepared.</summary>
		WAVERR_UNPREPARED = WAVERR_BASE + 2,

		/// <summary>device is synchronous</summary>
		WAVERR_SYNC = WAVERR_BASE + 3,

		/// <summary>last error in range</summary>
		WAVERR_LASTERROR = WAVERR_BASE + 3,

		/// <summary>header not prepared</summary>
		MIDIERR_UNPREPARED = MIDIERR_BASE + 0,

		/// <summary>still something playing</summary>
		MIDIERR_STILLPLAYING = MIDIERR_BASE + 1,

		/// <summary>no configured instruments</summary>
		MIDIERR_NOMAP = MIDIERR_BASE + 2,

		/// <summary>hardware is still busy</summary>
		MIDIERR_NOTREADY = MIDIERR_BASE + 3,

		/// <summary>port no longer connected</summary>
		MIDIERR_NODEVICE = MIDIERR_BASE + 4,

		/// <summary>invalid MIF</summary>
		MIDIERR_INVALIDSETUP = MIDIERR_BASE + 5,

		/// <summary>operation unsupported w/ open mode</summary>
		MIDIERR_BADOPENMODE = MIDIERR_BASE + 6,

		/// <summary>thru device 'eating' a message</summary>
		MIDIERR_DONT_CONTINUE = MIDIERR_BASE + 7,

		/// <summary>last error in range</summary>
		MIDIERR_LASTERROR = MIDIERR_BASE + 7,

		/// <summary></summary>
		MIXERR_INVALLINE = MIXERR_BASE + 0,

		/// <summary></summary>
		MIXERR_INVALCONTROL = MIXERR_BASE + 1,

		/// <summary></summary>
		MIXERR_INVALVALUE = MIXERR_BASE + 2,

		/// <summary></summary>
		MIXERR_LASTERROR = MIXERR_BASE + 2,
	}

	/// <summary>Time format.</summary>
	[PInvokeData("Mmsystem.h")]
	public enum MMTIME_TYPE
	{
		/// <summary>time in milliseconds</summary>
		TIME_MS = 0x0001,

		/// <summary>number of wave samples</summary>
		TIME_SAMPLES = 0x0002,

		/// <summary>current byte offset</summary>
		TIME_BYTES = 0x0004,

		/// <summary>SMPTE time</summary>
		TIME_SMPTE = 0x0008,

		/// <summary>MIDI time</summary>
		TIME_MIDI = 0x0010,

		/// <summary>Ticks within MIDI stream</summary>
		TIME_TICKS = 0x0020,
	}

	/// <summary>Makes a four character code.</summary>
	/// <param name="ch0">The first character.</param>
	/// <param name="ch1">The second character.</param>
	/// <param name="ch2">The third character.</param>
	/// <param name="ch3">The fourth character.</param>
	/// <returns>The character code.</returns>
	[PInvokeData("mmsyscon.h")]
	public static uint MAKEFOURCC(char ch0, char ch1, char ch2, char ch3) => (byte)ch0 | ((uint)(byte)ch1 << 8) |
		((uint)(byte)ch2 << 16) | ((uint)(byte)ch3 << 24);

	/// <summary>Makes a four character code.</summary>
	/// <param name="chars">The four character code.</param>
	/// <returns>The character code.</returns>
	[PInvokeData("mmsyscon.h")]
	public static uint MAKEFOURCC(string chars)
	{
		if (chars is null || chars.Length != 4)
			throw new ArgumentException("The character code was not a four-character string.");
		return MAKEFOURCC(chars[0], chars[1], chars[2], chars[3]);
	}

	/// <summary>Multimedia time.</summary>
	// https://docs.microsoft.com/en-us/previous-versions/dd757347(v=vs.85) typedef struct mmtime_tag { UINT wType; union { DWORD ms;
	// DWORD sample; DWORD cb; DWORD ticks; struct { BYTE hour; BYTE min; BYTE sec; BYTE frame; BYTE fps; BYTE dummy; BYTE pad[2]; }
	// smpte; struct { DWORD songptrpos; } midi; } u; } MMTIME, *PMMTIME, *LPMMTIME;
	[PInvokeData("Mmsystem.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MMTIME
	{
		/// <summary>Time format.</summary>
		public MMTIME_TYPE wType;

		/// <summary>The value.</summary>
		public uint u;

		/// <summary>Gets the native size of this structure.</summary>
		public static uint NativeSize = unchecked((uint)Marshal.SizeOf(typeof(MMTIME)));
	}
}