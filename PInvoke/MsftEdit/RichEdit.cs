using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

/// <summary>Items from the MsftEdit.dll.</summary>
public static partial class MsftEdit
{
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

	/// <summary>Indicates the state of the composition.</summary>
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._endcomposition")]
	public enum ECN : uint
	{
		/// <summary>The composition is complete.</summary>
		ECN_ENDCOMPOSITION = 1,

		/// <summary>There are new characters in the composition.</summary>
		ECN_NEWTEXT = 2,
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

	/// <summary>Type of composition string.</summary>
	[PInvokeData("richedit.h", MSDNShortId = "NS:richedit._imecomptext")]
	[Flags]
	public enum ICT : uint
	{
		/// <summary>The final composed string.</summary>
		ICT_RESULTREADSTR = 0x0001,
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
		public string lpDefaultChar;

		/// <summary>
		/// <para>Type: <c>LPBOOL</c></para>
		/// <para>
		/// A flag that indicates whether the default character ( <c>lpDefaultChar</c>) was used. This member is used only if the code page
		/// is not 1200 or <c>CP_UTF8</c> (Unicode). The flag is <c>TRUE</c> if one or more wide characters in the source string cannot be
		/// represented in the specified code page. Otherwise, the flag is <c>FALSE</c>. This member can be NULL.
		/// </para>
		/// </summary>
		public IntPtr lpUsedDefChar;
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
		public Action<StrPtrUni, LANGID, int, IntPtr> pfnHyphenate
		{
			get => (Action<StrPtrUni, LANGID, int, IntPtr>)Marshal.GetDelegateForFunctionPointer(pfn, typeof(Action<StrPtrUni, LANGID, int, IntPtr>));
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
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-punctuation typedef struct _punctuation { UINT iSize; LPSTR
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
		/// <para>Type: <c>LPSTR</c></para>
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
	// https://learn.microsoft.com/en-us/windows/win32/api/richedit/ns-richedit-textrangea typedef struct _textrange { CHARRANGE chrg; LPSTR
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
		/// <para>Type: <c>LPSTR</c></para>
		/// <para>The text.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpstrText;
	}
}