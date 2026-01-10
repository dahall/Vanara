using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke;

public static partial class Dwrite
{
	/// <summary>
	/// <para>
	/// Represents an absolute reference to a font face. This interface contains font face type, appropriate file references, and face
	/// identification data.
	/// </para>
	/// <para>
	/// This interface extends <c>IDWriteFontFace3</c>. Various font data such as metrics, names, and glyph outlines are obtained from <b>IDWriteFontFace</b>.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontface4
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontFace4")]
	[ComImport, Guid("27F2A904-4EB8-441D-9678-0563F53E3E2F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontFace4 : IDWriteFontFace, IDWriteFontFace1, IDWriteFontFace2, IDWriteFontFace3
	{
		/// <summary>Obtains the file format type of a font face.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_FACE_TYPE</c></para>
		/// <para>A value that indicates the type of format for the font face (such as Type 1, TrueType, vector, or bitmap).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-gettype DWRITE_FONT_FACE_TYPE GetType();
		[PreserveSig]
		new DWRITE_FONT_FACE_TYPE GetType();

		/// <summary>Obtains the font files representing a font face.</summary>
		/// <param name="numberOfFiles">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// If fontFiles is <c>NULL</c>, receives the number of files representing the font face. Otherwise, the number of font files being
		/// requested should be passed. See the Remarks section below for more information.
		/// </para>
		/// </param>
		/// <param name="fontFiles">
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a user-provided array that stores pointers to font files representing the font
		/// face. This parameter can be <c>NULL</c> if the user wants only the number of files representing the font face. This API
		/// increments reference count of the font file pointers returned according to COM conventions, and the client should release them
		/// when finished.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The <c>IDWriteFontFace::GetFiles</c> method should be called twice. The first time you call <c>GetFiles</c> fontFiles should be
		/// <c>NULL</c>. When the method returns, numberOfFiles receives the number of font files that represent the font face.
		/// </para>
		/// <para>
		/// Then, call the method a second time, passing the numberOfFiles value that was output the first call, and a non-null buffer of
		/// the correct size to store the IDWriteFontFile pointers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getfiles HRESULT GetFiles( UINT32
		// *numberOfFiles, IDWriteFontFile **fontFiles );
		new void GetFiles(ref uint numberOfFiles, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] IDWriteFontFile[]? fontFiles);

		/// <summary>Obtains the index of a font face in the context of its font files.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The zero-based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value is zero.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getindex UINT32 GetIndex();
		[PreserveSig]
		new uint GetIndex();

		/// <summary>Obtains the algorithmic style simulation flags of a font face.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>Font face simulation flags for algorithmic means of making text bold or italic.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getsimulations DWRITE_FONT_SIMULATIONS GetSimulations();
		[PreserveSig]
		new DWRITE_FONT_SIMULATIONS GetSimulations();

		/// <summary>Determines whether the font is a symbol font.</summary>
		/// <returns>
		/// <para>Type: <c>bool</c></para>
		/// <para>Returns <c>TRUE</c> if the font is a symbol font, otherwise <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-issymbolfont bool IsSymbolFont();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsSymbolFont();

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a font face and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="fontFaceMetrics">
		/// <para>Type: <c>DWRITE_FONT_METRICS*</c></para>
		/// <para>
		/// When this method returns, a DWRITE_FONT_METRICS structure that holds metrics (such as ascent, descent, or cap height) for the
		/// current font face element. The metrics returned by this function are in font design units.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getmetrics void GetMetrics(
		// DWRITE_FONT_METRICS *fontFaceMetrics );
		[PreserveSig]
		new void GetMetrics(out DWRITE_FONT_METRICS fontFaceMetrics);

		/// <summary>Obtains the number of glyphs in the font face.</summary>
		/// <returns>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>The number of glyphs in the font face.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphcount UINT16 GetGlyphCount();
		[PreserveSig]
		new ushort GetGlyphCount();

		/// <summary>Obtains ideal (resolution-independent) glyph metrics in font design units.</summary>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>
		/// An array of glyph indices for which to compute metrics. The array must contain at least as many elements as specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the glyphIndices array.</para>
		/// </param>
		/// <param name="glyphMetrics">
		/// <para>Type: <c>DWRITE_GLYPH_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains an array of DWRITE_GLYPH_METRICS structures. glyphMetrics must be initialized with an empty
		/// buffer that contains at least as many elements as glyphCount. The metrics returned by this function are in font design units.
		/// </para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// Indicates whether the font is being used in a sideways run. This can affect the glyph metrics if the font has oblique simulation
		/// because sideways oblique simulation differs from non-sideways oblique simulation
		/// </para>
		/// </param>
		/// <remarks>Design glyph metrics are used for glyph positioning.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getdesignglyphmetrics HRESULT
		// GetDesignGlyphMetrics( UINT16 const *glyphIndices, UINT32 glyphCount, DWRITE_GLYPH_METRICS *glyphMetrics, bool isSideways );
		new void GetDesignGlyphMetrics([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices, uint glyphCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_GLYPH_METRICS[] glyphMetrics, [MarshalAs(UnmanagedType.Bool)] bool isSideways = false);

		/// <summary>Returns the nominal mapping of UCS4 Unicode code points to glyph indices as defined by the font 'CMAP' table.</summary>
		/// <param name="codePoints">
		/// <para>Type: <c>const UINT32*</c></para>
		/// <para>
		/// An array of USC4 code points from which to obtain nominal glyph indices. The array must be allocated and be able to contain the
		/// number of elements specified by codePointCount.
		/// </para>
		/// </param>
		/// <param name="codePointCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the codePoints array.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>UINT16*</c></para>
		/// <para>When this method returns, contains a pointer to an array of nominal glyph indices filled by this function.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Note that this mapping is primarily provided for line layout engines built on top of the physical font API. Because of OpenType
		/// glyph substitution and line layout character substitution, the nominal conversion does not always correspond to how a Unicode
		/// string will map to glyph indices when rendering using a particular font face. Also, note that Unicode variant selectors provide
		/// for alternate mappings for character to glyph. This call will always return the default variant.
		/// </para>
		/// <para>
		/// When characters are not present in the font this method returns the index 0, which is the undefined glyph or ".notdef" glyph. If
		/// a character isn't in a font, IDWriteFont::HasCharacter returns false and GetUnicodeRanges doesn't return it in the range.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphindices HRESULT GetGlyphIndices(
		// UINT32 const *codePoints, UINT32 codePointCount, UINT16 *glyphIndices );
		new void GetGlyphIndices([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] codePoints, uint codePointCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices);

		/// <summary>
		/// Finds the specified OpenType font table if it exists and returns a pointer to it. The function accesses the underlying font data
		/// through the IDWriteFontFileStream interface implemented by the font file loader.
		/// </summary>
		/// <param name="openTypeTableTag">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The four-character tag of a OpenType font table to find. Use the <c>DWRITE_MAKE_OPENTYPE_TAG</c> macro to create it as an
		/// <c>UINT32</c>. Unlike GDI, it does not support the special TTCF and null tags to access the whole font.
		/// </para>
		/// </param>
		/// <param name="tableData">
		/// <para>Type: <c>const void**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the base of the table in memory. The pointer is valid only as
		/// long as the font face used to get the font table still exists; (not any other font face, even if it actually refers to the same
		/// physical font). This parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <param name="tableSize">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains a pointer to the size, in bytes, of the font table.</para>
		/// </param>
		/// <param name="tableContext">
		/// <para>Type: <c>void**</c></para>
		/// <para>
		/// When this method returns, the address of a pointer to the opaque context, which must be freed by calling ReleaseFontTable. The
		/// context actually comes from the lower-level IDWriteFontFileStream, which may be implemented by the application or DWrite itself.
		/// It is possible for a <c>NULL</c> tableContext to be returned, especially if the implementation performs direct memory mapping on
		/// the whole file. Nevertheless, always release it later, and do not use it as a test for function success. The same table can be
		/// queried multiple times, but because each returned context can be different, you must release each context separately.
		/// </para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <c>bool*</c></para>
		/// <para>When this method returns, <c>TRUE</c> if the font table exists; otherwise, <c>FALSE</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The context for the same tag may be different for each call, so each one must be held and released separately.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-trygetfonttable HRESULT TryGetFontTable(
		// UINT32 openTypeTableTag, const void **tableData, UINT32 *tableSize, void **tableContext, bool *exists );
		new HRESULT TryGetFontTable([In] uint openTypeTableTag, out IntPtr tableData, out uint tableSize, out IntPtr tableContext, [MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Releases the table obtained earlier from TryGetFontTable.</summary>
		/// <param name="tableContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>A pointer to the opaque context from TryGetFontTable.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-releasefonttable void ReleaseFontTable( void
		// *tableContext );
		[PreserveSig]
		new void ReleaseFontTable([In] IntPtr tableContext);

		/// <summary>Computes the outline of a run of glyphs by calling back to the outline sink interface.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>
		/// An array of glyph indices. The glyphs are in logical order and the advance direction depends on the isRightToLeft parameter. The
		/// array must be allocated and be able to contain the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <c>const FLOAT*</c></para>
		/// <para>
		/// An optional array of glyph advances in DIPs. The advance of a glyph is the amount to advance the position (in the direction of
		/// the baseline) after drawing the glyph. glyphAdvances contains the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphOffsets">
		/// <para>Type: <c>const DWRITE_GLYPH_OFFSET*</c></para>
		/// <para>
		/// An optional array of glyph offsets, each of which specifies the offset along the baseline and offset perpendicular to the
		/// baseline of a glyph relative to the current pen position. glyphOffsets contains the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of glyphs in the run.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// If <c>TRUE</c>, the ascender of the glyph runs alongside the baseline. If <c>FALSE</c>, the glyph ascender runs perpendicular to
		/// the baseline. For example, an English alphabet on a vertical baseline would have isSideways set to <c>FALSE</c>.
		/// </para>
		/// <para>
		/// A client can render a vertical run by setting isSideways to <c>TRUE</c> and rotating the resulting geometry 90 degrees to the
		/// right using a transform. The isSideways and isRightToLeft parameters cannot both be true.
		/// </para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// The visual order of the glyphs. If this parameter is <c>FALSE</c>, then glyph advances are from left to right. If <c>TRUE</c>,
		/// the advance direction is right to left. By default, the advance direction is left to right.
		/// </para>
		/// </param>
		/// <param name="geometrySink">
		/// <para>Type: <c>IDWriteGeometrySink*</c></para>
		/// <para>A pointer to the interface that is called back to perform outline drawing operations.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphrunoutline HRESULT
		// GetGlyphRunOutline( FLOAT emSize, UINT16 const *glyphIndices, FLOAT const *glyphAdvances, DWRITE_GLYPH_OFFSET const
		// *glyphOffsets, UINT32 glyphCount, bool isSideways, bool isRightToLeft, IDWriteGeometrySink *geometrySink );
		new void GetGlyphRunOutline(float emSize, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ushort[] glyphIndices,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[]? glyphAdvances,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_GLYPH_OFFSET[]? glyphOffsets,
			uint glyphCount, [MarshalAs(UnmanagedType.Bool)] bool isSideways, [MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
			[In, MarshalAs(UnmanagedType.Interface)] object geometrySink);

		/// <summary>Determines the recommended rendering mode for the font, using the specified size and rendering parameters.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96, this value is 1.0f. If the DPI is
		/// 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>
		/// The measuring method that will be used for glyphs in the font. Renderer implementations may choose different rendering modes for
		/// different measuring methods, for example:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL for DWRITE_MEASURING_MODE_NATURAL</term>
		/// </item>
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC for DWRITE_MEASURING_MODE_GDI_CLASSIC</term>
		/// </item>
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL for DWRITE_MEASURING_MODE_GDI_NATURAL</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>
		/// A pointer to an object that contains rendering settings such as gamma level, enhanced contrast, and ClearType level. This
		/// parameter is necessary in case the rendering parameters object overrides the rendering mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWRITE_RENDERING_MODE*</c></para>
		/// <para>When this method returns, contains a value that indicates the recommended rendering mode to use.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MEASURING_MODE measuringMode, IDWriteRenderingParams
		// *renderingParams, DWRITE_RENDERING_MODE *renderingMode );
		new DWRITE_RENDERING_MODE GetRecommendedRenderingMode(float emSize, float pixelsPerDip, DWRITE_MEASURING_MODE measuringMode, IDWriteRenderingParams renderingParams);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a fontface and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_METRICS*</c></para>
		/// <para>A pointer to a DWRITE_FONT_METRICS structure to fill in. The metrics returned by this function are in font design units.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getgdicompatiblemetrics HRESULT
		// GetGdiCompatibleMetrics( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, DWRITE_FONT_METRICS
		// *fontFaceMetrics );
		new DWRITE_FONT_METRICS GetGdiCompatibleMetrics(float emSize, float pixelsPerDip, [In, Optional] IntPtr transform);

		/// <summary>Obtains glyph metrics in font design units with the return values compatible with what GDI would produce.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The ogical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// When set to <c>FALSE</c>, the metrics are the same as the metrics of GDI aliased text. When set to <c>TRUE</c>, the metrics are
		/// the same as the metrics of text measured by GDI using a font created with <c>CLEARTYPE_NATURAL_QUALITY</c>.
		/// </para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>An array of glyph indices for which to compute the metrics.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the glyphIndices array.</para>
		/// </param>
		/// <param name="glyphMetrics">
		/// <para>Type: <c>DWRITE_GLYPH_METRICS*</c></para>
		/// <para>An array of DWRITE_GLYPH_METRICS structures filled by this function. The metrics are in font design units.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// A bool value that indicates whether the font is being used in a sideways run. This can affect the glyph metrics if the font has
		/// oblique simulation because sideways oblique simulation differs from non-sideways oblique simulation.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getgdicompatibleglyphmetrics HRESULT
		// GetGdiCompatibleGlyphMetrics( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, bool useGdiNatural, UINT16 const
		// *glyphIndices, UINT32 glyphCount, DWRITE_GLYPH_METRICS *glyphMetrics, bool isSideways );
		new void GetGdiCompatibleGlyphMetrics(float emSize, float pixelsPerDip, [In, Optional] IntPtr transform, [MarshalAs(UnmanagedType.Bool)] bool useGdiNatural,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ushort[] glyphIndices, uint glyphCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] DWRITE_GLYPH_METRICS[] glyphMetrics, [MarshalAs(UnmanagedType.Bool)] bool isSideways = false);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a font face and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="fontMetrics">
		/// <para>Type: <b><c>DWRITE_FONT_METRICS1</c>*</b></para>
		/// <para>
		/// A filled <c>DWRITE_FONT_METRICS1</c> structure that holds metrics for the current font face element. The metrics returned by
		/// this method are in font design units.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getmetrics void GetMetrics( [out]
		// DWRITE_FONT_METRICS1 *fontMetrics );
		[PreserveSig]
		new void GetMetrics(out DWRITE_FONT_METRICS1 fontMetrics);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a fontface and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="emSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The logical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and <i>pixelsPerDip</i>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_METRICS1</c>*</b></para>
		/// <para>
		/// A pointer to a <c>DWRITE_FONT_METRICS1</c> structure to fill in. The metrics returned by this function are in font design units.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getgdicompatiblemetrics HRESULT
		// GetGdiCompatibleMetrics( FLOAT emSize, FLOAT pixelsPerDip, [in, optional] DWRITE_MATRIX const *transform, [out]
		// DWRITE_FONT_METRICS1 *fontMetrics );
		new DWRITE_FONT_METRICS1 GetGdiCompatibleMetrics(float emSize, float pixelsPerDip, [In, Optional] StructPointer<DWRITE_MATRIX> transform);

		/// <summary>Gets caret metrics for the font in design units.</summary>
		/// <param name="caretMetrics">
		/// <para>Type: <b>DWRITE_CARET_METRICS*</b></para>
		/// <para>A pointer to the <c>DWRITE_CARET_METRICS</c> structure that is filled.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>Caret metrics are used by text editors for drawing the correct caret placement and slant.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getcaretmetrics void GetCaretMetrics(
		// [out] DWRITE_CARET_METRICS *caretMetrics );
		[PreserveSig]
		new void GetCaretMetrics(out DWRITE_CARET_METRICS caretMetrics);

		/// <summary>Retrieves a list of character ranges supported by a font.</summary>
		/// <param name="maxRangeCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Maximum number of character ranges passed in from the client.</para>
		/// </param>
		/// <param name="unicodeRanges">
		/// <para>Type: <b><c>DWRITE_UNICODE_RANGE</c>*</b></para>
		/// <para>An array of <c>DWRITE_UNICODE_RANGE</c> structures that are filled with the character ranges.</para>
		/// </param>
		/// <param name="actualRangeCount">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>A pointer to the actual number of character ranges, regardless of the maximum count.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// A list of character ranges supported by the font is useful for scenarios like character picking, glyph display, and efficient
		/// font selection lookup. This is similar to GDI's <c>GetFontUnicodeRanges</c>, except that it returns the full Unicode range, not
		/// just 16-bit UCS-2.
		/// </para>
		/// <para>These ranges are from the cmap, not the OS/2::ulCodePageRange1.</para>
		/// <para>
		/// If this method is unavailable, you can use the <c>IDWriteFontFace::GetGlyphIndices</c> method to check for missing glyphs. The
		/// method returns the 0 index for glyphs that aren't present in the font.
		/// </para>
		/// <para>
		/// The <c>IDWriteFont::HasCharacter</c> method is often simpler in cases where you need to check a single character or a series of
		/// single characters in succession, such as in font fallback.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getunicoderanges HRESULT
		// GetUnicodeRanges( UINT32 maxRangeCount, [out, optional] DWRITE_UNICODE_RANGE *unicodeRanges, [out] UINT32 *actualRangeCount );
		new void GetUnicodeRanges(int maxRangeCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DWRITE_UNICODE_RANGE[]? unicodeRanges, out uint actualRangeCount);

		/// <summary>
		/// Determines whether the font of a text range is monospaced, that is, the font characters are the same fixed-pitch width.
		/// </summary>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns TRUE if the font is monospaced, otherwise it returns FALSE.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-ismonospacedfont bool IsMonospacedFont();
		[PreserveSig]
		new bool IsMonospacedFont();

		/// <summary>Retrieves the advances in design units for a sequences of glyphs.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of glyphs to retrieve advances for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve advances for.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <b>INT32*</b></para>
		/// <para>The returned advances in font design units for each glyph.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Retrieve the glyph's vertical advance height rather than horizontal advance widths.</para>
		/// </param>
		/// <remarks>This is equivalent to calling GetGlyphMetrics and using only the advance width and height.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getdesignglyphadvances HRESULT
		// GetDesignGlyphAdvances( UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvances, bool isSideways );
		new void GetDesignGlyphAdvances(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] glyphAdvances, bool isSideways = false);

		/// <summary>Returns the pixel-aligned advances for a sequences of glyphs.</summary>
		/// <param name="emSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// Number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96 this value is 1.0f. If the DPI is 120,
		/// this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the font
		/// size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// When FALSE, the metrics are the same as GDI aliased text (DWRITE_MEASURING_MODE_GDI_CLASSIC). When TRUE, the metrics are the
		/// same as those measured by GDI using a font using CLEARTYPE_NATURAL_QUALITY (DWRITE_MEASURING_MODE_GDI_NATURAL).
		/// </para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Retrieve the glyph's vertical advances rather than horizontal advances.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Total glyphs to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve advances.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <b>const INT32*</b></para>
		/// <para>The returned advances in font design units for each glyph.</para>
		/// </param>
		/// <remarks>
		/// <para>This is equivalent to calling <c>GetGdiCompatibleGlyphMetrics</c> and using only the advance width and height.</para>
		/// <para>Like <c>GetGdiCompatibleGlyphMetrics</c>, these are in design units, meaning they must be scaled down by DWRITE_FONT_METRICS::designUnitsPerEm.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getgdicompatibleglyphadvances HRESULT
		// GetGdiCompatibleGlyphAdvances( FLOAT emSize, FLOAT pixelsPerDip, [in, optional] DWRITE_MATRIX const *transform, bool
		// useGdiNatural, bool isSideways, UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvances );
		new void GetGdiCompatibleGlyphAdvances(float emSize, float pixelsPerDip, [In, Optional] StructPointer<DWRITE_MATRIX> transform, bool useGdiNatural,
			bool isSideways, int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] int[] glyphAdvances);

		/// <summary>Retrieves the kerning pair adjustments from the font's kern table.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Number of glyphs to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphAdvanceAdjustments">
		/// <para>Type: <b>INT32*</b></para>
		/// <para>The advances, returned in font design units, for each glyph. The last glyph adjustment is zero.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <b>GetKerningPairAdjustments</b> isn't a direct replacement for GDI's character based <c>GetKerningPairs</c>, but it serves the
		/// same role, without the client needing to cache them locally. <b>GetKerningPairAdjustments</b> also uses glyph id's directly
		/// rather than UCS-2 characters (how the kern table actually stores them), which avoids glyph collapse and ambiguity, such as the
		/// dash and hyphen, or space and non-breaking space.
		/// </para>
		/// <para>
		/// Newer fonts may have only GPOS kerning instead of the legacy pair-table kerning. Such fonts, like Gabriola, will only return 0's
		/// for adjustments. <b>GetKerningPairAdjustments</b> doesn't virtualize and flatten these GPOS entries into kerning pairs.
		/// </para>
		/// <para>
		/// You can realize a performance benefit by calling <c>IDWriteFontFace1::HasKerningPairs</c> to determine whether you need to call
		/// <b>GetKerningPairAdjustments</b>. If you previously called <b>IDWriteFontFace1::HasKerningPairs</b> and it returned FALSE, you
		/// can avoid calling <b>GetKerningPairAdjustments</b> because the font has no kerning pair-table entries. That is, in this
		/// situation, a call to <b>GetKerningPairAdjustments</b> would be a no-op.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getkerningpairadjustments HRESULT
		// GetKerningPairAdjustments( UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvanceAdjustments );
		new void GetKerningPairAdjustments(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] glyphAdvanceAdjustments);

		/// <summary>Determines whether the font supports pair-kerning.</summary>
		/// <returns>Returns TRUE if the font supports kerning pairs, otherwise FALSE.</returns>
		/// <remarks>
		/// If the font doesn't support pair table kerning, you don't need to call <c>IDWriteFontFace1::GetKerningPairAdjustments</c>
		/// because it would retrieve all zeroes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-haskerningpairs bool HasKerningPairs();
		[PreserveSig]
		new bool HasKerningPairs();

		/// <summary>Determines the recommended rendering mode for the font, using the specified size and rendering parameters.</summary>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The number of physical pixels per DIP in a horizontal position. For example, if the DPI of the rendering surface is 96, this
		/// value is 1.0f. If the DPI is 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The number of physical pixels per DIP in a vertical position. For example, if the DPI of the rendering surface is 96, this value
		/// is 1.0f. If the DPI is 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const DWRITE_MATRIX*</b></para>
		/// <para>Specifies the world transform.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Whether the glyphs in the run are sideways or not.</para>
		/// </param>
		/// <param name="outlineThreshold">
		/// <para>Type: <b><c>DWRITE_OUTLINE_THRESHOLD</c></b></para>
		/// <para>
		/// A <c>DWRITE_OUTLINE_THRESHOLD</c>-typed value that specifies the quality of the graphics system's outline rendering, affects the
		/// size threshold above which outline rendering is used.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// The measuring method that will be used for glyphs in the font. Renderer implementations may choose different rendering modes for
		/// different measuring methods, for example:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL for <c>DWRITE_MEASURING_MODE_NATURAL</c></description>
		/// </item>
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC for <c>DWRITE_MEASURING_MODE_GDI_CLASSIC</c></description>
		/// </item>
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL for <c>DWRITE_MEASURING_MODE_GDI_NATURAL</c></description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c>*</b></para>
		/// <para>When this method returns, contains a value that indicates the recommended rendering mode to use.</para>
		/// </returns>
		/// <remarks>
		/// This method should be used to determine the actual rendering mode in cases where the rendering mode of the rendering params
		/// object is DWRITE_RENDERING_MODE_DEFAULT.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( FLOAT fontEmSize, FLOAT dpiX, FLOAT dpiY, [in, optional] DWRITE_MATRIX const *transform, bool
		// isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode, [out] DWRITE_RENDERING_MODE
		// *renderingMode );
		new DWRITE_RENDERING_MODE GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			bool isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode);

		/// <summary>Retrieves the vertical forms of the nominal glyphs retrieved from GetGlyphIndices.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of glyphs to retrieve.</para>
		/// </param>
		/// <param name="nominalGlyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>Original glyph indices from cmap.</para>
		/// </param>
		/// <param name="verticalGlyphIndices">
		/// <para>Type: <b>UINT16*</b></para>
		/// <para>The vertical form of glyph indices.</para>
		/// </param>
		/// <remarks>
		/// <para>The retrieval uses the font's 'vert' table. This is used in CJK vertical layout so the correct characters are shown.</para>
		/// <para>
		/// Call <c>GetGlyphIndices</c> to get the nominal glyph indices, followed by calling this to remap the to the substituted forms,
		/// when the run is sideways, and the font has vertical glyph variants. See <c>HasVerticalGlyphVariants</c> for more info.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getverticalglyphvariants HRESULT
		// GetVerticalGlyphVariants( UINT32 glyphCount, [in] UINT16 const *nominalGlyphIndices, [out] UINT16 *verticalGlyphIndices );
		new void GetVerticalGlyphVariants(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] nominalGlyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] verticalGlyphIndices);

		/// <summary>Determines whether the font has any vertical glyph variants.</summary>
		/// <returns>Returns TRUE if the font contains vertical glyph variants, otherwise FALSE.</returns>
		/// <remarks>
		/// <para>For OpenType fonts, <b>HasVerticalGlyphVariants</b> returns TRUE if the font contains a "vert"feature.</para>
		/// <para>
		/// <c>IDWriteFontFace1::GetVerticalGlyphVariants</c> retrieves the vertical forms of the nominal glyphs that are retrieved from <c>IDWriteFontFace::GetGlyphIndices</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-hasverticalglyphvariants bool HasVerticalGlyphVariants();
		[PreserveSig]
		new bool HasVerticalGlyphVariants();

		/// <summary>Allows you to determine if a color rendering path is potentially necessary.</summary>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns <b>TRUE</b> if a color rendering path is potentially necessary.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-iscolorfont bool IsColorFont();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsColorFont();

		/// <summary>Gets the number of color palettes defined by the font.</summary>
		/// <returns>
		/// The return value is zero if the font has no color information. Color fonts are required to define at least one palette, with
		/// palette index zero reserved as the default palette.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getcolorpalettecount UINT32 GetColorPaletteCount();
		[PreserveSig]
		new uint GetColorPaletteCount();

		/// <summary>Get the number of entries in each color palette.</summary>
		/// <returns>
		/// The number of entries in each color palette. All color palettes in a font have the same number of palette entries. The return
		/// value is zero if the font has no color information.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getpaletteentrycount UINT32 GetPaletteEntryCount();
		[PreserveSig]
		new uint GetPaletteEntryCount();

		/// <summary>Gets color values from the font's color palette.</summary>
		/// <param name="colorPaletteIndex">
		/// Zero-based index of the color palette. If the font does not have a palette with the specified index, the method returns <b>DWRITE_E_NOCOLOR</b>.
		/// </param>
		/// <param name="firstEntryIndex">Zero-based index of the first palette entry to read.</param>
		/// <param name="entryCount">Number of palette entries to read.</param>
		/// <param name="paletteEntries">Array that receives the color values.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// The sum of <i>firstEntryIndex</i> and <i>entryCount</i> is greater than the actual number of palette entries that's returned by
		/// the <c>GetPaletteEntryCount</c> method.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DWRITE_E_NOCOLOR</description>
		/// <description>The font doesn't have a palette with the specified palette index.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getpaletteentries HRESULT
		// GetPaletteEntries( UINT32 colorPaletteIndex, UINT32 firstEntryIndex, UINT32 entryCount, [out] DWRITE_COLOR_F *paletteEntries );
		[PreserveSig]
		new HRESULT GetPaletteEntries(uint colorPaletteIndex, uint firstEntryIndex, uint entryCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_COLOR_F[] paletteEntries);

		/// <summary>
		/// Determines the recommended text rendering and grid-fit mode to be used based on the font, size, world transform, and measuring mode.
		/// </summary>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Logical font size in DIPs.</para>
		/// </param>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the horizontal direction.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the vertical direction.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>A <c>DWRITE_MATRIX</c> structure that describes the world transform.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Specifies whether the font is sideways. <b>TRUE</b> if the font is sideways; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <param name="outlineThreshold">
		/// <para>Type: <b><c>DWRITE_OUTLINE_THRESHOLD</c></b></para>
		/// <para>
		/// A <c>DWRITE_OUTLINE_THRESHOLD</c>-typed value that specifies the quality of the graphics system's outline rendering, affects the
		/// size threshold above which outline rendering is used.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_MEASURING_MODE</c>-typed value that specifies the method used to measure during text layout. For proper glyph
		/// spacing, this method returns a rendering mode that is compatible with the specified measuring mode.
		/// </para>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <b><c>IDWriteRenderingParams</c>*</b></para>
		/// <para>
		/// A pointer to a <c>IDWriteRenderingParams</c> interface for the rendering parameters object. This parameter is necessary in case
		/// the rendering parameters object overrides the rendering mode.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_RENDERING_MODE</c>-typed value for the recommended rendering mode.</para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_GRID_FIT_MODE</c>-typed value for the recommended grid-fit mode.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( [in] FLOAT fontEmSize, [in] FLOAT dpiX, [in] FLOAT dpiY, [in, optional] DWRITE_MATRIX const
		// *transform, [in] bool isSideways, [in] DWRITE_OUTLINE_THRESHOLD outlineThreshold, [in] DWRITE_MEASURING_MODE measuringMode, [in,
		// optional] IDWriteRenderingParams *renderingParams, [out] DWRITE_RENDERING_MODE *renderingMode, [out] DWRITE_GRID_FIT_MODE
		// *gridFitMode );
		new void GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			bool isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode, [In, Optional] IDWriteRenderingParams? renderingParams,
			out DWRITE_RENDERING_MODE renderingMode, out DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary>Gets a font face reference that identifies this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteFontFaceReference</c> interface for the newly created font
		/// face reference object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getfontfacereference HRESULT
		// GetFontFaceReference( [out] IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference GetFontFaceReference();

		/// <summary>Gets the PANOSE values from the font, used for font selection and matching.</summary>
		/// <param name="panose">
		/// <para>Type: <b><c>DWRITE_PANOSE</c>*</b></para>
		/// <para>A pointer to a <c>DWRITE_PANOSE</c> structure that receives the PANOSE values from the font.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't simulate these values, such as substituting a weight or proportion inferred on other values. If the font
		/// doesn't specify them, they are all set to 'any' (0).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getpanose void GetPanose( [out]
		// DWRITE_PANOSE *panose );
		[PreserveSig]
		new void GetPanose(out DWRITE_PANOSE panose);

		/// <summary>Gets the weight of this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_WEIGHT</c></b></para>
		/// <para>
		/// Returns a <c>DWRITE_FONT_WEIGHT</c>-typed value that specifies the density of a typeface, in terms of the lightness or heaviness
		/// of the strokes.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getweight DWRITE_FONT_WEIGHT GetWeight();
		[PreserveSig]
		new DWRITE_FONT_WEIGHT GetWeight();

		/// <summary>Gets the stretch (also known as width) of this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_STRETCH</c></b></para>
		/// <para>
		/// Returns a <c>DWRITE_FONT_STRETCH</c>-typed value that specifies the degree to which a font has been stretched compared to a
		/// font's normal aspect ratio.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getstretch DWRITE_FONT_STRETCH GetStretch();
		[PreserveSig]
		new DWRITE_FONT_STRETCH GetStretch();

		/// <summary>Gets the style (also known as slope) of this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_STYLE</c></b></para>
		/// <para>Returns a <c>DWRITE_FONT_STYLE</c>-typed value that specifies the style of the font.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getstyle DWRITE_FONT_STYLE GetStyle();
		[PreserveSig]
		new DWRITE_FONT_STYLE GetStyle();

		/// <summary>Creates a localized strings object that contains the family names for the font family, indexed by locale name.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteLocalizedStrings</c> interface for the newly created
		/// localized strings object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getfamilynames HRESULT GetFamilyNames(
		// [out] IDWriteLocalizedStrings **names );
		new IDWriteLocalizedStrings GetFamilyNames();

		/// <summary>
		/// Creates a localized strings object that contains the face names for the font (for example, Regular or Bold), indexed by locale name.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteLocalizedStrings</c> interface for the newly created
		/// localized strings object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getfacenames HRESULT GetFaceNames(
		// [out] IDWriteLocalizedStrings **names );
		new IDWriteLocalizedStrings GetFaceNames();

		/// <summary>Gets a localized strings collection that contains the specified informational strings, indexed by locale name.</summary>
		/// <param name="informationalStringID">
		/// <para>Type: <b><c>DWRITE_INFORMATIONAL_STRING_ID</c></b></para>
		/// <para>A <c>DWRITE_INFORMATIONAL_STRING_ID</c>-typed value that identifies the strings to get.</para>
		/// </param>
		/// <param name="informationalStrings">
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteLocalizedStrings</c> interface for the newly created
		/// localized strings object.
		/// </para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>
		/// A pointer to a variable that receives whether the font contains the specified string ID. <b>TRUE</b> if the font contains the
		/// specified string ID; otherwise, <b>FALSE</b>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>
		/// If the font doesn't contain the specified string, the return value is S_OK, but <i>informationalStrings</i> receives a
		/// <b>NULL</b> pointer and <i>exists</i> receives the value <b>FALSE</b>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getinformationalstrings HRESULT
		// GetInformationalStrings( [in] DWRITE_INFORMATIONAL_STRING_ID informationalStringID, [out] IDWriteLocalizedStrings
		// **informationalStrings, [out] BOOL *exists );
		new void GetInformationalStrings(DWRITE_INFORMATIONAL_STRING_ID informationalStringID, out IDWriteLocalizedStrings? informationalStrings,
			[MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Determines whether the font supports the specified character.</summary>
		/// <param name="unicodeValue">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>A Unicode (UCS-4) character value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>
		/// Returns whether the font supports the specified character. Returns <b>TRUE</b> if the font has the specified character;
		/// otherwise, <b>FALSE</b>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-hascharacter BOOL HasCharacter( [in]
		// UINT32 unicodeValue );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool HasCharacter(uint unicodeValue);

		/// <summary>
		/// Determines the recommended text rendering and grid-fit mode to be used based on the font, size, world transform, and measuring mode.
		/// </summary>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Logical font size in DIPs.</para>
		/// </param>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the horizontal direction.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the vertical direction.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>A <c>DWRITE_MATRIX</c> structure that describes the world transform.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies whether the font is sideways. <b>TRUE</b> if the font is sideways; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <param name="outlineThreshold">
		/// <para>Type: <b><c>DWRITE_OUTLINE_THRESHOLD</c></b></para>
		/// <para>
		/// A <c>DWRITE_OUTLINE_THRESHOLD</c>-typed value that specifies the quality of the graphics system's outline rendering, affects the
		/// size threshold above which outline rendering is used.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_MEASURING_MODE</c>-typed value that specifies the method used to measure during text layout. For proper glyph
		/// spacing, this method returns a rendering mode that is compatible with the specified measuring mode.
		/// </para>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <b><c>IDWriteRenderingParams</c>*</b></para>
		/// <para>
		/// A pointer to a <c>IDWriteRenderingParams</c> interface for the rendering parameters object. This parameter is necessary in case
		/// the rendering parameters object overrides the rendering mode.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_RENDERING_MODE1</c>-typed value for the recommended rendering mode.</para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_GRID_FIT_MODE</c>-typed value for the recommended grid-fit mode.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( [in] FLOAT fontEmSize, [in] FLOAT dpiX, [in] FLOAT dpiY, [in, optional] DWRITE_MATRIX const
		// *transform, [in] BOOL isSideways, [in] DWRITE_OUTLINE_THRESHOLD outlineThreshold, [in] DWRITE_MEASURING_MODE measuringMode, [in,
		// optional] IDWriteRenderingParams *renderingParams, [out] DWRITE_RENDERING_MODE1 *renderingMode, [out] DWRITE_GRID_FIT_MODE
		// *gridFitMode );
		new void GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			bool isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode,
			[In, Optional] IDWriteRenderingParams? renderingParams, out DWRITE_RENDERING_MODE1 renderingMode, out DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary><c>unicodeValue</c></summary>
		/// <param name="unicodeValue"/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontface3-ischaracterlocal BOOL
		// IsCharacterLocal( UINT32 unicodeValue );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsCharacterLocal(uint unicodeValue);

		/// <summary>Determines whether the glyph is locally downloaded from the font.</summary>
		/// <param name="glyphId">
		/// <para>Type: <b>UINT16</b></para>
		/// <para>Glyph identifier.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Returns TRUE if the font has the specified glyph locally available.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-isglyphlocal BOOL IsGlyphLocal( [in]
		// UINT16 glyphId );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsGlyphLocal(ushort glyphId);

		/// <summary>Determines whether the specified characters are local.</summary>
		/// <param name="characters">
		/// <para>Type: <b>WCHAR</b></para>
		/// <para>Array of characters.</para>
		/// </param>
		/// <param name="characterCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of elements in the character array.</para>
		/// </param>
		/// <param name="enqueueIfNotLocal">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies whether to enqueue a download request if any of the specified characters are not local.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if all of the specified characters are local, FALSE if any of the specified characters are remote.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-arecharacterslocal HRESULT
		// AreCharactersLocal( [in] WCHAR const *characters, UINT32 characterCount, BOOL enqueueIfNotLocal, [out] BOOL *isLocal );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool AreCharactersLocal([MarshalAs(UnmanagedType.LPWStr)] string characters, uint characterCount, bool enqueueIfNotLocal);

		/// <summary>Determines whether the specified glyphs are local.</summary>
		/// <param name="glyphIndices">
		/// <para>Type: <b>UINT16</b></para>
		/// <para>Array of glyph indices.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of elements in the glyph index array.</para>
		/// </param>
		/// <param name="enqueueIfNotLocal">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies whether to enqueue a download request if any of the specified glyphs are not local.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if all of the specified glyphs are local, FALSE if any of the specified glyphs are remote.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-areglyphslocal HRESULT AreGlyphsLocal(
		// [in] UINT16 const *glyphIndices, UINT32 glyphCount, BOOL enqueueIfNotLocal, [out] BOOL *isLocal );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool AreGlyphsLocal([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices, uint glyphCount, bool enqueueIfNotLocal);

		/// <summary>Gets all the glyph image formats supported for the specified glyph.</summary>
		/// <param name="glyphId">The identifier of the glyph to be queried.</param>
		/// <param name="pixelsPerEmFirst">The lowest pixels per em value to query.</param>
		/// <param name="pixelsPerEmLast">The highest pixels per em value to query.</param>
		/// <returns>An array of <c>DWRITE_GLYPH_IMAGE_FORMATS</c> specifying the supported formats for the requested glyph.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface4-getglyphimageformats(uint16_uint32_uint32_dwrite_glyph_image_formats)
		// HRESULT GetGlyphImageFormats( UINT16 glyphId, UINT32 pixelsPerEmFirst, UINT32 pixelsPerEmLast, DWRITE_GLYPH_IMAGE_FORMATS
		// *glyphImageFormats );
		DWRITE_GLYPH_IMAGE_FORMATS GetGlyphImageFormats(ushort glyphId, uint pixelsPerEmFirst, uint pixelsPerEmLast);

		/// <summary>Gets all the glyph image formats supported by the entire font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_FORMATS</c></b></para>
		/// <para>Returns all the glyph image formats supported by the entire font.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface4-getglyphimageformats
		// DWRITE_GLYPH_IMAGE_FORMATS GetGlyphImageFormats();
		[PreserveSig]
		DWRITE_GLYPH_IMAGE_FORMATS GetGlyphImageFormats();

		/// <summary>Gets a pointer to the glyph data based on the desired image format.</summary>
		/// <param name="glyphId">
		/// <para>Type: <b>UINT16</b></para>
		/// <para>The ID of the glyph to retrieve image data for.</para>
		/// </param>
		/// <param name="pixelsPerEm">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Requested pixels per em.</para>
		/// </param>
		/// <param name="glyphImageFormat">
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_FORMATS</c></b></para>
		/// <para>Specifies which formats are supported in the font.</para>
		/// </param>
		/// <param name="glyphData">
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_DATA</c>*</b></para>
		/// <para>On return contains data for a glyph.</para>
		/// </param>
		/// <param name="glyphDataContext">Type: <b>void**</b></param>
		/// <remarks>
		/// <para>
		/// The glyphDataContext must be released via <c>ReleaseGlyphImageData</c> when done if the data is not empty, similar to
		/// <c>IDWriteFontFileStream::ReadFileFragment</c> and <c>IDWriteFontFileStream::ReleaseFileFragment</c>. The data pointer is valid
		/// so long as the <c>IDWriteFontFace</c> exists and <b>ReleaseGlyphImageData</b> has not been called.
		/// </para>
		/// <para>
		/// The <c>DWRITE_GLYPH_IMAGE_DATA::uniqueDataId</c> is valuable for caching purposes so that if the same resource is returned more
		/// than once, an existing resource can be quickly retrieved rather than needing to reparse or decompress the data.
		/// </para>
		/// <para>
		/// The function only returns SVG or raster data - requesting TrueType/CFF/COLR data returns DWRITE_E_INVALIDARG. Those must be
		/// drawn via DrawGlyphRun or queried using GetGlyphOutline instead. Exactly one format may be requested or else the function
		/// returns DWRITE_E_INVALIDARG. If the glyph does not have that format, the call is not an error, but the function returns empty data.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface4-getglyphimagedata HRESULT
		// GetGlyphImageData( [in] UINT16 glyphId, UINT32 pixelsPerEm, DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat, [out]
		// DWRITE_GLYPH_IMAGE_DATA *glyphData, [out] void **glyphDataContext );
		void GetGlyphImageData(ushort glyphId, uint pixelsPerEm, DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat, out DWRITE_GLYPH_IMAGE_DATA glyphData,
			out IntPtr glyphDataContext);

		/// <summary>Releases the table data obtained from ReadGlyphData.</summary>
		/// <param name="glyphDataContext">
		/// <para>Type: <b>void*</b></para>
		/// <para>Opaque context from ReadGlyphData.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface4-releaseglyphimagedata void
		// ReleaseGlyphImageData( void *glyphDataContext );
		[PreserveSig]
		void ReleaseGlyphImageData([In] IntPtr glyphDataContext);
	}

	/// <summary>
	/// <para>
	/// Represents an absolute reference to a font face. This interface contains font face type, appropriate file references, and face
	/// identification data. It adds new facilities such as comparing two font faces, retrieving font axis values, and retrieving the
	/// underlying font resource.
	/// </para>
	/// <para>
	/// This interface extends <c>IDWriteFontFace4</c>. Various font data such as metrics, names, and glyph outlines are obtained from <b>IDWriteFontFace</b>.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontface5
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontFace5")]
	[ComImport, Guid("98EFF3A5-B667-479A-B145-E2FA5B9FDC29"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontFace5 : IDWriteFontFace, IDWriteFontFace1, IDWriteFontFace2, IDWriteFontFace3, IDWriteFontFace4
	{
		/// <summary>Obtains the file format type of a font face.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_FACE_TYPE</c></para>
		/// <para>A value that indicates the type of format for the font face (such as Type 1, TrueType, vector, or bitmap).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-gettype DWRITE_FONT_FACE_TYPE GetType();
		[PreserveSig]
		new DWRITE_FONT_FACE_TYPE GetType();

		/// <summary>Obtains the font files representing a font face.</summary>
		/// <param name="numberOfFiles">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// If fontFiles is <c>NULL</c>, receives the number of files representing the font face. Otherwise, the number of font files being
		/// requested should be passed. See the Remarks section below for more information.
		/// </para>
		/// </param>
		/// <param name="fontFiles">
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a user-provided array that stores pointers to font files representing the font
		/// face. This parameter can be <c>NULL</c> if the user wants only the number of files representing the font face. This API
		/// increments reference count of the font file pointers returned according to COM conventions, and the client should release them
		/// when finished.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The <c>IDWriteFontFace::GetFiles</c> method should be called twice. The first time you call <c>GetFiles</c> fontFiles should be
		/// <c>NULL</c>. When the method returns, numberOfFiles receives the number of font files that represent the font face.
		/// </para>
		/// <para>
		/// Then, call the method a second time, passing the numberOfFiles value that was output the first call, and a non-null buffer of
		/// the correct size to store the IDWriteFontFile pointers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getfiles HRESULT GetFiles( UINT32
		// *numberOfFiles, IDWriteFontFile **fontFiles );
		new void GetFiles(ref uint numberOfFiles, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] IDWriteFontFile[]? fontFiles);

		/// <summary>Obtains the index of a font face in the context of its font files.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The zero-based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value is zero.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getindex UINT32 GetIndex();
		[PreserveSig]
		new uint GetIndex();

		/// <summary>Obtains the algorithmic style simulation flags of a font face.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>Font face simulation flags for algorithmic means of making text bold or italic.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getsimulations DWRITE_FONT_SIMULATIONS GetSimulations();
		[PreserveSig]
		new DWRITE_FONT_SIMULATIONS GetSimulations();

		/// <summary>Determines whether the font is a symbol font.</summary>
		/// <returns>
		/// <para>Type: <c>bool</c></para>
		/// <para>Returns <c>TRUE</c> if the font is a symbol font, otherwise <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-issymbolfont bool IsSymbolFont();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsSymbolFont();

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a font face and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="fontFaceMetrics">
		/// <para>Type: <c>DWRITE_FONT_METRICS*</c></para>
		/// <para>
		/// When this method returns, a DWRITE_FONT_METRICS structure that holds metrics (such as ascent, descent, or cap height) for the
		/// current font face element. The metrics returned by this function are in font design units.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getmetrics void GetMetrics(
		// DWRITE_FONT_METRICS *fontFaceMetrics );
		[PreserveSig]
		new void GetMetrics(out DWRITE_FONT_METRICS fontFaceMetrics);

		/// <summary>Obtains the number of glyphs in the font face.</summary>
		/// <returns>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>The number of glyphs in the font face.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphcount UINT16 GetGlyphCount();
		[PreserveSig]
		new ushort GetGlyphCount();

		/// <summary>Obtains ideal (resolution-independent) glyph metrics in font design units.</summary>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>
		/// An array of glyph indices for which to compute metrics. The array must contain at least as many elements as specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the glyphIndices array.</para>
		/// </param>
		/// <param name="glyphMetrics">
		/// <para>Type: <c>DWRITE_GLYPH_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains an array of DWRITE_GLYPH_METRICS structures. glyphMetrics must be initialized with an empty
		/// buffer that contains at least as many elements as glyphCount. The metrics returned by this function are in font design units.
		/// </para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// Indicates whether the font is being used in a sideways run. This can affect the glyph metrics if the font has oblique simulation
		/// because sideways oblique simulation differs from non-sideways oblique simulation
		/// </para>
		/// </param>
		/// <remarks>Design glyph metrics are used for glyph positioning.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getdesignglyphmetrics HRESULT
		// GetDesignGlyphMetrics( UINT16 const *glyphIndices, UINT32 glyphCount, DWRITE_GLYPH_METRICS *glyphMetrics, bool isSideways );
		new void GetDesignGlyphMetrics([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices, uint glyphCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_GLYPH_METRICS[] glyphMetrics, [MarshalAs(UnmanagedType.Bool)] bool isSideways = false);

		/// <summary>Returns the nominal mapping of UCS4 Unicode code points to glyph indices as defined by the font 'CMAP' table.</summary>
		/// <param name="codePoints">
		/// <para>Type: <c>const UINT32*</c></para>
		/// <para>
		/// An array of USC4 code points from which to obtain nominal glyph indices. The array must be allocated and be able to contain the
		/// number of elements specified by codePointCount.
		/// </para>
		/// </param>
		/// <param name="codePointCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the codePoints array.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>UINT16*</c></para>
		/// <para>When this method returns, contains a pointer to an array of nominal glyph indices filled by this function.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Note that this mapping is primarily provided for line layout engines built on top of the physical font API. Because of OpenType
		/// glyph substitution and line layout character substitution, the nominal conversion does not always correspond to how a Unicode
		/// string will map to glyph indices when rendering using a particular font face. Also, note that Unicode variant selectors provide
		/// for alternate mappings for character to glyph. This call will always return the default variant.
		/// </para>
		/// <para>
		/// When characters are not present in the font this method returns the index 0, which is the undefined glyph or ".notdef" glyph. If
		/// a character isn't in a font, IDWriteFont::HasCharacter returns false and GetUnicodeRanges doesn't return it in the range.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphindices HRESULT GetGlyphIndices(
		// UINT32 const *codePoints, UINT32 codePointCount, UINT16 *glyphIndices );
		new void GetGlyphIndices([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] codePoints, uint codePointCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices);

		/// <summary>
		/// Finds the specified OpenType font table if it exists and returns a pointer to it. The function accesses the underlying font data
		/// through the IDWriteFontFileStream interface implemented by the font file loader.
		/// </summary>
		/// <param name="openTypeTableTag">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The four-character tag of a OpenType font table to find. Use the <c>DWRITE_MAKE_OPENTYPE_TAG</c> macro to create it as an
		/// <c>UINT32</c>. Unlike GDI, it does not support the special TTCF and null tags to access the whole font.
		/// </para>
		/// </param>
		/// <param name="tableData">
		/// <para>Type: <c>const void**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the base of the table in memory. The pointer is valid only as
		/// long as the font face used to get the font table still exists; (not any other font face, even if it actually refers to the same
		/// physical font). This parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <param name="tableSize">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains a pointer to the size, in bytes, of the font table.</para>
		/// </param>
		/// <param name="tableContext">
		/// <para>Type: <c>void**</c></para>
		/// <para>
		/// When this method returns, the address of a pointer to the opaque context, which must be freed by calling ReleaseFontTable. The
		/// context actually comes from the lower-level IDWriteFontFileStream, which may be implemented by the application or DWrite itself.
		/// It is possible for a <c>NULL</c> tableContext to be returned, especially if the implementation performs direct memory mapping on
		/// the whole file. Nevertheless, always release it later, and do not use it as a test for function success. The same table can be
		/// queried multiple times, but because each returned context can be different, you must release each context separately.
		/// </para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <c>bool*</c></para>
		/// <para>When this method returns, <c>TRUE</c> if the font table exists; otherwise, <c>FALSE</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The context for the same tag may be different for each call, so each one must be held and released separately.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-trygetfonttable HRESULT TryGetFontTable(
		// UINT32 openTypeTableTag, const void **tableData, UINT32 *tableSize, void **tableContext, bool *exists );
		new HRESULT TryGetFontTable([In] uint openTypeTableTag, out IntPtr tableData, out uint tableSize, out IntPtr tableContext, [MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Releases the table obtained earlier from TryGetFontTable.</summary>
		/// <param name="tableContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>A pointer to the opaque context from TryGetFontTable.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-releasefonttable void ReleaseFontTable( void
		// *tableContext );
		[PreserveSig]
		new void ReleaseFontTable([In] IntPtr tableContext);

		/// <summary>Computes the outline of a run of glyphs by calling back to the outline sink interface.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>
		/// An array of glyph indices. The glyphs are in logical order and the advance direction depends on the isRightToLeft parameter. The
		/// array must be allocated and be able to contain the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <c>const FLOAT*</c></para>
		/// <para>
		/// An optional array of glyph advances in DIPs. The advance of a glyph is the amount to advance the position (in the direction of
		/// the baseline) after drawing the glyph. glyphAdvances contains the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphOffsets">
		/// <para>Type: <c>const DWRITE_GLYPH_OFFSET*</c></para>
		/// <para>
		/// An optional array of glyph offsets, each of which specifies the offset along the baseline and offset perpendicular to the
		/// baseline of a glyph relative to the current pen position. glyphOffsets contains the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of glyphs in the run.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// If <c>TRUE</c>, the ascender of the glyph runs alongside the baseline. If <c>FALSE</c>, the glyph ascender runs perpendicular to
		/// the baseline. For example, an English alphabet on a vertical baseline would have isSideways set to <c>FALSE</c>.
		/// </para>
		/// <para>
		/// A client can render a vertical run by setting isSideways to <c>TRUE</c> and rotating the resulting geometry 90 degrees to the
		/// right using a transform. The isSideways and isRightToLeft parameters cannot both be true.
		/// </para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// The visual order of the glyphs. If this parameter is <c>FALSE</c>, then glyph advances are from left to right. If <c>TRUE</c>,
		/// the advance direction is right to left. By default, the advance direction is left to right.
		/// </para>
		/// </param>
		/// <param name="geometrySink">
		/// <para>Type: <c>IDWriteGeometrySink*</c></para>
		/// <para>A pointer to the interface that is called back to perform outline drawing operations.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphrunoutline HRESULT
		// GetGlyphRunOutline( FLOAT emSize, UINT16 const *glyphIndices, FLOAT const *glyphAdvances, DWRITE_GLYPH_OFFSET const
		// *glyphOffsets, UINT32 glyphCount, bool isSideways, bool isRightToLeft, IDWriteGeometrySink *geometrySink );
		new void GetGlyphRunOutline(float emSize, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ushort[] glyphIndices,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[]? glyphAdvances,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_GLYPH_OFFSET[]? glyphOffsets,
			uint glyphCount, [MarshalAs(UnmanagedType.Bool)] bool isSideways, [MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
			[In, MarshalAs(UnmanagedType.Interface)] object geometrySink);

		/// <summary>Determines the recommended rendering mode for the font, using the specified size and rendering parameters.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96, this value is 1.0f. If the DPI is
		/// 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>
		/// The measuring method that will be used for glyphs in the font. Renderer implementations may choose different rendering modes for
		/// different measuring methods, for example:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL for DWRITE_MEASURING_MODE_NATURAL</term>
		/// </item>
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC for DWRITE_MEASURING_MODE_GDI_CLASSIC</term>
		/// </item>
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL for DWRITE_MEASURING_MODE_GDI_NATURAL</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>
		/// A pointer to an object that contains rendering settings such as gamma level, enhanced contrast, and ClearType level. This
		/// parameter is necessary in case the rendering parameters object overrides the rendering mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWRITE_RENDERING_MODE*</c></para>
		/// <para>When this method returns, contains a value that indicates the recommended rendering mode to use.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MEASURING_MODE measuringMode, IDWriteRenderingParams
		// *renderingParams, DWRITE_RENDERING_MODE *renderingMode );
		new DWRITE_RENDERING_MODE GetRecommendedRenderingMode(float emSize, float pixelsPerDip, DWRITE_MEASURING_MODE measuringMode, IDWriteRenderingParams renderingParams);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a fontface and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_METRICS*</c></para>
		/// <para>A pointer to a DWRITE_FONT_METRICS structure to fill in. The metrics returned by this function are in font design units.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getgdicompatiblemetrics HRESULT
		// GetGdiCompatibleMetrics( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, DWRITE_FONT_METRICS
		// *fontFaceMetrics );
		new DWRITE_FONT_METRICS GetGdiCompatibleMetrics(float emSize, float pixelsPerDip, [In, Optional] IntPtr transform);

		/// <summary>Obtains glyph metrics in font design units with the return values compatible with what GDI would produce.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The ogical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// When set to <c>FALSE</c>, the metrics are the same as the metrics of GDI aliased text. When set to <c>TRUE</c>, the metrics are
		/// the same as the metrics of text measured by GDI using a font created with <c>CLEARTYPE_NATURAL_QUALITY</c>.
		/// </para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>An array of glyph indices for which to compute the metrics.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the glyphIndices array.</para>
		/// </param>
		/// <param name="glyphMetrics">
		/// <para>Type: <c>DWRITE_GLYPH_METRICS*</c></para>
		/// <para>An array of DWRITE_GLYPH_METRICS structures filled by this function. The metrics are in font design units.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// A bool value that indicates whether the font is being used in a sideways run. This can affect the glyph metrics if the font has
		/// oblique simulation because sideways oblique simulation differs from non-sideways oblique simulation.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getgdicompatibleglyphmetrics HRESULT
		// GetGdiCompatibleGlyphMetrics( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, bool useGdiNatural, UINT16 const
		// *glyphIndices, UINT32 glyphCount, DWRITE_GLYPH_METRICS *glyphMetrics, bool isSideways );
		new void GetGdiCompatibleGlyphMetrics(float emSize, float pixelsPerDip, [In, Optional] IntPtr transform, [MarshalAs(UnmanagedType.Bool)] bool useGdiNatural,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ushort[] glyphIndices, uint glyphCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] DWRITE_GLYPH_METRICS[] glyphMetrics, [MarshalAs(UnmanagedType.Bool)] bool isSideways = false);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a font face and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="fontMetrics">
		/// <para>Type: <b><c>DWRITE_FONT_METRICS1</c>*</b></para>
		/// <para>
		/// A filled <c>DWRITE_FONT_METRICS1</c> structure that holds metrics for the current font face element. The metrics returned by
		/// this method are in font design units.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getmetrics void GetMetrics( [out]
		// DWRITE_FONT_METRICS1 *fontMetrics );
		[PreserveSig]
		new void GetMetrics(out DWRITE_FONT_METRICS1 fontMetrics);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a fontface and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="emSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The logical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and <i>pixelsPerDip</i>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_METRICS1</c>*</b></para>
		/// <para>
		/// A pointer to a <c>DWRITE_FONT_METRICS1</c> structure to fill in. The metrics returned by this function are in font design units.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getgdicompatiblemetrics HRESULT
		// GetGdiCompatibleMetrics( FLOAT emSize, FLOAT pixelsPerDip, [in, optional] DWRITE_MATRIX const *transform, [out]
		// DWRITE_FONT_METRICS1 *fontMetrics );
		new DWRITE_FONT_METRICS1 GetGdiCompatibleMetrics(float emSize, float pixelsPerDip, [In, Optional] StructPointer<DWRITE_MATRIX> transform);

		/// <summary>Gets caret metrics for the font in design units.</summary>
		/// <param name="caretMetrics">
		/// <para>Type: <b>DWRITE_CARET_METRICS*</b></para>
		/// <para>A pointer to the <c>DWRITE_CARET_METRICS</c> structure that is filled.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>Caret metrics are used by text editors for drawing the correct caret placement and slant.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getcaretmetrics void GetCaretMetrics(
		// [out] DWRITE_CARET_METRICS *caretMetrics );
		[PreserveSig]
		new void GetCaretMetrics(out DWRITE_CARET_METRICS caretMetrics);

		/// <summary>Retrieves a list of character ranges supported by a font.</summary>
		/// <param name="maxRangeCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Maximum number of character ranges passed in from the client.</para>
		/// </param>
		/// <param name="unicodeRanges">
		/// <para>Type: <b><c>DWRITE_UNICODE_RANGE</c>*</b></para>
		/// <para>An array of <c>DWRITE_UNICODE_RANGE</c> structures that are filled with the character ranges.</para>
		/// </param>
		/// <param name="actualRangeCount">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>A pointer to the actual number of character ranges, regardless of the maximum count.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// A list of character ranges supported by the font is useful for scenarios like character picking, glyph display, and efficient
		/// font selection lookup. This is similar to GDI's <c>GetFontUnicodeRanges</c>, except that it returns the full Unicode range, not
		/// just 16-bit UCS-2.
		/// </para>
		/// <para>These ranges are from the cmap, not the OS/2::ulCodePageRange1.</para>
		/// <para>
		/// If this method is unavailable, you can use the <c>IDWriteFontFace::GetGlyphIndices</c> method to check for missing glyphs. The
		/// method returns the 0 index for glyphs that aren't present in the font.
		/// </para>
		/// <para>
		/// The <c>IDWriteFont::HasCharacter</c> method is often simpler in cases where you need to check a single character or a series of
		/// single characters in succession, such as in font fallback.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getunicoderanges HRESULT
		// GetUnicodeRanges( UINT32 maxRangeCount, [out, optional] DWRITE_UNICODE_RANGE *unicodeRanges, [out] UINT32 *actualRangeCount );
		new void GetUnicodeRanges(int maxRangeCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DWRITE_UNICODE_RANGE[]? unicodeRanges, out uint actualRangeCount);

		/// <summary>
		/// Determines whether the font of a text range is monospaced, that is, the font characters are the same fixed-pitch width.
		/// </summary>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns TRUE if the font is monospaced, otherwise it returns FALSE.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-ismonospacedfont bool IsMonospacedFont();
		[PreserveSig]
		new bool IsMonospacedFont();

		/// <summary>Retrieves the advances in design units for a sequences of glyphs.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of glyphs to retrieve advances for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve advances for.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <b>INT32*</b></para>
		/// <para>The returned advances in font design units for each glyph.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Retrieve the glyph's vertical advance height rather than horizontal advance widths.</para>
		/// </param>
		/// <remarks>This is equivalent to calling GetGlyphMetrics and using only the advance width and height.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getdesignglyphadvances HRESULT
		// GetDesignGlyphAdvances( UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvances, bool isSideways );
		new void GetDesignGlyphAdvances(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] glyphAdvances, bool isSideways = false);

		/// <summary>Returns the pixel-aligned advances for a sequences of glyphs.</summary>
		/// <param name="emSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// Number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96 this value is 1.0f. If the DPI is 120,
		/// this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the font
		/// size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// When FALSE, the metrics are the same as GDI aliased text (DWRITE_MEASURING_MODE_GDI_CLASSIC). When TRUE, the metrics are the
		/// same as those measured by GDI using a font using CLEARTYPE_NATURAL_QUALITY (DWRITE_MEASURING_MODE_GDI_NATURAL).
		/// </para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Retrieve the glyph's vertical advances rather than horizontal advances.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Total glyphs to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve advances.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <b>const INT32*</b></para>
		/// <para>The returned advances in font design units for each glyph.</para>
		/// </param>
		/// <remarks>
		/// <para>This is equivalent to calling <c>GetGdiCompatibleGlyphMetrics</c> and using only the advance width and height.</para>
		/// <para>Like <c>GetGdiCompatibleGlyphMetrics</c>, these are in design units, meaning they must be scaled down by DWRITE_FONT_METRICS::designUnitsPerEm.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getgdicompatibleglyphadvances HRESULT
		// GetGdiCompatibleGlyphAdvances( FLOAT emSize, FLOAT pixelsPerDip, [in, optional] DWRITE_MATRIX const *transform, bool
		// useGdiNatural, bool isSideways, UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvances );
		new void GetGdiCompatibleGlyphAdvances(float emSize, float pixelsPerDip, [In, Optional] StructPointer<DWRITE_MATRIX> transform, bool useGdiNatural,
			bool isSideways, int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] int[] glyphAdvances);

		/// <summary>Retrieves the kerning pair adjustments from the font's kern table.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Number of glyphs to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphAdvanceAdjustments">
		/// <para>Type: <b>INT32*</b></para>
		/// <para>The advances, returned in font design units, for each glyph. The last glyph adjustment is zero.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <b>GetKerningPairAdjustments</b> isn't a direct replacement for GDI's character based <c>GetKerningPairs</c>, but it serves the
		/// same role, without the client needing to cache them locally. <b>GetKerningPairAdjustments</b> also uses glyph id's directly
		/// rather than UCS-2 characters (how the kern table actually stores them), which avoids glyph collapse and ambiguity, such as the
		/// dash and hyphen, or space and non-breaking space.
		/// </para>
		/// <para>
		/// Newer fonts may have only GPOS kerning instead of the legacy pair-table kerning. Such fonts, like Gabriola, will only return 0's
		/// for adjustments. <b>GetKerningPairAdjustments</b> doesn't virtualize and flatten these GPOS entries into kerning pairs.
		/// </para>
		/// <para>
		/// You can realize a performance benefit by calling <c>IDWriteFontFace1::HasKerningPairs</c> to determine whether you need to call
		/// <b>GetKerningPairAdjustments</b>. If you previously called <b>IDWriteFontFace1::HasKerningPairs</b> and it returned FALSE, you
		/// can avoid calling <b>GetKerningPairAdjustments</b> because the font has no kerning pair-table entries. That is, in this
		/// situation, a call to <b>GetKerningPairAdjustments</b> would be a no-op.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getkerningpairadjustments HRESULT
		// GetKerningPairAdjustments( UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvanceAdjustments );
		new void GetKerningPairAdjustments(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] glyphAdvanceAdjustments);

		/// <summary>Determines whether the font supports pair-kerning.</summary>
		/// <returns>Returns TRUE if the font supports kerning pairs, otherwise FALSE.</returns>
		/// <remarks>
		/// If the font doesn't support pair table kerning, you don't need to call <c>IDWriteFontFace1::GetKerningPairAdjustments</c>
		/// because it would retrieve all zeroes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-haskerningpairs bool HasKerningPairs();
		[PreserveSig]
		new bool HasKerningPairs();

		/// <summary>Determines the recommended rendering mode for the font, using the specified size and rendering parameters.</summary>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The number of physical pixels per DIP in a horizontal position. For example, if the DPI of the rendering surface is 96, this
		/// value is 1.0f. If the DPI is 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The number of physical pixels per DIP in a vertical position. For example, if the DPI of the rendering surface is 96, this value
		/// is 1.0f. If the DPI is 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const DWRITE_MATRIX*</b></para>
		/// <para>Specifies the world transform.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Whether the glyphs in the run are sideways or not.</para>
		/// </param>
		/// <param name="outlineThreshold">
		/// <para>Type: <b><c>DWRITE_OUTLINE_THRESHOLD</c></b></para>
		/// <para>
		/// A <c>DWRITE_OUTLINE_THRESHOLD</c>-typed value that specifies the quality of the graphics system's outline rendering, affects the
		/// size threshold above which outline rendering is used.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// The measuring method that will be used for glyphs in the font. Renderer implementations may choose different rendering modes for
		/// different measuring methods, for example:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL for <c>DWRITE_MEASURING_MODE_NATURAL</c></description>
		/// </item>
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC for <c>DWRITE_MEASURING_MODE_GDI_CLASSIC</c></description>
		/// </item>
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL for <c>DWRITE_MEASURING_MODE_GDI_NATURAL</c></description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c>*</b></para>
		/// <para>When this method returns, contains a value that indicates the recommended rendering mode to use.</para>
		/// </returns>
		/// <remarks>
		/// This method should be used to determine the actual rendering mode in cases where the rendering mode of the rendering params
		/// object is DWRITE_RENDERING_MODE_DEFAULT.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( FLOAT fontEmSize, FLOAT dpiX, FLOAT dpiY, [in, optional] DWRITE_MATRIX const *transform, bool
		// isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode, [out] DWRITE_RENDERING_MODE
		// *renderingMode );
		new DWRITE_RENDERING_MODE GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			bool isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode);

		/// <summary>Retrieves the vertical forms of the nominal glyphs retrieved from GetGlyphIndices.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of glyphs to retrieve.</para>
		/// </param>
		/// <param name="nominalGlyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>Original glyph indices from cmap.</para>
		/// </param>
		/// <param name="verticalGlyphIndices">
		/// <para>Type: <b>UINT16*</b></para>
		/// <para>The vertical form of glyph indices.</para>
		/// </param>
		/// <remarks>
		/// <para>The retrieval uses the font's 'vert' table. This is used in CJK vertical layout so the correct characters are shown.</para>
		/// <para>
		/// Call <c>GetGlyphIndices</c> to get the nominal glyph indices, followed by calling this to remap the to the substituted forms,
		/// when the run is sideways, and the font has vertical glyph variants. See <c>HasVerticalGlyphVariants</c> for more info.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getverticalglyphvariants HRESULT
		// GetVerticalGlyphVariants( UINT32 glyphCount, [in] UINT16 const *nominalGlyphIndices, [out] UINT16 *verticalGlyphIndices );
		new void GetVerticalGlyphVariants(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] nominalGlyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] verticalGlyphIndices);

		/// <summary>Determines whether the font has any vertical glyph variants.</summary>
		/// <returns>Returns TRUE if the font contains vertical glyph variants, otherwise FALSE.</returns>
		/// <remarks>
		/// <para>For OpenType fonts, <b>HasVerticalGlyphVariants</b> returns TRUE if the font contains a "vert"feature.</para>
		/// <para>
		/// <c>IDWriteFontFace1::GetVerticalGlyphVariants</c> retrieves the vertical forms of the nominal glyphs that are retrieved from <c>IDWriteFontFace::GetGlyphIndices</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-hasverticalglyphvariants bool HasVerticalGlyphVariants();
		[PreserveSig]
		new bool HasVerticalGlyphVariants();

		/// <summary>Allows you to determine if a color rendering path is potentially necessary.</summary>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns <b>TRUE</b> if a color rendering path is potentially necessary.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-iscolorfont bool IsColorFont();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsColorFont();

		/// <summary>Gets the number of color palettes defined by the font.</summary>
		/// <returns>
		/// The return value is zero if the font has no color information. Color fonts are required to define at least one palette, with
		/// palette index zero reserved as the default palette.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getcolorpalettecount UINT32 GetColorPaletteCount();
		[PreserveSig]
		new uint GetColorPaletteCount();

		/// <summary>Get the number of entries in each color palette.</summary>
		/// <returns>
		/// The number of entries in each color palette. All color palettes in a font have the same number of palette entries. The return
		/// value is zero if the font has no color information.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getpaletteentrycount UINT32 GetPaletteEntryCount();
		[PreserveSig]
		new uint GetPaletteEntryCount();

		/// <summary>Gets color values from the font's color palette.</summary>
		/// <param name="colorPaletteIndex">
		/// Zero-based index of the color palette. If the font does not have a palette with the specified index, the method returns <b>DWRITE_E_NOCOLOR</b>.
		/// </param>
		/// <param name="firstEntryIndex">Zero-based index of the first palette entry to read.</param>
		/// <param name="entryCount">Number of palette entries to read.</param>
		/// <param name="paletteEntries">Array that receives the color values.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// The sum of <i>firstEntryIndex</i> and <i>entryCount</i> is greater than the actual number of palette entries that's returned by
		/// the <c>GetPaletteEntryCount</c> method.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DWRITE_E_NOCOLOR</description>
		/// <description>The font doesn't have a palette with the specified palette index.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getpaletteentries HRESULT
		// GetPaletteEntries( UINT32 colorPaletteIndex, UINT32 firstEntryIndex, UINT32 entryCount, [out] DWRITE_COLOR_F *paletteEntries );
		[PreserveSig]
		new HRESULT GetPaletteEntries(uint colorPaletteIndex, uint firstEntryIndex, uint entryCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_COLOR_F[] paletteEntries);

		/// <summary>
		/// Determines the recommended text rendering and grid-fit mode to be used based on the font, size, world transform, and measuring mode.
		/// </summary>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Logical font size in DIPs.</para>
		/// </param>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the horizontal direction.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the vertical direction.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>A <c>DWRITE_MATRIX</c> structure that describes the world transform.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Specifies whether the font is sideways. <b>TRUE</b> if the font is sideways; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <param name="outlineThreshold">
		/// <para>Type: <b><c>DWRITE_OUTLINE_THRESHOLD</c></b></para>
		/// <para>
		/// A <c>DWRITE_OUTLINE_THRESHOLD</c>-typed value that specifies the quality of the graphics system's outline rendering, affects the
		/// size threshold above which outline rendering is used.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_MEASURING_MODE</c>-typed value that specifies the method used to measure during text layout. For proper glyph
		/// spacing, this method returns a rendering mode that is compatible with the specified measuring mode.
		/// </para>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <b><c>IDWriteRenderingParams</c>*</b></para>
		/// <para>
		/// A pointer to a <c>IDWriteRenderingParams</c> interface for the rendering parameters object. This parameter is necessary in case
		/// the rendering parameters object overrides the rendering mode.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_RENDERING_MODE</c>-typed value for the recommended rendering mode.</para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_GRID_FIT_MODE</c>-typed value for the recommended grid-fit mode.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( [in] FLOAT fontEmSize, [in] FLOAT dpiX, [in] FLOAT dpiY, [in, optional] DWRITE_MATRIX const
		// *transform, [in] bool isSideways, [in] DWRITE_OUTLINE_THRESHOLD outlineThreshold, [in] DWRITE_MEASURING_MODE measuringMode, [in,
		// optional] IDWriteRenderingParams *renderingParams, [out] DWRITE_RENDERING_MODE *renderingMode, [out] DWRITE_GRID_FIT_MODE
		// *gridFitMode );
		new void GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			bool isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode, [In, Optional] IDWriteRenderingParams? renderingParams,
			out DWRITE_RENDERING_MODE renderingMode, out DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary>Gets a font face reference that identifies this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteFontFaceReference</c> interface for the newly created font
		/// face reference object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getfontfacereference HRESULT
		// GetFontFaceReference( [out] IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference GetFontFaceReference();

		/// <summary>Gets the PANOSE values from the font, used for font selection and matching.</summary>
		/// <param name="panose">
		/// <para>Type: <b><c>DWRITE_PANOSE</c>*</b></para>
		/// <para>A pointer to a <c>DWRITE_PANOSE</c> structure that receives the PANOSE values from the font.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't simulate these values, such as substituting a weight or proportion inferred on other values. If the font
		/// doesn't specify them, they are all set to 'any' (0).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getpanose void GetPanose( [out]
		// DWRITE_PANOSE *panose );
		[PreserveSig]
		new void GetPanose(out DWRITE_PANOSE panose);

		/// <summary>Gets the weight of this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_WEIGHT</c></b></para>
		/// <para>
		/// Returns a <c>DWRITE_FONT_WEIGHT</c>-typed value that specifies the density of a typeface, in terms of the lightness or heaviness
		/// of the strokes.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getweight DWRITE_FONT_WEIGHT GetWeight();
		[PreserveSig]
		new DWRITE_FONT_WEIGHT GetWeight();

		/// <summary>Gets the stretch (also known as width) of this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_STRETCH</c></b></para>
		/// <para>
		/// Returns a <c>DWRITE_FONT_STRETCH</c>-typed value that specifies the degree to which a font has been stretched compared to a
		/// font's normal aspect ratio.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getstretch DWRITE_FONT_STRETCH GetStretch();
		[PreserveSig]
		new DWRITE_FONT_STRETCH GetStretch();

		/// <summary>Gets the style (also known as slope) of this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_STYLE</c></b></para>
		/// <para>Returns a <c>DWRITE_FONT_STYLE</c>-typed value that specifies the style of the font.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getstyle DWRITE_FONT_STYLE GetStyle();
		[PreserveSig]
		new DWRITE_FONT_STYLE GetStyle();

		/// <summary>Creates a localized strings object that contains the family names for the font family, indexed by locale name.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteLocalizedStrings</c> interface for the newly created
		/// localized strings object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getfamilynames HRESULT GetFamilyNames(
		// [out] IDWriteLocalizedStrings **names );
		new IDWriteLocalizedStrings GetFamilyNames();

		/// <summary>
		/// Creates a localized strings object that contains the face names for the font (for example, Regular or Bold), indexed by locale name.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteLocalizedStrings</c> interface for the newly created
		/// localized strings object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getfacenames HRESULT GetFaceNames(
		// [out] IDWriteLocalizedStrings **names );
		new IDWriteLocalizedStrings GetFaceNames();

		/// <summary>Gets a localized strings collection that contains the specified informational strings, indexed by locale name.</summary>
		/// <param name="informationalStringID">
		/// <para>Type: <b><c>DWRITE_INFORMATIONAL_STRING_ID</c></b></para>
		/// <para>A <c>DWRITE_INFORMATIONAL_STRING_ID</c>-typed value that identifies the strings to get.</para>
		/// </param>
		/// <param name="informationalStrings">
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteLocalizedStrings</c> interface for the newly created
		/// localized strings object.
		/// </para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>
		/// A pointer to a variable that receives whether the font contains the specified string ID. <b>TRUE</b> if the font contains the
		/// specified string ID; otherwise, <b>FALSE</b>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>
		/// If the font doesn't contain the specified string, the return value is S_OK, but <i>informationalStrings</i> receives a
		/// <b>NULL</b> pointer and <i>exists</i> receives the value <b>FALSE</b>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getinformationalstrings HRESULT
		// GetInformationalStrings( [in] DWRITE_INFORMATIONAL_STRING_ID informationalStringID, [out] IDWriteLocalizedStrings
		// **informationalStrings, [out] BOOL *exists );
		new void GetInformationalStrings(DWRITE_INFORMATIONAL_STRING_ID informationalStringID, out IDWriteLocalizedStrings? informationalStrings,
			[MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Determines whether the font supports the specified character.</summary>
		/// <param name="unicodeValue">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>A Unicode (UCS-4) character value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>
		/// Returns whether the font supports the specified character. Returns <b>TRUE</b> if the font has the specified character;
		/// otherwise, <b>FALSE</b>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-hascharacter BOOL HasCharacter( [in]
		// UINT32 unicodeValue );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool HasCharacter(uint unicodeValue);

		/// <summary>
		/// Determines the recommended text rendering and grid-fit mode to be used based on the font, size, world transform, and measuring mode.
		/// </summary>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Logical font size in DIPs.</para>
		/// </param>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the horizontal direction.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the vertical direction.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>A <c>DWRITE_MATRIX</c> structure that describes the world transform.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies whether the font is sideways. <b>TRUE</b> if the font is sideways; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <param name="outlineThreshold">
		/// <para>Type: <b><c>DWRITE_OUTLINE_THRESHOLD</c></b></para>
		/// <para>
		/// A <c>DWRITE_OUTLINE_THRESHOLD</c>-typed value that specifies the quality of the graphics system's outline rendering, affects the
		/// size threshold above which outline rendering is used.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_MEASURING_MODE</c>-typed value that specifies the method used to measure during text layout. For proper glyph
		/// spacing, this method returns a rendering mode that is compatible with the specified measuring mode.
		/// </para>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <b><c>IDWriteRenderingParams</c>*</b></para>
		/// <para>
		/// A pointer to a <c>IDWriteRenderingParams</c> interface for the rendering parameters object. This parameter is necessary in case
		/// the rendering parameters object overrides the rendering mode.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_RENDERING_MODE1</c>-typed value for the recommended rendering mode.</para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_GRID_FIT_MODE</c>-typed value for the recommended grid-fit mode.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( [in] FLOAT fontEmSize, [in] FLOAT dpiX, [in] FLOAT dpiY, [in, optional] DWRITE_MATRIX const
		// *transform, [in] BOOL isSideways, [in] DWRITE_OUTLINE_THRESHOLD outlineThreshold, [in] DWRITE_MEASURING_MODE measuringMode, [in,
		// optional] IDWriteRenderingParams *renderingParams, [out] DWRITE_RENDERING_MODE1 *renderingMode, [out] DWRITE_GRID_FIT_MODE
		// *gridFitMode );
		new void GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			bool isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode,
			[In, Optional] IDWriteRenderingParams? renderingParams, out DWRITE_RENDERING_MODE1 renderingMode, out DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary><c>unicodeValue</c></summary>
		/// <param name="unicodeValue"/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontface3-ischaracterlocal BOOL
		// IsCharacterLocal( UINT32 unicodeValue );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsCharacterLocal(uint unicodeValue);

		/// <summary>Determines whether the glyph is locally downloaded from the font.</summary>
		/// <param name="glyphId">
		/// <para>Type: <b>UINT16</b></para>
		/// <para>Glyph identifier.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Returns TRUE if the font has the specified glyph locally available.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-isglyphlocal BOOL IsGlyphLocal( [in]
		// UINT16 glyphId );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsGlyphLocal(ushort glyphId);

		/// <summary>Determines whether the specified characters are local.</summary>
		/// <param name="characters">
		/// <para>Type: <b>WCHAR</b></para>
		/// <para>Array of characters.</para>
		/// </param>
		/// <param name="characterCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of elements in the character array.</para>
		/// </param>
		/// <param name="enqueueIfNotLocal">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies whether to enqueue a download request if any of the specified characters are not local.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if all of the specified characters are local, FALSE if any of the specified characters are remote.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-arecharacterslocal HRESULT
		// AreCharactersLocal( [in] WCHAR const *characters, UINT32 characterCount, BOOL enqueueIfNotLocal, [out] BOOL *isLocal );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool AreCharactersLocal([MarshalAs(UnmanagedType.LPWStr)] string characters, uint characterCount, bool enqueueIfNotLocal);

		/// <summary>Determines whether the specified glyphs are local.</summary>
		/// <param name="glyphIndices">
		/// <para>Type: <b>UINT16</b></para>
		/// <para>Array of glyph indices.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of elements in the glyph index array.</para>
		/// </param>
		/// <param name="enqueueIfNotLocal">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies whether to enqueue a download request if any of the specified glyphs are not local.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if all of the specified glyphs are local, FALSE if any of the specified glyphs are remote.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-areglyphslocal HRESULT AreGlyphsLocal(
		// [in] UINT16 const *glyphIndices, UINT32 glyphCount, BOOL enqueueIfNotLocal, [out] BOOL *isLocal );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool AreGlyphsLocal([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices, uint glyphCount, bool enqueueIfNotLocal);

		/// <summary>Gets all the glyph image formats supported for the specified glyph.</summary>
		/// <param name="glyphId">The identifier of the glyph to be queried.</param>
		/// <param name="pixelsPerEmFirst">The lowest pixels per em value to query.</param>
		/// <param name="pixelsPerEmLast">The highest pixels per em value to query.</param>
		/// <returns>An array of <c>DWRITE_GLYPH_IMAGE_FORMATS</c> specifying the supported formats for the requested glyph.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface4-getglyphimageformats(uint16_uint32_uint32_dwrite_glyph_image_formats)
		// HRESULT GetGlyphImageFormats( UINT16 glyphId, UINT32 pixelsPerEmFirst, UINT32 pixelsPerEmLast, DWRITE_GLYPH_IMAGE_FORMATS
		// *glyphImageFormats );
		new DWRITE_GLYPH_IMAGE_FORMATS GetGlyphImageFormats(ushort glyphId, uint pixelsPerEmFirst, uint pixelsPerEmLast);

		/// <summary>Gets all the glyph image formats supported by the entire font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_FORMATS</c></b></para>
		/// <para>Returns all the glyph image formats supported by the entire font.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface4-getglyphimageformats
		// DWRITE_GLYPH_IMAGE_FORMATS GetGlyphImageFormats();
		[PreserveSig]
		new DWRITE_GLYPH_IMAGE_FORMATS GetGlyphImageFormats();

		/// <summary>Gets a pointer to the glyph data based on the desired image format.</summary>
		/// <param name="glyphId">
		/// <para>Type: <b>UINT16</b></para>
		/// <para>The ID of the glyph to retrieve image data for.</para>
		/// </param>
		/// <param name="pixelsPerEm">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Requested pixels per em.</para>
		/// </param>
		/// <param name="glyphImageFormat">
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_FORMATS</c></b></para>
		/// <para>Specifies which formats are supported in the font.</para>
		/// </param>
		/// <param name="glyphData">
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_DATA</c>*</b></para>
		/// <para>On return contains data for a glyph.</para>
		/// </param>
		/// <param name="glyphDataContext">Type: <b>void**</b></param>
		/// <remarks>
		/// <para>
		/// The glyphDataContext must be released via <c>ReleaseGlyphImageData</c> when done if the data is not empty, similar to
		/// <c>IDWriteFontFileStream::ReadFileFragment</c> and <c>IDWriteFontFileStream::ReleaseFileFragment</c>. The data pointer is valid
		/// so long as the <c>IDWriteFontFace</c> exists and <b>ReleaseGlyphImageData</b> has not been called.
		/// </para>
		/// <para>
		/// The <c>DWRITE_GLYPH_IMAGE_DATA::uniqueDataId</c> is valuable for caching purposes so that if the same resource is returned more
		/// than once, an existing resource can be quickly retrieved rather than needing to reparse or decompress the data.
		/// </para>
		/// <para>
		/// The function only returns SVG or raster data - requesting TrueType/CFF/COLR data returns DWRITE_E_INVALIDARG. Those must be
		/// drawn via DrawGlyphRun or queried using GetGlyphOutline instead. Exactly one format may be requested or else the function
		/// returns DWRITE_E_INVALIDARG. If the glyph does not have that format, the call is not an error, but the function returns empty data.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface4-getglyphimagedata HRESULT
		// GetGlyphImageData( [in] UINT16 glyphId, UINT32 pixelsPerEm, DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat, [out]
		// DWRITE_GLYPH_IMAGE_DATA *glyphData, [out] void **glyphDataContext );
		new void GetGlyphImageData(ushort glyphId, uint pixelsPerEm, DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat, out DWRITE_GLYPH_IMAGE_DATA glyphData,
			out IntPtr glyphDataContext);

		/// <summary>Releases the table data obtained from ReadGlyphData.</summary>
		/// <param name="glyphDataContext">
		/// <para>Type: <b>void*</b></para>
		/// <para>Opaque context from ReadGlyphData.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface4-releaseglyphimagedata void
		// ReleaseGlyphImageData( void *glyphDataContext );
		[PreserveSig]
		new void ReleaseGlyphImageData([In] IntPtr glyphDataContext);

		/// <summary>Retrieves the number of axes defined by the font face. This includes both static and variable axes (see <c>DWRITE_FONT_AXIS_RANGE</c>).</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axes defined by the font face.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface5-getfontaxisvaluecount UINT32 GetFontAxisValueCount();
		[PreserveSig]
		uint GetFontAxisValueCount();

		/// <summary>Retrieves the list of axis values used by the font.</summary>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c>*</b></para>
		/// <para>
		/// A pointer to an array of <b>DWRITE_FONT_AXIS_VALUE</b> structures into which <b>GetFontAxisValues</b> writes the list of font
		/// axis values. You're responsible for managing the size and the lifetime of this array. Call <c>GetFontAxisValueCount</c> to
		/// determine the size of array to allocate.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The maximum number of font axis values to write into the memory block pointed to by <c>fontAxisValues</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// <code>fontAxisValueCount</code>
		/// doesn't match the value returned by <b>GetFontAxisValueCount</b>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The values are returned in the canonical order defined by the font, clamped to the actual range supported. It's not necessarily
		/// the same axis value array that you passed to <b>CreateFontFace</b>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface5-getfontaxisvalues HRESULT
		// GetFontAxisValues( [out] DWRITE_FONT_AXIS_VALUE *fontAxisValues, UINT32 fontAxisValueCount );
		void GetFontAxisValues([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);

		/// <summary>
		/// Determines whether this font face's resource supports any variable axes. When <c>true</c>, at least one
		/// <c>DWRITE_FONT_AXIS_RANGE</c> in the font resource has a non-empty range (maxValue &gt; minValue).
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>BOOL</c></b></para>
		/// <para><c>true</c> if the font face's resource supports any variable axes. Otherwise, <c>false</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface5-hasvariations BOOL HasVariations();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool HasVariations();

		/// <summary>
		/// Retrieves the underlying font resource for this font face. You can use that to query information about the resource, or to
		/// recreate a new font face instance with different axis values.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontResource</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontResource</c> interface. On successful completion, the function sets the pointer to
		/// a newly created font resource object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface5-getfontresource HRESULT
		// GetFontResource( [out] IDWriteFontResource **fontResource );
		IDWriteFontResource GetFontResource();

		/// <summary>
		/// Performs an equality comparison between the font face object on which <b>Equals</b> is being called and the font face object
		/// passed as a parameter.
		/// </summary>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>A pointer to a font face object to compare with the font face object on which <b>Equals</b> is being called.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>BOOL</c></b></para>
		/// <para><c>true</c> if the font face objects are equal. Otherwise, <c>false</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface5-equals BOOL Equals( IDWriteFontFace
		// *fontFace );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool Equals(IDWriteFontFace fontFace);
	}

	/// <summary>The <b>IDWriteFontFace6</b> interface inherits from the IDWriteFontFace5 interface.</summary>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nn-dwrite_3-idwritefontface6
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontFace6")]
	[ComImport, Guid("C4B1FE1B-6E84-47D5-B54C-A597981B06AD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontFace6 : IDWriteFontFace, IDWriteFontFace1, IDWriteFontFace2, IDWriteFontFace3, IDWriteFontFace4, IDWriteFontFace5
	{
		/// <summary>Obtains the file format type of a font face.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_FACE_TYPE</c></para>
		/// <para>A value that indicates the type of format for the font face (such as Type 1, TrueType, vector, or bitmap).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-gettype DWRITE_FONT_FACE_TYPE GetType();
		[PreserveSig]
		new DWRITE_FONT_FACE_TYPE GetType();

		/// <summary>Obtains the font files representing a font face.</summary>
		/// <param name="numberOfFiles">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// If fontFiles is <c>NULL</c>, receives the number of files representing the font face. Otherwise, the number of font files being
		/// requested should be passed. See the Remarks section below for more information.
		/// </para>
		/// </param>
		/// <param name="fontFiles">
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a user-provided array that stores pointers to font files representing the font
		/// face. This parameter can be <c>NULL</c> if the user wants only the number of files representing the font face. This API
		/// increments reference count of the font file pointers returned according to COM conventions, and the client should release them
		/// when finished.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The <c>IDWriteFontFace::GetFiles</c> method should be called twice. The first time you call <c>GetFiles</c> fontFiles should be
		/// <c>NULL</c>. When the method returns, numberOfFiles receives the number of font files that represent the font face.
		/// </para>
		/// <para>
		/// Then, call the method a second time, passing the numberOfFiles value that was output the first call, and a non-null buffer of
		/// the correct size to store the IDWriteFontFile pointers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getfiles HRESULT GetFiles( UINT32
		// *numberOfFiles, IDWriteFontFile **fontFiles );
		new void GetFiles(ref uint numberOfFiles, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] IDWriteFontFile[]? fontFiles);

		/// <summary>Obtains the index of a font face in the context of its font files.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The zero-based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value is zero.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getindex UINT32 GetIndex();
		[PreserveSig]
		new uint GetIndex();

		/// <summary>Obtains the algorithmic style simulation flags of a font face.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>Font face simulation flags for algorithmic means of making text bold or italic.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getsimulations DWRITE_FONT_SIMULATIONS GetSimulations();
		[PreserveSig]
		new DWRITE_FONT_SIMULATIONS GetSimulations();

		/// <summary>Determines whether the font is a symbol font.</summary>
		/// <returns>
		/// <para>Type: <c>bool</c></para>
		/// <para>Returns <c>TRUE</c> if the font is a symbol font, otherwise <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-issymbolfont bool IsSymbolFont();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsSymbolFont();

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a font face and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="fontFaceMetrics">
		/// <para>Type: <c>DWRITE_FONT_METRICS*</c></para>
		/// <para>
		/// When this method returns, a DWRITE_FONT_METRICS structure that holds metrics (such as ascent, descent, or cap height) for the
		/// current font face element. The metrics returned by this function are in font design units.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getmetrics void GetMetrics(
		// DWRITE_FONT_METRICS *fontFaceMetrics );
		[PreserveSig]
		new void GetMetrics(out DWRITE_FONT_METRICS fontFaceMetrics);

		/// <summary>Obtains the number of glyphs in the font face.</summary>
		/// <returns>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>The number of glyphs in the font face.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphcount UINT16 GetGlyphCount();
		[PreserveSig]
		new ushort GetGlyphCount();

		/// <summary>Obtains ideal (resolution-independent) glyph metrics in font design units.</summary>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>
		/// An array of glyph indices for which to compute metrics. The array must contain at least as many elements as specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the glyphIndices array.</para>
		/// </param>
		/// <param name="glyphMetrics">
		/// <para>Type: <c>DWRITE_GLYPH_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains an array of DWRITE_GLYPH_METRICS structures. glyphMetrics must be initialized with an empty
		/// buffer that contains at least as many elements as glyphCount. The metrics returned by this function are in font design units.
		/// </para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// Indicates whether the font is being used in a sideways run. This can affect the glyph metrics if the font has oblique simulation
		/// because sideways oblique simulation differs from non-sideways oblique simulation
		/// </para>
		/// </param>
		/// <remarks>Design glyph metrics are used for glyph positioning.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getdesignglyphmetrics HRESULT
		// GetDesignGlyphMetrics( UINT16 const *glyphIndices, UINT32 glyphCount, DWRITE_GLYPH_METRICS *glyphMetrics, bool isSideways );
		new void GetDesignGlyphMetrics([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices, uint glyphCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_GLYPH_METRICS[] glyphMetrics, [MarshalAs(UnmanagedType.Bool)] bool isSideways = false);

		/// <summary>Returns the nominal mapping of UCS4 Unicode code points to glyph indices as defined by the font 'CMAP' table.</summary>
		/// <param name="codePoints">
		/// <para>Type: <c>const UINT32*</c></para>
		/// <para>
		/// An array of USC4 code points from which to obtain nominal glyph indices. The array must be allocated and be able to contain the
		/// number of elements specified by codePointCount.
		/// </para>
		/// </param>
		/// <param name="codePointCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the codePoints array.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>UINT16*</c></para>
		/// <para>When this method returns, contains a pointer to an array of nominal glyph indices filled by this function.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Note that this mapping is primarily provided for line layout engines built on top of the physical font API. Because of OpenType
		/// glyph substitution and line layout character substitution, the nominal conversion does not always correspond to how a Unicode
		/// string will map to glyph indices when rendering using a particular font face. Also, note that Unicode variant selectors provide
		/// for alternate mappings for character to glyph. This call will always return the default variant.
		/// </para>
		/// <para>
		/// When characters are not present in the font this method returns the index 0, which is the undefined glyph or ".notdef" glyph. If
		/// a character isn't in a font, IDWriteFont::HasCharacter returns false and GetUnicodeRanges doesn't return it in the range.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphindices HRESULT GetGlyphIndices(
		// UINT32 const *codePoints, UINT32 codePointCount, UINT16 *glyphIndices );
		new void GetGlyphIndices([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] codePoints, uint codePointCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices);

		/// <summary>
		/// Finds the specified OpenType font table if it exists and returns a pointer to it. The function accesses the underlying font data
		/// through the IDWriteFontFileStream interface implemented by the font file loader.
		/// </summary>
		/// <param name="openTypeTableTag">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The four-character tag of a OpenType font table to find. Use the <c>DWRITE_MAKE_OPENTYPE_TAG</c> macro to create it as an
		/// <c>UINT32</c>. Unlike GDI, it does not support the special TTCF and null tags to access the whole font.
		/// </para>
		/// </param>
		/// <param name="tableData">
		/// <para>Type: <c>const void**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the base of the table in memory. The pointer is valid only as
		/// long as the font face used to get the font table still exists; (not any other font face, even if it actually refers to the same
		/// physical font). This parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <param name="tableSize">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains a pointer to the size, in bytes, of the font table.</para>
		/// </param>
		/// <param name="tableContext">
		/// <para>Type: <c>void**</c></para>
		/// <para>
		/// When this method returns, the address of a pointer to the opaque context, which must be freed by calling ReleaseFontTable. The
		/// context actually comes from the lower-level IDWriteFontFileStream, which may be implemented by the application or DWrite itself.
		/// It is possible for a <c>NULL</c> tableContext to be returned, especially if the implementation performs direct memory mapping on
		/// the whole file. Nevertheless, always release it later, and do not use it as a test for function success. The same table can be
		/// queried multiple times, but because each returned context can be different, you must release each context separately.
		/// </para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <c>bool*</c></para>
		/// <para>When this method returns, <c>TRUE</c> if the font table exists; otherwise, <c>FALSE</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The context for the same tag may be different for each call, so each one must be held and released separately.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-trygetfonttable HRESULT TryGetFontTable(
		// UINT32 openTypeTableTag, const void **tableData, UINT32 *tableSize, void **tableContext, bool *exists );
		new HRESULT TryGetFontTable([In] uint openTypeTableTag, out IntPtr tableData, out uint tableSize, out IntPtr tableContext, [MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Releases the table obtained earlier from TryGetFontTable.</summary>
		/// <param name="tableContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>A pointer to the opaque context from TryGetFontTable.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-releasefonttable void ReleaseFontTable( void
		// *tableContext );
		[PreserveSig]
		new void ReleaseFontTable([In] IntPtr tableContext);

		/// <summary>Computes the outline of a run of glyphs by calling back to the outline sink interface.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>
		/// An array of glyph indices. The glyphs are in logical order and the advance direction depends on the isRightToLeft parameter. The
		/// array must be allocated and be able to contain the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <c>const FLOAT*</c></para>
		/// <para>
		/// An optional array of glyph advances in DIPs. The advance of a glyph is the amount to advance the position (in the direction of
		/// the baseline) after drawing the glyph. glyphAdvances contains the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphOffsets">
		/// <para>Type: <c>const DWRITE_GLYPH_OFFSET*</c></para>
		/// <para>
		/// An optional array of glyph offsets, each of which specifies the offset along the baseline and offset perpendicular to the
		/// baseline of a glyph relative to the current pen position. glyphOffsets contains the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of glyphs in the run.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// If <c>TRUE</c>, the ascender of the glyph runs alongside the baseline. If <c>FALSE</c>, the glyph ascender runs perpendicular to
		/// the baseline. For example, an English alphabet on a vertical baseline would have isSideways set to <c>FALSE</c>.
		/// </para>
		/// <para>
		/// A client can render a vertical run by setting isSideways to <c>TRUE</c> and rotating the resulting geometry 90 degrees to the
		/// right using a transform. The isSideways and isRightToLeft parameters cannot both be true.
		/// </para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// The visual order of the glyphs. If this parameter is <c>FALSE</c>, then glyph advances are from left to right. If <c>TRUE</c>,
		/// the advance direction is right to left. By default, the advance direction is left to right.
		/// </para>
		/// </param>
		/// <param name="geometrySink">
		/// <para>Type: <c>IDWriteGeometrySink*</c></para>
		/// <para>A pointer to the interface that is called back to perform outline drawing operations.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphrunoutline HRESULT
		// GetGlyphRunOutline( FLOAT emSize, UINT16 const *glyphIndices, FLOAT const *glyphAdvances, DWRITE_GLYPH_OFFSET const
		// *glyphOffsets, UINT32 glyphCount, bool isSideways, bool isRightToLeft, IDWriteGeometrySink *geometrySink );
		new void GetGlyphRunOutline(float emSize, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ushort[] glyphIndices,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[]? glyphAdvances,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_GLYPH_OFFSET[]? glyphOffsets,
			uint glyphCount, [MarshalAs(UnmanagedType.Bool)] bool isSideways, [MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
			[In, MarshalAs(UnmanagedType.Interface)] object geometrySink);

		/// <summary>Determines the recommended rendering mode for the font, using the specified size and rendering parameters.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96, this value is 1.0f. If the DPI is
		/// 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>
		/// The measuring method that will be used for glyphs in the font. Renderer implementations may choose different rendering modes for
		/// different measuring methods, for example:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL for DWRITE_MEASURING_MODE_NATURAL</term>
		/// </item>
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC for DWRITE_MEASURING_MODE_GDI_CLASSIC</term>
		/// </item>
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL for DWRITE_MEASURING_MODE_GDI_NATURAL</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>
		/// A pointer to an object that contains rendering settings such as gamma level, enhanced contrast, and ClearType level. This
		/// parameter is necessary in case the rendering parameters object overrides the rendering mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWRITE_RENDERING_MODE*</c></para>
		/// <para>When this method returns, contains a value that indicates the recommended rendering mode to use.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MEASURING_MODE measuringMode, IDWriteRenderingParams
		// *renderingParams, DWRITE_RENDERING_MODE *renderingMode );
		new DWRITE_RENDERING_MODE GetRecommendedRenderingMode(float emSize, float pixelsPerDip, DWRITE_MEASURING_MODE measuringMode, IDWriteRenderingParams renderingParams);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a fontface and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_METRICS*</c></para>
		/// <para>A pointer to a DWRITE_FONT_METRICS structure to fill in. The metrics returned by this function are in font design units.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getgdicompatiblemetrics HRESULT
		// GetGdiCompatibleMetrics( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, DWRITE_FONT_METRICS
		// *fontFaceMetrics );
		new DWRITE_FONT_METRICS GetGdiCompatibleMetrics(float emSize, float pixelsPerDip, [In, Optional] IntPtr transform);

		/// <summary>Obtains glyph metrics in font design units with the return values compatible with what GDI would produce.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The ogical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// When set to <c>FALSE</c>, the metrics are the same as the metrics of GDI aliased text. When set to <c>TRUE</c>, the metrics are
		/// the same as the metrics of text measured by GDI using a font created with <c>CLEARTYPE_NATURAL_QUALITY</c>.
		/// </para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>An array of glyph indices for which to compute the metrics.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the glyphIndices array.</para>
		/// </param>
		/// <param name="glyphMetrics">
		/// <para>Type: <c>DWRITE_GLYPH_METRICS*</c></para>
		/// <para>An array of DWRITE_GLYPH_METRICS structures filled by this function. The metrics are in font design units.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// A bool value that indicates whether the font is being used in a sideways run. This can affect the glyph metrics if the font has
		/// oblique simulation because sideways oblique simulation differs from non-sideways oblique simulation.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getgdicompatibleglyphmetrics HRESULT
		// GetGdiCompatibleGlyphMetrics( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, bool useGdiNatural, UINT16 const
		// *glyphIndices, UINT32 glyphCount, DWRITE_GLYPH_METRICS *glyphMetrics, bool isSideways );
		new void GetGdiCompatibleGlyphMetrics(float emSize, float pixelsPerDip, [In, Optional] IntPtr transform, [MarshalAs(UnmanagedType.Bool)] bool useGdiNatural,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ushort[] glyphIndices, uint glyphCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] DWRITE_GLYPH_METRICS[] glyphMetrics, [MarshalAs(UnmanagedType.Bool)] bool isSideways = false);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a font face and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="fontMetrics">
		/// <para>Type: <b><c>DWRITE_FONT_METRICS1</c>*</b></para>
		/// <para>
		/// A filled <c>DWRITE_FONT_METRICS1</c> structure that holds metrics for the current font face element. The metrics returned by
		/// this method are in font design units.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getmetrics void GetMetrics( [out]
		// DWRITE_FONT_METRICS1 *fontMetrics );
		[PreserveSig]
		new void GetMetrics(out DWRITE_FONT_METRICS1 fontMetrics);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a fontface and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="emSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The logical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and <i>pixelsPerDip</i>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_METRICS1</c>*</b></para>
		/// <para>
		/// A pointer to a <c>DWRITE_FONT_METRICS1</c> structure to fill in. The metrics returned by this function are in font design units.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getgdicompatiblemetrics HRESULT
		// GetGdiCompatibleMetrics( FLOAT emSize, FLOAT pixelsPerDip, [in, optional] DWRITE_MATRIX const *transform, [out]
		// DWRITE_FONT_METRICS1 *fontMetrics );
		new DWRITE_FONT_METRICS1 GetGdiCompatibleMetrics(float emSize, float pixelsPerDip, [In, Optional] StructPointer<DWRITE_MATRIX> transform);

		/// <summary>Gets caret metrics for the font in design units.</summary>
		/// <param name="caretMetrics">
		/// <para>Type: <b>DWRITE_CARET_METRICS*</b></para>
		/// <para>A pointer to the <c>DWRITE_CARET_METRICS</c> structure that is filled.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>Caret metrics are used by text editors for drawing the correct caret placement and slant.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getcaretmetrics void GetCaretMetrics(
		// [out] DWRITE_CARET_METRICS *caretMetrics );
		[PreserveSig]
		new void GetCaretMetrics(out DWRITE_CARET_METRICS caretMetrics);

		/// <summary>Retrieves a list of character ranges supported by a font.</summary>
		/// <param name="maxRangeCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Maximum number of character ranges passed in from the client.</para>
		/// </param>
		/// <param name="unicodeRanges">
		/// <para>Type: <b><c>DWRITE_UNICODE_RANGE</c>*</b></para>
		/// <para>An array of <c>DWRITE_UNICODE_RANGE</c> structures that are filled with the character ranges.</para>
		/// </param>
		/// <param name="actualRangeCount">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>A pointer to the actual number of character ranges, regardless of the maximum count.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// A list of character ranges supported by the font is useful for scenarios like character picking, glyph display, and efficient
		/// font selection lookup. This is similar to GDI's <c>GetFontUnicodeRanges</c>, except that it returns the full Unicode range, not
		/// just 16-bit UCS-2.
		/// </para>
		/// <para>These ranges are from the cmap, not the OS/2::ulCodePageRange1.</para>
		/// <para>
		/// If this method is unavailable, you can use the <c>IDWriteFontFace::GetGlyphIndices</c> method to check for missing glyphs. The
		/// method returns the 0 index for glyphs that aren't present in the font.
		/// </para>
		/// <para>
		/// The <c>IDWriteFont::HasCharacter</c> method is often simpler in cases where you need to check a single character or a series of
		/// single characters in succession, such as in font fallback.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getunicoderanges HRESULT
		// GetUnicodeRanges( UINT32 maxRangeCount, [out, optional] DWRITE_UNICODE_RANGE *unicodeRanges, [out] UINT32 *actualRangeCount );
		new void GetUnicodeRanges(int maxRangeCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DWRITE_UNICODE_RANGE[]? unicodeRanges, out uint actualRangeCount);

		/// <summary>
		/// Determines whether the font of a text range is monospaced, that is, the font characters are the same fixed-pitch width.
		/// </summary>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns TRUE if the font is monospaced, otherwise it returns FALSE.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-ismonospacedfont bool IsMonospacedFont();
		[PreserveSig]
		new bool IsMonospacedFont();

		/// <summary>Retrieves the advances in design units for a sequences of glyphs.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of glyphs to retrieve advances for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve advances for.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <b>INT32*</b></para>
		/// <para>The returned advances in font design units for each glyph.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Retrieve the glyph's vertical advance height rather than horizontal advance widths.</para>
		/// </param>
		/// <remarks>This is equivalent to calling GetGlyphMetrics and using only the advance width and height.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getdesignglyphadvances HRESULT
		// GetDesignGlyphAdvances( UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvances, bool isSideways );
		new void GetDesignGlyphAdvances(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] glyphAdvances, bool isSideways = false);

		/// <summary>Returns the pixel-aligned advances for a sequences of glyphs.</summary>
		/// <param name="emSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// Number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96 this value is 1.0f. If the DPI is 120,
		/// this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the font
		/// size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// When FALSE, the metrics are the same as GDI aliased text (DWRITE_MEASURING_MODE_GDI_CLASSIC). When TRUE, the metrics are the
		/// same as those measured by GDI using a font using CLEARTYPE_NATURAL_QUALITY (DWRITE_MEASURING_MODE_GDI_NATURAL).
		/// </para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Retrieve the glyph's vertical advances rather than horizontal advances.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Total glyphs to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve advances.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <b>const INT32*</b></para>
		/// <para>The returned advances in font design units for each glyph.</para>
		/// </param>
		/// <remarks>
		/// <para>This is equivalent to calling <c>GetGdiCompatibleGlyphMetrics</c> and using only the advance width and height.</para>
		/// <para>Like <c>GetGdiCompatibleGlyphMetrics</c>, these are in design units, meaning they must be scaled down by DWRITE_FONT_METRICS::designUnitsPerEm.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getgdicompatibleglyphadvances HRESULT
		// GetGdiCompatibleGlyphAdvances( FLOAT emSize, FLOAT pixelsPerDip, [in, optional] DWRITE_MATRIX const *transform, bool
		// useGdiNatural, bool isSideways, UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvances );
		new void GetGdiCompatibleGlyphAdvances(float emSize, float pixelsPerDip, [In, Optional] StructPointer<DWRITE_MATRIX> transform, bool useGdiNatural,
			bool isSideways, int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] int[] glyphAdvances);

		/// <summary>Retrieves the kerning pair adjustments from the font's kern table.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Number of glyphs to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphAdvanceAdjustments">
		/// <para>Type: <b>INT32*</b></para>
		/// <para>The advances, returned in font design units, for each glyph. The last glyph adjustment is zero.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <b>GetKerningPairAdjustments</b> isn't a direct replacement for GDI's character based <c>GetKerningPairs</c>, but it serves the
		/// same role, without the client needing to cache them locally. <b>GetKerningPairAdjustments</b> also uses glyph id's directly
		/// rather than UCS-2 characters (how the kern table actually stores them), which avoids glyph collapse and ambiguity, such as the
		/// dash and hyphen, or space and non-breaking space.
		/// </para>
		/// <para>
		/// Newer fonts may have only GPOS kerning instead of the legacy pair-table kerning. Such fonts, like Gabriola, will only return 0's
		/// for adjustments. <b>GetKerningPairAdjustments</b> doesn't virtualize and flatten these GPOS entries into kerning pairs.
		/// </para>
		/// <para>
		/// You can realize a performance benefit by calling <c>IDWriteFontFace1::HasKerningPairs</c> to determine whether you need to call
		/// <b>GetKerningPairAdjustments</b>. If you previously called <b>IDWriteFontFace1::HasKerningPairs</b> and it returned FALSE, you
		/// can avoid calling <b>GetKerningPairAdjustments</b> because the font has no kerning pair-table entries. That is, in this
		/// situation, a call to <b>GetKerningPairAdjustments</b> would be a no-op.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getkerningpairadjustments HRESULT
		// GetKerningPairAdjustments( UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvanceAdjustments );
		new void GetKerningPairAdjustments(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] glyphAdvanceAdjustments);

		/// <summary>Determines whether the font supports pair-kerning.</summary>
		/// <returns>Returns TRUE if the font supports kerning pairs, otherwise FALSE.</returns>
		/// <remarks>
		/// If the font doesn't support pair table kerning, you don't need to call <c>IDWriteFontFace1::GetKerningPairAdjustments</c>
		/// because it would retrieve all zeroes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-haskerningpairs bool HasKerningPairs();
		[PreserveSig]
		new bool HasKerningPairs();

		/// <summary>Determines the recommended rendering mode for the font, using the specified size and rendering parameters.</summary>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The number of physical pixels per DIP in a horizontal position. For example, if the DPI of the rendering surface is 96, this
		/// value is 1.0f. If the DPI is 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The number of physical pixels per DIP in a vertical position. For example, if the DPI of the rendering surface is 96, this value
		/// is 1.0f. If the DPI is 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const DWRITE_MATRIX*</b></para>
		/// <para>Specifies the world transform.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Whether the glyphs in the run are sideways or not.</para>
		/// </param>
		/// <param name="outlineThreshold">
		/// <para>Type: <b><c>DWRITE_OUTLINE_THRESHOLD</c></b></para>
		/// <para>
		/// A <c>DWRITE_OUTLINE_THRESHOLD</c>-typed value that specifies the quality of the graphics system's outline rendering, affects the
		/// size threshold above which outline rendering is used.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// The measuring method that will be used for glyphs in the font. Renderer implementations may choose different rendering modes for
		/// different measuring methods, for example:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL for <c>DWRITE_MEASURING_MODE_NATURAL</c></description>
		/// </item>
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC for <c>DWRITE_MEASURING_MODE_GDI_CLASSIC</c></description>
		/// </item>
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL for <c>DWRITE_MEASURING_MODE_GDI_NATURAL</c></description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c>*</b></para>
		/// <para>When this method returns, contains a value that indicates the recommended rendering mode to use.</para>
		/// </returns>
		/// <remarks>
		/// This method should be used to determine the actual rendering mode in cases where the rendering mode of the rendering params
		/// object is DWRITE_RENDERING_MODE_DEFAULT.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( FLOAT fontEmSize, FLOAT dpiX, FLOAT dpiY, [in, optional] DWRITE_MATRIX const *transform, bool
		// isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode, [out] DWRITE_RENDERING_MODE
		// *renderingMode );
		new DWRITE_RENDERING_MODE GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			bool isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode);

		/// <summary>Retrieves the vertical forms of the nominal glyphs retrieved from GetGlyphIndices.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of glyphs to retrieve.</para>
		/// </param>
		/// <param name="nominalGlyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>Original glyph indices from cmap.</para>
		/// </param>
		/// <param name="verticalGlyphIndices">
		/// <para>Type: <b>UINT16*</b></para>
		/// <para>The vertical form of glyph indices.</para>
		/// </param>
		/// <remarks>
		/// <para>The retrieval uses the font's 'vert' table. This is used in CJK vertical layout so the correct characters are shown.</para>
		/// <para>
		/// Call <c>GetGlyphIndices</c> to get the nominal glyph indices, followed by calling this to remap the to the substituted forms,
		/// when the run is sideways, and the font has vertical glyph variants. See <c>HasVerticalGlyphVariants</c> for more info.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getverticalglyphvariants HRESULT
		// GetVerticalGlyphVariants( UINT32 glyphCount, [in] UINT16 const *nominalGlyphIndices, [out] UINT16 *verticalGlyphIndices );
		new void GetVerticalGlyphVariants(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] nominalGlyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] verticalGlyphIndices);

		/// <summary>Determines whether the font has any vertical glyph variants.</summary>
		/// <returns>Returns TRUE if the font contains vertical glyph variants, otherwise FALSE.</returns>
		/// <remarks>
		/// <para>For OpenType fonts, <b>HasVerticalGlyphVariants</b> returns TRUE if the font contains a "vert"feature.</para>
		/// <para>
		/// <c>IDWriteFontFace1::GetVerticalGlyphVariants</c> retrieves the vertical forms of the nominal glyphs that are retrieved from <c>IDWriteFontFace::GetGlyphIndices</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-hasverticalglyphvariants bool HasVerticalGlyphVariants();
		[PreserveSig]
		new bool HasVerticalGlyphVariants();

		/// <summary>Allows you to determine if a color rendering path is potentially necessary.</summary>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns <b>TRUE</b> if a color rendering path is potentially necessary.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-iscolorfont bool IsColorFont();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsColorFont();

		/// <summary>Gets the number of color palettes defined by the font.</summary>
		/// <returns>
		/// The return value is zero if the font has no color information. Color fonts are required to define at least one palette, with
		/// palette index zero reserved as the default palette.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getcolorpalettecount UINT32 GetColorPaletteCount();
		[PreserveSig]
		new uint GetColorPaletteCount();

		/// <summary>Get the number of entries in each color palette.</summary>
		/// <returns>
		/// The number of entries in each color palette. All color palettes in a font have the same number of palette entries. The return
		/// value is zero if the font has no color information.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getpaletteentrycount UINT32 GetPaletteEntryCount();
		[PreserveSig]
		new uint GetPaletteEntryCount();

		/// <summary>Gets color values from the font's color palette.</summary>
		/// <param name="colorPaletteIndex">
		/// Zero-based index of the color palette. If the font does not have a palette with the specified index, the method returns <b>DWRITE_E_NOCOLOR</b>.
		/// </param>
		/// <param name="firstEntryIndex">Zero-based index of the first palette entry to read.</param>
		/// <param name="entryCount">Number of palette entries to read.</param>
		/// <param name="paletteEntries">Array that receives the color values.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// The sum of <i>firstEntryIndex</i> and <i>entryCount</i> is greater than the actual number of palette entries that's returned by
		/// the <c>GetPaletteEntryCount</c> method.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DWRITE_E_NOCOLOR</description>
		/// <description>The font doesn't have a palette with the specified palette index.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getpaletteentries HRESULT
		// GetPaletteEntries( UINT32 colorPaletteIndex, UINT32 firstEntryIndex, UINT32 entryCount, [out] DWRITE_COLOR_F *paletteEntries );
		[PreserveSig]
		new HRESULT GetPaletteEntries(uint colorPaletteIndex, uint firstEntryIndex, uint entryCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_COLOR_F[] paletteEntries);

		/// <summary>
		/// Determines the recommended text rendering and grid-fit mode to be used based on the font, size, world transform, and measuring mode.
		/// </summary>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Logical font size in DIPs.</para>
		/// </param>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the horizontal direction.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the vertical direction.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>A <c>DWRITE_MATRIX</c> structure that describes the world transform.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Specifies whether the font is sideways. <b>TRUE</b> if the font is sideways; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <param name="outlineThreshold">
		/// <para>Type: <b><c>DWRITE_OUTLINE_THRESHOLD</c></b></para>
		/// <para>
		/// A <c>DWRITE_OUTLINE_THRESHOLD</c>-typed value that specifies the quality of the graphics system's outline rendering, affects the
		/// size threshold above which outline rendering is used.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_MEASURING_MODE</c>-typed value that specifies the method used to measure during text layout. For proper glyph
		/// spacing, this method returns a rendering mode that is compatible with the specified measuring mode.
		/// </para>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <b><c>IDWriteRenderingParams</c>*</b></para>
		/// <para>
		/// A pointer to a <c>IDWriteRenderingParams</c> interface for the rendering parameters object. This parameter is necessary in case
		/// the rendering parameters object overrides the rendering mode.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_RENDERING_MODE</c>-typed value for the recommended rendering mode.</para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_GRID_FIT_MODE</c>-typed value for the recommended grid-fit mode.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( [in] FLOAT fontEmSize, [in] FLOAT dpiX, [in] FLOAT dpiY, [in, optional] DWRITE_MATRIX const
		// *transform, [in] bool isSideways, [in] DWRITE_OUTLINE_THRESHOLD outlineThreshold, [in] DWRITE_MEASURING_MODE measuringMode, [in,
		// optional] IDWriteRenderingParams *renderingParams, [out] DWRITE_RENDERING_MODE *renderingMode, [out] DWRITE_GRID_FIT_MODE
		// *gridFitMode );
		new void GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			bool isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode, [In, Optional] IDWriteRenderingParams? renderingParams,
			out DWRITE_RENDERING_MODE renderingMode, out DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary>Gets a font face reference that identifies this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteFontFaceReference</c> interface for the newly created font
		/// face reference object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getfontfacereference HRESULT
		// GetFontFaceReference( [out] IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference GetFontFaceReference();

		/// <summary>Gets the PANOSE values from the font, used for font selection and matching.</summary>
		/// <param name="panose">
		/// <para>Type: <b><c>DWRITE_PANOSE</c>*</b></para>
		/// <para>A pointer to a <c>DWRITE_PANOSE</c> structure that receives the PANOSE values from the font.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't simulate these values, such as substituting a weight or proportion inferred on other values. If the font
		/// doesn't specify them, they are all set to 'any' (0).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getpanose void GetPanose( [out]
		// DWRITE_PANOSE *panose );
		[PreserveSig]
		new void GetPanose(out DWRITE_PANOSE panose);

		/// <summary>Gets the weight of this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_WEIGHT</c></b></para>
		/// <para>
		/// Returns a <c>DWRITE_FONT_WEIGHT</c>-typed value that specifies the density of a typeface, in terms of the lightness or heaviness
		/// of the strokes.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getweight DWRITE_FONT_WEIGHT GetWeight();
		[PreserveSig]
		new DWRITE_FONT_WEIGHT GetWeight();

		/// <summary>Gets the stretch (also known as width) of this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_STRETCH</c></b></para>
		/// <para>
		/// Returns a <c>DWRITE_FONT_STRETCH</c>-typed value that specifies the degree to which a font has been stretched compared to a
		/// font's normal aspect ratio.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getstretch DWRITE_FONT_STRETCH GetStretch();
		[PreserveSig]
		new DWRITE_FONT_STRETCH GetStretch();

		/// <summary>Gets the style (also known as slope) of this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_STYLE</c></b></para>
		/// <para>Returns a <c>DWRITE_FONT_STYLE</c>-typed value that specifies the style of the font.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getstyle DWRITE_FONT_STYLE GetStyle();
		[PreserveSig]
		new DWRITE_FONT_STYLE GetStyle();

		/// <summary>Creates a localized strings object that contains the family names for the font family, indexed by locale name.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteLocalizedStrings</c> interface for the newly created
		/// localized strings object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getfamilynames HRESULT GetFamilyNames(
		// [out] IDWriteLocalizedStrings **names );
		new IDWriteLocalizedStrings GetFamilyNames();

		/// <summary>
		/// Creates a localized strings object that contains the face names for the font (for example, Regular or Bold), indexed by locale name.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteLocalizedStrings</c> interface for the newly created
		/// localized strings object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getfacenames HRESULT GetFaceNames(
		// [out] IDWriteLocalizedStrings **names );
		new IDWriteLocalizedStrings GetFaceNames();

		/// <summary>Gets a localized strings collection that contains the specified informational strings, indexed by locale name.</summary>
		/// <param name="informationalStringID">
		/// <para>Type: <b><c>DWRITE_INFORMATIONAL_STRING_ID</c></b></para>
		/// <para>A <c>DWRITE_INFORMATIONAL_STRING_ID</c>-typed value that identifies the strings to get.</para>
		/// </param>
		/// <param name="informationalStrings">
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteLocalizedStrings</c> interface for the newly created
		/// localized strings object.
		/// </para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>
		/// A pointer to a variable that receives whether the font contains the specified string ID. <b>TRUE</b> if the font contains the
		/// specified string ID; otherwise, <b>FALSE</b>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>
		/// If the font doesn't contain the specified string, the return value is S_OK, but <i>informationalStrings</i> receives a
		/// <b>NULL</b> pointer and <i>exists</i> receives the value <b>FALSE</b>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getinformationalstrings HRESULT
		// GetInformationalStrings( [in] DWRITE_INFORMATIONAL_STRING_ID informationalStringID, [out] IDWriteLocalizedStrings
		// **informationalStrings, [out] BOOL *exists );
		new void GetInformationalStrings(DWRITE_INFORMATIONAL_STRING_ID informationalStringID, out IDWriteLocalizedStrings? informationalStrings,
			[MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Determines whether the font supports the specified character.</summary>
		/// <param name="unicodeValue">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>A Unicode (UCS-4) character value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>
		/// Returns whether the font supports the specified character. Returns <b>TRUE</b> if the font has the specified character;
		/// otherwise, <b>FALSE</b>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-hascharacter BOOL HasCharacter( [in]
		// UINT32 unicodeValue );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool HasCharacter(uint unicodeValue);

		/// <summary>
		/// Determines the recommended text rendering and grid-fit mode to be used based on the font, size, world transform, and measuring mode.
		/// </summary>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Logical font size in DIPs.</para>
		/// </param>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the horizontal direction.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the vertical direction.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>A <c>DWRITE_MATRIX</c> structure that describes the world transform.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies whether the font is sideways. <b>TRUE</b> if the font is sideways; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <param name="outlineThreshold">
		/// <para>Type: <b><c>DWRITE_OUTLINE_THRESHOLD</c></b></para>
		/// <para>
		/// A <c>DWRITE_OUTLINE_THRESHOLD</c>-typed value that specifies the quality of the graphics system's outline rendering, affects the
		/// size threshold above which outline rendering is used.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_MEASURING_MODE</c>-typed value that specifies the method used to measure during text layout. For proper glyph
		/// spacing, this method returns a rendering mode that is compatible with the specified measuring mode.
		/// </para>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <b><c>IDWriteRenderingParams</c>*</b></para>
		/// <para>
		/// A pointer to a <c>IDWriteRenderingParams</c> interface for the rendering parameters object. This parameter is necessary in case
		/// the rendering parameters object overrides the rendering mode.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_RENDERING_MODE1</c>-typed value for the recommended rendering mode.</para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_GRID_FIT_MODE</c>-typed value for the recommended grid-fit mode.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( [in] FLOAT fontEmSize, [in] FLOAT dpiX, [in] FLOAT dpiY, [in, optional] DWRITE_MATRIX const
		// *transform, [in] BOOL isSideways, [in] DWRITE_OUTLINE_THRESHOLD outlineThreshold, [in] DWRITE_MEASURING_MODE measuringMode, [in,
		// optional] IDWriteRenderingParams *renderingParams, [out] DWRITE_RENDERING_MODE1 *renderingMode, [out] DWRITE_GRID_FIT_MODE
		// *gridFitMode );
		new void GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			bool isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode,
			[In, Optional] IDWriteRenderingParams? renderingParams, out DWRITE_RENDERING_MODE1 renderingMode, out DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary><c>unicodeValue</c></summary>
		/// <param name="unicodeValue"/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontface3-ischaracterlocal BOOL
		// IsCharacterLocal( UINT32 unicodeValue );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsCharacterLocal(uint unicodeValue);

		/// <summary>Determines whether the glyph is locally downloaded from the font.</summary>
		/// <param name="glyphId">
		/// <para>Type: <b>UINT16</b></para>
		/// <para>Glyph identifier.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Returns TRUE if the font has the specified glyph locally available.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-isglyphlocal BOOL IsGlyphLocal( [in]
		// UINT16 glyphId );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsGlyphLocal(ushort glyphId);

		/// <summary>Determines whether the specified characters are local.</summary>
		/// <param name="characters">
		/// <para>Type: <b>WCHAR</b></para>
		/// <para>Array of characters.</para>
		/// </param>
		/// <param name="characterCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of elements in the character array.</para>
		/// </param>
		/// <param name="enqueueIfNotLocal">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies whether to enqueue a download request if any of the specified characters are not local.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if all of the specified characters are local, FALSE if any of the specified characters are remote.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-arecharacterslocal HRESULT
		// AreCharactersLocal( [in] WCHAR const *characters, UINT32 characterCount, BOOL enqueueIfNotLocal, [out] BOOL *isLocal );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool AreCharactersLocal([MarshalAs(UnmanagedType.LPWStr)] string characters, uint characterCount, bool enqueueIfNotLocal);

		/// <summary>Determines whether the specified glyphs are local.</summary>
		/// <param name="glyphIndices">
		/// <para>Type: <b>UINT16</b></para>
		/// <para>Array of glyph indices.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of elements in the glyph index array.</para>
		/// </param>
		/// <param name="enqueueIfNotLocal">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies whether to enqueue a download request if any of the specified glyphs are not local.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if all of the specified glyphs are local, FALSE if any of the specified glyphs are remote.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-areglyphslocal HRESULT AreGlyphsLocal(
		// [in] UINT16 const *glyphIndices, UINT32 glyphCount, BOOL enqueueIfNotLocal, [out] BOOL *isLocal );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool AreGlyphsLocal([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices, uint glyphCount, bool enqueueIfNotLocal);

		/// <summary>Gets all the glyph image formats supported for the specified glyph.</summary>
		/// <param name="glyphId">The identifier of the glyph to be queried.</param>
		/// <param name="pixelsPerEmFirst">The lowest pixels per em value to query.</param>
		/// <param name="pixelsPerEmLast">The highest pixels per em value to query.</param>
		/// <returns>An array of <c>DWRITE_GLYPH_IMAGE_FORMATS</c> specifying the supported formats for the requested glyph.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface4-getglyphimageformats(uint16_uint32_uint32_dwrite_glyph_image_formats)
		// HRESULT GetGlyphImageFormats( UINT16 glyphId, UINT32 pixelsPerEmFirst, UINT32 pixelsPerEmLast, DWRITE_GLYPH_IMAGE_FORMATS
		// *glyphImageFormats );
		new DWRITE_GLYPH_IMAGE_FORMATS GetGlyphImageFormats(ushort glyphId, uint pixelsPerEmFirst, uint pixelsPerEmLast);

		/// <summary>Gets all the glyph image formats supported by the entire font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_FORMATS</c></b></para>
		/// <para>Returns all the glyph image formats supported by the entire font.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface4-getglyphimageformats
		// DWRITE_GLYPH_IMAGE_FORMATS GetGlyphImageFormats();
		[PreserveSig]
		new DWRITE_GLYPH_IMAGE_FORMATS GetGlyphImageFormats();

		/// <summary>Gets a pointer to the glyph data based on the desired image format.</summary>
		/// <param name="glyphId">
		/// <para>Type: <b>UINT16</b></para>
		/// <para>The ID of the glyph to retrieve image data for.</para>
		/// </param>
		/// <param name="pixelsPerEm">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Requested pixels per em.</para>
		/// </param>
		/// <param name="glyphImageFormat">
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_FORMATS</c></b></para>
		/// <para>Specifies which formats are supported in the font.</para>
		/// </param>
		/// <param name="glyphData">
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_DATA</c>*</b></para>
		/// <para>On return contains data for a glyph.</para>
		/// </param>
		/// <param name="glyphDataContext">Type: <b>void**</b></param>
		/// <remarks>
		/// <para>
		/// The glyphDataContext must be released via <c>ReleaseGlyphImageData</c> when done if the data is not empty, similar to
		/// <c>IDWriteFontFileStream::ReadFileFragment</c> and <c>IDWriteFontFileStream::ReleaseFileFragment</c>. The data pointer is valid
		/// so long as the <c>IDWriteFontFace</c> exists and <b>ReleaseGlyphImageData</b> has not been called.
		/// </para>
		/// <para>
		/// The <c>DWRITE_GLYPH_IMAGE_DATA::uniqueDataId</c> is valuable for caching purposes so that if the same resource is returned more
		/// than once, an existing resource can be quickly retrieved rather than needing to reparse or decompress the data.
		/// </para>
		/// <para>
		/// The function only returns SVG or raster data - requesting TrueType/CFF/COLR data returns DWRITE_E_INVALIDARG. Those must be
		/// drawn via DrawGlyphRun or queried using GetGlyphOutline instead. Exactly one format may be requested or else the function
		/// returns DWRITE_E_INVALIDARG. If the glyph does not have that format, the call is not an error, but the function returns empty data.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface4-getglyphimagedata HRESULT
		// GetGlyphImageData( [in] UINT16 glyphId, UINT32 pixelsPerEm, DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat, [out]
		// DWRITE_GLYPH_IMAGE_DATA *glyphData, [out] void **glyphDataContext );
		new void GetGlyphImageData(ushort glyphId, uint pixelsPerEm, DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat, out DWRITE_GLYPH_IMAGE_DATA glyphData,
			out IntPtr glyphDataContext);

		/// <summary>Releases the table data obtained from ReadGlyphData.</summary>
		/// <param name="glyphDataContext">
		/// <para>Type: <b>void*</b></para>
		/// <para>Opaque context from ReadGlyphData.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface4-releaseglyphimagedata void
		// ReleaseGlyphImageData( void *glyphDataContext );
		[PreserveSig]
		new void ReleaseGlyphImageData([In] IntPtr glyphDataContext);

		/// <summary>Retrieves the number of axes defined by the font face. This includes both static and variable axes (see <c>DWRITE_FONT_AXIS_RANGE</c>).</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axes defined by the font face.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface5-getfontaxisvaluecount UINT32 GetFontAxisValueCount();
		[PreserveSig]
		new uint GetFontAxisValueCount();

		/// <summary>Retrieves the list of axis values used by the font.</summary>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c>*</b></para>
		/// <para>
		/// A pointer to an array of <b>DWRITE_FONT_AXIS_VALUE</b> structures into which <b>GetFontAxisValues</b> writes the list of font
		/// axis values. You're responsible for managing the size and the lifetime of this array. Call <c>GetFontAxisValueCount</c> to
		/// determine the size of array to allocate.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The maximum number of font axis values to write into the memory block pointed to by <c>fontAxisValues</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// <code>fontAxisValueCount</code>
		/// doesn't match the value returned by <b>GetFontAxisValueCount</b>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The values are returned in the canonical order defined by the font, clamped to the actual range supported. It's not necessarily
		/// the same axis value array that you passed to <b>CreateFontFace</b>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface5-getfontaxisvalues HRESULT
		// GetFontAxisValues( [out] DWRITE_FONT_AXIS_VALUE *fontAxisValues, UINT32 fontAxisValueCount );
		new void GetFontAxisValues([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);

		/// <summary>
		/// Determines whether this font face's resource supports any variable axes. When <c>true</c>, at least one
		/// <c>DWRITE_FONT_AXIS_RANGE</c> in the font resource has a non-empty range (maxValue &gt; minValue).
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>BOOL</c></b></para>
		/// <para><c>true</c> if the font face's resource supports any variable axes. Otherwise, <c>false</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface5-hasvariations BOOL HasVariations();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool HasVariations();

		/// <summary>
		/// Retrieves the underlying font resource for this font face. You can use that to query information about the resource, or to
		/// recreate a new font face instance with different axis values.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontResource</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontResource</c> interface. On successful completion, the function sets the pointer to
		/// a newly created font resource object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface5-getfontresource HRESULT
		// GetFontResource( [out] IDWriteFontResource **fontResource );
		new IDWriteFontResource GetFontResource();

		/// <summary>
		/// Performs an equality comparison between the font face object on which <b>Equals</b> is being called and the font face object
		/// passed as a parameter.
		/// </summary>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>A pointer to a font face object to compare with the font face object on which <b>Equals</b> is being called.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>BOOL</c></b></para>
		/// <para><c>true</c> if the font face objects are equal. Otherwise, <c>false</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface5-equals BOOL Equals( IDWriteFontFace
		// *fontFace );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool Equals(IDWriteFontFace fontFace);

		/// <summary>Gets the family names.</summary>
		/// <param name="fontFamilyModel">The font family model.</param>
		/// <returns></returns>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontface6-getfamilynames HRESULT
		// GetFamilyNames( DWRITE_FONT_FAMILY_MODEL fontFamilyModel, IDWriteLocalizedStrings **names );
		IDWriteLocalizedStrings GetFamilyNames(DWRITE_FONT_FAMILY_MODEL fontFamilyModel);

		/// <summary>Gets the face names.</summary>
		/// <param name="fontFamilyModel">The font family model.</param>
		/// <returns></returns>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontface6-getfacenames HRESULT
		// GetFaceNames( DWRITE_FONT_FAMILY_MODEL fontFamilyModel, IDWriteLocalizedStrings **names );
		IDWriteLocalizedStrings GetFaceNames(DWRITE_FONT_FAMILY_MODEL fontFamilyModel);
	}

	/// <summary>The <b>IDWriteFontFace7</b> interface inherits from the IDWriteFontFace6 interface.</summary>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nn-dwrite_3-idwritefontface7
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontFace7")]
	[ComImport, Guid("3945B85B-BC95-40F7-B72C-8B73BFC7E13B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontFace7 : IDWriteFontFace, IDWriteFontFace1, IDWriteFontFace2, IDWriteFontFace3, IDWriteFontFace4, IDWriteFontFace5, IDWriteFontFace6
	{
		/// <summary>Obtains the file format type of a font face.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_FACE_TYPE</c></para>
		/// <para>A value that indicates the type of format for the font face (such as Type 1, TrueType, vector, or bitmap).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-gettype DWRITE_FONT_FACE_TYPE GetType();
		[PreserveSig]
		new DWRITE_FONT_FACE_TYPE GetType();

		/// <summary>Obtains the font files representing a font face.</summary>
		/// <param name="numberOfFiles">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// If fontFiles is <c>NULL</c>, receives the number of files representing the font face. Otherwise, the number of font files being
		/// requested should be passed. See the Remarks section below for more information.
		/// </para>
		/// </param>
		/// <param name="fontFiles">
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a user-provided array that stores pointers to font files representing the font
		/// face. This parameter can be <c>NULL</c> if the user wants only the number of files representing the font face. This API
		/// increments reference count of the font file pointers returned according to COM conventions, and the client should release them
		/// when finished.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The <c>IDWriteFontFace::GetFiles</c> method should be called twice. The first time you call <c>GetFiles</c> fontFiles should be
		/// <c>NULL</c>. When the method returns, numberOfFiles receives the number of font files that represent the font face.
		/// </para>
		/// <para>
		/// Then, call the method a second time, passing the numberOfFiles value that was output the first call, and a non-null buffer of
		/// the correct size to store the IDWriteFontFile pointers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getfiles HRESULT GetFiles( UINT32
		// *numberOfFiles, IDWriteFontFile **fontFiles );
		new void GetFiles(ref uint numberOfFiles, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] IDWriteFontFile[]? fontFiles);

		/// <summary>Obtains the index of a font face in the context of its font files.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The zero-based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value is zero.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getindex UINT32 GetIndex();
		[PreserveSig]
		new uint GetIndex();

		/// <summary>Obtains the algorithmic style simulation flags of a font face.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>Font face simulation flags for algorithmic means of making text bold or italic.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getsimulations DWRITE_FONT_SIMULATIONS GetSimulations();
		[PreserveSig]
		new DWRITE_FONT_SIMULATIONS GetSimulations();

		/// <summary>Determines whether the font is a symbol font.</summary>
		/// <returns>
		/// <para>Type: <c>bool</c></para>
		/// <para>Returns <c>TRUE</c> if the font is a symbol font, otherwise <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-issymbolfont bool IsSymbolFont();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsSymbolFont();

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a font face and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="fontFaceMetrics">
		/// <para>Type: <c>DWRITE_FONT_METRICS*</c></para>
		/// <para>
		/// When this method returns, a DWRITE_FONT_METRICS structure that holds metrics (such as ascent, descent, or cap height) for the
		/// current font face element. The metrics returned by this function are in font design units.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getmetrics void GetMetrics(
		// DWRITE_FONT_METRICS *fontFaceMetrics );
		[PreserveSig]
		new void GetMetrics(out DWRITE_FONT_METRICS fontFaceMetrics);

		/// <summary>Obtains the number of glyphs in the font face.</summary>
		/// <returns>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>The number of glyphs in the font face.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphcount UINT16 GetGlyphCount();
		[PreserveSig]
		new ushort GetGlyphCount();

		/// <summary>Obtains ideal (resolution-independent) glyph metrics in font design units.</summary>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>
		/// An array of glyph indices for which to compute metrics. The array must contain at least as many elements as specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the glyphIndices array.</para>
		/// </param>
		/// <param name="glyphMetrics">
		/// <para>Type: <c>DWRITE_GLYPH_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains an array of DWRITE_GLYPH_METRICS structures. glyphMetrics must be initialized with an empty
		/// buffer that contains at least as many elements as glyphCount. The metrics returned by this function are in font design units.
		/// </para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// Indicates whether the font is being used in a sideways run. This can affect the glyph metrics if the font has oblique simulation
		/// because sideways oblique simulation differs from non-sideways oblique simulation
		/// </para>
		/// </param>
		/// <remarks>Design glyph metrics are used for glyph positioning.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getdesignglyphmetrics HRESULT
		// GetDesignGlyphMetrics( UINT16 const *glyphIndices, UINT32 glyphCount, DWRITE_GLYPH_METRICS *glyphMetrics, bool isSideways );
		new void GetDesignGlyphMetrics([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices, uint glyphCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_GLYPH_METRICS[] glyphMetrics, [MarshalAs(UnmanagedType.Bool)] bool isSideways = false);

		/// <summary>Returns the nominal mapping of UCS4 Unicode code points to glyph indices as defined by the font 'CMAP' table.</summary>
		/// <param name="codePoints">
		/// <para>Type: <c>const UINT32*</c></para>
		/// <para>
		/// An array of USC4 code points from which to obtain nominal glyph indices. The array must be allocated and be able to contain the
		/// number of elements specified by codePointCount.
		/// </para>
		/// </param>
		/// <param name="codePointCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the codePoints array.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>UINT16*</c></para>
		/// <para>When this method returns, contains a pointer to an array of nominal glyph indices filled by this function.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Note that this mapping is primarily provided for line layout engines built on top of the physical font API. Because of OpenType
		/// glyph substitution and line layout character substitution, the nominal conversion does not always correspond to how a Unicode
		/// string will map to glyph indices when rendering using a particular font face. Also, note that Unicode variant selectors provide
		/// for alternate mappings for character to glyph. This call will always return the default variant.
		/// </para>
		/// <para>
		/// When characters are not present in the font this method returns the index 0, which is the undefined glyph or ".notdef" glyph. If
		/// a character isn't in a font, IDWriteFont::HasCharacter returns false and GetUnicodeRanges doesn't return it in the range.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphindices HRESULT GetGlyphIndices(
		// UINT32 const *codePoints, UINT32 codePointCount, UINT16 *glyphIndices );
		new void GetGlyphIndices([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] codePoints, uint codePointCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices);

		/// <summary>
		/// Finds the specified OpenType font table if it exists and returns a pointer to it. The function accesses the underlying font data
		/// through the IDWriteFontFileStream interface implemented by the font file loader.
		/// </summary>
		/// <param name="openTypeTableTag">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The four-character tag of a OpenType font table to find. Use the <c>DWRITE_MAKE_OPENTYPE_TAG</c> macro to create it as an
		/// <c>UINT32</c>. Unlike GDI, it does not support the special TTCF and null tags to access the whole font.
		/// </para>
		/// </param>
		/// <param name="tableData">
		/// <para>Type: <c>const void**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the base of the table in memory. The pointer is valid only as
		/// long as the font face used to get the font table still exists; (not any other font face, even if it actually refers to the same
		/// physical font). This parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <param name="tableSize">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains a pointer to the size, in bytes, of the font table.</para>
		/// </param>
		/// <param name="tableContext">
		/// <para>Type: <c>void**</c></para>
		/// <para>
		/// When this method returns, the address of a pointer to the opaque context, which must be freed by calling ReleaseFontTable. The
		/// context actually comes from the lower-level IDWriteFontFileStream, which may be implemented by the application or DWrite itself.
		/// It is possible for a <c>NULL</c> tableContext to be returned, especially if the implementation performs direct memory mapping on
		/// the whole file. Nevertheless, always release it later, and do not use it as a test for function success. The same table can be
		/// queried multiple times, but because each returned context can be different, you must release each context separately.
		/// </para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <c>bool*</c></para>
		/// <para>When this method returns, <c>TRUE</c> if the font table exists; otherwise, <c>FALSE</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The context for the same tag may be different for each call, so each one must be held and released separately.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-trygetfonttable HRESULT TryGetFontTable(
		// UINT32 openTypeTableTag, const void **tableData, UINT32 *tableSize, void **tableContext, bool *exists );
		new HRESULT TryGetFontTable([In] uint openTypeTableTag, out IntPtr tableData, out uint tableSize, out IntPtr tableContext, [MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Releases the table obtained earlier from TryGetFontTable.</summary>
		/// <param name="tableContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>A pointer to the opaque context from TryGetFontTable.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-releasefonttable void ReleaseFontTable( void
		// *tableContext );
		[PreserveSig]
		new void ReleaseFontTable([In] IntPtr tableContext);

		/// <summary>Computes the outline of a run of glyphs by calling back to the outline sink interface.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>
		/// An array of glyph indices. The glyphs are in logical order and the advance direction depends on the isRightToLeft parameter. The
		/// array must be allocated and be able to contain the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <c>const FLOAT*</c></para>
		/// <para>
		/// An optional array of glyph advances in DIPs. The advance of a glyph is the amount to advance the position (in the direction of
		/// the baseline) after drawing the glyph. glyphAdvances contains the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphOffsets">
		/// <para>Type: <c>const DWRITE_GLYPH_OFFSET*</c></para>
		/// <para>
		/// An optional array of glyph offsets, each of which specifies the offset along the baseline and offset perpendicular to the
		/// baseline of a glyph relative to the current pen position. glyphOffsets contains the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of glyphs in the run.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// If <c>TRUE</c>, the ascender of the glyph runs alongside the baseline. If <c>FALSE</c>, the glyph ascender runs perpendicular to
		/// the baseline. For example, an English alphabet on a vertical baseline would have isSideways set to <c>FALSE</c>.
		/// </para>
		/// <para>
		/// A client can render a vertical run by setting isSideways to <c>TRUE</c> and rotating the resulting geometry 90 degrees to the
		/// right using a transform. The isSideways and isRightToLeft parameters cannot both be true.
		/// </para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// The visual order of the glyphs. If this parameter is <c>FALSE</c>, then glyph advances are from left to right. If <c>TRUE</c>,
		/// the advance direction is right to left. By default, the advance direction is left to right.
		/// </para>
		/// </param>
		/// <param name="geometrySink">
		/// <para>Type: <c>IDWriteGeometrySink*</c></para>
		/// <para>A pointer to the interface that is called back to perform outline drawing operations.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphrunoutline HRESULT
		// GetGlyphRunOutline( FLOAT emSize, UINT16 const *glyphIndices, FLOAT const *glyphAdvances, DWRITE_GLYPH_OFFSET const
		// *glyphOffsets, UINT32 glyphCount, bool isSideways, bool isRightToLeft, IDWriteGeometrySink *geometrySink );
		new void GetGlyphRunOutline(float emSize, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ushort[] glyphIndices,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[]? glyphAdvances,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_GLYPH_OFFSET[]? glyphOffsets,
			uint glyphCount, [MarshalAs(UnmanagedType.Bool)] bool isSideways, [MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
			[In, MarshalAs(UnmanagedType.Interface)] object geometrySink);

		/// <summary>Determines the recommended rendering mode for the font, using the specified size and rendering parameters.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96, this value is 1.0f. If the DPI is
		/// 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>
		/// The measuring method that will be used for glyphs in the font. Renderer implementations may choose different rendering modes for
		/// different measuring methods, for example:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL for DWRITE_MEASURING_MODE_NATURAL</term>
		/// </item>
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC for DWRITE_MEASURING_MODE_GDI_CLASSIC</term>
		/// </item>
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL for DWRITE_MEASURING_MODE_GDI_NATURAL</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>
		/// A pointer to an object that contains rendering settings such as gamma level, enhanced contrast, and ClearType level. This
		/// parameter is necessary in case the rendering parameters object overrides the rendering mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWRITE_RENDERING_MODE*</c></para>
		/// <para>When this method returns, contains a value that indicates the recommended rendering mode to use.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MEASURING_MODE measuringMode, IDWriteRenderingParams
		// *renderingParams, DWRITE_RENDERING_MODE *renderingMode );
		new DWRITE_RENDERING_MODE GetRecommendedRenderingMode(float emSize, float pixelsPerDip, DWRITE_MEASURING_MODE measuringMode, IDWriteRenderingParams renderingParams);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a fontface and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_METRICS*</c></para>
		/// <para>A pointer to a DWRITE_FONT_METRICS structure to fill in. The metrics returned by this function are in font design units.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getgdicompatiblemetrics HRESULT
		// GetGdiCompatibleMetrics( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, DWRITE_FONT_METRICS
		// *fontFaceMetrics );
		new DWRITE_FONT_METRICS GetGdiCompatibleMetrics(float emSize, float pixelsPerDip, [In, Optional] IntPtr transform);

		/// <summary>Obtains glyph metrics in font design units with the return values compatible with what GDI would produce.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The ogical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// When set to <c>FALSE</c>, the metrics are the same as the metrics of GDI aliased text. When set to <c>TRUE</c>, the metrics are
		/// the same as the metrics of text measured by GDI using a font created with <c>CLEARTYPE_NATURAL_QUALITY</c>.
		/// </para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>An array of glyph indices for which to compute the metrics.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the glyphIndices array.</para>
		/// </param>
		/// <param name="glyphMetrics">
		/// <para>Type: <c>DWRITE_GLYPH_METRICS*</c></para>
		/// <para>An array of DWRITE_GLYPH_METRICS structures filled by this function. The metrics are in font design units.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>bool</c></para>
		/// <para>
		/// A bool value that indicates whether the font is being used in a sideways run. This can affect the glyph metrics if the font has
		/// oblique simulation because sideways oblique simulation differs from non-sideways oblique simulation.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getgdicompatibleglyphmetrics HRESULT
		// GetGdiCompatibleGlyphMetrics( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, bool useGdiNatural, UINT16 const
		// *glyphIndices, UINT32 glyphCount, DWRITE_GLYPH_METRICS *glyphMetrics, bool isSideways );
		new void GetGdiCompatibleGlyphMetrics(float emSize, float pixelsPerDip, [In, Optional] IntPtr transform, [MarshalAs(UnmanagedType.Bool)] bool useGdiNatural,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ushort[] glyphIndices, uint glyphCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] DWRITE_GLYPH_METRICS[] glyphMetrics, [MarshalAs(UnmanagedType.Bool)] bool isSideways = false);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a font face and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="fontMetrics">
		/// <para>Type: <b><c>DWRITE_FONT_METRICS1</c>*</b></para>
		/// <para>
		/// A filled <c>DWRITE_FONT_METRICS1</c> structure that holds metrics for the current font face element. The metrics returned by
		/// this method are in font design units.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getmetrics void GetMetrics( [out]
		// DWRITE_FONT_METRICS1 *fontMetrics );
		[PreserveSig]
		new void GetMetrics(out DWRITE_FONT_METRICS1 fontMetrics);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a fontface and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="emSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The logical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and <i>pixelsPerDip</i>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_METRICS1</c>*</b></para>
		/// <para>
		/// A pointer to a <c>DWRITE_FONT_METRICS1</c> structure to fill in. The metrics returned by this function are in font design units.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getgdicompatiblemetrics HRESULT
		// GetGdiCompatibleMetrics( FLOAT emSize, FLOAT pixelsPerDip, [in, optional] DWRITE_MATRIX const *transform, [out]
		// DWRITE_FONT_METRICS1 *fontMetrics );
		new DWRITE_FONT_METRICS1 GetGdiCompatibleMetrics(float emSize, float pixelsPerDip, [In, Optional] StructPointer<DWRITE_MATRIX> transform);

		/// <summary>Gets caret metrics for the font in design units.</summary>
		/// <param name="caretMetrics">
		/// <para>Type: <b>DWRITE_CARET_METRICS*</b></para>
		/// <para>A pointer to the <c>DWRITE_CARET_METRICS</c> structure that is filled.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>Caret metrics are used by text editors for drawing the correct caret placement and slant.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getcaretmetrics void GetCaretMetrics(
		// [out] DWRITE_CARET_METRICS *caretMetrics );
		[PreserveSig]
		new void GetCaretMetrics(out DWRITE_CARET_METRICS caretMetrics);

		/// <summary>Retrieves a list of character ranges supported by a font.</summary>
		/// <param name="maxRangeCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Maximum number of character ranges passed in from the client.</para>
		/// </param>
		/// <param name="unicodeRanges">
		/// <para>Type: <b><c>DWRITE_UNICODE_RANGE</c>*</b></para>
		/// <para>An array of <c>DWRITE_UNICODE_RANGE</c> structures that are filled with the character ranges.</para>
		/// </param>
		/// <param name="actualRangeCount">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>A pointer to the actual number of character ranges, regardless of the maximum count.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// A list of character ranges supported by the font is useful for scenarios like character picking, glyph display, and efficient
		/// font selection lookup. This is similar to GDI's <c>GetFontUnicodeRanges</c>, except that it returns the full Unicode range, not
		/// just 16-bit UCS-2.
		/// </para>
		/// <para>These ranges are from the cmap, not the OS/2::ulCodePageRange1.</para>
		/// <para>
		/// If this method is unavailable, you can use the <c>IDWriteFontFace::GetGlyphIndices</c> method to check for missing glyphs. The
		/// method returns the 0 index for glyphs that aren't present in the font.
		/// </para>
		/// <para>
		/// The <c>IDWriteFont::HasCharacter</c> method is often simpler in cases where you need to check a single character or a series of
		/// single characters in succession, such as in font fallback.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getunicoderanges HRESULT
		// GetUnicodeRanges( UINT32 maxRangeCount, [out, optional] DWRITE_UNICODE_RANGE *unicodeRanges, [out] UINT32 *actualRangeCount );
		new void GetUnicodeRanges(int maxRangeCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DWRITE_UNICODE_RANGE[]? unicodeRanges, out uint actualRangeCount);

		/// <summary>
		/// Determines whether the font of a text range is monospaced, that is, the font characters are the same fixed-pitch width.
		/// </summary>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns TRUE if the font is monospaced, otherwise it returns FALSE.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-ismonospacedfont bool IsMonospacedFont();
		[PreserveSig]
		new bool IsMonospacedFont();

		/// <summary>Retrieves the advances in design units for a sequences of glyphs.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of glyphs to retrieve advances for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve advances for.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <b>INT32*</b></para>
		/// <para>The returned advances in font design units for each glyph.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Retrieve the glyph's vertical advance height rather than horizontal advance widths.</para>
		/// </param>
		/// <remarks>This is equivalent to calling GetGlyphMetrics and using only the advance width and height.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getdesignglyphadvances HRESULT
		// GetDesignGlyphAdvances( UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvances, bool isSideways );
		new void GetDesignGlyphAdvances(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] glyphAdvances, bool isSideways = false);

		/// <summary>Returns the pixel-aligned advances for a sequences of glyphs.</summary>
		/// <param name="emSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// Number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96 this value is 1.0f. If the DPI is 120,
		/// this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the font
		/// size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <b>bool</b></para>
		/// <para>
		/// When FALSE, the metrics are the same as GDI aliased text (DWRITE_MEASURING_MODE_GDI_CLASSIC). When TRUE, the metrics are the
		/// same as those measured by GDI using a font using CLEARTYPE_NATURAL_QUALITY (DWRITE_MEASURING_MODE_GDI_NATURAL).
		/// </para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Retrieve the glyph's vertical advances rather than horizontal advances.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Total glyphs to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve advances.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <b>const INT32*</b></para>
		/// <para>The returned advances in font design units for each glyph.</para>
		/// </param>
		/// <remarks>
		/// <para>This is equivalent to calling <c>GetGdiCompatibleGlyphMetrics</c> and using only the advance width and height.</para>
		/// <para>Like <c>GetGdiCompatibleGlyphMetrics</c>, these are in design units, meaning they must be scaled down by DWRITE_FONT_METRICS::designUnitsPerEm.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getgdicompatibleglyphadvances HRESULT
		// GetGdiCompatibleGlyphAdvances( FLOAT emSize, FLOAT pixelsPerDip, [in, optional] DWRITE_MATRIX const *transform, bool
		// useGdiNatural, bool isSideways, UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvances );
		new void GetGdiCompatibleGlyphAdvances(float emSize, float pixelsPerDip, [In, Optional] StructPointer<DWRITE_MATRIX> transform, bool useGdiNatural,
			bool isSideways, int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] int[] glyphAdvances);

		/// <summary>Retrieves the kerning pair adjustments from the font's kern table.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Number of glyphs to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphAdvanceAdjustments">
		/// <para>Type: <b>INT32*</b></para>
		/// <para>The advances, returned in font design units, for each glyph. The last glyph adjustment is zero.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <b>GetKerningPairAdjustments</b> isn't a direct replacement for GDI's character based <c>GetKerningPairs</c>, but it serves the
		/// same role, without the client needing to cache them locally. <b>GetKerningPairAdjustments</b> also uses glyph id's directly
		/// rather than UCS-2 characters (how the kern table actually stores them), which avoids glyph collapse and ambiguity, such as the
		/// dash and hyphen, or space and non-breaking space.
		/// </para>
		/// <para>
		/// Newer fonts may have only GPOS kerning instead of the legacy pair-table kerning. Such fonts, like Gabriola, will only return 0's
		/// for adjustments. <b>GetKerningPairAdjustments</b> doesn't virtualize and flatten these GPOS entries into kerning pairs.
		/// </para>
		/// <para>
		/// You can realize a performance benefit by calling <c>IDWriteFontFace1::HasKerningPairs</c> to determine whether you need to call
		/// <b>GetKerningPairAdjustments</b>. If you previously called <b>IDWriteFontFace1::HasKerningPairs</b> and it returned FALSE, you
		/// can avoid calling <b>GetKerningPairAdjustments</b> because the font has no kerning pair-table entries. That is, in this
		/// situation, a call to <b>GetKerningPairAdjustments</b> would be a no-op.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getkerningpairadjustments HRESULT
		// GetKerningPairAdjustments( UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvanceAdjustments );
		new void GetKerningPairAdjustments(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] glyphAdvanceAdjustments);

		/// <summary>Determines whether the font supports pair-kerning.</summary>
		/// <returns>Returns TRUE if the font supports kerning pairs, otherwise FALSE.</returns>
		/// <remarks>
		/// If the font doesn't support pair table kerning, you don't need to call <c>IDWriteFontFace1::GetKerningPairAdjustments</c>
		/// because it would retrieve all zeroes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-haskerningpairs bool HasKerningPairs();
		[PreserveSig]
		new bool HasKerningPairs();

		/// <summary>Determines the recommended rendering mode for the font, using the specified size and rendering parameters.</summary>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The number of physical pixels per DIP in a horizontal position. For example, if the DPI of the rendering surface is 96, this
		/// value is 1.0f. If the DPI is 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The number of physical pixels per DIP in a vertical position. For example, if the DPI of the rendering surface is 96, this value
		/// is 1.0f. If the DPI is 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const DWRITE_MATRIX*</b></para>
		/// <para>Specifies the world transform.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Whether the glyphs in the run are sideways or not.</para>
		/// </param>
		/// <param name="outlineThreshold">
		/// <para>Type: <b><c>DWRITE_OUTLINE_THRESHOLD</c></b></para>
		/// <para>
		/// A <c>DWRITE_OUTLINE_THRESHOLD</c>-typed value that specifies the quality of the graphics system's outline rendering, affects the
		/// size threshold above which outline rendering is used.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// The measuring method that will be used for glyphs in the font. Renderer implementations may choose different rendering modes for
		/// different measuring methods, for example:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL for <c>DWRITE_MEASURING_MODE_NATURAL</c></description>
		/// </item>
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC for <c>DWRITE_MEASURING_MODE_GDI_CLASSIC</c></description>
		/// </item>
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL for <c>DWRITE_MEASURING_MODE_GDI_NATURAL</c></description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c>*</b></para>
		/// <para>When this method returns, contains a value that indicates the recommended rendering mode to use.</para>
		/// </returns>
		/// <remarks>
		/// This method should be used to determine the actual rendering mode in cases where the rendering mode of the rendering params
		/// object is DWRITE_RENDERING_MODE_DEFAULT.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( FLOAT fontEmSize, FLOAT dpiX, FLOAT dpiY, [in, optional] DWRITE_MATRIX const *transform, bool
		// isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode, [out] DWRITE_RENDERING_MODE
		// *renderingMode );
		new DWRITE_RENDERING_MODE GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			bool isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode);

		/// <summary>Retrieves the vertical forms of the nominal glyphs retrieved from GetGlyphIndices.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of glyphs to retrieve.</para>
		/// </param>
		/// <param name="nominalGlyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>Original glyph indices from cmap.</para>
		/// </param>
		/// <param name="verticalGlyphIndices">
		/// <para>Type: <b>UINT16*</b></para>
		/// <para>The vertical form of glyph indices.</para>
		/// </param>
		/// <remarks>
		/// <para>The retrieval uses the font's 'vert' table. This is used in CJK vertical layout so the correct characters are shown.</para>
		/// <para>
		/// Call <c>GetGlyphIndices</c> to get the nominal glyph indices, followed by calling this to remap the to the substituted forms,
		/// when the run is sideways, and the font has vertical glyph variants. See <c>HasVerticalGlyphVariants</c> for more info.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getverticalglyphvariants HRESULT
		// GetVerticalGlyphVariants( UINT32 glyphCount, [in] UINT16 const *nominalGlyphIndices, [out] UINT16 *verticalGlyphIndices );
		new void GetVerticalGlyphVariants(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] nominalGlyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] verticalGlyphIndices);

		/// <summary>Determines whether the font has any vertical glyph variants.</summary>
		/// <returns>Returns TRUE if the font contains vertical glyph variants, otherwise FALSE.</returns>
		/// <remarks>
		/// <para>For OpenType fonts, <b>HasVerticalGlyphVariants</b> returns TRUE if the font contains a "vert"feature.</para>
		/// <para>
		/// <c>IDWriteFontFace1::GetVerticalGlyphVariants</c> retrieves the vertical forms of the nominal glyphs that are retrieved from <c>IDWriteFontFace::GetGlyphIndices</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-hasverticalglyphvariants bool HasVerticalGlyphVariants();
		[PreserveSig]
		new bool HasVerticalGlyphVariants();

		/// <summary>Allows you to determine if a color rendering path is potentially necessary.</summary>
		/// <returns>
		/// <para>Type: <b>bool</b></para>
		/// <para>Returns <b>TRUE</b> if a color rendering path is potentially necessary.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-iscolorfont bool IsColorFont();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsColorFont();

		/// <summary>Gets the number of color palettes defined by the font.</summary>
		/// <returns>
		/// The return value is zero if the font has no color information. Color fonts are required to define at least one palette, with
		/// palette index zero reserved as the default palette.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getcolorpalettecount UINT32 GetColorPaletteCount();
		[PreserveSig]
		new uint GetColorPaletteCount();

		/// <summary>Get the number of entries in each color palette.</summary>
		/// <returns>
		/// The number of entries in each color palette. All color palettes in a font have the same number of palette entries. The return
		/// value is zero if the font has no color information.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getpaletteentrycount UINT32 GetPaletteEntryCount();
		[PreserveSig]
		new uint GetPaletteEntryCount();

		/// <summary>Gets color values from the font's color palette.</summary>
		/// <param name="colorPaletteIndex">
		/// Zero-based index of the color palette. If the font does not have a palette with the specified index, the method returns <b>DWRITE_E_NOCOLOR</b>.
		/// </param>
		/// <param name="firstEntryIndex">Zero-based index of the first palette entry to read.</param>
		/// <param name="entryCount">Number of palette entries to read.</param>
		/// <param name="paletteEntries">Array that receives the color values.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// The sum of <i>firstEntryIndex</i> and <i>entryCount</i> is greater than the actual number of palette entries that's returned by
		/// the <c>GetPaletteEntryCount</c> method.
		/// </description>
		/// </item>
		/// <item>
		/// <description>DWRITE_E_NOCOLOR</description>
		/// <description>The font doesn't have a palette with the specified palette index.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getpaletteentries HRESULT
		// GetPaletteEntries( UINT32 colorPaletteIndex, UINT32 firstEntryIndex, UINT32 entryCount, [out] DWRITE_COLOR_F *paletteEntries );
		[PreserveSig]
		new HRESULT GetPaletteEntries(uint colorPaletteIndex, uint firstEntryIndex, uint entryCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_COLOR_F[] paletteEntries);

		/// <summary>
		/// Determines the recommended text rendering and grid-fit mode to be used based on the font, size, world transform, and measuring mode.
		/// </summary>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Logical font size in DIPs.</para>
		/// </param>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the horizontal direction.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the vertical direction.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>A <c>DWRITE_MATRIX</c> structure that describes the world transform.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>bool</b></para>
		/// <para>Specifies whether the font is sideways. <b>TRUE</b> if the font is sideways; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <param name="outlineThreshold">
		/// <para>Type: <b><c>DWRITE_OUTLINE_THRESHOLD</c></b></para>
		/// <para>
		/// A <c>DWRITE_OUTLINE_THRESHOLD</c>-typed value that specifies the quality of the graphics system's outline rendering, affects the
		/// size threshold above which outline rendering is used.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_MEASURING_MODE</c>-typed value that specifies the method used to measure during text layout. For proper glyph
		/// spacing, this method returns a rendering mode that is compatible with the specified measuring mode.
		/// </para>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <b><c>IDWriteRenderingParams</c>*</b></para>
		/// <para>
		/// A pointer to a <c>IDWriteRenderingParams</c> interface for the rendering parameters object. This parameter is necessary in case
		/// the rendering parameters object overrides the rendering mode.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_RENDERING_MODE</c>-typed value for the recommended rendering mode.</para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_GRID_FIT_MODE</c>-typed value for the recommended grid-fit mode.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontface2-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( [in] FLOAT fontEmSize, [in] FLOAT dpiX, [in] FLOAT dpiY, [in, optional] DWRITE_MATRIX const
		// *transform, [in] bool isSideways, [in] DWRITE_OUTLINE_THRESHOLD outlineThreshold, [in] DWRITE_MEASURING_MODE measuringMode, [in,
		// optional] IDWriteRenderingParams *renderingParams, [out] DWRITE_RENDERING_MODE *renderingMode, [out] DWRITE_GRID_FIT_MODE
		// *gridFitMode );
		new void GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			bool isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode, [In, Optional] IDWriteRenderingParams? renderingParams,
			out DWRITE_RENDERING_MODE renderingMode, out DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary>Gets a font face reference that identifies this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteFontFaceReference</c> interface for the newly created font
		/// face reference object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getfontfacereference HRESULT
		// GetFontFaceReference( [out] IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference GetFontFaceReference();

		/// <summary>Gets the PANOSE values from the font, used for font selection and matching.</summary>
		/// <param name="panose">
		/// <para>Type: <b><c>DWRITE_PANOSE</c>*</b></para>
		/// <para>A pointer to a <c>DWRITE_PANOSE</c> structure that receives the PANOSE values from the font.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't simulate these values, such as substituting a weight or proportion inferred on other values. If the font
		/// doesn't specify them, they are all set to 'any' (0).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getpanose void GetPanose( [out]
		// DWRITE_PANOSE *panose );
		[PreserveSig]
		new void GetPanose(out DWRITE_PANOSE panose);

		/// <summary>Gets the weight of this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_WEIGHT</c></b></para>
		/// <para>
		/// Returns a <c>DWRITE_FONT_WEIGHT</c>-typed value that specifies the density of a typeface, in terms of the lightness or heaviness
		/// of the strokes.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getweight DWRITE_FONT_WEIGHT GetWeight();
		[PreserveSig]
		new DWRITE_FONT_WEIGHT GetWeight();

		/// <summary>Gets the stretch (also known as width) of this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_STRETCH</c></b></para>
		/// <para>
		/// Returns a <c>DWRITE_FONT_STRETCH</c>-typed value that specifies the degree to which a font has been stretched compared to a
		/// font's normal aspect ratio.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getstretch DWRITE_FONT_STRETCH GetStretch();
		[PreserveSig]
		new DWRITE_FONT_STRETCH GetStretch();

		/// <summary>Gets the style (also known as slope) of this font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_STYLE</c></b></para>
		/// <para>Returns a <c>DWRITE_FONT_STYLE</c>-typed value that specifies the style of the font.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getstyle DWRITE_FONT_STYLE GetStyle();
		[PreserveSig]
		new DWRITE_FONT_STYLE GetStyle();

		/// <summary>Creates a localized strings object that contains the family names for the font family, indexed by locale name.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteLocalizedStrings</c> interface for the newly created
		/// localized strings object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getfamilynames HRESULT GetFamilyNames(
		// [out] IDWriteLocalizedStrings **names );
		new IDWriteLocalizedStrings GetFamilyNames();

		/// <summary>
		/// Creates a localized strings object that contains the face names for the font (for example, Regular or Bold), indexed by locale name.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteLocalizedStrings</c> interface for the newly created
		/// localized strings object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getfacenames HRESULT GetFaceNames(
		// [out] IDWriteLocalizedStrings **names );
		new IDWriteLocalizedStrings GetFaceNames();

		/// <summary>Gets a localized strings collection that contains the specified informational strings, indexed by locale name.</summary>
		/// <param name="informationalStringID">
		/// <para>Type: <b><c>DWRITE_INFORMATIONAL_STRING_ID</c></b></para>
		/// <para>A <c>DWRITE_INFORMATIONAL_STRING_ID</c>-typed value that identifies the strings to get.</para>
		/// </param>
		/// <param name="informationalStrings">
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteLocalizedStrings</c> interface for the newly created
		/// localized strings object.
		/// </para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>
		/// A pointer to a variable that receives whether the font contains the specified string ID. <b>TRUE</b> if the font contains the
		/// specified string ID; otherwise, <b>FALSE</b>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>
		/// If the font doesn't contain the specified string, the return value is S_OK, but <i>informationalStrings</i> receives a
		/// <b>NULL</b> pointer and <i>exists</i> receives the value <b>FALSE</b>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getinformationalstrings HRESULT
		// GetInformationalStrings( [in] DWRITE_INFORMATIONAL_STRING_ID informationalStringID, [out] IDWriteLocalizedStrings
		// **informationalStrings, [out] BOOL *exists );
		new void GetInformationalStrings(DWRITE_INFORMATIONAL_STRING_ID informationalStringID, out IDWriteLocalizedStrings? informationalStrings,
			[MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Determines whether the font supports the specified character.</summary>
		/// <param name="unicodeValue">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>A Unicode (UCS-4) character value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>
		/// Returns whether the font supports the specified character. Returns <b>TRUE</b> if the font has the specified character;
		/// otherwise, <b>FALSE</b>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-hascharacter BOOL HasCharacter( [in]
		// UINT32 unicodeValue );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool HasCharacter(uint unicodeValue);

		/// <summary>
		/// Determines the recommended text rendering and grid-fit mode to be used based on the font, size, world transform, and measuring mode.
		/// </summary>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Logical font size in DIPs.</para>
		/// </param>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the horizontal direction.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Number of pixels per logical inch in the vertical direction.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>A <c>DWRITE_MATRIX</c> structure that describes the world transform.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies whether the font is sideways. <b>TRUE</b> if the font is sideways; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <param name="outlineThreshold">
		/// <para>Type: <b><c>DWRITE_OUTLINE_THRESHOLD</c></b></para>
		/// <para>
		/// A <c>DWRITE_OUTLINE_THRESHOLD</c>-typed value that specifies the quality of the graphics system's outline rendering, affects the
		/// size threshold above which outline rendering is used.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// A <c>DWRITE_MEASURING_MODE</c>-typed value that specifies the method used to measure during text layout. For proper glyph
		/// spacing, this method returns a rendering mode that is compatible with the specified measuring mode.
		/// </para>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <b><c>IDWriteRenderingParams</c>*</b></para>
		/// <para>
		/// A pointer to a <c>IDWriteRenderingParams</c> interface for the rendering parameters object. This parameter is necessary in case
		/// the rendering parameters object overrides the rendering mode.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_RENDERING_MODE1</c>-typed value for the recommended rendering mode.</para>
		/// </param>
		/// <param name="gridFitMode">
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c>*</b></para>
		/// <para>A pointer to a variable that receives a <c>DWRITE_GRID_FIT_MODE</c>-typed value for the recommended grid-fit mode.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( [in] FLOAT fontEmSize, [in] FLOAT dpiX, [in] FLOAT dpiY, [in, optional] DWRITE_MATRIX const
		// *transform, [in] BOOL isSideways, [in] DWRITE_OUTLINE_THRESHOLD outlineThreshold, [in] DWRITE_MEASURING_MODE measuringMode, [in,
		// optional] IDWriteRenderingParams *renderingParams, [out] DWRITE_RENDERING_MODE1 *renderingMode, [out] DWRITE_GRID_FIT_MODE
		// *gridFitMode );
		new void GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			bool isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode,
			[In, Optional] IDWriteRenderingParams? renderingParams, out DWRITE_RENDERING_MODE1 renderingMode, out DWRITE_GRID_FIT_MODE gridFitMode);

		/// <summary><c>unicodeValue</c></summary>
		/// <param name="unicodeValue"/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontface3-ischaracterlocal BOOL
		// IsCharacterLocal( UINT32 unicodeValue );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsCharacterLocal(uint unicodeValue);

		/// <summary>Determines whether the glyph is locally downloaded from the font.</summary>
		/// <param name="glyphId">
		/// <para>Type: <b>UINT16</b></para>
		/// <para>Glyph identifier.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Returns TRUE if the font has the specified glyph locally available.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-isglyphlocal BOOL IsGlyphLocal( [in]
		// UINT16 glyphId );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsGlyphLocal(ushort glyphId);

		/// <summary>Determines whether the specified characters are local.</summary>
		/// <param name="characters">
		/// <para>Type: <b>WCHAR</b></para>
		/// <para>Array of characters.</para>
		/// </param>
		/// <param name="characterCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of elements in the character array.</para>
		/// </param>
		/// <param name="enqueueIfNotLocal">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies whether to enqueue a download request if any of the specified characters are not local.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if all of the specified characters are local, FALSE if any of the specified characters are remote.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-arecharacterslocal HRESULT
		// AreCharactersLocal( [in] WCHAR const *characters, UINT32 characterCount, BOOL enqueueIfNotLocal, [out] BOOL *isLocal );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool AreCharactersLocal([MarshalAs(UnmanagedType.LPWStr)] string characters, uint characterCount, bool enqueueIfNotLocal);

		/// <summary>Determines whether the specified glyphs are local.</summary>
		/// <param name="glyphIndices">
		/// <para>Type: <b>UINT16</b></para>
		/// <para>Array of glyph indices.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of elements in the glyph index array.</para>
		/// </param>
		/// <param name="enqueueIfNotLocal">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies whether to enqueue a download request if any of the specified glyphs are not local.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if all of the specified glyphs are local, FALSE if any of the specified glyphs are remote.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface3-areglyphslocal HRESULT AreGlyphsLocal(
		// [in] UINT16 const *glyphIndices, UINT32 glyphCount, BOOL enqueueIfNotLocal, [out] BOOL *isLocal );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool AreGlyphsLocal([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices, uint glyphCount, bool enqueueIfNotLocal);

		/// <summary>Gets all the glyph image formats supported for the specified glyph.</summary>
		/// <param name="glyphId">The identifier of the glyph to be queried.</param>
		/// <param name="pixelsPerEmFirst">The lowest pixels per em value to query.</param>
		/// <param name="pixelsPerEmLast">The highest pixels per em value to query.</param>
		/// <returns>An array of <c>DWRITE_GLYPH_IMAGE_FORMATS</c> specifying the supported formats for the requested glyph.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface4-getglyphimageformats(uint16_uint32_uint32_dwrite_glyph_image_formats)
		// HRESULT GetGlyphImageFormats( UINT16 glyphId, UINT32 pixelsPerEmFirst, UINT32 pixelsPerEmLast, DWRITE_GLYPH_IMAGE_FORMATS
		// *glyphImageFormats );
		new DWRITE_GLYPH_IMAGE_FORMATS GetGlyphImageFormats(ushort glyphId, uint pixelsPerEmFirst, uint pixelsPerEmLast);

		/// <summary>Gets all the glyph image formats supported by the entire font.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_FORMATS</c></b></para>
		/// <para>Returns all the glyph image formats supported by the entire font.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface4-getglyphimageformats
		// DWRITE_GLYPH_IMAGE_FORMATS GetGlyphImageFormats();
		[PreserveSig]
		new DWRITE_GLYPH_IMAGE_FORMATS GetGlyphImageFormats();

		/// <summary>Gets a pointer to the glyph data based on the desired image format.</summary>
		/// <param name="glyphId">
		/// <para>Type: <b>UINT16</b></para>
		/// <para>The ID of the glyph to retrieve image data for.</para>
		/// </param>
		/// <param name="pixelsPerEm">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Requested pixels per em.</para>
		/// </param>
		/// <param name="glyphImageFormat">
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_FORMATS</c></b></para>
		/// <para>Specifies which formats are supported in the font.</para>
		/// </param>
		/// <param name="glyphData">
		/// <para>Type: <b><c>DWRITE_GLYPH_IMAGE_DATA</c>*</b></para>
		/// <para>On return contains data for a glyph.</para>
		/// </param>
		/// <param name="glyphDataContext">Type: <b>void**</b></param>
		/// <remarks>
		/// <para>
		/// The glyphDataContext must be released via <c>ReleaseGlyphImageData</c> when done if the data is not empty, similar to
		/// <c>IDWriteFontFileStream::ReadFileFragment</c> and <c>IDWriteFontFileStream::ReleaseFileFragment</c>. The data pointer is valid
		/// so long as the <c>IDWriteFontFace</c> exists and <b>ReleaseGlyphImageData</b> has not been called.
		/// </para>
		/// <para>
		/// The <c>DWRITE_GLYPH_IMAGE_DATA::uniqueDataId</c> is valuable for caching purposes so that if the same resource is returned more
		/// than once, an existing resource can be quickly retrieved rather than needing to reparse or decompress the data.
		/// </para>
		/// <para>
		/// The function only returns SVG or raster data - requesting TrueType/CFF/COLR data returns DWRITE_E_INVALIDARG. Those must be
		/// drawn via DrawGlyphRun or queried using GetGlyphOutline instead. Exactly one format may be requested or else the function
		/// returns DWRITE_E_INVALIDARG. If the glyph does not have that format, the call is not an error, but the function returns empty data.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface4-getglyphimagedata HRESULT
		// GetGlyphImageData( [in] UINT16 glyphId, UINT32 pixelsPerEm, DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat, [out]
		// DWRITE_GLYPH_IMAGE_DATA *glyphData, [out] void **glyphDataContext );
		new void GetGlyphImageData(ushort glyphId, uint pixelsPerEm, DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat, out DWRITE_GLYPH_IMAGE_DATA glyphData,
			out IntPtr glyphDataContext);

		/// <summary>Releases the table data obtained from ReadGlyphData.</summary>
		/// <param name="glyphDataContext">
		/// <para>Type: <b>void*</b></para>
		/// <para>Opaque context from ReadGlyphData.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface4-releaseglyphimagedata void
		// ReleaseGlyphImageData( void *glyphDataContext );
		[PreserveSig]
		new void ReleaseGlyphImageData([In] IntPtr glyphDataContext);

		/// <summary>Retrieves the number of axes defined by the font face. This includes both static and variable axes (see <c>DWRITE_FONT_AXIS_RANGE</c>).</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axes defined by the font face.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface5-getfontaxisvaluecount UINT32 GetFontAxisValueCount();
		[PreserveSig]
		new uint GetFontAxisValueCount();

		/// <summary>Retrieves the list of axis values used by the font.</summary>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c>*</b></para>
		/// <para>
		/// A pointer to an array of <b>DWRITE_FONT_AXIS_VALUE</b> structures into which <b>GetFontAxisValues</b> writes the list of font
		/// axis values. You're responsible for managing the size and the lifetime of this array. Call <c>GetFontAxisValueCount</c> to
		/// determine the size of array to allocate.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The maximum number of font axis values to write into the memory block pointed to by <c>fontAxisValues</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>
		/// <code>fontAxisValueCount</code>
		/// doesn't match the value returned by <b>GetFontAxisValueCount</b>.
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The values are returned in the canonical order defined by the font, clamped to the actual range supported. It's not necessarily
		/// the same axis value array that you passed to <b>CreateFontFace</b>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface5-getfontaxisvalues HRESULT
		// GetFontAxisValues( [out] DWRITE_FONT_AXIS_VALUE *fontAxisValues, UINT32 fontAxisValueCount );
		new void GetFontAxisValues([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);

		/// <summary>
		/// Determines whether this font face's resource supports any variable axes. When <c>true</c>, at least one
		/// <c>DWRITE_FONT_AXIS_RANGE</c> in the font resource has a non-empty range (maxValue &gt; minValue).
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>BOOL</c></b></para>
		/// <para><c>true</c> if the font face's resource supports any variable axes. Otherwise, <c>false</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface5-hasvariations BOOL HasVariations();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool HasVariations();

		/// <summary>
		/// Retrieves the underlying font resource for this font face. You can use that to query information about the resource, or to
		/// recreate a new font face instance with different axis values.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontResource</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontResource</c> interface. On successful completion, the function sets the pointer to
		/// a newly created font resource object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface5-getfontresource HRESULT
		// GetFontResource( [out] IDWriteFontResource **fontResource );
		new IDWriteFontResource GetFontResource();

		/// <summary>
		/// Performs an equality comparison between the font face object on which <b>Equals</b> is being called and the font face object
		/// passed as a parameter.
		/// </summary>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>A pointer to a font face object to compare with the font face object on which <b>Equals</b> is being called.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>BOOL</c></b></para>
		/// <para><c>true</c> if the font face objects are equal. Otherwise, <c>false</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontface5-equals BOOL Equals( IDWriteFontFace
		// *fontFace );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool Equals(IDWriteFontFace fontFace);

		/// <summary>Gets the family names.</summary>
		/// <param name="fontFamilyModel">The font family model.</param>
		/// <returns></returns>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontface6-getfamilynames HRESULT
		// GetFamilyNames( DWRITE_FONT_FAMILY_MODEL fontFamilyModel, IDWriteLocalizedStrings **names );
		new IDWriteLocalizedStrings GetFamilyNames(DWRITE_FONT_FAMILY_MODEL fontFamilyModel);

		/// <summary>Gets the face names.</summary>
		/// <param name="fontFamilyModel">The font family model.</param>
		/// <returns></returns>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontface6-getfacenames HRESULT
		// GetFaceNames( DWRITE_FONT_FAMILY_MODEL fontFamilyModel, IDWriteLocalizedStrings **names );
		new IDWriteLocalizedStrings GetFaceNames(DWRITE_FONT_FAMILY_MODEL fontFamilyModel);

		/// <summary><c>glyphImageFormat</c></summary>
		/// <param name="glyphImageFormat"/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontface7-getpaintfeaturelevel
		// DWRITE_PAINT_FEATURE_LEVEL GetPaintFeatureLevel( DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat );
		[PreserveSig]
		DWRITE_PAINT_FEATURE_LEVEL GetPaintFeatureLevel(DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat);

		/// <summary>
		/// <para><c>glyphImageFormat</c></para>
		/// <para><c>paintFeatureLevel</c></para>
		/// <para><c>paintReader</c></para>
		/// </summary>
		/// <param name="glyphImageFormat"/>
		/// <param name="paintFeatureLevel"/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontface7-createpaintreader
		// HRESULT CreatePaintReader( DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat, DWRITE_PAINT_FEATURE_LEVEL paintFeatureLevel,
		// IDWritePaintReader **paintReader );
		IDWritePaintReader CreatePaintReader(DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat, DWRITE_PAINT_FEATURE_LEVEL paintFeatureLevel);
	}

	/// <summary>
	/// Represents a reference to a font face. A uniquely identifying reference to a font, from which you can create a font face to query
	/// font metrics and use for rendering. A font face reference consists of a font file, font face index, and font face simulation. The
	/// file data may or may not be physically present on the local machine yet.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontfacereference
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontFaceReference")]
	[ComImport, Guid("5E7FA7CA-DDE3-424C-89F0-9FCD6FED58CD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontFaceReference
	{
		/// <summary>Creates a font face from the reference for use with layout, shaping, or rendering.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFace3</c>**</b></para>
		/// <para>Newly created font face object, or nullptr in the case of failure.</para>
		/// </returns>
		/// <remarks>This function can fail with DWRITE_E_REMOTEFONT if the font is not local.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-createfontface HRESULT
		// CreateFontFace( [out] IDWriteFontFace3 **fontFace );
		IDWriteFontFace3 CreateFontFace();

		/// <summary>
		/// Creates a font face with alternate font simulations, for example, to explicitly simulate a bold font face out of a regular variant.
		/// </summary>
		/// <param name="fontFaceSimulationFlags">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFace3</c>**</b></para>
		/// <para>Newly created font face object, or nullptr in the case of failure.</para>
		/// </returns>
		/// <remarks>This function can fail with DWRITE_E_REMOTEFONT if the font is not local.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-createfontfacewithsimulations
		// HRESULT CreateFontFaceWithSimulations( DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags, [out] IDWriteFontFace3 **fontFace );
		IDWriteFontFace3 CreateFontFaceWithSimulations(DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags);

		/// <summary><c>fontFaceReference</c></summary>
		/// <param name="fontFaceReference"/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontfacereference-equals BOOL
		// Equals( IDWriteFontFaceReference *fontFaceReference );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool Equals(IDWriteFontFaceReference fontFaceReference);

		/// <summary>
		/// Obtains the zero-based index of the font face in its font file or files. If the font files contain a single face, the return
		/// value is zero.
		/// </summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// the zero-based index of the font face in its font file or files. If the font files contain a single face, the return value is zero.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-getfontfaceindex UINT32 GetFontFaceIndex();
		[PreserveSig]
		uint GetFontFaceIndex();

		/// <summary>Obtains the algorithmic style simulation flags of a font face.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Returns the algorithmic style simulation flags of a font face.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-getsimulations
		// DWRITE_FONT_SIMULATIONS GetSimulations();
		[PreserveSig]
		DWRITE_FONT_SIMULATIONS GetSimulations();

		/// <summary>Obtains the font file representing a font face.</summary>
		/// <returns>Type: <b><c>IDWriteFontFile</c>**</b></returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-getfontfile HRESULT
		// GetFontFile( [out] IDWriteFontFile **fontFile );
		IDWriteFontFile GetFontFile();

		/// <summary>
		/// Get the local size of the font face in bytes, which will always be less than or equal to GetFullSize. If the locality is remote,
		/// this value is zero. If full, this value will equal GetFileSize.
		/// </summary>
		/// <returns>
		/// <para>Type: <b>UINT64</b></para>
		/// <para>
		/// the local size of the font face in bytes, which will always be less than or equal to GetFullSize. If the locality is remote,
		/// this value is zero. If full, this value will equal <c>GetFileSize</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-getlocalfilesize UINT64 GetLocalFileSize();
		[PreserveSig]
		ulong GetLocalFileSize();

		/// <summary>Get the total size of the font face in bytes.</summary>
		/// <returns>
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Returns the total size of the font face in bytes. If the locality is remote, this value is unknown and will be zero.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-getfilesize UINT64 GetFileSize();
		[PreserveSig]
		ulong GetFileSize();

		/// <summary>Get the last modified date.</summary>
		/// <returns>
		/// <para>Type: <b>FILETIME*</b></para>
		/// <para>Returns the last modified date. The time may be zero if the font file loader does not expose file time.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-getfiletime HRESULT
		// GetFileTime( [out] FILETIME *lastWriteTime );
		FILETIME GetFileTime();

		/// <summary>Get the locality of this font face reference.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_LOCALITY</c></b></para>
		/// <para>Returns the locality of this font face reference.</para>
		/// </returns>
		/// <remarks>
		/// You can always successfully create a font face from a fully local font. Attempting to create a font face on a remote or
		/// partially local font may fail with DWRITE_E_REMOTEFONT. This function may change between calls depending on background downloads
		/// and whether cached data expires.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-getlocality DWRITE_LOCALITY GetLocality();
		[PreserveSig]
		DWRITE_LOCALITY GetLocality();

		/// <summary>Adds a request to the font download queue ( <c>IDWriteFontDownloadQueue</c>).</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-enqueuefontdownloadrequest
		// HRESULT EnqueueFontDownloadRequest();
		void EnqueueFontDownloadRequest();

		/// <summary>Adds a request to the font download queue ( <c>IDWriteFontDownloadQueue</c>).</summary>
		/// <param name="characters">
		/// <para>Type: <b>const WCHAR*</b></para>
		/// <para>Array of characters to download.</para>
		/// </param>
		/// <param name="characterCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of elements in the character array.</para>
		/// </param>
		/// <remarks>
		/// Downloading a character involves downloading every glyph it depends on directly or indirectly, via font tables (cmap, GSUB,
		/// COLR, glyf).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-enqueuecharacterdownloadrequest
		// HRESULT EnqueueCharacterDownloadRequest( [in] WCHAR const *characters, UINT32 characterCount );
		void EnqueueCharacterDownloadRequest([MarshalAs(UnmanagedType.LPWStr)] string characters, uint characterCount);

		/// <summary>Adds a request to the font download queue ( <c>IDWriteFontDownloadQueue</c>).</summary>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>Array of glyph indices to download.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of elements in the glyph index array.</para>
		/// </param>
		/// <remarks>Downloading a glyph involves downloading any other glyphs it depends on from the font tables (GSUB, COLR, glyf).</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-enqueueglyphdownloadrequest
		// HRESULT EnqueueGlyphDownloadRequest( [in] UINT16 const *glyphIndices, UINT32 glyphCount );
		void EnqueueGlyphDownloadRequest([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices, uint glyphCount);

		/// <summary>Adds a request to the font download queue ( <c>IDWriteFontDownloadQueue</c>).</summary>
		/// <param name="fileOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Offset of the fragment from the beginning of the font file.</para>
		/// </param>
		/// <param name="fragmentSize">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Size of the fragment in bytes.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-enqueuefilefragmentdownloadrequest
		// HRESULT EnqueueFileFragmentDownloadRequest( UINT64 fileOffset, UINT64 fragmentSize );
		void EnqueueFileFragmentDownloadRequest(ulong fileOffset, ulong fragmentSize);
	}

	/// <summary>
	/// <para>
	/// Represents a reference to a font face. A uniquely identifying reference to a font, from which you can create a font face to query
	/// font metrics and use for rendering. A font face reference consists of a font file, font face index, and font face simulation. The
	/// file data may or may not be physically present on the local machine yet. <b>IDWriteFontFaceReference1</b> adds new facilities,
	/// including support for <c>IDWriteFontFace5</c>.
	/// </para>
	/// <para>This interface extends <c>IDWriteFontFaceReference</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontfacereference1
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontFaceReference1")]
	[ComImport, Guid("C081FE77-2FD1-41AC-A5A3-34983C4BA61A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontFaceReference1 : IDWriteFontFaceReference
	{
		/// <summary>Creates a font face from the reference for use with layout, shaping, or rendering.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFace3</c>**</b></para>
		/// <para>Newly created font face object, or nullptr in the case of failure.</para>
		/// </returns>
		/// <remarks>This function can fail with DWRITE_E_REMOTEFONT if the font is not local.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-createfontface HRESULT
		// CreateFontFace( [out] IDWriteFontFace3 **fontFace );
		new IDWriteFontFace3 CreateFontFace();

		/// <summary>
		/// Creates a font face with alternate font simulations, for example, to explicitly simulate a bold font face out of a regular variant.
		/// </summary>
		/// <param name="fontFaceSimulationFlags">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFace3</c>**</b></para>
		/// <para>Newly created font face object, or nullptr in the case of failure.</para>
		/// </returns>
		/// <remarks>This function can fail with DWRITE_E_REMOTEFONT if the font is not local.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-createfontfacewithsimulations
		// HRESULT CreateFontFaceWithSimulations( DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags, [out] IDWriteFontFace3 **fontFace );
		new IDWriteFontFace3 CreateFontFaceWithSimulations(DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags);

		/// <summary><c>fontFaceReference</c></summary>
		/// <param name="fontFaceReference"/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontfacereference-equals BOOL
		// Equals( IDWriteFontFaceReference *fontFaceReference );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool Equals(IDWriteFontFaceReference fontFaceReference);

		/// <summary>
		/// Obtains the zero-based index of the font face in its font file or files. If the font files contain a single face, the return
		/// value is zero.
		/// </summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// the zero-based index of the font face in its font file or files. If the font files contain a single face, the return value is zero.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-getfontfaceindex UINT32 GetFontFaceIndex();
		[PreserveSig]
		new uint GetFontFaceIndex();

		/// <summary>Obtains the algorithmic style simulation flags of a font face.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Returns the algorithmic style simulation flags of a font face.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-getsimulations
		// DWRITE_FONT_SIMULATIONS GetSimulations();
		[PreserveSig]
		new DWRITE_FONT_SIMULATIONS GetSimulations();

		/// <summary>Obtains the font file representing a font face.</summary>
		/// <returns>Type: <b><c>IDWriteFontFile</c>**</b></returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-getfontfile HRESULT
		// GetFontFile( [out] IDWriteFontFile **fontFile );
		new IDWriteFontFile GetFontFile();

		/// <summary>
		/// Get the local size of the font face in bytes, which will always be less than or equal to GetFullSize. If the locality is remote,
		/// this value is zero. If full, this value will equal GetFileSize.
		/// </summary>
		/// <returns>
		/// <para>Type: <b>UINT64</b></para>
		/// <para>
		/// the local size of the font face in bytes, which will always be less than or equal to GetFullSize. If the locality is remote,
		/// this value is zero. If full, this value will equal <c>GetFileSize</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-getlocalfilesize UINT64 GetLocalFileSize();
		[PreserveSig]
		new ulong GetLocalFileSize();

		/// <summary>Get the total size of the font face in bytes.</summary>
		/// <returns>
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Returns the total size of the font face in bytes. If the locality is remote, this value is unknown and will be zero.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-getfilesize UINT64 GetFileSize();
		[PreserveSig]
		new ulong GetFileSize();

		/// <summary>Get the last modified date.</summary>
		/// <returns>
		/// <para>Type: <b>FILETIME*</b></para>
		/// <para>Returns the last modified date. The time may be zero if the font file loader does not expose file time.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-getfiletime HRESULT
		// GetFileTime( [out] FILETIME *lastWriteTime );
		new FILETIME GetFileTime();

		/// <summary>Get the locality of this font face reference.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_LOCALITY</c></b></para>
		/// <para>Returns the locality of this font face reference.</para>
		/// </returns>
		/// <remarks>
		/// You can always successfully create a font face from a fully local font. Attempting to create a font face on a remote or
		/// partially local font may fail with DWRITE_E_REMOTEFONT. This function may change between calls depending on background downloads
		/// and whether cached data expires.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-getlocality DWRITE_LOCALITY GetLocality();
		[PreserveSig]
		new DWRITE_LOCALITY GetLocality();

		/// <summary>Adds a request to the font download queue ( <c>IDWriteFontDownloadQueue</c>).</summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-enqueuefontdownloadrequest
		// HRESULT EnqueueFontDownloadRequest();
		new void EnqueueFontDownloadRequest();

		/// <summary>Adds a request to the font download queue ( <c>IDWriteFontDownloadQueue</c>).</summary>
		/// <param name="characters">
		/// <para>Type: <b>const WCHAR*</b></para>
		/// <para>Array of characters to download.</para>
		/// </param>
		/// <param name="characterCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of elements in the character array.</para>
		/// </param>
		/// <remarks>
		/// Downloading a character involves downloading every glyph it depends on directly or indirectly, via font tables (cmap, GSUB,
		/// COLR, glyf).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-enqueuecharacterdownloadrequest
		// HRESULT EnqueueCharacterDownloadRequest( [in] WCHAR const *characters, UINT32 characterCount );
		new void EnqueueCharacterDownloadRequest([MarshalAs(UnmanagedType.LPWStr)] string characters, uint characterCount);

		/// <summary>Adds a request to the font download queue ( <c>IDWriteFontDownloadQueue</c>).</summary>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>Array of glyph indices to download.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of elements in the glyph index array.</para>
		/// </param>
		/// <remarks>Downloading a glyph involves downloading any other glyphs it depends on from the font tables (GSUB, COLR, glyf).</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-enqueueglyphdownloadrequest
		// HRESULT EnqueueGlyphDownloadRequest( [in] UINT16 const *glyphIndices, UINT32 glyphCount );
		new void EnqueueGlyphDownloadRequest([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices, uint glyphCount);

		/// <summary>Adds a request to the font download queue ( <c>IDWriteFontDownloadQueue</c>).</summary>
		/// <param name="fileOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Offset of the fragment from the beginning of the font file.</para>
		/// </param>
		/// <param name="fragmentSize">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Size of the fragment in bytes.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference-enqueuefilefragmentdownloadrequest
		// HRESULT EnqueueFileFragmentDownloadRequest( UINT64 fileOffset, UINT64 fragmentSize );
		new void EnqueueFileFragmentDownloadRequest(ulong fileOffset, ulong fragmentSize);

		/// <summary>Uses the reference to create a font face, for use with layout, shaping, or rendering.</summary>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace5</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontFace5</c> interface. On successful completion, the function sets the pointer to a
		/// newly created font face object, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DWRITE_E_REMOTEFONT</description>
		/// <description>The font is not local.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference1-createfontface HRESULT
		// CreateFontFace( [out] IDWriteFontFace5 **fontFace );
		[PreserveSig]
		HRESULT CreateFontFace(out IDWriteFontFace5 fontFace);

		/// <summary>Retrieves the number of axes specified by the reference.</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axes defined by the font face.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference1-getfontaxisvaluecount UINT32 GetFontAxisValueCount();
		[PreserveSig]
		uint GetFontAxisValueCount();

		/// <summary>Retrieves the list of font axis values specified by the reference.</summary>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c>*</b></para>
		/// <para>
		/// A pointer to an array of <b>DWRITE_FONT_AXIS_VALUE</b> structures into which <b>GetFontAxisValues</b> writes the list of font
		/// axis values. You're responsible for managing the size and the lifetime of this array. Call <c>GetFontAxisValueCount</c> to
		/// determine the size of array to allocate.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The maximum number of font axis values to write into the memory block pointed to by <c>fontAxisValues</c>.</para>
		/// </param>
		/// <remarks/>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfacereference1-getfontaxisvalues HRESULT
		// GetFontAxisValues( [out] DWRITE_FONT_AXIS_VALUE *fontAxisValues, UINT32 fontAxisValueCount );
		void GetFontAxisValues([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);
	}

	/// <summary>The <b>IDWriteFontFallback1</b> interface inherits from the IDWriteFontFallback interface.</summary>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nn-dwrite_3-idwritefontfallback1
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontFallback1")]
	[ComImport, Guid("2397599D-DD0D-4681-BD6A-F4F31EAADE77"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontFallback1 : IDWriteFontFallback
	{
		/// <summary>Determines an appropriate font to use to render the beginning range of text.</summary>
		/// <param name="analysisSource">
		/// <para>Type: <b><c>IDWriteTextAnalysisSource</c>*</b></para>
		/// <para>The text source implementation holds the text and locale.</para>
		/// </param>
		/// <param name="textPosition">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Starting position to analyze.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Length of the text to analyze.</para>
		/// </param>
		/// <param name="baseFontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection</c>*</b></para>
		/// <para>Default font collection to use.</para>
		/// </param>
		/// <param name="baseFamilyName">
		/// <para>Type: <b>const wchar_t*</b></para>
		/// <para>Family name of the base font. If you pass null, no matching will be done against the family.</para>
		/// </param>
		/// <param name="baseWeight">
		/// <para>Type: <b><c>DWRITE_FONT_WEIGHT</c></b></para>
		/// <para>The desired weight.</para>
		/// </param>
		/// <param name="baseStyle">
		/// <para>Type: <b><c>DWRITE_FONT_STYLE</c></b></para>
		/// <para>The desired style.</para>
		/// </param>
		/// <param name="baseStretch">
		/// <para>Type: <b><c>DWRITE_FONT_STRETCH</c></b></para>
		/// <para>The desired stretch.</para>
		/// </param>
		/// <param name="mappedLength">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>
		/// Length of text mapped to the mapped font. This will always be less than or equal to the text length and greater than zero (if
		/// the text length is non-zero) so the caller advances at least one character.
		/// </para>
		/// </param>
		/// <param name="mappedFont">
		/// <para>Type: <b><c>IDWriteFont</c>**</b></para>
		/// <para>
		/// The font that should be used to render the first <i>mappedLength</i> characters of the text. If it returns NULL, that means that
		/// no font can render the text, and <i>mappedLength</i> is the number of characters to skip (rendered with a missing glyph).
		/// </para>
		/// </param>
		/// <param name="scale">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>Scale factor to multiply the em size of the returned font by.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritefontfallback-mapcharacters HRESULT MapCharacters(
		// IDWriteTextAnalysisSource *analysisSource, UINT32 textPosition, UINT32 textLength, [in, optional] IDWriteFontCollection
		// *baseFontCollection, [in, optional] wchar_t const *baseFamilyName, DWRITE_FONT_WEIGHT baseWeight, DWRITE_FONT_STYLE baseStyle,
		// DWRITE_FONT_STRETCH baseStretch, [out] UINT32 *mappedLength, [out] IDWriteFont **mappedFont, [out] FLOAT *scale );
		[PreserveSig]
		new HRESULT MapCharacters([In] IDWriteTextAnalysisSource analysisSource, uint textPosition, uint textLength, [In, Optional] IDWriteFontCollection? baseFontCollection,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string? baseFamilyName, DWRITE_FONT_WEIGHT baseWeight, DWRITE_FONT_STYLE baseStyle,
			DWRITE_FONT_STRETCH baseStretch, out uint mappedLength, out IDWriteFont? mappedFont, out float scale);

		/// <summary>Determines an appropriate font to use to render the range of text.</summary>
		/// <param name="analysisSource">The text source implementation holds the text and locale.</param>
		/// <param name="textPosition">The text position.</param>
		/// <param name="textLength">Length of the text to analyze.</param>
		/// <param name="baseFontCollection">Default font collection to use.</param>
		/// <param name="baseFamilyName">
		/// Family name of the base font. If you pass <see langword="null"/>, no matching will be done against the base family.
		/// </param>
		/// <param name="fontAxisValues">List of font axis values.</param>
		/// <param name="fontAxisValueCount">Number of font axis values.</param>
		/// <param name="mappedLength">
		/// Length of text mapped to the mapped font. This will always be less or equal to the input text length and greater than zero (if
		/// the text length is non-zero) so that the caller advances at least one character each call.
		/// </param>
		/// <param name="scale">Scale factor to multiply the em size of the returned font by.</param>
		/// <param name="mappedFontFace">
		/// The font face that should be used to render the first mappedLength characters of the text. If it returns null, then no known
		/// font can render the text, and mappedLength is the number of unsupported characters to skip.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontfallback1-mapcharacters
		// HRESULT MapCharacters( IDWriteTextAnalysisSource *analysisSource, UINT32 textPosition, UINT32 textLength, IDWriteFontCollection
		// *baseFontCollection, WCHAR const *baseFamilyName, DWRITE_FONT_AXIS_VALUE const *fontAxisValues, UINT32 fontAxisValueCount, UINT32
		// *mappedLength, FLOAT *scale, IDWriteFontFace5 **mappedFontFace );
		void MapCharacters([In] IDWriteTextAnalysisSource analysisSource, uint textPosition, uint textLength,
			[In, Optional] IDWriteFontCollection? baseFontCollection, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? baseFamilyName,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount,
			out uint mappedLength, out float scale, out IDWriteFontFace5? mappedFontFace);
	}

	/// <summary>Represents a family of related fonts.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontfamily1
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontFamily1")]
	[ComImport, Guid("DA20D8EF-812A-4C43-9802-62EC4ABD7ADF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontFamily1 : IDWriteFontList, IDWriteFontFamily
	{
		/// <summary>Gets the font collection that contains the fonts in the font list.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the current IDWriteFontCollection object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfontcollection HRESULT GetFontCollection(
		// IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection GetFontCollection();

		/// <summary>Gets the number of fonts in the font list.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of fonts in the font list.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfontcount UINT32 GetFontCount();
		[PreserveSig]
		new uint GetFontCount();

		/// <summary>Gets a font given its zero-based index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFont**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created IDWriteFont object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfont HRESULT GetFont( UINT32 index,
		// IDWriteFont **font );
		new IDWriteFont GetFont(uint index);

		/// <summary>Creates a localized strings object that contains the family names for the font family, indexed by locale name.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteLocalizedStrings**</c></para>
		/// <para>The address of a pointer to the newly created IDWriteLocalizedStrings object.</para>
		/// </returns>
		/// <remarks>The following code example shows how to get the font family name from a IDWriteFontFamily object.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfamily-getfamilynames HRESULT GetFamilyNames(
		// IDWriteLocalizedStrings **names );
		new IDWriteLocalizedStrings GetFamilyNames();

		/// <summary>Gets the font that best matches the specified properties.</summary>
		/// <param name="weight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that is used to match a requested font weight.</para>
		/// </param>
		/// <param name="stretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value that is used to match a requested font stretch.</para>
		/// </param>
		/// <param name="style">
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value that is used to match a requested font style.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFont**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created IDWriteFont object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfamily-getfirstmatchingfont HRESULT
		// GetFirstMatchingFont( DWRITE_FONT_WEIGHT weight, DWRITE_FONT_STRETCH stretch, DWRITE_FONT_STYLE style, IDWriteFont
		// **matchingFont );
		new IDWriteFont GetFirstMatchingFont(DWRITE_FONT_WEIGHT weight, DWRITE_FONT_STRETCH stretch, DWRITE_FONT_STYLE style);

		/// <summary>Gets a list of fonts in the font family ranked in order of how well they match the specified properties.</summary>
		/// <param name="weight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that is used to match a requested font weight.</para>
		/// </param>
		/// <param name="stretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value that is used to match a requested font stretch.</para>
		/// </param>
		/// <param name="style">
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value that is used to match a requested font style.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontList**</c></para>
		/// <para>An address of a pointer to the newly created IDWriteFontList object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfamily-getmatchingfonts HRESULT GetMatchingFonts(
		// DWRITE_FONT_WEIGHT weight, DWRITE_FONT_STRETCH stretch, DWRITE_FONT_STYLE style, IDWriteFontList
		// **matchingFonts );
		new IDWriteFontList GetMatchingFonts(DWRITE_FONT_WEIGHT weight, DWRITE_FONT_STRETCH stretch, DWRITE_FONT_STYLE style);

		/// <summary>Gets the current location of a font given its zero-based index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_LOCALITY</c></b></para>
		/// <para>Returns a <c>DWRITE_LOCALITY</c>-typed value that specifies the location of the specified font.</para>
		/// </returns>
		/// <remarks>
		/// For fully local files, the result will always be <b>DWRITE_LOCALITY_LOCAL</b>. For streamed files, the result depends on how
		/// much of the file has been downloaded. <c>GetFont</c> fails if the locality is <b>DWRITE_LOCALITY_REMOTE</b> and potentially
		/// fails if <b>DWRITE_LOCALITY_PARTIAL</b>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfamily1-getfontlocality DWRITE_LOCALITY
		// GetFontLocality( [in] UINT32 listIndex );
		[PreserveSig]
		DWRITE_LOCALITY GetFontLocality(uint listIndex);

		/// <summary>Gets a font given its zero-based index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFont3</c>**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to a <c>IDWriteFont3</c> interface for the newly created font object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfamily1-getfont HRESULT GetFont( [in] UINT32
		// listIndex, [out] IDWriteFont3 **font );
		IDWriteFont3 GetFont3(uint listIndex);

		/// <summary>Gets a font face reference given its zero-based index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteFontFaceReference</c> interface for the newly created font
		/// face reference object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfamily1-getfontfacereference HRESULT
		// GetFontFaceReference( [in] UINT32 listIndex, [out] IDWriteFontFaceReference **fontFaceReference );
		IDWriteFontFaceReference GetFontFaceReference(uint listIndex);
	}

	/// <summary>
	/// <para>
	/// Represents a family of related fonts. <b>IDWriteFontFamily2</b> adds new facilities, including retrieving fonts by font axis values.
	/// </para>
	/// <para>This interface extends <c>IDWriteFontFamily1</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontfamily2
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontFamily2")]
	[ComImport, Guid("3ED49E77-A398-4261-B9CF-C126C2131EF3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontFamily2 : IDWriteFontList, IDWriteFontFamily, IDWriteFontFamily1
	{
		/// <summary>Gets the font collection that contains the fonts in the font list.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the current IDWriteFontCollection object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfontcollection HRESULT GetFontCollection(
		// IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection GetFontCollection();

		/// <summary>Gets the number of fonts in the font list.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of fonts in the font list.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfontcount UINT32 GetFontCount();
		[PreserveSig]
		new uint GetFontCount();

		/// <summary>Gets a font given its zero-based index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFont**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created IDWriteFont object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfont HRESULT GetFont( UINT32 index,
		// IDWriteFont **font );
		new IDWriteFont GetFont(uint index);

		/// <summary>Creates a localized strings object that contains the family names for the font family, indexed by locale name.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteLocalizedStrings**</c></para>
		/// <para>The address of a pointer to the newly created IDWriteLocalizedStrings object.</para>
		/// </returns>
		/// <remarks>The following code example shows how to get the font family name from a IDWriteFontFamily object.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfamily-getfamilynames HRESULT GetFamilyNames(
		// IDWriteLocalizedStrings **names );
		new IDWriteLocalizedStrings GetFamilyNames();

		/// <summary>Gets the font that best matches the specified properties.</summary>
		/// <param name="weight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that is used to match a requested font weight.</para>
		/// </param>
		/// <param name="stretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value that is used to match a requested font stretch.</para>
		/// </param>
		/// <param name="style">
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value that is used to match a requested font style.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFont**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created IDWriteFont object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfamily-getfirstmatchingfont HRESULT
		// GetFirstMatchingFont( DWRITE_FONT_WEIGHT weight, DWRITE_FONT_STRETCH stretch, DWRITE_FONT_STYLE style, IDWriteFont
		// **matchingFont );
		new IDWriteFont GetFirstMatchingFont(DWRITE_FONT_WEIGHT weight, DWRITE_FONT_STRETCH stretch, DWRITE_FONT_STYLE style);

		/// <summary>Gets a list of fonts in the font family ranked in order of how well they match the specified properties.</summary>
		/// <param name="weight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that is used to match a requested font weight.</para>
		/// </param>
		/// <param name="stretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value that is used to match a requested font stretch.</para>
		/// </param>
		/// <param name="style">
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value that is used to match a requested font style.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontList**</c></para>
		/// <para>An address of a pointer to the newly created IDWriteFontList object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfamily-getmatchingfonts HRESULT GetMatchingFonts(
		// DWRITE_FONT_WEIGHT weight, DWRITE_FONT_STRETCH stretch, DWRITE_FONT_STYLE style, IDWriteFontList
		// **matchingFonts );
		new IDWriteFontList GetMatchingFonts(DWRITE_FONT_WEIGHT weight, DWRITE_FONT_STRETCH stretch, DWRITE_FONT_STYLE style);

		/// <summary>Gets the current location of a font given its zero-based index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_LOCALITY</c></b></para>
		/// <para>Returns a <c>DWRITE_LOCALITY</c>-typed value that specifies the location of the specified font.</para>
		/// </returns>
		/// <remarks>
		/// For fully local files, the result will always be <b>DWRITE_LOCALITY_LOCAL</b>. For streamed files, the result depends on how
		/// much of the file has been downloaded. <c>GetFont</c> fails if the locality is <b>DWRITE_LOCALITY_REMOTE</b> and potentially
		/// fails if <b>DWRITE_LOCALITY_PARTIAL</b>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfamily1-getfontlocality DWRITE_LOCALITY
		// GetFontLocality( [in] UINT32 listIndex );
		[PreserveSig]
		new DWRITE_LOCALITY GetFontLocality(uint listIndex);

		/// <summary>Gets a font given its zero-based index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFont3</c>**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to a <c>IDWriteFont3</c> interface for the newly created font object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfamily1-getfont HRESULT GetFont( [in] UINT32
		// listIndex, [out] IDWriteFont3 **font );
		new IDWriteFont3 GetFont3(uint listIndex);

		/// <summary>Gets a font face reference given its zero-based index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteFontFaceReference</c> interface for the newly created font
		/// face reference object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfamily1-getfontfacereference HRESULT
		// GetFontFaceReference( [in] UINT32 listIndex, [out] IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference GetFontFaceReference(uint listIndex);

		/// <summary>Retrieves a list of fonts in the font family, ranked in order of how well they match the specified axis values.</summary>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c> const *</b></para>
		/// <para>
		/// A pointer to an array containing a list of font axis values. The array should be the size (the number of elements) indicated by
		/// the fontAxisValueCount argument.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of font axis values contained in the fontAxisValues array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontList2</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontList2</c> interface. On successful completion, the function sets the pointer to a
		/// newly created font list object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfamily2-getmatchingfonts HRESULT
		// GetMatchingFonts( DWRITE_FONT_AXIS_VALUE const *fontAxisValues, UINT32 fontAxisValueCount, [out] IDWriteFontList2 **matchingFonts );
		IDWriteFontList2 GetMatchingFonts([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);

		/// <summary>Retrieves the underlying font set used by this family.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to the
		/// font set used by the family.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontfamily2-getfontset HRESULT GetFontSet( [out]
		// IDWriteFontSet1 **fontSet );
		IDWriteFontSet1 GetFontSet();
	}

	/// <summary>Represents a list of fonts.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontlist1
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontList1")]
	[ComImport, Guid("DA20D8EF-812A-4C43-9802-62EC4ABD7ADE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontList1 : IDWriteFontList
	{
		/// <summary>Gets the font collection that contains the fonts in the font list.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the current IDWriteFontCollection object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfontcollection HRESULT GetFontCollection(
		// IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection GetFontCollection();

		/// <summary>Gets the number of fonts in the font list.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of fonts in the font list.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfontcount UINT32 GetFontCount();
		[PreserveSig]
		new uint GetFontCount();

		/// <summary>Gets a font given its zero-based index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFont**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created IDWriteFont object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfont HRESULT GetFont( UINT32 index,
		// IDWriteFont **font );
		new IDWriteFont GetFont(uint index);

		/// <summary>Gets the current location of a font given its zero-based index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_LOCALITY</c></b></para>
		/// <para>Returns a <c>DWRITE_LOCALITY</c>-typed value that specifies the location of the specified font.</para>
		/// </returns>
		/// <remarks>
		/// For fully local files, the result will always be <b>DWRITE_LOCALITY_LOCAL</b>. For streamed files, the result depends on how
		/// much of the file has been downloaded. <c>GetFont</c> fails if the locality is <b>DWRITE_LOCALITY_REMOTE</b> and potentially
		/// fails if <b>DWRITE_LOCALITY_PARTIAL</b>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontlist1-getfontlocality DWRITE_LOCALITY
		// GetFontLocality( [in] UINT32 listIndex );
		[PreserveSig]
		DWRITE_LOCALITY GetFontLocality(uint listIndex);

		/// <summary>Gets a font given its zero-based index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFont3</c>**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to a <c>IDWriteFont3</c> interface for the newly created font object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontlist1-getfont HRESULT GetFont( [in] UINT32
		// listIndex, [out] IDWriteFont3 **font );
		IDWriteFont3 GetFont3(uint listIndex);

		/// <summary>Gets a font face reference given its zero-based index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteFontFaceReference</c> interface for the newly created font
		/// face reference object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontlist1-getfontfacereference HRESULT
		// GetFontFaceReference( [in] UINT32 listIndex, [out] IDWriteFontFaceReference **fontFaceReference );
		IDWriteFontFaceReference GetFontFaceReference(uint listIndex);
	}

	/// <summary>
	/// <para>
	/// Represents a list of fonts. <b>IDWriteFontList2</b> adds new facilities, including retrieving the underlying font set used by the list.
	/// </para>
	/// <para>This interface extends <c>IDWriteFontList1</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontlist2
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontList2")]
	[ComImport, Guid("C0763A34-77AF-445A-B735-08C37B0A5BF5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontList2 : IDWriteFontList, IDWriteFontList1
	{
		/// <summary>Gets the font collection that contains the fonts in the font list.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the current IDWriteFontCollection object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfontcollection HRESULT GetFontCollection(
		// IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection GetFontCollection();

		/// <summary>Gets the number of fonts in the font list.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of fonts in the font list.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfontcount UINT32 GetFontCount();
		[PreserveSig]
		new uint GetFontCount();

		/// <summary>Gets a font given its zero-based index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFont**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created IDWriteFont object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontlist-getfont HRESULT GetFont( UINT32 index,
		// IDWriteFont **font );
		new IDWriteFont GetFont(uint index);

		/// <summary>Gets the current location of a font given its zero-based index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_LOCALITY</c></b></para>
		/// <para>Returns a <c>DWRITE_LOCALITY</c>-typed value that specifies the location of the specified font.</para>
		/// </returns>
		/// <remarks>
		/// For fully local files, the result will always be <b>DWRITE_LOCALITY_LOCAL</b>. For streamed files, the result depends on how
		/// much of the file has been downloaded. <c>GetFont</c> fails if the locality is <b>DWRITE_LOCALITY_REMOTE</b> and potentially
		/// fails if <b>DWRITE_LOCALITY_PARTIAL</b>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontlist1-getfontlocality DWRITE_LOCALITY
		// GetFontLocality( [in] UINT32 listIndex );
		[PreserveSig]
		new DWRITE_LOCALITY GetFontLocality(uint listIndex);

		/// <summary>Gets a font given its zero-based index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFont3</c>**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to a <c>IDWriteFont3</c> interface for the newly created font object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontlist1-getfont HRESULT GetFont( [in] UINT32
		// listIndex, [out] IDWriteFont3 **font );
		new IDWriteFont3 GetFont3(uint listIndex);

		/// <summary>Gets a font face reference given its zero-based index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font in the font list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to a <c>IDWriteFontFaceReference</c> interface for the newly created font
		/// face reference object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontlist1-getfontfacereference HRESULT
		// GetFontFaceReference( [in] UINT32 listIndex, [out] IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference GetFontFaceReference(uint listIndex);

		/// <summary>Retrieves the underlying font set used by this list.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to the
		/// font set used by the list.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontlist2-getfontset HRESULT GetFontSet( [out]
		// IDWriteFontSet1 **fontSet );
		IDWriteFontSet1 GetFontSet();
	}

	/// <summary>
	/// <para>Provides axis information for a font resource, and is used to create specific font face instances.</para>
	/// <para>This interface extends <c>IUnknown</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontresource
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontResource")]
	[ComImport, Guid("1F803A76-6871-48E8-987F-B975551C50F2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontResource
	{
		/// <summary>Retrieves the font file of the resource.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFile</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontFile</c> interface. On successful completion, the function sets the pointer to the
		/// font file object.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontresource-getfontfile HRESULT GetFontFile(
		// [out] IDWriteFontFile **fontFile );
		IDWriteFontFile GetFontFile();

		/// <summary>
		/// Retrieves the zero-based index of the font face within its font file. If the font file contains a single face, then the return
		/// value is zero.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The zero-based index of the font face within its font file.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontresource-getfontfaceindex UINT32 GetFontFaceIndex();
		[PreserveSig]
		uint GetFontFaceIndex();

		/// <summary>Retrieves the number of axes supported by the font resource. This includes both static and variable axes (see <c>DWRITE_FONT_AXIS_RANGE</c>).</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axes defined by the font face.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontresource-getfontaxiscount UINT32 GetFontAxisCount();
		[PreserveSig]
		uint GetFontAxisCount();

		/// <summary>Retrieves the default values for all axes supported by the font resource.</summary>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c>*</b></para>
		/// <para>
		/// A pointer to an array of <b>DWRITE_FONT_AXIS_VALUE</b> structures into which <b>GetDefaultFontAxisValues</b> writes the list of
		/// font axis values. You're responsible for managing the size and the lifetime of this array. Call <c>GetFontAxisCount</c> to
		/// determine the size of array to allocate.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The maximum number of font axis values to write into the memory block pointed to by <c>fontAxisValues</c>.</para>
		/// </param>
		/// <remarks>
		/// Different font resources may have different defaults. For OpenType 1.8 fonts, these values come from the STAT and fvar tables.
		/// For older fonts without a STAT table, weight-width-slant-italic are read from the OS/2 table.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontresource-getdefaultfontaxisvalues HRESULT
		// GetDefaultFontAxisValues( [out] DWRITE_FONT_AXIS_VALUE *fontAxisValues, UINT32 fontAxisValueCount );
		void GetDefaultFontAxisValues([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);

		/// <summary>Get ranges of each axis.</summary>
		/// <param name="fontAxisRanges"></param>
		/// <param name="fontAxisRangeCount">Total number of axis ranges</param>
		/// <remarks>Non-varying axes will have empty ranges (minimum==maximum).</remarks>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontresource-getfontaxisranges
		// HRESULT GetFontAxisRanges( DWRITE_FONT_AXIS_RANGE *fontAxisRanges, UINT32 fontAxisRangeCount );
		void GetFontAxisRanges([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges, uint fontAxisRangeCount);

		/// <summary>
		/// Retrieves attributes describing the given axis, such as whether the font author recommends to hide the axis in user interfaces.
		/// </summary>
		/// <param name="axisIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Font axis, from 0 to <c>GetFontAxisCount</c> minus 1.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_ATTRIBUTES</c></b></para>
		/// <para>The attributes for the given axis, or <b>DWRITE_FONT_AXIS_ATTRIBUTES_NONE</b> if axisIndex is beyond the font count.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontresource-getfontaxisattributes
		// DWRITE_FONT_AXIS_ATTRIBUTES GetFontAxisAttributes( UINT32 axisIndex );
		[PreserveSig]
		DWRITE_FONT_AXIS_ATTRIBUTES GetFontAxisAttributes(uint axisIndex);

		/// <summary>Gets the localized names of a font axis.</summary>
		/// <param name="axisIndex">Font axis, from 0 to GetFontAxisCount - 1.</param>
		/// <remarks>The font author may not have supplied names for some font axes. The localized strings will be empty in that case.</remarks>
		/// <returns>Receives a pointer to the newly created localized strings object.</returns>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontresource-getaxisnames HRESULT
		// GetAxisNames( UINT32 axisIndex, IDWriteLocalizedStrings **names );
		IDWriteLocalizedStrings GetAxisNames(uint axisIndex);

		/// <summary>Retrieves the number of named values for a specific axis.</summary>
		/// <param name="axisIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Font axis, from 0 to <c>GetFontAxisCount</c> minus 1.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of named values for the axis specified by axisIndex.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontresource-getaxisvaluenamecount UINT32
		// GetAxisValueNameCount( UINT32 axisIndex );
		[PreserveSig]
		uint GetAxisValueNameCount(uint axisIndex);

		/// <summary>Retrieves the localized names of specific values for a font axis.</summary>
		/// <param name="axisIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Font axis, from 0 to <c>GetFontAxisCount</c> minus 1.</para>
		/// </param>
		/// <param name="axisValueIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Value index, from 0 to <c>GetAxisValueNameCount</c> minus 1.</para>
		/// </param>
		/// <param name="fontAxisRange">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_RANGE</c>*</b></para>
		/// <para>Range of the named value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteLocalizedStrings</c> interface. On successful completion, the function sets the pointer
		/// to a newly created localized strings object.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The font author may not have supplied names for some font axis values. The localized strings will be empty in that case. The
		/// range may be a single point, where minValue == maxValue. All ranges are in ascending order by axisValueIndex.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontresource-getaxisvaluenames HRESULT
		// GetAxisValueNames( UINT32 axisIndex, UINT32 axisValueIndex, [out] DWRITE_FONT_AXIS_RANGE *fontAxisRange, [out]
		// IDWriteLocalizedStrings **names );
		IDWriteLocalizedStrings GetAxisValueNames(uint axisIndex, uint axisValueIndex, out DWRITE_FONT_AXIS_RANGE fontAxisRange);

		/// <summary>
		/// Determines whether this font face's resource supports any variable axes. When <c>true</c>, at least one
		/// <c>DWRITE_FONT_AXIS_RANGE</c> in the font resource has a non-empty range (maxValue &gt; minValue).
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>BOOL</c></b></para>
		/// <para><c>true</c> if the font face's resource supports any variable axes. Otherwise, <c>false</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontresource-hasvariations BOOL HasVariations();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool HasVariations();

		/// <summary>Creates a font face instance with specific axis values.</summary>
		/// <param name="fontSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c> const *</b></para>
		/// <para>
		/// A pointer to an array containing a list of font axis values. The array should be the size (the number of elements) indicated by
		/// the fontAxisValueCount argument.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of font axis values contained in the fontAxisValues array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFace5</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontFace5</c> interface. On successful completion, the function sets the pointer to a
		/// newly created font face object, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The axis values that you provide are permitted to be a subset or superset of all the ones actually supported by the font. Any
		/// unspecified axes use their default values: values beyond the ranges are clamped, and any non-varying axes have no effect.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontresource-createfontface HRESULT
		// CreateFontFace( DWRITE_FONT_SIMULATIONS fontSimulations, DWRITE_FONT_AXIS_VALUE const *fontAxisValues, UINT32 fontAxisValueCount,
		// [out] IDWriteFontFace5 **fontFace );
		IDWriteFontFace5 CreateFontFace(DWRITE_FONT_SIMULATIONS fontSimulations, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues,
			uint fontAxisValueCount);

		/// <summary>Creates a font face reference with specific axis values.</summary>
		/// <param name="fontSimulations">Font face simulation flags for algorithmic emboldening and italicization.</param>
		/// <param name="fontAxisValues">List of font axis values.</param>
		/// <param name="fontAxisValueCount">Number of font axis values.</param>
		/// <remarks>
		/// The passed input axis values are permitted to be a subset or superset of all the ones actually supported by the font. Any
		/// unspecified axes use their default values, values beyond the ranges are clamped, and any non-varying axes have no effect.
		/// </remarks>
		/// <returns>Receives a pointer to the newly created font face reference object, or nullptr on failure.</returns>
		IDWriteFontFaceReference1 CreateFontFaceReference(DWRITE_FONT_SIMULATIONS fontSimulations, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);
	}

	/// <summary>Represents a font set.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontset
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontSet")]
	[ComImport, Guid("53585141-D9F8-4095-8321-D73CF6BD116B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontSet
	{
		/// <summary>Get the number of total fonts in the set.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the number of total fonts in the set.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getfontcount UINT32 GetFontCount();
		[PreserveSig]
		uint GetFontCount();

		/// <summary>Gets a reference to the font at the specified index, which may be local or remote.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>Receives a pointer the font face reference object, or nullptr on failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getfontfacereference HRESULT
		// GetFontFaceReference( UINT32 listIndex, [out] IDWriteFontFaceReference **fontFaceReference );
		IDWriteFontFaceReference GetFontFaceReference(uint listIndex);

		/// <summary>Gets the index of the matching font face reference in the font set, with the same file, face index, and simulations.</summary>
		/// <param name="fontFaceReference">
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>*</b></para>
		/// <para>Font face object that specifies the physical font.</para>
		/// </param>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives the zero-based index of the matching font if the font was found, or UINT_MAX otherwise.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if the font exists or FALSE otherwise.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-findfontfacereference HRESULT
		// FindFontFaceReference( IDWriteFontFaceReference *fontFaceReference, [out] UINT32 *listIndex, [out] BOOL *exists );
		void FindFontFaceReference(IDWriteFontFaceReference fontFaceReference, out uint listIndex, out bool exists);

		/// <summary>Gets the index of the matching font face reference in the font set, with the same file, face index, and simulations.</summary>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>Font face object that specifies the physical font.</para>
		/// </param>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives the zero-based index of the matching font if the font was found, or UINT_MAX otherwise.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if the font exists or FALSE otherwise.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-findfontface HRESULT FindFontFace(
		// IDWriteFontFace *fontFace, [out] UINT32 *listIndex, [out] BOOL *exists );
		void FindFontFace(IDWriteFontFace fontFace, out uint listIndex, out bool exists);

		/// <summary>Returns the property values of a specific font item index.</summary>
		/// <param name="propertyID">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY_ID</c></b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>Receives a pointer to the newly created localized strings object, or nullptr on failure or non-existent property.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyvalues(dwrite_font_property_id_idwritestringlist)
		// HRESULT GetPropertyValues( DWRITE_FONT_PROPERTY_ID propertyID, [out] IDWriteStringList **values );
		IDWriteStringList? GetPropertyValues(DWRITE_FONT_PROPERTY_ID propertyID);

		/// <summary>
		/// Returns all unique property values in the set, which can be used for purposes such as displaying a family list or tag cloud.
		/// Values are returned in priority order according to the language list, such that if a font contains more than one localized name,
		/// then the preferred one is returned.
		/// </summary>
		/// <param name="propertyID">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY_ID</c></b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <param name="preferredLocaleNames">
		/// <para>Type: <b><c>WCHAR</c> const *</b></para>
		/// <para>
		/// The preferred locale names to query as a list of semicolon-delimited names in preferred order. When a particular string (such as
		/// font family) has more than one localized name, then the first match is returned. If the first match doesn't exist, then the
		/// second match is returned, and so on. For example, "ja-jp;en-us".
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>Receives a pointer to the newly created localized strings object; or <c>nullptr</c> on failure or non-existent property.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyvalues(dwrite_font_property_id_wcharconst_idwritestringlist)
		// HRESULT GetPropertyValues( DWRITE_FONT_PROPERTY_ID propertyID, WCHAR const *preferredLocaleNames, IDWriteStringList **values );
		IDWriteStringList? GetPropertyValues(DWRITE_FONT_PROPERTY_ID propertyID, [MarshalAs(UnmanagedType.LPWStr)] string preferredLocaleNames);

		/// <summary>Returns the property values of a specific font item index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font.</para>
		/// </param>
		/// <param name="propertyId">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY_ID</c></b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: [out] <b>BOOL*</b></para>
		/// <para>Receives the value TRUE if the font contains the specified property identifier or FALSE if not.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>Receives a pointer to the newly created localized strings object, or nullptr on failure or non-existent property.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyvalues(uint32_dwrite_font_property_id_bool_idwritelocalizedstrings)
		// HRESULT GetPropertyValues( UINT32 listIndex, DWRITE_FONT_PROPERTY_ID propertyId, BOOL *exists, IDWriteLocalizedStrings **values );
		IDWriteStringList? GetPropertyValues(uint listIndex, DWRITE_FONT_PROPERTY_ID propertyId, out bool exists);

		/// <summary>Returns how many times a given property value occurs in the set.</summary>
		/// <param name="property">
		/// <para>Type: <b>const <c>DWRITE_FONT_PROPERTY</c>*</b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives how many times the property occurs.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyoccurrencecount HRESULT
		// GetPropertyOccurrenceCount( [in] DWRITE_FONT_PROPERTY const *property, [out] UINT32 *propertyOccurrenceCount );
		uint GetPropertyOccurrenceCount(in DWRITE_FONT_PROPERTY property);

		/// <summary>Returns a subset of fonts filtered by the given properties.</summary>
		/// <param name="familyName">The font family name.</param>
		/// <param name="fontWeight">The font weight.</param>
		/// <param name="fontStretch">The font stretch value.</param>
		/// <param name="fontStyle">The font style.</param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>The subset of fonts that match the properties, or nullptr on failure.</para>
		/// </returns>
		/// <remarks>
		/// If no fonts matched the filter, the subset will be empty (GetFontCount returns 0), but the function does not return an error.
		/// The subset will always be equal to or less than the original set. If you only want to filter out remote fonts, you may pass null
		/// in properties and zero in propertyCount.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getmatchingfonts(wcharconst_dwrite_font_weight_dwrite_font_stretch_dwrite_font_style_idwritefontset)
		// HRESULT GetMatchingFonts( WCHAR const *familyName, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STRETCH fontStretch,
		// DWRITE_FONT_STYLE fontStyle, IDWriteFontSet **filteredSet );
		IDWriteFontSet GetMatchingFonts([MarshalAs(UnmanagedType.LPWStr)] string familyName, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STRETCH fontStretch,
			DWRITE_FONT_STYLE fontStyle);

		/// <summary>Returns a subset of fonts filtered by the given properties.</summary>
		/// <param name="properties">
		/// <para>Type: [in] <b>const <c>DWRITE_FONT_PROPERTY</c>*</b></para>
		/// <para>List of properties to filter using.</para>
		/// </param>
		/// <param name="propertyCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of properties to filter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>The subset of fonts that match the properties, or nullptr on failure.</para>
		/// </returns>
		/// <remarks>
		/// If no fonts matched the filter, the subset will be empty (GetFontCount returns 0), but the function does not return an error.
		/// The subset will always be equal to or less than the original set. If you only want to filter out remote fonts, you may pass null
		/// in properties and zero in propertyCount.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getmatchingfonts(dwrite_font_propertyconst_uint32_idwritefontset)
		// HRESULT GetMatchingFonts( DWRITE_FONT_PROPERTY const *properties, UINT32 propertyCount, IDWriteFontSet **filteredSet );
		IDWriteFontSet GetMatchingFonts([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_PROPERTY[] properties, uint propertyCount);
	}

	/// <summary>
	/// <para>Represents a font set.</para>
	/// <para>This interface extends <c>IDWriteFontSet</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontset1
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontSet1")]
	[ComImport, Guid("7E9FDA85-6C92-4053-BC47-7AE3530DB4D3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontSet1 : IDWriteFontSet
	{
		/// <summary>Get the number of total fonts in the set.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the number of total fonts in the set.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getfontcount UINT32 GetFontCount();
		[PreserveSig]
		new uint GetFontCount();

		/// <summary>Gets a reference to the font at the specified index, which may be local or remote.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>Receives a pointer the font face reference object, or nullptr on failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getfontfacereference HRESULT
		// GetFontFaceReference( UINT32 listIndex, [out] IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference GetFontFaceReference(uint listIndex);

		/// <summary>Gets the index of the matching font face reference in the font set, with the same file, face index, and simulations.</summary>
		/// <param name="fontFaceReference">
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>*</b></para>
		/// <para>Font face object that specifies the physical font.</para>
		/// </param>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives the zero-based index of the matching font if the font was found, or UINT_MAX otherwise.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if the font exists or FALSE otherwise.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-findfontfacereference HRESULT
		// FindFontFaceReference( IDWriteFontFaceReference *fontFaceReference, [out] UINT32 *listIndex, [out] BOOL *exists );
		new void FindFontFaceReference([In] IDWriteFontFaceReference fontFaceReference, out uint listIndex, out bool exists);

		/// <summary>Gets the index of the matching font face reference in the font set, with the same file, face index, and simulations.</summary>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>Font face object that specifies the physical font.</para>
		/// </param>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives the zero-based index of the matching font if the font was found, or UINT_MAX otherwise.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if the font exists or FALSE otherwise.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-findfontface HRESULT FindFontFace(
		// IDWriteFontFace *fontFace, [out] UINT32 *listIndex, [out] BOOL *exists );
		new void FindFontFace(IDWriteFontFace fontFace, out uint listIndex, out bool exists);

		/// <summary>Returns the property values of a specific font item index.</summary>
		/// <param name="propertyID">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY_ID</c></b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>Receives a pointer to the newly created localized strings object, or nullptr on failure or non-existent property.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyvalues(dwrite_font_property_id_idwritestringlist)
		// HRESULT GetPropertyValues( DWRITE_FONT_PROPERTY_ID propertyID, [out] IDWriteStringList **values );
		new IDWriteStringList? GetPropertyValues(DWRITE_FONT_PROPERTY_ID propertyID);

		/// <summary>
		/// Returns all unique property values in the set, which can be used for purposes such as displaying a family list or tag cloud.
		/// Values are returned in priority order according to the language list, such that if a font contains more than one localized name,
		/// then the preferred one is returned.
		/// </summary>
		/// <param name="propertyID">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY_ID</c></b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <param name="preferredLocaleNames">
		/// <para>Type: <b><c>WCHAR</c> const *</b></para>
		/// <para>
		/// The preferred locale names to query as a list of semicolon-delimited names in preferred order. When a particular string (such as
		/// font family) has more than one localized name, then the first match is returned. If the first match doesn't exist, then the
		/// second match is returned, and so on. For example, "ja-jp;en-us".
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>Receives a pointer to the newly created localized strings object; or <c>nullptr</c> on failure or non-existent property.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyvalues(dwrite_font_property_id_wcharconst_idwritestringlist)
		// HRESULT GetPropertyValues( DWRITE_FONT_PROPERTY_ID propertyID, WCHAR const *preferredLocaleNames, IDWriteStringList **values );
		new IDWriteStringList? GetPropertyValues(DWRITE_FONT_PROPERTY_ID propertyID, [MarshalAs(UnmanagedType.LPWStr)] string preferredLocaleNames);

		/// <summary>Returns the property values of a specific font item index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font.</para>
		/// </param>
		/// <param name="propertyId">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY_ID</c></b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: [out] <b>BOOL*</b></para>
		/// <para>Receives the value TRUE if the font contains the specified property identifier or FALSE if not.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>Receives a pointer to the newly created localized strings object, or nullptr on failure or non-existent property.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyvalues(uint32_dwrite_font_property_id_bool_idwritelocalizedstrings)
		// HRESULT GetPropertyValues( UINT32 listIndex, DWRITE_FONT_PROPERTY_ID propertyId, BOOL *exists, IDWriteLocalizedStrings **values );
		new IDWriteStringList? GetPropertyValues(uint listIndex, DWRITE_FONT_PROPERTY_ID propertyId, out bool exists);

		/// <summary>Returns how many times a given property value occurs in the set.</summary>
		/// <param name="property">
		/// <para>Type: <b>const <c>DWRITE_FONT_PROPERTY</c>*</b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives how many times the property occurs.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyoccurrencecount HRESULT
		// GetPropertyOccurrenceCount( [in] DWRITE_FONT_PROPERTY const *property, [out] UINT32 *propertyOccurrenceCount );
		new uint GetPropertyOccurrenceCount(in DWRITE_FONT_PROPERTY property);

		/// <summary>Returns a subset of fonts filtered by the given properties.</summary>
		/// <param name="familyName">The font family name.</param>
		/// <param name="fontWeight">The font weight.</param>
		/// <param name="fontStretch">The font stretch value.</param>
		/// <param name="fontStyle">The font style.</param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>The subset of fonts that match the properties, or nullptr on failure.</para>
		/// </returns>
		/// <remarks>
		/// If no fonts matched the filter, the subset will be empty (GetFontCount returns 0), but the function does not return an error.
		/// The subset will always be equal to or less than the original set. If you only want to filter out remote fonts, you may pass null
		/// in properties and zero in propertyCount.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getmatchingfonts(wcharconst_dwrite_font_weight_dwrite_font_stretch_dwrite_font_style_idwritefontset)
		// HRESULT GetMatchingFonts( WCHAR const *familyName, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STRETCH fontStretch,
		// DWRITE_FONT_STYLE fontStyle, IDWriteFontSet **filteredSet );
		new IDWriteFontSet GetMatchingFonts([MarshalAs(UnmanagedType.LPWStr)] string familyName, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STRETCH fontStretch,
			DWRITE_FONT_STYLE fontStyle);

		/// <summary>Returns a subset of fonts filtered by the given properties.</summary>
		/// <param name="properties">
		/// <para>Type: [in] <b>const <c>DWRITE_FONT_PROPERTY</c>*</b></para>
		/// <para>List of properties to filter using.</para>
		/// </param>
		/// <param name="propertyCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of properties to filter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>The subset of fonts that match the properties, or nullptr on failure.</para>
		/// </returns>
		/// <remarks>
		/// If no fonts matched the filter, the subset will be empty (GetFontCount returns 0), but the function does not return an error.
		/// The subset will always be equal to or less than the original set. If you only want to filter out remote fonts, you may pass null
		/// in properties and zero in propertyCount.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getmatchingfonts(dwrite_font_propertyconst_uint32_idwritefontset)
		// HRESULT GetMatchingFonts( DWRITE_FONT_PROPERTY const *properties, UINT32 propertyCount, IDWriteFontSet **filteredSet );
		new IDWriteFontSet GetMatchingFonts([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_PROPERTY[] properties, uint propertyCount);

		/// <summary>Retrieves a matching font set based on the requested inputs, ordered so that nearer matches are earlier.</summary>
		/// <param name="fontProperty">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY</c> const *</b></para>
		/// <para>Font property of interest, such as typographic family or weight/stretch/style family.</para>
		/// </param>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c> const *</b></para>
		/// <para>
		/// A pointer to an array containing a list of font axis values. The array should be the size (the number of elements) indicated by
		/// the fontAxisValueCount argument.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of font axis values contained in the fontAxisValues array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to a
		/// prioritized list of fonts that match the properties, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This method can yield distinct items that were not in the original font set, including items with simulation flags (if they
		/// would be a closer match to the request), and instances that were not named by the font author. Items from the same font
		/// resources are collapsed into one: the closest possible match.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getmatchingfonts HRESULT
		// GetMatchingFonts( DWRITE_FONT_PROPERTY const *fontProperty, DWRITE_FONT_AXIS_VALUE const *fontAxisValues, UINT32
		// fontAxisValueCount, IDWriteFontSet1 **matchingFonts );
		IDWriteFontSet1 GetMatchingFonts([In, Optional] ManagedStructPointer<DWRITE_FONT_PROPERTY> fontProperty,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);

		/// <summary>Retrieves a new font set that contains only the first occurrence of each font resource from the set.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to a
		/// new font set object consisting of single default instances from font resources, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfirstfontresources HRESULT
		// GetFirstFontResources( [out] IDWriteFontSet1 **filteredFontSet );
		IDWriteFontSet1 GetFirstFontResources();

		/// <summary>Retrieves a subset of fonts, filtered by the given indices.</summary>
		/// <param name="indices">
		/// <para>Type: <b><c>UINT32</c> const *</b></para>
		/// <para>An array of indices to filter by, in the range 0 to <c>IDwriteFontSet::GetFontCount</c> minus 1.</para>
		/// </param>
		/// <param name="indexCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of indices.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to an
		/// object representing the subset of fonts indicated by the given indices, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The indices can come in any order, meaning that <b>GetFilteredFonts</b> can produce a new set with items removed, duplicated, or
		/// reordered from the original. If you pass zero indices, then an empty font set is returned.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfonts(uint32const_uint32_idwritefontset1)
		// HRESULT GetFilteredFonts( UINT32 const *indices, UINT32 indexCount, [out] IDWriteFontSet1 **filteredFontSet );
		IDWriteFontSet1 GetFilteredFonts([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] indices, uint indexCount);

		/// <summary>Retrieves a subset of fonts filtered by the given ranges, endpoint-inclusive.</summary>
		/// <param name="fontAxisRanges">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_RANGE</c> const *</b></para>
		/// <para>List of axis value ranges to filter by.</para>
		/// </param>
		/// <param name="fontAxisRangeCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axis value ranges to filter.</para>
		/// </param>
		/// <param name="selectAnyRange">
		/// Type: <b><c>BOOL</c></b>
		/// <para>
		/// <see langword="true"/> if <b>GetFilteredFonts</b> should select any range; <c>false</c> if it should select the intersection of
		/// them all.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to an
		/// object representing the subset of fonts that fall within the ranges, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If no fonts match the filter, then the returned subset object will be empty (calling <c>IDWriteFontSet::GetFontCount</c> on it
		/// returns 0), but the function does not return an error. The subset is always equal to or less than the original set.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfonts(dwrite_font_axis_rangeconst_uint32_bool_idwritefontset1)
		// HRESULT GetFilteredFonts( DWRITE_FONT_AXIS_RANGE const *fontAxisRanges, UINT32 fontAxisRangeCount, BOOL selectAnyRange, [out]
		// IDWriteFontSet1 **filteredFontSet );
		IDWriteFontSet1 GetFilteredFonts([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges, uint fontAxisRangeCount, bool selectAnyRange);

		/// <summary>Retrieves a subset of fonts filtered by the given properties.</summary>
		/// <param name="properties">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY</c> const *</b></para>
		/// <para>List of properties to filter by.</para>
		/// </param>
		/// <param name="propertyCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of properties to filter.</para>
		/// </param>
		/// <param name="selectAnyProperty">
		/// Type: <b><c>BOOL</c></b>
		/// <para>
		/// <see langword="true"/> if <b>GetFilteredFonts</b> should select any property; <c>false</c> if it should select the intersection
		/// of them all.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to an
		/// object representing the subset of fonts that match the properties, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If no fonts match the filter, then the returned subset object will be empty (calling <c>IDWriteFontSet::GetFontCount</c> on it
		/// returns 0), but the function does not return an error. The subset is always equal to or less than the original set.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfonts(dwrite_font_propertyconst_uint32_bool_idwritefontset1)
		// HRESULT GetFilteredFonts( DWRITE_FONT_PROPERTY const *properties, UINT32 propertyCount, BOOL selectAnyProperty, [out]
		// IDWriteFontSet1 **filteredFontSet );
		IDWriteFontSet1 GetFilteredFonts([In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_PROPERTY[]? properties, [Optional] uint propertyCount, bool selectAnyProperty = false);

		/// <summary>Retrieves all the item indices, filtered by the given ranges.</summary>
		/// <param name="fontAxisRanges">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_RANGE</c> const *</b></para>
		/// <para>List of axis value ranges to filter by.</para>
		/// </param>
		/// <param name="fontAxisRangeCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axis value ranges to filter.</para>
		/// </param>
		/// <param name="selectAnyRange">
		/// Type: <b><c>BOOL</c></b>
		/// <para>
		/// <see langword="true"/> if <b>GetFilteredFontIndices</b> should select any range; <c>false</c> if it should select the
		/// intersection of them all.
		/// </para>
		/// </param>
		/// <param name="indices">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>An ascending array of indices, in the range 0 to <c>IDwriteFontSet::GetFontCount</c> minus 1.</para>
		/// </param>
		/// <param name="maxIndexCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of indices.</para>
		/// </param>
		/// <param name="actualIndexCount">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>The actual number of indices written or needed, in the range 0 to <c>IDwriteFontSet::GetFontCount</c> minus 1.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfontindices(dwrite_font_axis_rangeconst_uint32_bool_uint32_uint32_uint32)
		// HRESULT GetFilteredFontIndices( DWRITE_FONT_AXIS_RANGE const *fontAxisRanges, UINT32 fontAxisRangeCount, BOOL selectAnyRange,
		// [out] UINT32 *indices, UINT32 maxIndexCount, [out] UINT32 *actualIndexCount );
		void GetFilteredFontIndices([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges, uint fontAxisRangeCount,
			bool selectAnyRange, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[] indices, uint maxIndexCount,
			out uint actualIndexCount);

		/// <summary>Get all the item indices filtered by the given properties.</summary>
		/// <param name="properties">List of properties to filter using.</param>
		/// <param name="propertyCount">How many properties to filter.</param>
		/// <param name="selectAnyProperty">Select any property rather rather than the intersection of them all.</param>
		/// <param name="indices">Ascending array of indices [0..GetFontCount() - 1].</param>
		/// <param name="maxIndexCount">Number of indices.</param>
		/// <param name="actualIndexCount">Actual number of indices written or needed [0..GetFontCount()-1].</param>
		/// <remarks>The actualIndexCount will always be &lt;= IDwriteFontSet::GetFontCount.</remarks>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfontindices(dwrite_font_propertyconst_uint32_bool_uint32_uint32_uint32)
		// HRESULT GetFilteredFontIndices( DWRITE_FONT_PROPERTY const *properties, UINT32 propertyCount, BOOL selectAnyProperty, UINT32
		// *indices, UINT32 maxIndexCount, UINT32 *actualIndexCount );
		void GetFilteredFontIndices([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_PROPERTY[] properties, uint propertyCount,
			bool selectAnyProperty, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[] indices, uint maxIndexCount,
			out uint actualIndexCount);

		/// <summary>Retrieves the axis ranges of a single item.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font in the set.</para>
		/// </param>
		/// <param name="fontAxisRanges">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_RANGE</c>*</b></para>
		/// <para>List of axis value ranges to retrieve.</para>
		/// </param>
		/// <param name="maxFontAxisRangeCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axis value ranges to retrieve.</para>
		/// </param>
		/// <param name="actualFontAxisRangeCount">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>The actual number of axis ranges written or needed.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfontaxisranges(uint32_dwrite_font_axis_range_uint32_uint32)
		// HRESULT GetFontAxisRanges( UINT32 listIndex, [out] DWRITE_FONT_AXIS_RANGE *fontAxisRanges, UINT32 maxFontAxisRangeCount, [out]
		// UINT32 *actualFontAxisRangeCount );
		void GetFontAxisRanges(uint listIndex, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges,
			uint maxFontAxisRangeCount, out uint actualFontAxisRangeCount);

		/// <summary>Gets all axis ranges in the font set, the union of all contained items.</summary>
		/// <param name="fontAxisRanges">List of axis ranges.</param>
		/// <param name="maxFontAxisRangeCount">Number of axis ranges.</param>
		/// <param name="actualFontAxisRangeCount">Actual number of axis ranges written or needed.</param>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontset1-getfontaxisranges(dwrite_font_axis_range_uint32_uint32)
		// HRESULT GetFontAxisRanges( DWRITE_FONT_AXIS_RANGE *fontAxisRanges, UINT32 maxFontAxisRangeCount, UINT32 *actualFontAxisRangeCount );
		void GetFontAxisRanges([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges,
			uint maxFontAxisRangeCount, out uint actualFontAxisRangeCount);

		/// <summary>Retrieves the font face reference of a single item.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font item in the set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontFaceReference1</c> interface. On successful completion, the function sets the
		/// pointer to the font face reference.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfontfacereference HRESULT
		// GetFontFaceReference( UINT32 listIndex, IDWriteFontFaceReference1 **fontFaceReference );
		IDWriteFontFaceReference1 GetFontFaceReference1(uint listIndex);

		/// <summary>Creates the font resource of a single item.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font item in the set.</para>
		/// </param>
		/// <param name="fontResource">
		/// <para>Type: <b><c>IDWriteFontResource</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontResource</c> interface. On successful completion, the function sets the pointer to
		/// a newly created font resource object.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DWRITE_E_REMOTEFONT</description>
		/// <description>The file is not local.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-createfontresource HRESULT
		// CreateFontResource( UINT32 listIndex, [out] IDWriteFontResource **fontResource );
		[PreserveSig]
		HRESULT CreateFontResource(uint listIndex, out IDWriteFontResource fontResource);

		/// <summary>Creates a font face for a single item (rather than going through the font face reference).</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font item in the set.</para>
		/// </param>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace5</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontFace5</c> interface. On successful completion, the function sets the pointer to a
		/// newly created font face object.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DWRITE_E_REMOTEFONT</description>
		/// <description>The font is not local.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-createfontface HRESULT CreateFontFace(
		// UINT32 listIndex, [out] IDWriteFontFace5 **fontFace );
		[PreserveSig]
		HRESULT CreateFontFace(uint listIndex, out IDWriteFontFace5 fontFace);

		/// <summary>Retrieves the locality of a single item.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font item in the set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_LOCALITY</c></b></para>
		/// <para>A value indicating the locality.</para>
		/// </returns>
		/// <remarks>
		/// The locality enumeration. For fully local files, the result will always be <b>DWRITE_LOCALITY_LOCAL</b>. For downloadable files,
		/// the result depends on how much of the file has been downloaded.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfontlocality DWRITE_LOCALITY
		// GetFontLocality( UINT32 listIndex );
		[PreserveSig]
		DWRITE_LOCALITY GetFontLocality(uint listIndex);
	}

	/// <summary>
	/// <para>Represents a font set.</para>
	/// <para>This interface extends <c>IDWriteFontSet1</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontset2
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontSet2")]
	[ComImport, Guid("DC7EAD19-E54C-43AF-B2DA-4E2B79BA3F7F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontSet2 : IDWriteFontSet, IDWriteFontSet1
	{
		/// <summary>Get the number of total fonts in the set.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the number of total fonts in the set.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getfontcount UINT32 GetFontCount();
		[PreserveSig]
		new uint GetFontCount();

		/// <summary>Gets a reference to the font at the specified index, which may be local or remote.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>Receives a pointer the font face reference object, or nullptr on failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getfontfacereference HRESULT
		// GetFontFaceReference( UINT32 listIndex, [out] IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference GetFontFaceReference(uint listIndex);

		/// <summary>Gets the index of the matching font face reference in the font set, with the same file, face index, and simulations.</summary>
		/// <param name="fontFaceReference">
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>*</b></para>
		/// <para>Font face object that specifies the physical font.</para>
		/// </param>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives the zero-based index of the matching font if the font was found, or UINT_MAX otherwise.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if the font exists or FALSE otherwise.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-findfontfacereference HRESULT
		// FindFontFaceReference( IDWriteFontFaceReference *fontFaceReference, [out] UINT32 *listIndex, [out] BOOL *exists );
		new void FindFontFaceReference([In] IDWriteFontFaceReference fontFaceReference, out uint listIndex, out bool exists);

		/// <summary>Gets the index of the matching font face reference in the font set, with the same file, face index, and simulations.</summary>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>Font face object that specifies the physical font.</para>
		/// </param>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives the zero-based index of the matching font if the font was found, or UINT_MAX otherwise.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if the font exists or FALSE otherwise.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-findfontface HRESULT FindFontFace(
		// IDWriteFontFace *fontFace, [out] UINT32 *listIndex, [out] BOOL *exists );
		new void FindFontFace(IDWriteFontFace fontFace, out uint listIndex, out bool exists);

		/// <summary>Returns the property values of a specific font item index.</summary>
		/// <param name="propertyID">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY_ID</c></b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>Receives a pointer to the newly created localized strings object, or nullptr on failure or non-existent property.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyvalues(dwrite_font_property_id_idwritestringlist)
		// HRESULT GetPropertyValues( DWRITE_FONT_PROPERTY_ID propertyID, [out] IDWriteStringList **values );
		new IDWriteStringList? GetPropertyValues(DWRITE_FONT_PROPERTY_ID propertyID);

		/// <summary>
		/// Returns all unique property values in the set, which can be used for purposes such as displaying a family list or tag cloud.
		/// Values are returned in priority order according to the language list, such that if a font contains more than one localized name,
		/// then the preferred one is returned.
		/// </summary>
		/// <param name="propertyID">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY_ID</c></b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <param name="preferredLocaleNames">
		/// <para>Type: <b><c>WCHAR</c> const *</b></para>
		/// <para>
		/// The preferred locale names to query as a list of semicolon-delimited names in preferred order. When a particular string (such as
		/// font family) has more than one localized name, then the first match is returned. If the first match doesn't exist, then the
		/// second match is returned, and so on. For example, "ja-jp;en-us".
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>Receives a pointer to the newly created localized strings object; or <c>nullptr</c> on failure or non-existent property.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyvalues(dwrite_font_property_id_wcharconst_idwritestringlist)
		// HRESULT GetPropertyValues( DWRITE_FONT_PROPERTY_ID propertyID, WCHAR const *preferredLocaleNames, IDWriteStringList **values );
		new IDWriteStringList? GetPropertyValues(DWRITE_FONT_PROPERTY_ID propertyID, [MarshalAs(UnmanagedType.LPWStr)] string preferredLocaleNames);

		/// <summary>Returns the property values of a specific font item index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font.</para>
		/// </param>
		/// <param name="propertyId">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY_ID</c></b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: [out] <b>BOOL*</b></para>
		/// <para>Receives the value TRUE if the font contains the specified property identifier or FALSE if not.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>Receives a pointer to the newly created localized strings object, or nullptr on failure or non-existent property.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyvalues(uint32_dwrite_font_property_id_bool_idwritelocalizedstrings)
		// HRESULT GetPropertyValues( UINT32 listIndex, DWRITE_FONT_PROPERTY_ID propertyId, BOOL *exists, IDWriteLocalizedStrings **values );
		new IDWriteStringList? GetPropertyValues(uint listIndex, DWRITE_FONT_PROPERTY_ID propertyId, out bool exists);

		/// <summary>Returns how many times a given property value occurs in the set.</summary>
		/// <param name="property">
		/// <para>Type: <b>const <c>DWRITE_FONT_PROPERTY</c>*</b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives how many times the property occurs.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyoccurrencecount HRESULT
		// GetPropertyOccurrenceCount( [in] DWRITE_FONT_PROPERTY const *property, [out] UINT32 *propertyOccurrenceCount );
		new uint GetPropertyOccurrenceCount(in DWRITE_FONT_PROPERTY property);

		/// <summary>Returns a subset of fonts filtered by the given properties.</summary>
		/// <param name="familyName">The font family name.</param>
		/// <param name="fontWeight">The font weight.</param>
		/// <param name="fontStretch">The font stretch value.</param>
		/// <param name="fontStyle">The font style.</param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>The subset of fonts that match the properties, or nullptr on failure.</para>
		/// </returns>
		/// <remarks>
		/// If no fonts matched the filter, the subset will be empty (GetFontCount returns 0), but the function does not return an error.
		/// The subset will always be equal to or less than the original set. If you only want to filter out remote fonts, you may pass null
		/// in properties and zero in propertyCount.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getmatchingfonts(wcharconst_dwrite_font_weight_dwrite_font_stretch_dwrite_font_style_idwritefontset)
		// HRESULT GetMatchingFonts( WCHAR const *familyName, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STRETCH fontStretch,
		// DWRITE_FONT_STYLE fontStyle, IDWriteFontSet **filteredSet );
		new IDWriteFontSet GetMatchingFonts([MarshalAs(UnmanagedType.LPWStr)] string familyName, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STRETCH fontStretch,
			DWRITE_FONT_STYLE fontStyle);

		/// <summary>Returns a subset of fonts filtered by the given properties.</summary>
		/// <param name="properties">
		/// <para>Type: [in] <b>const <c>DWRITE_FONT_PROPERTY</c>*</b></para>
		/// <para>List of properties to filter using.</para>
		/// </param>
		/// <param name="propertyCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of properties to filter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>The subset of fonts that match the properties, or nullptr on failure.</para>
		/// </returns>
		/// <remarks>
		/// If no fonts matched the filter, the subset will be empty (GetFontCount returns 0), but the function does not return an error.
		/// The subset will always be equal to or less than the original set. If you only want to filter out remote fonts, you may pass null
		/// in properties and zero in propertyCount.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getmatchingfonts(dwrite_font_propertyconst_uint32_idwritefontset)
		// HRESULT GetMatchingFonts( DWRITE_FONT_PROPERTY const *properties, UINT32 propertyCount, IDWriteFontSet **filteredSet );
		new IDWriteFontSet GetMatchingFonts([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_PROPERTY[] properties, uint propertyCount);

		/// <summary>Retrieves a matching font set based on the requested inputs, ordered so that nearer matches are earlier.</summary>
		/// <param name="fontProperty">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY</c> const *</b></para>
		/// <para>Font property of interest, such as typographic family or weight/stretch/style family.</para>
		/// </param>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c> const *</b></para>
		/// <para>
		/// A pointer to an array containing a list of font axis values. The array should be the size (the number of elements) indicated by
		/// the fontAxisValueCount argument.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of font axis values contained in the fontAxisValues array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to a
		/// prioritized list of fonts that match the properties, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This method can yield distinct items that were not in the original font set, including items with simulation flags (if they
		/// would be a closer match to the request), and instances that were not named by the font author. Items from the same font
		/// resources are collapsed into one: the closest possible match.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getmatchingfonts HRESULT
		// GetMatchingFonts( DWRITE_FONT_PROPERTY const *fontProperty, DWRITE_FONT_AXIS_VALUE const *fontAxisValues, UINT32
		// fontAxisValueCount, IDWriteFontSet1 **matchingFonts );
		new IDWriteFontSet1 GetMatchingFonts([In, Optional] ManagedStructPointer<DWRITE_FONT_PROPERTY> fontProperty,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);

		/// <summary>Retrieves a new font set that contains only the first occurrence of each font resource from the set.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to a
		/// new font set object consisting of single default instances from font resources, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfirstfontresources HRESULT
		// GetFirstFontResources( [out] IDWriteFontSet1 **filteredFontSet );
		new IDWriteFontSet1 GetFirstFontResources();

		/// <summary>Retrieves a subset of fonts, filtered by the given indices.</summary>
		/// <param name="indices">
		/// <para>Type: <b><c>UINT32</c> const *</b></para>
		/// <para>An array of indices to filter by, in the range 0 to <c>IDwriteFontSet::GetFontCount</c> minus 1.</para>
		/// </param>
		/// <param name="indexCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of indices.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to an
		/// object representing the subset of fonts indicated by the given indices, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The indices can come in any order, meaning that <b>GetFilteredFonts</b> can produce a new set with items removed, duplicated, or
		/// reordered from the original. If you pass zero indices, then an empty font set is returned.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfonts(uint32const_uint32_idwritefontset1)
		// HRESULT GetFilteredFonts( UINT32 const *indices, UINT32 indexCount, [out] IDWriteFontSet1 **filteredFontSet );
		new IDWriteFontSet1 GetFilteredFonts([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] indices, uint indexCount);

		/// <summary>Retrieves a subset of fonts filtered by the given ranges, endpoint-inclusive.</summary>
		/// <param name="fontAxisRanges">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_RANGE</c> const *</b></para>
		/// <para>List of axis value ranges to filter by.</para>
		/// </param>
		/// <param name="fontAxisRangeCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axis value ranges to filter.</para>
		/// </param>
		/// <param name="selectAnyRange">
		/// Type: <b><c>BOOL</c></b>
		/// <para>
		/// <see langword="true"/> if <b>GetFilteredFonts</b> should select any range; <c>false</c> if it should select the intersection of
		/// them all.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to an
		/// object representing the subset of fonts that fall within the ranges, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If no fonts match the filter, then the returned subset object will be empty (calling <c>IDWriteFontSet::GetFontCount</c> on it
		/// returns 0), but the function does not return an error. The subset is always equal to or less than the original set.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfonts(dwrite_font_axis_rangeconst_uint32_bool_idwritefontset1)
		// HRESULT GetFilteredFonts( DWRITE_FONT_AXIS_RANGE const *fontAxisRanges, UINT32 fontAxisRangeCount, BOOL selectAnyRange, [out]
		// IDWriteFontSet1 **filteredFontSet );
		new IDWriteFontSet1 GetFilteredFonts([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges, uint fontAxisRangeCount, bool selectAnyRange);

		/// <summary>Retrieves a subset of fonts filtered by the given properties.</summary>
		/// <param name="properties">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY</c> const *</b></para>
		/// <para>List of properties to filter by.</para>
		/// </param>
		/// <param name="propertyCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of properties to filter.</para>
		/// </param>
		/// <param name="selectAnyProperty">
		/// Type: <b><c>BOOL</c></b>
		/// <para>
		/// <see langword="true"/> if <b>GetFilteredFonts</b> should select any property; <c>false</c> if it should select the intersection
		/// of them all.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to an
		/// object representing the subset of fonts that match the properties, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If no fonts match the filter, then the returned subset object will be empty (calling <c>IDWriteFontSet::GetFontCount</c> on it
		/// returns 0), but the function does not return an error. The subset is always equal to or less than the original set.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfonts(dwrite_font_propertyconst_uint32_bool_idwritefontset1)
		// HRESULT GetFilteredFonts( DWRITE_FONT_PROPERTY const *properties, UINT32 propertyCount, BOOL selectAnyProperty, [out]
		// IDWriteFontSet1 **filteredFontSet );
		new IDWriteFontSet1 GetFilteredFonts([In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_PROPERTY[]? properties, [Optional] uint propertyCount, bool selectAnyProperty = false);

		/// <summary>Retrieves all the item indices, filtered by the given ranges.</summary>
		/// <param name="fontAxisRanges">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_RANGE</c> const *</b></para>
		/// <para>List of axis value ranges to filter by.</para>
		/// </param>
		/// <param name="fontAxisRangeCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axis value ranges to filter.</para>
		/// </param>
		/// <param name="selectAnyRange">
		/// Type: <b><c>BOOL</c></b>
		/// <para>
		/// <see langword="true"/> if <b>GetFilteredFontIndices</b> should select any range; <c>false</c> if it should select the
		/// intersection of them all.
		/// </para>
		/// </param>
		/// <param name="indices">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>An ascending array of indices, in the range 0 to <c>IDwriteFontSet::GetFontCount</c> minus 1.</para>
		/// </param>
		/// <param name="maxIndexCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of indices.</para>
		/// </param>
		/// <param name="actualIndexCount">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>The actual number of indices written or needed, in the range 0 to <c>IDwriteFontSet::GetFontCount</c> minus 1.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfontindices(dwrite_font_axis_rangeconst_uint32_bool_uint32_uint32_uint32)
		// HRESULT GetFilteredFontIndices( DWRITE_FONT_AXIS_RANGE const *fontAxisRanges, UINT32 fontAxisRangeCount, BOOL selectAnyRange,
		// [out] UINT32 *indices, UINT32 maxIndexCount, [out] UINT32 *actualIndexCount );
		new void GetFilteredFontIndices([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges, uint fontAxisRangeCount,
			bool selectAnyRange, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[] indices, uint maxIndexCount,
			out uint actualIndexCount);

		/// <summary>Get all the item indices filtered by the given properties.</summary>
		/// <param name="properties">List of properties to filter using.</param>
		/// <param name="propertyCount">How many properties to filter.</param>
		/// <param name="selectAnyProperty">Select any property rather rather than the intersection of them all.</param>
		/// <param name="indices">Ascending array of indices [0..GetFontCount() - 1].</param>
		/// <param name="maxIndexCount">Number of indices.</param>
		/// <param name="actualIndexCount">Actual number of indices written or needed [0..GetFontCount()-1].</param>
		/// <remarks>The actualIndexCount will always be &lt;= IDwriteFontSet::GetFontCount.</remarks>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfontindices(dwrite_font_propertyconst_uint32_bool_uint32_uint32_uint32)
		// HRESULT GetFilteredFontIndices( DWRITE_FONT_PROPERTY const *properties, UINT32 propertyCount, BOOL selectAnyProperty, UINT32
		// *indices, UINT32 maxIndexCount, UINT32 *actualIndexCount );
		new void GetFilteredFontIndices([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_PROPERTY[] properties, uint propertyCount,
			bool selectAnyProperty, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[] indices, uint maxIndexCount,
			out uint actualIndexCount);

		/// <summary>Retrieves the axis ranges of a single item.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font in the set.</para>
		/// </param>
		/// <param name="fontAxisRanges">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_RANGE</c>*</b></para>
		/// <para>List of axis value ranges to retrieve.</para>
		/// </param>
		/// <param name="maxFontAxisRangeCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axis value ranges to retrieve.</para>
		/// </param>
		/// <param name="actualFontAxisRangeCount">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>The actual number of axis ranges written or needed.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfontaxisranges(uint32_dwrite_font_axis_range_uint32_uint32)
		// HRESULT GetFontAxisRanges( UINT32 listIndex, [out] DWRITE_FONT_AXIS_RANGE *fontAxisRanges, UINT32 maxFontAxisRangeCount, [out]
		// UINT32 *actualFontAxisRangeCount );
		new void GetFontAxisRanges(uint listIndex, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges,
			uint maxFontAxisRangeCount, out uint actualFontAxisRangeCount);

		/// <summary>Gets all axis ranges in the font set, the union of all contained items.</summary>
		/// <param name="fontAxisRanges">List of axis ranges.</param>
		/// <param name="maxFontAxisRangeCount">Number of axis ranges.</param>
		/// <param name="actualFontAxisRangeCount">Actual number of axis ranges written or needed.</param>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontset1-getfontaxisranges(dwrite_font_axis_range_uint32_uint32)
		// HRESULT GetFontAxisRanges( DWRITE_FONT_AXIS_RANGE *fontAxisRanges, UINT32 maxFontAxisRangeCount, UINT32 *actualFontAxisRangeCount );
		new void GetFontAxisRanges([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges,
			uint maxFontAxisRangeCount, out uint actualFontAxisRangeCount);

		/// <summary>Retrieves the font face reference of a single item.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font item in the set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontFaceReference1</c> interface. On successful completion, the function sets the
		/// pointer to the font face reference.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfontfacereference HRESULT
		// GetFontFaceReference( UINT32 listIndex, IDWriteFontFaceReference1 **fontFaceReference );
		new IDWriteFontFaceReference1 GetFontFaceReference1(uint listIndex);

		/// <summary>Creates the font resource of a single item.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font item in the set.</para>
		/// </param>
		/// <param name="fontResource">
		/// <para>Type: <b><c>IDWriteFontResource</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontResource</c> interface. On successful completion, the function sets the pointer to
		/// a newly created font resource object.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DWRITE_E_REMOTEFONT</description>
		/// <description>The file is not local.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-createfontresource HRESULT
		// CreateFontResource( UINT32 listIndex, [out] IDWriteFontResource **fontResource );
		[PreserveSig]
		new HRESULT CreateFontResource(uint listIndex, out IDWriteFontResource fontResource);

		/// <summary>Creates a font face for a single item (rather than going through the font face reference).</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font item in the set.</para>
		/// </param>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace5</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontFace5</c> interface. On successful completion, the function sets the pointer to a
		/// newly created font face object.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DWRITE_E_REMOTEFONT</description>
		/// <description>The font is not local.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-createfontface HRESULT CreateFontFace(
		// UINT32 listIndex, [out] IDWriteFontFace5 **fontFace );
		[PreserveSig]
		new HRESULT CreateFontFace(uint listIndex, out IDWriteFontFace5 fontFace);

		/// <summary>Retrieves the locality of a single item.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font item in the set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_LOCALITY</c></b></para>
		/// <para>A value indicating the locality.</para>
		/// </returns>
		/// <remarks>
		/// The locality enumeration. For fully local files, the result will always be <b>DWRITE_LOCALITY_LOCAL</b>. For downloadable files,
		/// the result depends on how much of the file has been downloaded.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfontlocality DWRITE_LOCALITY
		// GetFontLocality( UINT32 listIndex );
		[PreserveSig]
		new DWRITE_LOCALITY GetFontLocality(uint listIndex);

		/// <summary>
		/// Retrieves the expiration event for the font set, if any. The expiration event is set on a system font set object if it is out of
		/// date due to fonts being installed, uninstalled, or updated. You should handle the event by getting a new system font set.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>HANDLE</c></b></para>
		/// <para>An event handle, if called on the system font set, or <c>nullptr</c> if called on a custom font set.</para>
		/// </returns>
		/// <remarks>
		/// You mustn't call <b>CloseHandle</b> on the returned event handle. The handle is owned by the font set object, and it remains
		/// valid as long as you hold a reference to the font set. You can wait on the returned event, or use
		/// <c>RegisterWaitForSingleObject</c> to request a callback when the event is set.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset2-getexpirationevent HANDLE GetExpirationEvent();
		[PreserveSig]
		HEVENT GetExpirationEvent();
	}

	/// <summary>
	/// <para>Represents a font set.</para>
	/// <para>This interface extends <c>IDWriteFontSet2</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontset3
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontSet3")]
	[ComImport, Guid("7C073EF2-A7F4-4045-8C32-8AB8AE640F90"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontSet3 : IDWriteFontSet, IDWriteFontSet1, IDWriteFontSet2
	{
		/// <summary>Get the number of total fonts in the set.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the number of total fonts in the set.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getfontcount UINT32 GetFontCount();
		[PreserveSig]
		new uint GetFontCount();

		/// <summary>Gets a reference to the font at the specified index, which may be local or remote.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>Receives a pointer the font face reference object, or nullptr on failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getfontfacereference HRESULT
		// GetFontFaceReference( UINT32 listIndex, [out] IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference GetFontFaceReference(uint listIndex);

		/// <summary>Gets the index of the matching font face reference in the font set, with the same file, face index, and simulations.</summary>
		/// <param name="fontFaceReference">
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>*</b></para>
		/// <para>Font face object that specifies the physical font.</para>
		/// </param>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives the zero-based index of the matching font if the font was found, or UINT_MAX otherwise.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if the font exists or FALSE otherwise.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-findfontfacereference HRESULT
		// FindFontFaceReference( IDWriteFontFaceReference *fontFaceReference, [out] UINT32 *listIndex, [out] BOOL *exists );
		new void FindFontFaceReference([In] IDWriteFontFaceReference fontFaceReference, out uint listIndex, out bool exists);

		/// <summary>Gets the index of the matching font face reference in the font set, with the same file, face index, and simulations.</summary>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>Font face object that specifies the physical font.</para>
		/// </param>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives the zero-based index of the matching font if the font was found, or UINT_MAX otherwise.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if the font exists or FALSE otherwise.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-findfontface HRESULT FindFontFace(
		// IDWriteFontFace *fontFace, [out] UINT32 *listIndex, [out] BOOL *exists );
		new void FindFontFace(IDWriteFontFace fontFace, out uint listIndex, out bool exists);

		/// <summary>Returns the property values of a specific font item index.</summary>
		/// <param name="propertyID">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY_ID</c></b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>Receives a pointer to the newly created localized strings object, or nullptr on failure or non-existent property.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyvalues(dwrite_font_property_id_idwritestringlist)
		// HRESULT GetPropertyValues( DWRITE_FONT_PROPERTY_ID propertyID, [out] IDWriteStringList **values );
		new IDWriteStringList? GetPropertyValues(DWRITE_FONT_PROPERTY_ID propertyID);

		/// <summary>
		/// Returns all unique property values in the set, which can be used for purposes such as displaying a family list or tag cloud.
		/// Values are returned in priority order according to the language list, such that if a font contains more than one localized name,
		/// then the preferred one is returned.
		/// </summary>
		/// <param name="propertyID">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY_ID</c></b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <param name="preferredLocaleNames">
		/// <para>Type: <b><c>WCHAR</c> const *</b></para>
		/// <para>
		/// The preferred locale names to query as a list of semicolon-delimited names in preferred order. When a particular string (such as
		/// font family) has more than one localized name, then the first match is returned. If the first match doesn't exist, then the
		/// second match is returned, and so on. For example, "ja-jp;en-us".
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>Receives a pointer to the newly created localized strings object; or <c>nullptr</c> on failure or non-existent property.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyvalues(dwrite_font_property_id_wcharconst_idwritestringlist)
		// HRESULT GetPropertyValues( DWRITE_FONT_PROPERTY_ID propertyID, WCHAR const *preferredLocaleNames, IDWriteStringList **values );
		new IDWriteStringList? GetPropertyValues(DWRITE_FONT_PROPERTY_ID propertyID, [MarshalAs(UnmanagedType.LPWStr)] string preferredLocaleNames);

		/// <summary>Returns the property values of a specific font item index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font.</para>
		/// </param>
		/// <param name="propertyId">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY_ID</c></b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: [out] <b>BOOL*</b></para>
		/// <para>Receives the value TRUE if the font contains the specified property identifier or FALSE if not.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>Receives a pointer to the newly created localized strings object, or nullptr on failure or non-existent property.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyvalues(uint32_dwrite_font_property_id_bool_idwritelocalizedstrings)
		// HRESULT GetPropertyValues( UINT32 listIndex, DWRITE_FONT_PROPERTY_ID propertyId, BOOL *exists, IDWriteLocalizedStrings **values );
		new IDWriteStringList? GetPropertyValues(uint listIndex, DWRITE_FONT_PROPERTY_ID propertyId, out bool exists);

		/// <summary>Returns how many times a given property value occurs in the set.</summary>
		/// <param name="property">
		/// <para>Type: <b>const <c>DWRITE_FONT_PROPERTY</c>*</b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives how many times the property occurs.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyoccurrencecount HRESULT
		// GetPropertyOccurrenceCount( [in] DWRITE_FONT_PROPERTY const *property, [out] UINT32 *propertyOccurrenceCount );
		new uint GetPropertyOccurrenceCount(in DWRITE_FONT_PROPERTY property);

		/// <summary>Returns a subset of fonts filtered by the given properties.</summary>
		/// <param name="familyName">The font family name.</param>
		/// <param name="fontWeight">The font weight.</param>
		/// <param name="fontStretch">The font stretch value.</param>
		/// <param name="fontStyle">The font style.</param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>The subset of fonts that match the properties, or nullptr on failure.</para>
		/// </returns>
		/// <remarks>
		/// If no fonts matched the filter, the subset will be empty (GetFontCount returns 0), but the function does not return an error.
		/// The subset will always be equal to or less than the original set. If you only want to filter out remote fonts, you may pass null
		/// in properties and zero in propertyCount.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getmatchingfonts(wcharconst_dwrite_font_weight_dwrite_font_stretch_dwrite_font_style_idwritefontset)
		// HRESULT GetMatchingFonts( WCHAR const *familyName, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STRETCH fontStretch,
		// DWRITE_FONT_STYLE fontStyle, IDWriteFontSet **filteredSet );
		new IDWriteFontSet GetMatchingFonts([MarshalAs(UnmanagedType.LPWStr)] string familyName, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STRETCH fontStretch,
			DWRITE_FONT_STYLE fontStyle);

		/// <summary>Returns a subset of fonts filtered by the given properties.</summary>
		/// <param name="properties">
		/// <para>Type: [in] <b>const <c>DWRITE_FONT_PROPERTY</c>*</b></para>
		/// <para>List of properties to filter using.</para>
		/// </param>
		/// <param name="propertyCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of properties to filter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>The subset of fonts that match the properties, or nullptr on failure.</para>
		/// </returns>
		/// <remarks>
		/// If no fonts matched the filter, the subset will be empty (GetFontCount returns 0), but the function does not return an error.
		/// The subset will always be equal to or less than the original set. If you only want to filter out remote fonts, you may pass null
		/// in properties and zero in propertyCount.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getmatchingfonts(dwrite_font_propertyconst_uint32_idwritefontset)
		// HRESULT GetMatchingFonts( DWRITE_FONT_PROPERTY const *properties, UINT32 propertyCount, IDWriteFontSet **filteredSet );
		new IDWriteFontSet GetMatchingFonts([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_PROPERTY[] properties, uint propertyCount);

		/// <summary>Retrieves a matching font set based on the requested inputs, ordered so that nearer matches are earlier.</summary>
		/// <param name="fontProperty">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY</c> const *</b></para>
		/// <para>Font property of interest, such as typographic family or weight/stretch/style family.</para>
		/// </param>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c> const *</b></para>
		/// <para>
		/// A pointer to an array containing a list of font axis values. The array should be the size (the number of elements) indicated by
		/// the fontAxisValueCount argument.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of font axis values contained in the fontAxisValues array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to a
		/// prioritized list of fonts that match the properties, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This method can yield distinct items that were not in the original font set, including items with simulation flags (if they
		/// would be a closer match to the request), and instances that were not named by the font author. Items from the same font
		/// resources are collapsed into one: the closest possible match.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getmatchingfonts HRESULT
		// GetMatchingFonts( DWRITE_FONT_PROPERTY const *fontProperty, DWRITE_FONT_AXIS_VALUE const *fontAxisValues, UINT32
		// fontAxisValueCount, IDWriteFontSet1 **matchingFonts );
		new IDWriteFontSet1 GetMatchingFonts([In, Optional] ManagedStructPointer<DWRITE_FONT_PROPERTY> fontProperty,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);

		/// <summary>Retrieves a new font set that contains only the first occurrence of each font resource from the set.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to a
		/// new font set object consisting of single default instances from font resources, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfirstfontresources HRESULT
		// GetFirstFontResources( [out] IDWriteFontSet1 **filteredFontSet );
		new IDWriteFontSet1 GetFirstFontResources();

		/// <summary>Retrieves a subset of fonts, filtered by the given indices.</summary>
		/// <param name="indices">
		/// <para>Type: <b><c>UINT32</c> const *</b></para>
		/// <para>An array of indices to filter by, in the range 0 to <c>IDwriteFontSet::GetFontCount</c> minus 1.</para>
		/// </param>
		/// <param name="indexCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of indices.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to an
		/// object representing the subset of fonts indicated by the given indices, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The indices can come in any order, meaning that <b>GetFilteredFonts</b> can produce a new set with items removed, duplicated, or
		/// reordered from the original. If you pass zero indices, then an empty font set is returned.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfonts(uint32const_uint32_idwritefontset1)
		// HRESULT GetFilteredFonts( UINT32 const *indices, UINT32 indexCount, [out] IDWriteFontSet1 **filteredFontSet );
		new IDWriteFontSet1 GetFilteredFonts([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] indices, uint indexCount);

		/// <summary>Retrieves a subset of fonts filtered by the given ranges, endpoint-inclusive.</summary>
		/// <param name="fontAxisRanges">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_RANGE</c> const *</b></para>
		/// <para>List of axis value ranges to filter by.</para>
		/// </param>
		/// <param name="fontAxisRangeCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axis value ranges to filter.</para>
		/// </param>
		/// <param name="selectAnyRange">
		/// Type: <b><c>BOOL</c></b>
		/// <para>
		/// <see langword="true"/> if <b>GetFilteredFonts</b> should select any range; <c>false</c> if it should select the intersection of
		/// them all.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to an
		/// object representing the subset of fonts that fall within the ranges, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If no fonts match the filter, then the returned subset object will be empty (calling <c>IDWriteFontSet::GetFontCount</c> on it
		/// returns 0), but the function does not return an error. The subset is always equal to or less than the original set.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfonts(dwrite_font_axis_rangeconst_uint32_bool_idwritefontset1)
		// HRESULT GetFilteredFonts( DWRITE_FONT_AXIS_RANGE const *fontAxisRanges, UINT32 fontAxisRangeCount, BOOL selectAnyRange, [out]
		// IDWriteFontSet1 **filteredFontSet );
		new IDWriteFontSet1 GetFilteredFonts([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges, uint fontAxisRangeCount, bool selectAnyRange);

		/// <summary>Retrieves a subset of fonts filtered by the given properties.</summary>
		/// <param name="properties">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY</c> const *</b></para>
		/// <para>List of properties to filter by.</para>
		/// </param>
		/// <param name="propertyCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of properties to filter.</para>
		/// </param>
		/// <param name="selectAnyProperty">
		/// Type: <b><c>BOOL</c></b>
		/// <para>
		/// <see langword="true"/> if <b>GetFilteredFonts</b> should select any property; <c>false</c> if it should select the intersection
		/// of them all.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to an
		/// object representing the subset of fonts that match the properties, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If no fonts match the filter, then the returned subset object will be empty (calling <c>IDWriteFontSet::GetFontCount</c> on it
		/// returns 0), but the function does not return an error. The subset is always equal to or less than the original set.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfonts(dwrite_font_propertyconst_uint32_bool_idwritefontset1)
		// HRESULT GetFilteredFonts( DWRITE_FONT_PROPERTY const *properties, UINT32 propertyCount, BOOL selectAnyProperty, [out]
		// IDWriteFontSet1 **filteredFontSet );
		new IDWriteFontSet1 GetFilteredFonts([In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_PROPERTY[]? properties, [Optional] uint propertyCount, bool selectAnyProperty = false);

		/// <summary>Retrieves all the item indices, filtered by the given ranges.</summary>
		/// <param name="fontAxisRanges">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_RANGE</c> const *</b></para>
		/// <para>List of axis value ranges to filter by.</para>
		/// </param>
		/// <param name="fontAxisRangeCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axis value ranges to filter.</para>
		/// </param>
		/// <param name="selectAnyRange">
		/// Type: <b><c>BOOL</c></b>
		/// <para>
		/// <see langword="true"/> if <b>GetFilteredFontIndices</b> should select any range; <c>false</c> if it should select the
		/// intersection of them all.
		/// </para>
		/// </param>
		/// <param name="indices">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>An ascending array of indices, in the range 0 to <c>IDwriteFontSet::GetFontCount</c> minus 1.</para>
		/// </param>
		/// <param name="maxIndexCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of indices.</para>
		/// </param>
		/// <param name="actualIndexCount">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>The actual number of indices written or needed, in the range 0 to <c>IDwriteFontSet::GetFontCount</c> minus 1.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfontindices(dwrite_font_axis_rangeconst_uint32_bool_uint32_uint32_uint32)
		// HRESULT GetFilteredFontIndices( DWRITE_FONT_AXIS_RANGE const *fontAxisRanges, UINT32 fontAxisRangeCount, BOOL selectAnyRange,
		// [out] UINT32 *indices, UINT32 maxIndexCount, [out] UINT32 *actualIndexCount );
		new void GetFilteredFontIndices([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges, uint fontAxisRangeCount,
			bool selectAnyRange, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[] indices, uint maxIndexCount,
			out uint actualIndexCount);

		/// <summary>Get all the item indices filtered by the given properties.</summary>
		/// <param name="properties">List of properties to filter using.</param>
		/// <param name="propertyCount">How many properties to filter.</param>
		/// <param name="selectAnyProperty">Select any property rather rather than the intersection of them all.</param>
		/// <param name="indices">Ascending array of indices [0..GetFontCount() - 1].</param>
		/// <param name="maxIndexCount">Number of indices.</param>
		/// <param name="actualIndexCount">Actual number of indices written or needed [0..GetFontCount()-1].</param>
		/// <remarks>The actualIndexCount will always be &lt;= IDwriteFontSet::GetFontCount.</remarks>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfontindices(dwrite_font_propertyconst_uint32_bool_uint32_uint32_uint32)
		// HRESULT GetFilteredFontIndices( DWRITE_FONT_PROPERTY const *properties, UINT32 propertyCount, BOOL selectAnyProperty, UINT32
		// *indices, UINT32 maxIndexCount, UINT32 *actualIndexCount );
		new void GetFilteredFontIndices([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_PROPERTY[] properties, uint propertyCount,
			bool selectAnyProperty, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[] indices, uint maxIndexCount,
			out uint actualIndexCount);

		/// <summary>Retrieves the axis ranges of a single item.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font in the set.</para>
		/// </param>
		/// <param name="fontAxisRanges">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_RANGE</c>*</b></para>
		/// <para>List of axis value ranges to retrieve.</para>
		/// </param>
		/// <param name="maxFontAxisRangeCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axis value ranges to retrieve.</para>
		/// </param>
		/// <param name="actualFontAxisRangeCount">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>The actual number of axis ranges written or needed.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfontaxisranges(uint32_dwrite_font_axis_range_uint32_uint32)
		// HRESULT GetFontAxisRanges( UINT32 listIndex, [out] DWRITE_FONT_AXIS_RANGE *fontAxisRanges, UINT32 maxFontAxisRangeCount, [out]
		// UINT32 *actualFontAxisRangeCount );
		new void GetFontAxisRanges(uint listIndex, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges,
			uint maxFontAxisRangeCount, out uint actualFontAxisRangeCount);

		/// <summary>Gets all axis ranges in the font set, the union of all contained items.</summary>
		/// <param name="fontAxisRanges">List of axis ranges.</param>
		/// <param name="maxFontAxisRangeCount">Number of axis ranges.</param>
		/// <param name="actualFontAxisRangeCount">Actual number of axis ranges written or needed.</param>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontset1-getfontaxisranges(dwrite_font_axis_range_uint32_uint32)
		// HRESULT GetFontAxisRanges( DWRITE_FONT_AXIS_RANGE *fontAxisRanges, UINT32 maxFontAxisRangeCount, UINT32 *actualFontAxisRangeCount );
		new void GetFontAxisRanges([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges,
			uint maxFontAxisRangeCount, out uint actualFontAxisRangeCount);

		/// <summary>Retrieves the font face reference of a single item.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font item in the set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontFaceReference1</c> interface. On successful completion, the function sets the
		/// pointer to the font face reference.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfontfacereference HRESULT
		// GetFontFaceReference( UINT32 listIndex, IDWriteFontFaceReference1 **fontFaceReference );
		new IDWriteFontFaceReference1 GetFontFaceReference1(uint listIndex);

		/// <summary>Creates the font resource of a single item.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font item in the set.</para>
		/// </param>
		/// <param name="fontResource">
		/// <para>Type: <b><c>IDWriteFontResource</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontResource</c> interface. On successful completion, the function sets the pointer to
		/// a newly created font resource object.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DWRITE_E_REMOTEFONT</description>
		/// <description>The file is not local.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-createfontresource HRESULT
		// CreateFontResource( UINT32 listIndex, [out] IDWriteFontResource **fontResource );
		[PreserveSig]
		new HRESULT CreateFontResource(uint listIndex, out IDWriteFontResource fontResource);

		/// <summary>Creates a font face for a single item (rather than going through the font face reference).</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font item in the set.</para>
		/// </param>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace5</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontFace5</c> interface. On successful completion, the function sets the pointer to a
		/// newly created font face object.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DWRITE_E_REMOTEFONT</description>
		/// <description>The font is not local.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-createfontface HRESULT CreateFontFace(
		// UINT32 listIndex, [out] IDWriteFontFace5 **fontFace );
		[PreserveSig]
		new HRESULT CreateFontFace(uint listIndex, out IDWriteFontFace5 fontFace);

		/// <summary>Retrieves the locality of a single item.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font item in the set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_LOCALITY</c></b></para>
		/// <para>A value indicating the locality.</para>
		/// </returns>
		/// <remarks>
		/// The locality enumeration. For fully local files, the result will always be <b>DWRITE_LOCALITY_LOCAL</b>. For downloadable files,
		/// the result depends on how much of the file has been downloaded.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfontlocality DWRITE_LOCALITY
		// GetFontLocality( UINT32 listIndex );
		[PreserveSig]
		new DWRITE_LOCALITY GetFontLocality(uint listIndex);

		/// <summary>
		/// Retrieves the expiration event for the font set, if any. The expiration event is set on a system font set object if it is out of
		/// date due to fonts being installed, uninstalled, or updated. You should handle the event by getting a new system font set.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>HANDLE</c></b></para>
		/// <para>An event handle, if called on the system font set, or <c>nullptr</c> if called on a custom font set.</para>
		/// </returns>
		/// <remarks>
		/// You mustn't call <b>CloseHandle</b> on the returned event handle. The handle is owned by the font set object, and it remains
		/// valid as long as you hold a reference to the font set. You can wait on the returned event, or use
		/// <c>RegisterWaitForSingleObject</c> to request a callback when the event is set.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset2-getexpirationevent HANDLE GetExpirationEvent();
		[PreserveSig]
		new HEVENT GetExpirationEvent();

		/// <summary>Retrieves the font source type of the specified font.</summary>
		/// <param name="fontIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_SOURCE_TYPE</c></b></para>
		/// <para>The font source type of the specified font.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset3-getfontsourcetype
		// DWRITE_FONT_SOURCE_TYPE GetFontSourceType( UINT32 fontIndex );
		[PreserveSig]
		DWRITE_FONT_SOURCE_TYPE GetFontSourceType(uint fontIndex);

		/// <summary>Retrieves the length of the font source name for the specified font.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The length of the font source name for the specified font.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset3-getfontsourcenamelength UINT32
		// GetFontSourceNameLength( UINT32 listIndex );
		[PreserveSig]
		uint GetFontSourceNameLength(uint listIndex);

		/// <summary>Copies the font source name (for the specified font) into an output array.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font.</para>
		/// </param>
		/// <param name="stringBuffer">
		/// <para>Type: <b><c>WCHAR</c>*</b></para>
		/// <para>Character array that receives the string. Call <c>GetFontSourceNameLength</c> to determine the size of array to allocate.</para>
		/// </param>
		/// <param name="stringBufferSize">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Size of the array in characters. The size must include space for the terminating null character.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset3-getfontsourcename HRESULT
		// GetFontSourceName( UINT32 listIndex, [out] WCHAR *stringBuffer, UINT32 stringBufferSize );
		void GetFontSourceName(uint listIndex, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder stringBuffer, uint stringBufferSize);
	}

	/// <summary>
	/// <para>Represents a font set.</para>
	/// <para>This interface extends <c>IDWriteFontSet3</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontset4
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontSet4")]
	[ComImport, Guid("EEC175FC-BEA9-4C86-8B53-CCBDD7DF0C82"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontSet4 : IDWriteFontSet, IDWriteFontSet1, IDWriteFontSet2, IDWriteFontSet3
	{
		/// <summary>Get the number of total fonts in the set.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the number of total fonts in the set.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getfontcount UINT32 GetFontCount();
		[PreserveSig]
		new uint GetFontCount();

		/// <summary>Gets a reference to the font at the specified index, which may be local or remote.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>**</b></para>
		/// <para>Receives a pointer the font face reference object, or nullptr on failure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getfontfacereference HRESULT
		// GetFontFaceReference( UINT32 listIndex, [out] IDWriteFontFaceReference **fontFaceReference );
		new IDWriteFontFaceReference GetFontFaceReference(uint listIndex);

		/// <summary>Gets the index of the matching font face reference in the font set, with the same file, face index, and simulations.</summary>
		/// <param name="fontFaceReference">
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>*</b></para>
		/// <para>Font face object that specifies the physical font.</para>
		/// </param>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives the zero-based index of the matching font if the font was found, or UINT_MAX otherwise.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if the font exists or FALSE otherwise.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-findfontfacereference HRESULT
		// FindFontFaceReference( IDWriteFontFaceReference *fontFaceReference, [out] UINT32 *listIndex, [out] BOOL *exists );
		new void FindFontFaceReference([In] IDWriteFontFaceReference fontFaceReference, out uint listIndex, out bool exists);

		/// <summary>Gets the index of the matching font face reference in the font set, with the same file, face index, and simulations.</summary>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>Font face object that specifies the physical font.</para>
		/// </param>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives the zero-based index of the matching font if the font was found, or UINT_MAX otherwise.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if the font exists or FALSE otherwise.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-findfontface HRESULT FindFontFace(
		// IDWriteFontFace *fontFace, [out] UINT32 *listIndex, [out] BOOL *exists );
		new void FindFontFace(IDWriteFontFace fontFace, out uint listIndex, out bool exists);

		/// <summary>Returns the property values of a specific font item index.</summary>
		/// <param name="propertyID">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY_ID</c></b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>Receives a pointer to the newly created localized strings object, or nullptr on failure or non-existent property.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyvalues(dwrite_font_property_id_idwritestringlist)
		// HRESULT GetPropertyValues( DWRITE_FONT_PROPERTY_ID propertyID, [out] IDWriteStringList **values );
		new IDWriteStringList? GetPropertyValues(DWRITE_FONT_PROPERTY_ID propertyID);

		/// <summary>
		/// Returns all unique property values in the set, which can be used for purposes such as displaying a family list or tag cloud.
		/// Values are returned in priority order according to the language list, such that if a font contains more than one localized name,
		/// then the preferred one is returned.
		/// </summary>
		/// <param name="propertyID">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY_ID</c></b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <param name="preferredLocaleNames">
		/// <para>Type: <b><c>WCHAR</c> const *</b></para>
		/// <para>
		/// The preferred locale names to query as a list of semicolon-delimited names in preferred order. When a particular string (such as
		/// font family) has more than one localized name, then the first match is returned. If the first match doesn't exist, then the
		/// second match is returned, and so on. For example, "ja-jp;en-us".
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>Receives a pointer to the newly created localized strings object; or <c>nullptr</c> on failure or non-existent property.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyvalues(dwrite_font_property_id_wcharconst_idwritestringlist)
		// HRESULT GetPropertyValues( DWRITE_FONT_PROPERTY_ID propertyID, WCHAR const *preferredLocaleNames, IDWriteStringList **values );
		new IDWriteStringList? GetPropertyValues(DWRITE_FONT_PROPERTY_ID propertyID, [MarshalAs(UnmanagedType.LPWStr)] string preferredLocaleNames);

		/// <summary>Returns the property values of a specific font item index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the font.</para>
		/// </param>
		/// <param name="propertyId">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY_ID</c></b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: [out] <b>BOOL*</b></para>
		/// <para>Receives the value TRUE if the font contains the specified property identifier or FALSE if not.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteLocalizedStrings</c>**</b></para>
		/// <para>Receives a pointer to the newly created localized strings object, or nullptr on failure or non-existent property.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyvalues(uint32_dwrite_font_property_id_bool_idwritelocalizedstrings)
		// HRESULT GetPropertyValues( UINT32 listIndex, DWRITE_FONT_PROPERTY_ID propertyId, BOOL *exists, IDWriteLocalizedStrings **values );
		new IDWriteStringList? GetPropertyValues(uint listIndex, DWRITE_FONT_PROPERTY_ID propertyId, out bool exists);

		/// <summary>Returns how many times a given property value occurs in the set.</summary>
		/// <param name="property">
		/// <para>Type: <b>const <c>DWRITE_FONT_PROPERTY</c>*</b></para>
		/// <para>Font property of interest.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives how many times the property occurs.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getpropertyoccurrencecount HRESULT
		// GetPropertyOccurrenceCount( [in] DWRITE_FONT_PROPERTY const *property, [out] UINT32 *propertyOccurrenceCount );
		new uint GetPropertyOccurrenceCount(in DWRITE_FONT_PROPERTY property);

		/// <summary>Returns a subset of fonts filtered by the given properties.</summary>
		/// <param name="familyName">The font family name.</param>
		/// <param name="fontWeight">The font weight.</param>
		/// <param name="fontStretch">The font stretch value.</param>
		/// <param name="fontStyle">The font style.</param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>The subset of fonts that match the properties, or nullptr on failure.</para>
		/// </returns>
		/// <remarks>
		/// If no fonts matched the filter, the subset will be empty (GetFontCount returns 0), but the function does not return an error.
		/// The subset will always be equal to or less than the original set. If you only want to filter out remote fonts, you may pass null
		/// in properties and zero in propertyCount.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getmatchingfonts(wcharconst_dwrite_font_weight_dwrite_font_stretch_dwrite_font_style_idwritefontset)
		// HRESULT GetMatchingFonts( WCHAR const *familyName, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STRETCH fontStretch,
		// DWRITE_FONT_STYLE fontStyle, IDWriteFontSet **filteredSet );
		new IDWriteFontSet GetMatchingFonts([MarshalAs(UnmanagedType.LPWStr)] string familyName, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STRETCH fontStretch,
			DWRITE_FONT_STYLE fontStyle);

		/// <summary>Returns a subset of fonts filtered by the given properties.</summary>
		/// <param name="properties">
		/// <para>Type: [in] <b>const <c>DWRITE_FONT_PROPERTY</c>*</b></para>
		/// <para>List of properties to filter using.</para>
		/// </param>
		/// <param name="propertyCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of properties to filter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>The subset of fonts that match the properties, or nullptr on failure.</para>
		/// </returns>
		/// <remarks>
		/// If no fonts matched the filter, the subset will be empty (GetFontCount returns 0), but the function does not return an error.
		/// The subset will always be equal to or less than the original set. If you only want to filter out remote fonts, you may pass null
		/// in properties and zero in propertyCount.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset-getmatchingfonts(dwrite_font_propertyconst_uint32_idwritefontset)
		// HRESULT GetMatchingFonts( DWRITE_FONT_PROPERTY const *properties, UINT32 propertyCount, IDWriteFontSet **filteredSet );
		new IDWriteFontSet GetMatchingFonts([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_PROPERTY[] properties, uint propertyCount);

		/// <summary>Retrieves a matching font set based on the requested inputs, ordered so that nearer matches are earlier.</summary>
		/// <param name="fontProperty">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY</c> const *</b></para>
		/// <para>Font property of interest, such as typographic family or weight/stretch/style family.</para>
		/// </param>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c> const *</b></para>
		/// <para>
		/// A pointer to an array containing a list of font axis values. The array should be the size (the number of elements) indicated by
		/// the fontAxisValueCount argument.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of font axis values contained in the fontAxisValues array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to a
		/// prioritized list of fonts that match the properties, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This method can yield distinct items that were not in the original font set, including items with simulation flags (if they
		/// would be a closer match to the request), and instances that were not named by the font author. Items from the same font
		/// resources are collapsed into one: the closest possible match.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getmatchingfonts HRESULT
		// GetMatchingFonts( DWRITE_FONT_PROPERTY const *fontProperty, DWRITE_FONT_AXIS_VALUE const *fontAxisValues, UINT32
		// fontAxisValueCount, IDWriteFontSet1 **matchingFonts );
		new IDWriteFontSet1 GetMatchingFonts([In, Optional] ManagedStructPointer<DWRITE_FONT_PROPERTY> fontProperty,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);

		/// <summary>Retrieves a new font set that contains only the first occurrence of each font resource from the set.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to a
		/// new font set object consisting of single default instances from font resources, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfirstfontresources HRESULT
		// GetFirstFontResources( [out] IDWriteFontSet1 **filteredFontSet );
		new IDWriteFontSet1 GetFirstFontResources();

		/// <summary>Retrieves a subset of fonts, filtered by the given indices.</summary>
		/// <param name="indices">
		/// <para>Type: <b><c>UINT32</c> const *</b></para>
		/// <para>An array of indices to filter by, in the range 0 to <c>IDwriteFontSet::GetFontCount</c> minus 1.</para>
		/// </param>
		/// <param name="indexCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of indices.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to an
		/// object representing the subset of fonts indicated by the given indices, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The indices can come in any order, meaning that <b>GetFilteredFonts</b> can produce a new set with items removed, duplicated, or
		/// reordered from the original. If you pass zero indices, then an empty font set is returned.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfonts(uint32const_uint32_idwritefontset1)
		// HRESULT GetFilteredFonts( UINT32 const *indices, UINT32 indexCount, [out] IDWriteFontSet1 **filteredFontSet );
		new IDWriteFontSet1 GetFilteredFonts([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] indices, uint indexCount);

		/// <summary>Retrieves a subset of fonts filtered by the given ranges, endpoint-inclusive.</summary>
		/// <param name="fontAxisRanges">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_RANGE</c> const *</b></para>
		/// <para>List of axis value ranges to filter by.</para>
		/// </param>
		/// <param name="fontAxisRangeCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axis value ranges to filter.</para>
		/// </param>
		/// <param name="selectAnyRange">
		/// Type: <b><c>BOOL</c></b>
		/// <para>
		/// <see langword="true"/> if <b>GetFilteredFonts</b> should select any range; <c>false</c> if it should select the intersection of
		/// them all.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to an
		/// object representing the subset of fonts that fall within the ranges, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If no fonts match the filter, then the returned subset object will be empty (calling <c>IDWriteFontSet::GetFontCount</c> on it
		/// returns 0), but the function does not return an error. The subset is always equal to or less than the original set.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfonts(dwrite_font_axis_rangeconst_uint32_bool_idwritefontset1)
		// HRESULT GetFilteredFonts( DWRITE_FONT_AXIS_RANGE const *fontAxisRanges, UINT32 fontAxisRangeCount, BOOL selectAnyRange, [out]
		// IDWriteFontSet1 **filteredFontSet );
		new IDWriteFontSet1 GetFilteredFonts([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges, uint fontAxisRangeCount, bool selectAnyRange);

		/// <summary>Retrieves a subset of fonts filtered by the given properties.</summary>
		/// <param name="properties">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY</c> const *</b></para>
		/// <para>List of properties to filter by.</para>
		/// </param>
		/// <param name="propertyCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of properties to filter.</para>
		/// </param>
		/// <param name="selectAnyProperty">
		/// Type: <b><c>BOOL</c></b>
		/// <para>
		/// <see langword="true"/> if <b>GetFilteredFonts</b> should select any property; <c>false</c> if it should select the intersection
		/// of them all.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontSet1</c> interface. On successful completion, the function sets the pointer to an
		/// object representing the subset of fonts that match the properties, otherwise it sets the pointer to <c>nullptr</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If no fonts match the filter, then the returned subset object will be empty (calling <c>IDWriteFontSet::GetFontCount</c> on it
		/// returns 0), but the function does not return an error. The subset is always equal to or less than the original set.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfonts(dwrite_font_propertyconst_uint32_bool_idwritefontset1)
		// HRESULT GetFilteredFonts( DWRITE_FONT_PROPERTY const *properties, UINT32 propertyCount, BOOL selectAnyProperty, [out]
		// IDWriteFontSet1 **filteredFontSet );
		new IDWriteFontSet1 GetFilteredFonts([In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_PROPERTY[]? properties, [Optional] uint propertyCount, bool selectAnyProperty = false);

		/// <summary>Retrieves all the item indices, filtered by the given ranges.</summary>
		/// <param name="fontAxisRanges">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_RANGE</c> const *</b></para>
		/// <para>List of axis value ranges to filter by.</para>
		/// </param>
		/// <param name="fontAxisRangeCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axis value ranges to filter.</para>
		/// </param>
		/// <param name="selectAnyRange">
		/// Type: <b><c>BOOL</c></b>
		/// <para>
		/// <see langword="true"/> if <b>GetFilteredFontIndices</b> should select any range; <c>false</c> if it should select the
		/// intersection of them all.
		/// </para>
		/// </param>
		/// <param name="indices">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>An ascending array of indices, in the range 0 to <c>IDwriteFontSet::GetFontCount</c> minus 1.</para>
		/// </param>
		/// <param name="maxIndexCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of indices.</para>
		/// </param>
		/// <param name="actualIndexCount">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>The actual number of indices written or needed, in the range 0 to <c>IDwriteFontSet::GetFontCount</c> minus 1.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfontindices(dwrite_font_axis_rangeconst_uint32_bool_uint32_uint32_uint32)
		// HRESULT GetFilteredFontIndices( DWRITE_FONT_AXIS_RANGE const *fontAxisRanges, UINT32 fontAxisRangeCount, BOOL selectAnyRange,
		// [out] UINT32 *indices, UINT32 maxIndexCount, [out] UINT32 *actualIndexCount );
		new void GetFilteredFontIndices([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges, uint fontAxisRangeCount,
			bool selectAnyRange, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[] indices, uint maxIndexCount,
			out uint actualIndexCount);

		/// <summary>Get all the item indices filtered by the given properties.</summary>
		/// <param name="properties">List of properties to filter using.</param>
		/// <param name="propertyCount">How many properties to filter.</param>
		/// <param name="selectAnyProperty">Select any property rather rather than the intersection of them all.</param>
		/// <param name="indices">Ascending array of indices [0..GetFontCount() - 1].</param>
		/// <param name="maxIndexCount">Number of indices.</param>
		/// <param name="actualIndexCount">Actual number of indices written or needed [0..GetFontCount()-1].</param>
		/// <remarks>The actualIndexCount will always be &lt;= IDwriteFontSet::GetFontCount.</remarks>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontset1-getfilteredfontindices(dwrite_font_propertyconst_uint32_bool_uint32_uint32_uint32)
		// HRESULT GetFilteredFontIndices( DWRITE_FONT_PROPERTY const *properties, UINT32 propertyCount, BOOL selectAnyProperty, UINT32
		// *indices, UINT32 maxIndexCount, UINT32 *actualIndexCount );
		new void GetFilteredFontIndices([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_PROPERTY[] properties, uint propertyCount,
			bool selectAnyProperty, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[] indices, uint maxIndexCount,
			out uint actualIndexCount);

		/// <summary>Retrieves the axis ranges of a single item.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font in the set.</para>
		/// </param>
		/// <param name="fontAxisRanges">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_RANGE</c>*</b></para>
		/// <para>List of axis value ranges to retrieve.</para>
		/// </param>
		/// <param name="maxFontAxisRangeCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axis value ranges to retrieve.</para>
		/// </param>
		/// <param name="actualFontAxisRangeCount">
		/// <para>Type: <b><c>UINT32</c>*</b></para>
		/// <para>The actual number of axis ranges written or needed.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfontaxisranges(uint32_dwrite_font_axis_range_uint32_uint32)
		// HRESULT GetFontAxisRanges( UINT32 listIndex, [out] DWRITE_FONT_AXIS_RANGE *fontAxisRanges, UINT32 maxFontAxisRangeCount, [out]
		// UINT32 *actualFontAxisRangeCount );
		new void GetFontAxisRanges(uint listIndex, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges,
			uint maxFontAxisRangeCount, out uint actualFontAxisRangeCount);

		/// <summary>Gets all axis ranges in the font set, the union of all contained items.</summary>
		/// <param name="fontAxisRanges">List of axis ranges.</param>
		/// <param name="maxFontAxisRangeCount">Number of axis ranges.</param>
		/// <param name="actualFontAxisRangeCount">Actual number of axis ranges written or needed.</param>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritefontset1-getfontaxisranges(dwrite_font_axis_range_uint32_uint32)
		// HRESULT GetFontAxisRanges( DWRITE_FONT_AXIS_RANGE *fontAxisRanges, UINT32 maxFontAxisRangeCount, UINT32 *actualFontAxisRangeCount );
		new void GetFontAxisRanges([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges,
			uint maxFontAxisRangeCount, out uint actualFontAxisRangeCount);

		/// <summary>Retrieves the font face reference of a single item.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font item in the set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFaceReference1</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontFaceReference1</c> interface. On successful completion, the function sets the
		/// pointer to the font face reference.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfontfacereference HRESULT
		// GetFontFaceReference( UINT32 listIndex, IDWriteFontFaceReference1 **fontFaceReference );
		new IDWriteFontFaceReference1 GetFontFaceReference1(uint listIndex);

		/// <summary>Creates the font resource of a single item.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font item in the set.</para>
		/// </param>
		/// <param name="fontResource">
		/// <para>Type: <b><c>IDWriteFontResource</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontResource</c> interface. On successful completion, the function sets the pointer to
		/// a newly created font resource object.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DWRITE_E_REMOTEFONT</description>
		/// <description>The file is not local.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-createfontresource HRESULT
		// CreateFontResource( UINT32 listIndex, [out] IDWriteFontResource **fontResource );
		[PreserveSig]
		new HRESULT CreateFontResource(uint listIndex, out IDWriteFontResource fontResource);

		/// <summary>Creates a font face for a single item (rather than going through the font face reference).</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font item in the set.</para>
		/// </param>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace5</c>**</b></para>
		/// <para>
		/// The address of a pointer to an <c>IDWriteFontFace5</c> interface. On successful completion, the function sets the pointer to a
		/// newly created font face object.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DWRITE_E_REMOTEFONT</description>
		/// <description>The font is not local.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-createfontface HRESULT CreateFontFace(
		// UINT32 listIndex, [out] IDWriteFontFace5 **fontFace );
		[PreserveSig]
		new HRESULT CreateFontFace(uint listIndex, out IDWriteFontFace5 fontFace);

		/// <summary>Retrieves the locality of a single item.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font item in the set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_LOCALITY</c></b></para>
		/// <para>A value indicating the locality.</para>
		/// </returns>
		/// <remarks>
		/// The locality enumeration. For fully local files, the result will always be <b>DWRITE_LOCALITY_LOCAL</b>. For downloadable files,
		/// the result depends on how much of the file has been downloaded.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset1-getfontlocality DWRITE_LOCALITY
		// GetFontLocality( UINT32 listIndex );
		[PreserveSig]
		new DWRITE_LOCALITY GetFontLocality(uint listIndex);

		/// <summary>
		/// Retrieves the expiration event for the font set, if any. The expiration event is set on a system font set object if it is out of
		/// date due to fonts being installed, uninstalled, or updated. You should handle the event by getting a new system font set.
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>HANDLE</c></b></para>
		/// <para>An event handle, if called on the system font set, or <c>nullptr</c> if called on a custom font set.</para>
		/// </returns>
		/// <remarks>
		/// You mustn't call <b>CloseHandle</b> on the returned event handle. The handle is owned by the font set object, and it remains
		/// valid as long as you hold a reference to the font set. You can wait on the returned event, or use
		/// <c>RegisterWaitForSingleObject</c> to request a callback when the event is set.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset2-getexpirationevent HANDLE GetExpirationEvent();
		[PreserveSig]
		new HEVENT GetExpirationEvent();

		/// <summary>Retrieves the font source type of the specified font.</summary>
		/// <param name="fontIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_SOURCE_TYPE</c></b></para>
		/// <para>The font source type of the specified font.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset3-getfontsourcetype
		// DWRITE_FONT_SOURCE_TYPE GetFontSourceType( UINT32 fontIndex );
		[PreserveSig]
		new DWRITE_FONT_SOURCE_TYPE GetFontSourceType(uint fontIndex);

		/// <summary>Retrieves the length of the font source name for the specified font.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The length of the font source name for the specified font.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset3-getfontsourcenamelength UINT32
		// GetFontSourceNameLength( UINT32 listIndex );
		[PreserveSig]
		new uint GetFontSourceNameLength(uint listIndex);

		/// <summary>Copies the font source name (for the specified font) into an output array.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Zero-based index of the font.</para>
		/// </param>
		/// <param name="stringBuffer">
		/// <para>Type: <b><c>WCHAR</c>*</b></para>
		/// <para>Character array that receives the string. Call <c>GetFontSourceNameLength</c> to determine the size of array to allocate.</para>
		/// </param>
		/// <param name="stringBufferSize">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Size of the array in characters. The size must include space for the terminating null character.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset3-getfontsourcename HRESULT
		// GetFontSourceName( UINT32 listIndex, [out] WCHAR *stringBuffer, UINT32 stringBufferSize );
		new void GetFontSourceName(uint listIndex, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder stringBuffer, uint stringBufferSize);

		/// <summary>Computes derived font axis values from the specified font weight, stretch, style, and size.</summary>
		/// <param name="inputAxisValues">
		/// <para>Type: _In_reads_opt_(inputAxisCount) <b><c>DWRITE_FONT_AXIS_VALUE</c> const*</b></para>
		/// <para>
		/// Optional pointer to an array of input axis values. Axes present in this array are excluded from the output. That's so that
		/// explicit axis values take precedence over derived axis values.
		/// </para>
		/// </param>
		/// <param name="inputAxisCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Size of the array of input axis values.</para>
		/// </param>
		/// <param name="fontWeight">
		/// <para>Type: <b><c>DWRITE_FONT_WEIGHT</c></b></para>
		/// <para>Font weight, used to compute "wght" axis value.</para>
		/// </param>
		/// <param name="fontStretch">
		/// <para>Type: <b><c>DWRITE_FONT_STRETCH</c></b></para>
		/// <para>Font stretch, used to compute "wdth" axis value.</para>
		/// </param>
		/// <param name="fontStyle">
		/// <para>Type: <b><c>DWRITE_FONT_STYLE</c></b></para>
		/// <para>Font style, used to compute "slnt" and "ital" axis values.</para>
		/// </param>
		/// <param name="fontSize">
		/// <para>Type: <b>float</b></para>
		/// <para>
		/// Font size in DIPs, used to compute "opsz" axis value. If this parameter is zero, then no "opsz" axis value is added to the
		/// output array.
		/// </para>
		/// </param>
		/// <param name="outputAxisValues">
		/// <para>Type: _Out_writes_to_( <see cref="DWRITE_STANDARD_FONT_AXIS_COUNT"/>, return) <b><c>DWRITE_FONT_AXIS_VALUE</c>*</b></para>
		/// <para>
		/// Pointer to an output array to which derived axis values are written. The size of this array must be at least
		/// <b>DWRITE_STANDARD_FONT_AXIS_COUNT</b> (5). The return value is the number of axis values that were actually written to this array.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Returns the number of derived axis values that were actually written to the output array.</para>
		/// </returns>
		/// <remarks>
		/// The caller should concatenate the output axis values to the input axis values (if any), and pass the combined axis values to the
		/// <b>GetMatchingFonts</b> method. This doesn't result in duplicates because the output doesn't include any axes present in the
		/// inputAxisValues array.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset4-convertweightstretchstyletofontaxisvalues
		// UINT32 ConvertWeightStretchStyleToFontAxisValues( DWRITE_FONT_AXIS_VALUE const *inputAxisValues, UINT32 inputAxisCount,
		// DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STRETCH fontStretch, DWRITE_FONT_STYLE fontStyle, float fontSize,
		// DWRITE_FONT_AXIS_VALUE *outputAxisValues );
		[PreserveSig]
		uint ConvertWeightStretchStyleToFontAxisValues([In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_VALUE[]? inputAxisValues,
			[Optional] uint inputAxisCount, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STRETCH fontStretch, DWRITE_FONT_STYLE fontStyle,
			float fontSize, [Out, MarshalAs(UnmanagedType.LPArray)] DWRITE_FONT_AXIS_VALUE[] outputAxisValues);

		/// <summary>Generates a matching font set based on the requested inputs, ordered so that nearer matches are earlier.</summary>
		/// <param name="familyName">
		/// <para>Type: _In_z_ <b><c>WCHAR</c> const*</b></para>
		/// <para>
		/// Font family name. This can be: a typographic family name, weight/stretch/style family name, GDI (RBIZ) family name, or full name.
		/// </para>
		/// </param>
		/// <param name="fontAxisValues">
		/// <para>Type: _In_reads_(fontAxisValueCount) <b><c>DWRITE_FONT_AXIS_VALUE</c> const*</b></para>
		/// <para>Array of font axis values.</para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Number of font axis values.</para>
		/// </param>
		/// <param name="allowedSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>
		/// Specifies which simulations (that is, algorithmic emboldening and/or slant) may be applied to matching fonts to better match the
		/// specified axis values. If the argument is <b>DWRITE_FONT_SIMULATIONS_NONE</b> (0), then no simulations are applied.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: _COM_Outptr_ <b><c>IDWriteFontSet4</c>**</b></para>
		/// <para>Receives a pointer to a newly-created font set, which contains a prioritized list of fonts that match the specified inputs.</para>
		/// </returns>
		/// <remarks>
		/// This can yield distinct items that were not in the original font set, including items with simulation flags (if they would be a
		/// closer match to the request) and instances that were not named by the font author. Items from the same font resources are
		/// collapsed into one: the closest possible match.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontset4-getmatchingfonts HRESULT
		// GetMatchingFonts( WCHAR const *familyName, DWRITE_FONT_AXIS_VALUE const *fontAxisValues, UINT32 fontAxisValueCount,
		// DWRITE_FONT_SIMULATIONS allowedSimulations, IDWriteFontSet4 **matchingFonts );
		IDWriteFontSet4 GetMatchingFonts([MarshalAs(UnmanagedType.LPWStr)] string familyName,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount,
			DWRITE_FONT_SIMULATIONS allowedSimulations);
	}

	/// <summary>Contains methods for building a font set.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontsetbuilder
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontSetBuilder")]
	[ComImport, Guid("2F642AFE-9C68-4F40-B8BE-457401AFCB3D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontSetBuilder
	{
		/// <summary>
		/// Adds a reference to a font to the set being built. The necessary metadata will automatically be extracted from the font upon
		/// calling CreateFontSet.
		/// </summary>
		/// <param name="fontFaceReference">
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>*</b></para>
		/// <para>Font face reference object to add to the set.</para>
		/// </param>
		/// <param name="properties">List of properties to associate with the reference.</param>
		/// <param name="propertyCount">The number of properties specified.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontsetbuilder-addfontfacereference(idwritefontfacereference_dwrite_font_propertyconst_uint32)
		// HRESULT AddFontFaceReference( [in] IDWriteFontFaceReference *fontFaceReference, DWRITE_FONT_PROPERTY const *properties, UINT32
		// propertyCount );
		void AddFontFaceReference([In] IDWriteFontFaceReference fontFaceReference,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FONT_PROPERTY[] properties, uint propertyCount);

		/// <summary>
		/// Adds a reference to a font to the set being built. The necessary metadata will automatically be extracted from the font upon
		/// calling CreateFontSet.
		/// </summary>
		/// <param name="fontFaceReference">
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>*</b></para>
		/// <para>Font face reference object to add to the set.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontsetbuilder-addfontfacereference(idwritefontfacereference)
		// HRESULT AddFontFaceReference( [in] IDWriteFontFaceReference *fontFaceReference );
		void AddFontFaceReference([In] IDWriteFontFaceReference fontFaceReference);

		/// <summary>
		/// Appends an existing font set to the one being built, allowing one to aggregate two sets or to essentially extend an existing one.
		/// </summary>
		/// <param name="fontSet">
		/// <para>Type: <b><c>IDWriteFontSet</c>*</b></para>
		/// <para>Font set to append font face references from.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontsetbuilder-addfontset HRESULT AddFontSet(
		// [in] IDWriteFontSet *fontSet );
		void AddFontSet([In] IDWriteFontSet fontSet);

		/// <summary>Creates a font set from all the font face references added so far with AddFontFaceReference.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>Contains the newly created font set object, or nullptr in case of failure.</para>
		/// </returns>
		/// <remarks>
		/// Creating a font set takes less time if the references were added with metadata rather than needing to extract the metadata from
		/// the font file.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontsetbuilder-createfontset HRESULT
		// CreateFontSet( [out] IDWriteFontSet **fontSet );
		IDWriteFontSet CreateFontSet();
	}

	/// <summary>Contains methods for building a font set.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontsetbuilder1
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontSetBuilder1")]
	[ComImport, Guid("3FF7715F-3CDC-4DC6-9B72-EC5621DCCAFD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontSetBuilder1 : IDWriteFontSetBuilder
	{
		/// <summary>
		/// Adds a reference to a font to the set being built. The necessary metadata will automatically be extracted from the font upon
		/// calling CreateFontSet.
		/// </summary>
		/// <param name="fontFaceReference">
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>*</b></para>
		/// <para>Font face reference object to add to the set.</para>
		/// </param>
		/// <param name="properties">List of properties to associate with the reference.</param>
		/// <param name="propertyCount">The number of properties specified.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontsetbuilder-addfontfacereference(idwritefontfacereference_dwrite_font_propertyconst_uint32)
		// HRESULT AddFontFaceReference( [in] IDWriteFontFaceReference *fontFaceReference, DWRITE_FONT_PROPERTY const *properties, UINT32
		// propertyCount );
		new void AddFontFaceReference([In] IDWriteFontFaceReference fontFaceReference,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FONT_PROPERTY[] properties, uint propertyCount);

		/// <summary>
		/// Adds a reference to a font to the set being built. The necessary metadata will automatically be extracted from the font upon
		/// calling CreateFontSet.
		/// </summary>
		/// <param name="fontFaceReference">
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>*</b></para>
		/// <para>Font face reference object to add to the set.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontsetbuilder-addfontfacereference(idwritefontfacereference)
		// HRESULT AddFontFaceReference( [in] IDWriteFontFaceReference *fontFaceReference );
		new void AddFontFaceReference([In] IDWriteFontFaceReference fontFaceReference);

		/// <summary>
		/// Appends an existing font set to the one being built, allowing one to aggregate two sets or to essentially extend an existing one.
		/// </summary>
		/// <param name="fontSet">
		/// <para>Type: <b><c>IDWriteFontSet</c>*</b></para>
		/// <para>Font set to append font face references from.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontsetbuilder-addfontset HRESULT AddFontSet(
		// [in] IDWriteFontSet *fontSet );
		new void AddFontSet([In] IDWriteFontSet fontSet);

		/// <summary>Creates a font set from all the font face references added so far with AddFontFaceReference.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>Contains the newly created font set object, or nullptr in case of failure.</para>
		/// </returns>
		/// <remarks>
		/// Creating a font set takes less time if the references were added with metadata rather than needing to extract the metadata from
		/// the font file.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontsetbuilder-createfontset HRESULT
		// CreateFontSet( [out] IDWriteFontSet **fontSet );
		new IDWriteFontSet CreateFontSet();

		/// <summary>
		/// Adds references to all the fonts in the specified font file. The method parses the font file to determine the fonts and their properties.
		/// </summary>
		/// <param name="fontFile">
		/// <para>Type: <b>IDWriteFontFile*</b></para>
		/// <para>
		/// Font file reference object to add to the set. If the file is not a supported OpenType font file, then a DWRITE_E_FILEFORMAT
		/// error will be returned.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontsetbuilder1-addfontfile HRESULT AddFontFile(
		// [in] IDWriteFontFile *fontFile );
		void AddFontFile(IDWriteFontFile fontFile);
	}

	/// <summary>
	/// <para>Contains methods for building a font set.</para>
	/// <para>This interface extends <c>IDWriteFontSetBuilder1</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritefontsetbuilder2
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteFontSetBuilder2")]
	[ComImport, Guid("EE5BA612-B131-463C-8F4F-3189B9401E45"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontSetBuilder2 : IDWriteFontSetBuilder, IDWriteFontSetBuilder1
	{
		/// <summary>
		/// Adds a reference to a font to the set being built. The necessary metadata will automatically be extracted from the font upon
		/// calling CreateFontSet.
		/// </summary>
		/// <param name="fontFaceReference">
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>*</b></para>
		/// <para>Font face reference object to add to the set.</para>
		/// </param>
		/// <param name="properties">List of properties to associate with the reference.</param>
		/// <param name="propertyCount">The number of properties specified.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontsetbuilder-addfontfacereference(idwritefontfacereference_dwrite_font_propertyconst_uint32)
		// HRESULT AddFontFaceReference( [in] IDWriteFontFaceReference *fontFaceReference, DWRITE_FONT_PROPERTY const *properties, UINT32
		// propertyCount );
		new void AddFontFaceReference([In] IDWriteFontFaceReference fontFaceReference,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FONT_PROPERTY[] properties, uint propertyCount);

		/// <summary>
		/// Adds a reference to a font to the set being built. The necessary metadata will automatically be extracted from the font upon
		/// calling CreateFontSet.
		/// </summary>
		/// <param name="fontFaceReference">
		/// <para>Type: <b><c>IDWriteFontFaceReference</c>*</b></para>
		/// <para>Font face reference object to add to the set.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontsetbuilder-addfontfacereference(idwritefontfacereference)
		// HRESULT AddFontFaceReference( [in] IDWriteFontFaceReference *fontFaceReference );
		new void AddFontFaceReference([In] IDWriteFontFaceReference fontFaceReference);

		/// <summary>
		/// Appends an existing font set to the one being built, allowing one to aggregate two sets or to essentially extend an existing one.
		/// </summary>
		/// <param name="fontSet">
		/// <para>Type: <b><c>IDWriteFontSet</c>*</b></para>
		/// <para>Font set to append font face references from.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontsetbuilder-addfontset HRESULT AddFontSet(
		// [in] IDWriteFontSet *fontSet );
		new void AddFontSet([In] IDWriteFontSet fontSet);

		/// <summary>Creates a font set from all the font face references added so far with AddFontFaceReference.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>Contains the newly created font set object, or nullptr in case of failure.</para>
		/// </returns>
		/// <remarks>
		/// Creating a font set takes less time if the references were added with metadata rather than needing to extract the metadata from
		/// the font file.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontsetbuilder-createfontset HRESULT
		// CreateFontSet( [out] IDWriteFontSet **fontSet );
		new IDWriteFontSet CreateFontSet();

		/// <summary>
		/// Adds references to all the fonts in the specified font file. The method parses the font file to determine the fonts and their properties.
		/// </summary>
		/// <param name="fontFile">
		/// <para>Type: <b>IDWriteFontFile*</b></para>
		/// <para>
		/// Font file reference object to add to the set. If the file is not a supported OpenType font file, then a DWRITE_E_FILEFORMAT
		/// error will be returned.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontsetbuilder1-addfontfile HRESULT AddFontFile(
		// [in] IDWriteFontFile *fontFile );
		new void AddFontFile([In] IDWriteFontFile fontFile);

		/// <summary>
		/// Adds a font to the set being built, with the caller supplying enough information to search on and determine axis ranges,
		/// avoiding the need to open the potentially non-local font.
		/// </summary>
		/// <param name="fontFile">
		/// <para>Type: <b><c>IDWriteFontFile</c>*</b></para>
		/// <para>Font file reference object to add to the set.</para>
		/// </param>
		/// <param name="fontFaceIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The zero-based index of a font face in a collection.</para>
		/// </param>
		/// <param name="fontSimulations">
		/// <para>Type: <b><c>DWRITE_FONT_SIMULATIONS</c></b></para>
		/// <para>Font face simulation flags for algorithmic emboldening and italicization.</para>
		/// </param>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c> const *</b></para>
		/// <para>
		/// A pointer to an array containing a list of font axis values. The array should be the size (the number of elements) indicated by
		/// the fontAxisValueCount argument.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of font axis values contained in the fontAxisValues array.</para>
		/// </param>
		/// <param name="fontAxisRanges">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_RANGE</c> const *</b></para>
		/// <para>List of axis ranges.</para>
		/// </param>
		/// <param name="fontAxisRangeCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Number of axis ranges.</para>
		/// </param>
		/// <param name="properties">
		/// <para>Type: <b><c>DWRITE_FONT_PROPERTY</c> const *</b></para>
		/// <para>List of properties to associate with the reference.</para>
		/// </param>
		/// <param name="propertyCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of properties defined.</para>
		/// </param>
		/// <remarks>
		/// The font properties should include at least a family (typographic or weight/style/stretch). Otherwise the font would be
		/// accessible in the <b>IDWriteFontSet</b> only by index, not name.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontsetbuilder2-addfont HRESULT AddFont(
		// IDWriteFontFile *fontFile, UINT32 fontFaceIndex, DWRITE_FONT_SIMULATIONS fontSimulations, DWRITE_FONT_AXIS_VALUE const
		// *fontAxisValues, UINT32 fontAxisValueCount, DWRITE_FONT_AXIS_RANGE const *fontAxisRanges, UINT32 fontAxisRangeCount,
		// DWRITE_FONT_PROPERTY const *properties, UINT32 propertyCount );
		void AddFont([In] IDWriteFontFile fontFile, uint fontFaceIndex, DWRITE_FONT_SIMULATIONS fontSimulations,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] DWRITE_FONT_AXIS_RANGE[] fontAxisRanges, uint fontAxisRangeCount,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 8)] DWRITE_FONT_PROPERTY[] properties, uint propertyCount);

		/// <summary>
		/// Adds references to all the fonts in the specified font file. The method parses the font file to determine the fonts and their properties.
		/// </summary>
		/// <param name="filePath">
		/// <para>Type: <b><c>WCHAR</c> const *</b></para>
		/// <para>Absolute file path to add to the font set.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritefontsetbuilder2-addfontfile HRESULT AddFontFile(
		// WCHAR const *filePath );
		void AddFontFile([MarshalAs(UnmanagedType.LPWStr)] string filePath);
	}

	/// <summary>
	/// Provides interoperability with GDI, such as methods to convert a font face to a LOGFONT structure, or to convert a GDI font
	/// description into a font face. It is also used to create bitmap render target objects.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritegdiinterop1
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteGdiInterop1")]
	[ComImport, Guid("4556BE70-3ABD-4F70-90BE-421780A6F515"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteGdiInterop1 : IDWriteGdiInterop
	{
		/// <summary>Creates a font object that matches the properties specified by the <c>LOGFONT</c> structure.</summary>
		/// <param name="logFont">
		/// <para>Type: <c>const LOGFONTW*</c></para>
		/// <para>A structure containing a GDI-compatible font description.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFont**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to a newly created IDWriteFont object if successful; otherwise, <c>NULL</c>.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritegdiinterop-createfontfromlogfont HRESULT
		// CreateFontFromLOGFONT( LOGFONTW const *logFont, IDWriteFont **font );
		new IDWriteFont CreateFontFromLOGFONT(in LOGFONT logFont);

		/// <summary>Initializes a <c>LOGFONT</c> structure based on the GDI-compatible properties of the specified font.</summary>
		/// <param name="font">
		/// <para>Type: <c>IDWriteFont*</c></para>
		/// <para>An IDWriteFont object to be converted into a GDI-compatible <c>LOGFONT</c> structure.</para>
		/// </param>
		/// <param name="logFont">
		/// <para>Type: <c>LOGFONTW*</c></para>
		/// <para>When this method returns, contains a structure that receives a GDI-compatible font description.</para>
		/// </param>
		/// <param name="isSystemFont">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// When this method returns, contains <c>TRUE</c> if the specified font object is part of the system font collection; otherwise, <c>FALSE</c>.
		/// </para>
		/// </param>
		/// <remarks>
		/// The conversion to a <c>LOGFONT</c> by using <c>ConvertFontToLOGFONT</c> operates at the logical font level and does not
		/// guarantee that it will map to a specific physical font. It is not guaranteed that GDI will select the same physical font for
		/// displaying text formatted by a <c>LOGFONT</c> as the IDWriteFont object that was converted.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritegdiinterop-convertfonttologfont HRESULT
		// ConvertFontToLOGFONT( IDWriteFont *font, LOGFONTW *logFont, BOOL *isSystemFont );
		new void ConvertFontToLOGFONT([In] IDWriteFont font, out LOGFONT logFont, [MarshalAs(UnmanagedType.Bool)] out bool isSystemFont);

		/// <summary>Initializes a LOGFONT structure based on the GDI-compatible properties of the specified font.</summary>
		/// <param name="font">
		/// <para>Type: <c>IDWriteFontFace*</c></para>
		/// <para>An IDWriteFontFace object to be converted into a GDI-compatible LOGFONT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LOGFONTW*</c></para>
		/// <para>When this method returns, contains a pointer to a structure that receives a GDI-compatible font description.</para>
		/// </returns>
		/// <remarks>
		/// The conversion to a LOGFONT by using <c>ConvertFontFaceToLOGFONT</c> operates at the logical font level and does not guarantee
		/// that it will map to a specific physical font. It is not guaranteed that GDI will select the same physical font for displaying
		/// text formatted by a LOGFONT as the IDWriteFont object that was converted.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritegdiinterop-convertfontfacetologfont HRESULT
		// ConvertFontFaceToLOGFONT( IDWriteFontFace *font, LOGFONTW *logFont );
		new LOGFONT ConvertFontFaceToLOGFONT([In] IDWriteFontFace font);

		/// <summary>
		/// Creates an <c>IDWriteFontFace</c> object that corresponds to the currently selected <c>HFONT</c> of the specified <c>HDC</c>.
		/// </summary>
		/// <param name="hdc">
		/// <para>Type: <c>HDC</c></para>
		/// <para>
		/// A handle to a device context into which a font has been selected. It is assumed that the client has already performed font
		/// mapping and that the font selected into the device context is the actual font to be used for rendering glyphs.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFace**</c></para>
		/// <para>
		/// Contains an address of a pointer to the newly created font face object, or <c>NULL</c> in case of failure. The font face
		/// returned is guaranteed to reference the same physical typeface that would be used for drawing glyphs (but not necessarily
		/// characters) using ExtTextOut.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This function is intended for scenarios in which an application wants to use GDI and Uniscribe 1.x for text layout and shaping,
		/// but DirectWrite for final rendering. This function assumes the client is performing text output using glyph indexes.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritegdiinterop-createfontfacefromhdc HRESULT
		// CreateFontFaceFromHdc( HDC hdc, IDWriteFontFace **fontFace );
		new IDWriteFontFace CreateFontFaceFromHdc(HDC hdc);

		/// <summary>Creates an object that encapsulates a bitmap and memory DC (device context) which can be used for rendering glyphs.</summary>
		/// <param name="hdc">
		/// <para>Type: <c>HDC</c></para>
		/// <para>A handle to the optional device context used to create a compatible memory DC (device context).</para>
		/// </param>
		/// <param name="width">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The width of the bitmap render target.</para>
		/// </param>
		/// <param name="height">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The height of the bitmap render target.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteBitmapRenderTarget**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created IDWriteBitmapRenderTarget object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritegdiinterop-createbitmaprendertarget HRESULT
		// CreateBitmapRenderTarget( HDC hdc, UINT32 width, UINT32 height, IDWriteBitmapRenderTarget **renderTarget );
		new IDWriteBitmapRenderTarget CreateBitmapRenderTarget([In, Optional] HDC hdc, uint width, uint height);

		/// <summary>Creates a font object that matches the properties specified by the LOGFONT structure.</summary>
		/// <param name="logFont">
		/// <para>Type: <b>LOGFONTW</b></para>
		/// <para>Structure containing a GDI-compatible font description.</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection</c>*</b></para>
		/// <para>The font collection to search. If NULL, the local system font collection is used.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFont</c>**</b></para>
		/// <para>Receives a newly created font object if successful, or NULL in case of error.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritegdiinterop1-createfontfromlogfont HRESULT
		// CreateFontFromLOGFONT( [in] LOGFONTW const *logFont, [in, optional] IDWriteFontCollection *fontCollection, [out] IDWriteFont
		// **font );
		IDWriteFont CreateFontFromLOGFONT(in LOGFONT logFont, [In, Optional] IDWriteFontCollection? fontCollection);

		/// <summary>Reads the font signature from the given font.</summary>
		/// <param name="fontFace">
		/// <para>Type: [in] <b><c>IDWriteFont</c>*</b></para>
		/// <para>Font to read font signature from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b>FONTSIGNATURE*</b></para>
		/// <para>Font signature from the OS/2 table, ulUnicodeRange, and ulCodePageRange.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritegdiinterop1-getfontsignature(idwritefontface_fontsignature)
		// HRESULT GetFontSignature( IDWriteFontFace *fontFace, FONTSIGNATURE *fontSignature );
		FONTSIGNATURE GetFontSignature([In] IDWriteFontFace fontFace);

		/// <summary>Reads the font signature from the given font.</summary>
		/// <param name="font">
		/// <para>Type: <b><c>IDWriteFont</c>*</b></para>
		/// <para>Font to read font signature from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <b>FONTSIGNATURE*</b></para>
		/// <para>Font signature from the OS/2 table, ulUnicodeRange, and ulCodePageRange.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritegdiinterop1-getfontsignature(idwritefont_fontsignature)
		// HRESULT GetFontSignature( IDWriteFont *font, FONTSIGNATURE *fontSignature );
		FONTSIGNATURE GetFontSignature([In] IDWriteFont font);

		/// <summary>Gets a list of matching fonts based on the specified LOGFONT values. Only fonts of that family name will be returned.</summary>
		/// <param name="logFont">
		/// <para>Type: <b>LOGFONT</b></para>
		/// <para>Structure containing a GDI-compatible font description.</para>
		/// </param>
		/// <param name="fontSet">
		/// <para>Type: <b><c>IDWriteFontSet</c>*</b></para>
		/// <para>The font set to search.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontSet</c>**</b></para>
		/// <para>Receives the filtered font set if successful.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritegdiinterop1-getmatchingfontsbylogfont HRESULT
		// GetMatchingFontsByLOGFONT( [in] LOGFONT const *logFont, [in] IDWriteFontSet *fontSet, [out] IDWriteFontSet **filteredSet );
		IDWriteFontSet GetMatchingFontsByLOGFONT(in LOGFONT logFont, [In] IDWriteFontSet fontSet);
	}

	/// <summary>
	/// Represents a font file loader that can access in-memory fonts. The <c>IDWriteFactory5::CreateInMemoryFontFileLoader</c> method
	/// returns an instance of this interface, which the client can use to load in-memory fonts without having to implement a custom loader.
	/// A client can also create its own custom implementation, however. In either case, the client is responsible for registering and
	/// unregistering the loader using <c>IDWriteFactory::RegisterFontFileLoader</c> and <c>IDWriteFactory::UnregisterFontFileLoader</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwriteinmemoryfontfileloader
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteInMemoryFontFileLoader")]
	[ComImport, Guid("DC102F47-A12D-4B1C-822D-9E117E33043F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteInMemoryFontFileLoader : IDWriteFontFileLoader
	{
		/// <summary>Creates a font file stream object that encapsulates an open file resource.</summary>
		/// <param name="fontFileReferenceKey">
		/// <para>Type: <b>const void*</b></para>
		/// <para>
		/// A pointer to a font file reference key that uniquely identifies the font file resource within the scope of the font loader being
		/// used. The buffer allocated for this key must at least be the size, in bytes, specified by <i>fontFileReferenceKeySize</i>.
		/// </para>
		/// </param>
		/// <param name="fontFileReferenceKeySize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The size of font file reference key, in bytes.</para>
		/// </param>
		/// <param name="fontFileStream">
		/// <para>Type: <b><c>IDWriteFontFileStream</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created <c>IDWriteFontFileStream</c> object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		/// <remarks>The resource is closed when the last reference to <i>fontFileStream</i> is released.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfileloader-createstreamfromkey HRESULT
		// CreateStreamFromKey( [in] void const *fontFileReferenceKey, UINT32 fontFileReferenceKeySize, [out] IDWriteFontFileStream
		// **fontFileStream );
		[PreserveSig]
		new HRESULT CreateStreamFromKey([In] IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize, out IDWriteFontFileStream? fontFileStream);

		/// <summary>
		/// Creates a font file reference ( <c>IDWriteFontFile</c> object) from an array of bytes. The font file reference is bound to the
		/// <c>IDWriteInMemoryFontFileLoader</c> instance with which it was created and remains valid for as long as that loader is
		/// registered with the factory.
		/// </summary>
		/// <param name="factory">
		/// <para>Type: <b><c>IDWriteFactory</c>*</b></para>
		/// <para>Factory object used to create the font file reference.</para>
		/// </param>
		/// <param name="fontData">
		/// <para>Type: <b>void const*</b></para>
		/// <para>Pointer to a memory block containing the font data.</para>
		/// </param>
		/// <param name="fontDataSize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Size of the font data.</para>
		/// </param>
		/// <param name="ownerObject">
		/// <para>Type: <b><c>IUnknown</c>*</b></para>
		/// <para>
		/// Optional object that owns the memory specified by the fontData parameter. If this parameter is not NULL, the method stores a
		/// pointer to the font data and adds a reference to the owner object. The fontData pointer must remain valid until the owner object
		/// is released. If this parameter is NULL, the method makes a copy of the font data.
		/// </para>
		/// </param>
		/// <param name="fontFile">
		/// <para>Type: <b><c>IDWriteFontFile</c>**</b></para>
		/// <para>Receives a pointer to the newly-created font file reference.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwriteinmemoryfontfileloader-createinmemoryfontfilereference
		// HRESULT CreateInMemoryFontFileReference( IDWriteFactory *factory, [in] void const *fontData, UINT32 fontDataSize, [in, optional]
		// IUnknown *ownerObject, [out] IDWriteFontFile **fontFile );
		[PreserveSig]
		HRESULT CreateInMemoryFontFileReference(IDWriteFactory factory, [In] IntPtr fontData, uint fontDataSize,
			[In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? ownerObject, out IDWriteFontFile fontFile);

		/// <summary>Returns the number of font file references that have been created using this loader instance.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the number of font file references that have been created using this loader instance.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwriteinmemoryfontfileloader-getfilecount UINT32 GetFileCount();
		[PreserveSig]
		uint GetFileCount();
	}

	/// <summary>
	/// Interface used to read color glyph data for a specific font. A color glyph is represented as a visual tree of paint elements.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nn-dwrite_3-idwritepaintreader
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWritePaintReader")]
	[ComImport, Guid("8128E912-3B97-42A5-AB6C-24AAD3A86E54"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWritePaintReader
	{
		/// <summary>Sets the current glyph, and positions the reader on the root paint element of the selected glyph's visual tree.</summary>
		/// <param name="glyphIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Glyph index to get the color glyph representation for.</para>
		/// </param>
		/// <param name="paintElement">
		/// <para>Type: _Out_writes_bytes_(structSize) <b><c>DWRITE_PAINT_ELEMENT</c> *</b></para>
		/// <para>Receives information about the root paint element of the glyph's visual tree.</para>
		/// </param>
		/// <param name="structSize">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Size of the <c>DWRITE_PAINT_ELEMENT</c> structure, in bytes.</para>
		/// </param>
		/// <param name="clipBox">
		/// <para>Type: _Out_ <b><c>D2D_RECT_F</c> *</b></para>
		/// <para>
		/// Receives a precomputed glyph box (in ems) for the specified glyph, if one is specified by the font. Otherwise, the glyph box is
		/// set to an empty rectangle (all zeros). If a non-empty clip box is specified, then you must clip the color glyph's representation
		/// to the specified box.
		/// </para>
		/// </param>
		/// <param name="glyphAttributes">
		/// <para>Type: _Out_opt_ <b><c>DWRITE_PAINT_ATTRIBUTES</c> * = nullptr</b></para>
		/// <para>Receives optional paint attributes for the glyph.</para>
		/// </param>
		/// <remarks>
		/// If the specified glyph index isn't a color glyph, then the method succeeds, but the paintType member of the
		/// <c>DWRITE_PAINT_ELEMENT</c> structure is set to <b>DWRITE_PAINT_TYPE_NONE</b>. In that case, you should draw the input glyph as
		/// a non-color glyph.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritepaintreader-setcurrentglyph(uint32_dwrite_paint_element_uint32_d2d_rect_f_dwrite_paint_attributes)
		// HRESULT SetCurrentGlyph( UINT32 glyphIndex, DWRITE_PAINT_ELEMENT *paintElement, UINT32 structSize, D2D_RECT_F *clipBox,
		// DWRITE_PAINT_ATTRIBUTES *glyphAttributes );
		void SetCurrentGlyph(uint glyphIndex, out DWRITE_PAINT_ELEMENT paintElement, uint structSize, out D2D_RECT_F clipBox,
			out DWRITE_PAINT_ATTRIBUTES glyphAttributes);

		/// <summary>
		/// Sets the client-defined text color. The default value is transparent black. Changing the text color can affect the appearance of
		/// a glyph if its definition uses the current text color. If that's the case, then the <c>SetCurrentGlyph</c> method returns the
		/// <b>DWRITE_PAINT_ATTRIBUTES_USES_TEXT_COLOR</b> flag via the glyphAttributes output parameter.
		/// </summary>
		/// <param name="textColor">
		/// <para>Type: _In_reads_(paletteEntryCount) <b><c>DWRITE_COLOR_F</c> const &amp;</b></para>
		/// <para>Specifies the text color.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritepaintreader-settextcolor HRESULT
		// SetTextColor( DWRITE_COLOR_F const &amp; textColor );
		void SetTextColor(in DWRITE_COLOR_F textColor);

		/// <summary>
		/// Sets the current color palette index. The default value is zero. Changing the palette index can affect the appearance of a glyph
		/// if its definition references colors in the color palette. If that's the case, then the <c>SetCurrentGlyph</c> method returns the
		/// <b>DWRITE_PAINT_ATTRIBUTES_USES_PALETTE</b> flag via the glyphAttributes output parameter.
		/// </summary>
		/// <param name="colorPaletteIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Specifies the color palette index.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritepaintreader-setcolorpaletteindex
		// HRESULT SetColorPaletteIndex( UINT32 colorPaletteIndex );
		void SetColorPaletteIndex(uint colorPaletteIndex);

		/// <summary>
		/// Sets a custom color palette with client-defined palette entries, instead of using a font-defined color palette. Changing the
		/// color palette can affect the appearance of a glyph if its definition references colors in the color palette. If that's the case,
		/// then the <c>SetCurrentGlyph</c> method returns the <b>DWRITE_PAINT_ATTRIBUTES_USES_PALETTE</b> flag via the glyphAttributes
		/// output parameter.
		/// </summary>
		/// <param name="paletteEntries">
		/// <para>Type: _In_reads_(paletteEntryCount) <b><c>DWRITE_COLOR_F</c> const *</b></para>
		/// <para>Array of palette entries for the client-defined color palette.</para>
		/// </param>
		/// <param name="paletteEntryCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Size of the paletteEntries array. This must equal the font's palette entry count as returned by <c>IDWriteFontFace2::GetPaletteEntryCount</c>.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritepaintreader-setcustomcolorpalette
		// HRESULT SetCustomColorPalette( DWRITE_COLOR_F const *paletteEntries, UINT32 paletteEntryCount );
		void SetCustomColorPalette([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_COLOR_F[] paletteEntries, uint paletteEntryCount);

		/// <summary>
		/// Sets the current position in the visual tree to the first child of the current paint element, and returns the newly-selected
		/// element's properties via the paintElement output parameter.
		/// </summary>
		/// <param name="paintElement">
		/// <para>Type: _Out_writes_bytes_(structSize) <b><c>DWRITE_PAINT_ELEMENT</c> *</b></para>
		/// <para>Receives the properties of the newly-selected element.</para>
		/// </param>
		/// <param name="structSize">
		/// <para>Type: <b><c>UINT32</c> = sizeof(DWRITE_PAINT_ELEMENT)</b></para>
		/// <para>Size of the <c>DWRITE_PAINT_ELEMENT</c> structure, in bytes.</para>
		/// </param>
		/// <remarks>
		/// You can determine (a priori from its paint type and properties) whether a paint element has children, and how many. For more
		/// info, see <c>DWRITE_PAINT_ELEMENT</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritepaintreader-movetofirstchild
		// HRESULT MoveToFirstChild( DWRITE_PAINT_ELEMENT *paintElement, UINT32 structSize );
		void MoveToFirstChild(out DWRITE_PAINT_ELEMENT paintElement, uint structSize);

		/// <summary>
		/// Sets the current position in the visual tree to the next sibling of the current paint element, and returns the newly-selected
		/// element's properties via the paintElement output parameter.
		/// </summary>
		/// <param name="paintElement">
		/// <para>Type: _Out_writes_bytes_(structSize) <b><c>DWRITE_PAINT_ELEMENT</c> *</b></para>
		/// <para>Receives the properties of the newly-selected element.</para>
		/// </param>
		/// <param name="structSize">
		/// <para>Type: <b><c>UINT32</c> = sizeof(DWRITE_PAINT_ELEMENT)</b></para>
		/// <para>Size of the <c>DWRITE_PAINT_ELEMENT</c> structure, in bytes.</para>
		/// </param>
		/// <remarks>
		/// You can determine (a priori from its paint type and properties) whether a paint element has children, and how many. For more
		/// info, see <c>DWRITE_PAINT_ELEMENT</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritepaintreader-movetonextsibling
		// HRESULT MoveToNextSibling( DWRITE_PAINT_ELEMENT *paintElement, UINT32 structSize );
		void MoveToNextSibling(out DWRITE_PAINT_ELEMENT paintElement, uint structSize);

		/// <summary>Sets the current position in the visual tree to the parent of the current paint element.</summary>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritepaintreader-movetoparent HRESULT MoveToParent();
		void MoveToParent();

		/// <summary>Retrieves the gradient stops of the current paint element.</summary>
		/// <param name="firstGradientStopIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Index of the first gradient stop to retrieve.</para>
		/// </param>
		/// <param name="gradientStopCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Number of gradient stops to retrieve.</para>
		/// </param>
		/// <param name="gradientStops">
		/// <para>Type: _Out_writes_(gradientStopCount) <b><c>D2D1_GRADIENT_STOP</c> *</b></para>
		/// <para>Receives the gradient stops.</para>
		/// </param>
		/// <returns>A standard <b>HRESULT</b> error code.</returns>
		/// <remarks>Gradient stops are guaranteed to be in ascending order by position.</remarks>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritepaintreader-getgradientstops
		// HRESULT GetGradientStops( UINT32 firstGradientStopIndex, UINT32 gradientStopCount, D2D1_GRADIENT_STOP *gradientStops );
		void GetGradientStops(uint firstGradientStopIndex, uint gradientStopCount, [Out] IntPtr gradientStops);

		/// <summary>Retrieves color information about each gradient stop, such as palette indices.</summary>
		/// <param name="firstGradientStopIndex">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Index of the first gradient stop to get.</para>
		/// </param>
		/// <param name="gradientStopCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>Number of gradient stops to get.</para>
		/// </param>
		/// <param name="gradientStopColors">
		/// <para>Type: _Out_writes_(gradientStopCount) <b><c>DWRITE_PAINT_COLOR</c> *</b></para>
		/// <para>Receives the gradient stop colors.</para>
		/// </param>
		/// <returns>A standard <b>HRESULT</b> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritepaintreader-getgradientstopcolors
		// HRESULT GetGradientStopColors( UINT32 firstGradientStopIndex, UINT32 gradientStopCount, DWRITE_PAINT_COLOR *gradientStopColors );
		void GetGradientStopColors(uint firstGradientStopIndex, uint gradientStopCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_PAINT_COLOR[] gradientStopColors);
	}

	/// <summary>
	/// Represents a font file loader that can access remote (i.e., downloadable) fonts. The
	/// <c>IDWriteFactory5::CreateHttpFontFileLoader</c> method returns an instance of this interface, which the client can use to load
	/// remote fonts without having to implement a custom loader. A client can also create its own custom implementation, however. In either
	/// case, the client is responsible for registering and unregistering the loader using IDWriteFactory:: <c>RegisterFontFileLoader</c>
	/// and IDWriteFactory:: <c>UnregisterFontFileLoader</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwriteremotefontfileloader
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteRemoteFontFileLoader")]
	[ComImport, Guid("68648C83-6EDE-46C0-AB46-20083A887FDE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteRemoteFontFileLoader : IDWriteFontFileLoader
	{
		/// <summary>Creates a font file stream object that encapsulates an open file resource.</summary>
		/// <param name="fontFileReferenceKey">
		/// <para>Type: <b>const void*</b></para>
		/// <para>
		/// A pointer to a font file reference key that uniquely identifies the font file resource within the scope of the font loader being
		/// used. The buffer allocated for this key must at least be the size, in bytes, specified by <i>fontFileReferenceKeySize</i>.
		/// </para>
		/// </param>
		/// <param name="fontFileReferenceKeySize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The size of font file reference key, in bytes.</para>
		/// </param>
		/// <param name="fontFileStream">
		/// <para>Type: <b><c>IDWriteFontFileStream</c>**</b></para>
		/// <para>When this method returns, contains the address of a pointer to the newly created <c>IDWriteFontFileStream</c> object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		/// <remarks>The resource is closed when the last reference to <i>fontFileStream</i> is released.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfileloader-createstreamfromkey HRESULT
		// CreateStreamFromKey( [in] void const *fontFileReferenceKey, UINT32 fontFileReferenceKeySize, [out] IDWriteFontFileStream
		// **fontFileStream );
		[PreserveSig]
		new HRESULT CreateStreamFromKey([In] IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize, out IDWriteFontFileStream? fontFileStream);

		/// <summary>
		/// Creates a remote font file stream object that encapsulates an open file resource and can be used to download remote file data.
		/// </summary>
		/// <param name="fontFileReferenceKey">
		/// <para>Type: <b>void</b></para>
		/// <para>Font file reference key that uniquely identifies the font file resource within the scope of the font loader being used.</para>
		/// </param>
		/// <param name="fontFileReferenceKeySize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Size of font file reference key in bytes.</para>
		/// </param>
		/// <param name="fontFileStream">
		/// <para>Type: <b><c>IDWriteRemoteFontFileStream</c>**</b></para>
		/// <para>Pointer to the newly created font file stream.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		/// <remarks>
		/// Unlike <c>CreateStreamFromKey</c>, this method can be used to create a stream for a remote file. If the file is remote, the
		/// client must call <c>IDWriteRemoteFontFileStream::BeginDownload</c> with an empty array of file fragments before the stream can
		/// be used to get the file size or access data.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwriteremotefontfileloader-createremotestreamfromkey
		// HRESULT CreateRemoteStreamFromKey( [in] void const *fontFileReferenceKey, UINT32 fontFileReferenceKeySize, [out]
		// IDWriteRemoteFontFileStream **fontFileStream );
		[PreserveSig]
		HRESULT CreateRemoteStreamFromKey([In] IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize, out IDWriteRemoteFontFileStream fontFileStream);

		/// <summary>Gets the locality of the file resource identified by the unique key.</summary>
		/// <param name="fontFileReferenceKey">
		/// <para>Type: <b>void</b></para>
		/// <para>Font file reference key that uniquely identifies the font file resource within the scope of the font loader being used.</para>
		/// </param>
		/// <param name="fontFileReferenceKeySize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Size of font file reference key in bytes.</para>
		/// </param>
		/// <param name="locality">
		/// <para>Type: <b><c>DWRITE_LOCALITY</c>*</b></para>
		/// <para>Locality of the file.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwriteremotefontfileloader-getlocalityfromkey HRESULT
		// GetLocalityFromKey( [in] void const *fontFileReferenceKey, UINT32 fontFileReferenceKeySize, [out] DWRITE_LOCALITY *locality );
		[PreserveSig]
		HRESULT GetLocalityFromKey([In] IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize, out DWRITE_LOCALITY locality);

		/// <summary>Creates a font file reference from a URL if the loader supports this capability.</summary>
		/// <param name="factory">
		/// <para>Type: <b><c>IDWriteFactory</c>*</b></para>
		/// <para>Factory used to create the font file reference.</para>
		/// </param>
		/// <param name="baseUrl">
		/// <para>Type: <b>WCHAR</b></para>
		/// <para>
		/// Optional base URL. The base URL is used to resolve the fontFileUrl if it is relative. For example, the baseUrl might be the URL
		/// of the referring document that contained the fontFileUrl.
		/// </para>
		/// </param>
		/// <param name="fontFileUrl">
		/// <para>Type: <b>WCHAR</b></para>
		/// <para>URL of the font resource.</para>
		/// </param>
		/// <param name="fontFile">
		/// <para>Type: <b><c>IDWriteFontFile</c>**</b></para>
		/// <para>Receives a pointer to the newly created font file reference.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		/// <remarks>
		/// If baseUrl is a non-empty string, then baseUrl concatenated with fontFileUrl should form a valid URL, DirectWrite will not
		/// supply any additional delimiter.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwriteremotefontfileloader-createfontfilereferencefromurl
		// HRESULT CreateFontFileReferenceFromUrl( IDWriteFactory *factory, WCHAR const *baseUrl, [in] WCHAR const *fontFileUrl, [out]
		// IDWriteFontFile **fontFile );
		[PreserveSig]
		HRESULT CreateFontFileReferenceFromUrl([In] IDWriteFactory factory, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? baseUrl,
			[MarshalAs(UnmanagedType.LPWStr)] string fontFileUrl, out IDWriteFontFile fontFile);
	}

	/// <summary>
	/// Represents a font file stream, parts of which may be non-local. Non-local data must be downloaded before it can be accessed using
	/// ReadFragment. The interface exposes methods to download font data and query the locality of font data.
	/// </summary>
	/// <remarks>For more information, see the description of IDWriteRemoteFontFileLoader.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwriteremotefontfilestream
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteRemoteFontFileStream")]
	[ComImport, Guid("4DB3757A-2C72-4ED9-B2B6-1ABABE1AFF9C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteRemoteFontFileStream : IDWriteFontFileStream
	{
		/// <summary>Reads a fragment from a font file.</summary>
		/// <param name="fragmentStart">
		/// <para>Type: <c>const void**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the start of the font file fragment. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <param name="fileOffset">
		/// <para>Type: <c>UINT64</c></para>
		/// <para>The offset of the fragment, in bytes, from the beginning of the font file.</para>
		/// </param>
		/// <param name="fragmentSize">
		/// <para>Type: <c>UINT64</c></para>
		/// <para>The size of the file fragment, in bytes.</para>
		/// </param>
		/// <param name="fragmentContext">
		/// <para>Type: <c>void**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to a pointer to the client-defined context to be passed to ReleaseFileFragment.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Note that <c>ReadFileFragment</c> implementations must check whether the requested font file fragment is within the file bounds.
		/// Otherwise, an error should be returned from <c>ReadFileFragment</c>.
		/// </para>
		/// <para>
		/// DirectWrite may invoke IDWriteFontFileStream methods on the same object from multiple threads simultaneously. Therefore,
		/// <c>ReadFileFragment</c> implementations that rely on internal mutable state must serialize access to such state across multiple
		/// threads. For example, an implementation that uses separate Seek and Read operations to read a file fragment must place the code
		/// block containing Seek and Read calls under a lock or a critical section.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfilestream-readfilefragment HRESULT
		// ReadFileFragment( void const **fragmentStart, UINT64 fileOffset, UINT64 fragmentSize, void **fragmentContext );
		new void ReadFileFragment(out IntPtr fragmentStart, ulong fileOffset, ulong fragmentSize, [Out] out IntPtr fragmentContext);

		/// <summary>Releases a fragment from a file.</summary>
		/// <param name="fragmentContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>A pointer to the client-defined context of a font fragment returned from ReadFileFragment.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfilestream-releasefilefragment void
		// ReleaseFileFragment( void *fragmentContext );
		[PreserveSig]
		new void ReleaseFileFragment([In] IntPtr fragmentContext);

		/// <summary>Obtains the total size of a file.</summary>
		/// <param name="fileSize">
		/// <para>Type: <b>UINT64*</b></para>
		/// <para>When this method returns, contains the total size of the file.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		/// <remarks>
		/// Implementing <b>GetFileSize</b>() for asynchronously loaded font files may require downloading the complete file contents.
		/// Therefore, this method should be used only for operations that either require a complete font file to be loaded (for example,
		/// copying a font file) or that need to make decisions based on the value of the file size (for example, validation against a
		/// persisted file size).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfilestream-getfilesize HRESULT GetFileSize( [out]
		// UINT64 *fileSize );
		[PreserveSig]
		new HRESULT GetFileSize(out ulong fileSize);

		/// <summary>Obtains the last modified time of the file.</summary>
		/// <param name="lastWriteTime">
		/// <para>Type: <b>UINT64*</b></para>
		/// <para>
		/// When this method returns, contains the last modified time of the file in the format that represents the number of 100-nanosecond
		/// intervals since January 1, 1601 (UTC).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		/// <remarks>
		/// The "last modified time" is used by DirectWrite font selection algorithms to determine whether one font resource is more up to
		/// date than another one.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontfilestream-getlastwritetime HRESULT
		// GetLastWriteTime( [out] UINT64 *lastWriteTime );
		[PreserveSig]
		new HRESULT GetLastWriteTime(out FILETIME lastWriteTime);

		/// <summary>
		/// GetLocalFileSize returns the number of bytes of the font file that are currently local, which should always be less than or
		/// equal to the full file size returned by <c>GetFileSize</c>. If the locality is remote, the return value is zero. If the file is
		/// fully local, the return value must be the same as <c>GetFileSize</c>.
		/// </summary>
		/// <param name="localFileSize">
		/// <para>Type: <b>UINT64*</b></para>
		/// <para>Receives the local size of the file.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwriteremotefontfilestream-getlocalfilesize HRESULT
		// GetLocalFileSize( [out] UINT64 *localFileSize );
		[PreserveSig]
		HRESULT GetLocalFileSize(out ulong localFileSize);

		/// <summary>Returns information about the locality of a byte range (i.e., font fragment) within the font file stream.</summary>
		/// <param name="fileOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Offset of the fragment from the beginning of the font file.</para>
		/// </param>
		/// <param name="fragmentSize">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Size of the fragment in bytes.</para>
		/// </param>
		/// <param name="isLocal">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Receives TRUE if the first byte of the fragment is local, FALSE if not.</para>
		/// </param>
		/// <param name="partialSize">
		/// <para>Type: <b>UINT64*</b></para>
		/// <para>Receives the number of contiguous bytes from the start of the fragment that have the same locality as the first byte.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwriteremotefontfilestream-getfilefragmentlocality
		// HRESULT GetFileFragmentLocality( UINT64 fileOffset, UINT64 fragmentSize, [out] BOOL *isLocal, UINT64 *partialSize );
		[PreserveSig]
		HRESULT GetFileFragmentLocality(ulong fileOffset, ulong fragmentSize, out bool isLocal, out ulong partialSize);

		/// <summary>Gets the current locality of the file.</summary>
		/// <returns>Returns the locality enumeration (i.e., remote, partial, or local).</returns>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwriteremotefontfilestream-getlocality
		// DWRITE_LOCALITY GetLocality();
		[PreserveSig]
		DWRITE_LOCALITY GetLocality();

		/// <summary>Begins downloading all or part of the font file.</summary>
		/// <param name="downloadOperationID">Type: <b>UUID</b></param>
		/// <param name="fileFragments">
		/// <para>Type: <b><c>DWRITE_FILE_FRAGMENT</c></b></para>
		/// <para>Array of structures, each specifying a byte range to download.</para>
		/// </param>
		/// <param name="fragmentCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Number of elements in the fileFragments array. This can be zero to just download file information, such as the size.</para>
		/// </param>
		/// <param name="asyncResult">
		/// <para>Type: <b>COM_Outptr_result_maybenull</b></para>
		/// <para>
		/// Receives an object that can be used to wait for the asynchronous download to complete and to get the download result upon
		/// completion. The result may be NULL if the download completes synchronously. For example, this can happen if method determines
		/// that the requested data is already local.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwriteremotefontfilestream-begindownload HRESULT
		// BeginDownload( [in] UUID const *downloadOperationID, [in] DWRITE_FILE_FRAGMENT const *fileFragments, UINT32 fragmentCount,
		// IDWriteAsyncResult **asyncResult );
		[PreserveSig]
		HRESULT BeginDownload(in Guid downloadOperationID, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FILE_FRAGMENT[] fileFragments,
			uint fragmentCount, out IDWriteAsyncResult? asyncResult);
	}

	/// <summary>Represents text rendering settings for glyph rasterization and filtering.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwriterenderingparams3
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteRenderingParams3")]
	[ComImport, Guid("B7924BAA-391B-412A-8C5C-E44CC2D867DC"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteRenderingParams3 : IDWriteRenderingParams, IDWriteRenderingParams1, IDWriteRenderingParams2
	{
		/// <summary>Gets the gamma value used for gamma correction. Valid values must be greater than zero and cannot exceed 256.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Returns the gamma value used for gamma correction. Valid values must be greater than zero and cannot exceed 256.</para>
		/// </returns>
		/// <remarks>The gamma value is used for gamma correction, which compensates for the non-linear luminosity response of most monitors.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getgamma FLOAT GetGamma();
		[PreserveSig]
		new float GetGamma();

		/// <summary>
		/// Gets the enhanced contrast property of the rendering parameters object. Valid values are greater than or equal to zero.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Returns the amount of contrast enhancement. Valid values are greater than or equal to zero.</para>
		/// </returns>
		/// <remarks>
		/// Enhanced contrast is the amount to increase the darkness of text, and typically ranges from 0 to 1. Zero means no contrast enhancement.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getenhancedcontrast FLOAT GetEnhancedContrast();
		[PreserveSig]
		new float GetEnhancedContrast();

		/// <summary>Gets the ClearType level of the rendering parameters object.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The ClearType level of the rendering parameters object.</para>
		/// </returns>
		/// <remarks>
		/// The ClearType level represents the amount of ClearType – that is, the degree to which the red, green, and blue subpixels of each
		/// pixel are treated differently. Valid values range from zero (meaning no ClearType, which is equivalent to grayscale
		/// anti-aliasing) to one (meaning full ClearType)
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getcleartypelevel FLOAT GetClearTypeLevel();
		[PreserveSig]
		new float GetClearTypeLevel();

		/// <summary>Gets the pixel geometry of the rendering parameters object.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_PIXEL_GEOMETRY</c></para>
		/// <para>A value that indicates the type of pixel geometry used in the rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getpixelgeometry DWRITE_PIXEL_GEOMETRY GetPixelGeometry();
		[PreserveSig]
		new DWRITE_PIXEL_GEOMETRY GetPixelGeometry();

		/// <summary>Gets the rendering mode of the rendering parameters object.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_RENDERING_MODE</c></para>
		/// <para>A value that indicates the rendering mode of the rendering parameters object.</para>
		/// </returns>
		/// <remarks>
		/// By default, the rendering mode is initialized to DWRITE_RENDERING_MODE_DEFAULT, which means the rendering mode is determined
		/// automatically based on the font and size. To determine the recommended rendering mode to use for a given font and size and
		/// rendering parameters object, use the IDWriteFontFace::GetRecommendedRenderingMode method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getrenderingmode DWRITE_RENDERING_MODE GetRenderingMode();
		[PreserveSig]
		new DWRITE_RENDERING_MODE GetRenderingMode();

		/// <summary>Gets the amount of contrast enhancement to use for grayscale antialiasing.</summary>
		/// <returns>
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The contrast enhancement value. Valid values are greater than or equal to zero.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwriterenderingparams1-getgrayscaleenhancedcontrast
		// FLOAT GetGrayscaleEnhancedContrast();
		[PreserveSig]
		new float GetGrayscaleEnhancedContrast();

		/// <summary>Gets the grid fitting mode.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_GRID_FIT_MODE</c></b></para>
		/// <para>Returns a <c>DWRITE_GRID_FIT_MODE</c>-typed value for the grid fitting mode.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwriterenderingparams2-getgridfitmode
		// DWRITE_GRID_FIT_MODE GetGridFitMode();
		[PreserveSig]
		new DWRITE_GRID_FIT_MODE GetGridFitMode();

		/// <summary>Gets the rendering mode.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE1</c></b></para>
		/// <para>Returns a <c>DWRITE_RENDERING_MODE1</c>-typed value for the rendering mode.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwriterenderingparams3-getrenderingmode1
		// DWRITE_RENDERING_MODE1 GetRenderingMode1();
		[PreserveSig]
		DWRITE_RENDERING_MODE1 GetRenderingMode1();
	}

	/// <summary>
	/// Represents a collection of strings indexed by number.An IDWriteStringList is identical to IDWriteLocalizedStrings except for the
	/// semantics, where localized strings are indexed on language (each language has one string property) whereas IDWriteStringList may
	/// contain multiple strings of the same language, such as a string list of family names from a font set. You can QueryInterface from an
	/// IDWriteLocalizedStrings to an IDWriteStringList.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritestringlist
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteStringList")]
	[ComImport, Guid("CFEE3140-1157-47CA-8B85-31BFCF3F2D0E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteStringList
	{
		/// <summary>Gets the number of strings in the string list.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the number of strings in the string list.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritestringlist-getcount UINT32 GetCount();
		[PreserveSig]
		uint GetCount();

		/// <summary>Gets the length in characters (not including the null terminator) of the locale name with the specified index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the locale name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives the length in characters, not including the null terminator.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritestringlist-getlocalenamelength HRESULT
		// GetLocaleNameLength( UINT32 listIndex, [out] UINT32 *length );
		uint GetLocaleNameLength(uint listIndex);

		/// <summary>Copies the locale name with the specified index to the specified array.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the locale name.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <b>WCHAR*</b></para>
		/// <para>Character array that receives the locale name.</para>
		/// </param>
		/// <param name="size">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Size of the array in characters. The size must include space for the terminating null character.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritestringlist-getlocalename HRESULT GetLocaleName(
		// UINT32 listIndex, [out] WCHAR *localeName, UINT32 size );
		void GetLocaleName(uint listIndex, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder localeName, uint size);

		/// <summary>Gets the length in characters (not including the null terminator) of the string with the specified index.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the string.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Receives the length in characters of the string, not including the null terminator.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritestringlist-getstringlength HRESULT
		// GetStringLength( UINT32 listIndex, [out] UINT32 *length );
		uint GetStringLength(uint listIndex);

		/// <summary>Copies the string with the specified index to the specified array.</summary>
		/// <param name="listIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Zero-based index of the string.</para>
		/// </param>
		/// <param name="stringBuffer">
		/// <para>Type: <b>WCHAR*</b></para>
		/// <para>Character array that receives the string.</para>
		/// </param>
		/// <param name="stringBufferSize">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Size of the array in characters. The size must include space for the terminating null character.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritestringlist-getstring HRESULT GetString( UINT32
		// listIndex, [out] WCHAR *stringBuffer, UINT32 stringBufferSize );
		void GetString(uint listIndex, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder stringBuffer, uint stringBufferSize);
	}

	/// <summary>Describes the font and paragraph properties used to format text, and it describes locale information.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritetextformat2
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteTextFormat2")]
	[ComImport, Guid("F67E0EDD-9E3D-4ECC-8C32-4183253DFE70"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteTextFormat2 : IDWriteTextFormat, IDWriteTextFormat1
	{
		/// <summary>
		/// Sets the alignment of text in a paragraph, relative to the leading and trailing edge of a layout box for a IDWriteTextFormat interface.
		/// </summary>
		/// <param name="textAlignment">
		/// <para>Type: <c>DWRITE_TEXT_ALIGNMENT</c></para>
		/// <para>The text alignment option being set for the paragraph of type DWRITE_TEXT_ALIGNMENT. For more information, see Remarks.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The text can be aligned to the leading or trailing edge of the layout box, or it can be centered. The following illustration
		/// shows text with the alignment set to DWRITE_TEXT_ALIGNMENT_LEADING, <c>DWRITE_TEXT_ALIGNMENT_CENTER</c>, and
		/// <c>DWRITE_TEXT_ALIGNMENT_TRAILING</c>, respectively.
		/// </para>
		/// <para>
		/// <c>Note</c> The alignment is dependent on reading direction, the above is for left-to-right reading direction. For right-to-left
		/// reading direction it would be the opposite.
		/// </para>
		/// <para>See DWRITE_TEXT_ALIGNMENT for more information.</para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settextalignment HRESULT SetTextAlignment(
		// DWRITE_TEXT_ALIGNMENT textAlignment );
		new void SetTextAlignment(DWRITE_TEXT_ALIGNMENT textAlignment);

		/// <summary>Sets the alignment option of a paragraph relative to the layout box's top and bottom edge.</summary>
		/// <param name="paragraphAlignment">
		/// <para>Type: <c>DWRITE_PARAGRAPH_ALIGNMENT</c></para>
		/// <para>The paragraph alignment option being set for a paragraph; see DWRITE_PARAGRAPH_ALIGNMENT for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setparagraphalignment HRESULT
		// SetParagraphAlignment( DWRITE_PARAGRAPH_ALIGNMENT paragraphAlignment );
		new void SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT paragraphAlignment);

		/// <summary>Sets the word wrapping option.</summary>
		/// <param name="wordWrapping">
		/// <para>Type: <c>DWRITE_WORD_WRAPPING</c></para>
		/// <para>The word wrapping option being set for a paragraph; see DWRITE_WORD_WRAPPING for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setwordwrapping HRESULT SetWordWrapping(
		// DWRITE_WORD_WRAPPING wordWrapping );
		new void SetWordWrapping(DWRITE_WORD_WRAPPING wordWrapping);

		/// <summary>Sets the paragraph reading direction.</summary>
		/// <param name="readingDirection">
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>
		/// The text reading direction (for example, DWRITE_READING_DIRECTION_RIGHT_TO_LEFT for languages, such as Arabic, that read from
		/// right to left) for a paragraph.
		/// </para>
		/// </param>
		/// <remarks>
		/// The reading direction and flow direction must always be set 90 degrees orthogonal to each other, or else you will get the error
		/// DWRITE_E_FLOWDIRECTIONCONFLICTS when you use layout functions like Draw or GetMetrics. So if you set a vertical reading
		/// direction (for example, to DWRITE_READING_DIRECTION_TOP_TO_BOTTOM), then you must also use SetFlowDirection to set the flow
		/// direction appropriately (for example, to DWRITE_FLOW_DIRECTION_RIGHT_TO_LEFT).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setreadingdirection HRESULT
		// SetReadingDirection( DWRITE_READING_DIRECTION readingDirection );
		new void SetReadingDirection(DWRITE_READING_DIRECTION readingDirection);

		/// <summary>Sets the paragraph flow direction.</summary>
		/// <param name="flowDirection">
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>The paragraph flow direction; see DWRITE_FLOW_DIRECTION for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setflowdirection HRESULT SetFlowDirection(
		// DWRITE_FLOW_DIRECTION flowDirection );
		new void SetFlowDirection(DWRITE_FLOW_DIRECTION flowDirection);

		/// <summary>Sets a fixed distance between two adjacent tab stops.</summary>
		/// <param name="incrementalTabStop">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The fixed distance between two adjacent tab stops.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setincrementaltabstop HRESULT
		// SetIncrementalTabStop( FLOAT incrementalTabStop );
		new void SetIncrementalTabStop(float incrementalTabStop);

		/// <summary>Sets trimming options for text overflowing the layout width.</summary>
		/// <param name="trimmingOptions">
		/// <para>Type: <c>const DWRITE_TRIMMING*</c></para>
		/// <para>Text trimming options.</para>
		/// </param>
		/// <param name="trimmingSign">
		/// <para>Type: <c>IDWriteInlineObject*</c></para>
		/// <para>Application-defined omission sign. This parameter may be <c>NULL</c>. See IDWriteInlineObject for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settrimming HRESULT SetTrimming(
		// DWRITE_TRIMMING const *trimmingOptions, IDWriteInlineObject *trimmingSign );
		new void SetTrimming(in DWRITE_TRIMMING trimmingOptions, [In, Optional] IDWriteInlineObject? trimmingSign);

		/// <summary>Sets the line spacing.</summary>
		/// <param name="lineSpacingMethod">
		/// <para>Type: <c>DWRITE_LINE_SPACING_METHOD</c></para>
		/// <para>Specifies how line height is being determined; see DWRITE_LINE_SPACING_METHOD for more information.</para>
		/// </param>
		/// <param name="lineSpacing">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The line height, or distance between one baseline to another.</para>
		/// </param>
		/// <param name="baseline">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The distance from top of line to baseline. A reasonable ratio to lineSpacing is 80 percent.</para>
		/// </param>
		/// <remarks>
		/// For the default method, spacing depends solely on the content. For uniform spacing, the specified line height overrides the content.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setlinespacing HRESULT SetLineSpacing(
		// DWRITE_LINE_SPACING_METHOD lineSpacingMethod, FLOAT lineSpacing, FLOAT baseline );
		new void SetLineSpacing(DWRITE_LINE_SPACING_METHOD lineSpacingMethod, float lineSpacing, float baseline);

		/// <summary>Gets the alignment option of text relative to the layout box's leading and trailing edge.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_TEXT_ALIGNMENT</c></para>
		/// <para>Returns the text alignment option of the current paragraph.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-gettextalignment DWRITE_TEXT_ALIGNMENT GetTextAlignment();
		[PreserveSig]
		new DWRITE_TEXT_ALIGNMENT GetTextAlignment();

		/// <summary>Gets the alignment option of a paragraph which is relative to the top and bottom edges of a layout box.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_PARAGRAPH_ALIGNMENT</c></para>
		/// <para>A value that indicates the current paragraph alignment option.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getparagraphalignment
		// DWRITE_PARAGRAPH_ALIGNMENT GetParagraphAlignment();
		[PreserveSig]
		new DWRITE_PARAGRAPH_ALIGNMENT GetParagraphAlignment();

		/// <summary>Gets the word wrapping option.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_WORD_WRAPPING</c></para>
		/// <para>Returns the word wrapping option; see DWRITE_WORD_WRAPPING for more information.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getwordwrapping DWRITE_WORD_WRAPPING GetWordWrapping();
		[PreserveSig]
		new DWRITE_WORD_WRAPPING GetWordWrapping();

		/// <summary>Gets the current reading direction for text in a paragraph.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>A value that indicates the current reading direction for text in a paragraph.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getreadingdirection
		// DWRITE_READING_DIRECTION GetReadingDirection();
		[PreserveSig]
		new DWRITE_READING_DIRECTION GetReadingDirection();

		/// <summary>Gets the direction that text lines flow.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>
		/// The direction that text lines flow within their parent container. For example, DWRITE_FLOW_DIRECTION_TOP_TO_BOTTOM indicates
		/// that text lines are placed from top to bottom.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getflowdirection DWRITE_FLOW_DIRECTION GetFlowDirection();
		[PreserveSig]
		new DWRITE_FLOW_DIRECTION GetFlowDirection();

		/// <summary>Gets the incremental tab stop position.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The incremental tab stop value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getincrementaltabstop FLOAT GetIncrementalTabStop();
		[PreserveSig]
		new float GetIncrementalTabStop();

		/// <summary>Gets the trimming options for text that overflows the layout box.</summary>
		/// <param name="trimmingOptions">
		/// <para>Type: <c>DWRITE_TRIMMING*</c></para>
		/// <para>
		/// When this method returns, it contains a pointer to a DWRITE_TRIMMING structure that holds the text trimming options for the
		/// overflowing text.
		/// </para>
		/// </param>
		/// <param name="trimmingSign">
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>When this method returns, contains an address of a pointer to a trimming omission sign. This parameter may be <c>NULL</c>.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-gettrimming HRESULT GetTrimming(
		// DWRITE_TRIMMING *trimmingOptions, IDWriteInlineObject **trimmingSign );
		new void GetTrimming(out DWRITE_TRIMMING trimmingOptions, out IDWriteInlineObject? trimmingSign);

		/// <summary>Gets the line spacing adjustment set for a multiline text paragraph.</summary>
		/// <param name="lineSpacingMethod">
		/// <para>Type: <c>DWRITE_LINE_SPACING_METHOD*</c></para>
		/// <para>A value that indicates how line height is determined.</para>
		/// </param>
		/// <param name="lineSpacing">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the line height, or distance between one baseline to another.</para>
		/// </param>
		/// <param name="baseline">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>
		/// When this method returns, contains the distance from top of line to baseline. A reasonable ratio to lineSpacing is 80 percent.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlinespacing HRESULT GetLineSpacing(
		// DWRITE_LINE_SPACING_METHOD *lineSpacingMethod, FLOAT *lineSpacing, FLOAT *baseline );
		new void GetLineSpacing(out DWRITE_LINE_SPACING_METHOD lineSpacingMethod, out float lineSpacing, out float baseline);

		/// <summary>Gets the current font collection.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the font collection being used for the current text.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontcollection HRESULT
		// GetFontCollection( IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection GetFontCollection();

		/// <summary>Gets the length of the font family name.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array, in character count, not including the terminated <c>NULL</c> character.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontfamilynamelength UINT32 GetFontFamilyNameLength();
		[PreserveSig]
		new uint GetFontFamilyNameLength();

		/// <summary>Gets a copy of the font family name.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a character array, which is null-terminated, that receives the current font
		/// family name. The buffer allocated for this array should be at least the size, in elements, of nameSize.
		/// </para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The size of the fontFamilyName character array, in character count, including the terminated <c>NULL</c> character. To find the
		/// size of fontFamilyName, use GetFontFamilyNameLength.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontfamilyname HRESULT
		// GetFontFamilyName( WCHAR *fontFamilyName, UINT32 nameSize );
		new void GetFontFamilyName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder fontFamilyName, uint nameSize);

		/// <summary>Gets the font weight of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that indicates the type of weight (such as normal, bold, or black).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontweight DWRITE_FONT_WEIGHT GetFontWeight();
		[PreserveSig]
		new DWRITE_FONT_WEIGHT GetFontWeight();

		/// <summary>Gets the font style of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value which indicates the type of font style (such as slope or incline).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontstyle DWRITE_FONT_STYLE GetFontStyle();
		[PreserveSig]
		new DWRITE_FONT_STYLE GetFontStyle();

		/// <summary>Gets the font stretch of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value which indicates the type of font stretch (such as normal or condensed).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontstretch DWRITE_FONT_STRETCH GetFontStretch();
		[PreserveSig]
		new DWRITE_FONT_STRETCH GetFontStretch();

		/// <summary>Gets the font size in DIP unites.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The current font size in DIP units.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontsize FLOAT GetFontSize();
		[PreserveSig]
		new float GetFontSize();

		/// <summary>Gets the length of the locale name.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array in character count, not including the terminated <c>NULL</c> character.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalenamelength UINT32 GetLocaleNameLength();
		[PreserveSig]
		new uint GetLocaleNameLength();

		/// <summary>Gets a copy of the locale name.</summary>
		/// <param name="localeName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Contains a character array that receives the current locale name.</para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The size of the character array, in character count, including the terminated <c>NULL</c> character. Use GetLocaleNameLength to
		/// get the size of the locale name character array.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalename HRESULT GetLocaleName( WCHAR
		// *localeName, UINT32 nameSize );
		new void GetLocaleName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder localeName, uint nameSize);

		/// <summary>Sets the orientation of a text format.</summary>
		/// <param name="glyphOrientation">
		/// <para>Type: <b><c>DWRITE_VERTICAL_GLYPH_ORIENTATION</c></b></para>
		/// <para>The orientation to apply to the text format.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-setverticalglyphorientation HRESULT
		// SetVerticalGlyphOrientation( DWRITE_VERTICAL_GLYPH_ORIENTATION glyphOrientation );
		new void SetVerticalGlyphOrientation(DWRITE_VERTICAL_GLYPH_ORIENTATION glyphOrientation);

		/// <summary>Get the preferred orientation of glyphs when using a vertical reading direction.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_VERTICAL_GLYPH_ORIENTATION</c></b></para>
		/// <para>The preferred orientation of glyphs when using a vertical reading direction.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-getverticalglyphorientation
		// DWRITE_VERTICAL_GLYPH_ORIENTATION GetVerticalGlyphOrientation();
		[PreserveSig]
		new DWRITE_VERTICAL_GLYPH_ORIENTATION GetVerticalGlyphOrientation();

		/// <summary>Sets the wrapping mode of the last line.</summary>
		/// <param name="isLastLineWrappingEnabled">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>If set to FALSE, the last line is not wrapped. If set to TRUE, the last line is wrapped.</para>
		/// <para>The last line is wrapped by default.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-setlastlinewrapping HRESULT
		// SetLastLineWrapping( BOOL isLastLineWrappingEnabled );
		new void SetLastLineWrapping(bool isLastLineWrappingEnabled);

		/// <summary>Gets the wrapping mode of the last line.</summary>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Returns FALSE if the last line is not wrapped; TRUE if the last line is wrapped.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-getlastlinewrapping BOOL GetLastLineWrapping();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool GetLastLineWrapping();

		/// <summary>
		/// <para>Sets the optical margin alignment for the text format.</para>
		/// <para>
		/// By default, glyphs are aligned to the margin by the default origin and side-bearings of the glyph. If you specify
		/// <b>DWRITE_OPTICAL_ALIGNMENT_USING_SIDE_BEARINGS</b>, then the alignment Suses the side bearings to offset the glyph from the
		/// aligned edge to ensure the ink of the glyphs are aligned.
		/// </para>
		/// </summary>
		/// <param name="opticalAlignment">The optical alignment to set.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-setopticalalignment HRESULT
		// SetOpticalAlignment( DWRITE_OPTICAL_ALIGNMENT opticalAlignment );
		new void SetOpticalAlignment(DWRITE_OPTICAL_ALIGNMENT opticalAlignment);

		/// <summary>Gets the optical margin alignment for the text format.</summary>
		/// <returns>The optical alignment.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-getopticalalignment
		// DWRITE_OPTICAL_ALIGNMENT GetOpticalAlignment();
		[PreserveSig]
		new DWRITE_OPTICAL_ALIGNMENT GetOpticalAlignment();

		/// <summary>Applies the custom font fallback onto the layout. If none is set, it uses the default system fallback list.</summary>
		/// <param name="fontFallback">
		/// <para>Type: <b><c>IDWriteFontFallback</c>*</b></para>
		/// <para>The font fallback to apply to the layout.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-setfontfallback HRESULT
		// SetFontFallback( IDWriteFontFallback *fontFallback );
		new void SetFontFallback([In] IDWriteFontFallback fontFallback);

		/// <summary>Gets the current fallback. If none was ever set since creating the layout, it will be nullptr.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFallback</c>**</b></para>
		/// <para>Contains an address of a pointer to the current font fallback object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-getfontfallback HRESULT
		// GetFontFallback( [out] IDWriteFontFallback **fontFallback );
		new IDWriteFontFallback GetFontFallback();

		/// <summary>Set line spacing.</summary>
		/// <param name="lineSpacingOptions">
		/// <para>Type: <b>const <c>DWRITE_LINE_SPACING</c>*</b></para>
		/// <para>How to manage space between lines.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritetextformat2-setlinespacing HRESULT
		// SetLineSpacing( [in] DWRITE_LINE_SPACING const *lineSpacingOptions );
		void SetLineSpacing(in DWRITE_LINE_SPACING lineSpacingOptions);

		/// <summary>Gets the line spacing adjustment set for a multiline text paragraph.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_LINE_SPACING</c>*</b></para>
		/// <para>A structure describing how the space between lines is managed for the paragraph.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritetextformat2-getlinespacing HRESULT
		// GetLineSpacing( [out] DWRITE_LINE_SPACING *lineSpacingOptions );
		DWRITE_LINE_SPACING GetLineSpacing();
	}

	/// <summary>
	/// <para>Describes the font and paragraph properties used to format text, and it describes locale information.</para>
	/// <para>This interface extends <c>IDWriteTextFormat2</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritetextformat3
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteTextFormat3")]
	[ComImport, Guid("6D3B5641-E550-430D-A85B-B7BF48A93427"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteTextFormat3 : IDWriteTextFormat, IDWriteTextFormat1, IDWriteTextFormat2
	{
		/// <summary>
		/// Sets the alignment of text in a paragraph, relative to the leading and trailing edge of a layout box for a IDWriteTextFormat interface.
		/// </summary>
		/// <param name="textAlignment">
		/// <para>Type: <c>DWRITE_TEXT_ALIGNMENT</c></para>
		/// <para>The text alignment option being set for the paragraph of type DWRITE_TEXT_ALIGNMENT. For more information, see Remarks.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The text can be aligned to the leading or trailing edge of the layout box, or it can be centered. The following illustration
		/// shows text with the alignment set to DWRITE_TEXT_ALIGNMENT_LEADING, <c>DWRITE_TEXT_ALIGNMENT_CENTER</c>, and
		/// <c>DWRITE_TEXT_ALIGNMENT_TRAILING</c>, respectively.
		/// </para>
		/// <para>
		/// <c>Note</c> The alignment is dependent on reading direction, the above is for left-to-right reading direction. For right-to-left
		/// reading direction it would be the opposite.
		/// </para>
		/// <para>See DWRITE_TEXT_ALIGNMENT for more information.</para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settextalignment HRESULT SetTextAlignment(
		// DWRITE_TEXT_ALIGNMENT textAlignment );
		new void SetTextAlignment(DWRITE_TEXT_ALIGNMENT textAlignment);

		/// <summary>Sets the alignment option of a paragraph relative to the layout box's top and bottom edge.</summary>
		/// <param name="paragraphAlignment">
		/// <para>Type: <c>DWRITE_PARAGRAPH_ALIGNMENT</c></para>
		/// <para>The paragraph alignment option being set for a paragraph; see DWRITE_PARAGRAPH_ALIGNMENT for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setparagraphalignment HRESULT
		// SetParagraphAlignment( DWRITE_PARAGRAPH_ALIGNMENT paragraphAlignment );
		new void SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT paragraphAlignment);

		/// <summary>Sets the word wrapping option.</summary>
		/// <param name="wordWrapping">
		/// <para>Type: <c>DWRITE_WORD_WRAPPING</c></para>
		/// <para>The word wrapping option being set for a paragraph; see DWRITE_WORD_WRAPPING for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setwordwrapping HRESULT SetWordWrapping(
		// DWRITE_WORD_WRAPPING wordWrapping );
		new void SetWordWrapping(DWRITE_WORD_WRAPPING wordWrapping);

		/// <summary>Sets the paragraph reading direction.</summary>
		/// <param name="readingDirection">
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>
		/// The text reading direction (for example, DWRITE_READING_DIRECTION_RIGHT_TO_LEFT for languages, such as Arabic, that read from
		/// right to left) for a paragraph.
		/// </para>
		/// </param>
		/// <remarks>
		/// The reading direction and flow direction must always be set 90 degrees orthogonal to each other, or else you will get the error
		/// DWRITE_E_FLOWDIRECTIONCONFLICTS when you use layout functions like Draw or GetMetrics. So if you set a vertical reading
		/// direction (for example, to DWRITE_READING_DIRECTION_TOP_TO_BOTTOM), then you must also use SetFlowDirection to set the flow
		/// direction appropriately (for example, to DWRITE_FLOW_DIRECTION_RIGHT_TO_LEFT).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setreadingdirection HRESULT
		// SetReadingDirection( DWRITE_READING_DIRECTION readingDirection );
		new void SetReadingDirection(DWRITE_READING_DIRECTION readingDirection);

		/// <summary>Sets the paragraph flow direction.</summary>
		/// <param name="flowDirection">
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>The paragraph flow direction; see DWRITE_FLOW_DIRECTION for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setflowdirection HRESULT SetFlowDirection(
		// DWRITE_FLOW_DIRECTION flowDirection );
		new void SetFlowDirection(DWRITE_FLOW_DIRECTION flowDirection);

		/// <summary>Sets a fixed distance between two adjacent tab stops.</summary>
		/// <param name="incrementalTabStop">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The fixed distance between two adjacent tab stops.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setincrementaltabstop HRESULT
		// SetIncrementalTabStop( FLOAT incrementalTabStop );
		new void SetIncrementalTabStop(float incrementalTabStop);

		/// <summary>Sets trimming options for text overflowing the layout width.</summary>
		/// <param name="trimmingOptions">
		/// <para>Type: <c>const DWRITE_TRIMMING*</c></para>
		/// <para>Text trimming options.</para>
		/// </param>
		/// <param name="trimmingSign">
		/// <para>Type: <c>IDWriteInlineObject*</c></para>
		/// <para>Application-defined omission sign. This parameter may be <c>NULL</c>. See IDWriteInlineObject for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settrimming HRESULT SetTrimming(
		// DWRITE_TRIMMING const *trimmingOptions, IDWriteInlineObject *trimmingSign );
		new void SetTrimming(in DWRITE_TRIMMING trimmingOptions, [In, Optional] IDWriteInlineObject? trimmingSign);

		/// <summary>Sets the line spacing.</summary>
		/// <param name="lineSpacingMethod">
		/// <para>Type: <c>DWRITE_LINE_SPACING_METHOD</c></para>
		/// <para>Specifies how line height is being determined; see DWRITE_LINE_SPACING_METHOD for more information.</para>
		/// </param>
		/// <param name="lineSpacing">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The line height, or distance between one baseline to another.</para>
		/// </param>
		/// <param name="baseline">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The distance from top of line to baseline. A reasonable ratio to lineSpacing is 80 percent.</para>
		/// </param>
		/// <remarks>
		/// For the default method, spacing depends solely on the content. For uniform spacing, the specified line height overrides the content.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setlinespacing HRESULT SetLineSpacing(
		// DWRITE_LINE_SPACING_METHOD lineSpacingMethod, FLOAT lineSpacing, FLOAT baseline );
		new void SetLineSpacing(DWRITE_LINE_SPACING_METHOD lineSpacingMethod, float lineSpacing, float baseline);

		/// <summary>Gets the alignment option of text relative to the layout box's leading and trailing edge.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_TEXT_ALIGNMENT</c></para>
		/// <para>Returns the text alignment option of the current paragraph.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-gettextalignment DWRITE_TEXT_ALIGNMENT GetTextAlignment();
		[PreserveSig]
		new DWRITE_TEXT_ALIGNMENT GetTextAlignment();

		/// <summary>Gets the alignment option of a paragraph which is relative to the top and bottom edges of a layout box.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_PARAGRAPH_ALIGNMENT</c></para>
		/// <para>A value that indicates the current paragraph alignment option.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getparagraphalignment
		// DWRITE_PARAGRAPH_ALIGNMENT GetParagraphAlignment();
		[PreserveSig]
		new DWRITE_PARAGRAPH_ALIGNMENT GetParagraphAlignment();

		/// <summary>Gets the word wrapping option.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_WORD_WRAPPING</c></para>
		/// <para>Returns the word wrapping option; see DWRITE_WORD_WRAPPING for more information.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getwordwrapping DWRITE_WORD_WRAPPING GetWordWrapping();
		[PreserveSig]
		new DWRITE_WORD_WRAPPING GetWordWrapping();

		/// <summary>Gets the current reading direction for text in a paragraph.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>A value that indicates the current reading direction for text in a paragraph.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getreadingdirection
		// DWRITE_READING_DIRECTION GetReadingDirection();
		[PreserveSig]
		new DWRITE_READING_DIRECTION GetReadingDirection();

		/// <summary>Gets the direction that text lines flow.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>
		/// The direction that text lines flow within their parent container. For example, DWRITE_FLOW_DIRECTION_TOP_TO_BOTTOM indicates
		/// that text lines are placed from top to bottom.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getflowdirection DWRITE_FLOW_DIRECTION GetFlowDirection();
		[PreserveSig]
		new DWRITE_FLOW_DIRECTION GetFlowDirection();

		/// <summary>Gets the incremental tab stop position.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The incremental tab stop value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getincrementaltabstop FLOAT GetIncrementalTabStop();
		[PreserveSig]
		new float GetIncrementalTabStop();

		/// <summary>Gets the trimming options for text that overflows the layout box.</summary>
		/// <param name="trimmingOptions">
		/// <para>Type: <c>DWRITE_TRIMMING*</c></para>
		/// <para>
		/// When this method returns, it contains a pointer to a DWRITE_TRIMMING structure that holds the text trimming options for the
		/// overflowing text.
		/// </para>
		/// </param>
		/// <param name="trimmingSign">
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>When this method returns, contains an address of a pointer to a trimming omission sign. This parameter may be <c>NULL</c>.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-gettrimming HRESULT GetTrimming(
		// DWRITE_TRIMMING *trimmingOptions, IDWriteInlineObject **trimmingSign );
		new void GetTrimming(out DWRITE_TRIMMING trimmingOptions, out IDWriteInlineObject? trimmingSign);

		/// <summary>Gets the line spacing adjustment set for a multiline text paragraph.</summary>
		/// <param name="lineSpacingMethod">
		/// <para>Type: <c>DWRITE_LINE_SPACING_METHOD*</c></para>
		/// <para>A value that indicates how line height is determined.</para>
		/// </param>
		/// <param name="lineSpacing">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the line height, or distance between one baseline to another.</para>
		/// </param>
		/// <param name="baseline">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>
		/// When this method returns, contains the distance from top of line to baseline. A reasonable ratio to lineSpacing is 80 percent.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlinespacing HRESULT GetLineSpacing(
		// DWRITE_LINE_SPACING_METHOD *lineSpacingMethod, FLOAT *lineSpacing, FLOAT *baseline );
		new void GetLineSpacing(out DWRITE_LINE_SPACING_METHOD lineSpacingMethod, out float lineSpacing, out float baseline);

		/// <summary>Gets the current font collection.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the font collection being used for the current text.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontcollection HRESULT
		// GetFontCollection( IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection GetFontCollection();

		/// <summary>Gets the length of the font family name.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array, in character count, not including the terminated <c>NULL</c> character.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontfamilynamelength UINT32 GetFontFamilyNameLength();
		[PreserveSig]
		new uint GetFontFamilyNameLength();

		/// <summary>Gets a copy of the font family name.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a character array, which is null-terminated, that receives the current font
		/// family name. The buffer allocated for this array should be at least the size, in elements, of nameSize.
		/// </para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The size of the fontFamilyName character array, in character count, including the terminated <c>NULL</c> character. To find the
		/// size of fontFamilyName, use GetFontFamilyNameLength.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontfamilyname HRESULT
		// GetFontFamilyName( WCHAR *fontFamilyName, UINT32 nameSize );
		new void GetFontFamilyName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder fontFamilyName, uint nameSize);

		/// <summary>Gets the font weight of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that indicates the type of weight (such as normal, bold, or black).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontweight DWRITE_FONT_WEIGHT GetFontWeight();
		[PreserveSig]
		new DWRITE_FONT_WEIGHT GetFontWeight();

		/// <summary>Gets the font style of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value which indicates the type of font style (such as slope or incline).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontstyle DWRITE_FONT_STYLE GetFontStyle();
		[PreserveSig]
		new DWRITE_FONT_STYLE GetFontStyle();

		/// <summary>Gets the font stretch of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value which indicates the type of font stretch (such as normal or condensed).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontstretch DWRITE_FONT_STRETCH GetFontStretch();
		[PreserveSig]
		new DWRITE_FONT_STRETCH GetFontStretch();

		/// <summary>Gets the font size in DIP unites.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The current font size in DIP units.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontsize FLOAT GetFontSize();
		[PreserveSig]
		new float GetFontSize();

		/// <summary>Gets the length of the locale name.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array in character count, not including the terminated <c>NULL</c> character.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalenamelength UINT32 GetLocaleNameLength();
		[PreserveSig]
		new uint GetLocaleNameLength();

		/// <summary>Gets a copy of the locale name.</summary>
		/// <param name="localeName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Contains a character array that receives the current locale name.</para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The size of the character array, in character count, including the terminated <c>NULL</c> character. Use GetLocaleNameLength to
		/// get the size of the locale name character array.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalename HRESULT GetLocaleName( WCHAR
		// *localeName, UINT32 nameSize );
		new void GetLocaleName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder localeName, uint nameSize);

		/// <summary>Sets the orientation of a text format.</summary>
		/// <param name="glyphOrientation">
		/// <para>Type: <b><c>DWRITE_VERTICAL_GLYPH_ORIENTATION</c></b></para>
		/// <para>The orientation to apply to the text format.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-setverticalglyphorientation HRESULT
		// SetVerticalGlyphOrientation( DWRITE_VERTICAL_GLYPH_ORIENTATION glyphOrientation );
		new void SetVerticalGlyphOrientation(DWRITE_VERTICAL_GLYPH_ORIENTATION glyphOrientation);

		/// <summary>Get the preferred orientation of glyphs when using a vertical reading direction.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_VERTICAL_GLYPH_ORIENTATION</c></b></para>
		/// <para>The preferred orientation of glyphs when using a vertical reading direction.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-getverticalglyphorientation
		// DWRITE_VERTICAL_GLYPH_ORIENTATION GetVerticalGlyphOrientation();
		[PreserveSig]
		new DWRITE_VERTICAL_GLYPH_ORIENTATION GetVerticalGlyphOrientation();

		/// <summary>Sets the wrapping mode of the last line.</summary>
		/// <param name="isLastLineWrappingEnabled">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>If set to FALSE, the last line is not wrapped. If set to TRUE, the last line is wrapped.</para>
		/// <para>The last line is wrapped by default.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-setlastlinewrapping HRESULT
		// SetLastLineWrapping( BOOL isLastLineWrappingEnabled );
		new void SetLastLineWrapping(bool isLastLineWrappingEnabled);

		/// <summary>Gets the wrapping mode of the last line.</summary>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Returns FALSE if the last line is not wrapped; TRUE if the last line is wrapped.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-getlastlinewrapping BOOL GetLastLineWrapping();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool GetLastLineWrapping();

		/// <summary>
		/// <para>Sets the optical margin alignment for the text format.</para>
		/// <para>
		/// By default, glyphs are aligned to the margin by the default origin and side-bearings of the glyph. If you specify
		/// <b>DWRITE_OPTICAL_ALIGNMENT_USING_SIDE_BEARINGS</b>, then the alignment Suses the side bearings to offset the glyph from the
		/// aligned edge to ensure the ink of the glyphs are aligned.
		/// </para>
		/// </summary>
		/// <param name="opticalAlignment">The optical alignment to set.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-setopticalalignment HRESULT
		// SetOpticalAlignment( DWRITE_OPTICAL_ALIGNMENT opticalAlignment );
		new void SetOpticalAlignment(DWRITE_OPTICAL_ALIGNMENT opticalAlignment);

		/// <summary>Gets the optical margin alignment for the text format.</summary>
		/// <returns>The optical alignment.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-getopticalalignment
		// DWRITE_OPTICAL_ALIGNMENT GetOpticalAlignment();
		[PreserveSig]
		new DWRITE_OPTICAL_ALIGNMENT GetOpticalAlignment();

		/// <summary>Applies the custom font fallback onto the layout. If none is set, it uses the default system fallback list.</summary>
		/// <param name="fontFallback">
		/// <para>Type: <b><c>IDWriteFontFallback</c>*</b></para>
		/// <para>The font fallback to apply to the layout.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-setfontfallback HRESULT
		// SetFontFallback( IDWriteFontFallback *fontFallback );
		new void SetFontFallback([In] IDWriteFontFallback fontFallback);

		/// <summary>Gets the current fallback. If none was ever set since creating the layout, it will be nullptr.</summary>
		/// <returns>
		/// <para>Type: <b><c>IDWriteFontFallback</c>**</b></para>
		/// <para>Contains an address of a pointer to the current font fallback object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextformat1-getfontfallback HRESULT
		// GetFontFallback( [out] IDWriteFontFallback **fontFallback );
		new IDWriteFontFallback GetFontFallback();

		/// <summary>Set line spacing.</summary>
		/// <param name="lineSpacingOptions">
		/// <para>Type: <b>const <c>DWRITE_LINE_SPACING</c>*</b></para>
		/// <para>How to manage space between lines.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritetextformat2-setlinespacing HRESULT
		// SetLineSpacing( [in] DWRITE_LINE_SPACING const *lineSpacingOptions );
		new void SetLineSpacing(in DWRITE_LINE_SPACING lineSpacingOptions);

		/// <summary>Gets the line spacing adjustment set for a multiline text paragraph.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_LINE_SPACING</c>*</b></para>
		/// <para>A structure describing how the space between lines is managed for the paragraph.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritetextformat2-getlinespacing HRESULT
		// GetLineSpacing( [out] DWRITE_LINE_SPACING *lineSpacingOptions );
		new DWRITE_LINE_SPACING GetLineSpacing();

		/// <summary>Set values for font axes of the format.</summary>
		/// <param name="fontAxisValues">List of font axis values.</param>
		/// <param name="fontAxisValueCount">Number of font axis values.</param>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritetextformat3-setfontaxisvalues
		// HRESULT SetFontAxisValues( DWRITE_FONT_AXIS_VALUE const *fontAxisValues, UINT32 fontAxisValueCount );
		void SetFontAxisValues([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);

		/// <summary>Retrieves the number of axes set on the format.</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The number of axes set on the format.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritetextformat3-getfontaxisvaluecount UINT32 GetFontAxisValueCount();
		[PreserveSig]
		uint GetFontAxisValueCount();

		/// <summary>Retrieves the list of font axis values on the format.</summary>
		/// <param name="fontAxisValues">
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_VALUE</c>*</b></para>
		/// <para>
		/// A pointer to an array of <b>DWRITE_FONT_AXIS_VALUE</b> structures into which <b>GetFontAxisValues</b> writes the list of font
		/// axis values. You're responsible for managing the size and the lifetime of this array. Call <c>GetFontAxisValueCount</c> to
		/// determine the size of array to allocate.
		/// </para>
		/// </param>
		/// <param name="fontAxisValueCount">
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The maximum number of font axis values to write into the memory block pointed to by <c>fontAxisValues</c>.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritetextformat3-getfontaxisvalues HRESULT
		// GetFontAxisValues( [out] DWRITE_FONT_AXIS_VALUE *fontAxisValues, UINT32 fontAxisValueCount );
		void GetFontAxisValues([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues, uint fontAxisValueCount);

		/// <summary>Retrieves the automatic axis options.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_AUTOMATIC_FONT_AXES</c></b></para>
		/// <para>Automatic axis options.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritetextformat3-getautomaticfontaxes
		// DWRITE_AUTOMATIC_FONT_AXES GetAutomaticFontAxes();
		[PreserveSig]
		DWRITE_AUTOMATIC_FONT_AXES GetAutomaticFontAxes();

		/// <summary>Sets the automatic font axis options.</summary>
		/// <param name="automaticFontAxes">Automatic font axis options.</param>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritetextformat3-setautomaticfontaxes
		// HRESULT SetAutomaticFontAxes( DWRITE_AUTOMATIC_FONT_AXES automaticFontAxes );
		void SetAutomaticFontAxes(DWRITE_AUTOMATIC_FONT_AXES automaticFontAxes);
	}

	/// <summary>Represents a block of text after it has been fully analyzed and formatted.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nn-dwrite_3-idwritetextlayout3
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteTextLayout3")]
	[ComImport, Guid("07DDCD52-020E-4DE8-AC33-6C953D83F92D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteTextLayout3 : IDWriteTextFormat, IDWriteTextLayout, IDWriteTextLayout1, IDWriteTextLayout2
	{
		/// <summary>
		/// Sets the alignment of text in a paragraph, relative to the leading and trailing edge of a layout box for a IDWriteTextFormat interface.
		/// </summary>
		/// <param name="textAlignment">
		/// <para>Type: <c>DWRITE_TEXT_ALIGNMENT</c></para>
		/// <para>The text alignment option being set for the paragraph of type DWRITE_TEXT_ALIGNMENT. For more information, see Remarks.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The text can be aligned to the leading or trailing edge of the layout box, or it can be centered. The following illustration
		/// shows text with the alignment set to DWRITE_TEXT_ALIGNMENT_LEADING, <c>DWRITE_TEXT_ALIGNMENT_CENTER</c>, and
		/// <c>DWRITE_TEXT_ALIGNMENT_TRAILING</c>, respectively.
		/// </para>
		/// <para>
		/// <c>Note</c> The alignment is dependent on reading direction, the above is for left-to-right reading direction. For right-to-left
		/// reading direction it would be the opposite.
		/// </para>
		/// <para>See DWRITE_TEXT_ALIGNMENT for more information.</para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settextalignment HRESULT SetTextAlignment(
		// DWRITE_TEXT_ALIGNMENT textAlignment );
		new void SetTextAlignment(DWRITE_TEXT_ALIGNMENT textAlignment);

		/// <summary>Sets the alignment option of a paragraph relative to the layout box's top and bottom edge.</summary>
		/// <param name="paragraphAlignment">
		/// <para>Type: <c>DWRITE_PARAGRAPH_ALIGNMENT</c></para>
		/// <para>The paragraph alignment option being set for a paragraph; see DWRITE_PARAGRAPH_ALIGNMENT for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setparagraphalignment HRESULT
		// SetParagraphAlignment( DWRITE_PARAGRAPH_ALIGNMENT paragraphAlignment );
		new void SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT paragraphAlignment);

		/// <summary>Sets the word wrapping option.</summary>
		/// <param name="wordWrapping">
		/// <para>Type: <c>DWRITE_WORD_WRAPPING</c></para>
		/// <para>The word wrapping option being set for a paragraph; see DWRITE_WORD_WRAPPING for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setwordwrapping HRESULT SetWordWrapping(
		// DWRITE_WORD_WRAPPING wordWrapping );
		new void SetWordWrapping(DWRITE_WORD_WRAPPING wordWrapping);

		/// <summary>Sets the paragraph reading direction.</summary>
		/// <param name="readingDirection">
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>
		/// The text reading direction (for example, DWRITE_READING_DIRECTION_RIGHT_TO_LEFT for languages, such as Arabic, that read from
		/// right to left) for a paragraph.
		/// </para>
		/// </param>
		/// <remarks>
		/// The reading direction and flow direction must always be set 90 degrees orthogonal to each other, or else you will get the error
		/// DWRITE_E_FLOWDIRECTIONCONFLICTS when you use layout functions like Draw or GetMetrics. So if you set a vertical reading
		/// direction (for example, to DWRITE_READING_DIRECTION_TOP_TO_BOTTOM), then you must also use SetFlowDirection to set the flow
		/// direction appropriately (for example, to DWRITE_FLOW_DIRECTION_RIGHT_TO_LEFT).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setreadingdirection HRESULT
		// SetReadingDirection( DWRITE_READING_DIRECTION readingDirection );
		new void SetReadingDirection(DWRITE_READING_DIRECTION readingDirection);

		/// <summary>Sets the paragraph flow direction.</summary>
		/// <param name="flowDirection">
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>The paragraph flow direction; see DWRITE_FLOW_DIRECTION for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setflowdirection HRESULT SetFlowDirection(
		// DWRITE_FLOW_DIRECTION flowDirection );
		new void SetFlowDirection(DWRITE_FLOW_DIRECTION flowDirection);

		/// <summary>Sets a fixed distance between two adjacent tab stops.</summary>
		/// <param name="incrementalTabStop">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The fixed distance between two adjacent tab stops.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setincrementaltabstop HRESULT
		// SetIncrementalTabStop( FLOAT incrementalTabStop );
		new void SetIncrementalTabStop(float incrementalTabStop);

		/// <summary>Sets trimming options for text overflowing the layout width.</summary>
		/// <param name="trimmingOptions">
		/// <para>Type: <c>const DWRITE_TRIMMING*</c></para>
		/// <para>Text trimming options.</para>
		/// </param>
		/// <param name="trimmingSign">
		/// <para>Type: <c>IDWriteInlineObject*</c></para>
		/// <para>Application-defined omission sign. This parameter may be <c>NULL</c>. See IDWriteInlineObject for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settrimming HRESULT SetTrimming(
		// DWRITE_TRIMMING const *trimmingOptions, IDWriteInlineObject *trimmingSign );
		new void SetTrimming(in DWRITE_TRIMMING trimmingOptions, [In, Optional] IDWriteInlineObject? trimmingSign);

		/// <summary>Sets the line spacing.</summary>
		/// <param name="lineSpacingMethod">
		/// <para>Type: <c>DWRITE_LINE_SPACING_METHOD</c></para>
		/// <para>Specifies how line height is being determined; see DWRITE_LINE_SPACING_METHOD for more information.</para>
		/// </param>
		/// <param name="lineSpacing">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The line height, or distance between one baseline to another.</para>
		/// </param>
		/// <param name="baseline">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The distance from top of line to baseline. A reasonable ratio to lineSpacing is 80 percent.</para>
		/// </param>
		/// <remarks>
		/// For the default method, spacing depends solely on the content. For uniform spacing, the specified line height overrides the content.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setlinespacing HRESULT SetLineSpacing(
		// DWRITE_LINE_SPACING_METHOD lineSpacingMethod, FLOAT lineSpacing, FLOAT baseline );
		new void SetLineSpacing(DWRITE_LINE_SPACING_METHOD lineSpacingMethod, float lineSpacing, float baseline);

		/// <summary>Gets the alignment option of text relative to the layout box's leading and trailing edge.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_TEXT_ALIGNMENT</c></para>
		/// <para>Returns the text alignment option of the current paragraph.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-gettextalignment DWRITE_TEXT_ALIGNMENT GetTextAlignment();
		[PreserveSig]
		new DWRITE_TEXT_ALIGNMENT GetTextAlignment();

		/// <summary>Gets the alignment option of a paragraph which is relative to the top and bottom edges of a layout box.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_PARAGRAPH_ALIGNMENT</c></para>
		/// <para>A value that indicates the current paragraph alignment option.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getparagraphalignment
		// DWRITE_PARAGRAPH_ALIGNMENT GetParagraphAlignment();
		[PreserveSig]
		new DWRITE_PARAGRAPH_ALIGNMENT GetParagraphAlignment();

		/// <summary>Gets the word wrapping option.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_WORD_WRAPPING</c></para>
		/// <para>Returns the word wrapping option; see DWRITE_WORD_WRAPPING for more information.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getwordwrapping DWRITE_WORD_WRAPPING GetWordWrapping();
		[PreserveSig]
		new DWRITE_WORD_WRAPPING GetWordWrapping();

		/// <summary>Gets the current reading direction for text in a paragraph.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>A value that indicates the current reading direction for text in a paragraph.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getreadingdirection
		// DWRITE_READING_DIRECTION GetReadingDirection();
		[PreserveSig]
		new DWRITE_READING_DIRECTION GetReadingDirection();

		/// <summary>Gets the direction that text lines flow.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>
		/// The direction that text lines flow within their parent container. For example, DWRITE_FLOW_DIRECTION_TOP_TO_BOTTOM indicates
		/// that text lines are placed from top to bottom.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getflowdirection DWRITE_FLOW_DIRECTION GetFlowDirection();
		[PreserveSig]
		new DWRITE_FLOW_DIRECTION GetFlowDirection();

		/// <summary>Gets the incremental tab stop position.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The incremental tab stop value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getincrementaltabstop FLOAT GetIncrementalTabStop();
		[PreserveSig]
		new float GetIncrementalTabStop();

		/// <summary>Gets the trimming options for text that overflows the layout box.</summary>
		/// <param name="trimmingOptions">
		/// <para>Type: <c>DWRITE_TRIMMING*</c></para>
		/// <para>
		/// When this method returns, it contains a pointer to a DWRITE_TRIMMING structure that holds the text trimming options for the
		/// overflowing text.
		/// </para>
		/// </param>
		/// <param name="trimmingSign">
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>When this method returns, contains an address of a pointer to a trimming omission sign. This parameter may be <c>NULL</c>.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-gettrimming HRESULT GetTrimming(
		// DWRITE_TRIMMING *trimmingOptions, IDWriteInlineObject **trimmingSign );
		new void GetTrimming(out DWRITE_TRIMMING trimmingOptions, out IDWriteInlineObject trimmingSign);

		/// <summary>Gets the line spacing adjustment set for a multiline text paragraph.</summary>
		/// <param name="lineSpacingMethod">
		/// <para>Type: <c>DWRITE_LINE_SPACING_METHOD*</c></para>
		/// <para>A value that indicates how line height is determined.</para>
		/// </param>
		/// <param name="lineSpacing">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the line height, or distance between one baseline to another.</para>
		/// </param>
		/// <param name="baseline">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>
		/// When this method returns, contains the distance from top of line to baseline. A reasonable ratio to lineSpacing is 80 percent.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlinespacing HRESULT GetLineSpacing(
		// DWRITE_LINE_SPACING_METHOD *lineSpacingMethod, FLOAT *lineSpacing, FLOAT *baseline );
		new void GetLineSpacing(out DWRITE_LINE_SPACING_METHOD lineSpacingMethod, out float lineSpacing, out float baseline);

		/// <summary>Gets the current font collection.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the font collection being used for the current text.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontcollection HRESULT
		// GetFontCollection( IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection GetFontCollection();

		/// <summary>Gets the length of the font family name.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array, in character count, not including the terminated <c>NULL</c> character.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontfamilynamelength UINT32 GetFontFamilyNameLength();
		[PreserveSig]
		new uint GetFontFamilyNameLength();

		/// <summary>Gets a copy of the font family name.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a character array, which is null-terminated, that receives the current font
		/// family name. The buffer allocated for this array should be at least the size, in elements, of nameSize.
		/// </para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The size of the fontFamilyName character array, in character count, including the terminated <c>NULL</c> character. To find the
		/// size of fontFamilyName, use GetFontFamilyNameLength.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontfamilyname HRESULT
		// GetFontFamilyName( WCHAR *fontFamilyName, UINT32 nameSize );
		new void GetFontFamilyName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder fontFamilyName, uint nameSize);

		/// <summary>Gets the font weight of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that indicates the type of weight (such as normal, bold, or black).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontweight DWRITE_FONT_WEIGHT GetFontWeight();
		[PreserveSig]
		new DWRITE_FONT_WEIGHT GetFontWeight();

		/// <summary>Gets the font style of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value which indicates the type of font style (such as slope or incline).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontstyle DWRITE_FONT_STYLE GetFontStyle();
		[PreserveSig]
		new DWRITE_FONT_STYLE GetFontStyle();

		/// <summary>Gets the font stretch of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value which indicates the type of font stretch (such as normal or condensed).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontstretch DWRITE_FONT_STRETCH GetFontStretch();
		[PreserveSig]
		new DWRITE_FONT_STRETCH GetFontStretch();

		/// <summary>Gets the font size in DIP unites.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The current font size in DIP units.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontsize FLOAT GetFontSize();
		[PreserveSig]
		new float GetFontSize();

		/// <summary>Gets the length of the locale name.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array in character count, not including the terminated <c>NULL</c> character.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalenamelength UINT32 GetLocaleNameLength();
		[PreserveSig]
		new uint GetLocaleNameLength();

		/// <summary>Gets a copy of the locale name.</summary>
		/// <param name="localeName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Contains a character array that receives the current locale name.</para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The size of the character array, in character count, including the terminated <c>NULL</c> character. Use GetLocaleNameLength to
		/// get the size of the locale name character array.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalename HRESULT GetLocaleName( WCHAR
		// *localeName, UINT32 nameSize );
		new void GetLocaleName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder localeName, uint nameSize);

		/// <summary>Sets the layout maximum width.</summary>
		/// <param name="maxWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the maximum width of the layout box.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setmaxwidth HRESULT SetMaxWidth( FLOAT
		// maxWidth );
		new void SetMaxWidth(float maxWidth);

		/// <summary>Sets the layout maximum height.</summary>
		/// <param name="maxHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the maximum height of the layout box.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setmaxheight HRESULT SetMaxHeight( FLOAT
		// maxHeight );
		new void SetMaxHeight(float maxHeight);

		/// <summary>Sets the font collection.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection*</c></para>
		/// <para>The font collection to set.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontcollection HRESULT
		// SetFontCollection( IDWriteFontCollection *fontCollection, DWRITE_TEXT_RANGE textRange );
		new void SetFontCollection([In] IDWriteFontCollection fontCollection, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets null-terminated font family name for text within a specified text range.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>The font family name that applies to the entire text string within the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontfamilyname HRESULT
		// SetFontFamilyName( WCHAR const *fontFamilyName, DWRITE_TEXT_RANGE textRange );
		new void SetFontFamilyName([MarshalAs(UnmanagedType.LPWStr)] string fontFamilyName, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the font weight for text within a text range specified by a DWRITE_TEXT_RANGE structure.</summary>
		/// <param name="fontWeight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>The font weight to be set for text within the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The font weight can be set to one of the predefined font weight values provided in the DWRITE_FONT_WEIGHT enumeration or an
		/// integer from 1 to 999. Values outside this range will cause the method to fail with an <c>E_INVALIDARG</c> return value.
		/// </para>
		/// <para>The following illustration shows an example of Normal and UltraBold weights for the Palatino Linotype typeface.</para>
		/// <para>Examples</para>
		/// <para>The following code illustrates how to set the font weight to bold.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontweight HRESULT SetFontWeight(
		// DWRITE_FONT_WEIGHT fontWeight, DWRITE_TEXT_RANGE textRange );
		new void SetFontWeight(DWRITE_FONT_WEIGHT fontWeight, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the font style for text within a text range specified by a DWRITE_TEXT_RANGE structure.</summary>
		/// <param name="fontStyle">
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>The font style to be set for text within a range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>The text range to which this change applies.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The font style can be set to Normal, Italic or Oblique. The following illustration shows three styles for the Palatino font. For
		/// more information, see DWRITE_FONT_STYLE.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code illustrates how to set the font style to italic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontstyle HRESULT SetFontStyle(
		// DWRITE_FONT_STYLE fontStyle, DWRITE_TEXT_RANGE textRange );
		new void SetFontStyle(DWRITE_FONT_STYLE fontStyle, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the font stretch for text within a specified text range.</summary>
		/// <param name="fontStretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value which indicates the type of font stretch for text within the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontstretch HRESULT SetFontStretch(
		// DWRITE_FONT_STRETCH fontStretch, DWRITE_TEXT_RANGE textRange );
		new void SetFontStretch(DWRITE_FONT_STRETCH fontStretch, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the font size in DIP units for text within a specified text range.</summary>
		/// <param name="fontSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The font size in DIP units to be set for text in the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontsize HRESULT SetFontSize( FLOAT
		// fontSize, DWRITE_TEXT_RANGE textRange );
		new void SetFontSize(float fontSize, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets underlining for text within a specified text range.</summary>
		/// <param name="hasUnderline">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag that indicates whether underline takes place within a specified text range.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setunderline HRESULT SetUnderline( BOOL
		// hasUnderline, DWRITE_TEXT_RANGE textRange );
		new void SetUnderline([MarshalAs(UnmanagedType.Bool)] bool hasUnderline, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets strikethrough for text within a specified text range.</summary>
		/// <param name="hasStrikethrough">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag that indicates whether strikethrough takes place in the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setstrikethrough HRESULT SetStrikethrough(
		// BOOL hasStrikethrough, DWRITE_TEXT_RANGE textRange );
		new void SetStrikethrough([MarshalAs(UnmanagedType.Bool)] bool hasStrikethrough, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the application-defined drawing effect.</summary>
		/// <param name="drawingEffect">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// Application-defined drawing effects that apply to the range. This data object will be passed back to the application's drawing
		/// callbacks for final rendering.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>The text range to which this change applies.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// An ID2D1Brush, such as a color or gradient brush, can be set as a drawing effect if you are using the
		/// ID2D1RenderTarget::DrawTextLayout to draw text and that brush will be used to draw the specified range of text.
		/// </para>
		/// <para>
		/// This drawing effect is associated with the specified range and will be passed back to the application by way of the callback
		/// when the range is drawn at drawing time.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setdrawingeffect HRESULT SetDrawingEffect(
		// IUnknown *drawingEffect, DWRITE_TEXT_RANGE textRange );
		new void SetDrawingEffect([MarshalAs(UnmanagedType.Interface)] object drawingEffect, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the inline object.</summary>
		/// <param name="inlineObject">
		/// <para>Type: <c>IDWriteInlineObject*</c></para>
		/// <para>An application-defined inline object.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The application may call this function to specify the set of properties describing an application-defined inline object for
		/// specific range.
		/// </para>
		/// <para>
		/// This inline object applies to the specified range and will be passed back to the application by way of the DrawInlineObject
		/// callback when the range is drawn. Any text in that range will be suppressed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setinlineobject HRESULT SetInlineObject(
		// IDWriteInlineObject *inlineObject, DWRITE_TEXT_RANGE textRange );
		new void SetInlineObject([In] IDWriteInlineObject inlineObject, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets font typography features for text within a specified text range.</summary>
		/// <param name="typography">
		/// <para>Type: <c>IDWriteTypography*</c></para>
		/// <para>Pointer to font typography settings.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-settypography HRESULT SetTypography(
		// IDWriteTypography *typography, DWRITE_TEXT_RANGE textRange );
		new void SetTypography([In] IDWriteTypography typography, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the locale name for text within a specified text range.</summary>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>A null-terminated locale name string.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setlocalename HRESULT SetLocaleName( WCHAR
		// const *localeName, DWRITE_TEXT_RANGE textRange );
		new void SetLocaleName([MarshalAs(UnmanagedType.LPWStr)] string localeName, DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the layout maximum width.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Returns the layout maximum width.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmaxwidth FLOAT GetMaxWidth();
		[PreserveSig]
		new float GetMaxWidth();

		/// <summary>Gets the layout maximum height.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The layout maximum height.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmaxheight FLOAT GetMaxHeight();
		[PreserveSig]
		new float GetMaxHeight();

		/// <summary>Gets the font collection associated with the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>Contains an address of a pointer to the current font collection.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the underline.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontcollection HRESULT
		// GetFontCollection( UINT32 currentPosition, IDWriteFontCollection **fontCollection, DWRITE_TEXT_RANGE *textRange );
		new void GetFontCollection(uint currentPosition, out IDWriteFontCollection fontCollection, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Get the length of the font family name at the current position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The current text position.</para>
		/// </param>
		/// <param name="nameLength">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// When this method returns, contains the size of the character array containing the font family name, in character count, not
		/// including the terminated <c>NULL</c> character.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font family.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontfamilynamelength HRESULT
		// GetFontFamilyNameLength( UINT32 currentPosition, UINT32 *nameLength, DWRITE_TEXT_RANGE *textRange );
		new void GetFontFamilyNameLength(uint currentPosition, out uint nameLength, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Copies the font family name of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to examine.</para>
		/// </param>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// When this method returns, contains an array of characters that receives the current font family name. You must allocate storage
		/// for this parameter.
		/// </para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array in character count including the terminated <c>NULL</c> character.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font family name.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontfamilyname HRESULT
		// GetFontFamilyName( UINT32 currentPosition, WCHAR *fontFamilyName, UINT32 nameSize, DWRITE_TEXT_RANGE *textRange );
		new void GetFontFamilyName(uint currentPosition, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder fontFamilyName, uint nameSize, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font weight of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontWeight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT*</c></para>
		/// <para>When this method returns, contains a value which indicates the type of font weight being applied at the specified position.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font weight.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontweight HRESULT GetFontWeight( UINT32
		// currentPosition, DWRITE_FONT_WEIGHT *fontWeight, DWRITE_TEXT_RANGE *textRange );
		new void GetFontWeight(uint currentPosition, out DWRITE_FONT_WEIGHT fontWeight, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font style (also known as slope) of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontStyle">
		/// <para>Type: <c>DWRITE_FONT_STYLE*</c></para>
		/// <para>
		/// When this method returns, contains a value which indicates the type of font style (also known as slope or incline) being applied
		/// at the specified position.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font style.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontstyle HRESULT GetFontStyle( UINT32
		// currentPosition, DWRITE_FONT_STYLE *fontStyle, DWRITE_TEXT_RANGE *textRange );
		new void GetFontStyle(uint currentPosition, out DWRITE_FONT_STYLE fontStyle, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font stretch of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontStretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH*</c></para>
		/// <para>
		/// When this method returns, contains a value which indicates the type of font stretch (also known as width) being applied at the
		/// specified position.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font stretch.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontstretch HRESULT GetFontStretch(
		// UINT32 currentPosition, DWRITE_FONT_STRETCH *fontStretch, DWRITE_TEXT_RANGE *textRange );
		new void GetFontStretch(uint currentPosition, out DWRITE_FONT_STRETCH fontStretch, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font em height of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontSize">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the size of the font in ems of the text at the specified position.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font size.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontsize HRESULT GetFontSize( UINT32
		// currentPosition, FLOAT *fontSize, DWRITE_TEXT_RANGE *textRange );
		new void GetFontSize(uint currentPosition, out float fontSize, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the underline presence of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The current text position.</para>
		/// </param>
		/// <param name="hasUnderline">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>A Boolean flag that indicates whether underline is present at the position indicated by currentPosition.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the underline.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getunderline HRESULT GetUnderline( UINT32
		// currentPosition, BOOL *hasUnderline, DWRITE_TEXT_RANGE *textRange );
		new void GetUnderline(uint currentPosition, [MarshalAs(UnmanagedType.Bool)] out bool hasUnderline, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Get the strikethrough presence of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="hasStrikethrough">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>A Boolean flag that indicates whether strikethrough is present at the position indicated by currentPosition.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// Contains the range of text that has the same formatting as the text at the position specified by currentPosition. This means the
		/// run has the exact formatting as the position specified, including but not limited to strikethrough.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getstrikethrough HRESULT GetStrikethrough(
		// UINT32 currentPosition, BOOL *hasStrikethrough, DWRITE_TEXT_RANGE *textRange );
		new void GetStrikethrough(uint currentPosition, [MarshalAs(UnmanagedType.Bool)] out bool hasStrikethrough, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the application-defined drawing effect at the specified text position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text whose drawing effect is to be retrieved.</para>
		/// </param>
		/// <param name="drawingEffect">
		/// <para>Type: <c>IUnknown**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the current application-defined drawing effect. Usually this
		/// effect is a foreground brush that is used in glyph drawing.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// Contains the range of text that has the same formatting as the text at the position specified by currentPosition. This means the
		/// run has the exact formatting as the position specified, including but not limited to the drawing effect.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getdrawingeffect HRESULT GetDrawingEffect(
		// UINT32 currentPosition, IUnknown **drawingEffect, DWRITE_TEXT_RANGE *textRange );
		new void GetDrawingEffect(uint currentPosition, [MarshalAs(UnmanagedType.Interface)] out object drawingEffect, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the inline object at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The specified text position.</para>
		/// </param>
		/// <param name="inlineObject">
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>Contains the application-defined inline object.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the inline object.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getinlineobject HRESULT GetInlineObject(
		// UINT32 currentPosition, IDWriteInlineObject **inlineObject, DWRITE_TEXT_RANGE *textRange );
		new void GetInlineObject(uint currentPosition, out IDWriteInlineObject inlineObject, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the typography setting of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="typography">
		/// <para>Type: <c>IDWriteTypography**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the current typography setting.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the typography.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-gettypography HRESULT GetTypography( UINT32
		// currentPosition, IDWriteTypography **typography, DWRITE_TEXT_RANGE *textRange );
		new void GetTypography(uint currentPosition, out IDWriteTypography typography, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the length of the locale name of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="nameLength">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>Size of the character array, in character count, not including the terminated <c>NULL</c> character.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the locale name.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getlocalenamelength HRESULT
		// GetLocaleNameLength( UINT32 currentPosition, UINT32 *nameLength, DWRITE_TEXT_RANGE *textRange );
		new void GetLocaleNameLength(uint currentPosition, out uint nameLength, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the locale name of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>When this method returns, contains the character array receiving the current locale name.</para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Size of the character array, in character count, including the terminated <c>NULL</c> character.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the locale name.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getlocalename HRESULT GetLocaleName( UINT32
		// currentPosition, WCHAR *localeName, UINT32 nameSize, DWRITE_TEXT_RANGE *textRange );
		new void GetLocaleName(uint currentPosition, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder localeName, uint nameSize, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Draws text using the specified client drawing context.</summary>
		/// <param name="clientDrawingContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>An application-defined drawing context.</para>
		/// </param>
		/// <param name="renderer">
		/// <para>Type: <c>IDWriteTextRenderer*</c></para>
		/// <para>Pointer to the set of callback functions used to draw parts of a text string.</para>
		/// </param>
		/// <param name="originX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The x-coordinate of the layout's left side.</para>
		/// </param>
		/// <param name="originY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate of the layout's top side.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>To draw text with this method, a textLayout object needs to be created by the application using IDWriteFactory::CreateTextLayout.</para>
		/// <para>
		/// After the textLayout object is obtained, the application calls the <c>IDWriteTextLayout::Draw</c> method to draw the text,
		/// decorations, and inline objects. The actual drawing is done through the callback interface passed in as the textRenderer
		/// argument; there, the corresponding DrawGlyphRun API is called.
		/// </para>
		/// <para>
		/// If you set a vertical text reading direction on IDWriteTextLayout via SetReadingDirection with
		/// DWRITE_READING_DIRECTION_TOP_TO_BOTTOM (or bottom to top), then you must pass an interface that implements IDWriteTextRenderer1.
		/// Otherwise you get the error DWRITE_E_TEXTRENDERERINCOMPATIBLE because the original IDWriteTextRenderer interface only supported
		/// horizontal text.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-draw HRESULT Draw( void
		// *clientDrawingContext, IDWriteTextRenderer *renderer, FLOAT originX, FLOAT originY );
		new void Draw([In, Optional] IntPtr clientDrawingContext, [In] IDWriteTextRenderer renderer, float originX, float originY);

		/// <summary>Retrieves the information about each individual text line of the text string.</summary>
		/// <param name="lineMetrics">
		/// <para>Type: <c>DWRITE_LINE_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to an array of structures containing various calculated length values of individual
		/// text lines.
		/// </para>
		/// </param>
		/// <param name="maxLineCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The maximum size of the lineMetrics array.</para>
		/// </param>
		/// <param name="actualLineCount">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains the actual size of the lineMetricsarray that is needed.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// If maxLineCount is not large enough E_NOT_SUFFICIENT_BUFFER, which is equivalent to
		/// HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER), is returned and *actualLineCount is set to the number of lines needed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getlinemetrics HRESULT GetLineMetrics(
		// DWRITE_LINE_METRICS *lineMetrics, UINT32 maxLineCount, UINT32 *actualLineCount );
		new void GetLineMetrics([Out, Optional, MarshalAs(UnmanagedType.LPArray)] DWRITE_LINE_METRICS[]? lineMetrics, uint maxLineCount, out uint actualLineCount);

		/// <summary>Retrieves overall metrics for the formatted string.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_TEXT_METRICS*</c></para>
		/// <para>When this method returns, contains the measured distances of text and associated content after being formatted.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmetrics HRESULT GetMetrics(
		// DWRITE_TEXT_METRICS *textMetrics );
		new DWRITE_TEXT_METRICS GetMetrics();

		/// <summary>
		/// Returns the overhangs (in DIPs) of the layout and all objects contained in it, including text glyphs and inline objects.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_OVERHANG_METRICS*</c></para>
		/// <para>Overshoots of visible extents (in DIPs) outside the layout.</para>
		/// </returns>
		/// <remarks>
		/// Underlines and strikethroughs do not contribute to the black box determination, since these are actually drawn by the renderer,
		/// which is allowed to draw them in any variety of styles.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getoverhangmetrics HRESULT
		// GetOverhangMetrics( DWRITE_OVERHANG_METRICS *overhangs );
		new DWRITE_OVERHANG_METRICS GetOverhangMetrics();

		/// <summary>Retrieves logical properties and measurements of each glyph cluster.</summary>
		/// <param name="clusterMetrics">
		/// <para>Type: <c>DWRITE_CLUSTER_METRICS*</c></para>
		/// <para>When this method returns, contains metrics, such as line-break or total advance width, for a glyph cluster.</para>
		/// </param>
		/// <param name="maxClusterCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The maximum size of the clusterMetrics array.</para>
		/// </param>
		/// <param name="actualClusterCount">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains the actual size of the clusterMetrics array that is needed.</para>
		/// </param>
		/// <remarks>
		/// If maxClusterCount is not large enough, then E_NOT_SUFFICIENT_BUFFER, which is equivalent to
		/// HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER), is returned and actualClusterCount is set to the number of clusters needed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getclustermetrics HRESULT
		// GetClusterMetrics( DWRITE_CLUSTER_METRICS *clusterMetrics, UINT32 maxClusterCount, UINT32 *actualClusterCount );
		new void GetClusterMetrics([Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_CLUSTER_METRICS[]? clusterMetrics, uint maxClusterCount, out uint actualClusterCount);

		/// <summary>
		/// Determines the minimum possible width the layout can be set to without emergency breaking between the characters of whole words occurring.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>Minimum width.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-determineminwidth HRESULT
		// DetermineMinWidth( FLOAT *minWidth );
		new float DetermineMinWidth();

		/// <summary>
		/// The application calls this function passing in a specific pixel location relative to the top-left location of the layout box and
		/// obtains the information about the correspondent hit-test metrics of the text string where the hit-test has occurred. When the
		/// specified pixel location is outside the text string, the function sets the output value *isInside to <c>FALSE</c>.
		/// </summary>
		/// <param name="pointX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The pixel location X to hit-test, relative to the top-left location of the layout box.</para>
		/// </param>
		/// <param name="pointY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The pixel location Y to hit-test, relative to the top-left location of the layout box.</para>
		/// </param>
		/// <param name="isTrailingHit">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// An output flag that indicates whether the hit-test location is at the leading or the trailing side of the character. When the
		/// output *isInside value is set to <c>FALSE</c>, this value is set according to the output hitTestMetrics-&gt;textPosition value
		/// to represent the edge closest to the hit-test location.
		/// </para>
		/// </param>
		/// <param name="isInside">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// An output flag that indicates whether the hit-test location is inside the text string. When <c>FALSE</c>, the position nearest
		/// the text's edge is returned.
		/// </para>
		/// </param>
		/// <param name="hitTestMetrics">
		/// <para>Type: <c>DWRITE_HIT_TEST_METRICS*</c></para>
		/// <para>
		/// The output geometry fully enclosing the hit-test location. When the output *isInside value is set to <c>FALSE</c>, this
		/// structure represents the geometry enclosing the edge closest to the hit-test location.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-hittestpoint HRESULT HitTestPoint( FLOAT
		// pointX, FLOAT pointY, BOOL *isTrailingHit, BOOL *isInside, DWRITE_HIT_TEST_METRICS *hitTestMetrics );
		new void HitTestPoint(float pointX, float pointY, [MarshalAs(UnmanagedType.Bool)] out bool isTrailingHit,
			[MarshalAs(UnmanagedType.Bool)] out bool isInside, out DWRITE_HIT_TEST_METRICS hitTestMetrics);

		/// <summary>
		/// The application calls this function to get the pixel location relative to the top-left of the layout box given the text position
		/// and the logical side of the position. This function is normally used as part of caret positioning of text where the caret is
		/// drawn at the location corresponding to the current text editing position. It may also be used as a way to programmatically
		/// obtain the geometry of a particular text position in UI automation.
		/// </summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The text position used to get the pixel location.</para>
		/// </param>
		/// <param name="isTrailingHit">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A Boolean flag that indicates whether the pixel location is of the leading or the trailing side of the specified text position.
		/// </para>
		/// </param>
		/// <param name="pointX">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the output pixel location X, relative to the top-left location of the layout box.</para>
		/// </param>
		/// <param name="pointY">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the output pixel location Y, relative to the top-left location of the layout box.</para>
		/// </param>
		/// <param name="hitTestMetrics">
		/// <para>Type: <c>DWRITE_HIT_TEST_METRICS*</c></para>
		/// <para>When this method returns, contains the output geometry fully enclosing the specified text position.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-hittesttextposition HRESULT
		// HitTestTextPosition( UINT32 textPosition, BOOL isTrailingHit, FLOAT *pointX, FLOAT *pointY, DWRITE_HIT_TEST_METRICS
		// *hitTestMetrics );
		new void HitTestTextPosition(uint textPosition, [MarshalAs(UnmanagedType.Bool)] bool isTrailingHit, out float pointX, out float pointY,
			out DWRITE_HIT_TEST_METRICS hitTestMetrics);

		/// <summary>
		/// <para>
		/// The application calls this function to get a set of hit-test metrics corresponding to a range of text positions. One of the main
		/// usages is to implement highlight selection of the text string.
		/// </para>
		/// <para>
		/// The function returns E_NOT_SUFFICIENT_BUFFER, which is equivalent to HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER), when the
		/// buffer size of hitTestMetrics is too small to hold all the regions calculated by the function. In this situation, the function
		/// sets the output value *actualHitTestMetricsCount to the number of geometries calculated.
		/// </para>
		/// <para>The application is responsible for allocating a new buffer of greater size and calling the function again.</para>
		/// <para>A good value to use as an initial value for maxHitTestMetricsCount may be calculated from the following equation:</para>
		/// <para>
		/// where lineCount is obtained from the value of the output argument *actualLineCount (from the function
		/// IDWriteTextLayout::GetLineLengths), and the maxBidiReorderingDepth value from the DWRITE_TEXT_METRICSstructure of the output
		/// argument *textMetrics (from the function IDWriteFactory::CreateTextLayout).
		/// </para>
		/// </summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The first text position of the specified range.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of positions of the specified range.</para>
		/// </param>
		/// <param name="originX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The origin pixel location X at the left of the layout box. This offset is added to the hit-test metrics returned.</para>
		/// </param>
		/// <param name="originY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The origin pixel location Y at the top of the layout box. This offset is added to the hit-test metrics returned.</para>
		/// </param>
		/// <param name="hitTestMetrics">
		/// <para>Type: <c>DWRITE_HIT_TEST_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a buffer of the output geometry fully enclosing the specified position range.
		/// The buffer must be at least as large as maxHitTestMetricsCount.
		/// </para>
		/// </param>
		/// <param name="maxHitTestMetricsCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Maximum number of boxes hitTestMetrics could hold in its buffer memory.</para>
		/// </param>
		/// <param name="actualHitTestMetricsCount">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>Actual number of geometries hitTestMetrics holds in its buffer memory.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-hittesttextrange HRESULT HitTestTextRange(
		// UINT32 textPosition, UINT32 textLength, FLOAT originX, FLOAT originY, DWRITE_HIT_TEST_METRICS
		// *hitTestMetrics, UINT32 maxHitTestMetricsCount, UINT32 *actualHitTestMetricsCount );
		new void HitTestTextRange(uint textPosition, uint textLength, float originX, float originY,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] DWRITE_HIT_TEST_METRICS[]? hitTestMetrics,
			uint maxHitTestMetricsCount, out uint actualHitTestMetricsCount);

		/// <summary>Enables or disables pair-kerning on a given text range.</summary>
		/// <param name="isPairKerningEnabled">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>The flag that indicates whether text is pair-kerned.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <b><c>DWRITE_TEXT_RANGE</c></b></para>
		/// <para>The text range to which the change applies.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextlayout1-setpairkerning HRESULT
		// SetPairKerning( BOOL isPairKerningEnabled, DWRITE_TEXT_RANGE textRange );
		new void SetPairKerning(bool isPairKerningEnabled, DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets whether or not pair-kerning is enabled at given position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The current text position.</para>
		/// </param>
		/// <param name="isPairKerningEnabled">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>The flag that indicates whether text is pair-kerned.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <b><c>DWRITE_TEXT_RANGE</c>*</b></para>
		/// <para>The position range of the current format.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextlayout1-getpairkerning HRESULT
		// GetPairKerning( UINT32 currentPosition, [out] BOOL *isPairKerningEnabled, [out, optional] DWRITE_TEXT_RANGE *textRange );
		new void GetPairKerning(uint currentPosition, out bool isPairKerningEnabled, [Out, Optional] StructPointer<DWRITE_TEXT_RANGE> textRange);

		/// <summary>Sets the spacing between characters.</summary>
		/// <param name="leadingSpacing">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The spacing before each character, in reading order.</para>
		/// </param>
		/// <param name="trailingSpacing">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The spacing after each character, in reading order.</para>
		/// </param>
		/// <param name="minimumAdvanceWidth">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The minimum advance of each character, to prevent characters from becoming too thin or zero-width. This must be zero or greater.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <b><c>DWRITE_TEXT_RANGE</c></b></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextlayout1-setcharacterspacing HRESULT
		// SetCharacterSpacing( FLOAT leadingSpacing, FLOAT trailingSpacing, FLOAT minimumAdvanceWidth, DWRITE_TEXT_RANGE textRange );
		new void SetCharacterSpacing(float leadingSpacing, float trailingSpacing, float minimumAdvanceWidth, DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the spacing between characters.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The current text position.</para>
		/// </param>
		/// <param name="leadingSpacing">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>The spacing before each character, in reading order.</para>
		/// </param>
		/// <param name="trailingSpacing">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>The spacing after each character, in reading order.</para>
		/// </param>
		/// <param name="minimumAdvanceWidth">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>
		/// The minimum advance of each character, to prevent characters from becoming too thin or zero-width. This must be zero or greater.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <b><c>DWRITE_TEXT_RANGE</c>*</b></para>
		/// <para>The position range of the current format.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextlayout1-getcharacterspacing HRESULT
		// GetCharacterSpacing( UINT32 currentPosition, [out] FLOAT *leadingSpacing, [out] FLOAT *trailingSpacing, [out] FLOAT
		// *minimumAdvanceWidth, [out, optional] DWRITE_TEXT_RANGE *textRange );
		new void GetCharacterSpacing(uint currentPosition, out float leadingSpacing, out float trailingSpacing, out float minimumAdvanceWidth,
			[Out, Optional] StructPointer<DWRITE_TEXT_RANGE> textRange);

		/// <summary><c>textMetrics</c></summary>
		/// <param name="textMetrics"/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_2/nf-dwrite_2-idwritetextlayout2-getmetrics HRESULT
		// GetMetrics( DWRITE_TEXT_METRICS1 *textMetrics );
		new void GetMetrics(out DWRITE_TEXT_METRICS1 textMetrics);

		/// <summary>Set the preferred orientation of glyphs when using a vertical reading direction.</summary>
		/// <param name="glyphOrientation">Preferred glyph orientation.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-setverticalglyphorientation HRESULT
		// SetVerticalGlyphOrientation( DWRITE_VERTICAL_GLYPH_ORIENTATION glyphOrientation );
		new void SetVerticalGlyphOrientation(DWRITE_VERTICAL_GLYPH_ORIENTATION glyphOrientation);

		/// <summary>Get the preferred orientation of glyphs when using a vertical reading direction.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-getverticalglyphorientation
		// DWRITE_VERTICAL_GLYPH_ORIENTATION GetVerticalGlyphOrientation();
		[PreserveSig]
		new DWRITE_VERTICAL_GLYPH_ORIENTATION GetVerticalGlyphOrientation();

		/// <summary>Set whether or not the last word on the last line is wrapped.</summary>
		/// <param name="isLastLineWrappingEnabled">Line wrapping option.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-setlastlinewrapping HRESULT
		// SetLastLineWrapping( BOOL isLastLineWrappingEnabled );
		new void SetLastLineWrapping(bool isLastLineWrappingEnabled);

		/// <summary>Get whether or not the last word on the last line is wrapped.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-getlastlinewrapping BOOL GetLastLineWrapping();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool GetLastLineWrapping();

		/// <summary>
		/// Set how the glyphs align to the edges the margin. Default behavior is to align glyphs using their default glyphs metrics, which
		/// include side bearings.
		/// </summary>
		/// <param name="opticalAlignment">Optical alignment option.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-setopticalalignment HRESULT
		// SetOpticalAlignment( DWRITE_OPTICAL_ALIGNMENT opticalAlignment );
		new void SetOpticalAlignment(DWRITE_OPTICAL_ALIGNMENT opticalAlignment);

		/// <summary>Get how the glyphs align to the edges the margin.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-getopticalalignment
		// DWRITE_OPTICAL_ALIGNMENT GetOpticalAlignment();
		[PreserveSig]
		new DWRITE_OPTICAL_ALIGNMENT GetOpticalAlignment();

		/// <summary>Apply a custom font fallback onto layout. If none is specified, the layout uses the system fallback list.</summary>
		/// <param name="fontFallback">Custom font fallback created from <c>IDWriteFontFallbackBuilder::CreateFontFallback</c> or <c>IDWriteFactory2::GetSystemFontFallback</c>.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-setfontfallback HRESULT
		// SetFontFallback( IDWriteFontFallback *fontFallback );
		new void SetFontFallback([In] IDWriteFontFallback fontFallback);

		/// <summary>Get the current font fallback object.</summary>
		/// <returns>The current font fallback object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-getfontfallback HRESULT
		// GetFontFallback( [out] IDWriteFontFallback **fontFallback );
		new IDWriteFontFallback GetFontFallback();

		/// <summary>
		/// Invalidates the layout, forcing layout to remeasure before calling the metrics or drawing functions. This is useful if the
		/// locality of a font changes, and layout should be redrawn, or if the size of a client implemented IDWriteInlineObject changes.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritetextlayout3-invalidatelayout HRESULT InvalidateLayout();
		void InvalidateLayout();

		/// <summary>Set line spacing.</summary>
		/// <param name="lineSpacingOptions">How to manage space between lines.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritetextlayout3-setlinespacing HRESULT
		// SetLineSpacing( [in] DWRITE_LINE_SPACING const *lineSpacingOptions );
		void SetLineSpacing(in DWRITE_LINE_SPACING lineSpacingOptions);

		/// <summary>Gets line spacing information.</summary>
		/// <returns>How to manage space between lines.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritetextlayout3-getlinespacing HRESULT
		// GetLineSpacing( [out] DWRITE_LINE_SPACING *lineSpacingOptions );
		DWRITE_LINE_SPACING GetLineSpacing();

		/// <summary>Retrieves properties of each line.</summary>
		/// <param name="lineMetrics">The array to fill with line information.</param>
		/// <param name="maxLineCount">The maximum size of the lineMetrics array.</param>
		/// <param name="actualLineCount">The actual size of the lineMetrics array that is needed.</param>
		/// <returns>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
		/// <remarks>
		/// If maxLineCount is not large enough E_NOT_SUFFICIENT_BUFFER, which is equivalent to
		/// HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER), is returned and actualLineCount is set to the number of lines needed.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritetextlayout3-getlinemetrics HRESULT
		// GetLineMetrics( [out] DWRITE_LINE_METRICS1 *lineMetrics, UINT32 maxLineCount, [out] UINT32 *actualLineCount );
		[PreserveSig]
		HRESULT GetLineMetrics([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_LINE_METRICS1[] lineMetrics, uint maxLineCount, out uint actualLineCount);
	}

	/// <summary>The <b>IDWriteTextLayout4</b> interface inherits from the IDWriteTextLayout3 interface.</summary>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nn-dwrite_3-idwritetextlayout4
	[PInvokeData("dwrite_3.h", MSDNShortId = "NN:dwrite_3.IDWriteTextLayout4")]
	[ComImport, Guid("05A9BF42-223F-4441-B5FB-8263685F55E9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteTextLayout4 : IDWriteTextFormat, IDWriteTextLayout, IDWriteTextLayout1, IDWriteTextLayout2, IDWriteTextLayout3
	{
		/// <summary>
		/// Sets the alignment of text in a paragraph, relative to the leading and trailing edge of a layout box for a IDWriteTextFormat interface.
		/// </summary>
		/// <param name="textAlignment">
		/// <para>Type: <c>DWRITE_TEXT_ALIGNMENT</c></para>
		/// <para>The text alignment option being set for the paragraph of type DWRITE_TEXT_ALIGNMENT. For more information, see Remarks.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The text can be aligned to the leading or trailing edge of the layout box, or it can be centered. The following illustration
		/// shows text with the alignment set to DWRITE_TEXT_ALIGNMENT_LEADING, <c>DWRITE_TEXT_ALIGNMENT_CENTER</c>, and
		/// <c>DWRITE_TEXT_ALIGNMENT_TRAILING</c>, respectively.
		/// </para>
		/// <para>
		/// <c>Note</c> The alignment is dependent on reading direction, the above is for left-to-right reading direction. For right-to-left
		/// reading direction it would be the opposite.
		/// </para>
		/// <para>See DWRITE_TEXT_ALIGNMENT for more information.</para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settextalignment HRESULT SetTextAlignment(
		// DWRITE_TEXT_ALIGNMENT textAlignment );
		new void SetTextAlignment(DWRITE_TEXT_ALIGNMENT textAlignment);

		/// <summary>Sets the alignment option of a paragraph relative to the layout box's top and bottom edge.</summary>
		/// <param name="paragraphAlignment">
		/// <para>Type: <c>DWRITE_PARAGRAPH_ALIGNMENT</c></para>
		/// <para>The paragraph alignment option being set for a paragraph; see DWRITE_PARAGRAPH_ALIGNMENT for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setparagraphalignment HRESULT
		// SetParagraphAlignment( DWRITE_PARAGRAPH_ALIGNMENT paragraphAlignment );
		new void SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT paragraphAlignment);

		/// <summary>Sets the word wrapping option.</summary>
		/// <param name="wordWrapping">
		/// <para>Type: <c>DWRITE_WORD_WRAPPING</c></para>
		/// <para>The word wrapping option being set for a paragraph; see DWRITE_WORD_WRAPPING for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setwordwrapping HRESULT SetWordWrapping(
		// DWRITE_WORD_WRAPPING wordWrapping );
		new void SetWordWrapping(DWRITE_WORD_WRAPPING wordWrapping);

		/// <summary>Sets the paragraph reading direction.</summary>
		/// <param name="readingDirection">
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>
		/// The text reading direction (for example, DWRITE_READING_DIRECTION_RIGHT_TO_LEFT for languages, such as Arabic, that read from
		/// right to left) for a paragraph.
		/// </para>
		/// </param>
		/// <remarks>
		/// The reading direction and flow direction must always be set 90 degrees orthogonal to each other, or else you will get the error
		/// DWRITE_E_FLOWDIRECTIONCONFLICTS when you use layout functions like Draw or GetMetrics. So if you set a vertical reading
		/// direction (for example, to DWRITE_READING_DIRECTION_TOP_TO_BOTTOM), then you must also use SetFlowDirection to set the flow
		/// direction appropriately (for example, to DWRITE_FLOW_DIRECTION_RIGHT_TO_LEFT).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setreadingdirection HRESULT
		// SetReadingDirection( DWRITE_READING_DIRECTION readingDirection );
		new void SetReadingDirection(DWRITE_READING_DIRECTION readingDirection);

		/// <summary>Sets the paragraph flow direction.</summary>
		/// <param name="flowDirection">
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>The paragraph flow direction; see DWRITE_FLOW_DIRECTION for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setflowdirection HRESULT SetFlowDirection(
		// DWRITE_FLOW_DIRECTION flowDirection );
		new void SetFlowDirection(DWRITE_FLOW_DIRECTION flowDirection);

		/// <summary>Sets a fixed distance between two adjacent tab stops.</summary>
		/// <param name="incrementalTabStop">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The fixed distance between two adjacent tab stops.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setincrementaltabstop HRESULT
		// SetIncrementalTabStop( FLOAT incrementalTabStop );
		new void SetIncrementalTabStop(float incrementalTabStop);

		/// <summary>Sets trimming options for text overflowing the layout width.</summary>
		/// <param name="trimmingOptions">
		/// <para>Type: <c>const DWRITE_TRIMMING*</c></para>
		/// <para>Text trimming options.</para>
		/// </param>
		/// <param name="trimmingSign">
		/// <para>Type: <c>IDWriteInlineObject*</c></para>
		/// <para>Application-defined omission sign. This parameter may be <c>NULL</c>. See IDWriteInlineObject for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settrimming HRESULT SetTrimming(
		// DWRITE_TRIMMING const *trimmingOptions, IDWriteInlineObject *trimmingSign );
		new void SetTrimming(in DWRITE_TRIMMING trimmingOptions, [In, Optional] IDWriteInlineObject? trimmingSign);

		/// <summary>Sets the line spacing.</summary>
		/// <param name="lineSpacingMethod">
		/// <para>Type: <c>DWRITE_LINE_SPACING_METHOD</c></para>
		/// <para>Specifies how line height is being determined; see DWRITE_LINE_SPACING_METHOD for more information.</para>
		/// </param>
		/// <param name="lineSpacing">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The line height, or distance between one baseline to another.</para>
		/// </param>
		/// <param name="baseline">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The distance from top of line to baseline. A reasonable ratio to lineSpacing is 80 percent.</para>
		/// </param>
		/// <remarks>
		/// For the default method, spacing depends solely on the content. For uniform spacing, the specified line height overrides the content.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setlinespacing HRESULT SetLineSpacing(
		// DWRITE_LINE_SPACING_METHOD lineSpacingMethod, FLOAT lineSpacing, FLOAT baseline );
		new void SetLineSpacing(DWRITE_LINE_SPACING_METHOD lineSpacingMethod, float lineSpacing, float baseline);

		/// <summary>Gets the alignment option of text relative to the layout box's leading and trailing edge.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_TEXT_ALIGNMENT</c></para>
		/// <para>Returns the text alignment option of the current paragraph.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-gettextalignment DWRITE_TEXT_ALIGNMENT GetTextAlignment();
		[PreserveSig]
		new DWRITE_TEXT_ALIGNMENT GetTextAlignment();

		/// <summary>Gets the alignment option of a paragraph which is relative to the top and bottom edges of a layout box.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_PARAGRAPH_ALIGNMENT</c></para>
		/// <para>A value that indicates the current paragraph alignment option.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getparagraphalignment
		// DWRITE_PARAGRAPH_ALIGNMENT GetParagraphAlignment();
		[PreserveSig]
		new DWRITE_PARAGRAPH_ALIGNMENT GetParagraphAlignment();

		/// <summary>Gets the word wrapping option.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_WORD_WRAPPING</c></para>
		/// <para>Returns the word wrapping option; see DWRITE_WORD_WRAPPING for more information.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getwordwrapping DWRITE_WORD_WRAPPING GetWordWrapping();
		[PreserveSig]
		new DWRITE_WORD_WRAPPING GetWordWrapping();

		/// <summary>Gets the current reading direction for text in a paragraph.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>A value that indicates the current reading direction for text in a paragraph.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getreadingdirection
		// DWRITE_READING_DIRECTION GetReadingDirection();
		[PreserveSig]
		new DWRITE_READING_DIRECTION GetReadingDirection();

		/// <summary>Gets the direction that text lines flow.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>
		/// The direction that text lines flow within their parent container. For example, DWRITE_FLOW_DIRECTION_TOP_TO_BOTTOM indicates
		/// that text lines are placed from top to bottom.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getflowdirection DWRITE_FLOW_DIRECTION GetFlowDirection();
		[PreserveSig]
		new DWRITE_FLOW_DIRECTION GetFlowDirection();

		/// <summary>Gets the incremental tab stop position.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The incremental tab stop value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getincrementaltabstop FLOAT GetIncrementalTabStop();
		[PreserveSig]
		new float GetIncrementalTabStop();

		/// <summary>Gets the trimming options for text that overflows the layout box.</summary>
		/// <param name="trimmingOptions">
		/// <para>Type: <c>DWRITE_TRIMMING*</c></para>
		/// <para>
		/// When this method returns, it contains a pointer to a DWRITE_TRIMMING structure that holds the text trimming options for the
		/// overflowing text.
		/// </para>
		/// </param>
		/// <param name="trimmingSign">
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>When this method returns, contains an address of a pointer to a trimming omission sign. This parameter may be <c>NULL</c>.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-gettrimming HRESULT GetTrimming(
		// DWRITE_TRIMMING *trimmingOptions, IDWriteInlineObject **trimmingSign );
		new void GetTrimming(out DWRITE_TRIMMING trimmingOptions, out IDWriteInlineObject trimmingSign);

		/// <summary>Gets the line spacing adjustment set for a multiline text paragraph.</summary>
		/// <param name="lineSpacingMethod">
		/// <para>Type: <c>DWRITE_LINE_SPACING_METHOD*</c></para>
		/// <para>A value that indicates how line height is determined.</para>
		/// </param>
		/// <param name="lineSpacing">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the line height, or distance between one baseline to another.</para>
		/// </param>
		/// <param name="baseline">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>
		/// When this method returns, contains the distance from top of line to baseline. A reasonable ratio to lineSpacing is 80 percent.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlinespacing HRESULT GetLineSpacing(
		// DWRITE_LINE_SPACING_METHOD *lineSpacingMethod, FLOAT *lineSpacing, FLOAT *baseline );
		new void GetLineSpacing(out DWRITE_LINE_SPACING_METHOD lineSpacingMethod, out float lineSpacing, out float baseline);

		/// <summary>Gets the current font collection.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the font collection being used for the current text.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontcollection HRESULT
		// GetFontCollection( IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection GetFontCollection();

		/// <summary>Gets the length of the font family name.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array, in character count, not including the terminated <c>NULL</c> character.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontfamilynamelength UINT32 GetFontFamilyNameLength();
		[PreserveSig]
		new uint GetFontFamilyNameLength();

		/// <summary>Gets a copy of the font family name.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a character array, which is null-terminated, that receives the current font
		/// family name. The buffer allocated for this array should be at least the size, in elements, of nameSize.
		/// </para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The size of the fontFamilyName character array, in character count, including the terminated <c>NULL</c> character. To find the
		/// size of fontFamilyName, use GetFontFamilyNameLength.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontfamilyname HRESULT
		// GetFontFamilyName( WCHAR *fontFamilyName, UINT32 nameSize );
		new void GetFontFamilyName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder fontFamilyName, uint nameSize);

		/// <summary>Gets the font weight of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that indicates the type of weight (such as normal, bold, or black).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontweight DWRITE_FONT_WEIGHT GetFontWeight();
		[PreserveSig]
		new DWRITE_FONT_WEIGHT GetFontWeight();

		/// <summary>Gets the font style of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value which indicates the type of font style (such as slope or incline).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontstyle DWRITE_FONT_STYLE GetFontStyle();
		[PreserveSig]
		new DWRITE_FONT_STYLE GetFontStyle();

		/// <summary>Gets the font stretch of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value which indicates the type of font stretch (such as normal or condensed).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontstretch DWRITE_FONT_STRETCH GetFontStretch();
		[PreserveSig]
		new DWRITE_FONT_STRETCH GetFontStretch();

		/// <summary>Gets the font size in DIP unites.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The current font size in DIP units.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontsize FLOAT GetFontSize();
		[PreserveSig]
		new float GetFontSize();

		/// <summary>Gets the length of the locale name.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array in character count, not including the terminated <c>NULL</c> character.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalenamelength UINT32 GetLocaleNameLength();
		[PreserveSig]
		new uint GetLocaleNameLength();

		/// <summary>Gets a copy of the locale name.</summary>
		/// <param name="localeName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Contains a character array that receives the current locale name.</para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The size of the character array, in character count, including the terminated <c>NULL</c> character. Use GetLocaleNameLength to
		/// get the size of the locale name character array.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalename HRESULT GetLocaleName( WCHAR
		// *localeName, UINT32 nameSize );
		new void GetLocaleName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder localeName, uint nameSize);

		/// <summary>Sets the layout maximum width.</summary>
		/// <param name="maxWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the maximum width of the layout box.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setmaxwidth HRESULT SetMaxWidth( FLOAT
		// maxWidth );
		new void SetMaxWidth(float maxWidth);

		/// <summary>Sets the layout maximum height.</summary>
		/// <param name="maxHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the maximum height of the layout box.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setmaxheight HRESULT SetMaxHeight( FLOAT
		// maxHeight );
		new void SetMaxHeight(float maxHeight);

		/// <summary>Sets the font collection.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection*</c></para>
		/// <para>The font collection to set.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontcollection HRESULT
		// SetFontCollection( IDWriteFontCollection *fontCollection, DWRITE_TEXT_RANGE textRange );
		new void SetFontCollection([In] IDWriteFontCollection fontCollection, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets null-terminated font family name for text within a specified text range.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>The font family name that applies to the entire text string within the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontfamilyname HRESULT
		// SetFontFamilyName( WCHAR const *fontFamilyName, DWRITE_TEXT_RANGE textRange );
		new void SetFontFamilyName([MarshalAs(UnmanagedType.LPWStr)] string fontFamilyName, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the font weight for text within a text range specified by a DWRITE_TEXT_RANGE structure.</summary>
		/// <param name="fontWeight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>The font weight to be set for text within the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The font weight can be set to one of the predefined font weight values provided in the DWRITE_FONT_WEIGHT enumeration or an
		/// integer from 1 to 999. Values outside this range will cause the method to fail with an <c>E_INVALIDARG</c> return value.
		/// </para>
		/// <para>The following illustration shows an example of Normal and UltraBold weights for the Palatino Linotype typeface.</para>
		/// <para>Examples</para>
		/// <para>The following code illustrates how to set the font weight to bold.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontweight HRESULT SetFontWeight(
		// DWRITE_FONT_WEIGHT fontWeight, DWRITE_TEXT_RANGE textRange );
		new void SetFontWeight(DWRITE_FONT_WEIGHT fontWeight, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the font style for text within a text range specified by a DWRITE_TEXT_RANGE structure.</summary>
		/// <param name="fontStyle">
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>The font style to be set for text within a range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>The text range to which this change applies.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The font style can be set to Normal, Italic or Oblique. The following illustration shows three styles for the Palatino font. For
		/// more information, see DWRITE_FONT_STYLE.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code illustrates how to set the font style to italic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontstyle HRESULT SetFontStyle(
		// DWRITE_FONT_STYLE fontStyle, DWRITE_TEXT_RANGE textRange );
		new void SetFontStyle(DWRITE_FONT_STYLE fontStyle, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the font stretch for text within a specified text range.</summary>
		/// <param name="fontStretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value which indicates the type of font stretch for text within the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontstretch HRESULT SetFontStretch(
		// DWRITE_FONT_STRETCH fontStretch, DWRITE_TEXT_RANGE textRange );
		new void SetFontStretch(DWRITE_FONT_STRETCH fontStretch, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the font size in DIP units for text within a specified text range.</summary>
		/// <param name="fontSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The font size in DIP units to be set for text in the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontsize HRESULT SetFontSize( FLOAT
		// fontSize, DWRITE_TEXT_RANGE textRange );
		new void SetFontSize(float fontSize, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets underlining for text within a specified text range.</summary>
		/// <param name="hasUnderline">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag that indicates whether underline takes place within a specified text range.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setunderline HRESULT SetUnderline( BOOL
		// hasUnderline, DWRITE_TEXT_RANGE textRange );
		new void SetUnderline([MarshalAs(UnmanagedType.Bool)] bool hasUnderline, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets strikethrough for text within a specified text range.</summary>
		/// <param name="hasStrikethrough">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag that indicates whether strikethrough takes place in the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setstrikethrough HRESULT SetStrikethrough(
		// BOOL hasStrikethrough, DWRITE_TEXT_RANGE textRange );
		new void SetStrikethrough([MarshalAs(UnmanagedType.Bool)] bool hasStrikethrough, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the application-defined drawing effect.</summary>
		/// <param name="drawingEffect">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// Application-defined drawing effects that apply to the range. This data object will be passed back to the application's drawing
		/// callbacks for final rendering.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>The text range to which this change applies.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// An ID2D1Brush, such as a color or gradient brush, can be set as a drawing effect if you are using the
		/// ID2D1RenderTarget::DrawTextLayout to draw text and that brush will be used to draw the specified range of text.
		/// </para>
		/// <para>
		/// This drawing effect is associated with the specified range and will be passed back to the application by way of the callback
		/// when the range is drawn at drawing time.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setdrawingeffect HRESULT SetDrawingEffect(
		// IUnknown *drawingEffect, DWRITE_TEXT_RANGE textRange );
		new void SetDrawingEffect([MarshalAs(UnmanagedType.Interface)] object drawingEffect, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the inline object.</summary>
		/// <param name="inlineObject">
		/// <para>Type: <c>IDWriteInlineObject*</c></para>
		/// <para>An application-defined inline object.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The application may call this function to specify the set of properties describing an application-defined inline object for
		/// specific range.
		/// </para>
		/// <para>
		/// This inline object applies to the specified range and will be passed back to the application by way of the DrawInlineObject
		/// callback when the range is drawn. Any text in that range will be suppressed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setinlineobject HRESULT SetInlineObject(
		// IDWriteInlineObject *inlineObject, DWRITE_TEXT_RANGE textRange );
		new void SetInlineObject([In] IDWriteInlineObject inlineObject, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets font typography features for text within a specified text range.</summary>
		/// <param name="typography">
		/// <para>Type: <c>IDWriteTypography*</c></para>
		/// <para>Pointer to font typography settings.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-settypography HRESULT SetTypography(
		// IDWriteTypography *typography, DWRITE_TEXT_RANGE textRange );
		new void SetTypography([In] IDWriteTypography typography, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the locale name for text within a specified text range.</summary>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>A null-terminated locale name string.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setlocalename HRESULT SetLocaleName( WCHAR
		// const *localeName, DWRITE_TEXT_RANGE textRange );
		new void SetLocaleName([MarshalAs(UnmanagedType.LPWStr)] string localeName, DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the layout maximum width.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Returns the layout maximum width.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmaxwidth FLOAT GetMaxWidth();
		[PreserveSig]
		new float GetMaxWidth();

		/// <summary>Gets the layout maximum height.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The layout maximum height.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmaxheight FLOAT GetMaxHeight();
		[PreserveSig]
		new float GetMaxHeight();

		/// <summary>Gets the font collection associated with the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>Contains an address of a pointer to the current font collection.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the underline.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontcollection HRESULT
		// GetFontCollection( UINT32 currentPosition, IDWriteFontCollection **fontCollection, DWRITE_TEXT_RANGE *textRange );
		new void GetFontCollection(uint currentPosition, out IDWriteFontCollection fontCollection, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Get the length of the font family name at the current position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The current text position.</para>
		/// </param>
		/// <param name="nameLength">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// When this method returns, contains the size of the character array containing the font family name, in character count, not
		/// including the terminated <c>NULL</c> character.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font family.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontfamilynamelength HRESULT
		// GetFontFamilyNameLength( UINT32 currentPosition, UINT32 *nameLength, DWRITE_TEXT_RANGE *textRange );
		new void GetFontFamilyNameLength(uint currentPosition, out uint nameLength, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Copies the font family name of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to examine.</para>
		/// </param>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// When this method returns, contains an array of characters that receives the current font family name. You must allocate storage
		/// for this parameter.
		/// </para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array in character count including the terminated <c>NULL</c> character.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font family name.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontfamilyname HRESULT
		// GetFontFamilyName( UINT32 currentPosition, WCHAR *fontFamilyName, UINT32 nameSize, DWRITE_TEXT_RANGE *textRange );
		new void GetFontFamilyName(uint currentPosition, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder fontFamilyName, uint nameSize, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font weight of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontWeight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT*</c></para>
		/// <para>When this method returns, contains a value which indicates the type of font weight being applied at the specified position.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font weight.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontweight HRESULT GetFontWeight( UINT32
		// currentPosition, DWRITE_FONT_WEIGHT *fontWeight, DWRITE_TEXT_RANGE *textRange );
		new void GetFontWeight(uint currentPosition, out DWRITE_FONT_WEIGHT fontWeight, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font style (also known as slope) of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontStyle">
		/// <para>Type: <c>DWRITE_FONT_STYLE*</c></para>
		/// <para>
		/// When this method returns, contains a value which indicates the type of font style (also known as slope or incline) being applied
		/// at the specified position.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font style.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontstyle HRESULT GetFontStyle( UINT32
		// currentPosition, DWRITE_FONT_STYLE *fontStyle, DWRITE_TEXT_RANGE *textRange );
		new void GetFontStyle(uint currentPosition, out DWRITE_FONT_STYLE fontStyle, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font stretch of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontStretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH*</c></para>
		/// <para>
		/// When this method returns, contains a value which indicates the type of font stretch (also known as width) being applied at the
		/// specified position.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font stretch.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontstretch HRESULT GetFontStretch(
		// UINT32 currentPosition, DWRITE_FONT_STRETCH *fontStretch, DWRITE_TEXT_RANGE *textRange );
		new void GetFontStretch(uint currentPosition, out DWRITE_FONT_STRETCH fontStretch, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font em height of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontSize">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the size of the font in ems of the text at the specified position.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font size.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontsize HRESULT GetFontSize( UINT32
		// currentPosition, FLOAT *fontSize, DWRITE_TEXT_RANGE *textRange );
		new void GetFontSize(uint currentPosition, out float fontSize, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the underline presence of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The current text position.</para>
		/// </param>
		/// <param name="hasUnderline">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>A Boolean flag that indicates whether underline is present at the position indicated by currentPosition.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the underline.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getunderline HRESULT GetUnderline( UINT32
		// currentPosition, BOOL *hasUnderline, DWRITE_TEXT_RANGE *textRange );
		new void GetUnderline(uint currentPosition, [MarshalAs(UnmanagedType.Bool)] out bool hasUnderline, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Get the strikethrough presence of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="hasStrikethrough">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>A Boolean flag that indicates whether strikethrough is present at the position indicated by currentPosition.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// Contains the range of text that has the same formatting as the text at the position specified by currentPosition. This means the
		/// run has the exact formatting as the position specified, including but not limited to strikethrough.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getstrikethrough HRESULT GetStrikethrough(
		// UINT32 currentPosition, BOOL *hasStrikethrough, DWRITE_TEXT_RANGE *textRange );
		new void GetStrikethrough(uint currentPosition, [MarshalAs(UnmanagedType.Bool)] out bool hasStrikethrough, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the application-defined drawing effect at the specified text position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text whose drawing effect is to be retrieved.</para>
		/// </param>
		/// <param name="drawingEffect">
		/// <para>Type: <c>IUnknown**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the current application-defined drawing effect. Usually this
		/// effect is a foreground brush that is used in glyph drawing.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// Contains the range of text that has the same formatting as the text at the position specified by currentPosition. This means the
		/// run has the exact formatting as the position specified, including but not limited to the drawing effect.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getdrawingeffect HRESULT GetDrawingEffect(
		// UINT32 currentPosition, IUnknown **drawingEffect, DWRITE_TEXT_RANGE *textRange );
		new void GetDrawingEffect(uint currentPosition, [MarshalAs(UnmanagedType.Interface)] out object drawingEffect, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the inline object at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The specified text position.</para>
		/// </param>
		/// <param name="inlineObject">
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>Contains the application-defined inline object.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the inline object.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getinlineobject HRESULT GetInlineObject(
		// UINT32 currentPosition, IDWriteInlineObject **inlineObject, DWRITE_TEXT_RANGE *textRange );
		new void GetInlineObject(uint currentPosition, out IDWriteInlineObject inlineObject, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the typography setting of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="typography">
		/// <para>Type: <c>IDWriteTypography**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the current typography setting.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the typography.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-gettypography HRESULT GetTypography( UINT32
		// currentPosition, IDWriteTypography **typography, DWRITE_TEXT_RANGE *textRange );
		new void GetTypography(uint currentPosition, out IDWriteTypography typography, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the length of the locale name of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="nameLength">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>Size of the character array, in character count, not including the terminated <c>NULL</c> character.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the locale name.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getlocalenamelength HRESULT
		// GetLocaleNameLength( UINT32 currentPosition, UINT32 *nameLength, DWRITE_TEXT_RANGE *textRange );
		new void GetLocaleNameLength(uint currentPosition, out uint nameLength, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the locale name of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>When this method returns, contains the character array receiving the current locale name.</para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Size of the character array, in character count, including the terminated <c>NULL</c> character.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the locale name.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getlocalename HRESULT GetLocaleName( UINT32
		// currentPosition, WCHAR *localeName, UINT32 nameSize, DWRITE_TEXT_RANGE *textRange );
		new void GetLocaleName(uint currentPosition, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder localeName, uint nameSize, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Draws text using the specified client drawing context.</summary>
		/// <param name="clientDrawingContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>An application-defined drawing context.</para>
		/// </param>
		/// <param name="renderer">
		/// <para>Type: <c>IDWriteTextRenderer*</c></para>
		/// <para>Pointer to the set of callback functions used to draw parts of a text string.</para>
		/// </param>
		/// <param name="originX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The x-coordinate of the layout's left side.</para>
		/// </param>
		/// <param name="originY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate of the layout's top side.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>To draw text with this method, a textLayout object needs to be created by the application using IDWriteFactory::CreateTextLayout.</para>
		/// <para>
		/// After the textLayout object is obtained, the application calls the <c>IDWriteTextLayout::Draw</c> method to draw the text,
		/// decorations, and inline objects. The actual drawing is done through the callback interface passed in as the textRenderer
		/// argument; there, the corresponding DrawGlyphRun API is called.
		/// </para>
		/// <para>
		/// If you set a vertical text reading direction on IDWriteTextLayout via SetReadingDirection with
		/// DWRITE_READING_DIRECTION_TOP_TO_BOTTOM (or bottom to top), then you must pass an interface that implements IDWriteTextRenderer1.
		/// Otherwise you get the error DWRITE_E_TEXTRENDERERINCOMPATIBLE because the original IDWriteTextRenderer interface only supported
		/// horizontal text.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-draw HRESULT Draw( void
		// *clientDrawingContext, IDWriteTextRenderer *renderer, FLOAT originX, FLOAT originY );
		new void Draw([In, Optional] IntPtr clientDrawingContext, [In] IDWriteTextRenderer renderer, float originX, float originY);

		/// <summary>Retrieves the information about each individual text line of the text string.</summary>
		/// <param name="lineMetrics">
		/// <para>Type: <c>DWRITE_LINE_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to an array of structures containing various calculated length values of individual
		/// text lines.
		/// </para>
		/// </param>
		/// <param name="maxLineCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The maximum size of the lineMetrics array.</para>
		/// </param>
		/// <param name="actualLineCount">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains the actual size of the lineMetricsarray that is needed.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// If maxLineCount is not large enough E_NOT_SUFFICIENT_BUFFER, which is equivalent to
		/// HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER), is returned and *actualLineCount is set to the number of lines needed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getlinemetrics HRESULT GetLineMetrics(
		// DWRITE_LINE_METRICS *lineMetrics, UINT32 maxLineCount, UINT32 *actualLineCount );
		new void GetLineMetrics([Out, Optional, MarshalAs(UnmanagedType.LPArray)] DWRITE_LINE_METRICS[]? lineMetrics, uint maxLineCount, out uint actualLineCount);

		/// <summary>Retrieves overall metrics for the formatted string.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_TEXT_METRICS*</c></para>
		/// <para>When this method returns, contains the measured distances of text and associated content after being formatted.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmetrics HRESULT GetMetrics(
		// DWRITE_TEXT_METRICS *textMetrics );
		new DWRITE_TEXT_METRICS GetMetrics();

		/// <summary>
		/// Returns the overhangs (in DIPs) of the layout and all objects contained in it, including text glyphs and inline objects.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_OVERHANG_METRICS*</c></para>
		/// <para>Overshoots of visible extents (in DIPs) outside the layout.</para>
		/// </returns>
		/// <remarks>
		/// Underlines and strikethroughs do not contribute to the black box determination, since these are actually drawn by the renderer,
		/// which is allowed to draw them in any variety of styles.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getoverhangmetrics HRESULT
		// GetOverhangMetrics( DWRITE_OVERHANG_METRICS *overhangs );
		new DWRITE_OVERHANG_METRICS GetOverhangMetrics();

		/// <summary>Retrieves logical properties and measurements of each glyph cluster.</summary>
		/// <param name="clusterMetrics">
		/// <para>Type: <c>DWRITE_CLUSTER_METRICS*</c></para>
		/// <para>When this method returns, contains metrics, such as line-break or total advance width, for a glyph cluster.</para>
		/// </param>
		/// <param name="maxClusterCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The maximum size of the clusterMetrics array.</para>
		/// </param>
		/// <param name="actualClusterCount">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains the actual size of the clusterMetrics array that is needed.</para>
		/// </param>
		/// <remarks>
		/// If maxClusterCount is not large enough, then E_NOT_SUFFICIENT_BUFFER, which is equivalent to
		/// HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER), is returned and actualClusterCount is set to the number of clusters needed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getclustermetrics HRESULT
		// GetClusterMetrics( DWRITE_CLUSTER_METRICS *clusterMetrics, UINT32 maxClusterCount, UINT32 *actualClusterCount );
		new void GetClusterMetrics([Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_CLUSTER_METRICS[]? clusterMetrics, uint maxClusterCount, out uint actualClusterCount);

		/// <summary>
		/// Determines the minimum possible width the layout can be set to without emergency breaking between the characters of whole words occurring.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>Minimum width.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-determineminwidth HRESULT
		// DetermineMinWidth( FLOAT *minWidth );
		new float DetermineMinWidth();

		/// <summary>
		/// The application calls this function passing in a specific pixel location relative to the top-left location of the layout box and
		/// obtains the information about the correspondent hit-test metrics of the text string where the hit-test has occurred. When the
		/// specified pixel location is outside the text string, the function sets the output value *isInside to <c>FALSE</c>.
		/// </summary>
		/// <param name="pointX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The pixel location X to hit-test, relative to the top-left location of the layout box.</para>
		/// </param>
		/// <param name="pointY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The pixel location Y to hit-test, relative to the top-left location of the layout box.</para>
		/// </param>
		/// <param name="isTrailingHit">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// An output flag that indicates whether the hit-test location is at the leading or the trailing side of the character. When the
		/// output *isInside value is set to <c>FALSE</c>, this value is set according to the output hitTestMetrics-&gt;textPosition value
		/// to represent the edge closest to the hit-test location.
		/// </para>
		/// </param>
		/// <param name="isInside">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// An output flag that indicates whether the hit-test location is inside the text string. When <c>FALSE</c>, the position nearest
		/// the text's edge is returned.
		/// </para>
		/// </param>
		/// <param name="hitTestMetrics">
		/// <para>Type: <c>DWRITE_HIT_TEST_METRICS*</c></para>
		/// <para>
		/// The output geometry fully enclosing the hit-test location. When the output *isInside value is set to <c>FALSE</c>, this
		/// structure represents the geometry enclosing the edge closest to the hit-test location.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-hittestpoint HRESULT HitTestPoint( FLOAT
		// pointX, FLOAT pointY, BOOL *isTrailingHit, BOOL *isInside, DWRITE_HIT_TEST_METRICS *hitTestMetrics );
		new void HitTestPoint(float pointX, float pointY, [MarshalAs(UnmanagedType.Bool)] out bool isTrailingHit,
			[MarshalAs(UnmanagedType.Bool)] out bool isInside, out DWRITE_HIT_TEST_METRICS hitTestMetrics);

		/// <summary>
		/// The application calls this function to get the pixel location relative to the top-left of the layout box given the text position
		/// and the logical side of the position. This function is normally used as part of caret positioning of text where the caret is
		/// drawn at the location corresponding to the current text editing position. It may also be used as a way to programmatically
		/// obtain the geometry of a particular text position in UI automation.
		/// </summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The text position used to get the pixel location.</para>
		/// </param>
		/// <param name="isTrailingHit">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A Boolean flag that indicates whether the pixel location is of the leading or the trailing side of the specified text position.
		/// </para>
		/// </param>
		/// <param name="pointX">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the output pixel location X, relative to the top-left location of the layout box.</para>
		/// </param>
		/// <param name="pointY">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the output pixel location Y, relative to the top-left location of the layout box.</para>
		/// </param>
		/// <param name="hitTestMetrics">
		/// <para>Type: <c>DWRITE_HIT_TEST_METRICS*</c></para>
		/// <para>When this method returns, contains the output geometry fully enclosing the specified text position.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-hittesttextposition HRESULT
		// HitTestTextPosition( UINT32 textPosition, BOOL isTrailingHit, FLOAT *pointX, FLOAT *pointY, DWRITE_HIT_TEST_METRICS
		// *hitTestMetrics );
		new void HitTestTextPosition(uint textPosition, [MarshalAs(UnmanagedType.Bool)] bool isTrailingHit, out float pointX, out float pointY,
			out DWRITE_HIT_TEST_METRICS hitTestMetrics);

		/// <summary>
		/// <para>
		/// The application calls this function to get a set of hit-test metrics corresponding to a range of text positions. One of the main
		/// usages is to implement highlight selection of the text string.
		/// </para>
		/// <para>
		/// The function returns E_NOT_SUFFICIENT_BUFFER, which is equivalent to HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER), when the
		/// buffer size of hitTestMetrics is too small to hold all the regions calculated by the function. In this situation, the function
		/// sets the output value *actualHitTestMetricsCount to the number of geometries calculated.
		/// </para>
		/// <para>The application is responsible for allocating a new buffer of greater size and calling the function again.</para>
		/// <para>A good value to use as an initial value for maxHitTestMetricsCount may be calculated from the following equation:</para>
		/// <para>
		/// where lineCount is obtained from the value of the output argument *actualLineCount (from the function
		/// IDWriteTextLayout::GetLineLengths), and the maxBidiReorderingDepth value from the DWRITE_TEXT_METRICSstructure of the output
		/// argument *textMetrics (from the function IDWriteFactory::CreateTextLayout).
		/// </para>
		/// </summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The first text position of the specified range.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of positions of the specified range.</para>
		/// </param>
		/// <param name="originX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The origin pixel location X at the left of the layout box. This offset is added to the hit-test metrics returned.</para>
		/// </param>
		/// <param name="originY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The origin pixel location Y at the top of the layout box. This offset is added to the hit-test metrics returned.</para>
		/// </param>
		/// <param name="hitTestMetrics">
		/// <para>Type: <c>DWRITE_HIT_TEST_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a buffer of the output geometry fully enclosing the specified position range.
		/// The buffer must be at least as large as maxHitTestMetricsCount.
		/// </para>
		/// </param>
		/// <param name="maxHitTestMetricsCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Maximum number of boxes hitTestMetrics could hold in its buffer memory.</para>
		/// </param>
		/// <param name="actualHitTestMetricsCount">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>Actual number of geometries hitTestMetrics holds in its buffer memory.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-hittesttextrange HRESULT HitTestTextRange(
		// UINT32 textPosition, UINT32 textLength, FLOAT originX, FLOAT originY, DWRITE_HIT_TEST_METRICS
		// *hitTestMetrics, UINT32 maxHitTestMetricsCount, UINT32 *actualHitTestMetricsCount );
		new void HitTestTextRange(uint textPosition, uint textLength, float originX, float originY,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] DWRITE_HIT_TEST_METRICS[]? hitTestMetrics,
			uint maxHitTestMetricsCount, out uint actualHitTestMetricsCount);

		/// <summary>Enables or disables pair-kerning on a given text range.</summary>
		/// <param name="isPairKerningEnabled">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>The flag that indicates whether text is pair-kerned.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <b><c>DWRITE_TEXT_RANGE</c></b></para>
		/// <para>The text range to which the change applies.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextlayout1-setpairkerning HRESULT
		// SetPairKerning( BOOL isPairKerningEnabled, DWRITE_TEXT_RANGE textRange );
		new void SetPairKerning(bool isPairKerningEnabled, DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets whether or not pair-kerning is enabled at given position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The current text position.</para>
		/// </param>
		/// <param name="isPairKerningEnabled">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>The flag that indicates whether text is pair-kerned.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <b><c>DWRITE_TEXT_RANGE</c>*</b></para>
		/// <para>The position range of the current format.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextlayout1-getpairkerning HRESULT
		// GetPairKerning( UINT32 currentPosition, [out] BOOL *isPairKerningEnabled, [out, optional] DWRITE_TEXT_RANGE *textRange );
		new void GetPairKerning(uint currentPosition, out bool isPairKerningEnabled, [Out, Optional] StructPointer<DWRITE_TEXT_RANGE> textRange);

		/// <summary>Sets the spacing between characters.</summary>
		/// <param name="leadingSpacing">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The spacing before each character, in reading order.</para>
		/// </param>
		/// <param name="trailingSpacing">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The spacing after each character, in reading order.</para>
		/// </param>
		/// <param name="minimumAdvanceWidth">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The minimum advance of each character, to prevent characters from becoming too thin or zero-width. This must be zero or greater.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <b><c>DWRITE_TEXT_RANGE</c></b></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextlayout1-setcharacterspacing HRESULT
		// SetCharacterSpacing( FLOAT leadingSpacing, FLOAT trailingSpacing, FLOAT minimumAdvanceWidth, DWRITE_TEXT_RANGE textRange );
		new void SetCharacterSpacing(float leadingSpacing, float trailingSpacing, float minimumAdvanceWidth, DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the spacing between characters.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The current text position.</para>
		/// </param>
		/// <param name="leadingSpacing">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>The spacing before each character, in reading order.</para>
		/// </param>
		/// <param name="trailingSpacing">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>The spacing after each character, in reading order.</para>
		/// </param>
		/// <param name="minimumAdvanceWidth">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>
		/// The minimum advance of each character, to prevent characters from becoming too thin or zero-width. This must be zero or greater.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <b><c>DWRITE_TEXT_RANGE</c>*</b></para>
		/// <para>The position range of the current format.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextlayout1-getcharacterspacing HRESULT
		// GetCharacterSpacing( UINT32 currentPosition, [out] FLOAT *leadingSpacing, [out] FLOAT *trailingSpacing, [out] FLOAT
		// *minimumAdvanceWidth, [out, optional] DWRITE_TEXT_RANGE *textRange );
		new void GetCharacterSpacing(uint currentPosition, out float leadingSpacing, out float trailingSpacing, out float minimumAdvanceWidth,
			[Out, Optional] StructPointer<DWRITE_TEXT_RANGE> textRange);

		/// <summary><c>textMetrics</c></summary>
		/// <param name="textMetrics"/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_2/nf-dwrite_2-idwritetextlayout2-getmetrics HRESULT
		// GetMetrics( DWRITE_TEXT_METRICS1 *textMetrics );
		new void GetMetrics(out DWRITE_TEXT_METRICS1 textMetrics);

		/// <summary>Set the preferred orientation of glyphs when using a vertical reading direction.</summary>
		/// <param name="glyphOrientation">Preferred glyph orientation.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-setverticalglyphorientation HRESULT
		// SetVerticalGlyphOrientation( DWRITE_VERTICAL_GLYPH_ORIENTATION glyphOrientation );
		new void SetVerticalGlyphOrientation(DWRITE_VERTICAL_GLYPH_ORIENTATION glyphOrientation);

		/// <summary>Get the preferred orientation of glyphs when using a vertical reading direction.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-getverticalglyphorientation
		// DWRITE_VERTICAL_GLYPH_ORIENTATION GetVerticalGlyphOrientation();
		[PreserveSig]
		new DWRITE_VERTICAL_GLYPH_ORIENTATION GetVerticalGlyphOrientation();

		/// <summary>Set whether or not the last word on the last line is wrapped.</summary>
		/// <param name="isLastLineWrappingEnabled">Line wrapping option.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-setlastlinewrapping HRESULT
		// SetLastLineWrapping( BOOL isLastLineWrappingEnabled );
		new void SetLastLineWrapping(bool isLastLineWrappingEnabled);

		/// <summary>Get whether or not the last word on the last line is wrapped.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-getlastlinewrapping BOOL GetLastLineWrapping();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool GetLastLineWrapping();

		/// <summary>
		/// Set how the glyphs align to the edges the margin. Default behavior is to align glyphs using their default glyphs metrics, which
		/// include side bearings.
		/// </summary>
		/// <param name="opticalAlignment">Optical alignment option.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-setopticalalignment HRESULT
		// SetOpticalAlignment( DWRITE_OPTICAL_ALIGNMENT opticalAlignment );
		new void SetOpticalAlignment(DWRITE_OPTICAL_ALIGNMENT opticalAlignment);

		/// <summary>Get how the glyphs align to the edges the margin.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-getopticalalignment
		// DWRITE_OPTICAL_ALIGNMENT GetOpticalAlignment();
		[PreserveSig]
		new DWRITE_OPTICAL_ALIGNMENT GetOpticalAlignment();

		/// <summary>Apply a custom font fallback onto layout. If none is specified, the layout uses the system fallback list.</summary>
		/// <param name="fontFallback">Custom font fallback created from <c>IDWriteFontFallbackBuilder::CreateFontFallback</c> or <c>IDWriteFactory2::GetSystemFontFallback</c>.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-setfontfallback HRESULT
		// SetFontFallback( IDWriteFontFallback *fontFallback );
		new void SetFontFallback([In] IDWriteFontFallback fontFallback);

		/// <summary>Get the current font fallback object.</summary>
		/// <returns>The current font fallback object.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_2/nf-dwrite_2-idwritetextlayout2-getfontfallback HRESULT
		// GetFontFallback( [out] IDWriteFontFallback **fontFallback );
		new IDWriteFontFallback GetFontFallback();

		/// <summary>
		/// Invalidates the layout, forcing layout to remeasure before calling the metrics or drawing functions. This is useful if the
		/// locality of a font changes, and layout should be redrawn, or if the size of a client implemented IDWriteInlineObject changes.
		/// </summary>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritetextlayout3-invalidatelayout HRESULT InvalidateLayout();
		new void InvalidateLayout();

		/// <summary>Set line spacing.</summary>
		/// <param name="lineSpacingOptions">How to manage space between lines.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritetextlayout3-setlinespacing HRESULT
		// SetLineSpacing( [in] DWRITE_LINE_SPACING const *lineSpacingOptions );
		new void SetLineSpacing(in DWRITE_LINE_SPACING lineSpacingOptions);

		/// <summary>Gets line spacing information.</summary>
		/// <returns>How to manage space between lines.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritetextlayout3-getlinespacing HRESULT
		// GetLineSpacing( [out] DWRITE_LINE_SPACING *lineSpacingOptions );
		new DWRITE_LINE_SPACING GetLineSpacing();

		/// <summary>Retrieves properties of each line.</summary>
		/// <param name="lineMetrics">The array to fill with line information.</param>
		/// <param name="maxLineCount">The maximum size of the lineMetrics array.</param>
		/// <param name="actualLineCount">The actual size of the lineMetrics array that is needed.</param>
		/// <returns>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
		/// <remarks>
		/// If maxLineCount is not large enough E_NOT_SUFFICIENT_BUFFER, which is equivalent to
		/// HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER), is returned and actualLineCount is set to the number of lines needed.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-idwritetextlayout3-getlinemetrics HRESULT
		// GetLineMetrics( [out] DWRITE_LINE_METRICS1 *lineMetrics, UINT32 maxLineCount, [out] UINT32 *actualLineCount );
		[PreserveSig]
		new HRESULT GetLineMetrics([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_LINE_METRICS1[] lineMetrics, uint maxLineCount, out uint actualLineCount);

		/// <summary>Set values for font axes over a range of text.</summary>
		/// <param name="fontAxisValues">List of font axis values.</param>
		/// <param name="fontAxisValueCount">Number of font axis values.</param>
		/// <param name="textRange"/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritetextlayout4-setfontaxisvalues
		// HRESULT SetFontAxisValues( DWRITE_FONT_AXIS_VALUE const *fontAxisValues, UINT32 fontAxisValueCount, DWRITE_TEXT_RANGE textRange );
		void SetFontAxisValues([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues,
			uint fontAxisValueCount, DWRITE_TEXT_RANGE textRange);

		/// <summary>Get the number of axes set on the text position.</summary>
		/// <param name="currentPosition"/>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritetextlayout4-getfontaxisvaluecount
		// UINT32 GetFontAxisValueCount( UINT32 currentPosition );
		[PreserveSig]
		uint GetFontAxisValueCount(uint currentPosition);

		/// <summary>Get the list of font axis values on the text position.</summary>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="fontAxisValues">List of font axis values.</param>
		/// <param name="fontAxisValueCount">Maximum number of font axis values to write.</param>
		/// <param name="textRange">The text range.</param>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/nf-dwrite_3-idwritetextlayout4-getfontaxisvalues
		// HRESULT GetFontAxisValues( UINT32 currentPosition, DWRITE_FONT_AXIS_VALUE *fontAxisValues, UINT32 fontAxisValueCount,
		// DWRITE_TEXT_RANGE *textRange );
		void GetFontAxisValues(uint currentPosition, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DWRITE_FONT_AXIS_VALUE[] fontAxisValues,
			uint fontAxisValueCount, [Out, Optional] StructPointer<DWRITE_TEXT_RANGE> textRange);

		/// <summary>Get the automatic axis options.</summary>
		/// <returns>Automatic axis options.</returns>
		[PreserveSig]
		DWRITE_AUTOMATIC_FONT_AXES GetAutomaticFontAxes();

		/// <summary>Sets the automatic font axis options.</summary>
		/// <param name="automaticFontAxes">Automatic font axis options.</param>
		/// <returns>Standard HRESULT error code.</returns>
		void SetAutomaticFontAxes(DWRITE_AUTOMATIC_FONT_AXES automaticFontAxes);
	}

	/// <summary>Sets the current glyph, and positions the reader on the root paint element of the selected glyph's visual tree.</summary>
	/// <param name="rdr">The <see cref="IDWritePaintReader"/> instance.</param>
	/// <param name="glyphIndex">
	/// <para>Type: <b><c>UINT32</c></b></para>
	/// <para>Glyph index to get the color glyph representation for.</para>
	/// </param>
	/// <param name="paintElement">
	/// <para>Type: _Out_writes_bytes_(structSize) <b><c>DWRITE_PAINT_ELEMENT</c> *</b></para>
	/// <para>Receives information about the root paint element of the glyph's visual tree.</para>
	/// </param>
	/// <param name="clipBox">
	/// <para>Type: _Out_ <b><c>D2D_RECT_F</c> *</b></para>
	/// <para>
	/// Receives a precomputed glyph box (in ems) for the specified glyph, if one is specified by the font. Otherwise, the glyph box is set
	/// to an empty rectangle (all zeros). If a non-empty clip box is specified, then you must clip the color glyph's representation to the
	/// specified box.
	/// </para>
	/// </param>
	/// <param name="glyphAttributes">
	/// <para>Type: _Out_opt_ <b><c>DWRITE_PAINT_ATTRIBUTES</c> * = nullptr</b></para>
	/// <para>Receives optional paint attributes for the glyph.</para>
	/// </param>
	/// <remarks>
	/// If the specified glyph index isn't a color glyph, then the method succeeds, but the paintType member of the
	/// <c>DWRITE_PAINT_ELEMENT</c> structure is set to <b>DWRITE_PAINT_TYPE_NONE</b>. In that case, you should draw the input glyph as a
	/// non-color glyph.
	/// </remarks>
	public static void SetCurrentGlyph(this IDWritePaintReader rdr, uint glyphIndex, out DWRITE_PAINT_ELEMENT paintElement, out D2D_RECT_F clipBox,
		out DWRITE_PAINT_ATTRIBUTES glyphAttributes) =>
		rdr.SetCurrentGlyph(glyphIndex, out paintElement, (uint)Marshal.SizeOf<DWRITE_PAINT_ELEMENT>(), out clipBox, out glyphAttributes);
}