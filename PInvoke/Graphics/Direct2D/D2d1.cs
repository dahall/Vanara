using static Vanara.PInvoke.DXGI;

namespace Vanara.PInvoke;

// TODO: Move once D2d1 lib is done
/// <summary>Items from the D2d1.dll</summary>
public static partial class D2d1
{
	/// <summary>Specifies how the alpha value of a bitmap or render target should be treated.</summary>
	/// <remarks>
	/// <para>
	/// The <c>D2D1_ALPHA_MODE</c> enumeration is used with the D2D1_PIXEL_FORMAT enumeration to specify the alpha mode of a render
	/// target or bitmap. Different render targets and bitmaps support different alpha modes. For a list, see Supported Pixel Formats
	/// and Alpha Modes.
	/// </para>
	/// <para>The Differences Between Straight and Premultiplied Alpha</para>
	/// <para>
	/// When describing an RGBA color using straight alpha, the alpha value of the color is stored in the alpha channel. For example, to
	/// describe a red color that is 60% opaque, you'd use the following values: (255, 0, 0, 255 * 0.6) = (255, 0, 0, 153). The 255
	/// value indicates full red, and 153 (which is 60 percent of 255) indicates that the color should have an opacity of 60 percent.
	/// </para>
	/// <para>
	/// When describing an RGBA color using premultiplied alpha, each color is multiplied by the alpha value: (255 * 0.6, 0 * 0.6, 0 *
	/// 0.6, 255 * 0.6) = (153, 0, 0, 153).
	/// </para>
	/// <para>
	/// Regardless of the alpha mode of the render target, D2D1_COLOR_F values are always interpreted as straight alpha. For example,
	/// when specifying the color of an ID2D1SolidColorBrush for use with a bitmap that uses the premultiplied alpha mode, you'd specify
	/// the color just as you would if the bitmap used straight alpha. When you paint with the brush, Direct2D translates the color to
	/// the destination format for you.
	/// </para>
	/// <para>Alpha Mode for Render Targets</para>
	/// <para>
	/// Regardless of the alpha mode setting, a render target's contents support transparency. For example, if you draw a partially
	/// transparent red rectangle with a render target with an alpha mode of <c>D2D1_ALPHA_MODE_IGNORE</c>, the rectangle will appear
	/// pink (if the background is white), as you might expect.
	/// </para>
	/// <para>
	/// If you draw a partially transparent red rectangle when the alpha mode is CreateCompatibleRenderTarget method) to create a bitmap
	/// that supports transparency.
	/// </para>
	/// <para>ClearType and Alpha Modes</para>
	/// <para>
	/// If you specify an alpha mode other than <c>D2D1_ALPHA_MODE_IGNORE</c> for a render target, the text antialiasing mode
	/// automatically changes from D2D1_TEXT_ANTIALIAS_MODE CLEARTYPE to <c>D2D1_TEXT_ANTIALIAS_MODE GRAYSCALE</c>. (When you specify an
	/// alpha mode of <c>D2D1_ALPHA_MODE_UNKNOWN</c>, Direct2D sets the alpha for you depending on the type of render target. For a list
	/// of what the <c>D2D1_ALPHA_MODE_UNKNOWN</c> setting resolves to for each render target, see the Supported Pixel Formats and Alpha
	/// Modes overview.)
	/// </para>
	/// <para>
	/// You can use the SetTextAntialiasMode method to change the text antialias mode back to D2D1_TEXT_ANTIALIAS_MODE CLEARTYPE, but
	/// rendering ClearType text to a transparent surface can create unpredictable results. If you want to render ClearType text to an
	/// transparent render target, we recommend that you use one of the following two techniques.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Use the PushAxisAlignedClip method to clip the render target to the area where the text will be rendered, then call the Clear
	/// method and specify an opaque color, then render your text.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Use DrawRectangle to draw an opaque rectangle behind the area where the text will be rendered.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ne-dcommon-d2d1_alpha_mode typedef enum D2D1_ALPHA_MODE {
	// D2D1_ALPHA_MODE_UNKNOWN, D2D1_ALPHA_MODE_PREMULTIPLIED, D2D1_ALPHA_MODE_STRAIGHT, D2D1_ALPHA_MODE_IGNORE,
	// D2D1_ALPHA_MODE_FORCE_DWORD } ;
	[PInvokeData("dcommon.h", MSDNShortId = "f1b1e735-2e89-4dc1-9fee-dfb4626ef453")]
	public enum D2D1_ALPHA_MODE : uint
	{
		/// <summary>The alpha value might not be meaningful.</summary>
		D2D1_ALPHA_MODE_UNKNOWN,

		/// <summary>
		/// The alpha value has been premultiplied. Each color is first scaled by the alpha value. The alpha value itself is the same in
		/// both straight and premultiplied alpha. Typically, no color channel value is greater than the alpha channel value. If a color
		/// channel value in a premultiplied format is greater than the alpha channel, the standard source-over blending math results in
		/// an additive blend.
		/// </summary>
		D2D1_ALPHA_MODE_PREMULTIPLIED,

		/// <summary>The alpha value has not been premultiplied. The alpha channel indicates the transparency of the color.</summary>
		D2D1_ALPHA_MODE_STRAIGHT,

		/// <summary>The alpha value is ignored.</summary>
		D2D1_ALPHA_MODE_IGNORE,

		/// <summary/>
		D2D1_ALPHA_MODE_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Specifies how the edges of nontext primitives are rendered.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_antialias_mode typedef enum D2D1_ANTIALIAS_MODE {
	// D2D1_ANTIALIAS_MODE_PER_PRIMITIVE, D2D1_ANTIALIAS_MODE_ALIASED, D2D1_ANTIALIAS_MODE_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "3ca12155-6dd0-41bb-8778-3387422c4ffe")]
	public enum D2D1_ANTIALIAS_MODE : uint
	{
		/// <summary>Edges are antialiased using the Direct2D per-primitive method of high-quality antialiasing.</summary>
		D2D1_ANTIALIAS_MODE_PER_PRIMITIVE,

		/// <summary>
		/// Objects are aliased in most cases. Objects are antialiased only when they are drawn to a render target created by the
		/// CreateDxgiSurfaceRenderTarget method and Direct3D multisampling has been enabled on the backing DirectX Graphics
		/// Infrastructure (DXGI) surface.
		/// </summary>
		D2D1_ANTIALIAS_MODE_ALIASED,

		/// <summary/>
		D2D1_ANTIALIAS_MODE_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Specifies whether an arc should be greater than 180 degrees.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_arc_size typedef enum D2D1_ARC_SIZE { D2D1_ARC_SIZE_SMALL,
	// D2D1_ARC_SIZE_LARGE, D2D1_ARC_SIZE_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "c471716d-c2cc-4f79-8011-46690812b848")]
	public enum D2D1_ARC_SIZE : uint
	{
		/// <summary>An arc's sweep should be 180 degrees or less.</summary>
		D2D1_ARC_SIZE_SMALL = 0,

		/// <summary>An arc's sweep should be 180 degrees or greater.</summary>
		D2D1_ARC_SIZE_LARGE = 1,

		/// <summary/>
		D2D1_ARC_SIZE_FORCE_DWORD = 0xffffffff
	}

	/// <summary>
	/// <para>Specifies the algorithm that is used when images are scaled or rotated.</para>
	/// <para><c>Note</c> Starting in Windows 8, more interpolations modes are available. See D2D1_INTERPOLATION_MODE for more info.</para>
	/// </summary>
	/// <remarks>
	/// To stretch an image, each pixel in the original image must be mapped to a group of pixels in the larger image. To shrink an
	/// image, groups of pixels in the original image must be mapped to single pixels in the smaller image. The effectiveness of the
	/// algorithms that perform these mappings determines the quality of a scaled image. Algorithms that produce higher-quality scaled
	/// images tend to require more processing time. <c>D2D1_BITMAP_INTERPOLATION_MODE_NEAREST_NEIGHBOR</c> provides faster but
	/// lower-quality interpolation, while <c>D2D1_BITMAP_INTERPOLATION_MODE_LINEAR</c> provides higher-quality interpolation.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_bitmap_interpolation_mode typedef enum
	// D2D1_BITMAP_INTERPOLATION_MODE { D2D1_BITMAP_INTERPOLATION_MODE_NEAREST_NEIGHBOR, D2D1_BITMAP_INTERPOLATION_MODE_LINEAR,
	// D2D1_BITMAP_INTERPOLATION_MODE_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "b53b7e0a-aa8b-4788-896c-9825c9e6cceb")]
	public enum D2D1_BITMAP_INTERPOLATION_MODE : uint
	{
		/// <summary>Use the exact color of the nearest bitmap pixel to the current rendering pixel.</summary>
		D2D1_BITMAP_INTERPOLATION_MODE_NEAREST_NEIGHBOR,

		/// <summary>Interpolate a color from the four bitmap pixels that are the nearest to the rendering pixel.</summary>
		D2D1_BITMAP_INTERPOLATION_MODE_LINEAR,

		/// <summary/>
		D2D1_BITMAP_INTERPOLATION_MODE_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Describes the shape at the end of a line or segment.</summary>
	/// <remarks>
	/// The following illustration shows the available cap styles for lines or segments. The red portion of the line shows the extra
	/// area added by the line cap setting.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_cap_style typedef enum D2D1_CAP_STYLE { D2D1_CAP_STYLE_FLAT,
	// D2D1_CAP_STYLE_SQUARE, D2D1_CAP_STYLE_ROUND, D2D1_CAP_STYLE_TRIANGLE, D2D1_CAP_STYLE_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "acf4365e-b9df-459e-a746-016339cd09ac")]
	public enum D2D1_CAP_STYLE : uint
	{
		/// <summary>A cap that does not extend past the last point of the line. Comparable to cap used for objects other than lines.</summary>
		D2D1_CAP_STYLE_FLAT,

		/// <summary>Half of a square that has a length equal to the line thickness.</summary>
		D2D1_CAP_STYLE_SQUARE,

		/// <summary>A semicircle that has a diameter equal to the line thickness.</summary>
		D2D1_CAP_STYLE_ROUND,

		/// <summary>An isosceles right triangle whose hypotenuse is equal in length to the thickness of the line.</summary>
		D2D1_CAP_STYLE_TRIANGLE,

		/// <summary/>
		D2D1_CAP_STYLE_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Defines options that should be applied to the color space.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_color_space typedef enum D2D1_COLOR_SPACE {
	// D2D1_COLOR_SPACE_CUSTOM, D2D1_COLOR_SPACE_SRGB, D2D1_COLOR_SPACE_SCRGB, D2D1_COLOR_SPACE_FORCE_DWORD } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "2c90978b-8a5a-4e5d-9ced-e0ec917271ff")]
	public enum D2D1_COLOR_SPACE : uint
	{
		/// <summary>The color space is otherwise described, such as with a color profile.</summary>
		D2D1_COLOR_SPACE_CUSTOM,

		/// <summary>The color space is sRGB.</summary>
		D2D1_COLOR_SPACE_SRGB,

		/// <summary>The color space is scRGB.</summary>
		D2D1_COLOR_SPACE_SCRGB,

		/// <summary/>
		D2D1_COLOR_SPACE_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Specifies the different methods by which two geometries can be combined.</summary>
	/// <remarks>The following illustration shows the different geometry combine modes.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_combine_mode typedef enum D2D1_COMBINE_MODE {
	// D2D1_COMBINE_MODE_UNION, D2D1_COMBINE_MODE_INTERSECT, D2D1_COMBINE_MODE_XOR, D2D1_COMBINE_MODE_EXCLUDE,
	// D2D1_COMBINE_MODE_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "7526379a-5f57-4a9f-b85d-415f131528e2")]
	public enum D2D1_COMBINE_MODE : uint
	{
		/// <summary>
		/// The two regions are combined by taking the union of both. Given two geometries, A and B, the resulting geometry is geometry
		/// A + geometry B.
		/// </summary>
		D2D1_COMBINE_MODE_UNION = 0,

		/// <summary>
		/// The two regions are combined by taking their intersection. The new area consists of the overlapping region between the two geometries.
		/// </summary>
		D2D1_COMBINE_MODE_INTERSECT,

		/// <summary>
		/// The two regions are combined by taking the area that exists in the first region but not the second and the area that exists
		/// in the second region but not the first. Given two geometries, A and B, the new region consists of (A-B) + (B-A).
		/// </summary>
		D2D1_COMBINE_MODE_XOR,

		/// <summary>
		/// The second region is excluded from the first. Given two geometries, A and B, the area of geometry B is removed from the area
		/// of geometry A, producing a region that is A-B.
		/// </summary>
		D2D1_COMBINE_MODE_EXCLUDE,

		/// <summary/>
		D2D1_COMBINE_MODE_FORCE_DWORD = 0xffffffff
	}

	/// <summary>
	/// Specifies additional features supportable by a compatible render target when it is created. This enumeration allows a bitwise
	/// combination of its member values.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Use this enumeration when creating a compatible render target with the CreateCompatibleRenderTarget method. For more information
	/// about compatible render targets, see the Render Targets Overview.
	/// </para>
	/// <para>
	/// The <c>D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS_GDI_COMPATIBLE</c> option may only be requested if the parent render target was
	/// created with D2D1_RENDER_TARGET_USAGE_GDI_COMPATIBLE (for most render targets) or
	/// <c>D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS_GDI_COMPATIBLE</c> (for render targets created by the CreateCompatibleRenderTarget method).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_compatible_render_target_options typedef enum
	// D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS { D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS_NONE,
	// D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS_GDI_COMPATIBLE, D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "c20bf016-2304-4bd3-88ad-42d81e69c302")]
	[Flags]
	public enum D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS : uint
	{
		/// <summary>The render target supports no additional features.</summary>
		D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS_NONE = 0x00000000,

		/// <summary>The render target supports interoperability with the Windows Graphics Device Interface (GDI).</summary>
		D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS_GDI_COMPATIBLE = 0x00000001,

		/// <summary/>
		D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Describes the sequence of dashes and gaps in a stroke.</summary>
	/// <remarks>The following illustration shows several available dash styles.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_dash_style typedef enum D2D1_DASH_STYLE {
	// D2D1_DASH_STYLE_SOLID, D2D1_DASH_STYLE_DASH, D2D1_DASH_STYLE_DOT, D2D1_DASH_STYLE_DASH_DOT, D2D1_DASH_STYLE_DASH_DOT_DOT,
	// D2D1_DASH_STYLE_CUSTOM, D2D1_DASH_STYLE_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "0c1807e3-51e6-440a-bd80-9b43ed7a39f5")]
	public enum D2D1_DASH_STYLE : uint
	{
		/// <summary>A solid line with no breaks.</summary>
		D2D1_DASH_STYLE_SOLID,

		/// <summary>
		/// A dash followed by a gap of equal length. The dash and the gap are each twice as long as the stroke thickness.The equivalent
		/// dash array for D2D1_DASH_STYLE_DASH is {2, 2}.
		/// </summary>
		D2D1_DASH_STYLE_DASH,

		/// <summary>A dot followed by a longer gap.The equivalent dash array for D2D1_DASH_STYLE_DOT is {0, 2}.</summary>
		D2D1_DASH_STYLE_DOT,

		/// <summary>
		/// A dash, followed by a gap, followed by a dot, followed by another gap.The equivalent dash array for D2D1_DASH_STYLE_DASH_DOT
		/// is {2, 2, 0, 2}.
		/// </summary>
		D2D1_DASH_STYLE_DASH_DOT,

		/// <summary>
		/// A dash, followed by a gap, followed by a dot, followed by another gap, followed by another dot, followed by another gap.The
		/// equivalent dash array for D2D1_DASH_STYLE_DASH_DOT_DOT is {2, 2, 0, 2, 0, 2}.
		/// </summary>
		D2D1_DASH_STYLE_DASH_DOT_DOT,

		/// <summary>The dash pattern is specified by an array of floating-point values.</summary>
		D2D1_DASH_STYLE_CUSTOM,

		/// <summary/>
		D2D1_DASH_STYLE_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Specifies how a device context is initialized for GDI rendering when it is retrieved from the render target.</summary>
	/// <remarks>
	/// Use this enumeration with the ID2D1GdiInteropRenderTarget::GetDC method to specify how the device context is initialized for GDI rendering.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_dc_initialize_mode typedef enum D2D1_DC_INITIALIZE_MODE {
	// D2D1_DC_INITIALIZE_MODE_COPY, D2D1_DC_INITIALIZE_MODE_CLEAR, D2D1_DC_INITIALIZE_MODE_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "a7837fe4-6e11-42a0-8a85-cba42e0f123a")]
	public enum D2D1_DC_INITIALIZE_MODE : uint
	{
		/// <summary>The current contents of the render target are copied to the device context when it is initialized.</summary>
		D2D1_DC_INITIALIZE_MODE_COPY = 0,

		/// <summary>The device context is cleared to transparent black when it is initialized.</summary>
		D2D1_DC_INITIALIZE_MODE_CLEAR,

		/// <summary/>
		D2D1_DC_INITIALIZE_MODE_FORCE_DWORD = 0xffffffff
	}

	/// <summary>Indicates the type of information provided by the Direct2D Debug Layer.</summary>
	/// <remarks>To receive debugging messages, you must install the Direct2D Debug Layer.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_debug_level typedef enum D2D1_DEBUG_LEVEL {
	// D2D1_DEBUG_LEVEL_NONE, D2D1_DEBUG_LEVEL_ERROR, D2D1_DEBUG_LEVEL_WARNING, D2D1_DEBUG_LEVEL_INFORMATION,
	// D2D1_DEBUG_LEVEL_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "3f1b4127-12d4-4472-ae26-0b69fdbb35a7")]
	public enum D2D1_DEBUG_LEVEL : uint
	{
		/// <summary>Direct2D does not produce any debugging output.</summary>
		D2D1_DEBUG_LEVEL_NONE,

		/// <summary>Direct2D sends error messages to the debug layer.</summary>
		D2D1_DEBUG_LEVEL_ERROR,

		/// <summary>Direct2D sends error messages and warnings to the debug layer.</summary>
		D2D1_DEBUG_LEVEL_WARNING,

		/// <summary>
		/// Direct2D sends error messages, warnings, and additional diagnostic information that can help improve performance to the
		/// debug layer.
		/// </summary>
		D2D1_DEBUG_LEVEL_INFORMATION,

		/// <summary/>
		D2D1_DEBUG_LEVEL_FORCE_DWORD = 0xffffffff
	}

	/// <summary>This specifies options that apply to the device context for its lifetime.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_device_context_options typedef enum
	// D2D1_DEVICE_CONTEXT_OPTIONS { D2D1_DEVICE_CONTEXT_OPTIONS_NONE, D2D1_DEVICE_CONTEXT_OPTIONS_ENABLE_MULTITHREADED_OPTIMIZATIONS,
	// D2D1_DEVICE_CONTEXT_OPTIONS_FORCE_DWORD } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "be4e6eb7-0767-4faf-9f27-eeb3bed48244")]
	public enum D2D1_DEVICE_CONTEXT_OPTIONS : uint
	{
		/// <summary>The device context is created with default options.</summary>
		D2D1_DEVICE_CONTEXT_OPTIONS_NONE,

		/// <summary>
		/// Distribute rendering work across multiple threads. Refer to Improving the performance of Direct2D apps for additional notes
		/// on the use of this flag.
		/// </summary>
		D2D1_DEVICE_CONTEXT_OPTIONS_ENABLE_MULTITHREADED_OPTIMIZATIONS,

		/// <summary/>
		D2D1_DEVICE_CONTEXT_OPTIONS_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>
	/// Specifies whether text snapping is suppressed or clipping to the layout rectangle is enabled. This enumeration allows a bitwise
	/// combination of its member values.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_draw_text_options typedef enum D2D1_DRAW_TEXT_OPTIONS {
	// D2D1_DRAW_TEXT_OPTIONS_NO_SNAP, D2D1_DRAW_TEXT_OPTIONS_CLIP, D2D1_DRAW_TEXT_OPTIONS_ENABLE_COLOR_FONT,
	// D2D1_DRAW_TEXT_OPTIONS_DISABLE_COLOR_BITMAP_SNAPPING, D2D1_DRAW_TEXT_OPTIONS_NONE, D2D1_DRAW_TEXT_OPTIONS_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "30f5be4a-83c2-4039-8e09-00e842fc5eb2")]
	[Flags]
	public enum D2D1_DRAW_TEXT_OPTIONS : uint
	{
		/// <summary>Text is not vertically snapped to pixel boundaries. This setting is recommended for text that is being animated.</summary>
		D2D1_DRAW_TEXT_OPTIONS_NO_SNAP = 0x00000001,

		/// <summary>Text is clipped to the layout rectangle.</summary>
		D2D1_DRAW_TEXT_OPTIONS_CLIP = 0x00000002,

		/// <summary>In Windows 8.1 and later, text is rendered using color versions of glyphs, if defined by the font.</summary>
		D2D1_DRAW_TEXT_OPTIONS_ENABLE_COLOR_FONT = 0x00000004,

		/// <summary>Bitmap origins of color glyph bitmaps are not snapped.</summary>
		D2D1_DRAW_TEXT_OPTIONS_DISABLE_COLOR_BITMAP_SNAPPING = 0x00000008,

		/// <summary>Text is vertically snapped to pixel boundaries and is not clipped to the layout rectangle.</summary>
		D2D1_DRAW_TEXT_OPTIONS_NONE = 0x00000000,

		/// <summary/>
		D2D1_DRAW_TEXT_OPTIONS_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Specifies how a brush paints areas outside of its normal content area.</summary>
	/// <remarks>
	/// For an ID2D1BitmapBrush, the brush's content is the brush's bitmap. For an ID2D1LinearGradientBrush, the brush's content area is
	/// the gradient axis. For an ID2D1RadialGradientBrush, the brush's content is the area within the gradient ellipse.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_extend_mode typedef enum D2D1_EXTEND_MODE {
	// D2D1_EXTEND_MODE_CLAMP, D2D1_EXTEND_MODE_WRAP, D2D1_EXTEND_MODE_MIRROR, D2D1_EXTEND_MODE_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "6b6e1fe1-d43a-46cf-904d-5266b9bd6bf4")]
	public enum D2D1_EXTEND_MODE : uint
	{
		/// <summary>Repeat the edge pixels of the brush's content for all regions outside the normal content area.</summary>
		D2D1_EXTEND_MODE_CLAMP,

		/// <summary>Repeat the brush's content.</summary>
		D2D1_EXTEND_MODE_WRAP,

		/// <summary>
		/// The same as D2D1_EXTEND_MODE_WRAP, except that alternate tiles of the brush's content are flipped. (The brush's normal
		/// content is drawn untransformed.)
		/// </summary>
		D2D1_EXTEND_MODE_MIRROR,

		/// <summary/>
		D2D1_EXTEND_MODE_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>
	/// Specifies whether Direct2D provides synchronization for an ID2D1Factory and the resources it creates, so that they may be safely
	/// accessed from multiple threads.
	/// </summary>
	/// <remarks>
	/// <para>
	/// When you create a factory, you can specify whether it is multithreaded or singlethreaded. A singlethreaded factory provides no
	/// serialization against any other single threaded instance within Direct2D, so this mechanism provides a very large degree of
	/// scaling on the CPU.
	/// </para>
	/// <para>
	/// You can also create a multithreaded factory instance. In this case, the factory and all derived objects can be used from any
	/// thread, and each render target can be rendered to independently. Direct2D serializes calls to these objects, so a single
	/// multithreaded Direct2D instance won't scale as well on the CPU as many single threaded instances. However, the resources can be
	/// shared within the multithreaded instance.
	/// </para>
	/// <para>
	/// Note the qualifier "On the CPU": GPUs generally take advantage of fine-grained parallelism more so than CPUs. For example,
	/// multithreaded calls from the CPU might still end up being serialized when being sent to the GPU; however, a whole bank of pixel
	/// and vertex shaders will run in parallel to perform the rendering.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_factory_type typedef enum D2D1_FACTORY_TYPE {
	// D2D1_FACTORY_TYPE_SINGLE_THREADED, D2D1_FACTORY_TYPE_MULTI_THREADED, D2D1_FACTORY_TYPE_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "428053d3-7ea0-4b01-9924-4a31d8e018fb")]
	public enum D2D1_FACTORY_TYPE : uint
	{
		/// <summary>
		/// No synchronization is provided for accessing or writing to the factory or the objects it creates. If the factory or the
		/// objects are called from multiple threads, it is up to the application to provide access locking.
		/// </summary>
		D2D1_FACTORY_TYPE_SINGLE_THREADED = 0,

		/// <summary>
		/// Direct2D provides synchronization for accessing and writing to the factory and the objects it creates, enabling safe access
		/// from multiple threads.
		/// </summary>
		D2D1_FACTORY_TYPE_MULTI_THREADED,

		/// <summary/>
		D2D1_FACTORY_TYPE_FORCE_DWORD = 0xffffffff
	}

	/// <summary>Describes the minimum DirectX support required for hardware rendering by a render target.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_feature_level typedef enum D2D1_FEATURE_LEVEL {
	// D2D1_FEATURE_LEVEL_DEFAULT, D2D1_FEATURE_LEVEL_9, D2D1_FEATURE_LEVEL_10, D2D1_FEATURE_LEVEL_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "d9604c37-7345-40e3-850c-2e2c99353ba5")]
	public enum D2D1_FEATURE_LEVEL : uint
	{
		/// <summary>Direct2D determines whether the video card provides adequate hardware rendering support.</summary>
		D2D1_FEATURE_LEVEL_DEFAULT,

		/// <summary>The video card must support DirectX 9.</summary>
		D2D1_FEATURE_LEVEL_9,

		/// <summary>The video card must support DirectX 10.</summary>
		D2D1_FEATURE_LEVEL_10,

		/// <summary/>
		D2D1_FEATURE_LEVEL_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Indicates whether a specific ID2D1SimplifiedGeometrySink figure is filled or hollow.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_figure_begin typedef enum D2D1_FIGURE_BEGIN {
	// D2D1_FIGURE_BEGIN_FILLED, D2D1_FIGURE_BEGIN_HOLLOW, D2D1_FIGURE_BEGIN_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "c29aa79e-b978-4318-a8e1-5a321cd66327")]
	// public enum D2D1_FIGURE_BEGIN{D2D1_FIGURE_BEGIN_FILLED, D2D1_FIGURE_BEGIN_HOLLOW, D2D1_FIGURE_BEGIN_FORCE_DWORD, }
	public enum D2D1_FIGURE_BEGIN : uint
	{
		/// <summary>
		/// Indicates the figure will be filled by the FillGeometry (ID2D1CommandSink::FillGeometry or ID2D1RenderTarget::FillGeometry) method.
		/// </summary>
		D2D1_FIGURE_BEGIN_FILLED = 0,

		/// <summary>
		/// Indicates the figure will not be filled by the FillGeometry (ID2D1CommandSink::FillGeometry or
		/// ID2D1RenderTarget::FillGeometry) method and will only consist of an outline. Moreover, the bounds of a hollow figure are
		/// zero. D2D1_FIGURE_BEGIN_HOLLOW should be used for stroking, or for other geometry operations.
		/// </summary>
		D2D1_FIGURE_BEGIN_HOLLOW = 1,

		/// <summary/>
		D2D1_FIGURE_BEGIN_FORCE_DWORD = 0xffffffff
	}

	/// <summary>Indicates whether a specific ID2D1SimplifiedGeometrySink figure is open or closed.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_figure_end typedef enum D2D1_FIGURE_END {
	// D2D1_FIGURE_END_OPEN, D2D1_FIGURE_END_CLOSED, D2D1_FIGURE_END_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "44821eef-7ecf-44c1-bbfb-df259c0489dd")]
	// public enum D2D1_FIGURE_END{D2D1_FIGURE_END_OPEN, D2D1_FIGURE_END_CLOSED, D2D1_FIGURE_END_FORCE_DWORD, }
	public enum D2D1_FIGURE_END : uint
	{
		/// <summary>The figure is open.</summary>
		D2D1_FIGURE_END_OPEN = 0,

		/// <summary>The figure is closed.</summary>
		D2D1_FIGURE_END_CLOSED = 1,

		/// <summary/>
		D2D1_FIGURE_END_FORCE_DWORD = 0xffffffff
	}

	/// <summary>Specifies how the intersecting areas of geometries or figures are combined to form the area of the composite geometry.</summary>
	/// <remarks>
	/// <para>
	/// Use the <c>D2D1_FILL_MODE</c> enumeration when creating an ID2D1GeometryGroup with the CreateGeometryGroup method, or when
	/// modifying the fill mode of an ID2D1SimplifiedGeometrySink with the ID2D1SimplifiedGeometrySink::SetFillMode method.
	/// </para>
	/// <para>
	/// Direct2D fills the interior of a path by using one of the two fill modes specified by this enumeration:
	/// <c>D2D1_FILL_MODE_ALTERNATE</c> (alternate) or <c>D2D1_FILL_MODE_WINDING</c> (winding). Because the modes determine how to fill
	/// the interior of a closed shape, all shapes are treated as closed when they are filled. If there is a gap in a segment in a
	/// shape, draw an imaginary line to close it.
	/// </para>
	/// <para>
	/// To see the difference between the winding and alternate fill modes, assume that you have four circles with the same center and a
	/// different radius, as shown in the following illustration. The first one has the radius of 25, the second 50, the third 75, and
	/// the fourth 100.
	/// </para>
	/// <para>
	/// The following illustration shows the shape filled by using the alternate fill mode. Notice that the center and third ring are
	/// not filled. This is because a ray drawn from any point in either of those two rings passes through an even number of segments.
	/// </para>
	/// <para>The following illustration explains this process.</para>
	/// <para>The following illustration shows how the same shape is filled when the winding fill mode is specified.</para>
	/// <para>
	/// Notice that all the rings are filled. This is because all the segments run in the same direction, so a ray drawn from any point
	/// will cross one or more segments, and the sum of the crossings will not equal zero.
	/// </para>
	/// <para>
	/// The following illustration explains this process. The red arrows represent the direction in which the segments are drawn and the
	/// black arrow represents an arbitrary ray that runs from a point in the innermost ring. Starting with a value of zero, for each
	/// segment that the ray crosses, a value of one is added for every clockwise intersection. All points lie in the fill region in
	/// this illustration, because the count does not equal zero.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_fill_mode typedef enum D2D1_FILL_MODE {
	// D2D1_FILL_MODE_ALTERNATE, D2D1_FILL_MODE_WINDING, D2D1_FILL_MODE_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "f1a14447-39fa-4a48-9516-ff5b03abc3a6")]
	public enum D2D1_FILL_MODE
	{
		/// <summary>
		/// Determines whether a point is in the fill region by drawing a ray from that point to infinity in any direction, and then
		/// counting the number of path segments within the given shape that the ray crosses. If this number is odd, the point is in the
		/// fill region; if even, the point is outside the fill region.
		/// </summary>
		D2D1_FILL_MODE_ALTERNATE,

		/// <summary>
		/// Determines whether a point is in the fill region of the path by drawing a ray from that point to infinity in any direction,
		/// and then examining the places where a segment of the shape crosses the ray. Starting with a count of zero, add one each time
		/// a segment crosses the ray from left to right and subtract one each time a path segment crosses the ray from right to left,
		/// as long as left and right are seen from the perspective of the ray. After counting the crossings, if the result is zero,
		/// then the point is outside the path. Otherwise, it is inside the path.
		/// </summary>
		D2D1_FILL_MODE_WINDING,

		/// <summary/>
		D2D1_FILL_MODE_FORCE_DWORD,
	}

	/// <summary>Specifies which gamma is used for interpolation.</summary>
	/// <remarks>
	/// <para>
	/// Interpolating in a linear gamma space ( <c>D2D1_GAMMA_1_0</c>) can avoid changes in perceived brightness caused by the effect of
	/// gamma correction in spaces where the gamma is not 1.0, such as the default sRGB color space, where the gamma is 2.2. For an
	/// example of the differences between these two blending modes, consider the following illustration, which shows two gradients,
	/// each of which blends from red to blue to green:
	/// </para>
	/// <para>
	/// The first gradient is interpolated linearly in the space of the render target (sRGB in this case), and one can see the dark
	/// bands between each color. The second gradient uses a gamma-correct linear interpolation, and thus does not exhibit the same
	/// variations in brightness.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_gamma typedef enum D2D1_GAMMA { D2D1_GAMMA_2_2,
	// D2D1_GAMMA_1_0, D2D1_GAMMA_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "c84c66c6-5f4a-41de-938c-76a409145971")]
	public enum D2D1_GAMMA : uint
	{
		/// <summary>Interpolation is performed in the standard RGB (sRGB) gamma.</summary>
		D2D1_GAMMA_2_2,

		/// <summary>Interpolation is performed in the linear-gamma color space.</summary>
		D2D1_GAMMA_1_0,

		/// <summary/>
		D2D1_GAMMA_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Describes how one geometry object is spatially related to another geometry object.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_geometry_relation typedef enum D2D1_GEOMETRY_RELATION {
	// D2D1_GEOMETRY_RELATION_UNKNOWN, D2D1_GEOMETRY_RELATION_DISJOINT, D2D1_GEOMETRY_RELATION_IS_CONTAINED,
	// D2D1_GEOMETRY_RELATION_CONTAINS, D2D1_GEOMETRY_RELATION_OVERLAP, D2D1_GEOMETRY_RELATION_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "6c7290c8-9363-414b-af2c-0f2a79da99f9")]
	public enum D2D1_GEOMETRY_RELATION : uint
	{
		/// <summary>The relationship between the two geometries cannot be determined. This value is never returned by any D2D method.</summary>
		D2D1_GEOMETRY_RELATION_UNKNOWN = 0,

		/// <summary>The two geometries do not intersect at all.</summary>
		D2D1_GEOMETRY_RELATION_DISJOINT,

		/// <summary>The instance geometry is entirely contained by the passed-in geometry.</summary>
		D2D1_GEOMETRY_RELATION_IS_CONTAINED,

		/// <summary>The instance geometry entirely contains the passed-in geometry.</summary>
		D2D1_GEOMETRY_RELATION_CONTAINS,

		/// <summary>The two geometries overlap but neither completely contains the other.</summary>
		D2D1_GEOMETRY_RELATION_OVERLAP,

		/// <summary/>
		D2D1_GEOMETRY_RELATION_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Specifies how a geometry is simplified to an ID2D1SimplifiedGeometrySink.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_geometry_simplification_option typedef enum
	// D2D1_GEOMETRY_SIMPLIFICATION_OPTION { D2D1_GEOMETRY_SIMPLIFICATION_OPTION_CUBICS_AND_LINES,
	// D2D1_GEOMETRY_SIMPLIFICATION_OPTION_LINES, D2D1_GEOMETRY_SIMPLIFICATION_OPTION_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "cda5968b-843b-4759-ae0f-cb83e9990590")]
	public enum D2D1_GEOMETRY_SIMPLIFICATION_OPTION : uint
	{
		/// <summary>The output can contain cubic Bezier curves and line segments.</summary>
		D2D1_GEOMETRY_SIMPLIFICATION_OPTION_CUBICS_AND_LINES = 0,

		/// <summary>The output is flattened so that it contains only line segments.</summary>
		D2D1_GEOMETRY_SIMPLIFICATION_OPTION_LINES,

		/// <summary/>
		D2D1_GEOMETRY_SIMPLIFICATION_OPTION_FORCE_DWORD = 0xffffffff
	}

	/// <summary>
	/// <para>Specifies options that can be applied when a layer resource is applied to create a layer.</para>
	/// <para>
	/// <c>Note</c> Starting in Windows 8, the <c>D2D1_LAYER_OPTIONS_INITIALIZE_FOR_CLEARTYPE</c> option is no longer supported. See
	/// D2D1_LAYER_OPTIONS1 for Windows 8 layer options.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// ClearType antialiasing must use the current contents of the render target to blend properly. When a pushed layer requests
	/// initializing for ClearType, Direct2D copies the current contents of the render target into the layer so that ClearType
	/// antialiasing can be performed. Rendering ClearType text into a transparent layer does not produce the desired results.
	/// </para>
	/// <para>A small performance hit from re-copying content occurs when ID2D1RenderTarget::Clear is called.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_layer_options typedef enum D2D1_LAYER_OPTIONS {
	// D2D1_LAYER_OPTIONS_NONE, D2D1_LAYER_OPTIONS_INITIALIZE_FOR_CLEARTYPE, D2D1_LAYER_OPTIONS_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "d278211a-e99c-429d-9752-45c305f52ed8")]
	[Flags]
	public enum D2D1_LAYER_OPTIONS : uint
	{
		/// <summary>The text in this layer does not use ClearType antialiasing.</summary>
		D2D1_LAYER_OPTIONS_NONE = 0x00000000,

		/// <summary>
		/// The layer renders correctly for ClearType text. If the render target is set to ClearType, the layer continues to render
		/// ClearType. If the render target is set to ClearType and this option is not specified, the render target will be set to
		/// render gray-scale until the layer is popped. The caller can override this default by calling SetTextAntialiasMode while
		/// within the layer. This flag is slightly slower than the default.
		/// </summary>
		D2D1_LAYER_OPTIONS_INITIALIZE_FOR_CLEARTYPE = 0x00000001,

		/// <summary/>
		D2D1_LAYER_OPTIONS_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Describes the shape that joins two lines or segments.</summary>
	/// <remarks>
	/// <para>
	/// A miter limit affects how sharp miter joins are allowed to be. If the line join style is <c>D2D1_LINE_JOIN_MITER_OR_BEVEL</c>,
	/// then the join will be mitered with regular angular vertices if it doesn't extend beyond the miter limit; otherwise, the line
	/// join will be beveled.
	/// </para>
	/// <para>The following illustration shows different line join settings for the same stroked path geometry.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_line_join typedef enum D2D1_LINE_JOIN {
	// D2D1_LINE_JOIN_MITER, D2D1_LINE_JOIN_BEVEL, D2D1_LINE_JOIN_ROUND, D2D1_LINE_JOIN_MITER_OR_BEVEL, D2D1_LINE_JOIN_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "4368e93e-af69-4555-ac2b-c9c576c81372")]
	public enum D2D1_LINE_JOIN : uint
	{
		/// <summary>Regular angular vertices.</summary>
		D2D1_LINE_JOIN_MITER,

		/// <summary>Beveled vertices.</summary>
		D2D1_LINE_JOIN_BEVEL,

		/// <summary>Rounded vertices.</summary>
		D2D1_LINE_JOIN_ROUND,

		/// <summary>Regular angular vertices unless the join would extend beyond the miter limit; otherwise, beveled vertices.</summary>
		D2D1_LINE_JOIN_MITER_OR_BEVEL,

		/// <summary/>
		D2D1_LINE_JOIN_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>
	/// Describes whether an opacity mask contains graphics or text. Direct2D uses this information to determine which gamma space to
	/// use when blending the opacity mask.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_opacity_mask_content typedef enum D2D1_OPACITY_MASK_CONTENT
	// { D2D1_OPACITY_MASK_CONTENT_GRAPHICS, D2D1_OPACITY_MASK_CONTENT_TEXT_NATURAL, D2D1_OPACITY_MASK_CONTENT_TEXT_GDI_COMPATIBLE,
	// D2D1_OPACITY_MASK_CONTENT_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "ea14d7eb-b8cc-4ab8-8f51-9174748ee6a2")]
	public enum D2D1_OPACITY_MASK_CONTENT : uint
	{
		/// <summary>The opacity mask contains graphics. The opacity mask is blended in the gamma 2.2 color space.</summary>
		D2D1_OPACITY_MASK_CONTENT_GRAPHICS,

		/// <summary>
		/// The opacity mask contains non-GDI text. The gamma space used for blending is obtained from the render target's text
		/// rendering parameters. (ID2D1RenderTarget::SetTextRenderingParams).
		/// </summary>
		D2D1_OPACITY_MASK_CONTENT_TEXT_NATURAL,

		/// <summary>
		/// The opacity mask contains text rendered using the GDI-compatible rendering mode. The opacity mask is blended using the gamma
		/// for GDI rendering.
		/// </summary>
		D2D1_OPACITY_MASK_CONTENT_TEXT_GDI_COMPATIBLE,

		/// <summary/>
		D2D1_OPACITY_MASK_CONTENT_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>
	/// Indicates whether a segment should be stroked and whether the join between this segment and the previous one should be smooth.
	/// This enumeration allows a bitwise combination of its member values.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_path_segment typedef enum D2D1_PATH_SEGMENT {
	// D2D1_PATH_SEGMENT_NONE, D2D1_PATH_SEGMENT_FORCE_UNSTROKED, D2D1_PATH_SEGMENT_FORCE_ROUND_LINE_JOIN, D2D1_PATH_SEGMENT_FORCE_DWORD
	// } ;
	[PInvokeData("d2d1.h", MSDNShortId = "375a0a40-ec98-4f41-9c15-d284f8b17a73")]
	[Flags]
	public enum D2D1_PATH_SEGMENT : uint
	{
		/// <summary>The segment is joined as specified by the ID2D1StrokeStyle interface, and it is stroked.</summary>
		D2D1_PATH_SEGMENT_NONE = 0x00000000,

		/// <summary>The segment is not stroked.</summary>
		D2D1_PATH_SEGMENT_FORCE_UNSTROKED = 0x00000001,

		/// <summary>
		/// The segment is always joined with the one preceding it using a round line join, regardless of which
		/// D2D1_LINE_JOINenumeration is specified by the ID2D1StrokeStyle interface. If this segment is the first segment and the
		/// figure is closed, a round line join is used to connect the closing segment with the first segment. If the figure is not
		/// closed, this setting has no effect on the first segment of the figure. If ID2D1SimplifiedGeometrySink::SetSegmentFlags is
		/// called just before ID2D1SimplifiedGeometrySink::EndFigure, the join between the closing segment and the last explicitly
		/// specified segment is affected.
		/// </summary>
		D2D1_PATH_SEGMENT_FORCE_ROUND_LINE_JOIN = 0x00000002,

		/// <summary/>
		D2D1_PATH_SEGMENT_FORCE_DWORD = 0xffffffff
	}

	/// <summary>
	/// Describes how a render target behaves when it presents its content. This enumeration allows a bitwise combination of its member values.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_present_options typedef enum D2D1_PRESENT_OPTIONS {
	// D2D1_PRESENT_OPTIONS_NONE, D2D1_PRESENT_OPTIONS_RETAIN_CONTENTS, D2D1_PRESENT_OPTIONS_IMMEDIATELY,
	// D2D1_PRESENT_OPTIONS_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "56178ee9-7d35-42e1-97f8-62835010f277")]
	[Flags]
	public enum D2D1_PRESENT_OPTIONS : uint
	{
		/// <summary>The render target waits until the display refreshes to present and discards the frame upon presenting.</summary>
		D2D1_PRESENT_OPTIONS_NONE,

		/// <summary>The render target does not discard the frame upon presenting.</summary>
		D2D1_PRESENT_OPTIONS_RETAIN_CONTENTS,

		/// <summary>The render target does not wait until the display refreshes to present.</summary>
		D2D1_PRESENT_OPTIONS_IMMEDIATELY,

		/// <summary/>
		D2D1_PRESENT_OPTIONS_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Defines when font resources should be subset during printing.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_print_font_subset_mode typedef enum
	// D2D1_PRINT_FONT_SUBSET_MODE { D2D1_PRINT_FONT_SUBSET_MODE_DEFAULT, D2D1_PRINT_FONT_SUBSET_MODE_EACHPAGE,
	// D2D1_PRINT_FONT_SUBSET_MODE_NONE, D2D1_PRINT_FONT_SUBSET_MODE_FORCE_DWORD } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "B8361117-6018-48EE-AD3D-2A37F6B71293")]
	public enum D2D1_PRINT_FONT_SUBSET_MODE : uint
	{
		/// <summary/>
		D2D1_PRINT_FONT_SUBSET_MODE_DEFAULT,

		/// <summary/>
		D2D1_PRINT_FONT_SUBSET_MODE_EACHPAGE,

		/// <summary/>
		D2D1_PRINT_FONT_SUBSET_MODE_NONE,

		/// <summary/>
		D2D1_PRINT_FONT_SUBSET_MODE_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>
	/// Describes whether a render target uses hardware or software rendering, or if Direct2D should select the rendering mode.
	/// </summary>
	/// <remarks>Not every render target supports hardware rendering. For more information, see the Render Targets Overview.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_render_target_type typedef enum D2D1_RENDER_TARGET_TYPE {
	// D2D1_RENDER_TARGET_TYPE_DEFAULT, D2D1_RENDER_TARGET_TYPE_SOFTWARE, D2D1_RENDER_TARGET_TYPE_HARDWARE,
	// D2D1_RENDER_TARGET_TYPE_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "4ae6e4cf-e1c9-476e-a7b5-31cdad9cf321")]
	public enum D2D1_RENDER_TARGET_TYPE : uint
	{
		/// <summary>The render target uses hardware rendering, if available; otherwise, it uses software rendering.</summary>
		D2D1_RENDER_TARGET_TYPE_DEFAULT,

		/// <summary>The render target uses software rendering only.</summary>
		D2D1_RENDER_TARGET_TYPE_SOFTWARE,

		/// <summary>The render target uses hardware rendering only.</summary>
		D2D1_RENDER_TARGET_TYPE_HARDWARE,

		/// <summary/>
		D2D1_RENDER_TARGET_TYPE_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>
	/// Describes how a render target is remoted and whether it should be GDI-compatible. This enumeration allows a bitwise combination
	/// of its member values.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_render_target_usage typedef enum D2D1_RENDER_TARGET_USAGE {
	// D2D1_RENDER_TARGET_USAGE_NONE, D2D1_RENDER_TARGET_USAGE_FORCE_BITMAP_REMOTING, D2D1_RENDER_TARGET_USAGE_GDI_COMPATIBLE,
	// D2D1_RENDER_TARGET_USAGE_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "12d717c4-5f81-4bbf-a693-042e51913081")]
	public enum D2D1_RENDER_TARGET_USAGE : uint
	{
		/// <summary>
		/// The render target attempts to use Direct3D command-stream remoting and uses bitmap remoting if stream remoting fails. The
		/// render target is not GDI-compatible.
		/// </summary>
		D2D1_RENDER_TARGET_USAGE_NONE,

		/// <summary>The render target renders content locally and sends it to the terminal services client as a bitmap.</summary>
		D2D1_RENDER_TARGET_USAGE_FORCE_BITMAP_REMOTING,

		/// <summary>The render target can be used efficiently with GDI.</summary>
		D2D1_RENDER_TARGET_USAGE_GDI_COMPATIBLE,

		/// <summary/>
		D2D1_RENDER_TARGET_USAGE_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Defines the direction that an elliptical arc is drawn.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_sweep_direction typedef enum D2D1_SWEEP_DIRECTION {
	// D2D1_SWEEP_DIRECTION_COUNTER_CLOCKWISE, D2D1_SWEEP_DIRECTION_CLOCKWISE, D2D1_SWEEP_DIRECTION_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "97e6f384-7a42-4852-b948-66010bffed22")]
	public enum D2D1_SWEEP_DIRECTION : uint
	{
		/// <summary>Arcs are drawn in a counterclockwise (negative-angle) direction.</summary>
		D2D1_SWEEP_DIRECTION_COUNTER_CLOCKWISE = 0,

		/// <summary>Arcs are drawn in a clockwise (positive-angle) direction.</summary>
		D2D1_SWEEP_DIRECTION_CLOCKWISE = 1,

		/// <summary/>
		D2D1_SWEEP_DIRECTION_FORCE_DWORD = 0xffffffff
	}

	/// <summary>Describes the antialiasing mode used for drawing text.</summary>
	/// <remarks>
	/// <para>This enumeration is used with the SetTextAntialiasMode of an ID2D1RenderTarget to specify how text and glyphs are antialiased.</para>
	/// <para>By default, Direct2D renders text in ClearType mode. Factors that</para>
	/// <para>can downgrade the default quality to grayscale or aliased:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the DWRITE_RENDERING_MODE value is <c>DWRITE_RENDERING_MODE_ALIASED</c>, then the default text antialiasing mode is aliased.
	/// To change the DirectWrite rendering mode of an ID2D1RenderTarget, use the ID2D1RenderTarget::SetTextRenderingParams method.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the render target has an alpha channel and is not set to D2D1_ALPHA_MODE_IGNORE, then the default text antialiasing mode is grayscale.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_text_antialias_mode typedef enum D2D1_TEXT_ANTIALIAS_MODE {
	// D2D1_TEXT_ANTIALIAS_MODE_DEFAULT, D2D1_TEXT_ANTIALIAS_MODE_CLEARTYPE, D2D1_TEXT_ANTIALIAS_MODE_GRAYSCALE,
	// D2D1_TEXT_ANTIALIAS_MODE_ALIASED, D2D1_TEXT_ANTIALIAS_MODE_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "d2c829d7-9892-4cbb-9993-12bb7d77fc25")]
	public enum D2D1_TEXT_ANTIALIAS_MODE : uint
	{
		/// <summary>Use the system default. See Remarks.</summary>
		D2D1_TEXT_ANTIALIAS_MODE_DEFAULT,

		/// <summary>Use ClearType antialiasing.</summary>
		D2D1_TEXT_ANTIALIAS_MODE_CLEARTYPE,

		/// <summary>Use grayscale antialiasing.</summary>
		D2D1_TEXT_ANTIALIAS_MODE_GRAYSCALE,

		/// <summary>Do not use antialiasing.</summary>
		D2D1_TEXT_ANTIALIAS_MODE_ALIASED,

		/// <summary/>
		D2D1_TEXT_ANTIALIAS_MODE_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Describes whether a window is occluded.</summary>
	/// <remarks>
	/// If the window was occluded the last time EndDraw was called, the next time the render target calls CheckWindowState, it returns
	/// <c>D2D1_WINDOW_STATE_OCCLUDED</c> regardless of the current window state. If you want to use <c>CheckWindowState</c> to check
	/// the current window state, call <c>CheckWindowState</c> after every <c>EndDraw</c> call and ignore its return value. This will
	/// ensure that your next call to <c>CheckWindowState</c> state returns the actual window state.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_window_state typedef enum D2D1_WINDOW_STATE {
	// D2D1_WINDOW_STATE_NONE, D2D1_WINDOW_STATE_OCCLUDED, D2D1_WINDOW_STATE_FORCE_DWORD } ;
	[PInvokeData("d2d1.h", MSDNShortId = "79d3a903-f29e-4d0d-9918-85fbfc846517")]
	[Flags]
	public enum D2D1_WINDOW_STATE : uint
	{
		/// <summary>The window is not occluded.</summary>
		D2D1_WINDOW_STATE_NONE = 0x0000000,

		/// <summary>The window is occluded.</summary>
		D2D1_WINDOW_STATE_OCCLUDED = 0x0000001,

		/// <summary/>
		D2D1_WINDOW_STATE_FORCE_DWORD = 0xffffffff
	}

	/// <summary>Computes the maximum factor by which a given transform can stretch any vector.</summary>
	/// <param name="matrix">The input transform matrix.</param>
	/// <returns>The scale factor.</returns>
	/// <remarks>
	/// <para>
	/// Formally, if M is the input matrix, this method will return the maximum value of |V * M| / |V| for all vectors V, where |.|
	/// denotes length.
	/// </para>
	/// <para>
	/// <c>Note</c> Since this describes how M affects vectors (rather than points), the translation components (_31 and _32) of M are ignored.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_2/nf-d2d1_2-d2d1computemaximumscalefactor FLOAT
	// D2D1ComputeMaximumScaleFactor( const D2D1_MATRIX_3X2_F *matrix );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1_2.h", MSDNShortId = "5BC10305-436F-4528-9647-E70713130505")]
	public static extern float D2D1ComputeMaximumScaleFactor(in D2D_MATRIX_3X2_F matrix);

	/// <summary>Converts the given color from one colorspace to another.</summary>
	/// <param name="sourceColorSpace">
	/// <para>Type: <c>D2D1_COLOR_SPACE</c></para>
	/// <para>The source color space.</para>
	/// </param>
	/// <param name="destinationColorSpace">
	/// <para>Type: <c>D2D1_COLOR_SPACE</c></para>
	/// <para>The destination color space.</para>
	/// </param>
	/// <param name="color">
	/// <para>Type: <c>const D2D1_COLOR_F*</c></para>
	/// <para>The source color.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>D2D1_COLOR_F</c></para>
	/// <para>The converted color.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-d2d1convertcolorspace D2D1_COLOR_F D2D1ConvertColorSpace(
	// D2D1_COLOR_SPACE sourceColorSpace, D2D1_COLOR_SPACE destinationColorSpace, const D2D1_COLOR_F *color );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1_1.h", MSDNShortId = "ECFE9F50-290D-4E6C-90AB-A46B9E413A48")]
	public static extern D3DCOLORVALUE D2D1ConvertColorSpace(D2D1_COLOR_SPACE sourceColorSpace, D2D1_COLOR_SPACE destinationColorSpace, in D3DCOLORVALUE color);

	/// <summary>Creates a new Direct2D device associated with the provided DXGI device.</summary>
	/// <param name="dxgiDevice">The DXGI device the Direct2D device is associated with.</param>
	/// <param name="creationProperties">The properties to apply to the Direct2D device.</param>
	/// <param name="d2dDevice">When this function returns, contains the address of a pointer to a Direct2D device.</param>
	/// <returns>
	/// <para>The function returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>HRESULT</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>No error occurred.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Direct2D could not allocate sufficient memory to complete the call.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>An invalid value was passed to the method.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function will also create a new ID2D1Factory1 that can be retrieved through ID2D1Resource::GetFactory.</para>
	/// <para>
	/// If the creation properties are not specified, then d2dDevice will inherit its threading mode from dxgiDevice and debug tracing
	/// will not be enabled.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-d2d1createdevice HRESULT D2D1CreateDevice( IDXGIDevice
	// *dxgiDevice, const D2D1_CREATION_PROPERTIES *creationProperties, ID2D1Device **d2dDevice );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1_1.h", MSDNShortId = "5ed3ec21-b609-41b6-9568-6ede460bc395")]
	public static extern HRESULT D2D1CreateDevice(IDXGIDevice dxgiDevice, in D2D1_CREATION_PROPERTIES creationProperties, out ID2D1Device d2dDevice);

	/// <summary>Creates a new Direct2D device context associated with a DXGI surface.</summary>
	/// <param name="dxgiSurface">The DXGI surface the Direct2D device context is associated with.</param>
	/// <param name="creationProperties">The properties to apply to the Direct2D device context.</param>
	/// <param name="d2dDeviceContext">When this function returns, contains the address of a pointer to a Direct2D device context.</param>
	/// <returns>
	/// <para>The function returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>HRESULT</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>No error occurred.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Direct2D could not allocate sufficient memory to complete the call.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>An invalid value was passed to the method.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function will also create a new ID2D1Factory1 that can be retrieved through ID2D1Resource::GetFactory.</para>
	/// <para>This function will also create a new ID2D1Device that can be retrieved through ID2D1DeviceContext::GetDevice.</para>
	/// <para>The DXGI device will be specified implicitly through dxgiSurface.</para>
	/// <para>
	/// If creationProperties are not specified, the Direct2D device will inherit its threading mode from the DXGI device implied by
	/// dxgiSurface and debug tracing will not be enabled.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-d2d1createdevicecontext HRESULT D2D1CreateDeviceContext(
	// IDXGISurface *dxgiSurface, const D2D1_CREATION_PROPERTIES *creationProperties, ID2D1DeviceContext **d2dDeviceContext );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1_1.h", MSDNShortId = "0e56d057-20a5-47b7-aec9-63c8e31f349b")]
	public static extern HRESULT D2D1CreateDeviceContext(IDXGISurface dxgiSurface, in D2D1_CREATION_PROPERTIES creationProperties, out ID2D1DeviceContext d2dDeviceContext);

	/// <summary>Creates a factory object that can be used to create Direct2D resources.</summary>
	/// <param name="factoryType">
	/// <para>Type: <c>D2D1_FACTORY_TYPE</c></para>
	/// <para>The threading model of the factory and the resources it creates.</para>
	/// </param>
	/// <param name="riid">
	/// <para>Type: <c>REFIID</c></para>
	/// <para>A reference to the IID of ID2D1Factory that is obtained by using .</para>
	/// </param>
	/// <param name="pFactoryOptions">
	/// <para>Type: <c>const D2D1_FACTORY_OPTIONS*</c></para>
	/// <para>The level of detail provided to the debugging layer.</para>
	/// </param>
	/// <param name="ppIFactory">
	/// <para>Type: <c>void**</c></para>
	/// <para>When this method returns, contains the address to a pointer to the new factory.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
	/// </returns>
	/// <remarks>
	/// The ID2D1Factory interface provides the starting point for Direct2D. In general, an object created from a single instance of a
	/// factory object can be used with other resources created from that instance, but not with resources created by other factory instances.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-d2d1createfactory HRESULT D2D1CreateFactory( D2D1_FACTORY_TYPE
	// factoryType, REFIID riid, const D2D1_FACTORY_OPTIONS *pFactoryOptions, void **ppIFactory );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1.h", MSDNShortId = "8c0a685a-8f33-4072-a715-bb423cb44f03")]
	public static extern HRESULT D2D1CreateFactory(D2D1_FACTORY_TYPE factoryType, in Guid riid, [In, Optional] IntPtr pFactoryOptions, [MarshalAs(UnmanagedType.IUnknown)] out object ppIFactory);

	/// <summary>Creates a factory object that can be used to create Direct2D resources.</summary>
	/// <typeparam name="T">The type of the factory interface to create.</typeparam>
	/// <param name="factoryType">
	/// <para>Type: <c>D2D1_FACTORY_TYPE</c></para>
	/// <para>The threading model of the factory and the resources it creates.</para>
	/// </param>
	/// <param name="pFactoryOptions">
	/// <para>Type: <c>D2D1_FACTORY_OPTIONS?</c></para>
	/// <para>Optional level of detail provided to the debugging layer.</para>
	/// </param>
	/// <returns>When this method returns, contains the new factory interface specified in <typeparamref name="T"/>.</returns>
	[PInvokeData("d2d1.h", MSDNShortId = "8c0a685a-8f33-4072-a715-bb423cb44f03")]
	public static T D2D1CreateFactory<T>(D2D1_FACTORY_TYPE factoryType = D2D1_FACTORY_TYPE.D2D1_FACTORY_TYPE_SINGLE_THREADED, [In] D2D1_FACTORY_OPTIONS? pFactoryOptions = null) where T : class
	{
		using SafeCoTaskMemStruct<D2D1_FACTORY_OPTIONS> opts = pFactoryOptions;
#pragma warning disable IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
		D2D1CreateFactory(factoryType, typeof(T).GUID, opts, out var ppv).ThrowIfFailed();
#pragma warning restore IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
		return (T)ppv;
	}

	/// <summary>
	/// <para>Returns the interior points for a gradient mesh patch based on the points defining a Coons patch.</para>
	/// <para><c>Note</c></para>
	/// </summary>
	/// <param name="pPoint0">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 0.</para>
	/// </param>
	/// <param name="pPoint1">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 1.</para>
	/// </param>
	/// <param name="pPoint2">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 2.</para>
	/// </param>
	/// <param name="pPoint3">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 3.</para>
	/// </param>
	/// <param name="pPoint4">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 4.</para>
	/// </param>
	/// <param name="pPoint5">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 5.</para>
	/// </param>
	/// <param name="pPoint6">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 6.</para>
	/// </param>
	/// <param name="pPoint7">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 7.</para>
	/// </param>
	/// <param name="pPoint8">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 8.</para>
	/// </param>
	/// <param name="pPoint9">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 9.</para>
	/// </param>
	/// <param name="pPoint10">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 10.</para>
	/// </param>
	/// <param name="pPoint11">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 11.</para>
	/// </param>
	/// <param name="pTensorPoint11">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>Returns the interior point for the gradient mesh corresponding to point11 in the D2D1_GRADIENT_MESH_PATCH structure.</para>
	/// </param>
	/// <param name="pTensorPoint12">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>Returns the interior point for the gradient mesh corresponding to point12 in the D2D1_GRADIENT_MESH_PATCH structure.</para>
	/// </param>
	/// <param name="pTensorPoint21">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>Returns the interior point for the gradient mesh corresponding to point21 in the D2D1_GRADIENT_MESH_PATCH structure.</para>
	/// </param>
	/// <param name="pTensorPoint22">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>Returns the interior point for the gradient mesh corresponding to point22 in the D2D1_GRADIENT_MESH_PATCH structure.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>This function is called by the GradientMeshPatchFromCoonsPatch function and is not intended to be used directly.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-d2d1getgradientmeshinteriorpointsfromcoonspatch void
	// D2D1GetGradientMeshInteriorPointsFromCoonsPatch( const D2D1_POINT_2F *pPoint0, const D2D1_POINT_2F *pPoint1, const D2D1_POINT_2F
	// *pPoint2, const D2D1_POINT_2F *pPoint3, const D2D1_POINT_2F *pPoint4, const D2D1_POINT_2F *pPoint5, const D2D1_POINT_2F *pPoint6,
	// const D2D1_POINT_2F *pPoint7, const D2D1_POINT_2F *pPoint8, const D2D1_POINT_2F *pPoint9, const D2D1_POINT_2F *pPoint10, const
	// D2D1_POINT_2F *pPoint11, D2D1_POINT_2F *pTensorPoint11, D2D1_POINT_2F *pTensorPoint12, D2D1_POINT_2F *pTensorPoint21,
	// D2D1_POINT_2F *pTensorPoint22 );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1_3.h", MSDNShortId = "388d5cbf-cb15-f0c9-3f3b-897f68519a4c")]
	public static extern void D2D1GetGradientMeshInteriorPointsFromCoonsPatch(in D2D_POINT_2F pPoint0, in D2D_POINT_2F pPoint1, in D2D_POINT_2F pPoint2, in D2D_POINT_2F pPoint3,
		in D2D_POINT_2F pPoint4, in D2D_POINT_2F pPoint5, in D2D_POINT_2F pPoint6, in D2D_POINT_2F pPoint7, in D2D_POINT_2F pPoint8, in D2D_POINT_2F pPoint9,
		in D2D_POINT_2F pPoint10, in D2D_POINT_2F pPoint11, out D2D_POINT_2F pTensorPoint11, out D2D_POINT_2F pTensorPoint12, out D2D_POINT_2F pTensorPoint21, out D2D_POINT_2F pTensorPoint22);

	/// <summary>Tries to invert the specified matrix.</summary>
	/// <param name="matrix">
	/// <para>Type: <c>D2D1_MATRIX_3X2_F*</c></para>
	/// <para>The matrix to invert.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>true</c> if the matrix was inverted; otherwise, <c>false</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-d2d1invertmatrix BOOL D2D1InvertMatrix( D2D1_MATRIX_3X2_F *matrix );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1.h", MSDNShortId = "af01b6df-ada9-4e21-98f0-356b96d1017a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool D2D1InvertMatrix(ref D2D_MATRIX_3X2_F matrix);

	/// <summary>Indicates whether the specified matrix is invertible.</summary>
	/// <param name="matrix">
	/// <para>Type: <c>const D2D1_MATRIX_3X2_F*</c></para>
	/// <para>The matrix to test.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>true</c> if the matrix was inverted; otherwise, <c>false</c>.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-d2d1ismatrixinvertible BOOL D2D1IsMatrixInvertible( const
	// D2D1_MATRIX_3X2_F *matrix );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1.h", MSDNShortId = "c8ba9c60-dfc4-4872-81e0-e68dfd13f00e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool D2D1IsMatrixInvertible(in D2D_MATRIX_3X2_F matrix);

	/// <summary>Creates a rotation transformation that rotates by the specified angle about the specified point.</summary>
	/// <param name="angle">
	/// <para>Type: <c>FLOAT</c></para>
	/// <para>The clockwise rotation angle, in degrees.</para>
	/// </param>
	/// <param name="center">
	/// <para>Type: <c>D2D1_POINT_2F</c></para>
	/// <para>The point about which to rotate.</para>
	/// </param>
	/// <param name="matrix">
	/// <para>Type: <c>D2D1_MATRIX_3X2_F*</c></para>
	/// <para>When this method returns, contains the new rotation transformation. You must allocate storage for this parameter.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>Rotation occurs in the plane of the 2-D surface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-d2d1makerotatematrix void D2D1MakeRotateMatrix( FLOAT angle,
	// D2D1_POINT_2F center, D2D1_MATRIX_3X2_F *matrix );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1.h", MSDNShortId = "5e066328-5b0f-4e7a-9bf4-df55521fcc2b")]
	public static extern void D2D1MakeRotateMatrix(float angle, D2D_POINT_2F center, out D2D_MATRIX_3X2_F matrix);

	/// <summary>Creates a skew transformation that has the specified x-axis angle, y-axis angle, and center point.</summary>
	/// <param name="angleX">
	/// <para>Type: <c>FLOAT</c></para>
	/// <para>The x-axis skew angle, which is measured in degrees counterclockwise from the y-axis.</para>
	/// </param>
	/// <param name="angleY">
	/// <para>Type: <c>FLOAT</c></para>
	/// <para>The y-axis skew angle, which is measured in degrees counterclockwise from the x-axis.</para>
	/// </param>
	/// <param name="center">
	/// <para>Type: <c>D2D1_POINT_2F</c></para>
	/// <para>The center point of the skew operation.</para>
	/// </param>
	/// <param name="matrix">
	/// <para>Type: <c>D2D1_MATRIX_3X2_F*</c></para>
	/// <para>When this method returns, contains the rotation transformation. You must allocate storate for this parameter.</para>
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-d2d1makeskewmatrix void D2D1MakeSkewMatrix( FLOAT angleX, FLOAT
	// angleY, D2D1_POINT_2F center, D2D1_MATRIX_3X2_F *matrix );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1.h", MSDNShortId = "9f29488c-37f0-4d53-9e3b-3b27e841c8b4")]
	public static extern void D2D1MakeSkewMatrix(float angleX, float angleY, D2D_POINT_2F center, out D2D_MATRIX_3X2_F matrix);

	/// <summary>Returns the sine and cosine of an angle.</summary>
	/// <param name="angle">
	/// <para>Type: <c>FLOAT</c></para>
	/// <para>The angle to calculate.</para>
	/// </param>
	/// <param name="s">
	/// <para>Type: <c>FLOAT*</c></para>
	/// <para>The sine of the angle.</para>
	/// </param>
	/// <param name="c">
	/// <para>Type: <c>FLOAT*</c></para>
	/// <para>The cosine of the angle.</para>
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-d2d1sincos void D2D1SinCos( FLOAT angle, FLOAT *s, FLOAT *c );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1_1.h", MSDNShortId = "CE5899A8-B70F-492E-9A16-849FB64830AC")]
	public static extern void D2D1SinCos(float angle, out float s, out float c);

	/// <summary>Returns the tangent of an angle.</summary>
	/// <param name="angle">
	/// <para>Type: <c>FLOAT</c></para>
	/// <para>The angle to calculate the tangent for.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>FLOAT</c></para>
	/// <para>The tangent of the angle.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-d2d1tan FLOAT D2D1Tan( FLOAT angle );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1_1.h", MSDNShortId = "2BC66DEA-5C40-4EBA-8CDB-B48036E8A85F")]
	public static extern float D2D1Tan(float angle);

	/// <summary>Returns the length of a 3 dimensional vector.</summary>
	/// <param name="x">
	/// <para>Type: <c>FLOAT</c></para>
	/// <para>The x value of the vector.</para>
	/// </param>
	/// <param name="y">
	/// <para>Type: <c>FLOAT</c></para>
	/// <para>The y value of the vector.</para>
	/// </param>
	/// <param name="z">
	/// <para>Type: <c>FLOAT</c></para>
	/// <para>The z value of the vector.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>FLOAT</c></para>
	/// <para>The length of the vector.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-d2d1vec3length FLOAT D2D1Vec3Length( FLOAT x, FLOAT y, FLOAT
	// z );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1_1.h", MSDNShortId = "0E305151-63EA-4865-B9C4-5F685D17FD5A")]
	public static extern float D2D1Vec3Length(float x, float y, float z);

	/// <summary>Represents a 3-by-2 matrix.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_matrix_3x2_f typedef struct D2D_MATRIX_3X2_F { union {
	// struct { FLOAT m11; FLOAT m12; FLOAT m21; FLOAT m22; FLOAT dx; FLOAT dy; }; struct { FLOAT _11; FLOAT _12; FLOAT _21; FLOAT _22;
	// FLOAT _31; FLOAT _32; }; FLOAT m[3][2]; }; } D2D_MATRIX_3X2_F;
	[PInvokeData("dcommon.h", MSDNShortId = "c8a54bad-4376-479b-8529-1e407623e473")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_MATRIX_3X2_F
	{
		/// <summary>Horizontal scaling / cosine of rotation</summary>
		public float m11;

		/// <summary>Vertical shear / sine of rotation</summary>
		public float m12;

		/// <summary>Horizontal shear / negative sine of rotation</summary>
		public float m21;

		/// <summary>Vertical scaling / cosine of rotation</summary>
		public float m22;

		/// <summary>Horizontal shift (always orthogonal regardless of rotation)</summary>
		public float dx;

		/// <summary>Vertical shift (always orthogonal regardless of rotation)</summary>
		public float dy;

#pragma warning disable IDE1006 // Naming Styles

		/// <summary>Gets or sets the values as a multidimensional (3x2) array.</summary>
		/// <value>The array value.</value>
		/// <exception cref="ArgumentOutOfRangeException">m - Value must a 3x2 array.</exception>
		public float[,] m
		{
			get => new[,] { { m11, m12 }, { m21, m22 }, { dx, dy } };
			set
			{
				if (value.GetLength(0) != 3 || value.GetLength(1) != 2)
					throw new ArgumentOutOfRangeException(nameof(m), "Value must a 3x2 array.");
				m11 = value[0, 0];
				m12 = value[0, 1];
				m21 = value[1, 0];
				m22 = value[1, 1];
				dx = value[2, 0];
				dy = value[2, 1];
			}
		}

#pragma warning restore IDE1006 // Naming Styles
	}

	/// <summary>Represents an x-coordinate and y-coordinate pair, expressed as floating-point values, in two-dimensional space.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_point_2f typedef struct D2D_POINT_2F { FLOAT x; FLOAT
	// y; } D2D_POINT_2F;
	[PInvokeData("dcommon.h", MSDNShortId = "2ee55d63-594b-482d-9e31-2378369c6c30")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_POINT_2F
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The x-coordinate of the point.</para>
		/// </summary>
		public float x;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate of the point.</para>
		/// </summary>
		public float y;
	}

	/// <summary>
	/// Represents a rectangle defined by the coordinates of the upper-left corner (left, top) and the coordinates of the lower-right
	/// corner (right, bottom).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_rect_f typedef struct D2D_RECT_F { FLOAT left; FLOAT
	// top; FLOAT right; FLOAT bottom; } D2D_RECT_F;
	[PInvokeData("dcommon.h", MSDNShortId = "84bd7ab0-f273-46f8-b261-86cd1d7f3868")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_RECT_F
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The x-coordinate of the upper-left corner of the rectangle.</para>
		/// </summary>
		public float left;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate of the upper-left corner of the rectangle.</para>
		/// </summary>
		public float top;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The x-coordinate of the lower-right corner of the rectangle.</para>
		/// </summary>
		public float right;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate of the lower-right corner of the rectangle.</para>
		/// </summary>
		public float bottom;
	}

	/// <summary>Stores an ordered pair of floating-point values, typically the width and height of a rectangle.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_size_f typedef struct D2D_SIZE_F { FLOAT width; FLOAT
	// height; } D2D_SIZE_F;
	[PInvokeData("dcommon.h", MSDNShortId = "9d519bb9-3eb8-4d7e-ba00-b6cf5a428a04")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_SIZE_F
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The horizontal component of this size.</para>
		/// </summary>
		public float width;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The vertical component of this size.</para>
		/// </summary>
		public float height;
	}

	/// <summary>Stores an ordered pair of integers, typically the width and height of a rectangle.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d_size_u typedef struct D2D_SIZE_U { UINT32 width; UINT32
	// height; } D2D_SIZE_U;
	[PInvokeData("dcommon.h", MSDNShortId = "d9ea9df5-7c5f-4afa-9859-14d77b017904")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D_SIZE_U
	{
		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The horizontal component of this size.</para>
		/// </summary>
		public uint width;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The vertical component of this size.</para>
		/// </summary>
		public uint height;
	}

	/// <summary>Describes an elliptical arc between two points.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_arc_segment typedef struct D2D1_ARC_SEGMENT { D2D1_POINT_2F
	// point; D2D1_SIZE_F size; FLOAT rotationAngle; D2D1_SWEEP_DIRECTION sweepDirection; D2D1_ARC_SIZE arcSize; } D2D1_ARC_SEGMENT;
	[PInvokeData("d2d1.h", MSDNShortId = "3f391265-20b4-4897-aa0b-d14b71cd5f0a")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_ARC_SEGMENT
	{
		/// <summary>
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The end point of the arc.</para>
		/// </summary>
		public D2D_POINT_2F point;

		/// <summary>
		/// <para>Type: <c>D2D1_SIZE_F</c></para>
		/// <para>The x-radius and y-radius of the arc.</para>
		/// </summary>
		public D2D_SIZE_F size;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// A value that specifies how many degrees in the clockwise direction the ellipse is rotated relative to the current coordinate system.
		/// </para>
		/// </summary>
		public float rotationAngle;

		/// <summary>
		/// <para>Type: <c>D2D1_SWEEP_DIRECTION</c></para>
		/// <para>A value that specifies whether the arc sweep is clockwise or counterclockwise.</para>
		/// </summary>
		public D2D1_SWEEP_DIRECTION sweepDirection;

		/// <summary>
		/// <para>Type: <c>D2D1_ARC_SIZE</c></para>
		/// <para>A value that specifies whether the given arc is larger than 180 degrees.</para>
		/// </summary>
		public D2D1_ARC_SIZE arcSize;
	}

	/// <summary>Represents a cubic bezier segment drawn between two points.</summary>
	/// <remarks>
	/// <para>
	/// A cubic Bezier curve is defined by four points: a start point, an end point (point3), and two control points (point1 and
	/// point2). A Bezier segment does not contain a property for the starting point of the curve; it defines only the end point. The
	/// beginning point of the curve is the current point of the path to which the Bezier curve is added.
	/// </para>
	/// <para>
	/// The two control points of a cubic Bezier curve behave like magnets, attracting portions of what would otherwise be a straight
	/// line toward themselves and producing a curve. The first control point, point1, affects the beginning portion of the curve; the
	/// second control point, point2, affects the ending portion of the curve.
	/// </para>
	/// <para>
	/// <c>Note</c> The curve doesn't necessarily pass through either of the control points; each control point moves its portion of the
	/// line toward itself, but not through itself.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_bezier_segment typedef struct D2D1_BEZIER_SEGMENT {
	// D2D1_POINT_2F point1; D2D1_POINT_2F point2; D2D1_POINT_2F point3; } D2D1_BEZIER_SEGMENT;
	[PInvokeData("d2d1.h", MSDNShortId = "cf8df7d2-c4fe-4a46-a4b2-7e0eed67df2a")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_BEZIER_SEGMENT
	{
		/// <summary>
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The first control point for the Bezier segment.</para>
		/// </summary>
		public D2D_POINT_2F point1;

		/// <summary>
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The second control point for the Bezier segment.</para>
		/// </summary>
		public D2D_POINT_2F point2;

		/// <summary>
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The end point for the Bezier segment.</para>
		/// </summary>
		public D2D_POINT_2F point3;
	}

	/// <summary>Describes the extend modes and the interpolation mode of an ID2D1BitmapBrush.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_bitmap_brush_properties typedef struct
	// D2D1_BITMAP_BRUSH_PROPERTIES { D2D1_EXTEND_MODE extendModeX; D2D1_EXTEND_MODE extendModeY; D2D1_BITMAP_INTERPOLATION_MODE
	// interpolationMode; } D2D1_BITMAP_BRUSH_PROPERTIES;
	[PInvokeData("d2d1.h", MSDNShortId = "e252d1b4-2f34-4479-94fc-636d4115b00c")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_BITMAP_BRUSH_PROPERTIES
	{
		/// <summary>
		/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
		/// <para>A value that describes how the brush horizontally tiles those areas that extend past its bitmap.</para>
		/// </summary>
		public D2D1_EXTEND_MODE extendModeX;

		/// <summary>
		/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
		/// <para>A value that describes how the brush vertically tiles those areas that extend past its bitmap.</para>
		/// </summary>
		public D2D1_EXTEND_MODE extendModeY;

		/// <summary>
		/// <para>Type: <c>D2D1_BITMAP_INTERPOLATION_MODE</c></para>
		/// <para>A value that specifies how the bitmap is interpolated when it is scaled or rotated.</para>
		/// </summary>
		public D2D1_BITMAP_INTERPOLATION_MODE interpolationMode;
	}

	/// <summary>Describes the pixel format and dpi of a bitmap.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_bitmap_properties typedef struct D2D1_BITMAP_PROPERTIES {
	// D2D1_PIXEL_FORMAT pixelFormat; FLOAT dpiX; FLOAT dpiY; } D2D1_BITMAP_PROPERTIES;
	[PInvokeData("d2d1.h", MSDNShortId = "050246fd-f91a-4a2a-858a-5f0447e3ecbf")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_BITMAP_PROPERTIES
	{
		/// <summary>
		/// <para>Type: <c>D2D1_PIXEL_FORMAT</c></para>
		/// <para>The bitmap's pixel format and alpha mode.</para>
		/// </summary>
		public D2D1_PIXEL_FORMAT pixelFormat;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The horizontal dpi of the bitmap.</para>
		/// </summary>
		public float dpiX;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The vertical dpi of the bitmap.</para>
		/// </summary>
		public float dpiY;
	}

	/// <summary>Describes the opacity and transformation of a brush.</summary>
	/// <remarks>
	/// <para>
	/// This structure is used when creating a brush. For convenience, Direct2D provides the D2D1::BrushProperties function for creating
	/// <c>D2D1_BRUSH_PROPERTIES</c> structures.
	/// </para>
	/// <para>After creating a brush, you can change its opacity or transform by calling the SetOpacity or SetTransform methods.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_brush_properties typedef struct D2D1_BRUSH_PROPERTIES {
	// FLOAT opacity; D2D1_MATRIX_3X2_F transform; } D2D1_BRUSH_PROPERTIES;
	[PInvokeData("d2d1.h", MSDNShortId = "37b2fc18-a320-41c0-8717-dcd561a2f2df")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_BRUSH_PROPERTIES
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value between 0.0f and 1.0f, inclusive, that specifies the degree of opacity of the brush.</para>
		/// </summary>
		public float opacity;

		/// <summary>
		/// <para>Type: <c>D2D1_MATRIX_3X2_F</c></para>
		/// <para>The transformation that is applied to the brush.</para>
		/// </summary>
		public D2D_MATRIX_3X2_F transform;
	}

	/// <summary>Describes the drawing state of a render target.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_drawing_state_description typedef struct
	// D2D1_DRAWING_STATE_DESCRIPTION { D2D1_ANTIALIAS_MODE antialiasMode; D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode; ulong tag1; ulong
	// tag2; D2D1_MATRIX_3X2_F transform; } D2D1_DRAWING_STATE_DESCRIPTION;
	[PInvokeData("d2d1.h", MSDNShortId = "ba4adc4b-4d86-40c4-8911-1c800d3c6f3e")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_DRAWING_STATE_DESCRIPTION
	{
		/// <summary>
		/// <para>Type: <c>D2D1_ANTIALIAS_MODE</c></para>
		/// <para>The antialiasing mode for subsequent nontext drawing operations.</para>
		/// </summary>
		public D2D1_ANTIALIAS_MODE antialiasMode;

		/// <summary>
		/// <para>Type: <c>D2D1_TEXT_ANTIALIAS_MODE</c></para>
		/// <para>The antialiasing mode for subsequent text and glyph drawing operations.</para>
		/// </summary>
		public D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode;

		/// <summary>
		/// <para>Type: <c>ulong</c></para>
		/// <para>A label for subsequent drawing operations.</para>
		/// </summary>
		public ulong tag1;

		/// <summary>
		/// <para>Type: <c>ulong</c></para>
		/// <para>A label for subsequent drawing operations.</para>
		/// </summary>
		public ulong tag2;

		/// <summary>
		/// <para>Type: <c>D2D1_MATRIX_3X2_F</c></para>
		/// <para>The transformation to apply to subsequent drawing operations.</para>
		/// </summary>
		public D2D_MATRIX_3X2_F transform;
	}

	/// <summary>Contains the center point, x-radius, and y-radius of an ellipse.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_ellipse typedef struct D2D1_ELLIPSE { D2D1_POINT_2F point;
	// FLOAT radiusX; FLOAT radiusY; } D2D1_ELLIPSE;
	[PInvokeData("d2d1.h", MSDNShortId = "6fed6c49-ba83-4c2b-af8a-04156ee317f0")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_ELLIPSE
	{
		/// <summary>
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The center point of the ellipse.</para>
		/// </summary>
		public D2D_POINT_2F point;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The X-radius of the ellipse.</para>
		/// </summary>
		public float radiusX;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The Y-radius of the ellipse.</para>
		/// </summary>
		public float radiusY;
	}

	/// <summary>Contains the debugging level of an ID2D1Factory object.</summary>
	/// <remarks>To enable debugging, you must install the Direct2D Debug Layer.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_factory_options typedef struct D2D1_FACTORY_OPTIONS {
	// D2D1_DEBUG_LEVEL debugLevel; } D2D1_FACTORY_OPTIONS;
	[PInvokeData("d2d1.h", MSDNShortId = "2765d34e-978c-4121-82c9-2780d54e2850")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_FACTORY_OPTIONS
	{
		/// <summary>
		/// <para>Type: <c>D2D1_DEBUG_LEVEL</c></para>
		/// <para>The debugging level of the ID2D1Factory object.</para>
		/// </summary>
		public D2D1_DEBUG_LEVEL debugLevel;
	}

	/// <summary>Contains the position and color of a gradient stop.</summary>
	/// <remarks>
	/// <para>
	/// Gradient stops can be specified in any order if they are at different positions. Two stops may share a position. In this case,
	/// the first stop specified is treated as the "low" stop (nearer 0.0f) and subsequent stops are treated as "higher" (nearer 1.0f).
	/// This behavior is useful if a caller wants an instant transition in the middle of a stop.
	/// </para>
	/// <para>
	/// Typically, there are at least two points in a collection, although creation with only one stop is permitted. For example, one
	/// point is at position 0.0f, another point is at position 1.0f, and additional points are distributed in the [0, 1] range. Where
	/// the gradient progression is beyond the range of [0, 1], the stops are stored, but may affect the gradient.
	/// </para>
	/// <para>
	/// When drawn, the [0, 1] range of positions is mapped to the brush, in a brush-dependent way. For details, see
	/// ID2D1LinearGradientBrush and ID2D1RadialGradientBrush.
	/// </para>
	/// <para>
	/// Gradient stops with a position outside the [0, 1] range cannot be seen explicitly, but they can still affect the colors produced
	/// in the [0, 1] range. For example, a two-stop gradient {{0.0f, Black}, {2.0f, White}} is indistinguishable visually from {{0.0f,
	/// Black}, {1.0f, Mid-level gray}}. Also, the colors are clamped before interpolation.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_gradient_stop typedef struct D2D1_GRADIENT_STOP { FLOAT
	// position; D2D1_COLOR_F color; } D2D1_GRADIENT_STOP;
	[PInvokeData("d2d1.h", MSDNShortId = "f6798542-382a-4074-bbe1-707bc00b3575")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_GRADIENT_STOP
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// A value that indicates the relative position of the gradient stop in the brush. This value must be in the [0.0f, 1.0f] range
		/// if the gradient stop is to be seen explicitly.
		/// </para>
		/// </summary>
		public float position;

		/// <summary>
		/// <para>Type: <c>D2D1_COLOR_F</c></para>
		/// <para>The color of the gradient stop.</para>
		/// </summary>
		public D3DCOLORVALUE color;
	}

	/// <summary>Contains the HWND, pixel size, and presentation options for an ID2D1HwndRenderTarget.</summary>
	/// <remarks>
	/// <para>Use this structure when you call the CreateHwndRenderTarget method to create a new ID2D1HwndRenderTarget.</para>
	/// <para>
	/// For convenience, Direct2D provides the D2D1::HwndRenderTargetProperties function for creating new
	/// <c>D2D1_HWND_RENDER_TARGET_PROPERTIES</c> structures.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_hwnd_render_target_properties typedef struct
	// D2D1_HWND_RENDER_TARGET_PROPERTIES { HWND hwnd; D2D1_SIZE_U pixelSize; D2D1_PRESENT_OPTIONS presentOptions; } D2D1_HWND_RENDER_TARGET_PROPERTIES;
	[PInvokeData("d2d1.h", MSDNShortId = "4300843a-a24f-4f9e-a396-67172f083638")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_HWND_RENDER_TARGET_PROPERTIES
	{
		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>The HWND to which the render target issues the output from its drawing commands.</para>
		/// </summary>
		public HWND hwnd;

		/// <summary>
		/// <para>Type: <c>D2D1_SIZE_U</c></para>
		/// <para>The size of the render target, in pixels.</para>
		/// </summary>
		public D2D_SIZE_U pixelSize;

		/// <summary>
		/// <para>Type: <c>D2D1_PRESENT_OPTIONS</c></para>
		/// <para>
		/// A value that specifies whether the render target retains the frame after it is presented and whether the render target waits
		/// for the device to refresh before presenting.
		/// </para>
		/// </summary>
		public D2D1_PRESENT_OPTIONS presentOptions;
	}

	/// <summary>Contains the content bounds, mask information, opacity settings, and other options for a layer resource.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_layer_parameters typedef struct D2D1_LAYER_PARAMETERS {
	// D2D1_RECT_F contentBounds; ID2D1Geometry *geometricMask; D2D1_ANTIALIAS_MODE maskAntialiasMode; D2D1_MATRIX_3X2_F maskTransform;
	// FLOAT opacity; ID2D1Brush *opacityBrush; D2D1_LAYER_OPTIONS layerOptions; } D2D1_LAYER_PARAMETERS;
	[PInvokeData("d2d1.h", MSDNShortId = "ce575df6-9464-4672-9a0e-ff7e016d9354")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_LAYER_PARAMETERS
	{
		/// <summary>
		/// <para>Type: <c>D2D1_RECT_F</c></para>
		/// <para>The content bounds of the layer. Content outside these bounds is not guaranteed to render.</para>
		/// </summary>
		public D2D_RECT_F contentBounds;

		/// <summary>
		/// <para>Type: <c>ID2D1Geometry*</c></para>
		/// <para>The geometric mask specifies the area of the layer that is composited into the render target.</para>
		/// </summary>
		public IntPtr geometricMask;

		/// <summary>
		/// <para>Type: <c>D2D1_ANTIALIAS_MODE</c></para>
		/// <para>A value that specifies the antialiasing mode for the geometricMask.</para>
		/// </summary>
		public D2D1_ANTIALIAS_MODE maskAntialiasMode;

		/// <summary>
		/// <para>Type: <c>D2D1_MATRIX_3X2_F</c></para>
		/// <para>A value that specifies the transform that is applied to the geometric mask when composing the layer.</para>
		/// </summary>
		public D2D_MATRIX_3X2_F maskTransform;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>An opacity value that is applied uniformly to all resources in the layer when compositing to the target.</para>
		/// </summary>
		public float opacity;

		/// <summary>
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>
		/// A brush that is used to modify the opacity of the layer. The brush is mapped to the layer, and the alpha channel of each
		/// mapped brush pixel is multiplied against the corresponding layer pixel.
		/// </para>
		/// </summary>
		public IntPtr opacityBrush;

		/// <summary>
		/// <para>Type: <c>D2D1_LAYER_OPTIONS</c></para>
		/// <para>A value that specifies whether the layer intends to render text with ClearType antialiasing.</para>
		/// </summary>
		public D2D1_LAYER_OPTIONS layerOptions;
	}

	/// <summary>Contains the starting point and endpoint of the gradient axis for an ID2D1LinearGradientBrush.</summary>
	/// <remarks>
	/// <para>
	/// Use this method when creating new ID2D1LinearGradientBrush objects with the CreateLinearGradientBrush method. For convenience,
	/// Direct2D provides the D2D1::LinearGradientBrushProperties helper function for creating new
	/// <c>D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES</c> structures.
	/// </para>
	/// <para>
	/// The following illustration shows how a linear gradient changes as you change its start and end points. For the first gradient,
	/// the start point is set to (0,0) and the end point to (150, 50); this creates a diagonal gradient that starts at the upper-left
	/// corner and extends to the lower-right corner of the area being painted. When you set the start point to (0, 25) and the end
	/// point to (150, 25), a horizontal gradient is created. Similarly, setting the start point to (75, 0) and the end point to (75,
	/// 50) creates a vertical gradient. Setting the start point to (0, 50) and the end point to (150, 0) creates a diagonal gradient
	/// that starts at the lower-left corner and extends to the upper-right corner of the area being painted.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_linear_gradient_brush_properties typedef struct
	// D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES { D2D1_POINT_2F startPoint; D2D1_POINT_2F endPoint; } D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES;
	[PInvokeData("d2d1.h", MSDNShortId = "753278f0-d8a1-4dc5-b976-a00f8aab357e")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES
	{
		/// <summary>
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>In the brush's coordinate space, the starting point of the gradient axis.</para>
		/// </summary>
		public D2D_POINT_2F startPoint;

		/// <summary>
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>In the brush's coordinate space, the endpoint of the gradient axis.</para>
		/// </summary>
		public D2D_POINT_2F endPoint;
	}

	/// <summary>Contains the data format and alpha mode for a bitmap or render target.</summary>
	/// <remarks>
	/// <para>
	/// For more information about the pixel formats and alpha modes supported by each render target, see Supported Pixel Formats and
	/// Alpha Modes.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example creates a <c>D2D1_PIXEL_FORMAT</c> structure and uses it to specify the pixel format and alpha mode of an ID2D1HwndRenderTarget.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ns-dcommon-d2d1_pixel_format typedef struct D2D1_PIXEL_FORMAT {
	// DXGI_FORMAT format; D2D1_ALPHA_MODE alphaMode; } D2D1_PIXEL_FORMAT;
	[PInvokeData("dcommon.h", MSDNShortId = "e95afd9c-5793-4cb7-bcb8-aae4d28b6532")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_PIXEL_FORMAT
	{
		/// <summary>
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>A value that specifies the size and arrangement of channels in each pixel.</para>
		/// </summary>
		public DXGI_FORMAT format;

		/// <summary>
		/// <para>Type: <c>D2D1_ALPHA_MODE</c></para>
		/// <para>
		/// A value that specifies whether the alpha channel is using pre-multiplied alpha, straight alpha, whether it should be ignored
		/// and considered opaque, or whether it is unkown.
		/// </para>
		/// </summary>
		public D2D1_ALPHA_MODE alphaMode;
	}

	/// <summary>The creation properties for a ID2D1PrintControl object.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ns-d2d1_1-d2d1_print_control_properties typedef struct
	// D2D1_PRINT_CONTROL_PROPERTIES { D2D1_PRINT_FONT_SUBSET_MODE fontSubset; FLOAT rasterDPI; D2D1_COLOR_SPACE colorSpace; } D2D1_PRINT_CONTROL_PROPERTIES;
	[PInvokeData("d2d1_1.h", MSDNShortId = "5A4D4DDC-4161-44A2-9EB6-E4C14696B810")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_PRINT_CONTROL_PROPERTIES
	{
		/// <summary>
		/// <para>Type: <c>D2D1_PRINT_FONT_SUBSET_MODE</c></para>
		/// <para>The mode to use for subsetting fonts for printing, defaults to D2D1_PRINT_FONT_SUBSET_MODE_DEFAULT.</para>
		/// </summary>
		public D2D1_PRINT_FONT_SUBSET_MODE fontSubset;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>DPI for rasterization of all unsupported Direct2D commands or options, defaults to 150.0.</para>
		/// </summary>
		public float rasterDPI;

		/// <summary>
		/// <para>Type: <c>D2D1_COLOR_SPACE</c></para>
		/// <para>Color space for vector graphics, defaults to D2D1_COLOR_SPACE_SRGB.</para>
		/// </summary>
		public D2D1_COLOR_SPACE colorSpace;
	}

	/// <summary>Contains the control point and end point for a quadratic Bezier segment.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_quadratic_bezier_segment typedef struct
	// D2D1_QUADRATIC_BEZIER_SEGMENT { D2D1_POINT_2F point1; D2D1_POINT_2F point2; } D2D1_QUADRATIC_BEZIER_SEGMENT;
	[PInvokeData("d2d1.h", MSDNShortId = "5060cb17-b6f4-4796-b91d-602fd81591c2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_QUADRATIC_BEZIER_SEGMENT
	{
		/// <summary>
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The control point of the quadratic Bezier segment.</para>
		/// </summary>
		public D2D_POINT_2F point1;

		/// <summary>
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The end point of the quadratic Bezier segment.</para>
		/// </summary>
		public D2D_POINT_2F point2;
	}

	/// <summary>Contains the gradient origin offset and the size and position of the gradient ellipse for an ID2D1RadialGradientBrush.</summary>
	/// <remarks>
	/// <para>
	/// Different values for center, gradientOriginOffset, radiusX and/or radiusY produce different gradients. The following
	/// illustration shows several radial gradients that have different gradient origin offsets, creating the appearance of the light
	/// illuminating the circles from different angles.
	/// </para>
	/// <para>
	/// For convenience, Direct2D provides the D2D1::RadialGradientBrushProperties function for creating new
	/// <c>D2D1_RADIAL_GRADIENT_BRUSH</c> structures.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_radial_gradient_brush_properties typedef struct
	// D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES { D2D1_POINT_2F center; D2D1_POINT_2F gradientOriginOffset; FLOAT radiusX; FLOAT radiusY; } D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES;
	[PInvokeData("d2d1.h", MSDNShortId = "194f7624-ac3b-4054-8d6f-5b4c99ef6546")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES
	{
		/// <summary>
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>In the brush's coordinate space, the center of the gradient ellipse.</para>
		/// </summary>
		public D2D_POINT_2F center;

		/// <summary>
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>In the brush's coordinate space, the offset of the gradient origin relative to the gradient ellipse's center.</para>
		/// </summary>
		public D2D_POINT_2F gradientOriginOffset;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>In the brush's coordinate space, the x-radius of the gradient ellipse.</para>
		/// </summary>
		public float radiusX;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>In the brush's coordinate space, the y-radius of the gradient ellipse.</para>
		/// </summary>
		public float radiusY;
	}

	/// <summary>
	/// Contains rendering options (hardware or software), pixel format, DPI information, remoting options, and Direct3D support
	/// requirements for a render target.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Use this structure when creating a render target, or use it with the ID2D1RenderTarget::IsSupported method to check the
	/// properties supported by an existing render target.
	/// </para>
	/// <para>
	/// As a convenience, Direct2D provides the D2D1::RenderTargetProperties helper function for creating
	/// <c>D2D1_RENDER_TARGET_PROPERTIES</c> structures. An easy way to create a <c>D2D1_RENDER_TARGET_PROPERTIES</c> structure that
	/// works for most render targets is to call the function without specifying any parameters. Doing so creates a
	/// <c>D2D1_RENDER_TARGET_PROPERTIES</c> structure that has its fields set to default values. For more information, see D2D1::RenderTargetProperties.
	/// </para>
	/// <para>Not all render targets support hardware rendering. For a list, see the Render Targets Overview.</para>
	/// <para>Using Default DPI Settings</para>
	/// <para>To use the default DPI, set dpiX and dpiY to 0. The default DPI varies depending on the render target:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>For a compatible render target, the default DPI is the DPI of the parent render target.</term>
	/// </item>
	/// <item>
	/// <term>For a ID2D1HwndRenderTarget, the default DPI is the system DPI obtained from the render target's ID2D1Factory.</term>
	/// </item>
	/// <item>
	/// <term>For other render targets, the default DPI is 96.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To use the default DPI setting, both dpiX and dpiY must be set to 0. Setting only one value to 0 causes an E_INVALIDARG error
	/// when attempting to create a render target.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_render_target_properties typedef struct
	// D2D1_RENDER_TARGET_PROPERTIES { D2D1_RENDER_TARGET_TYPE type; D2D1_PIXEL_FORMAT pixelFormat; FLOAT dpiX; FLOAT dpiY;
	// D2D1_RENDER_TARGET_USAGE usage; D2D1_FEATURE_LEVEL minLevel; } D2D1_RENDER_TARGET_PROPERTIES;
	[PInvokeData("d2d1.h", MSDNShortId = "360900bd-1353-4a92-865c-ad34d5e98123")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_RENDER_TARGET_PROPERTIES
	{
		/// <summary>
		/// <para>Type: <c>D2D1_RENDER_TARGET_TYPE</c></para>
		/// <para>
		/// A value that specifies whether the render target should force hardware or software rendering. A value of
		/// D2D1_RENDER_TARGET_TYPE_DEFAULT specifies that the render target should use hardware rendering if it is available;
		/// otherwise, it uses software rendering. Note that WIC bitmap render targets do not support hardware rendering.
		/// </para>
		/// </summary>
		public D2D1_RENDER_TARGET_TYPE type;

		/// <summary>
		/// <para>Type: <c>D2D1_PIXEL_FORMAT</c></para>
		/// <para>
		/// The pixel format and alpha mode of the render target. You can use the D2D1::PixelFormat function to create a pixel format
		/// that specifies that Direct2D should select the pixel format and alpha mode for you. For a list of pixel formats and alpha
		/// modes supported by each render target, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </summary>
		public D2D1_PIXEL_FORMAT pixelFormat;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The horizontal DPI of the render target. To use the default DPI, set dpiX and dpiY to 0. For more information, see the
		/// Remarks section.
		/// </para>
		/// </summary>
		public float dpiX;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The vertical DPI of the render target. To use the default DPI, set dpiX and dpiY to 0. For more information, see the Remarks section.
		/// </para>
		/// </summary>
		public float dpiY;

		/// <summary>
		/// <para>Type: <c>D2D1_RENDER_TARGET_USAGE</c></para>
		/// <para>
		/// A value that specifies how the render target is remoted and whether it should be GDI-compatible. Set to
		/// D2D1_RENDER_TARGET_USAGE_NONE to create a render target that is not compatible with GDI and uses Direct3D command-stream
		/// remoting if it is available.
		/// </para>
		/// </summary>
		public D2D1_RENDER_TARGET_USAGE usage;

		/// <summary>
		/// <para>Type: <c>D2D1_FEATURE_LEVEL</c></para>
		/// <para>
		/// A value that specifies the minimum Direct3D feature level required for hardware rendering. If the specified minimum level is
		/// not available, the render target uses software rendering if the <c>type</c> member is set to
		/// D2D1_RENDER_TARGET_TYPE_DEFAULT; if <c>type</c> is set to to <c>D2D1_RENDER_TARGET_TYPE_HARDWARE</c>, render target creation
		/// fails. A value of D2D1_FEATURE_LEVEL_DEFAULT indicates that Direct2D should determine whether the Direct3D feature level of
		/// the device is adequate. This field is used only when creating ID2D1HwndRenderTarget and ID2D1DCRenderTarget objects.
		/// </para>
		/// </summary>
		public D2D1_FEATURE_LEVEL minLevel;
	}

	/// <summary>Contains the dimensions and corner radii of a rounded rectangle.</summary>
	/// <remarks>
	/// <para>
	/// Each corner of the rectangle specified by the rect is replaced with a quarter ellipse, with a radius in each direction specified
	/// by radiusX and radiusY.
	/// </para>
	/// <para>
	/// If the radiusX is greater than or equal to half the width of the rectangle, and the radiusY is greater than or equal to one-half
	/// the height, the rounded rectangle is an ellipse with the same width and height of the rect.
	/// </para>
	/// <para>
	/// Even when both radiuX and radiusY are zero, the rounded rectangle is different from a rectangle., When stroked, the corners of
	/// the rounded rectangle are roundly joined, not mitered (square).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_rounded_rect typedef struct D2D1_ROUNDED_RECT { D2D1_RECT_F
	// rect; FLOAT radiusX; FLOAT radiusY; } D2D1_ROUNDED_RECT;
	[PInvokeData("d2d1.h", MSDNShortId = "7069ca65-170e-42fc-8c1a-849a2f25c36f")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_ROUNDED_RECT
	{
		/// <summary>
		/// <para>Type: <c>D2D1_RECT_F</c></para>
		/// <para>The coordinates of the rectangle.</para>
		/// </summary>
		public D2D_RECT_F rect;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The x-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.</para>
		/// </summary>
		public float radiusX;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.</para>
		/// </summary>
		public float radiusY;
	}

	/// <summary>Describes the stroke that outlines a shape.</summary>
	/// <remarks>The following illustration shows different dashOffset values for the same custom dash style.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_stroke_style_properties typedef struct
	// D2D1_STROKE_STYLE_PROPERTIES { D2D1_CAP_STYLE startCap; D2D1_CAP_STYLE endCap; D2D1_CAP_STYLE dashCap; D2D1_LINE_JOIN lineJoin;
	// FLOAT miterLimit; D2D1_DASH_STYLE dashStyle; FLOAT dashOffset; } D2D1_STROKE_STYLE_PROPERTIES;
	[PInvokeData("d2d1.h", MSDNShortId = "67f3701f-febd-4afe-803e-c5d9dbcd1b21")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_STROKE_STYLE_PROPERTIES
	{
		/// <summary>
		/// <para>Type: <c>D2D1_CAP_STYLE</c></para>
		/// <para>The cap applied to the start of all the open figures in a stroked geometry.</para>
		/// </summary>
		public D2D1_CAP_STYLE startCap;

		/// <summary>
		/// <para>Type: <c>D2D1_CAP_STYLE</c></para>
		/// <para>The cap applied to the end of all the open figures in a stroked geometry.</para>
		/// </summary>
		public D2D1_CAP_STYLE endCap;

		/// <summary>
		/// <para>Type: <c>D2D1_CAP_STYLE</c></para>
		/// <para>The shape at either end of each dash segment.</para>
		/// </summary>
		public D2D1_CAP_STYLE dashCap;

		/// <summary>
		/// <para>Type: <c>D2D1_LINE_JOIN</c></para>
		/// <para>
		/// A value that describes how segments are joined. This value is ignored for a vertex if the segment flags specify that the
		/// segment should have a smooth join.
		/// </para>
		/// </summary>
		public D2D1_LINE_JOIN lineJoin;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The limit of the thickness of the join on a mitered corner. This value is always treated as though it is greater than or
		/// equal to 1.0f.
		/// </para>
		/// </summary>
		public float miterLimit;

		/// <summary>
		/// <para>Type: <c>D2D1_DASH_STYLE</c></para>
		/// <para>A value that specifies whether the stroke has a dash pattern and, if so, the dash style.</para>
		/// </summary>
		public D2D1_DASH_STYLE dashStyle;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// A value that specifies an offset in the dash sequence. A positive dash offset value shifts the dash pattern, in units of
		/// stroke width, toward the start of the stroked geometry. A negative dash offset value shifts the dash pattern, in units of
		/// stroke width, toward the end of the stroked geometry.
		/// </para>
		/// </summary>
		public float dashOffset;
	}

	/// <summary>Contains the three vertices that describe a triangle.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_triangle typedef struct D2D1_TRIANGLE { D2D1_POINT_2F
	// point1; D2D1_POINT_2F point2; D2D1_POINT_2F point3; } D2D1_TRIANGLE;
	[PInvokeData("d2d1.h", MSDNShortId = "6978bfff-05ca-44b6-8694-c4741f7987f6")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_TRIANGLE
	{
		/// <summary>
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The first vertex of a triangle.</para>
		/// </summary>
		public D2D_POINT_2F point1;

		/// <summary>
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The second vertex of a triangle.</para>
		/// </summary>
		public D2D_POINT_2F point2;

		/// <summary>
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The third vertex of a triangle.</para>
		/// </summary>
		public D2D_POINT_2F point3;
	}

	/// <summary>Describes color values.</summary>
	/// <remarks>
	/// You can set the members of this structure to values outside the range of 0 through 1 to implement some unusual effects. Values
	/// greater than 1 produce strong lights that tend to wash out a scene. Negative values produce dark lights that actually remove
	/// light from a scene.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/direct3d9/d3dcolorvalue typedef struct _D3DCOLORVALUE { float r; float g; float b;
	// float a; } D3DCOLORVALUE;
	[PInvokeData("", MSDNShortId = "6af8c2ec-bc79-4dc6-b56d-7a7676a50b39")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3DCOLORVALUE
	{
		/// <summary>Type: <c>float</c></summary>
		public float r;

		/// <summary>Type: <c>float</c></summary>
		public float g;

		/// <summary>Type: <c>float</c></summary>
		public float b;

		/// <summary>Type: <c>float</c></summary>
		public float a;
	}

	/// <summary>
	/// Contains the information needed by renderers to draw glyph runs. All coordinates are in device independent pixels (DIPs).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_glyph_run struct DWRITE_GLYPH_RUN { IDWriteFontFace
	// *fontFace; FLOAT fontEmSize; UINT32 glyphCount; UINT16 const *glyphIndices; FLOAT const *glyphAdvances; DWRITE_GLYPH_OFFSET const
	// *glyphOffsets; BOOL isSideways; UINT32 bidiLevel; };
	[PInvokeData("dwrite.h", MSDNShortId = "2997d63f-8d33-44c3-9617-cfffe5f61f7d")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_GLYPH_RUN
	{
		/// <summary>
		/// <para>Type: <c>IDWriteFontFace*</c></para>
		/// <para>The physical font face object to draw with.</para>
		/// </summary>
		public IntPtr fontFace;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIPs (equals 1/96 inch), not points.</para>
		/// </summary>
		public float fontEmSize;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of glyphs in the glyph run.</para>
		/// </summary>
		public uint glyphCount;

		/// <summary>
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>A pointer to an array of indices to render for the glyph run.</para>
		/// </summary>
		public IntPtr glyphIndices;

		/// <summary>
		/// <para>Type: <c>const FLOAT*</c></para>
		/// <para>A pointer to an array containing glyph advance widths for the glyph run.</para>
		/// </summary>
		public IntPtr glyphAdvances;

		/// <summary>
		/// <para>Type: <c>const DWRITE_GLYPH_OFFSET*</c></para>
		/// <para>A pointer to an array containing glyph offsets for the glyph run.</para>
		/// </summary>
		public IntPtr glyphOffsets;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// If true, specifies that glyphs are rotated 90 degrees to the left and vertical metrics are used. Vertical writing is
		/// achieved by specifying <c>isSideways</c> = true and rotating the entire run 90 degrees to the right via a rotate transform.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool isSideways;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The implicit resolved bidi level of the run. Odd levels indicate right-to-left languages like Hebrew and Arabic, while even
		/// levels indicate left-to-right languages like English and Japanese (when written horizontally). For right-to-left languages,
		/// the text origin is on the right, and text should be drawn to the left.
		/// </para>
		/// </summary>
		public uint bidiLevel;
	}

	/// <summary>Describes a JPEG AC huffman table.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-jpeg-ac-huffman-table typedef struct DXGI_JPEG_AC_HUFFMAN_TABLE
	// { BYTE CodeCounts[16]; BYTE CodeValues[162]; } DXGI_JPEG_AC_HUFFMAN_TABLE;
	[PInvokeData("dxgitype.h", MSDNShortId = "E1923FFA-E7E5-4158-9793-3E7F5A6EA7FA")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXGI_JPEG_AC_HUFFMAN_TABLE
	{
		/// <summary>The number of codes for each code length.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] CodeCounts;

		/// <summary>The Huffman code values, in order of increasing code length.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 162)]
		public byte[] CodeValues;
	}

	/// <summary>Describes a JPEG DC huffman table.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-jpeg-dc-huffman-table typedef struct DXGI_JPEG_DC_HUFFMAN_TABLE
	// { BYTE CodeCounts[12]; BYTE CodeValues[12]; } DXGI_JPEG_DC_HUFFMAN_TABLE;
	[PInvokeData("dxgitype.h", MSDNShortId = "9D6C18C3-F75C-41E0-9EFA-E882E89DE713")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXGI_JPEG_DC_HUFFMAN_TABLE
	{
		/// <summary>The number of codes for each code length.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		public byte[] CodeCounts;

		/// <summary>The Huffman code values, in order of increasing code length.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		public byte[] CodeValues;
	}

	/// <summary>Describes a JPEG quantization table.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-jpeg-quantization-table typedef struct
	// DXGI_JPEG_QUANTIZATION_TABLE { BYTE Elements[64]; } DXGI_JPEG_QUANTIZATION_TABLE;
	[PInvokeData("dxgitype.h", MSDNShortId = "DE1AAB15-B0B8-4594-BBCE-5F8EE5CE0AF7")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DXGI_JPEG_QUANTIZATION_TABLE
	{
		/// <summary>An array of bytes containing the elements of the quantization table.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[] Elements;
	}
}