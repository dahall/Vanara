using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class MsftEdit
{
	/// <summary>Retrieves the Unicode Transformation Format (UTF)-32 math alphanumeric character that corresponds to the specified Basic Multilingual Plane (BMP) character and math style.</summary>
	/// <param name="ch">
	/// <para>[in] Type: <c>LONG</c></para>
	/// <para>A BMP character.</para>
	/// </param>
	/// <param name="MathStyle">
	/// <para>[in] Type: <c>DWORD</c></para>
	/// <para>Math style. This parameter can be one of the values from the <c>MANCODE</c> enumeration.</para>
	/// </param>
	/// <returns>
	/// <para>Type:</para>
	/// <para>Returns the corresponding UTF-32 math alphanumeric character, or 0 if no such character exists.</para>
	/// </returns>
	/// <remarks>This function is exported by the RichEdit 6.0 or later msftedit.dll.</remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/hh780353(v=vs.85)
	// GetMathAlphanumeric( _In_&#194; LONG &#194; ch, _In_&#194; DWORD MathStyle );
	[PInvokeData("Tom.h")]
	[DllImport(Lib_msftedit, SetLastError = false, ExactSpelling = true)]
	public static extern uint GetMathAlphanumeric([In] int ch, [In] uint MathStyle);

	/// <summary>Retrieves the math style and the upright Basic Multilingual Plane (BMP) character code that corresponds to the specified trailing byte of a math surrogate pair.</summary>
	/// <param name="chTrail">
	/// <para>[in] Type: <c>DWORD</c></para>
	/// <para>The trailing byte of the math surrogate pair. It can be a surrogate trail code (0xDC00â0xDFFF), a letter-like character (0x2102â0x2134), or the UTF-32 value of a higher-plane character such as 0x1D44E.</para>
	/// </param>
	/// <param name="pch">
	/// <para>[out] Type: <c>WCHAR*</c></para>
	/// <para>A buffer that receives the upright BMP character code. If no such character exists, pch receives 0.</para>
	/// </param>
	/// <returns>
	/// <para>Type:</para>
	/// <para>Returns the math style, which consists of a pair of values from the <c>MANCODE</c> enumeration. It can be one of the following values:</para>
	/// <para>0</para>
	/// <para><c>MBOLD</c></para>
	/// <para><c>MITAL</c></para>
	/// <para><c>MGREEK</c></para>
	/// <para>combined with one of following values:</para>
	/// <para><c>MROMN</c></para>
	/// <para><c>MSCRP</c></para>
	/// <para><c>MFRAK</c></para>
	/// <para><c>MOPEN</c></para>
	/// <para><c>MSANS</c></para>
	/// <para><c>MMONO</c></para>
	/// </returns>
	/// <remarks>This function is exported by the RichEdit 6.0 or later msftedit.dll.</remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/hh780354(v=vs.85)
	// GetMathAlphanumericCode( _In_&#194; &#194; DWORD chTrail, _Out_&#194; WCHAR *pch );
	[PInvokeData("Tom.h")]
	[DllImport(Lib_msftedit, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	public static extern MANCODE GetMathAlphanumericCode([In] uint chTrail, out char pch);

	/// <summary>Translates the built-up math, ruby, and other inline objects in the specified range to linear form.</summary>
	/// <param name="prg">
	/// <para>[in, out]</para>
	/// <para>Type: <c>ITextRange2*</c></para>
	/// <para>On input, a text range object that contains the built-up math objects to convert to linear form. On output, the object contains the linear form.</para>
	/// </param>
	/// <param name="pstrs">
	/// <para>[in]</para>
	/// <para>Type: <c>ITextStrings*</c></para>
	/// <para>Strings collection used for manipulations.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>[in]</para>
	/// <para>Type: <c>long</c></para>
	/// <para>A combination of the following flags.</para>
	/// <para><c>tomMathAlphabetics</c></para>
	/// <para><c>tomMathBuildDownOutermost</c></para>
	/// <para><c>tomMathBuildUpArgOrZone</c></para>
	/// <para><c>tomMathRemoveOutermost</c></para>
	/// <para><c>tomPlain</c></para>
	/// <para><c>tomTeX</c></para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>See Remarks.</para>
	/// </returns>
	/// <remarks>
	/// <para>If the linearization is successful, the originally selected range is replaced by the linearized version.</para>
	/// <para>If the <c>tomMathRemoveOutermost</c> or <c>tomMathBuildDownOutermost</c> build down mode is specified, the build down operation can be affected by the <c>tomMathChangeMask</c> values. The main purpose of these build-down modes is to facilitate transformations of the build-up math object as exposed by math context menus.</para>
	/// <para>For example, to convert a stacked fraction to a linear fraction as in (a+b/c)/(u+x/y)â((a+b/c))â((u+x/y)), parentheses must be inserted; otherwise, you get a transformation that looks incorrect, as in (a+b/c)/(u+x/y)â(a+b/c)â(u+x/y), even though internally the linear fraction still has the original numerator and denominator.</para>
	/// <para>The build-down process automatically inserts the parentheses, because the linear format for this case has parentheses, and the special change is made to replace the stacked-fraction operator U+002F by the linear fraction operator U+2215. Build up doesn't discard the parentheses for U+2215, but it does for U+002F.</para>
	/// <para>This function is exported by the RichEdit 6.0 or later msftedit.dll.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/hh780443(v=vs.85)
	// HRESULT MathBuildDown( _Inout_&#194; ITextRange2 &#194; *prg, _In_&#194; &#194; &#194; &#194; ITextStrings *pstrs, _In_&#194; &#194; &#194; &#194; long &#194; &#194; &#194; &#194; &#194; &#194; &#194; &#194; Flags );
	[PInvokeData("Tom.h")]
	[DllImport(Lib_msftedit, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT MathBuildDown([In, Out] ITextRange2 prg, [In] ITextStrings pstrs, long Flags);

	/// <summary>Converts the linear-format math in a range to a built-up form, or modifies the current built-up form.</summary>
	/// <param name="prg">
	/// <para>[in, out]</para>
	/// <para>Type: <c>ITextRange2*</c></para>
	/// <para>On input, a text range object that contains the linearly formatted math expressions to be converted into built-up math. On output, the object contains the built-up math.</para>
	/// </param>
	/// <param name="pstrs">
	/// <para>[in]</para>
	/// <para>Type: <c>ITextStrings*</c></para>
	/// <para>Strings collection used for manipulations.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>[in]</para>
	/// <para>Type: <c>long</c></para>
	/// <para>A combination of the following flags.</para>
	/// <para><c>tomChemicalFormula</c></para>
	/// <para><c>tomHaveDelimiter</c></para>
	/// <para><c>tomMathAlphabetics</c></para>
	/// <para><c>tomMathApplyTemplate</c></para>
	/// <para><c>tomMathArabicAlphabetics</c></para>
	/// <para><c>tomMathAutoCorrect</c></para>
	/// <para><c>tomMathAutoCorrectExt</c></para>
	/// <para><c>tomMathAutoCorrectOpPairs</c></para>
	/// <para><c>tomMathBackspace</c></para>
	/// <para><c>tomMathBuildDown</c></para>
	/// <para><c>tomMathBuildDownOutermost</c></para>
	/// <para><c>tomMathBuildUpArgOrZone</c></para>
	/// <para><c>tomMathBuildUpRecurse</c></para>
	/// <para><c>tomMathChangeMask</c></para>
	/// <para><c>tomMathCollapseSel</c></para>
	/// <para><c>tomMathDeleteArg</c></para>
	/// <para><c>tomMathDeleteArg1</c></para>
	/// <para><c>tomMathDeleteArg2</c></para>
	/// <para><c>tomMathDeleteCol</c></para>
	/// <para><c>tomMathDeleteRow</c></para>
	/// <para><c>tomMathEnter</c></para>
	/// <para><c>tomMathInsColAfter</c></para>
	/// <para><c>tomMathInsColBefore</c></para>
	/// <para><c>tomMathInsRowAfter</c></para>
	/// <para><c>tomMathInsRowBefore</c></para>
	/// <para><c>tomMathMakeFracLinear</c></para>
	/// <para><c>tomMathMakeFracSlashed</c></para>
	/// <para><c>tomMathMakeFracStacked</c></para>
	/// <para><c>tomMathMakeLeftSubSup</c></para>
	/// <para><c>tomMathMakeSubSup</c></para>
	/// <para><c>tomMathRemoveOutermost</c></para>
	/// <para><c>tomMathRichEdit</c></para>
	/// <para><c>tomMathShiftTab</c></para>
	/// <para><c>tomMathSingleChar</c></para>
	/// <para><c>tomMathSubscript</c></para>
	/// <para><c>tomMathSuperscript</c></para>
	/// <para><c>tomMathTab</c></para>
	/// <para><c>tomNeedTermOp</c></para>
	/// <para><c>tomPlain</c></para>
	/// <para><c>tomShowEmptyArgPlaceholders</c></para>
	/// <para><c>tomTeX</c></para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>See Remarks.</para>
	/// </returns>
	/// <remarks>
	/// <para>If the <c>MathBuildUp</c> method is called on a nondegenerate range, the method checks the text for math italic conversions (if <c>tomMathAlphabetics</c> is specified) and math autocorrect conversions (if <c>tomMathAutoCorrect</c> or <c>tomMathAutoCorrectExt</c> is specified). Then, the method attempts to build up the selected text. If successful, the method replaces the previous text in the range with the built-up text. If the method makes any changes to the range, the function returns <c>NOERROR</c> and the range selects the result. If the method does change the range, it returns <c>S_FALSE</c> or a Component Object Model (COM) error code.</para>
	/// <para>If the <c>MathBuildUp</c> method is called on a degenerate range, the <c>MathBuildUp</c> method treats the range as an insertion point (IP) immediately following the last character input. The method converts that character, possibly along with some preceding characters, to math italic (if <c>tomMathAlphabetics</c> is specified), internal math autocorrect (if <c>tomMathAutoCorrect</c> is specified), negated operators, and some operator pairs (if <c>tomMathAutoCorrectOpPairs</c> is specified). If the IP is inside an argument, the method scans a range of text from the IP back to the start of a math object argument; otherwise, the method scans to the start of the current math zone. The scan is terminated by a hard carriage return or a soft end-of-paragraph mark, because math zones are terminated by these marks. A scan forward from start of the math object argument or math zone bypasses text that has no chance of being built up. If the scan reaches the original entry IP, one of the following outcomes can occur:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>If the method made any changes, the function returns <c>NOERROR</c> and the range updated with the changed text.</description>
	/// </item>
	/// <item>
	/// <description>If the method made no changes, the function returns <c>S_FALSE</c> and leaves the range unchanged.</description>
	/// </item>
	/// </list>
	/// <para>If the scan finds text that might get built up, the <c>MathBuildUp</c> method attempts to build up the text up to the insertion point. If successful, the method returns <c>NOERROR</c>, and the range is updated with the corresponding built-up text.</para>
	/// <para>If this full build-up attempt fails, the <c>MathBuildUp</c> method does a partial build-up check for the expression immediately preceding the IP. If this succeeds, the method returns <c>NOERROR</c> and the range contains the linear text to be replaced by the built-up text.</para>
	/// <para>If full and partial build-up attempts fail, the function returns as described previously for the cases where no build-up text was found. Other possible return values include <c>E_INVALIDARG</c> (if either interface pointer is <c>NULL</c>) and <c>E_OUTOFMEMORY</c>.</para>
	/// <para>You should set the <c>tomNeedTermOp</c> flag should for formula autobuildup unless autocorrection has occurred that deletes the terminating blank. Autocorrection can occur when correcting text like \alpha when the user types a blank to force autocorrection.</para>
	/// <para>This function is exported by the RichEdit 6.0 or later msftedit.dll.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/hh780445(v=vs.85)
	// HRESULT MathBuildUp( _Inout_&#194; ITextRange2 &#194; *prg, _In_&#194; &#194; &#194; &#194; ITextStrings *pstrs, _In_&#194; &#194; &#194; &#194; long &#194; &#194; &#194; &#194; &#194; &#194; &#194; &#194; Flags );
	[PInvokeData("Tom.h")]
	[DllImport(Lib_msftedit, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT MathBuildUp([In, Out] ITextRange2 prg, [In] ITextStrings pstrs, [In] long Flags);

	/// <summary>Translates the math characters in the specified range.</summary>
	/// <param name="prg">
	/// <para>[in, out] Type: <c>ITextRange2*</c></para>
	/// <para>On entry, this parameter specifies the text range that contains the math characters to translate. On successful exit, the characters in the range have been translated as specified</para>
	/// </param>
	/// <param name="Flags">
	/// <para>[in] Type: <c>long</c></para>
	/// <para>The translation flags, which can be one or more of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>tomConvertMathChar</c></description>
	/// <description>Converts to/from math italic and/or math bold according to the status of italic and bold retrieved by the <c>ITextFont2::GetEffects</c> method.</description>
	/// </item>
	/// <item>
	/// <description><c>tomFoldMathAlpha</c></description>
	/// <description>Converts from math alphanumerics back to ASCII and Basic Multilingual Plane (BMP) Greek.</description>
	/// </item>
	/// <item>
	/// <description><c>tomMathAlphabetics</c></description>
	/// <description>Converts to math italic.</description>
	/// </item>
	/// </list>
	/// <para>Â</para>
	/// <para>Other flags are ignored and must be zero.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>This function is exported by the RichEdit 6.0 or later msftedit.dll.</remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/hh780446(v=vs.85)
	// HRESULT MathTranslate( _Inout_&#194; ITextRange2 *prg, _In_&#194; &#194; &#194; &#194; long &#194; &#194; &#194; &#194; &#194; &#194; &#194; Flags );
	[PInvokeData("Tom.h")]
	[DllImport(Lib_msftedit, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT MathTranslate([In, Out] ITextRange2 prg, [In] long Flags);

	/// <summary>Represents mathematical alphanumeric codes.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/ne-tom-mancode
	// typedef enum __MIDL___MIDL_itf_tom_0000_0000_0003 { MBOLD = 0x10, MITAL = 0x20, MGREEK = 0x40, MROMN = 0, MSCRP = 1, MFRAK = 2, MOPEN = 3, MSANS = 4, MMONO = 5, MMATH = 6, MISOL = 7, MINIT = 8, MTAIL = 9, MSTRCH = 10, MLOOP = 11, MOPENA = 12 } MANCODE;
	[PInvokeData("tom.h", MSDNShortId = "NE:tom.__MIDL___MIDL_itf_tom_0000_0000_0003")]
	public enum MANCODE
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x10</para>
		///   <para>Bold</para>
		/// </summary>
		MBOLD,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x20</para>
		///   <para>Italics</para>
		/// </summary>
		MITAL,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x40</para>
		///   <para>Greek</para>
		/// </summary>
		MGREEK,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>Roman</para>
		/// </summary>
		MROMN,
		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>Script</para>
		/// </summary>
		MSCRP,
		/// <summary>
		///   <para>Value:</para>
		///   <para>2</para>
		///   <para>Fraktur</para>
		/// </summary>
		MFRAK,
		/// <summary>
		///   <para>Value:</para>
		///   <para>3</para>
		///   <para>Double struck</para>
		/// </summary>
		MOPEN,
		/// <summary>
		///   <para>Value:</para>
		///   <para>4</para>
		///   <para>Sans-serif</para>
		/// </summary>
		MSANS,
		/// <summary>
		///   <para>Value:</para>
		///   <para>5</para>
		///   <para>Monospaced</para>
		/// </summary>
		MMONO,
		/// <summary>
		///   <para>Value:</para>
		///   <para>6</para>
		///   <para>Math</para>
		/// </summary>
		MMATH,
		/// <summary>
		///   <para>Value:</para>
		///   <para>7</para>
		///   <para>Isolated</para>
		/// </summary>
		MISOL,
		/// <summary>
		///   <para>Value:</para>
		///   <para>8</para>
		///   <para>Initial</para>
		/// </summary>
		MINIT,
		/// <summary>
		///   <para>Value:</para>
		///   <para>9</para>
		///   <para>Tailed</para>
		/// </summary>
		MTAIL,
		/// <summary>
		///   <para>Value:</para>
		///   <para>10</para>
		///   <para>Stretched</para>
		/// </summary>
		MSTRCH,
		/// <summary>
		///   <para>Value:</para>
		///   <para>11</para>
		///   <para>Looped</para>
		/// </summary>
		MLOOP,
		/// <summary>
		///   <para>Value:</para>
		///   <para>12</para>
		///   <para>Arabic double-struck</para>
		/// </summary>
		MOPENA,
	}

	/// <summary>Defines values that identify object types in the Text Object Model (TOM) content.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/ne-tom-objecttype
	// typedef enum __MIDL___MIDL_itf_tom_0000_0000_0002 { tomSimpleText = 0, tomRuby, tomHorzVert, tomWarichu, tomEq = 9, tomMath = 10, tomAccent = tomMath, tomBox, tomBoxedFormula, tomBrackets, tomBracketsWithSeps, tomEquationArray, tomFraction, tomFunctionApply, tomLeftSubSup, tomLowerLimit, tomMatrix, tomNary, tomOpChar, tomOverbar, tomPhantom, tomRadical, tomSlashedFraction, tomStack, tomStretchStack, tomSubscript, tomSubSup, tomSuperscript, tomUnderbar, tomUpperLimit, tomObjectMax } OBJECTTYPE;
	[PInvokeData("tom.h", MSDNShortId = "NE:tom.__MIDL___MIDL_itf_tom_0000_0000_0002")]
	public enum OBJECTTYPE
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>Not an inline function.</para>
		/// </summary>
		tomSimpleText = 0,
		/// <summary>Base text with ruby annotation.</summary>
		tomRuby,
		/// <summary>Text flows horizontally in a vertically oriented document.</summary>
		tomHorzVert,
		/// <summary>A Warichu "2 lines in one" comment.</summary>
		tomWarichu,
		/// <summary>
		///   <para>Value:</para>
		///   <para>9</para>
		///   <para>An RTF Eq (equation) field.</para>
		/// </summary>
		tomEq = 9,
		/// <summary>
		///   <para>Value:</para>
		///   <para>10</para>
		///   <para>Math.</para>
		/// </summary>
		tomMath,
		/// <summary>
		///   <para>Value:</para>
		///   <para>tomMath</para>
		///   <para>Accent (combining mark).</para>
		/// </summary>
		tomAccent = tomMath,
		/// <summary>Abstract box with properties.</summary>
		tomBox,
		/// <summary>Encloses the argument in a rectangle.</summary>
		tomBoxedFormula,
		/// <summary>Encloses the argument in brackets, parentheses, and so on.</summary>
		tomBrackets,
		/// <summary>Encloses the argument in brackets, parentheses, and so on, and with separators.</summary>
		tomBracketsWithSeps,
		/// <summary>Column of aligned equations.</summary>
		tomEquationArray,
		/// <summary>Fraction.</summary>
		tomFraction,
		/// <summary>Function apply.</summary>
		tomFunctionApply,
		/// <summary>Left subscript or superscript.</summary>
		tomLeftSubSup,
		/// <summary>Second argument below the first.</summary>
		tomLowerLimit,
		/// <summary>Matrix.</summary>
		tomMatrix,
		/// <summary>
		///   <para>General</para>
		///   <para>n</para>
		///   <para>-ary expression.</para>
		/// </summary>
		tomNary,
		/// <summary>Internal use for no-build operators.</summary>
		tomOpChar,
		/// <summary>Overscores argument.</summary>
		tomOverbar,
		/// <summary>Special spacing.</summary>
		tomPhantom,
		/// <summary>Square root, and so on.</summary>
		tomRadical,
		/// <summary>Skewed and built-up linear fractions.</summary>
		tomSlashedFraction,
		/// <summary>"Fraction" with no divide bar.</summary>
		tomStack,
		/// <summary>Stretch character horizontally over or under argument.</summary>
		tomStretchStack,
		/// <summary>Subscript.</summary>
		tomSubscript,
		/// <summary>Subscript and superscript combination.</summary>
		tomSubSup,
		/// <summary>Superscript.</summary>
		tomSuperscript,
		/// <summary>Underscores the argument.</summary>
		tomUnderbar,
		/// <summary>Second argument above the first.</summary>
		tomUpperLimit,
		/// <summary>
		///   <para>The maximum value in the</para>
		///   <para>OBJECTTYPE</para>
		///   <para>enumeration.</para>
		/// </summary>
		tomObjectMax,
	}

	/// <summary>Defines values that are used with the Text Object Model (TOM) API.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/ne-tom-tomconstants
	// typedef enum __MIDL___MIDL_itf_tom_0000_0000_0001 { tomFalse = 0, tomTrue = -1, tomUndefined = -9999999, tomToggle = -9999998, tomAutoColor = -9999997, tomDefault = -9999996, tomSuspend = -9999995, tomResume = -9999994, tomApplyNow = 0, tomApplyLater = 1, tomTrackParms = 2, tomCacheParms = 3, tomApplyTmp = 4, tomDisableSmartFont = 8, tomEnableSmartFont = 9, tomUsePoints = 10, tomUseTwips = 11, tomBackward = 0xc0000001, tomForward = 0x3fffffff, tomMove = 0, tomExtend = 1, tomNoSelection = 0, tomSelectionIP = 1, tomSelectionNormal = 2, tomSelectionFrame = 3, tomSelectionColumn = 4, tomSelectionRow = 5, tomSelectionBlock = 6, tomSelectionInlineShape = 7, tomSelectionShape = 8, tomSelStartActive = 1, tomSelAtEOL = 2, tomSelOvertype = 4, tomSelActive = 8, tomSelReplace = 16, tomEnd = 0, tomStart = 32, tomCollapseEnd = 0, tomCollapseStart = 1, tomClientCoord = 256, tomAllowOffClient = 512, tomTransform = 1024, tomObjectArg = 2048, tomAtEnd = 4096, tomNone = 0, tomSingle = 1, tomWords = 2, tomDouble = 3, tomDotted = 4, tomDash = 5, tomDashDot = 6, tomDashDotDot = 7, tomWave = 8, tomThick = 9, tomHair = 10, tomDoubleWave = 11, tomHeavyWave = 12, tomLongDash = 13, tomThickDash = 14, tomThickDashDot = 15, tomThickDashDotDot = 16, tomThickDotted = 17, tomThickLongDash = 18, tomLineSpaceSingle = 0, tomLineSpace1pt5 = 1, tomLineSpaceDouble = 2, tomLineSpaceAtLeast = 3, tomLineSpaceExactly = 4, tomLineSpaceMultiple = 5, tomLineSpacePercent = 6, tomAlignLeft = 0, tomAlignCenter = 1, tomAlignRight = 2, tomAlignJustify = 3, tomAlignDecimal = 3, tomAlignBar = 4, tomDefaultTab = 5, tomAlignInterWord = 3, tomAlignNewspaper = 4, tomAlignInterLetter = 5, tomAlignScaled = 6, tomSpaces = 0, tomDots = 1, tomDashes = 2, tomLines = 3, tomThickLines = 4, tomEquals = 5, tomTabBack = -3, tomTabNext = -2, tomTabHere = -1, tomListNone = 0, tomListBullet = 1, tomListNumberAsArabic = 2, tomListNumberAsLCLetter = 3, tomListNumberAsUCLetter = 4, tomListNumberAsLCRoman = 5, tomListNumberAsUCRoman = 6, tomListNumberAsSequence = 7, tomListNumberedCircle = 8, tomListNumberedBlackCircleWingding = 9, tomListNumberedWhiteCircleWingding = 10, tomListNumberedArabicWide = 11, tomListNumberedChS = 12, tomListNumberedChT = 13, tomListNumberedJpnChS = 14, tomListNumberedJpnKor = 15, tomListNumberedArabic1 = 16, tomListNumberedArabic2 = 17, tomListNumberedHebrew = 18, tomListNumberedThaiAlpha = 19, tomListNumberedThaiNum = 20, tomListNumberedHindiAlpha = 21, tomListNumberedHindiAlpha1 = 22, tomListNumberedHindiNum = 23, tomListParentheses = 0x10000, tomListPeriod = 0x20000, tomListPlain = 0x30000, tomListNoNumber = 0x40000, tomListMinus = 0x80000, tomIgnoreNumberStyle = 0x1000000, tomParaStyleNormal = -1, tomParaStyleHeading1 = -2, tomParaStyleHeading2 = -3, tomParaStyleHeading3 = -4, tomParaStyleHeading4 = -5, tomParaStyleHeading5 = -6, tomParaStyleHeading6 = -7, tomParaStyleHeading7 = -8, tomParaStyleHeading8 = -9, tomParaStyleHeading9 = -10, tomCharacter = 1, tomWord = 2, tomSentence = 3, tomParagraph = 4, tomLine = 5, tomStory = 6, tomScreen = 7, tomSection = 8, tomTableColumn = 9, tomColumn = 9, tomRow = 0xc, tomWindow = 11, tomCell = 12, tomCharFormat = 13, tomParaFormat = 14, tomTable = 15, tomObject = 16, tomPage = 17, tomHardParagraph = 18, tomCluster = 19, tomInlineObject = 20, tomInlineObjectArg = 21, tomLeafLine = 22, tomLayoutColumn = 23, tomProcessId = 0x40000001, tomMatchWord = 2, tomMatchCase = 4, tomMatchPattern = 8, tomUnknownStory = 0, tomMainTextStory = 1, tomFootnotesStory = 2, tomEndnotesStory = 3, tomCommentsStory = 4, tomTextFrameStory = 5, tomEvenPagesHeaderStory = 6, tomPrimaryHeaderStory = 7, tomEvenPagesFooterStory = 8, tomPrimaryFooterStory = 9, tomFirstPageHeaderStory = 10, tomFirstPageFooterStory = 11, tomScratchStory = 127, tomFindStory = 128, tomReplaceStory = 129, tomStoryInactive = 0, tomStoryActiveDisplay = 1, tomStoryActiveUI = 2, tomStoryActiveDisplayUI = 3, tomNoAnimation = 0, tomLasVegasLights = 1, tomBlinkingBackground = 2, tomSparkleText = 3, tomMarchingBlackAnts = 4, tomMarchingRedAnts = 5, tomShimmer = 6, tomWipeDown = 7, tomWipeRight = 8, tomAnimationMax = 8, tomLowerCase = 0, tomUpperCase = 1, tomTitleCase = 2, tomSentenceCase = 4, tomToggleCase = 5, tomReadOnly = 0x100, tomShareDenyRead = 0x200, tomShareDenyWrite = 0x400, tomPasteFile = 0x1000, tomCreateNew = 0x10, tomCreateAlways = 0x20, tomOpenExisting = 0x30, tomOpenAlways = 0x40, tomTruncateExisting = 0x50, tomRTF = 0x1, tomText = 0x2, tomHTML = 0x3, tomWordDocument = 0x4, tomBold = 0x80000001, tomItalic = 0x80000002, tomUnderline = 0x80000004, tomStrikeout = 0x80000008, tomProtected = 0x80000010, tomLink = 0x80000020, tomSmallCaps = 0x80000040, tomAllCaps = 0x80000080, tomHidden = 0x80000100, tomOutline = 0x80000200, tomShadow = 0x80000400, tomEmboss = 0x80000800, tomImprint = 0x80001000, tomDisabled = 0x80002000, tomRevised = 0x80004000, tomSubscriptCF = 0x80010000, tomSuperscriptCF = 0x80020000, tomFontBound = 0x80100000, tomLinkProtected = 0x80800000, tomInlineObjectStart = 0x81000000, tomExtendedChar = 0x82000000, tomAutoBackColor = 0x84000000, tomMathZoneNoBuildUp = 0x88000000, tomMathZone = 0x90000000, tomMathZoneOrdinary = 0xa0000000, tomAutoTextColor = 0xc0000000, tomMathZoneDisplay = 0x40000, tomParaEffectRTL = 0x1, tomParaEffectKeep = 0x2, tomParaEffectKeepNext = 0x4, tomParaEffectPageBreakBefore = 0x8, tomParaEffectNoLineNumber = 0x10, tomParaEffectNoWidowControl = 0x20, tomParaEffectDoNotHyphen = 0x40, tomParaEffectSideBySide = 0x80, tomParaEffectCollapsed = 0x100, tomParaEffectOutlineLevel = 0x200, tomParaEffectBox = 0x400, tomParaEffectTableRowDelimiter = 0x1000, tomParaEffectTable = 0x4000, tomModWidthPairs = 0x1, tomModWidthSpace = 0x2, tomAutoSpaceAlpha = 0x4, tomAutoSpaceNumeric = 0x8, tomAutoSpaceParens = 0x10, tomEmbeddedFont = 0x20, tomDoublestrike = 0x40, tomOverlapping = 0x80, tomNormalCaret = 0, tomKoreanBlockCaret = 0x1, tomNullCaret = 0x2, tomIncludeInset = 0x1, tomUnicodeBiDi = 0x1, tomMathCFCheck = 0x4, tomUnlink = 0x8, tomUnhide = 0x10, tomCheckTextLimit = 0x20, tomIgnoreCurrentFont = 0, tomMatchCharRep = 0x1, tomMatchFontSignature = 0x2, tomMatchAscii = 0x4, tomGetHeightOnly = 0x8, tomMatchMathFont = 0x10, tomCharset = 0x80000000, tomCharRepFromLcid = 0x40000000, tomAnsi = 0, tomEastEurope = 1, tomCyrillic = 2, tomGreek = 3, tomTurkish = 4, tomHebrew = 5, tomArabic = 6, tomBaltic = 7, tomVietnamese = 8, tomDefaultCharRep = 9, tomSymbol = 10, tomThai = 11, tomShiftJIS = 12, tomGB2312 = 13, tomHangul = 14, tomBIG5 = 15, tomPC437 = 16, tomOEM = 17, tomMac = 18, tomArmenian = 19, tomSyriac = 20, tomThaana = 21, tomDevanagari = 22, tomBengali = 23, tomGurmukhi = 24, tomGujarati = 25, tomOriya = 26, tomTamil = 27, tomTelugu = 28, tomKannada = 29, tomMalayalam = 30, tomSinhala = 31, tomLao = 32, tomTibetan = 33, tomMyanmar = 34, tomGeorgian = 35, tomJamo = 36, tomEthiopic = 37, tomCherokee = 38, tomAboriginal = 39, tomOgham = 40, tomRunic = 41, tomKhmer = 42, tomMongolian = 43, tomBraille = 44, tomYi = 45, tomLimbu = 46, tomTaiLe = 47, tomNewTaiLue = 48, tomSylotiNagri = 49, tomKharoshthi = 50, tomKayahli = 51, tomUsymbol = 52, tomEmoji = 53, tomGlagolitic = 54, tomLisu = 55, tomVai = 56, tomNKo = 57, tomOsmanya = 58, tomPhagsPa = 59, tomGothic = 60, tomDeseret = 61, tomTifinagh = 62, tomCharRepMax = 63, tomRE10Mode = 0x1, tomUseAtFont = 0x2, tomTextFlowMask = 0xc, tomTextFlowES = 0, tomTextFlowSW = 0x4, tomTextFlowWN = 0x8, tomTextFlowNE = 0xc, tomNoIME = 0x80000, tomSelfIME = 0x40000, tomNoUpScroll = 0x10000, tomNoVpScroll = 0x40000, tomNoLink = 0, tomClientLink = 1, tomFriendlyLinkName = 2, tomFriendlyLinkAddress = 3, tomAutoLinkURL = 4, tomAutoLinkEmail = 5, tomAutoLinkPhone = 6, tomAutoLinkPath = 7, tomCompressNone = 0, tomCompressPunctuation = 1, tomCompressPunctuationAndKana = 2, tomCompressMax = 2, tomUnderlinePositionAuto = 0, tomUnderlinePositionBelow = 1, tomUnderlinePositionAbove = 2, tomUnderlinePositionMax = 2, tomFontAlignmentAuto = 0, tomFontAlignmentTop = 1, tomFontAlignmentBaseline = 2, tomFontAlignmentBottom = 3, tomFontAlignmentCenter = 4, tomFontAlignmentMax = 4, tomRubyBelow = 0x80, tomRubyAlignCenter = 0, tomRubyAlign010 = 1, tomRubyAlign121 = 2, tomRubyAlignLeft = 3, tomRubyAlignRight = 4, tomLimitsDefault = 0, tomLimitsUnderOver = 1, tomLimitsSubSup = 2, tomUpperLimitAsSuperScript = 3, tomLimitsOpposite = 4, tomShowLLimPlaceHldr = 8, tomShowULimPlaceHldr = 16, tomDontGrowWithContent = 64, tomGrowWithContent = 128, tomSubSupAlign = 1, tomLimitAlignMask = 3, tomLimitAlignCenter = 0, tomLimitAlignLeft = 1, tomLimitAlignRight = 2, tomShowDegPlaceHldr = 8, tomAlignDefault = 0, tomAlignMatchAscentDescent = 2, tomMathVariant = 0x20, tomStyleDefault = 0, tomStyleScriptScriptCramped = 1, tomStyleScriptScript = 2, tomStyleScriptCramped = 3, tomStyleScript = 4, tomStyleTextCramped = 5, tomStyleText = 6, tomStyleDisplayCramped = 7, tomStyleDisplay = 8, tomMathRelSize = 0x40, tomDecDecSize = 0xfe, tomDecSize = 0xff, tomIncSize, tomIncIncSize, tomGravityUI = 0, tomGravityBack = 1, tomGravityFore = 2, tomGravityIn = 3, tomGravityOut = 4, tomGravityBackward = 0x20000000, tomGravityForward = 0x40000000, tomAdjustCRLF = 1, tomUseCRLF = 2, tomTextize = 4, tomAllowFinalEOP = 8, tomFoldMathAlpha = 16, tomNoHidden = 32, tomIncludeNumbering = 64, tomTranslateTableCell = 128, tomNoMathZoneBrackets = 0x100, tomConvertMathChar = 0x200, tomNoUCGreekItalic = 0x400, tomAllowMathBold = 0x800, tomLanguageTag = 0x1000, tomConvertRTF = 0x2000, tomApplyRtfDocProps = 0x4000, tomPhantomShow = 1, tomPhantomZeroWidth = 2, tomPhantomZeroAscent = 4, tomPhantomZeroDescent = 8, tomPhantomTransparent = 16, tomPhantomASmash, tomPhantomDSmash, tomPhantomHSmash, tomPhantomSmash, tomPhantomHorz, tomPhantomVert, tomBoxHideTop = 1, tomBoxHideBottom = 2, tomBoxHideLeft = 4, tomBoxHideRight = 8, tomBoxStrikeH = 16, tomBoxStrikeV = 32, tomBoxStrikeTLBR = 64, tomBoxStrikeBLTR = 128, tomBoxAlignCenter = 1, tomSpaceMask = 0x1c, tomSpaceDefault = 0, tomSpaceUnary = 4, tomSpaceBinary = 8, tomSpaceRelational = 12, tomSpaceSkip = 16, tomSpaceOrd = 20, tomSpaceDifferential = 24, tomSizeText = 32, tomSizeScript = 64, tomSizeScriptScript = 96, tomNoBreak = 128, tomTransparentForPositioning = 256, tomTransparentForSpacing = 512, tomStretchCharBelow = 0, tomStretchCharAbove = 1, tomStretchBaseBelow = 2, tomStretchBaseAbove = 3, tomMatrixAlignMask = 3, tomMatrixAlignCenter = 0, tomMatrixAlignTopRow = 1, tomMatrixAlignBottomRow = 3, tomShowMatPlaceHldr = 8, tomEqArrayLayoutWidth = 1, tomEqArrayAlignMask = 0xc, tomEqArrayAlignCenter = 0, tomEqArrayAlignTopRow = 4, tomEqArrayAlignBottomRow = 0xc, tomMathManualBreakMask = 0x7f, tomMathBreakLeft = 0x7d, tomMathBreakCenter = 0x7e, tomMathBreakRight = 0x7f, tomMathEqAlign = 0x80, tomMathArgShadingStart = 0x251, tomMathArgShadingEnd = 0x252, tomMathObjShadingStart = 0x253, tomMathObjShadingEnd = 0x254, tomFunctionTypeNone = 0, tomFunctionTypeTakesArg = 1, tomFunctionTypeTakesLim = 2, tomFunctionTypeTakesLim2 = 3, tomFunctionTypeIsLim = 4, tomMathParaAlignDefault = 0, tomMathParaAlignCenterGroup = 1, tomMathParaAlignCenter = 2, tomMathParaAlignLeft = 3, tomMathParaAlignRight = 4, tomMathDispAlignMask = 3, tomMathDispAlignCenterGroup = 0, tomMathDispAlignCenter = 1, tomMathDispAlignLeft = 2, tomMathDispAlignRight = 3, tomMathDispIntUnderOver = 4, tomMathDispFracTeX = 8, tomMathDispNaryGrow = 0x10, tomMathDocEmptyArgMask = 0x60, tomMathDocEmptyArgAuto = 0, tomMathDocEmptyArgAlways = 0x20, tomMathDocEmptyArgNever = 0x40, tomMathDocSbSpOpUnchanged = 0x80, tomMathDocDiffMask = 0x300, tomMathDocDiffDefault = 0, tomMathDocDiffUpright = 0x100, tomMathDocDiffItalic = 0x200, tomMathDocDiffOpenItalic = 0x300, tomMathDispNarySubSup = 0x400, tomMathDispDef = 0x800, tomMathEnableRtl = 0x1000, tomMathBrkBinMask = 0x30000, tomMathBrkBinBefore = 0, tomMathBrkBinAfter = 0x10000, tomMathBrkBinDup = 0x20000, tomMathBrkBinSubMask = 0xc0000, tomMathBrkBinSubMM = 0, tomMathBrkBinSubPM = 0x40000, tomMathBrkBinSubMP = 0x80000, tomSelRange = 0x255, tomHstring = 0x254, tomFontPropTeXStyle = 0x33c, tomFontPropAlign = 0x33d, tomFontStretch = 0x33e, tomFontStyle = 0x33f, tomFontStyleUpright = 0, tomFontStyleOblique = 1, tomFontStyleItalic = 2, tomFontStretchDefault = 0, tomFontStretchUltraCondensed = 1, tomFontStretchExtraCondensed = 2, tomFontStretchCondensed = 3, tomFontStretchSemiCondensed = 4, tomFontStretchNormal = 5, tomFontStretchSemiExpanded = 6, tomFontStretchExpanded = 7, tomFontStretchExtraExpanded = 8, tomFontStretchUltraExpanded = 9, tomFontWeightDefault = 0, tomFontWeightThin = 100, tomFontWeightExtraLight = 200, tomFontWeightLight = 300, tomFontWeightNormal = 400, tomFontWeightRegular = 400, tomFontWeightMedium = 500, tomFontWeightSemiBold = 600, tomFontWeightBold = 700, tomFontWeightExtraBold = 800, tomFontWeightBlack = 900, tomFontWeightHeavy = 900, tomFontWeightExtraBlack = 950, tomParaPropMathAlign = 0x437, tomDocMathBuild = 0x80, tomMathLMargin = 0x81, tomMathRMargin = 0x82, tomMathWrapIndent = 0x83, tomMathWrapRight = 0x84, tomMathPostSpace = 0x86, tomMathPreSpace = 0x85, tomMathInterSpace = 0x87, tomMathIntraSpace = 0x88, tomCanCopy = 0x89, tomCanRedo = 0x8a, tomCanUndo = 0x8b, tomUndoLimit = 0x8c, tomDocAutoLink = 0x8d, tomEllipsisMode = 0x8e, tomEllipsisState = 0x8f, tomEllipsisNone = 0, tomEllipsisEnd = 1, tomEllipsisWord = 3, tomEllipsisPresent = 1, tomVTopCell = 1, tomVLowCell = 2, tomHStartCell = 4, tomHContCell = 8, tomRowUpdate = 1, tomRowApplyDefault = 0, tomCellStructureChangeOnly = 1, tomRowHeightActual = 0x80b } tomConstants;
	[PInvokeData("tom.h", MSDNShortId = "NE:tom.__MIDL___MIDL_itf_tom_0000_0000_0001")]
	[Flags]
	public enum tomConstants : int
	{
		/// <summary>A tomBool value that indicates false.</summary>
		tomFalse = 0,
		/// <summary>A tomBool value that indicates true.</summary>
		tomTrue = -1,
		/// <summary>A tomBool value that indicates a no-input, no-change value that works with long, float, and COLORREF parameters. For strings, tomUndefined (or NINCH) is represented by the null string. For Set operations, using tomUndefined does not change the target property. For Get operations, tomUndefined means that the characters in the range have different values (it gives the grayed check box in property dialog boxes).</summary>
		tomUndefined = -9999999,
		/// <summary>A tomBool value that toggles the state of a property.</summary>
		tomToggle = -9999998,
		/// <summary>Allow the rich edit control to select the appropriate color.</summary>
		tomAutoColor = -9999997,
		/// <summary>Set to the document default format for objects that are attached to a range, or to the basic TOM engine default for objects that are not attached to a range.</summary>
		tomDefault = -9999996,
		/// <summary>Suspend an operation.</summary>
		tomSuspend = -9999995,
		/// <summary>Resume an operation.</summary>
		tomResume = -9999994,
		/// <summary>Apply the current properties to the attached range.</summary>
		tomApplyNow = 0,
		/// <summary>Allow setting property definitions, but don’t apply them to a range yet.</summary>
		tomApplyLater = 1,
		/// <summary>Update the current font with the attached range properties.</summary>
		tomTrackParms = 2,
		/// <summary>Don’t update the current font with the attached range properties.</summary>
		tomCacheParms = 3,
		/// <summary>Apply temporary formatting.</summary>
		tomApplyTmp = 4,
		/// <summary>Do not apply smart fonts.</summary>
		tomDisableSmartFont = 8,
		/// <summary>Do apply smart fonts.</summary>
		tomEnableSmartFont = 9,
		/// <summary>Use points for floating-point measurements.</summary>
		tomUsePoints = 10,
		/// <summary>Use twips for floating-point measurements.</summary>
		tomUseTwips = 11,
		/// <summary>Move backward toward the start of a story.</summary>
		tomBackward = unchecked((int)0xc0000001),
		/// <summary>Move foreward toward the end of a story.</summary>
		tomForward = 0x3fffffff,
		/// <summary>Collapse the selection or range to an insertion point and then move the insertion point.</summary>
		tomMove = 0,
		/// <summary>Extend a selection or range by moving one of the endpoints.</summary>
		tomExtend = 1,
		/// <summary>There is no selection and no insertion point.</summary>
		tomNoSelection = 0,
		/// <summary>The selection insertion point.</summary>
		tomSelectionIP = 1,
		/// <summary>The selection is a single, nondegenerate text range.</summary>
		tomSelectionNormal = 2,
		/// <summary>A frame is selected.</summary>
		tomSelectionFrame = 3,
		/// <summary>One or more table columns is selected.</summary>
		tomSelectionColumn = 4,
		/// <summary>One or more table rows is selected.</summary>
		tomSelectionRow = 5,
		/// <summary>A block is selected.</summary>
		tomSelectionBlock = 6,
		/// <summary>The selection is a picture.</summary>
		tomSelectionInlineShape = 7,
		/// <summary>A shape is selected.</summary>
		tomSelectionShape = 8,
		/// <summary>The starting position of the selection is active.</summary>
		tomSelStartActive = 1,
		/// <summary>For degenerate selections, the ambiguous character position corresponding to both the beginning of a line and the end of the preceding line should have the caret displayed at the end of the preceding line.</summary>
		tomSelAtEOL = 2,
		/// <summary>Insert/overtype mode is set to overtype.</summary>
		tomSelOvertype = 4,
		/// <summary>Selection is active.</summary>
		tomSelActive = 8,
		/// <summary>Typing and pasting replaces the selection.</summary>
		tomSelReplace = 16,
		/// <summary>The end of a text range.</summary>
		tomEnd = 0,
		/// <summary>The start of range.</summary>
		tomStart = 32,
		/// <summary>Collapse to the end position of a range or selection.</summary>
		tomCollapseEnd = 0,
		/// <summary>Collapse to the start position of a range or selection.</summary>
		tomCollapseStart = 1,
		/// <summary>Use client coordinates instead of screen coordinates.</summary>
		tomClientCoord = 256,
		/// <summary>Allow points outside of the client area.</summary>
		tomAllowOffClient = 512,
		/// <summary>Transform coordinates using a world transform (XFORM) supplied by the host application.</summary>
		tomTransform = 1024,
		/// <summary>Get a point inside an inline object argument; for example, inside the numerator of a fraction.</summary>
		tomObjectArg = 2048,
		/// <summary>The end of the specified unit.</summary>
		tomAtEnd = 4096,
		/// <summary>No underlining.</summary>
		tomNone = 0,
		/// <summary>Single underline.</summary>
		tomSingle = 1,
		/// <summary>Underline words only.</summary>
		tomWords = 2,
		/// <summary>Double underline.</summary>
		tomDouble = 3,
		/// <summary>Dotted underline.</summary>
		tomDotted = 4,
		/// <summary>Dash underline.</summary>
		tomDash = 5,
		/// <summary>Dash dot underline.</summary>
		tomDashDot = 6,
		/// <summary>Dash dot dot underline.</summary>
		tomDashDotDot = 7,
		/// <summary>Wave underline.</summary>
		tomWave = 8,
		/// <summary>Thick underline.</summary>
		tomThick = 9,
		/// <summary>Hair underline.</summary>
		tomHair = 10,
		/// <summary>Double wave underline.</summary>
		tomDoubleWave = 11,
		/// <summary>Heavy wave underline.</summary>
		tomHeavyWave = 12,
		/// <summary>Long dash underline.</summary>
		tomLongDash = 13,
		/// <summary>Thick dash underline.</summary>
		tomThickDash = 14,
		/// <summary>Thick dash dot underline.</summary>
		tomThickDashDot = 15,
		/// <summary>Thick dash dot dot underline.</summary>
		tomThickDashDotDot = 16,
		/// <summary>Thick dotted underline.</summary>
		tomThickDotted = 17,
		/// <summary>Thick long dash underline.</summary>
		tomThickLongDash = 18,
		/// <summary>Single space. The line-spacing value is ignored.</summary>
		tomLineSpaceSingle = 0,
		/// <summary>One-and-a-half line spacing. The line-spacing value is ignored.</summary>
		tomLineSpace1pt5 = 1,
		/// <summary>Double line spacing. The line-spacing value is ignored.</summary>
		tomLineSpaceDouble = 2,
		/// <summary>The line-spacing value specifies the spacing from one line to the next. However, if the value is less than single spacing, text is single-spaced.</summary>
		tomLineSpaceAtLeast = 3,
		/// <summary>The line-spacing value specifies the exact spacing from one line to the next, even if the value is less than single spacing.</summary>
		tomLineSpaceExactly = 4,
		/// <summary>The line-spacing value specifies the line spacing, in lines.</summary>
		tomLineSpaceMultiple = 5,
		/// <summary>The line-spacing value specifies the line spacing by percent of line height.</summary>
		tomLineSpacePercent = 6,
		/// <summary>Text aligns with the left margin.</summary>
		tomAlignLeft = 0,
		/// <summary>Text is centered between the margins.</summary>
		tomAlignCenter = 1,
		/// <summary>Text aligns with the right margin.</summary>
		tomAlignRight = 2,
		/// <summary>Text starts at the left margin and, if the line extends beyond the right margin, all the spaces in the line are adjusted to be even.</summary>
		tomAlignJustify = 3,
		/// <summary>The decimal point is set at the tab position. This is useful for aligning a column of decimal numbers.</summary>
		tomAlignDecimal = 3,
		/// <summary>A vertical bar is positioned at the tab position. Text is not affected. Alignment bars on nearby lines at the same position form a continuous vertical line.</summary>
		tomAlignBar = 4,
		/// <summary>Position at a default tab stop.</summary>
		tomDefaultTab = 5,
		/// <summary>Same as tomAlignJustify.</summary>
		tomAlignInterWord = 3,
		/// <summary>Same as tomAlignInterLetter, but uses East Asian metrics.</summary>
		tomAlignNewspaper = 4,
		/// <summary>The first and last characters of each line (except the last line) are aligned to the left and right margins, and lines are filled by adding or subtracting the same amount from each character.</summary>
		tomAlignInterLetter = 5,
		/// <summary>Same as tomAlignInterLetter, but uses East Asian metrics, and scales the spacing by the width of characters.</summary>
		tomAlignScaled = 6,
		/// <summary>Use spaces to fill the spaces taken by a tab character.</summary>
		tomSpaces = 0,
		/// <summary>Use dots to fill the spaces taken by a tab character.</summary>
		tomDots = 1,
		/// <summary>Use dashes to fill the spaces taken by a tab character.</summary>
		tomDashes = 2,
		/// <summary>Use solid lines to fill the spaces taken by a tab character.</summary>
		tomLines = 3,
		/// <summary>Use thick solid lines to fill the spaces taken by a tab character.</summary>
		tomThickLines = 4,
		/// <summary>Use equal signs to fill the spaces taken by a tab character.</summary>
		tomEquals = 5,
		/// <summary>The tab preceding the specified location.</summary>
		tomTabBack = -3,
		/// <summary>The next tab following the specified location.</summary>
		tomTabNext = -2,
		/// <summary>The tab at the specified location.</summary>
		tomTabHere = -1,
		/// <summary>Not a list paragraph.</summary>
		tomListNone = 0,
		/// <summary>List uses bullets (0x2022); other bullets are given by > 32.</summary>
		tomListBullet = 1,
		/// <summary>List is numbered with Arabic numerals (0, 1, 2, ...).</summary>
		tomListNumberAsArabic = 2,
		/// <summary>List is ordered with lowercase letters (a, b, c, ...).</summary>
		tomListNumberAsLCLetter = 3,
		/// <summary>List is ordered with uppercase Arabic letters (A, B, C, ...).</summary>
		tomListNumberAsUCLetter = 4,
		/// <summary>List is ordered with lowercase Roman letters (i, ii, iii, ...).</summary>
		tomListNumberAsLCRoman = 5,
		/// <summary>List is ordered with uppercase Roman letters (I, II, III, ...).</summary>
		tomListNumberAsUCRoman = 6,
		/// <summary>The value returned by ITextPara::GetListStart is treated as the first code in a Unicode sequence.</summary>
		tomListNumberAsSequence = 7,
		/// <summary>List is ordered with Unicode circled numbers</summary>
		tomListNumberedCircle = 8,
		/// <summary>List is ordered with Wingdings black circled digits</summary>
		tomListNumberedBlackCircleWingding = 9,
		/// <summary>List is ordered with Wingdings white circled digits:</summary>
		tomListNumberedWhiteCircleWingding = 10,
		/// <summary>Full-width ASCII (０, １, ２, ３, …).</summary>
		tomListNumberedArabicWide = 11,
		/// <summary>Chinese with 十 only in items 10 through 99 (一, 二, 三, 四…).</summary>
		tomListNumberedChS = 12,
		/// <summary>Chinese with 十 only in items 10 through 19.</summary>
		tomListNumberedChT = 13,
		/// <summary>Chinese with a full-width period, no 十.</summary>
		tomListNumberedJpnChS = 14,
		/// <summary>Chinese with no 十.</summary>
		tomListNumberedJpnKor = 15,
		/// <summary>Arabic alphabetic ( أ ,ب ,ت ,ث ,…).</summary>
		tomListNumberedArabic1 = 16,
		/// <summary>Arabic abjadi ( أ ,ب ,ج ,د ,…).</summary>
		tomListNumberedArabic2 = 17,
		/// <summary>Hebrew alphabet (א, ב, ג, ד, …).</summary>
		tomListNumberedHebrew = 18,
		/// <summary>Thai alphabetic (ก, ข,ค, ง, …).</summary>
		tomListNumberedThaiAlpha = 19,
		/// <summary>Thai numbers (๑, ๒,๓, ๔…).</summary>
		tomListNumberedThaiNum = 20,
		/// <summary>Hindi vowels (अ, आ, इ, ई, …).</summary>
		tomListNumberedHindiAlpha = 21,
		/// <summary>Hindi consonants (क, ख, ग, घ, …).</summary>
		tomListNumberedHindiAlpha1 = 22,
		/// <summary>Hindi numbers (१, २, ३, ४, …).</summary>
		tomListNumberedHindiNum = 23,
		/// <summary>Encloses the number in parentheses, as in: (1).</summary>
		tomListParentheses = 0x10000,
		/// <summary>Follows the number with a period.</summary>
		tomListPeriod = 0x20000,
		/// <summary>Uses the number alone.</summary>
		tomListPlain = 0x30000,
		/// <summary>Uses no numbers.</summary>
		tomListNoNumber = 0x40000,
		/// <summary>Follows the number with a hyphen (-).</summary>
		tomListMinus = 0x80000,
		/// <summary>Suppress the numbering style for list items.</summary>
		tomIgnoreNumberStyle = 0x1000000,
		/// <summary>The normal paragraph style.</summary>
		tomParaStyleNormal = -1,
		/// <summary>The style for level 1 paragraph headings.</summary>
		tomParaStyleHeading1 = -2,
		/// <summary>The style for level 2 paragraph headings.</summary>
		tomParaStyleHeading2 = -3,
		/// <summary>The style for level 3 paragraph headings.</summary>
		tomParaStyleHeading3 = -4,
		/// <summary>The style for level 4 paragraph headings.</summary>
		tomParaStyleHeading4 = -5,
		/// <summary>The style for level 5 paragraph headings.</summary>
		tomParaStyleHeading5 = -6,
		/// <summary>The style for level 6 paragraph headings.</summary>
		tomParaStyleHeading6 = -7,
		/// <summary>The style for level 7 paragraph headings.</summary>
		tomParaStyleHeading7 = -8,
		/// <summary>The style for level 8 paragraph headings.</summary>
		tomParaStyleHeading8 = -9,
		/// <summary>The style for level 9 paragraph headings.</summary>
		tomParaStyleHeading9 = -10,
		/// <summary>The unit is a single character.</summary>
		tomCharacter = 1,
		/// <summary>The unit is a word.</summary>
		tomWord = 2,
		/// <summary>The unit is a sentence.</summary>
		tomSentence = 3,
		/// <summary>The unit is a paragraph.</summary>
		tomParagraph = 4,
		/// <summary>The unit is a line.</summary>
		tomLine = 5,
		/// <summary>The unit is a story; that is, a contiguous range of text that represent a part of a document, such as the main text of the document, headers and footers, footnotes, annotations, and so on.</summary>
		tomStory = 6,
		/// <summary>The unit is a screenful.</summary>
		tomScreen = 7,
		/// <summary>The unit is a section.</summary>
		tomSection = 8,
		/// <summary>The unit is a table column.</summary>
		tomTableColumn = 9,
		/// <summary>The unit is a text column.</summary>
		tomColumn = 9,
		/// <summary>The unit is a table row</summary>
		tomRow = 0xc,
		/// <summary>The unit is a window.</summary>
		tomWindow = 11,
		/// <summary>The unit is a spreadsheet cell.</summary>
		tomCell = 12,
		/// <summary>The unit is a run of constant character formatting.</summary>
		tomCharFormat = 13,
		/// <summary>The unit is a run of constant paragraph formatting.</summary>
		tomParaFormat = 14,
		/// <summary>The unit is a table.</summary>
		tomTable = 15,
		/// <summary>The unit is an embedded object.</summary>
		tomObject = 16,
		/// <summary>The unit is a page.</summary>
		tomPage = 17,
		/// <summary>The unit is a hard paragraph.</summary>
		tomHardParagraph = 18,
		/// <summary>The unit is a cluster of characters.</summary>
		tomCluster = 19,
		/// <summary>The unit is an inline object.</summary>
		tomInlineObject = 20,
		/// <summary>The unit is an inline object argument.</summary>
		tomInlineObjectArg = 21,
		/// <summary>The unit is a leaf-level line.</summary>
		tomLeafLine = 22,
		/// <summary>A layout column.</summary>
		tomLayoutColumn = 23,
		/// <summary>The identifier of the current process.</summary>
		tomProcessId = 0x40000001,
		/// <summary>Match on whole words when doing a text search.</summary>
		tomMatchWord = 2,
		/// <summary>A case-sensitive a text search.</summary>
		tomMatchCase = 4,
		/// <summary>Match regular expressions when doing a text search.</summary>
		tomMatchPattern = 8,
		/// <summary>No special type.</summary>
		tomUnknownStory = 0,
		/// <summary>The main story always exists for a rich edit control.</summary>
		tomMainTextStory = 1,
		/// <summary>The story used for footnotes.</summary>
		tomFootnotesStory = 2,
		/// <summary>The story used for endnotes.</summary>
		tomEndnotesStory = 3,
		/// <summary>The story used for comments.</summary>
		tomCommentsStory = 4,
		/// <summary>The story used for a text box.</summary>
		tomTextFrameStory = 5,
		/// <summary>The story containing headers for even pages.</summary>
		tomEvenPagesHeaderStory = 6,
		/// <summary>The story containing headers for odd pages.</summary>
		tomPrimaryHeaderStory = 7,
		/// <summary>The story containing footers for even pages.</summary>
		tomEvenPagesFooterStory = 8,
		/// <summary>The story containing footers for odd pages.</summary>
		tomPrimaryFooterStory = 9,
		/// <summary>The story containing the header for the first page.</summary>
		tomFirstPageHeaderStory = 10,
		/// <summary>The story containing the footer for the first page.</summary>
		tomFirstPageFooterStory = 11,
		/// <summary>The scratch story.</summary>
		tomScratchStory = 127,
		/// <summary>The story used for a Find dialog.</summary>
		tomFindStory = 128,
		/// <summary>The story used for a Replace dialog.</summary>
		tomReplaceStory = 129,
		/// <summary>Story is inactive.</summary>
		tomStoryInactive = 0,
		/// <summary>Story has display, but no UI.</summary>
		tomStoryActiveDisplay = 1,
		/// <summary>Story is UI active; that is, it receives keyboard and mouse input.</summary>
		tomStoryActiveUI = 2,
		/// <summary>Story has display and UI activity.</summary>
		tomStoryActiveDisplayUI = 3,
		/// <summary>Do not apply text animation.</summary>
		tomNoAnimation = 0,
		/// <summary>Text is bordered by marquee lights that blink between the colors red, yellow, green, and blue.</summary>
		tomLasVegasLights = 1,
		/// <summary>Text has a black background that blinks on and off.</summary>
		tomBlinkingBackground = 2,
		/// <summary>Text is overlaid with multicolored stars that blink on and off at regular intervals</summary>
		tomSparkleText = 3,
		/// <summary>Text is surrounded by a black dashed-line border. The border is animated so that the individual dashes appear to move clockwise around the text.</summary>
		tomMarchingBlackAnts = 4,
		/// <summary>Text is surrounded by a red dashed-line border that is animated to appear to move clockwise around the text.</summary>
		tomMarchingRedAnts = 5,
		/// <summary>Text is alternately blurred and unblurred at regular intervals, to give the appearance of shimmering.</summary>
		tomShimmer = 6,
		/// <summary>Text appears gradually from the top down.</summary>
		tomWipeDown = 7,
		/// <summary>Text appears gradually from the bottom up.</summary>
		tomWipeRight = 8,
		/// <summary>Defines the maximum animation flag value.</summary>
		tomAnimationMax = 8,
		/// <summary>Set text to lowercase.</summary>
		tomLowerCase = 0,
		/// <summary>Set text to uppercase.</summary>
		tomUpperCase = 1,
		/// <summary>Capitalize the first letter of each word.</summary>
		tomTitleCase = 2,
		/// <summary>Capitalize the first letter of each sentence.</summary>
		tomSentenceCase = 4,
		/// <summary>Toggle the case of each letter.</summary>
		tomToggleCase = 5,
		/// <summary>Read only.</summary>
		tomReadOnly = 0x100,
		/// <summary>Other programs cannot read.</summary>
		tomShareDenyRead = 0x200,
		/// <summary>Other programs cannot write.</summary>
		tomShareDenyWrite = 0x400,
		/// <summary>Replace the selection with a file.</summary>
		tomPasteFile = 0x1000,
		/// <summary>Create a new file. Fail if the file already exists.</summary>
		tomCreateNew = 0x10,
		/// <summary>Create a new file. Destroy the existing file if it exists.</summary>
		tomCreateAlways = 0x20,
		/// <summary>Open an existing file. Fail if the file does not exist.</summary>
		tomOpenExisting = 0x30,
		/// <summary>Open an existing file. Create a new file if the file does not exist.</summary>
		tomOpenAlways = 0x40,
		/// <summary>Open an existing file, but truncate it to zero length.</summary>
		tomTruncateExisting = 0x50,
		/// <summary>Open as RTF.</summary>
		tomRTF = 0x1,
		/// <summary>Open as text ANSI or Unicode.</summary>
		tomText = 0x2,
		/// <summary>Open as HTML.</summary>
		tomHTML = 0x3,
		/// <summary>Open as Word document.</summary>
		tomWordDocument = 0x4,
		/// <summary>Boldface.</summary>
		tomBold = unchecked((int)0x80000001),
		/// <summary>Italic.</summary>
		tomItalic = unchecked((int)0x80000002),
		/// <summary>Underline.</summary>
		tomUnderline = unchecked((int)0x80000004),
		/// <summary>Strikeout.</summary>
		tomStrikeout = unchecked((int)0x80000008),
		/// <summary>Protected.</summary>
		tomProtected = unchecked((int)0x80000010),
		/// <summary>Hyperlink.</summary>
		tomLink = unchecked((int)0x80000020),
		/// <summary>Small caps.</summary>
		tomSmallCaps = unchecked((int)0x80000040),
		/// <summary>All caps.</summary>
		tomAllCaps = unchecked((int)0x80000080),
		/// <summary>Hidden.</summary>
		tomHidden = unchecked((int)0x80000100),
		/// <summary>Outline.</summary>
		tomOutline = unchecked((int)0x80000200),
		/// <summary>Shadow.</summary>
		tomShadow = unchecked((int)0x80000400),
		/// <summary>Emboss.</summary>
		tomEmboss = unchecked((int)0x80000800),
		/// <summary>Imprint.</summary>
		tomImprint = unchecked((int)0x80001000),
		/// <summary>Disabled.</summary>
		tomDisabled = unchecked((int)0x80002000),
		/// <summary>Revised.</summary>
		tomRevised = unchecked((int)0x80004000),
		/// <summary>Subscript character format.</summary>
		tomSubscriptCF = unchecked((int)0x80010000),
		/// <summary>Superscript character format.</summary>
		tomSuperscriptCF = unchecked((int)0x80020000),
		/// <summary>Font bound (uses font binding).</summary>
		tomFontBound = unchecked((int)0x80100000),
		/// <summary>The link is protected (friendly name link).</summary>
		tomLinkProtected = unchecked((int)0x80800000),
		/// <summary>The start delimiter of an inline object.</summary>
		tomInlineObjectStart = unchecked((int)0x81000000),
		/// <summary>The characters are less common members of a script. A font that supports a script should check if it has glyphs for such characters.</summary>
		tomExtendedChar = unchecked((int)0x82000000),
		/// <summary>Use system back color.</summary>
		tomAutoBackColor = unchecked((int)0x84000000),
		/// <summary>Don't build up operator.</summary>
		tomMathZoneNoBuildUp = unchecked((int)0x88000000),
		/// <summary>Math zone.</summary>
		tomMathZone = unchecked((int)0x90000000),
		/// <summary>Math zone ordinary text.</summary>
		tomMathZoneOrdinary = unchecked((int)0xa0000000),
		/// <summary>Use system text color.</summary>
		tomAutoTextColor = unchecked((int)0xc0000000),
		/// <summary>Display math zone.</summary>
		tomMathZoneDisplay = 0x40000,
		/// <summary>Right-to-left paragraph</summary>
		tomParaEffectRTL = 0x1,
		/// <summary>Keep the paragraph together.</summary>
		tomParaEffectKeep = 0x2,
		/// <summary>Keep with next the paragraph.</summary>
		tomParaEffectKeepNext = 0x4,
		/// <summary>Put a page break before this paragraph.</summary>
		tomParaEffectPageBreakBefore = 0x8,
		/// <summary>No line number for this paragraph.</summary>
		tomParaEffectNoLineNumber = 0x10,
		/// <summary>No widow control.</summary>
		tomParaEffectNoWidowControl = 0x20,
		/// <summary>Don't hyphenate this paragraph.</summary>
		tomParaEffectDoNotHyphen = 0x40,
		/// <summary>Side by side.</summary>
		tomParaEffectSideBySide = 0x80,
		/// <summary>Heading contents are collapsed (in outline view).</summary>
		tomParaEffectCollapsed = 0x100,
		/// <summary>Outline view nested level.</summary>
		tomParaEffectOutlineLevel = 0x200,
		/// <summary>Paragraph has boxed effect (is not displayed).</summary>
		tomParaEffectBox = 0x400,
		/// <summary>At or inside table delimiter.</summary>
		tomParaEffectTableRowDelimiter = 0x1000,
		/// <summary>Inside or at the start of a table.</summary>
		tomParaEffectTable = 0x4000,
		/// <summary>Use East Asian character-pair-width modification.</summary>
		tomModWidthPairs = 0x1,
		/// <summary>Use East Asian space-width modification.</summary>
		tomModWidthSpace = 0x2,
		/// <summary>Use East Asian auto spacing between alphabetics.</summary>
		tomAutoSpaceAlpha = 0x4,
		/// <summary>Use East Asian auto spacing for digits.</summary>
		tomAutoSpaceNumeric = 0x8,
		/// <summary>Use East Asian automatic spacing for parentheses or brackets.</summary>
		tomAutoSpaceParens = 0x10,
		/// <summary>Embedded font (CLIP_EMBEDDED).</summary>
		tomEmbeddedFont = 0x20,
		/// <summary>Double strikeout.</summary>
		tomDoublestrike = 0x40,
		/// <summary>Run has overlapping text.</summary>
		tomOverlapping = 0x80,
		/// <summary>Normal caret.</summary>
		tomNormalCaret = 0,
		/// <summary>The Korean block caret.</summary>
		tomKoreanBlockCaret = 0x1,
		/// <summary>NULL caret (caret suppressed).</summary>
		tomNullCaret = 0x2,
		/// <summary>Add left/top insets to the client rectangle, and subtract right/bottom insets from the client rectangle.</summary>
		tomIncludeInset = 0x1,
		/// <summary>Use the Unicode bidirectional (bidi) algorithm.</summary>
		tomUnicodeBiDi = 0x1,
		/// <summary>Check math-zone character formatting.</summary>
		tomMathCFCheck = 0x4,
		/// <summary>Don't include text as part of a hyperlink.</summary>
		tomUnlink = 0x8,
		/// <summary>Don't insert as hidden text.</summary>
		tomUnhide = 0x10,
		/// <summary>Obey the current text limit instead of increasing the text to fit.</summary>
		tomCheckTextLimit = 0x20,
		/// <summary>Ignore the font that is active at a particular character position.</summary>
		tomIgnoreCurrentFont = 0,
		/// <summary>Match the current character repertoire.</summary>
		tomMatchCharRep = 0x1,
		/// <summary>Match the current font signature.</summary>
		tomMatchFontSignature = 0x2,
		/// <summary>Use the current font if its character repertoire is tomAnsi.</summary>
		tomMatchAscii = 0x4,
		/// <summary>Gets the height.</summary>
		tomGetHeightOnly = 0x8,
		/// <summary>Match a math font.</summary>
		tomMatchMathFont = 0x10,
		/// <summary>Set the character repertoire based on the specified character set.</summary>
		tomCharset = unchecked((int)0x80000000),
		/// <summary>Set the character repertoire based on the specified LCID.</summary>
		tomCharRepFromLcid = 0x40000000,
		/// <summary>Latin 1</summary>
		tomAnsi = 0,
		/// <summary>From Latin 1 and 2</summary>
		tomEastEurope = 1,
		/// <summary>Cyrillic</summary>
		tomCyrillic = 2,
		/// <summary>Greek</summary>
		tomGreek = 3,
		/// <summary>Turkish (Latin 1 + dotless i, ...)</summary>
		tomTurkish = 4,
		/// <summary>Hebrew</summary>
		tomHebrew = 5,
		/// <summary>Arabic</summary>
		tomArabic = 6,
		/// <summary>From Latin 1 and 2</summary>
		tomBaltic = 7,
		/// <summary>Latin 1 with some combining marks</summary>
		tomVietnamese = 8,
		/// <summary>Default character repertoire</summary>
		tomDefaultCharRep = 9,
		/// <summary>Symbol character set (not Unicode)</summary>
		tomSymbol = 10,
		/// <summary>Thai</summary>
		tomThai = 11,
		/// <summary>Japanese</summary>
		tomShiftJIS = 12,
		/// <summary>Simplified Chinese</summary>
		tomGB2312 = 13,
		/// <summary>Hangul</summary>
		tomHangul = 14,
		/// <summary>Traditional Chinese</summary>
		tomBIG5 = 15,
		/// <summary>PC437 character set (DOS)</summary>
		tomPC437 = 16,
		/// <summary>OEM character set (original PC)</summary>
		tomOEM = 17,
		/// <summary>Main Macintosh character repertoire</summary>
		tomMac = 18,
		/// <summary>Armenian</summary>
		tomArmenian = 19,
		/// <summary>Syriac</summary>
		tomSyriac = 20,
		/// <summary>Thaana</summary>
		tomThaana = 21,
		/// <summary>Devanagari</summary>
		tomDevanagari = 22,
		/// <summary>Bangla (formerly Bengali)</summary>
		tomBengali = 23,
		/// <summary>Gurmukhi</summary>
		tomGurmukhi = 24,
		/// <summary>Gujarati</summary>
		tomGujarati = 25,
		/// <summary>Odia (formerly Oriya)</summary>
		tomOriya = 26,
		/// <summary>Tamil</summary>
		tomTamil = 27,
		/// <summary>Telugu</summary>
		tomTelugu = 28,
		/// <summary>Kannada</summary>
		tomKannada = 29,
		/// <summary>Malayalam</summary>
		tomMalayalam = 30,
		/// <summary>Sinhala</summary>
		tomSinhala = 31,
		/// <summary>Lao</summary>
		tomLao = 32,
		/// <summary>Tibetan</summary>
		tomTibetan = 33,
		/// <summary>Myanmar</summary>
		tomMyanmar = 34,
		/// <summary>Georgian</summary>
		tomGeorgian = 35,
		/// <summary>Jamo</summary>
		tomJamo = 36,
		/// <summary>Ethiopic</summary>
		tomEthiopic = 37,
		/// <summary>Cherokee</summary>
		tomCherokee = 38,
		/// <summary>Aboriginal</summary>
		tomAboriginal = 39,
		/// <summary>Ogham</summary>
		tomOgham = 40,
		/// <summary>Runic</summary>
		tomRunic = 41,
		/// <summary>Khmer</summary>
		tomKhmer = 42,
		/// <summary>Mongolian</summary>
		tomMongolian = 43,
		/// <summary>Braille</summary>
		tomBraille = 44,
		/// <summary>Yi</summary>
		tomYi = 45,
		/// <summary>Limbu</summary>
		tomLimbu = 46,
		/// <summary>TaiLe</summary>
		tomTaiLe = 47,
		/// <summary>TaiLue</summary>
		tomNewTaiLue = 48,
		/// <summary>Syloti Nagri</summary>
		tomSylotiNagri = 49,
		/// <summary>Kharoshthi</summary>
		tomKharoshthi = 50,
		/// <summary>Kayah Li</summary>
		tomKayahli = 51,
		/// <summary>Unicode symbol</summary>
		tomUsymbol = 52,
		/// <summary>Emoji</summary>
		tomEmoji = 53,
		/// <summary>Glagolitic</summary>
		tomGlagolitic = 54,
		/// <summary>Lisu</summary>
		tomLisu = 55,
		/// <summary>Vai</summary>
		tomVai = 56,
		/// <summary>N'Ko</summary>
		tomNKo = 57,
		/// <summary>Osmanya</summary>
		tomOsmanya = 58,
		/// <summary>Phags-pa</summary>
		tomPhagsPa = 59,
		/// <summary>Gothic</summary>
		tomGothic = 60,
		/// <summary>Deseret</summary>
		tomDeseret = 61,
		/// <summary>Tifinagh</summary>
		tomTifinagh = 62,
		/// <summary>The maximum character repertoire flag value.</summary>
		tomCharRepMax = 63,
		/// <summary>Use Microsoft Rich Edit 1.0 mode.</summary>
		tomRE10Mode = 0x1,
		/// <summary>Use a font with a name that starts with @, for CJK vertical text. When rendered vertically, the characters in such a font are rotated 90 degrees so that they look upright instead of sideways.</summary>
		tomUseAtFont = 0x2,
		/// <summary>Mask for the following four text orientations.</summary>
		tomTextFlowMask = 0xc,
		/// <summary>Ordinary left-to-right horizontal text.</summary>
		tomTextFlowES = 0,
		/// <summary>Ordinary East Asian vertical text.</summary>
		tomTextFlowSW = 0x4,
		/// <summary>Alternative orientation.</summary>
		tomTextFlowWN = 0x8,
		/// <summary>Alternative orientation.</summary>
		tomTextFlowNE = 0xc,
		/// <summary>Disables the IME operation (see ES_NOIME).</summary>
		tomNoIME = 0x80000,
		/// <summary>Directs the rich edit control to allow the application to handle all IME operations (see ES_SELFIME).</summary>
		tomSelfIME = 0x40000,
		/// <summary>Horizontal scrolling is disabled.</summary>
		tomNoUpScroll = 0x10000,
		/// <summary>Vertical scrolling is disabled.</summary>
		tomNoVpScroll = 0x40000,
		/// <summary>Not a link.</summary>
		tomNoLink = 0,
		/// <summary>The URL only; that is, no friendly name.</summary>
		tomClientLink = 1,
		/// <summary>The name of friendly name link.</summary>
		tomFriendlyLinkName = 2,
		/// <summary>The URL of a friendly name link.</summary>
		tomFriendlyLinkAddress = 3,
		/// <summary>The URL of an automatic link.</summary>
		tomAutoLinkURL = 4,
		/// <summary>An automatic link to an email address.</summary>
		tomAutoLinkEmail = 5,
		/// <summary>An automatic link to a phone number.</summary>
		tomAutoLinkPhone = 6,
		/// <summary>An automatic link to a storage location.</summary>
		tomAutoLinkPath = 7,
		/// <summary>No compression.</summary>
		tomCompressNone = 0,
		/// <summary>Compress punctuation.</summary>
		tomCompressPunctuation = 1,
		/// <summary>Compress punctuation and kana.</summary>
		tomCompressPunctuationAndKana = 2,
		/// <summary>The maximum compression flag value.</summary>
		tomCompressMax = 2,
		/// <summary>Automatically set the underline position.</summary>
		tomUnderlinePositionAuto = 0,
		/// <summary>Render underline below text.</summary>
		tomUnderlinePositionBelow = 1,
		/// <summary>Render underline above text.</summary>
		tomUnderlinePositionAbove = 2,
		/// <summary>The maximum underline position flag value.</summary>
		tomUnderlinePositionMax = 2,
		/// <summary>For horizontal layout, align CJK characters on the baseline. For vertical layout, center align CJK characters.</summary>
		tomFontAlignmentAuto = 0,
		/// <summary>For horizontal layout, top align CJK characters. For vertical layout, right align CJK characters.</summary>
		tomFontAlignmentTop = 1,
		/// <summary>For horizontal or vertical layout, align CJK characters on the baseline.</summary>
		tomFontAlignmentBaseline = 2,
		/// <summary>For horizontal layout, bottom align CJK characters. For vertical layout, left align CJK characters.</summary>
		tomFontAlignmentBottom = 3,
		/// <summary>For horizontal layout, center CJK characters vertically. For vertical layout, center align CJK characters horizontally.</summary>
		tomFontAlignmentCenter = 4,
		/// <summary>The maximum font alignment flag value.</summary>
		tomFontAlignmentMax = 4,
		/// <summary/>
		tomRubyBelow = 0x80,
		/// <summary/>
		tomRubyAlignCenter = 0,
		/// <summary/>
		tomRubyAlign010 = 1,
		/// <summary/>
		tomRubyAlign121 = 2,
		/// <summary/>
		tomRubyAlignLeft = 3,
		/// <summary/>
		tomRubyAlignRight = 4,
		/// <summary>Limit locations use document default.</summary>
		tomLimitsDefault = 0,
		/// <summary>Limits are placed under and over the operator.</summary>
		tomLimitsUnderOver = 1,
		/// <summary>Limits are operator subscript and superscript.</summary>
		tomLimitsSubSup = 2,
		/// <summary>The upper limit is a superscript.</summary>
		tomUpperLimitAsSuperScript = 3,
		/// <summary>Switch between tomLimitsSubSup and tomLimitsUnderOver.</summary>
		tomLimitsOpposite = 4,
		/// <summary>Show empty lower limit placeholder.</summary>
		tomShowLLimPlaceHldr = 8,
		/// <summary>Show empty upper limit placeholder.</summary>
		tomShowULimPlaceHldr = 16,
		/// <summary>Don't grow the n-ary operator with the argument.</summary>
		tomDontGrowWithContent = 64,
		/// <summary>Grow the n-ary operator with the argument.</summary>
		tomGrowWithContent = 128,
		/// <summary>Align subscript under superscript.</summary>
		tomSubSupAlign = 1,
		/// <summary>Mask for tomLimitAlignCenter, tomLimitAlignLeft, and tomLimitAlignRight.</summary>
		tomLimitAlignMask = 3,
		/// <summary>Center limit under base.</summary>
		tomLimitAlignCenter = 0,
		/// <summary>Align left ends of limit and base.</summary>
		tomLimitAlignLeft = 1,
		/// <summary>Align right ends of limit and base.</summary>
		tomLimitAlignRight = 2,
		/// <summary>Show empty radical degree placeholder.</summary>
		tomShowDegPlaceHldr = 8,
		/// <summary>Center brackets at baseline.</summary>
		tomAlignDefault = 0,
		/// <summary>Use brackets that match the argument ascent and descent.</summary>
		tomAlignMatchAscentDescent = 2,
		/// <summary>Bits 7, 6 can have TeX variant enumeration values:</summary>
		tomMathVariant = 0x20,
		/// <summary>The math handler determines the style.</summary>
		tomStyleDefault = 0,
		/// <summary>The 2nd and higher level subscript superscript size, cramped.</summary>
		tomStyleScriptScriptCramped = 1,
		/// <summary>The 2nd and higher level subscript superscript size.</summary>
		tomStyleScriptScript = 2,
		/// <summary>The 1st level subscript superscript size, cramped.</summary>
		tomStyleScriptCramped = 3,
		/// <summary>The 1st level subscript superscript size.</summary>
		tomStyleScript = 4,
		/// <summary>Text size cramped, for example, inside a square root.</summary>
		tomStyleTextCramped = 5,
		/// <summary>The standard inline text size.</summary>
		tomStyleText = 6,
		/// <summary>Display style cramped.</summary>
		tomStyleDisplayCramped = 7,
		/// <summary>Display style.</summary>
		tomStyleDisplay = 8,
		/// <summary>Indicates one of these is active: tomDecDecSize, tomDecSize, tomIncSize, tomIncIncSize. Note that the maximum size is tomStyleText size, and the minimum size is tomStyleScriptScript size.</summary>
		tomMathRelSize = 0x40,
		/// <summary>Two sizes smaller than the default.</summary>
		tomDecDecSize = 0xfe,
		/// <summary>One size smaller than the default.</summary>
		tomDecSize = 0xff,
		/// <summary>One size bigger than the default.</summary>
		tomIncSize = 1 | tomMathRelSize,
		/// <summary>Two sizes bigger than the default.</summary>
		tomIncIncSize = 2 | tomMathRelSize,
		/// <summary>Use selection user interface rules.</summary>
		tomGravityUI = 0,
		/// <summary>Both ends have backward gravity.</summary>
		tomGravityBack = 1,
		/// <summary>Both ends have forward gravity.</summary>
		tomGravityFore = 2,
		/// <summary>Inward gravity; that is, the start is forward, and the end is backward.</summary>
		tomGravityIn = 3,
		/// <summary>Outward gravity; that is, the start is backward, and the end is forward.</summary>
		tomGravityOut = 4,
		/// <summary/>
		tomGravityBackward = 0x20000000,
		/// <summary/>
		tomGravityForward = 0x40000000,
		/// <summary>Adjust CR/LFs at the start.</summary>
		tomAdjustCRLF = 1,
		/// <summary>Use CR/LF in place of a carriage return or a line feed.</summary>
		tomUseCRLF = 2,
		/// <summary>Copy up to 0xFFFC (OLE object).</summary>
		tomTextize = 4,
		/// <summary>Allow a final end-of-paragraph (EOP) marker.</summary>
		tomAllowFinalEOP = 8,
		/// <summary>Fold math alphanumerics to ASCII/Greek.</summary>
		tomFoldMathAlpha = 16,
		/// <summary>Don't include hidden text.</summary>
		tomNoHidden = 32,
		/// <summary>Include list numbers.</summary>
		tomIncludeNumbering = 64,
		/// <summary>Replace table row delimiter characters with spaces.</summary>
		tomTranslateTableCell = 128,
		/// <summary>Don't include math zone brackets.</summary>
		tomNoMathZoneBrackets = 0x100,
		/// <summary>Convert to or from math italic and/or math bold according to the status of italic and bold retrieved by the ITextFont2::GetEffects method.</summary>
		tomConvertMathChar = 0x200,
		/// <summary>Don’t use math italics for upper-case Greek letters. This value is used with tomConvertMathChar.</summary>
		tomNoUCGreekItalic = 0x400,
		/// <summary>Allow math bold. This value is used with tomConvertMathChar.</summary>
		tomAllowMathBold = 0x800,
		/// <summary>Get the BCP-47 language tag for this range.</summary>
		tomLanguageTag = 0x1000,
		/// <summary>Get text in RTF.</summary>
		tomConvertRTF = 0x2000,
		/// <summary>Apply RTF document default properties.</summary>
		tomApplyRtfDocProps = 0x4000,
		/// <summary>Display the phantom object's argument.</summary>
		tomPhantomShow = 1,
		/// <summary>The phantom object has zero width.</summary>
		tomPhantomZeroWidth = 2,
		/// <summary>The phantom object has zero ascent.</summary>
		tomPhantomZeroAscent = 4,
		/// <summary>The phantom object has zero descent.</summary>
		tomPhantomZeroDescent = 8,
		/// <summary>Space the phantom object as if only the argument is present.</summary>
		tomPhantomTransparent = 16,
		/// <summary>Ascent smash.</summary>
		tomPhantomASmash = tomPhantomShow | tomPhantomZeroAscent,
		/// <summary>Descent smash.</summary>
		tomPhantomDSmash = tomPhantomShow | tomPhantomZeroDescent,
		/// <summary>Horizontal smash.</summary>
		tomPhantomHSmash = tomPhantomShow | tomPhantomZeroWidth,
		/// <summary>Full smash.</summary>
		tomPhantomSmash = tomPhantomShow | tomPhantomZeroAscent | tomPhantomZeroDescent,
		/// <summary>Horizontal phantom.</summary>
		tomPhantomHorz = tomPhantomZeroAscent | tomPhantomZeroDescent,
		/// <summary>Vertical phantom.</summary>
		tomPhantomVert = tomPhantomZeroWidth,
		/// <summary>Hide top border.</summary>
		tomBoxHideTop = 1,
		/// <summary>Hide bottom border.</summary>
		tomBoxHideBottom = 2,
		/// <summary>Hide left border.</summary>
		tomBoxHideLeft = 4,
		/// <summary>Hide right border.</summary>
		tomBoxHideRight = 8,
		/// <summary>Display horizontal strikethrough.</summary>
		tomBoxStrikeH = 16,
		/// <summary>Display vertical strikethrough.</summary>
		tomBoxStrikeV = 32,
		/// <summary>Display diagonal strikethrough from the top left to the lower right.</summary>
		tomBoxStrikeTLBR = 64,
		/// <summary>Display diagonal strikethrough from the lower left to the top right.</summary>
		tomBoxStrikeBLTR = 128,
		/// <summary>Vertically align with center on baseline.</summary>
		tomBoxAlignCenter = 1,
		/// <summary>Mask for tomSpaceDefault, tomSpaceUnary, tomSpaceBinary, tomSpaceRelational, tomSpaceSkip, tomSpaceOrd, and tomSpaceDifferential.</summary>
		tomSpaceMask = 0x1c,
		/// <summary>Default spacing</summary>
		tomSpaceDefault = 0,
		/// <summary>Space the object as if it were a unary operator.</summary>
		tomSpaceUnary = 4,
		/// <summary>Space the object as if it were a binary operator.</summary>
		tomSpaceBinary = 8,
		/// <summary>Space the object as if it were a relational operator.</summary>
		tomSpaceRelational = 12,
		/// <summary>Space the object as if it were a unary operator.</summary>
		tomSpaceSkip = 16,
		/// <summary>Space the object as if it were an ordinal operator.</summary>
		tomSpaceOrd = 20,
		/// <summary>Space the object as if it were a differential operator.</summary>
		tomSpaceDifferential = 24,
		/// <summary>Treat as text size.</summary>
		tomSizeText = 32,
		/// <summary>Treat as script size (approximately 73% of text size).</summary>
		tomSizeScript = 64,
		/// <summary>Treat as subscript size (approximately 60% of text size).</summary>
		tomSizeScriptScript = 96,
		/// <summary>Do not break arguments across a line.</summary>
		tomNoBreak = 128,
		/// <summary>Position as if only the argument appears.</summary>
		tomTransparentForPositioning = 256,
		/// <summary>Space according to argument properties.</summary>
		tomTransparentForSpacing = 512,
		/// <summary>Stretch character below base.</summary>
		tomStretchCharBelow = 0,
		/// <summary>Stretch character above base.</summary>
		tomStretchCharAbove = 1,
		/// <summary>Stretch base below character.</summary>
		tomStretchBaseBelow = 2,
		/// <summary>Stretch base above character.</summary>
		tomStretchBaseAbove = 3,
		/// <summary>Mask for tomMatrixAlignCenter, tomMatrixAlignTopRow, and tomMatrixAlignBottomRow.</summary>
		tomMatrixAlignMask = 3,
		/// <summary>Align the matrix center on baseline.</summary>
		tomMatrixAlignCenter = 0,
		/// <summary>Align the matrix top row on the baseline.</summary>
		tomMatrixAlignTopRow = 1,
		/// <summary>Align the matrix bottom row on the baseline.</summary>
		tomMatrixAlignBottomRow = 3,
		/// <summary>Show empty element placeholder (a dotted box).</summary>
		tomShowMatPlaceHldr = 8,
		/// <summary>Expand the right size to the layout width (for equation number)</summary>
		tomEqArrayLayoutWidth = 1,
		/// <summary>Mask for tomEqArrayAlignCenter, tomEqArrayAlignTopRow, and tomEqArrayBottomRow.</summary>
		tomEqArrayAlignMask = 0xc,
		/// <summary>Align the center of the equation array on the baseline.</summary>
		tomEqArrayAlignCenter = 0,
		/// <summary>Align the top row of the equation on the baseline.</summary>
		tomEqArrayAlignTopRow = 4,
		/// <summary>Align the bottom row of the equation on the baseline.</summary>
		tomEqArrayAlignBottomRow = 0xc,
		/// <summary>Mask for tomMathBreakLeft, tomMathBreakCenter, and tomMathBreakRight.</summary>
		tomMathManualBreakMask = 0x7f,
		/// <summary>Align text following a manual break to the left.</summary>
		tomMathBreakLeft = 0x7d,
		/// <summary>Center text following a manual break.</summary>
		tomMathBreakCenter = 0x7e,
		/// <summary>Align text following a manual break to the right.</summary>
		tomMathBreakRight = 0x7f,
		/// <summary>Math equation alignment.</summary>
		tomMathEqAlign = 0x80,
		/// <summary>Start shading math arguments.</summary>
		tomMathArgShadingStart = 0x251,
		/// <summary>End shading math arguments.</summary>
		tomMathArgShadingEnd = 0x252,
		/// <summary>Start shading math objects.</summary>
		tomMathObjShadingStart = 0x253,
		/// <summary>End shading math objects.</summary>
		tomMathObjShadingEnd = 0x254,
		/// <summary>Not in the function list.</summary>
		tomFunctionTypeNone = 0,
		/// <summary>An ordinary math function that takes arguments.</summary>
		tomFunctionTypeTakesArg = 1,
		/// <summary>Use the lower limit for _, and so on.</summary>
		tomFunctionTypeTakesLim = 2,
		/// <summary>Turn the preceding FA into an NBSP.</summary>
		tomFunctionTypeTakesLim2 = 3,
		/// <summary>A "lim" function.</summary>
		tomFunctionTypeIsLim = 4,
		/// <summary>The default alignment for math paragraphs.</summary>
		tomMathParaAlignDefault = 0,
		/// <summary>Center math paragraphs as a group.</summary>
		tomMathParaAlignCenterGroup = 1,
		/// <summary>Center math paragraphs.</summary>
		tomMathParaAlignCenter = 2,
		/// <summary>Left-align math paragraphs.</summary>
		tomMathParaAlignLeft = 3,
		/// <summary>Right-align math paragraphs.</summary>
		tomMathParaAlignRight = 4,
		/// <summary>Mask for tomMathDispAlignCenterGroup, tomMathDispAlignCenter, tomMathDispAlignLeft, tomMathDispAlignRight, tomMathDispIntUnderOver, and tomMathDispNaryGrow.</summary>
		tomMathDispAlignMask = 3,
		/// <summary>Center a math paragraph as a group.</summary>
		tomMathDispAlignCenterGroup = 0,
		/// <summary>Center all equations in a math paragraph.</summary>
		tomMathDispAlignCenter = 1,
		/// <summary>Left justify all equations in a math paragraph.</summary>
		tomMathDispAlignLeft = 2,
		/// <summary>Right justify all equations in a math paragraph.</summary>
		tomMathDispAlignRight = 3,
		/// <summary>Display-mode integral limits location.</summary>
		tomMathDispIntUnderOver = 4,
		/// <summary>Indicates whether to use display-mode nested fraction script size.</summary>
		tomMathDispFracTeX = 8,
		/// <summary>Indicates whether to use math-paragraph n-ary grow.</summary>
		tomMathDispNaryGrow = 0x10,
		/// <summary>Empty arguments display mask.</summary>
		tomMathDocEmptyArgMask = 0x60,
		/// <summary>Dotted square, if necessary.</summary>
		tomMathDocEmptyArgAuto = 0,
		/// <summary>Dotted square, always.</summary>
		tomMathDocEmptyArgAlways = 0x20,
		/// <summary>Nothing.</summary>
		tomMathDocEmptyArgNever = 0x40,
		/// <summary>Do not display the underscore (_) as subscripted, or the caret (^) as superscripted.</summary>
		tomMathDocSbSpOpUnchanged = 0x80,
		/// <summary>Style mask for the tomMathDocDiffUpright, tomMathDocDiffItalic, tomMathDocDiffOpenItalic options.</summary>
		tomMathDocDiffMask = 0x300,
		/// <summary>Use default glyphs for math differentials.</summary>
		tomMathDocDiffDefault = 0,
		/// <summary>Use upright glyphs for math differentials.</summary>
		tomMathDocDiffUpright = 0x100,
		/// <summary>Use italic glyphs for math differentials.</summary>
		tomMathDocDiffItalic = 0x200,
		/// <summary>No glyph change.</summary>
		tomMathDocDiffOpenItalic = 0x300,
		/// <summary>Math-paragraph non-integral n-ary limits location.</summary>
		tomMathDispNarySubSup = 0x400,
		/// <summary>Math-paragraph spacing defaults. Use math paragraph offsets instead of regular paragraph offsets.</summary>
		tomMathDispDef = 0x800,
		/// <summary>Enable right-to-left (RTL) math zones in RTL paragraphs.</summary>
		tomMathEnableRtl = 0x1000,
		/// <summary>Equation line break mask.</summary>
		tomMathBrkBinMask = 0x30000,
		/// <summary>Break before binary/relational operator.</summary>
		tomMathBrkBinBefore = 0,
		/// <summary>Break after binary/relational operator.</summary>
		tomMathBrkBinAfter = 0x10000,
		/// <summary>Duplicate binary/relational before/after.</summary>
		tomMathBrkBinDup = 0x20000,
		/// <summary>Duplicate mask for minus operator.</summary>
		tomMathBrkBinSubMask = 0xc0000,
		/// <summary>-- (minus on both lines).</summary>
		tomMathBrkBinSubMM = 0,
		/// <summary>+ -</summary>
		tomMathBrkBinSubPM = 0x40000,
		/// <summary>- +</summary>
		tomMathBrkBinSubMP = 0x80000,
		/// <summary>Set the selection character position and character count to range values.</summary>
		tomSelRange = 0x255,
		/// <summary>Use a string handle (HSTRING) instead of a binary string (BSTR).</summary>
		tomHstring = 0x254,
		/// <summary>Gets the TeX style of the font.</summary>
		tomFontPropTeXStyle = 0x33c,
		/// <summary>
		/// Use tomFontPropAlign to get the Align property of an operator in a math zone. Here are how the values are assigned:
		/// <list type="bullet"><item>Value 0 implies no special alignment.</item><item>Values 1 through 127 align the operator with the (n – 1)st operator on the first line of an equation.</item><item>Value 128 identifies operators to be vertically aligned with respect to one another ("Align at =").</item><item>Other values are illegal.</item></list></summary>
		tomFontPropAlign = 0x33d,
		/// <summary>
		/// The type of font stretching. It can have one of the following values.
		/// <list type="bullet"><item>tomFontStretchDefault</item><item>tomFontStretchUltraCondensed</item><item>tomFontStretchExtraCondensed</item><item>tomFontStretchCondensed</item><item>tomFontStretchNormal</item><item>tomFontStretchSemiExpanded</item><item>tomFontStretchExpanded</item><item>tomFontStretchExtraExpanded</item><item>tomFontStretchUltraExpanded</item></list></summary>
		tomFontStretch = 0x33e,
		/// <summary>
		/// The font style. It can have one of the following values.
		/// <list type="bullet"><item>tomFontStyleUpright</item><item>tomFontStyleItalic</item><item>tomFontStyleOblique</item></list></summary>
		tomFontStyle = 0x33f,
		/// <summary>Represents the normal upright font style.</summary>
		tomFontStyleUpright = 0,
		/// <summary>Represents an oblique font style.</summary>
		tomFontStyleOblique = 1,
		/// <summary>Represents an italic font style.</summary>
		tomFontStyleItalic = 2,
		/// <summary>No defined font stretch.</summary>
		tomFontStretchDefault = 0,
		/// <summary>An ultra-condensed font stretch (50% of normal).</summary>
		tomFontStretchUltraCondensed = 1,
		/// <summary>An extra-condensed font stretch (62.5% of normal).</summary>
		tomFontStretchExtraCondensed = 2,
		/// <summary>A condensed font stretch (75% of normal).</summary>
		tomFontStretchCondensed = 3,
		/// <summary>A semi-condensed font stretch (87.5% of normal).</summary>
		tomFontStretchSemiCondensed = 4,
		/// <summary>The normal font stretch that all other font stretch values relate to (100%).</summary>
		tomFontStretchNormal = 5,
		/// <summary>A semi-expanded font stretch (112.5% of normal).</summary>
		tomFontStretchSemiExpanded = 6,
		/// <summary>An expanded font stretch (125% of normal).</summary>
		tomFontStretchExpanded = 7,
		/// <summary>An extra-expanded font stretch (150% of normal).</summary>
		tomFontStretchExtraExpanded = 8,
		/// <summary>An ultra-expanded font stretch (200% of normal).</summary>
		tomFontStretchUltraExpanded = 9,
		/// <summary>The default font weight.</summary>
		tomFontWeightDefault = 0,
		/// <summary>Thin font weight.</summary>
		tomFontWeightThin = 100,
		/// <summary>Extra light font weight.</summary>
		tomFontWeightExtraLight = 200,
		/// <summary>Light font weight.</summary>
		tomFontWeightLight = 300,
		/// <summary>Normal font weight.</summary>
		tomFontWeightNormal = 400,
		/// <summary>Same as tomFontWeightNormal.</summary>
		tomFontWeightRegular = 400,
		/// <summary>Medium font weight.</summary>
		tomFontWeightMedium = 500,
		/// <summary>Semi bold font weight.</summary>
		tomFontWeightSemiBold = 600,
		/// <summary>Bold font weight.</summary>
		tomFontWeightBold = 700,
		/// <summary>Extra bold font weight.</summary>
		tomFontWeightExtraBold = 800,
		/// <summary>Heavy font weight.</summary>
		tomFontWeightBlack = 900,
		/// <summary>Same as tomFontWeightBlack.</summary>
		tomFontWeightHeavy = 900,
		/// <summary>Extra heavy font weight.</summary>
		tomFontWeightExtraBlack = 950,
		/// <summary>Alignment properties for a math paragraph.</summary>
		tomParaPropMathAlign = 0x437,
		/// <summary>Used with the ITextDocument2::SetProperty method to set any combination of tomMathAutoCorrect, tomTeX, or tomMathAlphabetics.</summary>
		tomDocMathBuild = 0x80,
		/// <summary>Left margin for display math.</summary>
		tomMathLMargin = 0x81,
		/// <summary>Right margin for display math.</summary>
		tomMathRMargin = 0x82,
		/// <summary>Equation wrap indent for display math.</summary>
		tomMathWrapIndent = 0x83,
		/// <summary>Equation right wrap indent for display math (in a left-to-right (LTR) math zone).</summary>
		tomMathWrapRight = 0x84,
		/// <summary>Space after a display math equation.</summary>
		tomMathPostSpace = 0x86,
		/// <summary>Space before a display math equation.</summary>
		tomMathPreSpace = 0x85,
		/// <summary>Space between equations in math paragraphs.</summary>
		tomMathInterSpace = 0x87,
		/// <summary>Space between lines in a display math equation.</summary>
		tomMathIntraSpace = 0x88,
		/// <summary>Indicates whether data can be copied to the clipboard.</summary>
		tomCanCopy = 0x89,
		/// <summary>Indicates whether one or more redo operations exist.</summary>
		tomCanRedo = 0x8a,
		/// <summary>Indicates whether one or more undo operations exist.</summary>
		tomCanUndo = 0x8b,
		/// <summary>The undo stack count limit.</summary>
		tomUndoLimit = 0x8c,
		/// <summary>A document automatic link.</summary>
		tomDocAutoLink = 0x8d,
		/// <summary>The ellipsis mode.</summary>
		tomEllipsisMode = 0x8e,
		/// <summary>The ellipsis state.</summary>
		tomEllipsisState = 0x8f,
		/// <summary>Ellipsis is disabled.</summary>
		tomEllipsisNone = 0,
		/// <summary>An ellipsis forces a break anywhere in the line.</summary>
		tomEllipsisEnd = 1,
		/// <summary>An ellipsis forces a break between words.</summary>
		tomEllipsisWord = 3,
		/// <summary>Ellipsis is present.</summary>
		tomEllipsisPresent = 1,
		/// <summary>The top cell in vertically merged cell set.</summary>
		tomVTopCell = 1,
		/// <summary>Any cell except the top cell in a vertically merged cell set.</summary>
		tomVLowCell = 2,
		/// <summary>Start a cell in a horizontally merged cell set.</summary>
		tomHStartCell = 4,
		/// <summary>Any cell except the start in a horizontally merged cell set.</summary>
		tomHContCell = 8,
		/// <summary>Update the row to have the properties of the table row identified by the associated text range.</summary>
		tomRowUpdate = 1,
		/// <summary/>
		tomRowApplyDefault = 0,
		/// <summary>Changes cell width(s) or cell count (for changing column widths and inserting/deleting columns without changing cell border properties, and so forth.)</summary>
		tomCellStructureChangeOnly = 1,
		/// <summary>The actual height of a table row.</summary>
		tomRowHeightActual = 0x80b,
	}

	/// <summary>Represents the displays collection for this Text Object Model (TOM) engine instance.</summary>
	/// <remarks>This interface is currently undefined.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextdisplays
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextDisplays")]
	[ComImport, Guid("C241F5F2-7206-11D8-A2C7-00A0D1D6C6B3"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ITextDisplays
	{
	}

	/// <summary>
	/// <para>The <c>ITextDocument</c> interface is the Text Object Model (TOM) top-level interface, which retrieves the active selection and range objects for any story in the documentâwhether active or not. It enables the application to:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Open and save documents.</description>
	/// </item>
	/// <item>
	/// <description>Control undo behavior and screen updating.</description>
	/// </item>
	/// <item>
	/// <description>Find a range from a screen position.</description>
	/// </item>
	/// <item>
	/// <description>Get an ITextStoryRanges story enumerator.</description>
	/// </item>
	/// </list>
	/// <para><c>When to Implement</c></para>
	/// <para>Applications typically do not implement the <c>ITextDocument</c> interface. Microsoft text solutions, such as rich edit controls, implement <c>ITextDocument</c> as part of their TOM implementation.</para>
	/// <para><c>When to Use</c></para>
	/// <para>Applications can retrieve an <c>ITextDocument</c> pointer from a rich edit control. To do this, send an EM_GETOLEINTERFACE message to retrieve an IRichEditOle object from a rich edit control. Then, call the object's IUnknown::QueryInterface method to retrieve an <c>ITextDocument</c> pointer.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextdocument
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextDocument")]
	[ComImport, Guid("8CC497C0-A1DF-11ce-8098-00AA0047BE5D"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface ITextDocument
	{
		/// <summary>Gets the file name of this document. This is the ITextDocument default property.</summary>
		/// <returns>
		///   <para>Type: <c>BSTR*</c></para>
		///   <para>The file name.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-getname
		// HRESULT GetName( BSTR *pName );
		string GetName();

		/// <summary>Gets the active selection.</summary>
		/// <returns>
		///   <para>Type: <c>ITextSelection**</c></para>
		///   <para>The active selection.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-getselection
		// HRESULT GetSelection( ITextSelection **ppSel );
		ITextSelection GetSelection();

		/// <summary>Gets the count of stories in this document.</summary>
		/// <returns>
		///   <para>Type: <c>LONG*</c></para>
		///   <para>The number of stories in the document.</para>
		/// </returns>
		/// <remarks>Rich edit controls have only one story and do not implement the ITextDocument::GetStoryRanges method. To avoid getting an error when there is only one story, use <c>ITextDocument::GetStoryCount</c> to check the story count. If the story count is greater than one, then call <c>ITextDocument::GetStoryRanges</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-getstorycount
		// HRESULT GetStoryCount( long *pCount );
		int GetStoryCount();

		/// <summary>Gets the story collection object used to enumerate the stories in a document.</summary>
		/// <returns>
		///   <para>Type: <c>ITextStoryRanges**</c></para>
		///   <para>The ITextStoryRanges pointer.</para>
		/// </returns>
		/// <remarks>Invoke this method only if ITextDocument::GetStoryCount returns a value greater than 1.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-getstoryranges
		// HRESULT GetStoryRanges( ITextStoryRanges **ppStories );
		ITextStoryRanges GetStoryRanges();

		/// <summary>Gets a value that indicates whether changes have been made since the file was last saved.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The value <c>tomTrue</c> if no changes have been made since the file was last saved, or the value <c>tomFalse</c> if there are unsaved changes.</para>
		/// </returns>
		/// <remarks>To set the saved property, call the ITextDocument::SetSaved method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-getsaved
		// HRESULT GetSaved( long *pValue );
		int GetSaved();

		/// <summary>Sets the document <c>Saved</c> property.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>New value of the <c>Saved</c> property. It can be one of the following values.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>No changes to the file since the last time it was saved.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>There are changes to the file.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-setsaved
		// HRESULT SetSaved( [in] long Value );
		void SetSaved(int Value);

		/// <summary>Gets the default tab width.</summary>
		/// <returns>
		///   <para>Type: <c>float*</c></para>
		///   <para>The default tab width.</para>
		/// </returns>
		/// <remarks>The default tab width is used whenever no tab exists beyond the current display position. The default width is given in floating-point points.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-getdefaulttabstop
		// HRESULT GetDefaultTabStop( float *pValue );
		float GetDefaultTabStop();

		/// <summary>Sets the default tab stop, which is used when no tab exists beyond the current display position.</summary>
		/// <param name="Value">
		///   <para>Type: <c>float</c></para>
		///   <para>New default tab setting, in floating-point points. Default value is 36.0 points, that is, 0.5 inches.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-setdefaulttabstop
		// HRESULT SetDefaultTabStop( [in] float Value );
		void SetDefaultTabStop(float Value);

		/// <summary>Opens a new document.</summary>
		/// <remarks>If another document is open, this method saves any current changes and closes the current document before opening a new one.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-new
		// HRESULT New();
		void New();

		/// <summary>Opens a specified document. There are parameters to specify access and sharing privileges, creation and conversion of the file, as well as the code page for the file.</summary>
		/// <param name="pVar">
		///   <para>Type: <c>VARIANT*</c></para>
		///   <para>A <c>VARIANT</c> that specifies the name of the file to open.</para>
		/// </param>
		/// <param name="Flags">
		///   <para>Type: <c>long</c></para>
		///   <para>The file creation, open, share, and conversion flags. Default value is zero, which gives read/write access and read/write sharing, open always, and automatic recognition of the file format (unrecognized file formats are treated as text). Other values are defined in the following groups.</para>
		///   <para>Any combination of these values may be used.</para>
		///   <para>tomReadOnly</para>
		///   <para>tomShareDenyRead</para>
		///   <para>tomShareDenyWrite</para>
		///   <para>tomPasteFile</para>
		///   <para>These values are mutually exclusive.</para>
		///   <para>tomCreateNew</para>
		///   <para>tomCreateAlways</para>
		///   <para>tomOpenExisting</para>
		///   <para>tomOpenAlways</para>
		///   <para>tomTruncateExisting</para>
		///   <para>tomRTF</para>
		///   <para>tomText</para>
		///   <para>tomHTML</para>
		///   <para>tomWordDocument</para>
		/// </param>
		/// <param name="CodePage">
		///   <para>Type: <c>long</c></para>
		///   <para>The code page to use for the file. Zero (the default value) means <c>CP_ACP</c> (ANSI code page) unless the file begins with a UnicodeÂ BOM 0xfeff, in which case the file is considered to be Unicode. Note that code page 1200 is Unicode, <c>CP_UTF8</c> is UTF-8.</para>
		/// </param>
		/// <remarks>
		///   <para>If a document is created with the ITextDocument::New method and the zero values are used, then the Text Object Model (TOM) engine has to choose which flags and code page to use. UTF-8Â Rich Text Format (RTF) (defined below) is an attractive default.</para>
		///   <para>Microsoft Rich EditÂ 3.0 defines a control word, \urtf8, which should be used instead of \rtf1. This means the file is encoded in UTF-8. On input, RTF files contain the relevant code-page information, but this can be changed for saving purposes, thereby allowing one version to be translated to another.</para>
		///   <para>If the tomPasteFile flag is not set in the <c>Flags</c> parameter, the method first closes the current document after saving any unsaved changes.</para>
		///   <para>A file is recognized as a Unicode text file if it starts with the UnicodeÂ BOM 0xfeff. The <c>ITextDocument::Open</c> method strips off this UnicodeÂ BOM on input and ITextDocument::Save applies it on output. See the comments on the <c>ITextDocument::Save</c> method, which discuss putting the UnicodeÂ BOM at the beginning of Unicode plain-text files. The conversion values <c>tomRTF</c>, <c>tomHTML</c>, and <c>tomWordDocument</c> are used primarily for the <c>ITextDocument::Save</c> method, since these formats are easily recognized on input.</para>
		///   <para>Errors are reported by negative values, but because file operations have many kinds of errors, you may not need all of the error information provided. In particular, you may not care (or you may already know) which file facility is used, namely Windows () or OLE storage for IStorage. By masking off bit 18 of an <c>HRESULT</c> value, you can ignore the difference and compare to its <c>STG_E_xxx</c> value. For example:</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-open
		// HRESULT Open( [in] VARIANT *pVar, long Flags, long CodePage );
		void Open([In] object pVar, tomConstants Flags, uint CodePage);

		/// <summary>Saves the document.</summary>
		/// <param name="pVar">
		///   <para>Type: <c>VARIANT*</c></para>
		///   <para>The save target. This parameter is a <c>VARIANT</c>, which can be a file name, or <c>NULL</c>.</para>
		/// </param>
		/// <param name="Flags">
		///   <para>Type: <c>long</c></para>
		///   <para>File creation, open, share, and conversion flags. For a list of possible values, see ITextDocument::Open.</para>
		/// </param>
		/// <param name="CodePage">
		///   <para>Type: <c>long</c></para>
		///   <para>The specified code page. Common values are CP_ACP (zero: system ANSI code page), 1200 (Unicode), and 1208 (UTF-8).</para>
		/// </param>
		/// <remarks>
		///   <para>To use the parameters that were specified for opening the file, use zero values for the parameters.</para>
		///   <para>If <c>pVar</c> is null or missing, the file name given by this document's name is used. If both of these are missing or null, the method fails.</para>
		///   <para>If <c>pVar</c> specifies a file name, that name should replace the current Name property. Similarly, the <c>Flags</c> and <c>CodePage</c> arguments can overrule those supplied in the ITextDocument::Open method and define the values to use for files created with the ITextDocument::New method.</para>
		///   <para>Unicode plain-text files should be saved with the Unicode byte-order mark (0xFEFF) as the first character. This character should be removed when the file is read in; that is, it is only used for import/export to identify the plain text as Unicode and to identify the byte order of that text. Microsoft Notepad adopted this convention, which is now recommended by the Unicode standard.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-save
		// HRESULT Save( [in] VARIANT *pVar, [in] long Flags, [in] long CodePage );
		void Save([In] object pVar, tomConstants Flags, uint CodePage);

		/// <summary>Increments the freeze count.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The updated freeze count.</para>
		/// </returns>
		/// <remarks>If the freeze count is nonzero, screen updating is disabled. This allows a sequence of editing operations to be performed without the performance loss and flicker of screen updating. To decrement the freeze count, call the ITextDocument::Unfreeze method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-freeze
		// HRESULT Freeze( long *pCount );
		int Freeze();

		/// <summary>Decrements the freeze count.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The updated freeze count.</para>
		/// </returns>
		/// <remarks>
		///   <para>If the freeze count goes to zero, screen updating is enabled. This method cannot decrement the count below zero, and no error occurs if it is executed with a zero freeze count.</para>
		///   <para>Note, if edit collection is active, screen updating is suppressed, even if the freeze count is zero.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-unfreeze
		// HRESULT Unfreeze( long *pCount );
		int Unfreeze();

		/// <summary>Turns on edit collection (also called <c>undo grouping</c>).</summary>
		/// <remarks>A single <c>Undo</c> command undoes all changes made while edit collection is turned on.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-begineditcollection
		// HRESULT BeginEditCollection();
		void BeginEditCollection();

		/// <summary>Turns off edit collection (also called <c>undo grouping</c>).</summary>
		/// <remarks>The screen is unfrozen unless the freeze count is nonzero.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-endeditcollection
		// HRESULT EndEditCollection();
		void EndEditCollection();

		/// <summary>Performs a specified number of undo operations.</summary>
		/// <param name="Count">
		///   <para>Type: <c>long</c></para>
		///   <para>The specified number of undo operations. If the value of this parameter is <c>tomFalse</c>, undo processing is suspended. If this parameter is <c>tomTrue</c>, undo processing is restored.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The actual count of undo operations performed. This parameter can be <c>NULL</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-undo
		// HRESULT Undo( long Count, long *pCount );
		int Undo(int Count);

		/// <summary>Performs a specified number of redo operations.</summary>
		/// <param name="Count">
		///   <para>Type: <c>long</c></para>
		///   <para>The number of redo operations specified.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The actual count of redo operations performed. This parameter can be <c>NULL</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-redo
		// HRESULT Redo( long Count, long *pCount );
		int Redo(int Count);

		/// <summary>Retrieves a text range object for a specified range of content in the active story of the document.</summary>
		/// <param name="cpActive">
		///   <para>Type: <c>long</c></para>
		///   <para>The start position of new range. The default value is zero, which represents the start of the document.</para>
		/// </param>
		/// <param name="cpAnchor">
		///   <para>Type: <c>long</c></para>
		///   <para>The end position of new range. The default value is zero.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>ITextRange**</c></para>
		///   <para>Address of a pointer to a variable of type ITextRange that receives a pointer to the specified text range.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-range
		// HRESULT Range( long cpActive, long cpAnchor, ITextRange **ppRange );
		ITextRange Range(int cpActive, int cpAnchor);

		/// <summary>Retrieves a range for the content at or nearest to the specified point on the screen.</summary>
		/// <param name="x">
		///   <para>Type: <c>long</c></para>
		///   <para>The horizontal coordinate of the specified point, in screen coordinates.</para>
		/// </param>
		/// <param name="y">
		///   <para>Type: <c>long</c></para>
		///   <para>The vertical coordinate of the specified point, in screen coordinates.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>ITextRange**</c></para>
		///   <para>The text range that corresponds to the specified point.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-rangefrompoint
		// HRESULT RangeFromPoint( long x, long y, ITextRange **ppRange );
		ITextRange RangeFromPoint(int x, int y);
	}

	/// <summary>
	/// <para>Extends the ITextDocument interface, adding methods that enable the Input Method Editor (IME) to drive the rich edit control, and methods to retrieve other interfaces such as ITextDisplays, ITextRange2, ITextFont2, ITextPara2, and so on.</para>
	/// <para>Some <c>ITextDocument2</c> methods used with the IME need access to the current window handle (<c>HWND</c>). Use the ITextDocument2::GetWindow method to retrieve the handle.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextdocument2
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextDocument2")]
	[ComImport, Guid("C241F5E0-7206-11D8-A2C7-00A0D1D6C6B3"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface ITextDocument2 : ITextDocument
	{
		/// <summary>Gets the file name of this document. This is the ITextDocument default property.</summary>
		/// <returns>
		///   <para>Type: <c>BSTR*</c></para>
		///   <para>The file name.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-getname
		// HRESULT GetName( BSTR *pName );
		new string GetName();

		/// <summary>Gets the active selection.</summary>
		/// <returns>
		///   <para>Type: <c>ITextSelection**</c></para>
		///   <para>The active selection.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-getselection
		// HRESULT GetSelection( ITextSelection **ppSel );
		new ITextSelection GetSelection();

		/// <summary>Gets the count of stories in this document.</summary>
		/// <returns>
		///   <para>Type: <c>LONG*</c></para>
		///   <para>The number of stories in the document.</para>
		/// </returns>
		/// <remarks>Rich edit controls have only one story and do not implement the ITextDocument::GetStoryRanges method. To avoid getting an error when there is only one story, use <c>ITextDocument::GetStoryCount</c> to check the story count. If the story count is greater than one, then call <c>ITextDocument::GetStoryRanges</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-getstorycount
		// HRESULT GetStoryCount( long *pCount );
		new int GetStoryCount();

		/// <summary>Gets the story collection object used to enumerate the stories in a document.</summary>
		/// <returns>
		///   <para>Type: <c>ITextStoryRanges**</c></para>
		///   <para>The ITextStoryRanges pointer.</para>
		/// </returns>
		/// <remarks>Invoke this method only if ITextDocument::GetStoryCount returns a value greater than 1.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-getstoryranges
		// HRESULT GetStoryRanges( ITextStoryRanges **ppStories );
		new ITextStoryRanges GetStoryRanges();

		/// <summary>Gets a value that indicates whether changes have been made since the file was last saved.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The value <c>tomTrue</c> if no changes have been made since the file was last saved, or the value <c>tomFalse</c> if there are unsaved changes.</para>
		/// </returns>
		/// <remarks>To set the saved property, call the ITextDocument::SetSaved method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-getsaved
		// HRESULT GetSaved( long *pValue );
		new int GetSaved();

		/// <summary>Sets the document <c>Saved</c> property.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>New value of the <c>Saved</c> property. It can be one of the following values.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>No changes to the file since the last time it was saved.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>There are changes to the file.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-setsaved
		// HRESULT SetSaved( [in] long Value );
		new void SetSaved(int Value);

		/// <summary>Gets the default tab width.</summary>
		/// <returns>
		///   <para>Type: <c>float*</c></para>
		///   <para>The default tab width.</para>
		/// </returns>
		/// <remarks>The default tab width is used whenever no tab exists beyond the current display position. The default width is given in floating-point points.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-getdefaulttabstop
		// HRESULT GetDefaultTabStop( float *pValue );
		new float GetDefaultTabStop();

		/// <summary>Sets the default tab stop, which is used when no tab exists beyond the current display position.</summary>
		/// <param name="Value">
		///   <para>Type: <c>float</c></para>
		///   <para>New default tab setting, in floating-point points. Default value is 36.0 points, that is, 0.5 inches.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-setdefaulttabstop
		// HRESULT SetDefaultTabStop( [in] float Value );
		new void SetDefaultTabStop(float Value);

		/// <summary>Opens a new document.</summary>
		/// <remarks>If another document is open, this method saves any current changes and closes the current document before opening a new one.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-new
		// HRESULT New();
		new void New();

		/// <summary>Opens a specified document. There are parameters to specify access and sharing privileges, creation and conversion of the file, as well as the code page for the file.</summary>
		/// <param name="pVar">
		///   <para>Type: <c>VARIANT*</c></para>
		///   <para>A <c>VARIANT</c> that specifies the name of the file to open.</para>
		/// </param>
		/// <param name="Flags">
		///   <para>Type: <c>long</c></para>
		///   <para>The file creation, open, share, and conversion flags. Default value is zero, which gives read/write access and read/write sharing, open always, and automatic recognition of the file format (unrecognized file formats are treated as text). Other values are defined in the following groups.</para>
		///   <para>Any combination of these values may be used.</para>
		///   <para>tomReadOnly</para>
		///   <para>tomShareDenyRead</para>
		///   <para>tomShareDenyWrite</para>
		///   <para>tomPasteFile</para>
		///   <para>These values are mutually exclusive.</para>
		///   <para>tomCreateNew</para>
		///   <para>tomCreateAlways</para>
		///   <para>tomOpenExisting</para>
		///   <para>tomOpenAlways</para>
		///   <para>tomTruncateExisting</para>
		///   <para>tomRTF</para>
		///   <para>tomText</para>
		///   <para>tomHTML</para>
		///   <para>tomWordDocument</para>
		/// </param>
		/// <param name="CodePage">
		///   <para>Type: <c>long</c></para>
		///   <para>The code page to use for the file. Zero (the default value) means <c>CP_ACP</c> (ANSI code page) unless the file begins with a UnicodeÂ BOM 0xfeff, in which case the file is considered to be Unicode. Note that code page 1200 is Unicode, <c>CP_UTF8</c> is UTF-8.</para>
		/// </param>
		/// <remarks>
		///   <para>If a document is created with the ITextDocument::New method and the zero values are used, then the Text Object Model (TOM) engine has to choose which flags and code page to use. UTF-8Â Rich Text Format (RTF) (defined below) is an attractive default.</para>
		///   <para>Microsoft Rich EditÂ 3.0 defines a control word, \urtf8, which should be used instead of \rtf1. This means the file is encoded in UTF-8. On input, RTF files contain the relevant code-page information, but this can be changed for saving purposes, thereby allowing one version to be translated to another.</para>
		///   <para>If the tomPasteFile flag is not set in the <c>Flags</c> parameter, the method first closes the current document after saving any unsaved changes.</para>
		///   <para>A file is recognized as a Unicode text file if it starts with the UnicodeÂ BOM 0xfeff. The <c>ITextDocument::Open</c> method strips off this UnicodeÂ BOM on input and ITextDocument::Save applies it on output. See the comments on the <c>ITextDocument::Save</c> method, which discuss putting the UnicodeÂ BOM at the beginning of Unicode plain-text files. The conversion values <c>tomRTF</c>, <c>tomHTML</c>, and <c>tomWordDocument</c> are used primarily for the <c>ITextDocument::Save</c> method, since these formats are easily recognized on input.</para>
		///   <para>Errors are reported by negative values, but because file operations have many kinds of errors, you may not need all of the error information provided. In particular, you may not care (or you may already know) which file facility is used, namely Windows () or OLE storage for IStorage. By masking off bit 18 of an <c>HRESULT</c> value, you can ignore the difference and compare to its <c>STG_E_xxx</c> value. For example:</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-open
		// HRESULT Open( [in] VARIANT *pVar, long Flags, long CodePage );
		new void Open([In] object pVar, tomConstants Flags, uint CodePage);

		/// <summary>Saves the document.</summary>
		/// <param name="pVar">
		///   <para>Type: <c>VARIANT*</c></para>
		///   <para>The save target. This parameter is a <c>VARIANT</c>, which can be a file name, or <c>NULL</c>.</para>
		/// </param>
		/// <param name="Flags">
		///   <para>Type: <c>long</c></para>
		///   <para>File creation, open, share, and conversion flags. For a list of possible values, see ITextDocument::Open.</para>
		/// </param>
		/// <param name="CodePage">
		///   <para>Type: <c>long</c></para>
		///   <para>The specified code page. Common values are CP_ACP (zero: system ANSI code page), 1200 (Unicode), and 1208 (UTF-8).</para>
		/// </param>
		/// <remarks>
		///   <para>To use the parameters that were specified for opening the file, use zero values for the parameters.</para>
		///   <para>If <c>pVar</c> is null or missing, the file name given by this document's name is used. If both of these are missing or null, the method fails.</para>
		///   <para>If <c>pVar</c> specifies a file name, that name should replace the current Name property. Similarly, the <c>Flags</c> and <c>CodePage</c> arguments can overrule those supplied in the ITextDocument::Open method and define the values to use for files created with the ITextDocument::New method.</para>
		///   <para>Unicode plain-text files should be saved with the Unicode byte-order mark (0xFEFF) as the first character. This character should be removed when the file is read in; that is, it is only used for import/export to identify the plain text as Unicode and to identify the byte order of that text. Microsoft Notepad adopted this convention, which is now recommended by the Unicode standard.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-save
		// HRESULT Save( [in] VARIANT *pVar, [in] long Flags, [in] long CodePage );
		new void Save([In] object pVar, tomConstants Flags, uint CodePage);

		/// <summary>Increments the freeze count.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The updated freeze count.</para>
		/// </returns>
		/// <remarks>If the freeze count is nonzero, screen updating is disabled. This allows a sequence of editing operations to be performed without the performance loss and flicker of screen updating. To decrement the freeze count, call the ITextDocument::Unfreeze method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-freeze
		// HRESULT Freeze( long *pCount );
		new int Freeze();

		/// <summary>Decrements the freeze count.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The updated freeze count.</para>
		/// </returns>
		/// <remarks>
		///   <para>If the freeze count goes to zero, screen updating is enabled. This method cannot decrement the count below zero, and no error occurs if it is executed with a zero freeze count.</para>
		///   <para>Note, if edit collection is active, screen updating is suppressed, even if the freeze count is zero.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-unfreeze
		// HRESULT Unfreeze( long *pCount );
		new int Unfreeze();

		/// <summary>Turns on edit collection (also called <c>undo grouping</c>).</summary>
		/// <remarks>A single <c>Undo</c> command undoes all changes made while edit collection is turned on.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-begineditcollection
		// HRESULT BeginEditCollection();
		new void BeginEditCollection();

		/// <summary>Turns off edit collection (also called <c>undo grouping</c>).</summary>
		/// <remarks>The screen is unfrozen unless the freeze count is nonzero.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-endeditcollection
		// HRESULT EndEditCollection();
		new void EndEditCollection();

		/// <summary>Performs a specified number of undo operations.</summary>
		/// <param name="Count">
		///   <para>Type: <c>long</c></para>
		///   <para>The specified number of undo operations. If the value of this parameter is <c>tomFalse</c>, undo processing is suspended. If this parameter is <c>tomTrue</c>, undo processing is restored.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The actual count of undo operations performed. This parameter can be <c>NULL</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-undo
		// HRESULT Undo( long Count, long *pCount );
		new int Undo(int Count);

		/// <summary>Performs a specified number of redo operations.</summary>
		/// <param name="Count">
		///   <para>Type: <c>long</c></para>
		///   <para>The number of redo operations specified.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The actual count of redo operations performed. This parameter can be <c>NULL</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-redo
		// HRESULT Redo( long Count, long *pCount );
		new int Redo(int Count);

		/// <summary>Retrieves a text range object for a specified range of content in the active story of the document.</summary>
		/// <param name="cpActive">
		///   <para>Type: <c>long</c></para>
		///   <para>The start position of new range. The default value is zero, which represents the start of the document.</para>
		/// </param>
		/// <param name="cpAnchor">
		///   <para>Type: <c>long</c></para>
		///   <para>The end position of new range. The default value is zero.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>ITextRange**</c></para>
		///   <para>Address of a pointer to a variable of type ITextRange that receives a pointer to the specified text range.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-range
		// HRESULT Range( long cpActive, long cpAnchor, ITextRange **ppRange );
		new ITextRange Range(int cpActive, int cpAnchor);

		/// <summary>Retrieves a range for the content at or nearest to the specified point on the screen.</summary>
		/// <param name="x">
		///   <para>Type: <c>long</c></para>
		///   <para>The horizontal coordinate of the specified point, in screen coordinates.</para>
		/// </param>
		/// <param name="y">
		///   <para>Type: <c>long</c></para>
		///   <para>The vertical coordinate of the specified point, in screen coordinates.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>ITextRange**</c></para>
		///   <para>The text range that corresponds to the specified point.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument-rangefrompoint
		// HRESULT RangeFromPoint( long x, long y, ITextRange **ppRange );
		new ITextRange RangeFromPoint(int x, int y);

		/// <summary>Gets the caret type.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The caret type. It can be one of the following values:</para>
		///   <para>tomKoreanBlockCaret</para>
		///   <para>tomNormalCaret</para>
		///   <para>tomNullCaret</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getcarettype
		// HRESULT GetCaretType( [out, retval] long *pValue );
		tomConstants GetCaretType();

		/// <summary>Sets the caret type.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The new caret type. It can be one of the following values:</para>
		///   <para>tomKoreanBlockCaret</para>
		///   <para>tomNormalCaret</para>
		///   <para>tomNullCaret</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-setcarettype
		// HRESULT SetCaretType( [in] long Value );
		void SetCaretType(tomConstants Value);

		/// <summary>Gets the displays collection for this Text Object Model (TOM) engine instance.</summary>
		/// <returns>
		///   <para>Type: <c>ITextDisplays**</c></para>
		///   <para>The displays collection.</para>
		/// </returns>
		/// <remarks>The rich edit control doesn't implement this method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getdisplays
		// HRESULT GetDisplays( [out, retval] ITextDisplays **ppDisplays );
		ITextDisplays GetDisplays();

		/// <summary>Gets an object that provides the default character format information for this instance of the Text Object Model (TOM) engine.</summary>
		/// <returns>
		///   <para>Type: <c>ITextFont2**</c></para>
		///   <para>The object that provides the default character format information.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getdocumentfont
		// HRESULT GetDocumentFont( [out, retval] ITextFont2 **ppFont );
		ITextFont2 GetDocumentFont();

		/// <summary>Sets the default character formatting for this instance of the Text Object Model (TOM) engine.</summary>
		/// <param name="pFont">
		///   <para>Type: <c>ITextFont2*</c></para>
		///   <para>The font object that provides the default character formatting.</para>
		/// </param>
		/// <remarks>You can also set the default character formatting by calling ITextFont::Reset(tomDefault).</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-setdocumentfont
		// HRESULT SetDocumentFont( [in] ITextFont2 *pFont );
		void SetDocumentFont([In, Optional] ITextFont2? pFont);

		/// <summary>Gets an object that provides the default paragraph format information for this instance of the Text Object Model (TOM) engine.</summary>
		/// <returns>
		///   <para>Type: <c>ITextPara2**</c></para>
		///   <para>The object that provides the default paragraph format information.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getdocumentpara
		// HRESULT GetDocumentPara( [out, retval] ITextPara2 **ppPara );
		ITextPara2 GetDocumentPara();

		/// <summary>Sets the default paragraph formatting for this instance of the Text Object Model (TOM) engine.</summary>
		/// <param name="pPara">
		///   <para>Type: <c>ITextPara2*</c></para>
		///   <para>The paragraph object that provides the default paragraph formatting</para>
		/// </param>
		/// <remarks>You can also set the default paragraph formatting by calling ITextPara::Reset(tomDefault).</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-setdocumentpara
		// HRESULT SetDocumentPara( [in] ITextPara2 *pPara );
		void SetDocumentPara([In, Optional] ITextPara2? pPara);

		/// <summary>Gets the East Asian flags.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The East Asian flags. This parameter can be a combination of the following values.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomRE10Mode</c>
		///       </description>
		///       <description>TOM version 1.0 emulation mode.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUseAtFont</c>
		///       </description>
		///       <description>Use @ fonts for CJK vertical text.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomTextFlowMask</c>
		///       </description>
		///       <description>A mask for the following four text orientations: <c>tomTextFlowES</c> Ordinary left-to-right horizontal text. <c>tomTextFlowSW</c> Ordinary East Asian vertical text. <c>tomTextFlowWN</c> An alternative orientation. <c>tomTextFlowNE</c> An alternative orientation.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUsePassword</c>
		///       </description>
		///       <description>Use password control.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomNoIME</c>
		///       </description>
		///       <description>Turn off IME operation (see ES_NOIME).</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomSelfIME</c>
		///       </description>
		///       <description>The rich edit host handles IME operation (see ES_SELFIME) .</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-geteastasianflags
		// HRESULT GetEastAsianFlags( [out, retval] long *pFlags );
		tomConstants GetEastAsianFlags();

		/// <summary>Gets the name of the Text Object Model (TOM) engine.</summary>
		/// <returns>
		///   <para>Type: <c>BSTR*</c></para>
		///   <para>The name of the TOM engine.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getgenerator
		// HRESULT GetGenerator( [out, retval] BSTR *pbstr );
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetGenerator();

		/// <summary>Sets the state of the Input Method Editor (IME) in-progress flag.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>Use <c>tomTrue</c> to turn on the IME in-progress flag, or <c>tomFalse</c> to turn it off.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-setimeinprogress
		// HRESULT SetIMEInProgress( [in] long Value );
		void SetIMEInProgress(tomConstants Value);

		/// <summary>Gets the notification mode.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The notification mode. This parameter is set to <c>tomTrue</c> if notifications are active, or <c>tomFalse</c> if not.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getnotificationmode
		// HRESULT GetNotificationMode( [out, retval] long *pValue );
		tomConstants GetNotificationMode();

		/// <summary>Sets the notification mode.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The notification mode. Use <c>tomTrue</c> to turn on notifications, or <c>tomFalse</c> to turn them off.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-setnotificationmode
		// HRESULT SetNotificationMode( [in] long Value );
		void SetNotificationMode(tomConstants Value);

		/// <summary>Gets the active selection.</summary>
		/// <returns>
		///   <para>Type: <c>ITextSelection2**</c></para>
		///   <para>The active selection. This parameter is <c>NULL</c> if the rich edit control is not in-place active.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getselection2
		// HRESULT GetSelection2( [out, retval] ITextSelection2 **ppSel );
		ITextSelection2 GetSelection2();

		/// <summary>Gets an object for enumerating the stories in a document.</summary>
		/// <returns>
		///   <para>Type: <c>ITextStoryRanges2**</c></para>
		///   <para>The object for enumerating stories.</para>
		/// </returns>
		/// <remarks>Call this method only if the ITextDocument::GetStoryCount method returns a value that is greater than one.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getstoryranges2
		// HRESULT GetStoryRanges2( [out, retval] ITextStoryRanges2 **ppStories );
		ITextStoryRanges2 GetStoryRanges2();

		/// <summary>Gets the typography options.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A combination of the following typography options.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>TO_ADVANCEDTYPOGRAPHY</c>
		///       </description>
		///       <description>Advanced typography (special line breaking and line formatting) is turned on.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>TO_SIMPLELINEBREAK</c>
		///       </description>
		///       <description>Normal line breaking and formatting is used.</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-gettypographyoptions
		// HRESULT GetTypographyOptions( [out, retval] long *pOptions );
		TO GetTypographyOptions();

		/// <summary>Gets the version number of the Text Object Model (TOM) engine.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The version number. Byte 3 gives the major version number, byte 2 the minor version number, and the low-order 16 bits give the build number.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getversion
		// HRESULT GetVersion( [out, retval] long *pValue );
		int GetVersion();

		/// <summary>Gets the handle of the window that the Text Object Model (TOM) engine is using to display output.</summary>
		/// <returns>
		///   <para>Type: <c>__int64*</c></para>
		///   <para>The handle of the window that the TOM engine is using.</para>
		/// </returns>
		/// <remarks>
		///   <para>A rich edit control doesn't need to own the window that the TOM engine is using. For example, the rich edit control might be windowless.</para>
		///   <para>The Input Method Editor (IME) needs the handle of the window that is receiving keyboard messages. This method retrieves that handle.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getwindow
		// HRESULT GetWindow( [out, retval] __int64 *pHwnd );
		HWND GetWindow();

		/// <summary>Attaches a new message filter to the edit instance. All window messages that the edit instance receives are forwarded to the message filter.</summary>
		/// <param name="pFilter">
		///   <para>Type: <c>IUnknown*</c></para>
		///   <para>The message filter.</para>
		/// </param>
		/// <remarks>The message filter must be bound to the document before it can be used.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-attachmsgfilter
		// HRESULT AttachMsgFilter( [in] IUnknown *pFilter );
		void AttachMsgFilter([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pFilter);

		/// <summary>Checks whether the number of characters to be added would exceed the maximum text limit.</summary>
		/// <param name="cch">
		///   <para>Type: <c>long</c></para>
		///   <para>The number of characters to be added.</para>
		/// </param>
		/// <param name="pcch">
		///   <para>Type: <c>long*</c></para>
		///   <para>The number of characters that exceed the maximum text limit. This parameter is 0 if the number of characters does not exceed the limit.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-checktextlimit
		// HRESULT CheckTextLimit( [in] long cch, [out] long *pcch );
		void CheckTextLimit(int cch, out int pcch);

		/// <summary>Gets the call manager.</summary>
		/// <returns>
		///   <para>Type: <c>IUnknown**</c></para>
		///   <para>The call manager object.</para>
		/// </returns>
		/// <remarks>The call manager object is opaque to the caller. The Text Object Model (TOM) engine uses the object to handle internal notifications for particular scenarios.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getcallmanager
		// HRESULT GetCallManager( [out, retval] IUnknown **ppVoid );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object GetCallManager();

		/// <summary>Retrieves the client rectangle of the rich edit control.</summary>
		/// <param name="Type">
		///   <para>Type: <c>long</c></para>
		///   <para>The client rectangle retrieval options. It can be a combination of the following values.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomClientCoord</c>
		///       </description>
		///       <description>Retrieve the rectangle in client coordinates. If this value isn't specified, the function retrieves screen coordinates.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomIncludeInset</c>
		///       </description>
		///       <description>Add left and top insets to the left and top coordinates of the client rectangle, and subtract right and bottom insets from the right and bottom coordinates.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomTransform</c>
		///       </description>
		///       <description>Use a world transform (XFORM) provided by the host application to transform the retrieved rectangle coordinates.</description>
		///     </item>
		///   </list>
		/// </param>
		/// <param name="pLeft">
		///   <para>Type: <c>long*</c></para>
		///   <para>The x-coordinate of the upper-left corner of the rectangle.</para>
		/// </param>
		/// <param name="pTop">
		///   <para>Type: <c>long*</c></para>
		///   <para>The y-coordinate of the upper-left corner of the rectangle.</para>
		/// </param>
		/// <param name="pRight">
		///   <para>Type: <c>long*</c></para>
		///   <para>The x-coordinate of the lower-right corner of the rectangle.</para>
		/// </param>
		/// <param name="pBottom">
		///   <para>Type: <c>long*</c></para>
		///   <para>The y-coordinate of the lower-right corner of the rectangle.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getclientrect
		// HRESULT GetClientRect( [in] long Type, [out] long *pLeft, [out] long *pTop, [out] long *pRight, [out] long *pBottom );
		void GetClientRect(tomConstants Type, out int pLeft, out int pTop, out int pRight, out int pBottom);

		/// <summary>Retrieves the color used for special text attributes.</summary>
		/// <param name="Index">
		///   <para>Type: <c>long</c></para>
		///   <para>The index of the color to retrieve. It can be one of the following values.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Index</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>0</description>
		///       <description>Text color.</description>
		///     </item>
		///     <item>
		///       <description>1</description>
		///       <description>RGB(0, 0, 0)</description>
		///     </item>
		///     <item>
		///       <description>2</description>
		///       <description>RGB(0, 0, 255)</description>
		///     </item>
		///     <item>
		///       <description>3</description>
		///       <description>RGB(0, 255, 255)</description>
		///     </item>
		///     <item>
		///       <description>4</description>
		///       <description>RGB(0, 255, 0)</description>
		///     </item>
		///     <item>
		///       <description>5</description>
		///       <description>RGB(255, 0, 255)</description>
		///     </item>
		///     <item>
		///       <description>6</description>
		///       <description>RGB(255, 0, 0)</description>
		///     </item>
		///     <item>
		///       <description>7</description>
		///       <description>RGB(255, 255, 0)</description>
		///     </item>
		///     <item>
		///       <description>8</description>
		///       <description>RGB(255, 255, 255)</description>
		///     </item>
		///     <item>
		///       <description>9</description>
		///       <description>RGB(0, 0, 128)</description>
		///     </item>
		///     <item>
		///       <description>10</description>
		///       <description>RGB(0, 128, 128)</description>
		///     </item>
		///     <item>
		///       <description>11</description>
		///       <description>RGB(0, 128, 0)</description>
		///     </item>
		///     <item>
		///       <description>12</description>
		///       <description>RGB(128, 0, 128)</description>
		///     </item>
		///     <item>
		///       <description>13</description>
		///       <description>RGB(128, 0, 0)</description>
		///     </item>
		///     <item>
		///       <description>14</description>
		///       <description>RGB(128, 128, 0)</description>
		///     </item>
		///     <item>
		///       <description>15</description>
		///       <description>RGB(128, 128, 128)</description>
		///     </item>
		///     <item>
		///       <description>16</description>
		///       <description>RGB(192, 192, 192)</description>
		///     </item>
		///   </list>
		/// </param>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The color that corresponds to the specified index.</para>
		/// </returns>
		/// <remarks>The first 16 index values are for special underline colors. If an index between 1 and 16 hasn't been defined by a call to the ITextDocument2:SetEffectColor method, <c>GetEffectColor</c> returns the corresponding Microsoft Word default color.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-geteffectcolor
		// HRESULT GetEffectColor( [in] long Index, [out] long *pValue );
		COLORREF GetEffectColor(int Index);

		/// <summary>Gets the Input Method Manager (IMM) input context from the Text Object Model (TOM) host.</summary>
		/// <returns>
		///   <para>Type: <c>__int64*</c></para>
		///   <para>The IMM input context.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getimmcontext
		// HRESULT GetImmContext( [out, retval] __int64 *pContext );
		int GetImmContext();

		/// <summary>Retrieves the preferred font for a particular character repertoire and character position.</summary>
		/// <param name="cp">
		///   <para>Type: <c>long</c></para>
		///   <para>The character position for the preferred font.</para>
		/// </param>
		/// <param name="CharRep">
		///   <para>Type: <c>long</c></para>
		///   <para>The character repertoire index for the preferred font. It can be one of the following values.</para>
		///   <para>tomAboriginal</para>
		///   <para>tomAnsi</para>
		///   <para>tomArabic</para>
		///   <para>tomArmenian</para>
		///   <para>tomBaltic</para>
		///   <para>tomBengali</para>
		///   <para>tomBIG5</para>
		///   <para>tomBraille</para>
		///   <para>tomCherokee</para>
		///   <para>tomCyrillic</para>
		///   <para>tomDefaultCharRep</para>
		///   <para>tomDevanagari</para>
		///   <para>tomEastEurope</para>
		///   <para>tomEmoji</para>
		///   <para>tomEthiopic</para>
		///   <para>tomGB2312</para>
		///   <para>tomGeorgian</para>
		///   <para>tomGreek</para>
		///   <para>tomGujarati</para>
		///   <para>tomGurmukhi</para>
		///   <para>tomHangul</para>
		///   <para>tomHebrew</para>
		///   <para>tomJamo</para>
		///   <para>tomKannada</para>
		///   <para>tomKayahli</para>
		///   <para>tomKharoshthi</para>
		///   <para>tomKhmer</para>
		///   <para>tomLao</para>
		///   <para>tomLimbu</para>
		///   <para>tomMac</para>
		///   <para>tomMalayalam</para>
		///   <para>tomMongolian</para>
		///   <para>tomMyanmar</para>
		///   <para>tomNewTaiLu</para>
		///   <para>tomOEM</para>
		///   <para>tomOgham</para>
		///   <para>tomOriya</para>
		///   <para>tomPC437</para>
		///   <para>tomRunic</para>
		///   <para>tomShiftJIS</para>
		///   <para>tomSinhala</para>
		///   <para>tomSylotinagr</para>
		///   <para>tomSymbol</para>
		///   <para>tomSyriac</para>
		///   <para>tomTaiLe</para>
		///   <para>tomTamil</para>
		///   <para>tomTelugu</para>
		///   <para>tomThaana</para>
		///   <para>tomThai</para>
		///   <para>tomTibetan</para>
		///   <para>tomTurkish</para>
		///   <para>tomUsymbol</para>
		///   <para>tomVietnamese</para>
		///   <para>tomYi</para>
		/// </param>
		/// <param name="Options">
		///   <para>Type: <c>long</c></para>
		///   <para>The preferred font options. The low-order word can be a combination of the following values.</para>
		///   <para>tomIgnoreCurrentFont</para>
		///   <para>tomMatchCharRep</para>
		///   <para>tomMatchFontSignature</para>
		///   <para>tomMatchAscii</para>
		///   <para>tomGetHeightOnly</para>
		///   <para>tomMatchMathFont</para>
		///   <para>If the high-order word of <c>Options</c> is tomUseTwips, the font heights are given in twips.</para>
		/// </param>
		/// <param name="curCharRep">
		///   <para>Type: <c>long</c></para>
		///   <para>The index of the current character repertoire.</para>
		/// </param>
		/// <param name="curFontSize">
		///   <para>Type: <c>long</c></para>
		///   <para>The current font size.</para>
		/// </param>
		/// <param name="pbstr">
		///   <para>Type: <c>BSTR*</c></para>
		///   <para>The name of the font.</para>
		/// </param>
		/// <param name="pPitchAndFamily">
		///   <para>Type: <c>long*</c></para>
		///   <para>The font pitch and family.</para>
		/// </param>
		/// <param name="pNewFontSize">
		///   <para>Type: <c>long*</c></para>
		///   <para>The new font size.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getpreferredfont HRESULT GetPreferredFont( [in] long
		// cp, [in] long CharRep, [in] long Options, [in] long curCharRep, [in] long curFontSize, [out] BSTR *pbstr, [out] long
		// *pPitchAndFamily, [out] long *pNewFontSize );
		void GetPreferredFont(int cp, tomConstants CharRep, tomConstants Options, int curCharRep, int curFontSize,
			[MarshalAs(UnmanagedType.BStr)] out string pbstr, out int pPitchAndFamily, out int pNewFontSize);

		/// <summary>Retrieves the value of a property.</summary>
		/// <param name="Type">
		///   <para>Type: <c>long</c></para>
		///   <para>The identifier of the property to retrieve. It can be one of the following property IDs.</para>
		///   <para>tomCanCopy</para>
		///   <para>tomCanRedo</para>
		///   <para>tomCanUndo</para>
		///   <para>tomDocMathBuild</para>
		///   <para>tomMathInterSpace</para>
		///   <para>tomMathIntraSpace</para>
		///   <para>tomMathLMargin</para>
		///   <para>tomMathPostSpace</para>
		///   <para>tomMathPreSpace</para>
		///   <para>tomMathRMargin</para>
		///   <para>tomMathWrapIndent</para>
		///   <para>tomMathWrapRight</para>
		///   <para>tomUndoLimit</para>
		///   <para>tomEllipsisMode</para>
		///   <para>tomEllipsisState</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The value of the property.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getproperty
		// HRESULT GetProperty( [in] long Type, [out] long *pValue );
		int GetProperty(tomConstants Type);

		/// <summary>Gets a collection of rich-text strings.</summary>
		/// <returns>
		///   <para>Type: <c>ITextStrings**</c></para>
		///   <para>The collection of rich-text strings.</para>
		/// </returns>
		/// <remarks>The collection is useful for manipulating rich text, particularly for transforming mathematical text from linear to built-up form, or vice versa.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getstrings
		// HRESULT GetStrings( [out] ITextStrings **ppStrs );
		ITextStrings GetStrings();

		/// <summary>Notifies the Text Object Model (TOM) engine client of particular Input Method Editor (IME) events.</summary>
		/// <param name="Notify">
		///   <para>Type: <c>long</c></para>
		///   <para>An IME notification code.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-notify
		// HRESULT Notify( [in] long Notify );
		void Notify(int Notify);

		/// <summary>Retrieves a new text range for the active story of the document.</summary>
		/// <param name="cpActive">
		///   <para>Type: <c>long</c></para>
		///   <para>The active end of the new text range. The default value is 0; that is, the beginning of the story.</para>
		/// </param>
		/// <param name="cpAnchor">
		///   <para>Type: <c>long</c></para>
		///   <para>The anchor end of the new text range. The default value is 0.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>ITextRange2**</c></para>
		///   <para>The new text range.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-range2
		// HRESULT Range2( [in] long cpActive, [in] long cpAnchor, [out, retval] ITextRange2 **ppRange );
		ITextRange2 Range2(int cpActive, int cpAnchor);

		/// <summary>Retrieves the degenerate range at (or nearest to) a particular point on the screen.</summary>
		/// <param name="x">
		///   <para>Type: <c>long</c></para>
		///   <para>The x-coordinate of a point, in screen coordinates.</para>
		/// </param>
		/// <param name="y">
		///   <para>Type: <c>long</c></para>
		///   <para>The y-coordinate of a point, in screen coordinates.</para>
		/// </param>
		/// <param name="Type">
		///   <para>Type: <c>long</c></para>
		///   <para>The alignment type of the specified point. For a list of valid values, see ITextRange::GetPoint.</para>
		/// </param>
		/// <returns>Type: <c>ITextRange2**</c></returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-rangefrompoint2
		// HRESULT RangeFromPoint2( [in] long x, [in] long y, [in] long Type, [out, retval] ITextRange2 **ppRange );
		ITextRange2 RangeFromPoint2(int x, int y, int Type);

		/// <summary>Releases the call manager.</summary>
		/// <param name="pVoid">
		///   <para>Type: <c>IUnknown*</c></para>
		///   <para>The call manager object to release.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-releasecallmanager
		// HRESULT ReleaseCallManager( [in] IUnknown *pVoid );
		void ReleaseCallManager([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pVoid);

		/// <summary>Releases an Input Method Manager (IMM) input context.</summary>
		/// <param name="Context">
		///   <para>Type: <c>int64</c></para>
		///   <para>The IMM input context to release.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-releaseimmcontext
		// HRESULT ReleaseImmContext( [in] __int64 Context );
		void ReleaseImmContext(int Context);

		/// <summary>Specifies the color to use for special text attributes.</summary>
		/// <param name="Index">
		///   <para>Type: <c>long</c></para>
		///   <para>The index of the color to retrieve. For a list of values, see GetEffectColor.</para>
		/// </param>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The new color for the specified index.</para>
		/// </param>
		/// <remarks>The first 16 index values are for special underline colors. If an index between 1 and 16 hasn't been defined by a call to the <c>ITextDocument2:SetEffectColor</c> method, the corresponding Microsoft Word default color is used.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-seteffectcolor
		// HRESULT SetEffectColor( [in] long Index, [in] long Value );
		void SetEffectColor(int Index, COLORREF Value);

		/// <summary>Specifies a new value for a property.</summary>
		/// <param name="Type">
		/// <para>Type: <c>long</c></para>
		/// <para>The identifier of the property. For a list of possible property identifiers, see GetProperty.</para>
		/// </param>
		/// <param name="Value">
		/// <para>Type: <c>long</c></para>
		/// <para>The new property value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>NOERROR</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-setproperty
		// HRESULT SetProperty( [in] long Type, [in] long Value );
		void SetProperty(int Type, int Value);

		/// <summary>Specifies the typography options for the document.</summary>
		/// <param name="Options">
		///   <para>Type: <c>long</c></para>
		///   <para>The typography options to set. For a list of possible options, see GetTypographyOptions.</para>
		/// </param>
		/// <param name="Mask">
		///   <para>Type: <c>long</c></para>
		///   <para>A mask identifying the options to set. For example, to turn on <c>TO_ADVANCEDTYPOGRAPHY</c>, call <c>ITextDocument2::SetTypographyOptions (TO_ADVANCEDTYPOGRAPHY, TO_ADVANCEDTYPOGRAPHY)</c>.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-settypographyoptions
		// HRESULT SetTypographyOptions( [in] long Options, [in] long Mask );
		void SetTypographyOptions(int Options, int Mask);

		/// <summary>Generates a system beep.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-sysbeep
		// HRESULT SysBeep();
		void SysBeep();

		/// <summary>Updates the selection and caret.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>Scroll flag. Use <c>tomTrue</c> to scroll the caret into view.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-update
		// HRESULT Update( [in] long Value );
		void Update(tomConstants Value);

		/// <summary>Notifies the client that the view has changed and the client should update the view if the Text Object Model (TOM) engine is in-place active.</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-updatewindow
		// HRESULT UpdateWindow();
		void UpdateWindow();

		/// <summary>Gets the math properties for the document.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A combination of the following math properties.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Property</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomMathDispAlignMask</c>
		///       </description>
		///       <description>Display-mode alignment mask.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathDispAlignCenter</c>
		///       </description>
		///       <description>Center (default) alignment.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathDispAlignLeft</c>
		///       </description>
		///       <description>Left alignment.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathDispAlignRight</c>
		///       </description>
		///       <description>Right alignment.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathDispIntUnderOver</c>
		///       </description>
		///       <description>Display-mode integral limits location.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathDispFracTeX</c>
		///       </description>
		///       <description>Display-mode nested fraction script size.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathDispNaryGrow</c>
		///       </description>
		///       <description>Math-paragraph n-ary grow.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathDocEmptyArgMask</c>
		///       </description>
		///       <description>Empty arguments display mask.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathDocEmptyArgAuto </c>
		///       </description>
		///       <description>Automatically use a dotted square to denote empty arguments, if necessary.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathDocEmptyArgAlways</c>
		///       </description>
		///       <description>Always use a dotted square to denote empty arguments..</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathDocEmptyArgNever</c>
		///       </description>
		///       <description>Don't denote empty arguments.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathDocSbSpOpUnchanged</c>
		///       </description>
		///       <description>Display the underscore (_) and caret (^) as themselves.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathDocDiffMask</c>
		///       </description>
		///       <description>Style mask for the <c>tomMathDocDiffUpright</c>, <c>tomMathDocDiffItalic</c>, <c>tomMathDocDiffOpenItalic </c> options.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathDocDiffItalic</c>
		///       </description>
		///       <description>Use italic (default) for math differentials.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathDocDiffUpright</c>
		///       </description>
		///       <description>Use an upright font for math differentials.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathDocDiffOpenItalic</c>
		///       </description>
		///       <description>Use open italic (default) for math differentials.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathDispNarySubSup</c>
		///       </description>
		///       <description>Math-paragraph non-integral n-ary limits location.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathDispDef</c>
		///       </description>
		///       <description>Math-paragraph spacing defaults.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathEnableRtl</c>
		///       </description>
		///       <description>Enable right-to-left (RTL) math zones in RTL paragraphs.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathBrkBinMask</c>
		///       </description>
		///       <description>Equation line break mask.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathBrkBinBefore</c>
		///       </description>
		///       <description>Break before binary/relational operator.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathBrkBinAfter</c>
		///       </description>
		///       <description>Break after binary/relational operator.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathBrkBinDup</c>
		///       </description>
		///       <description>Duplicate binary/relational before/after.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathBrkBinSubMask</c>
		///       </description>
		///       <description>Duplicate mask for minus operator.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathBrkBinSubMM</c>
		///       </description>
		///       <description>- - (minus on both lines).</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathBrkBinSubPM</c>
		///       </description>
		///       <description>+ -</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMathBrkBinSubMP</c>
		///       </description>
		///       <description>- +</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getmathproperties
		// HRESULT GetMathProperties( [out] long *pOptions );
		tomConstants GetMathProperties();

		/// <summary>Specifies the math properties to use for the document.</summary>
		/// <param name="Options">
		///   <para>Type: <c>long</c></para>
		///   <para>The math properties to set. For a list of possible properties, see GetMathProperties.</para>
		/// </param>
		/// <param name="Mask">
		///   <para>Type: <c>long</c></para>
		///   <para>The math mask. For a list of possible masks, see GetMathProperties</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-setmathproperties
		// HRESULT SetMathProperties( [in] long Options, [in] long Mask );
		void SetMathProperties(tomConstants Options, tomConstants Mask);

		/// <summary>Gets the active story; that is, the story that receives keyboard and mouse input.</summary>
		/// <returns>
		///   <para>Type: <c>ITextStory**</c></para>
		///   <para>The active story.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getactivestory
		// HRESULT GetActiveStory( [out, retval] ITextStory **ppStory );
		ITextStory GetActiveStory();

		/// <summary>Sets the active story; that is, the story that receives keyboard and mouse input.</summary>
		/// <param name="pStory">
		///   <para>Type: <c>ITextStory*</c></para>
		///   <para>The story to set as active.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-setactivestory
		// HRESULT SetActiveStory( [in] ITextStory *pStory );
		void SetActiveStory([In, Optional] ITextStory? pStory);

		/// <summary>Gets the main story.</summary>
		/// <returns>
		///   <para>Type: <c>ITextStory**</c></para>
		///   <para>The main story.</para>
		/// </returns>
		/// <remarks>A rich edit control automatically includes the main story; a call to the ITextDocument2::GetNewStory method is not required.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getmainstory
		// HRESULT GetMainStory( [out, retval] ITextStory **ppStory );
		ITextStory GetMainStory();

		/// <summary>
		///   <para>Not implemented.</para>
		///   <para>Gets a new story.</para>
		/// </summary>
		/// <returns>
		///   <para>Type: <c>ITextStory**</c></para>
		///   <para>The new story.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getnewstory
		// HRESULT GetNewStory( [out, retval] ITextStory **ppStory );
		ITextStory GetNewStory();

		/// <summary>Retrieves the story that corresponds to a particular index.</summary>
		/// <param name="Index">
		///   <para>Type: <c>long</c></para>
		///   <para>The index of the story to retrieve.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>ITextStory**</c></para>
		///   <para>The story.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextdocument2-getstory
		// HRESULT GetStory( [in] long Index, [out, retval] ITextStory **ppStory );
		ITextStory GetStory(int Index);
	}

	/// <summary>Text Object Model (TOM) rich text-range attributes are accessed through a pair of dual interfaces, <c>ITextFont</c> and ITextPara.</summary>
	/// <remarks>
	/// <para>The <c>ITextFont</c> and ITextPara interfaces encapsulate the functionality of the Microsoft Word Format <c>Font</c> and <c>Paragraph</c> dialog boxes, respectively. Both interfaces include a duplicate (<c>Value</c>) property that can return a duplicate of the attributes in a range object or transfer a set of attributes to a range. As such, they act like programmable format painters. For example, you could transfer all attributes from range r1 to range r2 except for making r2 bold and the font size 12 points by using the following subroutine.</para>
	/// <para>See SetFont for a similar example written in C++.</para>
	/// <para>The <c>ITextFont</c> attribute interface represents the traditional Microsoft Visual Basic for Applications (VBA) way of setting properties and it gives the desired VBA notation.</para>
	/// <para><c>ITextFont</c> uses the "tomBool" type for rich-text attributes that have binary states. For more information, see The tomBool Type.</para>
	/// <para>The rich edit control is able to accept and return all <c>ITextFont</c> properties intact, that is, without modification, both through TOM and through its Rich Text Format (RTF) converters. However, it cannot display the All Caps, Animation, Embossed, Imprint, Shadow, Small Caps, Hidden, Kerning, Outline, and Style font properties.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextfont
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextFont")]
	[ComImport, Guid("8CC497C3-A1DF-11ce-8098-00AA0047BE5D"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ITextFont
	{
		/// <summary>Gets a duplicate of this text font object.</summary>
		/// <returns>
		///   <para>Type: <c>ITextFont**</c></para>
		///   <para>The duplicate text font object.</para>
		/// </returns>
		/// <remarks>
		///   <para>The duplicate property is the default property of an ITextFont object.</para>
		///   <para>For an example of how to use font duplicates, see SetFont.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getduplicate
		// HRESULT GetDuplicate( ITextFont **ppFont );
		ITextFont GetDuplicate();

		/// <summary>Sets the character formatting by copying another text font object.</summary>
		/// <param name="pFont">
		///   <para>Type: <c>ITextFont*</c></para>
		///   <para>The text font object to apply to this font object.</para>
		/// </param>
		/// <remarks>
		///   <para>Values with the <c>tomUndefined</c> attribute have no effect.</para>
		///   <para>For an example of how to use font duplicates, see SetFont.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setduplicate
		// HRESULT SetDuplicate( [in] ITextFont *pFont );
		void SetDuplicate([In, Optional] ITextFont? pFont);

		/// <summary>Determines whether the font can be changed.</summary>
		/// <param name="pValue">
		/// <para>Type: <c>long*</c></para>
		/// <para>A variable that is <c>tomTrue</c> if the font can be changed or <c>tomFalse</c> if it cannot be changed. This parameter can be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the font can change, the method returns <c>S_OK</c>. If the method fails, it returns the following COM error code. For more information about COM error codes, see Error Handling in COM.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_FALSE</c></description>
		/// <description>The font cannot change.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>The *<c>pbCanChange</c> returns <c>tomTrue</c> only if the font can be changed. That is, no part of an associated range is protected and an associated document is not read-only. If this ITextFont object is a duplicate, no protection rules apply.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-canchange
		// HRESULT CanChange( [retval] long *pValue );
		[PreserveSig]
		HRESULT CanChange(out tomConstants pValue);

		/// <summary>Determines whether this text font object has the same properties as the specified text font object.</summary>
		/// <param name="pFont">
		/// <para>Type: <c>ITextFont*</c></para>
		/// <para>The text font object to compare against.</para>
		/// </param>
		/// <param name="pValue">
		/// <para>Type: <c>long*</c></para>
		/// <para>
		/// A variable that is <c>tomTrue</c> if the font objects have the same properties or <c>tomFalse</c> if they do not. This parameter
		/// can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// If the text font objects have the same properties, the method succeeds and returns <c>S_OK</c>. If the text font objects do not
		/// have the same properties, the method fails and returns <c>S_FALSE</c>. For more information about COM error codes, see Error
		/// Handling in COM.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The text font objects are equal only if <c>pFont</c> belongs to the same Text Object Model (TOM) object as the current font
		/// object. The <c>ITextFont::IsEqual</c> method ignores entries for which either font object has an tomUndefined.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-isequal
		// HRESULT IsEqual( ITextFont *pFont, long *pValue );
		[PreserveSig]
		HRESULT IsEqual([In, Optional] ITextFont? pFont, out tomConstants pValue);

		/// <summary>Resets the character formatting to the specified values.</summary>
		/// <param name="Value">
		/// <para>Type: <c>long</c></para>
		/// <para>The kind of reset. This parameter can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>tomDefault</c></description>
		/// <description>Set to the document default character format if this font object is attached to a range; otherwise, set the defaults to the basic TOM engine defaults.</description>
		/// </item>
		/// <item>
		/// <description><c>tomUndefined</c></description>
		/// <description>Sets all properties to undefined values. This value is valid only for a duplicate (clone) font object.</description>
		/// </item>
		/// <item>
		/// <description><c>tomApplyLater</c></description>
		/// <description>Allow property values to be set, but donât apply them to the attached range yet.</description>
		/// </item>
		/// <item>
		/// <description><c>tomApplyNow</c></description>
		/// <description>Apply the current properties to attached range.</description>
		/// </item>
		/// <item>
		/// <description><c>tomCacheParms</c></description>
		/// <description>Do not update the current font with the attached range properties.</description>
		/// </item>
		/// <item>
		/// <description><c>tomTrackParms</c></description>
		/// <description>Update the current font with the attached range properties.</description>
		/// </item>
		/// <item>
		/// <description><c>tomApplyTmp</c></description>
		/// <description>Apply temporary formatting.</description>
		/// </item>
		/// <item>
		/// <description><c>tomDisableSmartFont</c></description>
		/// <description>Do not apply smart fonts.</description>
		/// </item>
		/// <item>
		/// <description><c>tomEnableSmartFont</c></description>
		/// <description>Do apply smart fonts.</description>
		/// </item>
		/// <item>
		/// <description><c>tomUsePoints</c></description>
		/// <description>Use points for floating-point measurements.</description>
		/// </item>
		/// <item>
		/// <description><c>tomUseTwips</c></description>
		/// <description>Use twips for floating-point measurements.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If the method fails, it returns one of the following COM error codes. For more information about COM error codes, see Error Handling in COM.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_FALSE</c></description>
		/// <description>Protected from change.</description>
		/// </item>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>Invalid argument.</description>
		/// </item>
		/// <item>
		/// <description><c>CO_E_RELEASED</c></description>
		/// <description>The font object is attached to a range that has been deleted.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>Calling <c>ITextFont::Reset</c> with <c>tomUndefined</c> sets all properties to undefined values. Thus, applying the font object to a range changes nothing. This applies to a font object that is obtained by the ITextFont::GetDuplicate method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-reset
		// HRESULT Reset( [in] long Value );
		void Reset(tomConstants Value);

		/// <summary>Gets the character style handle of the characters in a range.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The character style handle.</para>
		/// </returns>
		/// <remarks>The Text Object Model (TOM) version 1.0 does not specify the meanings of the style handles. The meanings depend on other facilities of the text system that implements TOM.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getstyle
		// HRESULT GetStyle( long *pValue );
		int GetStyle();

		/// <summary>Sets the character style handle of the characters in a range.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The new character style handle.</para>
		/// </param>
		/// <remarks>The Text Object Model (TOM) version 1.0 does not specify the meanings of the style handles. The meanings depend on other facilities of the text system that implements TOM.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setstyle
		// HRESULT SetStyle( [in] long Value );
		void SetStyle(int Value);

		/// <summary>Gets whether the characters are all uppercase.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are all uppercase.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not all uppercase.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The AllCaps property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_ALLCAPS</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getallcaps
		// HRESULT GetAllCaps( long *pValue );
		tomConstants GetAllCaps();

		/// <summary>Sets whether the characters are all uppercase.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are all uppercase.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not all uppercase.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the AllCaps property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The AllCaps property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setallcaps
		// HRESULT SetAllCaps( [in] long Value );
		void SetAllCaps(tomConstants Value);

		/// <summary>Gets the animation type.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>One of the following animation types.</para>
		///   <para>tomNoAnimation tomLasVegasLights tomBlinkingBackground tomSparkleText tomMarchingBlackAnts tomMarchingRedAnts tomShimmer tomWipeDown tomWipeRight</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getanimation
		// HRESULT GetAnimation( long *pValue );
		tomConstants GetAnimation();

		/// <summary>Sets the animation type.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The animation type. It can be one of the following values.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Animation type</description>
		///       <description>Value</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomNoAnimation</c>
		///       </description>
		///       <description>0</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomLasVegasLights</c>
		///       </description>
		///       <description>1</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomBlinkingBackground</c>
		///       </description>
		///       <description>2</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomSparkleText</c>
		///       </description>
		///       <description>3</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMarchingBlackAnts</c>
		///       </description>
		///       <description>4</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMarchingRedAnts</c>
		///       </description>
		///       <description>5</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomShimmer</c>
		///       </description>
		///       <description>6</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomWipeDown</c>
		///       </description>
		///       <description>7</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomWipeRight</c>
		///       </description>
		///       <description>8</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setanimation
		// HRESULT SetAnimation( [in] long Value );
		void SetAnimation(tomConstants Value);

		/// <summary>Gets the text background (highlight) color.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The text background color. It can be one of the following values.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>A <see cref="COLORREF" /> value</description>
		///       <description>The high-order byte is zero, and the three low-order bytes specify an RGB color.</description>
		///     </item>
		///     <item>
		///       <description>A value returned by PALETTEINDEX</description>
		///       <description>The high-order byte is 1, and the LOWORD specifies the index of a logical-color palette entry.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomAutocolor</c> (-9999997)</description>
		///       <description>Indicates the range uses the default system background color.</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getbackcolor
		// HRESULT GetBackColor( long *pValue );
		int GetBackColor();

		/// <summary>Sets the background color.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The new background color. It can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>A COLORREF value.</description>
		///       <description>An RGB color.</description>
		///     </item>
		///     <item>
		///       <description>A value returned by PALETTEINDEX</description>
		///       <description>A palette index.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>No change.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomAutoColor</c>
		///       </description>
		///       <description>Use the default background color.</description>
		///     </item>
		///   </list>
		///   <para>If <c>Value</c> contains an RGB color, generate the COLORREF by using the RGB macro.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setbackcolor
		// HRESULT SetBackColor( [in] long Value );
		void SetBackColor(int Value);

		/// <summary>Gets whether the characters are bold.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are bold.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not bold.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Bold property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>You can use the ITextFont::SetWeight and ITextFont::GetWeight methods to set or retrieve the font weight more precisely than the ITextFont::SetBold and <c>ITextFont::GetBold</c> methods.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getbold
		// HRESULT GetBold( long *pValue );
		tomConstants GetBold();

		/// <summary>Sets whether characters are bold.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are bold.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not bold.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Bold property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Bold property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setbold
		// HRESULT SetBold( [in] long Value );
		void SetBold(tomConstants Value);

		/// <summary>Gets whether characters are embossed.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are embossed.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not embossed.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Emboss property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_EMBOSS</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getemboss
		// HRESULT GetEmboss( long *pValue );
		tomConstants GetEmboss();

		/// <summary>Sets whether characters are embossed.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are embossed.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not embossed.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Emboss property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Emboss property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setemboss
		// HRESULT SetEmboss( [in] long Value );
		void SetEmboss(tomConstants Value);

		/// <summary>Gets the foreground, or text, color.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The foreground color. It can be one of the following values.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>A COLORREF value</description>
		///       <description>The high-order byte is zero, and the three low-order bytes specify an RGB color.</description>
		///     </item>
		///     <item>
		///       <description>A value returned by PALETTEINDEX</description>
		///       <description>The high-order byte is 1, and the LOWORD specifies the index of a logical-color palette entry.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomAutocolor</c> (-9999997)</description>
		///       <description>Indicates that the range uses the default system foreground color.</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getforecolor
		// HRESULT GetForeColor( long *pValue );
		int GetForeColor();

		/// <summary>Sets the foreground (text) color.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The new foreground color. It can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>A COLORREF value.</description>
		///       <description>An RGB color.</description>
		///     </item>
		///     <item>
		///       <description>A value returned by PALETTEINDEX</description>
		///       <description>A palette index.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>No change.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomAutoColor</c>
		///       </description>
		///       <description>Use the default foreground color.</description>
		///     </item>
		///   </list>
		///   <para>Â</para>
		///   <para>If <c>Value</c> contains an RGB color, generate the COLORREF by using the RGB macro.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setforecolor
		// HRESULT SetForeColor( [in] long Value );
		void SetForeColor(int Value);

		/// <summary>Gets whether characters are hidden.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are hidden.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not hidden.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Hidden property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_HIDDEN</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-gethidden
		// HRESULT GetHidden( long *pValue );
		tomConstants GetHidden();

		/// <summary>Sets whether characters are hidden.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are hidden.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not hidden.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Hidden property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Hidden property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-sethidden
		// HRESULT SetHidden( [in] long Value );
		void SetHidden(tomConstants Value);

		/// <summary>Gets whether characters are displayed as imprinted characters.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed as imprinted characters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed as imprinted characters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Engrave property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_IMPRINT</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getengrave
		// HRESULT GetEngrave( long *pValue );
		tomConstants GetEngrave();

		/// <summary>Sets whether characters are displayed as imprinted characters.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are imprinted.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not imprinted.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Engrave property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Engrave property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setengrave
		// HRESULT SetEngrave( [in] long Value );
		void SetEngrave(tomConstants Value);

		/// <summary>Gets whether characters are in italics.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are in italics.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not in italics.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Italic property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getitalic
		// HRESULT GetItalic( long *pValue );
		tomConstants GetItalic();

		/// <summary>Sets whether characters are in italics.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are in italics.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not in italics.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Italic property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Italic property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setitalic
		// HRESULT SetItalic( [in] long Value );
		void SetItalic(tomConstants Value);

		/// <summary>Gets the minimum font size at which kerning occurs.</summary>
		/// <returns>
		///   <para>Type: <c>float*</c></para>
		///   <para>The minimum font size at which kerning occurs, in floating-point points.</para>
		/// </returns>
		/// <remarks>If the value pointed to by <c>pValue</c> is zero, kerning is off. Positive values turn on pair kerning for font point sizes greater than or equal to the kerning value. For example, the value 1 turns on kerning for all legible sizes, whereas 16 turns on kerning only for font sizes of 16 points and larger.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getkerning
		// HRESULT GetKerning( float *pValue );
		float GetKerning();

		/// <summary>Sets the minimum font size at which kerning occurs.</summary>
		/// <param name="Value">
		///   <para>Type: <c>float</c></para>
		///   <para>The new value of the minimum kerning size, in floating-point points.</para>
		/// </param>
		/// <remarks>If this value is zero, kerning is turned off. Positive values turn on pair kerning for font sizes greater than this kerning value. For example, the value 1 turns on kerning for all legible sizes, whereas 16 turns on kerning only for font sizes of 16 points and larger.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setkerning
		// HRESULT SetKerning( [in] float Value );
		void SetKerning(float Value);

		/// <summary>Gets the language ID or language code identifier (LCID).</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The language ID or LCID. The low word contains the language identifier. The high word is either zero or it contains the high word of the LCID. To retrieve the language identifier, mask out the high word. For more information, see Locale Identifiers.</para>
		/// </returns>
		/// <remarks>To get the BCP-47 language tag, such as "en-US", call <c>ITextRange2::GetText2(pBstr, tomLanguageTag)</c>, where <c>pBstr</c> specifies the desired language tag.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getlanguageid
		// HRESULT GetLanguageID( long *pValue );
		LCID GetLanguageID();

		/// <summary>Sets the language ID or language code identifier (LCID).</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The new language identifier. The low word contains the language identifier. The high word is either zero or it contains the high word of the locale identifier LCID. For more information, see Locale Identifiers.</para>
		/// </param>
		/// <remarks>
		///   <para>If the high nibble of <c>Value</c> is tomCharset, set the <c>charrep</c> from the <c>charset</c> in the low byte and the pitch and family from the next byte. See also ITextFont2::SetCharRep.</para>
		///   <para>If the high nibble of <c>Value</c> is tomCharRepFromLcid, set the <c>charrep</c> from the LCID and set the LCID as well. See ITextFont::GetLanguageID for more information.</para>
		///   <para>To set the BCP-47 language tag, such as "en-US", call ITextRange2::SetText2 and set the tomLanguageTag and <c>bstr</c> with the language tag.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setlanguageid
		// HRESULT SetLanguageID( [in] long Value );
		void SetLanguageID(LCID Value);

		/// <summary>Gets the font name.</summary>
		/// <returns>
		///   <para>Type: <c>BSTR*</c></para>
		///   <para>The font name.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getname
		// HRESULT GetName( BSTR *pbstr );
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetName();

		/// <summary>Sets the font name.</summary>
		/// <param name="bstr">
		///   <para>Type: <c>BSTR</c></para>
		///   <para>The new font name.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setname
		// HRESULT SetName( [in] BSTR bstr );
		void SetName([MarshalAs(UnmanagedType.BStr)] string bstr);

		/// <summary>Gets whether characters are displayed as outlined characters.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed as outlined characters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed as outlined characters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Outline property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_OUTLINE</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getoutline
		// HRESULT GetOutline( long *pValue );
		tomConstants GetOutline();

		/// <summary>Sets whether characters are displayed as outlined characters.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are outlined.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not outlined.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Outline property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Outline property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setoutline
		// HRESULT SetOutline( [in] long Value );
		void SetOutline(tomConstants Value);

		/// <summary>Gets the amount that characters are offset vertically relative to the baseline.</summary>
		/// <returns>
		///   <para>Type: <c>float*</c></para>
		///   <para>The amount of vertical offset, in floating-point points.</para>
		/// </returns>
		/// <remarks>Displayed text typically has a zero value for this property. Positive values raise the text, and negative values lower it.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getposition
		// HRESULT GetPosition( float *pValue );
		float GetPosition();

		/// <summary>Sets the amount that characters are offset vertically relative to the baseline.</summary>
		/// <param name="Value">
		///   <para>Type: <c>float</c></para>
		///   <para>The new amount of vertical offset, in floating-point points.</para>
		/// </param>
		/// <remarks>Displayed text typically has a zero value for this property. Positive values raise the text, and negative values lower it.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setposition
		// HRESULT SetPosition( [in] float Value );
		void SetPosition(float Value);

		/// <summary>Gets whether characters are protected against attempts to modify them.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are protected.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not protected.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Protected property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>In general, Text Object Model (TOM) methods that attempt to change the formatting or content of a range fail with <c>E_ACCESSDENIED</c> if any part of that range is protected, or if the document is read only. To make a change in protected text, the TOM client should attempt to turn off the protection of the text to be modified. The owner of the document may permit this to happen. For example in rich edit controls, attempts to change protected text result in an EN_PROTECTED notification code to the creator of the document, who then can refuse or grant permission for the change. The creator is the client that created a windowed rich edit control through the CreateWindow function or the ITextHost object that called the CreateTextServices function to create a windowless rich edit control.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getprotected
		// HRESULT GetProtected( long *pValue );
		tomConstants GetProtected();

		/// <summary>Sets whether characters are protected against attempts to modify them.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are protected.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not protected.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Protected property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Protected property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		/// <remarks>In general, Text Object Model (TOM) methods that attempt to change the formatting or content of a range will fail with <c>E_ACCESSDENIED</c> if any part of that range is protected or if the document is read-only. To make a change in protected text, the TOM client should attempt to turn off the protection of the text to be modified. The owner of the document may permit this to happen. For example in rich edit controls, attempts to change protected text result in an EN_PROTECTED notification code to the creator of the document, who then can refuse or grant permission for the change. The creator is the client that created a windowed rich-edit control through the CreateWindow function or the ITextHost object that called the CreateTextServices function to create a windowless rich edit control.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setprotected
		// HRESULT SetProtected( [in] long Value );
		void SetProtected(tomConstants Value);

		/// <summary>Gets whether characters are displayed as shadowed characters.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed as shadowed characters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed as shadowed characters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Shadow property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_SHADOW</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getshadow
		// HRESULT GetShadow( long *pValue );
		tomConstants GetShadow();

		/// <summary>Sets whether characters are displayed as shadowed characters.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are shadowed.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not shadowed.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Shadow property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Shadow property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setshadow
		// HRESULT SetShadow( [in] long Value );
		void SetShadow(tomConstants Value);

		/// <summary>Gets the font size.</summary>
		/// <returns>
		///   <para>Type: <c>float*</c></para>
		///   <para>The font size, in floating-point points.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getsize
		// HRESULT GetSize( float *pValue );
		float GetSize();

		/// <summary>Sets the font size.</summary>
		/// <param name="Value">
		///   <para>Type: <c>float</c></para>
		///   <para>The new font size, in floating-point points.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setsize
		// HRESULT SetSize( [in] float Value );
		void SetSize(float Value);

		/// <summary>Gets whether characters are in small capital letters.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are in small capital letters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not in small capital letters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The SmallCaps property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_SMALLCAPS</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getsmallcaps
		// HRESULT GetSmallCaps( long *pValue );
		tomConstants GetSmallCaps();

		/// <summary>Sets whether characters are in small capital letters.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are in small capital letters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not in small capital letters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the SmallCaps property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The SmallCaps property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setsmallcaps
		// HRESULT SetSmallCaps( [in] long Value );
		void SetSmallCaps(tomConstants Value);

		/// <summary>Gets the amount of horizontal spacing between characters.</summary>
		/// <returns>
		///   <para>Type: <c>float*</c></para>
		///   <para>The amount of horizontal spacing between characters, in floating-point points.</para>
		/// </returns>
		/// <remarks>Displayed text typically has an intercharacter spacing value of zero. Positive values expand the spacing, and negative values compress it.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getspacing
		// HRESULT GetSpacing( float *pValue );
		float GetSpacing();

		/// <summary>Sets the amount of horizontal spacing between characters.</summary>
		/// <param name="Value">
		///   <para>Type: <c>float</c></para>
		///   <para>The new amount of horizontal spacing between characters, in floating-point points.</para>
		/// </param>
		/// <remarks>Displayed text typically has an intercharacter spacing value of zero. Positive values expand the spacing, and negative values compress it.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setspacing
		// HRESULT SetSpacing( [in] float Value );
		void SetSpacing(float Value);

		/// <summary>Gets whether characters are displayed with a horizontal line through the center.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed with a horizontal line through the center.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed with a horizontal line through the center.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The StrikeThrough property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_STRIKEOUT</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getstrikethrough
		// HRESULT GetStrikeThrough( long *pValue );
		tomConstants GetStrikeThrough();

		/// <summary>Sets whether characters are displayed with a horizontal line through the center.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters have a horizontal line through the center.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters do not have a horizontal line through the center.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the StrikeThrough property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The StrikeThrough property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setstrikethrough
		// HRESULT SetStrikeThrough( [in] long Value );
		void SetStrikeThrough(tomConstants Value);

		/// <summary>Gets whether characters are displayed as subscript.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed as subscript.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed as subscript.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Subscript property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_SUBSCRIPT</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getsubscript
		// HRESULT GetSubscript( long *pValue );
		tomConstants GetSubscript();

		/// <summary>Sets whether characters are displayed as subscript.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed as subscript.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed as subscript.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Subscript property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Subscript property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setsubscript
		// HRESULT SetSubscript( [in] long Value );
		void SetSubscript(tomConstants Value);

		/// <summary>Gets whether characters are displayed as superscript.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed as superscript.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed as superscript.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Superscript property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_SUPERSCRIPT</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getsuperscript
		// HRESULT GetSuperscript( long *pValue );
		tomConstants GetSuperscript();

		/// <summary>Sets whether characters are displayed as superscript.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed as superscript.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed as superscript.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Superscript property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Superscript property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setsuperscript
		// HRESULT SetSuperscript( [in] long Value );
		void SetSuperscript(tomConstants Value);

		/// <summary>Gets the type of underlining for the characters in a range.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The type of underlining. It can be one of the following values.</para>
		///   <para>tomNone</para>
		///   <para>tomSingle</para>
		///   <para>tomWords</para>
		///   <para>tomDouble</para>
		///   <para>tomDotted</para>
		///   <para>tomDash</para>
		///   <para>tomDashDot</para>
		///   <para>tomDashDotDot</para>
		///   <para>tomWave</para>
		///   <para>tomThick</para>
		///   <para>tomHair</para>
		///   <para>tomDoubleWave</para>
		///   <para>tomHeavyWave</para>
		///   <para>tomLongDash</para>
		///   <para>tomThickDash</para>
		///   <para>tomThickDashDot</para>
		///   <para>tomThickDashDotDot</para>
		///   <para>tomThickDotted</para>
		///   <para>tomThickLongDash</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getunderline
		// HRESULT GetUnderline( long *pValue );
		tomConstants GetUnderline();

		/// <summary>Sets thevtype of underlining for the characters in a range.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The type of underlining. It can be one of the following values.</para>
		///   <para>tomNone</para>
		///   <para>tomSingle</para>
		///   <para>tomWords</para>
		///   <para>tomDouble</para>
		///   <para>tomDotted</para>
		///   <para>tomDash</para>
		///   <para>tomDashDot</para>
		///   <para>tomDashDotDot</para>
		///   <para>tomWave</para>
		///   <para>tomThick</para>
		///   <para>tomHair</para>
		///   <para>tomDoubleWave</para>
		///   <para>tomHeavyWave</para>
		///   <para>tomLongDash</para>
		///   <para>tomThickDash</para>
		///   <para>tomThickDashDot</para>
		///   <para>tomThickDashDotDot</para>
		///   <para>tomThickDotted</para>
		///   <para>tomThickLongDash</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setunderline
		// HRESULT SetUnderline( [in] long Value );
		void SetUnderline(tomConstants Value);

		/// <summary>Gets the font weight for the characters in a range.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The font weight. The Bold property is a binary version of the Weight property that sets the weight to <c>FW_BOLD</c>. The font weight exists in the LOGFONT structure and the IFont interface. Windows defines the following degrees of font weight.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Font weight</description>
		///       <description>Value</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>FW_DONTCARE</c>
		///       </description>
		///       <description>0</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_THIN</c>
		///       </description>
		///       <description>100</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_EXTRALIGHT</c>
		///       </description>
		///       <description>200</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_LIGHT</c>
		///       </description>
		///       <description>300</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_NORMAL</c>
		///       </description>
		///       <description>400</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_MEDIUM</c>
		///       </description>
		///       <description>500</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_SEMIBOLD</c>
		///       </description>
		///       <description>600</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_BOLD</c>
		///       </description>
		///       <description>700</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_EXTRABOLD</c>
		///       </description>
		///       <description>800</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_HEAVY</c>
		///       </description>
		///       <description>900</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getweight
		// HRESULT GetWeight( long *pValue );
		int GetWeight();

		/// <summary>Sets the font weight for the characters in a range.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The new font weight. The Bold property is a binary version of the Weight property that sets the weight to <c>FW_BOLD</c>. The font weight exists in the LOGFONT structure and the IFont interface. Windows defines the following degrees of font weight.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Font weight</description>
		///       <description>Value</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>FW_DONTCARE</c>
		///       </description>
		///       <description>0</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_THIN</c>
		///       </description>
		///       <description>100</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_EXTRALIGHT</c>
		///       </description>
		///       <description>200</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_LIGHT</c>
		///       </description>
		///       <description>300</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_NORMAL</c>
		///       </description>
		///       <description>400</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_MEDIUM</c>
		///       </description>
		///       <description>500</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_SEMIBOLD</c>
		///       </description>
		///       <description>600</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_BOLD</c>
		///       </description>
		///       <description>700</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_EXTRABOLD</c>
		///       </description>
		///       <description>800</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_HEAVY</c>
		///       </description>
		///       <description>900</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setweight
		// HRESULT SetWeight( [in] long Value );
		void SetWeight(int Value);
	}

	/// <summary>
	/// <para>In the Text Object Model (TOM), applications access text-range attributes by using a pair of dual interfaces, ITextFont and ITextPara.</para>
	/// <para>The <c>ITextFont2</c> interface extends ITextFont, providing the programming equivalent of the Microsoft Word format-font dialog.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextfont2
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextFont2")]
	[ComImport, Guid("C241F5E3-7206-11D8-A2C7-00A0D1D6C6B3"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ITextFont2 : ITextFont
	{
		/// <summary>Gets a duplicate of this text font object.</summary>
		/// <returns>
		///   <para>Type: <c>ITextFont**</c></para>
		///   <para>The duplicate text font object.</para>
		/// </returns>
		/// <remarks>
		///   <para>The duplicate property is the default property of an ITextFont object.</para>
		///   <para>For an example of how to use font duplicates, see SetFont.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getduplicate
		// HRESULT GetDuplicate( ITextFont **ppFont );
		new ITextFont GetDuplicate();

		/// <summary>Sets the character formatting by copying another text font object.</summary>
		/// <param name="pFont">
		///   <para>Type: <c>ITextFont*</c></para>
		///   <para>The text font object to apply to this font object.</para>
		/// </param>
		/// <remarks>
		///   <para>Values with the <c>tomUndefined</c> attribute have no effect.</para>
		///   <para>For an example of how to use font duplicates, see SetFont.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setduplicate
		// HRESULT SetDuplicate( [in] ITextFont *pFont );
		new void SetDuplicate([In, Optional] ITextFont? pFont);

		/// <summary>Determines whether the font can be changed.</summary>
		/// <param name="pValue">
		/// <para>Type: <c>long*</c></para>
		/// <para>A variable that is <c>tomTrue</c> if the font can be changed or <c>tomFalse</c> if it cannot be changed. This parameter can be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the font can change, the method returns <c>S_OK</c>. If the method fails, it returns the following COM error code. For more information about COM error codes, see Error Handling in COM.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_FALSE</c></description>
		/// <description>The font cannot change.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>The *<c>pbCanChange</c> returns <c>tomTrue</c> only if the font can be changed. That is, no part of an associated range is protected and an associated document is not read-only. If this ITextFont object is a duplicate, no protection rules apply.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-canchange
		// HRESULT CanChange( [retval] long *pValue );
		[PreserveSig]
		new HRESULT CanChange(out tomConstants pValue);

		/// <summary>Determines whether this text font object has the same properties as the specified text font object.</summary>
		/// <param name="pFont">
		/// <para>Type: <c>ITextFont*</c></para>
		/// <para>The text font object to compare against.</para>
		/// </param>
		/// <param name="pValue">
		/// <para>Type: <c>long*</c></para>
		/// <para>
		/// A variable that is <c>tomTrue</c> if the font objects have the same properties or <c>tomFalse</c> if they do not. This parameter
		/// can be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// If the text font objects have the same properties, the method succeeds and returns <c>S_OK</c>. If the text font objects do not
		/// have the same properties, the method fails and returns <c>S_FALSE</c>. For more information about COM error codes, see Error
		/// Handling in COM.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The text font objects are equal only if <c>pFont</c> belongs to the same Text Object Model (TOM) object as the current font
		/// object. The <c>ITextFont::IsEqual</c> method ignores entries for which either font object has an tomUndefined.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-isequal
		// HRESULT IsEqual( ITextFont *pFont, long *pValue );
		[PreserveSig]
		new HRESULT IsEqual([In, Optional] ITextFont? pFont, out tomConstants pValue);

		/// <summary>Resets the character formatting to the specified values.</summary>
		/// <param name="Value">
		/// <para>Type: <c>long</c></para>
		/// <para>The kind of reset. This parameter can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>tomDefault</c></description>
		/// <description>Set to the document default character format if this font object is attached to a range; otherwise, set the defaults to the basic TOM engine defaults.</description>
		/// </item>
		/// <item>
		/// <description><c>tomUndefined</c></description>
		/// <description>Sets all properties to undefined values. This value is valid only for a duplicate (clone) font object.</description>
		/// </item>
		/// <item>
		/// <description><c>tomApplyLater</c></description>
		/// <description>Allow property values to be set, but donât apply them to the attached range yet.</description>
		/// </item>
		/// <item>
		/// <description><c>tomApplyNow</c></description>
		/// <description>Apply the current properties to attached range.</description>
		/// </item>
		/// <item>
		/// <description><c>tomCacheParms</c></description>
		/// <description>Do not update the current font with the attached range properties.</description>
		/// </item>
		/// <item>
		/// <description><c>tomTrackParms</c></description>
		/// <description>Update the current font with the attached range properties.</description>
		/// </item>
		/// <item>
		/// <description><c>tomApplyTmp</c></description>
		/// <description>Apply temporary formatting.</description>
		/// </item>
		/// <item>
		/// <description><c>tomDisableSmartFont</c></description>
		/// <description>Do not apply smart fonts.</description>
		/// </item>
		/// <item>
		/// <description><c>tomEnableSmartFont</c></description>
		/// <description>Do apply smart fonts.</description>
		/// </item>
		/// <item>
		/// <description><c>tomUsePoints</c></description>
		/// <description>Use points for floating-point measurements.</description>
		/// </item>
		/// <item>
		/// <description><c>tomUseTwips</c></description>
		/// <description>Use twips for floating-point measurements.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If the method fails, it returns one of the following COM error codes. For more information about COM error codes, see Error Handling in COM.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return code</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>S_FALSE</c></description>
		/// <description>Protected from change.</description>
		/// </item>
		/// <item>
		/// <description><c>E_INVALIDARG</c></description>
		/// <description>Invalid argument.</description>
		/// </item>
		/// <item>
		/// <description><c>CO_E_RELEASED</c></description>
		/// <description>The font object is attached to a range that has been deleted.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>Calling <c>ITextFont::Reset</c> with <c>tomUndefined</c> sets all properties to undefined values. Thus, applying the font object to a range changes nothing. This applies to a font object that is obtained by the ITextFont::GetDuplicate method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-reset
		// HRESULT Reset( [in] long Value );
		new void Reset(tomConstants Value);

		/// <summary>Gets the character style handle of the characters in a range.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The character style handle.</para>
		/// </returns>
		/// <remarks>The Text Object Model (TOM) version 1.0 does not specify the meanings of the style handles. The meanings depend on other facilities of the text system that implements TOM.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getstyle
		// HRESULT GetStyle( long *pValue );
		new int GetStyle();

		/// <summary>Sets the character style handle of the characters in a range.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The new character style handle.</para>
		/// </param>
		/// <remarks>The Text Object Model (TOM) version 1.0 does not specify the meanings of the style handles. The meanings depend on other facilities of the text system that implements TOM.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setstyle
		// HRESULT SetStyle( [in] long Value );
		new void SetStyle(int Value);

		/// <summary>Gets whether the characters are all uppercase.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are all uppercase.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not all uppercase.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The AllCaps property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_ALLCAPS</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getallcaps
		// HRESULT GetAllCaps( long *pValue );
		new tomConstants GetAllCaps();

		/// <summary>Sets whether the characters are all uppercase.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are all uppercase.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not all uppercase.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the AllCaps property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The AllCaps property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setallcaps
		// HRESULT SetAllCaps( [in] long Value );
		new void SetAllCaps(tomConstants Value);

		/// <summary>Gets the animation type.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>One of the following animation types.</para>
		///   <para>tomNoAnimation tomLasVegasLights tomBlinkingBackground tomSparkleText tomMarchingBlackAnts tomMarchingRedAnts tomShimmer tomWipeDown tomWipeRight</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getanimation
		// HRESULT GetAnimation( long *pValue );
		new tomConstants GetAnimation();

		/// <summary>Sets the animation type.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The animation type. It can be one of the following values.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Animation type</description>
		///       <description>Value</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomNoAnimation</c>
		///       </description>
		///       <description>0</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomLasVegasLights</c>
		///       </description>
		///       <description>1</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomBlinkingBackground</c>
		///       </description>
		///       <description>2</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomSparkleText</c>
		///       </description>
		///       <description>3</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMarchingBlackAnts</c>
		///       </description>
		///       <description>4</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomMarchingRedAnts</c>
		///       </description>
		///       <description>5</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomShimmer</c>
		///       </description>
		///       <description>6</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomWipeDown</c>
		///       </description>
		///       <description>7</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomWipeRight</c>
		///       </description>
		///       <description>8</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setanimation
		// HRESULT SetAnimation( [in] long Value );
		new void SetAnimation(tomConstants Value);

		/// <summary>Gets the text background (highlight) color.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The text background color. It can be one of the following values.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>A <see cref="COLORREF" /> value</description>
		///       <description>The high-order byte is zero, and the three low-order bytes specify an RGB color.</description>
		///     </item>
		///     <item>
		///       <description>A value returned by PALETTEINDEX</description>
		///       <description>The high-order byte is 1, and the LOWORD specifies the index of a logical-color palette entry.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomAutocolor</c> (-9999997)</description>
		///       <description>Indicates the range uses the default system background color.</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getbackcolor
		// HRESULT GetBackColor( long *pValue );
		new int GetBackColor();

		/// <summary>Sets the background color.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The new background color. It can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>A COLORREF value.</description>
		///       <description>An RGB color.</description>
		///     </item>
		///     <item>
		///       <description>A value returned by PALETTEINDEX</description>
		///       <description>A palette index.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>No change.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomAutoColor</c>
		///       </description>
		///       <description>Use the default background color.</description>
		///     </item>
		///   </list>
		///   <para>If <c>Value</c> contains an RGB color, generate the COLORREF by using the RGB macro.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setbackcolor
		// HRESULT SetBackColor( [in] long Value );
		new void SetBackColor(int Value);

		/// <summary>Gets whether the characters are bold.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are bold.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not bold.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Bold property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>You can use the ITextFont::SetWeight and ITextFont::GetWeight methods to set or retrieve the font weight more precisely than the ITextFont::SetBold and <c>ITextFont::GetBold</c> methods.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getbold
		// HRESULT GetBold( long *pValue );
		new tomConstants GetBold();

		/// <summary>Sets whether characters are bold.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are bold.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not bold.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Bold property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Bold property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setbold
		// HRESULT SetBold( [in] long Value );
		new void SetBold(tomConstants Value);

		/// <summary>Gets whether characters are embossed.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are embossed.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not embossed.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Emboss property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_EMBOSS</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getemboss
		// HRESULT GetEmboss( long *pValue );
		new tomConstants GetEmboss();

		/// <summary>Sets whether characters are embossed.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are embossed.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not embossed.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Emboss property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Emboss property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setemboss
		// HRESULT SetEmboss( [in] long Value );
		new void SetEmboss(tomConstants Value);

		/// <summary>Gets the foreground, or text, color.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The foreground color. It can be one of the following values.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>A COLORREF value</description>
		///       <description>The high-order byte is zero, and the three low-order bytes specify an RGB color.</description>
		///     </item>
		///     <item>
		///       <description>A value returned by PALETTEINDEX</description>
		///       <description>The high-order byte is 1, and the LOWORD specifies the index of a logical-color palette entry.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomAutocolor</c> (-9999997)</description>
		///       <description>Indicates that the range uses the default system foreground color.</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getforecolor
		// HRESULT GetForeColor( long *pValue );
		new int GetForeColor();

		/// <summary>Sets the foreground (text) color.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The new foreground color. It can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>A COLORREF value.</description>
		///       <description>An RGB color.</description>
		///     </item>
		///     <item>
		///       <description>A value returned by PALETTEINDEX</description>
		///       <description>A palette index.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>No change.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomAutoColor</c>
		///       </description>
		///       <description>Use the default foreground color.</description>
		///     </item>
		///   </list>
		///   <para>Â</para>
		///   <para>If <c>Value</c> contains an RGB color, generate the COLORREF by using the RGB macro.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setforecolor
		// HRESULT SetForeColor( [in] long Value );
		new void SetForeColor(int Value);

		/// <summary>Gets whether characters are hidden.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are hidden.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not hidden.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Hidden property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_HIDDEN</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-gethidden
		// HRESULT GetHidden( long *pValue );
		new tomConstants GetHidden();

		/// <summary>Sets whether characters are hidden.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are hidden.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not hidden.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Hidden property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Hidden property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-sethidden
		// HRESULT SetHidden( [in] long Value );
		new void SetHidden(tomConstants Value);

		/// <summary>Gets whether characters are displayed as imprinted characters.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed as imprinted characters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed as imprinted characters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Engrave property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_IMPRINT</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getengrave
		// HRESULT GetEngrave( long *pValue );
		new tomConstants GetEngrave();

		/// <summary>Sets whether characters are displayed as imprinted characters.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are imprinted.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not imprinted.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Engrave property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Engrave property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setengrave
		// HRESULT SetEngrave( [in] long Value );
		new void SetEngrave(tomConstants Value);

		/// <summary>Gets whether characters are in italics.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are in italics.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not in italics.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Italic property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getitalic
		// HRESULT GetItalic( long *pValue );
		new tomConstants GetItalic();

		/// <summary>Sets whether characters are in italics.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are in italics.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not in italics.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Italic property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Italic property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setitalic
		// HRESULT SetItalic( [in] long Value );
		new void SetItalic(tomConstants Value);

		/// <summary>Gets the minimum font size at which kerning occurs.</summary>
		/// <returns>
		///   <para>Type: <c>float*</c></para>
		///   <para>The minimum font size at which kerning occurs, in floating-point points.</para>
		/// </returns>
		/// <remarks>If the value pointed to by <c>pValue</c> is zero, kerning is off. Positive values turn on pair kerning for font point sizes greater than or equal to the kerning value. For example, the value 1 turns on kerning for all legible sizes, whereas 16 turns on kerning only for font sizes of 16 points and larger.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getkerning
		// HRESULT GetKerning( float *pValue );
		new float GetKerning();

		/// <summary>Sets the minimum font size at which kerning occurs.</summary>
		/// <param name="Value">
		///   <para>Type: <c>float</c></para>
		///   <para>The new value of the minimum kerning size, in floating-point points.</para>
		/// </param>
		/// <remarks>If this value is zero, kerning is turned off. Positive values turn on pair kerning for font sizes greater than this kerning value. For example, the value 1 turns on kerning for all legible sizes, whereas 16 turns on kerning only for font sizes of 16 points and larger.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setkerning
		// HRESULT SetKerning( [in] float Value );
		new void SetKerning(float Value);

		/// <summary>Gets the language ID or language code identifier (LCID).</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The language ID or LCID. The low word contains the language identifier. The high word is either zero or it contains the high word of the LCID. To retrieve the language identifier, mask out the high word. For more information, see Locale Identifiers.</para>
		/// </returns>
		/// <remarks>To get the BCP-47 language tag, such as "en-US", call <c>ITextRange2::GetText2(pBstr, tomLanguageTag)</c>, where <c>pBstr</c> specifies the desired language tag.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getlanguageid
		// HRESULT GetLanguageID( long *pValue );
		new LCID GetLanguageID();

		/// <summary>Sets the language ID or language code identifier (LCID).</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The new language identifier. The low word contains the language identifier. The high word is either zero or it contains the high word of the locale identifier LCID. For more information, see Locale Identifiers.</para>
		/// </param>
		/// <remarks>
		///   <para>If the high nibble of <c>Value</c> is tomCharset, set the <c>charrep</c> from the <c>charset</c> in the low byte and the pitch and family from the next byte. See also ITextFont2::SetCharRep.</para>
		///   <para>If the high nibble of <c>Value</c> is tomCharRepFromLcid, set the <c>charrep</c> from the LCID and set the LCID as well. See ITextFont::GetLanguageID for more information.</para>
		///   <para>To set the BCP-47 language tag, such as "en-US", call ITextRange2::SetText2 and set the tomLanguageTag and <c>bstr</c> with the language tag.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setlanguageid
		// HRESULT SetLanguageID( [in] long Value );
		new void SetLanguageID(LCID Value);

		/// <summary>Gets the font name.</summary>
		/// <returns>
		///   <para>Type: <c>BSTR*</c></para>
		///   <para>The font name.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getname
		// HRESULT GetName( BSTR *pbstr );
		[return: MarshalAs(UnmanagedType.BStr)]
		new string GetName();

		/// <summary>Sets the font name.</summary>
		/// <param name="bstr">
		///   <para>Type: <c>BSTR</c></para>
		///   <para>The new font name.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setname
		// HRESULT SetName( [in] BSTR bstr );
		new void SetName([MarshalAs(UnmanagedType.BStr)] string bstr);

		/// <summary>Gets whether characters are displayed as outlined characters.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed as outlined characters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed as outlined characters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Outline property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_OUTLINE</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getoutline
		// HRESULT GetOutline( long *pValue );
		new tomConstants GetOutline();

		/// <summary>Sets whether characters are displayed as outlined characters.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are outlined.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not outlined.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Outline property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Outline property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setoutline
		// HRESULT SetOutline( [in] long Value );
		new void SetOutline(tomConstants Value);

		/// <summary>Gets the amount that characters are offset vertically relative to the baseline.</summary>
		/// <returns>
		///   <para>Type: <c>float*</c></para>
		///   <para>The amount of vertical offset, in floating-point points.</para>
		/// </returns>
		/// <remarks>Displayed text typically has a zero value for this property. Positive values raise the text, and negative values lower it.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getposition
		// HRESULT GetPosition( float *pValue );
		new float GetPosition();

		/// <summary>Sets the amount that characters are offset vertically relative to the baseline.</summary>
		/// <param name="Value">
		///   <para>Type: <c>float</c></para>
		///   <para>The new amount of vertical offset, in floating-point points.</para>
		/// </param>
		/// <remarks>Displayed text typically has a zero value for this property. Positive values raise the text, and negative values lower it.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setposition
		// HRESULT SetPosition( [in] float Value );
		new void SetPosition(float Value);

		/// <summary>Gets whether characters are protected against attempts to modify them.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are protected.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not protected.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Protected property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>In general, Text Object Model (TOM) methods that attempt to change the formatting or content of a range fail with <c>E_ACCESSDENIED</c> if any part of that range is protected, or if the document is read only. To make a change in protected text, the TOM client should attempt to turn off the protection of the text to be modified. The owner of the document may permit this to happen. For example in rich edit controls, attempts to change protected text result in an EN_PROTECTED notification code to the creator of the document, who then can refuse or grant permission for the change. The creator is the client that created a windowed rich edit control through the CreateWindow function or the ITextHost object that called the CreateTextServices function to create a windowless rich edit control.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getprotected
		// HRESULT GetProtected( long *pValue );
		new tomConstants GetProtected();

		/// <summary>Sets whether characters are protected against attempts to modify them.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are protected.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not protected.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Protected property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Protected property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		/// <remarks>In general, Text Object Model (TOM) methods that attempt to change the formatting or content of a range will fail with <c>E_ACCESSDENIED</c> if any part of that range is protected or if the document is read-only. To make a change in protected text, the TOM client should attempt to turn off the protection of the text to be modified. The owner of the document may permit this to happen. For example in rich edit controls, attempts to change protected text result in an EN_PROTECTED notification code to the creator of the document, who then can refuse or grant permission for the change. The creator is the client that created a windowed rich-edit control through the CreateWindow function or the ITextHost object that called the CreateTextServices function to create a windowless rich edit control.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setprotected
		// HRESULT SetProtected( [in] long Value );
		new void SetProtected(tomConstants Value);

		/// <summary>Gets whether characters are displayed as shadowed characters.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed as shadowed characters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed as shadowed characters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Shadow property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_SHADOW</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getshadow
		// HRESULT GetShadow( long *pValue );
		new tomConstants GetShadow();

		/// <summary>Sets whether characters are displayed as shadowed characters.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are shadowed.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not shadowed.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Shadow property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Shadow property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setshadow
		// HRESULT SetShadow( [in] long Value );
		new void SetShadow(tomConstants Value);

		/// <summary>Gets the font size.</summary>
		/// <returns>
		///   <para>Type: <c>float*</c></para>
		///   <para>The font size, in floating-point points.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getsize
		// HRESULT GetSize( float *pValue );
		new float GetSize();

		/// <summary>Sets the font size.</summary>
		/// <param name="Value">
		///   <para>Type: <c>float</c></para>
		///   <para>The new font size, in floating-point points.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setsize
		// HRESULT SetSize( [in] float Value );
		new void SetSize(float Value);

		/// <summary>Gets whether characters are in small capital letters.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are in small capital letters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not in small capital letters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The SmallCaps property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_SMALLCAPS</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getsmallcaps
		// HRESULT GetSmallCaps( long *pValue );
		new tomConstants GetSmallCaps();

		/// <summary>Sets whether characters are in small capital letters.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are in small capital letters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not in small capital letters.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the SmallCaps property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The SmallCaps property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setsmallcaps
		// HRESULT SetSmallCaps( [in] long Value );
		new void SetSmallCaps(tomConstants Value);

		/// <summary>Gets the amount of horizontal spacing between characters.</summary>
		/// <returns>
		///   <para>Type: <c>float*</c></para>
		///   <para>The amount of horizontal spacing between characters, in floating-point points.</para>
		/// </returns>
		/// <remarks>Displayed text typically has an intercharacter spacing value of zero. Positive values expand the spacing, and negative values compress it.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getspacing
		// HRESULT GetSpacing( float *pValue );
		new float GetSpacing();

		/// <summary>Sets the amount of horizontal spacing between characters.</summary>
		/// <param name="Value">
		///   <para>Type: <c>float</c></para>
		///   <para>The new amount of horizontal spacing between characters, in floating-point points.</para>
		/// </param>
		/// <remarks>Displayed text typically has an intercharacter spacing value of zero. Positive values expand the spacing, and negative values compress it.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setspacing
		// HRESULT SetSpacing( [in] float Value );
		new void SetSpacing(float Value);

		/// <summary>Gets whether characters are displayed with a horizontal line through the center.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed with a horizontal line through the center.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed with a horizontal line through the center.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The StrikeThrough property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_STRIKEOUT</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getstrikethrough
		// HRESULT GetStrikeThrough( long *pValue );
		new tomConstants GetStrikeThrough();

		/// <summary>Sets whether characters are displayed with a horizontal line through the center.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters have a horizontal line through the center.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters do not have a horizontal line through the center.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the StrikeThrough property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The StrikeThrough property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setstrikethrough
		// HRESULT SetStrikeThrough( [in] long Value );
		new void SetStrikeThrough(tomConstants Value);

		/// <summary>Gets whether characters are displayed as subscript.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed as subscript.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed as subscript.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Subscript property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_SUBSCRIPT</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getsubscript
		// HRESULT GetSubscript( long *pValue );
		new tomConstants GetSubscript();

		/// <summary>Sets whether characters are displayed as subscript.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed as subscript.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed as subscript.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Subscript property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Subscript property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setsubscript
		// HRESULT SetSubscript( [in] long Value );
		new void SetSubscript(tomConstants Value);

		/// <summary>Gets whether characters are displayed as superscript.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed as superscript.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed as superscript.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Superscript property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the <c>CFE_SUPERSCRIPT</c> effect described in the CHARFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getsuperscript
		// HRESULT GetSuperscript( long *pValue );
		new tomConstants GetSuperscript();

		/// <summary>Sets whether characters are displayed as superscript.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed as superscript.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed as superscript.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the state of the Superscript property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Superscript property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setsuperscript
		// HRESULT SetSuperscript( [in] long Value );
		new void SetSuperscript(tomConstants Value);

		/// <summary>Gets the type of underlining for the characters in a range.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The type of underlining. It can be one of the following values.</para>
		///   <para>tomNone</para>
		///   <para>tomSingle</para>
		///   <para>tomWords</para>
		///   <para>tomDouble</para>
		///   <para>tomDotted</para>
		///   <para>tomDash</para>
		///   <para>tomDashDot</para>
		///   <para>tomDashDotDot</para>
		///   <para>tomWave</para>
		///   <para>tomThick</para>
		///   <para>tomHair</para>
		///   <para>tomDoubleWave</para>
		///   <para>tomHeavyWave</para>
		///   <para>tomLongDash</para>
		///   <para>tomThickDash</para>
		///   <para>tomThickDashDot</para>
		///   <para>tomThickDashDotDot</para>
		///   <para>tomThickDotted</para>
		///   <para>tomThickLongDash</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getunderline
		// HRESULT GetUnderline( long *pValue );
		new tomConstants GetUnderline();

		/// <summary>Sets thevtype of underlining for the characters in a range.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The type of underlining. It can be one of the following values.</para>
		///   <para>tomNone</para>
		///   <para>tomSingle</para>
		///   <para>tomWords</para>
		///   <para>tomDouble</para>
		///   <para>tomDotted</para>
		///   <para>tomDash</para>
		///   <para>tomDashDot</para>
		///   <para>tomDashDotDot</para>
		///   <para>tomWave</para>
		///   <para>tomThick</para>
		///   <para>tomHair</para>
		///   <para>tomDoubleWave</para>
		///   <para>tomHeavyWave</para>
		///   <para>tomLongDash</para>
		///   <para>tomThickDash</para>
		///   <para>tomThickDashDot</para>
		///   <para>tomThickDashDotDot</para>
		///   <para>tomThickDotted</para>
		///   <para>tomThickLongDash</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setunderline
		// HRESULT SetUnderline( [in] long Value );
		new void SetUnderline(tomConstants Value);

		/// <summary>Gets the font weight for the characters in a range.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The font weight. The Bold property is a binary version of the Weight property that sets the weight to <c>FW_BOLD</c>. The font weight exists in the LOGFONT structure and the IFont interface. Windows defines the following degrees of font weight.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Font weight</description>
		///       <description>Value</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>FW_DONTCARE</c>
		///       </description>
		///       <description>0</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_THIN</c>
		///       </description>
		///       <description>100</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_EXTRALIGHT</c>
		///       </description>
		///       <description>200</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_LIGHT</c>
		///       </description>
		///       <description>300</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_NORMAL</c>
		///       </description>
		///       <description>400</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_MEDIUM</c>
		///       </description>
		///       <description>500</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_SEMIBOLD</c>
		///       </description>
		///       <description>600</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_BOLD</c>
		///       </description>
		///       <description>700</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_EXTRABOLD</c>
		///       </description>
		///       <description>800</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_HEAVY</c>
		///       </description>
		///       <description>900</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-getweight
		// HRESULT GetWeight( long *pValue );
		new int GetWeight();

		/// <summary>Sets the font weight for the characters in a range.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The new font weight. The Bold property is a binary version of the Weight property that sets the weight to <c>FW_BOLD</c>. The font weight exists in the LOGFONT structure and the IFont interface. Windows defines the following degrees of font weight.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Font weight</description>
		///       <description>Value</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>FW_DONTCARE</c>
		///       </description>
		///       <description>0</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_THIN</c>
		///       </description>
		///       <description>100</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_EXTRALIGHT</c>
		///       </description>
		///       <description>200</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_LIGHT</c>
		///       </description>
		///       <description>300</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_NORMAL</c>
		///       </description>
		///       <description>400</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_MEDIUM</c>
		///       </description>
		///       <description>500</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_SEMIBOLD</c>
		///       </description>
		///       <description>600</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_BOLD</c>
		///       </description>
		///       <description>700</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_EXTRABOLD</c>
		///       </description>
		///       <description>800</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>FW_HEAVY</c>
		///       </description>
		///       <description>900</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont-setweight
		// HRESULT SetWeight( [in] long Value );
		new void SetWeight(int Value);

		/// <summary>Gets the count of extra properties in this character formatting collection.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The count of extra properties in this collection.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getcount
		// HRESULT GetCount( [out, retval] long *pCount );
		int GetCount();

		/// <summary>Gets whether support for automatic ligatures is active.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Automatic ligature support is active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Automatic ligature support is not active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The AutoLigatures property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getautoligatures
		// HRESULT GetAutoLigatures( [out, retval] long *pValue );
		tomConstants GetAutoLigatures();

		/// <summary>Sets whether support for automatic ligatures is active.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Automatic ligature support is active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Automatic ligature support is not active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the AutoLigatures property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The AutoLigatures property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setautoligatures
		// HRESULT SetAutoLigatures( [in] long Value );
		void SetAutoLigatures(tomConstants Value);

		/// <summary>Gets the East Asian "autospace alphabetics" state.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Use East Asian autospace alphabetics.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Do not use East Asian autospace alphabetics.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The AutospaceAlpha property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getautospacealpha
		// HRESULT GetAutospaceAlpha( [out, retval] long *pValue );
		tomConstants GetAutospaceAlpha();

		/// <summary>Sets the East Asian "autospace alpha" state.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Use East Asian autospace alphabetics.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Do not use East Asian autospace alphabetics.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the AutospaceAlpha property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The AutospaceAlpha property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setautospacealpha
		// HRESULT SetAutospaceAlpha( [in] long Value );
		void SetAutospaceAlpha(tomConstants Value);

		/// <summary>Gets the East Asian "autospace numeric" state.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Use East Asian autospace numerics.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Do not use East Asian autospace numerics.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The AutospaceNumeric property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getautospacenumeric
		// HRESULT GetAutospaceNumeric( [out, retval] long *pValue );
		tomConstants GetAutospaceNumeric();

		/// <summary>Sets the East Asian "autospace numeric" state.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Use East Asian autospace numerics.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Do not use East Asian autospace numerics.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the AutospaceNumeric property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The AutospaceNumeric property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setautospacenumeric
		// HRESULT SetAutospaceNumeric( [in] long Value );
		void SetAutospaceNumeric(tomConstants Value);

		/// <summary>Gets the East Asian "autospace parentheses" state.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Use East Asian autospace parentheses.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Do not use East Asian autospace parentheses.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The AutospaceParens property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getautospaceparens
		// HRESULT GetAutospaceParens( [out, retval] long *pValue );
		tomConstants GetAutospaceParens();

		/// <summary>Sets the East Asian "autospace parentheses" state.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Use East Asian autospace parentheses.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Do not use East Asian autospace parentheses.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the AutospaceParens property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The AutospaceParens property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setautospaceparens
		// HRESULT SetAutospaceParens( [in] long Value );
		void SetAutospaceParens(tomConstants Value);

		/// <summary>Gets the character repertoire (writing system).</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The character repertoire. It can be one of the following values.</para>
		///   <para>tomAboriginal</para>
		///   <para>tomAnsi</para>
		///   <para>tomArabic</para>
		///   <para>tomArmenian</para>
		///   <para>tomBaltic</para>
		///   <para>tomBengali</para>
		///   <para>tomBIG5</para>
		///   <para>tomBraille</para>
		///   <para>tomCherokee</para>
		///   <para>tomCyrillic</para>
		///   <para>tomDefaultCharRep</para>
		///   <para>tomDevanagari</para>
		///   <para>tomEastEurope</para>
		///   <para>tomEmoji</para>
		///   <para>tomEthiopic</para>
		///   <para>tomGB2312</para>
		///   <para>tomGeorgian</para>
		///   <para>tomGreek</para>
		///   <para>tomGujarati</para>
		///   <para>tomGurmukhi</para>
		///   <para>tomHangul</para>
		///   <para>tomHebrew</para>
		///   <para>tomJamo</para>
		///   <para>tomKannada</para>
		///   <para>tomKayahli</para>
		///   <para>tomKharoshthi</para>
		///   <para>tomKhmer</para>
		///   <para>tomLao</para>
		///   <para>tomLimbu</para>
		///   <para>tomMac</para>
		///   <para>tomMalayalam</para>
		///   <para>tomMongolian</para>
		///   <para>tomMyanmar</para>
		///   <para>tomNewTaiLu</para>
		///   <para>tomOEM</para>
		///   <para>tomOgham</para>
		///   <para>tomOriya</para>
		///   <para>tomPC437</para>
		///   <para>tomRunic</para>
		///   <para>tomShiftJIS</para>
		///   <para>tomSinhala</para>
		///   <para>tomSylotinagr</para>
		///   <para>tomSymbol</para>
		///   <para>tomSyriac</para>
		///   <para>tomTaiLe</para>
		///   <para>tomTamil</para>
		///   <para>tomTelugu</para>
		///   <para>tomThaana</para>
		///   <para>tomThai</para>
		///   <para>tomTibetan</para>
		///   <para>tomTurkish</para>
		///   <para>tomVietnamese</para>
		///   <para>tomUsymbol</para>
		///   <para>tomYi</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getcharrep
		// HRESULT GetCharRep( [out, retval] long *pValue );
		tomConstants GetCharRep();

		/// <summary>Sets the character repertoire (writing system).</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The new character repertoire. For a list of possible values, see ITextFont2::GetCharRep.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setcharrep
		// HRESULT SetCharRep( [in] long Value );
		void SetCharRep(tomConstants Value);

		/// <summary>Gets the East Asian compression mode.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The compression mode, which can be one of these values:</para>
		///   <para>tomCompressNone (default)</para>
		///   <para>tomCompressPunctuation</para>
		///   <para>tomCompressPunctuationAndKana</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getcompressionmode
		// HRESULT GetCompressionMode( [out, retval] long *pValue );
		tomConstants GetCompressionMode();

		/// <summary>Sets the East Asian compression mode.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The compression mode, which can be one of these values:</para>
		///   <para>tomCompressNone (default)</para>
		///   <para>tomCompressPunctuation</para>
		///   <para>tomCompressPunctuationAndKana</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setcompressionmode
		// HRESULT SetCompressionMode( [in] long Value );
		void SetCompressionMode(tomConstants Value);

		/// <summary>Gets the client cookie.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The client cookie.</para>
		/// </returns>
		/// <remarks>This value is purely for the use of the client and has no meaning to the Text Object Model (TOM) engine. There are exceptions where different values correspond to different character format runs.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getcookie
		// HRESULT GetCookie( [out, retval] long *pValue );
		int GetCookie();

		/// <summary>Sets the client cookie.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The client cookie.</para>
		/// </param>
		/// <remarks>This value is purely for the use of the client. It has no meaning to the Text Object Model (TOM) engine except that different values correspond to different character format runs.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setcookie
		// HRESULT SetCookie( [in] long Value );
		void SetCookie(int Value);

		/// <summary>Gets whether characters are displayed with double horizontal lines through the center.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed with double horizontal lines.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed with double horizontal lines.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The DoubleStrike property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getdoublestrike
		// HRESULT GetDoubleStrike( [out, retval] long *pValue );
		tomConstants GetDoubleStrike();

		/// <summary>Sets whether characters are displayed with double horizontal lines through the center.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Characters are displayed with double horizontal lines.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Characters are not displayed with double horizontal lines.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the DoubleStrike property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The DoubleStrike property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setdoublestrike
		// HRESULT SetDoubleStrike( [in] long Value );
		void SetDoubleStrike(tomConstants Value);

		/// <summary>Gets a duplicate of this character format object.</summary>
		/// <returns>
		///   <para>Type: <c>ITextFont2**</c></para>
		///   <para>The duplicate character format object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getduplicate2
		// HRESULT GetDuplicate2( [out, retval] ITextFont2 **ppFont );
		ITextFont2 GetDuplicate2();

		/// <summary>Sets the properties of this object by copying the properties of another text font object.</summary>
		/// <param name="pFont">
		///   <para>Type: <c>ITextFont2*</c></para>
		///   <para>The text font object to copy from.</para>
		/// </param>
		/// <remarks>
		///   <para>Values with the <c>tomUndefined</c> attribute have no effect.</para>
		///   <para>For an example of how to use font duplicates, see ITextRange::SetFont.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setduplicate2
		// HRESULT SetDuplicate2( [in] ITextFont2 *pFont );
		void SetDuplicate2([In, Optional] ITextFont2? pFont);

		/// <summary>Gets the link type.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The link type. It can be one of the following values.</para>
		///   <para>tomNoLink</para>
		///   <para>tomClientLink</para>
		///   <para>tomFriendlyLinkName</para>
		///   <para>tomFriendlyLinkAddress</para>
		///   <para>tomAutoLinkURL</para>
		///   <para>tomAutoLinkEmail</para>
		///   <para>tomAutoLinkPhone</para>
		///   <para>tomAutoLinkPath</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getlinktype
		// HRESULT GetLinkType( [out, retval] long *pValue );
		tomConstants GetLinkType();

		/// <summary>Gets whether a math zone is active.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>A math zone is active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>A math zone is not active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The MathZone property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getmathzone
		// HRESULT GetMathZone( [out, retval] long *pValue );
		tomConstants GetMathZone();

		/// <summary>Sets whether a math zone is active.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>A math zone is active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>A math zone is not active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the MathZone property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The MathZone property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setmathzone
		// HRESULT SetMathZone( [in] long Value );
		void SetMathZone(tomConstants Value);

		/// <summary>Gets whether "decrease widths on pairs" is active.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Decrease widths on pairs is active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Decrease widths on pairs is not active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The ModWidthPairs property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getmodwidthpairs
		// HRESULT GetModWidthPairs( [out, retval] long *pValue );
		tomConstants GetModWidthPairs();

		/// <summary>Sets whether "decrease widths on pairs" is active.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Decrease widths on pairs is active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Decrease widths on pairs is not active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the ModWidthPairs property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The ModWidthPairs property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setmodwidthpairs
		// HRESULT SetModWidthPairs( [in] long Value );
		void SetModWidthPairs(tomConstants Value);

		/// <summary>Gets whether "increase width of whitespace" is active.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Increase width of whitespace is active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Increase width of whitespace is not active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The ModWidthSpace property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getmodwidthspace
		// HRESULT GetModWidthSpace( [out, retval] long *pValue );
		tomConstants GetModWidthSpace();

		/// <summary>Sets whether "increase width of whitespace" is active.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Increase width of whitespace is active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Increase width of whitespace is not active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the ModWidthSpace property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The ModWidthSpace property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setmodwidthspace
		// HRESULT SetModWidthSpace( [in] long Value );
		void SetModWidthSpace(tomConstants Value);

		/// <summary>Gets whether old-style numbers are active.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Old-style numbers are active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Old-style numbers are not active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The OldNumbers property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getoldnumbers
		// HRESULT GetOldNumbers( [out, retval] long *pValue );
		tomConstants GetOldNumbers();

		/// <summary>Sets whether old-style numbers are active.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Old-style numbers are active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Old-style numbers are not active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the OldNumbers property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The OldNumbers property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setoldnumbers
		// HRESULT SetOldNumbers( [in] long Value );
		void SetOldNumbers(tomConstants Value);

		/// <summary>Gets whether overlapping text is active.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Overlapping text is active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Overlapping text is not active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Overlapping property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getoverlapping
		// HRESULT GetOverlapping( [out, retval] long *pValue );
		tomConstants GetOverlapping();

		/// <summary>Sets whether overlapping text is active.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A tomBool value that can be one of the following.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Overlapping text is active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Overlapping text is not active.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomToggle</c>
		///       </description>
		///       <description>Toggle the Overlapping property.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The Overlapping property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setoverlapping
		// HRESULT SetOverlapping( [in] long Value );
		void SetOverlapping(tomConstants Value);

		/// <summary>Gets the subscript or superscript position relative to the baseline.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The subscript or superscript position relative to the baseline.</para>
		/// </returns>
		/// <remarks>
		///   <para>The subscript or superscript position is relative to the baseline as a percent of the font height.</para>
		///   <para>Subscripts and superscripts in math zones are handled using the tomSubscript, tomSuperscript, tomSubSup, and tomLeftSubSup mathematical objects. See ITextRange2::GetInlineObject.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getpositionsubsuper
		// HRESULT GetPositionSubSuper( [out, retval] long *pValue );
		int GetPositionSubSuper();

		/// <summary>Sets the position of a subscript or superscript relative to the baseline, as a percentage of the font height.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The new subscript or superscript position.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setpositionsubsuper
		// HRESULT SetPositionSubSuper( [in] long Value );
		void SetPositionSubSuper(int Value);

		/// <summary>Gets the font horizontal scaling percentage.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The scaling percentage.</para>
		/// </returns>
		/// <remarks>The font horizontal scaling percentage can range from 200, which doubles the widths of characters, to 0, where no scaling is performed. When the percentage is increased the height does not change.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getscaling
		// HRESULT GetScaling( [out, retval] long *pValue );
		int GetScaling();

		/// <summary>Sets the font horizontal scaling percentage.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The scaling percentage. Values from 0 through 255 are valid. For example, a value of 200 doubles the widths of characters while retaining the same height. A value of 0 has the same effect as a value of 100; that is, it turns scaling off.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setscaling
		// HRESULT SetScaling( [in] long Value );
		void SetScaling(int Value);

		/// <summary>Gets the East Asian space extension value.</summary>
		/// <returns>
		///   <para>Type: <c>float*</c></para>
		///   <para>The space extension, in floating-point points.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getspaceextension
		// HRESULT GetSpaceExtension( [out, retval] float *pValue );
		float GetSpaceExtension();

		/// <summary>Sets the East Asian space extension value.</summary>
		/// <param name="Value">
		///   <para>Type: <c>float</c></para>
		///   <para>The new space extension, in floating-points.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setspaceextension
		// HRESULT SetSpaceExtension( [in] float Value );
		void SetSpaceExtension(float Value);

		/// <summary>Gets the underline position mode.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The underline position mode. It can be one of the following values.</para>
		///   <para>tomUnderlinePositionAuto tomUnderlinePositionBelow tomUnderlinePositionAbove</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getunderlinepositionmode
		// HRESULT GetUnderlinePositionMode( [out, retval] long *pValue );
		tomConstants GetUnderlinePositionMode();

		/// <summary>Sets the underline position mode.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The new underline position mode. It can be one of the following values.</para>
		///   <list type="bullet">
		///     <item>
		///       <description>tomUnderlinePositionAuto (the default)</description>
		///     </item>
		///     <item>
		///       <description>tomUnderlinePositionBelow</description>
		///     </item>
		///     <item>
		///       <description>tomUnderlinePositionAbove</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setunderlinepositionmode
		// HRESULT SetUnderlinePositionMode( [in] long Value );
		void SetUnderlinePositionMode(tomConstants Value);

		/// <summary>Gets the character format effects.</summary>
		/// <param name="pValue">
		///   <para>Type: <c>long*</c></para>
		///   <para>A combination of the following character format values.</para>
		///   <para>tomAllCaps</para>
		///   <para>tomBold</para>
		///   <para>tomDisabled</para>
		///   <para>tomEmboss</para>
		///   <para>tomHidden</para>
		///   <para>tomImprint</para>
		///   <para>tomInlineObjectStart</para>
		///   <para>tomItalic</para>
		///   <para>tomLink</para>
		///   <para>tomLinkProtected</para>
		///   <para>tomMathZone</para>
		///   <para>tomMathZoneDisplay</para>
		///   <para>tomMathZoneNoBuildUp</para>
		///   <para>tomMathZoneOrdinary</para>
		///   <para>tomOutline</para>
		///   <para>tomProtected</para>
		///   <para>tomRevised</para>
		///   <para>tomShadow</para>
		///   <para>tomSmallCaps</para>
		///   <para>tomStrikeout</para>
		///   <para>tomUnderline</para>
		///   <para>If the tomInlineObjectStart flag is set, you might want to call GetInlineObject for more inline object properties.</para>
		/// </param>
		/// <param name="pMask">
		///   <para>Type: <c>long*</c></para>
		///   <para>The differences in these flags over the range. A value of zero indicates that the properties are the same over the range. For an insertion point, this value is always zero.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-geteffects
		// HRESULT GetEffects( [out] long *pValue, [out] long *pMask );
		void GetEffects(out tomConstants pValue, out tomConstants pMask);

		/// <summary>Gets the additional character format effects.</summary>
		/// <param name="pValue">
		///   <para>Type: <c>long*</c></para>
		///   <para>A combination of the following character format flags.</para>
		///   <para>tomAutoSpaceAlpha</para>
		///   <para>tomAutoSpaceNumeric</para>
		///   <para>tomAutoSpaceParens</para>
		///   <para>tomDoublestrike</para>
		///   <para>tomEmbeddedFont</para>
		///   <para>tomModWidthPairs</para>
		///   <para>tomModWidthSpace</para>
		///   <para>tomOverlapping</para>
		/// </param>
		/// <param name="pMask">
		///   <para>Type: <c>long*</c></para>
		///   <para>The differences in these flags over the range. Zero values indicate that the properties are the same over the range. For an insertion point, this value is always zero.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-geteffects2
		// HRESULT GetEffects2( [out] long *pValue, [out] long *pMask );
		void GetEffects2(out tomConstants pValue, out tomConstants pMask);

		/// <summary>Gets the value of the specified property.</summary>
		/// <param name="Type">
		///   <para>Type: <c>long</c></para>
		///   <para>The property ID of the value to return. See Remarks.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The property value.</para>
		/// </returns>
		/// <remarks>Property IDs are defined by the Text Object Model (TOM). Here are how some of the TOM values are obtained:</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getproperty
		// HRESULT GetProperty( [in] long Type, [out] long *pValue );
		int GetProperty(int Type);

		/// <summary>Gets the property type and value of the specified extra property.</summary>
		/// <param name="Index">
		///   <para>Type: <c>long</c></para>
		///   <para>The collection index of the extra property.</para>
		/// </param>
		/// <param name="pType">
		///   <para>Type: <c>long*</c></para>
		///   <para>The property ID.</para>
		/// </param>
		/// <param name="pValue">
		///   <para>Type: <c>long*</c></para>
		///   <para>The property value.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-getpropertyinfo
		// HRESULT GetPropertyInfo( [in] long Index, [out] long *pType, [out] long *pValue );
		void GetPropertyInfo(int Index, out int pType, out int pValue);

		/// <summary>Determines whether this text font object has the same properties as the specified text font object.</summary>
		/// <param name="pFont">
		///   <para>Type: <c>ITextFont2*</c></para>
		///   <para>The text font object to compare against.</para>
		/// </param>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A tomBool value that is <c>tomTrue</c> if the font objects have the same properties, or <c>tomFalse</c> if they don't. This parameter can be <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		///   <para>For two text font objects to be equal, both must belong to the same Text Object Model (TOM) object.</para>
		///   <para>The <c>ITextFont::IsEqual2</c> method ignores entries for which either font object has a tomUndefined value.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-isequal2
		// HRESULT IsEqual2( [in] ITextFont2 *pFont, [out] long *pB );
		tomConstants IsEqual2([In, Optional] ITextFont2? pFont);

		/// <summary>Sets the character format effects.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A combination of the following character format values.</para>
		///   <para>tomAllCaps</para>
		///   <para>tomBold</para>
		///   <para>tomDisabled</para>
		///   <para>tomEmboss</para>
		///   <para>tomHidden</para>
		///   <para>tomImprint</para>
		///   <para>tomInlineObjectStart</para>
		///   <para>tomItalic</para>
		///   <para>tomLink</para>
		///   <para>tomLinkProtected</para>
		///   <para>tomMathZone</para>
		///   <para>tomMathZoneDisplay</para>
		///   <para>tomMathZoneNoBuildUp</para>
		///   <para>tomMathZoneOrdinary</para>
		///   <para>tomOutline</para>
		///   <para>tomProtected</para>
		///   <para>tomRevised</para>
		///   <para>tomShadow</para>
		///   <para>tomSmallCaps</para>
		///   <para>tomStrikeout</para>
		///   <para>tomUnderline</para>
		/// </param>
		/// <param name="Mask">
		///   <para>Type: <c>long</c></para>
		///   <para>The desired mask, which can be a combination of the <c>Value</c> flags. Only effects with the corresponding mask flag set are modified.</para>
		/// </param>
		/// <remarks>Only effects with the corresponding mask flag set are modified.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-seteffects
		// HRESULT SetEffects( [in] long Value, [in] long Mask );
		void SetEffects(tomConstants Value, tomConstants Mask);

		/// <summary>Sets the additional character format effects.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>A combination of the following character format flags.</para>
		///   <para>tomAutoSpaceAlpha</para>
		///   <para>tomAutoSpaceNumeric</para>
		///   <para>tomAutoSpaceParens</para>
		///   <para>tomDoublestrike</para>
		///   <para>tomEmbeddedFont</para>
		///   <para>tomModWidthPairs</para>
		///   <para>tomModWidthSpace</para>
		///   <para>tomOverlapping</para>
		/// </param>
		/// <param name="Mask">
		///   <para>Type: <c>long</c></para>
		///   <para>The desired mask, which can be a combination of the <c>Value</c> flags. Only effects with the corresponding mask flag set are modified.</para>
		/// </param>
		/// <remarks>Only effects with the corresponding mask flag set are modified.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-seteffects2
		// HRESULT SetEffects2( [in] long Value, [in] long Mask );
		void SetEffects2(tomConstants Value, tomConstants Mask);

		/// <summary>Sets the value of the specified property.</summary>
		/// <param name="Type">
		///   <para>Type: <c>long</c></para>
		///   <para>The ID of the property value to set. Types are defined by TOM. For a list of types, see ITextFont2::GetProperty.</para>
		/// </param>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>The new property value.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextfont2-setproperty
		// HRESULT SetProperty( [in] long Type, [in] long Value );
		void SetProperty(int Type, int Value);
	}

	/// <summary>Text Object Model (TOM) rich text-range attributes are accessed through a pair of dual interfaces, ITextFont and <c>ITextPara</c>.</summary>
	/// <remarks>
	/// <para>The ITextFont and <c>ITextPara</c> interfaces encapsulate the functionality of the Microsoft Word Format <c>Font</c> and <c>Paragraph</c> dialog boxes, respectively. Both interfaces include a duplicate (<c>Value</c>) property that can return a duplicate of the attributes in a range object or transfer a set of attributes to a range. As such, they act like programmable format painters. For example, you could transfer all attributes from range r1 to range r2 except for making r2 bold and the font size 12 points by using the following subroutine.</para>
	/// <para>See SetFont for a similar example written in C++.</para>
	/// <para>The <c>ITextPara</c> interface encapsulates the Word Paragraph dialog box. All measurements are given in floating-point points. The rich edit control is able to accept and return all <c>ITextPara</c> properties intact (that is, without modification), both through TOM and through its Rich Text Format (RTF) converters. However, the following properties have no effect on what the control displays:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>DoNotHyphen</description>
	/// </item>
	/// <item>
	/// <description>KeepTogether</description>
	/// </item>
	/// <item>
	/// <description>KeepWithNext</description>
	/// </item>
	/// <item>
	/// <description>LineSpacing</description>
	/// </item>
	/// <item>
	/// <description>LineSpacingRule</description>
	/// </item>
	/// <item>
	/// <description>NoLineNumber</description>
	/// </item>
	/// <item>
	/// <description>PageBreakBefore</description>
	/// </item>
	/// <item>
	/// <description>Tab alignments</description>
	/// </item>
	/// <item>
	/// <description>Tab styles (other than tomAlignLeft and tomSpaces)</description>
	/// </item>
	/// <item>
	/// <description>Style WidowControl</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextpara
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextPara")]
	[ComImport, Guid("8CC497C4-A1DF-11ce-8098-00AA0047BE5D"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ITextPara
	{
		/// <summary>Creates a duplicate of the specified paragraph format object. The duplicate property is the default property of an ITextPara object.</summary>
		/// <returns>
		///   <para>Type: <c>ITextPara**</c></para>
		///   <para>The duplicate ITextPara object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara-getduplicate
		// HRESULT GetDuplicate( ITextPara **ppPara );
		ITextPara GetDuplicate();

		/// <summary>Sets the formatting for an existing paragraph by copying a given format.</summary>
		/// <param name="pPara">
		///   <para>Type: <c>ITextPara*</c></para>
		///   <para>The ITextPara range that contains the new paragraph formatting.</para>
		/// </param>
		/// <remarks>The tomUndefined values have no effect, that is, they will not change the target values.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara-setduplicate
		// HRESULT SetDuplicate( [in] ITextPara *pPara );
		void SetDuplicate([In, Optional] ITextPara? pPara);

		/// <summary>Determines whether the paragraph formatting can be changed.</summary>
		/// <param name="pValue">
		/// <para>Type: <c>long*</c></para>
		/// <para>A variable that is <c>tomTrue</c> if the paragraph formatting can be changed or <c>tomFalse</c> if it cannot be changed. This parameter can be null.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If paragraph formatting can change, <c>ITextPara::CanChange</c> succeeds and returns <c>S_OK</c>. If paragraph formatting cannot change, the method fails and returns S_FALSE. For more information about COM error codes, see Error Handling in COM.</para>
		/// </returns>
		/// <remarks>The *<c>pbCanChange</c> parameter returns <c>tomTrue</c> only if the paragraph formatting can be changed (that is, if no part of an associated range is protected and an associated document is not read-only). If this ITextPara object is a duplicate, no protection rules apply.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara-canchange
		// HRESULT CanChange( [retval] long *pValue );
		[PreserveSig]
		HRESULT CanChange(out tomConstants pValue);

		/// <summary>Determines if the current range has the same properties as a specified range.</summary>
		/// <param name="pPara">
		/// <para>Type: <c>ITextPara*</c></para>
		/// <para>The ITextPara range that is compared to the current range.</para>
		/// </param>
		/// <param name="pValue">
		/// <para>Type: <c>long*</c></para>
		/// <para>The comparison result. The value can be null.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the objects are equal, <c>ITextPara::IsEqual</c> succeeds and returns <c>S_OK</c>. If the objects are not equal, the method fails and returns S_FALSE. For more information about COM error codes, see Error Handling in COM.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara-isequal
		// HRESULT IsEqual( ITextPara *pPara, long *pValue );
		[PreserveSig]
		HRESULT IsEqual([In, Optional] ITextPara? pPara, out int pValue);

		/// <summary>Resets the paragraph formatting to a choice of default values.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>Type of reset. It can be one of the following possible values.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c></c> tomDefault</description>
		///       <description>Used for paragraph formatting that is defined by the RTF \pard, that is, the paragraph default control word.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c> tomUndefined</description>
		///       <description>Used for all undefined values. The tomUndefined value is only valid for duplicate (clone) ITextPara objects.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara-reset
		// HRESULT Reset( [in] long Value );
		void Reset(tomConstants Value);

		/// <summary>Retrieves the style handle to the paragraphs in the specified range.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The paragraph style handle. For more information, see the Remarks.</para>
		/// </returns>
		/// <remarks>
		///   <para>The Text Object Model (TOM) version 1.0 has no way to specify the meanings of user-defined style handles. They depend on other facilities of the text system implementing TOM. Negative style handles are reserved for built-in character and paragraph styles. Currently defined values are listed in the following table. For a description of the following styles, see the Microsoft Word documentation.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Style</description>
		///       <description>Value</description>
		///       <description>Style</description>
		///       <description>Value</description>
		///     </listheader>
		///     <item>
		///       <description>StyleNormal</description>
		///       <description>â1</description>
		///       <description>StyleTableofAuthorities</description>
		///       <description>â45</description>
		///     </item>
		///     <item>
		///       <description>StyleHeading1</description>
		///       <description>â2</description>
		///       <description>StyleMacroText</description>
		///       <description>â46</description>
		///     </item>
		///     <item>
		///       <description>StyleHeading2</description>
		///       <description>â3</description>
		///       <description>StyleTOAHeading</description>
		///       <description>â47</description>
		///     </item>
		///     <item>
		///       <description>StyleHeading3</description>
		///       <description>â4</description>
		///       <description>StyleList</description>
		///       <description>â48</description>
		///     </item>
		///     <item>
		///       <description>StyleHeading4</description>
		///       <description>â5</description>
		///       <description>StyleListBullet</description>
		///       <description>â49</description>
		///     </item>
		///     <item>
		///       <description>StyleHeading5</description>
		///       <description>â6</description>
		///       <description>StyleListNumber</description>
		///       <description>â50</description>
		///     </item>
		///     <item>
		///       <description>StyleHeading6</description>
		///       <description>â7</description>
		///       <description>StyleList2</description>
		///       <description>â51</description>
		///     </item>
		///     <item>
		///       <description>StyleHeading7</description>
		///       <description>â8</description>
		///       <description>StyleList3</description>
		///       <description>â52</description>
		///     </item>
		///     <item>
		///       <description>StyleHeading8</description>
		///       <description>â9</description>
		///       <description>StyleList4</description>
		///       <description>â53</description>
		///     </item>
		///     <item>
		///       <description>StyleHeading9</description>
		///       <description>â10</description>
		///       <description>StyleList5</description>
		///       <description>â54</description>
		///     </item>
		///     <item>
		///       <description>StyleIndex1</description>
		///       <description>â11</description>
		///       <description>StyleListBullet2</description>
		///       <description>â55</description>
		///     </item>
		///     <item>
		///       <description>StyleIndex2</description>
		///       <description>â12</description>
		///       <description>StyleListBullet3</description>
		///       <description>â56</description>
		///     </item>
		///     <item>
		///       <description>StyleIndex3</description>
		///       <description>â13</description>
		///       <description>StyleListBullet4</description>
		///       <description>â57</description>
		///     </item>
		///     <item>
		///       <description>StyleIndex4</description>
		///       <description>â14</description>
		///       <description>StyleListBullet5</description>
		///       <description>â58</description>
		///     </item>
		///     <item>
		///       <description>StyleIndex5</description>
		///       <description>â15</description>
		///       <description>StyleListNumber2</description>
		///       <description>â59</description>
		///     </item>
		///     <item>
		///       <description>StyleIndex6</description>
		///       <description>â16</description>
		///       <description>StyleListNumber3</description>
		///       <description>â60</description>
		///     </item>
		///     <item>
		///       <description>StyleIndex7</description>
		///       <description>â17</description>
		///       <description>StyleListNumber4</description>
		///       <description>â61</description>
		///     </item>
		///     <item>
		///       <description>StyleIndex8</description>
		///       <description>â18</description>
		///       <description>StyleListNumber5</description>
		///       <description>â62</description>
		///     </item>
		///     <item>
		///       <description>StyleIndex9</description>
		///       <description>â19</description>
		///       <description>StyleTitle</description>
		///       <description>â63</description>
		///     </item>
		///     <item>
		///       <description>StyleTOC1</description>
		///       <description>â20</description>
		///       <description>StyleClosing</description>
		///       <description>â64</description>
		///     </item>
		///     <item>
		///       <description>StyleTOC2</description>
		///       <description>â21</description>
		///       <description>StyleSignature</description>
		///       <description>â65</description>
		///     </item>
		///     <item>
		///       <description>StyleTOC3</description>
		///       <description>â22</description>
		///       <description>StyleDefaultParagraphFont</description>
		///       <description>â66</description>
		///     </item>
		///     <item>
		///       <description>StyleTOC4</description>
		///       <description>â23</description>
		///       <description>StyleBodyText</description>
		///       <description>â67</description>
		///     </item>
		///     <item>
		///       <description>StyleTOC5</description>
		///       <description>â24</description>
		///       <description>StyleBodyTextIndent</description>
		///       <description>â68</description>
		///     </item>
		///     <item>
		///       <description>StyleTOC6</description>
		///       <description>â25</description>
		///       <description>StyleListContinue</description>
		///       <description>â69</description>
		///     </item>
		///     <item>
		///       <description>StyleTOC7</description>
		///       <description>â26</description>
		///       <description>StyleListContinue2</description>
		///       <description>â70</description>
		///     </item>
		///     <item>
		///       <description>StyleTOC8</description>
		///       <description>â27</description>
		///       <description>StyleListContinue3</description>
		///       <description>â71</description>
		///     </item>
		///     <item>
		///       <description>StyleTOC9</description>
		///       <description>â28</description>
		///       <description>StyleListContinue4</description>
		///       <description>â72</description>
		///     </item>
		///     <item>
		///       <description>StyleNormalIndent</description>
		///       <description>â29</description>
		///       <description>StyleListContinue5</description>
		///       <description>â73</description>
		///     </item>
		///     <item>
		///       <description>StyleFootnoteText</description>
		///       <description>â30</description>
		///       <description>StyleMessageHeader</description>
		///       <description>â74</description>
		///     </item>
		///     <item>
		///       <description>StyleAnnotationText</description>
		///       <description>â31</description>
		///       <description>StyleSubtitle</description>
		///       <description>â75</description>
		///     </item>
		///     <item>
		///       <description>StyleHeader</description>
		///       <description>â32</description>
		///       <description>StyleSalutation</description>
		///       <description>â76</description>
		///     </item>
		///     <item>
		///       <description>StyleFooter</description>
		///       <description>â33</description>
		///       <description>StyleDate</description>
		///       <description>â77</description>
		///     </item>
		///     <item>
		///       <description>StyleIndexHeading</description>
		///       <description>â34</description>
		///       <description>StyleBodyTextFirstIndent</description>
		///       <description>â78</description>
		///     </item>
		///     <item>
		///       <description>StyleCaption</description>
		///       <description>â35</description>
		///       <description>StyleBodyTextFirstIndent2</description>
		///       <description>â79</description>
		///     </item>
		///     <item>
		///       <description>StyleTableofFigures</description>
		///       <description>â36</description>
		///       <description>StyleNoteHeading</description>
		///       <description>â80</description>
		///     </item>
		///     <item>
		///       <description>StyleEnvelopeAddress</description>
		///       <description>â37</description>
		///       <description>StyleBodyText2</description>
		///       <description>â81</description>
		///     </item>
		///     <item>
		///       <description>StyleEnvelopeReturn</description>
		///       <description>â38</description>
		///       <description>StyleBodyText3</description>
		///       <description>â82</description>
		///     </item>
		///     <item>
		///       <description>StyleFootnoteReference</description>
		///       <description>â39</description>
		///       <description>StyleBodyTextIndent2</description>
		///       <description>â83</description>
		///     </item>
		///     <item>
		///       <description>StyleAnnotationReference</description>
		///       <description>â40</description>
		///       <description>StyleBodyTextIndent3</description>
		///       <description>â84</description>
		///     </item>
		///     <item>
		///       <description>StyleLineNumber</description>
		///       <description>â41</description>
		///       <description>StyleBlockQuotation</description>
		///       <description>â85</description>
		///     </item>
		///     <item>
		///       <description>StylePageNumber</description>
		///       <description>â42</description>
		///       <description>StyleHyperlink</description>
		///       <description>â86</description>
		///     </item>
		///     <item>
		///       <description>StyleEndnoteReference</description>
		///       <description>â43</description>
		///       <description>StyleHyperlinkFollowed</description>
		///       <description>â87</description>
		///     </item>
		///     <item>
		///       <description>StyleEndnoteText</description>
		///       <description>â44</description>
		///       <description>Â</description>
		///       <description>Â</description>
		///     </item>
		///   </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara-getstyle
		// HRESULT GetStyle( long *pValue );
		int GetStyle();

		/// <summary>Sets the paragraph style for the paragraphs in a range.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>New paragraph style handle. For a list of styles, see the Remarks section of ITextPara::GetStyle.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara-setstyle
		// HRESULT SetStyle( [in] long Value );
		void SetStyle(int Value);

		/// <summary>Retrieves the current paragraph alignment value.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>The paragraph alignment, which can be one of the following values.</para>
		///   <para>tomAlignLeft</para>
		///   <para>tomAlignCenter</para>
		///   <para>tomAlignRight</para>
		///   <para>tomAlignJustify</para>
		///   <para>tomAlignInterWord</para>
		///   <para>tomAlignNewspaper</para>
		///   <para>tomAlignInterLetter</para>
		///   <para>tomAlignScaled</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara-getalignment
		// HRESULT GetAlignment( long *pValue );
		tomConstants GetAlignment();

		/// <summary>Sets the paragraph alignment.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>New paragraph alignment. For a list of possible values, see the ITextPara::GetAlignment method.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara-setalignment
		// HRESULT SetAlignment( [in] long Value );
		void SetAlignment(tomConstants Value);

		/// <summary>Determines whether automatic hyphenation is enabled for the range.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A variable that is one of the following values:</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Automatic hyphenation is enabled.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Automatic hyphenation is disabled.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The hyphenation property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the PFE_DONOTHYPHEN effect described in the PARAFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara-gethyphenation
		// HRESULT GetHyphenation( long *pValue );
		tomConstants GetHyphenation();

		/// <summary>Controls hyphenation for the paragraphs in the range.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>Indicates how hyphenation is controlled. It can be one of the following possible values.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c></c> tomTrue</description>
		///       <description>Automatic hyphenation is enabled.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c> tomFalse</description>
		///       <description>Automatic hyphenation is disabled.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c> tomUndefined</description>
		///       <description>The hyphenation property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara-sethyphenation
		// HRESULT SetHyphenation( [in] long Value );
		void SetHyphenation(tomConstants Value);

		/// <summary>Retrieves the amount used to indent the first line of a paragraph relative to the left indent. The left indent is the indent for all lines of the paragraph except the first line.</summary>
		/// <returns>
		///   <para>Type: <c>float*</c></para>
		///   <para>The first-line indentation amount in floating-point points.</para>
		/// </returns>
		/// <remarks>
		///   <para>To set the first line indentation amount, call the ITextPara::SetIndents method.</para>
		///   <para>To get and set the indent for all other lines of the paragraph (that is, the left indent), use ITextPara::GetLeftIndent and ITextPara::SetIndents.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara-getfirstlineindent
		// HRESULT GetFirstLineIndent( float *pValue );
		float GetFirstLineIndent();

		/// <summary>Determines whether page breaks are allowed within paragraphs.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A variable that is one of the following values.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Page breaks are not allowed within a paragraph.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Page breaks are allowed within a paragraph.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the PFE_KEEP effect described in the PARAFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara-getkeeptogether
		// HRESULT GetKeepTogether( long *pValue );
		tomConstants GetKeepTogether();

		/// <summary>Controls whether page breaks are allowed within a paragraph in a range.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>Indicates whether page breaks are allowed within a paragraph in a range. It can be one of the following possible values.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c></c> tomTrue</description>
		///       <description>Page breaks are not allowed within a paragraph.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c> tomFalse</description>
		///       <description>Page breaks are allowed within a paragraph.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c> tomUndefined</description>
		///       <description>The property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		/// <remarks>This property corresponds to the PFE_KEEP effect described in the PARAFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara-setkeeptogether
		// HRESULT SetKeepTogether( [in] long Value );
		void SetKeepTogether(tomConstants Value);

		/// <summary>Determines whether page breaks are allowed between paragraphs in the range.</summary>
		/// <returns>
		///   <para>Type: <c>long*</c></para>
		///   <para>A variable that is one of the following values:</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c>tomTrue</c>
		///       </description>
		///       <description>Page breaks are not allowed between paragraphs.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomFalse</c>
		///       </description>
		///       <description>Page breaks are allowed between paragraphs.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c>tomUndefined</c>
		///       </description>
		///       <description>The property is undefined.</description>
		///     </item>
		///   </list>
		/// </returns>
		/// <remarks>This property corresponds to the PFE_KEEPNEXT effect described in the PARAFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara-getkeepwithnext
		// HRESULT GetKeepWithNext( long *pValue );
		int GetKeepWithNext();

		/// <summary>Controls whether page breaks are allowed between the paragraphs in a range.</summary>
		/// <param name="Value">
		///   <para>Type: <c>long</c></para>
		///   <para>Indicates if page breaks can be used between the paragraphs of a range. It can be one of the following possible values.</para>
		///   <list type="table">
		///     <listheader>
		///       <description>Value</description>
		///       <description>Meaning</description>
		///     </listheader>
		///     <item>
		///       <description>
		///         <c></c> tomTrue</description>
		///       <description>Page breaks are not allowed between paragraphs.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c> tomFalse</description>
		///       <description>Page breaks are allowed between paragraphs.</description>
		///     </item>
		///     <item>
		///       <description>
		///         <c></c> tomUndefined</description>
		///       <description>The property is undefined.</description>
		///     </item>
		///   </list>
		/// </param>
		/// <remarks>This property corresponds to the PFE_KEEPNEXT effect described in the PARAFORMAT2 structure.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara-setkeepwithnext
		// HRESULT SetKeepWithNext( [in] long Value );
		void SetKeepWithNext(tomConstants Value);

		float GetLeftIndent();

		float GetLineSpacing();

		int GetLineSpacingRule();

		int GetListAlignment();

		HRESULT SetListAlignment(int Value);

		int GetListLevelIndex();

		HRESULT SetListLevelIndex(int Value);

		int GetListStart();

		HRESULT SetListStart(int Value);

		float GetListTab();

		HRESULT SetListTab(float Value);

		int GetListType();

		HRESULT SetListType(int Value);

		int GetNoLineNumber();

		HRESULT SetNoLineNumber(int Value);

		int GetPageBreakBefore();

		HRESULT SetPageBreakBefore(int Value);

		float GetRightIndent();

		HRESULT SetRightIndent(float Value);

		HRESULT SetIndents(float First, float Left, float Right);

		HRESULT SetLineSpacing(int Rule, float Spacing);

		float GetSpaceAfter();

		HRESULT SetSpaceAfter(float Value);

		float GetSpaceBefore();

		HRESULT SetSpaceBefore(float Value);

		int GetWidowControl();

		HRESULT SetWidowControl(int Value);

		int GetTabCount();

		HRESULT AddTab(float tbPos, int tbAlign, int tbLeader);

		HRESULT ClearAllTabs();

		HRESULT DeleteTab(float tbPos);

		HRESULT GetTab(int iTab, out float ptbPos, out int ptbAlign, out int ptbLeader);
	}

	/// <summary>
	/// <para>Text Object Model (TOM) rich text-range attributes are accessed through a pair of dual interfaces, ITextFont and ITextPara.</para>
	/// <para>The <c>ITextPara2</c> interface extends ITextPara, providing the equivalent of the Microsoft Word format-paragraph dialog.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextpara2
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextPara2")]
	[ComImport, Guid("C241F5E4-7206-11D8-A2C7-00A0D1D6C6B3"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ITextPara2 : ITextPara
	{
		/// <summary>
		/// <para>Not implemented.</para>
		/// <para>Gets the borders collection.</para>
		/// </summary>
		/// <param name="ppBorders">
		/// <para>Type: <c>IUnknown**</c></para>
		/// <para>The borders collection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>NOERROR</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara2-getborders
		// HRESULT GetBorders( [out, retval] IUnknown **ppBorders );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object GetBorders();

		ITextPara2 GetDuplicate2();

		HRESULT SetDuplicate2([In, Optional] ITextPara2? pPara);

		int GetFontAlignment();

		HRESULT SetFontAlignment(int Value);

		int GetHangingPunctuation();

		HRESULT SetHangingPunctuation(int Value);

		int GetSnapToGrid();

		HRESULT SetSnapToGrid(int Value);

		int GetTrimPunctuationAtStart();

		HRESULT SetTrimPunctuationAtStart(int Value);

		HRESULT GetEffects(out int pValue, out int pMask);

		HRESULT GetProperty(int Type, out int pValue);

		HRESULT IsEqual2([In, Optional] ITextPara2? pPara, out int pB);

		HRESULT SetEffects(int Value, int Mask);

		HRESULT SetProperty(int Type, int Value);
	}

	/// <summary>The <c>ITextRange</c> objects are powerful editing and data-binding tools that allow a program to select text in a story and then examine or change that text.</summary>
	/// <remarks>
	/// <para>Multiple text ranges can be active and work cooperatively on the same story and evolve with the story. For example, if one text range deletes specified text before another text range, the latter tracks the change. In this sense, text ranges are similar to Microsoft Word bookmarks, which also track editing changes. However, bookmarks cannot edit text, while text ranges can. In addition, ranges let you manipulate text without changing the selection or Clipboard, both of which are valuable to end users. The ITextSelection interface inherits from <c>ITextRange</c> and adds some UI-oriented methods and properties as described in the section on <c>ITextSelection</c>.</para>
	/// <para>You can look at a text range using methods based on character positions. Specifically, a text range is characterized by:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>The <c>first</c> character position, <c>cpFirst</c>, which points at an insertion point immediately preceding the first character (relative to the beginning of the story) in the range.</description>
	/// </item>
	/// <item>
	/// <description>The <c>limit</c> position, <c>cpLim</c>, which points at an insertion point immediately following the last character in the range.</description>
	/// </item>
	/// </list>
	/// <para>The first character in a story has <c>cpFirst</c> = zero. If a <c>cp</c> argument has a value greater than the number of characters in the story, the number of characters in the story is used instead. If a <c>cp</c> argument is negative, zero is used instead. For those familiar with Microsoft Visual Basic for Applications, call the <c>cpFirst</c> property <c>Start</c> and the <c>cpLim</c> property <c>End</c> (even though the starting position of a range is also an end).</para>
	/// <para>In the following figure, character positions are represented by the lines separating the letters. The corresponding character position values are given beneath the lines. The range starting at <c>cpFirst</c> = 5 and ending at <c>cpLim</c> = 7 contains the two-letter word is. If this figure depicts the complete text in a story, the story length is 30.</para>
	/// <para>The <c>length</c> of a range is given by <c>cpLim</c> - <c>cpFirst</c> or equivalently by End - Start. A range with zero length is called a <c>degenerate</c> or <c>empty</c> range and has equal <c>cp</c>* values, that is, <c>cpFirst</c> = <c>cpLim</c>. An example of a degenerate range is the current insertion point. A non-null selection is an example of a nondegenerate range.</para>
	/// <para>Suppose that the range from 5 to 7 indicated by shaded cells in the preceding figure is told to delete its text (see Delete), thereby turning itself into an insertion point. The range from 25 to 29 would automatically track its contents, namely the word text. The following figure shows the result.</para>
	/// <para>In this figure, the range for text now has been <c>automatically</c> adjusted to have <c>cpFirst</c> = 23 and <c>cpLim</c> = 27. The owner of the range does not have to worry about updating the range character position values in the face of editing.</para>
	/// <para>The names of the move methods indicate which end to move, but note that if any method attempts to move one range end past the other, both ends get moved to the target position. As a result, the insertion point is at the target position. The concept is that <c>cpFirst</c> and <c>cpLim</c> always have to obey the fundamental condition</para>
	/// <para>0 &lt;= <c>cpFirst</c> &lt;= <c>cpLim</c> &lt;= # characters in story</para>
	/// <para>or equivalently for a range <c>r</c>, 0 &lt;= <c>r</c>.Start &lt;= <c>r</c>.End &lt;= <c>r</c>.StoryLength, which is what you would expect from the names of these quantities.</para>
	/// <para>Another important feature is that all stories contain an undeletable final CR (0xD) character at the end. So even an empty story has a single character, namely the final CR. A range can select this character, but cannot become an insertion point beyond it. To see how this works, try selecting the final CR in a Word document and then press the RIGHT ARROW key to collapse it. The directory tree will collapse before the final CR, but the CR cannot be deleted. The Text Object Model (TOM) functions the same way. So, if <c>r</c>.Start &lt;= <c>r</c>.End, then <c>r</c>.End &lt;= (<c>r</c>.StoryLength â 1). For a discussion about deleting a CR, see Delete.</para>
	/// <para>Some methods depend on a <c>Unit</c> argument, which can take on the predefined values listed in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Unit</description>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description>tomCharacter</description>
	/// <description>1</description>
	/// <description>Character.</description>
	/// </item>
	/// <item>
	/// <description>tomWord</description>
	/// <description>2</description>
	/// <description>Word.</description>
	/// </item>
	/// <item>
	/// <description>tomSentence</description>
	/// <description>3</description>
	/// <description>Sentence.</description>
	/// </item>
	/// <item>
	/// <description>tomParagraph</description>
	/// <description>4</description>
	/// <description>Paragraph.</description>
	/// </item>
	/// <item>
	/// <description>tomLine</description>
	/// <description>5</description>
	/// <description>Line (on display).</description>
	/// </item>
	/// <item>
	/// <description>tomStory</description>
	/// <description>6</description>
	/// <description>Story.</description>
	/// </item>
	/// <item>
	/// <description>tomScreen</description>
	/// <description>7</description>
	/// <description>Screen (as for PAGE UP/PAGE DOWN).</description>
	/// </item>
	/// <item>
	/// <description>tomSection</description>
	/// <description>8</description>
	/// <description>Section.</description>
	/// </item>
	/// <item>
	/// <description>tomColumn</description>
	/// <description>9</description>
	/// <description>Table column.</description>
	/// </item>
	/// <item>
	/// <description>tomRow</description>
	/// <description>10</description>
	/// <description>Table row.</description>
	/// </item>
	/// <item>
	/// <description>tomWindow</description>
	/// <description>11</description>
	/// <description>Upper-left or lower-right of the window.</description>
	/// </item>
	/// <item>
	/// <description>tomCell</description>
	/// <description>12</description>
	/// <description>Table cell.</description>
	/// </item>
	/// <item>
	/// <description>tomCharFormat</description>
	/// <description>13</description>
	/// <description>Run of constant character formatting.</description>
	/// </item>
	/// <item>
	/// <description>tomParaFormat</description>
	/// <description>14</description>
	/// <description>Run of constant paragraph formatting.</description>
	/// </item>
	/// <item>
	/// <description>tomTable</description>
	/// <description>15</description>
	/// <description>Table.</description>
	/// </item>
	/// <item>
	/// <description>tomObject</description>
	/// <description>16</description>
	/// <description>Embedded object.</description>
	/// </item>
	/// </list>
	/// <para>Â</para>
	/// <para>Most of the <c>Unit</c> values are self-explanatory. However the following descriptions are provided for additional clarity.</para>
	/// <para>tomWord</para>
	/// <para>The tomWord constant is an end of paragraph or a span of alphanumerics or punctuation including any blanks that follow. To get an on-screen feel for tomWord, watch how the caret moves when you press CTRL+RIGHT ARROW (â&gt;) or CTRL+LEFT ARROW (&lt;â) in a Word document.</para>
	/// <para>tomSentence</para>
	/// <para>The tomSentence constant describes a string of text that ends with a period, question mark, or exclamation mark and is followed either by one or more ASCII white space characters (9 through 0xd and 0x20), or the Unicode paragraph separator (0x2029). The trailing white space is part of the sentence. The last sentence in a story does not need to have a period, question mark, or exclamation mark. The start of a story qualifies as the start of a tomSentence, even if the string there does not qualify as a sentence grammatically. Other sentences must follow a sentence end and cannot begin with a period, question mark, or exclamation mark.</para>
	/// <para>tomParagraph</para>
	/// <para>The tomParagraph constant is a string of text terminated by an end-of-paragraph mark (CRLF, CR, VT (for SHIFT+ENTER), LF, FF, or 0x2029). TOM engines always have an undeletable end-of-paragraph mark at the end of a story. Thus, all TOM stories automatically have at least one tomWord, one tomSentence, and one tomParagraph.</para>
	/// <para>tomLine</para>
	/// <para>The tomLine constant corresponds to one line of text on a display, provided that a display is associated with the range. If no display is associated with a range, tomLine is treated as tomParagraph. A selection automatically has a display and a range that is a duplicate (see GetDuplicate). Other ranges may not have a display, depending on the TOM engine and context.</para>
	/// <para>Methods that move one or both ends in terms of <c>Unit</c>, such as Move, MoveEnd, and MoveStart, depend on the signed <c>Count</c> argument. Except for the ITextSelection geometrical movement commands, if <c>Count</c> is greater than zero, the ends to be moved are moved forward (toward the end of the story), and if <c>Count</c> is less than zero, the ends are moved backward (toward the beginning). The default value of <c>Count</c> for these <c>Move</c> methods is 1. These methods attempt to move <c>Count Units</c>, but movement is never beyond the ends of the story.</para>
	/// <para>Methods that move one or both ends by matching character strings or string patterns, such as MoveWhile, MoveEndWhile, and MoveStartWhile, can move up to a maximum number of characters given by the signed <c>Count</c> argument. If <c>Count</c> is greater than zero, the ends to be moved are moved forward, and if <c>Count</c> is less than zero, the ends are moved backward. Two special <c>Count</c> values, tomForward and tomBackward, are defined. These values are guaranteed to reach the end and the start of the story, respectively. The default value of <c>Count</c> is tomForward.</para>
	/// <para>In <c>Move</c>* methods that turn a nondegenerate range into a degenerate one, such as Move, MoveWhile, and MoveUntil, <c>cpFirst</c> is changed if <c>Count</c> is negative and <c>cpLim</c> is changed if <c>Count</c> is positive. After this movement, the other end of the range is also moved to the new location. See the individual methods for more specific <c>Count</c> information. For nondegenerate ranges, the methods MoveStart, MoveEnd, MoveStartWhile, MoveEndWhile, MoveStartUntil and MoveEndUntil move either the starting position (Start) or the ending position (End).</para>
	/// <para>To select a unit that corresponds to a contiguous range, such as a tomWord, tomSentence, and tomParagraph, use the MoveEnd method. To select a unit that corresponds to a noncontiguous range, such as tomObject, use the EndOf method, since the next object may occur after substantial intermediate text, if at all. To select a tomCell unit, the range must be inside a table.</para>
	/// <para>Examples and further explanation of the <c>Count</c> and <c>Unit</c> arguments follow. Note that TOM engines may not support all of the units in the table above. For example, rich edit controls do not offer the concepts of sections, but rather return E_NOTIMPL when given tomSection. However if a TOM engine does support a unit, it has the index value given in the table.</para>
	/// <para>Applications typically do not implement the <c>ITextRange</c> interface. Microsoft text solutions, such as rich edit controls, implement <c>ITextRange</c> as part of their TOM implementation.</para>
	/// <para>Applications can retrieve an <c>ITextRange</c> pointer by calling the Range method.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextrange
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextRange")]
	[ComImport, Guid("8CC497C2-A1DF-11ce-8098-00AA0047BE5D"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ITextRange
	{
		HRESULT GetText([MarshalAs(UnmanagedType.BStr)] out string pbstr);

		HRESULT SetText([MarshalAs(UnmanagedType.BStr)] string bstr);

		int GetChar();

		HRESULT SetChar(int Char);

		ITextRange GetDuplicate();

		ITextRange GetFormattedText();

		HRESULT SetFormattedText([In, Optional] ITextRange? pRange);

		int GetStart();

		HRESULT SetStart(int cpFirst);

		int GetEnd();

		HRESULT SetEnd(int cpLim);

		ITextFont GetFont();

		HRESULT SetFont([In, Optional] ITextFont? pFont);

		ITextPara GetPara();

		HRESULT SetPara([In, Optional] ITextPara? pPara);

		int GetStoryLength();

		int GetStoryType();

		HRESULT Collapse(int bStart);

		HRESULT Expand(int Unit, out int pDelta);

		HRESULT GetIndex(int Unit, out int pIndex);

		HRESULT SetIndex(int Unit, int Index, int Extend);

		HRESULT SetRange(int cpAnchor, int cpActive);

		HRESULT InRange([In, Optional] ITextRange? pRange, out int pValue);

		HRESULT InStory([In, Optional] ITextRange? pRange, out int pValue);

		HRESULT IsEqual([In, Optional] ITextRange? pRange, out int pValue);

		HRESULT Select();

		HRESULT StartOf(int Unit, int Extend, out int pDelta);

		HRESULT EndOf(int Unit, int Extend, out int pDelta);

		HRESULT Move(int Unit, int Count, out int pDelta);

		HRESULT MoveStart(int Unit, int Count, out int pDelta);

		HRESULT MoveEnd(int Unit, int Count, out int pDelta);

		HRESULT MoveWhile([In] object Cset, int Count, out int pDelta);

		HRESULT MoveStartWhile([In] object Cset, int Count, out int pDelta);

		HRESULT MoveEndWhile([In] object Cset, int Count, out int pDelta);

		HRESULT MoveUntil([In] object Cset, int Count, out int pDelta);

		HRESULT MoveStartUntil([In] object Cset, int Count, out int pDelta);

		HRESULT MoveEndUntil([In] object Cset, int Count, out int pDelta);

		HRESULT FindText([MarshalAs(UnmanagedType.BStr)] string bstr, int Count, int Flags, out int pLength);

		HRESULT FindTextStart([MarshalAs(UnmanagedType.BStr)] string bstr, int Count, int Flags, out int pLength);

		HRESULT FindTextEnd([MarshalAs(UnmanagedType.BStr)] string bstr, int Count, int Flags, out int pLength);

		HRESULT Delete(int Unit, int Count, out int pDelta);

		HRESULT Cut(out VARIANT pVar);

		HRESULT Copy(out VARIANT pVar);

		HRESULT Paste([In] object pVar, int Format);

		HRESULT CanPaste([In] object pVar, int Format, out int pValue);

		HRESULT CanEdit(out int pValue);

		HRESULT ChangeCase(int Type);

		HRESULT GetPoint(int Type, out int px, out int py);

		HRESULT SetPoint(int x, int y, int Type, int Extend);

		HRESULT ScrollIntoView(int Value);

		/// <summary>Retrieves a pointer to the embedded object at the start of the specified range, that is, at <c>cpFirst</c>. The range must either be an insertion point or it must select only the embedded object.</summary>
		/// <returns>
		///   <para>Type: <c>IUnknown**</c></para>
		///   <para>The pointer to the object.</para>
		/// </returns>
		/// <remarks>If the start of this range does not have an embedded object or if the range selects more than a single object, <c>ppObject</c> is set equal to <c>NULL</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextrange-getembeddedobject
		// HRESULT GetEmbeddedObject( IUnknown **ppObject );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object GetEmbeddedObject();
	}

	/// <summary>
	/// <para>Text Object Model (TOM) rich text-range attributes are accessed through a pair of dual interfaces, ITextFont and ITextPara.</para>
	/// <para>The <c>ITextPara2</c> interface extends ITextPara, providing the equivalent of the Microsoft Word format-paragraph dialog.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextpara2
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextPara2")]
	[ComImport, Guid("C241F5E4-7206-11D8-A2C7-00A0D1D6C6B3"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ITextPara2 : ITextPara
	{
		/// <summary>
		/// <para>Not implemented.</para>
		/// <para>Gets the borders collection.</para>
		/// </summary>
		/// <param name="ppBorders">
		/// <para>Type: <c>IUnknown**</c></para>
		/// <para>The borders collection.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>NOERROR</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextpara2-getborders
		// HRESULT GetBorders( [out, retval] IUnknown **ppBorders );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object GetBorders();

		ITextPara2 GetDuplicate2();

		HRESULT SetDuplicate2([In, Optional] ITextPara2? pPara);

		int GetFontAlignment();

		HRESULT SetFontAlignment(int Value);

		int GetHangingPunctuation();

		HRESULT SetHangingPunctuation(int Value);

		int GetSnapToGrid();

		HRESULT SetSnapToGrid(int Value);

		int GetTrimPunctuationAtStart();

		HRESULT SetTrimPunctuationAtStart(int Value);

		HRESULT GetEffects(out int pValue, out int pMask);

		HRESULT GetProperty(int Type, out int pValue);

		HRESULT IsEqual2([In, Optional] ITextPara2? pPara, out int pB);

		HRESULT SetEffects(int Value, int Mask);

		HRESULT SetProperty(int Type, int Value);
	}

	/// <summary>The <c>ITextRange</c> objects are powerful editing and data-binding tools that allow a program to select text in a story and then examine or change that text.</summary>
	/// <remarks>
	/// <para>Multiple text ranges can be active and work cooperatively on the same story and evolve with the story. For example, if one text range deletes specified text before another text range, the latter tracks the change. In this sense, text ranges are similar to Microsoft Word bookmarks, which also track editing changes. However, bookmarks cannot edit text, while text ranges can. In addition, ranges let you manipulate text without changing the selection or Clipboard, both of which are valuable to end users. The ITextSelection interface inherits from <c>ITextRange</c> and adds some UI-oriented methods and properties as described in the section on <c>ITextSelection</c>.</para>
	/// <para>You can look at a text range using methods based on character positions. Specifically, a text range is characterized by:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>The <c>first</c> character position, <c>cpFirst</c>, which points at an insertion point immediately preceding the first character (relative to the beginning of the story) in the range.</description>
	/// </item>
	/// <item>
	/// <description>The <c>limit</c> position, <c>cpLim</c>, which points at an insertion point immediately following the last character in the range.</description>
	/// </item>
	/// </list>
	/// <para>The first character in a story has <c>cpFirst</c> = zero. If a <c>cp</c> argument has a value greater than the number of characters in the story, the number of characters in the story is used instead. If a <c>cp</c> argument is negative, zero is used instead. For those familiar with Microsoft Visual Basic for Applications, call the <c>cpFirst</c> property <c>Start</c> and the <c>cpLim</c> property <c>End</c> (even though the starting position of a range is also an end).</para>
	/// <para>In the following figure, character positions are represented by the lines separating the letters. The corresponding character position values are given beneath the lines. The range starting at <c>cpFirst</c> = 5 and ending at <c>cpLim</c> = 7 contains the two-letter word is. If this figure depicts the complete text in a story, the story length is 30.</para>
	/// <para>The <c>length</c> of a range is given by <c>cpLim</c> - <c>cpFirst</c> or equivalently by End - Start. A range with zero length is called a <c>degenerate</c> or <c>empty</c> range and has equal <c>cp</c>* values, that is, <c>cpFirst</c> = <c>cpLim</c>. An example of a degenerate range is the current insertion point. A non-null selection is an example of a nondegenerate range.</para>
	/// <para>Suppose that the range from 5 to 7 indicated by shaded cells in the preceding figure is told to delete its text (see Delete), thereby turning itself into an insertion point. The range from 25 to 29 would automatically track its contents, namely the word text. The following figure shows the result.</para>
	/// <para>In this figure, the range for text now has been <c>automatically</c> adjusted to have <c>cpFirst</c> = 23 and <c>cpLim</c> = 27. The owner of the range does not have to worry about updating the range character position values in the face of editing.</para>
	/// <para>The names of the move methods indicate which end to move, but note that if any method attempts to move one range end past the other, both ends get moved to the target position. As a result, the insertion point is at the target position. The concept is that <c>cpFirst</c> and <c>cpLim</c> always have to obey the fundamental condition</para>
	/// <para>0 &lt;= <c>cpFirst</c> &lt;= <c>cpLim</c> &lt;= # characters in story</para>
	/// <para>or equivalently for a range <c>r</c>, 0 &lt;= <c>r</c>.Start &lt;= <c>r</c>.End &lt;= <c>r</c>.StoryLength, which is what you would expect from the names of these quantities.</para>
	/// <para>Another important feature is that all stories contain an undeletable final CR (0xD) character at the end. So even an empty story has a single character, namely the final CR. A range can select this character, but cannot become an insertion point beyond it. To see how this works, try selecting the final CR in a Word document and then press the RIGHT ARROW key to collapse it. The directory tree will collapse before the final CR, but the CR cannot be deleted. The Text Object Model (TOM) functions the same way. So, if <c>r</c>.Start &lt;= <c>r</c>.End, then <c>r</c>.End &lt;= (<c>r</c>.StoryLength â 1). For a discussion about deleting a CR, see Delete.</para>
	/// <para>Some methods depend on a <c>Unit</c> argument, which can take on the predefined values listed in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Unit</description>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description>tomCharacter</description>
	/// <description>1</description>
	/// <description>Character.</description>
	/// </item>
	/// <item>
	/// <description>tomWord</description>
	/// <description>2</description>
	/// <description>Word.</description>
	/// </item>
	/// <item>
	/// <description>tomSentence</description>
	/// <description>3</description>
	/// <description>Sentence.</description>
	/// </item>
	/// <item>
	/// <description>tomParagraph</description>
	/// <description>4</description>
	/// <description>Paragraph.</description>
	/// </item>
	/// <item>
	/// <description>tomLine</description>
	/// <description>5</description>
	/// <description>Line (on display).</description>
	/// </item>
	/// <item>
	/// <description>tomStory</description>
	/// <description>6</description>
	/// <description>Story.</description>
	/// </item>
	/// <item>
	/// <description>tomScreen</description>
	/// <description>7</description>
	/// <description>Screen (as for PAGE UP/PAGE DOWN).</description>
	/// </item>
	/// <item>
	/// <description>tomSection</description>
	/// <description>8</description>
	/// <description>Section.</description>
	/// </item>
	/// <item>
	/// <description>tomColumn</description>
	/// <description>9</description>
	/// <description>Table column.</description>
	/// </item>
	/// <item>
	/// <description>tomRow</description>
	/// <description>10</description>
	/// <description>Table row.</description>
	/// </item>
	/// <item>
	/// <description>tomWindow</description>
	/// <description>11</description>
	/// <description>Upper-left or lower-right of the window.</description>
	/// </item>
	/// <item>
	/// <description>tomCell</description>
	/// <description>12</description>
	/// <description>Table cell.</description>
	/// </item>
	/// <item>
	/// <description>tomCharFormat</description>
	/// <description>13</description>
	/// <description>Run of constant character formatting.</description>
	/// </item>
	/// <item>
	/// <description>tomParaFormat</description>
	/// <description>14</description>
	/// <description>Run of constant paragraph formatting.</description>
	/// </item>
	/// <item>
	/// <description>tomTable</description>
	/// <description>15</description>
	/// <description>Table.</description>
	/// </item>
	/// <item>
	/// <description>tomObject</description>
	/// <description>16</description>
	/// <description>Embedded object.</description>
	/// </item>
	/// </list>
	/// <para>Â</para>
	/// <para>Most of the <c>Unit</c> values are self-explanatory. However the following descriptions are provided for additional clarity.</para>
	/// <para>tomWord</para>
	/// <para>The tomWord constant is an end of paragraph or a span of alphanumerics or punctuation including any blanks that follow. To get an on-screen feel for tomWord, watch how the caret moves when you press CTRL+RIGHT ARROW (â&gt;) or CTRL+LEFT ARROW (&lt;â) in a Word document.</para>
	/// <para>tomSentence</para>
	/// <para>The tomSentence constant describes a string of text that ends with a period, question mark, or exclamation mark and is followed either by one or more ASCII white space characters (9 through 0xd and 0x20), or the Unicode paragraph separator (0x2029). The trailing white space is part of the sentence. The last sentence in a story does not need to have a period, question mark, or exclamation mark. The start of a story qualifies as the start of a tomSentence, even if the string there does not qualify as a sentence grammatically. Other sentences must follow a sentence end and cannot begin with a period, question mark, or exclamation mark.</para>
	/// <para>tomParagraph</para>
	/// <para>The tomParagraph constant is a string of text terminated by an end-of-paragraph mark (CRLF, CR, VT (for SHIFT+ENTER), LF, FF, or 0x2029). TOM engines always have an undeletable end-of-paragraph mark at the end of a story. Thus, all TOM stories automatically have at least one tomWord, one tomSentence, and one tomParagraph.</para>
	/// <para>tomLine</para>
	/// <para>The tomLine constant corresponds to one line of text on a display, provided that a display is associated with the range. If no display is associated with a range, tomLine is treated as tomParagraph. A selection automatically has a display and a range that is a duplicate (see GetDuplicate). Other ranges may not have a display, depending on the TOM engine and context.</para>
	/// <para>Methods that move one or both ends in terms of <c>Unit</c>, such as Move, MoveEnd, and MoveStart, depend on the signed <c>Count</c> argument. Except for the ITextSelection geometrical movement commands, if <c>Count</c> is greater than zero, the ends to be moved are moved forward (toward the end of the story), and if <c>Count</c> is less than zero, the ends are moved backward (toward the beginning). The default value of <c>Count</c> for these <c>Move</c> methods is 1. These methods attempt to move <c>Count Units</c>, but movement is never beyond the ends of the story.</para>
	/// <para>Methods that move one or both ends by matching character strings or string patterns, such as MoveWhile, MoveEndWhile, and MoveStartWhile, can move up to a maximum number of characters given by the signed <c>Count</c> argument. If <c>Count</c> is greater than zero, the ends to be moved are moved forward, and if <c>Count</c> is less than zero, the ends are moved backward. Two special <c>Count</c> values, tomForward and tomBackward, are defined. These values are guaranteed to reach the end and the start of the story, respectively. The default value of <c>Count</c> is tomForward.</para>
	/// <para>In <c>Move</c>* methods that turn a nondegenerate range into a degenerate one, such as Move, MoveWhile, and MoveUntil, <c>cpFirst</c> is changed if <c>Count</c> is negative and <c>cpLim</c> is changed if <c>Count</c> is positive. After this movement, the other end of the range is also moved to the new location. See the individual methods for more specific <c>Count</c> information. For nondegenerate ranges, the methods MoveStart, MoveEnd, MoveStartWhile, MoveEndWhile, MoveStartUntil and MoveEndUntil move either the starting position (Start) or the ending position (End).</para>
	/// <para>To select a unit that corresponds to a contiguous range, such as a tomWord, tomSentence, and tomParagraph, use the MoveEnd method. To select a unit that corresponds to a noncontiguous range, such as tomObject, use the EndOf method, since the next object may occur after substantial intermediate text, if at all. To select a tomCell unit, the range must be inside a table.</para>
	/// <para>Examples and further explanation of the <c>Count</c> and <c>Unit</c> arguments follow. Note that TOM engines may not support all of the units in the table above. For example, rich edit controls do not offer the concepts of sections, but rather return E_NOTIMPL when given tomSection. However if a TOM engine does support a unit, it has the index value given in the table.</para>
	/// <para>Applications typically do not implement the <c>ITextRange</c> interface. Microsoft text solutions, such as rich edit controls, implement <c>ITextRange</c> as part of their TOM implementation.</para>
	/// <para>Applications can retrieve an <c>ITextRange</c> pointer by calling the Range method.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextrange
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextRange")]
	[ComImport, Guid("8CC497C2-A1DF-11ce-8098-00AA0047BE5D"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ITextRange
	{
		HRESULT GetText([MarshalAs(UnmanagedType.BStr)] out string pbstr);

		HRESULT SetText([MarshalAs(UnmanagedType.BStr)] string bstr);

		int GetChar();

		HRESULT SetChar(int Char);

		ITextRange GetDuplicate();

		ITextRange GetFormattedText();

		HRESULT SetFormattedText([In, Optional] ITextRange? pRange);

		int GetStart();

		HRESULT SetStart(int cpFirst);

		int GetEnd();

		HRESULT SetEnd(int cpLim);

		ITextFont GetFont();

		HRESULT SetFont([In, Optional] ITextFont? pFont);

		ITextPara GetPara();

		HRESULT SetPara([In, Optional] ITextPara? pPara);

		int GetStoryLength();

		int GetStoryType();

		HRESULT Collapse(int bStart);

		HRESULT Expand(int Unit, out int pDelta);

		HRESULT GetIndex(int Unit, out int pIndex);

		HRESULT SetIndex(int Unit, int Index, int Extend);

		HRESULT SetRange(int cpAnchor, int cpActive);

		HRESULT InRange([In, Optional] ITextRange? pRange, out int pValue);

		HRESULT InStory([In, Optional] ITextRange? pRange, out int pValue);

		HRESULT IsEqual([In, Optional] ITextRange? pRange, out int pValue);

		HRESULT Select();

		HRESULT StartOf(int Unit, int Extend, out int pDelta);

		HRESULT EndOf(int Unit, int Extend, out int pDelta);

		HRESULT Move(int Unit, int Count, out int pDelta);

		HRESULT MoveStart(int Unit, int Count, out int pDelta);

		HRESULT MoveEnd(int Unit, int Count, out int pDelta);

		HRESULT MoveWhile([In] object Cset, int Count, out int pDelta);

		HRESULT MoveStartWhile([In] object Cset, int Count, out int pDelta);

		HRESULT MoveEndWhile([In] object Cset, int Count, out int pDelta);

		HRESULT MoveUntil([In] object Cset, int Count, out int pDelta);

		HRESULT MoveStartUntil([In] object Cset, int Count, out int pDelta);

		HRESULT MoveEndUntil([In] object Cset, int Count, out int pDelta);

		HRESULT FindText([MarshalAs(UnmanagedType.BStr)] string bstr, int Count, int Flags, out int pLength);

		HRESULT FindTextStart([MarshalAs(UnmanagedType.BStr)] string bstr, int Count, int Flags, out int pLength);

		HRESULT FindTextEnd([MarshalAs(UnmanagedType.BStr)] string bstr, int Count, int Flags, out int pLength);

		HRESULT Delete(int Unit, int Count, out int pDelta);

		HRESULT Cut(out VARIANT pVar);

		HRESULT Copy(out VARIANT pVar);

		HRESULT Paste([In] object pVar, int Format);

		HRESULT CanPaste([In] object pVar, int Format, out int pValue);

		HRESULT CanEdit(out int pValue);

		HRESULT ChangeCase(int Type);

		HRESULT GetPoint(int Type, out int px, out int py);

		HRESULT SetPoint(int x, int y, int Type, int Extend);

		HRESULT ScrollIntoView(int Value);

		[return: MarshalAs(UnmanagedType.IUnknown)]
		object GetEmbeddedObject();
	}

	/// <summary>The <c>ITextRange2</c> interface is derived from ITextRange, and its objects are powerful editing and data-binding tools that enable a program to select text in a story and then examine or change that text.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextrange2
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextRange2")]
	[ComImport, Guid("C241F5E2-7206-11D8-A2C7-00A0D1D6C6B3"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ITextRange2 : ITextSelection
	{
		int GetCch();

		/// <summary>
		/// <para>Not implemented.</para>
		/// <para>Gets a cells object with the parameters of cells in the currently selected table row or column.</para>
		/// </summary>
		/// <param name="ppCells">
		/// <para>Type: <c>IUnknown**</c></para>
		/// <para>The cells object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>NOERROR</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextrange2-getcells
		// HRESULT GetCells( [out, retval] IUnknown **ppCells );
		[return: MarshalAs(UnmanagedType.IUnknown)] 
		object GetCells();

		[return: MarshalAs(UnmanagedType.IUnknown)]
		object GetColumn();

		int GetCount();

		ITextRange2 GetDuplicate2();

		ITextFont2 GetFont2();

		HRESULT SetFont2([In, Optional] ITextFont2? pFont);

		ITextRange2 GetFormattedText2();

		HRESULT SetFormattedText2([In, Optional] ITextRange2? pRange);

		int GetGravity();

		HRESULT SetGravity(int Value);

		ITextPara2 GetPara2();

		HRESULT SetPara2([In, Optional] ITextPara2? pPara);

		ITextRow GetRow();

		int GetStartPara();

		[return: MarshalAs(UnmanagedType.IUnknown)] 
		object GetTable();

		HRESULT GetURL([MarshalAs(UnmanagedType.BStr)] out string pbstr);

		HRESULT SetURL([MarshalAs(UnmanagedType.BStr)] string bstr);

		HRESULT AddSubrange(int cp1, int cp2, int Activate);

		HRESULT BuildUpMath(int Flags);

		HRESULT DeleteSubrange(int cpFirst, int cpLim);

		HRESULT Find([In, Optional] ITextRange2? pRange, int Count, int Flags, out int pDelta);

		HRESULT GetChar2(out int pChar, int Offset);

		HRESULT GetDropCap(out int pcLine, out int pPosition);

		HRESULT GetInlineObject(out int pType, out int pAlign, out int pChar, out int pChar1, out int pChar2, out int pCount, out int pTeXStyle, out int pcCol, out int pLevel);

		HRESULT GetProperty(int Type, out int pValue);

		HRESULT GetRect(int Type, out int pLeft, out int pTop, out int pRight, out int pBottom, out int pHit);

		HRESULT GetSubrange(int iSubrange, out int pcpFirst, out int pcpLim);

		HRESULT GetText2(int Flags, [MarshalAs(UnmanagedType.BStr)] out string pbstr);

		HRESULT HexToUnicode();

		HRESULT InsertTable(int cCol, int cRow, int AutoFit);

		HRESULT Linearize(int Flags);

		HRESULT SetActiveSubrange(int cpAnchor, int cpActive);

		HRESULT SetDropCap(int cLine, int Position);

		HRESULT SetProperty(int Type, int Value);

		HRESULT SetText2(int Flags, [MarshalAs(UnmanagedType.BStr)] string bstr);

		HRESULT UnicodeToHex();

		HRESULT SetInlineObject(int Type, int Align, int Char, int Char1, int Char2, int Count, int TeXStyle, int cCol);

		HRESULT GetMathFunctionType([MarshalAs(UnmanagedType.BStr)] string bstr, out int pValue);

		HRESULT InsertImage(int width, int height, int ascent, int Type, [MarshalAs(UnmanagedType.BStr)] string bstrAltText, [In, Optional] IStream? pStream);
	}

	/// <summary>The <c>ITextRow</c> interface provides methods to insert one or more identical table rows, and to retrieve and change table row properties. To insert nonidentical rows, call ITextRow::Insert for each different row configuration.</summary>
	/// <remarks>
	/// <para>To select a table, a row, or a cell, use ITextRange::Expand, with the <c>Unit</c> parameter set to <c>tomTable</c>, <c>tomRow</c>, or <c>tomCell</c>, respectively. These units can also be used with the ITextRange::Move methods to navigate and select multiple rows or cells.</para>
	/// <para>Some of the <c>ITextRow</c> properties apply to the whole row, such as the row alignment. In addition, there are a number of properties, such as cell alignment, that apply to a cell with the index set via the ITextRow::SetCellIndex method. This cell is referred to as the active cell.</para>
	/// <para><c>ITextRow</c> works similarly to ITextPara2, but doesn't modify the document until either the ITextRow::Apply or ITextRow::Insert methods are called. In addition, the row and cell parameters are always active, that is, they cannot have the value <c>tomDefault</c>.</para>
	/// <para>On initialization, the <c>ITextRow</c> object acquires the table row properties, if any, at the active end of the associated ITextRange2. The ITextRow::Reset method can be used to update these properties to the current values for <c>ITextRange2</c> object.</para>
	/// <para>A rich edit control table consists of a sequence of table rows, which, in turn, consist of sequences of paragraphs. A table row starts with the special two-character delimiter paragraph U+FFF9 U+000D and ends with the two-character delimiter paragraph U+FFFB U+000D. Each cell is terminated by the cell mark U+0007, which is treated as a hard end-of-paragraph mark just as U+000D (CR) is. The table row and cell parameters are treated as special paragraph formatting of the table-row delimiters. The cell parameters are stored in an expanded version of the tabs array. This format allows tables to be nested within other tables and is allowed to go fifteen levels deep.</para>
	/// <para>The architecture is quite flexible in that each table row can have any valid table-row parameters, regardless of the parameters for other rows (except for vertical merge flags). For example, the number of cells and the start indents of table rows can differ, unlike in HTML which has nÃm rectangular format with all rows starting at the same indent.</para>
	/// <para>On the other hand, no formal table description is stored anywhere. Information such as the number of rows must be figured out by navigating through the table. For example, the count of rows in a table can be obtained by calling ITextRange::StartOf (<c>tomTable</c>, <c>tomFalse</c>, <c>NULL</c>) to move to the start of the current table and then calling ITextRange::Move (<c>tomRow</c>, <c>tomForward</c>, <c>&amp;dcRow</c>). The quantity <c>&amp;dcRow</c> + 1 then contains the count of rows in the table, because moving by <c>tomRow</c> increments doesn't move beyond the last table row.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextrow
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextRow")]
	[ComImport, Guid("C241F5EF-7206-11D8-A2C7-00A0D1D6C6B3"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ITextRow
	{
		int GetAlignment();

		HRESULT SetAlignment(int Value);

		int GetCellCount();

		HRESULT SetCellCount(int Value);

		int GetCellCountCache();

		HRESULT SetCellCountCache(int Value);

		int GetCellIndex();

		HRESULT SetCellIndex(int Value);

		int GetCellMargin();

		HRESULT SetCellMargin(int Value);

		int GetHeight();

		HRESULT SetHeight(int Value);

		int GetIndent();

		HRESULT SetIndent(int Value);

		int GetKeepTogether();

		HRESULT SetKeepTogether(int Value);

		int GetKeepWithNext();

		HRESULT SetKeepWithNext(int Value);

		int GetNestLevel();

		int GetRTL();

		HRESULT SetRTL(int Value);

		int GetCellAlignment();

		HRESULT SetCellAlignment(int Value);

		int GetCellColorBack();

		HRESULT SetCellColorBack(int Value);

		int GetCellColorFore();

		HRESULT SetCellColorFore(int Value);

		int GetCellMergeFlags();

		HRESULT SetCellMergeFlags(int Value);

		int GetCellShading();

		HRESULT SetCellShading(int Value);

		int GetCellVerticalText();

		HRESULT SetCellVerticalText(int Value);

		int GetCellWidth();

		HRESULT SetCellWidth(int Value);

		HRESULT GetCellBorderColors(out int pcrLeft, out int pcrTop, out int pcrRight, out int pcrBottom);

		HRESULT GetCellBorderWidths(out int pduLeft, out int pduTop, out int pduRight, out int pduBottom);

		HRESULT SetCellBorderColors(int crLeft, int crTop, int crRight, int crBottom);

		HRESULT SetCellBorderWidths(int duLeft, int duTop, int duRight, int duBottom);

		HRESULT Apply(int cRow, int Flags);

		HRESULT CanChange(out int pValue);

		HRESULT GetProperty(int Type, out int pValue);

		HRESULT Insert(int cRow);

		HRESULT IsEqual([In, Optional] ITextRow? pRow, out int pB);

		HRESULT Reset(int Value);

		HRESULT SetProperty(int Type, int Value);
	}

	/// <summary>A text selection is a text range with selection highlighting.</summary>
	/// <remarks>
	/// <para>The selection is associated with some kind of view, and has some UI-oriented methods that allow one to emulate keyboard input. Thus, an application can use the ITextRange methods on a text selection, as well as the <c>ITextSelection</c> methods.</para>
	/// <para>For keyboard input emulation, ranges used in selections use the concept of the <c>active end</c>, which is typically the end that was last moved. For example, if an <c>ITextRange::Move</c>* method operates on a range that is actually a text selection, the most recently moved end is the active one. The most familiar examples of the active end are those involving Shift+Arrow Key handling, where the active end is the one that moves. Accordingly, the <c>ITextSelection</c> methods include move methods for the active end, such as MoveLeft or MoveRight, and methods to get and set the active end status. These methods manipulate selections in ways similar to the standard cursor-keypad operations. This allows you to implement, for example, a macro recorder facility.</para>
	/// <para>To see how the cursor-keypad methods work, see the following table. A given method corresponds to a cursor-keypad key with the Ctrl and Shift keys. The <c>Unit</c> parameter is selected by pressing or not pressing the Ctrl key, while the <c>Extend</c> parameter is selected by pressing or not pressing the Shift key. Note, MoveUp and MoveDown correspond to more than one keypad key. For more information, see the descriptions of the methods.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Method</description>
	/// <description>Cursor-keypad key</description>
	/// <description>Unit given by CTRL pressed (not pressed)</description>
	/// <description>Extend given by SHIFT pressed (not pressed)</description>
	/// </listheader>
	/// <item>
	/// <description>EndKey</description>
	/// <description>End</description>
	/// <description>tomStory (tomLine)</description>
	/// <description>tomExtend (tomMove)</description>
	/// </item>
	/// <item>
	/// <description>HomeKey</description>
	/// <description>Home</description>
	/// <description>tomStory (tomLine)</description>
	/// <description>tomExtend (tomMove)</description>
	/// </item>
	/// <item>
	/// <description>MoveLeft</description>
	/// <description>Left Arrow</description>
	/// <description>tomWord (tomCharacter)</description>
	/// <description>tomExtend (tomMove)</description>
	/// </item>
	/// <item>
	/// <description>MoveRight</description>
	/// <description>Right Arrow</description>
	/// <description>tomWord (tomCharacter)</description>
	/// <description>tomExtend (tomMove)</description>
	/// </item>
	/// <item>
	/// <description>MoveUp</description>
	/// <description>Up Arrow</description>
	/// <description>tomParagraph (tomLine)</description>
	/// <description>tomExtend (tomMove)</description>
	/// </item>
	/// <item>
	/// <description>MoveDown</description>
	/// <description>Down Arrow</description>
	/// <description>tomParagraph (tomLine)</description>
	/// <description>tomExtend (tomMove)</description>
	/// </item>
	/// <item>
	/// <description>MoveUp</description>
	/// <description>Page Up</description>
	/// <description>tomWindow (tomScreen)</description>
	/// <description>tomExtend (tomMove)</description>
	/// </item>
	/// <item>
	/// <description>MoveDown</description>
	/// <description>Page Down</description>
	/// <description>tomWindow (tomScreen)</description>
	/// <description>tomExtend (tomMove)</description>
	/// </item>
	/// </list>
	/// <para>Â</para>
	/// <para>Applications typically do not implement the <c>ITextSelection</c> interface. Instead, Microsoft text solutions such as rich edit controls implement <c>ITextSelection</c> as part of their Text Object Model (TOM) implementation.</para>
	/// <para>Applications can retrieve an <c>ITextSelection</c> pointer by calling the GetSelection method.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextselection
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextSelection")]
	[ComImport, Guid("8CC497C1-A1DF-11ce-8098-00AA0047BE5D"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ITextSelection : ITextRange
	{


		int GetFlags();

		HRESULT SetFlags(int Flags);

		int GetType();

		HRESULT MoveLeft(int Unit, int Count, int Extend, out int pDelta);

		HRESULT MoveRight(int Unit, int Count, int Extend, out int pDelta);

		HRESULT MoveUp(int Unit, int Count, int Extend, out int pDelta);

		HRESULT MoveDown(int Unit, int Count, int Extend, out int pDelta);

		HRESULT HomeKey(int Unit, int Extend, out int pDelta);

		HRESULT EndKey(int Unit, int Extend, out int pDelta);

		HRESULT TypeText([MarshalAs(UnmanagedType.BStr)] string bstr);
	}

	/// <summary>Currently, this interface contains no methods other than those inherited from ITextRange2.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextselection2
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextSelection2")]
	[ComImport, Guid("C241F5E1-7206-11D8-A2C7-00A0D1D6C6B3"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ITextSelection2 : ITextRange2
	{
	}

	/// <summary>
	/// <para>The <c>ITextStory</c> interface methods are used to access shared data from multiple stories, which is stored in the parent ITextServices instance.</para>
	/// <para>The stories can be "edited" simultaneously by using individual ITextRange2 methods, and displayed independently of one another. In addition, one story at a time can be UI active; that is, it receives keyboard and mouse input.</para>
	/// <para>The <c>ITextStory</c> is a lightweight interface that does not require an ITextRange2 object. This allows the client to manipulate a story, which is a faster, smaller object than a complete editing instance.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextstory
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextStory")]
	[ComImport, Guid("C241F5F3-7206-11D8-A2C7-00A0D1D6C6B3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITextStory
	{
		int GetActive();

		HRESULT SetActive(int Value);

		/// <summary>Gets a new display for a story.</summary>
		/// <param name="ppDisplay">
		/// <para>Type: <c>IUnknown**</c></para>
		/// <para>The IUnknown interface for a display.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>NOERROR</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>A story can be displayed by calling ITextStory::SetActive(<c>tomDisplayActive</c>). The <c>ITextStory::GetDisplay</c> method is included, in case it might be advantageous to have more than one display for a set of ITextStory interfaces.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/tom/nf-tom-itextstory-getdisplay
		// HRESULT GetDisplay( [out, retval] IUnknown **ppDisplay );
		[return: MarshalAs(UnmanagedType.IUnknown)] 
		object GetDisplay();

		int GetIndex();

		int GetType();

		HRESULT SetType(int Value);

		HRESULT GetProperty(int Type, out int pValue);

		HRESULT GetRange(int cpActive, int cpAnchor, out ITextRange2 ppRange);

		HRESULT GetText(int Flags, [MarshalAs(UnmanagedType.BStr)] out string pbstr);

		HRESULT SetFormattedText([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnk);

		HRESULT SetProperty(int Type, int Value);

		HRESULT SetText(int Flags, [MarshalAs(UnmanagedType.BStr)] string bstr);
	}

	/// <summary>The purpose of the <c>ITextStoryRanges</c> interface is to enumerate the stories in an ITextDocument.</summary>
	/// <remarks>You get a pointer to an <c>ITextStoryRanges</c> collection by calling the GetStoryRanges method. Each story obtained from this collection is represented by an ITextRange object that covers the whole story. Text Object Model (TOM) engines that only have a single story do not need to implement an <c>ITextStoryRanges</c> interface. Your code should only get a stories collection if GetStoryCount returns a story count greater than one.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextstoryranges
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextStoryRanges")]
	[ComImport, Guid("8CC497C5-A1DF-11ce-8098-00AA0047BE5D"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ITextStoryRanges
	{
		HRESULT NewEnum([MarshalAs(UnmanagedType.IUnknown)] out object ppunkEnum);

		HRESULT Item(int Index, out ITextRange ppRange);

		int GetCount();
	}

	/// <summary>
	/// <para>The <c>ITextStoryRanges2</c> interface enumerates the stories in an ITextDocument.</para>
	/// <para>You get a pointer to an <c>ITextStoryRanges2</c> collection by using the ITextDocument::GetStoryRanges method. Each story obtained from this collection is represented by an ITextRange2 object that covers the whole story.</para>
	/// <para>A Text Object Model (TOM) implementation that has only a single story doesn't need to implement the <c>ITextStoryRanges2</c> interface. An implementation of this interface should only retrieve a stories collection if ITextDocument::GetStoryCount returns a story count greater than one.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextstoryranges2
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextStoryRanges2")]
	[ComImport, Guid("C241F5E5-7206-11D8-A2C7-00A0D1D6C6B3"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ITextStoryRanges2 : ITextStoryRanges
	{
		HRESULT Item2(int Index, out ITextRange2 ppRange);
	}

	/// <summary>The <c>ITextStrings</c> interface represents a collection of rich-text strings that are useful for manipulating rich text. In particular, you can use the collection to convert linearly formatted math expressions into built-up form and vice versa. You can also use the collection to collect the concatenation of a set of rich-text strings, or to manipulate a string without changing a primary story. The collection is efficiently implemented by concatenating the strings in a scratch story and maintaining an array of the string counts that identify the strings.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/tom/nn-tom-itextstrings
	[PInvokeData("tom.h", MSDNShortId = "NN:tom.ITextStrings")]
	[ComImport, Guid("C241F5E7-7206-11D8-A2C7-00A0D1D6C6B3"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ITextStrings
	{
		HRESULT Item(int Index, out ITextRange2 ppRange);

		int GetCount();

		HRESULT Add([MarshalAs(UnmanagedType.BStr)] string bstr);

		HRESULT Append([In, Optional] ITextRange2? pRange, int iString);

		HRESULT Cat2(int iString);

		HRESULT CatTop2([MarshalAs(UnmanagedType.BStr)] string bstr);

		HRESULT DeleteRange([In, Optional] ITextRange2? pRange);

		HRESULT EncodeFunction(int Type, int Align, int Char, int Char1, int Char2, int Count, int TeXStyle, int cCol,
			[In, Optional] ITextRange2? pRange);

		HRESULT GetCch(int iString, out int pcch);

		HRESULT InsertNullStr(int iString);

		HRESULT MoveBoundary(int iString, int cch);

		HRESULT PrefixTop([MarshalAs(UnmanagedType.BStr)] string bstr);

		HRESULT Remove(int iString, int cString);

		HRESULT SetFormattedText([In, Optional] ITextRange2? pRangeD, [In, Optional] ITextRange2? pRangeS);

		HRESULT SetOpCp(int iString, int cp);

		HRESULT SuffixTop([MarshalAs(UnmanagedType.BStr)] string bstr, [In, Optional] ITextRange2? pRange);

		HRESULT Swap();
	}
}