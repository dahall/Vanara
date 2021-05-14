using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Items from the WinMm.dll</summary>
	public static partial class WinMm
	{
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

		/// <summary>Flags for playing the sound.</summary>
		[PInvokeData("Mmsystem.h")]
		[Flags]
		public enum SND : uint
		{
			/// <summary>
			/// The sound is played synchronously, and PlaySound returns after the sound event completes. This is the default behavior.
			/// </summary>
			SND_SYNC = 0x0000,

			/// <summary>
			/// The sound is played asynchronously and PlaySound returns immediately after beginning the sound. To terminate an
			/// asynchronously played waveform sound, call PlaySound with pszSound set to NULL.
			/// </summary>
			SND_ASYNC = 0x0001,

			/// <summary>
			/// No default sound event is used. If the sound cannot be found, PlaySound returns silently without playing the default sound.
			/// </summary>
			SND_NODEFAULT = 0x0002,

			/// <summary>The pszSound parameter points to a sound loaded in memory. For more information, see Playing WAVE Resources.</summary>
			SND_MEMORY = 0x0004,

			/// <summary>
			/// The sound plays repeatedly until PlaySound is called again with the pszSound parameter set to NULL. If this flag is set, you
			/// must also set the SND_ASYNC flag.
			/// </summary>
			SND_LOOP = 0x0008,

			/// <summary>
			/// The specified sound event will yield to another sound event that is already playing in the same process. If a sound cannot
			/// be played because the resource needed to generate that sound is busy playing another sound, the function immediately returns
			/// FALSE without playing the requested sound. If this flag is not specified, PlaySound attempts to stop any sound that is
			/// currently playing in the same process. Sounds played in other processes are not affected.
			/// </summary>
			SND_NOSTOP = 0x0010,

			/// <summary>
			/// Not supported. Note Previous versions of the documentation implied incorrectly that this flag is supported. The function
			/// ignores this flag.
			/// </summary>
			SND_NOWAIT = 0x00002000,

			/// <summary>
			/// The pszSound parameter is a system-event alias in the registry or the WIN.INI file. Do not use with either SND_FILENAME or SND_RESOURCE.
			/// </summary>
			SND_ALIAS = 0x00010000,

			/// <summary>The pszSound parameter is a predefined identifier for a system-event alias. See Remarks.</summary>
			SND_ALIAS_ID = 0x00110000,

			/// <summary>
			/// The pszSound parameter is a file name. If the file cannot be found, the function plays the default sound unless the
			/// SND_NODEFAULT flag is set.
			/// </summary>
			SND_FILENAME = 0x00020000,

			/// <summary>
			/// The pszSound parameter is a resource identifier; hmod must identify the instance that contains the resource. For more
			/// information, see Playing WAVE Resources.
			/// </summary>
			SND_RESOURCE = 0x00040004,

			/// <summary>Not supported.</summary>
			SND_PURGE = 0x0040,

			/// <summary>
			/// The pszSound parameter is an application-specific alias in the registry. You can combine this flag with the SND_ALIAS or
			/// SND_ALIAS_ID flag to specify an application-defined sound alias.
			/// </summary>
			SND_APPLICATION = 0x0080,

			/// <summary>
			/// Note Requires Windows Vista or later. If this flag is set, the function triggers a SoundSentry event when the sound is
			/// played. SoundSentry is an accessibility feature that causes the computer to display a visual cue when a sound is played. If
			/// the user did not enable SoundSentry, the visual cue is not displayed.
			/// </summary>
			SND_SENTRY = 0x00080000,

			/// <summary>Treat this as a "ring" from a communications app - don't duck me</summary>
			SND_RING = 0x00100000,

			/// <summary>
			/// Note Requires Windows Vista or later. If this flag is set, the sound is assigned to the audio session for system
			/// notification sounds. The system volume-control program (SndVol) displays a volume slider that controls system notification
			/// sounds. Setting this flag puts the sound under the control of that volume slider If this flag is not set, the sound is
			/// assigned to the default audio session for the application's process. For more information, see the documentation for the
			/// Core Audio APIs.
			/// </summary>
			SND_SYSTEM = 0x00200000,
		}

		/// <summary>Makes a four character code.</summary>
		/// <param name="ch0">The first character.</param>
		/// <param name="ch1">The second character.</param>
		/// <param name="ch2">The third character.</param>
		/// <param name="ch3">The fourth character.</param>
		/// <returns>The character code.</returns>
		public static uint MAKEFOURCC(char ch0, char ch1, char ch2, char ch3) => (byte)ch0 | ((uint)(byte)ch1 << 8) |
			((uint)(byte)ch2 << 16) | ((uint)(byte)ch3 << 24);

		/// <summary>
		/// The <c>PlaySound</c> function plays a sound specified by the given file name, resource, or system event. (A system event may be
		/// associated with a sound in the registry or in the WIN.INI file.)
		/// </summary>
		/// <param name="pszSound">
		/// <para>
		/// A string that specifies the sound to play. The maximum length, including the null terminator, is 256 characters. If this
		/// parameter is <c>NULL</c>, any currently playing waveform sound is stopped.
		/// </para>
		/// <para>
		/// Three flags in fdwSound ( <c>SND_ALIAS</c>, <c>SND_FILENAME</c>, and <c>SND_RESOURCE</c>) determine whether the name is
		/// interpreted as an alias for a system event, a file name, or a resource identifier. If none of these flags are specified,
		/// <c>PlaySound</c> searches the registry or the WIN.INI file for an association with the specified sound name. If an association
		/// is found, the sound event is played. If no association is found in the registry, the name is interpreted as a file name.
		/// </para>
		/// </param>
		/// <param name="hmod">
		/// Handle to the executable file that contains the resource to be loaded. This parameter must be <c>NULL</c> unless
		/// <c>SND_RESOURCE</c> is specified in fdwSound.
		/// </param>
		/// <param name="fdwSound">
		/// <para>Flags for playing the sound. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SND_APPLICATION</term>
		/// <term>
		/// The pszSound parameter is an application-specific alias in the registry. You can combine this flag with the SND_ALIAS or
		/// SND_ALIAS_ID flag to specify an application-defined sound alias.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SND_ALIAS</term>
		/// <term>
		/// The pszSound parameter is a system-event alias in the registry or the WIN.INI file. Do not use with either SND_FILENAME or SND_RESOURCE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SND_ALIAS_ID</term>
		/// <term>The pszSound parameter is a predefined identifier for a system-event alias. See Remarks.</term>
		/// </item>
		/// <item>
		/// <term>SND_ASYNC</term>
		/// <term>
		/// The sound is played asynchronously and PlaySound returns immediately after beginning the sound. To terminate an asynchronously
		/// played waveform sound, call PlaySound with pszSound set to NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SND_FILENAME</term>
		/// <term>
		/// The pszSound parameter is a file name. If the file cannot be found, the function plays the default sound unless the
		/// SND_NODEFAULT flag is set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SND_LOOP</term>
		/// <term>
		/// The sound plays repeatedly until PlaySound is called again with the pszSound parameter set to NULL. If this flag is set, you
		/// must also set the SND_ASYNC flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SND_MEMORY</term>
		/// <term>The pszSound parameter points to a sound loaded in memory. For more information, see Playing WAVE Resources.</term>
		/// </item>
		/// <item>
		/// <term>SND_NODEFAULT</term>
		/// <term>No default sound event is used. If the sound cannot be found, PlaySound returns silently without playing the default sound.</term>
		/// </item>
		/// <item>
		/// <term>SND_NOSTOP</term>
		/// <term>
		/// The specified sound event will yield to another sound event that is already playing in the same process. If a sound cannot be
		/// played because the resource needed to generate that sound is busy playing another sound, the function immediately returns FALSE
		/// without playing the requested sound. If this flag is not specified, PlaySound attempts to stop any sound that is currently
		/// playing in the same process. Sounds played in other processes are not affected.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SND_NOWAIT</term>
		/// <term>
		/// Not supported. Note Previous versions of the documentation implied incorrectly that this flag is supported. The function ignores
		/// this flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SND_PURGE</term>
		/// <term>Not supported.</term>
		/// </item>
		/// <item>
		/// <term>SND_RESOURCE</term>
		/// <term>
		/// The pszSound parameter is a resource identifier; hmod must identify the instance that contains the resource. For more
		/// information, see Playing WAVE Resources.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SND_SENTRY</term>
		/// <term>
		/// Note Requires Windows Vista or later. If this flag is set, the function triggers a SoundSentry event when the sound is played.
		/// SoundSentry is an accessibility feature that causes the computer to display a visual cue when a sound is played. If the user did
		/// not enable SoundSentry, the visual cue is not displayed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SND_SYNC</term>
		/// <term>The sound is played synchronously, and PlaySound returns after the sound event completes. This is the default behavior.</term>
		/// </item>
		/// <item>
		/// <term>SND_SYSTEM</term>
		/// <term>
		/// Note Requires Windows Vista or later. If this flag is set, the sound is assigned to the audio session for system notification
		/// sounds. The system volume-control program (SndVol) displays a volume slider that controls system notification sounds. Setting
		/// this flag puts the sound under the control of that volume slider If this flag is not set, the sound is assigned to the default
		/// audio session for the application's process. For more information, see the documentation for the Core Audio APIs.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
		/// <remarks>
		/// <para>
		/// The sound specified by pszSound must fit into available physical memory and be playable by an installed waveform-audio device driver.
		/// </para>
		/// <para>
		/// <c>PlaySound</c> searches the following directories for sound files: the current directory; the Windows directory; the Windows
		/// system directory; directories listed in the PATH environment variable; and the list of directories mapped in a network. If the
		/// function cannot find the specified sound and the <c>SND_NODEFAULT</c> flag is not specified, <c>PlaySound</c> uses the default
		/// system event sound instead. If the function can find neither the system default entry nor the default sound, it makes no sound
		/// and returns <c>FALSE</c>.
		/// </para>
		/// <para>If the <c>SND_ALIAS_ID</c> flag is specified in fdwSound, the pszSound parameter must be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SND_ALIAS_SYSTEMASTERISK</term>
		/// <term>"SystemAsterisk" event.</term>
		/// </item>
		/// <item>
		/// <term>SND_ALIAS_SYSTEMDEFAULT</term>
		/// <term>"SystemDefault" event.</term>
		/// </item>
		/// <item>
		/// <term>SND_ALIAS_SYSTEMEXCLAMATION</term>
		/// <term>"SystemExclamation" event.</term>
		/// </item>
		/// <item>
		/// <term>SND_ALIAS_SYSTEMEXIT</term>
		/// <term>"SystemExit" event.</term>
		/// </item>
		/// <item>
		/// <term>SND_ALIAS_SYSTEMHAND</term>
		/// <term>"SystemHand" event.</term>
		/// </item>
		/// <item>
		/// <term>SND_ALIAS_SYSTEMQUESTION</term>
		/// <term>"SystemQuestion" event.</term>
		/// </item>
		/// <item>
		/// <term>SND_ALIAS_SYSTEMSTART</term>
		/// <term>"SystemStart" event.</term>
		/// </item>
		/// <item>
		/// <term>SND_ALIAS_SYSTEMWELCOME</term>
		/// <term>"SystemWelcome" event.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>SND_ASYNC</c> flag causes <c>PlaySound</c> to return immediately without waiting for the sound to finish playing. If you
		/// combine the <c>SND_MEMORY</c> and <c>SND_ASYNC</c> flags, the memory buffer that contains the sound must remain valid until the
		/// sound has completed playing.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions//dd743680(v=vs.85) BOOL PlaySound( LPCTSTR pszSound, HMODULE hmod, DWORD
		// fdwSound );
		[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Mmsystem.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PlaySound([In, Optional, MarshalAs(UnmanagedType.LPTStr)] string pszSound, [In, Optional] HINSTANCE hmod, [In, Optional] SND fdwSound);

		/// <summary>
		/// The <c>sndPlaySound</c> function plays a waveform sound specified either by a file name or by an entry in the registry or the
		/// WIN.INI file. This function offers a subset of the functionality of the <c>PlaySound</c> function; <c>sndPlaySound</c> is being
		/// maintained for backward compatibility.
		/// </summary>
		/// <param name="lpszSound">
		/// A string that specifies the sound to play. This parameter can be either an entry in the registry or in WIN.INI that identifies a
		/// system sound, or it can be the name of a waveform-audio file. (If the function does not find the entry, the parameter is treated
		/// as a file name.) If this parameter is <c>NULL</c>, any currently playing sound is stopped.
		/// </param>
		/// <param name="fuSound">
		/// <para>Flags for playing the sound. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SND_ASYNC</term>
		/// <term>
		/// The sound is played asynchronously and the function returns immediately after beginning the sound. To terminate an
		/// asynchronously played sound, call sndPlaySound with lpszSound set to NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SND_LOOP</term>
		/// <term>
		/// The sound plays repeatedly until sndPlaySound is called again with the lpszSound parameter set to NULL. You must also specify
		/// the SND_ASYNC flag to loop sounds.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SND_MEMORY</term>
		/// <term>
		/// The parameter specified by lpszSound points to an image of a waveform sound in memory. The data passed must be trusted by the application.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SND_NODEFAULT</term>
		/// <term>If the sound cannot be found, the function returns silently without playing the default sound.</term>
		/// </item>
		/// <item>
		/// <term>SND_NOSTOP</term>
		/// <term>
		/// If a sound is currently playing in the same process, the function immediately returns FALSE, without playing the requested sound.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SND_SENTRY</term>
		/// <term>
		/// Note Requires Windows Vista or later. If this flag is set, the function triggers a SoundSentry event when the sound is played.
		/// For more information, see PlaySound.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SND_SYNC</term>
		/// <term>The sound is played synchronously and the function does not return until the sound ends.</term>
		/// </item>
		/// <item>
		/// <term>SND_SYSTEM</term>
		/// <term>
		/// Note Requires Windows Vista or later. If this flag is set, the sound is assigned to the audio session for system notification
		/// sounds. For more information, see PlaySound.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
		/// <remarks>
		/// <para>
		/// If the specified sound cannot be found, <c>sndPlaySound</c> plays the system default sound. If there is no system default entry
		/// in the registry or WIN.INI file, or if the default sound cannot be found, the function makes no sound and returns <c>FALSE</c>.
		/// </para>
		/// <para>
		/// The specified sound must fit in available physical memory and be playable by an installed waveform-audio device driver. If
		/// <c>sndPlaySound</c> does not find the sound in the current directory, the function searches for it using the standard
		/// directory-search order.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/dd798676(v=vs.85) BOOL sndPlaySound( LPCTSTR lpszSound, UINT fuSound );
		[DllImport(Lib_Winmm, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Mmsystem.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool sndPlaySound([In, Optional] string lpszSound, uint fuSound);

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
		}
	}
}