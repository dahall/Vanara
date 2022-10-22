using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Opc;

namespace Vanara.PInvoke
{
	public static partial class XpsObjectModel
	{
		/// <summary>Creates objects in the XPS document object model.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomobjectfactory
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "2444703e-4b89-4ef0-9ed7-aa937bc62e8c")]
		[ComImport, Guid("F9B2A685-A50D-4FC2-B764-B56E093EA0CA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(XpsOMObjectFactory))]
		public interface IXpsOMObjectFactory
		{
			/// <summary>Creates an IXpsOMPackage interface that serves as the root node of an XPS object model document tree.</summary>
			/// <returns>A pointer to the new IXpsOMPackage interface.</returns>
			/// <remarks>
			/// <para>The code example that follows illustrates how this method is used to create a new interface.</para>
			/// <para>For information about using IXpsOMPackage interface in a program, see Create a Blank XPS OM.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createpackage HRESULT
			// CreatePackage( IXpsOMPackage **package );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMPackage CreatePackage();

			/// <summary>Opens an XPS package file and returns an instantiated XPS document object tree.</summary>
			/// <param name="filename">The name of the XPS package file.</param>
			/// <param name="reuseObjects">
			/// <para>
			/// A Boolean value that indicates whether the software is to attempt to optimize the document object tree by sharing objects
			/// that are identical in all properties and children.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The software will attempt to optimize the object tree.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The software will not attempt to optimize the object tree.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>A pointer to the new IXpsOMPackage interface that contains the resulting XPS document object tree.</returns>
			/// <remarks>
			/// <para>
			/// This method does not validate the contents of any stream-based resources that it loads from the stream into the objects of
			/// the XPS OM. Instead, the application must validate these resources before it uses them.
			/// </para>
			/// <para>
			/// This method does not deserialize the document pages; it only deserializes the XPS package down to the page reference parts.
			/// The actual pages can be deserialized as they are needed, by calling the IXpsOMPageReference::GetPage method. Because the
			/// pages are not deserialized when <c>GetPage</c> is called, it is possible for this method to return S_OK or, if an attempt is
			/// made to load a problematic page in an XPS package, to return an error.
			/// </para>
			/// <para>
			/// If you write an XPS OM immediately after you have read an XPS package into it, some of the original content might be lost or changed.
			/// </para>
			/// <para>Some of the changes that can occur in such a case are listed in the table that follows:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Document feature</term>
			/// <term>Action</term>
			/// </listheader>
			/// <item>
			/// <term>Digital signatures</term>
			/// <term>Removed from document</term>
			/// </item>
			/// <item>
			/// <term>DiscardControl part</term>
			/// <term>Removed from document</term>
			/// </item>
			/// <item>
			/// <term>Foreign document parts</term>
			/// <term>Removed from document</term>
			/// </item>
			/// <item>
			/// <term>FixedPage markup</term>
			/// <term>Modified from original</term>
			/// </item>
			/// <item>
			/// <term>Resource dictionary markup</term>
			/// <term>Modified from original if Optimization flag is set</term>
			/// </item>
			/// </list>
			/// <para>For information about using IXpsOMPackage interface in a program, see Create a Blank XPS OM.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createpackagefromfile
			// HRESULT CreatePackageFromFile( LPCWSTR filename, BOOL reuseObjects, IXpsOMPackage **package );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMPackage CreatePackageFromFile([In, MarshalAs(UnmanagedType.LPWStr)] string filename, [In, MarshalAs(UnmanagedType.Bool)] bool reuseObjects);

			/// <summary>Opens a stream that contains an XPS package, and returns an instantiated XPS document object tree.</summary>
			/// <param name="stream">The stream that contains an XPS package.</param>
			/// <param name="reuseObjects">
			/// <para>
			/// The Boolean value that indicates that the software is to attempt to optimize the document object tree by sharing objects
			/// that are identical in all properties and children.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The software will attempt to optimize the object tree.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The software will not attempt to optimize the object tree.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>A pointer to the new IXpsOMPackage interface that contains the resulting XPS document object tree.</returns>
			/// <remarks>
			/// <para>
			/// This method does not validate the contents of any stream-based resources that it loads from the stream into the objects of
			/// the XPS OM. Instead, the application must validate these resources before it uses them.
			/// </para>
			/// <para>
			/// This method does not deserialize the document pages; it only deserializes the XPS package down to the page reference parts.
			/// The actual pages can be deserialized as they are needed, by calling the IXpsOMPageReference::GetPage method. Because the
			/// pages are not deserialized when <c>GetPage</c> is called, it is possible for this method to return S_OK or, if an attempt is
			/// made to load a problematic page in an XPS package, to return an error.
			/// </para>
			/// <para>
			/// If you write an XPS OM immediately after you have read an XPS package into it, some of the original content might be lost or changed.
			/// </para>
			/// <para>Some of the changes that can occur in such a case are listed in the table that follows:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Document feature</term>
			/// <term>Action</term>
			/// </listheader>
			/// <item>
			/// <term>Digital signatures</term>
			/// <term>Removed from document</term>
			/// </item>
			/// <item>
			/// <term>DiscardControl part</term>
			/// <term>Removed from document</term>
			/// </item>
			/// <item>
			/// <term>Foreign document parts</term>
			/// <term>Removed from document</term>
			/// </item>
			/// <item>
			/// <term>FixedPage markup</term>
			/// <term>Modified from original</term>
			/// </item>
			/// <item>
			/// <term>Resource dictionary markup</term>
			/// <term>Modified from original if Optimization flag is set</term>
			/// </item>
			/// </list>
			/// <para>For information about using IXpsOMPackage interface in a program, see Create a Blank XPS OM.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createpackagefromstream
			// HRESULT CreatePackageFromStream( IStream *stream, BOOL reuseObjects, IXpsOMPackage **package );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMPackage CreatePackageFromStream([In] IStream stream, [In, MarshalAs(UnmanagedType.Bool)] bool reuseObjects);

			/// <summary>
			/// Creates an IXpsOMStoryFragmentsResource interface that provides access to the content of the resource stream of a page's
			/// StoryFragments part.
			/// </summary>
			/// <param name="acquiredStream">
			/// <para>The read-only IStream interface to be associated with this StoryFragments resource.</para>
			/// <para><c>Important</c> Treat this stream as a Single-Threaded Apartment (STA) object; do not re-enter it.</para>
			/// </param>
			/// <param name="partUri">The IOpcPartUri interface that contains the part name to be assigned to this resource.</param>
			/// <returns>A pointer to the new IXpsOMStoryFragmentsResource interface.</returns>
			/// <remarks>
			/// <para>
			/// The StoryFragments part of a page contains the XML markup that describes the structure of the portions of one or more
			/// stories that are associated with a single fixed page. Some of the document contents that might be described by the XML
			/// markup in a StoryFragments part include the story's tables and paragraphs that are found on the page.
			/// </para>
			/// <para>The XML markup in the DocumentStructure and StoryFragments parts is described in the XML Paper Specification.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createstoryfragmentsresource
			// HRESULT CreateStoryFragmentsResource( IStream *acquiredStream, IOpcPartUri *partUri, IXpsOMStoryFragmentsResource
			// **storyFragmentsResource );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMStoryFragmentsResource CreateStoryFragmentsResource([In] IStream acquiredStream, [In] IOpcPartUri partUri);

			/// <summary>
			/// Creates an IXpsOMDocumentStructureResource interface, which provides access to the document structure resource stream.
			/// </summary>
			/// <param name="acquiredStream">
			/// The read-only IStream interface to be associated with this resource. This parameter must not be NULL.
			/// </param>
			/// <param name="partUri">
			/// The IOpcPartUri interface that contains the part name to be assigned to this resource. This parameter must not be NULL.
			/// </param>
			/// <returns>A pointer to the new IXpsOMDocumentStructureResource interface.</returns>
			/// <remarks>
			/// <para>
			/// The DocumentStructure part of an XPS document contains the document outline, which, with the StoryFragments parts, defines
			/// the reading order of every element that appears in the fixed pages of the document. This interface enables a program to read
			/// the XML contents of the DocumentStructure part and also to replace the XML contents of the DocumentStructure part.
			/// </para>
			/// <para>
			/// The DocumentStructure part contains the document framework and the outline that describes the overall reading order of the
			/// document. The reading order is organized into semantic blocks called stories. Stories are logical units of the document in
			/// the same way as articles are units in a magazine. Stories are made up of one or more StoryFragments parts.
			/// </para>
			/// <para>
			/// The StoryFragments parts contain content structure markup that defines the story's semantic blocks, such as the paragraphs
			/// and tables that make up the story's content.
			/// </para>
			/// <para>The content of the DocumentStructure and StoryFragments parts is described in the XML Paper Specification.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createdocumentstructureresource
			// HRESULT CreateDocumentStructureResource( IStream *acquiredStream, IOpcPartUri *partUri, IXpsOMDocumentStructureResource
			// **documentStructureResource );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMDocumentStructureResource CreateDocumentStructureResource([In] IStream acquiredStream, [In] IOpcPartUri partUri);

			/// <summary>Creates an IXpsOMSignatureBlockResource that can contain one or more signature requests.</summary>
			/// <param name="acquiredStream">A read-only stream to be associated with this resource.</param>
			/// <param name="partUri">A pointer to the IOpcPartUri interface that contains the part name to be assigned to this resource.</param>
			/// <returns>A pointer to the new IXpsOMSignatureBlockResource interface created by this method.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createsignatureblockresource
			// HRESULT CreateSignatureBlockResource( IStream *acquiredStream, IOpcPartUri *partUri, IXpsOMSignatureBlockResource
			// **signatureBlockResource );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMSignatureBlockResource CreateSignatureBlockResource([In] IStream acquiredStream, [In] IOpcPartUri partUri);

			/// <summary>Creates an IXpsOMRemoteDictionaryResource interface that enables the sharing of property resources.</summary>
			/// <param name="dictionary">The IXpsOMDictionary interface pointer of the dictionary to be associated with this resource.</param>
			/// <param name="partUri">The IOpcPartUri interface that contains the part name to be assigned to this resource.</param>
			/// <returns>A pointer to the new IXpsOMRemoteDictionaryResource interface.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createremotedictionaryresource
			// HRESULT CreateRemoteDictionaryResource( IXpsOMDictionary *dictionary, IOpcPartUri *partUri, IXpsOMRemoteDictionaryResource
			// **remoteDictionaryResource );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMRemoteDictionaryResource CreateRemoteDictionaryResource([In] IXpsOMDictionary dictionary, [In] IOpcPartUri partUri);

			/// <summary>Loads the remote resource dictionary markup into an unrooted IXpsOMRemoteDictionaryResource interface.</summary>
			/// <param name="dictionaryMarkupStream">The <c>IStream</c> interface that contains the remote resource dictionary markup.</param>
			/// <param name="dictionaryPartUri">The IOpcPartUri interface that contains the part name to be assigned to this resource.</param>
			/// <param name="resources">
			/// The IXpsOMPartResources interface for the part resources of the dictionary resource objects that have streams.
			/// </param>
			/// <returns>A pointer to the new IXpsOMRemoteDictionaryResource interface.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createremotedictionaryresourcefromstream
			// HRESULT CreateRemoteDictionaryResourceFromStream( IStream *dictionaryMarkupStream, IOpcPartUri *dictionaryPartUri,
			// IXpsOMPartResources *resources, IXpsOMRemoteDictionaryResource **dictionaryResource );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMRemoteDictionaryResource CreateRemoteDictionaryResourceFromStream([In] IStream dictionaryMarkupStream, [In] IOpcPartUri dictionaryPartUri, [In] IXpsOMPartResources resources);

			/// <summary>Creates an IXpsOMPartResources interface that can contain part-based resources.</summary>
			/// <returns>A pointer to the new IXpsOMPartResources interface.</returns>
			/// <remarks>
			/// <para>
			/// The part resources are shared between pages of a document and can include fonts, images, color profiles, and remote dictionaries.
			/// </para>
			/// <para>To find the part resources of a document, call IXpsOMPageReference::CollectPartResources.</para>
			/// <para>The code example that follows illustrates how this method is used to create a new interface.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createpartresources
			// HRESULT CreatePartResources( IXpsOMPartResources **partResources );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMPartResources CreatePartResources();

			/// <summary>Creates an IXpsOMDocumentSequence interface, which can contain the IXpsOMDocument interfaces of the XPS document.</summary>
			/// <param name="partUri">
			/// A pointer to the IOpcPartUri interface that contains the part name to be assigned to this resource. This parameter must not
			/// be <c>NULL</c>.
			/// </param>
			/// <returns>A pointer to the new IXpsOMDocumentSequence interface.</returns>
			/// <returns>
			/// <para>
			/// The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the table that follows. For
			/// information about XPS document API return values that are not listed in this table, see XPS Document Errors.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method succeeded.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>partUri or documentSequence is NULL.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>The code example that follows illustrates how this method is used to create a new interface.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createdocumentsequence
			// HRESULT CreateDocumentSequence( IOpcPartUri *partUri, IXpsOMDocumentSequence **documentSequence );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMDocumentSequence CreateDocumentSequence([In] IOpcPartUri partUri);

			/// <summary>
			/// Creates an IXpsOMDocument interface, which can contain a set of IXpsOMPageReference interfaces in an ordered sequence.
			/// </summary>
			/// <param name="partUri">
			/// The IOpcPartUri interface that contains the part name to be assigned to this resource. This parameter must not be <c>NULL</c>.
			/// </param>
			/// <returns>A pointer to the new IXpsOMDocument interface.</returns>
			/// <remarks>The code example that follows illustrates how this method is used to create a new interface.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createdocument
			// HRESULT CreateDocument( IOpcPartUri *partUri, IXpsOMDocument **document );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMDocument CreateDocument([In] IOpcPartUri partUri);

			/// <summary>Creates an IXpsOMPageReference interface that enables the virtualization of pages.</summary>
			/// <param name="advisoryPageDimensions">
			/// <para>The XPS_SIZE structure that sets the advisory page dimensions (page width and page height).</para>
			/// <para>
			/// Size is described in XPS units. There are 96 XPS units per inch. For example, the dimensions of an 8.5" by 11.0" page are
			/// 816 by 1,056 XPS units.
			/// </para>
			/// </param>
			/// <returns>A pointer to the new IXpsOMPageReference interface.</returns>
			/// <remarks>
			/// <para>
			/// The use of a page reference makes it possible to delay the loading of the full object model of a page until the loading is
			/// requested explicitly. If the page has not been altered, it can be unloaded on request.
			/// </para>
			/// <para>The code example that follows illustrates how this method is used to create a new interface.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createpagereference
			// HRESULT CreatePageReference( const XPS_SIZE *advisoryPageDimensions, IXpsOMPageReference **pageReference );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMPageReference CreatePageReference(in XPS_SIZE advisoryPageDimensions);

			/// <summary>
			/// Creates an IXpsOMPage interface, which provides the root node of a tree of objects that represent the contents of a single page.
			/// </summary>
			/// <param name="pageDimensions">
			/// <para>The XPS_SIZE structure that specifies the size of the page to be created.</para>
			/// <para>
			/// Size is described in XPS units. There are 96 XPS units per inch. For example, the dimensions of an 8.5" by 11.0" page are
			/// 816 by 1,056 XPS units.
			/// </para>
			/// </param>
			/// <param name="language">
			/// <para>The string that indicates the default language of the created page.</para>
			/// <para><c>Important</c> The language string must follow the RFC 3066 syntax.</para>
			/// </param>
			/// <param name="partUri">The IOpcPartUri interface that contains the part name to be assigned to this resource.</param>
			/// <returns>A pointer to the new IXpsOMPage interface.</returns>
			/// <remarks>The code example that follows illustrates how this method is used to create a new interface.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createpage HRESULT
			// CreatePage( const XPS_SIZE *pageDimensions, LPCWSTR language, IOpcPartUri *partUri, IXpsOMPage **page );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMPage CreatePage(in XPS_SIZE pageDimensions, [In, MarshalAs(UnmanagedType.LPWStr)] string language, [In] IOpcPartUri partUri);

			/// <summary>Reads the page markup from the specified stream to create and populate an IXpsOMPage interface.</summary>
			/// <param name="pageMarkupStream">The stream that contains the page markup.</param>
			/// <param name="partUri">The IOpcPartUri interface that contains the page's URI.</param>
			/// <param name="resources">The IXpsOMPartResources interface that contains the resources used by the page.</param>
			/// <param name="reuseObjects">
			/// <para>
			/// A Boolean value that specifies whether the software is to attempt to optimize the page contents tree by sharing objects that
			/// are identical in all properties and children.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The software will attempt to optimize the object tree.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The software will not attempt to optimize the object tree.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>A pointer to the new IXpsOMPage interface created by this method.</returns>
			/// <remarks>
			/// This method does not validate the contents of any stream-based resources that it loads from the stream into the document
			/// objects. The application must verify these resources before it uses them.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createpagefromstream
			// HRESULT CreatePageFromStream( IStream *pageMarkupStream, IOpcPartUri *partUri, IXpsOMPartResources *resources, BOOL
			// reuseObjects, IXpsOMPage **page );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMPage CreatePageFromStream([In] IStream pageMarkupStream, [In] IOpcPartUri partUri, [In] IXpsOMPartResources resources, [In, MarshalAs(UnmanagedType.Bool)] bool reuseObjects);

			/// <summary>Creates an IXpsOMCanvas interface that is used to group page elements.</summary>
			/// <returns>A pointer to the new IXpsOMCanvas interface.</returns>
			/// <remarks>The code example that follows illustrates how this method is used to create a new interface.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createcanvas HRESULT
			// CreateCanvas( IXpsOMCanvas **canvas );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMCanvas CreateCanvas();

			/// <summary>Creates an IXpsOMGlyphs interface, which specifies text that appears on a page.</summary>
			/// <param name="fontResource">A pointer to the IXpsOMFontResource interface of the font resource to be used.</param>
			/// <returns>The new IXpsOMGlyphs interface pointer.</returns>
			/// <remarks>The code example that follows illustrates how this method is used to create a new interface.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createglyphs HRESULT
			// CreateGlyphs( IXpsOMFontResource *fontResource, IXpsOMGlyphs **glyphs );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMGlyphs CreateGlyphs([In] IXpsOMFontResource fontResource);

			/// <summary>Creates an IXpsOMPath interface that specifies a graphical path element on a page.</summary>
			/// <returns>A pointer to the new IXpsOMPath interface.</returns>
			/// <remarks>The code example that follows illustrates how this method is used to create a new interface.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createpath HRESULT
			// CreatePath( IXpsOMPath **path );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMPath CreatePath();

			/// <summary>Creates an IXpsOMGeometry interface, which specifies the shape of a path or of a clipping region.</summary>
			/// <returns>A pointer to the new IXpsOMGeometry interface.</returns>
			/// <remarks>The code example that follows illustrates how this method is used to create a new interface.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-creategeometry
			// HRESULT CreateGeometry( IXpsOMGeometry **geometry );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMGeometry CreateGeometry();

			/// <summary>
			/// Creates an IXpsOMGeometryFigure interface, which specifies a portion of an object that is defined by an IXpsOMGeometry interface.
			/// </summary>
			/// <param name="startPoint">The coordinates of the starting point of the geometry figure.</param>
			/// <returns>A pointer to the new IXpsOMGeometryFigure interface.</returns>
			/// <remarks>The code example that follows illustrates how this method is used to create a new interface.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-creategeometryfigure
			// HRESULT CreateGeometryFigure( const XPS_POINT *startPoint, IXpsOMGeometryFigure **figure );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMGeometryFigure CreateGeometryFigure(in XPS_POINT startPoint);

			/// <summary>Creates an IXpsOMMatrixTransform interface that specifies an affine matrix transform.</summary>
			/// <param name="matrix">The initial matrix to be assigned to the transform.</param>
			/// <returns>A pointer to the new IXpsOMMatrixTransform interface.</returns>
			/// <remarks>
			/// <para>The transform specified by this matrix can be applied to the transform property of other XPS objects.</para>
			/// <para>The code example that follows illustrates how this method is used to create a new interface.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-creatematrixtransform
			// HRESULT CreateMatrixTransform( const XPS_MATRIX *matrix, IXpsOMMatrixTransform **transform );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMMatrixTransform CreateMatrixTransform(in XPS_MATRIX matrix);

			/// <summary>Creates an IXpsOMSolidColorBrush interface, which specifies a brush of a single, solid color.</summary>
			/// <param name="color">The XPS_COLOR structure that specifies the brush color.</param>
			/// <param name="colorProfile">
			/// The IXpsOMColorProfileResource interface. Unless the color type is XPS_COLOR_TYPE_CONTEXT, this value must be <c>NULL</c>.
			/// </param>
			/// <returns>A pointer to the new IXpsOMSolidColorBrush interface.</returns>
			/// <remarks>The code example that follows illustrates how this method is used to create a new interface.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createsolidcolorbrush
			// HRESULT CreateSolidColorBrush( const XPS_COLOR *color, IXpsOMColorProfileResource *colorProfile, IXpsOMSolidColorBrush
			// **solidColorBrush );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMSolidColorBrush CreateSolidColorBrush(in XPS_COLOR color, [In] IXpsOMColorProfileResource colorProfile);

			/// <summary>Creates an IXpsOMColorProfileResource interface, which is used to access a color profile resource stream.</summary>
			/// <param name="acquiredStream">
			/// <para>The read-only IStream interface to be associated with this resource. This parameter must not be <c>NULL</c>.</para>
			/// <para><c>Important</c> Treat this stream as a Single-Threaded Apartment (STA) object; do not re-enter it.</para>
			/// </param>
			/// <param name="partUri">The IOpcPartUri interface that contains the part name to be assigned to this resource.</param>
			/// <returns>A pointer to the new IXpsOMColorProfileResource interface.</returns>
			/// <remarks>The code example that follows illustrates how this method is used to create a new interface.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createcolorprofileresource
			// HRESULT CreateColorProfileResource( IStream *acquiredStream, IOpcPartUri *partUri, IXpsOMColorProfileResource
			// **colorProfileResource );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMColorProfileResource CreateColorProfileResource([In] IStream acquiredStream, [In] IOpcPartUri partUri);

			/// <summary>Creates an IXpsOMImageBrush interface.</summary>
			/// <param name="image">The IXpsOMImageResource interface that contains the image to be used as the source image of the brush.</param>
			/// <param name="viewBox">
			/// The XPS_RECT structure that defines the viewbox, which is the area of the source image that is used by the brush.
			/// </param>
			/// <param name="viewPort">
			/// The XPS_RECT structure that defines the viewport, which is the area covered by the first tile in the output area.
			/// </param>
			/// <remarks>
			/// <para>The brush's viewbox specifies the portion of a source image or visual to be used as the tile image.</para>
			/// <para>
			/// The coordinates of the brush's viewbox are relative to the source content, such that (0,0) specifies the upper-left corner
			/// of the source content. For images, dimensions specified by the brush's viewbox are expressed in the units of 1/96". The
			/// corresponding pixel coordinates in the source image are calculated as follows:
			/// </para>
			/// <para>
			/// In the illustration that follows, the image on the left is an example of a source image, and that on the far right is the
			/// brush that results after selecting the viewbox.
			/// </para>
			/// <para>
			/// If the source image resolution is 96 by 96 dots per inch and image dimensions are 96 by 96 pixels, the values of fields in
			/// the viewbox parameter are as follows:
			/// </para>
			/// <para>The preceding parameter values correspond to the source image as follows:</para>
			/// <para>
			/// An image brush is a tile brush that takes an image, or a part of it, transforms the image to create a tile, places the
			/// resulting tile in the viewport (the destination geometry of the tile in the output area), and fills the output area as
			/// described by the tile mode.
			/// </para>
			/// <para>
			/// The viewport is the area covered by the first tile in the output area. The viewport image is repeated throughout the output
			/// area as described by the tile mode.
			/// </para>
			/// <para>
			/// The next illustration shows how an image brush is used to fill an output area. From left to right, the original image is
			/// transformed to fill the viewport, then placed in the viewport area of the output area, and then tiled to fill the output area.
			/// </para>
			/// <para>The code example that follows illustrates how this method is used to create a new interface.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createimagebrush
			// HRESULT CreateImageBrush( IXpsOMImageResource *image, const XPS_RECT *viewBox, const XPS_RECT *viewPort, IXpsOMImageBrush
			// **imageBrush );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMImageBrush CreateImageBrush([In] IXpsOMImageResource image, in XPS_RECT viewBox, in XPS_RECT viewPort);

			/// <summary>Creates an IXpsOMVisualBrush interface, which is an IXpsOMTileBrush that uses a visual object.</summary>
			/// <param name="viewBox">
			/// The XPS_RECT structure that specifies the source image's area to be used in the brush. This parameter must not be <c>NULL</c>.
			/// </param>
			/// <param name="viewPort">
			/// The XPS_RECT structure that specifies the destination geometry area of the tile. This parameter must not be <c>NULL</c>.
			/// </param>
			/// <returns>A pointer to the new IXpsOMVisualBrush interface.</returns>
			/// <remarks>The code example that follows illustrates how this method is used to create a new interface.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createvisualbrush
			// HRESULT CreateVisualBrush( const XPS_RECT *viewBox, const XPS_RECT *viewPort, IXpsOMVisualBrush **visualBrush );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMVisualBrush CreateVisualBrush(in XPS_RECT viewBox, in XPS_RECT viewPort);

			/// <summary>Creates an IXpsOMImageResource interface, which is used to access an image resource stream.</summary>
			/// <param name="acquiredStream">
			/// <para>The read-only stream to be associated with this resource. This parameter must not be <c>NULL</c>.</para>
			/// <para><c>Important</c> Treat this stream as a Single-Threaded Apartment (STA) object; do not re-enter it.</para>
			/// </param>
			/// <param name="contentType">The XPS_IMAGE_TYPE value that describes the image type of the stream that is referenced by acquiredStream.</param>
			/// <param name="partUri">
			/// The IOpcPartUri interface that contains the part name to be assigned to this resource. This parameter must not be <c>NULL</c>.
			/// </param>
			/// <returns>A pointer to the new IXpsOMImageResource interface.</returns>
			/// <remarks>The code example that follows illustrates how this method is used to create a new interface.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createimageresource
			// HRESULT CreateImageResource( IStream *acquiredStream, XPS_IMAGE_TYPE contentType, IOpcPartUri *partUri, IXpsOMImageResource
			// **imageResource );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMImageResource CreateImageResource([In] IStream acquiredStream, [In] XPS_IMAGE_TYPE contentType, [In] IOpcPartUri partUri);

			/// <summary>Creates an IXpsOMPrintTicketResource interface that enables access to a PrintTicket stream.</summary>
			/// <param name="acquiredStream">
			/// <para>The read-only PrintTicket resource stream.</para>
			/// <para><c>Important</c> Treat this stream as a Single-Threaded Apartment (STA) object; do not re-enter it.</para>
			/// </param>
			/// <param name="partUri">The IOpcPartUri interface that contains the part name to be assigned to this resource.</param>
			/// <returns>A pointer to the new IXpsOMPrintTicketResource interface.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createprintticketresource
			// HRESULT CreatePrintTicketResource( IStream *acquiredStream, IOpcPartUri *partUri, IXpsOMPrintTicketResource
			// **printTicketResource );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMPrintTicketResource CreatePrintTicketResource([In] IStream acquiredStream, [In] IOpcPartUri partUri);

			/// <summary>Creates an IXpsOMFontResource interface, which provides an IStream interface to the font resource.</summary>
			/// <param name="acquiredStream">
			/// <para>The read-only IStream interface to be associated with this font resource. This parameter must not be <c>NULL</c>.</para>
			/// <para><c>Important</c> Treat this stream as a Single-Threaded Apartment (STA) object; do not re-enter it.</para>
			/// <para><c>Caution</c> This stream is not to be obfuscated.</para>
			/// </param>
			/// <param name="fontEmbedding">The XPS_FONT_EMBEDDING value that specifies the stream's embedding option.</param>
			/// <param name="partUri">
			/// The IOpcPartUri interface that contains the part name to be assigned to this resource. This parameter must not be <c>NULL</c>.
			/// </param>
			/// <param name="isObfSourceStream">
			/// <para>A Boolean value that indicates whether the stream referenced by acquiredStream is obfuscated.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The stream referenced by acquiredStream is obfuscated.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The stream referenced by acquiredStream is not obfuscated.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>A pointer to the new IXpsOMFontResource interface.</returns>
			/// <remarks>
			/// <para>
			/// The value of isObfSourceStream describes the state of the acquiredStream-referenced stream at the time the font resource is
			/// created. All subsequent calls to GetStream or SetContent will operate on unobfuscated versions of IStream.
			/// </para>
			/// <para>
			/// An error is returned if isObfSourceStream is set to <c>TRUE</c> and fontEmbedding is set to XPS_FONT_EMBEDDING_NORMAL, or if
			/// the name referenced by partUri does not conform to the syntax for obfuscated streams.
			/// </para>
			/// <para>The code example that follows illustrates how this method is used to create a new interface.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createfontresource
			// HRESULT CreateFontResource( IStream *acquiredStream, XPS_FONT_EMBEDDING fontEmbedding, IOpcPartUri *partUri, BOOL
			// isObfSourceStream, IXpsOMFontResource **fontResource );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMFontResource CreateFontResource([In] IStream acquiredStream, [In] XPS_FONT_EMBEDDING fontEmbedding, [In] IOpcPartUri partUri, [In, MarshalAs(UnmanagedType.Bool)] bool isObfSourceStream);

			/// <summary>Creates an IXpsOMGradientStop interface to represent a single color and location definition within a gradient.</summary>
			/// <param name="color">The color value.</param>
			/// <param name="colorProfile">
			/// A pointer to the IXpsOMColorProfileResource interface that contains the color profile to be used. If the color type is not
			/// XPS_COLOR_TYPE_CONTEXT, this parameter must be <c>NULL</c>.
			/// </param>
			/// <param name="offset">
			/// <para>The offset value.</para>
			/// <para>Valid range: 0.0–1.0</para>
			/// </param>
			/// <returns>A pointer to the new IXpsOMGradientStop interface.</returns>
			/// <remarks>
			/// <para>
			/// Gradient stops are used to define the color at a specific location; the color is interpolated between the gradient stops.
			/// The offset, which is specified by offset, is a relative position between the start and end points of the gradient. The
			/// offset at the start point of a linear gradient or the origin of a radial gradient is 0.0. The offset of the end point of a
			/// linear gradient or the bounding ellipse of a radial gradient is 1.0. Gradient stops can be specified for any offset between
			/// those points, including the start and end points. The following illustration shows the gradient path and gradient stops of a
			/// linear gradient.
			/// </para>
			/// <para>
			/// The following illustration shows the gradient stops of a radial gradient. In this example, the radial gradient region is the
			/// area enclosed by the outer ellipse and the <c>XPS_SPREAD_METHOD_REFLECT</c> spread method is used to fill the space outside
			/// of the gradient region.
			/// </para>
			/// <para>The IXpsOMGradientStop interface specifies one and only one stop in a gradient.</para>
			/// <para>The calculations used to render a gradient are described in the XML Paper Specification.</para>
			/// <para>The code example that follows illustrates how this method is used to create a new interface.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-creategradientstop
			// HRESULT CreateGradientStop( const XPS_COLOR *color, IXpsOMColorProfileResource *colorProfile, FLOAT offset,
			// IXpsOMGradientStop **gradientStop );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMGradientStop CreateGradientStop(in XPS_COLOR color, [In] IXpsOMColorProfileResource colorProfile, [In] float offset);

			/// <summary>Creates an IXpsOMLinearGradientBrush interface.</summary>
			/// <param name="gradStop1">
			/// The IXpsOMGradientStop interface that specifies the gradient properties at the beginning of the gradient's vector. This
			/// parameter must not be <c>NULL</c>.
			/// </param>
			/// <param name="gradStop2">
			/// The IXpsOMGradientStop interface that specifies the gradient properties at the end of the gradient's vector. This parameter
			/// must not be <c>NULL</c>.
			/// </param>
			/// <param name="startPoint">The XPS_POINT structure that contains the coordinates of the start point in two-dimensional space.</param>
			/// <param name="endPoint">The XPS_POINT structure that contains the coordinates of the end point in two-dimensional space.</param>
			/// <returns>A pointer to the new IXpsOMLinearGradientBrush interface.</returns>
			/// <remarks>
			/// <para>
			/// The gradient region of a linear gradient is the area between and including the start and end points and extending in both
			/// directions at a right angle to the gradient path. The spread area is the area of the geometry that lies outside the gradient region.
			/// </para>
			/// <para>
			/// Gradient stops define the color at specific locations along the gradient path. In the illustration, gradient stop 0,
			/// specified by the gradStop1 parameter, is located at the start point of the gradient path, and gradient stop 1, specified by
			/// the gradStop2 parameter, is at the end point.
			/// </para>
			/// <para>
			/// As shown in the illustration that follows, the start and end points of a linear gradient are also the start and end points
			/// of the gradient path, which is the straight line that connects those points.
			/// </para>
			/// <para>The code example that follows illustrates how this method is used to create a new interface.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createlineargradientbrush
			// HRESULT CreateLinearGradientBrush( IXpsOMGradientStop *gradStop1, IXpsOMGradientStop *gradStop2, const XPS_POINT *startPoint,
			// const XPS_POINT *endPoint, IXpsOMLinearGradientBrush **linearGradientBrush );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMLinearGradientBrush CreateLinearGradientBrush([In] IXpsOMGradientStop gradStop1, [In] IXpsOMGradientStop gradStop2, in XPS_POINT startPoint, in XPS_POINT endPoint);

			/// <summary>Creates an IXpsOMRadialGradientBrush interface.</summary>
			/// <param name="gradStop1">
			/// The IXpsOMGradientStop interface that specifies the properties of the gradient at gradient origin. This parameter must not
			/// be <c>NULL</c>.
			/// </param>
			/// <param name="gradStop2">
			/// The IXpsOMGradientStop interface that specifies the properties of the gradient at the end of the gradient's vector, which is
			/// the ellipse that encloses the gradient region. This parameter must not be <c>NULL</c>.
			/// </param>
			/// <param name="centerPoint">The coordinates of the center point of the radial gradient ellipse.</param>
			/// <param name="gradientOrigin">The coordinates of the origin of the radial gradient.</param>
			/// <param name="radiiSizes">
			/// <para>The XPS_SIZE structure whose members specify the lengths of the gradient region's radii.</para>
			/// <para>Size is described in XPS units. There are 96 XPS units per inch. For example, a 1" radius is 96 XPS units.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>XPS_SIZE Member</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>width</term>
			/// <term>Length of the radius along the x-axis.</term>
			/// </item>
			/// <item>
			/// <term>height</term>
			/// <term>Length of the radius along the y-axis.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <returns>A pointer to the new IXpsOMRadialGradientBrush interface.</returns>
			/// <remarks>
			/// <para>
			/// As shown in the following illustration, the gradient region of a radial gradient is the area enclosed by the ellipse that is
			/// described by the center point and the x and y radii that extend from the center point. The spread area is the area outside
			/// of that ellipse. The gradient path (not shown) is a radial line that is drawn between the gradient origin and the ellipse
			/// that bounds the gradient region.
			/// </para>
			/// <para>
			/// For radial-gradient brushes, the gradient stop that is set by the gradStop1 parameter corresponds to the gradient origin
			/// location and an offset value of 0.0. The gradient stop that is set by the gradStop2 parameter corresponds to the
			/// circumference of the gradient region and an offset value of 1.0. For more information on gradient stops, see IXpsOMGradientStop.
			/// </para>
			/// <para>The code example that follows illustrates how this method is used to create a new interface.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createradialgradientbrush
			// HRESULT CreateRadialGradientBrush( IXpsOMGradientStop *gradStop1, IXpsOMGradientStop *gradStop2, const XPS_POINT
			// *centerPoint, const XPS_POINT *gradientOrigin, const XPS_SIZE *radiiSizes, IXpsOMRadialGradientBrush **radialGradientBrush );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMRadialGradientBrush CreateRadialGradientBrush([In] IXpsOMGradientStop gradStop1, [In] IXpsOMGradientStop gradStop2, in XPS_POINT centerPoint, in XPS_POINT gradientOrigin, in XPS_SIZE radiiSizes);

			/// <summary>Creates an IXpsOMCoreProperties interface, which contains the metadata that describes an XPS document.</summary>
			/// <param name="partUri">
			/// The IOpcPartUri interface that contains the part name to be assigned to this resource. This parameter must not be <c>NULL</c>.
			/// </param>
			/// <returns>A pointer to the new IXpsOMCoreProperties interface.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createcoreproperties
			// HRESULT CreateCoreProperties( IOpcPartUri *partUri, IXpsOMCoreProperties **coreProperties );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMCoreProperties CreateCoreProperties([In] IOpcPartUri partUri);

			/// <summary>Creates an IXpsOMDictionary interface, which enables the sharing of property resources.</summary>
			/// <returns>A pointer to the new IXpsOMDictionary interface.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createdictionary
			// HRESULT CreateDictionary( IXpsOMDictionary **dictionary );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMDictionary CreateDictionary();

			/// <summary>Creates an IXpsOMPartUriCollection interface that can contain IOpcPartUri interface pointers.</summary>
			/// <returns>A pointer to the new IXpsOMPartUriCollection interface.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createparturicollection
			// HRESULT CreatePartUriCollection( IXpsOMPartUriCollection **partUriCollection );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMPartUriCollection CreatePartUriCollection();

			/// <summary>Opens a file for writing the contents of an XPS OM to an XPS package.</summary>
			/// <param name="fileName">The name of the file to be created.</param>
			/// <param name="securityAttributes">
			/// <para>The SECURITY_ATTRIBUTES structure, which contains two separate but related members:</para>
			/// <list type="bullet">
			/// <item>
			/// <term><c>lpSecurityDescriptor</c>: an optional security descriptor</term>
			/// </item>
			/// <item>
			/// <term><c>bInheritHandle</c>: a Boolean value that determines whether the returned handle can be inherited by child processes</term>
			/// </item>
			/// </list>
			/// <para>If</para>
			/// <para>lpSecurityDescriptor</para>
			/// <para>is</para>
			/// <para>NULL</para>
			/// <para>, the file or device associated with the returned handle is assigned a default security descriptor.</para>
			/// <para>For more information about securityAttributes, see CreateFile.</para>
			/// </param>
			/// <param name="flagsAndAttributes">
			/// <para>
			/// Specifies the settings and attributes of the file to be created. For most files, the <c>FILE_ATTRIBUTE_NORMAL</c> value can
			/// be used.
			/// </para>
			/// <para>See CreateFile for more information about this parameter.</para>
			/// </param>
			/// <param name="optimizeMarkupSize">
			/// <para>
			/// A Boolean value that indicates whether the document markup will be optimized for size when the contents of the XPS OM are
			/// written to the XPS package.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The package writer will try to optimize the markup for minimum size.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The package writer will not try to perform any optimization.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="interleaving">Specifies whether the content of the XPS OM will be interleaved when it is written to the file.</param>
			/// <param name="documentSequencePartName">
			/// The IOpcPartUri interface that contains the part name of the document sequence in the new file.
			/// </param>
			/// <param name="coreProperties">
			/// The IXpsOMCoreProperties interface that contains the core document properties to be given to the new file. This parameter
			/// can be set to <c>NULL</c>.
			/// </param>
			/// <param name="packageThumbnail">
			/// The IXpsOMImageResource interface that contains the thumbnail image to be assigned to the new file. This parameter can be
			/// set to <c>NULL</c>.
			/// </param>
			/// <param name="documentSequencePrintTicket">
			/// The IXpsOMPrintTicketResource interface that contains the package-level print ticket to be assigned to the new file. This
			/// parameter can be set to <c>NULL</c>.
			/// </param>
			/// <param name="discardControlPartName">
			/// The IOpcPartUri interface that contains the name of the discard control part. This parameter can be set to <c>NULL</c>.
			/// </param>
			/// <returns>A pointer to the new IXpsOMPackageWriter interface created by this method.</returns>
			/// <remarks>
			/// <para>
			/// The file is opened and initialized and the IXpsOMPackageWriter interface that is returned is then used to write content
			/// types, package relationships, core properties, document sequence resources, and document sequence relationships.
			/// </para>
			/// <para>
			/// If documentSequencePrintTicket is set to <c>NULL</c> and the value of interleaving is <c>XPS_INTERLEAVING_ON</c>, this
			/// method creates a blank job-level print ticket and adds a relationship to the blank print ticket. This is done to provide
			/// more efficient streaming consumption of the package.
			/// </para>
			/// <para>
			/// If documentSequencePrintTicket is set to <c>NULL</c> and the value of interleaving is <c>XPS_INTERLEAVING_OFF</c>, no blank
			/// print ticket is created.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createpackagewriteronfile
			// HRESULT CreatePackageWriterOnFile( LPCWSTR fileName, LPSECURITY_ATTRIBUTES securityAttributes, DWORD flagsAndAttributes, BOOL
			// optimizeMarkupSize, XPS_INTERLEAVING interleaving, IOpcPartUri *documentSequencePartName, IXpsOMCoreProperties
			// *coreProperties, IXpsOMImageResource *packageThumbnail, IXpsOMPrintTicketResource *documentSequencePrintTicket, IOpcPartUri
			// *discardControlPartName, IXpsOMPackageWriter **packageWriter );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMPackageWriter CreatePackageWriterOnFile([In, MarshalAs(UnmanagedType.LPWStr)] string fileName, [In] IntPtr securityAttributes, [In] uint flagsAndAttributes, [In] int optimizeMarkupSize, [In] XPS_INTERLEAVING interleaving, [In] IOpcPartUri documentSequencePartName, [In] IXpsOMCoreProperties coreProperties, [In] IXpsOMImageResource packageThumbnail, [In] IXpsOMPrintTicketResource documentSequencePrintTicket, [In] IOpcPartUri discardControlPartName);

			/// <summary>Opens a stream for writing the contents of an XPS OM to an XPS package.</summary>
			/// <param name="outputStream">The stream to be used for writing.</param>
			/// <param name="optimizeMarkupSize">
			/// <para>
			/// A Boolean value that indicates whether the document markup will be optimized for size when the document is written to the stream.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>When writing to the stream, the package writer will attempt to optimize the markup for minimum size.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>When writing to the package, the package writer will not attempt any optimization.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="interleaving">Specifies whether the content of the XPS OM will be interleaved when it is written to the stream.</param>
			/// <param name="documentSequencePartName">
			/// The IOpcPartUri interface that contains the part name of the document sequence in the new file.
			/// </param>
			/// <param name="coreProperties">
			/// The IXpsOMCoreProperties interface that contains the core document properties to be given to the new file. This parameter
			/// can be set to <c>NULL</c>.
			/// </param>
			/// <param name="packageThumbnail">
			/// The IXpsOMImageResource interface that contains the thumbnail image to be assigned to the new file. This parameter can be
			/// set to <c>NULL</c>.
			/// </param>
			/// <param name="documentSequencePrintTicket">
			/// The IXpsOMPrintTicketResource interface that contains the package-level print ticket to be assigned to the new file. This
			/// parameter can be set to <c>NULL</c>.
			/// </param>
			/// <param name="discardControlPartName">
			/// The IOpcPartUri interface that contains the name of the discard control part. This parameter can be set to <c>NULL</c>.
			/// </param>
			/// <returns>A pointer to the new IXpsOMPackageWriter interface created by this method.</returns>
			/// <remarks>
			/// <para>
			/// The stream is opened and initialized, and then the returned IXpsOMPackageWriter interface is used to write content types,
			/// package relationships, core properties, document sequence resources, and document sequence relationships.
			/// </para>
			/// <para>
			/// If documentSequencePrintTicket is set to <c>NULL</c> and the value of interleaving is <c>XPS_INTERLEAVING_ON</c>, this
			/// method creates a blank job-level print ticket and adds a relationship to the blank print ticket. This is done to provide
			/// more efficient streaming consumption of the package.
			/// </para>
			/// <para>
			/// If documentSequencePrintTicket is set to <c>NULL</c> and the value of interleaving is <c>XPS_INTERLEAVING_OFF</c>, no blank
			/// print ticket is created.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createpackagewriteronstream
			// HRESULT CreatePackageWriterOnStream( ISequentialStream *outputStream, BOOL optimizeMarkupSize, XPS_INTERLEAVING interleaving,
			// IOpcPartUri *documentSequencePartName, IXpsOMCoreProperties *coreProperties, IXpsOMImageResource *packageThumbnail,
			// IXpsOMPrintTicketResource *documentSequencePrintTicket, IOpcPartUri *discardControlPartName, IXpsOMPackageWriter
			// **packageWriter );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMPackageWriter CreatePackageWriterOnStream([In] ISequentialStream outputStream, [In] int optimizeMarkupSize, [In] XPS_INTERLEAVING interleaving, [In] IOpcPartUri documentSequencePartName, [In] IXpsOMCoreProperties coreProperties, [In] IXpsOMImageResource packageThumbnail, [In] IXpsOMPrintTicketResource documentSequencePrintTicket, [In] IOpcPartUri discardControlPartName);

			/// <summary>Creates an IOpcPartUri interface that uses the specified URI.</summary>
			/// <param name="uri">The URI string.</param>
			/// <returns>A pointer to the IOpcPartUri interface created by this method.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createparturi HRESULT
			// CreatePartUri( LPCWSTR uri, IOpcPartUri **partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IOpcPartUri CreatePartUri([In, MarshalAs(UnmanagedType.LPWStr)] string uri);

			/// <summary>Creates a read-only IStream over the specified file.</summary>
			/// <param name="filename">The name of the file to be opened.</param>
			/// <returns>A stream over the specified file.</returns>
			/// <remarks>
			/// <c>CreateReadOnlyStreamOnFile</c> is a wrapper method for IOpcFactory::CreateStreamOnFile. It has the same effect as calling
			/// the following:
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomobjectfactory-createreadonlystreamonfile
			// HRESULT CreateReadOnlyStreamOnFile( LPCWSTR filename, IStream **stream );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IStream CreateReadOnlyStreamOnFile([In, MarshalAs(UnmanagedType.LPWStr)] string filename);
		}

		/// <summary>CoClass for IXpsOMObjectFactory.</summary>
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "2444703e-4b89-4ef0-9ed7-aa937bc62e8c")]
		[ClassInterface(ClassInterfaceType.None), ComImport, Guid("E974D26D-3D9B-4D47-88CC-3872F2DC3585")]
		public class XpsOMObjectFactory { }
	}
}