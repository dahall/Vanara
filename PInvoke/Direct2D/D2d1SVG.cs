namespace Vanara.PInvoke;

public static partial class D2d1
{
	/// <summary>The alignment portion of the SVG preserveAspectRatio attribute.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/ne-d2d1svg-d2d1_svg_aspect_align typedef enum D2D1_SVG_ASPECT_ALIGN {
	// D2D1_SVG_ASPECT_ALIGN_NONE = 0, D2D1_SVG_ASPECT_ALIGN_X_MIN_Y_MIN = 1, D2D1_SVG_ASPECT_ALIGN_X_MID_Y_MIN = 2,
	// D2D1_SVG_ASPECT_ALIGN_X_MAX_Y_MIN = 3, D2D1_SVG_ASPECT_ALIGN_X_MIN_Y_MID = 4, D2D1_SVG_ASPECT_ALIGN_X_MID_Y_MID = 5,
	// D2D1_SVG_ASPECT_ALIGN_X_MAX_Y_MID = 6, D2D1_SVG_ASPECT_ALIGN_X_MIN_Y_MAX = 7, D2D1_SVG_ASPECT_ALIGN_X_MID_Y_MAX = 8,
	// D2D1_SVG_ASPECT_ALIGN_X_MAX_Y_MAX = 9, D2D1_SVG_ASPECT_ALIGN_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1svg.h", MSDNShortId = "NE:d2d1svg.D2D1_SVG_ASPECT_ALIGN")]
	public enum D2D1_SVG_ASPECT_ALIGN : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The alignment is set to SVG's 'none' value.</para>
		/// </summary>
		D2D1_SVG_ASPECT_ALIGN_NONE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The alignment is set to SVG's 'xMinYMin' value.</para>
		/// </summary>
		D2D1_SVG_ASPECT_ALIGN_X_MIN_Y_MIN,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The alignment is set to SVG's 'xMidYMin' value.</para>
		/// </summary>
		D2D1_SVG_ASPECT_ALIGN_X_MID_Y_MIN,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The alignment is set to SVG's 'xMaxYMin' value.</para>
		/// </summary>
		D2D1_SVG_ASPECT_ALIGN_X_MAX_Y_MIN,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The alignment is set to SVG's 'xMinYMid' value.</para>
		/// </summary>
		D2D1_SVG_ASPECT_ALIGN_X_MIN_Y_MID,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The alignment is set to SVG's 'xMidYMid' value.</para>
		/// </summary>
		D2D1_SVG_ASPECT_ALIGN_X_MID_Y_MID,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>The alignment is set to SVG's 'xMaxYMid' value.</para>
		/// </summary>
		D2D1_SVG_ASPECT_ALIGN_X_MAX_Y_MID,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>The alignment is set to SVG's 'xMinYMax' value.</para>
		/// </summary>
		D2D1_SVG_ASPECT_ALIGN_X_MIN_Y_MAX,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>The alignment is set to SVG's 'xMidYMax' value.</para>
		/// </summary>
		D2D1_SVG_ASPECT_ALIGN_X_MID_Y_MAX,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>The alignment is set to SVG's 'xMaxYMax' value.</para>
		/// </summary>
		D2D1_SVG_ASPECT_ALIGN_X_MAX_Y_MAX,
	}

	/// <summary>The meetOrSlice portion of the SVG preserveAspectRatio attribute.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/ne-d2d1svg-d2d1_svg_aspect_scaling typedef enum D2D1_SVG_ASPECT_SCALING {
	// D2D1_SVG_ASPECT_SCALING_MEET = 0, D2D1_SVG_ASPECT_SCALING_SLICE = 1, D2D1_SVG_ASPECT_SCALING_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1svg.h", MSDNShortId = "NE:d2d1svg.D2D1_SVG_ASPECT_SCALING")]
	public enum D2D1_SVG_ASPECT_SCALING : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Scale the viewBox up as much as possible such that the entire viewBox is visible within the viewport.</para>
		/// </summary>
		D2D1_SVG_ASPECT_SCALING_MEET,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Scale the viewBox down as much as possible such that the entire viewport is</para>
		/// <para>covered by the viewBox.</para>
		/// </summary>
		D2D1_SVG_ASPECT_SCALING_SLICE,
	}

	/// <summary>Specifies the units for an SVG length.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/ne-d2d1svg-d2d1_svg_length_units typedef enum D2D1_SVG_LENGTH_UNITS {
	// D2D1_SVG_LENGTH_UNITS_NUMBER = 0, D2D1_SVG_LENGTH_UNITS_PERCENTAGE = 1, D2D1_SVG_LENGTH_UNITS_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1svg.h", MSDNShortId = "NE:d2d1svg.D2D1_SVG_LENGTH_UNITS")]
	public enum D2D1_SVG_LENGTH_UNITS : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The length is unitless.</para>
		/// </summary>
		D2D1_SVG_LENGTH_UNITS_NUMBER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The length is a percentage value.</para>
		/// </summary>
		D2D1_SVG_LENGTH_UNITS_PERCENTAGE,
	}

	/// <summary>Represents an SVG length.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/ns-d2d1svg-d2d1_svg_length typedef struct D2D1_SVG_LENGTH { FLOAT value;
	// D2D1_SVG_LENGTH_UNITS units; } D2D1_SVG_LENGTH;
	[PInvokeData("d2d1svg.h", MSDNShortId = "NS:d2d1svg.D2D1_SVG_LENGTH")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_SVG_LENGTH
	{
		/// <summary/>
		public float value;

		/// <summary/>
		public D2D1_SVG_LENGTH_UNITS units;
	}

	/// <summary>Represents all SVG preserveAspectRatio settings.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/ns-d2d1svg-d2d1_svg_preserve_aspect_ratio typedef struct
	// D2D1_SVG_PRESERVE_ASPECT_RATIO { BOOL defer; D2D1_SVG_ASPECT_ALIGN align; D2D1_SVG_ASPECT_SCALING meetOrSlice; } D2D1_SVG_PRESERVE_ASPECT_RATIO;
	[PInvokeData("d2d1svg.h", MSDNShortId = "NS:d2d1svg.D2D1_SVG_PRESERVE_ASPECT_RATIO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_SVG_PRESERVE_ASPECT_RATIO
	{
		/// <summary>
		/// Sets the 'defer' portion of the preserveAspectRatio settings. This field only has an effect on an 'image' element that
		/// references another SVG document. As this is not currently supported, the field has no impact on rendering.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool defer;

		/// <summary>Sets the align portion of the preserveAspectRatio settings.</summary>
		public D2D1_SVG_ASPECT_ALIGN align;

		/// <summary>Sets the meetOrSlice portion of the preserveAspectRatio settings.</summary>
		public D2D1_SVG_ASPECT_SCALING meetOrSlice;
	}

	/// <summary>Represents an SVG viewBox.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/ns-d2d1svg-d2d1_svg_viewbox typedef struct D2D1_SVG_VIEWBOX { FLOAT x;
	// FLOAT y; FLOAT width; FLOAT height; } D2D1_SVG_VIEWBOX;
	[PInvokeData("d2d1svg.h", MSDNShortId = "NS:d2d1svg.D2D1_SVG_VIEWBOX")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_SVG_VIEWBOX
	{
		/// <summary>X coordinate of the view box.</summary>
		public float x;

		/// <summary>Y coordinate of the view box.</summary>
		public float y;

		/// <summary>Width of the view box.</summary>
		public float width;

		/// <summary>Height of the view box.</summary>
		public float height;
	}

	/*
D2D1_SVG_ATTRIBUTE_POD_TYPE
D2D1_SVG_ATTRIBUTE_STRING_TYPE
D2D1_SVG_DISPLAY
D2D1_SVG_LENGTH_UNITS
D2D1_SVG_LINE_CAP
D2D1_SVG_LINE_JOIN
D2D1_SVG_OVERFLOW
D2D1_SVG_PAINT_TYPE
D2D1_SVG_PATH_COMMAND
D2D1_SVG_UNIT_TYPE
D2D1_SVG_VISIBILITY

ID2D1SvgAttribute
ID2D1SvgDocument
ID2D1SvgElement
ID2D1SvgPaint
ID2D1SvgPathData
ID2D1SvgPointCollection
ID2D1SvgStrokeDashArray
	*/
}