using System.Runtime.InteropServices;
using static Vanara.Extensions.BitHelper;

namespace Vanara.PInvoke
{
	public static partial class Gdi32
	{
		/// <summary>Applies the specified digit substitution settings to the specified script control and script state structures.</summary>
		/// <param name="psds">
		/// Pointer to a SCRIPT_DIGITSUBSTITUTE structure. The application sets this parameter to <c>NULL</c> if the function is to call
		/// ScriptRecordDigitSubstitution with LOCALE_USER_DEFAULT.
		/// </param>
		/// <param name="psc">
		/// Pointer to a SCRIPT_CONTROL structure with the <c>fContextDigits</c> and <c>uDefaultLanguage</c> members updated.
		/// </param>
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
		// ScriptApplyDigitSubstitution( const SCRIPT_DIGITSUBSTITUTE *psds, SCRIPT_CONTROL *psc, SCRIPT_STATE *pss );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "486b8a56-eb14-48c3-b2f0-f5494f79baea")]
		public static extern HRESULT ScriptApplyDigitSubstitution(in SCRIPT_DIGITSUBSTITUTE psds, out SCRIPT_CONTROL psc, out SCRIPT_STATE pss);

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
		/// Pointer to an array in which the function retrieves the glyph advance widths. This array is suitable for passing to the piJustify
		/// parameter of ScriptTextOut.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptapplylogicalwidth HRESULT ScriptApplyLogicalWidth( const
		// int *piDx, int cChars, int cGlyphs, const WORD *pwLogClust, const SCRIPT_VISATTR *psva, const int *piAdvance, const
		// SCRIPT_ANALYSIS *psa, ABC *pABC, int *piJustify );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "964634f4-700b-47a7-a86f-071f1c97bcbe")]
		public static extern HRESULT ScriptApplyLogicalWidth([In] int[] piDx, int cChars, int cGlyphs, [In] ushort[] pwLogClust, in SCRIPT_VISATTR psva, [In] int[] piAdvance, in SCRIPT_ANALYSIS psa, ref ABC pABC, [Out] int[] piJustify);

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
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/nf-usp10-scriptbreak HRESULT ScriptBreak( const WCHAR *pwcChars, int
		// cChars, const SCRIPT_ANALYSIS *psa, SCRIPT_LOGATTR *psla );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("usp10.h", MSDNShortId = "1613819f-9473-4d9f-8a65-a109c9ef3f43")]
		public static extern HRESULT ScriptBreak([MarshalAs(UnmanagedType.LPWStr)] string pwcChars, int cChars, in SCRIPT_ANALYSIS psa, out SCRIPT_LOGATTR psla);

		/// <summary>Contains a portion of a Unicode string, that is, an "item".</summary>
		/// <remarks>
		/// <para>
		/// This structure is filled by ScriptItemize or ScriptItemizeOpenType, each of which breaks a Unicode string into individually
		/// shapeable items. Neither function accesses the <c>SCRIPT_ANALYSIS</c> structure directly. Each function handles an array of
		/// SCRIPT_ITEM structures, each of which has a member defining a <c>SCRIPT_ANALYSIS</c> structure.
		/// </para>
		/// <para>
		/// Applications that use ScriptItemizeOpenType instead of ScriptItemize should also use ScriptShapeOpenType and ScriptPlaceOpenType
		/// instead of ScriptShape and ScriptPlace. For more information, see Displaying Text with Uniscribe.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_analysis typedef struct tag_SCRIPT_ANALYSIS { WORD
		// eScript : 10; WORD fRTL : 1; WORD fLayoutRTL : 1; WORD fLinkBefore : 1; WORD fLinkAfter : 1; WORD fLogicalOrder : 1; WORD
		// fNoGlyphIndex : 1; SCRIPT_STATE s; } SCRIPT_ANALYSIS;
		[PInvokeData("usp10.h", MSDNShortId = "c673d5cc-c4ca-4238-8090-55abe3db324b")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SCRIPT_ANALYSIS
		{
			private ushort bits;

			/// <summary>
			/// <para>
			/// Opaque value identifying the engine that Uniscribe uses when calling the ScriptShape, ScriptPlace, and ScriptTextOut
			/// functions for the item. The value for this member is undefined and applications should not rely on its value being the same
			/// from one release to the next. An application can obtain the attributes of <c>eScript</c> by calling ScriptGetProperties.
			/// </para>
			/// <para>To disable shaping, the application should set this member to SCRIPT_UNDEFINED.</para>
			/// </summary>
			public ushort eScript { get => GetBits(bits, 0, 10); set => SetBits(ref bits, 0, 10, value); }

			/// <summary>
			/// <para>
			/// Value indicating rendering direction. Possible values are defined in the following table. This member is set to <c>TRUE</c>
			/// for a number in a left-to-right run, because digits are always displayed left to right, or <c>FALSE</c> for a number in a
			/// right-to-left run. The value of this member is normally identical to the parity of the Unicode embedding level, but it might
			/// differ if overridden by GetCharacterPlacement legacy support.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Use a right-to-left rendering direction.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Use a left-to-right rendering direction.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fRTL { get => GetBit(bits, 10); set => SetBit(ref bits, 10, value); }

			/// <summary>
			/// <para>
			/// Value indicating layout direction for a number. Possible values are defined in the following table. This member is usually
			/// the same as the value assigned to <c>fRTL</c> for a number in a right-to-left run.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Lay out the number in a right-to-left run, because it is read as part of the right-to-left sequence.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Lay out the number in a left-to-right run, because it is read as part of the left-to-right sequence.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fLayoutRTL { get => GetBit(bits, 11); set => SetBit(ref bits, 11, value); }

			/// <summary>
			/// <para>
			/// Value indicating if the shaping engine shapes the first character of the item as if it joins with a previous character.
			/// Possible values are defined in the following table. This member is set by ScriptItemize. The application can override the
			/// value before calling ScriptShape.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Shape the first character by linking with a previous character.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Do not shape the first character by linking with a previous character.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fLinkBefore { get => GetBit(bits, 12); set => SetBit(ref bits, 12, value); }

			/// <summary>
			/// <para>
			/// Value indicating if the shaping engine shapes the last character of the item as if it joins with a subsequent character.
			/// Possible values are defined in the following table. This member is set by ScriptItemize. The application can override the
			/// value before calling <c>ScriptItemize</c>.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Shape the last character by linking with a subsequent character.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Do not shape the last character by linking with a subsequent character.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fLinkAfter { get => GetBit(bits, 13); set => SetBit(ref bits, 13, value); }

			/// <summary>
			/// <para>
			/// Value indicating if the shaping engine generates all glyph-related arrays in logical order. Possible values are defined in
			/// the following table. This member is set to <c>FALSE</c> by ScriptItemize. The application can override the value before
			/// calling ScriptShape.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Generate all glyph-related arrays in logical order.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>
			/// Generate all glyph-related arrays in visual order, with the first array entry corresponding to the leftmost glyph. This value
			/// is the default.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fLogicalOrder { get => GetBit(bits, 14); set => SetBit(ref bits, 14, value); }

			/// <summary>
			/// <para>
			/// Value indicating the use of glyphs for the item. Possible values are defined in the following table. The application can set
			/// this member to <c>TRUE</c> on input to ScriptShape to disable the use of glyphs for the item. Additionally,
			/// <c>ScriptShape</c> sets it to <c>TRUE</c> for a hardware context containing symbolic, unrecognized, and device fonts.
			/// </para>
			/// <para>
			/// Disabling the use of glyphs also disables complex script shaping. Setting this member to <c>TRUE</c> implements shaping and
			/// placing directly by calls to GetTextExtentExPoint and ExtTextOut.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Disable the use of glyphs for the item. This value is used for bitmap, vector, and device fonts.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Enable the use of glyphs for the item. This value is the default.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fNoGlyphIndex { get => GetBit(bits, 15); set => SetBit(ref bits, 15, value); }

			/// <summary>A SCRIPT_STATE structure containing a copy of the Unicode algorithm state.</summary>
			public SCRIPT_STATE s;
		}

		/// <summary>Contains script control flags for several Uniscribe functions, for example, ScriptItemize.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_control typedef struct tag_SCRIPT_CONTROL { DWORD
		// uDefaultLanguage : 16; DWORD fContextDigits : 1; DWORD fInvertPreBoundDir : 1; DWORD fInvertPostBoundDir : 1; DWORD
		// fLinkStringBefore : 1; DWORD fLinkStringAfter : 1; DWORD fNeutralOverride : 1; DWORD fNumericOverride : 1; DWORD fLegacyBidiClass
		// : 1; DWORD fMergeNeutralItems : 1; DWORD fUseStandardBidi : 1; DWORD fReserved : 6; } SCRIPT_CONTROL;
		[PInvokeData("usp10.h", MSDNShortId = "4623f606-f67e-48ad-8c1d-d27da5ba556c")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SCRIPT_CONTROL
		{
			/// <summary>
			/// Primary language identifier for the language to use when Unicode values are ambiguous. This value is used in numeric
			/// processing to select digit shape when the <c>fDigitSubstitute</c> member of SCRIPT_STATE is set.
			/// </summary>
			public ushort uDefaultLanguage;

			private ushort bits;

			/// <summary>
			/// <para>Value indicating how national digits are selected. Possible values are defined in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Choose national digits according to the nearest previous strong text.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Choose national digits according to the value of the uDefaultLanguage member.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fContextDigits { get => GetBit(bits, 0); set => SetBit(ref bits, 0, value); }

			/// <summary>
			/// <para>
			/// Value indicating if the initial context is set to the opposite of the base embedding level, or to the base embedding level
			/// itself. Possible values are defined in the following table. The application sets this member to indicate that text at the
			/// start of the string defaults to being laid out as if it follows a strong left-to-right character if the base embedding level
			/// is 0, and as if it follows a strong right-to-left character if the base embedding level is 1. This member is used for
			/// GetCharacterPlacement legacy support.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Change the initial context to the opposite of the base embedding level.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Set the initial context to the base embedding level.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fInvertPreBoundDir { get => GetBit(bits, 1); set => SetBit(ref bits, 1, value); }

			/// <summary>
			/// <para>
			/// Value indicating if the final context is set to the opposite of the base embedding level, or to the base embedding level
			/// itself. Possible values are defined in the following table. The application sets this member to indicate that text at the end
			/// of the string defaults to being laid out as if it precedes strong text of the same direction as the base embedding level. It
			/// is used for GetCharacterPlacement legacy support.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Change the final context to the opposite of the base embedding level.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Set the final context to the base embedding level.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fInvertPostBoundDir { get => GetBit(bits, 2); set => SetBit(ref bits, 2, value); }

			/// <summary>
			/// <para>
			/// Value indicating if the shaping engine shapes the first character of the string as if it joins with a previous character.
			/// Possible values are defined in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Shape the first character by linking with a previous character.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Do not shape the first character by linking with a previous character.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fLinkStringBefore { get => GetBit(bits, 3); set => SetBit(ref bits, 3, value); }

			/// <summary>
			/// <para>
			/// Value indicating if the shaping engine shapes the last character of the string as if it is joined to a subsequent character.
			/// Possible values are defined in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Shape the last character by linking with a subsequent character.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Do not shape the last character by linking with a subsequent character.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fLinkStringAfter { get => GetBit(bits, 4); set => SetBit(ref bits, 4, value); }

			/// <summary>
			/// <para>
			/// Value indicating the treatment of all neutral characters in the string. Possible values are defined in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>
			/// Set neutral items to a strong direction, that is, right-to-left or left-to-right, depending on the current embedding level.
			/// This setting effectively locks the items in place, and reordering occurs only between neutrals.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Do not set neutral items to a strong direction.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fNeutralOverride { get => GetBit(bits, 5); set => SetBit(ref bits, 5, value); }

			/// <summary>
			/// <para>
			/// Value indicating the treatment of all numeric characters in the string. Possible values are defined in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>
			/// Set numeric characters to a strong direction, that is, right-to-left or left-to-right, depending on the current embedding
			/// level. This setting effectively locks the items in place, and reordering occurs only between numeric characters.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Do not set numeric characters to a strong direction.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fNumericOverride { get => GetBit(bits, 6); set => SetBit(ref bits, 6, value); }

			/// <summary>
			/// <para>
			/// Value indicating the handling for plus and minus characters by the shaping engine. Possible values are defined in the
			/// following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>
			/// Treat the plus and minus characters as for legacy bidirectional classes in pre-Windows XP operating systems. In this case,
			/// the characters are treated as neutral characters, that is, with no implied direction, and the slash character is treated as a
			/// common separator.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>
			/// Treat the plus and minus characters as for Windows XP and later. In this case, the characters are treated as European separators.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fLegacyBidiClass { get => GetBit(bits, 7); set => SetBit(ref bits, 7, value); }

			/// <summary>
			/// <para>
			/// Value specifying if the shaping engine should merge neutral characters into strong items when possible. Possible values are
			/// defined in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Merge neutral characters into strong items.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Do not merge neutral characters into strong items.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fMergeNeutralItems { get => GetBit(bits, 8); set => SetBit(ref bits, 8, value); }

			/// <summary>
			/// <para>
			/// Value specifying if the shaping engine should use the standard bidirectional matching pair algorithm. Possible values are
			/// defined in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Skip the matching pair algorithm.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Use the matching pair algorithm.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fUseStandardBidi { get => GetBit(bits, 9); set => SetBit(ref bits, 9, value); }
		}

		/// <summary>Contains native digit and digit substitution settings.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_digitsubstitute typedef struct tag_SCRIPT_DIGITSUBSTITUTE
		// { DWORD NationalDigitLanguage : 16; DWORD TraditionalDigitLanguage : 16; DWORD DigitSubstitute : 8; DWORD dwReserved; } SCRIPT_DIGITSUBSTITUTE;
		[PInvokeData("usp10.h", MSDNShortId = "e96bf8b4-7456-4e16-a623-48320104dd66")]
		[StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
		public struct SCRIPT_DIGITSUBSTITUTE
		{
			/// <summary>Language for native substitution.</summary>
			public ushort NationalDigitLanguage;

			/// <summary>Language for traditional substitution.</summary>
			public ushort TraditionalDigitLanguage;

			/// <summary>
			/// <para>
			/// Substitution type. This member is normally set by ScriptRecordDigitSubstitution. However, it can also have any of the values
			/// defined in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SCRIPT_DIGITSUBSTITUTE_CONTEXT</term>
			/// <term>
			/// Substitute digits U+0030 to U+0039 using the language of the prior letters. If there are no prior letters, substitute digits
			/// using the TraditionalDigitLanguage member. This member is normally set to the primary language of the locale passed to ScriptRecordDigitSubstitution.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SCRIPT_DIGITSUBSTITUTE_NATIONAL</term>
			/// <term>
			/// Substitute digits U+0030 to U+0039 using the NationalDigitLanguage member. This member is normally set to the national digits
			/// retrieved for the constant LOCALE_SNATIVEDIGITS by ScriptRecordDigitSubstitution.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SCRIPT_DIGITSUBSTITUTE_NONE</term>
			/// <term>Do not substitute digits. Display Unicode values U+0030 to U+0039 with European numerals.</term>
			/// </item>
			/// <item>
			/// <term>SCRIPT_DIGITSUBSTITUTE_TRADITIONAL</term>
			/// <term>
			/// Substitute digits U+0030 to U+0039 using the TraditionalDigitLanguage member. This member is normally set to the primary
			/// language of the locale passed to ScriptRecordDigitSubstitution.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public byte DigitSubstitute;

			/// <summary>Reserved; initialize to 0.</summary>
			public uint dwReserved;
		}

		/// <summary>Contains attributes of logical characters that are useful when editing and formatting text.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_logattr typedef struct tag_SCRIPT_LOGATTR { BYTE
		// fSoftBreak : 1; BYTE fWhiteSpace : 1; BYTE fCharStop : 1; BYTE fWordStop : 1; BYTE fInvalid : 1; BYTE fReserved : 3; } SCRIPT_LOGATTR;
		[PInvokeData("usp10.h", MSDNShortId = "24131b04-870a-4841-b9cd-7a09497bd2e6")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SCRIPT_LOGATTR
		{
			private ushort bits;

			/// <summary>
			/// <para>
			/// Value indicating if breaking the line in front of the character, called a "soft break", is valid. Possible values are defined
			/// in the following table. This member is set on the first character of Southeast Asian words.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>A soft break is valid.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>A soft break is not valid.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fSoftBreak { get => GetBit(bits, 0); set => SetBit(ref bits, 0, value); }

			/// <summary>
			/// <para>
			/// Value indicating if the character is one of the many Unicode characters classified as breakable white space. Possible values
			/// are defined in the following table. Breakable white space can break a word. All white space is breakable except nonbreaking
			/// space (NBSP) and zero-width nonbreaking space (ZWNBSP).
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The character is breakable white space.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The character is not breakable white space.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fWhiteSpace { get => GetBit(bits, 1); set => SetBit(ref bits, 1, value); }

			/// <summary>
			/// <para>
			/// Value indicating if the character is a valid position for showing the caret upon a character movement keyboard action.
			/// Possible values are defined in the following table. This member is set for most characters, but not on code points inside
			/// Indian and Southeast Asian character clusters. This member can be used to implement LEFT ARROW and RIGHT ARROW operations in editors.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The character is a valid position for showing the caret upon a character movement keyboard action.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The character is not a valid position for showing the caret upon a character movement keyboard action.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fCharStop { get => GetBit(bits, 2); set => SetBit(ref bits, 2, value); }

			/// <summary>
			/// <para>
			/// Value indicating the valid position for showing the caret upon a word movement keyboard action, such as CTRL+LEFT ARROW and
			/// CTRL+RIGHT ARROW. Possible values are defined in the following table. This member can be used to implement the CTRL+LEFT
			/// ARROW and CTRL+RIGHT ARROW operations in editors.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The character is a valid position for showing the caret upon a word movement keyboard action.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The character is not a valid position for showing the caret upon a word movement keyboard action.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fWordStop { get => GetBit(bits, 3); set => SetBit(ref bits, 3, value); }

			/// <summary>
			/// <para>
			/// Value used to mark characters that form an invalid or undisplayable combination. Possible values are defined in the following
			/// table. A script that can set this member has the <c>fInvalidLogAttr</c> member set in its SCRIPT_PROPERTIES structure.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The character forms an invalid or undisplayable combination.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The character does not form an invalid or undisplayable combination.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fInvalid { get => GetBit(bits, 4); set => SetBit(ref bits, 4, value); }
		}

		/// <summary>Contains script state information.</summary>
		/// <remarks>
		/// This structure is used to initialize the Unicode algorithm state as an input to ScriptItemize. It is also used as a component of
		/// the analysis retrieved by <c>ScriptItemize</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_state typedef struct tag_SCRIPT_STATE { WORD uBidiLevel :
		// 5; WORD fOverrideDirection : 1; WORD fInhibitSymSwap : 1; WORD fCharShape : 1; WORD fDigitSubstitute : 1; WORD fInhibitLigate : 1;
		// WORD fDisplayZWG : 1; WORD fArabicNumContext : 1; WORD fGcpClusters : 1; WORD fReserved : 1; WORD fEngineReserved : 2; } SCRIPT_STATE;
		[PInvokeData("usp10.h", MSDNShortId = "4b1724f7-7773-42c0-9c19-fbded5aef14e")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SCRIPT_STATE
		{
			private ushort bits;

			/// <summary>
			/// Embedding level associated with all characters in the associated run according to the Unicode bidirectional algorithm. When
			/// the application passes this structure to ScriptItemize, this member should be initialized to 0 for a left-to-right base
			/// embedding level, or to 1 for a right-to-left base embedding level.
			/// </summary>
			public ushort uBidiLevel { get => GetBits(bits, 0, 5); set => SetBits(ref bits, 0, 5, value); }

			/// <summary>
			/// <para>
			/// Initial override direction value indicating if the script uses an override level (LRO or RLO code in the string). Possible
			/// values are defined in the following table. For an override level, characters are laid out in one direction only, either left
			/// to right or right to left. No reordering of digits or strong characters of opposing direction takes place. Note that this
			/// value is reset by LRE, RLE, LRO or RLO codes in the string.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Use an override level that reflects the embedding level.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Do not use an override level that reflects the embedding level.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fOverrideDirection { get => GetBit(bits, 5); set => SetBit(ref bits, 5, value); }

			/// <summary>
			/// <para>
			/// Value indicating if the shaping engine bypasses mirroring of Unicode mirrored glyphs, for example, brackets. Possible values
			/// are defined in the following table. This member is set by Unicode character ISS, and cleared by ASS.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Bypass mirroring of Unicode mirrored glyphs.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Do not bypass mirroring of Unicode mirrored glyphs.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fInhibitSymSwap { get => GetBit(bits, 6); set => SetBit(ref bits, 6, value); }

			/// <summary>
			/// <para>
			/// Not implemented. Value indicating if character codes in the Arabic Presentation Forms areas of Unicode should be shaped.
			/// Possible values are defined in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Shape character codes in the Arabic Presentation Forms areas of Unicode.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Do not shape character codes in the Arabic Presentation Forms areas of Unicode.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fCharShape { get => GetBit(bits, 7); set => SetBit(ref bits, 7, value); }

			/// <summary>
			/// <para>
			/// This member provides the same control over digit substitution behavior that might have been obtained in legacy
			/// implementations using the now-deprecated Unicode characters U+206E NATIONAL DIGIT SHAPES ("NADS") and U+206F NOMINAL DIGIT
			/// SHAPES ("NODS"). Possible values are defined in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Character codes U+0030 through U+0039 are substituted by national digits.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Character codes U+0030 through U+0039 are not substituted by national digits.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fDigitSubstitute { get => GetBit(bits, 8); set => SetBit(ref bits, 8, value); }

			/// <summary>
			/// <para>
			/// Value indicating if ligatures are used in the shaping of Arabic or Hebrew characters. Possible values are defined in the
			/// following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Do not use ligatures in the shaping of Arabic or Hebrew characters.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Use ligatures in the shaping of Arabic or Hebrew characters.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fInhibitLigate { get => GetBit(bits, 9); set => SetBit(ref bits, 9, value); }

			/// <summary>
			/// <para>
			/// Value indicating if nondisplayable control characters are shaped as representational glyphs for languages that need
			/// reordering or different glyph shapes, depending on the positions of the characters within a word. Possible values are defined
			/// in the following table. Typically, the characters are not displayed. They are shaped to the blank glyph and given a width of 0.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Shape control characters as representational glyphs.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Do not shape control characters as representational glyphs.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fDisplayZWG { get => GetBit(bits, 10); set => SetBit(ref bits, 10, value); }

			/// <summary>
			/// <para>
			/// Value indicating if prior strong characters are Arabic for the purposes of rule P0, as discussed in the Unicode Standard,
			/// version 2.0. Possible values are defined in the following table. This member should normally be set to <c>TRUE</c> before
			/// itemization of a right-to-left paragraph in an Arabic language, and to <c>FALSE</c> otherwise.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Consider prior strong characters to be Arabic for the purposes of rule P0.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Do not consider prior strong characters to be Arabic for the purposes of rule P0.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fArabicNumContext { get => GetBit(bits, 11); set => SetBit(ref bits, 11, value); }

			/// <summary>
			/// <para>
			/// For GetCharacterPlacement legacy support only. Value indicating how ScriptShape should generate the array indicated by
			/// pwLogClust. Possible values are defined in the following table. This member affects only Arabic and Hebrew items.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Generate the array the same way as GetCharacterPlacement does.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Do not generate the array the same way as GetCharacterPlacement does.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fGcpClusters { get => GetBit(bits, 12); set => SetBit(ref bits, 12, value); }

			/// <summary>Reserved; always initialize to 0.</summary>
			public bool fReserved { get => GetBit(bits, 13); set => SetBit(ref bits, 13, value); }

			/// <summary>Reserved; always initialize to 0.</summary>
			public ushort fEngineReserved { get => GetBits(bits, 14, 2); set => SetBits(ref bits, 14, 2, value); }
		}

		/// <summary>Contains the visual (glyph) attributes that identify clusters and justification points, as generated by ScriptShape.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_visattr typedef struct tag_SCRIPT_VISATTR { WORD
		// uJustification : 4; WORD fClusterStart : 1; WORD fDiacritic : 1; WORD fZeroWidth : 1; WORD fReserved : 1; WORD fShapeReserved : 8;
		// } SCRIPT_VISATTR;
		[PInvokeData("usp10.h", MSDNShortId = "83b77f60-2520-49ee-bc7f-27cb3db02ac8")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SCRIPT_VISATTR
		{
			private ushort bits;

			/// <summary>Justification class for the glyph. See SCRIPT_JUSTIFY.</summary>
			public ushort uJustification { get => GetBits(bits, 0, 4); set => SetBits(ref bits, 0, 4, value); }

			/// <summary>
			/// <para>
			/// Value indicating the logical first glyph in every cluster, even for clusters containing just one glyph. Possible values are
			/// defined in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The glyph is the logical first glyph of the cluster.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The glyph is not the logical first glyph of the cluster.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fClusterStart { get => GetBit(bits, 4); set => SetBit(ref bits, 4, value); }

			/// <summary>
			/// <para>Value indicating if a glyph combines with base characters. Possible values are defined in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The glyph does combine with base characters.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The glyph does not combine with base characters.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fDiacritic { get => GetBit(bits, 5); set => SetBit(ref bits, 5, value); }

			/// <summary>
			/// <para>
			/// Value set by the shaping engine to indicate a zero-width character, such as ZWJ and ZWNJ. This value is set for some, but not
			/// all, zero-width characters. Possible values are defined in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The glyph indicates a zero-width character.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The glyph does not indicate a zero-width character.</term>
			/// </item>
			/// </list>
			/// </summary>
			public bool fZeroWidth { get => GetBit(bits, 6); set => SetBit(ref bits, 6, value); }

			/// <summary>Reserved; always initialize to 0.</summary>
			public bool fReserved { get => GetBit(bits, 7); set => SetBit(ref bits, 7, value); }

			/// <summary>Reserved; for use by shaping engines.</summary>
			public ushort fShapeReserved { get => GetBits(bits, 8, 8); set => SetBits(ref bits, 8, 8, value); }
		}

		/*
		ScriptCacheGetHeight Retrieves the height of the currently cached font.
	 ScriptCPtoX Generates the x offset from the left end or leading edge of a run to either the leading or trailing edge of a logical character cluster.
	 ScriptFreeCache Frees a script cache.
	 ScriptGetCMap Retrieves the glyph indexes of the Unicode characters in a string according to either the TrueType cmap table or the standard cmap table implemented for old-style fonts.
   ScriptGetFontAlternateGlyphs    Retrieves a list of alternate glyphs for a specified character that can be accessed through a specified OpenType feature.

   ScriptGetFontFeatureTags Retrieves a list of typographic features for the defined writing system for OpenType processing. The typographic feature tags comprising the list are retrieved from the font in the supplied device context or cache.

   ScriptGetFontLanguageTags Retrieves a list of language tags that are available for the specified item and are supported by a specified script tag for OpenType processing. The tags comprising the list are retrieved from the font in the specified device context or cache.

   ScriptGetFontProperties Retrieves information from the font cache on the special glyphs used by a font.
   ScriptGetFontScriptTags Retrieves a list of scripts available in the font for OpenType processing. Scripts comprising the list are retrieved from the font located in the supplied device context or from the script shaping engine that processes the font of the current run.

   ScriptGetGlyphABCWidth Retrieves the ABC width of a given glyph.
   ScriptGetLogicalWidths Converts the glyph advance widths for a specific font into logical widths.

   ScriptGetProperties Retrieves information about the current scripts.
   ScriptIsComplex Determines whether a Unicode string requires complex script processing.
   ScriptItemize Breaks a Unicode string into individually shapeable items.
   ScriptItemizeOpenType Breaks a Unicode string into individually shapeable items and provides an array of feature tags for each shapeable item for OpenType processing.

   ScriptJustify Creates an advance widths table to allow text justification when passed to the ScriptTextOut function.

   ScriptLayout Converts an array of run embedding levels to a map of visual-to-logical position and/or logical-to-visual position.

   ScriptPlace Generates glyph advance width and two-dimensional offset information from the output of ScriptShape.

   ScriptPlaceOpenType Generates glyphs and visual attributes for a Unicode run with OpenType information from the output of ScriptShapeOpenType.
   ScriptPositionSingleGlyph Positions a single glyph with a single adjustment using a specified feature provided in the font for OpenType processing.Most often, applications use this function to align a glyph optically at the beginning or end of a line.

 ScriptRecordDigitSubstitution Reads the National Language Support (NLS) native digit and digit substitution settings and records them in a SCRIPT_DIGITSUBSTITUTE structure.For more information, see Digit Shapes.
 ScriptShape Generates glyphs and visual attributes for a Unicode run.
 ScriptShapeOpenType Generates glyphs and visual attributes for a Unicode run with OpenType information. Each run consists of one call to this function.
 ScriptString_pcOutChars Returns a pointer to the length of a string after clipping.
 ScriptString_pLogAttr Returns a pointer to a logical attributes buffer for an analyzed string.

 ScriptString_pSize Returns a pointer to a SIZE structure for an analyzed string.

 ScriptStringAnalyse Analyzes a plain text string.

 ScriptStringCPtoX Retrieves the x coordinate for the leading or trailing edge of a character position.
 ScriptStringFree Frees a SCRIPT_STRING_ANALYSIS structure.
 ScriptStringGetLogicalWidths Converts visual widths into logical widths.
 ScriptStringGetOrder Creates an array that maps an original character position to a glyph position.

 ScriptStringOut Displays a string generated by a prior call to ScriptStringAnalyse and optionally adds highlighting.

 ScriptStringValidate Checks a SCRIPT_STRING_ANALYSIS structure for invalid sequences.

 ScriptStringXtoCP Converts an x coordinate to a character position.
 ScriptSubstituteSingleGlyph Enables substitution of a single glyph with one alternate form of the same glyph for OpenType processing.

 ScriptTextOut Displays text for the specified script shape and place information.
 ScriptXtoCP Generates the leading or trailing edge of a logical character cluster from the x offset of a run.

 */
	}
}