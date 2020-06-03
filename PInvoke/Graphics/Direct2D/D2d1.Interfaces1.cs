using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.Dwrite;
using static Vanara.PInvoke.WindowsCodecs;

namespace Vanara.PInvoke
{
	/// <summary>Items from the D2d1.dll</summary>
	public static partial class D2d1
	{
		/// <summary>Represents a bitmap that has been bound to an ID2D1RenderTarget.</summary>
		/// <remarks>
		/// <para>Creating ID2D1Bitmap Objects</para>
		/// <para>To create a bitmap, use one of the following methods of the render target on which the bitmap will be drawn:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>ID2D1RenderTarget::CreateBitmap</term>
		/// </item>
		/// <item>
		/// <term>ID2D1RenderTarget::CreateBitmapFromWicBitmap</term>
		/// </item>
		/// </list>
		/// <para>For information about the pixel formats supported by Direct2D bitmaps, see Supported Pixel Formats and Alpha Modes.</para>
		/// <para>
		/// An <c>ID2D1Bitmap</c> is a device-dependent resource: your application should create bitmaps after it initializes the render
		/// target with which the bitmap will be used, and recreate the bitmap whenever the render target needs recreated. (For more
		/// information about resources, see Resources Overview.)
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1bitmap
		[PInvokeData("d2d1.h", MSDNShortId = "e58216ea-e6b5-450f-a0ea-b879aa5dff38")]
		[ComImport, Guid("a2296057-ea42-4099-983b-539fb6505426"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ID2D1Bitmap : ID2D1Image
		{
			/// <summary>Retrieves the factory associated with this resource.</summary>
			/// <param name="factory">
			/// <para>Type: <c>ID2D1Factory**</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is
			/// passed uninitialized.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
			// **factory );
			[PreserveSig]
			new void GetFactory(out ID2D1Factory factory);

			/// <summary>Returns the size, in device-independent pixels (DIPs), of the bitmap.</summary>
			/// <returns>
			/// <para>Type: <c>D2D1_SIZE_F</c></para>
			/// <para>The size, in DIPs, of the bitmap.</para>
			/// </returns>
			/// <remarks>A DIP is 1/96 of an inch. To retrieve the size in device pixels, use the ID2D1Bitmap::GetPixelSizemethod.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmap-getsize D2D1_SIZE_F GetSize();
			[PreserveSig]
			D2D_SIZE_F GetSize();

			/// <summary>Returns the size, in device-dependent units (pixels), of the bitmap.</summary>
			/// <returns>
			/// <para>Type: <c>D2D1_SIZE_U</c></para>
			/// <para>The size, in pixels, of the bitmap.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmap-getpixelsize D2D1_SIZE_U GetPixelSize();
			[PreserveSig]
			D2D_SIZE_U GetPixelSize();

			/// <summary>Retrieves the pixel format and alpha mode of the bitmap.</summary>
			/// <returns>
			/// <para>Type: <c>D2D1_PIXEL_FORMAT</c></para>
			/// <para>The pixel format and alpha mode of the bitmap.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmap-getpixelformat D2D1_PIXEL_FORMAT GetPixelFormat();
			[PreserveSig]
			D2D1_PIXEL_FORMAT GetPixelFormat();

			/// <summary>Return the dots per inch (DPI) of the bitmap.</summary>
			/// <param name="dpiX">
			/// <para>Type: <c>FLOAT*</c></para>
			/// <para>The horizontal DPI of the image. You must allocate storage for this parameter.</para>
			/// </param>
			/// <param name="dpiY">
			/// <para>Type: <c>FLOAT*</c></para>
			/// <para>The vertical DPI of the image. You must allocate storage for this parameter.</para>
			/// </param>
			/// <returns>None</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmap-getdpi void GetDpi( FLOAT *dpiX, FLOAT *dpiY );
			[PreserveSig]
			void GetDpi(out float dpiX, out float dpiY);

			/// <summary>Copies the specified region from the specified bitmap into the current bitmap.</summary>
			/// <param name="destPoint">
			/// <para>Type: <c>const D2D1_POINT_2U*</c></para>
			/// <para>In the current bitmap, the upper-left corner of the area to which the region specified by srcRect is copied.</para>
			/// </param>
			/// <param name="bitmap">
			/// <para>Type: <c>ID2D1Bitmap*</c></para>
			/// <para>The bitmap to copy from.</para>
			/// </param>
			/// <param name="srcRect">
			/// <para>Type: <c>const D2D1_RECT_U*</c></para>
			/// <para>The area of bitmap to copy.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method does not update the size of the current bitmap. If the contents of the source bitmap do not fit in the current
			/// bitmap, this method fails. Also, note that this method does not perform format conversion, and will fail if the bitmap
			/// formats do not match.
			/// </para>
			/// <para>
			/// Calling this method may cause the current batch to flush if the bitmap is active in the batch. If the batch that was flushed
			/// does not complete successfully, this method fails. However, this method does not clear the error state of the render target
			/// on which the batch was flushed. The failing HRESULT and tag state will be returned at the next call to EndDraw or Flush.
			/// </para>
			/// <para>
			/// Starting with Windows 8.1, this method supports block compressed bitmaps. If you are using a block compressed format, the
			/// end coordinates of the srcRect parameter must be multiples of 4 or the method returns <c>E_INVALIDARG</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmap-copyfrombitmap HRESULT CopyFromBitmap( const
			// D2D1_POINT_2U *destPoint, ID2D1Bitmap *bitmap, const D2D1_RECT_U *srcRect );
			void CopyFromBitmap([In, Optional] IntPtr destPoint, [In] ID2D1Bitmap bitmap, [In, Optional] IntPtr srcRect);

			/// <summary>Copies the specified region from the specified render target into the current bitmap.</summary>
			/// <param name="destPoint">
			/// <para>Type: <c>const D2D1_POINT_2U*</c></para>
			/// <para>In the current bitmap, the upper-left corner of the area to which the region specified by srcRect is copied.</para>
			/// </param>
			/// <param name="renderTarget">
			/// <para>Type: <c>ID2D1RenderTarget*</c></para>
			/// <para>The render target that contains the region to copy.</para>
			/// </param>
			/// <param name="srcRect">
			/// <para>Type: <c>const D2D1_RECT_U*</c></para>
			/// <para>The area of renderTarget to copy.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method does not update the size of the current bitmap. If the contents of the source bitmap do not fit in the current
			/// bitmap, this method fails. Also, note that this method does not perform format conversion, and will fail if the bitmap
			/// formats do not match.
			/// </para>
			/// <para>
			/// Calling this method may cause the current batch to flush if the bitmap is active in the batch. If the batch that was flushed
			/// does not complete successfully, this method fails. However, this method does not clear the error state of the render target
			/// on which the batch was flushed. The failing HRESULT and tag state will be returned at the next call to EndDraw or Flush.
			/// </para>
			/// <para>
			/// All clips and layers must be popped off of the render target before calling this method. The method returns
			/// D2DERR_RENDER_TARGET_HAS_LAYER_OR_CLIPRECT if any clips or layers are currently applied to the render target.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmap-copyfromrendertarget HRESULT
			// CopyFromRenderTarget( const D2D1_POINT_2U *destPoint, ID2D1RenderTarget *renderTarget, const D2D1_RECT_U *srcRect );
			void CopyFromRenderTarget([In, Optional] IntPtr destPoint, [In] ID2D1RenderTarget renderTarget, [In, Optional] IntPtr srcRect);

			/// <summary>Copies the specified region from memory into the current bitmap.</summary>
			/// <param name="dstRect">
			/// <para>Type: <c>const D2D1_RECT_U*</c></para>
			/// <para>In the current bitmap, the rectangle to which the region specified by srcRect is copied.</para>
			/// </param>
			/// <param name="srcData">
			/// <para>Type: <c>const void*</c></para>
			/// <para>The data to copy.</para>
			/// </param>
			/// <param name="pitch">
			/// <para>Type: <c>UINT32</c></para>
			/// <para>
			/// The stride, or pitch, of the source bitmap stored in srcData. The stride is the byte count of a scanline (one row of pixels
			/// in memory). The stride can be computed from the following formula: pixel width * bytes per pixel + memory padding.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method does not update the size of the current bitmap. If the contents of the source bitmap do not fit in the current
			/// bitmap, this method fails. Also, note that this method does not perform format conversion; the two bitmap formats should match.
			/// </para>
			/// <para>
			/// If this method is passed invalid input (such as an invalid destination rectangle), can produce unpredictable results, such
			/// as a distorted image or device failure.
			/// </para>
			/// <para>
			/// Calling this method may cause the current batch to flush if the bitmap is active in the batch. If the batch that was flushed
			/// does not complete successfully, this method fails. However, this method does not clear the error state of the render target
			/// on which the batch was flushed. The failing HRESULT and tag state will be returned at the next call to EndDraw or Flush.
			/// </para>
			/// <para>
			/// Starting with Windows 8.1, this method supports block compressed bitmaps. If you are using a block compressed format, the
			/// end coordinates of the srcRect parameter must be multiples of 4 or the method returns <c>E_INVALIDARG</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmap-copyfrommemory HRESULT CopyFromMemory( const
			// D2D1_RECT_U *dstRect, const void *srcData, UINT32 pitch );
			void CopyFromMemory([In, Optional] IntPtr dstRect, [In]  IntPtr srcData, uint pitch);
		}

		/// <summary>Paints an area with a bitmap.</summary>
		/// <remarks>
		/// <para>
		/// A bitmap brush is used to fill a geometry with a bitmap. Like all brushes, it defines an infinite plane of content. Because
		/// bitmaps are finite, the brush relies on an "extend mode" to determine how the plane is filled horizontally and vertically.
		/// </para>
		/// <para>Creating ID2D1BitmapBrush Objects</para>
		/// <para>To create a bitmap brush, use the ID2D1RenderTarget::CreateBitmapBrush method.</para>
		/// <para>
		/// An <c>ID2D1BitmapBrush</c> is a device-dependent resource: your application should create bitmap brushes after it initializes
		/// the render target with which the bitmap brush will be used, and recreate the bitmap brush whenever the render target needs
		/// recreated. (For more information about resources, see Resources Overview.)
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1bitmapbrush
		[PInvokeData("d2d1.h", MSDNShortId = "22b14ffa-14cb-4e4d-bf80-7d81e4ae9ee4")]
		[ComImport, Guid("2cd906aa-12e2-11dc-9fed-001143a055f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ID2D1BitmapBrush : ID2D1Brush
		{
			/// <summary>Retrieves the factory associated with this resource.</summary>
			/// <param name="factory">
			/// <para>Type: <c>ID2D1Factory**</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is
			/// passed uninitialized.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
			// **factory );
			[PreserveSig]
			new void GetFactory(out ID2D1Factory factory);

			/// <summary>Sets the degree of opacity of this brush.</summary>
			/// <param name="opacity">
			/// <para>Type: <c>FLOAT</c></para>
			/// <para>
			/// A value between zero and 1 that indicates the opacity of the brush. This value is a constant multiplier that linearly scales
			/// the alpha value of all pixels filled by the brush. The opacity values are clamped in the range 0–1 before they are multipled together.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1brush-setopacity void SetOpacity( FLOAT opacity );
			[PreserveSig]
			new void SetOpacity(float opacity);

			/// <summary>Sets the transformation applied to the brush.</summary>
			/// <param name="transform">
			/// <para>Type: <c>const D2D1_MATRIX_3X2_F</c></para>
			/// <para>The transformation to apply to this brush.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// When you paint with a brush, it paints in the coordinate space of the render target. Brushes do not automatically position
			/// themselves to align with the object being painted; by default, they begin painting at the origin (0, 0) of the render target.
			/// </para>
			/// <para>
			/// You can "move" the gradient defined by an ID2D1LinearGradientBrush to a target area by setting its start point and end
			/// point. Likewise, you can move the gradient defined by an ID2D1RadialGradientBrush by changing its center and radii.
			/// </para>
			/// <para>
			/// To align the content of an ID2D1BitmapBrush to the area being painted, you can use the SetTransform method to translate the
			/// bitmap to the desired location. This transform only affects the brush; it does not affect any other content drawn by the
			/// render target.
			/// </para>
			/// <para>
			/// The following illustrations show the effect of using an ID2D1BitmapBrush to fill a rectangle located at (100, 100). The
			/// illustration on the left illustration shows the result of filling the rectangle without transforming the brush: the bitmap
			/// is drawn at the render target's origin. As a result, only a portion of the bitmap appears in the rectangle.
			/// </para>
			/// <para>
			/// The illustration on the right shows the result of transforming the ID2D1BitmapBrush so that its content is shifted 50 pixels
			/// to the right and 50 pixels down. The bitmap now fills the rectangle.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1brush-settransform(constd2d1_matrix_3x2_f_) void
			// SetTransform( const D2D1_MATRIX_3X2_F &amp; transform );
			[PreserveSig]
			new void SetTransform(in D2D_MATRIX_3X2_F transform);

			/// <summary>Gets the degree of opacity of this brush.</summary>
			/// <returns>
			/// <para>Type: <c>FLOAT</c></para>
			/// <para>
			/// A value between zero and 1 that indicates the opacity of the brush. This value is a constant multiplier that linearly scales
			/// the alpha value of all pixels filled by the brush. The opacity values are clamped in the range 0–1 before they are multipled together.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1brush-getopacity FLOAT GetOpacity();
			[PreserveSig]
			new float GetOpacity();

			/// <summary>Gets the transform applied to this brush.</summary>
			/// <param name="transform">
			/// <para>Type: <c>D2D1_MATRIX_3X2_F*</c></para>
			/// <para>The transform applied to this brush.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// When the brush transform is the identity matrix, the brush appears in the same coordinate space as the render target in
			/// which it is drawn.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1brush-gettransform void GetTransform( D2D1_MATRIX_3X2_F
			// *transform );
			[PreserveSig]
			new void GetTransform(out D2D_MATRIX_3X2_F transform);

			/// <summary>Specifies how the brush horizontally tiles those areas that extend past its bitmap.</summary>
			/// <param name="extendModeX">
			/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
			/// <para>A value that specifies how the brush horizontally tiles those areas that extend past its bitmap.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// Sometimes, the bitmap for a bitmap brush doesn't completely fill the area being painted. When this happens, Direct2D uses
			/// the brush's horizontal ( <c>SetExtendModeX</c>) and vertical (SetExtendModeY) extend mode settings to determine how to fill
			/// the remaining area.
			/// </para>
			/// <para>
			/// The following illustration shows the results from every possible combination of the extend modes for an ID2D1BitmapBrush:
			/// D2D1_EXTEND_MODE_CLAMP (CLAMP), <c>D2D1_EXTEND_MODE_WRAP</c> (WRAP), and <c>D2D1_EXTEND_MIRROR</c> (MIRROR).
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmapbrush-setextendmodex void SetExtendModeX(
			// D2D1_EXTEND_MODE extendModeX );
			[PreserveSig]
			void SetExtendModeX(D2D1_EXTEND_MODE extendModeX);

			/// <summary>Specifies how the brush vertically tiles those areas that extend past its bitmap.</summary>
			/// <param name="extendModeY">
			/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
			/// <para>A value that specifies how the brush vertically tiles those areas that extend past its bitmap.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// Sometimes, the bitmap for a bitmap brush doesn't completely fill the area being painted. When this happens, Direct2D uses
			/// the brush's horizontal (SetExtendModeX) and vertical ( <c>SetExtendModeY</c>) extend mode settings to determine how to fill
			/// the remaining area.
			/// </para>
			/// <para>
			/// The following illustration shows the results from every possible combination of the extend modes for an ID2D1BitmapBrush:
			/// D2D1_EXTEND_MODE_CLAMP (CLAMP), <c>D2D1_EXTEND_MODE_WRAP</c> (WRAP), and <c>D2D1_EXTEND_MIRROR</c> (MIRROR).
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmapbrush-setextendmodey void SetExtendModeY(
			// D2D1_EXTEND_MODE extendModeY );
			[PreserveSig]
			void SetExtendModeY(D2D1_EXTEND_MODE extendModeY);

			/// <summary>Specifies the interpolation mode used when the brush bitmap is scaled or rotated.</summary>
			/// <param name="interpolationMode">
			/// <para>Type: <c>D2D1_BITMAP_INTERPOLATION_MODE</c></para>
			/// <para>The interpolation mode used when the brush bitmap is scaled or rotated.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// This method sets the interpolation mode for a bitmap, which is an enum value that is specified in the
			/// D2D1_BITMAP_INTERPOLATION_MODE enumeration type. D2D1_BITMAP_INTERPOLATION_MODE_NEAREST_NEIGHBOR represents nearest neighbor
			/// filtering. It looks up the nearest bitmap pixel to the current rendering pixel and chooses its exact color.
			/// D2D1_BITMAP_INTERPOLATION_MODE_LINEAR represents linear filtering, and interpolates a color from the four nearest bitmap pixels.
			/// </para>
			/// <para>
			/// The interpolation mode of a bitmap also affects subpixel translations. In a subpixel translation, bilinear interpolation
			/// positions the bitmap more precisely to the application requests, but blurs the bitmap in the process.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmapbrush-setinterpolationmode void
			// SetInterpolationMode( D2D1_BITMAP_INTERPOLATION_MODE interpolationMode );
			[PreserveSig]
			void SetInterpolationMode(D2D1_BITMAP_INTERPOLATION_MODE interpolationMode);

			/// <summary>Specifies the bitmap source that this brush uses to paint.</summary>
			/// <param name="bitmap">
			/// <para>Type: <c>ID2D1Bitmap*</c></para>
			/// <para>The bitmap source used by the brush.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// This method specifies the bitmap source that this brush uses to paint. The bitmap is not resized or rescaled automatically
			/// to fit the geometry that it fills. The bitmap stays at its native size. To resize or translate the bitmap, use the
			/// SetTransform method to apply a transform to the brush.
			/// </para>
			/// <para>
			/// The native size of a bitmap is the width and height in bitmap pixels, divided by the bitmap DPI. This native size forms the
			/// base tile of the brush. To tile a subregion of the bitmap, you must generate a new bitmap containing this subregion and use
			/// <c>SetBitmap</c> to apply it to the brush.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmapbrush-setbitmap void SetBitmap( ID2D1Bitmap
			// *bitmap );
			[PreserveSig]
			void SetBitmap([In, Optional] ID2D1Bitmap bitmap);

			/// <summary>Gets the method by which the brush horizontally tiles those areas that extend past its bitmap.</summary>
			/// <returns>
			/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
			/// <para>A value that specifies how the brush horizontally tiles those areas that extend past its bitmap.</para>
			/// </returns>
			/// <remarks>
			/// Like all brushes, ID2D1BitmapBrush defines an infinite plane of content. Because bitmaps are finite, it relies on an extend
			/// mode to determine how the plane is filled horizontally and vertically.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmapbrush-getextendmodex D2D1_EXTEND_MODE GetExtendModeX();
			[PreserveSig]
			D2D1_EXTEND_MODE GetExtendModeX();

			/// <summary>Gets the method by which the brush vertically tiles those areas that extend past its bitmap.</summary>
			/// <returns>
			/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
			/// <para>A value that specifies how the brush vertically tiles those areas that extend past its bitmap.</para>
			/// </returns>
			/// <remarks>
			/// <para>Like all brushes, ID2D1BitmapBrush defines an infinite plane of content.</para>
			/// <para>Because bitmaps are finite, it relies on an extend mode to determine how the plane is filled horizontally and vertically.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmapbrush-getextendmodey D2D1_EXTEND_MODE GetExtendModeY();
			[PreserveSig]
			D2D1_EXTEND_MODE GetExtendModeY();

			/// <summary>Gets the interpolation method used when the brush bitmap is scaled or rotated.</summary>
			/// <returns>
			/// <para>Type: <c>D2D1_BITMAP_INTERPOLATION_MODE</c></para>
			/// <para>The interpolation method used when the brush bitmap is scaled or rotated.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method gets the interpolation mode of a bitmap, which is specified by the D2D1_BITMAP_INTERPOLATION_MODE enumeration
			/// type. <c>D2D1_BITMAP_INTERPOLATION_MODE_NEAREST_NEIGHBOR</c> represents nearest neighbor filtering. It looks up the bitmap
			/// pixel nearest to the current rendering pixel and chooses its exact color. <c>D2D1_BITMAP_INTERPOLATION_MODE_LINEAR</c>
			/// represents linear filtering, and interpolates a color from the four nearest bitmap pixels.
			/// </para>
			/// <para>
			/// The interpolation mode of a bitmap also affects subpixel translations. In a subpixel translation, linear interpolation
			/// positions the bitmap more precisely to the application request, but blurs the bitmap in the process.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmapbrush-getinterpolationmode
			// D2D1_BITMAP_INTERPOLATION_MODE GetInterpolationMode();
			[PreserveSig]
			D2D1_BITMAP_INTERPOLATION_MODE GetInterpolationMode();

			/// <summary>Gets the bitmap source that this brush uses to paint.</summary>
			/// <param name="bitmap">
			/// <para>Type: <c>ID2D1Bitmap**</c></para>
			/// <para>When this method returns, contains the address to a pointer to the bitmap with which this brush paints.</para>
			/// </param>
			/// <returns>None</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmapbrush-getbitmap void GetBitmap( ID2D1Bitmap
			// **bitmap );
			[PreserveSig]
			void GetBitmap(out ID2D1Bitmap bitmap);
		}

		/// <summary>Renders to an intermediate texture created by the CreateCompatibleRenderTarget method.</summary>
		/// <remarks>
		/// <para>
		/// An <c>ID2D1BitmapRenderTarget</c> writes to an intermediate texture. It's useful for creating patterns for use with an
		/// ID2D1BitmapBrush or caching drawing data that will be used repeatedly.
		/// </para>
		/// <para>
		/// To write directly to a WIC bitmap instead, use the ID2D1Factory::CreateWicBitmapRenderTarget method. This method returns an
		/// ID2D1RenderTarget that writes to the specified WIC bitmap.
		/// </para>
		/// <para>Creating ID2D1BitmapRenderTarget Objects</para>
		/// <para>To create a bitmap render target, call the ID2D1RenderTarget::CreateCompatibleRenderTarget method.</para>
		/// <para>
		/// Like other render targets, an <c>ID2D1BitmapRenderTarget</c> is a device-dependent resource and must be recreated when the
		/// associated device becomes unavailable. For more information, see the Resources Overview.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1bitmaprendertarget
		[PInvokeData("d2d1.h", MSDNShortId = "f298d4f7-acb8-4fbe-89f7-2410e3b753bd")]
		[ComImport, Guid("2cd90695-12e2-11dc-9fed-001143a055f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ID2D1BitmapRenderTarget : ID2D1RenderTarget
		{
			/// <summary>Retrieves the factory associated with this resource.</summary>
			/// <param name="factory">
			/// <para>Type: <c>ID2D1Factory**</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is
			/// passed uninitialized.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
			// **factory );
			[PreserveSig]
			new void GetFactory(out ID2D1Factory factory);

			/// <summary>Creates a Direct2D bitmap from a pointer to in-memory source data.</summary>
			/// <param name="size">
			/// <para>Type: [in] <c>D2D1_SIZE_U</c></para>
			/// <para>The dimensions of the bitmap to create in pixels.</para>
			/// </param>
			/// <param name="srcData">
			/// <para>Type: [in, optional] <c>const void*</c></para>
			/// <para>A pointer to the memory location of the image data, or <c>NULL</c> to create an uninitialized bitmap.</para>
			/// </param>
			/// <param name="pitch">
			/// <para>Type: [in] <c>UINT32</c></para>
			/// <para>
			/// The byte count of each scanline, which is equal to (the image width in pixels × the number of bytes per pixel) + memory
			/// padding. If srcData is <c>NULL</c>, this value is ignored. (Note that pitch is also sometimes called stride.)
			/// </para>
			/// </param>
			/// <param name="bitmapProperties">
			/// <para>Type: [in] <c>const D2D1_BITMAP_PROPERTIES &amp;</c></para>
			/// <para>The pixel format and dots per inch (DPI) of the bitmap to create.</para>
			/// </param>
			/// <returns>
			/// <para>Type: [out] <c>ID2D1Bitmap**</c></para>
			/// <para>When this method returns, contains a pointer to a pointer to the new bitmap. This parameter is passed uninitialized.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createbitmap(d2d1_size_u_constvoid_uint32_constd2d1_bitmap_properties__id2d1bitmap)
			// HRESULT CreateBitmap( D2D1_SIZE_U size, const void *srcData, UINT32 pitch, const D2D1_BITMAP_PROPERTIES &amp;
			// bitmapProperties, ID2D1Bitmap **bitmap );
			new ID2D1Bitmap CreateBitmap(D2D_SIZE_U size, [In, Optional] IntPtr srcData, uint pitch, in D2D1_BITMAP_PROPERTIES bitmapProperties);

			/// <summary>Creates an ID2D1Bitmap by copying the specified Microsoft Windows Imaging Component (WIC) bitmap.</summary>
			/// <param name="wicBitmapSource">
			/// <para>Type: [in] <c>IWICBitmapSource*</c></para>
			/// <para>The WIC bitmap to copy.</para>
			/// </param>
			/// <param name="bitmapProperties">
			/// <para>Type: [in, optional] <c>const D2D1_BITMAP_PROPERTIES*</c></para>
			/// <para>
			/// The pixel format and DPI of the bitmap to create. The pixel format must match the pixel format of wicBitmapSource, or the
			/// method will fail. To prevent a mismatch, you can pass <c>NULL</c> or pass the value obtained from calling the
			/// D2D1::PixelFormat helper function without specifying any parameter values. If both dpiX and dpiY are 0.0f, the default DPI,
			/// 96, is used. DPI information embedded in wicBitmapSource is ignored.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ID2D1Bitmap**</c></para>
			/// <para>When this method returns, contains the address of a pointer to the new bitmap. This parameter is passed uninitialized.</para>
			/// </returns>
			/// <remarks>
			/// Before Direct2D can load a WIC bitmap, that bitmap must be converted to a supported pixel format and alpha mode. For a list
			/// of supported pixel formats and alpha modes, see Supported Pixel Formats and Alpha Modes.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createbitmapfromwicbitmap(iwicbitmapsource_constd2d1_bitmap_properties_id2d1bitmap)
			// HRESULT CreateBitmapFromWicBitmap( IWICBitmapSource *wicBitmapSource, const D2D1_BITMAP_PROPERTIES *bitmapProperties,
			// ID2D1Bitmap **bitmap );
			new ID2D1Bitmap CreateBitmapFromWicBitmap(IWICBitmapSource wicBitmapSource, [In, Optional] IntPtr bitmapProperties);

			/// <summary>Creates an ID2D1Bitmap whose data is shared with another resource.</summary>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>The interface ID of the object supplying the source data.</para>
			/// </param>
			/// <param name="data">
			/// <para>Type: <c>void*</c></para>
			/// <para>
			/// An ID2D1Bitmap, IDXGISurface, or an IWICBitmapLock that contains the data to share with the new <c>ID2D1Bitmap</c>. For more
			/// information, see the Remarks section.
			/// </para>
			/// </param>
			/// <param name="bitmapProperties">
			/// <para>Type: <c>D2D1_BITMAP_PROPERTIES*</c></para>
			/// <para>
			/// The pixel format and DPI of the bitmap to create . The DXGI_FORMAT portion of the pixel format must match the DXGI_FORMAT of
			/// data or the method will fail, but the alpha modes don't have to match. To prevent a mismatch, you can pass <c>NULL</c> or
			/// the value obtained from the D2D1::PixelFormat helper function. The DPI settings do not have to match those of data. If both
			/// dpiX and dpiY are 0.0f, the DPI of the render target is used.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ID2D1Bitmap**</c></para>
			/// <para>When this method returns, contains the address of a pointer to the new bitmap. This parameter is passed uninitialized.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The <c>CreateSharedBitmap</c> method is useful for efficiently reusing bitmap data and can also be used to provide
			/// interoperability with Direct3D.
			/// </para>
			/// <para>Sharing an ID2D1Bitmap</para>
			/// <para>
			/// By passing an ID2D1Bitmap created by a render target that is resource-compatible, you can share a bitmap with that render
			/// target; both the original <c>ID2D1Bitmap</c> and the new <c>ID2D1Bitmap</c> created by this method will point to the same
			/// bitmap data. For more information about when render target resources can be shared, see the Sharing Render Target Resources
			/// section of the Resources Overview.
			/// </para>
			/// <para>
			/// You may also use this method to reinterpret the data of an existing bitmap and specify a new DPI or alpha mode. For example,
			/// in the case of a bitmap atlas, an ID2D1Bitmap may contain multiple sub-images, each of which should be rendered with a
			/// different D2D1_ALPHA_MODE ( <c>D2D1_ALPHA_MODE_PREMULTIPLIED</c> or <c>D2D1_ALPHA_MODE_IGNORE</c>). You could use the
			/// <c>CreateSharedBitmap</c> method to reinterpret the bitmap using the desired alpha mode without having to load a separate
			/// copy of the bitmap into memory.
			/// </para>
			/// <para>Sharing an IDXGISurface</para>
			/// <para>
			/// When using a DXGI surface render target (an ID2D1RenderTarget object created by the CreateDxgiSurfaceRenderTarget method),
			/// you can pass an IDXGISurface surface to the <c>CreateSharedBitmap</c> method to share video memory with Direct3D and
			/// manipulate Direct3D content as an ID2D1Bitmap. As described in the Resources Overview, the render target and the
			/// IDXGISurface must be using the same Direct3D device.
			/// </para>
			/// <para>
			/// Note also that the IDXGISurface must use one of the supported pixel formats and alpha modes described in Supported Pixel
			/// Formats and Alpha Modes.
			/// </para>
			/// <para>For more information about interoperability with Direct3D, see the Direct2D and Direct3D Interoperability Overview.</para>
			/// <para>Sharing an IWICBitmapLock</para>
			/// <para>
			/// An IWICBitmapLock stores the content of a WIC bitmap and shields it from simultaneous accesses. By passing an
			/// <c>IWICBitmapLock</c> to the <c>CreateSharedBitmap</c> method, you can create an ID2D1Bitmap that points to the bitmap data
			/// already stored in the <c>IWICBitmapLock</c>.
			/// </para>
			/// <para>
			/// To use an IWICBitmapLock with the <c>CreateSharedBitmap</c> method, the render target must use software rendering. To force
			/// a render target to use software rendering, set to D2D1_RENDER_TARGET_TYPE_SOFTWARE the <c>type</c> field of the
			/// D2D1_RENDER_TARGET_PROPERTIES structure that you use to create the render target. To check whether an existing render target
			/// uses software rendering, use the IsSupported method.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createsharedbitmap HRESULT
			// CreateSharedBitmap( REFIID riid, void *data, const D2D1_BITMAP_PROPERTIES *bitmapProperties, ID2D1Bitmap **bitmap );
			new ID2D1Bitmap CreateSharedBitmap(in Guid riid, [In, Out] IntPtr data, [In, Optional] IntPtr bitmapProperties);

			/// <summary>Creates an ID2D1BitmapBrush from the specified bitmap.</summary>
			/// <param name="bitmap">
			/// <para>Type: <c>ID2D1Bitmap*</c></para>
			/// <para>The bitmap contents of the new brush.</para>
			/// </param>
			/// <param name="bitmapBrushProperties">
			/// <para>Type: <c>D2D1_BITMAP_BRUSH_PROPERTIES*</c></para>
			/// <para>
			/// The extend modes and interpolation mode of the new brush, or <c>NULL</c>. If you set this parameter to <c>NULL</c>, the
			/// brush defaults to the D2D1_EXTEND_MODE_CLAMP horizontal and vertical extend modes and the
			/// D2D1_BITMAP_INTERPOLATION_MODE_LINEAR interpolation mode.
			/// </para>
			/// </param>
			/// <param name="brushProperties">
			/// <para>Type: <c>D2D1_BRUSH_PROPERTIES*</c></para>
			/// <para>
			/// A structure that contains the opacity and transform of the new brush, or <c>NULL</c>. If you set this parameter to
			/// <c>NULL</c>, the brush sets the opacity member to 1.0F and the transform member to the identity matrix.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ID2D1BitmapBrush**</c></para>
			/// <para>
			/// When this method returns, this output parameter contains a pointer to a pointer to the new brush. Pass this parameter uninitialized.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createbitmapbrush(id2d1bitmap_constd2d1_bitmap_brush_properties_constd2d1_brush_properties_id2d1bitmapbrush)
			// HRESULT CreateBitmapBrush( ID2D1Bitmap *bitmap, const D2D1_BITMAP_BRUSH_PROPERTIES *bitmapBrushProperties, const
			// D2D1_BRUSH_PROPERTIES *brushProperties, ID2D1BitmapBrush **bitmapBrush );
			new ID2D1BitmapBrush CreateBitmapBrush([In, Optional] ID2D1Bitmap bitmap, [In, Optional] IntPtr bitmapBrushProperties, [In, Optional] IntPtr brushProperties);

			/// <summary>Creates a new ID2D1SolidColorBrush that has the specified color and opacity.</summary>
			/// <param name="color">
			/// <para>Type: [in] <c>const D2D1_COLOR_F &amp;</c></para>
			/// <para>The red, green, blue, and alpha values of the brush's color.</para>
			/// </param>
			/// <param name="brushProperties">
			/// <para>Type: [in] <c>const D2D1_BRUSH_PROPERTIES &amp;</c></para>
			/// <para>The base opacity of the brush.</para>
			/// </param>
			/// <returns>
			/// <para>Type: [out] <c>ID2D1SolidColorBrush**</c></para>
			/// <para>When this method returns, contains the address of a pointer to the new brush. This parameter is passed uninitialized.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createsolidcolorbrush(constd2d1_color_f__constd2d1_brush_properties__id2d1solidcolorbrush)
			// HRESULT CreateSolidColorBrush( const D2D1_COLOR_F &amp; color, const D2D1_BRUSH_PROPERTIES &amp; brushProperties,
			// ID2D1SolidColorBrush **solidColorBrush );
			new ID2D1SolidColorBrush CreateSolidColorBrush(in D3DCOLORVALUE color, [In, Optional] IntPtr brushProperties);

			/// <summary>Creates an ID2D1GradientStopCollection from the specified array of D2D1_GRADIENT_STOP structures.</summary>
			/// <param name="gradientStops">
			/// <para>Type: [in] <c>D2D1_GRADIENT_STOP*</c></para>
			/// <para>A pointer to an array of D2D1_GRADIENT_STOP structures.</para>
			/// </param>
			/// <param name="gradientStopsCount">
			/// <para>Type: [in] <c>UINT</c></para>
			/// <para>A value greater than or equal to 1 that specifies the number of gradient stops in the gradientStops array.</para>
			/// </param>
			/// <param name="colorInterpolationGamma">
			/// <para>Type: [in] <c>D2D1_GAMMA</c></para>
			/// <para>The space in which color interpolation between the gradient stops is performed.</para>
			/// </param>
			/// <param name="extendMode">
			/// <para>Type: [in] <c>D2D1_EXTEND_MODE</c></para>
			/// <para>The behavior of the gradient outside the [0,1] normalized range.</para>
			/// </param>
			/// <returns>
			/// <para>Type: [out] <c>ID2D1GradientStopCollection**</c></para>
			/// <para>When this method returns, contains a pointer to a pointer to the new gradient stop collection.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-creategradientstopcollection%28constd2d1_gradient_stop_uint32_d2d1_gamma_d2d1_extend_mode_id2d1gradientstopcollection%29
			// HRESULT CreateGradientStopCollection( const D2D1_GRADIENT_STOP *gradientStops, UINT32 gradientStopsCount, D2D1_GAMMA
			// colorInterpolationGamma, D2D1_EXTEND_MODE extendMode, ID2D1GradientStopCollection **gradientStopCollection );
			new ID2D1GradientStopCollection CreateGradientStopCollection([In] D2D1_GRADIENT_STOP[] gradientStops, uint gradientStopsCount, D2D1_GAMMA colorInterpolationGamma, D2D1_EXTEND_MODE extendMode);

			/// <summary>Creates an ID2D1LinearGradientBrush object for painting areas with a linear gradient.</summary>
			/// <param name="linearGradientBrushProperties">
			/// <para>Type: [in] <c>const D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES*</c></para>
			/// <para>The start and end points of the gradient.</para>
			/// </param>
			/// <param name="brushProperties">
			/// <para>Type: [in] <c>const D2D1_BRUSH_PROPERTIES*</c></para>
			/// <para>The transform and base opacity of the new brush.</para>
			/// </param>
			/// <param name="gradientStopCollection">
			/// <para>Type: [in] <c>ID2D1GradientStopCollection*</c></para>
			/// <para>
			/// A collection of D2D1_GRADIENT_STOP structures that describe the colors in the brush's gradient and their locations along the
			/// gradient line.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: [out] <c>ID2D1LinearGradientBrush**</c></para>
			/// <para>When this method returns, contains the address of a pointer to the new brush. This parameter is passed uninitialized.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createlineargradientbrush%28constd2d1_linear_gradient_brush_properties_constd2d1_brush_properties_id2d1gradientstopcollection_id2d1lineargradientbrush%29
			// HRESULT CreateLinearGradientBrush( const D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES *linearGradientBrushProperties, const
			// D2D1_BRUSH_PROPERTIES *brushProperties, ID2D1GradientStopCollection *gradientStopCollection, ID2D1LinearGradientBrush
			// **linearGradientBrush );
			new ID2D1LinearGradientBrush CreateLinearGradientBrush(in D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES linearGradientBrushProperties, [In, Optional] IntPtr brushProperties, [In] ID2D1GradientStopCollection gradientStopCollection);

			/// <summary>Creates an ID2D1RadialGradientBrush object that can be used to paint areas with a radial gradient.</summary>
			/// <param name="radialGradientBrushProperties">
			/// <para>Type: <c>const D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES*</c></para>
			/// <para>The center, gradient origin offset, and x-radius and y-radius of the brush's gradient.</para>
			/// </param>
			/// <param name="brushProperties">
			/// <para>Type: [in] <c>const D2D1_BRUSH_PROPERTIES*</c></para>
			/// <para>The transform and base opacity of the new brush.</para>
			/// </param>
			/// <param name="gradientStopCollection">
			/// <para>Type: [in] <c>ID2D1GradientStopCollection*</c></para>
			/// <para>
			/// A collection of D2D1_GRADIENT_STOP structures that describe the colors in the brush's gradient and their locations along the gradient.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: [out] <c>ID2D1RadialGradientBrush**</c></para>
			/// <para>When this method returns, contains a pointer to a pointer to the new brush. This parameter is passed uninitialized.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createradialgradientbrush%28constd2d1_radial_gradient_brush_properties_constd2d1_brush_properties_id2d1gradientstopcollection_id2d1radialgradientbrush%29
			// HRESULT CreateRadialGradientBrush( const D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES *radialGradientBrushProperties, const
			// D2D1_BRUSH_PROPERTIES *brushProperties, ID2D1GradientStopCollection *gradientStopCollection, ID2D1RadialGradientBrush
			// **radialGradientBrush );
			new ID2D1RadialGradientBrush CreateRadialGradientBrush(in D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES radialGradientBrushProperties, [In, Optional] IntPtr brushProperties, [In] ID2D1GradientStopCollection gradientStopCollection);

			/// <summary>
			/// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
			/// </summary>
			/// <param name="desiredSize">
			/// <para>Type: [in] <c>const D2D1_SIZE_F*</c></para>
			/// <para>
			/// The desired size of the new render target (in device-independent pixels), if it should be different from the original render
			/// target. For more info, see the Remarks section.
			/// </para>
			/// </param>
			/// <param name="desiredPixelSize">
			/// <para>Type: [in] <c>const D2D1_SIZE_U*</c></para>
			/// <para>
			/// The desired size of the new render target in pixels if it should be different from the original render target. For more
			/// information, see the Remarks section.
			/// </para>
			/// </param>
			/// <param name="desiredFormat">
			/// <para>Type: [in] <c>const D2D1_PIXEL_FORMAT*</c></para>
			/// <para>
			/// The desired pixel format and alpha mode of the new render target. If the pixel format is set to DXGI_FORMAT_UNKNOWN, the new
			/// render target uses the same pixel format as the original render target. If the alpha mode is D2D1_ALPHA_MODE_UNKNOWN, the
			/// alpha mode of the new render target defaults to <c>D2D1_ALPHA_MODE_PREMULTIPLIED</c>. For information about supported pixel
			/// formats, see Supported Pixel Formats and Alpha Modes.
			/// </para>
			/// </param>
			/// <param name="options">
			/// <para>Type: [in] <c>D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS</c></para>
			/// <para>A value that specifies whether the new render target must be compatible with GDI.</para>
			/// </param>
			/// <returns>
			/// <para>Type: [out] <c>ID2D1BitmapRenderTarget**</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a pointer to a new bitmap render target. This parameter is passed uninitialized.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>The pixel size and DPI of the new render target can be altered by specifying values for desiredSize or desiredPixelSize:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>
			/// If desiredSize is specified but desiredPixelSize is not, the pixel size is computed from the desired size using the parent
			/// target DPI. If the desiredSize maps to a integer-pixel size, the DPI of the compatible render target is the same as the DPI
			/// of the parent target. If desiredSize maps to a fractional-pixel size, the pixel size is rounded up to the nearest integer
			/// and the DPI for the compatible render target is slightly higher than the DPI of the parent render target. In all cases, the
			/// coordinate (desiredSize.width, desiredSize.height) maps to the lower-right corner of the compatible render target.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// If the desiredPixelSize is specified and desiredSize is not, the DPI of the new render target is the same as the original
			/// render target.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// If both desiredSize and desiredPixelSize are specified, the DPI of the new render target is computed to account for the
			/// difference in scale.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// If neither desiredSize nor desiredPixelSize is specified, the new render target size and DPI match the original render target.
			/// </term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createcompatiblerendertarget(constd2d1_size_f_constd2d1_size_u_constd2d1_pixel_format_d2d1_compatible_render_target_options_id2d1bitmaprendertarget)
			// HRESULT CreateCompatibleRenderTarget( const D2D1_SIZE_F *desiredSize, const D2D1_SIZE_U *desiredPixelSize, const
			// D2D1_PIXEL_FORMAT *desiredFormat, D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS options, ID2D1BitmapRenderTarget **bitmapRenderTarget );
			new ID2D1BitmapRenderTarget CreateCompatibleRenderTarget([In, Optional] IntPtr desiredSize, [In, Optional] IntPtr desiredPixelSize, [In, Optional] IntPtr desiredFormat, [In, Optional] D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS options);

			/// <summary>Creates a layer resource that can be used with this render target and its compatible render targets.</summary>
			/// <param name="size">
			/// <para>Type: [in] <c>const D2D1_SIZE_F*</c></para>
			/// <para>
			/// If (0, 0) is specified, no backing store is created behind the layer resource. The layer resource is allocated to the
			/// minimum size when PushLayer is called.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: [out] <c>ID2D1Layer**</c></para>
			/// <para>When the method returns, contains a pointer to a pointer to the new layer. This parameter is passed uninitialized.</para>
			/// </returns>
			/// <remarks>The layer automatically resizes itself, as needed.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createlayer(constd2d1_size_f_id2d1layer)
			// HRESULT CreateLayer( const D2D1_SIZE_F *size, ID2D1Layer **layer );
			new ID2D1Layer CreateLayer([In, Optional] IntPtr size);

			/// <summary>Create a mesh that uses triangles to describe a shape.</summary>
			/// <returns>
			/// <para>Type: <c>ID2D1Mesh**</c></para>
			/// <para>When this method returns, contains a pointer to a pointer to the new mesh.</para>
			/// </returns>
			/// <remarks>
			/// To populate a mesh, use its Open method to obtain an ID2D1TessellationSink. To draw the mesh, use the render target's
			/// FillMesh method.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createmesh HRESULT CreateMesh( ID2D1Mesh
			// **mesh );
			new ID2D1Mesh CreateMesh();

			/// <summary>Draws a line between the specified points using the specified stroke style.</summary>
			/// <param name="point0">
			/// <para>Type: <c>D2D1_POINT_2F</c></para>
			/// <para>The start point of the line, in device-independent pixels.</para>
			/// </param>
			/// <param name="point1">
			/// <para>Type: <c>D2D1_POINT_2F</c></para>
			/// <para>The end point of the line, in device-independent pixels.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the line's stroke.</para>
			/// </param>
			/// <param name="strokeWidth">
			/// <para>Type: <c>FLOAT</c></para>
			/// <para>
			/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter
			/// isn't specified, it defaults to 1.0f. The stroke is centered on the line.
			/// </para>
			/// </param>
			/// <param name="strokeStyle">
			/// <para>Type: <c>ID2D1StrokeStyle*</c></para>
			/// <para>The style of stroke to paint, or <c>NULL</c> to paint a solid line.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>DrawLine</c>)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawline void DrawLine( D2D1_POINT_2F
			// point0, D2D1_POINT_2F point1, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
			[PreserveSig]
			new void DrawLine(D2D_POINT_2F point0, D2D_POINT_2F point1, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle strokeStyle = null);

			/// <summary>Draws the outline of a rectangle that has the specified dimensions and stroke style.</summary>
			/// <param name="rect">
			/// <para>Type: [in] <c>const D2D1_RECT_F &amp;</c></para>
			/// <para>The dimensions of the rectangle to draw, in device-independent pixels.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: [in] <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the rectangle's stroke.</para>
			/// </param>
			/// <param name="strokeWidth">
			/// <para>Type: [in] <c>FLOAT</c></para>
			/// <para>
			/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter
			/// isn't specified, it defaults to 1.0f. The stroke is centered on the line.
			/// </para>
			/// </param>
			/// <param name="strokeStyle">
			/// <para>Type: [in, optional] <c>ID2D1StrokeStyle*</c></para>
			/// <para>The style of stroke to paint, or <c>NULL</c> to paint a solid stroke.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// When this method fails, it does not return an error code. To determine whether a drawing method (such as DrawRectangle)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush method.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawrectangle(constd2d1_rect_f__id2d1brush_float_id2d1strokestyle)
			// void DrawRectangle( const D2D1_RECT_F &amp; rect, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
			[PreserveSig]
			new void DrawRectangle(in D2D_RECT_F rect, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle strokeStyle = null);

			/// <summary>Paints the interior of the specified rectangle.</summary>
			/// <param name="rect">
			/// <para>Type: [in] <c>const D2D1_RECT_F &amp;</c></para>
			/// <para>The dimension of the rectangle to paint, in device-independent pixels.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: [in] <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the rectangle's interior.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as FillRectangle)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillrectangle(constd2d1_rect_f__id2d1brush)
			// void FillRectangle( const D2D1_RECT_F &amp; rect, ID2D1Brush *brush );
			[PreserveSig]
			new void FillRectangle(in D2D_RECT_F rect, [In] ID2D1Brush brush);

			/// <summary>Draws the outline of the specified rounded rectangle using the specified stroke style.</summary>
			/// <param name="roundedRect">
			/// <para>Type: [in] <c>const D2D1_ROUNDED_RECT &amp;</c></para>
			/// <para>The dimensions of the rounded rectangle to draw, in device-independent pixels.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: [in] <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the rounded rectangle's outline.</para>
			/// </param>
			/// <param name="strokeWidth">
			/// <para>Type: [in] <c>FLOAT</c></para>
			/// <para>
			/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter
			/// isn't specified, it defaults to 1.0f. The stroke is centered on the line.
			/// </para>
			/// </param>
			/// <param name="strokeStyle">
			/// <para>Type: [in, optional] <c>ID2D1StrokeStyle*</c></para>
			/// <para>The style of the rounded rectangle's stroke, or <c>NULL</c> to paint a solid stroke. The default value is <c>NULL</c>.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
			/// DrawRoundedRectangle) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawroundedrectangle(constd2d1_rounded_rect__id2d1brush_float_id2d1strokestyle)
			// void DrawRoundedRectangle( const D2D1_ROUNDED_RECT &amp; roundedRect, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle
			// *strokeStyle );
			[PreserveSig]
			new void DrawRoundedRectangle(in D2D1_ROUNDED_RECT roundedRect, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle strokeStyle = null);

			/// <summary>Paints the interior of the specified rounded rectangle.</summary>
			/// <param name="roundedRect">
			/// <para>Type: [in] <c>const D2D1_ROUNDED_RECT &amp;</c></para>
			/// <para>The dimensions of the rounded rectangle to paint, in device independent pixels.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: [in] <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the interior of the rounded rectangle.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
			/// FillRoundedRectangle) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillroundedrectangle(constd2d1_rounded_rect__id2d1brush)
			// void FillRoundedRectangle( const D2D1_ROUNDED_RECT &amp; roundedRect, ID2D1Brush *brush );
			[PreserveSig]
			new void FillRoundedRectangle(in D2D1_ROUNDED_RECT roundedRect, [In] ID2D1Brush brush);

			/// <summary>Draws the outline of the specified ellipse using the specified stroke style.</summary>
			/// <param name="ellipse">
			/// <para>Type: [in] <c>const D2D1_ELLIPSE &amp;</c></para>
			/// <para>The position and radius of the ellipse to draw, in device-independent pixels.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: [in] <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the ellipse's outline.</para>
			/// </param>
			/// <param name="strokeWidth">
			/// <para>Type: [in] <c>FLOAT</c></para>
			/// <para>
			/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter
			/// isn't specified, it defaults to 1.0f. The stroke is centered on the line.
			/// </para>
			/// </param>
			/// <param name="strokeStyle">
			/// <para>Type: [in, optional] <c>ID2D1StrokeStyle*</c></para>
			/// <para>The style of stroke to apply to the ellipse's outline, or <c>NULL</c> to paint a solid stroke.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// The DrawEllipse method doesn't return an error code if it fails. To determine whether a drawing operation (such as
			/// <c>DrawEllipse</c>) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawellipse(constd2d1_ellipse__id2d1brush_float_id2d1strokestyle)
			// void DrawEllipse( const D2D1_ELLIPSE &amp; ellipse, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
			[PreserveSig]
			new void DrawEllipse(in D2D1_ELLIPSE ellipse, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle strokeStyle = null);

			/// <summary>Paints the interior of the specified ellipse.</summary>
			/// <param name="ellipse">
			/// <para>Type: [in] <c>const D2D1_ELLIPSE &amp;</c></para>
			/// <para>The position and radius, in device-independent pixels, of the ellipse to paint.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: [in] <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the interior of the ellipse.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as FillEllipse) failed,
			/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillellipse(constd2d1_ellipse__id2d1brush)
			// void FillEllipse( const D2D1_ELLIPSE &amp; ellipse, ID2D1Brush *brush );
			[PreserveSig]
			new void FillEllipse(in D2D1_ELLIPSE ellipse, [In] ID2D1Brush brush);

			/// <summary>Draws the outline of the specified geometry using the specified stroke style.</summary>
			/// <param name="geometry">
			/// <para>Type: <c>ID2D1Geometry*</c></para>
			/// <para>The geometry to draw.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the geometry's stroke.</para>
			/// </param>
			/// <param name="strokeWidth">
			/// <para>Type: <c>FLOAT</c></para>
			/// <para>
			/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter
			/// isn't specified, it defaults to 1.0f. The stroke is centered on the line.
			/// </para>
			/// </param>
			/// <param name="strokeStyle">
			/// <para>Type: <c>ID2D1StrokeStyle*</c></para>
			/// <para>The style of stroke to apply to the geometry's outline, or <c>NULL</c> to paint a solid stroke.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>DrawGeometry</c>)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawgeometry void DrawGeometry(
			// ID2D1Geometry *geometry, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
			[PreserveSig]
			new void DrawGeometry([In] ID2D1Geometry geometry, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle strokeStyle = null);

			/// <summary>Paints the interior of the specified geometry.</summary>
			/// <param name="geometry">
			/// <para>Type: <c>ID2D1Geometry*</c></para>
			/// <para>The geometry to paint.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the geometry's interior.</para>
			/// </param>
			/// <param name="opacityBrush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>
			/// The opacity mask to apply to the geometry, or <c>NULL</c> for no opacity mask. If an opacity mask (the opacityBrush
			/// parameter) is specified, brush must be an ID2D1BitmapBrush that has its x- and y-extend modes set to D2D1_EXTEND_MODE_CLAMP.
			/// For more information, see the Remarks section.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// If the opacityBrush parameter is not <c>NULL</c>, the alpha value of each pixel of the mapped opacityBrush is used to
			/// determine the resulting opacity of each corresponding pixel of the geometry. Only the alpha value of each color in the brush
			/// is used for this processing; all other color information is ignored.
			/// </para>
			/// <para>
			/// The alpha value specified by the brush is multiplied by the alpha value of the geometry after the geometry has been painted
			/// by brush.
			/// </para>
			/// <para>
			/// When this method fails, it does not return an error code. To determine whether a drawing operation (such as
			/// <c>FillGeometry</c>) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush method.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillgeometry void FillGeometry(
			// ID2D1Geometry *geometry, ID2D1Brush *brush, ID2D1Brush *opacityBrush );
			[PreserveSig]
			new void FillGeometry([In] ID2D1Geometry geometry, [In] ID2D1Brush brush, [In] ID2D1Brush opacityBrush = null);

			/// <summary>Paints the interior of the specified mesh.</summary>
			/// <param name="mesh">
			/// <para>Type: <c>ID2D1Mesh*</c></para>
			/// <para>The mesh to paint.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the mesh.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// The current antialias mode of the render target must be D2D1_ANTIALIAS_MODE_ALIASED when <c>FillMesh</c> is called. To
			/// change the render target's antialias mode, use the SetAntialiasMode method.
			/// </para>
			/// <para>
			/// <c>FillMesh</c> does not expect a particular winding order for the triangles in the ID2D1Mesh; both clockwise and
			/// counter-clockwise will work.
			/// </para>
			/// <para>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>FillMesh</c>)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillmesh void FillMesh( ID2D1Mesh *mesh,
			// ID2D1Brush *brush );
			[PreserveSig]
			new void FillMesh([In] ID2D1Mesh mesh, [In] ID2D1Brush brush);

			/// <summary>
			/// Applies the opacity mask described by the specified bitmap to a brush and uses that brush to paint a region of the render target.
			/// </summary>
			/// <param name="opacityMask">
			/// <para>Type: <c>ID2D1Bitmap*</c></para>
			/// <para>
			/// The opacity mask to apply to the brush. The alpha value of each pixel in the region specified by sourceRectangle is
			/// multiplied with the alpha value of the brush after the brush has been mapped to the area defined by destinationRectangle.
			/// </para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the region of the render target specified by destinationRectangle.</para>
			/// </param>
			/// <param name="content">
			/// <para>Type: <c>D2D1_OPACITY_MASK_CONTENT</c></para>
			/// <para>
			/// The type of content the opacity mask contains. The value is used to determine the color space in which the opacity mask is blended.
			/// </para>
			/// <para>
			/// <c>Note</c> Starting with Windows 8, the D2D1_OPACITY_MASK_CONTENT is not required. See the
			/// ID2D1DeviceContext::FillOpacityMask method, which has no <c>D2D1_OPACITY_MASK_CONTENT</c> parameter.
			/// </para>
			/// </param>
			/// <param name="destinationRectangle">
			/// <para>Type: <c>const D2D1_RECT_F</c></para>
			/// <para>The region of the render target to paint, in device-independent pixels.</para>
			/// </param>
			/// <param name="sourceRectangle">
			/// <para>Type: <c>const D2D1_RECT_F</c></para>
			/// <para>The region of the bitmap to use as the opacity mask, in device-independent pixels.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// For this method to work properly, the render target must be using the D2D1_ANTIALIAS_MODE_ALIASED antialiasing mode. You can
			/// set the antialiasing mode by calling the ID2D1RenderTarget::SetAntialiasMode method.
			/// </para>
			/// <para>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as FillOpacityMask)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillopacitymask(id2d1bitmap_id2d1brush_d2d1_opacity_mask_content_constd2d1_rect_f__constd2d1_rect_f_)
			// void FillOpacityMask( ID2D1Bitmap *opacityMask, ID2D1Brush *brush, D2D1_OPACITY_MASK_CONTENT content, const D2D1_RECT_F &amp;
			// destinationRectangle, const D2D1_RECT_F &amp; sourceRectangle );
			[PreserveSig]
			new void FillOpacityMask([In] ID2D1Bitmap opacityMask, [In] ID2D1Brush brush, D2D1_OPACITY_MASK_CONTENT content, [In, Optional] IntPtr destinationRectangle, [In, Optional] IntPtr sourceRectangle);

			/// <summary>Draws the specified bitmap after scaling it to the size of the specified rectangle.</summary>
			/// <param name="bitmap">
			/// <para>Type: <c>ID2D1Bitmap*</c></para>
			/// <para>The bitmap to render.</para>
			/// </param>
			/// <param name="destinationRectangle">
			/// <para>Type: <c>const D2D1_RECT_F</c></para>
			/// <para>
			/// The size and position, in device-independent pixels in the render target's coordinate space, of the area to which the bitmap
			/// is drawn. If the rectangle is not well-ordered, nothing is drawn, but the render target does not enter an error state.
			/// </para>
			/// </param>
			/// <param name="opacity">
			/// <para>Type: <c>FLOAT</c></para>
			/// <para>
			/// A value between 0.0f and 1.0f, inclusive, that specifies an opacity value to apply to the bitmap; this value is multiplied
			/// against the alpha values of the bitmap's contents.
			/// </para>
			/// </param>
			/// <param name="interpolationMode">
			/// <para>Type: <c>D2D1_BITMAP_INTERPOLATION_MODE</c></para>
			/// <para>The interpolation mode to use if the bitmap is scaled or rotated by the drawing operation.</para>
			/// </param>
			/// <param name="sourceRectangle">
			/// <para>Type: <c>const D2D1_RECT_F</c></para>
			/// <para>
			/// The size and position, in device-independent pixels in the bitmap's coordinate space, of the area within the bitmap to draw.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as DrawBitmap) failed,
			/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawbitmap(id2d1bitmap_constd2d1_rect_f__float_d2d1_bitmap_interpolation_mode_constd2d1_rect_f_)
			// void DrawBitmap( ID2D1Bitmap *bitmap, const D2D1_RECT_F &amp; destinationRectangle, FLOAT opacity,
			// D2D1_BITMAP_INTERPOLATION_MODE interpolationMode, const D2D1_RECT_F &amp; sourceRectangle );
			[PreserveSig]
			new void DrawBitmap([In] ID2D1Bitmap bitmap, [In, Optional] IntPtr destinationRectangle, float opacity = 1.0f,
				D2D1_BITMAP_INTERPOLATION_MODE interpolationMode = D2D1_BITMAP_INTERPOLATION_MODE.D2D1_BITMAP_INTERPOLATION_MODE_LINEAR, [In] IntPtr sourceRectangle = default);

			/// <summary>Draws the specified text using the format information provided by an IDWriteTextFormat object.</summary>
			/// <param name="string">
			/// <para>Type: <c>WCHAR*</c></para>
			/// <para>A pointer to an array of Unicode characters to draw.</para>
			/// </param>
			/// <param name="stringLength">
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of characters in string.</para>
			/// </param>
			/// <param name="textFormat">
			/// <para>Type: <c>IDWriteTextFormat*</c></para>
			/// <para>An object that describes formatting details of the text to draw, such as the font, the font size, and flow direction.</para>
			/// </param>
			/// <param name="layoutRect">
			/// <para>Type: <c>const D2D1_RECT_F</c></para>
			/// <para>The size and position of the area in which the text is drawn.</para>
			/// </param>
			/// <param name="defaultFillBrush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the text.</para>
			/// </param>
			/// <param name="options">
			/// <para>Type: <c>D2D1_DRAW_TEXT_OPTIONS</c></para>
			/// <para>
			/// A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the
			/// layout rectangle. The default value is D2D1_DRAW_TEXT_OPTIONS_NONE, which indicates that text should be snapped to pixel
			/// boundaries and it should not be clipped to the layout rectangle.
			/// </para>
			/// </param>
			/// <param name="measuringMode">
			/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
			/// <para>A value that indicates how glyph metrics are used to measure text when it is formatted. The default value is DWRITE_MEASURING_MODE_NATURAL.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>To create an IDWriteTextFormat object, create an IDWriteFactory and call its CreateTextFormat method.</para>
			/// <para>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as DrawText) failed,
			/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawtext(constwchar_uint32_idwritetextformat_constd2d1_rect_f__id2d1brush_d2d1_draw_text_options_dwrite_measuring_mode)
			// void DrawText( const WCHAR *string, UINT32 stringLength, IDWriteTextFormat *textFormat, const D2D1_RECT_F &amp; layoutRect,
			// ID2D1Brush *defaultFillBrush, D2D1_DRAW_TEXT_OPTIONS options, DWRITE_MEASURING_MODE measuringMode );
			[PreserveSig]
			new void DrawText([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat, in D2D_RECT_F layoutRect,
				[In] ID2D1Brush defaultFillBrush, D2D1_DRAW_TEXT_OPTIONS options = D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE,
				DWRITE_MEASURING_MODE measuringMode = DWRITE_MEASURING_MODE.DWRITE_MEASURING_MODE_NATURAL);

			/// <summary>Draws the formatted text described by the specified IDWriteTextLayout object.</summary>
			/// <param name="origin">
			/// <para>Type: <c>D2D1_POINT_2F</c></para>
			/// <para>
			/// The point, described in device-independent pixels, at which the upper-left corner of the text described by textLayout is drawn.
			/// </para>
			/// </param>
			/// <param name="textLayout">
			/// <para>Type: <c>IDWriteTextLayout*</c></para>
			/// <para>
			/// The formatted text to draw. Any drawing effects that do not inherit from ID2D1Resource are ignored. If there are drawing
			/// effects that inherit from <c>ID2D1Resource</c> that are not brushes, this method fails and the render target is put in an
			/// error state.
			/// </para>
			/// </param>
			/// <param name="defaultFillBrush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>
			/// The brush used to paint any text in textLayout that does not already have a brush associated with it as a drawing effect
			/// (specified by the IDWriteTextLayout::SetDrawingEffect method).
			/// </para>
			/// </param>
			/// <param name="options">
			/// <para>Type: <c>D2D1_DRAW_TEXT_OPTIONS</c></para>
			/// <para>
			/// A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the
			/// layout rectangle. The default value is D2D1_DRAW_TEXT_OPTIONS_NONE, which indicates that text should be snapped to pixel
			/// boundaries and it should not be clipped to the layout rectangle.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// When drawing the same text repeatedly, using the <c>DrawTextLayout</c> method is more efficient than using the DrawText
			/// method because the text doesn't need to be formatted and the layout processed with each call.
			/// </para>
			/// <para>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
			/// <c>DrawTextLayout</c>) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawtextlayout void DrawTextLayout(
			// D2D1_POINT_2F origin, IDWriteTextLayout *textLayout, ID2D1Brush *defaultFillBrush, D2D1_DRAW_TEXT_OPTIONS options );
			[PreserveSig]
			new void DrawTextLayout(D2D_POINT_2F origin, [In] IDWriteTextLayout textLayout, [In] ID2D1Brush defaultFillBrush,
				D2D1_DRAW_TEXT_OPTIONS options = D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE);

			/// <summary>Draws the specified glyphs.</summary>
			/// <param name="baselineOrigin">
			/// <para>Type: <c>D2D1_POINT_2F</c></para>
			/// <para>The origin, in device-independent pixels, of the glyphs' baseline.</para>
			/// </param>
			/// <param name="glyphRun">
			/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
			/// <para>The glyphs to render.</para>
			/// </param>
			/// <param name="foregroundBrush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the specified glyphs.</para>
			/// </param>
			/// <param name="measuringMode">
			/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
			/// <para>A value that indicates how glyph metrics are used to measure text when it is formatted. The default value is DWRITE_MEASURING_MODE_NATURAL.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>DrawGlyphRun</c>)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawglyphrun void DrawGlyphRun(
			// D2D1_POINT_2F baselineOrigin, const DWRITE_GLYPH_RUN *glyphRun, ID2D1Brush *foregroundBrush, DWRITE_MEASURING_MODE
			// measuringMode );
			[PreserveSig]
			new void DrawGlyphRun(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun, [In] ID2D1Brush foregroundBrush,
				DWRITE_MEASURING_MODE measuringMode = DWRITE_MEASURING_MODE.DWRITE_MEASURING_MODE_NATURAL);

			/// <summary>
			/// Applies the specified transform to the render target, replacing the existing transformation. All subsequent drawing
			/// operations occur in the transformed space.
			/// </summary>
			/// <param name="transform">
			/// <para>Type: <c>const D2D1_MATRIX_3X2_F</c></para>
			/// <para>The transform to apply to the render target.</para>
			/// </param>
			/// <returns>None</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-settransform(constd2d1_matrix_3x2_f_) void
			// SetTransform( const D2D1_MATRIX_3X2_F &amp; transform );
			[PreserveSig]
			new void SetTransform(in D2D_MATRIX_3X2_F transform);

			/// <summary>Gets the current transform of the render target.</summary>
			/// <param name="transform">
			/// <para>Type: <c>D2D1_MATRIX_3X2_F*</c></para>
			/// <para>When this returns, contains the current transform of the render target. This parameter is passed uninitialized.</para>
			/// </param>
			/// <returns>None</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettransform void GetTransform(
			// D2D1_MATRIX_3X2_F *transform );
			[PreserveSig]
			new void GetTransform(out D2D_MATRIX_3X2_F transform);

			/// <summary>
			/// Sets the antialiasing mode of the render target. The antialiasing mode applies to all subsequent drawing operations,
			/// excluding text and glyph drawing operations.
			/// </summary>
			/// <param name="antialiasMode">
			/// <para>Type: <c>D2D1_ANTIALIAS_MODE</c></para>
			/// <para>The antialiasing mode for future drawing operations.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>To specify the antialiasing mode for text and glyph operations, use the SetTextAntialiasMode method.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-setantialiasmode void SetAntialiasMode(
			// D2D1_ANTIALIAS_MODE antialiasMode );
			[PreserveSig]
			new void SetAntialiasMode(D2D1_ANTIALIAS_MODE antialiasMode);

			/// <summary>Retrieves the current antialiasing mode for nontext drawing operations.</summary>
			/// <returns>
			/// <para>Type: <c>D2D1_ANTIALIAS_MODE</c></para>
			/// <para>The current antialiasing mode for nontext drawing operations.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getantialiasmode D2D1_ANTIALIAS_MODE GetAntialiasMode();
			[PreserveSig]
			new D2D1_ANTIALIAS_MODE GetAntialiasMode();

			/// <summary>Specifies the antialiasing mode to use for subsequent text and glyph drawing operations.</summary>
			/// <param name="textAntialiasMode">
			/// <para>Type: <c>D2D1_TEXT_ANTIALIAS_MODE</c></para>
			/// <para>The antialiasing mode to use for subsequent text and glyph drawing operations.</para>
			/// </param>
			/// <returns>None</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-settextantialiasmode void
			// SetTextAntialiasMode( D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode );
			[PreserveSig]
			new void SetTextAntialiasMode(D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode);

			/// <summary>Gets the current antialiasing mode for text and glyph drawing operations.</summary>
			/// <returns>
			/// <para>Type: <c>D2D1_TEXT_ANTIALIAS_MODE</c></para>
			/// <para>The current antialiasing mode for text and glyph drawing operations.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettextantialiasmode
			// D2D1_TEXT_ANTIALIAS_MODE GetTextAntialiasMode();
			[PreserveSig]
			new D2D1_TEXT_ANTIALIAS_MODE GetTextAntialiasMode();

			/// <summary>Specifies text rendering options to be applied to all subsequent text and glyph drawing operations.</summary>
			/// <param name="textRenderingParams">
			/// <para>Type: <c>IDWriteRenderingParams*</c></para>
			/// <para>
			/// The text rendering options to be applied to all subsequent text and glyph drawing operations; <c>NULL</c> to clear current
			/// text rendering options.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// If the settings specified by textRenderingParams are incompatible with the render target's text antialiasing mode (specified
			/// by SetTextAntialiasMode), subsequent text and glyph drawing operations will fail and put the render target into an error state.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-settextrenderingparams void
			// SetTextRenderingParams( IDWriteRenderingParams *textRenderingParams );
			[PreserveSig]
			new void SetTextRenderingParams([In, Optional] IDWriteRenderingParams textRenderingParams);

			/// <summary>Retrieves the render target's current text rendering options.</summary>
			/// <param name="textRenderingParams">
			/// <para>Type: <c>IDWriteRenderingParams**</c></para>
			/// <para>
			/// When this method returns, textRenderingParamscontains the address of a pointer to the render target's current text rendering options.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// If the settings specified by textRenderingParams are incompatible with the render target's text antialiasing mode (specified
			/// by SetTextAntialiasMode), subsequent text and glyph drawing operations will fail and put the render target into an error state.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettextrenderingparams void
			// GetTextRenderingParams( IDWriteRenderingParams **textRenderingParams );
			[PreserveSig]
			new void GetTextRenderingParams(out IDWriteRenderingParams textRenderingParams);

			/// <summary>Specifies a label for subsequent drawing operations.</summary>
			/// <param name="tag1">
			/// <para>Type: <c>ulong</c></para>
			/// <para>A label to apply to subsequent drawing operations.</para>
			/// </param>
			/// <param name="tag2">
			/// <para>Type: <c>ulong</c></para>
			/// <para>A label to apply to subsequent drawing operations.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// The labels specified by this method are printed by debug error messages. If no tag is set, the default value for each tag is 0.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-settags void SetTags( ulong tag1, ulong
			// tag2 );
			[PreserveSig]
			new void SetTags(ulong tag1, ulong tag2);

			/// <summary>Gets the label for subsequent drawing operations.</summary>
			/// <param name="tag1">
			/// <para>Type: <c>D2D1_TAG*</c></para>
			/// <para>
			/// When this method returns, contains the first label for subsequent drawing operations. This parameter is passed
			/// uninitialized. If <c>NULL</c> is specified, no value is retrieved for this parameter.
			/// </para>
			/// </param>
			/// <param name="tag2">
			/// <para>Type: <c>D2D1_TAG*</c></para>
			/// <para>
			/// When this method returns, contains the second label for subsequent drawing operations. This parameter is passed
			/// uninitialized. If <c>NULL</c> is specified, no value is retrieved for this parameter.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>If the same address is passed for both parameters, both parameters receive the value of the second tag.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettags void GetTags( D2D1_TAG *tag1,
			// D2D1_TAG *tag2 );
			[PreserveSig]
			new void GetTags(out ulong tag1, out ulong tag2);

			/// <summary>
			/// Adds the specified layer to the render target so that it receives all subsequent drawing operations until PopLayer is called.
			/// </summary>
			/// <param name="layerParameters">
			/// <para>Type: <c>const D2D1_LAYER_PARAMETERS</c></para>
			/// <para>The content bounds, geometric mask, opacity, opacity mask, and antialiasing options for the layer.</para>
			/// </param>
			/// <param name="layer">
			/// <para>Type: <c>ID2D1Layer*</c></para>
			/// <para>The layer that receives subsequent drawing operations.</para>
			/// <para>
			/// <c>Note</c> Starting with Windows 8, this parameter is optional. If a layer is not specified, Direct2D manages the layer
			/// resource automatically.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// The <c>PushLayer</c> method allows a caller to begin redirecting rendering to a layer. All rendering operations are valid in
			/// a layer. The location of the layer is affected by the world transform set on the render target.
			/// </para>
			/// <para>
			/// Each PushLayer must have a matching PopLayer call. If there are more <c>PopLayer</c> calls than <c>PushLayer</c> calls, the
			/// render target is placed into an error state. If Flush is called before all outstanding layers are popped, the render target
			/// is placed into an error state, and an error is returned. The error state can be cleared by a call to EndDraw.
			/// </para>
			/// <para>
			/// A particular ID2D1Layer resource can be active only at one time. In other words, you cannot call a <c>PushLayer</c> method,
			/// and then immediately follow with another <c>PushLayer</c> method with the same layer resource. Instead, you must call the
			/// second <c>PushLayer</c> method with different layer resources.
			/// </para>
			/// <para>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as PushLayer) failed,
			/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-pushlayer(constd2d1_layer_parameters__id2d1layer)
			// void PushLayer( const D2D1_LAYER_PARAMETERS &amp; layerParameters, ID2D1Layer *layer );
			[PreserveSig]
			new void PushLayer(in D2D1_LAYER_PARAMETERS layerParameters, [In, Optional] ID2D1Layer layer);

			/// <summary>Stops redirecting drawing operations to the layer that is specified by the last PushLayer call.</summary>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>A <c>PopLayer</c> must match a previous PushLayer call.</para>
			/// <para>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>PopLayer</c>)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-poplayer void PopLayer();
			[PreserveSig]
			new void PopLayer();

			/// <summary>Executes all pending drawing commands.</summary>
			/// <param name="tag1">
			/// <para>Type: <c>D2D1_TAG*</c></para>
			/// <para>
			/// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors. This
			/// parameter is passed uninitialized.
			/// </para>
			/// </param>
			/// <param name="tag2">
			/// <para>Type: <c>D2D1_TAG*</c></para>
			/// <para>
			/// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors. This
			/// parameter is passed uninitialized.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>
			/// If the method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code and sets tag1 and tag2 to
			/// the tags that were active when the error occurred. If no error occurred, this method sets the error tag state to be (0,0).
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>This command does not flush the Direct3D device context that is associated with the render target.</para>
			/// <para>Calling this method resets the error state of the render target.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-flush HRESULT Flush( D2D1_TAG *tag1,
			// D2D1_TAG *tag2 );
			new void Flush(out ulong tag1, out ulong tag2);

			/// <summary>Saves the current drawing state to the specified ID2D1DrawingStateBlock.</summary>
			/// <param name="drawingStateBlock">
			/// <para>Type: <c>ID2D1DrawingStateBlock*</c></para>
			/// <para>
			/// When this method returns, contains the current drawing state of the render target. This parameter must be initialized before
			/// passing it to the method.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-savedrawingstate void SaveDrawingState(
			// ID2D1DrawingStateBlock *drawingStateBlock );
			[PreserveSig]
			new void SaveDrawingState([In, Out] ID2D1DrawingStateBlock drawingStateBlock);

			/// <summary>Sets the render target's drawing state to that of the specified ID2D1DrawingStateBlock.</summary>
			/// <param name="drawingStateBlock">
			/// <para>Type: <c>ID2D1DrawingStateBlock*</c></para>
			/// <para>The new drawing state of the render target.</para>
			/// </param>
			/// <returns>None</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-restoredrawingstate void
			// RestoreDrawingState( ID2D1DrawingStateBlock *drawingStateBlock );
			[PreserveSig]
			new void RestoreDrawingState([In] ID2D1DrawingStateBlock drawingStateBlock);

			/// <summary>Specifies a rectangle to which all subsequent drawing operations are clipped.</summary>
			/// <param name="clipRect">
			/// <para>Type: [in] <c>const D2D1_RECT_F &amp;</c></para>
			/// <para>The size and position of the clipping area, in device-independent pixels.</para>
			/// </param>
			/// <param name="antialiasMode">
			/// <para>Type: [in] <c>D2D1_ANTIALIAS_MODE</c></para>
			/// <para>
			/// The antialiasing mode that is used to draw the edges of clip rects that have subpixel boundaries, and to blend the clip with
			/// the scene contents. The blending is performed once when the PopAxisAlignedClip method is called, and does not apply to each
			/// primitive within the layer.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// The clipRect is transformed by the current world transform set on the render target. After the transform is applied to the
			/// clipRect that is passed in, the axis-aligned bounding box for the clipRect is computed. For efficiency, the contents are
			/// clipped to this axis-aligned bounding box and not to the original clipRect that is passed in.
			/// </para>
			/// <para>
			/// The following diagrams show how a rotation transform is applied to the render target, the resulting clipRect, and a
			/// calculated axis-aligned bounding box.
			/// </para>
			/// <list type="number">
			/// <item>
			/// <term>Assume the rectangle in the following illustration is a render target that is aligned to the screen pixels.</term>
			/// </item>
			/// <item>
			/// <term>
			/// Apply a rotation transform to the render target. In the following illustration, the black rectangle represents the original
			/// render target and the red dashed rectangle represents the transformed render target.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// After calling <c>PushAxisAlignedClip</c>, the rotation transform is applied to the clipRect. In the following illustration,
			/// the blue rectangle represents the transformed clipRect.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// The axis-aligned bounding box is calculated. The green dashed rectangle represents the bounding box in the following
			/// illustration. All contents are clipped to this axis-aligned bounding box.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// <c>Note</c> If rendering operations fail or if PopAxisAlignedClip is not called, clip rects may cause some artifacts on the
			/// render target. <c>PopAxisAlignedClip</c> can be considered a drawing operation that is designed to fix the borders of a
			/// clipping region. Without this call, the borders of a clipped area may be not antialiased or otherwise corrected.
			/// </para>
			/// <para>
			/// The <c>PushAxisAlignedClip</c> and PopAxisAlignedClip must match. Otherwise, the error state is set. For the render target
			/// to continue receiving new commands, you can call Flush to clear the error.
			/// </para>
			/// <para>
			/// A <c>PushAxisAlignedClip</c> and PopAxisAlignedClip pair can occur around or within a PushLayer and PopLayer, but cannot
			/// overlap. For example, the sequence of <c>PushAxisAlignedClip</c>, PushLayer, PopLayer, <c>PopAxisAlignedClip</c> is valid,
			/// but the sequence of <c>PushAxisAlignedClip</c>, <c>PushLayer</c>, <c>PopAxisAlignedClip</c>, <c>PopLayer</c> is invalid.
			/// </para>
			/// <para>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as PushAxisAlignedClip)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-pushaxisalignedclip(constd2d1_rect_f__d2d1_antialias_mode)
			// void PushAxisAlignedClip( const D2D1_RECT_F &amp; clipRect, D2D1_ANTIALIAS_MODE antialiasMode );
			[PreserveSig]
			new void PushAxisAlignedClip(in D2D_RECT_F clipRect, D2D1_ANTIALIAS_MODE antialiasMode);

			/// <summary>
			/// Removes the last axis-aligned clip from the render target. After this method is called, the clip is no longer applied to
			/// subsequent drawing operations.
			/// </summary>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// A PushAxisAlignedClip/ <c>PopAxisAlignedClip</c> pair can occur around or within a PushLayer/PopLayer pair, but may not
			/// overlap. For example, a <c>PushAxisAlignedClip</c>, <c>PushLayer</c>, <c>PopLayer</c>, <c>PopAxisAlignedClip</c> sequence is
			/// valid, but a <c>PushAxisAlignedClip</c>, <c>PushLayer</c>, <c>PopAxisAlignedClip</c>, <c>PopLayer</c> sequence is not.
			/// </para>
			/// <para><c>PopAxisAlignedClip</c> must be called once for every call to PushAxisAlignedClip.</para>
			/// <para>For an example, see How to Clip with an Axis-Aligned Clip Rectangle.</para>
			/// <para>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
			/// <c>PopAxisAlignedClip</c>) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-popaxisalignedclip void PopAxisAlignedClip();
			[PreserveSig]
			new void PopAxisAlignedClip();

			/// <summary>Clears the drawing area to the specified color.</summary>
			/// <param name="clearColor">
			/// <para>Type: [in] <c>const D2D1_COLOR_F &amp;</c></para>
			/// <para>The color to which the drawing area is cleared.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// Direct2D interprets the clearColor as straight alpha (not premultiplied). If the render target's alpha mode is
			/// D2D1_ALPHA_MODE_IGNORE, the alpha channel of clearColor is ignored and replaced with 1.0f (fully opaque).
			/// </para>
			/// <para>
			/// If the render target has an active clip (specified by PushAxisAlignedClip), the clear command is applied only to the area
			/// within the clip region.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-clear(constd2d1_color_f_) void Clear( const
			// D2D1_COLOR_F &amp; clearColor );
			[PreserveSig]
			new void Clear([In, Optional] IntPtr clearColor);

			/// <summary>Initiates drawing on this render target.</summary>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>Drawing operations can only be issued between a <c>BeginDraw</c> and EndDraw call.</para>
			/// <para>
			/// BeginDraw and EndDraw are used to indicate that a render target is in use by the Direct2D system. Different implementations
			/// of ID2D1RenderTarget might behave differently when <c>BeginDraw</c> is called. An ID2D1BitmapRenderTarget may be locked
			/// between <c>BeginDraw</c>/EndDraw calls, a DXGI surface render target might be acquired on <c>BeginDraw</c> and released on
			/// <c>EndDraw</c>, while an ID2D1HwndRenderTarget may begin batching at <c>BeginDraw</c> and may present on <c>EndDraw</c>, for example.
			/// </para>
			/// <para>
			/// The BeginDraw method must be called before rendering operations can be called, though state-setting and state-retrieval
			/// operations can be performed even outside of <c>BeginDraw</c>/EndDraw.
			/// </para>
			/// <para>
			/// After <c>BeginDraw</c> is called, a render target will normally build up a batch of rendering commands, but defer processing
			/// of these commands until either an internal buffer is full, the Flush method is called, or until EndDraw is called. The
			/// <c>EndDraw</c> method causes any batched drawing operations to complete, and then returns an HRESULT indicating the success
			/// of the operations and, optionally, the tag state of the render target at the time the error occurred. The <c>EndDraw</c>
			/// method always succeeds: it should not be called twice even if a previous <c>EndDraw</c> resulted in a failing HRESULT.
			/// </para>
			/// <para>
			/// If EndDraw is called without a matched call to <c>BeginDraw</c>, it returns an error indicating that <c>BeginDraw</c> must
			/// be called before <c>EndDraw</c>.
			/// </para>
			/// <para>
			/// Calling <c>BeginDraw</c> twice on a render target puts the target into an error state where nothing further is drawn, and
			/// returns an appropriate HRESULT and error information when <c>EndDraw</c> is called.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-begindraw void BeginDraw();
			[PreserveSig]
			new void BeginDraw();

			/// <summary>Ends drawing operations on the render target and indicates the current error state and associated tags.</summary>
			/// <param name="tag1">
			/// <para>Type: <c>D2D1_TAG*</c></para>
			/// <para>
			/// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors. This
			/// parameter is passed uninitialized.
			/// </para>
			/// </param>
			/// <param name="tag2">
			/// <para>Type: <c>D2D1_TAG*</c></para>
			/// <para>
			/// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors. This
			/// parameter is passed uninitialized.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>
			/// If the method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code and sets tag1 and tag2 to
			/// the tags that were active when the error occurred.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>Drawing operations can only be issued between a BeginDraw and <c>EndDraw</c> call.</para>
			/// <para>
			/// BeginDraw and <c>EndDraw</c> are use to indicate that a render target is in use by the Direct2D system. Different
			/// implementations of ID2D1RenderTarget might behave differently when <c>BeginDraw</c> is called. An ID2D1BitmapRenderTarget
			/// may be locked between <c>BeginDraw</c>/ <c>EndDraw</c> calls, a DXGI surface render target might be acquired on
			/// <c>BeginDraw</c> and released on <c>EndDraw</c>, while an ID2D1HwndRenderTarget may begin batching at <c>BeginDraw</c> and
			/// may present on <c>EndDraw</c>, for example.
			/// </para>
			/// <para>
			/// The BeginDraw method must be called before rendering operations can be called, though state-setting and state-retrieval
			/// operations can be performed even outside of <c>BeginDraw</c>/ <c>EndDraw</c>.
			/// </para>
			/// <para>
			/// After BeginDraw is called, a render target will normally build up a batch of rendering commands, but defer processing of
			/// these commands until either an internal buffer is full, the Flush method is called, or until <c>EndDraw</c> is called. The
			/// <c>EndDraw</c> method causes any batched drawing operations to complete, and then returns an <c>HRESULT</c> indicating the
			/// success of the operations and, optionally, the tag state of the render target at the time the error occurred. The
			/// <c>EndDraw</c> method always succeeds: it should not be called twice even if a previous <c>EndDraw</c> resulted in a failing <c>HRESULT</c>.
			/// </para>
			/// <para>
			/// If <c>EndDraw</c> is called without a matched call to BeginDraw, it returns an error indicating that <c>BeginDraw</c> must
			/// be called before <c>EndDraw</c>.
			/// </para>
			/// <para>
			/// Calling <c>BeginDraw</c> twice on a render target puts the target into an error state where nothing further is drawn, and
			/// returns an appropriate <c>HRESULT</c> and error information when <c>EndDraw</c> is called.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-enddraw HRESULT EndDraw( D2D1_TAG *tag1,
			// D2D1_TAG *tag2 );
			new void EndDraw(out ulong tag1, out ulong tag2);

			/// <summary>Retrieves the pixel format and alpha mode of the render target.</summary>
			/// <returns>
			/// <para>Type: <c>D2D1_PIXEL_FORMAT</c></para>
			/// <para>The pixel format and alpha mode of the render target.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getpixelformat D2D1_PIXEL_FORMAT GetPixelFormat();
			[PreserveSig]
			new D2D1_PIXEL_FORMAT GetPixelFormat();

			/// <summary>Sets the dots per inch (DPI) of the render target.</summary>
			/// <param name="dpiX">
			/// <para>Type: <c>FLOAT</c></para>
			/// <para>A value greater than or equal to zero that specifies the horizontal DPI of the render target.</para>
			/// </param>
			/// <param name="dpiY">
			/// <para>Type: <c>FLOAT</c></para>
			/// <para>A value greater than or equal to zero that specifies the vertical DPI of the render target.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// This method specifies the mapping from pixel space to device-independent space for the render target. If both dpiX and dpiY
			/// are 0, the factory-read system DPI is chosen. If one parameter is zero and the other unspecified, the DPI is not changed.
			/// </para>
			/// <para>
			/// For ID2D1HwndRenderTarget, the DPI defaults to the most recently factory-read system DPI. The default value for all other
			/// render targets is 96 DPI.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-setdpi void SetDpi( FLOAT dpiX, FLOAT dpiY );
			[PreserveSig]
			new void SetDpi(float dpiX, float dpiY);

			/// <summary>Return the render target's dots per inch (DPI).</summary>
			/// <param name="dpiX">
			/// <para>Type: <c>FLOAT*</c></para>
			/// <para>When this method returns, contains the horizontal DPI of the render target. This parameter is passed uninitialized.</para>
			/// </param>
			/// <param name="dpiY">
			/// <para>Type: <c>FLOAT*</c></para>
			/// <para>When this method returns, contains the vertical DPI of the render target. This parameter is passed uninitialized.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>This method indicates the mapping from pixel space to device-independent space for the render target.</para>
			/// <para>
			/// For ID2D1HwndRenderTarget, the DPI defaults to the most recently factory-read system DPI. The default value for all other
			/// render targets is 96 DPI.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getdpi void GetDpi( FLOAT *dpiX, FLOAT
			// *dpiY );
			[PreserveSig]
			new void GetDpi(out float dpiX, out float dpiY);

			/// <summary>Returns the size of the render target in device-independent pixels.</summary>
			/// <returns>
			/// <para>Type: <c>D2D1_SIZE_F</c></para>
			/// <para>The current size of the render target in device-independent pixels.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getsize D2D1_SIZE_F GetSize();
			[PreserveSig]
			new D2D_SIZE_F GetSize();

			/// <summary>Returns the size of the render target in device pixels.</summary>
			/// <returns>
			/// <para>Type: <c>D2D1_SIZE_U</c></para>
			/// <para>The size of the render target in device pixels.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getpixelsize D2D1_SIZE_U GetPixelSize();
			[PreserveSig]
			new D2D_SIZE_U GetPixelSize();

			/// <summary>
			/// Gets the maximum size, in device-dependent units (pixels), of any one bitmap dimension supported by the render target.
			/// </summary>
			/// <returns>
			/// <para>Type: <c>UINT32</c></para>
			/// <para>The maximum size, in pixels, of any one bitmap dimension supported by the render target.</para>
			/// </returns>
			/// <remarks>
			/// <para>This method returns the maximum texture size of the Direct3D device.</para>
			/// <para>
			/// <c>Note</c> The software renderer and WARP devices return the value of 16 megapixels (16*1024*1024). You can create a
			/// Direct2D texture that is this size, but not a Direct3D texture that is this size.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getmaximumbitmapsize UINT32 GetMaximumBitmapSize();
			[PreserveSig]
			new uint GetMaximumBitmapSize();

			/// <summary>Indicates whether the render target supports the specified properties.</summary>
			/// <param name="renderTargetProperties">
			/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES*</c></para>
			/// <para>The render target properties to test.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>BOOL</c></para>
			/// <para><c>TRUE</c> if the specified render target properties are supported by this render target; otherwise, <c>FALSE</c>.</para>
			/// </returns>
			/// <remarks>This method does not evaluate the DPI settings specified by the renderTargetProperties parameter.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-issupported(constd2d1_render_target_properties_)
			// BOOL IsSupported( const D2D1_RENDER_TARGET_PROPERTIES &amp; renderTargetProperties );
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool IsSupported(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

			/// <summary>Retrieves the bitmap for this render target. The returned bitmap can be used for drawing operations.</summary>
			/// <returns>
			/// <para>Type: <c>ID2D1Bitmap**</c></para>
			/// <para>
			/// When this method returns, contains the address of a pointer to the bitmap for this render target. This bitmap can be used
			/// for drawing operations.
			/// </para>
			/// </returns>
			/// <remarks>
			/// The DPI for the ID2D1Bitmap obtained from <c>GetBitmap</c> will be the DPI of the ID2D1BitmapRenderTarget when the render
			/// target was created. Changing the DPI of the <c>ID2D1BitmapRenderTarget</c> by calling SetDpi doesn't affect the DPI of the
			/// bitmap, even if <c>SetDpi</c> is called before <c>GetBitmap</c>. Using <c>SetDpi</c> to change the DPI of the
			/// <c>ID2D1BitmapRenderTarget</c> does affect how contents are rendered into the bitmap: it just doesn't affect the DPI of the
			/// bitmap retrieved by <c>GetBitmap</c>.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmaprendertarget-getbitmap HRESULT GetBitmap(
			// ID2D1Bitmap **bitmap );
			ID2D1Bitmap GetBitmap();
		}

		/// <summary>Defines an object that paints an area. Interfaces that derive from <c>ID2D1Brush</c> describe how the area is painted.</summary>
		/// <remarks>
		/// <para>
		/// An ID2D1BitmapBrush is a device-dependent resource: your application should create bitmap brushes after it initializes the
		/// render target with which the bitmap brush will be used, and recreate the bitmap brush whenever the render target needs
		/// recreated. (For more information about resources, see Resources Overview.)
		/// </para>
		/// <para>
		/// Brush space in Direct2D is specified differently than in XPS and Windows Presentation Foundation (WPF). In Direct2D, brush space
		/// is not relative to the object being drawn, but rather is the current coordinate system of the render target, transformed by the
		/// brush transform, if present. To paint an object as it would be painted by a WPF brush, you must translate the brush space origin
		/// to the upper-left corner of the object's bounding box, and then scale the brush space so that the base tile fills the bounding
		/// box of the object.
		/// </para>
		/// <para>For more information about brushes, see the Brushes Overview.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1brush
		[PInvokeData("d2d1.h", MSDNShortId = "5b8f6ff8-ba52-4d30-9bea-3de89793c868")]
		[ComImport, Guid("2cd906a8-12e2-11dc-9fed-001143a055f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ID2D1Brush : ID2D1Resource
		{
			/// <summary>Retrieves the factory associated with this resource.</summary>
			/// <param name="factory">
			/// <para>Type: <c>ID2D1Factory**</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is
			/// passed uninitialized.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
			// **factory );
			[PreserveSig]
			new void GetFactory(out ID2D1Factory factory);

			/// <summary>Sets the degree of opacity of this brush.</summary>
			/// <param name="opacity">
			/// <para>Type: <c>FLOAT</c></para>
			/// <para>
			/// A value between zero and 1 that indicates the opacity of the brush. This value is a constant multiplier that linearly scales
			/// the alpha value of all pixels filled by the brush. The opacity values are clamped in the range 0–1 before they are multipled together.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1brush-setopacity void SetOpacity( FLOAT opacity );
			[PreserveSig]
			void SetOpacity(float opacity);

			/// <summary>Sets the transformation applied to the brush.</summary>
			/// <param name="transform">
			/// <para>Type: <c>const D2D1_MATRIX_3X2_F</c></para>
			/// <para>The transformation to apply to this brush.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// When you paint with a brush, it paints in the coordinate space of the render target. Brushes do not automatically position
			/// themselves to align with the object being painted; by default, they begin painting at the origin (0, 0) of the render target.
			/// </para>
			/// <para>
			/// You can "move" the gradient defined by an ID2D1LinearGradientBrush to a target area by setting its start point and end
			/// point. Likewise, you can move the gradient defined by an ID2D1RadialGradientBrush by changing its center and radii.
			/// </para>
			/// <para>
			/// To align the content of an ID2D1BitmapBrush to the area being painted, you can use the SetTransform method to translate the
			/// bitmap to the desired location. This transform only affects the brush; it does not affect any other content drawn by the
			/// render target.
			/// </para>
			/// <para>
			/// The following illustrations show the effect of using an ID2D1BitmapBrush to fill a rectangle located at (100, 100). The
			/// illustration on the left illustration shows the result of filling the rectangle without transforming the brush: the bitmap
			/// is drawn at the render target's origin. As a result, only a portion of the bitmap appears in the rectangle.
			/// </para>
			/// <para>
			/// The illustration on the right shows the result of transforming the ID2D1BitmapBrush so that its content is shifted 50 pixels
			/// to the right and 50 pixels down. The bitmap now fills the rectangle.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1brush-settransform(constd2d1_matrix_3x2_f_) void
			// SetTransform( const D2D1_MATRIX_3X2_F &amp; transform );
			[PreserveSig]
			void SetTransform(in D2D_MATRIX_3X2_F transform);

			/// <summary>Gets the degree of opacity of this brush.</summary>
			/// <returns>
			/// <para>Type: <c>FLOAT</c></para>
			/// <para>
			/// A value between zero and 1 that indicates the opacity of the brush. This value is a constant multiplier that linearly scales
			/// the alpha value of all pixels filled by the brush. The opacity values are clamped in the range 0–1 before they are multipled together.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1brush-getopacity FLOAT GetOpacity();
			[PreserveSig]
			float GetOpacity();

			/// <summary>Gets the transform applied to this brush.</summary>
			/// <param name="transform">
			/// <para>Type: <c>D2D1_MATRIX_3X2_F*</c></para>
			/// <para>The transform applied to this brush.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// When the brush transform is the identity matrix, the brush appears in the same coordinate space as the render target in
			/// which it is drawn.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1brush-gettransform void GetTransform( D2D1_MATRIX_3X2_F
			// *transform );
			[PreserveSig]
			void GetTransform(out D2D_MATRIX_3X2_F transform);
		}

		/// <summary>Issues drawing commands to a GDI device context.</summary>
		/// <remarks>
		/// <para>Creating ID2D1DCRenderTarget Objects</para>
		/// <para>To create an <c>ID2D1DCRenderTarget</c>, use the ID2D1Factory::CreateDCRenderTarget method.</para>
		/// <para>
		/// Before you can render with the DC render target, you must use its BindDC method to associate it with a GDI DC. You do this each
		/// time you use a different DC, or the size of the area you want to draw to changes.
		/// </para>
		/// <para>
		/// To enable the DC render target to work with GDI, set its pixel format to DXGI_FORMAT_B8G8R8A8_UNORM and its alpha mode to
		/// D2D1_ALPHA_MODE_PREMULTIPLIED or <c>D2D1_ALPHA_MODE_IGNORE</c>.
		/// </para>
		/// <para>
		/// Your application should create render targets once and hold onto them for the life of the application or until the render
		/// target's EndDraw method returns the D2DERR_RECREATE_TARGET error. When you receive this error, you need to recreate the render
		/// target (and any resources it created).
		/// </para>
		/// <para>ID2D1DCRenderTargets, GDI Transforms, and Right-to-Left Language Builds of Windows</para>
		/// <para>
		/// When you use an <c>ID2D1DCRenderTarget</c>, it renders Direct2D content to an internal bitmap, and then renders the bitmap to
		/// the DC with GDI.
		/// </para>
		/// <para>
		/// It's possible for GDI to apply a GDI transform (through the SetWorldTransform method) or other effect to the same DC used by the
		/// render target, in which case GDI transforms the bitmap produced by Direct2D. Using a GDI transform to transform the Direct2D
		/// content has the potential to degrade the visual quality of the output, because you're transforming a bitmap for which
		/// antialiasing and subpixel positioning have already been calculated.
		/// </para>
		/// <para>
		/// For example, suppose you use the render target to draw a scene that contains antialiased geometries and text. If you use a GDI
		/// transform to apply a scale transform to the DC and scale the scene so that it's 10 times larger, you'll see pixelization and
		/// jagged edges. (If, however, you applied a similar transform using Direct2D, the visual quality of the scene would not be degraded.)
		/// </para>
		/// <para>
		/// In some cases, it might not be obvious that GDI is performing additional processing that might degrade the quality of the
		/// Direct2D content. For example, on a right-to-left (RTL) build of Windows, content rendered by an <c>ID2D1DCRenderTarget</c>
		/// might be horizontally inverted when GDI copies it to its destination. Whether the content is actually inverted depends on the
		/// current settings of the DC.
		/// </para>
		/// <para>
		/// Depending on the type of content being rendered, you might want to prevent the inversion. If the Direct2D content includes
		/// ClearType text, this inversion will degrade the quality of the text.
		/// </para>
		/// <para>
		/// You can control RTL rendering behavior by using the SetLayout GDI function. To prevent the mirroring, call the <c>SetLayout</c>
		/// GDI function and specify <c>LAYOUT_BITMAPORIENTATIONPRESERVED</c> as the only value for the second parameter (do not combine it
		/// with <c>LAYOUT_RTL</c>), as shown in the following example:
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1dcrendertarget
		[PInvokeData("d2d1.h", MSDNShortId = "6546998e-6740-413a-88c5-36fa0decec8f")]
		[ComImport, Guid("1c51bc64-de61-46fd-9899-63a5d8f03950"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ID2D1DCRenderTarget : ID2D1RenderTarget
		{
			/// <summary>Retrieves the factory associated with this resource.</summary>
			/// <param name="factory">
			/// <para>Type: <c>ID2D1Factory**</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is
			/// passed uninitialized.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
			// **factory );
			[PreserveSig]
			new void GetFactory(out ID2D1Factory factory);

			/// <summary>Creates a Direct2D bitmap from a pointer to in-memory source data.</summary>
			/// <param name="size">
			/// <para>Type: [in] <c>D2D1_SIZE_U</c></para>
			/// <para>The dimensions of the bitmap to create in pixels.</para>
			/// </param>
			/// <param name="srcData">
			/// <para>Type: [in, optional] <c>const void*</c></para>
			/// <para>A pointer to the memory location of the image data, or <c>NULL</c> to create an uninitialized bitmap.</para>
			/// </param>
			/// <param name="pitch">
			/// <para>Type: [in] <c>UINT32</c></para>
			/// <para>
			/// The byte count of each scanline, which is equal to (the image width in pixels × the number of bytes per pixel) + memory
			/// padding. If srcData is <c>NULL</c>, this value is ignored. (Note that pitch is also sometimes called stride.)
			/// </para>
			/// </param>
			/// <param name="bitmapProperties">
			/// <para>Type: [in] <c>const D2D1_BITMAP_PROPERTIES &amp;</c></para>
			/// <para>The pixel format and dots per inch (DPI) of the bitmap to create.</para>
			/// </param>
			/// <returns>
			/// <para>Type: [out] <c>ID2D1Bitmap**</c></para>
			/// <para>When this method returns, contains a pointer to a pointer to the new bitmap. This parameter is passed uninitialized.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createbitmap(d2d1_size_u_constvoid_uint32_constd2d1_bitmap_properties__id2d1bitmap)
			// HRESULT CreateBitmap( D2D1_SIZE_U size, const void *srcData, UINT32 pitch, const D2D1_BITMAP_PROPERTIES &amp;
			// bitmapProperties, ID2D1Bitmap **bitmap );
			new ID2D1Bitmap CreateBitmap(D2D_SIZE_U size, [In, Optional] IntPtr srcData, uint pitch, in D2D1_BITMAP_PROPERTIES bitmapProperties);

			/// <summary>Creates an ID2D1Bitmap by copying the specified Microsoft Windows Imaging Component (WIC) bitmap.</summary>
			/// <param name="wicBitmapSource">
			/// <para>Type: [in] <c>IWICBitmapSource*</c></para>
			/// <para>The WIC bitmap to copy.</para>
			/// </param>
			/// <param name="bitmapProperties">
			/// <para>Type: [in, optional] <c>const D2D1_BITMAP_PROPERTIES*</c></para>
			/// <para>
			/// The pixel format and DPI of the bitmap to create. The pixel format must match the pixel format of wicBitmapSource, or the
			/// method will fail. To prevent a mismatch, you can pass <c>NULL</c> or pass the value obtained from calling the
			/// D2D1::PixelFormat helper function without specifying any parameter values. If both dpiX and dpiY are 0.0f, the default DPI,
			/// 96, is used. DPI information embedded in wicBitmapSource is ignored.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ID2D1Bitmap**</c></para>
			/// <para>When this method returns, contains the address of a pointer to the new bitmap. This parameter is passed uninitialized.</para>
			/// </returns>
			/// <remarks>
			/// Before Direct2D can load a WIC bitmap, that bitmap must be converted to a supported pixel format and alpha mode. For a list
			/// of supported pixel formats and alpha modes, see Supported Pixel Formats and Alpha Modes.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createbitmapfromwicbitmap(iwicbitmapsource_constd2d1_bitmap_properties_id2d1bitmap)
			// HRESULT CreateBitmapFromWicBitmap( IWICBitmapSource *wicBitmapSource, const D2D1_BITMAP_PROPERTIES *bitmapProperties,
			// ID2D1Bitmap **bitmap );
			new ID2D1Bitmap CreateBitmapFromWicBitmap(IWICBitmapSource wicBitmapSource, [In, Optional] IntPtr bitmapProperties);

			/// <summary>Creates an ID2D1Bitmap whose data is shared with another resource.</summary>
			/// <param name="riid">
			/// <para>Type: <c>REFIID</c></para>
			/// <para>The interface ID of the object supplying the source data.</para>
			/// </param>
			/// <param name="data">
			/// <para>Type: <c>void*</c></para>
			/// <para>
			/// An ID2D1Bitmap, IDXGISurface, or an IWICBitmapLock that contains the data to share with the new <c>ID2D1Bitmap</c>. For more
			/// information, see the Remarks section.
			/// </para>
			/// </param>
			/// <param name="bitmapProperties">
			/// <para>Type: <c>D2D1_BITMAP_PROPERTIES*</c></para>
			/// <para>
			/// The pixel format and DPI of the bitmap to create . The DXGI_FORMAT portion of the pixel format must match the DXGI_FORMAT of
			/// data or the method will fail, but the alpha modes don't have to match. To prevent a mismatch, you can pass <c>NULL</c> or
			/// the value obtained from the D2D1::PixelFormat helper function. The DPI settings do not have to match those of data. If both
			/// dpiX and dpiY are 0.0f, the DPI of the render target is used.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ID2D1Bitmap**</c></para>
			/// <para>When this method returns, contains the address of a pointer to the new bitmap. This parameter is passed uninitialized.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The <c>CreateSharedBitmap</c> method is useful for efficiently reusing bitmap data and can also be used to provide
			/// interoperability with Direct3D.
			/// </para>
			/// <para>Sharing an ID2D1Bitmap</para>
			/// <para>
			/// By passing an ID2D1Bitmap created by a render target that is resource-compatible, you can share a bitmap with that render
			/// target; both the original <c>ID2D1Bitmap</c> and the new <c>ID2D1Bitmap</c> created by this method will point to the same
			/// bitmap data. For more information about when render target resources can be shared, see the Sharing Render Target Resources
			/// section of the Resources Overview.
			/// </para>
			/// <para>
			/// You may also use this method to reinterpret the data of an existing bitmap and specify a new DPI or alpha mode. For example,
			/// in the case of a bitmap atlas, an ID2D1Bitmap may contain multiple sub-images, each of which should be rendered with a
			/// different D2D1_ALPHA_MODE ( <c>D2D1_ALPHA_MODE_PREMULTIPLIED</c> or <c>D2D1_ALPHA_MODE_IGNORE</c>). You could use the
			/// <c>CreateSharedBitmap</c> method to reinterpret the bitmap using the desired alpha mode without having to load a separate
			/// copy of the bitmap into memory.
			/// </para>
			/// <para>Sharing an IDXGISurface</para>
			/// <para>
			/// When using a DXGI surface render target (an ID2D1RenderTarget object created by the CreateDxgiSurfaceRenderTarget method),
			/// you can pass an IDXGISurface surface to the <c>CreateSharedBitmap</c> method to share video memory with Direct3D and
			/// manipulate Direct3D content as an ID2D1Bitmap. As described in the Resources Overview, the render target and the
			/// IDXGISurface must be using the same Direct3D device.
			/// </para>
			/// <para>
			/// Note also that the IDXGISurface must use one of the supported pixel formats and alpha modes described in Supported Pixel
			/// Formats and Alpha Modes.
			/// </para>
			/// <para>For more information about interoperability with Direct3D, see the Direct2D and Direct3D Interoperability Overview.</para>
			/// <para>Sharing an IWICBitmapLock</para>
			/// <para>
			/// An IWICBitmapLock stores the content of a WIC bitmap and shields it from simultaneous accesses. By passing an
			/// <c>IWICBitmapLock</c> to the <c>CreateSharedBitmap</c> method, you can create an ID2D1Bitmap that points to the bitmap data
			/// already stored in the <c>IWICBitmapLock</c>.
			/// </para>
			/// <para>
			/// To use an IWICBitmapLock with the <c>CreateSharedBitmap</c> method, the render target must use software rendering. To force
			/// a render target to use software rendering, set to D2D1_RENDER_TARGET_TYPE_SOFTWARE the <c>type</c> field of the
			/// D2D1_RENDER_TARGET_PROPERTIES structure that you use to create the render target. To check whether an existing render target
			/// uses software rendering, use the IsSupported method.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createsharedbitmap HRESULT
			// CreateSharedBitmap( REFIID riid, void *data, const D2D1_BITMAP_PROPERTIES *bitmapProperties, ID2D1Bitmap **bitmap );
			new ID2D1Bitmap CreateSharedBitmap(in Guid riid, [In, Out] IntPtr data, [In, Optional] IntPtr bitmapProperties);

			/// <summary>Creates an ID2D1BitmapBrush from the specified bitmap.</summary>
			/// <param name="bitmap">
			/// <para>Type: <c>ID2D1Bitmap*</c></para>
			/// <para>The bitmap contents of the new brush.</para>
			/// </param>
			/// <param name="bitmapBrushProperties">
			/// <para>Type: <c>D2D1_BITMAP_BRUSH_PROPERTIES*</c></para>
			/// <para>
			/// The extend modes and interpolation mode of the new brush, or <c>NULL</c>. If you set this parameter to <c>NULL</c>, the
			/// brush defaults to the D2D1_EXTEND_MODE_CLAMP horizontal and vertical extend modes and the
			/// D2D1_BITMAP_INTERPOLATION_MODE_LINEAR interpolation mode.
			/// </para>
			/// </param>
			/// <param name="brushProperties">
			/// <para>Type: <c>D2D1_BRUSH_PROPERTIES*</c></para>
			/// <para>
			/// A structure that contains the opacity and transform of the new brush, or <c>NULL</c>. If you set this parameter to
			/// <c>NULL</c>, the brush sets the opacity member to 1.0F and the transform member to the identity matrix.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>ID2D1BitmapBrush**</c></para>
			/// <para>
			/// When this method returns, this output parameter contains a pointer to a pointer to the new brush. Pass this parameter uninitialized.
			/// </para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createbitmapbrush(id2d1bitmap_constd2d1_bitmap_brush_properties_constd2d1_brush_properties_id2d1bitmapbrush)
			// HRESULT CreateBitmapBrush( ID2D1Bitmap *bitmap, const D2D1_BITMAP_BRUSH_PROPERTIES *bitmapBrushProperties, const
			// D2D1_BRUSH_PROPERTIES *brushProperties, ID2D1BitmapBrush **bitmapBrush );
			new ID2D1BitmapBrush CreateBitmapBrush([In, Optional] ID2D1Bitmap bitmap, [In, Optional] IntPtr bitmapBrushProperties, [In, Optional] IntPtr brushProperties);

			/// <summary>Creates a new ID2D1SolidColorBrush that has the specified color and opacity.</summary>
			/// <param name="color">
			/// <para>Type: [in] <c>const D2D1_COLOR_F &amp;</c></para>
			/// <para>The red, green, blue, and alpha values of the brush's color.</para>
			/// </param>
			/// <param name="brushProperties">
			/// <para>Type: [in] <c>const D2D1_BRUSH_PROPERTIES &amp;</c></para>
			/// <para>The base opacity of the brush.</para>
			/// </param>
			/// <returns>
			/// <para>Type: [out] <c>ID2D1SolidColorBrush**</c></para>
			/// <para>When this method returns, contains the address of a pointer to the new brush. This parameter is passed uninitialized.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createsolidcolorbrush(constd2d1_color_f__constd2d1_brush_properties__id2d1solidcolorbrush)
			// HRESULT CreateSolidColorBrush( const D2D1_COLOR_F &amp; color, const D2D1_BRUSH_PROPERTIES &amp; brushProperties,
			// ID2D1SolidColorBrush **solidColorBrush );
			new ID2D1SolidColorBrush CreateSolidColorBrush(in D3DCOLORVALUE color, [In, Optional] IntPtr brushProperties);

			/// <summary>Creates an ID2D1GradientStopCollection from the specified array of D2D1_GRADIENT_STOP structures.</summary>
			/// <param name="gradientStops">
			/// <para>Type: [in] <c>D2D1_GRADIENT_STOP*</c></para>
			/// <para>A pointer to an array of D2D1_GRADIENT_STOP structures.</para>
			/// </param>
			/// <param name="gradientStopsCount">
			/// <para>Type: [in] <c>UINT</c></para>
			/// <para>A value greater than or equal to 1 that specifies the number of gradient stops in the gradientStops array.</para>
			/// </param>
			/// <param name="colorInterpolationGamma">
			/// <para>Type: [in] <c>D2D1_GAMMA</c></para>
			/// <para>The space in which color interpolation between the gradient stops is performed.</para>
			/// </param>
			/// <param name="extendMode">
			/// <para>Type: [in] <c>D2D1_EXTEND_MODE</c></para>
			/// <para>The behavior of the gradient outside the [0,1] normalized range.</para>
			/// </param>
			/// <returns>
			/// <para>Type: [out] <c>ID2D1GradientStopCollection**</c></para>
			/// <para>When this method returns, contains a pointer to a pointer to the new gradient stop collection.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-creategradientstopcollection%28constd2d1_gradient_stop_uint32_d2d1_gamma_d2d1_extend_mode_id2d1gradientstopcollection%29
			// HRESULT CreateGradientStopCollection( const D2D1_GRADIENT_STOP *gradientStops, UINT32 gradientStopsCount, D2D1_GAMMA
			// colorInterpolationGamma, D2D1_EXTEND_MODE extendMode, ID2D1GradientStopCollection **gradientStopCollection );
			new ID2D1GradientStopCollection CreateGradientStopCollection([In] D2D1_GRADIENT_STOP[] gradientStops, uint gradientStopsCount, D2D1_GAMMA colorInterpolationGamma, D2D1_EXTEND_MODE extendMode);

			/// <summary>Creates an ID2D1LinearGradientBrush object for painting areas with a linear gradient.</summary>
			/// <param name="linearGradientBrushProperties">
			/// <para>Type: [in] <c>const D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES*</c></para>
			/// <para>The start and end points of the gradient.</para>
			/// </param>
			/// <param name="brushProperties">
			/// <para>Type: [in] <c>const D2D1_BRUSH_PROPERTIES*</c></para>
			/// <para>The transform and base opacity of the new brush.</para>
			/// </param>
			/// <param name="gradientStopCollection">
			/// <para>Type: [in] <c>ID2D1GradientStopCollection*</c></para>
			/// <para>
			/// A collection of D2D1_GRADIENT_STOP structures that describe the colors in the brush's gradient and their locations along the
			/// gradient line.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: [out] <c>ID2D1LinearGradientBrush**</c></para>
			/// <para>When this method returns, contains the address of a pointer to the new brush. This parameter is passed uninitialized.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createlineargradientbrush%28constd2d1_linear_gradient_brush_properties_constd2d1_brush_properties_id2d1gradientstopcollection_id2d1lineargradientbrush%29
			// HRESULT CreateLinearGradientBrush( const D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES *linearGradientBrushProperties, const
			// D2D1_BRUSH_PROPERTIES *brushProperties, ID2D1GradientStopCollection *gradientStopCollection, ID2D1LinearGradientBrush
			// **linearGradientBrush );
			new ID2D1LinearGradientBrush CreateLinearGradientBrush(in D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES linearGradientBrushProperties, [In, Optional] IntPtr brushProperties, [In] ID2D1GradientStopCollection gradientStopCollection);

			/// <summary>Creates an ID2D1RadialGradientBrush object that can be used to paint areas with a radial gradient.</summary>
			/// <param name="radialGradientBrushProperties">
			/// <para>Type: <c>const D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES*</c></para>
			/// <para>The center, gradient origin offset, and x-radius and y-radius of the brush's gradient.</para>
			/// </param>
			/// <param name="brushProperties">
			/// <para>Type: [in] <c>const D2D1_BRUSH_PROPERTIES*</c></para>
			/// <para>The transform and base opacity of the new brush.</para>
			/// </param>
			/// <param name="gradientStopCollection">
			/// <para>Type: [in] <c>ID2D1GradientStopCollection*</c></para>
			/// <para>
			/// A collection of D2D1_GRADIENT_STOP structures that describe the colors in the brush's gradient and their locations along the gradient.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: [out] <c>ID2D1RadialGradientBrush**</c></para>
			/// <para>When this method returns, contains a pointer to a pointer to the new brush. This parameter is passed uninitialized.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createradialgradientbrush%28constd2d1_radial_gradient_brush_properties_constd2d1_brush_properties_id2d1gradientstopcollection_id2d1radialgradientbrush%29
			// HRESULT CreateRadialGradientBrush( const D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES *radialGradientBrushProperties, const
			// D2D1_BRUSH_PROPERTIES *brushProperties, ID2D1GradientStopCollection *gradientStopCollection, ID2D1RadialGradientBrush
			// **radialGradientBrush );
			new ID2D1RadialGradientBrush CreateRadialGradientBrush(in D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES radialGradientBrushProperties, [In, Optional] IntPtr brushProperties, [In] ID2D1GradientStopCollection gradientStopCollection);

			/// <summary>
			/// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
			/// </summary>
			/// <param name="desiredSize">
			/// <para>Type: [in] <c>const D2D1_SIZE_F*</c></para>
			/// <para>
			/// The desired size of the new render target (in device-independent pixels), if it should be different from the original render
			/// target. For more info, see the Remarks section.
			/// </para>
			/// </param>
			/// <param name="desiredPixelSize">
			/// <para>Type: [in] <c>const D2D1_SIZE_U*</c></para>
			/// <para>
			/// The desired size of the new render target in pixels if it should be different from the original render target. For more
			/// information, see the Remarks section.
			/// </para>
			/// </param>
			/// <param name="desiredFormat">
			/// <para>Type: [in] <c>const D2D1_PIXEL_FORMAT*</c></para>
			/// <para>
			/// The desired pixel format and alpha mode of the new render target. If the pixel format is set to DXGI_FORMAT_UNKNOWN, the new
			/// render target uses the same pixel format as the original render target. If the alpha mode is D2D1_ALPHA_MODE_UNKNOWN, the
			/// alpha mode of the new render target defaults to <c>D2D1_ALPHA_MODE_PREMULTIPLIED</c>. For information about supported pixel
			/// formats, see Supported Pixel Formats and Alpha Modes.
			/// </para>
			/// </param>
			/// <param name="options">
			/// <para>Type: [in] <c>D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS</c></para>
			/// <para>A value that specifies whether the new render target must be compatible with GDI.</para>
			/// </param>
			/// <returns>
			/// <para>Type: [out] <c>ID2D1BitmapRenderTarget**</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a pointer to a new bitmap render target. This parameter is passed uninitialized.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>The pixel size and DPI of the new render target can be altered by specifying values for desiredSize or desiredPixelSize:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>
			/// If desiredSize is specified but desiredPixelSize is not, the pixel size is computed from the desired size using the parent
			/// target DPI. If the desiredSize maps to a integer-pixel size, the DPI of the compatible render target is the same as the DPI
			/// of the parent target. If desiredSize maps to a fractional-pixel size, the pixel size is rounded up to the nearest integer
			/// and the DPI for the compatible render target is slightly higher than the DPI of the parent render target. In all cases, the
			/// coordinate (desiredSize.width, desiredSize.height) maps to the lower-right corner of the compatible render target.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// If the desiredPixelSize is specified and desiredSize is not, the DPI of the new render target is the same as the original
			/// render target.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// If both desiredSize and desiredPixelSize are specified, the DPI of the new render target is computed to account for the
			/// difference in scale.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// If neither desiredSize nor desiredPixelSize is specified, the new render target size and DPI match the original render target.
			/// </term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createcompatiblerendertarget(constd2d1_size_f_constd2d1_size_u_constd2d1_pixel_format_d2d1_compatible_render_target_options_id2d1bitmaprendertarget)
			// HRESULT CreateCompatibleRenderTarget( const D2D1_SIZE_F *desiredSize, const D2D1_SIZE_U *desiredPixelSize, const
			// D2D1_PIXEL_FORMAT *desiredFormat, D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS options, ID2D1BitmapRenderTarget **bitmapRenderTarget );
			new ID2D1BitmapRenderTarget CreateCompatibleRenderTarget([In, Optional] IntPtr desiredSize, [In, Optional] IntPtr desiredPixelSize, [In, Optional] IntPtr desiredFormat, [In, Optional] D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS options);

			/// <summary>Creates a layer resource that can be used with this render target and its compatible render targets.</summary>
			/// <param name="size">
			/// <para>Type: [in] <c>const D2D1_SIZE_F*</c></para>
			/// <para>
			/// If (0, 0) is specified, no backing store is created behind the layer resource. The layer resource is allocated to the
			/// minimum size when PushLayer is called.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: [out] <c>ID2D1Layer**</c></para>
			/// <para>When the method returns, contains a pointer to a pointer to the new layer. This parameter is passed uninitialized.</para>
			/// </returns>
			/// <remarks>The layer automatically resizes itself, as needed.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createlayer(constd2d1_size_f_id2d1layer)
			// HRESULT CreateLayer( const D2D1_SIZE_F *size, ID2D1Layer **layer );
			new ID2D1Layer CreateLayer([In, Optional] IntPtr size);

			/// <summary>Create a mesh that uses triangles to describe a shape.</summary>
			/// <returns>
			/// <para>Type: <c>ID2D1Mesh**</c></para>
			/// <para>When this method returns, contains a pointer to a pointer to the new mesh.</para>
			/// </returns>
			/// <remarks>
			/// To populate a mesh, use its Open method to obtain an ID2D1TessellationSink. To draw the mesh, use the render target's
			/// FillMesh method.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createmesh HRESULT CreateMesh( ID2D1Mesh
			// **mesh );
			new ID2D1Mesh CreateMesh();

			/// <summary>Draws a line between the specified points using the specified stroke style.</summary>
			/// <param name="point0">
			/// <para>Type: <c>D2D1_POINT_2F</c></para>
			/// <para>The start point of the line, in device-independent pixels.</para>
			/// </param>
			/// <param name="point1">
			/// <para>Type: <c>D2D1_POINT_2F</c></para>
			/// <para>The end point of the line, in device-independent pixels.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the line's stroke.</para>
			/// </param>
			/// <param name="strokeWidth">
			/// <para>Type: <c>FLOAT</c></para>
			/// <para>
			/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter
			/// isn't specified, it defaults to 1.0f. The stroke is centered on the line.
			/// </para>
			/// </param>
			/// <param name="strokeStyle">
			/// <para>Type: <c>ID2D1StrokeStyle*</c></para>
			/// <para>The style of stroke to paint, or <c>NULL</c> to paint a solid line.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>DrawLine</c>)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawline void DrawLine( D2D1_POINT_2F
			// point0, D2D1_POINT_2F point1, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
			[PreserveSig]
			new void DrawLine(D2D_POINT_2F point0, D2D_POINT_2F point1, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle strokeStyle = null);

			/// <summary>Draws the outline of a rectangle that has the specified dimensions and stroke style.</summary>
			/// <param name="rect">
			/// <para>Type: [in] <c>const D2D1_RECT_F &amp;</c></para>
			/// <para>The dimensions of the rectangle to draw, in device-independent pixels.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: [in] <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the rectangle's stroke.</para>
			/// </param>
			/// <param name="strokeWidth">
			/// <para>Type: [in] <c>FLOAT</c></para>
			/// <para>
			/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter
			/// isn't specified, it defaults to 1.0f. The stroke is centered on the line.
			/// </para>
			/// </param>
			/// <param name="strokeStyle">
			/// <para>Type: [in, optional] <c>ID2D1StrokeStyle*</c></para>
			/// <para>The style of stroke to paint, or <c>NULL</c> to paint a solid stroke.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// When this method fails, it does not return an error code. To determine whether a drawing method (such as DrawRectangle)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush method.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawrectangle(constd2d1_rect_f__id2d1brush_float_id2d1strokestyle)
			// void DrawRectangle( const D2D1_RECT_F &amp; rect, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
			[PreserveSig]
			new void DrawRectangle(in D2D_RECT_F rect, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle strokeStyle = null);

			/// <summary>Paints the interior of the specified rectangle.</summary>
			/// <param name="rect">
			/// <para>Type: [in] <c>const D2D1_RECT_F &amp;</c></para>
			/// <para>The dimension of the rectangle to paint, in device-independent pixels.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: [in] <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the rectangle's interior.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as FillRectangle)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillrectangle(constd2d1_rect_f__id2d1brush)
			// void FillRectangle( const D2D1_RECT_F &amp; rect, ID2D1Brush *brush );
			[PreserveSig]
			new void FillRectangle(in D2D_RECT_F rect, [In] ID2D1Brush brush);

			/// <summary>Draws the outline of the specified rounded rectangle using the specified stroke style.</summary>
			/// <param name="roundedRect">
			/// <para>Type: [in] <c>const D2D1_ROUNDED_RECT &amp;</c></para>
			/// <para>The dimensions of the rounded rectangle to draw, in device-independent pixels.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: [in] <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the rounded rectangle's outline.</para>
			/// </param>
			/// <param name="strokeWidth">
			/// <para>Type: [in] <c>FLOAT</c></para>
			/// <para>
			/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter
			/// isn't specified, it defaults to 1.0f. The stroke is centered on the line.
			/// </para>
			/// </param>
			/// <param name="strokeStyle">
			/// <para>Type: [in, optional] <c>ID2D1StrokeStyle*</c></para>
			/// <para>The style of the rounded rectangle's stroke, or <c>NULL</c> to paint a solid stroke. The default value is <c>NULL</c>.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
			/// DrawRoundedRectangle) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawroundedrectangle(constd2d1_rounded_rect__id2d1brush_float_id2d1strokestyle)
			// void DrawRoundedRectangle( const D2D1_ROUNDED_RECT &amp; roundedRect, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle
			// *strokeStyle );
			[PreserveSig]
			new void DrawRoundedRectangle(in D2D1_ROUNDED_RECT roundedRect, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle strokeStyle = null);

			/// <summary>Paints the interior of the specified rounded rectangle.</summary>
			/// <param name="roundedRect">
			/// <para>Type: [in] <c>const D2D1_ROUNDED_RECT &amp;</c></para>
			/// <para>The dimensions of the rounded rectangle to paint, in device independent pixels.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: [in] <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the interior of the rounded rectangle.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
			/// FillRoundedRectangle) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillroundedrectangle(constd2d1_rounded_rect__id2d1brush)
			// void FillRoundedRectangle( const D2D1_ROUNDED_RECT &amp; roundedRect, ID2D1Brush *brush );
			[PreserveSig]
			new void FillRoundedRectangle(in D2D1_ROUNDED_RECT roundedRect, [In] ID2D1Brush brush);

			/// <summary>Draws the outline of the specified ellipse using the specified stroke style.</summary>
			/// <param name="ellipse">
			/// <para>Type: [in] <c>const D2D1_ELLIPSE &amp;</c></para>
			/// <para>The position and radius of the ellipse to draw, in device-independent pixels.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: [in] <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the ellipse's outline.</para>
			/// </param>
			/// <param name="strokeWidth">
			/// <para>Type: [in] <c>FLOAT</c></para>
			/// <para>
			/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter
			/// isn't specified, it defaults to 1.0f. The stroke is centered on the line.
			/// </para>
			/// </param>
			/// <param name="strokeStyle">
			/// <para>Type: [in, optional] <c>ID2D1StrokeStyle*</c></para>
			/// <para>The style of stroke to apply to the ellipse's outline, or <c>NULL</c> to paint a solid stroke.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// The DrawEllipse method doesn't return an error code if it fails. To determine whether a drawing operation (such as
			/// <c>DrawEllipse</c>) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawellipse(constd2d1_ellipse__id2d1brush_float_id2d1strokestyle)
			// void DrawEllipse( const D2D1_ELLIPSE &amp; ellipse, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
			[PreserveSig]
			new void DrawEllipse(in D2D1_ELLIPSE ellipse, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle strokeStyle = null);

			/// <summary>Paints the interior of the specified ellipse.</summary>
			/// <param name="ellipse">
			/// <para>Type: [in] <c>const D2D1_ELLIPSE &amp;</c></para>
			/// <para>The position and radius, in device-independent pixels, of the ellipse to paint.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: [in] <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the interior of the ellipse.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as FillEllipse) failed,
			/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillellipse(constd2d1_ellipse__id2d1brush)
			// void FillEllipse( const D2D1_ELLIPSE &amp; ellipse, ID2D1Brush *brush );
			[PreserveSig]
			new void FillEllipse(in D2D1_ELLIPSE ellipse, [In] ID2D1Brush brush);

			/// <summary>Draws the outline of the specified geometry using the specified stroke style.</summary>
			/// <param name="geometry">
			/// <para>Type: <c>ID2D1Geometry*</c></para>
			/// <para>The geometry to draw.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the geometry's stroke.</para>
			/// </param>
			/// <param name="strokeWidth">
			/// <para>Type: <c>FLOAT</c></para>
			/// <para>
			/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter
			/// isn't specified, it defaults to 1.0f. The stroke is centered on the line.
			/// </para>
			/// </param>
			/// <param name="strokeStyle">
			/// <para>Type: <c>ID2D1StrokeStyle*</c></para>
			/// <para>The style of stroke to apply to the geometry's outline, or <c>NULL</c> to paint a solid stroke.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>DrawGeometry</c>)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawgeometry void DrawGeometry(
			// ID2D1Geometry *geometry, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
			[PreserveSig]
			new void DrawGeometry([In] ID2D1Geometry geometry, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle strokeStyle = null);

			/// <summary>Paints the interior of the specified geometry.</summary>
			/// <param name="geometry">
			/// <para>Type: <c>ID2D1Geometry*</c></para>
			/// <para>The geometry to paint.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the geometry's interior.</para>
			/// </param>
			/// <param name="opacityBrush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>
			/// The opacity mask to apply to the geometry, or <c>NULL</c> for no opacity mask. If an opacity mask (the opacityBrush
			/// parameter) is specified, brush must be an ID2D1BitmapBrush that has its x- and y-extend modes set to D2D1_EXTEND_MODE_CLAMP.
			/// For more information, see the Remarks section.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// If the opacityBrush parameter is not <c>NULL</c>, the alpha value of each pixel of the mapped opacityBrush is used to
			/// determine the resulting opacity of each corresponding pixel of the geometry. Only the alpha value of each color in the brush
			/// is used for this processing; all other color information is ignored.
			/// </para>
			/// <para>
			/// The alpha value specified by the brush is multiplied by the alpha value of the geometry after the geometry has been painted
			/// by brush.
			/// </para>
			/// <para>
			/// When this method fails, it does not return an error code. To determine whether a drawing operation (such as
			/// <c>FillGeometry</c>) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush method.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillgeometry void FillGeometry(
			// ID2D1Geometry *geometry, ID2D1Brush *brush, ID2D1Brush *opacityBrush );
			[PreserveSig]
			new void FillGeometry([In] ID2D1Geometry geometry, [In] ID2D1Brush brush, [In] ID2D1Brush opacityBrush = null);

			/// <summary>Paints the interior of the specified mesh.</summary>
			/// <param name="mesh">
			/// <para>Type: <c>ID2D1Mesh*</c></para>
			/// <para>The mesh to paint.</para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the mesh.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// The current antialias mode of the render target must be D2D1_ANTIALIAS_MODE_ALIASED when <c>FillMesh</c> is called. To
			/// change the render target's antialias mode, use the SetAntialiasMode method.
			/// </para>
			/// <para>
			/// <c>FillMesh</c> does not expect a particular winding order for the triangles in the ID2D1Mesh; both clockwise and
			/// counter-clockwise will work.
			/// </para>
			/// <para>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>FillMesh</c>)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillmesh void FillMesh( ID2D1Mesh *mesh,
			// ID2D1Brush *brush );
			[PreserveSig]
			new void FillMesh([In] ID2D1Mesh mesh, [In] ID2D1Brush brush);

			/// <summary>
			/// Applies the opacity mask described by the specified bitmap to a brush and uses that brush to paint a region of the render target.
			/// </summary>
			/// <param name="opacityMask">
			/// <para>Type: <c>ID2D1Bitmap*</c></para>
			/// <para>
			/// The opacity mask to apply to the brush. The alpha value of each pixel in the region specified by sourceRectangle is
			/// multiplied with the alpha value of the brush after the brush has been mapped to the area defined by destinationRectangle.
			/// </para>
			/// </param>
			/// <param name="brush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the region of the render target specified by destinationRectangle.</para>
			/// </param>
			/// <param name="content">
			/// <para>Type: <c>D2D1_OPACITY_MASK_CONTENT</c></para>
			/// <para>
			/// The type of content the opacity mask contains. The value is used to determine the color space in which the opacity mask is blended.
			/// </para>
			/// <para>
			/// <c>Note</c> Starting with Windows 8, the D2D1_OPACITY_MASK_CONTENT is not required. See the
			/// ID2D1DeviceContext::FillOpacityMask method, which has no <c>D2D1_OPACITY_MASK_CONTENT</c> parameter.
			/// </para>
			/// </param>
			/// <param name="destinationRectangle">
			/// <para>Type: <c>const D2D1_RECT_F</c></para>
			/// <para>The region of the render target to paint, in device-independent pixels.</para>
			/// </param>
			/// <param name="sourceRectangle">
			/// <para>Type: <c>const D2D1_RECT_F</c></para>
			/// <para>The region of the bitmap to use as the opacity mask, in device-independent pixels.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// For this method to work properly, the render target must be using the D2D1_ANTIALIAS_MODE_ALIASED antialiasing mode. You can
			/// set the antialiasing mode by calling the ID2D1RenderTarget::SetAntialiasMode method.
			/// </para>
			/// <para>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as FillOpacityMask)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillopacitymask(id2d1bitmap_id2d1brush_d2d1_opacity_mask_content_constd2d1_rect_f__constd2d1_rect_f_)
			// void FillOpacityMask( ID2D1Bitmap *opacityMask, ID2D1Brush *brush, D2D1_OPACITY_MASK_CONTENT content, const D2D1_RECT_F &amp;
			// destinationRectangle, const D2D1_RECT_F &amp; sourceRectangle );
			[PreserveSig]
			new void FillOpacityMask([In] ID2D1Bitmap opacityMask, [In] ID2D1Brush brush, D2D1_OPACITY_MASK_CONTENT content, [In, Optional] IntPtr destinationRectangle, [In, Optional] IntPtr sourceRectangle);

			/// <summary>Draws the specified bitmap after scaling it to the size of the specified rectangle.</summary>
			/// <param name="bitmap">
			/// <para>Type: <c>ID2D1Bitmap*</c></para>
			/// <para>The bitmap to render.</para>
			/// </param>
			/// <param name="destinationRectangle">
			/// <para>Type: <c>const D2D1_RECT_F</c></para>
			/// <para>
			/// The size and position, in device-independent pixels in the render target's coordinate space, of the area to which the bitmap
			/// is drawn. If the rectangle is not well-ordered, nothing is drawn, but the render target does not enter an error state.
			/// </para>
			/// </param>
			/// <param name="opacity">
			/// <para>Type: <c>FLOAT</c></para>
			/// <para>
			/// A value between 0.0f and 1.0f, inclusive, that specifies an opacity value to apply to the bitmap; this value is multiplied
			/// against the alpha values of the bitmap's contents.
			/// </para>
			/// </param>
			/// <param name="interpolationMode">
			/// <para>Type: <c>D2D1_BITMAP_INTERPOLATION_MODE</c></para>
			/// <para>The interpolation mode to use if the bitmap is scaled or rotated by the drawing operation.</para>
			/// </param>
			/// <param name="sourceRectangle">
			/// <para>Type: <c>const D2D1_RECT_F</c></para>
			/// <para>
			/// The size and position, in device-independent pixels in the bitmap's coordinate space, of the area within the bitmap to draw.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as DrawBitmap) failed,
			/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawbitmap(id2d1bitmap_constd2d1_rect_f__float_d2d1_bitmap_interpolation_mode_constd2d1_rect_f_)
			// void DrawBitmap( ID2D1Bitmap *bitmap, const D2D1_RECT_F &amp; destinationRectangle, FLOAT opacity,
			// D2D1_BITMAP_INTERPOLATION_MODE interpolationMode, const D2D1_RECT_F &amp; sourceRectangle );
			[PreserveSig]
			new void DrawBitmap([In] ID2D1Bitmap bitmap, [In, Optional] IntPtr destinationRectangle, float opacity = 1.0f,
				D2D1_BITMAP_INTERPOLATION_MODE interpolationMode = D2D1_BITMAP_INTERPOLATION_MODE.D2D1_BITMAP_INTERPOLATION_MODE_LINEAR, [In] IntPtr sourceRectangle = default);

			/// <summary>Draws the specified text using the format information provided by an IDWriteTextFormat object.</summary>
			/// <param name="string">
			/// <para>Type: <c>WCHAR*</c></para>
			/// <para>A pointer to an array of Unicode characters to draw.</para>
			/// </param>
			/// <param name="stringLength">
			/// <para>Type: <c>UINT</c></para>
			/// <para>The number of characters in string.</para>
			/// </param>
			/// <param name="textFormat">
			/// <para>Type: <c>IDWriteTextFormat*</c></para>
			/// <para>An object that describes formatting details of the text to draw, such as the font, the font size, and flow direction.</para>
			/// </param>
			/// <param name="layoutRect">
			/// <para>Type: <c>const D2D1_RECT_F</c></para>
			/// <para>The size and position of the area in which the text is drawn.</para>
			/// </param>
			/// <param name="defaultFillBrush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the text.</para>
			/// </param>
			/// <param name="options">
			/// <para>Type: <c>D2D1_DRAW_TEXT_OPTIONS</c></para>
			/// <para>
			/// A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the
			/// layout rectangle. The default value is D2D1_DRAW_TEXT_OPTIONS_NONE, which indicates that text should be snapped to pixel
			/// boundaries and it should not be clipped to the layout rectangle.
			/// </para>
			/// </param>
			/// <param name="measuringMode">
			/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
			/// <para>A value that indicates how glyph metrics are used to measure text when it is formatted. The default value is DWRITE_MEASURING_MODE_NATURAL.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>To create an IDWriteTextFormat object, create an IDWriteFactory and call its CreateTextFormat method.</para>
			/// <para>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as DrawText) failed,
			/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawtext(constwchar_uint32_idwritetextformat_constd2d1_rect_f__id2d1brush_d2d1_draw_text_options_dwrite_measuring_mode)
			// void DrawText( const WCHAR *string, UINT32 stringLength, IDWriteTextFormat *textFormat, const D2D1_RECT_F &amp; layoutRect,
			// ID2D1Brush *defaultFillBrush, D2D1_DRAW_TEXT_OPTIONS options, DWRITE_MEASURING_MODE measuringMode );
			[PreserveSig]
			new void DrawText([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat, in D2D_RECT_F layoutRect,
				[In] ID2D1Brush defaultFillBrush, D2D1_DRAW_TEXT_OPTIONS options = D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE,
				DWRITE_MEASURING_MODE measuringMode = DWRITE_MEASURING_MODE.DWRITE_MEASURING_MODE_NATURAL);

			/// <summary>Draws the formatted text described by the specified IDWriteTextLayout object.</summary>
			/// <param name="origin">
			/// <para>Type: <c>D2D1_POINT_2F</c></para>
			/// <para>
			/// The point, described in device-independent pixels, at which the upper-left corner of the text described by textLayout is drawn.
			/// </para>
			/// </param>
			/// <param name="textLayout">
			/// <para>Type: <c>IDWriteTextLayout*</c></para>
			/// <para>
			/// The formatted text to draw. Any drawing effects that do not inherit from ID2D1Resource are ignored. If there are drawing
			/// effects that inherit from <c>ID2D1Resource</c> that are not brushes, this method fails and the render target is put in an
			/// error state.
			/// </para>
			/// </param>
			/// <param name="defaultFillBrush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>
			/// The brush used to paint any text in textLayout that does not already have a brush associated with it as a drawing effect
			/// (specified by the IDWriteTextLayout::SetDrawingEffect method).
			/// </para>
			/// </param>
			/// <param name="options">
			/// <para>Type: <c>D2D1_DRAW_TEXT_OPTIONS</c></para>
			/// <para>
			/// A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the
			/// layout rectangle. The default value is D2D1_DRAW_TEXT_OPTIONS_NONE, which indicates that text should be snapped to pixel
			/// boundaries and it should not be clipped to the layout rectangle.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// When drawing the same text repeatedly, using the <c>DrawTextLayout</c> method is more efficient than using the DrawText
			/// method because the text doesn't need to be formatted and the layout processed with each call.
			/// </para>
			/// <para>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
			/// <c>DrawTextLayout</c>) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawtextlayout void DrawTextLayout(
			// D2D1_POINT_2F origin, IDWriteTextLayout *textLayout, ID2D1Brush *defaultFillBrush, D2D1_DRAW_TEXT_OPTIONS options );
			[PreserveSig]
			new void DrawTextLayout(D2D_POINT_2F origin, [In] IDWriteTextLayout textLayout, [In] ID2D1Brush defaultFillBrush,
				D2D1_DRAW_TEXT_OPTIONS options = D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE);

			/// <summary>Draws the specified glyphs.</summary>
			/// <param name="baselineOrigin">
			/// <para>Type: <c>D2D1_POINT_2F</c></para>
			/// <para>The origin, in device-independent pixels, of the glyphs' baseline.</para>
			/// </param>
			/// <param name="glyphRun">
			/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
			/// <para>The glyphs to render.</para>
			/// </param>
			/// <param name="foregroundBrush">
			/// <para>Type: <c>ID2D1Brush*</c></para>
			/// <para>The brush used to paint the specified glyphs.</para>
			/// </param>
			/// <param name="measuringMode">
			/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
			/// <para>A value that indicates how glyph metrics are used to measure text when it is formatted. The default value is DWRITE_MEASURING_MODE_NATURAL.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>DrawGlyphRun</c>)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawglyphrun void DrawGlyphRun(
			// D2D1_POINT_2F baselineOrigin, const DWRITE_GLYPH_RUN *glyphRun, ID2D1Brush *foregroundBrush, DWRITE_MEASURING_MODE
			// measuringMode );
			[PreserveSig]
			new void DrawGlyphRun(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun, [In] ID2D1Brush foregroundBrush,
				DWRITE_MEASURING_MODE measuringMode = DWRITE_MEASURING_MODE.DWRITE_MEASURING_MODE_NATURAL);

			/// <summary>
			/// Applies the specified transform to the render target, replacing the existing transformation. All subsequent drawing
			/// operations occur in the transformed space.
			/// </summary>
			/// <param name="transform">
			/// <para>Type: <c>const D2D1_MATRIX_3X2_F</c></para>
			/// <para>The transform to apply to the render target.</para>
			/// </param>
			/// <returns>None</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-settransform(constd2d1_matrix_3x2_f_) void
			// SetTransform( const D2D1_MATRIX_3X2_F &amp; transform );
			[PreserveSig]
			new void SetTransform(in D2D_MATRIX_3X2_F transform);

			/// <summary>Gets the current transform of the render target.</summary>
			/// <param name="transform">
			/// <para>Type: <c>D2D1_MATRIX_3X2_F*</c></para>
			/// <para>When this returns, contains the current transform of the render target. This parameter is passed uninitialized.</para>
			/// </param>
			/// <returns>None</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettransform void GetTransform(
			// D2D1_MATRIX_3X2_F *transform );
			[PreserveSig]
			new void GetTransform(out D2D_MATRIX_3X2_F transform);

			/// <summary>
			/// Sets the antialiasing mode of the render target. The antialiasing mode applies to all subsequent drawing operations,
			/// excluding text and glyph drawing operations.
			/// </summary>
			/// <param name="antialiasMode">
			/// <para>Type: <c>D2D1_ANTIALIAS_MODE</c></para>
			/// <para>The antialiasing mode for future drawing operations.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>To specify the antialiasing mode for text and glyph operations, use the SetTextAntialiasMode method.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-setantialiasmode void SetAntialiasMode(
			// D2D1_ANTIALIAS_MODE antialiasMode );
			[PreserveSig]
			new void SetAntialiasMode(D2D1_ANTIALIAS_MODE antialiasMode);

			/// <summary>Retrieves the current antialiasing mode for nontext drawing operations.</summary>
			/// <returns>
			/// <para>Type: <c>D2D1_ANTIALIAS_MODE</c></para>
			/// <para>The current antialiasing mode for nontext drawing operations.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getantialiasmode D2D1_ANTIALIAS_MODE GetAntialiasMode();
			[PreserveSig]
			new D2D1_ANTIALIAS_MODE GetAntialiasMode();

			/// <summary>Specifies the antialiasing mode to use for subsequent text and glyph drawing operations.</summary>
			/// <param name="textAntialiasMode">
			/// <para>Type: <c>D2D1_TEXT_ANTIALIAS_MODE</c></para>
			/// <para>The antialiasing mode to use for subsequent text and glyph drawing operations.</para>
			/// </param>
			/// <returns>None</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-settextantialiasmode void
			// SetTextAntialiasMode( D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode );
			[PreserveSig]
			new void SetTextAntialiasMode(D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode);

			/// <summary>Gets the current antialiasing mode for text and glyph drawing operations.</summary>
			/// <returns>
			/// <para>Type: <c>D2D1_TEXT_ANTIALIAS_MODE</c></para>
			/// <para>The current antialiasing mode for text and glyph drawing operations.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettextantialiasmode
			// D2D1_TEXT_ANTIALIAS_MODE GetTextAntialiasMode();
			[PreserveSig]
			new D2D1_TEXT_ANTIALIAS_MODE GetTextAntialiasMode();

			/// <summary>Specifies text rendering options to be applied to all subsequent text and glyph drawing operations.</summary>
			/// <param name="textRenderingParams">
			/// <para>Type: <c>IDWriteRenderingParams*</c></para>
			/// <para>
			/// The text rendering options to be applied to all subsequent text and glyph drawing operations; <c>NULL</c> to clear current
			/// text rendering options.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// If the settings specified by textRenderingParams are incompatible with the render target's text antialiasing mode (specified
			/// by SetTextAntialiasMode), subsequent text and glyph drawing operations will fail and put the render target into an error state.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-settextrenderingparams void
			// SetTextRenderingParams( IDWriteRenderingParams *textRenderingParams );
			[PreserveSig]
			new void SetTextRenderingParams([In, Optional] IDWriteRenderingParams textRenderingParams);

			/// <summary>Retrieves the render target's current text rendering options.</summary>
			/// <param name="textRenderingParams">
			/// <para>Type: <c>IDWriteRenderingParams**</c></para>
			/// <para>
			/// When this method returns, textRenderingParamscontains the address of a pointer to the render target's current text rendering options.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// If the settings specified by textRenderingParams are incompatible with the render target's text antialiasing mode (specified
			/// by SetTextAntialiasMode), subsequent text and glyph drawing operations will fail and put the render target into an error state.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettextrenderingparams void
			// GetTextRenderingParams( IDWriteRenderingParams **textRenderingParams );
			[PreserveSig]
			new void GetTextRenderingParams(out IDWriteRenderingParams textRenderingParams);

			/// <summary>Specifies a label for subsequent drawing operations.</summary>
			/// <param name="tag1">
			/// <para>Type: <c>ulong</c></para>
			/// <para>A label to apply to subsequent drawing operations.</para>
			/// </param>
			/// <param name="tag2">
			/// <para>Type: <c>ulong</c></para>
			/// <para>A label to apply to subsequent drawing operations.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// The labels specified by this method are printed by debug error messages. If no tag is set, the default value for each tag is 0.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-settags void SetTags( ulong tag1, ulong
			// tag2 );
			[PreserveSig]
			new void SetTags(ulong tag1, ulong tag2);

			/// <summary>Gets the label for subsequent drawing operations.</summary>
			/// <param name="tag1">
			/// <para>Type: <c>D2D1_TAG*</c></para>
			/// <para>
			/// When this method returns, contains the first label for subsequent drawing operations. This parameter is passed
			/// uninitialized. If <c>NULL</c> is specified, no value is retrieved for this parameter.
			/// </para>
			/// </param>
			/// <param name="tag2">
			/// <para>Type: <c>D2D1_TAG*</c></para>
			/// <para>
			/// When this method returns, contains the second label for subsequent drawing operations. This parameter is passed
			/// uninitialized. If <c>NULL</c> is specified, no value is retrieved for this parameter.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>If the same address is passed for both parameters, both parameters receive the value of the second tag.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettags void GetTags( D2D1_TAG *tag1,
			// D2D1_TAG *tag2 );
			[PreserveSig]
			new void GetTags(out ulong tag1, out ulong tag2);

			/// <summary>
			/// Adds the specified layer to the render target so that it receives all subsequent drawing operations until PopLayer is called.
			/// </summary>
			/// <param name="layerParameters">
			/// <para>Type: <c>const D2D1_LAYER_PARAMETERS</c></para>
			/// <para>The content bounds, geometric mask, opacity, opacity mask, and antialiasing options for the layer.</para>
			/// </param>
			/// <param name="layer">
			/// <para>Type: <c>ID2D1Layer*</c></para>
			/// <para>The layer that receives subsequent drawing operations.</para>
			/// <para>
			/// <c>Note</c> Starting with Windows 8, this parameter is optional. If a layer is not specified, Direct2D manages the layer
			/// resource automatically.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// The <c>PushLayer</c> method allows a caller to begin redirecting rendering to a layer. All rendering operations are valid in
			/// a layer. The location of the layer is affected by the world transform set on the render target.
			/// </para>
			/// <para>
			/// Each PushLayer must have a matching PopLayer call. If there are more <c>PopLayer</c> calls than <c>PushLayer</c> calls, the
			/// render target is placed into an error state. If Flush is called before all outstanding layers are popped, the render target
			/// is placed into an error state, and an error is returned. The error state can be cleared by a call to EndDraw.
			/// </para>
			/// <para>
			/// A particular ID2D1Layer resource can be active only at one time. In other words, you cannot call a <c>PushLayer</c> method,
			/// and then immediately follow with another <c>PushLayer</c> method with the same layer resource. Instead, you must call the
			/// second <c>PushLayer</c> method with different layer resources.
			/// </para>
			/// <para>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as PushLayer) failed,
			/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-pushlayer(constd2d1_layer_parameters__id2d1layer)
			// void PushLayer( const D2D1_LAYER_PARAMETERS &amp; layerParameters, ID2D1Layer *layer );
			[PreserveSig]
			new void PushLayer(in D2D1_LAYER_PARAMETERS layerParameters, [In, Optional] ID2D1Layer layer);

			/// <summary>Stops redirecting drawing operations to the layer that is specified by the last PushLayer call.</summary>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>A <c>PopLayer</c> must match a previous PushLayer call.</para>
			/// <para>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>PopLayer</c>)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-poplayer void PopLayer();
			[PreserveSig]
			new void PopLayer();

			/// <summary>Executes all pending drawing commands.</summary>
			/// <param name="tag1">
			/// <para>Type: <c>D2D1_TAG*</c></para>
			/// <para>
			/// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors. This
			/// parameter is passed uninitialized.
			/// </para>
			/// </param>
			/// <param name="tag2">
			/// <para>Type: <c>D2D1_TAG*</c></para>
			/// <para>
			/// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors. This
			/// parameter is passed uninitialized.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>
			/// If the method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code and sets tag1 and tag2 to
			/// the tags that were active when the error occurred. If no error occurred, this method sets the error tag state to be (0,0).
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>This command does not flush the Direct3D device context that is associated with the render target.</para>
			/// <para>Calling this method resets the error state of the render target.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-flush HRESULT Flush( D2D1_TAG *tag1,
			// D2D1_TAG *tag2 );
			new void Flush(out ulong tag1, out ulong tag2);

			/// <summary>Saves the current drawing state to the specified ID2D1DrawingStateBlock.</summary>
			/// <param name="drawingStateBlock">
			/// <para>Type: <c>ID2D1DrawingStateBlock*</c></para>
			/// <para>
			/// When this method returns, contains the current drawing state of the render target. This parameter must be initialized before
			/// passing it to the method.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-savedrawingstate void SaveDrawingState(
			// ID2D1DrawingStateBlock *drawingStateBlock );
			[PreserveSig]
			new void SaveDrawingState([In, Out] ID2D1DrawingStateBlock drawingStateBlock);

			/// <summary>Sets the render target's drawing state to that of the specified ID2D1DrawingStateBlock.</summary>
			/// <param name="drawingStateBlock">
			/// <para>Type: <c>ID2D1DrawingStateBlock*</c></para>
			/// <para>The new drawing state of the render target.</para>
			/// </param>
			/// <returns>None</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-restoredrawingstate void
			// RestoreDrawingState( ID2D1DrawingStateBlock *drawingStateBlock );
			[PreserveSig]
			new void RestoreDrawingState([In] ID2D1DrawingStateBlock drawingStateBlock);

			/// <summary>Specifies a rectangle to which all subsequent drawing operations are clipped.</summary>
			/// <param name="clipRect">
			/// <para>Type: [in] <c>const D2D1_RECT_F &amp;</c></para>
			/// <para>The size and position of the clipping area, in device-independent pixels.</para>
			/// </param>
			/// <param name="antialiasMode">
			/// <para>Type: [in] <c>D2D1_ANTIALIAS_MODE</c></para>
			/// <para>
			/// The antialiasing mode that is used to draw the edges of clip rects that have subpixel boundaries, and to blend the clip with
			/// the scene contents. The blending is performed once when the PopAxisAlignedClip method is called, and does not apply to each
			/// primitive within the layer.
			/// </para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// The clipRect is transformed by the current world transform set on the render target. After the transform is applied to the
			/// clipRect that is passed in, the axis-aligned bounding box for the clipRect is computed. For efficiency, the contents are
			/// clipped to this axis-aligned bounding box and not to the original clipRect that is passed in.
			/// </para>
			/// <para>
			/// The following diagrams show how a rotation transform is applied to the render target, the resulting clipRect, and a
			/// calculated axis-aligned bounding box.
			/// </para>
			/// <list type="number">
			/// <item>
			/// <term>Assume the rectangle in the following illustration is a render target that is aligned to the screen pixels.</term>
			/// </item>
			/// <item>
			/// <term>
			/// Apply a rotation transform to the render target. In the following illustration, the black rectangle represents the original
			/// render target and the red dashed rectangle represents the transformed render target.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// After calling <c>PushAxisAlignedClip</c>, the rotation transform is applied to the clipRect. In the following illustration,
			/// the blue rectangle represents the transformed clipRect.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// The axis-aligned bounding box is calculated. The green dashed rectangle represents the bounding box in the following
			/// illustration. All contents are clipped to this axis-aligned bounding box.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// <c>Note</c> If rendering operations fail or if PopAxisAlignedClip is not called, clip rects may cause some artifacts on the
			/// render target. <c>PopAxisAlignedClip</c> can be considered a drawing operation that is designed to fix the borders of a
			/// clipping region. Without this call, the borders of a clipped area may be not antialiased or otherwise corrected.
			/// </para>
			/// <para>
			/// The <c>PushAxisAlignedClip</c> and PopAxisAlignedClip must match. Otherwise, the error state is set. For the render target
			/// to continue receiving new commands, you can call Flush to clear the error.
			/// </para>
			/// <para>
			/// A <c>PushAxisAlignedClip</c> and PopAxisAlignedClip pair can occur around or within a PushLayer and PopLayer, but cannot
			/// overlap. For example, the sequence of <c>PushAxisAlignedClip</c>, PushLayer, PopLayer, <c>PopAxisAlignedClip</c> is valid,
			/// but the sequence of <c>PushAxisAlignedClip</c>, <c>PushLayer</c>, <c>PopAxisAlignedClip</c>, <c>PopLayer</c> is invalid.
			/// </para>
			/// <para>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as PushAxisAlignedClip)
			/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-pushaxisalignedclip(constd2d1_rect_f__d2d1_antialias_mode)
			// void PushAxisAlignedClip( const D2D1_RECT_F &amp; clipRect, D2D1_ANTIALIAS_MODE antialiasMode );
			[PreserveSig]
			new void PushAxisAlignedClip(in D2D_RECT_F clipRect, D2D1_ANTIALIAS_MODE antialiasMode);

			/// <summary>
			/// Removes the last axis-aligned clip from the render target. After this method is called, the clip is no longer applied to
			/// subsequent drawing operations.
			/// </summary>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// A PushAxisAlignedClip/ <c>PopAxisAlignedClip</c> pair can occur around or within a PushLayer/PopLayer pair, but may not
			/// overlap. For example, a <c>PushAxisAlignedClip</c>, <c>PushLayer</c>, <c>PopLayer</c>, <c>PopAxisAlignedClip</c> sequence is
			/// valid, but a <c>PushAxisAlignedClip</c>, <c>PushLayer</c>, <c>PopAxisAlignedClip</c>, <c>PopLayer</c> sequence is not.
			/// </para>
			/// <para><c>PopAxisAlignedClip</c> must be called once for every call to PushAxisAlignedClip.</para>
			/// <para>For an example, see How to Clip with an Axis-Aligned Clip Rectangle.</para>
			/// <para>
			/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
			/// <c>PopAxisAlignedClip</c>) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-popaxisalignedclip void PopAxisAlignedClip();
			[PreserveSig]
			new void PopAxisAlignedClip();

			/// <summary>Clears the drawing area to the specified color.</summary>
			/// <param name="clearColor">
			/// <para>Type: [in] <c>const D2D1_COLOR_F &amp;</c></para>
			/// <para>The color to which the drawing area is cleared.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// Direct2D interprets the clearColor as straight alpha (not premultiplied). If the render target's alpha mode is
			/// D2D1_ALPHA_MODE_IGNORE, the alpha channel of clearColor is ignored and replaced with 1.0f (fully opaque).
			/// </para>
			/// <para>
			/// If the render target has an active clip (specified by PushAxisAlignedClip), the clear command is applied only to the area
			/// within the clip region.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-clear(constd2d1_color_f_) void Clear( const
			// D2D1_COLOR_F &amp; clearColor );
			[PreserveSig]
			new void Clear([In, Optional] IntPtr clearColor);

			/// <summary>Initiates drawing on this render target.</summary>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>Drawing operations can only be issued between a <c>BeginDraw</c> and EndDraw call.</para>
			/// <para>
			/// BeginDraw and EndDraw are used to indicate that a render target is in use by the Direct2D system. Different implementations
			/// of ID2D1RenderTarget might behave differently when <c>BeginDraw</c> is called. An ID2D1BitmapRenderTarget may be locked
			/// between <c>BeginDraw</c>/EndDraw calls, a DXGI surface render target might be acquired on <c>BeginDraw</c> and released on
			/// <c>EndDraw</c>, while an ID2D1HwndRenderTarget may begin batching at <c>BeginDraw</c> and may present on <c>EndDraw</c>, for example.
			/// </para>
			/// <para>
			/// The BeginDraw method must be called before rendering operations can be called, though state-setting and state-retrieval
			/// operations can be performed even outside of <c>BeginDraw</c>/EndDraw.
			/// </para>
			/// <para>
			/// After <c>BeginDraw</c> is called, a render target will normally build up a batch of rendering commands, but defer processing
			/// of these commands until either an internal buffer is full, the Flush method is called, or until EndDraw is called. The
			/// <c>EndDraw</c> method causes any batched drawing operations to complete, and then returns an HRESULT indicating the success
			/// of the operations and, optionally, the tag state of the render target at the time the error occurred. The <c>EndDraw</c>
			/// method always succeeds: it should not be called twice even if a previous <c>EndDraw</c> resulted in a failing HRESULT.
			/// </para>
			/// <para>
			/// If EndDraw is called without a matched call to <c>BeginDraw</c>, it returns an error indicating that <c>BeginDraw</c> must
			/// be called before <c>EndDraw</c>.
			/// </para>
			/// <para>
			/// Calling <c>BeginDraw</c> twice on a render target puts the target into an error state where nothing further is drawn, and
			/// returns an appropriate HRESULT and error information when <c>EndDraw</c> is called.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-begindraw void BeginDraw();
			[PreserveSig]
			new void BeginDraw();

			/// <summary>Ends drawing operations on the render target and indicates the current error state and associated tags.</summary>
			/// <param name="tag1">
			/// <para>Type: <c>D2D1_TAG*</c></para>
			/// <para>
			/// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors. This
			/// parameter is passed uninitialized.
			/// </para>
			/// </param>
			/// <param name="tag2">
			/// <para>Type: <c>D2D1_TAG*</c></para>
			/// <para>
			/// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors. This
			/// parameter is passed uninitialized.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>
			/// If the method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code and sets tag1 and tag2 to
			/// the tags that were active when the error occurred.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>Drawing operations can only be issued between a BeginDraw and <c>EndDraw</c> call.</para>
			/// <para>
			/// BeginDraw and <c>EndDraw</c> are use to indicate that a render target is in use by the Direct2D system. Different
			/// implementations of ID2D1RenderTarget might behave differently when <c>BeginDraw</c> is called. An ID2D1BitmapRenderTarget
			/// may be locked between <c>BeginDraw</c>/ <c>EndDraw</c> calls, a DXGI surface render target might be acquired on
			/// <c>BeginDraw</c> and released on <c>EndDraw</c>, while an ID2D1HwndRenderTarget may begin batching at <c>BeginDraw</c> and
			/// may present on <c>EndDraw</c>, for example.
			/// </para>
			/// <para>
			/// The BeginDraw method must be called before rendering operations can be called, though state-setting and state-retrieval
			/// operations can be performed even outside of <c>BeginDraw</c>/ <c>EndDraw</c>.
			/// </para>
			/// <para>
			/// After BeginDraw is called, a render target will normally build up a batch of rendering commands, but defer processing of
			/// these commands until either an internal buffer is full, the Flush method is called, or until <c>EndDraw</c> is called. The
			/// <c>EndDraw</c> method causes any batched drawing operations to complete, and then returns an <c>HRESULT</c> indicating the
			/// success of the operations and, optionally, the tag state of the render target at the time the error occurred. The
			/// <c>EndDraw</c> method always succeeds: it should not be called twice even if a previous <c>EndDraw</c> resulted in a failing <c>HRESULT</c>.
			/// </para>
			/// <para>
			/// If <c>EndDraw</c> is called without a matched call to BeginDraw, it returns an error indicating that <c>BeginDraw</c> must
			/// be called before <c>EndDraw</c>.
			/// </para>
			/// <para>
			/// Calling <c>BeginDraw</c> twice on a render target puts the target into an error state where nothing further is drawn, and
			/// returns an appropriate <c>HRESULT</c> and error information when <c>EndDraw</c> is called.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-enddraw HRESULT EndDraw( D2D1_TAG *tag1,
			// D2D1_TAG *tag2 );
			new void EndDraw(out ulong tag1, out ulong tag2);

			/// <summary>Retrieves the pixel format and alpha mode of the render target.</summary>
			/// <returns>
			/// <para>Type: <c>D2D1_PIXEL_FORMAT</c></para>
			/// <para>The pixel format and alpha mode of the render target.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getpixelformat D2D1_PIXEL_FORMAT GetPixelFormat();
			[PreserveSig]
			new D2D1_PIXEL_FORMAT GetPixelFormat();

			/// <summary>Sets the dots per inch (DPI) of the render target.</summary>
			/// <param name="dpiX">
			/// <para>Type: <c>FLOAT</c></para>
			/// <para>A value greater than or equal to zero that specifies the horizontal DPI of the render target.</para>
			/// </param>
			/// <param name="dpiY">
			/// <para>Type: <c>FLOAT</c></para>
			/// <para>A value greater than or equal to zero that specifies the vertical DPI of the render target.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>
			/// This method specifies the mapping from pixel space to device-independent space for the render target. If both dpiX and dpiY
			/// are 0, the factory-read system DPI is chosen. If one parameter is zero and the other unspecified, the DPI is not changed.
			/// </para>
			/// <para>
			/// For ID2D1HwndRenderTarget, the DPI defaults to the most recently factory-read system DPI. The default value for all other
			/// render targets is 96 DPI.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-setdpi void SetDpi( FLOAT dpiX, FLOAT dpiY );
			[PreserveSig]
			new void SetDpi(float dpiX, float dpiY);

			/// <summary>Return the render target's dots per inch (DPI).</summary>
			/// <param name="dpiX">
			/// <para>Type: <c>FLOAT*</c></para>
			/// <para>When this method returns, contains the horizontal DPI of the render target. This parameter is passed uninitialized.</para>
			/// </param>
			/// <param name="dpiY">
			/// <para>Type: <c>FLOAT*</c></para>
			/// <para>When this method returns, contains the vertical DPI of the render target. This parameter is passed uninitialized.</para>
			/// </param>
			/// <returns>None</returns>
			/// <remarks>
			/// <para>This method indicates the mapping from pixel space to device-independent space for the render target.</para>
			/// <para>
			/// For ID2D1HwndRenderTarget, the DPI defaults to the most recently factory-read system DPI. The default value for all other
			/// render targets is 96 DPI.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getdpi void GetDpi( FLOAT *dpiX, FLOAT
			// *dpiY );
			[PreserveSig]
			new void GetDpi(out float dpiX, out float dpiY);

			/// <summary>Returns the size of the render target in device-independent pixels.</summary>
			/// <returns>
			/// <para>Type: <c>D2D1_SIZE_F</c></para>
			/// <para>The current size of the render target in device-independent pixels.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getsize D2D1_SIZE_F GetSize();
			[PreserveSig]
			new D2D_SIZE_F GetSize();

			/// <summary>Returns the size of the render target in device pixels.</summary>
			/// <returns>
			/// <para>Type: <c>D2D1_SIZE_U</c></para>
			/// <para>The size of the render target in device pixels.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getpixelsize D2D1_SIZE_U GetPixelSize();
			[PreserveSig]
			new D2D_SIZE_U GetPixelSize();

			/// <summary>
			/// Gets the maximum size, in device-dependent units (pixels), of any one bitmap dimension supported by the render target.
			/// </summary>
			/// <returns>
			/// <para>Type: <c>UINT32</c></para>
			/// <para>The maximum size, in pixels, of any one bitmap dimension supported by the render target.</para>
			/// </returns>
			/// <remarks>
			/// <para>This method returns the maximum texture size of the Direct3D device.</para>
			/// <para>
			/// <c>Note</c> The software renderer and WARP devices return the value of 16 megapixels (16*1024*1024). You can create a
			/// Direct2D texture that is this size, but not a Direct3D texture that is this size.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getmaximumbitmapsize UINT32 GetMaximumBitmapSize();
			[PreserveSig]
			new uint GetMaximumBitmapSize();

			/// <summary>Indicates whether the render target supports the specified properties.</summary>
			/// <param name="renderTargetProperties">
			/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES*</c></para>
			/// <para>The render target properties to test.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>BOOL</c></para>
			/// <para><c>TRUE</c> if the specified render target properties are supported by this render target; otherwise, <c>FALSE</c>.</para>
			/// </returns>
			/// <remarks>This method does not evaluate the DPI settings specified by the renderTargetProperties parameter.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-issupported(constd2d1_render_target_properties_)
			// BOOL IsSupported( const D2D1_RENDER_TARGET_PROPERTIES &amp; renderTargetProperties );
			[PreserveSig]
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool IsSupported(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

			/// <summary>Binds the render target to the device context to which it issues drawing commands.</summary>
			/// <param name="hDC">
			/// <para>Type: <c>const HDC</c></para>
			/// <para>The device context to which the render target issues drawing commands.</para>
			/// </param>
			/// <param name="pSubRect">
			/// <para>Type: <c>const RECT*</c></para>
			/// <para>The dimensions of the handle to a device context (HDC) to which the render target is bound.</para>
			/// </param>
			/// <remarks>
			/// Before you can render with the DC render target, you must use its <c>BindDC</c> method to associate it with a GDI DC. You do
			/// this each time you use a different DC, or the size of the area you want to draw to changes.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1dcrendertarget-binddc HRESULT BindDC( const HDC hDC,
			// const RECT *pSubRect );
			void BindDC([In] HDC hDC, in RECT pSubRect);
		}

		/// <summary>
		/// Indicates whether the area filled by the geometry would contain the specified point given the specified flattening tolerance.
		/// </summary>
		/// <param name="geometry">The <see cref="ID2D1Geometry"/> instance.</param>
		/// <param name="point">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The point to test.</para>
		/// </param>
		/// <param name="flatteningTolerance">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The numeric accuracy with which the precise geometric path and path intersection is calculated. Points missing the fill by less
		/// than the tolerance are still considered inside. Smaller values produce more accurate results but cause slower execution.
		/// </para>
		/// </param>
		/// <param name="worldTransform">
		/// <para>Type: <c>const D2D1_MATRIX_3X2_F</c></para>
		/// <para>The transform to apply to the geometry prior to testing for containment.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// When this method returns, contains a bool value that is true if the area filled by the geometry contains point; otherwise,
		/// false. You must allocate storage for this parameter.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1geometry-fillcontainspoint(d2d1_point_2f_constd2d1_matrix_3x2_f__float_bool)
		// HRESULT FillContainsPoint( D2D1_POINT_2F point, const D2D1_MATRIX_3X2_F &amp; worldTransform, FLOAT flatteningTolerance, BOOL
		// *contains );
		public static bool FillContainsPoint(this ID2D1Geometry geometry, D2D_POINT_2F point, float flatteningTolerance, D2D_MATRIX_3X2_F? worldTransform = null)
		{
			using SafeHGlobalStruct<D2D_MATRIX_3X2_F> mem = worldTransform;
			return geometry.FillContainsPoint(point, mem, flatteningTolerance);
		}
	}
}