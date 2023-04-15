using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

public static partial class Gdi32
{
	/// <summary>
	/// The <c>EnhMetaFileProc</c> function is an application-defined callback function used with the EnumEnhMetaFile function. The
	/// <c>ENHMFENUMPROC</c> type defines a pointer to this callback function. <c>EnhMetaFileProc</c> is a placeholder for the
	/// application-defined function name.
	/// </summary>
	/// <param name="hdc">Handle to the device context passed to EnumEnhMetaFile.</param>
	/// <param name="lpht">
	/// Pointer to a HANDLETABLE structure representing the table of handles associated with the graphics objects (pens, brushes, and so
	/// on) in the metafile. The first entry contains the enhanced-metafile handle.
	/// </param>
	/// <param name="lpmr">
	/// Pointer to one of the records in the metafile. This record should not be modified. (If modification is necessary, it should be
	/// performed on a copy of the record.)
	/// </param>
	/// <param name="nHandles">Specifies the number of objects with associated handles in the handle table.</param>
	/// <param name="data">Pointer to optional data.</param>
	/// <returns>This function must return a nonzero value to continue enumeration; to stop enumeration, it must return zero.</returns>
	/// <remarks>An application must register the callback function by passing its address to the EnumEnhMetaFile function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nc-wingdi-enhmfenumproc ENHMFENUMPROC Enhmfenumproc; int Enhmfenumproc(
	// HDC hdc, HANDLETABLE *lpht, const ENHMETARECORD *lpmr, int nHandles, LPARAM data ) {...}
	[PInvokeData("wingdi.h", MSDNShortId = "c9f04b38-18bc-4b52-8c56-d9475bc30202")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate int EnhMetaFileProc(HDC hdc, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] HGDIOBJ[] lpht, [In] IntPtr lpmr, int nHandles, IntPtr data);

	/// <summary>
	/// <para>
	/// The <c>EnumMetaFileProc</c> function is an application-defined callback function that processes Windows-format metafile records.
	/// This function is called by the EnumMetaFile function. The <c>MFENUMPROC</c> type defines a pointer to this callback function.
	/// <c>EnumMetaFileProc</c> is a placeholder for the application-defined function name.
	/// </para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with Windows-format metafiles. Enhanced-format metafiles provide
	/// superior functionality and are recommended for new applications. The corresponding function for an enhanced-format metafile is EnhMetaFileProc.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>An application must register the callback function by passing its address to the EnumMetaFile function.</para>
	/// <para><c>EnumMetaFileProc</c> is a placeholder for the application-supplied function name.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nc-wingdi-mfenumproc MFENUMPROC Mfenumproc; int Mfenumproc( HDC hdc,
	// HANDLETABLE *lpht, METARECORD *lpMR, int nObj, LPARAM param ) {...}
	[PInvokeData("wingdi.h", MSDNShortId = "ebef5a3f-0dd7-49df-a07d-c55c5e8c868c")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate int EnumMetaFileProc(HDC hdc, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] HGDIOBJ[] lpht, [In] IntPtr lpMR, int nObj, IntPtr param);

	/// <summary>
	/// The RecordType enumeration defines values that uniquely identify records in an EMF metafile. These values are specified in the
	/// Type fields of EMF records (section 2.3).
	/// </summary>
	[PInvokeData("wingdi.h")]
	public enum RecordType : uint
	{
		/// <summary>
		/// This record defines the start of the metafile and specifies its characteristics; its contents, including the dimensions of
		/// the embedded image; the number of records in the metafile; and the resolution of the device on which the embedded image was
		/// created. These values make it possible for the metafile to be device-independent.
		/// </summary>
		EMR_HEADER = 1,

		/// <summary>
		/// This record defines one or more Bezier curves. Cubic Bezier curves are defined using specified endpoints and control points,
		/// and are stroked with the current pen.
		/// </summary>
		EMR_POLYBEZIER = 2,

		/// <summary>
		/// This record defines a polygon consisting of two or more vertexes connected by straight lines. The polygon is outlined by
		/// using the current pen and filled by using the current brush and polygon fill mode. The polygon is closed automatically by
		/// drawing a line from the last vertex to the first.
		/// </summary>
		EMR_POLYGON = 3,

		/// <summary>This record defines a series of line segments by connecting the points in the specified array.</summary>
		EMR_POLYLINE = 4,

		/// <summary>This record defines one or more Bezier curves based upon the current drawing position.</summary>
		EMR_POLYBEZIERTO = 5,

		/// <summary>
		/// This record defines one or more straight lines based upon the current drawing position. A line is drawn from the current
		/// drawing position to the first point specified by the points field by using the current pen. For each additional line, drawing
		/// is performed from the ending point of the previous line to the next point specified by points.
		/// </summary>
		EMR_POLYLINETO = 6,

		/// <summary>
		/// This record defines multiple series of connected line segments. The line segments are drawn by using the current pen. The
		/// figures formed by the segments are not filled. The current position is neither used nor updated by this record.
		/// </summary>
		EMR_POLYPOLYLINE = 7,

		/// <summary>
		/// This record defines a series of closed polygons. Each polygon is outlined by using the current pen and filled by using the
		/// current brush and polygon fill mode. The polygons defined by this record can overlap.
		/// </summary>
		EMR_POLYPOLYGON = 8,

		/// <summary>This record defines the window extent.</summary>
		EMR_SETWINDOWEXTEX = 9,

		/// <summary>This record defines the window origin.</summary>
		EMR_SETWINDOWORGEX = 10,

		/// <summary>This record defines the viewport extent.</summary>
		EMR_SETVIEWPORTEXTEX = 11,

		/// <summary>This record defines the viewport origin.</summary>
		EMR_SETVIEWPORTORGEX = 12,

		/// <summary>This record defines the origin of the current brush.</summary>
		EMR_SETBRUSHORGEX = 13,

		/// <summary>This record indicates the end of the metafile.</summary>
		EMR_EOF = 14,

		/// <summary>This record defines the color of the pixel at the specified logical coordinates.</summary>
		EMR_SETPIXELV = 15,

		/// <summary>
		/// This record specifies parameters for the process of matching logical fonts to physical fonts, which is performed by the font mapper.
		/// </summary>
		EMR_SETMAPPERFLAGS = 16,

		/// <summary>
		/// This record defines the mapping mode, which defines the unit of measure used to transform page space units into device space
		/// units, and defines the orientation of the device's X and Y axes.
		/// </summary>
		EMR_SETMAPMODE = 17,

		/// <summary>
		/// This record defines the background mix mode, which is used with text, hatched brushes, and pen styles that are not solid lines.
		/// </summary>
		EMR_SETBKMODE = 18,

		/// <summary>This record defines polygon fill mode.</summary>
		EMR_SETPOLYFILLMODE = 19,

		/// <summary>This record defines binary raster operation mode.</summary>
		EMR_SETROP2 = 20,

		/// <summary>This record defines bitmap stretch mode.</summary>
		EMR_SETSTRETCHBLTMODE = 21,

		/// <summary>This record defines text alignment.</summary>
		EMR_SETTEXTALIGN = 22,

		/// <summary>This record defines the color adjustment values using the specified values.</summary>
		EMR_SETCOLORADJUSTMENT = 23,

		/// <summary>This record defines the current text color.</summary>
		EMR_SETTEXTCOLOR = 24,

		/// <summary>This record defines the background color.</summary>
		EMR_SETBKCOLOR = 25,

		/// <summary>This record redefines the current clipping region by the specified offsets.</summary>
		EMR_OFFSETCLIPRGN = 26,

		/// <summary>This record defines coordinates of the new drawing position in logical units.</summary>
		EMR_MOVETOEX = 27,

		/// <summary>
		/// This record intersects the current clipping region with the current metaregion and saves the combined region as the new
		/// current metaregion.
		/// </summary>
		EMR_SETMETARGN = 28,

		/// <summary>
		/// This record defines a new clipping region that consists of the current clipping region intersected with the specified rectangle.
		/// </summary>
		EMR_EXCLUDECLIPRECT = 29,

		/// <summary>
		/// This record defines a new clipping region from the intersection of the current clipping region and the specified rectangle.
		/// </summary>
		EMR_INTERSECTCLIPRECT = 30,

		/// <summary>This record redefines the viewport using the ratios formed by the specified multiplicands and divisors.</summary>
		EMR_SCALEVIEWPORTEXTEX = 31,

		/// <summary>This record redefines the window using the ratios formed by the specified multiplicands and divisors.</summary>
		EMR_SCALEWINDOWEXTEX = 32,

		/// <summary>
		/// This record saves the current state of the playback device context (section 3.1) in an array of states saved by preceding
		/// EMR_SAVEDC records if any.
		/// </summary>
		EMR_SAVEDC = 33,

		/// <summary>
		/// This record restores the playback device context to the specified state, which was saved by a preceding EMR_SAVEDC record
		/// (section 2.3.11).
		/// </summary>
		EMR_RESTOREDC = 34,

		/// <summary>This record defines a two-dimensional linear transform between world space and page space [MSDN-WRLDPGSPC].</summary>
		EMR_SETWORLDTRANSFORM = 35,

		/// <summary>This record redefines the world transform by using the specified mode.</summary>
		EMR_MODIFYWORLDTRANSFORM = 36,

		/// <summary>
		/// This record selects an object in the playback device context, which is identified by its index in the EMF object table
		/// (section 3.1.1.1).
		/// </summary>
		EMR_SELECTOBJECT = 37,

		/// <summary>This record defines a logical pen (section 2.2.19) that has the specified style, width, and color.</summary>
		EMR_CREATEPEN = 38,

		/// <summary>This record defines a logical brush for filling figures in graphics operations.</summary>
		EMR_CREATEBRUSHINDIRECT = 39,

		/// <summary>This record deletes a graphics object, clearing its index in the EMF object table.</summary>
		EMR_DELETEOBJECT = 40,

		/// <summary>
		/// This record defines a line segment of an arc. The line segment is drawn from the current drawing position to the beginning of
		/// the arc. The arc is drawn along the perimeter of a circle with the given radius and center. The length of the arc is defined
		/// by the given start and sweep angles.
		/// </summary>
		EMR_ANGLEARC = 41,

		/// <summary>
		/// This record defines an ellipse. The center of the ellipse is the center of the specified bounding rectangle. The ellipse is
		/// outlined by using the current pen and is filled by using the current brush.
		/// </summary>
		EMR_ELLIPSE = 42,

		/// <summary>
		/// This record defines a rectangle. The rectangle is outlined by using the current pen and filled by using the current brush.
		/// </summary>
		EMR_RECTANGLE = 43,

		/// <summary>
		/// This record defines a rectangle with rounded corners. The rectangle is outlined by using the current pen and filled by using
		/// the current brush.
		/// </summary>
		EMR_ROUNDRECT = 44,

		/// <summary>This record defines an elliptical arc.</summary>
		EMR_ARC = 45,

		/// <summary>
		/// This record defines a chord, which is a region bounded by the intersection of an ellipse and a line segment, called a secant.
		/// The chord is outlined by using the current pen and filled by using the current brush.
		/// </summary>
		EMR_CHORD = 46,

		/// <summary>
		/// This record defines a pie-shaped wedge bounded by the intersection of an ellipse and two radials. The pie is outlined by
		/// using the current pen and filled by using the current brush.
		/// </summary>
		EMR_PIE = 47,

		/// <summary>
		/// This record selects a LogPalette object (section 2.2.17) into the playback device context, identifying it by its index in the
		/// EMF object table.
		/// </summary>
		EMR_SELECTPALETTE = 48,

		/// <summary>This record defines a LogPalette object.</summary>
		EMR_CREATEPALETTE = 49,

		/// <summary>This record defines RGB color values in a range of entries in a LogPalette object.</summary>
		EMR_SETPALETTEENTRIES = 50,

		/// <summary>This record increases or decreases the size of a logical palette.</summary>
		EMR_RESIZEPALETTE = 51,

		/// <summary>This record maps entries from the current logical palette to the system palette.</summary>
		EMR_REALIZEPALETTE = 52,

		/// <summary>This record fills an area of the display surface with the current brush.</summary>
		EMR_EXTFLOODFILL = 53,

		/// <summary>
		/// This record defines a line from the current drawing position up to, but not including, the specified point. It resets the
		/// current drawing position to the specified point.
		/// </summary>
		EMR_LINETO = 54,

		/// <summary>This record defines an elliptical arc. It resets the current position to the endpoint of the arc.</summary>
		EMR_ARCTO = 55,

		/// <summary>This record defines a set of line segments and Bezier curves.</summary>
		EMR_POLYDRAW = 56,

		/// <summary>This record defines the drawing direction to be used for arc and rectangle operations.</summary>
		EMR_SETARCDIRECTION = 57,

		/// <summary>This record defines the limit for the length of miter joins.</summary>
		EMR_SETMITERLIMIT = 58,

		/// <summary>This record opens a path bracket for specifying the current path.</summary>
		EMR_BEGINPATH = 59,

		/// <summary>This record closes an open path bracket and selects the path into the playback device context.</summary>
		EMR_ENDPATH = 60,

		/// <summary>This record closes an open figure in a path.</summary>
		EMR_CLOSEFIGURE = 61,

		/// <summary>
		/// This record closes any open figures in the current path bracket and fills its interior by using the current brush and
		/// polygon-filling mode.
		/// </summary>
		EMR_FILLPATH = 62,

		/// <summary>
		/// This record closes any open figures in a path, strokes the outline of the path by using the current pen, and fills its
		/// interior by using the current brush.
		/// </summary>
		EMR_STROKEANDFILLPATH = 63,

		/// <summary>This record renders the specified path by using the current pen.</summary>
		EMR_STROKEPATH = 64,

		/// <summary>This record turns each curve in the path into a sequence of lines.</summary>
		EMR_FLATTENPATH = 65,

		/// <summary>
		/// This record redefines the current path bracket as the area that would be painted if the path were stroked using the current pen.
		/// </summary>
		EMR_WIDENPATH = 66,

		/// <summary>
		/// This record specifies a clipping region as the current clipping region combined with the current path bracket, using the
		/// specified mode.
		/// </summary>
		EMR_SELECTCLIPPATH = 67,

		/// <summary>This record aborts a path bracket or discards the path from a closed path bracket.</summary>
		EMR_ABORTPATH = 68,

		/// <summary>This record specifies arbitrary private data.</summary>
		EMR_GDICOMMENT = 70,

		/// <summary>This record fills the specified region by using the specified brush.</summary>
		EMR_FILLRGN = 71,

		/// <summary>This record draws a border around the specified region using the specified brush.</summary>
		EMR_FRAMERGN = 72,

		/// <summary>This record inverts the colors in the specified region.</summary>
		EMR_INVERTRGN = 73,

		/// <summary>This record paints the specified region by using the current brush.</summary>
		EMR_PAINTRGN = 74,

		/// <summary>This record combines the specified region with the current clipping region, using the specified mode.</summary>
		EMR_EXTSELECTCLIPRGN = 75,

		/// <summary>
		/// This record specifies a block transfer of pixels from a source bitmap to a destination rectangle, optionally in combination
		/// with a brush pattern, according to a specified raster operation.
		/// </summary>
		EMR_BITBLT = 76,

		/// <summary>
		/// This record specifies a block transfer of pixels from a source bitmap to a destination rectangle, optionally in combination
		/// with a brush pattern, according to a specified raster operation, stretching or compressing the output to fit the dimensions
		/// of the destination, if necessary.
		/// </summary>
		EMR_STRETCHBLT = 77,

		/// <summary>
		/// This record specifies a block transfer of pixels from a source bitmap to a destination rectangle, optionally in combination
		/// with a brush pattern and with the application of a color mask bitmap, according to specified foreground and background raster operations.
		/// </summary>
		EMR_MASKBLT = 78,

		/// <summary>
		/// This record specifies a block transfer of pixels from a source bitmap to a destination parallelogram, with the application of
		/// a color mask bitmap.
		/// </summary>
		EMR_PLGBLT = 79,

		/// <summary>
		/// This record specifies a block transfer of pixels from specified scanlines of a source bitmap to a destination rectangle.
		/// </summary>
		EMR_SETDIBITSTODEVICE = 80,

		/// <summary>
		/// This record specifies a block transfer of pixels from a source bitmap to a destination rectangle, optionally in combination
		/// with a brush pattern, according to a specified raster operation, stretching or compressing the output to fit the dimensions
		/// of the destination, if necessary.
		/// </summary>
		EMR_STRETCHDIBITS = 81,

		/// <summary>
		/// This record defines a logical font that has the specified characteristics. The font can subsequently be selected as the
		/// current font.
		/// </summary>
		EMR_EXTCREATEFONTINDIRECTW = 82,

		/// <summary>This record draws an ASCII text string using the current font and text colors.</summary>
		EMR_EXTTEXTOUTA = 83,

		/// <summary>This record draws a Unicode text string using the current font and text colors.</summary>
		EMR_EXTTEXTOUTW = 84,

		/// <summary>This record defines one or more Bezier curves. The curves are drawn using the current pen.</summary>
		EMR_POLYBEZIER16 = 85,

		/// <summary>
		/// This record defines a polygon consisting of two or more vertexes connected by straight lines. The polygon is outlined by
		/// using the current pen and filled by using the current brush and polygon fill mode. The polygon is closed automatically by
		/// drawing a line from the last vertex to the first.
		/// </summary>
		EMR_POLYGON16 = 86,

		/// <summary>This record defines a series of line segments by connecting the points in the specified array.</summary>
		EMR_POLYLINE16 = 87,

		/// <summary>This record defines one or more Bezier curves based on the current position.</summary>
		EMR_POLYBEZIERTO16 = 88,

		/// <summary>
		/// This record defines one or more straight lines based upon the current position. A line is drawn from the current position to
		/// the first point specified by the Points field by using the current pen. For each additional line, drawing is performed from
		/// the ending point of the previous line to the next point specified by Points.
		/// </summary>
		EMR_POLYLINETO16 = 89,

		/// <summary>This record defines multiple series of connected line segments.</summary>
		EMR_POLYPOLYLINE16 = 90,

		/// <summary>
		/// This record defines a series of closed polygons. Each polygon is outlined by using the current pen and filled by using the
		/// current brush and polygon fill mode. The polygons specified by this record can overlap.
		/// </summary>
		EMR_POLYPOLYGON16 = 91,

		/// <summary>This record defines a set of line segments and Bezier curves.</summary>
		EMR_POLYDRAW16 = 92,

		/// <summary>
		/// This record defines a logical brush with the specified bitmap pattern. The bitmap can be a device-independent bitmap (DIB)
		/// section bitmap or it can be a device-dependent bitmap.
		/// </summary>
		EMR_CREATEMONOBRUSH = 93,

		/// <summary>This record defines a logical brush that has the pattern specified by the DIB.</summary>
		EMR_CREATEDIBPATTERNBRUSHPT = 94,

		/// <summary>
		/// This record defines an extended logical pen (section 2.2.20) that has the specified style, width, color, and brush attributes.
		/// </summary>
		EMR_EXTCREATEPEN = 95,

		/// <summary>
		/// This record draws one or more ASCII text strings using the current font and text colors. Note: EMR_POLYTEXTOUTA SHOULD be
		/// emulated with a series of EMR_EXTTEXTOUTW records, one per string.
		/// </summary>
		EMR_POLYTEXTOUTA = 96,

		/// <summary>
		/// This record draws one or more Unicode text strings using the current font and text colors. Note: EMR_POLYTEXTOUTW SHOULD be
		/// emulated with a series of EMR_EXTTEXTOUTW records, one per string.
		/// </summary>
		EMR_POLYTEXTOUTW = 97,

		/// <summary>This record specifies the mode of Image Color Management (ICM) for graphics operations.</summary>
		EMR_SETICMMODE = 98,

		/// <summary>This record creates a logical color space object from a color profile with a name consisting of ASCII characters.</summary>
		EMR_CREATECOLORSPACE = 99,

		/// <summary>This record defines the current logical color space object for graphics operations.</summary>
		EMR_SETCOLORSPACE = 100,

		/// <summary>
		/// This record deletes a logical color space object. Note: An EMR_DELETEOBJECT record SHOULD be used instead of
		/// EMR_DELETECOLORSPACE to delete a logical color space object.
		/// </summary>
		EMR_DELETECOLORSPACE = 101,

		/// <summary>This record specifies an OpenGL function.</summary>
		EMR_GLSRECORD = 102,

		/// <summary>This record specifies an OpenGL function with a bounding rectangle for output.</summary>
		EMR_GLSBOUNDEDRECORD = 103,

		/// <summary>This record specifies the pixel format to use for graphics operations.</summary>
		EMR_PIXELFORMAT = 104,

		/// <summary>
		/// This record passes arbitrary information to the driver. The intent is that the information results in drawing being done.
		/// </summary>
		EMR_DRAWESCAPE = 105,

		/// <summary>
		/// This record passes arbitrary information to the driver. The intent is that the information does not result in drawing being done.
		/// </summary>
		EMR_EXTESCAPE = 106,

		/// <summary>This record outputs a string.</summary>
		EMR_SMALLTEXTOUT = 108,

		/// <summary>
		/// This record forces the font mapper to match fonts based on their UniversalFontId in preference to their LogFont information.
		/// </summary>
		EMR_FORCEUFIMAPPING = 109,

		/// <summary>This record passes arbitrary information to the given named driver.</summary>
		EMR_NAMEDESCAPE = 110,

		/// <summary>
		/// This record specifies how to correct the entries of a logical palette object using Windows Color System (WCS) 1.0 values.
		/// </summary>
		EMR_COLORCORRECTPALETTE = 111,

		/// <summary>This record specifies a color profile in a file with a name consisting of ASCII characters, for graphics output.</summary>
		EMR_SETICMPROFILEA = 112,

		/// <summary>This record specifies a color profile in a file with a name consisting of Unicode characters, for graphics output.</summary>
		EMR_SETICMPROFILEW = 113,

		/// <summary>
		/// This record specifies a block transfer of pixels from a source bitmap to a destination rectangle, including alpha
		/// transparency data, according to a specified blending operation.
		/// </summary>
		EMR_ALPHABLEND = 114,

		/// <summary>This record specifies the order in which text and graphics are drawn.</summary>
		EMR_SETLAYOUT = 115,

		/// <summary>
		/// This record specifies a block transfer of pixels from a source bitmap to a destination rectangle, treating a specified color
		/// as transparent, stretching or compressing the output to fit the dimensions of the destination, if necessary.
		/// </summary>
		EMR_TRANSPARENTBLT = 116,

		/// <summary>This record specifies filling rectangles or triangles with gradients of color.</summary>
		EMR_GRADIENTFILL = 118,

		/// <summary>This record sets the UniversalFontIds (section 2.2.27) of linked fonts to use during character lookup.</summary>
		EMR_SETLINKEDUFIS = 119,

		/// <summary>This record specifies the amount of extra space to add to break characters for justification purposes.</summary>
		EMR_SETTEXTJUSTIFICATION = 120,

		/// <summary>
		/// This record specifies whether to perform color matching with a color profile that is specified in a file with a name
		/// consisting of Unicode characters.
		/// </summary>
		EMR_COLORMATCHTOTARGETW = 121,

		/// <summary>This record creates a logical color space object from a color profile with a name consisting of Unicode characters.</summary>
		EMR_CREATECOLORSPACEW = 122,
	}

	/// <summary>
	/// The <c>CloseEnhMetaFile</c> function closes an enhanced-metafile device context and returns a handle that identifies an
	/// enhanced-format metafile.
	/// </summary>
	/// <param name="hdc">Handle to an enhanced-metafile device context.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to an enhanced metafile.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application can use the enhanced-metafile handle returned by the <c>CloseEnhMetaFile</c> function to perform the following tasks:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Display a picture stored in an enhanced metafile</term>
	/// </item>
	/// <item>
	/// <term>Create copies of the enhanced metafile</term>
	/// </item>
	/// <item>
	/// <term>Enumerate, edit, or copy individual records in the enhanced metafile</term>
	/// </item>
	/// <item>
	/// <term>Retrieve an optional description of the metafile contents from the enhanced-metafile header</term>
	/// </item>
	/// <item>
	/// <term>Retrieve a copy of the enhanced-metafile header</term>
	/// </item>
	/// <item>
	/// <term>Retrieve a binary copy of the enhanced metafile</term>
	/// </item>
	/// <item>
	/// <term>Enumerate the colors in the optional palette</term>
	/// </item>
	/// <item>
	/// <term>Convert an enhanced-format metafile into a Windows-format metafile</term>
	/// </item>
	/// </list>
	/// <para>
	/// When the application no longer needs the enhanced metafile handle, it should release the handle by calling the DeleteEnhMetaFile function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-closeenhmetafile HENHMETAFILE CloseEnhMetaFile( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "3c4a0d8b-75a5-4729-8c64-476c36d01a90")]
	public static extern SafeHENHMETAFILE CloseEnhMetaFile(HDC hdc);

	/// <summary>
	/// <para>
	/// The <c>CloseMetaFile</c> function closes a metafile device context and returns a handle that identifies a Windows-format metafile.
	/// </para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with Windows-format metafiles. Enhanced-format metafiles provide
	/// superior functionality and are recommended for new applications. The corresponding function for an enhanced-format metafile is CloseEnhMetaFile.
	/// </para>
	/// </summary>
	/// <param name="hdc">Handle to a metafile device context used to create a Windows-format metafile.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to a Windows-format metafile.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>To convert a Windows-format metafile into a new enhanced-format metafile, use the SetWinMetaFileBits function.</para>
	/// <para>
	/// When an application no longer needs the Windows-format metafile handle, it should delete the handle by calling the DeleteMetaFile function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-closemetafile HMETAFILE CloseMetaFile( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "8e50457a-8ef8-4e71-8c56-38cfb277f57d")]
	public static extern HMETAFILE CloseMetaFile(HDC hdc);

	/// <summary>The <c>CopyEnhMetaFile</c> function copies the contents of an enhanced-format metafile to a specified file.</summary>
	/// <param name="hEnh">A handle to the enhanced metafile to be copied.</param>
	/// <param name="lpFileName">
	/// A pointer to the name of the destination file. If this parameter is <c>NULL</c>, the source metafile is copied to memory.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the copy of the enhanced metafile.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Where text arguments must use Unicode characters, use the <c>CopyEnhMetaFile</c> function as a wide-character function. Where
	/// text arguments must use characters from the Windows character set, use this function as an ANSI function.
	/// </para>
	/// <para>Applications can use metafiles stored in memory for temporary operations.</para>
	/// <para>
	/// When the application no longer needs the enhanced-metafile handle, it should delete the handle by calling the DeleteEnhMetaFile function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-copyenhmetafilea HENHMETAFILE CopyEnhMetaFileA( HENHMETAFILE
	// hEnh, LPCSTR lpFileName );
	[DllImport(Lib.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "7c428828-b239-41d4-926c-88caa0aa7214")]
	public static extern SafeHENHMETAFILE CopyEnhMetaFile(HENHMETAFILE hEnh, [Optional] string? lpFileName);

	/// <summary>
	/// <para>The <c>CopyMetaFile</c> function copies the content of a Windows-format metafile to the specified file.</para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with Windows-format metafiles. Enhanced-format metafiles provide
	/// superior functionality and are recommended for new applications. The corresponding function for an enhanced-format metafile is CopyEnhMetaFile.
	/// </para>
	/// </summary>
	/// <param name="arg1">A handle to the source Windows-format metafile.</param>
	/// <param name="arg2">
	/// A pointer to the name of the destination file. If this parameter is <c>NULL</c>, the source metafile is copied to memory.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the copy of the Windows-format metafile.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Where text arguments must use Unicode characters, use this function as a wide-character function. Where text arguments must use
	/// characters from the Windows character set, use this function as an ANSI function.
	/// </para>
	/// <para>
	/// When the application no longer needs the Windows-format metafile handle, it should delete the handle by calling the
	/// DeleteMetaFile function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-copymetafilea HMETAFILE CopyMetaFileA( HMETAFILE , LPCSTR );
	[DllImport(Lib.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "e9f97591-697b-47d0-a748-60fda4d5258c")]
	public static extern SafeHMETAFILE CopyMetaFile(HMETAFILE arg1, string arg2);

	/// <summary>
	/// <para>
	/// The <c>CreateEnhMetaFile</c> function creates a device context for an enhanced-format metafile. This device context can be used
	/// to store a device-independent picture.
	/// </para>
	/// </summary>
	/// <param name="hdc">
	/// <para>
	/// A handle to a reference device for the enhanced metafile. This parameter can be <c>NULL</c>; for more information, see Remarks.
	/// </para>
	/// </param>
	/// <param name="lpFilename">
	/// <para>
	/// A pointer to the file name for the enhanced metafile to be created. If this parameter is <c>NULL</c>, the enhanced metafile is
	/// memory based and its contents are lost when it is deleted by using the DeleteEnhMetaFile function.
	/// </para>
	/// </param>
	/// <param name="lprc">
	/// <para>
	/// A pointer to a RECT structure that specifies the dimensions (in .01-millimeter units) of the picture to be stored in the enhanced metafile.
	/// </para>
	/// </param>
	/// <param name="lpDesc">
	/// <para>
	/// A pointer to a string that specifies the name of the application that created the picture, as well as the picture's title. This
	/// parameter can be <c>NULL</c>; for more information, see Remarks.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the device context for the enhanced metafile.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Where text arguments must use Unicode characters, use the <c>CreateEnhMetaFile</c> function as a wide-character function. Where
	/// text arguments must use characters from the Windows character set, use this function as an ANSI function.
	/// </para>
	/// <para>
	/// The system uses the reference device identified by the hdcRef parameter to record the resolution and units of the device on which
	/// a picture originally appeared. If the hdcRef parameter is <c>NULL</c>, it uses the current display device for reference.
	/// </para>
	/// <para>
	/// The <c>left</c> and <c>top</c> members of the RECT structure pointed to by the <paramref name="lprc"/> parameter must be less
	/// than the <c>right</c> and <c>bottom</c> members, respectively. Points along the edges of the rectangle are included in the
	/// picture. If <paramref name="lprc"/> is <c>NULL</c>, the graphics device interface (GDI) computes the dimensions of the smallest
	/// rectangle that surrounds the picture drawn by the application. The <paramref name="lprc"/> parameter should be provided where possible.
	/// </para>
	/// <para>
	/// The string pointed to by the lpDescription parameter must contain a null character between the application name and the picture
	/// name and must terminate with two null characters for example, "XYZ Graphics Editor\0Bald Eagle\0\0", where \0 represents the null
	/// character. If lpDescription is <c>NULL</c>, there is no corresponding entry in the enhanced-metafile header.
	/// </para>
	/// <para>
	/// Applications use the device context created by this function to store a graphics picture in an enhanced metafile. The handle
	/// identifying this device context can be passed to any GDI function.
	/// </para>
	/// <para>
	/// After an application stores a picture in an enhanced metafile, it can display the picture on any output device by calling the
	/// PlayEnhMetaFile function. When displaying the picture, the system uses the rectangle pointed to by the <paramref name="lprc"/>
	/// parameter and the resolution data from the reference device to position and scale the picture.
	/// </para>
	/// <para>The device context returned by this function contains the same default attributes associated with any new device context.</para>
	/// <para>Applications must use the GetWinMetaFileBits function to convert an enhanced metafile to the older Windows metafile format.</para>
	/// <para>The file name for the enhanced metafile should use the .emf extension.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating an Enhanced Metafile.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createenhmetafilea HDC CreateEnhMetaFileA( HDC hdc, LPCSTR
	// lpFilename, const RECT *lprc, LPCSTR lpDesc );
	[DllImport(Lib.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "647f83ca-dca3-44af-a594-5f9ba2bd7607")]
	public static extern SafeHDC CreateEnhMetaFile([Optional] HDC hdc, [Optional] string? lpFilename, [In, Optional] PRECT lprc, [Optional] string? lpDesc);

	/// <summary>
	/// <para>The <c>CreateMetaFile</c> function creates a device context for a Windows-format metafile.</para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with Windows-format metafiles. Enhanced-format metafiles provide
	/// superior functionality and are recommended for new applications. The corresponding function for an enhanced-format metafile is CreateEnhMetaFile.
	/// </para>
	/// </summary>
	/// <param name="pszFile">
	/// A pointer to the file name for the Windows-format metafile to be created. If this parameter is <c>NULL</c>, the Windows-format
	/// metafile is memory based and its contents are lost when it is deleted by using the DeleteMetaFile function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the device context for the Windows-format metafile.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Where text arguments must use Unicode characters, use the <c>CreateMetaFile</c> function as a wide-character function. Where text
	/// arguments must use characters from the Windows character set, use this function as an ANSI function.
	/// </para>
	/// <para>
	/// <c>CreateMetaFile</c> is a Windows-format metafile function. This function supports only 16-bit Windows-based applications, which
	/// are listed in Windows-Format Metafiles. It does not record or play back GDI functions such as PolyBezier, which were not part of
	/// 16-bit Windows.
	/// </para>
	/// <para>
	/// The device context created by this function can be used to record GDI output functions in a Windows-format metafile. It cannot be
	/// used with GDI query functions such as GetTextColor. When the device context is used with a GDI output function, the return value
	/// of that function becomes <c>TRUE</c> if the function is recorded and <c>FALSE</c> otherwise. When an object is selected by using
	/// the SelectObject function, only a copy of the object is recorded. The object still belongs to the application.
	/// </para>
	/// <para>
	/// To create a scalable Windows-format metafile, record the graphics output in the MM_ANISOTROPIC mapping mode. The file cannot
	/// contain functions that modify the viewport origin and extents, nor can it contain device-dependent functions such as the
	/// SelectClipRgn function. Once created, the Windows metafile can be scaled and rendered to any output device-format by defining the
	/// viewport origin and extents of the picture before playing it.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createmetafilea HDC CreateMetaFileA( LPCSTR pszFile );
	[DllImport(Lib.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "81b3baae-f0e6-4b71-a6de-953ad3376dbd")]
	public static extern HDC CreateMetaFile(string pszFile);

	/// <summary>
	/// <para>The <c>DeleteEnhMetaFile</c> function deletes an enhanced-format metafile or an enhanced-format metafile handle.</para>
	/// </summary>
	/// <param name="hmf">
	/// <para>A handle to an enhanced metafile.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the hemf parameter identifies an enhanced metafile stored in memory, the <c>DeleteEnhMetaFile</c> function deletes the
	/// metafile. If hemf identifies a metafile stored on a disk, the function deletes the metafile handle but does not destroy the
	/// actual metafile. An application can retrieve the file by calling the GetEnhMetaFile function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Opening an Enhanced Metafile and Displaying Its Contents.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-deleteenhmetafile BOOL DeleteEnhMetaFile( HENHMETAFILE hmf );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "d3b93b3b-fa0b-4480-8348-19919c9e904d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteEnhMetaFile(HENHMETAFILE hmf);

	/// <summary>
	/// <para>The <c>DeleteMetaFile</c> function deletes a Windows-format metafile or Windows-format metafile handle.</para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with Windows-format metafiles. Enhanced-format metafiles provide
	/// superior functionality and are recommended for new applications. The corresponding function for an enhanced-format metafile is DeleteEnhMetaFile.
	/// </para>
	/// </summary>
	/// <param name="hmf">A handle to a Windows-format metafile.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// If the metafile identified by the hmf parameter is stored in memory (rather than on a disk), its content is lost when it is
	/// deleted by using the <c>DeleteMetaFile</c> function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-deletemetafile BOOL DeleteMetaFile( HMETAFILE hmf );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "51766282-f185-4e29-a36e-1069d9d61f7c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteMetaFile(HMETAFILE hmf);

	/// <summary>
	/// The <c>EnumEnhMetaFile</c> function enumerates the records within an enhanced-format metafile by retrieving each record and
	/// passing it to the specified callback function. The application-supplied callback function processes each record as required. The
	/// enumeration continues until the last record is processed or when the callback function returns zero.
	/// </summary>
	/// <param name="hdc">A handle to a device context. This handle is passed to the callback function.</param>
	/// <param name="hmf">A handle to an enhanced metafile.</param>
	/// <param name="proc">A pointer to the application-supplied callback function. For more information, see the EnhMetaFileProc function.</param>
	/// <param name="param">A pointer to optional callback-function data.</param>
	/// <param name="lpRect">
	/// A pointer to a RECT structure that specifies the coordinates, in logical units, of the picture's upper-left and lower-right corners.
	/// </param>
	/// <returns>
	/// <para>If the callback function successfully enumerates all the records in the enhanced metafile, the return value is nonzero.</para>
	/// <para>
	/// If the callback function does not successfully enumerate all the records in the enhanced metafile, the return value is zero.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Points along the edge of the rectangle pointed to by the lpRect parameter are included in the picture. If the hdc parameter is
	/// <c>NULL</c>, the system ignores lpRect.
	/// </para>
	/// <para>
	/// If the callback function calls the PlayEnhMetaFileRecord function, hdc must identify a valid device context. The system uses the
	/// device context's transformation and mapping mode to transform the picture displayed by the <c>PlayEnhMetaFileRecord</c> function.
	/// </para>
	/// <para>You can use the <c>EnumEnhMetaFile</c> function to embed one enhanced-metafile within another.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-enumenhmetafile BOOL EnumEnhMetaFile( HDC hdc, HENHMETAFILE
	// hmf, ENHMFENUMPROC proc, LPVOID param, const RECT *lpRect );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "bef5f43e-219a-4f8a-986d-290e29e17c4e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumEnhMetaFile([Optional] HDC hdc, HENHMETAFILE hmf, EnhMetaFileProc proc, [Optional] IntPtr param, [In, Optional] PRECT lpRect);

	/// <summary>
	/// <para>
	/// The <c>EnumMetaFile</c> function enumerates the records within a Windows-format metafile by retrieving each record and passing it
	/// to the specified callback function. The application-supplied callback function processes each record as required. The enumeration
	/// continues until the last record is processed or when the callback function returns zero.
	/// </para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with Windows-format metafiles. Enhanced-format metafiles provide
	/// superior functionality and are recommended for new applications. The corresponding function for an enhanced-format metafile is EnumEnhMetaFile.
	/// </para>
	/// </summary>
	/// <param name="hdc">Handle to a device context. This handle is passed to the callback function.</param>
	/// <param name="hmf">Handle to a Windows-format metafile.</param>
	/// <param name="proc">Pointer to an application-supplied callback function. For more information, see EnumMetaFileProc.</param>
	/// <param name="param">Pointer to optional data.</param>
	/// <returns>
	/// <para>If the callback function successfully enumerates all the records in the Windows-format metafile, the return value is nonzero.</para>
	/// <para>
	/// If the callback function does not successfully enumerate all the records in the Windows-format metafile, the return value is zero.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>To convert a Windows-format metafile into an enhanced-format metafile, use the SetWinMetaFileBits function.</para>
	/// <para>You can use the <c>EnumMetaFile</c> function to embed one Windows-format metafile within another.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-enummetafile BOOL EnumMetaFile( HDC hdc, HMETAFILE hmf,
	// MFENUMPROC proc, LPARAM param );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "b11c7467-64a9-442b-8dee-26e15f64a26b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumMetaFile([Optional] HDC hdc, HMETAFILE hmf, EnumMetaFileProc proc, [Optional] IntPtr param);

	/// <summary>The <c>GdiComment</c> function copies a comment from a buffer into a specified enhanced-format metafile.</summary>
	/// <param name="hdc">A handle to an enhanced-metafile device context.</param>
	/// <param name="nSize">The length of the comment buffer, in bytes.</param>
	/// <param name="lpData">A pointer to the buffer that contains the comment.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A comment can include any kind of private information, for example, the source of a picture and the date it was created. A
	/// comment should begin with an application signature, followed by the data.
	/// </para>
	/// <para>
	/// Comments should not contain application-specific or position-specific data. Position-specific data specifies the location of a
	/// record, and it should not be included because one metafile may be embedded within another metafile.
	/// </para>
	/// <para>
	/// A public comment is a comment that begins with the comment signature identifier GDICOMMENT_IDENTIFIER. The following public
	/// comments are defined.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>GDICOMMENT_WINDOWS_METAFILE</term>
	/// <term>
	/// The GDICOMMENT_WINDOWS_METAFILE public comment contains a Windows-format metafile that is equivalent to an enhanced-format
	/// metafile. This comment is written only by the SetWinMetaFileBits function. The comment record, if given, follows the
	/// ENHMETAHEADER metafile record. The comment has the following form:
	/// </term>
	/// </listheader>
	/// </list>
	/// <list type="table">
	/// <listheader>
	/// <term>GDICOMMENT_BEGINGROUP</term>
	/// <term>
	/// The GDICOMMENT_BEGINGROUP public comment identifies the beginning of a group of drawing records. It identifies an object within
	/// an enhanced metafile. The comment has the following form:
	/// </term>
	/// </listheader>
	/// </list>
	/// <list type="table">
	/// <listheader>
	/// <term>GDICOMMENT_ENDGROUP</term>
	/// <term>
	/// The GDICOMMENT_ENDGROUP public comment identifies the end of a group of drawing records. The GDICOMMENT_BEGINGROUP comment and
	/// the GDICOMMENT_ENDGROUP comment must be included in a pair and may be nested. The comment has the following form:
	/// </term>
	/// </listheader>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gdicomment BOOL GdiComment( HDC hdc, UINT nSize, const BYTE
	// *lpData );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "80ed11fc-89f8-47ab-8b3b-c817733bd385")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GdiComment(HDC hdc, uint nSize, [In] byte[] lpData);

	/// <summary>
	/// <para>
	/// The <c>GetEnhMetaFile</c> function creates a handle that identifies the enhanced-format metafile stored in the specified file.
	/// </para>
	/// </summary>
	/// <param name="lpName">
	/// <para>A pointer to a null-terminated string that specifies the name of an enhanced metafile.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the enhanced metafile.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When the application no longer needs an enhanced-metafile handle, it should delete the handle by calling the DeleteEnhMetaFile function.
	/// </para>
	/// <para>
	/// A Windows-format metafile must be converted to the enhanced format before it can be processed by the <c>GetEnhMetaFile</c>
	/// function. To convert the file, use the SetWinMetaFileBits function.
	/// </para>
	/// <para>
	/// Where text arguments must use Unicode characters, use this function as a wide-character function. Where text arguments must use
	/// characters from the Windows character set, use this function as an ANSI function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Opening an Enhanced Metafile and Displaying Its Contents.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-getenhmetafilea HENHMETAFILE GetEnhMetaFileA( LPCSTR lpName );
	[DllImport(Lib.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "bcb9611e-8e4e-4f87-8a1e-dedbe0042821")]
	public static extern SafeHENHMETAFILE GetEnhMetaFile(string lpName);

	/// <summary>
	/// The <c>GetEnhMetaFileBits</c> function retrieves the contents of the specified enhanced-format metafile and copies them into a buffer.
	/// </summary>
	/// <param name="hEMF">A handle to the enhanced metafile.</param>
	/// <param name="nSize">The size, in bytes, of the buffer to receive the data.</param>
	/// <param name="lpData">
	/// A pointer to a buffer that receives the metafile data. The buffer must be sufficiently large to contain the data. If lpbBuffer is
	/// <c>NULL</c>, the function returns the size necessary to hold the data.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds and the buffer pointer is <c>NULL</c>, the return value is the size of the enhanced metafile, in bytes.
	/// </para>
	/// <para>
	/// If the function succeeds and the buffer pointer is a valid pointer, the return value is the number of bytes copied to the buffer.
	/// </para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// After the enhanced-metafile bits are retrieved, they can be used to create a memory-based metafile by calling the
	/// SetEnhMetaFileBits function.
	/// </para>
	/// <para>
	/// The <c>GetEnhMetaFileBits</c> function does not invalidate the enhanced-metafile handle. The application must call the
	/// DeleteEnhMetaFile function to delete the handle when it is no longer needed.
	/// </para>
	/// <para>
	/// The metafile contents retrieved by this function are in the enhanced format. To retrieve the metafile contents in the Windows
	/// format, use the GetWinMetaFileBits function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getenhmetafilebits UINT GetEnhMetaFileBits( HENHMETAFILE hEMF,
	// UINT nSize, LPBYTE lpData );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "2bbfa0da-5b1e-4843-9777-c2e4c5fd3b78")]
	public static extern uint GetEnhMetaFileBits(HENHMETAFILE hEMF, uint nSize, byte[] lpData);

	/// <summary>
	/// The <c>GetEnhMetaFileDescription</c> function retrieves an optional text description from an enhanced-format metafile and copies
	/// the string to the specified buffer.
	/// </summary>
	/// <param name="hemf">A handle to the enhanced metafile.</param>
	/// <param name="cchBuffer">The size, in characters, of the buffer to receive the data. Only this many characters will be copied.</param>
	/// <param name="lpDescription">A pointer to a buffer that receives the optional text description.</param>
	/// <returns>
	/// <para>
	/// If the optional text description exists and the buffer pointer is <c>NULL</c>, the return value is the length of the text string,
	/// in characters.
	/// </para>
	/// <para>
	/// If the optional text description exists and the buffer pointer is a valid pointer, the return value is the number of characters
	/// copied into the buffer.
	/// </para>
	/// <para>If the optional text description does not exist, the return value is zero.</para>
	/// <para>If the function fails, the return value is GDI_ERROR.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The optional text description contains two strings, the first identifying the application that created the enhanced metafile and
	/// the second identifying the picture contained in the metafile. The strings are separated by a null character and terminated with
	/// two null charactersfor example, "XYZ Graphics Editor\0Bald Eagle\0\0" where \0 represents the null character.
	/// </para>
	/// <para>
	/// Where text arguments must use Unicode characters, use this function as a wide-character function. Where text arguments must use
	/// characters from the Windows character set, use this function as an ANSI function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getenhmetafiledescriptiona UINT GetEnhMetaFileDescriptionA(
	// HENHMETAFILE hemf, UINT cchBuffer, LPSTR lpDescription );
	[DllImport(Lib.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "51f4f617-fe53-4463-b222-cb6860d15dd6")]
	public static extern uint GetEnhMetaFileDescription(HENHMETAFILE hemf, uint cchBuffer, StringBuilder lpDescription);

	/// <summary>
	/// The <c>GetEnhMetaFileHeader</c> function retrieves the record containing the header for the specified enhanced-format metafile.
	/// </summary>
	/// <param name="hemf">A handle to the enhanced metafile for which the header is to be retrieved.</param>
	/// <param name="nSize">The size, in bytes, of the buffer to receive the data. Only this many bytes will be copied.</param>
	/// <param name="lpEnhMetaHeader">
	/// A pointer to an ENHMETAHEADER structure that receives the header record. If this parameter is <c>NULL</c>, the function returns
	/// the size of the header record.
	/// </param>
	/// <returns>
	/// If the function succeeds and the structure pointer is <c>NULL</c>, the return value is the size of the record that contains the
	/// header; if the structure pointer is a valid pointer, the return value is the number of bytes copied. Otherwise, it is zero.
	/// </returns>
	/// <remarks>
	/// <para>
	/// An enhanced-metafile header contains such information as the metafile's size, in bytes; the dimensions of the picture stored in
	/// the metafile; the number of records stored in the metafile; the offset to the optional text description; the size of the optional
	/// palette, and the resolution of the device on which the picture was created.
	/// </para>
	/// <para>The record that contains the enhanced-metafile header is always the first record in the metafile.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getenhmetafileheader UINT GetEnhMetaFileHeader( HENHMETAFILE
	// hemf, UINT nSize, LPENHMETAHEADER lpEnhMetaHeader );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "c42bcbe2-2e8f-42bd-a8e3-2827c6563300")]
	public static extern uint GetEnhMetaFileHeader(HENHMETAFILE hemf, uint nSize, IntPtr lpEnhMetaHeader);

	/// <summary>
	/// The <c>GetEnhMetaFileHeader</c> function retrieves the record containing the header for the specified enhanced-format metafile.
	/// </summary>
	/// <param name="hemf">A handle to the enhanced metafile for which the header is to be retrieved.</param>
	/// <returns>An ENHMETAHEADER structure with the header record.</returns>
	/// <remarks>
	/// <para>
	/// An enhanced-metafile header contains such information as the metafile's size, in bytes; the dimensions of the picture stored in
	/// the metafile; the number of records stored in the metafile; the offset to the optional text description; the size of the optional
	/// palette, and the resolution of the device on which the picture was created.
	/// </para>
	/// <para>The record that contains the enhanced-metafile header is always the first record in the metafile.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getenhmetafileheader UINT GetEnhMetaFileHeader( HENHMETAFILE
	// hemf, UINT nSize, LPENHMETAHEADER lpEnhMetaHeader );
	[PInvokeData("wingdi.h", MSDNShortId = "c42bcbe2-2e8f-42bd-a8e3-2827c6563300")]
	public static ENHMETAHEADER GetEnhMetaFileHeader(HENHMETAFILE hemf)
	{
		var hdr = ENHMETAHEADER.Default;
		using (var mem = SafeHGlobalHandle.CreateFromStructure(hdr))
		{
			if (GetEnhMetaFileHeader(hemf, hdr.nSize, mem) != hdr.nSize)
				Win32Error.ThrowLastError();
			return mem.ToStructure<ENHMETAHEADER>();
		}
	}

	/// <summary>
	/// The <c>GetEnhMetaFilePaletteEntries</c> function retrieves optional palette entries from the specified enhanced metafile.
	/// </summary>
	/// <param name="hemf">A handle to the enhanced metafile.</param>
	/// <param name="nNumEntries">The number of entries to be retrieved from the optional palette.</param>
	/// <param name="lpPaletteEntries">
	/// A pointer to an array of PALETTEENTRY structures that receives the palette colors. The array must contain at least as many
	/// structures as there are entries specified by the cEntries parameter.
	/// </param>
	/// <returns>
	/// If the array pointer is <c>NULL</c> and the enhanced metafile contains an optional palette, the return value is the number of
	/// entries in the enhanced metafile's palette; if the array pointer is a valid pointer and the enhanced metafile contains an
	/// optional palette, the return value is the number of entries copied; if the metafile does not contain an optional palette, the
	/// return value is zero. Otherwise, the return value is GDI_ERROR.
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application can store an optional palette in an enhanced metafile by calling the CreatePalette and SetPaletteEntries functions
	/// before creating the picture and storing it in the metafile. By doing this, the application can achieve consistent colors when the
	/// picture is displayed on a variety of devices.
	/// </para>
	/// <para>
	/// An application that displays a picture stored in an enhanced metafile can call the <c>GetEnhMetaFilePaletteEntries</c> function
	/// to determine whether the optional palette exists. If it does, the application can call the <c>GetEnhMetaFilePaletteEntries</c>
	/// function a second time to retrieve the palette entries and then create a logical palette (by using the CreatePalette function),
	/// select it into its device context (by using the SelectPalette function), and then realize it (by using the RealizePalette
	/// function). After the logical palette has been realized, calling the PlayEnhMetaFile function displays the picture using its
	/// original colors.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getenhmetafilepaletteentries UINT
	// GetEnhMetaFilePaletteEntries( HENHMETAFILE hemf, UINT nNumEntries, LPPALETTEENTRY lpPaletteEntries );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "2d61fd6a-cebd-457e-ad00-d3e8bd15584a")]
	public static extern uint GetEnhMetaFilePaletteEntries(HENHMETAFILE hemf, uint nNumEntries, [Out] PALETTEENTRY[] lpPaletteEntries);

	/// <summary>
	/// <para>[GetMetaFile is no longer available for use as of Windows 2000. Instead, use GetEnhMetaFile.]</para>
	/// <para>The <c>GetMetaFile</c> function creates a handle that identifies the metafile stored in the specified file.</para>
	/// </summary>
	/// <param name="lpName">A pointer to a null-terminated string that specifies the name of a metafile.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the metafile.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// This function is not implemented in the Win32 API. It is provided for compatibility with 16-bit versions of Windows. In Win32
	/// applications, use the GetEnhMetaFile function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getmetafilea HMETAFILE GetMetaFileA( LPCSTR lpName );
	[DllImport(Lib.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "56A602C4-AE4D-46DE-B5DA-66A68E3A16BF")]
	public static extern SafeHMETAFILE GetMetaFile(string lpName);

	/// <summary>
	/// <para>
	/// The <c>GetMetaFileBitsEx</c> function retrieves the contents of a Windows-format metafile and copies them into the specified buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with Windows-format metafiles. Enhanced-format metafiles provide
	/// superior functionality and are recommended for new applications. The corresponding function for an enhanced-format metafile is GetEnhMetaFileBits.
	/// </para>
	/// </summary>
	/// <param name="hMF">A handle to a Windows-format metafile.</param>
	/// <param name="cbBuffer">The size, in bytes, of the buffer to receive the data.</param>
	/// <param name="lpData">
	/// A pointer to a buffer that receives the metafile data. The buffer must be sufficiently large to contain the data. If lpvData is
	/// <c>NULL</c>, the function returns the number of bytes required to hold the data.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds and the buffer pointer is <c>NULL</c>, the return value is the number of bytes required for the buffer;
	/// if the function succeeds and the buffer pointer is a valid pointer, the return value is the number of bytes copied.
	/// </para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// After the Windows-metafile bits are retrieved, they can be used to create a memory-based metafile by calling the
	/// SetMetaFileBitsEx function.
	/// </para>
	/// <para>
	/// The <c>GetMetaFileBitsEx</c> function does not invalidate the metafile handle. An application must delete this handle by calling
	/// the DeleteMetaFile function.
	/// </para>
	/// <para>To convert a Windows-format metafile into an enhanced-format metafile, use the SetWinMetaFileBits function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getmetafilebitsex UINT GetMetaFileBitsEx( HMETAFILE hMF, UINT
	// cbBuffer, LPVOID lpData );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "6ca6de2e-79cb-4503-a0d7-f616b8e383eb")]
	public static extern uint GetMetaFileBitsEx(HMETAFILE hMF, uint cbBuffer, [In, Optional] byte[]? lpData);

	/// <summary>
	/// The <c>GetWinMetaFileBits</c> function converts the enhanced-format records from a metafile into Windows-format records and
	/// stores the converted records in the specified buffer.
	/// </summary>
	/// <param name="hemf">A handle to the enhanced metafile.</param>
	/// <param name="cbData16">The size, in bytes, of the buffer into which the converted records are to be copied.</param>
	/// <param name="pData16">
	/// A pointer to the buffer that receives the converted records. If lpbBuffer is <c>NULL</c>, <c>GetWinMetaFileBits</c> returns the
	/// number of bytes required to store the converted metafile records.
	/// </param>
	/// <param name="iMapMode">The mapping mode to use in the converted metafile.</param>
	/// <param name="hdcRef">A handle to the reference device context.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds and the buffer pointer is <c>NULL</c>, the return value is the number of bytes required to store the
	/// converted records; if the function succeeds and the buffer pointer is a valid pointer, the return value is the size of the
	/// metafile data in bytes.
	/// </para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function converts an enhanced metafile into a Windows-format metafile so that its picture can be displayed in an application
	/// that recognizes the older format.
	/// </para>
	/// <para>The system uses the reference device context to determine the resolution of the converted metafile.</para>
	/// <para>
	/// The <c>GetWinMetaFileBits</c> function does not invalidate the enhanced metafile handle. An application should call the
	/// DeleteEnhMetaFile function to release the handle when it is no longer needed.
	/// </para>
	/// <para>To create a scalable Windows-format metafile, specify MM_ANISOTROPIC as the fnMapMode parameter.</para>
	/// <para>The upper-left corner of the metafile picture is always mapped to the origin of the reference device.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getwinmetafilebits UINT GetWinMetaFileBits( HENHMETAFILE hemf,
	// UINT cbData16, LPBYTE pData16, INT iMapMode, HDC hdcRef );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "db61ea3a-44d0-4769-acb4-05a982d3f06f")]
	public static extern uint GetWinMetaFileBits(HENHMETAFILE hemf, uint cbData16, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pData16, MapMode iMapMode, HDC hdcRef);

	/// <summary>The <c>PlayEnhMetaFile</c> function displays the picture stored in the specified enhanced-format metafile.</summary>
	/// <param name="hdc">A handle to the device context for the output device on which the picture will appear.</param>
	/// <param name="hmf">A handle to the enhanced metafile.</param>
	/// <param name="lprect">
	/// A pointer to a RECT structure that contains the coordinates of the bounding rectangle used to display the picture. The
	/// coordinates are specified in logical units.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When an application calls the <c>PlayEnhMetaFile</c> function, the system uses the picture frame in the enhanced-metafile header
	/// to map the picture onto the rectangle pointed to by the lpRect parameter. (This picture may be sheared or rotated by setting the
	/// world transform in the output device before calling <c>PlayEnhMetaFile</c>.) Points along the edges of the rectangle are included
	/// in the picture.
	/// </para>
	/// <para>
	/// An enhanced-metafile picture can be clipped by defining the clipping region in the output device before playing the enhanced metafile.
	/// </para>
	/// <para>
	/// If an enhanced metafile contains an optional palette, an application can achieve consistent colors by setting up a color palette
	/// on the output device before calling <c>PlayEnhMetaFile</c>. To retrieve the optional palette, use the
	/// GetEnhMetaFilePaletteEntries function.
	/// </para>
	/// <para>
	/// An enhanced metafile can be embedded in a newly created enhanced metafile by calling <c>PlayEnhMetaFile</c> and playing the
	/// source enhanced metafile into the device context for the new enhanced metafile.
	/// </para>
	/// <para>
	/// The states of the output device context are preserved by this function. Any object created but not deleted in the enhanced
	/// metafile is deleted by this function.
	/// </para>
	/// <para>
	/// To stop this function, an application can call the CancelDC function from another thread to terminate the operation. In this
	/// case, the function returns <c>FALSE</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Opening an Enhanced Metafile and Displaying Its Contents.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-playenhmetafile BOOL PlayEnhMetaFile( HDC hdc, HENHMETAFILE
	// hmf, const RECT *lprect );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "51e8937b-0c42-49fe-8930-7af303fce788")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PlayEnhMetaFile(HDC hdc, HENHMETAFILE hmf, [In, Optional] PRECT lprect);

	/// <summary>
	/// The <c>PlayEnhMetaFileRecord</c> function plays an enhanced-metafile record by executing the graphics device interface (GDI)
	/// functions identified by the record.
	/// </summary>
	/// <param name="hdc">A handle to the device context passed to the EnumEnhMetaFile function.</param>
	/// <param name="pht">
	/// A pointer to a table of handles to GDI objects used when playing the metafile. The first entry in this table contains the
	/// enhanced-metafile handle.
	/// </param>
	/// <param name="pmr">A pointer to the enhanced-metafile record to be played.</param>
	/// <param name="cht">The number of handles in the handle table.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>This is an enhanced-metafile function.</para>
	/// <para>
	/// An application typically uses <c>PlayEnhMetaFileRecord</c> in conjunction with the EnumEnhMetaFile function to process and play
	/// an enhanced-format metafile one record at a time.
	/// </para>
	/// <para>
	/// The hdc, lpHandletable, and nHandles parameters must be exactly those passed to the EnhMetaFileProc callback procedure by the
	/// EnumEnhMetaFile function.
	/// </para>
	/// <para>If <c>PlayEnhMetaFileRecord</c> does not recognize a record, it ignores the record and returns <c>TRUE</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-playenhmetafilerecord BOOL PlayEnhMetaFileRecord( HDC hdc,
	// LPHANDLETABLE pht, const ENHMETARECORD *pmr, UINT cht );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "3eec8c8d-b99f-4500-9d18-b819c097f341")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PlayEnhMetaFileRecord(HDC hdc, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] HGDIOBJ[] pht, [In] ENHMETARECORD pmr, uint cht);

	/// <summary>
	/// <para>The <c>PlayMetaFile</c> function displays the picture stored in the given Windows-format metafile on the specified device.</para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with Windows-format metafiles. Enhanced-format metafiles provide
	/// superior functionality and are recommended for new applications. The corresponding function for an enhanced-format metafile is PlayEnhMetaFile.
	/// </para>
	/// </summary>
	/// <param name="hdc">Handle to a device context.</param>
	/// <param name="hmf">Handle to a Windows-format metafile.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>To convert a Windows-format metafile into an enhanced format metafile, use the SetWinMetaFileBits function.</para>
	/// <para>A Windows-format metafile can be played multiple times.</para>
	/// <para>
	/// A Windows-format metafile can be embedded in a second Windows-format metafile by calling the <c>PlayMetaFile</c> function and
	/// playing the source metafile into the device context for the target metafile.
	/// </para>
	/// <para>Any object created but not deleted in the Windows-format metafile is deleted by this function.</para>
	/// <para>
	/// To stop this function, an application can call the CancelDC function from another thread to terminate the operation. In this
	/// case, the function returns <c>FALSE</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-playmetafile BOOL PlayMetaFile( HDC hdc, HMETAFILE hmf );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "044894df-dc8a-41b2-8810-e0a1b8bc19d8")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PlayMetaFile(HDC hdc, HMETAFILE hmf);

	/// <summary>
	/// <para>
	/// The <c>PlayMetaFileRecord</c> function plays a Windows-format metafile record by executing the graphics device interface (GDI)
	/// function contained within that record.
	/// </para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with Windows-format metafiles. Enhanced-format metafiles provide
	/// superior functionality and are recommended for new applications. The corresponding function for an enhanced-format metafile is PlayEnhMetaFileRecord.
	/// </para>
	/// </summary>
	/// <param name="hdc">A handle to a device context.</param>
	/// <param name="lpHandleTable">
	/// A pointer to a HANDLETABLE structure representing the table of handles to GDI objects used when playing the metafile.
	/// </param>
	/// <param name="lpMR">A pointer to the Windows-format metafile record.</param>
	/// <param name="noObjs">The number of handles in the handle table.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>To convert a Windows-format metafile into an enhanced-format metafile, use the SetWinMetaFileBits function.</para>
	/// <para>
	/// An application typically uses <c>PlayMetaFileRecord</c> in conjunction with the EnumMetaFile function to process and play a
	/// Windows-format metafile one record at a time.
	/// </para>
	/// <para>
	/// The lpHandletable and nHandles parameters must be identical to those passed to the EnumMetaFileProc callback procedure by EnumMetaFile.
	/// </para>
	/// <para>If the <c>PlayMetaFileRecord</c> function does not recognize a record, it ignores the record and returns <c>TRUE</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-playmetafilerecord BOOL PlayMetaFileRecord( HDC hdc,
	// LPHANDLETABLE lpHandleTable, LPMETARECORD lpMR, UINT noObjs );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "bea22981-dc77-4de2-b6dc-d6a4f4b74bbd")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PlayMetaFileRecord(HDC hdc, [In] HGDIOBJ[] lpHandleTable, METARECORD lpMR, uint noObjs);

	/// <summary>The <c>SetEnhMetaFileBits</c> function creates a memory-based enhanced-format metafile from the specified data.</summary>
	/// <param name="nSize">Specifies the size, in bytes, of the data provided.</param>
	/// <param name="pb">
	/// Pointer to a buffer that contains enhanced-metafile data. (It is assumed that the data in the buffer was obtained by calling the
	/// GetEnhMetaFileBits function.)
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to a memory-based enhanced metafile.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When the application no longer needs the enhanced-metafile handle, it should delete the handle by calling the DeleteEnhMetaFile function.
	/// </para>
	/// <para>
	/// The <c>SetEnhMetaFileBits</c> function does not accept metafile data in the Windows format. To import Windows-format metafiles,
	/// use the SetWinMetaFileBits function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setenhmetafilebits HENHMETAFILE SetEnhMetaFileBits( UINT
	// nSize, const BYTE *pb );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "0f21ed97-e37f-4b44-a2eb-b8e284b3dc4b")]
	public static extern SafeHENHMETAFILE SetEnhMetaFileBits(uint nSize, [In] byte[] pb);

	/// <summary>
	/// <para>The <c>SetMetaFileBitsEx</c> function creates a memory-based Windows-format metafile from the supplied data.</para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with Windows-format metafiles. Enhanced-format metafiles provide
	/// superior functionality and are recommended for new applications. The corresponding function for an enhanced-format metafile is SetEnhMetaFileBits.
	/// </para>
	/// </summary>
	/// <param name="cbBuffer">Specifies the size, in bytes, of the Windows-format metafile.</param>
	/// <param name="lpData">
	/// Pointer to a buffer that contains the Windows-format metafile. (It is assumed that the data was obtained by using the
	/// GetMetaFileBitsEx function.)
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to a memory-based Windows-format metafile.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>To convert a Windows-format metafile into an enhanced-format metafile, use the SetWinMetaFileBits function.</para>
	/// <para>
	/// When the application no longer needs the metafile handle returned by <c>SetMetaFileBitsEx</c>, it should delete it by calling the
	/// DeleteMetaFile function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setmetafilebitsex HMETAFILE SetMetaFileBitsEx( UINT cbBuffer,
	// const BYTE *lpData );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "232eeba9-f579-4b5f-a31a-416aeb56a909")]
	public static extern SafeHMETAFILE SetMetaFileBitsEx(uint cbBuffer, [In] byte[] lpData);

	/// <summary>
	/// The <c>SetWinMetaFileBits</c> function converts a metafile from the older Windows format to the new enhanced format and stores
	/// the new metafile in memory.
	/// </summary>
	/// <param name="nSize">The size, in bytes, of the buffer that contains the Windows-format metafile.</param>
	/// <param name="lpMeta16Data">
	/// A pointer to a buffer that contains the Windows-format metafile data. (It is assumed that the data was obtained by using the
	/// GetMetaFileBitsEx or GetWinMetaFileBits function.)
	/// </param>
	/// <param name="hdcRef">A handle to a reference device context.</param>
	/// <param name="lpMFP">
	/// A pointer to a METAFILEPICT structure that contains the suggested size of the metafile picture and the mapping mode that was used
	/// when the picture was created.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to a memory-based enhanced metafile.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Windows uses the reference device context's resolution data and the data in the METAFILEPICT structure to scale a picture. If the
	/// hdcRef parameter is <c>NULL</c>, the system uses resolution data for the current output device. If the lpmfp parameter is
	/// <c>NULL</c>, the system uses the MM_ANISOTROPIC mapping mode to scale the picture so that it fits the entire device surface. The
	/// <c>hMF</c> member of the <c>METAFILEPICT</c> structure is not used.
	/// </para>
	/// <para>
	/// When the application no longer needs the enhanced metafile handle, it should delete it by calling the DeleteEnhMetaFile function.
	/// </para>
	/// <para>The handle returned by this function can be used with other enhanced-metafile functions.</para>
	/// <para>
	/// If the reference device context is not identical to the device in which the metafile was originally created, some GDI functions
	/// that use device units may not draw the picture correctly.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setwinmetafilebits HENHMETAFILE SetWinMetaFileBits( UINT
	// nSize, const BYTE *lpMeta16Data, HDC hdcRef, const METAFILEPICT *lpMFP );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "b7170c8a-da5f-4946-9c56-da3cffc84567")]
	public static extern SafeHENHMETAFILE SetWinMetaFileBits(uint nSize, [In] byte[] lpMeta16Data, [Optional] HDC hdcRef, in METAFILEPICT lpMFP);

	/// <summary>
	/// The <c>SetWinMetaFileBits</c> function converts a metafile from the older Windows format to the new enhanced format and stores
	/// the new metafile in memory.
	/// </summary>
	/// <param name="nSize">The size, in bytes, of the buffer that contains the Windows-format metafile.</param>
	/// <param name="lpMeta16Data">
	/// A pointer to a buffer that contains the Windows-format metafile data. (It is assumed that the data was obtained by using the
	/// GetMetaFileBitsEx or GetWinMetaFileBits function.)
	/// </param>
	/// <param name="hdcRef">A handle to a reference device context.</param>
	/// <param name="lpMFP">
	/// A pointer to a METAFILEPICT structure that contains the suggested size of the metafile picture and the mapping mode that was used
	/// when the picture was created.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to a memory-based enhanced metafile.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Windows uses the reference device context's resolution data and the data in the METAFILEPICT structure to scale a picture. If the
	/// hdcRef parameter is <c>NULL</c>, the system uses resolution data for the current output device. If the lpmfp parameter is
	/// <c>NULL</c>, the system uses the MM_ANISOTROPIC mapping mode to scale the picture so that it fits the entire device surface. The
	/// <c>hMF</c> member of the <c>METAFILEPICT</c> structure is not used.
	/// </para>
	/// <para>
	/// When the application no longer needs the enhanced metafile handle, it should delete it by calling the DeleteEnhMetaFile function.
	/// </para>
	/// <para>The handle returned by this function can be used with other enhanced-metafile functions.</para>
	/// <para>
	/// If the reference device context is not identical to the device in which the metafile was originally created, some GDI functions
	/// that use device units may not draw the picture correctly.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setwinmetafilebits HENHMETAFILE SetWinMetaFileBits( UINT
	// nSize, const BYTE *lpMeta16Data, HDC hdcRef, const METAFILEPICT *lpMFP );
	[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "b7170c8a-da5f-4946-9c56-da3cffc84567")]
	public static extern SafeHENHMETAFILE SetWinMetaFileBits(uint nSize, [In] byte[] lpMeta16Data, [Optional] HDC hdcRef, [Optional] IntPtr lpMFP);

	/// <summary>
	/// <para>
	/// The <c>ENHMETAHEADER</c> structure contains enhanced-metafile data such as the dimensions of the picture stored in the enhanced
	/// metafile, the count of records in the enhanced metafile, the resolution of the device on which the picture was created, and so on.
	/// </para>
	/// <para>This structure is always the first record in an enhanced metafile.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-enhmetaheader typedef struct tagENHMETAHEADER { DWORD iType;
	// DWORD nSize; RECTL rclBounds; RECTL rclFrame; DWORD dSignature; DWORD nVersion; DWORD nBytes; DWORD nRecords; WORD nHandles; WORD
	// sReserved; DWORD nDescription; DWORD offDescription; DWORD nPalEntries; SIZEL szlDevice; SIZEL szlMillimeters; DWORD
	// cbPixelFormat; DWORD offPixelFormat; DWORD bOpenGL; SIZEL szlMicrometers; } ENHMETAHEADER, *PENHMETAHEADER, *LPENHMETAHEADER;
	[PInvokeData("wingdi.h", MSDNShortId = "8e5f9a51-a995-48be-b936-1766fccb603a")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ENHMETAHEADER
	{
		/// <summary>The record type. This member must specify the value assigned to the EMR_HEADER constant.</summary>
		public RecordType iType;

		/// <summary>The structure size, in bytes.</summary>
		public uint nSize;

		/// <summary>
		/// The dimensions, in device units, of the smallest rectangle that can be drawn around the picture stored in the metafile. This
		/// rectangle is supplied by graphics device interface (GDI). Its dimensions include the right and bottom edges.
		/// </summary>
		public RECT rclBounds;

		/// <summary>
		/// The dimensions, in .01 millimeter units, of a rectangle that surrounds the picture stored in the metafile. This rectangle
		/// must be supplied by the application that creates the metafile. Its dimensions include the right and bottom edges.
		/// </summary>
		public RECT rclFrame;

		/// <summary>A signature. This member must specify the value assigned to the ENHMETA_SIGNATURE constant.</summary>
		public uint dSignature;

		/// <summary>The metafile version. The current version value is 0x10000.</summary>
		public uint nVersion;

		/// <summary>The size of the enhanced metafile, in bytes.</summary>
		public uint nBytes;

		/// <summary>The number of records in the enhanced metafile.</summary>
		public uint nRecords;

		/// <summary>The number of handles in the enhanced-metafile handle table. (Index zero in this table is reserved.)</summary>
		public ushort nHandles;

		/// <summary>Reserved; must be zero.</summary>
		public ushort sReserved;

		/// <summary>
		/// The number of characters in the array that contains the description of the enhanced metafile's contents. This member should
		/// be set to zero if the enhanced metafile does not contain a description string.
		/// </summary>
		public uint nDescription;

		/// <summary>
		/// The offset from the beginning of the <c>ENHMETAHEADER</c> structure to the array that contains the description of the
		/// enhanced metafile's contents. This member should be set to zero if the enhanced metafile does not contain a description string.
		/// </summary>
		public uint offDescription;

		/// <summary>The number of entries in the enhanced metafile's palette.</summary>
		public uint nPalEntries;

		/// <summary>The resolution of the reference device, in pixels.</summary>
		public SIZE szlDevice;

		/// <summary>The resolution of the reference device, in millimeters.</summary>
		public SIZE szlMillimeters;

		/// <summary>
		/// The size of the last recorded pixel format in a metafile. If a pixel format is set in a reference DC at the start of
		/// recording, cbPixelFormat is set to the size of the PIXELFORMATDESCRIPTOR. When no pixel format is set when a metafile is
		/// recorded, this member is set to zero. If more than a single pixel format is set, the header points to the last pixel format.
		/// </summary>
		public uint cbPixelFormat;

		/// <summary>
		/// The offset of pixel format used when recording a metafile. If a pixel format is set in a reference DC at the start of
		/// recording or during recording, offPixelFormat is set to the offset of the PIXELFORMATDESCRIPTOR in the metafile. If no pixel
		/// format is set when a metafile is recorded, this member is set to zero. If more than a single pixel format is set, the header
		/// points to the last pixel format.
		/// </summary>
		public uint offPixelFormat;

		/// <summary>
		/// Indicates whether any OpenGL records are present in a metafile. bOpenGL is a simple Boolean flag that you can use to
		/// determine whether an enhanced metafile requires OpenGL handling. When a metafile contains OpenGL records, bOpenGL is
		/// <c>TRUE</c>; otherwise it is <c>FALSE</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bOpenGL;

		/// <summary>The size of the reference device, in micrometers.</summary>
		public SIZE szlMicrometers;

		/// <summary>A default instance of the structure with the size field preset.</summary>
		public static readonly ENHMETAHEADER Default = new() { nSize = (uint)Marshal.SizeOf(typeof(ENHMETAHEADER)) };
	}

	/// <summary>
	/// The <c>HANDLETABLE</c> structure is an array of handles, each of which identifies a graphics device interface (GDI) object.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-handletable typedef struct tagHANDLETABLE { HGDIOBJ
	// objectHandle[1]; } HANDLETABLE, *PHANDLETABLE, *LPHANDLETABLE;
	[PInvokeData("wingdi.h", MSDNShortId = "c0c03c7d-baac-4b59-ba2f-8f6330651b49")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HANDLETABLE
	{
		/// <summary>An array of handles.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public HGDIOBJ[] objectHandle;
	}

	/// <summary>Defines the metafile picture format used for exchanging metafile data through the clipboard.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-metafilepict typedef struct tagMETAFILEPICT { LONG mm; LONG
	// xExt; LONG yExt; HMETAFILE hMF; } METAFILEPICT, *LPMETAFILEPICT;
	[PInvokeData("wingdi.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct METAFILEPICT
	{
		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>The mapping mode in which the picture is drawn.</para>
		/// </summary>
		public MapMode mm;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// The size of the metafile picture for all modes except the <c>MM_ISOTROPIC</c> and <c>MM_ANISOTROPIC</c> modes. (For more
		/// information about these modes, see the <c>yExt</c> member.) The x-extent specifies the width of the rectangle within which
		/// the picture is drawn. The coordinates are in units that correspond to the mapping mode.
		/// </para>
		/// </summary>
		public int xExt;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// The size of the metafile picture for all modes except the <c>MM_ISOTROPIC</c> and <c>MM_ANISOTROPIC</c> modes. The y-extent
		/// specifies the height of the rectangle within which the picture is drawn. The coordinates are in units that correspond to the
		/// mapping mode. For <c>MM_ISOTROPIC</c> and <c>MM_ANISOTROPIC</c> modes, which can be scaled, the <c>xExt</c> and <c>yExt</c>
		/// members contain an optional suggested size in <c>MM_HIMETRIC</c> units. For <c>MM_ANISOTROPIC</c> pictures, <c>xExt</c> and
		/// <c>yExt</c> can be zero when no suggested size is supplied. For <c>MM_ISOTROPIC</c> pictures, an aspect ratio must be
		/// supplied even when no suggested size is given. (If a suggested size is given, the aspect ratio is implied by the size.) To
		/// give an aspect ratio without implying a suggested size, set <c>xExt</c> and <c>yExt</c> to negative values whose ratio is the
		/// appropriate aspect ratio. The magnitude of the negative <c>xExt</c> and <c>yExt</c> values is ignored; only the ratio is used.
		/// </para>
		/// </summary>
		public int yExt;

		/// <summary>
		/// <para>Type: <c>HMETAFILE</c></para>
		/// <para>A handle to a memory metafile.</para>
		/// </summary>
		public HMETAFILE hMF;
	}

	/// <summary>
	/// The <c>ENHMETARECORD</c> structure contains data that describes a graphics device interface (GDI) function used to create part of
	/// a picture in an enhanced-format metafile.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-enhmetarecord typedef struct tagENHMETARECORD { DWORD iType;
	// DWORD nSize; DWORD dParm[1]; } ENHMETARECORD, *PENHMETARECORD, *LPENHMETARECORD;
	[PInvokeData("wingdi.h", MSDNShortId = "efe49094-fe61-40e1-873e-3302c595717e")]
	public class ENHMETARECORD : SafeNativeArray<uint>
	{
		/// <summary>Initializes a new instance of the <see cref="ENHMETARECORD"/> class.</summary>
		/// <param name="type">The record type.</param>
		/// <param name="parameters">An array of parameters passed to the GDI function identified by the record.</param>
		public ENHMETARECORD(RecordType type, uint[] parameters) : base(parameters, 8)
		{
			handle.Write(type);
			handle.Write((uint)Size, 4);
		}

		/// <summary>Initializes a new instance of the <see cref="ENHMETARECORD"/> class.</summary>
		private ENHMETARECORD(IntPtr ptr) : base(ptr, 0, false, 8, 0, true)
		{
			sz = handle.ToStructure<uint>(0, 4);
			base.Count = (int)(Size - base.HeaderSize) / 4;
		}

		/// <summary>An array of parameters passed to the GDI function identified by the record.</summary>
		public uint[] dParm => base.Elements ?? new uint[0];

		/// <summary>The record type.</summary>
		public RecordType iType => handle.ToStructure<RecordType>();

		/// <summary>The size of the record, in bytes.</summary>
		public uint nSize => Size;

		/// <summary>Performs an explicit conversion from <see cref="IntPtr"/> to <see cref="ENHMETARECORD"/>.</summary>
		/// <param name="ptr">The pointer to an instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator ENHMETARECORD(IntPtr ptr) => new(ptr);
	}

	/// <summary>The <c>METARECORD</c> structure contains a Windows-format metafile record.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-metarecord typedef struct tagMETARECORD { DWORD rdSize; WORD
	// rdFunction; WORD rdParm[1]; } METARECORD, *PMETARECORD, *LPMETARECORD;
	[PInvokeData("wingdi.h", MSDNShortId = "7c5d6e97-dff1-4c80-a7d3-082413dca469")]
	public class METARECORD : SafeNativeArray<ushort>
	{
		/// <summary>Initializes a new instance of the <see cref="METARECORD"/> class.</summary>
		/// <param name="functionNumber">The function number.</param>
		/// <param name="parameters">An array of parameters passed to the GDI function identified by the record.</param>
		public METARECORD(ushort functionNumber, ushort[] parameters) : base(parameters, 6)
		{
			handle.Write(Size / 2U);
			handle.Write(functionNumber, 4);
		}

		/// <summary>Initializes a new instance of the <see cref="ENHMETARECORD"/> class.</summary>
		private METARECORD(IntPtr ptr) : base(ptr, 0, false, 6, 0, true)
		{
			sz = handle.ToStructure<uint>() * 2U;
			base.Count = (int)(Size - base.HeaderSize) / 2;
		}

		/// <summary>The function number.</summary>
		public ushort rdFunction => handle.ToStructure<ushort>(Size, 4);

		/// <summary>An array of words containing the function parameters, in reverse of the order they are passed to the function.</summary>
		public ushort[] rdParm => base.Elements ?? new ushort[0];

		/// <summary>The size, in words, of the record.</summary>
		public uint rdSize => Size / 2U;

		/// <summary>Performs an explicit conversion from <see cref="IntPtr"/> to <see cref="METARECORD"/>.</summary>
		/// <param name="ptr">The pointer to an instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator METARECORD(IntPtr ptr) => new(ptr);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HENHMETAFILE"/> that is disposed using <see cref="DeleteEnhMetaFile"/>.</summary>
	public class SafeHENHMETAFILE : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHENHMETAFILE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHENHMETAFILE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHENHMETAFILE"/> class.</summary>
		private SafeHENHMETAFILE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHENHMETAFILE"/> to <see cref="HENHMETAFILE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HENHMETAFILE(SafeHENHMETAFILE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => DeleteEnhMetaFile(this);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HMETAFILE"/> that is disposed using <see cref="DeleteMetaFile"/>.</summary>
	public class SafeHMETAFILE : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHMETAFILE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHMETAFILE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHMETAFILE"/> class.</summary>
		private SafeHMETAFILE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHMETAFILE"/> to <see cref="HMETAFILE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HMETAFILE(SafeHMETAFILE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => DeleteMetaFile(handle);
	}
}