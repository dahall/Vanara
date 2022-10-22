using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke
{
	/// <summary>Items from the Usp10.dll.</summary>
	public static partial class Usp10
	{
		private const string Lib_Usp10 = "Usp10.dll";

		/// <summary>Creates an <see cref="OPENTYPE_TAG"/> from four characters.</summary>
		/// <param name="a">The first character.</param>
		/// <param name="b">The second character.</param>
		/// <param name="c">The third character.</param>
		/// <param name="d">The fourth character.</param>
		/// <returns>An <see cref="OPENTYPE_TAG"/> from the input.</returns>
		public static OPENTYPE_TAG OTF_TAG(char a, char b, char c, char d) => new(a, b, c, d);

		/// <summary>Creates an <see cref="OPENTYPE_TAG"/> from a four character string.</summary>
		/// <param name="tag">The four character string.</param>
		/// <returns>An <see cref="OPENTYPE_TAG"/> from the input.</returns>
		public static OPENTYPE_TAG OTF_TAG(string tag) => new(tag);

		/// <summary>Creates an <see cref="OPENTYPE_TAG"/> from a four characters array.</summary>
		/// <param name="chars">The four character array.</param>
		/// <returns>An <see cref="OPENTYPE_TAG"/> from the input.</returns>
		public static OPENTYPE_TAG OTF_TAG(char[] chars) => new(chars);

		/// <summary>Creates an <see cref="OPENTYPE_TAG"/> from a four byte array.</summary>
		/// <param name="bytes">The four byte array.</param>
		/// <returns>An <see cref="OPENTYPE_TAG"/> from the input.</returns>
		public static OPENTYPE_TAG OTF_TAG(byte[] bytes) => new(bytes); 

		/// <summary>Applies the specified digit substitution settings to the specified script control and script state structures.</summary>
		/// <param name="psds">
		/// Pointer to a SCRIPT_DIGITSUBSTITUTE structure. The application sets this parameter to <c>NULL</c> if the function is to call
		/// ScriptRecordDigitSubstitution with LOCALE_USER_DEFAULT.
		/// </param>
		/// <param name="psc">Pointer to a SCRIPT_CONTROL structure with the <c>fContextDigits</c> and <c>uDefaultLanguage</c> members updated.</param>
		/// <param name="pss">Pointer to a SCRIPT_STATE structure with the <c>fDigitSubstitute</c> member updated.</param>
		/// <returns>
		/// <para>Returns S_OK if successful. The function returns a nonzero HRESULT value if it does not succeed.</para>
		/// <para>The function returns E_INVALIDARG if it does not recognize the <c>DigitSubstitute</c> member of SCRIPT_DIGITSUBSTITUTE.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function does not actually substitute digits. It just fills in the structures that describe the digit substitution policy.
		/// See Displaying Text with Uniscribe for a discussion of the context in which this function is normally called.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptapplydigitsubstitution HRESULT
		// ScriptApplyDigitSubstitution( [in] const SCRIPT_DIGITSUBSTITUTE *psds, [out] SCRIPT_CONTROL *psc, [out] SCRIPT_STATE *pss );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptApplyDigitSubstitution")]
		public static extern HRESULT ScriptApplyDigitSubstitution(in SCRIPT_DIGITSUBSTITUTE psds, out SCRIPT_CONTROL psc, out SCRIPT_STATE pss);

		/// <summary>Applies the specified digit substitution settings to the specified script control and script state structures.</summary>
		/// <param name="psds">
		/// Pointer to a SCRIPT_DIGITSUBSTITUTE structure. The application sets this parameter to <c>NULL</c> if the function is to call
		/// ScriptRecordDigitSubstitution with LOCALE_USER_DEFAULT.
		/// </param>
		/// <param name="psc">Pointer to a SCRIPT_CONTROL structure with the <c>fContextDigits</c> and <c>uDefaultLanguage</c> members updated.</param>
		/// <param name="pss">Pointer to a SCRIPT_STATE structure with the <c>fDigitSubstitute</c> member updated.</param>
		/// <returns>
		/// <para>Returns S_OK if successful. The function returns a nonzero HRESULT value if it does not succeed.</para>
		/// <para>The function returns E_INVALIDARG if it does not recognize the <c>DigitSubstitute</c> member of SCRIPT_DIGITSUBSTITUTE.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function does not actually substitute digits. It just fills in the structures that describe the digit substitution policy.
		/// See Displaying Text with Uniscribe for a discussion of the context in which this function is normally called.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptapplydigitsubstitution HRESULT
		// ScriptApplyDigitSubstitution( [in] const SCRIPT_DIGITSUBSTITUTE *psds, [out] SCRIPT_CONTROL *psc, [out] SCRIPT_STATE *pss );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptApplyDigitSubstitution")]
		public static extern HRESULT ScriptApplyDigitSubstitution([In, Optional] IntPtr psds, out SCRIPT_CONTROL psc, out SCRIPT_STATE pss);

		/// <summary>Takes an array of advance widths for a run and generates an array of adjusted advance glyph widths.</summary>
		/// <param name="piDx">Pointer to an array of advance widths in logical order, one per code point.</param>
		/// <param name="cChars">Count of the logical code points in the run.</param>
		/// <param name="cGlyphs">Glyph count.</param>
		/// <param name="pwLogClust">Pointer to an array of logical clusters from ScriptShape.</param>
		/// <param name="psva">Pointer to a SCRIPT_VISATTR structure from ScriptShape and updated by ScriptPlace.</param>
		/// <param name="piAdvance">Pointer to an array of glyph advance widths from ScriptPlace.</param>
		/// <param name="psa">Pointer to a SCRIPT_ANALYSIS structure from ScriptItemize and updated by ScriptShape and ScriptPlace.</param>
		/// <param name="pABC">
		/// Pointer to the overall ABC width of a run. On input, the parameter should contain the run ABC widths retrieved by ScriptPlace. On
		/// output, the parameter indicates the ABC width updated to match the new widths.
		/// </param>
		/// <param name="piJustify">
		/// Pointer to an array in which the function retrieves the glyph advance widths. This array is suitable for passing to the
		/// <c>piJustify</c> parameter of ScriptTextOut.
		/// </param>
		/// <returns>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function can be used to reapply logical widths obtained with ScriptGetLogicalWidths. It can be useful in situations such as
		/// metafiling, for which advance width information must be recorded and reapplied in a font-independent manner, independent of glyph
		/// substitutions, such as ligaturization.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptapplylogicalwidth HRESULT ScriptApplyLogicalWidth( [in]
		// const int *piDx, [in] int cChars, [in] int cGlyphs, [in] const WORD *pwLogClust, [in] const SCRIPT_VISATTR *psva, [in] const int
		// *piAdvance, [in] const SCRIPT_ANALYSIS *psa, [in, out, optional] ABC *pABC, [out] int *piJustify );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptApplyLogicalWidth")]
		public static extern HRESULT ScriptApplyLogicalWidth([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] piDx, int cChars,
			int cGlyphs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] pwLogClust, in SCRIPT_VISATTR psva,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] piAdvance, in SCRIPT_ANALYSIS psa, ref ABC pABC,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] piJustify);

		/// <summary>Retrieves information for determining line breaks.</summary>
		/// <param name="pwcChars">Pointer to the Unicode characters to process.</param>
		/// <param name="cChars">Number of Unicode characters to process.</param>
		/// <param name="psa">Pointer to the SCRIPT_ANALYSIS structure obtained from an earlier call to ScriptItemize.</param>
		/// <param name="psla">Pointer to a buffer in which this function retrieves the character attributes as a SCRIPT_LOGATTR structure.</param>
		/// <returns>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>See Displaying Text with Uniscribe for a discussion of the context in which this function is normally called.</para>
		/// <para>This function does not require a device context and does not perform glyph shaping.</para>
		/// <para>
		/// This function retrieves cursor movement and formatting break positions for an item in an array of SCRIPT_LOGATTR structures. To
		/// support mixed formatting within a single word correctly, the call to <c>ScriptBreak</c> should pass whole items as retrieved by
		/// ScriptItemize, and not the finer formatting runs.
		/// </para>
		/// <para>
		/// The SCRIPT_LOGATTR structure identifies valid caret positions and line breaks. The <c>fCharStop</c> member specifies a flag that
		/// marks cluster boundaries for scripts that are conventionally restricted from moving inside clusters. The same boundaries can also
		/// be inferred by inspecting the logical cluster information retrieved by ScriptShape. However, <c>ScriptBreak</c> is considerably
		/// faster in implementation and does not require a device context to be prepared.
		/// </para>
		/// <para>
		/// The flags designated by the <c>fWordStop</c>, <c>fSoftBreak</c>, and <c>fWhiteSpace</c> members of SCRIPT_LOGATTR are only
		/// available through <c>ScriptBreak</c>.
		/// </para>
		/// <para>
		/// Most shaping engines that identify invalid sequences set the flag indicated by the <c>fInvalid</c> member of SCRIPT_LOGATTR in
		/// <c>ScriptBreak</c>. The <c>fInvalidLogAttr</c> member of SCRIPT_PROPERTIES identifies the applicable scripts.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptbreak HRESULT ScriptBreak( [in] const WCHAR *pwcChars,
		// [in] int cChars, [in] const SCRIPT_ANALYSIS *psa, [out] SCRIPT_LOGATTR *psla );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptBreak")]
		public static extern HRESULT ScriptBreak([MarshalAs(UnmanagedType.LPWStr)] string pwcChars, int cChars, in SCRIPT_ANALYSIS psa,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SCRIPT_LOGATTR[] psla);

		/// <summary>Retrieves the height of the currently cached font.</summary>
		/// <param name="hdc">Optional. Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="tmHeight">Pointer to a buffer in which the function retrieves the font height.</param>
		/// <returns>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptcachegetheight HRESULT ScriptCacheGetHeight( [in] HDC hdc,
		// [in, out] SCRIPT_CACHE *psc, [out] long *tmHeight );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptCacheGetHeight")]
		public static extern HRESULT ScriptCacheGetHeight([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, out int tmHeight);

		/// <summary>
		/// Generates the x offset from the left end or leading edge of a run to either the leading or trailing edge of a logical character cluster.
		/// </summary>
		/// <param name="iCP">
		/// Logical character position in the run. This parameter corresponds to the offset of any logical character in the cluster.
		/// </param>
		/// <param name="fTrailing">
		/// <c>TRUE</c> to use the trailing edge of the logical character cluster to compute the offset. This parameter is set to
		/// <c>FALSE</c> to use the leading edge of the logical character cluster.
		/// </param>
		/// <param name="cChars">Number of characters in the run.</param>
		/// <param name="cGlyphs">Number of glyphs in the run.</param>
		/// <param name="pwLogClust">Pointer to the logical clusters.</param>
		/// <param name="psva">Pointer to a SCRIPT_VISATTR array of visual attributes.</param>
		/// <param name="piAdvance">Pointer to an advance widths value.</param>
		/// <param name="psa">
		/// Pointer to a SCRIPT_ANALYSIS structure. The <c>fLogicalOrder</c> member specifies the end of the run from which to measure the
		/// offset. If the flag is set, the leading edge of the run is used. If the flag is not set, the left end of the run is used.
		/// </param>
		/// <param name="piX">Pointer to the buffer in which the function retrieves the x position of the caret.</param>
		/// <returns>
		/// Returns 0 if successful. This function returns a nonzero HRESULT value if it does not succeed. The application can test the
		/// return value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>The leading or trailing edge of the character and the leading edge of a run depend on the direction of text in the run.</para>
		/// <para>
		/// For scripts in which the caret is conventionally placed in the middle of clusters (for example, Arabic and Hebrew), the retrieved
		/// x position of the carat can be an interpolated position for any code point in the line.
		/// </para>
		/// <para>
		/// For scripts in which the caret is conventionally snapped to the boundaries of clusters (for example, Thai and Indian), the x
		/// position is snapped to the requested edge of the cluster containing the logical character position indicated by <c>iCP</c>.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptcptox HRESULT ScriptCPtoX( [in] int iCP, [in] BOOL
		// fTrailing, [in] int cChars, [in] int cGlyphs, [in] const WORD *pwLogClust, [in] const SCRIPT_VISATTR *psva, [in] const int
		// *piAdvance, [in] const SCRIPT_ANALYSIS *psa, [out] int *piX );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptCPtoX")]
		public static extern HRESULT ScriptCPtoX(int iCP, [MarshalAs(UnmanagedType.Bool)] bool fTrailing, int cChars, int cGlyphs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ushort[] pwLogClust,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] SCRIPT_VISATTR[] psva,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] int[] piAdvance, in SCRIPT_ANALYSIS psa, out int piX);

		/// <summary>Frees a script cache.</summary>
		/// <param name="psc">Pointer to the SCRIPT_CACHE structure.</param>
		/// <returns>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application cant test the
		/// return value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can free the script cache at any time, with certain limitations if the application is multi-threaded. Uniscribe
		/// maintains reference counts in its font and shaper caches and frees font data only when all sizes of the font are free. It frees
		/// shaper data only when all supported fonts are freed.
		/// </para>
		/// <para>The application should free the script cache for a style when it discards that style.</para>
		/// <para><c>ScriptFreeCache</c> always sets its parameter to <c>NULL</c> to help avoid misreferencing.</para>
		/// <para>
		/// Uniscribe functions are re-entrant. Cache creation is interlocked through a single process-wide semaphore. <c>ScriptFreeCache</c>
		/// should not be called at a time when another thread might be accessing the particular cache to free. For performance reasons, the
		/// cache is not locked during ScriptShape or ScriptPlace.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptfreecache HRESULT ScriptFreeCache( [in, out] SCRIPT_CACHE
		// *psc );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptFreeCache")]
		public static extern HRESULT ScriptFreeCache(ref IntPtr psc);

		/// <summary>
		/// Retrieves the glyph indexes of the Unicode characters in a string according to either the TrueType cmap table or the standard
		/// cmap table implemented for old-style fonts.
		/// </summary>
		/// <param name="hdc">Optional. Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="pwcInChars">Pointer to a string of Unicode characters.</param>
		/// <param name="cChars">Number of Unicode characters in the string indicated by <c>pwcInChars</c>.</param>
		/// <param name="dwFlags">
		/// <para>
		/// Flags specifying any special handling of the glyphs. By default, the glyphs are provided in logical order with no special
		/// handling. This parameter can have the following value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SGCM_RTL</c></term>
		/// <term>The glyph array indicated by <c>pwOutGlyphs</c> should contain mirrored glyphs for those glyphs that have a mirrored equivalent.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pwOutGlyphs">
		/// Pointer to a buffer in which the function retrieves an array of glyph indexes. This buffer should be of the same length as the
		/// input buffer indicated by <c>pwcInChars</c>. Each code point maps to a single glyph.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns S_OK if all Unicode code points are present in the font. The function returns one of the nonzero HRESULT values listed
		/// below if it does not succeed.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>E_HANDLE</term>
		/// <term>The font or the operating system does not support glyph indexes.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>Some of the Unicode code points were mapped to the default glyph.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>See Displaying Text with Uniscribe for a discussion of the context in which this function is normally called.</para>
		/// <para>
		/// This function can be used to determine the characters in a run that are supported by the selected font. The application can scan
		/// the retrieved glyph buffer, looking for the default glyph to determine characters that are not available. The application should
		/// determine the default glyph index for the selected font by calling ScriptGetFontProperties.
		/// </para>
		/// <para>The return value for this function indicates the presence of any missing glyphs.</para>
		/// <para>
		/// <c>Note</c> The function assumes a 1:1 relationship between the elements in the input and output arrays. However, the function
		/// does not support this relationship for UTF-16 surrogate pairs. For a surrogate pair, the function does not retrieve the glyph
		/// index for the supplementary-plane character. Similarly, the function does not support Unicode Variation-Selector (VS) sequences,
		/// each of which consists of a Unicode graphic character followed by one of a set of VARIATION SELECTOR characters to select a
		/// particular glyph representation for that graphic character. For a VS sequence, the function retrieves the glyph index for the
		/// default glyph mapped by the cmap for the two characters, instead of the glyph index for the particular glyph for the VS sequence.
		/// </para>
		/// <para>
		/// Some code points can be rendered by a combination of glyphs, as well as by a single glyph, for example, 00C9; LATIN CAPITAL
		/// LETTER E WITH ACUTE. In this case, if the font supports the capital E glyph and the acute glyph, but not a single glyph for 00C9,
		/// <c>ScriptGetCMap</c> shows that 00C9 is unsupported. To determine the font support for a string that contains these kinds of code
		/// points, the application can call ScriptShape. If the function returns S_OK, the application should check the output for missing glyphs.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptgetcmap HRESULT ScriptGetCMap( [in] HDC hdc, [in, out]
		// SCRIPT_CACHE *psc, [in] const WCHAR *pwcInChars, [in] int cChars, [in] DWORD dwFlags, [out] WORD *pwOutGlyphs );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptGetCMap")]
		public static extern HRESULT ScriptGetCMap([In] HDC hdc, SafeSCRIPT_CACHE psc, [MarshalAs(UnmanagedType.LPWStr)] string pwcInChars,
			int cChars, SGCM dwFlags, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ushort[] pwOutGlyphs);

		/// <summary>
		/// Retrieves a list of alternate glyphs for a specified character that can be accessed through a specified OpenType feature.
		/// </summary>
		/// <param name="hdc">Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure defining the script cache.</param>
		/// <param name="psa">
		/// <para>
		/// Pointer to a SCRIPT_ANALYSIS structure obtained from a previous call to ScriptItemizeOpenType. This parameter identifies the
		/// shaping engine, so that the array of alternate glyphs can be created with the correct scope.
		/// </para>
		/// <para>Alternatively, the application can set this parameter to <c>NULL</c> to receive unfiltered results.</para>
		/// </param>
		/// <param name="tagScript">An OPENTYPE_TAG structure defining the script tag associated with alternate glyphs.</param>
		/// <param name="tagLangSys">An OPENTYPE_TAG structure defining the language tag associated with alternate glyphs.</param>
		/// <param name="tagFeature">An OPENTYPE_TAG structure defining the feature tag associated with alternate glyphs.</param>
		/// <param name="wGlyphId">The identifier of the original glyph mapped from the character map table.</param>
		/// <param name="cMaxAlternates">Length of the array specified by <c>pAlternateGlyphs</c>.</param>
		/// <param name="pAlternateGlyphs">
		/// <para>
		/// Pointer to buffer in which this function retrieves an array of glyph identifiers. The array includes the original glyph, followed
		/// by alternate glyphs. The first element is always the original glyph. Alternate forms are identified by an index into the array.
		/// The index is a value greater than one and less than the value of <c>pcAlternates</c>.
		/// </para>
		/// <para>
		/// When the user chooses an alternate form from the user interface, the alternate glyph is applied to the corresponding character
		/// and the rendering is reformatted.
		/// </para>
		/// </param>
		/// <param name="pcAlternates">Pointer to the number of elements in the array specified by <c>pAlternateGlyphs</c>.</param>
		/// <returns>
		/// <para>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </para>
		/// <para>
		/// If the number of alternate glyphs exceeds the value of <c>cMaxAlternates</c>, the function fails with E_OUTOFMEMORY. The
		/// application can try calling again with larger buffers.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When using alternate glyphs, the application first reshapes the original glyph without applying any feature tag, then selects an
		/// alternate. The original glyph is established as the base glyph. If another alternate is required, the original glyph provides
		/// information to match with the corresponding alternates list.
		/// </para>
		/// <para>
		/// If an alternate glyph is used as the base glyph, no matching output list is found. The user interface uses the selected final
		/// form without providing the capability to choose another alternate.
		/// </para>
		/// <para>
		/// The operations of <c>ScriptGetFontAlternateGlyphs</c> can be emulated by ScriptSubstituteSingleGlyph. The application should try
		/// parameters one by one while glyphs are substituted.
		/// </para>
		/// <para>For shaping fonts with Uniscribe, ScriptShapeOpenType is preferred over the older ScriptShape function.</para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptgetfontalternateglyphs HRESULT
		// ScriptGetFontAlternateGlyphs( [in, optional] HDC hdc, [in, out] SCRIPT_CACHE *psc, [in, optional] SCRIPT_ANALYSIS *psa, [in]
		// OPENTYPE_TAG tagScript, [in] OPENTYPE_TAG tagLangSys, [in] OPENTYPE_TAG tagFeature, [in] WORD wGlyphId, [in] int cMaxAlternates,
		// [out] WORD *pAlternateGlyphs, [out] int *pcAlternates );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptGetFontAlternateGlyphs")]
		public static extern HRESULT ScriptGetFontAlternateGlyphs([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, in SCRIPT_ANALYSIS psa,
			OPENTYPE_TAG tagScript, OPENTYPE_TAG tagLangSys, OPENTYPE_TAG tagFeature, ushort wGlyphId, int cMaxAlternates,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] ushort[] pAlternateGlyphs, out int pcAlternates);

		/// <summary>
		/// Retrieves a list of alternate glyphs for a specified character that can be accessed through a specified OpenType feature.
		/// </summary>
		/// <param name="hdc">Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure defining the script cache.</param>
		/// <param name="psa">
		/// <para>
		/// Pointer to a SCRIPT_ANALYSIS structure obtained from a previous call to ScriptItemizeOpenType. This parameter identifies the
		/// shaping engine, so that the array of alternate glyphs can be created with the correct scope.
		/// </para>
		/// <para>Alternatively, the application can set this parameter to <c>NULL</c> to receive unfiltered results.</para>
		/// </param>
		/// <param name="tagScript">An OPENTYPE_TAG structure defining the script tag associated with alternate glyphs.</param>
		/// <param name="tagLangSys">An OPENTYPE_TAG structure defining the language tag associated with alternate glyphs.</param>
		/// <param name="tagFeature">An OPENTYPE_TAG structure defining the feature tag associated with alternate glyphs.</param>
		/// <param name="wGlyphId">The identifier of the original glyph mapped from the character map table.</param>
		/// <param name="cMaxAlternates">Length of the array specified by <c>pAlternateGlyphs</c>.</param>
		/// <param name="pAlternateGlyphs">
		/// <para>
		/// Pointer to buffer in which this function retrieves an array of glyph identifiers. The array includes the original glyph, followed
		/// by alternate glyphs. The first element is always the original glyph. Alternate forms are identified by an index into the array.
		/// The index is a value greater than one and less than the value of <c>pcAlternates</c>.
		/// </para>
		/// <para>
		/// When the user chooses an alternate form from the user interface, the alternate glyph is applied to the corresponding character
		/// and the rendering is reformatted.
		/// </para>
		/// </param>
		/// <param name="pcAlternates">Pointer to the number of elements in the array specified by <c>pAlternateGlyphs</c>.</param>
		/// <returns>
		/// <para>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </para>
		/// <para>
		/// If the number of alternate glyphs exceeds the value of <c>cMaxAlternates</c>, the function fails with E_OUTOFMEMORY. The
		/// application can try calling again with larger buffers.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When using alternate glyphs, the application first reshapes the original glyph without applying any feature tag, then selects an
		/// alternate. The original glyph is established as the base glyph. If another alternate is required, the original glyph provides
		/// information to match with the corresponding alternates list.
		/// </para>
		/// <para>
		/// If an alternate glyph is used as the base glyph, no matching output list is found. The user interface uses the selected final
		/// form without providing the capability to choose another alternate.
		/// </para>
		/// <para>
		/// The operations of <c>ScriptGetFontAlternateGlyphs</c> can be emulated by ScriptSubstituteSingleGlyph. The application should try
		/// parameters one by one while glyphs are substituted.
		/// </para>
		/// <para>For shaping fonts with Uniscribe, ScriptShapeOpenType is preferred over the older ScriptShape function.</para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptgetfontalternateglyphs HRESULT
		// ScriptGetFontAlternateGlyphs( [in, optional] HDC hdc, [in, out] SCRIPT_CACHE *psc, [in, optional] SCRIPT_ANALYSIS *psa, [in]
		// OPENTYPE_TAG tagScript, [in] OPENTYPE_TAG tagLangSys, [in] OPENTYPE_TAG tagFeature, [in] WORD wGlyphId, [in] int cMaxAlternates,
		// [out] WORD *pAlternateGlyphs, [out] int *pcAlternates );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptGetFontAlternateGlyphs")]
		public static extern HRESULT ScriptGetFontAlternateGlyphs([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, [In, Optional] IntPtr psa,
			OPENTYPE_TAG tagScript, OPENTYPE_TAG tagLangSys, OPENTYPE_TAG tagFeature, ushort wGlyphId, int cMaxAlternates,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] ushort[] pAlternateGlyphs, out int pcAlternates);

		/// <summary>
		/// Retrieves a list of typographic features for the defined writing system for OpenType processing. The typographic feature tags
		/// comprising the list are retrieved from the font in the supplied device context or cache.
		/// </summary>
		/// <param name="hdc">Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="psa">
		/// <para>
		/// Pointer to a SCRIPT_ANALYSIS structure obtained from a previous call to ScriptItemizeOpenType. This parameter identifies the
		/// shaping engine, so that the font feature tags for the appropriate font and scripts can be retrieved.
		/// </para>
		/// <para>Alternatively, the application can set this parameter to <c>NULL</c> to retrieve unfiltered results.</para>
		/// </param>
		/// <param name="tagScript">An OPENTYPE_TAG structure defining the script tag associated with the specified feature tags.</param>
		/// <param name="tagLangSys">An <c>OPENTYPE_TAG</c> structure defining the language tag associated with the specified feature tags.</param>
		/// <param name="cMaxTags">The length of the array specified by <c>pFeatureTags</c>.</param>
		/// <param name="pFeatureTags">
		/// Pointer to a buffer in which this function retrieves an array of <c>OPENTYPE_TAG</c> structures defining the typographic feature
		/// tags supported by the font in the device context or cache for the defined writing system.
		/// </param>
		/// <param name="pcTags">Pointer to the number of elements in the feature tag array.</param>
		/// <returns>
		/// <para>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </para>
		/// <para>
		/// If the number of matching tags exceeds the value of <c>cMaxTags</c>, the function fails with E_OUTOFMEMORY. The application can
		/// try calling again with larger buffers.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// While formally declared as a ULONG type, an OPENTYPE_TAG structure contains a 4-byte array that contains four 8-bit ASCII values
		/// of space, A-Z, or a-z. For example, the feature tag for the Ligature feature is "liga".
		/// </para>
		/// <para>
		/// This function hides script-required or language-required features because the shaping engine controls these features. The
		/// application has no control over the shaping engine handling for language-required features. For example,
		/// <c>ScriptGetFontFeatureTags</c> hides the Arabic script features for initial, medial, and final forms.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptgetfontfeaturetags HRESULT ScriptGetFontFeatureTags( [in,
		// optional] HDC hdc, [in, out] SCRIPT_CACHE *psc, [in, optional] SCRIPT_ANALYSIS *psa, [in] OPENTYPE_TAG tagScript, [in]
		// OPENTYPE_TAG tagLangSys, [in] int cMaxTags, [out] OPENTYPE_TAG *pFeatureTags, [out] int *pcTags );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptGetFontFeatureTags")]
		public static extern HRESULT ScriptGetFontFeatureTags([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, in SCRIPT_ANALYSIS psa,
			OPENTYPE_TAG tagScript, OPENTYPE_TAG tagLangSys, int cMaxTags,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] OPENTYPE_TAG[] pFeatureTags, out int pcTags);

		/// <summary>
		/// Retrieves a list of typographic features for the defined writing system for OpenType processing. The typographic feature tags
		/// comprising the list are retrieved from the font in the supplied device context or cache.
		/// </summary>
		/// <param name="hdc">Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="psa">
		/// <para>
		/// Pointer to a SCRIPT_ANALYSIS structure obtained from a previous call to ScriptItemizeOpenType. This parameter identifies the
		/// shaping engine, so that the font feature tags for the appropriate font and scripts can be retrieved.
		/// </para>
		/// <para>Alternatively, the application can set this parameter to <c>NULL</c> to retrieve unfiltered results.</para>
		/// </param>
		/// <param name="tagScript">An OPENTYPE_TAG structure defining the script tag associated with the specified feature tags.</param>
		/// <param name="tagLangSys">An <c>OPENTYPE_TAG</c> structure defining the language tag associated with the specified feature tags.</param>
		/// <param name="cMaxTags">The length of the array specified by <c>pFeatureTags</c>.</param>
		/// <param name="pFeatureTags">
		/// Pointer to a buffer in which this function retrieves an array of <c>OPENTYPE_TAG</c> structures defining the typographic feature
		/// tags supported by the font in the device context or cache for the defined writing system.
		/// </param>
		/// <param name="pcTags">Pointer to the number of elements in the feature tag array.</param>
		/// <returns>
		/// <para>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </para>
		/// <para>
		/// If the number of matching tags exceeds the value of <c>cMaxTags</c>, the function fails with E_OUTOFMEMORY. The application can
		/// try calling again with larger buffers.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// While formally declared as a ULONG type, an OPENTYPE_TAG structure contains a 4-byte array that contains four 8-bit ASCII values
		/// of space, A-Z, or a-z. For example, the feature tag for the Ligature feature is "liga".
		/// </para>
		/// <para>
		/// This function hides script-required or language-required features because the shaping engine controls these features. The
		/// application has no control over the shaping engine handling for language-required features. For example,
		/// <c>ScriptGetFontFeatureTags</c> hides the Arabic script features for initial, medial, and final forms.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptgetfontfeaturetags HRESULT ScriptGetFontFeatureTags( [in,
		// optional] HDC hdc, [in, out] SCRIPT_CACHE *psc, [in, optional] SCRIPT_ANALYSIS *psa, [in] OPENTYPE_TAG tagScript, [in]
		// OPENTYPE_TAG tagLangSys, [in] int cMaxTags, [out] OPENTYPE_TAG *pFeatureTags, [out] int *pcTags );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptGetFontFeatureTags")]
		public static extern HRESULT ScriptGetFontFeatureTags([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, [In, Optional] IntPtr psa,
			OPENTYPE_TAG tagScript, OPENTYPE_TAG tagLangSys, int cMaxTags,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] OPENTYPE_TAG[] pFeatureTags, out int pcTags);

		/// <summary>
		/// Retrieves a list of language tags that are available for the specified item and are supported by a specified script tag for
		/// OpenType processing. The tags comprising the list are retrieved from the font in the specified device context or cache.
		/// </summary>
		/// <param name="hdc">Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="psa">
		/// <para>
		/// Pointer to a SCRIPT_ANALYSIS structure obtained from a previous call to ScriptItemizeOpenType. This parameter identifies the
		/// shaping engine, so that the font language tags for the appropriate font and scripts can be retrieved.
		/// </para>
		/// <para>Alternately, the application can set this parameter to <c>NULL</c> to retrieve unfiltered results.</para>
		/// </param>
		/// <param name="tagScript">
		/// An OPENTYPE_TAG structure defining the script tag for which the list of associated language tags is requested.
		/// </param>
		/// <param name="cMaxTags">The length of the array specified by <c>pLangSysTags</c>.</param>
		/// <param name="pLangsysTags">
		/// Pointer to a buffer in which this function retrieves an array of OPENTYPE_TAG structures identifying the language tags matching
		/// input criteria.
		/// </param>
		/// <param name="pcTags">Pointer to the number of elements in the language tag array.</param>
		/// <returns>
		/// <para>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </para>
		/// <para>
		/// If the number of matching tags exceeds <c>cMaxTags</c>, the function fails with E_OUTOFMEMORY. The application can try calling
		/// again with larger buffers.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// While formally declared as a ULONG type, the OPENTYPE_TAG structure contains a 4-byte array that contains four 8-bit ASCII values
		/// of space, A-Z, or a-z. For example, the language tags for Romanian, Urdu, and Persian are "ROM ", "URD ", and "FAR ",
		/// respectively. Note that each tag ends with a space.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptgetfontlanguagetags HRESULT ScriptGetFontLanguageTags(
		// [in, optional] HDC hdc, [in, out] SCRIPT_CACHE *psc, [in, optional] SCRIPT_ANALYSIS *psa, [in] OPENTYPE_TAG tagScript, [in] int
		// cMaxTags, [out] OPENTYPE_TAG *pLangsysTags, [out] int *pcTags );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptGetFontLanguageTags")]
		public static extern HRESULT ScriptGetFontLanguageTags([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, in SCRIPT_ANALYSIS psa, OPENTYPE_TAG tagScript,
			int cMaxTags, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] OPENTYPE_TAG[] pLangsysTags, out int pcTags);

		/// <summary>
		/// Retrieves a list of language tags that are available for the specified item and are supported by a specified script tag for
		/// OpenType processing. The tags comprising the list are retrieved from the font in the specified device context or cache.
		/// </summary>
		/// <param name="hdc">Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="psa">
		/// <para>
		/// Pointer to a SCRIPT_ANALYSIS structure obtained from a previous call to ScriptItemizeOpenType. This parameter identifies the
		/// shaping engine, so that the font language tags for the appropriate font and scripts can be retrieved.
		/// </para>
		/// <para>Alternately, the application can set this parameter to <c>NULL</c> to retrieve unfiltered results.</para>
		/// </param>
		/// <param name="tagScript">
		/// An OPENTYPE_TAG structure defining the script tag for which the list of associated language tags is requested.
		/// </param>
		/// <param name="cMaxTags">The length of the array specified by <c>pLangSysTags</c>.</param>
		/// <param name="pLangsysTags">
		/// Pointer to a buffer in which this function retrieves an array of OPENTYPE_TAG structures identifying the language tags matching
		/// input criteria.
		/// </param>
		/// <param name="pcTags">Pointer to the number of elements in the language tag array.</param>
		/// <returns>
		/// <para>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </para>
		/// <para>
		/// If the number of matching tags exceeds <c>cMaxTags</c>, the function fails with E_OUTOFMEMORY. The application can try calling
		/// again with larger buffers.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// While formally declared as a ULONG type, the OPENTYPE_TAG structure contains a 4-byte array that contains four 8-bit ASCII values
		/// of space, A-Z, or a-z. For example, the language tags for Romanian, Urdu, and Persian are "ROM ", "URD ", and "FAR ",
		/// respectively. Note that each tag ends with a space.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptgetfontlanguagetags HRESULT ScriptGetFontLanguageTags(
		// [in, optional] HDC hdc, [in, out] SCRIPT_CACHE *psc, [in, optional] SCRIPT_ANALYSIS *psa, [in] OPENTYPE_TAG tagScript, [in] int
		// cMaxTags, [out] OPENTYPE_TAG *pLangsysTags, [out] int *pcTags );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptGetFontLanguageTags")]
		public static extern HRESULT ScriptGetFontLanguageTags([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, [In, Optional] IntPtr psa, OPENTYPE_TAG tagScript,
			int cMaxTags, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] OPENTYPE_TAG[] pLangsysTags, out int pcTags);

		/// <summary>Retrieves information from the font cache on the special glyphs used by a font.</summary>
		/// <param name="hdc">Optional. Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="sfp">
		/// Pointer to a SCRIPT_FONTPROPERTIES structure in which this function retrieves the information from the font cache.
		/// </param>
		/// <returns>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The structure retrieved by this function identifies the glyphs that are used for blanks, missing glyphs, invalid combinations,
		/// and the smallest kashida.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptgetfontproperties HRESULT ScriptGetFontProperties( [in]
		// HDC hdc, [in, out] SCRIPT_CACHE *psc, [out] SCRIPT_FONTPROPERTIES *sfp );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptGetFontProperties")]
		public static extern HRESULT ScriptGetFontProperties([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, ref SCRIPT_FONTPROPERTIES sfp);

		/// <summary>
		/// Retrieves a list of scripts available in the font for OpenType processing. Scripts comprising the list are retrieved from the
		/// font located in the supplied device context or from the script shaping engine that processes the font of the current run.
		/// </summary>
		/// <param name="hdc">Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="psa">
		/// <para>
		/// Pointer to a SCRIPT_ANALYSIS structure obtained from a previous call to ScriptItemizeOpenType. This parameter identifies the
		/// shaping engine, so that the appropriate font script tags can be retrieved. The application supplies a non- <c>NULL</c> value for
		/// this parameter to retrieve script tags appropriate for the current run.
		/// </para>
		/// <para>Alternatively, the application can set this parameter to <c>NULL</c> to retrieve unfiltered results.</para>
		/// </param>
		/// <param name="cMaxTags">The length of the array specified by <c>pScriptTags</c>.</param>
		/// <param name="pScriptTags">
		/// Pointer to a buffer in which this function retrieves an array of OPENTYPE_TAG structures defining script tags from the device
		/// context or the scripting engine associated with the current run. If the value of the <c>eScript</c> member of the SCRIPT_ANALYSIS
		/// structure provided in the <c>psa</c> parameter has a definite script tag associated with it and the tag is present in the font,
		/// <c>pScriptTags</c> contains only this tag.
		/// </param>
		/// <param name="pcTags">Pointer to the number of elements in the script tag array indicated by <c>pScriptTags</c>.</param>
		/// <returns>
		/// <para>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </para>
		/// <para>
		/// If the number of matching tags exceeds the value of <c>cMaxTags</c>, the function fails with E_OUTOFMEMORY. The application can
		/// try calling again with larger buffers.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// While formally declared as a ULONG type, OPENTYPE_TAG defines a 4-byte array that contains four 8-bit ASCII values of space, A-Z
		/// or a-z. For example, the script tags for Latin and Arabic scripts are "latn" and "arab", respectively.
		/// </para>
		/// <para>This function retrieves a single tag from a font in the following cases:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The <c>psa</c> value is associated with text for a single complex script.</term>
		/// </item>
		/// <item>
		/// <term>The <c>psa</c> parameter indicates <c>NULL</c> and the font supports a single script.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If <c>ScriptGetFontScriptTags</c> retrieves all tags from a font, the tags are usually for neutral items, such as digits. Note
		/// that more than one tag might be applicable because some text runs of neutral items are not script-specific.
		/// </para>
		/// <para>
		/// If a tag corresponding to a particular script is present, a shaping engine might be unable to use the font to shape the given
		/// item because the engine lacks a needed item, such as a specific language system or a specific feature.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptgetfontscripttags HRESULT ScriptGetFontScriptTags( [in,
		// optional] HDC hdc, [in, out] SCRIPT_CACHE *psc, [in, optional] SCRIPT_ANALYSIS *psa, [in] int cMaxTags, [out] OPENTYPE_TAG
		// *pScriptTags, [out] int *pcTags );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptGetFontScriptTags")]
		public static extern HRESULT ScriptGetFontScriptTags([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, in SCRIPT_ANALYSIS psa, int cMaxTags,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] OPENTYPE_TAG[] pScriptTags, out int pcTags);

		/// <summary>
		/// Retrieves a list of scripts available in the font for OpenType processing. Scripts comprising the list are retrieved from the
		/// font located in the supplied device context or from the script shaping engine that processes the font of the current run.
		/// </summary>
		/// <param name="hdc">Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="psa">
		/// <para>
		/// Pointer to a SCRIPT_ANALYSIS structure obtained from a previous call to ScriptItemizeOpenType. This parameter identifies the
		/// shaping engine, so that the appropriate font script tags can be retrieved. The application supplies a non- <c>NULL</c> value for
		/// this parameter to retrieve script tags appropriate for the current run.
		/// </para>
		/// <para>Alternatively, the application can set this parameter to <c>NULL</c> to retrieve unfiltered results.</para>
		/// </param>
		/// <param name="cMaxTags">The length of the array specified by <c>pScriptTags</c>.</param>
		/// <param name="pScriptTags">
		/// Pointer to a buffer in which this function retrieves an array of OPENTYPE_TAG structures defining script tags from the device
		/// context or the scripting engine associated with the current run. If the value of the <c>eScript</c> member of the SCRIPT_ANALYSIS
		/// structure provided in the <c>psa</c> parameter has a definite script tag associated with it and the tag is present in the font,
		/// <c>pScriptTags</c> contains only this tag.
		/// </param>
		/// <param name="pcTags">Pointer to the number of elements in the script tag array indicated by <c>pScriptTags</c>.</param>
		/// <returns>
		/// <para>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </para>
		/// <para>
		/// If the number of matching tags exceeds the value of <c>cMaxTags</c>, the function fails with E_OUTOFMEMORY. The application can
		/// try calling again with larger buffers.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// While formally declared as a ULONG type, OPENTYPE_TAG defines a 4-byte array that contains four 8-bit ASCII values of space, A-Z
		/// or a-z. For example, the script tags for Latin and Arabic scripts are "latn" and "arab", respectively.
		/// </para>
		/// <para>This function retrieves a single tag from a font in the following cases:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The <c>psa</c> value is associated with text for a single complex script.</term>
		/// </item>
		/// <item>
		/// <term>The <c>psa</c> parameter indicates <c>NULL</c> and the font supports a single script.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If <c>ScriptGetFontScriptTags</c> retrieves all tags from a font, the tags are usually for neutral items, such as digits. Note
		/// that more than one tag might be applicable because some text runs of neutral items are not script-specific.
		/// </para>
		/// <para>
		/// If a tag corresponding to a particular script is present, a shaping engine might be unable to use the font to shape the given
		/// item because the engine lacks a needed item, such as a specific language system or a specific feature.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptgetfontscripttags HRESULT ScriptGetFontScriptTags( [in,
		// optional] HDC hdc, [in, out] SCRIPT_CACHE *psc, [in, optional] SCRIPT_ANALYSIS *psa, [in] int cMaxTags, [out] OPENTYPE_TAG
		// *pScriptTags, [out] int *pcTags );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptGetFontScriptTags")]
		public static extern HRESULT ScriptGetFontScriptTags([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, [In, Optional] IntPtr psa, int cMaxTags,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] OPENTYPE_TAG[] pScriptTags, out int pcTags);

		/// <summary>Retrieves the ABC width of a given glyph.</summary>
		/// <param name="hdc">Optional. Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="wGlyph">Glyph to analyze.</param>
		/// <param name="pABC">Pointer to the ABC width of the specified glyph.</param>
		/// <returns>
		/// <para>Returns S_OK if the ABC width of the glyph is retrieved. The function returns a nonzero HRESULT value if it does not succeed.</para>
		/// <para>The function returns E_HANDLE if the font or operating system does not support glyph indexes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is limited in its usefulness. For example, it is useful for drawing glyph charts. It should not be used for
		/// ordinary complex script text formatting.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptgetglyphabcwidth HRESULT ScriptGetGlyphABCWidth( [in] HDC
		// hdc, [in, out] SCRIPT_CACHE *psc, [in] WORD wGlyph, [out] ABC *pABC );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptGetGlyphABCWidth")]
		public static extern HRESULT ScriptGetGlyphABCWidth([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, ushort wGlyph, out ABC pABC);

		/// <summary>Converts the glyph advance widths for a specific font into logical widths.</summary>
		/// <param name="psa">Pointer to a SCRIPT_ANALYSIS structure.</param>
		/// <param name="cChars">Count of the logical code points in the run.</param>
		/// <param name="cGlyphs">Count of the glyphs in the run.</param>
		/// <param name="piGlyphWidth">Pointer to an array of glyph advance widths.</param>
		/// <param name="pwLogClust">Pointer to an array of logical clusters.</param>
		/// <param name="psva">Pointer to a SCRIPT_VISATTR structure defining visual attributes.</param>
		/// <param name="piDx">Pointer to an array of logical widths.</param>
		/// <returns>Currently returns S_OK in all cases.</returns>
		/// <remarks>
		/// <para>
		/// This function is useful for recording widths in a font-independent manner. It converts the glyph advance widths calculated for a
		/// specific font into logical widths, one per code point, in the same order as the code points. If the same string is then displayed
		/// on a different device using a different font, the logical widths can be applied by using ScriptApplyLogicalWidth to approximate
		/// the original placement. This mechanism is useful when implementing print preview. On the preview screen, it is important to match
		/// the layout and placement of the final printed result.
		/// </para>
		/// <para><c>Note</c> Ligature glyph widths are divided evenly among the characters they represent.</para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptgetlogicalwidths HRESULT ScriptGetLogicalWidths( [in]
		// const SCRIPT_ANALYSIS *psa, [in] int cChars, [in] int cGlyphs, [in] const int *piGlyphWidth, [in] const WORD *pwLogClust, [in]
		// const SCRIPT_VISATTR *psva, [out] int *piDx );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptGetLogicalWidths")]
		public static extern HRESULT ScriptGetLogicalWidths(in SCRIPT_ANALYSIS psa, int cChars, int cGlyphs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] piGlyphWidth,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] pwLogClust,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] SCRIPT_VISATTR[] psva,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] piDx);

		/// <summary>Retrieves information about the current scripts.</summary>
		/// <param name="ppSp">Pointer to an array of pointers to SCRIPT_PROPERTIES structures indexed by script.</param>
		/// <param name="piNumScripts">Pointer to the number of scripts. The valid range for this value is 0 through <c>piNumScripts</c>-1.</param>
		/// <returns>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>See Determining If a Script Requires Glyph Shaping for an example of the use of this function.</para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptgetproperties HRESULT ScriptGetProperties( [out] const
		// SCRIPT_PROPERTIES ***ppSp, [out] int *piNumScripts );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptGetProperties")]
		public static extern HRESULT ScriptGetProperties(out IntPtr ppSp, out int piNumScripts);

		/// <summary>Retrieves information about the current scripts.</summary>
		/// <param name="ppSp">Pointer to an array of pointers to SCRIPT_PROPERTIES structures indexed by script.</param>
		/// <returns>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>See Determining If a Script Requires Glyph Shaping for an example of the use of this function.</para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptgetproperties HRESULT ScriptGetProperties( [out] const
		// SCRIPT_PROPERTIES ***ppSp, [out] int *piNumScripts );
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptGetProperties")]
		public static HRESULT ScriptGetProperties(out SCRIPT_PROPERTIES[] ppSp)
		{
			HRESULT hr = ScriptGetProperties(out IntPtr p, out int c);
			ppSp = hr.Succeeded ? Array.ConvertAll(p.ToArray<IntPtr>(c), i => (SCRIPT_PROPERTIES)Marshal.ReadInt64(i)) : null;
			return hr;
		}

		/// <summary>Determines whether a Unicode string requires complex script processing.</summary>
		/// <param name="pwcInChars">Pointer to the string to test.</param>
		/// <param name="cInChars">Length of the input string, in characters.</param>
		/// <param name="dwFlags">
		/// <para>Flags specifying testing details. This parameter can have one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SIC_ASCIIDIGIT</c></term>
		/// <term>
		/// Treat digits U+0030 to U+0039 as complex. The application sets this flag if the string is displayed with digit substitution
		/// enabled. If the application is following the user's National Language Support (NLS) settings using the
		/// ScriptRecordDigitSubstitution function, it can pass a SCRIPT_DIGITSUBSTITUTE structure with the <c>DigitSubstitute</c> member set
		/// to SCRIPT_DIGITSUBSTITUTE_NONE.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SIC_COMPLEX</c></term>
		/// <term>Treat complex script letters as complex. This flag should normally be set.</term>
		/// </item>
		/// <item>
		/// <term><c>SIC_NEUTRAL</c></term>
		/// <term>Treat neutrals as complex. The application sets this flag to display the string with right-to-left reading order.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// Returns S_OK if the string requires complex script processing. The function returns S_FALSE if the string can be handled by
		/// standard API function calls, that is, it contains only characters laid out side-by-side and left-to-right. The function returns a
		/// nonzero HRESULT value if it does not succeed.
		/// </returns>
		/// <remarks>
		/// <para>See Displaying Text with Uniscribe for a discussion of the context in which this function is normally called.</para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptiscomplex HRESULT ScriptIsComplex( [in] const WCHAR
		// *pwcInChars, [in] int cInChars, [in] DWORD dwFlags );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptIsComplex")]
		public static extern HRESULT ScriptIsComplex([MarshalAs(UnmanagedType.LPWStr)] string pwcInChars, int cInChars, SIC dwFlags);

		/// <summary>Breaks a Unicode string into individually shapeable items.</summary>
		/// <param name="pwcInChars">Pointer to a Unicode string to itemize.</param>
		/// <param name="cInChars">Number of characters in <c>pwcInChars</c> to itemize.</param>
		/// <param name="cMaxItems">Maximum number of SCRIPT_ITEM structures defining items to process.</param>
		/// <param name="psControl">
		/// <para>Pointer to a SCRIPT_CONTROL structure indicating the type of itemization to perform.</para>
		/// <para>
		/// Alternatively, the application can set this parameter to <c>NULL</c> if no SCRIPT_CONTROL properties are needed. For more
		/// information, see the Remarks section.
		/// </para>
		/// </param>
		/// <param name="psState">
		/// <para>Pointer to a SCRIPT_STATE structure indicating the initial bidirectional algorithm state.</para>
		/// <para>
		/// Alternatively, the application can set this parameter to <c>NULL</c> if the script state is not needed. For more information, see
		/// the Remarks section.
		/// </para>
		/// </param>
		/// <param name="pItems">
		/// Pointer to a buffer in which the function retrieves SCRIPT_ITEM structures representing the items that have been processed. The
		/// buffer should be <c>(cMaxItems + 1) * sizeof(SCRIPT_ITEM)</c> bytes in length. It is invalid to call this function with a buffer
		/// that handles less than two <c>SCRIPT_ITEM</c> structures. The function always adds a terminal item to the item analysis array so
		/// that the length of the item with zero-based index "i" is always available as:
		/// <para><c>pItems[i+1].iCharPos -pItems[i].iCharPos;</c></para>
		/// </param>
		/// <param name="pcItems">Pointer to the number of SCRIPT_ITEM structures processed.</param>
		/// <returns>
		/// <para>Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed.</para>
		/// <para>
		/// The function returns E_INVALIDARG if <c>pwcInChars</c> is set to <c>NULL</c>, <c>cInChars</c> is 0, <c>pItems</c> is set to
		/// <c>NULL</c>, or <c>cMaxItems</c> &lt; 2.
		/// </para>
		/// <para>
		/// The function returns E_OUTOFMEMORY if the value of <c>cMaxItems</c> is insufficient. As in all error cases, no items are fully
		/// processed and no part of the output array contains defined values. If the function returns E_OUTOFMEMORY, the application can
		/// call it again with a larger <c>pItems</c> buffer.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>See Displaying Text with Uniscribe for a discussion of the context in which this function is normally called.</para>
		/// <para>The function delimits items by either a change of shaping engine or a change of direction.</para>
		/// <para>
		/// The application can create multiple ranges, or runs that fall entirely within a single item, from each SCRIPT_ITEM structure
		/// retrieved by <c>ScriptItemize</c>. However, it should not combine multiple items into a single run. Later, when measuring or
		/// rendering, the application can call ScriptShape for each run and must pass the SCRIPT_ANALYSIS structure retrieved by
		/// <c>ScriptItemize</c> in the SCRIPT_ITEM structure.
		/// </para>
		/// <para>
		/// If the text handled by an application can include any right-to-left content, the application uses the <c>psControl</c> and
		/// <c>psState</c> parameters in calling <c>ScriptItemize</c>. However, the application does not have to do this and can handle
		/// bidirectional text itself instead of relying on Uniscribe to do so. The <c>psControl</c> and <c>psState</c> parameters are useful
		/// in some strictly left-to-right scenarios, for example, when the <c>fLinkStringBefore</c> member of SCRIPT_CONTROL is not specific
		/// to right-to-left scripts. The application sets <c>psControl</c> and <c>psState</c> to <c>NULL</c> to have <c>ScriptItemize</c>
		/// break the Unicode string purely by character code.
		/// </para>
		/// <para>
		/// The application can set all parameters to non- <c>NULL</c> values to have the function perform a full Unicode bidirectional
		/// analysis. To permit a correct Unicode bidirectional analysis, the SCRIPT_STATE structure should be initialized according to the
		/// reading order at paragraph start, and <c>ScriptItemize</c> should be passed the whole paragraph. In particular, the
		/// <c>uBidiLevel</c> member should be initialized to 0 for left-to-right and 1 for right-to-left.
		/// </para>
		/// <para>
		/// The <c>fRTL</c> member of SCRIPT_ANALYSIS is referenced in SCRIPT_ITEM enabled="1". The <c>fNumeric</c> member of
		/// SCRIPT_PROPERTIES is retrieved by ScriptGetProperties. These members together provide the same classification as the
		/// <c>lpClass</c> member of GCP_RESULTS, referenced by <c>lpResults</c> in GetCharacterPlacement.
		/// </para>
		/// <para>European digits U+0030 through U+0039 can be rendered as national digits, as shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>SCRIPT_STATE.fDigitSubstitute</term>
		/// <term>SCRIPT_CONTROL.fContextDigits</term>
		/// <term>Digit shapes displayed for Unicode U+0030 through U+0039</term>
		/// </listheader>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Any</term>
		/// <term>European digits</term>
		/// </item>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term><c>FALSE</c></term>
		/// <term>As specified in <c>uDefaultLanguage</c> member of SCRIPT_CONTROL.</term>
		/// </item>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term><c>TRUE</c></term>
		/// <term>As prior strong text, defaulting to <c>uDefaultLanguage</c> member of SCRIPT_CONTROL.</term>
		/// </item>
		/// </list>
		/// <para>In context digit mode, one of the following actions occurs:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If the script specified by <c>uDefaultLanguage</c> is in the same direction as the output, all digits encountered before the
		/// first letters are rendered in the language indicated by <c>uDefaultLanguage</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the script specified by <c>uDefaultLanguage</c> is in the opposite direction from the output, all digits encountered before
		/// the first letters are rendered in European digits.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// For example, if <c>uDefaultLanguage</c> indicates LANG_ARABIC, initial digits are in Arabic-Indic in a right-to-left embedding.
		/// However, they are in European digits in a left-to-right embedding.
		/// </para>
		/// <para>For more information, see Digit Shapes.</para>
		/// <para>
		/// The Unicode control characters and definitions, and their effects on SCRIPT_STATE members, are provided in the following table.
		/// For more information on Unicode control characters, see the The Unicode Standard.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Unicode control characters</term>
		/// <term>Meaning</term>
		/// <term>Effect on SCRIPT_STATE</term>
		/// </listheader>
		/// <item>
		/// <term>NADS</term>
		/// <term>Override European digits (NODS) with national digit shapes.</term>
		/// <term>Set <c>fDigitSubstitute</c>.</term>
		/// </item>
		/// <item>
		/// <term>NODS</term>
		/// <term>Use nominal digit shapes, otherwise known as European digits. See NADS.</term>
		/// <term>Clear <c>fDigitSubstitute</c>.</term>
		/// </item>
		/// <item>
		/// <term>ASS</term>
		/// <term>
		/// Activate swapping of symmetric pairs, for example, parentheses. For these characters, left and right are interpreted as opening
		/// and closing. This is the default. See ISS.
		/// </term>
		/// <term>Clear <c>fInhibitSymSwap</c>.</term>
		/// </item>
		/// <item>
		/// <term>ISS</term>
		/// <term>Inhibit swapping of symmetric pairs. See ASS.</term>
		/// <term>Set <c>fInhibitSymSwap</c>.</term>
		/// </item>
		/// <item>
		/// <term>AAFS</term>
		/// <term>Activate Arabic form shaping for Arabic presentation forms. See IAFS.</term>
		/// <term>Set <c>fCharShape</c>.</term>
		/// </item>
		/// <item>
		/// <term>IAFS</term>
		/// <term>
		/// Inhibit Arabic form shaping, that is, ligatures and cursive connections, for Arabic presentation forms. Nominal Arabic characters
		/// are not affected. This is the default. See AAFS.
		/// </term>
		/// <term>Clear <c>fCharShape</c>.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>fArabicNumContext</c> member of SCRIPT_STATE supports the context-sensitive display of numerals in Arabic script text. It
		/// indicates if digits are rendered using native Arabic script digit shapes or European digits. At the beginning of a paragraph,
		/// this member should normally be initialized to <c>TRUE</c> for an Arabic locale, or <c>FALSE</c> for any other locale. The
		/// function updates the script state it as it processes strong text.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptitemize HRESULT ScriptItemize( [in] const WCHAR
		// *pwcInChars, [in] int cInChars, [in] int cMaxItems, [in, optional] const SCRIPT_CONTROL *psControl, [in, optional] const
		// SCRIPT_STATE *psState, [out] SCRIPT_ITEM *pItems, [out] int *pcItems );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptItemize")]
		public static extern HRESULT ScriptItemize([MarshalAs(UnmanagedType.LPWStr)] string pwcInChars, int cInChars, int cMaxItems,
			in SCRIPT_CONTROL psControl, in SCRIPT_STATE psState,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] SCRIPT_ITEM[] pItems, out int pcItems);

		/// <summary>Breaks a Unicode string into individually shapeable items.</summary>
		/// <param name="pwcInChars">Pointer to a Unicode string to itemize.</param>
		/// <param name="cInChars">Number of characters in <c>pwcInChars</c> to itemize.</param>
		/// <param name="cMaxItems">Maximum number of SCRIPT_ITEM structures defining items to process.</param>
		/// <param name="psControl">
		/// <para>Pointer to a SCRIPT_CONTROL structure indicating the type of itemization to perform.</para>
		/// <para>
		/// Alternatively, the application can set this parameter to <c>NULL</c> if no SCRIPT_CONTROL properties are needed. For more
		/// information, see the Remarks section.
		/// </para>
		/// </param>
		/// <param name="psState">
		/// <para>Pointer to a SCRIPT_STATE structure indicating the initial bidirectional algorithm state.</para>
		/// <para>
		/// Alternatively, the application can set this parameter to <c>NULL</c> if the script state is not needed. For more information, see
		/// the Remarks section.
		/// </para>
		/// </param>
		/// <param name="pItems">
		/// Pointer to a buffer in which the function retrieves SCRIPT_ITEM structures representing the items that have been processed. The
		/// buffer should be <c>(cMaxItems + 1) * sizeof(SCRIPT_ITEM)</c> bytes in length. It is invalid to call this function with a buffer
		/// that handles less than two <c>SCRIPT_ITEM</c> structures. The function always adds a terminal item to the item analysis array so
		/// that the length of the item with zero-based index "i" is always available as:
		/// <para><c>pItems[i+1].iCharPos -pItems[i].iCharPos;</c></para>
		/// </param>
		/// <param name="pcItems">Pointer to the number of SCRIPT_ITEM structures processed.</param>
		/// <returns>
		/// <para>Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed.</para>
		/// <para>
		/// The function returns E_INVALIDARG if <c>pwcInChars</c> is set to <c>NULL</c>, <c>cInChars</c> is 0, <c>pItems</c> is set to
		/// <c>NULL</c>, or <c>cMaxItems</c> &lt; 2.
		/// </para>
		/// <para>
		/// The function returns E_OUTOFMEMORY if the value of <c>cMaxItems</c> is insufficient. As in all error cases, no items are fully
		/// processed and no part of the output array contains defined values. If the function returns E_OUTOFMEMORY, the application can
		/// call it again with a larger <c>pItems</c> buffer.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>See Displaying Text with Uniscribe for a discussion of the context in which this function is normally called.</para>
		/// <para>The function delimits items by either a change of shaping engine or a change of direction.</para>
		/// <para>
		/// The application can create multiple ranges, or runs that fall entirely within a single item, from each SCRIPT_ITEM structure
		/// retrieved by <c>ScriptItemize</c>. However, it should not combine multiple items into a single run. Later, when measuring or
		/// rendering, the application can call ScriptShape for each run and must pass the SCRIPT_ANALYSIS structure retrieved by
		/// <c>ScriptItemize</c> in the SCRIPT_ITEM structure.
		/// </para>
		/// <para>
		/// If the text handled by an application can include any right-to-left content, the application uses the <c>psControl</c> and
		/// <c>psState</c> parameters in calling <c>ScriptItemize</c>. However, the application does not have to do this and can handle
		/// bidirectional text itself instead of relying on Uniscribe to do so. The <c>psControl</c> and <c>psState</c> parameters are useful
		/// in some strictly left-to-right scenarios, for example, when the <c>fLinkStringBefore</c> member of SCRIPT_CONTROL is not specific
		/// to right-to-left scripts. The application sets <c>psControl</c> and <c>psState</c> to <c>NULL</c> to have <c>ScriptItemize</c>
		/// break the Unicode string purely by character code.
		/// </para>
		/// <para>
		/// The application can set all parameters to non- <c>NULL</c> values to have the function perform a full Unicode bidirectional
		/// analysis. To permit a correct Unicode bidirectional analysis, the SCRIPT_STATE structure should be initialized according to the
		/// reading order at paragraph start, and <c>ScriptItemize</c> should be passed the whole paragraph. In particular, the
		/// <c>uBidiLevel</c> member should be initialized to 0 for left-to-right and 1 for right-to-left.
		/// </para>
		/// <para>
		/// The <c>fRTL</c> member of SCRIPT_ANALYSIS is referenced in SCRIPT_ITEM enabled="1". The <c>fNumeric</c> member of
		/// SCRIPT_PROPERTIES is retrieved by ScriptGetProperties. These members together provide the same classification as the
		/// <c>lpClass</c> member of GCP_RESULTS, referenced by <c>lpResults</c> in GetCharacterPlacement.
		/// </para>
		/// <para>European digits U+0030 through U+0039 can be rendered as national digits, as shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>SCRIPT_STATE.fDigitSubstitute</term>
		/// <term>SCRIPT_CONTROL.fContextDigits</term>
		/// <term>Digit shapes displayed for Unicode U+0030 through U+0039</term>
		/// </listheader>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Any</term>
		/// <term>European digits</term>
		/// </item>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term><c>FALSE</c></term>
		/// <term>As specified in <c>uDefaultLanguage</c> member of SCRIPT_CONTROL.</term>
		/// </item>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term><c>TRUE</c></term>
		/// <term>As prior strong text, defaulting to <c>uDefaultLanguage</c> member of SCRIPT_CONTROL.</term>
		/// </item>
		/// </list>
		/// <para>In context digit mode, one of the following actions occurs:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If the script specified by <c>uDefaultLanguage</c> is in the same direction as the output, all digits encountered before the
		/// first letters are rendered in the language indicated by <c>uDefaultLanguage</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the script specified by <c>uDefaultLanguage</c> is in the opposite direction from the output, all digits encountered before
		/// the first letters are rendered in European digits.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// For example, if <c>uDefaultLanguage</c> indicates LANG_ARABIC, initial digits are in Arabic-Indic in a right-to-left embedding.
		/// However, they are in European digits in a left-to-right embedding.
		/// </para>
		/// <para>For more information, see Digit Shapes.</para>
		/// <para>
		/// The Unicode control characters and definitions, and their effects on SCRIPT_STATE members, are provided in the following table.
		/// For more information on Unicode control characters, see the The Unicode Standard.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Unicode control characters</term>
		/// <term>Meaning</term>
		/// <term>Effect on SCRIPT_STATE</term>
		/// </listheader>
		/// <item>
		/// <term>NADS</term>
		/// <term>Override European digits (NODS) with national digit shapes.</term>
		/// <term>Set <c>fDigitSubstitute</c>.</term>
		/// </item>
		/// <item>
		/// <term>NODS</term>
		/// <term>Use nominal digit shapes, otherwise known as European digits. See NADS.</term>
		/// <term>Clear <c>fDigitSubstitute</c>.</term>
		/// </item>
		/// <item>
		/// <term>ASS</term>
		/// <term>
		/// Activate swapping of symmetric pairs, for example, parentheses. For these characters, left and right are interpreted as opening
		/// and closing. This is the default. See ISS.
		/// </term>
		/// <term>Clear <c>fInhibitSymSwap</c>.</term>
		/// </item>
		/// <item>
		/// <term>ISS</term>
		/// <term>Inhibit swapping of symmetric pairs. See ASS.</term>
		/// <term>Set <c>fInhibitSymSwap</c>.</term>
		/// </item>
		/// <item>
		/// <term>AAFS</term>
		/// <term>Activate Arabic form shaping for Arabic presentation forms. See IAFS.</term>
		/// <term>Set <c>fCharShape</c>.</term>
		/// </item>
		/// <item>
		/// <term>IAFS</term>
		/// <term>
		/// Inhibit Arabic form shaping, that is, ligatures and cursive connections, for Arabic presentation forms. Nominal Arabic characters
		/// are not affected. This is the default. See AAFS.
		/// </term>
		/// <term>Clear <c>fCharShape</c>.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>fArabicNumContext</c> member of SCRIPT_STATE supports the context-sensitive display of numerals in Arabic script text. It
		/// indicates if digits are rendered using native Arabic script digit shapes or European digits. At the beginning of a paragraph,
		/// this member should normally be initialized to <c>TRUE</c> for an Arabic locale, or <c>FALSE</c> for any other locale. The
		/// function updates the script state it as it processes strong text.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptitemize HRESULT ScriptItemize( [in] const WCHAR
		// *pwcInChars, [in] int cInChars, [in] int cMaxItems, [in, optional] const SCRIPT_CONTROL *psControl, [in, optional] const
		// SCRIPT_STATE *psState, [out] SCRIPT_ITEM *pItems, [out] int *pcItems );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptItemize")]
		public static extern HRESULT ScriptItemize([MarshalAs(UnmanagedType.LPWStr)] string pwcInChars, int cInChars, int cMaxItems,
			[In, Optional] IntPtr psControl, [In, Optional] IntPtr psState,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] SCRIPT_ITEM[] pItems, out int pcItems);

		/// <summary>
		/// Breaks a Unicode string into individually shapeable items and provides an array of feature tags for each shapeable item for
		/// OpenType processing.
		/// </summary>
		/// <param name="pwcInChars">Pointer to a Unicode string to itemize.</param>
		/// <param name="cInChars">Number of characters in <c>pwcInChars</c> to itemize.</param>
		/// <param name="cMaxItems">Maximum number of SCRIPT_ITEM structures defining items to process.</param>
		/// <param name="psControl">
		/// <para>Pointer to a SCRIPT_CONTROL structure indicating the type of itemization to perform.</para>
		/// <para>
		/// Alternatively, the application can set this parameter to <c>NULL</c> if no SCRIPT_CONTROL properties are needed. For more
		/// information, see the Remarks section.
		/// </para>
		/// </param>
		/// <param name="psState">
		/// <para>Pointer to a SCRIPT_STATE structure indicating the initial bidirectional algorithm state.</para>
		/// <para>
		/// Alternatively, the application can set this parameter to <c>NULL</c> if the script state is not needed. For more information, see
		/// the Remarks section.
		/// </para>
		/// </param>
		/// <param name="pItems">
		/// Pointer to a buffer in which the function retrieves SCRIPT_ITEM structures representing the items that have been processed. The
		/// buffer should be <c>(cMaxItems + 1) * sizeof(SCRIPT_ITEM)</c> bytes in length. It is invalid to call this function with a buffer
		/// that handles less than two <c>SCRIPT_ITEM</c> structures. The function always adds a terminal item to the item analysis array so
		/// that the length of the item with zero-based index "i" is always available as:
		/// <para><c>pItems[i+1].iCharPos -pItems[i].iCharPos;</c></para>
		/// </param>
		/// <param name="pScriptTags">
		/// <para>
		/// Pointer to a buffer in which the function retrieves an array of OPENTYPE_TAG structures representing script tags. The buffer
		/// should be
		/// <code>cMaxItems * sizeof(OPENTYPE_TAG)</code>
		/// bytes in length.
		/// </para>
		/// <para>
		/// <c>Note</c> When all characters in an item are neutral, the value of this parameter is SCRIPT_TAG_UNKNOWN (0x00000000). This can
		/// happen, for example, if an item consists entirely of punctuation.
		/// </para>
		/// </param>
		/// <param name="pcItems">Pointer to the number of SCRIPT_ITEM structures processed.</param>
		/// <returns>
		/// <para>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. In all error cases, no items are
		/// fully processed and no part of the output contains defined values. The application can test the return value with the
		/// <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </para>
		/// <para>
		/// The function returns E_OUTOFMEMORY if the size indicated by <c>cMaxItems</c> is too small. The application can try calling the
		/// function again with a larger buffer.
		/// </para>
		/// <para>The function returns E_INVALIDARG if one or more of the following conditions occur:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>pwcInChars</c> is set to <c>NULL</c></term>
		/// </item>
		/// <item>
		/// <term><c>cInChars</c> is 0</term>
		/// </item>
		/// <item>
		/// <term><c>pItems</c> is set to <c>NULL</c></term>
		/// </item>
		/// <item>
		/// <term><c>pScriptTags</c> is set to <c>NULL</c></term>
		/// </item>
		/// <item>
		/// <term><c>cMaxItems</c> &lt; 2</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>ScriptItemizeOpenType</c> is preferred over the older ScriptItemize function. One advantage of <c>ScriptItemizeOpenType</c> is
		/// the availability of feature tags for each shapeable item.
		/// </para>
		/// <para>See Displaying Text with Uniscribe for a discussion of the context in which this function is normally called.</para>
		/// <para>The function delimits items by either a change of shaping engine or a change of direction.</para>
		/// <para>
		/// The application can create multiple ranges, or runs that fall entirely within a single item, from each SCRIPT_ITEM structure
		/// retrieved by <c>ScriptItemizeOpenType</c>. However, it should not combine multiple items into a single run. When measuring or
		/// rendering, the application can call ScriptShapeOpenType for each run and must pass the corresponding SCRIPT_ANALYSIS structure in
		/// the SCRIPT_ITEM structure retrieved by <c>ScriptItemizeOpenType</c>.
		/// </para>
		/// <para>
		/// If the text handled by an application can include any right-to-left content, the application uses the <c>psControl</c> and
		/// <c>psState</c> parameters in calling <c>ScriptItemizeOpenType</c>. However, the application does not have to do this and can
		/// handle bidirectional text itself instead of relying on Uniscribe to do so. The <c>psControl</c> and <c>psState</c> parameters are
		/// useful in some strictly left-to-right scenarios, for example, when the <c>fLinkStringBefore</c> member of SCRIPT_CONTROL is not
		/// specific to right-to-left scripts. The application sets <c>psControl</c> and <c>psState</c> to <c>NULL</c> to have
		/// <c>ScriptItemizeOpenType</c> break the Unicode string purely by character code.
		/// </para>
		/// <para>
		/// The application can set all parameters to non- <c>NULL</c> values to have the function perform a full Unicode bidirectional
		/// analysis. To permit a correct Unicode bidirectional analysis, the SCRIPT_STATE structure should be initialized according to the
		/// reading order at paragraph start, and <c>ScriptItemizeOpenType</c> should be passed the whole paragraph. In particular, the
		/// <c>uBidiLevel</c> member should be initialized to 0 for left-to-right and 1 for right-to-left.
		/// </para>
		/// <para>
		/// The <c>fRTL</c> member of SCRIPT_ANALYSIS is referenced in SCRIPT_ITEM. The <c>fNumeric</c> member of SCRIPT_PROPERTIES is
		/// retrieved by ScriptGetProperties. These members together provide the same classification as the <c>lpClass</c> member of
		/// GCP_RESULTS, referenced by <c>lpResults</c> in GetCharacterPlacement.
		/// </para>
		/// <para>European digits U+0030 through U+0039 can be rendered as national digits, as shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>SCRIPT_STATE.fDigitSubstitute</term>
		/// <term>SCRIPT_CONTROL.fContextDigits</term>
		/// <term>Digit shapes displayed for Unicode U+0030 through U+0039</term>
		/// </listheader>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Any</term>
		/// <term>European digits</term>
		/// </item>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term><c>FALSE</c></term>
		/// <term>As specified in <c>uDefaultLanguage</c> member of SCRIPT_CONTROL.</term>
		/// </item>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term><c>TRUE</c></term>
		/// <term>As prior strong text, defaulting to <c>uDefaultLanguage</c> member of SCRIPT_CONTROL.</term>
		/// </item>
		/// </list>
		/// <para>In context digit mode, one of the following actions occurs:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If the script specified by <c>uDefaultLanguage</c> is in the same direction as the output, all digits encountered before the
		/// first letters are rendered in the language indicated by <c>uDefaultLanguage</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the script specified by <c>uDefaultLanguage</c> is in the opposite direction from the output, all digits encountered before
		/// the first letters are rendered in European digits.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// For example, if <c>uDefaultLanguage</c> indicates LANG_ARABIC, initial digits are in Arabic-Indic in a right-to-left embedding.
		/// However they are in European digits in a left-to-right embedding.
		/// </para>
		/// <para>For more information, see Digit Shapes.</para>
		/// <para>
		/// The Unicode control characters and definitions, and their effects on SCRIPT_STATE members, are provided in the following table.
		/// For more information on Unicode control characters, see the The Unicode Standard.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Unicode control characters</term>
		/// <term>Meaning</term>
		/// <term>Effect on SCRIPT_STATE</term>
		/// </listheader>
		/// <item>
		/// <term>NADS</term>
		/// <term>Override European digits (NODS) with national digit shapes.</term>
		/// <term>Set <c>fDigitSubstitute</c>.</term>
		/// </item>
		/// <item>
		/// <term>NODS</term>
		/// <term>Use nominal digit shapes, otherwise known as European digits. See NADS.</term>
		/// <term>Clear <c>fDigitSubstitute</c>.</term>
		/// </item>
		/// <item>
		/// <term>ASS</term>
		/// <term>
		/// Activate swapping of symmetric pairs, for example, parentheses. For these characters, left and right are interpreted as opening
		/// and closing. This is the default. See ISS.
		/// </term>
		/// <term>Clear <c>fInhibitSymSwap</c>.</term>
		/// </item>
		/// <item>
		/// <term>ISS</term>
		/// <term>Inhibit swapping of symmetric pairs. See ASS.</term>
		/// <term>Set <c>fInhibitSymSwap</c>.</term>
		/// </item>
		/// <item>
		/// <term>AAFS</term>
		/// <term>Activate Arabic form shaping for Arabic presentation forms. See IAFS.</term>
		/// <term>Set <c>fCharShape</c>.</term>
		/// </item>
		/// <item>
		/// <term>IAFS</term>
		/// <term>
		/// Inhibit Arabic form shaping, that is, ligatures and cursive connections, for Arabic presentation forms. Nominal Arabic characters
		/// are not affected. This is the default. See AAFS.
		/// </term>
		/// <term>Clear <c>fCharShape</c>.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>fArabicNumContext</c> member of SCRIPT_STATE supports the context-sensitive display of numerals in Arabic script text. It
		/// indicates if digits are rendered using native Arabic script digit shapes or European digits. At the beginning of a paragraph,
		/// this member should normally be initialized to <c>TRUE</c> for an Arabic locale, or <c>FALSE</c> for any other locale. The
		/// function updates the script state it as it processes strong text.
		/// </para>
		/// <para>
		/// The output parameter <c>pScriptTags</c> indicates an array with entries parallel to items. For each item, this function retrieves
		/// a script tag that should be used for shaping in all subsequent operations.
		/// </para>
		/// <para>
		/// A script tag is usually determined by <c>ScriptItemizeOpenType</c> from input characters. If the function retrieves a specific
		/// script tag, the application should pass it to other functions without change. However, when characters are neutral (for example,
		/// digits) and the script cannot be determined, the application should choose an appropriate script tag, for example, based on font
		/// and language associated with text.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptitemizeopentype HRESULT ScriptItemizeOpenType( [in] const
		// WCHAR *pwcInChars, [in] int cInChars, [in] int cMaxItems, [in, optional] const SCRIPT_CONTROL *psControl, [in, optional] const
		// SCRIPT_STATE *psState, [out] SCRIPT_ITEM *pItems, [out] OPENTYPE_TAG *pScriptTags, [out] int *pcItems );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptItemizeOpenType")]
		public static extern HRESULT ScriptItemizeOpenType([MarshalAs(UnmanagedType.LPWStr)] string pwcInChars, int cInChars, int cMaxItems,
			in SCRIPT_CONTROL psControl, in SCRIPT_STATE psState, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] SCRIPT_ITEM[] pItems,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] OPENTYPE_TAG[] pScriptTags, out int pcItems);

		/// <summary>
		/// Breaks a Unicode string into individually shapeable items and provides an array of feature tags for each shapeable item for
		/// OpenType processing.
		/// </summary>
		/// <param name="pwcInChars">Pointer to a Unicode string to itemize.</param>
		/// <param name="cInChars">Number of characters in <c>pwcInChars</c> to itemize.</param>
		/// <param name="cMaxItems">Maximum number of SCRIPT_ITEM structures defining items to process.</param>
		/// <param name="psControl">
		/// <para>Pointer to a SCRIPT_CONTROL structure indicating the type of itemization to perform.</para>
		/// <para>
		/// Alternatively, the application can set this parameter to <c>NULL</c> if no SCRIPT_CONTROL properties are needed. For more
		/// information, see the Remarks section.
		/// </para>
		/// </param>
		/// <param name="psState">
		/// <para>Pointer to a SCRIPT_STATE structure indicating the initial bidirectional algorithm state.</para>
		/// <para>
		/// Alternatively, the application can set this parameter to <c>NULL</c> if the script state is not needed. For more information, see
		/// the Remarks section.
		/// </para>
		/// </param>
		/// <param name="pItems">
		/// Pointer to a buffer in which the function retrieves SCRIPT_ITEM structures representing the items that have been processed. The
		/// buffer should be <c>(cMaxItems + 1) * sizeof(SCRIPT_ITEM)</c> bytes in length. It is invalid to call this function with a buffer
		/// that handles less than two <c>SCRIPT_ITEM</c> structures. The function always adds a terminal item to the item analysis array so
		/// that the length of the item with zero-based index "i" is always available as:
		/// <para><c>pItems[i+1].iCharPos -pItems[i].iCharPos;</c></para>
		/// </param>
		/// <param name="pScriptTags">
		/// <para>
		/// Pointer to a buffer in which the function retrieves an array of OPENTYPE_TAG structures representing script tags. The buffer
		/// should be
		/// <code>cMaxItems * sizeof(OPENTYPE_TAG)</code>
		/// bytes in length.
		/// </para>
		/// <para>
		/// <c>Note</c> When all characters in an item are neutral, the value of this parameter is SCRIPT_TAG_UNKNOWN (0x00000000). This can
		/// happen, for example, if an item consists entirely of punctuation.
		/// </para>
		/// </param>
		/// <param name="pcItems">Pointer to the number of SCRIPT_ITEM structures processed.</param>
		/// <returns>
		/// <para>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. In all error cases, no items are
		/// fully processed and no part of the output contains defined values. The application can test the return value with the
		/// <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </para>
		/// <para>
		/// The function returns E_OUTOFMEMORY if the size indicated by <c>cMaxItems</c> is too small. The application can try calling the
		/// function again with a larger buffer.
		/// </para>
		/// <para>The function returns E_INVALIDARG if one or more of the following conditions occur:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>pwcInChars</c> is set to <c>NULL</c></term>
		/// </item>
		/// <item>
		/// <term><c>cInChars</c> is 0</term>
		/// </item>
		/// <item>
		/// <term><c>pItems</c> is set to <c>NULL</c></term>
		/// </item>
		/// <item>
		/// <term><c>pScriptTags</c> is set to <c>NULL</c></term>
		/// </item>
		/// <item>
		/// <term><c>cMaxItems</c> &lt; 2</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>ScriptItemizeOpenType</c> is preferred over the older ScriptItemize function. One advantage of <c>ScriptItemizeOpenType</c> is
		/// the availability of feature tags for each shapeable item.
		/// </para>
		/// <para>See Displaying Text with Uniscribe for a discussion of the context in which this function is normally called.</para>
		/// <para>The function delimits items by either a change of shaping engine or a change of direction.</para>
		/// <para>
		/// The application can create multiple ranges, or runs that fall entirely within a single item, from each SCRIPT_ITEM structure
		/// retrieved by <c>ScriptItemizeOpenType</c>. However, it should not combine multiple items into a single run. When measuring or
		/// rendering, the application can call ScriptShapeOpenType for each run and must pass the corresponding SCRIPT_ANALYSIS structure in
		/// the SCRIPT_ITEM structure retrieved by <c>ScriptItemizeOpenType</c>.
		/// </para>
		/// <para>
		/// If the text handled by an application can include any right-to-left content, the application uses the <c>psControl</c> and
		/// <c>psState</c> parameters in calling <c>ScriptItemizeOpenType</c>. However, the application does not have to do this and can
		/// handle bidirectional text itself instead of relying on Uniscribe to do so. The <c>psControl</c> and <c>psState</c> parameters are
		/// useful in some strictly left-to-right scenarios, for example, when the <c>fLinkStringBefore</c> member of SCRIPT_CONTROL is not
		/// specific to right-to-left scripts. The application sets <c>psControl</c> and <c>psState</c> to <c>NULL</c> to have
		/// <c>ScriptItemizeOpenType</c> break the Unicode string purely by character code.
		/// </para>
		/// <para>
		/// The application can set all parameters to non- <c>NULL</c> values to have the function perform a full Unicode bidirectional
		/// analysis. To permit a correct Unicode bidirectional analysis, the SCRIPT_STATE structure should be initialized according to the
		/// reading order at paragraph start, and <c>ScriptItemizeOpenType</c> should be passed the whole paragraph. In particular, the
		/// <c>uBidiLevel</c> member should be initialized to 0 for left-to-right and 1 for right-to-left.
		/// </para>
		/// <para>
		/// The <c>fRTL</c> member of SCRIPT_ANALYSIS is referenced in SCRIPT_ITEM. The <c>fNumeric</c> member of SCRIPT_PROPERTIES is
		/// retrieved by ScriptGetProperties. These members together provide the same classification as the <c>lpClass</c> member of
		/// GCP_RESULTS, referenced by <c>lpResults</c> in GetCharacterPlacement.
		/// </para>
		/// <para>European digits U+0030 through U+0039 can be rendered as national digits, as shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>SCRIPT_STATE.fDigitSubstitute</term>
		/// <term>SCRIPT_CONTROL.fContextDigits</term>
		/// <term>Digit shapes displayed for Unicode U+0030 through U+0039</term>
		/// </listheader>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Any</term>
		/// <term>European digits</term>
		/// </item>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term><c>FALSE</c></term>
		/// <term>As specified in <c>uDefaultLanguage</c> member of SCRIPT_CONTROL.</term>
		/// </item>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term><c>TRUE</c></term>
		/// <term>As prior strong text, defaulting to <c>uDefaultLanguage</c> member of SCRIPT_CONTROL.</term>
		/// </item>
		/// </list>
		/// <para>In context digit mode, one of the following actions occurs:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If the script specified by <c>uDefaultLanguage</c> is in the same direction as the output, all digits encountered before the
		/// first letters are rendered in the language indicated by <c>uDefaultLanguage</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the script specified by <c>uDefaultLanguage</c> is in the opposite direction from the output, all digits encountered before
		/// the first letters are rendered in European digits.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// For example, if <c>uDefaultLanguage</c> indicates LANG_ARABIC, initial digits are in Arabic-Indic in a right-to-left embedding.
		/// However they are in European digits in a left-to-right embedding.
		/// </para>
		/// <para>For more information, see Digit Shapes.</para>
		/// <para>
		/// The Unicode control characters and definitions, and their effects on SCRIPT_STATE members, are provided in the following table.
		/// For more information on Unicode control characters, see the The Unicode Standard.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Unicode control characters</term>
		/// <term>Meaning</term>
		/// <term>Effect on SCRIPT_STATE</term>
		/// </listheader>
		/// <item>
		/// <term>NADS</term>
		/// <term>Override European digits (NODS) with national digit shapes.</term>
		/// <term>Set <c>fDigitSubstitute</c>.</term>
		/// </item>
		/// <item>
		/// <term>NODS</term>
		/// <term>Use nominal digit shapes, otherwise known as European digits. See NADS.</term>
		/// <term>Clear <c>fDigitSubstitute</c>.</term>
		/// </item>
		/// <item>
		/// <term>ASS</term>
		/// <term>
		/// Activate swapping of symmetric pairs, for example, parentheses. For these characters, left and right are interpreted as opening
		/// and closing. This is the default. See ISS.
		/// </term>
		/// <term>Clear <c>fInhibitSymSwap</c>.</term>
		/// </item>
		/// <item>
		/// <term>ISS</term>
		/// <term>Inhibit swapping of symmetric pairs. See ASS.</term>
		/// <term>Set <c>fInhibitSymSwap</c>.</term>
		/// </item>
		/// <item>
		/// <term>AAFS</term>
		/// <term>Activate Arabic form shaping for Arabic presentation forms. See IAFS.</term>
		/// <term>Set <c>fCharShape</c>.</term>
		/// </item>
		/// <item>
		/// <term>IAFS</term>
		/// <term>
		/// Inhibit Arabic form shaping, that is, ligatures and cursive connections, for Arabic presentation forms. Nominal Arabic characters
		/// are not affected. This is the default. See AAFS.
		/// </term>
		/// <term>Clear <c>fCharShape</c>.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>fArabicNumContext</c> member of SCRIPT_STATE supports the context-sensitive display of numerals in Arabic script text. It
		/// indicates if digits are rendered using native Arabic script digit shapes or European digits. At the beginning of a paragraph,
		/// this member should normally be initialized to <c>TRUE</c> for an Arabic locale, or <c>FALSE</c> for any other locale. The
		/// function updates the script state it as it processes strong text.
		/// </para>
		/// <para>
		/// The output parameter <c>pScriptTags</c> indicates an array with entries parallel to items. For each item, this function retrieves
		/// a script tag that should be used for shaping in all subsequent operations.
		/// </para>
		/// <para>
		/// A script tag is usually determined by <c>ScriptItemizeOpenType</c> from input characters. If the function retrieves a specific
		/// script tag, the application should pass it to other functions without change. However, when characters are neutral (for example,
		/// digits) and the script cannot be determined, the application should choose an appropriate script tag, for example, based on font
		/// and language associated with text.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptitemizeopentype HRESULT ScriptItemizeOpenType( [in] const
		// WCHAR *pwcInChars, [in] int cInChars, [in] int cMaxItems, [in, optional] const SCRIPT_CONTROL *psControl, [in, optional] const
		// SCRIPT_STATE *psState, [out] SCRIPT_ITEM *pItems, [out] OPENTYPE_TAG *pScriptTags, [out] int *pcItems );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptItemizeOpenType")]
		public static extern HRESULT ScriptItemizeOpenType([MarshalAs(UnmanagedType.LPWStr)] string pwcInChars, int cInChars, int cMaxItems,
			[In, Optional] IntPtr psControl, [In, Optional] IntPtr psState, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] SCRIPT_ITEM[] pItems,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] OPENTYPE_TAG[] pScriptTags, out int pcItems);

		/// <summary>Creates an advance widths table to allow text justification when passed to the ScriptTextOut function.</summary>
		/// <param name="psva">
		/// Pointer to an array, of length indicated by <c>cGlyphs</c>, containing SCRIPT_VISATTR structures. Each structure contains visual
		/// attributes for a glyph in the line to process.
		/// </param>
		/// <param name="piAdvance">
		/// Pointer to an advance widths array, of length indicated by <c>cGlyphs</c>, obtained from a previous call to ScriptPlace.
		/// </param>
		/// <param name="cGlyphs">
		/// Count of glyphs for the arrays indicated by <c>psva</c> and <c>piAdvance</c>. This parameter also indicates the count of glyphs
		/// for the output parameter <c>piJustify</c>.
		/// </param>
		/// <param name="iDx">Width, in pixels, of the desired change, either an increase of decrease.</param>
		/// <param name="iMinKashida">Minimum width of a kashida glyph to generate.</param>
		/// <param name="piJustify">
		/// Pointer to a buffer in which this function retrieves an array, of length indicated by <c>cGlyphs</c>, containing justified
		/// advance widths. The justified widths are sometimes called "cell widths" to distinguish them from unjustified advance widths.
		/// </param>
		/// <returns>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>See Displaying Text with Uniscribe for a discussion of the context in which this function is normally called.</para>
		/// <para>
		/// This function provides a simple implementation of multilingual justification. It establishes the amount of adjustment to make at
		/// each glyph position on the line. It interprets the SCRIPT_VISATTR array generated by a call to ScriptShape, giving top priority
		/// to kashida. The function uses interword spacing if no kashida points are available. It uses intercharacter spacing if no
		/// interword points are available.
		/// </para>
		/// <para>
		/// <c>Note</c> Sophisticated text formatters might generate their own delta dx array by combining formatter-specific features with
		/// the information retrieved by ScriptShape in the SCRIPT_VISATTR array.
		/// </para>
		/// <para>
		/// The application should pass the justified advance widths generated by <c>ScriptJustify</c> to ScriptTextOut in the
		/// <c>piJustify</c> parameter.
		/// </para>
		/// <para>
		/// <c>ScriptJustify</c> creates a justified array containing updated advance widths for each glyph. When an advance width for a
		/// glyph is increased, the extra width is rendered to the right of the glyph, with a white space or, for Arabic text, a kashida.
		/// </para>
		/// <para>
		/// <c>Note</c> Kashida insertion occurs to the right of the glyph to justify visually. Microsoft Word and Microsoft PowerPoint use
		/// this concept. Any change in the kashida placement algorithm should accompany a change in the corresponding ScriptTextOut handler
		/// for a particular script, for example, the Arabic TextOut justification handler.
		/// </para>
		/// <para>
		/// Sometimes the application tries to handle glyphs that cannot be justified, in which case the <c>uJustification</c> member of
		/// SCRIPT_VISATTR is set to SCRIPT_JUSTIFY_NONE. In this case, <c>ScriptJustify</c> copies the input array indicated by
		/// <c>piAdvance</c> to the output array indicated by <c>piJustify</c> and returns S_FALSE to the application.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptjustify HRESULT ScriptJustify( [in] const SCRIPT_VISATTR
		// *psva, [in] const int *piAdvance, [in] int cGlyphs, [in] int iDx, [in] int iMinKashida, [out] int *piJustify );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptJustify")]
		public static extern HRESULT ScriptJustify([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] SCRIPT_VISATTR[] psva,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] piAdvance, int cGlyphs, int iDx, int iMinKashida,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] piJustify);

		/// <summary>Converts an array of run embedding levels to a map of visual-to-logical position and/or logical-to-visual position.</summary>
		/// <param name="cRuns">Number of runs to process.</param>
		/// <param name="pbLevel">
		/// Pointer to an array, of length indicated by <c>cRuns</c>, containing run embedding levels. Embedding levels for all runs on the
		/// line must be included, ordered logically. For more information, see the Remarks section.
		/// </param>
		/// <param name="piVisualToLogical">
		/// Pointer to an array, of length indicated by <c>cRuns</c>, in which this function retrieves the run embedding levels reordered to
		/// visual order. The first array element represents the run to display at the far left, and subsequent entries should be displayed
		/// progressing from left to right. The function sets this parameter to <c>NULL</c> if there is no output.
		/// </param>
		/// <param name="piLogicalToVisual">
		/// Pointer to an array, of length indicated by <c>cRuns</c>, in which this function retrieves the visual run positions. The first
		/// array element is the relative visual position where the first logical run should be displayed, the leftmost display position
		/// being 0. The function sets this parameter to <c>NULL</c> if there is no output.
		/// </param>
		/// <returns>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>See Displaying Text with Uniscribe for a discussion of the context in which this function is normally called.</para>
		/// <para>This function handles only data that pertains to a single line of text.</para>
		/// <para>
		/// The run embedding levels are defined in the Unicode bidirectional algorithm. They describe the direction of a run, the direction
		/// of any runs in which it is embedded, and the direction of the paragraph. No other input is required for the call to this
		/// function. For more information, see Unicode.
		/// </para>
		/// <para>The following table lists the predefined embedding levels. The application can add levels as needed.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Level</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>A left-to-right run in a left-to-right paragraph.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// A right-to-left run embedded in a left-to-right run in a left-to-right paragraph. Alternatively, a right-to-left run, not
		/// embedded in another run, in a right-to-left paragraph.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>A left-to-right run embedded in a right-to-left run of type 1.</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>A right-to-left run embedded in a left-to-right run of type 2.</term>
		/// </item>
		/// </list>
		/// <para>
		/// A "logical position" refers to the placement of a run relative to other runs. It is the position in a backing store, and
		/// corresponds to the order in which the user reads the text aloud. The "visual position" of a run refers to the way the run is
		/// visually displayed on the line, taking into account the possible directions that the run can have.
		/// </para>
		/// <para>The application can call this function setting either <c>piLogicalToVisual</c> or <c>piVisualToLogical</c>, or both.</para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptlayout HRESULT ScriptLayout( [in] int cRuns, [in] const
		// BYTE *pbLevel, [out, optional] int *piVisualToLogical, [out, optional] int *piLogicalToVisual );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptLayout")]
		public static extern HRESULT ScriptLayout(int cRuns, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] pbLevel,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] piVisualToLogical,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] piLogicalToVisual);

		/// <summary>Generates glyph advance width and two-dimensional offset information from the output of ScriptShape.</summary>
		/// <param name="hdc">Optional. Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="pwGlyphs">Pointer to a glyph buffer obtained from an earlier call to the ScriptShape function.</param>
		/// <param name="cGlyphs">Count of glyphs in the glyph buffer.</param>
		/// <param name="psva">Pointer to an array of SCRIPT_VISATTR structures indicating visual attributes.</param>
		/// <param name="psa">
		/// Pointer to a SCRIPT_ANALYSIS structure. On input, this structure is obtained from a previous call to ScriptItemize. On output,
		/// this structure contains values retrieved by <c>ScriptPlace</c>.
		/// </param>
		/// <param name="piAdvance">Pointer to an array in which this function retrieves advance width information.</param>
		/// <param name="pGoffset">
		/// Optional. Pointer to an array of GOFFSET structures in which this function retrieves the x and y offsets of combining glyphs.
		/// This array must be of length indicated by <c>cGlyphs</c>.
		/// </param>
		/// <param name="pABC">Pointer to an ABC structure in which this function retrieves the ABC width for the entire run.</param>
		/// <returns>
		/// <para>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </para>
		/// <para>
		/// The function returns E_PENDING if the script cache specified by the <c>psc</c> parameter does not contain enough information to
		/// place the glyphs, and the <c>hdc</c> parameter is set to <c>NULL</c> so that the function cannot complete the placement process.
		/// The application should set up a correct device context for the run, and call this function again with the appropriate device
		/// context and with all other parameters the same.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>See Displaying Text with Uniscribe for a discussion of the context in which this function is normally called.</para>
		/// <para>
		/// The composite ABC width for the whole item identifies how much the glyphs overhang to the left of the start position and to the
		/// right of the length implied by the sum of the advance widths. The total advance width of the line is exactly abcA+abcB+abcC. The
		/// abcA and abcC values are maintained as proportions of the cell height represented in 8 bits and are thus roughly +/-1 percent.
		/// The total width retrieved, which is the sum of the abcA+abcB+abcC values indicated by <c>piAdvance</c>, is accurate to the
		/// resolution of the TrueType shaping engine.
		/// </para>
		/// <para>
		/// All arrays are in visual order unless the <c>fLogicalOrder</c> member is set in the SCRIPT_ANALYSIS structure indicated by the
		/// <c>psa</c> parameter.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptplace HRESULT ScriptPlace( [in] HDC hdc, [in, out]
		// SCRIPT_CACHE *psc, [in] const WORD *pwGlyphs, [in] int cGlyphs, [in] const SCRIPT_VISATTR *psva, [in, out] SCRIPT_ANALYSIS *psa,
		// [out] int *piAdvance, [out] GOFFSET *pGoffset, [out] ABC *pABC );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptPlace")]
		public static extern HRESULT ScriptPlace([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ushort[] pwGlyphs,
			int cGlyphs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] SCRIPT_VISATTR[] psva, ref SCRIPT_ANALYSIS psa,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] int[] piAdvance,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] GOFFSET[] pGoffset, out ABC pABC);

		/// <summary>Generates glyph advance width and two-dimensional offset information from the output of ScriptShape.</summary>
		/// <param name="hdc">Optional. Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="pwGlyphs">Pointer to a glyph buffer obtained from an earlier call to the ScriptShape function.</param>
		/// <param name="cGlyphs">Count of glyphs in the glyph buffer.</param>
		/// <param name="psva">Pointer to an array of SCRIPT_VISATTR structures indicating visual attributes.</param>
		/// <param name="psa">
		/// Pointer to a SCRIPT_ANALYSIS structure. On input, this structure is obtained from a previous call to ScriptItemize. On output,
		/// this structure contains values retrieved by <c>ScriptPlace</c>.
		/// </param>
		/// <param name="piAdvance">Pointer to an array in which this function retrieves advance width information.</param>
		/// <param name="pGoffset">
		/// Optional. Pointer to an array of GOFFSET structures in which this function retrieves the x and y offsets of combining glyphs.
		/// This array must be of length indicated by <c>cGlyphs</c>.
		/// </param>
		/// <param name="pABC">Pointer to an ABC structure in which this function retrieves the ABC width for the entire run.</param>
		/// <returns>
		/// <para>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </para>
		/// <para>
		/// The function returns E_PENDING if the script cache specified by the <c>psc</c> parameter does not contain enough information to
		/// place the glyphs, and the <c>hdc</c> parameter is set to <c>NULL</c> so that the function cannot complete the placement process.
		/// The application should set up a correct device context for the run, and call this function again with the appropriate device
		/// context and with all other parameters the same.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>See Displaying Text with Uniscribe for a discussion of the context in which this function is normally called.</para>
		/// <para>
		/// The composite ABC width for the whole item identifies how much the glyphs overhang to the left of the start position and to the
		/// right of the length implied by the sum of the advance widths. The total advance width of the line is exactly abcA+abcB+abcC. The
		/// abcA and abcC values are maintained as proportions of the cell height represented in 8 bits and are thus roughly +/-1 percent.
		/// The total width retrieved, which is the sum of the abcA+abcB+abcC values indicated by <c>piAdvance</c>, is accurate to the
		/// resolution of the TrueType shaping engine.
		/// </para>
		/// <para>
		/// All arrays are in visual order unless the <c>fLogicalOrder</c> member is set in the SCRIPT_ANALYSIS structure indicated by the
		/// <c>psa</c> parameter.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptplace HRESULT ScriptPlace( [in] HDC hdc, [in, out]
		// SCRIPT_CACHE *psc, [in] const WORD *pwGlyphs, [in] int cGlyphs, [in] const SCRIPT_VISATTR *psva, [in, out] SCRIPT_ANALYSIS *psa,
		// [out] int *piAdvance, [out] GOFFSET *pGoffset, [out] ABC *pABC );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptPlace")]
		public static extern HRESULT ScriptPlace([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ushort[] pwGlyphs,
			int cGlyphs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] SCRIPT_VISATTR[] psva, [In, Optional] IntPtr psa,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] int[] piAdvance,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] GOFFSET[] pGoffset, out ABC pABC);

		/// <summary>Generates glyphs and visual attributes for a Unicode run with OpenType information from the output of ScriptShapeOpenType.</summary>
		/// <param name="hdc">Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="psa">
		/// <para>
		/// Pointer to a SCRIPT_ANALYSIS structure obtained from a previous call to ScriptItemizeOpenType. This structures identifies the
		/// shaping engine that governs the generated list of glyphs and their associated widths, and x and y placement offsets.
		/// </para>
		/// <para>Alternatively, the application can set this parameter to <c>NULL</c> to receive unfiltered results.</para>
		/// </param>
		/// <param name="tagScript">An OPENTYPE_TAG structure containing the OpenType script tag for the writing system to use.</param>
		/// <param name="tagLangSys">An OPENTYPE_TAG structure containing the OpenType language tag for the writing system.</param>
		/// <param name="rcRangeChars">
		/// Array of the number of characters in each range. The number of members is indicated in the <c>cRanges</c> parameter. The total of
		/// values should equal the value of <c>cChars</c>.
		/// </param>
		/// <param name="rpRangeProperties">
		/// Array of TEXTRANGE_PROPERTIES structures defining properties for each range. The number of elements is defined by the
		/// <c>cRanges</c> parameter.
		/// </param>
		/// <param name="cRanges">The number of OpenType feature ranges.</param>
		/// <param name="pwcChars">
		/// Pointer to an array of Unicode characters containing the run. The number of elements is defined by the <c>cRanges</c> parameter.
		/// </param>
		/// <param name="pwLogClust">
		/// Pointer to an array of logical cluster information. Each element in the array corresponds to a character in the array defined by
		/// <c>pwcChars</c>. The value of each element is the offset from the first glyph in the run to the first glyph in the cluster
		/// containing the corresponding character. Note that, when the <c>fRTL</c> member of the SCRIPT_ANALYSIS structure is set to
		/// <c>TRUE</c>, the elements in <c>pwLogClust</c> decrease as the array is read.
		/// </param>
		/// <param name="pCharProps">Pointer to an array of character property values in the Unicode run.</param>
		/// <param name="cChars">Number of characters in the Unicode run.</param>
		/// <param name="pwGlyphs">Pointer to a glyph buffer obtained from an earlier call to the ScriptShapeOpenType function.</param>
		/// <param name="pGlyphProps">
		/// Pointer to an array of attributes for each of the glyphs to retrieve. The number of values equals the value of <c>cGlyphs</c>.
		/// Since there is one glyph property per glyph, this parameter has the number of elements indicated by <c>cGlyphs</c>.
		/// </param>
		/// <param name="cGlyphs">Count of glyphs in a glyph array buffer.</param>
		/// <param name="piAdvance">
		/// Pointer to an array, of length indicated by <c>cGlyphs</c>, in which this function retrieves advance width information.
		/// </param>
		/// <param name="pGoffset">
		/// Pointer to an array of GOFFSET structures in which this structure retrieves the x and y offsets of combining glyphs. This array
		/// must be of length indicated by <c>cGlyphs</c>.
		/// </param>
		/// <param name="pABC">Pointer to an ABC structure in which this function retrieves the ABC width for the entire run.</param>
		/// <returns>
		/// <para>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. In all error cases, the output
		/// values are undefined. The application can test the return value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </para>
		/// <para>
		/// The function returns E_OUTOFMEMORY if the output buffer length indicated by <c>cGlyphs</c> is too small. The application can try
		/// calling again with larger buffers.
		/// </para>
		/// <para>
		/// The function returns E_PENDING if the script cache specified by the <c>psc</c> parameter does not contain enough information to
		/// place the glyphs, and the <c>hdc</c> parameter is passed as <c>NULL</c> so that the function is unable to complete the placement
		/// process. The application should set up a correct device context for the run, and call this function again with the appropriate
		/// value in <c>hdc</c> and with all other parameters the same.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is preferred over the older ScriptPlace function. Some advantages of <c>ScriptPlaceOpenType</c> include the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Parameters directly correspond to OpenType tags in font layout tables.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Parameters define features applied to each character. Input is divided into ranges, and each range has OpenType properties
		/// associated with it.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The composite ABC width for the whole item identifies how much the glyphs overhang to the left of the start position and to the
		/// right of the length implied by the sum of the advance widths. The total advance width of the line is exactly abcA+abcB+abcC. The
		/// abcA and abcC values are maintained as proportions of the cell height represented in 8 bits and are thus roughly +/-1 percent.
		/// The total width retrieved, which is the sum of the abcA+abcB+abcC values indicated by <c>piAdvance</c>, is accurate to the
		/// resolution of the TrueType shaping engine.
		/// </para>
		/// <para>
		/// All arrays are in visual order unless the <c>fLogicalOrder</c> member is set in the SCRIPT_ANALYSIS structure indicated by the
		/// <c>psa</c> parameter.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptplaceopentype HRESULT ScriptPlaceOpenType( [in, optional]
		// HDC hdc, [in, out] SCRIPT_CACHE *psc, [in, out] SCRIPT_ANALYSIS *psa, [in] OPENTYPE_TAG tagScript, [in] OPENTYPE_TAG tagLangSys,
		// [in, optional] int *rcRangeChars, [in, optional] TEXTRANGE_PROPERTIES **rpRangeProperties, [in] int cRanges, [in] const WCHAR
		// *pwcChars, [in] WORD *pwLogClust, [in] SCRIPT_CHARPROP *pCharProps, [in] int cChars, [in] const WORD *pwGlyphs, [in] const
		// SCRIPT_GLYPHPROP *pGlyphProps, [in] int cGlyphs, [out] int *piAdvance, [out] GOFFSET *pGoffset, [out, optional] ABC *pABC );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptPlaceOpenType")]
		public static extern HRESULT ScriptPlaceOpenType([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, [In, Optional] IntPtr psa, OPENTYPE_TAG tagScript,
			OPENTYPE_TAG tagLangSys, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] int[] rcRangeChars,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] IntPtr[] rpRangeProperties, int cRanges,
			[MarshalAs(UnmanagedType.LPWStr)] string pwcChars, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 11)] ushort[] pwLogClust,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 11)] SCRIPT_CHARPROP[] pCharProps, int cChars,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 14)] ushort[] pwGlyphs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 14)] SCRIPT_GLYPHPROP[] pGlyphProps, int cGlyphs,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 14)] int piAdvance,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 14)] GOFFSET[] pGoffset, out ABC pABC);

		/// <summary>Generates glyphs and visual attributes for a Unicode run with OpenType information from the output of ScriptShapeOpenType.</summary>
		/// <param name="hdc">Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="psa">
		/// <para>
		/// Pointer to a SCRIPT_ANALYSIS structure obtained from a previous call to ScriptItemizeOpenType. This structures identifies the
		/// shaping engine that governs the generated list of glyphs and their associated widths, and x and y placement offsets.
		/// </para>
		/// <para>Alternatively, the application can set this parameter to <c>NULL</c> to receive unfiltered results.</para>
		/// </param>
		/// <param name="tagScript">An OPENTYPE_TAG structure containing the OpenType script tag for the writing system to use.</param>
		/// <param name="tagLangSys">An OPENTYPE_TAG structure containing the OpenType language tag for the writing system.</param>
		/// <param name="rcRangeChars">
		/// Array of the number of characters in each range. The number of members is indicated in the <c>cRanges</c> parameter. The total of
		/// values should equal the value of <c>cChars</c>.
		/// </param>
		/// <param name="rpRangeProperties">
		/// Array of TEXTRANGE_PROPERTIES structures defining properties for each range. The number of elements is defined by the
		/// <c>cRanges</c> parameter.
		/// </param>
		/// <param name="cRanges">The number of OpenType feature ranges.</param>
		/// <param name="pwcChars">
		/// Pointer to an array of Unicode characters containing the run. The number of elements is defined by the <c>cRanges</c> parameter.
		/// </param>
		/// <param name="pwLogClust">
		/// Pointer to an array of logical cluster information. Each element in the array corresponds to a character in the array defined by
		/// <c>pwcChars</c>. The value of each element is the offset from the first glyph in the run to the first glyph in the cluster
		/// containing the corresponding character. Note that, when the <c>fRTL</c> member of the SCRIPT_ANALYSIS structure is set to
		/// <c>TRUE</c>, the elements in <c>pwLogClust</c> decrease as the array is read.
		/// </param>
		/// <param name="pCharProps">Pointer to an array of character property values in the Unicode run.</param>
		/// <param name="cChars">Number of characters in the Unicode run.</param>
		/// <param name="pwGlyphs">Pointer to a glyph buffer obtained from an earlier call to the ScriptShapeOpenType function.</param>
		/// <param name="pGlyphProps">
		/// Pointer to an array of attributes for each of the glyphs to retrieve. The number of values equals the value of <c>cGlyphs</c>.
		/// Since there is one glyph property per glyph, this parameter has the number of elements indicated by <c>cGlyphs</c>.
		/// </param>
		/// <param name="cGlyphs">Count of glyphs in a glyph array buffer.</param>
		/// <param name="piAdvance">
		/// Pointer to an array, of length indicated by <c>cGlyphs</c>, in which this function retrieves advance width information.
		/// </param>
		/// <param name="pGoffset">
		/// Pointer to an array of GOFFSET structures in which this structure retrieves the x and y offsets of combining glyphs. This array
		/// must be of length indicated by <c>cGlyphs</c>.
		/// </param>
		/// <param name="pABC">Pointer to an ABC structure in which this function retrieves the ABC width for the entire run.</param>
		/// <returns>
		/// <para>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. In all error cases, the output
		/// values are undefined. The application can test the return value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </para>
		/// <para>
		/// The function returns E_OUTOFMEMORY if the output buffer length indicated by <c>cGlyphs</c> is too small. The application can try
		/// calling again with larger buffers.
		/// </para>
		/// <para>
		/// The function returns E_PENDING if the script cache specified by the <c>psc</c> parameter does not contain enough information to
		/// place the glyphs, and the <c>hdc</c> parameter is passed as <c>NULL</c> so that the function is unable to complete the placement
		/// process. The application should set up a correct device context for the run, and call this function again with the appropriate
		/// value in <c>hdc</c> and with all other parameters the same.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is preferred over the older ScriptPlace function. Some advantages of <c>ScriptPlaceOpenType</c> include the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Parameters directly correspond to OpenType tags in font layout tables.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Parameters define features applied to each character. Input is divided into ranges, and each range has OpenType properties
		/// associated with it.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The composite ABC width for the whole item identifies how much the glyphs overhang to the left of the start position and to the
		/// right of the length implied by the sum of the advance widths. The total advance width of the line is exactly abcA+abcB+abcC. The
		/// abcA and abcC values are maintained as proportions of the cell height represented in 8 bits and are thus roughly +/-1 percent.
		/// The total width retrieved, which is the sum of the abcA+abcB+abcC values indicated by <c>piAdvance</c>, is accurate to the
		/// resolution of the TrueType shaping engine.
		/// </para>
		/// <para>
		/// All arrays are in visual order unless the <c>fLogicalOrder</c> member is set in the SCRIPT_ANALYSIS structure indicated by the
		/// <c>psa</c> parameter.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptplaceopentype HRESULT ScriptPlaceOpenType( [in, optional]
		// HDC hdc, [in, out] SCRIPT_CACHE *psc, [in, out] SCRIPT_ANALYSIS *psa, [in] OPENTYPE_TAG tagScript, [in] OPENTYPE_TAG tagLangSys,
		// [in, optional] int *rcRangeChars, [in, optional] TEXTRANGE_PROPERTIES **rpRangeProperties, [in] int cRanges, [in] const WCHAR
		// *pwcChars, [in] WORD *pwLogClust, [in] SCRIPT_CHARPROP *pCharProps, [in] int cChars, [in] const WORD *pwGlyphs, [in] const
		// SCRIPT_GLYPHPROP *pGlyphProps, [in] int cGlyphs, [out] int *piAdvance, [out] GOFFSET *pGoffset, [out, optional] ABC *pABC );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptPlaceOpenType")]
		public static extern HRESULT ScriptPlaceOpenType([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, ref SCRIPT_ANALYSIS psa, OPENTYPE_TAG tagScript,
			OPENTYPE_TAG tagLangSys, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] int[] rcRangeChars,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] IntPtr[] rpRangeProperties, int cRanges,
			[MarshalAs(UnmanagedType.LPWStr)] string pwcChars, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 11)] ushort[] pwLogClust,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 11)] SCRIPT_CHARPROP[] pCharProps, int cChars,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 14)] ushort[] pwGlyphs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 14)] SCRIPT_GLYPHPROP[] pGlyphProps, int cGlyphs,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 14)] int[] piAdvance,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 14)] GOFFSET[] pGoffset, out ABC pABC);

		/// <summary>
		/// Positions a single glyph with a single adjustment using a specified feature provided in the font for OpenType processing. Most
		/// often, applications use this function to align a glyph optically at the beginning or end of a line.
		/// </summary>
		/// <param name="hdc">Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="psa">
		/// <para>
		/// Pointer to a SCRIPT_ANALYSIS structure obtained from a previous call to ScriptItemizeOpenType. This structure identifies the
		/// shaping engine, so that the advance widths can be retrieved.
		/// </para>
		/// <para>Alternatively, the application can set this parameter to <c>NULL</c> to retrieve unfiltered results.</para>
		/// </param>
		/// <param name="tagScript">An OPENTYPE_TAG structure defining the script tag for shaping.</param>
		/// <param name="tagLangSys">An OPENTYPE_TAG structure defining the language tag for shaping.</param>
		/// <param name="tagFeature">An OPENTYPE_TAG structure defining the feature tag to use for shaping the alternate glyph.</param>
		/// <param name="lParameter">
		/// A flag specifying if single substitution should be applied to the identifier specified in <c>wGlyphId</c>. The application sets
		/// this parameter to 1 to apply the single substitution feature to the identifier. The application sets the parameter to 0 if the
		/// function should not apply the feature.
		/// </param>
		/// <param name="wGlyphId">The identifier of the original glyph being shaped.</param>
		/// <param name="iAdvance">The original glyph advance width.</param>
		/// <param name="GOffset">The original glyph offset. Typically, this value is an output of ScriptPlaceOpenType or ScriptPlace.</param>
		/// <param name="piOutAdvance">
		/// Pointer to the location in which this function retrieves the new advance width adjusted for the alternate glyph.
		/// </param>
		/// <param name="pOutGoffset">
		/// Pointer to the location in which this function retrieves the new glyph offset adjusted for the alternate glyph.
		/// </param>
		/// <returns>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function positions an individual glyph by adjusting the advance width and/or the offset of the given glyph. The function
		/// assumes that the font requires only one adjustment.
		/// </para>
		/// <para>
		/// A typical use of this function is the slight adjustment of the margin to account for the visual impression made by certain
		/// characters. In Latin script, for example, at the beginning of a line it is common to make a slight adjustment to the left for an
		/// initial capital (such as "T" or "O") that does not have a vertical line on the left part of the glyph. Although doing this breaks
		/// the strict linear margin, the eye perceives the margin as more even.
		/// </para>
		/// <para>
		/// The following examples demonstrate this effect. The first example shows strict alignment; the next two examples show an
		/// adjustment of the initial "T" to the left. The adjustments are by one pixel and two pixels, respectively. The magnified images to
		/// the right show how the "T" pushes slightly farther into the left margin in each successive case.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptpositionsingleglyph HRESULT ScriptPositionSingleGlyph(
		// [in, optional] HDC hdc, [in, out] SCRIPT_CACHE *psc, [in, optional] SCRIPT_ANALYSIS *psa, [in] OPENTYPE_TAG tagScript, [in]
		// OPENTYPE_TAG tagLangSys, [in] OPENTYPE_TAG tagFeature, [in] LONG lParameter, [in] WORD wGlyphId, [in] int iAdvance, [in] GOFFSET
		// GOffset, [out] int *piOutAdvance, [out] GOFFSET *pOutGoffset );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptPositionSingleGlyph")]
		public static extern HRESULT ScriptPositionSingleGlyph([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, in SCRIPT_ANALYSIS psa, OPENTYPE_TAG tagScript,
			OPENTYPE_TAG tagLangSys, OPENTYPE_TAG tagFeature, int lParameter, ushort wGlyphId, int iAdvance, GOFFSET GOffset, out int piOutAdvance, out GOFFSET pOutGoffset);

		/// <summary>
		/// Positions a single glyph with a single adjustment using a specified feature provided in the font for OpenType processing. Most
		/// often, applications use this function to align a glyph optically at the beginning or end of a line.
		/// </summary>
		/// <param name="hdc">Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="psa">
		/// <para>
		/// Pointer to a SCRIPT_ANALYSIS structure obtained from a previous call to ScriptItemizeOpenType. This structure identifies the
		/// shaping engine, so that the advance widths can be retrieved.
		/// </para>
		/// <para>Alternatively, the application can set this parameter to <c>NULL</c> to retrieve unfiltered results.</para>
		/// </param>
		/// <param name="tagScript">An OPENTYPE_TAG structure defining the script tag for shaping.</param>
		/// <param name="tagLangSys">An OPENTYPE_TAG structure defining the language tag for shaping.</param>
		/// <param name="tagFeature">An OPENTYPE_TAG structure defining the feature tag to use for shaping the alternate glyph.</param>
		/// <param name="lParameter">
		/// A flag specifying if single substitution should be applied to the identifier specified in <c>wGlyphId</c>. The application sets
		/// this parameter to 1 to apply the single substitution feature to the identifier. The application sets the parameter to 0 if the
		/// function should not apply the feature.
		/// </param>
		/// <param name="wGlyphId">The identifier of the original glyph being shaped.</param>
		/// <param name="iAdvance">The original glyph advance width.</param>
		/// <param name="GOffset">The original glyph offset. Typically, this value is an output of ScriptPlaceOpenType or ScriptPlace.</param>
		/// <param name="piOutAdvance">
		/// Pointer to the location in which this function retrieves the new advance width adjusted for the alternate glyph.
		/// </param>
		/// <param name="pOutGoffset">
		/// Pointer to the location in which this function retrieves the new glyph offset adjusted for the alternate glyph.
		/// </param>
		/// <returns>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function positions an individual glyph by adjusting the advance width and/or the offset of the given glyph. The function
		/// assumes that the font requires only one adjustment.
		/// </para>
		/// <para>
		/// A typical use of this function is the slight adjustment of the margin to account for the visual impression made by certain
		/// characters. In Latin script, for example, at the beginning of a line it is common to make a slight adjustment to the left for an
		/// initial capital (such as "T" or "O") that does not have a vertical line on the left part of the glyph. Although doing this breaks
		/// the strict linear margin, the eye perceives the margin as more even.
		/// </para>
		/// <para>
		/// The following examples demonstrate this effect. The first example shows strict alignment; the next two examples show an
		/// adjustment of the initial "T" to the left. The adjustments are by one pixel and two pixels, respectively. The magnified images to
		/// the right show how the "T" pushes slightly farther into the left margin in each successive case.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptpositionsingleglyph HRESULT ScriptPositionSingleGlyph(
		// [in, optional] HDC hdc, [in, out] SCRIPT_CACHE *psc, [in, optional] SCRIPT_ANALYSIS *psa, [in] OPENTYPE_TAG tagScript, [in]
		// OPENTYPE_TAG tagLangSys, [in] OPENTYPE_TAG tagFeature, [in] LONG lParameter, [in] WORD wGlyphId, [in] int iAdvance, [in] GOFFSET
		// GOffset, [out] int *piOutAdvance, [out] GOFFSET *pOutGoffset );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptPositionSingleGlyph")]
		public static extern HRESULT ScriptPositionSingleGlyph([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, [In, Optional] IntPtr psa, OPENTYPE_TAG tagScript,
			OPENTYPE_TAG tagLangSys, OPENTYPE_TAG tagFeature, int lParameter, ushort wGlyphId, int iAdvance, GOFFSET GOffset, out int piOutAdvance, out GOFFSET pOutGoffset);

		/// <summary>
		/// Reads the National Language Support (NLS) native digit and digit substitution settings and records them in a
		/// SCRIPT_DIGITSUBSTITUTE structure. For more information, see Digit Shapes.
		/// </summary>
		/// <param name="Locale">
		/// Locale identifier of the locale to query. Typically, the application should set this parameter to LOCALE_USER_DEFAULT.
		/// Alternatively, the setting can indicate a specific locale combined with LOCALE_NOUSEROVERRIDE to obtain the default settings.
		/// </param>
		/// <param name="psds">Pointer to a SCRIPT_DIGITSUBSTITUTE structure. This structure can be passed later to ScriptApplyDigitSubstitution.</param>
		/// <returns>
		/// <para>Returns S_OK if successful. The function returns a nonzero HRESULT value if it does not succeed.</para>
		/// <para>Error returns include:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>E_INVALIDARG. The <c>Locale</c> parameter indicates a locale that is invalid or not installed.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER. The <c>psds</c> parameter is set to <c>NULL</c>.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>See Displaying Text with Uniscribe for a discussion of the context in which this function is normally called.</para>
		/// <para>
		/// This function supports context digit substitution only for Arabic and Persian locales. For other locales, context digit
		/// substitution is mapped to no substitution.
		/// </para>
		/// <para>The following example shows the typical way to call this function.</para>
		/// <para>
		/// <code>SCRIPT_DIGITSUBSTITUTE sds; ScriptRecordDigitSubstitution(LOCALE_USER_DEFAULT, &amp;sds);</code>
		/// </para>
		/// <para>At every itemization, the application can use the results as shown in the next example.</para>
		/// <para>
		/// <code>SCRIPT_CONTROL sc = {0}; SCRIPT_STATE ss = {0}; ScriptApplyDigitSubstitution(&amp;sds, &amp;sc, &amp;ss);</code>
		/// </para>
		/// <para>
		/// For performance reasons, your application should not call <c>ScriptRecordDigitSubstitution</c> frequently. The function requires
		/// considerable overhead to call it every time ScriptItemize or ScriptStringAnalyse is called. Instead, the application can save the
		/// SCRIPT_DIGITSUBSTITUTE structure and update it only when a WM_SETTINGCHANGE message is received. Alternatively, the application
		/// can update the structure when a RegNotifyChangeKeyValue call in a dedicated thread indicates a change in the registry under
		/// HKCU\Control Panel\International.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptrecorddigitsubstitution HRESULT
		// ScriptRecordDigitSubstitution( [in] LCID Locale, [out] SCRIPT_DIGITSUBSTITUTE *psds );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptRecordDigitSubstitution")]
		public static extern HRESULT ScriptRecordDigitSubstitution(LCID Locale, out SCRIPT_DIGITSUBSTITUTE psds);

		/// <summary>Generates glyphs and visual attributes for a Unicode run.</summary>
		/// <param name="hdc">Optional. Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="pwcChars">Pointer to an array of Unicode characters defining the run.</param>
		/// <param name="cChars">Number of characters in the Unicode run.</param>
		/// <param name="cMaxGlyphs">
		/// Maximum number of glyphs to generate, and the length of <c>pwOutGlyphs</c>. A reasonable value is
		/// <code>(1.5 * cChars + 16)</code>
		/// , but this value might be insufficient in some circumstances. For more information, see the Remarks section.
		/// </param>
		/// <param name="psa">Pointer to the SCRIPT_ANALYSIS structure for the run, containing the results from an earlier call to ScriptItemize.</param>
		/// <param name="pwOutGlyphs">
		/// Pointer to a buffer in which this function retrieves an array of glyphs with size as indicated by <c>cMaxGlyphs</c>.
		/// </param>
		/// <param name="pwLogClust">
		/// Pointer to a buffer in which this function retrieves an array of logical cluster information. Each array element corresponds to a
		/// character in the array of Unicode characters; therefore this array has the number of elements indicated by cChars. The value of
		/// each element is the offset from the first glyph in the run to the first glyph in the cluster containing the corresponding
		/// character. Note that, when the <c>fRTL</c> member is set to <c>TRUE</c> in the SCRIPT_ANALYSIS structure, the elements decrease
		/// as the array is read.
		/// </param>
		/// <param name="psva">
		/// Pointer to a buffer in which this function retrieves an array of SCRIPT_VISATTR structures containing visual attribute
		/// information. Since each glyph has only one visual attribute, this array has the number of elements indicated by <c>cMaxGlyphs</c>.
		/// </param>
		/// <param name="pcGlyphs">Pointer to the location in which this function retrieves the number of glyphs indicated in <c>pwOutGlyphs</c>.</param>
		/// <returns>
		/// <para>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. In all error cases, the content of
		/// all output parameters is undefined.
		/// </para>
		/// <para>Error returns include:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>E_OUTOFMEMORY. The output buffer length indicated by <c>cMaxGlyphs</c> is insufficient.</term>
		/// </item>
		/// <item>
		/// <term>
		/// E_PENDING. The script cache specified by the <c>psc</c> parameter does not contain enough information to shape the string, and
		/// the device context has been passed as <c>NULL</c> so that the function is unable to complete the shaping process. The application
		/// should set up a correct device context for the run, and call this function again with the appropriate value in <c>hdc</c> and
		/// with all other parameters the same.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// USP_E_SCRIPT_NOT_IN_FONT. The font corresponding to the device context does not support the script required by the run indicated
		/// by <c>pwcChars</c>. The application should choose another font, using either ScriptGetCMap or another function to select the font.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>See Displaying Text with Uniscribe for a discussion of the context in which this function is normally called.</para>
		/// <para>
		/// If this function returns E_OUTOFMEMORY, the application might call <c>ScriptShape</c> repeatedly, with successively larger output
		/// buffers, until a large enough buffer is provided. The number of glyphs generated by a code point varies according to the script
		/// and the font. For a simple script, a Unicode code point might generate a single glyph. However, a complex script font might
		/// construct characters from components, and thus generate several times as many glyphs as characters. Also, there are special
		/// cases, such as invalid character representations, in which extra glyphs are added to represent the invalid sequence. Therefore, a
		/// reasonable guess for the size of the buffer indicated by <c>pwOutGlyphs</c> is 1.5 times the length of the character buffer, plus
		/// an additional 16 glyphs for rare cases, for example, invalid sequence representation.
		/// </para>
		/// <para>
		/// This function can set the <c>fNoGlyphIndex</c> member of the SCRIPT_ANALYSIS structure if the font or operating system cannot
		/// support glyph indexes.
		/// </para>
		/// <para>
		/// The application can call <c>ScriptShape</c> to determine if a font supports the characters in a given string. If the function
		/// returns S_OK, the application should check the output for missing glyphs. If <c>fLogicalOrder</c> is set to <c>TRUE</c> in the
		/// SCRIPT_ANALYSIS structure, the function always generates glyphs in the same order as the original Unicode characters. If
		/// <c>fLogicalOrder</c> is set to <c>FALSE</c>, the function generates right-to-left items in reverse order so that ScriptTextOut
		/// does not have to reverse them before calling ExtTextOut.
		/// </para>
		/// <para>
		/// If the <c>eScript</c> member of SCRIPT_ANALYSIS is set to SCRIPT_UNDEFINED, shaping is disabled. In this case, <c>ScriptShape</c>
		/// displays the glyph that is in the font cmap table. If no glyph is in the table, the function indicates that glyphs are missing.
		/// </para>
		/// <para>
		/// <c>ScriptShape</c> sequences clusters uniformly within the run, and sequences glyphs uniformly within a cluster. It uses the
		/// value of the <c>fRTL</c> member of SCRIPT_ANALYSIS, from ScriptItemize, to identify sequencing as left-to-right or right-to-left.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example shows how <c>ScriptShape</c> generates a logical cluster array ( <c>pwLogClust</c>) from a character array
		/// ( <c>pwcChars</c>) and a glyph array ( <c>pwOutGlyphs</c>). The run has four clusters.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>First cluster: one character represented by one glyph</term>
		/// </item>
		/// <item>
		/// <term>Second cluster: one character represented by three glyphs</term>
		/// </item>
		/// <item>
		/// <term>Third cluster: three characters represented by one glyph</term>
		/// </item>
		/// <item>
		/// <term>Fourth cluster: two characters represented by three glyphs</term>
		/// </item>
		/// </list>
		/// <para>Character array, where c&lt;n&gt;u&lt;m&gt; means cluster n, Unicode code point m:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>| c1u1 | c2u1 | c3u1 c3u2 c3u3 | c4u1 c4u2 |</term>
		/// </item>
		/// </list>
		/// <para>Glyph array, where c&lt;n&gt;g&lt;m&gt; means cluster n, glyph m:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>| c1g1 | c2g1 c2g2 c2g3 | c3g1 | c4g1 c4g2 c4g3 |</term>
		/// </item>
		/// </list>
		/// <para>Cluster array, that is, the offset (in glyphs) to the cluster containing the character:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>| 0 | 1 | 4 4 4 | 5 5 |</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptshape HRESULT ScriptShape( [in] HDC hdc, [in, out]
		// SCRIPT_CACHE *psc, [in] const WCHAR *pwcChars, [in] int cChars, [in] int cMaxGlyphs, [in, out] SCRIPT_ANALYSIS *psa, [out] WORD
		// *pwOutGlyphs, [out] WORD *pwLogClust, [out] SCRIPT_VISATTR *psva, [out] int *pcGlyphs );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptShape")]
		public static extern HRESULT ScriptShape([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, [MarshalAs(UnmanagedType.LPWStr)] string pwcChars,
			int cChars, int cMaxGlyphs, ref SCRIPT_ANALYSIS psa, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ushort[] pwOutGlyphs,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ushort[] pwLogClust,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] SCRIPT_VISATTR[] psva, out int pcGlyphs);

		/// <summary>
		/// Generates glyphs and visual attributes for a Unicode run with OpenType information. Each run consists of one call to this function.
		/// </summary>
		/// <param name="hdc">Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="psa">
		/// <para>
		/// Pointer to a SCRIPT_ANALYSIS structure obtained from a previous call to ScriptItemizeOpenType. The structure identifies the
		/// shaping engine, so that glyphs can be formed correctly.
		/// </para>
		/// <para>Alternatively, the application can set this parameter to <c>NULL</c> to receive unfiltered results.</para>
		/// </param>
		/// <param name="tagScript">An OPENTYPE_TAG structure defining the OpenType script tag for the writing system.</param>
		/// <param name="tagLangSys">An OPENTYPE_TAG structure containing the OpenType language tag for the writing system.</param>
		/// <param name="rcRangeChars">
		/// Array of characters in each range. The number of array elements is indicated by <c>cRanges</c>. The values of the elements of
		/// this array add up to the value of <c>cChars</c>.
		/// </param>
		/// <param name="rpRangeProperties">
		/// Array of TEXTRANGE_PROPERTIES structures, each representing one OpenType feature range. The number of structures is indicated by
		/// the <c>cRanges</c> parameter. For more information on <c>rpRangeProperties</c>, see the Remarks section.
		/// </param>
		/// <param name="cRanges">The number of OpenType feature ranges.</param>
		/// <param name="pwcChars">Pointer to an array of Unicode characters containing the run.</param>
		/// <param name="cChars">Number of characters in the Unicode run.</param>
		/// <param name="cMaxGlyphs">Maximum number of glyphs to generate.</param>
		/// <param name="pwLogClust">
		/// Pointer to a buffer in which this function retrieves an array of logical cluster information. Each array element corresponds to a
		/// character in the array of Unicode characters. The value of each element is the offset from the first glyph in the run to the
		/// first glyph in the cluster containing the corresponding character. Note that, when the <c>fRTL</c> member of the SCRIPT_ANALYSIS
		/// structure is <c>TRUE</c>, the elements decrease as the array is read.
		/// </param>
		/// <param name="pCharProps">
		/// Pointer to a buffer in which this function retrieves an array of character property values, of length indicated by <c>cChars</c>.
		/// </param>
		/// <param name="pwOutGlyphs">Pointer to a buffer in which this function retrieves an array of glyphs.</param>
		/// <param name="pOutGlyphProps">
		/// Pointer to a buffer in which this function retrieves an array of attributes for each of the retrieved glyphs. The length of the
		/// values equals the value of <c>pcGlyphs</c>. Since one glyph property is indicated per glyph, the value of this parameter
		/// indicates the number of elements specified by <c>cMaxGlyphs</c>.
		/// </param>
		/// <param name="pcGlyphs">Pointer to the location in which this function retrieves the number of glyphs indicated in <c>pwOutGlyphs</c>.</param>
		/// <returns>
		/// <para>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. In all error cases, the content of
		/// all output array values is undefined.
		/// </para>
		/// <para>Error returns include:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>E_OUTOFMEMORY. The output buffer length indicated by <c>cMaxGlyphs</c> is insufficient.</term>
		/// </item>
		/// <item>
		/// <term>
		/// E_PENDING. The script cache specified by the <c>psc</c> parameter does not contain enough information to shape the string, and
		/// the device context has been passed as <c>NULL</c> so that the function is unable to complete the shaping process. The application
		/// should set up a correct device context for the run and call this function again with the appropriate context value in <c>hdc</c>
		/// and with all other parameters the same.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// USP_E_SCRIPT_NOT_IN_FONT. The font corresponding to the device context does not support the required script. The application
		/// should choose another font, using either ScriptGetCMap or another method to select the font.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>ScriptShapeOpenType</c> is preferred over the older ScriptShape function. Some advantages of the <c>ScriptShapeOpenType</c>
		/// include the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Parameters directly correspond to OpenType tags in font layout tables.</term>
		/// </item>
		/// <item>
		/// <term>Parameters define features applied to each character.</term>
		/// </item>
		/// <item>
		/// <term>Input is divided into runs. Each run has OpenType properties and consists of a single call to <c>ScriptShapeOpenType</c>.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If this function returns E_OUTOFMEMORY, the application might call <c>ScriptShapeOpenType</c> repeatedly, with successively
		/// larger output buffers, until a large enough buffer is provided. The number of glyphs generated by a code point varies according
		/// to the script and the font. For a simple script, a Unicode code point might generate a single glyph. However, a complex script
		/// font might construct characters from components, and thus generate several times as many glyphs as characters. Also, there are
		/// special cases, such as invalid character representations, in which extra glyphs are added to represent the invalid sequence.
		/// Therefore, a reasonable guess for the size of the buffer indicated by <c>pwOutGlyphs</c> is 1.5 times the length of the character
		/// buffer, plus an additional 16 glyphs for rare cases, for example, invalid sequence representation.
		/// </para>
		/// <para>
		/// This function can set the <c>fNoGlyphIndex</c> member of the SCRIPT_ANALYSIS structure if the font or operating system cannot
		/// support glyph indexes.
		/// </para>
		/// <para>
		/// The application can call <c>ScriptShapeOpenType</c> to determine if a font supports the characters in a given string. If the
		/// function returns S_OK, the application should check the output for missing glyphs. If <c>fLogicalOrder</c> is set to <c>TRUE</c>
		/// in the SCRIPT_ANALYSIS structure, the function always generates glyphs in the same order as the original Unicode characters. If
		/// <c>fLogicalOrder</c> is set to <c>FALSE</c>, the function generates right-to-left items in reverse order so that ScriptTextOut
		/// does not have to reverse them before calling ExtTextOut.
		/// </para>
		/// <para>
		/// If the <c>eScript</c> member of SCRIPT_ANALYSIS is set to SCRIPT_UNDEFINED, shaping is disabled. In this case,
		/// <c>ScriptShapeOpenType</c> displays the glyph that is in the font cmap table. If no glyph is in the table, the function indicates
		/// that glyphs are missing.
		/// </para>
		/// <para>
		/// <c>ScriptShapeOpenType</c> sequences clusters uniformly within the run, and sequences glyphs uniformly within a cluster. It uses
		/// the value of the <c>fRTL</c> member of SCRIPT_ANALYSIS, from ScriptItemizeOpenType, to identify if sequencing is left-to-right or right-to-left.
		/// </para>
		/// <para>
		/// For the <c>rpRangeProperties</c> parameter, the TEXTRANGE_PROPERTIES structure points to an array of OPENTYPE_FEATURE_RECORD
		/// structures. This array is used as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Each element of the array indicated for <c>rpRangeProperties</c> describes a range.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Spans of text sharing particular properties tend to "nest," and nested spans can share OPENTYPE_FEATURE_RECORD information. For
		/// example, in the illustration below:
		/// </term>
		/// </item>
		/// </list>
		/// <para><c>Note</c> The illustration makes use of many calls to <c>ScriptShapeOpenType</c>, each representing one run.</para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example shows how <c>ScriptShapeOpenType</c> generates a logical cluster array ( <c>pwLogClust</c>) from a
		/// character array ( <c>pwcChars</c>) and a glyph array ( <c>pwOutGlyphs</c>). The run has four clusters.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>First cluster: one character represented by one glyph</term>
		/// </item>
		/// <item>
		/// <term>Second cluster: one character represented by three glyphs</term>
		/// </item>
		/// <item>
		/// <term>Third cluster: three characters represented by one glyph</term>
		/// </item>
		/// <item>
		/// <term>Fourth cluster: two characters represented by three glyphs</term>
		/// </item>
		/// </list>
		/// <para>The run is described as follows in the character and glyph arrays.</para>
		/// <para>Character array:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>| c1u1 | c2u1 | c3u1 c3u2 c3u3 | c4u1 c4u2 |</term>
		/// </item>
		/// </list>
		/// <para>Glyph array:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>| c1g1 | c2g1 c2g2 c2g3 | c3g1 | c4g1 c4g2 c4g3 |</term>
		/// </item>
		/// </list>
		/// <para>Notation for the array elements consists of these items:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>c&lt;n&gt; means cluster n.</term>
		/// </item>
		/// <item>
		/// <term>g&lt;m&gt; means glyph m.</term>
		/// </item>
		/// <item>
		/// <term>u&lt;p&gt; means Unicode code point p.</term>
		/// </item>
		/// </list>
		/// <para>The generated cluster array stores offsets to the cluster containing the character. Units are expressed in glyphs.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>| 0 | 1 | 4 4 4 | 5 5 |</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptshapeopentype HRESULT ScriptShapeOpenType( [in, optional]
		// HDC hdc, [in, out] SCRIPT_CACHE *psc, [in, out] SCRIPT_ANALYSIS *psa, [in] OPENTYPE_TAG tagScript, [in] OPENTYPE_TAG tagLangSys,
		// [in, optional] int *rcRangeChars, [in, optional] TEXTRANGE_PROPERTIES **rpRangeProperties, [in] int cRanges, [in] const WCHAR
		// *pwcChars, [in] int cChars, [in] int cMaxGlyphs, [out] WORD *pwLogClust, [out] SCRIPT_CHARPROP *pCharProps, [out] WORD
		// *pwOutGlyphs, [out] SCRIPT_GLYPHPROP *pOutGlyphProps, [out] int *pcGlyphs );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptShapeOpenType")]
		public static extern HRESULT ScriptShapeOpenType([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, ref SCRIPT_ANALYSIS psa, OPENTYPE_TAG tagScript,
			OPENTYPE_TAG tagLangSys, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] int[] rcRangeChars,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] IntPtr[] rpRangeProperties, int cRanges,
			[MarshalAs(UnmanagedType.LPWStr)] string pwcChars, int cChars, int cMaxGlyphs,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 9)] ushort[] pwLogClust,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 9)] SCRIPT_CHARPROP[] pCharProps,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 10)] ushort[] pwOutGlyphs,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 10)] SCRIPT_GLYPHPROP[] pOutGlyphProps, out int pcGlyphs);

		/// <summary>Returns a pointer to the length of a string after clipping.</summary>
		/// <param name="ssa">A SCRIPT_STRING_ANALYSIS structure for the string.</param>
		/// <returns>
		/// Returns a pointer to the length of the string after clipping if successful. The length is the number of Unicode code points. The
		/// function returns <c>NULL</c> if it does not succeed.
		/// </returns>
		/// <remarks>
		/// <para>To use this function, the application needs to specify SSA_CLIP in its original call to ScriptStringAnalyse.</para>
		/// <para>
		/// The pointer returned by this function is valid only until the application passes the associated SCRIPT_STRING_ANALYSIS structure
		/// to ScriptStringFree.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptstring_pcoutchars const int * ScriptString_pcOutChars(
		// [in] SCRIPT_STRING_ANALYSIS ssa );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptString_pcOutChars")]
		public static extern unsafe int* ScriptString_pcOutChars([In] SafeSCRIPT_STRING_ANALYSIS ssa);

		/// <summary>Returns a pointer to a logical attributes buffer for an analyzed string.</summary>
		/// <param name="ssa">A SCRIPT_STRING_ANALYSIS structure for the string.</param>
		/// <returns>
		/// Returns a pointer to a buffer containing SCRIPT_LOGATTR structures defining logical attributes if successful. The function
		/// returns <c>NULL</c> if it does not succeed.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The pointer returned by this function is valid only until the application passes the associated SCRIPT_STRING_ANALYSIS structure
		/// to ScriptStringFree.
		/// </para>
		/// <para>The logical attribute buffer contains at least the number of integers indicated by the <c>ssa</c> parameter of ScriptString_pcOutChars.</para>
		/// <para>
		/// When scanning the SCRIPT_LOGATTR array for a word break point, the application should look backward for the values of the
		/// <c>fWordStop</c> and <c>fWhiteSpace</c> members. ScriptStringAnalyse just calls ScriptBreak on each run, and <c>ScriptBreak</c>
		/// never sets <c>fWordBreak</c> on the first character of a run, because it has no information that the previous run ended in white space.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptstring_plogattr const SCRIPT_LOGATTR *
		// ScriptString_pLogAttr( [in] SCRIPT_STRING_ANALYSIS ssa );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptString_pLogAttr")]
		public static extern unsafe SCRIPT_LOGATTR* ScriptString_pLogAttr([In] SafeSCRIPT_STRING_ANALYSIS ssa);

		/// <summary>Returns a pointer to a SIZE structure for an analyzed string.</summary>
		/// <param name="ssa">A SCRIPT_STRING_ANALYSIS structure for a string.</param>
		/// <returns>
		/// Returns a pointer to a SIZE structure containing the size (width and height) of the analyzed string if successful. The function
		/// returns <c>NULL</c> if it does not succeed.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The size returned by this function is the size before the effect of the justification requested by setting the SSA_FIT flag in
		/// ScriptStringAnalyse. The difference between the value of <c>iReqWidth</c> in <c>ScriptStringAnalyse</c> and the size returned by
		/// <c>ScriptString_pSize</c> is the effect of justification.
		/// </para>
		/// <para>
		/// The pointer returned by this function is valid only until the application passes the associated SCRIPT_STRING_ANALYSIS structure
		/// to ScriptStringFree.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptstring_psize const SIZE * ScriptString_pSize( [in]
		// SCRIPT_STRING_ANALYSIS ssa );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptString_pSize")]
		public static extern unsafe SIZE* ScriptString_pSize([In] SafeSCRIPT_STRING_ANALYSIS ssa);

		/// <summary>Analyzes a plain text string.</summary>
		/// <param name="hdc">
		/// Handle to the device context. If <c>dwFlags</c> is set to SSA_GLYPHS, the device context handle is required. If <c>dwFlags</c> is
		/// set to SSA_BREAK, the device context handle is optional. If the device context handle is provided, the function inspects the
		/// current font in the device context. If the current font is a symbolic font, the function treats the character string as a single
		/// neutral SCRIPT_UNDEFINED item.
		/// </param>
		/// <param name="pString">
		/// Pointer to the string to analyze. The string must have at least one character. It can be a Unicode string or use the character
		/// set from a Windows ANSI code page, as specified by the <c>iCharset</c> parameter.
		/// </param>
		/// <param name="cString">
		/// Length of the string to analyze. The length is measured in characters for an ANSI string or in wide characters for a Unicode
		/// string. The length must be at least 1.
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags indicating the analysis that is required. This parameter can have one of the values listed in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SSA_BREAK</c></term>
		/// <term>Retrieve break flags, that is, character and word stops.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_CLIP</c></term>
		/// <term>Clip the string at <c>iReqWidth.</c></term>
		/// </item>
		/// <item>
		/// <term><c>SSA_DZWG</c></term>
		/// <term>Provide representation glyphs for control characters.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_FALLBACK</c></term>
		/// <term>Use fallback fonts.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_FIT</c></term>
		/// <term>Justify the string to <c>iReqWidth</c>.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_GCP</c></term>
		/// <term>Retrieve missing glyphs and <c>pwLogClust</c> with GetCharacterPlacement conventions.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_GLYPHS</c></term>
		/// <term>Generate glyphs, positions, and attributes.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_HIDEHOTKEY</c></term>
		/// <term>Remove the first "&amp;" from displayed string.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_HOTKEY</c></term>
		/// <term>Replace "&amp;" with underline on subsequent code point.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_HOTKEYONLY</c></term>
		/// <term>
		/// Display underline only. The resulting bit pattern might be displayed, using an XOR mask, to toggle the visibility of the hotkey
		/// underline without disturbing the text.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SSA_LINK</c></term>
		/// <term>Apply East Asian font linking and association to noncomplex text.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_METAFILE</c></term>
		/// <term>Write items with ExtTextOutW calls, not with glyphs.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_PASSWORD</c></term>
		/// <term>Duplicate input string containing a single character <c>cString</c> times.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_RTL</c></term>
		/// <term>Use base embedding level 1.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_TAB</c></term>
		/// <term>Expand tabs.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="iReqWidth">Width required for fitting or clipping.</param>
		/// <param name="psControl">
		/// Pointer to a SCRIPT_CONTROL structure. The application can set this parameter to <c>NULL</c> to indicate that all
		/// <c>SCRIPT_CONTROL</c> members are set to 0.
		/// </param>
		/// <param name="psState">
		/// Pointer to a SCRIPT_STATE structure. The application can set this parameter to <c>NULL</c> to indicate that all
		/// <c>SCRIPT_STATE</c> members are set to 0. The <c>uBidiLevel</c> member of <c>SCRIPT_STATE</c> is ignored. The value used is
		/// derived from the SSA_RTL flag in combination with the layout of the device context.
		/// </param>
		/// <param name="piDx">Pointer to the requested logical dx array.</param>
		/// <param name="pTabdef">Pointer to a SCRIPT_TABDEF structure. This value is only required if <c>dwFlags</c> is set to SSA_TAB.</param>
		/// <param name="pbInClass">Pointer to a BYTE value that indicates GetCharacterPlacement character classifications.</param>
		/// <returns>A SCRIPT_STRING_ANALYSIS structure. This structure is dynamically allocated on successful return from the function.</returns>
		/// <remarks>
		/// <para>
		/// Use of this function is the first step in handling plain text strings. Such a string has only one font, one style, one size, one
		/// color, and so forth. <c>ScriptStringAnalyse</c> allocates temporary buffers for item analyses, glyphs, advance widths, and the
		/// like. Then it automatically runs ScriptItemize, ScriptShape, ScriptPlace, and ScriptBreak. The results are available through all
		/// the other <c>ScriptString*</c> functions.
		/// </para>
		/// <para>
		/// On successful return from this function a dynamically allocated structure that the application can pass successively to the other
		/// <c>ScriptString*</c> functions. The application must ultimately free the structure by calling ScriptStringFree.
		/// </para>
		/// <para>
		/// Although the functionality of <c>ScriptStringAnalyse</c> can be implemented by direct calls to other functions, use of the
		/// function itself drastically reduces the amount of code required in the application for plain text handling.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptstringanalyse HRESULT ScriptStringAnalyse( [in] HDC hdc,
		// [in] const void *pString, [in] int cString, [in] int cGlyphs, [in] int iCharset, [in] DWORD dwFlags, [in] int iReqWidth, [in,
		// optional] SCRIPT_CONTROL *psControl, [in, optional] SCRIPT_STATE *psState, [in, optional] const int *piDx, [in, optional]
		// SCRIPT_TABDEF *pTabdef, [in] const BYTE *pbInClass, [out] SCRIPT_STRING_ANALYSIS *pssa );
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptStringAnalyse")]
		public static SafeSCRIPT_STRING_ANALYSIS ScriptStringAnalyse([In, Optional] HDC hdc, string pString, SSA dwFlags,
			int cString = -1, int iReqWidth = 0, SCRIPT_CONTROL? psControl = null, SCRIPT_STATE? psState = null,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] piDx = null, SCRIPT_TABDEF? pTabdef = null,
			IntPtr pbInClass = default)
		{
			unsafe
			{
				if (cString == -1) cString = pString.Length;
				var cGlyphs = MulAdd(cString, 1.5m, 16);
				using var psc = InteropServices.PinnedObject.FromNullable(psControl);
				using var pss = InteropServices.PinnedObject.FromNullable(psState);
				using var ptd = InteropServices.PinnedObject.FromNullable(pTabdef);
				fixed (char* ps = pString)
				{
					ScriptStringAnalyse(hdc, ps, cString, cGlyphs, -1, dwFlags, iReqWidth, (SCRIPT_CONTROL*)(void*)psc,
						(SCRIPT_STATE*)(void*)pss, piDx, (SCRIPT_TABDEF*)(void*)ptd, (byte*)pbInClass, out var pssa).ThrowIfFailed();
					return pssa;
				}
			}
		}

		/// <summary>Analyzes a plain text string.</summary>
		/// <param name="hdc">
		/// Handle to the device context. If <c>dwFlags</c> is set to SSA_GLYPHS, the device context handle is required. If <c>dwFlags</c> is
		/// set to SSA_BREAK, the device context handle is optional. If the device context handle is provided, the function inspects the
		/// current font in the device context. If the current font is a symbolic font, the function treats the character string as a single
		/// neutral SCRIPT_UNDEFINED item.
		/// </param>
		/// <param name="pString">
		/// Pointer to the string to analyze. The string must have at least one character. It can be a Unicode string or use the character
		/// set from a Windows ANSI code page, as specified by the <c>iCharset</c> parameter.
		/// </param>
		/// <param name="cString">
		/// Length of the string to analyze. The length is measured in characters for an ANSI string or in wide characters for a Unicode
		/// string. The length must be at least 1.
		/// </param>
		/// <param name="cGlyphs">
		/// Size of the glyph buffer, in WORD values. This size is required. The recommended size is <c>(1.5 * cString + 16)</c>.
		/// </param>
		/// <param name="iCharset">
		/// <para>
		/// Character set descriptor. If the input string is an ANSI string, this descriptor is set to the character set identifier. If the
		/// string is a Unicode string, this descriptor is set to -1.
		/// </para>
		/// <para>The following character set identifiers are defined:</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags indicating the analysis that is required. This parameter can have one of the values listed in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SSA_BREAK</c></term>
		/// <term>Retrieve break flags, that is, character and word stops.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_CLIP</c></term>
		/// <term>Clip the string at <c>iReqWidth.</c></term>
		/// </item>
		/// <item>
		/// <term><c>SSA_DZWG</c></term>
		/// <term>Provide representation glyphs for control characters.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_FALLBACK</c></term>
		/// <term>Use fallback fonts.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_FIT</c></term>
		/// <term>Justify the string to <c>iReqWidth</c>.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_GCP</c></term>
		/// <term>Retrieve missing glyphs and <c>pwLogClust</c> with GetCharacterPlacement conventions.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_GLYPHS</c></term>
		/// <term>Generate glyphs, positions, and attributes.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_HIDEHOTKEY</c></term>
		/// <term>Remove the first "&amp;" from displayed string.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_HOTKEY</c></term>
		/// <term>Replace "&amp;" with underline on subsequent code point.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_HOTKEYONLY</c></term>
		/// <term>
		/// Display underline only. The resulting bit pattern might be displayed, using an XOR mask, to toggle the visibility of the hotkey
		/// underline without disturbing the text.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SSA_LINK</c></term>
		/// <term>Apply East Asian font linking and association to noncomplex text.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_METAFILE</c></term>
		/// <term>Write items with ExtTextOutW calls, not with glyphs.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_PASSWORD</c></term>
		/// <term>Duplicate input string containing a single character <c>cString</c> times.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_RTL</c></term>
		/// <term>Use base embedding level 1.</term>
		/// </item>
		/// <item>
		/// <term><c>SSA_TAB</c></term>
		/// <term>Expand tabs.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="iReqWidth">Width required for fitting or clipping.</param>
		/// <param name="psControl">
		/// Pointer to a SCRIPT_CONTROL structure. The application can set this parameter to <c>NULL</c> to indicate that all
		/// <c>SCRIPT_CONTROL</c> members are set to 0.
		/// </param>
		/// <param name="psState">
		/// Pointer to a SCRIPT_STATE structure. The application can set this parameter to <c>NULL</c> to indicate that all
		/// <c>SCRIPT_STATE</c> members are set to 0. The <c>uBidiLevel</c> member of <c>SCRIPT_STATE</c> is ignored. The value used is
		/// derived from the SSA_RTL flag in combination with the layout of the device context.
		/// </param>
		/// <param name="piDx">Pointer to the requested logical dx array.</param>
		/// <param name="pTabdef">Pointer to a SCRIPT_TABDEF structure. This value is only required if <c>dwFlags</c> is set to SSA_TAB.</param>
		/// <param name="pbInClass">Pointer to a BYTE value that indicates GetCharacterPlacement character classifications.</param>
		/// <param name="pssa">
		/// Pointer to a buffer in which this function retrieves a SCRIPT_STRING_ANALYSIS structure. This structure is dynamically allocated
		/// on successful return from the function.
		/// </param>
		/// <returns>
		/// <para>Returns S_OK if successful. The function returns a nonzero HRESULT value if it does not succeed.</para>
		/// <para>Error returns include:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>E_INVALIDARG. An invalid parameter is found.</term>
		/// </item>
		/// <item>
		/// <term>USP_E_SCRIPT_NOT_IN_FONT. SSA_FALLBACK has not been specified, or a standard fallback font is missing.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The function can also return a system error converted to an HRESULT type. An example is an error returned due to lack of memory
		/// or a GDI call using the device context.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Use of this function is the first step in handling plain text strings. Such a string has only one font, one style, one size, one
		/// color, and so forth. <c>ScriptStringAnalyse</c> allocates temporary buffers for item analyses, glyphs, advance widths, and the
		/// like. Then it automatically runs ScriptItemize, ScriptShape, ScriptPlace, and ScriptBreak. The results are available through all
		/// the other <c>ScriptString*</c> functions.
		/// </para>
		/// <para>
		/// On successful return from this function, <c>pssa</c> indicates a dynamically allocated structure that the application can pass
		/// successively to the other <c>ScriptString*</c> functions. The application must ultimately free the structure by calling ScriptStringFree.
		/// </para>
		/// <para>
		/// Although the functionality of <c>ScriptStringAnalyse</c> can be implemented by direct calls to other functions, use of the
		/// function itself drastically reduces the amount of code required in the application for plain text handling.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptstringanalyse HRESULT ScriptStringAnalyse( [in] HDC hdc,
		// [in] const void *pString, [in] int cString, [in] int cGlyphs, [in] int iCharset, [in] DWORD dwFlags, [in] int iReqWidth, [in,
		// optional] SCRIPT_CONTROL *psControl, [in, optional] SCRIPT_STATE *psState, [in, optional] const int *piDx, [in, optional]
		// SCRIPT_TABDEF *pTabdef, [in] const BYTE *pbInClass, [out] SCRIPT_STRING_ANALYSIS *pssa );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptStringAnalyse")]
		public static extern unsafe HRESULT ScriptStringAnalyse([In] HDC hdc, [In] void* pString, int cString, int cGlyphs, int iCharset,
			SSA dwFlags, int iReqWidth, [In, Optional] SCRIPT_CONTROL* psControl, [In, Optional] SCRIPT_STATE* psState,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] piDx, [In, Optional] SCRIPT_TABDEF* pTabdef,
			[In, Optional] byte* pbInClass, out SafeSCRIPT_STRING_ANALYSIS pssa);

		/// <summary>Retrieves the x coordinate for the leading or trailing edge of a character position.</summary>
		/// <param name="ssa">A SCRIPT_STRING_ANALYSIS structure for the string.</param>
		/// <param name="icp">Character position in the string.</param>
		/// <param name="fTrailing">
		/// <c>TRUE</c> to indicate the trailing edge of the character position ( <c>icp</c>) that corresponds to the x coordinate. This
		/// parameter is set to <c>FALSE</c> to indicate the leading edge of the character position.
		/// </param>
		/// <param name="pX">Pointer to a buffer in which this function retrieves the x coordinate corresponding to the character position.</param>
		/// <returns>
		/// Returns S_OK if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the
		/// return value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptstringcptox HRESULT ScriptStringCPtoX( [in]
		// SCRIPT_STRING_ANALYSIS ssa, [in] int icp, [in] BOOL fTrailing, [out] int *pX );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptStringCPtoX")]
		public static extern HRESULT ScriptStringCPtoX([In] SafeSCRIPT_STRING_ANALYSIS ssa, int icp, [MarshalAs(UnmanagedType.Bool)] bool fTrailing, out int pX);

		/// <summary>Frees a SCRIPT_STRING_ANALYSIS structure.</summary>
		/// <param name="pssa">Pointer to a SCRIPT_STRING_ANALYSIS structure.</param>
		/// <returns>
		/// Returns S_OK if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the
		/// return value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>
		/// When your application is finished with a SCRIPT_STRING_ANALYSIS structure, it should free the associated memory by calling this
		/// function. After this function is called, the pointers retrieved from ScriptString_pcOutChars, ScriptString_pLogAttr, and
		/// ScriptString_pSize that are associated with the <c>pssa</c> parameter are invalid.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptstringfree HRESULT ScriptStringFree( [in, out]
		// SCRIPT_STRING_ANALYSIS *pssa );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptStringFree")]
		public static extern HRESULT ScriptStringFree(ref IntPtr pssa);

		/// <summary>Converts visual widths into logical widths.</summary>
		/// <param name="ssa">A SCRIPT_STRING_ANALYSIS structure for the string.</param>
		/// <param name="piDx">
		/// Pointer to a buffer in which this function retrieves logical widths. The buffer should have room for at least the number of
		/// integers indicated by the <c>ssa</c> parameter of ScriptString_pcOutChars.
		/// </param>
		/// <returns>
		/// Returns S_OK if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the
		/// return value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function converts the visual widths generated by ScriptStringAnalyse into logical widths, one per original character, in
		/// logical order.
		/// </para>
		/// <para>To use this function, the application needs to specify SSA_GLYPHS in its original call to ScriptStringAnalyse.</para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptstringgetlogicalwidths HRESULT
		// ScriptStringGetLogicalWidths( [in] SCRIPT_STRING_ANALYSIS ssa, [out] int *piDx );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptStringGetLogicalWidths")]
		public static extern HRESULT ScriptStringGetLogicalWidths([In] SafeSCRIPT_STRING_ANALYSIS ssa, [Out, MarshalAs(UnmanagedType.LPArray)] int[] piDx);

		/// <summary>Creates an array that maps an original character position to a glyph position.</summary>
		/// <param name="ssa">A SCRIPT_STRING_ANALYSIS structure for the string.</param>
		/// <param name="puOrder">
		/// Pointer to a buffer in which this function retrieves an array of glyph positions, indexed by the original character position. The
		/// array should have room for at least the number of integers indicated by the <c>ssa</c> parameter of ScriptString_pcOutChars.
		/// </param>
		/// <returns>
		/// Returns S_OK if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the
		/// return value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>
		/// When the number of glyphs and the number of characters are equal, the function retrieves an array that references every glyph.
		/// This is the same treatment that occurs in GetCharacterPlacement.
		/// </para>
		/// <para>To use this function, the application needs to specify SSA_GLYPHS in its original call to ScriptStringAnalyse.</para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptstringgetorder HRESULT ScriptStringGetOrder( [in]
		// SCRIPT_STRING_ANALYSIS ssa, [out] UINT *puOrder );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptStringGetOrder")]
		public static extern HRESULT ScriptStringGetOrder([In] SafeSCRIPT_STRING_ANALYSIS ssa, [Out, MarshalAs(UnmanagedType.LPArray)] uint[] puOrder);

		/// <summary>Displays a string generated by a prior call to ScriptStringAnalyse and optionally adds highlighting.</summary>
		/// <param name="ssa">A SCRIPT_STRING_ANALYSIS structure for the string.</param>
		/// <param name="iX">The x-coordinate of the reference point used to position the string.</param>
		/// <param name="iY">The y-coordinate of the reference point used to position the string.</param>
		/// <param name="uOptions">
		/// <para>
		/// Options specifying the use of the application-defined rectangle. This parameter can be set to 0 or to any of the following
		/// values. The values can be combined with binary OR.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>ETO_CLIPPED</c></term>
		/// <term>Clip text to the rectangle.</term>
		/// </item>
		/// <item>
		/// <term><c>ETO_OPAQUE</c></term>
		/// <term>Use current background color to fill the rectangle.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="prc">
		/// Pointer to a RECT structure that defines the rectangle to use. If <c>uOptions</c> is set to ETO_OPAQUE and <c>NULL</c> is
		/// provided for <c>prc</c>, the function succeeds and returns S_OK. However, if the application sets <c>uOptions</c> to ETO_CLIPPING
		/// and provides <c>NULL</c> for <c>prc</c>, the function returns E_INVALIDARG. The application can set this parameter to <c>NULL</c>
		/// to indicate that no option is needed.
		/// </param>
		/// <param name="iMinSel">
		/// Zero-based index specifying the starting position in the string. For no selection, the application should set <c>iMinSel</c>
		/// &gt;= <c>iMaxSel</c>.
		/// </param>
		/// <param name="iMaxSel">Zero-based index specifying the ending position in the string.</param>
		/// <param name="fDisabled">
		/// <c>TRUE</c> if the operating system applies disabled-text highlighting by setting the background color to COLOR_HIGHLIGHT behind
		/// all selected characters. The application can set this parameter to <c>FALSE</c> if the operating system applies enabled-text
		/// highlighting by setting the background color to COLOR_HIGHLIGHT and the text color to COLOR_HIGHLIGHTTEXT for each selected character.
		/// </param>
		/// <returns>
		/// Returns S_OK if successful. The function returns a nonzero <c>HRESULT</c> value if it does not succeed. The application can't
		/// test the return value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>To use this function, the application needs to specify SSA_GLYPHS in its original call to ScriptStringAnalyse.</para>
		/// <para>
		/// The application should not use SetTextAlign with TA_UPDATECP when using <c>ScriptStringOut</c> because selected text cannot be
		/// rendered correctly. If the application must use this flag, it can unset and reset the flag as necessary to avoid the problem.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptstringout HRESULT ScriptStringOut( [in]
		// SCRIPT_STRING_ANALYSIS ssa, [in] int iX, [in] int iY, [in] UINT uOptions, [in, optional] const RECT *prc, [in] int iMinSel, [in]
		// int iMaxSel, [in] BOOL fDisabled );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptStringOut")]
		public static extern HRESULT ScriptStringOut([In] SafeSCRIPT_STRING_ANALYSIS ssa, int iX, int iY, ETO uOptions,
			[In, Optional] PRECT prc, int iMinSel, int iMaxSel, [MarshalAs(UnmanagedType.Bool)] bool fDisabled);

		/// <summary>Checks a SCRIPT_STRING_ANALYSIS structure for invalid sequences.</summary>
		/// <param name="ssa">A SCRIPT_STRING_ANALYSIS structure for a string.</param>
		/// <returns>
		/// Returns S_OK if no invalid sequences are found. The function returns S_FALSE if one or more invalid sequences are found. The
		/// function returns a nonzero HRESULT value if it does not succeed.
		/// </returns>
		/// <remarks>
		/// <para>This function is intended for use in editors that reject the input of invalid sequences.</para>
		/// <para>
		/// Invalid sequences are only checked for scripts with the <c>fRejectInvalid</c> member set in the associated SCRIPT_PROPERTIES
		/// structure. For example, it is conventional for Notepad to reject invalid Thai character sequences. However, invalid Indian
		/// sequences are not conventionally rejected, but instead are displayed in composition with a missing base character symbol.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptstringvalidate HRESULT ScriptStringValidate( [in]
		// SCRIPT_STRING_ANALYSIS ssa );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptStringValidate")]
		public static extern HRESULT ScriptStringValidate([In] SafeSCRIPT_STRING_ANALYSIS ssa);

		/// <summary>Converts an x coordinate to a character position.</summary>
		/// <param name="ssa">A SCRIPT_STRING_ANALYSIS structure for the string.</param>
		/// <param name="iX">The x coordinate.</param>
		/// <param name="piCh">Pointer to a variable in which this function retrieves the character position corresponding to the x coordinate.</param>
		/// <param name="piTrailing">
		/// Pointer to a variable in which this function retrieves a value indicating if the x coordinate is for the leading edge or the
		/// trailing edge of the character position. For more information, see the Remarks section.
		/// </param>
		/// <returns>
		/// Returns S_OK if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the
		/// return value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the x coordinate corresponds to the leading edge of the character, the value of <c>piTrailing</c> is 0. If the x coordinate
		/// corresponds to the trailing edge of the character, the value of <c>piTrailing</c> is a positive integer. As for ScriptXtoCP, the
		/// value is 1 for a character that can be rendered on its own. The value is greater than 1 if the character is part of a cluster in
		/// a script for which cursors are not placed within a cluster, to indicate the offset to the next legitimate logical cursor position.
		/// </para>
		/// <para>
		/// If the x coordinate is before the beginning of the line, the function retrieves -1 for <c>piCh</c> and 1 for <c>piTrailing</c>,
		/// indicating the trailing edge of the nonexistent character before the line. If the x coordinate is after the end of the line, the
		/// function retrieves for <c>piCh</c> the first index beyond the length of the line and 0 for <c>piTrailing</c>. The 0 value
		/// indicates the leading edge of the nonexistent character after the line.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptstringxtocp HRESULT ScriptStringXtoCP( [in]
		// SCRIPT_STRING_ANALYSIS ssa, [in] int iX, [out] int *piCh, [out] int *piTrailing );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptStringXtoCP")]
		public static extern HRESULT ScriptStringXtoCP([In] SafeSCRIPT_STRING_ANALYSIS ssa, int iX, out int piCh, out int piTrailing);

		/// <summary>Enables substitution of a single glyph with one alternate form of the same glyph for OpenType processing.</summary>
		/// <param name="hdc">Handle to the device context. For more information, see Caching.</param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure indicating the script cache.</param>
		/// <param name="psa">
		/// <para>
		/// Pointer to a SCRIPT_ANALYSIS structure obtained from a previous call to ScriptItemizeOpenType. This parameter identifies the
		/// shaping engine so that the correct substitute glyph is used.
		/// </para>
		/// <para>Alternatively, the application can set this parameter to <c>NULL</c> to retrieve unfiltered results.</para>
		/// </param>
		/// <param name="tagScript">An OPENTYPE_TAG structure defining the script tag for shaping.</param>
		/// <param name="tagLangSys">An OPENTYPE_TAG structure defining the language tag for shaping.</param>
		/// <param name="tagFeature">An OPENTYPE_TAG structure defining the feature tag to use for shaping the alternate glyph.</param>
		/// <param name="lParameter">
		/// Reference to the alternate glyph to substitute. This reference is an index to an array that contains all the alternate glyphs
		/// defined in the feature, as illustrated for OPENTYPE_FEATURE_RECORD. The alternate glyph array is one of the items retrieved by ScriptGetFontAlternateGlyphs.
		/// </param>
		/// <param name="wGlyphId">Identifier of the original glyph.</param>
		/// <param name="pwOutGlyphId">Pointer to the location in which this function retrieves the identifier of the alternate glyph.</param>
		/// <returns>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function uses one-to-one substitution in which the application can substitute one glyph with one alternate form. Most often,
		/// applications use this function to set a bullet or an alternate glyph at the beginning or end of a line.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptsubstitutesingleglyph HRESULT ScriptSubstituteSingleGlyph(
		// [in, optional] HDC hdc, [in, out] SCRIPT_CACHE *psc, [in, optional] SCRIPT_ANALYSIS *psa, [in] OPENTYPE_TAG tagScript, [in]
		// OPENTYPE_TAG tagLangSys, [in] OPENTYPE_TAG tagFeature, [in] LONG lParameter, [in] WORD wGlyphId, [out] WORD *pwOutGlyphId );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptSubstituteSingleGlyph")]
		public static extern HRESULT ScriptSubstituteSingleGlyph([In, Optional] HDC hdc, SafeSCRIPT_CACHE psc, in SCRIPT_ANALYSIS psa,
			OPENTYPE_TAG tagScript, OPENTYPE_TAG tagLangSys, OPENTYPE_TAG tagFeature, [In, MarshalAs(UnmanagedType.LPArray)] int[] lParameter,
			ushort wGlyphId, out ushort pwOutGlyphId);

		/// <summary>Displays text for the specified script shape and place information.</summary>
		/// <param name="hdc">
		/// Handle to the device context. For more information, see Caching. Note that, unlike some other related Uniscribe functions, this
		/// function defines the handle as mandatory.
		/// </param>
		/// <param name="psc">Pointer to a SCRIPT_CACHE structure identifying the script cache.</param>
		/// <param name="x">Value of the x coordinate of the first glyph.</param>
		/// <param name="y">Value of the y coordinate of the first glyph.</param>
		/// <param name="fuOptions">
		/// Options equivalent to the <c>fuOptions</c> parameter of ExtTextOut. This parameter can be set to either ETO_CLIPPED or
		/// ETO_OPAQUE, to both values, or to neither value.
		/// </param>
		/// <param name="lprc">
		/// Pointer to a RECT structure containing the rectangle used to clip the display. The application can set this parameter to <c>NULL</c>.
		/// </param>
		/// <param name="psa">Pointer to a SCRIPT_ANALYSIS structure obtained from a previous call to ScriptItemize.</param>
		/// <param name="pwcReserved">Reserved; must be set to <c>NULL</c>.</param>
		/// <param name="iReserved">Reserved; must be 0.</param>
		/// <param name="pwGlyphs">Pointer to an array of glyphs obtained from a previous call to ScriptShape.</param>
		/// <param name="cGlyphs">Count of the glyphs in the array indicated by <c>pwGlyphs</c>. The maximum number of glyphs is 65,536.</param>
		/// <param name="piAdvance">Pointer to an array of advance widths obtained from a previous call to ScriptPlace.</param>
		/// <param name="piJustify">
		/// Pointer to an array of justified advance widths (cell widths). The application can set this parameter to <c>NULL</c>.
		/// </param>
		/// <param name="pGoffset">Pointer to a GOFFSET structure containing the x and y offsets for the combining glyph.</param>
		/// <returns>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function calls the operating system ExtTextOut function for text display. For more information, see Displaying Text with Uniscribe.
		/// </para>
		/// <para>
		/// All arrays are in display order unless the <c>fLogicalOrder</c> member is set in the SCRIPT_ANALYSIS structure indicated by <c>psa</c>.
		/// </para>
		/// <para>
		/// For any run that is rendered right-to-left and was generated in logical order by forcing the <c>fLogicalOrder</c> member of
		/// SCRIPT_ANALYSIS, the application must call SetTextAlign (hdc, TA_RIGHT) and give the right-side coordinate before calling <c>ScriptTextOut</c>.
		/// </para>
		/// <para>
		/// The array indicated by <c>piJustify</c> provides cell widths for each glyph. When the width of a glyph differs from the
		/// unjustified width, specified by <c>piAdvance</c>, space is added to or removed from the glyph cell at its trailing edge. The
		/// glyph is always aligned with the leading edge of its cell. This rule applies even in visual order.
		/// </para>
		/// <para>
		/// When a glyph cell is extended, the extra space is usually made up by the addition of white space. However, for Arabic scripts,
		/// the extra space is made up by one or more kashida glyphs, unless the extra space is insufficient for the shortest kashida glyph
		/// in the font. The width of the shortest kashida is available by calling ScriptGetFontProperties.
		/// </para>
		/// <para>
		/// The application should pass a value for <c>piJustify</c> only if the string must be justified by <c>ScriptTextOut</c>. Normally,
		/// the application should pass <c>NULL</c>.
		/// </para>
		/// <para>
		/// The application should not use <c>ScriptTextOut</c> to write to a metafile unless the metafile will be played back without any
		/// font substitution, for example, immediately on the same system for scalable page preview. <c>ScriptTextOut</c> records glyph
		/// numbers in the metafile. Since glyph numbers vary considerably from one font to another, the file is unlikely to play back
		/// correctly when different fonts are substituted. For example, when a metafile is played back at a different scale, a CreateFont
		/// request recorded in the metafile can resolve to a bitmap instead of a TrueType font. Likewise, if the metafile is played back on
		/// a different computer, the requested fonts might not be installed. To write complex scripts in a metafile in a font-independent
		/// manner, the application should use ExtTextOut to write the logical characters directly, so that glyph generation and placement do
		/// not occur until the text is played back.
		/// </para>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scripttextout HRESULT ScriptTextOut( [in] const HDC hdc, [in,
		// out] SCRIPT_CACHE *psc, [in] int x, [in] int y, [in] UINT fuOptions, [in, optional] const RECT *lprc, [in] const SCRIPT_ANALYSIS
		// *psa, [in] const WCHAR *pwcReserved, [in] int iReserved, [in] const WORD *pwGlyphs, [in] int cGlyphs, [in] const int *piAdvance,
		// [in, optional] const int *piJustify, [in] const GOFFSET *pGoffset );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptTextOut")]
		public static extern HRESULT ScriptTextOut([In] HDC hdc, SafeSCRIPT_CACHE psc, int x, int y, uint fuOptions, [In, Optional] PRECT lprc,
			in SCRIPT_ANALYSIS psa, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pwcReserved, [Optional] int iReserved,
			[In, MarshalAs(UnmanagedType.LPArray)] ushort[] pwGlyphs, int cGlyphs, [In, MarshalAs(UnmanagedType.LPArray)] int[] piAdvance,
			[In, Optional, MarshalAs(UnmanagedType.LPArray)] int[] piJustify, in GOFFSET pGoffset);

		/// <summary>Generates the leading or trailing edge of a logical character cluster from the x offset of a run.</summary>
		/// <param name="iX">
		/// Offset, in logical units, from the end of the run specified by the <c>fLogicalOrder</c> member of the SCRIPT_ANALYSIS structure
		/// indicated by the <c>psa</c> parameter.
		/// </param>
		/// <param name="cChars">Count of logical code points in the run.</param>
		/// <param name="cGlyphs">Count of glyphs in the run.</param>
		/// <param name="pwLogClust">Pointer to an array of logical clusters.</param>
		/// <param name="psva">Pointer to an array of SCRIPT_VISATTR structures containing the visual attributes for the glyph.</param>
		/// <param name="piAdvance">Pointer to an array of advance widths.</param>
		/// <param name="psa">
		/// Pointer to a SCRIPT_ANALYSIS structure. The <c>fLogicalOrder</c> member indicates <c>TRUE</c> to use the leading edge of the run,
		/// or <c>FALSE</c> to use the trailing edge.
		/// </param>
		/// <param name="piCP">Pointer to a buffer in which this function retrieves the character position corresponding to the x coordinate.</param>
		/// <param name="piTrailing">
		/// Pointer to a buffer in which this function retrieves the distance, in code points, from the leading edge of the logical character
		/// to the <c>iX</c> position. If this value is 0, the <c>iX</c> position is at the leading edge of the logical character. For more
		/// information, see the Remarks section.
		/// </param>
		/// <returns>
		/// Returns 0 if successful. The function returns a nonzero HRESULT value if it does not succeed. The application can test the return
		/// value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The values passed to this function normally are the results of earlier calls to other Uniscribe functions. See Managing Caret
		/// Placement and Hit Testing for details.
		/// </para>
		/// <para>
		/// The leading and trailing edges of the logical character are determined by the direction of text in the run (left-to-right or
		/// right-to-left). For the left-to-right direction, the leading edge is the same as the left edge. For the right-to-left direction,
		/// the leading edge is the right edge.
		/// </para>
		/// <para>
		/// For scripts in which the caret is conventionally placed in the middle of a cluster, for example, Arabic and Hebrew, the retrieved
		/// character position can be for any code point in the line. In this case, the <c>piTrailing</c> parameter is set to either 0 or 1.
		/// </para>
		/// <para>
		/// For scripts in which the caret is conventionally snapped to the boundaries of a cluster, the retrieved character position is
		/// always the position of the first code point in a cluster (considered logically). The <c>piTrailing</c> parameter is set to 0 or
		/// to the number of code points in the cluster.
		/// </para>
		/// <para>
		/// The appropriate caret position for a mouse hit is always the retrieved character position plus the distance indicated by <c>piTrailing</c>.
		/// </para>
		/// <para>
		/// When <c>iX</c> indicates a position outside the run, <c>ScriptXtoCP</c> acts as if there is an extra infinitely large character
		/// beyond each end of the run. This results in the behavior shown in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term><c>iX</c> position (outside the run)</term>
		/// <term>Result</term>
		/// </listheader>
		/// <item>
		/// <term>Before the run, that is: <c>iX</c> &lt; 0 if run is left-to-right, or <c>iX</c> &gt;= sum of advances if run is right-to-left</term>
		/// <term>Value of <c>piCP</c> is -1 and value of <c>piTrailing</c> is 0</term>
		/// </item>
		/// <item>
		/// <term>After the run, that is: <c>iX</c> &gt;= sum of advances if run is left-to-right, or <c>iX</c> &lt; 0 if run is right-to-left</term>
		/// <term>Value of <c>piCP</c> is value of <c>cChars</c> and value of <c>piTrailing</c> is 1</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Important</c> Starting with Windows 8: To maintain the ability to run on Windows 7, a module that uses Uniscribe must specify
		/// Usp10.lib before gdi32.lib in its library list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptxtocp HRESULT ScriptXtoCP( [in] int iX, [in] int cChars,
		// [in] int cGlyphs, [in] const WORD *pwLogClust, [in] const SCRIPT_VISATTR *psva, [in] const int *piAdvance, [in] const
		// SCRIPT_ANALYSIS *psa, [out] int *piCP, [out] int *piTrailing );
		[DllImport(Lib_Usp10, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptXtoCP")]
		public static extern HRESULT ScriptXtoCP(int iX, int cChars, int cGlyphs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] pwLogClust,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] SCRIPT_VISATTR[] psva,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] piAdvance, in SCRIPT_ANALYSIS psa, out int piCP, out int piTrailing);

		private static int MulAdd(int x, decimal m, int a) => (int)Math.Round(x * m + a);
	}
}