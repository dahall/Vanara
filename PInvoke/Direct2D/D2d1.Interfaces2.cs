namespace Vanara.PInvoke;

public static partial class D2d1
{
	/// <summary>Represents the drawing state of a render target: the antialiasing mode, transform, tags, and text-rendering options.</summary>
	/// <remarks>
	/// <para>Creating ID2D1DrawingStateBlock Objects</para>
	/// <para>To create an <c>ID2D1DrawingStateBlock</c>, use the ID2D1Factory::CreateDrawingStateBlock method.</para>
	/// <para>
	/// A drawing state block is a device-independent resource; you can create it once and retain it for the life of your application.
	/// For more information about resources, see the Resources Overview.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1drawingstateblock
	[PInvokeData("d2d1.h", MSDNShortId = "9a3d9146-0e1b-4642-ad5d-ff1d09a93d2b")]
	[ComImport, Guid("28506e39-ebf6-46a1-bb47-fd85565ab957"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1DrawingStateBlock : ID2D1Resource
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

		/// <summary>Retrieves the antialiasing mode, transform, and tags portion of the drawing state.</summary>
		/// <param name="stateDescription">
		/// <para>Type: <c>D2D1_DRAWING_STATE_DESCRIPTION*</c></para>
		/// <para>
		/// When this method returns, contains the antialiasing mode, transform, and tags portion of the drawing state. You must
		/// allocate storage for this parameter.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1drawingstateblock-getdescription void GetDescription(
		// D2D1_DRAWING_STATE_DESCRIPTION *stateDescription );
		[PreserveSig]
		void GetDescription(out D2D1_DRAWING_STATE_DESCRIPTION stateDescription);

		/// <summary>Specifies the antialiasing mode, transform, and tags portion of the drawing state.</summary>
		/// <param name="stateDescription">
		/// <para>Type: <c>const D2D1_DRAWING_STATE_DESCRIPTION</c></para>
		/// <para>The antialiasing mode, transform, and tags portion of the drawing state.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1drawingstateblock-setdescription(constd2d1_drawing_state_description_)
		// void SetDescription( const D2D1_DRAWING_STATE_DESCRIPTION &amp; stateDescription );
		[PreserveSig]
		void SetDescription(in D2D1_DRAWING_STATE_DESCRIPTION stateDescription);

		/// <summary>Specifies the text-rendering configuration of the drawing state.</summary>
		/// <param name="textRenderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>The text-rendering configuration of the drawing state, or NULL to use default settings.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1drawingstateblock-settextrenderingparams void
		// SetTextRenderingParams( IDWriteRenderingParams *textRenderingParams );
		[PreserveSig]
		void SetTextRenderingParams([In, Optional] IDWriteRenderingParams? textRenderingParams);

		/// <summary>Retrieves the text-rendering configuration of the drawing state.</summary>
		/// <param name="textRenderingParams">
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to an IDWriteRenderingParams object that describes the
		/// text-rendering configuration of the drawing state.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1drawingstateblock-gettextrenderingparams void
		// GetTextRenderingParams( IDWriteRenderingParams **textRenderingParams );
		[PreserveSig]
		void GetTextRenderingParams(out IDWriteRenderingParams textRenderingParams);
	}

	/// <summary>Represents an ellipse.</summary>
	/// <remarks>
	/// <para>Creating ID2D1EllipseGeometry Objects</para>
	/// <para>To create an elipse geometry, use the ID2D1Factory::CreateEllipseGeometry method.</para>
	/// <para>
	/// Direct2D geometries are immutable and device-independent resources created by ID2D1Factory. In general, you should create
	/// geometries once and retain them for the life of the application, or until they need to be modified. For more information about
	/// device-independent and device-dependent resources, see the Resources Overview.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1ellipsegeometry
	[PInvokeData("d2d1.h", MSDNShortId = "4ab6452c-6df8-46c0-9e0d-0cebc19d84ba")]
	[ComImport, Guid("2cd906a4-12e2-11dc-9fed-001143a055f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1EllipseGeometry : ID2D1Geometry
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
		new D2D_RECT_F GetBounds([In, Optional] IntPtr worldTransform);

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
		new D2D_RECT_F GetWidenedBounds(float strokeWidth, [In, Optional] ID2D1StrokeStyle? strokeStyle, [In, Optional] IntPtr worldTransform, float flatteningTolerance);

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
		new bool StrokeContainsPoint(D2D_POINT_2F point, float strokeWidth, [In, Optional] ID2D1StrokeStyle? strokeStyle, [In, Optional] IntPtr worldTransform, float flatteningTolerance);

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
		new bool FillContainsPoint(D2D_POINT_2F point, [In, Optional] IntPtr worldTransform, float flatteningTolerance);

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
		new D2D1_GEOMETRY_RELATION CompareWithGeometry([In] ID2D1Geometry inputGeometry, [In, Optional] IntPtr inputGeometryTransform, float flatteningTolerance);

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
		new void Simplify(D2D1_GEOMETRY_SIMPLIFICATION_OPTION simplificationOption, [In, Optional] IntPtr worldTransform, float flatteningTolerance, [In] ID2D1SimplifiedGeometrySink? geometrySink);

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
		new void Tessellate([In, Optional] IntPtr worldTransform, float flatteningTolerance, [In] ID2D1TessellationSink tessellationSink);

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
		new void CombineWithGeometry([In] ID2D1Geometry inputGeometry, D2D1_COMBINE_MODE combineMode, [In, Optional] IntPtr inputGeometryTransform, float flatteningTolerance, [In] ID2D1SimplifiedGeometrySink geometrySink);

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
		new void Outline([In, Optional] IntPtr worldTransform, float flatteningTolerance, [In] ID2D1SimplifiedGeometrySink geometrySink);

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
		new float ComputeArea([In, Optional] IntPtr worldTransform, float flatteningTolerance);

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
		new float ComputeLength([In, Optional] IntPtr worldTransform, float flatteningTolerance);

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
		new void ComputePointAtLength(float length, [In, Optional] IntPtr worldTransform, float flatteningTolerance, out D2D_POINT_2F point, out D2D_POINT_2F unitTangentVector);

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
		new void Widen(float strokeWidth, [In, Optional] ID2D1StrokeStyle? strokeStyle, [In, Optional] IntPtr worldTransform, float flatteningTolerance, [In] ID2D1SimplifiedGeometrySink geometrySink);

		/// <summary>Gets the D2D1_ELLIPSE structure that describes this ellipse geometry.</summary>
		/// <param name="ellipse">
		/// <para>Type: <c>D2D1_ELLIPSE*</c></para>
		/// <para>
		/// When this method returns, contains the D2D1_ELLIPSE that describes the size and position of the ellipse. You must allocate
		/// storage for this parameter.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1ellipsegeometry-getellipse void GetEllipse( D2D1_ELLIPSE
		// *ellipse );
		[PreserveSig]
		void GetEllipse(out D2D1_ELLIPSE ellipse);
	}

	/// <summary>Creates Direct2D resources.</summary>
	/// <remarks>
	/// <para>
	/// The <c>ID2D1Factory</c> interface is the starting point for using Direct2D; it's what you use to create other Direct2D resources
	/// that you can use to draw or describe shapes.
	/// </para>
	/// <para>A factory defines a set of CreateResource methods that can produce the following drawing resources:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Render targets: objects that render drawing commands.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Drawing state blocks: objects that store drawing state information, such as the current transformation and antialiasing mode.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Geometries: objects that represent simple and potentially complex shapes.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To create an <c>ID2D1Factory</c>, you use one of the CreateFactory methods. You should retain the <c>ID2D1Factory</c> instance
	/// for as long as you use Direct2D resources; in general, you shouldn't need to recreate it when the application is running. For
	/// more information about Direct2D resources, see the Resources Overview.
	/// </para>
	/// <para>Singlethreaded and Multithreaded Factories</para>
	/// <para>
	/// When you create a factory, you can specify whether it is multithreaded or singlethreaded. A singlethreaded factory provides no
	/// serialization against any other single threaded instance within Direct2D, so, this mechanism provides a very large degree of
	/// scaling on the CPU.
	/// </para>
	/// <para>
	/// You can also create a multithreaded factory instance. In this case, the factory and all derived objects can be used from any
	/// thread and each render target can be rendered to independently. Direct2D serializes calls to these objects, so a single
	/// multithreaded Direct2D instance won't scale as well on the CPU as many single threaded instances. However, the resources can be
	/// shared within the multithreaded instance.
	/// </para>
	/// <para>
	/// Note that the qualifier "On the CPU": GPUs generally take advantage of fine-grained parallelism more so than CPUs. For example,
	/// multithreaded calls from the CPU might still end up being serialized when being sent to the GPU, however, a whole bank of pixel
	/// and vertex shaders will run in parallel to perform the rendering.
	/// </para>
	/// <para>See Multithreaded Direct2D Apps for more info.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1factory
	[PInvokeData("d2d1.h", MSDNShortId = "cef6115c-98e8-49e6-b419-271b43ce2938")]
	[ComImport, Guid("06152247-6f50-465a-9245-118bfd3b6007"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1Factory
	{
		/// <summary>Forces the factory to refresh any system defaults that it might have changed since factory creation.</summary>
		/// <remarks>You should call this method before calling the GetDesktopDpi method, to ensure that the system DPI is current.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-reloadsystemmetrics HRESULT ReloadSystemMetrics();
		void ReloadSystemMetrics();

		/// <summary>Retrieves the current desktop dots per inch (DPI). To refresh this value, call ReloadSystemMetrics.</summary>
		/// <param name="dpiX">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the horizontal DPI of the desktop. You must allocate storage for this parameter.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the vertical DPI of the desktop. You must allocate storage for this parameter.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Use this method to obtain the system DPI when setting physical pixel values, such as when you specify the size of a window.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-getdesktopdpi void GetDesktopDpi( FLOAT *dpiX,
		// FLOAT *dpiY );
		[PreserveSig, Obsolete("ID2D1Factory::GetDesktopDpi is deprecated. For a desktop app, instead use GetDpiForWindow. For a Universal Windows Platform (UWP) app, instead use DisplayInformation::LogicalDpi.")]
		void GetDesktopDpi(out float dpiX, out float dpiY);

		/// <summary>Creates an ID2D1RectangleGeometry.</summary>
		/// <param name="rectangle">
		/// <para>Type: [in] <c>const D2D1_RECT_F*</c></para>
		/// <para>The coordinates of the rectangle geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1RectangleGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the rectangle geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createrectanglegeometry%28constd2d1_rect_f_id2d1rectanglegeometry%29
		// HRESULT CreateRectangleGeometry( const D2D1_RECT_F *rectangle, ID2D1RectangleGeometry **rectangleGeometry );
		ID2D1RectangleGeometry CreateRectangleGeometry(in D2D_RECT_F rectangle);

		/// <summary>Creates an ID2D1RoundedRectangleGeometry.</summary>
		/// <param name="roundedRectangle">
		/// <para>Type: [in] <c>const D2D1_ROUNDED_RECT*</c></para>
		/// <para>The coordinates and corner radii of the rounded rectangle geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1RoundedRectangleGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the rounded rectangle geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createroundedrectanglegeometry%28constd2d1_rounded_rect_id2d1roundedrectanglegeometry%29
		// HRESULT CreateRoundedRectangleGeometry( const D2D1_ROUNDED_RECT *roundedRectangle, ID2D1RoundedRectangleGeometry
		// **roundedRectangleGeometry );
		ID2D1RoundedRectangleGeometry CreateRoundedRectangleGeometry(in D2D1_ROUNDED_RECT roundedRectangle);

		/// <summary>Creates an ID2D1EllipseGeometry.</summary>
		/// <param name="ellipse">
		/// <para>Type: [in] <c>const D2D1_ELLIPSE &amp;</c></para>
		/// <para>A value that describes the center point, x-radius, and y-radius of the ellipse geometry.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1EllipseGeometry**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ellipse geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createellipsegeometry%28constd2d1_ellipse__id2d1ellipsegeometry%29
		// HRESULT CreateEllipseGeometry( const D2D1_ELLIPSE &amp; ellipse, ID2D1EllipseGeometry **ellipseGeometry );
		ID2D1EllipseGeometry CreateEllipseGeometry(in D2D1_ELLIPSE ellipse);

		/// <summary>Creates an ID2D1GeometryGroup, which is an object that holds other geometries.</summary>
		/// <param name="fillMode">
		/// <para>Type: <c>D2D1_FILL_MODE</c></para>
		/// <para>A value that specifies the rule that a composite shape uses to determine whether a given point is part of the geometry.</para>
		/// </param>
		/// <param name="geometries">
		/// <para>Type: <c>ID2D1Geometry**</c></para>
		/// <para>
		/// An array containing the geometry objects to add to the geometry group. The number of elements in this array is indicated by
		/// the geometriesCount parameter.
		/// </para>
		/// </param>
		/// <param name="geometriesCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in geometries.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1GeometryGroup**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the geometry group created by this method.</para>
		/// </returns>
		/// <remarks>
		/// Geometry groups are a convenient way to group several geometries simultaneously so all figures of several distinct
		/// geometries are concatenated into one. To create a ID2D1GeometryGroup object, call the <c>CreateGeometryGroup</c> method on
		/// the ID2D1Factory object, passing in the fillMode with possible values of D2D1_FILL_MODE_ALTERNATE (alternate) and
		/// <c>D2D1_FILL_MODE_WINDING</c>, an array of geometry objects to add to the geometry group, and the number of elements in this array.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-creategeometrygroup HRESULT CreateGeometryGroup(
		// D2D1_FILL_MODE fillMode, ID2D1Geometry **geometries, UINT32 geometriesCount, ID2D1GeometryGroup **geometryGroup );
		ID2D1GeometryGroup CreateGeometryGroup(D2D1_FILL_MODE fillMode, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] ID2D1Geometry[] geometries, uint geometriesCount);

		/// <summary>Transforms the specified geometry and stores the result as an ID2D1TransformedGeometry object.</summary>
		/// <param name="sourceGeometry">
		/// <para>Type: [in] <c>ID2D1Geometry*</c></para>
		/// <para>The geometry to transform.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: [in] <c>const D2D1_MATRIX_3X2_F*</c></para>
		/// <para>The transformation to apply.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1TransformedGeometry**</c></para>
		/// <para>
		/// When this method returns, contains the address of the pointer to the new transformed geometry object. The transformed
		/// geometry stores the result of transforming sourceGeometry by transform.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Like other resources, a transformed geometry inherits the resource space and threading policy of the factory that created
		/// it. This object is immutable.
		/// </para>
		/// <para>
		/// When stroking a transformed geometry with the DrawGeometry method, the stroke width is not affected by the transform applied
		/// to the geometry. The stroke width is only affected by the world transform.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createtransformedgeometry%28id2d1geometry_constd2d1_matrix_3x2_f_id2d1transformedgeometry%29
		// HRESULT CreateTransformedGeometry( ID2D1Geometry *sourceGeometry, const D2D1_MATRIX_3X2_F *transform,
		// ID2D1TransformedGeometry **transformedGeometry );
		ID2D1TransformedGeometry CreateTransformedGeometry([In] ID2D1Geometry sourceGeometry, in D2D_MATRIX_3X2_F transform);

		/// <summary>Creates an empty ID2D1PathGeometry.</summary>
		/// <returns>
		/// <para>Type: <c>ID2D1PathGeometry**</c></para>
		/// <para>When this method returns, contains the address to a pointer to the path geometry created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createpathgeometry HRESULT CreatePathGeometry(
		// ID2D1PathGeometry **pathGeometry );
		ID2D1PathGeometry CreatePathGeometry();

		/// <summary>Creates an ID2D1StrokeStyle that describes start cap, dash pattern, and other features of a stroke.</summary>
		/// <param name="strokeStyleProperties">
		/// <para>Type: <c>const D2D1_STROKE_STYLE_PROPERTIES</c></para>
		/// <para>A structure that describes the stroke's line cap, dash offset, and other details of a stroke.</para>
		/// </param>
		/// <param name="dashes">
		/// <para>Type: <c>const FLOAT*</c></para>
		/// <para>
		/// An array whose elements are set to the length of each dash and space in the dash pattern. The first element sets the length
		/// of a dash, the second element sets the length of a space, the third element sets the length of a dash, and so on. The length
		/// of each dash and space in the dash pattern is the product of the element value in the array and the stroke width.
		/// </para>
		/// </param>
		/// <param name="dashesCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in the dashes array.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1StrokeStyle**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the stroke style created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createstrokestyle%28constd2d1_stroke_style_properties__constfloat_uint32_id2d1strokestyle%29
		// HRESULT CreateStrokeStyle( const D2D1_STROKE_STYLE_PROPERTIES &amp; strokeStyleProperties, const FLOAT *dashes, UINT32
		// dashesCount, ID2D1StrokeStyle **strokeStyle );
		ID2D1StrokeStyle CreateStrokeStyle(in D2D1_STROKE_STYLE_PROPERTIES strokeStyleProperties, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] float[] dashes, uint dashesCount);

		/// <summary>
		/// Creates an ID2D1DrawingStateBlock that can be used with the SaveDrawingState and RestoreDrawingState methods of a render target.
		/// </summary>
		/// <param name="drawingStateDescription">
		/// <para>Type: <c>const D2D1_DRAWING_STATE_DESCRIPTION*</c></para>
		/// <para>A structure that contains antialiasing, transform, and tags information.</para>
		/// </param>
		/// <param name="textRenderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>Optional text parameters that indicate how text should be rendered.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1DrawingStateBlock**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the new drawing state block created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdrawingstateblock%28constd2d1_drawing_state_description_idwriterenderingparams_id2d1drawingstateblock%29
		// HRESULT CreateDrawingStateBlock( const D2D1_DRAWING_STATE_DESCRIPTION *drawingStateDescription, IDWriteRenderingParams
		// *textRenderingParams, ID2D1DrawingStateBlock **drawingStateBlock );
		ID2D1DrawingStateBlock CreateDrawingStateBlock([In, Optional] IntPtr drawingStateDescription, [In, Optional] IDWriteRenderingParams? textRenderingParams);

		/// <summary>Creates a render target that renders to a Microsoft Windows Imaging Component (WIC) bitmap.</summary>
		/// <param name="target">
		/// <para>Type: <c>IWICBitmap*</c></para>
		/// <para>The bitmap that receives the rendering output of the render target.</para>
		/// </param>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1RenderTarget**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ID2D1RenderTarget object created by this method.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You must use D2D1_FEATURE_LEVEL_DEFAULT for the <c>minLevel</c> member of the renderTargetProperties parameter with this method.
		/// </para>
		/// <para>
		/// Your application should create render targets once and hold onto them for the life of the application or until the
		/// D2DERR_RECREATE_TARGET error is received. When you receive this error, you need to recreate the render target (and any
		/// resources it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createwicbitmaprendertarget%28iwicbitmap_constd2d1_render_target_properties__id2d1rendertarget%29
		// HRESULT CreateWicBitmapRenderTarget( IWICBitmap *target, const D2D1_RENDER_TARGET_PROPERTIES &amp; renderTargetProperties,
		// ID2D1RenderTarget **renderTarget );
		ID2D1RenderTarget CreateWicBitmapRenderTarget([In] IWICBitmap target, in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates an <c>ID2D1HwndRenderTarget</c>, a render target that renders to a window.</summary>
		/// <param name="renderTargetProperties">
		/// <para>[in] Type: <c>D2D1_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <param name="hwndRenderTargetProperties">
		/// <para>[in] Type: <c>D2D1_HWND_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>The window handle, initial size (in pixels), and present options.</para>
		/// </param>
		/// <returns>
		/// <para>[out] Type: <c>ID2D1HwndRenderTarget**</c></para>
		/// <para>
		/// When this method returns, contains the address of the pointer to the <c>ID2D1HwndRenderTarget</c> object created by this method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// When you create a render target and hardware acceleration is available, you allocate resources on the computer's GPU. By
		/// creating a render target once and retaining it as long as possible, you gain performance benefits. Your application should
		/// create render targets once and hold onto them for the life of the application or until the <c>D2DERR_RECREATE_TARGET</c>
		/// error is received. When you receive this error, you need to recreate the render target (and any resources it created).
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/dd371275(v=vs.85) virtual HRESULT
		// CreateHwndRenderTarget( [in] D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties, [in] D2D1_HWND_RENDER_TARGET_PROPERTIES
		// *hwndRenderTargetProperties, [out] ID2D1HwndRenderTarget **hwndRenderTarget ) = 0;
		ID2D1HwndRenderTarget CreateHwndRenderTarget(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties, in D2D1_HWND_RENDER_TARGET_PROPERTIES hwndRenderTargetProperties);

		/// <summary>Creates a render target that draws to a DirectX Graphics Infrastructure (DXGI) surface.</summary>
		/// <param name="dxgiSurface">
		/// <para>Type: <c>IDXGISurface*</c></para>
		/// <para>The IDXGISurface to which the render target will draw.</para>
		/// </param>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES &amp;</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1RenderTarget**</c></para>
		/// <para>When this method returns, contains the address of the pointer to the ID2D1RenderTarget object created by this method.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To write to a Direct3D surface, you obtain an IDXGISurface and pass it to the CreateDxgiSurfaceRenderTarget method to create
		/// a DXGI surface render target; you can then use the DXGI surface render target to draw 2-D content to the DXGI surface.
		/// </para>
		/// <para>
		/// A DXGI surface render target is a type of ID2D1RenderTarget. Like other Direct2D render targets, you can use it to create
		/// resources and issue drawing commands.
		/// </para>
		/// <para>
		/// The DXGI surface render target and the DXGI surface must use the same DXGI format. If you specify the DXGI_FORMAT_UNKOWN
		/// format when you create the render target, it will automatically use the surface's format.
		/// </para>
		/// <para>The DXGI surface render target does not perform DXGI surface synchronization.</para>
		/// <para>
		/// For more information about creating and using DXGI surface render targets, see the Direct2D and Direct3D Interoperability Overview.
		/// </para>
		/// <para>
		/// To work with Direct2D, the Direct3D device that provides the IDXGISurface must be created with the
		/// <c>D3D10_CREATE_DEVICE_BGRA_SUPPORT</c> flag.
		/// </para>
		/// <para>
		/// When you create a render target and hardware acceleration is available, you allocate resources on the computer's GPU. By
		/// creating a render target once and retaining it as long as possible, you gain performance benefits. Your application should
		/// create render targets once and hold onto them for the life of the application or until the render target's EndDraw method
		/// returns the D2DERR_RECREATE_TARGET error. When you receive this error, you need to recreate the render target (and any
		/// resources it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdxgisurfacerendertarget%28idxgisurface_constd2d1_render_target_properties__id2d1rendertarget%29
		// HRESULT CreateDxgiSurfaceRenderTarget( IDXGISurface *dxgiSurface, const D2D1_RENDER_TARGET_PROPERTIES &amp;
		// renderTargetProperties, ID2D1RenderTarget **renderTarget );
		ID2D1RenderTarget CreateDxgiSurfaceRenderTarget([In] IDXGISurface dxgiSurface, in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>Creates a render target that draws to a Windows Graphics Device Interface (GDI) device context.</summary>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>
		/// The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware
		/// rendering. To enable the device context (DC) render target to work with GDI, set the DXGI format to
		/// DXGI_FORMAT_B8G8R8A8_UNORM and the alpha mode to D2D1_ALPHA_MODE_PREMULTIPLIED or <c>D2D1_ALPHA_MODE_IGNORE</c>. For more
		/// information about pixel formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1DCRenderTarget**</c></para>
		/// <para>
		/// When this method returns, dcRenderTarget contains the address of the pointer to the ID2D1DCRenderTarget created by the method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Before you can render with a DC render target, you must use the render target's BindDC method to associate it with a GDI DC.
		/// Do this for each different DC and whenever there is a change in the size of the area you want to draw to.
		/// </para>
		/// <para>
		/// To enable the DC render target to work with GDI, set the render target's DXGI format to DXGI_FORMAT_B8G8R8A8_UNORM and alpha
		/// mode to D2D1_ALPHA_MODE_PREMULTIPLIED or <c>D2D1_ALPHA_MODE_IGNORE</c>.
		/// </para>
		/// <para>
		/// Your application should create render targets once and hold on to them for the life of the application or until the render
		/// target's EndDraw method returns the D2DERR_RECREATE_TARGET error. When you receive this error, recreate the render target
		/// (and any resources it created).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1factory-createdcrendertarget HRESULT
		// CreateDCRenderTarget( const D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties, ID2D1DCRenderTarget **dcRenderTarget );
		ID2D1DCRenderTarget CreateDCRenderTarget(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);
	}
}