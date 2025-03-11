using System.Collections.Generic;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

/// <summary>Items from the Imm32.dll</summary>
public static partial class Imm32
{
	private const string Lib_Imm32 = "Imm32.dll";

	/// <summary>
	/// An application-defined callback function that processes input contexts provided by the ImmEnumInputContext function. The
	/// IMCENUMPROC type defines a pointer to this callback function. <c>EnumInputContext</c> is a placeholder for the
	/// application-defined function name.
	/// </summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="lpData">Application-supplied data.</param>
	/// <returns>Returns a nonzero value to continue enumeration, or 0 to stop enumeration.</returns>
	/// <remarks>An application must register this function by passing its address to the ImmEnumInputContext function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nc-imm-imcenumproc IMCENUMPROC Imcenumproc; BOOL Imcenumproc( HIMC hIMC,
	// LPARAM unnamedParam2 ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("imm.h", MSDNShortId = "NC:imm.IMCENUMPROC")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool IMCENUMPROC(HIMC hIMC, IntPtr lpData);

	/// <summary>
	/// An application-defined callback function used with the ImmEnumRegisterWord function. It is used to process data of register
	/// strings. The REGISTERWORDENUMPROC type defines a pointer to this callback function. <c>EnumRegisterWordProc</c> is a placeholder
	/// for the application-defined function name.
	/// </summary>
	/// <param name="lpszReading">Pointer to a null-terminated string specifying the matched reading string.</param>
	/// <param name="dwStyle">The style of the register string.</param>
	/// <param name="lpszString">Pointer to a null-terminated string specifying the matched register string.</param>
	/// <param name="lpData">Application-supplied data.</param>
	/// <returns>Returns a nonzero value to continue enumeration, or 0 to stop enumeration.</returns>
	/// <remarks>
	/// <para>An application must register this function by passing its address to the ImmEnumRegisterWord function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nc-imm-registerwordenumproca REGISTERWORDENUMPROCA Registerwordenumproca;
	// int Registerwordenumproca( [in] LPCSTR lpszReading, DWORD unnamedParam2, [in] LPCSTR lpszString, LPVOID unnamedParam4 ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
	[PInvokeData("imm.h", MSDNShortId = "NC:imm.REGISTERWORDENUMPROCA")]
	public delegate int REGISTERWORDENUMPROC([MarshalAs(UnmanagedType.LPTStr)] string lpszReading, IME_REGWORD_STYLE dwStyle,
		[MarshalAs(UnmanagedType.LPTStr)] string lpszString, IntPtr lpData = default);

	/// <summary/>
	[PInvokeData("imm.h")]
	public enum ATTR : uint
	{
		/// <summary/>
		ATTR_CONVERTED = 0x02,

		/// <summary/>
		ATTR_FIXEDCONVERTED = 0x05,

		/// <summary/>
		ATTR_INPUT = 0x00,

		/// <summary/>
		ATTR_INPUT_ERROR = 0x04,

		/// <summary/>
		ATTR_TARGET_CONVERTED = 0x01,

		/// <summary/>
		ATTR_TARGET_NOTCONVERTED = 0x03,
	}

	/// <summary>Position style.</summary>
	[PInvokeData("imm.h")]
	[Flags]
	public enum CFS
	{
		/// <summary>
		/// Move the composition window to the default position. The IME window can display the composition window outside the client
		/// area, such as in a floating window.
		/// </summary>
		CFS_DEFAULT = 0x0000,

		/// <summary>
		/// Display the upper left corner of the candidate list window at the position specified by <c>ptCurrentPos</c>. The coordinates
		/// are relative to the upper left corner of the window containing the list window, and are subject to adjustment by the system.
		/// </summary>
		CFS_CANDIDATEPOS = 0x0040,

		/// <summary>
		/// Exclude the candidate window from the area specified by <c>rcArea</c>. The <c>ptCurrentPos</c> member specifies the
		/// coordinates of the current point of interest, typically the caret position.
		/// </summary>
		CFS_EXCLUDE = 0x0080,

		/// <summary>
		/// Display the upper left corner of the composition window at exactly the position specified by <c>ptCurrentPos</c>. The
		/// coordinates are relative to the upper left corner of the window containing the composition window and are not subject to
		/// adjustment by the IME.
		/// </summary>
		CFS_FORCE_POSITION = 0x0020,

		/// <summary>
		/// Display the upper left corner of the composition window at the position specified by <c>ptCurrentPos</c>. The coordinates are
		/// relative to the upper left corner of the window containing the composition window and are subject to adjustment by the IME.
		/// </summary>
		CFS_POINT = 0x0002,

		/// <summary>
		/// Display the composition window at the position specified by <c>rcArea</c>. The coordinates are relative to the upper left of
		/// the window containing the composition window.
		/// </summary>
		CFS_RECT = 0x0001,
	}

	/// <summary>Index of a candidate list.</summary>
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmNotifyIME")]
	public enum CPS
	{
		/// <summary>Clear the composition string and set the status to no composition string.</summary>
		CPS_CANCEL = 0x0004,

		/// <summary>Set the composition string as the result string.</summary>
		CPS_COMPLETE = 0x0001,

		/// <summary>Convert the composition string.</summary>
		CPS_CONVERT = 0x0002,

		/// <summary>Cancel the current composition string and set the composition string to be the unconverted string.</summary>
		CPS_REVERT = 0x0003,
	}

	/// <summary>Action flag.</summary>
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetConversionListA")]
	public enum GCL
	{
		/// <summary>Source string is the reading string. The function copies the result string to the destination buffer.</summary>
		GCL_CONVERSION = 0x0001,

		/// <summary>Source string is the result string. The function copies the reading string to the destination buffer.</summary>
		GCL_REVERSECONVERSION = 0x0002,

		/// <summary>
		/// Source string is the result string. The function returns the size, in bytes, of the reading string created if
		/// GCL_REVERSECONVERSION is specified.
		/// </summary>
		GCL_REVERSE_LENGTH = 0x0003,
	}

	/// <summary>These values are used with <see cref="ImmGetCompositionString(HIMC, GCS)"/> and WM_IME_COMPOSITION.</summary>
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetCompositionStringA")]
	[Flags]
	public enum GCS : uint
	{
		/// <summary>Retrieve or update the attribute of the composition string.</summary>
		GCS_COMPATTR = 0x0010,

		/// <summary>Retrieve or update clause information of the composition string.</summary>
		GCS_COMPCLAUSE = 0x0020,

		/// <summary>Retrieve or update the attributes of the reading string of the current composition.</summary>
		GCS_COMPREADATTR = 0x0002,

		/// <summary>Retrieve or update the clause information of the reading string of the composition string.</summary>
		GCS_COMPREADCLAUSE = 0x0004,

		/// <summary>Retrieve or update the reading string of the current composition.</summary>
		GCS_COMPREADSTR = 0x0001,

		/// <summary>Retrieve or update the current composition string.</summary>
		GCS_COMPSTR = 0x0008,

		/// <summary>Retrieve or update the cursor position in composition string.</summary>
		GCS_CURSORPOS = 0x0080,

		/// <summary>Retrieve or update the starting position of any changes in composition string.</summary>
		GCS_DELTASTART = 0x0100,

		/// <summary>Retrieve or update clause information of the result string.</summary>
		GCS_RESULTCLAUSE = 0x1000,

		/// <summary>Retrieve or update clause information of the reading string.</summary>
		GCS_RESULTREADCLAUSE = 0x0400,

		/// <summary>Retrieve or update the reading string.</summary>
		GCS_RESULTREADSTR = 0x0200,

		/// <summary>Retrieve or update the string of the composition result.</summary>
		GCS_RESULTSTR = 0x0800,
	}

	/// <summary>Type of guideline information to retrieve.</summary>
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetGuideLineA")]
	public enum GGL : uint
	{
		/// <summary>Return the error index.</summary>
		GGL_INDEX = 0x00000002,

		/// <summary>Return the error level.</summary>
		GGL_LEVEL = 0x00000001,

		/// <summary>Return information about reverse conversion.</summary>
		GGL_PRIVATE = 0x00000004,

		/// <summary>Return the error message string.</summary>
		GGL_STRING = 0x00000003,
	}

	/// <summary>An error index returned by <see cref="ImmGetGuideLine"/>.</summary>
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetGuideLineA")]
	public enum GL_ID : uint
	{
		/// <summary>Unknown error. Refer to the error message string.</summary>
		GL_ID_UNKNOWN = 0x00000000,

		/// <summary>The dictionary or the statistics data cannot be saved.</summary>
		GL_ID_CANNOTSAVE = 0x00000011,

		/// <summary>The IME is accepting candidate string selection from the end user.</summary>
		GL_ID_CHOOSECANDIDATE = 0x00000028,

		/// <summary>The IME is accepting character code input from the end user.</summary>
		GL_ID_INPUTCODE = 0x00000026,

		/// <summary>The IME is accepting radical character input from the end user.</summary>
		GL_ID_INPUTRADICAL = 0x00000025,

		/// <summary>The IME is accepting reading character input from the end user.</summary>
		GL_ID_INPUTREADING = 0x00000024,

		/// <summary/>
		GL_ID_INPUTSYMBOL = 0x00000027,

		/// <summary>The IME cannot convert any more.</summary>
		GL_ID_NOCONVERT = 0x00000020,

		/// <summary>The IME cannot find the dictionary, or the dictionary has an unexpected format.</summary>
		GL_ID_NODICTIONARY = 0x00000010,

		/// <summary>The IME cannot find the module that is needed.</summary>
		GL_ID_NOMODULE = 0x00000001,

		/// <summary>A reading conflict occurred. For example, some vowels cannot be put together to form one character.</summary>
		GL_ID_READINGCONFLICT = 0x00000023,

		/// <summary>
		/// Information about reverse conversion is available by calling ImmGetGuideLine, specifying GGL_PRIVATE. The information
		/// retrieved is in CANDIDATELIST format.
		/// </summary>
		GL_ID_REVERSECONVERSION = 0x00000029,

		/// <summary>There are too many strokes for one character or one clause.</summary>
		GL_ID_TOOMANYSTROKE = 0x00000022,

		/// <summary>Typing error. The IME cannot handle this typing.</summary>
		GL_ID_TYPINGERROR = 0x00000021,

		/// <summary/>
		GL_ID_PRIVATE_FIRST = 0x00008000,

		/// <summary/>
		GL_ID_PRIVATE_LAST = 0x0000FFFF,
	}

	/// <summary>An error level returned by <see cref="ImmGetGuideLine"/>.</summary>
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetGuideLineA")]
	public enum GL_LEVEL : uint
	{
		/// <summary>No error. Remove previous error message if still visible.</summary>
		GL_LEVEL_NOGUIDELINE = 0x00000000,

		/// <summary>Error. The IME might not be able to continue.</summary>
		GL_LEVEL_ERROR = 0x00000002,

		/// <summary>Fatal error. The IME cannot continue, and data might be lost.</summary>
		GL_LEVEL_FATAL = 0x00000001,

		/// <summary>No error. Information is available for the user.</summary>
		GL_LEVEL_INFORMATION = 0x00000004,

		/// <summary>Unexpected input or other result. The user should be warned, but the IME can continue.</summary>
		GL_LEVEL_WARNING = 0x00000003,
	}

	/// <summary>Flags specifying the type of association between the window and the input method context.</summary>
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmAssociateContextEx")]
	[Flags]
	public enum IACE
	{
		/// <summary>Associate the input method context to the child windows of the specified window only.</summary>
		IACE_CHILDREN = 0x0001,

		/// <summary>Restore the default input method context of the window.</summary>
		IACE_DEFAULT = 0x0010,

		/// <summary>Do not associate the input method context with windows that are not associated with any input method context.</summary>
		IACE_IGNORENOCONTEXT = 0x0020,
	}

	/// <summary>Flag specifying menu information options.</summary>
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetImeMenuItemsA")]
	[Flags]
	public enum IGIMIF
	{
		/// <summary>Retrieve the menu items for the context menu, obtained by a right mouse click.</summary>
		IGIMIF_RIGHTMENU = 0x0001,
	}

	/// <summary>Type of menu to retrieve.</summary>
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetImeMenuItemsA")]
	[Flags]
	public enum IGIMII
	{
		/// <summary>Retrieve the menu items that control conversion mode.</summary>
		IGIMII_CMODE = 0x0001,

		/// <summary>Retrieve the menu items that are related to IME configuration.</summary>
		IGIMII_CONFIGURE = 0x0004,

		/// <summary>Retrieve the menu items that control IME Help.</summary>
		IGIMII_HELP = 0x0010,

		/// <summary>
		/// Retrieve the menu items that control menu items related to IME input tools providing an extended way to input characters.
		/// </summary>
		IGIMII_INPUTTOOLS = 0x0040,

		/// <summary>Retrieve the menu items that control other IME functions.</summary>
		IGIMII_OTHER = 0x0020,

		/// <summary>Retrieve the menu items that control sentence mode.</summary>
		IGIMII_SMODE = 0x0002,

		/// <summary>Retrieve the menu items that are related to IME tools.</summary>
		IGIMII_TOOLS = 0x0008,
	}

	/// <summary>Value that specifies the type of property information to retrieve.</summary>
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetProperty")]
	public enum IGP : uint
	{
		/// <summary>Conversion information.</summary>
		IGP_CONVERSION = 0x00000008,

		/// <summary>Retrieves the system version number for which the specified IME was created.</summary>
		IGP_GETIMEVERSION = unchecked((uint)-4),

		/// <summary>Property information.</summary>
		IGP_PROPERTY = 0x00000004,

		/// <summary>Selection inheritance capabilities.</summary>
		IGP_SELECT = 0x00000018,

		/// <summary>Sentence mode capabilities.</summary>
		IGP_SENTENCE = 0x0000000c,

		/// <summary>Composition string capabilities.</summary>
		IGP_SETCOMPSTR = 0x00000014,

		/// <summary>User interface capabilities.</summary>
		IGP_UI = 0x00000010,
	}

	/// <summary>Candidate style values.</summary>
	[PInvokeData("imm.h")]
	public enum IME_CAND : uint
	{
		/// <summary>Candidates are in a style other than listed here.</summary>
		IME_CAND_UNKNOWN = 0x0000,

		/// <summary>Candidates are in a code range.</summary>
		IME_CAND_CODE = 0x0002,

		/// <summary>Candidates are in same meaning.</summary>
		IME_CAND_MEANING = 0x0003,

		/// <summary>Candidates use same radical character.</summary>
		IME_CAND_RADICAL = 0x0004,

		/// <summary>Candidates are in same reading.</summary>
		IME_CAND_READ = 0x0001,

		/// <summary>Candidates are in same number of strokes.</summary>
		IME_CAND_STROKE = 0x0005,
	}

	/// <summary>
	/// IME Conversion Mode Values
	/// <para>These values are used with the ImmGetConversionStatus and ImmSetConversionStatus functions.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/intl/ime-conversion-mode-values
	[PInvokeData("imm.h")]
	public enum IME_CMODE : uint
	{
		/// <summary>Alphanumeric input mode. This is the default, defined as 0x0000.</summary>
		IME_CMODE_ALPHANUMERIC = 0x0000,

		/// <summary>Set to 1 if NATIVE mode; 0 if ALPHANUMERIC mode.</summary>
		IME_CMODE_NATIVE = 0x0001,

		/// <summary/>
		IME_CMODE_CHINESE = IME_CMODE_NATIVE,

		/// <summary/>
		IME_CMODE_HANGUL = IME_CMODE_NATIVE,

		/// <summary/>
		IME_CMODE_JAPANESE = IME_CMODE_NATIVE,

		/// <summary>Set to 1 if KATAKANA mode; 0 if HIRAGANA mode.</summary>
		IME_CMODE_KATAKANA = 0x0002,

		/// <summary/>
		IME_CMODE_LANGUAGE = 0x0003,

		/// <summary>Set to 1 if full shape mode; 0 if half shape mode.</summary>
		IME_CMODE_FULLSHAPE = 0x0008,

		/// <summary>Set to 1 if ROMAN input mode; 0 if not.</summary>
		IME_CMODE_ROMAN = 0x0010,

		/// <summary>Set to 1 if character code input mode; 0 if not.</summary>
		IME_CMODE_CHARCODE = 0x0020,

		/// <summary>Set to 1 if HANJA convert mode; 0 if not.</summary>
		IME_CMODE_HANJACONVERT = 0x0040,

		/// <summary/>
		IME_CMODE_NATIVESYMBOL = 0x0080,

		/// <summary>Set to 1 if EUDC conversion mode; 0 if not.</summary>
		IME_CMODE_EUDC = 0x0200,

		/// <summary>Windows Me/98, Windows 2000, Windows XP: Set to 1 if fixed conversion mode; 0 if not.</summary>
		IME_CMODE_FIXED = 0x0800,

		/// <summary>Set to 1 if NATIVE mode; 0 if ALPHANUMERIC mode.</summary>
		IME_CMODE_HANGEUL = IME_CMODE_NATIVE,

		/// <summary>Set to 1 to prevent processing of conversions by IME; 0 if not.</summary>
		IME_CMODE_NOCONVERSION = 0x0100,

		/// <summary/>
		IME_CMODE_RESERVED = 0xF0000000,

		/// <summary>Set to 1 if Soft Keyboard mode; 0 if not.</summary>
		IME_CMODE_SOFTKBD = 0x0080,

		/// <summary>Set to 1 if SYMBOL conversion mode; 0 if not.</summary>
		IME_CMODE_SYMBOL = 0x0400,
	}

	/// <summary>Value that specifies the type of dialog box to display.</summary>
	[PInvokeData("imm.h")]
	public enum IME_CONFIG : uint
	{
		/// <summary>Displays general-purpose configuration dialog box.</summary>
		IME_CONFIG_GENERAL = 1,

		/// <summary>Displays register word dialog box.</summary>
		IME_CONFIG_REGISTERWORD = 2,

		/// <summary>Displays dictionary selection dialog box.</summary>
		IME_CONFIG_SELECTDICTIONARY = 3,
	}

	/// <summary>Values that are used with the ImmEscape function.</summary>
	[PInvokeData("imm.h")]
	public enum IME_ESC : uint
	{
		/// <summary/>
		IME_ESC_AUTOMATA = 0x1009,

		/// <summary>
		/// Windows Me/98, Windows 2000, Windows XP: Return the name of the IME's help file. On return the lpData parameter is the full
		/// path of the IME's help file. The path should be less than 80 * sizeof(TCHAR).
		/// </summary>
		IME_ESC_GETHELPFILENAME = 0x100b,

		/// <summary>
		/// Retrieves the path of the EUDC dictionary file. On input, the lpData parameter must be the pointer to the buffer to receive
		/// the path. This buffer must be no less than 80 characters in length. On return, the buffer contains the null-terminated string
		/// specifying the full path. For use by the Chinese EUDC editor; do not use in other applications.
		/// </summary>
		IME_ESC_GET_EUDC_DICTIONARY = 0x1003,

		/// <summary>
		/// Converts from Hangeul to Hanja. On input, lpData must be the pointer to the buffer that contains the Hangeul character to
		/// convert; on output, it receives the converted Hanja as a null-terminated string. For use by the Korean editor; do not use in
		/// other applications.
		/// </summary>
		IME_ESC_HANJA_MODE = 0x1008,

		/// <summary>
		/// Retrieves the name of the IME. On input, the lpData parameter must be the pointer to the buffer to receive the name. This
		/// buffer must be no less than 64 characters in length. On return, the buffer contains the null-terminated string specifying the
		/// IME name. For use by the Chinese EUDC editor; do not use in other applications.
		/// </summary>
		IME_ESC_IME_NAME = 0x1006,

		/// <summary>
		/// Returns the maximum number of key stokes for an EUDC character. For use by the Chinese EUDC editor; do not use in other applications.
		/// </summary>
		IME_ESC_MAX_KEY = 0x1005,

		/// <summary>
		/// The system reserves the escapes in the range IME_ESC_PRIVATE_FIRST to IME_ESC_PRIVATE_LAST for private use by IMEs.
		/// </summary>
		IME_ESC_PRIVATE_FIRST = 0x0800,

		/// <summary/>
		IME_ESC_PRIVATE_HOTKEY = 0x100a,

		/// <summary>
		/// The system reserves the escapes in the range IME_ESC_PRIVATE_FIRST to IME_ESC_PRIVATE_LAST for private use by IMEs.
		/// </summary>
		IME_ESC_PRIVATE_LAST = 0x0FFF,

		/// <summary>Checks for implementation. Returns zero if the escape is not implemented.</summary>
		IME_ESC_QUERY_SUPPORT = 0x0003,

		/// <summary>The system reserves the escapes in the range IME_ESC_RESERVED_FIRST to IME_ESC_RESERVED_LAST for its own use.</summary>
		IME_ESC_RESERVED_FIRST = 0x0004,

		/// <summary>The system reserves the escapes in the range IME_ESC_RESERVED_FIRST to IME_ESC_RESERVED_LAST for its own use.</summary>
		IME_ESC_RESERVED_LAST = 0x07FF,

		/// <summary>
		/// Returns the character code that matches the given sequence code. On input, the lpData parameter is the pointer to a 32-bit
		/// variable that contains the sequence code. For use by the Chinese EUDC editor; do not use in other applications. Typically,
		/// the Chinese IME will encode its reading character codes into sequence 1 to n.
		/// </summary>
		IME_ESC_SEQUENCE_TO_INTERNAL = 0x1001,

		/// <summary>
		/// Sets the EUDC dictionary file. On input, the lpData parameter is the pointer to a null-terminated string specifying the full
		/// path. For use by the Chinese EUDC editor; do not use in other applications.
		/// </summary>
		IME_ESC_SET_EUDC_DICTIONARY = 0x1004,

		/// <summary/>
		IME_ESC_SYNC_HOTKEY = 0x1007,
	}

	/// <summary>The identifiers that are used with the ImmSimulateHotKey function.</summary>
	[PInvokeData("imm.h")]
	public enum IME_HOTKEY : uint
	{
		/// <summary>(Simplified Chinese) Toggles between IME and non-IME operation.</summary>
		IME_CHOTKEY_IME_NONIME_TOGGLE = 0x10,

		/// <summary>(Simplified Chinese) Toggles the shape conversion mode of IME.</summary>
		IME_CHOTKEY_SHAPE_TOGGLE = 0x11,

		/// <summary>
		/// (Simplified Chinese) Toggles the symbol conversion mode of IME. Symbol mode indicates that the user can input Chinese
		/// punctuation and symbols by mapping to the punctuation and symbols on the keyboard.
		/// </summary>
		IME_CHOTKEY_SYMBOL_TOGGLE = 0x12,

		/// <summary>Enables a IME to be switched.</summary>
		IME_HOTKEY_DSWITCH_FIRST = 0x100,

		/// <summary>Enables a IME to be switched.</summary>
		IME_HOTKEY_DSWITCH_LAST = 0x11F,

		/// <summary></summary>
		IME_HOTKEY_PRIVATE_FIRST = 0x200,

		/// <summary></summary>
		IME_HOTKEY_PRIVATE_LAST = 0x21F,

		/// <summary></summary>
		IME_ITHOTKEY_PREVIOUS_COMPOSITION = 0x201,

		/// <summary>Windows Me/98, Windows 2000, Windows XP: (Traditional Chinese) Trigger reconversion.</summary>
		IME_ITHOTKEY_RECONVERTSTRING = 0x203,

		/// <summary></summary>
		IME_ITHOTKEY_RESEND_RESULTSTR = 0x200,

		/// <summary></summary>
		IME_ITHOTKEY_UISTYLE_TOGGLE = 0x202,

		/// <summary>(Japanese) Alternately opens and closes the IME.</summary>
		IME_JHOTKEY_CLOSE_OPEN = 0x30,

		/// <summary>(Korean) Switches to English.</summary>
		IME_KHOTKEY_ENGLISH = 0x52,

		/// <summary>(Korean) Switches to Hanja conversion.</summary>
		IME_KHOTKEY_HANJACONVERT = 0x51,

		/// <summary>(Korean) Toggles the shape conversion mode of IME.</summary>
		IME_KHOTKEY_SHAPE_TOGGLE = 0x50,

		/// <summary>(Traditional Chinese) Toggles between IME and non-IME operation.</summary>
		IME_THOTKEY_IME_NONIME_TOGGLE = 0x70,

		/// <summary>(Traditional Chinese) Toggles the shape conversion mode of IME.</summary>
		IME_THOTKEY_SHAPE_TOGGLE = 0x71,

		/// <summary>(Traditional Chinese) Toggles the symbol conversion mode of IME.</summary>
		IME_THOTKEY_SYMBOL_TOGGLE = 0x72,
	}

	/// <summary>Results for IGP_PROPERTY.</summary>
	[PInvokeData("imm.h")]
	[Flags]
	public enum IME_PROP : uint
	{
		/// <summary>If set, conversion window is at the caret position. If clear, the window is near the caret position.</summary>
		IME_PROP_AT_CARET = 0x00010000,

		/// <summary>If set, strings in the candidate list are numbered starting at 1. If clear, strings start at 0.</summary>
		IME_PROP_CANDLIST_START_FROM_1 = 0x00040000,

		/// <summary>
		/// If set, the IME completes the composition string when the IME is deactivated. If clear, the IME cancels the composition
		/// string when the IME is deactivated, for example, from a keyboard layout change.
		/// </summary>
		IME_PROP_COMPLETE_ON_UNSELECT = 0x00100000,

		/// <summary>If set, the IME has a nonstandard user interface. The application should not draw in the IME window.</summary>
		IME_PROP_SPECIAL_UI = 0x00020000,

		/// <summary>
		/// If set, the IME is viewed as a Unicode IME. The operating system and the IME communicate through the Unicode IME interface.
		/// If clear, the IME uses the ANSI interface to communicate with the operating system.
		/// </summary>
		IME_PROP_UNICODE = 0x00080000,

		/// <summary>
		/// If set, the IME processes the injected Unicode that came from the SendInput function by using VK_PACKET. If clear, the IME
		/// might not process the injected Unicode, and might send the injected Unicode to the application directly.
		/// </summary>
		IME_PROP_ACCEPT_WIDE_VKEY = 0x00000020,

		/// <summary/>
		IME_PROP_END_UNLOAD = 0x00000001,

		/// <summary/>
		IME_PROP_KBD_CHAR_FIRST = 0x00000002,

		/// <summary/>
		IME_PROP_IGNORE_UPKEYS = 0x00000004,

		/// <summary/>
		IME_PROP_NEED_ALTKEY = 0x00000008,

		/// <summary/>
		IME_PROP_NO_KEYS_ON_CLOSE = 0x00000010,
	}

	/// <summary>Style of the register string.</summary>
	[PInvokeData("imm.h")]
	public enum IME_REGWORD_STYLE : uint
	{
		/// <summary>Indicate the string is in the EUDC range.</summary>
		IME_REGWORD_STYLE_EUDC = 0x00000001,

		/// <summary>Indicate a private style maintained by the specified IME.</summary>
		IME_REGWORD_STYLE_USER_FIRST = 0x80000000,

		/// <summary>Indicate a private style maintained by the specified IME.</summary>
		IME_REGWORD_STYLE_USER_LAST = 0xFFFFFFFF,
	}

	/// <summary>
	/// IME Sentence Mode Values
	/// <para>These values are used with the ImmGetConversionStatus and ImmSetConversionStatus functions.</para>
	/// </summary>
	[PInvokeData("imm.h")]
	[Flags]
	public enum IME_SMODE : uint
	{
		/// <summary>No information for sentence.</summary>
		IME_SMODE_NONE = 0x0000,

		/// <summary>The IME carries out conversion processing in automatic mode.</summary>
		IME_SMODE_AUTOMATIC = 0x0004,

		/// <summary>The IME uses conversation mode. This is useful for chat applications.</summary>
		IME_SMODE_CONVERSATION = 0x0010,

		/// <summary>The IME uses phrase information to predict the next character.</summary>
		IME_SMODE_PHRASEPREDICT = 0x0008,

		/// <summary>The IME uses plural clause information to carry out conversion processing.</summary>
		IME_SMODE_PLAURALCLAUSE = 0x0001,

		/// <summary/>
		IME_SMODE_RESERVED = 0x0000F000,

		/// <summary>The IME carries out conversion processing in single-character mode.</summary>
		IME_SMODE_SINGLECONVERT = 0x0002,
	}

	/// <summary>Results for IGP_GETIMEVERSION.</summary>
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetProperty")]
	public enum IMEVER : uint
	{
		/// <summary>The IME was created for Windows 3.1.</summary>
		IMEVER_0310 = 0x0003000A,

		/// <summary>The IME was created for Windows 95 or later</summary>
		IMEVER_0400 = 0x00040000,
	}

	/// <summary>Menu item state.</summary>
	[PInvokeData("imm.h")]
	[Flags]
	public enum IMFS : uint
	{
		/// <summary>The menu item is checked. For more information, see the description of the <c>hbmpChecked</c> member.</summary>
		IMFS_CHECKED = MenuItemState.MFS_CHECKED,

		/// <summary>The menu item is the default. A menu can contain only one default menu item, which is displayed in bold.</summary>
		IMFS_DEFAULT = MenuItemState.MFS_DEFAULT,

		/// <summary>The menu item is disabled and appears dimmed so it cannot be selected. This is equivalent to IMFS_GRAYED.</summary>
		IMFS_DISABLED = MenuItemState.MFS_DISABLED,

		/// <summary>The menu item is enabled. This is the default state.</summary>
		IMFS_ENABLED = MenuItemState.MFS_ENABLED,

		/// <summary>The menu item is disabled and appears dimmed so it cannot be selected. This is equivalent to IMFS_DISABLED.</summary>
		IMFS_GRAYED = MenuItemState.MFS_GRAYED,

		/// <summary>The menu item is highlighted.</summary>
		IMFS_HILITE = MenuItemState.MFS_HILITE,

		/// <summary>
		/// The menu item is unchecked. For more information about unchecked menu items, see the description of the <c>hbmpUnchecked</c> member.
		/// </summary>
		IMFS_UNCHECKED = MenuItemState.MFS_UNCHECKED,

		/// <summary>The menu item is not highlighted. This is the default state.</summary>
		IMFS_UNHILITE = MenuItemState.MFS_UNHILITE,
	}

	/// <summary>Menu item type.</summary>
	[PInvokeData("imm.h")]
	[Flags]
	public enum IMFT
	{
		/// <summary>
		/// Display checked menu items using a radio-button mark instead of a check mark if the <c>hbmpChecked</c> member is <c>NULL</c>.
		/// </summary>
		IMFT_RADIOCHECK = 0x00001,

		/// <summary>
		/// Menu item is a separator. A menu item separator appears as a horizontal dividing line. The <c>hbmpItem</c> and
		/// <c>szString</c> members are ignored in this case.
		/// </summary>
		IMFT_SEPARATOR = 0x00002,

		/// <summary>Menu item is a submenu.</summary>
		IMFT_SUBMENU = 0x00004,
	}

	/// <summary>Display options for WM_IME_SETCONTEXT.</summary>
	[PInvokeData("imm.h")]
	[Flags]
	public enum ISC : uint
	{
		/// <summary/>
		ISC_SHOWUIALL = 0xC000000F,

		/// <summary/>
		ISC_SHOWUIALLCANDIDATEWINDOW = 0x0000000F,

		/// <summary>Show the candidate window of index 0 by user interface window.</summary>
		ISC_SHOWUICANDIDATEWINDOW = 0x00000001,

		/// <summary>Show the composition window by user interface window.</summary>
		ISC_SHOWUICOMPOSITIONWINDOW = 0x80000000,

		/// <summary/>
		ISC_SHOWUIGUIDELINE = 0x40000000,
	}

	/// <summary>Notification code.</summary>
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmNotifyIME")]
	public enum NI
	{
		/// <summary>
		/// An application changed the current selected candidate. The <c>dwIndex</c> parameter specifies an index of a candidate list to
		/// be selected and <c>dwValue</c> is not used.
		/// </summary>
		NI_CHANGECANDIDATELIST = 0x0013,

		/// <summary>
		/// An application directs the IME to close a candidate list. The <c>dwIndex</c> parameter specifies an index of the list to
		/// close, and <c>dwValue</c> is not used. The IME sends a IMN_CLOSECANDIDATE command to the application if it closes the list.
		/// </summary>
		NI_CLOSECANDIDATE = 0x0011,

		/// <summary>
		/// An application directs the IME to carry out an action on the composition string. The <c>dwIndex</c> parameter can be
		/// CPS_CANCEL, CPS_COMPLETE, CPS_CONVERT, or CPS_REVERT.
		/// </summary>
		NI_COMPOSITIONSTR = 0x0015,

		/// <summary/>
		NI_FINALIZECONVERSIONRESULT = 0x0014,

		/// <summary>
		/// An application directs the IME to allow the application to handle the specified menu. The <c>dwIndex</c> parameter specifies
		/// the ID of the menu and <c>dwValue</c> is an application-defined value for that menu item.
		/// </summary>
		NI_IMEMENUSELECTED = 0x0018,

		/// <summary>
		/// An application directs the IME to open a candidate list. The <c>dwIndex</c> parameter specifies the index of the list to
		/// open, and <c>dwValue</c> is not used. The IME sends a IMN_OPENCANDIDATE command to the application if it opens the list.
		/// </summary>
		NI_OPENCANDIDATE = 0x0010,

		/// <summary>
		/// An application has selected one of the candidates. The <c>dwIndex</c> parameter specifies an index of a candidate list to be
		/// selected. The <c>dwValue</c> parameter specifies an index of a candidate string in the selected candidate list.
		/// </summary>
		NI_SELECTCANDIDATESTR = 0x0012,

		/// <summary>
		/// The application changes the page size of a candidate list. The <c>dwIndex</c> parameter specifies the candidate list to be
		/// changed and must have a value in the range 0 to 3. The <c>dwValue</c> parameter specifies the new page size.
		/// </summary>
		NI_SETCANDIDATE_PAGESIZE = 0x0017,

		/// <summary>
		/// The application changes the page starting index of a candidate list. The <c>dwIndex</c> parameter specifies the candidate
		/// list to be changed and must have a value in the range 0 to 3. The <c>dwValue</c> parameter specifies the new page start index.
		/// </summary>
		NI_SETCANDIDATE_PAGESTART = 0x0016,
	}

	/// <summary>Value that specifies the type of information to set.</summary>
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmSetCompositionStringA")]
	public enum SCS : uint
	{
		/// <summary>
		/// Set attributes for the composition string, the reading string, or both. At least one of the <c>lpComp</c> and <c>lpRead</c>
		/// parameters must indicate a valid attribute array.
		/// </summary>
		SCS_CHANGEATTR = GCS.GCS_COMPREADATTR|GCS.GCS_COMPATTR,

		/// <summary>
		/// Set the clause information for the composition string, the reading string, or both. At least one of the <c>lpComp</c> and
		/// <c>lpRead</c> parameters must point to a valid clause information array.
		/// </summary>
		SCS_CHANGECLAUSE = GCS.GCS_COMPREADCLAUSE|GCS.GCS_COMPCLAUSE,

		/// <summary>
		/// <c>Windows Me/98, Windows 2000, Windows XP:</c> Ask IME to adjust the RECONVERTSTRING structure. Then the application can
		/// pass the adjusted structure into this function using SCS_SETRECONVERTSTRING. IME does not generate any WM_IME_COMPOSITION messages.
		/// </summary>
		SCS_QUERYRECONVERTSTRING = 0x00020000,

		/// <summary>
		/// <c>Windows Me/98, Windows 2000, Windows XP:</c> Ask IME to reconvert the string using a specified RECONVERTSTRING structure.
		/// </summary>
		SCS_SETRECONVERTSTRING = 0x00010000,

		/// <summary>
		/// Set the composition string, the reading string, or both. At least one of the <c>lpComp</c> and <c>lpRead</c> parameters must
		/// indicate a valid string. If either string is too long, the IME truncates it.
		/// </summary>
		SCS_SETSTR = GCS.GCS_COMPREADSTR|GCS.GCS_COMPSTR,
	}

	/// <summary>Results for IGP_SETCOMPSTR.</summary>
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetProperty")]
	[Flags]
	public enum SCS_CAP : uint
	{
		/// <summary>Can create the composition string by calling the ImmSetCompositionString function with the SCS_SETSTR value.</summary>
		SCS_CAP_COMPSTR = 0x00000001,

		/// <summary>
		/// Can create the reading string from corresponding composition string when using the ImmSetCompositionString function with
		/// SCS_SETSTR and without setting lpRead.
		/// </summary>
		SCS_CAP_MAKEREAD = 0x00000002,

		/// <summary>This IME can support reconversion. Use ImmSetCompositionString to do the reconversion.</summary>
		SCS_CAP_SETRECONVERTSTRING = 0x00000004,
	}

	/// <summary>Results for IGP_SELECT.</summary>
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetProperty")]
	[Flags]
	public enum SELECT_CAP : uint
	{
		/// <summary>Inherits conversion mode when a new IME is selected.</summary>
		SELECT_CAP_CONVERSION = 0x00000001,

		/// <summary>Inherits sentence mode when a new IME is selected.</summary>
		SELECT_CAP_SENTENCE = 0x00000002,
	}

	/// <summary>Results for IGP_UI.</summary>
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetProperty")]
	[Flags]
	public enum UI_CAP : uint
	{
		/// <summary>Supports text escapement values of 0 or 2700. For more information, see lfEscapement.</summary>
		UI_CAP_2700 = 0x00000001,

		/// <summary>Supports text escapement values of 0, 900, 1800, or 2700. For more information, see lfEscapement.</summary>
		UI_CAP_ROT90 = 0x00000002,

		/// <summary>Supports any text escapement value. For more information, see lfEscapement.</summary>
		UI_CAP_ROTANY = 0x00000004,
	}

	/// <summary>
	/// Associates the specified input context with the specified window. By default, the operating system associates the default input
	/// context with each window as it is created.
	/// </summary>
	/// <param name="hWnd">Handle to the window to associate with the input context.</param>
	/// <param name="hIMC">Handle to the input method context.</param>
	/// <returns>Returns the handle to the input context previously associated with the window.</returns>
	/// <remarks>
	/// When associating an input context with a window, an application must remove the association before destroying the input context.
	/// One way to do this is to save the handle and reassociate it to the default input context with the window.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immassociatecontext HIMC ImmAssociateContext( HWND hWnd, HIMC hIMC );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmAssociateContext")]
	public static extern HIMC ImmAssociateContext([In] HWND hWnd, [In] HIMC hIMC);

	/// <summary>Changes the association between the input method context and the specified window or its children.</summary>
	/// <param name="hWnd">Handle to the window to associate with the input context.</param>
	/// <param name="hIMC">Handle to the input method context.</param>
	/// <param name="dwFlags">
	/// <para>
	/// Flags specifying the type of association between the window and the input method context. This parameter can have one of the
	/// following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>IACE_CHILDREN</c></term>
	/// <term>Associate the input method context to the child windows of the specified window only.</term>
	/// </item>
	/// <item>
	/// <term><c>IACE_DEFAULT</c></term>
	/// <term>Restore the default input method context of the window.</term>
	/// </item>
	/// <item>
	/// <term><c>IACE_IGNORENOCONTEXT</c></term>
	/// <term>Do not associate the input method context with windows that are not associated with any input method context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <para>
	/// If the application calls this function with IACE_CHILDREN, the operating system associates the specified input method context
	/// with child windows of the window indicated by <c>hWnd</c>. It associates the input method context only with child windows of the
	/// thread that creates <c>hWnd</c>. Any child window that is created after this function has been called will not be affected.
	/// Instead, the default input method context will be associated with it.
	/// </para>
	/// <para>
	/// If the application calls this function with IACE_DEFAULT, the operating system restores the default input method context for the
	/// window. In this case, the <c>hIMC</c> parameter is ignored.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immassociatecontextex BOOL ImmAssociateContextEx( [in] HWND hWnd,
	// [in] HIMC hIMC, [in] DWORD unnamedParam3 );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmAssociateContextEx")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmAssociateContextEx([In] HWND hWnd, [In] HIMC hIMC, IACE dwFlags);

	/// <summary>Displays the configuration dialog box for the IME of the specified input locale identifier.</summary>
	/// <param name="hKL">Handle to the keyboard layout.</param>
	/// <param name="hWnd">[in] Handle to the parent window for the dialog box.</param>
	/// <param name="dwMode">
	/// [in] Value that specifies the type of dialog box to display. The following table shows the values this parameter can take.
	/// </param>
	/// <param name="lpData">
	/// [in] Long pointer to supplemental data. If dwMode is IME_CONFIG_REGISTERWORD, this parameter must be the address of a
	/// REGISTERWORD structure.
	/// <para>If dwMode is not IME_CONFIG_REGISTERWORD, this parameter is ignored.</para>
	/// </param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immconfigureimea BOOL ImmConfigureIMEA( HKL hKL, HWND hWnd, DWORD
	// unnamedParam3, LPVOID unnamedParam4 );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmConfigureIMEA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmConfigureIME([In] HKL hKL, [In] HWND hWnd, IME_CONFIG dwMode, [In, Optional] IntPtr lpData);

	/// <summary>
	/// Creates a new input context, allocating memory for the context and initializing it. An application calls this function to prepare
	/// its own input context.
	/// </summary>
	/// <returns>Returns the handle to the new input context if successful, or <c>NULL</c> otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immcreatecontext HIMC ImmCreateContext();
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmCreateContext")]
	public static extern HIMC ImmCreateContext();

	/// <summary>Releases the input context and frees associated memory.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	/// <remarks>
	/// Any application that creates an input context by using the ImmCreateContext function must call this function to free the context
	/// before it terminates. However, before calling <c>ImmDestroyContext</c>, the application must remove the input context from any
	/// association with windows in the thread by using the ImmAssociateContext function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immdestroycontext BOOL ImmDestroyContext( HIMC hIMC );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmDestroyContext")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmDestroyContext([In] HIMC hIMC);

	/// <summary>Disables the IME for a thread or for all threads in a process.</summary>
	/// <param name="idThread">
	/// Identifier of the thread for which to disable the text service. The thread must be in the same process as the application. The
	/// application sets this parameter to 0 to disable the service for the current thread. The application sets the parameter to –1 to
	/// disable the service for all threads in the current process.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <para>
	/// The application must call this function before the first top-level window in the thread receives the WM_CREATE message. Thus, the
	/// application must call this function in one of the following places:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Any time before calling CreateWindow to create the first top-level window</term>
	/// </item>
	/// <item>
	/// <term>In the WM_NCCREATE handler for first top-level window</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immdisableime BOOL ImmDisableIME( DWORD unnamedParam1 );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmDisableIME")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmDisableIME(uint idThread);

	/// <summary>Indicates that this thread is a Windows Store app UI thread.</summary>
	/// <returns>Returns <c>TRUE</c> if successful; otherwise, <c>FALSE</c>.</returns>
	/// <remarks>
	/// <para>
	/// Windows Store app brokers such as explorer.exe should call this function in Windows Store app UI threads to ensure that only IMEs
	/// that are compatible with Windows Store apps are made available. Those Windows Store app threads that don't require IME input
	/// should call ImmDisableIME to disable IMM entirely for that thread.
	/// </para>
	/// <para>
	/// The app must call this function before the first top-level window in the thread receives the WM_CREATE message. Thus, the app
	/// must call this function in one of the following places:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Any time before CreateWindow is called to create the first top-level window.</term>
	/// </item>
	/// <item>
	/// <term>In the WM_NCCREATE handler for the first top-level window.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immdisablelegacyime BOOL ImmDisableLegacyIME();
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmDisableLegacyIME")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmDisableLegacyIME();

	/// <summary>
	/// [ImmDisableTextFrameService is no longer available for use as of Windows Vista. Instead, use ImmDisableIME. ]
	/// <para>Disables the text service for the specified thread.For details, see Text Services Framework(TSF).</para>
	/// </summary>
	/// <param name="idThread">
	/// Identifier of the thread for which to disable the text service. The thread must be in the same process as the application. The
	/// application sets this parameter to 0 to disable the service for the current thread. The application sets the parameter to –1 to
	/// disable the service for all threads in the current process.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <para>An application calls this function if it has a thread that is incompatible with TSF.</para>
	/// <para>
	/// Note that TSF functionality is provided to applications that are not specifically written to use TSF, Input Method Manager
	/// (IMM32), or Active Input Method Manager (AIMM 1.2). Although an application can be written to use TSF, IMM32, and AIMM 1.2, there
	/// can be specific controls within the application that do not use these technologies. TSF support is provided to these specific
	/// controls as well. This TSF feature is available beginning with Windows XP when all of these dynamic-link libraries (DLLs) are
	/// loaded: system modules User32.dll, Imm32.dll, and Win32k.sys, and TSF modules Msctf.dll and Msimtf.dll.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immdisabletextframeservice BOOL ImmDisableTextFrameService( [in]
	// DWORD idThread );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmDisableTextFrameService")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmDisableTextFrameService(uint idThread);

	/// <summary>Retrieves the input context for the specified thread.</summary>
	/// <param name="idThread">
	/// <para>Identifier for the thread. This parameter can have one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>0</c></term>
	/// <term>Current thread.</term>
	/// </item>
	/// <item>
	/// <term><c>1</c></term>
	/// <term>Current process.</term>
	/// </item>
	/// <item>
	/// <term><c>Thread ID</c></term>
	/// <term>Identifier of the thread for which to enumerate the context. This thread identifier can belong to another process.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpfn">Pointer to the enumeration callback function. For more information, see EnumInputContext.</param>
	/// <param name="lParam">Application-supplied data. The function passes this data to the callback function.</param>
	/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// This function calls the application callback function for each enumerated input context, and passes the specified <c>lParam</c> value.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immenuminputcontext BOOL ImmEnumInputContext( [in] DWORD idThread,
	// [in] IMCENUMPROC lpfn, [in] LPARAM lParam );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmEnumInputContext")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmEnumInputContext(uint idThread, IMCENUMPROC lpfn, IntPtr lParam = default);

	/// <summary>Retrieves the input context for the specified thread.</summary>
	/// <param name="idThread">
	/// <para>Identifier for the thread. This parameter can have one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>0</c></term>
	/// <term>Current thread.</term>
	/// </item>
	/// <item>
	/// <term><c>1</c></term>
	/// <term>Current process.</term>
	/// </item>
	/// <item>
	/// <term><c>Thread ID</c></term>
	/// <term>Identifier of the thread for which to enumerate the context. This thread identifier can belong to another process.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>A sequence of <see cref="HIMC"/> values with the input context handles for the specified <paramref name="idThread"/>.</returns>
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmEnumInputContext")]
	public static IEnumerable<HIMC> ImmEnumInputContext(uint idThread)
	{
		List<HIMC> output = new();
		Win32Error.ThrowLastErrorIfFalse(ImmEnumInputContext(idThread, (HIMC himc, IntPtr _) => { output.Add(himc); return true; }));
		return output;
	}

	/// <summary>Enumerates the register strings having the specified reading string, style, and register string.</summary>
	/// <param name="hKL">Handle to the keyboard layout.</param>
	/// <param name="lpfnEnumProc">[in] Long pointer to the callback function. For more information, see EnumRegisterWordProc.</param>
	/// <param name="lpszReading">
	/// Pointer to the reading string to enumerate. The application sets this parameter to <c>NULL</c> if the function is to enumerate
	/// all available reading strings that match the <c>dwStyle</c> and <c>lpszRegister</c> settings.
	/// </param>
	/// <param name="dwStyle">
	/// [in] Style to be enumerated. If zero, this function enumerates all available styles that match with the specified lpszReading and lpszRegister.
	/// </param>
	/// <param name="lpszRegister">
	/// Pointer to the register string to enumerate. The application sets this parameter to <c>NULL</c> if the function is to enumerate
	/// all register strings that match the <c>lpszReading</c> and <c>dwStyle</c> settings.
	/// </param>
	/// <param name="lpData">[in] Long pointer to application-supplied data. The function passes this parameter to the callback function.</param>
	/// <returns>
	/// Returns the last value returned by the callback function, with the meaning defined by the application. The function returns 0 if
	/// it cannot enumerate the register strings.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If <c>dwStyle</c> is set to 0 and both <c>lpszReading</c> and <c>lpszRegister</c> are set to <c>NULL</c>, this function
	/// enumerates all register strings in the IME dictionary.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immenumregisterworda UINT ImmEnumRegisterWordA( HKL hKL,
	// REGISTERWORDENUMPROCA unnamedParam2, [in, optional] LPCSTR lpszReading, DWORD unnamedParam4, [in, optional] LPCSTR lpszRegister,
	// LPVOID unnamedParam6 );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmEnumRegisterWordA")]
	public static extern uint ImmEnumRegisterWord([In] HKL hKL, REGISTERWORDENUMPROC lpfnEnumProc, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? lpszReading,
		IME_REGWORD_STYLE dwStyle, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? lpszRegister, IntPtr lpData = default);

	/// <summary>Retrieves a candidate list.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="deIndex">Zero-based index of the candidate list.</param>
	/// <param name="lpCandList">Pointer to a CANDIDATELIST structure in which the function retrieves the candidate list.</param>
	/// <param name="dwBufLen">
	/// Size, in bytes, of the buffer to receive the candidate list. The application can specify 0 for this parameter if the function is
	/// to return the required size of the output buffer only.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns the number of bytes copied to the candidate list buffer if successful. If the application has supplied 0 for the
	/// <c>dwBufLen</c> parameter, the function returns the size required for the candidate list buffer.
	/// </para>
	/// <para>The function returns 0 if it does not succeed.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetcandidatelista DWORD ImmGetCandidateListA( HIMC hIMC, [in]
	// DWORD deIndex, [out, optional] LPCANDIDATELIST lpCandList, [in] DWORD dwBufLen );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetCandidateListA")]
	public static extern uint ImmGetCandidateList([In] HIMC hIMC, uint deIndex, [Out, Optional] IntPtr lpCandList, uint dwBufLen);

	/// <summary>Retrieves a candidate list.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="deIndex">Zero-based index of the candidate list.</param>
	/// <returns>The resulting <see cref="CANDIDATELIST_MGD"/> and the list of extracted candidate names.</returns>
	public static CANDIDATELIST_MGD ImmGetCandidateList([In] HIMC hIMC, uint deIndex)
	{
		using SafeCoTaskMemHandle mem = new(Win32Error.ThrowLastErrorIf(ImmGetCandidateList(hIMC, deIndex, default, 0), i => i == 0));
		Win32Error.ThrowLastErrorIf(ImmGetCandidateList(hIMC, deIndex, mem, mem.Size), i => i == 0);
		return mem.ToStructure<CANDIDATELIST_MGD>();
	}

	/// <summary>Retrieves the size of the candidate lists.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="lpdwListCount">Pointer to the buffer in which this function retrieves the size of the candidate lists.</param>
	/// <returns>Returns the number of bytes required for all candidate lists if successful, or 0 otherwise.</returns>
	/// <remarks>
	/// <para>Applications typically call this function in response to an IMN_OPENCANDIDATE or IMN_CHANGECANDIDATE command.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetcandidatelistcounta DWORD ImmGetCandidateListCountA( HIMC
	// hIMC, [out] LPDWORD lpdwListCount );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetCandidateListCountA")]
	public static extern uint ImmGetCandidateListCount([In] HIMC hIMC, out uint lpdwListCount);

	/// <summary>Retrieves information about the candidates window.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="index">
	/// [in] Index of the CANDIDATEFORM structure to retrieve. Windows supports four structures per context, ranging from 0 to 3.
	/// </param>
	/// <param name="lpCandidate">
	/// Pointer to a CANDIDATEFORM structure in which this function retrieves information about the candidates window.
	/// </param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetcandidatewindow BOOL ImmGetCandidateWindow( HIMC hIMC, DWORD
	// unnamedParam2, [out] LPCANDIDATEFORM lpCandidate );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetCandidateWindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmGetCandidateWindow(HIMC hIMC, uint index, out CANDIDATEFORM lpCandidate);

	/// <summary>Retrieves information about the logical font currently used to display characters in the composition window.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="lplf">Pointer to a LOGFONT structure in which this function retrieves the font information.</param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetcompositionfonta BOOL ImmGetCompositionFontA( HIMC hIMC, [out]
	// LPLOGFONTA lplf );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetCompositionFontA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmGetCompositionFont(HIMC hIMC, out LOGFONT lplf);

	/// <summary>Retrieves information about the composition string.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="dwIndex">
	/// [in] Index of the information to retrieve. This parameter can be one of the values specified in IME Composition String Values.
	/// For each value except GCS_CURSORPOS and GCS_DELTASTART, the function copies the requested information to the specified buffer.
	/// The function returns the cursor and delta position values in the low 16-bits of the return value.
	/// </param>
	/// <param name="lpBuf">Pointer to a buffer in which the function retrieves the composition string information.</param>
	/// <param name="dwBufLen">
	/// Size, in bytes, of the output buffer, even if the output is a Unicode string. The application sets this parameter to 0 if the
	/// function is to return the size of the required output buffer.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns the number of bytes copied to the output buffer. If <c>dwBufLen</c> is set to 0, the function returns the buffer size, in
	/// bytes, required to receive all requested information, excluding the terminating null character. The return value is always the
	/// size, in bytes, even if the requested data is a Unicode string.
	/// </para>
	/// <para>This function returns one of the following negative error codes if it does not succeed:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>IMM_ERROR_NODATA. Composition data is not ready in the input context.</term>
	/// </item>
	/// <item>
	/// <term>IMM_ERROR_GENERAL. General error detected by IME.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application calls this function in response to the WM_IME_COMPOSITION or WM_IME_STARTCOMPOSITION message. The IMM removes the
	/// information when the application calls the ImmReleaseContext function.
	/// </para>
	/// <para>
	/// <c>Note</c> You must write code to handle both full-width Hiragana and half-width Katakana if your application is used with the
	/// Soft Input Panel (SIP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetcompositionstringa LONG ImmGetCompositionStringA( HIMC hIMC,
	// DWORD unnamedParam2, [out, optional] LPVOID lpBuf, [in] DWORD dwBufLen );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetCompositionStringA")]
	public static extern int ImmGetCompositionString(HIMC hIMC, GCS dwIndex, [Out, Optional] IntPtr lpBuf, uint dwBufLen);

	/// <summary>Retrieves information about the composition string.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="dwIndex">
	/// [in] Index of the information to retrieve. This parameter can be one of the values specified in IME Composition String Values.
	/// For each value except GCS_CURSORPOS and GCS_DELTASTART, the function copies the requested information to the specified buffer.
	/// The function returns the cursor and delta position values in the low 16-bits of the return value.
	/// </param>
	/// <returns>The composition string information.</returns>
	/// <remarks>
	/// <para>
	/// An application calls this function in response to the WM_IME_COMPOSITION or WM_IME_STARTCOMPOSITION message. The IMM removes the
	/// information when the application calls the ImmReleaseContext function.
	/// </para>
	/// <para>
	/// <c>Note</c> You must write code to handle both full-width Hiragana and half-width Katakana if your application is used with the
	/// Soft Input Panel (SIP).
	/// </para>
	/// </remarks>
	public static string ImmGetCompositionString(HIMC hIMC, GCS dwIndex)
	{
		using SafeCoTaskMemString str = new(Win32Error.ThrowLastErrorIf(ImmGetCompositionString(hIMC, dwIndex, default, 0), i => i < 0) + 2, CharSet.Auto);
		Win32Error.ThrowLastErrorIf(ImmGetCompositionString(hIMC, dwIndex, str, str.Size), i => i < 0);
		return str.ToString()!;
	}

	/// <summary>Retrieves information about the composition window.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="lpCompForm">
	/// Pointer to a COMPOSITIONFORM structure in which the function retrieves information about the composition window.
	/// </param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetcompositionwindow BOOL ImmGetCompositionWindow( HIMC hIMC,
	// [out] LPCOMPOSITIONFORM lpCompForm );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetCompositionWindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmGetCompositionWindow(HIMC hIMC, out COMPOSITIONFORM lpCompForm);

	/// <summary>Returns the input context associated with the specified window.</summary>
	/// <param name="hWnd">[in] Handle to the window to retrieve the input context for.</param>
	/// <returns>Returns the handle to the input context.</returns>
	/// <remarks>
	/// <para>
	/// An application should routinely use this function to retrieve the current input context before attempting to access information
	/// in the context.
	/// </para>
	/// <para>The application must call ImmReleaseContext when it is finished with the input context.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetcontext HIMC ImmGetContext( HWND hWnd );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetContext")]
	public static extern HIMC ImmGetContext(HWND hWnd);

	/// <summary>Retrieves the conversion result list of characters or words without generating any IME-related messages.</summary>
	/// <param name="hKL">Handle to the keyboard layout.</param>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="lpSrc">Pointer to a null-terminated character string specifying the source of the list.</param>
	/// <param name="lpDst">Pointer to a CANDIDATELIST structure in which the function retrieves the list.</param>
	/// <param name="dwBufLen">
	/// Size, in bytes, of the output buffer. The application sets this parameter to 0 if the function is to return the buffer size
	/// required for the complete conversion result list.
	/// </param>
	/// <param name="uFlag">
	/// <para>Action flag. This parameter can have one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>GCL_CONVERSION</c></term>
	/// <term>Source string is the reading string. The function copies the result string to the destination buffer.</term>
	/// </item>
	/// <item>
	/// <term><c>GCL_REVERSECONVERSION</c></term>
	/// <term>Source string is the result string. The function copies the reading string to the destination buffer.</term>
	/// </item>
	/// <item>
	/// <term><c>GCL_REVERSE_LENGTH</c></term>
	/// <term>
	/// Source string is the result string. The function returns the size, in bytes, of the reading string created if
	/// GCL_REVERSECONVERSION is specified.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// Returns the number of bytes copied to the output buffer. If the application sets the <c>dwBufLen</c> parameter to 0, the function
	/// returns the size, in bytes, of the required output buffer.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetconversionlista DWORD ImmGetConversionListA( HKL hKL, HIMC
	// hIMC, [in] LPCSTR lpSrc, [out] LPCANDIDATELIST lpDst, [in] DWORD dwBufLen, [in] UINT uFlag );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetConversionListA")]
	public static extern uint ImmGetConversionList(HKL hKL, HIMC hIMC, [MarshalAs(UnmanagedType.LPTStr)] string lpSrc, [Out, Optional] IntPtr lpDst, uint dwBufLen, GCL uFlag);

	/// <summary>Retrieves the conversion result list of characters or words without generating any IME-related messages.</summary>
	/// <param name="hKL">Handle to the keyboard layout.</param>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="lpSrc">Pointer to a null-terminated character string specifying the source of the list.</param>
	/// <param name="uFlag">
	/// <para>Action flag. This parameter can have one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>GCL_CONVERSION</c></term>
	/// <term>Source string is the reading string. The function copies the result string to the destination buffer.</term>
	/// </item>
	/// <item>
	/// <term><c>GCL_REVERSECONVERSION</c></term>
	/// <term>Source string is the result string. The function copies the reading string to the destination buffer.</term>
	/// </item>
	/// <item>
	/// <term><c>GCL_REVERSE_LENGTH</c></term>
	/// <term>
	/// Source string is the result string. The function returns the size, in bytes, of the reading string created if
	/// GCL_REVERSECONVERSION is specified.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>A CANDIDATELIST_MGD structure with the conversion result list of characters or words.</returns>
	public static CANDIDATELIST_MGD ImmGetConversionList(HKL hKL, HIMC hIMC, [MarshalAs(UnmanagedType.LPTStr)] string lpSrc, GCL uFlag)
	{
		using SafeCoTaskMemHandle mem = new(Win32Error.ThrowLastErrorIf(ImmGetConversionList(hKL, hIMC, lpSrc, default, 0, uFlag), i => i == 0));
		Win32Error.ThrowLastErrorIf(ImmGetConversionList(hKL, hIMC, lpSrc, mem, mem.Size, uFlag), i => i == 0);
		return mem.ToStructure<CANDIDATELIST_MGD>();
	}

	/// <summary>Retrieves the current conversion status.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="lpfdwConversion">
	/// Pointer to a variable in which the function retrieves a combination of conversion mode values. For more information, see IME
	/// Conversion Mode Values.
	/// </param>
	/// <param name="lpfdwSentence">
	/// Pointer to a variable in which the function retrieves a sentence mode value. For more information, see IME Sentence Mode Values.
	/// </param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	/// <remarks>Conversion and sentence mode values are set only if the IME supports those modes.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetconversionstatus BOOL ImmGetConversionStatus( HIMC hIMC, [out,
	// optional] LPDWORD lpfdwConversion, [out, optional] LPDWORD lpfdwSentence );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetConversionStatus")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmGetConversionStatus(HIMC hIMC, out IME_CMODE lpfdwConversion, out IME_SMODE lpfdwSentence);

	/// <summary>Retrieves the default window handle to the IME class.</summary>
	/// <param name="hWnd">[in] Handle to the window for the application.</param>
	/// <returns>Returns the default window handle to the IME class if successful, or <c>NULL</c> otherwise.</returns>
	/// <remarks>
	/// The operating system creates a default IME window for every thread. The window is created based on the IME class. The application
	/// can send the WM_IME_CONTROL message to this window.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetdefaultimewnd HWND ImmGetDefaultIMEWnd( HWND hWnd );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetDefaultIMEWnd")]
	public static extern HWND ImmGetDefaultIMEWnd(HWND hWnd);

	/// <summary>Copies the description of the IME to the specified buffer.</summary>
	/// <param name="hKL">Handle to the keyboard layout.</param>
	/// <param name="lpszDescription">
	/// Pointer to a buffer in which the function retrieves the null-terminated string describing the IME.
	/// </param>
	/// <param name="uBufLen">
	/// <para>
	/// Size, in characters, of the output buffer. The application sets this parameter to 0 if the function is to return the buffer size
	/// needed for the complete description, excluding the terminating null character.
	/// </para>
	/// <para>
	/// <c>Windows NT, Windows 2000, Windows XP:</c> The size of the buffer is in Unicode characters, each consisting of two bytes. If
	/// the parameter is set to 0, the function returns the size of the buffer required in Unicode characters, excluding the Unicode
	/// terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// Returns the number of characters copied to the output buffer. If the application sets the <c>uBufLen</c> parameter to 0, the
	/// function returns the size of the buffer required to receive the description. Neither value includes the terminating null
	/// character. For Unicode, the function returns the number of Unicode characters, not including the Unicode terminating null character.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetdescriptiona UINT ImmGetDescriptionA( HKL hKL, [out, optional]
	// LPSTR lpszDescription, [in] UINT uBufLen );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetDescriptionA")]
	public static extern uint ImmGetDescription(HKL hKL, [Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszDescription, uint uBufLen);

	/// <summary>Retrieves information about errors. Applications use the information for user notifications.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="dwIndex">
	/// <para>Type of guideline information to retrieve. This parameter can have one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>GGL_LEVEL</c></term>
	/// <term>Return the error level.</term>
	/// </item>
	/// <item>
	/// <term><c>GGL_INDEX</c></term>
	/// <term>Return the error index.</term>
	/// </item>
	/// <item>
	/// <term><c>GGL_STRING</c></term>
	/// <term>Return the error message string.</term>
	/// </item>
	/// <item>
	/// <term><c>GGL_PRIVATE</c></term>
	/// <term>Return information about reverse conversion.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpBuf">
	/// Pointer to a buffer in which the function retrieves the error message string. This parameter contains <c>NULL</c> if
	/// <c>dwIndex</c> is not GGL_STRING or GGL_PRIVATE or if <c>dwBufLen</c> is set to 0.
	/// </param>
	/// <param name="dwBufLen">
	/// Size, in bytes, of the output buffer. The application sets this parameter to 0 if the function is to return the buffer size
	/// needed to receive the error message string, not including the terminating null character.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns an error level, an error index, or the size of an error message string, depending on the value of the <c>dwIndex</c>
	/// parameter. If <c>dwIndex</c> is GGL_LEVEL, the return is one of the following <see cref="GL_LEVEL"/> values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GL_LEVEL_ERROR</term>
	/// <term>Error. The IME might not be able to continue.</term>
	/// </item>
	/// <item>
	/// <term>GL_LEVEL_FATAL</term>
	/// <term>Fatal error. The IME cannot continue, and data might be lost.</term>
	/// </item>
	/// <item>
	/// <term>GL_LEVEL_INFORMATION</term>
	/// <term>No error. Information is available for the user.</term>
	/// </item>
	/// <item>
	/// <term>GL_LEVEL_NOGUIDELINE</term>
	/// <term>No error. Remove previous error message if still visible.</term>
	/// </item>
	/// <item>
	/// <term>GL_LEVEL_WARNING</term>
	/// <term>Unexpected input or other result. The user should be warned, but the IME can continue.</term>
	/// </item>
	/// </list>
	/// <para>If <c>dwIndex</c> is GGL_INDEX, the return value is one of the following <see cref="GL_ID"/> values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GL_ID_CANNOTSAVE</term>
	/// <term>The dictionary or the statistics data cannot be saved.</term>
	/// </item>
	/// <item>
	/// <term>GL_ID_NOCONVERT</term>
	/// <term>The IME cannot convert any more.</term>
	/// </item>
	/// <item>
	/// <term>GL_ID_NODICTIONARY</term>
	/// <term>The IME cannot find the dictionary, or the dictionary has an unexpected format.</term>
	/// </item>
	/// <item>
	/// <term>GL_ID_NOMODULE</term>
	/// <term>The IME cannot find the module that is needed.</term>
	/// </item>
	/// <item>
	/// <term>GL_ID_READINGCONFLICT</term>
	/// <term>A reading conflict occurred. For example, some vowels cannot be put together to form one character.</term>
	/// </item>
	/// <item>
	/// <term>GL_ID_TOOMANYSTROKE</term>
	/// <term>There are too many strokes for one character or one clause.</term>
	/// </item>
	/// <item>
	/// <term>GL_ID_TYPINGERROR</term>
	/// <term>Typing error. The IME cannot handle this typing.</term>
	/// </item>
	/// <item>
	/// <term>GL_ID_UNKNOWN</term>
	/// <term>Unknown error. Refer to the error message string.</term>
	/// </item>
	/// <item>
	/// <term>GL_ID_INPUTREADING</term>
	/// <term>The IME is accepting reading character input from the end user.</term>
	/// </item>
	/// <item>
	/// <term>GL_ID_INPUTRADICAL</term>
	/// <term>The IME is accepting radical character input from the end user.</term>
	/// </item>
	/// <item>
	/// <term>GL_ID_INPUTCODE</term>
	/// <term>The IME is accepting character code input from the end user.</term>
	/// </item>
	/// <item>
	/// <term>GL_ID_CHOOSECANDIDATE</term>
	/// <term>The IME is accepting candidate string selection from the end user.</term>
	/// </item>
	/// <item>
	/// <term>GL_ID_REVERSECONVERSION</term>
	/// <term>
	/// Information about reverse conversion is available by calling <c>ImmGetGuideLine</c>, specifying GGL_PRIVATE. The information
	/// retrieved is in CANDIDATELIST format.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If <c>dwIndex</c> is GGL_STRING, the return value is the number of bytes of the string copied to the buffer. However, if
	/// <c>dwBufLen</c> is 0, the return value is the buffer size needed to receive the string, not including the terminating null
	/// character. For Unicode, if <c>dwBufLen</c> is 0, the return value is the size, in bytes not including the Unicode terminating
	/// null character.
	/// </para>
	/// <para>
	/// If <c>dwIndex</c> is GGL_PRIVATE, the return value is the number of bytes of information copied to the buffer. If <c>dwIndex</c>
	/// is GGL_PRIVATE and <c>dwBufLen</c> is 0, the return value is the buffer size needed to receive the information.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>Applications typically call this function after receiving an IMN_GUIDELINE command.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetguidelinea DWORD ImmGetGuideLineA( [in] HIMC hIMC, [in] DWORD
	// dwIndex, [out, optional] LPSTR lpBuf, [in] DWORD dwBufLen );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetGuideLineA")]
	public static extern uint ImmGetGuideLine(HIMC hIMC, GGL dwIndex, [Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpBuf, uint dwBufLen);

	/// <summary>Retrieves the file name of the IME associated with the specified input locale.</summary>
	/// <param name="hKL">Handle to the keyboard layout.</param>
	/// <param name="lpszFileName">
	/// Pointer to a buffer in which the function retrieves the file name. This parameter contains <c>NULL</c> when <c>uBufLen</c> is set
	/// to <c>NULL</c>.
	/// </param>
	/// <param name="uBufLen">
	/// Size, in bytes, of the output buffer. The application specifies 0 if the function is to return the buffer size needed to receive
	/// the file name, not including the terminating null character. For Unicode, <c>uBufLen</c> specifies the size in Unicode
	/// characters, not including the terminating null character.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns the number of bytes in the file name copied to the output buffer. If the application sets <c>uBufLen</c> to 0, the
	/// function returns the size of the buffer required for the file name. In either case, the terminating null character is not included.
	/// </para>
	/// <para>
	/// For Unicode, the function returns the number of Unicode characters copied into the output buffer, not including the Unicode
	/// terminating null character.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// In the registry, the operating system stores the file name as the "IME name value" in the registry key
	/// HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\Keyboard Layouts\HKL.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetimefilenamea UINT ImmGetIMEFileNameA( HKL hKL, [out, optional]
	// LPSTR lpszFileName, [in] UINT uBufLen );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetIMEFileNameA")]
	public static extern uint ImmGetIMEFileName(HKL hKL, [Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? lpszFileName, uint uBufLen);

	/// <summary>Retrieves the menu items that are registered in the IME menu of a specified input context.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="dwFlags">
	/// <para>Flag specifying menu information options. The following value is defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>IGIMIF_RIGHTMENU</c></term>
	/// <term>Retrieve the menu items for the context menu, obtained by a right mouse click.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwType">
	/// <para>Type of menu to retrieve. This parameter can have one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>IGIMII_CMODE</c></term>
	/// <term>Retrieve the menu items that control conversion mode.</term>
	/// </item>
	/// <item>
	/// <term><c>IGIMII_SMODE</c></term>
	/// <term>Retrieve the menu items that control sentence mode.</term>
	/// </item>
	/// <item>
	/// <term><c>IGIMII_CONFIGURE</c></term>
	/// <term>Retrieve the menu items that are related to IME configuration.</term>
	/// </item>
	/// <item>
	/// <term><c>IGIMII_TOOLS</c></term>
	/// <term>Retrieve the menu items that are related to IME tools.</term>
	/// </item>
	/// <item>
	/// <term><c>IGIMII_HELP</c></term>
	/// <term>Retrieve the menu items that control IME Help.</term>
	/// </item>
	/// <item>
	/// <term><c>IGIMII_OTHER</c></term>
	/// <term>Retrieve the menu items that control other IME functions.</term>
	/// </item>
	/// <item>
	/// <term><c>IGIMII_INPUTTOOLS</c></term>
	/// <term>Retrieve the menu items that control menu items related to IME input tools providing an extended way to input characters.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpImeParentMenu">
	/// Pointer to an IMEMENUITEMINFO structure in which the function retrieves parent menu information. To retrieve information about
	/// the submenu items of this parent menu, the application sets the <c>fType</c> member to MFT_SUBMENU. This parameter contains
	/// <c>NULL</c> if the function retrieves only top-level menu items.
	/// </param>
	/// <param name="lpImeMenu">
	/// Pointer to an array of IMEMENUITEMINFO structures in which the function retrieves information about the menu items. This
	/// parameter contains <c>NULL</c> if the function retrieves the number of registered menu items.
	/// </param>
	/// <returns>
	/// Returns the number of menu items copied into <c>lpImeMenu</c>. If <c>lpImeMenu</c> specifies <c>NULL</c>, the function returns
	/// the number of registered menu items in the specified input context.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetimemenuitemsa DWORD ImmGetImeMenuItemsA( [in] HIMC hIMC, [in]
	// DWORD unnamedParam2, [in] DWORD unnamedParam3, [out, optional] LPIMEMENUITEMINFOA lpImeParentMenu, [out, optional]
	// LPIMEMENUITEMINFOA lpImeMenu, [in] DWORD dwSize );
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetImeMenuItemsA")]
	public static uint ImmGetImeMenuItems(HIMC hIMC, IGIMIF dwFlags, IGIMII dwType,
		out IMEMENUITEMINFO lpImeParentMenu, [Out, Optional, MarshalAs(UnmanagedType.LPArray)] IMEMENUITEMINFO[]? lpImeMenu) =>
		ImmGetImeMenuItems(hIMC, dwFlags, dwType, out lpImeParentMenu, lpImeMenu, lpImeMenu is null ? 0 : Marshal.SizeOf(typeof(IMEMENUITEMINFO)) * lpImeMenu.Length);

	/// <summary>Determines whether the IME is open or closed.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <returns>Returns a nonzero value if the IME is open, or 0 otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetopenstatus BOOL ImmGetOpenStatus( HIMC hIMC );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetOpenStatus")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmGetOpenStatus(HIMC hIMC);

	/// <summary>Retrieves the property and capabilities of the IME associated with the specified input locale.</summary>
	/// <param name="hKL">Handle to the keyboard layout.</param>
	/// <param name="dwIndex">
	/// Value that specifies the type of property information to retrieve. The following table shows the values this parameter can be.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns the property or capability value, depending on the value of the <c>dwIndex</c> parameter. If <c>dwIndex</c> is set to
	/// IGP_PROPERTY, the function returns one or more of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>IME_PROP_AT_CARET</term>
	/// <term>If set, conversion window is at the caret position. If clear, the window is near the caret position.</term>
	/// </item>
	/// <item>
	/// <term>IME_PROP_SPECIAL_UI</term>
	/// <term>If set, the IME has a nonstandard user interface. The application should not draw in the IME window.</term>
	/// </item>
	/// <item>
	/// <term>IME_PROP_CANDLIST_START_FROM_1</term>
	/// <term>If set, strings in the candidate list are numbered starting at 1. If clear, strings start at 0.</term>
	/// </item>
	/// <item>
	/// <term>IME_PROP_UNICODE</term>
	/// <term>
	/// If set, the IME is viewed as a Unicode IME. The operating system and the IME communicate through the Unicode IME interface. If
	/// clear, the IME uses the ANSI interface to communicate with the operating system.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IME_PROP_COMPLETE_ON_UNSELECT</term>
	/// <term>
	/// If set, the IME completes the composition string when the IME is deactivated. If clear, the IME cancels the composition string
	/// when the IME is deactivated, for example, from a keyboard layout change.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IME_PROP_ACCEPT_WIDE_VKEY</term>
	/// <term>
	/// If set, the IME processes the injected Unicode that came from the SendInput function by using VK_PACKET. If clear, the IME might
	/// not process the injected Unicode, and might send the injected Unicode to the application directly.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If <c>dwIndex</c> is set to IGP_UI, the function returns one or more of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>UI_CAP_2700</term>
	/// <term>Support text escapement values of 0 or 2700. For more information, see the <c>lfEscapement</c> member of the LOGFONT structure.</term>
	/// </item>
	/// <item>
	/// <term>UI_CAP_ROT90</term>
	/// <term>Support text escapement values of 0, 900, 1800, or 2700. For more information, see <c>lfEscapement</c>.</term>
	/// </item>
	/// <item>
	/// <term>UI_CAP_ROTANY</term>
	/// <term>Support any text escapement value. For more information, see <c>lfEscapement</c>.</term>
	/// </item>
	/// </list>
	/// <para>If <c>dwIndex</c> is set to IGP_SETCOMPSTR, the function returns one or more of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SCS_CAP_COMPSTR</term>
	/// <term>Create the composition string by calling the ImmSetCompositionString function with the SCS_SETSTR value.</term>
	/// </item>
	/// <item>
	/// <term>SCS_CAP_MAKEREAD</term>
	/// <term>
	/// Create the reading string from corresponding composition string when using the ImmSetCompositionString function with SCS_SETSTR
	/// and without setting <c>lpRead</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SCS_CAP_SETRECONVERTSTRING:</term>
	/// <term>This IME can support reconversion. Use ImmSetCompositionString to do reconversion.</term>
	/// </item>
	/// </list>
	/// <para>If <c>dwIndex</c> is set to IGP_SELECT, the function returns one or more of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SELECT_CAP_CONVMODE</term>
	/// <term>Inherit conversion mode when a new IME is selected.</term>
	/// </item>
	/// <item>
	/// <term>SELECT_CAP_SENTENCE</term>
	/// <term>Inherit sentence mode when a new IME is selected.</term>
	/// </item>
	/// </list>
	/// <para>If <c>dwIndex</c> is set to IGP_GETIMEVERSION, the function returns one or more of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>IMEVER_0310</term>
	/// <term>The IME was created for Windows 3.1.</term>
	/// </item>
	/// <item>
	/// <term>IMEVER_0400</term>
	/// <term>The IME was created for Windows Me/98/95.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetproperty DWORD ImmGetProperty( HKL hKL, DWORD unnamedParam2 );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetProperty")]
	public static extern uint ImmGetProperty(HKL hKL, IGP dwIndex);

	/// <summary>Retrieves a list of the styles supported by the IME associated with the specified input locale.</summary>
	/// <param name="hKL">Handle to the keyboard layout.</param>
	/// <param name="nItem">
	/// Maximum number of styles that the output buffer can hold. The application sets this parameter to 0 if the function is to count
	/// the number of styles available in the IME.
	/// </param>
	/// <param name="lpStyleBuf">Pointer to a STYLEBUF structure in which the function retrieves the style information.</param>
	/// <returns>
	/// Returns the number of styles copied to the buffer. If the application sets the <c>nItem</c> parameter to 0, the return value is
	/// the number of styles available in the IME.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetregisterwordstylea UINT ImmGetRegisterWordStyleA( HKL hKL,
	// [in] UINT nItem, [out] LPSTYLEBUFA lpStyleBuf );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetRegisterWordStyleA")]
	public static extern uint ImmGetRegisterWordStyle(HKL hKL, uint nItem, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] STYLEBUF[]? lpStyleBuf);

	/// <summary>Retrieves the position of the status window.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="lpptPos">
	/// Pointer to a POINT structure in which the function retrieves the position coordinates. These are screen coordinates, relative to
	/// the upper left corner of the screen.
	/// </param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetstatuswindowpos BOOL ImmGetStatusWindowPos( HIMC hIMC, [out]
	// LPPOINT lpptPos );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetStatusWindowPos")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmGetStatusWindowPos(HIMC hIMC, out POINT lpptPos);

	/// <summary>Retrieves the original virtual key value associated with a key input message that the IME has already processed.</summary>
	/// <param name="hWnd">
	/// [in] Handle to the window that receives the key message. The input context that is queried is the one associated with this window.
	/// </param>
	/// <returns>
	/// If TranslateMessage has been called by the application, <c>ImmGetVirtualKey</c> returns VK_PROCESSKEY; otherwise, it returns the
	/// virtual key.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Although the IME sets the virtual key value to VK_PROCESSKEY after processing a key input message, an application can recover the
	/// original virtual key value with the <c>ImmGetVirtualKey</c> function. This function is used only for key input messages
	/// containing the VK_PROCESSKEY value. Applications can only get the original virtual key by using this function after receiving
	/// </para>
	/// <para>the WM_KEYDOWN (VK_PROCESSKEY) message, and before TranslateMessage is called in its own</para>
	/// <para>message loop.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immgetvirtualkey UINT ImmGetVirtualKey( HWND hWnd );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmGetVirtualKey")]
	public static extern VK ImmGetVirtualKey(HWND hWnd);

	/// <summary>Installs an IME.</summary>
	/// <param name="lpszIMEFileName">Pointer to a null-terminated string that specifies the full path of the IME.</param>
	/// <param name="lpszLayoutText">
	/// Pointer to a null-terminated string that specifies the name of the IME and the associated layout text.
	/// </param>
	/// <returns>Returns the input locale identifier for the IME.</returns>
	/// <remarks>
	/// <para>This function is intended to be used by IME setup applications only.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-imminstallimea HKL ImmInstallIMEA( [in] LPCSTR lpszIMEFileName, [in]
	// LPCSTR lpszLayoutText );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmInstallIMEA")]
	public static extern HKL ImmInstallIME([MarshalAs(UnmanagedType.LPTStr)] string lpszIMEFileName, [MarshalAs(UnmanagedType.LPTStr)] string lpszLayoutText);

	/// <summary>Determines if the specified input locale has an IME.</summary>
	/// <param name="hKL">Handle to the keyboard layout.</param>
	/// <returns>Returns a nonzero value if the specified locale has an IME, or 0 otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immisime BOOL ImmIsIME( HKL hKL );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmIsIME")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmIsIME(HKL hKL);

	/// <summary>This function checks for messages intended for the IME window and sends those messages to the specified window.</summary>
	/// <param name="hWndIME">Handle to a window belonging to the IME window class.</param>
	/// <param name="msg">Message to check.</param>
	/// <param name="wParam">Message-specific parameter.</param>
	/// <param name="lParam">Message-specific parameter.</param>
	/// <returns>Returns a nonzero value if the message is processed by the IME window, or 0 otherwise.</returns>
	/// <remarks>
	/// <para>
	/// An application typically uses this function to display a composition string or candidate list specified by the IME. If
	/// <c>hWndIME</c> is <c>NULL</c>, the function determines if the message is a user interface message.
	/// </para>
	/// <para>
	/// <c>Windows Me/98:</c> This function has only an ANSI version. To receive Unicode characters from a Unicode-based IME, the
	/// application should use ImmGetCompositionString.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immisuimessagea BOOL ImmIsUIMessageA( HWND hWnd, UINT unnamedParam2,
	// WPARAM unnamedParam3, LPARAM unnamedParam4 );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmIsUIMessageA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmIsUIMessage(HWND hWndIME, uint msg, IntPtr wParam, IntPtr lParam);

	/// <summary>Notifies the IME about changes to the status of the input context.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="dwAction">
	/// <para>Notification code. This parameter can have one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>NI_CHANGECANDIDATELIST</c></term>
	/// <term>
	/// An application changed the current selected candidate. The <c>dwIndex</c> parameter specifies an index of a candidate list to be
	/// selected and <c>dwValue</c> is not used.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>NI_CLOSECANDIDATE</c></term>
	/// <term>
	/// An application directs the IME to close a candidate list. The <c>dwIndex</c> parameter specifies an index of the list to close,
	/// and <c>dwValue</c> is not used. The IME sends a IMN_CLOSECANDIDATE command to the application if it closes the list.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>NI_COMPOSITIONSTR</c></term>
	/// <term>
	/// An application directs the IME to carry out an action on the composition string. The <c>dwIndex</c> parameter can be CPS_CANCEL,
	/// CPS_COMPLETE, CPS_CONVERT, or CPS_REVERT.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>NI_IMEMENUSELECTED</c></term>
	/// <term>
	/// An application directs the IME to allow the application to handle the specified menu. The <c>dwIndex</c> parameter specifies the
	/// ID of the menu and <c>dwValue</c> is an application-defined value for that menu item.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>NI_OPENCANDIDATE</c></term>
	/// <term>
	/// An application directs the IME to open a candidate list. The <c>dwIndex</c> parameter specifies the index of the list to open,
	/// and <c>dwValue</c> is not used. The IME sends a IMN_OPENCANDIDATE command to the application if it opens the list.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>NI_SELECTCANDIDATESTR</c></term>
	/// <term>
	/// An application has selected one of the candidates. The <c>dwIndex</c> parameter specifies an index of a candidate list to be
	/// selected. The <c>dwValue</c> parameter specifies an index of a candidate string in the selected candidate list.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>NI_SETCANDIDATE_PAGESIZE</c></term>
	/// <term>
	/// The application changes the page size of a candidate list. The <c>dwIndex</c> parameter specifies the candidate list to be
	/// changed and must have a value in the range 0 to 3. The <c>dwValue</c> parameter specifies the new page size.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>NI_SETCANDIDATE_PAGESTART</c></term>
	/// <term>
	/// The application changes the page starting index of a candidate list. The <c>dwIndex</c> parameter specifies the candidate list to
	/// be changed and must have a value in the range 0 to 3. The <c>dwValue</c> parameter specifies the new page start index.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwIndex">
	/// <para>
	/// Index of a candidate list. Alternatively, if <c>dwAction</c> is NI_COMPOSITIONSTR, this parameter can have one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>CPS_CANCEL</c></term>
	/// <term>Clear the composition string and set the status to no composition string.</term>
	/// </item>
	/// <item>
	/// <term><c>CPS_COMPLETE</c></term>
	/// <term>Set the composition string as the result string.</term>
	/// </item>
	/// <item>
	/// <term><c>CPS_CONVERT</c></term>
	/// <term>Convert the composition string.</term>
	/// </item>
	/// <item>
	/// <term><c>CPS_REVERT</c></term>
	/// <term>Cancel the current composition string and set the composition string to be the unconverted string.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwValue">
	/// Index of a candidate string. The application can set this parameter or ignore it, depending on the value of the <c>dwAction</c> parameter.
	/// </param>
	/// <returns>Returns nonzero if successful, or 0 otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immnotifyime BOOL ImmNotifyIME( HIMC hIMC, [in] DWORD dwAction, [in]
	// DWORD dwIndex, [in] DWORD dwValue );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmNotifyIME")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmNotifyIME(HIMC hIMC, NI dwAction, CPS dwIndex, uint dwValue);

	/// <summary>
	/// This function releases the input context and unlocks the memory associated in the context. An application must call
	/// ImmReleaseContext for each call to the ImmGetContext function.
	/// </summary>
	/// <param name="hWnd">[in] Handle to the window for which the input context was previously retrieved.</param>
	/// <param name="hIMC">[in] Handle to the input context.</param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immreleasecontext BOOL ImmReleaseContext( HWND hWnd, HIMC hIMC );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmReleaseContext")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmReleaseContext(HWND hWnd, HIMC hIMC);

	/// <summary>This function sets information about the candidate list window.</summary>
	/// <param name="hIMC">[in] Handle to the input context.</param>
	/// <param name="lpCandidate">Pointer to a CANDIDATEFORM structure that contains information about the candidates window.</param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	/// <remarks>This function causes an IMN_SETCANDIDATEPOS command to be sent. Both the IME and the application call this function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immsetcandidatewindow BOOL ImmSetCandidateWindow( HIMC hIMC, [in]
	// LPCANDIDATEFORM lpCandidate );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmSetCandidateWindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmSetCandidateWindow(HIMC hIMC, in CANDIDATEFORM lpCandidate);

	/// <summary>This function sets the logical font to be used to display characters in the composition window.</summary>
	/// <param name="hIMC">[in] Handle to the input context.</param>
	/// <param name="lplf">Pointer to a LOGFONT structure containing the font information to set.</param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	/// <remarks>
	/// <para>
	/// This function causes a IMN_SETCOMPOSITIONFONT command to be sent to an application. Even if the application never uses the
	/// composition window, it must set the appropriate font to ensure that characters are displayed properly. This is especially true
	/// for vertical writing.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immsetcompositionfonta BOOL ImmSetCompositionFontA( HIMC hIMC, [in]
	// LPLOGFONTA lplf );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmSetCompositionFontA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmSetCompositionFont(HIMC hIMC, in LOGFONT lplf);

	/// <summary>This function sets the characters, attributes, and clauses of the composition and reading strings.</summary>
	/// <param name="hIMC">[in] Handle to the input context.</param>
	/// <param name="dwIndex">
	/// <para>Type of information to set. This parameter can have one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SCS_SETSTR</c></term>
	/// <term>
	/// Set the composition string, the reading string, or both. At least one of the <c>lpComp</c> and <c>lpRead</c> parameters must
	/// indicate a valid string. If either string is too long, the IME truncates it.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCS_CHANGEATTR</c></term>
	/// <term>
	/// Set attributes for the composition string, the reading string, or both. At least one of the <c>lpComp</c> and <c>lpRead</c>
	/// parameters must indicate a valid attribute array.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCS_CHANGECLAUSE</c></term>
	/// <term>
	/// Set the clause information for the composition string, the reading string, or both. At least one of the <c>lpComp</c> and
	/// <c>lpRead</c> parameters must point to a valid clause information array.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>SCS_SETRECONVERTSTRING</c></term>
	/// <term><c>Windows Me/98, Windows 2000, Windows XP:</c> Ask IME to reconvert the string using a specified RECONVERTSTRING structure.</term>
	/// </item>
	/// <item>
	/// <term><c>SCS_QUERYRECONVERTSTRING</c></term>
	/// <term>
	/// <c>Windows Me/98, Windows 2000, Windows XP:</c> Ask IME to adjust the RECONVERTSTRING structure. Then the application can pass
	/// the adjusted structure into this function using SCS_SETRECONVERTSTRING. IME does not generate any WM_IME_COMPOSITION messages.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpComp">
	/// Pointer to a buffer containing the information to set for the composition string, as specified by the value of <c>dwIndex</c>.
	/// </param>
	/// <param name="dwCompLen">
	/// Size, in bytes, of the information buffer for the composition string, even if SCS_SETSTR is specified and the buffer contains a
	/// Unicode string.
	/// </param>
	/// <param name="lpRead">
	/// Pointer to a buffer containing the information to set for the reading string, as specified by the value of <c>dwIndex</c>. The
	/// application can set this parameter to <c>NULL</c>.
	/// </param>
	/// <param name="dwReadLen">
	/// Size, in bytes, of the information buffer for the reading string, even if SCS_SETSTR is specified and the buffer contains a
	/// Unicode string.
	/// </param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	/// <remarks>
	/// <para>
	/// The application can set <c>lpComp</c>, <c>lpRead</c>, or both. If the application does not specify a value for <c>lpComp</c>, it
	/// must set this parameter to <c>NULL</c> and set <c>dwCompLen</c> to 0.
	/// </para>
	/// <para>
	/// When the application is changing attributes, all characters in a clause must have the same attribute. Converted characters must
	/// have the attribute ATTR_CONVERTED or ATTR_TARGET_CONVERTED. Unconverted characters must have the attribute ATTR_INPUT or ATTR_TARGET_NOTCONVERTED.
	/// </para>
	/// <para>
	/// When the application is changing clause information, it can change only the target clause, just affecting one boundary at a time.
	/// The target clause has the attribute ATTR_TARGET_CONVERTED or ATTR_TARGET_NOTCONVERTED.
	/// </para>
	/// <para>For additional information about attributes (ATTR_* values), see Composition String.</para>
	/// <para>When the IME completes the changes, it sends a WM_IME_COMPOSITION message to the application to notify it of the changes.</para>
	/// <para>
	/// <c>Windows Me/98, Windows 2000, Windows XP:</c> The SCS_*CONVERTSTRING values are used for reconversion. They can only be used
	/// for an IME that has the SCS_CAP_SETRECONVERTSTRING property. The application uses these values as follows:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Call <c>ImmSetCompositionString</c> with SCS_QUERYRECONVERTSTRING, so that IME adjusts the RECONVERTSTRING structure for the reconversion.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Call <c>ImmSetCompositionString</c> with SCS_SETRECONVERTSTRING, so that IME generates a new composition string. After this,
	/// <c>lpComp</c> and <c>lpRead</c> indicate a RECONVERTSTRING structure that contains the updated composition and reading string.
	/// Use the value of <c>lpRead</c> only when the selected IME has SCS_CAP_MAKEREAD set.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immsetcompositionstringa BOOL ImmSetCompositionStringA( HIMC hIMC,
	// [in] DWORD dwIndex, [in, optional] LPVOID lpComp, [in] DWORD dwCompLen, [in, optional] LPVOID lpRead, [in] DWORD dwReadLen );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmSetCompositionStringA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmSetCompositionString(HIMC hIMC, SCS dwIndex, [In, Optional] IntPtr lpComp, uint dwCompLen, [In, Optional] IntPtr lpRead, uint dwReadLen);

	/// <summary>This function sets the position of the composition window.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="lpCompForm">
	/// Pointer to a COMPOSITIONFORM structure that contains the new position and other related information about the composition window.
	/// </param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	/// <remarks>This function causes an IMN_SETCOMPOSITIONWINDOW command to be sent to the application.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immsetcompositionwindow BOOL ImmSetCompositionWindow( HIMC hIMC,
	// [in] LPCOMPOSITIONFORM lpCompForm );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmSetCompositionWindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmSetCompositionWindow(HIMC hIMC, in COMPOSITIONFORM lpCompForm);

	/// <summary>This function sets the current conversion status.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="fdwConversion">Conversion mode values. For more information, see IME Conversion Mode Values.</param>
	/// <param name="fdwSentence">Sentence mode values. For more information, see IME Sentence Mode Values.</param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	/// <remarks>
	/// <para>This function sends the IMN_SETCONVERSIONMODE and IMN_SETSENTENCEMODE commands to the application.</para>
	/// <para>
	/// <c>Note</c><c>Beginning with Windows 8:</c> By default, the input switch is set per user instead of per thread. The Microsoft IME
	/// (Japanese) respects the mode globally, and therefore <c>ImmSetConversionStatus</c> fails when getting focus.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immsetconversionstatus BOOL ImmSetConversionStatus( [in] HIMC hIMC,
	// [in] DWORD unnamedParam2, [in] DWORD unnamedParam3 );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmSetConversionStatus")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmSetConversionStatus(HIMC hIMC, IME_CMODE fdwConversion, IME_SMODE fdwSentence);

	/// <summary>This function opens or closes the IME.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="fOpen">[in] Open flag. If TRUE, the IME is opened; otherwise, it is closed.</param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	/// <remarks>This function causes an IMN_SETOPENSTATUS command to be sent to the application.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immsetopenstatus BOOL ImmSetOpenStatus( HIMC hIMC, BOOL
	// unnamedParam2 );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmSetOpenStatus")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmSetOpenStatus(HIMC hIMC, [MarshalAs(UnmanagedType.Bool)] bool fOpen);

	/// <summary>
	/// Simulates the specified IME hot key, causing the same response as if the user presses the hot key in the specified window.
	/// </summary>
	/// <param name="hWnd">[in] Handle to the window.</param>
	/// <param name="dwHotKeyID">[in] Identifier of the IME hot key.</param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immsimulatehotkey BOOL ImmSimulateHotKey( HWND hWnd, DWORD
	// unnamedParam2 );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmSimulateHotKey")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmSimulateHotKey(HWND hWnd, IME_HOTKEY dwHotKeyID);

	/// <summary>This function removes a register string from the dictionary of the IME associated with the specified keyboard layout.</summary>
	/// <param name="hKL">Handle to the keyboard layout.</param>
	/// <param name="lpszReading">Pointer to a null-terminated reading string associated with the string to remove.</param>
	/// <param name="dwStyle">
	/// [in] Style of the register string. This parameter can be IME_REGWORD_STYLE_EUDC to indicate the string is in the EUDC range, or
	/// any value in the reserved range IME_REGWORD_STYLE_USER_FIRST to IME_REGWORD_STYLE_USER_LAST to indicate a private style
	/// maintained by the specified IME.
	/// </param>
	/// <param name="lpszUnregister">Pointer to a null-terminated string specifying the register string to remove.</param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/nf-imm-immunregisterworda BOOL ImmUnregisterWordA( HKL hKL, [in] LPCSTR
	// lpszReading, DWORD unnamedParam3, [in] LPCSTR lpszUnregister );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("imm.h", MSDNShortId = "NF:imm.ImmUnregisterWordA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmUnregisterWord(HKL hKL, [MarshalAs(UnmanagedType.LPTStr)] string lpszReading, IME_REGWORD_STYLE dwStyle, [MarshalAs(UnmanagedType.LPTStr)] string lpszUnregister);

	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	private static extern uint ImmGetImeMenuItems(HIMC hIMC, IGIMIF dwFlags, IGIMII dwType, out IMEMENUITEMINFO lpImeParentMenu,
		[Out, Optional, MarshalAs(UnmanagedType.LPArray)] IMEMENUITEMINFO[]? lpImeMenu, int dwSize);

	/// <summary>Contains information about a candidate list.</summary>
	/// <remarks>The candidate strings immediately follow the last offset in the <c>dwOffset</c> array.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/ns-imm-candidatelist typedef struct tagCANDIDATELIST { DWORD dwSize; DWORD
	// dwStyle; DWORD dwCount; DWORD dwSelection; DWORD dwPageStart; DWORD dwPageSize; DWORD dwOffset[1]; } CANDIDATELIST,
	// *PCANDIDATELIST, *NPCANDIDATELIST, *LPCANDIDATELIST;
	[PInvokeData("imm.h", MSDNShortId = "NS:imm.tagCANDIDATELIST")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CANDIDATELIST
	{
		/// <summary>Size, in bytes, of the structure, the offset array, and all candidate strings.</summary>
		public uint dwSize;

		/// <summary>
		/// <para>Candidate style values. This member can have one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IME_CAND_UNKNOWN</term>
		/// <term>Candidates are in a style other than listed here.</term>
		/// </item>
		/// <item>
		/// <term>IME_CAND_READ</term>
		/// <term>Candidates are in same reading.</term>
		/// </item>
		/// <item>
		/// <term>IME_CAND_CODE</term>
		/// <term>Candidates are in a code range.</term>
		/// </item>
		/// <item>
		/// <term>IME_CAND_MEANING</term>
		/// <term>Candidates are in same meaning.</term>
		/// </item>
		/// <item>
		/// <term>IME_CAND_RADICAL</term>
		/// <term>Candidates use same radical character.</term>
		/// </item>
		/// <item>
		/// <term>IME_CAND_STROKES</term>
		/// <term>Candidates are in same number of strokes.</term>
		/// </item>
		/// </list>
		/// <para>
		/// For the IME_CAND_CODE style, the candidate list has a special structure depending on the value of the <c>dwCount</c> member.
		/// If <c>dwCount</c> is 1, the <c>dwOffset</c> member contains a single DBCS character rather than an offset, and no candidate
		/// string is provided. If the <c>dwCount</c> member is greater than 1, the <c>dwOffset</c> member contains valid offsets, and
		/// the candidate strings are text representations of individual DBCS character values in hexadecimal notation.
		/// </para>
		/// </summary>
		public IME_CAND dwStyle;

		/// <summary>Number of candidate strings.</summary>
		public uint dwCount;

		/// <summary>Index of the selected candidate string.</summary>
		public uint dwSelection;

		/// <summary>
		/// Index of the first candidate string in the candidate window. This varies as the user presses the PAGE UP and PAGE DOWN keys.
		/// </summary>
		public uint dwPageStart;

		/// <summary>
		/// Number of candidate strings to be shown in one page in the candidate window. The user can move to the next page by pressing
		/// IME-defined keys, such as the PAGE UP or PAGE DOWN key. If this number is 0, an application can define a proper value by itself.
		/// </summary>
		public uint dwPageSize;

		/// <summary>
		/// Offset to the start of the first candidate string, relative to the start of this structure. The offsets for subsequent
		/// strings immediately follow this member, forming an array of 32-bit offsets.
		/// </summary>
		public uint dwOffset;
	}

	/// <summary>Contains information about a candidate list.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/ns-imm-candidatelist
	[PInvokeData("imm.h", MSDNShortId = "NS:imm.tagCANDIDATELIST")]
	[VanaraMarshaler(typeof(CANDIDATELISTMarshaler))]
	[StructLayout(LayoutKind.Sequential)]
	public struct CANDIDATELIST_MGD
	{
		/// <summary>
		/// <para>Candidate style values.</para>
		/// <para>
		/// For the IME_CAND_CODE style, the candidate list has a special structure depending on the value of the <c>dwCount</c> member.
		/// If <c>dwCount</c> is 1, the <c>dwOffset</c> member contains a single DBCS character rather than an offset, and no candidate
		/// string is provided. If the <c>dwCount</c> member is greater than 1, the <c>dwOffset</c> member contains valid offsets, and
		/// the candidate strings are text representations of individual DBCS character values in hexadecimal notation.
		/// </para>
		/// </summary>
		public IME_CAND style;

		/// <summary>Index of the selected candidate string.</summary>
		public uint selectedIndex;

		/// <summary>
		/// Index of the first candidate string in the candidate window. This varies as the user presses the PAGE UP and PAGE DOWN keys.
		/// </summary>
		public uint pageStartIndex;

		/// <summary>
		/// Number of candidate strings to be shown in one page in the candidate window. The user can move to the next page by pressing
		/// IME-defined keys, such as the PAGE UP or PAGE DOWN key. If this number is 0, an application can define a proper value by itself.
		/// </summary>
		public uint pageSize;

		/// <summary>The candidate strings.</summary>
		public string?[] candidates;
	}

	/// <summary>Contains style and position information for a composition window.</summary>
	/// <remarks>
	/// Some IME windows adjust the composition window position specified by the system or the application. The CFS_FORCE_POSITION
	/// directs the IME window to skip this adjustment.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/ns-imm-compositionform typedef struct tagCOMPOSITIONFORM { DWORD dwStyle;
	// POINT ptCurrentPos; RECT rcArea; } COMPOSITIONFORM, *PCOMPOSITIONFORM, *NPCOMPOSITIONFORM, *LPCOMPOSITIONFORM;
	[PInvokeData("imm.h", MSDNShortId = "NS:imm.tagCOMPOSITIONFORM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct COMPOSITIONFORM
	{
		/// <summary>
		/// <para>Position style. This member can be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CFS_DEFAULT</term>
		/// <term>
		/// Move the composition window to the default position. The IME window can display the composition window outside the client
		/// area, such as in a floating window.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CFS_FORCE_POSITION</term>
		/// <term>
		/// Display the upper left corner of the composition window at exactly the position specified by <c>ptCurrentPos</c>. The
		/// coordinates are relative to the upper left corner of the window containing the composition window and are not subject to
		/// adjustment by the IME.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CFS_POINT</term>
		/// <term>
		/// Display the upper left corner of the composition window at the position specified by <c>ptCurrentPos</c>. The coordinates are
		/// relative to the upper left corner of the window containing the composition window and are subject to adjustment by the IME.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CFS_RECT</term>
		/// <term>
		/// Display the composition window at the position specified by <c>rcArea</c>. The coordinates are relative to the upper left of
		/// the window containing the composition window.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public CFS dwStyle;

		/// <summary>A POINT structure containing the coordinates of the upper left corner of the composition window.</summary>
		public POINT ptCurrentPos;

		/// <summary>A RECT structure containing the coordinates of the upper left and lower right corners of the composition window.</summary>
		public RECT rcArea;
	}

	/// <summary>Provides a handle to an input context.</summary>
	[AutoHandle]
	public partial struct HIMC { }

	/// <summary>Contains information about IME menu items.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/ns-imm-imemenuiteminfoa typedef struct tagIMEMENUITEMINFOA { UINT cbSize;
	// UINT fType; UINT fState; UINT wID; HBITMAP hbmpChecked; HBITMAP hbmpUnchecked; DWORD dwItemData; CHAR
	// szString[IMEMENUITEM_STRING_SIZE]; HBITMAP hbmpItem; } IMEMENUITEMINFOA, *PIMEMENUITEMINFOA, *NPIMEMENUITEMINFOA, *LPIMEMENUITEMINFOA;
	[PInvokeData("imm.h", MSDNShortId = "NS:imm.tagIMEMENUITEMINFOA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct IMEMENUITEMINFO
	{
		private const int IMEMENUITEM_STRING_SIZE = 80;

		/// <summary>Size, in bytes, of the structure.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>Menu item type. This member can have one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IMFT_RADIOCCHECK</term>
		/// <term>Display checked menu items using a radio-button mark instead of a check mark if the <c>hbmpChecked</c> member is <c>NULL</c>.</term>
		/// </item>
		/// <item>
		/// <term>IMFT_SEPARATOR</term>
		/// <term>
		/// Menu item is a separator. A menu item separator appears as a horizontal dividing line. The <c>hbmpItem</c> and
		/// <c>szString</c> members are ignored in this case.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IMFT_SUBMENU</term>
		/// <term>Menu item is a submenu.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IMFT fType;

		/// <summary>
		/// <para>Menu item state. This member can have one or more of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IMFS_CHECKED</term>
		/// <term>The menu item is checked. For more information, see the description of the <c>hbmpChecked</c> member.</term>
		/// </item>
		/// <item>
		/// <term>IMFS_DEFAULT</term>
		/// <term>The menu item is the default. A menu can contain only one default menu item, which is displayed in bold.</term>
		/// </item>
		/// <item>
		/// <term>IMFS_DISABLED</term>
		/// <term>The menu item is disabled and appears dimmed so it cannot be selected. This is equivalent to IMFS_GRAYED.</term>
		/// </item>
		/// <item>
		/// <term>IMFS_ENABLED</term>
		/// <term>The menu item is enabled. This is the default state.</term>
		/// </item>
		/// <item>
		/// <term>IMFS_GRAYED</term>
		/// <term>The menu item is disabled and appears dimmed so it cannot be selected. This is equivalent to IMFS_DISABLED.</term>
		/// </item>
		/// <item>
		/// <term>IMFS_HILITE</term>
		/// <term>The menu item is highlighted.</term>
		/// </item>
		/// <item>
		/// <term>IMFS_UNCHECKED</term>
		/// <term>
		/// The menu item is unchecked. For more information about unchecked menu items, see the description of the <c>hbmpUnchecked</c> member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IMFS_UNHILITE</term>
		/// <term>The menu item is not highlighted. This is the default state.</term>
		/// </item>
		/// </list>
		/// </summary>
		public IMFS fState;

		/// <summary>Application-defined 16-bit value that identifies the menu item.</summary>
		public uint wID;

		/// <summary>
		/// Handle to the bitmap to display next to the item if it is checked. If this member is <c>NULL</c>, a default bitmap is used.
		/// If the IMFT_RADIOCHECK type value is specified, the default bitmap is a bullet. Otherwise, it is a check mark.
		/// </summary>
		public HBITMAP hbmpChecked;

		/// <summary>
		/// Handle to the bitmap to display next to the item if it is not checked. If this member is <c>NULL</c>, no bitmap is used.
		/// </summary>
		public HBITMAP hbmpUnchecked;

		/// <summary>Application-defined value associated with the menu item.</summary>
		public uint dwItemData;

		/// <summary>Content of the menu item. This is a null-terminated string.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = IMEMENUITEM_STRING_SIZE)]
		public string szString;

		/// <summary>Handle to a bitmap to display.</summary>
		public HBITMAP hbmpItem;
	}

	/// <summary>Contains reading information or a word to register.</summary>
	/// <remarks>
	/// <para>
	/// The application can pass this structure to the ImmConfigureIME function to have the information or word appear as an initial
	/// value in the configuration dialog box for the IME.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imm/ns-imm-registerworda typedef struct tagREGISTERWORDA { LPSTR lpReading;
	// LPSTR lpWord; } REGISTERWORDA, *PREGISTERWORDA, *NPREGISTERWORDA, *LPREGISTERWORDA;
	[PInvokeData("imm.h", MSDNShortId = "NS:imm.tagREGISTERWORDA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct REGISTERWORD
	{
		/// <summary>
		/// Pointer to the reading information for the word to register. If the reading information is not needed, the member can be set
		/// to <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpReading;

		/// <summary>Pointer to the word to register. If a word is not needed, the member can be set to <c>NULL</c>.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpWord;
	}

	/// <summary>Contains the identifier and name of the style.</summary>
	/// <remarks>This structure maps to the STYLEBUF structure documented in the Windows Software Development Kit (SDK).</remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa741234(v=vs.85) typedef
	// struct { DWORD dwStyle; __wchar_t szDescription[STYLE_DESCRIPTION_SIZE]; } STYLEBUFA;
	[PInvokeData("Dimm.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct STYLEBUF
	{
		private const int STYLE_DESCRIPTION_SIZE = 32;

		/// <summary>
		/// <c>dwStyle</c> Unsigned long integer value that contains the style of the register string. This can be IME_REGWORD_STYLE_EUDC
		/// to indicate a string in the EUDC range.
		/// </summary>
		public IME_REGWORD_STYLE dwStyle;

		/// <summary><c>szDescription</c> Array of characters that contains the description of the style.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = STYLE_DESCRIPTION_SIZE)]
		public string szDescription;
	}

	private class CANDIDATELISTMarshaler : IVanaraMarshaler
	{
		SizeT IVanaraMarshaler.GetNativeSize() => Marshal.SizeOf(typeof(CANDIDATELIST));

		SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject) => new SafeHGlobalStruct<CANDIDATELIST>();

		object? IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
		{
			var mem = new SafeHGlobalStruct<CANDIDATELIST>(pNativeData, false, allocatedBytes);
			CANDIDATELIST info = mem.Value;
			return new CANDIDATELIST_MGD() { style = info.dwStyle, selectedIndex = info.dwSelection, pageSize = info.dwPageSize, pageStartIndex = info.dwPageStart, candidates = GetCand() };

			string?[] GetCand()
			{
				if (info.dwCount == 0)
					return new string[0];

				var offsetPtr = mem.GetFieldAddress(nameof(CANDIDATELIST.dwOffset));
				if (info.dwStyle == IME_CAND.IME_CAND_CODE && info.dwCount == 1)
					return new[] { StringHelper.GetString(offsetPtr, 1, CharSet.Unicode) };
				return Array.ConvertAll(offsetPtr.ToArray<uint>((int)info.dwCount)!, o => StringHelper.GetString(pNativeData.Offset(o)));
			}
		}
	}
}