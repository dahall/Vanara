using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

/// <summary>Items from the MsftEdit.dll.</summary>
public static partial class MsftEdit
{
	/// <summary>For Microsoft Rich Edit 4.1 (Msftedit.dll), specify MSFTEDIT_CLASS as the window class.</summary>
	public const string MSFTEDIT_CLASS = "RICHEDIT50W";

	/// <summary>The rich edit 1.0 class.</summary>
	public const string RICHEDIT_CLASS10A = "RichEdit10";

	/// <summary>For all previous versions, specify RICHEDIT_CLASS for the Rich Edit class name.</summary>
	public static readonly string RICHEDIT_CLASS = "RichEdit20" + (Marshal.SystemDefaultCharSize == 1 ? "A" : "W");

	private const string Lib_msftedit = "msftedit.dll";
	private const string Lib_Riched20 = "riched20.dll";

	/// <summary>
	/// <para>
	/// The <c>AutoCorrectProc</c> function is an application-defined callback function that is used with the EM_SETAUTOCORRECTPROC message.
	/// </para>
	/// <para>
	/// <c>AutoCorrectProc</c> is a placeholder for the application-defined function name. It provides application-defined automatic error
	/// correction for text entered into a rich edit control.
	/// </para>
	/// </summary>
	/// <param name="langid">
	/// <para>Type: <c>LANGID</c></para>
	/// <para>Language ID that identifies the autocorrect file to use for automatic correcting.</para>
	/// </param>
	/// <param name="pszBefore">
	/// <para>Type: <c>const WCHAR*</c></para>
	/// <para>Autocorrect candidate string.</para>
	/// </param>
	/// <param name="pszAfter">
	/// <para>Type: <c>WCHAR*</c></para>
	/// <para>Resulting autocorrect string, if the return value is not <c>ATP_NOCHANGE</c>.</para>
	/// </param>
	/// <param name="cchAfter">
	/// <para>Type: <c>LONG</c></para>
	/// <para>Count of characters in <c>pszAfter</c>.</para>
	/// </param>
	/// <param name="pcchReplaced">
	/// <para>Type: <c>LONG*</c></para>
	/// <para>Count of trailing characters in <c>pszBefore</c> to replace with <c>pszAfter</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>int</c></para>
	/// <para>Returns one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code/value</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><c>ATP_NOCHANGE</c> 0</description>
	/// <description>No change.</description>
	/// </item>
	/// <item>
	/// <description><c>ATP_CHANGE</c> 1</description>
	/// <description>
	/// Change but donât replace most delimiters, and donât replace a span of unchanged trailing characters (preserves their formatting).
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>ATP_NODELIMITER</c> 2</description>
	/// <description>Change but donât replace a span of unchanged trailing characters.</description>
	/// </item>
	/// <item>
	/// <description><c>ATP_REPLACEALLTEXT</c> 4</description>
	/// <description>
	/// Replace trailing characters even if they are not changed (uses the same formatting for the entire replacement string).
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/nc-richedit-autocorrectproc AutoCorrectProc Autocorrectproc; int
	// Autocorrectproc( LANGID langid, const WCHAR *pszBefore, WCHAR *pszAfter, LONG cchAfter, LONG *pcchReplaced ) {...}
	[PInvokeData("richedit.h", MSDNShortId = "NC:richedit.AutoCorrectProc")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate int AutoCorrectProc(LANGID langid, [MarshalAs(UnmanagedType.LPWStr)] string pszBefore, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszAfter, int cchAfter, ref int pcchReplaced);

	/// <summary>
	/// The <c>EditStreamCallback</c> function is an application defined callback function used with the EM_STREAMIN and EM_STREAMOUT
	/// messages. It is used to transfer a stream of data into or out of a rich edit control. The <c>EDITSTREAMCALLBACK</c> type defines a
	/// pointer to this callback function. <c>EditStreamCallback</c> is a placeholder for the application-defined function name.
	/// </summary>
	/// <param name="dwCookie">
	/// <para>Type: <c>DWORD_PTR</c></para>
	/// <para>
	/// Value of the <c>dwCookie</c> member of the EDITSTREAM structure. The application specifies this value when it sends the EM_STREAMIN
	/// or EM_STREAMOUT message.
	/// </para>
	/// </param>
	/// <param name="pbBuff">
	/// <para>Type: <c>LPBYTE</c></para>
	/// <para>
	/// Pointer to a buffer to read from or write to. For a stream-in (read) operation, the callback function fills this buffer with data to
	/// transfer into the rich edit control. For a stream-out (write) operation, the buffer contains data from the control that the callback
	/// function writes to some storage.
	/// </para>
	/// </param>
	/// <param name="cb">
	/// <para>Type: <c>LONG</c></para>
	/// <para>Number of bytes to read or write.</para>
	/// </param>
	/// <param name="pcb">
	/// <para>Type: <c>LONG*</c></para>
	/// <para>Pointer to a variable that the callback function sets to the number of bytes actually read or written.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The callback function returns zero to indicate success.</para>
	/// <para>
	/// The callback function returns a nonzero value to indicate an error. If an error occurs, the read or write operation ends and the rich
	/// edit control discards any data in the <c>pbBuff</c> buffer. If the callback function returns a nonzero value, the rich edit control
	/// uses the <c>dwError</c> member of the EDITSTREAM structure to pass the value back to the application.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When you send the EM_STREAMIN or EM_STREAMOUT message to a rich edit control, the <c>pfnCallback</c> member of the EDITSTREAM
	/// structure specifies a pointer to an <c>EditStreamCallback</c> function. The rich edit control repeatedly calls the function to
	/// transfer a stream of data into or out of the control.
	/// </para>
	/// <para>
	/// When you send the EM_STREAMIN or EM_STREAMOUT message, you specify a value for the <c>dwCookie</c> member of the EDITSTREAM
	/// structure. The rich edit control uses the <c>dwCookie</c> parameter to pass this value to your <c>EditStreamCallback</c> function.
	/// For example, you might use <c>dwCookie</c> to pass a handle to an open file. The callback function can then use the <c>dwCookie</c>
	/// handle to read from or write to the file.
	/// </para>
	/// <para>
	/// The control calls the callback function repeatedly, transferring a portion of the data with each call. The control continues to call
	/// the callback function until one of the following conditions occurs:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>The callback function returns a nonzero value.</description>
	/// </item>
	/// <item>
	/// <description>The callback function returns zero in the * <c>pcb</c> parameter.</description>
	/// </item>
	/// <item>
	/// <description>
	/// An error occurs that prevents the rich edit control from transferring data into or out of itself. Examples are out-of-memory
	/// situations, failure of a system function, or an invalid character in the read buffer.
	/// </description>
	/// </item>
	/// <item>
	/// <description>For a stream-in operation, the RTF code contains data specifying the end of an RTF block.</description>
	/// </item>
	/// <item>
	/// <description>
	/// For a stream-in operation on a single-line edit control, the callback reads in an end-of-paragraph character (CR, LF, VT, LS, or PS).
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/nc-richedit-editstreamcallback EDITSTREAMCALLBACK Editstreamcallback;
	// DWORD Editstreamcallback( [in] DWORD_PTR dwCookie, [in] LPBYTE pbBuff, [in] LONG cb, [in] LONG *pcb ) {...}
	[PInvokeData("richedit.h", MSDNShortId = "NC:richedit.EDITSTREAMCALLBACK")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate uint EDITSTREAMCALLBACK([In] IntPtr dwCookie, [In] IntPtr pbBuff, int cb, ref int pcb);

	/// <summary>
	/// The <c>EditWordBreakProcEx</c> function is an application defined callback function used with the EM_SETWORDBREAKPROCEX message. It
	/// determines the character index of the word break or the character class and word-break flags of the characters in the specified text.
	/// The <c>EDITWORDBREAKPROCEX</c> type defines a pointer to this callback function. <c>EditWordBreakProcEx</c> is a placeholder for the
	/// application-defined function name.
	/// </summary>
	/// <param name="pchText">
	/// <para>Type: <c>char*</c></para>
	/// <para>
	/// Pointer to the text at the current position. If <c>code</c> specifies movement to the left, the text is in the elements
	/// <c>pchText</c> [â1] through <c>pchText</c> [- <c>cchText</c>], and <c>pchText</c>[0] is undefined. For all other actions, the text
	/// is in the elements <c>pchText</c>[0] through <c>pchText</c>[ <c>cchText</c> â1].
	/// </para>
	/// </param>
	/// <param name="cchText">
	/// <para>Type: <c>LONG</c></para>
	/// <para>Number of characters in the buffer in the direction specified by <c>code</c>.</para>
	/// </param>
	/// <param name="bCharSet">
	/// <para>Type: <c>BYTE</c></para>
	/// <para>Character set of the text.</para>
	/// </param>
	/// <param name="action"/>
	/// <returns>
	/// <para>Type: <c>LONG</c></para>
	/// <para>The function returns a value based on the <c>code</c> parameter.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><c>code parameter</c></description>
	/// <description>Return value</description>
	/// </item>
	/// <item>
	/// <description><c>WB_CLASSIFY</c></description>
	/// <description>Returns the character class and word-break flags of the character at the specified position.</description>
	/// </item>
	/// <item>
	/// <description><c>WB_ISDELIMITER</c></description>
	/// <description>
	/// Returns <c>TRUE</c> if the character at the specified position is a delimiter or <c>FALSE</c> if the character is not.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>All other values</c></description>
	/// <description>Returns the character index of the word break.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application must install the callback function by specifying the address of the callback function in an EM_SETWORDBREAKPROCEX message.
	/// </para>
	/// <para>
	/// For Microsoft Rich EditÂ 2.0 and later, Rich Edit no longer supports <c>EditWordBreakProcEx</c>. Users can send EM_SETWORDBREAKPROC
	/// to set EditWordBreakProc, which is now enhanced to support the passing of Unicode text.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/nc-richedit-editwordbreakprocex EDITWORDBREAKPROCEX Editwordbreakprocex;
	// LONG Editwordbreakprocex( [in] char *pchText, [in] LONG cchText, [in] BYTE bCharSet, INT action ) {...}
	[PInvokeData("richedit.h", MSDNShortId = "NC:richedit.EDITWORDBREAKPROCEX")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false, CharSet = CharSet.Ansi)]
	[Obsolete("For Microsoft Rich Edit 2.0 and later, Rich Edit no longer supports EditWordBreakProcEx. Users can send EM_SETWORDBREAKPROC to set EditWordBreakProc, which is now enhanced to support the passing of Unicode text.")]
	public delegate int EDITWORDBREAKPROCEX(string pchText, int cchText, byte bCharSet, int action);

	/// <summary>
	/// The <c>HyphenateProc</c> function is an applicationâdefined callback function used with the EM_SETHYPHENATEINFO message. It
	/// determines how hyphenation is done in a Microsoft Rich Edit control.
	/// </summary>
	/// <param name="pszWord">
	/// <para>Type: <c>WCHAR*</c></para>
	/// <para>Pointer to the word to hyphenate.</para>
	/// </param>
	/// <param name="langid">
	/// <para>Type: <c>LANGID</c></para>
	/// <para>Current language ID for the control.</para>
	/// </param>
	/// <param name="ichExceed">
	/// <para>Type: <c>LONG</c></para>
	/// <para>Index of the character in the passed string that exceeds the line width.</para>
	/// </param>
	/// <param name="phyphresult">
	/// <para>Type: <c>HYPHRESULT*</c></para>
	/// <para>Pointer to a HYPHRESULT structure that <c>HyphenateProc</c> fills in with the result of the hyphenation.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para><c>HyphenateProc</c> is a placeholder for the application-defined function name.</para>
	/// <para>
	/// An application must install the callback function by specifying the address of the callback function in an EM_SETHYPHENATEINFO message.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/nf-richedit-hyphenateproc void HyphenateProc( [in] WCHAR *pszWord, [in]
	// LANGID langid, [in] long ichExceed, [out] HYPHRESULT *phyphresult );
	[PInvokeData("richedit.h", MSDNShortId = "NF:richedit.HyphenateProc")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false, CharSet = CharSet.Unicode)]
	public delegate void HyphenateProc(string pszWord, LANGID langid, long ichExceed, out HYPHRESULT phyphresult);

	/// <summary>Specify 0 to disable automatic link detection, or one of the following values to enable various kinds of detection.</summary>
	[PInvokeData("richedit.h")]
	[Flags]
	public enum AURL : ushort
	{
		/// <summary>Windows 8: Recognize URLs that include the path.</summary>
		AURL_ENABLEURL = 1,

		/// <summary>Windows 8: Recognize email addresses.</summary>
		AURL_ENABLEEMAILADDR = 2,

		/// <summary>Windows 8: Recognize telephone numbers.</summary>
		AURL_ENABLETELNO = 4,

		/// <summary>Recognize URLs that contain East Asian characters.</summary>
		AURL_ENABLEEAURLS = 8,

		/// <summary>Windows 8: Recognize file names that have a leading drive specification, such as c:\temp.</summary>
		AURL_ENABLEDRIVELETTERS = 16,

		/// <summary>
		/// Windows 8: Disable recognition of domain names that contain labels with characters belonging to more than one of the following
		/// scripts: Latin, Greek, and Cyrillic.
		/// </summary>
		AURL_DISABLEMIXEDLGC = 32,
	}

	/// <summary>
	/// A set of flags that indicate the desired or current state of the effects flags. Obsolete bits are valid only for the bidirectional
	/// version of Rich Edit 1.0.
	/// </summary>
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._bidioptions")]
	[Flags]
	public enum BOE : ushort
	{
		/// <summary>
		/// If this flag is 1, context paragraph alignment is active. This feature is used only for plain-text controls. When active, the
		/// paragraph alignment is set to PFA_LEFT if the first strongly directional character is LTR, or PFA_RIGHT if the first strongly
		/// directional character is RTL. If the control has no strongly directional character, the alignment is chosen according to the
		/// directionality of the keyboard language when the control regains focus (default: 0).
		/// </summary>
		BOE_CONTEXTALIGNMENT = 0x0004,

		/// <summary>
		/// If this flag is 1, context paragraph directionality is active. This feature is used only for plain-text controls. When active,
		/// the paragraph directionality effect PFE_RTLPARA is set to 0 if the first strongly directional character is LTR, or 1 if the first
		/// strongly directional character is RTL. If the control has no strongly directional character, the directionality is chosen
		/// according to the directionality of the keyboard language when the control regains focus (default: 0).
		/// </summary>
		BOE_CONTEXTREADING = 0x0002,

		/// <summary>Windows 8: Force the rich edit control to recalculate the bidirectional information, and then redraw the control.</summary>
		BOE_FORCERECALC = 0x0008,

		/// <summary>
		/// Causes the plus and minus characters to be treated as neutral characters with no implied direction. Also causes the slash
		/// character to be treated as a common separator.
		/// </summary>
		BOE_LEGACYBIDICLASS = 0x0010,

		/// <summary>If this flag is 1, the characters !"#&amp;'()*+,-./:;&lt;=&gt; are treated as strong LTR characters (default: 0).</summary>
		BOE_NEUTRALOVERRIDE = 0x0001,

		/// <summary>Uses plain text layout (obsolete).</summary>
		BOE_PLAINTEXT = 0x0000,

		/// <summary>Default paragraph direction—implies alignment (obsolete).</summary>
		BOE_RTLDIR = 0x0000,

		/// <summary>
		/// If this flag is 1, the Unicode Bidi Algorithm (UBA) is used for rich-text controls. The UBA is always used for plain-text
		/// controls (default: 0).
		/// </summary>
		BOE_UNICODEBIDI = 0x0020,
	}

	/// <summary>A set of mask bits that determine which of the wEffects flags will be set to 1 or 0 by the rich edit control.</summary>
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._bidioptions")]
	[Flags]
	public enum BOM : ushort
	{
		/// <summary>The BOE_CONTEXTALIGNMENT value is valid.</summary>
		BOM_CONTEXTALIGNMENT = 0x0010,

		/// <summary>The BOE_CONTEXTREADING value is valid.</summary>
		BOM_CONTEXTREADING = 0x0008,

		/// <summary>The BOE_RTLDIR value is valid.</summary>
		BOM_DEFPARADIR = 0x0001,

		/// <summary>The BOE_LEGACYBIDICLASS value is valid.</summary>
		BOM_LEGACYBIDICLASS = 0x0040,

		/// <summary>The BOE_NEUTRALOVERRIDE value is valid.</summary>
		BOM_NEUTRALOVERRIDE = 0x0004,

		/// <summary>The BOE_PLAINTEXT value is valid. (obsolete).</summary>
		BOM_PLAINTEXT = 0x0002,

		/// <summary>The BOE_UNICODEBIDI value is valid.</summary>
		BOM_UNICODEBIDI = 0x0080,
	}

	/// <summary>
	/// A set of bit flags that specify character effects. Some of the flags are included only for compatibility with Microsoft Text Object
	/// Model (TOM) interfaces; the rich edit control stores the value but does not use it to display text.
	/// </summary>
	[Flags]
	public enum CFE : uint
	{
		/// <summary>
		/// Characters are all capital letters. The value does not affect the way the control displays the text. This value applies only to
		/// versions earlier than Microsoft Rich Edit 3.0.
		/// </summary>
		CFE_ALLCAPS = CFM.CFM_ALLCAPS,

		/// <summary>
		/// The background color is the return value of GetSysColor(COLOR_WINDOW). If this flag is set, crBackColor member is ignored.
		/// </summary>
		CFE_AUTOBACKCOLOR = CFM.CFM_BACKCOLOR,

		/// <summary>
		/// The text color is the return value of GetSysColor(COLOR_WINDOWTEXT). If this flag is set, the crTextColor member is ignored.
		/// </summary>
		CFE_AUTOCOLOR = 0x40000000,

		/// <summary>Characters are bold.</summary>
		CFE_BOLD = 0x00000001,

		/// <summary>Characters are displayed with a shadow that is offset by 3/4 point or one pixel, whichever is larger.</summary>
		CFE_DISABLED = CFM.CFM_DISABLED,

		/// <summary>Characters are embossed. The value does not affect how the control displays the text.</summary>
		CFE_EMBOSS = CFM.CFM_EMBOSS,

		/// <summary>
		/// The characters are less common members of a script. A font that supports a script should check if it has glyphs for such characters.
		/// </summary>
		CFE_EXTENDED = 0x02000000,

		/// <summary>
		/// Font is chosen by the rich edit control because the active font doesn’t support the characters. This process is called font binding.
		/// </summary>
		CFE_FONTBOUND = 0x00100000,

		/// <summary>For Microsoft Rich Edit 3.0 and later, characters are not displayed.</summary>
		CFE_HIDDEN = CFM.CFM_HIDDEN,

		/// <summary>Characters are displayed as imprinted characters. The value does not affect how the control displays the text.</summary>
		CFE_IMPRINT = CFM.CFM_IMPRINT,

		/// <summary>Characters are italic.</summary>
		CFE_ITALIC = 0x00000002,

		/// <summary>
		/// A rich edit control can send EN_LINK notification codes when it receives mouse messages while the mouse pointer is over text with
		/// the CFE_LINK effect.
		/// </summary>
		CFE_LINK = 0x00000020,

		/// <summary>Characters are part of a friendly name link.</summary>
		CFE_LINKPROTECTED = 0x00800000,

		/// <summary>Characters are in a math zone.</summary>
		CFE_MATH = 0x10000000,

		/// <summary>
		/// Characters do not participate in a math build up. For example, when applied to a /, the / will not be used to build up a fraction.
		/// </summary>
		CFE_MATHNOBUILDUP = 0x08000000,

		/// <summary>Characters are displayed as ordinary text within a math zone.</summary>
		CFE_MATHORDINARY = 0x20000000,

		/// <summary>Characters are displayed as outlined characters. The value does not affect how the control displays the text.</summary>
		CFE_OUTLINE = CFM.CFM_OUTLINE,

		/// <summary>Characters are protected; an attempt to modify them will cause an EN_PROTECTED notification code.</summary>
		CFE_PROTECTED = 0x00000010,

		/// <summary>Characters are marked as revised.</summary>
		CFE_REVISED = CFM.CFM_REVISED,

		/// <summary>Characters are displayed as shadowed characters. The value does not affect how the control displays the text.</summary>
		CFE_SHADOW = CFM.CFM_SHADOW,

		/// <summary>Characters are in small capital letters. The value does not affect how the control displays the text.</summary>
		CFE_SMALLCAPS = CFM.CFM_SMALLCAPS,

		/// <summary>Characters are struck out.</summary>
		CFE_STRIKEOUT = 0x00000008,

		/// <summary>
		/// Characters are subscript. The CFE_SUPERSCRIPT and CFE_SUBSCRIPT values are mutually exclusive. For both values, the control
		/// automatically calculates an offset and a smaller font size. Alternatively, you can use the yHeight and yOffset members to
		/// explicitly specify font size and offset for subscript and superscript characters.
		/// </summary>
		CFE_SUBSCRIPT = 0x00010000,

		/// <summary>Characters are superscript.</summary>
		CFE_SUPERSCRIPT = 0x00020000,

		/// <summary>Characters are underlined.</summary>
		CFE_UNDERLINE = 0x00000004,
	}

	/// <summary>
	/// Specifies the parts of the CHARFORMAT2 structure that contain valid information. The dwMask member can be a combination of the values
	/// from two sets of bit flags. One set indicates the structure members that are valid. Another set indicates the valid attributes in the
	/// dwEffects member.
	/// </summary>
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit.CHARFORMAT2A")]
	[Flags]
	public enum CFM : uint
	{
		/// <summary>The bAnimation member is valid.</summary>
		CFM_ANIMATION = 0x00040000,

		/// <summary>The crBackColor member is valid.</summary>
		CFM_BACKCOLOR = 0x04000000,

		/// <summary>The bCharSet member is valid.</summary>
		CFM_CHARSET = 0x08000000,

		/// <summary>The szFaceName member is valid.</summary>
		CFM_FACE = 0x20000000,

		/// <summary>The wKerning member is valid.</summary>
		CFM_KERNING = 0x00100000,

		/// <summary>The lcid member is valid.</summary>
		CFM_LCID = 0x02000000,

		/// <summary>The yOffset member is valid.</summary>
		CFM_OFFSET = 0x10000000,

		/// <summary>The bRevAuthor member is valid.</summary>
		CFM_REVAUTHOR = 0x00008000,

		/// <summary>The yHeight member is valid.</summary>
		CFM_SIZE = 0x80000000,

		/// <summary>The sSpacing member is valid.</summary>
		CFM_SPACING = 0x00200000,

		/// <summary>The sStyle member is valid.</summary>
		CFM_STYLE = 0x00080000,

		/// <summary>The bUnderlineType member is valid.</summary>
		CFM_UNDERLINETYPE = 0x00800000,

		/// <summary>The wWeight member is valid.</summary>
		CFM_WEIGHT = 0x00400000,

		/// <summary>Windows 8: A combination of the following values: CFM_EFFECTS | CFM_SIZE | CFM_FACE | CFM_OFFSET | CFM_CHARSET</summary>
		CFM_ALL = CFM_EFFECTS | CFM_SIZE | CFM_FACE | CFM_OFFSET | CFM_CHARSET,

		/// <summary>The CFE_BOLD value of the dwEffects member is valid.</summary>
		CFM_BOLD = 0x00000001,

		/// <summary>The crTextColor member and the CFE_AUTOCOLOR value of the dwEffects member are valid.</summary>
		CFM_COLOR = 0x40000000,

		/// <summary>
		/// Windows 8: A combination of the following values: CFM_BOLD | CFM_ITALIC | CFM_UNDERLINE | CFM_COLOR | CFM_STRIKEOUT |
		/// CFE_PROTECTED | CFM_LINK
		/// </summary>
		CFM_EFFECTS = CFM_BOLD | CFM_ITALIC | CFM_UNDERLINE | CFM_COLOR | CFM_STRIKEOUT | CFM_PROTECTED | CFM_LINK,

		/// <summary>The CFE_ITALIC value of the dwEffects member is valid.</summary>
		CFM_ITALIC = 0x00000002,

		/// <summary>The CFE_PROTECTED value of the dwEffects member is valid.</summary>
		CFM_PROTECTED = 0x00000010,

		/// <summary>The CFE_STRIKEOUT value of the dwEffects member is valid.</summary>
		CFM_STRIKEOUT = 0x00000008,

		/// <summary>The CFE_UNDERLINE value of the dwEffects member is valid.</summary>
		CFM_UNDERLINE = 0x00000004,

		/// <summary>
		/// A combination of the following values: CFM_ALL | CFM_EFFECTS2 | CFM_BACKCOLOR | CFM_LCID | CFM_UNDERLINETYPE | CFM_WEIGHT |
		/// CFM_REVAUTHOR | CFM_SPACING | CFM_KERNING | CFM_STYLE | CFM_ANIMATION | CFM_COOKIE
		/// </summary>
		CFM_ALL2 = CFM_ALL | CFM_EFFECTS2 | CFM_BACKCOLOR | CFM_LCID | CFM_UNDERLINETYPE | CFM_WEIGHT | CFM_REVAUTHOR | CFM_SPACING | CFM_KERNING | CFM_STYLE | CFM_ANIMATION | CFM_COOKIE,

		/// <summary>The CFE_ALLCAPS value is valid.</summary>
		CFM_ALLCAPS = 0x00000080,

		/// <summary>The dwCookie value is valid.</summary>
		CFM_COOKIE = 0x01000000,

		/// <summary>The CFE_DISABLED value is valid.</summary>
		CFM_DISABLED = 0x00002000,

		/// <summary>The CFE_EXTENDED value is valid.</summary>
		CFM_EXTENDED = 0x02000000,

		/// <summary>
		/// A combination of the following values: CFM_EFFECTS | CFM_DISABLED | CFM_SMALLCAPS | CFM_ALLCAPS | CFM_HIDDEN | CFM_OUTLINE |
		/// CFM_SHADOW | CFM_EMBOSS | CFM_IMPRINT | CFM_REVISED | CFM_SUBSCRIPT | CFM_SUPERSCRIPT | CFM_BACKCOLOR
		/// </summary>
		CFM_EFFECTS2 = CFM_EFFECTS | CFM_DISABLED | CFM_SMALLCAPS | CFM_ALLCAPS | CFM_HIDDEN | CFM_OUTLINE | CFM_SHADOW | CFM_EMBOSS | CFM_IMPRINT | CFM_REVISED | CFM_SUBSCRIPT | CFM_SUPERSCRIPT | CFM_BACKCOLOR,

		/// <summary>The CFE_EMBOSS value is valid.</summary>
		CFM_EMBOSS = 0x00000800,

		/// <summary>The CFE_FONTBOUND value is valid.</summary>
		CFM_FONTBOUND = 0x00100000,

		/// <summary>The CFE_HIDDEN value is valid.</summary>
		CFM_HIDDEN = 0x00000100,

		/// <summary>The CFE_IMPRINT value is valid.</summary>
		CFM_IMPRINT = 0x00001000,

		/// <summary>The CFE_LINK value is valid.</summary>
		CFM_LINK = 0x00000020,

		/// <summary>The CFE_LINKPROTECTED value is valid.</summary>
		CFM_LINKPROTECTED = 0x00800000,

		/// <summary>The CFE_MATH value is valid.</summary>
		CFM_MATH = 0x10000000,

		/// <summary>The CFE_MATHNOBUILDUP value is valid.</summary>
		CFM_MATHNOBUILDUP = 0x08000000,

		/// <summary>The CFE_MATHORDINARY value is valid.</summary>
		CFM_MATHORDINARY = 0x20000000,

		/// <summary>The CFE_OUTLINE value is valid.</summary>
		CFM_OUTLINE = 0x00000200,

		/// <summary>The CFE_REVISION value is valid.</summary>
		CFM_REVISED = 0x00004000,

		/// <summary>The CFE_SHADOW value is valid.</summary>
		CFM_SHADOW = 0x00000400,

		/// <summary>The CFE_SMALLCAPS value is valid.</summary>
		CFM_SMALLCAPS = 0x00000040,

		/// <summary>The CFE_SUBSCRIPT and CFE_SUPERSCRIPT values are valid.</summary>
		CFM_SUBSCRIPT = 0x00010000,

		/// <summary>The CFE_SUBSCRIPT and CFE_SUPERSCRIPT values are valid.</summary>
		CFM_SUPERSCRIPT = 0x00020000,
	}

	/// <summary>Specifies the underline type. To use this member, set the CFM_UNDERLINETYPE flag in the dwMask member.</summary>
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._charformat2w")]
	public enum CFU : byte
	{
		/// <summary>No underline. This is the default.</summary>
		CFU_UNDERLINENONE,

		/// <summary>Text underlined with a single solid line.</summary>
		CFU_UNDERLINE,

		/// <summary>RichEdit 4.1 and later: Underline words only. The rich edit control displays the text with a solid underline.</summary>
		CFU_UNDERLINEWORD,

		/// <summary>Text underlined with a double line. The rich edit control displays the text with a solid underline.</summary>
		CFU_UNDERLINEDOUBLE,

		/// <summary>
		/// Text underlined with a dotted line. For versions earlier than Microsoft Rich Edit 3.0, text is displayed with a solid underline.
		/// </summary>
		CFU_UNDERLINEDOTTED,

		/// <summary>Text underlined with dashes.</summary>
		CFU_UNDERLINEDASH,

		/// <summary>Text underlined with a dashed and dotted line.</summary>
		CFU_UNDERLINEDASHDOT,

		/// <summary>Text underlined with a dashed and doubled dotted line.</summary>
		CFU_UNDERLINEDASHDOTDOT,

		/// <summary>RichEdit 4.1 and later: Text underlined with a wavy line.</summary>
		CFU_UNDERLINEWAVE,

		/// <summary>Display as CFU_UNDERLINE.</summary>
		CFU_UNDERLINETHICK,

		/// <summary>Display as CFU_UNDERLINE.</summary>
		CFU_UNDERLINEHAIRLINE,

		/// <summary>Display as CFU_UNDERLINEWAVE.</summary>
		CFU_UNDERLINEDOUBLEWAVE,

		/// <summary>Display as CFU_UNDERLINEWAVE.</summary>
		CFU_UNDERLINEHEAVYWAVE,

		/// <summary>Display as CFU_UNDERLINEDASH.</summary>
		CFU_UNDERLINELONGDASH,

		/// <summary>Display as CFU_UNDERLINEDASH.</summary>
		CFU_UNDERLINETHICKDASH,

		/// <summary>Display as CFU_UNDERLINEDASHDOT.</summary>
		CFU_UNDERLINETHICKDASHDOT,

		/// <summary>Display as CFU_UNDERLINEDASHDOT.</summary>
		CFU_UNDERLINETHICKDASHDOTDOT,

		/// <summary>Display as CFU_UNDERLINEDOT.</summary>
		CFU_UNDERLINETHICKDOTTED,

		/// <summary>Display as CFU_UNDERLINEDASH.</summary>
		CFU_UNDERLINETHICKLONGDASH,

		/// <summary>For IME composition, fake a selection.</summary>
		CFU_INVERT = 0xFE,

		/// <summary>
		/// The structure maps CHARFORMAT's bit underline to CHARFORMAT2, (that is, it performs a CHARFORMAT type of underline on this text).
		/// </summary>
		CFU_CF1UNDERLINE = 0xFF,
	}

	/// <summary>IME mode bias value.</summary>
	[PInvokeData("richedit.h")]
	public enum CTFMODEBIAS
	{
		/// <summary>There is no mode bias.</summary>
		CTFMODEBIAS_DEFAULT = 0x0000,

		/// <summary>The bias is to a filename.</summary>
		CTFMODEBIAS_FILENAME = 0x0001,

		/// <summary>The bias is to a name.</summary>
		CTFMODEBIAS_NAME = 0x0002,

		/// <summary>The bias is to the reading.</summary>
		CTFMODEBIAS_READING = 0x0003,

		/// <summary>The bias is to a date or time.</summary>
		CTFMODEBIAS_DATETIME = 0x0004,

		/// <summary>The bias is to a conversation.</summary>
		CTFMODEBIAS_CONVERSATION = 0x0005,

		/// <summary>The bias is to a number.</summary>
		CTFMODEBIAS_NUMERIC = 0x0006,

		/// <summary>The bias is to hiragana strings.</summary>
		CTFMODEBIAS_HIRAGANA = 0x0007,

		/// <summary>The bias is to katakana strings.</summary>
		CTFMODEBIAS_KATAKANA = 0x0008,

		/// <summary>The bias is to Hangul characters.</summary>
		CTFMODEBIAS_HANGUL = 0x0009,

		/// <summary>The bias is to half-width katakana strings.</summary>
		CTFMODEBIAS_HALFWIDTHKATAKANA = 0x000A,

		/// <summary>The bias is to full-width alphanumeric characters.</summary>
		CTFMODEBIAS_FULLWIDTHALPHANUMERIC = 0x000B,

		/// <summary>The bias is to half-width alphanumeric characters.</summary>
		CTFMODEBIAS_HALFWIDTHALPHANUMERIC = 0x000C,
	}

	/// <summary>Indicates the state of the composition.</summary>
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._endcomposition")]
	public enum ECN : uint
	{
		/// <summary>The composition is complete.</summary>
		ECN_ENDCOMPOSITION = 1,

		/// <summary>There are new characters in the composition.</summary>
		ECN_NEWTEXT = 2,
	}

	/// <summary>Specifies the edit control options.</summary>
	[PInvokeData("richedit.h")]
	[Flags]
	public enum ECO : uint
	{
		/// <summary>Automatic selection of word on double-click.</summary>
		ECO_AUTOWORDSELECTION = 0x00000001,

		/// <summary>Same as ES_AUTOVSCROLL style.</summary>
		ECO_AUTOVSCROLL = 0x00000040,

		/// <summary>Same as ES_AUTOHSCROLL style.</summary>
		ECO_AUTOHSCROLL = 0x00000080,

		/// <summary>Same as ES_NOHIDESEL style.</summary>
		ECO_NOHIDESEL = 0x00000100,

		/// <summary>Same as ES_READONLY style.</summary>
		ECO_READONLY = 0x00000800,

		/// <summary>Same as ES_WANTRETURN style.</summary>
		ECO_WANTRETURN = 0x00001000,

		/// <summary>Same as ES_SAVESEL style.</summary>
		ECO_SAVESEL = 0x00008000,

		/// <summary>Same as ES_SELECTIONBAR style.</summary>
		ECO_SELECTIONBAR = 0x01000000,

		/// <summary>Same as ES_VERTICAL style. Available in Asian-language versions only.</summary>
		ECO_VERTICAL = 0x00400000,
	}

	/// <summary>Specifies the operation to perform on edit control options.</summary>
	[PInvokeData("richedit.h")]
	[Flags]
	public enum ECOOP : ushort
	{
		/// <summary>Sets the options to those specified by lParam.</summary>
		ECOOP_SET = 0x0001,

		/// <summary>Combines the specified options with the current options.</summary>
		ECOOP_OR = 0x0002,

		/// <summary>Retains only those current options that are also specified by lParam.</summary>
		ECOOP_AND = 0x0003,

		/// <summary>Logically exclusive OR the current options with those specified by lParam.</summary>
		ECOOP_XOR = 0x0004,
	}

	/// <summary>The current ellipsis mode.</summary>
	[PInvokeData("richedit.h")]
	public enum ELLIPSIS
	{
		/// <summary>No ellipsis is used.</summary>
		ELLIPSIS_NONE = 0x00000000,

		/// <summary>Ellipsis at the end (forced break)</summary>
		ELLIPSIS_END = 0x00000001,

		/// <summary>Ellipsis at the end (word break)</summary>
		ELLIPSIS_WORD = 0x00000003,
	}

	/// <summary>The event mask specifies which notification codes a rich edit control sends to its parent window.</summary>
	[PInvokeData("richedit.h")]
	[Flags]
	public enum ENM : uint
	{
		/// <summary>Sends EN_NONE notifications.</summary>
		ENM_NONE = 0x00000000,

		/// <summary>Sends EN_CHANGE notifications.</summary>
		ENM_CHANGE = 0x00000001,

		/// <summary>
		/// Sends EN_UPDATE notifications. Rich Edit 2.0 and later: this flag is ignored and the EN_UPDATE notifications are always sent.
		/// However, if Rich Edit 3.0 emulates Microsoft Rich Edit 1.0, you must use this flag to send EN_UPDATE notifications.
		/// </summary>
		ENM_UPDATE = 0x00000002,

		/// <summary>Sends EN_HSCROLL and EN_VSCROLL notifications.</summary>
		ENM_SCROLL = 0x00000004,

		/// <summary>Sends EN_MSGFILTER notifications for mouse wheel events.</summary>
		ENM_SCROLLEVENTS = 0x00000008,

		/// <summary>Sends EN_DRAGDROPDONE notifications.</summary>
		ENM_DRAGDROPDONE = 0x00000010,

		/// <summary>Sends EN_PARAGRAPHEXPANDED notifications.</summary>
		ENM_PARAGRAPHEXPANDED = 0x00000020,

		/// <summary>Sends EN_PAGECHANGE notifications.</summary>
		ENM_PAGECHANGE = 0x00000040,

		/// <summary>Sends EN_CLIPFORMAT notifications.</summary>
		ENM_CLIPFORMAT = 0x00000080,

		/// <summary>Sends EN_MSGFILTER notifications for keyboard events.</summary>
		ENM_KEYEVENTS = 0x00010000,

		/// <summary>Sends EN_MSGFILTER notifications for mouse events.</summary>
		ENM_MOUSEEVENTS = 0x00020000,

		/// <summary>Sends EN_REQUESTRESIZE notifications.</summary>
		ENM_REQUESTRESIZE = 0x00040000,

		/// <summary>Sends EN_SELCHANGE notifications.</summary>
		ENM_SELCHANGE = 0x00080000,

		/// <summary>Sends EN_DROPFILES notifications.</summary>
		ENM_DROPFILES = 0x00100000,

		/// <summary>Sends EN_PROTECTED notifications.</summary>
		ENM_PROTECTED = 0x00200000,

		/// <summary>Sends EN_CORRECTTEXT notifications.</summary>
		ENM_CORRECTTEXT = 0x00400000,

		/// <summary>
		/// Microsoft Rich Edit 1.0 only: Sends EN_IMECHANGE notifications when the IME conversion status has changed. Only for
		/// Asian-language versions of the operating system.
		/// </summary>
		ENM_IMECHANGE = 0x00800000,

		/// <summary>Sends EN_LANGCHANGE notifications.</summary>
		ENM_LANGCHANGE = 0x01000000,

		/// <summary>Sends EN_OBJECTPOSITIONS notifications.</summary>
		ENM_OBJECTPOSITIONS = 0x02000000,

		/// <summary>
		/// Rich Edit 2.0 and later: Sends EN_LINK notifications when the mouse pointer is over text that has the CFE_LINK and one of several
		/// mouse actions is performed.
		/// </summary>
		ENM_LINK = 0x04000000,

		/// <summary>Sends EN_LOWFIRTF notifications.</summary>
		ENM_LOWFIRTF = 0x08000000,

		/// <summary>Sends EN_STARTCOMPOSITION notifications.</summary>
		ENM_STARTCOMPOSITION = 0x10000000,

		/// <summary>Sends EN_ENDCOMPOSITION notifications.</summary>
		ENM_ENDCOMPOSITION = 0x20000000,

		/// <summary>Sends EN_GROUPTYPINGCHANGE notifications.</summary>
		ENM_GROUPTYPINGCHANGE = 0x40000000,

		/// <summary>Sends EN_HIDELINKTOOLTIP notifications.</summary>
		ENM_HIDELINKTOOLTIP = 0x80000000,
	}

	/// <summary>EM_GETPAGEROTATE wParam values for text layout.</summary>
	[PInvokeData("richedit.h")]
	public enum EPR
	{
		/// <summary>Text flows left to right and top to bottom</summary>
		EPR_0 = 0,

		/// <summary>Text flows top to bottom and right to left</summary>
		EPR_270 = 1,

		/// <summary>Text flows right to left and bottom to top</summary>
		EPR_180 = 2,

		/// <summary>Text flows bottom to top and left to right</summary>
		EPR_90 = 3,

		/// <summary>Text flows top to bottom and left to right (Mongolian text layout)</summary>
		EPR_SE = 5,
	}

	/// <summary>Flags for GETCONTEXTMENUEX.</summary>
	[Flags]
	public enum GCMF : uint
	{
		/// <summary>Get the context menu that is invoked by tapping a touch gripper handle.</summary>
		GCMF_GRIPPER = 0x00000001,

		/// <summary>Get the context menu for a spelling error.</summary>
		GCMF_SPELLING = 0x00000002,

		/// <summary>Get the context menu that is invoked by mouse.</summary>
		GCMF_MOUSEMENU = 0x00000004,

		/// <summary>Get the context menu that is invoked by touch.</summary>
		GCMF_TOUCHMENU = 0x00000008,
	}

	/// <summary>Value specifying a text operation.</summary>
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._gettextex")]
	[Flags]
	public enum GT : uint
	{
		/// <summary>
		/// All text is retrieved according to the following criteria:
		/// <list type="bullet">
		/// <item>
		/// <description>Carriage returns (U+000D) are not translated into CRLF (U+000D U+000A).</description>
		/// </item>
		/// <item>
		/// <description>Table and math-object structure characters are removed(see GT_RAWTEXT).</description>
		/// </item>
		/// <item>
		/// <description>Hidden text is included.</description>
		/// </item>
		/// <item>
		/// <description>List numbers are not included.</description>
		/// </item>
		/// </list>
		/// </summary>
		GT_DEFAULT = 0,

		/// <summary>When copying text, translate each CR into a CR/LF.</summary>
		GT_USECRLF = 1,

		/// <summary>Retrieve the text for the current selection.</summary>
		GT_SELECTION = 2,

		/// <summary>
		/// Text is retrieved exactly as it appears in memory. This includes special structure characters for table row and cell delimiters
		/// (see Remarks for EM_INSERTTABLE) as well as math object delimiters (start delimiter U+FDD0, argument delimiter U+FDEE, and end
		/// delimiter U+FDDF) and object markers (U+FFFC). This maintains character-position alignment between the retrieved text and the
		/// text in memory.
		/// </summary>
		GT_RAWTEXT = 4,

		/// <summary>Hidden text is not included in the retrieved text.</summary>
		GT_NOHIDDENTEXT = 8,
	}

	/// <summary>Value specifying the method to be used in determining the text length.</summary>
	[Flags]
	public enum GTL : uint
	{
		/// <summary>Returns the number of characters. This is the default.</summary>
		GTL_DEFAULT = 0,

		/// <summary>Computes the answer by using CR/LFs at the end of paragraphs.</summary>
		GTL_USECRLF = 1,

		/// <summary>
		/// Computes a precise answer. This approach could necessitate a conversion and thereby take longer. This flag cannot be used with
		/// the GTL_CLOSE flag. E_INVALIDARG will be returned if both are used.
		/// </summary>
		GTL_PRECISE = 2,

		/// <summary>
		/// Computes an approximate (close) answer. It is obtained quickly and can be used to set the buffer size. This flag cannot be used
		/// with the GTL_PRECISE flag. E_INVALIDARG will be returned if both are used.
		/// </summary>
		GTL_CLOSE = 4,

		/// <summary>
		/// Returns the number of characters. This flag cannot be used with the GTL_NUMBYTES flag. E_INVALIDARG will be returned if both are used.
		/// </summary>
		GTL_NUMCHARS = 8,

		/// <summary>
		/// Returns the number of bytes. This flag cannot be used with the GTL_NUMCHARS flag. E_INVALIDARG will be returned if both are used.
		/// </summary>
		GTL_NUMBYTES = 16,
	}

	/// <summary>The Input Method Editor (IME) mode for a rich edit control.</summary>
	[PInvokeData("richedit.h")]
	public enum ICM
	{
		/// <summary>IME is not open.</summary>
		ICM_NOTOPEN = 0x0000,

		/// <summary>True inline mode.</summary>
		ICM_LEVEL3 = 0x0001,

		/// <summary>Level 2.</summary>
		ICM_LEVEL2 = 0x0002,

		/// <summary>Level 2.5</summary>
		ICM_LEVEL2_5 = 0x0003,

		/// <summary>Special UI.</summary>
		ICM_LEVEL2_SUI = 0x0004,

		/// <summary/>
		ICM_CTF = 0x0005,
	}

	/// <summary>Type of composition string.</summary>
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._imecomptext")]
	[Flags]
	public enum ICT : uint
	{
		/// <summary>The final composed string.</summary>
		ICT_RESULTREADSTR = 0x0001,
	}

	/// <summary>The Input Method Editor (IME) options.</summary>
	[PInvokeData("richedit.h")]
	[Flags]
	public enum IMF : uint
	{
		/// <summary>Disables IME handling.</summary>
		IMF_FORCENONE = 0x0001,

		/// <summary>Enables the IME when the control receives the input focus.</summary>
		IMF_FORCEENABLE = 0x0002,

		/// <summary>Disables the IME when the control receives the input focus.</summary>
		IMF_FORCEDISABLE = 0x0004,

		/// <summary>Closes the IME status window when the control receives the input focus.</summary>
		IMF_CLOSESTATUSWINDOW = 0x0008,

		/// <summary>Note used in Rich Edit 2.0 and later.</summary>
		IMF_VERTICAL = 0x0020,

		/// <summary>Activates the IME when the control receives the input focus.</summary>
		IMF_FORCEACTIVE = 0x0040,

		/// <summary>Inactivates the IME when the control receives the input focus.</summary>
		IMF_FORCEINACTIVE = 0x0080,

		/// <summary>Restores the previous IME status when the control receives the input focus.</summary>
		IMF_FORCEREMEMBER = 0x0100,

		/// <summary>
		/// Specifies that the composition string will not be canceled or determined by focus changes. This allows an application to have
		/// separate composition strings on each rich edit control.
		/// </summary>
		IMF_MULTIPLEEDIT = 0x0400,
	}

	/// <summary>IME mode bias value.</summary>
	[PInvokeData("richedit.h")]
	[Flags]
	public enum IMF_SMODE : uint
	{
		/// <summary>Sets the IME mode bias to Name.</summary>
		IMF_SMODE_PLAURALCLAUSE = 0x0001,

		/// <summary>No bias.</summary>
		IMF_SMODE_NONE = 0x0002,
	}

	/// <summary>
	/// Contains values used to specify how to do hyphenation in a rich edit control. The HyphenateProc callback function uses this
	/// enumeration type.
	/// </summary>
	/// <remarks>Hyphenation rules are specific for each language; not all hyphenation types are valid for a given language.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ne-richedit-khyph typedef enum tagKHYPH { khyphNil, khyphNormal,
	// khyphAddBefore, khyphChangeBefore, khyphDeleteBefore, khyphChangeAfter, khyphDelAndChange } KHYPH;
	[PInvokeData("richedit.h", MSDNShortId = "NE:richedit.tagKHYPH")]
	public enum KHYPH
	{
		/// <summary>No hyphenation is allowed.</summary>
		khyphNil,

		/// <summary>Do not change any characters during hyphenation.</summary>
		khyphNormal,

		/// <summary>Add a letter before the hyphenation mark.</summary>
		khyphAddBefore,

		/// <summary>Change the letter before the hyphenation mark.</summary>
		khyphChangeBefore,

		/// <summary>Delete the letter before the hyphenation mark.</summary>
		khyphDeleteBefore,

		/// <summary>Change the letter after the hyphenation mark.</summary>
		khyphChangeAfter,

		/// <summary>
		/// <para>The two letters before the hyphenation mark are replaced by one character; see the</para>
		/// <para>chHyph</para>
		/// <para>member of</para>
		/// <para>HYPHRESULT</para>
		/// <para>.</para>
		/// </summary>
		khyphDelAndChange,
	}

	/// <summary>Operation that failed.</summary>
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._enoleopfailed")]
	public enum OLEOP
	{
		/// <summary>Indicates that IOleObject::DoVerb failed.</summary>
		OLEOP_DOVERB = 1
	}

	/// <summary>Paragraph alignment. To use this member, set the PFM_ALIGNMENT flag in the dwMask member.</summary>
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._paraformat")]
	[Flags]
	public enum PFA : ushort
	{
		/// <summary>Paragraphs are aligned with the left margin.</summary>
		PFA_LEFT = 1,

		/// <summary>Paragraphs are aligned with the right margin.</summary>
		PFA_RIGHT = 2,

		/// <summary>Paragraphs are centered.</summary>
		PFA_CENTER = 3,

		/// <summary>
		/// RichEdit 2.0:Paragraphs are justified. Rich edit controls earlier than RichEdit 3.0 display the text aligned with the left margin.
		/// </summary>
		PFA_JUSTIFY = 4,

		/// <summary>Paragraphs are justified by expanding the blanks alone.</summary>
		PFA_FULL_INTERWORD = 4,
	}

	/// <summary>
	/// A set of bit flags that specify paragraph effects. These flags are included only for compatibility with TOM interfaces; the rich edit
	/// control stores the value but does not use it to display the text.
	/// </summary>
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._paraformat")]
	[Flags]
	public enum PFE : ushort
	{
		/// <summary>Displays text using right-to-left reading order.</summary>
		PFE_RTLPARA = (ushort)(PFM.PFM_RTLPARA >> 16),

		/// <summary>No page break within the paragraph.</summary>
		PFE_KEEP = (ushort)(PFM.PFM_KEEP >> 16),

		/// <summary>No page break between this paragraph and the next.</summary>
		PFE_KEEPNEXT = (ushort)(PFM.PFM_KEEPNEXT >> 16),

		/// <summary>Inserts a page break before the selected paragraph.</summary>
		PFE_PAGEBREAKBEFORE = (ushort)(PFM.PFM_PAGEBREAKBEFORE >> 16),

		/// <summary>Disables line numbering (not implemented).</summary>
		PFE_NOLINENUMBER = (ushort)(PFM.PFM_NOLINENUMBER >> 16),

		/// <summary>Disables widow and orphan control for the selected paragraph.</summary>
		PFE_NOWIDOWCONTROL = (ushort)(PFM.PFM_NOWIDOWCONTROL >> 16),

		/// <summary>Disables automatic hyphenation.</summary>
		PFE_DONOTHYPHEN = (ushort)(PFM.PFM_DONOTHYPHEN >> 16),

		/// <summary>Displays paragraphs side by side (not implemented).</summary>
		PFE_SIDEBYSIDE = (ushort)(PFM.PFM_SIDEBYSIDE >> 16),

		/// <summary/>
		PFE_TEXTWRAPPINGBREAK = (ushort)(PFM.PFM_TEXTWRAPPINGBREAK >> 16),

		/// <summary/>
		PFE_COLLAPSED = (ushort)(PFM.PFM_COLLAPSED >> 16),

		/// <summary/>
		PFE_BOX = (ushort)(PFM.PFM_BOX >> 16),

		/// <summary>The paragraph is a table row.</summary>
		PFE_TABLE = (ushort)(PFM.PFM_TABLE >> 16),

		/// <summary>The paragraph is a start delimiter (U+FFF9 U+000D) or end delimiter (U+FFFB U+000D) of a row in a table.</summary>
		PFE_TABLEROWDELIMITER = (ushort)(PFM.PFM_TABLEROWDELIMITER >> 16),
	}

	/// <summary>
	/// Members containing valid information or attributes to set. This parameter can be none or a combination of the following values. If
	/// both PFM_STARTINDENT and PFM_OFFSETINDENT are specified, PFM_STARTINDENT takes precedence.
	/// </summary>
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._paraformat")]
	[Flags]
	public enum PFM : uint
	{
		/// <summary>
		/// The dxStartIndent member is valid and specifies the indentation from the left margin. If both PFM_STARTINDENT and
		/// PFM_OFFSETINDENT are specified, PFM_STARTINDENT takes precedence.
		/// </summary>
		PFM_STARTINDENT = 0x00000001,

		/// <summary>The dxRightIndent member is valid.</summary>
		PFM_RIGHTINDENT = 0x00000002,

		/// <summary>The dxOffset member is valid.</summary>
		PFM_OFFSET = 0x00000004,

		/// <summary>The wAlignment member is valid.</summary>
		PFM_ALIGNMENT = 0x00000008,

		/// <summary>The cTabStobs and rgxTabStops members are valid.</summary>
		PFM_TABSTOPS = 0x00000010,

		/// <summary>The wNumbering member is valid.</summary>
		PFM_NUMBERING = 0x00000020,

		/// <summary>
		/// The dxStartIndent member is valid. If you are setting the indentation, dxStartIndent specifies the amount to indent relative to
		/// the current indentation.
		/// </summary>
		PFM_OFFSETINDENT = 0x80000000,

		/// <summary>The dySpaceBefore member is valid.</summary>
		PFM_SPACEBEFORE = 0x00000040,

		/// <summary>The dySpaceAfter member is valid.</summary>
		PFM_SPACEAFTER = 0x00000080,

		/// <summary>The dyLineSpacing and bLineSpacingRule members are valid.</summary>
		PFM_LINESPACING = 0x00000100,

		/// <summary>The sStyle member is valid.</summary>
		PFM_STYLE = 0x00000400,

		/// <summary>The wBorderSpace, wBorderWidth, and wBorders members are valid.</summary>
		PFM_BORDER = 0x00000800,

		/// <summary>The wShadingWeight and wShadingStyle members are valid.</summary>
		PFM_SHADING = 0x00001000,

		/// <summary>The wNumberingStyle member is valid.</summary>
		PFM_NUMBERINGSTYLE = 0x00002000,

		/// <summary>The wNumberingTab member is valid.</summary>
		PFM_NUMBERINGTAB = 0x00004000,

		/// <summary>The wNumberingStart member is valid.</summary>
		PFM_NUMBERINGSTART = 0x00008000,

		/// <summary>Rich Edit 2.0: The wEffects member is valid</summary>
		PFM_RTLPARA = 0x00010000,

		/// <summary>The PFE_KEEP value is valid.</summary>
		PFM_KEEP = 0x00020000,

		/// <summary>The PFE_KEEPNEXT value is valid.</summary>
		PFM_KEEPNEXT = 0x00040000,

		/// <summary>The PFE_PAGEBREAKBEFORE value is valid.</summary>
		PFM_PAGEBREAKBEFORE = 0x00080000,

		/// <summary>The PFE_NOLINENUMBER value is valid.</summary>
		PFM_NOLINENUMBER = 0x00100000,

		/// <summary>The PFE_NOWIDOWCONTROL value is valid.</summary>
		PFM_NOWIDOWCONTROL = 0x00200000,

		/// <summary>The PFE_DONOTHYPHEN value is valid.</summary>
		PFM_DONOTHYPHEN = 0x00400000,

		/// <summary>The PFE_SIDEBYSIDE value is valid.</summary>
		PFM_SIDEBYSIDE = 0x00800000,

		/// <summary/>
		PFM_COLLAPSED = 0x01000000,

		/// <summary>The bOutlineLevel member is valid.</summary>
		PFM_OUTLINELEVEL = 0x02000000,

		/// <summary/>
		PFM_BOX = 0x04000000,

		/// <summary/>
		PFM_RESERVED2 = 0x08000000,

		/// <summary>The PFE_TABLEROWDELIMITER value is valid.</summary>
		PFM_TABLEROWDELIMITER = 0x10000000,

		/// <summary/>
		PFM_TEXTWRAPPINGBREAK = 0x20000000,

		/// <summary>The PFE_TABLE value is valid.</summary>
		PFM_TABLE = 0x40000000,

		/// <summary>
		/// A combination of the following values: PFM_STARTINDENT, PFM_RIGHTINDENT, PFM_OFFSET, PFM_ALIGNMENT, PFM_TABSTOPS, PFM_NUMBERING,
		/// PFM_OFFSETINDENT, and PFM_RTLPARA.
		/// </summary>
		PFM_ALL = PFM_STARTINDENT | PFM_RIGHTINDENT | PFM_OFFSET | PFM_ALIGNMENT | PFM_TABSTOPS | PFM_NUMBERING | PFM_OFFSETINDENT | PFM_RTLPARA,

		/// <summary>The PFM effects</summary>
		PFM_EFFECTS = PFM_RTLPARA | PFM_KEEP | PFM_KEEPNEXT | PFM_TABLE | PFM_PAGEBREAKBEFORE | PFM_NOLINENUMBER | PFM_NOWIDOWCONTROL | PFM_DONOTHYPHEN | PFM_SIDEBYSIDE | PFM_TABLE | PFM_TABLEROWDELIMITER,

		/// <summary>
		/// A combination of the following values: PFM_ALL, PFM_EFFECTS, PFM_SPACEBEFORE, PFM_SPACEAFTER, PFM_LINESPACING, PFM_STYLE,
		/// PFM_SHADING, PFM_BORDER, PFM_NUMBERINGTAB, PFM_NUMBERINGSTART, and PFM_NUMBERINGSTYLE.
		/// </summary>
		PFM_ALL2 = PFM_ALL | PFM_EFFECTS | PFM_SPACEBEFORE | PFM_SPACEAFTER | PFM_LINESPACING | PFM_STYLE | PFM_SHADING | PFM_BORDER | PFM_NUMBERINGTAB | PFM_NUMBERINGSTART | PFM_NUMBERINGSTYLE,
	}

	/// <summary>Options used for bulleted or numbered paragraphs. To use this member, set the PFM_NUMBERING flag in the dwMask member.</summary>
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._paraformat")]
	[Flags]
	public enum PFN : ushort
	{
		/// <summary>No paragraph numbering or bullets.</summary>
		PFN_NONE = 0,

		/// <summary>Insert a bullet at the beginning of each selected paragraph.</summary>
		PFN_BULLET = 1,

		/// <summary>Use Arabic numbers (0, 1, 2, and so on).</summary>
		PFN_ARABIC = 2,

		/// <summary>Use lowercase letters (a, b, c, and so on).</summary>
		PFN_LCLETTER = 3,

		/// <summary>Use uppercase letters (A, B, C, and so on).</summary>
		PFN_UCLETTER = 4,

		/// <summary>Use lowercase Roman letters (i, ii, iii, and so on).</summary>
		PFN_LCROMAN = 5,

		/// <summary>Use uppercase Roman letters (I, II, III, and so on).</summary>
		PFN_UCROMAN = 6,

		/// <summary>Uses a sequence of characters beginning with the Unicode character specified by the wNumberingStart member.</summary>
		PFN_USERDEFINED = 7,
	}

	/// <summary>Numbering style used with numbered paragraphs. Use this member in conjunction with the <c>wNumbering</c> member.</summary>
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit.PARAFORMAT2")]
	public enum PFNS : ushort
	{
		/// <summary>Follows the number with a right parenthesis.</summary>
		PFNS_PAREN = 0x000,

		/// <summary>Encloses the number in parentheses.</summary>
		PFNS_PARENS = 0x100,

		/// <summary>Follows the number with a period.</summary>
		PFNS_PERIOD = 0x200,

		/// <summary>Displays only the number.</summary>
		PFNS_PLAIN = 0x300,

		/// <summary>Continues a numbered list without applying the next number or bullet.</summary>
		PFNS_NONUMBER = 0x400,

		/// <summary>Starts a new number with <c>wNumberingStart</c>.</summary>
		PFNS_NEWNUMBER = 0x8000,
	}

	/// <summary>Specifies the punctuation type</summary>
	[PInvokeData("richedit.h")]
	public enum PUNC
	{
		/// <summary>Leading punctuation characters.</summary>
		PC_LEADING = 2,

		/// <summary>Following punctuation characters.</summary>
		PC_FOLLOWING = 1,

		/// <summary>Delimiter.</summary>
		PC_DELIMITER = 4,

		/// <summary>Not supported.</summary>
		PC_OVERFLOW = 3,
	}

	/// <summary>Messages specific to the rich edit control.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/controls/bumper-rich-edit-control-reference-messages
	[PInvokeData("richedit.h")]
	public enum RichEditMessage
	{
		/// <summary>
		/// Determines whether a rich edit control can paste a specified clipboard format.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the Clipboard Formats to try. To try any format currently on the clipboard, set this parameter to zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the clipboard format can be pasted, the return value is a nonzero value.</para>
		/// <para>If the clipboard format cannot be pasted, the return value is zero.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-canpaste
		[MsgParams(typeof(CLIPFORMAT), null, LResultType = typeof(CLIPFORMAT))]
		EM_CANPASTE = WindowMessage.WM_USER + 50,

		/// <summary>
		/// Displays a portion of the contents of a rich edit control, as previously formatted for a device using the <c>EM_FORMATRANGE</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A <c>RECT</c> structure specifying the display area of the device.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the operation succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the operation fails, the return value is <c>FALSE</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Text and Component Object Model (COM) objects are clipped by the rectangle. The application does not need to set the clipping region.
		/// </para>
		/// <para>
		/// Banding is the process by which a single page of output is generated using one or more separate rectangles, or bands. When all
		/// bands are placed on the page, a complete image results. This approach is often used by raster printers that do not have
		/// sufficient memory or ability to image a full page at one time. Banding devices include most dot matrix printers as well as some
		/// laser printers.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-displayband
		[MsgParams(null, typeof(RECT?), LResultType = typeof(BOOL))]
		EM_DISPLAYBAND = WindowMessage.WM_USER + 51,

		/// <summary>
		/// Retrieves the starting and ending character positions of the selection in a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A <c>CHARRANGE</c> structure that receives the selection range.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-exgetsel
		[MsgParams(null, typeof(CHARRANGE?), LResultType = null)]
		EM_EXGETSEL = WindowMessage.WM_USER + 52,

		/// <summary>
		/// Sets an upper limit to the amount of text the user can type or paste into a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Specifies the maximum amount of text that can be entered. If this parameter is zero, the default maximum is used, which is 64K
		/// characters. A COM object counts as a single character.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The text limit set by the <c>EM_EXLIMITTEXT</c> message does not limit the amount of text that you can stream into a rich edit
		/// control using the <c>EM_STREAMIN</c> message with lParam set to SF_TEXT. However, it does limit the amount of text that you can
		/// stream into a rich edit control using the <c>EM_STREAMIN</c> message with lParam set to SF_RTF.
		/// </para>
		/// <para>Before <c>EM_EXLIMITTEXT</c> is called, the default limit to the amount of text a user can enter is 32,767 characters.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-exlimittext
		[MsgParams(null, typeof(uint), LResultType = null)]
		EM_EXLIMITTEXT = WindowMessage.WM_USER + 53,

		/// <summary>
		/// Determines which line contains the specified character in a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Zero-based index of the character.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns the zero-based index of the line.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-exlinefromchar
		[MsgParams(null, typeof(uint), LResultType = typeof(uint))]
		EM_EXLINEFROMCHAR = WindowMessage.WM_USER + 54,

		/// <summary>
		/// Selects a range of characters or Component Object Model (COM) objects in a Microsoft Rich Edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A <c>CHARRANGE</c> structure that specifies the selection range.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the selection that is actually set.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-exsetsel
		[MsgParams(null, typeof(CHARRANGE?), LResultType = typeof(CHARRANGE?))]
		EM_EXSETSEL = WindowMessage.WM_USER + 55,

		/// <summary>
		/// Finds text within a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specify the parameters of the search operation. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>FR_DOWN</c></description>
		/// <description>
		/// Microsoft Rich Edit 2.0 and later: If set, the search is from the end of the current selection to the end of the document. If not
		/// set, the search is from the end of the current selection to the beginning of the document. Microsoft Rich Edit 1.0: The FR_DOWN
		/// flag is ignored. The search is always from the end of the current selection to the end of the document.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>FR_MATCHALEFHAMZA</c></description>
		/// <description>
		/// Microsoft Rich Edit 3.0 and later: If set, the search differentiates between Arabic alefs with different accents. If not set, all
		/// alefs are matched by the alef character alone.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>FR_MATCHDIAC</c></description>
		/// <description>
		/// Microsoft Rich Edit 3.0 and later: If set, the search operation considers Arabic and Hebrew diacritical marks. If not set,
		/// diacritical marks are ignored.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>FR_MATCHKASHIDA</c></description>
		/// <description>
		/// Microsoft Rich Edit 3.0 and later: If set, the search operation considers Arabic kashidas. If not set, kashidas are ignored.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>FR_MATCHWIDTH</c></description>
		/// <description>Windows 8: If set, single-byte and double-byte versions of the same character are considered to be not equal.</description>
		/// </item>
		/// <item>
		/// <description><c>FR_WHOLEWORD</c></description>
		/// <description>
		/// If set, the operation searches only for whole words that match the search string. If not set, the operation also searches for
		/// word fragments that match the search string.
		/// </description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>A <c>FINDTEXT</c> structure containing information about the find operation.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the target string is found, the return value is the zero-based position of the first character of the match. If the target is
		/// not found, the return value is -1.
		/// </para>
		/// </summary>
		/// <remarks>
		/// The <c>cpMin</c> member of <c>FINDTEXT.chrg</c> always specifies the starting-point of the search, and <c>cpMax</c> specifies the
		/// end point. When searching backward, <c>cpMin</c> must be equal to or greater than <c>cpMax</c>. When searching forward, a value
		/// of -1 in <c>cpMax</c> extends the search range to the end of the text.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-findtext
		[MsgParams(typeof(FR), typeof(FINDTEXT), LResultType = typeof(int))]
		EM_FINDTEXT = WindowMessage.WM_USER + 56,

		/// <summary>
		/// Formats a range of text in a rich edit control for a specific device.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Specifies whether to render the text. If this parameter is not zero, the text is rendered. Otherwise, the text is just measured.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A <c>FORMATRANGE</c> structure containing information about the output device, or <c>NULL</c> to free information cached by the control.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns the index of the last character that fits in the region, plus 1.</para>
		/// </summary>
		/// <remarks>
		/// <para>This message is typically used to format the content of rich edit control for an output device such as a printer.</para>
		/// <para>
		/// After using this message to format a range of text, it is important that you free cached information by sending
		/// <c>EM_FORMATRANGE</c> again, but with lParam set to <c>NULL</c>; otherwise, a memory leak will occur. Also, after using this
		/// message for one device, you must free cached information before using it again for a different device.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-formatrange
		[MsgParams(typeof(BOOL), typeof(FORMATRANGE?), LResultType = typeof(int))]
		EM_FORMATRANGE = WindowMessage.WM_USER + 57,

		/// <summary>
		/// Determines the character formatting in a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the range of text from which to retrieve formatting. It can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>SCF_DEFAULT</c></description>
		/// <description>The default character formatting.</description>
		/// </item>
		/// <item>
		/// <description><c>SCF_SELECTION</c></description>
		/// <description>The current selection's character formatting.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A <c>CHARFORMAT</c> structure that receives the attributes of the first character. The <c>dwMask</c> member specifies which
		/// attributes are consistent throughout the entire selection. For example, if the entire selection is either in italics or not in
		/// italics, CFM_ITALIC is set; if the selection is partly in italics and partly not, CFM_ITALIC is not set.
		/// </para>
		/// <para>
		/// Microsoft Rich Edit 2.0 and later: This parameter can be a pointer to a <c>CHARFORMAT2</c> structure, which is an extension of
		/// the <c>CHARFORMAT</c> structure. Before sending the <c>EM_GETCHARFORMAT</c> message, set the structure's <c>cbSize</c> member to
		/// indicate the version of the structure.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns the value of the <c>dwMask</c> member of the <c>CHARFORMAT</c> structure.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getcharformat
		[MsgParams(typeof(SCF), typeof(CHARFORMAT?), LResultType = typeof(CFM))]
		EM_GETCHARFORMAT = WindowMessage.WM_USER + 58,

		/// <summary>
		/// Retrieves the event mask for a rich edit control. The event mask specifies which notification codes the control sends to its
		/// parent window.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns the event mask for the rich edit control.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-geteventmask
		[MsgParams(LResultType = typeof(ENM))]
		EM_GETEVENTMASK = WindowMessage.WM_USER + 59,

		/// <summary>
		/// Retrieves an <c>IRichEditOle</c> object that a client can use to access a rich edit control's Component Object Model (COM) functionality.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a pointer that receives the <c>IRichEditOle</c> object. The control calls the <c>AddRef</c> method for the object
		/// before returning, so the calling application must call the <c>Release</c> method when it is done with the object.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the operation succeeds, the return value is a nonzero value.</para>
		/// <para>If the operation fails, the return value is zero.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getoleinterface
		[MsgParams(null, typeof(IntPtr?))]
		EM_GETOLEINTERFACE = WindowMessage.WM_USER + 60,

		/// <summary>
		/// Retrieves the paragraph formatting of the current selection in a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>PARAFORMAT</c> structure that receives the paragraph formatting attributes of the current selection.</para>
		/// <para>
		/// If more than one paragraph is selected, the structure receives the attributes of the first paragraph, and the <c>dwMask</c>
		/// member specifies which attributes are consistent throughout the entire selection.
		/// </para>
		/// <para>
		/// Microsoft Rich Edit 2.0 and later: This parameter can be a pointer to a <c>PARAFORMAT2</c> structure, which is an extension of
		/// the <c>PARAFORMAT</c> structure. Before sending the <c>EM_GETPARAFORMAT</c> message, set the structure's <c>cbSize</c> member to
		/// indicate the version of the structure.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns the value of the <c>dwMask</c> member of the <c>PARAFORMAT</c> structure.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getparaformat
		[MsgParams(null, typeof(PARAFORMAT2?), LResultType = typeof(PFM))]
		EM_GETPARAFORMAT = WindowMessage.WM_USER + 61,

		/// <summary>
		/// Retrieves the currently selected text in a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a buffer that receives the selected text. The calling application must ensure that the buffer is large enough to hold
		/// the selected text.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns the number of characters copied, not including the terminating null character.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getseltext
		[MsgParams(null, typeof(IntPtr), LResultType = typeof(uint))]
		EM_GETSELTEXT = WindowMessage.WM_USER + 62,

		/// <summary>
		/// The <c>EM_HIDESELECTION</c> message hides or shows the selection in a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Value specifying whether to hide or show the selection. If this parameter is zero, the selection is shown. Otherwise, the
		/// selection is hidden.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-hideselection
		[MsgParams(typeof(BOOL), null, LResultType = null)]
		EM_HIDESELECTION = WindowMessage.WM_USER + 63,

		/// <summary>
		/// Pastes a specific clipboard format in a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the Clipboard Formats.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>REPASTESPECIAL</c> structure or <c>NULL</c>. If an object is being pasted, the <c>REPASTESPECIAL</c> structure is
		/// filled in with the desired display aspect. If lParam is <c>NULL</c> or the <c>dwAspect</c> member is zero, the display aspect
		/// used will be the contents of the object descriptor.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-pastespecial
		[MsgParams(typeof(ushort), typeof(REPASTESPECIAL?), LResultType = null)]
		EM_PASTESPECIAL = WindowMessage.WM_USER + 64,

		/// <summary>
		/// Forces a rich edit control to send an <c>EN_REQUESTRESIZE</c> notification code to its parent window.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// </summary>
		/// <remarks>This message is useful during <c>WM_SIZE</c> processing for the parent of a bottomless rich edit control.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-requestresize
		[MsgParams(LResultType = null)]
		EM_REQUESTRESIZE = WindowMessage.WM_USER + 65,

		/// <summary>
		/// Determines the selection type for a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the selection is empty, the return value is SEL_EMPTY.</para>
		/// <para>If the selection is not empty, the return value is a set of flags containing one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>SEL_TEXT</c></description>
		/// <description>Text.</description>
		/// </item>
		/// <item>
		/// <description><c>SEL_OBJECT</c></description>
		/// <description>At least one COM object.</description>
		/// </item>
		/// <item>
		/// <description><c>SEL_MULTICHAR</c></description>
		/// <description>More than one character of text.</description>
		/// </item>
		/// <item>
		/// <description><c>SEL_MULTIOBJECT</c></description>
		/// <description>More than one COM object.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>This message is useful during <c>WM_SIZE</c> processing for the parent of a bottomless rich edit control.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-selectiontype
		[MsgParams(LResultType = typeof(SEL))]
		EM_SELECTIONTYPE = WindowMessage.WM_USER + 66,

		/// <summary>
		/// The <c>EM_SETBKGNDCOLOR</c> message sets the background color for a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Specifies whether to use the system color. If this parameter is a nonzero value, the background is set to the window background
		/// system color. Otherwise, the background is set to the specified color.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>A <c>COLORREF</c> structure specifying the color if wParam is zero. To generate a <c>COLORREF</c>, use the <c>RGB</c> macro.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns the original background color.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setbkgndcolor
		[MsgParams(typeof(BOOL), typeof(COLORREF), LResultType = typeof(COLORREF))]
		EM_SETBKGNDCOLOR = WindowMessage.WM_USER + 67,

		/// <summary>
		/// Sets character formatting in a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Character formatting that applies to the control. If this parameter is zero, the default character format is set. Otherwise, it
		/// can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>SCF_ALL</c></description>
		/// <description>Applies the formatting to all text in the control. Not valid with <c>SCF_SELECTION</c> or <c>SCF_WORD</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>SCF_ASSOCIATEFONT</c></description>
		/// <description>
		/// <c>RichEdit 4.1:</c> Associates a font to a given script, thus changing the default font for that script. To specify the font,
		/// use the following members of <c>CHARFORMAT2</c>: <c>yHeight</c>, <c>bCharSet</c>, <c>bPitchAndFamily</c>, <c>szFaceName</c>, and <c>lcid</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SCF_ASSOCIATEFONT2</c></description>
		/// <description>
		/// <c>RichEdit 4.1:</c> Associates a surrogate (plane-2) font to a given script, thus changing the default font for that script. To
		/// specify the font, use the following members of <c>CHARFORMAT2</c>: <c>yHeight</c>, <c>bCharSet</c>, <c>bPitchAndFamily</c>,
		/// <c>szFaceName</c>, and <c>lcid</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SCF_CHARREPFROMLCID</c></description>
		/// <description>Gets the character repertoire from the LCID.</description>
		/// </item>
		/// <item>
		/// <description><c>SCF_DEFAULT</c></description>
		/// <description><c>RichEdit 4.1:</c> Sets the default font for the control.</description>
		/// </item>
		/// <item>
		/// <description><c>SPF_DONTSETDEFAULT</c></description>
		/// <description>Prevents setting the default paragraph format when the rich edit control is empty.</description>
		/// </item>
		/// <item>
		/// <description><c>SCF_NOKBUPDATE</c></description>
		/// <description>
		/// <c>RichEdit 4.1:</c> Prevents keyboard switching to match the font. For example, if an Arabic font is set, normally the automatic
		/// keyboard feature for Bidi languages changes the keyboard to an Arabic keyboard.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SCF_SELECTION</c></description>
		/// <description>
		/// Applies the formatting to the current selection. If the selection is empty, the character formatting is applied to the insertion
		/// point, and the new character format is in effect only until the insertion point changes.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SPF_SETDEFAULT</c></description>
		/// <description>Sets the default paragraph formatting attributes.</description>
		/// </item>
		/// <item>
		/// <description><c>SCF_SMARTFONT</c></description>
		/// <description>Apply the font only if it can handle script.</description>
		/// </item>
		/// <item>
		/// <description><c>SCF_USEUIRULES</c></description>
		/// <description>
		/// <c>RichEdit 4.1:</c> Used with <c>SCF_SELECTION</c>. Indicates that format came from a toolbar or other UI tool, so UI formatting
		/// rules should be used instead of literal formatting.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SCF_WORD</c></description>
		/// <description>
		/// Applies the formatting to the selected word or words. If the selection is empty but the insertion point is inside a word, the
		/// formatting is applied to the word. The <c>SCF_WORD</c> value must be used in conjunction with the <c>SCF_SELECTION</c> value.
		/// </description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>CHARFORMAT</c> structure specifying the character formatting to use. Only the formatting attributes specified by
		/// the <c>dwMask</c> member are changed.
		/// </para>
		/// <para>
		/// Microsoft Rich Edit 2.0 and later: This parameter can be a pointer to a <c>CHARFORMAT2</c> structure, which is an extension of
		/// the <c>CHARFORMAT</c> structure. Before sending the <c>EM_SETCHARFORMAT</c> message, set the structure's <c>cbSize</c> member to
		/// or indicate which version of the structure is being used.
		/// </para>
		/// <para>
		/// The <c>szFaceName</c> and <c>bCharSet</c> members may be overruled when invalid for characters, for example: Arial on kanji characters.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the operation succeeds, the return value is a nonzero value.</para>
		/// <para>If the operation fails, the return value is zero.</para>
		/// </summary>
		/// <remarks>
		/// If this message is sent more than once with the same parameters, the effect on the text is toggled. That is, sending the message
		/// once produces the effect, sending the message twice cancels the effect, and so forth.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setcharformat
		[MsgParams(typeof(SCF), typeof(CHARFORMAT2?))]
		EM_SETCHARFORMAT = WindowMessage.WM_USER + 68,

		/// <summary>
		/// Sets the event mask for a rich edit control. The event mask specifies which notification codes the control sends to its parent window.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>New event mask for the rich edit control. For a list of event masks, see <c>Rich Edit Control Event Mask Flags</c>.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns the previous event mask.</para>
		/// </summary>
		/// <remarks>The default event mask (before any is set) is ENM_NONE.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-seteventmask
		[MsgParams(null, typeof(ENM), LResultType = typeof(ENM))]
		EM_SETEVENTMASK = WindowMessage.WM_USER + 69,

		/// <summary>
		/// Gives a rich edit control an <c>IRichEditOleCallback</c> object that the control uses to get OLE-related resources and
		/// information from the client.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>IRichEditOleCallback</c> object. The control calls the <c>AddRef</c> method for the object before returning.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the operation succeeds, the return value is a nonzero value.</para>
		/// <para>If the operation fails, the return value is zero.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setolecallback
		[MsgParams(null, typeof(IRichEditOleCallback))]
		EM_SETOLECALLBACK = WindowMessage.WM_USER + 70,

		/// <summary>
		/// Sets the paragraph formatting for the current selection in a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>PARAFORMAT</c> structure specifying the new paragraph formatting attributes. Only the attributes specified by the
		/// <c>dwMask</c> member are changed.
		/// </para>
		/// <para>
		/// Microsoft Rich Edit 2.0 and later: This parameter can be a pointer to a <c>PARAFORMAT2</c> structure, which is an extension of
		/// the <c>PARAFORMAT</c> structure. Before sending the <c>EM_SETPARAFORMAT</c> message, set the structure's <c>cbSize</c> member to
		/// indicate the version of the structure.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the operation succeeds, the return value is a nonzero value.</para>
		/// <para>If the operation fails, the return value is zero.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setparaformat
		[MsgParams(null, typeof(PARAFORMAT2?))]
		EM_SETPARAFORMAT = WindowMessage.WM_USER + 71,

		/// <summary>
		/// Sets the target device and line width used for "what you see is what you get" (WYSIWYG) formatting in a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>HDC for the target device.</para>
		/// <para><em>lParam</em></para>
		/// <para>Line width to use for formatting.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is zero if the operation fails, or nonzero if it succeeds.</para>
		/// </summary>
		/// <remarks>
		/// <para>The HDC for the default printer can be obtained as follows.</para>
		/// <para>If lParam is zero, no line breaks are created.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-settargetdevice
		[MsgParams(typeof(HDC), typeof(int))]
		EM_SETTARGETDEVICE = WindowMessage.WM_USER + 72,

		/// <summary>
		/// Replaces the contents of a rich edit control with a stream of data provided by an application defined EditStreamCallback callback function.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the data format and replacement options. This value must be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>SF_RTF</c></description>
		/// <description>RTF</description>
		/// </item>
		/// <item>
		/// <description><c>SF_TEXT</c></description>
		/// <description>Text</description>
		/// </item>
		/// </list>
		/// <para>In addition, you can specify the following flags.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>SFF_PLAINRTF</c></description>
		/// <description>
		/// If specified, only keywords common to all languages are streamed in. Language-specific RTF keywords in the stream are ignored. If
		/// not specified, all keywords are streamed in. You can combine this flag with the <c>SF_RTF</c> flag.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SFF_SELECTION</c></description>
		/// <description>
		/// If specified, the data stream replaces the contents of the current selection. If not specified, the data stream replaces the
		/// entire contents of the control. You can combine this flag with the <c>SF_TEXT</c> or <c>SF_RTF</c> flags.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SF_UNICODE</c></description>
		/// <description>
		/// <c>Microsoft Rich Edit 2.0 and later:</c> Indicates Unicode text. You can combine this flag with the <c>SF_TEXT</c> flag.
		/// </description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>EDITSTREAM</c> structure. On input, the <c>pfnCallback</c> member of this structure must point to an application
		/// defined EditStreamCallback function. On output, the <c>dwError</c> member can contain a nonzero error code if an error occurred.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns the number of characters read.</para>
		/// </summary>
		/// <remarks>
		/// When you send an <c>EM_STREAMIN</c> message, the rich edit control makes repeated calls to the EditStreamCallback function
		/// specified by the <c>pfnCallback</c> member of the <c>EDITSTREAM</c> structure. Each time the callback function is called, it
		/// fills a buffer with data to read into the control. This continues until the callback function indicates that the stream-in
		/// operation has been completed or an error occurs.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-streamin
		[MsgParams(typeof(SF), typeof(EDITSTREAM?))]
		EM_STREAMIN = WindowMessage.WM_USER + 73,

		/// <summary>
		/// Causes a rich edit control to pass its contents to an application defined EditStreamCallback callback function. The callback
		/// function can then write the stream of data to a file or any other location that it chooses.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the data format and replacement options.</para>
		/// <para>This value must be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>SF_RTF</c></description>
		/// <description>RTF.</description>
		/// </item>
		/// <item>
		/// <description><c>SF_RTFNOOBJS</c></description>
		/// <description>RTF with spaces in place of COM objects.</description>
		/// </item>
		/// <item>
		/// <description><c>SF_TEXT</c></description>
		/// <description>Text with spaces in place of COM objects.</description>
		/// </item>
		/// <item>
		/// <description><c>SF_TEXTIZED</c></description>
		/// <description>Text with a text representation of COM objects.</description>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>SF_RTFNOOBJS</c> option is useful if an application stores COM objects itself, as RTF representation of COM objects is not
		/// very compact. The control word, \objattph, followed by a space denotes the object position.
		/// </para>
		/// <para>In addition, you can specify the following flags.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>SFF_PLAINRTF</c></description>
		/// <description>
		/// If specified, the rich edit control streams out only the keywords common to all languages, ignoring language-specific keywords.
		/// If not specified, the rich edit control streams out all keywords. You can combine this flag with the <c>SF_RTF</c> or
		/// <c>SF_RTFNOOBJS</c> flag.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SFF_SELECTION</c></description>
		/// <description>
		/// If specified, the rich edit control streams out only the contents of the current selection. If not specified, the control streams
		/// out the entire contents. You can combine this flag with any of data format values.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SF_UNICODE</c></description>
		/// <description>
		/// <c>Microsoft Rich Edit 2.0 and later:</c> Indicates Unicode text. You can combine this flag with the <c>SF_TEXT</c> flag.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SF_USECODEPAGE</c></description>
		/// <description>
		/// <c>Rich Edit 3.0 and later:</c> Generates UTF-8 RTF as well as text using other code pages. The code page is set in the high word
		/// of <c>wParam</c>. For example, for UTF-8 RTF, set <c>wParam</c> to (CP_UTF8 &lt;&lt; 16) | SF_USECODEPAGE | SF_RTF.
		/// </description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>EDITSTREAM</c> structure. On input, the <c>pfnCallback</c> member of this structure must point to an application
		/// defined EditStreamCallback function. On output, the <c>dwError</c> member can contain a nonzero error code if an error occurred.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns the number of characters written to the data stream.</para>
		/// </summary>
		/// <remarks>
		/// When you send an <c>EM_STREAMOUT</c> message, the rich edit control makes repeated calls to the EditStreamCallback function
		/// specified by the <c>pfnCallback</c> member of the <c>EDITSTREAM</c> structure. Each time it calls the callback function, the
		/// control passes a buffer containing a portion of the contents of the control. This process continues until the control has passed
		/// all its contents to the callback function, or until an error occurs.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-streamout
		[MsgParams(typeof(SF), typeof(EDITSTREAM?))]
		EM_STREAMOUT = WindowMessage.WM_USER + 74,

		/// <summary>
		/// Retrieves a specified range of characters from a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>TEXTRANGE</c> structure that specifies the range of characters to retrieve and a buffer to copy the characters to.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The message returns the number of characters copied, not including the terminating null character.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-gettextrange
		[MsgParams(null, typeof(TEXTRANGE?))]
		EM_GETTEXTRANGE = WindowMessage.WM_USER + 75,

		/// <summary>
		/// Finds the next word break before or after the specified character position or retrieves information about the character at that position.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the find operation. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>WB_CLASSIFY</c></description>
		/// <description>Returns the character class and word-break flags of the character at the specified position.</description>
		/// </item>
		/// <item>
		/// <description><c>WB_ISDELIMITER</c></description>
		/// <description>Returns <c>TRUE</c> if the character at the specified position is a delimiter, or <c>FALSE</c> otherwise.</description>
		/// </item>
		/// <item>
		/// <description><c>WB_LEFT</c></description>
		/// <description>Finds the nearest character before the specified position that begins a word.</description>
		/// </item>
		/// <item>
		/// <description><c>WB_LEFTBREAK</c></description>
		/// <description>Finds the next word end before the specified position. This value is the same as WB_PREVBREAK.</description>
		/// </item>
		/// <item>
		/// <description><c>WB_MOVEWORDLEFT</c></description>
		/// <description>
		/// Finds the next character that begins a word before the specified position. This value is used during CTRL+LEFT ARROW key
		/// processing. This value is the similar to WB_MOVEWORDPREV. See Remarks for more information.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>WB_MOVEWORDRIGHT</c></description>
		/// <description>
		/// Finds the next character that begins a word after the specified position. This value is used during CTRL+right key processing.
		/// This value is similar to WB_MOVEWORDNEXT. See Remarks for more information.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>WB_RIGHT</c></description>
		/// <description>Finds the next character that begins a word after the specified position.</description>
		/// </item>
		/// <item>
		/// <description><c>WB_RIGHTBREAK</c></description>
		/// <description>Finds the next end-of-word delimiter after the specified position. This value is the same as WB_NEXTBREAK.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Zero-based character starting position.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The message returns a value based on the wParam parameter.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>wParam</c></description>
		/// <description>Return Value</description>
		/// </item>
		/// <item>
		/// <description><c>WB_CLASSIFY</c></description>
		/// <description>Returns the character class and word-break flags of the character at the specified position.</description>
		/// </item>
		/// <item>
		/// <description><c>WB_ISDELIMITER</c></description>
		/// <description>Returns <c>TRUE</c> if the character at the specified position is a delimiter; otherwise it returns <c>FALSE</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>Others</c></description>
		/// <description>Returns the character index of the word break.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If wParam is WB_LEFT and WB_RIGHT, the word-break procedure finds word breaks only after delimiters. This matches the
		/// functionality of an edit control. If wParam is WB_MOVEWORDLEFT or WB_MOVEWORDRIGHT, the word-break procedure also compares
		/// character classes and word-break flags.
		/// </para>
		/// <para>For information about character classes and word-break flags, see Word and Line Breaks.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-findwordbreak
		[MsgParams(typeof(WB), typeof(uint))]
		EM_FINDWORDBREAK = WindowMessage.WM_USER + 76,

		/// <summary>
		/// Sets the options for a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the operation, which can be one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>ECOOP_SET</c></description>
		/// <description>Sets the options to those specified by <c>lParam</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>ECOOP_OR</c></description>
		/// <description>Combines the specified options with the current options.</description>
		/// </item>
		/// <item>
		/// <description><c>ECOOP_AND</c></description>
		/// <description>Retains only those current options that are also specified by <c>lParam</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>ECOOP_XOR</c></description>
		/// <description>Logically exclusive OR the current options with those specified by <c>lParam</c>.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Specifies one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>ECO_AUTOWORDSELECTION</c></description>
		/// <description>Automatic selection of word on double-click.</description>
		/// </item>
		/// <item>
		/// <description><c>ECO_AUTOVSCROLL</c></description>
		/// <description>Same as <c>ES_AUTOVSCROLL</c> style.</description>
		/// </item>
		/// <item>
		/// <description><c>ECO_AUTOHSCROLL</c></description>
		/// <description>Same as <c>ES_AUTOHSCROLL</c> style.</description>
		/// </item>
		/// <item>
		/// <description><c>ECO_NOHIDESEL</c></description>
		/// <description>Same as <c>ES_NOHIDESEL</c> style.</description>
		/// </item>
		/// <item>
		/// <description><c>ECO_READONLY</c></description>
		/// <description>Same as <c>ES_READONLY</c> style.</description>
		/// </item>
		/// <item>
		/// <description><c>ECO_WANTRETURN</c></description>
		/// <description>Same as <c>ES_WANTRETURN</c> style.</description>
		/// </item>
		/// <item>
		/// <description><c>ECO_SELECTIONBAR</c></description>
		/// <description>Same as <c>ES_SELECTIONBAR</c> style.</description>
		/// </item>
		/// <item>
		/// <description><c>ECO_VERTICAL</c></description>
		/// <description>Same as <c>ES_VERTICAL</c> style. Available in Asian-language versions only.</description>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns the current options of the edit control.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setoptions
		[MsgParams(typeof(ECOOP), typeof(ECO), LResultType = typeof(ECO))]
		EM_SETOPTIONS = WindowMessage.WM_USER + 77,

		/// <summary>
		/// Retrieves rich edit control options.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns a combination of the current option flag values described in the <c>EM_SETOPTIONS</c> message.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getoptions
		[MsgParams(LResultType = typeof(ECO))]
		EM_GETOPTIONS = WindowMessage.WM_USER + 78,

		/// <summary>
		/// Finds text within a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the behavior of the search operation. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>FR_DOWN</c></description>
		/// <description>
		/// Microsoft Rich Edit 2.0 and later: If set, the search is forward from <c>FINDTEXTEX.chrg.cpMin</c>; if not set, the search is
		/// backward from <c>FINDTEXTEX.chrg.cpMin</c>. Microsoft Rich Edit 1.0: The FR_DOWN flag is ignored. The search is always forward.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>FR_MATCHALEFHAMZA</c></description>
		/// <description>
		/// Microsoft Rich Edit 3.0 and later: If set, the search differentiates between Arabic and Hebrew alefs with different accents. If
		/// not set, all alefs are matched by the alef character alone.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>FR_MATCHCASE</c></description>
		/// <description>If set, the search operation is case-sensitive. If not set, the search operation is case-insensitive.</description>
		/// </item>
		/// <item>
		/// <description><c>FR_MATCHDIAC</c></description>
		/// <description>
		/// Microsoft Rich Edit 3.0 and later: If set, the search operation considers Arabic and Hebrew diacritical marks. If not set,
		/// diacritical marks are ignored.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>FR_MATCHKASHIDA</c></description>
		/// <description>
		/// Microsoft Rich Edit 3.0 and later: If set, the search operation considers Arabic and Hebrew kashidas. If not set, kashidas are ignored.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>FR_WHOLEWORD</c></description>
		/// <description>
		/// If set, the operation searches only for whole words that match the search string. If not set, the operation also searches for
		/// word fragments that match the search string.
		/// </description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>A <c>FINDTEXTEX</c> structure containing information about the find operation.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the target string is found, the return value is the zero-based position of the first character of the match. If the target is
		/// not found, the return value is -1.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>Use this message to find ANSI strings. For Unicode, use <c>EM_FINDTEXTEXW</c>.</para>
		/// <para>
		/// The <c>cpMin</c> member of <c>FINDTEXTEX.chrg</c> always specifies the starting-point of the search, and <c>cpMax</c> specifies
		/// the end point. When searching backward, <c>cpMin</c> must be equal to or greater than <c>cpMax</c>. When searching forward, a
		/// value of -1 in <c>cpMax</c> extends the search range to the end of the text.
		/// </para>
		/// <para>
		/// If the search operation finds a match, the <c>chrgText</c> member of the <c>FINDTEXTEX</c> structure returns the range of
		/// character positions that contains the matching text.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-findtextex
		[MsgParams(typeof(FR), typeof(FINDTEXTEX?))]
		EM_FINDTEXTEX = WindowMessage.WM_USER + 79,

		/// <summary>
		/// Retrieves the address of the currently registered extended word-break procedure for a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The message returns the address of the current procedure.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getwordbreakprocex
		[MsgParams(LResultType = typeof(EDITWORDBREAKPROCEX))]
		EM_GETWORDBREAKPROCEX = WindowMessage.WM_USER + 80,

		/// <summary>
		/// Sets the extended word-break procedure for a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an EditWordBreakProcEx function, or <c>NULL</c> to use the default procedure.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns the address of the previous extended word-break procedure.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setwordbreakprocex
		[MsgParams(null, typeof(EDITWORDBREAKPROCEX), LResultType = typeof(EDITWORDBREAKPROCEX))]
		EM_SETWORDBREAKPROCEX = WindowMessage.WM_USER + 81,

		/// <summary>
		/// Sets the maximum number of actions that can stored in the undo queue of a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the maximum number of actions that can be stored in the undo queue.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the new maximum number of undo actions for the rich edit control. This value may be less than wParam if
		/// memory is limited.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// By default, the maximum number of actions in the undo queue is 100. If you increase this number, there must be enough available
		/// memory to accommodate the new number. For better performance, set the limit to the smallest possible value.
		/// </para>
		/// <para>Setting the limit to zero disables the <c>Undo</c> feature.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setundolimit
		[MsgParams(typeof(uint), null, LResultType = typeof(uint))]
		EM_SETUNDOLIMIT = WindowMessage.WM_USER + 82,

		/// <summary>
		/// Sends an <c>EM_REDO</c> message to a rich edit control to redo the next action in the control's redo queue.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the <c>Redo</c> operation succeeds, the return value is a nonzero value.</para>
		/// <para>If the <c>Redo</c> operation fails, the return value is zero.</para>
		/// </summary>
		/// <remarks>To determine whether there are any actions in the control's redo queue, send the <c>EM_CANREDO</c> message.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-redo
		[MsgParams()]
		EM_REDO = WindowMessage.WM_USER + 84,

		/// <summary>
		/// Determines whether there are any actions in the control redo queue.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If there are actions in the control redo queue, the return value is a nonzero value.</para>
		/// <para>If the redo queue is empty, the return value is zero.</para>
		/// </summary>
		/// <remarks>To redo the most recent undo operation, send the <c>EM_REDO</c> message.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-canredo
		[MsgParams()]
		EM_CANREDO = WindowMessage.WM_USER + 85,

		/// <summary>
		/// <para>Microsoft Rich Edit 2.0 and later: Retrieves the type of the next undo action, if any.</para>
		/// <para>Microsoft Rich Edit 1.0: This message is not supported.</para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If there is an undo action, the value returned is an <c>UNDONAMEID</c> enumeration value that indicates the type of the next
		/// action in the control's undo queue.
		/// </para>
		/// <para>If there are no actions that can be undone or the type of the next undo action is unknown, the return value is zero.</para>
		/// </summary>
		/// <remarks>
		/// The types of actions that can be undone or redone include typing, delete, drag, drop, cut, and paste operations. This information
		/// can be useful for applications that provide an extended user interface for undo and redo operations, such as a drop-down list box
		/// of actions that can be undone.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getundoname
		[MsgParams(LResultType = typeof(UNDONAMEID))]
		EM_GETUNDONAME = WindowMessage.WM_USER + 86,

		/// <summary>
		/// Retrieves the type of the next action, if any, in the rich edit control's redo queue.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the redo queue for the control is not empty, the value returned is an <c>UNDONAMEID</c> enumeration value that indicates the
		/// type of the next action in the control's redo queue.
		/// </para>
		/// <para>If there are no redoable actions or the type of the next redoable action is unknown, the return value is zero.</para>
		/// </summary>
		/// <remarks>
		/// The types of actions that can be undone or redone include typing, delete, drag-drop, cut, and paste operations. This information
		/// can be useful for applications that provide an extended user interface for undo and redo operations, such as a drop-down list box
		/// of redoable actions.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getredoname
		[MsgParams(LResultType = typeof(UNDONAMEID))]
		EM_GETREDONAME = WindowMessage.WM_USER + 87,

		/// <summary>
		/// Stops a rich edit control from collecting additional typing actions into the current undo action. The control stores the next
		/// typing action, if any, into a new action in the undo queue.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is zero. This message cannot fail.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A rich edit control groups consecutive typing actions, including characters deleted by using the <c>BackSpace</c> key, into a
		/// single undo action until one of the following events occurs:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>The control receives an <c>EM_STOPGROUPTYPING</c> message.</description>
		/// </item>
		/// <item>
		/// <description>The control loses focus.</description>
		/// </item>
		/// <item>
		/// <description>The user moves the current selection, either by using the arrow keys or by clicking the mouse.</description>
		/// </item>
		/// <item>
		/// <description>The user presses the <c>Delete</c> key.</description>
		/// </item>
		/// <item>
		/// <description>The user performs any other action, such as a paste operation that does <c>not</c> involve typing.</description>
		/// </item>
		/// </list>
		/// <para>
		/// You can send the <c>EM_STOPGROUPTYPING</c> message to break consecutive typing actions into smaller undo groups. For example, you
		/// could send <c>EM_STOPGROUPTYPING</c> after each character or at each word break.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-stopgrouptyping
		[MsgParams()]
		EM_STOPGROUPTYPING = WindowMessage.WM_USER + 88,

		/// <summary>
		/// Sets the text mode or undo level of a rich edit control. The message fails if the control contains any text.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// One or more values from the <c>TEXTMODE</c> enumeration type. The values specify the new settings for the control's text mode and
		/// undo level parameters.
		/// </para>
		/// <para>
		/// Specify one of the following values to set the text mode parameter. If you do not specify a text mode value, the text mode
		/// remains at its current setting.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TM_PLAINTEXT</c></description>
		/// <description>
		/// Indicates plain text mode, in which the control is similar to a standard edit control. For more information about plain text
		/// mode, see the following Remarks section.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TM_RICHTEXT</c></description>
		/// <description>
		/// Indicates rich text mode, in which the control has standard rich edit functionality. Rich text mode is the default setting.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Specify one of the following values to set the undo level parameter. If you do not specify an undo level value, the undo level
		/// remains at its current setting.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TM_SINGLELEVELUNDO</c></description>
		/// <description>The control allows the user to undo only the last action that can be undone.</description>
		/// </item>
		/// <item>
		/// <description><c>TM_MULTILEVELUNDO</c></description>
		/// <description>
		/// The control supports multiple undo operations. This is the default setting. Use the <c>EM_SETUNDOLIMIT</c> message to set the
		/// maximum number of undo actions.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Specify one of the following values to set the code page parameter. If you do not specify an code page value, the code page
		/// remains at its current setting.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TM_SINGLECODEPAGE</c></description>
		/// <description>
		/// The control only allows the English keyboard and a keyboard corresponding to the default character set. For example, you could
		/// have Greek and English. Note that this prevents Unicode text from entering the control. For example, use this value if a Rich
		/// Edit control must be restricted to ANSI text.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>TM_MULTICODEPAGE</c></description>
		/// <description>The control allows multiple code pages and Unicode text into the control. This is the default setting.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the message succeeds, the return value is zero.</para>
		/// <para>If the message fails, the return value is a nonzero value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// In rich text mode, a rich edit control has standard rich edit functionality. However, in plain text mode, the control is similar
		/// to a standard edit control:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>The text in a plain text control can have only one format (such as Bold, 10pt Arial).</description>
		/// </item>
		/// <item>
		/// <description>
		/// The user cannot paste rich text formats, such as Rich Text Format (RTF) or embedded objects into a plain text control.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Rich text mode controls always have a default end-of-document marker or carriage return, to format paragraphs. Plain text
		/// controls, on the other hand, do not need the default, end-of-document marker, so it is omitted.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// The control must contain no text when it receives the <c>EM_SETTEXTMODE</c> message. To ensure there is no text, send a
		/// <c>WM_SETTEXT</c> message with an empty string ("").
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-settextmode
		[MsgParams(typeof(TEXTMODE), null)]
		EM_SETTEXTMODE = WindowMessage.WM_USER + 89,

		/// <summary>
		/// Gets the current text mode and undo level of a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is one or more values from the <c>TEXTMODE</c> enumeration type. The values indicate the current text mode and
		/// undo level of the control.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-gettextmode
		[MsgParams(LResultType = typeof(TEXTMODE))]
		EM_GETTEXTMODE = WindowMessage.WM_USER + 90,

		/// <summary>
		/// Enables or disables automatic detection of hyperlinks by a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specify 0 to disable automatic link detection, or one of the following values to enable various kinds of detection.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>AURL_DISABLEMIXEDLGC</c></description>
		/// <description>
		/// <c>Windows 8</c>: Disable recognition of domain names that contain labels with characters belonging to more than one of the
		/// following scripts: Latin, Greek, and Cyrillic.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>AURL_ENABLEDRIVELETTERS</c></description>
		/// <description><c>Windows 8</c>: Recognize file names that have a leading drive specification, such as c:\temp.</description>
		/// </item>
		/// <item>
		/// <description><c>AURL_ENABLEEA</c></description>
		/// <description>This value is deprecated; use <c>AURL_ENABLEEAURLS</c> instead.</description>
		/// </item>
		/// <item>
		/// <description><c>AURL_ENABLEEAURLS</c></description>
		/// <description>Recognize URLs that contain East Asian characters.</description>
		/// </item>
		/// <item>
		/// <description><c>AURL_ENABLEEMAILADDR</c></description>
		/// <description><c>Windows 8</c>: Recognize email addresses.</description>
		/// </item>
		/// <item>
		/// <description><c>AURL_ENABLETELNO</c></description>
		/// <description><c>Windows 8</c>: Recognize telephone numbers.</description>
		/// </item>
		/// <item>
		/// <description><c>AURL_ENABLEURL</c></description>
		/// <description><c>Windows 8</c>: Recognize URLs that include the path.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// This parameter determines the URL schemes recognized if <c>AURL_ENABLEURL</c> is active. If lParam is NULL, the default scheme
		/// name list is used (see Remarks). Alternatively, lParam can point to a null-terminated string consisting of up to 50
		/// colon-terminated scheme names that supersede the default scheme name list. For example, the string could be
		/// "news:http:ftp:telnet:". The scheme name syntax is defined in the Uniform Resource Identifiers (URI): Generic Syntax document on
		/// The Internet Engineering Task Force (IETF) website. Specifically, a scheme name can contain up to 13 characters (including the
		/// colon), must start with an ASCII alphabetic, and can be followed by a mixture of ASCII alphabetics, digits, and the three
		/// punctuation characters: ".", "+", and "-". The string type can be either <c>char*</c> or <c>WCHAR*</c>; the rich edit control
		/// automatically detects the type.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the message succeeds, the return value is zero.</para>
		/// <para>
		/// If the message fails, the return value is a nonzero value. For example, the message might fail due to insufficient memory, an
		/// invalid detection option, or an invalid scheme-name string.
		/// </para>
		/// <para>If lParam contains more than 50 scheme names, the message fails with a return value of <c>E_INVALIDARG</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If automatic URL detection is enabled (that is, wParam includes <c>AURL_ENABLEURL</c>), the rich edit control scans any modified
		/// text to determine whether the text matches the format of a URL (or more generally in Windows 8 or later an IRI International
		/// Resource Identifier). If lParam is NULL, the control detects URLs that begin with the following scheme names:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>callto</description>
		/// </item>
		/// <item>
		/// <description>file</description>
		/// </item>
		/// <item>
		/// <description>ftp</description>
		/// </item>
		/// <item>
		/// <description>gopher</description>
		/// </item>
		/// <item>
		/// <description>http</description>
		/// </item>
		/// <item>
		/// <description>https</description>
		/// </item>
		/// <item>
		/// <description>mailto</description>
		/// </item>
		/// <item>
		/// <description>news</description>
		/// </item>
		/// <item>
		/// <description>notes</description>
		/// </item>
		/// <item>
		/// <description>nntp</description>
		/// </item>
		/// <item>
		/// <description>onenote</description>
		/// </item>
		/// <item>
		/// <description>outlook</description>
		/// </item>
		/// <item>
		/// <description>prospero</description>
		/// </item>
		/// <item>
		/// <description>tel</description>
		/// </item>
		/// <item>
		/// <description>telnet</description>
		/// </item>
		/// <item>
		/// <description>wais</description>
		/// </item>
		/// <item>
		/// <description>webcal</description>
		/// </item>
		/// </list>
		/// <para>
		/// When automatic link detection is enabled, the rich edit control removes the <c>CFE_LINK</c> effect from modified text that does
		/// not have a format recognized by the control. If your application uses the <c>CFE_LINK</c> effect to mark other types of text, do
		/// not enable automatic link detection. The rich edit control does not check whether a detected link exists; that responsibility
		/// belongs to the client.
		/// </para>
		/// <para>
		/// A rich edit control sends the EN_LINK notification when it receives various messages while the mouse pointer is over text that
		/// has the <c>CFE_LINK</c> effect. For more information, see Automatic RichEdit Hyperlinks and RichEdit Friendly Name Hyperlinks.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-autourldetect
		[MsgParams(typeof(AURL), typeof(IntPtr))]
		EM_AUTOURLDETECT = WindowMessage.WM_USER + 91,

		/// <summary>
		/// Indicates whether the auto URL detection is turned on in the rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If auto-URL detection is active, the return value is 1.</para>
		/// <para>If auto-URL detection is inactive, the return value is 0.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When auto URL detection is on, Microsoft Rich Edit is constantly checking typed text for a valid URL. Rich Edit recognizes URLs
		/// that start with these prefixes:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>http:</description>
		/// </item>
		/// <item>
		/// <description>file:</description>
		/// </item>
		/// <item>
		/// <description>mailto:</description>
		/// </item>
		/// <item>
		/// <description>ftp:</description>
		/// </item>
		/// <item>
		/// <description>https:</description>
		/// </item>
		/// <item>
		/// <description>gopher:</description>
		/// </item>
		/// <item>
		/// <description>nntp:</description>
		/// </item>
		/// <item>
		/// <description>prospero:</description>
		/// </item>
		/// <item>
		/// <description>telnet:</description>
		/// </item>
		/// <item>
		/// <description>news:</description>
		/// </item>
		/// <item>
		/// <description>wais:</description>
		/// </item>
		/// <item>
		/// <description>outlook:</description>
		/// </item>
		/// </list>
		/// <para>
		/// Rich Edit also recognizes standard path names that start with \\. When Rich Edit locates a URL, it changes the URL text color,
		/// underlines the text, and notifies the client using EN_LINK.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getautourldetect
		[MsgParams(LResultType = typeof(BOOL))]
		EM_GETAUTOURLDETECT = WindowMessage.WM_USER + 92,

		/// <summary>
		/// Changes the palette that a rich edit control uses for its display window.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Handle to the new palette used by the rich edit control.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// </summary>
		/// <remarks>The rich edit control does not check whether the new palette is valid.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setpalette
		[MsgParams(typeof(HPALETTE), null)]
		EM_SETPALETTE = WindowMessage.WM_USER + 93,

		/// <summary>
		/// Gets the text from a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Pointer to a <c>GETTEXTEX</c> structure, which indicates how to translate the text before putting it into the output buffer.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to the buffer to receive the text. The size of this buffer, in bytes, is specified by the <c>cb</c> member of the
		/// <c>GETTEXTEX</c> structure. Use the <c>EM_GETTEXTLENGTHEX</c> message to get the required size of the buffer.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is the number of <c>TCHAR</c> s copied into the output buffer, not including the null terminator.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the size of the output buffer is less than the size of the text in the control, the edit control will copy text from its
		/// beginning and place it in the buffer until the buffer is full. A terminating null character will still be placed at the end of
		/// the buffer.
		/// </para>
		/// <para>
		/// If ANSI text is requested, <c>EM_GETTEXTEX</c> uses the <c>WideCharToMultiByte</c> function to translate the Unicode characters
		/// to ANSI. It allows you to go from Unicode to ANSI using a particular code page. The <c>GETTEXTEX</c> structure contains members (
		/// <c>lpDefaultChar</c> and <c>lpUsedDefChar</c>) that are used in the translation from Unicode to ANSI.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-gettextex
		[MsgParams(typeof(GETTEXTEX?), typeof(IntPtr))]
		EM_GETTEXTEX = WindowMessage.WM_USER + 94,

		/// <summary>
		/// Calculates text length in various ways. It is usually called before creating a buffer to receive the text from the control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Pointer to a <c>GETTEXTLENGTHEX</c> structure that receives the text length information.</para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The message returns the number of <c>TCHAR</c> s in the edit control, depending on the setting of the flags in the
		/// <c>GETTEXTLENGTHEX</c> structure. If incompatible flags were set in the <c>flags</c> member, the message returns E_INVALIDARG .
		/// </para>
		/// </summary>
		/// <remarks>
		/// This message is a fast and easy way to determine the number of characters in the Unicode version of the rich edit control.
		/// However, for a non-Unicode target code page you will potentially be converting to a combination of single-byte and double-byte characters.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-gettextlengthex
		[MsgParams(typeof(GETTEXTLENGTHEX?), null)]
		EM_GETTEXTLENGTHEX = WindowMessage.WM_USER + 95,

		/// <summary>
		/// Shows or hides one of the scroll bars in the host window of a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Identifies which scroll bar to display: horizontal or vertical. This parameter must be <c>SB_VERT</c> or <c>SB_HORZ</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Specifies whether to show the scroll bar or hide it. Specify <c>TRUE</c> to show the scroll bar and <c>FALSE</c> to hide it.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// </summary>
		/// <remarks>This method is only valid when the control is in-place active. Calls made while the control is inactive may fail.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-showscrollbar
		[MsgParams(typeof(SB), typeof(BOOL), LResultType = null)]
		EM_SHOWSCROLLBAR = WindowMessage.WM_USER + 96,

		/// <summary>
		/// Combines the functionality of the <c>WM_SETTEXT</c> and <c>EM_REPLACESEL</c> messages, and adds the ability to set text using a
		/// code page and to use either rich text or plain text.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Pointer to a <c>SETTEXTEX</c> structure that specifies flags and an optional code page to use in translating to Unicode.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to the null-terminated text to insert. This text is an ANSI string, unless the code page is 1200 (Unicode). If lParam
		/// starts with a valid RTF ASCII sequence for example, "{\rtf" or "{urtf" the text is read in using the RTF reader.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the operation is setting all of the text and succeeds, the return value is 1.</para>
		/// <para>If the operation is setting the selection and succeeds, the return value is the number of bytes or characters copied.</para>
		/// <para>If the operation fails, the return value is zero.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-settextex
		[MsgParams(typeof(SETTEXTEX?), typeof(IntPtr))]
		EM_SETTEXTEX = WindowMessage.WM_USER + 97,

		/// <summary>
		/// <para>Sets the punctuation characters for a rich edit control.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// This message is supported only in Asian-language versions of Microsoft Rich Edit 1.0. It is not supported in any later versions.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the punctuation type, which can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>PC_LEADING</c></description>
		/// <description>Leading punctuation characters.</description>
		/// </item>
		/// <item>
		/// <description><c>PC_FOLLOWING</c></description>
		/// <description>Following punctuation characters.</description>
		/// </item>
		/// <item>
		/// <description><c>PC_DELIMITER</c></description>
		/// <description>Delimiter.</description>
		/// </item>
		/// <item>
		/// <description><c>PC_OVERFLOW</c></description>
		/// <description>Not supported.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>PUNCTUATION</c> structure that contains the punctuation characters.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the operation succeeds, the return value is a nonzero value.</para>
		/// <para>If the operation fails, the return value is zero.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setpunctuation
		[MsgParams(typeof(PUNC), typeof(PUNCTUATION?))]
		EM_SETPUNCTUATION = WindowMessage.WM_USER + 100,

		/// <summary>
		/// <para>Gets the current punctuation characters for the rich edit control.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// This message is supported only in Asian-language versions of Microsoft Rich Edit 1.0. It is not supported in any later versions
		/// of Rich Edit.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The punctuation type can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>PC_LEADING</c></description>
		/// <description>Leading punctuation characters</description>
		/// </item>
		/// <item>
		/// <description><c>PC_FOLLOWING</c></description>
		/// <description>Following punctuation characters</description>
		/// </item>
		/// <item>
		/// <description><c>PC_DELIMITER</c></description>
		/// <description>Delimiter</description>
		/// </item>
		/// <item>
		/// <description><c>PC_OVERFLOW</c></description>
		/// <description>Not supported</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>PUNCTUATION</c> structure that receives the punctuation characters.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the operation succeeds, the return value is a nonzero value.</para>
		/// <para>If the operation fails, the return value is zero.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getpunctuation
		[MsgParams(typeof(PUNC), typeof(PUNCTUATION?))]
		EM_GETPUNCTUATION = WindowMessage.WM_USER + 101,

		/// <summary>
		/// <para>Sets the word-wrapping and word-breaking options for a rich edit control.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// This message is supported only in Asian-language versions of Microsoft Rich Edit 1.0. It is not supported in any later versions.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>WBF_WORDWRAP</c></description>
		/// <description>Enables Asian-specific word wrap operations, such as kinsoku in Japanese.</description>
		/// </item>
		/// <item>
		/// <description><c>WBF_WORDBREAK</c></description>
		/// <description>Enables English word-breaking operations in Japanese and Chinese. Enables Hangeul word-breaking operation.</description>
		/// </item>
		/// <item>
		/// <description><c>WBF_OVERFLOW</c></description>
		/// <description>Recognizes overflow punctuation. (Not currently supported.)</description>
		/// </item>
		/// <item>
		/// <description><c>WBF_LEVEL1</c></description>
		/// <description>Sets the Level 1 punctuation table as the default.</description>
		/// </item>
		/// <item>
		/// <description><c>WBF_LEVEL2</c></description>
		/// <description>Sets the Level 2 punctuation table as the default.</description>
		/// </item>
		/// <item>
		/// <description><c>WBF_CUSTOM</c></description>
		/// <description>Sets the application-defined punctuation table.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns the current word-wrapping and word-breaking options.</para>
		/// </summary>
		/// <remarks>This message must not be sent by the application defined word breaking procedure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setwordwrapmode
		[MsgParams(typeof(WBF), null, LResultType = typeof(WBF))]
		EM_SETWORDWRAPMODE = WindowMessage.WM_USER + 102,

		/// <summary>
		/// <para>Gets the current word wrap and word-break options for the rich edit control.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// This message is supported only in Asian-language versions of Microsoft Rich Edit 1.0. It is not supported in any later versions
		/// of Rich Edit.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The message returns the current word wrap and word-break options.</para>
		/// </summary>
		/// <remarks>This message must not be sent by the application-defined, word-break procedure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getwordwrapmode
		[MsgParams(LResultType = typeof(WBF))]
		EM_GETWORDWRAPMODE = WindowMessage.WM_USER + 103,

		/// <summary>
		/// <para>Sets the Input Method Editor (IME) composition color for a rich edit control.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// This message is supported only in Asian-language versions of Microsoft Rich Edit 1.0. It is not supported in any later versions.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>COMPCOLOR</c> structure that contains the composition color to be set.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the operation succeeds, the return value is a nonzero value.</para>
		/// <para>If the operation fails, the return value is zero.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setimecolor
		[MsgParams(null, typeof(COMPCOLOR?))]
		EM_SETIMECOLOR = WindowMessage.WM_USER + 104,

		/// <summary>
		/// <para>Retrieves the Input Method Editor (IME) composition color.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// This message is supported only in Asian-language versions of Microsoft Rich Edit 1.0. It is not supported in any later versions
		/// of Rich Edit.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A four-element array of <c>COMPCOLOR</c> structures that receives the composition color.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the operation succeeds, the return value is a nonzero value.</para>
		/// <para>If the operation fails, the return value is zero.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/em-getimecolor
		[MsgParams(null, typeof(COMPCOLOR[]))]
		EM_GETIMECOLOR = WindowMessage.WM_USER + 105,

		/// <summary>
		/// <para>Sets the Input Method Editor (IME) options.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// This message is supported only in Asian-language versions of Microsoft Rich Edit 1.0. It is not supported in any later versions.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>ECOOP_SET</c></description>
		/// <description>Sets the options to those specified by <c>lParam</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>ECOOP_OR</c></description>
		/// <description>Combines the specified options with the current options.</description>
		/// </item>
		/// <item>
		/// <description><c>ECOOP_AND</c></description>
		/// <description>Retains only those current options that are also specified by <c>lParam</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>ECOOP_XOR</c></description>
		/// <description>Logically exclusive OR the current options with those specified by <c>lParam.</c></description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Specifies one of more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>IMF_CLOSESTATUSWINDOW</c></description>
		/// <description>Closes the IME status window when the control receives the input focus.</description>
		/// </item>
		/// <item>
		/// <description><c>IMF_FORCEACTIVE</c></description>
		/// <description>Activates the IME when the control receives the input focus.</description>
		/// </item>
		/// <item>
		/// <description><c>IMF_FORCEDISABLE</c></description>
		/// <description>Disables the IME when the control receives the input focus.</description>
		/// </item>
		/// <item>
		/// <description><c>IMF_FORCEENABLE</c></description>
		/// <description>Enables the IME when the control receives the input focus.</description>
		/// </item>
		/// <item>
		/// <description><c>IMF_FORCEINACTIVE</c></description>
		/// <description>Inactivates the IME when the control receives the input focus.</description>
		/// </item>
		/// <item>
		/// <description><c>IMF_FORCENONE</c></description>
		/// <description>Disables IME handling.</description>
		/// </item>
		/// <item>
		/// <description><c>IMF_FORCEREMEMBER</c></description>
		/// <description>Restores the previous IME status when the control receives the input focus.</description>
		/// </item>
		/// <item>
		/// <description><c>IMF_MULTIPLEEDIT</c></description>
		/// <description>
		/// Specifies that the composition string will not be canceled or determined by focus changes. This allows an application to have
		/// separate composition strings on each rich edit control.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>IMF_VERTICAL</c></description>
		/// <description>Note used in Rich Edit 2.0 and later.</description>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>If the operation succeeds, the return value is a nonzero value.</para>
		/// <para>If the operation fails, the return value is zero.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setimeoptions
		[MsgParams(typeof(ECOOP), typeof(IMF))]
		EM_SETIMEOPTIONS = WindowMessage.WM_USER + 106,

		/// <summary>
		/// <para>Retrieves the current Input Method Editor (IME) options.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// This message is supported only in Asian-language versions of Microsoft Rich Edit 1.0. It is not supported in any later versions
		/// of Rich Edit.
		/// </para>
		/// </para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns one or more of the IME option flag values described in the <c>EM_SETIMEOPTIONS</c> message.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getimeoptions
		[MsgParams(LResultType = typeof(IMF))]
		EM_GETIMEOPTIONS = WindowMessage.WM_USER + 107,

		/// <summary>This message is not implemented.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-convposition
		EM_CONVPOSITION = WindowMessage.WM_USER + 108,

		/// <summary>
		/// Sets options for Input Method Editor (IME) and Asian language support in a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Specifies the language options. For a list of possible values, see <c>EM_GETLANGOPTIONS</c>.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns a value of 1.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>EM_SETLANGOPTIONS</c> message controls the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Automatic font binding.</description>
		/// </item>
		/// <item>
		/// <description>Automatic keyboard switching.</description>
		/// </item>
		/// <item>
		/// <description>Automatic font size adjustment.</description>
		/// </item>
		/// <item>
		/// <description>Use of user-interface default fonts instead of document default fonts.</description>
		/// </item>
		/// <item>
		/// <description>Notifications to client during IME composition.</description>
		/// </item>
		/// <item>
		/// <description>How IME aborts composition mode.</description>
		/// </item>
		/// <item>
		/// <description>Spell checking, autocorrect, and touch keyboard prediction.</description>
		/// </item>
		/// </list>
		/// <para>
		/// This message sets the values of all language option flags. To change a subset of the flags, send the <c>EM_GETLANGOPTIONS</c>
		/// message to get the current option flags, change the flags that you need to change, and then send the <c>EM_SETLANGOPTIONS</c>
		/// message with the result.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setlangoptions
		[MsgParams(null, typeof(IMF))]
		EM_SETLANGOPTIONS = WindowMessage.WM_USER + 120,

		/// <summary>
		/// Gets a rich edit control's option settings for Input Method Editor (IME) and Asian language support.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the IME and Asian language settings, which can be zero or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>IMF_AUTOFONT</c></description>
		/// <description>
		/// If this flag is set, the control automatically changes fonts when the user explicitly changes to a different keyboard layout. It
		/// is useful to turn off <c>IMF_AUTOFONT</c> for universal Unicode fonts. This option is turned on by default (1).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>IMF_AUTOFONTSIZEADJUST</c></description>
		/// <description>
		/// If this flag is set, the control scales font-bound font sizes from insertion point size according to script. For example, Asian
		/// fonts are slightly larger than Western ones. This option is turned on by default (1).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>IMF_AUTOKEYBOARD</c></description>
		/// <description>
		/// If this flag is set, the control automatically changes the keyboard layout when the user explicitly changes to a different font,
		/// or when the user explicitly changes the insertion point to a new location in the text. Will be turned on automatically for
		/// bidirectional controls. For all other controls, it is turned off by default. This option is turned off by default (0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>IMF_DISABLEAUTOBIDIAUTOKEYBOARD</c></description>
		/// <description>
		/// <c>Windows 8</c>: If this flag is set, the control uses language neutral logic for automatic keyboard switching. This option is
		/// turned off by default (0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>IMF_DUALFONT</c></description>
		/// <description>
		/// If this flag is set, the control uses dual-font mode. Used for Asian language support. The control uses an English font for ASCII
		/// text and a Asian font for Asian text. This option is turned on by default (1).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>IMF_IMEALWAYSSENDNOTIFY</c></description>
		/// <description>
		/// This flag controls how the rich edit control notifies the client during IME composition: 0: No EN_CHANGE or EN_SELCHANGE
		/// notifications during undetermined state. Send notification when the final string comes in. This is the default. 1: Send EN_CHANGE
		/// and EN_SELCHANGE events during undetermined state.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>IMF_IMECANCELCOMPLETE</c></description>
		/// <description>
		/// This flag determines how the control uses the composition string of an IME if the user cancels it. If this flag is set, the
		/// control discards the composition string. If this flag is not set, the control uses the composition string as the result string.
		/// This option is turned off by default (0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>IMF_NOIMPLICITLANG</c></description>
		/// <description>
		/// <c>Windows 8</c>: If this flag is set, disable stamping keyboard input with the keyboard language and ensuring that non-East
		/// Asian language IDss are compatible with the character repertoire. This option is turned off by default (0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>IMF_NOKBDLIDFIXUP</c></description>
		/// <description>
		/// <c>Windows 8</c>: If this flag is set, the rich edit control disables stamping keyboard language on an empty control. This option
		/// is turned off by default (0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>IMF_SPELLCHECKING</c></description>
		/// <description>
		/// <c>Windows 8</c>: If this flag is set, the rich edit control turns on spell checking. This option is turned off by default (0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>IMF_TKBAUTOCORRECTION</c></description>
		/// <description>
		/// <c>Windows 8</c>: If this flag is set, enable touch keyboard autocorrect. This option is turned off by default (0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>IMF_TKBPREDICTION</c></description>
		/// <description>
		/// <c>Windows 10</c>: Ignored. <c>Windows 8</c>: If this flag is set, the rich edit control enables touch keyboard prediction. This
		/// option is turned off by default (0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>IMF_UIFONTS</c></description>
		/// <description>Use user-interface default fonts. This option is turned off by default (0).</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// The <c>IMF_AUTOFONT</c> flag is set by default. The <c>IMF_AUTOKEYBOARD</c> and <c>IMF_IMECANCELCOMPLETE</c> flags are cleared by default.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getlangoptions
		[MsgParams(LResultType = typeof(IMF))]
		EM_GETLANGOPTIONS = WindowMessage.WM_USER + 121,

		/// <summary>
		/// Retrieves the current Input Method Editor (IME) mode for a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>ICM_NOTOPEN</c></description>
		/// <description>IME is not open.</description>
		/// </item>
		/// <item>
		/// <description><c>ICM_LEVEL3</c></description>
		/// <description>True inline mode.</description>
		/// </item>
		/// <item>
		/// <description><c>ICM_LEVEL2</c></description>
		/// <description>Level 2.</description>
		/// </item>
		/// <item>
		/// <description><c>ICM_LEVEL2_5</c></description>
		/// <description>Level 2.5</description>
		/// </item>
		/// <item>
		/// <description><c>ICM_LEVEL2_SUI</c></description>
		/// <description>Special UI.</description>
		/// </item>
		/// </list>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getimecompmode
		[MsgParams(LResultType = typeof(ICM))]
		EM_GETIMECOMPMODE = WindowMessage.WM_USER + 122,

		/// <summary>
		/// Finds Unicode text within a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the parameters of the search operation. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>FR_DOWN</c></description>
		/// <description>
		/// If set, the operation searches from the end of the current selection to the end of the document. If not set, the operation
		/// searches from the end of the current selection to the beginning of the document.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>FR_MATCHALEFHAMZA</c></description>
		/// <description>
		/// By default, Arabic and Hebrew alefs with different accents are all matched by the alef character. Set this flag if you want the
		/// search to differentiate between alefs with different accents.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>FR_MATCHCASE</c></description>
		/// <description>If set, the search operation is case-sensitive. If not set, the search operation is case-insensitive.</description>
		/// </item>
		/// <item>
		/// <description><c>FR_MATCHDIAC</c></description>
		/// <description>
		/// By default, Arabic and Hebrew diacritical marks are ignored. Set this flag if you want the search operation to consider
		/// diacritical marks.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>FR_MATCHKASHIDA</c></description>
		/// <description>
		/// By default, Arabic and Hebrew kashidas are ignored. Set this flag if you want the search operation to consider kashidas.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>FR_WHOLEWORD</c></description>
		/// <description>
		/// If set, the operation searches only for whole words that match the search string. If not set, the operation also searches for
		/// word fragments that match the search string.
		/// </description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>A <c>FINDTEXTW</c> structure containing information about the find operation.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the target string is found, the return value is the zero-based position of the first character of the match. If the target is
		/// not found, the return value is -1.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <c>EM_FINDTEXTW</c> uses the <c>FINDTEXTW</c> structure, while <c>EM_FINDTEXTEXW</c> uses the <c>FINDTEXTEXW</c> structure. The
		/// difference is that <c>FINDTEXTEXW</c> reports back the range of text that was found.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-findtextw
		[MsgParams(typeof(FR), typeof(FINDTEXT?))]
		EM_FINDTEXTW = WindowMessage.WM_USER + 123,

		/// <summary>
		/// Finds Unicode text within a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the behavior of the search operation. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>FR_DOWN</c></description>
		/// <description>
		/// Microsoft Rich Edit 2.0 and later: If set, the search is forward from <c>FINDTEXTEX.chrg.cpMin</c>; if not set, the search is
		/// backward from <c>FINDTEXTEX.chrg.cpMin</c>. Microsoft Rich Edit 1.0: The FR_DOWN flag is ignored. The search is always forward.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>FR_MATCHALEFHAMZA</c></description>
		/// <description>
		/// If set, the search differentiates between alefs with different accents. If not set, Arabic and Hebrew alefs with different
		/// accents are all matched by the alef character.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>FR_MATCHCASE</c></description>
		/// <description>If set, the search operation is case-sensitive. If not set, the search operation is case-insensitive.</description>
		/// </item>
		/// <item>
		/// <description><c>FR_MATCHDIAC</c></description>
		/// <description>
		/// If set, the search operation considers diacritical marks. If not set, Arabic and Hebrew diacritical marks are ignored.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>FR_MATCHKASHIDA</c></description>
		/// <description>If set, the search operation considers kashidas. If not set, Arabic and Hebrew kashidas are ignored.</description>
		/// </item>
		/// <item>
		/// <description><c>FR_WHOLEWORD</c></description>
		/// <description>
		/// If set, the operation searches only for whole words that match the search string. If not set, the operation also searches for
		/// word fragments that match the search string.
		/// </description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>A <c>FINDTEXTEXW</c> structure containing information about the find operation.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If the target string is found, the return value is the zero-based position of the first character of the match. If the target is
		/// not found, the return value is -1.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>Use this message to find Unicode strings. For ANSI;, use <c>EM_FINDTEXTEX</c>.</para>
		/// <para>
		/// The <c>cpMin</c> member of <c>FINDTEXTEX.chrg</c> always specifies the starting-point of the search, and <c>cpMax</c> specifies
		/// the end point. When searching backward, <c>cpMin</c> must be equal to or greater than <c>cpMax</c>. When searching forward, a
		/// value of -1 in <c>cpMax</c> extends the search range to the end of the text.
		/// </para>
		/// <para>
		/// If the search operation finds a match, the <c>chrgText</c> member of the <c>FINDTEXTEX</c> structure returns the range of
		/// character positions that contains the matching text.
		/// </para>
		/// <para>
		/// <c>EM_FINDTEXTEXW</c> uses the <c>FINDTEXTEXW</c> structure, while <c>EM_FINDTEXTW</c> uses the <c>FINDTEXTW</c> structure. The
		/// difference is that <c>EM_FINDTEXTEXW</c> reports the range of text that was found.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-findtextexw
		[MsgParams(typeof(FR), typeof(FINDTEXTEX?))]
		EM_FINDTEXTEXW = WindowMessage.WM_USER + 124,

		/// <summary>
		/// Invokes the Input Method Editor (IME) reconversion dialog box.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message always returns zero.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-reconversion
		[MsgParams()]
		EM_RECONVERSION = WindowMessage.WM_USER + 125,

		/// <summary>
		/// Set the Input Method Editor (IME) mode bias for a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>IME mode bias value. It can be one of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>IMF_SMODE_PLAURALCLAUSE</c></description>
		/// <description>Sets the IME mode bias to Name.</description>
		/// </item>
		/// <item>
		/// <description><c>IMF_SMODE_NONE</c></description>
		/// <description>No bias.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>This must be the same value as wParam.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns the new IME mode bias setting.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When the IME generates a list of alternative choices for a set of characters, this message sets the criteria by which some of the
		/// choices will appear at the top of the list.
		/// </para>
		/// <para>To set the Text Services Framework (TSF) mode bias, use <c>EM_SETCTFMODEBIAS</c>.</para>
		/// <para>The application should call <c>EM_ISIME</c> before calling this function.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setimemodebias
		[MsgParams(typeof(IMF_SMODE), typeof(IMF_SMODE), LResultType = typeof(IMF_SMODE))]
		EM_SETIMEMODEBIAS = WindowMessage.WM_USER + 126,

		/// <summary>
		/// Retrieves the Input Method Editor (IME) mode bias for a Microsoft Rich Edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns the current IME mode bias setting.</para>
		/// </summary>
		/// <remarks>
		/// <para>To get the Text Services Framework mode bias, use <c>EM_GETCTFMODEBIAS</c>.</para>
		/// <para>The application should call <c>EM_ISIME</c> before calling this function.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getimemodebias
		[MsgParams(LParamType = typeof(IMF_SMODE))]
		EM_GETIMEMODEBIAS = WindowMessage.WM_USER + 127,

		/// <summary>
		/// The <c>EM_SETBIDIOPTIONS</c> message sets the current state of the bidirectional options in the rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>BIDIOPTIONS</c> structure that indicates how to set the state of the bidirectional options in the rich edit control.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// </summary>
		/// <remarks>
		/// <para>The rich edit control must be in plain text mode or <c>EM_SETBIDIOPTIONS</c> will not do anything.</para>
		/// <para>
		/// In plain text controls, <c>EM_SETBIDIOPTIONS</c> automatically determines the paragraph direction and/or alignment based on the
		/// context rules. These rules state that the direction and/or alignment is derived from the first strong character in the control. A
		/// strong character is one from which text direction can be determined (see Unicode Standard version 2.0). The paragraph direction
		/// and/or alignment is applied to the default format.
		/// </para>
		/// <para><c>EM_SETBIDIOPTIONS</c> only switches the default paragraph format to RTL (right to left) if it finds an RTL character,</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setbidioptions
		[MsgParams(null, typeof(BIDIOPTIONS?), LResultType = null)]
		EM_SETBIDIOPTIONS = WindowMessage.WM_USER + 200,

		/// <summary>
		/// Indicates the current state of the bidirectional options in the rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A <c>BIDIOPTIONS</c> structure that receives the current state of the bidirectional options in the rich edit control.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message does not return a value.</para>
		/// </summary>
		/// <remarks>
		/// This message sets the values of the <c>wMask</c> and <c>wEffects</c> members to the value of the current state of the
		/// bidirectional options in the rich edit control.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getbidioptions
		[MsgParams(null, typeof(BIDIOPTIONS), LResultType = null)]
		EM_GETBIDIOPTIONS = WindowMessage.WM_USER + 201,

		/// <summary>
		/// Sets the current state of the typography options of a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies one or both of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TO_ADVANCEDTYPOGRAPHY</c></description>
		/// <description>Advanced line breaking and line formatting is turned on.</description>
		/// </item>
		/// <item>
		/// <description><c>TO_SIMPLELINEBREAK</c></description>
		/// <description>Faster line breaking for simple text (requires <c>TO_ADVANCEDTYPOGRAPHY</c>).</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A mask consisting of one or more of the flags in wParam. Only the flags that are set in this mask will be set or cleared. This
		/// allows a single flag to be set or cleared without reading the current flag states.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if wParam is valid, otherwise <c>FALSE</c>.</para>
		/// </summary>
		/// <remarks>
		/// Advanced line breaking is turned on automatically by the rich edit control when needed, such as for handling complex scripts like
		/// Arabic and Hebrew, and for mathematics. It s also needed for justified paragraphs, hyphenation, and other typographic features.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-settypographyoptions
		[MsgParams(typeof(TO), typeof(TO), LResultType = typeof(BOOL))]
		EM_SETTYPOGRAPHYOPTIONS = WindowMessage.WM_USER + 202,

		/// <summary>
		/// Returns the current state of the typography options of a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the current typography options. For a list of options, see <c>EM_SETTYPOGRAPHYOPTIONS</c>.</para>
		/// </summary>
		/// <remarks>
		/// You can turn on advanced line breaking by sending the <c>EM_SETTYPOGRAPHYOPTIONS</c> message. Advanced and normal line breaking
		/// may also be turned on automatically by the rich edit control if it is needed for certain languages.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-gettypographyoptions
		[MsgParams(LResultType = typeof(TO))]
		EM_GETTYPOGRAPHYOPTIONS = WindowMessage.WM_USER + 203,

		/// <summary>
		/// Sets the current edit style flags for a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies one or more edit style flags. For a list of possible values, see <c>EM_GETEDITSTYLE</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A mask consisting of one or more of the wParam values. Only the values specified in this mask will be set or cleared. This allows
		/// a single flag to be set or cleared without reading the current flag states.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the state of the edit style flags after the rich edit control has attempted to implement your edit style
		/// changes. The edit style flags are a set of flags that indicate the current edit style.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-seteditstyle
		[MsgParams(typeof(SES), typeof(SES), LResultType = typeof(SES))]
		EM_SETEDITSTYLE = WindowMessage.WM_USER + 204,

		/// <summary>
		/// Retrieves the current edit style flags.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the current edit style flags, which can include one or more of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>SES_BEEPONMAXTEXT</c></description>
		/// <description>Rich Edit will call the system beeper if the user attempts to enter more than the maximum characters.</description>
		/// </item>
		/// <item>
		/// <description><c>SES_BIDI</c></description>
		/// <description>
		/// Turns on bidirectional processing. This is automatically turned on by Rich Edit if any of the following window styles are active:
		/// <c>WS_EX_RIGHT</c>, <c>WS_EX_RTLREADING</c>, <c>WS_EX_LEFTSCROLLBAR</c>. However, this setting is useful for handling these
		/// window styles when using a custom implementation of <c>ITextHost</c> (default: 0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_CTFALLOWEMBED</c></description>
		/// <description><c>Windows XP with SP1</c>: Allow embedded objects to be inserted using TSF (default: 0).</description>
		/// </item>
		/// <item>
		/// <description><c>SES_CTFALLOWPROOFING</c></description>
		/// <description><c>Windows XP with SP1</c>: Allows TSF proofing tips (default: 0).</description>
		/// </item>
		/// <item>
		/// <description><c>SES_CTFALLOWSMARTTAG</c></description>
		/// <description><c>Windows XP with SP1</c>: Allows TSF SmartTag tips (default: 0).</description>
		/// </item>
		/// <item>
		/// <description><c>SES_CTFNOLOCK</c></description>
		/// <description><c>Windows 8</c>: Do not allow the TSF lock read/write access. This pauses TSF input.</description>
		/// </item>
		/// <item>
		/// <description><c>SES_DEFAULTLATINLIGA</c></description>
		/// <description>
		/// <c>Windows 8</c>: Fonts with an fi ligature are displayed with default OpenType features resulting in improved typography
		/// (default: 0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_DRAFTMODE</c></description>
		/// <description>
		/// <c>Windows XP with SP1</c>: Use draft mode fonts to display text. Draft mode is an accessibility option where the control
		/// displays the text with a single font; the font is determined by the system setting for the font used in message boxes. For
		/// example, accessible users may read text easier if it is uniform, rather than a mix of fonts and styles (default: 0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_EMULATE10</c></description>
		/// <description><c>Windows 8</c>: Emulate RichEdit 1.0 behavior.</description>
		/// </item>
		/// <item>
		/// <description><c>SES_EMULATESYSEDIT</c></description>
		/// <description>When this bit is on, rich edit attempts to emulate the system edit control (default: 0).</description>
		/// </item>
		/// <item>
		/// <description><c>SES_EXTENDBACKCOLOR</c></description>
		/// <description>Extends the background color all the way to the edges of the client rectangle (default: 0).</description>
		/// </item>
		/// <item>
		/// <description><c>SES_HIDEGRIDLINES</c></description>
		/// <description>
		/// <c>Windows XP with SP1</c>: If the width of table gridlines is zero, gridlines are not displayed. This is equivalent to the hide
		/// gridlines feature in Word's table menu (default: 0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_HYPERLINKTOOLTIPS</c></description>
		/// <description>
		/// <c>Windows 8</c>: When the cursor is over a link, display a tooltip with the target link address (default: 0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_LOGICALCARET</c></description>
		/// <description>
		/// <c>Windows 8</c>: Provide logical caret information instead of a caret bitmap as described in <c>ITextHost::TxSetCaretPos</c>
		/// (default: 0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_LOWERCASE</c></description>
		/// <description>Converts all input characters to lowercase (default: 0).</description>
		/// </item>
		/// <item>
		/// <description><c>SES_MAPCPS</c></description>
		/// <description>Obsolete. Do not use.</description>
		/// </item>
		/// <item>
		/// <description><c>SES_MULTISELECT</c></description>
		/// <description>
		/// <c>Windows 8</c>: Enable multiselection with individual mouse selections made while the Ctrl key is pressed (default: 0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_NOEALINEHEIGHTADJUST</c></description>
		/// <description>
		/// <c>Windows 8</c>: Do not adjust line height for East Asian text (default: 0 which adjusts the line height by 15%).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_NOFOCUSLINKNOTIFY</c></description>
		/// <description>Sends EN_LINK notification from links that do not have focus.</description>
		/// </item>
		/// <item>
		/// <description><c>SES_NOIME</c></description>
		/// <description>Disallows IMEs for this instance of the rich edit control (default: 0).</description>
		/// </item>
		/// <item>
		/// <description><c>SES_NOINPUTSEQUENCECHK</c></description>
		/// <description>
		/// When this bit is on, rich edit does not verify the sequence of typed text. Some languages (such as Thai and Vietnamese) require
		/// verifying the input sequence order before submitting it to the backing store (default: 0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_SCROLLONKILLFOCUS</c></description>
		/// <description>When KillFocus occurs, scroll to the beginning of the text (character position equal to 0) (default: 0).</description>
		/// </item>
		/// <item>
		/// <description><c>SES_SMARTDRAGDROP</c></description>
		/// <description><c>Windows 8</c>: Add or delete a space according to the context when dropping text (default: 0).</description>
		/// </item>
		/// <item>
		/// <description><c>SES_USECRLF</c></description>
		/// <description>Obsolete. Do not use.</description>
		/// </item>
		/// <item>
		/// <description><c>SES_WORDDRAGDROP</c></description>
		/// <description>
		/// <c>Windows 8</c>: If word select is active, ensure that the drop location is at a word boundary (default: 0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_UPPERCASE</c></description>
		/// <description>Converts all input characters to uppercase (default: 0).</description>
		/// </item>
		/// <item>
		/// <description><c>SES_USEAIMM</c></description>
		/// <description>Uses the Active IMM input method component that ships with Internet Explorer 4.0 or later (default: 0).</description>
		/// </item>
		/// <item>
		/// <description><c>SES_USEATFONT</c></description>
		/// <description>
		/// <c>Windows XP with SP1</c>: Uses an @ font, which is designed for vertical text; this is used with the <c>ES_VERTICAL</c> window
		/// style. The name of an @ font begins with the @ symbol, for example, "@Batang" (default: 0, but is automatically turned on for
		/// vertical text layout).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_USECTF</c></description>
		/// <description><c>Windows XP with SP1</c>: Turns on TSF support. (default: 0)</description>
		/// </item>
		/// <item>
		/// <description><c>SES_XLTCRCRLFTOCR</c></description>
		/// <description>
		/// Turns on translation of CRCRLFs to CRs. When this bit is on and a file is read in, all instances of CRCRLF will be converted to
		/// hard CRs internally. This will affect the text wrapping. Note that if such a file is saved as plain text, the CRs will be
		/// replaced by CRLFs. This is the .txt standard for plain text (default: 0, which deletes CRCRLFs on input).
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-geteditstyle
		[MsgParams(LResultType = typeof(SES))]
		EM_GETEDITSTYLE = WindowMessage.WM_USER + 205,

		/// <summary>Undocumented</summary>
		EM_OUTLINE = WindowMessage.WM_USER + 220,

		/// <summary>
		/// Obtains the current scroll position of the edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>POINT</c> structure. After calling <c>EM_GETSCROLLPOS</c>, this parameters contains a point in the virtual text
		/// space of the document, expressed in pixels. This point will be the point that is currently located in the upper-left corner of
		/// the edit control window.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message always returns 1.</para>
		/// </summary>
		/// <remarks>The values returned in the <c>POINT</c> structure are 16-bit values (even in the 32-bit wide fields).</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getscrollpos
		[MsgParams(null, typeof(POINT?))]
		EM_GETSCROLLPOS = WindowMessage.WM_USER + 221,

		/// <summary>
		/// Scrolls the contents of a rich edit control to the specified point.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to a <c>POINT</c> structure which specifies a point in the virtual text space of the document, expressed in pixels. The
		/// document will be scrolled until this point is located in the upper-left corner of the edit control window. If you want to change
		/// the view such that the upper left corner of the view is two lines down and one character in from the left edge. You would pass a
		/// point of (7, 22).
		/// </para>
		/// <para>
		/// The rich edit control checks the x and y coordinates and adjusts them if necessary, so that a complete line is displayed at the
		/// top. It also ensures that the text is never completely scrolled off the view rectangle.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message always returns 1.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setscrollpos
		[MsgParams(null, typeof(POINT?))]
		EM_SETSCROLLPOS = WindowMessage.WM_USER + 222,

		/// <summary>
		/// Sets the font size for the selected text in a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// Change in point size of the selected text. The result will be rounded according to values shown in the following table. This
		/// parameter should be in the range of -1637 to 1638. The resulting font size will be within the range of 1 to 1638.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>This parameter is not used; it must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If no error occurred, the return value is <c>TRUE</c>.</para>
		/// <para>If an error occurred, the return value is <c>FALSE</c>.</para>
		/// </summary>
		/// <remarks>
		/// <para>You can easily get the font size by sending the <c>EM_GETCHARFORMAT</c> message.</para>
		/// <para>
		/// Rich Edit first adds wParam to the current font size and then uses the resulting size and the following table to determine the
		/// rounding value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Band</description>
		/// <description>Rounding value</description>
		/// </listheader>
		/// <item>
		/// <description>&lt;=12</description>
		/// <description>1</description>
		/// </item>
		/// <item>
		/// <description>28</description>
		/// <description>2</description>
		/// </item>
		/// <item>
		/// <description>36</description>
		/// <description>0</description>
		/// </item>
		/// <item>
		/// <description>48</description>
		/// <description>0</description>
		/// </item>
		/// <item>
		/// <description>72</description>
		/// <description>0</description>
		/// </item>
		/// <item>
		/// <description>80</description>
		/// <description>0</description>
		/// </item>
		/// <item>
		/// <description>&gt; 80</description>
		/// <description>10</description>
		/// </item>
		/// </list>
		/// <para>
		/// If the resulting font size is not evenly divisible by the rounding value, the font size is then rounded to a number evenly
		/// divisible by the rounding value. So if the font size is less than or equal to 12, the rounding value will be 1. Similarly, if the
		/// font size is less than or equal to 28, the rounding value is 2. For values greater than 28, font sizes are rounded to the next
		/// band. So, the font size jumps to 36, 48, 72, 80. After 80, all rounding is done in increments of ten points.
		/// </para>
		/// <para>
		/// The font size is rounded up or down depending on the sign of wParam. If wParam is positive, the rounding is always up. Otherwise,
		/// rounding is always down. So, if the current font size is 10 and wParam is 3, the resulting font size would be 14 (10 + 3 = 13,
		/// which is not divisible by 2, so the size rounds up to 14). Conversely, if the current font size is 14 and wParam is -3, the
		/// resulting font size would be 10 (14 - 3 = 11, which is not divisible by 2, so the size rounds down to 10).
		/// </para>
		/// <para>
		/// The change is applied to each part of the selection. So, if some of the text is 10pt and some 20pt, after a call with wParam set
		/// to 1, the font sizes become 11pt and 22pt, respectively.
		/// </para>
		/// <para>Additional examples are shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Original font size</description>
		/// <description><c>wParam</c></description>
		/// <description>Resulting font size</description>
		/// </listheader>
		/// <item>
		/// <description>7</description>
		/// <description>1</description>
		/// <description>8</description>
		/// </item>
		/// <item>
		/// <description>7</description>
		/// <description>3</description>
		/// <description>10</description>
		/// </item>
		/// <item>
		/// <description>10</description>
		/// <description>3</description>
		/// <description>14</description>
		/// </item>
		/// <item>
		/// <description>14</description>
		/// <description>-3</description>
		/// <description>10</description>
		/// </item>
		/// <item>
		/// <description>28</description>
		/// <description>1</description>
		/// <description>36</description>
		/// </item>
		/// <item>
		/// <description>28</description>
		/// <description>3</description>
		/// <description>36</description>
		/// </item>
		/// <item>
		/// <description>80</description>
		/// <description>1</description>
		/// <description>90</description>
		/// </item>
		/// <item>
		/// <description>80</description>
		/// <description>-1</description>
		/// <description>72</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setfontsize
		[MsgParams(typeof(short), null, LResultType = typeof(BOOL))]
		EM_SETFONTSIZE = WindowMessage.WM_USER + 223,

		/// <summary>
		/// Gets the current zoom ratio for a multiline edit control or a rich edit control. The zoom ration is always between 1/64 and 64.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Receives the numerator of the zoom ratio.</para>
		/// <para><em>lParam</em></para>
		/// <para>Receives the denominator of the zoom ratio.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The message returns <c>TRUE</c> if message is processed, which it will be if both wParam and lParam are not <c>NULL</c>.</para>
		/// </summary>
		/// <remarks>
		/// <c>Edit:</c> Supported in Windows 10 1809 and later. The edit control needs to have the <c>ES_EX_ZOOMABLE</c> extended style set,
		/// for this message to have an effect, see Edit Control Extended Styles. For information about the edit control, see Edit Controls.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getzoom
		[MsgParams(typeof(int), typeof(int), LResultType = typeof(BOOL))]
		EM_GETZOOM = WindowMessage.WM_USER + 224,

		/// <summary>
		/// Sets the zoom ratio for a multiline edit control or a rich edit control. The ratio must be a value between 1/64 and 64. The edit
		/// control needs to have the <c>ES_EX_ZOOMABLE</c> extended style set, for this message to have an effect, see Edit Control Extended Styles.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Numerator of the zoom ratio.</para>
		/// <para><em>lParam</em></para>
		/// <para>Denominator of the zoom ratio. These parameters can have the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>Both 0</c></description>
		/// <description>Turns off zooming by using the <c>EM_SETZOOM</c> message (zooming may still occur using <c>TxGetExtent</c>).</description>
		/// </item>
		/// <item>
		/// <description><c>1/64 &lt; (wParam / lParam) &lt; 64</c></description>
		/// <description>Zooms display by the zoom ratio numerator/denominator</description>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>If the new zoom setting is accepted, the return value is <c>TRUE</c>.</para>
		/// <para>If the new zoom setting is not accepted, the return value is <c>FALSE</c>.</para>
		/// </summary>
		/// <remarks>
		/// <c>Edit:</c> Supported in Windows 10 1809 and later. The edit control needs to have the <c>ES_EX_ZOOMABLE</c> extended style set,
		/// for this message to have an effect, see Edit Control Extended Styles. For information about the edit control, see Edit Controls.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setzoom
		[MsgParams(typeof(int), typeof(int), LResultType = typeof(BOOL))]
		EM_SETZOOM = WindowMessage.WM_USER + 225,

		/// <summary>Undocumented</summary>
		EM_GETVIEWKIND = WindowMessage.WM_USER + 226,

		/// <summary>Undocumented</summary>
		EM_SETVIEWKIND = WindowMessage.WM_USER + 227,

		/// <summary>Undocumented</summary>
		EM_GETPAGE = WindowMessage.WM_USER + 228,

		/// <summary>Undocumented</summary>
		EM_SETPAGE = WindowMessage.WM_USER + 229,

		/// <summary>
		/// Retrieves information about hyphenation for a Microsoft Rich Edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The <c>HYPHENATEINFO</c> structure.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-gethyphenateinfo
		[MsgParams(typeof(HYPHENATEINFO?), null, LResultType = null)]
		EM_GETHYPHENATEINFO = WindowMessage.WM_USER + 230,

		/// <summary>
		/// Sets the way a rich edit control does hyphenation.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Pointer to a <c>HYPHENATEINFO</c> structure.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used, must be zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>To enable hyphenation, the client must call <c>EM_SETTYPOGRAPHYOPTIONS</c>, specifying TO_ADVANCEDTYPOGRAPHY.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-sethyphenateinfo
		[MsgParams(typeof(HYPHENATEINFO?), null, LResultType = null)]
		EM_SETHYPHENATEINFO = WindowMessage.WM_USER + 231,

		/// <summary>
		/// <para>
		/// [ <c>EM_GETPAGEROTATE</c> is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Gets the text layout for a Microsoft Rich Edit control.</para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Gets the current text layout. For a list of possible text layout values, see <c>EM_SETPAGEROTATE</c>.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getpagerotate
		[MsgParams(LResultType = typeof(EPR))]
		EM_GETPAGEROTATE = WindowMessage.WM_USER + 235,

		/// <summary>
		/// <para>
		/// [ <c>EM_SETPAGEROTATE</c> is available for use in the operating systems specified in the Requirements section. It may be altered
		/// or unavailable in subsequent versions.]
		/// </para>
		/// <para>Sets the text layout for a rich edit control.</para>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Text layout value. This can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>EPR_0</c></description>
		/// <description>Text flows from left to right and from top to bottom.</description>
		/// </item>
		/// <item>
		/// <description><c>EPR_90</c></description>
		/// <description>Text flows from bottom to top and from left to right.</description>
		/// </item>
		/// <item>
		/// <description><c>EPR_180</c></description>
		/// <description>Text flows from right to left and from bottom to top.</description>
		/// </item>
		/// <item>
		/// <description><c>EPR_270</c></description>
		/// <description>Text flows from top to bottom and from right to left.</description>
		/// </item>
		/// <item>
		/// <description><c>EPR_SE</c></description>
		/// <description><c>Windows 8:</c> Text flows top to bottom and left to right (Mongolian text layout).</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return value is the new text layout value.</para>
		/// </summary>
		/// <remarks>
		/// This message sets the text layout for the entire document. However, embedded contents are not rotated and must be rotated
		/// separately by the application.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setpagerotate
		[MsgParams(typeof(EPR), null, LResultType = null)]
		EM_SETPAGEROTATE = WindowMessage.WM_USER + 236,

		/// <summary>
		/// Gets the Text Services Framework mode bias values for a Microsoft Rich Edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The current Text Services Framework mode bias value.</para>
		/// </summary>
		/// <remarks>To get the IME mode bias, call <c>EM_GETIMEMODEBIAS</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getctfmodebias
		[MsgParams(LResultType = typeof(CTFMODEBIAS))]
		EM_GETCTFMODEBIAS = WindowMessage.WM_USER + 237,

		/// <summary>
		/// Sets the Text Services Framework (TSF) mode bias for a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Mode bias value. This can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>CTFMODEBIAS_DEFAULT</c></description>
		/// <description>There is no mode bias.</description>
		/// </item>
		/// <item>
		/// <description><c>CTFMODEBIAS_FILENAME</c></description>
		/// <description>The bias is to a filename.</description>
		/// </item>
		/// <item>
		/// <description><c>CTFMODEBIAS_NAME</c></description>
		/// <description>The bias is to a name.</description>
		/// </item>
		/// <item>
		/// <description><c>CTFMODEBIAS_READING</c></description>
		/// <description>The bias is to the reading.</description>
		/// </item>
		/// <item>
		/// <description><c>CTFMODEBIAS_DATETIME</c></description>
		/// <description>The bias is to a date or time.</description>
		/// </item>
		/// <item>
		/// <description><c>CTFMODEBIAS_CONVERSATION</c></description>
		/// <description>The bias is to a conversation.</description>
		/// </item>
		/// <item>
		/// <description><c>CTFMODEBIAS_NUMERIC</c></description>
		/// <description>The bias is to a number.</description>
		/// </item>
		/// <item>
		/// <description><c>CTFMODEBIAS_HIRAGANA</c></description>
		/// <description>The bias is to hiragana strings.</description>
		/// </item>
		/// <item>
		/// <description><c>CTFMODEBIAS_KATAKANA</c></description>
		/// <description>The bias is to katakana strings.</description>
		/// </item>
		/// <item>
		/// <description><c>CTFMODEBIAS_HANGUL</c></description>
		/// <description>The bias is to Hangul characters.</description>
		/// </item>
		/// <item>
		/// <description><c>CTFMODEBIAS_HALFWIDTHKATAKANA</c></description>
		/// <description>The bias is to half-width katakana strings.</description>
		/// </item>
		/// <item>
		/// <description><c>CTFMODEBIAS_FULLWIDTHALPHANUMERIC</c></description>
		/// <description>The bias is to full-width alphanumeric characters.</description>
		/// </item>
		/// <item>
		/// <description><c>CTFMODEBIAS_HALFWIDTHALPHANUMERIC</c></description>
		/// <description>The bias is to half-width alphanumeric characters.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If successful, the return value is the new TSF mode bias value. If unsuccessful, the return value is the old TSF mode bias value.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When a Microsoft Rich Edit application uses TSF, it can select the TSF mode bias. This message sets the criteria by which an
		/// alternative choice appears at the top of the list for selection.
		/// </para>
		/// <para>To set the mode bias for the Input Method Editor (IME), use <c>EM_SETIMEMODEBIAS</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/Controls/em-setctfmodebias
		[MsgParams(typeof(CTFMODEBIAS), null, LResultType = typeof(CTFMODEBIAS))]
		EM_SETCTFMODEBIAS = WindowMessage.WM_USER + 238,

		/// <summary>
		/// Determines if the Text Services Framework (TSF) keyboard is open or closed.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the TSF keyboard is open, the return value is <c>TRUE</c>. Otherwise, it is <c>FALSE</c>.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getctfopenstatus
		[MsgParams(LResultType = typeof(BOOL))]
		EM_GETCTFOPENSTATUS = WindowMessage.WM_USER + 240,

		/// <summary>
		/// Opens or closes the Text Services Framework (TSF) keyboard.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>To turn on the TSF keyboard, use <c>TRUE</c>. To turn off the TSF keyboard, use <c>FALSE</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If successful, this message returns <c>TRUE</c>. If unsuccessful, this message returns <c>FALSE</c>.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setctfopenstatus
		[MsgParams(typeof(BOOL), null, LResultType = typeof(BOOL))]
		EM_SETCTFOPENSTATUS = WindowMessage.WM_USER + 241,

		/// <summary>
		/// Retrieves the Input Method Editor (IME) composition text.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The <c>IMECOMPTEXT</c> structure.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// The buffer that receives the composition text. The size of this buffer is contained in the <c>cb</c> member of the wParam structure.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>If successful, the return value is the number of Unicode characters copied to the buffer. Otherwise, it is zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>This message only takes Unicode strings.</para>
		/// <para>
		/// <c>Security Warning:</c> Be sure to have a buffer sufficient for the size of the input. Failure to do so could cause problems for
		/// your application.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getimecomptext
		[MsgParams(typeof(IMECOMPTEXT?), typeof(IntPtr))]
		EM_GETIMECOMPTEXT = WindowMessage.WM_USER + 242,

		/// <summary>
		/// Determine with a rich edit control's current input locale is an East Asian locale.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns <c>TRUE</c> if it is an East Asian locale. Otherwise, it returns <c>FALSE</c>.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-isime
		[MsgParams(LResultType = typeof(BOOL))]
		EM_ISIME = WindowMessage.WM_USER + 243,

		/// <summary>
		/// Retrieves the property and capabilities of the Input Method Editor (IME) associated with the current input locale.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies the type of property information to retrieve. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>IGP_PROPERTY</c></description>
		/// <description>Property information.</description>
		/// </item>
		/// <item>
		/// <description><c>IGP_CONVERSION</c></description>
		/// <description>Conversion capabilities.</description>
		/// </item>
		/// <item>
		/// <description><c>IGP_SENTENCE</c></description>
		/// <description>Sentence mode capabilities.</description>
		/// </item>
		/// <item>
		/// <description><c>IGP_UI</c></description>
		/// <description>User interface capabilities.</description>
		/// </item>
		/// <item>
		/// <description><c>IGP_SETCOMPSTR</c></description>
		/// <description>Composition string capabilities.</description>
		/// </item>
		/// <item>
		/// <description><c>IGP_SELECT</c></description>
		/// <description>Selection inheritance capabilities.</description>
		/// </item>
		/// <item>
		/// <description><c>IGP_GETIMEVERSION</c></description>
		/// <description>Retrieves the system version number for which the specified IME was created.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the property or capability value, depending on the value of the lParam parameter. For more information, see the Remarks.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>If wParam is IGP_PROPERTY, it returns one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Requirement</description>
		/// <description>Value</description>
		/// </listheader>
		/// <item>
		/// <description>IME_PROP_AT_CARET</description>
		/// <description>If set, conversion window is at the caret position. If clear, the window is near caret position.</description>
		/// </item>
		/// <item>
		/// <description>IME_PROP_SPECIAL_UI</description>
		/// <description>If set, IME has a nonstandard user interface. The application should not draw in the IME window.</description>
		/// </item>
		/// <item>
		/// <description>IME_PROP_CANDLIST_START_FROM_1</description>
		/// <description>If set, strings in the candidate list are numbered starting at 1. If clear, strings start at zero.</description>
		/// </item>
		/// <item>
		/// <description>IME_PROP_UNICODE</description>
		/// <description>
		/// If set, the IME is viewed as a UnicodeIME. The system and the IME will communicate through the UnicodeIME interface. If clear,
		/// IME will use the ANSI interface to communicate with the system.
		/// </description>
		/// </item>
		/// <item>
		/// <description>IME_PROP_COMPLETE_ON_UNSELECT</description>
		/// <description>If set, conversion window is at the caret position. If clear, the window is near caret position.</description>
		/// </item>
		/// <item>
		/// <description>IME_PROP_ACCEPT_WIDE_VKEY</description>
		/// <description>
		/// If set, the IME processes the injected Unicode that came from the <c>SendInput</c> function by using VK_PACKET. If clear, the IME
		/// might not process the injected Unicode, and the injected Unicode might be sent to the application directly.
		/// </description>
		/// </item>
		/// </list>
		/// <para>If wParam is IGP_UI, it returns one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Requirement</description>
		/// <description>Value</description>
		/// </listheader>
		/// <item>
		/// <description>UI_CAP_2700</description>
		/// <description>Supports text escapement values of 0 or 2700. For more information, see <c>lfEscapement</c>.</description>
		/// </item>
		/// <item>
		/// <description>UI_CAP_ROT90</description>
		/// <description>Supports text escapement values of 0, 900, 1800, or 2700. For more information, see <c>lfEscapement</c>.</description>
		/// </item>
		/// <item>
		/// <description>UI_CAP_ROTANY</description>
		/// <description>Supports any text escapement value. For more information, see <c>lfEscapement</c>.</description>
		/// </item>
		/// </list>
		/// <para>If wParam is IGP_SETCOMPSTR, it returns one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Requirement</description>
		/// <description>Value</description>
		/// </listheader>
		/// <item>
		/// <description>SCS_CAP_COMPSTR</description>
		/// <description>
		/// Can create the composition string by calling the <c>ImmSetCompositionString</c> function with the SCS_SETSTR value.
		/// </description>
		/// </item>
		/// <item>
		/// <description>SCS_CAP_MAKEREAD</description>
		/// <description>
		/// Can create the reading string from corresponding composition string when using the <c>ImmSetCompositionString</c> function with
		/// SCS_SETSTR and without setting <c>lpRead</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description>SCS_CAP_SETRECONVERTSTRING</description>
		/// <description>This IME can support reconversion. Use <c>ImmSetCompositionString</c> to do the reconversion.</description>
		/// </item>
		/// </list>
		/// <para>If wParam is IGP_SELECT, it returns one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Requirement</description>
		/// <description>Value</description>
		/// </listheader>
		/// <item>
		/// <description>SELECT_CAP_CONVMODE</description>
		/// <description>Inherits conversion mode when a new IME is selected.</description>
		/// </item>
		/// <item>
		/// <description>SELECT_CAP_SENTENCE</description>
		/// <description>Inherits sentence mode when a new IME is selected.</description>
		/// </item>
		/// </list>
		/// <para>If wParam is IGP_GETIMEVERSION, it returns one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Requirement</description>
		/// <description>Value</description>
		/// </listheader>
		/// <item>
		/// <description>IMEVER_0310</description>
		/// <description>The IME was created for Windows 3.1.</description>
		/// </item>
		/// <item>
		/// <description>IMEVER_0400</description>
		/// <description>The IME was created for Windows 95 or later</description>
		/// </item>
		/// </list>
		/// <para>
		/// This message is similar to <c>ImmGetProperty</c>, except that it uses the current input locale. The application should call
		/// <c>EM_ISIME</c> before calling this function.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getimeproperty
		[MsgParams(typeof(Imm32.IGP), null)]
		EM_GETIMEPROPERTY = WindowMessage.WM_USER + 244,

		/// <summary>Undocumented</summary>
		EM_GETQUERYRTFOBJ = WindowMessage.WM_USER + 269,

		/// <summary>Undocumented</summary>
		EM_SETQUERYRTFOBJ = WindowMessage.WM_USER + 270,

		/// <summary>
		/// Gets a pointer to the application-defined AutoCorrectProc function.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns a pointer to the application-defined AutoCorrectProc function.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getautocorrectproc
		[MsgParams(LResultType = typeof(AutoCorrectProc))]
		EM_GETAUTOCORRECTPROC = WindowMessage.WM_USER + 233,

		/// <summary>
		/// Defines the current autocorrect callback procedure.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The AutoCorrectProc callback function.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero</para>
		/// <para><strong>Returns</strong></para>
		/// <para>If the operation succeeds, the return value is zero. If the operation fails, the return value is a nonzero value.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setautocorrectproc
		[MsgParams(typeof(AutoCorrectProc), null)]
		EM_SETAUTOCORRECTPROC = WindowMessage.WM_USER + 234,

		/// <summary>
		/// Calls the autocorrect callback function that is stored by the <c>EM_SETAUTOCORRECTPROC</c> message, provided that the text
		/// preceding the insertion point is a candidate for autocorrection.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>
		/// A character of type <c>WCHAR</c>. If this character is a tab (U+0009), and the character preceding the insertion point isn t a
		/// tab, then the character preceding the insertion point is treated as part of the autocorrect candidate string instead of as a
		/// string delimiter; otherwise, wParam has no effect.
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is zero if the message succeeds, or nonzero if an error occurs.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-callautocorrectproc
		[MsgParams(typeof(char), null)]
		EM_CALLAUTOCORRECTPROC = WindowMessage.WM_USER + 255,

		/// <summary>
		/// Retrieves the table parameters for a table row and the cell parameters for the specified number of cells.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A pointer to a <c>TABLEROWPARMS</c> structure.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>TABLECELLPARMS</c> structure.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns S_OK if successful, or one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>
		/// Changes cannot be made. This can occur if the control is a plain-text or single-line control, or if the insertion point is inside
		/// a math object. It also occurs if tables are disabled if the <c>EM_SETEDITSTYLEEX</c> message sets the <c>SES_EX_NOTABLE</c> value.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>
		/// The <c>wParam</c> or <c>lParam</c> is NULL or points to an invalid structure. The <c>cbRow</c> member of the <c>TABLEROWPARMS</c>
		/// structure must equal
		/// <code>sizeof(TABLEROWPARMS)</code>
		/// or sizeof(TABLEROWPARMS) 2*sizeof(long). The latter value is the size of the RichEdit 4.1 <c>TABLEROWPARMS</c> structure. The
		/// <c>cbCell</c> member of the <c>TABLEROWPARMS</c> structure must equal
		/// <code>sizeof(TABLECELLPARMS)</code>
		/// . The query character position must be at a table row delimiter.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>E_OUTOFMEMORY</c></description>
		/// <description>Insufficient memory is available.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This message gets the table parameters for the row at the character position specified by the <c>cpStartRow</c> member of the
		/// <c>TABLEROWPARMS</c> structure, and the number of cells specified by the <c>cCells</c> member of the <c>TABLECELLPARMS</c> structure.
		/// </para>
		/// <para>
		/// The character position specified by the <c>cpStartRow</c> member of the <c>TABLEROWPARMS</c> structure should be at the start of
		/// the table row, or at the end delimiter of the table row. If <c>cpStartRow</c> is set to 1, the character position is given by the
		/// current selection. In this case, position the selection at the end of the row (between the cell mark and the end delimiter of the
		/// table row), or select the row.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-gettableparms
		[MsgParams(typeof(TABLEROWPARMS?), typeof(TABLECELLPARMS?), LResultType = typeof(HRESULT))]
		EM_GETTABLEPARMS = WindowMessage.WM_USER + 265,

		/// <summary>
		/// Sets the current extended edit style flags.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Specifies one or more extended edit style flags. For a list of possible values, see <c>EM_GETEDITSTYLEEX</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A mask consisting of one or more of the wParam values. Only the values specified in this mask will be set or cleared. This allows
		/// a single flag to be set or cleared without reading the current flag states.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// The return value is the state of the extended edit style flags after rich edit has attempted to implement your edit style
		/// changes. The edit style flags are a set of flags that indicate the current edit style.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-seteditstyleex
		[MsgParams(typeof(SES_EX), typeof(SES_EX), LResultType = typeof(SES_EX))]
		EM_SETEDITSTYLEEX = WindowMessage.WM_USER + 275,

		/// <summary>
		/// Retrieves the current extended edit style flags.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the extended edit style flags, which can include one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>SES_EX_HANDLEFRIENDLYURL</c></description>
		/// <description>
		/// Display friendly name links with the same text color and underlining as automatic links, provided that temporary formatting isn t
		/// used or uses text autocolor (default: 0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_EX_MULTITOUCH</c></description>
		/// <description>
		/// Enable touch support in Rich Edit. This includes selection, caret placement, and context-menu invocation. When this flag is not
		/// set, touch is emulated by mouse commands, which do not take touch-mode specifics into account (default: 0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_EX_NOACETATESELECTION</c></description>
		/// <description>
		/// Display selected text using classic Windows selection text and background colors instead of background acetate color (default: 0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_EX_NOMATH</c></description>
		/// <description>
		/// Disable insertion of math zones (default: 1). To enable math editing and display, send the <c>EM_SETEDITSTYLEEX</c> message with
		/// <c>wParam</c> set to 0, and <c>lParam</c> set to <c>SES_EX_NOMATH</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_EX_NOTABLE</c></description>
		/// <description>
		/// Disable insertion of tables. The <c>EM_INSERTTABLE</c> message returns <c>E_FAIL</c> and RTF tables are skipped (default: 0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_EX_USESINGLELINE</c></description>
		/// <description>
		/// Enable a multiline control to act like a single-line control with the ability to scroll vertically when the single-line height is
		/// greater than the window height (default: 0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_HIDETEMPFORMAT</c></description>
		/// <description>
		/// Hide temporary formatting that is created when <c>ITextFont.Reset</c> is called with <c>tomApplyTmp</c>. For example, such
		/// formatting is used by spell checkers to display a squiggly underline under possibly misspelled words.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>SES_EX_USEMOUSEWPARAM</c></description>
		/// <description>Use <c>wParam</c> when handling the <c>WM_MOUSEMOVE</c> message and do not call <c>GetAsyncKeyState</c>.</description>
		/// </item>
		/// </list>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-geteditstyleex
		[MsgParams(LResultType = typeof(SES_EX))]
		EM_GETEDITSTYLEEX = WindowMessage.WM_USER + 276,

		/// <summary>
		/// Gets the story type.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The story index.</para>
		/// <para><em>lParam</em></para>
		/// <para>Reserved; must be 0.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns the story type, which can be a client-defined custom value, or one of the following values:</para>
		/// <list type="bullet">
		/// <item>tomCommentsStory</item>
		/// <item>tomEndnotesStory</item>
		/// <item>tomEvenPagesFooterStory</item>
		/// <item>tomEvenPagesHeaderStory</item>
		/// <item>tomFindStory</item>
		/// <item>tomFirstPageFooterStory</item>
		/// <item>tomFirstPageHeaderStory</item>
		/// <item>tomFootnotesStory</item>
		/// <item>tomMainTextStory</item>
		/// <item>tomPrimaryFooterStory</item>
		/// <item>tomPrimaryHeaderStory</item>
		/// <item>tomReplaceStory</item>
		/// <item>tomScratchStory</item>
		/// <item>tomTextFrameStory</item>
		/// <item>tomUnknownStory</item>
		/// </list>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getstorytype
		[MsgParams(typeof(int), null, LResultType = typeof(int))]
		EM_GETSTORYTYPE = WindowMessage.WM_USER + 290,

		/// <summary>
		/// Sets the story type.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The story index.</para>
		/// <para><em>lParam</em></para>
		/// <para>The new story type. For a list of story types, see <c>EM_GETSTORYTYPE</c>.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The story type that was set.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setstorytype
		[MsgParams(typeof(int), typeof(int), LResultType = typeof(int))]
		EM_SETSTORYTYPE = WindowMessage.WM_USER + 291,

		/// <summary>
		/// Retrieves the current ellipsis mode. When enabled, an ellipsis ( ) is displayed for text that doesn t fit in the display window.
		/// The ellipsis is only used when the control is not active. When active, scroll bars are used to reveal text that doesn t fit into
		/// the display window.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a DWORD which receives one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>ELLIPSIS_NONE</c></description>
		/// <description>No ellipsis is used.</description>
		/// </item>
		/// <item>
		/// <description><c>ELLIPSIS_END</c></description>
		/// <description>Ellipsis at the end (forced break).</description>
		/// </item>
		/// <item>
		/// <description><c>ELLIPSIS_WORD</c></description>
		/// <description>Ellipsis at the end (word break).</description>
		/// </item>
		/// </list>
		/// <para><strong>Returns</strong></para>
		/// <para>If wparam is 0 and lparam is not NULL, the return value equals TRUE; otherwise, the return value equals FALSE.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getellipsismode
		[MsgParams(null, typeof(ELLIPSIS?), LResultType = typeof(BOOL))]
		EM_GETELLIPSISMODE = WindowMessage.WM_USER + 305,

		/// <summary>
		/// This message sets the current ellipsis mode. When enabled, an ellipsis ( ) is displayed for text that doesn t fit in the display
		/// window. The ellipsis is only used when the control isn t active. When active, scroll bars are used to reveal text that doesn t
		/// fit into the display window.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A DWORD which receives one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>ELLIPSIS_NONE</c></description>
		/// <description>No ellipsis is used.</description>
		/// </item>
		/// <item>
		/// <description><c>ELLIPSIS_END</c></description>
		/// <description>Ellipsis at the end (forced break).</description>
		/// </item>
		/// <item>
		/// <description><c>ELLIPSIS_WORD</c></description>
		/// <description>Ellipsis at the end (word break).</description>
		/// </item>
		/// </list>
		/// <para>The bits for these values all fit in the <c>ELLIPSIS_MASK</c>.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// If wparam is 0 and lparam is one of the values in the table above, the return value equals TRUE; otherwise, the return value
		/// equals FALSE.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setellipsismode
		[MsgParams(null, typeof(ELLIPSIS), LResultType = typeof(BOOL))]
		EM_SETELLIPSISMODE = WindowMessage.WM_USER + 306,

		/// <summary>
		/// Changes the parameters of rows in a table.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>A pointer to a <c>TABLEROWPARMS</c> structure.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>TABLECELLPARMS</c> structure.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns S_OK if successful, or one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>
		/// Changes cannot be made. This can occur if the control is a plain-text or single-line control, or if the insertion point is inside
		/// a math object. It also occurs if tables are disabled, or if the <c>EM_SETEDITSTYLEEX</c> message sets the <c>SES_EX_NOTABLE</c> value.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>
		/// The <c>wParam</c> or <c>lParam</c> is NULL or points to an invalid structure. The <c>cCell</c> member of the <c>TABLEROWPARMS</c>
		/// structure must be at least 1 and not more than 63. The <c>cbRow</c> member must equal
		/// <code>sizeof(TABLEROWPARMS)</code>
		/// or
		/// <code>sizeof(TABLEROWPARMS) 2*sizeof(long)</code>
		/// . The latter value is the size of the RichEdit 4.1 <c>TABLEROWPARMS</c> structure. The <c>cbCell</c> member of
		/// <c>TABLEROWPARMS</c> must equal
		/// <code>sizeof(TABLECELLPARMS)</code>
		/// . The insertion point must be at the start of a table or inside a table row, and the number of cells can only change by one.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>E_OUTOFMEMORY</c></description>
		/// <description>Insufficient memory is available.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// This message changes the parameters of the number of rows specified by the <c>cRow</c> member of the <c>TABLEROWPARMS</c>
		/// structure, if the table has that many consecutive rows. If <c>cRow</c> is less than 0, the message iterates until the end of the
		/// table. If the new cell count differs from the current cell count by +1 or 1, it inserts or deletes the cell at the index
		/// specified by the <c>iCell</c> member of <c>TABLEROWPARMS</c>. The starting table row is identified by a character position. This
		/// position is specified by <c>cpStartRow</c> members with values that are greater than or equal to zero. The position should be
		/// inside the table row, but not inside a nested table, unless you want to change that table s parameters. If the <c>cpStartRow</c>
		/// member is 1, the character position is given by the current selection. For this, position the selection anywhere inside the table
		/// row, or select the row with the active end of the selection at the end of the table row.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-settableparms
		[MsgParams(typeof(TABLEROWPARMS?), typeof(TABLECELLPARMS?), LResultType = typeof(HRESULT))]
		EM_SETTABLEPARMS = WindowMessage.WM_USER + 307,

		/// <summary>
		/// Retrieves the touch options that are associated with a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The touch options to retrieve. It can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>RTO_SHOWHANDLES</c></description>
		/// <description>Retrieves whether the touch grippers are visible.</description>
		/// </item>
		/// <item>
		/// <description><c>RTO_DISABLEHANDLES</c></description>
		/// <description>Retrieving this flag is not implemented.</description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>
		/// Returns the value of the option specified by the wParam parameter. It is nonzero if wParam is <c>RTO_SHOWHANDLES</c> and the
		/// touch grippers are visible; zero, otherwise.
		/// </para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-gettouchoptions
		[MsgParams(typeof(RTO), null)]
		EM_GETTOUCHOPTIONS = WindowMessage.WM_USER + 310,

		/// <summary>
		/// Sets the touch options associated with a rich edit control.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The touch option to set. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>RTO_SHOWHANDLES</c></description>
		/// <description>Show or hide the touch gripper handles, depending on the value of <c>lParam</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>RTO_DISABLEHANDLES</c></description>
		/// <description>
		/// Enable or disable the touch gripper handles, depending on the value of <c>lParam</c>. When handles are disabled, they are hidden
		/// if they are visible and remain hidden until an <c>EM_SETTOUCHOPTIONS</c> message changes their status.
		/// </description>
		/// </item>
		/// </list>
		/// <para><em>lParam</em></para>
		/// <para>Set to <c>TRUE</c> to show/enable the touch selection handles, or <c>FALSE</c> to hide/disable the touch selection handles.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This message returns zero.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-settouchoptions
		[MsgParams(typeof(RTO), typeof(BOOL))]
		EM_SETTOUCHOPTIONS = WindowMessage.WM_USER + 311,

		/// <summary>
		/// Replaces the selection with a blob that displays an image.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>RICHEDIT_IMAGE_PARAMETERS</c> structure that contains the image blob.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Returns S_OK if successful, or one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>E_FAIL</c></description>
		/// <description>Cannot insert the image.</description>
		/// </item>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>The <c>lParam</c> parameter is NULL or points to an invalid image.</description>
		/// </item>
		/// <item>
		/// <description><c>E_OUTOFMEMORY</c></description>
		/// <description>Insufficient memory is available.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>If the selection is an insertion point, the image blob is inserted at the insertion point.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-insertimage
		[MsgParams(null, typeof(RICHEDIT_IMAGE_PARAMETERS?), LResultType = typeof(HRESULT))]
		EM_INSERTIMAGE = WindowMessage.WM_USER + 314,

		/// <summary>
		/// Sets the name of a rich edit control for UI Automation (UIA).
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to the null-terminated name string.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>TRUE if the name for UIA is successfully set, otherwise FALSE.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-setuianame
		[MsgParams(null, typeof(IntPtr), LResultType = typeof(BOOL))]
		EM_SETUIANAME = WindowMessage.WM_USER + 320,

		/// <summary>
		/// Retrieves the current ellipsis state.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Not used; must be zero.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is TRUE if an ellipsis is being displayed and FALSE otherwise.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/em-getellipsisstate
		[MsgParams(LResultType = typeof(BOOL))]
		EM_GETELLIPSISSTATE = WindowMessage.WM_USER + 322,
	}

	/// <summary>
	/// Notification codes sent by a rich edit control to its parent window. These are in addition to the standard notification codes.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/controls/bumper-rich-edit-control-reference-notifications
	[PInvokeData("richedit.h")]
	public enum RichEditNotification
	{
		/// <summary>
		/// Notifies a rich edit control's parent window that the paragraph direction has changed to left-to-right. A rich edit control sends
		/// this notification code in the form of a <c>WM_COMMAND</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The <c>LOWORD</c> contains the identifier of the rich edit control. The <c>HIWORD</c> specifies the notification code.</para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the rich edit control.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This notification code does not return a value.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-alignltr
		[MsgParams(typeof(uint), typeof(HWND))]
		EN_ALIGNLTR = 0x0710,

		/// <summary>
		/// Notifies a rich edit control's parent window that the paragraph direction changed to right-to-left. A rich edit control sends
		/// this notification code in the form of a <c>WM_COMMAND</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The <c>LOWORD</c> contains the identifier of the rich edit control. The <c>HIWORD</c> specifies the notification code.</para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the rich edit control.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This notification code does not return a value.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-alignrtl
		[MsgParams(typeof(uint), typeof(HWND))]
		EN_ALIGNRTL = 0x0711,

		/// <summary>
		/// Notifies a rich edit control's parent window that a paste occurred with a particular clipboard format. A windowless rich edit
		/// control sends this notification by using the <c>ITextHost::TxNotify</c> method.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The window ID retrieved by calling the <c>GetWindowLong</c> function with the GWL_ID value.</para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to a <c>CLIPBOARDFORMAT</c> structure that contains information about the clipboard format.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>The return value is ignored.</para>
		/// </summary>
		/// <remarks>
		/// To receive EN_CLIPFORMAT notification codes, specify <c>ENM_CLIPFORMAT</c> in the mask sent with the <c>EM_SETEVENTMASK</c> message.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-clipformat
		[MsgParams(typeof(int), typeof(CLIPBOARDFORMAT?))]
		EN_CLIPFORMAT = 0x0712,

		/// <summary>
		/// Notifies a rich edit control parent window that a SYV_CORRECT gesture occurred, giving the parent window a chance to cancel
		/// correcting the text. A rich edit control sends this notification code in the form of a <c>WM_NOTIFY</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>An <c>ENCORRECTTEXT</c> structure specifying the selection to be corrected.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return zero to ignore the action.</para>
		/// <para>Returns a nonzero value to process the action.</para>
		/// </summary>
		/// <remarks>
		/// <para>This notification code is sent only if pen capabilities are available.</para>
		/// <para>
		/// To receive EN_CORRECTTEXT notification codes, specify <c>ENM_CORRECTTEXT</c> in the mask sent with the <c>EM_SETEVENTMASK</c> message.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// The EN_CORRECTTEXT notification code is only supported in rich edit version 1.0. It is not supported in later versions of rich
		/// edit. For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-correcttext
		[MsgParams(null, typeof(ENCORRECTTEXT?))]
		EN_CORRECTTEXT = 0x0705,

		/// <summary>
		/// Notifies a rich edit control's parent window that the drag-and-drop operation has completed. A rich edit control sends this
		/// notification code in the form of a <c>WM_NOTIFY</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>An <c>NMHDR</c> structure.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This notification code does not return a value.</para>
		/// </summary>
		/// <remarks>
		/// To receive an EN_DRAGDROPDONE notification code, specify the <c>ENM_DRAGDROPDONE</c> flag in the mask sent with the
		/// <c>EM_SETEVENTMASK</c> message.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-dragdropdone
		[MsgParams(null, typeof(NMHDR?))]
		EN_DRAGDROPDONE = 0x070c,

		/// <summary>
		/// Notifies a rich edit control parent window that the user is attempting to drop files into the control. A rich edit control sends
		/// this notification code in the form of a <c>WM_NOTIFY</c> message when it receives the <c>WM_DROPFILES</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>An <c>ENDROPFILES</c> structure that receives dropped files information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return a nonzero value to allow the drop operation.</para>
		/// <para>Return zero to ignore the drop operation.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// For a rich edit control to receive <c>WM_DROPFILES</c> messages, the parent window must register the control as a drop target by
		/// using the <c>DragAcceptFiles</c> function. The control does not register itself.
		/// </para>
		/// <para>
		/// To receive EN_DROPFILES notification codes, specify <c>ENM_DROPFILES</c> in the mask sent with the <c>EM_SETEVENTMASK</c> message.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-dropfiles
		[MsgParams(null, typeof(ENDROPFILES?))]
		EN_DROPFILES = 0x0703,

		/// <summary>
		/// Notifies a rich edit control parent window that the user has entered new data or has finished entering data while using IME or
		/// Text Services Framework.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>A <c>ENDCOMPOSITIONNOTIFY</c> structure that receives information about the end composition condition.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-endcomposition
		[MsgParams(null, typeof(ENDCOMPOSITIONNOTIFY?))]
		EN_ENDCOMPOSITION = 0x0714,

		/// <summary>
		/// Notifies a rich edit control's parent that the IME conversion status has changed. This notification code is available only for
		/// Asian-language versions of the operating system. A rich edit control sends this notification code in the form of a
		/// <c>WM_COMMAND</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The <c>LOWORD</c> contains the identifier of the rich edit control. The <c>HIWORD</c> specifies the notification code.</para>
		/// <para><em>lParam</em></para>
		/// <para>Handle to the rich edit control.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This notification code returns zero.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To receive EN_IMECHANGE notification codes, specify <c>ENM_IMECHANGE</c> in the mask sent with the <c>EM_SETEVENTMASK</c> message.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// This notification code is only supported in the Asian version of Rich Edit 1.0. It is not supported in later versions. For
		/// information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
		/// </para>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-imechange
		[MsgParams(typeof(uint), typeof(HWND))]
		EN_IMECHANGE = 0x0707,

		/// <summary>
		/// A rich edit control sends EN_LINK notification codes when it receives various messages, for example, when the user clicks the
		/// mouse or when the mouse pointer is over text that has the <c>CFE_LINK</c> effect. A windowless rich edit control sends this
		/// notification by using the <c>ITextHost::TxNotify</c> method. The parent window of the control receives this notification code
		/// through a <c>WM_NOTIFY</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>wParam</em></para>
		/// <para>The window ID retrieved by calling the <c>GetWindowLong</c> function with the GWL_ID value.</para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// Pointer to an <c>ENLINK</c> structure. The structure contains an <c>NMHDR</c> structure, information about the notification code,
		/// and a <c>CHARRANGE</c> structure that indicates the range of characters that have the <c>CFE_LINK</c> effect.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return zero to allow the control to proceed with its normal handling of the message.</para>
		/// <para>Return a nonzero value to prevent the control from handling the message.</para>
		/// <para><c>Windows 8</c>: Return <c>EN_LINK_DO_DEFAULT</c> to direct the rich edit control to perform the default action.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To receive <c>EN_LINK</c> notification codes when the link has focus, specify the <c>ENM_LINK</c> flag in the mask sent with the
		/// <c>EM_SETEVENTMASK</c> message.
		/// </para>
		/// <para>
		/// If the link has no focus, to receive <c>EN_LINK</c> notification codes specify the <c>SES_NOFOCUSLINKNOTIFY</c> flag in the mask
		/// sent with the <c>EM_SETEDITSTYLE</c> message.
		/// </para>
		/// <para>
		/// A rich edit control sends <c>EN_LINK</c> notification codes when it receives the following messages while the mouse pointer is
		/// over text that has the <c>CFE_LINK</c> effect:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>WM_LBUTTONDBLCLK</c></description>
		/// </item>
		/// <item>
		/// <description><c>WM_LBUTTONDOWN</c></description>
		/// </item>
		/// <item>
		/// <description><c>WM_LBUTTONUP</c></description>
		/// </item>
		/// <item>
		/// <description><c>WM_MOUSEMOVE</c></description>
		/// </item>
		/// <item>
		/// <description><c>WM_RBUTTONDBLCLK</c></description>
		/// </item>
		/// <item>
		/// <description><c>WM_RBUTTONDOWN</c></description>
		/// </item>
		/// <item>
		/// <description><c>WM_RBUTTONUP</c></description>
		/// </item>
		/// <item>
		/// <description><c>WM_SETCURSOR</c></description>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>CFE_LINK</c> effect typically identifies a range of text that contains an URL. Applications can handle the EN_LINK
		/// notification code by changing the mouse pointer when it is over the URL, or by starting a browser to view the location identified
		/// by the URL.
		/// </para>
		/// <para>
		/// If you send the <c>EM_AUTOURLDETECT</c> message to enable automatic URL detection, the rich edit control automatically sets the
		/// <c>CFE_LINK</c> effect for modified text that it identifies as a URL.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-link
		[MsgParams(typeof(int), typeof(ENLINK?))]
		EN_LINK = 0x070b,

		/// <summary>
		/// Notifies the parent window of a Microsoft Rich Edit control that an unsupported Rich Text Format (RTF) keyword was received. A
		/// Rich Edit control sends this notification code in the form of a <c>WM_NOTIFY</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>The <c>ENLOWFIRTF</c> structure.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This notification code does not return a value.</para>
		/// </summary>
		/// <remarks>
		/// To receive an EN_LOWFIRTF notification, specify the ENM_LOWFIRTF flag in the mask sent with the <c>EM_SETEVENTMASK</c> message.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-lowfirtf
		[MsgParams(null, typeof(ENLOWFIRTF?))]
		EN_LOWFIRTF = 0x070f,

		/// <summary>
		/// Notifies a rich edit control's parent window of a keyboard or mouse event in the control. A rich edit control sends this
		/// notification code in the form of a <c>WM_NOTIFY</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>
		/// A <c>MSGFILTER</c> structure containing information about the keyboard or mouse message. If the parent window modifies this
		/// structure and returns a nonzero value, the modified message is processed instead of the original one.
		/// </para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return zero if the control should process the keyboard or mouse event.</para>
		/// <para>Return nonzero if the control should ignore the keyboard or mouse event.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To receive EN_MSGFILTER notification codes for events, specify one or more of the following flags in the mask sent with the
		/// <c>EM_SETEVENTMASK</c> message.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Flag</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>ENM_KEYEVENTS</c></description>
		/// <description>To receive notification codes for keyboard events.</description>
		/// </item>
		/// <item>
		/// <description><c>ENM_MOUSEEVENTS</c></description>
		/// <description>To receive notification codes for mouse events.</description>
		/// </item>
		/// <item>
		/// <description><c>ENM_SCROLLEVENTS</c></description>
		/// <description>To receive notification codes for a mouse wheel event.</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-msgfilter
		[MsgParams(null, typeof(MSGFILTER?))]
		EN_MSGFILTER = 0x0700,

		/// <summary>
		/// Notifies a rich edit control's parent window when the control reads in objects. A rich edit control sends this notification code
		/// in the form of a <c>WM_NOTIFY</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>An <c>OBJECTPOSITIONS</c> structure.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return zero to continue the <c>Read</c> operation.</para>
		/// <para>Return a nonzero value to stop the <c>Read</c> operation.</para>
		/// </summary>
		/// <remarks>
		/// To receive an EN_OBJECTPOSITIONS notification code, specify the <c>ENM_OBJECTPOSITIONS</c> flag in the mask sent with the
		/// <c>EM_SETEVENTMASK</c> message.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-objectpositions
		[MsgParams(null, typeof(OBJECTPOSITIONS?))]
		EN_OBJECTPOSITIONS = 0x070a,

		/// <summary>
		/// Notifies a rich edit control's parent window that a user action on a Component Object Model (COM) object has failed. A rich edit
		/// control sends this notification code in the form of a <c>WM_NOTIFY</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>An <c>ENOLEOPFAILED</c> structure that contains information about the failure.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This notification code returns zero.</para>
		/// </summary>
		/// <remarks>
		/// The parent window will always get a <c>WM_NOTIFY</c> message for this event, it does not require a notification mask sent with <c>EM_SETEVENTMASK</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-oleopfailed
		[MsgParams(null, typeof(ENOLEOPFAILED?))]
		EN_OLEOPFAILED = 0x0709,

		/// <summary>
		/// Notifies a windowless rich edit control's host window that a change has occurred. A rich edit control sends this notification
		/// code in the form of a <c>WM_NOTIFY</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>A <c>CHANGENOTIFY</c> structure specifying the change that was made.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This notification code does not return a value.</para>
		/// </summary>
		/// <remarks>
		/// To receive EN_CHANGE notification codes, specify <c>ENM_CHANGE</c> in the mask sent with the <c>EM_SETEVENTMASK</c> message.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-change--rich-edit-control-
		[MsgParams(null, typeof(CHANGENOTIFY?))]
		EN_PAGECHANGE = 0x070e,

		/// <summary>
		/// Notifies a rich edit control's parent that an outline has been expanded. A rich edit control sends this notification code in the
		/// form of a <c>WM_NOTIFY</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>An <c>NMHDR</c> structure.</para>
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-paragraphexpanded
		[MsgParams(null, typeof(NMHDR?))]
		EN_PARAGRAPHEXPANDED = 0x070d,

		/// <summary>
		/// Notifies a rich edit control's parent window that the user is taking an action that would change a protected range of text. A
		/// rich edit control sends this notification code in the form of a <c>WM_NOTIFY</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>An <c>ENPROTECTED</c> structure containing information about the message that triggered the notification code.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return zero to allow the operation.</para>
		/// <para>Return a nonzero value to prevent the operation.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If zero is returned and the <c>msg</c>, <c>wParam</c>, and <c>lParam</c> members of the <c>ENPROTECTED</c> structure are changed,
		/// the control processes the revised message instead of the original message.
		/// </para>
		/// <para>
		/// To receive EN_PROTECTED notification codes, specify <c>ENM_PROTECTED</c> in the mask sent with the <c>EM_SETEVENTMASK</c> message.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-protected
		[MsgParams(null, typeof(ENPROTECTED?))]
		EN_PROTECTED = 0x0704,

		/// <summary>
		/// Notifies a rich edit control's parent window that the control's contents are either smaller or larger than the control's window
		/// size. A rich edit control sends this notification code in the form of a <c>WM_NOTIFY</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>A <c>REQRESIZE</c> structure that receives the requested size.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This notification code does not return a value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To support the bottomless behavior of a rich edit control, the parent window must resize the control when it receives this
		/// notification code.
		/// </para>
		/// <para>
		/// To receive EN_REQUESTRESIZE notification codes, specify <c>ENM_REQUESTRESIZE</c> in the mask sent with the <c>EM_SETEVENTMASK</c> message.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-requestresize
		[MsgParams(null, typeof(REQRESIZE?))]
		EN_REQUESTRESIZE = 0x0701,

		/// <summary>
		/// Notifies the rich edit control's parent window that the control is closing and the clipboard contains information. A rich edit
		/// control sends this notification code in the form of a <c>WM_NOTIFY</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>An <c>ENSAVECLIPBOARD</c> structure that contains information about clipboard information.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return zero if the clipboard should be made available to other applications.</para>
		/// <para>Return a nonzero value if the clipboard should not be saved.</para>
		/// </summary>
		/// <remarks>
		/// The parent window will always get a <c>WM_NOTIFY</c> message for this event, it does not require a notification mask sent with <c>EM_SETEVENTMASK</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-saveclipboard
		[MsgParams(null, typeof(ENSAVECLIPBOARD?))]
		EN_SAVECLIPBOARD = 0x0708,

		/// <summary>
		/// Notifies a rich edit control's parent window that the current selection has changed. A rich edit control sends this notification
		/// code in the form of a <c>WM_NOTIFY</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>A <c>SELCHANGE</c> structure that receives information about the selection.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>This notification code does not return a value.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To receive EN_SELCHANGE notification codes, specify <c>ENM_SELCHANGE</c> in the mask sent with the <c>EM_SETEVENTMASK</c> message.
		/// </para>
		/// <para>
		/// This notification code is sent when the caret position changes and no text is selected (the selection is empty). The caret
		/// position can change when the user clicks the mouse, types, or presses an arrow key.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-selchange
		[MsgParams(null, typeof(SELCHANGE?))]
		EN_SELCHANGE = 0x0702,

		/// <summary>Notifies a rich edit control parent window that the user started typing with IME or Text Services Framework.</summary>
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>An <c>NMHDR</c> structure.</para>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-startcomposition
		[MsgParams(null, typeof(NMHDR?))]
		EN_STARTCOMPOSITION = 0x0713,

		/// <summary>
		/// Notifies a rich edit control's parent window that an action occurred for which the control cannot allocate enough memory to
		/// maintain the undo state. A rich edit control sends this notification code in the form of a <c>WM_NOTIFY</c> message.
		/// <para><strong>Parameters</strong></para>
		/// <para><em>lParam</em></para>
		/// <para>An <c>NMHDR</c> structure.</para>
		/// <para><strong>Returns</strong></para>
		/// <para>Return zero to continue the <c>Undo</c> operation.</para>
		/// <para>Return a nonzero value to stop the <c>Undo</c> operation.</para>
		/// </summary>
		/// <remarks>
		/// The parent window will always get a <c>WM_NOTIFY</c> message for this event, it does not require a notification mask sent with <c>EM_SETEVENTMASK</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/controls/en-stopnoundo
		[MsgParams(null, typeof(NMHDR?))]
		EN_STOPNOUNDO = 0x0706,
	}

	/// <summary>Styles for the rich edit control.</summary>
	[PInvokeData("Winuser.h", MSDNShortId = "edit_control_constants")]
	[Flags]
	public enum RichEditStyle : uint
	{
		/// <summary>Left aligns text.</summary>
		ES_LEFT = 0x0000,

		/// <summary>Centers text in a single-line or multiline edit control.</summary>
		ES_CENTER = 0x0001,

		/// <summary>Right aligns text in a single-line or multiline edit control.</summary>
		ES_RIGHT = 0x0002,

		/// <summary>Designates a multiline edit control. The default is single-line edit control.</summary>
		ES_MULTILINE = 0x0004,

		/// <summary>
		/// Displays an asterisk (*) for each character typed into the edit control. This style is valid only for single-line edit controls.
		/// </summary>
		ES_PASSWORD = 0x0020,

		/// <summary>Automatically scrolls text up one page when the user presses the ENTER key on the last line.</summary>
		ES_AUTOVSCROLL = 0x0040,

		/// <summary>
		/// Automatically scrolls text to the right by 10 characters when the user types a character at the end of the line. When the user
		/// presses the ENTER key, the control scrolls all text back to position zero.
		/// </summary>
		ES_AUTOHSCROLL = 0x0080,

		/// <summary>
		/// Negates the default behavior for an edit control. The default behavior hides the selection when the control loses the input focus
		/// and inverts the selection when the control receives the input focus. If you specify ES_NOHIDESEL, the selected text is inverted,
		/// even if the control does not have the focus.
		/// </summary>
		ES_NOHIDESEL = 0x0100,

		/// <summary>Prevents the user from typing or editing text in the edit control.</summary>
		ES_READONLY = 0x0800,

		/// <summary>
		/// Specifies that a carriage return be inserted when the user presses the ENTER key while entering text into a multiline edit
		/// control in a dialog box. If you do not specify this style, pressing the ENTER key has the same effect as pressing the dialog
		/// box's default push button. This style has no effect on a single-line edit control.
		/// </summary>
		ES_WANTRETURN = 0x1000,

		/// <summary>Allows only digits to be entered into the edit control.</summary>
		ES_NUMBER = 0x2000,

		/// <summary>
		/// Preserves the selection when the control loses the focus. By default, the entire contents of the control are selected when it
		/// regains the focus.
		/// </summary>
		ES_SAVESEL = 0x00008000,

		/// <summary>Displays the control with a sunken border style so that the rich edit control appears recessed into its parent window.</summary>
		ES_SUNKEN = 0x00004000,

		/// <summary>Disables scroll bars instead of hiding them when they are not needed.</summary>
		ES_DISABLENOSCROLL = 0x00002000,

		/// <summary>
		/// Adds space to the left margin where the cursor changes to a right-up arrow, allowing the user to select full lines of text.
		/// </summary>
		ES_SELECTIONBAR = 0x01000000,

		/// <summary>Disables support for drag-drop of OLE objects.</summary>
		ES_NOOLEDRAGDROP = 0x00000008,

		/// <summary>
		/// Prevents the control from calling the OleInitialize function when created. This window style is useful only in dialog templates
		/// because CreateWindowEx does not accept this style.
		/// </summary>
		ES_EX_NOCALLOLEINIT = 0x00000000,

		/// <summary>Draws text and objects in a vertical direction. This style is available for Asian-language support only.</summary>
		ES_VERTICAL = 0x00400000,

		/// <summary>Disables the IME operation. This style is available for Asian language support only.</summary>
		ES_NOIME = 0x00080000,

		/// <summary>
		/// Directs the rich edit control to allow the application to handle all IME operations. This style is available for Asian language
		/// support only.
		/// </summary>
		ES_SELFIME = 0x00040000,
	}

	/// <summary>The touch options to retrieve.</summary>
	[PInvokeData("richedit.h")]
	public enum RTO
	{
		/// <summary>Retrieves whether the touch grippers are visible.</summary>
		RTO_SHOWHANDLES = 1,

		/// <summary>Retrieving this flag is not implemented.</summary>
		RTO_DISABLEHANDLES = 2,

		/// <summary></summary>
		RTO_READINGMODE = 3,
	}
	/// <summary>EM_SETCHARFORMAT wParam masks</summary>
	[PInvokeData("richedit.h")]
	[Flags]
	public enum SCF : ushort
	{
		/// <summary>
		/// Applies the formatting to the current selection. If the selection is empty, the character formatting is applied to the insertion
		/// point, and the new character format is in effect only until the insertion point changes.
		/// </summary>
		SCF_SELECTION = 0x0001,

		/// <summary>
		/// Applies the formatting to the selected word or words. If the selection is empty but the insertion point is inside a word, the
		/// formatting is applied to the word. The SCF_WORD value must be used in conjunction with the SCF_SELECTION value.
		/// </summary>
		SCF_WORD = 0x0002,

		/// <summary>RichEdit 4.1: Sets the default font for the control.</summary>
		SCF_DEFAULT = 0x0000,

		/// <summary>Applies the formatting to all text in the control. Not valid with SCF_SELECTION or SCF_WORD.</summary>
		SCF_ALL = 0x0004,

		/// <summary>
		/// RichEdit 4.1: Used with SCF_SELECTION. Indicates that format came from a toolbar or other UI tool, so UI formatting rules should
		/// be used instead of literal formatting.
		/// </summary>
		SCF_USEUIRULES = 0x0008,

		/// <summary>
		/// RichEdit 4.1: Associates a font to a given script, thus changing the default font for that script. To specify the font, use the
		/// following members of CHARFORMAT2: yHeight, bCharSet, bPitchAndFamily, szFaceName, and lcid.
		/// </summary>
		SCF_ASSOCIATEFONT = 0x0010,

		/// <summary>
		/// RichEdit 4.1: Prevents keyboard switching to match the font. For example, if an Arabic font is set, normally the automatic
		/// keyboard feature for Bidi languages changes the keyboard to an Arabic keyboard.
		/// </summary>
		SCF_NOKBUPDATE = 0x0020,

		/// <summary>
		/// RichEdit 4.1: Associates a surrogate (plane-2) font to a given script, thus changing the default font for that script. To specify
		/// the font, use the following members of CHARFORMAT2: yHeight, bCharSet, bPitchAndFamily, szFaceName, and lcid.
		/// </summary>
		SCF_ASSOCIATEFONT2 = 0x0040,

		/// <summary>Apply the font only if it can handle script.</summary>
		SCF_SMARTFONT = 0x0080,

		/// <summary>Gets the character repertoire from the LCID.</summary>
		SCF_CHARREPFROMLCID = 0x0100,

		/// <summary>Prevents setting the default paragraph format when the rich edit control is empty.</summary>
		SPF_DONTSETDEFAULT = 0x0002,

		/// <summary>Sets the default paragraph formatting attributes.</summary>
		SPF_SETDEFAULT = 0x0004,
	}

	/// <summary>Value specifying the contents of the new selection.</summary>
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._encorrecttext")]
	[Flags]
	public enum SEL : ushort
	{
		/// <summary>No selection.</summary>
		SEL_EMPTY = 0x0000,

		/// <summary>The new selection contains text.</summary>
		SEL_TEXT = 0x0001,

		/// <summary>The new selection contains at least one COM object.</summary>
		SEL_OBJECT = 0x0002,

		/// <summary>The new selection contains more than one character of text.</summary>
		SEL_MULTICHAR = 0x0004,

		/// <summary>The new selection contains more than one COM object.</summary>
		SEL_MULTIOBJECT = 0x0008,
	}

	/// <summary>Edit style flags.</summary>
	[Flags]
	public enum SES : uint
	{
		/// <summary>Undocumented</summary>
		SES_ALLOWBEEPS = 256,

		/// <summary>Rich Edit will call the system beeper if the user attempts to enter more than the maximum characters.</summary>
		SES_BEEPONMAXTEXT = 2,

		/// <summary>
		/// Turns on bidirectional processing. This is automatically turned on by Rich Edit if any of the following window styles are active:
		/// WS_EX_RIGHT, WS_EX_RTLREADING, WS_EX_LEFTSCROLLBAR. However, this setting is useful for handling these window styles when using a
		/// custom implementation of ITextHost (default: 0).
		/// </summary>
		SES_BIDI = 4096,

		/// <summary>Windows XP with SP1: Allow embedded objects to be inserted using TSF (default: 0).</summary>
		SES_CTFALLOWEMBED = 0x00200000,

		/// <summary>Windows XP with SP1: Allows TSF proofing tips (default: 0).</summary>
		SES_CTFALLOWPROOFING = 0x00800000,

		/// <summary>Windows XP with SP1: Allows TSF SmartTag tips (default: 0).</summary>
		SES_CTFALLOWSMARTTAG = 0x00400000,

		/// <summary>Windows 8: Do not allow the TSF lock read/write access. This pauses TSF input.</summary>
		SES_CTFNOLOCK = 0x10000000,

		/// <summary>Undocumented</summary>
		SES_CUSTOMLOOK = 0x00080000,

		/// <summary>
		/// Windows 8: Fonts with an fi ligature are displayed with default OpenType features resulting in improved typography (default: 0).
		/// </summary>
		SES_DEFAULTLATINLIGA = 16,

		/// <summary>
		/// Windows XP with SP1: Use draft mode fonts to display text. Draft mode is an accessibility option where the control displays the
		/// text with a single font; the font is determined by the system setting for the font used in message boxes. For example, accessible
		/// users may read text easier if it is uniform, rather than a mix of fonts and styles (default: 0).
		/// </summary>
		SES_DRAFTMODE = 32786,

		/// <summary>
		/// Windows 8: Emulate RichEdit 1.0 behavior.
		/// <para>
		/// <note type="note">If you really want this behavior, use the Windows riched32.dll instead of riched20.dll or msftedit.dll.
		/// Riched32.dll had more functionality.</note>
		/// </para>
		/// </summary>
		SES_EMULATE10 = 16,

		/// <summary>When this bit is on, rich edit attempts to emulate the system edit control (default: 0).</summary>
		SES_EMULATESYSEDIT = 1,

		/// <summary>Extends the background color all the way to the edges of the client rectangle (default: 0).</summary>
		SES_EXTENDBACKCOLOR = 4,

		/// <summary>
		/// Windows XP with SP1: If the width of table gridlines is zero, gridlines are not displayed. This is equivalent to the hide
		/// gridlines feature in Word's table menu (default: 0).
		/// </summary>
		SES_HIDEGRIDLINES = 0x00020000,

		/// <summary>Windows 8: When the cursor is over a link, display a tooltip with the target link address (default: 0).</summary>
		SES_HYPERLINKTOOLTIPS = 8,

		/// <summary>Undocumented</summary>
		SES_LBSCROLLNOTIFY = 0x00100000,

		/// <summary>
		/// Windows 8: Provide logical caret information instead of a caret bitmap as described in ITextHost::TxSetCaretPos (default: 0).
		/// </summary>
		SES_LOGICALCARET = 0x01000000,

		/// <summary>Converts all input characters to lowercase (default: 0).</summary>
		SES_LOWERCASE = 1024,

		/// <summary>Obsolete. Do not use.</summary>
		SES_MAPCPS = 8,

		/// <summary>Windows 8: Enable multiselection with individual mouse selections made while the Ctrl key is pressed (default: 0).</summary>
		SES_MULTISELECT = 0x08000000,

		/// <summary>Windows 8: Do not adjust line height for East Asian text (default: 0 which adjusts the line height by 15%).</summary>
		SES_NOEALINEHEIGHTADJUST = 0x20000000,

		/// <summary>Sends EN_LINK notification from links that do not have focus.</summary>
		SES_NOFOCUSLINKNOTIFY = 32,

		/// <summary>Disallows IMEs for this instance of the rich edit control (default: 0).</summary>
		SES_NOIME = 128,

		/// <summary>
		/// When this bit is on, rich edit does not verify the sequence of typed text. Some languages (such as Thai and Vietnamese) require
		/// verifying the input sequence order before submitting it to the backing store (default: 0).
		/// </summary>
		SES_NOINPUTSEQUENCECHK = 2048,

		/// <summary>When KillFocus occurs, scroll to the beginning of the text (character position equal to 0) (default: 0).</summary>
		SES_SCROLLONKILLFOCUS = 8192,

		/// <summary>Windows 8: Add or delete a space according to the context when dropping text (default: 0).</summary>
		SES_SMARTDRAGDROP = 0x04000000,

		/// <summary>Obsolete. Do not use.</summary>
		SES_USECRLF = 32,

		/// <summary>Windows 8: If word select is active, ensure that the drop location is at a word boundary (default: 0).</summary>
		SES_WORDDRAGDROP = 0x02000000,

		/// <summary>Converts all input characters to uppercase (default: 0).</summary>
		SES_UPPERCASE = 512,

		/// <summary>Uses the Active IMM input method component that ships with Internet Explorer 4.0 or later (default: 0).</summary>
		SES_USEAIMM = 64,

		/// <summary>
		/// Windows XP with SP1: Uses an @ font, which is designed for vertical text; this is used with the ES_VERTICAL window style. The
		/// name of an @ font begins with the @ symbol, for example, "@Batang" (default: 0, but is automatically turned on for vertical text layout).
		/// </summary>
		SES_USEATFONT = 0x00040000,

		/// <summary>Windows XP with SP1: Turns on TSF support. (default: 0)</summary>
		SES_USECTF = 0x00010000,

		/// <summary>
		/// Turns on translation of CRCRLFs to CRs. When this bit is on and a file is read in, all instances of CRCRLF will be converted to
		/// hard CRs internally. This will affect the text wrapping. Note that if such a file is saved as plain text, the CRs will be
		/// replaced by CRLFs. This is the .txt standard for plain text (default: 0, which deletes CRCRLFs on input).
		/// </summary>
		SES_XLTCRCRLFTOCR = 16384,
	}

	/// <summary>The extended edit style flags.</summary>
	[PInvokeData("richedit.h")]
	[Flags]
	public enum SES_EX : uint
	{
		/// <summary>
		/// Display friendly name links with the same text color and underlining as automatic links, provided that temporary formatting isn t
		/// used or uses text autocolor (default: 0).
		/// </summary>
		SES_EX_HANDLEFRIENDLYURL = 0x00000100,

		/// <summary>
		/// Enable touch support in Rich Edit. This includes selection, caret placement, and context-menu invocation. When this flag is not
		/// set, touch is emulated by mouse commands, which do not take touch-mode specifics into account (default: 0).
		/// </summary>
		SES_EX_MULTITOUCH = 0x08000000,

		/// <summary>
		/// Display selected text using classic Windows selection text and background colors instead of background acetate color (default: 0).
		/// </summary>
		SES_EX_NOACETATESELECTION = 0x00100000,

		/// <summary>
		/// Disable insertion of math zones (default: 1). To enable math editing and display, send the EM_SETEDITSTYLEEX message with wParam
		/// set to 0, and lParam set to SES_EX_NOMATH.
		/// </summary>
		SES_EX_NOMATH = 0x00000040,

		/// <summary>Disable insertion of tables. The EM_INSERTTABLE message returns E_FAIL and RTF tables are skipped (default: 0).</summary>
		SES_EX_NOTABLE = 0x00000004,

		/// <summary>
		/// Enable a multiline control to act like a single-line control with the ability to scroll vertically when the single-line height is
		/// greater than the window height (default: 0).
		/// </summary>
		SES_EX_USESINGLELINE = 0x00200000,

		/// <summary>
		/// Hide temporary formatting that is created when ITextFont.Reset is called with tomApplyTmp. For example, such formatting is used
		/// by spell checkers to display a squiggly underline under possibly misspelled words.
		/// </summary>
		SES_HIDETEMPFORMAT = 0x10000000,

		/// <summary>Use wParam when handling the WM_MOUSEMOVE message and do not call GetAsyncKeyState.</summary>
		SES_EX_USEMOUSEWPARAM = 0x20000000,

		/// <summary>Undocumented</summary>
		SES_EX_NOTHEMING = 0x00080000,
	}

	/// <summary>Specifies the data format and replacement options.</summary>
	[PInvokeData("richedit.h")]
	[Flags]
	public enum SF : ushort
	{
		/// <summary>Text with spaces in place of COM objects.</summary>
		SF_TEXT = 0x0001,

		/// <summary>RTF</summary>
		SF_RTF = 0x0002,

		/// <summary>RTF with spaces in place of COM objects.</summary>
		SF_RTFNOOBJS = 0x0003,

		/// <summary>Text with a text representation of COM objects.</summary>
		SF_TEXTIZED = 0x0004,

		/// <summary>Microsoft Rich Edit 2.0 and later: Indicates Unicode text. You can combine this flag with the SF_TEXT flag.</summary>
		SF_UNICODE = 0x0010,

		/// <summary>
		/// Rich Edit 3.0 and later: Generates UTF-8 RTF as well as text using other code pages. The code page is set in the high word of
		/// wParam. For example, for UTF-8 RTF, set wParam to (CP_UTF8 &lt;&lt; 16) | SF_USECODEPAGE | SF_RTF.
		/// </summary>
		SF_USECODEPAGE = 0x0020,

		/// <summary>Output \uN for nonASCII</summary>
		SF_NCRFORNONASCII = 0x40,

		/// <summary>Output \par at end</summary>
		SFF_WRITEXTRAPAR = 0x80,

		/// <summary>
		/// If specified, the data stream replaces the contents of the current selection. If not specified, the data stream replaces the
		/// entire contents of the control. You can combine this flag with the SF_TEXT or SF_RTF flags.
		/// </summary>
		SFF_SELECTION = 0x8000,

		/// <summary>
		/// If specified, only keywords common to all languages are streamed in. Language-specific RTF keywords in the stream are ignored. If
		/// not specified, all keywords are streamed in. You can combine this flag with the SF_RTF flag.
		/// </summary>
		SFF_PLAINRTF = 0x4000,

		/// <summary>Flag telling file stream output (SFF_SELECTION flag not set) to persist \viewscaleN control word.</summary>
		SFF_PERSISTVIEWSCALE = 0x2000,

		/// <summary>Flag telling file stream input with SFF_SELECTION flag not set not to close the document</summary>
		SFF_KEEPDOCINFO = 0x1000,

		/// <summary>Flag telling stream operations to output in Pocket Word format.</summary>
		SFF_PWD = 0x0800,

		/// <summary>3-bit field specifying the value of N - 1 to use for \rtfN or \pwdN.</summary>
		SF_RTFVAL = 0x0700,
	}

	/// <summary>Option flags for SETTEXTEX.</summary>
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._settextex")]
	[Flags]
	public enum ST : uint
	{
		/// <summary>Deletes the undo stack, discards rich-text formatting, replaces all text.</summary>
		ST_DEFAULT = 0,

		/// <summary>Keeps the undo stack.</summary>
		ST_KEEPUNDO = 1,

		/// <summary>Replaces selection and keeps rich-text formatting.</summary>
		ST_SELECTION = 2,

		/// <summary>Act as if new characters are being entered.</summary>
		ST_NEWCHARS = 4,

		/// <summary>The text is UTF-16 (the <c>WCHAR</c> data type).</summary>
		ST_UNICODE = 8,
	}

	/// <summary>Indicates the text mode of a rich edit control. The EM_SETTEXTMODE and EM_GETTEXTMODE messages use this enumeration type.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/Richedit/ne-richedit-textmode typedef enum tagTextMode { TM_PLAINTEXT = 1,
	// TM_RICHTEXT = 2, TM_SINGLELEVELUNDO = 4, TM_MULTILEVELUNDO = 8, TM_SINGLECODEPAGE = 16, TM_MULTICODEPAGE = 32 } TEXTMODE;
	[PInvokeData("richedit.h", MSDNShortId = "NE:richedit.tagTextMode")]
	[Flags]
	public enum TEXTMODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// Indicates plain-text mode, in which the control is similar to a standard edit control. For more information about plain-text
		/// mode, see the Remarks section of
		/// </para>
		/// <para>EM_SETTEXTMODE</para>
		/// <para>.</para>
		/// </summary>
		TM_PLAINTEXT = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// Indicates rich-text mode, in which the control has the standard rich edit functionality. Rich-text mode is the default setting.
		/// </para>
		/// </summary>
		TM_RICHTEXT = 2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The control allows the user to undo only the last action in the undo queue.</para>
		/// </summary>
		TM_SINGLELEVELUNDO = 4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>The control supports multiple undo actions. This is the default setting. Use the</para>
		/// <para>EM_SETUNDOLIMIT</para>
		/// <para>message to set the maximum number of undo actions.</para>
		/// </summary>
		TM_MULTILEVELUNDO = 8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>16</para>
		/// <para>
		/// The control only allows the English keyboard and a keyboard corresponding to the default character set. For example, you could
		/// have Greek and English. Note that this prevents Unicode text from entering the control. For example, use this value if a Rich
		/// Edit control must be restricted to ANSI text.
		/// </para>
		/// </summary>
		TM_SINGLECODEPAGE = 16,

		/// <summary>
		/// <para>Value:</para>
		/// <para>32</para>
		/// <para>The control allows multiple code pages and Unicode text into the control. This is the default setting.</para>
		/// </summary>
		TM_MULTICODEPAGE = 32,
	}

	/// <summary>A mask identifying the options to set.</summary>
	[PInvokeData("richedit.h")]
	[Flags]
	public enum TO : uint
	{
		/// <summary>Advanced line breaking and line formatting is turned on.</summary>
		TO_ADVANCEDTYPOGRAPHY = 0x0001,

		/// <summary>Faster line breaking for simple text (requires TO_ADVANCEDTYPOGRAPHY).</summary>
		TO_SIMPLELINEBREAK = 0x0002,

		/// <summary/>
		TO_DISABLECUSTOMTEXTOUT = 0x0004,

		/// <summary/>
		TO_ADVANCEDLAYOUT = 0x0008,
	}

	/// <summary>
	/// Contains values that indicate types of rich edit control actions that can be undone or redone. The EM_GETREDONAME and EM_GETUNDONAME
	/// messages use this enumeration type to return a value.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ne-richedit-undonameid typedef enum _undonameid { UID_UNKNOWN = 0,
	// UID_TYPING = 1, UID_DELETE = 2, UID_DRAGDROP = 3, UID_CUT = 4, UID_PASTE = 5, UID_AUTOTABLE = 6 } UNDONAMEID;
	[PInvokeData("richedit.h", MSDNShortId = "NE:richedit._undonameid")]
	public enum UNDONAMEID
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The type of undo action is unknown.</para>
		/// </summary>
		UID_UNKNOWN = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Typing operation.</para>
		/// </summary>
		UID_TYPING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Delete operation.</para>
		/// </summary>
		UID_DELETE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Drag-and-drop operation.</para>
		/// </summary>
		UID_DRAGDROP,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Cut operation.</para>
		/// </summary>
		UID_CUT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Paste operation.</para>
		/// </summary>
		UID_PASTE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Automatic table insertion; for example, typing +---+---+&lt;Enter&gt; to insert a table row.</para>
		/// </summary>
		UID_AUTOTABLE,
	}

	/// <summary>The word-wrapping and word-breaking options for a rich edit control.</summary>
	[PInvokeData("richedit.h")]
	[Flags]
	public enum WBF : uint
	{
		/// <summary>Enables Asian-specific word wrap operations, such as kinsoku in Japanese.</summary>
		WBF_WORDWRAP = 0x010,

		/// <summary>Enables English word-breaking operations in Japanese and Chinese. Enables Hangeul word-breaking operation.</summary>
		WBF_WORDBREAK = 0x020,

		/// <summary>Recognizes overflow punctuation. (Not currently supported.)</summary>
		WBF_OVERFLOW = 0x040,

		/// <summary>Sets the Level 1 punctuation table as the default.</summary>
		WBF_LEVEL1 = 0x080,

		/// <summary>Sets the Level 2 punctuation table as the default.</summary>
		WBF_LEVEL2 = 0x100,

		/// <summary>Sets the application-defined punctuation table.</summary>
		WBF_CUSTOM = 0x200,
	}

	/// <summary>Initializes the current thread to use the Rich Edit control.</summary>
	public static void MsftEditThreadInit()
	{
		Ole32.OleInitialize(IntPtr.Zero);
		Kernel32.LoadLibrary(Lib_msftedit);
	}

	/// <summary>
	/// <para>[Intended for internal use; not recommended for use in applications. This function may not be supported in future versions.]</para>
	/// <para>Registers two class names, REListBox20W and RECombobox20W, that could be used to create Rich Edit listbox or combobox windows.</para>
	/// </summary>
	/// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/controls/reextendedregisterclass BOOL WINAPI REExtendedRegisterClass(void);
	[PInvokeData("None")]
	[DllImport(Lib_Riched20, SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool REExtendedRegisterClass();

	/// <summary>Retrives a related <see cref="IRichEditOle"/> instance from a Rich Edit control by sending a EM_GETOLEINTERFACE message.</summary>
	/// <param name="hRichEditWnd">The rich edit control window handle.</param>
	/// <returns>The <see cref="IRichEditOle"/> instance.</returns>
	public static IRichEditOle RichEdit_GetOleInterface(HWND hRichEditWnd)
	{
		IntPtr ptr = IntPtr.Zero;
		if (IntPtr.Zero == SendMessage(hRichEditWnd, RichEditMessage.EM_GETOLEINTERFACE, default, ref ptr))
			Win32Error.ThrowLastError();
		return (IRichEditOle)Marshal.GetObjectForIUnknown(ptr);
	}

	/// <summary>
	/// Contains bidirectional information about a rich edit control. This structure is used by the EM_GETBIDIOPTIONS and EM_SETBIDIOPTIONS
	/// messages to get and set the bidirectional information for a control.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-bidioptions typedef struct _bidioptions { UINT cbSize; WORD
	// wMask; WORD wEffects; } BIDIOPTIONS;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._bidioptions")]
	[StructLayout(LayoutKind.Sequential)]
	public struct BIDIOPTIONS
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Specifies the size, in bytes, of the structure. Before passing this structure to a rich edit control, set <c>cbSize</c> to the
		/// size of the <c>BIDIOPTIONS</c> structure. The rich edit control checks the size of <c>cbSize</c> before sending an
		/// EM_GETBIDIOPTIONS message.
		/// </para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// A set of mask bits that determine which of the <c>wEffects</c> flags will be set to 1 or 0 by the rich edit control. This
		/// approach eliminates the need to read the effects flags before changing them.
		/// </para>
		/// <para>Obsolete bits are valid only for the bidirectional version of Rich Edit 1.0.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>BOM_CONTEXTALIGNMENT</c></description>
		/// <description>The BOE_CONTEXTALIGNMENT value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>BOM_CONTEXTREADING</c></description>
		/// <description>The BOE_CONTEXTREADING value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>BOM_DEFPARADIR</c></description>
		/// <description>The BOE_RTLDIR value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>BOM_LEGACYBIDICLASS</c></description>
		/// <description>The BOE_LEGACYBIDICLASS value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>BOM_NEUTRALOVERRIDE</c></description>
		/// <description>The BOE_NEUTRALOVERRIDE value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>BOM_PLAINTEXT</c></description>
		/// <description>The BOE_PLAINTEXT value is valid. (obsolete).</description>
		/// </item>
		/// <item>
		/// <description><c>BOM_UNICODEBIDI</c></description>
		/// <description>The BOE_UNICODEBIDI value is valid.</description>
		/// </item>
		/// </list>
		/// </summary>
		public BOM wMask;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// A set of flags that indicate the desired or current state of the effects flags. Obsolete bits are valid only for the
		/// bidirectional version of Rich Edit 1.0.
		/// </para>
		/// <para>Obsolete bits are valid only for the bidirectional version of Rich Edit 1.0.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>BOE_CONTEXTALIGNMENT</c></description>
		/// <description>
		/// If this flag is 1, context paragraph alignment is active. This feature is used only for plain-text controls. When active, the
		/// paragraph alignment is set to PFA_LEFT if the first strongly directional character is LTR, or PFA_RIGHT if the first strongly
		/// directional character is RTL. If the control has no strongly directional character, the alignment is chosen according to the
		/// directionality of the keyboard language when the control regains focus (default: 0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>BOE_CONTEXTREADING</c></description>
		/// <description>
		/// If this flag is 1, context paragraph directionality is active. This feature is used only for plain-text controls. When active,
		/// the paragraph directionality effect PFE_RTLPARA is set to 0 if the first strongly directional character is LTR, or 1 if the first
		/// strongly directional character is RTL. If the control has no strongly directional character, the directionality is chosen
		/// according to the directionality of the keyboard language when the control regains focus (default: 0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>BOE_FORCERECALC</c></description>
		/// <description>
		/// <c>WindowsÂ 8</c>: Force the rich edit control to recalculate the bidirectional information, and then redraw the control.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>BOE_LEGACYBIDICLASS</c></description>
		/// <description>
		/// Causes the plus and minus characters to be treated as neutral characters with no implied direction. Also causes the slash
		/// character to be treated as a common separator.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>BOE_NEUTRALOVERRIDE</c></description>
		/// <description>
		/// If this flag is 1, the characters !"#&amp;'()*+,-./:;&lt;=&gt; are treated as strong LTR characters (default: 0).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>BOE_PLAINTEXT</c></description>
		/// <description>Uses plain text layout (obsolete).</description>
		/// </item>
		/// <item>
		/// <description><c>BOE_RTLDIR</c></description>
		/// <description>Default paragraph directionâimplies alignment (obsolete).</description>
		/// </item>
		/// <item>
		/// <description><c>BOE_UNICODEBIDI</c></description>
		/// <description>
		/// If this flag is 1, the Unicode Bidi Algorithm (UBA) is used for rich-text controls. The UBA is always used for plain-text
		/// controls (default: 0).
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		public BOE wEffects;
	}

	/// <summary>
	/// <para>Contains information about character formatting in a rich edit control.</para>
	/// <para>
	/// <c>Rich Edit 2.0:</c> The CHARFORMAT2 structure is a Microsoft Rich EditÂ 2.0 extension of the <c>CHARFORMAT</c> structure. Microsoft
	/// Rich EditÂ 2.0 and later allows you to use either structure with the EM_GETCHARFORMAT and EM_SETCHARFORMAT messages.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// To turn off a formatting attribute, set the appropriate value in <c>dwMask</c> but do not set the corresponding value in
	/// <c>dwEffects</c>. For example, to turn off italics, set CFM_ITALIC but do not set CFE_ITALIC.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The richedit.h header defines CHARFORMAT as an alias which automatically selects the ANSI or Unicode version of this function based
	/// on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-charformata typedef struct _charformat { UINT cbSize; DWORD
	// dwMask; DWORD dwEffects; LONG yHeight; LONG yOffset; COLORREF crTextColor; BYTE bCharSet; BYTE bPitchAndFamily; char
	// szFaceName[LF_FACESIZE]; } CHARFORMATA;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._charformat")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct CHARFORMAT
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Size in bytes of the specified structure. This member must be set before passing the structure to the rich edit control.</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Members containing valid information or attributes to set. This member can be zero, one, or more than one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>CFM_ALL</c></description>
		/// <description>
		/// <c>WindowsÂ 8</c>: A combination of the following values: CFM_EFFECTS | CFM_SIZE | CFM_FACE | CFM_OFFSET | CFM_CHARSET
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFM_BOLD</c></description>
		/// <description>The CFE_BOLD value of the <c>dwEffects</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_CHARSET</c></description>
		/// <description>The <c>bCharSet</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_COLOR</c></description>
		/// <description>The <c>crTextColor</c> member and the CFE_AUTOCOLOR value of the <c>dwEffects</c> member are valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_EFFECTS</c></description>
		/// <description>
		/// <c>WindowsÂ 8</c>: A combination of the following values: CFM_BOLD | CFM_ITALIC | CFM_UNDERLINE | CFM_COLOR | CFM_STRIKEOUT |
		/// CFE_PROTECTED | CFM_LINK
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFM_FACE</c></description>
		/// <description>The <c>szFaceName</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_ITALIC</c></description>
		/// <description>The CFE_ITALIC value of the <c>dwEffects</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_OFFSET</c></description>
		/// <description>The <c>yOffset</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_PROTECTED</c></description>
		/// <description>The CFE_PROTECTED value of the <c>dwEffects</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_SIZE</c></description>
		/// <description>The <c>yHeight</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_STRIKEOUT</c></description>
		/// <description>The CFE_STRIKEOUT value of the <c>dwEffects</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_UNDERLINE.</c></description>
		/// <description>The CFE_UNDERLINE value of the <c>dwEffects</c> member is valid.</description>
		/// </item>
		/// </list>
		/// </summary>
		public CFM dwMask;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Character effects. This member can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>CFE_AUTOCOLOR</c></description>
		/// <description>The text color is the return value of GetSysColor(COLOR_WINDOWTEXT).</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_BOLD</c></description>
		/// <description>Characters are bold.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_DISABLED</c></description>
		/// <description>
		/// <c>RichEdit 2.0 and later:</c> Characters are displayed with a shadow that is offset by 3/4 point or one pixel, whichever is larger.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFE_ITALIC</c></description>
		/// <description>Characters are italic.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_STRIKEOUT</c></description>
		/// <description>Characters are struck.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_UNDERLINE</c></description>
		/// <description>Characters are underlined.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_PROTECTED</c></description>
		/// <description>Characters are protected; an attempt to modify them will cause an EN_PROTECTED notification code.</description>
		/// </item>
		/// </list>
		/// </summary>
		public CFE dwEffects;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>Character height, in twips (1/1440 of an inch or 1/20 of a printer's point).</para>
		/// </summary>
		public int yHeight;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Character offset, in twips, from the baseline. If the value of this member is positive, the character is a superscript; if it is
		/// negative, the character is a subscript.
		/// </para>
		/// </summary>
		public int yOffset;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>
		/// Text color. This member is ignored if the CFE_AUTOCOLOR character effect is specified. To generate a COLORREF, use the RGB macro.
		/// </para>
		/// </summary>
		public COLORREF crTextColor;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>
		/// Character set value. The <c>bCharSet</c> member can be one of the values specified for the <c>lfCharSet</c> member of the LOGFONT
		/// structure. Microsoft Rich EditÂ 3.0 may override this value if it is invalid for the target characters.
		/// </para>
		/// </summary>
		public CharacterSet bCharSet;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>Font family and pitch. This member is the same as the <c>lfPitchAndFamily</c> member of the <see cref="LOGFONT"/> structure.</para>
		/// </summary>
		public FontPitch bPitchAndFamily;

		/// <summary>
		/// <para>Type: <c>TCHAR[LF_FACESIZE]</c></para>
		/// <para>Null-terminated character array specifying the font name.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string szFaceName;
	}

	/// <summary>
	/// Contains information about character formatting in a rich edit control. <c>CHARFORMAT2</c> is a Microsoft Rich EditÂ 2.0 extension of
	/// the CHARFORMAT structure. Microsoft Rich EditÂ 2.0 allows you to use either structure with the EM_GETCHARFORMAT and EM_SETCHARFORMAT messages.
	/// </summary>
	/// <remarks>
	/// To turn off a formatting attribute, set the appropriate value in <c>dwMask</c> but do not set the corresponding value in
	/// <c>dwEffects</c>. For example, to turn off italics, set <c>CFM_ITALIC</c> but do not set <c>CFE_ITALIC</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-charformat2w_1 typedef struct _charformat2w { UINT cbSize;
	// DWORD dwMask; DWORD dwEffects; LONG yHeight; LONG yOffset; COLORREF crTextColor; BYTE bCharSet; BYTE bPitchAndFamily; WCHAR
	// szFaceName[LF_FACESIZE]; WORD wWeight; SHORT sSpacing; COLORREF crBackColor; LCID lcid; union { DWORD dwReserved; DWORD dwCookie; };
	// DWORD dwReserved; SHORT sStyle; WORD wKerning; BYTE bUnderlineType; BYTE bAnimation; BYTE bRevAuthor; BYTE bUnderlineColor; } CHARFORMAT2W;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._charformat2w")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct CHARFORMAT2
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Specifies the size, in bytes, of the structure. Before passing this structure to a rich edit control, set <c>cbSize</c> to the
		/// size of the CHARFORMAT or <c>CHARFORMAT2</c> structure. If <c>cbSize</c> equals the size of a <c>CHARFORMAT</c> structure, the
		/// control uses only the <c>CHARFORMAT</c> members.
		/// </para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Specifies the parts of the <c>CHARFORMAT2</c> structure that contain valid information. The <c>dwMask</c> member can be a
		/// combination of the values from two sets of bit flags. One set indicates the structure members that are valid. Another set
		/// indicates the valid attributes in the <c>dwEffects</c> member.
		/// </para>
		/// <para>Set the following values to indicate the valid attributes of the <c>dwEffects</c> member.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>CFM_ALL</c></description>
		/// <description>
		/// A combination of the following values: <c>CFM_EFFECTS</c> | <c>CFM_SIZE</c> | <c>CFM_FACE</c> | <c>CFM_OFFSET</c> | <c>CFM_CHARSET</c>
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFM_ALL2</c></description>
		/// <description>
		/// A combination of the following values: <c>CFM_ALL</c> | <c>CFM_EFFECTS2</c> | <c>CFM_BACKCOLOR</c> | <c>CFM_LCID</c> |
		/// <c>CFM_UNDERLINETYPE</c> | <c>CFM_WEIGHT</c> | <c>CFM_REVAUTHOR</c> | <c>CFM_SPACING</c> | <c>CFM_KERNING</c> | <c>CFM_STYLE</c>
		/// | <c>CFM_ANIMATION</c> | <c>CFM_COOKIE</c>
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFM_ALLCAPS</c></description>
		/// <description>The <c>CFE_ALLCAPS</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_EFFECTS</c></description>
		/// <description>
		/// A combination of the following values: <c>CFM_EFFECTS2</c> | <c>CFM_FONTBOUND</c> | <c>CFM_EXTENDED</c> |
		/// <c>CFM_MATHNOBUILDUP</c> | <c>CFM_MATH</c> | <c>CFM_MATHORDINARY</c>
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFM_BOLD</c></description>
		/// <description>The <c>CFE_BOLD</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_COLOR</c></description>
		/// <description>The <c>CFE_AUTOCOLOR</c> value is valid, or the <c>crTextColor</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_COOKIE</c></description>
		/// <description>The <c>dwCookie</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_DISABLED</c></description>
		/// <description>The <c>CFE_DISABLED</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_EXTENDED</c></description>
		/// <description>The <c>CFE_EXTENDED</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_EFFECTS</c></description>
		/// <description>
		/// A combination of the following values: <c>CFM_BOLD</c> | <c>CFM_ITALIC</c> | <c>CFM_UNDERLINE</c> | <c>CFM_COLOR</c> |
		/// <c>CFM_STRIKEOUT</c> | <c>CFE_PROTECTED</c> | <c>CFM_LINK</c>
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFM_EFFECTS2</c></description>
		/// <description>
		/// A combination of the following values: <c>CFM_EFFECTS</c> | <c>CFM_DISABLED</c> | <c>CFM_SMALLCAPS</c> | <c>CFM_ALLCAPS</c> |
		/// <c>CFM_HIDDEN</c> | <c>CFM_OUTLINE</c> | <c>CFM_SHADOW</c> | <c>CFM_EMBOSS</c> | <c>CFM_IMPRINT</c> | <c>CFM_REVISED</c> |
		/// <c>CFM_SUBSCRIPT</c> | <c>CFM_SUPERSCRIPT</c> | <c>CFM_BACKCOLOR</c>
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFM_EMBOSS</c></description>
		/// <description>The <c>CFE_EMBOSS</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_FONTBOUND</c></description>
		/// <description>The <c>CFE_FONTBOUND</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_HIDDEN</c></description>
		/// <description>The <c>CFE_HIDDEN</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_IMPRINT</c></description>
		/// <description>The <c>CFE_IMPRINT</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_ITALIC</c></description>
		/// <description>The <c>CFE_ITALIC</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_LINK</c></description>
		/// <description>The <c>CFE_LINK</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_LINKPROTECTED</c></description>
		/// <description>The <c>CFE_LINKPROTECTED</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_MATH</c></description>
		/// <description>The <c>CFE_MATH</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_MATHNOBUILDUP</c></description>
		/// <description>The <c>CFE_MATHNOBUILDUP</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_MATHORDINARY</c></description>
		/// <description>The <c>CFE_MATHORDINARY</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_OUTLINE</c></description>
		/// <description>The <c>CFE_OUTLINE</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_PROTECTED</c></description>
		/// <description>The <c>CFE_PROTECTED</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_REVISED</c></description>
		/// <description>The <c>CFE_REVISION</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_SHADOW</c></description>
		/// <description>The <c>CFE_SHADOW</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_SMALLCAPS</c></description>
		/// <description>The <c>CFE_SMALLCAPS</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_STRIKEOUT</c></description>
		/// <description>The <c>CFE_STRIKEOUT</c> value is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_SUBSCRIPT</c></description>
		/// <description>The <c>CFE_SUBSCRIPT</c> and <c>CFE_SUPERSCRIPT</c> values are valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_SUPERSCRIPT</c></description>
		/// <description>The <c>CFE_SUBSCRIPT</c> and <c>CFE_SUPERSCRIPT</c> values are valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_UNDERLINE</c></description>
		/// <description>The <c>CFE_UNDERLINE</c> value is valid.</description>
		/// </item>
		/// </list>
		/// <para>Â</para>
		/// <para>Set the following values to indicate the valid structure members.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>CFM_ANIMATION</c></description>
		/// <description>The <c>bAnimation</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_BACKCOLOR</c></description>
		/// <description>The <c>crBackColor</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_CHARSET</c></description>
		/// <description>The <c>bCharSet</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_COLOR</c></description>
		/// <description>
		/// The <c>crTextColor</c> member is valid unless the <c>CFE_AUTOCOLOR</c> flag is set in the <c>dwEffects</c> member.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFM_FACE</c></description>
		/// <description>The <c>szFaceName</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_KERNING</c></description>
		/// <description>The <c>wKerning</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_LCID</c></description>
		/// <description>The <c>lcid</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_OFFSET</c></description>
		/// <description>The <c>yOffset</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_REVAUTHOR</c></description>
		/// <description>The <c>bRevAuthor</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_SIZE</c></description>
		/// <description>The <c>yHeight</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_SPACING</c></description>
		/// <description>The <c>sSpacing</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_STYLE</c></description>
		/// <description>The <c>sStyle</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_UNDERLINETYPE</c></description>
		/// <description>The <c>bUnderlineType</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>CFM_WEIGHT</c></description>
		/// <description>The <c>wWeight</c> member is valid.</description>
		/// </item>
		/// </list>
		/// </summary>
		public CFM dwMask;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A set of bit flags that specify character effects. Some of the flags are included only for compatibility with Microsoft Text
		/// Object Model (TOM) interfaces; the rich edit control stores the value but does not use it to display text.
		/// </para>
		/// <para>This member can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>CFE_ALLCAPS</c></description>
		/// <description>
		/// Characters are all capital letters. The value does not affect the way the control displays the text. This value applies only to
		/// versions earlier than Microsoft Rich EditÂ 3.0.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFE_AUTOBACKCOLOR</c></description>
		/// <description>
		/// The background color is the return value of GetSysColor( <c>COLOR_WINDOW</c>). If this flag is set, <c>crBackColor</c> member is ignored.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFE_AUTOCOLOR</c></description>
		/// <description>
		/// The text color is the return value of GetSysColor( <c>COLOR_WINDOWTEXT</c>). If this flag is set, the <c>crTextColor</c> member
		/// is ignored.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFE_BOLD</c></description>
		/// <description>Characters are bold.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_DISABLED</c></description>
		/// <description>Characters are displayed with a shadow that is offset by 3/4 point or one pixel, whichever is larger.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_EMBOSS</c></description>
		/// <description>Characters are embossed. The value does not affect how the control displays the text.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_EXTENDED</c></description>
		/// <description>
		/// The characters are less common members of a script. A font that supports a script should check if it has glyphs for such characters.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFE_FONTBOUND</c></description>
		/// <description>
		/// Font is chosen by the rich edit control because the active font doesnât support the characters. This process is called font binding.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFE_HIDDEN</c></description>
		/// <description>For Microsoft Rich EditÂ 3.0 and later, characters are not displayed.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_IMPRINT</c></description>
		/// <description>
		/// Characters are displayed as imprinted characters. The value does not affect how the control displays the text.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFE_ITALIC</c></description>
		/// <description>Characters are italic.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_LINK</c></description>
		/// <description>
		/// A rich edit control can send EN_LINK notification codes when it receives mouse messages while the mouse pointer is over text with
		/// the <c>CFE_LINK</c> effect.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFE_LINKPROTECTED</c></description>
		/// <description>Characters are part of a friendly name link.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_MATH</c></description>
		/// <description>Characters are in a math zone.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_MATHNOBUILDUP</c></description>
		/// <description>
		/// Characters do not participate in a math build up. For example, when applied to a /, the / will not be used to build up a fraction.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFE_MATHORDINARY</c></description>
		/// <description>Characters are displayed as ordinary text within a math zone.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_OUTLINE</c></description>
		/// <description>Characters are displayed as outlined characters. The value does not affect how the control displays the text.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_PROTECTED</c></description>
		/// <description>Characters are protected; an attempt to modify them will cause an EN_PROTECTED notification code.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_REVISED</c></description>
		/// <description>Characters are marked as revised.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_SHADOW</c></description>
		/// <description>Characters are displayed as shadowed characters. The value does not affect how the control displays the text.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_SMALLCAPS</c></description>
		/// <description>Characters are in small capital letters. The value does not affect how the control displays the text.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_STRIKEOUT</c></description>
		/// <description>Characters are struck out.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_SUBSCRIPT</c></description>
		/// <description>
		/// Characters are subscript. The <c>CFE_SUPERSCRIPT</c> and <c>CFE_SUBSCRIPT</c> values are mutually exclusive. For both values, the
		/// control automatically calculates an offset and a smaller font size. Alternatively, you can use the <c>yHeight</c> and
		/// <c>yOffset</c> members to explicitly specify font size and offset for subscript and superscript characters.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFE_SUPERSCRIPT</c></description>
		/// <description>Characters are superscript.</description>
		/// </item>
		/// <item>
		/// <description><c>CFE_UNDERLINE</c></description>
		/// <description>Characters are underlined.</description>
		/// </item>
		/// </list>
		/// </summary>
		public CFE dwEffects;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Specifies the character height, in twips (1/1440 of an inch, or 1/20 of a printer's point). To use this member, set the
		/// <c>CFM_SIZE</c> flag in the <c>dwMask</c> member.
		/// </para>
		/// </summary>
		public int yHeight;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Character offset from the baseline, in twips. If the value of this member is positive, the character is a superscript; if the
		/// value is negative, the character is a subscript. To use this member, set the <c>CFM_OFFSET</c> flag in the <c>dwMask</c> member.
		/// </para>
		/// </summary>
		public int yOffset;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>
		/// Text color. To use this member, set the <c>CFM_COLOR</c> flag in the <c>dwMask</c> member. This member is ignored if the
		/// <c>CFE_AUTOCOLOR</c> character effect is specified. To generate a COLORREF, use the RGB macro.
		/// </para>
		/// </summary>
		public COLORREF crTextColor;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>
		/// Character set value. It can be one of the values specified for the <c>lfCharSet</c> member of the LOGFONT structure. To use this
		/// member, set the <c>CFM_CHARSET</c> flag in the <c>dwMask</c> member.
		/// </para>
		/// </summary>
		public CharacterSet bCharSet;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>Specifies the font family and pitch. This member is the same as the <c>lfPitchAndFamily</c> member of the LOGFONT structure.</para>
		/// </summary>
		public FontPitch bPitchAndFamily;

		/// <summary>
		/// <para>Type: <c>TCHAR[LF_FACESIZE]</c></para>
		/// <para>
		/// A null-terminated character array specifying the font name. To use this member, set the <c>CFM_FACE</c> flag in the <c>dwMask</c> member.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string szFaceName;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// Font weight. This member is the same as the <see cref="LOGFONT.lfWeight"/> member of the LOGFONT structure. To use this member,
		/// set the <c>CFM_WEIGHT</c> flag in the <c>dwMask</c> member.
		/// </para>
		/// </summary>
		public ushort wWeight;

		/// <summary>
		/// <para>Type: <c>SHORT</c></para>
		/// <para>
		/// Horizontal space between letters, in twips. This value has no effect on the text displayed by a rich edit control; it is included
		/// for compatibility with Windows TOM interfaces. To use this member, set the <c>CFM_SPACING</c> flag in the <c>dwMask</c> member.
		/// </para>
		/// </summary>
		public short sSpacing;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>
		/// Background color. To use this member, set the <c>CFM_BACKCOLOR</c> flag in the <c>dwMask</c> member. This member is ignored if
		/// the <c>CFE_AUTOBACKCOLOR</c> character effect is specified. To generate a , use the macro.
		/// </para>
		/// </summary>
		public COLORREF crBackColor;

		/// <summary>
		/// <para>Type: <c>LCID</c></para>
		/// <para>
		/// A 32-bit locale identifier that contains a language identifier in the lower word and a sorting identifier and reserved value in
		/// the upper word. This member has no effect on the text displayed by a rich edit control, but spelling and grammar checkers can use
		/// it to deal with language-dependent problems. You can use the macro to create an <c>LCID</c> value. To use this member, set the
		/// <c>CFM_LCID</c> flag in the <c>dwMask</c> member.
		/// </para>
		/// </summary>
		public LCID lcid;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Reserved; the value must be zero.</para>
		/// </summary>
		public uint dwReserved;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Client cookie. This member is opaque to a rich edit control.</para>
		/// </summary>
		public uint dwCookie;

		/// <summary>
		/// <para>Type: <c>SHORT</c></para>
		/// <para>
		/// Character style handle. This value has no effect on the text displayed by a rich edit control; it is included for compatibility
		/// with WindowsTOM interfaces. To use this member, set the <c>CFM_STYLE</c> flag in the <c>dwMask</c> member. For more information
		/// see the TOM documentation.
		/// </para>
		/// </summary>
		public short sStyle;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// Value of the font size, above which to kern the character ( <c>yHeight</c>). This value has no effect on the text displayed by a
		/// rich edit control; it is included for compatibility with TOM interfaces. To use this member, set the <c>CFM_KERNING</c> flag in
		/// the <c>dwMask</c> member.
		/// </para>
		/// </summary>
		public ushort wKerning;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>
		/// Specifies the underline type. To use this member, set the <c>CFM_UNDERLINETYPE</c> flag in the <c>dwMask</c> member. This member
		/// can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>CFU_CF1UNDERLINE</c></description>
		/// <description>
		/// The structure maps CHARFORMAT's bit underline to <c>CHARFORMAT2</c>, (that is, it performs a <c>CHARFORMAT</c> type of underline
		/// on this text).
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFU_INVERT</c></description>
		/// <description>For IME composition, fake a selection.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINE</c></description>
		/// <description>Text underlined with a single solid line.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINEDASH</c></description>
		/// <description>Text underlined with dashes.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINEDASHDOT</c></description>
		/// <description>Text underlined with a dashed and dotted line.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINEDASHDOTDOT</c></description>
		/// <description>Text underlined with a dashed and doubled dotted line.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINEDOTTED</c></description>
		/// <description>
		/// Text underlined with a dotted line. For versions earlier than Microsoft Rich EditÂ 3.0, text is displayed with a solid underline.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINEDOUBLE</c></description>
		/// <description>Text underlined with a double line. The rich edit control displays the text with a solid underline.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINEDOUBLEWAVE</c></description>
		/// <description>Display as <c>CFU_UNDERLINEWAVE</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINEHAIRLINE</c></description>
		/// <description>Display as <c>CFU_UNDERLINE</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINEHEAVYWAVE</c></description>
		/// <description>Display as <c>CFU_UNDERLINEWAVE</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINELONGDASH</c></description>
		/// <description>Display as <c>CFU_UNDERLINEDASH</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINENONE</c></description>
		/// <description>No underline. This is the default.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINETHICK</c></description>
		/// <description>Display as <c>CFU_UNDERLINE</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINETHICKDASH</c></description>
		/// <description>Display as <c>CFU_UNDERLINEDASH</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINETHICKDASHDOT</c></description>
		/// <description>Display as <c>CFU_UNDERLINEDASHDOT</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINETHICKDASHDOTDOT</c></description>
		/// <description>Display as <c>CFU_UNDERLINEDASHDOT</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINETHICKDOTTED</c></description>
		/// <description>Display as <c>CFU_UNDERLINEDOT</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINETHICKLONGDASH</c></description>
		/// <description>Display as <c>CFU_UNDERLINEDASH</c>.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINEWAVE</c></description>
		/// <description><c>RichEdit 4.1 and later</c>: Text underlined with a wavy line.</description>
		/// </item>
		/// <item>
		/// <description><c>CFU_UNDERLINEWORD</c></description>
		/// <description>
		/// <c>RichEdit 4.1 and later</c>: Underline words only. The rich edit control displays the text with a solid underline.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		public CFU bUnderlineType;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>
		/// Text animation type. This value has no effect on the text displayed by a rich edit control; it is included for compatibility with
		/// TOM interfaces. To use this member, set the <c>CFM_ANIMATION</c> flag in the <c>dwMask</c> member.
		/// </para>
		/// </summary>
		public byte bAnimation;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>
		/// An index that identifies the author making a revision. The rich edit control uses different text colors for each different author
		/// index. To use this member, set the <c>CFM_REVAUTHOR</c> flag in the <c>dwMask</c> member.
		/// </para>
		/// </summary>
		public byte bRevAuthor;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>Underline color:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>UnderlineColor_Black = 0x00;</description>
		/// </item>
		/// <item>
		/// <description>UnderlineColor_Blue = 0x01;</description>
		/// </item>
		/// <item>
		/// <description>UnderlineColor_Aqua = 0x02;</description>
		/// </item>
		/// <item>
		/// <description>UnderlineColor_Lime = 0x03;</description>
		/// </item>
		/// <item>
		/// <description>UnderlineColor_Fuchsia = 0x04;</description>
		/// </item>
		/// <item>
		/// <description>UnderlineColor_Red = 0x05;</description>
		/// </item>
		/// <item>
		/// <description>UnderlineColor_Yellow = 0x06;</description>
		/// </item>
		/// <item>
		/// <description>UnderlineColor_White = 0x07;</description>
		/// </item>
		/// <item>
		/// <description>UnderlineColor_Navy = 0x08;</description>
		/// </item>
		/// <item>
		/// <description>UnderlineColor_Teal = 0x09;</description>
		/// </item>
		/// <item>
		/// <description>UnderlineColor_Green = 0x0A;</description>
		/// </item>
		/// <item>
		/// <description>UnderlineColor_Purple = 0x0B;</description>
		/// </item>
		/// <item>
		/// <description>UnderlineColor_Maroon = 0x0C;</description>
		/// </item>
		/// <item>
		/// <description>UnderlineColor_Olive = 0x0D;</description>
		/// </item>
		/// <item>
		/// <description>UnderlineColor_DkGray = 0x0E;</description>
		/// </item>
		/// <item>
		/// <description>UnderlineColor_LtGray = 0x0F;</description>
		/// </item>
		/// </list>
		/// </summary>
		public byte bUnderlineColor;
	}

	/// <summary>
	/// <para>Specifies a range of characters in a rich edit control.</para>
	/// <para>
	/// If the <c>cpMin</c> and <c>cpMax</c> members are equal, the range is empty. The range includes everything if <c>cpMin</c> is 0 and
	/// <c>cpMax</c> is â1.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-charrange typedef struct _charrange { LONG cpMin; LONG cpMax;
	// } CHARRANGE;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._charrange")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CHARRANGE
	{
		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>Character position index immediately preceding the first character in the range.</para>
		/// </summary>
		public int cpMin;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>Character position immediately following the last character in the range.</para>
		/// </summary>
		public int cpMax;
	}

	/// <summary>Specifies the clipboard format. This structure included with the EN_CLIPFORMAT notification.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-clipboardformat typedef struct _clipboardformat { NMHDR
	// nmhdr; CLIPFORMAT cf; } CLIPBOARDFORMAT;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._clipboardformat")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CLIPBOARDFORMAT : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>Structure that contains information about this notification message.</para>
		/// </summary>
		public NMHDR nmhdr;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A clipboard format registered by a call to the RegisterClipboardFormat function.</para>
		/// </summary>
		public CLIPFORMAT cf;
	}

	/// <summary>Contains color settings for a composition string.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-compcolor typedef struct _compcolor { COLORREF crText;
	// COLORREF crBackground; DWORD dwEffects; } COMPCOLOR;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._compcolor")]
	[StructLayout(LayoutKind.Sequential)]
	public struct COMPCOLOR
	{
		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>Color of text. To generate a COLORREF, use the RGB macro.</para>
		/// </summary>
		public COLORREF crText;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>Color of background. To generate a COLORREF, use the RGB macro.</para>
		/// </summary>
		public COLORREF crBackground;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Character effect values as described for the <c>dwEffects</c> member in the CHARFORMAT structure.</para>
		/// </summary>
		public CFE dwEffects;
	}

	/// <summary>
	/// Contains information that an application passes to a rich edit control in a EM_STREAMIN or EM_STREAMOUT message. The rich edit
	/// control uses the information to transfer a stream of data into or out of the control.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-editstream typedef struct _editstream { DWORD_PTR dwCookie;
	// DWORD dwError; EDITSTREAMCALLBACK pfnCallback; } EDITSTREAM;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._editstream")]
	[StructLayout(LayoutKind.Sequential)]
	public struct EDITSTREAM
	{
		/// <summary>
		/// <para>Type: <c>DWORD_PTR</c></para>
		/// <para>
		/// Specifies an application-defined value that the rich edit control passes to the EditStreamCallback callback function specified by
		/// the <c>pfnCallback</c> member.
		/// </para>
		/// </summary>
		public IntPtr dwCookie;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Indicates the results of the stream-in (read) or stream-out (write) operation. A value of zero indicates no error. A nonzero
		/// value can be the return value of the EditStreamCallback function or a code indicating that the control encountered an error.
		/// </para>
		/// </summary>
		public uint dwError;

		/// <summary>
		/// <para>Type: <c>EDITSTREAMCALLBACK</c></para>
		/// <para>
		/// Pointer to an EditStreamCallback function, which is an application-defined function that the control calls to transfer data. The
		/// control calls the callback function repeatedly, transferring a portion of the data with each call.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public EDITSTREAMCALLBACK pfnCallback;
	}

	/// <summary>Contains information about the selected text to be corrected.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-encorrecttext typedef struct _encorrecttext { NMHDR nmhdr;
	// CHARRANGE chrg; WORD seltyp; } ENCORRECTTEXT;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._encorrecttext")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENCORRECTTEXT : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>An NMHDR structure. The <c>code</c> member of this structure identifies the notification code being sent.</para>
		/// </summary>
		public NMHDR nmhdr;

		/// <summary>
		/// <para>Type: <c>CHARRANGE</c></para>
		/// <para>A CHARRANGE structure that specifies the range of selected characters.</para>
		/// </summary>
		public CHARRANGE chrg;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// Value specifying the contents of the new selection. This member is SEL_EMPTY if the selection is empty or one or more of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>SEL_TEXT</c></description>
		/// <description>The new selection contains text.</description>
		/// </item>
		/// <item>
		/// <description><c>SEL_OBJECT</c></description>
		/// <description>The new selection contains at least one COM object.</description>
		/// </item>
		/// <item>
		/// <description><c>SEL_MULTICHAR</c></description>
		/// <description>The new selection contains more than one character of text.</description>
		/// </item>
		/// <item>
		/// <description><c>SEL_MULTIOBJECT</c></description>
		/// <description>The new selection contains more than one COM object.</description>
		/// </item>
		/// </list>
		/// </summary>
		public SEL seltyp;
	}

	/// <summary>Contains information about an EN_ENDCOMPOSITION notification code from a rich edit control.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-endcompositionnotify typedef struct _endcomposition { NMHDR
	// nmhdr; DWORD dwCode; } ENDCOMPOSITIONNOTIFY;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._endcomposition")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENDCOMPOSITIONNOTIFY : INotificationInfo
	{
		/// <summary>The <c>code</c> member of this structure identifies the notification code being sent.</summary>
		public NMHDR nmhdr;

		/// <summary>
		/// <para>Indicates the state of the composition. This member is one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>ECN_ENDCOMPOSITION</c> 1</description>
		/// <description>The composition is complete.</description>
		/// </item>
		/// <item>
		/// <description><c>ECN_NEWTEXT</c> 2</description>
		/// <description>There are new characters in the composition.</description>
		/// </item>
		/// </list>
		/// </summary>
		public ECN dwCode;
	}

	/// <summary>
	/// Contains information associated with an EN_DROPFILES notification code. A rich edit control sends this notification code when it
	/// receives a WM_DROPFILES message.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-endropfiles typedef struct _endropfiles { NMHDR nmhdr; HANDLE
	// hDrop; LONG cp; BOOL fProtected; } ENDROPFILES;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._endropfiles")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENDROPFILES : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>Notification header.</para>
		/// </summary>
		public NMHDR nmhdr;

		/// <summary>
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>
		/// Handle to the dropped files list (same as with WM_DROPFILES ). This handle is used with the DragFinish, DragQueryFile, and
		/// DragQueryPoint functions.
		/// </para>
		/// </summary>
		public HDROP hDrop;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>Character position at which the dropped files would be inserted.</para>
		/// </summary>
		public int cp;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Indicates whether the specified character position is protected ( <c>TRUE</c>) or not protected ( <c>FALSE</c>).</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fProtected;
	}

	/// <summary>Contains information about an EN_LINK notification code from a rich edit control.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-enlink typedef struct _enlink { NMHDR nmhdr; UINT msg; WPARAM
	// wParam; LPARAM lParam; CHARRANGE chrg; } ENLINK;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._enlink")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENLINK : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>The code member of this structure identifies the notification code being sent.</para>
		/// </summary>
		public NMHDR nmhdr;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Identifier of the message that caused the rich edit control to send the EN_LINK notification code.</para>
		/// </summary>
		public uint msg;

		/// <summary>
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>The <c>wParam</c> parameter of the message received by the rich edit control.</para>
		/// </summary>
		public IntPtr wParam;

		/// <summary>
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>The <c>lParam</c> parameter of the message received by the rich edit control.</para>
		/// </summary>
		public IntPtr lParam;

		/// <summary>
		/// <para>Type: <c>CHARRANGE</c></para>
		/// <para>The range of consecutive characters in the rich edit control that have the CFE_LINK effect.</para>
		/// </summary>
		public CHARRANGE chrg;
	}

	/// <summary>Contains information about an unsupported Rich Text Format (RTF) keyword in a Microsoft Rich Edit control.</summary>
	/// <remarks>This structure is used with the EN_LOWFIRTF message.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-enlowfirtf typedef struct _enlowfirtf { NMHDR nmhdr; char
	// *szControl; } ENLOWFIRTF;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._enlowfirtf")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENLOWFIRTF : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>Specifies an NMHDR structure.</para>
		/// </summary>
		public NMHDR nmhdr;

		/// <summary>
		/// <para>Type: <c>CHAR*</c></para>
		/// <para>The unsupported RTF keyword.</para>
		/// </summary>
		public IntPtr szControl;
	}

	/// <summary>Contains information about a failed operation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-enoleopfailed typedef struct _enoleopfailed { NMHDR nmhdr;
	// LONG iob; LONG lOper; HRESULT hr; } ENOLEOPFAILED;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._enoleopfailed")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENOLEOPFAILED : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>NMHDR notification header.</para>
		/// </summary>
		public NMHDR nmhdr;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>Object index.</para>
		/// </summary>
		public int iob;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>Operation that failed. This can be <c>OLEOP_DOVERB</c> to indicate that IOleObject::DoVerb failed.</para>
		/// </summary>
		public OLEOP lOper;

		/// <summary>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Error code returned by the object on the operation.</para>
		/// </summary>
		public HRESULT hr;
	}

	/// <summary>
	/// Contains information associated with an EN_PROTECTED notification code. A rich edit control sends this notification when the user
	/// attempts to edit protected text.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-enprotected typedef struct _enprotected { NMHDR nmhdr; UINT
	// msg; WPARAM wParam; LPARAM lParam; CHARRANGE chrg; } ENPROTECTED;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._enprotected")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENPROTECTED : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>NMHDR notification header.</para>
		/// </summary>
		public NMHDR nmhdr;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Message that triggered the notification.</para>
		/// </summary>
		public uint msg;

		/// <summary>
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>The <c>wParam</c> parameter of the message.</para>
		/// </summary>
		public IntPtr wParam;

		/// <summary>
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>The <c>lParam</c> parameter of the message.</para>
		/// </summary>
		public IntPtr lParam;

		/// <summary>
		/// <para>Type: <c>CHARRANGE</c></para>
		/// <para>The current selection.</para>
		/// </summary>
		public CHARRANGE chrg;
	}

	/// <summary>Contains information about objects and text on the clipboard.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-ensaveclipboard typedef struct _ensaveclipboard { NMHDR
	// nmhdr; LONG cObjectCount; LONG cch; } ENSAVECLIPBOARD;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._ensaveclipboard")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENSAVECLIPBOARD : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>NMHDR notification header.</para>
		/// </summary>
		public NMHDR nmhdr;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>Number of objects on the clipboard.</para>
		/// </summary>
		public int cObjectCount;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>Number of characters on the clipboard.</para>
		/// </summary>
		public int cch;
	}

	/// <summary>Contains information about a search operation in a rich edit control. This structure is used with the EM_FINDTEXT message.</summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The richedit.h header defines FINDTEXT as an alias which automatically selects the ANSI or Unicode version of this function based on
	/// the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not encoding-neutral
	/// can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-findtextw typedef struct _findtextw { CHARRANGE chrg; LPCWSTR
	// lpstrText; } FINDTEXTW;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._findtextw")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct FINDTEXT
	{
		/// <summary>
		/// <para>Type: <c>CHARRANGE</c></para>
		/// <para>The range of characters to search.</para>
		/// </summary>
		public CHARRANGE chrg;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The null-terminated string used in the find operation.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpstrText;
	}

	/// <summary>Contains information about text to search for in a rich edit control. This structure is used with the EM_FINDTEXTEX message.</summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The richedit.h header defines FINDTEXTEX as an alias which automatically selects the ANSI or Unicode version of this function based
	/// on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-findtextexa typedef struct _findtextexa { CHARRANGE chrg;
	// LPCSTR lpstrText; CHARRANGE chrgText; } FINDTEXTEXA;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._findtextexa")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct FINDTEXTEX
	{
		/// <summary>
		/// <para>Type: <c>CHARRANGE</c></para>
		/// <para>The range of characters to search. To search forward in the entire control, set <c>cpMin</c> to 0 and <c>cpMax</c> to -1.</para>
		/// </summary>
		public CHARRANGE chrg;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The null-terminated string to find.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpstrText;

		/// <summary>
		/// <para>Type: <c>CHARRANGE</c></para>
		/// <para>The range of characters in which the text was found. If the text was not found, <c>cpMin</c> and <c>cpMax</c> are -1.</para>
		/// </summary>
		public CHARRANGE chrgText;
	}

	/// <summary>
	/// Information that a rich edit control uses to format its output for a particular device. This structure is used with the
	/// EM_FORMATRANGE message.
	/// </summary>
	/// <remarks>
	/// <para>
	/// <c>hdcTarget</c> contains the HDC to format for, which is usually the same as the HDC specified by <c>hdc</c> but can be different.
	/// For example, if you create a print preview module, <c>hdc</c> is the HDC of the window in which the output is viewed, and
	/// <c>hdcTarget</c> is the HDC for the printer.
	/// </para>
	/// <para>The values for <c>rc</c> and <c>rcPage</c> can be obtained by using GetDeviceCaps.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-formatrange typedef struct _formatrange { HDC hdc; HDC
	// hdcTarget; RECT rc; RECT rcPage; CHARRANGE chrg; } FORMATRANGE;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._formatrange")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FORMATRANGE
	{
		/// <summary>
		/// <para>Type: <c>HDC</c></para>
		/// <para>A HDC for the device to render to, if EM_FORMATRANGE is being used to send the output to a device.</para>
		/// </summary>
		public HDC hdc;

		/// <summary>
		/// <para>Type: <c>HDC</c></para>
		/// <para>An HDC for the target device to format for.</para>
		/// </summary>
		public HDC hdcTarget;

		/// <summary>
		/// <para>Type: <c>RECT</c></para>
		/// <para>The area within the <c>rcPage</c> rectangle to render to. Units are measured in twips.</para>
		/// </summary>
		public RECT rc;

		/// <summary>
		/// <para>Type: <c>RECT</c></para>
		/// <para>The entire area of a page on the rendering device. Units are measured in twips.</para>
		/// </summary>
		public RECT rcPage;

		/// <summary>
		/// <para>Type: <c>CHARRANGE</c></para>
		/// <para>The range of characters to format.</para>
		/// </summary>
		public CHARRANGE chrg;
	}

	/// <summary>Contains context menu information that is passed to the IRichEditOleCallback::GetContextMenu method.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-getcontextmenuex typedef struct _getcontextmenuex { CHARRANGE
	// chrg; DWORD dwFlags; POINT pt; void *pvReserved; } GETCONTEXTMENUEX;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._getcontextmenuex")]
	[StructLayout(LayoutKind.Sequential)]
	public struct GETCONTEXTMENUEX
	{
		/// <summary>
		/// <para>Type: <c>CHARRANGE</c></para>
		/// <para>The character-position range in the active display.</para>
		/// </summary>
		public CHARRANGE chrg;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>One or more of the following content menu flags:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>GCMF_GRIPPER</c></description>
		/// <description>Get the context menu that is invoked by tapping a touch gripper handle.</description>
		/// </item>
		/// <item>
		/// <description><c>GCMF_SPELLING</c></description>
		/// <description>Get the context menu for a spelling error.</description>
		/// </item>
		/// <item>
		/// <description><c>GCMF_MOUSEMENU</c></description>
		/// <description>Get the context menu that is invoked by mouse.</description>
		/// </item>
		/// <item>
		/// <description><c>GCMF_TOUCHMENU</c></description>
		/// <description>Get the context menu that is invoked by touch.</description>
		/// </item>
		/// </list>
		/// </summary>
		public GCMF dwFlags;

		/// <summary>
		/// <para>Type: <c>POINT</c></para>
		/// <para>The screen coordinates for the content menu.</para>
		/// </summary>
		public POINT pt;

		/// <summary>
		/// <para>Type: <c>void*</c></para>
		/// <para>Not used; must be zero.</para>
		/// </summary>
		public IntPtr pvReserved;
	}

	/// <summary>Contains information used in getting text from a rich edit control. This structure used with the EM_GETTEXTEX message.</summary>
	/// <remarks>The EM_GETTEXTEX message is faster when both <c>lpDefaultChar</c> and <c>lpUsedDefChar</c> are <c>NULL</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-gettextex typedef struct _gettextex { DWORD cb; DWORD flags;
	// UINT codepage; LPCSTR lpDefaultChar; LPBOOL lpUsedDefChar; } GETTEXTEX;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._gettextex")]
	[StructLayout(LayoutKind.Sequential)]
	public struct GETTEXTEX
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of the buffer used to store the retrieved text.</para>
		/// </summary>
		public uint cb;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Value specifying a text operation. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>GT_DEFAULT</c></description>
		/// <description>All text is retrieved according to the following criteria:
		/// <list type="bullet">
		/// <item>
		/// <description>Carriage returns (U+000D) are not translated into CRLF (U+000D U+000A).</description>
		/// </item>
		/// <item>
		/// <description>Table and math-object structure characters are removed(see GT_RAWTEXT).</description>
		/// </item>
		/// <item>
		/// <description>Hidden text is included.</description>
		/// </item>
		/// <item>
		/// <description>List numbers are not included.</description>
		/// </item>
		/// </list>
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>GT_NOHIDDENTEXT</c></description>
		/// <description>Hidden text is not included in the retrieved text.</description>
		/// </item>
		/// <item>
		/// <description><c>GT_RAWTEXT</c></description>
		/// <description>
		/// Text is retrieved exactly as it appears in memory. This includes special structure characters for table row and cell delimiters
		/// (see Remarks for EM_INSERTTABLE) as well as math object delimiters (start delimiter U+FDD0, argument delimiter U+FDEE, and end
		/// delimiter U+FDDF) and object markers (U+FFFC). This maintains character-position alignment between the retrieved text and the
		/// text in memory.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>GT_SELECTION</c></description>
		/// <description>Retrieve the text for the current selection.</description>
		/// </item>
		/// <item>
		/// <description><c>GT_USECRLF</c></description>
		/// <description>When copying text, translate each CR into a CR/LF.</description>
		/// </item>
		/// </list>
		/// </summary>
		public GT flags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Code page used in the translation. It is <c>CP_ACP</c> for ANSI code page and 1200 for Unicode.</para>
		/// </summary>
		public uint codepage;

		/// <summary>
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>
		/// The character used if a wide character cannot be represented in the specified code page. It is used only if the code page is
		/// <c>not</c> 1200 (Unicode). If this member is <c>NULL</c>, a system default value is used.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string? lpDefaultChar;

		/// <summary>
		/// <para>Type: <c>LPBOOL</c></para>
		/// <para>
		/// A flag that indicates whether the default character ( <c>lpDefaultChar</c>) was used. This member is used only if the code page
		/// is not 1200 or <c>CP_UTF8</c> (Unicode). The flag is <c>TRUE</c> if one or more wide characters in the source string cannot be
		/// represented in the specified code page. Otherwise, the flag is <c>FALSE</c>. This member can be NULL.
		/// </para>
		/// </summary>
		public StructPointer<BOOL> lpUsedDefChar;
	}

	/// <summary>
	/// Contains information about how the text length of a rich edit control should be calculated. This structure is passed in the
	/// <c>wParam</c> in the EM_GETTEXTLENGTHEX message.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-gettextlengthex typedef struct _gettextlengthex { DWORD
	// flags; UINT codepage; } GETTEXTLENGTHEX;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._gettextlengthex")]
	[StructLayout(LayoutKind.Sequential)]
	public struct GETTEXTLENGTHEX
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Value specifying the method to be used in determining the text length. This member can be one or more of the following values
		/// (some values are mutually exclusive).
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>GTL_DEFAULT</c></description>
		/// <description>Returns the number of characters. This is the default.</description>
		/// </item>
		/// <item>
		/// <description><c>GTL_USECRLF</c></description>
		/// <description>Computes the answer by using CR/LFs at the end of paragraphs.</description>
		/// </item>
		/// <item>
		/// <description><c>GTL_PRECISE</c></description>
		/// <description>
		/// Computes a precise answer. This approach could necessitate a conversion and thereby take longer. This flag cannot be used with
		/// the GTL_CLOSE flag. E_INVALIDARG will be returned if both are used.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>GTL_CLOSE</c></description>
		/// <description>
		/// Computes an approximate (close) answer. It is obtained quickly and can be used to set the buffer size. This flag cannot be used
		/// with the GTL_PRECISE flag. E_INVALIDARG will be returned if both are used.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>GTL_NUMCHARS</c></description>
		/// <description>
		/// Returns the number of characters. This flag cannot be used with the GTL_NUMBYTES flag. E_INVALIDARG will be returned if both are used.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>GTL_NUMBYTES</c></description>
		/// <description>
		/// Returns the number of bytes. This flag cannot be used with the GTL_NUMCHARS flag. E_INVALIDARG will be returned if both are used.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		public GTL flags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Code page used in the translation. It is CP_ACP for ANSI Code Page and 1200 for Unicode.</para>
		/// </summary>
		public uint codepage;
	}

	/// <summary>Contains information about hyphenation in a Microsoft Rich Edit control.</summary>
	/// <remarks>This structure is used with the EM_GETHYPHENATEINFO and EM_SETHYPHENATEINFO messages.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-hyphenateinfo typedef struct tagHyphenateInfo { SHORT cbSize;
	// SHORT dxHyphenateZone; void((WCHAR *,LANGID, long,HYPHRESULT *) * )pfnHyphenate; } HYPHENATEINFO;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit.tagHyphenateInfo")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HYPHENATEINFO
	{
		/// <summary>
		/// <para>Type: <c>SHORT</c></para>
		/// <para>Size of the <c>HYPHENATEINFO</c> structure, in bytes.</para>
		/// </summary>
		public short cbSize;

		/// <summary>
		/// <para>Type: <c>SHORT</c></para>
		/// <para>
		/// Size, in TWIPS (one TWIP is 1/1440 inch), of the area near the margin that excludes hyphenation. If a space character is closer
		/// to the margin than this value, do not hyphenate the following word.
		/// </para>
		/// </summary>
		public short dxHyphenateZone;

		private IntPtr pfn;

		/// <summary>
		/// <para>Type: <c>PFNHYPHENATEPROC</c></para>
		/// <para>The client-defined HyphenateProc callback function.</para>
		/// </summary>
		public Action<PWSTR, LANGID, int, IntPtr> pfnHyphenate
		{
			get => (Action<PWSTR, LANGID, int, IntPtr>)Marshal.GetDelegateForFunctionPointer(pfn, typeof(Action<PWSTR, LANGID, int, IntPtr>));
			set => pfn = Marshal.GetFunctionPointerForDelegate(value);
		}
	}

	/// <summary>Contains information about the result of hyphenation in a Microsoft Rich Edit control.</summary>
	/// <remarks>This structure is used with the HYPHENATEINFO structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-hyphresult typedef struct hyphresult { KHYPH khyph; long
	// ichHyph; WCHAR chHyph; } HYPHRESULT;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit.hyphresult")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HYPHRESULT
	{
		/// <summary>
		/// <para>Type: <c>KHYPH</c></para>
		/// <para>The type of hyphenation.</para>
		/// </summary>
		public KHYPH khyph;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>The index of the WCHAR in the passed string where hyphenation occurred.</para>
		/// </summary>
		public long ichHyph;

		/// <summary>
		/// <para>Type: <c>WCHAR</c></para>
		/// <para>
		/// The character used when hyphenation requires a replacement or an addition or a change. If no new character is needed, the value
		/// is zero.
		/// </para>
		/// </summary>
		public char chHyph;
	}

	/// <summary>Contains information about the Input Method Editor (IME) composition text in a Microsoft Rich Edit control.</summary>
	/// <remarks>This structure is used with the EM_GETIMECOMPTEXT message.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-imecomptext typedef struct _imecomptext { LONG cb; DWORD
	// flags; } IMECOMPTEXT;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._imecomptext")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMECOMPTEXT
	{
		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>Size of the output buffer, in bytes.</para>
		/// </summary>
		public int cb;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Type of composition string. It can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>ICT_RESULTREADSTR</c></description>
		/// <description>The final composed string.</description>
		/// </item>
		/// </list>
		/// </summary>
		public ICT flags;
	}

	/// <summary>
	/// Contains information about a keyboard or mouse event. A rich edit control sends this structure to its parent window as part of an
	/// EN_MSGFILTER notification code, enabling the parent to change the message or prevent it from being processed.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-msgfilter typedef struct _msgfilter { NMHDR nmhdr; UINT msg;
	// WPARAM wParam; LPARAM lParam; } MSGFILTER;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._msgfilter")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MSGFILTER : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>The <c>code</c> member of the NMHDR structure is the EN_MSGFILTER notification code that identifies the message being sent.</para>
		/// </summary>
		public NMHDR nmhdr;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Keyboard or mouse message identifier.</para>
		/// </summary>
		public uint msg;

		/// <summary>
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>The <c>wParam</c> parameter of the message.</para>
		/// </summary>
		public IntPtr wParam;

		/// <summary>
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>The <c>lParam</c> parameter of the message.</para>
		/// </summary>
		public IntPtr lParam;
	}

	/// <summary>Contains object position information.</summary>
	/// <remarks>This is used in the EN_OBJECTPOSITIONS notification.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-objectpositions typedef struct _objectpositions { NMHDR
	// nmhdr; LONG cObjectCount; LONG *pcpPositions; } OBJECTPOSITIONS;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._objectpositions")]
	[StructLayout(LayoutKind.Sequential)]
	public struct OBJECTPOSITIONS : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>The <c>code</c> member of this structure identifies the notification code being sent.</para>
		/// </summary>
		public NMHDR nmhdr;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>Number of object positions.</para>
		/// </summary>
		public int cObjectCount;

		/// <summary>
		/// <para>Type: <c>LONG*</c></para>
		/// <para>The object positions.</para>
		/// </summary>
		public IntPtr pcpPositions;
	}

	/// <summary>
	/// <para>
	/// Contains information about paragraph formatting attributes in a rich edit control. This structure is used with the EM_GETPARAFORMAT
	/// and EM_SETPARAFORMAT messages.
	/// </para>
	/// <para>
	/// In Microsoft Rich EditÂ 2.0, the PARAFORMAT2 structure is a Microsoft Rich EditÂ 2.0 extension of the <c>PARAFORMAT</c> structure.
	/// Microsoft Rich EditÂ 2.0 allows you to use either structure with EM_GETPARAFORMAT and EM_SETPARAFORMAT.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-paraformat typedef struct _paraformat { UINT cbSize; DWORD
	// dwMask; WORD wNumbering; union { WORD wReserved; WORD wEffects; }; LONG dxStartIndent; LONG dxRightIndent; LONG dxOffset; WORD
	// wAlignment; SHORT cTabCount; LONG rgxTabs[MAX_TAB_STOPS]; } PARAFORMAT;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._paraformat")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PARAFORMAT
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Structure size, in bytes. The member must be filled before passing to the rich edit control.</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Members containing valid information or attributes to set. This parameter can be none or a combination of the following values.
		/// If both PFM_STARTINDENT and PFM_OFFSETINDENT are specified, PFM_STARTINDENT takes precedence.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>PFM_ALIGNMENT</c></description>
		/// <description>The <c>wAlignment</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>PFM_NUMBERING</c></description>
		/// <description>The <c>wNumbering</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>PFM_OFFSET</c></description>
		/// <description>The <c>dxOffset</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>PFM_OFFSETINDENT</c></description>
		/// <description>The <c>dxStartIndent</c> member is valid and specifies a relative value.</description>
		/// </item>
		/// <item>
		/// <description><c>PFM_RIGHTINDENT</c></description>
		/// <description>The <c>dxRightIndent</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>PFM_RTLPARA</c></description>
		/// <description><c>Rich Edit 2.0:</c> The <c>wEffects</c> member is valid</description>
		/// </item>
		/// <item>
		/// <description><c>PFM_STARTINDENT</c></description>
		/// <description>The <c>dxStartIndent</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>PFM_TABSTOPS</c></description>
		/// <description>The <c>cTabStobs</c> and <c>rgxTabStops</c> members are valid.</description>
		/// </item>
		/// </list>
		/// </summary>
		public PFM dwMask;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>Value specifying numbering options. This member can be zero or PFN_BULLET.</para>
		/// </summary>
		public PFN wNumbering;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para><c>Rich Edit 1.0:</c>: Reserved; the value must be zero.</para>
		/// <para>
		/// <c>Rich Edit 2.0:</c> A bit flag that specifies a paragraph effect. It is included only for compatibility with TOM interfaces;
		/// the rich edit control stores the value but does not use it to display the text. This parameter can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>0</c></description>
		/// <description>Displays text using left-to-right reading order. This is the default.</description>
		/// </item>
		/// <item>
		/// <description><c>PFE_RLTPARA</c></description>
		/// <description>Displays text using right-to-left reading order.</description>
		/// </item>
		/// </list>
		/// </summary>
		public PFE wEffects;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Indentation of the first line in the paragraph, in twips. If the paragraph formatting is being set and PFM_OFFSETINDENT is
		/// specified, this member is treated as a relative value that is added to the starting indentation of each affected paragraph.
		/// </para>
		/// </summary>
		public int dxStartIndent;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>Size, of the right indentation relative to the right margin, in twips.</para>
		/// </summary>
		public int dxRightIndent;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Indentation of the second and subsequent lines of a paragraph relative to the starting indentation, in twips. The first line is
		/// indented if this member is negative or outdented if this member is positive.
		/// </para>
		/// </summary>
		public int dxOffset;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>Value specifying the paragraph alignment. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>PFA_CENTER</c></description>
		/// <description>Paragraphs are centered.</description>
		/// </item>
		/// <item>
		/// <description><c>PFA_LEFT</c></description>
		/// <description>Paragraphs are aligned with the left margin.</description>
		/// </item>
		/// <item>
		/// <description><c>PFA_RIGHT</c></description>
		/// <description>Paragraphs are aligned with the right margin.</description>
		/// </item>
		/// </list>
		/// </summary>
		public PFA wAlignment;

		/// <summary>
		/// <para>Type: <c>SHORT</c></para>
		/// <para>Number of tab stops.</para>
		/// </summary>
		public short cTabCount;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Array of absolute tab stop positions. Each element in the array specifies information about a tab stop. The 24 low-order bits
		/// specify the absolute offset, in twips. To use this member, set the PFM_TABSTOPS flag in the <c>dwMask</c> member.
		/// </para>
		/// <para>
		/// <c>Rich Edit 2.0:</c> For compatibility with TOM interfaces, you can use the eight high-order bits to store additional
		/// information about each tab stop.
		/// </para>
		/// <para>
		/// Bits 24-27 can specify one of the following values to indicate the tab alignment. These bits do not affect the rich edit control
		/// display for versions earlier than Microsoft Rich EditÂ 3.0.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>0</c></description>
		/// <description>Ordinary tab</description>
		/// </item>
		/// <item>
		/// <description><c>1</c></description>
		/// <description>Center tab</description>
		/// </item>
		/// <item>
		/// <description><c>2</c></description>
		/// <description>Right-aligned tab</description>
		/// </item>
		/// <item>
		/// <description><c>3</c></description>
		/// <description>Decimal tab</description>
		/// </item>
		/// <item>
		/// <description><c>4</c></description>
		/// <description>Word bar tab (vertical bar)</description>
		/// </item>
		/// </list>
		/// <para>Â</para>
		/// <para>
		/// Bits 28-31 can specify one of the following values to indicate the type of tab leader. These bits do not affect the rich edit
		/// control display.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>0</c></description>
		/// <description>No leader</description>
		/// </item>
		/// <item>
		/// <description><c>1</c></description>
		/// <description>Dotted leader</description>
		/// </item>
		/// <item>
		/// <description><c>2</c></description>
		/// <description>Dashed leader</description>
		/// </item>
		/// <item>
		/// <description><c>3</c></description>
		/// <description>Underlined leader</description>
		/// </item>
		/// <item>
		/// <description><c>4</c></description>
		/// <description>Thick line leader</description>
		/// </item>
		/// <item>
		/// <description><c>5</c></description>
		/// <description>Double line leader</description>
		/// </item>
		/// </list>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32 /*MAX_TAB_STOPS*/)]
		public uint[] rgxTabs;
	}

	/// <summary>
	/// Contains information about paragraph formatting attributes in a rich edit control. <c>PARAFORMAT2</c> is a Microsoft Rich EditÂ 2.0
	/// extension of the PARAFORMAT structure. Microsoft Rich EditÂ 2.0 allows you to use either structure with the EM_GETPARAFORMAT and
	/// EM_SETPARAFORMAT messages.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-paraformat2 struct PARAFORMAT2 : _paraformat { LONG
	// dySpaceBefore; LONG dySpaceAfter; LONG dyLineSpacing; SHORT sStyle; BYTE bLineSpacingRule; BYTE bOutlineLevel; WORD wShadingWeight;
	// WORD wShadingStyle; WORD wNumberingStart; WORD wNumberingStyle; WORD wNumberingTab; WORD wBorderSpace; WORD wBorderWidth; WORD
	// wBorders; };
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit.PARAFORMAT2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PARAFORMAT2
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Structure size, in bytes. The member must be filled before passing to the rich edit control.</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Members containing valid information or attributes to set. This parameter can be none or a combination of the following values.
		/// If both PFM_STARTINDENT and PFM_OFFSETINDENT are specified, PFM_STARTINDENT takes precedence.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>PFM_ALIGNMENT</c></description>
		/// <description>The <c>wAlignment</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>PFM_NUMBERING</c></description>
		/// <description>The <c>wNumbering</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>PFM_OFFSET</c></description>
		/// <description>The <c>dxOffset</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>PFM_OFFSETINDENT</c></description>
		/// <description>The <c>dxStartIndent</c> member is valid and specifies a relative value.</description>
		/// </item>
		/// <item>
		/// <description><c>PFM_RIGHTINDENT</c></description>
		/// <description>The <c>dxRightIndent</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>PFM_RTLPARA</c></description>
		/// <description><c>Rich Edit 2.0:</c> The <c>wEffects</c> member is valid</description>
		/// </item>
		/// <item>
		/// <description><c>PFM_STARTINDENT</c></description>
		/// <description>The <c>dxStartIndent</c> member is valid.</description>
		/// </item>
		/// <item>
		/// <description><c>PFM_TABSTOPS</c></description>
		/// <description>The <c>cTabStobs</c> and <c>rgxTabStops</c> members are valid.</description>
		/// </item>
		/// </list>
		/// </summary>
		public PFM dwMask;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>Value specifying numbering options. This member can be zero or PFN_BULLET.</para>
		/// </summary>
		public PFN wNumbering;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para><c>Rich Edit 1.0:</c>: Reserved; the value must be zero.</para>
		/// <para>
		/// <c>Rich Edit 2.0:</c> A bit flag that specifies a paragraph effect. It is included only for compatibility with TOM interfaces;
		/// the rich edit control stores the value but does not use it to display the text. This parameter can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>0</c></description>
		/// <description>Displays text using left-to-right reading order. This is the default.</description>
		/// </item>
		/// <item>
		/// <description><c>PFE_RLTPARA</c></description>
		/// <description>Displays text using right-to-left reading order.</description>
		/// </item>
		/// </list>
		/// </summary>
		public PFE wEffects;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Indentation of the first line in the paragraph, in twips. If the paragraph formatting is being set and PFM_OFFSETINDENT is
		/// specified, this member is treated as a relative value that is added to the starting indentation of each affected paragraph.
		/// </para>
		/// </summary>
		public int dxStartIndent;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>Size, of the right indentation relative to the right margin, in twips.</para>
		/// </summary>
		public int dxRightIndent;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Indentation of the second and subsequent lines of a paragraph relative to the starting indentation, in twips. The first line is
		/// indented if this member is negative or outdented if this member is positive.
		/// </para>
		/// </summary>
		public int dxOffset;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>Value specifying the paragraph alignment. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>PFA_CENTER</c></description>
		/// <description>Paragraphs are centered.</description>
		/// </item>
		/// <item>
		/// <description><c>PFA_LEFT</c></description>
		/// <description>Paragraphs are aligned with the left margin.</description>
		/// </item>
		/// <item>
		/// <description><c>PFA_RIGHT</c></description>
		/// <description>Paragraphs are aligned with the right margin.</description>
		/// </item>
		/// </list>
		/// </summary>
		public PFA wAlignment;

		/// <summary>
		/// <para>Type: <c>SHORT</c></para>
		/// <para>Number of tab stops.</para>
		/// </summary>
		public short cTabCount;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Array of absolute tab stop positions. Each element in the array specifies information about a tab stop. The 24 low-order bits
		/// specify the absolute offset, in twips. To use this member, set the PFM_TABSTOPS flag in the <c>dwMask</c> member.
		/// </para>
		/// <para>
		/// <c>Rich Edit 2.0:</c> For compatibility with TOM interfaces, you can use the eight high-order bits to store additional
		/// information about each tab stop.
		/// </para>
		/// <para>
		/// Bits 24-27 can specify one of the following values to indicate the tab alignment. These bits do not affect the rich edit control
		/// display for versions earlier than Microsoft Rich EditÂ 3.0.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>0</c></description>
		/// <description>Ordinary tab</description>
		/// </item>
		/// <item>
		/// <description><c>1</c></description>
		/// <description>Center tab</description>
		/// </item>
		/// <item>
		/// <description><c>2</c></description>
		/// <description>Right-aligned tab</description>
		/// </item>
		/// <item>
		/// <description><c>3</c></description>
		/// <description>Decimal tab</description>
		/// </item>
		/// <item>
		/// <description><c>4</c></description>
		/// <description>Word bar tab (vertical bar)</description>
		/// </item>
		/// </list>
		/// <para>Â</para>
		/// <para>
		/// Bits 28-31 can specify one of the following values to indicate the type of tab leader. These bits do not affect the rich edit
		/// control display.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>0</c></description>
		/// <description>No leader</description>
		/// </item>
		/// <item>
		/// <description><c>1</c></description>
		/// <description>Dotted leader</description>
		/// </item>
		/// <item>
		/// <description><c>2</c></description>
		/// <description>Dashed leader</description>
		/// </item>
		/// <item>
		/// <description><c>3</c></description>
		/// <description>Underlined leader</description>
		/// </item>
		/// <item>
		/// <description><c>4</c></description>
		/// <description>Thick line leader</description>
		/// </item>
		/// <item>
		/// <description><c>5</c></description>
		/// <description>Double line leader</description>
		/// </item>
		/// </list>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32 /*MAX_TAB_STOPS*/)]
		public uint[] rgxTabs;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Size of the spacing above the paragraph, in twips. To use this member, set the PFM_SPACEBEFORE flag in the <c>dwMask</c> member.
		/// The value must be greater than or equal to zero.
		/// </para>
		/// </summary>
		public int dySpaceBefore;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Specifies the size of the spacing below the paragraph, in twips. To use this member, set the PFM_SPACEAFTER flag in the
		/// <c>dwMask</c> member. The value must be greater than or equal to zero.
		/// </para>
		/// </summary>
		public int dySpaceAfter;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Spacing between lines. For a description of how this value is interpreted, see the <c>bLineSpacingRule</c> member. To use this
		/// member, set the PFM_LINESPACING flag in the <c>dwMask</c> member.
		/// </para>
		/// </summary>
		public int dyLineSpacing;

		/// <summary>
		/// <para>Type: <c>SHORT</c></para>
		/// <para>
		/// Text style. To use this member, set the PFM_STYLE flag in the <c>dwMask</c> member. This member is included only for
		/// compatibility with TOM interfaces and Word; the rich edit control stores the value but does not use it to display the text.
		/// </para>
		/// </summary>
		public short sStyle;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>
		/// Type of line spacing. To use this member, set the PFM_LINESPACING flag in the <c>dwMask</c> member. This member can be one of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>0</c></description>
		/// <description>Single spacing. The <c>dyLineSpacing</c> member is ignored.</description>
		/// </item>
		/// <item>
		/// <description><c>1</c></description>
		/// <description>One-and-a-half spacing. The <c>dyLineSpacing</c> member is ignored.</description>
		/// </item>
		/// <item>
		/// <description><c>2</c></description>
		/// <description>Double spacing. The <c>dyLineSpacing</c> member is ignored.</description>
		/// </item>
		/// <item>
		/// <description><c>3</c></description>
		/// <description>
		/// The <c>dyLineSpacing</c> member specifies the spacingfrom one line to the next, in twips. However, if <c>dyLineSpacing</c>
		/// specifies a value that is less than single spacing, the control displays single-spaced text.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>4</c></description>
		/// <description>
		/// The <c>dyLineSpacing</c> member specifies the spacing from one line to the next, in twips. The control uses the exact spacing
		/// specified, even if <c>dyLineSpacing</c> specifies a value that is less than single spacing.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>5</c></description>
		/// <description>
		/// The value of <c>dyLineSpacing</c> / 20 is the spacing, in lines, from one line to the next. Thus, setting <c>dyLineSpacing</c> to
		/// 20 produces single-spaced text, 40 is double spaced, 60 is triple spaced, and so on.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		public byte bLineSpacingRule;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>Reserved; must be zero.</para>
		/// </summary>
		public byte bOutlineLevel;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// Percentage foreground color used in shading. The <c>wShadingStyle</c> member specifies the foreground and background shading
		/// colors. A value of 5 indicates a shading color consisting of 5 percent foreground color and 95 percent background color. To use
		/// these members, set the PFM_SHADING flag in the <c>dwMask</c> member. This member is included only for compatibility with Word;
		/// the rich edit control stores the value but does not use it to display the text.
		/// </para>
		/// </summary>
		public ushort wShadingWeight;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// Style and colors used for background shading. Bits 0 to 3 contain the shading style, bits 4 to 7 contain the foreground color
		/// index, and bits 8 to 11 contain the background color index. To use this member, set the PFM_SHADING flag in the <c>dwMask</c>
		/// member. This member is included only for compatibility with Word; the rich edit control stores the value but does not use it to
		/// display the text.
		/// </para>
		/// <para>The shading style can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>0</c></description>
		/// <description>None</description>
		/// </item>
		/// <item>
		/// <description><c>1</c></description>
		/// <description>Dark horizontal</description>
		/// </item>
		/// <item>
		/// <description><c>2</c></description>
		/// <description>Dark vertical</description>
		/// </item>
		/// <item>
		/// <description><c>3</c></description>
		/// <description>Dark down diagonal</description>
		/// </item>
		/// <item>
		/// <description><c>4</c></description>
		/// <description>Dark up diagonal</description>
		/// </item>
		/// <item>
		/// <description><c>5</c></description>
		/// <description>Dark grid</description>
		/// </item>
		/// <item>
		/// <description><c>6</c></description>
		/// <description>Dark trellis</description>
		/// </item>
		/// <item>
		/// <description><c>7</c></description>
		/// <description>Light horizontal</description>
		/// </item>
		/// <item>
		/// <description><c>8</c></description>
		/// <description>Light vertical</description>
		/// </item>
		/// <item>
		/// <description><c>9</c></description>
		/// <description>Light down diagonal</description>
		/// </item>
		/// <item>
		/// <description><c>10</c></description>
		/// <description>Light up diagonal</description>
		/// </item>
		/// <item>
		/// <description><c>11</c></description>
		/// <description>Light grid</description>
		/// </item>
		/// <item>
		/// <description><c>12</c></description>
		/// <description>Light trellis</description>
		/// </item>
		/// </list>
		/// <para>Â</para>
		/// <para>The foreground and background color indexes can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>0</c></description>
		/// <description>Black</description>
		/// </item>
		/// <item>
		/// <description><c>1</c></description>
		/// <description>Blue</description>
		/// </item>
		/// <item>
		/// <description><c>2</c></description>
		/// <description>Cyan</description>
		/// </item>
		/// <item>
		/// <description><c>3</c></description>
		/// <description>Green</description>
		/// </item>
		/// <item>
		/// <description><c>4</c></description>
		/// <description>Magenta</description>
		/// </item>
		/// <item>
		/// <description><c>5</c></description>
		/// <description>Red</description>
		/// </item>
		/// <item>
		/// <description><c>6</c></description>
		/// <description>Yellow</description>
		/// </item>
		/// <item>
		/// <description><c>7</c></description>
		/// <description>White</description>
		/// </item>
		/// <item>
		/// <description><c>8</c></description>
		/// <description>Dark blue</description>
		/// </item>
		/// <item>
		/// <description><c>9</c></description>
		/// <description>Dark cyan</description>
		/// </item>
		/// <item>
		/// <description><c>10</c></description>
		/// <description>Dark green</description>
		/// </item>
		/// <item>
		/// <description><c>11</c></description>
		/// <description>Dark magenta</description>
		/// </item>
		/// <item>
		/// <description><c>12</c></description>
		/// <description>Dark red</description>
		/// </item>
		/// <item>
		/// <description><c>13</c></description>
		/// <description>Dark yellow</description>
		/// </item>
		/// <item>
		/// <description><c>14</c></description>
		/// <description>Dark gray</description>
		/// </item>
		/// <item>
		/// <description><c>15</c></description>
		/// <description>Light gray</description>
		/// </item>
		/// </list>
		/// </summary>
		public ushort wShadingStyle;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// Starting number or Unicode value used for numbered paragraphs. Use this member in conjunction with the <c>wNumbering</c> member.
		/// This member is included only for compatibility with TOM interfaces; the rich edit control stores the value but does not use it to
		/// display the text or bullets. To use this member, set the PFM_NUMBERINGSTART flag in the <c>dwMask</c> member.
		/// </para>
		/// </summary>
		public ushort wNumberingStart;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// Numbering style used with numbered paragraphs. Use this member in conjunction with the <c>wNumbering</c> member. This member is
		/// included only for compatibility with TOM interfaces; the rich edit control stores the value but rich edit versions earlier than
		/// 3.0 do not use it to display the text or bullets. To use this member, set the PFM_NUMBERINGSTYLE flag in the <c>dwMask</c>
		/// member. This member can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>PFNS_PAREN</c></description>
		/// <description>Follows the number with a right parenthesis.</description>
		/// </item>
		/// <item>
		/// <description><c>PFNS_PARENS</c></description>
		/// <description>Encloses the number in parentheses.</description>
		/// </item>
		/// <item>
		/// <description><c>PFNS_PERIOD</c></description>
		/// <description>Follows the number with a period.</description>
		/// </item>
		/// <item>
		/// <description><c>PFNS_PLAIN</c></description>
		/// <description>Displays only the number.</description>
		/// </item>
		/// <item>
		/// <description><c>PFNS_NONUMBER</c></description>
		/// <description>Continues a numbered list without applying the next number or bullet.</description>
		/// </item>
		/// <item>
		/// <description><c>PFNS_NEWNUMBER</c></description>
		/// <description>Starts a new number with <c>wNumberingStart</c>.</description>
		/// </item>
		/// </list>
		/// </summary>
		public PFNS wNumberingStyle;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// Minimum space between a paragraph number and the paragraph text, in twips. Use this member in conjunction with the
		/// <c>wNumbering</c> member. The <c>wNumberingTab</c> member is included for compatibility with TOM interfaces; previous to
		/// Microsoft Rich EditÂ 3.0, the rich edit control stores the value but does not use it to display text. To use this member, set the
		/// PFM_NUMBERINGTAB flag in the <c>dwMask</c> member.
		/// </para>
		/// </summary>
		public ushort wNumberingTab;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// The space between the border and the paragraph text, in twips. The <c>wBorderSpace</c> member is included for compatibility with
		/// Word; the rich edit control stores the values but does not use them to display text. To use this member, set the PFM_BORDER flag
		/// in the <c>dwMask</c> member.
		/// </para>
		/// </summary>
		public ushort wBorderSpace;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>Border width, in twips. To use this member, set the PFM_BORDER flag in the <c>dwMask</c> member.</para>
		/// </summary>
		public ushort wBorderWidth;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// Border location, style, and color. Bits 0 to 7 specify the border locations, bits 8 to 11 specify the border style, and bits 12
		/// to 15 specify the border color index. To use this member, set the PFM_BORDER flag in the <c>dwMask</c> member.
		/// </para>
		/// <para>Specify the border locations using a combination of the following values in bits 0 to 7.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>1</c></description>
		/// <description>Left border.</description>
		/// </item>
		/// <item>
		/// <description><c>2</c></description>
		/// <description>Right border.</description>
		/// </item>
		/// <item>
		/// <description><c>4</c></description>
		/// <description>Top border.</description>
		/// </item>
		/// <item>
		/// <description><c>8</c></description>
		/// <description>Bottom border.</description>
		/// </item>
		/// <item>
		/// <description><c>16</c></description>
		/// <description>Inside borders.</description>
		/// </item>
		/// <item>
		/// <description><c>32</c></description>
		/// <description>Outside borders.</description>
		/// </item>
		/// <item>
		/// <description><c>64</c></description>
		/// <description>Autocolor. If this bit is set, the color index in bits 12 to 15 is not used.</description>
		/// </item>
		/// </list>
		/// <para>Â</para>
		/// <para>Specify the border style using one of the following values for bits 8 to 11.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>0</c></description>
		/// <description>None</description>
		/// </item>
		/// <item>
		/// <description><c>1</c></description>
		/// <description><c>3</c>/ <c>4</c> point</description>
		/// </item>
		/// <item>
		/// <description><c>2</c></description>
		/// <description>1 <c>1</c>/ <c>2</c> point</description>
		/// </item>
		/// <item>
		/// <description><c>3</c></description>
		/// <description>2 <c>1</c>/ <c>4</c> point</description>
		/// </item>
		/// <item>
		/// <description><c>4</c></description>
		/// <description>3 point</description>
		/// </item>
		/// <item>
		/// <description><c>5</c></description>
		/// <description>4 <c>1</c>/ <c>2</c> point</description>
		/// </item>
		/// <item>
		/// <description><c>6</c></description>
		/// <description>6 point</description>
		/// </item>
		/// <item>
		/// <description><c>7</c></description>
		/// <description><c>3</c>/ <c>4</c> point double</description>
		/// </item>
		/// <item>
		/// <description><c>8</c></description>
		/// <description>1 <c>1</c>/ <c>2</c> point double</description>
		/// </item>
		/// <item>
		/// <description><c>9</c></description>
		/// <description>2 <c>1</c>/ <c>4</c> point double</description>
		/// </item>
		/// <item>
		/// <description><c>10</c></description>
		/// <description><c>3</c>/ <c>4</c> point gray</description>
		/// </item>
		/// <item>
		/// <description><c>11</c></description>
		/// <description><c>3</c>/ <c>4</c> point gray dashed</description>
		/// </item>
		/// </list>
		/// <para>Â</para>
		/// <para>
		/// Specify the border color using one of the following values for bits 12 to 15. This value is ignored if the autocolor bit (bit 6)
		/// is set.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>0</c></description>
		/// <description>Black</description>
		/// </item>
		/// <item>
		/// <description><c>1</c></description>
		/// <description>Blue</description>
		/// </item>
		/// <item>
		/// <description><c>2</c></description>
		/// <description>Cyan</description>
		/// </item>
		/// <item>
		/// <description><c>3</c></description>
		/// <description>Green</description>
		/// </item>
		/// <item>
		/// <description><c>4</c></description>
		/// <description>Magenta</description>
		/// </item>
		/// <item>
		/// <description><c>5</c></description>
		/// <description>Red</description>
		/// </item>
		/// <item>
		/// <description><c>6</c></description>
		/// <description>Yellow</description>
		/// </item>
		/// <item>
		/// <description><c>7</c></description>
		/// <description>White</description>
		/// </item>
		/// <item>
		/// <description><c>8</c></description>
		/// <description>Dark blue</description>
		/// </item>
		/// <item>
		/// <description><c>9</c></description>
		/// <description>Dark cyan</description>
		/// </item>
		/// <item>
		/// <description><c>10</c></description>
		/// <description>Dark green</description>
		/// </item>
		/// <item>
		/// <description><c>11</c></description>
		/// <description>Dark magenta</description>
		/// </item>
		/// <item>
		/// <description><c>12</c></description>
		/// <description>Dark red</description>
		/// </item>
		/// <item>
		/// <description><c>13</c></description>
		/// <description>Dark yellow</description>
		/// </item>
		/// <item>
		/// <description><c>14</c></description>
		/// <description>Dark gray</description>
		/// </item>
		/// <item>
		/// <description><c>15</c></description>
		/// <description>Light gray</description>
		/// </item>
		/// </list>
		/// </summary>
		public ushort wBorders;
	}

	/// <summary>Contains information about the punctuation used in a rich edit control.</summary>
	/// <remarks>This structure is used only in Asian-language versions of the operating system.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-punctuation typedef struct _punctuation { UINT iSize; PSTR
	// szPunctuation; } PUNCTUATION;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._punctuation")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PUNCTUATION
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Size of buffer pointed to by the <c>szPunctuation</c> member, in bytes.</para>
		/// </summary>
		public uint iSize;

		/// <summary>
		/// <para>Type: <c>PSTR</c></para>
		/// <para>The buffer containing the punctuation characters.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string szPunctuation;
	}

	/// <summary>
	/// Contains information identifying whether the display aspect of a pasted object should be based on the content of the object or the
	/// icon that represent the object.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-repastespecial typedef struct _repastespecial { DWORD
	// dwAspect; DWORD_PTR dwParam; } REPASTESPECIAL;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._repastespecial")]
	[StructLayout(LayoutKind.Sequential)]
	public struct REPASTESPECIAL
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Display aspect. It can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>DVASPECT_CONTENT</c></description>
		/// <description>Aspect is based on the content of the object.</description>
		/// </item>
		/// <item>
		/// <description><c>DVASPECT_ICON</c></description>
		/// <description>Aspect is based on the icon view of the object.</description>
		/// </item>
		/// </list>
		/// </summary>
		public DVASPECT dwAspect;

		/// <summary>
		/// <para>Type: <c>DWORD_PTR</c></para>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Aspect data. If <c>dwAspect</c> is DVASPECT_ICON, this member contains the handle to the metafile with the icon view of the object.
		/// </para>
		/// </summary>
		public IntPtr dwParam;
	}

	/// <summary>
	/// Contains the requested size of a rich edit control. A rich edit control sends this structure to its parent window as part of an
	/// EN_REQUESTRESIZE notification code.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-reqresize typedef struct _reqresize { NMHDR nmhdr; RECT rc; } REQRESIZE;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._reqresize")]
	[StructLayout(LayoutKind.Sequential)]
	public struct REQRESIZE : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>Notification header.</para>
		/// </summary>
		public NMHDR nmhdr;

		/// <summary>
		/// <para>Type: <c>RECT</c></para>
		/// <para>Requested new size.</para>
		/// </summary>
		public RECT rc;
	}

	/// <summary>Defines the attributes of an image to be inserted by the EM_INSERTIMAGE message.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-richedit_image_parameters typedef struct
	// tagRICHEDIT_IMAGE_PARAMETERS { LONG xWidth; LONG yHeight; LONG Ascent; LONG Type; LPCWSTR pwszAlternateText; IStream *pIStream; } RICHEDIT_IMAGE_PARAMETERS;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit.tagRICHEDIT_IMAGE_PARAMETERS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RICHEDIT_IMAGE_PARAMETERS
	{
		/// <summary>The width, in HIMETRIC units (0.01 mm), of the image.</summary>
		public int xWidth;

		/// <summary/>
		public int yHeight;

		/// <summary>
		/// If <c>Type</c> is TA_BASELINE, this parameter is the distance, in HIMETRIC units, that the top of the image extends above the
		/// text baseline. If <c>Type</c> is TA_BASELINE and ascent is zero, the bottom of the image is placed at the text baseline.
		/// </summary>
		public int Ascent;

		/// <summary>
		/// <para>The vertical alignment of the image. It can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TA_BASELINE</c></description>
		/// <description>Align the image relative to the text baseline.</description>
		/// </item>
		/// <item>
		/// <description><c>TA_BOTTOM</c></description>
		/// <description>Align the bottom of the image at the bottom of the text line.</description>
		/// </item>
		/// <item>
		/// <description><c>TA_TOP</c></description>
		/// <description>Align the top of the image at the top of the text line</description>
		/// </item>
		/// </list>
		/// </summary>
		public Gdi32.TextAlign Type;

		/// <summary>The alternate text for the image.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszAlternateText;

		/// <summary>The stream that contains the image data.</summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public IStream pIStream;
	}

	/// <summary>
	/// Contains information associated with an EN_SELCHANGE notification code. A rich edit control sends this notification to its parent
	/// window when the current selection changes.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-selchange typedef struct _selchange { NMHDR nmhdr; CHARRANGE
	// chrg; WORD seltyp; } SELCHANGE;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._selchange")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SELCHANGE : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>Notification header.</para>
		/// </summary>
		public NMHDR nmhdr;

		/// <summary>
		/// <para>Type: <c>CHARRANGE</c></para>
		/// <para>New selection range.</para>
		/// </summary>
		public CHARRANGE chrg;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// Value specifying the contents of the new selection. This member is SEL_EMPTY if the selection is empty or one or more of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>SEL_TEXT</c></description>
		/// <description>Text.</description>
		/// </item>
		/// <item>
		/// <description><c>SEL_OBJECT</c></description>
		/// <description>At least one COM object.</description>
		/// </item>
		/// <item>
		/// <description><c>SEL_MULTICHAR</c></description>
		/// <description>More than one character of text.</description>
		/// </item>
		/// <item>
		/// <description><c>SEL_MULTIOBJECT</c></description>
		/// <description>More than one COM object.</description>
		/// </item>
		/// </list>
		/// </summary>
		public SEL seltyp;
	}

	/// <summary>
	/// Specifies which code page (if any) to use in setting text, whether the text replaces all the text in the control or just the
	/// selection, and whether the undo state is to be preserved. This structure is used with the EM_SETTEXTEX message.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-settextex typedef struct _settextex { DWORD flags; UINT
	// codepage; } SETTEXTEX;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._settextex")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SETTEXTEX
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Option flags. It can be any reasonable combination of the following flags.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>ST_DEFAULT</c></description>
		/// <description>Deletes the undo stack, discards rich-text formatting, replaces all text.</description>
		/// </item>
		/// <item>
		/// <description><c>ST_KEEPUNDO</c></description>
		/// <description>Keeps the undo stack.</description>
		/// </item>
		/// <item>
		/// <description><c>ST_SELECTION</c></description>
		/// <description>Replaces selection and keeps rich-text formatting.</description>
		/// </item>
		/// <item>
		/// <description><c>ST_NEWCHARS</c></description>
		/// <description>Act as if new characters are being entered.</description>
		/// </item>
		/// <item>
		/// <description><c>ST_UNICODE</c></description>
		/// <description>The text is UTF-16 (the <c>WCHAR</c> data type).</description>
		/// </item>
		/// </list>
		/// </summary>
		public ST flags;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The code page used to translate the text to Unicode. If <c>codepage</c> is 1200 (Unicode code page), no translation is done. If
		/// <c>codepage</c> is CP_ACP, the system code page is used.
		/// </para>
		/// </summary>
		public uint codepage;
	}

	/// <summary>
	/// Defines the attributes of cells in a table row. The definitions include the corresponding Rich Text Format (RTF) control words, which
	/// are defined in the Rich Text Format (RTF) Specification.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-tablecellparms typedef struct _tableCellParms { LONG dxWidth;
	// 2 WORD nVertAlign : 2; 1 WORD fMergeTop : 1; 1 WORD fMergePrev : 1; 1 WORD fVertical : 1; 1 WORD fMergeStart : 1; 1 WORD fMergeCont :
	// 1; WORD wShading; SHORT dxBrdrLeft; SHORT dyBrdrTop; SHORT dxBrdrRight; SHORT dyBrdrBottom; COLORREF crBrdrLeft; COLORREF crBrdrTop;
	// COLORREF crBrdrRight; COLORREF crBrdrBottom; COLORREF crBackPat; COLORREF crForePat; } TABLECELLPARMS;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._tableCellParms")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TABLECELLPARMS
	{
		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>The width of a cell (\cellx).</para>
		/// </summary>
		public int dxWidth;

		private ushort flags;

		/// <summary/>
		public byte nVertAlign { get => (byte)BitHelper.GetBits(flags, 0, 2); set => BitHelper.SetBits(ref flags, 0, 2, value); }

		/// <summary/>
		public bool fMergeTop { get => BitHelper.GetBit(flags, 2); set => BitHelper.SetBit(ref flags, 2, value); }

		/// <summary/>
		public bool fMergePrev { get => BitHelper.GetBit(flags, 3); set => BitHelper.SetBit(ref flags, 3, value); }

		/// <summary/>
		public bool fVertical { get => BitHelper.GetBit(flags, 4); set => BitHelper.SetBit(ref flags, 4, value); }

		/// <summary/>
		public bool fMergeStart { get => BitHelper.GetBit(flags, 5); set => BitHelper.SetBit(ref flags, 5, value); }

		/// <summary/>
		public bool fMergeCont { get => BitHelper.GetBit(flags, 6); set => BitHelper.SetBit(ref flags, 6, value); }

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// Shading in .01% (\clshdng). This controls the amount of pattern foreground color ( <c>crForePat</c>) and pattern background color
		/// ( <c>crBackPat</c>) that is used to create the cell background color. If <c>wShading</c> is 0, the cell background is
		/// <c>crBackPat</c>. If it's 10000, the cell background is <c>crForePat</c>. Values of <c>wShading</c> in between are mixtures of
		/// the two pattern colors.
		/// </para>
		/// </summary>
		public ushort wShading;

		/// <summary>
		/// <para>Type: <c>SHORT</c></para>
		/// <para>Left border width, in twips (\clbrdrl\brdrwN).</para>
		/// </summary>
		public short dxBrdrLeft;

		/// <summary>
		/// <para>Type: <c>SHORT</c></para>
		/// <para>Top border width (\clbrdrt\brdrwN).</para>
		/// </summary>
		public short dyBrdrTop;

		/// <summary>
		/// <para>Type: <c>SHORT</c></para>
		/// <para>Right border width (\clbrdrr\brdrwN).</para>
		/// </summary>
		public short dxBrdrRight;

		/// <summary>
		/// <para>Type: <c>SHORT</c></para>
		/// <para>Bottom border width (\clbrdrb\brdrwN).</para>
		/// </summary>
		public short dyBrdrBottom;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>Left border color (\clbrdrl\brdrcf).</para>
		/// </summary>
		public COLORREF crBrdrLeft;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>Top border color (\clbrdrt\brdrcf).</para>
		/// </summary>
		public COLORREF crBrdrTop;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>Right border color (\clbrdrr\brdrcf).</para>
		/// </summary>
		public COLORREF crBrdrRight;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>Bottom border color (\clbrdrb\brdrcf).</para>
		/// </summary>
		public COLORREF crBrdrBottom;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>Background color (\clcbpat).</para>
		/// </summary>
		public COLORREF crBackPat;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>Foreground color (\clcfpat).</para>
		/// </summary>
		public COLORREF crForePat;
	}

	/// <summary>
	/// Defines the attributes of rows in a table. The definitions include the corresponding Rich Text Format (RTF) control words, which are
	/// defined in the Rich Text Format (RTF) Specification.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-tablerowparms typedef struct _tableRowParms { BYTE cbRow;
	// BYTE cbCell; BYTE cCell; BYTE cRow; LONG dxCellMargin; LONG dxIndent; LONG dyHeight; 3 DWORD nAlignment : 3; 1 DWORD fRTL : 1; 1 DWORD
	// fKeep : 1; 1 DWORD fKeepFollow : 1; 1 DWORD fWrap : 1; 1 DWORD fIdentCells : 1; LONG cpStartRow; BYTE bTableLevel; BYTE iCell; } TABLEROWPARMS;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._tableRowParms")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TABLEROWPARMS
	{
		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>The count of bytes in this structure.</para>
		/// </summary>
		public byte cbRow;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>The count of bytes in TABLECELLPARMS.</para>
		/// </summary>
		public byte cbCell;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>The count of cells in a row, up to the maximum specified by MAX_TABLE_CELLS.</para>
		/// </summary>
		public byte cCell;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>The count of rows.</para>
		/// </summary>
		public byte cRow;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>The size of the left and right margins in a cell (\trgaph).</para>
		/// </summary>
		public int dxCellMargin;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>The amount of left indentation, or right indentation if the <c>fRTL</c> member is <c>TRUE</c> (similar to \trleft).</para>
		/// </summary>
		public int dxIndent;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>The height of a row (\trrh).</para>
		/// </summary>
		public int dyHeight;

		private uint flags;

		/// <summary/>
		public uint nAlignment { get => (byte)BitHelper.GetBits(flags, 0, 3); set => BitHelper.SetBits(ref flags, 0, 3, value); }

		/// <summary/>
		public bool fRTL { get => BitHelper.GetBit(flags, 3); set => BitHelper.SetBit(ref flags, 3, value); }

		/// <summary/>
		public bool fKeep { get => BitHelper.GetBit(flags, 4); set => BitHelper.SetBit(ref flags, 4, value); }

		/// <summary/>
		public bool fKeepFollow { get => BitHelper.GetBit(flags, 5); set => BitHelper.SetBit(ref flags, 5, value); }

		/// <summary/>
		public bool fWrap { get => BitHelper.GetBit(flags, 6); set => BitHelper.SetBit(ref flags, 6, value); }

		/// <summary/>
		public bool fIdentCells { get => BitHelper.GetBit(flags, 7); set => BitHelper.SetBit(ref flags, 7, value); }

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>The character position that indicates where to insert table. A value of â1 indicates the character position of the selection.</para>
		/// </summary>
		public int cpStartRow;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>The table nesting level (EM_GETTABLEPARMS only).</para>
		/// </summary>
		public byte bTableLevel;

		/// <summary>
		/// <para>Type: <c>BYTE</c></para>
		/// <para>The index of the cell to insert or delete (EM_SETTABLEPARMS only).</para>
		/// </summary>
		public byte iCell;
	}

	/// <summary>
	/// A range of text from a rich edit control. This structure is filled in by the EM_GETTEXTRANGE message. The buffer pointed to by the
	/// <c>lpstrText</c> member must be large enough to receive all characters and the terminating null character.
	/// </summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The richedit.h header defines TEXTRANGE as an alias which automatically selects the ANSI or Unicode version of this function based on
	/// the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not encoding-neutral
	/// can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-textrangea typedef struct _textrange { CHARRANGE chrg; PSTR
	// lpstrText; } TEXTRANGEA;
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._textrange")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct TEXTRANGE
	{
		/// <summary>
		/// <para>Type: <c>CHARRANGE</c></para>
		/// <para>The range of characters to retrieve.</para>
		/// </summary>
		public CHARRANGE chrg;

		/// <summary>
		/// <para>Type: <c>PSTR</c></para>
		/// <para>The text.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpstrText;
	}
}