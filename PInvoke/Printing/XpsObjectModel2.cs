using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.InteropServices;
using static Vanara.PInvoke.Opc;
using static Vanara.PInvoke.UrlMon;

namespace Vanara.PInvoke;

public static partial class XpsObjectModel
{
	/// <summary>A collection of IXpsOMImageResource interface pointers.</summary>
	/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomimageresourcecollection
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "aed8b23e-71fd-49e6-aae9-006a59e0111b")]
	[ComImport, Guid("7A4A1A71-9CDE-4B71-B33F-62DE843EABFE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMImageResourceCollection
	{
		/// <summary>Gets the number of IXpsOMImageResource interface pointers in the collection.</summary>
		/// <returns>The number of IXpsOMImageResource interface pointers in the collection.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresourcecollection-getcount
		// HRESULT GetCount( UINT32 *count );
		[MethodImpl(MethodImplOptions.InternalCall)]
		uint GetCount();

		/// <summary>Gets an IXpsOMImageResource interface pointer from a specified location in the collection.</summary>
		/// <param name="index">The zero-based index of the IXpsOMImageResource interface pointer to be obtained.</param>
		/// <returns>The IXpsOMImageResource interface pointer at the location specified by index.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresourcecollection-getat
		// HRESULT GetAt( UINT32 index, IXpsOMImageResource **object );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMImageResource GetAt([In] uint index);

		/// <summary>Inserts an IXpsOMImageResource interface pointer at a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection where the interface pointer that is passed in object is to be inserted.
		/// </param>
		/// <param name="object">The IXpsOMImageResource interface pointer that will be inserted at the location specified by index.</param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method inserts the IXpsOMImageResource interface pointer that is passed in object.
		/// Prior to the insertion, the pointer in this and all subsequent locations is moved up by one index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresourcecollection-insertat
		// HRESULT InsertAt( UINT32 index, IXpsOMImageResource *object );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void InsertAt([In] uint index, [In] IXpsOMImageResource @object);

		/// <summary>Removes and releases an IXpsOMImageResource interface pointer from a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection from which an IXpsOMImageResource interface pointer is to be removed and released.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method releases the interface referenced by the pointer at the location specified by index. After releasing the
		/// interface, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresourcecollection-removeat
		// HRESULT RemoveAt( UINT32 index );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void RemoveAt([In] uint index);

		/// <summary>Replaces an IXpsOMImageResource interface pointer at a specified location in the collection.</summary>
		/// <param name="index">The zero-based index in the collection where an IXpsOMImageResource interface pointer is to be replaced.</param>
		/// <param name="object">
		/// The IXpsOMImageResource interface pointer that will replace current contents at the location specified by index.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method releases the IXpsOMImageResource interface referenced by the existing
		/// pointer, then writes the pointer that is passed in object.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresourcecollection-setat
		// HRESULT SetAt( UINT32 index, IXpsOMImageResource *object );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetAt([In] uint index, [In] IXpsOMImageResource @object);

		/// <summary>Appends an IXpsOMImageResource interface to the end of the collection.</summary>
		/// <param name="object">A pointer to the IXpsOMImageResource interface that is to be appended to the collection.</param>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresourcecollection-append
		// HRESULT Append( IXpsOMImageResource *object );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Append([In] IXpsOMImageResource @object);

		/// <summary>Gets an IXpsOMImageResource interface pointer from the collection by matching the interface's part name.</summary>
		/// <param name="partName">The part name of the interface that is to be found in the collection.</param>
		/// <returns>
		/// The IXpsOMImageResource interface whose part name matches partName. If a matching interface is not found in the collection,
		/// a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresourcecollection-getbypartname
		// HRESULT GetByPartName( IOpcPartUri *partName, IXpsOMImageResource **part );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMImageResource GetByPartName([In] IOpcPartUri partName);
	}

	/// <summary>Specifies a linear gradient, which is the color gradient along a vector.</summary>
	/// <remarks>
	/// <para>
	/// In the illustration that follows, the start and end points of a linear gradient are also the start and end points of the
	/// gradient path, which is the straight line that connects those points.
	/// </para>
	/// <para>
	/// The gradient region of a linear gradient is the area between and including the start and end points and extending in both
	/// directions at a right angle to the gradient path. The spread area is the area of the geometry that lies outside the gradient region.
	/// </para>
	/// <para>
	/// Gradient stops are used to define the color at specific locations along the gradient path. In the illustration, gradient stop 0
	/// is located at the start point of the gradient path, and gradient stop 1 is at the end point. The <c>XPS_SPREAD_METHOD_PAD</c>
	/// spread method is used to fill the spread area.
	/// </para>
	/// <para>The code example that follows illustrates how to create an instance of this interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomlineargradientbrush
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "739bf088-0f09-47c1-9b49-6c279395f15b")]
	[ComImport, Guid("005E279F-C30D-40FF-93EC-1950D3C528DB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMLinearGradientBrush : IXpsOMGradientBrush
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
		new IXpsOMGradientStopCollection GetGradientStops();

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
		new IXpsOMMatrixTransform GetTransform();

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
		new IXpsOMMatrixTransform GetTransformLocal();

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
		new void SetTransformLocal([In] IXpsOMMatrixTransform transform);

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
		new string GetTransformLookup();

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
		new void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

		/// <summary>Gets the XPS_SPREAD_METHOD value, which describes how the area outside of the gradient region will be rendered.</summary>
		/// <returns>
		/// The XPS_SPREAD_METHOD value that describes how the area outside of the gradient region will be rendered. The gradient region
		/// is defined by the linear-gradient brush or radial-gradient brush that inherits this interface.
		/// </returns>
		/// <remarks>For more information about different types of spread methods, see XPS_SPREAD_METHOD.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-getspreadmethod
		// HRESULT GetSpreadMethod( XPS_SPREAD_METHOD *spreadMethod );
		new XPS_SPREAD_METHOD GetSpreadMethod();

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
		new void SetSpreadMethod([In] XPS_SPREAD_METHOD spreadMethod);

		/// <summary>Gets the gamma function to be used for color interpolation.</summary>
		/// <returns>The XPS_COLOR_INTERPOLATION value that describes the gamma function to be used for color interpolation.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-getcolorinterpolationmode
		// HRESULT GetColorInterpolationMode( XPS_COLOR_INTERPOLATION *colorInterpolationMode );
		new XPS_COLOR_INTERPOLATION GetColorInterpolationMode();

		/// <summary>Sets the XPS_COLOR_INTERPOLATION value, which describes the gamma function to be used for color interpolation.</summary>
		/// <param name="colorInterpolationMode">
		/// The XPS_COLOR_INTERPOLATION value, which describes the gamma function to be used for color interpolation.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-setcolorinterpolationmode
		// HRESULT SetColorInterpolationMode( XPS_COLOR_INTERPOLATION colorInterpolationMode );
		new void SetColorInterpolationMode([In] XPS_COLOR_INTERPOLATION colorInterpolationMode);

		/// <summary>Gets the start point of the gradient.</summary>
		/// <returns>The x and y coordinates of the start point.</returns>
		/// <remarks>The coordinates are relative to the page and are expressed in the units of the transform that is in effect.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomlineargradientbrush-getstartpoint
		// HRESULT GetStartPoint( XPS_POINT *startPoint );
		XPS_POINT GetStartPoint();

		/// <summary>Sets the start point of the gradient.</summary>
		/// <param name="startPoint">The x and y coordinates of the start point.</param>
		/// <remarks>The coordinates are relative to the page and are expressed in the units of the transform that is in effect.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomlineargradientbrush-setstartpoint
		// HRESULT SetStartPoint( const XPS_POINT *startPoint );
		void SetStartPoint(in XPS_POINT startPoint);

		/// <summary>Gets the end point of the gradient.</summary>
		/// <returns>The x and y coordinates of the end point.</returns>
		/// <remarks>The coordinates are relative to the page and are expressed in units of the transform that is in effect.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomlineargradientbrush-getendpoint
		// HRESULT GetEndPoint( XPS_POINT *endPoint );
		XPS_POINT GetEndPoint();

		/// <summary>Sets the end point of the gradient.</summary>
		/// <param name="endPoint">The x and y coordinates of the end point.</param>
		/// <remarks>The coordinates are relative to the page and are expressed in the units of the transform that is in effect.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomlineargradientbrush-setendpoint
		// HRESULT SetEndPoint( const XPS_POINT *endPoint );
		void SetEndPoint(in XPS_POINT endPoint);

		/// <summary>Makes a deep copy of the interface.</summary>
		/// <returns>A pointer to the copy of the interface.</returns>
		/// <remarks>This method does not update any of the resource pointers in the copy.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomlineargradientbrush-clone HRESULT
		// Clone( IXpsOMLinearGradientBrush **linearGradientBrush );
		IXpsOMLinearGradientBrush Clone();
	}

	/// <summary>Specifies an affine matrix transform that can be applied to other objects in the object model.</summary>
	/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsommatrixtransform
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "d21457bc-9445-4ca2-ab9f-1e3f55e2e635")]
	[ComImport, Guid("B77330FF-BB37-4501-A93E-F1B1E50BFC46"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMMatrixTransform : IXpsOMShareable
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

		/// <summary>Gets the XPS_MATRIX structure, which specifies the transform matrix.</summary>
		/// <returns>The address of a variable that receives the XPS_MATRIX structure.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsommatrixtransform-getmatrix HRESULT
		// GetMatrix( XPS_MATRIX *matrix );
		XPS_MATRIX GetMatrix();

		/// <summary>Sets the XPS_MATRIX structure, which specifies the transform matrix.</summary>
		/// <param name="matrix">The address of the XPS_MATRIX structure.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsommatrixtransform-setmatrix HRESULT
		// SetMatrix( const XPS_MATRIX *matrix );
		void SetMatrix(in XPS_MATRIX matrix);

		/// <summary>Makes a deep copy of the interface.</summary>
		/// <returns>A pointer to the copy of the interface.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsommatrixtransform-clone HRESULT
		// Clone( IXpsOMMatrixTransform **matrixTransform );
		IXpsOMMatrixTransform Clone();
	}

	/// <summary>A collection of name strings.</summary>
	/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomnamecollection
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "b27f83fc-0fcf-44e9-a6ce-c3612c5399ff")]
	[ComImport, Guid("4BDDF8EC-C915-421B-A166-D173D25653D2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMNameCollection
	{
		/// <summary>Gets the number of name strings in the collection.</summary>
		/// <returns>The number of name strings in the collection.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomnamecollection-getcount HRESULT
		// GetCount( UINT32 *count );
		uint GetCount();

		/// <summary>Gets the name string that is stored at a specified location in the collection.</summary>
		/// <param name="index">The zero-based index of the collection that contains the name string to be obtained.</param>
		/// <returns>The name string at the location specified by index.</returns>
		/// <remarks>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomnamecollection-getat HRESULT GetAt(
		// UINT32 index, LPWSTR *name );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetAt([In] uint index);
	}

	/// <summary>Describes a non-text visual item.</summary>
	/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsompath
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "93257a77-3fef-400e-bfe1-06e760ba4b93")]
	[ComImport, Guid("37D38BB6-3EE9-4110-9312-14B194163337"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMPath : IXpsOMVisual
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

		/// <summary>Gets a pointer to the path's IXpsOMGeometry interface, which describes the resolved fill area for this path.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the path's IXpsOMGeometry interface, which describes the resolved fill area for this path. If a geometry has
		/// not been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the geometry.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in geometry</term>
		/// </listheader>
		/// <item>
		/// <term>SetGeometryLocal</term>
		/// <term>The local geometry that is set by SetGeometryLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetGeometryLookup</term>
		/// <term>
		/// The shared geometry retrieved, with a lookup key that matches the key that is set by SetGeometryLookup, from the resource directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Neither SetGeometryLocal nor SetGeometryLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getgeometry HRESULT
		// GetGeometry( IXpsOMGeometry **geometry );
		IXpsOMGeometry GetGeometry();

		/// <summary>Gets the local, unshared geometry of the resolved fill area for this path.</summary>
		/// <returns>
		/// <para>
		/// The local, unshared geometry of the resolved fill area for this path. If a geometry lookup key has been set or if a local
		/// geometry has not been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in geometry</term>
		/// </listheader>
		/// <item>
		/// <term>SetGeometryLocal</term>
		/// <term>The local geometry that is set by SetGeometryLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetGeometryLookup</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetGeometryLocal nor SetGeometryLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getgeometrylocal HRESULT
		// GetGeometryLocal( IXpsOMGeometry **geometry );
		IXpsOMGeometry GetGeometryLocal();

		/// <summary>
		/// Sets the pointer to the local, unshared IXpsOMGeometry interface that contains the geometry of the resolved fill area to be
		/// set for this path.
		/// </summary>
		/// <param name="geometry">
		/// The pointer to the local, unshared IXpsOMGeometry interface that contains the geometry of the resolved fill area to be set
		/// for this path.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetGeometryLocal</c>, the geometry lookup key is released and GetGeometryLookup returns a <c>NULL</c>
		/// pointer in the lookup parameter. The table that follows explains the relationship between the local and lookup values of
		/// this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in geometry by GetGeometry</term>
		/// <term>Object that is returned in geometry by GetGeometryLocal</term>
		/// <term>String that is returned in lookup by GetGeometryLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetGeometryLocal (this method)</term>
		/// <term>The local geometry that is set by SetGeometryLocal.</term>
		/// <term>The local geometry that is set by SetGeometryLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetGeometryLookup</term>
		/// <term>
		/// The shared geometry retrieved, with a lookup key that matches the key set by SetGeometryLookup, from the resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetGeometryLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetGeometryLocal nor SetGeometryLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-setgeometrylocal HRESULT
		// SetGeometryLocal( IXpsOMGeometry *geometry );
		void SetGeometryLocal([In] IXpsOMGeometry geometry);

		/// <summary>
		/// Gets the lookup key of a shared geometry object that is stored in a resource dictionary and that describes the resolved fill
		/// area for this path.
		/// </summary>
		/// <returns>
		/// <para>
		/// The lookup key of the geometry object that describes the resolved fill area for this path. If a geometry lookup key has not
		/// been set or if a local geometry has been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>String that is returned in lookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetGeometryLocal</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetGeometryLookup</term>
		/// <term>The lookup key that is set by SetGeometryLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetGeometryLocal nor SetGeometryLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getgeometrylookup HRESULT
		// GetGeometryLookup( LPWSTR *lookup );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetGeometryLookup();

		/// <summary>
		/// <para>Sets the lookup key name of a shared geometry in a resource dictionary.</para>
		/// <para>Here, the geometry describes the resolved fill area to be set for this path.</para>
		/// </summary>
		/// <param name="lookup">The lookup key name of a shared geometry in a resource dictionary.</param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetGeometryLookup</c>, the local geometry is released and SetGeometryLocal returns a <c>NULL</c> pointer
		/// in the geometry parameter. The table that follows explains the relationship between the local and lookup values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in geometry by GetGeometry</term>
		/// <term>Object that is returned in geometry by GetGeometryLocal</term>
		/// <term>String that is returned in lookup by GetGeometryLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetGeometryLocal</term>
		/// <term>The local geometry that is set by SetGeometryLocal.</term>
		/// <term>The local geometry that is set by SetGeometryLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetGeometryLookup (this method)</term>
		/// <term>
		/// The shared geometry retrieved, with a lookup key that matches the key that is set by SetGeometryLookup, from the resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetGeometryLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetGeometryLocal nor SetGeometryLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-setgeometrylookup HRESULT
		// SetGeometryLookup( LPCWSTR lookup );
		void SetGeometryLookup([In, MarshalAs(UnmanagedType.LPWStr)] string lookup);

		/// <summary>
		/// Gets the short textual description of the object's contents. This description is used by accessibility clients to describe
		/// the object.
		/// </summary>
		/// <returns>
		/// The short textual description of the object's contents. If this text has not been set, a <c>NULL</c> pointer will be returned.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The value that is returned in shortDescription is the value of the <c>AutomationProperties.Name</c> attribute of the
		/// <c>Path</c> element in the document markup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getaccessibilityshortdescription
		// HRESULT GetAccessibilityShortDescription( LPWSTR *shortDescription );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetAccessibilityShortDescription();

		/// <summary>
		/// Sets the short textual description of the object's contents. This description is used by accessibility clients to describe
		/// the object.
		/// </summary>
		/// <param name="shortDescription">The short textual description of the object's contents.</param>
		/// <remarks>
		/// In the document markup, the value that is set in shortDescription will be that of the <c>AutomationProperties.Name</c>
		/// attribute of the <c>Path</c> element.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-setaccessibilityshortdescription
		// HRESULT SetAccessibilityShortDescription( LPCWSTR shortDescription );
		void SetAccessibilityShortDescription([In, MarshalAs(UnmanagedType.LPWStr)] string shortDescription);

		/// <summary>
		/// Gets the long (detailed) textual description of the object's contents. This description is used by accessibility clients to
		/// describe the object.
		/// </summary>
		/// <returns>
		/// The detailed textual description of the object's contents. If this text has not been set, a <c>NULL</c> pointer will be returned.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The value returned in longDescription is the value of the <c>AutomationProperties.HelpText</c> attribute of the <c>Path</c>
		/// element in the document markup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getaccessibilitylongdescription
		// HRESULT GetAccessibilityLongDescription( LPWSTR *longDescription );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetAccessibilityLongDescription();

		/// <summary>
		/// Sets the long (detailed) textual description of the object's contents. This description is used by accessibility clients to
		/// describe the object.
		/// </summary>
		/// <param name="longDescription">The detailed textual description of the object's contents.</param>
		/// <remarks>
		/// In the document markup, the value that is set in longDescription will be that of the <c>AutomationProperties.HelpText</c>
		/// attribute of the <c>Path</c> element.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-setaccessibilitylongdescription
		// HRESULT SetAccessibilityLongDescription( LPCWSTR longDescription );
		void SetAccessibilityLongDescription([In, MarshalAs(UnmanagedType.LPWStr)] string longDescription);

		/// <summary>Gets a Boolean value that indicates whether the path is to be snapped to device pixels when the path is rendered.</summary>
		/// <returns>
		/// <para>
		/// A Boolean value that indicates whether the path is to be snapped to device pixels when the path is rendered. The following
		/// table describes the values possible for this parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The path is to be snapped to device pixels.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The path is not to be snapped to device pixels.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The value returned by <c>GetSnapsToPixels</c> corresponds to the <c>SnapsToDevicePixels</c> element in the document markup.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getsnapstopixels HRESULT
		// GetSnapsToPixels( BOOL *snapsToPixels );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetSnapsToPixels();

		/// <summary>
		/// Sets a Boolean value that indicates whether the path will be snapped to device pixels when that path is being rendered.
		/// </summary>
		/// <param name="snapsToPixels">
		/// <para>
		/// A Boolean value that indicates whether to snap the path to the device pixels when that path is being rendered. The following
		/// table describes the values possible for this parameter.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>Snap the path to the device pixels.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>Do not snap the path to the device pixels.</term>
		/// </item>
		/// </list>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-setsnapstopixels HRESULT
		// SetSnapsToPixels( BOOL snapsToPixels );
		void SetSnapsToPixels([In, MarshalAs(UnmanagedType.Bool)] bool snapsToPixels);

		/// <summary>
		/// Gets a pointer to the resolved IXpsOMBrush interface that contains the stroke brush that has been set for the path.
		/// </summary>
		/// <returns>
		/// <para>The stroke brush that has been set for the path. If a stroke brush has not been set, a <c>NULL</c> pointer is returned.</para>
		/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the brush.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in brush</term>
		/// </listheader>
		/// <item>
		/// <term>SetStrokeBrushLocal</term>
		/// <term>The local brush that is set by SetStrokeBrushLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetStrokeBrushLookup</term>
		/// <term>
		/// The shared brush retrieved, with a lookup key that matches the key that is set by SetStrokeBrushLookup, from the resource directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Neither SetStrokeBrushLocal nor SetStrokeBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getstrokebrush HRESULT
		// GetStrokeBrush( IXpsOMBrush **brush );
		IXpsOMBrush GetStrokeBrush();

		/// <summary>Gets a pointer to the local, unshared IXpsOMBrush interface that contains the stroke brush for the path.</summary>
		/// <returns>
		/// <para>
		/// The local, unshared IXpsOMBrush interface that contains the stroke brush for the path. If a stroke brush lookup key has been
		/// set or if a local stroke brush has not been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in brush</term>
		/// </listheader>
		/// <item>
		/// <term>SetStrokeBrushLocal</term>
		/// <term>The local brush that is set by SetStrokeBrushLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetStrokeBrushLookup</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetStrokeBrushLocal nor SetStrokeBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getstrokebrushlocal HRESULT
		// GetStrokeBrushLocal( IXpsOMBrush **brush );
		IXpsOMBrush GetStrokeBrushLocal();

		/// <summary>Sets a pointer to a local, unshared IXpsOMBrush interface to be used as a stroke brush.</summary>
		/// <param name="brush">A pointer to a local, unshared IXpsOMBrush interface to be used as a stroke brush.</param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetStrokeBrushLocal</c>, the stroke brush lookup key is released and GetStrokeBrushLookup returns a
		/// <c>NULL</c> pointer in the lookup parameter. The table that follows explains the relationship between the local and lookup
		/// values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in brush by GetStrokeBrush</term>
		/// <term>Object that is returned in brush by GetStrokeBrushLocal</term>
		/// <term>String that is returned in lookup by GetStrokeBrushLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetStrokeBrushLocal (this method)</term>
		/// <term>The local brush that is set by SetStrokeBrushLocal.</term>
		/// <term>The local brush that is set by SetStrokeBrushLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetStrokeBrushLookup</term>
		/// <term>
		/// The shared brush retrieved, with a lookup key that matches the key set by SetStrokeBrushLookup, from the resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetStrokeBrushLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetStrokeBrushLocal nor SetStrokeBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-setstrokebrushlocal HRESULT
		// SetStrokeBrushLocal( IXpsOMBrush *brush );
		void SetStrokeBrushLocal([In] IXpsOMBrush brush);

		/// <summary>
		/// Gets the lookup key of the brush that is stored in a resource dictionary and is to be used as the stroke brush for the path.
		/// </summary>
		/// <returns>
		/// <para>
		/// The lookup key of a brush that is stored in a resource dictionary. If a stroke brush lookup key has not been set or if a
		/// local stroke brush has been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>String that is returned in lookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetStrokeBrushLocal</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetStrokeBrushLookup</term>
		/// <term>The lookup key that is set by SetStrokeBrushLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetStrokeBrushLocal nor SetStrokeBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getstrokebrushlookup HRESULT
		// GetStrokeBrushLookup( LPWSTR *lookup );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetStrokeBrushLookup();

		/// <summary>
		/// Sets the lookup key name of a shared brush to be used as the stroke brush.The shared brush is stored in a resource dictionary.
		/// </summary>
		/// <param name="lookup">The lookup key name of a shared brush to be used as the stroke brush for the path.</param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetStrokeBrushLookup</c>, the local stroke brush is released and GetStrokeBrushLocal returns a <c>NULL</c>
		/// pointer in the brush parameter. The table that follows explains the relationship between the local and lookup values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in brush by GetStrokeBrush</term>
		/// <term>Object that is returned in brush by GetStrokeBrushLocal</term>
		/// <term>String that is returned in lookup by GetStrokeBrushLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetStrokeBrushLocal</term>
		/// <term>The local brush that is set by SetStrokeBrushLocal.</term>
		/// <term>The local brush that is set by SetStrokeBrushLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetStrokeBrushLookup(this method)</term>
		/// <term>
		/// The shared brush retrieved, with a lookup key that matches the key that is set by SetStrokeBrushLookup, from the resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetStrokeBrushLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetStrokeBrushLocal nor SetStrokeBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-setstrokebrushlookup HRESULT
		// SetStrokeBrushLookup( LPCWSTR lookup );
		void SetStrokeBrushLookup([In, MarshalAs(UnmanagedType.LPWStr)] string lookup);

		/// <summary>
		/// Gets a pointer to the IXpsOMDashCollection interface that contains the XPS_DASH structures that define the dash pattern of
		/// the stroke.
		/// </summary>
		/// <returns>
		/// A pointer to the IXpsOMDashCollection interface that contains the XPS_DASH structures that define the dash pattern of the stroke.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getstrokedashes HRESULT
		// GetStrokeDashes( IXpsOMDashCollection **strokeDashes );
		IXpsOMDashCollection GetStrokeDashes();

		/// <summary>Gets the style of the end cap to be used on the stroke dash.</summary>
		/// <returns>The XPS_DASH_CAP value that describes the style of the end cap to be used on the stroke dash.</returns>
		/// <remarks>For more information about dash cap styles, see XPS_DASH_CAP.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getstrokedashcap HRESULT
		// GetStrokeDashCap( XPS_DASH_CAP *strokeDashCap );
		XPS_DASH_CAP GetStrokeDashCap();

		/// <summary>Sets the style of the stroke's dash cap.</summary>
		/// <param name="strokeDashCap">The XPS_DASH_CAP value to be set.</param>
		/// <remarks>For more information about dash cap styles, see XPS_DASH_CAP.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-setstrokedashcap HRESULT
		// SetStrokeDashCap( XPS_DASH_CAP strokeDashCap );
		void SetStrokeDashCap([In] XPS_DASH_CAP strokeDashCap);

		/// <summary>Gets the offset from the origin of the stroke to the starting point of the dash array pattern.</summary>
		/// <returns>The offset value; specified in multiples of the stroke thickness.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getstrokedashoffset HRESULT
		// GetStrokeDashOffset( FLOAT *strokeDashOffset );
		float GetStrokeDashOffset();

		/// <summary>Sets the offset from the origin of the stroke to the starting point of the dash array pattern.</summary>
		/// <returns>The offset value to be set.</returns>
		/// <remarks>
		/// The offset describes the distance from the origin of the stroke where the dash starts, and is specified in multiples of the
		/// stroke thickness.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-setstrokedashoffset HRESULT
		// SetStrokeDashOffset( FLOAT strokeDashOffset );
		void SetStrokeDashOffset([In] float strokeDashOffset);

		/// <summary>Gets the style of the line cap at the start of the stroke line.</summary>
		/// <returns>The XPS_LINE_CAP value that indicates the style of the line cap at the start of the stroke line.</returns>
		/// <remarks>For more information about the shapes of line caps, see XPS_LINE_CAP.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getstrokestartlinecap HRESULT
		// GetStrokeStartLineCap( XPS_LINE_CAP *strokeStartLineCap );
		XPS_LINE_CAP GetStrokeStartLineCap();

		/// <summary>Sets the style of the stroke's line cap at the start of the stroke line.</summary>
		/// <param name="strokeStartLineCap">The XPS_LINE_CAP value to be set.</param>
		/// <remarks>For more information about the line join styles, see XPS_LINE_CAP.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-setstrokestartlinecap HRESULT
		// SetStrokeStartLineCap( XPS_LINE_CAP strokeStartLineCap );
		void SetStrokeStartLineCap([In] XPS_LINE_CAP strokeStartLineCap);

		/// <summary>Gets the style of the stroke line's end cap.</summary>
		/// <returns>The XPS_LINE_CAP value that specifies the style of the stroke line's end cap.</returns>
		/// <remarks>For more information about line end cap styles, see XPS_LINE_CAP.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getstrokeendlinecap HRESULT
		// GetStrokeEndLineCap( XPS_LINE_CAP *strokeEndLineCap );
		XPS_LINE_CAP GetStrokeEndLineCap();

		/// <summary>Sets the style of the stroke line's end cap.</summary>
		/// <param name="strokeEndLineCap">The XPS_LINE_CAP value to be set.</param>
		/// <remarks>For more information about dash cap styles, see XPS_LINE_CAP.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-setstrokeendlinecap HRESULT
		// SetStrokeEndLineCap( XPS_LINE_CAP strokeEndLineCap );
		void SetStrokeEndLineCap([In] XPS_LINE_CAP strokeEndLineCap);

		/// <summary>Gets the style for joining stroke lines.</summary>
		/// <returns>The XPS_LINE_JOIN value of the line join style of the stroke.</returns>
		/// <remarks>For more information about the line join styles, see XPS_LINE_JOIN.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getstrokelinejoin HRESULT
		// GetStrokeLineJoin( XPS_LINE_JOIN *strokeLineJoin );
		XPS_LINE_JOIN GetStrokeLineJoin();

		/// <summary>Sets the style for joining stroke lines.</summary>
		/// <param name="strokeLineJoin">The XPS_LINE_JOIN value to be set.</param>
		/// <remarks>For more information about the line join styles, see XPS_LINE_JOIN.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-setstrokelinejoin HRESULT
		// SetStrokeLineJoin( XPS_LINE_JOIN strokeLineJoin );
		void SetStrokeLineJoin([In] XPS_LINE_JOIN strokeLineJoin);

		/// <summary>Gets the miter limit value that is set for the stroke.</summary>
		/// <returns>The miter limit value that is set for the stroke.</returns>
		/// <remarks>
		/// <para>The miter limit value is the ratio of the maximum miter length to one-half of the stroke thickness.</para>
		/// <para>
		/// The miter limit value describes how to render a mitered line join; this value applies only if the line join style value is XPS_LINE_JOIN_MITER.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getstrokemiterlimit HRESULT
		// GetStrokeMiterLimit( FLOAT *strokeMiterLimit );
		float GetStrokeMiterLimit();

		/// <summary>Sets the miter limit of the path.</summary>
		/// <param name="strokeMiterLimit">The miter limit value to be set. The value must be 1.0 or greater.</param>
		/// <remarks>
		/// <para>The miter limit value is the ratio of the maximum miter length to one-half of the stroke thickness.</para>
		/// <para>
		/// The miter limit value describes how to render a mitered line join. This value applies only if the line join style value is XPS_LINE_JOIN_MITER.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-setstrokemiterlimit HRESULT
		// SetStrokeMiterLimit( FLOAT strokeMiterLimit );
		void SetStrokeMiterLimit([In] float strokeMiterLimit);

		/// <summary>Gets the stroke thickness.</summary>
		/// <returns>The stroke thickness value.</returns>
		/// <remarks>
		/// <para>
		/// The value returned in strokeThickness specifies the thickness of a stroke in units of the effective coordinate space. The
		/// units include the path's render transform.
		/// </para>
		/// <para>
		/// The stroke is drawn on top of the boundary of the path's geometry, such that one half of the stroke's width extends outside
		/// of the path's specified geometry and the other half falls inside of it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getstrokethickness HRESULT
		// GetStrokeThickness( FLOAT *strokeThickness );
		float GetStrokeThickness();

		/// <summary>Sets the stroke thickness.</summary>
		/// <param name="strokeThickness">The stroke thickness value to be set; must be 0.0 or greater.</param>
		/// <remarks>
		/// <para>
		/// The value returned in strokeThickness specifies the thickness of a stroke in units of the effective coordinate space; the
		/// units include the path's render transform.
		/// </para>
		/// <para>
		/// The stroke is drawn on top of the boundary of the path's geometry, such that one half of the stroke's width extends outside
		/// of the path's specified geometry and the other half falls inside of it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-setstrokethickness HRESULT
		// SetStrokeThickness( FLOAT strokeThickness );
		void SetStrokeThickness([In] float strokeThickness);

		/// <summary>Gets a pointer to the resolved IXpsOMBrush interface that contains the fill brush for the path.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the resolved IXpsOMBrush interface that contains the fill brush for the path. If a fill brush has not been set,
		/// a <c>NULL</c> pointer is returned.
		/// </para>
		/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the brush.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in brush</term>
		/// </listheader>
		/// <item>
		/// <term>SetFillBrushLocal</term>
		/// <term>The local brush that is set by SetFillBrushLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetFillBrushLookup</term>
		/// <term>
		/// The shared brush retrieved, with a lookup key that matches the key that is set by SetFillBrushLookup, from the resource directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Neither SetFillBrushLocal nor SetFillBrushLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getfillbrush HRESULT
		// GetFillBrush( IXpsOMBrush **brush );
		IXpsOMBrush GetFillBrush();

		/// <summary>Gets a pointer to the local, unshared IXpsOMBrush interface that contains the fill brush for the path.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMBrush interface to be used as the local, unshared fill brush for the path. If a fill brush lookup key
		/// has been set or if a local fill brush has not been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the brush.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in brush</term>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getfillbrushlocal HRESULT
		// GetFillBrushLocal( IXpsOMBrush **brush );
		IXpsOMBrush GetFillBrushLocal();

		/// <summary>Sets the pointer to the local, unshared IXpsOMBrush interface to be used as the fill brush.</summary>
		/// <param name="brush">A pointer to the local, unshared IXpsOMBrush interface to be used as the fill brush.</param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetFillBrushLocal</c>, the fill brush lookup key is released and GetFillBrushLookup returns a <c>NULL</c>
		/// pointer in the lookup parameter. The table that follows explains the relationship between the local and lookup values of
		/// this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in brush by GetFillBrush</term>
		/// <term>Object that is returned in brush by GetFillBrushLocal</term>
		/// <term>String that is returned in lookup by GetFillBrushLookup</term>
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
		/// The shared brush retrieved, with a lookup key that matches the key that is set by SetFillBrushLookup, from the resource directory.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-setfillbrushlocal HRESULT
		// SetFillBrushLocal( IXpsOMBrush *brush );
		void SetFillBrushLocal([In] IXpsOMBrush brush);

		/// <summary>
		/// Gets the lookup key of the brush that is stored in a resource dictionary and used as the fill brush for the path.
		/// </summary>
		/// <returns>
		/// <para>
		/// The lookup key for the fill brush that is stored in a resource dictionary. If the lookup key has not been set or if a local
		/// fill brush has been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>String that is returned in lookup</term>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-getfillbrushlookup HRESULT
		// GetFillBrushLookup( LPWSTR *lookup );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetFillBrushLookup();

		/// <summary>Sets the lookup key name of a shared brush in a resource dictionary, to be used as the fill brush.</summary>
		/// <param name="lookup">The key name of the brush in a resource dictionary, to be used as the fill brush.</param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetFillBrushLookup</c>, the local fill brush is released and GetFillBrushLocal returns a <c>NULL</c>
		/// pointer in the brush parameter. The table that follows explains the relationship between the local and lookup values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in brush by GetFillBrush</term>
		/// <term>Object that is returned in brush by GetFillBrushLocal</term>
		/// <term>String that is returned in lookup by GetFillBrushLookup</term>
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
		/// The shared brush retrieved, with a lookup key that matches the key that is set by SetFillBrushLookup, from the resource directory.
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
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-setfillbrushlookup HRESULT
		// SetFillBrushLookup( LPCWSTR lookup );
		void SetFillBrushLookup([In, MarshalAs(UnmanagedType.LPWStr)] string lookup);

		/// <summary>Makes a deep copy of the interface.</summary>
		/// <returns>A pointer to the copy of the interface.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompath-clone HRESULT Clone(
		// IXpsOMPath **path );
		IXpsOMPath Clone();
	}

	/// <summary>Provides an IStream interface to a <c>PrintTicket</c> resource.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomprintticketresource
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "2f37dbd2-3078-4aa8-97e7-556a0ff2dd74")]
	[ComImport, Guid("E7FF32D2-34AA-499B-BBE9-9CD4EE6C59F7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMPrintTicketResource : IXpsOMResource
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
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomprintticketresource-getstream
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
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomprintticketresource-setcontent
		// HRESULT SetContent( IStream *sourceStream, IOpcPartUri *partName );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetContent([In] IStream sourceStream, [In] IOpcPartUri partName);
	}

	/// <summary>Specifies a radial gradient.</summary>
	/// <remarks>
	/// <para>
	/// As shown in the figure that follows, the gradient region of a radial gradient is the area enclosed by the ellipse that is
	/// described by the center point and the x and y radii that extend from the center point. The spread area is the area outside of
	/// that ellipse. The gradient path (not shown) is a radial line that is drawn between the gradient origin and the ellipse that
	/// bounds the gradient region.
	/// </para>
	/// <para>The code example that follows illustrates how to create an instance of this interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomradialgradientbrush
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "2f5b7b99-64a0-4156-8963-cfceb0d73503")]
	[ComImport, Guid("75F207E5-08BF-413C-96B1-B82B4064176B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMRadialGradientBrush : IXpsOMGradientBrush
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
		new IXpsOMGradientStopCollection GetGradientStops();

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
		new IXpsOMMatrixTransform GetTransform();

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
		new IXpsOMMatrixTransform GetTransformLocal();

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
		new void SetTransformLocal([In] IXpsOMMatrixTransform transform);

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
		new string GetTransformLookup();

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
		new void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

		/// <summary>Gets the XPS_SPREAD_METHOD value, which describes how the area outside of the gradient region will be rendered.</summary>
		/// <returns>
		/// The XPS_SPREAD_METHOD value that describes how the area outside of the gradient region will be rendered. The gradient region
		/// is defined by the linear-gradient brush or radial-gradient brush that inherits this interface.
		/// </returns>
		/// <remarks>For more information about different types of spread methods, see XPS_SPREAD_METHOD.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-getspreadmethod
		// HRESULT GetSpreadMethod( XPS_SPREAD_METHOD *spreadMethod );
		new XPS_SPREAD_METHOD GetSpreadMethod();

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
		new void SetSpreadMethod([In] XPS_SPREAD_METHOD spreadMethod);

		/// <summary>Gets the gamma function to be used for color interpolation.</summary>
		/// <returns>The XPS_COLOR_INTERPOLATION value that describes the gamma function to be used for color interpolation.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-getcolorinterpolationmode
		// HRESULT GetColorInterpolationMode( XPS_COLOR_INTERPOLATION *colorInterpolationMode );
		new XPS_COLOR_INTERPOLATION GetColorInterpolationMode();

		/// <summary>Sets the XPS_COLOR_INTERPOLATION value, which describes the gamma function to be used for color interpolation.</summary>
		/// <param name="colorInterpolationMode">
		/// The XPS_COLOR_INTERPOLATION value, which describes the gamma function to be used for color interpolation.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-setcolorinterpolationmode
		// HRESULT SetColorInterpolationMode( XPS_COLOR_INTERPOLATION colorInterpolationMode );
		new void SetColorInterpolationMode([In] XPS_COLOR_INTERPOLATION colorInterpolationMode);

		/// <summary>Gets the center point of the radial gradient region ellipse.</summary>
		/// <returns>The x and y coordinates of the center point of the radial gradient region ellipse.</returns>
		/// <remarks>
		/// <para>
		/// The x and y coordinates that are specified in center are relative to the page and are expressed in units of the transform
		/// that is in effect.
		/// </para>
		/// <para>
		/// The following illustration shows the parts of a radial gradient. center gets the location of the center point of the ellipse
		/// that bounds the radial gradient region. For a more detailed description of this diagram, see IXpsOMRadialGradientBrush.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomradialgradientbrush-getcenter
		// HRESULT GetCenter( XPS_POINT *center );
		XPS_POINT GetCenter();

		/// <summary>Sets the center point of the radial gradient region ellipse.</summary>
		/// <param name="center">The x and y coordinates to be set for the center point of the radial gradient ellipse.</param>
		/// <remarks>
		/// <para>
		/// The x and y coordinates that are specified in center are relative to the page and are expressed in units of the transform
		/// that is in effect.
		/// </para>
		/// <para>
		/// The following illustration shows the parts of a radial gradient. center sets the location of the center point. For a more
		/// detailed description of this diagram, see IXpsOMRadialGradientBrush.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomradialgradientbrush-setcenter
		// HRESULT SetCenter( const XPS_POINT *center );
		void SetCenter(in XPS_POINT center);

		/// <summary>Gets the sizes of the radii that define the ellipse of the radial gradient region.</summary>
		/// <returns>
		/// <para>The XPS_SIZE structure that receives the sizes of the radii.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Field</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>width</term>
		/// <term>Size of the radius along the x-axis.</term>
		/// </item>
		/// <item>
		/// <term>height</term>
		/// <term>Size of the radius along the y-axis.</term>
		/// </item>
		/// </list>
		/// <para>Size is described in XPS units. There are 96 XPS units per inch. For example, a 1" radius is 96 XPS units.</para>
		/// </returns>
		/// <remarks>
		/// The following illustration shows the parts of a radial gradient. radiiSizes.width gets the x-radius, and radiiSizes.height
		/// the y-radius. For a more detailed description of this diagram, see IXpsOMRadialGradientBrush.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomradialgradientbrush-getradiisizes
		// HRESULT GetRadiiSizes( XPS_SIZE *radiiSizes );
		XPS_SIZE GetRadiiSizes();

		/// <summary>Sets the sizes of the radii that define ellipse of the radial gradient region.</summary>
		/// <param name="radiiSizes">
		/// <para>The XPS_SIZE structure that receives the sizes of the radii.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Field</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>width</term>
		/// <term>Size of the radius along the x-axis.</term>
		/// </item>
		/// <item>
		/// <term>height</term>
		/// <term>Size of the radius along the y-axis.</term>
		/// </item>
		/// </list>
		/// <para>Size is described in XPS units. There are 96 XPS units per inch. For example, a 1" radius is 96 XPS units.</para>
		/// </param>
		/// <remarks>
		/// The following illustration identifies the parts of a radial gradient. radiiSizes.width sets the x-radius, and
		/// radiiSizes.height the y-radius. For a more detailed description of this diagram, see IXpsOMRadialGradientBrush.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomradialgradientbrush-setradiisizes
		// HRESULT SetRadiiSizes( const XPS_SIZE *radiiSizes );
		void SetRadiiSizes(in XPS_SIZE radiiSizes);

		/// <summary>Gets the origin point of the radial gradient.</summary>
		/// <returns>The x and y coordinates of the radial gradient's origin point.</returns>
		/// <remarks>
		/// <para>
		/// The x and y coordinates that are specified in origin are relative to the page and are expressed in units of the transform
		/// that is in effect.
		/// </para>
		/// <para>
		/// The following illustration shows the parts of a radial gradient. origin gets the location of the gradient origin. For a more
		/// detailed description of this diagram, see IXpsOMRadialGradientBrush.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomradialgradientbrush-getgradientorigin
		// HRESULT GetGradientOrigin( XPS_POINT *origin );
		XPS_POINT GetGradientOrigin();

		/// <summary>Sets the origin point of the radial gradient.</summary>
		/// <param name="origin">The x and y coordinates to be set for the origin point of the radial gradient.</param>
		/// <remarks>
		/// <para>
		/// The x and y coordinates that are specified in origin are relative to the page and are expressed in units of the transform
		/// that is in effect.
		/// </para>
		/// <para>
		/// The following illustration shows the parts of a radial gradient. origin sets the location of the radial gradient's origin.
		/// For a more detailed description of this diagram, see IXpsOMRadialGradientBrush.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomradialgradientbrush-setgradientorigin
		// HRESULT SetGradientOrigin( const XPS_POINT *origin );
		void SetGradientOrigin(in XPS_POINT origin);

		/// <summary>Makes a deep copy of the interface.</summary>
		/// <returns>A pointer to the copy of the interface.</returns>
		/// <remarks>This method does not update any of the resource pointers in the new IXpsOMRadialGradientBrush interface.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomradialgradientbrush-clone HRESULT
		// Clone( IXpsOMRadialGradientBrush **radialGradientBrush );
		IXpsOMRadialGradientBrush Clone();
	}

	/// <summary>Provides an interface that enables pages in an XPS package to share resources.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomremotedictionaryresource
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "dd757856-f16e-46ad-b865-8203c3428372")]
	[ComImport, Guid("C9BD7CD4-E16A-4BF8-8C84-C950AF7A3061"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMRemoteDictionaryResource : IXpsOMResource
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

		/// <summary>Gets a pointer to the IXpsOMDictionary interface of the remote dictionary that is associated with this resource.</summary>
		/// <returns>A pointer to the IXpsOMDictionary interface of the dictionary that is associated with this resource.</returns>
		/// <remarks>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomremotedictionaryresource-getdictionary
		// HRESULT GetDictionary( IXpsOMDictionary **dictionary );
		IXpsOMDictionary GetDictionary();

		/// <summary>
		/// Sets a pointer to the IXpsOMDictionary interface of the remote dictionary that is to be associated with this resource.
		/// </summary>
		/// <param name="dictionary">The IXpsOMDictionary interface of the dictionary that is to be associated with this resource.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomremotedictionaryresource-setdictionary
		// HRESULT SetDictionary( IXpsOMDictionary *dictionary );
		void SetDictionary([In] IXpsOMDictionary dictionary);
	}

	/// <summary>A collection of IXpsOMRemoteDictionaryResource interface pointers.</summary>
	/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomremotedictionaryresourcecollection
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "50c9bd7a-226f-4785-96b4-d0b5e861ae37")]
	[ComImport, Guid("5C38DB61-7FEC-464A-87BD-41E3BEF018BE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMRemoteDictionaryResourceCollection
	{
		/// <summary>Gets the number of IXpsOMRemoteDictionaryResource interface pointers in the collection.</summary>
		/// <returns>The number of IXpsOMRemoteDictionaryResource interface pointers in the collection.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomremotedictionaryresourcecollection-getcount
		// HRESULT GetCount( UINT32 *count );
		uint GetCount();

		/// <summary>Gets an IXpsOMRemoteDictionaryResource interface pointer from a specified location in the collection.</summary>
		/// <param name="index">The zero-based index of the IXpsOMRemoteDictionaryResource interface pointer to be obtained.</param>
		/// <returns>The IXpsOMRemoteDictionaryResource interface pointer at the location specified by index.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomremotedictionaryresourcecollection-getat
		// HRESULT GetAt( UINT32 index, IXpsOMRemoteDictionaryResource **object );
		IXpsOMRemoteDictionaryResource GetAt([In] uint index);

		/// <summary>Inserts an IXpsOMRemoteDictionaryResource interface pointer at a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection where the interface pointer that is passed in object is to be inserted.
		/// </param>
		/// <param name="object">
		/// The IXpsOMRemoteDictionaryResource interface pointer that is to be inserted at the location specified by index.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method inserts the IXpsOMRemoteDictionaryResource interface pointer that is passed
		/// in object. Prior to the insertion, the pointer in this and all subsequent locations is moved up by one index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomremotedictionaryresourcecollection-insertat
		// HRESULT InsertAt( UINT32 index, IXpsOMRemoteDictionaryResource *object );
		void InsertAt([In] uint index, [In] IXpsOMRemoteDictionaryResource @object);

		/// <summary>Removes and releases an IXpsOMRemoteDictionaryResource interface pointer from a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection from which an IXpsOMRemoteDictionaryResource interface pointer is to be removed and released.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method releases the interface referenced by the pointer at the location specified by index. After releasing the
		/// interface, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomremotedictionaryresourcecollection-removeat
		// HRESULT RemoveAt( UINT32 index );
		void RemoveAt([In] uint index);

		/// <summary>Replaces an IXpsOMRemoteDictionaryResource interface pointer at a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection where an IXpsOMRemoteDictionaryResource interface pointer is to be replaced.
		/// </param>
		/// <param name="object">
		/// The IXpsOMRemoteDictionaryResource interface pointer that will replace current contents at the location specified by index.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method releases the IXpsOMRemoteDictionaryResource interface referenced by the
		/// existing pointer, then writes the pointer that is passed in object.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomremotedictionaryresourcecollection-setat
		// HRESULT SetAt( UINT32 index, IXpsOMRemoteDictionaryResource *object );
		void SetAt([In] uint index, [In] IXpsOMRemoteDictionaryResource @object);

		/// <summary>Appends an IXpsOMRemoteDictionaryResource interface to the end of the collection.</summary>
		/// <param name="object">A pointer to the IXpsOMRemoteDictionaryResource interface that is to be appended to the collection.</param>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomremotedictionaryresourcecollection-append
		// HRESULT Append( IXpsOMRemoteDictionaryResource *object );
		void Append([In] IXpsOMRemoteDictionaryResource @object);

		/// <summary>
		/// Gets an IXpsOMRemoteDictionaryResource interface pointer from the collection by matching the interface's part name.
		/// </summary>
		/// <param name="partName">The part name of the IXpsOMRemoteDictionaryResource interface to be found in the collection.</param>
		/// <returns>
		/// A pointer to the IXpsOMRemoteDictionaryResource interface whose part name matches partName. If a matching interface is not
		/// found in the collection, a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomremotedictionaryresourcecollection-getbypartname
		// HRESULT GetByPartName( IOpcPartUri *partName, IXpsOMRemoteDictionaryResource **remoteDictionaryResource );
		IXpsOMRemoteDictionaryResource GetByPartName([In] IOpcPartUri partName);
	}

	/// <summary>Used as the base interface for the resource interfaces of the XPS object model.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomresource
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "ed3d6ea0-efe5-4917-85fa-bd9ad1978b4e")]
	[ComImport, Guid("DA2AC0A2-73A2-4975-AD14-74097C3FF3A5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMResource : IXpsOMPart
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
	}

	/// <summary>The base interface for sharable interfaces.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomshareable
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "2071292f-b898-4ec8-99f7-294c8d820965")]
	[ComImport, Guid("7137398F-2FC1-454D-8C6A-2C3115A16ECE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMShareable
	{
		/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
		/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner HRESULT
		// GetOwner( IUnknown **owner );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object GetOwner();

		/// <summary>Gets the object type of the interface.</summary>
		/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype HRESULT GetType(
		// XPS_OBJECT_TYPE *type );
		XPS_OBJECT_TYPE GetType();
	}

	/// <summary>Provides an IStream interface to a signature block resource.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomsignatureblockresource
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "f5052470-487d-4f47-8d42-70538a4a45a8")]
	[ComImport, Guid("4776AD35-2E04-4357-8743-EBF6C171A905"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMSignatureBlockResource : IXpsOMResource
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
		/// A pointer to the IXpsOMDocument interface that contains the resource. If the resource is not part of a document, a
		/// <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomsignatureblockresource-getowner
		// HRESULT GetOwner( IXpsOMDocument **owner );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMDocument GetOwner();

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
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomsignatureblockresource-getstream
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
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomsignatureblockresource-setcontent
		// HRESULT SetContent( IStream *sourceStream, IOpcPartUri *partName );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetContent([In] IStream sourceStream, [In] IOpcPartUri partName);
	}

	/// <summary>A collection of IXpsOMSignatureBlockResource interface pointers.</summary>
	/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomsignatureblockresourcecollection
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "681bdb9c-69dd-4bf6-a4b3-c490f7a0363e")]
	[ComImport, Guid("AB8F5D8E-351B-4D33-AAED-FA56F0022931"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMSignatureBlockResourceCollection
	{
		/// <summary>Gets the number of IXpsOMSignatureBlockResource interface pointers in the collection.</summary>
		/// <returns>The number of IXpsOMSignatureBlockResource interface pointers in the collection.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomsignatureblockresourcecollection-getcount
		// HRESULT GetCount( UINT32 *count );
		uint GetCount();

		/// <summary>Gets an IXpsOMSignatureBlockResource interface pointer from a specified location in the collection.</summary>
		/// <param name="index">The zero-based index of the IXpsOMSignatureBlockResource interface pointer to be obtained.</param>
		/// <returns>The IXpsOMSignatureBlockResource interface pointer at the location specified by index.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomsignatureblockresourcecollection-getat
		// HRESULT GetAt( UINT32 index, IXpsOMSignatureBlockResource **signatureBlockResource );
		IXpsOMSignatureBlockResource GetAt([In] uint index);

		/// <summary>Inserts an IXpsOMSignatureBlockResource interface pointer at a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection where the interface pointer that is passed in signatureBlockResource is to be inserted.
		/// </param>
		/// <param name="signatureBlockResource">
		/// The IXpsOMSignatureBlockResource interface pointer that is to be inserted at the location specified by index.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method inserts the IXpsOMSignatureBlockResource interface pointer that is passed in
		/// signatureBlockResource. Prior to the insertion, the pointer in this and all subsequent locations is moved up by one index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomsignatureblockresourcecollection-insertat
		// HRESULT InsertAt( UINT32 index, IXpsOMSignatureBlockResource *signatureBlockResource );
		void InsertAt([In] uint index, [In] IXpsOMSignatureBlockResource signatureBlockResource);

		/// <summary>Removes and releases an IXpsOMSignatureBlockResource interface pointer from a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection from which an IXpsOMSignatureBlockResource interface pointer is to be removed and released.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method releases the interface referenced by the pointer at the location specified by index. After releasing the
		/// interface, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomsignatureblockresourcecollection-removeat
		// HRESULT RemoveAt( UINT32 index );
		void RemoveAt([In] uint index);

		/// <summary>Replaces an IXpsOMSignatureBlockResource interface pointer at a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection where an IXpsOMSignatureBlockResource interface pointer is to be replaced.
		/// </param>
		/// <param name="signatureBlockResource">
		/// The IXpsOMSignatureBlockResource interface pointer that will replace current contents at the location specified by index.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method releases the IXpsOMSignatureBlockResource interface referenced by the
		/// existing pointer, then writes the pointer that is passed in signatureBlockResource.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomsignatureblockresourcecollection-setat
		// HRESULT SetAt( UINT32 index, IXpsOMSignatureBlockResource *signatureBlockResource );
		void SetAt([In] uint index, [In] IXpsOMSignatureBlockResource signatureBlockResource);

		/// <summary>Appends an IXpsOMSignatureBlockResource interface to the end of the collection.</summary>
		/// <param name="signatureBlockResource">
		/// A pointer to the IXpsOMSignatureBlockResource interface that is to be appended to the collection.
		/// </param>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomsignatureblockresourcecollection-append
		// HRESULT Append( IXpsOMSignatureBlockResource *signatureBlockResource );
		void Append([In] IXpsOMSignatureBlockResource signatureBlockResource);

		/// <summary>
		/// Gets an IXpsOMSignatureBlockResource interface pointer from the collection by matching the interface's part name.
		/// </summary>
		/// <param name="partName">The part name of the IXpsOMSignatureBlockResource interface to be found in the collection.</param>
		/// <returns>
		/// A pointer to the IXpsOMSignatureBlockResource interface whose part name matches partName. If a matching interface is not
		/// found in the collection, a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomsignatureblockresourcecollection-getbypartname
		// HRESULT GetByPartName( IOpcPartUri *partName, IXpsOMSignatureBlockResource **signatureBlockResource );
		IXpsOMSignatureBlockResource GetByPartName([In] IOpcPartUri partName);
	}

	/// <summary>A single-color brush.</summary>
	/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomsolidcolorbrush
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "26580a25-09d1-4a9b-85c3-aa8ddcc97867")]
	[ComImport, Guid("A06F9F05-3BE9-4763-98A8-094FC672E488"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMSolidColorBrush : IXpsOMBrush
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

		/// <summary>Gets the color value and color profile of the brush.</summary>
		/// <param name="color">The color value of the brush.</param>
		/// <returns>
		/// <para>The color profile of the brush.</para>
		/// <para>If no color profile has been specified for the brush, a <c>NULL</c> pointer is returned.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomsolidcolorbrush-getcolor HRESULT
		// GetColor( XPS_COLOR *color, IXpsOMColorProfileResource **colorProfile );
		IXpsOMColorProfileResource GetColor(out XPS_COLOR color);

		/// <summary>Sets the color value and color profile of the brush.</summary>
		/// <param name="color">
		/// <para>The color value of the brush.</para>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomsolidcolorbrush-setcolor HRESULT
		// SetColor( const XPS_COLOR *color, IXpsOMColorProfileResource *colorProfile );
		void SetColor(in XPS_COLOR color, [In] IXpsOMColorProfileResource colorProfile);

		/// <summary>Makes a deep copy of the interface.</summary>
		/// <returns>A pointer to the copy of the interface.</returns>
		/// <remarks>This method does not update any of the resource pointers in the copy.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomsolidcolorbrush-clone HRESULT
		// Clone( IXpsOMSolidColorBrush **solidColorBrush );
		IXpsOMSolidColorBrush Clone();
	}

	/// <summary>Provides access to the content of the resource stream of a page's StoryFragments part.</summary>
	/// <remarks>
	/// <para>
	/// The StoryFragments part of a page contains the XML markup that describes the portions of one or more stories that are associated
	/// with a single fixed page. Some of the document contents that might be described by the XML markup in a StoryFragments part
	/// include the story's tables and paragraphs that are found on the page.
	/// </para>
	/// <para>The XML markup of the DocumentStructure and StoryFragments parts is described in the XML Paper Specification.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomstoryfragmentsresource
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "83bc8017-c679-40a8-96a8-bff9aa2273af")]
	[ComImport, Guid("C2B3CA09-0473-4282-87AE-1780863223F0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMStoryFragmentsResource : IXpsOMResource
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

		/// <summary>Gets a pointer to the IXpsOMPage interface that contains this resource.</summary>
		/// <returns>
		/// A pointer to the IXpsOMPage interface that contains this resource. If the resource is not part of a page, a <c>NULL</c>
		/// pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomstoryfragmentsresource-getowner
		// HRESULT GetOwner( IXpsOMPageReference **owner );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMPageReference GetOwner();

		/// <summary>Gets a new, read-only copy of the stream that is associated with this resource.</summary>
		/// <returns>A new, read-only copy of the stream that is associated with this resource.</returns>
		/// <remarks>
		/// <para>
		/// Reading from the IStream object returned by this method might return an E_PENDING error, which indicates that the stream
		/// length has not been determined yet. This behavior is different from that of a standard <c>IStream</c> object.
		/// </para>
		/// <para>For more information about the content of StoryFragments part, see the XML Paper Specification.</para>
		/// <para>
		/// This method calls the stream's <c>Clone</c> method to create the stream returned in stream. As a result, the performance of
		/// this method will depend on that of the stream's <c>Clone</c> method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomstoryfragmentsresource-getstream
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
		/// <para>For more information about the content of a StoryFragments part, see the XML Paper Specification.</para>
		/// <para>
		/// Because GetStream gets a clone of the stream that is set by this method, the provided stream should have an efficient
		/// cloning method. A stream with an inefficient cloning method will reduce the performance of <c>GetStream</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomstoryfragmentsresource-setcontent
		// HRESULT SetContent( IStream *sourceStream, IOpcPartUri *partName );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetContent([In] IStream sourceStream, [In] IOpcPartUri partName);
	}

	/// <summary>Generates a thumbnail image resource.</summary>
	/// <remarks>
	/// <para>To instantiate this interface, call CoCreateInstance as shown in the code example that follows.</para>
	/// <para>
	/// This interface requires XpsRasterService.dll. If XpsRasterService.dll is not present when CoCreateInstance is called to create
	/// an <c>IXpsOMThumbnailGenerator</c> instance, <c>CoCreateInstance</c> returns E_FAIL.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomthumbnailgenerator
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "cac794c0-bea2-417e-880f-15838f718ba7")]
	[ComImport, Guid("15B873D5-1971-41E8-83A3-6578403064C7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(XpsOMThumbnailGenerator))]
	public interface IXpsOMThumbnailGenerator
	{
		/// <summary>Generates a thumbnail image of a page.</summary>
		/// <param name="page">A pointer to the IXpsOMPage interface that contains the page for which the thumbnail image will be created.</param>
		/// <param name="thumbnailType">The XPS_IMAGE_TYPE value that specifies the type of thumbnail image to create.</param>
		/// <param name="thumbnailSize">The XPS_THUMBNAIL_SIZE value that specifies the image size of the thumbnail to create.</param>
		/// <param name="imageResourcePartName">
		/// A pointer to the IOpcPartUri interface that contains the name of the new thumbnail image part.
		/// </param>
		/// <returns>A pointer to the new IXpsOMImageResource interface that contains the thumbnail image created by this method.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomthumbnailgenerator-generatethumbnail
		// HRESULT GenerateThumbnail( IXpsOMPage *page, XPS_IMAGE_TYPE thumbnailType, XPS_THUMBNAIL_SIZE thumbnailSize, IOpcPartUri
		// *imageResourcePartName, IXpsOMImageResource **imageResource );
		IXpsOMImageResource GenerateThumbnail([In] IXpsOMPage page, [In] XPS_IMAGE_TYPE thumbnailType, [In] XPS_THUMBNAIL_SIZE thumbnailSize, [In] IOpcPartUri imageResourcePartName);
	}

	/// <summary>
	/// <para>A tile brush uses a visual image to paint a region by repeating the image.</para>
	/// <para>This is the base interface of IXpsOMImageBrush and IXpsOMVisualBrush.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// As shown in the illustration that follows, the tile brush takes a visual element, or a part of it, transforms the visual element
	/// to create a tile, places the tile in the viewport of the output area, and fills the output area as specified by the tile mode.
	/// </para>
	/// <para>
	/// In the preceding illustration, the viewport is the area covered by the first tile in the output area. The viewport image is
	/// repeated throughout the output area as specified by the tile mode. The transform property determines how the output area is
	/// transformed after the viewport has been tiled in the output area. The part of the output area that is ultimately rendered as a
	/// visible image is determined by the path, stroke, or glyph that is using the tile brush.
	/// </para>
	/// <para>
	/// A viewbox describes the portion of the source image that is used for the brush. The viewbox in the preceding illustration has
	/// the same size as the source image, so all of the source image is used for the brush. A viewbox can also be smaller than the
	/// original image.
	/// </para>
	/// <para>
	/// In the illustration that follows, the brush is created by using a viewbox that includes only a portion of the original image or visual.
	/// </para>
	/// <para>
	/// The next illustration shows the tile modes that are used to repeat the tile image to fill the output area. If the tile mode
	/// value is XPS_TILE_MODE_NONE, the tile image is drawn only once.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomtilebrush
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "fc9e1925-0dbc-447b-9acc-e7f719df62d1")]
	[ComImport, Guid("0FC2328D-D722-4A54-B2EC-BE90218A789E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMTileBrush : IXpsOMBrush
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
		IXpsOMMatrixTransform GetTransform();

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
		IXpsOMMatrixTransform GetTransformLocal();

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
		void SetTransformLocal([In] IXpsOMMatrixTransform transform);

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
		string GetTransformLookup();

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
		void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

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
		XPS_RECT GetViewbox();

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
		void SetViewbox(in XPS_RECT viewbox);

		/// <summary>Gets the portion of the destination geometry that is covered by a single tile.</summary>
		/// <returns>The XPS_RECT structure that describes the portion of the destination geometry that is covered by a single tile.</returns>
		/// <remarks>
		/// The viewport is the portion of the output area where the first tile is drawn. In the illustration, the viewport is outlined
		/// by the purple rectangle inside the red, dotted rectangle. The tile mode of the brush determines how the rest of the tiles
		/// are drawn in the output area.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-getviewport HRESULT
		// GetViewport( XPS_RECT *viewport );
		XPS_RECT GetViewport();

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
		void SetViewport(in XPS_RECT viewport);

		/// <summary>Gets the XPS_TILE_MODE value that describes the tile mode of the brush.</summary>
		/// <returns>The XPS_TILE_MODE value that describes the tile mode of the brush.</returns>
		/// <remarks>
		/// The tile mode determines how the tile image is repeated to fill the output area. If the tile mode value is
		/// XPS_TILE_MODE_NONE, the tile image is drawn only once. The following illustration shows examples of how the tile image
		/// appears in several tile modes.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-gettilemode HRESULT
		// GetTileMode( XPS_TILE_MODE *tileMode );
		XPS_TILE_MODE GetTileMode();

		/// <summary>Sets the XPS_TILE_MODE value that describes the tiling mode of the brush.</summary>
		/// <param name="tileMode">The XPS_TILE_MODE value to be set.</param>
		/// <remarks>
		/// The tile mode determines how the tile image is repeated to fill the output area. If the tile mode value is
		/// XPS_TILE_MODE_NONE, the tile image is drawn only once.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-settilemode HRESULT
		// SetTileMode( XPS_TILE_MODE tileMode );
		void SetTileMode([In] XPS_TILE_MODE tileMode);
	}

	/// <summary>The base interface for path, canvas, and glyph interfaces.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomvisual
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "f2ec412c-aece-4b20-a721-e6c17615e56b")]
	[ComImport, Guid("BC3E7333-FB0B-4AF3-A819-0B4EAAD0D2FD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMVisual : IXpsOMShareable
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
		IXpsOMMatrixTransform GetTransform();

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
		IXpsOMMatrixTransform GetTransformLocal();

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
		void SetTransformLocal([In] IXpsOMMatrixTransform matrixTransform);

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
		string GetTransformLookup();

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
		void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

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
		IXpsOMGeometry GetClipGeometry();

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
		IXpsOMGeometry GetClipGeometryLocal();

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
		void SetClipGeometryLocal([In] IXpsOMGeometry clipGeometry);

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
		string GetClipGeometryLookup();

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
		void SetClipGeometryLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

		/// <summary>Gets the opacity value of this visual.</summary>
		/// <returns>The opacity value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacity HRESULT
		// GetOpacity( FLOAT *opacity );
		[MethodImpl(MethodImplOptions.InternalCall)]
		float GetOpacity();

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
		void SetOpacity([In] float opacity);

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
		IXpsOMBrush GetOpacityMaskBrush();

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
		IXpsOMBrush GetOpacityMaskBrushLocal();

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
		void SetOpacityMaskBrushLocal([In] IXpsOMBrush opacityMaskBrush);

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
		string GetOpacityMaskBrushLookup();

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
		void SetOpacityMaskBrushLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

		/// <summary>Gets the <c>Name</c> property of the visual.</summary>
		/// <returns>The <c>Name</c> property string. If the <c>Name</c> property has not been set, a <c>NULL</c> pointer is returned.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getname HRESULT GetName(
		// LPWSTR *name );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetName();

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
		void SetName([In, MarshalAs(UnmanagedType.LPWStr)] string name);

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
		bool GetIsHyperlinkTarget();

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
		void SetIsHyperlinkTarget([In, MarshalAs(UnmanagedType.Bool)] bool isHyperlink);

		/// <summary>Gets a pointer to the IUri interface to which this visual object links.</summary>
		/// <returns>
		/// A pointer to the IUri interface that contains the destination URI for the link. If a URI has not been set for this object, a
		/// <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gethyperlinknavigateuri
		// HRESULT GetHyperlinkNavigateUri( IUri **hyperlinkUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IUri GetHyperlinkNavigateUri();

		/// <summary>Sets the destination URI of the visual's hyperlink.</summary>
		/// <param name="hyperlinkUri">The IUri interface that contains the destination URI of the visual's hyperlink.</param>
		/// <remarks>
		/// Setting an object's URI makes the object a hyperlink. When activated or clicked, the object will navigate to the destination
		/// that is specified by the URI in hyperlinkUri.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-sethyperlinknavigateuri
		// HRESULT SetHyperlinkNavigateUri( IUri *hyperlinkUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetHyperlinkNavigateUri([In] IUri hyperlinkUri);

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
		string GetLanguage();

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
		void SetLanguage([In, MarshalAs(UnmanagedType.LPWStr)] string language);
	}

	/// <summary>A brush that uses a visual element as a source.</summary>
	/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomvisualbrush
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "56c11e64-64a8-4c42-9547-4f1fcdc13a4b")]
	[ComImport, Guid("97E294AF-5B37-46B4-8057-874D2F64119B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMVisualBrush : IXpsOMTileBrush
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

		/// <summary>Gets a pointer to the interface of the resolved visual to be used as the source for the brush.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMVisual interface of the resolved visual object used as the source for the brush. If a visual has not
		/// been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <para>
		/// The value that is returned in this parameter depends on which method has most recently been called to set the visual object.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in visual</term>
		/// </listheader>
		/// <item>
		/// <term>SetVisualLocal</term>
		/// <term>The visual that is set by SetVisualLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetVisualLookup</term>
		/// <term>
		/// The visual that is retrieved, with a lookup key that matches the key that is set by SetVisualLookup, from the resource directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Neither SetVisualLocal nor SetVisualLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method returns an IXpsOMVisual interface pointer. However, the interface that is returned can be any interface that
		/// inherits from <c>IXpsOMVisual</c>, such as IXpsOMCanvas, IXpsOMPath, and IXpsOMGlyphs.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisualbrush-getvisual HRESULT
		// GetVisual( IXpsOMVisual **visual );
		IXpsOMVisual GetVisual();

		/// <summary>Gets a pointer to the interface of the local, unshared visual used as the source for the brush.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMVisual interface of the local, unshared visual used as the source for the brush. If a local visual
		/// object has not been set or if a visual lookup key has been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in visual</term>
		/// </listheader>
		/// <item>
		/// <term>SetVisualLocal</term>
		/// <term>The visual that is set by SetVisualLocal.</term>
		/// </item>
		/// <item>
		/// <term>SetVisualLookup</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetVisualLocal nor SetVisualLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method returns an IXpsOMVisual interface pointer. However, the interface that is returned can be any interface that
		/// inherits from <c>IXpsOMVisual</c>, such as IXpsOMCanvas, IXpsOMPath, or IXpsOMGlyphs.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisualbrush-getvisuallocal HRESULT
		// GetVisualLocal( IXpsOMVisual **visual );
		IXpsOMVisual GetVisualLocal();

		/// <summary>Sets the interface pointer of the local, unshared visual used as the source for the brush.</summary>
		/// <param name="visual">
		/// A pointer to the IXpsOMVisual interface to be set as the visual for the brush. If a local visual has been set, passing a
		/// <c>NULL</c> pointer will release it.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetVisualLocal</c>, the visual lookup key is released and GetVisualLookup returns a <c>NULL</c> pointer in
		/// the lookup parameter. The table that follows explains the relationship between the local and lookup values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in visual by GetVisual</term>
		/// <term>Object that is returned in visual by GetVisualLocal</term>
		/// <term>String that is returned in lookup by GetVisualLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetVisualLocal (this method).</term>
		/// <term>The visual that is set by SetVisualLocal.</term>
		/// <term>The visual that is set by SetVisualLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetVisualLookup</term>
		/// <term>
		/// The visual that is retrieved, with a lookup key that matches the key that is set by SetVisualLookup, from the resource directory.
		/// </term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetVisualLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetVisualLocal nor SetVisualLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisualbrush-setvisuallocal HRESULT
		// SetVisualLocal( IXpsOMVisual *visual );
		void SetVisualLocal([In] IXpsOMVisual visual);

		/// <summary>
		/// Gets the lookup key name of a visual in a resource dictionary; the visual is to be used as the source for the brush.
		/// </summary>
		/// <returns>
		/// <para>
		/// The key name of a visual in a resource dictionary; the visual is to be used as the source for the brush. If a visual's
		/// lookup key has not been set, or if a local visual has been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in lookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetVisualLocal</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetVisualLookup</term>
		/// <term>The lookup key that is set by SetVisualLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetVisualLocal nor SetVisualLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisualbrush-getvisuallookup HRESULT
		// GetVisualLookup( LPWSTR *lookup );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetVisualLookup();

		/// <summary>
		/// Sets the lookup key name of the shared visual, which is stored in a resource dictionary, to be used as the source for the brush.
		/// </summary>
		/// <param name="lookup">
		/// The lookup key name of the shared visual to be used as the source for the brush. If a lookup key has already been set, a
		/// <c>NULL</c> pointer will clear it.
		/// </param>
		/// <remarks>
		/// <para>
		/// After you call <c>SetVisualLookup</c>, the local visual is released and GetVisualLocal returns a <c>NULL</c> pointer in the
		/// visual parameter. The table that follows explains the relationship between the local and lookup values of this property.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in visual by GetVisual</term>
		/// <term>Object that is returned in visual by GetVisualLocal</term>
		/// <term>String that is returned in lookup by GetVisualLookup</term>
		/// </listheader>
		/// <item>
		/// <term>SetVisualLocal</term>
		/// <term>The visual that is set by SetVisualLocal.</term>
		/// <term>The visual that is set by SetVisualLocal.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>SetVisualLookup (this method).</term>
		/// <term>The visual that is retrieved, with a lookup key that matches the key set by SetVisualLookup, from the resource directory.</term>
		/// <term>NULL pointer.</term>
		/// <term>The lookup key that is set by SetVisualLookup.</term>
		/// </item>
		/// <item>
		/// <term>Neither SetVisualLocal nor SetVisualLookup has been called yet.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// <term>NULL pointer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisualbrush-setvisuallookup HRESULT
		// SetVisualLookup( LPCWSTR lookup );
		void SetVisualLookup([In, MarshalAs(UnmanagedType.LPWStr)] string lookup);

		/// <summary>Makes a deep copy of the interface.</summary>
		/// <returns>A pointer to the copy of the interface.</returns>
		/// <remarks>This method does not update the resource pointers in the new IXpsOMVisualBrush interface.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisualbrush-clone HRESULT Clone(
		// IXpsOMVisualBrush **visualBrush );
		IXpsOMVisualBrush Clone();
	}

	/// <summary>A collection of IXpsOMVisual interface pointers.</summary>
	/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomvisualcollection
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "f373b437-3973-40aa-9cac-a6b196a3e5d1")]
	[ComImport, Guid("94D8ABDE-AB91-46A8-82B7-F5B05EF01A96"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMVisualCollection
	{
		/// <summary>Gets the number of IXpsOMVisual interface pointers in the collection.</summary>
		/// <returns>The number of IXpsOMVisual interface pointers in the collection.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisualcollection-getcount HRESULT
		// GetCount( UINT32 *count );
		[MethodImpl(MethodImplOptions.InternalCall)]
		uint GetCount();

		/// <summary>Gets an IXpsOMVisual interface pointer from a specified location in the collection.</summary>
		/// <param name="index">The zero-based index of the IXpsOMVisual interface pointer to be obtained.</param>
		/// <returns>The IXpsOMVisual interface pointer at the location specified by index.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisualcollection-getat HRESULT
		// GetAt( UINT32 index, IXpsOMVisual **object );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMVisual GetAt([In] uint index);

		/// <summary>Inserts an IXpsOMVisual interface pointer at a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index of the collection where the interface pointer that is passed in object is to be inserted.
		/// </param>
		/// <param name="object">The IXpsOMVisual interface pointer that is to be inserted at the location specified by index.</param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method inserts the IXpsOMVisual interface pointer that is passed in object. Prior
		/// to the insertion, the pointer in this and all subsequent locations is moved up by one index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisualcollection-insertat HRESULT
		// InsertAt( UINT32 index, IXpsOMVisual *object );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void InsertAt([In] uint index, [In] IXpsOMVisual @object);

		/// <summary>Removes and releases an IXpsOMVisual interface pointer from a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection from which an IXpsOMVisual interface pointer is to be removed and released.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method releases the interface referenced by the pointer. After releasing the
		/// interface, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisualcollection-removeat HRESULT
		// RemoveAt( UINT32 index );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void RemoveAt([In] uint index);

		/// <summary>Replaces an IXpsOMVisual interface pointer at a specified location in the collection.</summary>
		/// <param name="index">The zero-based index in the collection where an IXpsOMVisual interface pointer is to be replaced.</param>
		/// <param name="object">
		/// The IXpsOMVisual interface pointer that will replace current contents at the location specified by index.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method releases the IXpsOMVisual interface referenced by the existing pointer, then
		/// writes the pointer that is passed in object.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisualcollection-setat HRESULT
		// SetAt( UINT32 index, IXpsOMVisual *object );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetAt([In] uint index, [In] IXpsOMVisual @object);

		/// <summary>Appends an IXpsOMVisual interface to the end of the collection.</summary>
		/// <param name="object">A pointer to the IXpsOMVisual interface that is to be appended to the collection.</param>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisualcollection-append HRESULT
		// Append( IXpsOMVisual *object );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Append([In] IXpsOMVisual @object);
	}

	/// <summary>Generates a thumbnail image resource.</summary>
	/// <remarks>
	/// <para>To instantiate this interface, call CoCreateInstance as shown in the code example that follows.</para>
	/// <para>
	/// This interface requires XpsRasterService.dll. If XpsRasterService.dll is not present when CoCreateInstance is called to create
	/// an <c>IXpsOMThumbnailGenerator</c> instance, <c>CoCreateInstance</c> returns E_FAIL.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomthumbnailgenerator
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "cac794c0-bea2-417e-880f-15838f718ba7")]
	[ClassInterface(ClassInterfaceType.None), ComImport, Guid("7E4A23E2-B969-4761-BE35-1A8CED58E323")]
	public class XpsOMThumbnailGenerator { }
}