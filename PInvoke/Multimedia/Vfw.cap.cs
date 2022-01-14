#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Runtime.InteropServices;
using System.Text;
using static Vanara.PInvoke.WinMm;

namespace Vanara.PInvoke
{
	/// <summary>Items from the Vfw32.dll</summary>
	public static partial class Vfw32
	{
		private const string Lib_Avicap32 = "avicap32.dll";

		/// <summary>
		/// <para>
		/// The <c>capControlCallback</c> function is the callback function used for precision control to begin and end streaming capture.
		/// The name <c>capControlCallback</c> is a placeholder for the application-supplied function name.
		/// </para>
		/// <para>
		/// To set the callback, send the WM_CAP_SET_CALLBACK_CAPCONTROL message to the capture window or call the
		/// capSetCallbackOnCapControl macro.
		/// </para>
		/// </summary>
		/// <param name="hWnd">Handle to the capture window associated with the callback function.</param>
		/// <param name="nState">
		/// Current state of the capture operation. The CONTROLCALLBACK_PREROLL value is sent initially to enable prerolling of the video
		/// sources and to return control to the capture application at the exact moment recording is to begin. The
		/// CONTROLCALLBACK_CAPTURING value is sent once per captured frame to indicate that streaming capture is in progress and to enable
		/// the application to end capture.
		/// </param>
		/// <returns>
		/// When nState is set to CONTROLCALLBACK_PREROLL, this callback function must return <c>TRUE</c> to start capture or <c>FALSE</c>
		/// to abort it. When nState is set to CONTROLCALLBACK_CAPTURING, this callback function must return <c>TRUE</c> to continue capture
		/// or <c>FALSE</c> to end it.
		/// </returns>
		/// <remarks>
		/// The first message sent to the callback procedure sets the nState parameter to CONTROLCALLBACK_PREROLL after allocating all
		/// buffers and all other capture preparations are complete.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nc-vfw-capcontrolcallback CAPCONTROLCALLBACK Capcontrolcallback; LRESULT
		// Capcontrolcallback( HWND hWnd, int nState ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("vfw.h", MSDNShortId = "NC:vfw.CAPCONTROLCALLBACK")]
		public delegate IntPtr capControlCallback(HWND hWnd, CONTROLCALLBACK nState);

		/// <summary>
		/// <para>
		/// The <c>capErrorCallback</c> function is the error callback function used with video capture. The name <c>capErrorCallback</c> is
		/// a placeholder for the application-supplied function name.
		/// </para>
		/// <para>
		/// To set the callback, send the WM_CAP_SET_CALLBACK_ERROR message to the capture window or call the capSetCallbackOnError macro.
		/// </para>
		/// </summary>
		/// <param name="hWnd">Handle to the capture window associated with the callback function.</param>
		/// <param name="nID">Error identification number.</param>
		/// <param name="lpsz">Pointer to a textual description of the returned error.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// A message identifier of zero indicates a new operation is starting and the callback function should clear the current error.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The vfw.h header defines CAPERRORCALLBACK as an alias which automatically selects the ANSI or Unicode version of this function
		/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
		/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
		/// Function Prototypes.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nc-vfw-caperrorcallbacka CAPERRORCALLBACKA Caperrorcallbacka; LRESULT
		// Caperrorcallbacka( HWND hWnd, int nID, LPCSTR lpsz ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("vfw.h", MSDNShortId = "NC:vfw.CAPERRORCALLBACKA")]
		public delegate IntPtr capErrorCallback(HWND hWnd, int nID, [MarshalAs(UnmanagedType.LPTStr)] string lpsz);

		/// <summary>
		/// <para>
		/// The <c>capStatusCallback</c> function is the status callback function used with video capture. The name <c>capStatusCallback</c>
		/// is a placeholder for the application-supplied function name.
		/// </para>
		/// <para>
		/// To set the callback, send the WM_CAP_SET_CALLBACK_STATUS message to the capture window or call the capSetCallbackOnStatus macro.
		/// </para>
		/// </summary>
		/// <param name="hWnd">Handle to the capture window associated with the callback function.</param>
		/// <param name="nID">Message identification number.</param>
		/// <param name="lpsz">Pointer to a textual description of the returned status.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// During capture operations, the first message sent to the callback function is always IDS_CAP_BEGIN and the last is always
		/// IDS_CAP_END. A message identifier of zero indicates a new operation is starting and the callback function should clear the
		/// current status.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The vfw.h header defines CAPSTATUSCALLBACK as an alias which automatically selects the ANSI or Unicode version of this function
		/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
		/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
		/// Function Prototypes.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nc-vfw-capstatuscallbacka CAPSTATUSCALLBACKA Capstatuscallbacka; LRESULT
		// Capstatuscallbacka( HWND hWnd, int nID, LPCSTR lpsz ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("vfw.h", MSDNShortId = "NC:vfw.CAPSTATUSCALLBACKA")]
		public delegate IntPtr capStatusCallback(HWND hWnd, int nID, [MarshalAs(UnmanagedType.LPTStr)] string lpsz);

		/// <summary>
		/// <para>
		/// The <c>capVideoStreamCallback</c> function is the callback function used with streaming capture to optionally process a frame of
		/// captured video. The name <c>capVideoStreamCallback</c> is a placeholder for the application-supplied function name.
		/// </para>
		/// <para>
		/// To set this callback for streaming capture, send the WM_CAP_SET_CALLBACK_VIDEOSTREAM message to the capture window or call the
		/// capSetCallbackOnVideoStream macro.
		/// </para>
		/// <para>
		/// To set this callback for preview frame capture, send the WM_CAP_SET_CALLBACK_FRAME message to the capture window or call the
		/// capSetCallbackOnFrame macro.
		/// </para>
		/// </summary>
		/// <param name="hWnd">Handle to the capture window associated with the callback function.</param>
		/// <param name="lpVHdr">Pointer to a VIDEOHDR structure containing information about the captured frame.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// The capture window calls a video stream callback function when a video buffer is marked done by the capture driver. When
		/// capturing to disk, this will precede the disk write operation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nc-vfw-capvideocallback CAPVIDEOCALLBACK Capvideocallback; LRESULT
		// Capvideocallback( HWND hWnd, LPVIDEOHDR lpVHdr ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("vfw.h", MSDNShortId = "NC:vfw.CAPVIDEOCALLBACK")]
		public delegate IntPtr capVideoStreamCallback(HWND hWnd, in VIDEOHDR lpVHdr);

		/// <summary>
		/// <para>
		/// The <c>capWaveStreamCallback</c> function is the callback function used with streaming capture to optionally process buffers of
		/// audio data. The name <c>capWaveStreamCallback</c> is a placeholder for the application-supplied function name.
		/// </para>
		/// <para>
		/// To set the callback, send the WM_CAP_SET_CALLBACK_WAVESTREAM message to the capture window or call the
		/// capSetCallbackOnWaveStream macro.
		/// </para>
		/// </summary>
		/// <param name="hWnd">Handle to the capture window associated with the callback function.</param>
		/// <param name="lpWHdr">Pointer to a WAVEHDR structure containing information about the captured audio data.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// The capture window calls a wave stream callback function when an audio buffer is marked done by the waveform-audio driver. When
		/// capturing to disk, this will precede the disk write operation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nc-vfw-capwavecallback CAPWAVECALLBACK Capwavecallback; LRESULT
		// Capwavecallback( HWND hWnd, LPWAVEHDR lpWHdr ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("vfw.h", MSDNShortId = "NC:vfw.CAPWAVECALLBACK")]
		public delegate IntPtr capWaveStreamCallback(HWND hWnd, in WAVEHDR lpWHdr);

		/// <summary>
		/// <para>
		/// The <c>capYieldCallback</c> function is the yield callback function used with video capture. The name <c>capYieldCallback</c> is
		/// a placeholder for the application-supplied function name.
		/// </para>
		/// <para>
		/// To set the callback, send the WM_CAP_SET_CALLBACK_YIELD message to the capture window or call the capSetCallbackOnYield macro.
		/// </para>
		/// </summary>
		/// <param name="hWnd">Handle to the capture window associated with the callback function.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// The capture window calls the yield callback function at least once for every captured video frame, but the exact rate depends on
		/// the frame rate and the overhead of the capture driver and disk.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nc-vfw-capyieldcallback CAPYIELDCALLBACK Capyieldcallback; LRESULT
		// Capyieldcallback( HWND hWnd ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("vfw.h", MSDNShortId = "NC:vfw.CAPYIELDCALLBACK")]
		public delegate IntPtr capYieldCallback(HWND hWnd);

		/// <summary>Window messages for capture drivers.</summary>
		[PInvokeData("vfw.h")]
		public enum capMessage : uint
		{
			/// <summary>start of unicode messages</summary>
			WM_CAP_START = User32.WM_USER,

			/// <summary></summary>
			WM_CAP_UNICODE_START = User32.WM_USER + 100,

			/// <summary></summary>
			WM_CAP_GET_CAPSTREAMPTR = WM_CAP_START + 1,

			/// <summary></summary>
			WM_CAP_SET_CALLBACK_ERRORW = WM_CAP_UNICODE_START + 2,

			/// <summary></summary>
			WM_CAP_SET_CALLBACK_STATUSW = WM_CAP_UNICODE_START + 3,

			/// <summary></summary>
			WM_CAP_SET_CALLBACK_ERRORA = WM_CAP_START + 2,

			/// <summary></summary>
			WM_CAP_SET_CALLBACK_STATUSA = WM_CAP_START + 3,

			/// <summary></summary>
			WM_CAP_SET_CALLBACK_ERROR = WM_CAP_SET_CALLBACK_ERRORW,

			/// <summary></summary>
			WM_CAP_SET_CALLBACK_STATUS = WM_CAP_SET_CALLBACK_STATUSW,

			/// <summary></summary>
			WM_CAP_SET_CALLBACK_YIELD = WM_CAP_START + 4,

			/// <summary></summary>
			WM_CAP_SET_CALLBACK_FRAME = WM_CAP_START + 5,

			/// <summary></summary>
			WM_CAP_SET_CALLBACK_VIDEOSTREAM = WM_CAP_START + 6,

			/// <summary></summary>
			WM_CAP_SET_CALLBACK_WAVESTREAM = WM_CAP_START + 7,

			/// <summary></summary>
			WM_CAP_GET_USER_DATA = WM_CAP_START + 8,

			/// <summary></summary>
			WM_CAP_SET_USER_DATA = WM_CAP_START + 9,

			/// <summary></summary>
			WM_CAP_DRIVER_CONNECT = WM_CAP_START + 10,

			/// <summary></summary>
			WM_CAP_DRIVER_DISCONNECT = WM_CAP_START + 11,

			/// <summary></summary>
			WM_CAP_DRIVER_GET_NAMEA = WM_CAP_START + 12,

			/// <summary></summary>
			WM_CAP_DRIVER_GET_VERSIONA = WM_CAP_START + 13,

			/// <summary></summary>
			WM_CAP_DRIVER_GET_NAMEW = WM_CAP_UNICODE_START + 12,

			/// <summary></summary>
			WM_CAP_DRIVER_GET_VERSIONW = WM_CAP_UNICODE_START + 13,

			/// <summary></summary>
			WM_CAP_DRIVER_GET_NAME = WM_CAP_DRIVER_GET_NAMEW,

			/// <summary></summary>
			WM_CAP_DRIVER_GET_VERSION = WM_CAP_DRIVER_GET_VERSIONW,

			/// <summary></summary>
			WM_CAP_DRIVER_GET_CAPS = WM_CAP_START + 14,

			/// <summary></summary>
			WM_CAP_FILE_SET_CAPTURE_FILEA = WM_CAP_START + 20,

			/// <summary></summary>
			WM_CAP_FILE_GET_CAPTURE_FILEA = WM_CAP_START + 21,

			/// <summary></summary>
			WM_CAP_FILE_SAVEASA = WM_CAP_START + 23,

			/// <summary></summary>
			WM_CAP_FILE_SAVEDIBA = WM_CAP_START + 25,

			/// <summary></summary>
			WM_CAP_FILE_SET_CAPTURE_FILEW = WM_CAP_UNICODE_START + 20,

			/// <summary></summary>
			WM_CAP_FILE_GET_CAPTURE_FILEW = WM_CAP_UNICODE_START + 21,

			/// <summary></summary>
			WM_CAP_FILE_SAVEASW = WM_CAP_UNICODE_START + 23,

			/// <summary></summary>
			WM_CAP_FILE_SAVEDIBW = WM_CAP_UNICODE_START + 25,

			/// <summary></summary>
			WM_CAP_FILE_SET_CAPTURE_FILE = WM_CAP_FILE_SET_CAPTURE_FILEW,

			/// <summary></summary>
			WM_CAP_FILE_GET_CAPTURE_FILE = WM_CAP_FILE_GET_CAPTURE_FILEW,

			/// <summary></summary>
			WM_CAP_FILE_SAVEAS = WM_CAP_FILE_SAVEASW,

			/// <summary></summary>
			WM_CAP_FILE_SAVEDIB = WM_CAP_FILE_SAVEDIBW,

			/// <summary></summary>
			WM_CAP_FILE_ALLOCATE = WM_CAP_START + 22,

			/// <summary></summary>
			WM_CAP_FILE_SET_INFOCHUNK = WM_CAP_START + 24,

			/// <summary></summary>
			WM_CAP_EDIT_COPY = WM_CAP_START + 30,

			/// <summary></summary>
			WM_CAP_SET_AUDIOFORMAT = WM_CAP_START + 35,

			/// <summary></summary>
			WM_CAP_GET_AUDIOFORMAT = WM_CAP_START + 36,

			/// <summary></summary>
			WM_CAP_DLG_VIDEOFORMAT = WM_CAP_START + 41,

			/// <summary></summary>
			WM_CAP_DLG_VIDEOSOURCE = WM_CAP_START + 42,

			/// <summary></summary>
			WM_CAP_DLG_VIDEODISPLAY = WM_CAP_START + 43,

			/// <summary></summary>
			WM_CAP_GET_VIDEOFORMAT = WM_CAP_START + 44,

			/// <summary></summary>
			WM_CAP_SET_VIDEOFORMAT = WM_CAP_START + 45,

			/// <summary></summary>
			WM_CAP_DLG_VIDEOCOMPRESSION = WM_CAP_START + 46,

			/// <summary></summary>
			WM_CAP_SET_PREVIEW = WM_CAP_START + 50,

			/// <summary></summary>
			WM_CAP_SET_OVERLAY = WM_CAP_START + 51,

			/// <summary></summary>
			WM_CAP_SET_PREVIEWRATE = WM_CAP_START + 52,

			/// <summary></summary>
			WM_CAP_SET_SCALE = WM_CAP_START + 53,

			/// <summary></summary>
			WM_CAP_GET_STATUS = WM_CAP_START + 54,

			/// <summary></summary>
			WM_CAP_SET_SCROLL = WM_CAP_START + 55,

			/// <summary></summary>
			WM_CAP_GRAB_FRAME = WM_CAP_START + 60,

			/// <summary></summary>
			WM_CAP_GRAB_FRAME_NOSTOP = WM_CAP_START + 61,

			/// <summary></summary>
			WM_CAP_SEQUENCE = WM_CAP_START + 62,

			/// <summary></summary>
			WM_CAP_SEQUENCE_NOFILE = WM_CAP_START + 63,

			/// <summary></summary>
			WM_CAP_SET_SEQUENCE_SETUP = WM_CAP_START + 64,

			/// <summary></summary>
			WM_CAP_GET_SEQUENCE_SETUP = WM_CAP_START + 65,

			/// <summary></summary>
			WM_CAP_SET_MCI_DEVICEA = WM_CAP_START + 66,

			/// <summary></summary>
			WM_CAP_GET_MCI_DEVICEA = WM_CAP_START + 67,

			/// <summary></summary>
			WM_CAP_SET_MCI_DEVICEW = WM_CAP_UNICODE_START + 66,

			/// <summary></summary>
			WM_CAP_GET_MCI_DEVICEW = WM_CAP_UNICODE_START + 67,

			/// <summary></summary>
			WM_CAP_SET_MCI_DEVICE = WM_CAP_SET_MCI_DEVICEW,

			/// <summary></summary>
			WM_CAP_GET_MCI_DEVICE = WM_CAP_GET_MCI_DEVICEW,

			/// <summary></summary>
			WM_CAP_STOP = WM_CAP_START + 68,

			/// <summary></summary>
			WM_CAP_ABORT = WM_CAP_START + 69,

			/// <summary></summary>
			WM_CAP_SINGLE_FRAME_OPEN = WM_CAP_START + 70,

			/// <summary></summary>
			WM_CAP_SINGLE_FRAME_CLOSE = WM_CAP_START + 71,

			/// <summary></summary>
			WM_CAP_SINGLE_FRAME = WM_CAP_START + 72,

			/// <summary></summary>
			WM_CAP_PAL_OPENA = WM_CAP_START + 80,

			/// <summary></summary>
			WM_CAP_PAL_SAVEA = WM_CAP_START + 81,

			/// <summary></summary>
			WM_CAP_PAL_OPENW = WM_CAP_UNICODE_START + 80,

			/// <summary></summary>
			WM_CAP_PAL_SAVEW = WM_CAP_UNICODE_START + 81,

			/// <summary></summary>
			WM_CAP_PAL_OPEN = WM_CAP_PAL_OPENW,

			/// <summary></summary>
			WM_CAP_PAL_SAVE = WM_CAP_PAL_SAVEW,

			/// <summary></summary>
			WM_CAP_PAL_PASTE = WM_CAP_START + 82,

			/// <summary></summary>
			WM_CAP_PAL_AUTOCREATE = WM_CAP_START + 83,

			/// <summary>Following added post VFW 1.1</summary>
			WM_CAP_PAL_MANUALCREATE = WM_CAP_START + 84,

			/// <summary></summary>
			WM_CAP_SET_CALLBACK_CAPCONTROL = WM_CAP_START + 85,
		}

		/// <summary>Current state of the capture operation.</summary>
		[PInvokeData("vfw.h", MSDNShortId = "NC:vfw.CAPCONTROLCALLBACK")]
		public enum CONTROLCALLBACK
		{
			/// <summary>Waiting to start capture</summary>
			CONTROLCALLBACK_PREROLL = 1,

			/// <summary>Now capturing</summary>
			CONTROLCALLBACK_CAPTURING = 2,
		}

		/// <summary>Flags for VIDEOHDR.</summary>
		[Flags]
		public enum VHDR : uint
		{
			/// <summary>Done bit</summary>
			VHDR_DONE = 0x00000001,

			/// <summary>Set if this header has been prepared</summary>
			VHDR_PREPARED = 0x00000002,

			/// <summary>Reserved for driver</summary>
			VHDR_INQUEUE = 0x00000004,

			/// <summary>Key Frame</summary>
			VHDR_KEYFRAME = 0x00000008,
		}

		/// <summary>
		/// The <c>capCaptureAbort</c> macro stops the capture operation. You can use this macro or explictly send the WM_CAP_ABORT message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>The capture operation must yield to use this macro.</para>
		/// <para>
		/// In the case of step capture, the image data collected up to the point of the <c>capCaptureAbort</c> macro will be retained in
		/// the capture file, but audio will not be captured.
		/// </para>
		/// <para>Use the capCaptureStop macro to halt step capture at the current position, and then capture audio.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capcaptureabort void capCaptureAbort( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capCaptureAbort")]
		public static bool capCaptureAbort(HWND hwnd) => AVICapSM(hwnd, capMessage.WM_CAP_ABORT);

		/// <summary>
		/// The <c>capCaptureGetSetup</c> macro retrieves the current settings of the streaming capture parameters. You can use this macro
		/// or explictly send the WM_CAP_GET_SEQUENCE_SETUP message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="s">Pointer to a CAPTUREPARMS structure.</param>
		/// <returns>None</returns>
		/// <remarks>For information about the parameters used to control streaming capture, see the CAPTUREPARMS structure.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capcapturegetsetup void capCaptureGetSetup( hwnd, s, wSize );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capCaptureGetSetup")]
		public static bool capCaptureGetSetup(HWND hwnd, out CAPTUREPARMS s) => AVICapSM(hwnd, capMessage.WM_CAP_GET_SEQUENCE_SETUP, out s) != 0;

		/// <summary>
		/// The <c>capCaptureSequence</c> macro initiates streaming video and audio capture to a file. You can use this macro or explicitly
		/// send the WM_CAP_SEQUENCE message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If you want to alter the parameters controlling streaming capture, use the capCaptureSetSetup macro prior to starting the capture.
		/// </para>
		/// <para>
		/// By default, the capture window does not allow other applications to continue running during capture. To override this, either
		/// set the <c>fYield</c> member of the CAPTUREPARMS structure to <c>TRUE</c>, or install a yield callback function.
		/// </para>
		/// <para>
		/// During streaming capture, the capture window can optionally issue notifications to your application of specific types of
		/// conditions. To install callback procedures for these notifications, use the following macros:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>capSetCallbackOnError</term>
		/// </item>
		/// <item>
		/// <term>capSetCallbackOnStatus</term>
		/// </item>
		/// <item>
		/// <term>capSetCallbackOnVideoStream</term>
		/// </item>
		/// <item>
		/// <term>capSetCallbackOnWaveStream</term>
		/// </item>
		/// <item>
		/// <term>capSetCallbackOnYield</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capcapturesequence void capCaptureSequence( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capCaptureSequence")]
		public static bool capCaptureSequence(HWND hwnd) => AVICapSM(hwnd, capMessage.WM_CAP_SEQUENCE);

		/// <summary>
		/// The <c>capCaptureSequenceNoFile</c> macro initiates streaming video capture without writing data to a file. You can use this
		/// macro or explicitly send the WM_CAP_SEQUENCE_NOFILE message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This message is useful in conjunction with video stream or waveform-audio stream callback functions that let your application
		/// use the video and audio data directly.
		/// </para>
		/// <para>
		/// If you want to alter the parameters controlling streaming capture, use the capCaptureSetSetup macro prior to starting the capture.
		/// </para>
		/// <para>
		/// By default, the capture window does not allow other applications to continue running during capture. To override this, either
		/// set the <c>fYield</c> member of the CAPTUREPARMS structure to <c>TRUE</c>, or install a yield callback function.
		/// </para>
		/// <para>
		/// During streaming capture, the capture window can optionally issue notifications to your application of specific types of
		/// conditions. To install callback procedures for these notifications, use the following macros:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>capSetCallbackOnError</term>
		/// </item>
		/// <item>
		/// <term>capSetCallbackOnStatus</term>
		/// </item>
		/// <item>
		/// <term>capSetCallbackOnVideoStream</term>
		/// </item>
		/// <item>
		/// <term>capSetCallbackOnWaveStream</term>
		/// </item>
		/// <item>
		/// <term>capSetCallbackOnYield</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capcapturesequencenofile void capCaptureSequenceNoFile( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capCaptureSequenceNoFile")]
		public static bool capCaptureSequenceNoFile(HWND hwnd) => AVICapSM(hwnd, capMessage.WM_CAP_SEQUENCE_NOFILE);

		/// <summary>
		/// The <c>capCaptureSetSetup</c> macro sets the configuration parameters used with streaming capture. You can use this macro or
		/// explicitly send the WM_CAP_SET_SEQUENCE_SETUP message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="s">Pointer to a CAPTUREPARMS structure.</param>
		/// <returns>None</returns>
		/// <remarks>For information about the parameters used to control streaming capture, see the CAPTUREPARMS structure.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capcapturesetsetup void capCaptureSetSetup( hwnd, s, wSize );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capCaptureSetSetup")]
		public static bool capCaptureSetSetup(HWND hwnd, in CAPTUREPARMS s) => AVICapSM(hwnd, capMessage.WM_CAP_SET_SEQUENCE_SETUP, -1, s) != 0;

		/// <summary>
		/// The <c>capCaptureSingleFrame</c> macro appends a single frame to a capture file that was opened using the
		/// capCaptureSingleFrameOpen macro. You can use this macro or explicitly send the WM_CAP_SINGLE_FRAME message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capcapturesingleframe void capCaptureSingleFrame( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capCaptureSingleFrame")]
		public static bool capCaptureSingleFrame(HWND hwnd) => AVICapSM(hwnd, capMessage.WM_CAP_SINGLE_FRAME);

		/// <summary>
		/// The <c>capCaptureSingleFrameClose</c> macro closes the capture file opened by the capCaptureSingleFrameOpen macro. You can use
		/// this macro or explicitly send the WM_CAP_SINGLE_FRAME_CLOSE message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		/// <remarks>For information about installing callback functions, see the capSetCallbackOnError and capSetCallbackOnFrame macros.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capcapturesingleframeclose void capCaptureSingleFrameClose( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capCaptureSingleFrameClose")]
		public static bool capCaptureSingleFrameClose(HWND hwnd) => AVICapSM(hwnd, capMessage.WM_CAP_SINGLE_FRAME_CLOSE);

		/// <summary>
		/// The <c>capCaptureSingleFrameOpen</c> macro opens the capture file for single-frame capturing. Any previous information in the
		/// capture file is overwritten. You can use this macro or explicitly send the WM_CAP_SINGLE_FRAME_OPEN message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		/// <remarks>For information about installing callback functions, see the capSetCallbackOnError and capSetCallbackOnFrame macros.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capcapturesingleframeopen void capCaptureSingleFrameOpen( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capCaptureSingleFrameOpen")]
		public static bool capCaptureSingleFrameOpen(HWND hwnd) => AVICapSM(hwnd, capMessage.WM_CAP_SINGLE_FRAME_OPEN);

		/// <summary>
		/// <para>
		/// The <c>capCaptureStop</c> macro stops the capture operation. You can use this macro or explicitly send the WM_CAP_STOP message.
		/// </para>
		/// <para>
		/// In step frame capture, the image data that was collected before this message was sent is retained in the capture file. An
		/// equivalent duration of audio data is also retained in the capture file if audio capture was enabled.
		/// </para>
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// The capture operation must yield to use this message. Use the capCaptureAbort macro to abandon the current capture operation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capcapturestop void capCaptureStop( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capCaptureStop")]
		public static bool capCaptureStop(HWND hwnd) => AVICapSM(hwnd, capMessage.WM_CAP_STOP);

		/// <summary>The <c>capCreateCaptureWindow</c> function creates a capture window.</summary>
		/// <param name="lpszWindowName">Null-terminated string containing the name used for the capture window.</param>
		/// <param name="dwStyle">Window styles used for the capture window. Window styles are described with the CreateWindowEx function.</param>
		/// <param name="x">The x-coordinate of the upper left corner of the capture window.</param>
		/// <param name="y">The y-coordinate of the upper left corner of the capture window.</param>
		/// <param name="nWidth">Width of the capture window.</param>
		/// <param name="nHeight">Height of the capture window.</param>
		/// <param name="hwndParent">Handle to the parent window.</param>
		/// <param name="nID">Window identifier.</param>
		/// <returns>Returns a handle of the capture window if successful or <c>NULL</c> otherwise.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capcreatecapturewindowa HWND VFWAPI capCreateCaptureWindowA( LPCSTR
		// lpszWindowName, DWORD dwStyle, int x, int y, int nWidth, int nHeight, HWND hwndParent, int nID );
		[DllImport(Lib_Avicap32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capCreateCaptureWindowA")]
		public static extern HWND capCreateCaptureWindow([MarshalAs(UnmanagedType.LPTStr)] string lpszWindowName, User32.WindowStyles dwStyle, int x, int y, int nWidth, int nHeight, [In, Optional] HWND hwndParent, int nID);

		/// <summary>
		/// The <c>capDlgVideoCompression</c> macro displays a dialog box in which the user can select a compressor to use during the
		/// capture process. The list of available compressors can vary with the video format selected in the capture driver's Video Format
		/// dialog box. You can use this macro or explicitly send the WM_CAP_DLG_VIDEOCOMPRESSION message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Use this message with capture drivers that provide frames only in the BI_RGB format. This message is most useful in the step
		/// capture operation to combine capture and compression in a single operation. Compressing frames with a software compressor as
		/// part of a real-time capture operation is most likely too time-consuming to perform.
		/// </para>
		/// <para>Compression does not affect the frames copied to the clipboard.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capdlgvideocompression void capDlgVideoCompression( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capDlgVideoCompression")]
		public static bool capDlgVideoCompression(HWND hwnd) => AVICapSM(hwnd, capMessage.WM_CAP_DLG_VIDEOCOMPRESSION);

		/// <summary>
		/// The <c>capDlgVideoDisplay</c> macro displays a dialog box in which the user can set or adjust the video output. This dialog box
		/// might contain controls that affect the hue, contrast, and brightness of the displayed image, as well as key color alignment. You
		/// can use this macro or explicitly send the WM_CAP_DLG_VIDEODISPLAY message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The controls in this dialog box do not affect digitized video data; they affect only the output or redisplay of the video signal.
		/// </para>
		/// <para>
		/// The Video Display dialog box is unique for each capture driver. Some capture drivers might not support a Video Display dialog
		/// box. Applications can determine if the capture driver supports this message by checking the <c>fHasDlgVideoDisplay</c> member of
		/// the CAPDRIVERCAPS structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capdlgvideodisplay void capDlgVideoDisplay( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capDlgVideoDisplay")]
		public static bool capDlgVideoDisplay(HWND hwnd) => AVICapSM(hwnd, capMessage.WM_CAP_DLG_VIDEODISPLAY);

		/// <summary>
		/// The <c>capDlgVideoFormat</c> macro displays a dialog box in which the user can select the video format. The Video Format dialog
		/// box might be used to select image dimensions, bit depth, and hardware compression options. You can use this macro or explicitly
		/// send the WM_CAP_DLG_VIDEOFORMAT message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// After this message returns, applications might need to update the CAPSTATUS structure because the user might have changed the
		/// image dimensions.
		/// </para>
		/// <para>
		/// The Video Format dialog box is unique for each capture driver. Some capture drivers might not support a Video Format dialog box.
		/// Applications can determine if the capture driver supports this message by checking the <c>fHasDlgVideoFormat</c> member of CAPDRIVERCAPS.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capdlgvideoformat void capDlgVideoFormat( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capDlgVideoFormat")]
		public static bool capDlgVideoFormat(HWND hwnd) => AVICapSM(hwnd, capMessage.WM_CAP_DLG_VIDEOFORMAT);

		/// <summary>
		/// The <c>capDlgVideoSource</c> macro displays a dialog box in which the user can control the video source. The Video Source dialog
		/// box might contain controls that select input sources; alter the hue, contrast, brightness of the image; and modify the video
		/// quality before digitizing the images into the frame buffer. You can use this macro or explicitly send the WM_CAP_DLG_VIDEOSOURCE message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// The Video Source dialog box is unique for each capture driver. Some capture drivers might not support a Video Source dialog box.
		/// Applications can determine if the capture driver supports this message by checking the <c>fHasDlgVideoSource</c> member of the
		/// CAPDRIVERCAPS structure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capdlgvideosource void capDlgVideoSource( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capDlgVideoSource")]
		public static bool capDlgVideoSource(HWND hwnd) => AVICapSM(hwnd, capMessage.WM_CAP_DLG_VIDEOSOURCE);

		/// <summary>
		/// The <c>capDriverConnect</c> macro connects a capture window to a capture driver. You can use this macro or explicitly send the
		/// WM_CAP_DRIVER_CONNECT message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="i">Index of the capture driver. The index can range from 0 through 9.</param>
		/// <returns>None</returns>
		/// <remarks>Connecting a capture driver to a capture window automatically disconnects any previously connected capture driver.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capdriverconnect void capDriverConnect( hwnd, i );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capDriverConnect")]
		public static bool capDriverConnect(HWND hwnd, int i) => AVICapSM(hwnd, capMessage.WM_CAP_DRIVER_CONNECT, (IntPtr)i);

		/// <summary>
		/// The <c>capDriverDisconnect</c> macro disconnects a capture driver from a capture window. You can use this macro or explicitly
		/// send the WM_CAP_DRIVER_DISCONNECT message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capdriverdisconnect void capDriverDisconnect( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capDriverDisconnect")]
		public static bool capDriverDisconnect(HWND hwnd) => AVICapSM(hwnd, capMessage.WM_CAP_DRIVER_DISCONNECT);

		/// <summary>
		/// The <c>capDriverGetCaps</c> macro returns the hardware capabilities of the capture driver currently connected to a capture
		/// window. You can use this macro or explicitly send the WM_CAP_DRIVER_GET_CAPS message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="s">Pointer to the CAPDRIVERCAPS structure to contain the hardware capabilities.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// The capabilities returned in CAPDRIVERCAPS are constant for a given capture driver. Applications need to retrieve this
		/// information once when the capture driver is first connected to a capture window.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capdrivergetcaps void capDriverGetCaps( hwnd, s, wSize );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capDriverGetCaps")]
		public static bool capDriverGetCaps(HWND hwnd, out CAPDRIVERCAPS s) => AVICapSM(hwnd, capMessage.WM_CAP_DRIVER_GET_CAPS, out s) != 0;

		/// <summary>
		/// The <c>capDriverGetName</c> macro returns the name of the capture driver connected to the capture window. You can use this macro
		/// or explicitly call the WM_CAP_DRIVER_GET_NAME message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="szName">Pointer to an application-defined buffer used to return the device name as a null-terminated string.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// The name is a text string retrieved from the driver's resource area. Applications should allocate approximately 80 bytes for
		/// this string. If the driver does not contain a name resource, the full path name of the driver listed in the registry or in the
		/// SYSTEM.INI file is returned.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capdrivergetname void capDriverGetName( hwnd, szName, wSize );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capDriverGetName")]
		public static bool capDriverGetName(HWND hwnd, StringBuilder szName) => AVICapSM(hwnd, capMessage.WM_CAP_DRIVER_GET_NAME, szName);

		/// <summary>
		/// The <c>capDriverGetVersion</c> macro returns the version information of the capture driver connected to a capture window. You
		/// can use this macro or explicitly send the WM_CAP_DRIVER_GET_VERSION message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="szVer">Pointer to an application-defined buffer used to return the version information as a null-terminated string.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// The version information is a text string retrieved from the driver's resource area. Applications should allocate approximately
		/// 40 bytes for this string. If version information is not available, a <c>NULL</c> string is returned.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capdrivergetversion void capDriverGetVersion( hwnd, szVer, wSize );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capDriverGetVersion")]
		public static bool capDriverGetVersion(HWND hwnd, StringBuilder szVer) => AVICapSM(hwnd, capMessage.WM_CAP_DRIVER_GET_VERSION, szVer);

		/// <summary>
		/// The <c>capEditCopy</c> macro copies the contents of the video frame buffer and associated palette to the clipboard. You can use
		/// this macro or explicitly send the WM_CAP_EDIT_COPY message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capeditcopy void capEditCopy( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capEditCopy")]
		public static bool capEditCopy(HWND hwnd) => AVICapSM(hwnd, capMessage.WM_CAP_EDIT_COPY);

		/// <summary>
		/// The <c>capFileAlloc</c> macro creates (preallocates) a capture file of a specified size. You can use this macro or explicitly
		/// send the WM_CAP_FILE_ALLOCATE message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="dwSize">Size, in bytes, to create the capture file.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// You can improve streaming capture performance significantly by preallocating a capture file large enough to store an entire
		/// video clip and by defragmenting the capture file before capturing the clip.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capfilealloc void capFileAlloc( hwnd, dwSize );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capFileAlloc")]
		public static bool capFileAlloc(HWND hwnd, int dwSize) => AVICapSM(hwnd, capMessage.WM_CAP_FILE_ALLOCATE, (IntPtr)0, (IntPtr)dwSize);

		/// <summary>
		/// The <c>capFileGetCaptureFile</c> macro returns the name of the current capture file. You can use this macro or explicitly call
		/// the WM_CAP_FILE_GET_CAPTURE_FILE message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="szName">
		/// Pointer to an application-defined buffer used to return the name of the capture file as a null-terminated string.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>The default capture filename is C:\CAPTURE.AVI.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capfilegetcapturefile void capFileGetCaptureFile( hwnd, szName,
		// wSize );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capFileGetCaptureFile")]
		public static bool capFileGetCaptureFile(HWND hwnd, StringBuilder szName) => AVICapSM(hwnd, capMessage.WM_CAP_FILE_GET_CAPTURE_FILE, szName);

		/// <summary>
		/// The <c>capFileSaveAs</c> macro copies the contents of the capture file to another file. You can use this macro or explicitly
		/// call the WM_CAP_FILE_SAVEAS message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="szName">
		/// Pointer to the null-terminated string that contains the name of the destination file used to copy the file.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This message does not change the name or contents of the current capture file.</para>
		/// <para>If the copy operation is unsuccessful due to a disk full error, the destination file is automatically deleted.</para>
		/// <para>
		/// Typically, a capture file is preallocated for the largest capture segment anticipated and only a portion of it might be used to
		/// capture data. This message copies only the portion of the file containing the capture data.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capfilesaveas void capFileSaveAs( hwnd, szName );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capFileSaveAs")]
		public static bool capFileSaveAs(HWND hwnd, string szName) => AVICapSM(hwnd, capMessage.WM_CAP_FILE_SAVEAS, szName);

		/// <summary>
		/// The <c>capFileSaveDIB</c> macro copies the current frame to a DIB file. You can use this macro or explicitly call the
		/// WM_CAP_FILE_SAVEDIB message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="szName">Pointer to the null-terminated string that contains the name of the destination DIB file.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// If the capture driver supplies frames in a compressed format, this call attempts to decompress the frame before writing the file.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capfilesavedib void capFileSaveDIB( hwnd, szName );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capFileSaveDIB")]
		public static bool capFileSaveDIB(HWND hwnd, string szName) => AVICapSM(hwnd, capMessage.WM_CAP_FILE_SAVEDIB, szName);

		/// <summary>
		/// The <c>capFileSetCaptureFile</c> macro names the file used for video capture. You can use this macro or explicitly call the
		/// WM_CAP_FILE_SET_CAPTURE_FILE message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="szName">Pointer to the null-terminated string that contains the name of the capture file to use.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// This message stores the filename in an internal structure. It does not create, allocate, or open the specified file. The default
		/// capture filename is C:\CAPTURE.AVI.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capfilesetcapturefile void capFileSetCaptureFile( hwnd, szName );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capFileSetCaptureFile")]
		public static bool capFileSetCaptureFile(HWND hwnd, string szName) => AVICapSM(hwnd, capMessage.WM_CAP_FILE_SET_CAPTURE_FILE, szName);

		/// <summary>
		/// The <c>capFileSetInfoChunk</c> macro sets and clears information chunks. Information chunks can be inserted in an AVI file
		/// during capture to embed text strings or custom data. You can use this macro or explicitly call the WM_CAP_FILE_SET_INFOCHUNK message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="lpInfoChunk">Pointer to a CAPINFOCHUNK structure defining the information chunk to be created or deleted.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Multiple registered information chunks can be added to an AVI file. After an information chunk is set, it continues to be added
		/// to subsequent capture files until either the entry is cleared or all information chunk entries are cleared. To clear a single
		/// entry, specify the information chunk in the <c>fccInfoID</c> member and <c>NULL</c> in the <c>lpData</c> member of the
		/// CAPINFOCHUNK structure. To clear all entries, specify <c>NULL</c> in <c>fccInfoID</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capfilesetinfochunk void capFileSetInfoChunk( hwnd, lpInfoChunk );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capFileSetInfoChunk")]
		public static bool capFileSetInfoChunk(HWND hwnd, out CAPINFOCHUNK lpInfoChunk) => AVICapSM(hwnd, capMessage.WM_CAP_FILE_SET_INFOCHUNK, out lpInfoChunk, 0) != 0;

		/// <summary>
		/// The <c>capGetAudioFormat</c> macro obtains the audio format. You can use this macro or explicitly call the
		/// WM_CAP_GET_AUDIOFORMAT message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="s">
		/// Pointer to a WAVEFORMATEX structure, or <c>NULL</c>. If the value is <c>NULL</c>, the size, in bytes, required to hold the
		/// <c>WAVEFORMATEX</c> structure is returned.
		/// </param>
		/// <param name="wSize">Size, in bytes, of the structure referenced by s.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Because compressed audio formats vary in size requirements applications must first retrieve the size, then allocate memory, and
		/// finally request the audio format data.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capgetaudioformat void capGetAudioFormat( hwnd, s, wSize );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capGetAudioFormat")]
		public static int capGetAudioFormat(HWND hwnd, IntPtr s, int wSize) => User32.SendMessage(hwnd, capMessage.WM_CAP_GET_AUDIOFORMAT, (IntPtr)wSize, s).ToInt32();

		/// <summary>
		/// The <c>capGetAudioFormatSize</c> macro obtains the size of the audio format. You can use this macro or explicitly call the
		/// WM_CAP_GET_AUDIOFORMAT message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Because compressed audio formats vary in size requirements applications must first retrieve the size, then allocate memory, and
		/// finally request the audio format data.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capgetaudioformatsize void capGetAudioFormatSize( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capGetAudioFormatSize")]
		public static int capGetAudioFormatSize(HWND hwnd) => User32.SendMessage(hwnd, capMessage.WM_CAP_GET_AUDIOFORMAT).ToInt32();

		/// <summary>The <c>capGetDriverDescription</c> function retrieves the version description of the capture driver.</summary>
		/// <param name="wDriverIndex">
		/// <para>Index of the capture driver. The index can range from 0 through 9.</para>
		/// <para>
		/// Plug-and-Play capture drivers are enumerated first, followed by capture drivers listed in the registry, which are then followed
		/// by capture drivers listed in SYSTEM.INI.
		/// </para>
		/// </param>
		/// <param name="lpszName">Pointer to a buffer containing a null-terminated string corresponding to the capture driver name.</param>
		/// <param name="cbName">Length, in bytes, of the buffer pointed to by lpszName.</param>
		/// <param name="lpszVer">
		/// Pointer to a buffer containing a null-terminated string corresponding to the description of the capture driver.
		/// </param>
		/// <param name="cbVer">Length, in bytes, of the buffer pointed to by lpszVer.</param>
		/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
		/// <remarks>
		/// <para>
		/// If the information description is longer than its buffer, the description is truncated. The returned string is always
		/// null-terminated. If a buffer size is zero, its corresponding description is not copied.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The vfw.h header defines capGetDriverDescription as an alias which automatically selects the ANSI or Unicode version of this
		/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
		/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
		/// for Function Prototypes.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capgetdriverdescriptiona BOOL VFWAPI capGetDriverDescriptionA( UINT
		// wDriverIndex, LPSTR lpszName, int cbName, LPSTR lpszVer, int cbVer );
		[DllImport(Lib_Avicap32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capGetDriverDescriptionA")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool capGetDriverDescription(uint wDriverIndex, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszName, int cbName, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszVer, int cbVer);

		/// <summary>
		/// The <c>capGetMCIDeviceName</c> macro retrieves the name of an MCI device previously set with the capSetMCIDeviceName macro. You
		/// can use this macro or explicitly call the WM_CAP_GET_MCI_DEVICE message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="szName">Pointer to a null-terminated string that contains the MCI device name.</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capgetmcidevicename void capGetMCIDeviceName( hwnd, szName, wSize );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capGetMCIDeviceName")]
		public static bool capGetMCIDeviceName(HWND hwnd, StringBuilder szName) => AVICapSM(hwnd, capMessage.WM_CAP_GET_MCI_DEVICE, szName);

		/// <summary>
		/// The <c>capGetStatus</c> macro retrieves the status of the capture window. You can use this macro or explicitly call the
		/// WM_CAP_GET_STATUS message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="s">Pointer to a CAPSTATUS structure.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// The CAPSTATUS structure contains the current state of the capture window. Since this state is dynamic and changes in response to
		/// various messages, the application should initialize this structure after sending the capDlgVideoFormat macro and whenever it
		/// needs to enable menu items or determine the actual state of the window.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capgetstatus void capGetStatus( hwnd, s, wSize );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capGetStatus")]
		public static bool capGetStatus(HWND hwnd, out CAPSTATUS s) => AVICapSM(hwnd, capMessage.WM_CAP_GET_STATUS, out s) != 0;

		/// <summary>
		/// The <c>capGetUserData</c> macro retrieves a <c>LONG_PTR</c> data value associated with a capture window. You can use this macro
		/// or explicitly call the WM_CAP_GET_USER_DATA message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>Returns a value previously saved by using the WM_CAP_SET_USER_DATA message.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capgetuserdata void capGetUserData( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capGetUserData")]
		public static IntPtr capGetUserData(HWND hwnd) => User32.SendMessage(hwnd, capMessage.WM_CAP_GET_USER_DATA);

		/// <summary>
		/// The <c>capGetVideoFormat</c> macro retrieves a copy of the video format in use. You can use this macro or explicitly call the
		/// WM_CAP_GET_VIDEOFORMAT message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="s">
		/// Pointer to a BITMAPINFO structure. You can also specify <c>NULL</c> to retrieve the number of bytes needed by <c>BITMAPINFO</c>.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Because compressed video formats vary in size requirements applications must first retrieve the size, then allocate memory, and
		/// finally request the video format data.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capgetvideoformat void capGetVideoFormat( hwnd, s, wSize );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capGetVideoFormat")]
		public static int capGetVideoFormat(HWND hwnd, [Out] Gdi32.SafeBITMAPINFO s) => User32.SendMessage(hwnd, capMessage.WM_CAP_GET_VIDEOFORMAT, (IntPtr)(int)s.Size, s.DangerousGetHandle()).ToInt32();

		/// <summary>
		/// The <c>capGetVideoFormatSize</c> macro retrieves the size required for the video format. You can use this macro or explicitly
		/// call the WM_CAP_GET_VIDEOFORMAT message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Because compressed video formats vary in size requirements applications must first retrieve the size, then allocate memory, and
		/// finally request the video format data.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capgetvideoformatsize void capGetVideoFormatSize( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capGetVideoFormatSize")]
		public static int capGetVideoFormatSize(HWND hwnd) => User32.SendMessage(hwnd, capMessage.WM_CAP_GET_VIDEOFORMAT).ToInt32();

		/// <summary>
		/// The <c>capGrabFrame</c> macro retrieves and displays a single frame from the capture driver. After capture, overlay and preview
		/// are disabled. You can use this macro or explicitly call the WM_CAP_GRAB_FRAME message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		/// <remarks>For information about installing callback functions, see the capSetCallbackOnError and capSetCallbackOnFrame macros.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capgrabframe void capGrabFrame( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capGrabFrame")]
		public static bool capGrabFrame(HWND hwnd) => AVICapSM(hwnd, capMessage.WM_CAP_GRAB_FRAME);

		/// <summary>
		/// The <c>capGrabFrameNoStop</c> macro fills the frame buffer with a single uncompressed frame from the capture device and displays
		/// it. Unlike with the capGrabFrame macro, the state of overlay or preview is not altered by this message. You can use this macro
		/// or explicitly call the WM_CAP_GRAB_FRAME_NOSTOP message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// For information about installing callback functions, see the <c>capSetCallbackOnError</c> and <c>capSetCallbackOnFrame</c> macros.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capgrabframenostop void capGrabFrameNoStop( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capGrabFrameNoStop")]
		public static bool capGrabFrameNoStop(HWND hwnd) => AVICapSM(hwnd, capMessage.WM_CAP_GRAB_FRAME_NOSTOP);

		/// <summary>
		/// The <c>capOverlay</c> macro enables or disables overlay mode. In overlay mode, video is displayed using hardware overlay. You
		/// can use this macro or explicitly call the WM_CAP_SET_OVERLAY message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="f">Overlay flag. Specify <c>TRUE</c> for this parameter to enable overlay mode or <c>FALSE</c> to disable it.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Using an overlay does not require CPU resources.</para>
		/// <para>
		/// The <c>fHasOverlay</c> member of the <c>CAPDRIVERCAPS</c> structure indicates whether the device is capable of overlay. The
		/// <c>fOverlayWindow</c> member of the <c>CAPSTATUS</c> structure indicates whether overlay mode is currently enabled.
		/// </para>
		/// <para>Enabling overlay mode automatically disables preview mode.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capoverlay void capOverlay( hwnd, f );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capOverlay")]
		public static bool capOverlay(HWND hwnd, bool f) => AVICapSM(hwnd, capMessage.WM_CAP_SET_OVERLAY, (IntPtr)(f ? 1 : 0));

		/// <summary>
		/// The <c>capPaletteAuto</c> macro requests that the capture driver sample video frames and automatically create a new palette. You
		/// can use this macro or explicitly call the WM_CAP_PAL_AUTOCREATE message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="iFrames">Number of frames to sample.</param>
		/// <param name="iColors">Number of colors in the palette. The maximum value for this parameter is 256.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// The sampled video sequence should include all the colors you want in the palette. To obtain the best palette, you might have to
		/// sample the whole sequence rather than a portion of it.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-cappaletteauto void capPaletteAuto( hwnd, iFrames, iColors );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capPaletteAuto")]
		public static bool capPaletteAuto(HWND hwnd, int iFrames, int iColors) => AVICapSM(hwnd, capMessage.WM_CAP_PAL_AUTOCREATE, (IntPtr)iFrames, (IntPtr)iColors);

		/// <summary>
		/// The <c>capPaletteManual</c> macro requests that the capture driver manually sample video frames and create a new palette. You
		/// can use this macro or explicitly call the WM_CAP_PAL_MANUALCREATE message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="fGrab">
		/// Palette histogram flag. Set this parameter to <c>TRUE</c> for each frame included in creating the optimal palette. After the
		/// last frame has been collected, set this parameter to <c>FALSE</c> to calculate the optimal palette and send it to the capture driver.
		/// </param>
		/// <param name="iColors">
		/// Number of colors in the palette. The maximum value for this parameter is 256. This value is used only during collection of the
		/// first frame in a sequence.
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-cappalettemanual void capPaletteManual( hwnd, fGrab, iColors );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capPaletteManual")]
		public static bool capPaletteManual(HWND hwnd, bool fGrab, int iColors) => AVICapSM(hwnd, capMessage.WM_CAP_PAL_MANUALCREATE, (IntPtr)(fGrab ? 1 : 0), (IntPtr)iColors);

		/// <summary>
		/// The <c>capPaletteOpen</c> macro loads a new palette from a palette file and passes it to a capture driver. Palette files
		/// typically use the filename extension .PAL. A capture driver uses a palette when required by the specified digitized image
		/// format. You can use this macro or explicitly call the WM_CAP_PAL_OPEN message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="szName">Pointer to a null-terminated string containing the palette filename.</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-cappaletteopen void capPaletteOpen( hwnd, szName );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capPaletteOpen")]
		public static bool capPaletteOpen(HWND hwnd, string szName) => AVICapSM(hwnd, capMessage.WM_CAP_PAL_OPEN, szName);

		/// <summary>
		/// The <c>capPalettePaste</c> macro copies the palette from the clipboard and passes it to a capture driver. You can use this macro
		/// or explicitly call the WM_CAP_PAL_PASTE message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <returns>None</returns>
		/// <remarks>A capture driver uses a palette when required by the specified digitized video format.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-cappalettepaste void capPalettePaste( hwnd );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capPalettePaste")]
		public static bool capPalettePaste(HWND hwnd) => AVICapSM(hwnd, capMessage.WM_CAP_PAL_PASTE);

		/// <summary>
		/// The <c>capPaletteSave</c> macro saves the current palette to a palette file. Palette files typically use the filename extension
		/// .PAL. You can use this macro or explicitly send the WM_CAP_PAL_SAVE message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="szName">Pointer to a null-terminated string containing the palette filename.</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-cappalettesave void capPaletteSave( hwnd, szName );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capPaletteSave")]
		public static bool capPaletteSave(HWND hwnd, string szName) => AVICapSM(hwnd, capMessage.WM_CAP_PAL_SAVE, szName);

		/// <summary>
		/// The <c>capPreview</c> macro enables or disables preview mode. In preview mode, frames are transferred from the capture hardware
		/// to system memory and then displayed in the capture window using GDI functions. You can use this macro or explicitly call the
		/// WM_CAP_SET_PREVIEW message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="f">Preview flag. Specify <c>TRUE</c> for this parameter to enable preview mode or <c>FALSE</c> to disable it.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The preview mode uses substantial CPU resources. Applications can disable preview or lower the preview rate when another
		/// application has the focus. The <c>fLiveWindow</c> member of the CAPSTATUS structure indicates if preview mode is currently enabled.
		/// </para>
		/// <para>Enabling preview mode automatically disables overlay mode.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-cappreview void capPreview( hwnd, f );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capPreview")]
		public static bool capPreview(HWND hwnd, bool f) => AVICapSM(hwnd, capMessage.WM_CAP_SET_PREVIEW, (IntPtr)(f ? 1 : 0));

		/// <summary>
		/// The <c>capPreviewRate</c> macro sets the frame display rate in preview mode. You can use this macro or explicitly call the
		/// WM_CAP_SET_PREVIEWRATE message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="wMS">Rate, in milliseconds, at which new frames are captured and displayed.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// The preview mode uses substantial CPU resources. Applications can disable preview or lower the preview rate when another
		/// application has the focus. During streaming video capture, the previewing task is lower priority than writing frames to disk,
		/// and preview frames are displayed only if no other buffers are available for writing.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-cappreviewrate void capPreviewRate( hwnd, wMS );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capPreviewRate")]
		public static bool capPreviewRate(HWND hwnd, int wMS) => AVICapSM(hwnd, capMessage.WM_CAP_SET_PREVIEWRATE, (IntPtr)wMS);

		/// <summary>
		/// The <c>capPreviewScale</c> macro enables or disables scaling of the preview video images. If scaling is enabled, the captured
		/// video frame is stretched to the dimensions of the capture window. You can use this macro or explicitly call the WM_CAP_SET_SCALE message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="f">
		/// Preview scaling flag. Specify <c>TRUE</c> for this parameter to stretch preview frames to the size of the capture window or
		/// <c>FALSE</c> to display them at their natural size.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Scaling preview images controls the immediate presentation of captured frames within the capture window. It has no effect on the
		/// size of the frames saved to file.
		/// </para>
		/// <para>Scaling has no effect when using overlay to display video in the frame buffer.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-cappreviewscale void capPreviewScale( hwnd, f );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capPreviewScale")]
		public static bool capPreviewScale(HWND hwnd, bool f) => AVICapSM(hwnd, capMessage.WM_CAP_SET_SCALE, (IntPtr)(f ? 1 : 0));

		/// <summary>
		/// The <c>capSetAudioFormat</c> macro sets the audio format to use when performing streaming or step capture. You can use this
		/// macro or explicitly call the WM_CAP_SET_AUDIOFORMAT message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="s">Pointer to a WAVEFORMATEX or PCMWAVEFORMAT structure that defines the audio format.</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capsetaudioformat void capSetAudioFormat( hwnd, s, wSize );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capSetAudioFormat")]
		public static bool capSetAudioFormat(HWND hwnd, in WAVEFORMATEX s) => AVICapSM(hwnd, capMessage.WM_CAP_SET_AUDIOFORMAT, -1, s) != 0;

		/// <summary>
		/// The <c>capSetAudioFormat</c> macro sets the audio format to use when performing streaming or step capture. You can use this
		/// macro or explicitly call the WM_CAP_SET_AUDIOFORMAT message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="s">Pointer to a WAVEFORMATEX or PCMWAVEFORMAT structure that defines the audio format.</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capsetaudioformat void capSetAudioFormat( hwnd, s, wSize );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capSetAudioFormat")]
		public static bool capSetAudioFormat(HWND hwnd, in PCMWAVEFORMAT s) => AVICapSM(hwnd, capMessage.WM_CAP_SET_AUDIOFORMAT, -1, s) != 0;

		/// <summary>
		/// The <c>capSetCallbackOnCapControl</c> macro sets a callback function in the application giving it precise recording control. You
		/// can use this macro or explicitly call the WM_CAP_SET_CALLBACK_CAPCONTROL message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="fpProc">
		/// Pointer to the callback function, of type capControlCallback . Specify <c>NULL</c> for this parameter to disable a previously
		/// installed callback function.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// A single callback function is used to give the application precise control over the moments that streaming capture begins and
		/// completes. The capture window first calls the procedure with nState set to CONTROLCALLBACK_PREROLL after all buffers have been
		/// allocated and all other capture preparations have finished. This gives the application the ability to preroll video sources,
		/// returning from the callback function at the exact moment recording is to begin. A return value of <c>TRUE</c> from the callback
		/// function continues capture, and a return value of <c>FALSE</c> aborts capture. After capture begins, this callback function will
		/// be called frequently with nState set to CONTROLCALLBACK_CAPTURING to allow the application to end capture by returning <c>FALSE</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capsetcallbackoncapcontrol void capSetCallbackOnCapControl( hwnd,
		// fpProc );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capSetCallbackOnCapControl")]
		public static bool capSetCallbackOnCapControl(HWND hwnd, [Optional] capControlCallback fpProc) => AVICapSM(hwnd, capMessage.WM_CAP_SET_CALLBACK_CAPCONTROL, 0, fpProc);

		/// <summary>
		/// The <c>capSetCallbackOnError</c> macro sets an error callback function in the client application. AVICap calls this procedure
		/// when errors occur. You can use this macro or explicitly call the WM_CAP_SET_CALLBACK_ERROR message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="fpProc">
		/// Pointer to the error callback function, of type capErrorCallback. Specify <c>NULL</c> for this parameter to disable a previously
		/// installed error callback function.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Applications can optionally set an error callback function. If set, AVICap calls the error procedure in the following situations:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The disk is full.</term>
		/// </item>
		/// <item>
		/// <term>A capture window cannot be connected with a capture driver.</term>
		/// </item>
		/// <item>
		/// <term>A waveform-audio device cannot be opened.</term>
		/// </item>
		/// <item>
		/// <term>The number of frames dropped during capture exceeds the specified percentage.</term>
		/// </item>
		/// <item>
		/// <term>The frames cannot be captured due to vertical synchronization interrupt problems.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capsetcallbackonerror void capSetCallbackOnError( hwnd, fpProc );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capSetCallbackOnError")]
		public static bool capSetCallbackOnError(HWND hwnd, [Optional] capErrorCallback fpProc) => AVICapSM(hwnd, capMessage.WM_CAP_SET_CALLBACK_ERROR, 0, fpProc);

		/// <summary>
		/// The <c>capSetCallbackOnFrame</c> macro sets a preview callback function in the application. AVICap calls this procedure when the
		/// capture window captures preview frames. You can use this macro or explicitly call the WM_CAP_SET_CALLBACK_FRAME message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="fpProc">
		/// Pointer to the preview callback function, of type capVideoStreamCallback. Specify <c>NULL</c> for this parameter to disable a
		/// previously installed callback function.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The capture window calls the callback function before displaying preview frames. This allows an application to modify the frame
		/// if desired. This callback function is not used during streaming video capture.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capsetcallbackonframe void capSetCallbackOnFrame( hwnd, fpProc );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capSetCallbackOnFrame")]
		public static bool capSetCallbackOnFrame(HWND hwnd, capVideoStreamCallback fpProc) => AVICapSM(hwnd, capMessage.WM_CAP_SET_CALLBACK_FRAME, 0, fpProc);

		/// <summary>
		/// The <c>capSetCallbackOnStatus</c> macro sets a status callback function in the application. AVICap calls this procedure whenever
		/// the capture window status changes. You can use this macro or explicitly call the WM_CAP_SET_CALLBACK_STATUS message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="fpProc">
		/// Pointer to the status callback function, of type capStatusCallback. Specify <c>NULL</c> for this parameter to disable a
		/// previously installed status callback function.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Applications can optionally set a status callback function. If set, AVICap calls this procedure in the following situations:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>A capture session is completed.</term>
		/// </item>
		/// <item>
		/// <term>A capture driver successfully connected to a capture window.</term>
		/// </item>
		/// <item>
		/// <term>An optimal palette is created.</term>
		/// </item>
		/// <item>
		/// <term>The number of captured frames is reported.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capsetcallbackonstatus void capSetCallbackOnStatus( hwnd, fpProc );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capSetCallbackOnStatus")]
		public static bool capSetCallbackOnStatus(HWND hwnd, [Optional] capStatusCallback fpProc) => AVICapSM(hwnd, capMessage.WM_CAP_SET_CALLBACK_STATUS, 0, fpProc);

		/// <summary>
		/// The <c>capSetCallbackOnVideoStream</c> macro sets a callback function in the application. AVICap calls this procedure during
		/// streaming capture when a video buffer is filled. You can use this macro or explicitly call the WM_CAP_SET_CALLBACK_VIDEOSTREAM message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="fpProc">
		/// Pointer to the video-stream callback function, of type capVideoStreamCallback. Specify <c>NULL</c> for this parameter to disable
		/// a previously installed video-stream callback function.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The capture window calls the callback function before writing the captured frame to disk. This allows applications to modify the
		/// frame if desired.
		/// </para>
		/// <para>
		/// If a video stream callback function is used for streaming capture, the procedure must be installed before starting the capture
		/// session and it must remain enabled for the duration of the session. It can be disabled after streaming capture ends.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capsetcallbackonvideostream void capSetCallbackOnVideoStream( hwnd,
		// fpProc );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capSetCallbackOnVideoStream")]
		public static bool capSetCallbackOnVideoStream(HWND hwnd, [Optional] capVideoStreamCallback fpProc) => AVICapSM(hwnd, capMessage.WM_CAP_SET_CALLBACK_VIDEOSTREAM, 0, fpProc);

		/// <summary>
		/// The <c>capSetCallbackOnWaveStream</c> macro sets a callback function in the application. AVICap calls this procedure during
		/// streaming capture when a new audio buffer becomes available. You can use this macro or explicitly call the
		/// WM_CAP_SET_CALLBACK_WAVESTREAM message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="fpProc">
		/// Pointer to the wave stream callback function, of type capWaveStreamCallback. Specify <c>NULL</c> for this parameter to disable a
		/// previously installed wave stream callback function.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The capture window calls the procedure before writing the audio buffer to disk. This allows applications to modify the audio
		/// buffer if desired.
		/// </para>
		/// <para>
		/// If a wave stream callback function is used, it must be installed before starting the capture session and it must remain enabled
		/// for the duration of the session. It can be disabled after streaming capture ends.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capsetcallbackonwavestream void capSetCallbackOnWaveStream( hwnd,
		// fpProc );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capSetCallbackOnWaveStream")]
		public static bool capSetCallbackOnWaveStream(HWND hwnd, [Optional] capWaveStreamCallback fpProc) => AVICapSM(hwnd, capMessage.WM_CAP_SET_CALLBACK_WAVESTREAM, 0, fpProc);

		/// <summary>
		/// The <c>capSetCallbackOnYield</c> macro sets a callback function in the application. AVICap calls this procedure when the capture
		/// window yields during streaming capture. You can use this macro or explicitly call the WM_CAP_SET_CALLBACK_YIELD message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="fpProc">
		/// Pointer to the yield callback function, of type capYieldCallback. Specify <c>NULL</c> for this parameter to disable a previously
		/// installed yield callback function.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Applications can optionally set a yield callback function. The yield callback function is called at least once for each video
		/// frame captured during streaming capture. If a yield callback function is installed, it will be called regardless of the state of
		/// the <c>fYield</c> member of the CAPTUREPARMS structure.
		/// </para>
		/// <para>
		/// If the yield callback function is used, it must be installed before starting the capture session and it must remain enabled for
		/// the duration of the session. It can be disabled after streaming capture ends.
		/// </para>
		/// <para>
		/// Applications typically perform some type of message processing in the callback function consisting of a PeekMessage,
		/// TranslateMessage, DispatchMessage loop, as in the message loop of a WinMain function. The yield callback function must also
		/// filter and remove messages that can cause reentrancy problems.
		/// </para>
		/// <para>
		/// An application typically returns <c>TRUE</c> in the yield procedure to continue streaming capture. If a yield callback function
		/// returns <c>FALSE</c>, the capture window stops the capture process.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capsetcallbackonyield void capSetCallbackOnYield( hwnd, fpProc );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capSetCallbackOnYield")]
		public static bool capSetCallbackOnYield(HWND hwnd, [Optional] capYieldCallback fpProc) => AVICapSM(hwnd, capMessage.WM_CAP_SET_CALLBACK_YIELD, 0, fpProc);

		/// <summary>
		/// The <c>capSetMCIDeviceName</c> macro specifies the name of the MCI video device to be used to capture data. You can use this
		/// macro or explicitly call the WM_CAP_SET_MCI_DEVICE message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="szName">Pointer to a null-terminated string containing the name of the device.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// This message stores the MCI device name in an internal structure. It does not open or access the device. The default device name
		/// is <c>NULL</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capsetmcidevicename void capSetMCIDeviceName( hwnd, szName );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capSetMCIDeviceName")]
		public static bool capSetMCIDeviceName(HWND hwnd, string szName) => AVICapSM(hwnd, capMessage.WM_CAP_SET_MCI_DEVICE, szName);

		/// <summary>
		/// The <c>capSetScrollPos</c> macro defines the portion of the video frame to display in the capture window. This message sets the
		/// upper left corner of the client area of the capture window to the coordinates of a specified pixel within the video frame. You
		/// can use this macro or explicitly call the WM_CAP_SET_SCROLL message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="lpP">Address to contain the desired scroll position.</param>
		/// <returns>None</returns>
		/// <remarks>The scroll position affects the image in both preview and overlay modes.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capsetscrollpos void capSetScrollPos( hwnd, lpP );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capSetScrollPos")]
		public static bool capSetScrollPos(HWND hwnd, POINT lpP) => AVICapSM(hwnd, capMessage.WM_CAP_SET_SCROLL, 0, lpP) != 0;

		/// <summary>
		/// The <c>capSetUserData</c> macro associates a <c>LONG_PTR</c> data value with a capture window. You can use this macro or
		/// explicitly call the WM_CAP_SET_USER_DATA message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="lUser">Data value to associate with a capture window.</param>
		/// <returns>None</returns>
		/// <remarks>Typically this message is used to point to a block of data associated with a capture window.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capsetuserdata void capSetUserData( hwnd, lUser );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capSetUserData")]
		public static bool capSetUserData(HWND hwnd, IntPtr lUser) => AVICapSM(hwnd, capMessage.WM_CAP_SET_USER_DATA, default, lUser);

		/// <summary>
		/// The <c>capSetVideoFormat</c> macro sets the format of captured video data. You can use this macro or explicitly call the
		/// WM_CAP_SET_VIDEOFORMAT message.
		/// </summary>
		/// <param name="hwnd">Handle to a capture window.</param>
		/// <param name="s">Pointer to a BITMAPINFO structure.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Because video formats are device-specific, applications should check the return value from this function to determine if the
		/// format is accepted by the driver.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-capsetvideoformat void capSetVideoFormat( hwnd, s, wSize );
		[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.capSetVideoFormat")]
		public static bool capSetVideoFormat(HWND hwnd, [In] Gdi32.SafeBITMAPINFO s) => AVICapSM(hwnd, capMessage.WM_CAP_SET_VIDEOFORMAT, (IntPtr)(int)s.Size, s.DangerousGetHandle());

		private static bool AVICapSM(HWND hwnd, capMessage msg, int v, Delegate d) => User32.SendMessage(hwnd, unchecked((uint)msg), (IntPtr)v, Marshal.GetFunctionPointerForDelegate(d)) != IntPtr.Zero;

		private static bool AVICapSM(HWND hwnd, capMessage msg, [Optional] IntPtr wparam, [Optional] IntPtr lparam) => User32.SendMessage(hwnd, unchecked((uint)msg), wparam, lparam) != IntPtr.Zero;

		private static bool AVICapSM(HWND hwnd, capMessage msg, StringBuilder lparam) => User32.SendMessage(hwnd, unchecked((uint)msg), (IntPtr)(lparam?.Capacity ?? 0), lparam) != IntPtr.Zero;

		private static int AVICapSM<TLP>(HWND hwnd, capMessage msg, int size, in TLP lparam) where TLP : struct
		{
			TLP res = lparam;
			return User32.SendMessage(hwnd, msg, (IntPtr)(size == -1 ? Marshal.SizeOf(typeof(TLP)) : size), ref res).ToInt32();
		}

		private static int AVICapSM<TLP>(HWND hwnd, capMessage msg, out TLP lparam, int size = -1) where TLP : struct
		{
			TLP res = default;
			var ret = User32.SendMessage(hwnd, msg, (IntPtr)(size == -1 ? Marshal.SizeOf(typeof(TLP)) : size), ref res).ToInt32();
			lparam = res;
			return ret;
		}

		private static bool AVICapSM(HWND hwnd, capMessage msg, string lparam) => User32.SendMessage(hwnd, unchecked((uint)msg), default, lparam) != IntPtr.Zero;

		/// <summary>
		/// <para>The <c>CAPDRIVERCAPS</c> structure defines the capabilities of the capture driver.</para>
		/// <para>
		/// An application should use the WM_CAP_DRIVER_GET_CAPS message or capDriverGetCaps macro to place a copy of the driver
		/// capabilities in a <c>CAPDRIVERCAPS</c> structure whenever the application connects a capture window to a capture driver.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-capdrivercaps typedef struct tagCapDriverCaps { UINT wDeviceIndex;
		// BOOL fHasOverlay; BOOL fHasDlgVideoSource; BOOL fHasDlgVideoFormat; BOOL fHasDlgVideoDisplay; BOOL fCaptureInitialized; BOOL
		// fDriverSuppliesPalettes; HANDLE hVideoIn; HANDLE hVideoOut; HANDLE hVideoExtIn; HANDLE hVideoExtOut; } CAPDRIVERCAPS,
		// *PCAPDRIVERCAPS, *LPCAPDRIVERCAPS;
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.tagCapDriverCaps")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CAPDRIVERCAPS
		{
			/// <summary>Index of the capture driver. An index value can range from 0 to 9.</summary>
			public uint wDeviceIndex;

			/// <summary>Video-overlay flag. The value of this member is <c>TRUE</c> if the device supports video overlay.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fHasOverlay;

			/// <summary>
			/// Video source dialog flag. The value of this member is <c>TRUE</c> if the device supports a dialog box for selecting and
			/// controlling the video source.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fHasDlgVideoSource;

			/// <summary>
			/// Video format dialog flag. The value of this member is <c>TRUE</c> if the device supports a dialog box for selecting the
			/// video format.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fHasDlgVideoFormat;

			/// <summary>
			/// Video display dialog flag. The value of this member is <c>TRUE</c> if the device supports a dialog box for controlling the
			/// redisplay of video from the capture frame buffer.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fHasDlgVideoDisplay;

			/// <summary>
			/// Capture initialization flag. The value of this member is <c>TRUE</c> if a capture device has been successfully connected.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fCaptureInitialized;

			/// <summary>Driver palette flag. The value of this member is <c>TRUE</c> if the driver can create palettes.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fDriverSuppliesPalettes;

			/// <summary>Not used in Win32 applications.</summary>
			public HANDLE hVideoIn;

			/// <summary>Not used in Win32 applications.</summary>
			public HANDLE hVideoOut;

			/// <summary>Not used in Win32 applications.</summary>
			public HANDLE hVideoExtIn;

			/// <summary>Not used in Win32 applications.</summary>
			public HANDLE hVideoExtOut;
		}

		/// <summary>
		/// The <c>CAPINFOCHUNK</c> structure contains parameters that can be used to define an information chunk within an AVI capture
		/// file. The WM_CAP_FILE_SET_INFOCHUNK message or <c>capSetInfoChunk</c> macro is used to send a <c>CAPINFOCHUNK</c> structure to a
		/// capture window.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-capinfochunk typedef struct tagCapInfoChunk { FOURCC fccInfoID;
		// LPVOID lpData; LONG cbData; } CAPINFOCHUNK, *PCAPINFOCHUNK, *LPCAPINFOCHUNK;
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.tagCapInfoChunk")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CAPINFOCHUNK
		{
			/// <summary>
			/// Four-character code that identifies the representation of the chunk data. If this value is <c>NULL</c> and <c>lpData</c> is
			/// <c>NULL</c>, all accumulated information chunks are deleted.
			/// </summary>
			public uint fccInfoID;

			/// <summary>Pointer to the data. If this value is <c>NULL</c>, all <c>fccInfoID</c> information chunks are deleted.</summary>
			public IntPtr lpData;

			/// <summary>
			/// Size, in bytes, of the data pointed to by <c>lpData</c>. If <c>lpData</c> specifies a null-terminated string, use the string
			/// length incremented by one to save the <c>NULL</c> with the string.
			/// </summary>
			public int cbData;
		}

		/// <summary>The <c>CAPSTATUS</c> structure defines the current state of the capture window.</summary>
		/// <remarks>
		/// Because the state of a capture window changes in response to various messages, an application should update the information in
		/// this structure whenever it needs to enable menu items, determine the actual state of the capture window, or call the video
		/// format dialog box. If the application yields during streaming capture, this structure returns the progress of the capture in the
		/// <c>dwCurrentVideoFrame</c>, <c>dwCurrentVideoFramesDropped</c>, dwCurre <c></c> ntWaveSamples, and <c>dwCurrentTimeElapsedMS</c>
		/// members. Use the WM_CAP_GET_STATUS message or capGetStatus macro to update the contents of this structure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-capstatus typedef struct tagCapStatus { UINT uiImageWidth; UINT
		// uiImageHeight; BOOL fLiveWindow; BOOL fOverlayWindow; BOOL fScale; POINT ptScroll; BOOL fUsingDefaultPalette; BOOL
		// fAudioHardware; BOOL fCapFileExists; DWORD dwCurrentVideoFrame; DWORD dwCurrentVideoFramesDropped; DWORD dwCurrentWaveSamples;
		// DWORD dwCurrentTimeElapsedMS; HPALETTE hPalCurrent; BOOL fCapturingNow; DWORD dwReturn; UINT wNumVideoAllocated; UINT
		// wNumAudioAllocated; } CAPSTATUS, *PCAPSTATUS, *LPCAPSTATUS;
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.tagCapStatus")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CAPSTATUS
		{
			/// <summary>Image width, in pixels.</summary>
			public uint uiImageWidth;

			/// <summary>Image height, in pixels</summary>
			public uint uiImageHeight;

			/// <summary>
			/// Live window flag. The value of this member is <c>TRUE</c> if the window is displaying video using the preview method.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fLiveWindow;

			/// <summary>
			/// Overlay window flag. The value of this member is <c>TRUE</c> if the window is displaying video using hardware overlay.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fOverlayWindow;

			/// <summary>
			/// Input scaling flag. The value of this member is <c>TRUE</c> if the window is scaling the input video to the client area when
			/// displaying video using preview. This parameter has no effect when displaying video using overlay.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fScale;

			/// <summary>The x- and y-offset of the pixel displayed in the upper left corner of the client area of the window.</summary>
			public POINT ptScroll;

			/// <summary>Default palette flag. The value of this member is <c>TRUE</c> if the capture driver is using its default palette.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fUsingDefaultPalette;

			/// <summary>Audio hardware flag. The value of this member is <c>TRUE</c> if the system has waveform-audio hardware installed.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fAudioHardware;

			/// <summary>Capture file flag. The value of this member is <c>TRUE</c> if a valid capture file has been generated.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fCapFileExists;

			/// <summary>
			/// Number of frames processed during the current (or most recent) streaming capture. This count includes dropped frames.
			/// </summary>
			public uint dwCurrentVideoFrame;

			/// <summary>
			/// Number of frames dropped during the current (or most recent) streaming capture. Dropped frames occur when the capture rate
			/// exceeds the rate at which frames can be saved to file. In this case, the capture driver has no buffers available for storing
			/// data. Dropping frames does not affect synchronization because the previous frame is displayed in place of the dropped frame.
			/// </summary>
			public uint dwCurrentVideoFramesDropped;

			/// <summary>Number of waveform-audio samples processed during the current (or most recent) streaming capture.</summary>
			public uint dwCurrentWaveSamples;

			/// <summary>Time, in milliseconds, since the start of the current (or most recent) streaming capture.</summary>
			public uint dwCurrentTimeElapsedMS;

			/// <summary>Handle to current palette.</summary>
			public HPALETTE hPalCurrent;

			/// <summary>Capturing flag. The value of this member is <c>TRUE</c> when capturing is in progress.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fCapturingNow;

			/// <summary>Error return values. Use this member if your application does not support an error callback function.</summary>
			public uint dwReturn;

			/// <summary>
			/// Number of video buffers allocated. This value might be less than the number specified in the <c>wNumVideoRequested</c>
			/// member of the CAPTUREPARMS structure.
			/// </summary>
			public uint wNumVideoAllocated;

			/// <summary>
			/// Number of audio buffers allocated. This value might be less than the number specified in the <c>wNumAudioRequested</c>
			/// member of the CAPTUREPARMS structure.
			/// </summary>
			public uint wNumAudioAllocated;
		}

		/// <summary>
		/// The <c>CAPTUREPARMS</c> structure contains parameters that control the streaming video capture process. This structure is used
		/// to get and set parameters that affect the capture rate, the number of buffers to use while capturing, and how capture is terminated.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The WM_CAP_GET_SEQUENCE_SETUP message or capCaptureGetSetup macro is used to retrieve the current capture parameters. The
		/// WM_CAP_SET_SEQUENCE_SETUP message or capCaptureSetSetup macro is used to set the capture parameters.
		/// </para>
		/// <para>
		/// The WM_CAP_GET_SEQUENCE_SETUP message or capCaptureGetSetup macro is used to retrieve the current capture parameters. The
		/// WM_CAP_SET_SEQUENCE_SETUP message or capCaptureSetSetup macro is used to set the capture parameters.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-captureparms typedef struct tagCaptureParms { DWORD
		// dwRequestMicroSecPerFrame; BOOL fMakeUserHitOKToCapture; UINT wPercentDropForError; BOOL fYield; DWORD dwIndexSize; UINT
		// wChunkGranularity; BOOL fUsingDOSMemory; UINT wNumVideoRequested; BOOL fCaptureAudio; UINT wNumAudioRequested; UINT vKeyAbort;
		// BOOL fAbortLeftMouse; BOOL fAbortRightMouse; BOOL fLimitEnabled; UINT wTimeLimit; BOOL fMCIControl; BOOL fStepMCIDevice; DWORD
		// dwMCIStartTime; DWORD dwMCIStopTime; BOOL fStepCaptureAt2x; UINT wStepCaptureAverageFrames; DWORD dwAudioBufferSize; BOOL
		// fDisableWriteCache; UINT AVStreamMaster; } CAPTUREPARMS, *PCAPTUREPARMS, *LPCAPTUREPARMS;
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.tagCaptureParms")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CAPTUREPARMS
		{
			/// <summary>Requested frame rate, in microseconds. The default value is 66667, which corresponds to 15 frames per second.</summary>
			public uint dwRequestMicroSecPerFrame;

			/// <summary>
			/// User-initiated capture flag. If this member is <c>TRUE</c>, AVICap displays a dialog box prompting the user to initiate
			/// capture. The default value is <c>FALSE</c>.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fMakeUserHitOKToCapture;

			/// <summary>
			/// Maximum allowable percentage of dropped frames during capture. Values range from 0 to 100. The default value is 10.
			/// </summary>
			public uint wPercentDropForError;

			/// <summary>
			/// <para>
			/// Yield flag. If this member is <c>TRUE</c>, the capture window spawns a separate background thread to perform step and
			/// streaming capture. The default value is <c>FALSE</c>.
			/// </para>
			/// <para>
			/// Applications that set this flag must handle potential reentry issues because the controls in the application are not
			/// disabled while capture is in progress.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fYield;

			/// <summary>
			/// <para>
			/// Maximum number of index entries in an AVI file. Values range from 1800 to 324,000. If set to 0, a default value of 34,952
			/// (32K frames plus a proportional number of audio buffers) is used.
			/// </para>
			/// <para>
			/// Each video frame or buffer of waveform-audio data uses one index entry. The value of this entry establishes a limit for the
			/// number of frames or audio buffers that can be captured.
			/// </para>
			/// </summary>
			public uint dwIndexSize;

			/// <summary>Logical block size, in bytes, of an AVI file. The value 0 indicates the current sector size is used as the granularity.</summary>
			public uint wChunkGranularity;

			/// <summary>Not used in Win32 applications.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fUsingDOSMemory;

			/// <summary>
			/// Maximum number of video buffers to allocate. The memory area to place the buffers is specified with <c>fUsingDOSMemory</c>.
			/// The actual number of buffers allocated might be lower if memory is unavailable.
			/// </summary>
			public uint wNumVideoRequested;

			/// <summary>
			/// Capture audio flag. If this member is <c>TRUE</c>, audio is captured during streaming capture. This is the default value if
			/// audio hardware is installed.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fCaptureAudio;

			/// <summary>Maximum number of audio buffers to allocate. The maximum number of buffers is 10.</summary>
			public uint wNumAudioRequested;

			/// <summary>
			/// <para>
			/// Virtual keycode used to terminate streaming capture. The default value is VK_ESCAPE. You must call the RegisterHotKey
			/// function before specifying a keystroke that can abort a capture session.
			/// </para>
			/// <para>
			/// You can combine keycodes that include CTRL and SHIFT keystrokes by using the logical OR operator with the keycodes for CTRL
			/// (0x8000) and SHIFT (0x4000).
			/// </para>
			/// </summary>
			public uint vKeyAbort;

			/// <summary>
			/// Abort flag for left mouse button. If this member is <c>TRUE</c>, streaming capture stops if the left mouse button is
			/// pressed. The default value is <c>TRUE</c>.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fAbortLeftMouse;

			/// <summary>
			/// Abort flag for right mouse button. If this member is <c>TRUE</c>, streaming capture stops if the right mouse button is
			/// pressed. The default value is <c>TRUE</c>.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fAbortRightMouse;

			/// <summary>
			/// Time limit enabled flag. If this member is <c>TRUE</c>, streaming capture stops after the number of seconds in
			/// <c>wTimeLimit</c> has elapsed. The default value is <c>FALSE</c>.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fLimitEnabled;

			/// <summary>Time limit for capture, in seconds. This parameter is used only if <c>fLimitEnabled</c> is <c>TRUE</c>.</summary>
			public uint wTimeLimit;

			/// <summary>
			/// MCI device capture flag. If this member is <c>TRUE</c>, AVICap controls an MCI-compatible video source during streaming
			/// capture. MCI-compatible video sources include VCRs and laserdiscs.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fMCIControl;

			/// <summary>
			/// MCI device step capture flag. If this member is <c>TRUE</c>, step capture using an MCI device as a video source is enabled.
			/// If it is <c>FALSE</c>, real-time capture using an MCI device is enabled. (If <c>fMCIControl</c> is <c>FALSE</c>, this member
			/// is ignored.)
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fStepMCIDevice;

			/// <summary>
			/// Starting position, in milliseconds, of the MCI device for the capture sequence. (If <c>fMCIControl</c> is <c>FALSE</c>, this
			/// member is ignored.)
			/// </summary>
			public uint dwMCIStartTime;

			/// <summary>
			/// Stopping position, in milliseconds, of the MCI device for the capture sequence. When this position in the content is
			/// reached, capture ends and the MCI device stops. (If <c>fMCIControl</c> is <c>FALSE</c>, this member is ignored.)
			/// </summary>
			public uint dwMCIStopTime;

			/// <summary>
			/// <para>
			/// Double-resolution step capture flag. If this member is <c>TRUE</c>, the capture hardware captures at twice the specified
			/// resolution. (The resolution for the height and width is doubled.)
			/// </para>
			/// <para>Enable this option if the hardware does not support hardware-based decimation and you are capturing in the RGB format.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fStepCaptureAt2x;

			/// <summary>
			/// Number of times a frame is sampled when creating a frame based on the average sample. A typical value for the number of
			/// averages is 5.
			/// </summary>
			public uint wStepCaptureAverageFrames;

			/// <summary>
			/// Audio buffer size. If the default value of zero is used, the size of each buffer will be the maximum of 0.5 seconds of audio
			/// or 10K bytes.
			/// </summary>
			public uint dwAudioBufferSize;

			/// <summary>Not used in Win32 applications.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fDisableWriteCache;

			/// <summary>
			/// Indicates whether the audio stream controls the clock when writing an AVI file. If this member is set to
			/// AVSTREAMMASTER_AUDIO, the audio stream is considered the master stream and the video stream duration is forced to match the
			/// audio duration. If this member is set to AVSTREAMMASTER_NONE, the durations of audio and video streams can differ.
			/// </summary>
			public uint AVStreamMaster;
		}

		/// <summary>The <c>VIDEOHDR</c> structure is used by the capVideoStreamCallback function.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-videohdr typedef struct videohdr_tag { LPBYTE lpData; DWORD
		// dwBufferLength; DWORD dwBytesUsed; DWORD dwTimeCaptured; DWORD_PTR dwUser; DWORD dwFlags; DWORD_PTR dwReserved[4]; } VIDEOHDR,
		// *PVIDEOHDR, *LPVIDEOHDR;
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.videohdr_tag")]
		[StructLayout(LayoutKind.Sequential)]
		public struct VIDEOHDR
		{
			/// <summary>Pointer to locked data buffer.</summary>
			public IntPtr lpData;

			/// <summary>Length of data buffer.</summary>
			public uint dwBufferLength;

			/// <summary>Bytes actually used.</summary>
			public uint dwBytesUsed;

			/// <summary>Milliseconds from start of stream.</summary>
			public uint dwTimeCaptured;

			/// <summary>User-defined data.</summary>
			public IntPtr dwUser;

			/// <summary>
			/// <para>The flags are defined as follows.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Flag</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>VHDR_DONE</term>
			/// <term>Done bit</term>
			/// </item>
			/// <item>
			/// <term>VHDR_PREPARED</term>
			/// <term>Set if this header has been prepared</term>
			/// </item>
			/// <item>
			/// <term>VHDR_INQUEUE</term>
			/// <term>Reserved for driver</term>
			/// </item>
			/// <item>
			/// <term>VHDR_KEYFRAME</term>
			/// <term>Key Frame</term>
			/// </item>
			/// </list>
			/// </summary>
			public VHDR dwFlags;

			/// <summary>Reserved for driver.</summary>
			public IntPtr dwReserved1;

			/// <summary>Reserved for driver.</summary>
			public IntPtr dwReserved2;

			/// <summary>Reserved for driver.</summary>
			public IntPtr dwReserved3;

			/// <summary>Reserved for driver.</summary>
			public IntPtr dwReserved4;
		}
	}
}