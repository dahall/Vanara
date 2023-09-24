using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

public static partial class Imm32
{
	/// <summary>
	/// Accesses capabilities of particular IMEs that are not available through other IME API functions. This function is used mainly for
	/// country-specific operations.
	/// </summary>
	/// <param name="hKL">Handle to the keyboard layout.</param>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="uEscape">[in] Index of the subfunction. For more information about the escape, see IME Escapes.</param>
	/// <param name="lpData">[in] Long pointer to subfunction-specific data.</param>
	/// <returns>Returns an operation-specific value if successful, or 0 otherwise.</returns>
	/// <remarks>
	/// <para>
	/// When <c>uEscape</c> is set to IME_ESC_QUERY_SUPPORT, <c>lpData</c> indicates the buffer containing the IME escape value. For
	/// example, to see if the current IME supports IME_ESC_GETHELPFILENAME, your application uses the following call:
	/// </para>
	/// <para>
	/// <code>DWORD dwEsc = IME_ESC_GETHELPFILENAME; LRESULT lRet = ImmEscape(hKL, hIMC, IME_ESC_QUERY_SUPPORT, (LPVOID)&amp;dwEsc);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/immdev/nf-immdev-immescapea LRESULT ImmEscapeA( HKL hKL, HIMC hIMC, UINT
	// unnamedParam3, LPVOID unnamedParam4 );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("immdev.h", MSDNShortId = "NF:immdev.ImmEscapeA")]
	public static extern IntPtr ImmEscape([In] HKL hKL, [In] HIMC hIMC, IME_ESC uEscape, [In] IntPtr lpData = default);

	/// <summary>This function registers a string into the dictionary of the IME associated with the specified keyboard layout.</summary>
	/// <param name="hKL">Handle to the keyboard layout.</param>
	/// <param name="lpszReading">Pointer to a null-terminated reading string associated with the string to register.</param>
	/// <param name="dwStyle">
	/// [in] Style of the register string. This parameter can be IME_REGWORD_STYLE_EUDC to indicate the string is in the EUDC range, or
	/// any value in the reserved range IME_REGWORD_STYLE_USER_FIRST to IME_REGWORD_STYLE_USER_LAST to indicate a private style
	/// maintained by the specified IME.
	/// </param>
	/// <param name="lpszRegister">Pointer to the null-terminated string to register.</param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	/// <remarks>
	/// <para>
	/// An IME independent software vendor (ISV) can define private styles for an IME in the IME_REGWORD_STYLE_USER_FIRST and
	/// IME_REGWORD_STYLE_USER_LAST values. For example:
	/// </para>
	/// <para>
	/// <code>#define MSIME_NOUN (IME_REGWORD_STYLE_USER_FIRST) #define MSIME_VERB (IME_REGWORD_STYLE_USER_FIRST + 1)</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/immdev/nf-immdev-immregisterworda BOOL ImmRegisterWordA( HKL hKL, [in] LPCSTR
	// lpszReading, DWORD unnamedParam3, [in] LPCSTR lpszRegister );
	[DllImport(Lib_Imm32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("immdev.h", MSDNShortId = "NF:immdev.ImmRegisterWordA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmRegisterWord(HKL hKL, [MarshalAs(UnmanagedType.LPTStr)] string lpszReading, IME_REGWORD_STYLE dwStyle, [MarshalAs(UnmanagedType.LPTStr)] string lpszRegister);

	/// <summary>
	/// This function is called by the IME control panel application to set the value of the input method editor (IME) hot key.
	/// </summary>
	/// <param name="dwHotKeyID">[in] Hot key identifier.</param>
	/// <param name="uModifiers">
	/// [in] Pointer to the combination keys used with the hot key. Keys include MOD_ALT, MOD_CONTROL, MOD_SHIFT, MOD_LEFT, and
	/// MOD_RIGHT. The key up flag, MOD_ON_KEYUP, indicates the hot key is effective when the key is up. The modifier ignore flag,
	/// MOD_IGNORE_ALL_MODIFIER, indicates the combination of modifiers are ignored in hot key matching.
	/// </param>
	/// <param name="uVKey">[in] Virtual key code of the hot key.</param>
	/// <param name="hKL">
	/// <para>
	/// [in] Handle to the keyboard layout of the IME. If this parameter is specified, the hot key can switch to the IME with this
	/// keyboard layout handle.
	/// </para>
	/// <para>
	/// Windows CE does not support true keyboard layouts. In this instance, however, Windows CE uses the keyboard handle to associate
	/// hot keys with a specific IME and locale.
	/// </para>
	/// </param>
	/// <remarks>
	/// <para>For a key that is not on each side of the keyboard, uModifiers should specify both sides, MOD_LEFT|MODE_RIGHT.</para>
	/// <para>The following table shows the hot key identifiers that are supported by Windows CE.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Hot Key Identifier</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>IME_CHOTKEY_SHAPE_TOGGLE</term>
	/// <term>For simplified Chinese, toggles the shape conversion mode of IME.</term>
	/// </item>
	/// <item>
	/// <term>IME_CHOTKEY_SYMBOL_TOGGLE</term>
	/// <term>
	/// For simplified Chinese, toggles the symbol conversion mode of IME. Symbol mode indicates that the user can input Chinese
	/// punctuation and symbols by mapping to the punctuation and symbols on the keyboard.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IME_JHOTKEY_CLOSE_OPEN</term>
	/// <term>For Japanese, alternately opens and closes the IME.</term>
	/// </item>
	/// <item>
	/// <term>IME_KHOTKEY_ENGLISH</term>
	/// <term>Switches to from Korean to English.</term>
	/// </item>
	/// <item>
	/// <term>IME_KHOTKEY_SHAPE_TOGGLE</term>
	/// <term>For Korean, toggles the shape conversion mode of IME.</term>
	/// </item>
	/// <item>
	/// <term>IME_KHOTKEY_HANJACONVERT</term>
	/// <term>For Korean, switches to Hanja conversion.</term>
	/// </item>
	/// <item>
	/// <term>IME_THOTKEY_SHAPE_TOGGLE</term>
	/// <term>For traditional Chinese, toggles the shape conversion mode of IME.</term>
	/// </item>
	/// <item>
	/// <term>IME_THOTKEY_SYMBOL_TOGGLE</term>
	/// <term>For traditional Chinese, toggles the symbol conversion mode of IME.</term>
	/// </item>
	/// <item>
	/// <term>IME_HOTKEY_DSWITCH_FIRST through IME_HOTKEY_DSWITCH_LAST</term>
	/// <term>Enables an IME to be switched.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/embedded/ms920997(v=msdn.10)
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("immdev.h")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmSetHotKey(IME_HOTKEY dwHotKeyID, HotKeyModifiers uModifiers, VK uVKey, HKL hKL);

	/// <summary>This function sets the position of the status window.</summary>
	/// <param name="hIMC">Handle to the input context.</param>
	/// <param name="lpptPos">
	/// Pointer to a POINT structure containing the new position of the status window, in screen coordinates relative to the upper left
	/// corner of the display screen.
	/// </param>
	/// <returns>Returns a nonzero value if successful, or 0 otherwise.</returns>
	/// <remarks>This function causes an IMN_SETSTATUSWINDOWPOS command to be sent to the application.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/immdev/nf-immdev-immsetstatuswindowpos BOOL ImmSetStatusWindowPos( HIMC hIMC,
	// [in] LPPOINT lpptPos );
	[DllImport(Lib_Imm32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("immdev.h", MSDNShortId = "NF:immdev.ImmSetStatusWindowPos")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImmSetStatusWindowPos(HIMC hIMC, in POINT lpptPos);

	/// <summary>Contains position information for the candidate window.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/immdev/ns-immdev-candidateform typedef struct tagCANDIDATEFORM { DWORD dwIndex;
	// DWORD dwStyle; POINT ptCurrentPos; RECT rcArea; } CANDIDATEFORM, *PCANDIDATEFORM, *NPCANDIDATEFORM, *LPCANDIDATEFORM;
	[PInvokeData("immdev.h", MSDNShortId = "NS:immdev.tagCANDIDATEFORM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CANDIDATEFORM
	{
		/// <summary>Candidate list identifier. It is 0 for the first list, 1 for the second, and so on. The maximum index is 3.</summary>
		public uint dwIndex;

		/// <summary>
		/// <para>Position style. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CFS_CANDIDATEPOS</term>
		/// <term>
		/// Display the upper left corner of the candidate list window at the position specified by <c>ptCurrentPos</c>. The coordinates
		/// are relative to the upper left corner of the window containing the list window, and are subject to adjustment by the system.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CFS_EXCLUDE</term>
		/// <term>
		/// Exclude the candidate window from the area specified by <c>rcArea</c>. The <c>ptCurrentPos</c> member specifies the
		/// coordinates of the current point of interest, typically the caret position.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public CFS dwStyle;

		/// <summary>
		/// A POINT structure containing the coordinates of the upper left corner of the candidate window or the caret position,
		/// depending on the value of <c>dwStyle</c>.
		/// </summary>
		public POINT ptCurrentPos;

		/// <summary>A RECT structure containing the coordinates of the upper left and lower right corners of the exclusion area.</summary>
		public RECT rcArea;
	}

	/// <summary>Contains information about the character position in the composition window.</summary>
	/// <remarks>
	/// When an application uses IME to draw the composition string, the members of this structure are automatically filled. Applications
	/// that draw the composition string themselves, rather than relying on the IME, are responsible for filling all the fields defined
	/// in the structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/immdev/ns-immdev-imecharposition typedef struct tagIMECHARPOSITION { DWORD
	// dwSize; DWORD dwCharPos; POINT pt; UINT cLineHeight; RECT rcDocument; } IMECHARPOSITION, *PIMECHARPOSITION, *NPIMECHARPOSITION, *LPIMECHARPOSITION;
	[PInvokeData("immdev.h", MSDNShortId = "NS:immdev.tagIMECHARPOSITION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMECHARPOSITION
	{
		/// <summary>Size of the structure, in bytes.</summary>
		public uint dwSize;

		/// <summary>Character offset in the composition string, in <c>TCHAR</c> values.</summary>
		public uint dwCharPos;

		/// <summary>
		/// A POINT structure containing the coordinate of the top left point of requested character in screen coordinates. The top left
		/// point is based on the character baseline in any text flow.
		/// </summary>
		public POINT pt;

		/// <summary>Height of a line that contains the requested character, in pixels.</summary>
		public uint cLineHeight;

		/// <summary>A RECT structure containing the editable area for text, in screen coordinates, for the application.</summary>
		public RECT rcDocument;
	}

	/// <summary>Defines the strings for IME reconversion. It is the first item in a memory block that contains the strings for reconversion.</summary>
	/// <remarks>
	/// <para>
	/// The <c>dwCompStrOffset</c> and <c>dwTargetOffset</c> members are the relative positions in <c>dwStrOffset</c>. For a Unicode IME,
	/// <c>dwStrLen</c>, <c>dwCompStrLen</c>, and <c>dwTargetStrLen</c> are TCHAR values, that is, character counts. The members
	/// <c>dwStrOffset</c>, <c>dwCompStrOffset</c>, and <c>dwTargetStrOffset</c> specify byte counts.
	/// </para>
	/// <para>
	/// If an application starts the reconversion process by calling ImmSetCompositionString with SCS_SETRECONVERTSTRING and
	/// SCS_QUERYRECONVERTSTRING, the application must allocate the necessary memory for the <c>RECONVERTSTRING</c> structure as well as
	/// the composition string buffer. IME should not use this memory later. If IME starts the process, IME should allocate necessary
	/// memory for the structure and the composition string buffer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/immdev/ns-immdev-reconvertstring typedef struct tagRECONVERTSTRING { DWORD
	// dwSize; DWORD dwVersion; DWORD dwStrLen; DWORD dwStrOffset; DWORD dwCompStrLen; DWORD dwCompStrOffset; DWORD dwTargetStrLen; DWORD
	// dwTargetStrOffset; } RECONVERTSTRING, *PRECONVERTSTRING, *NPRECONVERTSTRING, *LPRECONVERTSTRING;
	[PInvokeData("immdev.h", MSDNShortId = "NS:immdev.tagRECONVERTSTRING")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RECONVERTSTRING
	{
		/// <summary>Size of this structure and the memory block it heads.</summary>
		public uint dwSize;

		/// <summary>Version number. Must be 0.</summary>
		public uint dwVersion;

		/// <summary>Length of the string that contains the composition string.</summary>
		public uint dwStrLen;

		/// <summary>Offset from the start position of this structure.</summary>
		public uint dwStrOffset;

		/// <summary>Length of the string that will be the composition string.</summary>
		public uint dwCompStrLen;

		/// <summary>Offset of the string that will be the composition string.</summary>
		public uint dwCompStrOffset;

		/// <summary>Length of the string that is related to the target clause in the composition string.</summary>
		public uint dwTargetStrLen;

		/// <summary>Offset of the target string.</summary>
		public uint dwTargetStrOffset;
	}
}