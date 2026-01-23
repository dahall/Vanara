using System.Runtime.CompilerServices;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Opc;

namespace Vanara.PInvoke;

public static partial class XpsObjectModel
{
	/// <summary>
	/// <para>This interface provides access to the metadata that is stored in the Core Properties part of the XPS document.</para>
	/// <para>
	/// The contents of the Core Properties part are described in the 1st edition, Part 2, "Open Packaging Conventions," of Standard
	/// ECMA-376, Office Open XML File Formats.
	/// </para>
	/// </summary>
	/// <remarks>The meaning and use of these properties is determined by the user or context.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomcoreproperties
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "705ec9c7-5aa9-4fc5-ad2c-441cb545d056")]
	[ComImport, Guid("3340FE8F-4027-4AA1-8F5F-D35AE45FE597"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMCoreProperties : IXpsOMPart
	{
		/// <summary>Gets the name that will be used when the part is serialized.</summary>
		/// <returns>
		/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
		/// method), a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
		// GetPartName( IOpcPartUri **partUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IOpcPartUri? GetPartName();

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
		new void SetPartName([In] IOpcPartUri? partUri);

		/// <summary>Gets a pointer to the IXpsOMPackage interface that contains the core properties.</summary>
		/// <returns>
		/// A pointer to the IXpsOMPackage interface that contains the core properties. If the interface does not belong to a package, a
		/// <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getowner HRESULT
		// GetOwner( IXpsOMPackage **package );
		IXpsOMPackage? GetOwner();

		/// <summary>Gets the <c>category</c> property.</summary>
		/// <returns>The string that is read from the <c>category</c> property.</returns>
		/// <remarks>
		/// <para>The <c>category</c> property contains categorization of the content.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getcategory HRESULT
		// GetCategory( StrPtrUni *category );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string? GetCategory();

		/// <summary>Sets the <c>category</c> property.</summary>
		/// <param name="category">
		/// The string to be written to the <c>category</c> property. A <c>NULL</c> pointer clears the <c>category</c> property.
		/// </param>
		/// <remarks>The <c>category</c> property contains a categorization of the content.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setcategory HRESULT
		// SetCategory( LPCWSTR category );
		void SetCategory([In, MarshalAs(UnmanagedType.LPWStr)] string? category);

		/// <summary>Gets the <c>contentStatus</c> property.</summary>
		/// <returns>The string that is read from the <c>contentStatus</c> property.</returns>
		/// <remarks>
		/// <para>
		/// The <c>contentStatus</c> property stores the content's status. Examples of <c>contentStatus</c> values include <c>Draft</c>,
		/// <c>Reviewed</c>, and <c>Final</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getcontentstatus
		// HRESULT GetContentStatus( StrPtrUni *contentStatus );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string? GetContentStatus();

		/// <summary>Sets the <c>contentStatus</c> property.</summary>
		/// <param name="contentStatus">
		/// The string to be written to the <c>contentStatus</c> property. A <c>NULL</c> pointer clears the <c>contentStatus</c> property.
		/// </param>
		/// <remarks>
		/// The <c>contentStatus</c> property contains the status of the content. Examples of <c>contentStatus</c> values include
		/// <c>Draft</c>, <c>Reviewed</c>, and <c>Final</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setcontentstatus
		// HRESULT SetContentStatus( LPCWSTR contentStatus );
		void SetContentStatus([In, MarshalAs(UnmanagedType.LPWStr)] string? contentStatus);

		/// <summary>Gets the <c>contentType</c> property.</summary>
		/// <returns>The string that is read from the <c>contentType</c> property.</returns>
		/// <remarks>
		/// <para>
		/// The <c>contentType</c> property stores the type of content that is being represented, and it is generally defined by a
		/// specific use and intended audience. Examples of <c>contentType</c> values include <c>Whitepaper</c>, <c>Security
		/// Bulletin</c>, and <c>Exam</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getcontenttype
		// HRESULT GetContentType( StrPtrUni *contentType );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string? GetContentType();

		/// <summary>Sets the <c>contentType</c> property.</summary>
		/// <param name="contentType">
		/// The string to be written to the <c>contentType</c> property. A <c>NULL</c> pointer clears the <c>contentType</c> property.
		/// </param>
		/// <remarks>
		/// The <c>contentType</c> property contains the type of content that is being represented, which is generally defined by a
		/// specific use and intended audience. Examples of <c>contentType</c> values include <c>Whitepaper</c>, <c>Security
		/// Bulletin</c>, and <c>Exam</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setcontenttype
		// HRESULT SetContentType( LPCWSTR contentType );
		void SetContentType([In, MarshalAs(UnmanagedType.LPWStr)] string? contentType);

		/// <summary>Gets the <c>created</c> property.</summary>
		/// <returns>The date and time that are read from the <c>created</c> property.</returns>
		/// <remarks>The <c>created</c> property contains the date and time the package was created.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getcreated HRESULT
		// GetCreated( SYSTEMTIME *created );
		SYSTEMTIME GetCreated();

		/// <summary>Sets the <c>created</c> property.</summary>
		/// <param name="created">The date and time the package was created. A <c>NULL</c> pointer clears the <c>created</c> property</param>
		/// <remarks>The <c>created</c> property contains the date and time the package was created.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setcreated HRESULT
		// SetCreated( const SYSTEMTIME *created );
		void SetCreated(in SYSTEMTIME created);

		/// <summary>Gets the <c>creator</c> property.</summary>
		/// <returns>The string that is read from the <c>creator</c> property.</returns>
		/// <remarks>
		/// <para>The <c>creator</c> property describes the entity that is primarily responsible for making the content of the resource.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getcreator HRESULT
		// GetCreator( StrPtrUni *creator );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string? GetCreator();

		/// <summary>Sets the <c>creator</c> property.</summary>
		/// <param name="creator">
		/// The string to be written to the <c>creator</c> property. A <c>NULL</c> pointer clears the <c>creator</c> property.
		/// </param>
		/// <remarks>
		/// The <c>creator</c> property describes the entity that is primarily responsible for making the content of the resource.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setcreator HRESULT
		// SetCreator( LPCWSTR creator );
		void SetCreator([In, MarshalAs(UnmanagedType.LPWStr)] string? creator);

		/// <summary>Gets the <c>description</c> property.</summary>
		/// <returns>The string that is read from the <c>description</c> property.</returns>
		/// <remarks>
		/// <para>The <c>description</c> property provides an explanation of the content.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getdescription
		// HRESULT GetDescription( StrPtrUni *description );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string? GetDescription();

		/// <summary>Sets the <c>description</c> property.</summary>
		/// <param name="description">
		/// The string to be written to the <c>description</c> property. A <c>NULL</c> pointer clears this property.
		/// </param>
		/// <remarks>The <c>description</c> property explains the content.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setdescription
		// HRESULT SetDescription( LPCWSTR description );
		void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string? description);

		/// <summary>Gets the <c>identifier</c> property.</summary>
		/// <returns>The string that is read from the <c>identifier</c> property.</returns>
		/// <remarks>
		/// <para>
		/// The <c>identifier</c> property is an unambiguous reference to the resource within a user-defined or application-specific context.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getidentifier
		// HRESULT GetIdentifier( StrPtrUni *identifier );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string? GetIdentifier();

		/// <summary>Sets the <c>identifier</c> property.</summary>
		/// <param name="identifier">
		/// The string to be written to the <c>identifier</c> property. A <c>NULL</c> pointer clears the <c>identifier</c> property.
		/// </param>
		/// <remarks>
		/// The <c>identifier</c> property is an unambiguous reference to the resource within a user-defined or application-specific context.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setidentifier
		// HRESULT SetIdentifier( LPCWSTR identifier );
		void SetIdentifier([In, MarshalAs(UnmanagedType.LPWStr)] string? identifier);

		/// <summary>Gets the <c>keywords</c> property.</summary>
		/// <returns>The string that is read from the <c>keywords</c> property.</returns>
		/// <remarks>
		/// <para>
		/// The <c>keywords</c> property is a delimited set of keywords that are used to support searching and indexing. This is
		/// typically a list of terms that are not available in other properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getkeywords HRESULT
		// GetKeywords( StrPtrUni *keywords );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string? GetKeywords();

		/// <summary>Sets the <c>keywords</c> property.</summary>
		/// <param name="keywords">
		/// The string that contains the keywords to be written to the <c>keywords</c> property. A <c>NULL</c> pointer clears the
		/// <c>keywords</c> property.
		/// </param>
		/// <remarks>
		/// The <c>keywords</c> property is a delimited set of keywords that are used to support searching and indexing. It is typically
		/// a list of terms that are not available elsewhere in the properties.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setkeywords HRESULT
		// SetKeywords( LPCWSTR keywords );
		void SetKeywords([In, MarshalAs(UnmanagedType.LPWStr)] string? keywords);

		/// <summary>Gets the <c>language</c> property.</summary>
		/// <returns>The value that is read from the <c>language</c> property.</returns>
		/// <remarks>
		/// <para>The <c>language</c> property describes the language of the resource's intellectual content.</para>
		/// <para>Internet Engineering Task Force (IETF) RFC 3066 describes the recommended encoding for this property.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getlanguage HRESULT
		// GetLanguage( StrPtrUni *language );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string? GetLanguage();

		/// <summary>Sets the <c>language</c> property.</summary>
		/// <param name="language">
		/// The string that contains the language value to be written to the <c>language</c> property. A <c>NULL</c> pointer clears the
		/// <c>language</c> property.
		/// </param>
		/// <remarks>
		/// <para>The <c>language</c> property describes the language of the resource's intellectual content.</para>
		/// <para>Internet Engineering Task Force (IETF) RFC 3066 describes the recommended encoding for this property.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setlanguage HRESULT
		// SetLanguage( LPCWSTR language );
		void SetLanguage([In, MarshalAs(UnmanagedType.LPWStr)] string? language);

		/// <summary>Gets the <c>lastModifiedBy</c> property.</summary>
		/// <returns>The value that is read from the <c>lastModifiedBy</c> property.</returns>
		/// <remarks>
		/// <para>The <c>lastModifiedBy</c> property describes the user who performed the last modification.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getlastmodifiedby
		// HRESULT GetLastModifiedBy( StrPtrUni *lastModifiedBy );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string? GetLastModifiedBy();

		/// <summary>Sets the <c>lastModifiedBy</c> property.</summary>
		/// <param name="lastModifiedBy">
		/// The string that contains the value to be written to the <c>lastModifiedBy</c> property. A <c>NULL</c> pointer clears the
		/// <c>lastModifiedBy</c> property.
		/// </param>
		/// <remarks>The <c>lastModifiedBy</c> property describes the user who performs the last modification.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setlastmodifiedby
		// HRESULT SetLastModifiedBy( LPCWSTR lastModifiedBy );
		void SetLastModifiedBy([In, MarshalAs(UnmanagedType.LPWStr)] string? lastModifiedBy);

		/// <summary>Gets the <c>lastPrinted</c> property.</summary>
		/// <returns>The date and time that are read from the <c>lastPrinted</c> property.</returns>
		/// <remarks>The <c>lastPrinted</c> property contains the date and time the package was last printed.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getlastprinted
		// HRESULT GetLastPrinted( SYSTEMTIME *lastPrinted );
		SYSTEMTIME GetLastPrinted();

		/// <summary>Sets the <c>lastPrinted</c> property.</summary>
		/// <param name="lastPrinted">
		/// The date and time the package was last printed. A <c>NULL</c> pointer clears the <c>lastPrinted</c> property.
		/// </param>
		/// <remarks>The <c>lastPrinted</c> property contains the date and time the package was last printed.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setlastprinted
		// HRESULT SetLastPrinted( const SYSTEMTIME *lastPrinted );
		void SetLastPrinted([In, Optional] PSYSTEMTIME? lastPrinted);

		/// <summary>Gets the <c>modified</c> property.</summary>
		/// <returns>The date and time that are read from the <c>modified</c> property.</returns>
		/// <remarks>The <c>modified</c> property contains the date and time the package was last modified.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getmodified HRESULT
		// GetModified( SYSTEMTIME *modified );
		SYSTEMTIME GetModified();

		/// <summary>Sets the <c>modified</c> property.</summary>
		/// <param name="modified">
		/// The date and time the package was last changed. A <c>NULL</c> pointer clears the <c>modified</c> property.
		/// </param>
		/// <remarks>The <c>modified</c> property contains the date and time the package was last changed.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setmodified HRESULT
		// SetModified( const SYSTEMTIME *modified );
		void SetModified([In, Optional] PSYSTEMTIME? modified);

		/// <summary>Gets the <c>revision</c> property.</summary>
		/// <returns>The string that is read from the <c>revision</c> property.</returns>
		/// <remarks>
		/// <para>The <c>revision</c> property contains the resource's revision number.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getrevision HRESULT
		// GetRevision( StrPtrUni *revision );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string? GetRevision();

		/// <summary>Sets the <c>revision</c> property.</summary>
		/// <param name="revision">
		/// The string to be written to the <c>revision</c> property. A <c>NULL</c> pointer clears the <c>revision</c> property.
		/// </param>
		/// <remarks>The <c>revision</c> property contains the revision number of the resource.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setrevision HRESULT
		// SetRevision( LPCWSTR revision );
		void SetRevision([In, MarshalAs(UnmanagedType.LPWStr)] string? revision);

		/// <summary>Gets the <c>subject</c> property.</summary>
		/// <returns>The string that is read from the <c>subject</c> property.</returns>
		/// <remarks>The <c>subject</c> property contains the topic of the resource's content.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getsubject HRESULT
		// GetSubject( StrPtrUni *subject );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string? GetSubject();

		/// <summary>Sets the <c>subject</c> property.</summary>
		/// <param name="subject">
		/// The string to be written to the <c>subject</c> property. A <c>NULL</c> pointer clears the <c>subject</c> property.
		/// </param>
		/// <remarks>The <c>subject</c> property contains the topic of the resource content.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setsubject HRESULT
		// SetSubject( LPCWSTR subject );
		void SetSubject([In, MarshalAs(UnmanagedType.LPWStr)] string? subject);

		/// <summary>Gets the <c>title</c> property.</summary>
		/// <returns>The string that is read from the <c>title</c> property.</returns>
		/// <remarks>The <c>title</c> property contains the resource's name.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-gettitle HRESULT
		// GetTitle( StrPtrUni *title );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string? GetTitle();

		/// <summary>Sets the <c>title</c> property.</summary>
		/// <param name="title">
		/// The string to be written to the <c>title</c> property. A <c>NULL</c> pointer clears the <c>title</c> property.
		/// </param>
		/// <remarks>The <c>title</c> property contains the name given to the resource.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-settitle HRESULT
		// SetTitle( LPCWSTR title );
		void SetTitle([In, MarshalAs(UnmanagedType.LPWStr)] string? title);

		/// <summary>Gets the <c>version</c> property.</summary>
		/// <returns>The string that is read from the <c>version</c> property.</returns>
		/// <remarks>The <c>version</c> property contains the resource's version number.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getversion HRESULT
		// GetVersion( StrPtrUni *version );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string? GetVersion();

		/// <summary>Sets the <c>version</c> property.</summary>
		/// <param name="version">
		/// The string to be written to the <c>version</c> property. A <c>NULL</c> pointer clears the <c>version</c> property.
		/// </param>
		/// <remarks>The <c>version</c> property contains the version number of the resource.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setversion HRESULT
		// SetVersion( LPCWSTR version );
		void SetVersion([In, MarshalAs(UnmanagedType.LPWStr)] string? version);

		/// <summary>Makes a deep copy of the interface.</summary>
		/// <returns>A pointer to the copy of the interface.</returns>
		/// <remarks>The owner of the interface returned in coreProperties is <c>NULL</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-clone HRESULT Clone(
		// IXpsOMCoreProperties **coreProperties );
		IXpsOMCoreProperties Clone();
	}

	/// <summary>An ordered sequence of fixed pages and document-level resources that make up the document.</summary>
	/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
	/// <seealso cref="Vanara.PInvoke.XpsObjectModel.IXpsOMPart"/>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomdocument
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "22d3c0a1-3ad5-4f48-9e1e-eaf3bd95b39f")]
	[ComImport, Guid("2C2C94CB-AC5F-4254-8EE9-23948309D9F0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMDocument : IXpsOMPart
	{
		/// <summary>Gets the name that will be used when the part is serialized.</summary>
		/// <returns>
		/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
		/// method), a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
		// GetPartName( IOpcPartUri **partUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IOpcPartUri? GetPartName();

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
		new void SetPartName([In] IOpcPartUri? partUri);

		/// <summary>Gets a pointer to the IXpsOMDocumentSequence interface that contains the document.</summary>
		/// <returns>
		/// A pointer to the IXpsOMDocumentSequence interface that contains the document. If the document does not belong to a document
		/// sequence, a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocument-getowner HRESULT GetOwner(
		// IXpsOMDocumentSequence **documentSequence );
		IXpsOMDocumentSequence GetOwner();

		/// <summary>Gets the IXpsOMPageReferenceCollection interface of the document, which allows virtualized access to its pages.</summary>
		/// <returns>
		/// A pointer to the IXpsOMPageReferenceCollection interface that contains a collection of page references for each page of the
		/// document. If there are no page references, the <c>IXpsOMPageReferenceCollection</c> returned in pageReferences will be empty
		/// and will have no elements.
		/// </returns>
		/// <remarks>
		/// <para>
		/// To get the pages of a document, first get the list of IXpsOMPageReference interfaces by calling <c>GetPageReferences</c>.
		/// Then, for each <c>IXpsOMPageReference</c> interface, load a page by calling GetPage.
		/// </para>
		/// <para>
		/// If the document does not have any pages, the page reference collection returned in pageReferences will be empty. To get the
		/// number of page references in the collection, call its GetCount method.
		/// </para>
		/// <para>For an example of how this method can be used in a program, see Navigate the XPS OM.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocument-getpagereferences HRESULT
		// GetPageReferences( IXpsOMPageReferenceCollection **pageReferences );
		IXpsOMPageReferenceCollection GetPageReferences();

		/// <summary>Gets the IXpsOMPrintTicketResource interface of the document-level print ticket.</summary>
		/// <returns>
		/// A pointer to the IXpsOMPrintTicketResource interface of the document-level print ticket that is associated with the
		/// document. If no print ticket has been assigned, a <c>NULL</c> pointer will be returned.
		/// </returns>
		/// <remarks>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocument-getprintticketresource
		// HRESULT GetPrintTicketResource( IXpsOMPrintTicketResource **printTicketResource );
		IXpsOMPrintTicketResource GetPrintTicketResource();

		/// <summary>Sets the IXpsOMPrintTicketResource interface for the document-level print ticket.</summary>
		/// <returns>
		/// A pointer to the IXpsOMPrintTicketResource interface for the document-level print ticket to be assigned to the document. A
		/// <c>NULL</c> pointer releases any previously assigned print ticket resource.
		/// </returns>
		/// <remarks>
		/// If the document contains an IXpsOMPrintTicketResource interface when this method is called, that interface is released
		/// before the new <c>IXpsOMPrintTicketResource</c> interface, passed in printTicketResource, is set.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocument-setprintticketresource
		// HRESULT SetPrintTicketResource( IXpsOMPrintTicketResource *printTicketResource );
		void SetPrintTicketResource([In] IXpsOMPrintTicketResource printTicketResource);

		/// <summary>
		/// Gets a pointer to the IXpsOMDocumentStructureResource interface of the resource that contains structural information about
		/// the document.
		/// </summary>
		/// <remarks>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocument-getdocumentstructureresource
		// HRESULT GetDocumentStructureResource( IXpsOMDocumentStructureResource **documentStructureResource );
		IXpsOMDocumentStructureResource GetDocumentStructureResource();

		/// <summary>Sets the IXpsOMDocumentStructureResource interface for the document.</summary>
		/// <remarks>
		/// If the document contains an IXpsOMDocumentStructureResource interface when this method is called, that interface is released
		/// before the new <c>IXpsOMDocumentStructureResource</c> interface, which is passed in documentStructureResource, is set.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocument-setdocumentstructureresource
		// HRESULT SetDocumentStructureResource( IXpsOMDocumentStructureResource *documentStructureResource );
		void SetDocumentStructureResource([In] IXpsOMDocumentStructureResource documentStructureResource);

		/// <summary>
		/// Gets a pointer to the IXpsOMSignatureBlockResourceCollection interface, which refers to a collection of the document's
		/// digital signature block resources.
		/// </summary>
		/// <returns>
		/// A pointer to the IXpsOMSignatureBlockResourceCollection interface, which refers to a collection of the document's digital
		/// signature block resources. If the document does not contain any signature block resources, the
		/// <c>IXpsOMSignatureBlockResourceCollection</c> interface will be empty.
		/// </returns>
		/// <remarks>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocument-getsignatureblockresources
		// HRESULT GetSignatureBlockResources( IXpsOMSignatureBlockResourceCollection **signatureBlockResources );
		IXpsOMSignatureBlockResourceCollection GetSignatureBlockResources();

		/// <summary>Makes a deep copy of the interface.</summary>
		/// <returns>A pointer to the copy of the interface.</returns>
		/// <remarks>This method does not update any of the resource pointers in the copy.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocument-clone HRESULT Clone(
		// IXpsOMDocument **document );
		IXpsOMDocument Clone();
	}

	/// <summary>A collection of IXpsOMDocument interface pointers.</summary>
	/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomdocumentcollection
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "4f3acae9-10a0-47ff-9170-a40abe230580")]
	[ComImport, Guid("D1C87F0D-E947-4754-8A25-971478F7E83E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMDocumentCollection
	{
		/// <summary>Gets the number of IXpsOMDocument interface pointers in the collection.</summary>
		/// <returns>The number of IXpsOMDocument interface pointers in the collection.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentcollection-getcount HRESULT
		// GetCount( UINT32 *count );
		uint GetCount();

		/// <summary>Gets an IXpsOMDocument interface pointer from a specified location in the collection.</summary>
		/// <returns>The zero-based index of the IXpsOMDocument interface pointer to be obtained.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentcollection-getat HRESULT
		// GetAt( UINT32 index, IXpsOMDocument **document );
		IXpsOMDocument GetAt([In] uint index);

		/// <summary>Inserts an IXpsOMDocument interface pointer at a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index of the collection where the interface pointer that is passed in document is to be inserted.
		/// </param>
		/// <param name="document">The IXpsOMDocument interface pointer that is to be inserted at the location specified by index.</param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method inserts the IXpsOMDocument interface pointer that is passed in document.
		/// Prior to the insertion, the pointer in this and all subsequent locations is moved up by one index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentcollection-insertat HRESULT
		// InsertAt( UINT32 index, IXpsOMDocument *document );
		void InsertAt([In] uint index, [In] IXpsOMDocument document);

		/// <summary>Removes and releases an IXpsOMDocument interface pointer from a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection from which an IXpsOMDocument interface pointer is to be removed and released.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method releases the interface referenced by the pointer at the location specified by index. After releasing the
		/// interface, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentcollection-removeat HRESULT
		// RemoveAt( UINT32 index );
		void RemoveAt([In] uint index);

		/// <summary>Replaces an IXpsOMDocument interface pointer at a specified location in the collection.</summary>
		/// <param name="index">The zero-based index in the collection where an IXpsOMDocument interface pointer is to be replaced.</param>
		/// <param name="document">
		/// The IXpsOMDocument interface pointer that will replace current contents at the location specified by index.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method releases the IXpsOMDocument interface referenced by the existing pointer,
		/// then writes the pointer that is passed in document.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentcollection-setat HRESULT
		// SetAt( UINT32 index, IXpsOMDocument *document );
		void SetAt([In] uint index, [In] IXpsOMDocument document);

		/// <summary>Appends an IXpsOMDocument interface to the end of the collection.</summary>
		/// <param name="document">A pointer to the IXpsOMDocument interface that is to be appended to the collection.</param>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentcollection-append HRESULT
		// Append( IXpsOMDocument *document );
		void Append([In] IXpsOMDocument document);
	}

	/// <summary>The root object that has the XPS document content.</summary>
	/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomdocumentsequence
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "472095a4-ecd8-406a-97c2-1a34b4e5184a")]
	[ComImport, Guid("56492EB4-D8D5-425E-8256-4C2B64AD0264"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMDocumentSequence : IXpsOMPart
	{
		/// <summary>Gets the name that will be used when the part is serialized.</summary>
		/// <returns>
		/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
		/// method), a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
		// GetPartName( IOpcPartUri **partUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IOpcPartUri? GetPartName();

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
		new void SetPartName([In] IOpcPartUri? partUri);

		/// <summary>Gets a pointer to the IXpsOMPackage interface that contains the document sequence.</summary>
		/// <returns>
		/// A pointer to the IXpsOMPackage interface that contains the document sequence. If the document sequence does not belong to a
		/// package, a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentsequence-getowner HRESULT
		// GetOwner( IXpsOMPackage **package );
		IXpsOMPackage? GetOwner();

		/// <summary>
		/// Gets a pointer to the IXpsOMDocumentCollection interface, which contains the documents specified in the document sequence.
		/// </summary>
		/// <returns>
		/// A pointer to the IXpsOMDocumentCollection interface, which contains the documents specified in the document sequence. If the
		/// sequence does not have any documents, the <c>IXpsOMDocumentCollection</c> interface will be empty.
		/// </returns>
		/// <remarks>
		/// If the document sequence does not have any documents, the document collection that is returned in documents will be empty.
		/// To get the number of documents in the collection, call the collection's GetCount method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentsequence-getdocuments
		// HRESULT GetDocuments( IXpsOMDocumentCollection **documents );
		IXpsOMDocumentCollection GetDocuments();

		/// <summary>
		/// Gets the IXpsOMPrintTicketResource interface to the job-level print ticket that is assigned to the document sequence.
		/// </summary>
		/// <returns>
		/// A pointer to the IXpsOMPrintTicketResource interface of the job-level print ticket that is assigned to the document
		/// sequence. If no <c>IXpsOMPrintTicketResource</c> interface has been assigned to the document sequence, a <c>NULL</c> pointer
		/// is returned.
		/// </returns>
		/// <remarks>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentsequence-getprintticketresource
		// HRESULT GetPrintTicketResource( IXpsOMPrintTicketResource **printTicketResource );
		IXpsOMPrintTicketResource? GetPrintTicketResource();

		/// <summary>Sets the job-level print ticket resource for the document sequence.</summary>
		/// <param name="printTicketResource">
		/// A pointer to the IXpsOMPrintTicketResource interface of the job-level print ticket that will be set for the document
		/// sequence. If the document sequence has a print ticket resource, a <c>NULL</c> pointer will release it.
		/// </param>
		/// <remarks>
		/// If the document contains an IXpsOMPrintTicketResource interface when this method is called, that interface is released
		/// before the new <c>IXpsOMPrintTicketResource</c> interface, which is passed in printTicketResource, is set.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentsequence-setprintticketresource
		// HRESULT SetPrintTicketResource( IXpsOMPrintTicketResource *printTicketResource );
		void SetPrintTicketResource([In] IXpsOMPrintTicketResource? printTicketResource);
	}

	/// <summary>
	/// <para>Provides the top-level entry into the XPS object model tree.</para>
	/// <para>
	/// Although this interface does not correspond to any XPS markup, it does correspond to the XPS document, and it is required to
	/// save the components of an XPS object model tree as an XPS document.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>The code example that follows illustrates how to create an instance of this interface.</para>
	/// <para>For information about using this interface in a program, see Create a Blank XPS OM.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsompackage
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "7b0a36d6-1af1-4c2c-af14-d6139e9115c3")]
	[ComImport, Guid("18C3DF65-81E1-4674-91DC-FC452F5A416F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMPackage
	{
		/// <summary>Gets a pointer to the IXpsOMDocumentSequence interface that contains the document sequence of the XPS package.</summary>
		/// <returns>
		/// A pointer to the IXpsOMDocumentSequence interface that contains the document sequence of the XPS package. If an
		/// <c>IXpsOMDocumentSequence</c> interface has not been set, a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompackage-getdocumentsequence HRESULT
		// GetDocumentSequence( IXpsOMDocumentSequence **documentSequence );
		IXpsOMDocumentSequence? GetDocumentSequence();

		/// <summary>Sets the IXpsOMDocumentSequence interface of the XPS package.</summary>
		/// <param name="documentSequence">
		/// The IXpsOMDocumentSequence interface pointer to be assigned to the package. This parameter must not be <c>NULL</c>.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompackage-setdocumentsequence HRESULT
		// SetDocumentSequence( IXpsOMDocumentSequence *documentSequence );
		void SetDocumentSequence([In] IXpsOMDocumentSequence? documentSequence);

		/// <summary>Gets a pointer to the IXpsOMCoreProperties interface of the XPS package.</summary>
		/// <returns>
		/// A pointer to the IXpsOMCoreProperties interface of the XPS package. If an <c>IXpsOMCoreProperties</c> interface has not been
		/// set, a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompackage-getcoreproperties HRESULT
		// GetCoreProperties( IXpsOMCoreProperties **coreProperties );
		IXpsOMCoreProperties? GetCoreProperties();

		/// <summary>Sets the IXpsOMCoreProperties interface of the XPS package.</summary>
		/// <param name="coreProperties">
		/// The IXpsOMCoreProperties interface pointer to be assigned to the package. A <c>NULL</c> pointer releases any previously
		/// assigned core properties interface.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompackage-setcoreproperties HRESULT
		// SetCoreProperties( IXpsOMCoreProperties *coreProperties );
		void SetCoreProperties([In] IXpsOMCoreProperties? coreProperties);

		/// <summary>Gets the name of the discard control part in the XPS package.</summary>
		/// <returns>
		/// A pointer to the IOpcPartUri interface that contains the name of the discard control part in the XPS package. If a discard
		/// control part has not been set, a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompackage-getdiscardcontrolpartname
		// HRESULT GetDiscardControlPartName( IOpcPartUri **discardControlPartUri );
		IOpcPartUri? GetDiscardControlPartName();

		/// <summary>Sets the name of the discard control part in the XPS package.</summary>
		/// <param name="discardControlPartUri">
		/// The IOpcPartUri interface that contains the name of the discard control part to be assigned to the XPS package. A
		/// <c>NULL</c> pointer releases any previously assigned discard control part.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompackage-setdiscardcontrolpartname
		// HRESULT SetDiscardControlPartName( IOpcPartUri *discardControlPartUri );
		void SetDiscardControlPartName([In] IOpcPartUri? discardControlPartUri);

		/// <summary>
		/// Gets a pointer to the IXpsOMImageResource interface of the thumbnail resource that is associated with the XPS package.
		/// </summary>
		/// <returns>
		/// A pointer to the IXpsOMImageResource interface of the thumbnail resource that is associated with the XPS package. If the
		/// package does not have a thumbnail resource, a <c>NULL</c> pointer is returned.
		/// </returns>
		/// <remarks>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompackage-getthumbnailresource
		// HRESULT GetThumbnailResource( IXpsOMImageResource **imageResource );
		IXpsOMImageResource? GetThumbnailResource();

		/// <summary>Sets the thumbnail image of the XPS document.</summary>
		/// <param name="imageResource">
		/// The IXpsOMImageResource interface that contains the thumbnail image that will be assigned to the package. A <c>NULL</c>
		/// pointer releases any previously assigned thumbnail image resources.
		/// </param>
		/// <remarks>
		/// <para>The thumbnail image is a small, visual representation of the document's contents.</para>
		/// <para>The image type of the image resource must be either XPS_IMAGE_TYPE_JPEG or <c>XPS_IMAGE_TYPE_PNG</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompackage-setthumbnailresource
		// HRESULT SetThumbnailResource( IXpsOMImageResource *imageResource );
		void SetThumbnailResource([In] IXpsOMImageResource? imageResource);

		/// <summary>Writes the XPS package to a specified file.</summary>
		/// <param name="fileName">The name of the file to be created. This parameter must not be <c>NULL</c>.</param>
		/// <param name="securityAttributes">
		/// <para>The SECURITY_ATTRIBUTES structure, which contains two distinct but related data members:</para>
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
		/// <para>, the file or device that is associated with the returned handle will be assigned a default security descriptor.</para>
		/// <para>For more information about the securityAttributes parameter, refer to CreateFile.</para>
		/// </param>
		/// <param name="flagsAndAttributes">
		/// <para>
		/// Specifies the settings and attributes of the file to be created. For most files, a value of <c>FILE_ATTRIBUTE_NORMAL</c> can
		/// be used.
		/// </para>
		/// <para>For more information about the flagsAndAttributes parameter, refer to CreateFile.</para>
		/// </param>
		/// <param name="optimizeMarkupSize">
		/// <para>A Boolean value that indicates whether the document markup is to be optimized for size when it is written to the file.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The package writer will attempt to optimize the markup for minimum size.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The package writer will not attempt any optimization.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// The optimizeMarkupSize value determines whether the markup inside the individual document parts is to be optimized. It has
		/// no effect on how the parts are interleaved.
		/// </para>
		/// <para>
		/// <c>Note</c> Writing an XPS OM to a file does not automatically create a thumbnail for the XPS document. To create a
		/// thumbnail of the XPS document, use the IXpsOMThumbnailGenerator interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompackage-writetofile HRESULT
		// WriteToFile( LPCWSTR fileName, LPSECURITY_ATTRIBUTES securityAttributes, DWORD flagsAndAttributes, BOOL optimizeMarkupSize );
		void WriteToFile([In, MarshalAs(UnmanagedType.LPWStr)] string fileName, [In] SECURITY_ATTRIBUTES? securityAttributes, [In] FileFlagsAndAttributes flagsAndAttributes, [In, MarshalAs(UnmanagedType.Bool)] bool optimizeMarkupSize);

		/// <summary>Writes the XPS package to a specified stream.</summary>
		/// <param name="stream">The stream that receives the serialized contents of the package. This parameter must not be <c>NULL</c>.</param>
		/// <param name="optimizeMarkupSize">
		/// <para>A Boolean value that indicates whether the document markup is to be optimized for size when it is written to the stream.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The package writer will attempt to optimize the markup for minimum size.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The package writer will not attempt any optimization.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// The optimizeMarkupSize value determines whether the markup inside the individual document parts is to be optimized. It has
		/// no effect on how the parts are interleaved.
		/// </para>
		/// <para>
		/// <c>Note</c> Writing an XPS OM to a stream does not automatically create a thumbnail for the XPS document. To create a
		/// thumbnail of the XPS document, use the IXpsOMThumbnailGenerator interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompackage-writetostream HRESULT
		// WriteToStream( ISequentialStream *stream, BOOL optimizeMarkupSize );
		void WriteToStream([In] ISequentialStream stream, [In, MarshalAs(UnmanagedType.Bool)] bool optimizeMarkupSize);
	}

	/// <summary>Incrementally writes the parts of an XPS document to a package file.</summary>
	/// <remarks>
	/// <para>
	/// Progressive writing enables an application to serialize XPS document content and resources as they become available. It does not
	/// require the application to create all elements of the document before serialization.
	/// </para>
	/// <para>
	/// This interface writes the pages to the package sequentially, in the order that AddPage is called. The interface does not support
	/// page writing in a non-sequential order; thus it should only be used when page content is produced or is available for writing in
	/// the order it is to appear in the XPS document.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsompackagewriter
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "cbbcc8bf-6172-41c8-9d74-27e5635ec167")]
	[ComImport, Guid("4E2AA182-A443-42C6-B41B-4F8E9DE73FF9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMPackageWriter
	{
		/// <summary>Opens and initializes a new FixedDocument in the FixedDocumentSequence of the package.</summary>
		/// <param name="documentPartName">A pointer to an IOpcPartUri interface that contains the part name of the new document.</param>
		/// <param name="documentPrintTicket">
		/// A pointer to an IXpsOMPrintTicketResource interface that contains the document-level print ticket. If there is no
		/// document-level print ticket for this package, this parameter can be set to <c>NULL</c>. See also Remarks.
		/// </param>
		/// <param name="documentStructure">
		/// A pointer to an IXpsOMDocumentStructureResource interface that contains the initial document structure resource, if the
		/// resource is available; if it is not available, this parameter can be set to <c>NULL</c>.
		/// </param>
		/// <param name="signatureBlockResources">
		/// A pointer to an IXpsOMSignatureBlockResourceCollection interface that contains a collection of digital signatures to be
		/// attached to the document. If there are no digital signatures to be attached, this parameter can be set to <c>NULL</c>.
		/// </param>
		/// <param name="restrictedFonts">
		/// <para>
		/// A pointer to an IXpsOMPartUriCollection interface that contains the fonts that must have restricted font relationships
		/// written for them. The font data are not written until AddResource or Close is called.
		/// </para>
		/// <para>If the document does not contain any restricted fonts, this parameter can be set to <c>NULL</c>.</para>
		/// </param>
		/// <remarks>
		/// <para>This method must be called before AddPage can be called to write the contents of an IXpsOMPage interface.</para>
		/// <para>
		/// Immediately after the IXpsOMPackageWriter interface has been instantiated, the package contains only an empty Fixed Document
		/// Sequence part. The first time this method is called, a FixedDocument part is added to the Fixed Document Sequence part and
		/// the AddPage method will add pages to that FixedDocument part. Each time this method is called after the first time, the
		/// current FixedDocument part is closed, and a new FixedDocument part is opened and added to the Fixed Document Sequence part.
		/// All subsequent calls to the <c>AddPage</c> method add pages to the most recently opened FixedDocument part. This interface
		/// does not support adding pages to closed FixedDocument parts.
		/// </para>
		/// <para>
		/// If documentPrintTicket contains a <c>NULL</c> pointer and the package writer was created with interleaving set to
		/// <c>XPS_INTERLEAVING_ON</c>, this method creates a blank document-level print ticket, if one does not already exist. Each
		/// time this method is called with a <c>NULL</c> pointer in documentPrintTicket, it adds a relationship from the new document
		/// to the blank print ticket. This is done to provide more efficient streaming consumption of the package.
		/// </para>
		/// <para>
		/// If documentPrintTicket contains a <c>NULL</c> pointer and the package writer was created with interleaving set to
		/// <c>XPS_INTERLEAVING_OFF</c>, no blank print ticket is created.
		/// </para>
		/// <para>
		/// <c>Note</c> Creating a new document in the package does not automatically create a thumbnail for the XPS document. To create
		/// a thumbnail of the XPS document, use the IXpsOMThumbnailGenerator interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompackagewriter-startnewdocument
		// HRESULT StartNewDocument( IOpcPartUri *documentPartName, IXpsOMPrintTicketResource *documentPrintTicket,
		// IXpsOMDocumentStructureResource *documentStructure, IXpsOMSignatureBlockResourceCollection *signatureBlockResources,
		// IXpsOMPartUriCollection *restrictedFonts );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void StartNewDocument([In] IOpcPartUri documentPartName, [In, Optional] IXpsOMPrintTicketResource? documentPrintTicket,
			[In, Optional] IXpsOMDocumentStructureResource? documentStructure,
			[In, Optional] IXpsOMSignatureBlockResourceCollection? signatureBlockResources, [In, Optional] IXpsOMPartUriCollection? restrictedFonts);

		/// <summary>Writes a new FixedPage part to the currently open FixedDocument part in the package.</summary>
		/// <param name="page">
		/// The IXpsOMPage interface whose page content is to be written to the currently open FixedDocument of the package.
		/// </param>
		/// <param name="advisoryPageDimensions">
		/// <para>The XPS_SIZE structure that contains page dimensions.</para>
		/// <para>
		/// Size is described in XPS units. There are 96 XPS units per inch. For example, the dimensions of an 8.5" by 11.0" page are
		/// 816 by 1,056 XPS units.
		/// </para>
		/// </param>
		/// <param name="discardableResourceParts">
		/// The IXpsOMPartUriCollection interface that contains a collection of the discardable resource parts.
		/// </param>
		/// <param name="storyFragments">The IXpsOMStoryFragmentsResource interface that is to be used for this page.</param>
		/// <param name="pagePrintTicket">
		/// The IXpsOMPrintTicketResource interface that contains the page-level print ticket for this page. See also Remarks.
		/// </param>
		/// <param name="pageThumbnail">The IXpsOMImageResource interface that contains the thumbnail image of this page.</param>
		/// <remarks>
		/// <para>Call this method after calling StartNewDocument.</para>
		/// <para>
		/// This method creates a new FixedPage part in the package, copies the contents of the IXpsOMPage interface that is passed in
		/// the page parameter, and then closes the new FixedPage part after the page has been written to the package.
		/// </para>
		/// <para>
		/// If pagePrintTicket contains a <c>NULL</c> pointer and the package writer was created with interleaving set to
		/// <c>XPS_INTERLEAVING_ON</c>, this method creates a blank page-level print ticket, if one does not already exist. Each time
		/// method is called with a <c>NULL</c> pointer in pagePrintTicket, it adds a relationship from the new page to the blank print
		/// ticket. This is done to provide more efficient streaming consumption of the package.
		/// </para>
		/// <para>
		/// If pagePrintTicket contains a <c>NULL</c> pointer and the package writer was created with interleaving set to
		/// <c>XPS_INTERLEAVING_OFF</c>, no blank print ticket is created.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompackagewriter-addpage HRESULT
		// AddPage( IXpsOMPage *page, const XPS_SIZE *advisoryPageDimensions, IXpsOMPartUriCollection *discardableResourceParts,
		// IXpsOMStoryFragmentsResource *storyFragments, IXpsOMPrintTicketResource *pagePrintTicket, IXpsOMImageResource *pageThumbnail );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AddPage([In] IXpsOMPage page, in XPS_SIZE advisoryPageDimensions, [In, Optional] IXpsOMPartUriCollection? discardableResourceParts,
			[In, Optional] IXpsOMStoryFragmentsResource? storyFragments, [In] IXpsOMPrintTicketResource? pagePrintTicket, [In, Optional] IXpsOMImageResource? pageThumbnail);

		/// <summary>Creates a new part resource in the package.</summary>
		/// <param name="resource">
		/// The IXpsOMResource interface of the part resource that will be added as a new part in the package. See Remarks for the types
		/// of resources that may be passed in this parameter.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method creates a new part in the document package that corresponds to resource, adds the contents of resource to the
		/// new part, and then closes the new part.
		/// </para>
		/// <para>If this method returns an error, the package writer is no longer usable.</para>
		/// <para>The resource parameter must be one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// The IXpsOMFontResource interface of a font resource that is used in the current page or a page that has already been added.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The IXpsOMImageResource interface of an image resource that is used in the current page or a page that has already been added.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The IXpsOMColorProfileResource interface of color profile resource that is used in the current page or a page that has
		/// already been added.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The IXpsOMStoryFragmentsResource interface of a story fragments resource that is used in the current page or a page that has
		/// already been added.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The IXpsOMDocumentStructureResource interface of a document structure resource that is used in the current document or a
		/// document that has already been added.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The IXpsOMSignatureBlockResource interface of a signature block resource that is used in the current document or a document
		/// that has already been added.
		/// </term>
		/// </item>
		/// </list>
		/// <para>This method returns an error if resource contains one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The IXpsOMRemoteDictionaryResource interface of a remote resource dictionary.</term>
		/// </item>
		/// <item>
		/// <term>The IXpsOMPrintTicketResource interface of a print ticket.</term>
		/// </item>
		/// <item>
		/// <term>The IXpsOMImageResource interface of a thumbnail image.</term>
		/// </item>
		/// </list>
		/// <para>
		/// This method returns an error when resource references a resource that has the same name as a resource that has already been
		/// added to the stream or for which there is no existing relationship.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompackagewriter-addresource HRESULT
		// AddResource( IXpsOMResource *resource );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void AddResource([In] IXpsOMResource resource);

		/// <summary>Closes any open parts of the package, then closes the package.</summary>
		/// <remarks>
		/// <para>If any discardable parts that are referenced by a call to AddPage have not been received, an error will be returned.</para>
		/// <para>After this method is called, calling any other IXpsOMPackageWriter method except IsClosed will return an error.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompackagewriter-close HRESULT Close();
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Close();

		/// <summary>Gets the status of the IXpsOMPackageWriter interface.</summary>
		/// <returns>
		/// <para>A pointer to a Boolean variable that receives the status of the IXpsOMPackageWriter interface.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The package is closed and no more content can be added.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The package is open and content can be added.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>If the IXpsOMPackageWriter interface is closed, operations on the package are not allowed.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompackagewriter-isclosed HRESULT
		// IsClosed( BOOL *isClosed );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsClosed();
	}

	/// <summary>
	/// <para>Provides the root node of a tree of objects that hold the contents of a single page.</para>
	/// <para>The <c>IXpsOMPage</c> interface corresponds to the <c>FixedPage</c> element in XPS document markup.</para>
	/// </summary>
	/// <remarks>
	/// <para>The code example that follows illustrates how to create an instance of this interface.</para>
	/// <para>For information about using this interface in a program, see Create a Blank XPS OM and Navigate the XPS OM.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsompage
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "741deebd-9dce-4cd9-883e-4586c10a4609")]
	[ComImport, Guid("D3E18888-F120-4FEE-8C68-35296EAE91D4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMPage : IXpsOMPart
	{
		/// <summary>Gets the name that will be used when the part is serialized.</summary>
		/// <returns>
		/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
		/// method), a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
		// GetPartName( IOpcPartUri **partUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Interface)]
		new IOpcPartUri? GetPartName();

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
		new void SetPartName([In] IOpcPartUri? partUri);

		/// <summary>Gets a pointer to the IXpsOMPageReference interface that contains the page.</summary>
		/// <returns>A pointer to the IXpsOMPageReference interface that contains the page.</returns>
		/// <remarks>When the page does not have an owner, a <c>NULL</c> pointer is returned in pageReference.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-getowner HRESULT GetOwner(
		// IXpsOMPageReference **pageReference );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMPageReference? GetOwner();

		/// <summary>Gets a pointer to an IXpsOMVisualCollection interface that contains a collection of the page's visual objects.</summary>
		/// <returns>A pointer to the IXpsOMVisualCollection interface that contains a collection of the page's visual objects.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-getvisuals HRESULT GetVisuals(
		// IXpsOMVisualCollection **visuals );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMVisualCollection GetVisuals();

		/// <summary>Gets the page dimensions.</summary>
		/// <returns>
		/// <para>The page dimensions.</para>
		/// <para>
		/// Size is described in XPS units. There are 96 XPS units per inch. For example, the dimensions of an 8.5" by 11.0" page are
		/// 816 by 1,056 XPS units.
		/// </para>
		/// </returns>
		/// <remarks>The default page size is passed to IXpsOMObjectFactory::CreatePage in the pageDimensions parameter.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-getpagedimensions HRESULT
		// GetPageDimensions( XPS_SIZE *pageDimensions );
		[MethodImpl(MethodImplOptions.InternalCall)]
		XPS_SIZE GetPageDimensions();

		/// <summary>Sets dimensions of the page.</summary>
		/// <param name="pageDimensions">
		/// <para>Dimensions of the page.</para>
		/// <para>
		/// Size is described in XPS units. There are 96 XPS units per inch. For example, the dimensions of an 8.5" by 11.0" page are
		/// 816 by 1,056 XPS units.
		/// </para>
		/// <para>The XPS_SIZE structure has the following properties:</para>
		/// <para>0 ≤ value )</para>
		/// <para>0 ≤ value )</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-setpagedimensions HRESULT
		// SetPageDimensions( const XPS_SIZE *pageDimensions );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetPageDimensions(in XPS_SIZE pageDimensions);

		/// <summary>Gets the dimensions of the page's content box.</summary>
		/// <returns>The dimensions of the content box.</returns>
		/// <remarks>
		/// <para>The content box indicates where ink appears on the page.</para>
		/// <para>The default content box of a page is</para>
		/// <list type="table">
		/// <listheader>
		/// <term>XPS_RECT field</term>
		/// <term>Default value</term>
		/// </listheader>
		/// <item>
		/// <term>x</term>
		/// <term>0</term>
		/// </item>
		/// <item>
		/// <term>y</term>
		/// <term>0</term>
		/// </item>
		/// <item>
		/// <term>width</term>
		/// <term>pageDimension.width</term>
		/// </item>
		/// <item>
		/// <term>height</term>
		/// <term>pageDimension.height</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-getcontentbox HRESULT
		// GetContentBox( XPS_RECT *contentBox );
		[MethodImpl(MethodImplOptions.InternalCall)]
		XPS_RECT GetContentBox();

		/// <summary>Sets the dimensions of the page's content box.</summary>
		/// <param name="contentBox">
		/// <para>The dimensions of the page's content box.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>contentBox field</term>
		/// <term>Valid values</term>
		/// </listheader>
		/// <item>
		/// <term>contentBox.width</term>
		/// <term>Greater than or equal to 0.0 and less than or equal to (pageDimensions.width - contentBox.x).</term>
		/// </item>
		/// <item>
		/// <term>contentBox.height</term>
		/// <term>Greater than or equal to 0.0 and less than or equal to (pageDimensions.height - contentBox.y).</term>
		/// </item>
		/// <item>
		/// <term>contentBox.x</term>
		/// <term>Greater than or equal to 0.0 and less than pageDimensions.width.</term>
		/// </item>
		/// <item>
		/// <term>contentBox.y</term>
		/// <term>Greater than or equal to 0.0 and less than pageDimensions.height.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>The content box specifies where ink appears on the page.</para>
		/// <para>The content box dimensions are not checked against the page dimensions until the page is serialized.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-setcontentbox HRESULT
		// SetContentBox( const XPS_RECT *contentBox );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetContentBox(in XPS_RECT contentBox);

		/// <summary>Gets the dimensions of the page's bleed box.</summary>
		/// <returns>The dimensions of the bleed box.</returns>
		/// <remarks>
		/// <para>The default bleed box of a page is:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>XPS_RECT field</term>
		/// <term>Default value</term>
		/// </listheader>
		/// <item>
		/// <term>x</term>
		/// <term>0</term>
		/// </item>
		/// <item>
		/// <term>y</term>
		/// <term>0</term>
		/// </item>
		/// <item>
		/// <term>width</term>
		/// <term>pageDimension.width</term>
		/// </item>
		/// <item>
		/// <term>height</term>
		/// <term>pageDimension.height</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-getbleedbox HRESULT
		// GetBleedBox( XPS_RECT *bleedBox );
		[MethodImpl(MethodImplOptions.InternalCall)]
		XPS_RECT GetBleedBox();

		/// <summary>Sets the dimensions of the page's bleed box.</summary>
		/// <param name="bleedBox">
		/// <para>The dimensions of the page's bleed box. This parameter must not be <c>NULL</c>.</para>
		/// <para>A valid bleed box has the following properties:</para>
		/// <para>####### x)) ≤ value )</para>
		/// <para>####### y)) ≤ value )</para>
		/// <para>0)</para>
		/// <para>0)</para>
		/// </param>
		/// <remarks>The bleed box dimensions are not checked against the page dimensions until the page is serialized.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-setbleedbox HRESULT
		// SetBleedBox( const XPS_RECT *bleedBox );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetBleedBox(in XPS_RECT bleedBox);

		/// <summary>Gets the <c>Language</c> property of the page.</summary>
		/// <returns>
		/// A language tag string that represents the language of the page contents. If the <c>Language</c> property has not been set, a
		/// <c>NULL</c> pointer is returned.
		/// </returns>
		/// <remarks>
		/// <para>The default value is the language tag string that is passed to IXpsOMObjectFactory::CreatePage in the language parameter.</para>
		/// <para>
		/// Internet Engineering Task Force (IETF) RFC 3066 describes the recommended encoding of the language tag string that is
		/// returned in language.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-getlanguage HRESULT
		// GetLanguage( StrPtrUni *language );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string? GetLanguage();

		/// <summary>Sets the <c>Language</c> property of the page.</summary>
		/// <param name="language">
		/// A language tag string that represents the language of the page content. A <c>NULL</c> pointer clears the previously assigned language.
		/// </param>
		/// <remarks>
		/// The language tag string must conform to the language tag syntax that is described in the Internet Engineering Task Force
		/// (IETF) RFC 3066. For more information, go to http://tools.ietf.org/html/rfc3066.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-setlanguage HRESULT
		// SetLanguage( LPCWSTR language );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetLanguage([In, MarshalAs(UnmanagedType.LPWStr)] string? language);

		/// <summary>Gets the <c>Name</c> property of the page.</summary>
		/// <returns>
		/// The <c>Name</c> property of the page. A <c>NULL</c> pointer is returned if the <c>Name</c> property has not been set.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-getname HRESULT GetName(
		// StrPtrUni *name );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string? GetName();

		/// <summary>Sets the <c>Name</c> property of this page.</summary>
		/// <param name="name">
		/// A pointer to the name string to be set as the page's <c>Name</c> property. A <c>NULL</c> pointer clears any previously
		/// assigned name.
		/// </param>
		/// <remarks>
		/// The <c>Name</c> property identifies the current page as a named, addressable point in a document, allowing the page to be
		/// referenced by a hyperlink.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-setname HRESULT SetName(
		// LPCWSTR name );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetName([In, MarshalAs(UnmanagedType.LPWStr)] string? name);

		/// <summary>Gets a Boolean value that indicates whether the page is the target of a hyperlink.</summary>
		/// <returns>
		/// <para>A Boolean value that indicates whether the page is the target of a hyperlink.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The page is the target of a hyperlink.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The page is not the target of a hyperlink.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-getishyperlinktarget HRESULT
		// GetIsHyperlinkTarget( BOOL *isHyperlinkTarget );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetIsHyperlinkTarget();

		/// <summary>Specifies whether the page is the target of a hyperlink.</summary>
		/// <param name="isHyperlinkTarget">
		/// <para>The Boolean value that indicates whether the page is the target of a hyperlink.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The page is the target of a hyperlink.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The page is not the target of a hyperlink.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// Only those pages that have this property set to <c>TRUE</c> will be included in the hyperlink targets that are collected by IXpsOMPageReference::CollectLinkTargets.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-setishyperlinktarget HRESULT
		// SetIsHyperlinkTarget( BOOL isHyperlinkTarget );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetIsHyperlinkTarget([In, MarshalAs(UnmanagedType.Bool)] bool isHyperlinkTarget);

		/// <summary>Gets a pointer to the resolved IXpsOMDictionary interface that is associated with this page.</summary>
		/// <returns>
		/// <para>A pointer to the resolved IXpsOMDictionary interface that is associated with this page.</para>
		/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the dictionary.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in resourceDictionary</term>
		/// </listheader>
		/// <item>
		/// <term>SetDictionaryLocal</term>
		/// <term>The local dictionary resource that is set by SetDictionaryLocal.</term>
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
		/// Whether the dictionary is local or is contained within a remote dictionary resource, this method returns an IXpsOMDictionary
		/// interface pointer. GetOwner determines whether the dictionary is remote.
		/// </para>
		/// <para>
		/// If a page contains a remote dictionary, <c>GetDictionary</c> will deserialize the dictionary. If the page contains a remote
		/// dictionary that is not valid, <c>GetDictionary</c> might return a deserialization error code.
		/// </para>
		/// <para>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-getdictionary HRESULT
		// GetDictionary( IXpsOMDictionary **resourceDictionary );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMDictionary? GetDictionary();

		/// <summary>
		/// Gets a pointer to the IXpsOMDictionary interface of the local, unshared dictionary that is associated with this page.
		/// </summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMDictionary interface of the local, unshared dictionary that is associated with this page. If no
		/// <c>IXpsOMDictionary</c> interface pointer has been set or if a remote dictionary resource has been set, a <c>NULL</c>
		/// pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in resourceDictionary</term>
		/// </listheader>
		/// <item>
		/// <term>SetDictionaryLocal</term>
		/// <term>The local dictionary resource that is set by SetDictionaryLocal.</term>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-getdictionarylocal HRESULT
		// GetDictionaryLocal( IXpsOMDictionary **resourceDictionary );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMDictionary? GetDictionaryLocal();

		/// <summary>Sets the IXpsOMDictionary interface pointer of the page's local dictionary resource.</summary>
		/// <param name="resourceDictionary">
		/// The IXpsOMDictionary interface pointer to be set for the page. A <c>NULL</c> pointer releases any previously assigned local dictionary.
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
		/// <term>The local dictionary resource that is set by SetDictionaryLocal.</term>
		/// <term>The local dictionary resource that is set by SetDictionaryLocal.</term>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-setdictionarylocal HRESULT
		// SetDictionaryLocal( IXpsOMDictionary *resourceDictionary );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetDictionaryLocal([In] IXpsOMDictionary? resourceDictionary);

		/// <summary>
		/// Gets a pointer to the IXpsOMRemoteDictionaryResource interface of the shared dictionary resource that is used by this page.
		/// </summary>
		/// <returns>
		/// <para>
		/// A pointer to the IXpsOMRemoteDictionaryResource interface of the shared dictionary resource that is used by this page. If no
		/// <c>IXpsOMRemoteDictionaryResource</c> interface has been set or if a local dictionary has been set, a <c>NULL</c> pointer is returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in remoteDictionaryResource</term>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-getdictionaryresource HRESULT
		// GetDictionaryResource( IXpsOMRemoteDictionaryResource **remoteDictionaryResource );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMRemoteDictionaryResource? GetDictionaryResource();

		/// <summary>Sets the IXpsOMRemoteDictionaryResource interface pointer of the page's remote dictionary resource.</summary>
		/// <param name="remoteDictionaryResource">
		/// The IXpsOMRemoteDictionaryResource interface pointer to be set for the page. A <c>NULL</c> value releases the previously
		/// assigned dictionary resource.
		/// </param>
		/// <remarks>
		/// <para>Setting this value will cause GetDictionaryLocal to return <c>NULL</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Most recent method called</term>
		/// <term>Object that is returned in resourceDictionary by GetDictionary</term>
		/// <term>Object that is returned in resourceDictionary by GetDictionaryLocal</term>
		/// <term>Object that is returned in remoteDictionaryResource by GetDictionaryResource</term>
		/// </listheader>
		/// <item>
		/// <term>SetDictionaryLocal</term>
		/// <term>The local dictionary resource that is set by SetDictionaryLocal.</term>
		/// <term>The local dictionary resource that is set by SetDictionaryLocal.</term>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-setdictionaryresource HRESULT
		// SetDictionaryResource( IXpsOMRemoteDictionaryResource *remoteDictionaryResource );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetDictionaryResource([In] IXpsOMRemoteDictionaryResource? remoteDictionaryResource);

		/// <summary>Writes the page to the specified stream.</summary>
		/// <param name="stream">The stream that receives the serialized contents of the page.</param>
		/// <param name="optimizeMarkupSize">
		/// <para>
		/// A Boolean value that indicates whether the document markup of the page is to be optimized for size when the page is written
		/// to the stream.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The package writer will attempt to optimize the markup for minimum size when writing the page to the stream.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The package writer will not attempt any optimization when writing the page to the stream.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// <para>
		/// To examine the XPS markup of a page before it is written to an XPS package, an application can call the <c>Write</c> method
		/// to write the page's contents to a stream. The application can then read that stream to examine the XPS markup as it would be
		/// serialized when it is written to the XPS package.
		/// </para>
		/// <para>The XPS markup that is written to the stream by this method contains the page markup but none of the page's resources.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-write HRESULT Write(
		// ISequentialStream *stream, BOOL optimizeMarkupSize );
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Write([In] ISequentialStream stream, [In, MarshalAs(UnmanagedType.Bool)] bool optimizeMarkupSize);

		/// <summary>Generates a unique name that can be used as a lookup key by a resource in a resource dictionary.</summary>
		/// <param name="type">The type of IXpsOMShareable object for which the lookup key is generated.</param>
		/// <returns>The lookup key string that is generated by this method.</returns>
		/// <remarks>
		/// <para>
		/// To be unique in the dictionary, the string generated by <c>GenerateUnusedLookupKey</c> consists of a prefix string that is
		/// based on the object type and is followed by four unique alphanumeric characters.
		/// </para>
		/// <para>The prefix string for each object type is shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Object type</term>
		/// <term>Prefix string for this object type</term>
		/// </listheader>
		/// <item>
		/// <term>XPS_OBJECT_TYPE_CANVAS</term>
		/// <term>Canvas_</term>
		/// </item>
		/// <item>
		/// <term>XPS_OBJECT_TYPE_GEOMETRY</term>
		/// <term>Geometry_</term>
		/// </item>
		/// <item>
		/// <term>XPS_OBJECT_TYPE_GLYPHS</term>
		/// <term>Glyphs_</term>
		/// </item>
		/// <item>
		/// <term>XPS_OBJECT_TYPE_IMAGE_BRUSH</term>
		/// <term>IBrush_</term>
		/// </item>
		/// <item>
		/// <term>XPS_OBJECT_TYPE_LINEAR_GRADIENT_BRUSH</term>
		/// <term>LGBrush_</term>
		/// </item>
		/// <item>
		/// <term>XPS_OBJECT_TYPE_MATRIX_TRANSFORM</term>
		/// <term>MTransform_</term>
		/// </item>
		/// <item>
		/// <term>XPS_OBJECT_TYPE_PATH</term>
		/// <term>Path_</term>
		/// </item>
		/// <item>
		/// <term>XPS_OBJECT_TYPE_RADIAL_GRADIENT_BRUSH</term>
		/// <term>RGBrush_</term>
		/// </item>
		/// <item>
		/// <term>XPS_OBJECT_TYPE_SOLID_COLOR_BRUSH</term>
		/// <term>SCBrush_</term>
		/// </item>
		/// <item>
		/// <term>XPS_OBJECT_TYPE_VISUAL_BRUSH</term>
		/// <term>VBrush_</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> This method returns a key string that is unique within the context of this page. It is not guaranteed to return
		/// a key that is unique in a remote dictionary resource that could be used by more than one page.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-generateunusedlookupkey
		// HRESULT GenerateUnusedLookupKey( XPS_OBJECT_TYPE type, StrPtrUni *key );
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GenerateUnusedLookupKey([In] XPS_OBJECT_TYPE type);

		/// <summary>Makes a deep copy of the interface.</summary>
		/// <returns>A pointer to the copy of the interface.</returns>
		/// <remarks>
		/// <para>This method does not update any of the resource pointers in the copy.</para>
		/// <para>The owner of the new interface is <c>NULL</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompage-clone HRESULT Clone(
		// IXpsOMPage **page );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMPage Clone();
	}

	/// <summary>
	/// <para>Enables virtualization of pages in an XPS document.</para>
	/// <para>
	/// A page reference defers loading of the full object model of a page until the page is requested. If the page has not been
	/// altered, it can also be unloaded on request.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>The code example that follows illustrates how to create an instance of this interface.</para>
	/// <para>For information about using this interface in a program, see Create a Blank XPS OM and Navigate the XPS OM.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsompagereference
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "cdebab24-f918-4235-b4d5-5ee1007ade87")]
	[ComImport, Guid("ED360180-6F92-4998-890D-2F208531A0A0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMPageReference
	{
		/// <summary>Gets a pointer to the IXpsOMDocument interface that contains the page reference.</summary>
		/// <returns>
		/// A pointer to the IXpsOMDocument interface that contains the page reference. If the page reference does not have an owner, a
		/// <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereference-getowner HRESULT
		// GetOwner( IXpsOMDocument **document );
		IXpsOMDocument? GetOwner();

		/// <summary>Gets a pointer to the IXpsOMPage interface that contains the page.</summary>
		/// <returns>A pointer to the IXpsOMPage interface of the page. If a page has not been set, a <c>NULL</c> pointer is returned.</returns>
		/// <remarks>
		/// <para>
		/// If a page has not been set but the IXpsOMPackage interface that contains the page's reference has loaded from an XPS
		/// package, this method will load and return the page. If a page has not been set and the <c>IXpsOMPackage</c> interface that
		/// contains this page reference has not loaded from an XPS package, a <c>NULL</c> pointer will be returned.
		/// </para>
		/// <para>
		/// Depending on the page's contents, this call might take some time to return and it might also cause unexpected changes in
		/// other objects in the document tree. For example, if the page has remote resource dictionary references, the remote resource
		/// dictionary might get modified.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereference-getpage HRESULT
		// GetPage( IXpsOMPage **page );
		IXpsOMPage? GetPage();

		/// <summary>Sets the IXpsOMPage interface of the page reference.</summary>
		/// <param name="page">The IXpsOMPage interface pointer of the page.</param>
		/// <remarks>
		/// <para>The page added by this method can be empty or fully constructed.</para>
		/// <para>
		/// If the incoming page has references to remote dictionary objects, those objects will not be imported into the document
		/// object by this call. They must be added in a separate call to the IXpsOMPage::SetDictionaryResource or
		/// IXpsOMCanvas::SetDictionaryResource method.
		/// </para>
		/// <para>
		/// If a page has been set, the calling method must first release that page before calling <c>SetPage</c> with a new page. To
		/// explain, once <c>SetPage</c> has been called with a new page, the original page cannot be discarded even if it still exists
		/// in the package.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereference-setpage HRESULT
		// SetPage( IXpsOMPage *page );
		void SetPage([In] IXpsOMPage page);

		/// <summary>Discards the page from memory.</summary>
		/// <remarks>
		/// <para>
		/// If SetPage has not been called, calling <c>DiscardPage</c> and then GetPage will return the virtualized page from the source
		/// package. If <c>SetPage</c> has been called, calling <c>DiscardPage</c> and then <c>GetPage</c> will return <c>NULL</c>.
		/// </para>
		/// <para>
		/// If the page referenced by this IXpsOMPageReference interface has been constructed entirely in memory and does not have a
		/// corresponding file, <c>DiscardPage</c> will delete the page from memory and the page's content will be lost. If the page has
		/// been constructed from a file, <c>DiscardPage</c> will delete the page from memory but will not alter the original file. The
		/// page can be reconstructed and read back into memory by calling GetPage.
		/// </para>
		/// <para>
		/// If the page has been constructed from a file and subsequently modified, <c>DiscardPage</c> will discard the page from
		/// memory, and any changes made to the page will be lost. Calling GetPage after this will re-read the original content from the file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereference-discardpage HRESULT DiscardPage();
		void DiscardPage();

		/// <summary>Gets the referenced page status, which indicates whether the page is loaded.</summary>
		/// <returns>
		/// <para>A Boolean value that indicates the status of the page.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The page is loaded.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The page is not loaded.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereference-ispageloaded HRESULT
		// IsPageLoaded( BOOL *isPageLoaded );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsPageLoaded();

		/// <summary>Gets the suggested dimensions of the page.</summary>
		/// <returns>
		/// <para>The suggested dimensions of the page.</para>
		/// <para>
		/// Size is described in XPS units. There are 96 XPS units per inch. For example, the dimensions of an 8.5" by 11.0" page are
		/// 816 by 1,056 XPS units.
		/// </para>
		/// </returns>
		/// <remarks><c>Note</c> If a dimension value has not been set, a value of –1.0 is returned for that dimension.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereference-getadvisorypagedimensions
		// HRESULT GetAdvisoryPageDimensions( XPS_SIZE *pageDimensions );
		XPS_SIZE GetAdvisoryPageDimensions();

		/// <summary>Sets the suggested dimensions of the page.</summary>
		/// <param name="pageDimensions">
		/// <para>The suggested dimensions to be set for the page.</para>
		/// <para>
		/// The <c>height</c> and <c>width</c> members must have the value of –1.0 or a value that is greater than or equal to +1.0.
		/// </para>
		/// <para>
		/// Size is described in XPS units. There are 96 XPS units per inch. For example, the dimensions of an 8.5" by 11.0" page are
		/// 816 by 1,056 XPS units.
		/// </para>
		/// </param>
		/// <remarks>
		/// The <c>height</c> and <c>width</c> members of the XPS_SIZE structure that is referenced by pageDimensions must have values
		/// that are greater than or equal to +1.0, if those fields' values are to be set, or –1.0 if not. For example, if an advisory
		/// dimension were to be set just for the page width, pageDimensions.width would have the desired value and
		/// pageDimensions.height would have the value of –1.0.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereference-setadvisorypagedimensions
		// HRESULT SetAdvisoryPageDimensions( const XPS_SIZE *pageDimensions );
		void SetAdvisoryPageDimensions(in XPS_SIZE pageDimensions);

		/// <summary>
		/// Gets a pointer to the IXpsOMStoryFragmentsResource interface of the StoryFragments part resource that is associated with the page.
		/// </summary>
		/// <returns>
		/// A pointer to the IXpsOMStoryFragmentsResource interface of the StoryFragments part resource that is associated with the
		/// page. If there is no StoryFragments part, a <c>NULL</c> pointer is returned.
		/// </returns>
		/// <remarks>
		/// <para>
		/// After the resource is parsed and loaded into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because when a resource is loaded, all of the relationships are parsed.
		/// </para>
		/// <para>
		/// The StoryFragments part of a page contains the XML markup that describes the portions of one or more stories that are
		/// associated with a single fixed page. Some of the document contents that might be described by the XML markup in a
		/// StoryFragments part include the story's tables and paragraphs that are found on the page.
		/// </para>
		/// <para>The XML markup in the DocumentStructure and StoryFragments parts is described in the XML Paper Specification.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereference-getstoryfragmentsresource
		// HRESULT GetStoryFragmentsResource( IXpsOMStoryFragmentsResource **storyFragmentsResource );
		IXpsOMStoryFragmentsResource? GetStoryFragmentsResource();

		/// <summary>
		/// Sets the IXpsOMStoryFragmentsResource interface pointer of the StoryFragments resource to be assigned to the page.
		/// </summary>
		/// <param name="storyFragmentsResource">
		/// A pointer to the IXpsOMStoryFragmentsResource interface of the StoryFragments part resource to be assigned to the page. If
		/// an <c>IXpsOMStoryFragmentsResource</c> interface has been set, a <c>NULL</c> pointer will release it.
		/// </param>
		/// <remarks>
		/// <para>
		/// The StoryFragments part of a page contains the XML markup that describes the portions of one or more stories that are
		/// associated with a single fixed page. Some of the document contents that might be described by the XML markup in a
		/// StoryFragments part include the story's tables and paragraphs that are found on the page.
		/// </para>
		/// <para>The XML markup of the DocumentStructure and StoryFragments parts is described in the XML Paper Specification.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereference-setstoryfragmentsresource
		// HRESULT SetStoryFragmentsResource( IXpsOMStoryFragmentsResource *storyFragmentsResource );
		void SetStoryFragmentsResource([In] IXpsOMStoryFragmentsResource? storyFragmentsResource);

		/// <summary>
		/// Gets a pointer to the IXpsOMPrintTicketResource interface of the page-level print ticket resource that is associated with
		/// the page.
		/// </summary>
		/// <returns>
		/// A pointer to the IXpsOMPrintTicketResource interface of the page-level print ticket resource that is associated with the
		/// page. If no print ticket resource has been set, a <c>NULL</c> pointer is returned.
		/// </returns>
		/// <remarks>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereference-getprintticketresource
		// HRESULT GetPrintTicketResource( IXpsOMPrintTicketResource **printTicketResource );
		IXpsOMPrintTicketResource? GetPrintTicketResource();

		/// <summary>
		/// Sets the IXpsOMPrintTicketResource interface pointer of the page-level print ticket resource that is to be assigned to the page.
		/// </summary>
		/// <param name="printTicketResource">
		/// A pointer to the IXpsOMPrintTicketResource interface of the page-level print ticket resource that is to be assigned to the
		/// page. If a print ticket has already been set, a <c>NULL</c> pointer releases it.
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereference-setprintticketresource
		// HRESULT SetPrintTicketResource( IXpsOMPrintTicketResource *printTicketResource );
		void SetPrintTicketResource([In] IXpsOMPrintTicketResource? printTicketResource);

		/// <summary>
		/// Gets a pointer to the IXpsOMImageResource interface of the thumbnail image resource that is associated with the page.
		/// </summary>
		/// <returns>
		/// A pointer to the IXpsOMImageResource interface of the thumbnail image resource that is associated with the page. If no
		/// thumbnail image resource has been assigned to the page, a <c>NULL</c> pointer is returned.
		/// </returns>
		/// <remarks>
		/// <para>The thumbnail image is a small, visual representation of the page's contents.</para>
		/// <para>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereference-getthumbnailresource
		// HRESULT GetThumbnailResource( IXpsOMImageResource **imageResource );
		IXpsOMImageResource? GetThumbnailResource();

		/// <summary>
		/// Sets the pointer to the IXpsOMImageResource interface of the thumbnail image resource to be assigned to the page.
		/// </summary>
		/// <param name="imageResource">
		/// A pointer to the IXpsOMImageResource interface of the thumbnail image resource to be assigned to the page. If an
		/// <c>IXpsOMImageResource</c> interface has been set, a <c>NULL</c> pointer will release it.
		/// </param>
		/// <remarks>
		/// <para>The thumbnail image is a small, visual representation of the document's contents.</para>
		/// <para>The image type of the image resource must be either XPS_IMAGE_TYPE_JPEG or <c>XPS_IMAGE_TYPE_PNG</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereference-setthumbnailresource
		// HRESULT SetThumbnailResource( IXpsOMImageResource *imageResource );
		void SetThumbnailResource([In] IXpsOMImageResource? imageResource);

		/// <summary>
		/// Gets an IXpsOMNameCollection interface that contains the names of all the document subtree objects whose
		/// <c>IsHyperlinkTarget</c> property is set to <c>TRUE</c>.
		/// </summary>
		/// <returns>
		/// <para>
		/// A pointer to an IXpsOMNameCollection interface that contains the names of all the document subtree objects whose
		/// <c>IsHyperlinkTarget</c> property is set to <c>TRUE</c>. If no such objects exist in the document, the
		/// <c>IXpsOMNameCollection</c> interface will be empty.
		/// </para>
		/// <para><c>Note</c> Every time this method is called, it returns a new collection.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the page is originally loaded from a package but is not currently loaded in the object model, this method returns the
		/// values specified in the original <c>PageContent.LinkTargets</c> markup.
		/// </para>
		/// <para>If the document does not have any link targets, the name collection returned in linkTargets will be empty.</para>
		/// <para>To get the number of elements in the collection that is returned in linkTargets, call the collection's GetCount method.</para>
		/// <para>
		/// This method returns the pointer to a new collection every time it is called. To prevent a memory leak, the pointer to a
		/// previous collection should be released when it is no longer needed or before the pointer variable is reused for another call
		/// to this method. The following code example shows how this can be done in a program.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereference-collectlinktargets
		// HRESULT CollectLinkTargets( IXpsOMNameCollection **linkTargets );
		IXpsOMNameCollection CollectLinkTargets();

		/// <summary>Creates a list of all part-based resources that are associated with the page.</summary>
		/// <returns>
		/// A pointer to the IXpsOMPartResources interface that contains the list of all part-based resources that are associated with
		/// the page.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the page is not loaded when this method is called, this method finds the part-based resources that are associated with
		/// this page by parsing the relationships part of the page and returns them in the partResources parameter. If the page is
		/// loaded, this method traverses the page's object model to find the part-based resources and returns them in partResources.
		/// </para>
		/// <para>
		/// The list of resource parts that are returned in the IXpsOMPartResources interface is a snapshot of the document structure
		/// that is taken when the method is called. Changes made to the document after this call are not reflected in the
		/// <c>IXpsOMPartResources</c> interface after it is returned by this method. Likewise, changes made to the
		/// <c>IXpsOMPartResources</c> interface that is returned by this method will not be reflected in the document contents.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereference-collectpartresources
		// HRESULT CollectPartResources( IXpsOMPartResources **partResources );
		IXpsOMPartResources CollectPartResources();

		/// <summary>
		/// Gets a Boolean value that indicates whether the document sub-tree of the referenced page includes any Glyphs that have a
		/// font resource whose <c>EmbeddingOption</c> property is set to XPS_FONT_EMBEDDING_RESTRICTED.
		/// </summary>
		/// <returns>
		/// <para>
		/// A Boolean value that indicates whether the document sub-tree of the referenced page includes any IXpsOMGlyphs interfaces
		/// that have a font resource whose <c>EmbeddingOption</c> property is set to XPS_FONT_EMBEDDING_RESTRICTED.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>
		/// If the referenced page is loaded, the page references at least one font resource whose EmbeddingOption property is set to
		/// XPS_FONT_EMBEDDING_RESTRICTED. If the referenced page is not loaded, it has a relationship with at least one font resource
		/// whose EmbeddingOption property is set to XPS_FONT_EMBEDDING_RESTRICTED.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>
		/// If the referenced page is loaded, the page does not reference any font resources whose EmbeddingOption property is set to
		/// XPS_FONT_EMBEDDING_RESTRICTED. If the referenced page is not loaded, it does not have a relationship with a font resource
		/// whose EmbeddingOption property is set to XPS_FONT_EMBEDDING_RESTRICTED.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This value is not updated automatically. If fonts or glyphs are added or removed such that the value changes,
		/// <c>HasRestrictedFonts</c> must be called again to get the current value.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereference-hasrestrictedfonts
		// HRESULT HasRestrictedFonts( BOOL *restrictedFonts );
		[return: MarshalAs(UnmanagedType.Bool)]
		bool HasRestrictedFonts();

		/// <summary>Makes a deep copy of the interface.</summary>
		/// <returns>A pointer to the copy of the interface.</returns>
		/// <remarks>This method does not update the resource pointers in the new IXpsOMPageReference interface.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereference-clone HRESULT Clone(
		// IXpsOMPageReference **pageReference );
		IXpsOMPageReference Clone();
	}

	/// <summary>A collection of IXpsOMPageReference interface pointers.</summary>
	/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsompagereferencecollection
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "4b51bc29-c653-41fa-bbd3-9ff529f84e4e")]
	[ComImport, Guid("CA16BA4D-E7B9-45C5-958B-F98022473745"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMPageReferenceCollection
	{
		/// <summary>Gets the number of IXpsOMPageReference interface pointers in the collection.</summary>
		/// <returns>The number of IXpsOMPageReference interface pointers in the collection.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereferencecollection-getcount
		// HRESULT GetCount( UINT32 *count );
		uint GetCount();

		/// <summary>Gets an IXpsOMPageReference interface pointer from a specified location in the collection.</summary>
		/// <param name="index">The zero-based index of the IXpsOMPageReference interface pointer to be obtained.</param>
		/// <returns>The IXpsOMPageReference interface pointer at the location specified by index.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereferencecollection-getat
		// HRESULT GetAt( UINT32 index, IXpsOMPageReference **pageReference );
		IXpsOMPageReference GetAt([In] uint index);

		/// <summary>Inserts an IXpsOMPageReference interface pointer at a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection where the interface pointer that is passed in pageReference is to be inserted.
		/// </param>
		/// <param name="pageReference">
		/// The IXpsOMPageReference interface pointer that is to be inserted at the location specified by index.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method inserts the IXpsOMPageReference interface pointer that is passed in
		/// pageReference. Prior to the insertion, the pointer in this and all subsequent locations is moved up by one index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereferencecollection-insertat
		// HRESULT InsertAt( UINT32 index, IXpsOMPageReference *pageReference );
		void InsertAt([In] uint index, [In] IXpsOMPageReference pageReference);

		/// <summary>Removes and releases an IXpsOMPageReference interface pointer from a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection from which an IXpsOMPageReference interface pointer is to be removed and released.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method releases the interface referenced by the pointer at the location specified by index. After releasing the
		/// interface, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereferencecollection-removeat
		// HRESULT RemoveAt( UINT32 index );
		void RemoveAt([In] uint index);

		/// <summary>Replaces an IXpsOMPageReference interface pointer at a specified location in the collection.</summary>
		/// <param name="index">The zero-based index in the collection where an IXpsOMPageReference interface pointer is to be replaced.</param>
		/// <param name="pageReference">
		/// The IXpsOMPageReference interface pointer that will replace current contents at the location specified by index.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method releases the IXpsOMPageReference interface referenced by the existing
		/// pointer, then writes the pointer that is passed in pageReference.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereferencecollection-setat
		// HRESULT SetAt( UINT32 index, IXpsOMPageReference *pageReference );
		void SetAt([In] uint index, [In] IXpsOMPageReference pageReference);

		/// <summary>Appends an IXpsOMPageReference interface to the end of the collection.</summary>
		/// <param name="pageReference">A pointer to the IXpsOMPageReference interface that is to be appended to the collection.</param>
		/// <returns>If the method succeeds, it returns S_OK; otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompagereferencecollection-append
		// HRESULT Append( IXpsOMPageReference *pageReference );
		void Append([In] IXpsOMPageReference pageReference);
	}

	/// <summary>The base interface for all XPS document part interfaces.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsompart
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "71cd0155-6c95-42ca-bfc3-dffd43d95dc9")]
	[ComImport, Guid("74EB2F0B-A91E-4486-AFAC-0FABECA3DFC6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMPart
	{
		/// <summary>Gets the name that will be used when the part is serialized.</summary>
		/// <returns>
		/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
		/// method), a <c>NULL</c> pointer is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
		// GetPartName( IOpcPartUri **partUri );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IOpcPartUri? GetPartName();

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
		void SetPartName([In] IOpcPartUri? partUri);
	}

	/// <summary>Provides access to all shared, part-based resources of the XPS document.</summary>
	/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsompartresources
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "9f706f23-25a0-40ee-93f4-3d7ac98ad6ed")]
	[ComImport, Guid("F4CF7729-4864-4275-99B3-A8717163ECAF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMPartResources
	{
		/// <summary>Gets the IXpsOMFontResourceCollection interface that contains the fonts that are used in the XPS document.</summary>
		/// <returns>A pointer to the IXpsOMFontResourceCollection interface that contains the fonts that are used in the XPS document.</returns>
		/// <remarks>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompartresources-getfontresources
		// HRESULT GetFontResources( IXpsOMFontResourceCollection **fontResources );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMFontResourceCollection GetFontResources();

		/// <summary>Gets the IXpsOMImageResourceCollection interface that contains the images that are used in the XPS document.</summary>
		/// <returns>A pointer to the IXpsOMImageResourceCollection interface that contains the images that are used in the XPS document.</returns>
		/// <remarks>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompartresources-getimageresources
		// HRESULT GetImageResources( IXpsOMImageResourceCollection **imageResources );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMImageResourceCollection GetImageResources();

		/// <summary>
		/// Gets the IXpsOMColorProfileResourceCollection interface that contains the color profiles that are used in the XPS document.
		/// </summary>
		/// <returns>
		/// A pointer to the IXpsOMColorProfileResourceCollection interface that contains the color profiles that are used in the XPS document.
		/// </returns>
		/// <remarks>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompartresources-getcolorprofileresources
		// HRESULT GetColorProfileResources( IXpsOMColorProfileResourceCollection **colorProfileResources );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMColorProfileResourceCollection GetColorProfileResources();

		/// <summary>
		/// Gets the IXpsOMRemoteDictionaryResourceCollection interface that contains the remote resource dictionaries that are used in
		/// the XPS document.
		/// </summary>
		/// <returns>
		/// A pointer to the IXpsOMRemoteDictionaryResourceCollection interface that contains the remote resource dictionaries that are
		/// used in the XPS document.
		/// </returns>
		/// <remarks>
		/// After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource.
		/// This occurs because all of the relationships are parsed when a resource is loaded.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompartresources-getremotedictionaryresources
		// HRESULT GetRemoteDictionaryResources( IXpsOMRemoteDictionaryResourceCollection **dictionaryResources );
		[MethodImpl(MethodImplOptions.InternalCall)]
		IXpsOMRemoteDictionaryResourceCollection GetRemoteDictionaryResources();
	}

	/// <summary>A collection of IOpcPartUri interface pointers.</summary>
	/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomparturicollection
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "05fe9700-19e6-4e63-9693-cfa4b019f643")]
	[ComImport, Guid("57C650D4-067C-4893-8C33-F62A0633730F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IXpsOMPartUriCollection
	{
		/// <summary>Gets the number of IOpcPartUri interface pointers in the collection.</summary>
		/// <returns>The number of IOpcPartUri interface pointers in the collection.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomparturicollection-getcount HRESULT
		// GetCount( UINT32 *count );
		uint GetCount();

		/// <summary>Gets an IOpcPartUri interface pointer from a specified location in the collection.</summary>
		/// <param name="index">The zero-based index of the IOpcPartUri interface pointer to be obtained.</param>
		/// <returns>The IOpcPartUri interface pointer at the location specified by index.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomparturicollection-getat HRESULT
		// GetAt( UINT32 index, IOpcPartUri **partUri );
		IOpcPartUri GetAt([In] uint index);

		/// <summary>Inserts an IOpcPartUri interface pointer at a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index of the collection where the interface pointer that is passed in partUri is to be inserted.
		/// </param>
		/// <param name="partUri">The IOpcPartUri interface pointer that is to be inserted at the location specified by index.</param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method inserts the IOpcPartUri interface pointer that is passed in partUri. Prior
		/// to the insertion, the pointer in this and all subsequent locations is moved up by one index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomparturicollection-insertat HRESULT
		// InsertAt( UINT32 index, IOpcPartUri *partUri );
		void InsertAt([In] uint index, [In] IOpcPartUri partUri);

		/// <summary>Removes and releases an IOpcPartUri interface pointer from a specified location in the collection.</summary>
		/// <param name="index">
		/// The zero-based index in the collection from which an IOpcPartUri interface pointer is to be removed and released.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method releases the interface referenced by the pointer at the location specified by index. After releasing the
		/// interface, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomparturicollection-removeat HRESULT
		// RemoveAt( UINT32 index );
		void RemoveAt([In] uint index);

		/// <summary>Replaces an IOpcPartUri interface pointer at a specified location in the collection.</summary>
		/// <param name="index">The zero-based index of the collection where an IOpcPartUri interface pointer is to be replaced.</param>
		/// <param name="partUri">
		/// The IOpcPartUri interface pointer that will replace current contents at the location specified by index.
		/// </param>
		/// <remarks>
		/// <para>
		/// At the location specified by index, this method releases the IOpcPartUri interface referenced by the existing pointer, then
		/// writes the pointer that is passed in partUri.
		/// </para>
		/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomparturicollection-setat HRESULT
		// SetAt( UINT32 index, IOpcPartUri *partUri );
		void SetAt([In] uint index, [In] IOpcPartUri partUri);

		/// <summary>Appends an IOpcPartUri interface to the end of the collection.</summary>
		/// <param name="partUri">A pointer to the IOpcPartUri interface that is to be appended to the collection.</param>
		/// <returns>If the method succeeds, it returns S_OK; otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomparturicollection-append HRESULT
		// Append( IOpcPartUri *partUri );
		void Append([In] IOpcPartUri partUri);
	}
}