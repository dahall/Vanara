namespace Vanara.PInvoke;

public static partial class D2d1
{
	/// <summary>Paints an area with a solid color.</summary>
	/// <remarks>
	/// <para>Creating ID2D1SolidColorBrush Objects</para>
	/// <para>
	/// To create a solid color brush, use the ID2D1RenderTarget::CreateSolidColorBrush method of the render target on which the brush
	/// will be used. The brush can only be used with the render target that created it or with the compatible targets for that render target.
	/// </para>
	/// <para>A solid color brush is a device-dependent resource. (For more information about resources, see Resources Overview.)</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1solidcolorbrush
	[PInvokeData("d2d1.h", MSDNShortId = "a15c2696-3122-461e-806e-2195a50a3e92")]
	[ComImport, Guid("2cd906a9-12e2-11dc-9fed-001143a055f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1SolidColorBrush : ID2D1Brush
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

		/// <summary>Specifies the color of this solid-color brush.</summary>
		/// <param name="color">
		/// <para>Type: <c>const D2D1_COLOR_F</c></para>
		/// <para>The color of this solid-color brush.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// To help create colors, Direct2D provides the ColorF class. It offers several helper methods for creating colors and provides
		/// a set or predefined colors.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1solidcolorbrush-setcolor(constd2d1_color_f_) void
		// SetColor( const D2D1_COLOR_F &amp; color );
		[PreserveSig]
		void SetColor(in D3DCOLORVALUE color);

		/// <summary>Retrieves the color of the solid color brush.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_COLOR_F</c></para>
		/// <para>The color of this solid color brush.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1solidcolorbrush-getcolor D2D1_COLOR_F GetColor();
		[PreserveSig]
		D3DCOLORVALUE GetColor();
	}

	/// <summary>Describes the caps, miter limit, line join, and dash information for a stroke.</summary>
	/// <remarks>
	/// <para>Creating ID2D1StrokeStyle Objects</para>
	/// <para>To create a stroke style, use the ID2D1Factory::CreateStrokeStyle method.</para>
	/// <para>
	/// A stroke style is a device-indenpendent resource; you can create it once then retain it for the life of your application. For
	/// more information about resources, see the Resources Overview.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1strokestyle
	[PInvokeData("d2d1.h", MSDNShortId = "2cdf66dc-f34f-4132-8c06-7464648d3cef")]
	[ComImport, Guid("2cd9069d-12e2-11dc-9fed-001143a055f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1StrokeStyle : ID2D1Resource
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

		/// <summary>Retrieves the type of shape used at the beginning of a stroke.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_CAP_STYLE</c></para>
		/// <para>The type of shape used at the beginning of a stroke.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1strokestyle-getstartcap D2D1_CAP_STYLE GetStartCap();
		[PreserveSig]
		D2D1_CAP_STYLE GetStartCap();

		/// <summary>Retrieves the type of shape used at the end of a stroke.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_CAP_STYLE</c></para>
		/// <para>The type of shape used at the end of a stroke.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1strokestyle-getendcap D2D1_CAP_STYLE GetEndCap();
		[PreserveSig]
		D2D1_CAP_STYLE GetEndCap();

		/// <summary>Gets a value that specifies how the ends of each dash are drawn.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_CAP_STYLE</c></para>
		/// <para>A value that specifies how the ends of each dash are drawn.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1strokestyle-getdashcap D2D1_CAP_STYLE GetDashCap();
		[PreserveSig]
		D2D1_CAP_STYLE GetDashCap();

		/// <summary>Retrieves the limit on the ratio of the miter length to half the stroke's thickness.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// A positive number greater than or equal to 1.0f that describes the limit on the ratio of the miter length to half the
		/// stroke's thickness.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1strokestyle-getmiterlimit FLOAT GetMiterLimit();
		[PreserveSig]
		float GetMiterLimit();

		/// <summary>Retrieves the type of joint used at the vertices of a shape's outline.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_LINE_JOIN</c></para>
		/// <para>A value that specifies the type of joint used at the vertices of a shape's outline.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1strokestyle-getlinejoin D2D1_LINE_JOIN GetLineJoin();
		[PreserveSig]
		D2D1_LINE_JOIN GetLineJoin();

		/// <summary>Retrieves a value that specifies how far in the dash sequence the stroke will start.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that specifies how far in the dash sequence the stroke will start.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1strokestyle-getdashoffset FLOAT GetDashOffset();
		[PreserveSig]
		float GetDashOffset();

		/// <summary>Gets a value that describes the stroke's dash pattern.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_DASH_STYLE</c></para>
		/// <para>A value that describes the predefined dash pattern used, or D2D1_DASH_STYLE_CUSTOM if a custom dash style is used.</para>
		/// </returns>
		/// <remarks>
		/// If a custom dash style is specified, the dash pattern is described by the dashes array, which can be retrieved by calling
		/// the GetDashes method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1strokestyle-getdashstyle D2D1_DASH_STYLE GetDashStyle();
		[PreserveSig]
		D2D1_DASH_STYLE GetDashStyle();

		/// <summary>Retrieves the number of entries in the dashes array.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of entries in the dashes array if the stroke is dashed; otherwise, 0.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1strokestyle-getdashescount UINT32 GetDashesCount();
		[PreserveSig]
		uint GetDashesCount();

		/// <summary>Copies the dash pattern to the specified array.</summary>
		/// <param name="dashes">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>
		/// A pointer to an array that will receive the dash pattern. The array must be able to contain at least as many elements as
		/// specified by dashesCount. You must allocate storage for this array.
		/// </para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The number of dashes to copy. If this value is less than the number of dashes in the stroke style's dashes array, the
		/// returned dashes are truncated to dashesCount. If this value is greater than the number of dashes in the stroke style's
		/// dashes array, the extra dashes are set to 0.0f. To obtain the actual number of dashes in the stroke style's dashes array,
		/// use the GetDashesCount method.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The dashes are specified in units that are a multiple of the stroke width, with subsequent members of the array indicating
		/// the dashes and gaps between dashes: the first entry indicates a filled dash, the second a gap, and so on.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1strokestyle-getdashes void GetDashes( FLOAT *dashes,
		// UINT32 dashesCount );
		[PreserveSig]
		void GetDashes([Out] float[] dashes, uint dashesCount);
	}

	/// <summary>Populates an ID2D1Mesh object with triangles.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1tessellationsink
	[PInvokeData("d2d1.h", MSDNShortId = "967c702f-d16f-4a8e-ac77-a8bb35afe0a1")]
	[ComImport, Guid("2cd906c1-12e2-11dc-9fed-001143a055f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1TessellationSink
	{
		/// <summary>Copies the specified triangles to the sink.</summary>
		/// <param name="triangles">
		/// <para>Type: <c>const D2D1_TRIANGLE*</c></para>
		/// <para>An array of D2D1_TRIANGLE structures that describe the triangles to add to the sink.</para>
		/// </param>
		/// <param name="trianglesCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of triangles to copy from the triangles array.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1tessellationsink-addtriangles void AddTriangles( const
		// D2D1_TRIANGLE *triangles, UINT32 trianglesCount );
		[PreserveSig]
		void AddTriangles([In] D2D1_TRIANGLE[] triangles, uint trianglesCount);

		/// <summary>Closes the sink and returns its error status.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1tessellationsink-close HRESULT Close();
		void Close();
	}

	/// <summary>Represents a geometry that has been transformed.</summary>
	/// <remarks>
	/// <para>
	/// Using an <c>ID2D1TransformedGeometry</c> rather than transforming a geometry by using a render target's transform enables you to
	/// transform a geometry without transforming its stroke.
	/// </para>
	/// <para>Creating ID2D1TransformedGeometry Objects</para>
	/// <para>To create an <c>ID2D1TransformedGeometry</c>, call the ID2D1Factory::CreateTransformedGeometry method.</para>
	/// <para>
	/// Direct2D geometries are immutable and device-independent resources created by ID2D1Factory. In general, you should create
	/// geometries once and retain them for the life of the application, or until they need to be modified. For more information about
	/// device-independent and device-dependent resources, see the Resources Overview.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1transformedgeometry
	[PInvokeData("d2d1.h", MSDNShortId = "5d48eab6-1229-4e54-bfab-602b471b23a4")]
	[ComImport, Guid("2cd906bb-12e2-11dc-9fed-001143a055f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1TransformedGeometry : ID2D1Geometry
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

		/// <summary>Retrieves the bounds of the geometry.</summary>
		/// <param name="worldTransform">
		/// <para>Type: <c>const D2D1_MATRIX_3X2_F*</c></para>
		/// <para>The transform to apply to this geometry before calculating its bounds, or <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>D2D1_RECT_F*</c></para>
		/// <para>
		/// When this method returns, contains the bounds of this geometry. If the bounds are empty, this parameter will be a rect where
		/// bounds.left &gt; bounds.right. You must allocate storage for this parameter.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1geometry-getbounds(constd2d1_matrix_3x2_f_d2d1_rect_f)
		// HRESULT GetBounds( const D2D1_MATRIX_3X2_F *worldTransform, D2D1_RECT_F *bounds );
		new D2D_RECT_F GetBounds([In, Optional] StructPointer<D2D_MATRIX_3X2_F> worldTransform);

		/// <summary>
		/// Gets the bounds of the geometry after it has been widened by the specified stroke width and style and transformed by the
		/// specified matrix.
		/// </summary>
		/// <param name="strokeWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The amount by which to widen the geometry by stroking its outline.</para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: <c>ID2D1StrokeStyle*</c></para>
		/// <para>The style of the stroke that widens the geometry.</para>
		/// </param>
		/// <param name="worldTransform">
		/// <para>Type: <c>const D2D1_MATRIX_3X2_F*</c></para>
		/// <para>
		/// A transform to apply to the geometry after the geometry is transformed and after the geometry has been stroked, or <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="flatteningTolerance">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal
		/// representation will diverge from the original geometry by more than the flattening tolerance. Smaller values produce more
		/// accurate results but cause slower execution.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>D2D1_RECT_F*</c></para>
		/// <para>When this method returns, contains the bounds of the widened geometry. You must allocate storage for this parameter.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1geometry-getwidenedbounds%28float_id2d1strokestyle_constd2d1_matrix_3x2_f_float_d2d1_rect_f%29
		// HRESULT GetWidenedBounds( FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle, const D2D1_MATRIX_3X2_F *worldTransform, FLOAT
		// flatteningTolerance, D2D1_RECT_F *bounds );
		new D2D_RECT_F GetWidenedBounds(float strokeWidth, [In, Optional] ID2D1StrokeStyle? strokeStyle, [In, Optional] StructPointer<D2D1_MATRIX_3X2_F> worldTransform, float flatteningTolerance = D2D1_DEFAULT_FLATTENING_TOLERANCE);

		/// <summary>
		/// Determines whether the geometry's stroke contains the specified point given the specified stroke thickness, style, and transform.
		/// </summary>
		/// <param name="point">
		/// <para>Type: [in] <c>D2D1_POINT_2F</c></para>
		/// <para>The point to test for containment.</para>
		/// </param>
		/// <param name="strokeWidth">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>The thickness of the stroke to apply.</para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: [in, optional] <c>ID2D1StrokeStyle*</c></para>
		/// <para>The style of stroke to apply.</para>
		/// </param>
		/// <param name="worldTransform">
		/// <para>Type: [in, optional] <c>const D2D1_MATRIX_3X2_F*</c></para>
		/// <para>The transform to apply to the stroked geometry.</para>
		/// </param>
		/// <param name="flatteningTolerance">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>
		/// The numeric accuracy with which the precise geometric path and path intersection is calculated. Points missing the stroke by
		/// less than the tolerance are still considered inside. Smaller values produce more accurate results but cause slower execution.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>BOOL*</c></para>
		/// <para>
		/// When this method returns, contains a boolean value set to true if the geometry's stroke contains the specified point;
		/// otherwise, false. You must allocate storage for this parameter.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1geometry-strokecontainspoint%28d2d1_point_2f_float_id2d1strokestyle_constd2d1_matrix_3x2_f_float_bool%29
		// HRESULT StrokeContainsPoint( D2D1_POINT_2F point, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle, const D2D1_MATRIX_3X2_F
		// *worldTransform, FLOAT flatteningTolerance, BOOL *contains );
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool StrokeContainsPoint(D2D_POINT_2F point, float strokeWidth, [In, Optional] ID2D1StrokeStyle? strokeStyle, [In, Optional] StructPointer<D2D1_MATRIX_3X2_F> worldTransform, float flatteningTolerance = D2D1_DEFAULT_FLATTENING_TOLERANCE);

		/// <summary>
		/// Indicates whether the area filled by the geometry would contain the specified point given the specified flattening tolerance.
		/// </summary>
		/// <param name="point">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The point to test.</para>
		/// </param>
		/// <param name="worldTransform">
		/// <para>Type: <c>const D2D1_MATRIX_3X2_F</c></para>
		/// <para>The transform to apply to the geometry prior to testing for containment.</para>
		/// </param>
		/// <param name="flatteningTolerance">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The numeric accuracy with which the precise geometric path and path intersection is calculated. Points missing the fill by
		/// less than the tolerance are still considered inside. Smaller values produce more accurate results but cause slower execution.
		/// </para>
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
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool FillContainsPoint(D2D_POINT_2F point, [In, Optional] StructPointer<D2D1_MATRIX_3X2_F> worldTransform, float flatteningTolerance = D2D1_DEFAULT_FLATTENING_TOLERANCE);

		/// <summary>
		/// Describes the intersection between this geometry and the specified geometry. The comparison is performed by using the
		/// specified flattening tolerance.
		/// </summary>
		/// <param name="inputGeometry">
		/// <para>Type: [in] <c>ID2D1Geometry*</c></para>
		/// <para>The geometry to test.</para>
		/// </param>
		/// <param name="inputGeometryTransform">
		/// <para>Type: [in, optional] <c>const D2D1_MATRIX_3X2_F*</c></para>
		/// <para>The transform to apply to inputGeometry, or <c>NULL</c>.</para>
		/// </param>
		/// <param name="flatteningTolerance">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>
		/// The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal
		/// representation will diverge from the original geometry by more than the flattening tolerance. Smaller values produce more
		/// accurate results but cause slower execution.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>D2D1_GEOMETRY_RELATION*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a value that describes how this geometry is related to inputGeometry. You
		/// must allocate storage for this parameter.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When interpreting the returned relation value, it is important to remember that the member
		/// D2D1_GEOMETRY_RELATION_IS_CONTAINED of the <c>D2D1_GEOMETRY_RELATION</c> enumeration type means that this geometry is
		/// contained inside inputGeometry, not that this geometry contains inputGeometry.
		/// </para>
		/// <para>For more information about how to interpret other possible return values, see D2D1_GEOMETRY_RELATION.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1geometry-comparewithgeometry%28id2d1geometry_constd2d1_matrix_3x2_f_float_d2d1_geometry_relation%29
		// HRESULT CompareWithGeometry( ID2D1Geometry *inputGeometry, const D2D1_MATRIX_3X2_F *inputGeometryTransform, FLOAT
		// flatteningTolerance, D2D1_GEOMETRY_RELATION *relation );
		new D2D1_GEOMETRY_RELATION CompareWithGeometry([In] ID2D1Geometry inputGeometry, [In, Optional] StructPointer<D2D1_MATRIX_3X2_F> inputGeometryTransform, float flatteningTolerance = D2D1_DEFAULT_FLATTENING_TOLERANCE);

		/// <summary>
		/// Creates a simplified version of the geometry that contains only lines and (optionally) cubic Bezier curves and writes the
		/// result to an ID2D1SimplifiedGeometrySink.
		/// </summary>
		/// <param name="simplificationOption">
		/// <para>Type: [in] <c>D2D1_GEOMETRY_SIMPLIFICATION_OPTION</c></para>
		/// <para>A value that specifies whether the simplified geometry should contain curves.</para>
		/// </param>
		/// <param name="worldTransform">
		/// <para>Type: [in, optional] <c>const D2D1_MATRIX_3X2_F*</c></para>
		/// <para>The transform to apply to the simplified geometry, or <c>NULL</c>.</para>
		/// </param>
		/// <param name="flatteningTolerance">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>
		/// The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal
		/// representation will diverge from the original geometry by more than the flattening tolerance. Smaller values produce more
		/// accurate results but cause slower execution.
		/// </para>
		/// </param>
		/// <param name="geometrySink">
		/// <para>Type: [in] <c>ID2D1SimplifiedGeometrySink*</c></para>
		/// <para>The ID2D1SimplifiedGeometrySink to which the simplified geometry is appended.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1geometry-simplify%28d2d1_geometry_simplification_option_constd2d1_matrix_3x2_f_float_id2d1simplifiedgeometrysink%29
		// HRESULT Simplify( D2D1_GEOMETRY_SIMPLIFICATION_OPTION simplificationOption, const D2D1_MATRIX_3X2_F *worldTransform, FLOAT
		// flatteningTolerance, ID2D1SimplifiedGeometrySink *geometrySink );
		new void Simplify(D2D1_GEOMETRY_SIMPLIFICATION_OPTION simplificationOption, [In, Optional] StructPointer<D2D1_MATRIX_3X2_F> worldTransform, float flatteningTolerance = D2D1_DEFAULT_FLATTENING_TOLERANCE, [In] ID2D1SimplifiedGeometrySink? geometrySink = null);

		/// <summary>
		/// Creates a set of clockwise-wound triangles that cover the geometry after it has been transformed using the specified matrix
		/// and flattened using the specified tolerance.
		/// </summary>
		/// <param name="worldTransform">
		/// <para>Type: [in, optional] <c>const D2D1_MATRIX_3X2_F*</c></para>
		/// <para>The transform to apply to this geometry, or <c>NULL</c>.</para>
		/// </param>
		/// <param name="flatteningTolerance">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>
		/// The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal
		/// representation will diverge from the original geometry by more than the flattening tolerance. Smaller values produce more
		/// accurate results but cause slower execution.
		/// </para>
		/// </param>
		/// <param name="tessellationSink">
		/// <para>Type: [in] <c>ID2D1TessellationSink*</c></para>
		/// <para>The ID2D1TessellationSink to which the tessellated is appended.</para>
		/// </param>
		// https://docs.microsoft.com/ja-jp/windows/win32/api/d2d1/nf-d2d1-id2d1geometry-tessellate%28constd2d1_matrix_3x2_f_float_id2d1tessellationsink%29
		// HRESULT Tessellate( const D2D1_MATRIX_3X2_F *worldTransform, FLOAT flatteningTolerance, ID2D1TessellationSink
		// *tessellationSink );
		new void Tessellate([In, Optional] StructPointer<D2D1_MATRIX_3X2_F> worldTransform, float flatteningTolerance = D2D1_DEFAULT_FLATTENING_TOLERANCE, [In] ID2D1TessellationSink? tessellationSink = null);

		/// <summary>Combines this geometry with the specified geometry and stores the result in an ID2D1SimplifiedGeometrySink.</summary>
		/// <param name="inputGeometry">
		/// <para>Type: [in] <c>ID2D1Geometry*</c></para>
		/// <para>The geometry to combine with this instance.</para>
		/// </param>
		/// <param name="combineMode">
		/// <para>Type: [in] <c>D2D1_COMBINE_MODE</c></para>
		/// <para>The type of combine operation to perform.</para>
		/// </param>
		/// <param name="inputGeometryTransform">
		/// <para>Type: [in] <c>const D2D1_MATRIX_3X2_F &amp;</c></para>
		/// <para>The transform to apply to inputGeometry before combining.</para>
		/// </param>
		/// <param name="flatteningTolerance">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>
		/// The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal
		/// representation will diverge from the original geometry by more than the flattening tolerance. Smaller values produce more
		/// accurate results but cause slower execution.
		/// </para>
		/// </param>
		/// <param name="geometrySink">
		/// <para>Type: [in] <c>ID2D1SimplifiedGeometrySink*</c></para>
		/// <para>The result of the combine operation.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1geometry-combinewithgeometry(id2d1geometry_d2d1_combine_mode_constd2d1_matrix_3x2_f__float_id2d1simplifiedgeometrysink)
		// HRESULT CombineWithGeometry( ID2D1Geometry *inputGeometry, D2D1_COMBINE_MODE combineMode, const D2D1_MATRIX_3X2_F &amp;
		// inputGeometryTransform, FLOAT flatteningTolerance, ID2D1SimplifiedGeometrySink *geometrySink );
		new void CombineWithGeometry([In] ID2D1Geometry inputGeometry, D2D1_COMBINE_MODE combineMode, [In, Optional] StructPointer<D2D1_MATRIX_3X2_F> inputGeometryTransform, float flatteningTolerance = D2D1_DEFAULT_FLATTENING_TOLERANCE, [In] ID2D1SimplifiedGeometrySink? geometrySink = null);

		/// <summary>Computes the outline of the geometry and writes the result to an ID2D1SimplifiedGeometrySink.</summary>
		/// <param name="worldTransform">
		/// <para>Type: <c>const D2D1_MATRIX_3X2_F*</c></para>
		/// <para>The transform to apply to the geometry outline, or <c>NULL</c>.</para>
		/// </param>
		/// <param name="flatteningTolerance">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal
		/// representation will diverge from the original geometry by more than the flattening tolerance. Smaller values produce more
		/// accurate results but cause slower execution.
		/// </para>
		/// </param>
		/// <param name="geometrySink">
		/// <para>Type: <c>ID2D1SimplifiedGeometrySink*</c></para>
		/// <para>The ID2D1SimplifiedGeometrySink to which the geometry's transformed outline is appended.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The Outline method allows the caller to produce a geometry with an equivalent fill to the input geometry, with the following
		/// additional properties:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The output geometry contains no transverse intersections; that is, segments may touch, but they never cross.</term>
		/// </item>
		/// <item>
		/// <term>The outermost figures in the output geometry are all oriented counterclockwise.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The output geometry is fill-mode invariant; that is, the fill of the geometry does not depend on the choice of the fill
		/// mode. For more information about the fill mode, see D2D1_FILL_MODE.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Additionally, the Outline method can be useful in removing redundant portions of said geometries to simplify complex
		/// geometries. It can also be useful in combination with ID2D1GeometryGroup to create unions among several geometries simultaneously.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1geometry-outline%28constd2d1_matrix_3x2_f_float_id2d1simplifiedgeometrysink%29
		// HRESULT Outline( const D2D1_MATRIX_3X2_F *worldTransform, FLOAT flatteningTolerance, ID2D1SimplifiedGeometrySink
		// *geometrySink );
		new void Outline([In, Optional] StructPointer<D2D1_MATRIX_3X2_F> worldTransform, float flatteningTolerance = D2D1_DEFAULT_FLATTENING_TOLERANCE, [In] ID2D1SimplifiedGeometrySink? geometrySink = null);

		/// <summary>
		/// Computes the area of the geometry after it has been transformed by the specified matrix and flattened using the specified tolerance.
		/// </summary>
		/// <param name="worldTransform">
		/// <para>Type: [in] <c>const D2D1_MATRIX_3X2_F &amp;</c></para>
		/// <para>The transform to apply to this geometry before computing its area.</para>
		/// </param>
		/// <param name="flatteningTolerance">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>
		/// The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal
		/// representation will diverge from the original geometry by more than the flattening tolerance. Smaller values produce more
		/// accurate results but cause slower execution.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>FLOAT*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to the area of the transformed, flattened version of this geometry. You must
		/// allocate storage for this parameter.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1geometry-computearea(constd2d1_matrix_3x2_f__float_float)
		// HRESULT ComputeArea( const D2D1_MATRIX_3X2_F &amp; worldTransform, FLOAT flatteningTolerance, FLOAT *area );
		new float ComputeArea([In, Optional] StructPointer<D2D1_MATRIX_3X2_F> worldTransform, float flatteningTolerance = D2D1_DEFAULT_FLATTENING_TOLERANCE);

		/// <summary>Calculates the length of the geometry as though each segment were unrolled into a line.</summary>
		/// <param name="worldTransform">
		/// <para>Type: [in] <c>const D2D1_MATRIX_3X2_F &amp;</c></para>
		/// <para>The transform to apply to the geometry before calculating its length.</para>
		/// </param>
		/// <param name="flatteningTolerance">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>
		/// The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal
		/// representation will diverge from the original geometry by more than the flattening tolerance. Smaller values produce more
		/// accurate results but cause slower execution.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>FLOAT*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to the length of the geometry. For closed geometries, the length includes an
		/// implicit closing segment. You must allocate storage for this parameter.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1geometry-computelength(constd2d1_matrix_3x2_f__float_float)
		// HRESULT ComputeLength( const D2D1_MATRIX_3X2_F &amp; worldTransform, FLOAT flatteningTolerance, FLOAT *length );
		new float ComputeLength([In, Optional] StructPointer<D2D1_MATRIX_3X2_F> worldTransform, float flatteningTolerance = D2D1_DEFAULT_FLATTENING_TOLERANCE);

		/// <summary>
		/// Calculates the point and tangent vector at the specified distance along the geometry after it has been transformed by the
		/// specified matrix and flattened using the specified tolerance.
		/// </summary>
		/// <param name="length">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>
		/// The distance along the geometry of the point and tangent to find. If this distance is less than 0, this method calculates
		/// the first point in the geometry. If this distance is greater than the length of the geometry, this method calculates the
		/// last point in the geometry.
		/// </para>
		/// </param>
		/// <param name="worldTransform">
		/// <para>Type: [in] <c>const D2D1_MATRIX_3X2_F &amp;</c></para>
		/// <para>The transform to apply to the geometry before calculating the specified point and tangent.</para>
		/// </param>
		/// <param name="flatteningTolerance">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>
		/// The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal
		/// representation will diverge from the original geometry by more than the flattening tolerance. Smaller values produce more
		/// accurate results but cause slower execution.
		/// </para>
		/// </param>
		/// <param name="point">
		/// <para>Type: [out, optional] <c>D2D1_POINT_2F*</c></para>
		/// <para>
		/// The location at the specified distance along the geometry. If the geometry is empty, this point contains NaN as its x and y values.
		/// </para>
		/// </param>
		/// <param name="unitTangentVector">
		/// <para>Type: [out, optional] <c>D2D1_POINT_2F*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to the tangent vector at the specified distance along the geometry. If the
		/// geometry is empty, this vector contains NaN as its x and y values. You must allocate storage for this parameter.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1geometry-computepointatlength(float_constd2d1_matrix_3x2_f__float_d2d1_point_2f_d2d1_point_2f)
		// HRESULT ComputePointAtLength( FLOAT length, const D2D1_MATRIX_3X2_F &amp; worldTransform, FLOAT flatteningTolerance,
		// D2D1_POINT_2F *point, D2D1_POINT_2F *unitTangentVector );
		new void ComputePointAtLength(float length, [In, Optional] StructPointer<D2D1_MATRIX_3X2_F> worldTransform, float flatteningTolerance, out D2D_POINT_2F point, out D2D_POINT_2F unitTangentVector);

		/// <summary>
		/// Widens the geometry by the specified stroke and writes the result to an ID2D1SimplifiedGeometrySink after it has been
		/// transformed by the specified matrix and flattened using the specified tolerance.
		/// </summary>
		/// <param name="strokeWidth">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>The amount by which to widen the geometry.</para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: [in, optional] <c>ID2D1StrokeStyle*</c></para>
		/// <para>The style of stroke to apply to the geometry, or <c>NULL</c>.</para>
		/// </param>
		/// <param name="worldTransform">
		/// <para>Type: [in] <c>const D2D1_MATRIX_3X2_F &amp;</c></para>
		/// <para>The transform to apply to the geometry after widening it.</para>
		/// </param>
		/// <param name="flatteningTolerance">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>
		/// The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal
		/// representation will diverge from the original geometry by more than the flattening tolerance. Smaller values produce more
		/// accurate results but cause slower execution.
		/// </para>
		/// </param>
		/// <param name="geometrySink">
		/// <para>Type: [in] <c>ID2D1SimplifiedGeometrySink*</c></para>
		/// <para>The ID2D1SimplifiedGeometrySink to which the widened geometry is appended.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1geometry-widen(float_id2d1strokestyle_constd2d1_matrix_3x2_f__float_id2d1simplifiedgeometrysink)
		// HRESULT Widen( FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle, const D2D1_MATRIX_3X2_F &amp; worldTransform, FLOAT
		// flatteningTolerance, ID2D1SimplifiedGeometrySink *geometrySink );
		new void Widen(float strokeWidth, [In, Optional] ID2D1StrokeStyle? strokeStyle, [In, Optional] StructPointer<D2D1_MATRIX_3X2_F> worldTransform, float flatteningTolerance = D2D1_DEFAULT_FLATTENING_TOLERANCE, [In] ID2D1SimplifiedGeometrySink? geometrySink = null);

		/// <summary>Retrieves the source geometry of this transformed geometry object.</summary>
		/// <param name="sourceGeometry">
		/// <para>Type: <c>ID2D1Geometry**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the source geometry for this transformed geometry object. This
		/// parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1transformedgeometry-getsourcegeometry void
		// GetSourceGeometry( ID2D1Geometry **sourceGeometry );
		[PreserveSig]
		void GetSourceGeometry(out ID2D1Geometry sourceGeometry);

		/// <summary>Retrieves the matrix used to transform the ID2D1TransformedGeometry object's source geometry.</summary>
		/// <param name="transform">
		/// <para>Type: <c>D2D1_MATRIX_3X2_F*</c></para>
		/// <para>
		/// A pointer that receives the matrix used to transform the ID2D1TransformedGeometry object's source geometry. You must
		/// allocate storage for this parameter.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1transformedgeometry-gettransform void GetTransform(
		// D2D1_MATRIX_3X2_F *transform );
		[PreserveSig]
		void GetTransform(out D2D_MATRIX_3X2_F transform);
	}

	/// <summary>Specifies the color of this solid-color brush.</summary>
	/// <param name="brush">The brush.</param>
	/// <param name="color">
	/// <para>Type: <c>const D2D1_COLOR_F</c></para>
	/// <para>The color of this solid-color brush.</para>
	/// </param>
	/// <returns>None</returns>
	public static void SetColor(this ID2D1SolidColorBrush brush, System.Drawing.Color color) =>
		brush.SetColor((D3DCOLORVALUE)color);
}