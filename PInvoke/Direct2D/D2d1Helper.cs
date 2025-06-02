using System.Runtime.CompilerServices;

namespace Vanara.PInvoke;

public static partial class D2d1
{
	/// <summary>Creates a <c>D2D1_ARC_SEGMENT</c> structure.</summary>
	/// <param name="point">
	/// <para>Type: <b>const <c>D2D1_POINT_2F</c></b></para>
	/// <para>The end point of the arc.</para>
	/// </param>
	/// <param name="size">
	/// <para>Type: <b>const <c>D2D1_SIZE_F</c></b></para>
	/// <para>The x-radius and y-radius of the arc.</para>
	/// </param>
	/// <param name="rotationAngle">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>
	/// The number of degrees that the ellipse is rotated relative to the current coordinate system. A positive number specifies a clockwise
	/// rotation and a negative number specifies a counterclockwise rotation.
	/// </para>
	/// </param>
	/// <param name="sweepDirection">
	/// <para>Type: <b><c>D2D1_SWEEP_DIRECTION</c></b></para>
	/// <para>A value that specifies whether the arc sweep is clockwise or counterclockwise.</para>
	/// </param>
	/// <param name="arcSize">
	/// <para>Type: <b><c>D2D1_ARC_SIZE</c></b></para>
	/// <para>A value that specifies whether the arc is larger than 180 degrees.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_ARC_SEGMENT</c></b></para>
	/// <para>The new arc segment.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-arcsegment D2D1_ARC_SEGMENT ArcSegment( [in, ref] const
	// D2D1_POINT_2F &amp; point, [in, ref] const D2D1_SIZE_F &amp; size, [in] FLOAT rotationAngle, [in] D2D1_SWEEP_DIRECTION sweepDirection,
	// [in] D2D1_ARC_SIZE arcSize );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.ArcSegment")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1_ARC_SEGMENT ArcSegment(in D2D_POINT_2F point, in D2D_SIZE_F size, [In] float rotationAngle, [In] D2D1_SWEEP_DIRECTION sweepDirection, [In] D2D1_ARC_SIZE arcSize) => new(point, size, rotationAngle, sweepDirection, arcSize);

	/// <summary>Creates a <c>D2D1_BEZIER_SEGMENT</c> structure.</summary>
	/// <param name="point1">
	/// <para>Type: <b>const <c>D2D1_POINT_2F</c></b></para>
	/// <para>The first control point for the Bezier segment.</para>
	/// </param>
	/// <param name="point2">
	/// <para>Type: <b>const <c>D2D1_POINT_2F</c></b></para>
	/// <para>The second control point for the Bezier segment.</para>
	/// </param>
	/// <param name="point3">
	/// <para>Type: <b>const <c>D2D1_POINT_2F</c></b></para>
	/// <para>The end point for the Bezier segment.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_BEZIER_SEGMENT</c></b></para>
	/// <para>The new Bezier segment.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-beziersegment D2D1_BEZIER_SEGMENT BezierSegment( [in,
	// ref] const D2D1_POINT_2F &amp; point1, [in, ref] const D2D1_POINT_2F &amp; point2, [in, ref] const D2D1_POINT_2F &amp; point3 );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.BezierSegment")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1_BEZIER_SEGMENT BezierSegment(in D2D_POINT_2F point1, in D2D_POINT_2F point2, D2D_POINT_2F point3) => new(point1, point2, point3);

	/// <summary>Creates a <c>D2D1_BITMAP_BRUSH_PROPERTIES</c> structure.</summary>
	/// <param name="extendModeX">
	/// <para>Type: <b><c>D2D1_EXTEND_MODE</c></b></para>
	/// <para>
	/// A value that specifies how the brush horizontally tiles those areas that extend past its bitmap. The default value is
	/// <c>D2D1_EXTEND_MODE CLAMP</c>.
	/// </para>
	/// </param>
	/// <param name="extendModeY">
	/// <para>Type: <b><c>D2D1_EXTEND_MODE</c></b></para>
	/// <para>
	/// A value that specifies how the brush vertically tiles those areas that extend past its bitmap. The default value is
	/// <c>D2D1_EXTEND_MODE CLAMP</c>.
	/// </para>
	/// </param>
	/// <param name="interpolationMode">
	/// <para>Type: <b><c>D2D1_BITMAP_INTERPOLATION_MODE</c></b></para>
	/// <para>A value that specifies the interpolation algorithm that is used when images are scaled or rotated. The default value is <c>D2D1_BITMAP_INTERPOLATION_MODE_LINEAR</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_BITMAP_BRUSH_PROPERTIES</c></b></para>
	/// <para>A structure that describes the extend modes and the interpolation mode of an <c>ID2D1BitmapBrush</c>.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-bitmapbrushproperties D2D1_BITMAP_BRUSH_PROPERTIES
	// BitmapBrushProperties( D2D1_EXTEND_MODE extendModeX, D2D1_EXTEND_MODE extendModeY, D2D1_BITMAP_INTERPOLATION_MODE interpolationMode );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.BitmapBrushProperties")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1_BITMAP_BRUSH_PROPERTIES BitmapBrushProperties(D2D1_EXTEND_MODE extendModeX = D2D1_EXTEND_MODE.D2D1_EXTEND_MODE_CLAMP,
	D2D1_EXTEND_MODE extendModeY = D2D1_EXTEND_MODE.D2D1_EXTEND_MODE_CLAMP,
	D2D1_BITMAP_INTERPOLATION_MODE interpolationMode = D2D1_BITMAP_INTERPOLATION_MODE.D2D1_BITMAP_INTERPOLATION_MODE_LINEAR) =>
		new(extendModeX, extendModeY, interpolationMode);

	/// <summary>Creates a <c>D2D1_BITMAP_PROPERTIES</c> structure.</summary>
	/// <param name="pixelFormat">
	/// <para>Type: <b>const <c>D2D1_PIXEL_FORMAT</c></b></para>
	/// <para>
	/// The bitmap's pixel format and alpha mode. The default value is a <c>D2D1_PIXEL_FORMAT</c> with a <b>format</b> of
	/// <c>DXGI_FORMAT_UNKNOWN</c> and an <b>alphaMode</b> of <c>D2D1_ALPHA_MODE_UNKNOWN</c>. For more information about pixel formats, see
	/// <c>Supported Pixel Formats and Alpha Modes</c>.
	/// </para>
	/// </param>
	/// <param name="dpiX">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>The horizontal dpi of the bitmap. The default value is 96.0f.</para>
	/// </param>
	/// <param name="dpiY">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>The vertical dpi of the bitmap. The default value is 96.0f.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_BITMAP_PROPERTIES</c></b></para>
	/// <para>A structure that describes the pixel format and dpi of a bitmap.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-bitmapproperties D2D1_BITMAP_PROPERTIES BitmapProperties(
	// [ref] const D2D1_PIXEL_FORMAT &amp; pixelFormat, FLOAT dpiX, FLOAT dpiY );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.BitmapProperties")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1_BITMAP_PROPERTIES BitmapProperties(D2D1_PIXEL_FORMAT pixelFormat = default,
	float dpiX = 96.0f, float dpiY = 96.0f) => new(pixelFormat, dpiX, dpiY);

	/// <summary>Creates a <c>D2D1_BRUSH_PROPERTIES</c> structure.</summary>
	/// <param name="opacity">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>The base opacity of the brush. The default value is 1.0.</para>
	/// </param>
	/// <param name="transform">
	/// <para>Type: <b>const <c>D2D1_MATRIX_3X2_F</c></b></para>
	/// <para>The transformation to apply to the brush. The default value is <c>D2D1::IdentityMatrix</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_BRUSH_PROPERTIES</c></b></para>
	/// <para>The new brush properties structure.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-brushproperties D2D1_BRUSH_PROPERTIES BrushProperties(
	// [in] FLOAT opacity, [in, ref] const D2D1_MATRIX_3X2_F &amp; transform );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.BrushProperties")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1_BRUSH_PROPERTIES BrushProperties([In] float opacity = 1f, in D2D_MATRIX_3X2_F? transform = null) =>
			new(opacity, transform);

	/// <summary>Creates a <c>D2D1_DRAWING_STATE_DESCRIPTION</c> structure.</summary>
	/// <param name="antialiasMode">
	/// <para>Type: <b><c>D2D1_ANTIALIAS_MODE</c></b></para>
	/// <para>The antialiasing mode for subsequent non-text drawing operations. The default value is <c>D2D1_ANTIALIAS_MODE_PER_PRIMITIVE</c>.</para>
	/// </param>
	/// <param name="textAntialiasMode">
	/// <para>Type: <b><c>D2D1_TEXT_ANTIALIAS_MODE</c></b></para>
	/// <para>The antialiasing mode for subsequent text and glyph drawing operations. The default value is <c>D2D1_TEXT_ANTIALIAS_MODE_DEFAULT</c>.</para>
	/// </param>
	/// <param name="tag1">
	/// <para>Type: <b><c>D2D1_TAG</c></b></para>
	/// <para>A label for subsequent drawing operations. The default value is 0.</para>
	/// </param>
	/// <param name="tag2">
	/// <para>Type: <b><c>D2D1_TAG</c></b></para>
	/// <para>A label for subsequent drawing operations. The default value is 0.</para>
	/// </param>
	/// <param name="transform">
	/// <para>Type: <b>const <c>D2D1_MATRIX_3X2_F</c></b></para>
	/// <para>
	/// The transformation to be applied to subsequent drawing operations. The default value is provided by the <c>D2D1::IdentityMatrix</c>
	/// function, which returns the identity matrix.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_DRAWING_STATE_DESCRIPTION</c></b></para>
	/// <para>A structure that describes the drawing state of a render target.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-drawingstatedescription D2D1_DRAWING_STATE_DESCRIPTION
	// DrawingStateDescription( D2D1_ANTIALIAS_MODE antialiasMode, D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode, D2D1_TAG tag1, D2D1_TAG tag2,
	// [in, ref] const D2D1_MATRIX_3X2_F &amp; transform );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.DrawingStateDescription")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1_DRAWING_STATE_DESCRIPTION DrawingStateDescription(D2D1_ANTIALIAS_MODE antialiasMode = D2D1_ANTIALIAS_MODE.D2D1_ANTIALIAS_MODE_PER_PRIMITIVE,
		D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode = D2D1_TEXT_ANTIALIAS_MODE.D2D1_TEXT_ANTIALIAS_MODE_DEFAULT, ulong tag1 = 0, ulong tag2 = 0,
		in D2D_MATRIX_3X2_F? transform = null) => new(antialiasMode, textAntialiasMode, tag1, tag2, transform);

	/// <summary>Creates a <c>D2D1_ELLIPSE</c> structure.</summary>
	/// <param name="center">
	/// <para>Type: <b>const <c>D2D1_POINT_2F</c></b></para>
	/// <para>The center point of the ellipse.</para>
	/// </param>
	/// <param name="radiusX">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>The x-radius of the ellipse.</para>
	/// </param>
	/// <param name="radiusY">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>The y-radius of the ellipse.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_ELLIPSE</c></b></para>
	/// <para>The new ellipse.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-ellipse D2D1_ELLIPSE Ellipse( [in, ref] const
	// D2D1_POINT_2F &amp; center, FLOAT radiusX, FLOAT radiusY );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.Ellipse")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1_ELLIPSE Ellipse(in D2D_POINT_2F center, float radiusX, float radiusY) => new(center, radiusX, radiusY);

	/// <summary>Returns the maximum floating-point value.</summary>
	/// <returns>
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>The maximum floating-point value.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-floatmax FLOAT FloatMax();
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.FloatMax")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float FloatMax() => float.MaxValue;

	/// <summary>Creates a <c>D2D1_GRADIENT_STOP</c> structure.</summary>
	/// <param name="position">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>
	/// A value that indicates the relative position of the gradient stop in the brush. A value of 0.0 specifies that the stop is positioned
	/// at the beginning of the gradient vector, while a value of 1.0 specifies that the stop is positioned at the end of the gradient
	/// vector. Stops outside the 0.0-1.0 range might not be directly visible but still influence the gradient pattern.
	/// </para>
	/// </param>
	/// <param name="color">
	/// <para>Type: <b>const <c>D2D1_COLOR_F</c></b></para>
	/// <para>The color of the gradient stop.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_GRADIENT_STOP</c></b></para>
	/// <para>The new gradient stop.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-gradientstop D2D1_GRADIENT_STOP GradientStop( FLOAT
	// position, [in, ref] const D2D1_COLOR_F &amp; color );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.GradientStop")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1_GRADIENT_STOP GradientStop(float position, in D2D1_COLOR_F color) => new(position, color);

	/// <summary>Creates a <c>D2D1_HWND_RENDER_TARGET_PROPERTIES</c> structure.</summary>
	/// <param name="hwnd">
	/// <para>Type: <b>HWND</b></para>
	/// <para>The HWND to which the render target issues the output from its drawing commands.</para>
	/// </param>
	/// <param name="pixelSize">
	/// <para>Type: <b><c>D2D1_SIZE_U</c></b></para>
	/// <para>The size of the render target, in pixels. The default value is a <c>D2D1_SIZE_U</c> that has a width and height of 0.</para>
	/// </param>
	/// <param name="presentOptions">
	/// <para>Type: <b><c>D2D1_PRESENT_OPTIONS</c></b></para>
	/// <para>
	/// A value that specifies whether the render target retains the frame after it is presented and whether the render target waits for the
	/// device to refresh before presenting. The default value is <c>D2D1_PRESENT_OPTIONS_NONE</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_HWND_RENDER_TARGET_PROPERTIES</c></b></para>
	/// <para>A structure that contains the HWND, pixel size, and presentation options for an <c>ID2D1HwndRenderTarget</c>.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-hwndrendertargetproperties
	// D2D1_HWND_RENDER_TARGET_PROPERTIES HwndRenderTargetProperties( [in] HWND hwnd, [in] D2D1_SIZE_U pixelSize, [in] D2D1_PRESENT_OPTIONS
	// presentOptions );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.HwndRenderTargetProperties")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1_HWND_RENDER_TARGET_PROPERTIES HwndRenderTargetProperties([In] HWND hwnd, [In] D2D_SIZE_U pixelSize = default,
	[In] D2D1_PRESENT_OPTIONS presentOptions = D2D1_PRESENT_OPTIONS.D2D1_PRESENT_OPTIONS_NONE) => new(hwnd, pixelSize, presentOptions);

	/// <summary>
	/// Creates a rectangle that has its upper-left corner set to (negative infinity, negative infinity) and its lower-right corner set to
	/// (infinity, infinity).
	/// </summary>
	/// <returns>
	/// <para>Type: <b><c>D2D1_RECT_F</c></b></para>
	/// <para>
	/// A rectangle that has its upper-left corner set to (negative infinity, negative infinity) and its lower-right corner set to (infinity, infinity).
	/// </para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-infiniterect D2D1_RECT_F InfiniteRect();
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.InfiniteRect")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D_RECT_F InfiniteRect() => new(-FloatMax(), -FloatMax(), FloatMax(), FloatMax());

	/// <summary>Creates a <c>D2D1_LAYER_PARAMETERS</c> structure.</summary>
	/// <param name="contentBounds">
	/// <para>Type: <b>const <c>D2D1_RECT_F</c></b></para>
	/// <para>The content bounds of the layer. Content outside these bounds is not guaranteed to render. The default value is <c>D2D1::InfiniteRect</c>.</para>
	/// </param>
	/// <param name="geometricMask">
	/// <para>Type: <b><c>ID2D1Geometry</c>*</b></para>
	/// <para>
	/// A mask that specifies the area of the layer that is composited into the render target, or <b>NULL</b>. The default value is <b>NULL</b>.
	/// </para>
	/// </param>
	/// <param name="maskAntialiasMode">
	/// <para>Type: <b><c>D2D1_ANTIALIAS_MODE</c></b></para>
	/// <para>A value that specifies the antialiasing mode for the geometric mask. The default value is <c>D2D1_ANTIALIAS_MODE_PER_PRIMITIVE</c>.</para>
	/// </param>
	/// <param name="maskTransform">
	/// <para>Type: <b><c>D2D1_MATRIX_3X2_F</c></b></para>
	/// <para>A value that specifies the transform that is applied to the geometric mask when composing the layer. The default value is <c>D2D1::IdentityMatrix</c>.</para>
	/// </param>
	/// <param name="opacity">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>An opacity that is applied uniformly to all resources in the layer when compositing to the target. The default value is 1.0.</para>
	/// </param>
	/// <param name="opacityBrush">
	/// <para>Type: <b><c>ID2D1Brush</c>*</b></para>
	/// <para>
	/// A brush that is used to alter the opacity of the layer. The brush is mapped to the layer, and the alpha channel of each mapped brush
	/// pixel is multiplied by the corresponding layer pixel. The default value is <b>NULL</b>.
	/// </para>
	/// </param>
	/// <param name="layerOptions">
	/// <para>Type: <b><c>D2D1_LAYER_OPTIONS</c></b></para>
	/// <para>A value that specifies whether the layer intends to render text with ClearType antialiasing. The default value is <c>D2D1_LAYER_OPTIONS_NONE</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_LAYER_PARAMETERS</c></b></para>
	/// <para>A structure that contains the content bounds, mask information, opacity settings, and other options for a layer resource.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-layerparameters D2D1_LAYER_PARAMETERS LayerParameters(
	// [in, ref] const D2D1_RECT_F &amp; contentBounds, [in, optional] ID2D1Geometry *geometricMask, D2D1_ANTIALIAS_MODE maskAntialiasMode,
	// D2D1_MATRIX_3X2_F maskTransform, FLOAT opacity, ID2D1Brush *opacityBrush, D2D1_LAYER_OPTIONS layerOptions );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.LayerParameters")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1_LAYER_PARAMETERS LayerParameters(in D2D_RECT_F? contentBounds = null, ID2D1Geometry? geometricMask = default,
		D2D1_ANTIALIAS_MODE maskAntialiasMode = D2D1_ANTIALIAS_MODE.D2D1_ANTIALIAS_MODE_PER_PRIMITIVE,
		in D2D_MATRIX_3X2_F? maskTransform = null, float opacity = 1.0f, ID2D1Brush? opacityBrush = default,
		D2D1_LAYER_OPTIONS layerOptions = D2D1_LAYER_OPTIONS.D2D1_LAYER_OPTIONS_NONE) =>
		new(contentBounds, geometricMask, maskAntialiasMode, maskTransform, opacity, opacityBrush, layerOptions);

	/// <summary>Creates a <c>D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES</c> structure.</summary>
	/// <param name="startPoint">
	/// <para>Type: <b>const <c>D2D1_POINT_2F</c></b></para>
	/// <para>The start point, in the brush's coordinate space, of the gradient axis.</para>
	/// </param>
	/// <param name="endPoint">
	/// <para>Type: <b>const <c>D2D1_POINT_2F</c></b></para>
	/// <para>The end point, in the brush's coordinate space, of the gradient axis.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES</c></b></para>
	/// <para>A structure that contains the start and end point of the gradient axis for an <c>ID2D1LinearGradientBrush</c>.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-lineargradientbrushproperties
	// D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES LinearGradientBrushProperties( [in, ref] const D2D1_POINT_2F &amp; startPoint, [in, ref] const
	// D2D1_POINT_2F &amp; endPoint );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.LinearGradientBrushProperties")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES LinearGradientBrushProperties(in D2D_POINT_2F startPoint, in D2D_POINT_2F endPoint) => new(startPoint, endPoint);

	/// <summary>Creates a <c>D2D1_PIXEL_FORMAT</c> structure.</summary>
	/// <param name="dxgiFormat">
	/// <para>Type: <b><c>DXGI_FORMAT</c></b></para>
	/// <para>A value that specifies the size and arrangement of channels in each pixel. The default value is <c>DXGI_FORMAT_UNKNOWN</c>.</para>
	/// </param>
	/// <param name="alphaMode">
	/// <para>Type: <b><c>ALPHA_MODE</c></b></para>
	/// <para>
	/// A value that specifies whether the alpha channel is using premultiplied alpha or straight alpha, or whether it should be ignored and
	/// considered opaque. The default value is <c>D2D1_ALPHA_MODE_UNKNOWN</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_PIXEL_FORMAT</c></b></para>
	/// <para>A structure that contains the data format and alpha mode for a bitmap or render target.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-pixelformat D2D1_PIXEL_FORMAT PixelFormat( [in]
	// DXGI_FORMAT dxgiFormat, [in] D2D1_ALPHA_MODE alphaMode );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.PixelFormat")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1_PIXEL_FORMAT PixelFormat([In] DXGI_FORMAT dxgiFormat = DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,
	[In] D2D1_ALPHA_MODE alphaMode = D2D1_ALPHA_MODE.D2D1_ALPHA_MODE_UNKNOWN) =>
		new D2D1_PIXEL_FORMAT(dxgiFormat, alphaMode);

	/// <summary>Creates a <c>D2D1_POINT_2F</c> structure that contains the specified x-coordinates and y-coordinates.</summary>
	/// <param name="x">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>The x-coordinate of the point. The default value is 0.f.</para>
	/// </param>
	/// <param name="y">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>The y-coordinate of the point. The default value is 0.f.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
	/// <para>The new point.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-point2f D2D1_POINT_2F Point2F( FLOAT x, FLOAT y );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.Point2F")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D_POINT_2F Point2F(float x = 0f, float y = 0f) => new(x, y);

	/// <summary>Creates a <c>D2D1_POINT_2U</c> structure that contains the specified x-coordinates and y-coordinates.</summary>
	/// <param name="x">
	/// <para>Type: <b>UINT32</b></para>
	/// <para>The x-coordinate of the point. The default value is 0.</para>
	/// </param>
	/// <param name="y">
	/// <para>Type: <b>UINT32</b></para>
	/// <para>The y-coordinate of the point. The default value is 0.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_POINT_2U</c></b></para>
	/// <para>The new point.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-point2u D2D1_POINT_2U Point2U( UINT32 x, UINT32 y );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.Point2U")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D_POINT_2U Point2U(uint x, uint y) => new(x, y);

	/// <summary>Creates a <c>D2D1_QUADRATIC_BEZIER_SEGMENT</c> structure.</summary>
	/// <param name="point1">
	/// <para>Type: <b>const <c>D2D1_POINT_2F</c></b></para>
	/// <para>The control point of the quadratic Bezier segment.</para>
	/// </param>
	/// <param name="point2">
	/// <para>Type: <b>const <c>D2D1_POINT_2F</c></b></para>
	/// <para>The end point of the quadratic Bezier segment.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_QUADRATIC_BEZIER_SEGMENT</c></b></para>
	/// <para>The new quadratic Bezier curve segment.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-quadraticbeziersegment D2D1_QUADRATIC_BEZIER_SEGMENT
	// QuadraticBezierSegment( [in, ref] const D2D1_POINT_2F &amp; point1, [in, ref] const D2D1_POINT_2F &amp; point2 );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.QuadraticBezierSegment")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1_QUADRATIC_BEZIER_SEGMENT QuadraticBezierSegment(in D2D_POINT_2F point1, in D2D_POINT_2F point2) => new(point1, point2);

	/// <summary>Creates a <c>D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES</c> structure.</summary>
	/// <param name="center">
	/// <para>Type: <b>const <c>D2D1_POINT_2F</c></b></para>
	/// <para>In the brush's coordinate space, the center of the gradient ellipse.</para>
	/// </param>
	/// <param name="gradientOriginOffset">
	/// <para>Type: <b>const <c>D2D1_POINT_2F</c></b></para>
	/// <para>In the brush's coordinate space, the offset of the gradient origin relative to the gradient ellipse's center.</para>
	/// </param>
	/// <param name="radiusX">
	/// <para>Type: <b>const FLOAT</b></para>
	/// <para>In the brush's coordinate space, the x-radius of the gradient ellipse.</para>
	/// </param>
	/// <param name="radiusY">
	/// <para>Type: <b>const FLOAT</b></para>
	/// <para>In the brush's coordinate space, the y-radius of the gradient ellipse.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES</c></b></para>
	/// <para>A structure that contains the gradient origin offset and the size and position of the gradient ellipse for an <c>ID2D1RadialGradientBrush</c>.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-radialgradientbrushproperties
	// D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES RadialGradientBrushProperties( [in, ref] const D2D1_POINT_2F &amp; center, [in, ref] const
	// D2D1_POINT_2F &amp; gradientOriginOffset, [in] FLOAT radiusX, [in] FLOAT radiusY );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.RadialGradientBrushProperties")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES RadialGradientBrushProperties(in D2D_POINT_2F center, in D2D_POINT_2F gradientOriginOffset, float radiusX, float radiusY) =>
		new(center, gradientOriginOffset, radiusX, radiusY);

	/// <summary>
	/// Creates a <c>RectF</c> object and initializes the <b>X</b>, <b>Y</b>, <b>Width</b>, and <b>Height</b> data members to zero. This is
	/// the default constructor.
	/// </summary>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/gdiplustypes/nf-gdiplustypes-rectf-rectf void RectF();
	[PInvokeData("gdiplustypes.h", MSDNShortId = "NF:gdiplustypes.RectF.RectF")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D_RECT_F RectF(float left = 0f, float top = 0f, float right = 0f, float bottom = 0f) => new(left, top, right, bottom);

	/// <summary>Creates a <c>D2D1_RECT_U</c> structure that contains the specified dimensions.</summary>
	/// <param name="left">
	/// <para>Type: <b>UINT32</b></para>
	/// <para>The x-coordinate of the upper-left corner of the rectangle. The default value is 0.</para>
	/// </param>
	/// <param name="top">
	/// <para>Type: <b>UINT32</b></para>
	/// <para>The y-coordinate of the upper-left corner of the rectangle. The default value is 0.</para>
	/// </param>
	/// <param name="right">
	/// <para>Type: <b>UINT32</b></para>
	/// <para>The x-coordinate of the lower-right corner of the rectangle. The default value is 0.</para>
	/// </param>
	/// <param name="bottom">
	/// <para>Type: <b>UINT32</b></para>
	/// <para>The y-coordinate of the lower-right corner of the rectangle. The default value is 0.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_RECT_U</c></b></para>
	/// <para>A rectangle structure that contains the specified dimensions.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-rectu D2D1_RECT_U RectU( UINT32 left, UINT32 top, UINT32
	// right, UINT32 bottom );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.RectU")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D_RECT_U RectU(uint left, uint top, uint right, uint bottom) => new(left, top, right, bottom);

	/// <summary>Creates a <c>D2D1_RENDER_TARGET_PROPERTIES</c> structure.</summary>
	/// <param name="type">
	/// <para>Type: <b><c>D2D1_RENDER_TARGET_TYPE</c></b></para>
	/// <para>
	/// A value that specifies whether the render target must use hardware rendering or software rendering. The default value,
	/// <c>D2D1_RENDER_TARGET_TYPE_DEFAULT</c>, specifies that hardware rendering be used; if hardware rendering is not available, the render
	/// target uses software rendering. Note that WIC bitmap render targets do not support hardware rendering.
	/// </para>
	/// </param>
	/// <param name="pixelFormat">
	/// <para>Type: <b>const <c>D2D1_PIXEL_FORMAT</c></b></para>
	/// <para>
	/// The pixel format and alpha mode of the render target. The default pixel format is <c>D2D1::PixelFormat</c>, which tells Direct2D to
	/// select a pixel format that is supported by the render target. For a list of pixel formats and alpha modes supported by each render
	/// target, see <c>Supported Pixel Formats and Alpha Modes</c>.
	/// </para>
	/// </param>
	/// <param name="dpiX">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>
	/// The horizontal DPI of the render target. The default value is 0.0. If both <i>dpiX</i> and <i>dpiY</i> are set to 0.0, the render
	/// target uses its default DPI. For more information, see <c>D2D1_RENDER_TARGET_PROPERTIES</c>.
	/// </para>
	/// </param>
	/// <param name="dpiY">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>
	/// The vertical DPI of the render target. The default value is 0.0. If both <i>dpiX</i> and <i>dpiY</i> are set to 0.0, the render
	/// target uses its default DPI. For more information, see <c>D2D1_RENDER_TARGET_PROPERTIES</c>.
	/// </para>
	/// </param>
	/// <param name="usage">
	/// <para>Type: <b><c>D2D1_RENDER_TARGET_USAGE</c></b></para>
	/// <para>
	/// Specifies how the render target is remotely rendered and whether it should be GDI-compatible. The default value,
	/// <c>D2D1_RENDER_TARGET_USAGE_NONE</c>, creates a render target that is not compatible with GDI and that uses Direct3D command-stream
	/// remote rendering, if it is available.
	/// </para>
	/// </param>
	/// <param name="minLevel">
	/// <para>Type: <b><c>D2D1_FEATURE_LEVEL</c></b></para>
	/// <para>
	/// The minimum Direct3D feature level that is required for hardware rendering. The default value, <c>D2D1_FEATURE_LEVEL_DEFAULT</c>,
	/// indicates that Direct2D should determine whether the Direct3D feature level of the device is adequate. This field is used only when
	/// <c>ID2D1HwndRenderTarget</c> and <c>ID2D1DCRenderTarget</c> objects are created. For more information, see <c>D2D1_RENDER_TARGET_PROPERTIES</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_RENDER_TARGET_PROPERTIES</c></b></para>
	/// <para>A <c>D2D1_RENDER_TARGET_PROPERTIES</c> that contains the specified settings.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-rendertargetproperties D2D1_RENDER_TARGET_PROPERTIES
	// RenderTargetProperties( D2D1_RENDER_TARGET_TYPE type, [in] const D2D1_PIXEL_FORMAT &amp; pixelFormat, FLOAT dpiX, FLOAT dpiY,
	// D2D1_RENDER_TARGET_USAGE usage, D2D1_FEATURE_LEVEL minLevel );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.RenderTargetProperties")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1_RENDER_TARGET_PROPERTIES RenderTargetProperties(D2D1_RENDER_TARGET_TYPE type = D2D1_RENDER_TARGET_TYPE.D2D1_RENDER_TARGET_TYPE_DEFAULT,
	in D2D1_PIXEL_FORMAT pixelFormat = default, float dpiX = 0, float dpiY = 0, D2D1_RENDER_TARGET_USAGE usage = D2D1_RENDER_TARGET_USAGE.D2D1_RENDER_TARGET_USAGE_NONE,
	D2D1_FEATURE_LEVEL minLevel = D2D1_FEATURE_LEVEL.D2D1_FEATURE_LEVEL_DEFAULT) => new(type, pixelFormat, dpiX, dpiY, usage, minLevel);

	/// <summary>Creates a <c>D2D1_ROUNDED_RECT</c> structure.</summary>
	/// <param name="rect">
	/// <para>Type: <b>const <c>D2D1_RECT_F</c></b></para>
	/// <para>The size and position of the rectangle.</para>
	/// </param>
	/// <param name="radiusX">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>The x-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.</para>
	/// </param>
	/// <param name="radiusY">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>The y-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_ROUNDED_RECT</c></b></para>
	/// <para>The new rounded rectangle.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-roundedrect D2D1_ROUNDED_RECT RoundedRect( [in, ref]
	// const D2D1_RECT_F &amp; rect, FLOAT radiusX, FLOAT radiusY );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.RoundedRect")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1_ROUNDED_RECT RoundedRect(in D2D_RECT_F rect, float radiusX, float radiusY) => new(rect, radiusX, radiusY);

	/// <summary>Creates a <c>D2D1_SIZE_F</c> structure that contains the specified width and height.</summary>
	/// <param name="width">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>The width of the size. The default value is 0.f.</para>
	/// </param>
	/// <param name="height">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>The height of the size. The default value is 0.f.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_SIZE_F</c></b></para>
	/// <para>The new size structure.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-sizef D2D1_SIZE_F SizeF( FLOAT width, FLOAT height );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.SizeF")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D_SIZE_F SizeF(float width = 0f, float height = 0f) => new(width, height);

	/// <summary>Creates a <c>D2D1_SIZE_U</c> structure that contains the specified width and height.</summary>
	/// <param name="width">
	/// <para>Type: <b>UINT32</b></para>
	/// <para>The width of the size. The default value is 0.</para>
	/// </param>
	/// <param name="height">
	/// <para>Type: <b>UINT32</b></para>
	/// <para>The height of the size. The default value is 0.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_SIZE_U</c></b></para>
	/// <para>The new size structure.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-sizeu D2D1_SIZE_U SizeU( UINT32 width, UINT32 height );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.SizeU")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D_SIZE_U SizeU(uint width, uint height) => new(width, height);

	/// <summary>Creates a <c>D2D1_STROKE_STYLE_PROPERTIES</c> structure.</summary>
	/// <param name="startCap">
	/// <para>Type: <b><c>D2D1_CAP_STYLE</c></b></para>
	/// <para>The shape at the beginning of a stroke. The default value is <c>D2D1_CAP_STYLE_FLAT</c>.</para>
	/// </param>
	/// <param name="endCap">
	/// <para>Type: <b><c>D2D1_CAP_STYLE</c></b></para>
	/// <para>The shape at the end of a stroke. The default value is <c>D2D1_CAP_STYLE_FLAT</c>.</para>
	/// </param>
	/// <param name="dashCap">
	/// <para>Type: <b><c>D2D1_CAP_STYLE</c></b></para>
	/// <para>The shape at either end of each dash segment. The default value is <c>D2D1_CAP_STYLE_FLAT</c>.</para>
	/// </param>
	/// <param name="lineJoin">
	/// <para>Type: <b><c>D2D1_LINE_JOIN</c></b></para>
	/// <para>A value that describes how segments are joined. The default value is <c>D2D1_LINE_JOIN_MITER</c>.</para>
	/// </param>
	/// <param name="miterLimit">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>
	/// The limit of the thickness of the join on a mitered corner. This value is always treated as though it is greater than or equal to 1.0f.
	/// </para>
	/// <para>The default value is 10.0f.</para>
	/// </param>
	/// <param name="dashStyle">
	/// <para>Type: <b><c>D2D1_DASH_STYLE</c></b></para>
	/// <para>A value that specifies whether the stroke has a dash pattern and, if so, the dash style.</para>
	/// <para>The default value is <c>D2D1_DASH_STYLE_SOLID</c>.</para>
	/// </param>
	/// <param name="dashOffset">
	/// <para>Type: <b>FLOAT</b></para>
	/// <para>A value that specifies how far in the dash sequence the stroke will start.</para>
	/// <para>The default value is 0.0f.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>D2D1_STROKE_STYLE_PROPERTIES</c></b></para>
	/// <para>The new stroke style.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1helper/nf-d2d1helper-strokestyleproperties D2D1_STROKE_STYLE_PROPERTIES
	// StrokeStyleProperties( D2D1_CAP_STYLE startCap, D2D1_CAP_STYLE endCap, D2D1_CAP_STYLE dashCap, D2D1_LINE_JOIN lineJoin, FLOAT
	// miterLimit, D2D1_DASH_STYLE dashStyle, FLOAT dashOffset );
	[PInvokeData("d2d1helper.h", MSDNShortId = "NF:d2d1helper.StrokeStyleProperties")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static D2D1_STROKE_STYLE_PROPERTIES StrokeStyleProperties(D2D1_CAP_STYLE startCap = D2D1_CAP_STYLE.D2D1_CAP_STYLE_FLAT,
	D2D1_CAP_STYLE endCap = D2D1_CAP_STYLE.D2D1_CAP_STYLE_FLAT, D2D1_CAP_STYLE dashCap = D2D1_CAP_STYLE.D2D1_CAP_STYLE_FLAT,
	D2D1_LINE_JOIN lineJoin = D2D1_LINE_JOIN.D2D1_LINE_JOIN_MITER, float miterLimit = 10.0f,
	D2D1_DASH_STYLE dashStyle = D2D1_DASH_STYLE.D2D1_DASH_STYLE_SOLID, float dashOffset = 0f) =>
			new(startCap, endCap, dashCap, lineJoin, miterLimit, dashStyle, dashOffset);
}