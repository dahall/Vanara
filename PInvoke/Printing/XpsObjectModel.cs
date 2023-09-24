using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Opc;
using static Vanara.PInvoke.UrlMon;

namespace Vanara.PInvoke;

/// <summary>Interfaces and supporting enums and structures for XPS programming.</summary>
// https://docs.microsoft.com/en-us/windows/win32/printdocs/xps-programming-reference
public static partial class XpsObjectModel
{
	/// <summary>
	/// Defines objects that are used to paint graphical objects. Classes that derive from <c>IXpsOMBrush</c> describe how the area is painted.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsombrush
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "43cb56db-e09e-47cb-b50b-7827131659fd")]
	[ComImport, Guid("56A3F80C-EA4C-4187-A57B-A2A473B2B42B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMBrush : IXpsOMShareable
	{
		/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
		/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner HRESULT
		// GetOwner( IUnknown **owner );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		new object GetOwner();

		/// <summary>Gets the object type of the interface.</summary>
		/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype HRESULT GetType(
		// XPS_OBJECT_TYPE *type );
		new XPS_OBJECT_TYPE GetType();

		/// <summary>Gets the opacity of the brush.</summary>
		/// <returns>The opacity value of the brush.</returns>
		/// <remarks>
		/// opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is
		/// 50 percent opaque, and 1.0 that it is completely opaque.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-getopacity HRESULT
		// GetOpacity( FLOAT *opacity );
		float GetOpacity();

		/// <summary>Sets the opacity of the brush.</summary>
		/// <param name="opacity">The opacity value of the brush.</param>
		/// <remarks>
		/// <para>
		/// opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is
		/// 50 percent opaque, and 1.0 that it is completely opaque.
		/// </para>
		/// <para>If opacity is less than 0.0 or greater than 1.0, the method returns an error.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-setopacity HRESULT
		// SetOpacity( FLOAT opacity );
		void SetOpacity([In] float opacity);
	}

	/// <summary>A group of visual elements and related properties.</summary>
	/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomcanvas
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "3cb0e1b3-88a8-4724-a3c5-0df416294e62")]
	[ComImport, Guid("221D1452-331E-47C6-87E9-6CCEFB9B5BA3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMCanvas : IXpsOMVisual
	{
		/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
		/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner HRESULT
		// GetOwner( IUnknown **owner );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		new object GetOwner();

		/// <summary>Gets the object type of the interface.</summary>
		/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype HRESULT GetType(
		// XPS_OBJECT_TYPE *type );
		new XPS_OBJECT_TYPE GetType();

		/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the visual's resolved matrix transform.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMMatrixTransform interface that contains the visual's resolved matrix transform. If a matrix transform
		/// has not been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the transform.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in matrixTransform</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>
		/// The shared transform that gets retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the
		/// resource directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransform HRESULT
		// GetTransform( IXpsOMMatrixTransform **matrixTransform );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IXpsOMMatrixTransform GetTransform();

		/// <summary>
		/// Gets a pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the visual.
		/// </summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the
		/// visual. If a matrix transform lookup key has not been set, or if a local matrix transform has been set, a <c>NULL</c>
		/// pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in matrixTransform</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransformlocal HRESULT
		// GetTransformLocal( IXpsOMMatrixTransform **matrixTransform );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IXpsOMMatrixTransform GetTransformLocal();

		/// <summary>Sets the local, unshared matrix transform.</summary>
		/// <param name="matrixTransform">
		/// A pointer to the IXpsOMMatrixTransform interface to be set as the local, unshared matrix transform. A <c>NULL</c> pointer
		/// releases the previously assigned transform.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetTransformLocal</c>, the transform lookup key is released and GetTransformLookup returns a <c>NULL</c>
		/// pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in transform by GetTransform</term>
		/// <term>Object that is returned in matrixTransform by GetTransformLocal</term>
		/// <term>Object that is returned in key by GetTransformLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal (this method)</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// <term>The local transform set by SetTransformLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>
		/// The shared transform that gets retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the
		/// resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetTransformLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-settransformlocal HRESULT
		// SetTransformLocal( IXpsOMMatrixTransform *matrixTransform );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetTransformLocal([In] IXpsOMMatrixTransform matrixTransform);

		/// <summary>
		/// Gets the lookup key name of the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix
		/// transform for the visual.
		/// </summary>
		/// <returns>
		/// <para>
		/// The lookup key name for the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix
		/// transform for the visual. If a matrix transform lookup key has not been set, or if a local matrix transform has been set, a
		/// <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in key</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>The lookup key that is set by SetTransformLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransformlookup HRESULT
		// GetTransformLookup( LPWSTR *key );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		new string GetTransformLookup();

		/// <summary>Sets the lookup key name of a shared matrix transform in a resource dictionary.</summary>
		/// <param name="key">The lookup key name of the matrix transform in the dictionary.</param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetTransformLookup</c>, the local transform is released and GetTransformLocal returns a <c>NULL</c>
		/// pointer in the matrixTransform parameter. The table that follows explains the relationship between the local and lookup
		/// values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in transform by GetTransform</term>
		/// <term>Object that is returned in matrixTransform by GetTransformLocal</term>
		/// <term>Object that is returned in key by GetTransformLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup (this method)</term>
		/// <term>
		/// The shared transform that gets retrieved—with a lookup key that matches the key that is set by SetTransformLookup—from the
		/// resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetTransformLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-settransformlookup HRESULT
		// SetTransformLookup( LPCWSTR key );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

		/// <summary>
		/// Gets a pointer to the IXpsOMGeometry interface that contains the resolved geometry of the visual's clipping region.
		/// </summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMGeometry interface that contains the resolved geometry of the visual's clipping region. If the clip
		/// geometry has not been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the geometry.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in clipGeometry</term>
		/// </listheader>
		/// <item>
		/// <term>SetClipGeometryLocal</term>
		/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetClipGeometryLookup</term>
		/// <term>
		/// The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup,
		/// from the resource directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometry HRESULT
		// GetClipGeometry( IXpsOMGeometry **clipGeometry );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IXpsOMGeometry GetClipGeometry();

		/// <summary>
		/// Gets a pointer to the IXpsOMGeometry interface that contains the local, unshared geometry of the visual's clipping region.
		/// </summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMGeometry interface that contains the local, unshared geometry of the visual's clipping region. If a
		/// clip geometry lookup key has been set, or if a local clip geometry has not been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in clipGeometry</term>
		/// </listheader>
		/// <item>
		/// <term>SetClipGeometryLocal</term>
		/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetClipGeometryLookup</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometrylocal HRESULT
		// GetClipGeometryLocal( IXpsOMGeometry **clipGeometry );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IXpsOMGeometry GetClipGeometryLocal();

		/// <summary>Sets the local, unshared clipping region for the visual.</summary>
		/// <param name="clipGeometry">
		/// A pointer to the IXpsOMGeometry interface to be set as the local, unshared clipping region for the visual. A <c>NULL</c>
		/// pointer releases the previously assigned geometry interface.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetClipGeometryLocal</c>, the clip geometry lookup key is released and GetClipGeometryLookup returns a
		/// <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup
		/// values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in clipGeometry by GetClipGeometry</term>
		/// <term>Object that is returned in clipGeometry by GetClipGeometryLocal</term>
		/// <term>String that is returned in key by GetClipGeometryLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetClipGeometryLocal (this method)</term>
		/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
		/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetClipGeometryLookup</term>
		/// <term>
		/// The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup,
		/// from the resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetClipGeometryLookup nor SetClipGeometryLocal has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setclipgeometrylocal HRESULT
		// SetClipGeometryLocal( IXpsOMGeometry *clipGeometry );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetClipGeometryLocal([In] IXpsOMGeometry clipGeometry);

		/// <summary>
		/// Gets the lookup key for the IXpsOMGeometry interface in a resource dictionary that contains the visual's clipping region.
		/// </summary>
		/// <returns>
		/// <para>
		/// The lookup key for the IXpsOMGeometry interface in a resource dictionary that contains the visual's clipping region. If a
		/// lookup key for the clip geometry has not been set, or if a local clip geometry has been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Lookup key string that is returned in key</term>
		/// </listheader>
		/// <item>
		/// <term>SetClipGeometryLocal</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetClipGeometryLookup</term>
		/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometrylookup
		// HRESULT GetClipGeometryLookup( LPWSTR *key );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		new string GetClipGeometryLookup();

		/// <summary>Sets the lookup key name of a shared clip geometry in a resource dictionary.</summary>
		/// <param name="key">
		/// The lookup key name of the clip geometry in the dictionary. A <c>NULL</c> pointer clears the previously assigned key name.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetClipGeometryLookup</c>, the local clip geometry is released and GetClipGeometryLocal returns a
		/// <c>NULL</c> pointer in the clipGeometry parameter. The table that follows explains the relationship between the local and
		/// lookup values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in clipGeometry by GetClipGeometry</term>
		/// <term>Object that is returned in clipGeometry by GetClipGeometryLocal</term>
		/// <term>String that is returned in key by GetClipGeometryLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetClipGeometryLocal</term>
		/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
		/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetClipGeometryLookup (this method)</term>
		/// <term>
		/// The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup,
		/// from the resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetClipGeometryLookup nor SetClipGeometryLocal has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setclipgeometrylookup
		// HRESULT SetClipGeometryLookup( LPCWSTR key );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetClipGeometryLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

		/// <summary>Gets the opacity value of this visual.</summary>
		/// <returns>The opacity value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacity HRESULT
		// GetOpacity( FLOAT *opacity );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new float GetOpacity();

		/// <summary>Sets the opacity value of the visual.</summary>
		/// <param name="opacity">
		/// <para>The opacity value to be set for the visual.</para>
		/// <para>
		/// The range of allowed values for this parameter is 0.0 to 1.0; with 0.0 the visual is completely transparent, and with 1.0 it
		/// is completely opaque.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacity HRESULT
		// SetOpacity( FLOAT opacity );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetOpacity([In] float opacity);

		/// <summary>Gets a pointer to the IXpsOMBrush interface of the visual's opacity mask brush.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMBrush interface of the visual's opacity mask brush. If an opacity mask brush has not been set for
		/// this visual, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the brush.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in opacityMaskBrush</term>
		/// </listheader>
		/// <item>
		/// <term>SetOpacityMaskBrushLocal</term>
		/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetOpacityMaskBrushLookup</term>
		/// <term>
		/// The shared opacity mask brush that gets retrieved, with a lookup key that matches the key that is set by
		/// SetOpacityMaskBrushLookup, from the resource directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrush HRESULT
		// GetOpacityMaskBrush( IXpsOMBrush **opacityMaskBrush );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IXpsOMBrush GetOpacityMaskBrush();

		/// <summary>Gets the local, unshared opacity mask brush for the visual.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMBrush interface of the visual's opacity mask brush. If an opacity mask brush lookup key has been set,
		/// or if a local opacity mask brush has not been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in opacityMaskBrush</term>
		/// </listheader>
		/// <item>
		/// <term>SetOpacityMaskBrushLocal</term>
		/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetOpacityMaskBrushLookup</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrushlocal
		// HRESULT GetOpacityMaskBrushLocal( IXpsOMBrush **opacityMaskBrush );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IXpsOMBrush GetOpacityMaskBrushLocal();

		/// <summary>Sets the IXpsOMBrush interface pointer as the local, unshared opacity mask brush.</summary>
		/// <param name="opacityMaskBrush">
		/// A pointer to the IXpsOMBrush interface to be set as the local, unshared opacity mask brush. A <c>NULL</c> pointer clears the
		/// previously assigned opacity mask brush.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetOpacityMaskBrushLocal</c>, the opacity mask brush lookup key is released and GetOpacityMaskBrushLookup
		/// returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and
		/// lookup values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrush</term>
		/// <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrushLocal</term>
		/// <term>String that is returned in key by GetOpacityMaskBrushLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetOpacityMaskBrushLocal (this method)</term>
		/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
		/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetOpacityMaskBrushLookup</term>
		/// <term>
		/// The shared opacity mask brush that gets retrieved, with a lookup key that matches the key that is set by
		/// SetOpacityMaskBrushLookup, from the resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacitymaskbrushlocal
		// HRESULT SetOpacityMaskBrushLocal( IXpsOMBrush *opacityMaskBrush );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetOpacityMaskBrushLocal([In] IXpsOMBrush opacityMaskBrush);

		/// <summary>Gets the name of the lookup key of the shared opacity mask brush in a resource dictionary.</summary>
		/// <returns>
		/// <para>
		/// The name of the lookup key of the shared opacity mask brush in a resource dictionary. If the lookup key of an opacity mask
		/// brush has not been set, or if a local opacity mask brush has been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in key</term>
		/// </listheader>
		/// <item>
		/// <term>SetOpacityMaskBrushLocal</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetOpacityMaskBrushLookup</term>
		/// <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrushlookup
		// HRESULT GetOpacityMaskBrushLookup( LPWSTR *key );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		new string GetOpacityMaskBrushLookup();

		/// <summary>Sets the lookup key name of a shared opacity mask brush in a resource dictionary.</summary>
		/// <param name="key">
		/// The lookup key name of the opacity mask brush in the dictionary. A <c>NULL</c> pointer clears the previously assigned key name.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetOpacityMaskBrushLookup</c>, the local opacity mask brush is released and GetOpacityMaskBrushLocal
		/// returns a <c>NULL</c> pointer in the opacityMaskBrush parameter. The table that follows explains the relationship between
		/// the local and lookup values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrush</term>
		/// <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrushLocal</term>
		/// <term>String that is returned in key by GetOpacityMaskBrushLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetOpacityMaskBrushLocal</term>
		/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
		/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetOpacityMaskBrushLookup (this method)</term>
		/// <term>
		/// The shared opacity mask brush that gets retrieved—with a lookup key that matches the key that is set by
		/// SetOpacityMaskBrushLookup—from the resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacitymaskbrushlookup
		// HRESULT SetOpacityMaskBrushLookup( LPCWSTR key );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetOpacityMaskBrushLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

		/// <summary>Gets the <c>Name</c> property of the visual.</summary>
		/// <returns>The <c>Name</c> property string. If the <c>Name</c> property has not been set, a <c>NULL</c> pointer is returned.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getname HRESULT GetName(
		// LPWSTR *name );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		new string GetName();

		/// <summary>Sets the <c>Name</c> property of the visual.</summary>
		/// <param name="name">The name of the visual. A <c>NULL</c> pointer clears the <c>Name</c> property.</param>
		/// <remarks>
		/// <para>Names must be unique.</para>
		/// <para>
		/// Clearing the <c>Name</c> property by passing a <c>NULL</c> pointer in name sets the <c>IsHyperlinkTarget</c> property to <c>FALSE</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setname HRESULT SetName(
		// LPCWSTR name );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetName([In, MarshalAs(UnmanagedType.LPWStr)] string name);

		/// <summary>Gets a value that indicates whether the visual is the target of a hyperlink.</summary>
		/// <returns>
		/// <para>The Boolean value that indicates whether the visual is the target of a hyperlink.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The visual is the target of a hyperlink.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The visual is not the target of a hyperlink.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getishyperlinktarget HRESULT
		// GetIsHyperlinkTarget( BOOL *isHyperlink );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool GetIsHyperlinkTarget();

		/// <summary>Specifies whether the visual is the target of a hyperlink.</summary>
		/// <param name="isHyperlink">
		/// <para>The Boolean value that specifies whether the visual is the target of a hyperlink.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The visual is the target of a hyperlink.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The visual is not the target of a hyperlink.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>The visual must be named before it can be set as the target of a hyperlink.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setishyperlinktarget HRESULT
		// SetIsHyperlinkTarget( BOOL isHyperlink );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetIsHyperlinkTarget([In, MarshalAs(UnmanagedType.Bool)] bool isHyperlink);

		/// <summary>Gets a pointer to the IUri interface to which this visual object links.</summary>
		/// <returns>
		/// A pointer to the IUri interface that contains the destination URI for the link. If a URI has not been set for this object, a
		/// <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gethyperlinknavigateuri
		// HRESULT GetHyperlinkNavigateUri( IUri **hyperlinkUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IUri GetHyperlinkNavigateUri();

		/// <summary>Sets the destination URI of the visual's hyperlink.</summary>
		/// <param name="hyperlinkUri">The IUri interface that contains the destination URI of the visual's hyperlink.</param>
		/// <remarks>
		/// Setting an object's URI makes the object a hyperlink. When activated or clicked, the object will navigate to the destination
		/// that is specified by the URI in hyperlinkUri.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-sethyperlinknavigateuri
		// HRESULT SetHyperlinkNavigateUri( IUri *hyperlinkUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetHyperlinkNavigateUri([In] IUri hyperlinkUri);

		/// <summary>Gets the <c>Language</c> property of the visual and of its contents.</summary>
		/// <returns>
		/// The language string that specifies the language of the page. If a language has not been set, a <c>NULL</c> pointer is returned.
		/// </returns>
		/// <remarks>
		/// <para>The <c>Language</c> property that is set by this method specifies the language of the resource content.</para>
		/// <para>Internet Engineering Task Force (IETF) RFC 3066 specifies the recommended encoding for the <c>Language</c> property.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getlanguage HRESULT
		// GetLanguage( LPWSTR *language );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		new string GetLanguage();

		/// <summary>Sets the <c>Language</c> property of the visual.</summary>
		/// <param name="language">
		/// The language string that specifies the language of the visual and of its contents. A <c>NULL</c> pointer clears the
		/// <c>Language</c> property.
		/// </param>
		/// <remarks>
		/// The recommended encoding for the <c>Language</c> property is specified in Internet Engineering Task Force (IETF) RFC 3066r.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setlanguage HRESULT
		// SetLanguage( LPCWSTR language );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetLanguage([In, MarshalAs(UnmanagedType.LPWStr)] string language);

		/// <summary>
		/// Gets a pointer to an IXpsOMVisualCollection interface that contains a collection of the visual objects in the canvas.
		/// </summary>
		/// <returns>
		/// The collection of the visual objects in the canvas. If no visual objects are attached to the canvas, an empty collection is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-getvisuals HRESULT
		// GetVisuals( IXpsOMVisualCollection **visuals );
		IXpsOMVisualCollection GetVisuals();

		/// <summary>
		/// Gets a Boolean value that determines whether the edges of the objects in the canvas are to be rendered using the aliased
		/// edge mode.
		/// </summary>
		/// <returns>
		/// <para>The Boolean value that determines whether the objects in the canvas are to be rendered using the aliased edge mode.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>
		/// The edges of objects in the canvas are to be rendered without anti-aliasing using the aliased edge mode. This includes any
		/// objects in the canvas that have useAliasedEdgeMode set to FALSE. In the document markup, this corresponds to the
		/// RenderOptions.EdgeMode attribute having a value of Aliased.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>
		/// The edges of objects in the canvas are to be rendered in the default manner. In the document markup, this corresponds to the
		/// RenderOptions.EdgeMode attribute being absent.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The property that is returned by this method corresponds to the <c>RenderOptions.EdgeMode</c> attribute of the <c>Canvas</c>
		/// element in the document markup.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-getusealiasededgemode
		// HRESULT GetUseAliasedEdgeMode( BOOL *useAliasedEdgeMode );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetUseAliasedEdgeMode();

		/// <summary>
		/// Sets the value that determines whether the edges of objects in this canvas will be rendered using the aliased edge mode.
		/// </summary>
		/// <param name="useAliasedEdgeMode">
		/// <para>
		/// The Boolean value that determines whether the edges of child objects in this canvas will be rendered using the aliased edge mode.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>
		/// The edges of objects in the canvas are to be rendered without anti-aliasing using the aliased edge mode. This includes any
		/// objects that have this value set to FALSE. In the document markup, this corresponds to the RenderOptions.EdgeMode attribute
		/// having the value of Aliased.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>
		/// The edges of objects in the canvas are to be rendered in the default manner. In the document markup, this corresponds to the
		/// RenderOptions.EdgeMode attribute being absent.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// This property corresponds to the <c>RenderOptions.EdgeMode</c> attribute of the <c>Canvas</c> element in the document markup.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-setusealiasededgemode
		// HRESULT SetUseAliasedEdgeMode( BOOL useAliasedEdgeMode );
		void SetUseAliasedEdgeMode([MarshalAs(UnmanagedType.Bool)] bool useAliasedEdgeMode);

		/// <summary>
		/// Gets a short textual description of the object's contents. This text is used by accessibility clients to describe the object.
		/// </summary>
		/// <returns>
		/// The short textual description of the object's contents. If this description is not set, a <c>NULL</c> pointer is returned.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property returned by this method corresponds to the <c>AutomationProperties.Name</c> attribute of the <c>Canvas</c>
		/// element in the document markup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-getaccessibilityshortdescription
		// HRESULT GetAccessibilityShortDescription( LPWSTR *shortDescription );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetAccessibilityShortDescription();

		/// <summary>
		/// Sets the short textual description of the object's contents. This text is used by accessibility clients to describe the object.
		/// </summary>
		/// <param name="shortDescription">
		/// The short textual description of the object's contents. A <c>NULL</c> pointer clears the previously assigned text.
		/// </param>
		/// <remarks>
		/// The property that is set by this method corresponds to the <c>AutomationProperties.HelpText</c> attribute of the
		/// <c>Canvas</c> element in the document markup.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-setaccessibilityshortdescription
		// HRESULT SetAccessibilityShortDescription( LPCWSTR shortDescription );
		void SetAccessibilityShortDescription([In, MarshalAs(UnmanagedType.LPWStr)] string shortDescription);

		/// <summary>
		/// Gets the long (detailed) textual description of the object's contents. This text is used by accessibility clients to
		/// describe the object.
		/// </summary>
		/// <returns>
		/// The long (detailed) textual description of the object's contents. A <c>NULL</c> pointer is returned if this text has not
		/// been set.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property returned by this method corresponds to the <c>AutomationProperties.HelpText</c> attribute of the <c>Canvas</c>
		/// element in the document markup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-getaccessibilitylongdescription
		// HRESULT GetAccessibilityLongDescription( LPWSTR *longDescription );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetAccessibilityLongDescription();

		/// <summary>
		/// Sets the long (detailed) textual description of the object's contents. This text is used by accessibility clients to
		/// describe the object.
		/// </summary>
		/// <param name="longDescription">
		/// The long (detailed) textual description of the object's contents. A <c>NULL</c> pointer clears the previously assigned value.
		/// </param>
		/// <remarks>
		/// The property that is set by this method corresponds to the <c>AutomationProperties.HelpText</c> attribute of the
		/// <c>Canvas</c> element in the document markup.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-setaccessibilitylongdescription
		// HRESULT SetAccessibilityLongDescription( LPCWSTR longDescription );
		void SetAccessibilityLongDescription([In, MarshalAs(UnmanagedType.LPWStr)] string longDescription);

		/// <summary>Gets a pointer to the resolved IXpsOMDictionary interface of the dictionary associated with the canvas.</summary>
		/// <returns>
		/// <para>A pointer to the resolved IXpsOMDictionary interface of the dictionary.</para>
		/// <para>The value that is returned in this parameter depends on which method has been most recently called to set the dictionary.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object returned in resourceDictionary</term>
		/// </listheader>
		/// <item>
		/// <term>SetDictionaryLocal</term>
		/// <term>The local dictionary that is set by SetDictionaryLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetDictionaryResource</term>
		/// <term>The shared dictionary in the dictionary resource that is set by SetDictionaryResource.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetDictionaryLocal nor SetDictionaryResource has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>GetDictionary</c> can return the interface pointer of a local or remote dictionary. GetOwner can be called to determine
		/// whether the dictionary is local or remote.
		/// </para>
		/// <para>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-getdictionary HRESULT
		// GetDictionary( IXpsOMDictionary **resourceDictionary );
		IXpsOMDictionary GetDictionary();

		/// <summary>Gets a pointer to the IXpsOMDictionary interface of the local, unshared dictionary.</summary>
		/// <returns>
		/// <para>
		/// The IXpsOMDictionary interface pointer to the local, unshared dictionary, if one has been set. If a local dictionary has not
		/// been set or if a remote dictionary resource has been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object returned in resourceDictionary</term>
		/// </listheader>
		/// <item>
		/// <term>SetDictionaryLocal</term>
		/// <term>The local dictionary that is set by SetDictionaryLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetDictionaryResource</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetDictionaryLocal nor SetDictionaryResource has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When this method loads and parses the resource into the XPS OM, it might return an error that applies to another resource.
		/// This can occur because all of the relationships are parsed when the resource is loaded.
		/// </para>
		/// <para>For more information about other return values that might be returned by this method, see XPS Document Errors.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-getdictionarylocal HRESULT
		// GetDictionaryLocal( IXpsOMDictionary **resourceDictionary );
		IXpsOMDictionary GetDictionaryLocal();

		/// <summary>Sets the IXpsOMDictionary interface pointer of the local, unshared dictionary.</summary>
		/// <param name="resourceDictionary">
		/// The IXpsOMDictionary interface of the local, unshared dictionary. A <c>NULL</c> pointer releases any previously assigned
		/// local dictionary.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetDictionaryLocal</c>, the remote dictionary resource is released and GetDictionaryResource returns a
		/// <c>NULL</c> pointer in the remoteDictionaryResource parameter. The table that follows explains the relationship between the
		/// local and remote values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in resourceDictionary by GetDictionary</term>
		/// <term>Object that is returned in resourceDictionary by GetDictionaryLocal</term>
		/// <term>Object that is returned in remoteDictionaryResource by GetDictionaryResource</term>
		/// </listheader>
		/// <item>
		/// <term>SetDictionaryLocal (this method)</term>
		/// <term>The local dictionary that is set by SetDictionaryLocal.</term>
		/// <term>The local dictionary that is set by SetDictionaryLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetDictionaryResource</term>
		/// <term>The shared dictionary in the dictionary resource that is set by SetDictionaryResource.</term>
		/// <term>NULL pointer.</term>
		/// <term>The remote dictionary resource that is set by SetDictionaryResource.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetDictionaryLocal nor SetDictionaryResource has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-setdictionarylocal HRESULT
		// SetDictionaryLocal( IXpsOMDictionary *resourceDictionary );
		void SetDictionaryLocal([In] IXpsOMDictionary resourceDictionary);

		/// <summary>Gets a pointer to the IXpsOMRemoteDictionaryResource interface of the remote dictionary resource.</summary>
		/// <returns>
		/// <para>
		/// The IXpsOMRemoteDictionaryResource interface pointer to the remote dictionary resource, if one has been set. If a remote
		/// dictionary resource has not been set or if a local dictionary resource has been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object returned in remoteDictionaryResource</term>
		/// </listheader>
		/// <item>
		/// <term>SetDictionaryLocal</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetDictionaryResource</term>
		/// <term>The remote dictionary resource that is set by SetDictionaryResource.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetDictionaryLocal nor SetDictionaryResource has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-getdictionaryresource
		// HRESULT GetDictionaryResource( IXpsOMRemoteDictionaryResource **remoteDictionaryResource );
		IXpsOMRemoteDictionaryResource GetDictionaryResource();

		/// <summary>Sets the IXpsOMRemoteDictionaryResource interface pointer of the remote dictionary resource.</summary>
		/// <param name="remoteDictionaryResource">
		/// The IXpsOMRemoteDictionaryResource interface of the remote dictionary resource. A <c>NULL</c> pointer releases any
		/// previously assigned dictionary resource.
		/// </param>
		/// <remarks>
		/// <para>After calling this method, GetDictionaryLocal returns a <c>NULL</c> pointer in the resourceDictionary parameter.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in resourceDictionary by GetDictionary</term>
		/// <term>Object that is returned in resourceDictionary by GetDictionaryLocal</term>
		/// <term>Object that is returned in remoteDictionaryResource by GetDictionaryResource</term>
		/// </listheader>
		/// <item>
		/// <term>SetDictionaryLocal</term>
		/// <term>The local dictionary that is set by SetDictionaryLocal.</term>
		/// <term>The local dictionary that is set by SetDictionaryLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetDictionaryResource (this method)</term>
		/// <term>The shared dictionary in the dictionary resource that is set by SetDictionaryResource.</term>
		/// <term>NULL pointer.</term>
		/// <term>The remote dictionary resource that is set by SetDictionaryResource.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetDictionaryLocal nor SetDictionaryResource has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-setdictionaryresource
		// HRESULT SetDictionaryResource( IXpsOMRemoteDictionaryResource *remoteDictionaryResource );
		void SetDictionaryResource([In] IXpsOMRemoteDictionaryResource remoteDictionaryResource);

		/// <summary>Makes a deep copy of the interface.</summary>
		/// <returns>A pointer to the copy of the interface.</returns>
		/// <remarks>The owner of the new interface is <c>NULL</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-clone HRESULT Clone(
		// IXpsOMCanvas **canvas );
		IXpsOMCanvas Clone();
	}

	/// <summary>Provides an IStream interface to a color profile resource.</summary>
	/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomcolorprofileresource
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "8a344300-c3fc-4225-bfa5-d5d33798a094")]
	[ComImport, Guid("67BD7D69-1EEF-4BB1-B5E7-6F4F87BE8ABE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMColorProfileResource : IXpsOMResource
	{
		/// <summary>Gets the name that will be used when the part is serialized.</summary>
		/// <returns>
		/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
		/// method), a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
		// GetPartName( IOpcPartUri **partUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IOpcPartUri GetPartName();

		/// <summary>Sets the name that will be used when the part is serialized.</summary>
		/// <param name="partUri">
		/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <remarks>
		/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
		/// has previously serialized.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
		// SetPartName( IOpcPartUri *partUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetPartName([In] IOpcPartUri partUri);

		/// <summary>Gets a new, read-only copy of the stream that is associated with this resource.</summary>
		/// <returns>A new, read-only copy of the stream that is associated with this resource.</returns>
		/// <remarks>
		/// <para>
		/// The IStream object returned by this method might return an error of E_PENDING, which indicates that the stream length has
		/// not been determined yet. This behavior is different from that of a standard <c>IStream</c> object.
		/// </para>
		/// <para>
		/// This method calls the stream's <c>Clone</c> method to create the stream returned in stream. As a result, the performance of
		/// this method will depend on that of the stream's <c>Clone</c> method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresource-getstream
		// HRESULT GetStream( IStream **stream );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IStream GetStream();

		/// <summary>Sets the read-only stream to be associated with this resource.</summary>
		/// <param name="sourceStream">The read-only stream to be associated with this resource.</param>
		/// <param name="partName">The part name to be assigned to this resource.</param>
		/// <remarks>
		/// <para>
		/// The calling method should treat this stream as a single-threaded apartment (STA) model object and not re-enter any of the
		/// stream interface's methods.
		/// </para>
		/// <para>
		/// Because GetStream gets a clone of the stream that is set by this method, the provided stream should have an efficient
		/// cloning method. A stream with an inefficient cloning method will reduce the performance of <c>GetStream</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresource-setcontent
		// HRESULT SetContent( IStream *sourceStream, IOpcPartUri *partName );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetContent([In] IStream sourceStream, [In] IOpcPartUri partName);
	}

	/// <summary>A collection of IXpsOMColorProfileResource interface pointers.</summary>
	/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomcolorprofileresourcecollection
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "cb9253f3-461e-47a3-820b-bb6bf5e30210")]
	[ComImport, Guid("12759630-5FBA-4283-8F7D-CCA849809EDB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMColorProfileResourceCollection
	{
		/// <summary>Gets the number of IXpsOMColorProfileResource interface pointers in the collection.</summary>
		/// <returns>The number of IXpsOMColorProfileResource interface pointers in the collection.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresourcecollection-getcount
		// HRESULT GetCount( UINT32 *count );
		[MethodImpl(MethodImplOptions.InternalCall)]
		uint GetCount();

		/// <summary>Gets an IXpsOMColorProfileResource interface pointer from a specified location in the collection.</summary>
		/// <param name="index">The zero-based index of the IXpsOMColorProfileResource interface pointer to be obtained.</param>
		/// <returns>The IXpsOMColorProfileResource interface pointer at the location specified by index.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresourcecollection-getat
		// HRESULT GetAt( UINT32 index, IXpsOMColorProfileResource **object );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMColorProfileResource GetAt([In] uint index);

		/// <summary>Inserts an IXpsOMColorProfileResource interface pointer at a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection where the interface pointer that is passed in object is to be inserted.
		/// </param>
		/// <param name="object">
		/// The IXpsOMColorProfileResource interface pointer that is to be inserted in the location specified by index.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method inserts the IXpsOMColorProfileResource interface pointer that is passed in
		/// object. Prior to the insertion, the pointer in this and all subsequent locations is moved up by one index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresourcecollection-insertat
		// HRESULT InsertAt( UINT32 index, IXpsOMColorProfileResource *object );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void InsertAt([In] uint index, [In] IXpsOMColorProfileResource @object);

		/// <summary>Removes and releases an IXpsOMColorProfileResource interface pointer from a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection from which an IXpsOMColorProfileResource interface pointer is to be removed and released.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method releases the interface referenced by the pointer at the location specified by index. After releasing the
		/// interface, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresourcecollection-removeat
		// HRESULT RemoveAt( UINT32 index );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void RemoveAt([In] uint index);

		/// <summary>Replaces an IXpsOMColorProfileResource interface pointer at a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection where an IXpsOMColorProfileResource interface pointer is to be replaced.
		/// </param>
		/// <param name="object">
		/// The IXpsOMColorProfileResource interface pointer that will replace current contents at the location specified by index.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method releases the IXpsOMColorProfileResource interface referenced by the existing
		/// pointer, then writes the pointer that is passed in object.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresourcecollection-setat
		// HRESULT SetAt( UINT32 index, IXpsOMColorProfileResource *object );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetAt([In] uint index, [In] IXpsOMColorProfileResource @object);

		/// <summary>Appends an IXpsOMColorProfileResource interface pointer to the end of the collection.</summary>
		/// <param name="object">A pointer to the IXpsOMColorProfileResource interface that is to be appended to the collection.</param>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresourcecollection-append
		// HRESULT Append( IXpsOMColorProfileResource *object );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Append([In] IXpsOMColorProfileResource @object);

		/// <summary>Gets an IXpsOMColorProfileResource interface pointer from the collection by matching the interface's part name.</summary>
		/// <param name="partName">The part name of the IXpsOMColorProfileResource interface to be found in the collection.</param>
		/// <returns>
		/// A pointer to the IXpsOMColorProfileResource interface whose part name matches partName. If a matching interface is not found
		/// in the collection, a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresourcecollection-getbypartname
		// HRESULT GetByPartName( IOpcPartUri *partName, IXpsOMColorProfileResource **part );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMColorProfileResource GetByPartName([In] IOpcPartUri partName);
	}

	/// <summary>A collection of XPS_DASH structures.</summary>
	/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomdashcollection
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "02a152a1-e117-42fb-8428-a2b28e6540a9")]
	[ComImport, Guid("081613F4-74EB-48F2-83B3-37A9CE2D7DC6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMDashCollection
	{
		/// <summary>Gets the number of XPS_DASH structures in the collection.</summary>
		/// <returns>The number of XPS_DASH structures in the collection.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdashcollection-getcount HRESULT
		// GetCount( UINT32 *count );
		uint GetCount();

		/// <summary>Gets an XPS_DASH structure from a specified location in the collection.</summary>
		/// <param name="index">The zero-based index in the collection where an XPS_DASH structure is to be obtained.</param>
		/// <returns>The XPS_DASH structure that is found at the location specified by index.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdashcollection-getat HRESULT GetAt(
		// UINT32 index, XPS_DASH *dash );
		XPS_DASH GetAt([In] uint index);

		/// <summary>Inserts an XPS_DASH structure at a specified location in the collection.</summary>
		/// <param name="index">The zero-based index in the collection where the structure that is referenced by dash is to be inserted.</param>
		/// <param name="dash">A pointer to the XPS_DASH structure that is to be inserted at the location specified by index.</param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method inserts the XPS_DASH structure that is passed in dash. Prior to insertion,
		/// the structure in this and all subsequent locations is moved up by one index.
		/// </para>
		/// <para>The figure that follows illustrates how the collection is changed by the <c>InsertAt</c> method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdashcollection-insertat HRESULT
		// InsertAt( UINT32 index, const XPS_DASH *dash );
		void InsertAt([In] uint index, in XPS_DASH dash);

		/// <summary>Removes and frees an XPS_DASH structure from a specified location in the collection.</summary>
		/// <param name="index">The zero-based index in the collection from which an XPS_DASH structure is to be removed and freed.</param>
		/// <remarks>
		/// <para>
		/// This method removes and frees the XPS_DASH structure referenced by the pointer at the location specified by index. After
		/// freeing the structure, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.
		/// </para>
		/// <para>The figure that follows illustrates how the collection is changed by the <c>RemoveAt</c> method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdashcollection-removeat HRESULT
		// RemoveAt( UINT32 index );
		void RemoveAt([In] uint index);

		/// <summary>Replaces an XPS_DASH structure at a specified location in the collection.</summary>
		/// <param name="index">The zero-based index in the collection where an XPS_DASH structure is to be replaced.</param>
		/// <param name="dash">
		/// A pointer to the XPS_DASH structure that will replace the current contents at the location specified by index.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method frees the existing XPS_DASH structure then replaces it with the structure
		/// that is passed in dash.
		/// </para>
		/// <para>The figure that follows illustrates how the collection is changed by the <c>SetAt</c> method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdashcollection-setat HRESULT SetAt(
		// UINT32 index, const XPS_DASH *dash );
		void SetAt([In] uint index, in XPS_DASH dash);

		/// <summary>Appends an XPS_DASH structure to the end of the collection.</summary>
		/// <param name="dash">A pointer to the XPS_DASH structure that is to be appended to the collection.</param>
		/// <remarks>The figure that follows illustrates how the collection is changed by the <c>Append</c> method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdashcollection-append HRESULT
		// Append( const XPS_DASH *dash );
		void Append(in XPS_DASH dash);
	}

	/// <summary>The dictionary is used by an XPS package to share resources.</summary>
	/// <remarks>
	/// <para>
	/// The interface pointers stored in a dictionary will usually point to interfaces, such as IXpsOMBrush and IXpsOMVisual, that are
	/// derived from the IXpsOMShareable interface. To determine the interface type, call the IXpsOMShareable::GetType method.
	/// </para>
	/// <para>A dictionary cannot contain duplicate interface pointers.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomdictionary
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "f887e3d3-973c-4267-a785-6bc190c13082")]
	[ComImport, Guid("897C86B8-8EAF-4AE3-BDDE-56419FCF4236"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMDictionary
	{
		/// <summary>Gets a pointer to the interface that contains the dictionary.</summary>
		/// <returns>The <c>IUnknown</c> interface of the interface that contains the dictionary.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-getowner HRESULT
		// GetOwner( IUnknown **owner );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object GetOwner();

		/// <summary>Gets the number of entries in the dictionary.</summary>
		/// <returns>The number of entries in the dictionary.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-getcount HRESULT
		// GetCount( UINT32 *count );
		uint GetCount();

		/// <summary>
		/// Gets the IXpsOMShareable interface pointer and the key name string of the entry at a specified index in the dictionary.
		/// </summary>
		/// <param name="index">The zero-based index of the dictionary entry that is to be obtained.</param>
		/// <param name="key">The key string that is found at the location specified by index.</param>
		/// <returns>The IXpsOMShareable interface pointer that is found at the location specified by index.</returns>
		/// <remarks>
		/// <para>
		/// The interface pointers that are stored in a dictionary will usually point to interfaces, such as IXpsOMBrush and
		/// IXpsOMVisual, that are derived from the IXpsOMShareable interface. To determine the interface type, call the
		/// IXpsOMShareable::GetType method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-getat HRESULT GetAt(
		// UINT32 index, LPWSTR *key, IXpsOMShareable **entry );
		IXpsOMShareable GetAt([In] uint index, [MarshalAs(UnmanagedType.LPWStr)] out string key);

		/// <summary>Gets the IXpsOMShareable interface pointer of the entry that contains the specified key.</summary>
		/// <param name="key">The entry's key to be found in the dictionary.</param>
		/// <param name="beforeEntry">
		/// The IXpsOMShareable interface pointer to the last entry in the dictionary which is to be searched for key. If beforeEntry is
		/// <c>NULL</c> or is an interface pointer to an entry that is not in the dictionary, the entire dictionary will be searched.
		/// </param>
		/// <returns>The interface pointer to the dictionary entry whose key matches key.</returns>
		/// <remarks>
		/// The interface pointers stored in a dictionary will usually point to interfaces, such as IXpsOMBrush and IXpsOMVisual, that
		/// are derived from the IXpsOMShareable interface. To determine the interface type, call the IXpsOMShareable::GetType method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-getbykey HRESULT
		// GetByKey( LPCWSTR key, IXpsOMShareable *beforeEntry, IXpsOMShareable **entry );
		IXpsOMShareable GetByKey([In, MarshalAs(UnmanagedType.LPWStr)] string key, [In] IXpsOMShareable beforeEntry);

		/// <summary>Gets the index of an IXpsOMShareable interface from the dictionary.</summary>
		/// <param name="entry">The IXpsOMShareable interface pointer to be found in the dictionary.</param>
		/// <returns>The zero-based index of entry in the dictionary.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-getindex HRESULT
		// GetIndex( IXpsOMShareable *entry, UINT32 *index );
		uint GetIndex([In] IXpsOMShareable entry);

		/// <summary>Appends an IXpsOMShareable interface along with its key to the end of the dictionary.</summary>
		/// <param name="key">
		/// <para>The key to be used for this entry.</para>
		/// <para>The string referenced by key must be unique in the dictionary.</para>
		/// </param>
		/// <param name="entry">
		/// <para>A pointer to the IXpsOMShareable interface that is to be appended to the dictionary.</para>
		/// <para>
		/// A dictionary cannot contain duplicate interface pointers. This parameter must contain an interface pointer that is not
		/// already in the dictionary.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The interface pointers stored in a dictionary will usually point to interfaces, such as IXpsOMBrush and IXpsOMVisual, that
		/// are derived from the IXpsOMShareable interface. To determine the interface type, call the IXpsOMShareable::GetType method.
		/// </para>
		/// <para>The figure that follows illustrates how the dictionary is changed by the <c>Append</c> method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-append HRESULT Append(
		// LPCWSTR key, IXpsOMShareable *entry );
		void Append([In, MarshalAs(UnmanagedType.LPWStr)] string key, [In] IXpsOMShareable entry);

		/// <summary>
		/// Inserts an IXpsOMShareable interface at a specified location in the dictionary and sets the key to identify the interface.
		/// </summary>
		/// <param name="index">The zero-based index in the dictionary where the IXpsOMShareable interface is to be inserted.</param>
		/// <param name="key">
		/// <para>The key to be used to identify the IXpsOMShareable interface in the dictionary.</para>
		/// <para>The string referenced by key must be unique in the dictionary.</para>
		/// </param>
		/// <param name="entry">
		/// <para>The IXpsOMShareable interface pointer to be inserted at the location specified by index.</para>
		/// <para>
		/// A dictionary cannot contain duplicate interface pointers. This parameter must contain an interface pointer that is not
		/// already in the dictionary.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The interface pointers stored in the dictionary will usually be pointers to interfaces, such as IXpsOMBrush and
		/// IXpsOMVisual, that are derived from the IXpsOMShareable interface. To determine the interface type, call the
		/// IXpsOMShareable::GetType method.
		/// </para>
		/// <para>
		/// At the location specified by index, this method inserts the IXpsOMShareable interface pointer and sets the key; the
		/// interface pointer and key are passed in value and key, respectively. Before value and key are inserted, the interface
		/// pointer and the key at this and all subsequent locations are moved up by one index.
		/// </para>
		/// <para>The figure that follows illustrates how the dictionary is changed by the <c>InsertAt</c> method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-insertat HRESULT
		// InsertAt( UINT32 index, LPCWSTR key, IXpsOMShareable *entry );
		void InsertAt([In] uint index, [In, MarshalAs(UnmanagedType.LPWStr)] string key, [In] IXpsOMShareable entry);

		/// <summary>Removes and releases the entry from a specified location in the dictionary.</summary>
		/// <param name="index">The zero-based index in the dictionary from which an entry is to be removed and released.</param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method releases the interface referenced by the pointer. After releasing the
		/// interface, this method compacts the dictionary by reducing by 1 the index of each pointer subsequent to index.
		/// </para>
		/// <para>The figure that follows illustrates how the dictionary is changed by the <c>RemoveAt</c> method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-removeat HRESULT
		// RemoveAt( UINT32 index );
		void RemoveAt([In] uint index);

		/// <summary>Replaces the entry at a specified location in the dictionary.</summary>
		/// <param name="index">The zero-based index in the dictionary in which an entry is to be replaced.</param>
		/// <param name="key">
		/// <para>The key to be used for the new entry.</para>
		/// <para>The string referenced by key must be unique in the dictionary.</para>
		/// </param>
		/// <param name="entry">
		/// <para>The IXpsOMShareable interface pointer that will replace current contents at the location specified by index.</para>
		/// <para>
		/// A dictionary cannot contain duplicate interface pointers. This parameter must contain an interface pointer that is not
		/// already in the dictionary.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method releases the IXpsOMShareable interface referenced by the existing pointer,
		/// then replaces it with the interface pointer that is passed in entry and assigns it the key passed in key.
		/// </para>
		/// <para>
		/// The interface pointers stored in a dictionary will usually point to interfaces, such as IXpsOMBrush and IXpsOMVisual, that
		/// are derived from the IXpsOMShareable interface. To determine the interface type, call the GetType method.
		/// </para>
		/// <para>The figure that follows illustrates how the dictionary is changed by the <c>SetAt</c> method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-setat HRESULT SetAt(
		// UINT32 index, LPCWSTR key, IXpsOMShareable *entry );
		void SetAt([In] uint index, [In, MarshalAs(UnmanagedType.LPWStr)] string key, [In] IXpsOMShareable entry);

		/// <summary>Makes a deep copy of the interface.</summary>
		/// <returns>A pointer to the copy of the interface.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-clone HRESULT Clone(
		// IXpsOMDictionary **dictionary );
		IXpsOMDictionary Clone();
	}

	/// <summary>
	/// Provides access to the XML content of the resource stream of the DocumentStructure part.The
	/// <c>IXpsOMDocumentStructureResource</c> interface enables a program to read and replace the XML content of the DocumentStructure part.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The DocumentStructure part of an XPS document contains the document outline, which, along with the StoryFragments parts, defines
	/// the reading order of every element that appears in the fixed pages of the document.
	/// </para>
	/// <para>
	/// The reading order of an XPS document is organized into semantic blocks called stories. Stories are logical units of the
	/// document, in the same way that articles are units in a magazine. Stories are made up of one or more StoryFragments parts;
	/// StoryFragments parts contain the XML markup that defines the story's semantic blocks, which describe the structure of the
	/// document's content. Examples of a story's semantic blocks include paragraphs and tables.
	/// </para>
	/// <para>The XML markup in the DocumentStructure and StoryFragments parts is described in the XML Paper Specification.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomdocumentstructureresource
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "a0cc8748-08b2-4471-9961-603786e983a4")]
	[ComImport, Guid("85FEBC8A-6B63-48A9-AF07-7064E4ECFF30"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMDocumentStructureResource : IXpsOMResource
	{
		/// <summary>Gets the name that will be used when the part is serialized.</summary>
		/// <returns>
		/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
		/// method), a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
		// GetPartName( IOpcPartUri **partUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IOpcPartUri GetPartName();

		/// <summary>Sets the name that will be used when the part is serialized.</summary>
		/// <param name="partUri">
		/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <remarks>
		/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
		/// has previously serialized.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
		// SetPartName( IOpcPartUri *partUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetPartName([In] IOpcPartUri partUri);

		/// <summary>Gets a pointer to the IXpsOMDocument interface that contains the resource.</summary>
		/// <returns>
		/// A pointer to the IXpsOMDocument interface that contains the resource. If the resource is not part of a document, a NULL
		/// pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentstructureresource-getowner
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMDocument GetOwner();

		/// <summary>Gets a new, read-only copy of the stream that is associated with this resource.</summary>
		/// <returns>A new, read-only copy of the stream that is associated with this resource.</returns>
		/// <remarks>
		/// <para>
		/// The IStream object returned by this method might return an error of E_PENDING, which indicates that the stream length has
		/// not been determined yet. This behavior is different from that of a standard <c>IStream</c> object.
		/// </para>
		/// <para>For more information about the content of DocumentStructure part, see the XML Paper Specification.</para>
		/// <para>
		/// This method calls the stream's <c>Clone</c> method to create the stream returned in stream. As a result, the performance of
		/// this method will depend on that of the stream's <c>Clone</c> method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentstructureresource-getstream
		// HRESULT GetStream( IStream **stream );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IStream GetStream();

		/// <summary>Sets the read-only stream to be associated with this resource.</summary>
		/// <param name="sourceStream">The read-only stream to be associated with this resource.</param>
		/// <param name="partName">The part name to be assigned to this resource.</param>
		/// <remarks>
		/// <para>
		/// The calling method should treat this stream as a single-threaded apartment (STA) model object and not re-enter any of the
		/// stream interface's methods.
		/// </para>
		/// <para>For more information about the content of DocumentStructure part, see the XML Paper Specification.</para>
		/// <para>
		/// Because GetStream gets a clone of the stream that is set by this method, the provided stream should have an efficient
		/// cloning method. A stream with an inefficient cloning method will reduce the performance of <c>GetStream</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentstructureresource-setcontent
		// HRESULT SetContent( IStream *sourceStream, IOpcPartUri *partName );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetContent([In] IStream sourceStream, [In] IOpcPartUri partName);
	}

	/// <summary>Provides an IStream interface to a font resource.</summary>
	/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomfontresource
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "dd0ce1c0-1c04-46a8-9075-93de9b3e3062")]
	[ComImport, Guid("A8C45708-47D9-4AF4-8D20-33B48C9B8485"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMFontResource : IXpsOMResource
	{
		/// <summary>Gets the name that will be used when the part is serialized.</summary>
		/// <returns>
		/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
		/// method), a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
		// GetPartName( IOpcPartUri **partUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IOpcPartUri GetPartName();

		/// <summary>Sets the name that will be used when the part is serialized.</summary>
		/// <param name="partUri">
		/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <remarks>
		/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
		/// has previously serialized.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
		// SetPartName( IOpcPartUri *partUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetPartName([In] IOpcPartUri partUri);

		/// <summary>Gets a new, read-only copy of the stream that is associated with this resource.</summary>
		/// <returns>A new, read-only copy of the stream that is associated with this resource.</returns>
		/// <remarks>
		/// <para>
		/// The IStream object returned by this method might return an error of E_PENDING, which indicates that the stream length has
		/// not been determined yet. This behavior is different from that of a standard <c>IStream</c> object.
		/// </para>
		/// <para>
		/// This method calls the stream's <c>Clone</c> method to create the stream returned in stream. As a result, the performance of
		/// this method will depend on that of the stream's <c>Clone</c> method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresource-getstream HRESULT
		// GetStream( IStream **readerStream );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IStream GetStream();

		/// <summary>Sets the read-only stream to be associated with this resource.</summary>
		/// <param name="sourceStream">The read-only stream to be associated with this resource.</param>
		/// <param name="embeddingOption">
		/// <para>The XPS_FONT_EMBEDDING value that describes how the resource is to be obfuscated.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>XPS_FONT_EMBEDDING_NORMAL</term>
		/// <term>Font resource is neither obfuscated nor restricted.</term>
		/// </item>
		/// <item>
		/// <term>XPS_FONT_EMBEDDING_OBFUSCATED</term>
		/// <term>Font resource is obfuscated but not restricted.</term>
		/// </item>
		/// <item>
		/// <term>XPS_FONT_EMBEDDING_RESTRICTED</term>
		/// <term>Font resource is both obfuscated and restricted.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="partName">The part name to be assigned to this resource.</param>
		/// <remarks>
		/// <para>
		/// The calling method should treat this stream as a single-threaded apartment (STA) model object and not re-enter any of the
		/// stream interface's methods.
		/// </para>
		/// <para>
		/// The stream assigned to this resource should not be obfuscated. Obfuscation of the font resource takes place during serialization.
		/// </para>
		/// <para>
		/// Providing an obfuscated font stream while setting the embeddingOption to XPS_FONT_EMBEDDING_OBFUSCATED will result in a font
		/// that is not obfuscated in the serialized XPS document.
		/// </para>
		/// <para>
		/// partName resets the part name for this object and is checked against the value of embeddingOption for the proper obfuscation syntax.
		/// </para>
		/// <para>
		/// Because GetStream gets a clone of the stream that is set by this method, the provided stream should have an efficient
		/// cloning method. A stream with an inefficient cloning method will reduce the performance of <c>GetStream</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresource-setcontent HRESULT
		// SetContent( IStream *sourceStream, XPS_FONT_EMBEDDING embeddingOption, IOpcPartUri *partName );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetContent([In] IStream sourceStream, [In] XPS_FONT_EMBEDDING embeddingOption, [In] IOpcPartUri partName);

		/// <summary>Gets the embedding option that will be applied when the resource is serialized.</summary>
		/// <returns>
		/// <para>The stream's embedding option.</para>
		/// <para>
		/// The XPS_FONT_EMBEDDING value describes how the resource is obfuscated. The following possible values are returned in this parameter:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>XPS_FONT_EMBEDDING_NORMAL</term>
		/// <term>Font resource is neither obfuscated nor restricted.</term>
		/// </item>
		/// <item>
		/// <term>XPS_FONT_EMBEDDING_OBFUSCATED</term>
		/// <term>Font resource is obfuscated but not restricted.</term>
		/// </item>
		/// <item>
		/// <term>XPS_FONT_EMBEDDING_RESTRICTED</term>
		/// <term>Font resource is both obfuscated and restricted.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresource-getembeddingoption
		// HRESULT GetEmbeddingOption( XPS_FONT_EMBEDDING *embeddingOption );
		[MethodImpl(MethodImplOptions.InternalCall)]
		XPS_FONT_EMBEDDING GetEmbeddingOption();
	}

	/// <summary>A collection of IXpsOMFontResource interface pointers.</summary>
	/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomfontresourcecollection
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "71153c4c-631b-4f7a-9dd5-8537dcaca150")]
	[ComImport, Guid("70B4A6BB-88D4-4FA8-AAF9-6D9C596FDBAD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMFontResourceCollection
	{
		/// <summary>Gets the number of IXpsOMFontResource interface pointers in the collection.</summary>
		/// <returns>The number of IXpsOMFontResource interface pointers in the collection.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresourcecollection-getcount
		// HRESULT GetCount( UINT32 *count );
		[MethodImpl(MethodImplOptions.InternalCall)]
		uint GetCount();

		/// <summary>Gets an IXpsOMFontResource interface pointer from a specified location in the collection.</summary>
		/// <param name="index">The zero-based index of the IXpsOMFontResource interface pointer to be obtained.</param>
		/// <returns>The IXpsOMFontResource interface pointer at the location specified by index.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresourcecollection-getat
		// HRESULT GetAt( UINT32 index, IXpsOMFontResource **value );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMFontResource GetAt([In] uint index);

		/// <summary>Replaces an IXpsOMFontResource interface pointer at a specified location in the collection.</summary>
		/// <param name="index">The zero-based index in the collection where an IXpsOMFontResource interface pointer is to be replaced.</param>
		/// <param name="value">
		/// The IXpsOMFontResource interface pointer that will replace current contents at the location specified by index.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method releases the IXpsOMFontResource interface referenced by the existing
		/// pointer, then writes the pointer that is passed in value.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresourcecollection-setat
		// HRESULT SetAt( UINT32 index, IXpsOMFontResource *value );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetAt([In] uint index, [In] IXpsOMFontResource value);

		/// <summary>Inserts an IXpsOMFontResource interface pointer at a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection where the interface pointer that is passed in value is to be inserted.
		/// </param>
		/// <param name="value">The IXpsOMFontResource interface pointer that is to be inserted at the location specified by index.</param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method inserts the IXpsOMFontResource interface pointer that is passed in value.
		/// Prior to the insertion, the pointer in this and all subsequent locations is moved up by one index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresourcecollection-insertat
		// HRESULT InsertAt( UINT32 index, IXpsOMFontResource *value );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void InsertAt([In] uint index, [In] IXpsOMFontResource value);

		/// <summary>Appends an IXpsOMFontResource interface to the end of the collection.</summary>
		/// <param name="value">A pointer to the IXpsOMFontResource interface that is to be appended to the collection.</param>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresourcecollection-append
		// HRESULT Append( IXpsOMFontResource *value );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Append([In] IXpsOMFontResource value);

		/// <summary>Removes and releases an IXpsOMFontResource interface pointer from a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection from which an IXpsOMFontResource interface pointer is to be removed and released.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method releases the interface referenced by the pointer at the location specified by index. After releasing the
		/// interface, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresourcecollection-removeat
		// HRESULT RemoveAt( UINT32 index );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void RemoveAt([In] uint index);

		/// <summary>Gets an IXpsOMFontResource interface pointer from the collection by matching the interface's part name.</summary>
		/// <param name="partName">The part name of the IXpsOMFontResource interface to be found in the collection.</param>
		/// <returns>
		/// A pointer to the IXpsOMFontResource interface that has the matching part name. If a matching interface is not found in the
		/// collection, a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresourcecollection-getbypartname
		// HRESULT GetByPartName( IOpcPartUri *partName, IXpsOMFontResource **part );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMFontResource GetByPartName([In] IOpcPartUri partName);
	}

	/// <summary>Describes the shape of a path or of a clipping region.</summary>
	/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomgeometry
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "d3f74c1e-49ef-40ee-a2f4-b6d198b57624")]
	[ComImport, Guid("64FCF3D7-4D58-44BA-AD73-A13AF6492072"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMGeometry : IXpsOMShareable
	{
		/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
		/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner HRESULT
		// GetOwner( IUnknown **owner );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		new object GetOwner();

		/// <summary>Gets the object type of the interface.</summary>
		/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype HRESULT GetType(
		// XPS_OBJECT_TYPE *type );
		new XPS_OBJECT_TYPE GetType();

		/// <summary>
		/// Gets a pointer to the geometry's IXpsOMGeometryFigureCollection interface, which contains the collection of figures that
		/// make up this geometry.
		/// </summary>
		/// <returns>A pointer to the IXpsOMGeometryFigureCollection interface.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-getfigures HRESULT
		// GetFigures( IXpsOMGeometryFigureCollection **figures );
		IXpsOMGeometryFigureCollection GetFigures();

		/// <summary>Gets the XPS_FILL_RULE value that describes the fill rule to be used.</summary>
		/// <returns>The XPS_FILL_RULE value that describes the fill rule to be used.</returns>
		/// <remarks>
		/// <para>For more information about how the file rule determines whether a point is inside the fill region, see XPS_FILL_RULE.</para>
		/// <para>
		/// The value that is returned in fillRule corresponds to the <c>FillRule</c> attribute of the <c>PathGeometry</c> element in
		/// the document markup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-getfillrule HRESULT
		// GetFillRule( XPS_FILL_RULE *fillRule );
		XPS_FILL_RULE GetFillRule();

		/// <summary>Sets the XPS_FILL_RULE value that describes the fill rule to be used.</summary>
		/// <param name="fillRule">The XPS_FILL_RULE value that describes the fill rule to be used.</param>
		/// <remarks>
		/// <para>For more information about how the file rule determines whether a point is inside the fill region, see XPS_FILL_RULE.</para>
		/// <para>In the document markup, this value corresponds to the <c>FillRule</c> attribute of the <c>PathGeometry</c> element.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-setfillrule HRESULT
		// SetFillRule( XPS_FILL_RULE fillRule );
		void SetFillRule([In] XPS_FILL_RULE fillRule);

		/// <summary>
		/// Gets a pointer to the geometry's IXpsOMMatrixTransform interface, which contains the resolved matrix transform for the geometry.
		/// </summary>
		/// <returns>
		/// <para>
		/// A pointer to the geometry's IXpsOMMatrixTransform interface, which contains the resolved matrix transform for the geometry.
		/// If a matrix transform has not been set, a <c>NULL</c> pointer will be returned.
		/// </para>
		/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the transform.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in transform</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>
		/// The shared transform retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-gettransform HRESULT
		// GetTransform( IXpsOMMatrixTransform **transform );
		IXpsOMMatrixTransform GetTransform();

		/// <summary>
		/// Gets a pointer to the IXpsOMMatrixTransform interface that contains the local, unshared matrix transform for the geometry.
		/// </summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMMatrixTransform interface that contains the local, unshared matrix transform for the geometry. A
		/// <c>NULL</c> pointer is returned if a local matrix transform has not been set or a matrix transform lookup key has been set.
		/// </para>
		/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the transform.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in transform</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-gettransformlocal HRESULT
		// GetTransformLocal( IXpsOMMatrixTransform **transform );
		IXpsOMMatrixTransform GetTransformLocal();

		/// <summary>Sets the local, unshared matrix transform.</summary>
		/// <param name="transform">
		/// A pointer to the IXpsOMMatrixTransform interface to be set as the local, unshared matrix transform for the geometry.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetTransformLocal</c>, the transform lookup key is released and GetTransformLookup returns a <c>NULL</c>
		/// pointer in the lookup parameter. The table that follows explains the relationship between the local and lookup values of
		/// this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in transform by GetTransform</term>
		/// <term>Object that is returned in transform by GetTransformLocal</term>
		/// <term>Object that is returned in lookup by GetTransformLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal (this method)</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>
		/// The shared transform retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetTransformLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-settransformlocal HRESULT
		// SetTransformLocal( IXpsOMMatrixTransform *transform );
		void SetTransformLocal([In] IXpsOMMatrixTransform transform);

		/// <summary>
		/// Gets the lookup key for the IXpsOMMatrixTransform interface that contains the resolved matrix transform for the geometry.
		/// The matrix transform is stored in a resource dictionary.
		/// </summary>
		/// <returns>
		/// <para>
		/// The lookup key for the IXpsOMMatrixTransform interface in a resource dictionary. A <c>NULL</c> pointer is returned if a
		/// matrix transform lookup key has not been set or if a local matrix transform has been set.
		/// </para>
		/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the transform.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in lookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>The lookup key set by SetTransformLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-gettransformlookup HRESULT
		// GetTransformLookup( LPWSTR *lookup );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetTransformLookup();

		/// <summary>Sets the lookup key name of a shared matrix transform in a resource dictionary.</summary>
		/// <param name="lookup">The key name of the shared matrix transform in the resource dictionary.</param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetTransformLookup</c>, the local transform is released and GetTransformLocal returns a <c>NULL</c>
		/// pointer in the transform parameter. The table that follows explains the relationship between the local and lookup values of
		/// this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in transform by GetTransform</term>
		/// <term>Object that is returned in transform by GetTransformLocal</term>
		/// <term>Object that is returned in lookup by GetTransformLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup (this method)</term>
		/// <term>
		/// The shared transform retrieved, with a lookup key that matches the key set by SetTransformLookup, from the resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetTransformLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-settransformlookup HRESULT
		// SetTransformLookup( LPCWSTR lookup );
		void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string lookup);

		/// <summary>Makes a deep copy of the interface.</summary>
		/// <returns>A pointer to the copy of the interface.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-clone HRESULT Clone(
		// IXpsOMGeometry **geometry );
		IXpsOMGeometry Clone();
	}

	/// <summary>Describes one portion of the path or clipping region that is specified by an IXpsOMGeometry interface.</summary>
	/// <remarks>
	/// <para>The <c>IXpsOMGeometryFigure</c> corresponds to the <c>PathFigure</c> element in XPS markup.</para>
	/// <para>The code example that follows illustrates how to create an instance of this interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomgeometryfigure
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "e76a14ce-cfc3-4a50-855e-f5779b9fc261")]
	[ComImport, Guid("D410DC83-908C-443E-8947-B1795D3C165A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMGeometryFigure
	{
		/// <summary>Gets a pointer to the IXpsOMGeometry interface that contains the geometry figure.</summary>
		/// <returns>
		/// A pointer to the IXpsOMGeometry interface that contains the geometry figure. If the interface is not assigned to a geometry,
		/// a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getowner HRESULT
		// GetOwner( IXpsOMGeometry **owner );
		IXpsOMGeometry GetOwner();

		/// <summary>Gets the segment data points for the geometry figure.</summary>
		/// <param name="dataCount">
		/// <para>The size of the array referenced by the segmentData parameter.</para>
		/// <para>
		/// If the method returns successfully, dataCount will contain the number of elements returned in the array that is referenced
		/// by segmentData.
		/// </para>
		/// <para>If segmentData is set to <c>NULL</c> when the method is called, dataCount must be set to zero.</para>
		/// <para>
		/// If a <c>NULL</c> pointer is returned in segmentData, dataCount will contain the required buffer size as the number of elements.
		/// </para>
		/// </param>
		/// <param name="segmentData">
		/// <para>
		/// The address of an array that has the same number of elements as specified in dataCount. This value can be set to <c>NULL</c>
		/// if the caller requires that the method return only the required buffer size in dataCount.
		/// </para>
		/// <para>
		/// If the array is large enough, this method copies the segment data points into the array and returns, in dataCount, the
		/// number of data points that are copied. If segmentData is set to <c>NULL</c> or references a buffer that is not large enough,
		/// a <c>NULL</c> pointer will be returned, no data will be copied, and dataCount will contain the required buffer size
		/// specified as the number of elements.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>To determine the required size of the segment data array before calling this method, call GetSegmentDataCount.</para>
		/// <para>
		/// A geometry segment is described by the start point, the segment type, and additional parameters whose values are determined
		/// by the segment type. The coordinates for the start point of the first segment are a property of the geometry figure and are
		/// set by calling SetStartPoint. The start point of each subsequent segment is the end point of the preceding segment.
		/// </para>
		/// <para>
		/// The values in the array returned in the segmentData parameter will correspond with the XPS_SEGMENT_TYPE values in the array
		/// returned by the GetSegmentTypes method in the segmentTypes parameter. To read the segment data values correctly, you will
		/// need to know the type of each segment in the geometry figure. For example, if the first line segment has a segment type
		/// value of <c>XPS_SEGMENT_TYPE_LINE</c>, the first two data values in the segmentData array will be the x and y coordinates of
		/// the end point of that segment; if the next segment has a segment type value of <c>XPS_SEGMENT_TYPE_BEZIER</c>, the next six
		/// values in the segmentData array will describe the characteristics of that segment; and so on for each line segment in the
		/// geometry figure.
		/// </para>
		/// <para>
		/// The table that follows describes the specific set of data values that are returned for each segment type. For an example of
		/// how to access this data in a program, see the code example that follows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Segment type</term>
		/// <term>Required data values</term>
		/// </listheader>
		/// <item>
		/// <term>XPS_SEGMENT_TYPE_LINE</term>
		/// <term>Two data values: x-coordinate of the segment line's end point. y-coordinate of the segment line's end point.</term>
		/// </item>
		/// <item>
		/// <term>XPS_SEGMENT_TYPE_ARC_LARGE_CLOCKWISE</term>
		/// <term>
		/// Five data values: x-coordinate of the arc's end point. y-coordinate of the arc's end point. Length of the ellipse's radius
		/// along the x-axis. Length of the ellipse's radius along the y-axis. Rotation angle.
		/// </term>
		/// </item>
		/// <item>
		/// <term>XPS_SEGMENT_TYPE_ARC_SMALL_CLOCKWISE</term>
		/// <term>
		/// Five data values: x-coordinate of the arc's end point. y-coordinate of the arc's end point. Length of the ellipse's radius
		/// along the x-axis. Length of the ellipse's radius along the y-axis. Rotation angle.
		/// </term>
		/// </item>
		/// <item>
		/// <term>XPS_SEGMENT_TYPE_ARC_LARGE_COUNTERCLOCKWISE</term>
		/// <term>
		/// Five data values: x-coordinate of the arc's end point. y-coordinate of the arc's end point. Length of the ellipse's radius
		/// along the x-axis. Length of the ellipse's radius along the y-axis. Rotation angle.
		/// </term>
		/// </item>
		/// <item>
		/// <term>XPS_SEGMENT_TYPE_ARC_SMALL_COUNTERCLOCKWISE</term>
		/// <term>
		/// Five data values: x-coordinate of the arc's end point. y-coordinate of the arc's end point. Length of the ellipse's radius
		/// along the x-axis. Length of the ellipse's radius along the y-axis. Rotation angle.
		/// </term>
		/// </item>
		/// <item>
		/// <term>XPS_SEGMENT_TYPE_BEZIER</term>
		/// <term>
		/// Six data values: x-coordinate of the Bezier curve's first control point. y-coordinate of the Bezier curve's first control
		/// point. x-coordinate of the Bezier curve's second control point. y-coordinate of the Bezier curve's second control point.
		/// x-coordinate of the Bezier curve's end point. y-coordinate of the Bezier curve's end point.
		/// </term>
		/// </item>
		/// <item>
		/// <term>XPS_SEGMENT_TYPE_QUADRATIC_BEZIER</term>
		/// <term>
		/// Four data values: x-coordinate of the Quad Bezier curve's control point. y-coordinate of the Quad Bezier curve's control
		/// point. x-coordinate of the Quad Bezier curve's end point. y-coordinate of the Quad Bezier curve's end point.
		/// </term>
		/// </item>
		/// </list>
		/// <para>The following code example accesses the different data points of each segment type in a geometry figure.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getsegmentdata
		// HRESULT GetSegmentData( UINT32 *dataCount, FLOAT *segmentData );
		void GetSegmentData([In, Out] ref uint dataCount, [In, Out] float[] segmentData);

		/// <summary>Gets the types of segments in the figure.</summary>
		/// <param name="segmentCount">
		/// <para>The size of the array that is referenced by segmentTypes (see below). This parameter must not be <c>NULL</c>.</para>
		/// <para>
		/// If the method returns successfully, segmentCount will contain the number of elements that are returned in the array
		/// referenced by segmentTypes.
		/// </para>
		/// <para>If segmentTypes is <c>NULL</c> when the method is called, segmentCount must be set to zero.</para>
		/// <para>
		/// If a <c>NULL</c> pointer is returned in segmentTypes, the value of segmentCount will contain the required buffer size,
		/// specified as the number of elements.
		/// </para>
		/// </param>
		/// <param name="segmentTypes">
		/// <para>
		/// An array of XPS_SEGMENT_TYPE values that has the same number of elements as specified in segmentCount. If the caller
		/// requires that only the specified buffer size be returned, set this value to <c>NULL</c>.
		/// </para>
		/// <para>
		/// If the array is large enough, this method will copy the XPS_SEGMENT_TYPE values into the array and return, in segmentCount,
		/// the number of the copied values. If segmentTypes is <c>NULL</c> or references a buffer that is not large enough, a
		/// <c>NULL</c> pointer will be returned, no data will be copied, and segmentCount will contain the required buffer size, which
		/// is specified as the number of elements.
		/// </para>
		/// </param>
		/// <remarks>For an example of how to use this method in a program, see the code example in GetSegmentData.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getsegmenttypes
		// HRESULT GetSegmentTypes( UINT32 *segmentCount, XPS_SEGMENT_TYPE *segmentTypes );
		void GetSegmentTypes([In, Out] ref uint segmentCount, [In, Out] XPS_SEGMENT_TYPE[] segmentTypes);

		/// <summary>Gets stroke definitions for the figure's segments.</summary>
		/// <param name="segmentCount">
		/// <para>The size of the array that is referenced by segmentStrokes. This parameter must not be <c>NULL</c>.</para>
		/// <para>
		/// If the method returns successfully, segmentCount will contain the number of elements that are returned in the array
		/// referenced by segmentStrokes.
		/// </para>
		/// <para>If segmentStrokes is <c>NULL</c> when the method is called, segmentCount must be set to zero.</para>
		/// <para>
		/// If a <c>NULL</c> pointer is returned in segmentStrokes, the value of segmentCount will contain the required buffer size,
		/// specified as the number of elements.
		/// </para>
		/// </param>
		/// <param name="segmentStrokes">
		/// <para>
		/// An array that has the same number of elements as specified in segmentCount. If the caller requires that this method return
		/// only the required buffer size, set this value to <c>NULL</c>.
		/// </para>
		/// <para>
		/// If the array is large enough, this method copies the segment stroke values into the array and returns, in segmentCount, the
		/// number of copied segment stroke values. If segmentData is <c>NULL</c> or references a buffer that is not large enough, a
		/// <c>NULL</c> pointer will be returned, no data will be copied, and segmentCount will contain the required buffer size that is
		/// specified as the number of elements.
		/// </para>
		/// <para>The following table shows the possible values of an element in the array that is referenced by segmentStrokes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The segment is stroked.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The segment is not stroked.</term>
		/// </item>
		/// </list>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getsegmentstrokes
		// HRESULT GetSegmentStrokes( UINT32 *segmentCount, BOOL *segmentStrokes );
		void GetSegmentStrokes([In, Out] ref uint segmentCount, [In, Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Bool)] bool[] segmentStrokes);

		/// <summary>Sets the segment information and data points for segments in the figure.</summary>
		/// <param name="segmentCount">
		/// <para>The number of segments.</para>
		/// <para>This value is also the number of elements in the arrays that are referenced by segmentTypes and segmentStrokes.</para>
		/// </param>
		/// <param name="segmentDataCount">
		/// <para>The number of segment data points.</para>
		/// <para>This value is also the number of elements in the array that is referenced by segmentData.</para>
		/// </param>
		/// <param name="segmentTypes">
		/// An array of XPS_SEGMENT_TYPE variables. The value of segmentCount specifies the number of elements in this array.
		/// </param>
		/// <param name="segmentData">
		/// An array of segment data values. The value of segmentDataCount specifies the number of elements in this array.
		/// </param>
		/// <param name="segmentStrokes">
		/// An array of segment stroke values. The value of segmentCount specifies the number of elements in this array.
		/// </param>
		/// <remarks>
		/// <para>
		/// A geometry segment is described by the start point, the segment type, and additional parameters whose values are determined
		/// by the segment type. The coordinates for the start point of the first segment are a property of the geometry figure and are
		/// set by calling SetStartPoint. The start point of each subsequent segment is the end point of the preceding segment.
		/// </para>
		/// <para>
		/// The number of data values that define a line segment depends on the segment type. The table that follows describes the
		/// specific set of required data values that must be used for each segment type. The values in the segment data array that is
		/// passed in the segmentData parameter must correspond with the XPS_SEGMENT_TYPE values in the array that is passed in the
		/// segmentTypes parameter. For example, if the first line segment has a segment type value of <c>XPS_SEGMENT_TYPE_LINE</c>, the
		/// first two data values in the segmentData array will be the x and y coordinates of the end point of that segment; if the next
		/// segment has a segment type value of <c>XPS_SEGMENT_TYPE_BEZIER</c>, the next six values in the segmentData array will
		/// describe the characteristics of that segment; and so on for each line segment in the geometry figure.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Segment type</term>
		/// <term>Required data values</term>
		/// </listheader>
		/// <item>
		/// <term>XPS_SEGMENT_TYPE_LINE</term>
		/// <term>Two data values: x-coordinate of the segment line's end point. y-coordinate of the segment line's end point.</term>
		/// </item>
		/// <item>
		/// <term>XPS_SEGMENT_TYPE_ARC_LARGE_CLOCKWISE</term>
		/// <term>
		/// Five data values: x-coordinate of the arc's end point. y-coordinate of the arc's end point. Length of the ellipse's radius
		/// along the x-axis. Length of the ellipse's radius along the y-axis. Rotation angle.
		/// </term>
		/// </item>
		/// <item>
		/// <term>XPS_SEGMENT_TYPE_ARC_SMALL_CLOCKWISE</term>
		/// <term>
		/// Five data values: x-coordinate of the arc's end point. y-coordinate of the arc's end point. Length of the ellipse's radius
		/// along the x-axis. Length of the ellipse's radius along the y-axis. Rotation angle.
		/// </term>
		/// </item>
		/// <item>
		/// <term>XPS_SEGMENT_TYPE_ARC_LARGE_COUNTERCLOCKWISE</term>
		/// <term>
		/// Five data values: x-coordinate of the arc's end point. y-coordinate of the arc's end point. Length of the ellipse's radius
		/// along the x-axis. Length of the ellipse's radius along the y-axis. Rotation angle.
		/// </term>
		/// </item>
		/// <item>
		/// <term>XPS_SEGMENT_TYPE_ARC_SMALL_COUNTERCLOCKWISE</term>
		/// <term>
		/// Five data values: x-coordinate of the arc's end point. y-coordinate of the arc's end point. Length of the ellipse's radius
		/// along the x-axis. Length of the ellipse's radius along the y-axis. Rotation angle.
		/// </term>
		/// </item>
		/// <item>
		/// <term>XPS_SEGMENT_TYPE_BEZIER</term>
		/// <term>
		/// Six data values: x-coordinate of the Bezier curve's first control point. y-coordinate of the Bezier curve's first control
		/// point. x-coordinate of the Bezier curve's second control point. y-coordinate of the Bezier curve's second control point.
		/// x-coordinate of the Bezier curve's end point. y-coordinate of the Bezier curve's end point.
		/// </term>
		/// </item>
		/// <item>
		/// <term>XPS_SEGMENT_TYPE_QUADRATIC_BEZIER</term>
		/// <term>
		/// Four data values: x-coordinate of the Quad Bezier curve's control point. y-coordinate of the Quad Bezier curve's control
		/// point. x-coordinate of the Quad Bezier curve's end point. y-coordinate of the Quad Bezier curve's end point.
		/// </term>
		/// </item>
		/// </list>
		/// <para>To get the segment types in the figure, call GetSegmentTypes.</para>
		/// <para>The following code examples demonstrate one way to create and populate the buffers required by <c>SetSegments</c>.</para>
		/// <para>
		/// In the first code example, the <c>AddSegmentDataToArrays</c> method takes the data points that describe a single segment and
		/// stores them in the three different data buffers required by the <c>SetSegments</c> method. The data buffers that are passed
		/// as arguments to <c>AddSegmentDataToArrays</c> are managed by the calling method as shown in the code example that follows <c>AddSegmentDataToArrays</c>.
		/// </para>
		/// <para>
		/// In this code example, <c>UpdateSegmentData</c> creates the data buffers required by the <c>SetSegments</c> method and calls
		/// the <c>AddSegmentDataToArrays</c> method from the preceding code example to populate them with the segment data. After the
		/// buffers have been populated, <c>SetSegments</c> is called to add this data to the geometry figure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-setsegments HRESULT
		// SetSegments( UINT32 segmentCount, UINT32 segmentDataCount, const XPS_SEGMENT_TYPE *segmentTypes, const FLOAT *segmentData,
		// const BOOL *segmentStrokes );
		void SetSegments([In] uint segmentCount, [In] uint segmentDataCount, [In] XPS_SEGMENT_TYPE[] segmentTypes, [In] float[] segmentData, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Bool)] bool[] segmentStrokes);

		/// <summary>Gets the starting point of the figure.</summary>
		/// <returns>The coordinates of the starting point of the figure.</returns>
		/// <remarks>
		/// In the document markup, the value returned in startPoint corresponds to that of the <c>StartPoint</c> attribute of the
		/// <c>PathFigure</c> element.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getstartpoint
		// HRESULT GetStartPoint( XPS_POINT *startPoint );
		XPS_POINT GetStartPoint();

		/// <summary>Sets the starting point of the figure.</summary>
		/// <param name="startPoint">The coordinates of the starting point of the figure.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-setstartpoint
		// HRESULT SetStartPoint( const XPS_POINT *startPoint );
		void SetStartPoint(in XPS_POINT startPoint);

		/// <summary>Gets a value that indicates whether the figure is closed.</summary>
		/// <returns>
		/// <para>The Boolean value that indicates whether the figure is closed.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>
		/// The figure is closed. The line segment between the start and end points of the figure will be stroked to close the shape.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The figure is open. No line segment will be stroked between the start and end points of the figure.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>This value only applies if the <c>PathFigure</c> attribute is used in the <c>Path</c> element that specifies a stroke.</para>
		/// <para>A closed figure adds a line segment between the start point and the end point of the figure to close the shape.</para>
		/// <para>This value corresponds to that of the <c>IsClosed</c> element of the <c>PathFigure</c> element in the document markup.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getisclosed HRESULT
		// GetIsClosed( BOOL *isClosed );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetIsClosed();

		/// <summary>Sets a value that indicates whether the figure is closed.</summary>
		/// <param name="isClosed">
		/// <para>The value to be set.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The figure is closed. A line segment between the start point and the last point defined in the figure will be stroked.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The figure is open. There is no line segment between the start point and the last point defined in the figure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>This value only applies if the <c>PathFigure</c> attribute is used in the <c>Path</c> element that specifies a stroke.</para>
		/// <para>A closed figure adds a line segment between the start point and the end point of the figure to close the shape.</para>
		/// <para>This value corresponds to that of the <c>IsClosed</c> element of the <c>PathFigure</c> element in the document markup.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-setisclosed HRESULT
		// SetIsClosed( BOOL isClosed );
		void SetIsClosed([In, MarshalAs(UnmanagedType.Bool)] bool isClosed);

		/// <summary>Gets a value that indicates whether the figure is filled.</summary>
		/// <returns>
		/// <para>The Boolean value that indicates whether the figure is filled.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The figure is filled by a brush.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The figure is not filled.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This value corresponds to that of the <c>IsFilled</c> attribute of the <c>PathFigure</c> element in the document markup.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getisfilled HRESULT
		// GetIsFilled( BOOL *isFilled );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetIsFilled();

		/// <summary>Sets a value that indicates whether the figure is filled.</summary>
		/// <param name="isFilled">
		/// <para>The value to be set.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The figure is filled by a brush.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The figure is not filled.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// In the document markup, the value returned in isFilled corresponds to that of the <c>IsFilled</c> attribute of the
		/// <c>PathFigure</c> element.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-setisfilled HRESULT
		// SetIsFilled( BOOL isFilled );
		void SetIsFilled([In, MarshalAs(UnmanagedType.Bool)] bool isFilled);

		/// <summary>Gets the number of segments in the figure.</summary>
		/// <returns>The number of segments in the figure.</returns>
		/// <remarks>For an example of how to use this method in a program, see the code example in GetSegmentData.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getsegmentcount
		// HRESULT GetSegmentCount( UINT32 *segmentCount );
		uint GetSegmentCount();

		/// <summary>Gets the number of segment data points in the figure.</summary>
		/// <returns>The number of segment data points. segmentDataCount must not be <c>NULL</c> when the method is called.</returns>
		/// <remarks>
		/// <para>To get the segment data points, call GetSegmentData.</para>
		/// <para>For an example of how to use this method in a program, see the code example in GetSegmentData.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getsegmentdatacount
		// HRESULT GetSegmentDataCount( UINT32 *segmentDataCount );
		uint GetSegmentDataCount();

		/// <summary>Gets the XPS_SEGMENT_STROKE_PATTERN value that indicates whether the segments in the figure are stroked.</summary>
		/// <returns>The XPS_SEGMENT_STROKE_PATTERN value that indicates whether the segments in the figure are stroked.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getsegmentstrokepattern
		// HRESULT GetSegmentStrokePattern( XPS_SEGMENT_STROKE_PATTERN *segmentStrokePattern );
		XPS_SEGMENT_STROKE_PATTERN GetSegmentStrokePattern();

		/// <summary>Makes a deep copy of the interface.</summary>
		/// <returns>A pointer to the copy of the interface.</returns>
		/// <remarks>The owner of the copy is <c>NULL</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-clone HRESULT Clone(
		// IXpsOMGeometryFigure **geometryFigure );
		IXpsOMGeometryFigure Clone();
	}

	/// <summary>A collection of IXpsOMGeometryFigure interface pointers.</summary>
	/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomgeometryfigurecollection
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "24ed79ff-9160-4e9b-b322-c538b30f113b")]
	[ComImport, Guid("FD48C3F3-A58E-4B5A-8826-1DE54ABE72B2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMGeometryFigureCollection
	{
		/// <summary>Gets the number of IXpsOMGeometryFigure interface pointers in the collection.</summary>
		/// <returns>The number of IXpsOMGeometryFigure interface pointers in the collection.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigurecollection-getcount
		// HRESULT GetCount( UINT32 *count );
		uint GetCount();

		/// <summary>Gets an IXpsOMGeometryFigure interface pointer from a specified location in the collection.</summary>
		/// <param name="index">The zero-based index of the IXpsOMGeometryFigure interface pointer to be obtained.</param>
		/// <returns>The IXpsOMGeometryFigure interface pointer at the location specified by index.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigurecollection-getat
		// HRESULT GetAt( UINT32 index, IXpsOMGeometryFigure **geometryFigure );
		IXpsOMGeometryFigure GetAt([In] uint index);

		/// <summary>Inserts an IXpsOMGeometryFigure interface pointer at a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection where the interface pointer that is passed in geometryFigure is to be inserted.
		/// </param>
		/// <param name="geometryFigure">
		/// The IXpsOMGeometryFigure interface pointer that is to be inserted at the location specified by index.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method inserts the IXpsOMGeometryFigure interface pointer that is passed in
		/// geometryFigure. Prior to the insertion, the pointer in this and all subsequent locations is moved up by one index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigurecollection-insertat
		// HRESULT InsertAt( UINT32 index, IXpsOMGeometryFigure *geometryFigure );
		void InsertAt([In] uint index, [In] IXpsOMGeometryFigure geometryFigure);

		/// <summary>Removes and releases an IXpsOMGeometryFigure interface pointer from a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection from which an IXpsOMGeometryFigure interface pointer is to be removed and released.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method releases the interface referenced by the pointer at the location specified by index. After releasing the
		/// interface, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigurecollection-removeat
		// HRESULT RemoveAt( UINT32 index );
		void RemoveAt([In] uint index);

		/// <summary>Replaces an IXpsOMGeometryFigure interface pointer at a specified location in the collection.</summary>
		/// <param name="index">The zero-based index in the collection where an IXpsOMGeometryFigure interface pointer is to be replaced.</param>
		/// <param name="geometryFigure">
		/// The IXpsOMGeometryFigure interface pointer that will replace current contents at the location specified by index.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method releases the IXpsOMGeometryFigure interface referenced by the existing
		/// pointer, then writes the pointer that is passed in geometryFigure.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigurecollection-setat
		// HRESULT SetAt( UINT32 index, IXpsOMGeometryFigure *geometryFigure );
		void SetAt([In] uint index, [In] IXpsOMGeometryFigure geometryFigure);

		/// <summary>Appends an IXpsOMGeometryFigure interface to the end of the collection.</summary>
		/// <param name="geometryFigure">A pointer to the IXpsOMGeometryFigure interface that is to be appended to the collection.</param>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigurecollection-append
		// HRESULT Append( IXpsOMGeometryFigure *geometryFigure );
		void Append([In] IXpsOMGeometryFigure geometryFigure);
	}

	/// <summary>
	/// <para>Describes the text that appears on a page.</para>
	/// <para>The IXpsOMGlyphsEditor interface is used to modify the text that is described by this interface.</para>
	/// </summary>
	/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomglyphs
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "6d2cda65-c719-46f2-97c9-8aee7b5f84b9")]
	[ComImport, Guid("819B3199-0A5A-4B64-BEC7-A9E17E780DE2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMGlyphs : IXpsOMVisual
	{
		/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
		/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner HRESULT
		// GetOwner( IUnknown **owner );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		new object GetOwner();

		/// <summary>Gets the object type of the interface.</summary>
		/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype HRESULT GetType(
		// XPS_OBJECT_TYPE *type );
		new XPS_OBJECT_TYPE GetType();

		/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the visual's resolved matrix transform.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMMatrixTransform interface that contains the visual's resolved matrix transform. If a matrix transform
		/// has not been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the transform.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in matrixTransform</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>
		/// The shared transform that gets retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the
		/// resource directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransform HRESULT
		// GetTransform( IXpsOMMatrixTransform **matrixTransform );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IXpsOMMatrixTransform GetTransform();

		/// <summary>
		/// Gets a pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the visual.
		/// </summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the
		/// visual. If a matrix transform lookup key has not been set, or if a local matrix transform has been set, a <c>NULL</c>
		/// pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in matrixTransform</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransformlocal HRESULT
		// GetTransformLocal( IXpsOMMatrixTransform **matrixTransform );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IXpsOMMatrixTransform GetTransformLocal();

		/// <summary>Sets the local, unshared matrix transform.</summary>
		/// <param name="matrixTransform">
		/// A pointer to the IXpsOMMatrixTransform interface to be set as the local, unshared matrix transform. A <c>NULL</c> pointer
		/// releases the previously assigned transform.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetTransformLocal</c>, the transform lookup key is released and GetTransformLookup returns a <c>NULL</c>
		/// pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in transform by GetTransform</term>
		/// <term>Object that is returned in matrixTransform by GetTransformLocal</term>
		/// <term>Object that is returned in key by GetTransformLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal (this method)</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// <term>The local transform set by SetTransformLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>
		/// The shared transform that gets retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the
		/// resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetTransformLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-settransformlocal HRESULT
		// SetTransformLocal( IXpsOMMatrixTransform *matrixTransform );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetTransformLocal([In] IXpsOMMatrixTransform matrixTransform);

		/// <summary>
		/// Gets the lookup key name of the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix
		/// transform for the visual.
		/// </summary>
		/// <returns>
		/// <para>
		/// The lookup key name for the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix
		/// transform for the visual. If a matrix transform lookup key has not been set, or if a local matrix transform has been set, a
		/// <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in key</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>The lookup key that is set by SetTransformLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransformlookup HRESULT
		// GetTransformLookup( LPWSTR *key );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		new string GetTransformLookup();

		/// <summary>Sets the lookup key name of a shared matrix transform in a resource dictionary.</summary>
		/// <param name="key">The lookup key name of the matrix transform in the dictionary.</param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetTransformLookup</c>, the local transform is released and GetTransformLocal returns a <c>NULL</c>
		/// pointer in the matrixTransform parameter. The table that follows explains the relationship between the local and lookup
		/// values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in transform by GetTransform</term>
		/// <term>Object that is returned in matrixTransform by GetTransformLocal</term>
		/// <term>Object that is returned in key by GetTransformLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup (this method)</term>
		/// <term>
		/// The shared transform that gets retrieved—with a lookup key that matches the key that is set by SetTransformLookup—from the
		/// resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetTransformLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-settransformlookup HRESULT
		// SetTransformLookup( LPCWSTR key );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

		/// <summary>
		/// Gets a pointer to the IXpsOMGeometry interface that contains the resolved geometry of the visual's clipping region.
		/// </summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMGeometry interface that contains the resolved geometry of the visual's clipping region. If the clip
		/// geometry has not been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the geometry.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in clipGeometry</term>
		/// </listheader>
		/// <item>
		/// <term>SetClipGeometryLocal</term>
		/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetClipGeometryLookup</term>
		/// <term>
		/// The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup,
		/// from the resource directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometry HRESULT
		// GetClipGeometry( IXpsOMGeometry **clipGeometry );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IXpsOMGeometry GetClipGeometry();

		/// <summary>
		/// Gets a pointer to the IXpsOMGeometry interface that contains the local, unshared geometry of the visual's clipping region.
		/// </summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMGeometry interface that contains the local, unshared geometry of the visual's clipping region. If a
		/// clip geometry lookup key has been set, or if a local clip geometry has not been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in clipGeometry</term>
		/// </listheader>
		/// <item>
		/// <term>SetClipGeometryLocal</term>
		/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetClipGeometryLookup</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometrylocal HRESULT
		// GetClipGeometryLocal( IXpsOMGeometry **clipGeometry );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IXpsOMGeometry GetClipGeometryLocal();

		/// <summary>Sets the local, unshared clipping region for the visual.</summary>
		/// <param name="clipGeometry">
		/// A pointer to the IXpsOMGeometry interface to be set as the local, unshared clipping region for the visual. A <c>NULL</c>
		/// pointer releases the previously assigned geometry interface.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetClipGeometryLocal</c>, the clip geometry lookup key is released and GetClipGeometryLookup returns a
		/// <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup
		/// values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in clipGeometry by GetClipGeometry</term>
		/// <term>Object that is returned in clipGeometry by GetClipGeometryLocal</term>
		/// <term>String that is returned in key by GetClipGeometryLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetClipGeometryLocal (this method)</term>
		/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
		/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetClipGeometryLookup</term>
		/// <term>
		/// The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup,
		/// from the resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetClipGeometryLookup nor SetClipGeometryLocal has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setclipgeometrylocal HRESULT
		// SetClipGeometryLocal( IXpsOMGeometry *clipGeometry );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetClipGeometryLocal([In] IXpsOMGeometry clipGeometry);

		/// <summary>
		/// Gets the lookup key for the IXpsOMGeometry interface in a resource dictionary that contains the visual's clipping region.
		/// </summary>
		/// <returns>
		/// <para>
		/// The lookup key for the IXpsOMGeometry interface in a resource dictionary that contains the visual's clipping region. If a
		/// lookup key for the clip geometry has not been set, or if a local clip geometry has been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Lookup key string that is returned in key</term>
		/// </listheader>
		/// <item>
		/// <term>SetClipGeometryLocal</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetClipGeometryLookup</term>
		/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometrylookup
		// HRESULT GetClipGeometryLookup( LPWSTR *key );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		new string GetClipGeometryLookup();

		/// <summary>Sets the lookup key name of a shared clip geometry in a resource dictionary.</summary>
		/// <param name="key">
		/// The lookup key name of the clip geometry in the dictionary. A <c>NULL</c> pointer clears the previously assigned key name.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetClipGeometryLookup</c>, the local clip geometry is released and GetClipGeometryLocal returns a
		/// <c>NULL</c> pointer in the clipGeometry parameter. The table that follows explains the relationship between the local and
		/// lookup values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in clipGeometry by GetClipGeometry</term>
		/// <term>Object that is returned in clipGeometry by GetClipGeometryLocal</term>
		/// <term>String that is returned in key by GetClipGeometryLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetClipGeometryLocal</term>
		/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
		/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetClipGeometryLookup (this method)</term>
		/// <term>
		/// The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup,
		/// from the resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetClipGeometryLookup nor SetClipGeometryLocal has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setclipgeometrylookup
		// HRESULT SetClipGeometryLookup( LPCWSTR key );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetClipGeometryLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

		/// <summary>Gets the opacity value of this visual.</summary>
		/// <returns>The opacity value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacity HRESULT
		// GetOpacity( FLOAT *opacity );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new float GetOpacity();

		/// <summary>Sets the opacity value of the visual.</summary>
		/// <param name="opacity">
		/// <para>The opacity value to be set for the visual.</para>
		/// <para>
		/// The range of allowed values for this parameter is 0.0 to 1.0; with 0.0 the visual is completely transparent, and with 1.0 it
		/// is completely opaque.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacity HRESULT
		// SetOpacity( FLOAT opacity );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetOpacity([In] float opacity);

		/// <summary>Gets a pointer to the IXpsOMBrush interface of the visual's opacity mask brush.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMBrush interface of the visual's opacity mask brush. If an opacity mask brush has not been set for
		/// this visual, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the brush.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in opacityMaskBrush</term>
		/// </listheader>
		/// <item>
		/// <term>SetOpacityMaskBrushLocal</term>
		/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetOpacityMaskBrushLookup</term>
		/// <term>
		/// The shared opacity mask brush that gets retrieved, with a lookup key that matches the key that is set by
		/// SetOpacityMaskBrushLookup, from the resource directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrush HRESULT
		// GetOpacityMaskBrush( IXpsOMBrush **opacityMaskBrush );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IXpsOMBrush GetOpacityMaskBrush();

		/// <summary>Gets the local, unshared opacity mask brush for the visual.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMBrush interface of the visual's opacity mask brush. If an opacity mask brush lookup key has been set,
		/// or if a local opacity mask brush has not been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in opacityMaskBrush</term>
		/// </listheader>
		/// <item>
		/// <term>SetOpacityMaskBrushLocal</term>
		/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetOpacityMaskBrushLookup</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrushlocal
		// HRESULT GetOpacityMaskBrushLocal( IXpsOMBrush **opacityMaskBrush );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IXpsOMBrush GetOpacityMaskBrushLocal();

		/// <summary>Sets the IXpsOMBrush interface pointer as the local, unshared opacity mask brush.</summary>
		/// <param name="opacityMaskBrush">
		/// A pointer to the IXpsOMBrush interface to be set as the local, unshared opacity mask brush. A <c>NULL</c> pointer clears the
		/// previously assigned opacity mask brush.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetOpacityMaskBrushLocal</c>, the opacity mask brush lookup key is released and GetOpacityMaskBrushLookup
		/// returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and
		/// lookup values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrush</term>
		/// <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrushLocal</term>
		/// <term>String that is returned in key by GetOpacityMaskBrushLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetOpacityMaskBrushLocal (this method)</term>
		/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
		/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetOpacityMaskBrushLookup</term>
		/// <term>
		/// The shared opacity mask brush that gets retrieved, with a lookup key that matches the key that is set by
		/// SetOpacityMaskBrushLookup, from the resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacitymaskbrushlocal
		// HRESULT SetOpacityMaskBrushLocal( IXpsOMBrush *opacityMaskBrush );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetOpacityMaskBrushLocal([In] IXpsOMBrush opacityMaskBrush);

		/// <summary>Gets the name of the lookup key of the shared opacity mask brush in a resource dictionary.</summary>
		/// <returns>
		/// <para>
		/// The name of the lookup key of the shared opacity mask brush in a resource dictionary. If the lookup key of an opacity mask
		/// brush has not been set, or if a local opacity mask brush has been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in key</term>
		/// </listheader>
		/// <item>
		/// <term>SetOpacityMaskBrushLocal</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetOpacityMaskBrushLookup</term>
		/// <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrushlookup
		// HRESULT GetOpacityMaskBrushLookup( LPWSTR *key );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		new string GetOpacityMaskBrushLookup();

		/// <summary>Sets the lookup key name of a shared opacity mask brush in a resource dictionary.</summary>
		/// <param name="key">
		/// The lookup key name of the opacity mask brush in the dictionary. A <c>NULL</c> pointer clears the previously assigned key name.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetOpacityMaskBrushLookup</c>, the local opacity mask brush is released and GetOpacityMaskBrushLocal
		/// returns a <c>NULL</c> pointer in the opacityMaskBrush parameter. The table that follows explains the relationship between
		/// the local and lookup values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrush</term>
		/// <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrushLocal</term>
		/// <term>String that is returned in key by GetOpacityMaskBrushLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetOpacityMaskBrushLocal</term>
		/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
		/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetOpacityMaskBrushLookup (this method)</term>
		/// <term>
		/// The shared opacity mask brush that gets retrieved—with a lookup key that matches the key that is set by
		/// SetOpacityMaskBrushLookup—from the resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacitymaskbrushlookup
		// HRESULT SetOpacityMaskBrushLookup( LPCWSTR key );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetOpacityMaskBrushLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

		/// <summary>Gets the <c>Name</c> property of the visual.</summary>
		/// <returns>The <c>Name</c> property string. If the <c>Name</c> property has not been set, a <c>NULL</c> pointer is returned.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getname HRESULT GetName(
		// LPWSTR *name );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		new string GetName();

		/// <summary>Sets the <c>Name</c> property of the visual.</summary>
		/// <param name="name">The name of the visual. A <c>NULL</c> pointer clears the <c>Name</c> property.</param>
		/// <remarks>
		/// <para>Names must be unique.</para>
		/// <para>
		/// Clearing the <c>Name</c> property by passing a <c>NULL</c> pointer in name sets the <c>IsHyperlinkTarget</c> property to <c>FALSE</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setname HRESULT SetName(
		// LPCWSTR name );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetName([In, MarshalAs(UnmanagedType.LPWStr)] string name);

		/// <summary>Gets a value that indicates whether the visual is the target of a hyperlink.</summary>
		/// <returns>
		/// <para>The Boolean value that indicates whether the visual is the target of a hyperlink.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The visual is the target of a hyperlink.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The visual is not the target of a hyperlink.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getishyperlinktarget HRESULT
		// GetIsHyperlinkTarget( BOOL *isHyperlink );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool GetIsHyperlinkTarget();

		/// <summary>Specifies whether the visual is the target of a hyperlink.</summary>
		/// <param name="isHyperlink">
		/// <para>The Boolean value that specifies whether the visual is the target of a hyperlink.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The visual is the target of a hyperlink.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The visual is not the target of a hyperlink.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>The visual must be named before it can be set as the target of a hyperlink.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setishyperlinktarget HRESULT
		// SetIsHyperlinkTarget( BOOL isHyperlink );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetIsHyperlinkTarget([In, MarshalAs(UnmanagedType.Bool)] bool isHyperlink);

		/// <summary>Gets a pointer to the IUri interface to which this visual object links.</summary>
		/// <returns>
		/// A pointer to the IUri interface that contains the destination URI for the link. If a URI has not been set for this object, a
		/// <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gethyperlinknavigateuri
		// HRESULT GetHyperlinkNavigateUri( IUri **hyperlinkUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IUri GetHyperlinkNavigateUri();

		/// <summary>Sets the destination URI of the visual's hyperlink.</summary>
		/// <param name="hyperlinkUri">The IUri interface that contains the destination URI of the visual's hyperlink.</param>
		/// <remarks>
		/// Setting an object's URI makes the object a hyperlink. When activated or clicked, the object will navigate to the destination
		/// that is specified by the URI in hyperlinkUri.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-sethyperlinknavigateuri
		// HRESULT SetHyperlinkNavigateUri( IUri *hyperlinkUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetHyperlinkNavigateUri([In] IUri hyperlinkUri);

		/// <summary>Gets the <c>Language</c> property of the visual and of its contents.</summary>
		/// <returns>
		/// The language string that specifies the language of the page. If a language has not been set, a <c>NULL</c> pointer is returned.
		/// </returns>
		/// <remarks>
		/// <para>The <c>Language</c> property that is set by this method specifies the language of the resource content.</para>
		/// <para>Internet Engineering Task Force (IETF) RFC 3066 specifies the recommended encoding for the <c>Language</c> property.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getlanguage HRESULT
		// GetLanguage( LPWSTR *language );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		new string GetLanguage();

		/// <summary>Sets the <c>Language</c> property of the visual.</summary>
		/// <param name="language">
		/// The language string that specifies the language of the visual and of its contents. A <c>NULL</c> pointer clears the
		/// <c>Language</c> property.
		/// </param>
		/// <remarks>
		/// The recommended encoding for the <c>Language</c> property is specified in Internet Engineering Task Force (IETF) RFC 3066r.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setlanguage HRESULT
		// SetLanguage( LPCWSTR language );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetLanguage([In, MarshalAs(UnmanagedType.LPWStr)] string language);

		/// <summary>Gets the text in unescaped UTF-16 scalar values.</summary>
		/// <returns>The UTF-16 Unicode string of the text to be displayed. If the string is empty, a <c>NULL</c> pointer is returned.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getunicodestring HRESULT
		// GetUnicodeString( LPWSTR *unicodeString );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetUnicodeString();

		/// <summary>Gets the number of Glyph indices.</summary>
		/// <returns>The number of glyph indices.</returns>
		/// <remarks>GetGlyphIndices gets the glyph indices.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getglyphindexcount HRESULT
		// GetGlyphIndexCount( UINT32 *indexCount );
		uint GetGlyphIndexCount();

		/// <summary>Gets an array of XPS_GLYPH_INDEX structures that describe the specific glyph indices in the font.</summary>
		/// <param name="indexCount">
		/// The number of XPS_GLYPH_INDEX structures that will fit in the array that is referenced by glyphIndices. When the method
		/// returns, indexCount will contain the number of <c>XPS_GLYPH_INDEX</c> structures that are returned in the array referenced
		/// by glyphIndices.
		/// </param>
		/// <param name="glyphIndices">The address of an array of XPS_GLYPH_INDEX structures that receive the glyph indices.</param>
		/// <remarks>
		/// <para>GetGlyphIndexCount gets the number of elements in the glyph index array.</para>
		/// <para>
		/// The glyph indices override the default <c>cmap</c> mapping from the <c>UnicodeString</c> to the glyph index. The
		/// XPS_GLYPH_INDEX structure also contains advance width as well as vertical and horizontal offset information.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getglyphindices HRESULT
		// GetGlyphIndices( UINT32 *indexCount, XPS_GLYPH_INDEX *glyphIndices );
		void GetGlyphIndices(ref uint indexCount, [In, Out] XPS_GLYPH_INDEX[] glyphIndices);

		/// <summary>Gets the number of glyph mappings.</summary>
		/// <returns>The number of glyph mappings.</returns>
		/// <remarks>GetGlyphMappings gets the glyph mappings.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getglyphmappingcount HRESULT
		// GetGlyphMappingCount( UINT32 *glyphMappingCount );
		uint GetGlyphMappingCount();

		/// <summary>
		/// Gets an array of XPS_GLYPH_MAPPING structures that describe how to map UTF-16 scalar values to entries in the array of
		/// XPS_GLYPH_INDEX structures, which is returned by GetGlyphIndices.
		/// </summary>
		/// <param name="glyphMappingCount">
		/// The number of XPS_GLYPH_MAPPING structures that will fit in the array referenced by glyphMappings. When the method returns,
		/// glyphMappingCount contains the number of values returned in the array referenced by glyphMappings.
		/// </param>
		/// <param name="glyphMappings">An array of XPS_GLYPH_MAPPING structures that contain the glyph mapping values.</param>
		/// <remarks>GetGlyphMappingCount gets the number of glyph mappings.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getglyphmappings HRESULT
		// GetGlyphMappings( UINT32 *glyphMappingCount, XPS_GLYPH_MAPPING *glyphMappings );
		void GetGlyphMappings(ref uint glyphMappingCount, [In, Out] XPS_GLYPH_MAPPING[] glyphMappings);

		/// <summary>Gets the number of prohibited caret stops.</summary>
		/// <returns>The number of prohibited caret stops.</returns>
		/// <remarks>
		/// <para>GetProhibitedCaretStops gets the prohibited caret stops.</para>
		/// <para>
		/// Each caret stop index corresponds to the scalar values of a UTF-16 <c>UnicodeString</c> property. Index 0 represents the
		/// location just before the first UTF-16 scalar value of <c>UnicodeString</c>; index 1 represents the location between the
		/// first and second UTF-16 scalar values, and so on. There is an additional index at the end of <c>UnicodeString</c>. Any
		/// unspecified index is a valid caret stop location.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getprohibitedcaretstopcount
		// HRESULT GetProhibitedCaretStopCount( UINT32 *prohibitedCaretStopCount );
		uint GetProhibitedCaretStopCount();

		/// <summary>Gets an array of prohibited caret stop locations.</summary>
		/// <param name="prohibitedCaretStopCount">
		/// The number of prohibited caret stop locations that will fit in the array referenced by prohibitedCaretStops. When the method
		/// returns, prohibitedCaretStopCount will contain the number of values returned in the array referenced by prohibitedCaretStops.
		/// </param>
		/// <param name="prohibitedCaretStops">
		/// An array of prohibited caret stop locations; if such are not defined, a <c>NULL</c> pointer is returned.
		/// </param>
		/// <remarks>
		/// <para>
		/// Each caret stop index corresponds to the scalar values of a UTF-16 <c>UnicodeString</c> property. Index 0 represents the
		/// location just before the first UTF-16 scalar value of <c>UnicodeString</c>; index 1 represents the location between the
		/// first and second UTF-16 scalar values, and so on. There is an additional index at the end of <c>UnicodeString</c>. Any
		/// unspecified index is a valid caret stop location.
		/// </para>
		/// <para>GetProhibitedCaretStopCount gets the number of prohibited caret stops.</para>
		/// <para>A caret stop is the index of the UTF-16 code point in the <c>UnicodeString</c> property of the glyph.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getprohibitedcaretstops
		// HRESULT GetProhibitedCaretStops( UINT32 *prohibitedCaretStopCount, UINT32 *prohibitedCaretStops );
		void GetProhibitedCaretStops(ref uint prohibitedCaretStopCount, [In, Out] uint[] prohibitedCaretStops);

		/// <summary>Gets the level of bidirectional text.</summary>
		/// <returns>
		/// <para>The level of bidirectional text.</para>
		/// <para>Range: 0–61</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The bidirectional text level, or <c>BidiLevel</c>, specifies the nesting level of the Unicode bidirectional algorithm. Even
		/// values imply the left-to-right layout and odd values the right-to-left layout, which places the run origin on the right side
		/// of the first glyph. Advance widths that are positive will move to the left, allowing subsequent glyphs to be placed to the
		/// left of the previous glyph.
		/// </para>
		/// <para>The range of allowed values for this property is between 0 and 61, inclusive, and the default value is 0.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getbidilevel HRESULT
		// GetBidiLevel( UINT32 *bidiLevel );
		uint GetBidiLevel();

		/// <summary>Gets a Boolean value that indicates whether the text is to be rendered with the glyphs rotated sideways.</summary>
		/// <returns>
		/// <para>The Boolean value that indicates whether the text is to be rendered with the glyphs rotated sideways.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>Render the glyphs sideways to produce sideways text.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>Do not render the glyphs sideways to produce normal text.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>The default value for this property is <c>FALSE</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getissideways HRESULT
		// GetIsSideways( BOOL *isSideways );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetIsSideways();

		/// <summary>Gets the name of the device font.</summary>
		/// <returns>
		/// The string that contains the unescaped name of the device font. If the name has not been set, a <c>NULL</c> pointer will be returned.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The device font name uniquely identifies a specific device font and is typically defined by a hardware vendor or font vendor.
		/// </para>
		/// <para>The escaped version of the device font name is created when the object is serialized.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getdevicefontname HRESULT
		// GetDeviceFontName( LPWSTR *deviceFontName );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetDeviceFontName();

		/// <summary>Gets the style simulations that will be applied when rendering the glyphs.</summary>
		/// <returns>The XPS_STYLE_SIMULATION value that describes the style simulations to be applied.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getstylesimulations HRESULT
		// GetStyleSimulations( XPS_STYLE_SIMULATION *styleSimulations );
		XPS_STYLE_SIMULATION GetStyleSimulations();

		/// <summary>Sets the style simulations that will be applied when the glyphs are rendered.</summary>
		/// <param name="styleSimulations">The XPS_STYLE_SIMULATION value that specifies the style simulation to be applied.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-setstylesimulations HRESULT
		// SetStyleSimulations( XPS_STYLE_SIMULATION styleSimulations );
		void SetStyleSimulations([In] XPS_STYLE_SIMULATION styleSimulations);

		/// <summary>Gets the starting position of the text.</summary>
		/// <returns>The XPS_POINT structure that receives the starting position of the text.</returns>
		/// <remarks>
		/// In the units of the effective coordinate space, the origin specifies the x and y coordinates of the first glyph in the run.
		/// The glyph is placed such that its baseline and the leading edge of its advance vector intersect with the point defined by
		/// origin.x and origin.y.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getorigin HRESULT GetOrigin(
		// XPS_POINT *origin );
		XPS_POINT GetOrigin();

		/// <summary>Sets the starting position of the text.</summary>
		/// <param name="origin">The XPS_POINT structure that contains the coordinates to be set as the text's starting position.</param>
		/// <remarks>
		/// In the units of the effective coordinate space, the origin specifies the x and y coordinates of the first glyph in the run.
		/// The glyph is placed such that its baseline and the leading edge of its advance vector intersect with the point defined by
		/// origin.x and origin.y.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-setorigin HRESULT SetOrigin(
		// const XPS_POINT *origin );
		void SetOrigin(in XPS_POINT origin);

		/// <summary>Gets the font size.</summary>
		/// <returns>The font size.</returns>
		/// <remarks>
		/// <para>
		/// The em size that is returned in fontRenderingEmSize specifies the font size in the drawing surface units. The drawing
		/// surface units are expressed as floating-point values in the effective coordinate space.
		/// </para>
		/// <para>In new glyph objects, the default value of fontRenderingEmSize is 10.0.</para>
		/// <para>If the value of fontRenderingEmSize is 0.0, no text is displayed.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getfontrenderingemsize
		// HRESULT GetFontRenderingEmSize( FLOAT *fontRenderingEmSize );
		float GetFontRenderingEmSize();

		/// <summary>Sets the font size of the text.</summary>
		/// <param name="fontRenderingEmSize">The font size.</param>
		/// <remarks>
		/// <para>
		/// The em size returned in fontRenderingEmSize specifies the font size in drawing surface units. Drawing surface units are
		/// expressed as floating-point values in the units of the effective coordinate space.
		/// </para>
		/// <para>In new glyph objects, the default value of fontRenderingEmSize is 10.0.</para>
		/// <para>If the value of fontRenderingEmSize is 0.0, no text is displayed.</para>
		/// <para>A value of 0.0 results in no visible text being displayed.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-setfontrenderingemsize
		// HRESULT SetFontRenderingEmSize( FLOAT fontRenderingEmSize );
		void SetFontRenderingEmSize([In] float fontRenderingEmSize);

		/// <summary>Gets a pointer to the IXpsOMFontResource interface of the font resource object required for this text.</summary>
		/// <returns>A pointer to the IXpsOMFontResource interface of the font resource.</returns>
		/// <remarks>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getfontresource HRESULT
		// GetFontResource( IXpsOMFontResource **fontResource );
		IXpsOMFontResource GetFontResource();

		/// <summary>Sets the pointer to the IXpsOMFontResource interface of the font resource object that is required for this text.</summary>
		/// <param name="fontResource">The pointer to the IXpsOMFontResource interface to be used.</param>
		/// <remarks>fontResource must not be a <c>NULL</c> pointer; a glyph object must have a font resource.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-setfontresource HRESULT
		// SetFontResource( IXpsOMFontResource *fontResource );
		void SetFontResource([In] IXpsOMFontResource fontResource);

		/// <summary>
		/// <para>Gets the index of the font face to be used.</para>
		/// <para>
		/// This value is only used when GetFontResource returns an IXpsOMFontResource interface that represents a <c>TrueType</c> font collection.
		/// </para>
		/// </summary>
		/// <returns>The index value of the font face. If the font face has not been set, –1 is returned.</returns>
		/// <remarks>
		/// <para>The font resource is obtained by calling the GetFontResource method.</para>
		/// <para>
		/// If a font face has not been set or is not supported by the font, a value of –1 is returned in fontFaceIndex. When the glyph
		/// is loaded from an existing XPS document file, a fontFaceIndex value of –1 indicates that the <c>FontUri</c> attribute did
		/// not include a <c>#index</c> fragment.
		/// </para>
		/// <para>
		/// In the following markup of a FixedPage, the <c>FontUri</c> attribute of the <c>Glyphs</c> element has a value of . In this
		/// case, <c>GetFontFaceIndex</c> would return a value of 1 in fontFaceIndex.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getfontfaceindex HRESULT
		// GetFontFaceIndex( SHORT *fontFaceIndex );
		short GetFontFaceIndex();

		/// <summary>
		/// <para>Sets the index of the font face to be used.</para>
		/// <para>
		/// This value is only used when GetFontResource returns an IXpsOMFontResource interface that represents a <c>TrueType</c> font collection.
		/// </para>
		/// </summary>
		/// <param name="fontFaceIndex">The index value of the font face to be used.</param>
		/// <remarks>
		/// <para>
		/// The default value of the font face index property is –1, which means that a font index has not been set or the font resource
		/// is not a <c>TrueType</c> font collection.
		/// </para>
		/// <para>
		/// If this value is specified and is not –1, "#&lt;Index&gt;" is appended to the Font URI during serialization. Here,
		/// &lt;Index&gt; is the value that is set by <c>SetFontFaceIndex</c>.
		/// </para>
		/// <para>
		/// The following markup of a FixedPage shows the result of setting the fontFaceIndex to 1. Notice that the <c>FontUri</c>
		/// attribute of the <c>Glyphs</c> element has a value of , which includes the index of the font face.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-setfontfaceindex HRESULT
		// SetFontFaceIndex( SHORT fontFaceIndex );
		void SetFontFaceIndex([In] short fontFaceIndex);

		/// <summary>Gets a pointer to the resolved IXpsOMBrush interface of the fill brush to be used for the text.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the resolved IXpsOMBrush interface of the fill brush to be used for the text. If a fill brush has not been set,
		/// a <c>NULL</c> pointer will be returned.
		/// </para>
		/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the brush.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in fillBrush</term>
		/// </listheader>
		/// <item>
		/// <term>SetFillBrushLocal</term>
		/// <term>The local brush that is set by SetFillBrushLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetFillBrushLookup</term>
		/// <term>
		/// The shared brush retrieved, with a lookup key that matches the key that is set by SetFillBrushLookup, from the local or
		/// resource directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Neither SetFillBrushLocal nor SetFillBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>The fill brush is used to fill the shape of the rendered glyphs.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getfillbrush HRESULT
		// GetFillBrush( IXpsOMBrush **fillBrush );
		IXpsOMBrush GetFillBrush();

		/// <summary>Gets a pointer to the local, unshared IXpsOMBrush interface of the fill brush to be used for the text.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the local, unshared IXpsOMBrush interface of the fill brush to be used for the text. If a fill brush lookup key
		/// has been set or if a local fill brush has not been set, a <c>NULL</c> pointer will be returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in fillBrush</term>
		/// </listheader>
		/// <item>
		/// <term>SetFillBrushLocal</term>
		/// <term>The local brush that is set by SetFillBrushLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetFillBrushLookup</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetFillBrushLocal nor SetFillBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getfillbrushlocal HRESULT
		// GetFillBrushLocal( IXpsOMBrush **fillBrush );
		IXpsOMBrush GetFillBrushLocal();

		/// <summary>Sets the IXpsOMBrush interface pointer to a local, unshared fill brush.</summary>
		/// <param name="fillBrush">
		/// The IXpsOMBrush interface pointer to be set as the local, unshared fill brush. A <c>NULL</c> pointer releases any previously
		/// assigned brushes.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetFillBrushLocal</c>, the fill brush lookup key is released and GetFillBrushLookup returns a <c>NULL</c>
		/// pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in fillBrush by GetFillBrush</term>
		/// <term>Object that is returned in fillBrush by GetFillBrushLocal</term>
		/// <term>String that is returned in key by GetFillBrushLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetFillBrushLocal (this method)</term>
		/// <term>The local brush that is set by SetFillBrushLocal.</term>
		/// <term>The local brush that is set by SetFillBrushLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetFillBrushLookup</term>
		/// <term>
		/// The shared brush that gets retrieved, with a lookup key matching the key that is set by SetFillBrushLookup, from the
		/// resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetFillBrushLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetFillBrushLocal nor SetFillBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-setfillbrushlocal HRESULT
		// SetFillBrushLocal( IXpsOMBrush *fillBrush );
		void SetFillBrushLocal([In] IXpsOMBrush fillBrush);

		/// <summary>
		/// Gets the lookup key of the IXpsOMBrush interface that is stored in a resource dictionary and will be used as the fill brush.
		/// </summary>
		/// <returns>
		/// <para>
		/// The lookup key for the brush that is stored in a resource dictionary and will be used as the fill brush. If a fill brush
		/// lookup key has not been set or if a local fill brush has been set, a <c>NULL</c> pointer will be returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>String that is returned in key</term>
		/// </listheader>
		/// <item>
		/// <term>SetFillBrushLocal</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetFillBrushLookup</term>
		/// <term>The lookup key that is set by SetFillBrushLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetFillBrushLocal nor SetFillBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getfillbrushlookup HRESULT
		// GetFillBrushLookup( LPWSTR *key );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetFillBrushLookup();

		/// <summary>Sets the lookup key name of a shared fill brush.</summary>
		/// <param name="key">
		/// A string variable that contains the key name of the fill brush that is stored in the resource dictionary and will be used as
		/// the shared fill brush. A <c>NULL</c> pointer clears any previously assigned key string.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetFillBrushLookup</c>, the local fill brush is released and GetFillBrushLocal returns a <c>NULL</c>
		/// pointer in the fillBrush parameter. The table that follows explains the relationship between the local and lookup values of
		/// this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in fillBrush by GetFillBrush</term>
		/// <term>Object that is returned in fillBrush by GetFillBrushLocal</term>
		/// <term>String that is returned in key by GetFillBrushLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetFillBrushLocal</term>
		/// <term>The local brush that is set by SetFillBrushLocal.</term>
		/// <term>The local brush that is set by SetFillBrushLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetFillBrushLookup (this method)</term>
		/// <term>
		/// The shared brush that gets retrieved, with a lookup key matching the key that is set by SetFillBrushLookup, from the
		/// resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetFillBrushLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetFillBrushLocal nor SetFillBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-setfillbrushlookup HRESULT
		// SetFillBrushLookup( LPCWSTR key );
		void SetFillBrushLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

		/// <summary>Gets a pointer to the IXpsOMGlyphsEditor interface that will be used to edit the glyphs in the object.</summary>
		/// <returns>A pointer to the IXpsOMGlyphsEditor interface.</returns>
		/// <remarks>An IXpsOMGlyphsEditor interface is required to edit the read-only properties of the IXpsOMGlyphs interface.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getglyphseditor HRESULT
		// GetGlyphsEditor( IXpsOMGlyphsEditor **editor );
		IXpsOMGlyphsEditor GetGlyphsEditor();

		/// <summary>Makes a deep copy of the interface.</summary>
		/// <returns>A pointer to the copy of the interface.</returns>
		/// <remarks>This method does not update any of the resource pointers in the copy of the interface.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-clone HRESULT Clone(
		// IXpsOMGlyphs **glyphs );
		IXpsOMGlyphs Clone();
	}

	/// <summary>Allows batch modification of properties that affect the text content in an IXpsOMGlyphs interface.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomglyphseditor
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "5bdf2892-ce6f-4560-b638-e441166fc309")]
	[ComImport, Guid("A5AB8616-5B16-4B9F-9629-89B323ED7909"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMGlyphsEditor
	{
		/// <summary>Performs cross-property validation and then copies the changes to the parent IXpsOMGlyphs interface.</summary>
		/// <remarks>
		/// The IXpsOMGlyphsEditor interface remains valid after this method is called, allowing for additional modifications to be made.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-applyedits HRESULT ApplyEdits();
		void ApplyEdits();

		/// <summary>Gets the text in unescaped UTF-16 scalar values.</summary>
		/// <returns>The UTF-16 Unicode string. If the string is empty, a <c>NULL</c> pointer is returned.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getunicodestring
		// HRESULT GetUnicodeString( LPWSTR *unicodeString );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetUnicodeString();

		/// <summary>Sets the text in unescaped UTF-16 scalar values.</summary>
		/// <param name="unicodeString">The address of a UTF-16 Unicode string. A <c>NULL</c> pointer clears the property.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-setunicodestring
		// HRESULT SetUnicodeString( LPCWSTR unicodeString );
		void SetUnicodeString([In, MarshalAs(UnmanagedType.LPWStr)] string unicodeString);

		/// <summary>Gets the number of glyph indices.</summary>
		/// <returns>The glyph index count.</returns>
		/// <remarks>To get the glyph indices, call GetGlyphIndices.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getglyphindexcount
		// HRESULT GetGlyphIndexCount( UINT32 *indexCount );
		uint GetGlyphIndexCount();

		/// <summary>Gets an array of XPS_GLYPH_INDEX structures that describe the specific glyph indices in the font.</summary>
		/// <param name="indexCount">
		/// The number of elements that will fit in the array referenced by the glyphIndices parameter. When the method returns,
		/// indexCount will contain the number of XPS_GLYPH_INDEX structures that are returned in the array referenced by glyphIndices.
		/// </param>
		/// <param name="glyphIndices">The XPS_GLYPH_INDEX structure array that receives the glyph indices.</param>
		/// <remarks>
		/// <para>
		/// The glyph indices that are returned in glyphIndices override the default cmap mapping from the <c>UnicodeString</c> property
		/// to the glyph index. Each XPS_GLYPH_INDEX structure also contains advance width and vertical and horizontal offset information.
		/// </para>
		/// <para>GetGlyphIndexCount gets the number of elements in the glyph index array.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getglyphindices
		// HRESULT GetGlyphIndices( UINT32 *indexCount, XPS_GLYPH_INDEX *glyphIndices );
		void GetGlyphIndices(ref uint indexCount, [In, Out] XPS_GLYPH_INDEX[] glyphIndices);

		/// <summary>Sets an XPS_GLYPH_INDEX structure array that describes which glyph indices are to be used in the font.</summary>
		/// <param name="indexCount">
		/// The number of XPS_GLYPH_INDEX structures in the array that is referenced by glyphIndices. The value of 0 clears the property.
		/// </param>
		/// <param name="glyphIndices">
		/// An array of XPS_GLYPH_INDEX structures that contain the glyph indices. If indexCount is 0, this parameter is ignored.
		/// </param>
		/// <remarks>
		/// The glyph indices that are passed in glyphIndices override the default cmap mapping from the <c>UnicodeString</c> property
		/// to the glyph index. Each XPS_GLYPH_INDEX structure also has advance width and vertical and horizontal offset information.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-setglyphindices
		// HRESULT SetGlyphIndices( UINT32 indexCount, const XPS_GLYPH_INDEX *glyphIndices );
		void SetGlyphIndices([In] uint indexCount, [In] XPS_GLYPH_INDEX[] glyphIndices);

		/// <summary>Gets the number of glyph mappings.</summary>
		/// <returns>The number of glyph mappings.</returns>
		/// <remarks>To get the glyph mappings, call GetGlyphMappings.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getglyphmappingcount
		// HRESULT GetGlyphMappingCount( UINT32 *glyphMappingCount );
		uint GetGlyphMappingCount();

		/// <summary>
		/// Gets an array of XPS_GLYPH_MAPPING structures that describe how to map UTF-16 scalar values to entries in the array of
		/// XPS_GLYPH_INDEX structures, which is returned by GetGlyphIndices.
		/// </summary>
		/// <param name="glyphMappingCount">
		/// The number of XPS_GLYPH_MAPPING structures that will fit in the array referenced by glyphMappings. When the method returns,
		/// glyphMappingCount will contain the number of values in that array.
		/// </param>
		/// <param name="glyphMappings">An array of XPS_GLYPH_MAPPING structures that receives the glyph mapping values.</param>
		/// <remarks>GetGlyphMappingCount gets the number of glyph mappings.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getglyphmappings
		// HRESULT GetGlyphMappings( UINT32 *glyphMappingCount, XPS_GLYPH_MAPPING *glyphMappings );
		void GetGlyphMappings(ref uint glyphMappingCount, [In, Out] XPS_GLYPH_MAPPING[] glyphMappings);

		/// <summary>
		/// Sets an array of XPS_GLYPH_MAPPING structures that describe how to map the UTF-16 scalar values in the <c>UnicodeString</c>
		/// property to entries in the array of XPS_GLYPH_INDEX structures.
		/// </summary>
		/// <param name="glyphMappingCount">
		/// The number of XPS_GLYPH_MAPPING structures in the array that is referenced by glyphMappings. A value of 0 clears the property.
		/// </param>
		/// <param name="glyphMappings">
		/// An XPS_GLYPH_MAPPING structure array that contains the glyph mapping values. If glyphMappingCount is 0, this parameter is
		/// ignored and can be set to <c>NULL</c>.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-setglyphmappings
		// HRESULT SetGlyphMappings( UINT32 glyphMappingCount, const XPS_GLYPH_MAPPING *glyphMappings );
		void SetGlyphMappings([In] uint glyphMappingCount, [In] XPS_GLYPH_MAPPING[] glyphMappings);

		/// <summary>Gets the number of prohibited caret stops.</summary>
		/// <returns>The number of prohibited caret stops.</returns>
		/// <remarks>
		/// <para>To get the prohibited caret stops, call GetProhibitedCaretStops.</para>
		/// <para>
		/// Each caret stop index corresponds to the scalar values of a UTF-16 <c>UnicodeString</c> property. Index 0 represents the
		/// location just before the first UTF-16 scalar value of <c>UnicodeString</c>; index 1 represents the location between the
		/// first and second UTF-16 scalar values, and so on. There is an additional index at the end of <c>UnicodeString</c>. Any
		/// unspecified index is a valid caret stop location.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getprohibitedcaretstopcount
		// HRESULT GetProhibitedCaretStopCount( UINT32 *prohibitedCaretStopCount );
		uint GetProhibitedCaretStopCount();

		/// <summary>Gets an array of prohibited caret stop locations.</summary>
		/// <param name="count">
		/// The number of prohibited caret stop values that will fit in the array that is referenced by the prohibitedCaretStops
		/// parameter. When the method returns, prohibitedCaretStopCount will contain the number of values in that array.
		/// </param>
		/// <param name="prohibitedCaretStops">
		/// An array of glyph mapping values. If no prohibited caret stops have been defined, a <c>NULL</c> pointer is returned.
		/// </param>
		/// <remarks>
		/// <para>
		/// Each caret stop index corresponds to the scalar values of a UTF-16 <c>UnicodeString</c> property. Index 0 represents the
		/// location just before the first UTF-16 scalar value of <c>UnicodeString</c>; index 1 represents the location between the
		/// first and second UTF-16 scalar values, and so on. There is an additional index at the end of <c>UnicodeString</c>. Any
		/// unspecified index is a valid caret stop location.
		/// </para>
		/// <para>GetProhibitedCaretStopCount gets the number of prohibited caret stops.</para>
		/// <para>A caret stop is the index of the UTF-16 code point in the <c>UnicodeString</c> property of the glyph.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getprohibitedcaretstops
		// HRESULT GetProhibitedCaretStops( UINT32 *count, UINT32 *prohibitedCaretStops );
		void GetProhibitedCaretStops(ref uint count, [In, Out] uint[] prohibitedCaretStops);

		/// <summary>Sets an array of prohibited caret stop locations.</summary>
		/// <param name="count">
		/// The number of prohibited caret stop locations in the array that is referenced by prohibitedCaretStops. A value of 0 clears
		/// the property.
		/// </param>
		/// <param name="prohibitedCaretStops">
		/// The array of prohibited caret stop locations to be set. If count is 0, this parameter is ignored and can be set to <c>NULL</c>.
		/// </param>
		/// <remarks>
		/// Each caret stop index corresponds to the scalar values of a UTF-16 <c>UnicodeString</c> property. Index 0 represents the
		/// location just before the first UTF-16 scalar value of <c>UnicodeString</c>; index 1 represents the location between the
		/// first and second UTF-16 scalar values, and so on. There is an additional index at the end of <c>UnicodeString</c>. Any
		/// unspecified index is a valid caret stop location.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-setprohibitedcaretstops
		// HRESULT SetProhibitedCaretStops( UINT32 count, const UINT32 *prohibitedCaretStops );
		void SetProhibitedCaretStops([In] uint count, [In] uint[] prohibitedCaretStops);

		/// <summary>Gets the bidirectional text level of the parent IXpsOMGlyphs interface.</summary>
		/// <returns>
		/// <para>The bidirectional text level.</para>
		/// <para>Range: 0–61</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>BidiLevel</c> property specifies the bidirectional nesting level of the Unicode algorithm. Even values imply the
		/// left-to-right layout and odd values the right-to-left layout. Right-to-left layout places the run origin at the right side
		/// of the first glyph. Advance widths that are positive will move to the left, allowing subsequent glyphs to be placed to the
		/// left of the previous glyph.
		/// </para>
		/// <para>The range of allowed values for this property is between 0 and 61, inclusive, and the default value is 0.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getbidilevel HRESULT
		// GetBidiLevel( UINT32 *bidiLevel );
		uint GetBidiLevel();

		/// <summary>Sets the level of bidirectional text.</summary>
		/// <param name="bidiLevel">
		/// <para>The level of bidirectional text.</para>
		/// <para>Range: 0–61</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The <c>BidiLevel</c> property specifies the bidirectional nesting level of the Unicode algorithm. Even values imply the
		/// left-to-right layout and odd values the right-to-left layout. Right-to-left layout places the run origin on the right side
		/// of the first glyph. Advance widths that are positive will move to the left, allowing subsequent glyphs to be placed to the
		/// left of the previous glyph.
		/// </para>
		/// <para>The range of allowed values for this property is between 0 and 61, inclusive, and the default value is 0.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-setbidilevel HRESULT
		// SetBidiLevel( UINT32 bidiLevel );
		void SetBidiLevel([In] uint bidiLevel);

		/// <summary>Gets a Boolean value that indicates whether the text is to be rendered with the glyphs rotated sideways.</summary>
		/// <returns>
		/// <para>The Boolean value that indicates whether the text is to be rendered with the glyphs rotated sideways.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>Rotate the glyphs sideways. Produces sideways text.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>Do not rotate the glyphs sideways. Produces normal text.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>The default value for this property is <c>false</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getissideways HRESULT
		// GetIsSideways( BOOL *isSideways );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetIsSideways();

		/// <summary>Sets the value that indicates whether the text is to be rendered with the glyphs rotated sideways.</summary>
		/// <param name="isSideways">
		/// <para>The Boolean value that indicates whether the text is to be rendered with the glyphs rotated sideways.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>Rotate the glyphs sideways. Produces sideways text.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>Do not rotate the glyphs sideways. Produces normal text.</term>
		/// </item>
		/// </list>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-setissideways HRESULT
		// SetIsSideways( BOOL isSideways );
		void SetIsSideways([In, MarshalAs(UnmanagedType.Bool)] bool isSideways);

		/// <summary>Gets the name of the device font.</summary>
		/// <returns>The name of the device font; if not specified, a <c>NULL</c> pointer will be returned.</returns>
		/// <remarks>
		/// <para>The device font name is created as an escaped name when the object is serialized.</para>
		/// <para>The device font name uniquely identifies a specific device font and is typically defined by a hardware or font vendor.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getdevicefontname
		// HRESULT GetDeviceFontName( LPWSTR *deviceFontName );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetDeviceFontName();

		/// <summary>Sets the name of the device font.</summary>
		/// <param name="deviceFontName">
		/// A pointer to the string that contains the name of the device font in its unescaped form. A <c>NULL</c> pointer clears the property.
		/// </param>
		/// <remarks>
		/// The device font name that is passed in deviceFontName can be set in its unescaped form; it will be converted to its escaped
		/// form when the document is serialized.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-setdevicefontname
		// HRESULT SetDeviceFontName( LPCWSTR deviceFontName );
		void SetDeviceFontName([In, MarshalAs(UnmanagedType.LPWStr)] string deviceFontName);
	}

	/// <summary>
	/// <para>
	/// This interface describes a gradient that is made up of gradient stops. Classes that inherit from <c>IXpsOMGradientBrush</c>
	/// specify different ways of interpreting gradient stops.
	/// </para>
	/// <para><c>IXpsOMGradientBrush</c> is the base interface for the IXpsOMLinearGradientBrush and IXpsOMRadialGradientBrush interfaces.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The methods of this interface define the basic parameters of a gradient. The gradient type, which can be linear or radial,
	/// determines how these parameters are applied.
	/// </para>
	/// <para>
	/// As shown in the figure that follows, the start and end points of a linear gradient mark the end points of the gradient path. The
	/// gradient path is the straight line that connects the start and end points. The gradient region of a linear gradient consists of
	/// the area between the start and end points, including those points, and extends in both directions at a right angle to the
	/// gradient path. The spread area is the area outside the gradient region.
	/// </para>
	/// <para>
	/// Gradient stops define the color at specific locations along the gradient path; the color is interpolated along the gradient path
	/// between the gradient stops, as shown in the following illustration.
	/// </para>
	/// <para>
	/// As shown in the figure that follows, the gradient region of a radial gradient is the area enclosed by the ellipse that is
	/// described by the center point and the x and y radii that extend from the center point. The spread area is the area outside of
	/// that ellipse. The gradient path is a radial line that sweeps the entire gradient region from the gradient origin to the ellipse
	/// that bounds the gradient region. In the following illustration, the gradient path is not shown.
	/// </para>
	/// <para>
	/// The spread method describes how the spread area is filled. Implementation of the spread method depends on the gradient type
	/// (linear or radial). The following illustration shows several examples of how the spread area can be filled. For information
	/// about different spread methods, see XPS_SPREAD_METHOD.
	/// </para>
	/// <para>
	/// The transform determines how the resulting gradient is transformed. The visible part of the gradient that is ultimately rendered
	/// in the image is determined by the path, stroke, or glyph that is using the gradient brush.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomgradientbrush
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "d381b813-5368-4ffe-a9a1-0f5027ae9d80")]
	[ComImport, Guid("EDB59622-61A2-42C3-BACE-ACF2286C06BF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMGradientBrush : IXpsOMBrush
	{
		/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
		/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner HRESULT
		// GetOwner( IUnknown **owner );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		new object GetOwner();

		/// <summary>Gets the object type of the interface.</summary>
		/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype HRESULT GetType(
		// XPS_OBJECT_TYPE *type );
		new XPS_OBJECT_TYPE GetType();

		/// <summary>Gets the opacity of the brush.</summary>
		/// <returns>The opacity value of the brush.</returns>
		/// <remarks>
		/// opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is
		/// 50 percent opaque, and 1.0 that it is completely opaque.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-getopacity HRESULT
		// GetOpacity( FLOAT *opacity );
		new float GetOpacity();

		/// <summary>Sets the opacity of the brush.</summary>
		/// <param name="opacity">The opacity value of the brush.</param>
		/// <remarks>
		/// <para>
		/// opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is
		/// 50 percent opaque, and 1.0 that it is completely opaque.
		/// </para>
		/// <para>If opacity is less than 0.0 or greater than 1.0, the method returns an error.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-setopacity HRESULT
		// SetOpacity( FLOAT opacity );
		new void SetOpacity([In] float opacity);

		/// <summary>
		/// Gets a pointer to an IXpsOMGradientStopCollection interface that contains the collection of IXpsOMGradientStop interfaces
		/// that define the gradient.
		/// </summary>
		/// <returns>A pointer to the IXpsOMGradientStopCollection interface that contains the collection of IXpsOMGradientStop interfaces.</returns>
		/// <remarks>
		/// <para>
		/// Gradient stops, which are described in the XPS OM by an IXpsOMGradientStop interface, are used to define the color at a
		/// specific location along a gradient path; the color is interpolated between the gradient stops. The illustration that follows
		/// shows the gradient path and gradient stops of a linear gradient.
		/// </para>
		/// <para>
		/// The illustration that follows shows the gradient stops of a radial gradient. In this example, the gradient region is the
		/// area enclosed by the outer ellipse, and the radial gradient is using the <c>XPS_SPREAD_METHOD_REFLECT</c> spread method to
		/// fill the space outside of the gradient region.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-getgradientstops
		// HRESULT GetGradientStops( IXpsOMGradientStopCollection **gradientStops );
		IXpsOMGradientStopCollection GetGradientStops();

		/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the resolved matrix transform for the brush.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMMatrixTransform interface that contains the resolved matrix transform for the brush. If the transform
		/// has not been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <para>The value that is returned in this parameter depends on which method has been most recently called to set the transform.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in transform</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>
		/// The shared transform that is retrieved, with a lookup key that matches the key set by SetTransformLookup, from the resource directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The transform determines how the gradient is transformed. The visible part of the gradient that is ultimately rendered in
		/// the image is determined by the path, stroke, or glyph that is using the gradient brush.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-gettransform HRESULT
		// GetTransform( IXpsOMMatrixTransform **transform );
		IXpsOMMatrixTransform GetTransform();

		/// <summary>
		/// Gets a pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the brush.
		/// </summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the brush.
		/// If the transform has not been set or if a matrix transform lookup key has been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <para>The value that is returned in this parameter depends on which method has been most recently called to set the transform.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in transform</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The transform determines how the gradient is transformed. The visible part of the gradient that is ultimately rendered in
		/// the image is determined by the path, stroke, or glyph that is using the gradient brush.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-gettransformlocal
		// HRESULT GetTransformLocal( IXpsOMMatrixTransform **transform );
		IXpsOMMatrixTransform GetTransformLocal();

		/// <summary>
		/// Sets the IXpsOMMatrixTransform interface pointer to a local, unshared matrix transform that is to be used for the brush.
		/// </summary>
		/// <param name="transform">
		/// A pointer to the IXpsOMMatrixTransform interface of the local, unshared matrix transform that is to be used for the brush. A
		/// <c>NULL</c> pointer releases any previously set interface.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetTransformLocal</c>, the transform lookup key is released and GetTransformLocal returns a <c>NULL</c>
		/// pointer in the transform parameter. The table that follows explains the relationship between the local and lookup values of
		/// this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in transform by GetTransform</term>
		/// <term>Object that is returned in transform by GetTransformLocal</term>
		/// <term>Object that is returned in key by GetTransformLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal (this method)</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>
		/// The shared transform retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetTransformLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The transform passed in transform determines how the gradient is transformed. The visible part of the gradient that is
		/// ultimately rendered in the image is determined by the path, stroke, or glyph that is using the gradient brush.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-settransformlocal
		// HRESULT SetTransformLocal( IXpsOMMatrixTransform *transform );
		void SetTransformLocal([In] IXpsOMMatrixTransform transform);

		/// <summary>
		/// <para>Gets the name of the lookup key of the shared matrix transform interface that is to be used for the brush.</para>
		/// <para>The key name identifies a shared resource in a resource dictionary.</para>
		/// </summary>
		/// <returns>
		/// <para>
		/// The name of the lookup key of the shared matrix transform interface that is to be used for the brush. If the lookup key name
		/// has not been set or if the local matrix transform has been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <para>
		/// The value that is returned in this parameter depends on which method has been most recently called to set the lookup key or
		/// the transform.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>String that is returned in key</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>The key that is set by SetTransformLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method does not return an IXpsOMMatrixTransform interface pointer; to retrieve this pointer from the dictionary, call IXpsOMDictionary::GetByKey.
		/// </para>
		/// <para>
		/// The transform determines how the gradient is transformed. The visible part of the gradient that is ultimately rendered in
		/// the image is determined by the path, stroke, or glyph that is using the gradient brush.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-gettransformlookup
		// HRESULT GetTransformLookup( LPWSTR *key );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetTransformLookup();

		/// <summary>
		/// <para>Sets the name of the lookup key of a shared matrix transform that is to be used for the brush.</para>
		/// <para>The key name identifies a shared resource in a resource dictionary.</para>
		/// </summary>
		/// <param name="key">The name of the lookup key of the matrix transform that is to be used for the brush.</param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetTransformLookup</c>, the local transform is released and GetTransformLocal returns a <c>NULL</c>
		/// pointer in the transform parameter. The table that follows explains the relationship between the local and lookup values of
		/// this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in transform by GetTransform</term>
		/// <term>Object that is returned in transform by GetTransformLocal</term>
		/// <term>Object that is returned in key by GetTransformLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// <term>The local transform that is set by SetTransformLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup (this method)</term>
		/// <term>
		/// The shared transform retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetTransformLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The transform referenced by key determines how the gradient is transformed. The visible part of the gradient that is
		/// ultimately rendered in the image is determined by the path, stroke, or glyph that is using the brush.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-settransformlookup
		// HRESULT SetTransformLookup( LPCWSTR key );
		void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

		/// <summary>Gets the XPS_SPREAD_METHOD value, which describes how the area outside of the gradient region will be rendered.</summary>
		/// <returns>
		/// The XPS_SPREAD_METHOD value that describes how the area outside of the gradient region will be rendered. The gradient region
		/// is defined by the linear-gradient brush or radial-gradient brush that inherits this interface.
		/// </returns>
		/// <remarks>For more information about different types of spread methods, see XPS_SPREAD_METHOD.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-getspreadmethod
		// HRESULT GetSpreadMethod( XPS_SPREAD_METHOD *spreadMethod );
		XPS_SPREAD_METHOD GetSpreadMethod();

		/// <summary>
		/// Sets the XPS_SPREAD_METHOD value, which describes how the area outside of the gradient region is to be rendered. The
		/// gradient region is defined by the start and end points of the gradient.
		/// </summary>
		/// <param name="spreadMethod">
		/// The XPS_SPREAD_METHOD value that describes how the area outside of the gradient region is to be rendered. The gradient
		/// region is defined by the linear-gradient brush or radial-gradient brush that inherits this interface.
		/// </param>
		/// <remarks>For more information about different types of spread methods, see XPS_SPREAD_METHOD.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-setspreadmethod
		// HRESULT SetSpreadMethod( XPS_SPREAD_METHOD spreadMethod );
		void SetSpreadMethod([In] XPS_SPREAD_METHOD spreadMethod);

		/// <summary>Gets the gamma function to be used for color interpolation.</summary>
		/// <returns>The XPS_COLOR_INTERPOLATION value that describes the gamma function to be used for color interpolation.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-getcolorinterpolationmode
		// HRESULT GetColorInterpolationMode( XPS_COLOR_INTERPOLATION *colorInterpolationMode );
		XPS_COLOR_INTERPOLATION GetColorInterpolationMode();

		/// <summary>Sets the XPS_COLOR_INTERPOLATION value, which describes the gamma function to be used for color interpolation.</summary>
		/// <param name="colorInterpolationMode">
		/// The XPS_COLOR_INTERPOLATION value, which describes the gamma function to be used for color interpolation.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-setcolorinterpolationmode
		// HRESULT SetColorInterpolationMode( XPS_COLOR_INTERPOLATION colorInterpolationMode );
		void SetColorInterpolationMode([In] XPS_COLOR_INTERPOLATION colorInterpolationMode);
	}

	/// <summary>Represents a single color and location within a gradient.</summary>
	/// <remarks>
	/// <para>
	/// A gradient stop is a specific color that is defined for a location within the gradient region. The color of the gradient changes
	/// between the gradient stops of the gradient. The area and absolute location of the gradient is defined by the gradient interface.
	/// The offset is a relative location within the gradient region and is measured between 0.0 and 1.0. An offset of 0.0 is the
	/// beginning of the gradient and 1.0 is the end. Gradient stops can be defined for any offset within the range, including the end
	/// points. This interface describes one and only one stop in a gradient.
	/// </para>
	/// <para>
	/// The gradient path is the straight line that connects the start point and the end point of a linear gradient. The gradient region
	/// of a linear gradient consists of the area between the start point and the end point, including those points, and extends in both
	/// directions at a right angle to the gradient path. The spread area is the area outside the gradient region.
	/// </para>
	/// <para>
	/// Gradient stops define the color at a specific location along the gradient path; the color is interpolated along the gradient
	/// path between the gradient stops. In the example that follows, the gradient region fills the image, so there is no spread area.
	/// </para>
	/// <para>
	/// For gradient stops used in linear-gradient brushes, the offset value of 0.0 corresponds to the start point of the gradient path,
	/// and the offset value of 1.0 corresponds to the end point. To determine the location of a gradient stop between these two points,
	/// intermediate offset values are interpolated between them. The following illustration shows two intermediate gradient stops, one
	/// at an offset of 0.25 and another at 0.75.
	/// </para>
	/// <para>
	/// For gradient stops used in radial-gradient brushes, the offset value of 0.0 corresponds to the gradient origin location, and the
	/// offset value of 1.0 corresponds to the circumference of the ellipse that bounds the gradient. Offsets between 0.0 and 1.0 define
	/// an ellipse that is interpolated between the gradient origin and the bounding ellipse. The illustration that follows has one
	/// intermediate gradient stop at an offset of 0.50 (Gradient stop 1). The gradient is using the <c>XPS_SPREAD_METHOD_REFLECT</c>
	/// spread method to fill the space outside of the gradient region.
	/// </para>
	/// <para>The calculations that are used to render a gradient are described in the XML Paper Specification.</para>
	/// <para>The code example that follows illustrates how to create an instance of this interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomgradientstop
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "e115d806-70c1-4c6a-810e-e6a058628b44")]
	[ComImport, Guid("5CF4F5CC-3969-49B5-A70A-5550B618FE49"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMGradientStop
	{
		/// <summary>Gets a pointer to the IXpsOMGradientBrush interface that contains the gradient stop.</summary>
		/// <returns>
		/// A pointer to the IXpsOMGradientBrush interface that contains the gradient stop. If the gradient stop is not assigned to a
		/// gradient brush, a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstop-getowner HRESULT
		// GetOwner( IXpsOMGradientBrush **owner );
		IXpsOMGradientBrush GetOwner();

		/// <summary>Gets the offset value of the gradient stop.</summary>
		/// <returns>The offset value of the gradient stop, expressed as a fraction of the gradient path.</returns>
		/// <remarks>
		/// The valid range of values returned in offset is 0.0–1.0. 0.0 is the start point of the gradient, 1.0 is the end point, and a
		/// value between 0.0 and 1.0 is a location that is linearly interpolated between the start point and the end point.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstop-getoffset HRESULT
		// GetOffset( FLOAT *offset );
		float GetOffset();

		/// <summary>Sets the offset location of the gradient stop.</summary>
		/// <param name="offset">
		/// <para>The offset value that describes the location of the gradient stop as a fraction of the gradient path.</para>
		/// <para>The valid range of this parameter is 0.0 &lt;= offset &lt;= 1.0.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstop-setoffset HRESULT
		// SetOffset( FLOAT offset );
		void SetOffset([In] float offset);

		/// <summary>Gets the color value and color profile of the gradient stop.</summary>
		/// <param name="color">The color value of the gradient stop.</param>
		/// <returns>
		/// A pointer to the IXpsOMColorProfileResource interface that contains the color profile to be used. If no color profile
		/// resource has been set, a <c>NULL</c> pointer is returned. See remarks.
		/// </returns>
		/// <remarks>A color profile is only returned when the color type of color is XPS_COLOR_TYPE_CONTEXT.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstop-getcolor HRESULT
		// GetColor( XPS_COLOR *color, IXpsOMColorProfileResource **colorProfile );
		IXpsOMColorProfileResource GetColor(out XPS_COLOR color);

		/// <summary>Sets the color value and color profile of the gradient stop.</summary>
		/// <param name="color">
		/// <para>The color value to be set at the gradient stop.</para>
		/// <para>
		/// If the value of the <c>colorType</c> field in the XPS_COLOR structure that is passed in this parameter is
		/// XPS_COLOR_TYPE_CONTEXT, a valid color profile must be provided in the colorProfile parameter.
		/// </para>
		/// </param>
		/// <param name="colorProfile">
		/// <para>The color profile to be used with color.</para>
		/// <para>
		/// A color profile is required when the value of the <c>colorType</c> field in the XPS_COLOR structure that is passed in the
		/// color parameter is XPS_COLOR_TYPE_CONTEXT. If the value of the <c>colorType</c> field is not <c>XPS_COLOR_TYPE_CONTEXT</c>,
		/// this parameter must be set to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <remarks>A color profile is only required when the color type of color is XPS_COLOR_TYPE_CONTEXT.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstop-setcolor HRESULT
		// SetColor( const XPS_COLOR *color, IXpsOMColorProfileResource *colorProfile );
		void SetColor(in XPS_COLOR color, [In] IXpsOMColorProfileResource colorProfile);

		/// <summary>Makes a deep copy of the IXpsOMGradientStop interface.</summary>
		/// <returns>A pointer to the copy of the interface.</returns>
		/// <remarks>
		/// <para>The owner of the new interface is <c>NULL</c>.</para>
		/// <para>This method does not update any of the resource pointers in the IXpsOMGradientStop interface returned in gradientStop.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstop-clone HRESULT Clone(
		// IXpsOMGradientStop **gradientStop );
		IXpsOMGradientStop Clone();
	}

	/// <summary>A collection of IXpsOMGradientStop interface pointers.</summary>
	/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomgradientstopcollection
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "1f51f818-e9bb-4d88-9795-4e6890d24b8c")]
	[ComImport, Guid("C9174C3A-3CD3-4319-BDA4-11A39392CEEF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMGradientStopCollection
	{
		/// <summary>Gets the number of IXpsOMGradientStop interface pointers in the collection.</summary>
		/// <returns>The number of IXpsOMGradientStop interface pointers in the collection.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstopcollection-getcount
		// HRESULT GetCount( UINT32 *count );
		uint GetCount();

		/// <summary>Gets an IXpsOMGradientStop interface pointer from a specified location in the collection.</summary>
		/// <param name="index">The zero-based index of the IXpsOMGradientStop interface pointer to be obtained.</param>
		/// <returns>The IXpsOMGradientStop interface pointer at the location specified by index.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstopcollection-getat
		// HRESULT GetAt( UINT32 index, IXpsOMGradientStop **stop );
		IXpsOMGradientStop GetAt([In] uint index);

		/// <summary>Inserts an IXpsOMGradientStop interface pointer at a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection where the interface pointer that is passed in stop is to be inserted.
		/// </param>
		/// <param name="stop">The IXpsOMGradientStop interface pointer to be inserted at the location specified by index.</param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method inserts the IXpsOMGradientStop interface pointer that is passed in stop.
		/// Prior to the insertion, the pointer in this and all subsequent locations is moved up by one index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstopcollection-insertat
		// HRESULT InsertAt( UINT32 index, IXpsOMGradientStop *stop );
		void InsertAt([In] uint index, [In] IXpsOMGradientStop stop);

		/// <summary>Removes and releases an IXpsOMGradientStop interface pointer from a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection from which an IXpsOMGradientStop interface pointer is to be removed and released.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method releases the IXpsOMGradientStop interface referenced by the pointer at the location specified by index. After
		/// releasing the interface, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstopcollection-removeat
		// HRESULT RemoveAt( UINT32 index );
		void RemoveAt([In] uint index);

		/// <summary>Replaces an IXpsOMGradientStop interface pointer at a specified location in the collection.</summary>
		/// <param name="index">The zero-based index in the collection where an IXpsOMGradientStop interface pointer is to be replaced.</param>
		/// <param name="stop">
		/// The IXpsOMGradientStop interface pointer that will replace current contents at the location specified by index.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method releases the IXpsOMGradientStop interface referenced by the existing
		/// pointer, then writes the pointer that is passed in stop.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstopcollection-setat
		// HRESULT SetAt( UINT32 index, IXpsOMGradientStop *stop );
		void SetAt([In] uint index, [In] IXpsOMGradientStop stop);

		/// <summary>Appends an IXpsOMGradientStop interface to the end of the collection.</summary>
		/// <param name="stop">A pointer to the IXpsOMGradientStop interface that is to be appended to the collection.</param>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstopcollection-append
		// HRESULT Append( IXpsOMGradientStop *stop );
		void Append([In] IXpsOMGradientStop stop);
	}

	/// <summary>A brush that uses a raster image as a source.</summary>
	/// <remarks>
	/// <para>
	/// The image used by this brush is defined in a coordinate space that is specified by the image's resolution. The image type must
	/// be JPEG, PNG, TIFF 6.0, or HD Photo.
	/// </para>
	/// <para>The code example that follows illustrates how to create an instance of this interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomimagebrush
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "f5478582-466b-496e-b7f3-42fb8caa6814")]
	[ComImport, Guid("3DF0B466-D382-49EF-8550-DD94C80242E4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMImageBrush : IXpsOMTileBrush
	{
		/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
		/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner HRESULT
		// GetOwner( IUnknown **owner );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		new object GetOwner();

		/// <summary>Gets the object type of the interface.</summary>
		/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype HRESULT GetType(
		// XPS_OBJECT_TYPE *type );
		new XPS_OBJECT_TYPE GetType();

		/// <summary>Gets the opacity of the brush.</summary>
		/// <returns>The opacity value of the brush.</returns>
		/// <remarks>
		/// opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is
		/// 50 percent opaque, and 1.0 that it is completely opaque.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-getopacity HRESULT
		// GetOpacity( FLOAT *opacity );
		new float GetOpacity();

		/// <summary>Sets the opacity of the brush.</summary>
		/// <param name="opacity">The opacity value of the brush.</param>
		/// <remarks>
		/// <para>
		/// opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is
		/// 50 percent opaque, and 1.0 that it is completely opaque.
		/// </para>
		/// <para>If opacity is less than 0.0 or greater than 1.0, the method returns an error.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-setopacity HRESULT
		// SetOpacity( FLOAT opacity );
		new void SetOpacity([In] float opacity);

		/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the resolved matrix transform for the brush.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMMatrixTransform interface that contains the resolved matrix transform for the brush. If a matrix
		/// transform has not been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the transform.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in transform</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>The transform that is set by SetTransformLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>
		/// The transform which is retrieved, using a lookup key that matches the key that is set by SetTransformLookup, from the
		/// resource directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The transform determines how the output area is transformed before the brush image is rendered in the path, stroke, or glyph
		/// that is using the tile brush.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-gettransform HRESULT
		// GetTransform( IXpsOMMatrixTransform **transform );
		new IXpsOMMatrixTransform GetTransform();

		/// <summary>
		/// Gets a pointer to the IXpsOMMatrixTransform interface that contains the local, unshared resolved matrix transform for the brush.
		/// </summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMMatrixTransform interface that contains the local, unshared resolved matrix transform for the brush.
		/// If a local matrix transform has not been set or if a matrix transform lookup key has been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in transform</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>The transform that is set by SetTransformLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The transform determines how the output area is transformed before the brush image is rendered in the path, stroke, or glyph
		/// that is using the tile brush.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-gettransformlocal HRESULT
		// GetTransformLocal( IXpsOMMatrixTransform **transform );
		new IXpsOMMatrixTransform GetTransformLocal();

		/// <summary>Sets the IXpsOMMatrixTransform interface pointer to a local, unshared matrix transform.</summary>
		/// <param name="transform">
		/// A pointer to the IXpsOMMatrixTransform interface to be set as the local, unshared matrix transform. If a local transform has
		/// been set, a <c>NULL</c> pointer will release it.
		/// </param>
		/// <remarks>
		/// <para>
		/// The transform determines how the output area is transformed before the brush image is rendered in the path, stroke, or glyph
		/// that is using the tile brush.
		/// </para>
		/// <para>
		/// After you call <c>SetTransformLocal</c>, the transform lookup key is released and GetTransformLookup returns a <c>NULL</c>
		/// pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in transform by GetTransform</term>
		/// <term>Object that is returned in transform by GetTransformLocal</term>
		/// <term>String that is returned in key by GetTransformLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal (this method)</term>
		/// <term>The transform that is set by SetTransformLocal.</term>
		/// <term>The transform that is set by SetTransformLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>
		/// The transform which is retrieved, using a lookup key that matches the key that is set by SetTransformLookup, from the
		/// resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetTransformLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-settransformlocal HRESULT
		// SetTransformLocal( IXpsOMMatrixTransform *transform );
		new void SetTransformLocal([In] IXpsOMMatrixTransform transform);

		/// <summary>
		/// Gets the lookup key that identifies the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved
		/// matrix transform for the brush.
		/// </summary>
		/// <returns>
		/// <para>
		/// The lookup key that identifies the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved
		/// matrix transform for the brush. If a matrix transform lookup key has not been set or if a local matrix transform has been
		/// set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in key</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup</term>
		/// <term>The lookup key set by SetTransformLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The transform determines how the output area is transformed before the brush image is rendered in the path, stroke, or glyph
		/// that is using the tile brush.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-gettransformlookup
		// HRESULT GetTransformLookup( LPWSTR *key );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		new string GetTransformLookup();

		/// <summary>
		/// Sets the lookup key name of a shared matrix transform that will be used as the transform for this brush.The shared matrix
		/// transform that is referenced by the lookup key is stored in the resource dictionary.
		/// </summary>
		/// <param name="key">
		/// A string variable that contains the lookup key name of a shared matrix transform in the resource dictionary. If a lookup key
		/// has already been set, a <c>NULL</c> pointer will clear it.
		/// </param>
		/// <remarks>
		/// <para>
		/// The transform is applied before the brush image is rendered in the path, stroke, or glyph that is using the tile brush. The
		/// tile brush has only one transform, which can be local or remote.
		/// </para>
		/// <para>
		/// After you call <c>SetTransformLookup</c>, the local transform is released and GetTransformLocal returns a <c>NULL</c>
		/// pointer in the transform parameter. The table that follows explains the relationship between the local and lookup values of
		/// this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in transform by GetTransform</term>
		/// <term>Object that is returned in transform by GetTransformLocal</term>
		/// <term>String that is returned in key by GetTransformLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetTransformLocal</term>
		/// <term>The transform that is set by SetTransformLocal.</term>
		/// <term>The transform that is set by SetTransformLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetTransformLookup (this method)</term>
		/// <term>
		/// The transform which is retrieved—using a lookup key that matches the key that is set by SetTransformLookup— from the
		/// resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetTransformLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-settransformlookup
		// HRESULT SetTransformLookup( LPCWSTR key );
		new void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

		/// <summary>Gets the portion of the source image to be used by the tile.</summary>
		/// <returns>The XPS_RECT structure that describes the area of the source content to be used by the tile.</returns>
		/// <remarks>
		/// <para>The brush's viewbox specifies the portion of a source image or visual to be used as the tile image.</para>
		/// <para>
		/// The coordinates of the brush's viewbox are relative to the source content, such that (0,0) specifies the upper-left corner
		/// of the source content. For images, dimensions specified by the brush's viewbox are expressed in the units of 1/96". The
		/// corresponding pixel coordinates in the source image are calculated as follows:
		/// </para>
		/// <para>
		/// In the illustration that follows, the image on the left is an example of a source image, the image in the center shows the
		/// selected viewbox, and the image on the right shows the resulting brush.
		/// </para>
		/// <para>
		/// If the source image resolution is 96 by 96 dots per inch and image dimensions are 96 by 96 pixels, the values of fields in
		/// the viewbox parameter would be:
		/// </para>
		/// <para>The preceding parameter values correspond to the source image as:</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-getviewbox HRESULT
		// GetViewbox( XPS_RECT *viewbox );
		new XPS_RECT GetViewbox();

		/// <summary>Sets the portion of the source content to be used as the tile image.</summary>
		/// <param name="viewbox">An XPS_RECT structure that describes the portion of the source content to be used as the tile image.</param>
		/// <remarks>
		/// <para>The brush's viewbox specifies the portion of a source image or visual to be used as the tile image.</para>
		/// <para>
		/// The coordinates of the brush's viewbox are relative to the source content, such that (0,0) specifies the upper-left corner
		/// of the source content. For images, dimensions specified by the brush's viewbox are expressed in the units of 1/96". The
		/// corresponding pixel coordinates in the source image are calculated as follows:
		/// </para>
		/// <para>
		/// In the illustration that follows, the image on the left is an example of a source image, while that on the right is the
		/// source image with the selected viewbox for the brush shown as a red rectangle. In this example, the part of the source image
		/// that is used as the content for the tile brush is the area within the red rectangle. The shaded area of the image is not
		/// used by the brush.
		/// </para>
		/// <para>
		/// If the source image resolution is 96 by 96 dots per inch and image dimensions are 96 by 96 pixels, the values of fields in
		/// the viewbox parameter would be:
		/// </para>
		/// <para>The preceding parameter values correspond to the source image as:</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-setviewbox HRESULT
		// SetViewbox( const XPS_RECT *viewbox );
		new void SetViewbox(in XPS_RECT viewbox);

		/// <summary>Gets the portion of the destination geometry that is covered by a single tile.</summary>
		/// <returns>The XPS_RECT structure that describes the portion of the destination geometry that is covered by a single tile.</returns>
		/// <remarks>
		/// The viewport is the portion of the output area where the first tile is drawn. In the illustration, the viewport is outlined
		/// by the purple rectangle inside the red, dotted rectangle. The tile mode of the brush determines how the rest of the tiles
		/// are drawn in the output area.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-getviewport HRESULT
		// GetViewport( XPS_RECT *viewport );
		new XPS_RECT GetViewport();

		/// <summary>Sets the portion of the destination geometry that is covered by a single tile.</summary>
		/// <param name="viewport">
		/// An XPS_RECT structure that describes the portion of the destination geometry that is covered by a single tile.
		/// </param>
		/// <remarks>
		/// The viewport is the portion of the output area where the tile is drawn. In the following illustration, the viewport is
		/// outlined by the blue rectangle inside the red, dotted rectangle. The tile mode of the brush determines how other tiles are
		/// drawn in the output area.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-setviewport HRESULT
		// SetViewport( const XPS_RECT *viewport );
		new void SetViewport(in XPS_RECT viewport);

		/// <summary>Gets the XPS_TILE_MODE value that describes the tile mode of the brush.</summary>
		/// <returns>The XPS_TILE_MODE value that describes the tile mode of the brush.</returns>
		/// <remarks>
		/// The tile mode determines how the tile image is repeated to fill the output area. If the tile mode value is
		/// XPS_TILE_MODE_NONE, the tile image is drawn only once. The following illustration shows examples of how the tile image
		/// appears in several tile modes.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-gettilemode HRESULT
		// GetTileMode( XPS_TILE_MODE *tileMode );
		new XPS_TILE_MODE GetTileMode();

		/// <summary>Sets the XPS_TILE_MODE value that describes the tiling mode of the brush.</summary>
		/// <param name="tileMode">The XPS_TILE_MODE value to be set.</param>
		/// <remarks>
		/// The tile mode determines how the tile image is repeated to fill the output area. If the tile mode value is
		/// XPS_TILE_MODE_NONE, the tile image is drawn only once.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-settilemode HRESULT
		// SetTileMode( XPS_TILE_MODE tileMode );
		new void SetTileMode([In] XPS_TILE_MODE tileMode);

		/// <summary>
		/// Gets a pointer to the IXpsOMImageResource interface, which contains the image resource to be used as the source for the brush.
		/// </summary>
		/// <returns>
		/// A pointer to the IXpsOMImageResource interface that contains the image resource to be used as the source for the brush.
		/// </returns>
		/// <remarks>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimagebrush-getimageresource HRESULT
		// GetImageResource( IXpsOMImageResource **imageResource );
		IXpsOMImageResource GetImageResource();

		/// <summary>
		/// Sets a pointer to the IXpsOMImageResource interface that contains the image resource to be used as the source for the brush.
		/// </summary>
		/// <param name="imageResource">
		/// The image resource to be used as the source for the brush. This parameter must not be a <c>NULL</c> pointer.
		/// </param>
		/// <remarks>The image resource must be of type JPEG, PNG, TIFF 6.0, or HD Photo.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimagebrush-setimageresource HRESULT
		// SetImageResource( IXpsOMImageResource *imageResource );
		void SetImageResource([In] IXpsOMImageResource imageResource);

		/// <summary>
		/// Gets a pointer to the IXpsOMColorProfileResource interface, which contains the color profile resource that is associated
		/// with the image.
		/// </summary>
		/// <returns>
		/// A pointer to the IXpsOMColorProfileResource interface that contains the color profile resource that is associated with the
		/// image. If no color profile resource has been set, a <c>NULL</c> pointer is returned.
		/// </returns>
		/// <remarks>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimagebrush-getcolorprofileresource
		// HRESULT GetColorProfileResource( IXpsOMColorProfileResource **colorProfileResource );
		IXpsOMColorProfileResource GetColorProfileResource();

		/// <summary>
		/// Sets a pointer to the IXpsOMColorProfileResource interface, which contains the color profile resource that is associated
		/// with the image.
		/// </summary>
		/// <param name="colorProfileResource">
		/// The color profile resource that is associated with the image. A <c>NULL</c> pointer will release any previously set color
		/// profile resources.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimagebrush-setcolorprofileresource
		// HRESULT SetColorProfileResource( IXpsOMColorProfileResource *colorProfileResource );
		void SetColorProfileResource([In] IXpsOMColorProfileResource colorProfileResource);

		/// <summary>Makes a deep copy of the interface.</summary>
		/// <returns>A pointer to the copy of the interface.</returns>
		/// <remarks>This method does not update any of the resource pointers in the copy.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimagebrush-clone HRESULT Clone(
		// IXpsOMImageBrush **imageBrush );
		IXpsOMImageBrush Clone();
	}

	/// <summary>Provides an IStream interface to an image resource.</summary>
	/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomimageresource
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "89a1530e-fa87-45bf-a1da-c8656ec09ba3")]
	[ComImport, Guid("3DB8417D-AE50-485E-9A44-D7758F78A23F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMImageResource : IXpsOMResource
	{
		/// <summary>Gets the name that will be used when the part is serialized.</summary>
		/// <returns>
		/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
		/// method), a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
		// GetPartName( IOpcPartUri **partUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new IOpcPartUri GetPartName();

		/// <summary>Sets the name that will be used when the part is serialized.</summary>
		/// <param name="partUri">
		/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <remarks>
		/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
		/// has previously serialized.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
		// SetPartName( IOpcPartUri *partUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		new void SetPartName([In] IOpcPartUri partUri);

		/// <summary>Gets a new, read-only copy of the stream that is associated with this resource.</summary>
		/// <returns>A new, read-only copy of the stream that is associated with this resource.</returns>
		/// <remarks>
		/// <para>
		/// The IStream object returned by this method might return an error of E_PENDING, which indicates that the stream length has
		/// not been determined yet. This behavior is different from that of a standard <c>IStream</c> object.
		/// </para>
		/// <para>
		/// This method calls the stream's <c>Clone</c> method to create the stream returned in stream. As a result, the performance of
		/// this method will depend on that of the stream's <c>Clone</c> method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresource-getstream HRESULT
		// GetStream( IStream **readerStream );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IStream GetStream();

		/// <summary>Sets the read-only stream to be associated with this resource.</summary>
		/// <param name="sourceStream">The read-only stream to be associated with this resource.</param>
		/// <param name="imageType">The XPS_IMAGE_TYPE value that describes the type of image in the stream.</param>
		/// <param name="partName">The part name to be assigned to this resource.</param>
		/// <remarks>
		/// <para>
		/// The calling method should treat this stream as a single-threaded apartment (STA) model object and not re-enter any of the
		/// stream interface's methods.
		/// </para>
		/// <para>
		/// Because GetStream gets a clone of the stream that is set by this method, the provided stream should have an efficient
		/// cloning method. A stream with an inefficient cloning method will reduce the performance of <c>GetStream</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresource-setcontent HRESULT
		// SetContent( IStream *sourceStream, XPS_IMAGE_TYPE imageType, IOpcPartUri *partName );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetContent([In] IStream sourceStream, [In] XPS_IMAGE_TYPE imageType, [In] IOpcPartUri partName);

		/// <summary>Gets the type of image resource.</summary>
		/// <returns>The XPS_IMAGE_TYPE value that describes the image type in the stream.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresource-getimagetype HRESULT
		// GetImageType( XPS_IMAGE_TYPE *imageType );
		[MethodImpl(MethodImplOptions.InternalCall)]
		XPS_IMAGE_TYPE GetImageType();
	}

	/// <summary>Represents an x- and y-coordinate pair in two-dimensional space.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ns-xpsobjectmodel-xps_point typedef struct
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0017 { FLOAT x; FLOAT y; } XPS_POINT;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "NS:xpsobjectmodel.__MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0017")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XPS_POINT 
	{
		/// <summary>The x-coordinate of a point.</summary>
		public float x;

		/// <summary>The y-coordinate of a point.</summary>
		public float y;
	}

	/// <summary>Describes the width, height, and location of a rectangle.</summary>
	/// <remarks>The measurement units depend on the context and are not specified in the structure.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ns-xpsobjectmodel-xps_rect typedef struct
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0019 { FLOAT x; FLOAT y; FLOAT width; FLOAT height; } XPS_RECT;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "NS:xpsobjectmodel.__MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0019")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XPS_RECT
	{
		/// <summary>The x-coordinate of the rectangle's left side.</summary>
		public float x;

		/// <summary>The y-coordinate of the rectangle's top side.</summary>
		public float y;

		/// <summary>A non-negative value that represents the object's size in the horizontal (x) dimension.</summary>
		public float width;

		/// <summary>A non-negative value that represents the object's size in the vertical (y) dimension.</summary>
		public float height;
	}

	/// <summary>Describes the size of an object.</summary>
	/// <remarks>The measurement units are not specified in the structure.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ns-xpsobjectmodel-xps_size typedef struct
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0018 { FLOAT width; FLOAT height; } XPS_SIZE;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "NS:xpsobjectmodel.__MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0018")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XPS_SIZE
	{
		/// <summary>A non-negative value that represents the object's size in the horizontal (x) dimension.</summary>
		public float width;

		/// <summary>A non-negative value that represents the object's size in the vertical (y) dimension.</summary>
		public float height;
	}
}