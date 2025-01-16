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

	/// <summary>Defines the type of SVG POD attribute to set or get.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/ne-d2d1svg-d2d1_svg_attribute_pod_type typedef enum
	// D2D1_SVG_ATTRIBUTE_POD_TYPE { D2D1_SVG_ATTRIBUTE_POD_TYPE_FLOAT = 0, D2D1_SVG_ATTRIBUTE_POD_TYPE_COLOR = 1,
	// D2D1_SVG_ATTRIBUTE_POD_TYPE_FILL_MODE = 2, D2D1_SVG_ATTRIBUTE_POD_TYPE_DISPLAY = 3, D2D1_SVG_ATTRIBUTE_POD_TYPE_OVERFLOW = 4,
	// D2D1_SVG_ATTRIBUTE_POD_TYPE_LINE_CAP = 5, D2D1_SVG_ATTRIBUTE_POD_TYPE_LINE_JOIN = 6, D2D1_SVG_ATTRIBUTE_POD_TYPE_VISIBILITY = 7,
	// D2D1_SVG_ATTRIBUTE_POD_TYPE_MATRIX = 8, D2D1_SVG_ATTRIBUTE_POD_TYPE_UNIT_TYPE = 9, D2D1_SVG_ATTRIBUTE_POD_TYPE_EXTEND_MODE = 10,
	// D2D1_SVG_ATTRIBUTE_POD_TYPE_PRESERVE_ASPECT_RATIO = 11, D2D1_SVG_ATTRIBUTE_POD_TYPE_VIEWBOX = 12, D2D1_SVG_ATTRIBUTE_POD_TYPE_LENGTH
	// = 13, D2D1_SVG_ATTRIBUTE_POD_TYPE_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1svg.h", MSDNShortId = "NE:d2d1svg.D2D1_SVG_ATTRIBUTE_POD_TYPE")]
	public enum D2D1_SVG_ATTRIBUTE_POD_TYPE : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The attribute is a FLOAT.</para>
		/// </summary>
		[CorrespondingType(typeof(float))]
		D2D1_SVG_ATTRIBUTE_POD_TYPE_FLOAT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The attribute is a D2D1_COLOR_F.</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_COLOR_F))]
		D2D1_SVG_ATTRIBUTE_POD_TYPE_COLOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The attribute is a D2D1_FILL_MODE.</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_FILL_MODE))]
		D2D1_SVG_ATTRIBUTE_POD_TYPE_FILL_MODE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The attribute is a D2D1_SVG_DISPLAY.</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_SVG_DISPLAY))]
		D2D1_SVG_ATTRIBUTE_POD_TYPE_DISPLAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The attribute is a D2D1_SVG_OVERFLOW.</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_SVG_OVERFLOW))]
		D2D1_SVG_ATTRIBUTE_POD_TYPE_OVERFLOW,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The attribute is a D2D1_SVG_LINE_CAP.</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_SVG_LINE_CAP))]
		D2D1_SVG_ATTRIBUTE_POD_TYPE_LINE_CAP,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>The attribute is a D2D1_SVG_LINE_JOIN.</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_SVG_LINE_JOIN))]
		D2D1_SVG_ATTRIBUTE_POD_TYPE_LINE_JOIN,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>The attribute is a D2D1_SVG_VISIBILITY.</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_SVG_VISIBILITY))]
		D2D1_SVG_ATTRIBUTE_POD_TYPE_VISIBILITY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>The attribute is a D2D1_MATRIX_3X2_F.</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_MATRIX_3X2_F))]
		D2D1_SVG_ATTRIBUTE_POD_TYPE_MATRIX,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>The attribute is a D2D1_SVG_UNIT_TYPE.</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_SVG_UNIT_TYPE))]
		D2D1_SVG_ATTRIBUTE_POD_TYPE_UNIT_TYPE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>The attribute is a D2D1_EXTEND_MODE.</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_EXTEND_MODE))]
		D2D1_SVG_ATTRIBUTE_POD_TYPE_EXTEND_MODE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>The attribute is a D2D1_SVG_PRESERVE_ASPECT_RATIO.</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_SVG_PRESERVE_ASPECT_RATIO))]
		D2D1_SVG_ATTRIBUTE_POD_TYPE_PRESERVE_ASPECT_RATIO,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <para>The attribute is a D2D1_SVG_VIEWBOX.</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_SVG_VIEWBOX))]
		D2D1_SVG_ATTRIBUTE_POD_TYPE_VIEWBOX,

		/// <summary>
		/// <para>Value:</para>
		/// <para>13</para>
		/// <para>The attribute is a D2D1_SVG_LENGTH.</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_SVG_LENGTH))]
		D2D1_SVG_ATTRIBUTE_POD_TYPE_LENGTH,
	}

	/// <summary>Defines the type of SVG string attribute to set or get.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/ne-d2d1svg-d2d1_svg_attribute_string_type typedef enum
	// D2D1_SVG_ATTRIBUTE_STRING_TYPE { D2D1_SVG_ATTRIBUTE_STRING_TYPE_SVG = 0, D2D1_SVG_ATTRIBUTE_STRING_TYPE_ID = 1,
	// D2D1_SVG_ATTRIBUTE_STRING_TYPE_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1svg.h", MSDNShortId = "NE:d2d1svg.D2D1_SVG_ATTRIBUTE_STRING_TYPE")]
	public enum D2D1_SVG_ATTRIBUTE_STRING_TYPE : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The attribute is a string in the same form as it would appear in the SVG XML.</para>
		/// <para>
		/// Note that when getting values of this type, the value returned may not exactly match the value that was set. Instead, the output
		/// value is a normalized version
		/// </para>
		/// <para>of the value. For example, an input color of 'red' may be output as '#FF0000'.</para>
		/// </summary>
		D2D1_SVG_ATTRIBUTE_STRING_TYPE_SVG,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The attribute is an element ID.</para>
		/// </summary>
		D2D1_SVG_ATTRIBUTE_STRING_TYPE_ID,
	}

	/// <summary>Specifies a value for the SVG display property.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/ne-d2d1svg-d2d1_svg_display typedef enum D2D1_SVG_DISPLAY {
	// D2D1_SVG_DISPLAY_INLINE = 0, D2D1_SVG_DISPLAY_NONE = 1, D2D1_SVG_DISPLAY_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1svg.h", MSDNShortId = "NE:d2d1svg.D2D1_SVG_DISPLAY")]
	public enum D2D1_SVG_DISPLAY
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The element uses the default display behavior.</para>
		/// </summary>
		D2D1_SVG_DISPLAY_INLINE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The element and all children are not rendered directly.</para>
		/// </summary>
		D2D1_SVG_DISPLAY_NONE,
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

	/// <summary>Specifies a value for the SVG stroke-linecap property.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/ne-d2d1svg-d2d1_svg_line_cap typedef enum D2D1_SVG_LINE_CAP {
	// D2D1_SVG_LINE_CAP_BUTT, D2D1_SVG_LINE_CAP_SQUARE, D2D1_SVG_LINE_CAP_ROUND, D2D1_SVG_LINE_CAP_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1svg.h", MSDNShortId = "NE:d2d1svg.D2D1_SVG_LINE_CAP")]
	public enum D2D1_SVG_LINE_CAP
	{
		/// <summary>The property is set to SVG's 'butt' value.</summary>
		D2D1_SVG_LINE_CAP_BUTT,

		/// <summary>The property is set to SVG's 'square' value.</summary>
		D2D1_SVG_LINE_CAP_SQUARE,

		/// <summary>The property is set to SVG's 'round' value.</summary>
		D2D1_SVG_LINE_CAP_ROUND,
	}

	/// <summary>Specifies a value for the SVG stroke-linejoin property.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/ne-d2d1svg-d2d1_svg_line_join typedef enum D2D1_SVG_LINE_JOIN {
	// D2D1_SVG_LINE_JOIN_BEVEL, D2D1_SVG_LINE_JOIN_MITER, D2D1_SVG_LINE_JOIN_ROUND, D2D1_SVG_LINE_JOIN_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1svg.h", MSDNShortId = "NE:d2d1svg.D2D1_SVG_LINE_JOIN")]
	public enum D2D1_SVG_LINE_JOIN
	{
		/// <summary>The property is set to SVG's 'bevel' value.</summary>
		D2D1_SVG_LINE_JOIN_BEVEL,

		/// <summary>The property is set to SVG's 'miter' value. Note that this is equivalent to D2D1_LINE_JOIN_MITER_OR_BEVEL, not D2D1_LINE_JOIN_MITER.</summary>
		D2D1_SVG_LINE_JOIN_MITER,

		/// <summary>The property is set to SVG's 'round' value.</summary>
		D2D1_SVG_LINE_JOIN_ROUND,
	}

	/// <summary>Specifies a value for the SVG overflow property.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/ne-d2d1svg-d2d1_svg_overflow typedef enum D2D1_SVG_OVERFLOW {
	// D2D1_SVG_OVERFLOW_VISIBLE = 0, D2D1_SVG_OVERFLOW_HIDDEN = 1, D2D1_SVG_OVERFLOW_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1svg.h", MSDNShortId = "NE:d2d1svg.D2D1_SVG_OVERFLOW")]
	public enum D2D1_SVG_OVERFLOW
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The element is not clipped to its viewport.</para>
		/// </summary>
		D2D1_SVG_OVERFLOW_VISIBLE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The element is clipped to its viewport.</para>
		/// </summary>
		D2D1_SVG_OVERFLOW_HIDDEN,
	}

	/// <summary>Specifies the paint type for an SVG fill or stroke.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/ne-d2d1svg-d2d1_svg_paint_type typedef enum D2D1_SVG_PAINT_TYPE {
	// D2D1_SVG_PAINT_TYPE_NONE = 0, D2D1_SVG_PAINT_TYPE_COLOR = 1, D2D1_SVG_PAINT_TYPE_CURRENT_COLOR = 2, D2D1_SVG_PAINT_TYPE_URI = 3,
	// D2D1_SVG_PAINT_TYPE_URI_NONE = 4, D2D1_SVG_PAINT_TYPE_URI_COLOR = 5, D2D1_SVG_PAINT_TYPE_URI_CURRENT_COLOR = 6,
	// D2D1_SVG_PAINT_TYPE_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1svg.h", MSDNShortId = "NE:d2d1svg.D2D1_SVG_PAINT_TYPE")]
	public enum D2D1_SVG_PAINT_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The fill or stroke is not rendered.</para>
		/// </summary>
		D2D1_SVG_PAINT_TYPE_NONE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>A solid color is rendered.</para>
		/// </summary>
		D2D1_SVG_PAINT_TYPE_COLOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The current color is rendered.</para>
		/// </summary>
		D2D1_SVG_PAINT_TYPE_CURRENT_COLOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>A paint server, defined by another element in the SVG document, is used.</para>
		/// </summary>
		D2D1_SVG_PAINT_TYPE_URI,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>
		/// A paint server, defined by another element in the SVG document, is used. If the paint server reference is invalid, fall back to D2D1_SVG_PAINT_TYPE_NONE.
		/// </para>
		/// </summary>
		D2D1_SVG_PAINT_TYPE_URI_NONE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>
		/// A paint server, defined by another element in the SVG document, is used. If the paint server reference is invalid, fall back to D2D1_SVG_PAINT_TYPE_COLOR.
		/// </para>
		/// </summary>
		D2D1_SVG_PAINT_TYPE_URI_COLOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>
		/// A paint server, defined by another element in the SVG document, is used. If the paint server reference is invalid, fall back to D2D1_SVG_PAINT_TYPE_CURRENT_COLOR.
		/// </para>
		/// </summary>
		D2D1_SVG_PAINT_TYPE_URI_CURRENT_COLOR,
	}

	/// <summary>
	/// Represents a path commmand. Each command may reference floats from the segment data. Commands ending in _ABSOLUTE interpret data as
	/// absolute coordinate. Commands ending in _RELATIVE interpret data as being relative to the previous point.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/ne-d2d1svg-d2d1_svg_path_command typedef enum D2D1_SVG_PATH_COMMAND {
	// D2D1_SVG_PATH_COMMAND_CLOSE_PATH = 0, D2D1_SVG_PATH_COMMAND_MOVE_ABSOLUTE = 1, D2D1_SVG_PATH_COMMAND_MOVE_RELATIVE = 2,
	// D2D1_SVG_PATH_COMMAND_LINE_ABSOLUTE = 3, D2D1_SVG_PATH_COMMAND_LINE_RELATIVE = 4, D2D1_SVG_PATH_COMMAND_CUBIC_ABSOLUTE = 5,
	// D2D1_SVG_PATH_COMMAND_CUBIC_RELATIVE = 6, D2D1_SVG_PATH_COMMAND_QUADRADIC_ABSOLUTE = 7, D2D1_SVG_PATH_COMMAND_QUADRADIC_RELATIVE = 8,
	// D2D1_SVG_PATH_COMMAND_ARC_ABSOLUTE = 9, D2D1_SVG_PATH_COMMAND_ARC_RELATIVE = 10, D2D1_SVG_PATH_COMMAND_HORIZONTAL_ABSOLUTE = 11,
	// D2D1_SVG_PATH_COMMAND_HORIZONTAL_RELATIVE = 12, D2D1_SVG_PATH_COMMAND_VERTICAL_ABSOLUTE = 13, D2D1_SVG_PATH_COMMAND_VERTICAL_RELATIVE
	// = 14, D2D1_SVG_PATH_COMMAND_CUBIC_SMOOTH_ABSOLUTE = 15, D2D1_SVG_PATH_COMMAND_CUBIC_SMOOTH_RELATIVE = 16,
	// D2D1_SVG_PATH_COMMAND_QUADRADIC_SMOOTH_ABSOLUTE = 17, D2D1_SVG_PATH_COMMAND_QUADRADIC_SMOOTH_RELATIVE = 18,
	// D2D1_SVG_PATH_COMMAND_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1svg.h", MSDNShortId = "NE:d2d1svg.D2D1_SVG_PATH_COMMAND")]
	public enum D2D1_SVG_PATH_COMMAND : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Closes the current subpath. Uses no segment data.</para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_CLOSE_PATH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Starts a new subpath at the coordinate (x y). Uses 2 floats of segment data.</para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_MOVE_ABSOLUTE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Starts a new subpath at the coordinate (x y). Uses 2 floats of segment data.</para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_MOVE_RELATIVE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Draws a line to the coordinate (x y). Uses 2 floats of segment data.</para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_LINE_ABSOLUTE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Draws a line to the coordinate (x y). Uses 2 floats of segment data.</para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_LINE_RELATIVE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>
		/// Draws a cubic Bezier curve (x1 y1 x2 y2 x y). The curve ends at (x, y) and is defined by the two control points (x1, y1) and
		/// (x2, y2). Uses 6 floats of segment data.
		/// </para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_CUBIC_ABSOLUTE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>
		/// Draws a cubic Bezier curve (x1 y1 x2 y2 x y). The curve ends at (x, y) and is defined by the two control points (x1, y1) and
		/// (x2, y2). Uses 6 floats of segment data.
		/// </para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_CUBIC_RELATIVE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>
		/// Draws a quadratic Bezier curve (x1 y1 x y). The curve ends at (x, y) and is defined by the control point (x1 y1). Uses 4 floats
		/// of segment data.
		/// </para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_QUADRADIC_ABSOLUTE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>
		/// Draws a quadratic Bezier curve (x1 y1 x y). The curve ends at (x, y) and is defined by the control point (x1 y1). Uses 4 floats
		/// of segment data.
		/// </para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_QUADRADIC_RELATIVE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>
		/// Draws an elliptical arc (rx ry x-axis-rotation large-arc-flag sweep-flag x y). The curve ends at (x, y) and is defined by the
		/// arc parameters. The two flags are
		/// </para>
		/// <para>considered set if their values are non-zero. Uses 7 floats of segment data.</para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_ARC_ABSOLUTE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>
		/// Draws an elliptical arc (rx ry x-axis-rotation large-arc-flag sweep-flag x y). The curve ends at (x, y) and is defined by the
		/// arc parameters. The two flags are
		/// </para>
		/// <para>considered set if their values are non-zero. Uses 7 floats of segment data.</para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_ARC_RELATIVE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>Draws a horizontal line to the coordinate (x). Uses 1 float of segment data.</para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_HORIZONTAL_ABSOLUTE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <para>Draws a horizontal line to the coordinate (x). Uses 1 float of segment data.</para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_HORIZONTAL_RELATIVE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>13</para>
		/// <para>Draws a vertical line to the coordinate (y). Uses 1 float of segment data.</para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_VERTICAL_ABSOLUTE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>14</para>
		/// <para>Draws a vertical line to the coordinate (y). Uses 1 float of segment data.</para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_VERTICAL_RELATIVE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>15</para>
		/// <para>
		/// Draws a smooth cubic Bezier curve (x2 y2 x y). The curve ends at (x, y) and is defined by the control point (x2, y2). Uses 4
		/// floats of segment data.
		/// </para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_CUBIC_SMOOTH_ABSOLUTE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>16</para>
		/// <para>
		/// Draws a smooth cubic Bezier curve (x2 y2 x y). The curve ends at (x, y) and is defined by the control point (x2, y2). Uses 4
		/// floats of segment data.
		/// </para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_CUBIC_SMOOTH_RELATIVE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>17</para>
		/// <para>Draws a smooth quadratic Bezier curve ending at (x, y). Uses 2 floats of segment data.</para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_QUADRADIC_SMOOTH_ABSOLUTE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>18</para>
		/// <para>Draws a smooth quadratic Bezier curve ending at (x, y). Uses 2 floats of segment data.</para>
		/// </summary>
		D2D1_SVG_PATH_COMMAND_QUADRADIC_SMOOTH_RELATIVE,
	}

	/// <summary>Defines the coordinate system used for SVG gradient or clipPath elements.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/ne-d2d1svg-d2d1_svg_unit_type typedef enum D2D1_SVG_UNIT_TYPE {
	// D2D1_SVG_UNIT_TYPE_USER_SPACE_ON_USE = 0, D2D1_SVG_UNIT_TYPE_OBJECT_BOUNDING_BOX = 1, D2D1_SVG_UNIT_TYPE_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1svg.h", MSDNShortId = "NE:d2d1svg.D2D1_SVG_UNIT_TYPE")]
	public enum D2D1_SVG_UNIT_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The property is set to SVG's 'userSpaceOnUse' value.</para>
		/// </summary>
		D2D1_SVG_UNIT_TYPE_USER_SPACE_ON_USE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The property is set to SVG's 'objectBoundingBox' value.</para>
		/// </summary>
		D2D1_SVG_UNIT_TYPE_OBJECT_BOUNDING_BOX,
	}

	/// <summary>Specifies a value for the SVG visibility property.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/ne-d2d1svg-d2d1_svg_visibility typedef enum D2D1_SVG_VISIBILITY {
	// D2D1_SVG_VISIBILITY_VISIBLE = 0, D2D1_SVG_VISIBILITY_HIDDEN = 1, D2D1_SVG_VISIBILITY_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1svg.h", MSDNShortId = "NE:d2d1svg.D2D1_SVG_VISIBILITY")]
	public enum D2D1_SVG_VISIBILITY
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The element is visible.</para>
		/// </summary>
		D2D1_SVG_VISIBILITY_VISIBLE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The element is invisible.</para>
		/// </summary>
		D2D1_SVG_VISIBILITY_HIDDEN,
	}

	/// <summary>Interface describing an SVG attribute.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nn-d2d1svg-id2d1svgattribute
	[PInvokeData("d2d1svg.h", MSDNShortId = "NN:d2d1svg.ID2D1SvgAttribute")]
	[ComImport, Guid("c9cdb0dd-f8c9-4e70-b7c2-301c80292c5e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1SvgAttribute : ID2D1Resource
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Returns the element on which this attribute is set. Returns null if the attribute is not set on any element.</summary>
		/// <param name="element">
		/// <para>Type: <b>ID2D1SvgElement**</b></para>
		/// <para>When this method completes, this will contain a pointer to the element on which this attribute is set.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgattribute-getelement void GetElement( [out]
		// ID2D1SvgElement **element );
		[PreserveSig]
		void GetElement(out ID2D1SvgElement element);

		/// <summary>Creates a clone of this attribute value. On creation, the cloned attribute is not set on any element.</summary>
		/// <returns>
		/// <para>Type: <b>ID2D1SvgAttribute**</b></para>
		/// <para>Specifies the attribute value to clone.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgattribute-clone HRESULT Clone( [out]
		// ID2D1SvgAttribute **attribute );
		ID2D1SvgAttribute Clone();
	}

	/// <summary>Represents an SVG document.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nn-d2d1svg-id2d1svgdocument
	[PInvokeData("d2d1svg.h", MSDNShortId = "NN:d2d1svg.ID2D1SvgDocument")]
	[ComImport, Guid("86b88e4d-afa4-4d7b-88e4-68a51c4a0aec"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1SvgDocument : ID2D1Resource
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Sets the size of the initial viewport.</summary>
		/// <param name="viewportSize">
		/// <para>Type: <b>D2D1_SIZE_F</b></para>
		/// <para>The size of the viewport.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgdocument-setviewportsize HRESULT SetViewportSize(
		// D2D1_SIZE_F viewportSize );
		void SetViewportSize(D2D_SIZE_F viewportSize);

		/// <summary>Returns the size of the initial viewport.</summary>
		/// <returns>
		/// <para>Type: <b>D2D1_SIZE_F</b></para>
		/// <para>Returns the size of the initial viewport</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgdocument-getviewportsize D2D1_SIZE_F GetViewportSize();
		[PreserveSig]
		D2D_SIZE_F GetViewportSize();

		/// <summary>
		/// Sets the root element of the document.The root element must be an svg element. If the element already exists within an svg tree,
		/// it is first removed.
		/// </summary>
		/// <param name="root">
		/// <para>Type: <b>ID2D1SvgElement*</b></para>
		/// <para>The new root element of the document.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgdocument-setroot HRESULT SetRoot( [in, optional]
		// ID2D1SvgElement *root );
		void SetRoot([In] ID2D1SvgElement root);

		/// <summary>Gets the root element of the document.</summary>
		/// <param name="root">
		/// <para>Type: <b>ID2D1SvgElement**</b></para>
		/// <para>Outputs the root element of the document.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgdocument-getroot void GetRoot( [out]
		// ID2D1SvgElement **root );
		[PreserveSig]
		void GetRoot(out ID2D1SvgElement root);

		/// <summary>Gets the SVG element with the specified ID.</summary>
		/// <param name="id">
		/// <para>Type: <b>PCWSTR</b></para>
		/// <para>ID of the element to retrieve.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>ID2D1SvgElement**</b></para>
		/// <para>The element matching the specified ID. If the element cannot be found, the returned element will be null.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgdocument-findelementbyid HRESULT FindElementById(
		// [in] PCWSTR id, ID2D1SvgElement **svgElement );
		ID2D1SvgElement FindElementById([MarshalAs(UnmanagedType.LPWStr)] string id);

		/// <summary>Serializes an element and its subtree to XML. The output XML is encoded as UTF-8.</summary>
		/// <param name="outputXmlStream">
		/// <para>Type: <b>IStream*</b></para>
		/// <para>An output stream to contain the SVG XML subtree.</para>
		/// </param>
		/// <param name="subtree">
		/// <para>Type: <b>ID2D1SvgElement*</b></para>
		/// <para>The root of the subtree. If null, the entire document is serialized.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgdocument-serialize HRESULT Serialize( [in] IStream
		// *outputXmlStream, [in, optional] ID2D1SvgElement *subtree );
		void Serialize([In] IStream outputXmlStream, [In, Optional] ID2D1SvgElement? subtree);

		/// <summary>
		/// Deserializes a subtree from the stream. The stream must have only one root element, but that root element need not be an 'svg'
		/// element. The output element is not inserted into this document tree.
		/// </summary>
		/// <param name="inputXmlStream">
		/// <para>Type: <b>IStream*</b></para>
		/// <para>An input stream containing the SVG XML subtree.</para>
		/// </param>
		/// <param name="subtree">
		/// <para>Type: <b>ID2D1SvgElement**</b></para>
		/// <para>The root of the subtree.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgdocument-deserialize HRESULT Deserialize( [in]
		// IStream *inputXmlStream, [out] ID2D1SvgElement **subtree );
		void Deserialize([In] IStream inputXmlStream, out ID2D1SvgElement subtree);

		/// <summary>Creates a paint object which can be used to set the 'fill' or 'stroke' properties.</summary>
		/// <param name="paintType">
		/// <para>Type: <b><c>D2D1_SVG_PAINT_TYPE</c></b></para>
		/// <para>Specifies the type of paint object to create.</para>
		/// </param>
		/// <param name="color">
		/// <para>Type: <b>const D2D1_COLOR_F</b></para>
		/// <para>The color used if the paintType is D2D1_SVG_PAINT_TYPE_COLOR.</para>
		/// </param>
		/// <param name="id">
		/// <para>Type: <b>PCWSTR</b></para>
		/// <para>The element id which acts as the paint server. This id is used if the paint type is D2D1_SVG_PAINT_TYPE_URI.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>ID2D1SvgPaint**</b></para>
		/// <para>When the method completes, this will contain a pointer to the created paint object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgdocument-createpaint(d2d1_svg_paint_type_constd2d1_color_f__pcwstr_id2d1svgpaint)
		// HRESULT CreatePaint( D2D1_SVG_PAINT_TYPE paintType, [ref] const D2D1_COLOR_F &amp; color, [in, optional] PCWSTR id, [out]
		// ID2D1SvgPaint **paint );
		ID2D1SvgPaint CreatePaint(D2D1_SVG_PAINT_TYPE paintType, [In, Optional] StructPointer<D2D1_COLOR_F> color, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? id);

		/// <summary>Creates a dash array object which can be used to set the stroke-dasharray property.</summary>
		/// <param name="dashes">
		/// <para>Type: <b>const <c>D2D1_SVG_LENGTH</c>*</b></para>
		/// <para>An array of dashes.</para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Size of the array in th dashes argument.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>ID2D1SvgStrokeDashArray**</b></para>
		/// <para>The created <c>ID2D1SvgStrokeDashArray</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgdocument-createstrokedasharray HRESULT
		// CreateStrokeDashArray( [in, optional] const D2D1_SVG_LENGTH *dashes, UINT32 dashesCount, [out] ID2D1SvgStrokeDashArray
		// **strokeDashArray );
		ID2D1SvgStrokeDashArray CreateStrokeDashArray([In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D1_SVG_LENGTH[]? dashes, [Optional] int dashesCount);

		/// <summary>Creates a points object which can be used to set a points attribute on a polygon or polyline element.</summary>
		/// <param name="points">
		/// <para>Type: <b>const D2D1_POINT_2F*</b></para>
		/// <para>The points in the point collection.</para>
		/// </param>
		/// <param name="pointsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of points in the points argument.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>ID2D1SvgPointCollection**</b></para>
		/// <para>The created <c>ID2D1SvgPointCollection</c> object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgdocument-createpointcollection HRESULT
		// CreatePointCollection( [in, optional] const D2D1_POINT_2F *points, UINT32 pointsCount, [out] ID2D1SvgPointCollection
		// **pointCollection );
		ID2D1SvgPointCollection CreatePointCollection([In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D_POINT_2F[]? points, [Optional] int pointsCount);

		/// <summary>Creates a path data object which can be used to set a 'd' attribute on a 'path' element.</summary>
		/// <param name="segmentData">
		/// <para>Type: <b>const FLOAT*</b></para>
		/// <para>An array of segment data.</para>
		/// </param>
		/// <param name="segmentDataCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Number of items in segmentData.</para>
		/// </param>
		/// <param name="commands">
		/// <para>Type: <b>const <c>D2D1_SVG_PATH_COMMAND</c>*</b></para>
		/// <para>An array of path commands.</para>
		/// </param>
		/// <param name="commandsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of items in commands.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>ID2D1SvgPathData**</b></para>
		/// <para>When this method completes, this points to the created path data.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgdocument-createpathdata HRESULT CreatePathData(
		// [in, optional] const FLOAT *segmentData, UINT32 segmentDataCount, [in, optional] const D2D1_SVG_PATH_COMMAND *commands, UINT32
		// commandsCount, [out] ID2D1SvgPathData **pathData );
		ID2D1SvgPathData CreatePathData([In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[]? segmentData,
			[Optional] int segmentDataCount, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D2D1_SVG_PATH_COMMAND[]? commands,
			[Optional] int commandsCount);
	}

	/// <summary>Interface for all SVG elements.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nn-d2d1svg-id2d1svgelement
	[PInvokeData("d2d1svg.h", MSDNShortId = "NN:d2d1svg.ID2D1SvgElement")]
	[ComImport, Guid("ac7b67a6-183e-49c1-a823-0ebe40b0db29"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1SvgElement : ID2D1Resource
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Gets the document that contains this element.</summary>
		/// <param name="document">
		/// <para>Type: <b>ID2D1SvgDocument**</b></para>
		/// <para>Outputs the document that contains this element. This argument will be null if the element has been removed from the tree.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-getdocument void GetDocument( [out]
		// ID2D1SvgDocument **document );
		[PreserveSig]
		void GetDocument(out ID2D1SvgDocument document);

		/// <summary>Gets the tag name.</summary>
		/// <param name="name">
		/// <para>Type: <b>PWSTR</b></para>
		/// <para>The tag name.</para>
		/// </param>
		/// <param name="nameCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Length of the value in the name argument.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-gettagname HRESULT GetTagName( [out] PWSTR
		// name, UINT32 nameCount );
		void GetTagName([In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name, uint nameCount);

		/// <summary>Gets the string length of the tag name.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the string length of the tag name. The returned string length does not include room for the null terminator.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-gettagnamelength UINT32 GetTagNameLength();
		[PreserveSig]
		uint GetTagNameLength();

		/// <summary>Returns a boolean indicating whether this element represents text content.</summary>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>
		/// Returns TRUE if this element represents text content, e.g. the content of a 'title' or 'desc' element. Text content does not
		/// have a tag name.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-istextcontent BOOL IsTextContent();
		[PreserveSig]
		bool IsTextContent();

		/// <summary>Gets the parent element.</summary>
		/// <param name="parent">
		/// <para>Type: <b>ID2D1SvgElement**</b></para>
		/// <para>Outputs the parent element.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-getparent void GetParent( [out]
		// ID2D1SvgElement **parent );
		[PreserveSig]
		void GetParent(out ID2D1SvgElement parent);

		/// <summary>Returns a boolean indicating whether this element has children.</summary>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Returns TRUE if this element has children.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-haschildren BOOL HasChildren();
		[PreserveSig]
		bool HasChildren();

		/// <summary>Gets the first child of this element.</summary>
		/// <param name="child">
		/// <para>Type: <b>ID2D1SvgElement**</b></para>
		/// <para>Outputs the first child of this element.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-getfirstchild void GetFirstChild( [out]
		// ID2D1SvgElement **child );
		[PreserveSig]
		void GetFirstChild(out ID2D1SvgElement child);

		/// <summary>Gets the last child of this element.</summary>
		/// <param name="child">
		/// <para>Type: <b>ID2D1SvgElement**</b></para>
		/// <para>Outputs the last child of this element.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-getlastchild void GetLastChild( [out]
		// ID2D1SvgElement **child );
		[PreserveSig]
		void GetLastChild(out ID2D1SvgElement child);

		/// <summary>Gets the previous sibling of the referenceChild element.</summary>
		/// <param name="referenceChild">
		/// <para>Type: <b>ID2D1SvgElement*</b></para>
		/// <para>The referenceChild must be an immediate child of this element.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>ID2D1SvgElement**</b></para>
		/// <para>
		/// The output previousChild element will be non-null if the referenceChild has a previous sibling. If the referenceChild is the
		/// first child, the output is null.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-getpreviouschild HRESULT GetPreviousChild(
		// [in] ID2D1SvgElement *referenceChild, ID2D1SvgElement **previousChild );
		ID2D1SvgElement GetPreviousChild([In] ID2D1SvgElement referenceChild);

		/// <summary>Gets the next sibling of the referenceChild element.</summary>
		/// <param name="referenceChild">
		/// <para>Type: <b>ID2D1SvgElement*</b></para>
		/// <para>The referenceChild must be an immediate child of this element.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>ID2D1SvgElement**</b></para>
		/// <para>
		/// The output nextChild element will be non-null if the referenceChild has a next sibling. If the referenceChild is the last child,
		/// the output is null.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-getnextchild HRESULT GetNextChild( [in]
		// ID2D1SvgElement *referenceChild, ID2D1SvgElement **nextChild );
		ID2D1SvgElement GetNextChild([In] ID2D1SvgElement referenceChild);

		/// <summary>
		/// Inserts newChild as a child of this element, before the referenceChild element. If the newChild element already has a parent, it
		/// is removed from this parent as part of the insertion.
		/// </summary>
		/// <param name="newChild">
		/// <para>Type: <b>ID2D1SvgElement*</b></para>
		/// <para>The element to be inserted.</para>
		/// </param>
		/// <param name="referenceChild">
		/// <para>Type: <b>ID2D1SvgElement*</b></para>
		/// <para>
		/// The element that the child should be inserted before. If referenceChild is null, the newChild is placed as the last child. If
		/// referenceChild is non-null, it must be an immediate child of this element.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-insertchildbefore HRESULT
		// InsertChildBefore( [in] ID2D1SvgElement *newChild, [in, optional] ID2D1SvgElement *referenceChild );
		void InsertChildBefore([In] ID2D1SvgElement newChild, [In, Optional] ID2D1SvgElement? referenceChild);

		/// <summary>
		/// Appends an element to the list of children. If the element already has a parent, it is removed from this parent as part of the
		/// append operation.
		/// </summary>
		/// <param name="newChild">
		/// <para>Type: <b>ID2D1SvgElement*</b></para>
		/// <para>The element to append.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-appendchild HRESULT AppendChild( [in]
		// ID2D1SvgElement *newChild );
		void AppendChild([In] ID2D1SvgElement newChild);

		/// <summary>
		/// Replaces the oldChild element with the newChild. This operation removes the oldChild from the tree. If the newChild element
		/// already has a parent, it is removed from this parent as part of the replace operation.
		/// </summary>
		/// <param name="newChild">
		/// <para>Type: <b>ID2D1SvgElement*</b></para>
		/// <para>The element to be inserted.</para>
		/// </param>
		/// <param name="oldChild">
		/// <para>Type: <b>ID2D1SvgElement*</b></para>
		/// <para>The child element to be replaced. The oldChild element must be an immediate child of this element.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-replacechild HRESULT ReplaceChild( [in]
		// ID2D1SvgElement *newChild, [in] ID2D1SvgElement *oldChild );
		void ReplaceChild([In] ID2D1SvgElement newChild, [In] ID2D1SvgElement oldChild);

		/// <summary>Removes the oldChild from the tree. Children of oldChild remain children of oldChild.</summary>
		/// <param name="oldChild">
		/// <para>Type: <b>ID2D1SvgElement*</b></para>
		/// <para>The child element to be removed. The oldChild element must be an immediate child of this element.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-removechild HRESULT RemoveChild( [in]
		// ID2D1SvgElement *oldChild );
		void RemoveChild([In] ID2D1SvgElement oldChild);

		/// <summary>Creates an element from a tag name. The element is appended to the list of children.</summary>
		/// <param name="tagName">
		/// <para>Type: <b>PCWSTR</b></para>
		/// <para>The tag name of the new child. An empty string is interpreted to be a text content element.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>ID2D1SvgElement**</b></para>
		/// <para>The new child element.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-createchild HRESULT CreateChild( [in]
		// PCWSTR tagName, [out] ID2D1SvgElement **newChild );
		ID2D1SvgElement CreateChild([MarshalAs(UnmanagedType.LPWStr)] string tagName);

		/// <summary>Returns a boolean indicating if the attribute is explicitly set on the element.</summary>
		/// <param name="name">
		/// <para>Type: <b>PCWSTR</b></para>
		/// <para>The name of the attribute.</para>
		/// </param>
		/// <param name="inherited">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Outputs whether the attribute is set to the inherit value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>
		/// TReturns true if the attribute is explicitly set on the element or if it is present within an inline style. Returns FALSE if the
		/// attribute is not a valid attribute on this element.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-isattributespecified BOOL
		// IsAttributeSpecified( [in] PCWSTR name, [out, optional] BOOL *inherited );
		[PreserveSig]
		bool IsAttributeSpecified([MarshalAs(UnmanagedType.LPWStr)] string name, out bool inherited);

		/// <summary>
		/// Returns the number of specified attributes on this element. Attributes are only considered specified if they are explicitly set
		/// on the element or present within an inline style. Properties that receive their value through CSS inheritance are not considered
		/// specified. An attribute can become specified if it is set through a method call. It can become unspecified if it is removed via <c>RemoveAttribute</c>.
		/// </summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the number of specified attributes on this element.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-getspecifiedattributecount UINT32 GetSpecifiedAttributeCount();
		[PreserveSig]
		uint GetSpecifiedAttributeCount();

		/// <summary>Gets the name of the attribute at the given index.</summary>
		/// <param name="index">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the attribute.</para>
		/// </param>
		/// <param name="name">
		/// <para>Type: <b>PWSTR</b></para>
		/// <para>Outputs the name of the attribute.</para>
		/// </param>
		/// <param name="nameCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Length of the string returned in the name argument.</para>
		/// </param>
		/// <param name="inherited">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Outputs whether the attribute is set to the inherit value.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-getspecifiedattributename HRESULT
		// GetSpecifiedAttributeName( UINT32 index, [out] PWSTR name, UINT32 nameCount, [out, optional] BOOL *inherited );
		void GetSpecifiedAttributeName(uint index, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name, uint nameCount, out bool inherited);

		/// <summary>
		/// Gets the string length of the name of the specified attribute at the given index. The output string length does not include room
		/// for the null terminator.
		/// </summary>
		/// <param name="index">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the attribute.</para>
		/// </param>
		/// <param name="nameLength">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>Outputs the string length of the name of the specified attribute.</para>
		/// </param>
		/// <param name="inherited">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Indicates whether the attribute is set to the inherit value.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-getspecifiedattributenamelength HRESULT
		// GetSpecifiedAttributeNameLength( UINT32 index, [out] UINT32 *nameLength, [out, optional] BOOL *inherited );
		void GetSpecifiedAttributeNameLength(uint index, out uint nameLength, [Out, Optional] StructPointer<BOOL> inherited);

		/// <summary>Removes the attribute from this element. Also removes this attribute from within an inline style if present.</summary>
		/// <param name="name">
		/// <para>Type: <b>PCWSTR</b></para>
		/// <para>The name of the attribute to remove.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-removeattribute HRESULT RemoveAttribute(
		// [in] PCWSTR name );
		void RemoveAttribute([MarshalAs(UnmanagedType.LPWStr)] string name);

		/// <summary>Sets the value of a text content element.</summary>
		/// <param name="name">
		/// <para>Type: <b>const WCHAR*</b></para>
		/// <para>The new value of the text content element.</para>
		/// </param>
		/// <param name="nameCount">Type: <b>UINT32</b></param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-settextvalue HRESULT SetTextValue( [in]
		// const WCHAR *name, UINT32 nameCount );
		void SetTextValue([MarshalAs(UnmanagedType.LPWStr)] string name, uint nameCount);

		/// <summary>Gets the value of a text content element.</summary>
		/// <param name="name">
		/// <para>Type: <b>PWSTR</b></para>
		/// <para>The value of the text content element.</para>
		/// </param>
		/// <param name="nameCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The length of the value in the name argument.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-gettextvalue HRESULT GetTextValue( [out]
		// PWSTR name, UINT32 nameCount );
		void GetTextValue([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder name, uint nameCount);

		/// <summary>Gets the length of the text content value.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the length of the text content value. The returned string length does not include room for the null terminator.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-gettextvaluelength UINT32 GetTextValueLength();
		[PreserveSig]
		uint GetTextValueLength();

		/// <summary>Sets an attribute of this element using a string.</summary>
		/// <param name="name">
		/// <para>Type: <b>PCWSTR</b></para>
		/// <para>Name of the attribute to set.</para>
		/// </param>
		/// <param name="type">
		/// <para>Type: <b><c>D2D1_SVG_ATTRIBUTE_STRING_TYPE</c></b></para>
		/// <para>The type of the string.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <b>PCWSTR</b></para>
		/// <para>The new value of the attribute.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-setattributevalue(pcwstr_d2d1_svg_attribute_string_type_pcwstr)
		// HRESULT SetAttributeValue( [in] PCWSTR name, D2D1_SVG_ATTRIBUTE_STRING_TYPE type, [in] PCWSTR value );
		void SetAttributeValue([MarshalAs(UnmanagedType.LPWStr)] string name, D2D1_SVG_ATTRIBUTE_STRING_TYPE type, [MarshalAs(UnmanagedType.LPWStr)] string value);

		/// <summary>Gets an attribute of this element as a string.</summary>
		/// <param name="name">
		/// <para>Type: [in] <b>PCWSTR</b></para>
		/// <para>The name of the attribute.</para>
		/// </param>
		/// <param name="type">
		/// <para>Type: [in] <b><c>D2D1_SVG_ATTRIBUTE_STRING_TYPE</c></b></para>
		/// <para>The string type.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: [out] <b>PWSTR</b></para>
		/// <para>The value of the attribute.</para>
		/// </param>
		/// <param name="valueCount">
		/// <para>Type: [out] <b>UINT32</b></para>
		/// <para>The number of elements in the returned value.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-getattributevalue(pcwstr_d2d1_svg_attribute_string_type_pwstr_uint32)
		// HRESULT GetAttributeValue( PCWSTR name, D2D1_SVG_ATTRIBUTE_STRING_TYPE type, PWSTR value, UINT32 valueCount );
		[PreserveSig]
		HRESULT GetAttributeValue([MarshalAs(UnmanagedType.LPWStr)] string name, D2D1_SVG_ATTRIBUTE_STRING_TYPE type,
			[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder value, uint valueCount);

		/// <summary>Gets the string length of an attribute of this element.</summary>
		/// <param name="name">
		/// <para>Type: <b>PCWSTR</b></para>
		/// <para>The name of the attribute.</para>
		/// </param>
		/// <param name="type">
		/// <para>Type: <b><c>D2D1_SVG_ATTRIBUTE_STRING_TYPE</c></b></para>
		/// <para>The string type of the attribute.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>The length of the attribute. The returned string length does not include room for the null terminator.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-getattributevaluelength HRESULT
		// GetAttributeValueLength( [in] PCWSTR name, D2D1_SVG_ATTRIBUTE_STRING_TYPE type, [out] UINT32 *valueLength );
		uint GetAttributeValueLength([MarshalAs(UnmanagedType.LPWStr)] string name, D2D1_SVG_ATTRIBUTE_STRING_TYPE type);

		/// <summary>Sets an attribute of this element using a POD type.</summary>
		/// <param name="name">
		/// <para>Type: <b>PCWSTR</b></para>
		/// <para>Name of the attribute to set.</para>
		/// </param>
		/// <param name="type">
		/// <para>Type: <b><c>D2D1_SVG_ATTRIBUTE_POD_TYPE</c></b></para>
		/// <para>The POD type of the attribute.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <b>const void*</b></para>
		/// <para>The new value of the attribute.</para>
		/// </param>
		/// <param name="valueSizeInBytes">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The size of the new value in bytes.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-setattributevalue(pcwstr_d2d1_svg_attribute_pod_type_constvoid_uint32)
		// HRESULT SetAttributeValue( [in] PCWSTR name, D2D1_SVG_ATTRIBUTE_POD_TYPE type, [in] const void *value, UINT32 valueSizeInBytes );
		void SetAttributeValue([MarshalAs(UnmanagedType.LPWStr)] string name, D2D1_SVG_ATTRIBUTE_POD_TYPE type, [In] IntPtr value, uint valueSizeInBytes);

		/// <summary>Gets an attribute of this element as a POD type.</summary>
		/// <param name="name">
		/// <para>Type: <b>PCWSTR</b></para>
		/// <para>The name of the attribute.</para>
		/// </param>
		/// <param name="type">
		/// <para>Type: <b><c>D2D1_SVG_ATTRIBUTE_POD_TYPE</c></b></para>
		/// <para>The POD type of the value.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <b>void*</b></para>
		/// <para>The value of the attribute.</para>
		/// </param>
		/// <param name="valueSizeInBytes">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The size of the value in bytes.</para>
		/// </param>
		/// <returns>
		/// This method returns an HRESULT success or error code. Returns an error if the attribute name is not valid on this element.
		/// Returns an error if the attribute cannot be expressed as the specified string type. Returns an error if the attribute is not specified.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-getattributevalue(pcwstr_d2d1_svg_attribute_pod_type_void_uint32)
		// HRESULT GetAttributeValue( [in] PCWSTR name, D2D1_SVG_ATTRIBUTE_POD_TYPE type, [out] void *value, UINT32 valueSizeInBytes );
		[PreserveSig]
		HRESULT GetAttributeValue([MarshalAs(UnmanagedType.LPWStr)] string name, D2D1_SVG_ATTRIBUTE_POD_TYPE type, [Out] IntPtr value, uint valueSizeInBytes);

		/// <summary>
		/// <para>Sets an attribute of this element using an interface.</para>
		/// <para>A given attribute object may only be set on one element in one attribute location at a time.</para>
		/// </summary>
		/// <param name="name">
		/// <para>Type: <b>PCWSTR</b></para>
		/// <para>Name of the attribute to set.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <b>ID2D1SvgAttribute*</b></para>
		/// <para>The new value of the attribute.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-setattributevalue(pcwstr_id2d1svgattribute)
		// HRESULT SetAttributeValue( [in] PCWSTR name, [in] ID2D1SvgAttribute *value );
		void SetAttributeValue([MarshalAs(UnmanagedType.LPWStr)] string name, [In] ID2D1SvgAttribute value);

		/// <summary>Gets an attribute of this element as an interface type.</summary>
		/// <param name="name">
		/// <para>Type: <b>PCWSTR</b></para>
		/// <para>The name of the attribute.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The interface ID of the attribute value.</para>
		/// </param>
		/// <param name="value">
		/// <para>Type: <b>void**</b></para>
		/// <para>The value of the attribute.</para>
		/// </param>
		/// <returns>
		/// This method returns an HRESULT success or error code. Returns an error if the attribute name is not valid on this element.
		/// Returns an error if the attribute cannot be expressed as the specified string type. Returns an error if the attribute is not specified.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgelement-getattributevalue(pcwstr_refiid_void)
		// HRESULT GetAttributeValue( [in] PCWSTR name, [in] REFIID riid, void **value );
		[PreserveSig]
		HRESULT GetAttributeValue([MarshalAs(UnmanagedType.LPWStr)] string name, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object? value);
	}

	/// <summary>Interface describing an SVG fill or stroke value.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nn-d2d1svg-id2d1svgpaint
	[PInvokeData("d2d1svg.h", MSDNShortId = "NN:d2d1svg.ID2D1SvgPaint")]
	[ComImport, Guid("d59bab0a-68a2-455b-a5dc-9eb2854e2490"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1SvgPaint : ID2D1SvgAttribute, ID2D1Resource
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Returns the element on which this attribute is set. Returns null if the attribute is not set on any element.</summary>
		/// <param name="element">
		/// <para>Type: <b>ID2D1SvgElement**</b></para>
		/// <para>When this method completes, this will contain a pointer to the element on which this attribute is set.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgattribute-getelement void GetElement( [out]
		// ID2D1SvgElement **element );
		[PreserveSig]
		new void GetElement(out ID2D1SvgElement element);

		/// <summary>Creates a clone of this attribute value. On creation, the cloned attribute is not set on any element.</summary>
		/// <returns>
		/// <para>Type: <b>ID2D1SvgAttribute**</b></para>
		/// <para>Specifies the attribute value to clone.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgattribute-clone HRESULT Clone( [out]
		// ID2D1SvgAttribute **attribute );
		new ID2D1SvgAttribute Clone();

		/// <summary>Sets the paint type.</summary>
		/// <param name="paintType">
		/// <para>Type: <b><c>D2D1_SVG_PAINT_TYPE</c></b></para>
		/// <para>The new paint type.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpaint-setpainttype HRESULT SetPaintType(
		// D2D1_SVG_PAINT_TYPE paintType );
		void SetPaintType(D2D1_SVG_PAINT_TYPE paintType);

		/// <summary>Gets the paint type.</summary>
		/// <returns>
		/// <para>Type: <b><c>D2D1_SVG_PAINT_TYPE</c></b></para>
		/// <para>Returns the paint type.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpaint-getpainttype D2D1_SVG_PAINT_TYPE GetPaintType();
		[PreserveSig]
		D2D1_SVG_PAINT_TYPE GetPaintType();

		/// <summary>Sets the paint color that is used if the paint type is D2D1_SVG_PAINT_TYPE_COLOR.</summary>
		/// <param name="color">
		/// <para>Type: <b>const D2D1_COLOR_F</b></para>
		/// <para>The new paint color.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpaint-setcolor(constd2d1_color_f_) HRESULT
		// SetColor( [ref] const D2D1_COLOR_F &amp; color );
		void SetColor(in D3DCOLORVALUE color);

		/// <summary>Gets the paint color that is used if the paint type is D2D1_SVG_PAINT_TYPE_COLOR.</summary>
		/// <param name="color">
		/// <para>Type: <b>D2D1_COLOR_F*</b></para>
		/// <para>The paint color that is used if the paint type is D2D1_SVG_PAINT_TYPE_COLOR.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpaint-getcolor void GetColor( [out] D2D1_COLOR_F
		// *color );
		[PreserveSig]
		void GetColor(out D3DCOLORVALUE color);

		/// <summary>Sets the element id which acts as the paint server. This id is used if the paint type is D2D1_SVG_PAINT_TYPE_URI.</summary>
		/// <param name="id">
		/// <para>Type: <b>PCWSTR</b></para>
		/// <para>The element id which acts as the paint server. This id is used if the paint type is D2D1_SVG_PAINT_TYPE_URI.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpaint-setid HRESULT SetId( [in] PCWSTR id );
		void SetId([MarshalAs(UnmanagedType.LPWStr)] string id);

		/// <summary>Gets the element id which acts as the paint server. This id is used if the paint type is D2D1_SVG_PAINT_TYPE_URI.</summary>
		/// <param name="id">
		/// <para>Type: <b>PWSTR</b></para>
		/// <para>The element id which acts as the paint server.</para>
		/// </param>
		/// <param name="idCount">Type: <b>UINT32</b></param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpaint-getid HRESULT GetId( [out] PWSTR id, UINT32
		// idCount );
		void GetId([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder id, uint idCount);

		/// <summary>Gets the string length of the element id which acts as the paint server. This id is used if the paint type is D2D1_SVG_PAINT_TYPE_URI.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>
		/// the string length of the element id which acts as the paint server. The returned string length does not include room for the
		/// null terminator.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpaint-getidlength UINT32 GetIdLength();
		[PreserveSig]
		uint GetIdLength();
	}

	/// <summary>
	/// <para>Interface describing SVG path data. Path data can be set as the 'd' attribute on a 'path' element.</para>
	/// <para>
	/// The path data set is factored into two arrays. The segment data array stores all numbers and the commands array stores the set of
	/// commands. Unlike the string data set in the d attribute, each command in this representation uses a fixed number of elements in the
	/// segment data array. Therefore, the path 'M 0,0 100,0 0,100 Z' is represented as: 'M0,0 L100,0 L0,100 Z'. This is split into two
	/// arrays, with the segment data containing '0,0 100,0 0,100', and the commands containing 'M L L Z'.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nn-d2d1svg-id2d1svgpathdata
	[PInvokeData("d2d1svg.h", MSDNShortId = "NN:d2d1svg.ID2D1SvgPathData")]
	[ComImport, Guid("c095e4f4-bb98-43d6-9745-4d1b84ec9888"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1SvgPathData : ID2D1SvgAttribute, ID2D1Resource
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Returns the element on which this attribute is set. Returns null if the attribute is not set on any element.</summary>
		/// <param name="element">
		/// <para>Type: <b>ID2D1SvgElement**</b></para>
		/// <para>When this method completes, this will contain a pointer to the element on which this attribute is set.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgattribute-getelement void GetElement( [out]
		// ID2D1SvgElement **element );
		[PreserveSig]
		new void GetElement(out ID2D1SvgElement element);

		/// <summary>Creates a clone of this attribute value. On creation, the cloned attribute is not set on any element.</summary>
		/// <returns>
		/// <para>Type: <b>ID2D1SvgAttribute**</b></para>
		/// <para>Specifies the attribute value to clone.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgattribute-clone HRESULT Clone( [out]
		// ID2D1SvgAttribute **attribute );
		new ID2D1SvgAttribute Clone();

		/// <summary>Removes data from the end of the segment data array.</summary>
		/// <param name="dataCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Specifies how much data to remove.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpathdata-removesegmentdataatend HRESULT
		// RemoveSegmentDataAtEnd( UINT32 dataCount );
		void RemoveSegmentDataAtEnd(uint dataCount);

		/// <summary>
		/// Updates the segment data array. Existing segment data not updated by this method are preserved. The array is resized larger if
		/// necessary to accommodate the new segment data.
		/// </summary>
		/// <param name="data">
		/// <para>Type: <b>const FLOAT*</b></para>
		/// <para>The data array.</para>
		/// </param>
		/// <param name="dataCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of data to update.</para>
		/// </param>
		/// <param name="startIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index at which to begin updating segment data. Must be less than or equal to the size of the segment data array.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpathdata-updatesegmentdata HRESULT
		// UpdateSegmentData( [in] const FLOAT *data, UINT32 dataCount, UINT32 startIndex );
		void UpdateSegmentData([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] data, int dataCount, uint startIndex = 0);

		/// <summary>Gets data from the segment data array.</summary>
		/// <param name="data">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>Buffer to contain the segment data array.</para>
		/// </param>
		/// <param name="dataCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The element count of the buffer.</para>
		/// </param>
		/// <param name="startIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the first segment data to retrieve.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpathdata-getsegmentdata HRESULT GetSegmentData(
		// [out] FLOAT *data, UINT32 dataCount, UINT32 startIndex );
		void GetSegmentData([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] data, int dataCount, uint startIndex = 0);

		/// <summary>Gets the size of the segment data array.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the size of the segment data array.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpathdata-getsegmentdatacount UINT32 GetSegmentDataCount();
		[PreserveSig]
		uint GetSegmentDataCount();

		/// <summary>Removes commands from the end of the commands array.</summary>
		/// <param name="commandsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Specifies how many commands to remove.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpathdata-removecommandsatend HRESULT
		// RemoveCommandsAtEnd( UINT32 commandsCount );
		void RemoveCommandsAtEnd(uint commandsCount);

		/// <summary>
		/// Updates the commands array. Existing commands not updated by this method are preserved. The array is resized larger if necessary
		/// to accommodate the new commands.
		/// </summary>
		/// <param name="commands">
		/// <para>Type: <b>const <c>D2D1_SVG_PATH_COMMAND</c>*</b></para>
		/// <para>The commands array.</para>
		/// </param>
		/// <param name="commandsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of commands to update.</para>
		/// </param>
		/// <param name="startIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index at which to begin updating commands. Must be less than or equal to the size of the commands array.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpathdata-updatecommands HRESULT UpdateCommands(
		// [in] const D2D1_SVG_PATH_COMMAND *commands, UINT32 commandsCount, UINT32 startIndex );
		void UpdateCommands([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D1_SVG_PATH_COMMAND[] commands, int commandsCount, uint startIndex = 0);

		/// <summary>Gets commands from the commands array.</summary>
		/// <param name="commands">
		/// <para>Type: <b><c>D2D1_SVG_PATH_COMMAND</c>*</b></para>
		/// <para>Buffer to contain the commands.</para>
		/// </param>
		/// <param name="commandsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The element count of the buffer.</para>
		/// </param>
		/// <param name="startIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the first commands to retrieve.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpathdata-getcommands HRESULT GetCommands( [out]
		// D2D1_SVG_PATH_COMMAND *commands, UINT32 commandsCount, UINT32 startIndex );
		void GetCommands([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D1_SVG_PATH_COMMAND[] commands, int commandsCount, uint startIndex = 0);

		/// <summary>Gets the size of the commands array.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the size of the commands array.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpathdata-getcommandscount UINT32 GetCommandsCount();
		[PreserveSig]
		uint GetCommandsCount();

		/// <summary>Creates a path geometry object representing the path data.</summary>
		/// <param name="fillMode">
		/// <para>Type: <b><c>D2D1_FILL_MODE</c></b></para>
		/// <para>Fill mode for the path geometry object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>ID2D1PathGeometry1**</b></para>
		/// <para>On completion, pathGeometry will contain a point to the created <c>ID2D1PathGeometry1</c> object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpathdata-createpathgeometry HRESULT
		// CreatePathGeometry( D2D1_FILL_MODE fillMode, [out] ID2D1PathGeometry1 **pathGeometry );
		ID2D1PathGeometry1 CreatePathGeometry(D2D1_FILL_MODE fillMode);
	}

	/// <summary>Interface describing an SVG points value in a polyline or polygon element.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nn-d2d1svg-id2d1svgpointcollection
	[PInvokeData("d2d1svg.h", MSDNShortId = "NN:d2d1svg.ID2D1SvgPointCollection")]
	[ComImport, Guid("9dbe4c0d-3572-4dd9-9825-5530813bb712"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1SvgPointCollection : ID2D1SvgAttribute, ID2D1Resource
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Returns the element on which this attribute is set. Returns null if the attribute is not set on any element.</summary>
		/// <param name="element">
		/// <para>Type: <b>ID2D1SvgElement**</b></para>
		/// <para>When this method completes, this will contain a pointer to the element on which this attribute is set.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgattribute-getelement void GetElement( [out]
		// ID2D1SvgElement **element );
		[PreserveSig]
		new void GetElement(out ID2D1SvgElement element);

		/// <summary>Creates a clone of this attribute value. On creation, the cloned attribute is not set on any element.</summary>
		/// <returns>
		/// <para>Type: <b>ID2D1SvgAttribute**</b></para>
		/// <para>Specifies the attribute value to clone.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgattribute-clone HRESULT Clone( [out]
		// ID2D1SvgAttribute **attribute );
		new ID2D1SvgAttribute Clone();

		/// <summary>Removes points from the end of the array.</summary>
		/// <param name="pointsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Specifies how many points to remove.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpointcollection-removepointsatend HRESULT
		// RemovePointsAtEnd( UINT32 pointsCount );
		void RemovePointsAtEnd(uint pointsCount);

		/// <summary>
		/// Updates the points array. Existing points not updated by this method are preserved. The array is resized larger if necessary to
		/// accommodate the new points.
		/// </summary>
		/// <param name="points">
		/// <para>Type: <b>const D2D1_POINT_2F*</b></para>
		/// <para>The points array.</para>
		/// </param>
		/// <param name="pointsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of points to update.</para>
		/// </param>
		/// <param name="startIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index at which to begin updating points. Must be less than or equal to the size of the array.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpointcollection-updatepoints HRESULT UpdatePoints(
		// [in] const D2D1_POINT_2F *points, UINT32 pointsCount, UINT32 startIndex );
		void UpdatePoints([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D_POINT_2F[] points, int pointsCount, uint startIndex = 0);

		/// <summary>Gets points from the points array.</summary>
		/// <param name="points">
		/// <para>Type: <b>D2D1_POINT_2F*</b></para>
		/// <para>Buffer to contain the points.</para>
		/// </param>
		/// <param name="pointsCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The element count of the buffer.</para>
		/// </param>
		/// <param name="startIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the first point to retrieve.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpointcollection-getpoints HRESULT GetPoints( [out]
		// D2D1_POINT_2F *points, UINT32 pointsCount, UINT32 startIndex );
		void GetPoints([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D_POINT_2F[] points, int pointsCount, uint startIndex = 0);

		/// <summary>Gets the number of points in the array.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the number of points in the array.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgpointcollection-getpointscount UINT32 GetPointsCount();
		[PreserveSig]
		uint GetPointsCount();
	}

	/// <summary>Interface describing an SVG stroke-dasharray value.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nn-d2d1svg-id2d1svgstrokedasharray
	[PInvokeData("d2d1svg.h", MSDNShortId = "NN:d2d1svg.ID2D1SvgStrokeDashArray")]
	[ComImport, Guid("f1c0ca52-92a3-4f00-b4ce-f35691efd9d9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1SvgStrokeDashArray : ID2D1SvgAttribute, ID2D1Resource
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Returns the element on which this attribute is set. Returns null if the attribute is not set on any element.</summary>
		/// <param name="element">
		/// <para>Type: <b>ID2D1SvgElement**</b></para>
		/// <para>When this method completes, this will contain a pointer to the element on which this attribute is set.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgattribute-getelement void GetElement( [out]
		// ID2D1SvgElement **element );
		[PreserveSig]
		new void GetElement(out ID2D1SvgElement element);

		/// <summary>Creates a clone of this attribute value. On creation, the cloned attribute is not set on any element.</summary>
		/// <returns>
		/// <para>Type: <b>ID2D1SvgAttribute**</b></para>
		/// <para>Specifies the attribute value to clone.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgattribute-clone HRESULT Clone( [out]
		// ID2D1SvgAttribute **attribute );
		new ID2D1SvgAttribute Clone();

		/// <summary>Removes dashes from the end of the array.</summary>
		/// <param name="dashesCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Specifies how many dashes to remove.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgstrokedasharray-removedashesatend HRESULT
		// RemoveDashesAtEnd( UINT32 dashesCount );
		void RemoveDashesAtEnd(uint dashesCount);

		/// <summary>
		/// Updates the array. Existing dashes not updated by this method are preserved. The array is resized larger if necessary to
		/// accommodate the new dashes.
		/// </summary>
		/// <param name="dashes">
		/// <para>Type: <b>const FLOAT*</b></para>
		/// <para>The dashes array.</para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of dashes to update.</para>
		/// </param>
		/// <param name="startIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index at which to begin updating dashes. Must be less than or equal to the size of the array.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgstrokedasharray-updatedashes(constd2d1_svg_length_uint32_uint32)
		// HRESULT UpdateDashes( [in] const D2D1_SVG_LENGTH *dashes, UINT32 dashesCount, UINT32 startIndex );
		void UpdateDashes([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D1_SVG_LENGTH[] dashes, int dashesCount, uint startIndex = 0);

		/// <summary>
		/// Updates the array. Existing dashes not updated by this method are preserved. The array is resized larger if necessary to
		/// accommodate the new dashes.
		/// </summary>
		/// <param name="dashes">
		/// <para>Type: <b>const FLOAT*</b></para>
		/// <para>The dashes array.</para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of dashes to update.</para>
		/// </param>
		/// <param name="startIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index at which to begin updating dashes. Must be less than or equal to the size of the array.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgstrokedasharray-updatedashes(constd2d1_svg_length_uint32_uint32)
		// HRESULT UpdateDashes( [in] const D2D1_SVG_LENGTH *dashes, UINT32 dashesCount, UINT32 startIndex );
		void UpdateDashes([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] dashes, int dashesCount, uint startIndex = 0);

		/// <summary>Gets dashes from the array.</summary>
		/// <param name="dashes">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>Buffer to contain the dashes.</para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The element count of the array in the dashes argument.</para>
		/// </param>
		/// <param name="startIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the first dash to retrieve.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgstrokedasharray-getdashes(float_uint32_uint32)
		// HRESULT GetDashes( [out] FLOAT *dashes, UINT32 dashesCount, UINT32 startIndex );
		void GetDashes([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D1_SVG_LENGTH[] dashes, int dashesCount, uint startIndex = 0);

		/// <summary>Gets dashes from the array.</summary>
		/// <param name="dashes">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>Buffer to contain the dashes.</para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The element count of the array in the dashes argument.</para>
		/// </param>
		/// <param name="startIndex">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The index of the first dash to retrieve.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgstrokedasharray-getdashes(float_uint32_uint32)
		// HRESULT GetDashes( [out] FLOAT *dashes, UINT32 dashesCount, UINT32 startIndex );
		void GetDashes([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] dashes, int dashesCount, uint startIndex = 0);

		/// <summary>Gets the number of the dashes in the array.</summary>
		/// <returns>
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Returns the number of the dashes in the array.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1svg/nf-d2d1svg-id2d1svgstrokedasharray-getdashescount UINT32 GetDashesCount();
		[PreserveSig]
		uint GetDashesCount();
	}

	/// <summary>Gets an attribute of this element as an interface type.</summary>
	/// <typeparam name="T">The type of the requested interface.</typeparam>
	/// <param name="elem">The <see cref="ID2D1SvgElement"/> instance.</param>
	/// <param name="name">The name of the attribute.</param>
	/// <param name="value">The value of the attribute.</param>
	/// <returns>
	/// This method returns an HRESULT success or error code. Returns an error if the attribute name is not valid on this element. Returns
	/// an error if the attribute cannot be expressed as the specified string type. Returns an error if the attribute is not specified.
	/// </returns>
	public static HRESULT GetAttributeValue<T>(this ID2D1SvgElement elem, string name, out T? value) where T : ID2D1SvgAttribute
	{
		var hr = elem.GetAttributeValue(name, typeof(T).GUID, out var obj);
		value = hr.Succeeded ? (T)obj! : default;
		return hr;
	}

	/// <summary>Gets an attribute of this element as an interface type.</summary>
	/// <typeparam name="T">The type of the requested interface.</typeparam>
	/// <param name="elem">The <see cref="ID2D1SvgElement"/> instance.</param>
	/// <param name="name">The name of the attribute.</param>
	/// <param name="value">The value of the attribute.</param>
	/// <param name="type">The POD type of the value. If omitted, the default value will lookup the correct type.</param>
	/// <returns>
	/// This method returns an HRESULT success or error code. Returns an error if the attribute name is not valid on this element. Returns
	/// an error if the attribute cannot be expressed as the specified string type. Returns an error if the attribute is not specified.
	/// </returns>
	public static HRESULT GetAttributeValue<T>(this ID2D1SvgElement elem, string name, out T value,
		D2D1_SVG_ATTRIBUTE_POD_TYPE type = (D2D1_SVG_ATTRIBUTE_POD_TYPE)uint.MaxValue) where T : struct
	{
		value = default;
		if (!type.IsValid() && !CorrespondingTypeAttribute.CanGet<T, D2D1_SVG_ATTRIBUTE_POD_TYPE>(out type))
			return HRESULT.E_INVALIDARG;
		using SafeCoTaskMemStruct<T> val = new();
		var hr = elem.GetAttributeValue(name, type, val, val.Size);
		value = val.Value;
		return hr;
	}

	/// <summary>Gets an attribute of this element as a string.</summary>
	/// <param name="elem">The <see cref="ID2D1SvgElement"/> instance.</param>
	/// <param name="name">The name of the attribute.</param>
	/// <param name="type">The string type.</param>
	/// <param name="value">The value of the attribute.</param>
	/// <returns>
	/// This method returns an HRESULT success or error code. Returns an error if the attribute name is not valid on this element. Returns
	/// an error if the attribute cannot be expressed as the specified string type. Returns an error if the attribute is not specified.
	/// </returns>
	public static HRESULT GetAttributeValue(this ID2D1SvgElement elem, string name, D2D1_SVG_ATTRIBUTE_STRING_TYPE type, out string? value)
	{
		StringBuilder sb = new((int)elem.GetAttributeValueLength(name, type) + 1);
		var hr = elem.GetAttributeValue(name, type, sb, (uint)sb.Capacity);
		value = hr.Succeeded ? sb.ToString() : default;
		return hr;
	}

	/// <summary>Gets points from the points array.</summary>
	/// <param name="coll">The <see cref="ID2D1SvgPointCollection"/> instance.</param>
	/// <param name="startIndex">
	/// <para>Type: <b>UINT32</b></para>
	/// <para>The index of the first point to retrieve.</para>
	/// </param>
	/// <returns>The points.</returns>
	public static D2D_POINT_2F[] GetPoints(this ID2D1SvgPointCollection coll, uint startIndex = 0)
	{
		var pts = new D2D_POINT_2F[coll.GetPointsCount() - startIndex];
		coll.GetPoints(pts, pts.Length, startIndex);
		return pts;
	}

	/// <summary>Gets the tag name.</summary>
	/// <param name="elem">The <see cref="ID2D1SvgElement"/> instance.</param>
	/// <returns>The tag name.</returns>
	public static string GetTagName(this ID2D1SvgElement elem)
	{
		StringBuilder sb = new((int)elem.GetTagNameLength() + 1);
		elem.GetTagName(sb, (uint)sb.Capacity);
		return sb.ToString();
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
}