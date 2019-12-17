using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.UrlMon;

namespace Vanara.PInvoke
{
	/// <summary>Interfaces from the Microsoft Packaging API for Open Packaging.</summary>
	public static partial class Opc
	{
		/// <summary>
		/// Represents the part name of a part. If the part is a Relationships part, it is represented by the IOpcRelationshipSet interface;
		/// otherwise, it is represented by the IOpcPart interface.
		/// </summary>
		/// <remarks>
		/// <para>Support on Previous Windows Versions</para>
		/// <para>
		/// The behavior and performance of this interface is the same on all supported Windows versions. For more information, see Getting
		/// Started with the Packaging API, and Platform Update for Windows Vista.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>Packaging objects are not thread-safe.</para>
		/// <para>For more information, see the Getting Started with the Packaging API.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcparturi
		[PInvokeData("msopc.h", MSDNShortId = "81123212-7a32-4833-b81f-8454a544327d")]
		[ComImport, Guid("7D3BABE7-88B2-46BA-85CB-4203CB016C87"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), TypeLibType(TypeLibTypeFlags.FNonExtensible)]
		public interface IOpcPartUri : IOpcUri
		{
			/// <summary>
			/// Returns an integer that indicates whether the URIs represented by the current part URI object and a specified part URI
			/// object are equivalent.
			/// </summary>
			/// <param name="partUri">
			/// A pointer to the IOpcPartUri interface of the part URI object to compare with the current part URI object.
			/// </param>
			/// <returns>
			/// <para>Receives an integer that indicates whether the two part URI objects are equivalent.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>&lt;0</term>
			/// <term>The current part URI object is less than the input part URI object that is passed in partUri.</term>
			/// </item>
			/// <item>
			/// <term>0</term>
			/// <term>The current part URI object is equivalent to the input part URI object that is passed in partUri.</term>
			/// </item>
			/// <item>
			/// <term>&gt;0</term>
			/// <term>The current part URI object is greater than the input part URI object that is passed in partUri.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>Support on Previous Windows Versions</para>
			/// <para>
			/// The behavior and performance of this method is the same on all supported Windows versions. For more information, see Getting
			/// Started with the Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcparturi-compareparturi HRESULT ComparePartUri(
			// IOpcPartUri *partUri, INT32 *comparisonResult );
			int ComparePartUri([In] IOpcPartUri partUri);

			/// <summary>
			/// Gets the source URI of the relationships that are stored in a Relationships part. The current part URI object represents the
			/// part name of that Relationships part.
			/// </summary>
			/// <returns>
			/// A pointer to the IOpcUri interface of the OPC URI object that represents the URI of the source of the relationships stored
			/// in the Relationships part.
			/// </returns>
			/// <remarks>
			/// <para>
			/// If the current part URI object represents the part name of the Relationships part that stores package relationships
			/// ("/_rels/.rels"), the OPC URI object returned in sourceUri will represent the package root ("/").
			/// </para>
			/// <para>
			/// If the current part URI object is not the part name of a Relationships part, this method fails with the
			/// <c>OPC_E_RELATIONSHIP_URI_REQUIRED</c> error. The syntax for Relationship part names is specified in the OPC.
			/// </para>
			/// <para>The following table shows possible current part URIs and the source URI that would be returned by this method.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Current Part URI</term>
			/// <term>Current Part URI Description</term>
			/// <term>Source URI</term>
			/// <term>Source URI Description</term>
			/// <term>Return Value</term>
			/// </listheader>
			/// <item>
			/// <term>/mydoc/_rels/picture.jpg.rels</term>
			/// <term>The part name of a Relationships part</term>
			/// <term>/mydoc/picture.jpg</term>
			/// <term>
			/// The part name of the part that is the source of the relationships stored in the Relationships part that is represented by
			/// the current part URI object
			/// </term>
			/// <term>S_OK</term>
			/// </item>
			/// <item>
			/// <term>/_rels/.rels</term>
			/// <term>The part name of a Relationships part</term>
			/// <term>/</term>
			/// <term>
			/// The package root; the source of the relationships stored in the Relationships part that is represented by the current part
			/// URI object
			/// </term>
			/// <term>S_OK</term>
			/// </item>
			/// <item>
			/// <term>/mydoc/image/chart1.jpg</term>
			/// <term>The part name of a part that is not a Relationships part</term>
			/// <term>Undefined</term>
			/// <term>Undefined</term>
			/// <term>OPC_E_RELATIONSHIP_URI_REQUIRED</term>
			/// </item>
			/// <item>
			/// <term>/_rels/a.jpg</term>
			/// <term>The part name of a part that is not a Relationships part</term>
			/// <term>Undefined</term>
			/// <term>Undefined</term>
			/// <term>OPC_E_RELATIONSHIP_URI_REQUIRED</term>
			/// </item>
			/// </list>
			/// <para>Support on Previous Windows Versions</para>
			/// <para>
			/// The behavior and performance of this method is the same on all supported Windows versions. For more information, see Getting
			/// Started with the Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcparturi-getsourceuri HRESULT GetSourceUri( IOpcUri
			// **sourceUri );
			IOpcUri GetSourceUri();

			/// <summary>Returns a value that indicates whether the current part URI object represents the part name of a Relationships
			/// part.</summary> <returns> <para>Receives a value that indicates whether the current part URI object represents the part name
			/// of a Relationships part.</para> <list type="table"> <listheader> <term>Value</term> <term>Meaning</term> </listheader>
			/// <item> <term>TRUE</term> <term>The current part URI object represents the part name of a Relationships part.</term> </item>
			/// <item> <term>FALSE</term> <term>The current part URI object does not represent the part name of a Relationships part.</term>
			/// </item> </list> </param> </returns> <remarks> <para>Support on Previous Windows Versions</para> <para>The behavior and
			/// performance of this method is the same on all supported Windows versions. For more information, see Getting Started with the
			/// Packaging API, and Platform Update for Windows Vista.</para> <para>Thread Safety</para> <para>Packaging objects are not
			/// thread-safe.</para> <para>For more information, see the Getting Started with the Packaging API.</para> </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcparturi-isrelationshipsparturi HRESULT
			// IsRelationshipsPartUri( BOOL *isRelationshipUri );
			[return: MarshalAs(UnmanagedType.Bool)]
			bool IsRelationshipsPartUri();
		}

		/// <summary>Represents the URI of the package root or of a part that is relative to the package root.</summary>
		/// <remarks>
		/// <para>Support on Previous Windows Versions</para>
		/// <para>
		/// The behavior and performance of this interface is the same on all supported Windows versions. For more information, see the
		/// Getting Started with the Packaging API, and Platform Update for Windows Vista.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nn-msopc-iopcuri
		[PInvokeData("msopc.h", MSDNShortId = "35ce7946-f7e7-4ac3-852f-e3fcca23d6d4")]
		[ComImport, Guid("BC9C1B9B-D62C-49EB-AEF0-3B4E0B28EBED"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), TypeLibType(TypeLibTypeFlags.FNonExtensible)]
		public interface IOpcUri : IUri
		{
			/// <summary>
			/// Forms the part name of the part that is referenced by the specified relative URI. The specified relative URI of the part is
			/// resolved against the URI represented as the current OPC URI object.
			/// </summary>
			/// <param name="relativeUri">
			/// <para>A pointer to the IUri interface of the relative URI of the part.</para>
			/// <para>
			/// To form the part URI object that represents the part name, this input URI is resolved against the URI represented as the
			/// current OPC URI object. Therefore, the input URI must be relative to the URI represented by the current OPC URI object.
			/// </para>
			/// <para>
			/// This URI may include a fragment component; however, the fragment will be ignored and will not be included in the part name
			/// to be formed. A fragment component is preceded by a '#', as described in RFC 3986: URI Generic Syntax.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>A pointer to the IOpcPartUri interface of the part URI object that represents the part name.</para>
			/// <para>
			/// The part URI object is formed by resolving the relative URI in relativeUri against the URI represented by the current OPC
			/// URI object.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>Example input and output:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Input relative IUri</term>
			/// <term>Current IOpcUri</term>
			/// <term>Formed IOpcPartUri</term>
			/// </listheader>
			/// <item>
			/// <term>picture.jpg</term>
			/// <term>/mydoc/markup/page.xml</term>
			/// <term>/mydoc/markup/picture.jpg</term>
			/// </item>
			/// <item>
			/// <term>../picture.jpg</term>
			/// <term>/mydoc/markup/page.xml</term>
			/// <term>/mydoc/picture.jpg</term>
			/// </item>
			/// <item>
			/// <term>../../images/picture.jpg</term>
			/// <term>/mydoc/page.xml</term>
			/// <term>/images/picture.jpg</term>
			/// </item>
			/// </list>
			/// <para>
			/// For information about how to use this method to help resolve a part name, see Resolving a Part Name from a Target URI.
			/// </para>
			/// <para>Support on Previous Windows Versions</para>
			/// <para>
			/// The behavior and performance of this method is the same on all supported Windows versions. For more information, see Getting
			/// Started with the Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcuri-combineparturi HRESULT CombinePartUri( IUri
			// *relativeUri, IOpcPartUri **combinedUri );
			IOpcPartUri CombinePartUri([In] IUri relativeUri);

			/// <summary>
			/// Gets the part name of the Relationships part that stores relationships that have the source URI represented by the current
			/// OPC URI object.
			/// </summary>
			/// <returns>
			/// A pointer to the IOpcPartUri interface of the part URI object that represents the part name of the Relationships part. The
			/// source URI of the relationships stored in this Relationships part is represented by the current OPC URI object.
			/// </returns>
			/// <remarks>
			/// <para>The following table shows Relationships part URIs for some OPC URIs.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>OPC URI</term>
			/// <term>Relationships Part Name</term>
			/// <term>Return Value</term>
			/// </listheader>
			/// <item>
			/// <term>/mydoc/images/picture.jpg</term>
			/// <term>/mydoc/images/_rels/picture.jpg.rels</term>
			/// <term>S_OK</term>
			/// </item>
			/// <item>
			/// <term>/</term>
			/// <term>/_rels/.rels</term>
			/// <term>S_OK</term>
			/// </item>
			/// <item>
			/// <term>/mydoc/images/_rels/picture.jpg.rels</term>
			/// <term>Undefined</term>
			/// <term>OPC_E_NONCONFORMING_URI</term>
			/// </item>
			/// </list>
			/// <para>Support on Previous Windows Versions</para>
			/// <para>
			/// The behavior and performance of this method is the same on all supported Windows versions. For more information, see Getting
			/// Started with the Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcuri-getrelationshipsparturi HRESULT
			// GetRelationshipsPartUri( IOpcPartUri **relationshipPartUri );
			IOpcPartUri GetRelationshipsPartUri();

			/// <summary>Forms a relative URI for a specified part, relative to the URI represented by the current OPC URI object.</summary>
			/// <param name="targetPartUri">
			/// A pointer to the IOpcPartUri interface of the part URI object that represents the part name from which the relative URI is formed.
			/// </param>
			/// <returns>A pointer to the IUri interface of the URI of the part, relative to the current OPC URI object.</returns>
			/// <remarks>
			/// <para>Example input and output:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Input IOpcPartUri represents</term>
			/// <term>Current IOpcUri represents</term>
			/// <term>Returned relative IUri represents</term>
			/// </listheader>
			/// <item>
			/// <term>/mydoc/markup/page.xml</term>
			/// <term>/mydoc/markup/picture.jpg</term>
			/// <term>picture.jpg</term>
			/// </item>
			/// <item>
			/// <term>/mydoc/markup/page.xml</term>
			/// <term>/mydoc/picture.jpg</term>
			/// <term>../picture.jpg</term>
			/// </item>
			/// <item>
			/// <term>/mydoc/markup/page.xml</term>
			/// <term>/mydoc/images/pictures.jpg</term>
			/// <term>../images/pictures.jpg</term>
			/// </item>
			/// </list>
			/// <para>Support on Previous Windows Versions</para>
			/// <para>
			/// The behavior and performance of this method is the same on all supported Windows versions. For more information, see Getting
			/// Started with the Packaging API, and Platform Update for Windows Vista.
			/// </para>
			/// <para>Thread Safety</para>
			/// <para>Packaging objects are not thread-safe.</para>
			/// <para>For more information, see the Getting Started with the Packaging API.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/msopc/nf-msopc-iopcuri-getrelativeuri HRESULT GetRelativeUri( IOpcPartUri
			// *targetPartUri, IUri **relativeUri );
			IUri GetRelativeUri([In] IOpcPartUri targetPartUri);
		}
	}
}