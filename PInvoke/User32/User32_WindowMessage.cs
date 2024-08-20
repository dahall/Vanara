namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>The "snap desktop" hot key was pressed.</summary>
	public const int IDHOT_SNAPDESKTOP = -2;

	/// <summary>The "snap window" hot key was pressed.</summary>
	public const int IDHOT_SNAPWINDOW = -1;

	/// <summary>Value to pass as the wParam to a WM_UNICARE message to test whether a target app can process WM_UNICHAR messages.</summary>
	public const char UNICODE_NOCHAR = (char)0xFFFF;

	private const int FAPPCOMMAND_MASK = 0xF000;

	/// <summary>
	/// Part of the details returned by WM_APPCOMMAND. Specifies the application command. Use <see cref="GET_APPCOMMAND_LPARAM"/> to extract
	/// this value.
	/// </summary>
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.wm-appcommand")]
	public enum APPCOMMAND
	{
		/// <summary>Toggle the bass boost on and off.</summary>
		APPCOMMAND_BASS_BOOST = 20,

		/// <summary>Decrease the bass.</summary>
		APPCOMMAND_BASS_DOWN = 19,

		/// <summary>Increase the bass.</summary>
		APPCOMMAND_BASS_UP = 21,

		/// <summary>Navigate backward.</summary>
		APPCOMMAND_BROWSER_BACKWARD = 1,

		/// <summary>Open favorites.</summary>
		APPCOMMAND_BROWSER_FAVORITES = 6,

		/// <summary>Navigate forward.</summary>
		APPCOMMAND_BROWSER_FORWARD = 2,

		/// <summary>Navigate home.</summary>
		APPCOMMAND_BROWSER_HOME = 7,

		/// <summary>Refresh page.</summary>
		APPCOMMAND_BROWSER_REFRESH = 3,

		/// <summary>Open search.</summary>
		APPCOMMAND_BROWSER_SEARCH = 5,

		/// <summary>Stop download.</summary>
		APPCOMMAND_BROWSER_STOP = 4,

		/// <summary>Close the window (not the application).</summary>
		APPCOMMAND_CLOSE = 31,

		/// <summary>Copy the selection.</summary>
		APPCOMMAND_COPY = 36,

		/// <summary>Brings up the correction list when a word is incorrectly identified during speech input.</summary>
		APPCOMMAND_CORRECTION_LIST = 45,

		/// <summary>Cut the selection.</summary>
		APPCOMMAND_CUT = 37,

		/// <summary>
		/// Toggles between two modes of speech input: dictation and command/control (giving commands to an application or accessing menus).
		/// </summary>
		APPCOMMAND_DICTATE_OR_COMMAND_CONTROL_TOGGLE = 43,

		/// <summary>Open the Find dialog.</summary>
		APPCOMMAND_FIND = 28,

		/// <summary>Forward a mail message.</summary>
		APPCOMMAND_FORWARD_MAIL = 40,

		/// <summary>Open the Help dialog.</summary>
		APPCOMMAND_HELP = 27,

		/// <summary>Start App1.</summary>
		APPCOMMAND_LAUNCH_APP1 = 17,

		/// <summary>Start App2.</summary>
		APPCOMMAND_LAUNCH_APP2 = 18,

		/// <summary>Open mail.</summary>
		APPCOMMAND_LAUNCH_MAIL = 15,

		/// <summary>Go to Media Select mode.</summary>
		APPCOMMAND_LAUNCH_MEDIA_SELECT = 16,

		/// <summary>Decrement the channel value, for example, for a TV or radio tuner.</summary>
		APPCOMMAND_MEDIA_CHANNEL_DOWN = 52,

		/// <summary>Increment the channel value, for example, for a TV or radio tuner.</summary>
		APPCOMMAND_MEDIA_CHANNEL_UP = 51,

		/// <summary>
		/// Increase the speed of stream playback. This can be implemented in many ways, for example, using a fixed speed or toggling through
		/// a series of increasing speeds.
		/// </summary>
		APPCOMMAND_MEDIA_FAST_FORWARD = 49,

		/// <summary>Go to next track.</summary>
		APPCOMMAND_MEDIA_NEXTTRACK = 11,

		/// <summary>
		/// Pause. If already paused, take no further action. This is a direct PAUSE command that has no state. If there are discrete Play
		/// and Pause buttons, applications should take action on this command as well as APPCOMMAND_MEDIA_PLAY_PAUSE.
		/// </summary>
		APPCOMMAND_MEDIA_PAUSE = 47,

		/// <summary>
		/// Begin playing at the current position. If already paused, it will resume. This is a direct PLAY command that has no state. If
		/// there are discrete Play and Pause buttons, applications should take action on this command as well as APPCOMMAND_MEDIA_PLAY_PAUSE.
		/// </summary>
		APPCOMMAND_MEDIA_PLAY = 46,

		/// <summary>
		/// Play or pause playback. If there are discrete Play and Pause buttons, applications should take action on this command as well as
		/// APPCOMMAND_MEDIA_PLAY and APPCOMMAND_MEDIA_PAUSE.
		/// </summary>
		APPCOMMAND_MEDIA_PLAY_PAUSE = 14,

		/// <summary>Go to previous track.</summary>
		APPCOMMAND_MEDIA_PREVIOUSTRACK = 12,

		/// <summary>Begin recording the current stream.</summary>
		APPCOMMAND_MEDIA_RECORD = 48,

		/// <summary>
		/// Go backward in a stream at a higher rate of speed. This can be implemented in many ways, for example, using a fixed speed or
		/// toggling through a series of increasing speeds.
		/// </summary>
		APPCOMMAND_MEDIA_REWIND = 50,

		/// <summary>Stop playback.</summary>
		APPCOMMAND_MEDIA_STOP = 13,

		/// <summary>Toggle the microphone.</summary>
		APPCOMMAND_MIC_ON_OFF_TOGGLE = 44,

		/// <summary>Decrease microphone volume.</summary>
		APPCOMMAND_MICROPHONE_VOLUME_DOWN = 25,

		/// <summary>Mute the microphone.</summary>
		APPCOMMAND_MICROPHONE_VOLUME_MUTE = 24,

		/// <summary>Increase microphone volume.</summary>
		APPCOMMAND_MICROPHONE_VOLUME_UP = 26,

		/// <summary>Create a new window.</summary>
		APPCOMMAND_NEW = 29,

		/// <summary>Open a window.</summary>
		APPCOMMAND_OPEN = 30,

		/// <summary>Paste</summary>
		APPCOMMAND_PASTE = 38,

		/// <summary>Print current document.</summary>
		APPCOMMAND_PRINT = 33,

		/// <summary>Redo last action.</summary>
		APPCOMMAND_REDO = 35,

		/// <summary>Reply to a mail message.</summary>
		APPCOMMAND_REPLY_TO_MAIL = 39,

		/// <summary>Save current document.</summary>
		APPCOMMAND_SAVE = 32,

		/// <summary>Send a mail message.</summary>
		APPCOMMAND_SEND_MAIL = 41,

		/// <summary>Initiate a spell check.</summary>
		APPCOMMAND_SPELL_CHECK = 42,

		/// <summary>Decrease the treble.</summary>
		APPCOMMAND_TREBLE_DOWN = 22,

		/// <summary>Increase the treble.</summary>
		APPCOMMAND_TREBLE_UP = 23,

		/// <summary>Undo last action.</summary>
		APPCOMMAND_UNDO = 34,

		/// <summary>Lower the volume.</summary>
		APPCOMMAND_VOLUME_DOWN = 9,

		/// <summary>Mute the volume.</summary>
		APPCOMMAND_VOLUME_MUTE = 8,

		/// <summary>Raise the volume.</summary>
		APPCOMMAND_VOLUME_UP = 10,

		/// <summary/>
		APPCOMMAND_DELETE = 53,

		/// <summary/>
		APPCOMMAND_DWM_FLIP3D = 54,
	}

	/// <summary>lParam value for WM_QUERYENDSESSION.</summary>
	[PInvokeData("winuser.h")]
	[Flags]
	public enum ENDSESSION : uint
	{
		/// <summary>
		/// The application is using a file that must be replaced, the system is being serviced, or system resources are exhausted. For more
		/// information, see Guidelines for Applications.
		/// </summary>
		ENDSESSION_CLOSEAPP = 0x00000001,

		/// <summary>The application is forced to shut down.</summary>
		ENDSESSION_CRITICAL = 0x40000000,

		/// <summary>The user is logging off. For more information, see Logging Off.</summary>
		ENDSESSION_LOGOFF = 0x80000000,
	}

	/// <summary>
	/// Part of the details returned by WM_APPCOMMAND. Specifies the input device that generated the input event. Use <see
	/// cref="GET_DEVICE_LPARAM"/> to extract this value.
	/// </summary>
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.wm-appcommand")]
	[Flags]
	public enum FAPPCOMMAND
	{
		/// <summary>User clicked a mouse button.</summary>
		FAPPCOMMAND_MOUSE = 0x8000,

		/// <summary>User pressed a key.</summary>
		FAPPCOMMAND_KEY = 0,

		/// <summary>An unidentified hardware source generated the event. It could be a mouse or a keyboard event.</summary>
		FAPPCOMMAND_OEM = 0x1000,
	}

	/// <summary>wParam value for WM_INPUT_DEVICE_CHANGE.</summary>
	[PInvokeData("winuser.h")]
	public enum GIDC
	{
		/// <summary>
		/// A new device has been added to the system. You can call GetRawInputDeviceInfo to get more information regarding the device.
		/// </summary>
		GIDC_ARRIVAL = 1,

		/// <summary>A device has been removed from the system.</summary>
		GIDC_REMOVAL = 2,
	}

	/// <summary>The new input locale.</summary>
	[PInvokeData("winuser.h")]
	[Flags]
	public enum INPUTLANGCHANGE : int
	{
		/// <summary>The new input locale's keyboard layout can be used with the system character set.</summary>
		INPUTLANGCHANGE_SYSCHARSET = 0x0001,

		/// <summary>
		/// A hot key was used to choose the next input locale in the installed list of input locales. This flag cannot be used with the
		/// INPUTLANGCHANGE_BACKWARD flag.
		/// </summary>
		INPUTLANGCHANGE_FORWARD = 0x0002,

		/// <summary>
		/// A hot key was used to choose the previous input locale in the installed list of input locales. This flag cannot be used with the
		/// INPUTLANGCHANGE_FORWARD flag.
		/// </summary>
		INPUTLANGCHANGE_BACKWARD = 0x0004,
	}

	/// <summary>lParam flags for WM_IME_SETCONTEXT</summary>
	[PInvokeData("imm.h")]
	[Flags]
	public enum ISC : uint
	{
		/// <summary>Show the candidate window of index 0 by user interface window.</summary>
		ISC_SHOWUICANDIDATEWINDOW = 0x00000001,

		/// <summary>Show the composition window by user interface window.</summary>
		ISC_SHOWUICOMPOSITIONWINDOW = 0x80000000,

		/// <summary>Show the guide window by user interface window.</summary>
		ISC_SHOWUIGUIDELINE = 0x40000000,

		/// <summary/>
		ISC_SHOWUIALLCANDIDATEWINDOW = 0x0000000F,

		/// <summary/>
		ISC_SHOWUIALL = 0xC000000F,
	}

	/// <summary>WM_MENUDRAG return values.</summary>
	[PInvokeData("winuser.h")]
	public enum MND
	{
		/// <summary>Menu should remain active. If the mouse is released, it should be ignored.</summary>
		MND_CONTINUE = 0,

		/// <summary>Menu should be ended.</summary>
		MND_ENDMENU = 1,
	}

	/// <summary>WM_MENUGETOBJECT return values.</summary>
	[PInvokeData("winuser.h")]
	public enum MNGO
	{
		/// <summary>The interface is not supported.</summary>
		MNGO_NOINTERFACE = 0x00000000,

		/// <summary>An interface pointer was returned in the pvObj member of MENUGETOBJECTINFO</summary>
		MNGO_NOERROR = 0x00000001,
	}

	/// <summary>Message filter values. Used in wParam from WM_ENTERIDLE message.</summary>
	[PInvokeData("winuser.h")]
	public enum MSGF
	{
		/// <summary>The system is idle because a dialog box is displayed.</summary>
		MSGF_DIALOGBOX = 0,

		/// <summary>Indicates an input event occurred in a message box.</summary>
		MSGF_MESSAGEBOX = 1,

		/// <summary>The system is idle because a menu is displayed.</summary>
		MSGF_MENU = 2,

		/// <summary/>
		MSGF_MOVE = 3,

		/// <summary/>
		MSGF_SIZE = 4,

		/// <summary>The input event occurred in a scroll bar.</summary>
		MSGF_SCROLLBAR = 5,

		/// <summary>The input event occurred as a result of the user's pressing the ALT+TAB key combination to activate a different window.</summary>
		MSGF_NEXTWINDOW = 6,

		/// <summary/>
		MSGF_MAINLOOP = 8,

		/// <summary/>
		MSGF_MAX = 8,

		/// <summary/>
		MSGF_USER = 4096,
	}

	/// <summary>Values associated with WM_NOTIFYFORMAT</summary>
	[PInvokeData("winuser.h")]
	public enum NOTIFYFORMAT : int
	{
		/// <summary>An error occurred.</summary>
		NFR_ERROR = 0,

		/// <summary>ANSI structures should be used in WM_NOTIFY messages sent by the control.</summary>
		NFR_ANSI = 1,

		/// <summary>Unicode structures should be used in WM_NOTIFY messages sent by the control.</summary>
		NFR_UNICODE = 2,

		/// <summary>
		/// The message is a query to determine whether ANSI or Unicode structures should be used in WM_NOTIFY messages. This command is sent
		/// from a control to its parent window during the creation of a control and in response to an NF_REQUERY command.
		/// </summary>
		NF_QUERY = 3,

		/// <summary>
		/// The message is a request for a control to send an NF_QUERY form of this message to its parent window. This command is sent from
		/// the parent window. The parent window is asking the control to requery it about the type of structures to use in WM_NOTIFY
		/// messages. If lParam is NF_REQUERY, the return value is the result of the requery operation.
		/// </summary>
		NF_REQUERY = 4,
	}

	/// <summary>lParam for WM_PRINT message. The drawing options.</summary>
	[PInvokeData("winuser.h")]
	[Flags]
	public enum PRF
	{
		/// <summary>Draws the window only if it is visible.</summary>
		PRF_CHECKVISIBLE = 0x00000001,

		/// <summary>Draws the nonclient area of the window.</summary>
		PRF_NONCLIENT = 0x00000002,

		/// <summary>Draws the client area of the window.</summary>
		PRF_CLIENT = 0x00000004,

		/// <summary>Erases the background before drawing the window.</summary>
		PRF_ERASEBKGND = 0x00000008,

		/// <summary>Draws all visible children windows.</summary>
		PRF_CHILDREN = 0x00000010,

		/// <summary>Draws all owned windows.</summary>
		PRF_OWNED = 0x00000020
	}

	/// <summary>wParam from WM_INPUT message</summary>
	[PInvokeData("winuser.h")]
	public enum RIM_CODE
	{
		/// <summary>Input occurred while the application was in the foreground.</summary>
		RIM_INPUT = 0,

		/// <summary>Input occurred while the application was not in the foreground.</summary>
		RIM_INPUTSINK = 1,
	}

	/// <summary>The scroll command supplied in the LOWORD value of wParam when handling WM_HSCROLL or WM_VSCROLL messages.</summary>
	[PInvokeData("winuser.h")]
	public enum SBCMD : ushort
	{
		/// <summary>Scrolls one line up.</summary>
		SB_LINEUP = 0,

		/// <summary>Scrolls left by one unit.</summary>
		SB_LINELEFT = 0,

		/// <summary>Scrolls one line down.</summary>
		SB_LINEDOWN = 1,

		/// <summary>Scrolls right by one unit.</summary>
		SB_LINERIGHT = 1,

		/// <summary>Scrolls one page up.</summary>
		SB_PAGEUP = 2,

		/// <summary>Scrolls left by the width of the window.</summary>
		SB_PAGELEFT = 2,

		/// <summary>Scrolls one page down.</summary>
		SB_PAGEDOWN = 3,

		/// <summary>Scrolls right by the width of the window.</summary>
		SB_PAGERIGHT = 3,

		/// <summary>
		/// The user has dragged the scroll box (thumb) and released the mouse button. The HIWORD indicates the position of the scroll box at
		/// the end of the drag operation.
		/// </summary>
		SB_THUMBPOSITION = 4,

		/// <summary>
		/// The user is dragging the scroll box. This message is sent repeatedly until the user releases the mouse button. The HIWORD
		/// indicates the position that the scroll box has been dragged to.
		/// </summary>
		SB_THUMBTRACK = 5,

		/// <summary>Scrolls to the upper left.</summary>
		SB_TOP = 6,

		/// <summary>Scrolls to the upper left.</summary>
		SB_LEFT = 6,

		/// <summary>The sb bottom</summary>
		SB_BOTTOM = 7,

		/// <summary>Scrolls to the lower right.</summary>
		SB_RIGHT = 7,

		/// <summary>Ends scroll.</summary>
		SB_ENDSCROLL = 8,
	}

	/// <summary>Specifies the action to be taken.</summary>
	[PInvokeData("winuser.h")]
	public enum UIS : ushort
	{
		/// <summary>The UI state flags specified by the high-order word should be set.</summary>
		UIS_SET = 1,

		/// <summary>The UI state flags specified by the high-order word should be cleared.</summary>
		UIS_CLEAR = 2,

		/// <summary>
		/// The UI state flags specified by the high-order word should be changed based on the last input event. For more information, see Remarks.
		/// </summary>
		UIS_INITIALIZE = 3,
	}

	/// <summary>Specifies which UI state elements are affected or the style of the control.</summary>
	[PInvokeData("winuser.h")]
	[Flags]
	public enum UISF : ushort
	{
		/// <summary>Focus indicators are hidden.</summary>
		UISF_HIDEFOCUS = 0x1,

		/// <summary>Keyboard accelerators are hidden.</summary>
		UISF_HIDEACCEL = 0x2,

		/// <summary>A control should be drawn in the style used for active controls.</summary>
		UISF_ACTIVE = 0x4,
	}

	/// <summary>Windows Messages</summary>
	[PInvokeData("winuser.h")]
	public enum WindowMessage
	{
		/// <summary>
		/// <para>
		/// Performs no operation. An application sends the <c>WM_NULL</c> message if it wants to post a message that the recipient window
		/// will ignore.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NULL 0x0000</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>An application returns zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// For example, if an application has installed a <c>WH_GETMESSAGE</c> hook and wants to prevent a message from being processed, the
		/// <c>GetMsgProc</c> callback function can change the message number to <c>WM_NULL</c> so the recipient will ignore it.
		/// </para>
		/// <para>
		/// As another example, an application can check if a window is responding to messages by sending the <c>WM_NULL</c> message with the
		/// <c>SendMessageTimeout</c> function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-null
		[MsgParams()]
		WM_NULL = 0x0000,

		/// <summary>
		/// <para>
		/// Sent when an application requests that a window be created by calling the <c>CreateWindowEx</c> or <c>CreateWindow</c> function.
		/// (The message is sent before the function returns.) The window procedure of the new window receives this message after the window
		/// is created, but before the window becomes visible.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_CREATE 0x0001</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>CREATESTRUCT</c> structure that contains information about the window being created.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>
		/// If an application processes this message, it should return zero to continue creation of the window. If the application returns
		/// –1, the window is destroyed and the <c>CreateWindowEx</c> or <c>CreateWindow</c> function returns a <c>NULL</c> handle.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-create
		[MsgParams(LParamType = typeof(CREATESTRUCT?))]
		WM_CREATE = 0x0001,

		/// <summary>
		/// <para>
		/// Sent when a window is being destroyed. It is sent to the window procedure of the window being destroyed after the window is
		/// removed from the screen.
		/// </para>
		/// <para>
		/// This message is sent first to the window being destroyed and then to the child windows (if any) as they are destroyed. During the
		/// processing of the message, it can be assumed that all child windows still exist.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_DESTROY 0x0002</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// If the window being destroyed is part of the clipboard viewer chain (set by calling the <c>SetClipboardViewer</c> function), the
		/// window must remove itself from the chain by processing the <c>ChangeClipboardChain</c> function before returning from the
		/// <c>WM_DESTROY</c> message.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-destroy
		[MsgParams()]
		WM_DESTROY = 0x0002,

		/// <summary>
		/// <para>Sent after a window has been moved.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_MOVE 0x0003</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The x and y coordinates of the upper-left corner of the client area of the window. The low-order word contains the x-coordinate
		/// while the high-order word contains the y coordinate.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The parameters are given in screen coordinates for overlapped and pop-up windows and in parent-client coordinates for child windows.
		/// </para>
		/// <para>The following example demonstrates how to obtain the position from the lParam parameter.</para>
		/// <para>
		/// <code>xPos = (int)(short) LOWORD(lParam); // horizontal position yPos = (int)(short) HIWORD(lParam); // vertical position</code>
		/// </para>
		/// <para>You can also use the <c>MAKEPOINTS</c> macro to convert the lParam parameter to a <c>POINTS</c> structure.</para>
		/// <para>
		/// The <c>DefWindowProc</c> function sends the <c>WM_SIZE</c> and <c>WM_MOVE</c> messages when it processes the
		/// <c>WM_WINDOWPOSCHANGED</c> message. The <c>WM_SIZE</c> and <c>WM_MOVE</c> messages are not sent if an application handles the
		/// <c>WM_WINDOWPOSCHANGED</c> message without calling <c>DefWindowProc</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-move
		[MsgParams(null, typeof(POINTS))]
		WM_MOVE = 0x0003,

		/// <summary>
		/// <para>Sent to a window after its size has changed.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_SIZE 0x0005</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The type of resizing requested. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SIZE_MAXHIDE</c> 4</term>
		/// <term>Message is sent to all pop-up windows when some other window is maximized.</term>
		/// </item>
		/// <item>
		/// <term><c>SIZE_MAXIMIZED</c> 2</term>
		/// <term>The window has been maximized.</term>
		/// </item>
		/// <item>
		/// <term><c>SIZE_MAXSHOW</c> 3</term>
		/// <term>Message is sent to all pop-up windows when some other window has been restored to its former size.</term>
		/// </item>
		/// <item>
		/// <term><c>SIZE_MINIMIZED</c> 1</term>
		/// <term>The window has been minimized.</term>
		/// </item>
		/// <item>
		/// <term><c>SIZE_RESTORED</c> 0</term>
		/// <term>The window has been resized, but neither the <c>SIZE_MINIMIZED</c> nor <c>SIZE_MAXIMIZED</c> value applies.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>The low-order word of lParam specifies the new width of the client area.</para>
		/// <para>The high-order word of lParam specifies the new height of the client area.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the <c>SetScrollPos</c> or <c>MoveWindow</c> function is called for a child window as a result of the <c>WM_SIZE</c> message,
		/// the bRedraw or bRepaint parameter should be nonzero to cause the window to be repainted.
		/// </para>
		/// <para>
		/// Although the width and height of a window are 32-bit values, the lParam parameter contains only the low-order 16 bits of each.
		/// </para>
		/// <para>
		/// The <c>DefWindowProc</c> function sends the <c>WM_SIZE</c> and <c>WM_MOVE</c> messages when it processes the
		/// <c>WM_WINDOWPOSCHANGED</c> message. The <c>WM_SIZE</c> and <c>WM_MOVE</c> messages are not sent if an application handles the
		/// <c>WM_WINDOWPOSCHANGED</c> message without calling <c>DefWindowProc</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-size
		[MsgParams(typeof(WM_SIZE_WPARAM), typeof(SIZES))]
		WM_SIZE = 0x0005,

		/// <summary>
		/// <para>
		/// Sent to both the window being activated and the window being deactivated. If the windows use the same input queue, the message is
		/// sent synchronously, first to the window procedure of the top-level window being deactivated, then to the window procedure of the
		/// top-level window being activated. If the windows use different input queues, the message is sent asynchronously, so the window is
		/// activated immediately.
		/// </para>
		/// <para>
		/// <code>#define WM_ACTIVATE 0x0006</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The low-order word specifies whether the window is being activated or deactivated. This parameter can be one of the following
		/// values. The high-order word specifies the minimized state of the window being activated or deactivated. A nonzero value indicates
		/// the window is minimized.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>WA_ACTIVE</c> 1</term>
		/// <term>
		/// Activated by some method other than a mouse click (for example, by a call to the <c>SetActiveWindow</c> function or by use of the
		/// keyboard interface to select the window).
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WA_CLICKACTIVE</c> 2</term>
		/// <term>Activated by a mouse click.</term>
		/// </item>
		/// <item>
		/// <term><c>WA_INACTIVE</c> 0</term>
		/// <term>Deactivated.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A handle to the window being activated or deactivated, depending on the value of the wParam parameter. If the low-order word of
		/// wParam is <c>WA_INACTIVE</c>, lParam is the handle to the window being activated. If the low-order word of wParam is
		/// <c>WA_ACTIVE</c> or <c>WA_CLICKACTIVE</c>, lParam is the handle to the window being deactivated. This handle can be <c>NULL</c>.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// If the window is being activated and is not minimized, the <c>DefWindowProc</c> function sets the keyboard focus to the window.
		/// If the window is activated by a mouse click, it also receives a <c>WM_MOUSEACTIVATE</c> message.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-activate
		[MsgParams(typeof(WM_ACTIVATE_WPARAM), typeof(HWND))]
		WM_ACTIVATE = 0x0006,

		/// <summary>
		/// <para>Sent to a window after it has gained the keyboard focus.</para>
		/// <para>
		/// <code>#define WM_SETFOCUS 0x0007</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the window that has lost the keyboard focus. This parameter can be <c>NULL</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// To display a caret, an application should call the appropriate caret functions when it receives the <c>WM_SETFOCUS</c> message.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-setfocus
		[MsgParams(typeof(HWND), null)]
		WM_SETFOCUS = 0x0007,

		/// <summary>
		/// <para>Sent to a window immediately before it loses the keyboard focus.</para>
		/// <para>
		/// <code>#define WM_KILLFOCUS 0x0008</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the window that receives the keyboard focus. This parameter can be <c>NULL</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>If an application is displaying a caret, the caret should be destroyed at this point.</para>
		/// <para>
		/// While processing this message, do not make any function calls that display or activate a window. This causes the thread to yield
		/// control and can cause the application to stop responding to messages. For more information, see Message Deadlocks.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-killfocus
		[MsgParams(typeof(HWND), null)]
		WM_KILLFOCUS = 0x0008,

		/// <summary>
		/// <para>
		/// Sent when an application changes the enabled state of a window. It is sent to the window whose enabled state is changing. This
		/// message is sent before the <c>EnableWindow</c> function returns, but after the enabled state ( <c>WS_DISABLED</c> style
		/// bit) of the window has changed.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_ENABLE 0x000A</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Indicates whether the window has been enabled or disabled. This parameter is <c>TRUE</c> if the window has been enabled or
		/// <c>FALSE</c> if the window has been disabled.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-enable
		[MsgParams(typeof(BOOL), null)]
		WM_ENABLE = 0x000A,

		/// <summary>
		/// <para>
		/// You send the <c>WM_SETREDRAW</c> message to a window to allow changes in that window to be redrawn, or to prevent changes in that
		/// window from being redrawn.
		/// </para>
		/// <para>To send this message, call the <c>SendMessage</c> function with the following parameters.</para>
		/// <para>
		/// <code>SendMessage( (HWND) hWnd, WM_SETREDRAW, (WPARAM) wParam, (LPARAM) lParam );</code>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The redraw state. If this parameter is <c>TRUE</c>, then the content can be redrawn after a change. If this parameter is
		/// <c>FALSE</c>, then the content can't be redrawn after a change.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter isn't used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Your application should return 0 if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This message can be useful if your application must add several items to a list box. Your application can call this message with
		/// wParam set to <c>FALSE</c>, add the items, and then call the message again with wParam set to <c>TRUE</c>. Finally, your
		/// application can call <c>RedrawWindow</c>(hWnd, <c>NULL</c>, <c>NULL</c>, RDW_ERASE | RDW_FRAME | RDW_INVALIDATE |
		/// RDW_ALLCHILDREN) to cause the list box to be repainted.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// You should use <c>RedrawWindow</c> with the specified flags, instead of <c>InvalidateRect</c>, because the former is necessary
		/// for some controls that have nonclient area of their own, or have window styles that cause them to be given a nonclient area (such
		/// as <c>WS_THICKFRAME</c>, <c>WS_BORDER</c>, or <c>WS_EX_CLIENTEDGE</c>). If the control does not have a nonclient area, then
		/// <c>RedrawWindow</c> with these flags will do only as much invalidation as <c>InvalidateRect</c> would.
		/// </para>
		/// </para>
		/// <para>
		/// Passing a <c>WM_SETREDRAW</c> message to the <c>DefWindowProc</c> function removes the <c>WS_VISIBLE</c> style from the window
		/// when wParam is set to <c>FALSE</c>. Although the window content remains visible on screen, the <c>IsWindowVisible</c> function
		/// returns <c>FALSE</c> when called on a window in this state.
		/// </para>
		/// <para>
		/// Passing a <c>WM_SETREDRAW</c> message to the <c>DefWindowProc</c> function adds the <c>WS_VISIBLE</c> style to the window, if not
		/// set, when wParam is set to <c>TRUE</c>. If your application sends the <c>WM_SETREDRAW</c> message with wParam set to <c>TRUE</c>
		/// to a hidden window, then the window becomes visible.
		/// </para>
		/// <para>
		/// <c>Windows 10 and later; Windows Server 2016 and later</c>. The system sets a property named SysSetRedraw on a window whose
		/// window procedure passes <c>WM_SETREDRAW</c> messages to <c>DefWindowProc</c>. You can use the <c>GetProp</c> function to get the
		/// property value when it's available. <c>GetProp</c> returns a non-zero value when redraw is disabled. <c>GetProp</c> will return
		/// zero when redraw is enabled, or when the window property doesn't exist.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/gdi/wm-setredraw
		[MsgParams(typeof(BOOL), null)]
		WM_SETREDRAW = 0x000B,

		/// <summary>
		/// <para>Sets the text of a window.</para>
		/// <para>
		/// <code>#define WM_SETTEXT 0x000C</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a null-terminated string that is the window text.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>
		/// The return value is <c>TRUE</c> if the text is set. It is <c>FALSE</c> (for an edit control), <c>LB_ERRSPACE</c> (for a list
		/// box), or <c>CB_ERRSPACE</c> (for a combo box) if insufficient space is available to set the text in the edit control. It is
		/// <c>CB_ERR</c> if this message is sent to a combo box without an edit control.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>DefWindowProc</c> function sets and displays the window text. For an edit control, the text is the contents of the edit
		/// control. For a combo box, the text is the contents of the edit-control portion of the combo box. For a button, the text is the
		/// button name. For other windows, the text is the window title.
		/// </para>
		/// <para>
		/// This message does not change the current selection in the list box of a combo box. An application should use the
		/// <c>CB_SELECTSTRING</c> message to select the item in a list box that matches the text in the edit control.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-settext
		[MsgParams(null, typeof(string), LResultType = typeof(BOOL))]
		WM_SETTEXT = 0x000C,

		/// <summary>
		/// <para>Copies the text that corresponds to a window into a buffer provided by the caller.</para>
		/// <para>
		/// <code>#define WM_GETTEXT 0x000D</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The maximum number of characters to be copied, including the terminating null character.</para>
		/// <para>
		/// ANSI applications may have the string in the buffer reduced in size (to a minimum of half that of the wParam value) due to
		/// conversion from ANSI to Unicode.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to the buffer that is to receive the text.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>The return value is the number of characters copied, not including the terminating null character.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>DefWindowProc</c> function copies the text associated with the window into the specified buffer and returns the number of
		/// characters copied. Note, for non-text static controls this gives you the text with which the control was originally created, that
		/// is, the ID number. However, it gives you the ID of the non-text static control as originally created. That is, if you
		/// subsequently used a <c>STM_SETIMAGE</c> to change it the original ID would still be returned.
		/// </para>
		/// <para>
		/// For an edit control, the text to be copied is the content of the edit control. For a combo box, the text is the content of the
		/// edit control (or static-text) portion of the combo box. For a button, the text is the button name. For other windows, the text is
		/// the window title. To copy the text of an item in a list box, an application can use the <c>LB_GETTEXT</c> message.
		/// </para>
		/// <para>
		/// When the <c>WM_GETTEXT</c> message is sent to a static control with the <c>SS_ICON</c> style, a handle to the icon will be
		/// returned in the first four bytes of the buffer pointed to by lParam. This is true only if the <c>WM_SETTEXT</c> message has been
		/// used to set the icon.
		/// </para>
		/// <para><c>Rich Edit:</c> If the text to be copied exceeds 64K, use either the <c>EM_STREAMOUT</c> or <c>EM_GETSELTEXT</c> message.</para>
		/// <para>
		/// Sending a <c>WM_GETTEXT</c> message to a non-text static control, such as a static bitmap or static icon control, does not return
		/// a string value. Instead, it returns zero. In addition, in early versions of Windows, applications could send a <c>WM_GETTEXT</c>
		/// message to a non-text static control to retrieve the control's ID. To retrieve a control's ID, applications can use
		/// <c>GetWindowLong</c> passing <c>GWL_ID</c> as the index value or <c>GetWindowLongPtr</c> using <c>GWLP_ID</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-gettext
		[MsgParams(typeof(uint), typeof(StringBuilder))]
		WM_GETTEXT = 0x000D,

		/// <summary>
		/// <para>Determines the length, in characters, of the text associated with a window.</para>
		/// <para>
		/// <code>#define WM_GETTEXTLENGTH 0x000E</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>The return value is the length of the text in characters, not including the terminating null character.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// For an edit control, the text to be copied is the content of the edit control. For a combo box, the text is the content of the
		/// edit control (or static-text) portion of the combo box. For a button, the text is the button name. For other windows, the text is
		/// the window title. To determine the length of an item in a list box, an application can use the <c>LB_GETTEXTLEN</c> message.
		/// </para>
		/// <para>
		/// When the <c>WM_GETTEXTLENGTH</c> message is sent, the <c>DefWindowProc</c> function returns the length, in characters, of the
		/// text. Under certain conditions, the <c>DefWindowProc</c> function returns a value that is larger than the actual length of the
		/// text. This occurs with certain mixtures of ANSI and Unicode, and is due to the system allowing for the possible existence of
		/// double-byte character set (DBCS) characters within the text. The return value, however, will always be at least as large as the
		/// actual length of the text; you can thus always use it to guide buffer allocation. This behavior can occur when an application
		/// uses both ANSI functions and common dialogs, which use Unicode.
		/// </para>
		/// <para>
		/// To obtain the exact length of the text, use the <c>WM_GETTEXT</c>, <c>LB_GETTEXT</c>, or <c>CB_GETLBTEXT</c> messages, or the
		/// <c>GetWindowText</c> function.
		/// </para>
		/// <para>
		/// Sending a <c>WM_GETTEXTLENGTH</c> message to a non-text static control, such as a static bitmap or static icon controlc, does not
		/// return a string value. Instead, it returns zero.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-gettextlength
		[MsgParams()]
		WM_GETTEXTLENGTH = 0x000E,

		/// <summary>
		/// <para>
		/// The <c>WM_PAINT</c> message is sent when the system or another application makes a request to paint a portion of an application's
		/// window. The message is sent when the <c>UpdateWindow</c> or <c>RedrawWindow</c> function is called, or by the
		/// <c>DispatchMessage</c> function when the application obtains a <c>WM_PAINT</c> message by using the <c>GetMessage</c> or
		/// <c>PeekMessage</c> function.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application returns zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>WM_PAINT</c> message is generated by the system and should not be sent by an application. To force a window to draw into a
		/// specific device context, use the <c>WM_PRINT</c> or <c>WM_PRINTCLIENT</c> message. Note that this requires the target window to
		/// support the <c>WM_PRINTCLIENT</c> message. Most common controls support the <c>WM_PRINTCLIENT</c> message.
		/// </para>
		/// <para>
		/// The <c>DefWindowProc</c> function validates the update region. The function may also send the <c>WM_NCPAINT</c> message to the
		/// window procedure if the window frame must be painted and send the <c>WM_ERASEBKGND</c> message if the window background must be erased.
		/// </para>
		/// <para>
		/// The system sends this message when there are no other messages in the application's message queue. <c>DispatchMessage</c>
		/// determines where to send the message; <c>GetMessage</c> determines which message to dispatch. <c>GetMessage</c> returns the
		/// <c>WM_PAINT</c> message when there are no other messages in the application's message queue, and <c>DispatchMessage</c> sends the
		/// message to the appropriate window procedure.
		/// </para>
		/// <para>
		/// A window may receive internal paint messages as a result of calling <c>RedrawWindow</c> with the RDW_INTERNALPAINT flag set. In
		/// this case, the window may not have an update region. An application may call the <c>GetUpdateRect</c> function to determine
		/// whether the window has an update region. If <c>GetUpdateRect</c> returns zero, the application need not call the
		/// <c>BeginPaint</c> and <c>EndPaint</c> functions.
		/// </para>
		/// <para>
		/// An application must check for any necessary internal painting by looking at its internal data structures for each <c>WM_PAINT</c>
		/// message, because a <c>WM_PAINT</c> message may have been caused by both a non-NULL update region and a call to
		/// <c>RedrawWindow</c> with the RDW_INTERNALPAINT flag set.
		/// </para>
		/// <para>
		/// The system sends an internal <c>WM_PAINT</c> message only once. After an internal <c>WM_PAINT</c> message is returned from
		/// <c>GetMessage</c> or <c>PeekMessage</c> or is sent to a window by <c>UpdateWindow</c>, the system does not post or send further
		/// <c>WM_PAINT</c> messages until the window is invalidated or until <c>RedrawWindow</c> is called again with the RDW_INTERNALPAINT
		/// flag set.
		/// </para>
		/// <para>
		/// For some common controls, the default <c>WM_PAINT</c> message processing checks the wParam parameter. If wParam is non-NULL, the
		/// control assumes that the value is an HDC and paints using that device context.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/gdi/wm-paint
		[MsgParams()]
		WM_PAINT = 0x000F,

		/// <summary>
		/// <para>Sent as a signal that a window or an application should terminate.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_CLOSE 0x0010</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// An application can prompt the user for confirmation, prior to destroying a window, by processing the <c>WM_CLOSE</c> message and
		/// calling the <c>DestroyWindow</c> function only if the user confirms the choice.
		/// </para>
		/// <para>By default, the <c>DefWindowProc</c> function calls the <c>DestroyWindow</c> function to destroy the window.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-close
		[MsgParams()]
		WM_CLOSE = 0x0010,

		/// <summary>
		/// <para>
		/// The <c>WM_QUERYENDSESSION</c> message is sent when the user chooses to end the session or when an application calls one of the
		/// system shutdown functions. If any application returns zero, the session is not ended. The system stops sending
		/// <c>WM_QUERYENDSESSION</c> messages as soon as one application returns zero.
		/// </para>
		/// <para>
		/// After processing this message, the system sends the <c>WM_ENDSESSION</c> message with the wParam parameter set to the results of
		/// the <c>WM_QUERYENDSESSION</c> message.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, // handle to window UINT uMsg, // message identifier WPARAM wParam, // not used LPARAM lParam // logoff option );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hwnd</em></para>
		/// <para>A handle to the window.</para>
		/// <para><em>uMsg</em></para>
		/// <para>The <c>WM_QUERYENDSESSION</c> identifier.</para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is reserved for future use.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// This parameter can be one or more of the following values. If this parameter is 0, the system is shutting down or restarting (it
		/// is not possible to determine which event is occurring).
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>ENDSESSION_CLOSEAPP</c> 0x00000001</term>
		/// <term>
		/// The application is using a file that must be replaced, the system is being serviced, or system resources are exhausted. For more
		/// information, see Guidelines for Applications.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>ENDSESSION_CRITICAL</c> 0x40000000</term>
		/// <term>The application is forced to shut down.</term>
		/// </item>
		/// <item>
		/// <term><c>ENDSESSION_LOGOFF</c> 0x80000000</term>
		/// <term>The user is logging off. For more information, see Logging Off.</term>
		/// </item>
		/// </list>
		/// <para>Note that this parameter is a bit mask. To test for this value, use a bit-wise operation; do not test for equality.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Applications should respect the user's intentions and return <c>TRUE</c>. By default, the <c>DefWindowProc</c> function returns
		/// <c>TRUE</c> for this message.
		/// </para>
		/// <para>
		/// If shutting down would corrupt the system or media that is being burned, the application can return <c>FALSE</c>. However, it is
		/// good practice to respect the user's actions.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When an application returns <c>TRUE</c> for this message, it receives the <c>WM_ENDSESSION</c> message, regardless of how the
		/// other applications respond to the <c>WM_QUERYENDSESSION</c> message. Each application should return <c>TRUE</c> or <c>FALSE</c>
		/// immediately upon receiving this message, and defer any cleanup operations until it receives the <c>WM_ENDSESSION</c> message.
		/// </para>
		/// <para>
		/// Applications can display a user interface prompting the user for information at shutdown, however it is not recommended. After
		/// five seconds, the system displays information about the applications that are preventing shutdown and allows the user to
		/// terminate them. For example, Windows XP displays a dialog box, while Windows Vista displays a full screen with additional
		/// information about the applications blocking shutdown. If your application must block or postpone system shutdown, use the
		/// <c>ShutdownBlockReasonCreate</c> function. For more information, see Shutdown Changes for Windows Vista.
		/// </para>
		/// <para>Console applications can use the <c>SetConsoleCtrlHandler</c> function to receive shutdown notification.</para>
		/// <para>
		/// Service applications can use the <c>RegisterServiceCtrlHandlerEx</c> function to receive shutdown notifications in a handler routine.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shutdown/wm-queryendsession
		[MsgParams(null, typeof(ENDSESSION), LResultType = typeof(BOOL))]
		WM_QUERYENDSESSION = 0x0011,

		/// <summary>
		/// <para>Sent to an icon when the user requests that the window be restored to its previous size and position.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_QUERYOPEN 0x0013</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>
		/// If the icon can be opened, an application that processes this message should return <c>TRUE</c>; otherwise, it should return
		/// <c>FALSE</c> to prevent the icon from being opened.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>By default, the <c>DefWindowProc</c> function returns <c>TRUE</c>.</para>
		/// <para>
		/// While processing this message, the application should not perform any action that would cause an activation or focus change (for
		/// example, creating a dialog box).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-queryopen
		[MsgParams(LResultType = typeof(BOOL))]
		WM_QUERYOPEN = 0x0013,

		/// <summary>
		/// <para>
		/// The <c>WM_ENDSESSION</c> message is sent to an application after the system processes the results of the
		/// <c>WM_QUERYENDSESSION</c> message. The <c>WM_ENDSESSION</c> message informs the application whether the session is ending.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, // handle to window UINT uMsg, // message identifier WPARAM wParam, // end-session option LPARAM lParam // logoff option );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hwnd</em></para>
		/// <para>A handle to the window.</para>
		/// <para><em>uMsg</em></para>
		/// <para>The <c>WM_ENDSESSION</c> identifier.</para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// If the session is being ended, this parameter is <c>TRUE</c>; the session can end any time after all applications have returned
		/// from processing this message. Otherwise, it is <c>FALSE</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// This parameter can be one or more of the following values. If this parameter is 0, the system is shutting down or restarting (it
		/// is not possible to determine which event is occurring).
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>ENDSESSION_CLOSEAPP</c> 0x1</term>
		/// <term>
		/// If <c>wParam</c> is <c>TRUE</c>, the application must shut down. Any data should be saved automatically without prompting the
		/// user (for more information, see Remarks). The Restart Manager sends this message when the application is using a file that needs
		/// to be replaced, when it must service the system, or when system resources are exhausted. The application will be restarted if it
		/// has registered for restart using the <c>RegisterApplicationRestart</c> function. For more information, see Guidelines for
		/// Applications. If <c>wParam</c> is <c>FALSE</c>, the application should not shut down.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>ENDSESSION_CRITICAL</c> 0x40000000</term>
		/// <term>The application is forced to shut down.</term>
		/// </item>
		/// <item>
		/// <term><c>ENDSESSION_LOGOFF</c> 0x80000000</term>
		/// <term>The user is logging off. For more information, see Logging Off.</term>
		/// </item>
		/// </list>
		/// <para>Note that this parameter is a bit mask. To test for this value, use a bit-wise operation; do not test for equality.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Applications that have unsaved data could save the data to a temporary location and restore it the next time the application
		/// starts. It is recommended that applications save their data and state frequently; for example, automatically save data between
		/// save operations initiated by the user to reduce the amount of data to be saved at shutdown.
		/// </para>
		/// <para>The application need not call the <c>DestroyWindow</c> or <c>PostQuitMessage</c> function when the session is ending.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shutdown/wm-endsession
		[MsgParams(typeof(BOOL), typeof(ENDSESSION))]
		WM_ENDSESSION = 0x0016,

		/// <summary>
		/// <para>
		/// Indicates a request to terminate an application, and is generated when the application calls the <c>PostQuitMessage</c> function.
		/// This message causes the <c>GetMessage</c> function to return zero.
		/// </para>
		/// <para>
		/// <code>#define WM_QUIT 0x0012</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The exit code given in the <c>PostQuitMessage</c> function.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>
		/// This message does not have a return value because it causes the message loop to terminate before the message is sent to the
		/// application's window procedure.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>WM_QUIT</c> message is not associated with a window and therefore will never be received through a window's window
		/// procedure. It is retrieved only by the <c>GetMessage</c> or <c>PeekMessage</c> functions.
		/// </para>
		/// <para>Do not post the <c>WM_QUIT</c> message using the <c>PostMessage</c> function; use <c>PostQuitMessage</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-quit
		[MsgParams(typeof(BOOL), typeof(ENDSESSION), LResultType = null)]
		WM_QUIT = 0x0012,

		/// <summary>
		/// <para>
		/// Sent when the window background must be erased (for example, when a window is resized). The message is sent to prepare an
		/// invalidated portion of a window for painting.
		/// </para>
		/// <para>
		/// <code>#define WM_ERASEBKGND 0x0014</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the device context.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>An application should return nonzero if it erases the background; otherwise, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>DefWindowProc</c> function erases the background by using the class background brush specified by the <c>hbrBackground</c>
		/// member of the <c>WNDCLASS</c> structure. If <c>hbrBackground</c> is <c>NULL</c>, the application should process the
		/// <c>WM_ERASEBKGND</c> message and erase the background.
		/// </para>
		/// <para>
		/// An application should return nonzero in response to <c>WM_ERASEBKGND</c> if it processes the message and erases the background;
		/// this indicates that no further erasing is required. If the application returns zero, the window will remain marked for erasing.
		/// (Typically, this indicates that the <c>fErase</c> member of the <c>PAINTSTRUCT</c> structure will be <c>TRUE</c>.)
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-erasebkgnd
		[MsgParams(typeof(HDC), null)]
		WM_ERASEBKGND = 0x0014,

		/// <summary>
		/// <para>The <c>WM_SYSCOLORCHANGE</c> message is sent to all top-level windows when a change is made to a system color setting.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// </summary>
		/// <remarks>
		/// <para>The system sends a <c>WM_PAINT</c> message to any window that is affected by a system color change.</para>
		/// <para>
		/// Applications that have brushes using the existing system colors should delete those brushes and re-create them using the new
		/// system colors.
		/// </para>
		/// <para>
		/// Top level windows that use common controls must forward the <c>WM_SYSCOLORCHANGE</c> message to the controls; otherwise, the
		/// controls will not be notified of the color change. This ensures that the colors used by your common controls are consistent with
		/// those used by other user interface objects. For example, a toolbar control uses the "3D Objects" color to draw its buttons. If
		/// the user changes the 3D Objects color but the <c>WM_SYSCOLORCHANGE</c> message is not forwarded to the toolbar, the toolbar
		/// buttons will remain in their original color while the color of other buttons in the system changes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/gdi/wm-syscolorchange
		[MsgParams(LResultType = null)]
		WM_SYSCOLORCHANGE = 0x0015,

		/// <summary>
		/// <para>Sent to a window when the window is about to be hidden or shown.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_SHOWWINDOW 0x0018</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Indicates whether a window is being shown. If wParam is <c>TRUE</c>, the window is being shown. If wParam is <c>FALSE</c>, the
		/// window is being hidden.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The status of the window being shown. If lParam is zero, the message was sent because of a call to the <c>ShowWindow</c>
		/// function; otherwise, lParam is one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SW_OTHERUNZOOM</c> 4</term>
		/// <term>The window is being uncovered because a maximize window was restored or minimized.</term>
		/// </item>
		/// <item>
		/// <term><c>SW_OTHERZOOM</c> 2</term>
		/// <term>The window is being covered by another window that has been maximized.</term>
		/// </item>
		/// <item>
		/// <term><c>SW_PARENTCLOSING</c> 1</term>
		/// <term>The window's owner window is being minimized.</term>
		/// </item>
		/// <item>
		/// <term><c>SW_PARENTOPENING</c> 3</term>
		/// <term>The window's owner window is being restored.</term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>DefWindowProc</c> function hides or shows the window, as specified by the message. If a window has the <c>WS_VISIBLE</c>
		/// style when it is created, the window receives this message after it is created, but before it is displayed. A window also
		/// receives this message when its visibility state is changed by the <c>ShowWindow</c> or <c>ShowOwnedPopups</c> function.
		/// </para>
		/// <para>The <c>WM_SHOWWINDOW</c> message is not sent under the following circumstances:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>When a top-level, overlapped window is created with the <c>WS_MAXIMIZE</c> or <c>WS_MINIMIZE</c> style.</term>
		/// </item>
		/// <item>
		/// <term>When the <c>SW_SHOWNORMAL</c> flag is specified in the call to the <c>ShowWindow</c> function.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-showwindow
		[MsgParams(typeof(BOOL), typeof(WM_SHOWWINDOW_LPARAM))]
		WM_SHOWWINDOW = 0x0018,

		/// <summary>
		/// <para>
		/// An application sends the <c>WM_WININICHANGE</c> message to all top-level windows after making a change to the WIN.INI file. The
		/// <c>SystemParametersInfo</c> function sends this message after an application uses the function to change a setting in WIN.INI.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The <c>WM_WININICHANGE</c> message is provided only for compatibility with earlier versions of the system. Applications should
		/// use the <c>WM_SETTINGCHANGE</c> message.
		/// </para>
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_WININICHANGE 0x001A</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a string containing the name of the system parameter that was changed. For example, this string can be the name of a
		/// registry key or the name of a section in the Win.ini file. This parameter is not particularly useful in determining which system
		/// parameter changed. For example, when the string is a registry name, it typically indicates only the leaf node in the registry,
		/// not the whole path. In addition, some applications send this message with lParam set to <c>NULL</c>. In general, when you receive
		/// this message, you should check and reload any system parameter settings that are used by your application.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If you process this message, return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To send the <c>WM_WININICHANGE</c> message to all top-level windows, use the <c>SendMessage</c> function with the hWnd parameter
		/// set to <c>HWND_BROADCAST</c>.
		/// </para>
		/// <para>
		/// Calls to functions that change WIN.INI may be mapped to the registry instead. This mapping occurs when WIN.INI and the section
		/// being changed are specified in the registry under the following key:
		/// </para>
		/// <para><c>HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\IniFileMapping</c></para>
		/// <para>The change in the storage location has no effect on the behavior of this message.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-wininichange
		[MsgParams(null, typeof(string))]
		WM_WININICHANGE = 0x001A,

		/// <summary>
		/// <para>
		/// A message that is sent to all top-level windows when the <c>SystemParametersInfo</c> function changes a system-wide setting or
		/// when policy settings have changed.
		/// </para>
		/// <para>
		/// Applications should send <c>WM_SETTINGCHANGE</c> to all top-level windows when they make changes to system parameters. (This
		/// message cannot be sent directly to a window.) To send the <c>WM_SETTINGCHANGE</c> message to all top-level windows, use the
		/// <c>SendMessageTimeout</c> function with the hwnd parameter set to <c>HWND_BROADCAST</c>.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_WININICHANGE 0x001A #define WM_SETTINGCHANGE WM_WININICHANGE</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// When the system sends this message as a result of a <c>SystemParametersInfo</c> call, the wParam parameter is the value of the
		/// uiAction parameter passed to the <c>SystemParametersInfo</c> function. For a list of values, see <c>SystemParametersInfo</c>.
		/// </para>
		/// <para>
		/// When the system sends this message as a result of a change in policy settings, this parameter indicates the type of policy that
		/// was applied. This value is 1 if computer policy was applied or zero if user policy was applied.
		/// </para>
		/// <para>When the system sends this message as a result of a change in locale settings, this parameter is zero.</para>
		/// <para>When an application sends this message, this parameter must be <c>NULL</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// When the system sends this message as a result of a <c>SystemParametersInfo</c> call, lParam is a pointer to a string that
		/// indicates the area containing the system parameter that was changed. This parameter does not usually indicate which specific
		/// system parameter changed. (Note that some applications send this message with lParam set to <c>NULL</c>.) In general, when you
		/// receive this message, you should check and reload any system parameter settings that are used by your application.
		/// </para>
		/// <para>
		/// This string can be the name of a registry key or the name of a section in the Win.ini file. When the string is a registry name,
		/// it typically indicates only the leaf node in the registry, not the full path.
		/// </para>
		/// <para>When the system sends this message as a result of a change in policy settings, this parameter points to the string "Policy".</para>
		/// <para>When the system sends this message as a result of a change in locale settings, this parameter points to the string "intl".</para>
		/// <para>
		/// To effect a change in the environment variables for the system or the user, broadcast this message with lParam set to the string "Environment".
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If you process this message, return zero.</para>
		/// </summary>
		/// <remarks>
		/// The lParam parameter indicates which system metric has changed, for example, "ConvertibleSlateMode" if the CONVERTIBLESLATEMODE
		/// indicator was toggled or "SystemDockMode" if the DOCKED indicator was toggled.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-settingchange
		[MsgParams(null, typeof(string))]
		WM_SETTINGCHANGE = WM_WININICHANGE,

		/// <summary>
		/// <para>The <c>WM_DEVMODECHANGE</c> message is sent to all top-level windows whenever the user changes device-mode settings.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hwnd</em></para>
		/// <para>A handle to a window.</para>
		/// <para><em>uMsg</em></para>
		/// <para>WM_DEVMODECHANGE</para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a string that specifies the device name.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// This message cannot be sent directly to a window. To send the <c>WM_DEVMODECHANGE</c> message to all top-level windows, use the
		/// <c>SendMessageTimeout</c> function with the hWnd parameter set to HWND_BROADCAST.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/gdi/wm-devmodechange
		[MsgParams(null, typeof(string))]
		WM_DEVMODECHANGE = 0x001B,

		/// <summary>
		/// <para>
		/// Sent when a window belonging to a different application than the active window is about to be activated. The message is sent to
		/// the application whose window is being activated and to the application whose window is being deactivated.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_ACTIVATEAPP 0x001C</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Indicates whether the window is being activated or deactivated. This parameter is <c>TRUE</c> if the window is being activated;
		/// it is <c>FALSE</c> if the window is being deactivated.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The thread identifier. If the wParam parameter is <c>TRUE</c>, lParam is the identifier of the thread that owns the window being
		/// deactivated. If wParam is <c>FALSE</c>, lParam is the identifier of the thread that owns the window being activated.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-activateapp
		[MsgParams(typeof(BOOL), typeof(uint))]
		WM_ACTIVATEAPP = 0x001C,

		/// <summary>
		/// <para>
		/// An application sends the <c>WM_FONTCHANGE</c> message to all top-level windows in the system after changing the pool of font resources.
		/// </para>
		/// <para>To send this message, call the <c>SendMessage</c> function with the following parameters.</para>
		/// <para>
		/// <code>SendMessage( (HWND) hWnd, WM_FONTCHANGE, (WPARAM) wParam, (LPARAM) lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// An application that adds or removes fonts from the system (for example, by using the <c>AddFontResource</c> or
		/// <c>RemoveFontResource</c> function) should send this message to all top-level windows.
		/// </para>
		/// <para>
		/// To send the <c>WM_FONTCHANGE</c> message to all top-level windows, an application can call the <c>SendMessage</c> function with
		/// the hwnd parameter set to HWND_BROADCAST.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/gdi/wm-fontchange
		[MsgParams(LResultType = null)]
		WM_FONTCHANGE = 0x001D,

		/// <summary>
		/// <para>A message that is sent whenever there is a change in the system time.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, // handle to window UINT uMsg, // message identifier WPARAM wParam, // not used; must be zero LPARAM lParam // not used; must be zero );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hwnd</em></para>
		/// <para>A handle to window.</para>
		/// <para><em>uMsg</em></para>
		/// <para><c>WM_TIMECHANGE</c> identifier.</para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// An application should not broadcast this message, because the system will broadcast this message when the application changes the
		/// system time.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/sysinfo/wm-timechange
		[MsgParams(LResultType = null)]
		WM_TIMECHANGE = 0x001E,

		/// <summary>
		/// <para>
		/// Sent to cancel certain modes, such as mouse capture. For example, the system sends this message to the active window when a
		/// dialog box or message box is displayed. Certain functions also send this message explicitly to the specified window regardless of
		/// whether it is the active window. For example, the <c>EnableWindow</c> function sends this message when disabling the specified window.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_CANCELMODE 0x001F</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// When the <c>WM_CANCELMODE</c> message is sent, the <c>DefWindowProc</c> function cancels internal processing of standard scroll
		/// bar input, cancels internal menu processing, and releases the mouse capture.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-cancelmode
		[MsgParams()]
		WM_CANCELMODE = 0x001F,

		/// <summary>
		/// <para>Sent to a window if the mouse causes the cursor to move within a window and mouse input is not captured.</para>
		/// <para>
		/// <code>#define WM_SETCURSOR 0x0020</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the window that contains the cursor.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word of lParam specifies the hit-test result for the cursor position. See the return values for WM_NCHITTEST for
		/// possible values.
		/// </para>
		/// <para>
		/// The high-order word of lParam specifies the mouse window message which triggered this event, such as WM_MOUSEMOVE. When the
		/// window enters menu mode, this value is zero.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return <c>TRUE</c> to halt further processing or <c>FALSE</c> to continue.</para>
		/// </summary>
		/// <remarks>
		/// The <c>DefWindowProc</c> function passes the <c>WM_SETCURSOR</c> message to a parent window before processing. If the parent
		/// window returns <c>TRUE</c>, further processing is halted. Passing the message to a window's parent window gives the parent window
		/// control over the cursor's setting in a child window. The <c>DefWindowProc</c> function also uses this message to set the cursor
		/// to an arrow if it is not in the client area, or to the registered class cursor if it is in the client area. If the low-order word
		/// of the lParam parameter is <c>HTERROR</c> and the high-order word of lParam specifies that one of the mouse buttons is pressed,
		/// <c>DefWindowProc</c> calls the <c>MessageBeep</c> function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-setcursor
		[MsgParams(typeof(HWND), typeof(WM_SETCURSOR_LPARAM), LResultType = typeof(BOOL))]
		WM_SETCURSOR = 0x0020,

		/// <summary>
		/// <para>
		/// Sent when the cursor is in an inactive window and the user presses a mouse button. The parent window receives this message only
		/// if the child window passes it to the <c>DefWindowProc</c> function.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_MOUSEACTIVATE 0x0021</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the top-level parent window of the window being activated.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the hit-test value returned by the <c>DefWindowProc</c> function as a result of processing the
		/// <c>WM_NCHITTEST</c> message. For a list of hit-test values, see <c>WM_NCHITTEST</c>.
		/// </para>
		/// <para>
		/// The high-order word specifies the identifier of the mouse message generated when the user pressed a mouse button. The mouse
		/// message is either discarded or posted to the window, depending on the return value.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value specifies whether the window should be activated and whether the identifier of the mouse message should be
		/// discarded. It must be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>MA_ACTIVATE</c> 1</term>
		/// <term>Activates the window, and does not discard the mouse message.</term>
		/// </item>
		/// <item>
		/// <term><c>MA_ACTIVATEANDEAT</c> 2</term>
		/// <term>Activates the window, and discards the mouse message.</term>
		/// </item>
		/// <item>
		/// <term><c>MA_NOACTIVATE</c> 3</term>
		/// <term>Does not activate the window, and does not discard the mouse message.</term>
		/// </item>
		/// <item>
		/// <term><c>MA_NOACTIVATEANDEAT</c> 4</term>
		/// <term>Does not activate the window, but discards the mouse message.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// The <c>DefWindowProc</c> function passes the message to a child window's parent window before any processing occurs. The parent
		/// window determines whether to activate the child window. If it activates the child window, the parent window should return
		/// <c>MA_NOACTIVATE</c> or <c>MA_NOACTIVATEANDEAT</c> to prevent the system from processing the message further.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mouseactivate
		[MsgParams(typeof(HWND), typeof(WM_SETCURSOR_LPARAM), LResultType = typeof(WM_MOUSEACTIVATE_RETURN))]
		WM_MOUSEACTIVATE = 0x0021,

		/// <summary>
		/// <para>Sent to a child window when the user clicks the window's title bar or when the window is activated, moved, or sized.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_CHILDACTIVATE 0x0022</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-childactivate
		[MsgParams()]
		WM_CHILDACTIVATE = 0x0022,

		/// <summary>
		/// <para>
		/// Sent by a computer-based training (CBT) application to separate user-input messages from other messages sent through the
		/// <c>WH_JOURNALPLAYBACK</c> procedure.
		/// </para>
		/// <para>
		/// <code>#define WM_QUEUESYNC 0x0023</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>void</c></para>
		/// <para>A CBT application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Whenever a CBT application uses the <c>WH_JOURNALPLAYBACK</c> procedure, the first and last messages are <c>WM_QUEUESYNC</c>.
		/// This allows the CBT application to intercept and examine user-initiated messages without doing so for events that it sends.
		/// </para>
		/// <para>If an application specifies a <c>NULL</c> window handle, the message is posted to the message queue of the active window.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-queuesync
		[MsgParams()]
		WM_QUEUESYNC = 0x0023,

		/// <summary>
		/// <para>
		/// Sent to a window when the size or position of the window is about to change. An application can use this message to override the
		/// window's default maximized size and position, or its default minimum or maximum tracking size.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_GETMINMAXINFO 0x0024</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>MINMAXINFO</c> structure that contains the default maximized position and dimensions, and the default minimum
		/// and maximum tracking sizes. An application can override the defaults by setting the members of this structure.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// The maximum tracking size is the largest window size that can be produced by using the borders to size the window. The minimum
		/// tracking size is the smallest window size that can be produced by using the borders to size the window.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-getminmaxinfo
		[MsgParams(null, typeof(MINMAXINFO?))]
		WM_GETMINMAXINFO = 0x0024,

		/// <summary>
		/// <para>
		/// The WM_PAINTICON message is sent to a minimized window when the icon is to be painted but only if the application is written for
		/// Windows 3.x. A window receives this message only if a class icon is defined for the window; otherwise, WM_PAINT is sent instead.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_PAINTICON 0x0026</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// The DefWindowProc function draws the class icon. For compatibility with Windows 3.x, wParam is TRUE. However, this value has no significance.
		/// </remarks>
		[MsgParams()]
		WM_PAINTICON = 0x0026,

		/// <summary>
		/// <para>
		/// The WM_ICONERASEBKGND message is sent to a minimized window when the background of the icon must be filled before painting the
		/// icon. A window receives this message only if a class icon is defined for the window; otherwise, WM_ERASEBKGND is sent.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_ICONERASEBKGND 0x0027</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Type: HDC. Identifies the device context of the icon.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>The DefWindowProc function fills the icon background with the class background brush of the parent window.</remarks>
		[MsgParams(typeof(HDC), null)]
		WM_ICONERASEBKGND = 0x0027,

		/// <summary>
		/// <para>Sent to a dialog box procedure to set the keyboard focus to a different control in the dialog box.</para>
		/// <para>
		/// <code>#define WM_NEXTDLGCTL 0x0028</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// If lParam is <c>TRUE</c>, this parameter identifies the control that receives the focus. If lParam is <c>FALSE</c>, this
		/// parameter indicates whether the next or previous control with the <c>WS_TABSTOP</c> style receives the focus. If wParam is zero,
		/// the next control receives the focus; otherwise, the previous control with the <c>WS_TABSTOP</c> style receives the focus.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word indicates how the system uses wParam. If the low-order word is <c>TRUE</c>, wParam is a handle associated with
		/// the control that receives the focus; otherwise, wParam is a flag that indicates whether the next or previous control with the
		/// <c>WS_TABSTOP</c> style receives the focus.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This message performs additional dialog box management operations beyond those performed by the <c>SetFocus</c> function
		/// <c>WM_NEXTDLGCTL</c> updates the default pushbutton border, sets the default control identifier, and automatically selects the
		/// text of an edit control (if the target window is an edit control).
		/// </para>
		/// <para>
		/// Do not use the <c>SendMessage</c> function to send a <c>WM_NEXTDLGCTL</c> message if your application will concurrently process
		/// other messages that set the focus. Use the <c>PostMessage</c> function instead.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dlgbox/wm-nextdlgctl
		[MsgParams(typeof(BOOL), typeof(BOOL))]
		WM_NEXTDLGCTL = 0x0028,

		/// <summary>
		/// <para>
		/// The <c>WM_SPOOLERSTATUS</c> message is sent from Print Manager whenever a job is added to or removed from the Print Manager queue.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The PR_JOBSTATUS flag.</para>
		/// <para><em>lParam</em></para>
		/// <para>The low-order word specifies the number of jobs remaining in the Print Manager queue.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This message is for informational purposes only. This message is advisory and does not have guaranteed delivery semantics.
		/// Applications should not assume that they will receive a WM_SPOOLERSTATUS message for every change in spooler status.
		/// </para>
		/// <para>
		/// The WM_SPOOLERSTATUS message is not supported after Windows XP. To be notified of changes to the print queue status, you can use
		/// <c>FindFirstPrinterChangeNotification</c> and <c>FindNextPrinterChangeNotification</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/printdocs/wm-spoolerstatus
		[MsgParams(typeof(int), typeof(uint))]
		WM_SPOOLERSTATUS = 0x002A,

		/// <summary>
		/// <para>
		/// Sent to the parent window of an owner-drawn button, combo box, list box, or menu when a visual aspect of the button, combo box,
		/// list box, or menu has changed.
		/// </para>
		/// <para>A window receives this message through its WindowProc function.</para>
		/// <para>
		/// <code>WM_DRAWITEM WPARAM wParam; LPARAM lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Specifies the identifier of the control that sent the <c>WM_DRAWITEM</c> message. If the message was sent by a menu, this
		/// parameter is zero.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>DRAWITEMSTRUCT</c> structure containing information about the item to be drawn and the type of drawing required.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return <c>TRUE</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>By default, the <c>DefWindowProc</c> function draws the focus rectangle for an owner-drawn list box item.</para>
		/// <para>
		/// The itemAction member of the <c>DRAWITEMSTRUCT</c> structure specifies the drawing operation that an application should perform.
		/// </para>
		/// <para>
		/// Before returning from processing this message, an application should ensure that the device context identified by the hDC member
		/// of the <c>DRAWITEMSTRUCT</c> structure is in the default state.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/wm-drawitem
		[MsgParams(typeof(uint), typeof(DRAWITEMSTRUCT?), LResultType = typeof(BOOL))]
		WM_DRAWITEM = 0x002B,

		/// <summary>
		/// <para>Sent to the owner window of a combo box, list box, list-view control, or menu item when the control or menu is created.</para>
		/// <para>A window receives this message through its WindowProc function.</para>
		/// <para>
		/// <code>WM_MEASUREITEM WPARAM wParam; LPARAM lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Contains the value of the <c>CtlID</c> member of the <c>MEASUREITEMSTRUCT</c> structure pointed to by the lParam parameter. This
		/// value identifies the control that sent the <c>WM_MEASUREITEM</c> message. If the message was sent by a menu, this parameter is
		/// zero. If the value is nonzero or the value is zero and the value of the <c>CtlType</c> member of the <c>MEASUREITEMSTRUCT</c>
		/// pointed to by lParam is not <c>ODT_MENU</c>, the message was sent by a combo box or by a list box. If the value is nonzero, and
		/// the value of the <c>itemID</c> member of the <c>MEASUREITEMSTRUCT</c> pointed to by lParam is (UINT) 1, the message was sent by a
		/// combo edit field.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>MEASUREITEMSTRUCT</c> structure that contains the dimensions of the owner-drawn control or menu item.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return <c>TRUE</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When the owner window receives the <c>WM_MEASUREITEM</c> message, the owner fills in the <c>MEASUREITEMSTRUCT</c> structure
		/// pointed to by the lParam parameter of the message and returns; this informs the system of the dimensions of the control. If a
		/// list box or combo box is created with the <c>LBS_OWNERDRAWVARIABLE</c> or <c>CBS_OWNERDRAWVARIABLE</c> style, this message is
		/// sent to the owner for each item in the control; otherwise, this message is sent once.
		/// </para>
		/// <para>
		/// The system sends the <c>WM_MEASUREITEM</c> message to the owner window of combo boxes and list boxes created with the
		/// OWNERDRAWFIXED style before sending the <c>WM_INITDIALOG</c> message. As a result, when the owner receives this message, the
		/// system has not yet determined the height and width of the font used in the control; function calls and calculations requiring
		/// these values should occur in the main function of the application or library.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/wm-measureitem
		[MsgParams(typeof(uint), typeof(MEASUREITEMSTRUCT?), LResultType = typeof(BOOL))]
		WM_MEASUREITEM = 0x002C,

		/// <summary>
		/// <para>
		/// Sent to the owner of a list box or combo box when the list box or combo box is destroyed or when items are removed by the
		/// <c>LB_DELETESTRING</c>, <c>LB_RESETCONTENT</c>, <c>CB_DELETESTRING</c>, or <c>CB_RESETCONTENT</c> message. The system sends a
		/// <c>WM_DELETEITEM</c> message for each deleted item. The system sends the <c>WM_DELETEITEM</c> message for any deleted list box or
		/// combo box item with nonzero item data.
		/// </para>
		/// <para>
		/// <code>WM_DELETEITEM WPARAM wParam; LPARAM lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the identifier of the control that sent the <c>WM_DELETEITEM</c> message.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>DELETEITEMSTRUCT</c> structure that contains information about the item deleted from a list box.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return <c>TRUE</c> if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Microsoft Windows NT and later: Windows sends a <c>WM_DELETEITEM</c> message only for items deleted from an owner-drawn list box
		/// (with the <c>LBS_OWNERDRAWFIXED</c> or <c>LBS_OWNERDRAWVARIABLE</c> style) or owner-drawn combo box (with the
		/// <c>CBS_OWNERDRAWFIXED</c> or <c>CBS_OWNERDRAWVARIABLE</c> style).
		/// </para>
		/// <para>
		/// Windows 95: Windows sends the <c>WM_DELETEITEM</c> message for any deleted list box or combo box item with nonzero item data.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/wm-deleteitem
		[MsgParams(typeof(uint), typeof(DELETEITEMSTRUCT?), LResultType = typeof(BOOL))]
		WM_DELETEITEM = 0x002D,

		/// <summary>
		/// <para>Sent by a list box with the <c>LBS_WANTKEYBOARDINPUT</c> style to its owner in response to a <c>WM_KEYDOWN</c> message.</para>
		/// <para>
		/// <code>WM_VKEYTOITEM WPARAM wParam; LPARAM lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> specifies the virtual-key code of the key the user pressed. The <c>HIWORD</c> specifies the current position of
		/// the caret.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the list box.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value specifies the action that the application performed in response to the message. A return value of -2 indicates
		/// that the application handled all aspects of selecting the item and requires no further action by the list box. (See Remarks.) A
		/// return value of -1 indicates that the list box should perform the default action in response to the keystroke. A return value of
		/// 0 or greater specifies the index of an item in the list box and indicates that the list box should perform the default action for
		/// the keystroke on the specified item.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A return value of -2 is valid only for keys that are not translated into characters by the list box control. If the
		/// <c>WM_KEYDOWN</c> message translates to a <c>WM_CHAR</c> message and the application processes the <c>WM_VKEYTOITEM</c> message
		/// generated as a result of the key press, the list box ignores the return value and does the default processing for that
		/// character). <c>WM_KEYDOWN</c> messages generated by keys such as VK_UP, VK_DOWN, VK_NEXT, and VK_PREVIOUS are not translated to
		/// <c>WM_CHAR</c> messages. In such cases, trapping the <c>WM_VKEYTOITEM</c> message and returning -2 prevents the list box from
		/// doing the default processing for that key.
		/// </para>
		/// <para>
		/// To trap keys that generate a char message and do special processing, the application must subclass the list box, trap both the
		/// <c>WM_KEYDOWN</c> and <c>WM_CHAR</c> messages, and process the messages appropriately in the subclass procedure.
		/// </para>
		/// <para>
		/// The preceding remarks apply to regular list boxes that are created with the <c>LBS_WANTKEYBOARDINPUT</c> style. If the list box
		/// is owner-drawn, the application must process the <c>WM_CHARTOITEM</c> message.
		/// </para>
		/// <para>The <c>DefWindowProc</c> function returns -1.</para>
		/// <para>
		/// If a dialog box procedure handles this message, it should cast the desired return value to a <c>BOOL</c> and return the value
		/// directly. The DWL_MSGRESULT value set by the <c>SetWindowLong</c> function is ignored.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/wm-vkeytoitem
		[MsgParams(typeof(uint), typeof(HWND))]
		WM_VKEYTOITEM = 0x002E,

		/// <summary>
		/// <para>Sent by a list box with the <c>LBS_WANTKEYBOARDINPUT</c> style to its owner in response to a <c>WM_CHAR</c> message.</para>
		/// <para>
		/// <code>WM_CHARTOITEM WPARAM wParam; LPARAM lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The <c>LOWORD</c> specifies the character code of the key the user pressed. The <c>HIWORD</c> specifies the current position of
		/// the caret.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the list box.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value specifies the action that the application performed in response to the message. A return value of -1 or -2
		/// indicates that the application handled all aspects of selecting the item and requires no further action by the list box. A return
		/// value of 0 or greater specifies the zero-based index of an item in the list box and indicates that the list box should perform
		/// the default action for the keystroke on the specified item.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>DefWindowProc</c> function returns -1.</para>
		/// <para>Only owner-drawn list boxes that do not have the <c>LBS_HASSTRINGS</c> style can receive this message.</para>
		/// <para>
		/// If a dialog box procedure handles this message, it should cast the desired return value to a <c>BOOL</c> and return the value
		/// directly. The DWL_MSGRESULT value set by the <c>SetWindowLong</c> function is ignored.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/wm-chartoitem
		[MsgParams(typeof(uint), typeof(HWND))]
		WM_CHARTOITEM = 0x002F,

		/// <summary>
		/// <para>Sets the font that a control is to use when drawing text.</para>
		/// <para>
		/// <code>#define WM_SETFONT 0x0030</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A handle to the font ( <c>HFONT</c>). If this parameter is <c>NULL</c>, the control uses the default system font to draw text.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word of lParam specifies whether the control should be redrawn immediately upon setting the font. If this parameter
		/// is <c>TRUE</c>, the control redraws itself.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>This message does not return a value.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>WM_SETFONT</c> message applies to all controls, not just those in dialog boxes.</para>
		/// <para>
		/// The best time for the owner of a dialog box control to set the font of the control is when it receives the <c>WM_INITDIALOG</c>
		/// message. The application should call the <c>DeleteObject</c> function to delete the font when it is no longer needed; for
		/// example, after it destroys the control.
		/// </para>
		/// <para>
		/// The size of the control does not change as a result of receiving this message. To avoid clipping text that does not fit within
		/// the boundaries of the control, the application should correct the size of the control window before it sets the font.
		/// </para>
		/// <para>
		/// When a dialog box uses the DS_SETFONT style to set the text in its controls, the system sends the <c>WM_SETFONT</c> message to
		/// the dialog box procedure before it creates the controls. An application can create a dialog box that contains the DS_SETFONT
		/// style by calling any of the following functions:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>CreateDialogIndirect</c></term>
		/// </item>
		/// <item>
		/// <term><c>CreateDialogIndirectParam</c></term>
		/// </item>
		/// <item>
		/// <term><c>DialogBoxIndirect</c></term>
		/// </item>
		/// <item>
		/// <term><c>DialogBoxIndirectParam</c></term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-setfont
		[MsgParams(typeof(HFONT), typeof(BOOL), LResultType = null)]
		WM_SETFONT = 0x0030,

		/// <summary>
		/// <para>Retrieves the font with which the control is currently drawing its text.</para>
		/// <para>
		/// <code>#define WM_GETFONT 0x0031</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>HFONT</c></para>
		/// <para>The return value is a handle to the font used by the control, or <c>NULL</c> if the control is using the system font.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-getfont
		[MsgParams(LResultType = typeof(HFONT))]
		WM_GETFONT = 0x0031,

		/// <summary>
		/// <para>Sent to a window to associate a hot key with the window. When the user presses the hot key, the system activates the window.</para>
		/// <para>
		/// <code>#define WM_SETHOTKEY 0x0032</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The low-order word specifies the virtual-key code to associate with the window.</para>
		/// <para>The high-order word can be one or more of the following values from CommCtrl.h.</para>
		/// <para>Setting wParam to <c>NULL</c> removes the hot key associated with a window.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HOTKEYF_ALT</c> 0x04</term>
		/// <term>ALT key</term>
		/// </item>
		/// <item>
		/// <term><c>HOTKEYF_CONTROL</c> 0x02</term>
		/// <term>CTRL key</term>
		/// </item>
		/// <item>
		/// <term><c>HOTKEYF_EXT</c> 0x08</term>
		/// <term>Extended key</term>
		/// </item>
		/// <item>
		/// <term><c>HOTKEYF_SHIFT</c> 0x01</term>
		/// <term>SHIFT key</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is one of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>-1</term>
		/// <term>The function is unsuccessful; the hot key is invalid.</term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>The function is unsuccessful; the window is invalid.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>The function is successful, and no other window has the same hot key.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>The function is successful, but another window already has the same hot key.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>A hot key cannot be associated with a child window.</para>
		/// <para><c>VK_ESCAPE</c>, <c>VK_SPACE</c>, and <c>VK_TAB</c> are invalid hot keys.</para>
		/// <para>
		/// When the user presses the hot key, the system generates a <c>WM_SYSCOMMAND</c> message with wParam equal to <c>SC_HOTKEY</c> and
		/// lParam equal to the window's handle. If this message is passed on to <c>DefWindowProc</c>, the system will bring the window's
		/// last active popup (if it exists) or the window itself (if there is no popup window) to the foreground.
		/// </para>
		/// <para>
		/// A window can only have one hot key. If the window already has a hot key associated with it, the new hot key replaces the old one.
		/// If more than one window has the same hot key, the window that is activated by the hot key is random.
		/// </para>
		/// <para>These hot keys are unrelated to the hot keys set by <c>RegisterHotKey</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-sethotkey
		[MsgParams(typeof(uint), null)]
		WM_SETHOTKEY = 0x0032,

		/// <summary>
		/// <para>Sent to determine the hot key associated with a window.</para>
		/// <para>
		/// <code>#define WM_GETHOTKEY 0x0033</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the virtual-key code and modifiers for the hot key, or <c>NULL</c> if no hot key is associated with the
		/// window. The virtual-key code is in the low byte of the return value and the modifiers are in the high byte. The modifiers can be
		/// a combination of the following flags from CommCtrl.h.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>HOTKEYF_ALT</c> 0x04</term>
		/// <term>ALT key</term>
		/// </item>
		/// <item>
		/// <term><c>HOTKEYF_CONTROL</c> 0x02</term>
		/// <term>CTRL key</term>
		/// </item>
		/// <item>
		/// <term><c>HOTKEYF_EXT</c> 0x08</term>
		/// <term>Extended key</term>
		/// </item>
		/// <item>
		/// <term><c>HOTKEYF_SHIFT</c> 0x01</term>
		/// <term>SHIFT key</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>These hot keys are unrelated to the hot keys set by the <c>RegisterHotKey</c> function.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-gethotkey
		[MsgParams(LResultType = typeof(uint))]
		WM_GETHOTKEY = 0x0033,

		/// <summary>
		/// <para>
		/// Sent to a minimized (iconic) window. The window is about to be dragged by the user but does not have an icon defined for its
		/// class. An application can return a handle to an icon or cursor. The system displays this cursor or icon while the user drags the icon.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_QUERYDRAGICON 0x0037</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>
		/// An application should return a handle to a cursor or icon that the system is to display while the user drags the icon. The cursor
		/// or icon must be compatible with the display driver's resolution. If the application returns <c>NULL</c>, the system displays the
		/// default cursor.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When the user drags the icon of a window without a class icon, the system replaces the icon with a default cursor. If the
		/// application requires a different cursor to be displayed during dragging, it must return a handle to the cursor or icon compatible
		/// with the display driver's resolution. If an application returns a handle to a color cursor or icon, the system converts the
		/// cursor or icon to black and white. The application can call the <c>LoadCursor</c> or <c>LoadIcon</c> function to load a cursor or
		/// icon from the resources in its executable (.exe) file and to retrieve this handle.
		/// </para>
		/// <para>
		/// If a dialog box procedure handles this message, it should cast the desired return value to a <c>BOOL</c> and return the value
		/// directly. The <c>DWL_MSGRESULT</c> value set by the <c>SetWindowLong</c> function is ignored.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-querydragicon
		[MsgParams(LResultType = typeof(HANDLE))]
		WM_QUERYDRAGICON = 0x0037,

		/// <summary>
		/// <para>
		/// Sent to determine the relative position of a new item in the sorted list of an owner-drawn combo box or list box. Whenever the
		/// application adds a new item, the system sends this message to the owner of a combo box or list box created with the
		/// <c>CBS_SORT</c> or <c>LBS_SORT</c> style.
		/// </para>
		/// <para>
		/// <code>WM_COMPAREITEM WPARAM wParam; LPARAM lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the identifier of the control that sent the <c>WM_COMPAREITEM</c> message.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>COMPAREITEMSTRUCT</c> structure that contains the identifiers and application-supplied data for two items in the
		/// combo or list box.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value indicates the relative position of the two items. It may be any of the values shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>Value</c></term>
		/// <term>Meaning</term>
		/// </item>
		/// <item>
		/// <term><c>-1</c></term>
		/// <term>Item 1 precedes item 2 in the sorted order.</term>
		/// </item>
		/// <item>
		/// <term><c>0</c></term>
		/// <term>Items 1 and 2 are equivalent in the sorted order.</term>
		/// </item>
		/// <item>
		/// <term><c>1</c></term>
		/// <term>Item 1 follows item 2 in the sorted order.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When the owner of an owner-drawn combo box or list box receives this message, the owner returns a value indicating which of the
		/// items specified by the <c>COMPAREITEMSTRUCT</c> structure will appear before the other. Typically, the system sends this message
		/// several times until it determines the exact position for the new item.
		/// </para>
		/// <para>
		/// If a dialog box procedure handles this message, it should cast the desired return value to a <c>BOOL</c> and return the value
		/// directly. The DWL_MSGRESULT value set by the <c>SetWindowLong</c> function is ignored.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/wm-compareitem
		[MsgParams(typeof(uint), typeof(COMPAREITEMSTRUCT?))]
		WM_COMPAREITEM = 0x0039,

		/// <summary>
		/// <para>
		/// Sent by both Microsoft Active Accessibility and Microsoft UI Automation to obtain information about an accessible object
		/// contained in a server application.
		/// </para>
		/// <para>
		/// Applications never send this message directly. Microsoft Active Accessibility sends this message in response to calls to
		/// <c>AccessibleObjectFromPoint</c>, <c>AccessibleObjectFromEvent</c>, or <c>AccessibleObjectFromWindow</c>. However, server
		/// applications handle this message. UI Automation sends this message in response to calls to
		/// <c>IUIAutomation::ElementFromHandle</c>, <c>ElementFromPoint</c>, and <c>GetFocusedElement</c>, and when handling events for
		/// which a client has registered.
		/// </para>
		/// <para>
		/// <code>dwFlags = (WPARAM)(DWORD) wParam; dwObjId = (LPARAM)(DWORD) lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>dwFlags</em></para>
		/// <para>
		/// Provides additional information about the message and is used only by the system. Servers pass dwFlags as the wParam parameter in
		/// the call to <c>LresultFromObject</c> when handling the message.
		/// </para>
		/// <para><em>dwObjId</em></para>
		/// <para>
		/// Object identifier. This value is one of the object identifier constants or a custom object identifier. A server application must
		/// check this value to identify the type of information being requested. Before comparing this value against the OBJID_ values, the
		/// server must cast it to <c>DWORD</c>; otherwise, on 64-bit Windows, the sign extension of the lParam can interfere with the comparison.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If dwObjId is one of the OBJID_ values such as <c>OBJID_CLIENT</c>, the request is for a Microsoft Active Accessibility object
		/// that implements <c>IAccessible</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If dwObjId is equal to <c>UiaRootObjectId</c>, the request is for a UI Automation provider. If the server is implementing UI
		/// Automation, it should return a provider using the <c>UiaReturnRawElementProvider</c> function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If dwObjId is <c>OBJID_NATIVEOM</c>, the request is for the control's underlying object model. If the control supports this
		/// request, it should return an appropriate COM interface by calling the <c>LresultFromObject</c> function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If dwObjId is <c>OBJID_QUERYCLASSNAMEIDX</c>, the request is for the control to identify itself as a standard Windows control or
		/// a common control implemented by the common control library (ComCtrl.dll).
		/// </term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the window or control does not need to respond to this message, it should pass the message to the <c>DefWindowProc</c>
		/// function; otherwise, the window or control should return a value that corresponds to the request specified by dwObjId:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If the window or control implements UI Automation, the window or control should return the value obtained by a call to the
		/// <c>UiaReturnRawElementProvider</c> function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If dwObjId is <c>OBJID_NATIVEOM</c> and the window exposes a native Object Model, the windows should return the value obtained by
		/// a call to the <c>LresultFromObject</c> function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If dwObjId is <c>OBJID_CLIENT</c> and the window implements <c>IAccessible</c>, the window should return the value obtained by a
		/// call to the <c>LresultFromObject</c> function.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When a client calls <c>AccessibleObjectFromWindow</c> or any of the other <c>AccessibleObjectFrom</c> X functions that retrieve
		/// an interface to an object, Microsoft Active Accessibility sends the <c>WM_GETOBJECT</c> message to the appropriate window
		/// procedure within the appropriate server application. While processing <c>WM_GETOBJECT</c>, server applications call
		/// <c>LresultFromObject</c> and use the return value of this function as the return value for the message. Microsoft Active
		/// Accessibility, in conjunction with the COM library, performs the appropriate marshaling and passes the interface pointer from the
		/// server back to the client.
		/// </para>
		/// <para>
		/// Servers do not respond to <c>WM_GETOBJECT</c> before the object is fully initialized or after it begins to close down. When an
		/// application creates a new window, the system sends <c>EVENT_OBJECT_CREATE</c> to notify clients before it sends the WM_CREATE
		/// message to the application's window procedure. Because many applications use WM_CREATE to start their initialization process,
		/// servers do not respond to the <c>WM_GETOBJECT</c> message until finished processing the <c>WM_CREATE</c> message.
		/// </para>
		/// <para>A server uses <c>WM_GETOBJECT</c> to perform the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Create New Accessible Objects</term>
		/// </item>
		/// <item>
		/// <term>Reuse Existing Pointers to Objects</term>
		/// </item>
		/// <item>
		/// <term>Create New Interfaces to the Same Object</term>
		/// </item>
		/// </list>
		/// <para>
		/// For clients, this means that they might receive distinct interface pointers for the same user interface element, depending on the
		/// server's action. To determine if two interface pointers point to the same user interface element, clients compare
		/// <c>IAccessible</c> properties of the object. Comparing pointers does not work.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winauto/wm-getobject
		[MsgParams(typeof(IntPtr), typeof(int), LResultType = typeof(IntPtr))]
		WM_GETOBJECT = 0x003D,

		/// <summary>
		/// <para>
		/// Sent to all top-level windows when the system detects more than 12.5 percent of system time over a 30- to 60-second interval is
		/// being spent compacting memory. This indicates that system memory is low.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This message is provided only for compatibility with 16-bit Windows-based applications.</para>
		/// </para>
		/// <para>
		/// <code>#define WM_COMPACTING 0x0041</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The ratio of central processing unit (CPU) time currently spent by the system compacting memory to CPU time currently spent by
		/// the system performing other operations. For example, 0x8000 represents 50 percent of CPU time spent compacting memory.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// When an application receives this message, it should free as much memory as possible, taking into account the current level of
		/// activity of the application and the total number of applications running on the system.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-compacting
		[MsgParams(LResultType = typeof(HFONT))]
		WM_COMPACTING = 0x0041,

		/// <summary/>
		[Obsolete]
		WM_COMMNOTIFY = 0x0044,

		/// <summary>
		/// Sent to a window whose size, position, or place in the Z order is about to change as a result of a call to the SetWindowPos
		/// function or another window-management function.
		/// <para>A window receives this message through its WindowProc function.</para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <see cref="WINDOWPOS"/> structure that contains information about the window's new size and position.</para>
		/// <para><strong>Return value</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// For a window with the WS_OVERLAPPED or WS_THICKFRAME style, the DefWindowProc function sends the WM_GETMINMAXINFO message to the
		/// window. This is done to validate the new size and position of the window and to enforce the CS_BYTEALIGNCLIENT and
		/// CS_BYTEALIGNWINDOW client styles. By not passing the WM_WINDOWPOSCHANGING message to the DefWindowProc function, an application
		/// can override these defaults.
		/// <para>
		/// While this message is being processed, modifying any of the values in WINDOWPOS affects the window's new size, position, or place
		/// in the Z order. An application can prevent changes to the window by setting or clearing the appropriate bits in the flags member
		/// of WINDOWPOS.
		/// </para>
		/// </remarks>
		[MsgParams(null, typeof(WINDOWPOS?))]
		WM_WINDOWPOSCHANGING = 0x0046,

		/// <summary>
		/// Sent to a window whose size, position, or place in the Z order has changed as a result of a call to the SetWindowPos function or
		/// another window-management function.
		/// <para>A window receives this message through its WindowProc function.</para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <see cref="WINDOWPOS"/> structure that contains information about the window's new size and position.</para>
		/// <para><strong>Return value</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// By default, the DefWindowProc function sends the WM_SIZE and WM_MOVE messages to the window. The WM_SIZE and WM_MOVE messages are
		/// not sent if an application handles the WM_WINDOWPOSCHANGED message without calling DefWindowProc. It is more efficient to perform
		/// any move or size change processing during the WM_WINDOWPOSCHANGED message without calling DefWindowProc.
		/// </remarks>
		[MsgParams(null, typeof(WINDOWPOS?))]
		WM_WINDOWPOSCHANGED = 0x0047,

		/// <summary>
		/// <para>Notifies applications that the system, typically a battery-powered personal computer, is about to enter a suspended mode.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The <c>WM_POWER</c> message is obsolete. It is provided only for compatibility with 16-bit Windows-based applications.
		/// Applications should use the <c>WM_POWERBROADCAST</c> message.
		/// </para>
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc HWND hwnd, // handle to window UINT uMsg, // WM_POWER WPARAM wParam, // power-event notification LPARAM lParam // not used );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hwnd</em></para>
		/// <para>A handle to window.</para>
		/// <para><em>uMsg</em></para>
		/// <para>The <c>WM_POWER</c> message identifier.</para>
		/// <para><em>wParam</em></para>
		/// <para>The power-event notification. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>PWR_CRITICALRESUME</c></term>
		/// <term>
		/// Indicates that the system is resuming operation after entering suspended mode without first broadcasting a
		/// <c>PWR_SUSPENDREQUEST</c> notification message to the application. An application should perform any necessary recovery actions.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>PWR_SUSPENDREQUEST</c></term>
		/// <term>Indicates that the system is about to enter suspended mode.</term>
		/// </item>
		/// <item>
		/// <term><c>PWR_SUSPENDRESUME</c></term>
		/// <term>
		/// Indicates that the system is resuming operation after having entered suspended mode normally that is, the system broadcast a
		/// <c>PWR_SUSPENDREQUEST</c> notification message to the application before the system was suspended. An application should perform
		/// any necessary recovery actions.
		/// </term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The value an application returns depends on the value of the wParam parameter. If wParam is <c>PWR_SUSPENDREQUEST</c>, the return
		/// value is <c>PWR_FAIL</c> to prevent the system from entering the suspended state; otherwise, it is <c>PWR_OK</c>. If wParam is
		/// <c>PWR_SUSPENDRESUME</c> or <c>PWR_CRITICALRESUME</c>, the return value is zero.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This message is broadcast only to an application that is running on a system that conforms to the Advanced Power Management (APM)
		/// basic input/output system (BIOS) specification. The message is broadcast by the power-management driver to each window returned
		/// by the <c>EnumWindows</c> function.
		/// </para>
		/// <para>
		/// The suspended mode is the state in which the greatest amount of power savings occurs, but all operational data and parameters are
		/// preserved. Random-access memory (RAM) contents are preserved, but many devices are likely to be turned off.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/power/wm-power
		[Obsolete]
		WM_POWER = 0x0048,

		/// <summary>
		/// <para>An application sends the <c>WM_COPYDATA</c> message to pass data to another application.</para>
		/// <para>
		/// <code>#define WM_COPYDATA 0x004A</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the window passing the data.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>COPYDATASTRUCT</c> structure that contains the data to be passed.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the receiving application processes this message, it should return <c>TRUE</c>; otherwise, it should return <c>FALSE</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The data being passed must not contain pointers or other references to objects not accessible to the application receiving the data.
		/// </para>
		/// <para>While this message is being sent, the referenced data must not be changed by another thread of the sending process.</para>
		/// <para>
		/// The receiving application should consider the data read-only. The lParam parameter is valid only during the processing of the
		/// message. The receiving application should not free the memory referenced by lParam. If the receiving application must access the
		/// data after <c>SendMessage</c> returns, it must copy the data into a local buffer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dataxchg/wm-copydata
		[MsgParams(typeof(HWND), typeof(COPYDATASTRUCT?), LResultType = typeof(BOOL))]
		WM_COPYDATA = 0x004A,

		/// <summary>
		/// <para>
		/// Posted to an application when a user cancels the application's journaling activities. The message is posted with a <c>NULL</c>
		/// window handle.
		/// </para>
		/// <para>
		/// <code>#define WM_CANCELJOURNAL 0x004B</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>void</c></para>
		/// <para>
		/// This message does not return a value. It is meant to be processed from within an application's main loop or a <c>GetMessage</c>
		/// hook procedure, not from a window procedure.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Journal record and playback modes are modes imposed on the system that let an application sequentially record or play back user
		/// input. The system enters these modes when an application installs a JournalRecordProc or JournalPlaybackProc hook procedure. When
		/// the system is in either of these journaling modes, applications must take turns reading input from the input queue. If any one
		/// application stops reading input while the system is in a journaling mode, other applications are forced to wait.
		/// </para>
		/// <para>
		/// To ensure a robust system, one that cannot be made unresponsive by any one application, the system automatically cancels any
		/// journaling activities when a user presses CTRL+ESC or CTRL+ALT+DEL. The system then unhooks any journaling hook procedures, and
		/// posts a <c>WM_CANCELJOURNAL</c> message, with a <c>NULL</c> window handle, to the application that set the journaling hook.
		/// </para>
		/// <para>
		/// The <c>WM_CANCELJOURNAL</c> message has a <c>NULL</c> window handle, therefore it cannot be dispatched to a window procedure.
		/// There are two ways for an application to see a <c>WM_CANCELJOURNAL</c> message: If the application is running in its own main
		/// loop, it must catch the message between its call to <c>GetMessage</c> or <c>PeekMessage</c> and its call to
		/// <c>DispatchMessage</c>. If the application is not running in its own main loop, it must set a GetMsgProc hook procedure (through
		/// a call to <c>SetWindowsHookEx</c> specifying the <c>WH_GETMESSAGE</c> hook type) that watches for the message.
		/// </para>
		/// <para>
		/// When an application sees a <c>WM_CANCELJOURNAL</c> message, it can assume two things: the user has intentionally canceled the
		/// journal record or playback mode, and the system has already unhooked any journal record or playback hook procedures.
		/// </para>
		/// <para>
		/// Note that the key combinations mentioned above (CTRL+ESC or CTRL+ALT+DEL) cause the system to cancel journaling. If any one
		/// application is made unresponsive, they give the user a means of recovery. The <c>VK_CANCEL</c> virtual key code (usually
		/// implemented as the CTRL+BREAK key combination) is what an application that is in journal record mode should watch for as a signal
		/// that the user wishes to cancel the journaling activity. The difference is that watching for <c>VK_CANCEL</c> is a suggested
		/// behavior for journaling applications, whereas CTRL+ESC or CTRL+ALT+DEL cause the system to cancel journaling regardless of a
		/// journaling application's behavior.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-canceljournal
		[MsgParams(LResultType = null)]
		WM_CANCELJOURNAL = 0x004B,

		/// <summary>
		/// Sent by a common control to its parent window when an event has occurred or the control requires some information.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The identifier of the common control sending the message. This identifier is not guaranteed to be unique. An application should
		/// use the <c>hwndFrom</c> or <c>idFrom</c> member of the <c>NMHDR</c> structure (passed as the lParam parameter) to identify the control.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to an <c>NMHDR</c> structure that contains the notification code and additional information. For some notification
		/// messages, this parameter points to a larger structure that has the <c>NMHDR</c> structure as its first member.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is ignored except for notification messages that specify otherwise.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The destination of the message must be the <c>HWND</c> of the parent of the control. This value can be obtained by using
		/// <c>GetParent</c>, as shown in the following example, where m_controlHwnd is the <c>HWND</c> of the control itself.
		/// </para>
		/// <para>
		/// <code>NMHDR nmh; nmh.code = CUSTOM_SELCHANGE; // Message type defined by control. nmh.idFrom = GetDlgCtrlID(m_controlHwnd); nmh.hwndFrom = m_controlHwnd; SendMessage(GetParent(m_controlHwnd), WM_NOTIFY, nmh.idFrom, (LPARAM)&amp;nmh);</code>
		/// </para>
		/// <para>
		/// Applications handle the message in the window procedure of the parent window, as shown in the following example, which handles
		/// the notification message sent by the custom control in the previous example.
		/// </para>
		/// <para>
		/// <code>INT_PTR CALLBACK DlgProc(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam) { switch (message) { case WM_NOTIFY: switch (((LPNMHDR)lParam)-&gt;code) { case CUSTOM_SELCHANGE: if (((LPNMHDR)lParam)-&gt;idFrom == IDC_CUSTOMLISTBOX1) { ... // Respond to message. return TRUE; } break; ... // More cases on WM_NOTIFY switch. break; } ... // More cases on message switch. } return FALSE; }</code>
		/// </para>
		/// <para>
		/// Some notifications, chiefly those that have been in the API for a long time, are sent as <c>WM_COMMAND</c> messages. For more
		/// information, see Control Messages.
		/// </para>
		/// <para>
		/// If the message handler is in a dialog box procedure, you must use the <c>SetWindowLong</c> function with DWL_MSGRESULT to set a
		/// return value.
		/// </para>
		/// <para>For Windows Vista and later systems, the <c>WM_NOTIFY</c> message cannot be sent between processes.</para>
		/// <para>
		/// Many notifications are available in both ANSI and Unicode formats. The window sending the <c>WM_NOTIFY</c> message uses the
		/// <c>WM_NOTIFYFORMAT</c> message to determine which format should be used. See <c>WM_NOTIFYFORMAT</c> for further discussion.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/wm-notify
		[MsgParams(typeof(uint), typeof(NMHDR?), LResultType = typeof(HWND))]
		WM_NOTIFY = 0x004E,

		/// <summary>
		/// <para>
		/// Posted to the window with the focus when the user chooses a new input language, either with the hotkey (specified in the Keyboard
		/// control panel application) or from the indicator on the system taskbar. An application can accept the change by passing the
		/// message to the <c>DefWindowProc</c> function or reject the change (and prevent it from taking place) by returning immediately.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_INPUTLANGCHANGEREQUEST 0x0050</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The new input locale. This parameter can be a combination of the following flags.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>INPUTLANGCHANGE_BACKWARD</c> 0x0004</term>
		/// <term>
		/// A hot key was used to choose the previous input locale in the installed list of input locales. This flag cannot be used with the
		/// INPUTLANGCHANGE_FORWARD flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>INPUTLANGCHANGE_FORWARD</c> 0x0002</term>
		/// <term>
		/// A hot key was used to choose the next input locale in the installed list of input locales. This flag cannot be used with the
		/// INPUTLANGCHANGE_BACKWARD flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>INPUTLANGCHANGE_SYSCHARSET</c> 0x0001</term>
		/// <term>The new input locale's keyboard layout can be used with the system character set.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>The input locale identifier. For more information, see Languages, Locales, and Keyboard Layouts.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>
		/// This message is posted, not sent, to the application, so the return value is ignored. To accept the change, the application
		/// should pass the message to <c>DefWindowProc</c>. To reject the change, the application should return zero without calling <c>DefWindowProc</c>.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When the <c>DefWindowProc</c> function receives the <c>WM_INPUTLANGCHANGEREQUEST</c> message, it activates the new input locale
		/// and notifies the application of the change by sending the <c>WM_INPUTLANGCHANGE</c> message.
		/// </para>
		/// <para>
		/// The language indicator is present on the taskbar only if you have installed more than one keyboard layout and if you have enabled
		/// the indicator using the Keyboard control panel application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-inputlangchangerequest
		[MsgParams(typeof(INPUTLANGCHANGE), typeof(LCID), LResultType = null)]
		WM_INPUTLANGCHANGEREQUEST = 0x0050,

		/// <summary>
		/// <para>
		/// Sent to the topmost affected window after an application's input language has been changed. You should make any
		/// application-specific settings and pass the message to the <c>DefWindowProc</c> function, which passes the message to all
		/// first-level child windows. These child windows can pass the message to <c>DefWindowProc</c> to have it pass the message to their
		/// child windows, and so on.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_INPUTLANGCHANGE 0x0051</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Type: **WPARAM**</para>
		/// <para>The code page of the new locale.</para>
		/// <para><em>lParam</em></para>
		/// <para>Type: **LPARAM**</para>
		/// <para>The <c>HKL</c> input locale identifier. For more information, see Languages, Locales, and Keyboard Layouts.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>An application should return nonzero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>You can retrieve keyboard locale name via LCIDToLocaleName function. With locale name you can use modern locale functions:</para>
		/// <para>
		/// <code>case WM_INPUTLANGCHANGE: { HKL hkl = (HKL)lParam; WCHAR localeName[LOCALE_NAME_MAX_LENGTH]; LCIDToLocaleName(MAKELCID(LOWORD(hkl), SORT_DEFAULT), localeName, LOCALE_NAME_MAX_LENGTH, 0); WCHAR lang[9]; GetLocaleInfoEx(localeName, LOCALE_SISO639LANGNAME2, lang, 9); }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-inputlangchange
		[MsgParams(typeof(CharacterSet), typeof(HKL))]
		WM_INPUTLANGCHANGE = 0x0051,

		/// <summary>
		/// Sent to an application that has initiated a training card with Windows Help. The message informs the application when the user
		/// clicks an authorable button. An application initiates a training card by specifying the HELP_TCARD command in a call to the
		/// <c>WinHelp</c> function.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>idAction</em></para>
		/// <para>A value that indicates the action the user has taken. This can be one of the following values.</para>
		/// <para><em><c>IDABORT</c></em></para>
		/// <para>The user clicked an authorable <c>Abort</c> button.</para>
		/// <para><em><c>IDCANCEL</c></em></para>
		/// <para>The user clicked an authorable <c>Cancel</c> button.</para>
		/// <para><em><c>IDCLOSE</c></em></para>
		/// <para>The user closed the training card.</para>
		/// <para><em><c>IDHELP</c></em></para>
		/// <para>The user clicked an authorable Windows <c>Help</c> button.</para>
		/// <para><em><c>IDIGNORE</c></em></para>
		/// <para>The user clicked an authorable <c>Ignore</c> button.</para>
		/// <para><em><c>IDOK</c></em></para>
		/// <para>The user clicked an authorable <c>OK</c> button.</para>
		/// <para><em><c>IDNO</c></em></para>
		/// <para>The user clicked an authorable <c>No</c> button.</para>
		/// <para><em><c>IDRETRY</c></em></para>
		/// <para>The user clicked an authorable <c>Retry</c> button.</para>
		/// <para><em><c>HELP_TCARD_DATA</c></em></para>
		/// <para>The user clicked an authorable button. The dwActionData parameter contains a long integer specified by the Help author.</para>
		/// <para><em><c>HELP_TCARD_OTHER_CALLER</c></em></para>
		/// <para>Another application has requested training cards.</para>
		/// <para><em><c>IDYES</c></em></para>
		/// <para>The user clicked an authorable <c>Yes</c> button.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is ignored; use zero.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/shell/wm-tcard
		[MsgParams(typeof(MB_RESULT), typeof(int))]
		WM_TCARD = 0x0052,

		/// <summary>
		/// Indicates that the user pressed the F1 key. If a menu is active when F1 is pressed, <c>WM_HELP</c> is sent to the window
		/// associated with the menu; otherwise, <c>WM_HELP</c> is sent to the window that has the keyboard focus. If no window has the
		/// keyboard focus, <c>WM_HELP</c> is sent to the currently active window.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lphi</em></para>
		/// <para>
		/// The address of a <c>HELPINFO</c> structure that contains information about the menu item, control, dialog box, or window for
		/// which Help is requested.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c>.</para>
		/// </summary>
		/// <remarks>
		/// The <c>DefWindowProc</c> function passes <c>WM_HELP</c> to the parent window of a child window or to the owner of a top-level window.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/wm-help
		[MsgParams(typeof(int), typeof(HELPINFO?), LResultType = typeof(BOOL))]
		WM_HELP = 0x0053,

		/// <summary>
		/// <para>
		/// Sent to all windows after the user has logged on or off. When the user logs on or off, the system updates the user-specific
		/// settings. The system sends this message immediately after updating the settings.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This message is not supported as of Windows Vista.</para>
		/// </para>
		/// <para>
		/// <code>#define WM_USERCHANGED 0x0054</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-userchanged
		[MsgParams()]
		WM_USERCHANGED = 0x0054,

		/// <summary>
		/// Determines if a window accepts ANSI or Unicode structures in the <c>WM_NOTIFY</c> notification message. <c>WM_NOTIFYFORMAT</c>
		/// messages are sent from a common control to its parent window and from the parent window to the common control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A handle to the window that is sending the <c>WM_NOTIFYFORMAT</c> message. If lParam is NF_QUERY, this parameter is the handle to
		/// a control. If lParam is NF_REQUERY, this parameter is the handle to the parent window of a control.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>The command value that specifies the nature of the <c>WM_NOTIFYFORMAT</c> message. This will be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>NF_QUERY</c></term>
		/// <term>
		/// The message is a query to determine whether ANSI or Unicode structures should be used in <c>WM_NOTIFY</c> messages. This command
		/// is sent from a control to its parent window during the creation of a control and in response to an NF_REQUERY command.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>NF_REQUERY</c></term>
		/// <term>
		/// The message is a request for a control to send an NF_QUERY form of this message to its parent window. This command is sent from
		/// the parent window. The parent window is asking the control to requery it about the type of structures to use in <c>WM_NOTIFY</c>
		/// messages. If <c>lParam</c> is NF_REQUERY, the return value is the result of the requery operation.
		/// </term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>NFR_ANSI</c></term>
		/// <term>ANSI structures should be used in <c>WM_NOTIFY</c> messages sent by the control.</term>
		/// </item>
		/// <item>
		/// <term><c>NFR_UNICODE</c></term>
		/// <term>Unicode structures should be used in <c>WM_NOTIFY</c> messages sent by the control.</term>
		/// </item>
		/// <item>
		/// <term><c>0</c></term>
		/// <term>An error occurred.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When a common control is created, the control sends a <c>WM_NOTIFYFORMAT</c> message to its parent window to determine the type
		/// of structures to use in <c>WM_NOTIFY</c> messages. If the parent window does not handle this message, the <c>DefWindowProc</c>
		/// function responds according to the type of the parent window. That is, if the parent window is a Unicode window,
		/// <c>DefWindowProc</c> returns NFR_UNICODE, and if the parent window is an ANSI window, <c>DefWindowProc</c> returns NFR_ANSI. If
		/// the parent window is a dialog box and does not handle this message, the <c>DefDlgProc</c> function similarly responds according
		/// to the type of the dialog box (Unicode or ANSI).
		/// </para>
		/// <para>
		/// A parent window can change the type of structures a common control uses in <c>WM_NOTIFY</c> messages by setting lParam to
		/// NF_REQUERY and sending a <c>WM_NOTIFYFORMAT</c> message to the control. This causes the control to send an NF_QUERY form of the
		/// <c>WM_NOTIFYFORMAT</c> message to the parent window.
		/// </para>
		/// <para>
		/// All common controls will send <c>WM_NOTIFYFORMAT</c> messages. However, the standard Windows controls (edit controls, combo
		/// boxes, list boxes, buttons, scroll bars, and static controls) do not.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/wm-notifyformat
		[MsgParams(typeof(HWND), typeof(NOTIFYFORMAT), LResultType = typeof(NOTIFYFORMAT))]
		WM_NOTIFYFORMAT = 0x0055,

		/// <summary>
		/// <para>
		/// Notifies a window that the user desires a context menu to appear. The user may have clicked the right mouse button
		/// (right-clicked) in the window, pressed Shift+F10 or pressed the applications key (context menu key) available on some keyboards.
		/// </para>
		/// <para>
		/// <code>#define WM_CONTEXTMENU 0x007B</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A handle to the window in which the user right-clicked the mouse. This can be a child window of the window receiving the message.
		/// For more information about processing this message, see the Remarks section.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>The low-order word specifies the horizontal position of the cursor, in screen coordinates, at the time of the mouse click.</para>
		/// <para>The high-order word specifies the vertical position of the cursor, in screen coordinates, at the time of the mouse click.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A window can process this message by displaying a shortcut menu using the <c>TrackPopupMenu</c> or <c>TrackPopupMenuEx</c>
		/// functions. To obtain the horizontal and vertical positions, use the following code.
		/// </para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// If a window does not display a shortcut menu it should pass this message to the <c>DefWindowProc</c> function. If a window is a
		/// child window, <c>DefWindowProc</c> sends the message to the parent. Otherwise, <c>DefWindowProc</c> displays a default shortcut
		/// menu if the specified position is in the window's caption.
		/// </para>
		/// <para>
		/// <c>DefWindowProc</c> generates the <c>WM_CONTEXTMENU</c> message when it processes the <c>WM_RBUTTONUP</c> or
		/// <c>WM_NCRBUTTONUP</c> message or when the user types SHIFT+F10. The <c>WM_CONTEXTMENU</c> message is also generated when the user
		/// presses and releases the <c>VK_APPS</c> key.
		/// </para>
		/// <para>
		/// If the context menu is generated from the keyboard for example, if the user types SHIFT+F10 then the x- and y-coordinates are
		/// -1 and the application should display the context menu at the location of the current selection rather than at (xPos, yPos).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-contextmenu
		[MsgParams(typeof(HWND), typeof(POINTS), LResultType = null)]
		WM_CONTEXTMENU = 0x007B,

		/// <summary>
		/// <para>Sent to a window when the <c>SetWindowLong</c> function is about to change one or more of the window's styles.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_STYLECHANGING 0x007C</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Indicates whether the window's styles or extended window styles are changing. This parameter can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>GWL_EXSTYLE</c> -20</term>
		/// <term>The extended window styles are changing.</term>
		/// </item>
		/// <item>
		/// <term><c>GWL_STYLE</c> -16</term>
		/// <term>The window styles are changing.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>STYLESTRUCT</c> structure that contains the proposed new styles for the window. An application can examine the
		/// styles and, if necessary, change them.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-stylechanging
		[MsgParams(typeof(WindowLongFlags), typeof(STYLESTRUCT))]
		WM_STYLECHANGING = 0x007C,

		/// <summary>
		/// <para>Sent to a window after the <c>SetWindowLong</c> function has changed one or more of the window's styles.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_STYLECHANGED 0x007D</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Indicates whether the window's styles or extended window styles have changed. This parameter can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>GWL_EXSTYLE</c> -20</term>
		/// <term>The extended window styles have changed.</term>
		/// </item>
		/// <item>
		/// <term><c>GWL_STYLE</c> -16</term>
		/// <term>The window styles have changed.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>STYLESTRUCT</c> structure that contains the new styles for the window. An application can examine the styles,
		/// but cannot change them.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-stylechanged
		[MsgParams(typeof(WindowLongFlags), typeof(STYLESTRUCT))]
		WM_STYLECHANGED = 0x007D,

		/// <summary>
		/// <para>The <c>WM_DISPLAYCHANGE</c> message is sent to all windows when the display resolution has changed.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The new image depth of the display, in bits per pixel.</para>
		/// <para><em>lParam</em></para>
		/// <para>The low-order word specifies the horizontal resolution of the screen.</para>
		/// <para>The high-order word specifies the vertical resolution of the screen.</para>
		/// </summary>
		/// <remarks>This message is only sent to top-level windows. For all other windows it is posted.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/gdi/wm-displaychange
		[MsgParams(typeof(ushort), typeof(SIZES))]
		WM_DISPLAYCHANGE = 0x007E,

		/// <summary>
		/// <para>
		/// Sent to a window to retrieve a handle to the large or small icon associated with a window. The system displays the large icon in
		/// the ALT+TAB dialog, and the small icon in the window caption.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_GETICON 0x007F</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The type of icon being retrieved. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>ICON_BIG</c> 1</term>
		/// <term>Retrieve the large icon for the window.</term>
		/// </item>
		/// <item>
		/// <term><c>ICON_SMALL</c> 0</term>
		/// <term>Retrieve the small icon for the window.</term>
		/// </item>
		/// <item>
		/// <term><c>ICON_SMALL2</c> 2</term>
		/// <term>
		/// Retrieves the small icon provided by the application. If the application does not provide one, the system uses the
		/// system-generated icon for that window.
		/// </term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>The DPI of the icon being retrieved. This can be used to provide different icons depending on the icon size.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>HICON</c></para>
		/// <para>
		/// The return value is a handle to the large or small icon, depending on the value of wParam. When an application receives this
		/// message, it can return a handle to a large or small icon, or pass the message to the <c>DefWindowProc</c> function.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>When an application receives this message, it can return a handle to a large or small icon, or pass the message to <c>DefWindowProc</c>.</para>
		/// <para>
		/// <c>DefWindowProc</c> returns a handle to the large or small icon associated with the window, depending on the value of wParam.
		/// </para>
		/// <para>
		/// A window that has no icon explicitly set (with <c>WM_SETICON</c>) uses the icon for the registered window class, and in this case
		/// <c>DefWindowProc</c> will return 0 for a <c>WM_GETICON</c> message. If sending a <c>WM_GETICON</c> message to a window returns 0,
		/// next try calling the <c>GetClassLongPtr</c> function for the window. If that returns 0 then try the <c>LoadIcon</c> function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-geticon
		[MsgParams(typeof(WM_ICON_WPARAM), typeof(uint), LResultType = typeof(HICON))]
		WM_GETICON = 0x007F,

		/// <summary>
		/// <para>
		/// Associates a new large or small icon with a window. The system displays the large icon in the ALT+TAB dialog box, and the small
		/// icon in the window caption.
		/// </para>
		/// <para>
		/// <code>#define WM_SETICON 0x0080</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The type of icon to be set. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>ICON_BIG</c> 1</term>
		/// <term>Set the large icon for the window.</term>
		/// </item>
		/// <item>
		/// <term><c>ICON_SMALL</c> 0</term>
		/// <term>Set the small icon for the window.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the new large or small icon. If this parameter is <c>NULL</c>, the icon indicated by wParamis removed.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>
		/// The return value is a handle to the previous large or small icon, depending on the value of wParam. It is <c>NULL</c> if the
		/// window previously had no icon of the type indicated by wParam.
		/// </para>
		/// </summary>
		/// <remarks>
		/// The <c>DefWindowProc</c> function returns a handle to the previous large or small icon associated with the window, depending on
		/// the value of wParam.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-seticon
		[MsgParams(typeof(WM_ICON_WPARAM), typeof(HICON), LResultType = typeof(HICON))]
		WM_SETICON = 0x0080,

		/// <summary>
		/// <para>Sent prior to the <c>WM_CREATE</c> message when a window is first created.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCCREATE 0x0081</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to the <c>CREATESTRUCT</c> structure that contains information about the window being created. The members of
		/// <c>CREATESTRUCT</c> are identical to the parameters of the <c>CreateWindowEx</c> function.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>
		/// If an application processes this message, it should return <c>TRUE</c> to continue creation of the window. If the application
		/// returns <c>FALSE</c>, the <c>CreateWindow</c> or <c>CreateWindowEx</c> function will return a <c>NULL</c> handle.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-nccreate
		[MsgParams(null, typeof(CREATESTRUCT?), LResultType = typeof(BOOL))]
		WM_NCCREATE = 0x0081,

		/// <summary>
		/// <para>
		/// Notifies a window that its nonclient area is being destroyed. The <c>DestroyWindow</c> function sends the <c>WM_NCDESTROY</c>
		/// message to the window following the <c>WM_DESTROY</c> message. <c>WM_DESTROY</c> is used to free the allocated memory object
		/// associated with the window.
		/// </para>
		/// <para>
		/// The <c>WM_NCDESTROY</c> message is sent after the child windows have been destroyed. In contrast, <c>WM_DESTROY</c> is sent
		/// before the child windows are destroyed.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCDESTROY 0x0082</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>This message frees any memory internally allocated for the window.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-ncdestroy
		[MsgParams()]
		WM_NCDESTROY = 0x0082,

		/// <summary>
		/// <para>
		/// Sent when the size and position of a window's client area must be calculated. By processing this message, an application can
		/// control the content of the window's client area when the size or position of the window changes.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCCALCSIZE 0x0083</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// If wParam is <c>TRUE</c>, it specifies that the application should indicate which part of the client area contains valid
		/// information. The system copies the valid information to the specified area within the new client area.
		/// </para>
		/// <para>If wParam is <c>FALSE</c>, the application does not need to indicate the valid part of the client area.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// If wParam is <c>TRUE</c>, lParam points to an <c>NCCALCSIZE_PARAMS</c> structure that contains information an application can use
		/// to calculate the new size and position of the client rectangle.
		/// </para>
		/// <para>
		/// If wParam is <c>FALSE</c>, lParam points to a <c>RECT</c> structure. On entry, the structure contains the proposed window
		/// rectangle for the window. On exit, the structure should contain the screen coordinates of the corresponding window client area.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If the wParam parameter is <c>FALSE</c>, the application should return zero.</para>
		/// <para>If wParam is <c>TRUE</c>, the application should return zero or a combination of the following values.</para>
		/// <para>
		/// If wParam is <c>TRUE</c> and an application returns zero, the old client area is preserved and is aligned with the upper-left
		/// corner of the new client area.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>WVR_ALIGNTOP</c> 0x0010</term>
		/// <term>
		/// Specifies that the client area of the window is to be preserved and aligned with the top of the new position of the window. For
		/// example, to align the client area to the upper-left corner, return the WVR_ALIGNTOP and <c>WVR_ALIGNLEFT</c> values.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WVR_ALIGNRIGHT</c> 0x0080</term>
		/// <term>
		/// Specifies that the client area of the window is to be preserved and aligned with the right side of the new position of the
		/// window. For example, to align the client area to the lower-right corner, return the <c>WVR_ALIGNRIGHT</c> and WVR_ALIGNBOTTOM values.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WVR_ALIGNLEFT</c> 0x0020</term>
		/// <term>
		/// Specifies that the client area of the window is to be preserved and aligned with the left side of the new position of the window.
		/// For example, to align the client area to the lower-left corner, return the <c>WVR_ALIGNLEFT</c> and <c>WVR_ALIGNBOTTOM</c> values.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WVR_ALIGNBOTTOM</c> 0x0040</term>
		/// <term>
		/// Specifies that the client area of the window is to be preserved and aligned with the bottom of the new position of the window.
		/// For example, to align the client area to the top-left corner, return the WVR_ALIGNTOP and <c>WVR_ALIGNLEFT</c> values.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WVR_HREDRAW</c> 0x0100</term>
		/// <term>
		/// Used in combination with any other values, except <c>WVR_VALIDRECTS</c>, causes the window to be completely redrawn if the client
		/// rectangle changes size horizontally. This value is similar to CS_HREDRAW class style
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WVR_VREDRAW</c> 0x0200</term>
		/// <term>
		/// Used in combination with any other values, except <c>WVR_VALIDRECTS</c>, causes the window to be completely redrawn if the client
		/// rectangle changes size vertically. This value is similar to CS_VREDRAW class style
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WVR_REDRAW</c> 0x0300</term>
		/// <term>This value causes the entire window to be redrawn. It is a combination of <c>WVR_HREDRAW</c> and <c>WVR_VREDRAW</c> values.</term>
		/// </item>
		/// <item>
		/// <term><c>WVR_VALIDRECTS</c> 0x0400</term>
		/// <term>
		/// This value indicates that, upon return from <c>WM_NCCALCSIZE</c>, the rectangles specified by the <c>rgrc</c>[1] and
		/// <c>rgrc</c>[2] members of the <c>NCCALCSIZE_PARAMS</c> structure contain valid destination and source area rectangles,
		/// respectively. The system combines these rectangles to calculate the area of the window to be preserved. The system copies any
		/// part of the window image that is within the source rectangle and clips the image to the destination rectangle. Both rectangles
		/// are in parent-relative or screen-relative coordinates. This flag cannot be combined with any other flags. This return value
		/// allows an application to implement more elaborate client-area preservation strategies, such as centering or preserving a subset
		/// of the client area.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The window may be redrawn, depending on whether the CS_HREDRAW or CS_VREDRAW class style is specified. This is the default,
		/// backward-compatible processing of this message by the <c>DefWindowProc</c> function (in addition to the usual client rectangle
		/// calculation described in the preceding table).
		/// </para>
		/// <para>
		/// When wParam is <c>TRUE</c>, simply returning 0 without processing the <c>NCCALCSIZE_PARAMS</c> rectangles will cause the client
		/// area to resize to the size of the window, including the window frame. This will remove the window frame and caption items from
		/// your window, leaving only the client area displayed.
		/// </para>
		/// <para>
		/// Starting with Windows Vista, removing the standard frame by simply returning 0 when the wParam is <c>TRUE</c> does not affect
		/// frames that are extended into the client area using the <c>DwmExtendFrameIntoClientArea</c> function. Only the standard frame
		/// will be removed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-nccalcsize
		[MsgParams(typeof(BOOL), typeof(BOOL), LResultType = typeof(BOOL))]
		WM_NCCALCSIZE = 0x0083,

		/// <summary>
		/// <para>
		/// Sent to a window in order to determine what part of the window corresponds to a particular screen coordinate. This can happen,
		/// for example, when the cursor moves, when a mouse button is pressed or released, or in response to a call to a function such as
		/// <c>WindowFromPoint</c>. If the mouse is not captured, the message is sent to the window beneath the cursor. Otherwise, the
		/// message is sent to the window that has captured the mouse.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCHITTEST 0x0084</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the x-coordinate of the cursor. The coordinate is relative to the upper-left corner of the screen.
		/// </para>
		/// <para>
		/// The high-order word specifies the y-coordinate of the cursor. The coordinate is relative to the upper-left corner of the screen.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value of the <c>DefWindowProc</c> function is one of the following values, indicating the position of the cursor hot spot.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>HTBORDER</c> 18</term>
		/// <term>In the border of a window that does not have a sizing border.</term>
		/// </item>
		/// <item>
		/// <term><c>HTBOTTOM</c> 15</term>
		/// <term>In the lower-horizontal border of a resizable window (the user can click the mouse to resize the window vertically).</term>
		/// </item>
		/// <item>
		/// <term><c>HTBOTTOMLEFT</c> 16</term>
		/// <term>In the lower-left corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).</term>
		/// </item>
		/// <item>
		/// <term><c>HTBOTTOMRIGHT</c> 17</term>
		/// <term>In the lower-right corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).</term>
		/// </item>
		/// <item>
		/// <term><c>HTCAPTION</c> 2</term>
		/// <term>In a title bar.</term>
		/// </item>
		/// <item>
		/// <term><c>HTCLIENT</c> 1</term>
		/// <term>In a client area.</term>
		/// </item>
		/// <item>
		/// <term><c>HTCLOSE</c> 20</term>
		/// <term>In a <c>Close</c> button.</term>
		/// </item>
		/// <item>
		/// <term><c>HTERROR</c> -2</term>
		/// <term>
		/// On the screen background or on a dividing line between windows (same as <c>HTNOWHERE</c>, except that the <c>DefWindowProc</c>
		/// function produces a system beep to indicate an error).
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>HTGROWBOX</c> 4</term>
		/// <term>In a size box (same as <c>HTSIZE</c>).</term>
		/// </item>
		/// <item>
		/// <term><c>HTHELP</c> 21</term>
		/// <term>In a <c>Help</c> button.</term>
		/// </item>
		/// <item>
		/// <term><c>HTHSCROLL</c> 6</term>
		/// <term>In a horizontal scroll bar.</term>
		/// </item>
		/// <item>
		/// <term><c>HTLEFT</c> 10</term>
		/// <term>In the left border of a resizable window (the user can click the mouse to resize the window horizontally).</term>
		/// </item>
		/// <item>
		/// <term><c>HTMENU</c> 5</term>
		/// <term>In a menu.</term>
		/// </item>
		/// <item>
		/// <term><c>HTMAXBUTTON</c> 9</term>
		/// <term>In a <c>Maximize</c> button.</term>
		/// </item>
		/// <item>
		/// <term><c>HTMINBUTTON</c> 8</term>
		/// <term>In a <c>Minimize</c> button.</term>
		/// </item>
		/// <item>
		/// <term><c>HTNOWHERE</c> 0</term>
		/// <term>On the screen background or on a dividing line between windows.</term>
		/// </item>
		/// <item>
		/// <term><c>HTREDUCE</c> 8</term>
		/// <term>In a <c>Minimize</c> button.</term>
		/// </item>
		/// <item>
		/// <term><c>HTRIGHT</c> 11</term>
		/// <term>In the right border of a resizable window (the user can click the mouse to resize the window horizontally).</term>
		/// </item>
		/// <item>
		/// <term><c>HTSIZE</c> 4</term>
		/// <term>In a size box (same as <c>HTGROWBOX</c>).</term>
		/// </item>
		/// <item>
		/// <term><c>HTSYSMENU</c> 3</term>
		/// <term>In a window menu or in a <c>Close</c> button in a child window.</term>
		/// </item>
		/// <item>
		/// <term><c>HTTOP</c> 12</term>
		/// <term>In the upper-horizontal border of a window.</term>
		/// </item>
		/// <item>
		/// <term><c>HTTOPLEFT</c> 13</term>
		/// <term>In the upper-left corner of a window border.</term>
		/// </item>
		/// <item>
		/// <term><c>HTTOPRIGHT</c> 14</term>
		/// <term>In the upper-right corner of a window border.</term>
		/// </item>
		/// <item>
		/// <term><c>HTTRANSPARENT</c> -1</term>
		/// <term>
		/// In a window currently covered by another window in the same thread (the message will be sent to underlying windows in the same
		/// thread until one of them returns a code that is not <c>HTTRANSPARENT</c>).
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>HTVSCROLL</c> 7</term>
		/// <term>In the vertical scroll bar.</term>
		/// </item>
		/// <item>
		/// <term><c>HTZOOM</c> 9</term>
		/// <term>In a <c>Maximize</c> button.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>Use the following code to obtain the horizontal and vertical position:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the return value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the <c>MAKEPOINTS</c> macro to obtain a <c>POINTS</c> structure from the
		/// return value. You can also use the <c>GET_X_LPARAM</c> or <c>GET_Y_LPARAM</c> macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>
		/// <c>Windows Vista:</c> When creating custom frames that include the standard caption buttons, this message should first be passed
		/// to the <c>DwmDefWindowProc</c> function. This enables the Desktop Window Manager (DWM) to provide hit-testing for the captions
		/// buttons. If <c>DwmDefWindowProc</c> does not handle the message, further processing of <c>WM_NCHITTEST</c> may be needed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest
		[MsgParams(null, typeof(POINTS), LResultType = typeof(HitTestValues))]
		WM_NCHITTEST = 0x0084,

		/// <summary>
		/// <para>The <c>WM_NCPAINT</c> message is sent to a window when its frame must be painted.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the update region of the window. The update region is clipped to the window frame.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application returns zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>DefWindowProc</c> function paints the window frame.</para>
		/// <para>
		/// An application can intercept the <c>WM_NCPAINT</c> message and paint its own custom window frame. The clipping region for a
		/// window is always rectangular, even if the shape of the frame is altered.
		/// </para>
		/// <para>The wParam value can be passed to <c>GetDCEx</c> as in the following example.</para>
		/// <para>
		/// <code>case WM_NCPAINT: { HDC hdc; hdc = GetDCEx(hwnd, (HRGN)wParam, DCX_WINDOW|DCX_INTERSECTRGN); // Paint into this DC ReleaseDC(hwnd, hdc); }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/gdi/wm-ncpaint
		[MsgParams(typeof(HRGN), null)]
		WM_NCPAINT = 0x0085,

		/// <summary>
		/// <para>Sent to a window when its nonclient area needs to be changed to indicate an active or inactive state.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCACTIVATE 0x0086</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Indicates when a title bar or icon needs to be changed to indicate an active or inactive state. If an active title bar or icon is
		/// to be drawn, the wParam parameter is <c>TRUE</c>. If an inactive title bar or icon is to be drawn, wParam is <c>FALSE</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>When a visual style is active for this window, this parameter is not used.</para>
		/// <para>
		/// When a visual style is not active for this window, this parameter is a handle to an optional update region for the nonclient area
		/// of the window. If this parameter is set to -1, <c>DefWindowProc</c> does not repaint the nonclient area to reflect the state change.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>
		/// When the wParam parameter is <c>FALSE</c>, an application should return <c>TRUE</c> to indicate that the system should proceed
		/// with the default processing, or it should return <c>FALSE</c> to prevent the change. When wParam is <c>TRUE</c>, the return value
		/// is ignored.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Processing messages related to the nonclient area of a standard window is not recommended, because the application must be able
		/// to draw all the required parts of the nonclient area for the window. If an application does process this message, it must return
		/// <c>TRUE</c> to direct the system to complete the change of active window. If the window is minimized when this message is
		/// received, the application should pass the message to the <c>DefWindowProc</c> function.
		/// </para>
		/// <para>
		/// The <c>DefWindowProc</c> function draws the title bar or icon title in its active colors when the wParam parameter is <c>TRUE</c>
		/// and in its inactive colors when wParam is <c>FALSE</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-ncactivate
		[MsgParams(typeof(BOOL), typeof(IntPtr))]
		WM_NCACTIVATE = 0x0086,

		/// <summary>
		/// <para>
		/// Sent to the window procedure associated with a control. By default, the system handles all keyboard input to the control; the
		/// system interprets certain types of keyboard input as dialog box navigation keys. To override this default behavior, the control
		/// can respond to the <c>WM_GETDLGCODE</c> message to indicate the types of input it wants to process itself.
		/// </para>
		/// <para>
		/// <code>#define WM_GETDLGCODE 0x0087</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The virtual key, pressed by the user, that prompted Windows to issue this notification. The handler must selectively handle these
		/// keys. For instance, the handler might accept and process <c>VK_RETURN</c> but delegate <c>VK_TAB</c> to the owner window. For a
		/// list of values, see <c>Virtual-Key Codes</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to an <c>MSG</c> structure (or <c>NULL</c> if the system is performing a query).</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is one or more of the following values, indicating which type of input the application processes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>DLGC_BUTTON</c> 0x2000</term>
		/// <term>Button.</term>
		/// </item>
		/// <item>
		/// <term><c>DLGC_DEFPUSHBUTTON</c> 0x0010</term>
		/// <term>Default push button.</term>
		/// </item>
		/// <item>
		/// <term><c>DLGC_HASSETSEL</c> 0x0008</term>
		/// <term><c>EM_SETSEL</c> messages.</term>
		/// </item>
		/// <item>
		/// <term><c>DLGC_RADIOBUTTON</c> 0x0040</term>
		/// <term>Radio button.</term>
		/// </item>
		/// <item>
		/// <term><c>DLGC_STATIC</c> 0x0100</term>
		/// <term>Static control.</term>
		/// </item>
		/// <item>
		/// <term><c>DLGC_UNDEFPUSHBUTTON</c> 0x0020</term>
		/// <term>Non-default push button.</term>
		/// </item>
		/// <item>
		/// <term><c>DLGC_WANTALLKEYS</c> 0x0004</term>
		/// <term>All keyboard input.</term>
		/// </item>
		/// <item>
		/// <term><c>DLGC_WANTARROWS</c> 0x0001</term>
		/// <term>Direction keys.</term>
		/// </item>
		/// <item>
		/// <term><c>DLGC_WANTCHARS</c> 0x0080</term>
		/// <term><c>WM_CHAR</c> messages.</term>
		/// </item>
		/// <item>
		/// <term><c>DLGC_WANTMESSAGE</c> 0x0004</term>
		/// <term>All keyboard input (the application passes this message in the <c>MSG</c> structure to the control).</term>
		/// </item>
		/// <item>
		/// <term><c>DLGC_WANTTAB</c> 0x0002</term>
		/// <term>TAB key.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Although the <c>DefWindowProc</c> function always returns zero in response to the <c>WM_GETDLGCODE</c> message, the window
		/// procedure for the predefined control classes return a code appropriate for each class.
		/// </para>
		/// <para>
		/// The <c>WM_GETDLGCODE</c> message and the returned values are useful only with user-defined dialog box controls or standard
		/// controls modified by subclassing.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dlgbox/wm-getdlgcode
		[MsgParams(typeof(VK), typeof(MSG?), LResultType = typeof(DLGC))]
		WM_GETDLGCODE = 0x0087,

		/// <summary>
		/// <para>The <c>WM_SYNCPAINT</c> message is used to synchronize painting while avoiding linking independent GUI threads.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application returns zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// When a window has been hidden, shown, moved, or sized, the system may determine that it is necessary to send a
		/// <c>WM_SYNCPAINT</c> message to the top-level windows of other threads. Applications must pass <c>WM_SYNCPAINT</c> to
		/// <c>DefWindowProc</c> for processing. The <c>DefWindowProc</c> function will send a <c>WM_NCPAINT</c> message to the window
		/// procedure if the window frame must be painted and send a <c>WM_ERASEBKGND</c> message if the window background must be erased.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/gdi/wm-syncpaint
		[MsgParams()]
		WM_SYNCPAINT = 0x0088,

		/// <summary/>
		WM_UAHDESTROYWINDOW = 0x0090,

		/// <summary/>
		WM_UAHDRAWMENU = 0x0091,

		/// <summary/>
		WM_UAHDRAWMENUITEM = 0x0092,

		/// <summary/>
		WM_UAHINITMENU = 0x0093,

		/// <summary/>
		WM_UAHMEASUREMENUITEM = 0x0094,

		/// <summary/>
		WM_UAHNCPAINTMENUPOPUP = 0x0095,

		/// <summary>
		/// <para>
		/// Posted to a window when the cursor is moved within the nonclient area of the window. This message is posted to the window that
		/// contains the cursor. If a window has captured the mouse, this message is not posted.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCMOUSEMOVE 0x00A0</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The hit-test value returned by the <c>DefWindowProc</c> function as a result of processing the <c>WM_NCHITTEST</c> message. For a
		/// list of hit-test values, see <c>WM_NCHITTEST</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A <c>POINTS</c> structure that contains the x- and y-coordinates of the cursor. The coordinates are relative to the upper-left
		/// corner of the screen.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>If it is appropriate to do so, the system sends the <c>WM_SYSCOMMAND</c> message to the window.</para>
		/// <para>
		/// You can also use the <c>GET_X_LPARAM</c> and <c>GET_Y_LPARAM</c> macros to extract the values of the x- and y- coordinates from lParam.
		/// </para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncmousemove
		[MsgParams(typeof(HitTestValues), typeof(POINTS?))]
		WM_NCMOUSEMOVE = 0x00A0,

		/// <summary>
		/// <para>
		/// Posted when the user presses the left mouse button while the cursor is within the nonclient area of a window. This message is
		/// posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCLBUTTONDOWN 0x00A1</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The hit-test value returned by the <c>DefWindowProc</c> function as a result of processing the <c>WM_NCHITTEST</c> message. For a
		/// list of hit-test values, see <c>WM_NCHITTEST</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A <c>POINTS</c> structure that contains the x- and y-coordinates of the cursor. The coordinates are relative to the upper-left
		/// corner of the screen.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>DefWindowProc</c> function tests the specified point to find the location of the cursor and performs the appropriate
		/// action. If appropriate, <c>DefWindowProc</c> sends the <c>WM_SYSCOMMAND</c> message to the window.
		/// </para>
		/// <para>
		/// You can also use the <c>GET_X_LPARAM</c> and <c>GET_Y_LPARAM</c> macros to extract the values of the x- and y- coordinates from lParam.
		/// </para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nclbuttondown
		[MsgParams(typeof(HitTestValues), typeof(POINTS?))]
		WM_NCLBUTTONDOWN = 0x00A1,

		/// <summary>
		/// <para>
		/// Posted when the user releases the left mouse button while the cursor is within the nonclient area of a window. This message is
		/// posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCLBUTTONUP 0x00A2</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The hit-test value returned by the <c>DefWindowProc</c> function as a result of processing the <c>WM_NCHITTEST</c> message. For a
		/// list of hit-test values, see <c>WM_NCHITTEST</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A <c>POINTS</c> structure that contains the x- and y-coordinates of the cursor. The coordinates are relative to the upper-left
		/// corner of the screen.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>DefWindowProc</c> function tests the specified point to find out the location of the cursor and performs the appropriate
		/// action. If appropriate, <c>DefWindowProc</c> sends the <c>WM_SYSCOMMAND</c> message to the window.
		/// </para>
		/// <para>
		/// You can also use the <c>GET_X_LPARAM</c> and <c>GET_Y_LPARAM</c> macros to extract the values of the x- and y- coordinates from lParam.
		/// </para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>If it is appropriate to do so, the system sends the <c>WM_SYSCOMMAND</c> message to the window.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nclbuttonup
		[MsgParams(typeof(HitTestValues), typeof(POINTS?))]
		WM_NCLBUTTONUP = 0x00A2,

		/// <summary>
		/// <para>
		/// Posted when the user double-clicks the left mouse button while the cursor is within the nonclient area of a window. This message
		/// is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCLBUTTONDBLCLK 0x00A3</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The hit-test value returned by the <c>DefWindowProc</c> function as a result of processing the <c>WM_NCHITTEST</c> message. For a
		/// list of hit-test values, see <c>WM_NCHITTEST</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A <c>POINTS</c> structure that contains the x- and y-coordinates of the cursor. The coordinates are relative to the upper-left
		/// corner of the screen.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can also use the <c>GET_X_LPARAM</c> and <c>GET_Y_LPARAM</c> macros to extract the values of the x- and y- coordinates from lParam.
		/// </para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>
		/// By default, the <c>DefWindowProc</c> function tests the specified point to find out the location of the cursor and performs the
		/// appropriate action. If appropriate, <c>DefWindowProc</c> sends the <c>WM_SYSCOMMAND</c> message to the window.
		/// </para>
		/// <para>A window need not have the <c>CS_DBLCLKS</c> style to receive <c>WM_NCLBUTTONDBLCLK</c> messages.</para>
		/// <para>
		/// The system generates a <c>WM_NCLBUTTONDBLCLK</c> message when the user presses, releases, and again presses the left mouse button
		/// within the system's double-click time limit. Double-clicking the left mouse button actually generates four messages:
		/// <c>WM_NCLBUTTONDOWN</c>, <c>WM_NCLBUTTONUP</c>, <c>WM_NCLBUTTONDBLCLK</c>, and <c>WM_NCLBUTTONUP</c> again.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nclbuttondblclk
		[MsgParams(typeof(HitTestValues), typeof(POINTS?))]
		WM_NCLBUTTONDBLCLK = 0x00A3,

		/// <summary>
		/// <para>
		/// Posted when the user presses the right mouse button while the cursor is within the nonclient area of a window. This message is
		/// posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCRBUTTONDOWN 0x00A4</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The hit-test value returned by the <c>DefWindowProc</c> function as a result of processing the <c>WM_NCHITTEST</c> message. For a
		/// list of hit-test values, see <c>WM_NCHITTEST</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A <c>POINTS</c> structure that contains the x- and y-coordinates of the cursor. The coordinates are relative to the upper-left
		/// corner of the screen.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can also use the <c>GET_X_LPARAM</c> and <c>GET_Y_LPARAM</c> macros to extract the values of the x- and y- coordinates from lParam.
		/// </para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>If it is appropriate to do so, the system sends the <c>WM_SYSCOMMAND</c> message to the window.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncrbuttondown
		[MsgParams(typeof(HitTestValues), typeof(POINTS?))]
		WM_NCRBUTTONDOWN = 0x00A4,

		/// <summary>
		/// <para>
		/// Posted when the user releases the right mouse button while the cursor is within the nonclient area of a window. This message is
		/// posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCRBUTTONUP 0x00A5</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The hit-test value returned by the <c>DefWindowProc</c> function as a result of processing the <c>WM_NCHITTEST</c> message. For a
		/// list of hit-test values, see <c>WM_NCHITTEST</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A <c>POINTS</c> structure that contains the x- and y-coordinates of the cursor. The coordinates are relative to the upper-left
		/// corner of the screen.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can also use the <c>GET_X_LPARAM</c> and <c>GET_Y_LPARAM</c> macros to extract the values of the x- and y- coordinates from lParam.
		/// </para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>If it is appropriate to do so, the system sends the <c>WM_SYSCOMMAND</c> message to the window.</para>
		/// </remarks>
		[MsgParams(typeof(HitTestValues), typeof(POINTS?))]
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncrbuttonup
		WM_NCRBUTTONUP = 0x00A5,

		/// <summary>
		/// <para>
		/// Posted when the user double-clicks the right mouse button while the cursor is within the nonclient area of a window. This message
		/// is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCRBUTTONDBLCLK 0x00A6</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The hit-test value returned by the <c>DefWindowProc</c> function as a result of processing the <c>WM_NCHITTEST</c> message. For a
		/// list of hit-test values, see <c>WM_NCHITTEST</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A <c>POINTS</c> structure that contains the x- and y-coordinates of the cursor. The coordinates are relative to the upper-left
		/// corner of the screen.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>A window need not have the <c>CS_DBLCLKS</c> style to receive <c>WM_NCRBUTTONDBLCLK</c> messages.</para>
		/// <para>
		/// The system generates a <c>WM_NCRBUTTONDBLCLK</c> message when the user presses, releases, and again presses the right mouse
		/// button within the system's double-click time limit. Double-clicking the right mouse button actually generates four messages:
		/// <c>WM_NCRBUTTONDOWN</c>, <c>WM_NCRBUTTONUP</c>, <c>WM_NCRBUTTONDBLCLK</c>, and <c>WM_NCRBUTTONUP</c> again.
		/// </para>
		/// <para>
		/// You can also use the <c>GET_X_LPARAM</c> and <c>GET_Y_LPARAM</c> macros to extract the values of the x- and y- coordinates from lParam.
		/// </para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>If it is appropriate to do so, the system sends the <c>WM_SYSCOMMAND</c> message to the window.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncrbuttondblclk
		[MsgParams(typeof(HitTestValues), typeof(POINTS?))]
		WM_NCRBUTTONDBLCLK = 0x00A6,

		/// <summary>
		/// <para>
		/// Posted when the user presses the middle mouse button while the cursor is within the nonclient area of a window. This message is
		/// posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCMBUTTONDOWN 0x00A7</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The hit-test value returned by the <c>DefWindowProc</c> function as a result of processing the <c>WM_NCHITTEST</c> message. For a
		/// list of hit-test values, see <c>WM_NCHITTEST</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A <c>POINTS</c> structure that contains the x- and y-coordinates of the cursor. The coordinates are relative to the upper-left
		/// corner of the screen.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can also use the <c>GET_X_LPARAM</c> and <c>GET_Y_LPARAM</c> macros to extract the values of the x- and y- coordinates from lParam.
		/// </para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>If it is appropriate to do so, the system sends the <c>WM_SYSCOMMAND</c> message to the window.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncmbuttondown
		[MsgParams(typeof(HitTestValues), typeof(POINTS?))]
		WM_NCMBUTTONDOWN = 0x00A7,

		/// <summary>
		/// <para>
		/// Posted when the user releases the middle mouse button while the cursor is within the nonclient area of a window. This message is
		/// posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCMBUTTONUP 0x00A8</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The hit-test value returned by the <c>DefWindowProc</c> function as a result of processing the <c>WM_NCHITTEST</c> message. For a
		/// list of hit-test values, see <c>WM_NCHITTEST</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A <c>POINTS</c> structure that contains the x- and y-coordinates of the cursor. The coordinates are relative to the upper-left
		/// corner of the screen.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can also use the <c>GET_X_LPARAM</c> and <c>GET_Y_LPARAM</c> macros to extract the values of the x- and y- coordinates from lParam.
		/// </para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>If it is appropriate to do so, the system sends the <c>WM_SYSCOMMAND</c> message to the window.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncmbuttonup
		[MsgParams(typeof(HitTestValues), typeof(POINTS?))]
		WM_NCMBUTTONUP = 0x00A8,

		/// <summary>
		/// <para>
		/// Posted when the user double-clicks the middle mouse button while the cursor is within the nonclient area of a window. This
		/// message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCMBUTTONDBLCLK 0x00A9</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The hit-test value returned by the <c>DefWindowProc</c> function as a result of processing the <c>WM_NCHITTEST</c> message. For a
		/// list of hit-test values, see <c>WM_NCHITTEST</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A <c>POINTS</c> structure that contains the x- and y-coordinates of the cursor. The coordinates are relative to the upper-left
		/// corner of the screen.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>A window need not have the <c>CS_DBLCLKS</c> style to receive <c>WM_NCMBUTTONDBLCLK</c> messages.</para>
		/// <para>
		/// The system generates a <c>WM_NCMBUTTONDBLCLK</c> message when the user presses, releases, and again presses the middle mouse
		/// button within the system's double-click time limit. Double-clicking the middle mouse button actually generates four messages:
		/// <c>WM_NCMBUTTONDOWN</c>, <c>WM_NCMBUTTONUP</c>, <c>WM_NCMBUTTONDBLCLK</c>, and <c>WM_NCMBUTTONUP</c> again.
		/// </para>
		/// <para>
		/// You can also use the <c>GET_X_LPARAM</c> and <c>GET_Y_LPARAM</c> macros to extract the values of the x- and y- coordinates from lParam.
		/// </para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>If it is appropriate to do so, the system sends the <c>WM_SYSCOMMAND</c> message to the window.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncmbuttondblclk
		[MsgParams(typeof(HitTestValues), typeof(POINTS?))]
		WM_NCMBUTTONDBLCLK = 0x00A9,

		/// <summary>
		/// <para>
		/// Posted when the user presses the first or second X button while the cursor is in the nonclient area of a window. This message is
		/// posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCXBUTTONDOWN 0x00AB</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The low-order word specifies the hit-test value returned by the <c>DefWindowProc</c> function from processing the
		/// <c>WM_NCHITTEST</c> message. For a list of hit-test values, see <c>WM_NCHITTEST</c>. The high-order word indicates which button
		/// was pressed. It can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>XBUTTON1</c> 0x0001</term>
		/// <term>The first X button was pressed.</term>
		/// </item>
		/// <item>
		/// <term><c>XBUTTON2</c> 0x0002</term>
		/// <term>The second X button was pressed.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>POINTS</c> structure that contains the x- and y-coordinates of the cursor. The coordinates are relative to the
		/// upper-left corner of the screen.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If an application processes this message, it should return <c>TRUE</c>. For more information about processing the return value,
		/// see the Remarks section.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>Use the following code to get the information in the wParam parameter.</para>
		/// <para>
		/// <code>nHittest = GET_NCHITTEST_WPARAM(wParam); fwButton = GET_XBUTTON_WPARAM(wParam);</code>
		/// </para>
		/// <para>You can also use the following code to get the x- and y-coordinates from lParam:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>
		/// By default, the <c>DefWindowProc</c> function tests the specified point to get the position of the cursor and performs the
		/// appropriate action. If appropriate, it sends the <c>WM_SYSCOMMAND</c> message to the window.
		/// </para>
		/// <para>
		/// Unlike the <c>WM_NCLBUTTONDOWN</c>, <c>WM_NCMBUTTONDOWN</c>, and <c>WM_NCRBUTTONDOWN</c> messages, an application should return
		/// <c>TRUE</c> from this message if it processes it. Doing so will allow software that simulates this message on Windows systems
		/// earlier than Windows 2000 to determine whether the window procedure processed the message or called <c>DefWindowProc</c> to
		/// process it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncxbuttondown
		[MsgParams(typeof(HitTestValues), typeof(POINTS?))]
		WM_NCXBUTTONDOWN = 0x00AB,

		/// <summary>
		/// <para>
		/// Posted when the user releases the first or second X button while the cursor is in the nonclient area of a window. This message is
		/// posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCXBUTTONUP 0x00AC</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The low-order word specifies the hit-test value returned by the <c>DefWindowProc</c> function from processing the
		/// <c>WM_NCHITTEST</c> message. For a list of hit-test values, see <c>WM_NCHITTEST</c>.
		/// </para>
		/// <para>The high-order word indicates which button was released. It can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>XBUTTON1</c> 0x0001</term>
		/// <term>The first X button was released.</term>
		/// </item>
		/// <item>
		/// <term><c>XBUTTON2</c> 0x0002</term>
		/// <term>The second X button was released.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>POINTS</c> structure that contains the x- and y-coordinates of the cursor. The coordinates are relative to the
		/// upper-left corner of the screen.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If an application processes this message, it should return <c>TRUE</c>. For more information about processing the return value,
		/// see the Remarks section.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>Use the following code to get the information in the wParam parameter.</para>
		/// <para>
		/// <code>nHittest = GET_NCHITTEST_WPARAM(wParam); fwButton = GET_XBUTTON_WPARAM(wParam);</code>
		/// </para>
		/// <para>You can also use the following code to get the x- and y-coordinates from lParam:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>
		/// By default, the <c>DefWindowProc</c> function tests the specified point to get the position of the cursor and performs the
		/// appropriate action. If appropriate, it sends the <c>WM_SYSCOMMAND</c> message to the window.
		/// </para>
		/// <para>
		/// Unlike the <c>WM_NCLBUTTONUP</c>, <c>WM_NCMBUTTONUP</c>, and <c>WM_NCRBUTTONUP</c> messages, an application should return
		/// <c>TRUE</c> from this message if it processes it. Doing so will allow software that simulates this message on Windows systems
		/// earlier than Windows 2000 to determine whether the window procedure processed the message or called <c>DefWindowProc</c> to
		/// process it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncxbuttonup
		WM_NCXBUTTONUP = 0x00AC,

		/// <summary>
		/// <para>
		/// Posted when the user double-clicks the first or second X button while the cursor is in the nonclient area of a window. This
		/// message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCXBUTTONDBLCLK 0x00AD</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The low-order word specifies the hit-test value returned by the <c>DefWindowProc</c> function from processing the
		/// <c>WM_NCHITTEST</c> message. For a list of hit-test values, see <c>WM_NCHITTEST</c>.
		/// </para>
		/// <para>The high-order word indicates which button was double-clicked. It can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>XBUTTON1</c> 0x0001</term>
		/// <term>The first X button was double-clicked..</term>
		/// </item>
		/// <item>
		/// <term><c>XBUTTON2</c> 0x0002</term>
		/// <term>The second X button was double-clicked.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>POINTS</c> structure that contains the x- and y-coordinates of the cursor. The coordinates are relative to the
		/// upper-left corner of the screen.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If an application processes this message, it should return <c>TRUE</c>. For more information about processing the return value,
		/// see the Remarks section.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>Use the following code to get the information in the wParam parameter.</para>
		/// <para>
		/// <code>nHittest = GET_NCHITTEST_WPARAM(wParam); fwButton = GET_XBUTTON_WPARAM(wParam);</code>
		/// </para>
		/// <para>You can also use the following code to get the x- and y-coordinates from lParam:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>
		/// By default, the <c>DefWindowProc</c> function tests the specified point to get the position of the cursor and performs the
		/// appropriate action. If appropriate, it sends the <c>WM_SYSCOMMAND</c> message to the window.
		/// </para>
		/// <para>
		/// A window need not have the <c>CS_DBLCLKS</c> style to receive <c>WM_NCXBUTTONDBLCLK</c> messages. The system generates a
		/// <c>WM_NCXBUTTONDBLCLK</c> message when the user presses, releases, and again presses an X button within the system's double-click
		/// time limit. Double-clicking one of these buttons actually generates four messages: <c>WM_NCXBUTTONDOWN</c>,
		/// <c>WM_NCXBUTTONUP</c>, <c>WM_NCXBUTTONDBLCLK</c>, and <c>WM_NCXBUTTONUP</c> again.
		/// </para>
		/// <para>
		/// Unlike the <c>WM_NCLBUTTONDBLCLK</c>, <c>WM_NCMBUTTONDBLCLK</c>, and <c>WM_NCRBUTTONDBLCLK</c> messages, an application should
		/// return <c>TRUE</c> from this message if it processes it. Doing so will allow software that simulates this message on Windows
		/// systems earlier than Windows 2000 to determine whether the window procedure processed the message or called <c>DefWindowProc</c>
		/// to process it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncxbuttondblclk
		[MsgParams(typeof(HitTestValues), typeof(POINTS?))]
		WM_NCXBUTTONDBLCLK = 0x00AD,

		/// <summary>
		/// Simulates the user clicking a button. This message causes the button to receive the <c>WM_LBUTTONDOWN</c> and <c>WM_LBUTTONUP</c>
		/// messages, and the button's parent window to receive a BN_CLICKED notification code.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// </summary>
		/// <remarks>
		/// If the button is in a dialog box and the dialog box is not active, the <c>BM_CLICK</c> message might fail. To ensure success in
		/// this situation, call the <c>SetActiveWindow</c> function to activate the dialog box before sending the <c>BM_CLICK</c> message to
		/// the button.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/bm-click
		[MsgParams()]
		WM_BM_CLICK = 0x00F5,

		/// <summary>
		/// <para>Sent to the window that registered to receive raw input.</para>
		/// <para>Raw input notifications are available only after the application calls RegisterRawInputDevices with RIDEV_DEVNOTIFY flag.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_INPUT_DEVICE_CHANGE 0x00FE</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>GIDC_ARRIVAL</c> 1</term>
		/// <term>A new device has been added to the system. You can call GetRawInputDeviceInfo to get more information regarding the device.</term>
		/// </item>
		/// <item>
		/// <term><c>GIDC_REMOVAL</c> 2</term>
		/// <term>A device has been removed from the system.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>The <c>HANDLE</c> to the raw input device.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-input-device-change
		[MsgParams(typeof(GIDC), typeof(HANDLE))]
		WM_INPUT_DEVICE_CHANGE = 0x00FE,

		/// <summary>
		/// <para>Sent to the window that is getting raw input.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_INPUT 0x00FF</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The input code. Use <c>GET_RAWINPUT_CODE_WPARAM</c> macro to get the value.</para>
		/// <para>Can be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>RIM_INPUT</c> 0</term>
		/// <term>
		/// Input occurred while the application was in the foreground. The application must call <c>DefWindowProc</c> so the system can
		/// perform cleanup.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>RIM_INPUTSINK</c> 1</term>
		/// <term>Input occurred while the application was not in the foreground.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A <c>HRAWINPUT</c> handle to the <c>RAWINPUT</c> structure that contains the raw input from the device. To get the raw data, use
		/// this handle in the call to <c>GetRawInputData</c>.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>Raw input is available only when the application calls <c>RegisterRawInputDevices</c> with valid device specifications.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-input
		[MsgParams(typeof(RIM_CODE), typeof(HRAWINPUT))]
		WM_INPUT = 0x00FF,

		/// <summary>
		/// <para>
		/// Posted to the window with the keyboard focus when a nonsystem key is pressed. A nonsystem key is a key that is pressed when the
		/// ALT key is not pressed.
		/// </para>
		/// <para>
		/// <code>#define WM_KEYDOWN 0x0100</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The virtual-key code of the nonsystem key. See Virtual-Key Codes.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag, as shown following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bits</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0-15</term>
		/// <term>
		/// The repeat count for the current message. The value is the number of times the keystroke is autorepeated as a result of the user
		/// holding down the key. If the keystroke is held long enough, multiple messages are sent. However, the repeat count is not cumulative.
		/// </term>
		/// </item>
		/// <item>
		/// <term>16-23</term>
		/// <term>The scan code. The value depends on the OEM.</term>
		/// </item>
		/// <item>
		/// <term>24</term>
		/// <term>
		/// Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key
		/// keyboard. The value is 1 if it is an extended key; otherwise, it is 0.
		/// </term>
		/// </item>
		/// <item>
		/// <term>25-28</term>
		/// <term>Reserved; do not use.</term>
		/// </item>
		/// <item>
		/// <term>29</term>
		/// <term>The context code. The value is always 0 for a <c>WM_KEYDOWN</c> message.</term>
		/// </item>
		/// <item>
		/// <term>30</term>
		/// <term>The previous key state. The value is 1 if the key is down before the message is sent, or it is zero if the key is up.</term>
		/// </item>
		/// <item>
		/// <term>31</term>
		/// <term>The transition state. The value is always 0 for a <c>WM_KEYDOWN</c> message.</term>
		/// </item>
		/// </list>
		/// <para>For more detail, see Keystroke Message Flags.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the F10 key is pressed, the <c>DefWindowProc</c> function sets an internal flag. When <c>DefWindowProc</c> receives the
		/// <c>WM_KEYUP</c> message, the function checks whether the internal flag is set and, if so, sends a <c>WM_SYSCOMMAND</c> message to
		/// the top-level window. The <c>WM_SYSCOMMAND</c> parameter of the message is set to SC_KEYMENU.
		/// </para>
		/// <para>
		/// Because of the autorepeat feature, more than one <c>WM_KEYDOWN</c> message may be posted before a <c>WM_KEYUP</c> message is
		/// posted. The previous key state (bit 30) can be used to determine whether the <c>WM_KEYDOWN</c> message indicates the first down
		/// transition or a repeated down transition.
		/// </para>
		/// <para>
		/// For enhanced 101- and 102-key keyboards, extended keys are the right ALT and CTRL keys on the main section of the keyboard; the
		/// INS, DEL, HOME, END, PAGE UP, PAGE DOWN, and arrow keys in the clusters to the left of the numeric keypad; and the divide (/) and
		/// ENTER keys in the numeric keypad. Other keyboards may support the extended-key bit in the lParam parameter.
		/// </para>
		/// <para>Applications must pass wParam to <c>TranslateMessage</c> without altering it at all.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-keydown
		WM_KEYFIRST = 0x0100,

		/// <summary>
		/// <para>
		/// Posted to the window with the keyboard focus when a nonsystem key is pressed. A nonsystem key is a key that is pressed when the
		/// ALT key is not pressed.
		/// </para>
		/// <para>
		/// <code>#define WM_KEYDOWN 0x0100</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The virtual-key code of the nonsystem key. See Virtual-Key Codes.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag, as shown following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bits</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0-15</term>
		/// <term>
		/// The repeat count for the current message. The value is the number of times the keystroke is autorepeated as a result of the user
		/// holding down the key. If the keystroke is held long enough, multiple messages are sent. However, the repeat count is not cumulative.
		/// </term>
		/// </item>
		/// <item>
		/// <term>16-23</term>
		/// <term>The scan code. The value depends on the OEM.</term>
		/// </item>
		/// <item>
		/// <term>24</term>
		/// <term>
		/// Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key
		/// keyboard. The value is 1 if it is an extended key; otherwise, it is 0.
		/// </term>
		/// </item>
		/// <item>
		/// <term>25-28</term>
		/// <term>Reserved; do not use.</term>
		/// </item>
		/// <item>
		/// <term>29</term>
		/// <term>The context code. The value is always 0 for a <c>WM_KEYDOWN</c> message.</term>
		/// </item>
		/// <item>
		/// <term>30</term>
		/// <term>The previous key state. The value is 1 if the key is down before the message is sent, or it is zero if the key is up.</term>
		/// </item>
		/// <item>
		/// <term>31</term>
		/// <term>The transition state. The value is always 0 for a <c>WM_KEYDOWN</c> message.</term>
		/// </item>
		/// </list>
		/// <para>For more detail, see Keystroke Message Flags.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the F10 key is pressed, the <c>DefWindowProc</c> function sets an internal flag. When <c>DefWindowProc</c> receives the
		/// <c>WM_KEYUP</c> message, the function checks whether the internal flag is set and, if so, sends a <c>WM_SYSCOMMAND</c> message to
		/// the top-level window. The <c>WM_SYSCOMMAND</c> parameter of the message is set to SC_KEYMENU.
		/// </para>
		/// <para>
		/// Because of the autorepeat feature, more than one <c>WM_KEYDOWN</c> message may be posted before a <c>WM_KEYUP</c> message is
		/// posted. The previous key state (bit 30) can be used to determine whether the <c>WM_KEYDOWN</c> message indicates the first down
		/// transition or a repeated down transition.
		/// </para>
		/// <para>
		/// For enhanced 101- and 102-key keyboards, extended keys are the right ALT and CTRL keys on the main section of the keyboard; the
		/// INS, DEL, HOME, END, PAGE UP, PAGE DOWN, and arrow keys in the clusters to the left of the numeric keypad; and the divide (/) and
		/// ENTER keys in the numeric keypad. Other keyboards may support the extended-key bit in the lParam parameter.
		/// </para>
		/// <para>Applications must pass wParam to <c>TranslateMessage</c> without altering it at all.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-keydown
		[MsgParams(typeof(VK), typeof(WM_KEY_LPARAM))]
		WM_KEYDOWN = 0x0100,

		/// <summary>
		/// <para>
		/// Posted to the window with the keyboard focus when a nonsystem key is released. A nonsystem key is a key that is pressed when the
		/// ALT key is not pressed, or a keyboard key that is pressed when a window has the keyboard focus.
		/// </para>
		/// <para>
		/// <code>#define WM_KEYUP 0x0101</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The virtual-key code of the nonsystem key. See Virtual-Key Codes.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag, as shown in the
		/// following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bits</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0-15</term>
		/// <term>
		/// The repeat count for the current message. The value is the number of times the keystroke is autorepeated as a result of the user
		/// holding down the key. The repeat count is always 1 for a <c>WM_KEYUP</c> message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>16-23</term>
		/// <term>The scan code. The value depends on the OEM.</term>
		/// </item>
		/// <item>
		/// <term>24</term>
		/// <term>
		/// Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key
		/// keyboard. The value is 1 if it is an extended key; otherwise, it is 0.
		/// </term>
		/// </item>
		/// <item>
		/// <term>25-28</term>
		/// <term>Reserved; do not use.</term>
		/// </item>
		/// <item>
		/// <term>29</term>
		/// <term>The context code. The value is always 0 for a <c>WM_KEYUP</c> message.</term>
		/// </item>
		/// <item>
		/// <term>30</term>
		/// <term>The previous key state. The value is always 1 for a <c>WM_KEYUP</c> message.</term>
		/// </item>
		/// <item>
		/// <term>31</term>
		/// <term>The transition state. The value is always 1 for a <c>WM_KEYUP</c> message.</term>
		/// </item>
		/// </list>
		/// <para>For more detail, see Keystroke Message Flags.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>DefWindowProc</c> function sends a <c>WM_SYSCOMMAND</c> message to the top-level window if the F10 key or the ALT key was
		/// released. The wParam parameter of the message is set to SC_KEYMENU.
		/// </para>
		/// <para>
		/// For enhanced 101- and 102-key keyboards, extended keys are the right ALT and CTRL keys on the main section of the keyboard; the
		/// INS, DEL, HOME, END, PAGE UP, PAGE DOWN, and arrow keys in the clusters to the left of the numeric keypad; and the divide (/) and
		/// ENTER keys in the numeric keypad. Other keyboards may support the extended-key bit in the lParam parameter.
		/// </para>
		/// <para>Applications must pass wParam to <c>TranslateMessage</c> without altering it at all.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-keyup
		[MsgParams(typeof(VK), typeof(WM_KEY_LPARAM))]
		WM_KEYUP = 0x0101,

		/// <summary>
		/// <para>
		/// Posted to the window with the keyboard focus when a <c>WM_KEYDOWN</c> message is translated by the <c>TranslateMessage</c>
		/// function. The <c>WM_CHAR</c> message contains the character code of the key that was pressed.
		/// </para>
		/// <para>
		/// <code>#define WM_CHAR 0x0102</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The character code of the key.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag, as shown in the
		/// following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bits</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0-15</term>
		/// <term>
		/// The repeat count for the current message. The value is the number of times the keystroke is autorepeated as a result of the user
		/// holding down the key. If the keystroke is held long enough, multiple messages are sent. However, the repeat count is not cumulative.
		/// </term>
		/// </item>
		/// <item>
		/// <term>16-23</term>
		/// <term>The scan code. The value depends on the OEM.</term>
		/// </item>
		/// <item>
		/// <term>24</term>
		/// <term>
		/// Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key
		/// keyboard. The value is 1 if it is an extended key; otherwise, it is 0.
		/// </term>
		/// </item>
		/// <item>
		/// <term>25-28</term>
		/// <term>Reserved; do not use.</term>
		/// </item>
		/// <item>
		/// <term>29</term>
		/// <term>The context code. The value is 1 if the ALT key is held down while the key is pressed; otherwise, the value is 0.</term>
		/// </item>
		/// <item>
		/// <term>30</term>
		/// <term>The previous key state. The value is 1 if the key is down before the message is sent, or it is 0 if the key is up.</term>
		/// </item>
		/// <item>
		/// <term>31</term>
		/// <term>The transition state. The value is 1 if the key is being released, or it is 0 if the key is being pressed.</term>
		/// </item>
		/// </list>
		/// <para>For more detail, see Keystroke Message Flags.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>WM_CHAR</c> message uses Unicode Transformation Format (UTF)-16.</para>
		/// <para>
		/// There is not necessarily a one-to-one correspondence between keys pressed and character messages generated, and so the
		/// information in the high-order word of the lParam parameter is generally not useful to applications. The information in the
		/// high-order word applies only to the most recent <c>WM_KEYDOWN</c> message that precedes the posting of the <c>WM_CHAR</c> message.
		/// </para>
		/// <para>
		/// For enhanced 101- and 102-key keyboards, extended keys are the right ALT and the right CTRL keys on the main section of the
		/// keyboard; the INS, DEL, HOME, END, PAGE UP, PAGE DOWN and arrow keys in the clusters to the left of the numeric keypad; and the
		/// divide (/) and ENTER keys in the numeric keypad. Some other keyboards may support the extended-key bit in the lParam parameter.
		/// </para>
		/// <para>
		/// The <c>WM_UNICHAR</c> message is the same as <c>WM_CHAR</c>, except it uses UTF-32. It is designed to send or post Unicode
		/// characters to ANSI windows, and it can handle Unicode Supplementary Plane characters.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-char
		[MsgParams(typeof(char), typeof(WM_KEY_LPARAM))]
		WM_CHAR = 0x0102,

		/// <summary>
		/// <para>
		/// Posted to the window with the keyboard focus when a <c>WM_KEYUP</c> message is translated by the <c>TranslateMessage</c>
		/// function. <c>WM_DEADCHAR</c> specifies a character code generated by a dead key. A dead key is a key that generates a character,
		/// such as the umlaut (double-dot), that is combined with another character to form a composite character. For example, the umlaut-O
		/// character ( ) is generated by typing the dead key for the umlaut character, and then typing the O key.
		/// </para>
		/// <para>
		/// <code>#define WM_DEADCHAR 0x0103</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The character code generated by the dead key.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag, as shown in the
		/// following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bits</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0-15</term>
		/// <term>
		/// The repeat count for the current message. The value is the number of times the keystroke is autorepeated as a result of the user
		/// holding down the key. If the keystroke is held long enough, multiple messages are sent. However, the repeat count is not cumulative.
		/// </term>
		/// </item>
		/// <item>
		/// <term>16-23</term>
		/// <term>The scan code. The value depends on the OEM.</term>
		/// </item>
		/// <item>
		/// <term>24</term>
		/// <term>
		/// Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key
		/// keyboard. The value is 1 if it is an extended key; otherwise, it is 0.
		/// </term>
		/// </item>
		/// <item>
		/// <term>25-28</term>
		/// <term>Reserved; do not use.</term>
		/// </item>
		/// <item>
		/// <term>29</term>
		/// <term>The context code. The value is 1 if the ALT key is held down while the key is pressed; otherwise, the value is 0.</term>
		/// </item>
		/// <item>
		/// <term>30</term>
		/// <term>The previous key state. The value is 1 if the key is down before the message is sent, or it is 0 if the key is up.</term>
		/// </item>
		/// <item>
		/// <term>31</term>
		/// <term>The transition state. The value is 1 if the key is being released, or it is 0 if the key is being pressed.</term>
		/// </item>
		/// </list>
		/// <para>For more detail, see Keystroke Message Flags.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>WM_DEADCHAR</c> message typically is used by applications to give the user feedback about each key pressed. For example,
		/// an application can display the accent in the current character position without moving the caret.
		/// </para>
		/// <para>
		/// Because there is not necessarily a one-to-one correspondence between keys pressed and character messages generated, the
		/// information in the high-order word of the lParam parameter is generally not useful to applications. The information in the
		/// high-order word applies only to the most recent <c>WM_KEYDOWN</c> message that precedes the posting of the <c>WM_DEADCHAR</c> message.
		/// </para>
		/// <para>
		/// For enhanced 101- and 102-key keyboards, extended keys are the right ALT and the right CTRL keys on the main section of the
		/// keyboard; the INS, DEL, HOME, END, PAGE UP, PAGE DOWN and arrow keys in the clusters to the left of the numeric keypad; and the
		/// divide (/) and ENTER keys in the numeric keypad. Some other keyboards may support the extended-key bit in the lParam parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-deadchar
		[MsgParams(typeof(char), typeof(WM_KEY_LPARAM))]
		WM_DEADCHAR = 0x0103,

		/// <summary>
		/// <para>
		/// Posted to the window with the keyboard focus when the user presses the F10 key (which activates the menu bar) or holds down the
		/// ALT key and then presses another key. It also occurs when no window currently has the keyboard focus; in this case, the
		/// <c>WM_SYSKEYDOWN</c> message is sent to the active window. The window that receives the message can distinguish between these two
		/// contexts by checking the context code in the lParam parameter.
		/// </para>
		/// <para>
		/// <code>#define WM_SYSKEYDOWN 0x0104</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The virtual-key code of the key being pressed. See <c>Virtual-Key Codes</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag, as shown in the
		/// following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bits</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0-15</term>
		/// <term>
		/// The repeat count for the current message. The value is the number of times the keystroke is autorepeated as a result of the user
		/// holding down the key. If the keystroke is held long enough, multiple messages are sent. However, the repeat count is not cumulative.
		/// </term>
		/// </item>
		/// <item>
		/// <term>16-23</term>
		/// <term>The scan code. The value depends on the OEM.</term>
		/// </item>
		/// <item>
		/// <term>24</term>
		/// <term>
		/// Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key
		/// keyboard. The value is 1 if it is an extended key; otherwise, it is 0.
		/// </term>
		/// </item>
		/// <item>
		/// <term>25-28</term>
		/// <term>Reserved; do not use.</term>
		/// </item>
		/// <item>
		/// <term>29</term>
		/// <term>
		/// The context code. The value is 1 if the ALT key is down while the key is pressed; it is 0 if the <c>WM_SYSKEYDOWN</c> message is
		/// posted to the active window because no window has the keyboard focus.
		/// </term>
		/// </item>
		/// <item>
		/// <term>30</term>
		/// <term>The previous key state. The value is 1 if the key is down before the message is sent, or it is 0 if the key is up.</term>
		/// </item>
		/// <item>
		/// <term>31</term>
		/// <term>The transition state. The value is always 0 for a <c>WM_SYSKEYDOWN</c> message.</term>
		/// </item>
		/// </list>
		/// <para>For more detail, see Keystroke Message Flags.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>DefWindowProc</c> function examines the specified key and generates a <c>WM_SYSCOMMAND</c> message if the key is either
		/// TAB or ENTER.
		/// </para>
		/// <para>
		/// When the context code is zero, the message can be passed to the <c>TranslateAccelerator</c> function, which will handle it as
		/// though it were a normal key message instead of a character-key message. This allows accelerator keys to be used with the active
		/// window even if the active window does not have the keyboard focus.
		/// </para>
		/// <para>
		/// Because of automatic repeat, more than one <c>WM_SYSKEYDOWN</c> message may occur before a <c>WM_SYSKEYUP</c> message is sent.
		/// The previous key state (bit 30) can be used to determine whether the <c>WM_SYSKEYDOWN</c> message indicates the first down
		/// transition or a repeated down transition.
		/// </para>
		/// <para>
		/// For enhanced 101- and 102-key keyboards, enhanced keys are the right ALT and CTRL keys on the main section of the keyboard; the
		/// INS, DEL, HOME, END, PAGE UP, PAGE DOWN, and arrow keys in the clusters to the left of the numeric keypad; and the divide (/) and
		/// ENTER keys in the numeric keypad. Other keyboards may support the extended-key bit in the lParam parameter.
		/// </para>
		/// <para>This message is also sent whenever the user presses the F10 key without the ALT key.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-syskeydown
		[MsgParams(typeof(VK), typeof(WM_KEY_LPARAM))]
		WM_SYSKEYDOWN = 0x0104,

		/// <summary>
		/// <para>
		/// Posted to the window with the keyboard focus when the user releases a key that was pressed while the ALT key was held down. It
		/// also occurs when no window currently has the keyboard focus; in this case, the <c>WM_SYSKEYUP</c> message is sent to the active
		/// window. The window that receives the message can distinguish between these two contexts by checking the context code in the
		/// lParam parameter.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_SYSKEYUP 0x0105</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The virtual-key code of the key being released. See <c>Virtual-Key Codes</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag, as shown in the
		/// following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bits</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0-15</term>
		/// <term>
		/// The repeat count for the current message. The value is the number of times the keystroke is autorepeated as a result of the user
		/// holding down the key. The repeat count is always one for a <c>WM_SYSKEYUP</c> message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>16-23</term>
		/// <term>The scan code. The value depends on the OEM.</term>
		/// </item>
		/// <item>
		/// <term>24</term>
		/// <term>
		/// Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key
		/// keyboard. The value is 1 if it is an extended key; otherwise, it is zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>25-28</term>
		/// <term>Reserved; do not use.</term>
		/// </item>
		/// <item>
		/// <term>29</term>
		/// <term>
		/// The context code. The value is 1 if the ALT key is down while the key is released; it is zero if the <c>WM_SYSKEYUP</c> message
		/// is posted to the active window because no window has the keyboard focus.
		/// </term>
		/// </item>
		/// <item>
		/// <term>30</term>
		/// <term>The previous key state. The value is always 1 for a <c>WM_SYSKEYUP</c> message.</term>
		/// </item>
		/// <item>
		/// <term>31</term>
		/// <term>The transition state. The value is always 1 for a <c>WM_SYSKEYUP</c> message.</term>
		/// </item>
		/// </list>
		/// <para>For more details, see Keystroke Message Flags.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>DefWindowProc</c> function sends a <c>WM_SYSCOMMAND</c> message to the top-level window if the F10 key or the ALT key was
		/// released. The wParam parameter of the message is set to <c>SC_KEYMENU</c>.
		/// </para>
		/// <para>
		/// When the context code is zero, the message can be passed to the <c>TranslateAccelerator</c> function, which will handle it as
		/// though it were a normal key message instead of a character-key message. This allows accelerator keys to be used with the active
		/// window even if the active window does not have the keyboard focus.
		/// </para>
		/// <para>
		/// For enhanced 101- and 102-key keyboards, extended keys are the right ALT and CTRL keys on the main section of the keyboard; the
		/// INS, DEL, HOME, END, PAGE UP, PAGE DOWN, and arrow keys in the clusters to the left of the numeric keypad; and the divide (/) and
		/// ENTER keys in the numeric keypad. Other keyboards may support the extended-key bit in the lParam parameter.
		/// </para>
		/// <para>
		/// For non-U.S. enhanced 102-key keyboards, the right ALT key is handled as a CTRL+ALT key. The following table shows the sequence
		/// of messages that result when the user presses and releases this key.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Message</term>
		/// <term>Virtual-key code</term>
		/// </listheader>
		/// <item>
		/// <term><c>WM_KEYDOWN</c></term>
		/// <term><c>VK_CONTROL</c></term>
		/// </item>
		/// <item>
		/// <term><c>WM_KEYDOWN</c></term>
		/// <term><c>VK_MENU</c></term>
		/// </item>
		/// <item>
		/// <term><c>WM_KEYUP</c></term>
		/// <term><c>VK_CONTROL</c></term>
		/// </item>
		/// <item>
		/// <term><c>WM_SYSKEYUP</c></term>
		/// <term><c>VK_MENU</c></term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-syskeyup
		[MsgParams(typeof(VK), typeof(WM_KEY_LPARAM))]
		WM_SYSKEYUP = 0x0105,

		/// <summary>
		/// <para>
		/// Posted to the window with the keyboard focus when a <c>WM_SYSKEYDOWN</c> message is translated by the <c>TranslateMessage</c>
		/// function. It specifies the character code of a system character key that is, a character key that is pressed while the ALT key is down.
		/// </para>
		/// <para>
		/// <code>#define WM_SYSCHAR 0x0106</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The character code of the window menu key.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag, as shown in the
		/// following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bits</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0 15</term>
		/// <term>
		/// The repeat count for the current message. The value is the number of times the keystroke was auto-repeated as a result of the
		/// user holding down the key. If the keystroke is held long enough, multiple messages are sent. However, the repeat count is not cumulative.
		/// </term>
		/// </item>
		/// <item>
		/// <term>16 23</term>
		/// <term>The scan code. The value depends on the original equipment manufacturer (OEM).</term>
		/// </item>
		/// <item>
		/// <term>24</term>
		/// <term>
		/// Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key
		/// keyboard. The value is 1 if it is an extended key; otherwise, it is 0.
		/// </term>
		/// </item>
		/// <item>
		/// <term>25 28</term>
		/// <term>Reserved; do not use.</term>
		/// </item>
		/// <item>
		/// <term>29</term>
		/// <term>The context code. The value is 1 if the ALT key is held down while the key is pressed; otherwise, the value is 0.</term>
		/// </item>
		/// <item>
		/// <term>30</term>
		/// <term>The previous key state. The value is 1 if the key is down before the message is sent, or it is 0 if the key is up.</term>
		/// </item>
		/// <item>
		/// <term>31</term>
		/// <term>The transition state. The value is 1 if the key is being released, or it is 0 if the key is being pressed.</term>
		/// </item>
		/// </list>
		/// <para>For more detail, see Keystroke Message Flags.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When the context code is zero, the message can be passed to the <c>TranslateAccelerator</c> function, which will handle it as
		/// though it were a standard key message instead of a system character-key message. This allows accelerator keys to be used with the
		/// active window even if the active window does not have the keyboard focus.
		/// </para>
		/// <para>
		/// For enhanced 101- and 102-key keyboards, extended keys are the right ALT and CTRL keys on the main section of the keyboard; the
		/// INS, DEL, HOME, END, PAGE UP, PAGE DOWN and arrow keys in the clusters to the left of the numeric keypad; the PRINT SCRN key; the
		/// BREAK key; the NUMLOCK key; and the divide (/) and ENTER keys in the numeric keypad. Other keyboards may support the extended-key
		/// bit in the parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syschar
		[MsgParams(typeof(char), typeof(WM_KEY_LPARAM))]
		WM_SYSCHAR = 0x0106,

		/// <summary>
		/// <para>
		/// Sent to the window with the keyboard focus when a <c>WM_SYSKEYDOWN</c> message is translated by the <c>TranslateMessage</c>
		/// function. <c>WM_SYSDEADCHAR</c> specifies the character code of a system dead key that is, a dead key that is pressed while
		/// holding down the ALT key.
		/// </para>
		/// <para>
		/// <code>#define WM_SYSDEADCHAR 0x0107</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The character code generated by the system dead key that is, a dead key that is pressed while holding down the ALT key.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag, as shown in the
		/// following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bits</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0-15</term>
		/// <term>
		/// The repeat count for the current message. The value is the number of times the keystroke is autorepeated as a result of the user
		/// holding down the key. If the keystroke is held long enough, multiple messages are sent. However, the repeat count is not cumulative.
		/// </term>
		/// </item>
		/// <item>
		/// <term>16-23</term>
		/// <term>The scan code. The value depends on the OEM.</term>
		/// </item>
		/// <item>
		/// <term>24</term>
		/// <term>
		/// Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key
		/// keyboard. The value is 1 if it is an extended key; otherwise, it is 0.
		/// </term>
		/// </item>
		/// <item>
		/// <term>25-28</term>
		/// <term>Reserved; do not use.</term>
		/// </item>
		/// <item>
		/// <term>29</term>
		/// <term>The context code. The value is 1 if the ALT key is held down while the key is pressed; otherwise, the value is 0.</term>
		/// </item>
		/// <item>
		/// <term>30</term>
		/// <term>The previous key state. The value is 1 if the key is down before the message is sent, or it is 0 if the key is up.</term>
		/// </item>
		/// <item>
		/// <term>31</term>
		/// <term>Transition state. The value is 1 if the key is being released, or it is 0 if the key is being pressed.</term>
		/// </item>
		/// </list>
		/// <para>For more detail, see Keystroke Message Flags.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// For enhanced 101- and 102-key keyboards, extended keys are the right ALT and CTRL keys on the main section of the keyboard; the
		/// INS, DEL, HOME, END, PAGE UP, PAGE DOWN, and arrow keys in the clusters to the left of the numeric keypad; and the divide (/) and
		/// ENTER keys in the numeric keypad. Other keyboards may support the extended-key bit in the lParam parameter.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-sysdeadchar
		[MsgParams(typeof(char), typeof(WM_KEY_LPARAM))]
		WM_SYSDEADCHAR = 0x0107,

		/// <summary>
		/// <para>
		/// The <c>WM_UNICHAR</c> message can be used by an application to post input to other windows. This message contains the character
		/// code of the key that was pressed. (Test whether a target app can process <c>WM_UNICHAR</c> messages by sending the message with
		/// wParam set to <c>UNICODE_NOCHAR</c>.)
		/// </para>
		/// <para>
		/// <code>#define WM_UNICHAR 0x0109</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The character code of the key.</para>
		/// <para>
		/// If wParam is <c>UNICODE_NOCHAR</c> and the application processes this message, then return <c>TRUE</c>. The <c>DefWindowProc</c>
		/// function will return <c>FALSE</c> (the default).
		/// </para>
		/// <para>
		/// If wParam is not <c>UNICODE_NOCHAR</c>, return <c>FALSE</c>. The Unicode <c>DefWindowProc</c> posts a <c>WM_CHAR</c> message with
		/// the same parameters and the ANSI <c>DefWindowProc</c> function posts either one or two <c>WM_CHAR</c> messages with the
		/// corresponding ANSI character(s).
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The repeat count, scan code, extended-key flag, context code, previous key-state flag, and transition-state flag, as shown in the
		/// following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bits</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0-15</term>
		/// <term>
		/// The repeat count for the current message. The value is the number of times the keystroke is autorepeated as a result of the user
		/// holding down the key. If the keystroke is held long enough, multiple messages are sent. However, the repeat count is not cumulative.
		/// </term>
		/// </item>
		/// <item>
		/// <term>16-23</term>
		/// <term>The scan code. The value depends on the OEM.</term>
		/// </item>
		/// <item>
		/// <term>24</term>
		/// <term>
		/// Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key
		/// keyboard. The value is 1 if it is an extended key; otherwise, it is 0.
		/// </term>
		/// </item>
		/// <item>
		/// <term>25-28</term>
		/// <term>Reserved; do not use.</term>
		/// </item>
		/// <item>
		/// <term>29</term>
		/// <term>The context code. The value is 1 if the ALT key is held down while the key is pressed; otherwise, the value is 0.</term>
		/// </item>
		/// <item>
		/// <term>30</term>
		/// <term>The previous key state. The value is 1 if the key is down before the message is sent, or it is 0 if the key is up.</term>
		/// </item>
		/// <item>
		/// <term>31</term>
		/// <term>The transition state. The value is 1 if the key is being released, or it is 0 if the key is being pressed.</term>
		/// </item>
		/// </list>
		/// <para>For more detail, see Keystroke Message Flags.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>WM_UNICHAR</c> message is similar to <c>WM_CHAR</c>, but it uses Unicode Transformation Format (UTF)-32, whereas
		/// <c>WM_CHAR</c> uses UTF-16.
		/// </para>
		/// <para>
		/// This message is designed to send or post Unicode characters to ANSI windows and can handle Unicode Supplementary Plane characters.
		/// </para>
		/// <para>
		/// Because there is not necessarily a one-to-one correspondence between keys pressed and character messages generated, the
		/// information in the high-order word of the lParam parameter is generally not useful to applications. The information in the
		/// high-order word applies only to the most recent <c>WM_KEYDOWN</c> message that precedes the posting of the <c>WM_UNICHAR</c> message.
		/// </para>
		/// <para>
		/// For enhanced 101- and 102-key keyboards, extended keys are the right ALT and the right CTRL keys on the main section of the
		/// keyboard; the INS, DEL, HOME, END, PAGE UP, PAGE DOWN and arrow keys in the clusters to the left of the numeric keypad; and the
		/// divide (/) and ENTER keys in the numeric keypad. Some other keyboards may support the extended-key bit in the lParam parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-unichar
		[MsgParams(typeof(char), typeof(WM_KEY_LPARAM))]
		WM_UNICHAR = 0x0109,

		/// <summary>Keyboard message filter value.</summary>
		/// <remarks>
		/// Use the WM_KEYFIRST and WM_KEYLAST messages to filter for keyboard messages when using the GetMessage and PeekMessage functions.
		/// </remarks>
		WM_KEYLAST = 0x0109,

		/// <summary>
		/// <para>
		/// Sent immediately before the IME generates the composition string as a result of a keystroke. A window receives this message
		/// through its WindowProc function.
		/// </para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, WM_IME_STARTCOMPOSITION, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message has no return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This message is a notification to an IME window to open its composition window. An application should process this message if it
		/// displays composition characters itself.
		/// </para>
		/// <para>
		/// If an application has created an IME window, it should pass this message to that window. The <c>DefWindowProc</c> function
		/// processes the message by passing it to the default IME window.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/intl/wm-ime-startcomposition
		[MsgParams()]
		WM_IME_STARTCOMPOSITION = 0x010D,

		/// <summary>
		/// <para>Sent to an application when the IME ends composition. A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, WM_IME_ENDCOMPOSITION, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message has no return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>An application should process this message if it displays composition characters itself.</para>
		/// <para>
		/// If the application has created an IME window, it should pass this message to that window. The <c>DefWindowProc</c> function
		/// processes this message by passing it to the default IME window.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/intl/wm-ime-endcomposition
		[MsgParams()]
		WM_IME_ENDCOMPOSITION = 0x010E,

		/// <summary>
		/// <para>
		/// Sent to an application when the IME changes composition status as a result of a keystroke. A window receives this message through
		/// its WindowProc function.
		/// </para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, WM_IME_COMPOSITION, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hwnd</em></para>
		/// <para>A handle to window.</para>
		/// <para><em>wParam</em></para>
		/// <para>DBCS character representing the latest change to the composition string.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Value specifying how the composition string or character changed. This parameter can be one or more of the following values. For
		/// more information about these values, see IME Composition String Values.
		/// </para>
		/// <list/>
		/// <para>The lParam parameter can also have one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>CS_INSERTCHAR</c></term>
		/// <term>
		/// Insert the <c>wParam</c> composition character at the current insertion point. An application should display the composition
		/// character if it processes this message.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>CS_NOMOVECARET</c></term>
		/// <term>
		/// Do not move the caret position as a result of processing the message. For example, if an IME specifies a combination of
		/// CS_INSERTCHAR and CS_NOMOVECARET, the application should insert the specified character at the current caret position but should
		/// not move the caret to the next position. A subsequent WM_IME_COMPOSITION message with GCS_RESULTSTR will replace this character.
		/// </term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>This message has no return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// An application should process this message if it displays composition characters itself. Otherwise, it should send the message to
		/// the IME window.
		/// </para>
		/// <para>
		/// If the application has created an IME window, it should pass this message to that window. The <c>DefWindowProc</c> function
		/// processes this message by passing it to the default IME window. The IME window processes this message by updating its appearance
		/// based on the change flag specified. An application can call <c>ImmGetCompositionString</c> to retrieve the new composition status.
		/// </para>
		/// <para>
		/// If none of the GCS_ values are set, the message indicates that the current composition has been canceled and applications that
		/// draw the composition string should delete the string.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/intl/wm-ime-composition
		[MsgParams(typeof(HWND), typeof(uint), LResultType = null)]
		WM_IME_COMPOSITION = 0x010F,

		/// <summary/>
		WM_IME_KEYLAST = 0x010F,

		/// <summary>
		/// <para>
		/// Sent to the dialog box procedure immediately before a dialog box is displayed. Dialog box procedures typically use this message
		/// to initialize controls and carry out any other initialization tasks that affect the appearance of the dialog box.
		/// </para>
		/// <para>
		/// <code>#define WM_INITDIALOG 0x0110</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A handle to the control to receive the default keyboard focus. The system assigns the default keyboard focus only if the dialog
		/// box procedure returns <c>TRUE</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Additional initialization data. This data is passed to the system as the lParam parameter in a call to the
		/// <c>CreateDialogIndirectParam</c>, <c>CreateDialogParam</c>, <c>DialogBoxIndirectParam</c>, or <c>DialogBoxParam</c> function used
		/// to create the dialog box. For property sheets, this parameter is a pointer to the <c>PROPSHEETPAGE</c> structure used to create
		/// the page. This parameter is zero if any other dialog box creation function is used.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The dialog box procedure should return <c>TRUE</c> to direct the system to set the keyboard focus to the control specified by
		/// wParam. Otherwise, it should return <c>FALSE</c> to prevent the system from setting the default keyboard focus.
		/// </para>
		/// <para>
		/// The dialog box procedure should return the value directly. The <c>DWL_MSGRESULT</c> value set by the <c>SetWindowLong</c>
		/// function is ignored.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The control to receive the default keyboard focus is always the first control in the dialog box that is visible, not disabled,
		/// and that has the <c>WS_TABSTOP</c> style. When the dialog box procedure returns <c>TRUE</c>, the system checks the control to
		/// ensure that the procedure has not disabled it. If it has been disabled, the system sets the keyboard focus to the next control
		/// that is visible, not disabled, and has the <c>WS_TABSTOP</c>.
		/// </para>
		/// <para>An application can return <c>FALSE</c> only if it has set the keyboard focus to one of the controls of the dialog box.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dlgbox/wm-initdialog
		[MsgParams(typeof(BOOL), typeof(IntPtr), LResultType = typeof(BOOL))]
		WM_INITDIALOG = 0x0110,

		/// <summary>
		/// <para>
		/// Sent when the user selects a command item from a menu, when a control sends a notification message to its parent window, or when
		/// an accelerator keystroke is translated.
		/// </para>
		/// <para>
		/// <code>#define WM_COMMAND 0x0111</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>For a description of this parameter, see Remarks.</para>
		/// <para><em>lParam</em></para>
		/// <para>For a description of this parameter, see Remarks.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>Use of the wParam and lParam parameters are summarized here.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Message Source</term>
		/// <term>wParam (high word)</term>
		/// <term>wParam (low word)</term>
		/// <term>lParam</term>
		/// </listheader>
		/// <item>
		/// <term>Menu</term>
		/// <term>0</term>
		/// <term>Menu identifier (IDM_*)</term>
		/// <term>0</term>
		/// </item>
		/// <item>
		/// <term>Accelerator</term>
		/// <term>1</term>
		/// <term>Accelerator identifier (IDM_*)</term>
		/// <term>0</term>
		/// </item>
		/// <item>
		/// <term>Control</term>
		/// <term>Control-defined notification code</term>
		/// <term>Control identifier</term>
		/// <term>Handle to the control window</term>
		/// </item>
		/// </list>
		/// <para>Menus</para>
		/// <para>
		/// If an application enables a menu separator, the system sends a <c>WM_COMMAND</c> message with the low-word of the wParam
		/// parameter set to zero when the user selects the separator.
		/// </para>
		/// <para>
		/// If a menu is defined with a <c>MENUINFO.dwStyle</c> value of <c>MNS_NOTIFYBYPOS</c>, <c>WM_MENUCOMMAND</c> is sent instead of <c>WM_COMMAND</c>.
		/// </para>
		/// <para>Accelerators</para>
		/// <para>Accelerator keystrokes that select items from the window menu are translated into <c>WM_SYSCOMMAND</c> messages.</para>
		/// <para>
		/// If an accelerator keystroke occurs that corresponds to a menu item when the window that owns the menu is minimized, no
		/// <c>WM_COMMAND</c> message is sent. However, if an accelerator keystroke occurs that does not match any of the items in the
		/// window's menu or in the window menu, a <c>WM_COMMAND</c> message is sent, even if the window is minimized.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-command
		[MsgParams(typeof(uint), typeof(HWND))]
		WM_COMMAND = 0x0111,

		/// <summary>
		/// <para>
		/// A window receives this message when the user chooses a command from the <c>Window</c> menu (formerly known as the system or
		/// control menu) or when the user chooses the maximize button, minimize button, restore button, or close button.
		/// </para>
		/// <para>
		/// <code>#define WM_SYSCOMMAND 0x0112</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The type of system command requested. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SC_CLOSE</c> 0xF060</term>
		/// <term>Closes the window.</term>
		/// </item>
		/// <item>
		/// <term><c>SC_CONTEXTHELP</c> 0xF180</term>
		/// <term>
		/// Changes the cursor to a question mark with a pointer. If the user then clicks a control in the dialog box, the control receives a
		/// <c>WM_HELP</c> message.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SC_DEFAULT</c> 0xF160</term>
		/// <term>Selects the default item; the user double-clicked the window menu.</term>
		/// </item>
		/// <item>
		/// <term><c>SC_HOTKEY</c> 0xF150</term>
		/// <term>
		/// Activates the window associated with the application-specified hot key. The <c>lParam</c> parameter identifies the window to activate.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SC_HSCROLL</c> 0xF080</term>
		/// <term>Scrolls horizontally.</term>
		/// </item>
		/// <item>
		/// <term><c>SCF_ISSECURE</c> 0x00000001</term>
		/// <term>Indicates whether the screen saver is secure.</term>
		/// </item>
		/// <item>
		/// <term><c>SC_KEYMENU</c> 0xF100</term>
		/// <term>Retrieves the window menu as a result of a keystroke. For more information, see the Remarks section.</term>
		/// </item>
		/// <item>
		/// <term><c>SC_MAXIMIZE</c> 0xF030</term>
		/// <term>Maximizes the window.</term>
		/// </item>
		/// <item>
		/// <term><c>SC_MINIMIZE</c> 0xF020</term>
		/// <term>Minimizes the window.</term>
		/// </item>
		/// <item>
		/// <term><c>SC_MONITORPOWER</c> 0xF170</term>
		/// <term>
		/// Sets the state of the display. This command supports devices that have power-saving features, such as a battery-powered personal
		/// computer. The <c>lParam</c> parameter can have the following values:
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SC_MOUSEMENU</c> 0xF090</term>
		/// <term>Retrieves the window menu as a result of a mouse click.</term>
		/// </item>
		/// <item>
		/// <term><c>SC_MOVE</c> 0xF010</term>
		/// <term>Moves the window.</term>
		/// </item>
		/// <item>
		/// <term><c>SC_NEXTWINDOW</c> 0xF040</term>
		/// <term>Moves to the next window.</term>
		/// </item>
		/// <item>
		/// <term><c>SC_PREVWINDOW</c> 0xF050</term>
		/// <term>Moves to the previous window.</term>
		/// </item>
		/// <item>
		/// <term><c>SC_RESTORE</c> 0xF120</term>
		/// <term>Restores the window to its normal position and size.</term>
		/// </item>
		/// <item>
		/// <term><c>SC_SCREENSAVE</c> 0xF140</term>
		/// <term>Executes the screen saver application specified in the [boot] section of the System.ini file.</term>
		/// </item>
		/// <item>
		/// <term><c>SC_SIZE</c> 0xF000</term>
		/// <term>Sizes the window.</term>
		/// </item>
		/// <item>
		/// <term><c>SC_TASKLIST</c> 0xF130</term>
		/// <term>Activates the <c>Start</c> menu.</term>
		/// </item>
		/// <item>
		/// <term><c>SC_VSCROLL</c> 0xF070</term>
		/// <term>Scrolls vertically.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the horizontal position of the cursor, in screen coordinates, if a window menu command is chosen
		/// with the mouse. Otherwise, this parameter is not used.
		/// </para>
		/// <para>
		/// The high-order word specifies the vertical position of the cursor, in screen coordinates, if a window menu command is chosen with
		/// the mouse. This parameter is 1 if the command is chosen using a system accelerator, or zero if using a mnemonic.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>To obtain the position coordinates in screen coordinates, use the following code:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); // horizontal position yPos = GET_Y_LPARAM(lParam); // vertical position</code>
		/// </para>
		/// <para>
		/// The <c>DefWindowProc</c> function carries out the window menu request for the predefined actions specified in the previous table.
		/// </para>
		/// <para>
		/// In <c>WM_SYSCOMMAND</c> messages, the four low-order bits of the wParam parameter are used internally by the system. To obtain
		/// the correct result when testing the value of wParam, an application must combine the value 0xFFF0 with the wParam value by using
		/// the bitwise AND operator.
		/// </para>
		/// <para>
		/// The menu items in a window menu can be modified by using the <c>GetSystemMenu</c>, <c>AppendMenu</c>, <c>InsertMenu</c>,
		/// <c>ModifyMenu</c>, <c>InsertMenuItem</c>, and <c>SetMenuItemInfo</c> functions. Applications that modify the window menu must
		/// process <c>WM_SYSCOMMAND</c> messages.
		/// </para>
		/// <para>
		/// An application can carry out any system command at any time by passing a <c>WM_SYSCOMMAND</c> message to <c>DefWindowProc</c>.
		/// Any <c>WM_SYSCOMMAND</c> messages not handled by the application must be passed to <c>DefWindowProc</c>. Any command values added
		/// by an application must be processed by the application and cannot be passed to <c>DefWindowProc</c>.
		/// </para>
		/// <para>
		/// If password protection is enabled by policy, the screen saver is started regardless of what an application does with the
		/// <c>SC_SCREENSAVE</c> notification even if fails to pass it to <c>DefWindowProc</c>.
		/// </para>
		/// <para>
		/// Accelerator keys that are defined to choose items from the window menu are translated into <c>WM_SYSCOMMAND</c> messages; all
		/// other accelerator keystrokes are translated into <c>WM_COMMAND</c> messages.
		/// </para>
		/// <para>
		/// If the wParam is <c>SC_KEYMENU</c>, lParam contains the character code of the key that is used with the ALT key to display the
		/// popup menu. For example, pressing ALT+F to display the File popup will cause a <c>WM_SYSCOMMAND</c> with wParam equal to
		/// <c>SC_KEYMENU</c> and lParam equal to 'f'.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand
		[MsgParams(typeof(SysCommand), typeof(POINTS))]
		WM_SYSCOMMAND = 0x0112,

		/// <summary>
		/// <para>
		/// Posted to the installing thread's message queue when a timer expires. The message is posted by the <c>GetMessage</c> or
		/// <c>PeekMessage</c> function.
		/// </para>
		/// <para>
		/// <code>#define WM_TIMER 0x0113</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The timer identifier.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to an application-defined callback function that was passed to the <c>SetTimer</c> function when the timer was installed.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can process the message by providing a <c>WM_TIMER</c> case in the window procedure. Otherwise, <c>DispatchMessage</c> will
		/// call the TimerProc callback function specified in the call to the <c>SetTimer</c> function used to install the timer.
		/// </para>
		/// <para>
		/// The <c>WM_TIMER</c> message is a low-priority message. The <c>GetMessage</c> and <c>PeekMessage</c> functions post this message
		/// only when no other higher-priority messages are in the thread's message queue.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-timer
		[MsgParams(typeof(uint), typeof(IntPtr))]
		WM_TIMER = 0x0113,

		/// <summary>
		/// <para>
		/// The <c>WM_HSCROLL</c> message is sent to a window when a scroll event occurs in the window's standard horizontal scroll bar. This
		/// message is also sent to the owner of a horizontal scroll bar control when a scroll event occurs in the control.
		/// </para>
		/// <para>A window receives this message through its WindowProc function.</para>
		/// <para>
		/// <code>WM_HSCROLL WPARAM wParam LPARAM lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The <c>HIWORD</c> specifies the current position of the scroll box if the <c>LOWORD</c> is SB_THUMBPOSITION or SB_THUMBTRACK;
		/// otherwise, this word is not used.
		/// </para>
		/// <para>
		/// The <c>LOWORD</c> specifies a scroll bar value that indicates the user's scrolling request. This word can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SB_ENDSCROLL</c></term>
		/// <term>Ends scroll.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_LEFT</c></term>
		/// <term>Scrolls to the upper left.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_RIGHT</c></term>
		/// <term>Scrolls to the lower right.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_LINELEFT</c></term>
		/// <term>Scrolls left by one unit.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_LINERIGHT</c></term>
		/// <term>Scrolls right by one unit.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_PAGELEFT</c></term>
		/// <term>Scrolls left by the width of the window.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_PAGERIGHT</c></term>
		/// <term>Scrolls right by the width of the window.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_THUMBPOSITION</c></term>
		/// <term>
		/// The user has dragged the scroll box (thumb) and released the mouse button. The <c>HIWORD</c> indicates the position of the scroll
		/// box at the end of the drag operation.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SB_THUMBTRACK</c></term>
		/// <term>
		/// The user is dragging the scroll box. This message is sent repeatedly until the user releases the mouse button. The <c>HIWORD</c>
		/// indicates the position that the scroll box has been dragged to.
		/// </term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// If the message is sent by a scroll bar control, this parameter is the handle to the scroll bar control. If the message is sent by
		/// a standard scroll bar, this parameter is <c>NULL</c>.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>The SB_THUMBTRACK request code is typically used by applications that provide feedback as the user drags the scroll box.</para>
		/// <para>
		/// If an application scrolls the content of the window, it must also reset the position of the scroll box by using the
		/// <c>SetScrollPos</c> function.
		/// </para>
		/// <para>
		/// Note that the <c>WM_HSCROLL</c> message carries only 16 bits of scroll box position data. Thus, applications that rely solely on
		/// <c>WM_HSCROLL</c> (and <c>WM_VSCROLL</c>) for scroll position data have a practical maximum position value of 65,535.
		/// </para>
		/// <para>
		/// However, because the <c>SetScrollInfo</c>, <c>SetScrollPos</c>, <c>SetScrollRange</c>, <c>GetScrollInfo</c>, <c>GetScrollPos</c>,
		/// and <c>GetScrollRange</c> functions support 32-bit scroll bar position data, there is a way to circumvent the 16-bit barrier of
		/// the <c>WM_HSCROLL</c> and <c>WM_VSCROLL</c> messages. See <c>GetScrollInfo</c> for a description of the technique.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/wm-hscroll
		[MsgParams(typeof(SBCMD), typeof(IntPtr))]
		WM_HSCROLL = 0x0114,

		/// <summary>
		/// <para>
		/// The <c>WM_VSCROLL</c> message is sent to a window when a scroll event occurs in the window's standard vertical scroll bar. This
		/// message is also sent to the owner of a vertical scroll bar control when a scroll event occurs in the control.
		/// </para>
		/// <para>A window receives this message through its WindowProc function.</para>
		/// <para>
		/// <code>WM_VSCROLL WPARAM wParam LPARAM lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The <c>HIWORD</c> specifies the current position of the scroll box if the <c>LOWORD</c> is SB_THUMBPOSITION or SB_THUMBTRACK;
		/// otherwise, this word is not used.
		/// </para>
		/// <para>
		/// The <c>LOWORD</c> specifies a scroll bar value that indicates the user's scrolling request. This parameter can be one of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SB_BOTTOM</c></term>
		/// <term>Scrolls to the lower right.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_ENDSCROLL</c></term>
		/// <term>Ends scroll.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_LINEDOWN</c></term>
		/// <term>Scrolls one line down.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_LINEUP</c></term>
		/// <term>Scrolls one line up.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_PAGEDOWN</c></term>
		/// <term>Scrolls one page down.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_PAGEUP</c></term>
		/// <term>Scrolls one page up.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_THUMBPOSITION</c></term>
		/// <term>
		/// The user has dragged the scroll box (thumb) and released the mouse button. The <c>HIWORD</c> indicates the position of the scroll
		/// box at the end of the drag operation.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SB_THUMBTRACK</c></term>
		/// <term>
		/// The user is dragging the scroll box. This message is sent repeatedly until the user releases the mouse button. The <c>HIWORD</c>
		/// indicates the position that the scroll box has been dragged to.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SB_TOP</c></term>
		/// <term>Scrolls to the upper left.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// If the message is sent by a scroll bar control, this parameter is the handle to the scroll bar control. If the message is sent by
		/// a standard scroll bar, this parameter is <c>NULL</c>.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>The SB_THUMBTRACK request code is typically used by applications that provide feedback as the user drags the scroll box.</para>
		/// <para>
		/// If an application scrolls the content of the window, it must also reset the position of the scroll box by using the
		/// <c>SetScrollPos</c> function.
		/// </para>
		/// <para>
		/// Note that the <c>WM_VSCROLL</c> message carries only 16 bits of scroll box position data. Thus, applications that rely solely on
		/// <c>WM_VSCROLL</c> (and <c>WM_HSCROLL</c>) for scroll position data have a practical maximum position value of 65,535.
		/// </para>
		/// <para>
		/// However, because the <c>SetScrollInfo</c>, <c>SetScrollPos</c>, <c>SetScrollRange</c>, <c>GetScrollInfo</c>, <c>GetScrollPos</c>,
		/// and <c>GetScrollRange</c> functions support 32-bit scroll bar position data, there is a way to circumvent the 16-bit barrier of
		/// the <c>WM_HSCROLL</c> and <c>WM_VSCROLL</c> messages. See <c>GetScrollInfo</c> for a description of the technique.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/wm-vscroll
		[MsgParams(typeof(SBCMD), typeof(IntPtr))]
		WM_VSCROLL = 0x0115,

		/// <summary>
		/// <para>
		/// Sent when a menu is about to become active. It occurs when the user clicks an item on the menu bar or presses a menu key. This
		/// allows the application to modify the menu before it is displayed.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_INITMENU 0x0116</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the menu to be initialized.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// A <c>WM_INITMENU</c> message is sent only when a menu is first accessed; only one <c>WM_INITMENU</c> message is generated for
		/// each access. For example, moving the mouse across several menu items while holding down the button does not generate new
		/// messages. <c>WM_INITMENU</c> does not provide information about menu items.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-initmenu
		[MsgParams(typeof(HMENU), null)]
		WM_INITMENU = 0x0116,

		/// <summary>
		/// <para>
		/// Sent when a drop-down menu or submenu is about to become active. This allows an application to modify the menu before it is
		/// displayed, without changing the entire menu.
		/// </para>
		/// <para>
		/// <code>#define WM_INITMENUPOPUP 0x0117</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the drop-down menu or submenu.</para>
		/// <para><em>lParam</em></para>
		/// <para>The low-order word specifies the zero-based relative position of the menu item that opens the drop-down menu or submenu.</para>
		/// <para>
		/// The high-order word indicates whether the drop-down menu is the window menu. If the menu is the window menu, this parameter is
		/// <c>TRUE</c>; otherwise, it is <c>FALSE</c>.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-initmenupopup
		[MsgParams(typeof(HMENU), typeof(uint))]
		WM_INITMENUPOPUP = 0x0117,

		/// <summary>
		/// <para>Sent to a menu's owner window when the user selects a menu item.</para>
		/// <para>
		/// <code>#define WM_MENUSELECT 0x011F</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The low-order word specifies the menu item or submenu index. If the selected item is a command item, this parameter contains the
		/// identifier of the menu item. If the selected item opens a drop-down menu or submenu, this parameter contains the index of the
		/// drop-down menu or submenu in the main menu, and the lParam parameter contains the handle to the main (clicked) menu; use the
		/// <c>GetSubMenu</c> function to get the menu handle to the drop-down menu or submenu.
		/// </para>
		/// <para>The high-order word specifies one or more menu flags. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MF_BITMAP</c> 0x00000004L</term>
		/// <term>Item displays a bitmap.</term>
		/// </item>
		/// <item>
		/// <term><c>MF_CHECKED</c> 0x00000008L</term>
		/// <term>Item is checked.</term>
		/// </item>
		/// <item>
		/// <term><c>MF_DISABLED</c> 0x00000002L</term>
		/// <term>Item is disabled.</term>
		/// </item>
		/// <item>
		/// <term><c>MF_GRAYED</c> 0x00000001L</term>
		/// <term>Item is grayed.</term>
		/// </item>
		/// <item>
		/// <term><c>MF_HILITE</c> 0x00000080L</term>
		/// <term>Item is highlighted.</term>
		/// </item>
		/// <item>
		/// <term><c>MF_MOUSESELECT</c> 0x00008000L</term>
		/// <term>Item is selected with the mouse.</term>
		/// </item>
		/// <item>
		/// <term><c>MF_OWNERDRAW</c> 0x00000100L</term>
		/// <term>Item is an owner-drawn item.</term>
		/// </item>
		/// <item>
		/// <term><c>MF_POPUP</c> 0x00000010L</term>
		/// <term>Item opens a drop-down menu or submenu.</term>
		/// </item>
		/// <item>
		/// <term><c>MF_SYSMENU</c> 0x00002000L</term>
		/// <term>Item is contained in the window menu. The <c>lParam</c> parameter contains a handle to the menu associated with the message.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the menu that was clicked.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the high-order word of wParam contains 0xFFFF and the lParam parameter contains <c>NULL</c>, the system has closed the menu.
		/// </para>
		/// <para>
		/// Do not use the value 1 for the high-order word of wParam, because this value is specified as ( <c>UINT</c>)
		/// <c>HIWORD</c>(wParam). If the value is 0xFFFF, it would be interpreted as 0x0000FFFF, not 1, because of the cast to a <c>UINT</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-menuselect
		[MsgParams(typeof(uint), typeof(HMENU))]
		WM_MENUSELECT = 0x011F,

		/// <summary>
		/// <para>
		/// Sent when a menu is active and the user presses a key that does not correspond to any mnemonic or accelerator key. This message
		/// is sent to the window that owns the menu.
		/// </para>
		/// <para>
		/// <code>#define WM_MENUCHAR 0x0120</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The low-order word specifies the character code that corresponds to the key the user pressed.</para>
		/// <para>The high-order word specifies the active menu type. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MF_POPUP</c> 0x00000010L</term>
		/// <term>A drop-down menu, submenu, or shortcut menu.</term>
		/// </item>
		/// <item>
		/// <term><c>MF_SYSMENU</c> 0x00002000L</term>
		/// <term>The window menu.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the active menu.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// An application that processes this message should return one of the following values in the high-order word of the return value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>MNC_CLOSE</c> 1</term>
		/// <term>Informs the system that it should close the active menu.</term>
		/// </item>
		/// <item>
		/// <term><c>MNC_EXECUTE</c> 2</term>
		/// <term>
		/// Informs the system that it should choose the item specified in the low-order word of the return value. The owner window receives
		/// a <c>WM_COMMAND</c> message.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>MNC_IGNORE</c> 0</term>
		/// <term>Informs the system that it should discard the character the user pressed and create a short beep on the system speaker.</term>
		/// </item>
		/// <item>
		/// <term><c>MNC_SELECT</c> 3</term>
		/// <term>Informs the system that it should select the item specified in the low-order word of the return value.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>The low-order word is ignored if the high-order word contains 0 or 1.</para>
		/// <para>An application should process this message when an accelerator is used to select a menu item that displays a bitmap.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-menuchar
		[MsgParams(typeof(uint), typeof(HMENU))]
		WM_MENUCHAR = 0x0120,

		/// <summary>
		/// <para>
		/// Sent to the owner window of a modal dialog box or menu that is entering an idle state. A modal dialog box or menu enters an idle
		/// state when no messages are waiting in its queue after it has processed one or more previous messages.
		/// </para>
		/// <para>
		/// <code>#define WM_ENTERIDLE 0x0121</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MSGF_DIALOGBOX</c> 0</term>
		/// <term>The system is idle because a dialog box is displayed.</term>
		/// </item>
		/// <item>
		/// <term><c>MSGF_MENU</c> 2</term>
		/// <term>The system is idle because a menu is displayed.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the dialog box (if wParam is <c>MSGF_DIALOGBOX</c>) or window containing the displayed menu (if wParam is <c>MSGF_MENU</c>).</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// You can suppress the <c>WM_ENTERIDLE</c> message for a dialog box by creating the dialog box with the <c>DS_NOIDLEMSG</c> style.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dlgbox/wm-enteridle
		[MsgParams(typeof(MSGF), typeof(HWND))]
		WM_ENTERIDLE = 0x0121,

		/// <summary>
		/// <para>Sent when the user releases the right mouse button while the cursor is on a menu item.</para>
		/// <para>
		/// <code>#define WM_MENURBUTTONUP 0x0122</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based index of the menu item on which the right mouse button was released.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the menu containing the item.</para>
		/// </summary>
		/// <remarks>
		/// The <c>WM_MENURBUTTONUP</c> message allows applications to provide a context-sensitive menu also known as a shortcut menu for the
		/// menu item specified in this message. To display a context-sensitive menu for a menu item, call the <c>TrackPopupMenuEx</c>
		/// function with <c>TPM_RECURSE</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-menurbuttonup
		[MsgParams(typeof(uint), typeof(HMENU))]
		WM_MENURBUTTONUP = 0x0122,

		/// <summary>
		/// <para>Sent to the owner of a drag-and-drop menu when the user drags a menu item.</para>
		/// <para>
		/// <code>#define WM_MENUDRAG 0x0123</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The position of the item where the drag operation began.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the menu containing the item.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The application should return one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>MND_CONTINUE</c> 0</term>
		/// <term>Menu should remain active. If the mouse is released, it should be ignored.</term>
		/// </item>
		/// <item>
		/// <term><c>MND_ENDMENU</c> 1</term>
		/// <term>Menu should be ended.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>The application can call the <c>DoDragDrop</c> function in response to this message.</para>
		/// <para>To create a drag-and-drop menu, call <c>SetMenuInfo</c> with <c>MNS_DRAGDROP</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-menudrag
		[MsgParams(typeof(uint), typeof(HMENU), LResultType = typeof(MND))]
		WM_MENUDRAG = 0x0123,

		/// <summary>
		/// <para>
		/// Sent to the owner of a drag-and-drop menu when the mouse cursor enters a menu item or moves from the center of the item to the
		/// top or bottom of the item.
		/// </para>
		/// <para>
		/// <code>#define WM_MENUGETOBJECT 0x0124</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>MENUGETOBJECTINFO</c> structure.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The application should return one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>MNGO_NOERROR</c> 0x00000001</term>
		/// <term>An interface pointer was returned in the <c>pvObj</c> member of <c>MENUGETOBJECTINFO</c></term>
		/// </item>
		/// <item>
		/// <term><c>MNGO_NOINTERFACE</c> 0x00000000</term>
		/// <term>The interface is not supported.</term>
		/// </item>
		/// </list>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-menugetobject
		[MsgParams(null, typeof(MENUGETOBJECTINFO?), LResultType = typeof(MNGO))]
		WM_MENUGETOBJECT = 0x0124,

		/// <summary>
		/// <para>Sent when a drop-down menu or submenu has been destroyed.</para>
		/// <para>
		/// <code>#define WM_UNINITMENUPOPUP 0x0125</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the menu</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The high-order word identifies the menu that was destroyed. Currently, this parameter can only be <c>MF_SYSMENU</c> (the window menu).
		/// </para>
		/// </summary>
		/// <remarks>If an application receives a <c>WM_INITMENUPOPUP</c> message, it will receive a <c>WM_UNINITMENUPOPUP</c> message.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-uninitmenupopup
		[MsgParams(typeof(HMENU), typeof(uint))]
		WM_UNINITMENUPOPUP = 0x0125,

		/// <summary>
		/// <para>Sent when the user makes a selection from a menu.</para>
		/// <para>
		/// <code>#define WM_MENUCOMMAND 0x0126</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The zero-based index of the item selected.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the menu for the item selected.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>WM_MENUCOMMAND</c> message gives you a handle to the menu so you can access the menu data in the <c>MENUINFO</c> structure
		/// and also gives you the index of the selected item, which is typically what applications need. In contrast, the <c>WM_COMMAND</c>
		/// message gives you the menu item identifier.
		/// </para>
		/// <para>
		/// The <c>WM_MENUCOMMAND</c> message is sent only for menus that are defined with the <c>MNS_NOTIFYBYPOS</c> flag set in the
		/// <c>dwStyle</c> member of the <c>MENUINFO</c> structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-menucommand
		[MsgParams(typeof(uint), typeof(HMENU))]
		WM_MENUCOMMAND = 0x0126,

		/// <summary>
		/// <para>An application sends the <c>WM_CHANGEUISTATE</c> message to indicate that the UI state should be changed.</para>
		/// <para>
		/// <code>#define WM_CHANGEUISTATE 0x0127</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The low-order word specifies the action to be taken. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>UIS_CLEAR</c> 2</term>
		/// <term>The UI state flags specified by the high-order word should be cleared.</term>
		/// </item>
		/// <item>
		/// <term><c>UIS_INITIALIZE</c> 3</term>
		/// <term>
		/// The UI state flags specified by the high-order word should be changed based on the last input event. For more information, see Remarks.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>UIS_SET</c> 1</term>
		/// <term>The UI state flags specified by the high-order word should be set.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The high-order word specifies which UI state elements are affected or the style of the control. This member can be one or more of
		/// the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>UISF_ACTIVE</c> 0x4</term>
		/// <term>A control should be drawn in the style used for active controls.</term>
		/// </item>
		/// <item>
		/// <term><c>UISF_HIDEACCEL</c> 0x2</term>
		/// <term>Keyboard accelerators are hidden.</term>
		/// </item>
		/// <item>
		/// <term><c>UISF_HIDEFOCUS</c> 0x1</term>
		/// <term>Focus indicators are hidden.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used and must be 0.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A window should send this message to itself or its parent when it must change the UI state elements of all windows in the same
		/// hierarchy. The window procedure must let <c>DefWindowProc</c> process this message so that the entire window tree has a
		/// consistent UI state. When the top-level window receives the <c>WM_CHANGEUISTATE</c> message, it sends a <c>WM_UPDATEUISTATE</c>
		/// message with the same parameters to all child windows. When the system processes the <c>WM_UPDATEUISTATE</c> message, it makes
		/// the change in the UI state.
		/// </para>
		/// <para>
		/// If the low-order word of wParam is UIS_INITIALIZE, the system will send the <c>WM_UPDATEUISTATE</c> message with a UI state based
		/// on the last input event. For example, if the last input came from the mouse, the system will hide the keyboard cues. And, if the
		/// last input came from the keyboard, the system will show the keyboard cues. If the state that results from processing
		/// <c>WM_CHANGEUISTATE</c> is the same as the old state, <c>DefWindowProc</c> does not send this message.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-changeuistate
		[MsgParams(typeof(UISTATE), null, LResultType = null)]
		WM_CHANGEUISTATE = 0x0127,

		/// <summary>
		/// <para>
		/// An application sends the <c>WM_UPDATEUISTATE</c> message to change the UI state for the specified window and all its child windows.
		/// </para>
		/// <para>
		/// <code>#define WM_UPDATEUISTATE 0x0128</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The low-order word specifies the action to be performed. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>UIS_CLEAR</c> 2</term>
		/// <term>The UI state element specified by the high-order word should be hidden.</term>
		/// </item>
		/// <item>
		/// <term><c>UIS_INITIALIZE</c> 3</term>
		/// <term>
		/// The UI state element specified by the high-order word should be changed based on the last input event. For more information, see Remarks.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>UIS_SET</c> 1</term>
		/// <term>The UI state element specified by the high-order word should be visible.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The high-order word specifies which UI state elements are affected or the style of the control. This parameter can be one or more
		/// of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>UISF_ACTIVE</c> 0x4</term>
		/// <term>A control should be drawn in the style used for active controls.</term>
		/// </item>
		/// <item>
		/// <term><c>UISF_HIDEACCEL</c> 0x2</term>
		/// <term>Keyboard accelerators.</term>
		/// </item>
		/// <item>
		/// <term><c>UISF_HIDEFOCUS</c> 0x1</term>
		/// <term>Focus indicators.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A window should send this message to change the UI state of all its child windows. In contrast to the <c>WM_CHANGEUISTATE</c>
		/// message, which is a notification, when <c>DefWindowProc</c> processes the <c>WM_UPDATEUISTATE</c> message it changes the UI state
		/// and propagates the changes to all child windows.
		/// </para>
		/// <para>
		/// The <c>DefWindowProc</c> function updates the UI state according to the wParam value. If the UI state is modified, the function
		/// sends the message to all the immediate child windows. <c>DefWindowProc</c> also sends this message when it receives a
		/// <c>WM_CHANGEUISTATE</c> message notifying the system that a child window intends to modify the UI state.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-updateuistate
		[MsgParams(typeof(UISTATE), null, LResultType = null)]
		WM_UPDATEUISTATE = 0x0128,

		/// <summary>
		/// <para>An application sends the <c>WM_QUERYUISTATE</c> message to retrieve the UI state for a window.</para>
		/// <para>
		/// <code>#define WM_QUERYUISTATE 0x0129</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used and must be 0.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used and must be 0.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is <c>NULL</c> if the focus indicators and the keyboard accelerators are visible. Otherwise, the return value
		/// can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>UISF_ACTIVE</c> 0x4</term>
		/// <term>A control should be drawn in the style used for active controls.</term>
		/// </item>
		/// <item>
		/// <term><c>UISF_HIDEACCEL</c> 0x2</term>
		/// <term>Keyboard accelerators are hidden.</term>
		/// </item>
		/// <item>
		/// <term><c>UISF_HIDEFOCUS</c> 0x1</term>
		/// <term>Focus indicators are hidden.</term>
		/// </item>
		/// </list>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-queryuistate
		[MsgParams(null, null, LResultType = typeof(UISF))]
		WM_QUERYUISTATE = 0x0129,

		/// <summary>
		/// <para>
		/// The WM_CTLCOLORMSGBOX message is sent to the owner window of a message box before Windows draws the message box. By responding to
		/// this message, the owner window can set the text and background colors of the message box by using the given display device
		/// context handle.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Type: HDC. Identifies the device context for the message box.</para>
		/// <para><em>lParam</em></para>
		/// <para>Type: HWND. Identifies the message box.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If an application processes this message, it must return the handle of a brush. Windows uses the brush to paint the background of
		/// the message box.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The WM_CTLCOLORMSGBOX message is never sent between threads. It is sent only within one thread.</para>
		/// </remarks>
		[MsgParams(typeof(HDC), typeof(HWND), LResultType = typeof(HBRUSH))]
		WM_CTLCOLORMSGBOX = 0x0132,

		/// <summary>
		/// <para>
		/// An edit control that is not read-only or disabled sends the <c>WM_CTLCOLOREDIT</c> message to its parent window when the control
		/// is about to be drawn. By responding to this message, the parent window can use the specified device context handle to set the
		/// text and background colors of the edit control.
		/// </para>
		/// <para>
		/// <code>WM_CTLCOLOREDIT WPARAM wParam; LPARAM lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the device context for the edit control window.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the edit control.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If an application processes this message, it must return the handle of a brush. The system uses the brush to paint the background
		/// of the edit control.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the application returns a brush that it created (for example, by using the <c>CreateSolidBrush</c> or
		/// <c>CreateBrushIndirect</c> function), the application must free the brush. If the application returns a system brush (for
		/// example, one that was retrieved by the <c>GetStockObject</c> or <c>GetSysColorBrush</c> function), the application does not need
		/// to free the brush.
		/// </para>
		/// <para>By default, the <c>DefWindowProc</c> function selects the default system colors for the edit control.</para>
		/// <para>
		/// Read-only or disabled edit controls do not send the <c>WM_CTLCOLOREDIT</c> message; instead, they send the
		/// <c>WM_CTLCOLORSTATIC</c> message.
		/// </para>
		/// <para>The <c>WM_CTLCOLOREDIT</c> message is never sent between threads, it is only sent within the same thread.</para>
		/// <para>
		/// If a dialog box procedure handles this message, it should cast the desired return value to a <c>INT_PTR</c> and return the value
		/// directly. If the dialog box procedure returns <c>FALSE</c>, then default message handling is performed. The DWL_MSGRESULT value
		/// set by the <c>SetWindowLong</c> function is ignored.
		/// </para>
		/// <para>
		/// <c>Rich Edit:</c> This message is not supported. To set the background color for a rich edit control, use the
		/// <c>EM_SETBKGNDCOLOR</c> message.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/wm-ctlcoloredit
		[MsgParams(typeof(HDC), typeof(HWND), LResultType = typeof(HBRUSH))]
		WM_CTLCOLOREDIT = 0x0133,

		/// <summary>
		/// <para>
		/// Sent to the parent window of a list box before the system draws the list box. By responding to this message, the parent window
		/// can set the text and background colors of the list box by using the specified display device context handle.
		/// </para>
		/// <para>
		/// <code>WM_CTLCOLORLISTBOX WPARAM wParam; LPARAM lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Handle to the device context for the list box.</para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the list box.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If an application processes this message, it must return a handle to a brush. The system uses the brush to paint the background
		/// of the list box.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>By default, the <c>DefWindowProc</c> function selects the default system colors for the list box.</para>
		/// <para>The <c>WM_CTLCOLORLISTBOX</c> message is never sent between threads. It is sent only within one thread.</para>
		/// <para>
		/// If a dialog box procedure handles this message, it should cast the desired return value to a <c>INT_PTR</c> and return the value
		/// directly. If the dialog box procedure returns <c>FALSE</c>, then default message handling is performed. The <c>DWL_MSGRESULT</c>
		/// value set by the <c>SetWindowLong</c> function is ignored.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/wm-ctlcolorlistbox
		[MsgParams(typeof(HDC), typeof(HWND), LResultType = typeof(HBRUSH))]
		WM_CTLCOLORLISTBOX = 0x0134,

		/// <summary>
		/// <para>
		/// The <c>WM_CTLCOLORBTN</c> message is sent to the parent window of a button before drawing the button. The parent window can
		/// change the button's text and background colors. However, only owner-drawn buttons respond to the parent window processing this message.
		/// </para>
		/// <para>
		/// <code>WM_CTLCOLORBTN WPARAM wParam; LPARAM lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>An <c>HDC</c> that specifies the handle to the display context for the button.</para>
		/// <para><em>lParam</em></para>
		/// <para>An <c>HWND</c> that specifies the handle to the button.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If an application processes this message, it must return a handle to a brush. The system uses the brush to paint the background
		/// of the button.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the application returns a brush that it created (for example, by using the <c>CreateSolidBrush</c> or
		/// <c>CreateBrushIndirect</c> function), the application must free the brush. If the application returns a system brush (for
		/// example, one that was retrieved by the <c>GetStockObject</c> or <c>GetSysColorBrush</c> function), the application does not need
		/// to free the brush.
		/// </para>
		/// <para>
		/// By default, the <c>DefWindowProc</c> function selects the default system colors for the button. Buttons with the
		/// <c>BS_PUSHBUTTON</c>, <c>BS_DEFPUSHBUTTON</c>, or <c>BS_PUSHLIKE</c> styles do not use the returned brush. Buttons with these
		/// styles are always drawn with the default system colors. Drawing push buttons requires several different brushes-face, highlight,
		/// and shadow-but the <c>WM_CTLCOLORBTN</c> message allows only one brush to be returned. To provide a custom appearance for push
		/// buttons, use an owner-drawn button. For more information, see Creating Owner-Drawn Controls.
		/// </para>
		/// <para>The <c>WM_CTLCOLORBTN</c> message is never sent between threads. It is sent only within one thread.</para>
		/// <para>
		/// The text color of a check box or radio button applies to the box or button, its check mark, and the text. The focus rectangle for
		/// these buttons remains the system default color (typically black). The text color of a group box applies to the text but not to
		/// the line that defines the box. The text color of a push button applies only to its focus rectangle; it does not affect the color
		/// of the text.
		/// </para>
		/// <para>
		/// If a dialog box procedure handles this message, it should cast the desired return value to a <c>INT_PTR</c> and return the value
		/// directly. If the dialog box procedure returns <c>FALSE</c>, then default message handling is performed. The DWL_MSGRESULT value
		/// set by the <c>SetWindowLong</c> function is ignored.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/wm-ctlcolorbtn
		[MsgParams(typeof(HDC), typeof(HWND), LResultType = typeof(HBRUSH))]
		WM_CTLCOLORBTN = 0x0135,

		/// <summary>
		/// <para>
		/// Sent to a dialog box before the system draws the dialog box. By responding to this message, the dialog box can set its text and
		/// background colors using the specified display device context handle.
		/// </para>
		/// <para>
		/// <code>#define WM_CTLCOLORDLG 0x0136</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the device context for the dialog box.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the dialog box.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If an application processes this message, it must return a handle to a brush. The system uses the brush to paint the background
		/// of the dialog box.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>By default, the <c>DefWindowProc</c> function selects the default system colors for the dialog box.</para>
		/// <para>
		/// The system does not automatically destroy the returned brush. It is the application's responsibility to destroy the brush when it
		/// is no longer needed.
		/// </para>
		/// <para>The <c>WM_CTLCOLORDLG</c> message is never sent between threads. It is sent only within one thread.</para>
		/// <para>
		/// Note that the <c>WM_CTLCOLORDLG</c> message is sent to the dialog box itself; all of the other <c>WM_CTLCOLOR*</c> messages are
		/// sent to the owner of the control.
		/// </para>
		/// <para>
		/// If a dialog box procedure handles this message, it should cast the desired return value to an <c>INT_PTR</c> and return the value
		/// directly. If the dialog box procedure returns <c>FALSE</c>, then default message handling is performed. The <c>DWL_MSGRESULT</c>
		/// value set by the <c>SetWindowLong</c> function is ignored.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dlgbox/wm-ctlcolordlg
		[MsgParams(typeof(HDC), typeof(HWND), LResultType = typeof(HBRUSH))]
		WM_CTLCOLORDLG = 0x0136,

		/// <summary>
		/// <para>
		/// The <c>WM_CTLCOLORSCROLLBAR</c> message is sent to the parent window of a scroll bar control when the control is about to be
		/// drawn. By responding to this message, the parent window can use the display context handle to set the background color of the
		/// scroll bar control.
		/// </para>
		/// <para>A window receives this message through its WindowProc function.</para>
		/// <para>
		/// <code>WM_CTLCOLORSCROLLBAR WPARAM wParam LPARAM lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Handle to the device context for the scroll bar control.</para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the scroll bar.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If an application processes this message, it must return the handle to a brush. The system uses the brush to paint the background
		/// of the scroll bar control.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the application returns a brush that it created (for example, by using the <c>CreateSolidBrush</c> or
		/// <c>CreateBrushIndirect</c> function), the application must free the brush. If the application returns a system brush (for
		/// example, one that was retrieved by the <c>GetStockObject</c> or <c>GetSysColorBrush</c> function), the application does not need
		/// to free the brush.
		/// </para>
		/// <para>By default, the <c>DefWindowProc</c> function selects the default system colors for the scroll bar control.</para>
		/// <para>The <c>WM_CTLCOLORSCROLLBAR</c> message is never sent between threads; it is only sent within the same thread.</para>
		/// <para>
		/// If a dialog box procedure handles this message, it should cast the desired return value to a <c>INT_PTR</c> and return the value
		/// directly. If the dialog box procedure returns <c>FALSE</c>, then default message handling is performed. The DWL_MSGRESULT value
		/// set by the <c>SetWindowLong</c> function is ignored.
		/// </para>
		/// <para>
		/// The <c>WM_CTLCOLORSCROLLBAR</c> message is used only by child scroll bar controls. Scrollbars attached to a window (WS_SCROLL and
		/// WS_VSCROLL) do not generate this message. To customize the appearance of scrollbars attached to a window, use the flat scroll bar functions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/wm-ctlcolorscrollbar
		[MsgParams(typeof(HDC), typeof(HWND), LResultType = typeof(HBRUSH))]
		WM_CTLCOLORSCROLLBAR = 0x0137,

		/// <summary>
		/// <para>
		/// A static control, or an edit control that is read-only or disabled, sends the <c>WM_CTLCOLORSTATIC</c> message to its parent
		/// window when the control is about to be drawn. By responding to this message, the parent window can use the specified device
		/// context handle to set the text foreground and background colors of the static control.
		/// </para>
		/// <para>A window receives this message through its WindowProc function.</para>
		/// <para>
		/// <code>WM_CTLCOLORSTATIC WPARAM wParam; LPARAM lParam;</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Handle to the device context for the static control window.</para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the static control.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If an application processes this message, the return value is a handle to a brush that the system uses to paint the background of
		/// the static control.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the application returns a brush that it created (for example, by using the <c>CreateSolidBrush</c> or
		/// <c>CreateBrushIndirect</c> function), the application must free the brush. If the application returns a system brush (for
		/// example, one that was retrieved by the <c>GetStockObject</c> or <c>GetSysColorBrush</c> function), the application does not need
		/// to free the brush.
		/// </para>
		/// <para>By default, the <c>DefWindowProc</c> function selects the default system colors for the static control.</para>
		/// <para>
		/// You can set the text background color of a disabled edit control, but you cannot set the text foreground color. The system always
		/// uses COLOR_GRAYTEXT.
		/// </para>
		/// <para>
		/// Edit controls that are not read-only or disabled do not send the <c>WM_CTLCOLORSTATIC</c> message; instead, they send the
		/// <c>WM_CTLCOLOREDIT</c> message.
		/// </para>
		/// <para>The <c>WM_CTLCOLORSTATIC</c> message is never sent between threads; it is sent only within the same thread.</para>
		/// <para>
		/// If a dialog box procedure handles this message, it should cast the desired return value to a <c>INT_PTR</c> and return the value
		/// directly. If the dialog box procedure returns <c>FALSE</c>, then default message handling is performed. The DWL_MSGRESULT value
		/// set by the <c>SetWindowLong</c> function is ignored.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/wm-ctlcolorstatic
		[MsgParams(typeof(HDC), typeof(HWND), LResultType = typeof(HBRUSH))]
		WM_CTLCOLORSTATIC = 0x0138,

		/// <summary>The first mouse related message.</summary>
		WM_MOUSEFIRST = 0x0200,

		/// <summary>
		/// <para>
		/// Posted to a window when the cursor moves. If the mouse is not captured, the message is posted to the window that contains the
		/// cursor. Otherwise, the message is posted to the window that has captured the mouse.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_MOUSEMOVE 0x0200</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Indicates whether various virtual keys are down. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MK_CONTROL</c> 0x0008</term>
		/// <term>The CTRL key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_LBUTTON</c> 0x0001</term>
		/// <term>The left mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_MBUTTON</c> 0x0010</term>
		/// <term>The middle mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_RBUTTON</c> 0x0002</term>
		/// <term>The right mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_SHIFT</c> 0x0004</term>
		/// <term>The SHIFT key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON1</c> 0x0020</term>
		/// <term>The first X button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON2</c> 0x0040</term>
		/// <term>The second X button is down.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the x-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para>
		/// The high-order word specifies the y-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>Use the following code to obtain the horizontal and vertical position:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the return value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the <c>MAKEPOINTS</c> macro to obtain a <c>POINTS</c> structure from the
		/// return value. You can also use the <c>GET_X_LPARAM</c> or <c>GET_Y_LPARAM</c> macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mousemove
		[MsgParams(typeof(MouseButtonState), typeof(POINTS))]
		WM_MOUSEMOVE = 0x0200,

		/// <summary>
		/// <para>
		/// Posted when the user presses the left mouse button while the cursor is in the client area of a window. If the mouse is not
		/// captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has
		/// captured the mouse.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_LBUTTONDOWN 0x0201</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Indicates whether various virtual keys are down. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MK_CONTROL</c> 0x0008</term>
		/// <term>The CTRL key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_LBUTTON</c> 0x0001</term>
		/// <term>The left mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_MBUTTON</c> 0x0010</term>
		/// <term>The middle mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_RBUTTON</c> 0x0002</term>
		/// <term>The right mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_SHIFT</c> 0x0004</term>
		/// <term>The SHIFT key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON1</c> 0x0020</term>
		/// <term>The first X button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON2</c> 0x0040</term>
		/// <term>The second X button is down.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the x-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para>
		/// The high-order word specifies the y-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the return value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the <c>MAKEPOINTS</c> macro to obtain a <c>POINTS</c> structure from the
		/// return value. You can also use the <c>GET_X_LPARAM</c> or <c>GET_Y_LPARAM</c> macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>
		/// To detect that the ALT key was pressed, check whether <c>GetKeyState</c> with <c>VK_MENU</c> &lt; 0. Note, this must not be <c>GetAsyncKeyState</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-lbuttondown
		[MsgParams(typeof(MouseButtonState), typeof(POINTS))]
		WM_LBUTTONDOWN = 0x0201,

		/// <summary>
		/// <para>
		/// Posted when the user releases the left mouse button while the cursor is in the client area of a window. If the mouse is not
		/// captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has
		/// captured the mouse.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_LBUTTONUP 0x0202</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Indicates whether various virtual keys are down. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MK_CONTROL</c> 0x0008</term>
		/// <term>The CTRL key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_MBUTTON</c> 0x0010</term>
		/// <term>The middle mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_RBUTTON</c> 0x0002</term>
		/// <term>The right mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_SHIFT</c> 0x0004</term>
		/// <term>The SHIFT key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON1</c> 0x0020</term>
		/// <term>The first X button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON2</c> 0x0040</term>
		/// <term>The second X button is down.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the x-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para>
		/// The high-order word specifies the y-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>Use the following code to obtain the horizontal and vertical position:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the lParam value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the <c>MAKEPOINTS</c> macro to obtain a <c>POINTS</c> structure from the
		/// return value. You can also use the <c>GET_X_LPARAM</c> or <c>GET_Y_LPARAM</c> macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-lbuttonup
		[MsgParams(typeof(MouseButtonState), typeof(POINTS))]
		WM_LBUTTONUP = 0x0202,

		/// <summary>
		/// <para>
		/// Posted when the user double-clicks the left mouse button while the cursor is in the client area of a window. If the mouse is not
		/// captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has
		/// captured the mouse.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_LBUTTONDBLCLK 0x0203</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Indicates whether various virtual keys are down. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MK_CONTROL</c> 0x0008</term>
		/// <term>The CTRL key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_LBUTTON</c> 0x0001</term>
		/// <term>The left mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_MBUTTON</c> 0x0010</term>
		/// <term>The middle mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_RBUTTON</c> 0x0002</term>
		/// <term>The right mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_SHIFT</c> 0x0004</term>
		/// <term>The SHIFT key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON1</c> 0x0020</term>
		/// <term>The first X button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON2</c> 0x0040</term>
		/// <term>The second X button is down.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the x-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para>
		/// The high-order word specifies the y-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>Use the following code to obtain the horizontal and vertical position:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the return value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the <c>MAKEPOINTS</c> macro to obtain a <c>POINTS</c> structure from the
		/// return value. You can also use the <c>GET_X_LPARAM</c> or <c>GET_Y_LPARAM</c> macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>
		/// Only windows that have the <c>CS_DBLCLKS</c> style can receive <c>WM_LBUTTONDBLCLK</c> messages, which the system generates
		/// whenever the user presses, releases, and again presses the left mouse button within the system's double-click time limit.
		/// Double-clicking the left mouse button actually generates a sequence of four messages: <c>WM_LBUTTONDOWN</c>, <c>WM_LBUTTONUP</c>,
		/// <c>WM_LBUTTONDBLCLK</c>, and <c>WM_LBUTTONUP</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-lbuttondblclk
		[MsgParams(typeof(MouseButtonState), typeof(POINTS))]
		WM_LBUTTONDBLCLK = 0x0203,

		/// <summary>
		/// <para>
		/// Posted when the user presses the right mouse button while the cursor is in the client area of a window. If the mouse is not
		/// captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has
		/// captured the mouse.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_RBUTTONDOWN 0x0204</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Indicates whether various virtual keys are down. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MK_CONTROL</c> 0x0008</term>
		/// <term>The CTRL key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_LBUTTON</c> 0x0001</term>
		/// <term>The left mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_MBUTTON</c> 0x0010</term>
		/// <term>The middle mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_RBUTTON</c> 0x0002</term>
		/// <term>The right mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_SHIFT</c> 0x0004</term>
		/// <term>The SHIFT key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON1</c> 0x0020</term>
		/// <term>The first X button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON2</c> 0x0040</term>
		/// <term>The second X button is down.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the x-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para>
		/// The high-order word specifies the y-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>Use the following code to obtain the horizontal and vertical position:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the return value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the <c>MAKEPOINTS</c> macro to obtain a <c>POINTS</c> structure from the
		/// return value. You can also use the <c>GET_X_LPARAM</c> or <c>GET_Y_LPARAM</c> macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>
		/// To detect that the ALT key was pressed, check whether <c>GetKeyState</c> with <c>VK_MENU</c> &lt; 0. Note, this must not be <c>GetAsyncKeyState</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-rbuttondown
		[MsgParams(typeof(MouseButtonState), typeof(POINTS))]
		WM_RBUTTONDOWN = 0x0204,

		/// <summary>
		/// <para>
		/// Posted when the user releases the right mouse button while the cursor is in the client area of a window. If the mouse is not
		/// captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has
		/// captured the mouse.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_RBUTTONUP 0x0205</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Indicates whether various virtual keys are down. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MK_CONTROL</c> 0x0008</term>
		/// <term>The CTRL key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_LBUTTON</c> 0x0001</term>
		/// <term>The left mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_MBUTTON</c> 0x0010</term>
		/// <term>The middle mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_RBUTTON</c> 0x0002</term>
		/// <term>The SHIFT key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON1</c> 0x0020</term>
		/// <term>The first X button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON2</c> 0x0040</term>
		/// <term>The second X button is down.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the x-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para>
		/// The high-order word specifies the y-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>Use the following code to obtain the horizontal and vertical position:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the return value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the <c>MAKEPOINTS</c> macro to obtain a <c>POINTS</c> structure from the
		/// return value. You can also use the <c>GET_X_LPARAM</c> or <c>GET_Y_LPARAM</c> macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-rbuttonup
		[MsgParams(typeof(MouseButtonState), typeof(POINTS))]
		WM_RBUTTONUP = 0x0205,

		/// <summary>
		/// <para>
		/// Posted when the user double-clicks the right mouse button while the cursor is in the client area of a window. If the mouse is not
		/// captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has
		/// captured the mouse.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_RBUTTONDBLCLK 0x0206</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Indicates whether various virtual keys are down. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MK_CONTROL</c> 0x0008</term>
		/// <term>The CTRL key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_LBUTTON</c> 0x0001</term>
		/// <term>The left mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_MBUTTON</c> 0x0010</term>
		/// <term>The middle mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_RBUTTON</c> 0x0002</term>
		/// <term>The right mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_SHIFT</c> 0x0004</term>
		/// <term>The SHIFT key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON1</c> 0x0020</term>
		/// <term>The first X button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON2</c> 0x0040</term>
		/// <term>The second X button is down.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the x-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para>
		/// The high-order word specifies the y-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Only windows that have the <c>CS_DBLCLKS</c> style can receive <c>WM_RBUTTONDBLCLK</c> messages, which the system generates
		/// whenever the user presses, releases, and again presses the right mouse button within the system's double-click time limit.
		/// Double-clicking the right mouse button actually generates four messages: <c>WM_RBUTTONDOWN</c>, <c>WM_RBUTTONUP</c>,
		/// <c>WM_RBUTTONDBLCLK</c>, and <c>WM_RBUTTONUP</c> again.
		/// </para>
		/// <para>Use the following code to obtain the horizontal and vertical position:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the return value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the <c>MAKEPOINTS</c> macro to obtain a <c>POINTS</c> structure from the
		/// return value. You can also use the <c>GET_X_LPARAM</c> or <c>GET_Y_LPARAM</c> macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-rbuttondblclk
		[MsgParams(typeof(MouseButtonState), typeof(POINTS))]
		WM_RBUTTONDBLCLK = 0x0206,

		/// <summary>
		/// <para>
		/// Posted when the user presses the middle mouse button while the cursor is in the client area of a window. If the mouse is not
		/// captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has
		/// captured the mouse.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_MBUTTONDOWN 0x0207</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Indicates whether various virtual keys are down. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MK_CONTROL</c> 0x0008</term>
		/// <term>The CTRL key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_LBUTTON</c> 0x0001</term>
		/// <term>The left mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_MBUTTON</c> 0x0010</term>
		/// <term>The middle mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_RBUTTON</c> 0x0002</term>
		/// <term>The right mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_SHIFT</c> 0x0004</term>
		/// <term>The SHIFT key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON1</c> 0x0020</term>
		/// <term>The first X button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON2</c> 0x0040</term>
		/// <term>The second X button is down.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the x-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para>
		/// The high-order word specifies the y-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>Use the following code to obtain the horizontal and vertical position:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the return value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the <c>MAKEPOINTS</c> macro to obtain a <c>POINTS</c> structure from the
		/// return value. You can also use the <c>GET_X_LPARAM</c> or <c>GET_Y_LPARAM</c> macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>
		/// To detect that the ALT key was pressed, check whether <c>GetKeyState</c> with <c>VK_MENU</c> &lt; 0. Note, this must not be <c>GetAsyncKeyState</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mbuttondown
		WM_MBUTTONDOWN = 0x0207,

		/// <summary>
		/// <para>
		/// Posted when the user releases the middle mouse button while the cursor is in the client area of a window. If the mouse is not
		/// captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has
		/// captured the mouse.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_MBUTTONUP 0x0208</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Indicates whether various virtual keys are down. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MK_CONTROL</c> 0x0008</term>
		/// <term>The CTRL key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_LBUTTON</c> 0x0001</term>
		/// <term>The left mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_MBUTTON</c> 0x0010</term>
		/// <term>The middle mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_RBUTTON</c> 0x0002</term>
		/// <term>The right mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_SHIFT</c> 0x0004</term>
		/// <term>The SHIFT key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON1</c> 0x0020</term>
		/// <term>The first X button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON2</c> 0x0040</term>
		/// <term>The second X button is down.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the x-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para>
		/// The high-order word specifies the y-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para>
		/// Note that when a shortcut menu is present (displayed), coordinates are relative to the screen, not the client area. Because
		/// <c>TrackPopupMenu</c> is an asynchronous call and the <c>WM_MBUTTONUP</c> notification does not have a special flag indicating
		/// coordinate derivation, an application cannot tell if the x,y coordinates contained in lParam are relative to the screen or the
		/// client area.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>Use the following code to obtain the horizontal and vertical position:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the return value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the <c>MAKEPOINTS</c> macro to obtain a <c>POINTS</c> structure from the
		/// return value. You can also use the <c>GET_X_LPARAM</c> or <c>GET_Y_LPARAM</c> macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mbuttonup
		[MsgParams(typeof(MouseButtonState), typeof(POINTS))]
		WM_MBUTTONUP = 0x0208,

		/// <summary>
		/// <para>
		/// Posted when the user double-clicks the middle mouse button while the cursor is in the client area of a window. If the mouse is
		/// not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has
		/// captured the mouse.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_MBUTTONDBLCLK 0x0209</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Indicates whether various virtual keys are down. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MK_CONTROL</c> 0x0008</term>
		/// <term>The CTRL key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_LBUTTON</c> 0x0001</term>
		/// <term>The left mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_MBUTTON</c> 0x0010</term>
		/// <term>The middle mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_RBUTTON</c> 0x0002</term>
		/// <term>The right mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_SHIFT</c> 0x0004</term>
		/// <term>The SHIFT key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON1</c> 0x0020</term>
		/// <term>The first X button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON2</c> 0x0040</term>
		/// <term>The second X button is down.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the x-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para>
		/// The high-order word specifies the y-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>Use the following code to obtain the horizontal and vertical position:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the return value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the <c>MAKEPOINTS</c> macro to obtain a <c>POINTS</c> structure from the
		/// return value. You can also use the <c>GET_X_LPARAM</c> or <c>GET_Y_LPARAM</c> macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>
		/// Only windows that have the <c>CS_DBLCLKS</c> style can receive <c>WM_MBUTTONDBLCLK</c> messages, which the system generates when
		/// the user presses, releases, and again presses the middle mouse button within the system's double-click time limit.
		/// Double-clicking the middle mouse button actually generates four messages: <c>WM_MBUTTONDOWN</c>, <c>WM_MBUTTONUP</c>,
		/// <c>WM_MBUTTONDBLCLK</c>, and <c>WM_MBUTTONUP</c> again.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mbuttondblclk
		[MsgParams(typeof(MouseButtonState), typeof(POINTS))]
		WM_MBUTTONDBLCLK = 0x0209,

		/// <summary>
		/// <para>
		/// Sent to the focus window when the mouse wheel is rotated. The <c>DefWindowProc</c> function propagates the message to the
		/// window's parent. There should be no internal forwarding of the message, since <c>DefWindowProc</c> propagates it up the parent
		/// chain until it finds a window that processes it.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_MOUSEWHEEL 0x020A</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The high-order word indicates the distance the wheel is rotated, expressed in multiples or divisions of <c>WHEEL_DELTA</c>, which
		/// is 120. A positive value indicates that the wheel was rotated forward, away from the user; a negative value indicates that the
		/// wheel was rotated backward, toward the user.
		/// </para>
		/// <para>
		/// The low-order word indicates whether various virtual keys are down. This parameter can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MK_CONTROL</c> 0x0008</term>
		/// <term>The CTRL key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_LBUTTON</c> 0x0001</term>
		/// <term>The left mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_MBUTTON</c> 0x0010</term>
		/// <term>The middle mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_RBUTTON</c> 0x0002</term>
		/// <term>The right mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_SHIFT</c> 0x0004</term>
		/// <term>The SHIFT key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON1</c> 0x0020</term>
		/// <term>The first X button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON2</c> 0x0040</term>
		/// <term>The second X button is down.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>The low-order word specifies the x-coordinate of the pointer, relative to the upper-left corner of the screen.</para>
		/// <para>The high-order word specifies the y-coordinate of the pointer, relative to the upper-left corner of the screen.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>Use the following code to get the information in the wParam parameter:</para>
		/// <para>
		/// <code>fwKeys = GET_KEYSTATE_WPARAM(wParam); zDelta = GET_WHEEL_DELTA_WPARAM(wParam);</code>
		/// </para>
		/// <para>Use the following code to obtain the horizontal and vertical position:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the return value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the <c>MAKEPOINTS</c> macro to obtain a <c>POINTS</c> structure from the
		/// return value. You can also use the <c>GET_X_LPARAM</c> or <c>GET_Y_LPARAM</c> macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>
		/// The wheel rotation will be a multiple of <c>WHEEL_DELTA</c>, which is set at 120. This is the threshold for action to be taken,
		/// and one such action (for example, scrolling one increment) should occur for each delta.
		/// </para>
		/// <para>
		/// The delta was set to 120 to allow Microsoft or other vendors to build finer-resolution wheels (a freely-rotating wheel with no
		/// notches) to send more messages per rotation, but with a smaller value in each message. To use this feature, you can either add
		/// the incoming delta values until <c>WHEEL_DELTA</c> is reached (so for a delta-rotation you get the same response), or scroll
		/// partial lines in response to the more frequent messages. You can also choose your scroll granularity and accumulate deltas until
		/// it is reached.
		/// </para>
		/// <para>Note, there is no fwKeys for <c>MSH_MOUSEWHEEL</c>. Otherwise, the parameters are exactly the same as for <c>WM_MOUSEWHEEL</c>.</para>
		/// <para>
		/// It is up to the application to forward <c>MSH_MOUSEWHEEL</c> to any embedded objects or controls. The application is required to
		/// send the message to an active embedded OLE application. It is optional that the application sends it to a wheel-enabled control
		/// with focus. If the application does send the message to a control, it can check the return value to see if the message was
		/// processed. Controls are required to return a value of <c>TRUE</c> if they process the message.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mousewheel
		[MsgParams(typeof(MOUSEWHEEL), typeof(POINTS))]
		WM_MOUSEWHEEL = 0x020A,

		/// <summary>
		/// <para>
		/// Posted when the user presses the first or second X button while the cursor is in the client area of a window. If the mouse is not
		/// captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has
		/// captured the mouse.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_XBUTTONDOWN 0x020B</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The low-order word indicates whether various virtual keys are down. It can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MK_CONTROL</c> 0x0008</term>
		/// <term>The CTRL key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_LBUTTON</c> 0x0001</term>
		/// <term>The left mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_MBUTTON</c> 0x0010</term>
		/// <term>The middle mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_RBUTTON</c> 0x0002</term>
		/// <term>The right mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_SHIFT</c> 0x0004</term>
		/// <term>The SHIFT key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON1</c> 0x0020</term>
		/// <term>The first X button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON2</c> 0x0040</term>
		/// <term>The second X button is down.</term>
		/// </item>
		/// </list>
		/// <para>The high-order word indicates which button was clicked. It can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>XBUTTON1</c> 0x0001</term>
		/// <term>The first X button was clicked.</term>
		/// </item>
		/// <item>
		/// <term><c>XBUTTON2</c> 0x0002</term>
		/// <term>The second X button was clicked.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the x-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para>
		/// The high-order word specifies the y-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If an application processes this message, it should return <c>TRUE</c>. For more information about processing the return value,
		/// see the Remarks section.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>Use the following code to get the information in the wParam parameter:</para>
		/// <para>
		/// <code>fwKeys = GET_KEYSTATE_WPARAM (wParam); fwButton = GET_XBUTTON_WPARAM (wParam);</code>
		/// </para>
		/// <para>Use the following code to obtain the horizontal and vertical position:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the return value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the <c>MAKEPOINTS</c> macro to obtain a <c>POINTS</c> structure from the
		/// return value. You can also use the <c>GET_X_LPARAM</c> or <c>GET_Y_LPARAM</c> macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>
		/// Unlike the <c>WM_LBUTTONDOWN</c>, <c>WM_MBUTTONDOWN</c>, and <c>WM_RBUTTONDOWN</c> messages, an application should return
		/// <c>TRUE</c> from this message if it processes it. Doing so allows software that simulates this message on Windows systems earlier
		/// than Windows 2000 to determine whether the window procedure processed the message or called <c>DefWindowProc</c> to process it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-xbuttondown
		[MsgParams(typeof(MouseButtonState), typeof(POINTS))]
		WM_XBUTTONDOWN = 0x020B,

		/// <summary>
		/// <para>
		/// Posted when the user releases the first or second X button while the cursor is in the client area of a window. If the mouse is
		/// not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has
		/// captured the mouse.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_XBUTTONUP 0x020C</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The low-order word indicates whether various virtual keys are down. It can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MK_CONTROL</c> 0x0008</term>
		/// <term>The CTRL key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_LBUTTON</c> 0x0001</term>
		/// <term>The left mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_MBUTTON</c> 0x0010</term>
		/// <term>The middle mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_RBUTTON</c> 0x0002</term>
		/// <term>The right mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_SHIFT</c> 0x0004</term>
		/// <term>The SHIFT key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON1</c> 0x0020</term>
		/// <term>The first X button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON2</c> 0x0040</term>
		/// <term>The second X button is down.</term>
		/// </item>
		/// </list>
		/// <para>The high-order word indicates which button was released. It can be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>XBUTTON1</c> 0x0001</term>
		/// <term>The first X button was released.</term>
		/// </item>
		/// <item>
		/// <term><c>XBUTTON2</c> 0x0002</term>
		/// <term>The second X button was released.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the x-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para>
		/// The high-order word specifies the y-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If an application processes this message, it should return <c>TRUE</c>. For more information about processing the return value,
		/// see the Remarks section.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>Use the following code to get the information in the wParam parameter:</para>
		/// <para>
		/// <code>fwKeys = GET_KEYSTATE_WPARAM (wParam); fwButton = GET_XBUTTON_WPARAM (wParam);</code>
		/// </para>
		/// <para>Use the following code to obtain the horizontal and vertical position:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the return value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the <c>MAKEPOINTS</c> macro to obtain a <c>POINTS</c> structure from the
		/// return value. You can also use the <c>GET_X_LPARAM</c> or <c>GET_Y_LPARAM</c> macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>
		/// Unlike the <c>WM_LBUTTONUP</c>, <c>WM_MBUTTONUP</c>, and <c>WM_RBUTTONUP</c> messages, an application should return <c>TRUE</c>
		/// from this message if it processes it. Doing so will allow software that simulates this message on Windows systems earlier than
		/// Windows 2000 to determine whether the window procedure processed the message or called <c>DefWindowProc</c> to process it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-xbuttonup
		[MsgParams(typeof(MouseButtonState), typeof(POINTS))]
		WM_XBUTTONUP = 0x020C,

		/// <summary>
		/// <para>
		/// Posted when the user double-clicks the first or second X button while the cursor is in the client area of a window. If the mouse
		/// is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has
		/// captured the mouse.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_XBUTTONDBLCLK 0x020D</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The low-order word indicates whether various virtual keys are down. It can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MK_CONTROL</c> 0x0008</term>
		/// <term>The CTRL key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_LBUTTON</c> 0x0001</term>
		/// <term>The left mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_MBUTTON</c> 0x0010</term>
		/// <term>The middle mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_RBUTTON</c> 0x0002</term>
		/// <term>The right mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_SHIFT</c> 0x0004</term>
		/// <term>The SHIFT key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON1</c> 0x0020</term>
		/// <term>The first X button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON2</c> 0x0040</term>
		/// <term>The second X button is down.</term>
		/// </item>
		/// </list>
		/// <para>The high-order word indicates which button was double-clicked. It can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>XBUTTON1</c> 0x0001</term>
		/// <term>The first X button was double-clicked.</term>
		/// </item>
		/// <item>
		/// <term><c>XBUTTON2</c> 0x0002</term>
		/// <term>The second X button was double-clicked.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the x-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para>
		/// The high-order word specifies the y-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If an application processes this message, it should return <c>TRUE</c>. For more information about processing the return value,
		/// see the Remarks section.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>Use the following code to get the information in the wParam parameter:</para>
		/// <para>
		/// <code>fwKeys = GET_KEYSTATE_WPARAM (wParam); fwButton = GET_XBUTTON_WPARAM (wParam);</code>
		/// </para>
		/// <para>Use the following code to obtain the horizontal and vertical position:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the return value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the <c>MAKEPOINTS</c> macro to obtain a <c>POINTS</c> structure from the
		/// return value. You can also use the <c>GET_X_LPARAM</c> or <c>GET_Y_LPARAM</c> macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>
		/// Only windows that have the <c>CS_DBLCLKS</c> style can receive <c>WM_XBUTTONDBLCLK</c> messages, which the system generates
		/// whenever the user presses, releases, and again presses an X button within the system's double-click time limit. Double-clicking
		/// one of these buttons actually generates four messages: <c>WM_XBUTTONDOWN</c>, <c>WM_XBUTTONUP</c>, <c>WM_XBUTTONDBLCLK</c>, and
		/// <c>WM_XBUTTONUP</c> again.
		/// </para>
		/// <para>
		/// Unlike the <c>WM_LBUTTONDBLCLK</c>, <c>WM_MBUTTONDBLCLK</c>, and <c>WM_RBUTTONDBLCLK</c> messages, an application should return
		/// <c>TRUE</c> from this message if it processes it. Doing so will allow software that simulates this message on Windows systems
		/// earlier than Windows 2000 to determine whether the window procedure processed the message or called <c>DefWindowProc</c> to
		/// process it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-xbuttondblclk
		[MsgParams(typeof(MouseButtonState), typeof(POINTS))]
		WM_XBUTTONDBLCLK = 0x020D,

		/// <summary>
		/// <para>
		/// Sent to the active window when the mouse's horizontal scroll wheel is tilted or rotated. The <c>DefWindowProc</c> function
		/// propagates the message to the window's parent. There should be no internal forwarding of the message, since <c>DefWindowProc</c>
		/// propagates it up the parent chain until it finds a window that processes it.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_MOUSEHWHEEL 0x020E</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The high-order word indicates the distance the wheel is rotated, expressed in multiples or factors of <c>WHEEL_DELTA</c>, which
		/// is set to 120. A positive value indicates that the wheel was rotated to the right; a negative value indicates that the wheel was
		/// rotated to the left.
		/// </para>
		/// <para>
		/// The low-order word indicates whether various virtual keys are down. This parameter can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MK_CONTROL</c> 0x0008</term>
		/// <term>The CTRL key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_LBUTTON</c> 0x0001</term>
		/// <term>The left mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_MBUTTON</c> 0x0010</term>
		/// <term>The middle mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_RBUTTON</c> 0x0002</term>
		/// <term>The right mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_SHIFT</c> 0x0004</term>
		/// <term>The SHIFT key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON1</c> 0x0020</term>
		/// <term>The first X button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON2</c> 0x0040</term>
		/// <term>The second X button is down.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>The low-order word specifies the x-coordinate of the pointer, relative to the upper-left corner of the screen.</para>
		/// <para>The high-order word specifies the y-coordinate of the pointer, relative to the upper-left corner of the screen.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>Use the following code to obtain the information in the wParam parameter.</para>
		/// <para>
		/// <code>fwKeys = GET_KEYSTATE_WPARAM(wParam); zDelta = GET_WHEEL_DELTA_WPARAM(wParam);</code>
		/// </para>
		/// <para>Use the following code to obtain the horizontal and vertical position.</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the return value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the <c>MAKEPOINTS</c> macro to obtain a <c>POINTS</c> structure from the
		/// return value. You can also use the <c>GET_X_LPARAM</c> or <c>GET_Y_LPARAM</c> macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// <para>
		/// The wheel rotation is a multiple of <c>WHEEL_DELTA</c>, which is set to 120. This is the threshold for action to be taken, and
		/// one such action (for example, scrolling one increment) should occur for each delta.
		/// </para>
		/// <para>
		/// The delta was set to 120 to allow Microsoft or other vendors to build finer-resolution wheels (for example, a freely-rotating
		/// wheel with no notches) to send more messages per rotation, but with a smaller value in each message. To use this feature, you can
		/// either add the incoming delta values until <c>WHEEL_DELTA</c> is reached (so for a delta-rotation you get the same response), or
		/// scroll partial lines in response to more frequent messages. You can also choose your scroll granularity and accumulate deltas
		/// until it is reached.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mousehwheel
		[MsgParams(typeof(MOUSEWHEEL), typeof(POINTS))]
		WM_MOUSEHWHEEL = 0x020E,

		/// <summary>The last mouse related message.</summary>
		WM_MOUSELAST = 0x020E,

		/// <summary>
		/// <para>
		/// Sent to a window when a significant action occurs on a descendant window. This message is now extended to include the
		/// <c>WM_POINTERDOWN</c> event. When the child window is being created, the system sends <c>WM_PARENTNOTIFY</c> just before the
		/// <c>CreateWindow</c> or <c>CreateWindowEx</c> function that creates the window returns. When the child window is being destroyed,
		/// the system sends the message before any processing to destroy the window takes place.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <para>
		/// [!Important] Desktop apps should be DPI aware. If your app is not DPI aware, screen coordinates contained in pointer messages and
		/// related structures might appear inaccurate due to DPI virtualization. DPI virtualization provides automatic scaling support to
		/// applications that are not DPI aware and is active by default (users can turn it off). For more information, see Writing High-DPI
		/// Win32 Applications.
		/// </para>
		/// </para>
		/// <para>
		/// <code>#define WM_PARENTNOTIFY 0x0210</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The low-order word of wParam specifies the event for which the parent is being notified. The value of the high-order word depends
		/// on the value of the low-order word. This parameter can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>LOWORD( <c>wParam</c>)</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>WM_CREATE</c> 0x0001</term>
		/// <term>
		/// The child window is being created. HIWORD( <c>wParam</c>) is the identifier of the child window. <c>lParam</c> is a handle to the
		/// child window.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WM_DESTROY</c> 0x0002</term>
		/// <term>
		/// The child window is being destroyed. HIWORD( <c>wParam</c>) is the identifier of the child window. <c>lParam</c> is a handle to
		/// the child window.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WM_LBUTTONDOWN</c> 0x0201</term>
		/// <term>
		/// The user has placed the cursor over the child window and has clicked the left mouse button. HIWORD( <c>wParam</c>) is undefined.
		/// <c>lParam</c> is the x-coordinate of the cursor is the low-order word, and the y-coordinate of the cursor is the high-order word.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WM_MBUTTONDOWN</c> 0x0207</term>
		/// <term>
		/// The user has placed the cursor over the child window and has clicked the middle mouse button. HIWORD( <c>wParam</c>) is
		/// undefined. <c>lParam</c> is the x-coordinate of the cursor is the low-order word, and the y-coordinate of the cursor is the
		/// high-order word.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WM_RBUTTONDOWN</c> 0x0204</term>
		/// <term>
		/// The user has placed the cursor over the child window and has clicked the right mouse button. HIWORD( <c>wParam</c>) is undefined.
		/// <c>lParam</c> is the x-coordinate of the cursor is the low-order word, and the y-coordinate of the cursor is the high-order word.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WM_XBUTTONDOWN</c> 0x020B</term>
		/// <term>
		/// The user has placed the cursor over the child window and has clicked the first or second X button. HIWORD( <c>wParam</c>)
		/// indicates which button was pressed. This parameter can be one of the following values: XBUTTON1 or XBUTTON2. <c>lParam</c> is the
		/// x-coordinate of the cursor is the low-order word, and the y-coordinate of the cursor is the high-order word.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WM_POINTERDOWN</c> 0x0246</term>
		/// <term>
		/// A pointer has made contact with the child window. HIWORD( <c>wParam</c>) contains the identifier of the pointer that generated
		/// the <c>WM_POINTERDOWN</c> event.
		/// </term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Contains the point location of the pointer.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Because the pointer may make contact with the device over a non-trivial area, this point location may be a simplification of a
		/// more complex pointer area. Whenever possible, an application should use the complete pointer area information instead of the
		/// point location.
		/// </para>
		/// </para>
		/// <para>Use the following macros to retrieve the physical screen coordinates of the point.</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>GET_X_LPARAM</c>(lParam): the x (horizontal point) coordinate.</term>
		/// </item>
		/// <item>
		/// <term><c>GET_Y_LPARAM</c>(lParam): the y (vertical point) coordinate.</term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>If the application processes this message, it returns zero.</para>
		/// <para>If the application does not process this message, it calls <c>DefWindowProc</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>This message is also sent to all ancestor windows of the child window, including the top-level window.</para>
		/// <para>
		/// All child windows, except those that have the <c>WS_EX_NOPARENTNOTIFY</c> extended window style, send this message to their
		/// parent windows. By default, child windows in a dialog box have the <c>WS_EX_NOPARENTNOTIFY</c> style, unless the
		/// <c>CreateWindowEx</c> function is called to create the child window without this style.
		/// </para>
		/// <para>
		/// This notification provides the child window's ancestor windows an opportunity to examine the pointer information and, if
		/// required, capture the pointer using the pointer capture functions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputmsg/wm-parentnotify
		[MsgParams(typeof(WindowMessage), typeof(POINTS))]
		WM_PARENTNOTIFY = 0x0210,

		/// <summary>
		/// <para>Notifies an application's main window procedure that a menu modal loop has been entered.</para>
		/// <para>
		/// <code>#define WM_ENTERMENULOOP 0x0211</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Specifies whether the window menu was entered using the <c>TrackPopupMenu</c> function. This parameter has a value of <c>TRUE</c>
		/// if the window menu was entered using <c>TrackPopupMenu</c>, and <c>FALSE</c> if it was not.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>The <c>DefWindowProc</c> function returns zero.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-entermenuloop
		[MsgParams(typeof(BOOL), null)]
		WM_ENTERMENULOOP = 0x0211,

		/// <summary>
		/// <para>Notifies an application's main window procedure that a menu modal loop has been exited.</para>
		/// <para>
		/// <code>#define WM_EXITMENULOOP 0x0212</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Specifies whether the menu is a shortcut menu. This parameter has a value of <c>TRUE</c> if it is a shortcut menu, <c>FALSE</c>
		/// if it is not.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>The <c>DefWindowProc</c> function returns zero.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-exitmenuloop
		[MsgParams(typeof(BOOL), null)]
		WM_EXITMENULOOP = 0x0212,

		/// <summary>
		/// <para>Sent to an application when the right or left arrow key is used to switch between the menu bar and the system menu.</para>
		/// <para>
		/// <code>#define WM_NEXTMENU 0x0213</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The virtual-key code of the key. See <c>Virtual-Key Codes</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>MDINEXTMENU</c> structure that contains information about the menu to be activated.</para>
		/// </summary>
		/// <remarks>
		/// In responding to this message, the application can specify the menu to switch to in the <c>hmenuNext</c> member of
		/// <c>MDINEXTMENU</c> and the window to receive the menu notification messages in the <c>hwndNext</c> member of the
		/// <c>MDINEXTMENU</c> structure. You must set both members for the changes to take effect (they are initially <c>NULL</c>).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-nextmenu
		[MsgParams(typeof(VK), typeof(MDINEXTMENU?))]
		WM_NEXTMENU = 0x0213,

		/// <summary>
		/// <para>
		/// Sent to a window that the user is resizing. By processing this message, an application can monitor the size and position of the
		/// drag rectangle and, if needed, change its size or position.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_SIZING 0x0214</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The edge of the window that is being sized. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>WMSZ_BOTTOM</c> 6</term>
		/// <term>Bottom edge</term>
		/// </item>
		/// <item>
		/// <term><c>WMSZ_BOTTOMLEFT</c> 7</term>
		/// <term>Bottom-left corner</term>
		/// </item>
		/// <item>
		/// <term><c>WMSZ_BOTTOMRIGHT</c> 8</term>
		/// <term>Bottom-right corner</term>
		/// </item>
		/// <item>
		/// <term><c>WMSZ_LEFT</c> 1</term>
		/// <term>Left edge</term>
		/// </item>
		/// <item>
		/// <term><c>WMSZ_RIGHT</c> 2</term>
		/// <term>Right edge</term>
		/// </item>
		/// <item>
		/// <term><c>WMSZ_TOP</c> 3</term>
		/// <term>Top edge</term>
		/// </item>
		/// <item>
		/// <term><c>WMSZ_TOPLEFT</c> 4</term>
		/// <term>Top-left corner</term>
		/// </item>
		/// <item>
		/// <term><c>WMSZ_TOPRIGHT</c> 5</term>
		/// <term>Top-right corner</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>RECT</c> structure with the screen coordinates of the drag rectangle. To change the size or position of the
		/// drag rectangle, an application must change the members of this structure.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>An application should return <c>TRUE</c> if it processes this message.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-sizing
		[MsgParams(typeof(WMSZ), typeof(RECT?))]
		WM_SIZING = 0x0214,

		/// <summary>
		/// <para>Sent to the window that is losing the mouse capture.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_CAPTURECHANGED 0x0215</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the window gaining the mouse capture.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A window receives this message even if it calls <c>ReleaseCapture</c> itself. An application should not attempt to set the mouse
		/// capture in response to this message.
		/// </para>
		/// <para>When it receives this message, a window should redraw itself, if necessary, to reflect the new mouse-capture state.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-capturechanged
		[MsgParams(null, typeof(HWND))]
		WM_CAPTURECHANGED = 0x0215,

		/// <summary>
		/// <para>
		/// Sent to a window that the user is moving. By processing this message, an application can monitor the position of the drag
		/// rectangle and, if needed, change its position.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_MOVING 0x0216</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>RECT</c> structure with the current position of the window, in screen coordinates. To change the position of
		/// the drag rectangle, an application must change the members of this structure.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>An application should return <c>TRUE</c> if it processes this message.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-moving
		[MsgParams(null, typeof(RECT?), LResultType = typeof(BOOL))]
		WM_MOVING = 0x0216,

		/// <summary>
		/// <para>Notifies applications that a power-management event has occurred.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, // handle to window UINT uMsg, // WM_POWERBROADCAST WPARAM wParam, // power-management event LPARAM lParam // function-specific data );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hwnd</em></para>
		/// <para>A handle to window.</para>
		/// <para><em>*uMsg*</em></para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>WM_POWERBROADCAST</c></c> 536 (0x218)</term>
		/// <term>Message identifier.</term>
		/// </item>
		/// </list>
		/// <para><em>wParam</em></para>
		/// <para>The power-management event. This parameter can be one of the following event identifiers.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Event</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>PBT_APMPOWERSTATUSCHANGE</c> 10 (0xA)</term>
		/// <term>Power status has changed.</term>
		/// </item>
		/// <item>
		/// <term><c>PBT_APMRESUMEAUTOMATIC</c> 18 (0x12)</term>
		/// <term>Operation is resuming automatically from a low-power state. This message is sent every time the system resumes.</term>
		/// </item>
		/// <item>
		/// <term><c>PBT_APMRESUMESUSPEND</c> 7 (0x7)</term>
		/// <term>
		/// Operation is resuming from a low-power state. This message is sent after PBT_APMRESUMEAUTOMATIC if the resume is triggered by
		/// user input, such as pressing a key.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>PBT_APMSUSPEND</c> 4 (0x4)</term>
		/// <term>System is suspending operation.</term>
		/// </item>
		/// <item>
		/// <term><c>PBT_POWERSETTINGCHANGE</c> 32787 (0x8013)</term>
		/// <term>A power setting change event has been received.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>The event-specific data. For most events, this parameter is reserved and not used.</para>
		/// <para>
		/// If the wParam parameter is PBT_POWERSETTINGCHANGE, the lParam parameter is a pointer to a <c>POWERBROADCAST_SETTING</c> structure.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return <c>TRUE</c> if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The system always sends a PBT_APMRESUMEAUTOMATIC message whenever the system resumes. If the system resumes in response to user
		/// input such as pressing a key, the system also sends a <c>PBT_APMRESUMESUSPEND</c> message after sending PBT_APMRESUMEAUTOMATIC.
		/// </para>
		/// <para>
		/// <c>WM_POWERBROADCAST</c> messages do not distinguish between different low-power states. An application can determine only that
		/// the system is entering or has resumed from a low-power state; it cannot determine the specific power state. The system records
		/// details about power state transitions in the Windows System event log.
		/// </para>
		/// <para>
		/// To prevent the system from transitioning to a low-power state in Windows Vista, an application must call
		/// <c>SetThreadExecutionState</c> to inform the system that it is in use.
		/// </para>
		/// <para>The following messages are not supported on any of the operating systems specified in the Requirements section:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>PBT_APMQUERYSTANDBY</term>
		/// </item>
		/// <item>
		/// <term>PBT_APMQUERYSTANDBYFAILED</term>
		/// </item>
		/// <item>
		/// <term>PBT_APMSTANDBY</term>
		/// </item>
		/// <item>
		/// <term>PBT_APMRESUMESTANDBY</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/power/wm-powerbroadcast
		[MsgParams(typeof(PowerBroadcastType), typeof(IntPtr), LResultType = typeof(BOOL))]
		WM_POWERBROADCAST = 0x0218,

		/// <summary>
		/// <para>Notifies an application of a change to the hardware configuration of a device or the computer.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc(HWND hwnd, // handle to window UINT uMsg, // WM_DEVICECHANGE WPARAM wParam, // device-change event LPARAM lParam ); // event-specific data</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hwnd</em></para>
		/// <para>A handle to the window.</para>
		/// <para><em>uMsg</em></para>
		/// <para>The <c>WM_DEVICECHANGE</c> identifier.</para>
		/// <para><em>wParam</em></para>
		/// <para>The event that has occurred. This parameter can be one of the following values from the Dbt.h header file.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>DBT_DEVNODES_CHANGED</c> 0x0007</term>
		/// <term>A device has been added to or removed from the system.</term>
		/// </item>
		/// <item>
		/// <term><c>DBT_QUERYCHANGECONFIG</c> 0x0017</term>
		/// <term>Permission is requested to change the current configuration (dock or undock).</term>
		/// </item>
		/// <item>
		/// <term><c>DBT_CONFIGCHANGED</c> 0x0018</term>
		/// <term>The current configuration has changed, due to a dock or undock.</term>
		/// </item>
		/// <item>
		/// <term><c>DBT_CONFIGCHANGECANCELED</c> 0x0019</term>
		/// <term>A request to change the current configuration (dock or undock) has been canceled.</term>
		/// </item>
		/// <item>
		/// <term><c>DBT_DEVICEARRIVAL</c> 0x8000</term>
		/// <term>A device or piece of media has been inserted and is now available.</term>
		/// </item>
		/// <item>
		/// <term><c>DBT_DEVICEQUERYREMOVE</c> 0x8001</term>
		/// <term>Permission is requested to remove a device or piece of media. Any application can deny this request and cancel the removal.</term>
		/// </item>
		/// <item>
		/// <term><c>DBT_DEVICEQUERYREMOVEFAILED</c> 0x8002</term>
		/// <term>A request to remove a device or piece of media has been canceled.</term>
		/// </item>
		/// <item>
		/// <term><c>DBT_DEVICEREMOVEPENDING</c> 0x8003</term>
		/// <term>A device or piece of media is about to be removed. Cannot be denied.</term>
		/// </item>
		/// <item>
		/// <term><c>DBT_DEVICEREMOVECOMPLETE</c> 0x8004</term>
		/// <term>A device or piece of media has been removed.</term>
		/// </item>
		/// <item>
		/// <term><c>DBT_DEVICETYPESPECIFIC</c> 0x8005</term>
		/// <term>A device-specific event has occurred.</term>
		/// </item>
		/// <item>
		/// <term><c>DBT_CUSTOMEVENT</c> 0x8006</term>
		/// <term>A custom event has occurred.</term>
		/// </item>
		/// <item>
		/// <term><c>DBT_USERDEFINED</c> 0xFFFF</term>
		/// <term>The meaning of this message is user-defined.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a structure that contains event-specific data. Its format depends on the value of the wParam parameter. For more
		/// information, refer to the documentation for each event.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return <c>TRUE</c> to grant the request.</para>
		/// <para>Return <c>BROADCAST_QUERY_DENY</c> to deny the request.</para>
		/// </summary>
		/// <remarks>
		/// For devices that offer software-controllable features, such as ejection and locking, the system typically sends a
		/// DBT_DEVICEREMOVEPENDING message to let applications and device drivers end their use of the device gracefully. If the system
		/// forcibly removes a device, it may not send a DBT_DEVICEQUERYREMOVE message before doing so.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/devio/wm-devicechange
		[MsgParams(typeof(DeviceBroadcastEvent), typeof(IntPtr), LResultType = typeof(IntPtr))]
		WM_DEVICECHANGE = 0x0219,

		/// <summary>
		/// <para>
		/// An application sends the <c>WM_MDICREATE</c> message to a multiple-document interface (MDI) client window to create an MDI child window.
		/// </para>
		/// <para>
		/// <code>#define WM_MDICREATE 0x0220</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to an <c>MDICREATESTRUCT</c> structure containing information that the system uses to create the MDI child window.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>HWND</c></para>
		/// <para>If the message succeeds, the return value is the handle to the new child window.</para>
		/// <para>If the message fails, the return value is <c>NULL</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The MDI child window is created with the <c>window style</c> bits <c>WS_CHILD</c>, <c>WS_CLIPSIBLINGS</c>,
		/// <c>WS_CLIPCHILDREN</c>, <c>WS_SYSMENU</c>, <c>WS_CAPTION</c>, <c>WS_THICKFRAME</c>, <c>WS_MINIMIZEBOX</c>, and
		/// <c>WS_MAXIMIZEBOX</c>, plus additional style bits specified in the <c>MDICREATESTRUCT</c> structure. The system adds the title of
		/// the new child window to the window menu of the frame window. An application should use this message to create all child windows
		/// of the client window.
		/// </para>
		/// <para>
		/// If an MDI client window receives any message that changes the activation of its child windows while the active child window is
		/// maximized, the system restores the active child window and maximizes the newly activated child window.
		/// </para>
		/// <para>
		/// When an MDI child window is created, the system sends the <c>WM_CREATE</c> message to the window. The lParam parameter of the
		/// <c>WM_CREATE</c> message contains a pointer to a <c>CREATESTRUCT</c> structure. The lpCreateParams member of this structure
		/// contains a pointer to the <c>MDICREATESTRUCT</c> structure passed with the <c>WM_MDICREATE</c> message that created the MDI child window.
		/// </para>
		/// <para>
		/// An application should not send a second <c>WM_MDICREATE</c> message while a <c>WM_MDICREATE</c> message is still being processed.
		/// For example, it should not send a <c>WM_MDICREATE</c> message while an MDI child window is processing its <c>WM_MDICREATE</c> message.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-mdicreate
		[MsgParams(null, typeof(MDICREATESTRUCT?), LResultType = typeof(HWND))]
		WM_MDICREATE = 0x0220,

		/// <summary>
		/// <para>
		/// An application sends the <c>WM_MDIDESTROY</c> message to a multiple-document interface (MDI) client window to close an MDI child window.
		/// </para>
		/// <para>
		/// <code>#define WM_MDIDESTROY 0x0221</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the MDI child window to be closed.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>zero</c></para>
		/// <para>This message always returns zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This message removes the title of the MDI child window from the MDI frame window and deactivates the child window. An application
		/// should use this message to close all MDI child windows.
		/// </para>
		/// <para>
		/// If an MDI client window receives a message that changes the activation of its child windows and the active MDI child window is
		/// maximized, the system restores the active child window and maximizes the newly activated child window.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-mdidestroy
		[MsgParams(typeof(HWND), null)]
		WM_MDIDESTROY = 0x0221,

		/// <summary>
		/// <para>
		/// An application sends the <c>WM_MDIACTIVATE</c> message to a multiple-document interface (MDI) client window to instruct the
		/// client window to activate a different MDI child window.
		/// </para>
		/// <para>
		/// <code>#define WM_MDIACTIVATE 0x0222</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the MDI child window to be activated.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If an application sends this message to an MDI client window, the return value is zero.</para>
		/// <para>An MDI child window should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// As the client window processes this message, it sends <c>WM_MDIACTIVATE</c> to the child window being deactivated and to the
		/// child window being activated. The message parameters received by an MDI child window are as follows:
		/// </para>
		/// <list>
		/// <item>
		/// <term>
		/// <para>wParam</para>
		/// </term>
		/// <term>
		/// <para>lParam</para>
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// An MDI child window is activated independently of the MDI frame window. When the frame window becomes active, the child window
		/// last activated by using the <c>WM_MDIACTIVATE</c> message receives the <c>WM_NCACTIVATE</c> message to draw an active window
		/// frame and title bar; the child window does not receive another <c>WM_MDIACTIVATE</c> message.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-mdiactivate
		[MsgParams(typeof(HWND), null)]
		WM_MDIACTIVATE = 0x0222,

		/// <summary>
		/// <para>
		/// An application sends the <c>WM_MDIRESTORE</c> message to a multiple-document interface (MDI) client window to restore an MDI
		/// child window from maximized or minimized size.
		/// </para>
		/// <para>
		/// <code>#define WM_MDIRESTORE 0x0223</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the MDI child window to be restored.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>zero</c></para>
		/// <para>The return value is always zero.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-mdirestore
		[MsgParams(typeof(HWND), null)]
		WM_MDIRESTORE = 0x0223,

		/// <summary>
		/// <para>
		/// An application sends the <c>WM_MDINEXT</c> message to a multiple-document interface (MDI) client window to activate the next or
		/// previous child window.
		/// </para>
		/// <para>
		/// <code>#define WM_MDINEXT 0x0224</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A handle to the MDI child window. The system activates the child window that is immediately before or after the specified child
		/// window, depending on the value of the lParam parameter. If the wParam parameter is <c>NULL</c>, the system activates the child
		/// window that is immediately before or after the currently active child window.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// If this parameter is zero, the system activates the next MDI child window and places the child window identified by the wParam
		/// parameter behind all other child windows. If this parameter is nonzero, the system activates the previous child window, placing
		/// it in front of the child window identified by wParam.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>zero</c></para>
		/// <para>The return value is always zero.</para>
		/// </summary>
		/// <remarks>
		/// If an MDI client window receives any message that changes the activation of its child windows while the active MDI child window
		/// is maximized, the system restores the active child window and maximizes the newly activated child window.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-mdinext
		[MsgParams(typeof(HWND), typeof(int))]
		WM_MDINEXT = 0x0224,

		/// <summary>
		/// <para>
		/// An application sends the <c>WM_MDIMAXIMIZE</c> message to a multiple-document interface (MDI) client window to maximize an MDI
		/// child window. The system resizes the child window to make its client area fill the client window. The system places the child
		/// window's window menu icon in the rightmost position of the frame window's menu bar, and places the child window's restore icon in
		/// the leftmost position. The system also appends the title bar text of the child window to that of the frame window.
		/// </para>
		/// <para>
		/// <code>#define WM_MDIMAXIMIZE 0x0225</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the MDI child window to be maximized.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>zero</c></para>
		/// <para>The return value is always zero.</para>
		/// </summary>
		/// <remarks>
		/// If an MDI client window receives any message that changes the activation of its child windows while the currently active MDI
		/// child window is maximized, the system restores the active child window and maximizes the newly activated child window.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-mdimaximize
		[MsgParams(typeof(HWND), null)]
		WM_MDIMAXIMIZE = 0x0225,

		/// <summary>
		/// <para>
		/// An application sends the <c>WM_MDITILE</c> message to a multiple-document interface (MDI) client window to arrange all of its MDI
		/// child windows in a tile format.
		/// </para>
		/// <para>
		/// <code>#define WM_MDITILE 0x0226</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The tiling option. This parameter can be one of the following values, optionally combined with <c>MDITILE_SKIPDISABLED</c> to
		/// prevent disabled MDI child windows from being tiled.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MDITILE_HORIZONTAL</c> 0x0001</term>
		/// <term>Tiles windows horizontally.</term>
		/// </item>
		/// <item>
		/// <term><c>MDITILE_VERTICAL</c> 0x0000</term>
		/// <term>Tiles windows vertically.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the message succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the message fails, the return value is <c>FALSE</c>.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-mditile
		[MsgParams(typeof(MdiTileFlags), null, LResultType = typeof(BOOL))]
		WM_MDITILE = 0x0226,

		/// <summary>
		/// <para>
		/// An application sends the <c>WM_MDICASCADE</c> message to a multiple-document interface (MDI) client window to arrange all its
		/// child windows in a cascade format.
		/// </para>
		/// <para>
		/// <code>#define WM_MDICASCADE 0x0227</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The cascade behavior. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MDITILE_SKIPDISABLED</c> 0x0002</term>
		/// <term>Prevents disabled MDI child windows from being cascaded.</term>
		/// </item>
		/// <item>
		/// <term><c>MDITILE_ZORDER</c> 0x0004</term>
		/// <term>Arranges the windows in Z order.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the message succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the message fails, the return value is <c>FALSE</c>.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-mdicascade
		[MsgParams(typeof(MdiTileFlags), null, LResultType = typeof(BOOL))]
		WM_MDICASCADE = 0x0227,

		/// <summary>
		/// <para>
		/// An application sends the <c>WM_MDIICONARRANGE</c> message to a multiple-document interface (MDI) client window to arrange all
		/// minimized MDI child windows. It does not affect child windows that are not minimized.
		/// </para>
		/// <para>
		/// <code>#define WM_MDIICONARRANGE 0x0228</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-mdiiconarrange
		[MsgParams()]
		WM_MDIICONARRANGE = 0x0228,

		/// <summary>
		/// <para>
		/// An application sends the <c>WM_MDIGETACTIVE</c> message to a multiple-document interface (MDI) client window to retrieve the
		/// handle to the active MDI child window.
		/// </para>
		/// <para>
		/// <code>#define WM_MDIGETACTIVE 0x0229</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The maximized state. If this parameter is not <c>NULL</c>, it is a pointer to a value that indicates the maximized state of the
		/// MDI child window. If the value is <c>TRUE</c>, the window is maximized; a value of <c>FALSE</c> indicates that it is not. If this
		/// parameter is <c>NULL</c>, the parameter is ignored.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>HWND</c></para>
		/// <para>The return value is the handle to the active MDI child window.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-mdigetactive
		[MsgParams(null, typeof(BOOL), LResultType = typeof(HWND))]
		WM_MDIGETACTIVE = 0x0229,

		/// <summary>
		/// <para>
		/// An application sends the <c>WM_MDISETMENU</c> message to a multiple-document interface (MDI) client window to replace the entire
		/// menu of an MDI frame window, to replace the window menu of the frame window, or both.
		/// </para>
		/// <para>
		/// <code>#define WM_MDISETMENU 0x0230</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the new frame window menu. If this parameter is <c>NULL</c>, the frame window menu is not changed.</para>
		/// <para><em>lParam</em></para>
		/// <para>A handle to the new window menu. If this parameter is <c>NULL</c>, the window menu is not changed.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>HMENU</c></para>
		/// <para>If the message succeeds, the return value is the handle to the old frame window menu.</para>
		/// <para>If the message fails, the return value is zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>After sending this message, an application must call the <c>DrawMenuBar</c> function to update the menu bar.</para>
		/// <para>
		/// If this message replaces the window menu, the MDI child window menu items are removed from the previous window menu and added to
		/// the new window menu.
		/// </para>
		/// <para>
		/// If an MDI child window is maximized and this message replaces the MDI frame window menu, the window menu icon and restore icon
		/// are removed from the previous frame window menu and added to the new frame window menu.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-mdisetmenu
		[MsgParams(typeof(HMENU), typeof(HMENU), LResultType = typeof(HMENU))]
		WM_MDISETMENU = 0x0230,

		/// <summary>
		/// <para>
		/// Sent one time to a window after it enters the moving or sizing modal loop. The window enters the moving or sizing modal loop when
		/// the user clicks the window's title bar or sizing border, or when the window passes the <c>WM_SYSCOMMAND</c> message to the
		/// <c>DefWindowProc</c> function and the wParam parameter of the message specifies the <c>SC_MOVE</c> or <c>SC_SIZE</c> value. The
		/// operation is complete when <c>DefWindowProc</c> returns.
		/// </para>
		/// <para>The system sends the <c>WM_ENTERSIZEMOVE</c> message regardless of whether the dragging of full windows is enabled.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_ENTERSIZEMOVE 0x0231</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-entersizemove
		[MsgParams()]
		WM_ENTERSIZEMOVE = 0x0231,

		/// <summary>
		/// <para>
		/// Sent one time to a window, after it has exited the moving or sizing modal loop. The window enters the moving or sizing modal loop
		/// when the user clicks the window's title bar or sizing border, or when the window passes the <c>WM_SYSCOMMAND</c> message to the
		/// <c>DefWindowProc</c> function and the wParam parameter of the message specifies the <c>SC_MOV</c> E or <c>SC_SIZE</c> value. The
		/// operation is complete when <c>DefWindowProc</c> returns.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_EXITSIZEMOVE 0x0232</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-exitsizemove
		[MsgParams()]
		WM_EXITSIZEMOVE = 0x0232,

		/// <summary>
		/// <para>Sent when the user drops a file on the window of an application that has registered itself as a recipient of dropped files.</para>
		/// <para>
		/// <code>PostMessage( (HWND) hWndControl, // handle to destination control (UINT) WM_DROPFILES, // message ID (WPARAM) wParam, // = (WPARAM) (HDROP) hDrop; (LPARAM) lParam // = 0; not used, must be zero );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hDrop</em></para>
		/// <para>
		/// A handle to an internal structure describing the dropped files. Pass this handle <c>DragFinish</c>, <c>DragQueryFile</c>, or
		/// <c>DragQueryPoint</c> to retrieve information about the dropped files.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return zero if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// The HDROP handle is declared in Shellapi.h. You must include this header in your build to use <c>WM_DROPFILES</c>. For further
		/// discussion of how to use drag-and-drop to transfer Shell data, see Transferring Shell Data Using Drag-and-Drop or the Clipboard.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/shell/wm-dropfiles
		[MsgParams(typeof(HDROP), null)]
		WM_DROPFILES = 0x0233,

		/// <summary>
		/// <para>
		/// An application sends the <c>WM_MDIREFRESHMENU</c> message to a multiple-document interface (MDI) client window to refresh the
		/// window menu of the MDI frame window.
		/// </para>
		/// <para>
		/// <code>#define WM_MDIREFRESHMENU 0x0234</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>HMENU</c></para>
		/// <para>If the message succeeds, the return value is the handle to the frame window menu.</para>
		/// <para>If the message fails, the return value is <c>NULL</c>.</para>
		/// </summary>
		/// <remarks>After sending this message, an application must call the <c>DrawMenuBar</c> function to update the menu bar.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-mdirefreshmenu
		[MsgParams(null, null, LResultType = typeof(HMENU))]
		WM_MDIREFRESHMENU = 0x0234,

		/// <summary>
		/// <para>Sent to an application when a window is activated. A window receives this message through its WindowProc function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, WM_IME_SETCONTEXT, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hwnd</em></para>
		/// <para>A handle to window.</para>
		/// <para><em>wParam</em></para>
		/// <para><c>TRUE</c> if the window is active, and <c>FALSE</c> otherwise.</para>
		/// <para><em>lParam</em></para>
		/// <para>Display options. This parameter can have one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>ISC_SHOWUICOMPOSITIONWINDOW</c></term>
		/// <term>Show the composition window by user interface window.</term>
		/// </item>
		/// <item>
		/// <term><c>ISC_SHOWUIGUIDWINDOW</c></term>
		/// <term>Show the guide window by user interface window.</term>
		/// </item>
		/// <item>
		/// <term><c>ISC_SHOWUISOFTKBD</c></term>
		/// <term>Show the soft keyboard by user interface window.</term>
		/// </item>
		/// <item>
		/// <term><c>ISC_SHOWUICANDIDATEWINDOW</c></term>
		/// <term>Show the candidate window of index 0 by user interface window.</term>
		/// </item>
		/// <item>
		/// <term>ISC_SHOWUICANDIDATEWINDOW &lt;&lt; 1</term>
		/// <term>Show the candidate window of index 1 by user interface window.</term>
		/// </item>
		/// <item>
		/// <term>ISC_SHOWUICANDIDATEWINDOW &lt;&lt; 2</term>
		/// <term>Show the candidate window of index 2 by user interface window.</term>
		/// </item>
		/// <item>
		/// <term>ISC_SHOWUICANDIDATEWINDOW &lt;&lt; 3</term>
		/// <term>Show the candidate window of index 3 by user interface window.</term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the value returned by <c>DefWindowProc</c> or <c>ImmIsUIMessage</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the application has created an IME window, it should call <c>ImmIsUIMessage</c>. Otherwise, it should pass this message to <c>DefWindowProc</c>.
		/// </para>
		/// <para>
		/// If the application draws the composition window, the default IME window does not have to show its composition window. In this
		/// case, the application must clear the <c>ISC_SHOWUICOMPOSITIONWINDOW</c> value from the lParam parameter before passing the
		/// message to <c>DefWindowProc</c> or <c>ImmIsUIMessage</c>. To display a certain user interface window, an application should
		/// remove the corresponding value so that the IME will not display it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/intl/wm-ime-setcontext
		[MsgParams(typeof(BOOL), typeof(ISC), LResultType = typeof(IntPtr))]
		WM_IME_SETCONTEXT = 0x0281,

		/// <summary>
		/// <para>
		/// Sent to an application to notify it of changes to the IME window. A window receives this message through its <c>WindowProc</c> function.
		/// </para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, WM_IME_NOTIFY, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hwnd</em></para>
		/// <para>A handle to window.</para>
		/// <para><em>wParam</em></para>
		/// <para>The command. This parameter can have one of the following values.</para>
		/// <list/>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Command-specific data, with format dependent on the value of the wParam parameter. For more information, refer to the
		/// documentation for each command.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value depends on the command sent.</para>
		/// </summary>
		/// <remarks>An application processes this message if it is responsible for managing the IME window.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/intl/wm-ime-notify
		[MsgParams(typeof(IntPtr), typeof(IntPtr), LResultType = typeof(IntPtr))]
		WM_IME_NOTIFY = 0x0282,

		/// <summary>
		/// <para>
		/// Sent by an application to direct the IME window to carry out the requested command. The application uses this message to control
		/// the IME window that it has created. To send this message, the application calls the <c>SendMessage</c> function with the
		/// following parameters.
		/// </para>
		/// <para>
		/// <code>SendMessage( HWND hwnd, WM_IME_CONTROL, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hwnd</em></para>
		/// <para>Handle to the window.</para>
		/// <para><em>wParam</em></para>
		/// <para>The command. This parameter can have one of the following values:</para>
		/// <list/>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Command-specific data, with format dependent on the value of the wParam parameter. For more information, refer to the
		/// documentation for each command.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The message returns a command-specific value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/intl/wm-ime-control
		[MsgParams(typeof(IntPtr), typeof(IntPtr), LResultType = typeof(IntPtr))]
		WM_IME_CONTROL = 0x0283,

		/// <summary>
		/// <para>
		/// Sent to an application when the IME window finds no space to extend the area for the composition window. A window receives this
		/// message through its <c>WindowProc</c> function.
		/// </para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, WM_IME_COMPOSITIONFULL, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message has no return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>The application should use the IMC_SETCOMPOSITIONWINDOW command to specify how the window should be displayed.</para>
		/// <para>The IME window, instead of the IME, sends this notification message by the <c>SendMessage</c> function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/intl/wm-ime-compositionfull
		[MsgParams()]
		WM_IME_COMPOSITIONFULL = 0x0284,

		/// <summary>
		/// <para>
		/// Sent to an application when the operating system is about to change the current IME. A window receives this message through its
		/// WindowProc function.
		/// </para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, WM_IME_SELECT, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hwnd</em></para>
		/// <para>A handle to window.</para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Selection indicator. This parameter specifies <c>TRUE</c> if the indicated IME is selected. The parameter is set to <c>FALSE</c>
		/// if the specified IME is no longer selected.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Input locale identifier associated with the IME.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message has no return value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// An application that has created an IME window should pass this message to that window so that it can retrieve the keyboard layout
		/// handle to the newly selected IME.
		/// </para>
		/// <para>The <c>DefWindowProc</c> function processes this message by passing the information to the default IME window.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/intl/wm-ime-select
		[MsgParams(typeof(BOOL), typeof(LCID), LResultType = null)]
		WM_IME_SELECT = 0x0285,

		/// <summary>
		/// <para>
		/// Sent to an application when the IME gets a character of the conversion result. A window receives this message through its
		/// <c>WindowProc</c> function.
		/// </para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, WM_IME_CHAR, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hwnd</em></para>
		/// <para>A handle to window.</para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// <c>DBCS:</c> A single-byte or double-byte character value. For a double-byte character, (BYTE)(wParam &gt;&gt; 8) contains the
		/// lead byte. Note that the parentheses are necessary because the cast operator has higher precedence than the shift operator.
		/// </para>
		/// <para><c>Unicode:</c> A Unicode character value.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The repeat count, scan code, extended key flag, context code, previous key state flag, and transition state flag, with values as
		/// defined below.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bit</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0-15</term>
		/// <term>Repeat count. Since the first byte and second byte are continuous, this is always 1.</term>
		/// </item>
		/// <item>
		/// <term>16-23</term>
		/// <term>Scan code for a complete Asian character.</term>
		/// </item>
		/// <item>
		/// <term>24</term>
		/// <term>Extended key.</term>
		/// </item>
		/// <item>
		/// <term>25-28</term>
		/// <term>Not used.</term>
		/// </item>
		/// <item>
		/// <term>29</term>
		/// <term>Context code.</term>
		/// </item>
		/// <item>
		/// <term>30</term>
		/// <term>Previous key state.</term>
		/// </item>
		/// <item>
		/// <term>31</term>
		/// <term>Transition state.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Unlike the <c>WM_CHAR</c> message for a non-Unicode window, this message can include double-byte and single-byte character
		/// values. For a Unicode window, this message is the same as WM_CHAR.
		/// </para>
		/// <para>
		/// For a non-Unicode window, if the WM_IME_CHAR message includes a double-byte character and the application passes this message to
		/// <c>DefWindowProc</c>, the IME converts this message into two WM_CHAR messages, each containing one byte of the double-byte character.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/intl/wm-ime-char
		[MsgParams(typeof(char), typeof(WM_KEY_LPARAM))]
		WM_IME_CHAR = 0x0286,

		/// <summary>
		/// <para>
		/// Sent to an application to provide commands and request information. A window receives this message through its <c>WindowProc</c> function.
		/// </para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, WM_IME_REQUEST, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hwnd</em></para>
		/// <para>A handle to window.</para>
		/// <para><em>wParam</em></para>
		/// <para>Command. This parameter can have one of the following values:</para>
		/// <list/>
		/// <para><em>lParam</em></para>
		/// <para>Command-specific data. For more information, see the description for each command.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a command-specific value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/intl/wm-ime-request
		[MsgParams(typeof(IntPtr), typeof(IntPtr))]
		WM_IME_REQUEST = 0x0288,

		/// <summary>
		/// <para>
		/// Sent to an application by the IME to notify the application of a key press and to keep message order. A window receives this
		/// message through its <c>WindowProc</c> function.
		/// </para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, WM_IME_KEYDOWN, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hwnd</em></para>
		/// <para>A handle to window.</para>
		/// <para><em>wParam</em></para>
		/// <para>Virtual key code of the key.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Repeat count, scan code, extended key flag, context code, previous key state flag, and transition state flag, as shown in the
		/// following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bit</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0-15</term>
		/// <term>Repeat count.</term>
		/// </item>
		/// <item>
		/// <term>16-23</term>
		/// <term>Scan code.</term>
		/// </item>
		/// <item>
		/// <term>24</term>
		/// <term>Extended key. This value is 1 if it is an extended key. Otherwise, it is 0.</term>
		/// </item>
		/// <item>
		/// <term>25-28</term>
		/// <term>Not used.</term>
		/// </item>
		/// <item>
		/// <term>29</term>
		/// <term>Context code. This value is always 0.</term>
		/// </item>
		/// <item>
		/// <term>30</term>
		/// <term>Previous key state. This value is 1 if the key is down or 0 if it is up.</term>
		/// </item>
		/// <item>
		/// <term>31</term>
		/// <term>Transition state. This value is always 0.</term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return 0 if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// An application can process this message or pass it to the <c>DefWindowProc</c> function to generate a matching <c>WM_KEYDOWN</c> message.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/intl/wm-ime-keydown
		[MsgParams(typeof(VK), typeof(WM_KEY_LPARAM))]
		WM_IME_KEYDOWN = 0x0290,

		/// <summary>
		/// <para>
		/// Sent to an application by the IME to notify the application of a key release and to keep message order. A window receives this
		/// message through its <c>WindowProc</c> function.
		/// </para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, WM_IME_KEYUP, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hwnd</em></para>
		/// <para>A handle to window.</para>
		/// <para><em>wParam</em></para>
		/// <para>Virtual key code of the key.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Repeat count, scan code, extended key flag, context code, previous key state flag, and transition state flag, as shown below.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bit</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0-15</term>
		/// <term>Repeat count. This value is always 1.</term>
		/// </item>
		/// <item>
		/// <term>16-23</term>
		/// <term>Scan code.</term>
		/// </item>
		/// <item>
		/// <term>24</term>
		/// <term>Extended key. This value is 1 if it is an extended key. Otherwise, it is 0.</term>
		/// </item>
		/// <item>
		/// <term>25-28</term>
		/// <term>Not used.</term>
		/// </item>
		/// <item>
		/// <term>29</term>
		/// <term>Context code. This value is always 0.</term>
		/// </item>
		/// <item>
		/// <term>30</term>
		/// <term>Previous key state. This value is always 1.</term>
		/// </item>
		/// <item>
		/// <term>31</term>
		/// <term>Transition state. This value is always 1.</term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>An application should return 0 if it processes this message.</para>
		/// </summary>
		/// <remarks>
		/// An application can process this message or pass it to the <c>DefWindowProc</c> function to generate a matching <c>WM_KEYUP</c> message.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/intl/wm-ime-keyup
		[MsgParams(typeof(VK), typeof(WM_KEY_LPARAM))]
		WM_IME_KEYUP = 0x0291,

		/// <summary>
		/// <para>
		/// Posted to a window when the cursor hovers over the client area of the window for the period of time specified in a prior call to <c>TrackMouseEvent</c>.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_MOUSEHOVER 0x02A1</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Indicates whether various virtual keys are down. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MK_CONTROL</c> 0x0008</term>
		/// <term>The CTRL key is depressed.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_LBUTTON</c> 0x0001</term>
		/// <term>The left mouse button is depressed.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_MBUTTON</c> 0x0010</term>
		/// <term>The middle mouse button is depressed.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_RBUTTON</c> 0x0002</term>
		/// <term>The right mouse button is depressed.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_SHIFT</c> 0x0004</term>
		/// <term>The SHIFT key is depressed.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON1</c> 0x0020</term>
		/// <term>The first X button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON2</c> 0x0040</term>
		/// <term>The second X button is down.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the x-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para>
		/// The high-order word specifies the y-coordinate of the cursor. The coordinate is relative to the upper-left corner of the client area.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Hover tracking stops when <c>WM_MOUSEHOVER</c> is generated. The application must call <c>TrackMouseEvent</c> again if it
		/// requires further tracking of mouse hover behavior.
		/// </para>
		/// <para>Use the following code to obtain the horizontal and vertical position:</para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the return value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the <c>MAKEPOINTS</c> macro to obtain a <c>POINTS</c> structure from the
		/// return value. You can also use the <c>GET_X_LPARAM</c> or <c>GET_Y_LPARAM</c> macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mousehover
		[MsgParams(typeof(MouseButtonState), typeof(POINTS))]
		WM_MOUSEHOVER = 0x02A1,

		/// <summary>
		/// <para>Posted to a window when the cursor leaves the client area of the window specified in a prior call to <c>TrackMouseEvent</c>.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_MOUSELEAVE 0x02A3</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// All tracking requested by <c>TrackMouseEvent</c> is canceled when this message is generated. The application must call
		/// <c>TrackMouseEvent</c> when the mouse reenters its window if it requires further tracking of mouse hover behavior.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-mouseleave
		[MsgParams()]
		WM_MOUSELEAVE = 0x02A3,

		/// <summary>
		/// <para>
		/// Posted to a window when the cursor hovers over the nonclient area of the window for the period of time specified in a prior call
		/// to <c>TrackMouseEvent</c>.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCMOUSEHOVER 0x02A0</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The hit-test value returned by the <c>DefWindowProc</c> function as a result of processing the <c>WM_NCHITTEST</c> message. For a
		/// list of hit-test values, see <c>WM_NCHITTEST</c>.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A <c>POINTS</c> structure that contains the x- and y-coordinates of the cursor. The coordinates are relative to the upper-left
		/// corner of the screen.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Hover tracking stops when this message is generated. The application must call <c>TrackMouseEvent</c> again if it requires
		/// further tracking of mouse hover behavior.
		/// </para>
		/// <para>
		/// You can also use the <c>GET_X_LPARAM</c> and <c>GET_Y_LPARAM</c> macros to extract the values of the x- and y- coordinates from lParam.
		/// </para>
		/// <para>
		/// <code>xPos = GET_X_LPARAM(lParam); yPos = GET_Y_LPARAM(lParam);</code>
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// Do not use the <c>LOWORD</c> or <c>HIWORD</c> macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncmousehover
		[MsgParams(typeof(HitTestValues), typeof(POINTS))]
		WM_NCMOUSEHOVER = 0x02A0,

		/// <summary>
		/// <para>Posted to a window when the cursor leaves the nonclient area of the window specified in a prior call to <c>TrackMouseEvent</c>.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_NCMOUSELEAVE 0x02A2</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// All tracking requested by <c>TrackMouseEvent</c> is canceled when this message is generated. The application must call
		/// <c>TrackMouseEvent</c> when the mouse reenters its window if it requires further tracking of mouse hover behavior.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-ncmouseleave
		[MsgParams()]
		WM_NCMOUSELEAVE = 0x02A2,

		/// <summary>
		/// <para>Notifies applications of changes in session state.</para>
		/// <para>The window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hWnd, // handle to window UINT Msg, // WM_WTSSESSION_CHANGE WPARAM wParam, // session state change event LPARAM lParam // session ID );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>hWnd</em></para>
		/// <para>Handle to the window.</para>
		/// <para><em>Msg</em></para>
		/// <para>Specifies the message ( <c>WM_WTSSESSION_CHANGE</c>).</para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Status code describing the reason the session state change notification was sent. This parameter can be one of the following values.
		/// </para>
		/// <para><em><c>WTS_CONSOLE_CONNECT</c> (0x1)</em></para>
		/// <para>The session identified by lParam was connected to the console terminal or RemoteFX session.</para>
		/// <para><em><c>WTS_CONSOLE_DISCONNECT</c> (0x2)</em></para>
		/// <para>The session identified by lParam was disconnected from the console terminal or RemoteFX session.</para>
		/// <para><em><c>WTS_REMOTE_CONNECT</c> (0x3)</em></para>
		/// <para>The session identified by lParam was connected to the remote terminal.</para>
		/// <para><em><c>WTS_REMOTE_DISCONNECT</c> (0x4)</em></para>
		/// <para>The session identified by lParam was disconnected from the remote terminal.</para>
		/// <para><em><c>WTS_SESSION_LOGON</c> (0x5)</em></para>
		/// <para>A user has logged on to the session identified by lParam.</para>
		/// <para><em><c>WTS_SESSION_LOGOFF</c> (0x6)</em></para>
		/// <para>A user has logged off the session identified by lParam.</para>
		/// <para><em><c>WTS_SESSION_LOCK</c> (0x7)</em></para>
		/// <para>The session identified by lParam has been locked.</para>
		/// <para><em><c>WTS_SESSION_UNLOCK</c> (0x8)</em></para>
		/// <para>The session identified by lParam has been unlocked.</para>
		/// <para><em><c>WTS_SESSION_REMOTE_CONTROL</c> (0x9)</em></para>
		/// <para>
		/// The session identified by lParam has changed its remote controlled status. To determine the status, call <c>GetSystemMetrics</c>
		/// and check the <c>SM_REMOTECONTROL</c> metric.
		/// </para>
		/// <para><em><c>WTS_SESSION_CREATE</c> (0xA)</em></para>
		/// <para>Reserved for future use.</para>
		/// <para><em><c>WTS_SESSION_TERMINATE</c> (0xB)</em></para>
		/// <para>Reserved for future use.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is ignored.</para>
		/// </summary>
		/// <remarks>
		/// <para>This message is sent only to applications that have registered to receive this message by calling <c>WTSRegisterSessionNotification</c>.</para>
		/// <para>
		/// Examples of how applications can respond to this message include releasing or acquiring console-specific resources, determining
		/// how a screen is to be painted, or triggering console animation effects.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/termserv/wm-wtssession-change
		[MsgParams(typeof(WTS), typeof(uint), LResultType = null)]
		WM_WTSSESSION_CHANGE = 0x02B1,

		/// <summary/>
		WM_TABLET_LAST = 0x02df,

		/// <summary>
		/// <para>
		/// Sent when the effective dots per inch (dpi) for a window has changed. The DPI is the scale factor for a window. There are
		/// multiple events that can cause the DPI to change. The following list indicates the possible causes for the change in DPI.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The window is moved to a new monitor that has a different DPI.</term>
		/// </item>
		/// <item>
		/// <term>The DPI of the monitor hosting the window changes.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The current DPI for a window always equals the last DPI sent by <c>WM_DPICHANGED</c>. This is the scale factor that the window
		/// should be scaling to for threads that are aware of DPI changes.
		/// </para>
		/// <para>
		/// <code>#define WM_DPICHANGED 0x02E0</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The <c>HIWORD</c> of the wParam contains the Y-axis value of the new dpi of the window. The <c>LOWORD</c> of the wParam contains
		/// the X-axis value of the new DPI of the window. For example, 96, 120, 144, or 192. The values of the X-axis and the Y-axis are
		/// identical for Windows apps.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>RECT</c> structure that provides a suggested size and position of the current window scaled for the new DPI.
		/// The expectation is that apps will reposition and resize windows based on the suggestions provided by lParam when handling this message.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This message is only relevant for <c>PROCESS_PER_MONITOR_DPI_AWARE</c> applications or <c>DPI_AWARENESS_PER_MONITOR_AWARE</c>
		/// threads. It may be received on certain DPI changes if your top-level window or process is running as <c>DPI unaware</c> or
		/// <c>system DPI aware</c>, but in those situations it can be safely ignored. For more information about the different types of
		/// awareness, see <c>PROCESS_DPI_AWARENESS</c> and <c>DPI_AWARENESS</c>. Older versions of Windows required DPI awareness to be tied
		/// at the level of an application. Those apps use <c>PROCESS_DPI_AWARENESS</c>. Currently, DPI awareness is tied to threads and
		/// individual windows rather than the entire application. These apps use <c>DPI_AWARENESS</c>.
		/// </para>
		/// <para>You only need to use either the X-axis or the Y-axis value when scaling your application since they are the same.</para>
		/// <para>
		/// In order to handle this message correctly, you will need to resize and reposition your window based on the suggestions provided
		/// by lParam and using <c>SetWindowPos</c>. If you do not do this, your window will grow or shrink with respect to everything else
		/// on the new monitor. For example, if a user is using multiple monitors and drags your window from a 96 DPI monitor to a 192 DPI
		/// monitor, your window will appear to be half as large with respect to other items on the 192 DPI monitor.
		/// </para>
		/// <para>
		/// The base value of DPI is defined as <c>USER_DEFAULT_SCREEN_DPI</c> which is set to 96. To determine the scaling factor for a
		/// monitor, take the DPI value and divide by <c>USER_DEFAULT_SCREEN_DPI</c>. The following table provides some sample DPI values and
		/// associated scaling factors.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>DPI value</term>
		/// <term>Scaling percentage</term>
		/// </listheader>
		/// <item>
		/// <term>96</term>
		/// <term>100%</term>
		/// </item>
		/// <item>
		/// <term>120</term>
		/// <term>125%</term>
		/// </item>
		/// <item>
		/// <term>144</term>
		/// <term>150%</term>
		/// </item>
		/// <item>
		/// <term>192</term>
		/// <term>200%</term>
		/// </item>
		/// </list>
		/// <para>The following example provides a sample DPI change handler.</para>
		/// <para>
		/// <code> case WM_DPICHANGED: { g_dpi = HIWORD(wParam); UpdateDpiDependentFontsAndResources(); RECT* const prcNewWindow = (RECT*)lParam; SetWindowPos(hWnd, NULL, prcNewWindow -&gt;left, prcNewWindow -&gt;top, prcNewWindow-&gt;right - prcNewWindow-&gt;left, prcNewWindow-&gt;bottom - prcNewWindow-&gt;top, SWP_NOZORDER | SWP_NOACTIVATE); break; }</code>
		/// </para>
		/// <para>The following code linearly scales a value from 100% (96 DPI) to an arbitrary DPI defined by g_dpi.</para>
		/// <para>
		/// <code> INT iBorderWidth100 = 5; iBorderWidth = MulDiv(iBorderWidth100, g_dpi, USER_DEFAULT_SCREEN_DPI);</code>
		/// </para>
		/// <para>An alternative way to scale a value is to convert the DPI value into a scale factor and use that.</para>
		/// <para>
		/// <code> INT iBorderWidth100 = 5; FLOAT fscale = (float) g_dpi / USER_DEFAULT_SCREEN_DPI; iBorderWidth = iBorderWidth100 * fscale;</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/hidpi/wm-dpichanged
		[MsgParams(typeof(WM_SIZE_WPARAM), typeof(RECT?))]
		WM_DPICHANGED = 0x02E0,

		/// <summary>
		/// <para>
		/// An application sends a <c>WM_CUT</c> message to an edit control or combo box to delete (cut) the current selection, if any, in
		/// the edit control and copy the deleted text to the clipboard in <c>CF_TEXT</c> format.
		/// </para>
		/// <para>
		/// <code>#define WM_CUT 0x0300</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// </summary>
		/// <remarks>
		/// <para>The deletion performed by the <c>WM_CUT</c> message can be undone by sending the edit control an <c>EM_UNDO</c> message.</para>
		/// <para>To delete the current selection without placing the deleted text on the clipboard, use the <c>WM_CLEAR</c> message.</para>
		/// <para>
		/// When sent to a combo box, the <c>WM_CUT</c> message is handled by its edit control. This message has no effect when sent to a
		/// combo box with the <c>CBS_DROPDOWNLIST</c> style.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dataxchg/wm-cut
		[MsgParams(LResultType = null)]
		WM_CUT = 0x0300,

		/// <summary>
		/// <para>
		/// An application sends the <c>WM_COPY</c> message to an edit control or combo box to copy the current selection to the clipboard in
		/// <c>CF_TEXT</c> format.
		/// </para>
		/// <para>
		/// <code>#define WM_COPY 0x0301</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns nonzero value on success, else zero.</para>
		/// </summary>
		/// <remarks>
		/// When sent to a combo box, the <c>WM_COPY</c> message is handled by its edit control. This message has no effect when sent to a
		/// combo box with the <c>CBS_DROPDOWNLIST</c> style.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dataxchg/wm-copy
		[MsgParams()]
		WM_COPY = 0x0301,

		/// <summary>
		/// <para>
		/// An application sends a <c>WM_PASTE</c> message to an edit control or combo box to copy the current content of the clipboard to
		/// the edit control at the current caret position. Data is inserted only if the clipboard contains data in <c>CF_TEXT</c> format.
		/// </para>
		/// <para>
		/// <code>#define WM_PASTE 0x0302</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// </summary>
		/// <remarks>
		/// When sent to a combo box, the <c>WM_PASTE</c> message is handled by its edit control. This message has no effect when sent to a
		/// combo box with the <c>CBS_DROPDOWNLIST</c> style.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dataxchg/wm-paste
		[MsgParams(LResultType = null)]
		WM_PASTE = 0x0302,

		/// <summary>
		/// <para>
		/// An application sends a <c>WM_CLEAR</c> message to an edit control or combo box to delete (clear) the current selection, if any,
		/// from the edit control.
		/// </para>
		/// <para>
		/// <code>#define WM_CLEAR 0x0303</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// </summary>
		/// <remarks>
		/// <para>The deletion performed by the <c>WM_CLEAR</c> message can be undone by sending the edit control an <c>EM_UNDO</c> message.</para>
		/// <para>To delete the current selection and place the deleted content on the clipboard, use the <c>WM_CUT</c> message.</para>
		/// <para>
		/// When sent to a combo box, the <c>WM_CLEAR</c> message is handled by its edit control. This message has no effect when sent to a
		/// combo box with the <c>CBS_DROPDOWNLIST</c> style.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dataxchg/wm-clear
		[MsgParams(LResultType = null)]
		WM_CLEAR = 0x0303,

		/// <summary>
		/// An application sends a <c>WM_UNDO</c> message to an edit control to undo the last operation. When this message is sent to an edit
		/// control, the previously deleted text is restored or the previously added text is deleted.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the message succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the message fails, the return value is <c>FALSE</c>.</para>
		/// </summary>
		/// <remarks><c>Rich Edit:</c> It is recommended that <c>EM_UNDO</c> be used instead of <c>WM_UNDO</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/wm-undo
		[MsgParams(LResultType = typeof(BOOL))]
		WM_UNDO = 0x0304,

		/// <summary>
		/// <para>
		/// Sent to the clipboard owner if it has delayed rendering a specific clipboard format and if an application has requested data in
		/// that format. The clipboard owner must render data in the specified format and place it on the clipboard by calling the
		/// <c>SetClipboardData</c> function.
		/// </para>
		/// <para>
		/// <code>#define WM_RENDERFORMAT 0x0305</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The clipboard format to be rendered.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// When responding to a <c>WM_RENDERFORMAT</c> message, the clipboard owner must not open the clipboard before calling
		/// <c>SetClipboardData</c>. Opening the clipboard is not necessary before placing data in response to <c>WM_RENDERFORMAT</c>, and
		/// any attempt to open the clipboard will fail because the clipboard is currently being held open by the application that requested
		/// the format to be rendered.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dataxchg/wm-renderformat
		[MsgParams(typeof(CLIPFORMAT), null)]
		WM_RENDERFORMAT = 0x0305,

		/// <summary>
		/// <para>
		/// Sent to the clipboard owner before it is destroyed, if the clipboard owner has delayed rendering one or more clipboard formats.
		/// For the content of the clipboard to remain available to other applications, the clipboard owner must render data in all the
		/// formats it is capable of generating, and place the data on the clipboard by calling the <c>SetClipboardData</c> function.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_RENDERALLFORMATS 0x0306</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When responding to a <c>WM_RENDERALLFORMATS</c> message, the application must call the <c>OpenClipboard</c> function and then
		/// check that it is still the clipboard owner by calling the <c>GetClipboardOwner</c> function before calling <c>SetClipboardData</c>.
		/// </para>
		/// <para>
		/// The application needs to check that it is still the clipboard owner after opening the clipboard because after it receives the
		/// <c>WM_RENDERALLFORMATS</c> message, but before it opens the clipboard, another application may have opened and taken ownership of
		/// the clipboard, and that application's data should not be overwritten.
		/// </para>
		/// <para>
		/// In most cases, the application should not call the <c>EmptyClipboard</c> function before calling <c>SetClipboardData</c>, since
		/// doing so will erase the clipboard formats that the application has already rendered.
		/// </para>
		/// <para>
		/// When the application returns, the system removes any unrendered formats from the list of available clipboard formats. For
		/// information about delayed rendering, see Delayed Rendering.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dataxchg/wm-renderallformats
		[MsgParams()]
		WM_RENDERALLFORMATS = 0x0306,

		/// <summary>
		/// <para>Sent to the clipboard owner when a call to the <c>EmptyClipboard</c> function empties the clipboard.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_DESTROYCLIPBOARD 0x0307</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/dataxchg/wm-destroyclipboard
		[MsgParams()]
		WM_DESTROYCLIPBOARD = 0x0307,

		/// <summary>
		/// <para>
		/// Sent to the first window in the clipboard viewer chain when the content of the clipboard changes. This enables a clipboard viewer
		/// window to display the new content of the clipboard.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_DRAWCLIPBOARD 0x0308</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Only clipboard viewer windows receive this message. These are windows that have been added to the clipboard viewer chain by using
		/// the <c>SetClipboardViewer</c> function.
		/// </para>
		/// <para>
		/// Each window that receives the <c>WM_DRAWCLIPBOARD</c> message must call the <c>SendMessage</c> function to pass the message on to
		/// the next window in the clipboard viewer chain. The handle to the next window in the chain is returned by
		/// <c>SetClipboardViewer</c>, and may change in response to a <c>WM_CHANGECBCHAIN</c> message.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dataxchg/wm-drawclipboard
		[MsgParams()]
		WM_DRAWCLIPBOARD = 0x0308,

		/// <summary>
		/// <para>
		/// Sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the <c>CF_OWNERDISPLAY</c> format
		/// and the clipboard viewer's client area needs repainting.
		/// </para>
		/// <para>
		/// <code>#define WM_PAINTCLIPBOARD 0x0309</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the clipboard viewer window.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A handle to a global memory object that contains a <c>PAINTSTRUCT</c> structure. The structure defines the part of the client
		/// area to paint.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To determine whether the entire client area or just a portion of it needs repainting, the clipboard owner must compare the
		/// dimensions of the drawing area given in the <c>rcPaint</c> member of <c>PAINTSTRUCT</c> to the dimensions given in the most
		/// recent <c>WM_SIZECLIPBOARD</c> message.
		/// </para>
		/// <para>
		/// The clipboard owner must use the <c>GlobalLock</c> function to lock the memory that contains the <c>PAINTSTRUCT</c> structure.
		/// Before returning, the clipboard owner must unlock that memory by using the <c>GlobalUnlock</c> function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dataxchg/wm-paintclipboard
		[MsgParams(typeof(HWND), typeof(PAINTSTRUCT?))]
		WM_PAINTCLIPBOARD = 0x0309,

		/// <summary>
		/// <para>
		/// Sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the <c>CF_OWNERDISPLAY</c> format
		/// and an event occurs in the clipboard viewer's vertical scroll bar. The owner should scroll the clipboard image and update the
		/// scroll bar values.
		/// </para>
		/// <para>
		/// <code>#define WM_VSCROLLCLIPBOARD 0x030A</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the clipboard viewer window.</para>
		/// <para><em>lParam</em></para>
		/// <para>The low-order word of lParam specifies a scroll bar event. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SB_BOTTOM</c> 7</term>
		/// <term>Scroll to lower right.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_ENDSCROLL</c> 8</term>
		/// <term>End scroll.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_LINEDOWN</c> 1</term>
		/// <term>Scroll one line down.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_LINEUP</c> 0</term>
		/// <term>Scroll one line up.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_PAGEDOWN</c> 3</term>
		/// <term>Scroll one page down.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_PAGEUP</c> 2</term>
		/// <term>Scroll one page up.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_THUMBPOSITION</c> 4</term>
		/// <term>Scroll to absolute position. The current position is specified by the high-order word.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_TOP</c> 6</term>
		/// <term>Scroll to upper left.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The high-order word of lParam specifies the current position of the scroll box if the low-order word of lParam is
		/// <c>SB_THUMBPOSITION</c>; otherwise, the high-order word of lParam is not used.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// The clipboard owner can use the <c>ScrollWindow</c> function to scroll the image in the clipboard viewer window and invalidate
		/// the appropriate region.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dataxchg/wm-vscrollclipboard
		[MsgParams(typeof(HWND), typeof(WM_SCROLL_LPARAM))]
		WM_VSCROLLCLIPBOARD = 0x030A,

		/// <summary>
		/// <para>
		/// Sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the <c>CF_OWNERDISPLAY</c> format
		/// and the clipboard viewer's client area has changed size.
		/// </para>
		/// <para>
		/// <code>#define WM_SIZECLIPBOARD 0x030B</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the clipboard viewer window.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A handle to a global memory object that contains a <c>RECT</c> structure. The structure specifies the new dimensions of the
		/// clipboard viewer's client area.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When the clipboard viewer window is about to be destroyed or resized, a <c>WM_SIZECLIPBOARD</c> message is sent with a null
		/// rectangle (0, 0, 0, 0) as the new size. This permits the clipboard owner to free its display resources.
		/// </para>
		/// <para>
		/// The clipboard owner must use the <c>GlobalLock</c> function to lock the memory object that contains <c>RECT</c>. Before
		/// returning, the clipboard owner must unlock the object by using the <c>GlobalUnlock</c> function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dataxchg/wm-sizeclipboard
		[MsgParams(typeof(HWND), typeof(RECT?))]
		WM_SIZECLIPBOARD = 0x030B,

		/// <summary>
		/// <para>Sent to the clipboard owner by a clipboard viewer window to request the name of a <c>CF_OWNERDISPLAY</c> clipboard format.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_ASKCBFORMATNAME 0x030C</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The size, in characters, of the buffer pointed to by the lParam parameter.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to the buffer that is to receive the clipboard format name.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// In response to this message, the clipboard owner should copy the name of the owner-display format to the specified buffer, not
		/// exceeding the buffer size specified by the wParam parameter.
		/// </para>
		/// <para>
		/// A clipboard viewer window sends this message to the clipboard owner to determine the name of the <c>CF_OWNERDISPLAY</c> format
		/// for example, to initialize a menu listing available formats.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dataxchg/wm-askcbformatname
		[MsgParams(typeof(uint), typeof(IntPtr))]
		WM_ASKCBFORMATNAME = 0x030C,

		/// <summary>
		/// <para>Sent to the first window in the clipboard viewer chain when a window is being removed from the chain.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_CHANGECBCHAIN 0x030D</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the window being removed from the clipboard viewer chain.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A handle to the next window in the chain following the window being removed. This parameter is <c>NULL</c> if the window being
		/// removed is the last window in the chain.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Each clipboard viewer window saves the handle to the next window in the clipboard viewer chain. Initially, this handle is the
		/// return value of the <c>SetClipboardViewer</c> function.
		/// </para>
		/// <para>
		/// When a clipboard viewer window receives the <c>WM_CHANGECBCHAIN</c> message, it should call the <c>SendMessage</c> function to
		/// pass the message to the next window in the chain, unless the next window is the window being removed. In this case, the clipboard
		/// viewer should save the handle specified by the lParam parameter as the next window in the chain.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dataxchg/wm-changecbchain
		[MsgParams(typeof(HWND), typeof(HWND))]
		WM_CHANGECBCHAIN = 0x030D,

		/// <summary>
		/// <para>
		/// Sent to the clipboard owner by a clipboard viewer window. This occurs when the clipboard contains data in the
		/// <c>CF_OWNERDISPLAY</c> format and an event occurs in the clipboard viewer's horizontal scroll bar. The owner should scroll the
		/// clipboard image and update the scroll bar values.
		/// </para>
		/// <para>
		/// <code>#define WM_HSCROLLCLIPBOARD 0x030E</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the clipboard viewer window.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word of lParam specifies a scroll bar event. This parameter can be one of the following values. The high-order word
		/// of lParam specifies the current position of the scroll box if the low-order word of lParam is <c>SB_THUMBPOSITION</c>; otherwise,
		/// the high-order word is not used.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SB_ENDSCROLL</c> 8</term>
		/// <term>End scroll.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_LEFT</c> 6</term>
		/// <term>Scroll to upper left.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_RIGHT</c> 7</term>
		/// <term>Scroll to lower right.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_LINELEFT</c> 0</term>
		/// <term>Scrolls left by one unit.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_LINERIGHT</c> 1</term>
		/// <term>Scrolls right by one unit.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_PAGELEFT</c> 2</term>
		/// <term>Scrolls left by the width of the window.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_PAGERIGHT</c> 3</term>
		/// <term>Scrolls right by the width of the window.</term>
		/// </item>
		/// <item>
		/// <term><c>SB_THUMBPOSITION</c> 4</term>
		/// <term>Scroll to absolute position. The current position is specified by the high-order word.</term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// The clipboard owner can use the <c>ScrollWindow</c> function to scroll the image in the clipboard viewer window and invalidate
		/// the appropriate region.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dataxchg/wm-hscrollclipboard
		[MsgParams(typeof(HWND), typeof(WM_SCROLL_LPARAM))]
		WM_HSCROLLCLIPBOARD = 0x030E,

		/// <summary>
		/// <para>
		/// The <c>WM_QUERYNEWPALETTE</c> message informs a window that it is about to receive the keyboard focus, giving the window the
		/// opportunity to realize its logical palette when it receives the focus.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the window realizes its logical palette, it must return <c>TRUE</c>; otherwise, it must return <c>FALSE</c>.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/gdi/wm-querynewpalette
		[MsgParams(LResultType = typeof(BOOL))]
		WM_QUERYNEWPALETTE = 0x030F,

		/// <summary>
		/// <para>The <c>WM_PALETTEISCHANGING</c> message informs applications that an application is going to realize its logical palette.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the window that is going to realize its logical palette.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The application changing its palette does not wait for acknowledgment of this message before changing the palette and sending the
		/// <c>WM_PALETTECHANGED</c> message. As a result, the palette may already be changed by the time an application receives this message.
		/// </para>
		/// <para>
		/// If the application either ignores or fails to process this message and a second application realizes its palette while the first
		/// is using palette indexes, there is a strong possibility that the user will see unexpected colors during subsequent drawing operations.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/gdi/wm-paletteischanging
		[MsgParams(typeof(HWND), null)]
		WM_PALETTEISCHANGING = 0x0310,

		/// <summary>
		/// <para>
		/// The <c>WM_PALETTECHANGED</c> message is sent to all top-level and overlapped windows after the window with the keyboard focus has
		/// realized its logical palette, thereby changing the system palette. This message enables a window that uses a color palette but
		/// does not have the keyboard focus to realize its logical palette and update its client area.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the window that caused the system palette to change.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This message must be sent to all top-level and overlapped windows, including the one that changed the system palette. If any
		/// child windows use a color palette, this message must be passed on to them as well.
		/// </para>
		/// <para>
		/// To avoid creating an infinite loop, a window that receives this message must not realize its palette, unless it determines that
		/// wParam does not contain its own window handle.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/gdi/wm-palettechanged
		[MsgParams(typeof(HWND), null, LResultType = null)]
		WM_PALETTECHANGED = 0x0311,

		/// <summary>
		/// <para>
		/// Posted when the user presses a hot key registered by the <c>RegisterHotKey</c> function. The message is placed at the top of the
		/// message queue associated with the thread that registered the hot key.
		/// </para>
		/// <para>
		/// <code>#define WM_HOTKEY 0x0312</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The identifier of the hot key that generated the message. If the message was generated by a system-defined hot key, this
		/// parameter will be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>IDHOT_SNAPDESKTOP</c> -2</term>
		/// <term>The "snap desktop" hot key was pressed.</term>
		/// </item>
		/// <item>
		/// <term><c>IDHOT_SNAPWINDOW</c> -1</term>
		/// <term>The "snap window" hot key was pressed.</term>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The low-order word specifies the keys that were to be pressed in combination with the key specified by the high-order word to
		/// generate the <c>WM_HOTKEY</c> message. This word can be one or more of the following values. The high-order word specifies the
		/// virtual key code of the hot key.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MOD_ALT</c> 0x0001</term>
		/// <term>Either ALT key was held down.</term>
		/// </item>
		/// <item>
		/// <term><c>MOD_CONTROL</c> 0x0002</term>
		/// <term>Either CTRL key was held down.</term>
		/// </item>
		/// <item>
		/// <term><c>MOD_SHIFT</c> 0x0004</term>
		/// <term>Either SHIFT key was held down.</term>
		/// </item>
		/// <item>
		/// <term><c>MOD_WIN</c> 0x0008</term>
		/// <term>
		/// Either WINDOWS key was held down. These keys are labeled with the Windows logo. Hotkeys that involve the Windows key are reserved
		/// for use by the operating system.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <c>WM_HOTKEY</c> is unrelated to the <c>WM_GETHOTKEY</c> and <c>WM_SETHOTKEY</c> hot keys. The <c>WM_HOTKEY</c> message is sent
		/// for generic hot keys while the <c>WM_SETHOTKEY</c> and <c>WM_GETHOTKEY</c> messages relate to window activation hot keys.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-hotkey
		[MsgParams(typeof(int), typeof(WM_HOTKEY_LPARAM), LResultType = null)]
		WM_HOTKEY = 0x0312,

		/// <summary>
		/// <para>
		/// The <c>WM_PRINT</c> message is sent to a window to request that it draw itself in the specified device context, most commonly in
		/// a printer device context.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the device context to draw in.</para>
		/// <para><em>lParam</em></para>
		/// <para>The drawing options. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>PRF_CHECKVISIBLE</c></term>
		/// <term>Draws the window only if it is visible.</term>
		/// </item>
		/// <item>
		/// <term><c>PRF_CHILDREN</c></term>
		/// <term>Draws all visible children windows.</term>
		/// </item>
		/// <item>
		/// <term><c>PRF_CLIENT</c></term>
		/// <term>Draws the client area of the window.</term>
		/// </item>
		/// <item>
		/// <term><c>PRF_ERASEBKGND</c></term>
		/// <term>Erases the background before drawing the window.</term>
		/// </item>
		/// <item>
		/// <term><c>PRF_NONCLIENT</c></term>
		/// <term>Draws the nonclient area of the window.</term>
		/// </item>
		/// <item>
		/// <term><c>PRF_OWNED</c></term>
		/// <term>Draws all owned windows.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// The <c>DefWindowProc</c> function processes this message based on which drawing option is specified: if PRF_CHECKVISIBLE is
		/// specified and the window is not visible, do nothing, if PRF_NONCLIENT is specified, draw the nonclient area in the specified
		/// device context, if PRF_ERASEBKGND is specified, send the window a <c>WM_ERASEBKGND</c> message, if PRF_CLIENT is specified, send
		/// the window a <c>WM_PRINTCLIENT</c> message, if PRF_CHILDREN is set, send each visible child window a <c>WM_PRINT</c> message, if
		/// PRF_OWNED is set, send each visible owned window a <c>WM_PRINT</c> message.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/gdi/wm-print
		[MsgParams(typeof(HDC), typeof(PRF), LResultType = null)]
		WM_PRINT = 0x0317,

		/// <summary>
		/// <para>
		/// The <c>WM_PRINTCLIENT</c> message is sent to a window to request that it draw its client area in the specified device context,
		/// most commonly in a printer device context.
		/// </para>
		/// <para>
		/// Unlike <c>WM_PRINT</c>, <c>WM_PRINTCLIENT</c> is not processed by <c>DefWindowProc</c>. A window should process the
		/// <c>WM_PRINTCLIENT</c> message through an application-defined <c>WindowProc</c> function for it to be used properly.
		/// </para>
		/// <para>
		/// <code>LRESULT CALLBACK WindowProc( HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam );</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A handle to the device context to draw in.</para>
		/// <para><em>lParam</em></para>
		/// <para>The drawing options. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>PRF_CHECKVISIBLE</c></term>
		/// <term>Draws the window only if it is visible.</term>
		/// </item>
		/// <item>
		/// <term><c>PRF_CHILDREN</c></term>
		/// <term>Draws all visible children windows.</term>
		/// </item>
		/// <item>
		/// <term><c>PRF_CLIENT</c></term>
		/// <term>Draws the client area of the window.</term>
		/// </item>
		/// <item>
		/// <term><c>PRF_ERASEBKGND</c></term>
		/// <term>Erases the background before drawing the window.</term>
		/// </item>
		/// <item>
		/// <term><c>PRF_NONCLIENT</c></term>
		/// <term>Draws the nonclient area of the window.</term>
		/// </item>
		/// <item>
		/// <term><c>PRF_OWNED</c></term>
		/// <term>Draws all owned windows.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A window can process this message in much the same manner as <c>WM_PAINT</c>, except that <c>BeginPaint</c> and <c>EndPaint</c>
		/// need not be called (a device context is provided), and the window should draw its entire client area rather than just the invalid region.
		/// </para>
		/// <para>
		/// Windows that can be used anywhere in the system, such as controls, should process this message. It is probably worthwhile for
		/// other windows to process this message as well because it is relatively easy to implement.
		/// </para>
		/// <para>The AnimateWindow function requires that the window being animated implements the <c>WM_PRINTCLIENT</c> message.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/gdi/wm-printclient
		[MsgParams(typeof(HDC), typeof(PRF), LResultType = null)]
		WM_PRINTCLIENT = 0x0318,

		/// <summary>
		/// <para>
		/// Notifies a window that the user generated an application command event, for example, by clicking an application command button
		/// using the mouse or typing an application command key on the keyboard.
		/// </para>
		/// <para>
		/// <code>#define WM_APPCOMMAND 0x0319</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A handle to the window where the user clicked the button or pressed the key. This can be a child window of the window receiving
		/// the message. For more information about processing this message, see the Remarks section.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Use the following code to get the information contained in the lParam parameter.</para>
		/// <para>
		/// <code>cmd = GET_APPCOMMAND_LPARAM(lParam); uDevice = GET_DEVICE_LPARAM(lParam); dwKeys = GET_KEYSTATE_LPARAM(lParam);</code>
		/// </para>
		/// <para>The application command is cmd, which can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>APPCOMMAND_BASS_BOOST</c> 20</term>
		/// <term>Toggle the bass boost on and off.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_BASS_DOWN</c> 19</term>
		/// <term>Decrease the bass.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_BASS_UP</c> 21</term>
		/// <term>Increase the bass.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_BROWSER_BACKWARD</c> 1</term>
		/// <term>Navigate backward.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_BROWSER_FAVORITES</c> 6</term>
		/// <term>Open favorites.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_BROWSER_FORWARD</c> 2</term>
		/// <term>Navigate forward.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_BROWSER_HOME</c> 7</term>
		/// <term>Navigate home.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_BROWSER_REFRESH</c> 3</term>
		/// <term>Refresh page.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_BROWSER_SEARCH</c> 5</term>
		/// <term>Open search.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_BROWSER_STOP</c> 4</term>
		/// <term>Stop download.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_CLOSE</c> 31</term>
		/// <term>Close the window (not the application).</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_COPY</c> 36</term>
		/// <term>Copy the selection.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_CORRECTION_LIST</c> 45</term>
		/// <term>Brings up the correction list when a word is incorrectly identified during speech input.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_CUT</c> 37</term>
		/// <term>Cut the selection.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_DICTATE_OR_COMMAND_CONTROL_TOGGLE</c> 43</term>
		/// <term>
		/// Toggles between two modes of speech input: dictation and command/control (giving commands to an application or accessing menus).
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_FIND</c> 28</term>
		/// <term>Open the <c>Find</c> dialog.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_FORWARD_MAIL</c> 40</term>
		/// <term>Forward a mail message.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_HELP</c> 27</term>
		/// <term>Open the <c>Help</c> dialog.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_LAUNCH_APP1</c> 17</term>
		/// <term>Start App1.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_LAUNCH_APP2</c> 18</term>
		/// <term>Start App2.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_LAUNCH_MAIL</c> 15</term>
		/// <term>Open mail.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_LAUNCH_MEDIA_SELECT</c> 16</term>
		/// <term>Go to Media Select mode.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_MEDIA_CHANNEL_DOWN</c> 52</term>
		/// <term>Decrement the channel value, for example, for a TV or radio tuner.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_MEDIA_CHANNEL_UP</c> 51</term>
		/// <term>Increment the channel value, for example, for a TV or radio tuner.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_MEDIA_FAST_FORWARD</c> 49</term>
		/// <term>
		/// Increase the speed of stream playback. This can be implemented in many ways, for example, using a fixed speed or toggling through
		/// a series of increasing speeds.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_MEDIA_NEXTTRACK</c> 11</term>
		/// <term>Go to next track.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_MEDIA_PAUSE</c> 47</term>
		/// <term>
		/// Pause. If already paused, take no further action. This is a direct PAUSE command that has no state. If there are discrete Play
		/// and Pause buttons, applications should take action on this command as well as <c>APPCOMMAND_MEDIA_PLAY_PAUSE</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_MEDIA_PLAY</c> 46</term>
		/// <term>
		/// Begin playing at the current position. If already paused, it will resume. This is a direct PLAY command that has no state. If
		/// there are discrete <c>Play</c> and <c>Pause</c> buttons, applications should take action on this command as well as <c>APPCOMMAND_MEDIA_PLAY_PAUSE</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_MEDIA_PLAY_PAUSE</c> 14</term>
		/// <term>
		/// Play or pause playback. If there are discrete <c>Play</c> and <c>Pause</c> buttons, applications should take action on this
		/// command as well as <c>APPCOMMAND_MEDIA_PLAY</c> and <c>APPCOMMAND_MEDIA_PAUSE</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_MEDIA_PREVIOUSTRACK</c> 12</term>
		/// <term>Go to previous track.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_MEDIA_RECORD</c> 48</term>
		/// <term>Begin recording the current stream.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_MEDIA_REWIND</c> 50</term>
		/// <term>
		/// Go backward in a stream at a higher rate of speed. This can be implemented in many ways, for example, using a fixed speed or
		/// toggling through a series of increasing speeds.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_MEDIA_STOP</c> 13</term>
		/// <term>Stop playback.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_MIC_ON_OFF_TOGGLE</c> 44</term>
		/// <term>Toggle the microphone.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_MICROPHONE_VOLUME_DOWN</c> 25</term>
		/// <term>Decrease microphone volume.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_MICROPHONE_VOLUME_MUTE</c> 24</term>
		/// <term>Mute the microphone.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_MICROPHONE_VOLUME_UP</c> 26</term>
		/// <term>Increase microphone volume.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_NEW</c> 29</term>
		/// <term>Create a new window.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_OPEN</c> 30</term>
		/// <term>Open a window.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_PASTE</c> 38</term>
		/// <term>Paste</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_PRINT</c> 33</term>
		/// <term>Print current document.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_REDO</c> 35</term>
		/// <term>Redo last action.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_REPLY_TO_MAIL</c> 39</term>
		/// <term>Reply to a mail message.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_SAVE</c> 32</term>
		/// <term>Save current document.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_SEND_MAIL</c> 41</term>
		/// <term>Send a mail message.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_SPELL_CHECK</c> 42</term>
		/// <term>Initiate a spell check.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_TREBLE_DOWN</c> 22</term>
		/// <term>Decrease the treble.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_TREBLE_UP</c> 23</term>
		/// <term>Increase the treble.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_UNDO</c> 34</term>
		/// <term>Undo last action.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_VOLUME_DOWN</c> 9</term>
		/// <term>Lower the volume.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_VOLUME_MUTE</c> 8</term>
		/// <term>Mute the volume.</term>
		/// </item>
		/// <item>
		/// <term><c>APPCOMMAND_VOLUME_UP</c> 10</term>
		/// <term>Raise the volume.</term>
		/// </item>
		/// </list>
		/// <para>The uDevice component indicates the input device that generated the input event, and can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>FAPPCOMMAND_KEY</c> 0</term>
		/// <term>User pressed a key.</term>
		/// </item>
		/// <item>
		/// <term><c>FAPPCOMMAND_MOUSE</c> 0x8000</term>
		/// <term>User clicked a mouse button.</term>
		/// </item>
		/// <item>
		/// <term><c>FAPPCOMMAND_OEM</c> 0x1000</term>
		/// <term>An unidentified hardware source generated the event. It could be a mouse or a keyboard event.</term>
		/// </item>
		/// </list>
		/// <para>The dwKeys component indicates whether various virtual keys are down, and can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>MK_CONTROL</c> 0x0008</term>
		/// <term>The CTRL key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_LBUTTON</c> 0x0001</term>
		/// <term>The left mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_MBUTTON</c> 0x0010</term>
		/// <term>The middle mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_RBUTTON</c> 0x0002</term>
		/// <term>The right mouse button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_SHIFT</c> 0x0004</term>
		/// <term>The SHIFT key is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON1</c> 0x0020</term>
		/// <term>The first X button is down.</term>
		/// </item>
		/// <item>
		/// <term><c>MK_XBUTTON2</c> 0x0040</term>
		/// <term>The second X button is down.</term>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If an application processes this message, it should return <c>TRUE</c>. For more information about processing the return value,
		/// see the Remarks section.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// <c>DefWindowProc</c> generates the <c>WM_APPCOMMAND</c> message when it processes the <c>WM_XBUTTONUP</c> or
		/// <c>WM_NCXBUTTONUP</c> message, or when the user types an application command key.
		/// </para>
		/// <para>
		/// If a child window does not process this message and instead calls <c>DefWindowProc</c>, <c>DefWindowProc</c> will send the
		/// message to its parent window. If a top level window does not process this message and instead calls <c>DefWindowProc</c>,
		/// <c>DefWindowProc</c> will call a shell hook with the hook code equal to <c>HSHELL_APPCOMMAND</c>.
		/// </para>
		/// <para>
		/// To get the coordinates of the cursor if the message was generated by a mouse click, the application can call
		/// <c>GetMessagePos</c>. An application can test whether the message was generated by the mouse by checking whether lParam contains <c>FAPPCOMMAND_MOUSE</c>.
		/// </para>
		/// <para>
		/// Unlike other windows messages, an application should return <c>TRUE</c> from this message if it processes it. Doing so will allow
		/// software that simulates this message on Windows systems earlier than Windows 2000 to determine whether the window procedure
		/// processed the message or called <c>DefWindowProc</c> to process it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-appcommand
		[MsgParams(typeof(HWND), typeof(IntPtr), LResultType = typeof(BOOL))]
		WM_APPCOMMAND = 0x0319,

		/// <summary>
		/// <para>
		/// Broadcast to every window following a theme change event. Examples of theme change events are the activation of a theme, the
		/// deactivation of a theme, or a transition from one theme to another.
		/// </para>
		/// <para>
		/// <code>#define WM_THEMECHANGED 0x031A</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is reserved.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is reserved.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>This message is posted by the operating system. Applications typically do not send this message.</para>
		/// </para>
		/// <para>
		/// Themes are specifications for the appearance of controls, so that the visual element of a control is treated separately from its functionality.
		/// </para>
		/// <para>To release an existing theme handle, call <c>CloseThemeData</c>. To acquire a new theme handle, use <c>OpenThemeData</c>.</para>
		/// <para>
		/// Following the <c>WM_THEMECHANGED</c> broadcast, any existing theme handles are invalid. A theme-aware window should release and
		/// reopen any of its pre-existing theme handles when it receives the <c>WM_THEMECHANGED</c> message. If the <c>OpenThemeData</c>
		/// function returns <c>NULL</c>, the window should paint unthemed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-themechanged
		[MsgParams()]
		WM_THEMECHANGED = 0x031A,

		/// <summary>
		/// <para>Sent when the contents of the clipboard have changed.</para>
		/// <para>
		/// <code>#define WM_CLIPBOARDUPDATE 0x031D</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used and must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>To register a window to receive this message, use the <c>AddClipboardFormatListener</c> function.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dataxchg/wm-clipboardupdate
		[MsgParams()]
		WM_CLIPBOARDUPDATE = 0x031D,

		/// <summary>
		/// <para>Informs all top-level windows that Desktop Window Manager (DWM) composition has been enabled or disabled.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>As of Windows 8, DWM composition is always enabled, so this message is not sent regardless of video mode changes.</para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>The <c>DwmIsCompositionEnabled</c> function can be used to determine the current composition state.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dwm/wm-dwmcompositionchanged
		[MsgParams()]
		WM_DWMCOMPOSITIONCHANGED = 0x031E,

		/// <summary>
		/// Sent when the non-client area rendering policy has changed.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies whether DWM rendering is enabled for the non-client area of the window. <c>TRUE</c> if enabled; otherwise, <c>FALSE</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// The <c>DwmGetWindowAttribute</c> and <c>DwmSetWindowAttribute</c> functions are used to get or set the non-client rendering policy.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dwm/wm-dwmncrenderingchanged
		[MsgParams(typeof(BOOL), null)]
		WM_DWMNCRENDERINGCHANGED = 0x031F,

		/// <summary>
		/// Informs all top-level windows that the colorization color has changed.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the new colorization color. The color format is 0xAARRGGBB.</para>
		/// <para><em>lParam</em></para>
		/// <para>Specifies whether the new color is blended with opacity.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para><c>DwmGetColorizationColor</c> is used to determine the current color value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dwm/wm-dwmcolorizationcolorchanged
		[MsgParams(typeof(COLORREF), typeof(BOOL))]
		WM_DWMCOLORIZATIONCOLORCHANGED = 0x0320,

		/// <summary>
		/// Sent when a Desktop Window Manager (DWM) composed window is maximized.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Set to true to specify that the window has been maximized.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// </summary>
		/// <remarks>A window receives this message through its <c>WindowProc</c> function.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/dwm/wm-dwmwindowmaximizedchange
		[MsgParams(typeof(BOOL), null)]
		WM_DWMWINDOWMAXIMIZEDCHANGE = 0x0321,

		/// <summary>
		/// <para>Sent to request extended title bar information. A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <code>#define WM_GETTITLEBARINFOEX 0x033F</code>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used and must be 0.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A pointer to a <c>TITLEBARINFOEX</c> structure. The message sender is responsible for allocating memory for this structure. Set
		/// the <c>cbSize</c> member of this structure to
		/// <code>sizeof(TITLEBARINFOEX)</code>
		/// before passing this structure with the message.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The following example shows how the message receiver casts an <c>LPARAM</c> value to retrieve the <c>TITLEBARINFOEX</c> structure.
		/// </para>
		/// <para>
		/// <code>TITLEBARINFOEX *ptinfo = (TITLEBARINFOEX *)lParam;</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/menurc/wm-gettitlebarinfoex
		[MsgParams(null, typeof(TITLEBARINFO?), LResultType = null)]
		WM_GETTITLEBARINFOEX = 0x033F,

		/// <summary/>
		WM_HANDHELDFIRST = 0x0358,

		/// <summary/>
		WM_HANDHELDLAST = 0x035F,

		/// <summary/>
		WM_AFXFIRST = 0x0360,

		/// <summary/>
		WM_AFXLAST = 0x037F,

		/// <summary/>
		WM_PENWINFIRST = 0x0380,

		/// <summary/>
		WM_PENWINLAST = 0x038F,

		/// <summary>
		/// <para>Used to define private messages, usually of the form <c>WM_APP</c>+x, where x is an integer value.</para>
		/// <para>
		/// <code>#define WM_APP 0x8000</code>
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>WM_APP</c> constant is used to distinguish between message values that are reserved for use by the system and values that
		/// can be used by an application to send messages within a private window class. The following are the ranges of message numbers available.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Range</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0 through <c>WM_USER</c> –1</term>
		/// <term>Messages reserved for use by the system.</term>
		/// </item>
		/// <item>
		/// <term><c>WM_USER</c> through 0x7FFF</term>
		/// <term>Integer messages for use by private window classes.</term>
		/// </item>
		/// <item>
		/// <term><c>WM_APP</c> through 0xBFFF</term>
		/// <term>Messages available for use by applications.</term>
		/// </item>
		/// <item>
		/// <term>0xC000 through 0xFFFF</term>
		/// <term>String messages for use by applications.</term>
		/// </item>
		/// <item>
		/// <term>Greater than 0xFFFF</term>
		/// <term>Reserved by the system.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Message numbers in the first range (0 through <c>WM_USER</c> –1) are defined by the system. Values in this range that are not
		/// explicitly defined are reserved by the system.
		/// </para>
		/// <para>
		/// Message numbers in the second range ( <c>WM_USER</c> through 0x7FFF) can be defined and used by an application to send messages
		/// within a private window class. These values cannot be used to define messages that are meaningful throughout an application
		/// because some predefined window classes already define values in this range. For example, predefined control classes such as
		/// <c>BUTTON</c>, <c>EDIT</c>, <c>LISTBOX</c>, and <c>COMBOBOX</c> may use these values. Messages in this range should not be sent
		/// to other applications unless the applications have been designed to exchange messages and to attach the same meaning to the
		/// message numbers.
		/// </para>
		/// <para>
		/// Message numbers in the third range (0x8000 through 0xBFFF) are available for applications to use as private messages. Messages in
		/// this range do not conflict with system messages.
		/// </para>
		/// <para>
		/// Message numbers in the fourth range (0xC000 through 0xFFFF) are defined at run time when an application calls the
		/// <c>RegisterWindowMessage</c> function to retrieve a message number for a string. All applications that register the same string
		/// can use the associated message number for exchanging messages. The actual message number, however, is not a constant and cannot
		/// be assumed to be the same between different sessions.
		/// </para>
		/// <para>Message numbers in the fifth range (greater than 0xFFFF) are reserved by the system.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-app
		WM_APP = 0x8000,

		/// <summary>
		/// <para>
		/// Used to define private messages for use by private window classes, usually of the form <c>WM_USER</c>+x, where x is an integer value.
		/// </para>
		/// <para>
		/// <code>#define WM_USER 0x0400</code>
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The following are the ranges of message numbers.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Range</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0 through <c>WM_USER</c> –1</term>
		/// <term>Messages reserved for use by the system.</term>
		/// </item>
		/// <item>
		/// <term><c>WM_USER</c> through 0x7FFF</term>
		/// <term>Integer messages for use by private window classes.</term>
		/// </item>
		/// <item>
		/// <term><c>WM_APP</c> (0x8000) through 0xBFFF</term>
		/// <term>Messages available for use by applications.</term>
		/// </item>
		/// <item>
		/// <term>0xC000 through 0xFFFF</term>
		/// <term>String messages for use by applications.</term>
		/// </item>
		/// <item>
		/// <term>Greater than 0xFFFF</term>
		/// <term>Reserved by the system.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Message numbers in the first range (0 through <c>WM_USER</c> –1) are defined by the system. Values in this range that are not
		/// explicitly defined are reserved by the system.
		/// </para>
		/// <para>
		/// Message numbers in the second range ( <c>WM_USER</c> through 0x7FFF) can be defined and used by an application to send messages
		/// within a private window class. These values cannot be used to define messages that are meaningful throughout an application
		/// because some predefined window classes already define values in this range. For example, predefined control classes such as
		/// <c>BUTTON</c>, <c>EDIT</c>, <c>LISTBOX</c>, and <c>COMBOBOX</c> may use these values. Messages in this range should not be sent
		/// to other applications unless the applications have been designed to exchange messages and to attach the same meaning to the
		/// message numbers.
		/// </para>
		/// <para>
		/// Message numbers in the third range (0x8000 through 0xBFFF) are available for applications to use as private messages. Messages in
		/// this range do not conflict with system messages.
		/// </para>
		/// <para>
		/// Message numbers in the fourth range (0xC000 through 0xFFFF) are defined at run time when an application calls the
		/// <c>RegisterWindowMessage</c> function to retrieve a message number for a string. All applications that register the same string
		/// can use the associated message number for exchanging messages. The actual message number, however, is not a constant and cannot
		/// be assumed to be the same between different sessions.
		/// </para>
		/// <para>Message numbers in the fifth range (greater than 0xFFFF) are reserved by the system.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winmsg/wm-user
		WM_USER = 0x0400,

		/// <summary>
		/// An application sends the WM_CPL_LAUNCH message to Windows Control Panel to request that a Control Panel application be started.
		/// </summary>
		WM_CPL_LAUNCH = WM_USER + 0x1000,

		/// <summary>
		/// The WM_CPL_LAUNCHED message is sent when a Control Panel application, started by the WM_CPL_LAUNCH message, has closed. The
		/// WM_CPL_LAUNCHED message is sent to the window identified by the wParam parameter of the WM_CPL_LAUNCH message that started the application.
		/// </summary>
		WM_CPL_LAUNCHED = WM_USER + 0x1001,

		/// <summary>
		/// Reflects messages back to child controls. Sometimes you want to write a self-contained control based on standard Windows control,
		/// typically by using subclassing or superclassing. Unfortunately, most standard controls send interesting notifications to their
		/// parents, not to themselves, so your window proc won't normally receive them. A parent window could help by reflecting (sending)
		/// those messages back to the child window so that your window proc could process them. By convention, a message WM_X is reflected
		/// back as (OCM__BASE + WM_X). This is mainly to avoid conflicts with real notifications coming from the child windows of the
		/// control (e.g. a list view control has a header control as its child window, and receives WM_NOTIFY from the header. It would be
		/// inconvenient if you had to figure out every time whether WM_NOTIFY came from the header or reflected from your parent).
		/// </summary>
		WM_REFLECT = WM_USER + 0x1C00,

		/// <summary>WM_SYSTIMER is a well-known yet still undocumented message. Windows uses WM_SYSTIMER for internal actions like scrolling.</summary>
		[MsgParams(typeof(uint), typeof(IntPtr))]
		WM_SYSTIMER = 0x118,

		/// <summary>
		/// <para>
		/// Sent to a window when there is a change in the settings of a monitor that has a digitizer attached to it. This message contains
		/// information regarding the scaling of the display mode.
		/// </para>
		/// <para>
		/// ![Important] Desktop apps should be DPI aware. If your app is not DPI aware, screen coordinates contained in pointer messages and
		/// related structures might appear inaccurate due to DPI virtualization. DPI virtualization provides automatic scaling support to
		/// applications that are not DPI aware and is active by default (users can turn it off). For more information, see Writing High-DPI
		/// Win32 Applications.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Contains a value from <c>Pointer Device Change Constants</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>Additional message-specific information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the application processes this message, it should return zero.</para>
		/// <para>If the application does not process this message, it should call <c>DefWindowProc</c>.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerdevicechange
		[MsgParams(typeof(PDC), typeof(IntPtr))]
		WM_POINTERDEVICECHANGE = 0x238,

		/// <summary>
		/// <para>
		/// Sent to a window when a pointer device is detected within range of an input digitizer. This message contains information
		/// regarding the device and its proximity.
		/// </para>
		/// <para>
		/// <para>
		/// ![Important] Desktop apps should be DPI aware. If your app is not DPI aware, screen coordinates contained in pointer messages and
		/// related structures might appear inaccurate due to DPI virtualization. DPI virtualization provides automatic scaling support to
		/// applications that are not DPI aware and is active by default (users can turn it off). For more information, see Writing High-DPI
		/// Win32 Applications.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Additional message-specific information.</para>
		/// <para><em>lParam</em></para>
		/// <para>Additional message-specific information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the application processes this message, it should return zero.</para>
		/// <para>If the application does not process this message, it should call <c>DefWindowProc</c>.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerdeviceinrange
		[MsgParams(typeof(IntPtr), typeof(IntPtr))]
		WM_POINTERDEVICEINRANGE = 0x239,

		/// <summary>
		/// <para>
		/// Sent to a window when a pointer device has departed the range of an input digitizer. This message contains information regarding
		/// the device and its proximity.
		/// </para>
		/// <para>
		/// <para>
		/// ![Important] Desktop apps should be DPI aware. If your app is not DPI aware, screen coordinates contained in pointer messages and
		/// related structures might appear inaccurate due to DPI virtualization. DPI virtualization provides automatic scaling support to
		/// applications that are not DPI aware and is active by default (users can turn it off). For more information, see Writing High-DPI
		/// Win32 Applications.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Additional message-specific information.</para>
		/// <para><em>lParam</em></para>
		/// <para>Additional message-specific information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the application processes this message, it should return zero.</para>
		/// <para>If the application does not process this message, it should call <c>DefWindowProc</c>.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerdeviceoutofrange
		[MsgParams(typeof(IntPtr), typeof(IntPtr))]
		WM_POINTERDEVICEOUTOFRANGE = 0x23A,

		/// <summary>
		/// <para>Notifies the window when one or more touch points, such as a finger or pen, touches a touch-sensitive digitizer surface.</para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// The low-order word contains the number of touch points associated with this message. The high-order word is reserved for future use.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Contains a touch input handle that can be used in a call to <c>GetTouchInputInfo</c> to retrieve detailed information about the
		/// touch points associated with this message.
		/// </para>
		/// <para>
		/// This handle is valid only within the current process and should not be passed cross-process except as the <c>LPARAM</c> in a
		/// <c>SendMessage</c> or <c>PostMessage</c> call.
		/// </para>
		/// <para>
		/// When the application no longer requires this handle, the application must call <c>CloseTouchInputHandle</c> to free the process
		/// memory associated with this handle. Failing to do so can result in an application memory leak.
		/// </para>
		/// <para>
		/// Note that the touch input handle in this parameter is no longer valid after the message has been passed to DefWindowProc.
		/// DefWindowProc will close and invalidate this handle.
		/// </para>
		/// <para>
		/// Note also that the touch input handle in this parameter is no longer valid after the message has been forwarded using
		/// <c>PostMessage</c>, <c>SendMessage</c>, or one of their variants. These functions will close and invalidate this handle.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// <para>
		/// If the application does not process the message, it must call DefWindowProc. Not doing so causes the application to leak memory
		/// because the touch input handle is not closed and associated process memory is not freed.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <c>WM_TOUCH</c> messages do not respect <c>HTTRANSPARENT</c> regions of windows. If a window returns <c>HTTRANSPARENT</c> in
		/// response to a <c>WM_NCHITTEST</c> message, mouse messages go to the parent, and <c>WM_TOUCH</c> messages go directly to the window.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/wintouch/wm-touchdown
		[MsgParams(typeof(uint), typeof(HTOUCHINPUT))]
		WM_TOUCH = 0x0240,

		/// <summary>
		/// <para>
		/// Posted to provide an update on a pointer that made contact over the non-client area of a window or when a hovering uncaptured
		/// contact moves over the non-client area of a window. While the pointer is hovering, the message targets whichever window the
		/// pointer happens to be over. While the pointer is in contact with the surface, the pointer is implicitly captured to the window
		/// over which the pointer made contact and that window continues to receive input for the pointer until it breaks contact.
		/// </para>
		/// <para>
		/// If a window has captured this pointer, this message is not posted. Instead, a <c>WM_POINTERUPDATE</c> is posted to the window
		/// that has captured this pointer.
		/// </para>
		/// <para>
		/// <para>
		/// ![Important] Desktop apps should be DPI aware. If your app is not DPI aware, screen coordinates contained in pointer messages and
		/// related structures might appear inaccurate due to DPI virtualization. DPI virtualization provides automatic scaling support to
		/// applications that are not DPI aware and is active by default (users can turn it off). For more information, see Writing High-DPI
		/// Win32 Applications.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Contains the pointer identifier and additional information. Use the following macros to retrieve this information.</para>
		/// <para><c>GET_POINTERID_WPARAM</c>(wParam): pointer identifier</para>
		/// <para><c>HIWORD</c>(wParam): hit-test value returned from processing the <c>WM_NCHITTEST</c> message.</para>
		/// <para><em>lParam</em></para>
		/// <para>Contains the point location of the pointer.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Because the pointer may make contact with the device over a non-trivial area, this point location may be a simplification of a
		/// more complex pointer area. Whenever possible, an application should use the complete pointer area information instead of the
		/// point location.
		/// </para>
		/// </para>
		/// <para>Use the following macros to retrieve the physical screen coordinates of the point.</para>
		/// <list type="bullet">
		/// <item>
		/// <description><see cref="Macros.GET_X_LPARAM"/>(lParam): the x (horizontal point) coordinate.</description>
		/// </item>
		/// <item>
		/// <description><see cref="Macros.GET_Y_LPARAM"/>(lParam): the y (vertical point) coordinate.</description>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// <para>If the application does not process this message, it should call <c>DefWindowProc</c>.</para>
		/// </summary>
		/// <remarks>
		/// If the application does not process this message, <c>DefWindowProc</c> may perform one or more system actions depending on the
		/// hit-test result included in the message. Typically, applications should not need to handle this message.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-ncpointerupdate
		[MsgParams(typeof(IntPtr), typeof(IntPtr))]
		WM_NCPOINTERUPDATE = 0x0241,

		/// <summary>
		/// <para>
		/// Posted when a pointer makes contact over the non-client area of a window. The message targets the window over which the pointer
		/// makes contact. The pointer is implicitly captured to the window so that the window continues to receive input for the pointer
		/// until it breaks contact.
		/// </para>
		/// <para>
		/// If a window has captured this pointer, this message is not posted. Instead, a <c>WM_POINTERDOWN</c> is posted to the window that
		/// has captured this pointer.
		/// </para>
		/// <para>
		/// <para>
		/// ![Important] Desktop apps should be DPI aware. If your app is not DPI aware, screen coordinates contained in pointer messages and
		/// related structures might appear inaccurate due to DPI virtualization. DPI virtualization provides automatic scaling support to
		/// applications that are not DPI aware and is active by default (users can turn it off). For more information, see Writing High-DPI
		/// Win32 Applications.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Contains the pointer identifier and additional information. Use the following macros to retrieve this information.</para>
		/// <para><c>GET_POINTERID_WPARAM</c>(wParam): pointer identifier.</para>
		/// <para><c>HIWORD</c>(wParam): hit-test value returned from processing the <c>WM_NCHITTEST</c> message.</para>
		/// <para><em>lParam</em></para>
		/// <para>Contains the point location of the pointer.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Because the pointer may make contact with the device over a non-trivial area, this point location may be a simplification of a
		/// more complex pointer area. Whenever possible, an application should use the complete pointer area information instead of the
		/// point location.
		/// </para>
		/// </para>
		/// <para>Use the following macros to retrieve the physical screen coordinates of the point.</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>GET_X_LPARAM</c>(lParam): the x (horizontal point) coordinate.</description>
		/// </item>
		/// <item>
		/// <description><c>GET_Y_LPARAM</c>(lParam): the y (vertical point) coordinate.</description>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// <para>If the application does not process this message, it should call <c>DefWindowProc</c>.</para>
		/// </summary>
		/// <remarks>
		/// If the application does not process this message, <c>DefWindowProc</c> may perform one or more system actions depending on the
		/// hit-test result included in the message. Typically, applications should not need to handle this message.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-ncpointerdown
		[MsgParams(typeof(IntPtr), typeof(IntPtr))]
		WM_NCPOINTERDOWN = 0x0242,

		/// <summary>
		/// <para>
		/// Posted when a pointer that made contact over the non-client area of a window breaks contact. The message targets the window over
		/// which the pointer makes contact and the pointer is, at that point, implicitly captured to the window so that the window continues
		/// to receive input for the pointer until it breaks contact, including the <c>WM_NCPOINTERUP</c> notification.
		/// </para>
		/// <para>
		/// If a window has captured this pointer, this message is not posted. Instead, a <c>WM_POINTERUP</c> is posted to the window that
		/// has captured this pointer.
		/// </para>
		/// <para>
		/// <para>
		/// ![Important] Desktop apps should be DPI aware. If your app is not DPI aware, screen coordinates contained in pointer messages and
		/// related structures might appear inaccurate due to DPI virtualization. DPI virtualization provides automatic scaling support to
		/// applications that are not DPI aware and is active by default (users can turn it off). For more information, see Writing High-DPI
		/// Win32 Applications.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Contains the pointer identifier and additional information. Use the following macros to retrieve this information.</para>
		/// <para><c>GET_POINTERID_WPARAM</c>(wParam): pointer identifier</para>
		/// <para><c>HIWORD</c>(wParam): hit-test value returned from processing the <c>WM_NCHITTEST</c> message.</para>
		/// <para><em>lParam</em></para>
		/// <para>Contains the point location of the pointer.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Because the pointer may make contact with the device over a non-trivial area, this point location may be a simplification of a
		/// more complex pointer area. Whenever possible, an application should use the complete pointer area information instead of the
		/// point location.
		/// </para>
		/// </para>
		/// <para>Use the following macros to retrieve the physical screen coordinates of the point.</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>GET_X_LPARAM</c>(lParam): the x (horizontal point) coordinate.</description>
		/// </item>
		/// <item>
		/// <description><c>GET_Y_LPARAM</c>(lParam): the y (vertical point) coordinate.</description>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// <para>If the application does not process this message, it should call <c>DefWindowProc</c>.</para>
		/// </summary>
		/// <remarks>
		/// If the application does not process this message, <c>DefWindowProc</c> may perform one or more system actions depending on the
		/// hit-test result included in the message. Typically, applications should not need to handle this message.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-ncpointerup
		[MsgParams(typeof(IntPtr), typeof(IntPtr))]
		WM_NCPOINTERUP = 0x0243,

		/// <summary>
		/// <para>
		/// Posted to provide an update on a pointer that made contact over the client area of a window or on a hovering uncaptured pointer
		/// over the client area of a window. While the pointer is hovering, the message targets whichever window the pointer happens to be
		/// over. While the pointer is in contact with the surface, the pointer is implicitly captured to the window over which the pointer
		/// made contact and that window continues to receive input for the pointer until it breaks contact.
		/// </para>
		/// <para>
		/// <para>
		/// ![Important] Desktop apps should be DPI aware. If your app is not DPI aware, screen coordinates contained in pointer messages and
		/// related structures might appear inaccurate due to DPI virtualization. DPI virtualization provides automatic scaling support to
		/// applications that are not DPI aware and is active by default (users can turn it off). For more information, see Writing High-DPI
		/// Win32 Applications.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Contains information about the pointer. Use the following macros to retrieve information from the wParam parameter.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para><c>GET_POINTERID_WPARAM</c>(wParam): the pointer identifier.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_NEW_WPARAM</c>(wParam): a flag that indicates whether this message represents the first input generated by a new pointer.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_INRANGE_WPARAM</c>(wParam): a flag that indicates whether this message was generated by a pointer during its
		/// lifetime. This flag is not set on messages that indicate that the pointer has left detection range
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_INCONTACT_WPARAM</c>(wParam): a flag that indicates whether this message was generated by a pointer that is in
		/// contact with the window surface. This flag is not set on messages that indicate a hovering pointer.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para><c>IS_POINTER_PRIMARY_WPARAM</c>(wParam): indicates that this pointer has been designated as primary.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para><c>IS_POINTER_FIRSTBUTTON_WPARAM</c>(wParam): a flag that indicates whether there is a primary action.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para><c>IS_POINTER_SECONDBUTTON_WPARAM</c>(wParam): a flag that indicates whether there is a secondary action.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_THIRDBUTTON_WPARAM</c>(wParam): a flag that indicates whether there are one or more tertiary actions based on the
		/// pointer type; applications that wish to respond to tertiary actions must retrieve information specific to the pointer type to
		/// determine which tertiary buttons are pressed. For example, an application can determine the buttons states of a pen by calling
		/// <c>GetPointerPenInfo</c> and examining the flags that specify button states.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_FOURTHBUTTON_WPARAM</c>(wParam): a flag that indicates whether the specified pointer took fourth action.
		/// Applications that wish to respond to fourth actions must retrieve information specific to the pointer type to determine if the
		/// first extended mouse (XButton1) button is pressed.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_FIFTHBUTTON_WPARAM</c>(wParam): a <c>flag</c> that indicates whether the specified pointer took fifth action.
		/// Applications that wish to respond to fifth actions must retrieve information specific to the pointer type to determine if the
		/// second extended mouse (XButton2) button is pressed.
		/// </para>
		/// <para>See <c>Pointer Flags</c> for more details.</para>
		/// </description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Contains the point location of the pointer.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Because the pointer may make contact with the device over a non-trivial area, this point location may be a simplification of a
		/// more complex pointer area. Whenever possible, an application should use the complete pointer area information instead of the
		/// point location.
		/// </para>
		/// </para>
		/// <para>Use the following macros to retrieve the physical screen coordinates of the point.</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>GET_X_LPARAM</c>(lParam): the x (horizontal point) coordinate.</description>
		/// </item>
		/// <item>
		/// <description><c>GET_Y_LPARAM</c>(lParam): the y (vertical point) coordinate.</description>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// <para>If the application does not process this message, it should call <c>DefWindowProc</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>Each pointer has a unique pointer identifier during its lifetime. The lifetime of a pointer begins when it is first detected.</para>
		/// <para>
		/// A <c>WM_POINTERENTER</c> message is generated if a hovering pointer is detected. A <c>WM_POINTERDOWN</c> message followed by a
		/// <c>WM_POINTERENTER</c> message is generated if a non-hovering pointer is detected.
		/// </para>
		/// <para>During its lifetime, a pointer may generate a series of <c>WM_POINTERUPDATE</c> messages while it is hovering or in contact.</para>
		/// <para>The lifetime of a pointer ends when it is no longer detected. This generates a <c>WM_POINTERLEAVE</c> message.</para>
		/// <para>When a pointer is aborted, <c>POINTER_FLAG_CANCELED</c> is set.</para>
		/// <para>A <c>WM_POINTERLEAVE</c> message may also be generated when a non-captured pointer moves outside the bounds of a window.</para>
		/// <para>To obtain the horizontal and vertical position of a pointer, use the following:</para>
		/// <para>The <c>MAKEPOINTS</c> macro can also be used to convert the lParam parameter to a <c>POINTS</c> structure.</para>
		/// <para>
		/// The <c>GetKeyState</c> function can be used to determine the keyboard modifier key states associated with this message. For
		/// example, to detect that the ALT key was pressed, check whether <c>GetKeyState</c> (VK_MENU) &lt; 0.
		/// </para>
		/// <para>
		/// If the application does not process this message, <c>DefWindowProc</c> may generate one or more <c>WM_GESTURE</c> messages if the
		/// sequence of input from this and, possibly, other pointers is recognized as a gesture. If a gesture is not recognized,
		/// <c>DefWindowProc</c> may generate mouse input.
		/// </para>
		/// <para>
		/// If an application selectively consumes some pointer input and passes the rest to <c>DefWindowProc</c>, the resulting behavior is undefined.
		/// </para>
		/// <para>Use the <c>GetPointerInfo</c> function to retrieve further information related to this message.</para>
		/// <para>
		/// If the application does not process these messages as fast as they are generated, some moves may be coalesced. The history of
		/// inputs that were coalesced into this message can be retrieved using the <c>GetPointerInfoHistory</c> function.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerupdate
		[MsgParams(typeof(IntPtr), typeof(IntPtr))]
		WM_POINTERUPDATE = 0x0245,

		/// <summary>
		/// <para>
		/// Posted when a pointer makes contact over the client area of a window. This input message targets the window over which the
		/// pointer makes contact, and the pointer is implicitly captured to the window so that the window continues to receive input for the
		/// pointer until it breaks contact.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <para>
		/// ![Important] Desktop apps should be DPI aware. If your app is not DPI aware, screen coordinates contained in pointer messages and
		/// related structures might appear inaccurate due to DPI virtualization. DPI virtualization provides automatic scaling support to
		/// applications that are not DPI aware and is active by default (users can turn it off). For more information, see Writing High-DPI
		/// Win32 Applications.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Contains information about the pointer. Use the following macros to retrieve information from the wParam parameter.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para><c>GET_POINTERID_WPARAM</c>(wParam): the pointer identifier.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_NEW_WPARAM</c>(wParam): a flag that indicates whether this message represents the first input generated by a new pointer.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_INRANGE_WPARAM</c>(wParam): a flag that indicates whether this message was generated by a pointer during its
		/// lifetime. This flag is not set on messages that indicate that the pointer has left detection range
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_INCONTACT_WPARAM</c>(wParam): a flag that indicates whether this message was generated by a pointer that is in
		/// contact with the window surface. This flag is not set on messages that indicate a hovering pointer.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para><c>IS_POINTER_PRIMARY_WPARAM</c>(wParam): indicates that this pointer has been designated as primary.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para><c>IS_POINTER_FIRSTBUTTON_WPARAM</c>(wParam): a flag that indicates whether there is a primary action.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para><c>IS_POINTER_SECONDBUTTON_WPARAM</c>(wParam): a flag that indicates whether there is a secondary action.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_THIRDBUTTON_WPARAM</c>(wParam): a flag that indicates whether there are one or more tertiary actions based on the
		/// pointer type; applications that wish to respond to tertiary actions must retrieve information specific to the pointer type to
		/// determine which tertiary buttons are pressed. For example, an application can determine the buttons states of a pen by calling
		/// <c>GetPointerPenInfo</c> and examining the flags that specify button states.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_FOURTHBUTTON_WPARAM</c>(wParam): a flag that indicates whether the specified pointer took fourth action.
		/// Applications that wish to respond to fourth actions must retrieve information specific to the pointer type to determine if the
		/// first extended mouse (XButton1) button is pressed.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_FIFTHBUTTON_WPARAM</c>(wParam): a <c>flag</c> that indicates whether the specified pointer took fifth action.
		/// Applications that wish to respond to fifth actions must retrieve information specific to the pointer type to determine if the
		/// second extended mouse (XButton2) button is pressed.
		/// </para>
		/// <para>See <c>Pointer Flags</c> for more details.</para>
		/// </description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Contains the point location of the pointer.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Because the pointer may make contact with the device over a non-trivial area, this point location may be a simplification of a
		/// more complex pointer area. Whenever possible, an application should use the complete pointer area information instead of the
		/// point location.
		/// </para>
		/// </para>
		/// <para>Use the following macros to retrieve the physical screen coordinates of the point.</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>GET_X_LPARAM</c>(lParam): the x (horizontal point) coordinate.</description>
		/// </item>
		/// <item>
		/// <description><c>GET_Y_LPARAM</c>(lParam): the y (vertical point) coordinate.</description>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// <para>If the application does not process this message, it should call <c>DefWindowProc</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// <para>
		/// ![Important] When a window loses capture of a pointer and it receives the <c>WM_POINTERCAPTURECHANGED</c> notification, it
		/// typically will not receive any further notifications. For this reason, it is important that you not make any assumptions based on
		/// evenly paired <c>WM_POINTERDOWN</c>/ <c>WM_POINTERUP</c> or <c>WM_POINTERENTER</c>/ <c>WM_POINTERLEAVE</c> notifications.
		/// </para>
		/// </para>
		/// <para>Each pointer has a unique pointer identifier during its lifetime. The lifetime of a pointer begins when it is first detected.</para>
		/// <para>
		/// A <c>WM_POINTERENTER</c> message is generated if a hovering pointer is detected. A <c>WM_POINTERDOWN</c> message followed by a
		/// <c>WM_POINTERENTER</c> message is generated if a non-hovering pointer is detected.
		/// </para>
		/// <para>During its lifetime, a pointer may generate a series of <c>WM_POINTERUPDATE</c> messages while it is hovering or in contact.</para>
		/// <para>The lifetime of a pointer ends when it is no longer detected. This generates a <c>WM_POINTERLEAVE</c> message.</para>
		/// <para>When a pointer is aborted, <c>POINTER_FLAG_CANCELED</c> is set.</para>
		/// <para>A <c>WM_POINTERLEAVE</c> message may also be generated when a non-captured pointer moves outside the bounds of a window.</para>
		/// <para>To obtain the horizontal and vertical position of a pointer, use the following:</para>
		/// <para>To convert the lParam parameter to a <c>POINTS</c>) structure, use the <c>MAKEPOINTS</c> macro.</para>
		/// <para>To retrieve further information associated with the message, use the <c>GetPointerInfo</c> function.</para>
		/// <para>
		/// To determine the keyboard modifier key states associated with this message, use the <c>GetKeyState</c> function. For example, to
		/// detect that the ALT key was pressed, check whether GetKeyState(VK_MENU) &lt; 0.
		/// </para>
		/// <para>
		/// Note that if the application does not process this message, <c>DefWindowProc</c> may generate one or more <c>WM_GESTURE</c>
		/// messages if the sequence of input from this and, possibly, other pointers is recognized as a gesture. If a gesture is not
		/// recognized, <c>DefWindowProc</c> may generate mouse input.
		/// </para>
		/// <para>
		/// If an application selectively consumes some pointer input and passes the rest to <c>DefWindowProc</c>, the resulting behavior is undefined.
		/// </para>
		/// <para>
		/// When a window loses capture of a pointer and receives the <c>WM_POINTERCAPTURECHANGED</c> notification, it will typically not
		/// receive any further notifications. Therefore, it is important that a window does not make any assumptions of its pointer status,
		/// regardless of whether it receives evenly paired DOWN / UP or ENTER / LEAVE notifications.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerdown
		[MsgParams(typeof(IntPtr), typeof(IntPtr))]
		WM_POINTERDOWN = 0x0246,

		/// <summary>
		/// <para>
		/// Posted when a pointer that made contact over the client area of a window breaks contact. This input message targets the window
		/// over which the pointer makes contact and the pointer is, at that point, implicitly captured to the window so that the window
		/// continues to receive input messages including the <c>WM_POINTERUP</c> notification for the pointer until it breaks contact.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <para>
		/// ![Important] Desktop apps should be DPI aware. If your app is not DPI aware, screen coordinates contained in pointer messages and
		/// related structures might appear inaccurate due to DPI virtualization. DPI virtualization provides automatic scaling support to
		/// applications that are not DPI aware and is active by default (users can turn it off). For more information, see Writing High-DPI
		/// Win32 Applications.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Contains information about the pointer. Use the following macros to retrieve information from the wParam parameter.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para><c>GET_POINTERID_WPARAM</c>(wParam): the pointer identifier.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_NEW_WPARAM</c>(wParam): a flag that indicates whether this message represents the first input generated by a new pointer.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_INRANGE_WPARAM</c>(wParam): a flag that indicates whether this message was generated by a pointer during its
		/// lifetime. This flag is not set on messages that indicate that the pointer has left detection range
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_INCONTACT_WPARAM</c>(wParam): a flag that indicates whether this message was generated by a pointer that is in
		/// contact with the window surface. This flag is not set on messages that indicate a hovering pointer.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para><c>IS_POINTER_PRIMARY_WPARAM</c>(wParam): indicates that this pointer has been designated as primary.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para><c>IS_POINTER_FIRSTBUTTON_WPARAM</c>(wParam): a flag that indicates whether there is a primary action.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para><c>IS_POINTER_SECONDBUTTON_WPARAM</c>(wParam): a flag that indicates whether there is a secondary action.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_THIRDBUTTON_WPARAM</c>(wParam): a flag that indicates whether there are one or more tertiary actions based on the
		/// pointer type; applications that wish to respond to tertiary actions must retrieve information specific to the pointer type to
		/// determine which tertiary buttons are pressed. For example, an application can determine the buttons states of a pen by calling
		/// <c>GetPointerPenInfo</c> and examining the flags that specify button states.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_FOURTHBUTTON_WPARAM</c>(wParam): a flag that indicates whether the specified pointer took fourth action.
		/// Applications that wish to respond to fourth actions must retrieve information specific to the pointer type to determine if the
		/// first extended mouse (XButton1) button is pressed.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// <c>IS_POINTER_FIFTHBUTTON_WPARAM</c>(wParam): a <c>flag</c> that indicates whether the specified pointer took fifth action.
		/// Applications that wish to respond to fifth actions must retrieve information specific to the pointer type to determine if the
		/// second extended mouse (XButton2) button is pressed.
		/// </para>
		/// <para>See <c>Pointer Flags</c> for more details.</para>
		/// </description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Contains the point location of the pointer.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Because the pointer may make contact with the device over a non-trivial area, this point location may be a simplification of a
		/// more complex pointer area. Whenever possible, an application should use the complete pointer area information instead of the
		/// point location.
		/// </para>
		/// </para>
		/// <para>Use the following macros to retrieve the physical screen coordinates of the point.</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>GET_X_LPARAM</c>(lParam): the x (horizontal point) coordinate.</description>
		/// </item>
		/// <item>
		/// <description><c>GET_Y_LPARAM</c>(lParam): the y (vertical point) coordinate.</description>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// <para>If the application does not process this message, it should call <c>DefWindowProc</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// <para>
		/// ![Important] When a window loses capture of a pointer and it receives the <c>WM_POINTERCAPTURECHANGED</c> notification, it
		/// typically will not receive any further notifications. For this reason, it is important that you not make any assumptions based on
		/// evenly paired <c>WM_POINTERDOWN</c>/ <c>WM_POINTERUP</c> or <c>WM_POINTERENTER</c>/ <c>WM_POINTERLEAVE</c> notifications.
		/// </para>
		/// </para>
		/// <para>Each pointer has a unique pointer identifier during its lifetime. The lifetime of a pointer begins when it is first detected.</para>
		/// <para>
		/// A <c>WM_POINTERENTER</c> message is generated if a hovering pointer is detected. A <c>WM_POINTERDOWN</c> message followed by a
		/// <c>WM_POINTERENTER</c> message is generated if a non-hovering pointer is detected.
		/// </para>
		/// <para>During its lifetime, a pointer may generate a series of <c>WM_POINTERUPDATE</c> messages while it is hovering or in contact.</para>
		/// <para>The lifetime of a pointer ends when it is no longer detected. This generates a <c>WM_POINTERLEAVE</c> message.</para>
		/// <para>When a pointer is aborted, <c>POINTER_FLAG_CANCELED</c> is set.</para>
		/// <para>A <c>WM_POINTERLEAVE</c> message may also be generated when a non-captured pointer moves outside the bounds of a window.</para>
		/// <para>To obtain the horizontal and vertical position of a pointer, use the following:</para>
		/// <para>Use the following code to obtain the horizontal and vertical position:</para>
		/// <para>The <c>MAKEPOINTS</c> macro can also be used to convert the lParam parameter to a <c>POINTS</c> structure.</para>
		/// <para>
		/// The <c>GetKeyState</c> function can be used to determine the keyboard modifier key states associated with this message. For
		/// example, to detect that the ALT key was pressed, check whether <c>GetKeyState</c>(VK_MENU) &lt; 0.
		/// </para>
		/// <para>
		/// If the application does not process this message, <c>DefWindowProc</c> may generate one or more <c>WM_GESTURE</c> messages if the
		/// sequence of input from this and, possibly, other pointers is recognized as a gesture. If a gesture is not recognized,
		/// <c>DefWindowProc</c> may generate mouse input.
		/// </para>
		/// <para>
		/// If an application selectively consumes some pointer input and passes the rest to <c>DefWindowProc</c>, the resulting behavior is undefined.
		/// </para>
		/// <para>Use the <c>GetPointerInfo</c> function to retrieve further information related to this message.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerup
		[MsgParams(typeof(IntPtr), typeof(IntPtr))]
		WM_POINTERUP = 0x0247,

		/// <summary>
		/// <para>
		/// Sent to a window when a new pointer enters detection range over the window (hover) or when an existing pointer moves within the
		/// boundaries of the window.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <para>
		/// ![Important] Desktop apps should be DPI aware. If your app is not DPI aware, screen coordinates contained in pointer messages and
		/// related structures might appear inaccurate due to DPI virtualization. DPI virtualization provides automatic scaling support to
		/// applications that are not DPI aware and is active by default (users can turn it off). For more information, see Writing High-DPI
		/// Win32 Applications.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Contains the pointer identifier and additonal information. Use the following macros to retrieve specific information in the
		/// wParam parameter.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>GET_POINTERID_WPARAM</c>(wParam): the pointer identifier.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>IS_POINTER_NEW_WPARAM</c>(wParam): indicates whether this message is the first message generated by a new pointer entering
		/// detection range (hover).
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>IS_POINTER_INRANGE_WPARAM</c>(wParam): indicates whether this message was generated by a pointer that has not left detection
		/// range. This flag is always set for <c>WM_POINTERENTER</c> messages.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>IS_POINTER_INCONTACT_WPARAM</c>(wParam): a flag that indicates whether this message was generated by a pointer that is in
		/// contact. This flag is not set for a pointer in detection range (hover).
		/// </description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Contains the point location of the pointer.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Because the pointer may make contact with the device over a non-trivial area, this point location may be a simplification of a
		/// more complex pointer area. Whenever possible, an application should use the complete pointer area information instead of the
		/// point location.
		/// </para>
		/// </para>
		/// <para>Use the following macros to retrieve the physical screen coordinates of the point.</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>GET_X_LPARAM</c>(lParam): the x (horizontal point) coordinate.</description>
		/// </item>
		/// <item>
		/// <description><c>GET_Y_LPARAM</c>(lParam): the y (vertical point) coordinate.</description>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// <para>If the application does not process this message, it should call <c>DefWindowProc</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>WM_POINTERENTER</c> notification can be used by a window to provide feedback to the user while the pointer is over its
		/// surface or to otherwise react to the presence of a pointer over its surface.
		/// </para>
		/// <para>
		/// This notification is only sent to the window that is receiving input for the pointer. The following table lists some of the
		/// situations in which this notification is sent.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Action</description>
		/// <description>Flags Set</description>
		/// <description>Notifications Sent To</description>
		/// </listheader>
		/// <item>
		/// <description>A new pointer enters detection range (hover).</description>
		/// <description><c>IS_POINTER_NEW_WPARAM</c><c>IS_POINTER_INRANGE_WPARAM</c></description>
		/// <description>Window over which the pointer enters detection range.</description>
		/// </item>
		/// <item>
		/// <description>A hovering pointer crosses within the window boundaries.</description>
		/// <description><c>IS_POINTER_INRANGE_WPARAM</c></description>
		/// <description>Window within which the pointer has crossed.</description>
		/// </item>
		/// </list>
		/// <para>
		/// <para>
		/// ![Important] When a window loses capture of a pointer and it receives the <c>WM_POINTERCAPTURECHANGED</c> notification, it
		/// typically will not receive any further notifications. For this reason, it is important that you not make any assumptions based on
		/// evenly paired <c>WM_POINTERDOWN</c>/ <c>WM_POINTERUP</c> or <c>WM_POINTERENTER</c>/ <c>WM_POINTERLEAVE</c> notifications.
		/// </para>
		/// </para>
		/// <para>When inputs come from the mouse, as a result of mouse and pointer message integration, <c>WM_POINTERENTER</c> is not sent.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerenter
		[MsgParams(typeof(IntPtr), typeof(IntPtr))]
		WM_POINTERENTER = 0x0249,

		/// <summary>
		/// <para>
		/// Sent to a window when a pointer leaves detection range over the window (hover) or when a pointer moves outside the boundaries of
		/// the window.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <para>
		/// ![Important] Desktop apps should be DPI aware. If your app is not DPI aware, screen coordinates contained in pointer messages and
		/// related structures might appear inaccurate due to DPI virtualization. DPI virtualization provides automatic scaling support to
		/// applications that are not DPI aware and is active by default (users can turn it off). For more information, see Writing High-DPI
		/// Win32 Applications.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Contains the pointer identifier and additional information. Use the following macros to retrieve this information.</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>GET_POINTERID_WPARAM</c>(wParam): the pointer identifier.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>IS_POINTER_INRANGE_WPARAM</c>(wParam): indicates whether this message was generated by a pointer that has not left detection
		/// range. This flag is not set when the pointer leaves the detection range of the window.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>IS_POINTER_INCONTACT_WPARAM</c>(wParam): a flag that indicates whether this message was generated by a pointer that is in
		/// contact. This flag is not set for a pointer in detection range (hover).
		/// </description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Contains the point location of the pointer.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Because the pointer may make contact with the device over a non-trivial area, this point location may be a simplification of a
		/// more complex pointer area. Whenever possible, an application should use the complete pointer area information instead of the
		/// point location.
		/// </para>
		/// </para>
		/// <para>Use the following macros to retrieve the physical screen coordinates of the point.</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>GET_X_LPARAM</c>(lParam): the x (horizontal point) coordinate.</description>
		/// </item>
		/// <item>
		/// <description><c>GET_Y_LPARAM</c>(lParam): the y (vertical point) coordinate.</description>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// <para>If the application does not process this message, it should call <c>DefWindowProc</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>WM_POINTERLEAVE</c> notification can be used by a window to change mode or stop any feedback to the user while the pointer
		/// is over the window surface.
		/// </para>
		/// <para>
		/// This notification is only sent to the window that is receiving input for the pointer. The following table lists some of the
		/// situations in which this notification is sent.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Action</description>
		/// <description>Flags Set</description>
		/// <description>Notifications Sent To</description>
		/// </listheader>
		/// <item>
		/// <description>A hovering pointer crosses window boundaries.</description>
		/// <description><c>IS_POINTER_INRANGE_WPARAM</c></description>
		/// <description>Window outside of whose boundary the pointer moved.</description>
		/// </item>
		/// <item>
		/// <description>A pointer goes out of detection range.</description>
		/// <description>N/A</description>
		/// <description>Window for which the pointer leaves detection range.</description>
		/// </item>
		/// </list>
		/// <para>
		/// <para>
		/// ![Important] When a window loses capture of a pointer and it receives the <c>WM_POINTERCAPTURECHANGED</c> notification, it
		/// typically will not receive any further notifications. For this reason, it is important that you not make any assumptions based on
		/// evenly paired <c>WM_POINTERDOWN</c>/ <c>WM_POINTERUP</c> or <c>WM_POINTERENTER</c>/ <c>WM_POINTERLEAVE</c> notifications.
		/// </para>
		/// </para>
		/// <para>
		/// If contact is maintained with the input digitizer and the pointer moves outside the window, <c>WM_POINTERLEAVE</c> is not
		/// generated. <c>WM_POINTERLEAVE</c> is generated only when a hovering pointer crosses window boundaries or contact is terminated.
		/// </para>
		/// <para><c>WM_POINTERLEAVE</c> is posted to the posted message queue if the input is originated from a mouse device.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerleave
		[MsgParams(typeof(IntPtr), typeof(IntPtr))]
		WM_POINTERLEAVE = 0x024A,

		/// <summary>
		/// <para>
		/// Sent to an inactive window when a primary pointer generates a <c>WM_POINTERDOWN</c> over the window. As long as the message
		/// remains unhandled, it travels up the parent window chain until it is reaches the top-level window. Applications can respond to
		/// this message to specify whether they wish to be activated.
		/// </para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Contains the pointer identifier and additional information. Use the following macros to retrieve this information.</para>
		/// <para><c>GET_POINTERID_WPARAM</c>(wParam): pointer identifier</para>
		/// <para><c>HIWORD</c>(wParam): hit-test value returned from processing the <c>WM_NCHITTEST</c> message.</para>
		/// <para><em>lParam</em></para>
		/// <para>Contains the handle to the top-level window of the window being activated.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return one of the values described in the Remarks section.</para>
		/// <para>If the application does not process this message, it should call <c>DefWindowProc</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// An application can handle this message and return one of the following values to determine how the system processes the
		/// activation and the activating input:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>PA_ACTIVATE</description>
		/// </item>
		/// <item>
		/// <description>PA_NOACTIVATE</description>
		/// </item>
		/// </list>
		/// <para>
		/// It is important to note that, when the user is interacting with the system with multiple simultaneous pointers, the activation
		/// opportunity that the <c>WM_POINTERACTIVATE</c> message represents is available to applications only for the first of those
		/// pointers. Applications should, therefore, be aware that they may still receive input from pointers while they are inactive.
		/// </para>
		/// <para>If the application does not handle this message, <c>DefWindowProc</c> passes the message to the parent window.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointeractivate
		[MsgParams(typeof(IntPtr), typeof(IntPtr), LResultType = typeof(WM_POINTERACTIVATE_RETURN))]
		WM_POINTERACTIVATE = 0x024B,

		/// <summary>
		/// <para>Sent to a window that is losing capture of an input pointer.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Contains information about the input pointer that is being lost. Use <c>GET_POINTERID_WPARAM</c> to get the pointer ID.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Contains a handle to the window that is capturing the input pointer. This value can be NULL if the pointer is no longer being
		/// captured by the window.
		/// </para>
		/// <para>If this message is generated from internal processing, the value can be the handle of the window receiving the message.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If an application processes this message, it should return zero.</para>
		/// <para>If the application does not process this message, it should call <c>DefWindowProc</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A window should use this notification to stop processing subsequent messages and initiate any cleanup required for the pointer
		/// being lost. Processing of gestures associated with the pointer should also be terminated (for example, by calling
		/// <c>StopInteractionContext</c>) and remaining contacts re-associated with the window.
		/// </para>
		/// <para>
		/// Typically, if a window receives the <c>WM_POINTERCAPTURECHANGED</c> notification, no subsequent notifications related to the
		/// input pointer are received. Because of this, do not depend on paired notifications such as <c>WM_POINTERENTER</c> and <c>WM_POINTERLEAVE</c>.
		/// </para>
		/// <para>
		/// <c>WM_POINTERCAPTURECHANGED</c> does not include <c>POINTER_INFO</c> data. Other than the <c>POINTER_FLAG_CAPTURECHANGED</c> flag
		/// being set, the data returned by <c>GetPointerInfo</c> (or any variant) is identical to that returned prior to the notification.
		/// </para>
		/// <para>
		/// If the application does not process this notification, <c>DefWindowProc</c> may generate one or more <c>WM_GESTURE</c> messages
		/// or, if a gesture is not recognized, <c>DefWindowProc</c> may generate mouse input.
		/// </para>
		/// <para>
		/// If an application selectively consumes some pointer input and passes the rest to <c>DefWindowProc</c>, the resulting behavior is undefined.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointercapturechanged
		[MsgParams(typeof(IntPtr), typeof(HWND))]
		WM_POINTERCAPTURECHANGED = 0x024C,

		/// <summary>
		/// <para>Sent to a window on a touch down in order to determine the most probable touch target.</para>
		/// <para>
		/// <para>
		/// ![Important] Desktop apps should be DPI aware. If your app is not DPI aware, screen coordinates contained in pointer messages and
		/// related structures might appear inaccurate due to DPI virtualization. DPI virtualization provides automatic scaling support to
		/// applications that are not DPI aware and is active by default (users can turn it off). For more information, see Writing High-DPI
		/// Win32 Applications.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Unused.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to the <c>TOUCH_HIT_TESTING_INPUT</c> structure that holds the touch contact area data.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If one or more elements are within the touch contact area, an application should return the result of <c>PackTouchHitTestingProximityEvaluation</c>.</para>
		/// <para>
		/// If no elements are within the touch contact area, an application should set the value of <c>score</c> in
		/// <c>TOUCH_HIT_TESTING_PROXIMITY_EVALUATION</c> to <c>TOUCH_HIT_TESTING_PROXIMITY_FARTHEST</c> and call
		/// <c>PackTouchHitTestingProximityEvaluation</c> to get the LRESULT return value.
		/// </para>
		/// <para>If the application does not process this message, it must call <c>DefWindowProc</c>.</para>
		/// </summary>
		/// <remarks>This message is sent to windows that register through the <c>RegisterTouchHitTestingWindow</c> function.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-touchhittesting
		[MsgParams(null, typeof(TOUCH_HIT_TESTING_INPUT))]
		WM_TOUCHHITTESTING = 0x024D,

		/// <summary>
		/// <para>Posted to the window with foreground keyboard focus when a scroll wheel is rotated.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <para>
		/// ![Important] Desktop apps should be DPI aware. If your app is not DPI aware, screen coordinates contained in pointer messages and
		/// related structures might appear inaccurate due to DPI virtualization. DPI virtualization provides automatic scaling support to
		/// applications that are not DPI aware and is active by default (users can turn it off). For more information, see Writing High-DPI
		/// Win32 Applications.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Contains the pointer identifier and wheel delta. Use the following macros to retrieve this information.</para>
		/// <para><c>GET_POINTERID_WPARAM</c>(wParam): pointer identifier.</para>
		/// <para><c>GET_WHEEL_DELTA_WPARAM</c>(wParam): wheel delta as a signed short value.</para>
		/// <para><em>lParam</em></para>
		/// <para>Contains the point location of the pointer.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Because the pointer may make contact with the device over a non-trivial area, this point location may be a simplification of a
		/// more complex pointer area. Whenever possible, an application should use the complete pointer area information instead of the
		/// point location.
		/// </para>
		/// </para>
		/// <para>Use the following macros to retrieve the physical screen coordinates of the point.</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>GET_X_LPARAM</c>(lParam): the x (horizontal point) coordinate.</description>
		/// </item>
		/// <item>
		/// <description><c>GET_Y_LPARAM</c>(lParam): the y (vertical point) coordinate.</description>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>If the application processes this message, it should return zero.</para>
		/// <para>If the application does not process this message, it should call <c>DefWindowProc</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To retrieve the wheel scroll units, use the <c>inputData</c> filed of the <c>POINTER_INFO</c> structure returned by calling
		/// <c>GetPointerInfo</c> function. This field contains a signed value and is expressed in a multiple of <c>WHEEL_DELTA</c>. A
		/// positive value indicates a rotation forward and a negative value indicates a rotation backward.
		/// </para>
		/// <para>
		/// Note that the wheel inputs may be delivered even if the mouse cursor is located outside of application s window. The wheel
		/// messages are delivered in a way very similar to the keyboard inputs. The focus window of the foregournd message queue receives
		/// the wheel messages.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerwheel
		[MsgParams(typeof(IntPtr), typeof(IntPtr))]
		WM_POINTERWHEEL = 0x024E,

		/// <summary>
		/// <para>Posted to the window with foreground keyboard focus when a horizontal scroll wheel is rotated.</para>
		/// <para>A window receives this message through its <c>WindowProc</c> function.</para>
		/// <para>
		/// <para>
		/// ![Important] Desktop apps should be DPI aware. If your app is not DPI aware, screen coordinates contained in pointer messages and
		/// related structures might appear inaccurate due to DPI virtualization. DPI virtualization provides automatic scaling support to
		/// applications that are not DPI aware and is active by default (users can turn it off). For more information, see Writing High-DPI
		/// Win32 Applications.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Contains the pointer identifier and wheel delta. Use the following macros to retrieve this information.</para>
		/// <para><c>GET_POINTERID_WPARAM</c>(wParam): pointer identifier.</para>
		/// <para><c>GET_WHEEL_DELTA_WPARAM</c>(wParam): wheel delta as signed short value.</para>
		/// <para><em>lParam</em></para>
		/// <para>Contains the point location of the pointer.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Because the pointer may make contact with the device over a non-trivial area, this point location may be a simplification of a
		/// more complex pointer area. Whenever possible, an application should use the complete pointer area information instead of the
		/// point location.
		/// </para>
		/// </para>
		/// <para>Use the following macros to retrieve the physical screen coordinates of the point.</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>GET_X_LPARAM</c>(lParam): the x (horizontal point) coordinate.</description>
		/// </item>
		/// <item>
		/// <description><c>GET_Y_LPARAM</c>(lParam): the y (vertical point) coordinate.</description>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>If the application processes this message, it should return zero.</para>
		/// <para>If the application does not process this message, it should call <c>DefWindowProc</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To retrieve the wheel scroll units, use the <c>inputData</c> filed of the <c>POINTER_INFO</c> structure returned by calling
		/// <c>GetPointerInfo</c> function. This field contains a signed value and is expressed in a multiple of <c>WHEEL_DELTA</c>. A
		/// positive value indicates a rotation forward and a negative value indicates a rotation backward.
		/// </para>
		/// <para>
		/// Note that the wheel inputs may be delivered even if the mouse cursor is located outside of application s window. The wheel
		/// messages are delivered in a way very similar to the keyboard inputs. The focus window of the foregournd message queue receives
		/// the wheel messages.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerhwheel
		[MsgParams(typeof(IntPtr), typeof(IntPtr))]
		WM_POINTERHWHEEL = 0x024F,

		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>
		/// Sent to a window, when pointer input is first detected, in order to determine the most probable input target for Direct Manipulation.
		/// </para>
		/// <para>
		/// <para>
		/// ![Important] Desktop apps should be DPI aware. If your app is not DPI aware, screen coordinates contained in pointer messages and
		/// related structures might appear inaccurate due to DPI virtualization. DPI virtualization provides automatic scaling support to
		/// applications that are not DPI aware and is active by default (users can turn it off). For more information, see Writing High-DPI
		/// Win32 Applications.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Unused.</para>
		/// <para><em>lParam</em></para>
		/// <para>Unused.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>NULL</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/dm-pointerhittest
		[MsgParams(null, null, LResultType = null)]
		DM_POINTERHITTEST = 0x0250,

		/// <summary>
		/// <para>
		/// Sent when ongoing pointer input, for an existing pointer ID, transitions from one process to another across content configured
		/// for cross-process chaining ( <c>AddContentWithCrossProcessChaining</c>).
		/// </para>
		/// <para>This message is sent to the process not currently receiving pointer input.</para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Unused.</para>
		/// <para><em>lParam</em></para>
		/// <para>Unused.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>NULL</para>
		/// </summary>
		/// <remarks>
		/// <para>This message is not sent when a <c>WM_POINTERDOWN</c> message is posted for a new pointer ID on a different process.</para>
		/// <para>A <c>WM_POINTERDOWN</c> message is not sent if a <c>WM_POINTERROUTEDTO</c> message is posted first.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerroutedto
		[MsgParams(null, null, LResultType = null)]
		WM_POINTERROUTEDTO = 0x0251,

		/// <summary>
		/// <para>Occurs on the process receiving input when the pointer input is routed to another process.</para>
		/// <para>
		/// Sent when pointer input transitions from one process to another across content configured for cross-process chaining ( <c>AddContentWithCrossProcessChaining</c>).
		/// </para>
		/// <para>This message is sent to the process currently receiving pointer input.</para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Unused.</para>
		/// <para><em>lParam</em></para>
		/// <para>Unused.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>NULL</para>
		/// </summary>
		/// <remarks>This message is not sent with either a <c>WM_POINTERUP</c> message or a <c>WM_POINTERCAPTURECHANGED</c> message.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerroutedaway
		[MsgParams(null, null, LResultType = null)]
		WM_POINTERROUTEDAWAY = 0x0252,

		/// <summary>
		/// <para>
		/// Sent to all processes (configured for cross-process chaining through <c>AddContentWithCrossProcessChaining</c> and not currently
		/// handling pointer input) ever associated with a specific pointer ID, when a <c>WM_POINTERUP</c> message is received on the current process.
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Unused.</para>
		/// <para><em>lParam</em></para>
		/// <para>Unused.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>NULL</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/inputmsg/wm-pointerroutedreleased
		[MsgParams(null, null, LResultType = null)]
		WM_POINTERROUTEDRELEASED = 0x0253,
	}

	/// <summary>wParam value for WM_ACTIVATE.</summary>
	[PInvokeData("winuser.h")]
	public enum WM_ACTIVATE_WPARAM
	{
		/// <summary>Deactivated.</summary>
		WA_INACTIVE = 0,

		/// <summary>
		/// Activated by some method other than a mouse click (for example, by a call to the SetActiveWindow function or by use of the
		/// keyboard interface to select the window).
		/// </summary>
		WA_ACTIVE = 1,

		/// <summary>Activated by a mouse click.</summary>
		WA_CLICKACTIVE = 2,
	}

	/// <summary>The type of icon being set or retrieved via WM_SETICON or WM_GETICON.</summary>
	[PInvokeData("winuser.h")]
	public enum WM_ICON_WPARAM
	{
		/// <summary>The small icon for the window.</summary>
		ICON_SMALL = 0,

		/// <summary>The large icon for the window.</summary>
		ICON_BIG = 1,

		/// <summary>
		/// The small icon provided by the application. If the application does not provide one, the system uses the system-generated icon
		/// for that window.
		/// </summary>
		ICON_SMALL2 = 2,
	}

	/// <summary>Return value for WM_MOUSEACTIVATE.</summary>
	[PInvokeData("winuser.h")]
	public enum WM_MOUSEACTIVATE_RETURN : int
	{
		/// <summary>Activates the window and does not discard the mouse message.</summary>
		MA_ACTIVATE = 1,

		/// <summary>Activates the window and discards the mouse message.</summary>
		MA_ACTIVATEANDEAT = 2,

		/// <summary>Does not activate the window and does not discard the mouse message.</summary>
		MA_NOACTIVATE = 3,

		/// <summary>Does not activate the window and discards the mouse message.</summary>
		MA_NOACTIVATEANDEAT = 4,
	}

	/// <summary>lParam value for WM_SHOWWINDOW.</summary>
	[PInvokeData("winuser.h")]
	public enum WM_SHOWWINDOW_LPARAM : uint
	{
		/// <summary>The window's owner window is being minimized.</summary>
		SW_PARENTCLOSING = 1,

		/// <summary>The window is being covered by another window that has been maximized.</summary>
		SW_OTHERZOOM = 2,

		/// <summary>The window's owner window is being restored.</summary>
		SW_PARENTOPENING = 3,

		/// <summary>The window is being uncovered because a maximize window was restored or minimized.</summary>
		SW_OTHERUNZOOM = 4,
	}

	/// <summary>wParam value for WM_SIZE.</summary>
	[PInvokeData("winuser.h")]
	public enum WM_SIZE_WPARAM
	{
		/// <summary>The window has been resized, but neither the SIZE_MINIMIZED nor SIZE_MAXIMIZED value applies.</summary>
		SIZE_RESTORED = 0,

		/// <summary>The window has been minimized.</summary>
		SIZE_MINIMIZED = 1,

		/// <summary>The window has been maximized.</summary>
		SIZE_MAXIMIZED = 2,

		/// <summary>Message is sent to all pop-up windows when some other window has been restored to its former size.</summary>
		SIZE_MAXSHOW = 3,

		/// <summary>Message is sent to all pop-up windows when some other window is maximized.</summary>
		SIZE_MAXHIDE = 4,
	}

	/// <summary>Used in wParam from WM_SIZING message.</summary>
	[PInvokeData("winuser.h")]
	public enum WMSZ
	{
		/// <summary>Left edge.</summary>
		WMSZ_LEFT = 1,

		/// <summary>Right edge</summary>
		WMSZ_RIGHT = 2,

		/// <summary>Top edge</summary>
		WMSZ_TOP = 3,

		/// <summary>Top-left edge</summary>
		WMSZ_TOPLEFT = 4,

		/// <summary>Top-right edge</summary>
		WMSZ_TOPRIGHT = 5,

		/// <summary>Bottom edge</summary>
		WMSZ_BOTTOM = 6,

		/// <summary>Bottom-left edge</summary>
		WMSZ_BOTTOMLEFT = 7,

		/// <summary>Bottom-right edge</summary>
		WMSZ_BOTTOMRIGHT = 8,
	}

	/// <summary>
	/// wParam for WM_WTSSESSION_CHANGE message. Status code describing the reason the session state change notification was sent.
	/// </summary>
	[PInvokeData("winuser.h")]
	public enum WTS
	{
		/// <summary>The session identified by lParam was connected to the console terminal or RemoteFX session.</summary>
		WTS_CONSOLE_CONNECT = 0x1,

		/// <summary>The session identified by lParam was disconnected from the console terminal or RemoteFX session.</summary>
		WTS_CONSOLE_DISCONNECT = 0x2,

		/// <summary>The session identified by lParam was connected to the remote terminal.</summary>
		WTS_REMOTE_CONNECT = 0x3,

		/// <summary>The session identified by lParam was disconnected from the remote terminal.</summary>
		WTS_REMOTE_DISCONNECT = 0x4,

		/// <summary>A user has logged on to the session identified by lParam.</summary>
		WTS_SESSION_LOGON = 0x5,

		/// <summary>A user has logged off the session identified by lParam.</summary>
		WTS_SESSION_LOGOFF = 0x6,

		/// <summary>The session identified by lParam has been locked.</summary>
		WTS_SESSION_LOCK = 0x7,

		/// <summary>The session identified by lParam has been unlocked.</summary>
		WTS_SESSION_UNLOCK = 0x8,

		/// <summary>
		/// The session identified by lParam has changed its remote controlled status. To determine the status, call GetSystemMetrics and
		/// check the SM_REMOTECONTROL metric.
		/// </summary>
		WTS_SESSION_REMOTE_CONTROL = 0x9,

		/// <summary>Reserved for future use.</summary>
		WTS_SESSION_CREATE = 0xA,

		/// <summary>Reserved for future use.</summary>
		WTS_SESSION_TERMINATE = 0xB,
	}

	/// <summary>Retrieves the application command from the specified <c>LPARAM</c> value.</summary>
	/// <param name="lParam">The value to be converted.</param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-get_appcommand_lparam void GET_APPCOMMAND_LPARAM( lParam );
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.GET_APPCOMMAND_LPARAM")]
	public static APPCOMMAND GET_APPCOMMAND_LPARAM(IntPtr lParam) => (APPCOMMAND)(Macros.HIWORD(lParam) & ~FAPPCOMMAND_MASK);

	/// <summary>Retrieves the input device type from the specified <c>LPARAM</c> value.</summary>
	/// <param name="lParam">The value to be converted.</param>
	/// <returns>None</returns>
	/// <remarks>This macro is identical to the GET_MOUSEORKEY_LPARAM macro.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-get_device_lparam void GET_DEVICE_LPARAM( lParam );
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.GET_DEVICE_LPARAM")]
	public static FAPPCOMMAND GET_DEVICE_LPARAM(IntPtr lParam) => (FAPPCOMMAND)(Macros.HIWORD(lParam) & FAPPCOMMAND_MASK);

	/// <summary>Retrieves the state of certain virtual keys from the specified <c>LPARAM</c> value.</summary>
	/// <param name="lParam">The value to be converted.</param>
	/// <returns>None</returns>
	/// <remarks>This macro is identical to the GET_KEYSTATE_LPARAM macro.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-get_flags_lparam void GET_FLAGS_LPARAM( lParam );
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.GET_FLAGS_LPARAM")]
	public static ushort GET_FLAGS_LPARAM(IntPtr lParam) => Macros.LOWORD(lParam);

	/// <summary>Retrieves the state of certain virtual keys from the specified <c>LPARAM</c> value.</summary>
	/// <param name="lParam">The value to be converted.</param>
	/// <returns>None</returns>
	/// <remarks>This macro is identical to the GET_FLAGS_LPARAM macro.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-get_keystate_lparam void GET_KEYSTATE_LPARAM( lParam );
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.GET_KEYSTATE_LPARAM")]
	public static ushort GET_KEYSTATE_LPARAM(IntPtr lParam) => GET_FLAGS_LPARAM(lParam);

	/// <summary>Retrieves the input device type from the specified <c>LPARAM</c> value.</summary>
	/// <returns>
	/// <para>The return value is the bit of the high-order word representing the input device type. It can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code/value</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><c>FAPPCOMMAND_KEY</c> 0</description>
	/// <description>User pressed a key.</description>
	/// </item>
	/// <item>
	/// <description><c>FAPPCOMMAND_MOUSE</c> 0x8000</description>
	/// <description>User clicked a mouse button.</description>
	/// </item>
	/// <item>
	/// <description><c>FAPPCOMMAND_OEM</c> 0x1000</description>
	/// <description>An unidentified hardware source generated the event. It could be a mouse or a keyboard event.</description>
	/// </item>
	/// </list>
	/// <para>Â</para>
	/// </returns>
	/// <remarks>This macro is identical to the <c>GET_DEVICE_LPARAM</c> macro.</remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms646252(v=vs.85) WORD GET_MOUSEORKEY_LPARAM( &#194; LPARAM
	// lParam );
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.GET_MOUSEORKEY_LPARAM")]
	public static MouseButtonState GET_MOUSEORKEY_LPARAM(IntPtr lParam) => (MouseButtonState)(Macros.HIWORD(lParam) & FAPPCOMMAND_MASK);

	/// <summary>Retrieves the input code from <c>wParam</c> in WM_INPUT message.</summary>
	/// <param name="wParam"><c>wParam</c> from WM_INPUT message.</param>
	/// <returns>
	/// <para>Input code value. Can be one of the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>RIM_INPUT</c> 0</description>
	/// <description>Input occurred while the application was in the foreground.</description>
	/// </item>
	/// <item>
	/// <description><c>RIM_INPUTSINK</c> 1</description>
	/// <description>Input occurred while the application was not in the foreground.</description>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-get_rawinput_code_wparam void GET_RAWINPUT_CODE_WPARAM( wParam );
	[PInvokeData("winuser.h", MSDNShortId = "NF:winuser.GET_RAWINPUT_CODE_WPARAM")]
	public static RIM_CODE GET_RAWINPUT_CODE_WPARAM(IntPtr wParam) => (RIM_CODE)(wParam.ToInt32() & 0xff);

	/// <summary>Converts a WPARAM value to a character code.</summary>
	/// <param name="wParam">The WPARAM value.</param>
	/// <returns>The extracted <see cref="char"/> value.</returns>
	public static char WPARAM_TO_CHARCODE(IntPtr wParam) => Convert.ToChar((int)wParam);

	/// <summary>Contains data to be passed to another application by the WM_COPYDATA message.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-copydatastruct typedef struct tagCOPYDATASTRUCT { ULONG_PTR
	// dwData; DWORD cbData; PVOID lpData; } COPYDATASTRUCT, *PCOPYDATASTRUCT;
	[PInvokeData("winuser.h", MSDNShortId = "NS:winuser.tagCOPYDATASTRUCT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct COPYDATASTRUCT
	{
		/// <summary>
		/// <para>Type: <c>ULONG_PTR</c></para>
		/// <para>The type of the data to be passed to the receiving application. The receiving application defines the valid types.</para>
		/// </summary>
		public IntPtr dwData;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of the data pointed to by the <c>lpData</c> member.</para>
		/// </summary>
		public uint cbData;

		/// <summary>
		/// <para>Type: <c>PVOID</c></para>
		/// <para>The data to be passed to the receiving application. This member can be <c>NULL</c>.</para>
		/// </summary>
		public IntPtr lpData;
	}

	/// <summary>Contains information about the class, title, owner, location, and size of a multiple-document interface (MDI) child window.</summary>
	/// <remarks>
	/// <para>
	/// When the MDI client window creates an MDI child window by calling CreateWindow, the system sends a WM_CREATE message to the created
	/// window. The <c>lParam</c> member of the <c>WM_CREATE</c> message contains a pointer to a CREATESTRUCT structure. The
	/// <c>lpCreateParams</c> member of this structure contains a pointer to the <c>MDICREATESTRUCT</c> structure passed with the
	/// WM_MDICREATE message that created the MDI child window.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The winuser.h header defines MDICREATESTRUCT as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-mdicreatestructa typedef struct tagMDICREATESTRUCTA { LPCSTR
	// szClass; LPCSTR szTitle; HANDLE hOwner; int x; int y; int cx; int cy; DWORD style; LPARAM lParam; } MDICREATESTRUCTA, *LPMDICREATESTRUCTA;
	[PInvokeData("winuser.h", MSDNShortId = "NS:winuser.tagMDICREATESTRUCTA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct MDICREATESTRUCT
	{
		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The name of the window class of the MDI child window. The class name must have been registered by a previous call to the
		/// RegisterClass function.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string szClass;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The title of the MDI child window. The system displays the title in the child window's title bar.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string szTitle;

		/// <summary>
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>A handle to the instance of the application creating the MDI client window.</para>
		/// </summary>
		public HANDLE hOwner;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The initial horizontal position, in client coordinates, of the MDI child window. If this member is <c>CW_USEDEFAULT</c>, the MDI
		/// child window is assigned the default horizontal position.
		/// </para>
		/// </summary>
		public int x;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The initial vertical position, in client coordinates, of the MDI child window. If this member is <c>CW_USEDEFAULT</c>, the MDI
		/// child window is assigned the default vertical position.
		/// </para>
		/// </summary>
		public int y;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The initial width, in device units, of the MDI child window. If this member is <c>CW_USEDEFAULT</c>, the MDI child window is
		/// assigned the default width.
		/// </para>
		/// </summary>
		public int cx;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The initial height, in device units, of the MDI child window. If this member is set to <c>CW_USEDEFAULT</c>, the MDI child window
		/// is assigned the default height.
		/// </para>
		/// </summary>
		public int cy;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The style of the MDI child window. If the MDI client window was created with the <c>MDIS_ALLCHILDSTYLES</c> window style, this
		/// member can be any combination of the window styles listed in the Window Styles page. Otherwise, this member can be one or more of
		/// the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>WS_MINIMIZE</c> 0x20000000L</description>
		/// <description>Creates an MDI child window that is initially minimized.</description>
		/// </item>
		/// <item>
		/// <description><c>WS_MAXIMIZE</c> 0x01000000L</description>
		/// <description>Creates an MDI child window that is initially maximized.</description>
		/// </item>
		/// <item>
		/// <description><c>WS_HSCROLL</c> 0x00100000L</description>
		/// <description>Creates an MDI child window that has a horizontal scroll bar.</description>
		/// </item>
		/// <item>
		/// <description><c>WS_VSCROLL</c> 0x00200000L</description>
		/// <description>Creates an MDI child window that has a vertical scroll bar.</description>
		/// </item>
		/// </list>
		/// </summary>
		public WindowStyles style;

		/// <summary>
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>An application-defined value.</para>
		/// </summary>
		public IntPtr lParam;
	}

	/// <summary>The state specified in the wParam value of WM_*MOUSEWHEEL* commands.</summary>
	[PInvokeData("winuser.h")]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct MOUSEWHEEL
	{
		private readonly ushort btndown;

		/// <summary>
		/// The distance the wheel is rotated, expressed in multiples or factors of WHEEL_DELTA, which is set to 120. A positive value
		/// indicates that the wheel was rotated to the right or forward; a negative value indicates that the wheel was rotated to the left
		/// or backward.
		/// </summary>
		public readonly short distance;

		/// <summary>The down state of the mouse buttons.</summary>
		public MouseButtonState ButtonState => (MouseButtonState)btndown;

		/// <summary>Initializes a new instance of the <see cref="MOUSEWHEEL"/> struct.</summary>
		/// <param name="lParam">The lParam value from *UISTATE*.</param>
		public MOUSEWHEEL(IntPtr lParam)
		{ btndown = Macros.LOWORD(unchecked((uint)lParam.ToInt32())); distance = unchecked((short)Macros.HIWORD(unchecked((uint)lParam.ToInt32()))); }

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="MOUSEWHEEL"/>.</summary>
		/// <param name="p">The wParam.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator MOUSEWHEEL(IntPtr p) => new(p);
	}

	/// <summary>lParam value for <see cref="WindowMessage.WM_SIZE"/>.</summary>
	[PInvokeData("winuser.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SIZES(ushort width, ushort height)
	{
		/// <summary>The width</summary>
		public ushort Width = width;

		/// <summary>The height</summary>
		public ushort Height = height;

		/// <summary>Performs an explicit conversion from <see cref="System.IntPtr"/> to <see cref="Vanara.PInvoke.User32.SIZES"/>.</summary>
		/// <param name="p">The pointer value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator SIZES(IntPtr p) => new(Macros.LOWORD(p), Macros.HIWORD(p));

		/// <summary>Performs an implicit conversion from <see cref="Vanara.PInvoke.User32.SIZES"/> to <see cref="System.IntPtr"/>.</summary>
		/// <param name="s">The size.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator IntPtr(SIZES s) => Macros.MAKELPARAM(s.Width, s.Height);
	}

	/// <summary>Contains the styles for a window.</summary>
	/// <remarks>
	/// <para>
	/// The styles in <c>styleOld</c> and <c>styleNew</c> can be either the window styles ( <c>WS_</c>) or the extended window styles (
	/// <c>WS_EX_</c>), depending on the <c>wParam</c> of the message that includes <c>STYLESTRUCT</c>.
	/// </para>
	/// <para>
	/// The <c>styleOld</c> and <c>styleNew</c> members indicate the styles through their bit pattern. Note that several styles are equal to
	/// zero; to detect these styles, test for the negation of their inverse style. For example, to see if <c>WS_EX_LEFT</c> is set, you test
	/// for ~ <c>WS_EX_RIGHT</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-stylestruct typedef struct tagSTYLESTRUCT { DWORD styleOld;
	// DWORD styleNew; } STYLESTRUCT, *LPSTYLESTRUCT;
	[PInvokeData("winuser.h", MSDNShortId = "NS:winuser.tagSTYLESTRUCT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STYLESTRUCT
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The previous styles for a window. For more information, see the Remarks.</para>
		/// </summary>
		public uint styleOld;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The new styles for a window. For more information, see the Remarks.</para>
		/// </summary>
		public uint styleNew;
	}

	/// <summary>The state specified in the wParam value of WM_*UISTATE* commands.</summary>
	[PInvokeData("winuser.h")]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct UISTATE
	{
		/// <summary>Specifies the action to be taken.</summary>
		public readonly UIS action;

		/// <summary>The state</summary>
		public readonly UISF state;

		/// <summary>Initializes a new instance of the <see cref="UISTATE"/> struct.</summary>
		/// <param name="lParam">The lParam value from *UISTATE*.</param>
		public UISTATE(IntPtr lParam)
		{ action = (UIS)Macros.LOWORD(unchecked((uint)lParam.ToInt32())); state = (UISF)Macros.HIWORD(unchecked((uint)lParam.ToInt32())); }

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="UISTATE"/>.</summary>
		/// <param name="p">The wParam.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator UISTATE(IntPtr p) => new(p);
	}

	/// <summary>Handles lParam value of WM_HOTKEY.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct WM_HOTKEY_LPARAM
	{
		private readonly ushort _Modifiers;
		private readonly ushort _VirtualKeyCode;

		/// <summary>The keys that were to be pressed in combination with the key specified by the high-order word to generate the message.</summary>
		public HotKeyModifiers Modifiers => (HotKeyModifiers)_Modifiers;

		/// <summary>Gets the virtual key code of the hot key.</summary>
		public VK VirtualKeyCode => (VK)_VirtualKeyCode;

		/// <summary>Initializes a new instance of the <see cref="WM_HOTKEY_LPARAM"/> struct.</summary>
		/// <param name="lParam">The lParam value from *UISTATE*.</param>
		public WM_HOTKEY_LPARAM(IntPtr lParam)
		{ _Modifiers = Macros.LOWORD(unchecked((uint)lParam.ToInt32())); _VirtualKeyCode = Macros.HIWORD(unchecked((uint)lParam.ToInt32())); }

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="WM_HOTKEY_LPARAM"/>.</summary>
		/// <param name="p">The wParam.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator WM_HOTKEY_LPARAM(IntPtr p) => new(p);
	}

	/// <summary>Helper structure to dicect the lParam of WM_KEYxx messages.</summary>
	[PInvokeData("winuser.h")]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct WM_KEY_LPARAM
	{
		private readonly uint lp;

		/// <summary>
		/// The repeat count for the current message. The value is the number of times the keystroke is autorepeated as a result of the user
		/// holding down the key. If the keystroke is held long enough, multiple messages are sent. However, the repeat count is not cumulative.
		/// </summary>
		public ushort RepeatCount => (ushort)BitHelper.GetBits(lp, 0, 16);

		/// <summary>The scan code. The value depends on the OEM.</summary>
		public byte ScanCode => (byte)BitHelper.GetBits(lp, 16, 8);

		/// <summary>
		/// Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key
		/// keyboard. The value is 1 if it is an extended key; otherwise, it is 0.
		/// </summary>
		public bool ExtendedKey => BitHelper.GetBit(lp, 24);

		/// <summary>The context code. The value is 1 if the ALT key is held down while the key is pressed; otherwise, the value is 0.</summary>
		public bool AltKeyDown => BitHelper.GetBit(lp, 29);

		/// <summary>The previous key state. The value is 1 if the key is down before the message is sent, or it is 0 if the key is up.</summary>
		public bool PrevKeyDown => BitHelper.GetBit(lp, 30);

		/// <summary>Transition state. The value is 1 if the key is being released, or it is 0 if the key is being pressed.</summary>
		public bool KeyReleased => BitHelper.GetBit(lp, 31);

		/// <summary>Initializes a new instance of the <see cref="WM_KEY_LPARAM"/> struct.</summary>
		/// <param name="lParam">The lParam value from WM_KEYxx.</param>
		public WM_KEY_LPARAM(IntPtr lParam) => lp = unchecked((uint)lParam.ToInt32());

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="WM_KEY_LPARAM"/>.</summary>
		/// <param name="p">The lParam.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator WM_KEY_LPARAM(IntPtr p) => new(p);
	}

	/// <summary>The state specified in the wParam value of WM_*MOUSEWHEEL* commands.</summary>
	[PInvokeData("winuser.h")]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct WM_SCROLL_LPARAM
	{
		private readonly ushort _scrollbarEvent;

		/// <summary>The current position of the scroll box if the low-order word of lParam is SB_THUMBPOSITION.</summary>
		public readonly ushort scrollPosition;

		/// <summary>The scroll bar event.</summary>
		public SBCMD ScrollbarEvent => (SBCMD)_scrollbarEvent;

		/// <summary>Initializes a new instance of the <see cref="WM_SCROLL_LPARAM"/> struct.</summary>
		/// <param name="lParam">The lParam value from *UISTATE*.</param>
		public WM_SCROLL_LPARAM(IntPtr lParam)
		{ _scrollbarEvent = Macros.LOWORD(unchecked((uint)lParam.ToInt32())); scrollPosition = Macros.HIWORD(unchecked((uint)lParam.ToInt32())); }

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="WM_SCROLL_LPARAM"/>.</summary>
		/// <param name="p">The wParam.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator WM_SCROLL_LPARAM(IntPtr p) => new(p);
	}

	/// <summary>lParam value for WM_SETCURSOR.</summary>
	[PInvokeData("winuser.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WM_SETCURSOR_LPARAM
	{
		private IntPtr lp;

		/// <summary>Specifies the hit-test result for the cursor position.</summary>
		public HitTestValues HitTestResult => (HitTestValues)Macros.LOWORD(lp);

		/// <summary>
		/// Specifies the mouse window message which triggered this event, such as WM_MOUSEMOVE. When the window enters menu mode, this value
		/// is zero.
		/// </summary>
		public WindowMessage MouseWindowMessage => (WindowMessage)Macros.HIWORD(lp);

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="WM_SETCURSOR_LPARAM"/>.</summary>
		/// <param name="lparam">The lparam value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator WM_SETCURSOR_LPARAM(IntPtr lparam) => new() { lp = lparam };
	}
}