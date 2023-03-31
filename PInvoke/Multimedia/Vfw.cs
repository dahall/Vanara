#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.WinMm;

namespace Vanara.PInvoke;

/// <summary>Items from the AviFil32.dll</summary>
public static partial class AviFil32
{
	/// <summary></summary>
	public static readonly uint ckidAVIMAINHDR = MAKEFOURCC('a', 'v', 'i', 'h');

	/// <summary></summary>
	public static readonly uint ckidAVINEWINDEX = MAKEFOURCC('i', 'd', 'x', '1');

	/// <summary></summary>
	public static readonly uint ckidAVIPADDING = MAKEFOURCC('J', 'U', 'N', 'K');

	/// <summary></summary>
	public static readonly uint ckidSTREAMFORMAT = MAKEFOURCC('s', 't', 'r', 'f');

	/// <summary></summary>
	public static readonly uint ckidSTREAMHANDLERDATA = MAKEFOURCC('s', 't', 'r', 'd');

	/// <summary></summary>
	public static readonly uint ckidSTREAMHEADER = MAKEFOURCC('s', 't', 'r', 'h');

	/// <summary></summary>
	public static readonly uint ckidSTREAMNAME = MAKEFOURCC('s', 't', 'r', 'n');

	/// <summary></summary>
	public static readonly ushort cktypeDIBbits = aviTWOCC('d', 'b');

	/// <summary></summary>
	public static readonly ushort cktypeDIBcompressed = aviTWOCC('d', 'c');

	/// <summary></summary>
	public static readonly ushort cktypePALchange = aviTWOCC('p', 'c');

	/// <summary></summary>
	public static readonly ushort cktypeWAVEbytes = aviTWOCC('w', 'b');

	/// <summary></summary>
	public static readonly uint formtypeAVI = MAKEFOURCC('A', 'V', 'I', ' ');

	/// <summary></summary>
	public static readonly uint listtypeAVIHEADER = MAKEFOURCC('h', 'd', 'r', 'l');

	/// <summary></summary>
	public static readonly uint listtypeAVIMOVIE = MAKEFOURCC('m', 'o', 'v', 'i');

	/// <summary></summary>
	public static readonly uint listtypeAVIRECORD = MAKEFOURCC('r', 'e', 'c', ' ');

	/// <summary></summary>
	public static readonly uint listtypeSTREAMHEADER = MAKEFOURCC('s', 't', 'r', 'l');

	/// <summary></summary>
	public static readonly uint streamtypeAUDIO = MAKEFOURCC('a', 'u', 'd', 's');

	/// <summary></summary>
	public static readonly uint streamtypeMIDI = MAKEFOURCC('m', 'i', 'd', 's');

	/// <summary></summary>
	public static readonly uint streamtypeTEXT = MAKEFOURCC('t', 'x', 't', 's');

	/// <summary></summary>
	public static readonly uint streamtypeVIDEO = MAKEFOURCC('v', 'i', 'd', 's');

	/// <summary>Flags for <c>VIDEOHDR</c></summary>
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.videohdr_tag")]
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
		public AVSTREAMMASTER AVStreamMaster;
	}

	/// <summary>
	/// The <c>DRAWDIBTIME</c> structure contains elapsed timing information for performing a set of DrawDib operations. The DrawDibTime
	/// function resets the count and the elapsed time value for each operation each time it is called.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-drawdibtime typedef struct { LONG timeCount; LONG timeDraw; LONG
	// timeDecompress; LONG timeDither; LONG timeStretch; LONG timeBlt; LONG timeSetDIBits; } DRAWDIBTIME, *LPDRAWDIBTIME;
	[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_12")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DRAWDIBTIME
	{
		/// <summary>
		/// <para>Number of times the following operations have been performed since DrawDibTime was last called:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Draw a bitmap on the screen.</term>
		/// </item>
		/// <item>
		/// <term>Decompress a bitmap.</term>
		/// </item>
		/// <item>
		/// <term>Dither a bitmap.</term>
		/// </item>
		/// <item>
		/// <term>Stretch a bitmap.</term>
		/// </item>
		/// <item>
		/// <term>Transfer bitmap data by using the BitBlt function.</term>
		/// </item>
		/// <item>
		/// <term>Transfer bitmap data by using the SetDIBits function.</term>
		/// </item>
		/// </list>
		/// </summary>
		public int timeCount;

		/// <summary>Time to draw bitmaps.</summary>
		public int timeDraw;

		/// <summary>Time to decompress bitmaps.</summary>
		public int timeDecompress;

		/// <summary>Time to dither bitmaps.</summary>
		public int timeDither;

		/// <summary>Time to stretch bitmaps.</summary>
		public int timeStretch;

		/// <summary>Time to transfer bitmaps by using the BitBlt function.</summary>
		public int timeBlt;

		/// <summary>Time to transfer bitmaps by using the SetDIBits function.</summary>
		public int timeSetDIBits;
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
		private readonly IntPtr dwReserved1;
		private readonly IntPtr dwReserved2;
		private readonly IntPtr dwReserved3;
		private readonly IntPtr dwReserved4;
	}
}