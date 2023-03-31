using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>Flags used by WM_GETHOTKEY and WM_SETHOTKEY</summary>
	[PInvokeData("winuser.h")]
	[Flags]
	public enum HOTKEYF : byte
	{
		/// <summary>SHIFT key</summary>
		HOTKEYF_SHIFT = 0x01,

		/// <summary>CTRL key</summary>
		HOTKEYF_CONTROL = 0x02,

		/// <summary>ALT key</summary>
		HOTKEYF_ALT = 0x04,

		/// <summary>Extended key</summary>
		HOTKEYF_EXT = 0x08,
	}

	/// <summary>Modifiers for key press.</summary>
	[PInvokeData("winuser.h")]
	[Flags]
	public enum HotKeyModifiers
	{
		/// <summary>Nothing held down.</summary>
		MOD_NONE = 0,

		/// <summary>Either ALT key must be held down.</summary>
		MOD_ALT = 0x0001,

		/// <summary>Either CTRL key must be held down.</summary>
		MOD_CONTROL = 0x0002,

		/// <summary>Either SHIFT key must be held down.</summary>
		MOD_SHIFT = 0x0004,

		/// <summary>
		/// Either WINDOWS key was held down. These keys are labeled with the Windows logo. Keyboard shortcuts that involve the WINDOWS
		/// key are reserved for use by the operating system.
		/// </summary>
		MOD_WIN = 0x0008,

		/// <summary>
		/// Changes the hotkey behavior so that the keyboard auto-repeat does not yield multiple hotkey notifications.
		/// <para>Windows Vista: This flag is not supported.</para>
		/// </summary>
		MOD_NOREPEAT = 0x4000,
	}

	/// <summary>Controls various aspects of function operation of <see cref="keybd_event"/>.</summary>
	[PInvokeData("winuser.h")]
	[Flags]
	public enum KEYEVENTF
	{
		/// <summary>If specified, the scan code was preceded by a prefix byte having the value 0xE0 (224).</summary>
		KEYEVENTF_EXTENDEDKEY = 0x0001,

		/// <summary>If specified, the key is being released. If not specified, the key is being depressed.</summary>
		KEYEVENTF_KEYUP = 0x0002,

		/// <summary>
		/// If specified, the system synthesizes a VK_PACKET keystroke. The wVk parameter must be zero. This flag can only be combined
		/// with the KEYEVENTF_KEYUP flag. For more information, see the Remarks section.
		/// </summary>
		KEYEVENTF_UNICODE = 0x0004,

		/// <summary>If specified, wScan identifies the key and wVk is ignored.</summary>
		KEYEVENTF_SCANCODE = 0x0008,
	}

	/// <summary>Flags used by keyboard layout functions.</summary>
	[PInvokeData("winuser.h")]
	[Flags]
	public enum KLF
	{
		/// <summary>
		/// Prior to Windows 8: If the specified input locale identifier is not already loaded, the function loads and activates the
		/// input locale identifier for the current thread.
		/// <para>
		/// Beginning in Windows 8: If the specified input locale identifier is not already loaded, the function loads and activates the
		/// input locale identifier for the system.
		/// </para>
		/// </summary>
		KLF_ACTIVATE = 0x00000001,

		/// <summary>
		/// Prior to Windows 8: Prevents a ShellProchook procedure from receiving an HSHELL_LANGUAGE hook code when the new input locale
		/// identifier is loaded. This value is typically used when an application loads multiple input locale identifiers one after
		/// another. Applying this value to all but the last input locale identifier delays the shell's processing until all input
		/// locale identifiers have been added.
		/// <para>Beginning in Windows 8: In this scenario, the last input locale identifier is set for the entire system.</para>
		/// </summary>
		KLF_NOTELLSHELL = 0x00000080,

		/// <summary>
		/// Prior to Windows 8: Moves the specified input locale identifier to the head of the input locale identifier list, making that
		/// locale identifier the active locale identifier for the current thread. This value reorders the input locale identifier list
		/// even if KLF_ACTIVATE is not provided.
		/// <para>
		/// Beginning in Windows 8: Moves the specified input locale identifier to the head of the input locale identifier list, making
		/// that locale identifier the active locale identifier for the system. This value reorders the input locale identifier list
		/// even if KLF_ACTIVATE is not provided.
		/// </para>
		/// </summary>
		KLF_REORDER = 0x00000008,

		/// <summary>
		/// If the new input locale identifier has the same language identifier as a current input locale identifier, the new input
		/// locale identifier replaces the current one as the input locale identifier for that language. If this value is not provided
		/// and the input locale identifiers have the same language identifiers, the current input locale identifier is not replaced and
		/// the function returns NULL.
		/// </summary>
		KLF_REPLACELANG = 0x00000010,

		/// <summary>
		/// Substitutes the specified input locale identifier with another locale preferred by the user. The system starts with this
		/// flag set, and it is recommended that your application always use this flag. The substitution occurs only if the registry key
		/// HKEY_CURRENT_USER\Keyboard\Layout\Substitutes explicitly defines a substitution locale. For example, if the key includes the
		/// value name "00000409" with value "00010409", loading the U.S. English layout ("00000409") causes the Dvorak U.S. English
		/// layout ("00010409") to be loaded instead. The system uses KLF_SUBSTITUTE_OK when booting, and it is recommended that all
		/// applications use this value when loading input locale identifiers to ensure that the user's preference is selected.
		/// </summary>
		KLF_SUBSTITUTE_OK = 0x00000002,

		/// <summary>
		/// Prior to Windows 8: This flag is valid only with KLF_ACTIVATE. Activates the specified input locale identifier for the
		/// entire process and sends the WM_INPUTLANGCHANGE message to the current thread's Focus or Active window. Typically,
		/// LoadKeyboardLayout activates an input locale identifier only for the current thread.
		/// <para>
		/// Beginning in Windows 8: This flag is not used. LoadKeyboardLayout always activates an input locale identifier for the entire
		/// system if the current process owns the window with keyboard focus.
		/// </para>
		/// </summary>
		KLF_SETFORPROCESS = 0x00000100,

		/// <summary>This is used with KLF_RESET. See KLF_RESET for an explanation.</summary>
		KLF_SHIFTLOCK = 0x00010000,

		/// <summary>
		/// If set but KLF_SHIFTLOCK is not set, the Caps Lock state is turned off by pressing the Caps Lock key again. If set and
		/// KLF_SHIFTLOCK is also set, the Caps Lock state is turned off by pressing either SHIFT key.
		/// <para>These two methods are mutually exclusive, and the setting persists as part of the User's profile in the registry.</para>
		/// </summary>
		KLF_RESET = 0x40000000,
	}

	/// <summary>The translation to be performed in <see cref="MapVirtualKey"/>.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public enum MAPVK
	{
		/// <summary>
		/// uCode is a virtual-key code and is translated into a scan code. If it is a virtual-key code that does not distinguish
		/// between left- and right-hand keys, the left-hand scan code is returned. If there is no translation, the function returns 0.
		/// </summary>
		MAPVK_VK_TO_VSC = 0,

		/// <summary>
		/// uCode is a scan code and is translated into a virtual-key code that does not distinguish between left- and right-hand keys.
		/// If there is no translation, the function returns 0.
		/// </summary>
		MAPVK_VSC_TO_VK = 1,

		/// <summary>
		/// uCode is a virtual-key code and is translated into an unshifted character value in the low-order word of the return value.
		/// Dead keys (diacritics) are indicated by setting the top bit of the return value. If there is no translation, the function
		/// returns 0.
		/// </summary>
		MAPVK_VK_TO_CHAR = 2,

		/// <summary>
		/// uCode is a scan code and is translated into a virtual-key code that distinguishes between left- and right-hand keys. If
		/// there is no translation, the function returns 0.
		/// </summary>
		MAPVK_VSC_TO_VK_EX = 3,

		/// <summary>
		/// The uCode parameter is a virtual-key code and is translated into a scan code. If it is a virtual-key code that does not
		/// distinguish between left- and right-hand keys, the left-hand scan code is returned. If the scan code is an extended scan
		/// code, the high byte of the uCode value can contain either 0xe0 or 0xe1 to specify the extended scan code. If there is no
		/// translation, the function returns 0.
		/// </summary>
		MAPVK_VK_TO_VSC_EX = 4,
	}

	/// <summary>
	/// The following table shows the symbolic constant names, hexadecimal values, and mouse or keyboard equivalents for the virtual-key
	/// codes used by the system. The codes are listed in numeric order.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
	[PInvokeData("winuser.h")]
	public enum VK : byte
	{
		/// <summary>Left mouse button</summary>
		VK_LBUTTON = 0x01,

		/// <summary>Right mouse button</summary>
		VK_RBUTTON = 0x02,

		/// <summary>Control-break processing</summary>
		VK_CANCEL = 0x03,

		/// <summary>Middle mouse button (three-button mouse)</summary>
		VK_MBUTTON = 0x04,

		/// <summary>X1 mouse button</summary>
		VK_XBUTTON1 = 0x05,

		/// <summary>X2 mouse button</summary>
		VK_XBUTTON2 = 0x06,

		/// <summary>BACKSPACE key</summary>
		VK_BACK = 0x08,

		/// <summary>TAB key</summary>
		VK_TAB = 0x09,

		/// <summary>CLEAR key</summary>
		VK_CLEAR = 0x0C,

		/// <summary>ENTER key</summary>
		VK_RETURN = 0x0D,

		/// <summary>SHIFT key</summary>
		VK_SHIFT = 0x10,

		/// <summary>CTRL key</summary>
		VK_CONTROL = 0x11,

		/// <summary>ALT key</summary>
		VK_MENU = 0x12,

		/// <summary>PAUSE key</summary>
		VK_PAUSE = 0x13,

		/// <summary>CAPS LOCK key</summary>
		VK_CAPITAL = 0x14,

		/// <summary>IME Kana mode</summary>
		VK_KANA = 0x15,

		/// <summary>IME Hanguel mode (maintained for compatibility; use VK_HANGUL)</summary>
		VK_HANGUEL = 0x15,

		/// <summary>IME Hangul mode</summary>
		VK_HANGUL = 0x15,

		/// <summary>IME On</summary>
		VK_IME_ON = 0x16,

		/// <summary>IME Junja mode</summary>
		VK_JUNJA = 0x17,

		/// <summary>IME final mode</summary>
		VK_FINAL = 0x18,

		/// <summary>IME Hanja mode</summary>
		VK_HANJA = 0x19,

		/// <summary>IME Kanji mode</summary>
		VK_KANJI = 0x19,

		/// <summary>IME Off</summary>
		VK_IME_OFF = 0x1A,

		/// <summary>ESC key</summary>
		VK_ESCAPE = 0x1B,

		/// <summary>IME convert</summary>
		VK_CONVERT = 0x1C,

		/// <summary>IME nonconvert</summary>
		VK_NONCONVERT = 0x1D,

		/// <summary>IME accept</summary>
		VK_ACCEPT = 0x1E,

		/// <summary>IME mode change request</summary>
		VK_MODECHANGE = 0x1F,

		/// <summary>SPACEBAR</summary>
		VK_SPACE = 0x20,

		/// <summary>PAGE UP key</summary>
		VK_PRIOR = 0x21,

		/// <summary>PAGE DOWN key</summary>
		VK_NEXT = 0x22,

		/// <summary>END key</summary>
		VK_END = 0x23,

		/// <summary>HOME key</summary>
		VK_HOME = 0x24,

		/// <summary>LEFT ARROW key</summary>
		VK_LEFT = 0x25,

		/// <summary>UP ARROW key</summary>
		VK_UP = 0x26,

		/// <summary>RIGHT ARROW key</summary>
		VK_RIGHT = 0x27,

		/// <summary>DOWN ARROW key</summary>
		VK_DOWN = 0x28,

		/// <summary>SELECT key</summary>
		VK_SELECT = 0x29,

		/// <summary>PRINT key</summary>
		VK_PRINT = 0x2A,

		/// <summary>EXECUTE key</summary>
		VK_EXECUTE = 0x2B,

		/// <summary>PRINT SCREEN key</summary>
		VK_SNAPSHOT = 0x2C,

		/// <summary>INS key</summary>
		VK_INSERT = 0x2D,

		/// <summary>DEL key</summary>
		VK_DELETE = 0x2E,

		/// <summary>HELP key</summary>
		VK_HELP = 0x2F,

		/// <summary>0 key</summary>
		VK_0 = 0x30,

		/// <summary>1 key</summary>
		VK_1 = 0x31,

		/// <summary>2 key</summary>
		VK_2 = 0x32,

		/// <summary>3 key</summary>
		VK_3 = 0x33,

		/// <summary>4 key</summary>
		VK_4 = 0x34,

		/// <summary>5 key</summary>
		VK_5 = 0x35,

		/// <summary>6 key</summary>
		VK_6 = 0x36,

		/// <summary>7 key</summary>
		VK_7 = 0x37,

		/// <summary>8 key</summary>
		VK_8 = 0x38,

		/// <summary>9 key</summary>
		VK_9 = 0x39,

		/// <summary>A key</summary>
		VK_A = 0x41,

		/// <summary>B key</summary>
		VK_B = 0x42,

		/// <summary>C key</summary>
		VK_C = 0x43,

		/// <summary>D key</summary>
		VK_D = 0x44,

		/// <summary>E key</summary>
		VK_E = 0x45,

		/// <summary>F key</summary>
		VK_F = 0x46,

		/// <summary>G key</summary>
		VK_G = 0x47,

		/// <summary>H key</summary>
		VK_H = 0x48,

		/// <summary>I key</summary>
		VK_I = 0x49,

		/// <summary>J key</summary>
		VK_J = 0x4A,

		/// <summary>K key</summary>
		VK_K = 0x4B,

		/// <summary>L key</summary>
		VK_L = 0x4C,

		/// <summary>M key</summary>
		VK_M = 0x4D,

		/// <summary>N key</summary>
		VK_N = 0x4E,

		/// <summary>O key</summary>
		VK_O = 0x4F,

		/// <summary>P key</summary>
		VK_P = 0x50,

		/// <summary>Q key</summary>
		VK_Q = 0x51,

		/// <summary>R key</summary>
		VK_R = 0x52,

		/// <summary>S key</summary>
		VK_S = 0x53,

		/// <summary>T key</summary>
		VK_T = 0x54,

		/// <summary>U key</summary>
		VK_U = 0x55,

		/// <summary>V key</summary>
		VK_V = 0x56,

		/// <summary>W key</summary>
		VK_W = 0x57,

		/// <summary>X key</summary>
		VK_X = 0x58,

		/// <summary>Y key</summary>
		VK_Y = 0x59,

		/// <summary>Z key</summary>
		VK_Z = 0x5A,

		/// <summary>Left Windows key (Natural keyboard)</summary>
		VK_LWIN = 0x5B,

		/// <summary>Right Windows key (Natural keyboard)</summary>
		VK_RWIN = 0x5C,

		/// <summary>Applications key (Natural keyboard)</summary>
		VK_APPS = 0x5D,

		/// <summary>Computer Sleep key</summary>
		VK_SLEEP = 0x5F,

		/// <summary>Numeric keypad 0 key</summary>
		VK_NUMPAD0 = 0x60,

		/// <summary>Numeric keypad 1 key</summary>
		VK_NUMPAD1 = 0x61,

		/// <summary>Numeric keypad 2 key</summary>
		VK_NUMPAD2 = 0x62,

		/// <summary>Numeric keypad 3 key</summary>
		VK_NUMPAD3 = 0x63,

		/// <summary>Numeric keypad 4 key</summary>
		VK_NUMPAD4 = 0x64,

		/// <summary>Numeric keypad 5 key</summary>
		VK_NUMPAD5 = 0x65,

		/// <summary>Numeric keypad 6 key</summary>
		VK_NUMPAD6 = 0x66,

		/// <summary>Numeric keypad 7 key</summary>
		VK_NUMPAD7 = 0x67,

		/// <summary>Numeric keypad 8 key</summary>
		VK_NUMPAD8 = 0x68,

		/// <summary>Numeric keypad 9 key</summary>
		VK_NUMPAD9 = 0x69,

		/// <summary>Multiply key</summary>
		VK_MULTIPLY = 0x6A,

		/// <summary>Add key</summary>
		VK_ADD = 0x6B,

		/// <summary>Separator key</summary>
		VK_SEPARATOR = 0x6C,

		/// <summary>Subtract key</summary>
		VK_SUBTRACT = 0x6D,

		/// <summary>Decimal key</summary>
		VK_DECIMAL = 0x6E,

		/// <summary>Divide key</summary>
		VK_DIVIDE = 0x6F,

		/// <summary>F1 key</summary>
		VK_F1 = 0x70,

		/// <summary>F2 key</summary>
		VK_F2 = 0x71,

		/// <summary>F3 key</summary>
		VK_F3 = 0x72,

		/// <summary>F4 key</summary>
		VK_F4 = 0x73,

		/// <summary>F5 key</summary>
		VK_F5 = 0x74,

		/// <summary>F6 key</summary>
		VK_F6 = 0x75,

		/// <summary>F7 key</summary>
		VK_F7 = 0x76,

		/// <summary>F8 key</summary>
		VK_F8 = 0x77,

		/// <summary>F9 key</summary>
		VK_F9 = 0x78,

		/// <summary>F10 key</summary>
		VK_F10 = 0x79,

		/// <summary>F11 key</summary>
		VK_F11 = 0x7A,

		/// <summary>F12 key</summary>
		VK_F12 = 0x7B,

		/// <summary>F13 key</summary>
		VK_F13 = 0x7C,

		/// <summary>F14 key</summary>
		VK_F14 = 0x7D,

		/// <summary>F15 key</summary>
		VK_F15 = 0x7E,

		/// <summary>F16 key</summary>
		VK_F16 = 0x7F,

		/// <summary>F17 key</summary>
		VK_F17 = 0x80,

		/// <summary>F18 key</summary>
		VK_F18 = 0x81,

		/// <summary>F19 key</summary>
		VK_F19 = 0x82,

		/// <summary>F20 key</summary>
		VK_F20 = 0x83,

		/// <summary>F21 key</summary>
		VK_F21 = 0x84,

		/// <summary>F22 key</summary>
		VK_F22 = 0x85,

		/// <summary>F23 key</summary>
		VK_F23 = 0x86,

		/// <summary>F24 key</summary>
		VK_F24 = 0x87,

		/// <summary>NUM LOCK key</summary>
		VK_NUMLOCK = 0x90,

		/// <summary>SCROLL LOCK key</summary>
		VK_SCROLL = 0x91,

		/// <summary>NEC '=' key on numpad</summary>
		VK_OEM_NEC_EQUAL = 0x92,

		/// <summary>Fujitsu 'Dictionary' key</summary>
		VK_OEM_FJ_JISHO = 0x92,

		/// <summary>Fujitsu 'Unregister word' key</summary>
		VK_OEM_FJ_MASSHOU = 0x93,

		/// <summary>Fujitsu 'Register word' key</summary>
		VK_OEM_FJ_TOUROKU = 0x94,

		/// <summary>Fujitsu 'Left OYAYUBI' key</summary>
		VK_OEM_FJ_LOYA = 0x95,

		/// <summary>Fujitsu 'Right OYAYUBI' key</summary>
		VK_OEM_FJ_ROYA = 0x96,

		/// <summary>Left SHIFT key</summary>
		VK_LSHIFT = 0xA0,

		/// <summary>Right SHIFT key</summary>
		VK_RSHIFT = 0xA1,

		/// <summary>Left CONTROL key</summary>
		VK_LCONTROL = 0xA2,

		/// <summary>Right CONTROL key</summary>
		VK_RCONTROL = 0xA3,

		/// <summary>Left MENU key</summary>
		VK_LMENU = 0xA4,

		/// <summary>Right MENU key</summary>
		VK_RMENU = 0xA5,

		/// <summary>Browser Back key</summary>
		VK_BROWSER_BACK = 0xA6,

		/// <summary>Browser Forward key</summary>
		VK_BROWSER_FORWARD = 0xA7,

		/// <summary>Browser Refresh key</summary>
		VK_BROWSER_REFRESH = 0xA8,

		/// <summary>Browser Stop key</summary>
		VK_BROWSER_STOP = 0xA9,

		/// <summary>Browser Search key</summary>
		VK_BROWSER_SEARCH = 0xAA,

		/// <summary>Browser Favorites key</summary>
		VK_BROWSER_FAVORITES = 0xAB,

		/// <summary>Browser Start and Home key</summary>
		VK_BROWSER_HOME = 0xAC,

		/// <summary>Volume Mute key</summary>
		VK_VOLUME_MUTE = 0xAD,

		/// <summary>Volume Down key</summary>
		VK_VOLUME_DOWN = 0xAE,

		/// <summary>Volume Up key</summary>
		VK_VOLUME_UP = 0xAF,

		/// <summary>Next Track key</summary>
		VK_MEDIA_NEXT_TRACK = 0xB0,

		/// <summary>Previous Track key</summary>
		VK_MEDIA_PREV_TRACK = 0xB1,

		/// <summary>Stop Media key</summary>
		VK_MEDIA_STOP = 0xB2,

		/// <summary>Play/Pause Media key</summary>
		VK_MEDIA_PLAY_PAUSE = 0xB3,

		/// <summary>Start Mail key</summary>
		VK_LAUNCH_MAIL = 0xB4,

		/// <summary>Select Media key</summary>
		VK_LAUNCH_MEDIA_SELECT = 0xB5,

		/// <summary>Start Application 1 key</summary>
		VK_LAUNCH_APP1 = 0xB6,

		/// <summary>Start Application 2 key</summary>
		VK_LAUNCH_APP2 = 0xB7,

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard.
		/// <para>For the US standard keyboard, the ';:' key///<summary>For any country/region, the '+' key</summary></para>
		/// </summary>
		VK_OEM_1 = 0xBA,

		/// <summary>For any country/region, the '+' key</summary>
		VK_OEM_PLUS = 0xBB,

		/// <summary>For any country/region, the ',' key</summary>
		VK_OEM_COMMA = 0xBC,

		/// <summary>For any country/region, the '-' key</summary>
		VK_OEM_MINUS = 0xBD,

		/// <summary>For any country/region, the '.' key</summary>
		VK_OEM_PERIOD = 0xBE,

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard.
		/// <para>For the US standard keyboard, the '/?' key</para>
		/// </summary>
		VK_OEM_2 = 0xBF,

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard.
		/// <para>For the US standard keyboard, the '`~' key</para>
		/// </summary>
		VK_OEM_3 = 0xC0,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_A = 0xC3,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_B = 0xC4,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_X = 0xC5,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_Y = 0xC6,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_RIGHT_SHOULDER = 0xC7,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_LEFT_SHOULDER = 0xC8,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_LEFT_TRIGGER = 0xC9,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_RIGHT_TRIGGER = 0xCA,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_DPAD_UP = 0xCB,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_DPAD_DOWN = 0xCC,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_DPAD_LEFT = 0xCD,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_DPAD_RIGHT = 0xCE,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_MENU = 0xCF,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_VIEW = 0xD0,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_LEFT_THUMBSTICK_BUTTON = 0xD1,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_RIGHT_THUMBSTICK_BUTTON = 0xD2,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_LEFT_THUMBSTICK_UP = 0xD3,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_LEFT_THUMBSTICK_DOWN = 0xD4,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_LEFT_THUMBSTICK_RIGHT = 0xD5,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_LEFT_THUMBSTICK_LEFT = 0xD6,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_RIGHT_THUMBSTICK_UP = 0xD7,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_RIGHT_THUMBSTICK_DOWN = 0xD8,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_RIGHT_THUMBSTICK_RIGHT = 0xD9,

		/// <summary>Reserved</summary>
		VK_GAMEPAD_RIGHT_THUMBSTICK_LEFT = 0xDA,

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard.
		/// <para>For the US standard keyboard, the '[{' key</para>
		/// </summary>
		VK_OEM_4 = 0xDB,

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard.
		/// <para>For the US standard keyboard, the '\|' key</para>
		/// </summary>
		VK_OEM_5 = 0xDC,

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard.
		/// <para>For the US standard keyboard, the ']}' key</para>
		/// </summary>
		VK_OEM_6 = 0xDD,

		/// <summary>
		/// Used for miscellaneous characters; it can vary by keyboard.
		/// <para>For the US standard keyboard, the 'single-quote/double-quote' key</para>
		/// </summary>
		VK_OEM_7 = 0xDE,

		/// <summary>Used for miscellaneous characters; it can vary by keyboard.</summary>
		VK_OEM_8 = 0xDF,

		/// <summary>'AX' key on Japanese AX kbd</summary>
		VK_OEM_AX = 0xE1,

		/// <summary>Either the angle bracket key or the backslash key on the RT 102-key keyboard</summary>
		VK_OEM_102 = 0xE2,

		/// <summary>IME PROCESS key</summary>
		VK_PROCESSKEY = 0xE5,

		/// <summary>OEM specific</summary>
		VK_ICO_CLEAR = 0xE6,

		/// <summary>
		/// Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value
		/// used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
		/// </summary>
		VK_PACKET = 0xE7,

		/// <summary>Nokia/Ericsson definition</summary>
		VK_OEM_RESET = 0xE9,

		/// <summary>Nokia/Ericsson definition</summary>
		VK_OEM_JUMP = 0xEA,

		/// <summary>Nokia/Ericsson definition</summary>
		VK_OEM_PA1 = 0xEB,

		/// <summary>Nokia/Ericsson definition</summary>
		VK_OEM_PA2 = 0xEC,

		/// <summary>Nokia/Ericsson definition</summary>
		VK_OEM_PA3 = 0xED,

		/// <summary>Nokia/Ericsson definition</summary>
		VK_OEM_WSCTRL = 0xEE,

		/// <summary>Nokia/Ericsson definition</summary>
		VK_OEM_CUSEL = 0xEF,

		/// <summary>Nokia/Ericsson definition</summary>
		VK_OEM_ATTN = 0xF0,

		/// <summary>Nokia/Ericsson definition</summary>
		VK_OEM_FINISH = 0xF1,

		/// <summary>Nokia/Ericsson definition</summary>
		VK_OEM_COPY = 0xF2,

		/// <summary>Nokia/Ericsson definition</summary>
		VK_OEM_AUTO = 0xF3,

		/// <summary>Nokia/Ericsson definition</summary>
		VK_OEM_ENLW = 0xF4,

		/// <summary>Nokia/Ericsson definition</summary>
		VK_OEM_BACKTAB = 0xF5,

		/// <summary>Attn key</summary>
		VK_ATTN = 0xF6,

		/// <summary>CrSel key</summary>
		VK_CRSEL = 0xF7,

		/// <summary>ExSel key</summary>
		VK_EXSEL = 0xF8,

		/// <summary>Erase EOF key</summary>
		VK_EREOF = 0xF9,

		/// <summary>Play key</summary>
		VK_PLAY = 0xFA,

		/// <summary>Zoom key</summary>
		VK_ZOOM = 0xFB,

		/// <summary>Reserved</summary>
		VK_NONAME = 0xFC,

		/// <summary>PA1 key</summary>
		VK_PA1 = 0xFD,

		/// <summary>Clear key</summary>
		VK_OEM_CLEAR = 0xFE,
	}

	/// <summary>
	/// Sets the input locale identifier (formerly called the keyboard layout handle) for the calling thread or the current process. The
	/// input locale identifier specifies a locale as well as the physical layout of the keyboard.
	/// </summary>
	/// <param name="hkl">
	/// <para>Type: <c>HKL</c></para>
	/// <para>Input locale identifier to be activated.</para>
	/// <para>
	/// The input locale identifier must have been loaded by a previous call to the LoadKeyboardLayout function. This parameter must be
	/// either the handle to a keyboard layout or one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HKL_NEXT 1</term>
	/// <term>Selects the next locale identifier in the circular list of loaded locale identifiers maintained by the system.</term>
	/// </item>
	/// <item>
	/// <term>HKL_PREV 0</term>
	/// <term>Selects the previous locale identifier in the circular list of loaded locale identifiers maintained by the system.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Specifies how the input locale identifier is to be activated. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KLF_REORDER 0x00000008</term>
	/// <term>
	/// If this bit is set, the system's circular list of loaded locale identifiers is reordered by moving the locale identifier to the
	/// head of the list. If this bit is not set, the list is rotated without a change of order. For example, if a user had an English
	/// locale identifier active, as well as having French, German, and Spanish locale identifiers loaded (in that order), then
	/// activating the German locale identifier with the KLF_REORDER bit set would produce the following order: German, English, French,
	/// Spanish. Activating the German locale identifier without the KLF_REORDER bit set would produce the following order: German,
	/// Spanish, English, French. If less than three locale identifiers are loaded, the value of this flag is irrelevant.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KLF_RESET 0x40000000</term>
	/// <term>
	/// If set but KLF_SHIFTLOCK is not set, the Caps Lock state is turned off by pressing the Caps Lock key again. If set and
	/// KLF_SHIFTLOCK is also set, the Caps Lock state is turned off by pressing either SHIFT key. These two methods are mutually
	/// exclusive, and the setting persists as part of the User's profile in the registry.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KLF_SETFORPROCESS 0x00000100</term>
	/// <term>
	/// Activates the specified locale identifier for the entire process and sends the WM_INPUTLANGCHANGE message to the current
	/// thread's focus or active window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KLF_SHIFTLOCK 0x00010000</term>
	/// <term>This is used with KLF_RESET. See KLF_RESET for an explanation.</term>
	/// </item>
	/// <item>
	/// <term>KLF_UNLOADPREVIOUS</term>
	/// <term>This flag is unsupported. Use the UnloadKeyboardLayout function instead.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HKL</c></para>
	/// <para>
	/// The return value is of type <c>HKL</c>. If the function succeeds, the return value is the previous input locale identifier.
	/// Otherwise, it is zero.
	/// </para>
	/// <para>To get extended error information, use the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function only affects the layout for the current process or thread.</para>
	/// <para>
	/// This function is not restricted to keyboard layouts. The hkl parameter is actually an input locale identifier. This is a broader
	/// concept than a keyboard layout, since it can also encompass a speech-to-text converter, an Input Method Editor (IME), or any
	/// other form of input. Several input locale identifiers can be loaded at any one time, but only one is active at a time. Loading
	/// multiple input locale identifiers makes it possible to rapidly switch between them.
	/// </para>
	/// <para>
	/// When multiple IMEs are allowed for each locale, passing an input locale identifier in which the high word (the device handle) is
	/// zero activates the first IME in the list belonging to the locale.
	/// </para>
	/// <para>
	/// The <c>KLF_RESET</c> and <c>KLF_SHIFTLOCK</c> flags alter the method by which the Caps Lock state is turned off. By default, the
	/// Caps Lock state is turned off by hitting the Caps Lock key again. If only <c>KLF_RESET</c> is set, the default state is
	/// reestablished. If <c>KLF_RESET</c> and <c>KLF_SHIFTLOCK</c> are set, the Caps Lock state is turned off by pressing either Caps
	/// Lock key. This feature is used to conform to local keyboard behavior standards as well as for personal preferences.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-activatekeyboardlayout HKL ActivateKeyboardLayout( HKL
	// hkl, UINT Flags );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h")]
	public static extern HKL ActivateKeyboardLayout(HKL hkl, KLF Flags);

	/// <summary>Blocks keyboard and mouse input events from reaching applications.</summary>
	/// <param name="fBlockIt">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// The function's purpose. If this parameter is <c>TRUE</c>, keyboard and mouse input events are blocked. If this parameter is
	/// <c>FALSE</c>, keyboard and mouse events are unblocked. Note that only the thread that blocked input can successfully unblock input.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If input is already blocked, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When input is blocked, real physical input from the mouse or keyboard will not affect the input queue's synchronous key state
	/// (reported by GetKeyState and GetKeyboardState), nor will it affect the asynchronous key state (reported by GetAsyncKeyState).
	/// However, the thread that is blocking input can affect both of these key states by calling SendInput. No other thread can do this.
	/// </para>
	/// <para>The system will unblock input in the following cases:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The thread that blocked input unexpectedly exits without calling <c>BlockInput</c> with fBlock set to <c>FALSE</c>. In this
	/// case, the system cleans up properly and re-enables input.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The user presses CTRL+ALT+DEL or the system invokes the <c>Hard System Error</c> modal message box (for example, when a program
	/// faults or a device fails).
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-blockinput BOOL BlockInput( BOOL fBlockIt );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool BlockInput([MarshalAs(UnmanagedType.Bool)] bool fBlockIt);

	/// <summary>
	/// Determines whether a key is up or down at the time the function is called, and whether the key was pressed after a previous call
	/// to <c>GetAsyncKeyState</c>.
	/// </summary>
	/// <param name="vKey">
	/// <para>Type: <c>int</c></para>
	/// <para>The virtual-key code. For more information, see Virtual Key Codes.</para>
	/// <para>You can use left- and right-distinguishing constants to specify certain keys. See the Remarks section for further information.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>SHORT</c></para>
	/// <para>
	/// If the function succeeds, the return value specifies whether the key was pressed since the last call to <c>GetAsyncKeyState</c>,
	/// and whether the key is currently up or down. If the most significant bit is set, the key is down, and if the least significant
	/// bit is set, the key was pressed after the previous call to <c>GetAsyncKeyState</c>. However, you should not rely on this last
	/// behavior; for more information, see the Remarks.
	/// </para>
	/// <para>The return value is zero for the following cases:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The current desktop is not the active desktop</term>
	/// </item>
	/// <item>
	/// <term>The foreground thread belongs to another process and the desktop does not allow the hook or the journal record.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GetAsyncKeyState</c> function works with mouse buttons. However, it checks on the state of the physical mouse buttons,
	/// not on the logical mouse buttons that the physical buttons are mapped to. For example, the call
	/// <c>GetAsyncKeyState</c>(VK_LBUTTON) always returns the state of the left physical mouse button, regardless of whether it is
	/// mapped to the left or right logical mouse button. You can determine the system's current mapping of physical mouse buttons to
	/// logical mouse buttons by calling .
	/// </para>
	/// <para>which returns TRUE if the mouse buttons have been swapped.</para>
	/// <para>
	/// Although the least significant bit of the return value indicates whether the key has been pressed since the last query, due to
	/// the pre-emptive multitasking nature of Windows, another application can call <c>GetAsyncKeyState</c> and receive the "recently
	/// pressed" bit instead of your application. The behavior of the least significant bit of the return value is retained strictly for
	/// compatibility with 16-bit Windows applications (which are non-preemptive) and should not be relied upon.
	/// </para>
	/// <para>
	/// You can use the virtual-key code constants <c>VK_SHIFT</c>, <c>VK_CONTROL</c>, and <c>VK_MENU</c> as values for the vKey
	/// parameter. This gives the state of the SHIFT, CTRL, or ALT keys without distinguishing between left and right.
	/// </para>
	/// <para>
	/// You can use the following virtual-key code constants as values for vKey to distinguish between the left and right instances of
	/// those keys.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>VK_LSHIFT</term>
	/// <term>Left-shift key.</term>
	/// </item>
	/// <item>
	/// <term>VK_RSHIFT</term>
	/// <term>Right-shift key.</term>
	/// </item>
	/// <item>
	/// <term>VK_LCONTROL</term>
	/// <term>Left-control key.</term>
	/// </item>
	/// <item>
	/// <term>VK_RCONTROL</term>
	/// <term>Right-control key.</term>
	/// </item>
	/// <item>
	/// <term>VK_LMENU</term>
	/// <term>Left-menu key.</term>
	/// </item>
	/// <item>
	/// <term>VK_RMENU</term>
	/// <term>Right-menu key.</term>
	/// </item>
	/// </list>
	/// <para>
	/// These left- and right-distinguishing constants are only available when you call the GetKeyboardState, SetKeyboardState,
	/// <c>GetAsyncKeyState</c>, GetKeyState, and MapVirtualKey functions.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getasynckeystate SHORT GetAsyncKeyState( int vKey );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern short GetAsyncKeyState(int vKey);

	/// <summary>
	/// <para>Retrieves the current code page.</para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the
	/// GetOEMCP function to retrieve the OEM code-page identifier for the system.
	/// </para>
	/// </summary>
	/// <returns>
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The return value is an OEM code-page identifier, or it is the default identifier if the registry value is not readable. For a
	/// list of OEM code-page identifiers, see Code Page Identifiers.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getkbcodepage UINT GetKBCodePage( );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern uint GetKBCodePage();

	/// <summary>Retrieves the active input locale identifier (formerly called the keyboard layout).</summary>
	/// <param name="idThread">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The identifier of the thread to query, or 0 for the current thread.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HKL</c></para>
	/// <para>
	/// The return value is the input locale identifier for the thread. The low word contains a Language Identifier for the input
	/// language and the high word contains a device handle to the physical layout of the keyboard.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The input locale identifier is a broader concept than a keyboard layout, since it can also encompass a speech-to-text converter,
	/// an Input Method Editor (IME), or any other form of input.
	/// </para>
	/// <para>
	/// Since the keyboard layout can be dynamically changed, applications that cache information about the current keyboard layout
	/// should process the WM_INPUTLANGCHANGE message to be informed of changes in the input language.
	/// </para>
	/// <para>To get the KLID (keyboard layout ID) of the currently active HKL, call the GetKeyboardLayoutName.</para>
	/// <para>
	/// <c>Beginning in Windows 8:</c> The preferred method to retrieve the language associated with the current keyboard layout or
	/// input method is a call to Windows.Globalization.Language.CurrentInputMethodLanguageTag. If your app passes language tags from
	/// <c>CurrentInputMethodLanguageTag</c> to any National Language Support functions, it must first convert the tags by calling ResolveLocaleName.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getkeyboardlayout HKL GetKeyboardLayout( DWORD idThread );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern HKL GetKeyboardLayout(uint idThread);

	/// <summary>
	/// Retrieves the input locale identifiers (formerly called keyboard layout handles) corresponding to the current set of input
	/// locales in the system. The function copies the identifiers to the specified buffer.
	/// </summary>
	/// <param name="nBuff">
	/// <para>Type: <c>int</c></para>
	/// <para>The maximum number of handles that the buffer can hold.</para>
	/// </param>
	/// <param name="lpList">
	/// <para>Type: <c>HKL*</c></para>
	/// <para>A pointer to the buffer that receives the array of input locale identifiers.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// If the function succeeds, the return value is the number of input locale identifiers copied to the buffer or, if nBuff is zero,
	/// the return value is the size, in array elements, of the buffer needed to receive all current input locale identifiers.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The input locale identifier is a broader concept than a keyboard layout, since it can also encompass a speech-to-text converter,
	/// an Input Method Editor (IME), or any other form of input.
	/// </para>
	/// <para>
	/// <c>Beginning in Windows 8:</c> The preferred method to retrieve the language associated with the current keyboard layout or
	/// input method is a call to Windows.Globalization.Language.CurrentInputMethodLanguageTag. If your app passes language tags from
	/// <c>CurrentInputMethodLanguageTag</c> to any National Language Support functions, it must first convert the tags by calling ResolveLocaleName.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getkeyboardlayoutlist int GetKeyboardLayoutList( int
	// nBuff, HKL *lpList );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern int GetKeyboardLayoutList(int nBuff, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] HKL[] lpList);

	/// <summary>Retrieves the name of the active input locale identifier (formerly called the keyboard layout) for the system.</summary>
	/// <param name="pwszKLID">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// The buffer (of at least <c>KL_NAMELENGTH</c> characters in length) that receives the name of the input locale identifier,
	/// including the terminating null character. This will be a copy of the string provided to the LoadKeyboardLayout function, unless
	/// layout substitution took place.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The input locale identifier is a broader concept than a keyboard layout, since it can also encompass a speech-to-text converter,
	/// an Input Method Editor (IME), or any other form of input.
	/// </para>
	/// <para>
	/// <c>Beginning in Windows 8:</c> The preferred method to retrieve the language associated with the current keyboard layout or
	/// input method is a call to Windows.Globalization.Language.CurrentInputMethodLanguageTag. If your app passes language tags from
	/// <c>CurrentInputMethodLanguageTag</c> to any National Language Support functions, it must first convert the tags by calling ResolveLocaleName.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getkeyboardlayoutnamea BOOL GetKeyboardLayoutNameA( LPSTR
	// pwszKLID );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetKeyboardLayoutName(StringBuilder pwszKLID);

	/// <summary>Copies the status of the 256 virtual keys to the specified buffer.</summary>
	/// <param name="lpKeyState">
	/// <para>Type: <c>PBYTE</c></para>
	/// <para>The 256-byte array that receives the status data for each virtual key.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application can call this function to retrieve the current status of all the virtual keys. The status changes as a thread
	/// removes keyboard messages from its message queue. The status does not change as keyboard messages are posted to the thread's
	/// message queue, nor does it change as keyboard messages are posted to or retrieved from message queues of other threads.
	/// (Exception: Threads that are connected through AttachThreadInput share the same keyboard state.)
	/// </para>
	/// <para>
	/// When the function returns, each member of the array pointed to by the lpKeyState parameter contains status data for a virtual
	/// key. If the high-order bit is 1, the key is down; otherwise, it is up. If the key is a toggle key, for example CAPS LOCK, then
	/// the low-order bit is 1 when the key is toggled and is 0 if the key is untoggled. The low-order bit is meaningless for non-toggle
	/// keys. A toggle key is said to be toggled when it is turned on. A toggle key's indicator light (if any) on the keyboard will be
	/// on when the key is toggled, and off when the key is untoggled.
	/// </para>
	/// <para>
	/// To retrieve status information for an individual key, use the GetKeyState function. To retrieve the current state for an
	/// individual key regardless of whether the corresponding keyboard message has been retrieved from the message queue, use the
	/// GetAsyncKeyState function.
	/// </para>
	/// <para>
	/// An application can use the virtual-key code constants <c>VK_SHIFT</c>, <c>VK_CONTROL</c> and <c>VK_MENU</c> as indices into the
	/// array pointed to by lpKeyState. This gives the status of the SHIFT, CTRL, or ALT keys without distinguishing between left and
	/// right. An application can also use the following virtual-key code constants as indices to distinguish between the left and right
	/// instances of those keys:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>VK_LSHIFT</term>
	/// </listheader>
	/// <item>
	/// <term>VK_RSHIFT</term>
	/// </item>
	/// <item>
	/// <term>VK_LCONTROL</term>
	/// </item>
	/// <item>
	/// <term>VK_RCONTROL</term>
	/// </item>
	/// <item>
	/// <term>VK_LMENU</term>
	/// </item>
	/// <item>
	/// <term>VK_RMENU</term>
	/// </item>
	/// </list>
	/// <para>
	/// These left- and right-distinguishing constants are available to an application only through the <c>GetKeyboardState</c>,
	/// SetKeyboardState, GetAsyncKeyState, GetKeyState, and MapVirtualKey functions.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getkeyboardstate BOOL GetKeyboardState( PBYTE lpKeyState );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetKeyboardState(byte[] lpKeyState);

	/// <summary>Retrieves information about the current keyboard.</summary>
	/// <param name="nTypeFlag">
	/// <para>Type: <c>int</c></para>
	/// <para>The type of keyboard information to be retrieved. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Keyboard type</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>Keyboard subtype</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>The number of function keys on the keyboard</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>If the function succeeds, the return value specifies the requested information.</para>
	/// <para>
	/// If the function fails and nTypeFlag is not one, the return value is zero; zero is a valid return value when nTypeFlag is one
	/// (keyboard subtype). To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>The type may be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>IBM PC/XT or compatible (83-key) keyboard</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Olivetti "ICO" (102-key) keyboard</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>IBM PC/AT (84-key) or similar keyboard</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>IBM enhanced (101- or 102-key) keyboard</term>
	/// </item>
	/// <item>
	/// <term>5</term>
	/// <term>Nokia 1050 and similar keyboards</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>Nokia 9140 and similar keyboards</term>
	/// </item>
	/// <item>
	/// <term>7</term>
	/// <term>Japanese keyboard</term>
	/// </item>
	/// </list>
	/// <para>The subtype is an original equipment manufacturer (OEM)-dependent value.</para>
	/// <para>
	/// The application can also determine the number of function keys on a keyboard from the keyboard type. Following are the number of
	/// function keys for each keyboard type.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type</term>
	/// <term>Number of function keys</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>10</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>12 (sometimes 18)</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>10</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>12</term>
	/// </item>
	/// <item>
	/// <term>5</term>
	/// <term>10</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>24</term>
	/// </item>
	/// <item>
	/// <term>7</term>
	/// <term>Hardware dependent and specified by the OEM</term>
	/// </item>
	/// </list>
	/// <para>When a single USB keyboard is connected to the computer, this function returns the code 81.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getkeyboardtype int GetKeyboardType( int nTypeFlag );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "39b9ba8b-0cab-465c-9a58-2b69eea7de76")]
	public static extern int GetKeyboardType(int nTypeFlag);

	/// <summary>Retrieves a string that represents the name of a key.</summary>
	/// <param name="lParam">
	/// <para>Type: <c>LONG</c></para>
	/// <para>
	/// The second parameter of the keyboard message (such as WM_KEYDOWN) to be processed. The function interprets the following bit
	/// positions in the lParam.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Bits</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>16-23</term>
	/// <term>Scan code.</term>
	/// </item>
	/// <item>
	/// <term>24</term>
	/// <term>Extended-key flag. Distinguishes some keys on an enhanced keyboard.</term>
	/// </item>
	/// <item>
	/// <term>25</term>
	/// <term>
	/// "Do not care" bit. The application calling this function sets this bit to indicate that the function should not distinguish
	/// between left and right CTRL and SHIFT keys, for example.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpString">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>The buffer that will receive the key name.</para>
	/// </param>
	/// <param name="cchSize">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The maximum length, in characters, of the key name, including the terminating null character. (This parameter should be equal to
	/// the size of the buffer pointed to by the lpString parameter.)
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// If the function succeeds, a null-terminated string is copied into the specified buffer, and the return value is the length of
	/// the string, in characters, not counting the terminating null character.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// The format of the key-name string depends on the current keyboard layout. The keyboard driver maintains a list of names in the
	/// form of character strings for keys with names longer than a single character. The key name is translated according to the layout
	/// of the currently installed keyboard, thus the function may give different results for different input locales. The name of a
	/// character key is the character itself. The names of dead keys are spelled out in full.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getkeynametexta int GetKeyNameTextA( LONG lParam, LPSTR
	// lpString, int cchSize );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern int GetKeyNameText(int lParam, StringBuilder lpString, int cchSize);

	/// <summary>
	/// Retrieves the status of the specified virtual key. The status specifies whether the key is up, down, or toggled (on,
	/// off—alternating each time the key is pressed).
	/// </summary>
	/// <param name="nVirtKey">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// A virtual key. If the desired virtual key is a letter or digit (A through Z, a through z, or 0 through 9), nVirtKey must be set
	/// to the ASCII value of that character. For other keys, it must be a virtual-key code.
	/// </para>
	/// <para>
	/// If a non-English keyboard layout is used, virtual keys with values in the range ASCII A through Z and 0 through 9 are used to
	/// specify most of the character keys. For example, for the German keyboard layout, the virtual key of value ASCII O (0x4F) refers
	/// to the "o" key, whereas VK_OEM_1 refers to the "o with umlaut" key.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>SHORT</c></para>
	/// <para>The return value specifies the status of the specified virtual key, as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>If the high-order bit is 1, the key is down; otherwise, it is up.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If the low-order bit is 1, the key is toggled. A key, such as the CAPS LOCK key, is toggled if it is turned on. The key is off
	/// and untoggled if the low-order bit is 0. A toggle key's indicator light (if any) on the keyboard will be on when the key is
	/// toggled, and off when the key is untoggled.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The key status returned from this function changes as a thread reads key messages from its message queue. The status does not
	/// reflect the interrupt-level state associated with the hardware. Use the GetAsyncKeyState function to retrieve that information.
	/// </para>
	/// <para>
	/// An application calls <c>GetKeyState</c> in response to a keyboard-input message. This function retrieves the state of the key
	/// when the input message was generated.
	/// </para>
	/// <para>To retrieve state information for all the virtual keys, use the GetKeyboardState function.</para>
	/// <para>
	/// An application can use the virtual key code constants <c>VK_SHIFT</c>, <c>VK_CONTROL</c>, and <c>VK_MENU</c> as values for the
	/// nVirtKey parameter. This gives the status of the SHIFT, CTRL, or ALT keys without distinguishing between left and right. An
	/// application can also use the following virtual-key code constants as values for nVirtKey to distinguish between the left and
	/// right instances of those keys:
	/// </para>
	/// <para>
	/// <c>VK_LSHIFT</c><c>VK_RSHIFT</c><c>VK_LCONTROL</c><c>VK_RCONTROL</c><c>VK_LMENU</c><c>VK_RMENU</c> These left- and
	/// right-distinguishing constants are available to an application only through the GetKeyboardState, SetKeyboardState,
	/// GetAsyncKeyState, <c>GetKeyState</c>, and MapVirtualKey functions.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Displaying Keyboard Input.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getkeystate SHORT GetKeyState( int nVirtKey );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern short GetKeyState(int nVirtKey);

	/// <summary>
	/// <para>
	/// Synthesizes a keystroke. The system can use such a synthesized keystroke to generate a WM_KEYUP or WM_KEYDOWN message. The
	/// keyboard driver's interrupt handler calls the <c>keybd_event</c> function.
	/// </para>
	/// <para><c>Note</c> This function has been superseded. Use SendInput instead.</para>
	/// </summary>
	/// <param name="bVk">
	/// <para>Type: <c>BYTE</c></para>
	/// <para>A virtual-key code. The code must be a value in the range 1 to 254. For a complete list, see Virtual Key Codes.</para>
	/// </param>
	/// <param name="bScan">
	/// <para>Type: <c>BYTE</c></para>
	/// <para>A hardware scan code for the key.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Controls various aspects of function operation. This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KEYEVENTF_EXTENDEDKEY 0x0001</term>
	/// <term>If specified, the scan code was preceded by a prefix byte having the value 0xE0 (224).</term>
	/// </item>
	/// <item>
	/// <term>KEYEVENTF_KEYUP 0x0002</term>
	/// <term>If specified, the key is being released. If not specified, the key is being depressed.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwExtraInfo">
	/// <para>Type: <c>ULONG_PTR</c></para>
	/// <para>An additional value associated with the key stroke.</para>
	/// </param>
	/// <remarks>
	/// <para>
	/// An application can simulate a press of the PRINTSCRN key in order to obtain a screen snapshot and save it to the clipboard. To
	/// do this, call <c>keybd_event</c> with the bVk parameter set to <c>VK_SNAPSHOT</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following sample program toggles the NUM LOCK light by using <c>keybd_event</c> with a virtual key of <c>VK_NUMLOCK</c>. It
	/// takes a Boolean value that indicates whether the light should be turned off ( <c>FALSE</c>) or on ( <c>TRUE</c>). The same
	/// technique can be used for the CAPS LOCK key ( <c>VK_CAPITAL</c>) and the SCROLL LOCK key ( <c>VK_SCROLL</c>).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-keybd_event void keybd_event( BYTE bVk, BYTE bScan, DWORD
	// dwFlags, ULONG_PTR dwExtraInfo );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern void keybd_event(byte bVk, byte bScan, KEYEVENTF dwFlags, IntPtr dwExtraInfo = default);

	/// <summary>
	/// <para>Loads a new input locale identifier (formerly called the keyboard layout) into the system.</para>
	/// <para>
	/// <c>Prior to Windows 8:</c> Several input locale identifiers can be loaded at a time, but only one per process is active at a
	/// time. Loading multiple input locale identifiers makes it possible to rapidly switch between them.
	/// </para>
	/// <para>
	/// <c>Beginning in Windows 8:</c> The input locale identifier is loaded for the entire system. This function has no effect if the
	/// current process does not own the window with keyboard focus.
	/// </para>
	/// </summary>
	/// <param name="pwszKLID">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The name of the input locale identifier to load. This name is a string composed of the hexadecimal value of the Language
	/// Identifier (low word) and a device identifier (high word). For example, U.S. English has a language identifier of 0x0409, so the
	/// primary U.S. English layout is named "00000409". Variants of U.S. English layout (such as the Dvorak layout) are named
	/// "00010409", "00020409", and so on.
	/// </para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Specifies how the input locale identifier is to be loaded. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KLF_ACTIVATE 0x00000001</term>
	/// <term>
	/// Prior to Windows 8: If the specified input locale identifier is not already loaded, the function loads and activates the input
	/// locale identifier for the current thread. Beginning in Windows 8: If the specified input locale identifier is not already
	/// loaded, the function loads and activates the input locale identifier for the system.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KLF_NOTELLSHELL 0x00000080</term>
	/// <term>
	/// Prior to Windows 8: Prevents a ShellProchook procedure from receiving an HSHELL_LANGUAGE hook code when the new input locale
	/// identifier is loaded. This value is typically used when an application loads multiple input locale identifiers one after
	/// another. Applying this value to all but the last input locale identifier delays the shell's processing until all input locale
	/// identifiers have been added. Beginning in Windows 8: In this scenario, the last input locale identifier is set for the entire system.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KLF_REORDER 0x00000008</term>
	/// <term>
	/// Prior to Windows 8: Moves the specified input locale identifier to the head of the input locale identifier list, making that
	/// locale identifier the active locale identifier for the current thread. This value reorders the input locale identifier list even
	/// if KLF_ACTIVATE is not provided. Beginning in Windows 8: Moves the specified input locale identifier to the head of the input
	/// locale identifier list, making that locale identifier the active locale identifier for the system. This value reorders the input
	/// locale identifier list even if KLF_ACTIVATE is not provided.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KLF_REPLACELANG 0x00000010</term>
	/// <term>
	/// If the new input locale identifier has the same language identifier as a current input locale identifier, the new input locale
	/// identifier replaces the current one as the input locale identifier for that language. If this value is not provided and the
	/// input locale identifiers have the same language identifiers, the current input locale identifier is not replaced and the
	/// function returns NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KLF_SUBSTITUTE_OK 0x00000002</term>
	/// <term>
	/// Substitutes the specified input locale identifier with another locale preferred by the user. The system starts with this flag
	/// set, and it is recommended that your application always use this flag. The substitution occurs only if the registry key
	/// HKEY_CURRENT_USER\Keyboard\Layout\Substitutes explicitly defines a substitution locale. For example, if the key includes the
	/// value name "00000409" with value "00010409", loading the U.S. English layout ("00000409") causes the Dvorak U.S. English layout
	/// ("00010409") to be loaded instead. The system uses KLF_SUBSTITUTE_OK when booting, and it is recommended that all applications
	/// use this value when loading input locale identifiers to ensure that the user's preference is selected.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KLF_SETFORPROCESS 0x00000100</term>
	/// <term>
	/// Prior to Windows 8: This flag is valid only with KLF_ACTIVATE. Activates the specified input locale identifier for the entire
	/// process and sends the WM_INPUTLANGCHANGE message to the current thread's Focus or Active window. Typically, LoadKeyboardLayout
	/// activates an input locale identifier only for the current thread. Beginning in Windows 8: This flag is not used.
	/// LoadKeyboardLayout always activates an input locale identifier for the entire system if the current process owns the window with
	/// keyboard focus.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KLF_UNLOADPREVIOUS</term>
	/// <term>This flag is unsupported. Use the UnloadKeyboardLayout function instead.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HKL</c></para>
	/// <para>
	/// If the function succeeds, the return value is the input locale identifier corresponding to the name specified in pwszKLID. If no
	/// matching locale is available, the return value is the default language of the system. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The input locale identifier is a broader concept than a keyboard layout, since it can also encompass a speech-to-text converter,
	/// an Input Method Editor (IME), or any other form of input.
	/// </para>
	/// <para>
	/// An application can and will typically load the default input locale identifier or IME for a language and can do so by specifying
	/// only a string version of the language identifier. If an application wants to load a specific locale or IME, it should read the
	/// registry to determine the specific input locale identifier to pass to <c>LoadKeyboardLayout</c>. In this case, a request to
	/// activate the default input locale identifier for a locale will activate the first matching one. A specific IME should be
	/// activated using an explicit input locale identifier returned from GetKeyboardLayout or <c>LoadKeyboardLayout</c>.
	/// </para>
	/// <para><c>Prior to Windows 8:</c> This function only affects the layout for the current process or thread.</para>
	/// <para><c>Beginning in Windows 8:</c> This function affects the layout for the entire system.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-loadkeyboardlayouta HKL LoadKeyboardLayoutA( LPCSTR
	// pwszKLID, UINT Flags );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern SafeHKL LoadKeyboardLayout(string pwszKLID, KLF Flags);

	/// <summary>
	/// <para>
	/// Translates (maps) a virtual-key code into a scan code or character value, or translates a scan code into a virtual-key code.
	/// </para>
	/// <para>To specify a handle to the keyboard layout to use for translating the specified code, use the MapVirtualKeyEx function.</para>
	/// </summary>
	/// <param name="uCode">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The virtual key code or scan code for a key. How this value is interpreted depends on the value of the uMapType parameter.</para>
	/// </param>
	/// <param name="uMapType">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The translation to be performed. The value of this parameter depends on the value of the uCode parameter.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MAPVK_VK_TO_CHAR 2</term>
	/// <term>
	/// uCode is a virtual-key code and is translated into an unshifted character value in the low-order word of the return value. Dead
	/// keys (diacritics) are indicated by setting the top bit of the return value. If there is no translation, the function returns 0.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MAPVK_VK_TO_VSC 0</term>
	/// <term>
	/// uCode is a virtual-key code and is translated into a scan code. If it is a virtual-key code that does not distinguish between
	/// left- and right-hand keys, the left-hand scan code is returned. If there is no translation, the function returns 0.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MAPVK_VSC_TO_VK 1</term>
	/// <term>
	/// uCode is a scan code and is translated into a virtual-key code that does not distinguish between left- and right-hand keys. If
	/// there is no translation, the function returns 0.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MAPVK_VSC_TO_VK_EX 3</term>
	/// <term>
	/// uCode is a scan code and is translated into a virtual-key code that distinguishes between left- and right-hand keys. If there is
	/// no translation, the function returns 0.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The return value is either a scan code, a virtual-key code, or a character value, depending on the value of uCode and uMapType.
	/// If there is no translation, the return value is zero.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application can use <c>MapVirtualKey</c> to translate scan codes to the virtual-key code constants <c>VK_SHIFT</c>,
	/// <c>VK_CONTROL</c>, and <c>VK_MENU</c>, and vice versa. These translations do not distinguish between the left and right
	/// instances of the SHIFT, CTRL, or ALT keys.
	/// </para>
	/// <para>
	/// An application can get the scan code corresponding to the left or right instance of one of these keys by calling
	/// <c>MapVirtualKey</c> with uCode set to one of the following virtual-key code constants.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>VK_LSHIFT</c></term>
	/// </item>
	/// <item>
	/// <term><c>VK_RSHIFT</c></term>
	/// </item>
	/// <item>
	/// <term><c>VK_LCONTROL</c></term>
	/// </item>
	/// <item>
	/// <term><c>VK_RCONTROL</c></term>
	/// </item>
	/// <item>
	/// <term><c>VK_LMENU</c></term>
	/// </item>
	/// <item>
	/// <term><c>VK_RMENU</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// These left- and right-distinguishing constants are available to an application only through the GetKeyboardState,
	/// SetKeyboardState, GetAsyncKeyState, GetKeyState, and <c>MapVirtualKey</c> functions.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-mapvirtualkeya UINT MapVirtualKeyA( UINT uCode, UINT
	// uMapType );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern uint MapVirtualKey(uint uCode, MAPVK uMapType);

	/// <summary>
	/// Translates (maps) a virtual-key code into a scan code or character value, or translates a scan code into a virtual-key code. The
	/// function translates the codes using the input language and an input locale identifier.
	/// </summary>
	/// <param name="uCode">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The virtual-key code or scan code for a key. How this value is interpreted depends on the value of the uMapType parameter.</para>
	/// <para>
	/// Starting with Windows Vista, the high byte of the uCode value can contain either 0xe0 or 0xe1 to specify the extended scan code.
	/// </para>
	/// </param>
	/// <param name="uMapType">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The translation to perform. The value of this parameter depends on the value of the uCode parameter.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MAPVK_VK_TO_CHAR 2</term>
	/// <term>
	/// The uCode parameter is a virtual-key code and is translated into an unshifted character value in the low order word of the
	/// return value. Dead keys (diacritics) are indicated by setting the top bit of the return value. If there is no translation, the
	/// function returns 0.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MAPVK_VK_TO_VSC 0</term>
	/// <term>
	/// The uCode parameter is a virtual-key code and is translated into a scan code. If it is a virtual-key code that does not
	/// distinguish between left- and right-hand keys, the left-hand scan code is returned. If there is no translation, the function
	/// returns 0.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MAPVK_VK_TO_VSC_EX 4</term>
	/// <term>
	/// The uCode parameter is a virtual-key code and is translated into a scan code. If it is a virtual-key code that does not
	/// distinguish between left- and right-hand keys, the left-hand scan code is returned. If the scan code is an extended scan code,
	/// the high byte of the uCode value can contain either 0xe0 or 0xe1 to specify the extended scan code. If there is no translation,
	/// the function returns 0.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MAPVK_VSC_TO_VK 1</term>
	/// <term>
	/// The uCode parameter is a scan code and is translated into a virtual-key code that does not distinguish between left- and
	/// right-hand keys. If there is no translation, the function returns 0.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MAPVK_VSC_TO_VK_EX 3</term>
	/// <term>
	/// The uCode parameter is a scan code and is translated into a virtual-key code that distinguishes between left- and right-hand
	/// keys. If there is no translation, the function returns 0.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwhkl">
	/// <para>Type: <c>HKL</c></para>
	/// <para>
	/// Input locale identifier to use for translating the specified code. This parameter can be any input locale identifier previously
	/// returned by the LoadKeyboardLayout function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The return value is either a scan code, a virtual-key code, or a character value, depending on the value of uCode and uMapType.
	/// If there is no translation, the return value is zero.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The input locale identifier is a broader concept than a keyboard layout, since it can also encompass a speech-to-text converter,
	/// an Input Method Editor (IME), or any other form of input.
	/// </para>
	/// <para>
	/// An application can use <c>MapVirtualKeyEx</c> to translate scan codes to the virtual-key code constants <c>VK_SHIFT</c>,
	/// <c>VK_CONTROL</c>, and <c>VK_MENU</c>, and vice versa. These translations do not distinguish between the left and right
	/// instances of the SHIFT, CTRL, or ALT keys.
	/// </para>
	/// <para>
	/// An application can get the scan code corresponding to the left or right instance of one of these keys by calling
	/// <c>MapVirtualKeyEx</c> with uCode set to one of the following virtual-key code constants.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>VK_LSHIFT</c></term>
	/// </item>
	/// <item>
	/// <term><c>VK_RSHIFT</c></term>
	/// </item>
	/// <item>
	/// <term><c>VK_LCONTROL</c></term>
	/// </item>
	/// <item>
	/// <term><c>VK_RCONTROL</c></term>
	/// </item>
	/// <item>
	/// <term><c>VK_LMENU</c></term>
	/// </item>
	/// <item>
	/// <term><c>VK_RMENU</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// These left- and right-distinguishing constants are available to an application only through the GetKeyboardState,
	/// SetKeyboardState, GetAsyncKeyState, GetKeyState, MapVirtualKey, and <c>MapVirtualKeyEx</c> functions. For list complete table of
	/// virtual key codes, see Virtual Key Codes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-mapvirtualkeyexa UINT MapVirtualKeyExA( UINT uCode, UINT
	// uMapType, HKL dwhkl );
	[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern uint MapVirtualKeyEx(uint uCode, MAPVK uMapType, HKL dwhkl);

	/// <summary>
	/// Maps OEMASCII codes 0 through 0x0FF into the OEM scan codes and shift states. The function provides information that allows a
	/// program to send OEM text to another program by simulating keyboard input.
	/// </summary>
	/// <param name="wOemChar">
	/// <para>Type: <c>WORD</c></para>
	/// <para>The ASCII value of the OEM character.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The low-order word of the return value contains the scan code of the OEM character, and the high-order word contains the shift
	/// state, which can be a combination of the following bits.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Bit</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>Either SHIFT key is pressed.</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Either CTRL key is pressed.</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>Either ALT key is pressed.</term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>The Hankaku key is pressed.</term>
	/// </item>
	/// <item>
	/// <term>16</term>
	/// <term>Reserved (defined by the keyboard layout driver).</term>
	/// </item>
	/// <item>
	/// <term>32</term>
	/// <term>Reserved (defined by the keyboard layout driver).</term>
	/// </item>
	/// </list>
	/// <para>If the character cannot be produced by a single keystroke using the current keyboard layout, the return value is –1.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function does not provide translations for characters that require CTRL+ALT or dead keys. Characters not translated by this
	/// function must be copied by simulating input using the ALT+ keypad mechanism. The NUMLOCK key must be off.
	/// </para>
	/// <para>
	/// This function does not provide translations for characters that cannot be typed with one keystroke using the current keyboard
	/// layout, such as characters with diacritics requiring dead keys. Characters not translated by this function may be simulated
	/// using the ALT+ keypad mechanism. The NUMLOCK key must be on.
	/// </para>
	/// <para>This function is implemented using the VkKeyScan function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-oemkeyscan DWORD OemKeyScan( WORD wOemChar );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern uint OemKeyScan(ushort wOemChar);

	/// <summary>
	/// <para>Defines a system-wide hot key.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the window that will receive WM_HOTKEY messages generated by the hot key. If this parameter is <c>NULL</c>,
	/// <c>WM_HOTKEY</c> messages are posted to the message queue of the calling thread and must be processed in the message loop.
	/// </para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>int</c></para>
	/// <para>
	/// The identifier of the hot key. If the hWnd parameter is NULL, then the hot key is associated with the current thread rather than
	/// with a particular window. If a hot key already exists with the same hWnd and id parameters, see Remarks for the action taken.
	/// </para>
	/// </param>
	/// <param name="fsModifiers">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The keys that must be pressed in combination with the key specified by the uVirtKey parameter in order to generate the WM_HOTKEY
	/// message. The fsModifiers parameter can be a combination of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MOD_ALT 0x0001</term>
	/// <term>Either ALT key must be held down.</term>
	/// </item>
	/// <item>
	/// <term>MOD_CONTROL 0x0002</term>
	/// <term>Either CTRL key must be held down.</term>
	/// </item>
	/// <item>
	/// <term>MOD_NOREPEAT 0x4000</term>
	/// <term>
	/// Changes the hotkey behavior so that the keyboard auto-repeat does not yield multiple hotkey notifications. Windows Vista: This
	/// flag is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MOD_SHIFT 0x0004</term>
	/// <term>Either SHIFT key must be held down.</term>
	/// </item>
	/// <item>
	/// <term>MOD_WIN 0x0008</term>
	/// <term>
	/// Either WINDOWS key was held down. These keys are labeled with the Windows logo. Keyboard shortcuts that involve the WINDOWS key
	/// are reserved for use by the operating system.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="vk">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The virtual-key code of the hot key. See Virtual Key Codes.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When a key is pressed, the system looks for a match against all hot keys. Upon finding a match, the system posts the WM_HOTKEY
	/// message to the message queue of the window with which the hot key is associated. If the hot key is not associated with a window,
	/// then the <c>WM_HOTKEY</c> message is posted to the thread associated with the hot key.
	/// </para>
	/// <para>This function cannot associate a hot key with a window created by another thread.</para>
	/// <para><c>RegisterHotKey</c> fails if the keystrokes specified for the hot key have already been registered by another hot key.</para>
	/// <para>
	/// If a hot key already exists with the same hWnd and id parameters, it is maintained along with the new hot key. The application
	/// must explicitly call UnregisterHotKey to unregister the old hot key.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003:</c> If a hot key already exists with the same hWnd and id parameters, it is replaced by the new hot key.
	/// </para>
	/// <para>
	/// The F12 key is reserved for use by the debugger at all times, so it should not be registered as a hot key. Even when you are not
	/// debugging an application, F12 is reserved in case a kernel-mode debugger or a just-in-time debugger is resident.
	/// </para>
	/// <para>
	/// An application must specify an id value in the range 0x0000 through 0xBFFF. A shared DLL must specify a value in the range
	/// 0xC000 through 0xFFFF (the range returned by the GlobalAddAtom function). To avoid conflicts with hot-key identifiers defined by
	/// other shared DLLs, a DLL should use the <c>GlobalAddAtom</c> function to obtain the hot-key identifier.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to use the <c>RegisterHotKey</c> function with the <c>MOD_NOREPEAT</c> flag. In this example,
	/// the hotkey 'ALT+b' is registered for the main thread. When the hotkey is pressed, the thread will receive a WM_HOTKEY message,
	/// which will get picked up in the GetMessage call. Because this example uses <c>MOD_ALT</c> with the <c>MOD_NOREPEAT</c> value for
	/// fsModifiers, the thread will only receive another <c>WM_HOTKEY</c> message when the 'b' key is released and then pressed again
	/// while the 'ALT' key is being pressed down.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-registerhotkey BOOL RegisterHotKey( HWND hWnd, int id,
	// UINT fsModifiers, UINT vk );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "registerhotkey")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RegisterHotKey(HWND hWnd, int id, HotKeyModifiers fsModifiers, uint vk);

	/// <summary>
	/// <para>
	/// Copies an array of keyboard key states into the calling thread's keyboard input-state table. This is the same table accessed by
	/// the GetKeyboardState and GetKeyState functions. Changes made to this table do not affect keyboard input to any other thread.
	/// </para>
	/// </summary>
	/// <param name="lpKeyState">
	/// <para>Type: <c>LPBYTE</c></para>
	/// <para>A pointer to a 256-byte array that contains keyboard key states.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Because the <c>SetKeyboardState</c> function alters the input state of the calling thread and not the global input state of the
	/// system, an application cannot use <c>SetKeyboardState</c> to set the NUM LOCK, CAPS LOCK, or SCROLL LOCK (or the Japanese KANA)
	/// indicator lights on the keyboard. These can be set or cleared using SendInput to simulate keystrokes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setkeyboardstate BOOL SetKeyboardState( LPBYTE lpKeyState );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetKeyboardState([In] byte[] lpKeyState);

	/// <summary>
	/// <para>
	/// Translates the specified virtual-key code and keyboard state to the corresponding character or characters. The function
	/// translates the code using the input language and physical keyboard layout identified by the keyboard layout handle.
	/// </para>
	/// <para>To specify a handle to the keyboard layout to use to translate the specified code, use the ToAsciiEx function.</para>
	/// </summary>
	/// <param name="uVirtKey">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The virtual-key code to be translated. See Virtual-Key Codes.</para>
	/// </param>
	/// <param name="uScanCode">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The hardware scan code of the key to be translated. The high-order bit of this value is set if the key is up (not pressed).</para>
	/// </param>
	/// <param name="lpKeyState">
	/// <para>Type: <c>const BYTE*</c></para>
	/// <para>
	/// A pointer to a 256-byte array that contains the current keyboard state. Each element (byte) in the array contains the state of
	/// one key. If the high-order bit of a byte is set, the key is down (pressed).
	/// </para>
	/// <para>
	/// The low bit, if set, indicates that the key is toggled on. In this function, only the toggle bit of the CAPS LOCK key is
	/// relevant. The toggle state of the NUM LOCK and SCROLL LOCK keys is ignored.
	/// </para>
	/// </param>
	/// <param name="lpChar">
	/// <para>Type: <c>LPWORD</c></para>
	/// <para>The buffer that receives the translated character or characters.</para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>This parameter must be 1 if a menu is active, or 0 otherwise.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>If the specified key is a dead key, the return value is negative. Otherwise, it is one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>The specified virtual key has no translation for the current state of the keyboard.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>One character was copied to the buffer.</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>
	/// Two characters were copied to the buffer. This usually happens when a dead-key character (accent or diacritic) stored in the
	/// keyboard layout cannot be composed with the specified virtual key to form a single character.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The parameters supplied to the <c>ToAscii</c> function might not be sufficient to translate the virtual-key code, because a
	/// previous dead key is stored in the keyboard layout.
	/// </para>
	/// <para>
	/// Typically, <c>ToAscii</c> performs the translation based on the virtual-key code. In some cases, however, bit 15 of the
	/// uScanCode parameter may be used to distinguish between a key press and a key release. The scan code is used for translating ALT+
	/// number key combinations.
	/// </para>
	/// <para>
	/// Although NUM LOCK is a toggle key that affects keyboard behavior, <c>ToAscii</c> ignores the toggle setting (the low bit) of
	/// lpKeyState ( <c>VK_NUMLOCK</c>) because the uVirtKey parameter alone is sufficient to distinguish the cursor movement keys (
	/// <c>VK_HOME</c>, <c>VK_INSERT</c>, and so on) from the numeric keys ( <c>VK_DECIMAL</c>, <c>VK_NUMPAD0</c> - <c>VK_NUMPAD9</c>).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-toascii int ToAscii( UINT uVirtKey, UINT uScanCode, const
	// BYTE *lpKeyState, LPWORD lpChar, UINT uFlags );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern int ToAscii(uint uVirtKey, uint uScanCode, byte[] lpKeyState, out ushort lpChar, uint uFlags);

	/// <summary>
	/// Translates the specified virtual-key code and keyboard state to the corresponding character or characters. The function
	/// translates the code using the input language and physical keyboard layout identified by the input locale identifier.
	/// </summary>
	/// <param name="uVirtKey">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The virtual-key code to be translated. See Virtual-Key Codes.</para>
	/// </param>
	/// <param name="uScanCode">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The hardware scan code of the key to be translated. The high-order bit of this value is set if the key is up (not pressed).</para>
	/// </param>
	/// <param name="lpKeyState">
	/// <para>Type: <c>const BYTE*</c></para>
	/// <para>
	/// A pointer to a 256-byte array that contains the current keyboard state. Each element (byte) in the array contains the state of
	/// one key. If the high-order bit of a byte is set, the key is down (pressed).
	/// </para>
	/// <para>
	/// The low bit, if set, indicates that the key is toggled on. In this function, only the toggle bit of the CAPS LOCK key is
	/// relevant. The toggle state of the NUM LOCK and SCOLL LOCK keys is ignored.
	/// </para>
	/// </param>
	/// <param name="lpChar">
	/// <para>Type: <c>LPWORD</c></para>
	/// <para>A pointer to the buffer that receives the translated character or characters.</para>
	/// </param>
	/// <param name="uFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>This parameter must be 1 if a menu is active, zero otherwise.</para>
	/// </param>
	/// <param name="dwhkl">
	/// <para>Type: <c>HKL</c></para>
	/// <para>
	/// Input locale identifier to use to translate the code. This parameter can be any input locale identifier previously returned by
	/// the LoadKeyboardLayout function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>If the specified key is a dead key, the return value is negative. Otherwise, it is one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>The specified virtual key has no translation for the current state of the keyboard.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>One character was copied to the buffer.</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>
	/// Two characters were copied to the buffer. This usually happens when a dead-key character (accent or diacritic) stored in the
	/// keyboard layout cannot be composed with the specified virtual key to form a single character.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The input locale identifier is a broader concept than a keyboard layout, since it can also encompass a speech-to-text converter,
	/// an Input Method Editor (IME), or any other form of input.
	/// </para>
	/// <para>
	/// The parameters supplied to the <c>ToAsciiEx</c> function might not be sufficient to translate the virtual-key code, because a
	/// previous dead key is stored in the keyboard layout.
	/// </para>
	/// <para>
	/// Typically, <c>ToAsciiEx</c> performs the translation based on the virtual-key code. In some cases, however, bit 15 of the
	/// uScanCode parameter may be used to distinguish between a key press and a key release. The scan code is used for translating
	/// ALT+number key combinations.
	/// </para>
	/// <para>
	/// Although NUM LOCK is a toggle key that affects keyboard behavior, <c>ToAsciiEx</c> ignores the toggle setting (the low bit) of
	/// lpKeyState ( <c>VK_NUMLOCK</c>) because the uVirtKey parameter alone is sufficient to distinguish the cursor movement keys (
	/// <c>VK_HOME</c>, <c>VK_INSERT</c>, and so on) from the numeric keys ( <c>VK_DECIMAL</c>, <c>VK_NUMPAD0</c> - <c>VK_NUMPAD9</c>).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-toasciiex int ToAsciiEx( UINT uVirtKey, UINT uScanCode,
	// const BYTE *lpKeyState, LPWORD lpChar, UINT uFlags, HKL dwhkl );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern int ToAsciiEx(uint uVirtKey, uint uScanCode, byte[] lpKeyState, out ushort lpChar, uint uFlags, HKL dwhkl);

	/// <summary>
	/// <para>Translates the specified virtual-key code and keyboard state to the corresponding Unicode character or characters.</para>
	/// <para>To specify a handle to the keyboard layout to use to translate the specified code, use the ToUnicodeEx function.</para>
	/// </summary>
	/// <param name="wVirtKey">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The virtual-key code to be translated. See Virtual-Key Codes.</para>
	/// </param>
	/// <param name="wScanCode">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The hardware scan code of the key to be translated. The high-order bit of this value is set if the key is up.</para>
	/// </param>
	/// <param name="lpKeyState">
	/// <para>Type: <c>const BYTE*</c></para>
	/// <para>
	/// A pointer to a 256-byte array that contains the current keyboard state. Each element (byte) in the array contains the state of
	/// one key. If the high-order bit of a byte is set, the key is down.
	/// </para>
	/// </param>
	/// <param name="pwszBuff">
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>
	/// The buffer that receives the translated Unicode character or characters. However, this buffer may be returned without being
	/// null-terminated even though the variable name suggests that it is null-terminated.
	/// </para>
	/// </param>
	/// <param name="cchBuff">
	/// <para>Type: <c>int</c></para>
	/// <para>The size, in characters, of the buffer pointed to by the pwszBuff parameter.</para>
	/// </param>
	/// <param name="wFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The behavior of the function.</para>
	/// <para>If bit 0 is set, a menu is active.</para>
	/// <para>If bit 2 is set, keyboard state is not changed (Windows 10, version 1607 and newer)</para>
	/// <para>All other bits (through 31) are reserved.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>The function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>-1</term>
	/// <term>
	/// The specified virtual key is a dead-key character (accent or diacritic). This value is returned regardless of the keyboard
	/// layout, even if several characters have been typed and are stored in the keyboard state. If possible, even with Unicode keyboard
	/// layouts, the function has written a spacing version of the dead-key character to the buffer specified by pwszBuff. For example,
	/// the function writes the character SPACING ACUTE (0x00B4), rather than the character NON_SPACING ACUTE (0x0301).
	/// </term>
	/// </item>
	/// <item>
	/// <term>0</term>
	/// <term>
	/// The specified virtual key has no translation for the current state of the keyboard. Nothing was written to the buffer specified
	/// by pwszBuff.
	/// </term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>One character was written to the buffer specified by pwszBuff.</term>
	/// </item>
	/// <item>
	/// <term>2 ≤ value</term>
	/// <term>
	/// Two or more characters were written to the buffer specified by pwszBuff. The most common cause for this is that a dead-key
	/// character (accent or diacritic) stored in the keyboard layout could not be combined with the specified virtual key to form a
	/// single character. However, the buffer may contain more characters than the return value specifies. When this happens, any extra
	/// characters are invalid and should be ignored.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The parameters supplied to the <c>ToUnicode</c> function might not be sufficient to translate the virtual-key code because a
	/// previous dead key is stored in the keyboard layout.
	/// </para>
	/// <para>
	/// Typically, <c>ToUnicode</c> performs the translation based on the virtual-key code. In some cases, however, bit 15 of the
	/// wScanCode parameter can be used to distinguish between a key press and a key release.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-tounicode int ToUnicode( UINT wVirtKey, UINT wScanCode,
	// const BYTE *lpKeyState, LPWSTR pwszBuff, int cchBuff, UINT wFlags );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern int ToUnicode(uint wVirtKey, uint wScanCode, byte[] lpKeyState, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, uint wFlags);

	/// <summary>Translates the specified virtual-key code and keyboard state to the corresponding Unicode character or characters.</summary>
	/// <param name="wVirtKey">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The virtual-key code to be translated. See Virtual-Key Codes.</para>
	/// </param>
	/// <param name="wScanCode">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The hardware scan code of the key to be translated. The high-order bit of this value is set if the key is up.</para>
	/// </param>
	/// <param name="lpKeyState">
	/// <para>Type: <c>const BYTE*</c></para>
	/// <para>
	/// A pointer to a 256-byte array that contains the current keyboard state. Each element (byte) in the array contains the state of
	/// one key. If the high-order bit of a byte is set, the key is down.
	/// </para>
	/// </param>
	/// <param name="pwszBuff">
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>
	/// The buffer that receives the translated Unicode character or characters. However, this buffer may be returned without being
	/// null-terminated even though the variable name suggests that it is null-terminated.
	/// </para>
	/// </param>
	/// <param name="cchBuff">
	/// <para>Type: <c>int</c></para>
	/// <para>The size, in characters, of the buffer pointed to by the pwszBuff parameter.</para>
	/// </param>
	/// <param name="wFlags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The behavior of the function.</para>
	/// <para>If bit 0 is set, a menu is active.</para>
	/// <para>If bit 2 is set, keyboard state is not changed (Windows 10, version 1607 and newer)</para>
	/// <para>All other bits (through 31) are reserved.</para>
	/// </param>
	/// <param name="dwhkl">
	/// <para>Type: <c>HKL</c></para>
	/// <para>
	/// The input locale identifier used to translate the specified code. This parameter can be any input locale identifier previously
	/// returned by the LoadKeyboardLayout function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>The function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>-1</term>
	/// <term>
	/// The specified virtual key is a dead-key character (accent or diacritic). This value is returned regardless of the keyboard
	/// layout, even if several characters have been typed and are stored in the keyboard state. If possible, even with Unicode keyboard
	/// layouts, the function has written a spacing version of the dead-key character to the buffer specified by pwszBuff. For example,
	/// the function writes the character SPACING ACUTE (0x00B4), rather than the character NON_SPACING ACUTE (0x0301).
	/// </term>
	/// </item>
	/// <item>
	/// <term>0</term>
	/// <term>
	/// The specified virtual key has no translation for the current state of the keyboard. Nothing was written to the buffer specified
	/// by pwszBuff.
	/// </term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>One character was written to the buffer specified by pwszBuff.</term>
	/// </item>
	/// <item>
	/// <term>2 ≤ value</term>
	/// <term>
	/// Two or more characters were written to the buffer specified by pwszBuff. The most common cause for this is that a dead-key
	/// character (accent or diacritic) stored in the keyboard layout could not be combined with the specified virtual key to form a
	/// single character. However, the buffer may contain more characters than the return value specifies. When this happens, any extra
	/// characters are invalid and should be ignored.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The input locale identifier is a broader concept than a keyboard layout, since it can also encompass a speech-to-text converter,
	/// an Input Method Editor (IME), or any other form of input.
	/// </para>
	/// <para>
	/// The parameters supplied to the <c>ToUnicodeEx</c> function might not be sufficient to translate the virtual-key code because a
	/// previous dead key is stored in the keyboard layout.
	/// </para>
	/// <para>
	/// Typically, <c>ToUnicodeEx</c> performs the translation based on the virtual-key code. In some cases, however, bit 15 of the
	/// wScanCode parameter can be used to distinguish between a key press and a key release.
	/// </para>
	/// <para>
	/// As <c>ToUnicodeEx</c> translates the virtual-key code, it also changes the state of the kernel-mode keyboard buffer. This
	/// state-change affects dead keys, ligatures, alt+numpad key entry, and so on. It might also cause undesired side-effects if used
	/// in conjunction with TranslateMessage (which also changes the state of the kernel-mode keyboard buffer).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-tounicodeex int ToUnicodeEx( UINT wVirtKey, UINT
	// wScanCode, const BYTE *lpKeyState, LPWSTR pwszBuff, int cchBuff, UINT wFlags, HKL dwhkl );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, uint wFlags, HKL dwhkl);

	/// <summary>Unloads an input locale identifier (formerly called a keyboard layout).</summary>
	/// <param name="hkl">
	/// <para>Type: <c>HKL</c></para>
	/// <para>The input locale identifier to be unloaded.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. The function can fail for the following reasons:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>An invalid input locale identifier was passed.</term>
	/// </item>
	/// <item>
	/// <term>The input locale identifier was preloaded.</term>
	/// </item>
	/// <item>
	/// <term>The input locale identifier is in use.</term>
	/// </item>
	/// </list>
	/// <para>To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The input locale identifier is a broader concept than a keyboard layout, since it can also encompass a speech-to-text converter,
	/// an Input Method Editor (IME), or any other form of input.
	/// </para>
	/// <para>
	/// <c>UnloadKeyboardLayout</c> cannot unload the system default input locale identifier if it is the only keyboard layout loaded.
	/// You must first load another input locale identifier before unloading the default input locale identifier.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-unloadkeyboardlayout BOOL UnloadKeyboardLayout( HKL hkl );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UnloadKeyboardLayout(HKL hkl);

	/// <summary>
	/// <para>Frees a hot key previously registered by the calling thread.</para>
	/// </summary>
	/// <param name="hWnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the window associated with the hot key to be freed. This parameter should be <c>NULL</c> if the hot key is not
	/// associated with a window.
	/// </para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>int</c></para>
	/// <para>The identifier of the hot key to be freed.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-unregisterhotkey BOOL UnregisterHotKey( HWND hWnd, int id );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "unregisterhotkey")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UnregisterHotKey(HWND hWnd, int id);

	/// <summary>
	/// <para>
	/// [This function has been superseded by the VkKeyScanEx function. You can still use <c>VkKeyScan</c>, however, if you do not need
	/// to specify a keyboard layout.]
	/// </para>
	/// <para>Translates a character to the corresponding virtual-key code and shift state for the current keyboard.</para>
	/// </summary>
	/// <param name="ch">
	/// <para>Type: <c>TCHAR</c></para>
	/// <para>The character to be translated into a virtual-key code.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>SHORT</c></para>
	/// <para>
	/// If the function succeeds, the low-order byte of the return value contains the virtual-key code and the high-order byte contains
	/// the shift state, which can be a combination of the following flag bits.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>Either SHIFT key is pressed.</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Either CTRL key is pressed.</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>Either ALT key is pressed.</term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>The Hankaku key is pressed</term>
	/// </item>
	/// <item>
	/// <term>16</term>
	/// <term>Reserved (defined by the keyboard layout driver).</term>
	/// </item>
	/// <item>
	/// <term>32</term>
	/// <term>Reserved (defined by the keyboard layout driver).</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function finds no key that translates to the passed character code, both the low-order and high-order bytes contain –1.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For keyboard layouts that use the right-hand ALT key as a shift key (for example, the French keyboard layout), the shift state
	/// is represented by the value 6, because the right-hand ALT key is converted internally into CTRL+ALT.
	/// </para>
	/// <para>
	/// Translations for the numeric keypad ( <c>VK_NUMPAD0</c> through <c>VK_DIVIDE</c>) are ignored. This function is intended to
	/// translate characters into keystrokes from the main keyboard section only. For example, the character "7" is translated into
	/// VK_7, not VK_NUMPAD7.
	/// </para>
	/// <para><c>VkKeyScan</c> is used by applications that send characters by using the WM_KEYUP and WM_KEYDOWN messages.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-vkkeyscana SHORT VkKeyScanA( CHAR ch );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern short VkKeyScanA(byte ch);

	/// <summary>
	/// Translates a character to the corresponding virtual-key code and shift state. The function translates the character using the
	/// input language and physical keyboard layout identified by the input locale identifier.
	/// </summary>
	/// <param name="ch">
	/// <para>Type: <c>TCHAR</c></para>
	/// <para>The character to be translated into a virtual-key code.</para>
	/// </param>
	/// <param name="dwhkl">
	/// <para>Type: <c>HKL</c></para>
	/// <para>
	/// Input locale identifier used to translate the character. This parameter can be any input locale identifier previously returned
	/// by the LoadKeyboardLayout function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>SHORT</c></para>
	/// <para>
	/// If the function succeeds, the low-order byte of the return value contains the virtual-key code and the high-order byte contains
	/// the shift state, which can be a combination of the following flag bits.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>Either SHIFT key is pressed.</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Either CTRL key is pressed.</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>Either ALT key is pressed.</term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>The Hankaku key is pressed</term>
	/// </item>
	/// <item>
	/// <term>16</term>
	/// <term>Reserved (defined by the keyboard layout driver).</term>
	/// </item>
	/// <item>
	/// <term>32</term>
	/// <term>Reserved (defined by the keyboard layout driver).</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function finds no key that translates to the passed character code, both the low-order and high-order bytes contain –1.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The input locale identifier is a broader concept than a keyboard layout, since it can also encompass a speech-to-text converter,
	/// an Input Method Editor (IME), or any other form of input.
	/// </para>
	/// <para>
	/// For keyboard layouts that use the right-hand ALT key as a shift key (for example, the French keyboard layout), the shift state
	/// is represented by the value 6, because the right-hand ALT key is converted internally into CTRL+ALT.
	/// </para>
	/// <para>
	/// Translations for the numeric keypad (VK_NUMPAD0 through VK_DIVIDE) are ignored. This function is intended to translate
	/// characters into keystrokes from the main keyboard section only. For example, the character "7" is translated into VK_7, not VK_NUMPAD7.
	/// </para>
	/// <para><c>VkKeyScanEx</c> is used by applications that send characters by using the WM_KEYUP and WM_KEYDOWN messages.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-vkkeyscanexa SHORT VkKeyScanExA( CHAR ch, HKL dwhkl );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern short VkKeyScanExA(byte ch, HKL dwhkl);

	/// <summary>
	/// Translates a character to the corresponding virtual-key code and shift state. The function translates the character using the
	/// input language and physical keyboard layout identified by the input locale identifier.
	/// </summary>
	/// <param name="ch">
	/// <para>Type: <c>TCHAR</c></para>
	/// <para>The character to be translated into a virtual-key code.</para>
	/// </param>
	/// <param name="dwhkl">
	/// <para>Type: <c>HKL</c></para>
	/// <para>
	/// Input locale identifier used to translate the character. This parameter can be any input locale identifier previously returned
	/// by the LoadKeyboardLayout function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>SHORT</c></para>
	/// <para>
	/// If the function succeeds, the low-order byte of the return value contains the virtual-key code and the high-order byte contains
	/// the shift state, which can be a combination of the following flag bits.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>Either SHIFT key is pressed.</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Either CTRL key is pressed.</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>Either ALT key is pressed.</term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>The Hankaku key is pressed</term>
	/// </item>
	/// <item>
	/// <term>16</term>
	/// <term>Reserved (defined by the keyboard layout driver).</term>
	/// </item>
	/// <item>
	/// <term>32</term>
	/// <term>Reserved (defined by the keyboard layout driver).</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function finds no key that translates to the passed character code, both the low-order and high-order bytes contain –1.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The input locale identifier is a broader concept than a keyboard layout, since it can also encompass a speech-to-text converter,
	/// an Input Method Editor (IME), or any other form of input.
	/// </para>
	/// <para>
	/// For keyboard layouts that use the right-hand ALT key as a shift key (for example, the French keyboard layout), the shift state
	/// is represented by the value 6, because the right-hand ALT key is converted internally into CTRL+ALT.
	/// </para>
	/// <para>
	/// Translations for the numeric keypad (VK_NUMPAD0 through VK_DIVIDE) are ignored. This function is intended to translate
	/// characters into keystrokes from the main keyboard section only. For example, the character "7" is translated into VK_7, not VK_NUMPAD7.
	/// </para>
	/// <para><c>VkKeyScanEx</c> is used by applications that send characters by using the WM_KEYUP and WM_KEYDOWN messages.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-vkkeyscanexw SHORT VkKeyScanExW( WCHAR ch, HKL dwhkl );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern short VkKeyScanExW(char ch, HKL dwhkl);

	/// <summary>
	/// <para>
	/// [This function has been superseded by the VkKeyScanEx function. You can still use <c>VkKeyScan</c>, however, if you do not need
	/// to specify a keyboard layout.]
	/// </para>
	/// <para>Translates a character to the corresponding virtual-key code and shift state for the current keyboard.</para>
	/// </summary>
	/// <param name="ch">
	/// <para>Type: <c>TCHAR</c></para>
	/// <para>The character to be translated into a virtual-key code.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>SHORT</c></para>
	/// <para>
	/// If the function succeeds, the low-order byte of the return value contains the virtual-key code and the high-order byte contains
	/// the shift state, which can be a combination of the following flag bits.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>Either SHIFT key is pressed.</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Either CTRL key is pressed.</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>Either ALT key is pressed.</term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>The Hankaku key is pressed</term>
	/// </item>
	/// <item>
	/// <term>16</term>
	/// <term>Reserved (defined by the keyboard layout driver).</term>
	/// </item>
	/// <item>
	/// <term>32</term>
	/// <term>Reserved (defined by the keyboard layout driver).</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function finds no key that translates to the passed character code, both the low-order and high-order bytes contain –1.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For keyboard layouts that use the right-hand ALT key as a shift key (for example, the French keyboard layout), the shift state
	/// is represented by the value 6, because the right-hand ALT key is converted internally into CTRL+ALT.
	/// </para>
	/// <para>
	/// Translations for the numeric keypad ( <c>VK_NUMPAD0</c> through <c>VK_DIVIDE</c>) are ignored. This function is intended to
	/// translate characters into keystrokes from the main keyboard section only. For example, the character "7" is translated into
	/// VK_7, not VK_NUMPAD7.
	/// </para>
	/// <para><c>VkKeyScan</c> is used by applications that send characters by using the WM_KEYUP and WM_KEYDOWN messages.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-vkkeyscanw SHORT VkKeyScanW( WCHAR ch );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern short VkKeyScanW(char ch);

	/// <summary>Provides a handle to a .</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HKL : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HKL"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HKL(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HKL"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HKL NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HKL"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HKL h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HKL"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HKL(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HKL h1, HKL h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HKL h1, HKL h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HKL h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Contains information about a simulated keyboard event.</summary>
	/// <remarks>
	/// <para>
	/// <c>INPUT_KEYBOARD</c> supports nonkeyboard-input methods—such as handwriting recognition or voice recognition—as if it were text
	/// input by using the <c>KEYEVENTF_UNICODE</c> flag. If <c>KEYEVENTF_UNICODE</c> is specified, SendInput sends a WM_KEYDOWN or
	/// WM_KEYUP message to the foreground thread's message queue with wParam equal to <c>VK_PACKET</c>. Once GetMessage or PeekMessage
	/// obtains this message, passing the message to TranslateMessage posts a WM_CHAR message with the Unicode character originally
	/// specified by <c>wScan</c>. This Unicode character will automatically be converted to the appropriate ANSI value if it is posted
	/// to an ANSI window.
	/// </para>
	/// <para>
	/// Set the <c>KEYEVENTF_SCANCODE</c> flag to define keyboard input in terms of the scan code. This is useful to simulate a physical
	/// keystroke regardless of which keyboard is currently being used. The virtual key value of a key may alter depending on the
	/// current keyboard layout or what other keys were pressed, but the scan code will always be the same.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagkeybdinput typedef struct tagKEYBDINPUT { WORD wVk;
	// WORD wScan; DWORD dwFlags; DWORD time; ULONG_PTR dwExtraInfo; } KEYBDINPUT, *PKEYBDINPUT, *LPKEYBDINPUT;
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[StructLayout(LayoutKind.Sequential)]
	public struct KEYBDINPUT
	{
		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// A virtual-key code. The code must be a value in the range 1 to 254. If the <c>dwFlags</c> member specifies
		/// <c>KEYEVENTF_UNICODE</c>, <c>wVk</c> must be 0.
		/// </para>
		/// </summary>
		public ushort wVk;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// A hardware scan code for the key. If <c>dwFlags</c> specifies <c>KEYEVENTF_UNICODE</c>, <c>wScan</c> specifies a Unicode
		/// character which is to be sent to the foreground application.
		/// </para>
		/// </summary>
		public ushort wScan;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Specifies various aspects of a keystroke. This member can be certain combinations of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>KEYEVENTF_EXTENDEDKEY 0x0001</term>
		/// <term>If specified, the scan code was preceded by a prefix byte that has the value 0xE0 (224).</term>
		/// </item>
		/// <item>
		/// <term>KEYEVENTF_KEYUP 0x0002</term>
		/// <term>If specified, the key is being released. If not specified, the key is being pressed.</term>
		/// </item>
		/// <item>
		/// <term>KEYEVENTF_SCANCODE 0x0008</term>
		/// <term>If specified, wScan identifies the key and wVk is ignored.</term>
		/// </item>
		/// <item>
		/// <term>KEYEVENTF_UNICODE 0x0004</term>
		/// <term>
		/// If specified, the system synthesizes a VK_PACKET keystroke. The wVk parameter must be zero. This flag can only be combined
		/// with the KEYEVENTF_KEYUP flag. For more information, see the Remarks section.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public KEYEVENTF dwFlags;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The time stamp for the event, in milliseconds. If this parameter is zero, the system will provide its own time stamp.</para>
		/// </summary>
		public uint time;

		/// <summary>
		/// <para>Type: <c>ULONG_PTR</c></para>
		/// <para>An additional value associated with the keystroke. Use the GetMessageExtraInfo function to obtain this information.</para>
		/// </summary>
		public IntPtr dwExtraInfo;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HKL"/> that is disposed using <see cref="UnloadKeyboardLayout"/>.</summary>
	public class SafeHKL : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHKL"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHKL(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHKL"/> class.</summary>
		private SafeHKL() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHKL"/> to <see cref="HKL"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HKL(SafeHKL h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => UnloadKeyboardLayout(this);
	}
}