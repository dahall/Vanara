namespace Vanara.PInvoke;

public static partial class D2d1
{
	/// <summary>Represents a set of vertices that form a list of triangles.</summary>
	/// <remarks>
	/// <para>Creating ID2D1Mesh Objects</para>
	/// <para>
	/// To create a mesh, call the ID2D1RenderTarget::CreateMesh method on the render target with which the mesh will be used. A mesh
	/// can only be used with the render target that created it and the render target's compatible targets.
	/// </para>
	/// <para>
	/// A mesh is a device-dependent resource: your application should create meshes after it initializes the render target with which
	/// the meshes will be used, and recreate the meshes whenever the render target needs recreated. (For more information about
	/// resources, see Resources Overview.)
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1mesh
	[PInvokeData("d2d1.h", MSDNShortId = "2a58fb5f-2281-4f73-a689-cc1350d13c8b")]
	[ComImport, Guid("2cd906c2-12e2-11dc-9fed-001143a055f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1Mesh : ID2D1Resource
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

		/// <summary>Opens the mesh for population.</summary>
		/// <returns>
		/// <para>Type: <c>ID2D1TessellationSink**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to an ID2D1TessellationSink that is used to populate the mesh.
		/// This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1mesh-open HRESULT Open( ID2D1TessellationSink
		// **tessellationSink );
		ID2D1TessellationSink Open();
	}

	/// <summary>Represents a complex shape that may be composed of arcs, curves, and lines.</summary>
	/// <remarks>
	/// <para>
	/// An <c>ID2D1PathGeometry</c> object enables you to describe a geometric path. To describe an <c>ID2D1PathGeometry</c> object's
	/// path, use the object's Open method to retrieve an ID2D1GeometrySink. Use the sink to populate the path geometry with figures and segments.
	/// </para>
	/// <para>Creating ID2D1PathGeometry Objects</para>
	/// <para>To create a path geometry, use the ID2D1Factory::CreatePathGeometry method.</para>
	/// <para>
	/// <c>ID2D1PathGeometry</c> objects are device-independent resources created by ID2D1Factory. In general, you should create
	/// geometries once and retain them for the life of the application, or until they need to be modified. For more information about
	/// device-independent and device-dependent resources, see the Resources Overview.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1pathgeometry
	[PInvokeData("d2d1.h", MSDNShortId = "d200563c-d78e-4fa0-a8f2-242b24480e99")]
	[ComImport, Guid("2cd906a5-12e2-11dc-9fed-001143a055f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1PathGeometry : ID2D1Geometry
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

		/// <summary>Retrieves the geometry sink that is used to populate the path geometry with figures and segments.</summary>
		/// <returns>
		/// <para>Type: <c>ID2D1GeometrySink**</c></para>
		/// <para>
		/// When this method returns, geometrySink contains the address of a pointer to the geometry sink that is used to populate the
		/// path geometry with figures and segments. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Because path geometries are immutable and can only be populated once, it is an error to call <c>Open</c> on a path geometry
		/// more than once.
		/// </para>
		/// <para>
		/// Note that the fill mode defaults to D2D1_FILL_MODE_ALTERNATE. To set the fill mode, call SetFillMode before the first call
		/// to BeginFigure. Failure to do so will put the geometry sink in an error state.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1pathgeometry-open HRESULT Open( ID2D1GeometrySink
		// **geometrySink );
		ID2D1GeometrySink Open();

		/// <summary>Copies the contents of the path geometry to the specified ID2D1GeometrySink.</summary>
		/// <param name="geometrySink">
		/// <para>Type: <c>ID2D1GeometrySink*</c></para>
		/// <para>
		/// The sink to which the path geometry's contents are copied. Modifying this sink does not change the contents of this path geometry.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1pathgeometry-stream HRESULT Stream( ID2D1GeometrySink
		// *geometrySink );
		void Stream([In] ID2D1GeometrySink geometrySink);

		/// <summary>Retrieves the number of segments in the path geometry.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// A pointer that receives the number of segments in the path geometry when this method returns. You must allocate storage for
		/// this parameter.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1pathgeometry-getsegmentcount HRESULT GetSegmentCount(
		// UINT32 *count );
		uint GetSegmentCount();

		/// <summary>Retrieves the number of figures in the path geometry.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// A pointer that receives the number of figures in the path geometry when this method returns. You must allocate storage for
		/// this parameter.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1pathgeometry-getfigurecount HRESULT GetFigureCount(
		// UINT32 *count );
		uint GetFigureCount();
	}

	/// <summary>Paints an area with a radial gradient.</summary>
	/// <remarks>
	/// <para>
	/// The <c>ID2D1RadialGradientBrush</c> is similar to the ID2D1LinearGradientBrush in that they both map a collection of gradient
	/// stops to a gradient. However, the linear gradient has a start and an end point to define the gradient vector, while the radial
	/// gradient uses an ellipse and a gradient origin to define its gradient behavior. To define the position and size of the ellipse,
	/// use the SetCenter, SetRadiusX, and SetRadiusY methods to specify the center, x-radius, and y-radius of the ellipse. The gradient
	/// origin is the center of the ellipse, unless a gradient offset is specified by using the SetGradientOriginOffset method.
	/// </para>
	/// <para>
	/// The brush maps the gradient stop position 0.0f of the gradient origin, and the position 1.0f is mapped to the ellipse boundary.
	/// When the gradient origin is within the ellipse, the contents of the ellipse enclose the entire [0, 1] range of the brush
	/// gradient stops. If the gradient origin is outside the bounds of the ellipse, the brush still works, but its gradient is not well-defined.
	/// </para>
	/// <para>
	/// The start point and end point are described in the brush space and are mappped to the render target when the brush is used. Note
	/// the starting and ending coordinates are absolute, not relative to the render target size. A value of (0, 0) maps to the
	/// upper-left corner of the render target, while a value of (1, 1) maps just one pixel diagonally away from (0, 0). If there is a
	/// nonidentity brush transform or render target transform, the brush ellipse and gradient origin are also transformed.
	/// </para>
	/// <para>
	/// It is possible to specify an ellipse that does not completely fill area being painted. When this occurs, the D2D1_EXTEND_MODE
	/// and setting (specified by the brush ID2D1GradientStopCollection) determines how the remaining area is painted.
	/// </para>
	/// <para>Creating ID2D1RadialGradientBrush Objects</para>
	/// <para>
	/// To create a radial gradient brush, use the ID2D1RenderTarget::CreateRadialGradientBrush method of the render target on which the
	/// brush will be used. The brush may be used only with the render target that created it or with the compatible targets for that
	/// render target.
	/// </para>
	/// <para>
	/// A radial gradient brush is a device-dependent resource: your application should create radial gradient brushes after it
	/// initializes the render target with which the brushes will be used, and recreate the brushes whenever the render target needs
	/// recreated. (For more information about resources, see Resources Overview.)
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1radialgradientbrush
	[PInvokeData("d2d1.h", MSDNShortId = "21ed2286-e4df-4b77-ba31-e5d5927e16f5")]
	[ComImport, Guid("2cd906ac-12e2-11dc-9fed-001143a055f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1RadialGradientBrush : ID2D1Brush
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

		/// <summary>Specifies the center of the gradient ellipse in the brush's coordinate space.</summary>
		/// <param name="center">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The center of the gradient ellipse, in the brush's coordinate space.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1radialgradientbrush-setcenter void SetCenter(
		// D2D1_POINT_2F center );
		[PreserveSig]
		void SetCenter(D2D_POINT_2F center);

		/// <summary>Specifies the offset of the gradient origin relative to the gradient ellipse's center.</summary>
		/// <param name="gradientOriginOffset">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The offset of the gradient origin from the center of the gradient ellipse.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1radialgradientbrush-setgradientoriginoffset void
		// SetGradientOriginOffset( D2D1_POINT_2F gradientOriginOffset );
		[PreserveSig]
		void SetGradientOriginOffset(D2D_POINT_2F gradientOriginOffset);

		/// <summary>Specifies the x-radius of the gradient ellipse, in the brush's coordinate space.</summary>
		/// <param name="radiusX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The x-radius of the gradient ellipse. This value is in the brush's coordinate space.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1radialgradientbrush-setradiusx void SetRadiusX( FLOAT
		// radiusX );
		[PreserveSig]
		void SetRadiusX(float radiusX);

		/// <summary>Specifies the y-radius of the gradient ellipse, in the brush's coordinate space.</summary>
		/// <param name="radiusY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-radius of the gradient ellipse. This value is in the brush's coordinate space.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1radialgradientbrush-setradiusy void SetRadiusY( FLOAT
		// radiusY );
		[PreserveSig]
		void SetRadiusY(float radiusY);

		/// <summary>Retrieves the center of the gradient ellipse.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The center of the gradient ellipse. This value is expressed in the brush's coordinate space.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1radialgradientbrush-getcenter D2D1_POINT_2F GetCenter();
		[PreserveSig]
		D2D_POINT_2F GetCenter();

		/// <summary>Retrieves the offset of the gradient origin relative to the gradient ellipse's center.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>
		/// The offset of the gradient origin from the center of the gradient ellipse. This value is expressed in the brush's coordinate space.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1radialgradientbrush-getgradientoriginoffset
		// D2D1_POINT_2F GetGradientOriginOffset();
		[PreserveSig]
		D2D_POINT_2F GetGradientOriginOffset();

		/// <summary>Retrieves the x-radius of the gradient ellipse.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The x-radius of the gradient ellipse. This value is expressed in the brush's coordinate space.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1radialgradientbrush-getradiusx FLOAT GetRadiusX();
		[PreserveSig]
		float GetRadiusX();

		/// <summary>Retrieves the y-radius of the gradient ellipse.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-radius of the gradient ellipse. This value is expressed in the brush's coordinate space.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1radialgradientbrush-getradiusy FLOAT GetRadiusY();
		[PreserveSig]
		float GetRadiusY();

		/// <summary>Retrieves the ID2D1GradientStopCollection associated with this radial gradient brush object.</summary>
		/// <param name="gradientStopCollection">
		/// <para>Type: <c>ID2D1GradientStopCollection**</c></para>
		/// <para>
		/// The ID2D1GradientStopCollection object associated with this linear gradient brush object. This parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// ID2D1GradientStopCollection contains an array of D2D1_GRADIENT_STOP structures and additional information, such as the
		/// extend mode and the color interpolation mode.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1radialgradientbrush-getgradientstopcollection void
		// GetGradientStopCollection( ID2D1GradientStopCollection **gradientStopCollection );
		[PreserveSig]
		void GetGradientStopCollection(out ID2D1GradientStopCollection gradientStopCollection);
	}

	/// <summary>Describes a two-dimensional rectangle.</summary>
	/// <remarks>
	/// <para>Creating ID2D1RectangleGeometry Objects</para>
	/// <para>To create a rectangle geometry, use the ID2D1Factory::CreateRectangleGeometry method.</para>
	/// <para>
	/// Direct2D geometries are immutable and device-independent resources created by ID2D1Factory. In general, you should create
	/// geometries once and retain them for the life of the application, or until they need to be modified. For more information about
	/// device-independent and device-dependent resources, see the Resources Overview.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1rectanglegeometry
	[PInvokeData("d2d1.h", MSDNShortId = "bb5f65ba-34d4-418b-863c-2431046bce8e")]
	[ComImport, Guid("2cd906a2-12e2-11dc-9fed-001143a055f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1RectangleGeometry : ID2D1Geometry
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

		/// <summary>Retrieves the rectangle that describes the rectangle geometry's dimensions.</summary>
		/// <param name="rect">
		/// <para>Type: <c>D2D1_RECT_F*</c></para>
		/// <para>
		/// Contains a pointer to a rectangle that describes the rectangle geometry's dimensions when this method returns. You must
		/// allocate storage for this parameter.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rectanglegeometry-getrect void GetRect( D2D1_RECT_F
		// *rect );
		[PreserveSig]
		void GetRect(out D2D_RECT_F rect);
	}

	/// <summary>
	/// Represents an object that can receive drawing commands. Interfaces that inherit from <c>ID2D1RenderTarget</c> render the drawing
	/// commands they receive in different ways.
	/// </summary>
	/// <remarks>
	/// Your application should create render targets once and hold onto them for the life of the application or until the render
	/// target's EndDraw method returns the D2DERR_RECREATE_TARGET error. When you receive this error, you need to recreate the render
	/// target (and any resources it created).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1rendertarget
	[PInvokeData("d2d1.h", MSDNShortId = "40629be9-5840-4bde-b369-56bbfd791775")]
	[ComImport, Guid("2cd90694-12e2-11dc-9fed-001143a055f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1RenderTarget : ID2D1Resource
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
		ID2D1Bitmap CreateBitmap(D2D_SIZE_U size, [In, Optional] IntPtr srcData, uint pitch, in D2D1_BITMAP_PROPERTIES bitmapProperties);

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
		ID2D1Bitmap CreateBitmapFromWicBitmap(IWICBitmapSource wicBitmapSource, [In, Optional] StructPointer<D2D1_BITMAP_PROPERTIES> bitmapProperties);

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
		ID2D1Bitmap CreateSharedBitmap(in Guid riid, [In, Out, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] object data, [In, Optional] StructPointer<D2D1_BITMAP_PROPERTIES> bitmapProperties);

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
		ID2D1BitmapBrush CreateBitmapBrush([In, Optional] ID2D1Bitmap? bitmap, [In, Optional] StructPointer<D2D1_BITMAP_BRUSH_PROPERTIES> bitmapBrushProperties,
			[In, Optional] StructPointer<D2D1_BRUSH_PROPERTIES> brushProperties);

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
		ID2D1SolidColorBrush CreateSolidColorBrush(in D3DCOLORVALUE color, [In, Optional] StructPointer<D2D1_BRUSH_PROPERTIES> brushProperties);

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
		ID2D1GradientStopCollection CreateGradientStopCollection([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D1_GRADIENT_STOP[] gradientStops, uint gradientStopsCount,
			[Optional] D2D1_GAMMA colorInterpolationGamma, [Optional] D2D1_EXTEND_MODE extendMode);

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
		ID2D1LinearGradientBrush CreateLinearGradientBrush(in D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES linearGradientBrushProperties,
			[In, Optional] StructPointer<D2D1_BRUSH_PROPERTIES> brushProperties, [In] ID2D1GradientStopCollection gradientStopCollection);

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
		ID2D1RadialGradientBrush CreateRadialGradientBrush(in D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES radialGradientBrushProperties,
			[In, Optional] StructPointer<D2D1_BRUSH_PROPERTIES> brushProperties, [In] ID2D1GradientStopCollection gradientStopCollection);

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
		ID2D1BitmapRenderTarget CreateCompatibleRenderTarget([In, Optional] StructPointer<D2D_SIZE_F> desiredSize, [In, Optional] StructPointer<D2D_SIZE_U> desiredPixelSize,
			[In, Optional] StructPointer<D2D1_PIXEL_FORMAT> desiredFormat, [In, Optional] D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS options);

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
		ID2D1Layer CreateLayer([In, Optional] StructPointer<D2D_SIZE_F> size);

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
		ID2D1Mesh CreateMesh();

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
		void DrawLine(D2D_POINT_2F point0, D2D_POINT_2F point1, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle? strokeStyle = null);

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
		void DrawRectangle(in D2D_RECT_F rect, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle? strokeStyle = null);

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
		void FillRectangle(in D2D_RECT_F rect, [In] ID2D1Brush brush);

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
		void DrawRoundedRectangle(in D2D1_ROUNDED_RECT roundedRect, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle? strokeStyle = null);

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
		void FillRoundedRectangle(in D2D1_ROUNDED_RECT roundedRect, [In] ID2D1Brush brush);

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
		void DrawEllipse(in D2D1_ELLIPSE ellipse, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle? strokeStyle = null);

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
		void FillEllipse(in D2D1_ELLIPSE ellipse, [In] ID2D1Brush brush);

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
		void DrawGeometry([In] ID2D1Geometry geometry, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle? strokeStyle = null);

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
		void FillGeometry([In] ID2D1Geometry geometry, [In] ID2D1Brush brush, [In] ID2D1Brush? opacityBrush = null);

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
		void FillMesh([In] ID2D1Mesh mesh, [In] ID2D1Brush brush);

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
		void FillOpacityMask([In] ID2D1Bitmap opacityMask, [In] ID2D1Brush brush, D2D1_OPACITY_MASK_CONTENT content,
			[In, Optional] PD2D_RECT_F? destinationRectangle, [In, Optional] PD2D_RECT_F? sourceRectangle);

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
		void DrawBitmap([In] ID2D1Bitmap bitmap, [In, Optional] PD2D_RECT_F? destinationRectangle, float opacity = 1.0f,
			D2D1_BITMAP_INTERPOLATION_MODE interpolationMode = D2D1_BITMAP_INTERPOLATION_MODE.D2D1_BITMAP_INTERPOLATION_MODE_LINEAR,
			[In] PD2D_RECT_F? sourceRectangle = null);

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
		void DrawText([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat, in D2D_RECT_F layoutRect,
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
		void DrawTextLayout(D2D_POINT_2F origin, [In] IDWriteTextLayout textLayout, [In] ID2D1Brush defaultFillBrush,
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
		void DrawGlyphRun(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun, [In] ID2D1Brush foregroundBrush,
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
		void SetTransform(in D2D_MATRIX_3X2_F transform);

		/// <summary>Gets the current transform of the render target.</summary>
		/// <param name="transform">
		/// <para>Type: <c>D2D1_MATRIX_3X2_F*</c></para>
		/// <para>When this returns, contains the current transform of the render target. This parameter is passed uninitialized.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettransform void GetTransform(
		// D2D1_MATRIX_3X2_F *transform );
		[PreserveSig]
		void GetTransform(out D2D_MATRIX_3X2_F transform);

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
		void SetAntialiasMode(D2D1_ANTIALIAS_MODE antialiasMode);

		/// <summary>Retrieves the current antialiasing mode for nontext drawing operations.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_ANTIALIAS_MODE</c></para>
		/// <para>The current antialiasing mode for nontext drawing operations.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getantialiasmode D2D1_ANTIALIAS_MODE GetAntialiasMode();
		[PreserveSig]
		D2D1_ANTIALIAS_MODE GetAntialiasMode();

		/// <summary>Specifies the antialiasing mode to use for subsequent text and glyph drawing operations.</summary>
		/// <param name="textAntialiasMode">
		/// <para>Type: <c>D2D1_TEXT_ANTIALIAS_MODE</c></para>
		/// <para>The antialiasing mode to use for subsequent text and glyph drawing operations.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-settextantialiasmode void
		// SetTextAntialiasMode( D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode );
		[PreserveSig]
		void SetTextAntialiasMode(D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode);

		/// <summary>Gets the current antialiasing mode for text and glyph drawing operations.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_TEXT_ANTIALIAS_MODE</c></para>
		/// <para>The current antialiasing mode for text and glyph drawing operations.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettextantialiasmode
		// D2D1_TEXT_ANTIALIAS_MODE GetTextAntialiasMode();
		[PreserveSig]
		D2D1_TEXT_ANTIALIAS_MODE GetTextAntialiasMode();

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
		void SetTextRenderingParams([In, Optional] IDWriteRenderingParams? textRenderingParams);

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
		void GetTextRenderingParams(out IDWriteRenderingParams textRenderingParams);

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
		void SetTags(ulong tag1, ulong tag2);

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
		void GetTags(out ulong tag1, out ulong tag2);

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
		void PushLayer(in D2D1_LAYER_PARAMETERS layerParameters, [In, Optional] ID2D1Layer? layer);

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
		void PopLayer();

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
		void Flush(out ulong tag1, out ulong tag2);

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
		void SaveDrawingState([In, Out] ID2D1DrawingStateBlock drawingStateBlock);

		/// <summary>Sets the render target's drawing state to that of the specified ID2D1DrawingStateBlock.</summary>
		/// <param name="drawingStateBlock">
		/// <para>Type: <c>ID2D1DrawingStateBlock*</c></para>
		/// <para>The new drawing state of the render target.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-restoredrawingstate void
		// RestoreDrawingState( ID2D1DrawingStateBlock *drawingStateBlock );
		[PreserveSig]
		void RestoreDrawingState([In] ID2D1DrawingStateBlock drawingStateBlock);

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
		void PushAxisAlignedClip(in D2D_RECT_F clipRect, D2D1_ANTIALIAS_MODE antialiasMode);

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
		void PopAxisAlignedClip();

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
		void Clear([In, Optional] StructPointer<D2D1_COLOR_F> clearColor);

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
		void BeginDraw();

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
		[PreserveSig]
		HRESULT EndDraw(out ulong tag1, out ulong tag2);

		/// <summary>Retrieves the pixel format and alpha mode of the render target.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_PIXEL_FORMAT</c></para>
		/// <para>The pixel format and alpha mode of the render target.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getpixelformat D2D1_PIXEL_FORMAT GetPixelFormat();
		[PreserveSig]
		D2D1_PIXEL_FORMAT GetPixelFormat();

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
		void SetDpi(float dpiX, float dpiY);

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
		void GetDpi(out float dpiX, out float dpiY);

		/// <summary>Returns the size of the render target in device-independent pixels.</summary>
		/// <returns>
		/// <para>Type: <b><c>D2D1_SIZE_F</c></b></para>
		/// <para>The current size of the render target in device-independent pixels.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getsize D2D1_SIZE_F GetSize();
		[PreserveSig]
		void GetSize(out D2D_SIZE_F size);

		/// <summary>Returns the size of the render target in device pixels.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_SIZE_U</c></para>
		/// <para>The size of the render target in device pixels.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getpixelsize D2D1_SIZE_U GetPixelSize();
		[PreserveSig]
		void GetPixelSize(out D2D_SIZE_U size);

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
		uint GetMaximumBitmapSize();

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
		bool IsSupported(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);
	}

	/// <summary>Represents a Direct2D drawing resource.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1resource
	[PInvokeData("d2d1.h", MSDNShortId = "8f19e74a-f010-4082-a4da-d1dc3cfe3192")]
	[ComImport, Guid("2cd90691-12e2-11dc-9fed-001143a055f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1Resource
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
		void GetFactory(out ID2D1Factory factory);
	}

	/// <summary>Describes a rounded rectangle.</summary>
	/// <remarks>
	/// <para>Creating ID2D1RoundedRectangleGeometry Objects</para>
	/// <para>To create a rectangle geometry, use the ID2D1Factory::CreateRoundedRectangleGeometry method.</para>
	/// <para>
	/// Direct2D geometries are immutable and device-independent resources created by ID2D1Factory. In general, you should create
	/// geometries once and retain them for the life of the application, or until they need to be modified. For more information about
	/// device-independent and device-dependent resources, see the Resources Overview.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1roundedrectanglegeometry
	[PInvokeData("d2d1.h", MSDNShortId = "e49e9be7-155a-4487-9931-035f18771c04")]
	[ComImport, Guid("2cd906a3-12e2-11dc-9fed-001143a055f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1RoundedRectangleGeometry : ID2D1Geometry
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

		/// <summary>Retrieves a rounded rectangle that describes this rounded rectangle geometry.</summary>
		/// <param name="roundedRect">
		/// <para>Type: <c>D2D1_ROUNDED_RECT*</c></para>
		/// <para>
		/// A pointer that receives a rounded rectangle that describes this rounded rectangle geometry. You must allocate storage for
		/// this parameter.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1roundedrectanglegeometry-getroundedrect void
		// GetRoundedRect( D2D1_ROUNDED_RECT *roundedRect );
		[PreserveSig]
		void GetRoundedRect(out D2D1_ROUNDED_RECT roundedRect);
	}

	/// <summary>Describes a geometric path that does not contain quadratic bezier curves or arcs.</summary>
	/// <remarks>
	/// <para>
	/// A geometry sink consists of one or more figures. Each figure is made up of one or more line or Bezier curve segments. To create
	/// a figure, call the BeginFigure method and specify the figure's start point, then use AddLines and AddBeziers to add line and
	/// Bezier segments. When you are finished adding segments, call the EndFigure method. You can repeat this sequence to create
	/// additional figures. When you are finished creating figures, call the Close method.
	/// </para>
	/// <para>To create geometry paths that can contain arcs and quadratic Bezier curves, use an ID2D1GeometrySink.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1simplifiedgeometrysink
	[PInvokeData("d2d1.h", MSDNShortId = "cf877a25-7b9f-4db0-ac53-b4a350795a86")]
	[ComImport, Guid("2cd9069e-12e2-11dc-9fed-001143a055f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1SimplifiedGeometrySink
	{
		/// <summary>
		/// Specifies the method used to determine which points are inside the geometry described by this geometry sink and which points
		/// are outside.
		/// </summary>
		/// <param name="fillMode">
		/// <para>Type: <c>D2D1_FILL_MODE</c></para>
		/// <para>The method used to determine whether a given point is part of the geometry.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The fill mode defaults to D2D1_FILL_MODE_ALTERNATE. To set the fill mode, call <c>SetFillMode</c> before the first call to
		/// BeginFigure. Not doing will put the geometry sink in an error state.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1simplifiedgeometrysink-setfillmode void SetFillMode(
		// D2D1_FILL_MODE fillMode );
		[PreserveSig]
		void SetFillMode(D2D1_FILL_MODE fillMode);

		/// <summary>Specifies stroke and join options to be applied to new segments added to the geometry sink.</summary>
		/// <param name="vertexFlags">
		/// <para>Type: <c>D2D1_PATH_SEGMENT</c></para>
		/// <para>Stroke and join options to be applied to new segments added to the geometry sink.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// After this method is called, the specified segment flags are applied to each segment subsequently added to the sink. The
		/// segment flags are applied to every additional segment until this method is called again and a different set of segment flags
		/// is specified.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1simplifiedgeometrysink-setsegmentflags void
		// SetSegmentFlags( D2D1_PATH_SEGMENT vertexFlags );
		[PreserveSig]
		void SetSegmentFlags(D2D1_PATH_SEGMENT vertexFlags);

		/// <summary>Starts a new figure at the specified point.</summary>
		/// <param name="startPoint">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The point at which to begin the new figure.</para>
		/// </param>
		/// <param name="figureBegin">
		/// <para>Type: <c>D2D1_FIGURE_BEGIN</c></para>
		/// <para>Whether the new figure should be hollow or filled.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// If this method is called while a figure is currently in progress, the interface is invalidated and all future methods will fail.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1simplifiedgeometrysink-beginfigure void BeginFigure(
		// D2D1_POINT_2F startPoint, D2D1_FIGURE_BEGIN figureBegin );
		[PreserveSig]
		void BeginFigure(D2D_POINT_2F startPoint, D2D1_FIGURE_BEGIN figureBegin);

		/// <summary>Creates a sequence of lines using the specified points and adds them to the geometry sink.</summary>
		/// <param name="points">
		/// <para>Type: <c>const D2D1_POINT_2F*</c></para>
		/// <para>
		/// A pointer to an array of one or more points that describe the lines to draw. A line is drawn from the geometry sink's
		/// current point (the end point of the last segment drawn or the location specified by BeginFigure) to the first point in the
		/// array. if the array contains additional points, a line is drawn from the first point to the second point in the array, from
		/// the second point to the third point, and so on.
		/// </para>
		/// </param>
		/// <param name="pointsCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of points in the points array.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1simplifiedgeometrysink-addlines void AddLines( const
		// D2D1_POINT_2F *points, UINT32 pointsCount );
		[PreserveSig]
		void AddLines([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D_POINT_2F[] points, uint pointsCount);

		/// <summary>Creates a sequence of cubic Bezier curves and adds them to the geometry sink.</summary>
		/// <param name="beziers">
		/// <para>Type: <c>const D2D1_BEZIER_SEGMENT*</c></para>
		/// <para>
		/// A pointer to an array of Bezier segments that describes the Bezier curves to create. A curve is drawn from the geometry
		/// sink's current point (the end point of the last segment drawn or the location specified by BeginFigure) to the end point of
		/// the first Bezier segment in the array. if the array contains additional Bezier segments, each subsequent Bezier segment uses
		/// the end point of the preceding Bezier segment as its start point.
		/// </para>
		/// </param>
		/// <param name="beziersCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of Bezier segments in the beziers array.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1simplifiedgeometrysink-addbeziers void AddBeziers( const
		// D2D1_BEZIER_SEGMENT *beziers, UINT32 beziersCount );
		[PreserveSig]
		void AddBeziers([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D1_BEZIER_SEGMENT[] beziers, uint beziersCount);

		/// <summary>Ends the current figure; optionally, closes it.</summary>
		/// <param name="figureEnd">
		/// <para>Type: <c>D2D1_FIGURE_END</c></para>
		/// <para>
		/// A value that indicates whether the current figure is closed. If the figure is closed, a line is drawn between the current
		/// point and the start point specified by BeginFigure.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Calling this method without a matching call to BeginFigure places the geometry sink in an error state; subsequent calls are
		/// ignored, and the overall failure will be returned when the Close method is called.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1simplifiedgeometrysink-endfigure void EndFigure(
		// D2D1_FIGURE_END figureEnd );
		[PreserveSig]
		void EndFigure(D2D1_FIGURE_END figureEnd);

		/// <summary>Closes the geometry sink, indicates whether it is in an error state, and resets the sink's error state.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Do not close the geometry sink while a figure is still in progress; doing so puts the geometry sink in an error state. For
		/// the close operation to be successful, there must be one EndFigure call for each call to BeginFigure.
		/// </para>
		/// <para>
		/// After calling this method, the geometry sink might not be usable. Direct2D implementations of this interface do not allow
		/// the geometry sink to be modified after it is closed, but other implementations might not impose this restriction.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1simplifiedgeometrysink-close HRESULT Close();
		[PreserveSig]
		HRESULT Close();
	}

	/// <summary>Clears the drawing area to the specified color.</summary>
	/// <param name="t">The <see cref="ID2D1RenderTarget"/> instance.</param>
	/// <param name="clearColor">The color to which the drawing area is cleared.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// Direct2D interprets the clearColor as straight alpha (not premultiplied). If the render target's alpha mode is
	/// D2D1_ALPHA_MODE_IGNORE, the alpha channel of clearColor is ignored and replaced with 1.0f (fully opaque).
	/// </para>
	/// <para>
	/// If the render target has an active clip (specified by PushAxisAlignedClip), the clear command is applied only to the area within the
	/// clip region.
	/// </para>
	/// </remarks>
	public static void Clear(this ID2D1RenderTarget t, D3DCOLORVALUE clearColor)
	{
		unsafe
		{
			t.Clear(&clearColor);
		}
	}

	/// <summary>Clears the drawing area to the specified color.</summary>
	/// <param name="t">The <see cref="ID2D1RenderTarget" /> instance.</param>
	/// <param name="clearColor">The color to which the drawing area is cleared.</param>
	/// <param name="a">The alpha component of the color.</param>
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
	public static void Clear(this ID2D1RenderTarget t, System.Drawing.Color clearColor, float a = 0f) =>
		Clear(t, new(clearColor, a));

	/// <summary>Creates an ID2D1Bitmap by copying the specified Microsoft Windows Imaging Component (WIC) bitmap.</summary>
	/// <param name="target">The <see cref="ID2D1RenderTarget"/> instance.</param>
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
	public static ID2D1Bitmap CreateBitmapFromWicBitmap(this ID2D1RenderTarget target, IWICBitmapSource wicBitmapSource, in D2D1_BITMAP_PROPERTIES bitmapProperties) =>
		target.CreateBitmapFromWicBitmap(wicBitmapSource, new(bitmapProperties, out _));

	/// <summary>Creates an ID2D1Bitmap whose data is shared with another resource.</summary>
	/// <typeparam name="T">The interface type of the object supplying the source data.</typeparam>
	/// <param name="target">The <see cref="ID2D1RenderTarget"/> instance.</param>
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
	public static ID2D1Bitmap CreateSharedBitmap<T>(this ID2D1RenderTarget target, T data, in D2D1_BITMAP_PROPERTIES? bitmapProperties = null) where T : class
	{
		using SafeCoTaskMemStruct<D2D1_BITMAP_PROPERTIES> props = bitmapProperties;
		return target.CreateSharedBitmap(typeof(T).GUID, data, props);
	}

	/// <summary>Creates an ID2D1BitmapBrush from the specified bitmap.</summary>
	/// <param name="target">The <see cref="ID2D1RenderTarget"/> instance.</param>
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
	public static ID2D1BitmapBrush CreateBitmapBrush(this ID2D1RenderTarget target, [In] ID2D1Bitmap? bitmap = null, [In] in D2D1_BITMAP_BRUSH_PROPERTIES? bitmapBrushProperties = null,
		in D2D1_BRUSH_PROPERTIES? brushProperties = null) =>
		target.CreateBitmapBrush(bitmap, new(bitmapBrushProperties, out _), new(brushProperties, out _));

	/// <summary>Creates a new ID2D1SolidColorBrush that has the specified color and opacity.</summary>
	/// <param name="target">The <see cref="ID2D1RenderTarget"/> instance.</param>
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
	public static ID2D1SolidColorBrush CreateSolidColorBrush(this ID2D1RenderTarget target, in D3DCOLORVALUE color, in D2D1_BRUSH_PROPERTIES? brushProperties = null) =>
		target.CreateSolidColorBrush(color, new(brushProperties, out _));

	/// <summary>Creates a new ID2D1SolidColorBrush that has the specified color and opacity.</summary>
	/// <param name="target">The <see cref="ID2D1RenderTarget"/> instance.</param>
	/// <param name="color">The brush's color.</param>
	/// <param name="brushProperties">
	/// <para>Type: [in] <c>const D2D1_BRUSH_PROPERTIES &amp;</c></para>
	/// <para>The base opacity of the brush.</para>
	/// </param>
	/// <returns>
	/// <para>Type: [out] <c>ID2D1SolidColorBrush**</c></para>
	/// <para>When this method returns, contains the address of a pointer to the new brush. This parameter is passed uninitialized.</para>
	/// </returns>
	public static ID2D1SolidColorBrush CreateSolidColorBrush(this ID2D1RenderTarget target, System.Drawing.Color color, in D2D1_BRUSH_PROPERTIES? brushProperties = null) =>
		target.CreateSolidColorBrush((D3DCOLORVALUE)color, new(brushProperties, out _));

	/// <summary>Creates an ID2D1LinearGradientBrush object for painting areas with a linear gradient.</summary>
	/// <param name="target">The <see cref="ID2D1RenderTarget"/> instance.</param>
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
	public static ID2D1LinearGradientBrush CreateLinearGradientBrush(this ID2D1RenderTarget target, in D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES linearGradientBrushProperties,
		in D2D1_BRUSH_PROPERTIES brushProperties, [In] ID2D1GradientStopCollection gradientStopCollection) =>
		target.CreateLinearGradientBrush(linearGradientBrushProperties, new(brushProperties, out _), gradientStopCollection);

	/// <summary>Creates an ID2D1RadialGradientBrush object that can be used to paint areas with a radial gradient.</summary>
	/// <param name="target">The <see cref="ID2D1RenderTarget"/> instance.</param>
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
	public static ID2D1RadialGradientBrush CreateRadialGradientBrush(this ID2D1RenderTarget target, in D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES radialGradientBrushProperties,
		in D2D1_BRUSH_PROPERTIES brushProperties, [In] ID2D1GradientStopCollection gradientStopCollection) =>
		target.CreateRadialGradientBrush(radialGradientBrushProperties, new(brushProperties, out _), gradientStopCollection);

	/// <summary>
	/// <param name="target">The <see cref="ID2D1RenderTarget"/> instance.</param>
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
	public static ID2D1BitmapRenderTarget CreateCompatibleRenderTarget(this ID2D1RenderTarget target, in D2D_SIZE_F? desiredSize = null, in D2D_SIZE_U? desiredPixelSize = null,
		in D2D1_PIXEL_FORMAT? desiredFormat = null, D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS options = 0) =>
		target.CreateCompatibleRenderTarget(new(desiredSize, out _), new(desiredPixelSize, out _), new(desiredFormat, out _), options);

	/// <summary>Creates a layer resource that can be used with this render target and its compatible render targets.</summary>
	/// <param name="target">The <see cref="ID2D1RenderTarget"/> instance.</param>
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
	public static ID2D1Layer CreateLayer(this ID2D1RenderTarget target, D2D_SIZE_F size) { unsafe { return target.CreateLayer(&size); } }

	/// <summary>Ends drawing operations on the render target and indicates the current error state and associated tags.</summary>
	/// <param name="target">The <see cref="ID2D1RenderTarget"/> instance.</param>
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
	public static HRESULT EndDraw(this ID2D1RenderTarget target) => target.EndDraw(out _, out _);

	/// <summary>Returns the size of the render target in device-independent pixels.</summary>
	/// <returns>
	/// <para>Type: <b><c>D2D1_SIZE_F</c></b></para>
	/// <para>The current size of the render target in device-independent pixels.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getsize D2D1_SIZE_F GetSize();
	public static D2D_SIZE_F GetSize(this ID2D1RenderTarget target) { target.GetSize(out D2D_SIZE_F size); return size; }

	/// <summary>Returns the size of the render target in device pixels.</summary>
	/// <returns>
	/// <para>Type: <c>D2D1_SIZE_U</c></para>
	/// <para>The size of the render target in device pixels.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getpixelsize D2D1_SIZE_U GetPixelSize();
	public static D2D_SIZE_U GetPixelSize(this ID2D1RenderTarget target) { target.GetPixelSize(out D2D_SIZE_U size); return size; }
}