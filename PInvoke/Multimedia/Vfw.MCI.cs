using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

/// <summary>Items from the Vfw32.dll</summary>
public static partial class Vfw32
{
	/// <summary>Seek from the end.</summary>
	public const int MCIWND_END = -2;

	/// <summary>Seek from the start.</summary>
	public const int MCIWND_START = -1;

	private const string Lib_Msvfw32 = "msvfw32.dll";

	/// <summary>Window messages for MCI functions.</summary>
	[PInvokeData("mciapi.h")]
	public enum MCI : uint
	{
		/// <summary>
		/// <para>The MCI_OPEN command initializes a device or file. All devices recognize this command.</para>
		/// <para>To send this command, call the <c>mciSendCommand</c> function with the following parameters.</para>
		/// <para>
		///   <code lang="CPP">MCIERROR mciSendCommand( MCIDEVICEID wDeviceID, MCI_OPEN, DWORD dwFlags, (DWORD) (LPMCI_OPEN_PARMS) lpOpen );</code>
		/// </para>
		/// <list>
		///   <item>
		///     <term>wDeviceID</term>
		///     <definition>Device identifier of the MCI device that is to receive the command message.</definition>
		///   </item>
		///   <item>
		///     <term>dwFlags</term>
		///     <definition>MCI_NOTIFY or MCI_WAIT. For information about these flags, see The Wait, Notify, and Test Flags.</definition>
		///   </item>
		///   <item>
		///     <term>lpOpen</term>
		///     <definition>Pointer to an <c>MCI_OPEN_PARMS</c> structure. (Devices with extended command sets might replace this structure
		/// with a device-specific structure.)</definition>
		///   </item>
		///   <item>
		///     <term>Return Value</term>
		///     <definition>Returns zero if successful or an error otherwise.</definition>
		///   </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>The following additional flags apply to all devices supporting MCI_OPEN:</para>
		/// <para>MCI_OPEN_ALIAS</para>
		/// <para>An alias is included in the lpstrAlias member of the structure identified by lpOpen.</para>
		/// <para>MCI_OPEN_SHAREABLE</para>
		/// <para>The device or file should be opened as sharable.</para>
		/// <para>MCI_OPEN_TYPE</para>
		/// <para>A device type name or constant is included in the lpstrDeviceType member of the structure identified by lpOpen.</para>
		/// <para>MCI_OPEN_TYPE_ID</para>
		/// <para>
		/// The low-order word of the lpstrDeviceType member of the structure identified by lpOpen contains a standard MCI device type
		/// identifier and the high-order word optionally contains the ordinal index for the device. Use this flag with the
		/// MCI_OPEN_TYPE flag.
		/// </para>
		/// <para>The following additional flags apply to compound devices:</para>
		/// <para>MCI_OPEN_ELEMENT</para>
		/// <para>A filename is included in the lpstrElementName member of the structure identified by lpOpen.</para>
		/// <para>MCI_OPEN_ELEMENT_ID</para>
		/// <para>
		/// The lpstrElementName member of the structure identified by lpOpen is interpreted as a DWORD value and has meaning internal
		/// to the device. Use this flag with the MCI_OPEN_ELEMENT flag.
		/// </para>
		/// <para>The following additional flags are used with the digitalvideo device type:</para>
		/// <para>MCI_DGV_OPEN_NOSTATIC</para>
		/// <para>
		/// The device should reduce the number of static (system) colors in the palette. This increases the number of colors available
		/// for rendering the video stream. This flag applies only to devices that share a palette with Windows.
		/// </para>
		/// <para>MCI_DGV_OPEN_PARENT</para>
		/// <para>The parent window handle is specified in the hWndParent member of the structure identified by lpOpen.</para>
		/// <para>MCI_DGV_OPEN_WS</para>
		/// <para>A window style is specified in the dwStyle member of the structure identified by lpOpen.</para>
		/// <para>MCI_DGV_OPEN_16BIT</para>
		/// <para>Indicates a preference for 16-bit MCI device support.</para>
		/// <para>MCI_DGV_OPEN_32BIT</para>
		/// <para>Indicates a preference for 32-bit MCI device support.</para>
		/// <para>For digital-video devices, the lpOpen parameter points to an MCI_DGV_OPEN_PARMS structure.</para>
		/// <para>The following additional flags are used with the overlay device type:</para>
		/// <para>MCI_OVLY_OPEN_PARENT</para>
		/// <para>The parent window handle is specified in the hWndParent member of the structure identified by lpOpen.</para>
		/// <para>MCI_OVLY_OPEN_WS</para>
		/// <para>
		/// A window style is specified in the dwStyle member of the structure identified by lpOpen. The dwStyle value specifies the
		/// style of the window that the driver will create and display if the application does not provide one. The style parameter
		/// takes an integer that defines the window style. These constants are the same as the standard window styles (such as
		/// WS_CHILD, WS_OVERLAPPEDWINDOW, or WS_POPUP).
		/// </para>
		/// <para>For video-overlay devices, the lpOpen parameter points to an MCI_OVLY_OPEN_PARMS structure.</para>
		/// <para>The following additional flag is used with the waveaudio device type:</para>
		/// <para>MCI_WAVE_OPEN_BUFFER</para>
		/// <para>A buffer length is specified in the dwBufferSeconds member of the structure identified by lpOpen.</para>
		/// <para>
		/// For waveform-audio devices, the lpOpen parameter points to an MCI_WAVE_OPEN_PARMS structure. The MCIWAVE driver requires an
		/// asynchronous waveform-audio device.
		/// </para>
		/// </remarks>
		MCI_OPEN = 0x0803,

		/// <summary></summary>
		MCI_CLOSE = 0x0804,

		/// <summary></summary>
		MCI_PLAY = 0x0806,

		/// <summary></summary>
		MCI_SEEK = 0x0807,

		/// <summary></summary>
		MCI_STOP = 0x0808,

		/// <summary></summary>
		MCI_PAUSE = 0x0809,

		/// <summary></summary>
		MCI_STEP = 0x080E,

		/// <summary></summary>
		MCI_RECORD = 0x080F,

		/// <summary></summary>
		MCI_SAVE = 0x0813,

		/// <summary></summary>
		MCI_CUT = 0x0851,

		/// <summary></summary>
		MCI_COPY = 0x0852,

		/// <summary></summary>
		MCI_PASTE = 0x0853,

		/// <summary></summary>
		MCI_RESUME = 0x0855,

		/// <summary></summary>
		MCI_DELETE = 0x0856,
	}

	/// <summary>The MCI constant defining the time format.</summary>
	[PInvokeData("mciapi.h")]
	public enum MCI_FORMAT
	{
		/// <summary>Milliseconds</summary>
		MCI_FORMAT_MILLISECONDS = 0,

		/// <summary>Hours, minutes, seconds</summary>
		MCI_FORMAT_HMS = 1,

		/// <summary>Minutes, seconds, frames</summary>
		MCI_FORMAT_MSF = 2,

		/// <summary>Frames</summary>
		MCI_FORMAT_FRAMES = 3,

		/// <summary>SMPTE 24</summary>
		MCI_FORMAT_SMPTE_24 = 4,

		/// <summary>SMPTE 25</summary>
		MCI_FORMAT_SMPTE_25 = 5,

		/// <summary>SMPTE 30 drop</summary>
		MCI_FORMAT_SMPTE_30 = 6,

		/// <summary>SMPTE 30 non-drop</summary>
		MCI_FORMAT_SMPTE_30DROP = 7,

		/// <summary>Bytes</summary>
		MCI_FORMAT_BYTES = 8,

		/// <summary>Samples</summary>
		MCI_FORMAT_SAMPLES = 9,

		/// <summary>Tracks, minutes, seconds, frames</summary>
		MCI_FORMAT_TMSF = 10,
	}

	/// <summary>An integer corresponding to the MCI constant defining the mode.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetMode")]
	public enum MCI_MODE
	{
		/// <summary>Not ready</summary>
		MCI_MODE_NOT_READY = 524,

		/// <summary>Stopped</summary>
		MCI_MODE_STOP = 525,

		/// <summary>Playing</summary>
		MCI_MODE_PLAY = 526,

		/// <summary>Recording</summary>
		MCI_MODE_RECORD = 527,

		/// <summary>Seeking</summary>
		MCI_MODE_SEEK = 528,

		/// <summary>Paused</summary>
		MCI_MODE_PAUSE = 529,

		/// <summary>Open</summary>
		MCI_MODE_OPEN = 530,
	}

	/// <summary>Window messages for MCI functions.</summary>
	[PInvokeData("vfw.h")]
	public enum MCIMessage : uint
	{
		/// <summary></summary>
		MCIWNDM_GETDEVICEID = WM_USER + 100,

		/// <summary></summary>
		MCIWNDM_GETSTART = WM_USER + 103,

		/// <summary></summary>
		MCIWNDM_GETLENGTH = WM_USER + 104,

		/// <summary></summary>
		MCIWNDM_GETEND = WM_USER + 105,

		/// <summary></summary>
		MCIWNDM_EJECT = WM_USER + 107,

		/// <summary></summary>
		MCIWNDM_SETZOOM = WM_USER + 108,

		/// <summary></summary>
		MCIWNDM_GETZOOM = WM_USER + 109,

		/// <summary></summary>
		MCIWNDM_SETVOLUME = WM_USER + 110,

		/// <summary></summary>
		MCIWNDM_GETVOLUME = WM_USER + 111,

		/// <summary></summary>
		MCIWNDM_SETSPEED = WM_USER + 112,

		/// <summary></summary>
		MCIWNDM_GETSPEED = WM_USER + 113,

		/// <summary></summary>
		MCIWNDM_SETREPEAT = WM_USER + 114,

		/// <summary></summary>
		MCIWNDM_GETREPEAT = WM_USER + 115,

		/// <summary></summary>
		MCIWNDM_REALIZE = WM_USER + 118,

		/// <summary></summary>
		MCIWNDM_VALIDATEMEDIA = WM_USER + 121,

		/// <summary></summary>
		MCIWNDM_PLAYFROM = WM_USER + 122,

		/// <summary></summary>
		MCIWNDM_PLAYTO = WM_USER + 123,

		/// <summary></summary>
		MCIWNDM_GETPALETTE = WM_USER + 126,

		/// <summary></summary>
		MCIWNDM_SETPALETTE = WM_USER + 127,

		/// <summary></summary>
		MCIWNDM_SETTIMERS = WM_USER + 129,

		/// <summary></summary>
		MCIWNDM_SETACTIVETIMER = WM_USER + 130,

		/// <summary></summary>
		MCIWNDM_SETINACTIVETIMER = WM_USER + 131,

		/// <summary></summary>
		MCIWNDM_GETACTIVETIMER = WM_USER + 132,

		/// <summary></summary>
		MCIWNDM_GETINACTIVETIMER = WM_USER + 133,

		/// <summary></summary>
		MCIWNDM_CHANGESTYLES = WM_USER + 135,

		/// <summary></summary>
		MCIWNDM_GETSTYLES = WM_USER + 136,

		/// <summary></summary>
		MCIWNDM_GETALIAS = WM_USER + 137,

		/// <summary></summary>
		MCIWNDM_PLAYREVERSE = WM_USER + 139,

		/// <summary></summary>
		MCIWNDM_GET_SOURCE = WM_USER + 140,

		/// <summary></summary>
		MCIWNDM_PUT_SOURCE = WM_USER + 141,

		/// <summary></summary>
		MCIWNDM_GET_DEST = WM_USER + 142,

		/// <summary></summary>
		MCIWNDM_PUT_DEST = WM_USER + 143,

		/// <summary></summary>
		MCIWNDM_CAN_PLAY = WM_USER + 144,

		/// <summary></summary>
		MCIWNDM_CAN_WINDOW = WM_USER + 145,

		/// <summary></summary>
		MCIWNDM_CAN_RECORD = WM_USER + 146,

		/// <summary></summary>
		MCIWNDM_CAN_SAVE = WM_USER + 147,

		/// <summary></summary>
		MCIWNDM_CAN_EJECT = WM_USER + 148,

		/// <summary></summary>
		MCIWNDM_CAN_CONFIG = WM_USER + 149,

		/// <summary></summary>
		MCIWNDM_PALETTEKICK = WM_USER + 150,

		/// <summary></summary>
		MCIWNDM_OPENINTERFACE = WM_USER + 151,

		/// <summary></summary>
		MCIWNDM_SETOWNER = WM_USER + 152,

		//define both A and W messages
		/// <summary></summary>
		MCIWNDM_SENDSTRINGA = WM_USER + 101,

		/// <summary></summary>
		MCIWNDM_GETPOSITIONA = WM_USER + 102,

		/// <summary></summary>
		MCIWNDM_GETMODEA = WM_USER + 106,

		/// <summary></summary>
		MCIWNDM_SETTIMEFORMATA = WM_USER + 119,

		/// <summary></summary>
		MCIWNDM_GETTIMEFORMATA = WM_USER + 120,

		/// <summary></summary>
		MCIWNDM_GETFILENAMEA = WM_USER + 124,

		/// <summary></summary>
		MCIWNDM_GETDEVICEA = WM_USER + 125,

		/// <summary></summary>
		MCIWNDM_GETERRORA = WM_USER + 128,

		/// <summary></summary>
		MCIWNDM_NEWA = WM_USER + 134,

		/// <summary></summary>
		MCIWNDM_RETURNSTRINGA = WM_USER + 138,

		/// <summary></summary>
		MCIWNDM_OPENA = WM_USER + 153,

		/// <summary></summary>
		MCIWNDM_SENDSTRINGW = WM_USER + 201,

		/// <summary></summary>
		MCIWNDM_GETPOSITIONW = WM_USER + 202,

		/// <summary></summary>
		MCIWNDM_GETMODEW = WM_USER + 206,

		/// <summary></summary>
		MCIWNDM_SETTIMEFORMATW = WM_USER + 219,

		/// <summary></summary>
		MCIWNDM_GETTIMEFORMATW = WM_USER + 220,

		/// <summary></summary>
		MCIWNDM_GETFILENAMEW = WM_USER + 224,

		/// <summary></summary>
		MCIWNDM_GETDEVICEW = WM_USER + 225,

		/// <summary></summary>
		MCIWNDM_GETERRORW = WM_USER + 228,

		/// <summary></summary>
		MCIWNDM_NEWW = WM_USER + 234,

		/// <summary></summary>
		MCIWNDM_RETURNSTRINGW = WM_USER + 238,

		/// <summary>map defaults to A or W depending on app's UNICODE setting</summary>
		MCIWNDM_OPENW = WM_USER + 252,

		/// <summary></summary>
		MCIWNDM_SENDSTRING = MCIWNDM_SENDSTRINGW,

		/// <summary></summary>
		MCIWNDM_GETPOSITION = MCIWNDM_GETPOSITIONW,

		/// <summary></summary>
		MCIWNDM_GETMODE = MCIWNDM_GETMODEW,

		/// <summary></summary>
		MCIWNDM_SETTIMEFORMAT = MCIWNDM_SETTIMEFORMATW,

		/// <summary></summary>
		MCIWNDM_GETTIMEFORMAT = MCIWNDM_GETTIMEFORMATW,

		/// <summary></summary>
		MCIWNDM_GETFILENAME = MCIWNDM_GETFILENAMEW,

		/// <summary></summary>
		MCIWNDM_GETDEVICE = MCIWNDM_GETDEVICEW,

		/// <summary></summary>
		MCIWNDM_GETERROR = MCIWNDM_GETERRORW,

		/// <summary></summary>
		MCIWNDM_NEW = MCIWNDM_NEWW,

		/// <summary></summary>
		MCIWNDM_RETURNSTRING = MCIWNDM_RETURNSTRINGW,

		/// <summary></summary>
		MCIWNDM_OPEN = MCIWNDM_OPENW,
	}

	/// <summary>
	/// Flags defining the window style. In addition to specifying the window styles used with the function,
	/// <c>CreateWindowEx</c> you can specify the following styles to use with MCIWnd windows.
	/// </summary>
	[Flags]
	public enum MCIWNDF : uint
	{
		/// <summary>Will not change the dimensions of an MCIWnd window when the image size changes.</summary>
		MCIWNDF_NOAUTOSIZEWINDOW = 0x0001,

		/// <summary>Hides the toolbar from view and prohibits users from accessing it.</summary>
		MCIWNDF_NOPLAYBAR = 0x0002,

		/// <summary>Will not change the dimensions of the destination rectangle when an MCIWnd window size changes.</summary>
		MCIWNDF_NOAUTOSIZEMOVIE = 0x0004,

		/// <summary>Hides the Menu button from view on the toolbar and prohibits users from accessing its pop-up menu.</summary>
		MCIWNDF_NOMENU = 0x0008,

		/// <summary>Displays the name of the open MCI device or data file in the MCIWnd window title bar.</summary>
		MCIWNDF_SHOWNAME = 0x0010,

		/// <summary>Displays the current position within the content of the MCI device in the window title bar.</summary>
		MCIWNDF_SHOWPOS = 0x0020,

		/// <summary>
		/// Displays the current mode of the MCI device in the window title bar. For a list of device modes, see the MCIWndGetMode macro.
		/// </summary>
		MCIWNDF_SHOWMODE = 0x0040,

		/// <summary>Causes all MCIWNDF_SHOW styles to be used.</summary>
		MCIWNDF_SHOWALL = 0x0070,

		/// <summary>
		/// Causes MCIWnd to notify the parent window with an MCIMessage.MCIWNDM_NOTIFYMODE message whenever the device changes
		/// operating modes. The lParam parameter of this message identifies the new mode, such as MCI_MODE_STOP.
		/// </summary>
		MCIWNDF_NOTIFYMODE = 0x0100,

		/// <summary>
		/// Causes MCIWnd to notify the parent window with an MCIMessage.MCIWNDM_NOTIFYPOS message whenever a change in the playback or
		/// record position within the content occurs. The lParam parameter of this message contains the new position in the content.
		/// </summary>
		MCIWNDF_NOTIFYPOS = 0x0200,

		/// <summary>Causes MCIWnd to notify the parent window when the MCIWnd window size changes.</summary>
		MCIWNDF_NOTIFYSIZE = 0x0400,

		/// <summary>Causes MCIWnd to notify the parent window when an MCI error occurs.</summary>
		MCIWNDF_NOTIFYERROR = 0x1000,

		/// <summary>Causes all MCIWNDF window notification styles to be used.</summary>
		MCIWNDF_NOTIFYALL = 0x1F00,

		/// <summary>
		/// Causes MCIWnd to use an ANSI string instead of a Unicode string when notifying the parent window of device mode changes.
		/// This flag is used in combination with MCIWNDF_NOTIFYMODE.
		/// </summary>
		MCIWNDF_NOTIFYANSI = 0x0080,

		/// <summary>
		/// Causes MCIWnd to notify the parent window with an MCIMessage.MCIWNDM_NOTIFYMEDIA message whenever a new device is used or a
		/// data file is opened or closed. The lParam parameter of this message contains a pointer to the new file name.
		/// </summary>
		MCIWNDF_NOTIFYMEDIAA = 0x0880,

		/// <summary>
		/// Causes MCIWnd to notify the parent window with an MCIMessage.MCIWNDM_NOTIFYMEDIA message whenever a new device is used or a
		/// data file is opened or closed. The lParam parameter of this message contains a pointer to the new file name.
		/// </summary>
		MCIWNDF_NOTIFYMEDIAW = 0x0800,

		/// <summary>
		/// Causes MCIWnd to notify the parent window with an MCIMessage.MCIWNDM_NOTIFYMEDIA message whenever a new device is used or a
		/// data file is opened or closed. The lParam parameter of this message contains a pointer to the new file name.
		/// </summary>
		MCIWNDF_NOTIFYMEDIA = MCIWNDF_NOTIFYMEDIAW,

		/// <summary>
		/// Adds a Record button to the toolbar and adds a new file command to the menu if the MCI device has recording capability.
		/// </summary>
		MCIWNDF_RECORD = 0x2000,

		/// <summary>Inhibits display of MCI errors to users.</summary>
		MCIWNDF_NOERRORDLG = 0x4000,

		/// <summary>
		/// Hides the open and close commands from the MCIWnd menu and prohibits users from accessing these choices in the pop-up menu.
		/// </summary>
		MCIWNDF_NOOPEN = 0x8000,
	}

	/// <summary>Flags associated with the device or file to open.</summary>
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndOpen")]
	[Flags]
	public enum MCIWNDOPENF
	{
		/// <summary>Specifies a new file is to be created with the name specified in szFile.</summary>
		MCIWNDOPENF_NEW = 0x0001
	}

	/// <summary>
	/// The <c>MCIWndCanConfig</c> macro determines if an MCI device can display a configuration dialog box. You can use this macro or
	/// explicitly send the MCIWNDM_CAN_CONFIG message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndcanconfig void MCIWndCanConfig( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndCanConfig")]
	public static bool MCIWndCanConfig(HWND hwnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_CAN_CONFIG) != 0;

	/// <summary>
	/// The <c>MCIWndCanEject</c> macro determines if an MCI device can eject its media. You can use this macro or explicitly send the
	/// MCIWNDM_CAN_EJECT message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndcaneject void MCIWndCanEject( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndCanEject")]
	public static bool MCIWndCanEject(HWND hwnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_CAN_EJECT) != 0;

	/// <summary>
	/// The <c>MCIWndCanPlay</c> macro determines if an MCI device can play a data file or content of some other kind. You can use this
	/// macro or explicitly send the MCIWNDM_CAN_PLAY message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndcanplay void MCIWndCanPlay( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndCanPlay")]
	public static bool MCIWndCanPlay(HWND hwnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_CAN_PLAY) != 0;

	/// <summary>
	/// The <c>MCIWndCanRecord</c> macro determines if an MCI device supports recording. You can use this macro or explicitly send the
	/// MCIWNDM_CAN_RECORD message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndcanrecord void MCIWndCanRecord( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndCanRecord")]
	public static bool MCIWndCanRecord(HWND hwnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_CAN_RECORD) != 0;

	/// <summary>
	/// The <c>MCIWndCanSave</c> macro determines if an MCI device can save data. You can use this macro or explicitly send the
	/// MCIWNDM_CAN_SAVE message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndcansave void MCIWndCanSave( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndCanSave")]
	public static bool MCIWndCanSave(HWND hwnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_CAN_SAVE) != 0;

	/// <summary>
	/// The <c>MCIWndCanWindow</c> macro determines if an MCI device supports window-oriented MCI commands. You can use this macro or
	/// explicitly send the MCIWNDM_CAN_WINDOW message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndcanwindow void MCIWndCanWindow( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndCanWindow")]
	public static bool MCIWndCanWindow(HWND hwnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_CAN_WINDOW) != 0;

	/// <summary>
	/// The <c>MCIWndChangeStyles</c> macro changes the styles used by the MCIWnd window. You can use this macro or explicitly send the
	/// MCIWNDM_CHANGESTYLES message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="mask">
	/// Mask that identifies the styles that can change. This mask is the bitwise OR operator of all styles that will be permitted to change.
	/// </param>
	/// <param name="value">
	/// New style settings for the window. Specify zero for this parameter to turn off all styles identified in the mask. For a list of
	/// the available styles, see the MCIWndCreate function.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>For an example of using <c>MCIWndChangeStyles</c>, see Pausing and Resuming Playback.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndchangestyles void MCIWndChangeStyles( hwnd, mask, value );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndChangeStyles")]
	public static int MCIWndChangeStyles(HWND hwnd, MCIWNDF mask, [Optional] int value) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_CHANGESTYLES, unchecked((int)mask), value);

	/// <summary>
	/// The <c>MCIWndClose</c> macro closes an MCI device or file associated with an MCIWnd window. Although the MCI device closes, the
	/// MCIWnd window is still open and can be associated with another MCI device. You can use this macro or explicitly send the
	/// MCI_CLOSE command.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndclose void MCIWndClose( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndClose")]
	public static int MCIWndClose(HWND hwnd) => MCIWndSM(hwnd, MCI.MCI_CLOSE);

	/// <summary>
	/// The <c>MCIWndCreate</c> function registers the MCIWnd window class and creates an MCIWnd window for using MCI services.
	/// <c>MCIWndCreate</c> can also open an MCI device or file (such as an AVI file) and associate it with the MCIWnd window.
	/// </summary>
	/// <param name="hwndParent">Handle to the parent window.</param>
	/// <param name="hInstance">Handle to the module instance to associate with the MCIWnd window.</param>
	/// <param name="dwStyle">
	/// <para>
	/// Flags defining the window style. In addition to specifying the window styles used with the CreateWindowEx function, you can
	/// specify the following styles to use with MCIWnd windows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MCIWNDF_NOAUTOSIZEWINDOW</term>
	/// <term>Will not change the dimensions of an MCIWnd window when the image size changes.</term>
	/// </item>
	/// <item>
	/// <term>MCIWNDF_NOAUTOSIZEMOVIE</term>
	/// <term>Will not change the dimensions of the destination rectangle when an MCIWnd window size changes.</term>
	/// </item>
	/// <item>
	/// <term>MCIWNDF_NOERRORDLG</term>
	/// <term>Inhibits display of MCI errors to users.</term>
	/// </item>
	/// <item>
	/// <term>MCIWNDF_NOMENU</term>
	/// <term>Hides the Menu button from view on the toolbar and prohibits users from accessing its pop-up menu.</term>
	/// </item>
	/// <item>
	/// <term>MCIWNDF_NOOPEN</term>
	/// <term>
	/// Hides the open and close commands from the MCIWnd menu and prohibits users from accessing these choices in the pop-up menu.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MCIWNDF_NOPLAYBAR</term>
	/// <term>Hides the toolbar from view and prohibits users from accessing it.</term>
	/// </item>
	/// <item>
	/// <term>MCIWNDF_NOTIFYANSI</term>
	/// <term>
	/// Causes MCIWnd to use an ANSI string instead of a Unicode string when notifying the parent window of device mode changes. This
	/// flag is used in combination with MCIWNDF_NOTIFYMODE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MCIWNDF_NOTIFYMODE</term>
	/// <term>
	/// Causes MCIWnd to notify the parent window with an MCIMessage.MCIWNDM_NOTIFYMODE message whenever the device changes operating
	/// modes. The lParam parameter of this message identifies the new mode, such as MCI_MODE_STOP.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MCIWNDF_NOTIFYPOS</term>
	/// <term>
	/// Causes MCIWnd to notify the parent window with an MCIMessage.MCIWNDM_NOTIFYPOS message whenever a change in the playback or
	/// record position within the content occurs. The lParam parameter of this message contains the new position in the content.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MCIWNDF_NOTIFYMEDIA</term>
	/// <term>
	/// Causes MCIWnd to notify the parent window with an MCIMessage.MCIWNDM_NOTIFYMEDIA message whenever a new device is used or a data
	/// file is opened or closed. The lParam parameter of this message contains a pointer to the new file name.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MCIWNDF_NOTIFYSIZE</term>
	/// <term>Causes MCIWnd to notify the parent window when the MCIWnd window size changes.</term>
	/// </item>
	/// <item>
	/// <term>MCIWNDF_NOTIFYERROR</term>
	/// <term>Causes MCIWnd to notify the parent window when an MCI error occurs.</term>
	/// </item>
	/// <item>
	/// <term>MCIWNDF_NOTIFYALL</term>
	/// <term>Causes all MCIWNDF window notification styles to be used.</term>
	/// </item>
	/// <item>
	/// <term>MCIWNDF_RECORD</term>
	/// <term>Adds a Record button to the toolbar and adds a new file command to the menu if the MCI device has recording capability.</term>
	/// </item>
	/// <item>
	/// <term>MCIWNDF_SHOWALL</term>
	/// <term>Causes all MCIWNDF_SHOW styles to be used.</term>
	/// </item>
	/// <item>
	/// <term>MCIWNDF_SHOWMODE</term>
	/// <term>
	/// Displays the current mode of the MCI device in the window title bar. For a list of device modes, see the MCIWndGetMode macro.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MCIWNDF_SHOWNAME</term>
	/// <term>Displays the name of the open MCI device or data file in the MCIWnd window title bar.</term>
	/// </item>
	/// <item>
	/// <term>MCIWNDF_SHOWPOS</term>
	/// <term>Displays the current position within the content of the MCI device in the window title bar.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szFile">Null-terminated string indicating the name of an MCI device or data file to open.</param>
	/// <returns>Returns the handle to an MCI window if successful or zero otherwise.</returns>
	/// <remarks>
	/// <para>
	/// Default window styles for a child window are WS_CHILD, WS_BORDER, and WS_VISIBLE. <c>MCIWndCreate</c> assumes a child window
	/// when a non- <c>NULL</c> handle of a parent window is specified.
	/// </para>
	/// <para>
	/// Default window styles for a parent window are WS_OVERLAPPEDWINDOW and WS_VISIBLE. <c>MCIWndCreate</c> assumes a parent window
	/// when a <c>NULL</c> handle of a parent window is specified.
	/// </para>
	/// <para>
	/// Use the window handle returned by this function for the window handle in the MCIWnd macros. If your application uses this
	/// function, it does not need to use the MCIWndRegisterClass function.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The vfw.h header defines MCIWndCreate as an alias which automatically selects the ANSI or Unicode version of this function based
	/// on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndcreatea HWND VFWAPIV MCIWndCreateA( HWND hwndParent,
	// HINSTANCE hInstance, DWORD dwStyle, LPCSTR szFile );
	[DllImport(Lib_Msvfw32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndCreateA")]
	public static extern HWND MCIWndCreate([In, Optional] HWND hwndParent, [In, Optional] HINSTANCE hInstance, MCIWNDF dwStyle, [In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? szFile);

	/// <summary>
	/// The <c>MCIWndDestroy</c> macro closes an MCI device or file associated with an MCIWnd window and destroys the window. You can
	/// use this macro or explicitly send the WM_CLOSE message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwnddestroy void MCIWndDestroy( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndDestroy")]
	public static void MCIWndDestroy(HWND hwnd) => MCIWndSM(hwnd, WindowMessage.WM_CLOSE);

	/// <summary>
	/// The <c>MCIWndEject</c> macro sends a command to an MCI device to eject its media. You can use this macro or explicitly send the
	/// MCIWNDM_EJECT message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndeject void MCIWndEject( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndEject")]
	public static int MCIWndEject(HWND hwnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_EJECT);

	/// <summary>
	/// The <c>MCIWndEnd</c> macro moves the current position to the end of the content. You can use this macro or explicitly send the
	/// MCI_SEEK message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndend void MCIWndEnd( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndEnd")]
	public static int MCIWndEnd(HWND hwnd) => MCIWndSeek(hwnd, MCIWND_END);

	/// <summary>
	/// The <c>MCIWndGetActiveTimer</c> macro retrieves the update period used when the MCIWnd window is the active window. You can use
	/// this macro or explicitly send the MCIWNDM_GETACTIVETIMER message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetactivetimer void MCIWndGetActiveTimer( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetActiveTimer")]
	public static uint MCIWndGetActiveTimer(HWND hwnd) => unchecked((uint)MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETACTIVETIMER));

	/// <summary>
	/// The <c>MCIWndGetAlias</c> macro retrieves the alias used to open an MCI device or file with the mciSendString function. You can
	/// use this macro or explicitly send the MCIWNDM_GETALIAS message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetalias void MCIWndGetAlias( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetAlias")]
	public static uint MCIWndGetAlias(HWND hwnd) => unchecked((uint)MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETALIAS));

	/// <summary>
	/// The <c>MCIWndGetDest</c> macro retrieves the coordinates of the destination rectangle used for zooming or stretching the images
	/// of an AVI file during playback. You can use this macro or explicitly send the MCIWNDM_GET_DEST message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="prc">Pointer to a RECT structure to return the coordinates of the destination rectangle.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetdest void MCIWndGetDest( hwnd, prc );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetDest")]
	public static bool MCIWndGetDest(HWND hwnd, out RECT prc) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_GET_DEST, out prc, 0) != 0;

	/// <summary>
	/// The <c>MCIWndGetDevice</c> macro retrieves the name of the current MCI device. You can use this macro or explicitly send the
	/// MCIWNDM_GETDEVICE message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="lp">Pointer to an application-defined buffer to return the device name.</param>
	/// <returns>None</returns>
	/// <remarks>If the null-terminated string containing the device name is longer than the buffer, MCIWnd truncates it.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetdevice void MCIWndGetDevice( hwnd, lp, len );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetDevice")]
	public static bool MCIWndGetDevice(HWND hwnd, StringBuilder lp) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETDEVICE, lp) != 0;

	/// <summary>
	/// The <c>MCIWndGetDeviceID</c> macro retrieves the identifier of the current MCI device to use with the mciSendCommand function.
	/// You can use this macro or explicitly send the MCIWNDM_GETDEVICEID message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetdeviceid void MCIWndGetDeviceID( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetDeviceID")]
	public static uint MCIWndGetDeviceID(HWND hwnd) => unchecked((uint)MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETDEVICEID));

	/// <summary>
	/// The <c>MCIWndGetEnd</c> macro retrieves the location of the end of the content of an MCI device or file. You can use this macro
	/// or explicitly send the MCIWNDM_GETEND message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetend void MCIWndGetEnd( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetEnd")]
	public static int MCIWndGetEnd(HWND hwnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETEND);

	/// <summary>
	/// The <c>MCIWndGetError</c> macro retrieves the last MCI error encountered. You can use this macro or explicitly send the
	/// MCIWNDM_GETERROR message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="lp">Pointer to an application-defined buffer used to return the error string.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// If lp is a valid pointer, a null-terminated string corresponding to the error is returned in its buffer. If the error string is
	/// longer than the buffer, MCIWnd truncates it.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgeterror void MCIWndGetError( hwnd, lp, len );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetError")]
	public static int MCIWndGetError(HWND hwnd, StringBuilder lp) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETERROR, lp);

	/// <summary>
	/// The <c>MCIWndGetFileName</c> macro retrieves the filename used by an MCI device. You can use this macro or explicitly send the
	/// MCIWNDM_GETFILENAME message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="lp">Pointer to an application-defined buffer to return the filename.</param>
	/// <returns>None</returns>
	/// <remarks>If the null-terminated string containing the filename is longer than the buffer, MCIWnd truncates the filename.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetfilename void MCIWndGetFileName( hwnd, lp, len );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetFileName")]
	public static int MCIWndGetFileName(HWND hwnd, StringBuilder lp) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETFILENAME, lp);

	/// <summary>
	/// The <c>MCIWndGetInactiveTimer</c> macro retrieves the update period used when the MCIWnd window is the inactive window. You can
	/// use this macro or explicitly send the MCIWNDM_GETINACTIVETIMER message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetinactivetimer void MCIWndGetInactiveTimer( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetInactiveTimer")]
	public static uint MCIWndGetInactiveTimer(HWND hwnd) => unchecked((uint)MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETINACTIVETIMER));

	/// <summary>
	/// The <c>MCIWndGetLength</c> macro retrieves the length of the content or file currently used by an MCI device. You can use this
	/// macro or explicitly send the MCIWNDM_GETLENGTH message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	/// <remarks>This value added to the value returned for the MCIWndGetStart macro equals the end of the content.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetlength void MCIWndGetLength( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetLength")]
	public static int MCIWndGetLength(HWND hwnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETLENGTH);

	/// <summary>
	/// The <c>MCIWndGetMode</c> macro retrieves the current operating mode of an MCI device. MCI devices have several operating modes,
	/// which are designated by constants. You can use this macro or explicitly send the MCIWNDM_GETMODE message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="lp">Pointer to the application-defined buffer used to return the mode.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>If the null-terminated string describing the mode is longer than the buffer, it is truncated.</para>
	/// <para>
	/// Not all devices can operate in every mode. For example, the MCIAVI device is a playback device; it doesn't support the recording
	/// mode. The following modes can be retrieved by using MCIWNDM_GETMODE:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Operating mode</term>
	/// <term>MCI constant</term>
	/// </listheader>
	/// <item>
	/// <term>not ready</term>
	/// <term>MCI_MODE_NOT_READY</term>
	/// </item>
	/// <item>
	/// <term>open</term>
	/// <term>MCI_MODE_OPEN</term>
	/// </item>
	/// <item>
	/// <term>paused</term>
	/// <term>MCI_MODE_PAUSE</term>
	/// </item>
	/// <item>
	/// <term>playing</term>
	/// <term>MCI_MODE_PLAY</term>
	/// </item>
	/// <item>
	/// <term>recording</term>
	/// <term>MCI_MODE_RECORD</term>
	/// </item>
	/// <item>
	/// <term>seeking</term>
	/// <term>MCI_MODE_SEEK</term>
	/// </item>
	/// <item>
	/// <term>stopped</term>
	/// <term>MCI_MODE_STOP</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetmode void MCIWndGetMode( hwnd, lp, len );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetMode")]
	public static MCI_MODE MCIWndGetMode(HWND hwnd, StringBuilder lp) => (MCI_MODE)MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETMODE, lp);

	/// <summary>
	/// The <c>MCIWndGetPalette</c> macro retrieves a handle of the palette used by an MCI device. You can use this macro or explicitly
	/// send the MCIWNDM_GETPALETTE message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetpalette void MCIWndGetPalette( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetPalette")]
	public static HPALETTE MCIWndGetPalette(HWND hwnd) => SendMessage(hwnd, MCIMessage.MCIWNDM_GETPALETTE);

	/// <summary>
	/// The <c>MCIWndGetPosition</c> macro retrieves the numerical value of the current position within the content of the MCI device.
	/// You can use this macro or explicitly send the MCIWNDM_GETPOSITION message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetposition void MCIWndGetPosition( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetPosition")]
	public static int MCIWndGetPosition(HWND hwnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETPOSITION);

	/// <summary>
	/// The <c>MCIWndGetPositionString</c> macro retrieves the numerical value of the current position within the content of the MCI
	/// device. This macro also provides the current position in string form in an application-defined buffer. You can use this macro or
	/// explicitly send the MCIWNDM_GETPOSITION message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="lp">
	/// Pointer to an application-defined buffer used to return the position. Use zero to inhibit retrieval of the position as a string.
	/// If the device supports tracks, the string position information is returned in the form TT:MM:SS:FF where TT corresponds to
	/// tracks, MM and SS correspond to minutes and seconds, and FF corresponds to frames.
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetpositionstring void MCIWndGetPositionString( hwnd, lp, len );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetPositionString")]
	public static int MCIWndGetPositionString(HWND hwnd, StringBuilder lp) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETPOSITION, lp);

	/// <summary>
	/// The <c>MCIWndGetRepeat</c> macro determines if continuous playback has been activated. You can use this macro or explicitly send
	/// the MCIWNDM_GETREPEAT message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetrepeat void MCIWndGetRepeat( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetRepeat")]
	public static bool MCIWndGetRepeat(HWND hwnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETREPEAT) != 0;

	/// <summary>
	/// The <c>MCIWndGetSource</c> macro retrieves the coordinates of the source rectangle used for cropping the images of an AVI file
	/// during playback. You can use this macro or explicitly send the MCIWNDM_GET_SOURCE message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="prc">Pointer to a RECT structure to contain the coordinates of the source rectangle.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetsource void MCIWndGetSource( hwnd, prc );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetSource")]
	public static bool MCIWndGetSource(HWND hwnd, out RECT prc) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_GET_SOURCE, out prc, 0) != 0;

	/// <summary>
	/// The <c>MCIWndGetSpeed</c> macro retrieves the playback speed of an MCI device. You can use this macro or explicitly send the
	/// MCIWNDM_GETSPEED message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetspeed void MCIWndGetSpeed( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetSpeed")]
	public static int MCIWndGetSpeed(HWND hwnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETSPEED);

	/// <summary>
	/// The <c>MCIWndGetStart</c> macro retrieves the location of the beginning of the content of an MCI device or file. You can use
	/// this macro or explicitly send the MCIWNDM_GETSTART message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetstart void MCIWndGetStart( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetStart")]
	public static int MCIWndGetStart(HWND hwnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETSTART);

	/// <summary>
	/// The <c>MCIWndGetStyles</c> macro retrieves the flags specifying the current MCIWnd window styles used by a window. You can use
	/// this macro or explicitly send the MCIWNDM_GETSTYLES message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetstyles void MCIWndGetStyles( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetStyles")]
	public static MCIWNDF MCIWndGetStyles(HWND hwnd) => unchecked((MCIWNDF)MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETSTYLES));

	/// <summary>
	/// The <c>MCIWndGetTimeFormat</c> macro retrieves the current time format of an MCI device in two forms: as a numerical value and
	/// as a string. You can use this macro or explicitly send the MCIWNDM_GETTIMEFORMAT message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="lp">Pointer to a buffer to contain the null-terminated string form of the time format.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>If the time format string is longer than the return buffer, MCIWnd truncates the string.</para>
	/// <para>An MCI device can support one or more of the following time formats:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Time format</term>
	/// <term>MCI constant</term>
	/// </listheader>
	/// <item>
	/// <term>Bytes</term>
	/// <term>MCI_FORMAT_BYTES</term>
	/// </item>
	/// <item>
	/// <term>Frames</term>
	/// <term>MCI_FORMAT_FRAMES</term>
	/// </item>
	/// <item>
	/// <term>Hours, minutes, seconds</term>
	/// <term>MCI_FORMAT_HMS</term>
	/// </item>
	/// <item>
	/// <term>Milliseconds</term>
	/// <term>MCI_FORMAT_MILLISECONDS</term>
	/// </item>
	/// <item>
	/// <term>Minutes, seconds, frames</term>
	/// <term>MCI_FORMAT_MSF</term>
	/// </item>
	/// <item>
	/// <term>Samples</term>
	/// <term>MCI_FORMAT_SAMPLES</term>
	/// </item>
	/// <item>
	/// <term>SMPTE 24</term>
	/// <term>MCI_FORMAT_SMPTE_24</term>
	/// </item>
	/// <item>
	/// <term>SMPTE 25</term>
	/// <term>MCI_FORMAT_SMPTE_25</term>
	/// </item>
	/// <item>
	/// <term>SMPTE 30 drop</term>
	/// <term>MCI_FORMAT_SMPTE_30DROP</term>
	/// </item>
	/// <item>
	/// <term>SMPTE 30 (non-drop)</term>
	/// <term>MCI_FORMAT_SMPTE_30</term>
	/// </item>
	/// <item>
	/// <term>Tracks, minutes, seconds, frames</term>
	/// <term>MCI_FORMAT_TMSF</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgettimeformat void MCIWndGetTimeFormat( hwnd, lp, len );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetTimeFormat")]
	public static MCI_FORMAT MCIWndGetTimeFormat(HWND hwnd, StringBuilder lp) => (MCI_FORMAT)MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETTIMEFORMAT, lp);

	/// <summary>
	/// The <c>MCIWndGetVolume</c> macro retrieves the current volume setting of an MCI device. You can use this macro or explicitly
	/// send the MCIWNDM_GETVOLUME message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetvolume void MCIWndGetVolume( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetVolume")]
	public static int MCIWndGetVolume(HWND hwnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETVOLUME);

	/// <summary>
	/// The <c>MCIWndGetZoom</c> macro retrieves the current zoom value used by an MCI device. You can use this macro or explicitly send
	/// the MCIWNDM_GETZOOM message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndgetzoom void MCIWndGetZoom( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndGetZoom")]
	public static uint MCIWndGetZoom(HWND hwnd) => unchecked((uint)MCIWndSM(hwnd, MCIMessage.MCIWNDM_GETZOOM));

	/// <summary>
	/// The <c>MCIWndHome</c> macro moves the current position to the beginning of the content. You can use this macro or explicitly
	/// send the MCI_SEEK command.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndhome void MCIWndHome( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndHome")]
	public static int MCIWndHome(HWND hwnd) => MCIWndSeek(hwnd, MCIWND_START);

	/// <summary>
	/// The <c>MCIWndNew</c> macro creates a new file for the current MCI device. You can use this macro or explicitly send the
	/// MCIWNDM_NEW message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="lp">Pointer to a buffer containing the name of the MCI device that will use the file.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndnew void MCIWndNew( hwnd, lp );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndNew")]
	public static bool MCIWndNew(HWND hwnd, string lp) => SendMessage(hwnd, MCIMessage.MCIWNDM_NEW, 0, lp) != IntPtr.Zero;

	/// <summary>
	/// The <c>MCIWndOpen</c> macro opens an MCI device and associates it with an MCIWnd window. For MCI devices that use data files,
	/// this macro can also open a specified data file, name a new file to be created, or display a dialog box to let the user select a
	/// file to open. You can use this macro or explicitly send the MCIWNDM_OPEN message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="sz">
	/// Pointer to a null-terminated string identifying the filename or MCI Device Names to open. Specify ?1 for this parameter to
	/// display the Open dialog box.
	/// </param>
	/// <param name="f">
	/// Flags associated with the device or file to open. The MCIWNDOPENF_NEW flag specifies a new file is to be created with the name
	/// specified in szFile.
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndopen void MCIWndOpen( hwnd, sz, f );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndOpen")]
	public static int MCIWndOpen(HWND hwnd, string sz, MCIWNDOPENF f) => SendMessage(hwnd, MCIMessage.MCIWNDM_OPEN, (IntPtr)(int)f, sz).ToInt32();

	/// <summary>
	/// The <c>MCIWndOpenDialog</c> macro opens a user-specified data file and corresponding type of MCI device, and associates them
	/// with an MCIWnd window. This macro displays the Open dialog box for the user to select the data file to associate with an MCI
	/// window. You can use this macro or explicitly send the MCIWNDM_OPEN message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndopendialog void MCIWndOpenDialog( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndOpenDialog")]
	public static int MCIWndOpenDialog(HWND hwnd) => SendMessage(hwnd, MCIMessage.MCIWNDM_OPEN, (IntPtr)0, new IntPtr(-1)).ToInt32();

	/// <summary>
	/// The <c>MCIWndOpenInterface</c> macro attaches the data stream or file associated with the specified interface to an MCIWnd
	/// window. You can use this macro or explicitly send the MCIWNDM_OPENINTERFACE message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="pUnk">Pointer to an IAVI interface that points to a file or a data stream in a file.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndopeninterface void MCIWndOpenInterface( hwnd, pUnk );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndOpenInterface")]
	public static bool MCIWndOpenInterface(HWND hwnd, [In, MarshalAs(UnmanagedType.IUnknown)] object pUnk) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_OPENINTERFACE, default, Marshal.GetIUnknownForObject(pUnk)) != 0;

	/// <summary>Undocumented.</summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	[PInvokeData("vfw.h")]
	public static bool MCIWndPaletteKick(HWND hwnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_PALETTEKICK) != 0;

	/// <summary>The <c>MCIWndPause</c> macro sends a command to an MCI device to pause playing or recording.</summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndpause void MCIWndPause( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndPause")]
	public static int MCIWndPause(HWND hwnd) => MCIWndSM(hwnd, MCI.MCI_PAUSE);

	/// <summary>
	/// The <c>MCIWndPlay</c> macro sends a command to an MCI device to start playing from the current position in the content. You can
	/// use this macro or explicitly send the MCI_PLAY command.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndplay void MCIWndPlay( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndPlay")]
	public static int MCIWndPlay(HWND hwnd) => MCIWndSM(hwnd, MCI.MCI_PLAY);

	/// <summary>
	/// The <c>MCIWndPlayFrom</c> macro plays the content of an MCI device from the specified location to the end of the content or
	/// until another command stops playback. You can use this macro or explicitly send the MCIWNDM_PLAYFROM message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="lPos">Starting location. The units for the starting location depend on the current time format.</param>
	/// <returns>None</returns>
	/// <remarks>You can also specify both a starting and ending location for playback by using the MCIWndPlayFromTo macro.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndplayfrom void MCIWndPlayFrom( hwnd, lPos );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndPlayFrom")]
	public static int MCIWndPlayFrom(HWND hwnd, int lPos) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_PLAYFROM, 0, lPos);

	/// <summary>
	/// The <c>MCIWndPlayFromTo</c> macro plays a portion of content between specified starting and ending locations. This macro seeks
	/// to the specified point to begin playback, then plays the content to the specified ending location. This macro is defined using
	/// the MCIWndSeek and MCIWndPlayTo macros, which in turn use the MCI_SEEK command and the MCIWNDM_PLAYTO message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="lStart">Position to seek; it is also the starting location.</param>
	/// <param name="lEnd">Ending location.</param>
	/// <returns>None</returns>
	/// <remarks>The units for the seek position depend on the current time format.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndplayfromto void MCIWndPlayFromTo( hwnd, lStart, lEnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndPlayFromTo")]
	public static int MCIWndPlayFromTo(HWND hwnd, int lStart, int lEnd) { MCIWndSeek(hwnd, lStart); return MCIWndPlayTo(hwnd, lEnd); }

	/// <summary>
	/// The <c>MCIWndPlayReverse</c> macro plays the current content in the reverse direction, beginning at the current position and
	/// ending at the beginning of the content or until another command stops playback. You can use this macro or explicitly send the
	/// MCIWNDM_PLAYREVERSE message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndplayreverse void MCIWndPlayReverse( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndPlayReverse")]
	public static int MCIWndPlayReverse(HWND hwnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_PLAYREVERSE);

	/// <summary>
	/// The <c>MCIWndPlayTo</c> macro plays the content of an MCI device from the current position to the specified ending location or
	/// until another command stops playback. If the specified ending location is beyond the end of the content, playback stops at the
	/// end of the content. You can use this macro or explicitly send the MCIWNDM_PLAYTO message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="lPos">Ending location. The units for the ending location depend on the current time format.</param>
	/// <returns>None</returns>
	/// <remarks>You can also specify both a starting and ending location for playback by using the MCIWndPlayFromTo macro.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndplayto void MCIWndPlayTo( hwnd, lPos );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndPlayTo")]
	public static int MCIWndPlayTo(HWND hwnd, int lPos) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_PLAYTO, 0, lPos);

	/// <summary>
	/// The <c>MCIWndPutDest</c> macro redefines the coordinates of the destination rectangle used for zooming or stretching the images
	/// of an AVI file during playback. You can use this macro or explicitly send the MCIWNDM_PUT_DEST message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="prc">Pointer to a RECT structure containing the coordinates of the destination rectangle.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndputdest void MCIWndPutDest( hwnd, prc );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndPutDest")]
	public static int MCIWndPutDest(HWND hwnd, in RECT prc) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_PUT_DEST, 0, prc);

	/// <summary>
	/// The <c>MCIWndPutSource</c> macro redefines the coordinates of the source rectangle used for cropping the images of an AVI file
	/// during playback. You can use this macro or explicitly send the MCIWNDM_PUT_SOURCE message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="prc">Pointer to a RECT structure containing the coordinates of the source rectangle.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndputsource void MCIWndPutSource( hwnd, prc );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndPutSource")]
	public static int MCIWndPutSource(HWND hwnd, in RECT prc) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_PUT_SOURCE, 0, prc);

	/// <summary>
	/// The <c>MCIWndRealize</c> macro controls how an MCI window realized in the foreground or background. This macro also causes the
	/// palette for the MCI window to be realized in the process. You can use this macro or explicitly send the MCIWNDM_REALIZE message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="fBkgnd">
	/// Background flag. Specify <c>TRUE</c> for this parameter for the window to be realized in the background or <c>FALSE</c> if the
	/// window can be realized in the foreground.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// A common use for <c>MCIWndRealize</c> is to coordinate palette ownership between an MCI control and the application that
	/// contains it. The application can have the MCI window realize in the background and realize its own palette in the foreground.
	/// </para>
	/// <para>
	/// If your application contains an MCI control, but does not need to realize its palette, you can use this macro to handle the
	/// WM_PALETTECHANGED and WM_QUERYNEWPALETTE messages, instead of using <c>RealizePalette</c>. However, it is usually easier to call
	/// the <c>SendMessage</c> function to forward the message to the MCIWnd window, which will automatically realize the palette.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndrealize void MCIWndRealize( hwnd, fBkgnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndRealize")]
	public static int MCIWndRealize(HWND hwnd, bool fBkgnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_REALIZE, fBkgnd ? 1 : 0, 0);

	/// <summary>
	/// The <c>MCIWndRecord</c> macro begins recording content using the MCI device. The recording process begins at the current
	/// position in the content and will overwrite existing data for the duration of the recording.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// The function that an MCI device performs during recording depends on the characteristics of the device. An MCI device that uses
	/// files, such as a waveform-audio device, sends data to the file during recording. An MCI device that does not use files, such as
	/// a video-cassette recorder, receives and externally records data on another medium.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndrecord void MCIWndRecord( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndRecord")]
	public static int MCIWndRecord(HWND hwnd) => MCIWndSM(hwnd, MCI.MCI_RECORD);

	/// <summary>The <c>MCIWndRegisterClass</c> function registers the MCI window class MCIWND_WINDOW_CLASS.</summary>
	/// <returns>Returns zero if successful.</returns>
	/// <remarks>
	/// After registering the MCI window class, use the <c>CreateWindow</c> or <c>CreateWindowEx</c> functions to create an MCIWnd
	/// window. If your application uses this function, it does not need to use the MCIWndCreate function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndregisterclass BOOL VFWAPIV MCIWndRegisterClass();
	[DllImport(Lib_Msvfw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndRegisterClass")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool MCIWndRegisterClass();

	/// <summary>
	/// The <c>MCIWndResume</c> macro resumes playback or recording content from the paused mode. This macro restarts playback or
	/// recording from the current position in the content. You can use this macro or explicitly send the MCI_RESUME command.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndresume void MCIWndResume( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndResume")]
	public static int MCIWndResume(HWND hwnd) => MCIWndSM(hwnd, MCI.MCI_RESUME);

	/// <summary>
	/// The <c>MCIWndReturnString</c> macro retrieves the reply to the most recent MCI string command sent to an MCI device. Information
	/// in the reply is supplied as a null-terminated string. You can use this macro or explicitly send the MCIWNDM_RETURNSTRING message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="lp">Pointer to an application-defined buffer to contain the null-terminated string.</param>
	/// <returns>None</returns>
	/// <remarks>If the null-terminated string is longer than the buffer, the string is truncated.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndreturnstring void MCIWndReturnString( hwnd, lp, len );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndReturnString")]
	public static int MCIWndReturnString(HWND hwnd, StringBuilder lp) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_RETURNSTRING, lp);

	/// <summary>
	/// The <c>MCIWndSave</c> macro saves the content currently used by an MCI device. This macro can save the content to a specified
	/// data file or display the Save dialog box to let the user select a filename to store the content. You can use this macro or
	/// explicitly send the MCI_SAVE command.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="szFile">
	/// Null-terminated string containing the name and path of the destination file. Specify ?1 for this parameter to display the Save
	/// dialog box.
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndsave void MCIWndSave( hwnd, szFile );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndSave")]
	public static int MCIWndSave(HWND hwnd, string szFile) => SendMessage(hwnd, MCI.MCI_SAVE, 0, szFile).ToInt32();

	/// <summary>
	/// The <c>MCIWndSaveDialog</c> macro saves the content currently used by an MCI device. This macro displays the Save dialog box to
	/// let the user select a filename to store the content. You can use this macro or explicitly send the MCI_SAVE command.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndsavedialog void MCIWndSaveDialog( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndSaveDialog")]
	public static int MCIWndSaveDialog(HWND hwnd) => SendMessage(hwnd, MCI.MCI_SAVE, (IntPtr)0, new IntPtr(-1)).ToInt32();

	/// <summary>
	/// The <c>MCIWndSave</c> macro saves the content currently used by an MCI device. This macro can save the content to a specified
	/// data file or display the Save dialog box to let the user select a filename to store the content. You can use this macro or
	/// explicitly send the MCI_SAVE command.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndsave void MCIWndSave( hwnd, szFile );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndSave")]
	public static int MCIWndSaveWithDialog(HWND hwnd) => MCIWndSM(hwnd, MCI.MCI_SAVE, 0, -1);

	/// <summary>
	/// The <c>MCIWndSeek</c> macro moves the playback position to the specified location in the content. You can use this macro or
	/// explicitly use the MCI_SEEK command.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="lPos">
	/// Position to seek. You can specify a position using the current time format, the MCIWND_START constant to designate the beginning
	/// of the content, or the MCIWND_END constant to designate the end of the content.
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndseek void MCIWndSeek( hwnd, lPos );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndSeek")]
	public static int MCIWndSeek(HWND hwnd, int lPos) => MCIWndSM(hwnd, MCI.MCI_SEEK, 0, lPos);

	/// <summary>
	/// The <c>MCIWndSendString</c> macro sends an MCI command in string form to the device associated with the MCIWnd window. You can
	/// use this macro or explicitly send the MCIWNDM_SENDSTRING message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="sz">String command to send to the MCI device.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// The message handler for <c>MCIWndSendString</c> (and <c>MCIWNDM_SENDSTRING</c>) appends a device alias to the MCI command you
	/// send to the device. Therefore, you should not use any alias in an MCI command that you issue with <c>MCIWndSendString</c>.
	/// </para>
	/// <para>To get the return string, which contains the result of the command, use the MCIWndReturnString macro.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndsendstring void MCIWndSendString( hwnd, sz );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndSendString")]
	public static int MCIWndSendString(HWND hwnd, string sz) => SendMessage(hwnd, MCIMessage.MCIWNDM_SENDSTRING, IntPtr.Zero, sz).ToInt32();

	/// <summary>
	/// The <c>MCIWndSetActiveTimer</c> macro sets the update period used by MCIWnd to update the trackbar in the MCIWnd window, update
	/// position information displayed in the window title bar, and send notification messages to the parent window when the MCIWnd
	/// window is active. You can use this macro or explicitly send the MCIWNDM_SETACTIVETIMER message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="active">Update period, in milliseconds. The default is 500 milliseconds.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndsetactivetimer void MCIWndSetActiveTimer( hwnd, active );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndSetActiveTimer")]
	public static void MCIWndSetActiveTimer(HWND hwnd, uint active) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_SETACTIVETIMER, unchecked((int)active), 0);

	/// <summary>
	/// The <c>MCIWndSetInactiveTimer</c> macro sets the update period used by MCIWnd to update the trackbar in the MCIWnd window,
	/// update position information displayed in the window title bar, and send notification messages to the parent window when the
	/// MCIWnd window is inactive. You can use this macro or explicitly send the MCIWNDM_SETINACTIVETIMER message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="inactive">Update period, in milliseconds. The default is 2000 milliseconds.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndsetinactivetimer void MCIWndSetInactiveTimer( hwnd, inactive );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndSetInactiveTimer")]
	public static void MCIWndSetInactiveTimer(HWND hwnd, uint inactive) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_SETINACTIVETIMER, unchecked((int)inactive), 0);

	/// <summary>
	/// The <c>MCIWndSetOwner</c> macro sets the window to receive notification messages associated with the MCIWnd window. You can use
	/// this macro or explicitly send the MCIWNDM_SETOWNER message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="hwndP">Handle of the window to receive the notification messages.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndsetowner void MCIWndSetOwner( hwnd, hwndP );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndSetOwner")]
	public static int MCIWndSetOwner(HWND hwnd, HWND hwndP) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_SETOWNER, (IntPtr)hwndP);

	/// <summary>
	/// The <c>MCIWndSetPalette</c> macro sends a palette handle to the MCI device associated with the MCIWnd window. You can use this
	/// macro or explicitly send the MCIWNDM_SETPALETTE message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="hpal">Palette handle.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndsetpalette void MCIWndSetPalette( hwnd, hpal );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndSetPalette")]
	public static int MCIWndSetPalette(HWND hwnd, HPALETTE hpal) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_SETPALETTE, (IntPtr)hpal);

	/// <summary>
	/// The <c>MCIWndSetRepeat</c> macro sets the repeat flag associated with continuous playback. You can use this macro or explicitly
	/// send the MCIWNDM_SETREPEAT message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="f">New state of the repeat flag. Specify <c>TRUE</c> to turn on continuous playback.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// The <c>MCIWndSetRepeat</c> macro only affects playback that the user initiates by hitting the play button on the toolbar. It
	/// will not affect playback started with the <c>MCIWndPlay</c> macro.
	/// </para>
	/// <para>Currently, MCIAVI is the only device that supports continuous playback.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndsetrepeat void MCIWndSetRepeat( hwnd, f );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndSetRepeat")]
	public static void MCIWndSetRepeat(HWND hwnd, bool f) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_SETREPEAT, 0, f ? 1 : 0);

	/// <summary>
	/// The <c>MCIWndSetSpeed</c> macro sets the playback speed of an MCI device. You can use this macro or explicitly send the
	/// MCIWNDM_SETSPEED message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="iSpeed">
	/// Playback speed. Specify 1000 for normal speed, larger values for faster speeds, and smaller values for slower speeds.
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndsetspeed void MCIWndSetSpeed( hwnd, iSpeed );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndSetSpeed")]
	public static int MCIWndSetSpeed(HWND hwnd, uint iSpeed) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_SETSPEED, 0, iSpeed);

	/// <summary>
	/// The <c>MCIWndSetTimeFormat</c> macro sets the time format of an MCI device. You can use this macro or explicitly send the
	/// MCIWNDM_SETTIMEFORMAT message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="lp">
	/// Pointer to a buffer containing the null-terminated string indicating the time format. Specify "frames" to set the time format to
	/// frames, or "ms" to set the time format to milliseconds.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// An application can specify time formats other than frames or milliseconds as long as the formats are supported by the MCI
	/// device. Noncontinuous formats, such as tracks and SMPTE, can cause the trackbar to behave erratically. For these time formats,
	/// you might want to turn off the toolbar by using the MCIWndChangeStyles macro and specifying the MCIWNDF_NOPLAYBAR window style.
	/// </para>
	/// <para>
	/// If you want to set the time format to frames or milliseconds, you can also use the <c>MCIWndUseFrames</c> or
	/// <c>MCIWndUseTime</c> macro. For a list of time formats, see the <c>MCIWndGetTimeFormat</c> macro.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndsettimeformat void MCIWndSetTimeFormat( hwnd, lp );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndSetTimeFormat")]
	public static int MCIWndSetTimeFormat(HWND hwnd, string lp) => SendMessage(hwnd, MCIMessage.MCIWNDM_SETTIMEFORMAT, 0, lp).ToInt32();

	/// <summary>
	/// The <c>MCIWndSetTimers</c> macro sets the update periods used by MCIWnd to update the trackbar in the MCIWnd window, update the
	/// position information displayed in the window title bar, and send notification messages to the parent window. You can use this
	/// macro or explicitly send the MCIWNDM_SETTIMERS message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="active">
	/// Update period used by MCIWnd when it is the active window. The default value is 500 milliseconds. Storage for this value is
	/// limited to 16 bits.
	/// </param>
	/// <param name="inactive">
	/// Update period used by MCIWnd when it is the inactive window. The default value is 2000 milliseconds. Storage for this value is
	/// limited to 16 bits.
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndsettimers void MCIWndSetTimers( hwnd, active, inactive );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndSetTimers")]
	public static void MCIWndSetTimers(HWND hwnd, uint active, uint inactive) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_SETTIMERS, unchecked((int)active), unchecked((int)inactive));

	/// <summary>
	/// The <c>MCIWndSetVolume</c> macro sets the volume level of an MCI device. You can use this macro or explicitly send the
	/// MCIWNDM_SETVOLUME message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="iVol">
	/// New volume level. Specify 1000 for normal volume level. Specify a higher value for a louder volume or a lower value for a
	/// quieter volume.
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndsetvolume void MCIWndSetVolume( hwnd, iVol );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndSetVolume")]
	public static int MCIWndSetVolume(HWND hwnd, uint iVol) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_SETVOLUME, 0, iVol);

	/// <summary>
	/// The <c>MCIWndSetZoom</c> macro resizes a video image according to a zoom factor. This marco adjusts the size of an MCIWnd window
	/// while maintaining a constant aspect ratio. You can use this macro or explicitly send the MCIWNDM_SETZOOM message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="iZoom">
	/// Zoom factor expressed as a percentage of the original image. Specify 100 to display the image at its authored size, 200 to
	/// display the image at twice its normal size, or 50 to display the image at half its normal size.
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndsetzoom void MCIWndSetZoom( hwnd, iZoom );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndSetZoom")]
	public static void MCIWndSetZoom(HWND hwnd, uint iZoom) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_SETZOOM, 0, iZoom);

	/// <summary>
	/// The <c>MCIWndStep</c> macro moves the current position in the content forward or backward by a specified increment. You can use
	/// this macro or explicitly send the MCI_STEP command.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <param name="n">
	/// Step value. Negative values step the device through the content in reverse. The units for the step value depend on the current
	/// time format.
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndstep void MCIWndStep( hwnd, n );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndStep")]
	public static int MCIWndStep(HWND hwnd, int n) => MCIWndSM(hwnd, MCI.MCI_STEP, 0, n);

	/// <summary>
	/// The <c>MCIWndStop</c> macro stops playing or recording the content of the MCI device associated with the MCIWnd window. You can
	/// use this macro or explicitly send the MCI_STOP command.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndstop void MCIWndStop( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndStop")]
	public static int MCIWndStop(HWND hwnd) => MCIWndSM(hwnd, MCI.MCI_STOP);

	/// <summary>
	/// The <c>MCIWndUseFrames</c> macro sets the time format of an MCI device to frames. You can use this macro or explicitly send the
	/// MCIWNDM_SETTIMEFORMAT message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwnduseframes void MCIWndUseFrames( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndUseFrames")]
	public static int MCIWndUseFrames(HWND hwnd) => MCIWndSetTimeFormat(hwnd, "frames");

	/// <summary>
	/// The <c>MCIWndUseTime</c> macro sets the time format of an MCI device to milliseconds. You can use this macro or explicitly send
	/// the MCIWNDM_SETTIMEFORMAT message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndusetime void MCIWndUseTime( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndUseTime")]
	public static int MCIWndUseTime(HWND hwnd) => MCIWndSetTimeFormat(hwnd, "ms");

	/// <summary>
	/// The <c>MCIWndValidateMedia</c> macro updates the starting and ending locations of the content, the current position in the
	/// content, and the trackbar according to the current time format. You can use this macro or explicitly send the
	/// MCIWNDM_VALIDATEMEDIA message.
	/// </summary>
	/// <param name="hwnd">Handle of the MCIWnd window.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// Typically, you should not need to use this macro; however, if your application changes the time format of a device without using
	/// MCIWnd; the starting and ending locations of the content, as well as the trackbar, continue to use the old format. You can use
	/// this macro to update these values.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vfw/nf-vfw-mciwndvalidatemedia void MCIWndValidateMedia( hwnd );
	[PInvokeData("vfw.h", MSDNShortId = "NF:vfw.MCIWndValidateMedia")]
	public static void MCIWndValidateMedia(HWND hwnd) => MCIWndSM(hwnd, MCIMessage.MCIWNDM_VALIDATEMEDIA);

	private static int MCIWndSM<TEnum>(HWND hwnd, TEnum msg, int wparam, int lparam) where TEnum : struct, IConvertible => SendMessage(hwnd, msg, (IntPtr)wparam, (IntPtr)lparam).ToInt32();

	private static int MCIWndSM<TEnum>(HWND hwnd, TEnum msg, [Optional] IntPtr wparam, [Optional] IntPtr lparam) where TEnum : struct, IConvertible => SendMessage(hwnd, msg, wparam, lparam).ToInt32();

	private static int MCIWndSM<TEnum>(HWND hwnd, TEnum msg, StringBuilder lparam) where TEnum : struct, IConvertible => SendMessage(hwnd, msg, (IntPtr)lparam.Capacity, lparam).ToInt32();

	private static int MCIWndSM<TEnum, TLP>(HWND hwnd, TEnum msg, out TLP lparam, int size = -1) where TEnum : struct, IConvertible where TLP : struct
	{
		TLP res = default;
		var ret = SendMessage(hwnd, msg, (IntPtr)(size == -1 ? Marshal.SizeOf(typeof(TLP)) : size), ref res).ToInt32();
		lparam = res;
		return ret;
	}

	private static int MCIWndSM<TEnum, TLP>(HWND hwnd, TEnum msg, int size, in TLP lparam) where TEnum : struct, IConvertible where TLP : struct
	{
		TLP res = lparam;
		return SendMessage(hwnd, msg, (IntPtr)(size == -1 ? Marshal.SizeOf(typeof(TLP)) : size), ref res).ToInt32();
	}
}