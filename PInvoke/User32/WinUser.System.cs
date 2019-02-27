using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>Callback function that processes help events for the message box.</summary>
		/// <param name="lpHelpInfo">The help information.</param>
		[PInvokeData("Winuser.h")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void MsgBoxCallback(ref HELPINFO lpHelpInfo);

		/// <summary>The starting position and direction used when arranging minimized windows.</summary>
		[PInvokeData("Winuser.h")]
		[Flags]
		public enum ARW : uint
		{
			/// <summary>Start at the lower-left corner of the work area.</summary>
			ARW_BOTTOMLEFT = 0x0000,

			/// <summary>Start at the lower-right corner of the work area.</summary>
			ARW_BOTTOMRIGHT = 0x0001,

			/// <summary>Start at the upper-left corner of the work area.</summary>
			ARW_TOPLEFT = 0x0002,

			/// <summary>Start at the upper-right corner of the work area.</summary>
			ARW_TOPRIGHT = 0x0003,

			/// <summary>Arrange left (valid with ARW_BOTTOMRIGHT and ARW_TOPRIGHT only).</summary>
			ARW_LEFT = 0x0000,

			/// <summary>Arrange right (valid with ARW_BOTTOMLEFT and ARW_TOPLEFT only).</summary>
			ARW_RIGHT = 0x0000,

			/// <summary>Arrange up (valid with ARW_BOTTOMLEFT and ARW_BOTTOMRIGHT only).</summary>
			ARW_UP = 0x0004,

			/// <summary>Arrange down (valid with ARW_TOPLEFT and ARW_TOPRIGHT only).</summary>
			ARW_DOWN = 0x0004,

			/// <summary>Hide minimized windows by moving them off the visible area of the screen.</summary>
			ARW_HIDE = 0x0008,
		}

		/// <summary>A set of bit flags that specify properties of the time-out behavior for accessibility features.</summary>
		[PInvokeData("Winuser.h")]
		[Flags]
		public enum ATF
		{
			/// <summary>
			/// If this flag is set, a time-out period has been set for accessibility features. If this flag is not set, the features will
			/// not time out even though a time-out period is specified.
			/// </summary>
			ATF_TIMEOUTON = 0x00000001,

			/// <summary>
			/// If this flag is set, the operating system plays a descending siren sound when the time-out period elapses and the
			/// accessibility features are turned off.
			/// </summary>
			ATF_ONOFFFEEDBACK = 0x00000002
		}

		/// <summary>Enum for SystemParametersInfo</summary>
		[PInvokeData("Winuser.h")]
		public enum ContactVisualization : uint
		{
			/// <summary>Specifies UI feedback for all contacts is off.</summary>
			CONTACTVISUALIZATION_OFF = 0x0000,

			/// <summary>Specifies UI feedback for all contacts is on.</summary>
			CONTACTVISUALIZATION_ON = 0x0001,

			/// <summary>Specifies UI feedback for all contacts is on with presentation mode visuals.</summary>
			CONTACTVISUALIZATION_PRESENTATIONMODE = 0x0002,
		}

		/// <summary>The shutdown type for the <see cref="ExitWindowsEx"/> method.</summary>
		[PInvokeData("Winuser.h")]
		[Flags]
		public enum ExitWindowsFlags
		{
			/// <summary>
			/// Shuts down all processes running in the logon session of the process that called the ExitWindowsEx function. Then it logs the
			/// user off.
			/// <para>This flag can be used only by processes running in an interactive user's logon session.</para>
			/// </summary>
			EWX_LOGOFF = 0x00000000,

			/// <summary>
			/// Shuts down the system to a point at which it is safe to turn off the power. All file buffers have been flushed to disk, and
			/// all running processes have stopped.
			/// <para>The calling process must have the SE_SHUTDOWN_NAME privilege. For more information, see the following Remarks section.</para>
			/// <para>
			/// Specifying this flag will not turn off the power even if the system supports the power-off feature. You must specify
			/// EWX_POWEROFF to do this.
			/// </para>
			/// <para>Windows XP with SP1: If the system supports the power-off feature, specifying this flag turns off the power.</para>
			/// </summary>
			EWX_SHUTDOWN = 0x00000001,

			/// <summary>
			/// Shuts down the system and then restarts the system.
			/// <para>The calling process must have the SE_SHUTDOWN_NAME privilege. For more information, see the following Remarks section.</para>
			/// </summary>
			EWX_REBOOT = 0x00000002,

			/// <summary>
			/// This flag has no effect if terminal services is enabled. Otherwise, the system does not send the WM_QUERYENDSESSION message.
			/// This can cause applications to lose data. Therefore, you should only use this flag in an emergency.
			/// </summary>
			EWX_FORCE = 0x00000004,

			/// <summary>
			/// Shuts down the system and turns off the power. The system must support the power-off feature.
			/// <para>The calling process must have the SE_SHUTDOWN_NAME privilege. For more information, see the following Remarks section.</para>
			/// </summary>
			EWX_POWEROFF = 0x00000008,

			/// <summary>
			/// Forces processes to terminate if they do not respond to the WM_QUERYENDSESSION or WM_ENDSESSION message within the timeout
			/// interval. For more information, see the Remarks.
			/// </summary>
			EWX_FORCEIFHUNG = 0x00000010,

			/// <summary>The ewx quickresolve</summary>
			EWX_QUICKRESOLVE = 0x00000020,

			/// <summary>
			/// Shuts down the system and then restarts it, as well as any applications that have been registered for restart using the
			/// RegisterApplicationRestart function. These application receive the WM_QUERYENDSESSION message with lParam set to the
			/// ENDSESSION_CLOSEAPP value. For more information, see Guidelines for Applications.
			/// </summary>
			EWX_RESTARTAPPS = 0x00000040,

			/// <summary>
			/// Beginning with Windows 8: You can prepare the system for a faster startup by combining the EWX_HYBRID_SHUTDOWN flag with the
			/// EWX_SHUTDOWN flag.
			/// </summary>
			EWX_HYBRID_SHUTDOWN = 0x00400000,

			/// <summary>When combined with the EWX_REBOOT flag, will reboot to the boot options.</summary>
			EWX_BOOTOPTIONS = 0x01000000,
		}

		/// <summary>A set of bit flags that specify properties of the FilterKeys feature.</summary>
		[PInvokeData("Winuser.h")]
		[Flags]
		public enum FKF
		{
			/// <summary>The FilterKeys features are available.</summary>
			FKF_AVAILABLE = 0x00000002,

			/// <summary>
			/// The computer makes a click sound when a key is pressed or accepted. If SlowKeys is on, a click is generated when the key is
			/// pressed and again when the keystroke is accepted.
			/// </summary>
			FKF_CLICKON = 0x00000040,

			/// <summary>
			/// Windows 95/98, Windows 2000: A confirmation dialog box appears when the FilterKeys features are activated by using the hot key.
			/// </summary>
			FKF_CONFIRMHOTKEY = 0x00000008,

			/// <summary>The FilterKeys features are on.</summary>
			FKF_FILTERKEYSON = 0x00000001,

			/// <summary>The user can turn the FilterKeys feature on and off by holding down the RIGHT SHIFT key for eight seconds.</summary>
			FKF_HOTKEYACTIVE = 0x00000004,

			/// <summary>
			/// If this flag is set, the computer plays a siren sound when the user turns the FilterKeys feature on or off by using the hot key.
			/// </summary>
			FKF_HOTKEYSOUND = 0x00000010,

			/// <summary>Windows 95, Windows 2000: A visual indicator is displayed when the FilterKeys features are on.</summary>
			FKF_INDICATOR = 0x00000020,
		}

		/// <summary>Enum for SystemParametersInfo</summary>
		[PInvokeData("Winuser.h")]
		[Flags]
		public enum GestureVisualization : uint
		{
			/// <summary>Specifies that UI feedback for all gestures is off.</summary>
			GESTUREVISUALIZATION_OFF = 0x0000,

			/// <summary>Specifies that UI feedback for all gestures is on.</summary>
			GESTUREVISUALIZATION_ON = 0x001F,

			/// <summary>Specifies UI feedback for a tap.</summary>
			GESTUREVISUALIZATION_TAP = 0x0001,

			/// <summary>Specifies UI feedback for a double tap.</summary>
			GESTUREVISUALIZATION_DOUBLETAP = 0x0002,

			/// <summary>Specifies UI feedback for a press and tap.</summary>
			GESTUREVISUALIZATION_PRESSANDTAP = 0x0004,

			/// <summary>Specifies UI feedback for a press and hold.</summary>
			GESTUREVISUALIZATION_PRESSANDHOLD = 0x0008,

			/// <summary>Specifies UI feedback for a right tap.</summary>
			GESTUREVISUALIZATION_RIGHTTAP = 0x0010,
		}

		/// <summary>Enum for SystemParametersInfo</summary>
		[PInvokeData("Winuser.h")]
		public enum HANDEDNESS
		{
			/// <summary>Undocumented</summary>
			HANDEDNESS_LEFT = 0,

			/// <summary>Undocumented</summary>
			HANDEDNESS_RIGHT
		}

		/// <summary>Values used by HELPINFO.iContextType specifying the type of context for which Help is requested.</summary>
		[PInvokeData("Winuser.h")]
		public enum HELPINFOCONTEXT
		{
			/// <summary>Help requested for a menu item.</summary>
			HELPINFO_MENUITEM,

			/// <summary>Help requested for a control or window.</summary>
			HELPINFO_WINDOW
		}

		/// <summary>A set of bit flags that specify properties of the HighContrast feature.</summary>
		[PInvokeData("Winuser.h")]
		[Flags]
		public enum HFC
		{
			/// <summary>The high contrast feature is available.</summary>
			HCF_AVAILABLE = 0x00000002,

			/// <summary>A confirmation dialog appears when the high contrast feature is activated by using the hot key.</summary>
			HCF_CONFIRMHOTKEY = 0x00000008,

			/// <summary>The high contrast feature is on.</summary>
			HCF_HIGHCONTRASTON = 0x00000001,

			/// <summary>
			/// The user can turn the high contrast feature on and off by simultaneously pressing the left ALT, left SHIFT, and PRINT SCREEN keys.
			/// </summary>
			HCF_HOTKEYACTIVE = 0x00000004,

			/// <summary>
			/// The hot key associated with the high contrast feature can be enabled. An application can retrieve this value, but cannot set it.
			/// </summary>
			HCF_HOTKEYAVAILABLE = 0x00000040,

			/// <summary>A siren is played when the user turns the high contrast feature on or off by using the hot key.</summary>
			HCF_HOTKEYSOUND = 0x00000010,

			/// <summary>
			/// A visual indicator is displayed when the high contrast feature is on. This value is not currently used and is ignored.
			/// </summary>
			HCF_INDICATOR = 0x00000020,

			/// <summary>Undocumented</summary>
			HCF_LOGONDESKTOP = 0x00000100,

			/// <summary>Undocumented</summary>
			HCF_DEFAULTDESKTOP = 0x00000200
		}

		/// <summary>Specifies the contents and behavior of a message box.</summary>
		[PInvokeData("Winuser.h")]
		[Flags]
		public enum MB_FLAGS
		{
			/// <summary>The message box contains three push buttons: Abort, Retry, and Ignore.</summary>
			MB_ABORTRETRYIGNORE = 0x00000002,

			/// <summary>
			/// The message box contains three push buttons: Cance, Try Again, Continue. Use this message box type instead of MB_ABORTRETRYIGNORE.
			/// </summary>
			MB_CANCELTRYCONTINUE = 0x00000006,

			/// <summary>
			/// Adds a Help button to the message box. When the user clicks the Help button or presses F1, the system sends a WM_HELP message
			/// to the owner.
			/// </summary>
			MB_HELP = 0x00004000,

			/// <summary>The message box contains one push button: OK. This is the default.</summary>
			MB_OK = 0x00000000,

			/// <summary>The message box contains two push buttons: OK and Cancel.</summary>
			MB_OKCANCEL = 0x00000001,

			/// <summary>The message box contains two push buttons: Retry and Cancel.</summary>
			MB_RETRYCANCEL = 0x00000005,

			/// <summary>The message box contains two push buttons: Yes and No.</summary>
			MB_YESNO = 0x00000004,

			/// <summary>The message box contains three push buttons: Yes, No, and Cancel.</summary>
			MB_YESNOCANCEL = 0x00000003,

			/// <summary>An exclamation-point icon appears in the message box.</summary>
			MB_ICONEXCLAMATION = 0x00000030,

			/// <summary>An exclamation-point icon appears in the message box.</summary>
			MB_ICONWARNING = 0x00000030,

			/// <summary>An icon consisting of a lowercase letter i in a circle appears in the message box.</summary>
			MB_ICONINFORMATION = 0x00000040,

			/// <summary>An icon consisting of a lowercase letter i in a circle appears in the message box.</summary>
			MB_ICONASTERISK = 0x00000040,

			/// <summary>
			/// A question-mark icon appears in the message box. The question-mark message icon is no longer recommended because it does not
			/// clearly represent a specific type of message and because the phrasing of a message as a question could apply to any message
			/// type. In addition, users can confuse the message symbol question mark with Help information. Therefore, do not use this
			/// question mark message symbol in your message boxes. The system continues to support its inclusion only for backward compatibility.
			/// </summary>
			MB_ICONQUESTION = 0x00000020,

			/// <summary>A stop-sign icon appears in the message box.</summary>
			MB_ICONSTOP = 0x00000010,

			/// <summary>A stop-sign icon appears in the message box.</summary>
			MB_ICONERROR = 0x00000010,

			/// <summary>A stop-sign icon appears in the message box.</summary>
			MB_ICONHAND = 0x00000010,

			/// <summary>
			/// The first button is the default button.
			/// <para>MB_DEFBUTTON1 is the default unless MB_DEFBUTTON2, MB_DEFBUTTON3, or MB_DEFBUTTON4 is specified.</para>
			/// </summary>
			MB_DEFBUTTON1 = 0x00000000,

			/// <summary>The second button is the default button.</summary>
			MB_DEFBUTTON2 = 0x00000100,

			/// <summary>The third button is the default button.</summary>
			MB_DEFBUTTON3 = 0x00000200,

			/// <summary>The fourth button is the default button.</summary>
			MB_DEFBUTTON4 = 0x00000300,

			/// <summary>
			/// The user must respond to the message box before continuing work in the window identified by the hWnd parameter. However, the
			/// user can move to the windows of other threads and work in those windows.
			/// <para>
			/// Depending on the hierarchy of windows in the application, the user may be able to move to other windows within the thread.
			/// All child windows of the parent of the message box are automatically disabled, but pop-up windows are not.
			/// </para>
			/// <para>MB_APPLMODAL is the default if neither MB_SYSTEMMODAL nor MB_TASKMODAL is specified.</para>
			/// </summary>
			MB_APPLMODAL = 0x00000000,

			/// <summary>
			/// Same as MB_APPLMODAL except that the message box has the WS_EX_TOPMOST style. Use system-modal message boxes to notify the
			/// user of serious, potentially damaging errors that require immediate attention (for example, running out of memory). This flag
			/// has no effect on the user's ability to interact with windows other than those associated with hWnd.
			/// </summary>
			MB_SYSTEMMODAL = 0x00001000,

			/// <summary>
			/// Same as MB_APPLMODAL except that all the top-level windows belonging to the current thread are disabled if the hWnd parameter
			/// is NULL. Use this flag when the calling application or library does not have a window handle available but still needs to
			/// prevent input to other windows in the calling thread without suspending other threads.
			/// </summary>
			MB_TASKMODAL = 0x00002000,

			/// <summary>
			/// Same as desktop of the interactive window station. For more information, see Window Stations.
			/// <para>
			/// If the current input desktop is not the default desktop, MessageBox does not return until the user switches to the default desktop.
			/// </para>
			/// </summary>
			MB_DEFAULT_DESKTOP_ONLY = 0x00020000,

			/// <summary>The text is right-justified.</summary>
			MB_RIGHT = 0x00080000,

			/// <summary>Displays message and caption text using right-to-left reading order on Hebrew and Arabic systems.</summary>
			MB_RTLREADING = 0x00100000,

			/// <summary>
			/// The message box becomes the foreground window. Internally, the system calls the SetForegroundWindow function for the message box.
			/// </summary>
			MB_SETFOREGROUND = 0x00010000,

			/// <summary>The message box is created with the WS_EX_TOPMOST window style.</summary>
			MB_TOPMOST = 0x00040000,

			/// <summary>
			/// The caller is a service notifying the user of an event. The function displays a message box on the current active desktop,
			/// even if there is no user logged on to the computer.
			/// <para>
			/// Terminal Services: If the calling thread has an impersonation token, the function directs the message box to the session
			/// specified in the impersonation token.
			/// </para>
			/// <para>
			/// If this flag is set, the hWnd parameter must be NULL. This is so that the message box can appear on a desktop other than the
			/// desktop corresponding to the hWnd.
			/// </para>
			/// <para>
			/// For information on security considerations in regard to using this flag, see Interactive Services. In particular, be aware
			/// that this flag can produce interactive content on a locked desktop and should therefore be used for only a very limited set
			/// of scenarios, such as resource exhaustion.
			/// </para>
			/// </summary>
			MB_SERVICE_NOTIFICATION = 0x00200000,
		}

		/// <summary>Specifies the contents and behavior of a message box.</summary>
		[PInvokeData("Winuser.h")]
		[Flags]
		public enum MB_RESULT
		{
			/// <summary>The Abort button was selected.</summary>
			IDABORT = 3,

			/// <summary>The Cancel button was selected.</summary>
			IDCANCEL = 2,

			/// <summary>The Continue button was selected.</summary>
			IDCONTINUE = 11,

			/// <summary>The Ignore button was selected.</summary>
			IDIGNORE = 5,

			/// <summary>The No button was selected.</summary>
			IDNO = 7,

			/// <summary>The OK button was selected.</summary>
			IDOK = 1,

			/// <summary>The Retry button was selected.</summary>
			IDRETRY = 4,

			/// <summary>The Try Again button was selected.</summary>
			IDTRYAGAIN = 10,

			/// <summary>The Yes button was selected.</summary>
			IDYES = 6,
		}

		/// <summary>A set of bit-flags that specify properties of the MouseKeys feature.</summary>
		[PInvokeData("Winuser.h")]
		[Flags]
		public enum MKF : uint
		{
			/// <summary>If this flag is set, the MouseKeys feature is available.</summary>
			MKF_AVAILABLE = 0x00000002,

			/// <summary>
			/// Windows 95/98, Windows 2000: A confirmation dialog box appears when the MouseKeys feature is activated by using the hot key.
			/// </summary>
			MKF_CONFIRMHOTKEY = 0x00000008,

			/// <summary>
			/// If this flag is set, the user can turn the MouseKeys feature on and off by using the hot key, which is LEFT ALT+LEFT
			/// SHIFT+NUM LOCK.
			/// </summary>
			MKF_HOTKEYACTIVE = 0x00000004,

			/// <summary>
			/// If this flag is set, the system plays a siren sound when the user turns the MouseKeys feature on or off by using the hot key.
			/// </summary>
			MKF_HOTKEYSOUND = 0x00000010,

			/// <summary>Windows 95/98, Windows 2000: A visual indicator is displayed when the MouseKeys feature is on.</summary>
			MKF_INDICATOR = 0x00000020,

			/// <summary>Windows 95/98, Windows 2000: The left button is in the "down" state.</summary>
			MKF_LEFTBUTTONDOWN = 0x01000000,

			/// <summary>Windows 95/98, Windows 2000: The user has selected the left button for mouse-button actions.</summary>
			MKF_LEFTBUTTONSEL = 0x10000000,

			/// <summary>
			/// Windows 95/98, Windows 2000: The CTRL key increases cursor speed by the value specified by the iCtrlSpeed member, and the
			/// SHIFT key causes the cursor to delay briefly after moving a single pixel, allowing fine positioning of the cursor. If this
			/// value is not specified, the CTRLand SHIFT keys are ignored while the user moves the mouse cursor using the arrow keys.
			/// </summary>
			MKF_MODIFIERS = 0x00000040,

			/// <summary>If this flag is set, the MouseKeys feature is on.</summary>
			MKF_MOUSEKEYSON = 0x00000001,

			/// <summary>Windows 95/98, Windows 2000: The system is processing numeric keypad input as mouse commands.</summary>
			MKF_MOUSEMODE = 0x80000000,

			/// <summary>
			/// Windows 95/98, Windows 2000: The numeric keypad moves the mouse when the NUM LOCK key is on. If this flag is not specified,
			/// the numeric keypad moves the mouse cursor when the NUM LOCK key is off.
			/// </summary>
			MKF_REPLACENUMBERS = 0x00000080,

			/// <summary>Windows 95/98, Windows 2000: The right button is in the "down" state.</summary>
			MKF_RIGHTBUTTONDOWN = 0x02000000,

			/// <summary>Windows 95/98, Windows 2000: The user has selected the right button for mouse-button actions.</summary>
			MKF_RIGHTBUTTONSEL = 0x20000000,
		}

		/// <summary>Enum for SystemParametersInfo</summary>
		[PInvokeData("Winuser.h")]
		public enum MouseWheelRouting : uint
		{
			/// <summary>Mouse wheel input is delivered to the app with focus.</summary>
			MOUSEWHEEL_ROUTING_FOCUS = 0,

			/// <summary>
			/// Mouse wheel input is delivered to the app with focus (desktop apps) or the app under the mouse cursor (Windows Store apps).
			/// </summary>
			MOUSEWHEEL_ROUTING_HYBRID = 1,

			/// <summary>Undocumented</summary>
			MOUSEWHEEL_ROUTING_MOUSE_POS = 2
		}

		/// <summary>Enum for SystemParametersInfo</summary>
		[PInvokeData("Winuser.h")]
		public enum PenArbitrationType : uint
		{
			/// <summary>Undocumented</summary>
			PENARBITRATIONTYPE_NONE = 0x0000,

			/// <summary>Undocumented</summary>
			PENARBITRATIONTYPE_WIN8 = 0x0001,

			/// <summary>Undocumented</summary>
			PENARBITRATIONTYPE_FIS = 0x0002,

			/// <summary>Undocumented</summary>
			PENARBITRATIONTYPE_SPT = 0x0003,

			/// <summary>Undocumented</summary>
			PENARBITRATIONTYPE_MAX = 0x0004,
		}

		/// <summary>Enum for SystemParametersInfo</summary>
		[PInvokeData("Winuser.h")]
		public enum PenVisualization : uint
		{
			/// <summary>Specifies that UI feedback for all pen gestures is off.</summary>
			PENVISUALIZATION_OFF = 0x0000,

			/// <summary>Specifies that UI feedback for all pen gestures is on.</summary>
			PENVISUALIZATION_ON = 0x0023,

			/// <summary>Specifies UI feedback for a pen tap.</summary>
			PENVISUALIZATION_TAP = 0x0001,

			/// <summary>Specifies UI feedback for a pen double tap.</summary>
			PENVISUALIZATION_DOUBLETAP = 0x0002,

			/// <summary>Specifies UI feedback for the pen cursor.</summary>
			PENVISUALIZATION_CURSOR = 0x0020,
		}

		/// <summary>A set of bit-flags that specify properties of the SerialKeys feature.</summary>
		[PInvokeData("Winuser.h")]
		[Flags]
		public enum SERKF
		{
			/// <summary>The SerialKeys feature is on.</summary>
			SERKF_SERIALKEYSON = 0x00000001,

			/// <summary>The SerialKeys feature is available.</summary>
			SERKF_AVAILABLE = 0x00000002,

			/// <summary>A visual indicator is displayed when the SerialKeys feature is on. This value is not currently used and is ignored.</summary>
			SERKF_INDICATOR = 0x00000004,
		}

		/// <summary>A set of bit-flags that specify properties of the StickyKeys feature.</summary>
		[PInvokeData("Winuser.h")]
		[Flags]
		public enum SKF : uint
		{
			/// <summary>
			/// If this flag is set, the system plays a sound when the user latches, locks, or releases modifier keys using the StickyKeys feature.
			/// </summary>
			SKF_AUDIBLEFEEDBACK = 0x00000040,

			/// <summary>If this flag is set, the StickyKeys feature is available.</summary>
			SKF_AVAILABLE = 0x00000002,

			/// <summary>
			/// Windows 95/98, Windows 2000: A confirmation dialog appears when the StickyKeys feature is activated by using the hot key.
			/// </summary>
			SKF_CONFIRMHOTKEY = 0x00000008,

			/// <summary>If this flag is set, the user can turn the StickyKeys feature on and off by pressing the SHIFT key five times.</summary>
			SKF_HOTKEYACTIVE = 0x00000004,

			/// <summary>
			/// If this flag is set, the system plays a siren sound when the user turns the StickyKeys feature on or off by using the hot key.
			/// </summary>
			SKF_HOTKEYSOUND = 0x00000010,

			/// <summary>Windows 95/98, Windows 2000: A visual indicator should be displayed when the StickyKeys feature is on.</summary>
			SKF_INDICATOR = 0x00000020,

			/// <summary>If this flag is set, the StickyKeys feature is on.</summary>
			SKF_STICKYKEYSON = 0x00000001,

			/// <summary>
			/// If this flag is set, pressing a modifier key twice in a row locks down the key until the user presses it a third time.
			/// </summary>
			SKF_TRISTATE = 0x00000080,

			/// <summary>
			/// If this flag is set, releasing a modifier key that has been pressed in combination with any other key turns off the
			/// StickyKeys feature.
			/// </summary>
			SKF_TWOKEYSOFF = 0x00000100,

			/// <summary>Windows 98, Windows 2000: The left ALT key is latched.</summary>
			SKF_LALTLATCHED = 0x10000000,

			/// <summary>Windows 98, Windows 2000: The left CTRL key is latched.</summary>
			SKF_LCTLLATCHED = 0x04000000,

			/// <summary>Windows 98, Windows 2000: The left SHIFT key is latched.</summary>
			SKF_LSHIFTLATCHED = 0x01000000,

			/// <summary>Windows 98, Windows 2000: The right ALT key is latched.</summary>
			SKF_RALTLATCHED = 0x20000000,

			/// <summary>Windows 98, Windows 2000: The right CTRL key is latched.</summary>
			SKF_RCTLLATCHED = 0x08000000,

			/// <summary>Windows 98, Windows 2000: The right SHIFT key is latched.</summary>
			SKF_RSHIFTLATCHED = 0x02000000,

			/// <summary>Windows 98, Windows 2000: The left ALT key is locked.</summary>
			SKF_LALTLOCKED = 0x00100000,

			/// <summary>Windows 98, Windows 2000: The left CTRL key is locked.</summary>
			SKF_LCTLLOCKED = 0x00040000,

			/// <summary>Windows 98, Windows 2000: The left SHIFT key is locked.</summary>
			SKF_LSHIFTLOCKED = 0x00010000,

			/// <summary>Windows 98, Windows 2000: The right ALT key is locked.</summary>
			SKF_RALTLOCKED = 0x00200000,

			/// <summary>Windows 98, Windows 2000: The right CTRL key is locked.</summary>
			SKF_RCTLLOCKED = 0x00080000,

			/// <summary>Windows 98, Windows 2000: The right SHIFT key is locked.</summary>
			SKF_RSHIFTLOCKED = 0x00020000,

			/// <summary>Windows 98, Windows 2000: The left Windows key is latched.</summary>
			SKF_LWINLATCHED = 0x40000000,

			/// <summary>Windows 98, Windows 2000: The right Windows key is latched.</summary>
			SKF_RWINLATCHED = 0x80000000,

			/// <summary>Windows 98, Windows 2000: The left Windows key is locked.</summary>
			SKF_LWINLOCKED = 0x00400000,

			/// <summary>Windows 98, Windows 2000: The right Windows key is locked.</summary>
			SKF_RWINLOCKED = 0x00800000,
		}

		/// <summary>Enum for SystemParametersInfo</summary>
		[PInvokeData("Winuser.h")]
		public enum SPI : uint
		{
			/// <summary>
			/// Determines whether the warning beeper is on. The pvParam parameter must point to a BOOL variable that receives TRUE if the
			/// beeper is on, or FALSE if it is off.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get, false)]
			SPI_GETBEEP = 0x0001,

			/// <summary>Turns the warning beeper on or off. The uiParam parameter specifies TRUE for on, or FALSE for off.</summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETBEEP = 0x0002,

			/// <summary>Retrieves the two mouse threshold values and the mouse speed.</summary>
			[SPCorrespondingType(typeof(int[]), CorrepsondingAction.Get, false)]
			SPI_GETMOUSE = 0x0003,

			/// <summary>Sets the two mouse threshold values and the mouse speed.</summary>
			[SPCorrespondingType(typeof(int[]), CorrepsondingAction.Set, false)]
			SPI_SETMOUSE = 0x0004,

			/// <summary>
			/// Retrieves the border multiplier factor that determines the width of a window's sizing border. The pvParam parameter must
			/// point to an integer variable that receives this value.
			/// </summary>
			[SPCorrespondingType(typeof(int), CorrepsondingAction.Get, false)]
			SPI_GETBORDER = 0x0005,

			/// <summary>
			/// Sets the border multiplier factor that determines the width of a window's sizing border. The uiParam parameter specifies the
			/// new value.
			/// </summary>
			[SPCorrespondingType(typeof(int), CorrepsondingAction.Set, true)]
			SPI_SETBORDER = 0x0006,

			/// <summary>
			/// Retrieves the keyboard repeat-speed setting, which is a value in the range from 0 (approximately 2.5 repetitions per second)
			/// through 31 (approximately 30 repetitions per second). The actual repeat rates are hardware-dependent and may vary from a
			/// linear scale by as much as 20%. The pvParam parameter must point to a DWORD variable that receives the setting
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get, false)]
			SPI_GETKEYBOARDSPEED = 0x000A,

			/// <summary>
			/// Sets the keyboard repeat-speed setting. The uiParam parameter must specify a value in the range from 0 (approximately 2.5
			/// repetitions per second) through 31 (approximately 30 repetitions per second). The actual repeat rates are hardware-dependent
			/// and may vary from a linear scale by as much as 20%. If uiParam is greater than 31, the parameter is set to 31.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set, true)]
			SPI_SETKEYBOARDSPEED = 0x000B,

			/// <summary>Not implemented.</summary>
			SPI_LANGDRIVER = 0x000C,

			/// <summary>
			/// Sets or retrieves the width, in pixels, of an icon cell. The system uses this rectangle to arrange icons in large icon view.
			/// To set this value, set uiParam to the new value and set pvParam to null. You cannot set this value to less than SM_CXICON. To
			/// retrieve this value, pvParam must point to an integer that receives the current value.
			/// </summary>
			[SPCorrespondingType(typeof(int), CorrepsondingAction.Set, false)]
			SPI_ICONHORIZONTALSPACING = 0x000D,

			/// <summary>
			/// Retrieves the screen saver time-out value, in seconds. The pvParam parameter must point to an integer variable that receives
			/// the value.
			/// </summary>
			[SPCorrespondingType(typeof(int), CorrepsondingAction.Get, false)]
			SPI_GETSCREENSAVETIMEOUT = 0x000E,

			/// <summary>
			/// Sets the screen saver time-out value to the value of the uiParam parameter. This value is the amount of time, in seconds,
			/// that the system must be idle before the screen saver activates.
			/// </summary>
			[SPCorrespondingType(typeof(int), CorrepsondingAction.Set, true)]
			SPI_SETSCREENSAVETIMEOUT = 0x000F,

			/// <summary>
			/// Determines whether screen saving is enabled. The pvParam parameter must point to a bool variable that receives TRUE if screen
			/// saving is enabled, or FALSE otherwise.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get, false)]
			SPI_GETSCREENSAVEACTIVE = 0x0010,

			/// <summary>
			/// Sets the state of the screen saver. The uiParam parameter specifies TRUE to activate screen saving, or FALSE to deactivate it.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETSCREENSAVEACTIVE = 0x0011,

			/// <summary>
			/// Retrieves the current granularity value of the desktop sizing grid. The pvParam parameter must point to an integer variable
			/// that receives the granularity.
			/// </summary>
			[SPCorrespondingType(typeof(int), CorrepsondingAction.Get, false)]
			SPI_GETGRIDGRANULARITY = 0x0012,

			/// <summary>Sets the granularity of the desktop sizing grid to the value of the uiParam parameter.</summary>
			[SPCorrespondingType(typeof(int), CorrepsondingAction.Set, true)]
			SPI_SETGRIDGRANULARITY = 0x0013,

			/// <summary>
			/// Sets the desktop wallpaper. The value of the pvParam parameter determines the new wallpaper. To specify a wallpaper bitmap,
			/// set pvParam to point to a null-terminated string containing the name of a bitmap file. Setting pvParam to "" removes the
			/// wallpaper. Setting pvParam to SETWALLPAPER_DEFAULT or null reverts to the default wallpaper.
			/// </summary>
			[SPCorrespondingType(typeof(string), CorrepsondingAction.Set, false)]
			SPI_SETDESKWALLPAPER = 0x0014,

			/// <summary>Sets the current desktop pattern by causing Windows to read the Pattern= setting from the WIN.INI file.</summary>
			[SPCorrespondingType(typeof(string), CorrepsondingAction.Set, false)]
			SPI_SETDESKPATTERN = 0x0015,

			/// <summary>
			/// Retrieves the keyboard repeat-delay setting, which is a value in the range from 0 (approximately 250 ms delay) through 3
			/// (approximately 1 second delay). The actual delay associated with each value may vary depending on the hardware. The pvParam
			/// parameter must point to an integer variable that receives the setting.
			/// </summary>
			[SPCorrespondingType(typeof(int), CorrepsondingAction.Get, false)]
			SPI_GETKEYBOARDDELAY = 0x0016,

			/// <summary>
			/// Sets the keyboard repeat-delay setting. The uiParam parameter must specify 0, 1, 2, or 3, where zero sets the shortest delay
			/// (approximately 250
			/// ms) and 3 sets the longest delay (approximately 1 second). The actual delay associated with each value may vary depending on
			/// the hardware.
			/// </summary>
			[SPCorrespondingType(typeof(int), CorrepsondingAction.Set, true)]
			SPI_SETKEYBOARDDELAY = 0x0017,

			/// <summary>
			/// Sets or retrieves the height, in pixels, of an icon cell. To set this value, set uiParam to the new value and set pvParam to
			/// null. You cannot set this value to less than SM_CYICON. To retrieve this value, pvParam must point to an integer that
			/// receives the current value.
			/// </summary>
			[SPCorrespondingType(typeof(int), CorrepsondingAction.Set, false)]
			SPI_ICONVERTICALSPACING = 0x0018,

			/// <summary>
			/// Determines whether icon-title wrapping is enabled. The pvParam parameter must point to a bool variable that receives TRUE if
			/// enabled, or FALSE otherwise.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETICONTITLEWRAP = 0x0019,

			/// <summary>Turns icon-title wrapping on or off. The uiParam parameter specifies TRUE for on, or FALSE for off.</summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETICONTITLEWRAP = 0x001A,

			/// <summary>
			/// Determines whether pop-up menus are left-aligned or right-aligned, relative to the corresponding menu-bar item. The pvParam
			/// parameter must point to a bool variable that receives TRUE if left-aligned, or FALSE otherwise.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETMENUDROPALIGNMENT = 0x001B,

			/// <summary>
			/// Sets the alignment value of pop-up menus. The uiParam parameter specifies TRUE for right alignment, or FALSE for left alignment.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETMENUDROPALIGNMENT = 0x001C,

			/// <summary>
			/// Sets the width of the double-click rectangle to the value of the uiParam parameter. The double-click rectangle is the
			/// rectangle within which the second click of a double-click must fall for it to be registered as a double-click. To retrieve
			/// the width of the double-click rectangle, call GetSystemMetrics with the SM_CXDOUBLECLK flag.
			/// </summary>
			[SPCorrespondingType(typeof(int), CorrepsondingAction.Set, true)]
			SPI_SETDOUBLECLKWIDTH = 0x001D,

			/// <summary>
			/// Sets the height of the double-click rectangle to the value of the uiParam parameter. The double-click rectangle is the
			/// rectangle within which the second click of a double-click must fall for it to be registered as a double-click. To retrieve
			/// the height of the double-click rectangle, call GetSystemMetrics with the SM_CYDOUBLECLK flag.
			/// </summary>
			[SPCorrespondingType(typeof(int), CorrepsondingAction.Set, true)]
			SPI_SETDOUBLECLKHEIGHT = 0x001E,

			/// <summary>
			/// Retrieves the logical font information for the current icon-title font. The uiParam parameter specifies the size of a LOGFONT
			/// structure, and the pvParam parameter must point to the LOGFONT structure to fill in.
			/// </summary>
			[SPCorrespondingType(typeof(LOGFONT), CorrepsondingAction.Get)]
			SPI_GETICONTITLELOGFONT = 0x001F,

			/// <summary>
			/// Sets the double-click time for the mouse to the value of the uiParam parameter. The double-click time is the maximum number
			/// of milliseconds that can occur between the first and second clicks of a double-click. You can also call the
			/// SetDoubleClickTime function to set the double-click time. To get the current double-click time, call the GetDoubleClickTime function.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set, true)]
			SPI_SETDOUBLECLICKTIME = 0x0020,

			/// <summary>
			/// Swaps or restores the meaning of the left and right mouse buttons. The uiParam parameter specifies TRUE to swap the meanings
			/// of the buttons, or FALSE to restore their original meanings.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETMOUSEBUTTONSWAP = 0x0021,

			/// <summary>
			/// Sets the font that is used for icon titles. The uiParam parameter specifies the size of a LOGFONT structure, and the pvParam
			/// parameter must point to a LOGFONT structure.
			/// </summary>
			[SPCorrespondingType(typeof(LOGFONT), CorrepsondingAction.Set)]
			SPI_SETICONTITLELOGFONT = 0x0022,

			/// <summary>
			/// This flag is obsolete. Previous versions of the system use this flag to determine whether ALT+TAB fast task switching is
			/// enabled. For Windows 95, Windows 98, and Windows NT version 4.0 and later, fast task switching is always enabled.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get), Obsolete]
			SPI_GETFASTTASKSWITCH = 0x0023,

			/// <summary>
			/// This flag is obsolete. Previous versions of the system use this flag to enable or disable ALT+TAB fast task switching. For
			/// Windows 95, Windows 98, and Windows NT version 4.0 and later, fast task switching is always enabled.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set), Obsolete]
			SPI_SETFASTTASKSWITCH = 0x0024,

			/// <summary>
			/// Sets dragging of full windows either on or off. The uiParam parameter specifies TRUE for on, or FALSE for off. Windows 95:
			/// This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETDRAGFULLWINDOWS = 0x0025,

			/// <summary>
			/// Determines whether dragging of full windows is enabled. The pvParam parameter must point to a BOOL variable that receives
			/// TRUE if enabled, or FALSE otherwise. Windows 95: This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETDRAGFULLWINDOWS = 0x0026,

			/// <summary>
			/// Retrieves the metrics associated with the nonclient area of nonminimized windows. The pvParam parameter must point to a
			/// NONCLIENTMETRICS structure that receives the information. Set the cbSize member of this structure and the uiParam parameter
			/// to sizeof(NONCLIENTMETRICS).
			/// </summary>
			[SPCorrespondingType(typeof(NONCLIENTMETRICS), CorrepsondingAction.Get)]
			SPI_GETNONCLIENTMETRICS = 0x0029,

			/// <summary>
			/// Sets the metrics associated with the nonclient area of nonminimized windows. The pvParam parameter must point to a
			/// NONCLIENTMETRICS structure that contains the new parameters. Set the cbSize member of this structure and the uiParam
			/// parameter to sizeof(NONCLIENTMETRICS). Also, the lfHeight member of the LOGFONT structure must be a negative value.
			/// </summary>
			[SPCorrespondingType(typeof(NONCLIENTMETRICS), CorrepsondingAction.Set)]
			SPI_SETNONCLIENTMETRICS = 0x002A,

			/// <summary>
			/// Retrieves the metrics associated with minimized windows. The pvParam parameter must point to a MINIMIZEDMETRICS structure
			/// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(MINIMIZEDMETRICS).
			/// </summary>
			[SPCorrespondingType(typeof(MINIMIZEDMETRICS), CorrepsondingAction.Get)]
			SPI_GETMINIMIZEDMETRICS = 0x002B,

			/// <summary>
			/// Sets the metrics associated with minimized windows. The pvParam parameter must point to a MINIMIZEDMETRICS structure that
			/// contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(MINIMIZEDMETRICS).
			/// </summary>
			[SPCorrespondingType(typeof(MINIMIZEDMETRICS), CorrepsondingAction.Set)]
			SPI_SETMINIMIZEDMETRICS = 0x002C,

			/// <summary>
			/// Retrieves the metrics associated with icons. The pvParam parameter must point to an ICONMETRICS structure that receives the
			/// information. Set the cbSize member of this structure and the uiParam parameter to sizeof(ICONMETRICS).
			/// </summary>
			[SPCorrespondingType(typeof(ICONMETRICS), CorrepsondingAction.Get)]
			SPI_GETICONMETRICS = 0x002D,

			/// <summary>
			/// Sets the metrics associated with icons. The pvParam parameter must point to an ICONMETRICS structure that contains the new
			/// parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ICONMETRICS).
			/// </summary>
			[SPCorrespondingType(typeof(ICONMETRICS), CorrepsondingAction.Set)]
			SPI_SETICONMETRICS = 0x002E,

			/// <summary>
			/// Sets the size of the work area. The work area is the portion of the screen not obscured by the system taskbar or by
			/// application desktop toolbars. The pvParam parameter is a pointer to a RECT structure that specifies the new work area
			/// rectangle, expressed in virtual screen coordinates. In a system with multiple display monitors, the function sets the work
			/// area of the monitor that contains the specified rectangle.
			/// </summary>
			[SPCorrespondingType(typeof(RECT), CorrepsondingAction.Set)]
			SPI_SETWORKAREA = 0x002F,

			/// <summary>
			/// Retrieves the size of the work area on the primary display monitor. The work area is the portion of the screen not obscured
			/// by the system taskbar or by application desktop toolbars. The pvParam parameter must point to a RECT structure that receives
			/// the coordinates of the work area, expressed in virtual screen coordinates. To get the work area of a monitor other than the
			/// primary display monitor, call the GetMonitorInfo function.
			/// </summary>
			[SPCorrespondingType(typeof(RECT), CorrepsondingAction.Get)]
			SPI_GETWORKAREA = 0x0030,

			/// <summary>
			/// Windows Me/98/95: Pen windows is being loaded or unloaded. The uiParam parameter is TRUE when loading and FALSE when
			/// unloading pen windows. The pvParam parameter is null.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETPENWINDOWS = 0x0031,

			/// <summary>
			/// Retrieves information about the HighContrast accessibility feature. The pvParam parameter must point to a HIGHCONTRAST
			/// structure that receives the information. Set the cbSize member of this structure and the uiParam parameter to
			/// sizeof(HIGHCONTRAST). For a general discussion, see remarks. Windows NT: This value is not supported.
			/// </summary>
			/// <remarks>
			/// There is a difference between the High Contrast color scheme and the High Contrast Mode. The High Contrast color scheme
			/// changes the system colors to colors that have obvious contrast; you switch to this color scheme by using the Display Options
			/// in the control panel. The High Contrast Mode, which uses SPI_GETHIGHCONTRAST and SPI_SETHIGHCONTRAST, advises applications to
			/// modify their appearance for visually-impaired users. It involves such things as audible warning to users and customized color
			/// scheme (using the Accessibility Options in the control panel). For more information, see HIGHCONTRAST on MSDN. For more
			/// information on general accessibility features, see Accessibility on MSDN.
			/// </remarks>
			[SPCorrespondingType(typeof(HIGHCONTRAST), CorrepsondingAction.Get)]
			SPI_GETHIGHCONTRAST = 0x0042,

			/// <summary>
			/// Sets the parameters of the HighContrast accessibility feature. The pvParam parameter must point to a HIGHCONTRAST structure
			/// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(HIGHCONTRAST).
			/// Windows NT: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(HIGHCONTRAST), CorrepsondingAction.Set)]
			SPI_SETHIGHCONTRAST = 0x0043,

			/// <summary>
			/// Determines whether the user relies on the keyboard instead of the mouse, and wants applications to display keyboard
			/// interfaces that would otherwise be hidden. The pvParam parameter must point to a BOOL variable that receives TRUE if the user
			/// relies on the keyboard; or FALSE otherwise. Windows NT: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETKEYBOARDPREF = 0x0044,

			/// <summary>
			/// Sets the keyboard preference. The uiParam parameter specifies TRUE if the user relies on the keyboard instead of the mouse,
			/// and wants applications to display keyboard interfaces that would otherwise be hidden; uiParam is FALSE otherwise. Windows NT:
			/// This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETKEYBOARDPREF = 0x0045,

			/// <summary>
			/// Determines whether a screen reviewer utility is running. A screen reviewer utility directs textual information to an output
			/// device, such as a speech synthesizer or Braille display. When this flag is set, an application should provide textual
			/// information in situations where it would otherwise present the information graphically. The pvParam parameter is a pointer to
			/// a BOOL variable that receives TRUE if a screen reviewer utility is running, or FALSE otherwise. Windows NT: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETSCREENREADER = 0x0046,

			/// <summary>
			/// Determines whether a screen review utility is running. The uiParam parameter specifies TRUE for on, or FALSE for off. Windows
			/// NT: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETSCREENREADER = 0x0047,

			/// <summary>
			/// Retrieves the animation effects associated with user actions. The pvParam parameter must point to an ANIMATIONINFO structure
			/// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(ANIMATIONINFO).
			/// </summary>
			[SPCorrespondingType(typeof(ANIMATIONINFO), CorrepsondingAction.Get)]
			SPI_GETANIMATION = 0x0048,

			/// <summary>
			/// Sets the animation effects associated with user actions. The pvParam parameter must point to an ANIMATIONINFO structure that
			/// contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ANIMATIONINFO).
			/// </summary>
			[SPCorrespondingType(typeof(ANIMATIONINFO), CorrepsondingAction.Set)]
			SPI_SETANIMATION = 0x0049,

			/// <summary>
			/// Determines whether the font smoothing feature is enabled. This feature uses font antialiasing to make font curves appear
			/// smoother by painting pixels at different gray levels. The pvParam parameter must point to a BOOL variable that receives TRUE
			/// if the feature is enabled, or FALSE if it is not. Windows 95: This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETFONTSMOOTHING = 0x004A,

			/// <summary>
			/// Enables or disables the font smoothing feature, which uses font antialiasing to make font curves appear smoother by painting
			/// pixels at different gray levels. To enable the feature, set the uiParam parameter to TRUE. To disable the feature, set
			/// uiParam to FALSE. Windows 95: This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETFONTSMOOTHING = 0x004B,

			/// <summary>
			/// Sets the width, in pixels, of the rectangle used to detect the start of a drag operation. Set uiParam to the new value. To
			/// retrieve the drag width, call GetSystemMetrics with the SM_CXDRAG flag.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set, true)]
			SPI_SETDRAGWIDTH = 0x004C,

			/// <summary>
			/// Sets the height, in pixels, of the rectangle used to detect the start of a drag operation. Set uiParam to the new value. To
			/// retrieve the drag height, call GetSystemMetrics with the SM_CYDRAG flag.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set, true)]
			SPI_SETDRAGHEIGHT = 0x004D,

			/// <summary>Used internally; applications should not use this value.</summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETHANDHELD = 0x004E,

			/// <summary>
			/// Retrieves the time-out value for the low-power phase of screen saving. The pvParam parameter must point to an integer
			/// variable that receives the value. This flag is supported for 32-bit applications only. Windows NT, Windows Me/98: This flag
			/// is supported for 16-bit and 32-bit applications. Windows 95: This flag is supported for 16-bit applications only.
			/// </summary>
			[SPCorrespondingType(typeof(int), CorrepsondingAction.Get)]
			SPI_GETLOWPOWERTIMEOUT = 0x004F,

			/// <summary>
			/// Retrieves the time-out value for the power-off phase of screen saving. The pvParam parameter must point to an integer
			/// variable that receives the value. This flag is supported for 32-bit applications only. Windows NT, Windows Me/98: This flag
			/// is supported for 16-bit and 32-bit applications. Windows 95: This flag is supported for 16-bit applications only.
			/// </summary>
			[SPCorrespondingType(typeof(int), CorrepsondingAction.Get)]
			SPI_GETPOWEROFFTIMEOUT = 0x0050,

			/// <summary>
			/// Sets the time-out value, in seconds, for the low-power phase of screen saving. The uiParam parameter specifies the new value.
			/// The pvParam parameter must be null. This flag is supported for 32-bit applications only. Windows NT, Windows Me/98: This flag
			/// is supported for 16-bit and 32-bit applications. Windows 95: This flag is supported for 16-bit applications only.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set, true)]
			SPI_SETLOWPOWERTIMEOUT = 0x0051,

			/// <summary>
			/// Sets the time-out value, in seconds, for the power-off phase of screen saving. The uiParam parameter specifies the new value.
			/// The pvParam parameter must be null. This flag is supported for 32-bit applications only. Windows NT, Windows Me/98: This flag
			/// is supported for 16-bit and 32-bit applications. Windows 95: This flag is supported for 16-bit applications only.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set, true)]
			SPI_SETPOWEROFFTIMEOUT = 0x0052,

			/// <summary>
			/// Determines whether the low-power phase of screen saving is enabled. The pvParam parameter must point to a BOOL variable that
			/// receives TRUE if enabled, or FALSE if disabled. This flag is supported for 32-bit applications only. Windows NT, Windows
			/// Me/98: This flag is supported for 16-bit and 32-bit applications. Windows 95: This flag is supported for 16-bit applications only.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETLOWPOWERACTIVE = 0x0053,

			/// <summary>
			/// Determines whether the power-off phase of screen saving is enabled. The pvParam parameter must point to a BOOL variable that
			/// receives TRUE if enabled, or FALSE if disabled. This flag is supported for 32-bit applications only. Windows NT, Windows
			/// Me/98: This flag is supported for 16-bit and 32-bit applications. Windows 95: This flag is supported for 16-bit applications only.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETPOWEROFFACTIVE = 0x0054,

			/// <summary>
			/// Activates or deactivates the low-power phase of screen saving. Set uiParam to 1 to activate, or zero to deactivate. The
			/// pvParam parameter must be null. This flag is supported for 32-bit applications only. Windows NT, Windows Me/98: This flag is
			/// supported for 16-bit and 32-bit applications. Windows 95: This flag is supported for 16-bit applications only.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETLOWPOWERACTIVE = 0x0055,

			/// <summary>
			/// Activates or deactivates the power-off phase of screen saving. Set uiParam to 1 to activate, or zero to deactivate. The
			/// pvParam parameter must be null. This flag is supported for 32-bit applications only. Windows NT, Windows Me/98: This flag is
			/// supported for 16-bit and 32-bit applications. Windows 95: This flag is supported for 16-bit applications only.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETPOWEROFFACTIVE = 0x0056,

			/// <summary>Reloads the system cursors. Set the uiParam parameter to zero and the pvParam parameter to null.</summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set, true)]
			SPI_SETCURSORS = 0x0057,

			/// <summary>Reloads the system icons. Set the uiParam parameter to zero and the pvParam parameter to null.</summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set, true)]
			SPI_SETICONS = 0x0058,

			/// <summary>
			/// Retrieves the input locale identifier for the system default input language. The pvParam parameter must point to an HKL
			/// variable that receives this value. For more information, see Languages, Locales, and Keyboard Layouts on MSDN.
			/// </summary>
			[SPCorrespondingType(typeof(IntPtr), CorrepsondingAction.Get)]
			SPI_GETDEFAULTINPUTLANG = 0x0059,

			/// <summary>
			/// Sets the default input language for the system shell and applications. The specified language must be displayable using the
			/// current system character set. The pvParam parameter must point to an HKL variable that contains the input locale identifier
			/// for the default language. For more information, see Languages, Locales, and Keyboard Layouts on MSDN.
			/// </summary>
			[SPCorrespondingType(typeof(IntPtr), CorrepsondingAction.Set)]
			SPI_SETDEFAULTINPUTLANG = 0x005A,

			/// <summary>
			/// Sets the hot key set for switching between input languages. The uiParam and pvParam parameters are not used. The value sets
			/// the shortcut keys in the keyboard property sheets by reading the registry again. The registry must be set before this flag is
			/// used. the path in the registry is \HKEY_CURRENT_USER\keyboard layout\toggle. Valid values are "1" = ALT+SHIFT, "2" =
			/// CTRL+SHIFT, and "3" = none.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set, true)]
			SPI_SETLANGTOGGLE = 0x005B,

			/// <summary>
			/// Windows 95: Determines whether the Windows extension, Windows Plus!, is installed. Set the uiParam parameter to 1. The
			/// pvParam parameter is not used. The function returns TRUE if the extension is installed, or FALSE if it is not.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETWINDOWSEXTENSION = 0x005C,

			/// <summary>
			/// Enables or disables the Mouse Trails feature, which improves the visibility of mouse cursor movements by briefly showing a
			/// trail of cursors and quickly erasing them. To disable the feature, set the uiParam parameter to zero or 1. To enable the
			/// feature, set uiParam to a value greater than 1 to indicate the number of cursors drawn in the trail. Windows 2000/NT: This
			/// value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set, true)]
			SPI_SETMOUSETRAILS = 0x005D,

			/// <summary>
			/// Determines whether the Mouse Trails feature is enabled. This feature improves the visibility of mouse cursor movements by
			/// briefly showing a trail of cursors and quickly erasing them. The pvParam parameter must point to an integer variable that
			/// receives a value. If the value is zero or 1, the feature is disabled. If the value is greater than 1, the feature is enabled
			/// and the value indicates the number of cursors drawn in the trail. The uiParam parameter is not used. Windows 2000/NT: This
			/// value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETMOUSETRAILS = 0x005E,

			/// <summary>Windows Me/98: Used internally; applications should not use this flag.</summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETSCREENSAVERRUNNING = 0x0061,

			/// <summary>Same as SPI_SETSCREENSAVERRUNNING.</summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SCREENSAVERRUNNING = SPI_SETSCREENSAVERRUNNING,

			/// <summary>
			/// Retrieves information about the FilterKeys accessibility feature. The pvParam parameter must point to a FILTERKEYS structure
			/// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(FILTERKEYS).
			/// </summary>
			[SPCorrespondingType(typeof(FILTERKEYS), CorrepsondingAction.Get)]
			SPI_GETFILTERKEYS = 0x0032,

			/// <summary>
			/// Sets the parameters of the FilterKeys accessibility feature. The pvParam parameter must point to a FILTERKEYS structure that
			/// contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(FILTERKEYS).
			/// </summary>
			[SPCorrespondingType(typeof(FILTERKEYS), CorrepsondingAction.Set)]
			SPI_SETFILTERKEYS = 0x0033,

			/// <summary>
			/// Retrieves information about the ToggleKeys accessibility feature. The pvParam parameter must point to a TOGGLEKEYS structure
			/// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(TOGGLEKEYS).
			/// </summary>
			[SPCorrespondingType(typeof(TOGGLEKEYS), CorrepsondingAction.Get)]
			SPI_GETTOGGLEKEYS = 0x0034,

			/// <summary>
			/// Sets the parameters of the ToggleKeys accessibility feature. The pvParam parameter must point to a TOGGLEKEYS structure that
			/// contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(TOGGLEKEYS).
			/// </summary>
			[SPCorrespondingType(typeof(TOGGLEKEYS), CorrepsondingAction.Set)]
			SPI_SETTOGGLEKEYS = 0x0035,

			/// <summary>
			/// Retrieves information about the MouseKeys accessibility feature. The pvParam parameter must point to a MOUSEKEYS structure
			/// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(MOUSEKEYS).
			/// </summary>
			[SPCorrespondingType(typeof(MOUSEKEYS), CorrepsondingAction.Get)]
			SPI_GETMOUSEKEYS = 0x0036,

			/// <summary>
			/// Sets the parameters of the MouseKeys accessibility feature. The pvParam parameter must point to a MOUSEKEYS structure that
			/// contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(MOUSEKEYS).
			/// </summary>
			[SPCorrespondingType(typeof(MOUSEKEYS), CorrepsondingAction.Set)]
			SPI_SETMOUSEKEYS = 0x0037,

			/// <summary>
			/// Determines whether the Show Sounds accessibility flag is on or off. If it is on, the user requires an application to present
			/// information visually in situations where it would otherwise present the information only in audible form. The pvParam
			/// parameter must point to a BOOL variable that receives TRUE if the feature is on, or FALSE if it is off. Using this value is
			/// equivalent to calling GetSystemMetrics (SM_SHOWSOUNDS). That is the recommended call.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETSHOWSOUNDS = 0x0038,

			/// <summary>
			/// Sets the parameters of the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY structure
			/// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
			/// </summary>
			[SPCorrespondingType(typeof(SOUNDSENTRY), CorrepsondingAction.Set)]
			SPI_SETSHOWSOUNDS = 0x0039,

			/// <summary>
			/// Retrieves information about the StickyKeys accessibility feature. The pvParam parameter must point to a STICKYKEYS structure
			/// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(STICKYKEYS).
			/// </summary>
			[SPCorrespondingType(typeof(STICKYKEYS), CorrepsondingAction.Get)]
			SPI_GETSTICKYKEYS = 0x003A,

			/// <summary>
			/// Sets the parameters of the StickyKeys accessibility feature. The pvParam parameter must point to a STICKYKEYS structure that
			/// contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(STICKYKEYS).
			/// </summary>
			[SPCorrespondingType(typeof(STICKYKEYS), CorrepsondingAction.Set)]
			SPI_SETSTICKYKEYS = 0x003B,

			/// <summary>
			/// Retrieves information about the time-out period associated with the accessibility features. The pvParam parameter must point
			/// to an ACCESSTIMEOUT structure that receives the information. Set the cbSize member of this structure and the uiParam
			/// parameter to sizeof(ACCESSTIMEOUT).
			/// </summary>
			[SPCorrespondingType(typeof(ACCESSTIMEOUT), CorrepsondingAction.Get)]
			SPI_GETACCESSTIMEOUT = 0x003C,

			/// <summary>
			/// Sets the time-out period associated with the accessibility features. The pvParam parameter must point to an ACCESSTIMEOUT
			/// structure that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ACCESSTIMEOUT).
			/// </summary>
			[SPCorrespondingType(typeof(ACCESSTIMEOUT), CorrepsondingAction.Set)]
			SPI_SETACCESSTIMEOUT = 0x003D,

			//#if(WINVER >= 0x0400)
			/// <summary>
			/// Windows Me/98/95: Retrieves information about the SerialKeys accessibility feature. The pvParam parameter must point to a
			/// SERIALKEYS structure that receives the information. Set the cbSize member of this structure and the uiParam parameter to
			/// sizeof(SERIALKEYS). Windows Server 2003, Windows XP/2000/NT: Not supported. The user controls this feature through the
			/// control panel.
			/// </summary>
			[SPCorrespondingType(typeof(SERIALKEYS), CorrepsondingAction.Get)]
			SPI_GETSERIALKEYS = 0x003E,

			/// <summary>
			/// Windows Me/98/95: Sets the parameters of the SerialKeys accessibility feature. The pvParam parameter must point to a
			/// SERIALKEYS structure that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to
			/// sizeof(SERIALKEYS). Windows Server 2003, Windows XP/2000/NT: Not supported. The user controls this feature through the
			/// control panel.
			/// </summary>
			[SPCorrespondingType(typeof(SERIALKEYS), CorrepsondingAction.Set)]
			SPI_SETSERIALKEYS = 0x003F,

			/// <summary>
			/// Retrieves information about the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY
			/// structure that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
			/// </summary>
			[SPCorrespondingType(typeof(SOUNDSENTRY), CorrepsondingAction.Get)]
			SPI_GETSOUNDSENTRY = 0x0040,

			/// <summary>
			/// Sets the parameters of the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY structure
			/// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
			/// </summary>
			[SPCorrespondingType(typeof(SOUNDSENTRY), CorrepsondingAction.Set)]
			SPI_SETSOUNDSENTRY = 0x0041,

			/// <summary>
			/// Determines whether the snap-to-default-button feature is enabled. If enabled, the mouse cursor automatically moves to the
			/// default button, such as OK or Apply, of a dialog box. The pvParam parameter must point to a BOOL variable that receives TRUE
			/// if the feature is on, or FALSE if it is off. Windows 95: Not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETSNAPTODEFBUTTON = 0x005F,

			/// <summary>
			/// Enables or disables the snap-to-default-button feature. If enabled, the mouse cursor automatically moves to the default
			/// button, such as OK or Apply, of a dialog box. Set the uiParam parameter to TRUE to enable the feature, or FALSE to disable
			/// it. Applications should use the ShowWindow function when displaying a dialog box so the dialog manager can position the mouse
			/// cursor. Windows 95: Not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETSNAPTODEFBUTTON = 0x0060,

			/// <summary>
			/// Retrieves the width, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent to generate a
			/// WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the width. Windows 95: Not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETMOUSEHOVERWIDTH = 0x0062,

			/// <summary>
			/// Retrieves the width, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent to generate a
			/// WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the width. Windows 95: Not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETMOUSEHOVERWIDTH = 0x0063,

			/// <summary>
			/// Retrieves the height, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent to generate
			/// a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the height. Windows 95: Not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETMOUSEHOVERHEIGHT = 0x0064,

			/// <summary>
			/// Sets the height, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent to generate a
			/// WM_MOUSEHOVER message. Set the uiParam parameter to the new height. Windows 95: Not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set, true)]
			SPI_SETMOUSEHOVERHEIGHT = 0x0065,

			/// <summary>
			/// Retrieves the time, in milliseconds, that the mouse pointer has to stay in the hover rectangle for TrackMouseEvent to
			/// generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the time. Windows 95: Not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETMOUSEHOVERTIME = 0x0066,

			/// <summary>
			/// Sets the time, in milliseconds, that the mouse pointer has to stay in the hover rectangle for TrackMouseEvent to generate a
			/// WM_MOUSEHOVER message. This is used only if you pass HOVER_DEFAULT in the dwHoverTime parameter in the call to
			/// TrackMouseEvent. Set the uiParam parameter to the new time. Windows 95: Not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set, true)]
			SPI_SETMOUSEHOVERTIME = 0x0067,

			/// <summary>
			/// Retrieves the number of lines to scroll when the mouse wheel is rotated. The pvParam parameter must point to a UINT variable
			/// that receives the number of lines. The default value is 3. Windows 95: Not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETWHEELSCROLLLINES = 0x0068,

			/// <summary>
			/// Sets the number of lines to scroll when the mouse wheel is rotated. The number of lines is set from the uiParam parameter.
			/// The number of lines is the suggested number of lines to scroll when the mouse wheel is rolled without using modifier keys. If
			/// the number is 0, then no scrolling should occur. If the number of lines to scroll is greater than the number of lines
			/// viewable, and in particular if it is WHEEL_PAGESCROLL (#defined as UINT_MAX), the scroll operation should be interpreted as
			/// clicking once in the page down or page up regions of the scroll bar. Windows 95: Not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set, true)]
			SPI_SETWHEELSCROLLLINES = 0x0069,

			/// <summary>
			/// Retrieves the time, in milliseconds, that the system waits before displaying a shortcut menu when the mouse cursor is over a
			/// submenu item. The pvParam parameter must point to a DWORD variable that receives the time of the delay. Windows 95: Not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETMENUSHOWDELAY = 0x006A,

			/// <summary>
			/// Sets uiParam to the time, in milliseconds, that the system waits before displaying a shortcut menu when the mouse cursor is
			/// over a submenu item. Windows 95: Not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set, true)]
			SPI_SETMENUSHOWDELAY = 0x006B,

			/// <summary>
			/// Determines whether the IME status window is visible (on a per-user basis). The pvParam parameter must point to a BOOL
			/// variable that receives TRUE if the status window is visible, or FALSE if it is not. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETSHOWIMEUI = 0x006E,

			/// <summary>
			/// Sets whether the IME status window is visible or not on a per-user basis. The uiParam parameter specifies TRUE for on or
			/// FALSE for off. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETSHOWIMEUI = 0x006F,

			/// <summary>
			/// Retrieves the current mouse speed. The mouse speed determines how far the pointer will move based on the distance the mouse
			/// moves. The pvParam parameter must point to an integer that receives a value which ranges between 1 (slowest) and 20
			/// (fastest). A value of 10 is the default. The value can be set by an end user using the mouse control panel application or by
			/// an application using SPI_SETMOUSESPEED. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETMOUSESPEED = 0x0070,

			/// <summary>
			/// Sets the current mouse speed. The pvParam parameter is an integer between 1 (slowest) and 20 (fastest). A value of 10 is the
			/// default. This value is typically set using the mouse control panel application. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETMOUSESPEED = 0x0071,

			/// <summary>
			/// Determines whether a screen saver is currently running on the window station of the calling process. The pvParam parameter
			/// must point to a BOOL variable that receives TRUE if a screen saver is currently running, or FALSE otherwise. Note that only
			/// the interactive window station, "WinSta0", can have a screen saver running. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETSCREENSAVERRUNNING = 0x0072,

			/// <summary>
			/// Retrieves the full path of the bitmap file for the desktop wallpaper. The pvParam parameter must point to a buffer that
			/// receives a null-terminated path string. Set the uiParam parameter to the size, in characters, of the pvParam buffer. The
			/// returned string will not exceed MAX_PATH characters. If there is no desktop wallpaper, the returned string is empty. Windows
			/// NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(string), CorrepsondingAction.Get)]
			SPI_GETDESKWALLPAPER = 0x0073,

			/// <summary>
			/// Determines whether audio descriptions are enabled or disabled. The pvParam parameter is a pointer to an AUDIODESCRIPTION
			/// structure. Set the cbSize member of this structure and the uiParam parameter to sizeof(AUDIODESCRIPTION).
			/// <para>
			/// While it is possible for users who have visual impairments to hear the audio in video content, there is a lot of action in
			/// video that does not have corresponding audio. Specific audio description of what is happening in a video helps these users
			/// understand the content better. This flag enables you to determine whether audio descriptions have been enabled and in which language.
			/// </para>
			/// <para>Windows Server 2003 and Windows XP/2000: This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(AUDIODESCRIPTION), CorrepsondingAction.Get)]
			SPI_GETAUDIODESCRIPTION = 0x0074,

			/// <summary>
			/// Turns the audio descriptions feature on or off. The pvParam parameter is a pointer to an AUDIODESCRIPTION structure.
			/// <para>
			/// While it is possible for users who are visually impaired to hear the audio in video content, there is a lot of action in
			/// video that does not have corresponding audio. Specific audio description of what is happening in a video helps these users
			/// understand the content better. This flag enables you to enable or disable audio descriptions in the languages they are
			/// provided in.
			/// </para>
			/// <para>Windows Server 2003 and Windows XP/2000: This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(AUDIODESCRIPTION), CorrepsondingAction.Set)]
			SPI_SETAUDIODESCRIPTION = 0x0075,

			/// <summary>
			/// Determines whether the screen saver requires a password to display the Windows desktop. The pvParam parameter must point to a
			/// BOOL variable that receives TRUE if the screen saver requires a password, or FALSE otherwise. The uiParam parameter is
			/// ignored. Windows Server 2003 and Windows XP/2000: This parameter is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETSCREENSAVESECURE = 0x0076,

			/// <summary>
			/// Sets whether the screen saver requires the user to enter a password to display the Windows desktop. The uiParam parameter is
			/// a BOOL variable. The pvParam parameter is ignored. Set uiParam to TRUE to require a password, or FALSE to not require a password.
			/// <para>If the machine has entered power saving mode or system lock state, an ERROR_OPERATION_IN_PROGRESS exception occurs.</para>
			/// <para>Windows Server 2003 and Windows XP/2000: This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETSCREENSAVESECURE = 0x0077,

			/// <summary>
			/// Retrieves the number of milliseconds that a thread can go without dispatching a message before the system considers it
			/// unresponsive. The pvParam parameter must point to an integer variable that receives the value.
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETHUNGAPPTIMEOUT = 0x0078,

			/// <summary>
			/// Sets the hung application time-out to the value of the uiParam parameter. This value is the number of milliseconds that a
			/// thread can go without dispatching a message before the system considers it unresponsive.
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set, true)]
			SPI_SETHUNGAPPTIMEOUT = 0x0079,

			/// <summary>
			/// Retrieves the number of milliseconds that the system waits before terminating an application that does not respond to a
			/// shutdown request. The pvParam parameter must point to an integer variable that receives the value.
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETWAITTOKILLTIMEOUT = 0x007A,

			/// <summary>
			/// Sets the application shutdown request time-out to the value of the uiParam parameter. This value is the number of
			/// milliseconds that the system waits before terminating an application that does not respond to a shutdown request.
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set, true)]
			SPI_SETWAITTOKILLTIMEOUT = 0x007B,

			/// <summary>
			/// Retrieves the number of milliseconds that the service control manager waits before terminating a service that does not
			/// respond to a shutdown request. The pvParam parameter must point to an integer variable that receives the value.
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETWAITTOKILLSERVICETIMEOUT = 0x007C,

			/// <summary>
			/// Sets the service shutdown request time-out to the value of the uiParam parameter. This value is the number of milliseconds
			/// that the system waits before terminating a service that does not respond to a shutdown request.
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set, true)]
			SPI_SETWAITTOKILLSERVICETIMEOUT = 0x007D,

			/// <summary>
			/// Retrieves the threshold in pixels where docking behavior is triggered by using a mouse to drag a window to the edge of a
			/// monitor or monitor array. The default threshold is 1. The pvParam parameter must point to a DWORD variable that receives the value.
			/// <para>Use SPI_GETWINARRANGING to determine whether this behavior is enabled.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETMOUSEDOCKTHRESHOLD = 0x007E,

			/// <summary>
			/// Sets the threshold in pixels where docking behavior is triggered by using a mouse to drag a window to the edge of a monitor
			/// or monitor array. The default threshold is 1. The pvParam parameter must point to a DWORD variable that contains the new value.
			/// <para>SPI_GETWINARRANGING must be TRUE to enable this behavior.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETMOUSEDOCKTHRESHOLD = 0x007F,

			/// <summary>
			/// Retrieves the threshold in pixels where docking behavior is triggered by using a pen to drag a window to the edge of a
			/// monitor or monitor array. The default is 30.
			/// <para>Use <c>SPI_GETWINARRANGING</c> to determine whether this behavior is enabled.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETPENDOCKTHRESHOLD = 0x0080,

			/// <summary>
			/// Sets the threshold in pixels where docking behavior is triggered by using a pen to drag a window to the edge of a monitor or
			/// monitor array. The default threshold is 30. The pvParam parameter must point to a DWORD variable that contains the new value.
			/// <para><c>SPI_GETWINARRANGING</c> must be TRUE to enable this behavior.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETPENDOCKTHRESHOLD = 0x0081,

			/// <summary>
			/// Determines whether window arrangement is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE if
			/// enabled, or FALSE otherwise.
			/// <para>
			/// Window arrangement reduces the number of mouse, pen, or touch interactions needed to move and size top-level windows by
			/// simplifying the default behavior of a window when it is dragged or sized.
			/// </para>
			/// <para>The following parameters retrieve individual window arrangement settings:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>SPI_GETDOCKMOVING</term>
			/// </item>
			/// <item>
			/// <term>SPI_GETMOUSEDOCKTHRESHOLD</term>
			/// </item>
			/// <item>
			/// <term>SPI_GETMOUSEDRAGOUTTHRESHOLD</term>
			/// </item>
			/// <item>
			/// <term>SPI_GETMOUSESIDEMOVETHRESHOLD</term>
			/// </item>
			/// <item>
			/// <term>SPI_GETPENDOCKTHRESHOLD</term>
			/// </item>
			/// <item>
			/// <term>SPI_GETPENDRAGOUTTHRESHOLD</term>
			/// </item>
			/// <item>
			/// <term>SPI_GETPENSIDEMOVETHRESHOLD</term>
			/// </item>
			/// <item>
			/// <term>SPI_GETSNAPSIZING</term>
			/// </item>
			/// </list>
			/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000: This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETWINARRANGING = 0x0082,

			/// <summary>
			/// Sets whether window arrangement is enabled. Set pvParam to TRUE for on or FALSE for off.
			/// <para>
			/// Window arrangement reduces the number of mouse, pen, or touch interactions needed to move and size top-level windows by
			/// simplifying the default behavior of a window when it is dragged or sized.
			/// </para>
			/// <para>The following parameters retrieve individual window arrangement settings:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>SPI_GETDOCKMOVING</term>
			/// </item>
			/// <item>
			/// <term>SPI_GETMOUSEDOCKTHRESHOLD</term>
			/// </item>
			/// <item>
			/// <term>SPI_GETMOUSEDRAGOUTTHRESHOLD</term>
			/// </item>
			/// <item>
			/// <term>SPI_GETMOUSESIDEMOVETHRESHOLD</term>
			/// </item>
			/// <item>
			/// <term>SPI_GETPENDOCKTHRESHOLD</term>
			/// </item>
			/// <item>
			/// <term>SPI_GETPENDRAGOUTTHRESHOLD</term>
			/// </item>
			/// <item>
			/// <term>SPI_GETPENSIDEMOVETHRESHOLD</term>
			/// </item>
			/// <item>
			/// <term>SPI_GETSNAPSIZING</term>
			/// </item>
			/// </list>
			/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000: This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETWINARRANGING = 0x0083,

			/// <summary>
			/// Retrieves the threshold in pixels where undocking behavior is triggered by using a mouse to drag a window from the edge of a
			/// monitor or a monitor array toward the center. The default threshold is 20.
			/// <para>Use <c>SPI_GETWINARRANGING</c> to determine whether this behavior is enabled.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETMOUSEDRAGOUTTHRESHOLD = 0x0084,

			/// <summary>
			/// Sets the threshold in pixels where undocking behavior is triggered by using a mouse to drag a window from the edge of a
			/// monitor or monitor array to its center. The default threshold is 20. The pvParam parameter must point to a DWORD variable
			/// that contains the new value.
			/// <para><c>SPI_GETWINARRANGING</c> must be TRUE to enable this behavior.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETMOUSEDRAGOUTTHRESHOLD = 0x0085,

			/// <summary>
			/// Retrieves the threshold in pixels where undocking behavior is triggered by using a pen to drag a window from the edge of a
			/// monitor or monitor array toward its center. The default threshold is 30.
			/// <para>Use <c>SPI_GETWINARRANGING</c> to determine whether this behavior is enabled.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETPENDRAGOUTTHRESHOLD = 0x0086,

			/// <summary>
			/// Sets the threshold in pixels where undocking behavior is triggered by using a pen to drag a window from the edge of a monitor
			/// or monitor array to its center. The default threshold is 30. The pvParam parameter must point to a DWORD variable that
			/// contains the new value.
			/// <para><c>SPI_GETWINARRANGING</c> must be TRUE to enable this behavior.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETPENDRAGOUTTHRESHOLD = 0x0087,

			/// <summary>
			/// Retrieves the threshold in pixels from the top of a monitor or a monitor array where a vertically maximized window is
			/// restored when dragged with the mouse. The default threshold is 50.
			/// <para>Use <c>SPI_GETWINARRANGING</c> to determine whether this behavior is enabled.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETMOUSESIDEMOVETHRESHOLD = 0x0088,

			/// <summary>
			/// Sets the threshold in pixels from the top of the monitor where a vertically maximized window is restored when dragged with
			/// the mouse. The default threshold is 50. The pvParam parameter must point to a DWORD variable that contains the new value.
			/// <para><c>SPI_GETWINARRANGING</c> must be TRUE to enable this behavior.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETMOUSESIDEMOVETHRESHOLD = 0x0089,

			/// <summary>
			/// Retrieves the threshold in pixels from the top of a monitor or monitor array where a vertically maximized window is restored
			/// when dragged with the mouse. The default threshold is 50.
			/// <para>Use <c>SPI_GETWINARRANGING</c> to determine whether this behavior is enabled.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETPENSIDEMOVETHRESHOLD = 0x008A,

			/// <summary>
			/// Sets the threshold in pixels from the top of the monitor where a vertically maximized window is restored when dragged with a
			/// pen. The default threshold is 50. The pvParam parameter must point to a DWORD variable that contains the new value.
			/// <para><c>SPI_GETWINARRANGING</c> must be TRUE to enable this behavior.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETPENSIDEMOVETHRESHOLD = 0x008B,

			/// <summary>
			/// Determines whether a maximized window is restored when its caption bar is dragged. The pvParam parameter must point to a BOOL
			/// variable that receives TRUE if enabled, or FALSE otherwise.
			/// <para>Use <c>SPI_GETWINARRANGING</c> to determine whether this behavior is enabled.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETDRAGFROMMAXIMIZE = 0x008C,

			/// <summary>
			/// Sets whether a maximized window is restored when its caption bar is dragged. Set pvParam to TRUE for on or FALSE for off.
			/// <para><c>SPI_GETWINARRANGING</c> must be TRUE to enable this behavior.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETDRAGFROMMAXIMIZE = 0x008D,

			/// <summary>
			/// Determines whether a window is vertically maximized when it is sized to the top or bottom of a monitor or monitor array. The
			/// pvParam parameter must point to a BOOL variable that receives TRUE if enabled, or FALSE otherwise.
			/// <para>Use <c>SPI_GETWINARRANGING</c> to determine whether this behavior is enabled.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETSNAPSIZING = 0x008E,

			/// <summary>
			/// Sets whether a window is vertically maximized when it is sized to the top or bottom of the monitor. Set pvParam to TRUE for
			/// on or FALSE for off.
			/// <para><c>SPI_GETWINARRANGING</c> must be TRUE to enable this behavior.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETSNAPSIZING = 0x008F,

			/// <summary>
			/// Determines whether a window is docked when it is moved to the top, left, or right edges of a monitor or monitor array. The
			/// pvParam parameter must point to a BOOL variable that receives TRUE if enabled, or FALSE otherwise.
			/// <para>Use <c>SPI_GETWINARRANGING</c> to determine whether this behavior is enabled.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETDOCKMOVING = 0x0090,

			/// <summary>
			/// Sets whether a window is docked when it is moved to the top, left, or right docking targets on a monitor or monitor array.
			/// Set pvParam to TRUE for on or FALSE for off.
			/// <para><c>SPI_GETWINARRANGING</c> must be TRUE to enable this behavior.</para>
			/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETDOCKMOVING = 0x0091,

			/// <summary>Undocumented</summary>
			SPI_GETTOUCHPREDICTIONPARAMETERS = 0x009C,

			/// <summary>Undocumented</summary>
			SPI_SETTOUCHPREDICTIONPARAMETERS = 0x009D,

			/// <summary>
			/// Retrieves a value that determines whether Windows 8 is displaying apps using the default scaling plateau for the hardware or
			/// going to the next higher plateau. This value is based on the current "Make everything on your screen bigger" setting, found
			/// in the Ease of Access section of PC
			/// settings: 1 is on, 0 is off.
			/// <para>
			/// Apps can provide text and image resources for each of several scaling plateaus: 100%, 140%, and 180%. Providing separate
			/// resources optimized for a particular scale avoids distortion due to resizing. Windows 8 determines the appropriate scaling
			/// plateau based on a number of factors, including screen size and pixel density. When "Make everything on your screen bigger"
			/// is selected (SPI_GETLOGICALDPIOVERRIDE returns a value of 1), Windows uses resources from the next higher plateau.For
			/// example, in the case of hardware that Windows determines should use a scale of SCALE_100_PERCENT, this override causes
			/// Windows to use the SCALE_140_PERCENT scale value, assuming that it does not violate other constraints.
			/// </para>
			/// <note type="note">You should not use this value.It might be altered or unavailable in subsequent versions of Windows.
			/// Instead, use the GetScaleFactorForDevice function or the DisplayProperties class to retrieve the preferred scaling
			/// factor.Desktop applications should use desktop logical DPI rather than scale factor.Desktop logical DPI can be retrieved
			/// through the GetDeviceCaps function.</note>
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETLOGICALDPIOVERRIDE = 0x009E,

			/// <summary>Do not use.</summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETLOGICALDPIOVERRIDE = 0x009F,

			/// <summary>Undocumented</summary>
			SPI_GETMENURECT = 0x00A2,

			/// <summary>Undocumented</summary>
			SPI_SETMENURECT = 0x00A3,

			/// <summary>
			/// Determines whether active window tracking (activating the window the mouse is on) is on or off. The pvParam parameter must
			/// point to a BOOL variable that receives TRUE for on, or FALSE for off. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETACTIVEWINDOWTRACKING = 0x1000,

			/// <summary>
			/// Sets active window tracking (activating the window the mouse is on) either on or off. Set pvParam to TRUE for on or FALSE for
			/// off. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETACTIVEWINDOWTRACKING = 0x1001,

			/// <summary>
			/// Determines whether the menu animation feature is enabled. This master switch must be on to enable menu animation effects. The
			/// pvParam parameter must point to a BOOL variable that receives TRUE if animation is enabled and FALSE if it is disabled. If
			/// animation is enabled, SPI_GETMENUFADE indicates whether menus use fade or slide animation. Windows NT, Windows 95: This value
			/// is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETMENUANIMATION = 0x1002,

			/// <summary>
			/// Enables or disables menu animation. This master switch must be on for any menu animation to occur. The pvParam parameter is a
			/// BOOL variable; set pvParam to TRUE to enable animation and FALSE to disable animation. If animation is enabled,
			/// SPI_GETMENUFADE indicates whether menus use fade or slide animation. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETMENUANIMATION = 0x1003,

			/// <summary>
			/// Determines whether the slide-open effect for combo boxes is enabled. The pvParam parameter must point to a BOOL variable that
			/// receives TRUE for enabled, or FALSE for disabled. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETCOMBOBOXANIMATION = 0x1004,

			/// <summary>
			/// Enables or disables the slide-open effect for combo boxes. Set the pvParam parameter to TRUE to enable the gradient effect,
			/// or FALSE to disable it. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETCOMBOBOXANIMATION = 0x1005,

			/// <summary>
			/// Determines whether the smooth-scrolling effect for list boxes is enabled. The pvParam parameter must point to a BOOL variable
			/// that receives TRUE for enabled, or FALSE for disabled. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETLISTBOXSMOOTHSCROLLING = 0x1006,

			/// <summary>
			/// Enables or disables the smooth-scrolling effect for list boxes. Set the pvParam parameter to TRUE to enable the
			/// smooth-scrolling effect, or FALSE to disable it. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETLISTBOXSMOOTHSCROLLING = 0x1007,

			/// <summary>
			/// Determines whether the gradient effect for window title bars is enabled. The pvParam parameter must point to a BOOL variable
			/// that receives TRUE for enabled, or FALSE for disabled. For more information about the gradient effect, see the GetSysColor
			/// function. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETGRADIENTCAPTIONS = 0x1008,

			/// <summary>
			/// Enables or disables the gradient effect for window title bars. Set the pvParam parameter to TRUE to enable it, or FALSE to
			/// disable it. The gradient effect is possible only if the system has a color depth of more than 256 colors. For more
			/// information about the gradient effect, see the GetSysColor function. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETGRADIENTCAPTIONS = 0x1009,

			/// <summary>
			/// Determines whether menu access keys are always underlined. The pvParam parameter must point to a BOOL variable that receives
			/// TRUE if menu access keys are always underlined, and FALSE if they are underlined only when the menu is activated by the
			/// keyboard. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETKEYBOARDCUES = 0x100A,

			/// <summary>
			/// Sets the underlining of menu access key letters. The pvParam parameter is a BOOL variable. Set pvParam to TRUE to always
			/// underline menu access keys, or FALSE to underline menu access keys only when the menu is activated from the keyboard. Windows
			/// NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETKEYBOARDCUES = 0x100B,

			/// <summary>Same as SPI_GETKEYBOARDCUES.</summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETMENUUNDERLINES = SPI_GETKEYBOARDCUES,

			/// <summary>Same as SPI_SETKEYBOARDCUES.</summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETMENUUNDERLINES = SPI_SETKEYBOARDCUES,

			/// <summary>
			/// Determines whether windows activated through active window tracking will be brought to the top. The pvParam parameter must
			/// point to a BOOL variable that receives TRUE for on, or FALSE for off. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETACTIVEWNDTRKZORDER = 0x100C,

			/// <summary>
			/// Determines whether or not windows activated through active window tracking should be brought to the top. Set pvParam to TRUE
			/// for on or FALSE for off. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETACTIVEWNDTRKZORDER = 0x100D,

			/// <summary>
			/// Determines whether hot tracking of user-interface elements, such as menu names on menu bars, is enabled. The pvParam
			/// parameter must point to a BOOL variable that receives TRUE for enabled, or FALSE for disabled. Hot tracking means that when
			/// the cursor moves over an item, it is highlighted but not selected. You can query this value to decide whether to use hot
			/// tracking in the user interface of your application. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETHOTTRACKING = 0x100E,

			/// <summary>
			/// Enables or disables hot tracking of user-interface elements such as menu names on menu bars. Set the pvParam parameter to
			/// TRUE to enable it, or FALSE to disable it. Hot-tracking means that when the cursor moves over an item, it is highlighted but
			/// not selected. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETHOTTRACKING = 0x100F,

			/// <summary>
			/// Determines whether menu fade animation is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE
			/// when fade animation is enabled and FALSE when it is disabled. If fade animation is disabled, menus use slide animation. This
			/// flag is ignored unless menu animation is enabled, which you can do using the SPI_SETMENUANIMATION flag. For more information,
			/// see AnimateWindow. Windows NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETMENUFADE = 0x1012,

			/// <summary>
			/// Enables or disables menu fade animation. Set pvParam to TRUE to enable the menu fade effect or FALSE to disable it. If fade
			/// animation is disabled, menus use slide animation. he The menu fade effect is possible only if the system has a color depth of
			/// more than 256 colors. This flag is ignored unless SPI_MENUANIMATION is also set. For more information, see AnimateWindow.
			/// Windows NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETMENUFADE = 0x1013,

			/// <summary>
			/// Determines whether the selection fade effect is enabled. The pvParam parameter must point to a BOOL variable that receives
			/// TRUE if enabled or FALSE if disabled. The selection fade effect causes the menu item selected by the user to remain on the
			/// screen briefly while fading out after the menu is dismissed. Windows NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETSELECTIONFADE = 0x1014,

			/// <summary>
			/// Set pvParam to TRUE to enable the selection fade effect or FALSE to disable it. The selection fade effect causes the menu
			/// item selected by the user to remain on the screen briefly while fading out after the menu is dismissed. The selection fade
			/// effect is possible only if the system has a color depth of more than 256 colors. Windows NT, Windows Me/98/95: This value is
			/// not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETSELECTIONFADE = 0x1015,

			/// <summary>
			/// Determines whether ToolTip animation is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE if
			/// enabled or FALSE if disabled. If ToolTip animation is enabled, SPI_GETTOOLTIPFADE indicates whether ToolTips use fade or
			/// slide animation. Windows NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETTOOLTIPANIMATION = 0x1016,

			/// <summary>
			/// Set pvParam to TRUE to enable ToolTip animation or FALSE to disable it. If enabled, you can use SPI_SETTOOLTIPFADE to specify
			/// fade or slide animation. Windows NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETTOOLTIPANIMATION = 0x1017,

			/// <summary>
			/// If SPI_SETTOOLTIPANIMATION is enabled, SPI_GETTOOLTIPFADE indicates whether ToolTip animation uses a fade effect or a slide
			/// effect. The pvParam parameter must point to a BOOL variable that receives TRUE for fade animation or FALSE for slide
			/// animation. For more information on slide and fade effects, see AnimateWindow. Windows NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETTOOLTIPFADE = 0x1018,

			/// <summary>
			/// If the SPI_SETTOOLTIPANIMATION flag is enabled, use SPI_SETTOOLTIPFADE to indicate whether ToolTip animation uses a fade
			/// effect or a slide effect. Set pvParam to TRUE for fade animation or FALSE for slide animation. The tooltip fade effect is
			/// possible only if the system has a color depth of more than 256 colors. For more information on the slide and fade effects,
			/// see the AnimateWindow function. Windows NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETTOOLTIPFADE = 0x1019,

			/// <summary>
			/// Determines whether the cursor has a shadow around it. The pvParam parameter must point to a BOOL variable that receives TRUE
			/// if the shadow is enabled, FALSE if it is disabled. This effect appears only if the system has a color depth of more than 256
			/// colors. Windows NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETCURSORSHADOW = 0x101A,

			/// <summary>
			/// Enables or disables a shadow around the cursor. The pvParam parameter is a BOOL variable. Set pvParam to TRUE to enable the
			/// shadow or FALSE to disable the shadow. This effect appears only if the system has a color depth of more than 256 colors.
			/// Windows NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETCURSORSHADOW = 0x101B,

			/// <summary>
			/// Retrieves the state of the Mouse Sonar feature. The pvParam parameter must point to a BOOL variable that receives TRUE if
			/// enabled or FALSE otherwise. For more information, see About Mouse Input on MSDN. Windows 2000/NT, Windows 98/95: This value
			/// is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETMOUSESONAR = 0x101C,

			/// <summary>
			/// Turns the Sonar accessibility feature on or off. This feature briefly shows several concentric circles around the mouse
			/// pointer when the user presses and releases the CTRL key. The pvParam parameter specifies TRUE for on and FALSE for off. The
			/// default is off. For more information, see About Mouse Input. Windows 2000/NT, Windows 98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETMOUSESONAR = 0x101D,

			/// <summary>
			/// Retrieves the state of the Mouse ClickLock feature. The pvParam parameter must point to a BOOL variable that receives TRUE if
			/// enabled, or FALSE otherwise. For more information, see About Mouse Input. Windows 2000/NT, Windows 98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETMOUSECLICKLOCK = 0x101E,

			/// <summary>
			/// Turns the Mouse ClickLock accessibility feature on or off. This feature temporarily locks down the primary mouse button when
			/// that button is clicked and held down for the time specified by SPI_SETMOUSECLICKLOCKTIME. The uiParam parameter specifies
			/// TRUE for on, or FALSE for off. The default is off. For more information, see Remarks and About Mouse Input on MSDN. Windows
			/// 2000/NT, Windows 98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETMOUSECLICKLOCK = 0x101F,

			/// <summary>
			/// Retrieves the state of the Mouse Vanish feature. The pvParam parameter must point to a BOOL variable that receives TRUE if
			/// enabled or FALSE otherwise. For more information, see About Mouse Input on MSDN. Windows 2000/NT, Windows 98/95: This value
			/// is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETMOUSEVANISH = 0x1020,

			/// <summary>
			/// Turns the Vanish feature on or off. This feature hides the mouse pointer when the user types; the pointer reappears when the
			/// user moves the mouse. The pvParam parameter specifies TRUE for on and FALSE for off. The default is off. For more
			/// information, see About Mouse Input on MSDN. Windows 2000/NT, Windows 98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETMOUSEVANISH = 0x1021,

			/// <summary>
			/// Determines whether native User menus have flat menu appearance. The pvParam parameter must point to a BOOL variable that
			/// returns TRUE if the flat menu appearance is set, or FALSE otherwise. Windows 2000/NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETFLATMENU = 0x1022,

			/// <summary>
			/// Enables or disables flat menu appearance for native User menus. Set pvParam to TRUE to enable flat menu appearance or FALSE
			/// to disable it. When enabled, the menu bar uses COLOR_MENUBAR for the menubar background, COLOR_MENU for the menu-popup
			/// background, COLOR_MENUHILIGHT for the fill of the current menu selection, and COLOR_HILIGHT for the outline of the current
			/// menu selection. If disabled, menus are drawn using the same metrics and colors as in Windows 2000 and earlier. Windows
			/// 2000/NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETFLATMENU = 0x1023,

			/// <summary>
			/// Determines whether the drop shadow effect is enabled. The pvParam parameter must point to a BOOL variable that returns TRUE
			/// if enabled or FALSE if disabled. Windows 2000/NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETDROPSHADOW = 0x1024,

			/// <summary>
			/// Enables or disables the drop shadow effect. Set pvParam to TRUE to enable the drop shadow effect or FALSE to disable it. You
			/// must also have CS_DROPSHADOW in the window class style. Windows 2000/NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETDROPSHADOW = 0x1025,

			/// <summary>
			/// Retrieves a BOOL indicating whether an application can reset the screensaver's timer by calling the SendInput function to
			/// simulate keyboard or mouse input. The pvParam parameter must point to a BOOL variable that receives TRUE if the simulated
			/// input will be blocked, or FALSE otherwise.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETBLOCKSENDINPUTRESETS = 0x1026,

			/// <summary>
			/// Determines whether an application can reset the screensaver's timer by calling the SendInput function to simulate keyboard or
			/// mouse input. The uiParam parameter specifies TRUE if the screensaver will not be deactivated by simulated input, or FALSE if
			/// the screensaver will be deactivated by simulated input.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETBLOCKSENDINPUTRESETS = 0x1027,

			/// <summary>
			/// Determines whether UI effects are enabled or disabled. The pvParam parameter must point to a BOOL variable that receives TRUE
			/// if all UI effects are enabled, or FALSE if they are disabled. Windows NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETUIEFFECTS = 0x103E,

			/// <summary>
			/// Enables or disables UI effects. Set the pvParam parameter to TRUE to enable all UI effects or FALSE to disable all UI
			/// effects. Windows NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETUIEFFECTS = 0x103F,

			/// <summary>
			/// Determines whether overlapped content is enabled or disabled. The pvParam parameter must point to a BOOL variable that
			/// receives TRUE if enabled, or FALSE otherwise.
			/// <para>
			/// Display features such as background images, textured backgrounds, water marks on documents, alpha blending, and transparency
			/// can reduce the contrast between the foreground and background, making it harder for users with low vision to see objects on
			/// the screen. This flag enables you to determine whether such overlapped content has been disabled.
			/// </para>
			/// <para><c>Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETDISABLEOVERLAPPEDCONTENT = 0x1040,

			/// <summary>
			/// Turns overlapped content (such as background images and watermarks) on or off. The pvParam parameter is a BOOL variable. Set
			/// pvParam to TRUE to disable overlapped content, or FALSE to enable overlapped content.
			/// <para>
			/// Display features such as background images, textured backgrounds, water marks on documents, alpha blending, and transparency
			/// can reduce the contrast between the foreground and background, making it harder for users with low vision to see objects on
			/// the screen. This flag enables you to determine whether such overlapped content has been disabled.
			/// </para>
			/// <para><c>Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETDISABLEOVERLAPPEDCONTENT = 0x1041,

			/// <summary>
			/// Determines whether animations are enabled or disabled. The pvParam parameter must point to a BOOL variable that receives TRUE
			/// if animations are enabled, or FALSE otherwise.
			/// <para>
			/// Display features such as flashing, blinking, flickering, and moving content can cause seizures in users with photo-sensitive
			/// epilepsy. This flag enables you to determine whether such animations have been disabled in the client area.
			/// </para>
			/// <para><c>Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETCLIENTAREAANIMATION = 0x1042,

			/// <summary>
			/// Turns client area animations on or off. The pvParam parameter is a BOOL variable. Set pvParam to TRUE to enable animations
			/// and other transient effects in the client area, or FALSE to disable them.
			/// <para>
			/// Display features such as flashing, blinking, flickering, and moving content can cause seizures in users with photo-sensitive
			/// epilepsy. This flag enables you to determine whether such animations have been disabled in the client area.
			/// </para>
			/// <para><c>Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETCLIENTAREAANIMATION = 0x1043,

			/// <summary>
			/// Determines whether ClearType is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE if ClearType
			/// is enabled, or FALSE otherwise.
			/// <para>ClearType is a software technology that improves the readability of text on liquid crystal display (LCD) monitors.</para>
			/// <para><c>Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETCLEARTYPE = 0x1048,

			/// <summary>
			/// Turns ClearType on or off. The pvParam parameter is a BOOL variable. Set pvParam to TRUE to enable ClearType, or FALSE to
			/// disable it.
			/// <para>ClearType is a software technology that improves the readability of text on liquid crystal display (LCD) monitors.</para>
			/// <para><c>Windows Server 2003 and Windows XP/2000:</c> This parameter is not supported.</para>
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETCLEARTYPE = 0x1049,

			/// <summary>Undocumented</summary>
			SPI_GETSPEECHRECOGNITION = 0x104A,

			/// <summary>Undocumented</summary>
			SPI_SETSPEECHRECOGNITION = 0x104B,

			/// <summary>Undocumented</summary>
			SPI_GETCARETBROWSING = 0x104C,

			/// <summary>Undocumented</summary>
			SPI_SETCARETBROWSING = 0x104D,

			/// <summary>
			/// <c>Starting with Windows 8:</c> Determines whether the active input settings have Local (per-thread, TRUE) or Global
			/// (session, FALSE) scope. The pvParam parameter must point to a BOOL variable.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETTHREADLOCALINPUTSETTINGS = 0x104E,

			/// <summary>
			/// <c>Starting with Windows 8:</c> Determines whether the active input settings have Local (per-thread, TRUE) or Global
			/// (session, FALSE) scope. The pvParam parameter must point to a BOOL variable, casted by PVOID.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_SETTHREADLOCALINPUTSETTINGS = 0x104F,

			/// <summary>
			/// <c>Starting with Windows 8:</c> Determines whether the system language bar is enabled or disabled. The pvParam parameter must
			/// point to a BOOL variable that receives TRUE if the language bar is enabled, or FALSE otherwise.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Get)]
			SPI_GETSYSTEMLANGUAGEBAR = 0x1050,

			/// <summary>
			/// <c>Starting with Windows 8:</c> Turns the legacy language bar feature on or off. The pvParam parameter is a pointer to a BOOL
			/// variable. Set pvParam to TRUE to enable the legacy language bar, or FALSE to disable it. The flag is supported on Windows 8
			/// where the legacy language bar is replaced by Input Switcher and therefore turned off by default. Turning the legacy language
			/// bar on is provided for compatibility reasons and has no effect on the Input Switcher.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set)]
			SPI_SETSYSTEMLANGUAGEBAR = 0x1051,

			/// <summary>
			/// Retrieves the amount of time following user input, in milliseconds, during which the system will not allow applications to
			/// force themselves into the foreground. The pvParam parameter must point to a DWORD variable that receives the time. Windows
			/// NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000,

			/// <summary>
			/// Sets the amount of time following user input, in milliseconds, during which the system does not allow applications to force
			/// themselves into the foreground. Set pvParam to the new timeout value. The calling thread must be able to change the
			/// foreground window, otherwise the call fails. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001,

			/// <summary>
			/// Retrieves the active window tracking delay, in milliseconds. The pvParam parameter must point to a DWORD variable that
			/// receives the time. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETACTIVEWNDTRKTIMEOUT = 0x2002,

			/// <summary>
			/// Sets the active window tracking delay. Set pvParam to the number of milliseconds to delay before activating the window under
			/// the mouse pointer. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETACTIVEWNDTRKTIMEOUT = 0x2003,

			/// <summary>
			/// Retrieves the number of times SetForegroundWindow will flash the taskbar button when rejecting a foreground switch request.
			/// The pvParam parameter must point to a DWORD variable that receives the value. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETFOREGROUNDFLASHCOUNT = 0x2004,

			/// <summary>
			/// Sets the number of times SetForegroundWindow will flash the taskbar button when rejecting a foreground switch request. Set
			/// pvParam to the number of times to flash. Windows NT, Windows 95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETFOREGROUNDFLASHCOUNT = 0x2005,

			/// <summary>
			/// Retrieves the caret width in edit controls, in pixels. The pvParam parameter must point to a DWORD that receives this value.
			/// Windows NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETCARETWIDTH = 0x2006,

			/// <summary>
			/// Sets the caret width in edit controls. Set pvParam to the desired width, in pixels. The default and minimum value is 1.
			/// Windows NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETCARETWIDTH = 0x2007,

			/// <summary>
			/// Retrieves the time delay before the primary mouse button is locked. The pvParam parameter must point to DWORD that receives
			/// the time delay. This is only enabled if SPI_SETMOUSECLICKLOCK is set to TRUE. For more information, see About Mouse Input on
			/// MSDN. Windows 2000/NT, Windows 98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETMOUSECLICKLOCKTIME = 0x2008,

			/// <summary>
			/// Turns the Mouse ClickLock accessibility feature on or off. This feature temporarily locks down the primary mouse button when
			/// that button is clicked and held down for the time specified by SPI_SETMOUSECLICKLOCKTIME. The uiParam parameter specifies
			/// TRUE for on, or FALSE for off. The default is off. For more information, see Remarks and About Mouse Input on MSDN. Windows
			/// 2000/NT, Windows 98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(bool), CorrepsondingAction.Set, true)]
			SPI_SETMOUSECLICKLOCKTIME = 0x2009,

			/// <summary>
			/// Retrieves the type of font smoothing. The pvParam parameter must point to a UINT that receives the information. Windows
			/// 2000/NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETFONTSMOOTHINGTYPE = 0x200A,

			/// <summary>
			/// Sets the font smoothing type. The pvParam parameter points to a UINT that contains either FE_FONTSMOOTHINGSTANDARD, if
			/// standard anti-aliasing is used, or FE_FONTSMOOTHINGCLEARTYPE, if ClearType is used. The default is FE_FONTSMOOTHINGSTANDARD.
			/// When using this option, the fWinIni parameter must be set to SPIF_SENDWININICHANGE | SPIF_UPDATEINIFILE; otherwise,
			/// SystemParametersInfo fails.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETFONTSMOOTHINGTYPE = 0x200B,

			/// <summary>
			/// Retrieves a contrast value that is used in ClearType™ smoothing. The pvParam parameter must point to a UINT that receives the
			/// information. Windows 2000/NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETFONTSMOOTHINGCONTRAST = 0x200C,

			/// <summary>
			/// Sets the contrast value used in ClearType smoothing. The pvParam parameter points to a UINT that holds the contrast value.
			/// Valid contrast values are from 1000 to 2200. The default value is 1400. When using this option, the fWinIni parameter must be
			/// set to SPIF_SENDWININICHANGE | SPIF_UPDATEINIFILE; otherwise, SystemParametersInfo fails. SPI_SETFONTSMOOTHINGTYPE must also
			/// be set to FE_FONTSMOOTHINGCLEARTYPE. Windows 2000/NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETFONTSMOOTHINGCONTRAST = 0x200D,

			/// <summary>
			/// Retrieves the width, in pixels, of the left and right edges of the focus rectangle drawn with DrawFocusRect. The pvParam
			/// parameter must point to a UINT. Windows 2000/NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETFOCUSBORDERWIDTH = 0x200E,

			/// <summary>
			/// Sets the height of the left and right edges of the focus rectangle drawn with DrawFocusRect to the value of the pvParam
			/// parameter. Windows 2000/NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETFOCUSBORDERWIDTH = 0x200F,

			/// <summary>
			/// Retrieves the height, in pixels, of the top and bottom edges of the focus rectangle drawn with DrawFocusRect. The pvParam
			/// parameter must point to a UINT. Windows 2000/NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETFOCUSBORDERHEIGHT = 0x2010,

			/// <summary>
			/// Sets the height of the top and bottom edges of the focus rectangle drawn with DrawFocusRect to the value of the pvParam
			/// parameter. Windows 2000/NT, Windows Me/98/95: This value is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETFOCUSBORDERHEIGHT = 0x2011,

			/// <summary>
			/// Retrieves the font smoothing orientation. The pvParam parameter must point to a UINT that receives the information. The
			/// possible values are FE_FONTSMOOTHINGORIENTATIONBGR (blue-green-red) and FE_FONTSMOOTHINGORIENTATIONRGB (red-green-blue).
			/// Windows XP/2000: This parameter is not supported until Windows XP with SP2.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETFONTSMOOTHINGORIENTATION = 0x2012,

			/// <summary>
			/// Sets the font smoothing orientation. The pvParam parameter is either FE_FONTSMOOTHINGORIENTATIONBGR (blue-green-red) or
			/// FE_FONTSMOOTHINGORIENTATIONRGB (red-green-blue). Windows XP/2000: This parameter is not supported until Windows XP with SP2.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETFONTSMOOTHINGORIENTATION = 0x2013,

			/// <summary>Undocumented</summary>
			SPI_GETMINIMUMHITRADIUS = 0x2014,

			/// <summary>Undocumented</summary>
			SPI_SETMINIMUMHITRADIUS = 0x2015,

			/// <summary>
			/// Retrieves the time that notification pop-ups should be displayed, in seconds. The pvParam parameter must point to a ULONG
			/// that receives the message duration. Users with visual impairments or cognitive conditions such as ADHD and dyslexia might
			/// need a longer time to read the text in notification messages. This flag enables you to retrieve the message duration. Windows
			/// Server 2003 and Windows XP/2000: This parameter is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Get)]
			SPI_GETMESSAGEDURATION = 0x2016,

			/// <summary>
			/// Sets the time that notification pop-ups should be displayed, in seconds. The pvParam parameter specifies the message
			/// duration. Users with visual impairments or cognitive conditions such as ADHD and dyslexia might need a longer time to read
			/// the text in notification messages. This flag enables you to set the message duration. Windows Server 2003 and Windows
			/// XP/2000: This parameter is not supported.
			/// </summary>
			[SPCorrespondingType(typeof(uint), CorrepsondingAction.Set)]
			SPI_SETMESSAGEDURATION = 0x2017,

			/// <summary>
			/// Retrieves the current contact visualization setting. The pvParam parameter must point to a ULONG variable that receives the
			/// setting. For more information, see Contact Visualization.
			/// </summary>
			[SPCorrespondingType(typeof(ContactVisualization), CorrepsondingAction.Get)]
			SPI_GETCONTACTVISUALIZATION = 0x2018,

			/// <summary>
			/// Sets the current contact visualization setting. The pvParam parameter must point to a ULONG variable that identifies the
			/// setting. For more information, see Contact Visualization.
			/// </summary>
			[SPCorrespondingType(typeof(ContactVisualization), CorrepsondingAction.Set)]
			SPI_SETCONTACTVISUALIZATION = 0x2019,

			/// <summary>
			/// Retrieves the current gesture visualization setting. The pvParam parameter must point to a ULONG variable that receives the
			/// setting. For more information, see Gesture Visualization.
			/// </summary>
			[SPCorrespondingType(typeof(GestureVisualization), CorrepsondingAction.Get)]
			SPI_GETGESTUREVISUALIZATION = 0x201A,

			/// <summary>
			/// Sets the current gesture visualization setting. The pvParam parameter must point to a ULONG variable that identifies the
			/// setting. For more information, see Gesture Visualization.
			/// </summary>
			[SPCorrespondingType(typeof(GestureVisualization), CorrepsondingAction.Set)]
			SPI_SETGESTUREVISUALIZATION = 0x201B,

			/// <summary>
			/// Retrieves the routing setting for wheel button input. The routing setting determines whether wheel button input is sent to
			/// the app with focus (foreground) or the app under the mouse cursor. The pvParam parameter must point to a DWORD variable that
			/// receives the routing option. If the value is zero or MOUSEWHEEL_ROUTING_FOCUS, mouse wheel input is delivered to the app with
			/// focus. If the value is 1 or MOUSEWHEEL_ROUTING_HYBRID (default), mouse wheel input is delivered to the app with focus(desktop
			/// apps) or the app under the mouse cursor(Windows Store apps). The uiParam parameter is not used.
			/// </summary>
			[SPCorrespondingType(typeof(MouseWheelRouting), CorrepsondingAction.Get)]
			SPI_GETMOUSEWHEELROUTING = 0x201C,

			/// <summary>
			/// Sets the routing setting for wheel button input. The routing setting determines whether wheel button input is sent to the app
			/// with focus (foreground) or the app under the mouse cursor. The pvParam parameter must point to a DWORD variable that receives
			/// the routing option. If the value is zero or MOUSEWHEEL_ROUTING_FOCUS, mouse wheel input is delivered to the app with focus.
			/// If the value is 1 or MOUSEWHEEL_ROUTING_HYBRID (default), mouse wheel input is delivered to the app with focus(desktop apps)
			/// or the app under the mouse cursor(Windows Store apps). Set the uiParam parameter to zero.
			/// </summary>
			[SPCorrespondingType(typeof(MouseWheelRouting), CorrepsondingAction.Set)]
			SPI_SETMOUSEWHEELROUTING = 0x201D,

			/// <summary>
			/// Retrieves the current pen gesture visualization setting. The pvParam parameter must point to a ULONG variable that receives
			/// the setting. For more information, see Pen Visualization.
			/// </summary>
			[SPCorrespondingType(typeof(PenVisualization), CorrepsondingAction.Get)]
			SPI_GETPENVISUALIZATION = 0x201E,

			/// <summary>
			/// Sets the current pen gesture visualization setting. The pvParam parameter must point to a ULONG variable that identifies the
			/// setting. For more information, see Pen Visualization.
			/// </summary>
			[SPCorrespondingType(typeof(PenVisualization), CorrepsondingAction.Set)]
			SPI_SETPENVISUALIZATION = 0x201F,

			/// <summary>Undocumented</summary>
			[SPCorrespondingType(typeof(PenArbitrationType), CorrepsondingAction.Get)]
			SPI_GETPENARBITRATIONTYPE = 0x2020,

			/// <summary>Undocumented</summary>
			[SPCorrespondingType(typeof(PenArbitrationType), CorrepsondingAction.Set)]
			SPI_SETPENARBITRATIONTYPE = 0x2021,

			/// <summary>Undocumented</summary>
			SPI_GETCARETTIMEOUT = 0x2022,

			/// <summary>Undocumented</summary>
			SPI_SETCARETTIMEOUT = 0x2023,

			/// <summary>Undocumented</summary>
			[SPCorrespondingType(typeof(HANDEDNESS), CorrepsondingAction.Get)]
			SPI_GETHANDEDNESS = 0x2024,

			/// <summary>Undocumented</summary>
			[SPCorrespondingType(typeof(HANDEDNESS), CorrepsondingAction.Set)]
			SPI_SETHANDEDNESS = 0x2025,
		}

		/// <summary>Flags for SystemParametersInfo</summary>
		[PInvokeData("Winuser.h")]
		[Flags]
		public enum SPIF
		{
			/// <summary>No flags set.</summary>
			None = 0x00,

			/// <summary>Writes the new system-wide parameter setting to the user profile.</summary>
			SPIF_UPDATEINIFILE = 0x01,

			/// <summary>Broadcasts the WM_SETTINGCHANGE message after updating the user profile.</summary>
			SPIF_SENDCHANGE = 0x02,

			/// <summary>Same as SPIF_SENDCHANGE.</summary>
			SPIF_SENDWININICHANGE = 0x02
		}

		/// <summary>A set of bit flags that specify properties of the SoundSentry feature.</summary>
		[PInvokeData("Winuser.h")]
		[Flags]
		public enum SSF
		{
			/// <summary>If this flag is set, the SoundSentry feature is on.</summary>
			SSF_SOUNDSENTRYON = 0x00000001,

			/// <summary>If this flag is set, the SoundSentry feature is available.</summary>
			SSF_AVAILABLE = 0x00000002,

			/// <summary>This flag is not implemented.</summary>
			SSF_INDICATOR = 0x00000004
		}

		/// <summary>
		/// Specifies the visual signal to present when a graphics-mode application generates a sound while running in a full-screen virtual machine.
		/// </summary>
		[PInvokeData("Winuser.h")]
		public enum SSGF
		{
			/// <summary>No visual signal</summary>
			SSGF_NONE = 0,

			/// <summary>Flash the entire display.</summary>
			SSGF_DISPLAY = 3,
		}

		/// <summary>
		/// Specifies the visual signal to present when a text-mode application generates a sound while running in a full-screen virtual machine.
		/// </summary>
		[PInvokeData("Winuser.h")]
		public enum SSTF
		{
			/// <summary>No visual signal</summary>
			SSTF_NONE = 0,

			/// <summary>Flash characters in the corner of the screen.</summary>
			SSTF_CHARS = 1,

			/// <summary>Flash the screen border (that is, the overscan area), which is unavailable on some displays.</summary>
			SSTF_BORDER = 2,

			/// <summary>Flash the entire display.</summary>
			SSTF_DISPLAY = 3,
		}

		/// <summary>
		/// Specifies the visual signal to display when a sound is generated by a Windows-based application or an MS-DOS application running
		/// in a window.
		/// </summary>
		[PInvokeData("Winuser.h")]
		public enum SSWF
		{
			/// <summary>No visual signal.</summary>
			SSWF_NONE = 0,

			/// <summary>Flash the title bar of the active window.</summary>
			SSWF_TITLE = 1,

			/// <summary>Flash the active window.</summary>
			SSWF_WINDOW = 2,

			/// <summary>Flash the entire display.</summary>
			SSWF_DISPLAY = 3,

			/// <summary>Use a custom visual signal.</summary>
			SSWF_CUSTOM = 4,
		}

		/// <summary>The system metric or configuration setting to be retrieved by <see cref="GetSystemMetrics"/>.</summary>
		[PInvokeData("Winuser.h", MSDNShortId = "ms724385")]
		public enum SystemMetric
		{
			/// <summary>
			/// The flags that specify how the system arranged minimized windows. For more information, see the Remarks section in this topic.
			/// </summary>
			SM_ARRANGE = 56,

			/// <summary>
			/// The value that specifies how the system is started:
			/// <para>0 Normal boot</para>
			/// <para>1 Fail-safe boot</para>
			/// <para>2 Fail-safe with network boot</para>
			/// <para>A fail-safe boot (also called SafeBoot, Safe Mode, or Clean Boot) bypasses the user startup files.</para>
			/// </summary>
			SM_CLEANBOOT = 67,

			/// <summary>The number of display monitors on a desktop. For more information, see the Remarks section in this topic.</summary>
			SM_CMONITORS = 80,

			/// <summary>The number of buttons on a mouse, or zero if no mouse is installed.</summary>
			SM_CMOUSEBUTTONS = 43,

			/// <summary>
			/// Reflects the state of the laptop or slate mode, 0 for Slate Mode and non-zero otherwise. When this system metric changes, the
			/// system sends a broadcast message via WM_SETTINGCHANGE with "ConvertibleSlateMode" in the LPARAM. Note that this system metric
			/// doesn't apply to desktop PCs. In that case, use GetAutoRotationState.
			/// </summary>
			SM_CONVERTIBLESLATEMODE = 0x2003,

			/// <summary>
			/// The width of a window border, in pixels. This is equivalent to the SM_CXEDGE value for windows with the 3-D look.
			/// </summary>
			SM_CXBORDER = 5,

			/// <summary>The width of a cursor, in pixels. The system cannot create cursors of other sizes.</summary>
			SM_CXCURSOR = 13,

			/// <summary>This value is the same as SM_CXFIXEDFRAME.</summary>
			SM_CXDLGFRAME = 7,

			/// <summary>
			/// The width of the rectangle around the location of a first click in a double-click sequence, in pixels. The second click must
			/// occur within the rectangle that is defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system to consider the two clicks a
			/// double-click. The two clicks must also occur within a specified time.
			/// <para>To set the width of the double-click rectangle, call SystemParametersInfo with SPI_SETDOUBLECLKWIDTH.</para>
			/// </summary>
			SM_CXDOUBLECLK = 36,

			/// <summary>
			/// The number of pixels on either side of a mouse-down point that the mouse pointer can move before a drag operation begins.
			/// This allows the user to click and release the mouse button easily without unintentionally starting a drag operation. If this
			/// value is negative, it is subtracted from the left of the mouse-down point and added to the right of it.
			/// </summary>
			SM_CXDRAG = 68,

			/// <summary>The width of a 3-D border, in pixels. This metric is the 3-D counterpart of SM_CXBORDER.</summary>
			SM_CXEDGE = 45,

			/// <summary>
			/// The thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. SM_CXFIXEDFRAME
			/// is the height of the horizontal border, and SM_CYFIXEDFRAME is the width of the vertical border.
			/// <para>This value is the same as SM_CXDLGFRAME.</para>
			/// </summary>
			SM_CXFIXEDFRAME = 7,

			/// <summary>
			/// The width of the left and right edges of the focus rectangle that the DrawFocusRect draws. This value is in pixels.
			/// <para>Windows 2000: This value is not supported.</para>
			/// </summary>
			SM_CXFOCUSBORDER = 83,

			/// <summary>This value is the same as SM_CXSIZEFRAME.</summary>
			SM_CXFRAME = 32,

			/// <summary>
			/// The width of the client area for a full-screen window on the primary display monitor, in pixels. To get the coordinates of
			/// the portion of the screen that is not obscured by the system taskbar or by application desktop toolbars, call the
			/// SystemParametersInfo function with the SPI_GETWORKAREA value.
			/// </summary>
			SM_CXFULLSCREEN = 16,

			/// <summary>The width of the arrow bitmap on a horizontal scroll bar, in pixels.</summary>
			SM_CXHSCROLL = 21,

			/// <summary>The width of the thumb box in a horizontal scroll bar, in pixels.</summary>
			SM_CXHTHUMB = 10,

			/// <summary>
			/// The default width of an icon, in pixels. The LoadIcon function can load only icons with the dimensions that SM_CXICON and
			/// SM_CYICON specifies.
			/// </summary>
			SM_CXICON = 11,

			/// <summary>
			/// The width of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size SM_CXICONSPACING by
			/// SM_CYICONSPACING when arranged. This value is always greater than or equal to SM_CXICON.
			/// </summary>
			SM_CXICONSPACING = 38,

			/// <summary>The default width, in pixels, of a maximized top-level window on the primary display monitor.</summary>
			SM_CXMAXIMIZED = 61,

			/// <summary>
			/// The default maximum width of a window that has a caption and sizing borders, in pixels. This metric refers to the entire
			/// desktop. The user cannot drag the window frame to a size larger than these dimensions. A window can override this value by
			/// processing the WM_GETMINMAXINFO message.
			/// </summary>
			SM_CXMAXTRACK = 59,

			/// <summary>The width of the default menu check-mark bitmap, in pixels.</summary>
			SM_CXMENUCHECK = 71,

			/// <summary>
			/// The width of menu bar buttons, such as the child window close button that is used in the multiple document interface, in pixels.
			/// </summary>
			SM_CXMENUSIZE = 54,

			/// <summary>The minimum width of a window, in pixels.</summary>
			SM_CXMIN = 28,

			/// <summary>The width of a minimized window, in pixels.</summary>
			SM_CXMINIMIZED = 57,

			/// <summary>
			/// The width of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when
			/// arranged. This value is always greater than or equal to SM_CXMINIMIZED.
			/// </summary>
			SM_CXMINSPACING = 47,

			/// <summary>
			/// The minimum tracking width of a window, in pixels. The user cannot drag the window frame to a size smaller than these
			/// dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.
			/// </summary>
			SM_CXMINTRACK = 34,

			/// <summary>
			/// The amount of border padding for captioned windows, in pixels.
			/// <para>Windows XP/2000: This value is not supported.</para>
			/// </summary>
			SM_CXPADDEDBORDER = 92,

			/// <summary>
			/// The width of the screen of the primary display monitor, in pixels. This is the same value obtained by calling GetDeviceCaps
			/// as follows: GetDeviceCaps( hdcPrimaryMonitor, HORZRES).
			/// </summary>
			SM_CXSCREEN = 0,

			/// <summary>The width of a button in a window caption or title bar, in pixels.</summary>
			SM_CXSIZE = 30,

			/// <summary>
			/// The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. SM_CXSIZEFRAME is the
			/// width of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border.
			/// <para>This value is the same as SM_CXFRAME.</para>
			/// </summary>
			SM_CXSIZEFRAME = 32,

			/// <summary>
			/// The recommended width of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.
			/// </summary>
			SM_CXSMICON = 49,

			/// <summary>The width of small caption buttons, in pixels.</summary>
			SM_CXSMSIZE = 52,

			/// <summary>
			/// The width of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors. The
			/// SM_XVIRTUALSCREEN metric is the coordinates for the left side of the virtual screen.
			/// </summary>
			SM_CXVIRTUALSCREEN = 78,

			/// <summary>The width of a vertical scroll bar, in pixels.</summary>
			SM_CXVSCROLL = 2,

			/// <summary>
			/// The height of a window border, in pixels. This is equivalent to the SM_CYEDGE value for windows with the 3-D look.
			/// </summary>
			SM_CYBORDER = 6,

			/// <summary>The height of a caption area, in pixels.</summary>
			SM_CYCAPTION = 4,

			/// <summary>The height of a cursor, in pixels. The system cannot create cursors of other sizes.</summary>
			SM_CYCURSOR = 14,

			/// <summary>This value is the same as SM_CYFIXEDFRAME.</summary>
			SM_CYDLGFRAME = 8,

			/// <summary>
			/// The height of the rectangle around the location of a first click in a double-click sequence, in pixels. The second click must
			/// occur within the rectangle defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system to consider the two clicks a
			/// double-click. The two clicks must also occur within a specified time.
			/// <para>To set the height of the double-click rectangle, call SystemParametersInfo with SPI_SETDOUBLECLKHEIGHT.</para>
			/// </summary>
			SM_CYDOUBLECLK = 37,

			/// <summary>
			/// The number of pixels above and below a mouse-down point that the mouse pointer can move before a drag operation begins. This
			/// allows the user to click and release the mouse button easily without unintentionally starting a drag operation. If this value
			/// is negative, it is subtracted from above the mouse-down point and added below it.
			/// </summary>
			SM_CYDRAG = 69,

			/// <summary>The height of a 3-D border, in pixels. This is the 3-D counterpart of SM_CYBORDER.</summary>
			SM_CYEDGE = 46,

			/// <summary>
			/// The thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. SM_CXFIXEDFRAME
			/// is the height of the horizontal border, and SM_CYFIXEDFRAME is the width of the vertical border.
			/// <para>This value is the same as SM_CYDLGFRAME.</para>
			/// </summary>
			SM_CYFIXEDFRAME = 8,

			/// <summary>
			/// The height of the top and bottom edges of the focus rectangle drawn by DrawFocusRect. This value is in pixels.
			/// <para>Windows 2000: This value is not supported.</para>
			/// </summary>
			SM_CYFOCUSBORDER = 84,

			/// <summary>This value is the same as SM_CYSIZEFRAME.</summary>
			SM_CYFRAME = 33,

			/// <summary>
			/// The height of the client area for a full-screen window on the primary display monitor, in pixels. To get the coordinates of
			/// the portion of the screen not obscured by the system taskbar or by application desktop toolbars, call the
			/// SystemParametersInfo function with the SPI_GETWORKAREA value.
			/// </summary>
			SM_CYFULLSCREEN = 17,

			/// <summary>The height of a horizontal scroll bar, in pixels.</summary>
			SM_CYHSCROLL = 3,

			/// <summary>
			/// The default height of an icon, in pixels. The LoadIcon function can load only icons with the dimensions SM_CXICON and SM_CYICON.
			/// </summary>
			SM_CYICON = 12,

			/// <summary>
			/// The height of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size SM_CXICONSPACING
			/// by SM_CYICONSPACING when arranged. This value is always greater than or equal to SM_CYICON.
			/// </summary>
			SM_CYICONSPACING = 39,

			/// <summary>
			/// For double byte character set versions of the system, this is the height of the Kanji window at the bottom of the screen, in pixels.
			/// </summary>
			SM_CYKANJIWINDOW = 18,

			/// <summary>The default height, in pixels, of a maximized top-level window on the primary display monitor.</summary>
			SM_CYMAXIMIZED = 62,

			/// <summary>
			/// The default maximum height of a window that has a caption and sizing borders, in pixels. This metric refers to the entire
			/// desktop. The user cannot drag the window frame to a size larger than these dimensions. A window can override this value by
			/// processing the WM_GETMINMAXINFO message.
			/// </summary>
			SM_CYMAXTRACK = 60,

			/// <summary>The height of a single-line menu bar, in pixels.</summary>
			SM_CYMENU = 15,

			/// <summary>The height of the default menu check-mark bitmap, in pixels.</summary>
			SM_CYMENUCHECK = 72,

			/// <summary>
			/// The height of menu bar buttons, such as the child window close button that is used in the multiple document interface, in pixels.
			/// </summary>
			SM_CYMENUSIZE = 55,

			/// <summary>The minimum height of a window, in pixels.</summary>
			SM_CYMIN = 29,

			/// <summary>The height of a minimized window, in pixels.</summary>
			SM_CYMINIMIZED = 58,

			/// <summary>
			/// The height of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when
			/// arranged. This value is always greater than or equal to SM_CYMINIMIZED.
			/// </summary>
			SM_CYMINSPACING = 48,

			/// <summary>
			/// The minimum tracking height of a window, in pixels. The user cannot drag the window frame to a size smaller than these
			/// dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.
			/// </summary>
			SM_CYMINTRACK = 35,

			/// <summary>
			/// The height of the screen of the primary display monitor, in pixels. This is the same value obtained by calling GetDeviceCaps
			/// as follows: GetDeviceCaps( hdcPrimaryMonitor, VERTRES).
			/// </summary>
			SM_CYSCREEN = 1,

			/// <summary>The height of a button in a window caption or title bar, in pixels.</summary>
			SM_CYSIZE = 31,

			/// <summary>
			/// The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. SM_CXSIZEFRAME is the
			/// width of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border.
			/// <para>This value is the same as SM_CYFRAME.</para>
			/// </summary>
			SM_CYSIZEFRAME = 33,

			/// <summary>The height of a small caption, in pixels.</summary>
			SM_CYSMCAPTION = 51,

			/// <summary>
			/// The recommended height of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.
			/// </summary>
			SM_CYSMICON = 50,

			/// <summary>The height of small caption buttons, in pixels.</summary>
			SM_CYSMSIZE = 53,

			/// <summary>
			/// The height of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors. The
			/// SM_YVIRTUALSCREEN metric is the coordinates for the top of the virtual screen.
			/// </summary>
			SM_CYVIRTUALSCREEN = 79,

			/// <summary>The height of the arrow bitmap on a vertical scroll bar, in pixels.</summary>
			SM_CYVSCROLL = 20,

			/// <summary>The height of the thumb box in a vertical scroll bar, in pixels.</summary>
			SM_CYVTHUMB = 9,

			/// <summary>Nonzero if User32.dll supports DBCS; otherwise, 0.</summary>
			SM_DBCSENABLED = 42,

			/// <summary>Nonzero if the debug version of User.exe is installed; otherwise, 0.</summary>
			SM_DEBUG = 22,

			/// <summary>
			/// Nonzero if the current operating system is Windows 7 or Windows Server 2008 R2 and the Tablet PC Input service is started;
			/// otherwise, 0. The return value is a bitmask that specifies the type of digitizer input supported by the device. For more
			/// information, see Remarks.
			/// <para>Windows Server 2008, Windows Vista and Windows XP/2000: This value is not supported.</para>
			/// </summary>
			SM_DIGITIZER = 94,

			/// <summary>
			/// Nonzero if Input Method Manager/Input Method Editor features are enabled; otherwise, 0.
			/// <para>
			/// SM_IMMENABLED indicates whether the system is ready to use a Unicode-based IME on a Unicode application. To ensure that a
			/// language-dependent IME works, check SM_DBCSENABLED and the system ANSI code page. Otherwise the ANSI-to-Unicode conversion
			/// may not be performed correctly, or some components like fonts or registry settings may not be present.
			/// </para>
			/// </summary>
			SM_IMMENABLED = 82,

			/// <summary>
			/// Nonzero if there are digitizers in the system; otherwise, 0.
			/// <para>
			/// SM_MAXIMUMTOUCHES returns the aggregate maximum of the maximum number of contacts supported by every digitizer in the system.
			/// If the system has only single-touch digitizers, the return value is 1. If the system has multi-touch digitizers, the return
			/// value is the number of simultaneous contacts the hardware can provide.
			/// </para>
			/// <para>Windows Server 2008, Windows Vista and Windows XP/2000: This value is not supported.</para>
			/// </summary>
			SM_MAXIMUMTOUCHES = 95,

			/// <summary>Nonzero if the current operating system is the Windows XP, Media Center Edition, 0 if not.</summary>
			SM_MEDIACENTER = 87,

			/// <summary>Nonzero if drop-down menus are right-aligned with the corresponding menu-bar item; 0 if the menus are left-aligned.</summary>
			SM_MENUDROPALIGNMENT = 40,

			/// <summary>Nonzero if the system is enabled for Hebrew and Arabic languages, 0 if not.</summary>
			SM_MIDEASTENABLED = 74,

			/// <summary>
			/// Nonzero if a mouse is installed; otherwise, 0. This value is rarely zero, because of support for virtual mice and because
			/// some systems detect the presence of the port instead of the presence of a mouse.
			/// </summary>
			SM_MOUSEPRESENT = 19,

			/// <summary>Nonzero if a mouse with a horizontal scroll wheel is installed; otherwise 0.</summary>
			SM_MOUSEHORIZONTALWHEELPRESENT = 91,

			/// <summary>Nonzero if a mouse with a vertical scroll wheel is installed; otherwise 0.</summary>
			SM_MOUSEWHEELPRESENT = 75,

			/// <summary>
			/// The least significant bit is set if a network is present; otherwise, it is cleared. The other bits are reserved for future use.
			/// </summary>
			SM_NETWORK = 63,

			/// <summary>Nonzero if the Microsoft Windows for Pen computing extensions are installed; zero otherwise.</summary>
			SM_PENWINDOWS = 41,

			/// <summary>
			/// This system metric is used in a Terminal Services environment to determine if the current Terminal Server session is being
			/// remotely controlled. Its value is nonzero if the current session is remotely controlled; otherwise, 0.
			/// <para>
			/// You can use terminal services management tools such as Terminal Services Manager (tsadmin.msc) and shadow.exe to control a
			/// remote session. When a session is being remotely controlled, another user can view the contents of that session and
			/// potentially interact with it.
			/// </para>
			/// </summary>
			SM_REMOTECONTROL = 0x2001,

			/// <summary>
			/// This system metric is used in a Terminal Services environment. If the calling process is associated with a Terminal Services
			/// client session, the return value is nonzero. If the calling process is associated with the Terminal Services console session,
			/// the return value is 0.
			/// <para>
			/// Windows Server 2003 and Windows XP: The console session is not necessarily the physical console. For more information, see WTSGetActiveConsoleSessionId.
			/// </para>
			/// </summary>
			SM_REMOTESESSION = 0x1000,

			/// <summary>
			/// Nonzero if all the display monitors have the same color format, otherwise, 0. Two displays can have the same bit depth, but
			/// different color formats. For example, the red, green, and blue pixels can be encoded with different numbers of bits, or those
			/// bits can be located in different places in a pixel color value.
			/// </summary>
			SM_SAMEDISPLAYFORMAT = 81,

			/// <summary>This system metric should be ignored; it always returns 0.</summary>
			SM_SECURE = 44,

			/// <summary>The build number if the system is Windows Server 2003 R2; otherwise, 0.</summary>
			SM_SERVERR2 = 89,

			/// <summary>
			/// Nonzero if the user requires an application to present information visually in situations where it would otherwise present
			/// the information only in audible form; otherwise, 0.
			/// </summary>
			SM_SHOWSOUNDS = 70,

			/// <summary>
			/// Nonzero if the current session is shutting down; otherwise, 0.
			/// <para>Windows 2000: This value is not supported.</para>
			/// </summary>
			SM_SHUTTINGDOWN = 0x2000,

			/// <summary>Nonzero if the computer has a low-end (slow) processor; otherwise, 0.</summary>
			SM_SLOWMACHINE = 73,

			/// <summary>
			/// Nonzero if the current operating system is Windows 7 Starter Edition, Windows Vista Starter, or Windows XP Starter Edition;
			/// otherwise, 0.
			/// </summary>
			SM_STARTER = 88,

			/// <summary>Nonzero if the meanings of the left and right mouse buttons are swapped; otherwise, 0.</summary>
			SM_SWAPBUTTON = 23,

			/// <summary>
			/// Reflects the state of the docking mode, 0 for Undocked Mode and non-zero otherwise. When this system metric changes, the
			/// system sends a broadcast message via WM_SETTINGCHANGE with "SystemDockMode" in the LPARAM.
			/// </summary>
			SM_SYSTEMDOCKED = 0x2004,

			/// <summary>
			/// Nonzero if the current operating system is the Windows XP Tablet PC edition or if the current operating system is Windows
			/// Vista or Windows 7 and the Tablet PC Input service is started; otherwise, 0. The SM_DIGITIZER setting indicates the type of
			/// digitizer input supported by a device running Windows 7 or Windows Server 2008 R2. For more information, see Remarks.
			/// </summary>
			SM_TABLETPC = 86,

			/// <summary>
			/// The coordinates for the left side of the virtual screen. The virtual screen is the bounding rectangle of all display
			/// monitors. The SM_CXVIRTUALSCREEN metric is the width of the virtual screen.
			/// </summary>
			SM_XVIRTUALSCREEN = 76,

			/// <summary>
			/// The coordinates for the top of the virtual screen. The virtual screen is the bounding rectangle of all display monitors. The
			/// SM_CYVIRTUALSCREEN metric is the height of the virtual screen.
			/// </summary>
			SM_YVIRTUALSCREEN = 77,
		}

		/// <summary>A set of bit flags that specify properties of the ToggleKeys feature.</summary>
		[PInvokeData("Winuser.h")]
		[Flags]
		public enum TKF : uint
		{
			/// <summary>If this flag is set, the ToggleKeys feature is available.</summary>
			TKF_AVAILABLE = 0x00000002,

			/// <summary>
			/// Windows 95/98, Windows 2000: A confirmation dialog box appears when the ToggleKeys feature is activated by using the hot key.
			/// </summary>
			TKF_CONFIRMHOTKEY = 0x00000008,

			/// <summary>
			/// If this flag is set, the user can turn the ToggleKeys feature on and off by holding down the NUM LOCK key for eight seconds.
			/// </summary>
			TKF_HOTKEYACTIVE = 0x00000004,

			/// <summary>
			/// If this flag is set, the system plays a siren sound when the user turns the ToggleKeys feature on or off by using the hot key.
			/// </summary>
			TKF_HOTKEYSOUND = 0x00000010,

			/// <summary>This flag is not implemented.</summary>
			TKF_INDICATOR = 0x00000020,

			/// <summary>If this flag is set, the ToggleKeys feature is on.</summary>
			TKF_TOGGLEKEYSON = 0x00000001,
		}

		/// <summary>
		/// The ExitWindowsEx function either logs off the current user, shuts down the system, or shuts down and restarts the system. It
		/// sends the WM_QUERYENDSESSION message to all applications to determine if they can be terminated.
		/// </summary>
		/// <param name="uFlags">Specifies the type of shutdown.</param>
		/// <param name="dwReason">The reason for initiating the shutdown.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. <br></br><br>If the function fails, the return value is zero. To get
		/// extended error information, call Marshal.GetLastWin32Error.</br>
		/// </returns>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/aa376868(v=vs.85).aspx
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("Winuser.h", MSDNShortId = "aa376868")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ExitWindowsEx(ExitWindowsFlags uFlags, SystemShutDownReason dwReason);

		/// <summary>
		/// <para>Retrieves the specified system metric or system configuration setting.</para>
		/// <para>Note that all dimensions retrieved by <c>GetSystemMetrics</c> are in pixels.</para>
		/// </summary>
		/// <param name="nIndex">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The system metric or configuration setting to be retrieved. This parameter can be one of the following values. Note that all
		/// SM_CX* values are widths and all SM_CY* values are heights. Also note that all settings designed to return Boolean data represent
		/// <c>TRUE</c> as any nonzero value, and <c>FALSE</c> as a zero value.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SM_ARRANGE56</term>
		/// <term>
		/// The flags that specify how the system arranged minimized windows. For more information, see the Remarks section in this topic.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CLEANBOOT67</term>
		/// <term>
		/// The value that specifies how the system is started: A fail-safe boot (also called SafeBoot, Safe Mode, or Clean Boot) bypasses
		/// the user startup files.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CMONITORS80</term>
		/// <term>The number of display monitors on a desktop. For more information, see the Remarks section in this topic.</term>
		/// </item>
		/// <item>
		/// <term>SM_CMOUSEBUTTONS43</term>
		/// <term>The number of buttons on a mouse, or zero if no mouse is installed.</term>
		/// </item>
		/// <item>
		/// <term>SM_CONVERTIBLESLATEMODE0x2003</term>
		/// <term>
		/// Reflects the state of the laptop or slate mode, 0 for Slate Mode and non-zero otherwise. When this system metric changes, the
		/// system sends a broadcast message via WM_SETTINGCHANGE with &amp;quot;ConvertibleSlateMode&amp;quot; in the LPARAM. Note that this
		/// system metric doesn't apply to desktop PCs. In that case, use GetAutoRotationState.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXBORDER5</term>
		/// <term>The width of a window border, in pixels. This is equivalent to the SM_CXEDGE value for windows with the 3-D look.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXCURSOR13</term>
		/// <term>The width of a cursor, in pixels. The system cannot create cursors of other sizes.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXDLGFRAME7</term>
		/// <term>This value is the same as SM_CXFIXEDFRAME.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXDOUBLECLK36</term>
		/// <term>
		/// The width of the rectangle around the location of a first click in a double-click sequence, in pixels. The second click must
		/// occur within the rectangle that is defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system to consider the two clicks a
		/// double-click. The two clicks must also occur within a specified time. To set the width of the double-click rectangle, call
		/// SystemParametersInfo with SPI_SETDOUBLECLKWIDTH.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXDRAG68</term>
		/// <term>
		/// The number of pixels on either side of a mouse-down point that the mouse pointer can move before a drag operation begins. This
		/// allows the user to click and release the mouse button easily without unintentionally starting a drag operation. If this value is
		/// negative, it is subtracted from the left of the mouse-down point and added to the right of it.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXEDGE45</term>
		/// <term>The width of a 3-D border, in pixels. This metric is the 3-D counterpart of SM_CXBORDER.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXFIXEDFRAME7</term>
		/// <term>
		/// The thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. SM_CXFIXEDFRAME is
		/// the height of the horizontal border, and SM_CYFIXEDFRAME is the width of the vertical border. This value is the same as SM_CXDLGFRAME.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXFOCUSBORDER83</term>
		/// <term>
		/// The width of the left and right edges of the focus rectangle that the DrawFocusRect draws. This value is in pixels. Windows 2000:
		/// This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXFRAME32</term>
		/// <term>This value is the same as SM_CXSIZEFRAME.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXFULLSCREEN16</term>
		/// <term>
		/// The width of the client area for a full-screen window on the primary display monitor, in pixels. To get the coordinates of the
		/// portion of the screen that is not obscured by the system taskbar or by application desktop toolbars, call the
		/// SystemParametersInfo function with the SPI_GETWORKAREA value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXHSCROLL21</term>
		/// <term>The width of the arrow bitmap on a horizontal scroll bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXHTHUMB10</term>
		/// <term>The width of the thumb box in a horizontal scroll bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXICON11</term>
		/// <term>
		/// The default width of an icon, in pixels. The LoadIcon function can load only icons with the dimensions that SM_CXICON and
		/// SM_CYICON specifies.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXICONSPACING38</term>
		/// <term>
		/// The width of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size SM_CXICONSPACING by
		/// SM_CYICONSPACING when arranged. This value is always greater than or equal to SM_CXICON.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXMAXIMIZED61</term>
		/// <term>The default width, in pixels, of a maximized top-level window on the primary display monitor.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXMAXTRACK59</term>
		/// <term>
		/// The default maximum width of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop.
		/// The user cannot drag the window frame to a size larger than these dimensions. A window can override this value by processing the
		/// WM_GETMINMAXINFO message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXMENUCHECK71</term>
		/// <term>The width of the default menu check-mark bitmap, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXMENUSIZE54</term>
		/// <term>
		/// The width of menu bar buttons, such as the child window close button that is used in the multiple document interface, in pixels.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXMIN28</term>
		/// <term>The minimum width of a window, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXMINIMIZED57</term>
		/// <term>The width of a minimized window, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXMINSPACING47</term>
		/// <term>
		/// The width of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged.
		/// This value is always greater than or equal to SM_CXMINIMIZED.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXMINTRACK34</term>
		/// <term>
		/// The minimum tracking width of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions.
		/// A window can override this value by processing the WM_GETMINMAXINFO message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXPADDEDBORDER92</term>
		/// <term>The amount of border padding for captioned windows, in pixels.Windows XP/2000: This value is not supported.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXSCREEN0</term>
		/// <term>
		/// The width of the screen of the primary display monitor, in pixels. This is the same value obtained by calling GetDeviceCaps as
		/// follows: .
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXSIZE30</term>
		/// <term>The width of a button in a window caption or title bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXSIZEFRAME32</term>
		/// <term>
		/// The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. SM_CXSIZEFRAME is the width
		/// of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border. This value is the same as SM_CXFRAME.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXSMICON49</term>
		/// <term>The recommended width of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXSMSIZE52</term>
		/// <term>The width of small caption buttons, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXVIRTUALSCREEN78</term>
		/// <term>
		/// The width of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors. The
		/// SM_XVIRTUALSCREEN metric is the coordinates for the left side of the virtual screen.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXVSCROLL2</term>
		/// <term>The width of a vertical scroll bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYBORDER6</term>
		/// <term>The height of a window border, in pixels. This is equivalent to the SM_CYEDGE value for windows with the 3-D look.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYCAPTION4</term>
		/// <term>The height of a caption area, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYCURSOR14</term>
		/// <term>The height of a cursor, in pixels. The system cannot create cursors of other sizes.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYDLGFRAME8</term>
		/// <term>This value is the same as SM_CYFIXEDFRAME.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYDOUBLECLK37</term>
		/// <term>
		/// The height of the rectangle around the location of a first click in a double-click sequence, in pixels. The second click must
		/// occur within the rectangle defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system to consider the two clicks a double-click.
		/// The two clicks must also occur within a specified time. To set the height of the double-click rectangle, call
		/// SystemParametersInfo with SPI_SETDOUBLECLKHEIGHT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYDRAG69</term>
		/// <term>
		/// The number of pixels above and below a mouse-down point that the mouse pointer can move before a drag operation begins. This
		/// allows the user to click and release the mouse button easily without unintentionally starting a drag operation. If this value is
		/// negative, it is subtracted from above the mouse-down point and added below it.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYEDGE46</term>
		/// <term>The height of a 3-D border, in pixels. This is the 3-D counterpart of SM_CYBORDER.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYFIXEDFRAME8</term>
		/// <term>
		/// The thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. SM_CXFIXEDFRAME is
		/// the height of the horizontal border, and SM_CYFIXEDFRAME is the width of the vertical border.This value is the same as SM_CYDLGFRAME.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYFOCUSBORDER84</term>
		/// <term>
		/// The height of the top and bottom edges of the focus rectangle drawn by DrawFocusRect. This value is in pixels.Windows 2000: This
		/// value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYFRAME33</term>
		/// <term>This value is the same as SM_CYSIZEFRAME.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYFULLSCREEN17</term>
		/// <term>
		/// The height of the client area for a full-screen window on the primary display monitor, in pixels. To get the coordinates of the
		/// portion of the screen not obscured by the system taskbar or by application desktop toolbars, call the SystemParametersInfo
		/// function with the SPI_GETWORKAREA value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYHSCROLL3</term>
		/// <term>The height of a horizontal scroll bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYICON12</term>
		/// <term>
		/// The default height of an icon, in pixels. The LoadIcon function can load only icons with the dimensions SM_CXICON and SM_CYICON.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYICONSPACING39</term>
		/// <term>
		/// The height of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size SM_CXICONSPACING by
		/// SM_CYICONSPACING when arranged. This value is always greater than or equal to SM_CYICON.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYKANJIWINDOW18</term>
		/// <term>
		/// For double byte character set versions of the system, this is the height of the Kanji window at the bottom of the screen, in pixels.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYMAXIMIZED62</term>
		/// <term>The default height, in pixels, of a maximized top-level window on the primary display monitor.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYMAXTRACK60</term>
		/// <term>
		/// The default maximum height of a window that has a caption and sizing borders, in pixels. This metric refers to the entire
		/// desktop. The user cannot drag the window frame to a size larger than these dimensions. A window can override this value by
		/// processing the WM_GETMINMAXINFO message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYMENU15</term>
		/// <term>The height of a single-line menu bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYMENUCHECK72</term>
		/// <term>The height of the default menu check-mark bitmap, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYMENUSIZE55</term>
		/// <term>
		/// The height of menu bar buttons, such as the child window close button that is used in the multiple document interface, in pixels.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYMIN29</term>
		/// <term>The minimum height of a window, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYMINIMIZED58</term>
		/// <term>The height of a minimized window, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYMINSPACING48</term>
		/// <term>
		/// The height of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged.
		/// This value is always greater than or equal to SM_CYMINIMIZED.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYMINTRACK35</term>
		/// <term>
		/// The minimum tracking height of a window, in pixels. The user cannot drag the window frame to a size smaller than these
		/// dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYSCREEN1</term>
		/// <term>
		/// The height of the screen of the primary display monitor, in pixels. This is the same value obtained by calling GetDeviceCaps as
		/// follows: .
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYSIZE31</term>
		/// <term>The height of a button in a window caption or title bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYSIZEFRAME33</term>
		/// <term>
		/// The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. SM_CXSIZEFRAME is the width
		/// of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border. This value is the same as SM_CYFRAME.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYSMCAPTION51</term>
		/// <term>The height of a small caption, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYSMICON50</term>
		/// <term>The recommended height of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYSMSIZE53</term>
		/// <term>The height of small caption buttons, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYVIRTUALSCREEN79</term>
		/// <term>
		/// The height of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors. The
		/// SM_YVIRTUALSCREEN metric is the coordinates for the top of the virtual screen.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYVSCROLL20</term>
		/// <term>The height of the arrow bitmap on a vertical scroll bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYVTHUMB9</term>
		/// <term>The height of the thumb box in a vertical scroll bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_DBCSENABLED42</term>
		/// <term>Nonzero if User32.dll supports DBCS; otherwise, 0.</term>
		/// </item>
		/// <item>
		/// <term>SM_DEBUG22</term>
		/// <term>Nonzero if the debug version of User.exe is installed; otherwise, 0.</term>
		/// </item>
		/// <item>
		/// <term>SM_DIGITIZER94</term>
		/// <term>
		/// Nonzero if the current operating system is Windows 7 or Windows Server 2008 R2 and the Tablet PC Input service is started;
		/// otherwise, 0. The return value is a bitmask that specifies the type of digitizer input supported by the device. For more
		/// information, see Remarks.Windows Server 2008, Windows Vista and Windows XP/2000: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_IMMENABLED82</term>
		/// <term>
		/// Nonzero if Input Method Manager/Input Method Editor features are enabled; otherwise, 0. SM_IMMENABLED indicates whether the
		/// system is ready to use a Unicode-based IME on a Unicode application. To ensure that a language-dependent IME works, check
		/// SM_DBCSENABLED and the system ANSI code page. Otherwise the ANSI-to-Unicode conversion may not be performed correctly, or some
		/// components like fonts or registry settings may not be present.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_MAXIMUMTOUCHES95</term>
		/// <term>
		/// Nonzero if there are digitizers in the system; otherwise, 0. SM_MAXIMUMTOUCHES returns the aggregate maximum of the maximum
		/// number of contacts supported by every digitizer in the system. If the system has only single-touch digitizers, the return value
		/// is 1. If the system has multi-touch digitizers, the return value is the number of simultaneous contacts the hardware can
		/// provide.Windows Server 2008, Windows Vista and Windows XP/2000: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_MEDIACENTER87</term>
		/// <term>Nonzero if the current operating system is the Windows XP, Media Center Edition, 0 if not.</term>
		/// </item>
		/// <item>
		/// <term>SM_MENUDROPALIGNMENT40</term>
		/// <term>Nonzero if drop-down menus are right-aligned with the corresponding menu-bar item; 0 if the menus are left-aligned.</term>
		/// </item>
		/// <item>
		/// <term>SM_MIDEASTENABLED74</term>
		/// <term>Nonzero if the system is enabled for Hebrew and Arabic languages, 0 if not.</term>
		/// </item>
		/// <item>
		/// <term>SM_MOUSEPRESENT19</term>
		/// <term>
		/// Nonzero if a mouse is installed; otherwise, 0. This value is rarely zero, because of support for virtual mice and because some
		/// systems detect the presence of the port instead of the presence of a mouse.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_MOUSEHORIZONTALWHEELPRESENT91</term>
		/// <term>Nonzero if a mouse with a horizontal scroll wheel is installed; otherwise 0.</term>
		/// </item>
		/// <item>
		/// <term>SM_MOUSEWHEELPRESENT75</term>
		/// <term>Nonzero if a mouse with a vertical scroll wheel is installed; otherwise 0.</term>
		/// </item>
		/// <item>
		/// <term>SM_NETWORK63</term>
		/// <term>
		/// The least significant bit is set if a network is present; otherwise, it is cleared. The other bits are reserved for future use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_PENWINDOWS41</term>
		/// <term>Nonzero if the Microsoft Windows for Pen computing extensions are installed; zero otherwise.</term>
		/// </item>
		/// <item>
		/// <term>SM_REMOTECONTROL0x2001</term>
		/// <term>
		/// This system metric is used in a Terminal Services environment to determine if the current Terminal Server session is being
		/// remotely controlled. Its value is nonzero if the current session is remotely controlled; otherwise, 0.You can use terminal
		/// services management tools such as Terminal Services Manager (tsadmin.msc) and shadow.exe to control a remote session. When a
		/// session is being remotely controlled, another user can view the contents of that session and potentially interact with it.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_REMOTESESSION0x1000</term>
		/// <term>
		/// This system metric is used in a Terminal Services environment. If the calling process is associated with a Terminal Services
		/// client session, the return value is nonzero. If the calling process is associated with the Terminal Services console session, the
		/// return value is 0. Windows Server 2003 and Windows XP: The console session is not necessarily the physical console. For more
		/// information, see WTSGetActiveConsoleSessionId.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_SAMEDISPLAYFORMAT81</term>
		/// <term>
		/// Nonzero if all the display monitors have the same color format, otherwise, 0. Two displays can have the same bit depth, but
		/// different color formats. For example, the red, green, and blue pixels can be encoded with different numbers of bits, or those
		/// bits can be located in different places in a pixel color value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_SECURE44</term>
		/// <term>This system metric should be ignored; it always returns 0.</term>
		/// </item>
		/// <item>
		/// <term>SM_SERVERR289</term>
		/// <term>The build number if the system is Windows Server 2003 R2; otherwise, 0.</term>
		/// </item>
		/// <item>
		/// <term>SM_SHOWSOUNDS70</term>
		/// <term>
		/// Nonzero if the user requires an application to present information visually in situations where it would otherwise present the
		/// information only in audible form; otherwise, 0.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_SHUTTINGDOWN0x2000</term>
		/// <term>Nonzero if the current session is shutting down; otherwise, 0. Windows 2000: This value is not supported.</term>
		/// </item>
		/// <item>
		/// <term>SM_SLOWMACHINE73</term>
		/// <term>Nonzero if the computer has a low-end (slow) processor; otherwise, 0.</term>
		/// </item>
		/// <item>
		/// <term>SM_STARTER88</term>
		/// <term>
		/// Nonzero if the current operating system is Windows 7 Starter Edition, Windows Vista Starter, or Windows XP Starter Edition;
		/// otherwise, 0.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_SWAPBUTTON23</term>
		/// <term>Nonzero if the meanings of the left and right mouse buttons are swapped; otherwise, 0.</term>
		/// </item>
		/// <item>
		/// <term>SM_SYSTEMDOCKED0x2004</term>
		/// <term>
		/// Reflects the state of the docking mode, 0 for Undocked Mode and non-zero otherwise. When this system metric changes, the system
		/// sends a broadcast message via WM_SETTINGCHANGE with &amp;quot;SystemDockMode&amp;quot; in the LPARAM.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_TABLETPC86</term>
		/// <term>
		/// Nonzero if the current operating system is the Windows XP Tablet PC edition or if the current operating system is Windows Vista
		/// or Windows 7 and the Tablet PC Input service is started; otherwise, 0. The SM_DIGITIZER setting indicates the type of digitizer
		/// input supported by a device running Windows 7 or Windows Server 2008 R2. For more information, see Remarks.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_XVIRTUALSCREEN76</term>
		/// <term>
		/// The coordinates for the left side of the virtual screen. The virtual screen is the bounding rectangle of all display monitors.
		/// The SM_CXVIRTUALSCREEN metric is the width of the virtual screen.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_YVIRTUALSCREEN77</term>
		/// <term>
		/// The coordinates for the top of the virtual screen. The virtual screen is the bounding rectangle of all display monitors. The
		/// SM_CYVIRTUALSCREEN metric is the height of the virtual screen.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type:</para>
		/// <para>If the function succeeds, the return value is the requested system metric or configuration setting.</para>
		/// <para>If the function fails, the return value is 0. <c>GetLastError</c> does not provide extended error information.</para>
		/// </returns>
		// int WINAPI GetSystemMetrics( _In_ int nIndex); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724385(v=vs.85).aspx
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winuser.h", MSDNShortId = "ms724385")]
		public static extern int GetSystemMetrics(SystemMetric nIndex);

		/// <summary>Locks the workstation's display, protecting it from unauthorized use.</summary>
		/// <returns>0 on failure, non-zero for success</returns>
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("Winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool LockWorkStation();

		/// <summary>Returns strings for standard message box buttons.</summary>
		/// <param name="wBtn">The id of the string to return. These are identified by the Dialog Box Command ID values listed in winuser.h.</param>
		/// <returns>The string, or NULL if not found.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/dlgbox/mb-getstring LPCWSTR WINAPI MB_GetString( UINT wBtn );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("", MSDNShortId = "D2AF238D-F5A8-477D-BF47-0F5D4D68B27E")]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		public static extern string MB_GetString(uint wBtn);

		/// <summary>
		/// <para>Plays a waveform sound. The waveform sound for each sound type is identified by an entry in the registry.</para>
		/// </summary>
		/// <param name="uType">
		/// <para>
		/// The sound to be played. The sounds are set by the user through the Sound control panel application, and then stored in the registry.
		/// </para>
		/// <para>This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0xFFFFFFFF</term>
		/// <term>A simple beep. If the sound card is not available, the sound is generated using the speaker.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONASTERISK 0x00000040L</term>
		/// <term>See MB_ICONINFORMATION.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONEXCLAMATION 0x00000030L</term>
		/// <term>See MB_ICONWARNING.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONERROR 0x00000010L</term>
		/// <term>The sound specified as the Windows Critical Stop sound.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONHAND 0x00000010L</term>
		/// <term>See MB_ICONERROR.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONINFORMATION 0x00000040L</term>
		/// <term>The sound specified as the Windows Asterisk sound.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONQUESTION 0x00000020L</term>
		/// <term>The sound specified as the Windows Question sound.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONSTOP 0x00000010L</term>
		/// <term>See MB_ICONERROR.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONWARNING 0x00000030L</term>
		/// <term>The sound specified as the Windows Exclamation sound.</term>
		/// </item>
		/// <item>
		/// <term>MB_OK 0x00000000L</term>
		/// <term>The sound specified as the Windows Default Beep sound.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>After queuing the sound, the <c>MessageBeep</c> function returns control to the calling function and plays the sound asynchronously.</para>
		/// <para>
		/// If it cannot play the specified alert sound, <c>MessageBeep</c> attempts to play the system default sound. If it cannot play the
		/// system default sound, the function produces a standard beep sound through the computer speaker.
		/// </para>
		/// <para>The user can disable the warning beep by using the Sound control panel application.</para>
		/// <para>
		/// <c>Note</c> To send a beep to a remote client, use the Beep function. The <c>Beep</c> function is redirected to the client,
		/// whereas <c>MessageBeep</c> is not.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-messagebeep BOOL MessageBeep( UINT uType );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "70681472-36a5-4ae3-b769-0421cf97ff2a")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MessageBeep(uint uType);

		/// <summary>
		/// <para>
		/// Displays a modal dialog box that contains a system icon, a set of buttons, and a brief application-specific message, such as
		/// status or error information. The message box returns an integer value that indicates which button the user clicked.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the owner window of the message box to be created. If this parameter is <c>NULL</c>, the message box has no owner window.
		/// </para>
		/// </param>
		/// <param name="lpText">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The message to be displayed. If the string consists of more than one line, you can separate the lines using a carriage return
		/// and/or linefeed character between each line.
		/// </para>
		/// </param>
		/// <param name="lpCaption">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The dialog box title. If this parameter is <c>NULL</c>, the default title is <c>Error</c>.</para>
		/// </param>
		/// <param name="uType">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The contents and behavior of the dialog box. This parameter can be a combination of flags from the following groups of flags.
		/// </para>
		/// <para>To indicate the buttons displayed in the message box, specify one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MB_ABORTRETRYIGNORE 0x00000002L</term>
		/// <term>The message box contains three push buttons: Abort, Retry, and Ignore.</term>
		/// </item>
		/// <item>
		/// <term>MB_CANCELTRYCONTINUE 0x00000006L</term>
		/// <term>The message box contains three push buttons: Cancel, Try Again, Continue. Use this message box type instead of MB_ABORTRETRYIGNORE.</term>
		/// </item>
		/// <item>
		/// <term>MB_HELP 0x00004000L</term>
		/// <term>
		/// Adds a Help button to the message box. When the user clicks the Help button or presses F1, the system sends a WM_HELP message to
		/// the owner.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MB_OK 0x00000000L</term>
		/// <term>The message box contains one push button: OK. This is the default.</term>
		/// </item>
		/// <item>
		/// <term>MB_OKCANCEL 0x00000001L</term>
		/// <term>The message box contains two push buttons: OK and Cancel.</term>
		/// </item>
		/// <item>
		/// <term>MB_RETRYCANCEL 0x00000005L</term>
		/// <term>The message box contains two push buttons: Retry and Cancel.</term>
		/// </item>
		/// <item>
		/// <term>MB_YESNO 0x00000004L</term>
		/// <term>The message box contains two push buttons: Yes and No.</term>
		/// </item>
		/// <item>
		/// <term>MB_YESNOCANCEL 0x00000003L</term>
		/// <term>The message box contains three push buttons: Yes, No, and Cancel.</term>
		/// </item>
		/// </list>
		/// <para>To display an icon in the message box, specify one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MB_ICONEXCLAMATION 0x00000030L</term>
		/// <term>An exclamation-point icon appears in the message box.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONWARNING 0x00000030L</term>
		/// <term>An exclamation-point icon appears in the message box.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONINFORMATION 0x00000040L</term>
		/// <term>An icon consisting of a lowercase letter i in a circle appears in the message box.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONASTERISK 0x00000040L</term>
		/// <term>An icon consisting of a lowercase letter i in a circle appears in the message box.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONQUESTION 0x00000020L</term>
		/// <term>
		/// A question-mark icon appears in the message box. The question-mark message icon is no longer recommended because it does not
		/// clearly represent a specific type of message and because the phrasing of a message as a question could apply to any message type.
		/// In addition, users can confuse the message symbol question mark with Help information. Therefore, do not use this question mark
		/// message symbol in your message boxes. The system continues to support its inclusion only for backward compatibility.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MB_ICONSTOP 0x00000010L</term>
		/// <term>A stop-sign icon appears in the message box.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONERROR 0x00000010L</term>
		/// <term>A stop-sign icon appears in the message box.</term>
		/// </item>
		/// <item>
		/// <term>MB_ICONHAND 0x00000010L</term>
		/// <term>A stop-sign icon appears in the message box.</term>
		/// </item>
		/// </list>
		/// <para>To indicate the default button, specify one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MB_DEFBUTTON1 0x00000000L</term>
		/// <term>
		/// The first button is the default button. MB_DEFBUTTON1 is the default unless MB_DEFBUTTON2, MB_DEFBUTTON3, or MB_DEFBUTTON4 is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MB_DEFBUTTON2 0x00000100L</term>
		/// <term>The second button is the default button.</term>
		/// </item>
		/// <item>
		/// <term>MB_DEFBUTTON3 0x00000200L</term>
		/// <term>The third button is the default button.</term>
		/// </item>
		/// <item>
		/// <term>MB_DEFBUTTON4 0x00000300L</term>
		/// <term>The fourth button is the default button.</term>
		/// </item>
		/// </list>
		/// <para>To indicate the modality of the dialog box, specify one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MB_APPLMODAL 0x00000000L</term>
		/// <term>
		/// The user must respond to the message box before continuing work in the window identified by the hWnd parameter. However, the user
		/// can move to the windows of other threads and work in those windows. Depending on the hierarchy of windows in the application, the
		/// user may be able to move to other windows within the thread. All child windows of the parent of the message box are automatically
		/// disabled, but pop-up windows are not. MB_APPLMODAL is the default if neither MB_SYSTEMMODAL nor MB_TASKMODAL is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MB_SYSTEMMODAL 0x00001000L</term>
		/// <term>
		/// Same as MB_APPLMODAL except that the message box has the WS_EX_TOPMOST style. Use system-modal message boxes to notify the user
		/// of serious, potentially damaging errors that require immediate attention (for example, running out of memory). This flag has no
		/// effect on the user's ability to interact with windows other than those associated with hWnd.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MB_TASKMODAL 0x00002000L</term>
		/// <term>
		/// Same as MB_APPLMODAL except that all the top-level windows belonging to the current thread are disabled if the hWnd parameter is
		/// NULL. Use this flag when the calling application or library does not have a window handle available but still needs to prevent
		/// input to other windows in the calling thread without suspending other threads.
		/// </term>
		/// </item>
		/// </list>
		/// <para>To specify other options, use one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MB_DEFAULT_DESKTOP_ONLY 0x00020000L</term>
		/// <term>
		/// Same as desktop of the interactive window station. For more information, see Window Stations. If the current input desktop is not
		/// the default desktop, MessageBox does not return until the user switches to the default desktop.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MB_RIGHT 0x00080000L</term>
		/// <term>The text is right-justified.</term>
		/// </item>
		/// <item>
		/// <term>MB_RTLREADING 0x00100000L</term>
		/// <term>Displays message and caption text using right-to-left reading order on Hebrew and Arabic systems.</term>
		/// </item>
		/// <item>
		/// <term>MB_SETFOREGROUND 0x00010000L</term>
		/// <term>
		/// The message box becomes the foreground window. Internally, the system calls the SetForegroundWindow function for the message box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MB_TOPMOST 0x00040000L</term>
		/// <term>The message box is created with the WS_EX_TOPMOST window style.</term>
		/// </item>
		/// <item>
		/// <term>MB_SERVICE_NOTIFICATION 0x00200000L</term>
		/// <term>
		/// The caller is a service notifying the user of an event. The function displays a message box on the current active desktop, even
		/// if there is no user logged on to the computer. Terminal Services: If the calling thread has an impersonation token, the function
		/// directs the message box to the session specified in the impersonation token. If this flag is set, the hWnd parameter must be
		/// NULL. This is so that the message box can appear on a desktop other than the desktop corresponding to the hWnd. For information
		/// on security considerations in regard to using this flag, see Interactive Services. In particular, be aware that this flag can
		/// produce interactive content on a locked desktop and should therefore be used for only a very limited set of scenarios, such as
		/// resource exhaustion.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// If a message box has a <c>Cancel</c> button, the function returns the <c>IDCANCEL</c> value if either the ESC key is pressed or
		/// the <c>Cancel</c> button is selected. If the message box has no <c>Cancel</c> button, pressing ESC has no effect.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// <para>If the function succeeds, the return value is one of the following menu-item values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>IDABORT 3</term>
		/// <term>The Abort button was selected.</term>
		/// </item>
		/// <item>
		/// <term>IDCANCEL 2</term>
		/// <term>The Cancel button was selected.</term>
		/// </item>
		/// <item>
		/// <term>IDCONTINUE 11</term>
		/// <term>The Continue button was selected.</term>
		/// </item>
		/// <item>
		/// <term>IDIGNORE 5</term>
		/// <term>The Ignore button was selected.</term>
		/// </item>
		/// <item>
		/// <term>IDNO 7</term>
		/// <term>The No button was selected.</term>
		/// </item>
		/// <item>
		/// <term>IDOK 1</term>
		/// <term>The OK button was selected.</term>
		/// </item>
		/// <item>
		/// <term>IDRETRY 4</term>
		/// <term>The Retry button was selected.</term>
		/// </item>
		/// <item>
		/// <term>IDTRYAGAIN 10</term>
		/// <term>The Try Again button was selected.</term>
		/// </item>
		/// <item>
		/// <term>IDYES 6</term>
		/// <term>The Yes button was selected.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The following system icons can be used in a message box by setting the uType parameter to the corresponding flag value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Icon</term>
		/// <term>Flag values</term>
		/// </listheader>
		/// <item>
		/// <term/>
		/// <term>MB_ICONHAND, MB_ICONSTOP, or MB_ICONERROR</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>MB_ICONQUESTION</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>MB_ICONEXCLAMATION or MB_ICONWARNING</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>MB_ICONASTERISK or MB_ICONINFORMATION</term>
		/// </item>
		/// </list>
		/// <para>
		/// Adding two right-to-left marks (RLMs), represented by Unicode formatting character U+200F, in the beginning of a MessageBox
		/// display string is interpreted by the MessageBox rendering engine so as to cause the reading order of the MessageBox to be
		/// rendered as right-to-left (RTL).
		/// </para>
		/// <para>
		/// When you use a system-modal message box to indicate that the system is low on memory, the strings pointed to by the lpText and
		/// lpCaption parameters should not be taken from a resource file because an attempt to load the resource may fail.
		/// </para>
		/// <para>
		/// If you create a message box while a dialog box is present, use a handle to the dialog box as the hWnd parameter. The hWnd
		/// parameter should not identify a child window, such as a control in a dialog box.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// In the following example, the application displays a message box that prompts the user for an action after an error condition has
		/// occurred. The message box displays the message that describes the error condition and how to resolve it. The
		/// <c>MB_CANCELTRYCONTINUE</c> style directs <c>MessageBox</c> to provide three buttons with which the user can choose how to
		/// proceed. The <c>MB_DEFBUTTON2</c> style sets the default focus on the second button of the message box, in this case, the <c>Try
		/// Again</c> button.
		/// </para>
		/// <para>The following image shows the output from the preceding code example:</para>
		/// <para>For another message box example, see Displaying a Message Box.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-messagebox int MessageBox( HWND hWnd, LPCTSTR lpText,
		// LPCTSTR lpCaption, UINT uType );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "messagebox")]
		public static extern MB_RESULT MessageBox(HWND hWnd, string lpText, string lpCaption, MB_FLAGS uType);

		/// <summary>
		/// Creates, displays, and operates a message box. The message box contains application-defined message text and title, any icon, and
		/// any combination of predefined push buttons.
		/// </summary>
		/// <param name="lpMsgBoxParams">A pointer to a MSGBOXPARAMS structure that contains information used to display the message box.</param>
		/// <returns>
		/// If the function succeeds, the return value is one of the following menu-item values.
		/// <para>
		/// If a message box has a Cancel button, the function returns the IDCANCEL value if either the ESC key is pressed or the Cancel
		/// button is selected.If the message box has no Cancel button, pressing ESC has no effect.
		/// </para>
		/// <para>If there is not enough memory to create the message box, the return value is zero.</para>
		/// </returns>
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winuser.h")]
		public static extern MB_RESULT MessageBoxIndirect(in MSGBOXPARAMS lpMsgBoxParams);

		/// <summary>
		/// Indicates that the system cannot be shut down and sets a reason string to be displayed to the user if system shutdown is initiated.
		/// </summary>
		/// <param name="hWnd">A handle to the main window of the application.</param>
		/// <param name="reason">
		/// The reason the application must block system shutdown. This string will be truncated for display purposes after
		/// MAX_STR_BLOCKREASON characters.
		/// </param>
		/// <returns>
		/// If the call succeeds, the return value is nonzero. If the call fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShutdownBlockReasonCreate(HWND hWnd, [MarshalAs(UnmanagedType.LPWStr)] string reason);

		/// <summary>Indicates that the system can be shut down and frees the reason string.</summary>
		/// <param name="hWnd">A handle to the main window of the application.</param>
		/// <returns>
		/// If the call succeeds, the return value is nonzero. If the call fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShutdownBlockReasonDestroy(HWND hWnd);

		/// <summary>Retrieves the reason string set by the <see cref="ShutdownBlockReasonCreate"/> function.</summary>
		/// <param name="hWnd">A handle to the main window of the application.</param>
		/// <param name="pwszBuff">
		/// A pointer to a buffer that receives the reason string. If this parameter is NULL, the function retrieves the number of characters
		/// in the reason string.
		/// </param>
		/// <param name="pcchBuff">
		/// A pointer to a variable that specifies the size of the pwszBuff buffer, in characters. If the function succeeds, this variable
		/// receives the number of characters copied into the buffer, including the null-terminating character. If the buffer is too small,
		/// the variable receives the required buffer size, in characters, not including the null-terminating character.
		/// </param>
		/// <returns>
		/// If the call succeeds, the return value is nonzero. If the call fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShutdownBlockReasonQuery(HWND hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, ref uint pcchBuff);

		/// <summary>Retrieves the reason string set by the <see cref="ShutdownBlockReasonCreate"/> function.</summary>
		/// <param name="hWnd">A handle to the main window of the application.</param>
		/// <param name="reason">On success, receives the reason string.</param>
		/// <returns>
		/// If the call succeeds, the return value is nonzero. If the call fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		public static bool ShutdownBlockReasonQuery(HWND hWnd, out string reason)
		{
			uint sz = 0;
			reason = null;
			if (!ShutdownBlockReasonQuery(hWnd, null, ref sz)) return false;
			var sb = new StringBuilder((int)sz);
			if (!ShutdownBlockReasonQuery(hWnd, sb, ref sz)) return false;
			reason = sb.ToString();
			return true;
		}

		/// <summary>
		/// Retrieves or sets the value of one of the system-wide parameters. This function can also update the user profile while setting a parameter.
		/// </summary>
		/// <param name="uiAction">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The system-wide parameter to be retrieved or set. The possible values are organized in the following tables of related parameters:
		/// </para>
		/// </param>
		/// <param name="uiParam">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A parameter whose usage and format depends on the system parameter being queried or set. For more information about system-wide
		/// parameters, see the uiAction parameter. If not otherwise indicated, you must specify zero for this parameter.
		/// </para>
		/// </param>
		/// <param name="pvParam">
		/// <para>Type: <c>PVOID</c></para>
		/// <para>
		/// A parameter whose usage and format depends on the system parameter being queried or set. For more information about system-wide
		/// parameters, see the uiAction parameter. If not otherwise indicated, you must specify <c>NULL</c> for this parameter. For
		/// information on the <c>PVOID</c> datatype, see <c>Windows Data Types</c>.
		/// </para>
		/// </param>
		/// <param name="fWinIni">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// If a system parameter is being set, specifies whether the user profile is to be updated, and if so, whether the
		/// <c>WM_SETTINGCHANGE</c> message is to be broadcast to all top-level windows to notify them of the change.
		/// </para>
		/// <para>
		/// This parameter can be zero if you do not want to update the user profile or broadcast the <c>WM_SETTINGCHANGE</c> message, or it
		/// can be one or more of the following values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SPIF_UPDATEINIFILE</term>
		/// <term>Writes the new system-wide parameter setting to the user profile.</term>
		/// </item>
		/// <item>
		/// <term>SPIF_SENDCHANGE</term>
		/// <term>Broadcasts the WM_SETTINGCHANGE message after updating the user profile.</term>
		/// </item>
		/// <item>
		/// <term>SPIF_SENDWININICHANGE</term>
		/// <term>Same as SPIF_SENDCHANGE.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type:</para>
		/// <para>If the function succeeds, the return value is a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SystemParametersInfo( _In_ UINT uiAction, _In_ UINT uiParam, _Inout_ PVOID pvParam, _In_ UINT fWinIni); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724947(v=vs.85).aspx
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winuser.h", MSDNShortId = "ms724947")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, IntPtr pvParam, SPIF fWinIni);

		/// <summary>
		/// Retrieves or sets the value of one of the system-wide parameters. This function can also update the user profile while setting a parameter.
		/// </summary>
		/// <param name="uiAction">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The system-wide parameter to be retrieved or set. The possible values are organized in the following tables of related parameters:
		/// </para>
		/// </param>
		/// <param name="uiParam">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A parameter whose usage and format depends on the system parameter being queried or set. For more information about system-wide
		/// parameters, see the uiAction parameter. If not otherwise indicated, you must specify zero for this parameter.
		/// </para>
		/// </param>
		/// <param name="pvParam">
		/// <para>Type: <c>PVOID</c></para>
		/// <para>
		/// A parameter whose usage and format depends on the system parameter being queried or set. For more information about system-wide
		/// parameters, see the uiAction parameter. If not otherwise indicated, you must specify <c>NULL</c> for this parameter. For
		/// information on the <c>PVOID</c> datatype, see <c>Windows Data Types</c>.
		/// </para>
		/// </param>
		/// <param name="fWinIni">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// If a system parameter is being set, specifies whether the user profile is to be updated, and if so, whether the
		/// <c>WM_SETTINGCHANGE</c> message is to be broadcast to all top-level windows to notify them of the change.
		/// </para>
		/// <para>
		/// This parameter can be zero if you do not want to update the user profile or broadcast the <c>WM_SETTINGCHANGE</c> message, or it
		/// can be one or more of the following values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SPIF_UPDATEINIFILE</term>
		/// <term>Writes the new system-wide parameter setting to the user profile.</term>
		/// </item>
		/// <item>
		/// <term>SPIF_SENDCHANGE</term>
		/// <term>Broadcasts the WM_SETTINGCHANGE message after updating the user profile.</term>
		/// </item>
		/// <item>
		/// <term>SPIF_SENDWININICHANGE</term>
		/// <term>Same as SPIF_SENDCHANGE.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type:</para>
		/// <para>If the function succeeds, the return value is a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SystemParametersInfo( _In_ UINT uiAction, _In_ UINT uiParam, _Inout_ PVOID pvParam, _In_ UINT fWinIni); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724947(v=vs.85).aspx
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winuser.h", MSDNShortId = "ms724947")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, string pvParam, SPIF fWinIni);

		/// <summary>
		/// Retrieves or sets the value of one of the system-wide parameters. This function can also update the user profile while setting a parameter.
		/// </summary>
		/// <param name="uiAction">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The system-wide parameter to be retrieved or set. The possible values are organized in the following tables of related parameters:
		/// </para>
		/// </param>
		/// <param name="uiParam">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A parameter whose usage and format depends on the system parameter being queried or set. For more information about system-wide
		/// parameters, see the uiAction parameter. If not otherwise indicated, you must specify zero for this parameter.
		/// </para>
		/// </param>
		/// <param name="pvParam">
		/// <para>Type: <c>PVOID</c></para>
		/// <para>
		/// A parameter whose usage and format depends on the system parameter being queried or set. For more information about system-wide
		/// parameters, see the uiAction parameter. If not otherwise indicated, you must specify <c>NULL</c> for this parameter. For
		/// information on the <c>PVOID</c> datatype, see <c>Windows Data Types</c>.
		/// </para>
		/// </param>
		/// <param name="fWinIni">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// If a system parameter is being set, specifies whether the user profile is to be updated, and if so, whether the
		/// <c>WM_SETTINGCHANGE</c> message is to be broadcast to all top-level windows to notify them of the change.
		/// </para>
		/// <para>
		/// This parameter can be zero if you do not want to update the user profile or broadcast the <c>WM_SETTINGCHANGE</c> message, or it
		/// can be one or more of the following values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SPIF_UPDATEINIFILE</term>
		/// <term>Writes the new system-wide parameter setting to the user profile.</term>
		/// </item>
		/// <item>
		/// <term>SPIF_SENDCHANGE</term>
		/// <term>Broadcasts the WM_SETTINGCHANGE message after updating the user profile.</term>
		/// </item>
		/// <item>
		/// <term>SPIF_SENDWININICHANGE</term>
		/// <term>Same as SPIF_SENDCHANGE.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type:</para>
		/// <para>If the function succeeds, the return value is a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SystemParametersInfo( _In_ UINT uiAction, _In_ UINT uiParam, _Inout_ PVOID pvParam, _In_ UINT fWinIni); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724947(v=vs.85).aspx
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winuser.h", MSDNShortId = "ms724947")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, StringBuilder pvParam, SPIF fWinIni);

		/// <summary>Retrives the value of one of the system-wide parameters.</summary>
		/// <typeparam name="T">The type of the value to retrieve.</typeparam>
		/// <param name="uiAction">The system-wide parameter to retrieve.</param>
		/// <param name="getValue">The value to retrieve.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <see langword="true"/>.</para>
		/// <para>If the function fails, the return value is <see langword="false"/>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		/// <exception cref="ArgumentException">Type mismatch. - getValue</exception>
		public static bool SystemParametersInfo<T>(SPI uiAction, out T getValue) where T : struct
		{
			if (!CorrespondingTypeAttribute.CanGet(uiAction, typeof(T))) throw new ArgumentException("Type mismatch.", nameof(getValue));
			SPIF spif = 0;
			var isBool = typeof(T) == typeof(bool);
			var uv = isBool ? 4u : (uint)Marshal.SizeOf(typeof(T));
			using (var ptr = new SafeHGlobalHandle((int)uv))
			{
				if (isBool || uv <= sizeof(uint)) uv = 0;
				getValue = default;
				if (!SystemParametersInfo(uiAction, uv, (IntPtr)ptr, spif))
					return false;
				getValue = isBool ? (T)(object)(ptr.ToStructure<uint>() > 0) : ptr.ToStructure<T>();
				return true;
			}
		}

		/// <summary>Sets the value of one of the system-wide parameters. This function can also update the user profile.</summary>
		/// <typeparam name="T">The type of the value being set.</typeparam>
		/// <param name="uiAction">The system-wide parameter to be set.</param>
		/// <param name="setValue">The value to set.</param>
		/// <param name="updateUserProfile">if set to <c>true</c> writes the new system-wide parameter setting to the user profile.</param>
		/// <param name="broadcastChange">if set to <c>true</c> broadcasts the WM_SETTINGCHANGE message after updating the user profile.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <see langword="true"/>.</para>
		/// <para>If the function fails, the return value is <see langword="false"/>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		/// <exception cref="ArgumentException">Type mismatch. - setValue</exception>
		public static bool SystemParametersInfo<T>(SPI uiAction, T setValue, bool updateUserProfile = false, bool broadcastChange = true) where T : struct
		{
			if (!CorrespondingTypeAttribute.CanSet(uiAction, typeof(T))) throw new ArgumentException("Type mismatch.", nameof(setValue));
			var spif = (updateUserProfile ? SPIF.SPIF_UPDATEINIFILE : 0) | (broadcastChange ? SPIF.SPIF_SENDCHANGE : 0);
			if (SPCorrespondingTypeAttribute.UseUI(uiAction))
				return SystemParametersInfo(uiAction, (uint)Convert.ChangeType(setValue, typeof(uint)), IntPtr.Zero, spif);
			else
			{
				var isBool = typeof(T) == typeof(bool);
				using (var ptr = isBool ? SafeHGlobalHandle.CreateFromStructure((uint)Convert.ChangeType(setValue, typeof(uint))) : SafeHGlobalHandle.CreateFromStructure(setValue))
				{
					var uv = isBool ? 0 : (uint)Marshal.SizeOf(typeof(T));
					if (uv <= sizeof(uint)) uv = 0;
					return SystemParametersInfo(uiAction, uv, (IntPtr)ptr, spif);
				}
			}
		}

		/// <summary>
		/// Contains information about the time-out period associated with the Microsoft Win32 accessibility features.
		/// <para>
		/// The accessibility time-out period is the length of time that must pass without keyboard and mouse input before the operating
		/// system automatically turns off accessibility features.The accessibility time-out is designed for computers that are shared by
		/// several users so that options selected by one user do not inconvenience a subsequent user.
		/// </para>
		/// <para>
		/// The accessibility features affected by the time-out are the FilterKeys features(SlowKeys, BounceKeys, and RepeatKeys), MouseKeys,
		/// ToggleKeys, and StickyKeys.The accessibility time-out also affects the high contrast mode setting.
		/// </para>
		/// </summary>
		[PInvokeData("Winuser.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ACCESSTIMEOUT
		{
			/// <summary>Specifies the size, in bytes, of this structure.</summary>
			public uint cbSize;

			/// <summary>A set of bit flags that specify properties of the time-out behavior for accessibility features.</summary>
			public ATF dwFlags;

			/// <summary>Specifies the time-out period, in milliseconds.</summary>
			public uint iTimeOutMSec;
		}

		/// <summary>
		/// Describes the animation effects associated with user actions. This structure is used with the <c>SystemParametersInfo</c>
		/// function when the SPI_GETANIMATION or SPI_SETANIMATION action value is specified.
		/// </summary>
		// typedef struct tagANIMATIONINFO { UINT cbSize; int iMinAnimate;} ANIMATIONINFO, *LPANIMATIONINFO; https://msdn.microsoft.com/en-us/library/windows/desktop/ms724197(v=vs.85).aspx
		[PInvokeData("Winuser.h", MSDNShortId = "ms724197")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ANIMATIONINFO
		{
			/// <summary>The size of the structure, in bytes. The caller must set this to .</summary>
			public uint cbSize;

			/// <summary>If this member is nonzero, minimize and restore animation is enabled; otherwise it is disabled.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool iMinAnimate;
		}

		/// <summary>
		/// Contains information associated with audio descriptions. This structure is used with the <c>SystemParametersInfo</c> function
		/// when the SPI_GETAUDIODESCRIPTION or SPI_SETAUDIODESCRIPTION action value is specified.
		/// </summary>
		// typedef struct tagAUDIODESCRIPTION { UINT cbSize; BOOL Enabled; LCID Locale;} AUDIODESCRIPTION, *LPAUDIODESCRIPTION; https://msdn.microsoft.com/en-us/library/windows/desktop/aa379651(v=vs.85).aspx
		[PInvokeData("Winuser.h", MSDNShortId = "aa379651")]
		[StructLayout(LayoutKind.Sequential)]
		public struct AUDIODESCRIPTION
		{
			/// <summary>The size of the structure, in bytes. The caller must set this member to .</summary>
			public uint cbSize;

			/// <summary>If this member is <c>TRUE</c>, audio descriptions are enabled; Otherwise, this member is <c>FALSE</c>.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool Enabled;

			/// <summary>
			/// The locale identifier (LCID) of the language for the audio description. For more information, see Locales and Languages.
			/// </summary>
			public uint Locale;
		}

		/// <summary>
		/// Contains information about the FilterKeys accessibility feature, which enables a user with disabilities to set the keyboard
		/// repeat rate (RepeatKeys), acceptance delay (SlowKeys), and bounce rate (BounceKeys).
		/// </summary>
		[PInvokeData("Winuser.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct FILTERKEYS
		{
			/// <summary>Specifies the structure size, in bytes.</summary>
			public uint cbSize;

			/// <summary>A set of bit flags that specify properties of the FilterKeys feature.</summary>
			public FKF dwFlags;

			/// <summary>
			/// Specifies the length of time, in milliseconds, that the user must hold down a key before it is accepted by the computer.
			/// </summary>
			public uint iWaitMSec;

			/// <summary>Specifies the length of time, in milliseconds, that the user must hold down a key before it begins to repeat.</summary>
			public uint iDelayMSec;

			/// <summary>Specifies the length of time, in milliseconds, between each repetition of the keystroke.</summary>
			public uint iRepeatMSec;

			/// <summary>
			/// Specifies the length of time, in milliseconds, that must elapse after releasing a key before the computer will accept a
			/// subsequent press of the same key.
			/// </summary>
			public uint iBounceMSec;
		}

		/// <summary>Contains information about an item for which context-sensitive Help has been requested.</summary>
		[PInvokeData("Winuser.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct HELPINFO
		{
			/// <summary>The structure size, in bytes.</summary>
			public uint cbSize;

			/// <summary>The type of context for which Help is requested. This member can be one of the following values.</summary>
			public HELPINFOCONTEXT iContextType;

			/// <summary>
			/// The identifier of the window or control if iContextType is HELPINFO_WINDOW, or identifier of the menu item if iContextType is HELPINFO_MENUITEM.
			/// </summary>
			public int iCtrlId;

			/// <summary>
			/// The identifier of the child window or control if iContextType is HELPINFO_WINDOW, or identifier of the associated menu if
			/// iContextType is HELPINFO_MENUITEM.
			/// </summary>
			public IntPtr hItemHandle;

			/// <summary>The help context identifier of the window or control.</summary>
			public IntPtr dwContextId;

			/// <summary>
			/// The POINT structure that contains the screen coordinates of the mouse cursor. This is useful for providing Help based on the
			/// position of the mouse cursor.
			/// </summary>
			public System.Drawing.Point MousePos;
		}

		/// <summary>
		/// Contains information about the high contrast accessibility feature. This feature sets the appearance scheme of the user interface
		/// for maximum visibility for a visually-impaired user, and advises applications to comply with this appearance scheme.
		/// </summary>
		[PInvokeData("Winuser.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct HIGHCONTRAST
		{
			/// <summary>Specifies the size, in bytes, of this structure.</summary>
			public uint cbSize;

			/// <summary>A set of bit flags that specify properties of the HighContrast feature.</summary>
			public HFC dwFlags;

			/// <summary>Points to a string that contains the name of the color scheme that will be set to the default scheme.</summary>
			public string lpszDefaultScheme;
		}

		/// <summary>
		/// Contains the scalable metrics associated with icons. This structure is used with the SystemParametersInfo function when the
		/// SPI_GETICONMETRICS or SPI_SETICONMETRICS action is specified.
		/// </summary>
		[PInvokeData("Winuser.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ICONMETRICS
		{
			/// <summary>The size of the structure, in bytes.</summary>
			public uint cbSize;

			/// <summary>The horizontal space, in pixels, for each arranged icon.</summary>
			public int iHorzSpacing;

			/// <summary>The vertical space, in pixels, for each arranged icon.</summary>
			public int iVertSpacing;

			/// <summary>If this member is nonzero, icon titles wrap to a new line.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool iTitleWrap;

			/// <summary>The font to use for icon titles.</summary>
			public LOGFONT lfFont;
		}

		/// <summary>
		/// Contains the scalable metrics associated with minimized windows. This structure is used with the <c>SystemParametersInfo</c>
		/// function when the SPI_GETMINIMIZEDMETRICS or SPI_SETMINIMIZEDMETRICS action value is specified.
		/// </summary>
		// typedef struct tagMINIMIZEDMETRICS { UINT cbSize; int iWidth; int iHorzGap; int iVertGap; int iArrange;} MINIMIZEDMETRICS, *PMINIMIZEDMETRICS,
		// *LPMINIMIZEDMETRICS; https://msdn.microsoft.com/en-us/library/windows/desktop/ms724500(v=vs.85).aspx
		[PInvokeData("Winuser.h", MSDNShortId = "ms724500")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct MINIMIZEDMETRICS
		{
			/// <summary>The size of the structure, in bytes. The caller must set this to .</summary>
			public uint cbSize;

			/// <summary>The width of minimized windows, in pixels.</summary>
			public int iWidth;

			/// <summary>The horizontal space between arranged minimized windows, in pixels.</summary>
			public int iHorzGap;

			/// <summary>The vertical space between arranged minimized windows, in pixels.</summary>
			public int iVertGap;

			/// <summary>
			/// <para>
			/// The starting position and direction used when arranging minimized windows. The starting position must be one of the following values.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ARW_BOTTOMLEFT0x0000L</term>
			/// <term>Start at the lower-left corner of the work area.</term>
			/// </item>
			/// <item>
			/// <term>ARW_BOTTOMRIGHT0x0001L</term>
			/// <term>Start at the lower-right corner of the work area.</term>
			/// </item>
			/// <item>
			/// <term>ARW_TOPLEFT0x0002L</term>
			/// <term>Start at the upper-left corner of the work area.</term>
			/// </item>
			/// <item>
			/// <term>ARW_TOPRIGHT0x0003L</term>
			/// <term>Start at the upper-right corner of the work area.</term>
			/// </item>
			/// </list>
			/// </para>
			/// <para>The direction must be one of the following values.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ARW_LEFT0x0000L</term>
			/// <term>Arrange left (valid with ARW_BOTTOMRIGHT and ARW_TOPRIGHT only).</term>
			/// </item>
			/// <item>
			/// <term>ARW_RIGHT0x0000L</term>
			/// <term>Arrange right (valid with ARW_BOTTOMLEFT and ARW_TOPLEFT only).</term>
			/// </item>
			/// <item>
			/// <term>ARW_UP0x0004L</term>
			/// <term>Arrange up (valid with ARW_BOTTOMLEFT and ARW_BOTTOMRIGHT only).</term>
			/// </item>
			/// <item>
			/// <term>ARW_DOWN0x0004L</term>
			/// <term>Arrange down (valid with ARW_TOPLEFT and ARW_TOPRIGHT only).</term>
			/// </item>
			/// <item>
			/// <term>ARW_HIDE0x0008L</term>
			/// <term>Hide minimized windows by moving them off the visible area of the screen.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public ARW iArrange;
		}

		/// <summary>
		/// Contains information about the MouseKeys accessibility feature. When the MouseKeys feature is active, the user can use the
		/// numeric keypad to control the mouse pointer, and to click, double-click, drag, and drop. By pressing NUMLOCK, the user can toggle
		/// the numeric keypad between mouse control mode and normal operation.
		/// </summary>
		[PInvokeData("Winuser.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct MOUSEKEYS
		{
			/// <summary>Specifies the size, in bytes, of this structure.</summary>
			public uint cbSize;

			/// <summary>A set of bit-flags that specify properties of the MouseKeys feature.</summary>
			public MKF dwFlags;

			/// <summary>Specifies the maximum speed the mouse cursor attains when an arrow key is held down.</summary>
			public uint iMaxSpeed;

			/// <summary>
			/// Specifies the length of time, in milliseconds, that it takes for the mouse cursor to reach maximum speed when an arrow key is
			/// held down. Valid values are from 1000 to 5000.
			/// </summary>
			public uint iTimeToMaxSpeed;

			/// <summary>
			/// Specifies the multiplier to apply to the mouse cursor speed when the user holds down the CTRL key while using the arrow keys
			/// to move the cursor. this value is ignored if MKF_MODIFIERS is not set.
			/// </summary>
			public uint iCtrlSpeed;

			/// <summary>This member is reserved for future use. It must be set to zero.</summary>
			public uint dwReserved1;

			/// <summary>This member is reserved for future use. It must be set to zero.</summary>
			public uint dwReserved2;
		}

		/// <summary>Contains information used to display a message box. The MessageBoxIndirect function uses this structure.</summary>
		[PInvokeData("Winuser.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct MSGBOXPARAMS
		{
			/// <summary>The structure size, in bytes.</summary>
			public uint cbSize;

			/// <summary>A handle to the owner window. This member can be NULL.</summary>
			public HWND hwndOwner;

			/// <summary>
			/// A handle to the module that contains the icon resource identified by the lpszIcon member, and the string resource identified
			/// by the lpszText or lpszCaption member.
			/// </summary>
			public HINSTANCE hInstance;

			/// <summary>A null-terminated string, or the identifier of a string resource, that contains the message to be displayed.</summary>
			public string lpszText;

			/// <summary>
			/// A null-terminated string, or the identifier of a string resource, that contains the message box title. If this member is
			/// NULL, the default title Error is used.
			/// </summary>
			public string lpszCaption;

			/// <summary>
			/// The contents and behavior of the dialog box. This member can be a combination of flags described for the uType parameter of
			/// the MessageBoxEx function.
			/// <para>
			/// In addition, you can specify the MB_USERICON flag(0x00000080L) if you want the message box to display the icon specified by
			/// the lpszIcon member.
			/// </para>
			/// </summary>
			public MB_FLAGS dwStyle;

			/// <summary>
			/// Identifies an icon resource. This parameter can be either a null-terminated string or an integer resource identifier passed
			/// to the MAKEINTRESOURCE macro.
			/// <para>
			/// To load one of the standard system-defined icons, set the hInstance member to NULL and set lpszIcon to one of the values
			/// listed with the LoadIcon function.
			/// </para>
			/// <para>This member is ignored if the dwStyle member does not specify the MB_USERICON flag.</para>
			/// </summary>
			public IntPtr lpszIcon;

			/// <summary>
			/// Identifies a help context. If a help event occurs, this value is specified in the HELPINFO structure that the message box
			/// sends to the owner window or callback function.
			/// </summary>
			public IntPtr dwContextHelpId;

			/// <summary>
			/// A pointer to the callback function that processes help events for the message box.
			/// <para>If this member is NULL, the message box sends WM_HELP messages to the owner window when help events occur.</para>
			/// </summary>
			public MsgBoxCallback lpfnMsgBoxCallback;

			/// <summary>
			/// The language in which to display the text contained in the predefined push buttons. This value must be in the form returned
			/// by the MAKELANGID macro.
			/// <para>
			/// For a list of supported language identifiers, see Language Identifiers.Note that each localized release of Windows typically
			/// contains resources only for a limited set of languages.Thus, for example, the U.S.version offers LANG_ENGLISH, the French
			/// version offers LANG_FRENCH, the German version offers LANG_GERMAN, and the Japanese version offers LANG_JAPANESE. Each
			/// version offers LANG_NEUTRAL. This limits the set of values that can be used with the dwLanguageId parameter. Before
			/// specifying a language identifier, you should enumerate the locales that are installed on a system.
			/// </para>
			/// </summary>
			public uint dwLanguageId;
		}

		/// <summary>
		/// Contains the scalable metrics associated with the nonclient area of a nonminimized window. This structure is used by the
		/// <c>SPI_GETNONCLIENTMETRICS</c> and <c>SPI_SETNONCLIENTMETRICS</c> actions of the <c>SystemParametersInfo</c> function.
		/// </summary>
		// typedef struct tagNONCLIENTMETRICS { UINT cbSize; int iBorderWidth; int iScrollWidth; int iScrollHeight; int iCaptionWidth; int
		// iCaptionHeight; LOGFONT lfCaptionFont; int iSmCaptionWidth; int iSmCaptionHeight; LOGFONT lfSmCaptionFont; int iMenuWidth; int
		// iMenuHeight; LOGFONT lfMenuFont; LOGFONT lfStatusFont; LOGFONT lfMessageFont;#if (WINVER &gt;= 0x0600) int
		// iPaddedBorderWidth;#endif } NONCLIENTMETRICS, *PNONCLIENTMETRICS,
		// *LPNONCLIENTMETRICS; https://msdn.microsoft.com/en-us/library/windows/desktop/ff729175(v=vs.85).aspx
		[PInvokeData("Winuser.h", MSDNShortId = "ff729175")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NONCLIENTMETRICS
		{
			/// <summary>
			/// The size of the structure, in bytes. The caller must set this to sizeof(NONCLIENTMETRICS). For information about application
			/// compatibility, see Remarks.
			/// </summary>
			public uint cbSize;

			/// <summary>The thickness of the sizing border, in pixels. The default is 1 pixel.</summary>
			public int iBorderWidth;

			/// <summary>The width of a standard vertical scroll bar, in pixels.</summary>
			public int iScrollWidth;

			/// <summary>The height of a standard horizontal scroll bar, in pixels.</summary>
			public int iScrollHeight;

			/// <summary>The width of caption buttons, in pixels.</summary>
			public int iCaptionWidth;

			/// <summary>The height of caption buttons, in pixels.</summary>
			public int iCaptionHeight;

			/// <summary>A <c>LOGFONT</c> structure that contains information about the caption font.</summary>
			public LOGFONT lfCaptionFont;

			/// <summary>The width of small caption buttons, in pixels.</summary>
			public int iSMCaptionWidth;

			/// <summary>The height of small captions, in pixels.</summary>
			public int iSMCaptionHeight;

			/// <summary>A <c>LOGFONT</c> structure that contains information about the small caption font.</summary>
			public LOGFONT lfSMCaptionFont;

			/// <summary>The width of menu-bar buttons, in pixels.</summary>
			public int iMenuWidth;

			/// <summary>The height of a menu bar, in pixels.</summary>
			public int iMenuHeight;

			/// <summary>A <c>LOGFONT</c> structure that contains information about the font used in menu bars.</summary>
			public LOGFONT lfMenuFont;

			/// <summary>A <c>LOGFONT</c> structure that contains information about the font used in status bars and tooltips.</summary>
			public LOGFONT lfStatusFont;

			/// <summary>A <c>LOGFONT</c> structure that contains information about the font used in message boxes.</summary>
			public LOGFONT lfMessageFont;

			/// <summary>
			/// <para>
			/// The thickness of the padded border, in pixels. The default value is 4 pixels. The <c>iPaddedBorderWidth</c> and
			/// <c>iBorderWidth</c> members are combined for both resizable and nonresizable windows in the Windows Aero desktop experience.
			/// To compile an application that uses this member, define <c>_WIN32_WINNT</c> as 0x0600 or later. For more information, see Remarks.
			/// </para>
			/// <para><c>Windows Server 2003 and Windows XP/2000:</c> This member is not supported.</para>
			/// </summary>
			public int iPaddedBorderWidth;
		}

		/// <summary>
		/// Contains information about the SerialKeys accessibility feature, which interprets data from a communication aid attached to a
		/// serial port as commands causing the system to simulate keyboard and mouse input.
		/// </summary>
		[PInvokeData("Winuser.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SERIALKEYS
		{
			/// <summary>Specifies the structure size, in bytes.</summary>
			public uint cbSize;

			/// <summary>A set of bit-flags that specify properties of the SerialKeys feature.</summary>
			public SERKF dwFlags;

			/// <summary>
			/// Points to a string that contains the name of the serial port that receives input from the communication aid when the
			/// SerialKeys feature is on. If no port is being used, this member is NULL. If this member is "Auto", the system watches all
			/// unused serial ports for input from communication aids.
			/// </summary>
			public string lpszActivePort;

			/// <summary>Reserved; must be NULL.</summary>
			public IntPtr lpszPort;

			/// <summary>
			/// Specifies the baud rate setting for the serial port specified by the lpszActivePort member. This member should be set to one
			/// of the CBR_ values defined in the winbase.h header file. If lpszActivePort is NULL, this member is zero.
			/// </summary>
			public uint iBaudRate;

			/// <summary>
			/// Specifies the state of the port specified by the lpszActivePort member. If lpszActivePort is NULL, iPortState is zero;
			/// otherwise, it is one of the following values:
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <description>Meaning</description>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <description>All input on this port is ignored by the SerialKeys feature.</description>
			/// </item>
			/// <item>
			/// <term>1</term>
			/// <description>
			/// Input on this port is watched for SerialKeys activation sequences when no other application has the port open.
			/// </description>
			/// </item>
			/// <item>
			/// <term>2</term>
			/// <description>All input on this port is treated as SerialKeys commands.</description>
			/// </item>
			/// </list>
			/// </summary>
			public uint iPortState;

			/// <summary>Specifies the active port.</summary>
			public uint iActive;
		}

		/// <summary>
		/// Contains information about the SoundSentry accessibility feature. When the SoundSentry feature is on, the computer displays a
		/// visual indication only when a sound is generated.
		/// </summary>
		[PInvokeData("Winuser.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SOUNDSENTRY
		{
			/// <summary>Specifies the size, in bytes, of this structure.</summary>
			public uint cbSize;

			/// <summary>A set of bit flags that specify properties of the SoundSentry feature.</summary>
			public SSF dwFlags;

			/// <summary>
			/// Specifies the visual signal to present when a text-mode application generates a sound while running in a full-screen virtual machine.
			/// </summary>
			public SSTF iFSTextEffect;

			/// <summary>
			/// Specifies the duration, in milliseconds, of the visual signal that is displayed when a full-screen, text-mode application
			/// generates a sound.
			/// </summary>
			public uint iFSTextEffectMSec;

			/// <summary>
			/// Specifies the RGB value of the color to be used when displaying the visual signal shown when a full-screen, text-mode
			/// application generates a sound.
			/// </summary>
			public COLORREF iFSTextEffectColorBits;

			/// <summary>
			/// Specifies the visual signal to present when a graphics-mode application generates a sound while running in a full-screen
			/// virtual machine.
			/// </summary>
			public SSGF iFSGrafEffect;

			/// <summary>
			/// Specifies the duration, in milliseconds, of the visual signal that is displayed when a full-screen, graphics-mode application
			/// generates a sound.
			/// </summary>
			public uint iFSGrafEffectMSec;

			/// <summary>
			/// Specifies the RGB value of the color to be used when displaying the visual signal shown when a full-screen, graphics-mode
			/// application generates a sound.
			/// </summary>
			public COLORREF iFSGrafEffectColor;

			/// <summary>
			/// Specifies the visual signal to display when a sound is generated by a Windows-based application or an MS-DOS application
			/// running in a window.
			/// </summary>
			public SSWF iWindowsEffect;

			/// <summary>
			/// Specifies the duration, in milliseconds, of the visual signal that is displayed when a Win32-based application (or an
			/// application running in a window) generates a sound.
			/// </summary>
			public uint iWindowsEffectMSec;

			/// <summary>This member is reserved for future use. It should be set to NULL.</summary>
			public IntPtr lpszWindowsEffectDLL;

			/// <summary>This member is reserved for future use. It must be set to zero.</summary>
			public uint iWindowsEffectOrdinal;
		}

		/// <summary>
		/// Contains information about the StickyKeys accessibility feature. When the StickyKeys feature is on, the user can press a modifier
		/// key (SHIFT, CTRL, or ALT) and then another key in sequence rather than at the same time, to enter shifted (modified) characters
		/// and other key combinations. Pressing a modifier key once latches the key down until the user presses a non-modifier key or clicks
		/// a mouse button. Pressing a modifier key twice locks the key until the user presses the key a third time.
		/// </summary>
		[PInvokeData("Winuser.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct STICKYKEYS
		{
			/// <summary>Specifies the size, in bytes, of this structure.</summary>
			public uint cbSize;

			/// <summary>A set of bit-flags that specify properties of the StickyKeys feature.</summary>
			public SKF dwFlags;
		}

		/// <summary>
		/// Contains information about the ToggleKeys accessibility feature. When the ToggleKeys feature is on, the computer emits a
		/// high-pitched tone whenever the user turns on the CAPS LOCK, NUM LOCK, or SCROLL LOCK key, and a low-pitched tone whenever the
		/// user turns off one of those keys.
		/// </summary>
		[PInvokeData("Winuser.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct TOGGLEKEYS
		{
			/// <summary>Specifies the size, in bytes, of this structure.</summary>
			public uint cbSize;

			/// <summary>A set of bit flags that specify properties of the ToggleKeys feature.</summary>
			public TKF dwFlags;
		}

		/// <summary>
		/// Contains hardware input details that can be used to predict touch targets and help compensate for hardware latency when
		/// processing touch and gesture input that contains distance and velocity data.
		/// </summary>
		// typedef struct tagTouchPredictionParameters { UINT cbSize; UINT dwLatency; UINT dwSampleTime; UINT bUseHWTimeStamp;}
		// TouchPredictionParameters, *PTouchPredictionParameters; https://msdn.microsoft.com/en-us/library/windows/desktop/hh969214(v=vs.85).aspx
		[PInvokeData("Winuser.h", MSDNShortId = "hh969214")]
		public struct TOUCHPREDICTIONPARAMETERS
		{
			/// <summary>Use timestamps provided by the hardware.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool bUseHWTimeStamp;

			/// <summary>The size of this structure, in bytes.</summary>
			public uint cbSize;

			/// <summary>Latency in milliseconds.</summary>
			public uint dwLatency;

			/// <summary>Sample time in milliseconds (used to calculate velocity).</summary>
			public uint dwSampleTime;
		}

		internal class SPCorrespondingTypeAttribute : CorrespondingTypeAttribute
		{
			public SPCorrespondingTypeAttribute(Type typeRef, CorrepsondingAction action, bool useUiParam = false) : base(typeRef, action) => UseUiParam = useUiParam;

			public bool UseUiParam { get; }

			public static bool UseUI(object value) => GetAttrForObj(value).OfType<SPCorrespondingTypeAttribute>().Any(a => a.UseUiParam);
		}
	}
}