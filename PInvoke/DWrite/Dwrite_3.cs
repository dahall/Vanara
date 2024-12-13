namespace Vanara.PInvoke;

public static partial class Dwrite
{
	/// <summary>Defines constants that specify known feature levels for use with the <c>IDWritePaintReader</c> interface and related APIs. A feature level represents a level of functionality. For example, it determines what <c>DWRITE_PAINT_TYPE</c> values might be returned.</summary>
	/// <remarks>For info about which paint types are required for each feature level, see the <c>DWRITE_PAINT_TYPE</c> enumeration.</remarks>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/ne-dwrite_3-dwrite_paint_feature_level
	// typedef enum DWRITE_PAINT_FEATURE_LEVEL { DWRITE_PAINT_FEATURE_LEVEL_NONE, DWRITE_PAINT_FEATURE_LEVEL_COLR_V0, DWRITE_PAINT_FEATURE_LEVEL_COLR_V1 } ;
	[PInvokeData("dwrite_3.h", MSDNShortId = "NE:dwrite_3.DWRITE_PAINT_FEATURE_LEVEL")]
	public enum DWRITE_PAINT_FEATURE_LEVEL
	{
		/// <summary>No paint API support.</summary>
		DWRITE_PAINT_FEATURE_LEVEL_NONE,
		/// <summary>Specifies a level of functionality corresponding to OpenType COLR version 0.</summary>
		DWRITE_PAINT_FEATURE_LEVEL_COLR_V0,
		/// <summary>Specifies a level of functionality corresponding to OpenType COLR version 1.</summary>
		DWRITE_PAINT_FEATURE_LEVEL_COLR_V1,
	}

/*
DWRITE_AUTOMATIC_FONT_AXES
DWRITE_COLOR_COMPOSITE_MODE
DWRITE_CONTAINER_TYPE
DWRITE_FONT_AXIS_ATTRIBUTES
DWRITE_FONT_AXIS_TAG
DWRITE_FONT_FAMILY_MODEL
DWRITE_FONT_LINE_GAP_USAGE
DWRITE_FONT_PROPERTY_ID
DWRITE_FONT_SOURCE_TYPE
DWRITE_LOCALITY
DWRITE_PAINT_ATTRIBUTES
DWRITE_PAINT_FEATURE_LEVEL
DWRITE_PAINT_TYPE
DWRITE_RENDERING_MODE1

DWRITE_BITMAP_DATA_BGRA32
DWRITE_COLOR_GLYPH_RUN1
DWRITE_FILE_FRAGMENT
DWRITE_FONT_AXIS_RANGE
DWRITE_FONT_AXIS_VALUE
DWRITE_FONT_PROPERTY
DWRITE_GLYPH_IMAGE_DATA
DWRITE_LINE_METRICS1
DWRITE_LINE_SPACING
DWRITE_PAINT_COLOR
DWRITE_PAINT_ELEMENT

DWRITE_MAKE_FONT_AXIS_TAG

IDWriteAsyncResult
IDWriteBitmapRenderTarget2
IDWriteBitmapRenderTarget3
IDWriteColorGlyphRunEnumerator1
IDWriteFactory3
IDWriteFactory4
IDWriteFactory5
IDWriteFactory6
IDWriteFactory7
IDWriteFactory8
IDWriteFont3
IDWriteFontCollection1
IDWriteFontCollection2
IDWriteFontCollection3
IDWriteFontDownloadListener
IDWriteFontDownloadQueue
IDWriteFontFace3
IDWriteFontFace4
IDWriteFontFace5
IDWriteFontFace6
IDWriteFontFace7
IDWriteFontFaceReference
IDWriteFontFaceReference1
IDWriteFontFallback1
IDWriteFontFamily1
IDWriteFontFamily2
IDWriteFontList1
IDWriteFontList2
IDWriteFontResource
IDWriteFontSet
IDWriteFontSet1
IDWriteFontSet2
IDWriteFontSet3
IDWriteFontSet4
IDWriteFontSetBuilder
IDWriteFontSetBuilder1
IDWriteFontSetBuilder2
IDWriteGdiInterop1
IDWriteInMemoryFontFileLoader
IDWritePaintReader
IDWriteRemoteFontFileLoader
IDWriteRemoteFontFileStream
IDWriteRenderingParams3
IDWriteStringList
IDWriteTextFormat2
IDWriteTextFormat3
IDWriteTextLayout3
IDWriteTextLayout4
*/
}