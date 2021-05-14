#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.WinMm;

namespace Vanara.PInvoke
{
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

		/// <summary>Flags used for compression.</summary>
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_2")]
		[Flags]
		public enum ICCOMPRESSF : uint
		{
			/// <summary>Input data should be treated as a key frame.</summary>
			ICCOMPRESS_KEYFRAME = 0x00000001
		}

		/// <summary>Applicable flags.</summary>
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_3")]
		[Flags]
		public enum ICCOMPRESSFRAMESF : uint
		{
			/// <summary>Padding is used with the frame.</summary>
			ICCOMPRESSFRAMES_PADDING = 1
		}

		/// <summary>Applicable flags.</summary>
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_5")]
		[Flags]
		public enum ICDECOMPRESSF : uint
		{
			/// <summary>
			/// Tries to decompress at a faster rate. When an application uses this flag, the driver should buffer the decompressed data but
			/// not draw the image.
			/// </summary>
			ICDECOMPRESS_HURRYUP = 0x80000000,

			/// <summary>Screen is being updated or refreshed.</summary>
			ICDECOMPRESS_UPDATE = 0x40000000,

			/// <summary>Current frame precedes the point in the movie where playback starts and, therefore, will not be drawn.</summary>
			ICDECOMPRESS_PREROLL = 0x20000000,

			/// <summary>Current frame does not contain data and the decompressed image should be left the same.</summary>
			ICDECOMPRESS_NULLFRAME = 0x10000000,

			/// <summary>Current frame is not a key frame.</summary>
			ICDECOMPRESS_NOTKEYFRAME = 0x08000000,
		}

		/// <summary>Flags from the AVI file index.</summary>
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_8")]
		[Flags]
		public enum ICDRAWF : uint
		{
			/// <summary>Determines if the decompressor can handle the decompression. The driver does not actually decompress the data.</summary>
			ICDRAW_QUERY = 0x00000001,

			/// <summary>Draws the decompressed data on the full screen.</summary>
			ICDRAW_FULLSCREEN = 0x00000002,

			/// <summary>Draws the decompressed data to a window or a DC.</summary>
			ICDRAW_HDC = 0x00000004,

			/// <summary>Application can animate the palette.</summary>
			ICDRAW_ANIMATE = 0x00000008,

			/// <summary>Drawing is a continuation of the previous frame.</summary>
			ICDRAW_CONTINUE = 0x00000010,

			/// <summary>DC is off-screen.</summary>
			ICDRAW_MEMORYDC = 0x00000020,

			/// <summary>Current frame is being updated rather than played.</summary>
			ICDRAW_UPDATING = 0x00000040,

			/// <summary>Renders but does not draw the data.</summary>
			ICDRAW_RENDER = 0x00000080,

			/// <summary>Buffers this data off-screen; it will need to be updated.</summary>
			ICDRAW_BUFFER = 0x00000100,

			/// <summary>Data is buffered and not drawn to the screen. Use this flag for fastest decompression.</summary>
			ICDRAW_HURRYUP = 0x80000000,

			/// <summary>Updates the screen based on data previously received. In this case, lpData should be ignored.</summary>
			ICDRAW_UPDATE = 0x40000000,

			/// <summary>
			/// Current frame of video occurs before playback should start. For example, if playback will begin on frame 10, and frame 0 is
			/// the nearest previous key frame, frames 0 through 9 are sent to the driver with this flag set. The driver needs this data to
			/// display frame 10 properly.
			/// </summary>
			ICDRAW_PREROLL = 0x20000000,

			/// <summary>Current frame does not contain any data, and the previous frame should be redrawn.</summary>
			ICDRAW_NULLFRAME = 0x10000000,

			/// <summary>Current frame is not a key frame.</summary>
			ICDRAW_NOTKEYFRAME = 0x08000000,
		}

		/// <summary>Applicable flags.</summary>
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_11")]
		public enum ICMF_COMPVARS
		{
			/// <summary>
			/// Data in this structure is valid and has been manually entered. Set this flag before you call any function if you fill this
			/// structure manually. Do not set this flag if you let ICCompressorChoose initialize this structure.
			/// </summary>
			ICMF_COMPVARS_VALID = 0x00000001
		}

		/// <summary>Applicable flags indicating why the driver is opened.</summary>
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_0")]
		public enum ICMODE
		{
			/// <summary>Driver is opened to compress data.</summary>
			ICMODE_COMPRESS = 1,

			/// <summary>Driver is opened to decompress data.</summary>
			ICMODE_DECOMPRESS = 2,

			/// <summary></summary>
			ICMODE_FASTDECOMPRESS = 3,

			/// <summary>Driver is opened for informational purposes, rather than for compression.</summary>
			ICMODE_QUERY = 4,

			/// <summary></summary>
			ICMODE_FASTCOMPRESS = 5,

			/// <summary>Device driver is opened to decompress data directly to hardware.</summary>
			ICMODE_DRAW = 8,
		}

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

		/// <summary>Applicable flags.</summary>
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_1")]
		[Flags]
		public enum VIDCF : uint
		{
			/// <summary>Driver supports quality values.</summary>
			VIDCF_QUALITY = 0x0001,

			/// <summary>Driver supports compressing to a frame size.</summary>
			VIDCF_CRUNCH = 0x0002,

			/// <summary>Driver supports inter-frame compression.</summary>
			VIDCF_TEMPORAL = 0x0004,

			/// <summary>
			/// Driver is requesting to compress all frames. For information about compressing all frames, see the ICM_COMPRESS_FRAMES_INFO message.
			/// </summary>
			VIDCF_COMPRESSFRAMES = 0x0008,

			/// <summary>Driver supports drawing.</summary>
			VIDCF_DRAW = 0x0010,

			/// <summary>
			/// Driver can perform temporal compression and maintains its own copy of the current frame. When compressing a stream of frame
			/// data, the driver doesn't need image data from the previous frame.
			/// </summary>
			VIDCF_FASTTEMPORALC = 0x0020,

			/// <summary>
			/// Driver can perform temporal decompression and maintains its own copy of the current frame. When decompressing a stream of
			/// frame data, the driver doesn't need image data from the previous frame.
			/// </summary>
			VIDCF_FASTTEMPORALD = 0x0080,
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
			public System.Drawing.Point ptScroll;

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
		/// The <c>COMPVARS</c> structure describes compressor settings for functions such as ICCompressorChoose, ICSeqCompressFrame, and ICCompressorFree.
		/// </summary>
		/// <remarks>
		/// You can let ICCompressorChoose fill the contents of this structure or you can do it manually. If you manually fill the
		/// structure, you must provide information for the following members: <c>cbSize</c>, <c>hic</c>, <c>lpbiOut</c>, <c>lKey</c>, and
		/// <c>lQ</c>. Also, you must set the <c>ICMF_COMPVARS_VALID</c> flag in the <c>dwFlags</c> member.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-compvars typedef struct { LONG cbSize; DWORD dwFlags; HIC hic;
		// DWORD fccType; DWORD fccHandler; LPBITMAPINFO lpbiIn; LPBITMAPINFO lpbiOut; LPVOID lpBitsOut; LPVOID lpBitsPrev; LONG lFrame;
		// LONG lKey; LONG lDataRate; LONG lQ; LONG lKeyCount; LPVOID lpState; LONG cbState; } COMPVARS, *PCOMPVARS;
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_11")]
		[StructLayout(LayoutKind.Sequential)]
		public struct COMPVARS
		{
			/// <summary>
			/// Size, in bytes, of this structure. This member must be set to validate the structure before calling any function using this structure.
			/// </summary>
			public int cbSize;

			/// <summary>
			/// <para>Applicable flags. The following value is defined:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ICMF_COMPVARS_VALID</term>
			/// <term>
			/// Data in this structure is valid and has been manually entered. Set this flag before you call any function if you fill this
			/// structure manually. Do not set this flag if you let ICCompressorChoose initialize this structure.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ICMF_COMPVARS dwFlags;

			/// <summary>
			/// Handle to the compressor to use. You can open a compressor and obtain a handle of it by using the ICOpen function. You can
			/// also choose a compressor by using ICCompressorChoose. <c>ICCompressorChoose</c> opens the chosen compressor and returns the
			/// handle of the compressor in this member. You can close the compressor by using ICCompressorFree.
			/// </summary>
			public HIC hic;

			/// <summary>Type of compressor used. Currently only <c>ICTYPE_VIDEO</c> (VIDC) is supported. This member can be set to zero.</summary>
			public uint fccType;

			/// <summary>
			/// Four-character code of the compressor. Specify <c>NULL</c> to indicate the data is not to be recompressed. Specify "DIB" to
			/// indicate the data is an uncompressed, full frame. You can use this member to specify which compressor is selected by default
			/// when the dialog box is displayed.
			/// </summary>
			public uint fccHandler;

			/// <summary>Reserved; do not use.</summary>
			public IntPtr lpbiIn;

			/// <summary>
			/// Pointer to a BITMAPINFO structure containing the image output format. You can specify a specific format to use or you can
			/// specify <c>NULL</c> to use the default compressor associated with the input format. You can also set the image output format
			/// by using ICCompressorChoose.
			/// </summary>
			public IntPtr lpbiOut;

			/// <summary>Reserved; do not use.</summary>
			public IntPtr lpBitsOut;

			/// <summary>Reserved; do not use.</summary>
			public IntPtr lpBitsPrev;

			/// <summary>Reserved; do not use.</summary>
			public int lFrame;

			/// <summary>
			/// Key-frame rate. Specify an integer to indicate the frequency that key frames are to occur in the compressed sequence or zero
			/// to not use key frames. You can also let ICCompressorChoose set the key-frame rate selected in the dialog box. The
			/// ICSeqCompressFrameStart function uses the value of this member for making key frames.
			/// </summary>
			public int lKey;

			/// <summary>
			/// Data rate, in kilobytes per second. ICCompressorChoose copies the selected data rate from the dialog box to this member.
			/// </summary>
			public int lDataRate;

			/// <summary>
			/// Quality setting. Specify a quality setting of 1 to 10,000 or specify <c>ICQUALITY_DEFAULT</c> to use the default quality
			/// setting. You can also let ICCompressorChoose set the quality value selected in the dialog box. ICSeqCompressFrameStart uses
			/// the value of this member as its quality setting.
			/// </summary>
			public int lQ;

			/// <summary>Reserved; do not use.</summary>
			public int lKeyCount;

			/// <summary>Reserved; do not use.</summary>
			public IntPtr lpState;

			/// <summary>Reserved; do not use.</summary>
			public int cbState;
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

		/// <summary>Provides a handle to an image decompressor.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HIC : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HIC"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HIC(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HIC"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HIC NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HIC"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HIC h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HIC"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HIC(IntPtr h) => new(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HIC h1, HIC h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HIC h1, HIC h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HIC h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>The <c>ICCOMPRESS</c> structure contains compression parameters used with the ICM_COMPRESS message.</summary>
		/// <remarks>
		/// Drivers that perform temporal compression use data from the previous frame (found in the <c>lpbiPrev</c> and <c>lpPrev</c>
		/// members) to prune redundant data from the current frame.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-iccompress typedef struct { DWORD dwFlags; LPBITMAPINFOHEADER
		// lpbiOutput; LPVOID lpOutput; LPBITMAPINFOHEADER lpbiInput; LPVOID lpInput; LPDWORD lpckid; LPDWORD lpdwFlags; LONG lFrameNum;
		// DWORD dwFrameSize; DWORD dwQuality; LPBITMAPINFOHEADER lpbiPrev; LPVOID lpPrev; } ICCOMPRESS;
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_2")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ICCOMPRESS
		{
			/// <summary>
			/// <para>Flags used for compression. The following value is defined:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ICCOMPRESS_KEYFRAME</term>
			/// <term>Input data should be treated as a key frame.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ICCOMPRESSF dwFlags;

			/// <summary>
			/// Pointer to a BITMAPINFOHEADER structure containing the output (compressed) format. The <c>biSizeImage</c> member must
			/// contain the size of the compressed data.
			/// </summary>
			public IntPtr lpbiOutput;

			/// <summary>Pointer to the buffer where the driver should write the compressed data.</summary>
			public IntPtr lpOutput;

			/// <summary>Pointer to a BITMAPINFOHEADER structure containing the input (uncompressed) format.</summary>
			public IntPtr lpbiInput;

			/// <summary>Pointer to the buffer containing input data.</summary>
			public IntPtr lpInput;

			/// <summary>
			/// Address to contain the chunk identifier for data in the AVI file. If the value of this member is not <c>NULL</c>, the driver
			/// should specify a two-character code for the chunk identifier corresponding to the chunk identifier used in the AVI file.
			/// </summary>
			public uint lpckid;

			/// <summary>
			/// Address to contain flags for the AVI index. If the returned frame is a key frame, the driver should set the
			/// <c>AVIIF_KEYFRAME</c> flag.
			/// </summary>
			public uint lpdwFlags;

			/// <summary>Number of the frame to compress.</summary>
			public int lFrameNum;

			/// <summary>
			/// Desired maximum size, in bytes, for compressing this frame. The size value is used for compression methods that can make
			/// tradeoffs between compressed image size and image quality. Specify zero for this member to use the default setting.
			/// </summary>
			public uint dwFrameSize;

			/// <summary>Quality setting.</summary>
			public uint dwQuality;

			/// <summary>
			/// Pointer to a BITMAPINFOHEADER structure containing the format of the previous frame, which is typically the same as the
			/// input format.
			/// </summary>
			public IntPtr lpbiPrev;

			/// <summary>Pointer to the buffer containing input data of the previous frame.</summary>
			public IntPtr lpPrev;
		}

		/// <summary>The <c>ICCOMPRESSFRAMES</c> structure contains compression parameters used with the ICM_COMPRESS_FRAMES_INFO message.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-iccompressframes typedef struct { DWORD dwFlags; LPBITMAPINFOHEADER
		// lpbiOutput; LPARAM lOutput; LPBITMAPINFOHEADER lpbiInput; LPARAM lInput; LONG lStartFrame; LONG lFrameCount; LONG lQuality; LONG
		// lDataRate; LONG lKeyRate; DWORD dwRate; DWORD dwScale; DWORD dwOverheadPerFrame; DWORD dwReserved2; LONG( )(LPARAM lInput,LONG
		// lFrame,LPVOID lpBits,LONG len) *GetData; LONG( )(LPARAM lOutput,LONG lFrame,LPVOID lpBits,LONG len) *PutData; } ICCOMPRESSFRAMES;
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_3")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ICCOMPRESSFRAMES
		{
			/// <summary>
			/// Applicable flags. The following value is defined: <c>ICCOMPRESSFRAMES_PADDING</c>. If this value is used, padding is used
			/// with the frame.
			/// </summary>
			public ICCOMPRESSFRAMESF dwFlags;

			/// <summary>Pointer to a BITMAPINFOHEADER structure containing the output format.</summary>
			public IntPtr lpbiOutput;

			/// <summary>Reserved; do not use.</summary>
			public IntPtr lOutput;

			/// <summary>Pointer to a BITMAPINFOHEADER structure containing the input format.</summary>
			public IntPtr lpbiInput;

			/// <summary>Reserved; do not use.</summary>
			public IntPtr lInput;

			/// <summary>Number of the first frame to compress.</summary>
			public int lStartFrame;

			/// <summary>Number of frames to compress.</summary>
			public int lFrameCount;

			/// <summary>Quality setting.</summary>
			public int lQuality;

			/// <summary>Maximum data rate, in bytes per second.</summary>
			public int lDataRate;

			/// <summary>Maximum number of frames between consecutive key frames.</summary>
			public int lKeyRate;

			/// <summary>
			/// Compression rate in an integer format. To obtain the rate in frames per second, divide this value by the value in <c>dwScale</c>.
			/// </summary>
			public uint dwRate;

			/// <summary>Value used to scale <c>dwRate</c> to frames per second.</summary>
			public uint dwScale;

			/// <summary>Reserved; do not use.</summary>
			public uint dwOverheadPerFrame;

			/// <summary>Reserved; do not use.</summary>
			public uint dwReserved2;
		}

		/// <summary>The <c>ICDECOMPRESS</c> structure contains decompression parameters used with the ICM_DECOMPRESS message.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-icdecompress typedef struct { DWORD dwFlags; LPBITMAPINFOHEADER
		// lpbiInput; LPVOID lpInput; LPBITMAPINFOHEADER lpbiOutput; LPVOID lpOutput; DWORD ckid; } ICDECOMPRESS;
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_5")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ICDECOMPRESS
		{
			/// <summary>
			/// <para>Applicable flags. The following values are defined:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ICDECOMPRESS_HURRYUP</term>
			/// <term>
			/// Tries to decompress at a faster rate. When an application uses this flag, the driver should buffer the decompressed data but
			/// not draw the image.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ICDECOMPRESS_NOTKEYFRAME</term>
			/// <term>Current frame is not a key frame.</term>
			/// </item>
			/// <item>
			/// <term>ICDECOMPRESS_NULLFRAME</term>
			/// <term>Current frame does not contain data and the decompressed image should be left the same.</term>
			/// </item>
			/// <item>
			/// <term>ICDECOMPRESS_PREROLL</term>
			/// <term>Current frame precedes the point in the movie where playback starts and, therefore, will not be drawn.</term>
			/// </item>
			/// <item>
			/// <term>ICDECOMPRESS_UPDATE</term>
			/// <term>Screen is being updated or refreshed.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ICDECOMPRESSF dwFlags;

			/// <summary>Pointer to a BITMAPINFOHEADER structure containing the input format.</summary>
			public IntPtr lpbiInput;

			/// <summary>Pointer to a buffer containing the input data.</summary>
			public IntPtr lpInput;

			/// <summary>Pointer to a BITMAPINFOHEADER structure containing the output format.</summary>
			public IntPtr lpbiOutput;

			/// <summary>Pointer to a buffer where the driver should write the decompressed image.</summary>
			public IntPtr lpOutput;

			/// <summary>Chunk identifier from the AVI file.</summary>
			public uint ckid;
		}

		/// <summary>The <c>ICDECOMPRESSEX</c> structure contains decompression parameters used with the ICM_DECOMPRESSEX message</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-icdecompressex typedef struct { DWORD dwFlags; LPBITMAPINFOHEADER
		// lpbiSrc; LPVOID lpSrc; LPBITMAPINFOHEADER lpbiDst; LPVOID lpDst; int xDst; int yDst; int dxDst; int dyDst; int xSrc; int ySrc;
		// int dxSrc; int dySrc; } ICDECOMPRESSEX;
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_6")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ICDECOMPRESSEX
		{
			/// <summary>
			/// <para>Applicable flags. The following values are defined:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ICDECOMPRESS_HURRYUP</term>
			/// <term>
			/// Tries to decompress at a faster rate. When an application uses this flag, the driver should buffer the decompressed data but
			/// not draw the image.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ICDECOMPRESS_NOTKEYFRAME</term>
			/// <term>Current frame is not a key frame.</term>
			/// </item>
			/// <item>
			/// <term>ICDECOMPRESS_NULLFRAME</term>
			/// <term>Current frame does not contain data and the decompressed image should be left the same.</term>
			/// </item>
			/// <item>
			/// <term>ICDECOMPRESS_PREROLL</term>
			/// <term>Current frame precedes the point in the movie where playback starts and, therefore, will not be drawn.</term>
			/// </item>
			/// <item>
			/// <term>ICDECOMPRESS_UPDATE</term>
			/// <term>Screen is being updated or refreshed.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ICDECOMPRESSF dwFlags;

			/// <summary>Pointer to a BITMAPINFOHEADER structure containing the input format.</summary>
			public IntPtr lpbiSrc;

			/// <summary>Pointer to a buffer containing the input data.</summary>
			public IntPtr lpSrc;

			/// <summary>Pointer to a BITMAPINFOHEADER structure containing the output format.</summary>
			public IntPtr lpbiDst;

			/// <summary>Pointer to a buffer where the driver should write the decompressed image.</summary>
			public IntPtr lpDst;

			/// <summary>The x-coordinate of the destination rectangle within the DIB specified by <c>lpbiDst</c>.</summary>
			public int xDst;

			/// <summary>The y-coordinate of the destination rectangle within the DIB specified by <c>lpbiDst</c>.</summary>
			public int yDst;

			/// <summary>Width of the destination rectangle.</summary>
			public int dxDst;

			/// <summary>Height of the destination rectangle.</summary>
			public int dyDst;

			/// <summary>The x-coordinate of the source rectangle within the DIB specified by <c>lpbiSrc</c>.</summary>
			public int xSrc;

			/// <summary>The y-coordinate of the source rectangle within the DIB specified by <c>lpbiSrc</c>.</summary>
			public int ySrc;

			/// <summary>Width of the source rectangle.</summary>
			public int dxSrc;

			/// <summary>Height of the source rectangle.</summary>
			public int dySrc;
		}

		/// <summary>
		/// The <c>ICDRAW</c> structure contains parameters for drawing video data to the screen. This structure is used with the ICM_DRAW message.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-icdraw typedef struct { DWORD dwFlags; LPVOID lpFormat; LPVOID
		// lpData; DWORD cbData; LONG lTime; } ICDRAW;
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_8")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct ICDRAW
		{
			/// <summary>
			/// <para>Flags from the AVI file index. The following values are defined:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ICDRAW_HURRYUP</term>
			/// <term>Data is buffered and not drawn to the screen. Use this flag for fastest decompression.</term>
			/// </item>
			/// <item>
			/// <term>ICDRAW_NOTKEYFRAME</term>
			/// <term>Current frame is not a key frame.</term>
			/// </item>
			/// <item>
			/// <term>ICDRAW_NULLFRAME</term>
			/// <term>Current frame does not contain any data, and the previous frame should be redrawn.</term>
			/// </item>
			/// <item>
			/// <term>ICDRAW_PREROLL</term>
			/// <term>
			/// Current frame of video occurs before playback should start. For example, if playback will begin on frame 10, and frame 0 is
			/// the nearest previous key frame, frames 0 through 9 are sent to the driver with this flag set. The driver needs this data to
			/// display frame 10 properly.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ICDRAW_UPDATE</term>
			/// <term>Updates the screen based on data previously received. In this case, lpData should be ignored.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ICDRAWF dwFlags;

			/// <summary>Pointer to a structure containing the data format. For video streams, this is a BITMAPINFOHEADER structure.</summary>
			public IntPtr lpFormat;

			/// <summary>Pointer to the data to render.</summary>
			public IntPtr lpData;

			/// <summary>Number of data bytes to render.</summary>
			public uint cbData;

			/// <summary>Time, in samples, when this data should be drawn. For video data this is normally a frame number.</summary>
			public int lTime;
		}

		/// <summary>The <c>ICDRAWBEGIN</c> structure contains decompression parameters used with the ICM_DRAW_BEGIN message.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-icdrawbegin typedef struct { DWORD dwFlags; HPALETTE hpal; HWND
		// hwnd; HDC hdc; int xDst; int yDst; int dxDst; int dyDst; LPBITMAPINFOHEADER lpbi; int xSrc; int ySrc; int dxSrc; int dySrc; DWORD
		// dwRate; DWORD dwScale; } ICDRAWBEGIN;
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_7")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ICDRAWBEGIN
		{
			/// <summary>
			/// <para>Applicable flags. The following values are defined:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ICDRAW_ANIMATE</term>
			/// <term>Application can animate the palette.</term>
			/// </item>
			/// <item>
			/// <term>ICDRAW_BUFFER</term>
			/// <term>Buffers this data off-screen; it will need to be updated.</term>
			/// </item>
			/// <item>
			/// <term>ICDRAW_CONTINUE</term>
			/// <term>Drawing is a continuation of the previous frame.</term>
			/// </item>
			/// <item>
			/// <term>ICDRAW_FULLSCREEN</term>
			/// <term>Draws the decompressed data on the full screen.</term>
			/// </item>
			/// <item>
			/// <term>ICDRAW_HDC</term>
			/// <term>Draws the decompressed data to a window or a DC.</term>
			/// </item>
			/// <item>
			/// <term>ICDRAW_MEMORYDC</term>
			/// <term>DC is off-screen.</term>
			/// </item>
			/// <item>
			/// <term>ICDRAW_QUERY</term>
			/// <term>Determines if the decompressor can handle the decompression. The driver does not actually decompress the data.</term>
			/// </item>
			/// <item>
			/// <term>ICDRAW_RENDER</term>
			/// <term>Renders but does not draw the data.</term>
			/// </item>
			/// <item>
			/// <term>ICDRAW_UPDATING</term>
			/// <term>Current frame is being updated rather than played.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ICDRAWF dwFlags;

			/// <summary>Handle to the palette used for drawing.</summary>
			public HPALETTE hpal;

			/// <summary>Handle to the window used for drawing.</summary>
			public HWND hwnd;

			/// <summary>Handle to the DC used for drawing. Specify <c>NULL</c> to use a DC associated with the specified window.</summary>
			public HDC hdc;

			/// <summary>The x-coordinate of the destination rectangle.</summary>
			public int xDst;

			/// <summary>The y-coordinate of the destination rectangle.</summary>
			public int yDst;

			/// <summary>Width of the destination rectangle.</summary>
			public int dxDst;

			/// <summary>Height of the destination rectangle.</summary>
			public int dyDst;

			/// <summary>Pointer to a BITMAPINFOHEADER structure containing the input format.</summary>
			public IntPtr lpbi;

			/// <summary>The x-coordinate of the source rectangle.</summary>
			public int xSrc;

			/// <summary>The y-coordinate of the source rectangle.</summary>
			public int ySrc;

			/// <summary>Width of the source rectangle.</summary>
			public int dxSrc;

			/// <summary>Height of the source rectangle.</summary>
			public int dySrc;

			/// <summary>
			/// Decompression rate in an integer format. To obtain the rate in frames per second, divide this value by the value in <c>dwScale</c>.
			/// </summary>
			public uint dwRate;

			/// <summary>Value used to scale <c>dwRate</c> to frames per second.</summary>
			public uint dwScale;
		}

		/// <summary>
		/// The <c>ICDRAWSUGGEST</c> structure contains compression parameters used with the ICM_DRAW_SUGGESTFORMAT message to suggest an
		/// appropriate input format.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-icdrawsuggest typedef struct { LPBITMAPINFOHEADER lpbiIn;
		// LPBITMAPINFOHEADER lpbiSuggest; int dxSrc; int dySrc; int dxDst; int dyDst; HIC hicDecompressor; } ICDRAWSUGGEST;
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_9")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ICDRAWSUGGEST
		{
			/// <summary>Pointer to the structure containing the compressed input format.</summary>
			public IntPtr lpbiIn;

			/// <summary>Pointer to a buffer to return a compatible input format for the renderer.</summary>
			public IntPtr lpbiSuggest;

			/// <summary>Width of the source rectangle.</summary>
			public int dxSrc;

			/// <summary>Height of the source rectangle.</summary>
			public int dySrc;

			/// <summary>Width of the destination rectangle.</summary>
			public int dxDst;

			/// <summary>Height of the destination rectangle.</summary>
			public int dyDst;

			/// <summary>Handle to a decompressor that supports the format of data described in <c>lpbiIn</c>.</summary>
			public HIC hicDecompressor;
		}

		/// <summary>
		/// The <c>ICINFO</c> structure contains compression parameters supplied by a video compression driver. The driver fills or updates
		/// the structure when it receives the ICM_GETINFO message.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-icinfo typedef struct { DWORD dwSize; DWORD fccType; DWORD
		// fccHandler; DWORD dwFlags; DWORD dwVersion; DWORD dwVersionICM; WCHAR szName[16]; WCHAR szDescription[128]; WCHAR szDriver[128];
		// } ICINFO;
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_1")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct ICINFO
		{
			/// <summary>Size, in bytes, of the <c>ICINFO</c> structure.</summary>
			public uint dwSize;

			/// <summary>
			/// Four-character code indicating the type of stream being compressed or decompressed. Specify "VIDC" for video streams.
			/// </summary>
			public uint fccType;

			/// <summary>A four-character code identifying a specific compressor.</summary>
			public uint fccHandler;

			/// <summary>
			/// <para>Applicable flags. Zero or more of the following flags can be set:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>VIDCF_COMPRESSFRAMES</term>
			/// <term>
			/// Driver is requesting to compress all frames. For information about compressing all frames, see the ICM_COMPRESS_FRAMES_INFO message.
			/// </term>
			/// </item>
			/// <item>
			/// <term>VIDCF_CRUNCH</term>
			/// <term>Driver supports compressing to a frame size.</term>
			/// </item>
			/// <item>
			/// <term>VIDCF_DRAW</term>
			/// <term>Driver supports drawing.</term>
			/// </item>
			/// <item>
			/// <term>VIDCF_FASTTEMPORALC</term>
			/// <term>
			/// Driver can perform temporal compression and maintains its own copy of the current frame. When compressing a stream of frame
			/// data, the driver doesn't need image data from the previous frame.
			/// </term>
			/// </item>
			/// <item>
			/// <term>VIDCF_FASTTEMPORALD</term>
			/// <term>
			/// Driver can perform temporal decompression and maintains its own copy of the current frame. When decompressing a stream of
			/// frame data, the driver doesn't need image data from the previous frame.
			/// </term>
			/// </item>
			/// <item>
			/// <term>VIDCF_QUALITY</term>
			/// <term>Driver supports quality values.</term>
			/// </item>
			/// <item>
			/// <term>VIDCF_TEMPORAL</term>
			/// <term>Driver supports inter-frame compression.</term>
			/// </item>
			/// </list>
			/// </summary>
			public VIDCF dwFlags;

			/// <summary>Version number of the driver.</summary>
			public uint dwVersion;

			/// <summary>Version of VCM supported by the driver. This member should be set to ICVERSION.</summary>
			public uint dwVersionICM;

			/// <summary>
			/// Short version of the compressor name. The name in the null-terminated string should be suitable for use in list boxes.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
			public string szName;

			/// <summary>Long version of the compressor name.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string szDescription;

			/// <summary>Name of the module containing VCM compression driver. Normally, a driver does not need to fill this out.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string szDriver;
		}

		/// <summary>
		/// The <c>ICOPEN</c> structure contains information about the data stream being compressed or decompressed, the version number of
		/// the driver, and how the driver is used.
		/// </summary>
		/// <remarks>
		/// This structure is passed to video capture drivers when they are opened. This allows a single installable driver to function as
		/// either an installable compressor or a video capture device. By examining the <c>fccType</c> member of the <c>ICOPEN</c>
		/// structure, the driver can determine its function. For example, a <c>fccType</c> value of "VIDC" indicates that it is opened as
		/// an installable video compressor.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-icopen typedef struct { DWORD dwSize; DWORD fccType; DWORD
		// fccHandler; DWORD dwVersion; DWORD dwFlags; LRESULT dwError; LPVOID pV1Reserved; LPVOID pV2Reserved; DWORD dnDevNode; } ICOPEN;
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_0")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ICOPEN
		{
			/// <summary>Size, in bytes, of the structure.</summary>
			public uint dwSize;

			/// <summary>
			/// Four-character code indicating the type of stream being compressed or decompressed. Specify "VIDC" for video streams.
			/// </summary>
			public uint fccType;

			/// <summary>Four-character code identifying a specific compressor.</summary>
			public uint fccHandler;

			/// <summary>Version of the installable driver interface used to open the driver.</summary>
			public uint dwVersion;

			/// <summary>
			/// <para>Applicable flags indicating why the driver is opened. The following values are defined:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Name</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ICMODE_COMPRESS</term>
			/// <term>Driver is opened to compress data.</term>
			/// </item>
			/// <item>
			/// <term>ICMODE_DECOMPRESS</term>
			/// <term>Driver is opened to decompress data.</term>
			/// </item>
			/// <item>
			/// <term>ICMODE_DRAW</term>
			/// <term>Device driver is opened to decompress data directly to hardware.</term>
			/// </item>
			/// <item>
			/// <term>ICMODE_QUERY</term>
			/// <term>Driver is opened for informational purposes, rather than for compression.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ICMODE dwFlags;

			/// <summary/>
			public IntPtr dwError;

			/// <summary>Reserved; do not use.</summary>
			public IntPtr pV1Reserved;

			/// <summary>Reserved; do not use.</summary>
			public IntPtr pV2Reserved;

			/// <summary>Device node for plug and play devices.</summary>
			public uint dnDevNode;
		}

		/// <summary>The <c>ICSETSTATUSPROC</c> structure contains status information used with the ICM_SET_STATUS_PROC message.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vfw/ns-vfw-icsetstatusproc typedef struct { DWORD dwFlags; LPARAM lParam;
		// LONG( )(LPARAM lParam,UINT message,LONG l) *Status; } ICSETSTATUSPROC;
		[PInvokeData("vfw.h", MSDNShortId = "NS:vfw.__unnamed_struct_4")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ICSETSTATUSPROC
		{
			/// <summary>Reserved; set to zero.</summary>
			public uint dwFlags;

			/// <summary>Parameter that contains a constant to pass to the status procedure.</summary>
			public IntPtr lParam;
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

		/*
		CAPCONTROLCALLBACK
		CAPERRORCALLBACKA
		CAPERRORCALLBACKW
		CAPSTATUSCALLBACKA
		CAPSTATUSCALLBACKW
		CAPVIDEOCALLBACK
		CAPWAVECALLBACK
		CAPYIELDCALLBACK

		capCaptureAbort
		capCaptureGetSetup
		capCaptureSequence
		capCaptureSequenceNoFile
		capCaptureSetSetup
		capCaptureSingleFrame
		capCaptureSingleFrameClose
		capCaptureSingleFrameOpen
		capCaptureStop
		capCreateCaptureWindowA
		capCreateCaptureWindowW
		capDlgVideoCompression
		capDlgVideoDisplay
		capDlgVideoFormat
		capDlgVideoSource
		capDriverConnect
		capDriverDisconnect
		capDriverGetCaps
		capDriverGetName
		capDriverGetVersion
		capEditCopy
		capFileAlloc
		capFileGetCaptureFile
		capFileSaveAs
		capFileSaveDIB
		capFileSetCaptureFile
		capFileSetInfoChunk
		capGetAudioFormat
		capGetAudioFormatSize
		capGetDriverDescriptionA
		capGetDriverDescriptionW
		capGetMCIDeviceName
		capGetStatus
		capGetUserData
		capGetVideoFormat
		capGetVideoFormatSize
		capGrabFrame
		capGrabFrameNoStop
		capOverlay
		capPaletteAuto
		capPaletteManual
		capPaletteOpen
		capPalettePaste
		capPaletteSave
		capPreview
		capPreviewRate
		capPreviewScale
		capSetAudioFormat
		capSetCallbackOnCapControl
		capSetCallbackOnError
		capSetCallbackOnFrame
		capSetCallbackOnStatus
		capSetCallbackOnVideoStream
		capSetCallbackOnWaveStream
		capSetCallbackOnYield
		capSetMCIDeviceName
		capSetScrollPos
		capSetUserData
		capSetVideoFormat
		MCIWndCanConfig
		MCIWndCanEject
		MCIWndCanPlay
		MCIWndCanRecord
		MCIWndCanSave
		MCIWndCanWindow
		MCIWndChangeStyles
		MCIWndClose
		MCIWndCreateA
		MCIWndCreateW
		MCIWndDestroy
		MCIWndEject
		MCIWndEnd
		MCIWndGetActiveTimer
		MCIWndGetAlias
		MCIWndGetDest
		MCIWndGetDevice
		MCIWndGetDeviceID
		MCIWndGetEnd
		MCIWndGetError
		MCIWndGetFileName
		MCIWndGetInactiveTimer
		MCIWndGetLength
		MCIWndGetMode
		MCIWndGetPalette
		MCIWndGetPosition
		MCIWndGetPositionString
		MCIWndGetRepeat
		MCIWndGetSource
		MCIWndGetSpeed
		MCIWndGetStart
		MCIWndGetStyles
		MCIWndGetTimeFormat
		MCIWndGetVolume
		MCIWndGetZoom
		MCIWndHome
		MCIWndNew
		MCIWndOpen
		MCIWndOpenDialog
		MCIWndOpenInterface
		MCIWndPause
		MCIWndPlay
		MCIWndPlayFrom
		MCIWndPlayFromTo
		MCIWndPlayReverse
		MCIWndPlayTo
		MCIWndPutDest
		MCIWndPutSource
		MCIWndRealize
		MCIWndRecord
		MCIWndRegisterClass
		MCIWndResume
		MCIWndReturnString
		MCIWndSave
		MCIWndSaveDialog
		MCIWndSeek
		MCIWndSendString
		MCIWndSetActiveTimer
		MCIWndSetInactiveTimer
		MCIWndSetOwner
		MCIWndSetPalette
		MCIWndSetRepeat
		MCIWndSetSpeed
		MCIWndSetTimeFormat
		MCIWndSetTimers
		MCIWndSetVolume
		MCIWndSetZoom
		MCIWndStep
		MCIWndStop
		MCIWndUseFrames
		MCIWndUseTime
		MCIWndValidateMedia
		*/
	}
}