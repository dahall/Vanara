using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Gdi32
	{
		/// <summary>End caps used by Pen functions and structures.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "34ffa71d-e94d-425e-9f9d-21e3df4990b7")]
		public enum PenEndCap : uint
		{
			/// <summary>End caps are round.</summary>
			PS_ENDCAP_ROUND = 0x00000000,

			/// <summary>End caps are square.</summary>
			PS_ENDCAP_SQUARE = 0x00000100,

			/// <summary>End caps are flat.</summary>
			PS_ENDCAP_FLAT = 0x00000200,
		}

		/// <summary>Joins used by Pen functions and structures.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "34ffa71d-e94d-425e-9f9d-21e3df4990b7")]
		public enum PenJoin : uint
		{
			/// <summary>Joins are round.</summary>
			PS_JOIN_ROUND = 0x00000000,

			/// <summary>Joins are beveled.</summary>
			PS_JOIN_BEVEL = 0x00001000,

			/// <summary>
			/// Joins are mitered when they are within the current limit set by the SetMiterLimit function. If it exceeds this limit, the
			/// join is beveled.
			/// </summary>
			PS_JOIN_MITER = 0x00002000,
		}

		/// <summary>Styles used by Pen functions and structures.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "34ffa71d-e94d-425e-9f9d-21e3df4990b7")]
		public enum PenStyle : uint
		{
			/// <summary>The pen is solid.</summary>
			PS_SOLID = 0,

			/// <summary>The pen is dashed.</summary>
			PS_DASH = 1,

			/// <summary>The pen is dotted.</summary>
			PS_DOT = 2,

			/// <summary>The pen has alternating dashes and dots.</summary>
			PS_DASHDOT = 3,

			/// <summary>The pen has alternating dashes and double dots.</summary>
			PS_DASHDOTDOT = 4,

			/// <summary>The pen is invisible.</summary>
			PS_NULL = 5,

			/// <summary>
			/// The pen is solid. When this pen is used in any GDI drawing function that takes a bounding rectangle, the dimensions of the
			/// figure are shrunk so that it fits entirely in the bounding rectangle, taking into account the width of the pen. This applies
			/// only to geometric pens.
			/// </summary>
			PS_INSIDEFRAME = 6,

			/// <summary>The pen uses a styling array supplied by the user.</summary>
			PS_USERSTYLE = 7,

			/// <summary>The pen sets every other pixel. (This style is applicable only for cosmetic pens.)</summary>
			PS_ALTERNATE = 8,
		}

		/// <summary>Joins used by Pen functions and structures.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "34ffa71d-e94d-425e-9f9d-21e3df4990b7")]
		public enum PenType : uint
		{
			/// <summary>The pen is cosmetic.</summary>
			PS_COSMETIC = 0x00000000,

			/// <summary>The pen is geometric.</summary>
			PS_GEOMETRIC = 0x00010000,
		}

		/// <summary>
		/// <para>
		/// The <c>CreatePen</c> function creates a logical pen that has the specified style, width, and color. The pen can subsequently be
		/// selected into a device context and used to draw lines and curves.
		/// </para>
		/// </summary>
		/// <param name="iStyle">
		/// <para>The pen style. It can be any one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PS_SOLID</term>
		/// <term>The pen is solid.</term>
		/// </item>
		/// <item>
		/// <term>PS_DASH</term>
		/// <term>The pen is dashed. This style is valid only when the pen width is one or less in device units.</term>
		/// </item>
		/// <item>
		/// <term>PS_DOT</term>
		/// <term>The pen is dotted. This style is valid only when the pen width is one or less in device units.</term>
		/// </item>
		/// <item>
		/// <term>PS_DASHDOT</term>
		/// <term>The pen has alternating dashes and dots. This style is valid only when the pen width is one or less in device units.</term>
		/// </item>
		/// <item>
		/// <term>PS_DASHDOTDOT</term>
		/// <term>The pen has alternating dashes and double dots. This style is valid only when the pen width is one or less in device units.</term>
		/// </item>
		/// <item>
		/// <term>PS_NULL</term>
		/// <term>The pen is invisible.</term>
		/// </item>
		/// <item>
		/// <term>PS_INSIDEFRAME</term>
		/// <term>
		/// The pen is solid. When this pen is used in any GDI drawing function that takes a bounding rectangle, the dimensions of the figure
		/// are shrunk so that it fits entirely in the bounding rectangle, taking into account the width of the pen. This applies only to
		/// geometric pens.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="cWidth">
		/// <para>The width of the pen, in logical units. If nWidth is zero, the pen is a single pixel wide, regardless of the current transformation.</para>
		/// <para>
		/// <c>CreatePen</c> returns a pen with the specified width bit with the PS_SOLID style if you specify a width greater than one for
		/// the following styles: PS_DASH, PS_DOT, PS_DASHDOT, PS_DASHDOTDOT.
		/// </para>
		/// </param>
		/// <param name="color">
		/// <para>A color reference for the pen color. To generate a COLORREF structure, use the RGB macro.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle that identifies a logical pen.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// After an application creates a logical pen, it can select that pen into a device context by calling the SelectObject function.
		/// After a pen is selected into a device context, it can be used to draw lines and curves.
		/// </para>
		/// <para>
		/// If the value specified by the nWidth parameter is zero, a line drawn with the created pen always is a single pixel wide
		/// regardless of the current transformation.
		/// </para>
		/// <para>If the value specified by nWidth is greater than 1, the fnPenStyle parameter must be PS_NULL, PS_SOLID, or PS_INSIDEFRAME.</para>
		/// <para>
		/// If the value specified by nWidth is greater than 1 and fnPenStyle is PS_INSIDEFRAME, the line associated with the pen is drawn
		/// inside the frame of all primitives except polygons and polylines.
		/// </para>
		/// <para>
		/// If the value specified by nWidth is greater than 1, fnPenStyle is PS_INSIDEFRAME, and the color specified by the crColor
		/// parameter does not match one of the entries in the logical palette, the system draws lines by using a dithered color. Dithered
		/// colors are not available with solid pens.
		/// </para>
		/// <para>When you no longer need the pen, call the DeleteObject function to delete it.</para>
		/// <para>
		/// <c>ICM:</c> No color management is done at creation. However, color management is performed when the pen is selected into an
		/// ICM-enabled device context.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating Colored Pens and Brushes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createpen HPEN CreatePen( int iStyle, int cWidth, COLORREF
		// color );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "882facd2-7e06-48f6-82e4-f20e4d5adc92")]
		public static extern SafeHPEN CreatePen(uint iStyle, int cWidth, COLORREF color);

		/// <summary>
		/// <para>
		/// The <c>CreatePenIndirect</c> function creates a logical cosmetic pen that has the style, width, and color specified in a structure.
		/// </para>
		/// </summary>
		/// <param name="plpen">
		/// <para>Pointer to a LOGPEN structure that specifies the pen's style, width, and color.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle that identifies a logical cosmetic pen.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// After an application creates a logical pen, it can select that pen into a device context by calling the SelectObject function.
		/// After a pen is selected into a device context, it can be used to draw lines and curves.
		/// </para>
		/// <para>When you no longer need the pen, call the DeleteObject function to delete it.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-createpenindirect HPEN CreatePenIndirect( const LOGPEN
		// *plpen );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "638c0294-9a8f-44ed-a791-1be152cd92dd")]
		public static extern SafeHPEN CreatePenIndirect(in LOGPEN plpen);

		/// <summary>
		/// <para>
		/// The <c>ExtCreatePen</c> function creates a logical cosmetic or geometric pen that has the specified style, width, and brush attributes.
		/// </para>
		/// </summary>
		/// <param name="iPenStyle">
		/// <para>
		/// A combination of type, style, end cap, and join attributes. The values from each category are combined by using the bitwise OR
		/// operator ( | ).
		/// </para>
		/// <para>The pen type can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PS_GEOMETRIC</term>
		/// <term>The pen is geometric.</term>
		/// </item>
		/// <item>
		/// <term>PS_COSMETIC</term>
		/// <term>The pen is cosmetic.</term>
		/// </item>
		/// </list>
		/// <para>The pen style can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PS_ALTERNATE</term>
		/// <term>The pen sets every other pixel. (This style is applicable only for cosmetic pens.)</term>
		/// </item>
		/// <item>
		/// <term>PS_SOLID</term>
		/// <term>The pen is solid.</term>
		/// </item>
		/// <item>
		/// <term>PS_DASH</term>
		/// <term>The pen is dashed.</term>
		/// </item>
		/// <item>
		/// <term>PS_DOT</term>
		/// <term>The pen is dotted.</term>
		/// </item>
		/// <item>
		/// <term>PS_DASHDOT</term>
		/// <term>The pen has alternating dashes and dots.</term>
		/// </item>
		/// <item>
		/// <term>PS_DASHDOTDOT</term>
		/// <term>The pen has alternating dashes and double dots.</term>
		/// </item>
		/// <item>
		/// <term>PS_NULL</term>
		/// <term>The pen is invisible.</term>
		/// </item>
		/// <item>
		/// <term>PS_USERSTYLE</term>
		/// <term>The pen uses a styling array supplied by the user.</term>
		/// </item>
		/// <item>
		/// <term>PS_INSIDEFRAME</term>
		/// <term>
		/// The pen is solid. When this pen is used in any GDI drawing function that takes a bounding rectangle, the dimensions of the figure
		/// are shrunk so that it fits entirely in the bounding rectangle, taking into account the width of the pen. This applies only to
		/// geometric pens.
		/// </term>
		/// </item>
		/// </list>
		/// <para>The end cap is only specified for geometric pens. The end cap can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PS_ENDCAP_ROUND</term>
		/// <term>End caps are round.</term>
		/// </item>
		/// <item>
		/// <term>PS_ENDCAP_SQUARE</term>
		/// <term>End caps are square.</term>
		/// </item>
		/// <item>
		/// <term>PS_ENDCAP_FLAT</term>
		/// <term>End caps are flat.</term>
		/// </item>
		/// </list>
		/// <para>The join is only specified for geometric pens. The join can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PS_JOIN_BEVEL</term>
		/// <term>Joins are beveled.</term>
		/// </item>
		/// <item>
		/// <term>PS_JOIN_MITER</term>
		/// <term>
		/// Joins are mitered when they are within the current limit set by the SetMiterLimit function. If it exceeds this limit, the join is beveled.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PS_JOIN_ROUND</term>
		/// <term>Joins are round.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="cWidth">
		/// <para>
		/// The width of the pen. If the dwPenStyle parameter is PS_GEOMETRIC, the width is given in logical units. If dwPenStyle is
		/// PS_COSMETIC, the width must be set to 1.
		/// </para>
		/// </param>
		/// <param name="plbrush">
		/// <para>
		/// A pointer to a LOGBRUSH structure. If dwPenStyle is PS_COSMETIC, the <c>lbColor</c> member specifies the color of the pen and the
		/// <c>lpStyle</c> member must be set to BS_SOLID. If dwPenStyle is PS_GEOMETRIC, all members must be used to specify the brush
		/// attributes of the pen.
		/// </para>
		/// </param>
		/// <param name="cStyle">
		/// <para>The length, in <c>DWORD</c> units, of the lpStyle array. This value must be zero if dwPenStyle is not PS_USERSTYLE.</para>
		/// <para>The style count is limited to 16.</para>
		/// </param>
		/// <param name="pstyle">
		/// <para>
		/// A pointer to an array. The first value specifies the length of the first dash in a user-defined style, the second value specifies
		/// the length of the first space, and so on. This pointer must be <c>NULL</c> if dwPenStyle is not PS_USERSTYLE.
		/// </para>
		/// <para>
		/// If the lpStyle array is exceeded during line drawing, the pointer is reset to the beginning of the array. When this happens and
		/// dwStyleCount is an even number, the pattern of dashes and spaces repeats. However, if dwStyleCount is odd, the pattern reverses
		/// when the pointer is reset -- the first element of lpStyle now refers to spaces, the second refers to dashes, and so forth.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle that identifies a logical pen.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A geometric pen can have any width and can have any of the attributes of a brush, such as dithers and patterns. A cosmetic pen
		/// can only be a single pixel wide and must be a solid color, but cosmetic pens are generally faster than geometric pens.
		/// </para>
		/// <para>The width of a geometric pen is always specified in world units. The width of a cosmetic pen is always 1.</para>
		/// <para>End caps and joins are only specified for geometric pens.</para>
		/// <para>
		/// After an application creates a logical pen, it can select that pen into a device context by calling the SelectObject function.
		/// After a pen is selected into a device context, it can be used to draw lines and curves.
		/// </para>
		/// <para>
		/// If dwPenStyle is PS_COSMETIC and PS_USERSTYLE, the entries in the lpStyle array specify lengths of dashes and spaces in style
		/// units. A style unit is defined by the device where the pen is used to draw a line.
		/// </para>
		/// <para>
		/// If dwPenStyle is PS_GEOMETRIC and PS_USERSTYLE, the entries in the lpStyle array specify lengths of dashes and spaces in logical units.
		/// </para>
		/// <para>If dwPenStyle is PS_ALTERNATE, the style unit is ignored and every other pixel is set.</para>
		/// <para>
		/// If the <c>lbStyle</c> member of the LOGBRUSH structure pointed to by lplb is BS_PATTERN, the bitmap pointed to by the
		/// <c>lbHatch</c> member of that structure cannot be a DIB section. A DIB section is a bitmap created by CreateDIBSection. If that
		/// bitmap is a DIB section, the <c>ExtCreatePen</c> function fails.
		/// </para>
		/// <para>When an application no longer requires a specified pen, it should call the DeleteObject function to delete the pen.</para>
		/// <para>
		/// <c>ICM:</c> No color management is done at pen creation. However, color management is performed when the pen is selected into an
		/// ICM-enabled device context.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Pens.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/nf-wingdi-extcreatepen HPEN ExtCreatePen( DWORD iPenStyle, DWORD
		// cWidth, const LOGBRUSH *plbrush, DWORD cStyle, const DWORD *pstyle );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "a1e81314-4fe6-481f-af96-24ebf56332cf")]
		public static extern SafeHPEN ExtCreatePen(uint iPenStyle, uint cWidth, in LOGBRUSH plbrush, uint cStyle, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] uint[] pstyle);

		/// <summary>
		/// <para>
		/// The <c>EXTLOGPEN</c> structure defines the pen style, width, and brush attributes for an extended pen. This structure is used by
		/// the GetObject function when it retrieves a description of a pen that was created when an application called the ExtCreatePen function.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-tagextlogpen typedef struct tagEXTLOGPEN { DWORD
		// elpPenStyle; DWORD elpWidth; UINT elpBrushStyle; COLORREF elpColor; ULONG_PTR elpHatch; DWORD elpNumEntries; DWORD
		// elpStyleEntry[1]; } EXTLOGPEN, *PEXTLOGPEN, *NPEXTLOGPEN, *LPEXTLOGPEN;
		[PInvokeData("wingdi.h", MSDNShortId = "34ffa71d-e94d-425e-9f9d-21e3df4990b7")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct EXTLOGPEN
		{
			/// <summary>
			/// <para>
			/// A combination of pen type, style, end cap style, and join style. The values from each category can be retrieved by using a
			/// bitwise AND operator with the appropriate mask.
			/// </para>
			/// <para>The <c>elpPenStyle</c> member masked with PS_TYPE_MASK has one of the following pen type values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PS_GEOMETRIC</term>
			/// <term>The pen is geometric.</term>
			/// </item>
			/// <item>
			/// <term>PS_COSMETIC</term>
			/// <term>The pen is cosmetic.</term>
			/// </item>
			/// </list>
			/// <para>The <c>elpPenStyle</c> member masked with PS_STYLE_MASK has one of the following pen styles values:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PS_DASH</term>
			/// <term>The pen is dashed.</term>
			/// </item>
			/// <item>
			/// <term>PS_DASHDOT</term>
			/// <term>The pen has alternating dashes and dots.</term>
			/// </item>
			/// <item>
			/// <term>PS_DASHDOTDOT</term>
			/// <term>The pen has alternating dashes and double dots.</term>
			/// </item>
			/// <item>
			/// <term>PS_DOT</term>
			/// <term>The pen is dotted.</term>
			/// </item>
			/// <item>
			/// <term>PS_INSIDEFRAME</term>
			/// <term>
			/// The pen is solid. When this pen is used in any GDI drawing function that takes a bounding rectangle, the dimensions of the
			/// figure are shrunk so that it fits entirely in the bounding rectangle, taking into account the width of the pen. This applies
			/// only to PS_GEOMETRIC pens.
			/// </term>
			/// </item>
			/// <item>
			/// <term>PS_NULL</term>
			/// <term>The pen is invisible.</term>
			/// </item>
			/// <item>
			/// <term>PS_SOLID</term>
			/// <term>The pen is solid.</term>
			/// </item>
			/// <item>
			/// <term>PS_USERSTYLE</term>
			/// <term>The pen uses a styling array supplied by the user.</term>
			/// </item>
			/// </list>
			/// <para>
			/// The following category applies only to PS_GEOMETRIC pens. The <c>elpPenStyle</c> member masked with PS_ENDCAP_MASK has one of
			/// the following end cap values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PS_ENDCAP_FLAT</term>
			/// <term>Line end caps are flat.</term>
			/// </item>
			/// <item>
			/// <term>PS_ENDCAP_ROUND</term>
			/// <term>Line end caps are round.</term>
			/// </item>
			/// <item>
			/// <term>PS_ENDCAP_SQUARE</term>
			/// <term>Line end caps are square.</term>
			/// </item>
			/// </list>
			/// <para>
			/// The following category applies only to PS_GEOMETRIC pens. The <c>elpPenStyle</c> member masked with PS_JOIN_MASK has one of
			/// the following join values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PS_JOIN_BEVEL</term>
			/// <term>Line joins are beveled.</term>
			/// </item>
			/// <item>
			/// <term>PS_JOIN_MITER</term>
			/// <term>
			/// Line joins are mitered when they are within the current limit set by the SetMiterLimit function. A join is beveled when it
			/// would exceed the limit.
			/// </term>
			/// </item>
			/// <item>
			/// <term>PS_JOIN_ROUND</term>
			/// <term>Line joins are round.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint elpPenStyle;

			/// <summary>
			/// <para>
			/// The width of the pen. If the <c>elpPenStyle</c> member is PS_GEOMETRIC, this value is the width of the line in logical units.
			/// Otherwise, the lines are cosmetic and this value is 1, which indicates a line with a width of one pixel.
			/// </para>
			/// </summary>
			public uint elpWidth;

			/// <summary>
			/// <para>The brush style of the pen. The <c>elpBrushStyle</c> member value can be one of the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>BS_DIBPATTERN</term>
			/// <term>
			/// Specifies a pattern brush defined by a DIB specification. If elpBrushStyle is BS_DIBPATTERN, the elpHatch member contains a
			/// handle to a packed DIB. For more information, see discussion in elpHatch
			/// </term>
			/// </item>
			/// <item>
			/// <term>BS_DIBPATTERNPT</term>
			/// <term>
			/// Specifies a pattern brush defined by a DIB specification. If elpBrushStyle is BS_DIBPATTERNPT, the elpHatch member contains a
			/// pointer to a packed DIB. For more information, see discussion in elpHatch.
			/// </term>
			/// </item>
			/// <item>
			/// <term>BS_HATCHED</term>
			/// <term>Specifies a hatched brush.</term>
			/// </item>
			/// <item>
			/// <term>BS_HOLLOW</term>
			/// <term>Specifies a hollow or NULL brush.</term>
			/// </item>
			/// <item>
			/// <term>BS_PATTERN</term>
			/// <term>Specifies a pattern brush defined by a memory bitmap.</term>
			/// </item>
			/// <item>
			/// <term>BS_SOLID</term>
			/// <term>Specifies a solid brush.</term>
			/// </item>
			/// </list>
			/// </summary>
			public BrushStyle elpBrushStyle;

			/// <summary>
			/// <para>
			/// If <c>elpBrushStyle</c> is BS_SOLID or BS_HATCHED, <c>elpColor</c> specifies the color in which the pen is to be drawn. For
			/// BS_HATCHED, the SetBkMode and SetBkColor functions determine the background color.
			/// </para>
			/// <para>If <c>elpBrushStyle</c> is BS_HOLLOW or BS_PATTERN, <c>elpColor</c> is ignored.</para>
			/// <para>
			/// If <c>elpBrushStyle</c> is BS_DIBPATTERN or BS_DIBPATTERNPT, the low-order word of <c>elpColor</c> specifies whether the
			/// <c>bmiColors</c> member of the BITMAPINFO structure contain explicit RGB values or indices into the currently realized
			/// logical palette. The <c>elpColor</c> value must be one of the following.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>DIB_PAL_COLORS</term>
			/// <term>The color table consists of an array of 16-bit indices into the currently realized logical palette.</term>
			/// </item>
			/// <item>
			/// <term>DIB_RGB_COLORS</term>
			/// <term>The color table contains literal RGB values.</term>
			/// </item>
			/// </list>
			/// <para>The RGB macro is used to generate a COLORREF structure.</para>
			/// </summary>
			public COLORREF elpColor;

			/// <summary>
			/// <para>If <c>elpBrushStyle</c> is BS_PATTERN, <c>elpHatch</c> is a handle to the bitmap that defines the pattern.</para>
			/// <para>If <c>elpBrushStyle</c> is BS_SOLID or BS_HOLLOW, <c>elpHatch</c> is ignored.</para>
			/// <para>
			/// If <c>elpBrushStyle</c> is BS_DIBPATTERN, the <c>elpHatch</c> member is a handle to a packed DIB. To obtain this handle, an
			/// application calls the GlobalAlloc function with GMEM_MOVEABLE (or LocalAlloc with LMEM_MOVEABLE) to allocate a block of
			/// memory and then fills the memory with the packed DIB. A packed DIB consists of a BITMAPINFO structure immediately followed by
			/// the array of bytes that define the pixels of the bitmap.
			/// </para>
			/// <para>
			/// If <c>elpBrushStyle</c> is BS_DIBPATTERNPT, the <c>elpHatch</c> member is a pointer to a packed DIB. The pointer derives from
			/// the memory block created by LocalAlloc with LMEM_FIXED set or by GlobalAlloc with GMEM_FIXED set, or it is the pointer
			/// returned by a call like LocalLock (handle_to_the_dib). A packed DIB consists of a BITMAPINFO structure immediately followed
			/// by the array of bytes that define the pixels of the bitmap.
			/// </para>
			/// <para>
			/// If <c>elpBrushStyle</c> is BS_HATCHED, the <c>elpHatch</c> member specifies the orientation of the lines used to create the
			/// hatch. It can be one of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>HS_BDIAGONAL</term>
			/// <term>45-degree upward hatch (left to right)</term>
			/// </item>
			/// <item>
			/// <term>HS_CROSS</term>
			/// <term>Horizontal and vertical crosshatch</term>
			/// </item>
			/// <item>
			/// <term>HS_DIAGCROSS</term>
			/// <term>45-degree crosshatch</term>
			/// </item>
			/// <item>
			/// <term>HS_FDIAGONAL</term>
			/// <term>45-degree downward hatch (left to right)</term>
			/// </item>
			/// <item>
			/// <term>HS_HORIZONTAL</term>
			/// <term>Horizontal hatch</term>
			/// </item>
			/// <item>
			/// <term>HS_VERTICAL</term>
			/// <term>Vertical hatch</term>
			/// </item>
			/// </list>
			/// </summary>
			public IntPtr elpHatch;

			/// <summary>
			/// <para>
			/// The number of entries in the style array in the <c>elpStyleEntry</c> member. This value is zero if <c>elpPenStyle</c> does
			/// not specify PS_USERSTYLE.
			/// </para>
			/// </summary>
			public uint elpNumEntries;

			/// <summary>
			/// <para>
			/// A user-supplied style array. The array is specified with a finite length, but it is used as if it repeated indefinitely. The
			/// first entry in the array specifies the length of the first dash. The second entry specifies the length of the first gap.
			/// Thereafter, lengths of dashes and gaps alternate.
			/// </para>
			/// <para>
			/// If <c>elpWidth</c> specifies geometric lines, the lengths are in logical units. Otherwise, the lines are cosmetic and lengths
			/// are in device units.
			/// </para>
			/// </summary>
			public IntPtr elpStyleEntry;

			/// <summary>Gets or sets the style of the pen.</summary>
			public PenStyle Style { get => (PenStyle)(elpPenStyle & 0xF); set => elpPenStyle = elpPenStyle & 0xFFFF0 | (uint)value; }

			/// <summary>Gets or sets the end cap style of the pen.</summary>
			public PenEndCap EndCap { get => (PenEndCap)(elpPenStyle & 0xF00); set => elpPenStyle = elpPenStyle & 0xFF0FF | (uint)value; }

			/// <summary>Gets or sets the join style for the pen.</summary>
			public PenJoin Join { get => (PenJoin)(elpPenStyle & 0xF000); set => elpPenStyle = elpPenStyle & 0xF0FFF | (uint)value; }

			/// <summary>Gets or sets the pen type.</summary>
			public PenType Type { get => (PenType)(elpPenStyle & 0xF0000); set => elpPenStyle = elpPenStyle & 0xFFFF | (uint)value; }
		}

		/// <summary>
		/// <para>
		/// The <c>LOGPEN</c> structure defines the style, width, and color of a pen. The CreatePenIndirect function uses the <c>LOGPEN</c> structure.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the width of the pen is greater than 1 and the pen style is PS_INSIDEFRAME, the line is drawn inside the frame of all GDI
		/// objects except polygons and polylines. If the pen color does not match an available RGB value, the pen is drawn with a logical
		/// (dithered) color. If the pen width is less than or equal to 1, the PS_INSIDEFRAME style is identical to the PS_SOLID style.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-taglogpen typedef struct tagLOGPEN { UINT lopnStyle; POINT
		// lopnWidth; COLORREF lopnColor; } LOGPEN, *PLOGPEN, *NPLOGPEN, *LPLOGPEN;
		[PInvokeData("wingdi.h", MSDNShortId = "0e098b5a-e249-43ad-a6d8-2509b6562453")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct LOGPEN
		{
			/// <summary>
			/// <para>The pen style, which can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PS_SOLID</term>
			/// <term>The pen is solid.</term>
			/// </item>
			/// <item>
			/// <term>PS_DASH</term>
			/// <term>The pen is dashed.</term>
			/// </item>
			/// <item>
			/// <term>PS_DOT</term>
			/// <term>The pen is dotted.</term>
			/// </item>
			/// <item>
			/// <term>PS_DASHDOT</term>
			/// <term>The pen has alternating dashes and dots.</term>
			/// </item>
			/// <item>
			/// <term>PS_DASHDOTDOT</term>
			/// <term>The pen has dashes and double dots.</term>
			/// </item>
			/// <item>
			/// <term>PS_NULL</term>
			/// <term>The pen is invisible.</term>
			/// </item>
			/// <item>
			/// <term>PS_INSIDEFRAME</term>
			/// <term>
			/// The pen is solid. When this pen is used in any GDI drawing function that takes a bounding rectangle, the dimensions of the
			/// figure are shrunk so that it fits entirely in the bounding rectangle, taking into account the width of the pen. This applies
			/// only to geometric pens.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public PenStyle lopnStyle;

			/// <summary>
			/// <para>
			/// The POINT structure that contains the pen width, in logical units. If the <c>pointer</c> member is <c>NULL</c>, the pen is
			/// one pixel wide on raster devices. The <c>y</c> member in the <c>POINT</c> structure for <c>lopnWidth</c> is not used.
			/// </para>
			/// </summary>
			public System.Drawing.Point lopnWidth;

			/// <summary>
			/// <para>The pen color. To generate a COLORREF structure, use the RGB macro.</para>
			/// </summary>
			public COLORREF lopnColor;
		}
	}
}